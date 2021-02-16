using OnionArchitectureDotNet.App_Start;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace OnionArchitectureDotNet
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container = IocContainer.ConfigureRepositories(container);
            container = IocContainer.ConfigureServices(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}