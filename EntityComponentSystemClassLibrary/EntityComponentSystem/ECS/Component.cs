using System;

namespace EntityComponentSystemClassLibrary.ECS
{
    public abstract class Component : IComponent
    {
        protected Entity owningEntity;
        public Component(Entity _owningEntity)
        {
            owningEntity = _owningEntity;
        }
    }
}
