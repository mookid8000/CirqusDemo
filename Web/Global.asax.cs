using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Web.Helpers;

namespace Web
{
    public class WebApiApplication : HttpApplication
    {
        static IWindsorContainer _container;

        protected void Application_Start()
        {
            _container = new WindsorContainer().Install(FromAssembly.This());

            GlobalConfiguration.Configure(WebApiConfig.Register);

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(_container));
        }

        protected void Application_End()
        {
            _container.Dispose();
        }
    }
}
