using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicGraphic.Model
{
    interface IGeneratorAddEntries
    {
        IEnumerable<Measurement> getEntries();
    }
}
