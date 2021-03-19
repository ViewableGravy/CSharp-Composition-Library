using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositionLibrary;

namespace Examples.Interactive_Demo
{
    public class Name : IComponent
    {
        private string name;

        public string GetName { get => name; set => name = value; }

        public Name(string _name)
        {
            GetName = _name;
        }
    }
}
