using DeadProject.App_Start;
using Microsoft.Practices.Unity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity.Mvc5;

namespace DeadProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IUnityContainer unityContainer = UnityContainerHelper.InitUnityContainer();
            UnityDependencyResolver dependencyRcolver = new UnityDependencyResolver(unityContainer);
            DependencyResolver.SetResolver(dependencyRcolver);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
