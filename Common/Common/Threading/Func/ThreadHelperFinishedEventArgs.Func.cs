using System;

namespace Common.Threading
{
    public class ThreadHelperFinishedEventArgs<TResult> : EventArgs
    {
        public ThreadHelperFinishedEventArgs(TResult value)
        {
            this.Value = value;
        }

        public TResult Value
        {
            get;
            internal set;
        }
    }
}
