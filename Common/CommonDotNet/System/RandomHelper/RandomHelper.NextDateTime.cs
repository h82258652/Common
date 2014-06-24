
namespace System
{
    public static partial class RandomHelper
    {
        public static DateTime NextDateTime()
        {
            // TODO add comment
            return NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        public static DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            // TODO add comment
            return new DateTime(NextLong(minValue.Ticks, maxValue.Ticks));
        }
    }
}
