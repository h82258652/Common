using System;
using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static object DeserializeToObject(string input, Type type)
        {
            input = input.Trim();
            #region null
            if (input == "null")
            {
                return null;
            }
            #endregion
            #region Boolean
            else if (type == typeof(bool))
            {
                return DeserializeToBoolean(input, type);
            }
            #endregion
            #region Byte
            else if (type == typeof(byte))
            {
                return DeserializeToByte(input, type);
            }
            #endregion
            #region Char
            else if (type == typeof(char))
            {
                return DeserializeToChar(input, type);
            }
            #endregion
            #region Decimal
            else if (type == typeof(decimal))
            {
                return DeserializeToDecimal(input, type);
            }
            #endregion
            #region Double
            else if (type == typeof(double))
            {
                return DeserializeToDouble(input, type);
            }
            #endregion
            #region Int16
            else if (type == typeof(short))
            {
                return DeserializeToInt16(input, type);
            }
            #endregion
            #region Int32
            else if (type == typeof(int))
            {
                return DeserializeToInt32(input, type);
            }
            #endregion
            #region Int64
            else if (type == typeof(long))
            {
                return DeserializeToInt64(input, type);
            }
            #endregion
            #region SByte
            else if (type == typeof(sbyte))
            {
                return DeserializeToSByte(input, type);
            }
            #endregion
            #region Single
            else if (type == typeof(float))
            {
                return DeserializeToSingle(input, type);
            }
            #endregion
            #region String
            else if (type == typeof(string))
            {
                return DeserializeToString(input, type);
            }
            #endregion
            #region UInt16
            else if (type == typeof(ushort))
            {
                return DeserializeToUInt16(input, type);
            }
            #endregion
            #region UInt32
            else if (type == typeof(uint))
            {
                return DeserializeToUInt32(input, type);
            }
            #endregion
            #region UInt64
            else if (type == typeof(ulong))
            {
                return DeserializeToUInt64(input, type);
            }
            #endregion
            #region Array
            else if (type.IsArray == true)
            {
                return DeserializeToArray(input, type);
            }
            #endregion
            #region BigInteger
            else if (type == typeof(BigInteger))
            {
                return DeserializeToBigInteger(input, type);
            }
            #endregion
            #region DateTime
            else if (type == typeof(DateTime))
            {
                return DeserializeToDateTime(input, type);
            }
            #endregion
            #region Dictionary
            else if (typeof(IDictionary).IsAssignableFrom(type) == true)
            {
                return DeserializeToDictionary(input, type);
            }
            #endregion
            #region Enum
            else if (type.IsEnum == true)
            {
                return DeserializeToEnum(input, type);
            }
            #endregion
            #region List
            else if (typeof(IList).IsAssignableFrom(type) == true)
            {
                return DeserializeToList(input, type);
            }
            #endregion
            #region Regex
            else if (type == typeof(Regex))
            {
                return DeserializeToRegex(input, type);
            }
            #endregion
            #region Uri
            else if (type == typeof(Uri))
            {
                return DeserializeToUri(input, type);
            }
            #endregion
            #region Class
            else
            {
                return DeserializeToClass(input, type);
            }
            #endregion
        }
    }
}
