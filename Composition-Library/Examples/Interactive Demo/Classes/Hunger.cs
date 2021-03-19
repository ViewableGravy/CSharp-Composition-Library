using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositionLibrary;

namespace Examples.Interactive_Demo
{
    public class Hunger : Component
    {
        private int hungerLevel;

        public int HungerLevel { get => hungerLevel; set => hungerLevel = value; }

        public Hunger(Entity _owningEntity) : base(_owningEntity)
        {
            if (!_owningEntity.ContainsComponent<Name>())
                throw new Exception($"Cannot Be {GetType()} if it doesn't have a name");
            hungerLevel = 5;
        }

        public string GetSatiationResponse()
        {
            return $"you have {hungerLevel} out of 10 hunger";
        }

        public string IncreaseSatiation(int amount)
        {
            if (hungerLevel > 9)
                return "Hunger is already at max";

            hungerLevel += amount;
            if (hungerLevel > 10)
                hungerLevel = 10;
            return $"player {owningEntity.GetComponent<Name>().GetName}'s Hunger level increased" +
                Environment.NewLine + GetSatiationResponse();
        }

        public string DecreaseSatiation(int amount)
        {
            if (hungerLevel < 1)
                return "Hunger is already at 0";

            hungerLevel -= amount;
            if (hungerLevel < 0)
                HungerLevel = 0;
            return $"Player {owningEntity.GetComponent<Name>().GetName}'s Hunger level decreased" +
                Environment.NewLine + GetSatiationResponse();
        }
    }
}
