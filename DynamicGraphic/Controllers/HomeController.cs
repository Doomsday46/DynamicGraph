using DynamicGraphic.App_Data;
using DynamicGraphic.Mappers;
using DynamicGraphic.Models;
using DynamicGraphic.Models.Generators;
using DynamicGraphic.Models.Generators.Implements;
using DynamicGraphic.Strategies;
using DynamicGraphic.Strategies.Enum;
using Ninject;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DynamicGraphic.Controllers
{
    public class HomeController : Controller
    {

        public IRepository Repository { get; set; }

        [Inject]
        public IMapper ModelMapper { get; set; }

        private ExecuterStrategies executerStratigies;
        [Inject]
        public HomeController(IRepository Repository) {
            this.Repository = Repository;
            executerStratigies = new ExecuterStrategies(new List<IStrategy>() { new GenerateRecords(Repository), new RandomGenerateRecords(Repository) });
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public  ActionResult GenerateRecordsAsync() {
            int startTimeSpan = 5000,
                periodTimeSpan = 10000;
            var timer = new Timer(async (e) =>
            {
                Console.WriteLine("--------Срабатывает таймер ------------------------------------------------------------------------");
                await Task.Run(() => executerStratigies.ExecuteStrategy(AlgorithmEnum.GenerateRecords));
            }, null, startTimeSpan, periodTimeSpan);

            return View("Index");
        }

        public ActionResult GetData()
        {
            IEnumerable<Measurement> measurements = Repository.GetMeasurements();
            ViewBag.Data = measurements;
            return View("GraphView");
        }

        public JsonResult GetDataJSON()
        {
            
            var records = Repository.GetMeasurements();
            var jsonData = new List<object>();
            foreach (var record in records) {
                jsonData.Add(ModelMapper.Map(record, typeof(Measurement), typeof(MeasurementView)));
            }
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}