using CompositionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Basic_Example
{
    public class StatusComponent : IComponent
    {
        public string MyStatus()
        {
            return "Yeah I am doing alright";
        }
    }
}
