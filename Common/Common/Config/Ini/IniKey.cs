using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Config
{
    internal class IniKey : IniNode
    {
        public string Key
        {
            get
            {
                return this.Text.Split('=')[0];
            }
            set
            {
                var temp = this.Text.Split('=');
                temp[0] = value;
                this.Text = string.Join("=", temp);
            }
        }

        public string Value
        {
            get
            {
                var temp = this.Text.Split('=');
                if (temp.Length != 2)
                {
                    return string.Empty;
                }
                else
                {
                    return temp[1];
                }
            }
            set
            {
                var temp = this.Text.Split('=');
                if (temp.Length != 2)
                {
                    this.Text = temp[0] + '=';
                }
                else
                {
                    this.Text = temp[0] + '=' + value;
                }
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
                if (value.Contains('=') == false)
                {
                    value = value + '=';
                }
                base.Text = value;
            }
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}