using System;

namespace Common.Serialization.Json
{
    /// <summary>
    /// ����ֶλ��������Զ��� JSON ���л���
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public sealed class JsonAttribute : Attribute
    {
        private Type _converter;

        /// <summary>
        /// ����һ�� JsonAttribute ��ʵ����
        /// </summary>
        public JsonAttribute()
            : this(null, null)
        {
        }

        /// <summary>
        /// ����һ�� JsonAttribute ��ʵ����
        /// </summary>
        /// <param name="name">ָ�����ֶλ����������л��ͷ����л�ʱӳ������֡�</param>
        public JsonAttribute(string name)
            : this(name, null)
        {
        }

        /// <summary>
        /// ����һ�� JsonAttribute ��ʵ����
        /// </summary>
        /// <param name="converter">ָ�����ֶλ����������л��ͷ����л�ʱʹ�õ��Զ���ת���������͡�</param>
        public JsonAttribute(Type converter)
            : this(null, converter)
        {
        }

        /// <summary>
        /// ����һ�� JsonAttribute ��ʵ����
        /// </summary>
        /// <param name="name">ָ�����ֶλ����������л��ͷ����л�ʱӳ������֡�</param>
        /// <param name="converter">ָ�����ֶλ����������л��ͷ����л�ʱʹ�õ��Զ���ת���������͡�</param>
        public JsonAttribute(string name, Type converter)
        {
            this.Name = name;
            this.Converter = converter;
            this.CountGreaterThan = -1;
            this.CountLessThan = -1;
        }

        /// <summary>
        /// Լ�������л�ʱ�ַ���������򼯺ϵ�Ԫ�ظ����������ָ��ֵ��С����Ϊ��Լ����Ĭ��Ϊ -1��
        /// </summary>
        public int CountGreaterThan
        {
            get;
            set;
        }

        /// <summary>
        /// Լ�������л�ʱ�ַ���������򼯺ϵ�Ԫ�ظ�������С��ָ��ֵ��С����Ϊ��Լ����Ĭ��Ϊ -1��
        /// </summary>
        public int CountLessThan
        {
            get;
            set;
        }

        /// <summary>
        /// ʹ���Զ�������л�ת����
        /// </summary>
        public Type Converter
        {
            get
            {
                return _converter;
            }
            set
            {
                if (value == null || value.IsSubclassOf(typeof(JsonConverter)) == true)
                {
                    _converter = value;
                }
                else
                {
                    throw new ArgumentException("Converter ����Ϊ JsonConverter ������ࡣ");
                }
            }
        }

        /// <summary>
        /// �Ƿ������л�ʱ���Ա�ǵ��ֶλ����ԡ�Ĭ�� false��
        /// </summary>
        public bool Ignore
        {
            get;
            set;
        }

        /// <summary>
        /// ����ǵ��ֶλ�����Ϊ null ʱ���Ƿ������л�ʱ���ԡ�Ĭ�� false��
        /// </summary>
        public bool IgnoreNull
        {
            get;
            set;
        }

        /// <summary>
        /// ָ�������л��ͷ����л�ʱӳ������֡�
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// �Ƿ����л��뷴���л��ǹ����ֶλ����ԡ�Ĭ�� false��
        /// </summary>
        public bool ProcessNonPublic
        {
            get;
            set;
        }
        
        /// <summary>
        /// �����л�ʱ����ǰ�ֶλ�����Ϊ null�����׳��쳣��Ĭ�� false�������ȶȵ��� Ignore �� IgnoreNull ���ԣ���
        /// </summary>
        public bool Required
        {
            get;
            set;
        }
    }
}
