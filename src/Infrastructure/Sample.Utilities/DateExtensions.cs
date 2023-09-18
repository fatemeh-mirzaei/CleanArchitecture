using System.Globalization;

namespace Sample.Utilities
{
    public static class DateExtensions
    {

        public static DateTime ToMiladi(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, new PersianCalendar());
        }

        public static string ToShamsi(this DateTime value)
        {
            {
                PersianCalendar pc = new PersianCalendar();

                return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
                       pc.GetDayOfMonth(value).ToString("00");

            }
        }
    }
}
