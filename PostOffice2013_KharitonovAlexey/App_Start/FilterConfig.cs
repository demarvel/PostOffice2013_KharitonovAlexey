using System.Web;
using System.Web.Mvc;

namespace PostOffice2013_KharitonovAlexey
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}