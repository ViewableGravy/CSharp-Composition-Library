using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositionLibrary;

namespace Examples.Interactive_Demo
{
    public class Eats : Component
    {
        public Eats(Entity _owningEntity) : base(_owningEntity) { }

        public string Eat(Entity toConsume)
        {
            var beingConsumedName = toConsume.GetComponent<Name>().GetName;
            var owningEntityName = owningEntity.GetComponent<Name>().GetName;

            if (!toConsume.ContainsComponent<Edible>())
                return $"player {owningEntityName} tries to eat {beingConsumedName} but you can't eat that!";

            if (!owningEntity.ContainsComponent<Hunger>())
                return $"player {owningEntityName} takes a massive bite from the {beingConsumedName}";

            var edible = toConsume.GetComponent<Edible>().SatiationAmount();
            var response = owningEntity
                .GetComponent<Hunger>()
                .IncreaseSatiation(edible);
            if (response.Contains("max"))
                return $"player {owningEntityName} Could not eat any more - {response}";

            return $"player {owningEntityName} takes a massive bite from the {beingConsumedName} and {response}";
        }
    }
}
