using System;
using System.Collections.Generic;

namespace OutworldMini.Core.Containers
{
    public class Container : IContainer
    {
        private Dictionary<Type, object> registeredObj;

        public Container()
        {
            registeredObj = new Dictionary<Type, object>();
        }


        public TType GetSingle<TType>()
        { 
            return (TType)registeredObj[typeof(TType)];
        }

        public void RegisterSingle<TType>(TType obj)
        {
            registeredObj.Add(typeof(TType),obj);
        }
    }
}