
namespace Common.Serialization.Json
{
    internal partial class JsonSerializer
    {
        private int _currentStackLevel;

        internal DateTimeFormat DateTimeFormat
        {
            get;
            set;
        }

        internal EnumFormat EnumFormat
        {
            get;
            set;
        }

        internal RegexFormat RegexFormat
        {
            get;
            set;
        }

        internal int MaxStackLevel
        {
            get;
            set;
        }

        internal int CurrentStackLevel
        {
            get
            {
                return this._currentStackLevel;
            }
            set
            {
                this._currentStackLevel = value;
                if (this._currentStackLevel > this.MaxStackLevel)
                {
                    throw new JsonStackOverFlowException(this.CurrentStackLevel,this.MaxStackLevel);
                }
            }
        }

        internal JsonSerializer()
        {
        }
    }
}
