using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DynamicGraphic.App_Data;

namespace DynamicGraphic.Models.Generators.Implements
{
    public class RandomAddMeasurementRecords : IAddMeasurementRecords
    {
        private IEnumerable<Measurement> MeasurementRecords;
        private IString generatorString;
        private const int YEAR = 2018; 

        public RandomAddMeasurementRecords(IEnumerable<Measurement> measurementRecords,IString generatorString) {
            if (measurementRecords == null || generatorString == null) throw new ArgumentNullException("Constructor RandomGeneratorAddMeasurementRecords");
            this.MeasurementRecords = measurementRecords;
            this.generatorString = generatorString;
        }

        public IEnumerable<Measurement> getRecords()
        {
            Random random = new Random();
            foreach(var record in MeasurementRecords){
                record.parameter_name = generatorString.getString().Trim();
                record.parameter_value = random.Next(0, 250);
                int month = random.Next(1, 12),
                    day = random.Next(1, 28),
                    hours = random.Next(0, 24);
                record.date_time = generateDateTime(month, day, hours);
            }
            return MeasurementRecords;
        }

        private DateTime generateDateTime(int month,int day, int hours) {
            return new DateTime(YEAR, month, day, hours, 0 , 0);
        }
        
    }
}