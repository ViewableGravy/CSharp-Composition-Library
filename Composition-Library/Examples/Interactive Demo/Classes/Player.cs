using CompositionLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Interactive_Demo
{
    public class Player : Entity
    {
        public Player(ComponentFactory componentFactory) : base(componentFactory)
        {
            AddComponents(new ComponentParameterList<IComponent>()
            {
                new ComponentParameters<Name>("ViewableGravy"),
                new ComponentParameters<Hunger>(this),
                new ComponentParameters<Eats>(this)
            });
        }
    }
}
