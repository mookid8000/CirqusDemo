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
                        var database = new MongoClient()
                            .GetServer()
                            .GetDatabase("todoom");

                        return database;
                    })
                );
        }
    }
}