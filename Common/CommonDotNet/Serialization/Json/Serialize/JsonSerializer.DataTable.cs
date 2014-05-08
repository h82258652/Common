using System.Collections.Generic;
using System.Data;

namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private string SerializeDataTable(DataTable table)
        {
            List<string> rowsJson = new List<string>();
            foreach (DataRow row in table.Rows)
            {
                List<string> keyValues = new List<string>();
                foreach (DataColumn column in table.Columns)
                {
                    string keyString = "\"" + column.ColumnName + "\"";
                    string valueString = SerializeObject(row[column]);
                    keyValues.Add(keyString + ":" + valueString);
                }
                rowsJson.Add("{" + string.Join(",", keyValues) + "}");
            }
            return "[" + string.Join(",", rowsJson) + "]";
        }
    }
}
