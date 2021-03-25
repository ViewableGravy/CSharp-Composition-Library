using System;
using System.Reflection;
using CompositionLibrary;
using System.Linq;
using Examples.ReferenceComponents.Classes;

namespace Examples
{
    public static class ReferenceComponent
    {
        public static void ReferenceComponentsExample()
        {
            var componentFactory = new ComponentFactory(Assembly.GetExecutingAssembly());
            Entity entity = new Entity(componentFactory);
            entity.AddComponents(new ComponentParameterList<IComponent>
            {
                new ComponentParameters<TempComponent3>(entity)
            });

            Console.WriteLine("All 3 components should be visible since Component3 has a dependency on the other two");
            entity.GetComponentNames().ToList().ForEach(x => Console.WriteLine(x));
        } 
    }
}
