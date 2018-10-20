using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DynamicGraphic.App_Data;
using Ninject;

namespace DynamicGraphic.Models
{
    public class SqlRepository : IRepository
    {
        [Inject]
        public TestDBDataContext Db { get; set; }

        public bool addAllMeasurements(IEnumerable<Measurement> measurements)
        {
            if (measurements.Count() != 0) {
                Db.Measurement.InsertAllOnSubmit(measurements);
                Db.Measurement.Context.SubmitChanges();
                return true;
            }
            return false;
        }

        public bool addMeasurements(Measurement measurement)
        {
            if (measurement != null)
            {
                if (measurement.parameter_name != null || measurement.parameter_name != "" || measurement.date_time != null) {
                    Db.Measurement.InsertOnSubmit(measurement);
                    Db.Measurement.Context.SubmitChanges();
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Measurement> GetMeasurements()
        {
            var measurements = Db.Measurement;
            if (measurements.Count() !=  0) {
                return measurements;
            }
            return null;
        }
    }
}