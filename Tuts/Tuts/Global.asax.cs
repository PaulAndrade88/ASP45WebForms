using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using Tuts.Models;
using Tuts.Logic;

namespace Tuts
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Initialize the product database.
            Database.SetInitializer(new ProductDatabaseInitializer());

            // Create the custom role and user.
            RoleActions roleActions = new RoleActions();
            roleActions.AddUserAndRole();

            // Add Routes.
            RouteActions routeActions = new RouteActions();
            routeActions.RegisterCustomRoutes(RouteTable.Routes);
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs.

            //Get last error from the server
            Exception ex = Server.GetLastError();

            if (ex is HttpUnhandledException)
            {
                if(ex.InnerException != null)
                {
                    ex = new Exception(ex.InnerException.Message);
                    Server.Transfer("ErrorPage.aspx?handler=Application_Error20-%20Global.asax",
                    true);
                }
            }
        }
    }
}