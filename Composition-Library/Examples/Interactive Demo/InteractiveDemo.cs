using System;
using System.Reflection;
using CompositionLibrary;
using Examples.Interactive_Demo;

namespace Examples
{
    public static class InteractiveDemo
    {
        public static void InteractiveDemoExample()
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
                Console.Clear();
                Console.WriteLine(key switch
                {
                    ConsoleKey.D1 => waterCup.GetComponent<Drinkable>().GetResponse(),
                    ConsoleKey.D2 => player.GetComponent<Eats>().Eat(burger),
                    _ => "Silly billy, that isn't a valid option"
                });
                Console.WriteLine("Press the any key to continue");
                Console.ReadKey();
                Console.Clear();

                ApplyHunger++;
                if (ApplyHunger == 3)
                {
                    Console.WriteLine(player.GetComponent<Hunger>().DecreaseSatiation(1));
                    ApplyHunger = 0;
                }
            }
        }
    }
}
