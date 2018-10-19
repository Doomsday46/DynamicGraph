using DynamicGraphic.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicGraphic.Models
{
    public class MeasurementFactory
    {
        public Measurement GetMeasurement() {
            return new Measurement();
        }
    }
}