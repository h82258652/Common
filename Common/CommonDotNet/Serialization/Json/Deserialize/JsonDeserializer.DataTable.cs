using System;
using System.Collections.Generic;
using System.Data;

namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private DataTable DeserializeToDataTable(string input, Type type)
        {
            input = input.Trim();
            if (input.StartsWith("[") == true && input.EndsWith("]") == true)
            {
                var rows = JsonHelper.ItemReader(input.Substring(1,input.Length-2));
                DataTable table = new DataTable();
                foreach (var row in rows)
                {
                    var temp = row.Trim();
                    List<object> values = new List<object>();
                    foreach (var column in JsonHelper.ItemReader(temp.Substring(1,temp.Length-2)))
                    {
                        string columnName;
                        string value;
                        JsonHelper.ItemSpliter(column, out columnName, out value);
                        columnName = (string)DeserializeToObject(columnName, typeof(string));
                        Type valueType = JsonHelper.TypeInference(value);
                        if (table.Columns.Contains(columnName) == false)
                        {
                            table.Columns.Add(columnName, valueType ?? typeof(object));
                        }
                        if (valueType == null)
                        {
                            values.Add(value);
                        }
                        else
                        {
                            values.Add(DeserializeToObject(value, valueType));
                        }
                    }
                    table.Rows.Add(values.ToArray());
                }
                return table;
            }
            else
            {
                throw new JsonDeserializeException(input, type);
            }
        }
    }
}
