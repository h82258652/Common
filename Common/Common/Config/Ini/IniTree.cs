using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Config
{
    class IniTree
    {
        public List<IniNode> Nodes = new List<IniNode>();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Nodes.Count; i++)
            {
                sb.Append(Nodes[i].ToString());
                if (i != Nodes.Count - 1)
                {
                    sb.Append(Environment.NewLine);
                }
            }
            return sb.ToString();
        }
    }
}
