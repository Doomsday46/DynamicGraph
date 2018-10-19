using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGraphic.Models.Generators
{
    public interface IString
    {
        String getString(int size);

        String getString();
    }
}
