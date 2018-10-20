using DynamicGraphic.App_Data;
using DynamicGraphic.Models;
using DynamicGraphic.Models.Generators.Implements;
using DynamicGraphic.Strategies.Enum;
using Ninject;
using System;
using System.Collections.Generic;

namespace DynamicGraphic.Strategies
{
    public class GenerateRecords : IStrategy
    {
        public GenerateRecords(IRepository repository) : base(repository)
        {
        }

        public override void ExecuteAlgorithm()
        {
            Random random = new Random();
            List<string> list_names_parameters = new List<string>();
            for (var i = 1; i < 12; i++)
                list_names_parameters.Add("Param" + i);
            ICollection<Measurement> measurements = GetMeasurements(random.Next(1, 15));
            addMeasurementRecords = new RandomAddMeasurementRecords(measurements, new RandomByTheList(random, list_names_parameters));
            Repository.addAllMeasurements(addMeasurementRecords.getRecords());
        }
        public override AlgorithmEnum GetTyperAlgoritm()
        {
            return AlgorithmEnum.GenerateRecords;
        }
    }
}