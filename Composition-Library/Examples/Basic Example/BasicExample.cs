using CompositionLibrary;
using Examples.Basic_Example;
using System;
using System.Linq;
using System.Reflection;

namespace Examples
{
    static class BasicExample
    {
        public  static void BasicExampleExample()
        {
            var componentFactory = new ComponentFactory(Assembly.GetExecutingAssembly());

            Entity TestEntity = new Entity(componentFactory);
            TestEntity.AddComponents(new ComponentParameterList<IComponent>()
            {
                new ComponentParameters<StatusComponent>(),
                new ComponentParameters<ResponseComponent>("Fuck me sideways and call me a jiggly-puff, this worked batman")
            });

            var response = TestEntity.GetComponent<StatusComponent>().MyStatus();
            Console.WriteLine(response);

            response = TestEntity.GetComponent<ResponseComponent>().GetResponse();
            Console.WriteLine(response);

            TestEntity.RemoveComponent<ResponseComponent>();
            TestEntity.AddComponent<ResponseComponent>("This is a new Component 3");

            response = TestEntity.GetComponent<ResponseComponent>().GetResponse();
            Console.WriteLine(response);


            var components = TestEntity.GetComponentNames();
            foreach (string name in components)
            {
                char character = name != components.Last() ? ',' : ' ';
                Console.Write($"[{name}]{character}");
            }
        }
    }
}
