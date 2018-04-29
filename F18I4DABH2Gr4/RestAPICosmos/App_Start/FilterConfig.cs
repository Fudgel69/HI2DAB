using System.Web;
using System.Web.Mvc;

namespace E17I4DABH33Gr4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
