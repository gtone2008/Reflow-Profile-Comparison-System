using SMT_Reflow_Profile_Comparison_System.Infrastructure;

namespace SMT_Reflow_Profile_Comparison_System.App_Start
{
    public class FilterConfig
    {
        public static void Configure(System.Web.Mvc.GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
