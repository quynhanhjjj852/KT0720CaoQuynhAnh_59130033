using System.Web;
using System.Web.Mvc;

namespace KT0720CaoQuynhAnh_59130033
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
