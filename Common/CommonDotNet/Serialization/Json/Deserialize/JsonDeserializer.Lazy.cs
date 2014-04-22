using System;
using System.Collections;
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
            if (input == "null")
            {
                return Activator.CreateInstance(type);
            }
            else
            {
                Type elementType = type.GetGenericArguments()[0];

                object element = DeserializeToObject(input, elementType);
                object lazyInstance = Activator.CreateInstance(type, new object[] { Expression.Lambda(Expression.Constant(element, elementType)).Compile() });

                PropertyInfo valueProperty = type.GetProperty("Value");
                valueProperty.GetValue(lazyInstance, null);

                return lazyInstance;
            }
        }
    }
}
