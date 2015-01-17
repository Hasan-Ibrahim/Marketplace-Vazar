using Api.AccessControl.Attribtues;
using Data.Repositories.Abstraction;
using Data.TokenStorages;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Service.Account;
using Unity.WebApi;

namespace Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ITokenStorage, InMemoryTokenStorage>();
            container.RegisterType(typeof (IRepository<>), typeof (PgsqlRepository<>));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}