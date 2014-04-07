using System;

namespace Common.Serialization
{
    /// <summary>
    /// 标记字段或属性以自定义 JSON 序列化。
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed partial class JsonAttribute : Attribute
    {
        private Type converter;

        /// <summary>
        /// 创建一个 JsonAttribute 的实例。
        /// </summary>
        public JsonAttribute()
            : this(null, null)
        {
        }

        /// <summary>
        /// 创建一个 JsonAttribute 的实例。
        /// </summary>
        /// <param name="name">指定该字段或属性在序列化和反序列化时映射的名字。</param>
        public JsonAttribute(string name)
            : this(name, null)
        {
        }

        /// <summary>
        /// 创建一个 JsonAttribute 的实例。
        /// </summary>
        /// <param name="converter">指定该字段或属性在序列化和反序列化时使用的自定义转换器的类型。</param>
        public JsonAttribute(Type converter)
            : this(null, converter)
        {
        }

        /// <summary>
        /// 创建一个 JsonAttribute 的实例。
        /// </summary>
        /// <param name="name">指定该字段或属性在序列化和反序列化时映射的名字。</param>
        /// <param name="converter">指定该字段或属性在序列化和反序列化时使用的自定义转换器的类型。</param>
        public JsonAttribute(string name, Type converter)
        {
            Name = name;
            Converter = converter;
            CollectionCountGreaterThan = -1;
            CollectionCountLessThan = -1;
        }

        /// <summary>
        /// 约束在序列化时字符串或数组或集合的元素个数必须大于指定值。小于零为不约束。默认为 -1。
        /// </summary>
        public int CollectionCountGreaterThan
        {
            get;
            set;
        }

        /// <summary>
        /// 约束在序列化时字符串或数组或集合的元素个数必须小于指定值。小于零为不约束。默认为 -1。
        /// </summary>
        public int CollectionCountLessThan
        {
            get;
            set;
        }

        /// <summary>
        /// 使用自定义的序列化转换。
        /// </summary>
        public Type Converter
        {
            get
            {
                return converter;
            }
            set
            {
                if (converter == null || typeof(JsonConverter).IsSubclassOf(value) == true)
                {
                    converter = value;
                }
                else
                {
                    throw new ArgumentException("Converter 必须为 JsonConverter 类的子类。");
                }
            }
        }

        /// <summary>
        /// 是否在序列化时忽略标记的字段或属性。默认 false。
        /// </summary>
        public bool Ignore
        {
            get;
            set;
        }

        /// <summary>
        /// 若标记的字段或属性为 null 时，是否在序列化时忽略。默认 false。
        /// </summary>
        public bool IgnoreNull
        {
            get;
            set;
        }

        /// <summary>
        /// 指定在序列化和反序列化时映射的名字。
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// 是否序列化与反序列化非公有字段或属性。默认 false。
        /// </summary>
        public bool ProcessNonPublic
        {
            get;
            set;
        }
    }
}
