using DynamicGraphic.App_Data;
using DynamicGraphic.Models;
using DynamicGraphic.Models.Generators;
using DynamicGraphic.Strategies.Enum;
using Ninject;
using System.Collections.Generic;


namespace DynamicGraphic.Strategies
{
    public abstract class IStrategy
    {
        protected IRepository Repository { get; }

        protected IAddMeasurementRecords addMeasurementRecords;

        public IStrategy(IRepository repository) {
            Repository = repository;
        }

        public abstract void ExecuteAlgorithm();

        public abstract AlgorithmEnum GetTyperAlgoritm();

        protected ICollection<Measurement> GetMeasurements(int size)
        {
            ICollection<Measurement> measurements = new List<Measurement>();
            for (int i = 0; i < size; i++)
            {
                measurements.Add(new Measurement());
            }
            return measurements;
        }
    }
    
}
