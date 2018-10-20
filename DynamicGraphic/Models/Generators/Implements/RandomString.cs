using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DynamicGraphic.Models.Generators.Implements
{
    public class RandomString : IString
    {
        private Random random;
        private const int BASE_SIZE_STRING = 6;
        private int size_string;
        public RandomString(Random random,int size) {
            this.random = random ?? throw new ArgumentNullException();
            if (size > 0) this.size_string = size;
            else this.size_string = BASE_SIZE_STRING;
        }
        public string getString()
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size_string; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString().TrimEnd();
        }
    }
}