using System;
using System.Reflection;
using System.Text.RegularExpressions;
using EntityComponentSystemClassLibrary.ECS;

namespace InteractionDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var componentFactory = new ComponentFactory(Assembly.GetExecutingAssembly());

            Entity waterCup = new WaterCup(componentFactory);
            Entity burger = new Burger(componentFactory);
            Entity player = new Player(componentFactory);

            int ApplyHunger = 0;

            while (true)
            {
                Console.WriteLine("Press 1 to take a drink from the watercup, 2 to eat the burger");
                var key = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine(key switch
                {
                    ConsoleKey.D1 => waterCup.GetComponent<Drinkable>().GetResponse(),
                    ConsoleKey.D2 => player.GetComponent<Eats>().Eat(burger),
                    _ => "Silly billy, that isn't a valid option"
                });
                Console.WriteLine();

                ApplyHunger++;
                if (ApplyHunger == 3)
                {
                    Console.WriteLine(player.GetComponent<Hunger>().DecreaseSatiation(1));
                    ApplyHunger = 0;
                }

            }
        }
    }

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

    public class Name : IComponent
    {
        private string name;

        public string GetName { get => name; set => name = value; }

        public Name(string _name)
        {
            GetName = _name;
        }
    }

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

    public class Drinkable : Component
    {
        public Drinkable(Entity _owningEntity) : base(_owningEntity)
        {
            if (!_owningEntity.ContainsComponent<Name>())
                throw new Exception("Cannot Be drinkable if it doesn't have a name");
        }

        public string GetResponse()
        {
            return $"You take a drink from the {owningEntity.GetComponent<Name>().GetName} and feel refreshed";
        }
    }
}
