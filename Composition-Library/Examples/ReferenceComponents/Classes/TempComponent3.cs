using System;
using CompositionLibrary;

namespace Examples.ReferenceComponents.Classes
{
    public class TempComponent3 : RelationalComponent
    {
        public TempComponent3(Entity containingEntity) : base(containingEntity)
        {
            AddDependencies(new ComponentParameterList<IComponent>
            {
                new ComponentParameters<TempComponent>(containingEntity),
                new ComponentParameters<TempComponent2>(containingEntity)
            });
        }
    }
}
