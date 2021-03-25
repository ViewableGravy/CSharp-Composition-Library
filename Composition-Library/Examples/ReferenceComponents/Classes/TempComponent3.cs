using System;
using CompositionLibrary;

namespace Examples.ReferenceComponents.Classes
{
    public class TempComponent3 : RelationalComponent
    {
        public TempComponent3(Entity containingEntity) : base(containingEntity)
        {
            AddDependency<TempComponent>(containingEntity);
            AddDependency<TempComponent2>(containingEntity);
        }
    }
}
