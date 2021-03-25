using System;

namespace CompositionLibrary
{
    /// <summary>
    /// Specifies to the ComponentFactory not to include this component
    /// </summary>
    public class ExcludeAttribute : Attribute
    {
    }

    /// <summary>
    /// Specifies that the required dependencies for a RelationalComponent will be manually added to the entity
    /// </summary>
    public class ManuallyAddDependencies : Attribute
    {
    }
}
