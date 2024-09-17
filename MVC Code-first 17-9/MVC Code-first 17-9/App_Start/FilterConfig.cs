using System.Web;
using System.Web.Mvc;

namespace MVC_Code_first_17_9
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
