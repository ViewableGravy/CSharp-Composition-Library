using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EntityComponentSystemClassLibrary.ECS
{
    


    public class ComponentFactory
    {
        List<Type> CreateableComponents = new List<Type>();

        /// <summary>
        /// Imports all IComponents from an assembly to the factory excluding components with the Exclude Attribute
        /// </summary>
        /// <param name="assemblies"></param>
        public ComponentFactory(params Assembly[] assemblies)
        {
            CreateableComponents.AddRange(assemblies
                .Append(Assembly.GetExecutingAssembly())
                .SelectMany(x => x.GetTypes())
                .Where(x =>
                    typeof(IComponent).IsAssignableFrom(x) &&
                    !x.IsAbstract &&
                    !x.IsInterface &&
                    x.GetCustomAttribute<ExcludeAttribute>() == null)   
            );
        }

        public ComponentFactory(params Type[] iComponents)
        {
            var notComponents = iComponents.Where(x => !typeof(IComponent).IsAssignableFrom(x));
            if (!notComponents.IsNullOrEmpty())
            {
                throw new ArgumentException($"Parameter with Type {notComponents.First().Name}, " +
                    $"did not implement the EntityComponentSystemClassLibrary.ECS.IComponent interface");
            }
                
            foreach (Type excluded in iComponents.Where(x => x.GetCustomAttribute<ExcludeAttribute>() != null))
            {
                Console.WriteLine($"WARNING: Component {excluded.Name} has Attribute \"Exclude\" and will be ignored");
            }
                
            CreateableComponents.AddRange(iComponents);
        }

        public bool ComponentExists(Type componentType)
        {
            return CreateableComponents.Any(local => local.Name == componentType.Name);
        }

        public IEnumerable<Type> GetAvailableComponents()
        {
            return (IEnumerable<Type>)CreateableComponents.ToArray().Clone();
        }

        public IComponent GetNewComponent(Type componentType, params object[] parameters)
        {
            return (IComponent) Activator.CreateInstance(
                CreateableComponents.Find(local => local.Name == componentType.Name),
                parameters);
        }
    }
}
