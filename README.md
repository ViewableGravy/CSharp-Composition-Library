# EntityComponentSystem
A library for my interpretation/implementation of an ECS sort of system

# Preface:
This is not a proper implementation of ECS, It is my spin on the concept of Composition rather than Inheritance. Currently the implementation is primitive but my focus is primarily in performance and useability.

# Introduction 
This library is primarily focused around the use of Types (Generics) to create and interact with components. My main focus was to make sure that there was no use of strings and therefore a constraint on what the consuming application could do wrong. 

# Explanation
There are three main components to this implementation
1. ComponentFactory
2. Entity
3. IComponent

## ComponentFactory: 
  A Factory for creating new Components. It can either take a list of IComponents or an Assembly. Atleast one of these should be created in order to add IComponents to an Entity
  
## Entity
  The Entity class is the base class for entities within an application. It contains the logic for storing, retrieving and utilising IComponents. The constructor Injects a/the ComponentFactory and uses it to create new internal components. Using it's method, you can query the Entity for a particular component, to either Add, Remove or Retrieve the component
  
## IComponent
  This is the primary interface for components to implement within an application. It allows a class to be used within the ECS system as a Component and added to Entities. 
  
#ToDo
  Add constructor parameter for IComponent that stores a reference for it's parent (This is always going to be useful and is worth the slight overhead for the times when it is not needed)
  Handle default parameters from constructors for IComponents in the Factory (It currently fails epicly if you try to leave the default parameter blank (which becomes null and breaks))
  Work on Event handlers
  
  Note: Having a component that allows the interaction between the entity and another component has seemed fruitful, look into this further
