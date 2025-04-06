using System;
using System.Collections.Generic;

namespace InteractionSystem
{
    public class InteractionData
    {
        private readonly Dictionary<Type, object> _services = new();

        public bool TryAddService<T>(T service)
        {
            return _services.TryAdd(typeof(T), service);
        }

        public bool TryRemoveService<T>()
        {
            return _services.Remove(typeof(T));
        }

        public bool TryGetService<T>(out T service)
        {
            service = default;

            if (_services.TryGetValue(typeof(T), out object obj))
            {
                if (obj is T t)
                {
                    service = t;

                    return true;
                }
            }

            return false;
        }
    }
}