using DynamicGraphic.App_Data;
using DynamicGraphic.Mappers;
using DynamicGraphic.Models;
using DynamicGraphic.Models.Generators;
using DynamicGraphic.Models.Generators.Implements;
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
        [Inject]
        public IRepository Repository { get; set; }

        public IAddMeasurementRecords addMeasurementRecords;

        [Inject]
        public IMapper ModelMapper { get; set; }
        public ActionResult Index()
        {

            return View();
        }

        private void RandomGenerateRecords()
        {
            Random random = new Random();
            int size_measurements = random.Next(1, 15),
                size_string = random.Next(4, 6);
            ICollection<Measurement> measurements = GetMeasurements(size_measurements);
            addMeasurementRecords = new RandomAddMeasurementRecords(measurements, new RandomString(random, size_string));
            Repository.addAllMeasurements(addMeasurementRecords.getRecords());
        }
        private void GenerateRecords()
        {
            Random random = new Random();
            List<string> list_names_parameters = new List<string>();
            for (var i = 1; i < 12; i++)
                list_names_parameters.Add("Param" + i);
            ICollection<Measurement> measurements = GetMeasurements(random.Next(1, 15));
            addMeasurementRecords = new RandomAddMeasurementRecords(measurements, new RandomByTheList(random, list_names_parameters));
            Repository.addAllMeasurements(addMeasurementRecords.getRecords());
        }
        public  ActionResult GenerateRecordsAsync() {
            int startTimeSpan = 5000,
                periodTimeSpan = 20000;
            var timer = new Timer(async (e) =>
            {
                await Task.Run(() => GenerateRecords());
            }, null, startTimeSpan, periodTimeSpan);

            return View("Index");
        }

        private ICollection<Measurement> GetMeasurements(int size) {
            ICollection<Measurement> measurements = new List<Measurement>();
            for (int i = 0; i < size; i++) {
                measurements.Add(new MeasurementFactory().GetMeasurement());
            }
            return measurements;
        }

        public ActionResult GetData()
        {
            IEnumerable<Measurement> measurements = Repository.GetMeasurements();
            ViewBag.Data = measurements;
            return View("DBView");
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