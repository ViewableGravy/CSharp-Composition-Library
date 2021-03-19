namespace CompositionLibrary
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
