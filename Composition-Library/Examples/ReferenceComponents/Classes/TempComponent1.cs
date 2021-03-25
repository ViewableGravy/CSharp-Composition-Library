using System;
using CompositionLibrary;

namespace Examples.ReferenceComponents.Classes
{
    public class TempComponent : RelationalComponent
    {
        public TempComponent(Entity containingEntity) : base(containingEntity)
        {
            AddDependency<TempComponent2>(containingEntity);
        }
    }
}
