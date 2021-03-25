using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompositionLibrary
{ 
    public abstract class RelationalComponent : Component
    {
        private List<ComponentParameters<IComponent>> dependencies = new List<ComponentParameters<IComponent>>();

        protected RelationalComponent(Entity _owningEntity) : base(_owningEntity)
        {

        }

        internal List<ComponentParameters<IComponent>> GetDependencies()
        {
            return dependencies;
        }

        protected void AddDependencies(ComponentParameterList<IComponent> components)
        {
            foreach (ComponentParameters<IComponent> componentPair in components)
            {
                AddDependency(componentPair.IComponentType, componentPair.parameters);
            }
        }

        protected void AddDependency<T>(params object[] parameters)
            where T : IComponent
        {
            AddDependency(typeof(T), parameters);
        }

        private void AddDependency(Type type, params object[] parameters)
        {
            if (ContainsComponent(type))
                throw new ArgumentException($"component {type.Name} already exists in Component {GetType().Name}");

            dependencies.Add(new ComponentParameters<IComponent>(type, parameters));
        }

        private bool ContainsComponent(Type componentType)
        {
            return dependencies.Any(component => component.IComponentType.Name == componentType.Name);
        }
    }
}
