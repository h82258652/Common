using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Config
{
    public static partial class IsolatedStorageConfigHelper
    {
        private const string ISOLATEDSTORAGESETTINGNAME = "appsetting.bin";

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
