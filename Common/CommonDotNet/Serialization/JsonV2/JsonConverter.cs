using System;

namespace Common.Serialization.Json
{
    /// <summary>
    /// �Զ����ֶλ����� JSON ���л��뷴���л��ĳ�����ࡣ
    /// </summary>
    public abstract class JsonConverter
    {
        /// <summary>
        /// ʵ�ִ˷������Զ��� JSON ���л���
        /// </summary>
        /// <param name="value">�ֶλ����Ե�ֵ��</param>
        /// <param name="type">�ֶλ����Ե����͡�</param>
        /// <param name="skip">�Ƿ��������ֶλ����Ե� JSON ���л���Ĭ�� false��</param>
        /// <returns> JSON �ַ�����</returns>
        public abstract string Serialize(object value, Type type, ref bool skip);

        /// <summary>
        /// ʵ�ִ˷������Զ��� JSON �����л���
        /// </summary>
        /// <param name="value"> JSON �ַ�����</param>
        /// <param name="type">�ֶλ����Ե����͡�</param>
        /// <param name="skip">�Ƿ��������ֶλ����Ե� JSON �����л���Ĭ�� false��</param>
        /// <returns>�ֶλ����Ե�ֵ��</returns>
        public abstract object Deserialize(string value, Type type, ref bool skip);
    }
}
