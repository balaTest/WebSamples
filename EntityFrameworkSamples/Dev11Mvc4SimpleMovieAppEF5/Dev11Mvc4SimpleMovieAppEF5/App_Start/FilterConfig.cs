using System.Web;
using System.Web.Mvc;

namespace Dev11Mvc4SimpleMovieAppEF5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}