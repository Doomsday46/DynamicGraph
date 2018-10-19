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
        public RandomString(Random random) {
            this.random = random;
        }
        public string getString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

        public string getString()
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < BASE_SIZE_STRING; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }
    }
}