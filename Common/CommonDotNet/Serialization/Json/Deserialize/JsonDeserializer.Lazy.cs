using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private object DeserializeToLazy(string input, Type type)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (var temp in JsonHelper.ItemReader(input))
            {
                string key;
                string value;
                JsonHelper.ItemSpliter(temp, out key, out value);
                dictionary.Add(key, value);
            }

            if (dictionary["IsValueCreated"] == "true")
            {
                Type elementType = type.GetGenericArguments()[0];

                object element = DeserializeToObject(dictionary["Value"], elementType);
                object lazyInstance = Activator.CreateInstance(type, new object[] { Expression.Lambda(Expression.Constant(element, elementType)).Compile() });

                PropertyInfo valueProperty = type.GetProperty("Value");
                valueProperty.GetValue(lazyInstance, null);

                return lazyInstance;
            }
            else
            {
                return Activator.CreateInstance(type);
            }
        }
    }
}
