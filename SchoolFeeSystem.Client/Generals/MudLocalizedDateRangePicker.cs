using MudBlazor;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SchoolFeeSystem.Client.Generals
{
    public class MudLocalizedDateRangePicker : MudDateRangePicker
    {
        protected override void OnInitialized()
        {
            Culture = GetPersianCulture();
            base.OnInitialized();
        }
        public CultureInfo GetPersianCulture()
        {
            var culture = new CultureInfo("ps-AF");
            DateTimeFormatInfo formatInfo = culture.DateTimeFormat;
            formatInfo.AbbreviatedDayNames = ["ی", "د", "س", "چ", "پ", "ج", "ش"];
            formatInfo.DayNames = ["یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنجشنبه", "جمعه", "شنبه"];
            string[] monthNames = ["وری", "غویی", "غبرګلی", "چنګاښ", "زمری", "وږی", "تله", "لړم", "لیند", "مرغومی", "سلواغه", "کب", ""];
            formatInfo.AbbreviatedMonthNames =
                formatInfo.MonthNames =
                    formatInfo.MonthGenitiveNames = formatInfo.AbbreviatedMonthGenitiveNames = monthNames;
            formatInfo.AMDesignator = "AM";
            formatInfo.PMDesignator = "PM";
            formatInfo.ShortDatePattern = "yyyy/MM/dd";
            formatInfo.LongDatePattern = "dddd, dd MMMM,yyyy";
            formatInfo.FirstDayOfWeek = DayOfWeek.Saturday;
            Calendar cal = new PersianCalendar();
            FieldInfo fieldInfo = culture.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance)!;
            if (fieldInfo != null)
                fieldInfo.SetValue(culture, cal);
            FieldInfo info = formatInfo.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance)!;
            if (info != null)
                info.SetValue(formatInfo, cal);
            culture.NumberFormat.NumberDecimalSeparator = "/";
            culture.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
            culture.NumberFormat.NumberNegativePattern = 0;
            return culture;
        }
    }
}
