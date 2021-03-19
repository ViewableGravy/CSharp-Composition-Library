using CompositionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Basic_Example
{
    [Exclude]
    public class ExistsComponent : IComponent
    {
        public string Exists()
        {
            return "I do in fact exist";
        }
    }
}
