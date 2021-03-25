using System;
using CompositionLibrary;

namespace Examples.ReferenceComponents.Classes
{
    public class TempComponent2 : RelationalComponent
    {
        public TempComponent2(Entity containingEntity) : base(containingEntity)
        {
            AddDependency<TempComponent3>(containingEntity);
        }
    }
}
