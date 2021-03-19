using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositionLibrary;

namespace Examples.Interactive_Demo
{
    public class Edible : Component
    {
        private int satiationAmount;
        public Edible(Entity _owningEntity, int _satiationAmount) : base(_owningEntity)
        {
            if (!_owningEntity.ContainsComponent<Name>())
                throw new Exception($"Cannot Be {GetType()} if it doesn't have a name");
            satiationAmount = _satiationAmount;
        }

        public int SatiationAmount()
        {
            return satiationAmount;
        }
    }
}
