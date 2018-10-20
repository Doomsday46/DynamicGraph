using DynamicGraphic.App_Data;
using DynamicGraphic.Models;
using DynamicGraphic.Models.Generators.Implements;
using DynamicGraphic.Strategies.Enum;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicGraphic.Strategies
{
    public class RandomGenerateRecords : IStrategy
    {
        public RandomGenerateRecords(IRepository repository) : base(repository)
        {
        }

        public override void ExecuteAlgorithm()
        {
            Random random = new Random();
            int size_measurements = random.Next(1, 15),
                size_string = random.Next(4, 6);
            ICollection<Measurement> measurements = GetMeasurements(size_measurements);
            addMeasurementRecords = new RandomAddMeasurementRecords(measurements, new RandomString(random, size_string));
            Repository.addAllMeasurements(addMeasurementRecords.getRecords());
        }

        public override AlgorithmEnum GetTyperAlgoritm()
        {
            return AlgorithmEnum.RandomGenerateRecords;
        }
    }
}