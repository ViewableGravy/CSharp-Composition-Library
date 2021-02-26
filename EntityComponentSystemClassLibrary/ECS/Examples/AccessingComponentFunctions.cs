using System;
using System.Reflection;

namespace EntityComponentSystemClassLibrary.ECS.Examples
{
    public class AccessingComponentFunctions
    {
        public void Main() {
            //note: by using this method of adding assemblies, if an IComponent is a sub-class of the current, retrieving will fail
            var componentFactory = new ComponentFactory(Assembly.GetExecutingAssembly());
            var testEntity = new Entity(componentFactory);

            //Since TestComponent3 has parameters, pass them as the second parameter
            testEntity.AddComponent<TestComponent3>("This is a custom message from component 3");

            //check to make sure that Component exists in testEntity
            if (testEntity.ContainsComponent<TestComponent3>())
            {
                //Call the components function by retrieving it from the entity using GetComponent
                var testThreeResponse = testEntity.GetComponent<TestComponent3>().GetResponse();
                Console.WriteLine(testThreeResponse);
            }
        }
    }

    public class TestComponent3 : IComponent
    {
        private string Response;

        public TestComponent3(string _response)
        {
            Response = _response;
        }

        public string GetResponse()
        {
            return Response;
        }
    }
}
