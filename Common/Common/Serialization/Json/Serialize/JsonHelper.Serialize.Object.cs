using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.Serialization
{
    public static partial class JsonHelper
    {
        internal static string SerializeObject(object obj)
        {
            #region null
            if (obj == null)
            {
                return "null";
            }
            #endregion
            #region Boolean
            else if (obj is bool)
            {
                return SerializeBoolean((bool)obj);
            }
            #endregion
            #region Byte
            else if (obj is byte)
            {
                return SerializeByte((byte)obj);
            }
            #endregion
            #region Char
            else if (obj is char)
            {
                return SerializeChar((char)obj);
            }
            #endregion
            #region Decimal
            else if (obj is decimal)
            {
                return SerializeDecimal((decimal)obj);
            }
            #endregion
            #region Double
            else if (obj is double)
            {
                return SerializeDouble((double)obj);
            }
            #endregion
            #region Int16
            else if (obj is short)
            {
                return SerializeInt16((short)obj);
            }
            #endregion
            #region Int32
            else if (obj is int)
            {
                return SerializeInt32((int)obj);
            }
            #endregion
            #region Int64
            else if (obj is long)
            {
                return SerializeInt64((long)obj);
            }
            #endregion
            #region SByte
            else if (obj is sbyte)
            {
                return SerializeSByte((sbyte)obj);
            }
            #endregion
            #region Single
            else if (obj is float)
            {
                return SerializeSingle((float)obj);
            }
            #endregion
            #region String
            else if (obj is string)
            {
                return SerializeString(obj as string);
            }
            #endregion
            #region UInt16
            else if (obj is ushort)
            {
                return SerializeUInt16((ushort)obj);
            }
            #endregion
            #region UInt32
            else if (obj is uint)
            {
                return SerializeUInt32((uint)obj);
            }
            #endregion
            #region UInt64
            else if (obj is ulong)
            {
                return SerializeUInt64((ulong)obj);
            }
            #endregion
            #region Array
            else if (obj is Array)
            {
                return SerializeArray(obj as Array);
            }
            #endregion
            #region BigInteger
            else if (obj is BigInteger)
            {
                return SerializeBigInteger((BigInteger)obj);
            }
            #endregion
            #region DateTime
            else if (obj is DateTime)
            {
                return SerializeDateTime((DateTime)obj);
            }
            #endregion
            #region Enum
            else if (obj is Enum)
            {
                return SerializeEnum(obj as Enum);
            }
            #endregion
            #region Dictionary
            else if (obj is IDictionary)
            {
                return SerializeDictionary(obj as IDictionary);
            }
            #endregion
            #region List
            else if (obj is IList)
            {
                return SerializeList(obj as IList);
            }
            #endregion
            #region Regex
            else if (obj is Regex)
            {
                return SerializeRegex(obj as Regex);
            }
            #endregion
            #region Class
            else
            {
                return SerializeClass(obj);
            }
            #endregion
        }
    }
}
