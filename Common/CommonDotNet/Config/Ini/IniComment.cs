
namespace Common.Config
{
    internal class IniComment : IniNode
    {
        public string Comment
        {
            get
            {
                return this.Text;
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
                if (value.StartsWith(";") == false)
                {
                    value = ';' + value;
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
