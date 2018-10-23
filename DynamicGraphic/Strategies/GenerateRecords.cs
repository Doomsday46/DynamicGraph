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
            list_names_parameters.Add("Param" + 1);
            ICollection<Measurement> measurements = GetMeasurements(1);
            addMeasurementRecords = new RandomAddMeasurementRecords(measurements, new RandomByTheList(random, list_names_parameters));
            Repository.addAllMeasurements(addMeasurementRecords.getRecords());
        }
        public override AlgorithmEnum GetTyperAlgoritm()
        {
            return AlgorithmEnum.GenerateRecords;
        }
    }
}