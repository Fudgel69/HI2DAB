using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RestAPICosmos
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DocumentDBRepository<E17I4DABH33Gr4.Models.Person>.Initialize();
            DocumentDBRepository<E17I4DABH33Gr4.Models.City>.Initialize();
            DocumentDBRepository<E17I4DABH33Gr4.Models.Address>.Initialize();
        }
    }
}
