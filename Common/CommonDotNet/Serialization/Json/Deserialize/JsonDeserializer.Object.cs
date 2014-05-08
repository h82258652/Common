using System;
using System.Collections;
using System.Data;
using System.Dynamic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        internal object DeserializeToObject(string input, Type type)
        {
            this.CurrentStackLevel++;
            object obj;

            input = input.Trim();
            #region null
            if (input == "null")
            {
                obj = null;
            }
            #endregion
            #region Boolean
            else if (type == typeof(bool))
            {
                obj = DeserializeToBoolean(input, type);
            }
            #endregion
            #region Byte
            else if (type == typeof(byte))
            {
                obj = DeserializeToByte(input, type);
            }
            #endregion
            #region Char
            else if (type == typeof(char))
            {
                obj = DeserializeToChar(input, type);
            }
            #endregion
            #region Decimal
            else if (type == typeof(decimal))
            {
                obj = DeserializeToDecimal(input, type);
            }
            #endregion
            #region Double
            else if (type == typeof(double))
            {
                obj = DeserializeToDouble(input, type);
            }
            #endregion
            #region Int16
            else if (type == typeof(short))
            {
                obj = DeserializeToInt16(input, type);
            }
            #endregion
            #region Int32
            else if (type == typeof(int))
            {
                obj = DeserializeToInt32(input, type);
            }
            #endregion
            #region Int64
            else if (type == typeof(long))
            {
                obj = DeserializeToInt64(input, type);
            }
            #endregion
            #region SByte
            else if (type == typeof(sbyte))
            {
                obj = DeserializeToSByte(input, type);
            }
            #endregion
            #region Single
            else if (type == typeof(float))
            {
                obj = DeserializeToSingle(input, type);
            }
            #endregion
            #region String
            else if (type == typeof(string))
            {
                obj = DeserializeToString(input, type);
            }
            #endregion
            #region UInt16
            else if (type == typeof(ushort))
            {
                obj = DeserializeToUInt16(input, type);
            }
            #endregion
            #region UInt32
            else if (type == typeof(uint))
            {
                obj = DeserializeToUInt32(input, type);
            }
            #endregion
            #region UInt64
            else if (type == typeof(ulong))
            {
                obj = DeserializeToUInt64(input, type);
            }
            #endregion
            #region Array
            else if (type.IsArray == true)
            {
                obj = DeserializeToArray(input, type);
            }
            #endregion
            #region BigInteger
            else if (type == typeof(BigInteger))
            {
                obj = DeserializeToBigInteger(input, type);
            }
            #endregion
            #region DataTable
            else if (type == typeof(DataTable))
            {
                obj = DeserializeToDataTable(input, type);
            }
            #endregion
            #region DateTime
            else if (type == typeof(DateTime))
            {
                obj = DeserializeToDateTime(input, type);
            }
            #endregion
            #region Dictionary
            else if (typeof(IDictionary).IsAssignableFrom(type) == true)
            {
                obj = DeserializeToDictionary(input, type);
            }
            #endregion
            #region Enum
            else if (type.IsEnum == true)
            {
                obj = DeserializeToEnum(input, type);
            }
            #endregion
            #region ExpandoObject
            else if (type == typeof(ExpandoObject))
            {
                obj = DeserializeToExpandoObject(input, type);
            }
            #endregion
            #region Guid
            else if (type == typeof(Guid))
            {
                obj = DeserializeToGuid(input, type);
            }
            #endregion
            #region Lazy
            else if (type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof(Lazy<>))
            {
                obj = DeserializeToLazy(input, type);
            }
            #endregion
            #region List
            else if (typeof(IList).IsAssignableFrom(type) == true)
            {
                obj = DeserializeToList(input, type);
            }
            #endregion
            #region Nullable
            else if (type.IsGenericType == true && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                obj = DeserializeToNullable(input, type);
            }
            #endregion
            #region Regex
            else if (type == typeof(Regex))
            {
                obj = DeserializeToRegex(input, type);
            }
            #endregion
            #region Uri
            else if (type == typeof(Uri))
            {
                obj = DeserializeToUri(input, type);
            }
            #endregion
            #region Class
            else
            {
                obj = DeserializeToClass(input, type);
            }
            #endregion

            this.CurrentStackLevel--;
            return obj;
        }
    }
}
