using System;
using System.Reflection;
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

            while(true)
            {
                Console.WriteLine("Press 1 to take a drink from the watercup, 2 to eat burger");
                var key = Console.ReadKey().Key;
                Console.WriteLine();
                Console.WriteLine(key switch
                {
                    ConsoleKey.D1 => waterCup.GetComponent<Drinkable>().GetResponse(),
                    ConsoleKey.D2 => burger.GetComponent<Edible>().GetResponse(),
                    _ => "Silly billy, that isn't a valid option"
                });
                Console.WriteLine();
            }
        }
    }

    public class Burger : Entity
    {
        public Burger(ComponentFactory componentfactory) : base(componentfactory)
        {
            AddComponents(new ComponentParameterList<IComponent>()
            {
                new ComponentParameters<Name>("Big Juicy Burger boi"),
                new ComponentParameters<Edible>(this)
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

    public class Edible : IComponent
    {
        private Entity owningEntity;
        public Edible(Entity _owningEntity)
        {
            if (!_owningEntity.ContainsComponent<Name>())
                throw new Exception($"Cannot Be {GetType()} if it doesn't have a name");
            owningEntity = _owningEntity;
        }

        public string GetResponse()
        {
            return $"You take a massive bite from the {owningEntity.GetComponent<Name>().GetName} and feel replenished";
        }
    }

    public class Drinkable : IComponent
    {
        private Entity owningEntity;
        public Drinkable(Entity _owningEntity)
        {
            if (!_owningEntity.ContainsComponent<Name>())
                throw new Exception("Cannot Be drinkable if it doesn't have a name");
            owningEntity = _owningEntity;
        }

        public string GetResponse()
        {
            return $"You take a drink from the {owningEntity.GetComponent<Name>().GetName} and feel refreshed";
        }
    }
}
