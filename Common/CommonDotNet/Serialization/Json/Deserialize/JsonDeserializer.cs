
namespace Common.Serialization.Json
{
    internal partial class JsonDeserializer
    {
        private int _currentStackLevel;

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
                    throw new JsonStackOverFlowException(this.CurrentStackLevel, this.MaxStackLevel);
                }
            }
        }

        internal JsonDeserializer()
        {
        }
    }
}
