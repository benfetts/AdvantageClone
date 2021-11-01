using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace AdvantageFramework.Core.Utilities
{
    public partial class LoGlo
    {
        public static decimal FormatDecimal(string Number)
        {
            try
            {
                string s = Number;
                //s = FormatNumber(s);
                return decimal.Parse(s);
            }
            catch (Exception ex)
            {
                return decimal.Parse(Number);
            }
        }

        //public static string FormatNumber(string Number)
        //{
        //    try
        //    {
        //        var ci = new CultureInfo(UserCultureGet());
        //        string s = Number;
        //        if (double.TryParse(s,out _) == false & IsEnglish() == false)
        //        {
        //            // Culture is set correctly, yet "Number" is not valid
        //            // most likely string being passed in is English
        //            // HACK!
        //            try
        //            {
        //                s = s.Replace(" ", "");
        //                s = s.Replace(",", "");
        //                string DecimalSeparator = ci.NumberFormat.NumberDecimalSeparator;
        //                s = s.Replace(".", DecimalSeparator);
        //            }
        //            catch (Exception ex)
        //            {
        //                return Number;
        //            }
        //        }

        //        return string.FormatNumber(s, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Number;
        //    }
        //}

        //public static string FormatDate(string Date)
        //{
        //    try
        //    {
        //        if (Date.Trim().IndexOf("&nbsp;") > -1 | string.IsNullOrEmpty(Date.Trim()) | Date.Trim() == "1/1/1900" | Date.Trim() == "01/01/1900" | Date.Trim() == "1/01/1900")
        //            return "";
        //        DateTime d = default;
        //        var CurrentCulture = default(CultureInfo);
        //        var lg = new LoGlo();
        //        d = lg.SetDate(ref CurrentCulture, Date);
        //        return string.Format(CurrentCulture, "{0:d}", d);
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}

        //public static string FormatLongDateTime(string Date)
        //{
        //    try
        //    {
        //        if (Date.Trim().IndexOf("&nbsp;") > -1 | string.IsNullOrEmpty(Date.Trim()))
        //            return "";
        //        DateTime d = default;
        //        var CurrentCulture = default(CultureInfo);
        //        var lg = new LoGlo();
        //        d = lg.SetDate(ref CurrentCulture, Date);
        //        return string.Format(CurrentCulture, "{0:D}", d);
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}

        //public static string FormatDateTime(string Date, bool IncludeTime = true)
        //{
        //    try
        //    {
        //        if (Date.Trim().IndexOf("&nbsp;") > -1 | string.IsNullOrEmpty(Date.Trim()))
        //            return "";
        //        DateTime d = default;
        //        var CurrentCulture = default(CultureInfo);
        //        var lg = new LoGlo();
        //        d = lg.SetDate(ref CurrentCulture, Date);

        //        // If ReturnLongDateTimeString = True Then
        //        // Return String.Format(CurrentCulture, "{0:D}", d)
        //        // End If
        //        if (IncludeTime == true)
        //        {
        //            return string.Format(CurrentCulture, "{0:g}", d);
        //        }
        //        else
        //        {
        //            return string.Format(CurrentCulture, "{0:d}", d);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}

        //public static string FormatMonthText(string Date)
        //{
        //    try
        //    {
        //        string CultureCode = "";
        //        CultureInfo CurrentCulture;
        //        {
        //            var withBlock = HttpContext.Current.Request;
        //            if (withBlock.Cookies("LoGloCode") is object & withBlock.Cookies("LoGloCode").Value is object)
        //            {
        //                CultureCode = withBlock.Cookies("LoGloCode").Value;
        //            }
        //            else
        //            {
        //                CultureCode = "en-US";
        //                UserCultureSet(CultureCode);
        //            }
        //        }

        //        CurrentCulture = CultureInfo.GetCultureInfo(CultureCode);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Date;
        //    }

        //    return default;
        //}

        public static DateTime FirstOfMonth()
        {
            return DateTime.Today.AddDays(-(DateTime.Today.Day - 1));
        }

        //public static DateTime FirstOfMonth(string Date)
        //{
        //    if (Information.IsDate(Date))
        //    {
        //        return Conversions.ToDate(Date).AddDays(-(Conversions.ToDate(Date).Day - 1));
        //    }

        //    return default;
        //}

        public static DateTime FirstOfMonth(int Year, int Month)
        {
            var d = new DateTime(Year, Month, 1);
            return d;
        }

        public static DateTime LastOfMonth()
        {
            return DateTime.Today.AddMonths(1).AddDays(-DateTime.Today.Day);
        }

        //public static DateTime LastOfMonth(string Date)
        //{
        //    if (Information.IsDate(Date))
        //    {
        //        if (Conversions.ToDate(Date).Day == 31)
        //        {
        //            if (Conversions.ToDate(Date).AddMonths(1).Month == 1 | Conversions.ToDate(Date).AddMonths(1).Month == 8)
        //            {
        //                return Conversions.ToDate(Date).AddMonths(1).AddDays(-Conversions.ToDate(Date).Day);
        //            }
        //            else
        //            {
        //                return Conversions.ToDate(Date).AddMonths(1).AddDays(-(Conversions.ToDate(Date).Day - 1));
        //            }
        //        }
        //        else
        //        {
        //            return Conversions.ToDate(Date).AddMonths(1).AddDays(-Conversions.ToDate(Date).Day);
        //        }
        //    }

        //    return default;
        //}

        public static DateTime FirstOfYear(int Year = 0)
        {
            if (Year == 0)
            {
                Year = DateTime.Now.Year;
            }

            var d = new DateTime(Year, 1, 1);
            return d;
        }

        public static DateTime LastOfYear(int Year = 0)
        {
            if (Year == 0)
            {
                Year = DateTime.Now.Year;
            }

            var d = new DateTime(Year, 12, 31);
            return d;
        }

        //public static DataTable LoadMonths(bool UseAbbreviations = false)
        //{
        //    var dt = new DataTable();
        //    {
        //        var withBlock = dt.Columns;
        //        withBlock.Add("code");
        //        withBlock.Add("description");
        //    }

        //    var c = GetCultureInfo();
        //    // Dim c As New System.Globalization.CultureInfo("en-US")


        //    for (int i = 1; i <= 12; i++)
        //    {
        //        DataRow r;
        //        r = dt.NewRow();
        //        r.Item("code") = i.ToString();
        //        if (UseAbbreviations == false)
        //        {
        //            r.Item("description") = DayPilot.Utils.Year.GetMonthName(i).ToString();
        //        }
        //        else
        //        {
        //            var d = new DateTime(DateTime.Now.Year, i, 1);
        //            r.Item("description") = string.Format(c, "{0:MMM}", d);
        //        }

        //        dt.Rows.Add(r);
        //    }

        //    return dt;
        //}

        //public void MvcTimesheetHeader(DateTime Date, ref string DayText, ref string DateText)
        //{
        //    TimesheetHeader(Conversions.ToString(Date), false, false, ref DayText, ref DateText);
        //}

        //public string TimesheetHeader(string Date, bool ShowOnlyAbbreviatedDay = false, bool ShowLongDate = false, [Optional, DefaultParameterValue("")] ref string DayText, [Optional, DefaultParameterValue("")] ref string DateText)
        //{
        //    try
        //    {
        //        var c = GetCultureInfo();
        //        var sb = new StringBuilder();
        //        DateTime d = Conversions.ToDate(Date);
        //        string TodayIndicator = "";
        //        if (Conversions.ToDate(Date) == DateTime.Today.Date)
        //        {
        //            TodayIndicator = "*";
        //        }

        //        if (ShowLongDate == true) // overrides ShowOnlyAbbreviatedDay
        //        {
        //            sb.Append(d.ToLongDateString());
        //            DayText = d.ToLongDateString();
        //            ShowOnlyAbbreviatedDay = true;
        //        }
        //        else
        //        {
        //            DayText = string.Format(c, "{0:ddd}", d);
        //            sb.Append(string.Format(c, "{0:ddd}", d));
        //        } // abbreviated day

        //        // .Append(TodayIndicator)

        //        if (ShowOnlyAbbreviatedDay == false)
        //        {
        //            sb.Append("<br />");

        //            // HACK!!!
        //            if (IsEnglish() == true)
        //            {
        //                sb.Append(string.Format(c, "{0:MM/dd}", d));
        //                DateText = string.Format(c, "{0:MM/dd}", d);
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    string[] ar;
        //                    var ci = new CultureInfo(UserCultureGet());
        //                    ar = string.Format(c, "{0:MM/dd}", d).Split(ci.DateTimeFormat.DateSeparator);
        //                    if (ar.Length == 2)
        //                    {
        //                        sb.Append(ar[1]);
        //                        sb.Append(c.DateTimeFormat.DateSeparator);
        //                        sb.Append(ar[0]);
        //                    }

        //                    DateText = ar[1] + c.DateTimeFormat.DateSeparator + ar[0];
        //                }
        //                catch (Exception ex)
        //                {
        //                    return Date;
        //                }
        //            }
        //        }

        //        return sb.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return Date;
        //    }
        //}

        //public DateTime SetDate(ref CultureInfo ci, string Date)
        //{
        //    try
        //    {
        //        if (Date.Trim().IndexOf("&nbsp;") > -1 | string.IsNullOrEmpty(Date.Trim()))
        //            return default;
        //        DateTime d = default;
        //        string CultureCode = "";
        //        // Dim CurrentCulture As System.Globalization.CultureInfo

        //        {
        //            var withBlock = HttpContext.Current.Request;
        //            if (withBlock.Cookies("LoGloCode") is object & withBlock.Cookies("LoGloCode").Value is object)
        //            {
        //                CultureCode = withBlock.Cookies("LoGloCode").Value;
        //            }
        //            else
        //            {
        //                CultureCode = "en-US";
        //                UserCultureSet(CultureCode);
        //            }
        //        }

        //        ci = CultureInfo.GetCultureInfo(CultureCode);
        //        if (Information.IsDate(Date) == true)
        //        {
        //            d = Conversions.ToDate(Date);
        //        }
        //        else // not a date according to culture set, most likely a string in en-US format
        //        {

        //            // hack for now....
        //            string[] ar = null;
        //            if (Date.IndexOf("/") > -1)
        //            {
        //                ar = Date.Split("/");
        //            }
        //            else if (Date.IndexOf(".") > -1)
        //            {
        //                ar = Date.Split(".");
        //            }
        //            else if (Date.IndexOf("-") > -1)
        //            {
        //                ar = Date.Split("-");
        //            }
        //            else if (Date.IndexOf(",") > -1)
        //            {
        //                ar = Date.Split(",");
        //            }

        //            if (ar.Length == 3)
        //            {
        //                d = Conversions.ToDate(ar[1] + ci.DateTimeFormat.DateSeparator + ar[0] + ci.DateTimeFormat.DateSeparator + ar[2]);
        //            }
        //        }

        //        return d;
        //    }
        //    catch (Exception ex)
        //    {
        //        return default;
        //    }
        //}

        //public static CultureInfo GetCultureInfo()
        //{
        //    try
        //    {
        //        string CultureCode = "";
        //        {
        //            var withBlock = HttpContext.Current.Request;
        //            if (withBlock.Cookies("LoGloCode") is object & withBlock.Cookies("LoGloCode").Value is object)
        //            {
        //                CultureCode = withBlock.Cookies("LoGloCode").Value;
        //            }
        //            else
        //            {
        //                CultureCode = "en-US";
        //                UserCultureSet(CultureCode);
        //            }
        //        }

        //        return CultureInfo.GetCultureInfo(CultureCode);
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return default;
        //}

        //public static bool IsEnglish()
        //{
        //    try
        //    {
        //        return UserCultureGet() == "en-US";
        //    }
        //    catch (Exception ex)
        //    {
        //        return true;
        //    }
        //}

        //public static string GetDateFormat()
        //{
        //    var info = new CultureInfo(UserCultureGet());
        //    return info.DateTimeFormat.ShortDatePattern;
        //}

        //public static string[] GetDateInputFormat()
        //{
        //    string _dateFormat = GetDateFormat();

        //    // Month first
        //    if (_dateFormat.StartsWith("M"))
        //    {
        //        return new[] { "MM-dd-yyyy", "MM-dd-yy", "MM/dd/yyyy", "MM/dd/yy", "MMddyyyy", "MMddyy" };
        //    }

        //    return new[] { "dd-MM-yyyy", "dd-MM-yy", "dd/MM/yyyy", "dd/MM/yy", "ddMMyyyy", "ddMMyy" };
        //}

        //public static void UserCultureSet(string CultureCode = "en-US")
        //{
        //    {
        //        var withBlock = HttpContext.Current.Response;
        //        withBlock.Cookies("LoGloCode").Value = CultureCode;
        //        withBlock.Cookies("LoGloCode").Expires = DateTime.Now.AddYears(1);
        //    }
        //}

        //public static string UserCultureGet()
        //{
        //    try
        //    {
        //        if (HttpContext.Current.Request.Cookies("LoGloCode") is object && string.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies("LoGloCode").Value) == false)
        //        {
        //            return HttpContext.Current.Request.Cookies("LoGloCode").Value.ToString().Trim();
        //        }
        //        else
        //        {
        //            return "en-US";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "en-US";
        //    }
        //}

        //public string UserCurrentCulture
        //{
        //    get
        //    {
        //        string UserCurrentCultureRet = default;
        //        try
        //        {
        //            {
        //                var withBlock = HttpContext.Current.Request;
        //                if (withBlock.Cookies("LoGloCode") is object & withBlock.Cookies("LoGloCode").Value is object)
        //                {
        //                    return withBlock.Cookies("LoGloCode").Value.ToString().Trim();
        //                }
        //                else
        //                {
        //                    UserCurrentCultureRet = "en-US";
        //                    return "en-US";
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return "en-US";
        //        }
        //    }

        //    set
        //    {
        //        try
        //        {
        //            {
        //                var withBlock = HttpContext.Current.Response;
        //                withBlock.Cookies("LoGloCode").Value = value;
        //                withBlock.Cookies("LoGloCode").Expires = DateTime.Now.AddYears(1);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            {
        //                var withBlock = HttpContext.Current.Response;
        //                withBlock.Cookies("LoGloCode").Value = "en-US";
        //                withBlock.Cookies("LoGloCode").Expires = DateTime.Now.AddYears(1);
        //            }
        //        }
        //    }
        //}

        //public static void GetCultureCodesForUser(ref string CultureCode, ref string UICulture)
        //{
        //    string DatabaseCultureCode = "en-US";
        //    string AgencyCultureCode = "en-US";
        //    string EmployeeCultureCode = "en-US";
        //    EmployeeCultureCode = UserCultureGet();
        //    if (HttpContext.Current.Session("DatabaseCultureCode") is null)
        //    {
        //        try
        //        {
        //            using (var DbContext = new AdvantageFramework.Core.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode")))
        //            {
        //                DatabaseCultureCode = AdvantageFramework.Core.Database.Procedures.Generic.LoadDatabaseCultureCode(DbContext);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            DatabaseCultureCode = "en-US";
        //        }

        //        HttpContext.Current.Session("DatabaseCultureCode") = DatabaseCultureCode;
        //    }
        //    else
        //    {
        //        DatabaseCultureCode = HttpContext.Current.Session("DatabaseCultureCode");
        //    }

        //    CultureCode = DatabaseCultureCode;
        //    UICulture = EmployeeCultureCode;
        //}

        //public static void PageCultureSet(Page Page)
        //{
        //    Page.Culture = UserCultureGet();
        //    Page.UICulture = UserCultureGet();
        //}

        //public static void PageCultureSetDatabaseAndUser(Page Page)
        //{
        //    GetCultureCodesForUser(ref Page.Culture, ref Page.UICulture);
        //}

        public LoGlo()
        {
        }
    }
}
