using System.Collections.Generic;
using System.Linq;
using System;

namespace CompositionLibrary
{
    public abstract class Component : IComponent
    {
        private Entity owningEntity;
        public Component(Entity _owningEntity)
        {
            owningEntity = _owningEntity;
        }

        protected Entity OwningEntity { get => owningEntity; }
    }
}
