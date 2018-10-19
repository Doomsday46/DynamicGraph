using DynamicGraphic.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGraphic.Models
{
    public interface IRepository
    {
        bool addMeasurements(Measurement measurement);

        bool addAllMeasurements(IEnumerable<Measurement> measurements);
        IEnumerable<Measurement> GetMeasurements(); 
    }
}
