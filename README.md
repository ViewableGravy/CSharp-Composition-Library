# C# Composition Library
A Simple Library that allows the use of composition over inheritance in c#. The library focuses heavily on retrieving components from an entity using Generics but also keeping the code simple, clean and consistent

# Preface:
This is not a proper implementation of ECS but My primary focus was simplicity and ease of use which will allow consuming apps to use this however they choose

# Primary Concepts
### 1. ComponentFactory: 
  A Factory for creating new Components. It can either take a list of IComponents or an Assembly. Atleast one of these should be created in order to add IComponents to an Entity
  
### 2. Entity
  The Entity class is the base class for entities within an application. It contains the logic for storing, retrieving and utilising IComponents. The constructor Injects a/the ComponentFactory and uses it to create new internal components. Using it's method, you can query the Entity for a particular component, to either Add, Remove or Retrieve the component
  
### 3. IComponent
  This is the primary interface for components to implement within an application. It allows a class to be used within the ECS system as a Component and added to Entities. 
  
  
# Example:
Let's consider a scenario where we have a Player and a Burger. Both are Entities that have components that allow them to interact

![image](https://user-images.githubusercontent.com/42259073/109454708-ea5d2780-7aa8-11eb-9366-91dc44e97248.png)

Taking that diagram into account, creating the component factory is simple (it can also take individual components but we will just use the executing assembly for now)

```cs
  new ComponentFactory(Assembly.GetExecutingAssembly());
```

now having the factory, creating the Player entity would look as follows: (Creating the burger is similar)
```cs
  public class Player : Entity
    {
        public Player(ComponentFactory componentFactory) : base(componentFactory)
        {
            AddComponents(new ComponentParameterList<IComponent>()
            {
                new ComponentParameters<Name>("ViewableGravy"),
                new ComponentParameters<Hunger>(this),
                new ComponentParameters<Eats>(this)
            });
        }
    }
```

Creating the Eats Component would look as follows
Note that in the future it is likely that the base component interface will take the owningEntity as a parameter so this private parameter will be abstracted.
```cs
public class Eats : IComponent
    {
        private Entity owningEntity;

        public Eats(Entity _owningEntity)
        {
            owningEntity = _owningEntity;
        }

        public string Eat(Entity toConsume)
        {
            ...
        }
    }
```

Then your code for a player eating a burger can look as follows
```cs
  player.GetComponent<Eats>().Eat(burger)
```

This is a simple example that perhaps doesn't fully benefit from this library due to the initial overhead, but as your program expands, being able to add, Remove and interact with components can simplify your code so that you are not limited by the mechanisms of inheritance.

# ToDo
  Add constructor parameter for IComponent that stores a reference for it's parent (This is always going to be useful and is worth the slight overhead for the times when it is not needed)
  Handle default parameters from constructors for IComponents in the Factory (It currently fails epicly if you try to leave the default parameter blank (which becomes null and breaks))
  Work on Event handlers
  
  Note: Having a component that allows the interaction between the entity and another component has seemed fruitful, look into this further
