using CompositionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Interactive_Demo
{
    public class Burger : Entity
    {
        public Burger(ComponentFactory componentfactory) : base(componentfactory)
        {
            AddComponents(new ComponentParameterList<IComponent>()
            {
                new ComponentParameters<Name>("Big Juicy Burger boi"),
                new ComponentParameters<Edible>(this, 1)
            });
        }
    }
}
