using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Web.Installers
{
    public class WebApiControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Classes.FromThisAssembly()
                    .BasedOn<ApiController>()
                    .WithServiceSelf()
                    .LifestyleTransient()
                );
        }
    }
}