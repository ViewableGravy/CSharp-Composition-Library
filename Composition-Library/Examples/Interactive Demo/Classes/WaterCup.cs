using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositionLibrary;

namespace Examples.Interactive_Demo
{
    public class WaterCup : Entity
    {
        public WaterCup(ComponentFactory componentFactory) : base(componentFactory)
        {
            AddComponents(new ComponentParameterList<IComponent>()
            {
                new ComponentParameters<Name>("Half full water jug"),
                new ComponentParameters<Drinkable>(this)
            });
        }
    }
}
