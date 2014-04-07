using System;
using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        internal string SerializeObject(object obj)
        {
            this.CurrentStackLevel++;
            string json;

            #region null
            if (obj == null)
            {
                json = "null";
            }
            #endregion
            #region Boolean
            else if (obj is bool)
            {
                json = SerializeBoolean((bool)obj);
            }
            #endregion
            #region Byte
            else if (obj is byte)
            {
                json = SerializeByte((byte)obj);
            }
            #endregion
            #region Char
            else if (obj is char)
            {
                json = SerializeChar((char)obj);
            }
            #endregion
            #region Decimal
            else if (obj is decimal)
            {
                json = SerializeDecimal((decimal)obj);
            }
            #endregion
            #region Double
            else if (obj is double)
            {
                json = SerializeDouble((double)obj);
            }
            #endregion
            #region Int16
            else if (obj is short)
            {
                json = SerializeInt16((short)obj);
            }
            #endregion
            #region Int32
            else if (obj is int)
            {
                json = SerializeInt32((int)obj);
            }
            #endregion
            #region Int64
            else if (obj is long)
            {
                json = SerializeInt64((long)obj);
            }
            #endregion
            #region SByte
            else if (obj is sbyte)
            {
                json = SerializeSByte((sbyte)obj);
            }
            #endregion
            #region Single
            else if (obj is float)
            {
                json = SerializeSingle((float)obj);
            }
            #endregion
            #region String
            else if (obj is string)
            {
                json = SerializeString(obj as string);
            }
            #endregion
            #region UInt16
            else if (obj is ushort)
            {
                json = SerializeUInt16((ushort)obj);
            }
            #endregion
            #region UInt32
            else if (obj is uint)
            {
                json = SerializeUInt32((uint)obj);
            }
            #endregion
            #region UInt64
            else if (obj is ulong)
            {
                json = SerializeUInt64((ulong)obj);
            }
            #endregion
            #region Array
            else if (obj is Array)
            {
                json = SerializeArray(obj as Array);
            }
            #endregion
            #region BigInteger
            else if (obj is BigInteger)
            {
                json = SerializeBigInteger((BigInteger)obj);
            }
            #endregion
            #region DateTime
            else if (obj is DateTime)
            {
                json = SerializeDateTime((DateTime)obj);
            }
            #endregion
            #region Dictionary
            else if (obj is IDictionary)
            {
                json = SerializeDictionary(obj as IDictionary);
            }
            #endregion
            #region Enum
            else if (obj is Enum)
            {
                json = SerializeEnum(obj as Enum);
            }
            #endregion
            #region Guid
            else if (obj is Guid)
            {
                json = SerializeGuid((Guid)obj);
            }
            #endregion
            #region List
            else if (obj is IList)
            {
                json = SerializeList(obj as IList);
            }
            #endregion
            #region Nullable
            else if (obj.GetType().IsGenericType == true &&
                     obj.GetType().GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                json = SerializeNullable(obj);
            }
            #endregion
            #region Regex
            else if (obj is Regex)
            {
                json = SerializeRegex(obj as Regex);
            }
            #endregion
            #region Uri
            else if (obj is Uri)
            {
                json = SerializeUri(obj as Uri);
            }
            #endregion
            #region Class
            else
            {
                json = SerializeClass(obj);
            }
            #endregion

            this.CurrentStackLevel--;
            return json;
        }
    }
}