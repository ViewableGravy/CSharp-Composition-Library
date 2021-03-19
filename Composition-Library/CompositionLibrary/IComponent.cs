using System;
using System.Collections.Generic;
using System.Text;

namespace CompositionLibrary
{
    public interface IComponent
    {
        public string Name
        {
            get { return GetType().Name; }
        }
    }
}
