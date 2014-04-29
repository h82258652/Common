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
            Dictionary<string, string> dictionary = JsonHelper.ItemReader(input.Substring(1, input.Length - 2)).ToDictionary(temp => temp.Substring(0, temp.IndexOf(':')).Trim('\"'), temp => temp.Substring(temp.IndexOf(':') + 1));

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
