using System.Web.Mvc;
using System.Web.Routing;

namespace SMT_Reflow_Profile_Comparison_System.App_Start
{
    public class RouteConfig
    {
        public static void Configure(RouteCollection routes)
        {
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Report", id = UrlParameter.Optional }
            );
        }
    }
}