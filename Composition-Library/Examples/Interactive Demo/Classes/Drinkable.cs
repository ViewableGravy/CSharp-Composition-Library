using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositionLibrary;

namespace Examples.Interactive_Demo
{
    public class Drinkable : Component
    {
        public Drinkable(Entity _owningEntity) : base(_owningEntity)
        {
            if (!_owningEntity.ContainsComponent<Name>())
                throw new Exception("Cannot Be drinkable if it doesn't have a name");
        }

        public string GetResponse()
        {
            return $"You take a drink from the {OwningEntity.GetComponent<Name>().GetName} and feel refreshed";
        }
    }
}
