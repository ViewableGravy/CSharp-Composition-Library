using System;
using System.Reflection;
using CompositionLibrary;
using System.Linq;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var componentFactory = new ComponentFactory(Assembly.GetExecutingAssembly());
            Entity entity = new Entity(componentFactory);
            entity.AddComponents(new ComponentParameterList<IComponent>
            {
                new ComponentParameters<TempComponent>(entity),
                new ComponentParameters<TempComponent2>(entity)
            });

            entity.GetComponentNames().ToList().ForEach(x => Console.WriteLine(x));
        }

        public class TempComponent2 : RelationalComponent
        {
            public TempComponent2(Entity containingEntity) : base(containingEntity)
            {
                AddDependency<TempComponent3>(containingEntity);
            }
        }

        public class TempComponent3 : RelationalComponent
        {
            public TempComponent3(Entity containingEntity) : base(containingEntity)
            {
                AddDependency<TempComponent>(containingEntity);
                AddDependency<TempComponent2>(containingEntity);
            }
        }

        public class TempComponent : RelationalComponent
        {
            public TempComponent(Entity containingEntity) : base(containingEntity)
            {
                AddDependency<TempComponent2>(containingEntity);
            }
        }
    }
}
