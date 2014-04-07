using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Config
{
    internal class IniSection : IniNode
    {
        internal List<IniNode> Nodes = new List<IniNode>();

        public string Section
        {
            get
            {
                return this.Text.Substring(1, this.Text.Length - 2);
            }
            set
            {
                this.Text = value;
            }
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (value.StartsWith("[") == false)
                {
                    value = '[' + value;
                }
                if (value.EndsWith("]") == false)
                {
                    value = value + ']';
                }
                base.Text = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(this.Text);
            sb.Append(Environment.NewLine);

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
