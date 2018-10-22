using DynamicGraphic.App_Data;
using DynamicGraphic.Mappers;
using DynamicGraphic.Mappers.implements;
using DynamicGraphic.Models;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using System.Configuration;

namespace DynamicGraphic.App_Start
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<SqlRepository>();
            Bind<MeasurementDBDataContext>().ToMethod(c => new MeasurementDBDataContext(ConfigurationManager.ConnectionStrings["MeasurementConnectionString"].ConnectionString));
            Bind<IMapper>().To<MeasurementMapper>().InSingletonScope();
        }
    }
  
}