using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicGraphic.Models.Generators.Implements
{
    public class RandomByTheList : IString
    {
        private List<String> list_elements;
        private Random random;
        public RandomByTheList(Random random, List<String> list_elements) {
            if (random == null || list_elements == null || list_elements.Count() == 0) throw new ArgumentNullException();
            this.list_elements = list_elements;
            this.random = random;
        }
        public string getString(int size)
        {
            return "DefaultName";
        }

        public string getString()
        {
            var sizeList = list_elements.Count();
            var position = random.Next(0, sizeList);
            return list_elements[position];
        }
    }
}