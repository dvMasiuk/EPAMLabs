using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SystemSales.Application.AutoMapper;
using SystemSales.Presentation.AutoMapper;
using AutoMapper;

namespace SystemSales.Presentation
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfiguration.Configure();
            Mapper.AddProfile<ViewModelToDtoMappingProfile>();
            Mapper.AddProfile<DtoToViewModelMappingProfile>();
            Database.SetInitializer(new AppDbInitializer());
        }
    }
}
