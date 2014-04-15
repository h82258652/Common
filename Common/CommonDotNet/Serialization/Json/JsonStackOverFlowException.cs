using System;
using System.Runtime.Serialization;

namespace Common.Serialization.Json
{
    /// <summary>
    /// JSON 序列化或反序列化时超出指定的深度时产生的异常。
    /// </summary>
    [Serializable]
    public sealed class JsonStackOverFlowException : Exception, ISerializable
    {
        /// <summary>
        /// 产生异常的深度。
        /// </summary>
        public int CurrentStackLevel
        {
            get;
            private set;
        }

        /// <summary>
        /// 允许的最大深度。
        /// </summary>
        public int MaxStackLevel
        {
            get;
            private set;
        }

        internal JsonStackOverFlowException(int currentStackLevel, int maxStackLevel)
        {
            this.CurrentStackLevel = currentStackLevel;
            this.MaxStackLevel = maxStackLevel;
        }

        /// <summary>
        /// 显示当前异常的信息。
        /// </summary>
        /// <returns>异常的信息。</returns>
        public override string ToString()
        {
            return "当前深度：" + this.CurrentStackLevel + "：最大深度：" + this.MaxStackLevel + "。";
        }
        
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
