using System.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MongoDB.Driver;

namespace Web.Installers
{
    public class MongoDbInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<MongoDatabase>()
                    .UsingFactoryMethod(k =>
                    {
                        var mongodbLocalhostTodoom = ConfigurationManager.AppSettings["mongodb"];
                        var mongoUrl = new MongoUrl(mongodbLocalhostTodoom);

                        var database = new MongoClient(mongoUrl)
                            .GetServer()
                            .GetDatabase(mongoUrl.DatabaseName);

                        return database;
                    })
                );
        }
    }
}