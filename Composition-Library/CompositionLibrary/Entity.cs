using System;
using System.Collections.Generic;
using System.Linq;

namespace CompositionLibrary
{
    public class Entity
    {

        private List<IComponent> Components = new List<IComponent>();
        private ComponentFactory componentFactory;

        public Entity(ComponentFactory _componentFactory)
        {
            componentFactory = _componentFactory;
        }

        public void AddComponent<T>(params object[] parameters)
            where T : IComponent
        {
            AddComponent(typeof(T), parameters);
        }

        public void AddComponents(ComponentParameterList<IComponent> components)
        {
            foreach (ComponentParameters<IComponent> componentPair in components)
            {
                AddComponent(componentPair.IComponentType, componentPair.parameters);
            }
        }

        public void RemoveComponent<T>()
            where T : IComponent
        {
            if (!ContainsComponent(typeof(T)))
                throw new ArgumentException($"component {typeof(T).Name} does not exists in Entity {GetType().Name}");
            Components.Remove(GetComponent(typeof(T)));
        }

        public bool ContainsComponent<T>()
            where T : IComponent
        {
            return ContainsComponent(typeof(T));
        }

        public T GetComponent<T>()
            where T : IComponent
        {
            return (T)GetComponent(typeof(T));
        }

        public IEnumerable<string> GetComponentNames()
        {
            return Components.Select(component => component.Name);
        }

        private void AddComponent(Type componentType, params object[] parameters)
        {
            if (!componentFactory.ComponentExists(componentType))
                throw new ArgumentOutOfRangeException($"Component {componentType.Name} does not exist in Factory");

            var component = componentFactory.GetNewComponent(componentType, parameters);
            if(!ContainsComponent(componentType))
                Components.Add(component);

            if (typeof(RelationalComponent).IsAssignableFrom(componentType))
            {
                ((RelationalComponent)component)
                    .GetDependencies()
                    .ForEach(dependencyParameters =>
                    {
                        if(!ContainsComponent(dependencyParameters.IComponentType))
                            AddComponent(dependencyParameters.IComponentType, dependencyParameters.parameters);
                    });
            }
        }

        private bool ContainsComponent(Type componentType)
        {
            return Components.Any(component => component.Name == componentType.Name);
        }

        private IComponent GetComponent(Type componentType)
        {
            return Components.Find(component => component.Name == componentType.Name);
        }


    }
}
