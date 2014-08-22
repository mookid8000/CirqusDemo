using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using d60.Cirqus;
using d60.Cirqus.Aggregates;
using d60.Cirqus.Config;
using d60.Cirqus.MongoDb.Events;
using d60.Cirqus.MongoDb.Views;
using d60.Cirqus.Views.ViewManagers;
using MongoDB.Driver;
using Web.Views;

namespace Web.Installers
{
    public class CirqusInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IViewManager, MongoDbViewManager<ListOfTodoomListsView>>()
                .UsingFactoryMethod(k =>
                {
                    var database = k.Resolve<MongoDatabase>();

                    return new MongoDbViewManager<ListOfTodoomListsView>(database, typeof(ListOfTodoomListsView).Name);
                }),

                Component.For<ICommandProcessor>()
                    .UsingFactoryMethod(k =>
                    {
                        var database = k.Resolve<MongoDatabase>();

                        var eventStore = new MongoDbEventStore(database, "Events");
                        var aggregateRootRepository = new DefaultAggregateRootRepository(eventStore);

                        var eventDispatcher = new ViewManagerEventDispatcher(aggregateRootRepository, k.ResolveAll<IViewManager>());

                        var commandProcessor = new CommandProcessor(eventStore, aggregateRootRepository, eventDispatcher);

                        commandProcessor.Initialize();

                        return commandProcessor;
                    })
                    .LifestyleSingleton()
                );
        }
    }
}