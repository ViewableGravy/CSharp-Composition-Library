using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositionLibrary;

namespace BenchMark
{
    public static class Code
    {
        public static void createEntities(ComponentFactory componentFactory)
        {
            for (int i = 0; i < 1000; i++)
            {
                Entity entity = new Entity(componentFactory);
                entity.AddComponents(new ComponentParameterList<IComponent>
                {
                    new ComponentParameters<TempComponent>(entity),
                    new ComponentParameters<TempComponent2>(entity)
                });
            }
        }
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
