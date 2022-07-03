using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Owin;
using Microsoft.Owin;
using System.Data.SqlClient;
using System.Configuration;

[assembly: OwinStartup(typeof(PMS.MvcApplication))]
namespace PMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
       
      //   bool value=   SqlDependency.Start(ConfigurationManager.ConnectionStrings["PMS"].ConnectionString);
        //    int a;
        }
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
        protected void Application_End()
        {
          //  SqlDependency.Stop(ConfigurationManager.ConnectionStrings["PMS"].ConnectionString);
        }



    }
}
