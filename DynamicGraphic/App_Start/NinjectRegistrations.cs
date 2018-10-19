using DynamicGraphic.App_Data;
using DynamicGraphic.Mappers;
using DynamicGraphic.Mappers.implements;
using DynamicGraphic.Models;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;


namespace DynamicGraphic.App_Start
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<SqlRepository>();
            Bind<TestDBDataContext>().ToMethod(c => new TestDBDataContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False"));
            Bind<IMapper>().To<MeasurementMapper>().InSingletonScope();
        }
    }
  
}