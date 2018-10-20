using DynamicGraphic.Strategies.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicGraphic.Strategies
{
    public class ExecuterStrategies
    {
        private IDictionary<AlgorithmEnum, IStrategy> _strategy;

        public ExecuterStrategies()
        {
            _strategy = new Dictionary<AlgorithmEnum, IStrategy>();
        }

        public ExecuterStrategies(IStrategy strategy)
        {
            _strategy = new Dictionary<AlgorithmEnum, IStrategy>();
            _strategy.Add(strategy.GetTyperAlgoritm(), strategy);
        }

        public ExecuterStrategies(ICollection<IStrategy> strategy)
        {
            _strategy = new Dictionary<AlgorithmEnum, IStrategy>();
            foreach (var curstrategy in strategy)
            {
                _strategy.Add(curstrategy.GetTyperAlgoritm(), curstrategy);

            }
        }

        public void AddStrategy(IStrategy strategy)
        {
            _strategy.Add(strategy.GetTyperAlgoritm(), strategy);
        }

        public void AddStrategis(ICollection<IStrategy> strategy)
        {
            foreach (var curstrategy in strategy)
            {
                _strategy.Add(curstrategy.GetTyperAlgoritm(), curstrategy);

            }
        }

        public void ExecuteStrategy(AlgorithmEnum algorithmEnum)
        {
            _strategy.TryGetValue(algorithmEnum, out IStrategy strategy);
            strategy.ExecuteAlgorithm();
        }
    }
}