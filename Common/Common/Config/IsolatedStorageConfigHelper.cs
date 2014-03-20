using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Config
{
    /// <summary>
    /// 独立存储设置帮助类。
    /// </summary>
    public static partial class IsolatedStorageConfigHelper
    {
        private const string ISOLATEDSTORAGESETTINGNAME = "appsetting.bin";

        /// <summary>
        /// 获取指定键的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <returns>键的值。</returns>
        public static object Get(string key)
        {
            using (IsolatedStorageFile file = IsolatedStorageFile.GetMachineStoreForDomain())
            {
                if (file.FileExists(ISOLATEDSTORAGESETTINGNAME) == false)
                {
                    using (IsolatedStorageFileStream fs = file.CreateFile(ISOLATEDSTORAGESETTINGNAME))
                    {
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, dict);
                    }
                }

                using (IsolatedStorageFileStream fs = file.OpenFile(ISOLATEDSTORAGESETTINGNAME, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Dictionary<string, object> dict = (Dictionary<string, object>)bf.Deserialize(fs);
                    if (dict.ContainsKey(key))
                    {
                        return dict[key];
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// 获取指定键的值。
        /// </summary>
        /// <typeparam name="T">键的类型。</typeparam>
        /// <param name="key">键。</param>
        /// <returns>键的值。</returns>
        public static T Get<T>(string key)
        {
            var temp = Get(key);
            if (temp == null)
            {
                return default(T);
            }
            else
            {
                return (T)temp;
            }
        }

        /// <summary>
        /// 设置指定键的值。
        /// </summary>
        /// <param name="key">键。</param>
        /// <param name="value">值。</param>
        public static void Set(string key, object value)
        {
            using (IsolatedStorageFile file = IsolatedStorageFile.GetMachineStoreForDomain())
            {
                if (file.FileExists(ISOLATEDSTORAGESETTINGNAME) == false)
                {
                    using (IsolatedStorageFileStream fs = file.CreateFile(ISOLATEDSTORAGESETTINGNAME))
                    {
                        Dictionary<string, object> dict = new Dictionary<string, object>();
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, dict);
                    }
                }

                using (IsolatedStorageFileStream fs = file.OpenFile(ISOLATEDSTORAGESETTINGNAME, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    Dictionary<string, object> dict = (Dictionary<string, object>)bf.Deserialize(fs);
                    if (dict.ContainsKey(key))
                    {
                        dict[key] = value;
                    }
                    else
                    {
                        dict.Add(key, value);
                    }
                    fs.SetLength(0);
                    bf.Serialize(fs,dict);
                }
            }
        }
    }
}
