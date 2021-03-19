using System;
using System.Collections;
using System.Collections.Generic;

namespace CompositionLibrary
{
    public class ComponentParameters<T>
        where T : IComponent
    {
        public Type IComponentType;
        public object[] parameters;

        /// <summary>
        /// Internal Type (passed onto ComponentFactory) will be of type T
        /// </summary>
        /// <param name="_parameters"></param>
        public ComponentParameters(params object[] _parameters)
        {
            IComponentType = typeof(T);
            parameters = _parameters;
        }

        public ComponentParameters(Type _type, params object[] _parameters)
        {
            IComponentType = _type;
            parameters = _parameters;
        }
    }

    public class ComponentParameterList<T> : IEnumerable
        where T : IComponent
    {
        private List<ComponentParameters<IComponent>> list;
        public ComponentParameterList()
        {
            list = new List<ComponentParameters<IComponent>>();
        }

        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(list);
        }

        public void Add<U>(ComponentParameters<U> incoming)
            where U : IComponent
        {
            list.Add(new ComponentParameters<IComponent>(incoming.IComponentType, incoming.parameters));
        }

        private class MyEnumerator : IEnumerator
        {
            public List<ComponentParameters<IComponent>> list;
            int position = -1;

            public MyEnumerator(List<ComponentParameters<IComponent>> _list)
            {
                list = _list;
            }
            private IEnumerator etEnumerator()
            {
                return this;
            }
            //IEnumerator
            public bool MoveNext()
            {
                position++;
                return (position < list.Count);
            }
            //IEnumerator
            public void Reset()
            {
                position = -1;
            }
            public object Current
            {
                get
                {
                    try
                    {
                        return list[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
