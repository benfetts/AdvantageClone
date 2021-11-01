using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


namespace AdvantageFramework.Core.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualBasic;

    [Serializable()]
    public class MiscFN
    {
        public const string ShowErrorSessionKey = "ii8j47EohQAB5ZFYGE3cdqy";

        public enum DisplayMedium
        {
            web = 0,
            javascript = 1
        }

        public enum Browser_Types
        {
            IE = 0,
            Safari = 1,
            Firefox = 2,
            Chrome = 3,
            Opera = 4
        }

        // pass the int using "f" for the querysting variable
        public enum Source_App
        {
            Alert = 0,
            JobJacket = 1,
            JobJacketAlerts = 2,
            ProjectSchedule = 3,
            ProjectScheduleTask = 4,
            Campaign = 5,
            Estimate = 6 // multiple components (ALERT TYPE: ES)
    ,
            Desktop = 7,
            PurchaseOrder = 8,
            RequestForQuote = 9,
            JobVersion = 10,
            CreativeBrief = 11,
            ProjectSchedule_Alerts = 12,
            Campaign_Print = 13,
            VendorQuote = 14,
            EstimateComponent = 15 // One component (ALERT TYPE: EST)
    ,
            JobSpecs = 16,
            CalendarActivity = 17,
            AlertInbox = 18,
            JobJacketMultiPrint = 19,
            MediaATB = 20
        }

        // Public Shared Function GetAdminConnection(ByVal SqlServerName As String, ByVal DatabaseName As String) As Admin

        // Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
        // Dim Admin As Admin = Nothing

        // For Each ConnectionStringSetting In System.Configuration.ConfigurationManager.ConnectionStrings.OfType(Of System.Configuration.ConnectionStringSettings)

        // SqlConnectionStringBuilder = Nothing

        // Try

        // SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionStringSetting.ConnectionString)

        // Catch ex As Exception
        // SqlConnectionStringBuilder = Nothing
        // End Try

        // If SqlConnectionStringBuilder IsNot Nothing Then

        // If SqlConnectionStringBuilder.DataSource = SqlServerName AndAlso SqlConnectionStringBuilder.InitialCatalog = DatabaseName Then

        // Admin = New Admin
        // Admin.ConnectionString = ConnectionStringSetting.ConnectionString
        // Admin.UserCode = SqlConnectionStringBuilder.UserID
        // Exit For

        // End If

        // End If

        // Next

        // Return Admin

        // End Function

        [Serializable]
        public class Admin
        {
            public string UserCode { get; set; } = string.Empty;
            public string ConnectionString { get; set; } = string.Empty;
            public Admin()
            {
            }
        }

        public static string CheckForCodeBlock(string Text, string Delimiter = "#CODE#")
        {
            int DelimiterLength = Delimiter.Length;
            System.Text.StringBuilder RebuiltText = new System.Text.StringBuilder();
            int Index = Text.IndexOf(Delimiter);
            int EndIndex = 0;
            string ReturnValue = "";

            if (Index > -1)
            {
                RebuiltText.Append(Text.Substring(0, Index));
                Text = Text.Substring(Index + DelimiterLength, Text.Length - (Index + DelimiterLength));
                EndIndex = Text.IndexOf(Delimiter);

                if (EndIndex > -1)
                {
                    RebuiltText.Append(System.Web.HttpUtility.HtmlEncode(Text.Substring(0, EndIndex)));
                    Text = Text.Substring(EndIndex + 6, Text.Length - (EndIndex + DelimiterLength));
                }

                RebuiltText.Append(Text);
                Text = RebuiltText.ToString();

                if (Text.IndexOf(Delimiter) > -1)
                    CheckForCodeBlock(Text);
                else
                    return Text;
            }
            else
            {
                RebuiltText.Append(Text);
                return RebuiltText.ToString();
            }

            return ReturnValue;
        }

        public static Dictionary<int, string> EnumToDictionary(System.Type Enumeration)
        {
            System.Array Values = System.Enum.GetValues(Enumeration);
            Dictionary<int, string> Container = new Dictionary<int, string>();
            foreach (int Value in Values)
            {
                string Text = System.Enum.GetName(Enumeration, Value);
                Container.Add(Value, Text);
            }
            return Container;
        }

        public static int SourceApp_ToInt(Source_App App)
        {
            try
            {
                return System.Convert.ToInt32(App);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public static Source_App SourceApp_FromInt(int IntVal)
        {
            try
            {
                return (Source_App)IntVal;
            }
            catch (Exception ex)
            {
                return default(Source_App);
            }
        }

        //public static long CharCount(string OrigString, string Chars, bool CaseSensitive = false)
        //{

        //    // **********************************************
        //    // PURPOSE: Returns Number of occurrences of a character or
        //    // or a character sequencence within a string

        //    // PARAMETERS:
        //    // OrigString: String to Search in
        //    // Chars: Character(s) to search for
        //    // CaseSensitive (Optional): Do a case sensitive search
        //    // Defaults to false

        //    // RETURNS:
        //    // Number of Occurrences of Chars in OrigString

        //    // EXAMPLES:
        //    // Debug.Print CharCount("FreeVBCode.com", "E") -- returns 3
        //    // Debug.Print CharCount("FreeVBCode.com", "E", True) -- returns 0
        //    // Debug.Print CharCount("FreeVBCode.com", "co") -- returns 2
        //    // '**********************************************
        //    try
        //    {
        //        long lLen;
        //        long lCharLen;
        //        long lAns;
        //        string sInput;
        //        string sChar;
        //        long lCtr;
        //        long lEndOfLoop;
        //        byte bytCompareType;

        //        sInput = OrigString;
        //        if (sInput == "")
        //            return 0;
        //        lLen = Strings.Len(sInput);
        //        lCharLen = Strings.Len(Chars);
        //        lEndOfLoop = (lLen - lCharLen) + 1;
        //        bytCompareType = CaseSensitive ? Constants.vbBinaryCompare : Constants.vbTextCompare;

        //        for (lCtr = 1; lCtr <= lEndOfLoop; lCtr++)
        //        {
        //            sChar = Strings.Mid(sInput, lCtr, lCharLen);
        //            if (Strings.StrComp(sChar, Chars, bytCompareType) == 0)
        //                lAns = lAns + 1;
        //        }

        //        CharCount = lAns;
        //    }
        //    catch (Exception ex)
        //    {
        //        return -1;
        //    }
        //}

        public static byte[] FileToByteArray(string PathSource, ref string Mime_Type)
        {
            if (PathSource.IndexOf(".pdf") > 0)
                Mime_Type = "application/pdf";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "application/msword";
            else if (PathSource.IndexOf(".ppt") > 0)
                Mime_Type = "application/mspowerpoint";
            else if (PathSource.IndexOf(".xls") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";
            else if (PathSource.IndexOf(".doc") > 0)
                Mime_Type = "";

            using (FileStream fsSource = new FileStream(PathSource, FileMode.Open, FileAccess.Read))
            {

                // Read the source file into a byte array.
                byte[] bytes = new byte[(fsSource.Length) - 1 + 1];
                int numBytesToRead = System.Convert.ToInt32(fsSource.Length);
                int numBytesRead = 0;

                while ((numBytesToRead > 0))
                {
                    // Read may return anything from 0 to numBytesToRead.
                    int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                    // Break when the end of the file is reached.
                    if ((n == 0))
                        break;
                    numBytesRead = (numBytesRead + n);
                    numBytesToRead = (numBytesToRead - n);
                }
                numBytesToRead = bytes.Length;

                if (numBytesToRead > 0)
                    return bytes;
            }

            return null;
        }


        public static bool NumberInRange(int JobNumber, int CompNumber)
        {
            if ((JobNumber > 0 & JobNumber < 999999) && (CompNumber > 0 & CompNumber < 999999))
                return true;
            else
                return false;
        }

        public static bool NumberInRange(int TheNumber)
        {
            if (TheNumber > 0 & TheNumber < 999999)
                return true;
            else
                return false;
        }

        public static string PadJobNum(string str)
        {
            try
            {
                if (str != "" & str != "0")
                    return str.PadLeft(6, '0');
                else
                    return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string PadJobCompNum(string str)
        {
            try
            {
                if (str != "" & str != "0")
                    return str.PadLeft(2, '0');
                else
                    return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static decimal ValidPerc(string Val, decimal DefaultPerc, ref bool IsValid)
        {
            if (Information.IsNumeric(Val) == false)
            {
                IsValid = false;
                return DefaultPerc;
            }
            else
            {
                decimal d = decimal.Parse(Val);
                if (d > 100)
                {
                    IsValid = false;
                    return 100.0M;
                }
                else if (d < 0)
                {
                    IsValid = false;
                    return 0.0M;
                }
                else
                {
                    IsValid = true;
                    return System.Convert.ToDecimal(Val);
                }
            }
        }





        public static bool IsValidTime(string StringToCheck, bool AllowBlanks)
        {
            if (StringToCheck != "")
            {
                StringToCheck = StringToCheck.Replace(" ", "").Replace("AM", "").Replace("PM", "");
                string[] ArStart;
                bool ValidTime = true;
                ArStart = StringToCheck.Split(":");
                if (System.Convert.ToInt32(ArStart[0]) > 12 | System.Convert.ToInt32(ArStart[0]) <= 0 | System.Convert.ToInt32(ArStart[1]) < 0 | System.Convert.ToInt32(ArStart[1]) > 59)
                    return false;
                else
                    return true;
            }
            else if (AllowBlanks)
                return true;
            else
                return false;
        }

        public static string GUID_Date(bool IncludeSpacer = true, bool IncludeTime = true, bool IncludeSeconds = true, bool IncludeMilliseconds = false)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            {
                var withBlock = sb;
                if (IncludeSpacer == true)
                    withBlock.Append("_");

                withBlock.Append(DateTime.Now.Year.ToString());
                withBlock.Append(DateTime.Now.Month.ToString().PadLeft(2, '0'));
                withBlock.Append(DateTime.Now.Day.ToString().PadLeft(2, '0'));

                if (IncludeSpacer == true)
                    withBlock.Append("_");

                if (IncludeTime == true)
                {
                    withBlock.Append(DateTime.Now.Hour.ToString().PadLeft(2, '0'));
                    withBlock.Append(DateTime.Now.Minute.ToString().PadLeft(2, '0'));

                    if (IncludeSeconds == true)
                        withBlock.Append(DateTime.Now.Second.ToString().PadLeft(2, '0'));

                    if (IncludeMilliseconds == true)
                    {
                        if (IncludeSpacer == true)
                            withBlock.Append("_");

                        withBlock.Append(DateTime.Now.Millisecond.ToString().PadLeft(4));
                    }
                }
            }
            return sb.ToString();
        }

        public static DateTime NormalizeDate(DateTime d)
        {
            // function to set the date to today while retaining the original time...
            // use for comparing time ranges (like if a task starts at 8am, is emp available at 8am regardless of date)
            return Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + d.ToShortTimeString());
        }

        //public static bool StartIsBeforeEnd(string s1, string s2)
        //{
        //    DateTime d1;
        //    DateTime d2;
        //    if (s1 == "" | s2 == "")
        //        return false;
        //    if (cGlobals.wvIsDate(s1) == false | cGlobals.wvIsDate(s2) == false)
        //        return false;
        //    try
        //    {
        //        d1 = cGlobals.wvCDate(s1);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    try
        //    {
        //        d2 = cGlobals.wvCDate(s2);
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    int i = DateTime.DateDiff(DateInterval.Day, d1, d2);
        //    if (i >= 0)
        //        return true;
        //    else
        //        return false;
        //}

        public static bool IsWeekendDay(DateTime TheDate)
        {
            try
            {
                switch (TheDate.DayOfWeek)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        {
                            return true;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public static int GetWorkingDays(string StartDate, string EndDate)
        //{
        //    // NOTE: To get an employee's working days, use the db function: wvfn_get_emp_workday_count
        //    // This function simply gets work days M,T,W,R,F (excludes weekends)
        //    if (cGlobals.wvIsDate(StartDate) == false | cGlobals.wvIsDate(EndDate) == false)
        //        return 0;
        //    else
        //        try
        //        {
        //            DateTime dStart = System.Convert.ToDateTime(StartDate);
        //            DateTime dEnd = System.Convert.ToDateTime(EndDate);
        //            long i = 0;
        //            int daycounter = 0;
        //            i = DateTime.DateDiff(DateInterval.Day, dStart, dEnd);
        //            DateTime currday;
        //            for (int j = 0; j <= i; j++)
        //            {
        //                currday = dStart.AddDays(System.Convert.ToDouble(j));
        //                if (currday.DayOfWeek != DayOfWeek.Saturday & currday.DayOfWeek != DayOfWeek.Sunday)
        //                    daycounter += 1;
        //            }
        //            return daycounter;
        //        }
        //        catch (Exception ex)
        //        {
        //            return 0;
        //        }
        //}

        //public static int GetTotalDays(string StartDate, string EndDate)
        //{
        //    if (cGlobals.wvIsDate(StartDate) == false | cGlobals.wvIsDate(EndDate) == false)
        //        return 0;
        //    else
        //        try
        //        {
        //            DateTime dStart = System.Convert.ToDateTime(StartDate);
        //            DateTime dEnd = System.Convert.ToDateTime(EndDate);
        //            long i = 0;
        //            return DateTime.DateDiff(DateInterval.Day, dStart, dEnd);
        //        }
        //        catch (Exception ex)
        //        {
        //            return 0;
        //        }
        //}

        //public static DateTime FixRadTimePickerDate(ref System.Web.UI.WebControls.TextBox tb, ref Telerik.Web.UI.RadTimePicker RTP)
        //{
        //    try
        //    {
        //        string StrRebuildTheDate;
        //        if (cGlobals.wvIsDate(tb.Text) == false)
        //            return default(DateTime);
        //        else
        //        {
        //            StrRebuildTheDate = cGlobals.wvCDate(tb.Text).ToShortDateString() + " " + Convert.ToDateTime(RTP.SelectedDate).ToShortTimeString();
        //            return Convert.ToDateTime(StrRebuildTheDate);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return default(DateTime);
        //    }
        //}

        public static string InvalidDateMessage()
        {
            StringBuilder sb = new StringBuilder();
            {
                var withBlock = sb;
                withBlock.Append(@"Invalid date.\n\n");
                withBlock.Append(@"Please provide the date in one of the following formats:\n");
                withBlock.Append(@"           090202                 mmddyy\n");
                withBlock.Append(@"           09022002             mmddyy\n");
                withBlock.Append(@"           09/02/02              mm/dd/yy\n");
                withBlock.Append(@"           09/02/2002          mm/dd/yyyy\n");
                withBlock.Append(@"           09-02-02               mm-dd-yy\n");
                withBlock.Append(@"           09-02-2002           mm-dd-yyyy\n\n");
            }
            return sb.ToString();
        }

        public static string SetCurrentMonth(bool StartOfMonth)
        {
            if (StartOfMonth == true)
                return System.Convert.ToString(DateTime.Now.Month) + "/1/" + System.Convert.ToString(DateTime.Now.Year);
            else
                return System.Convert.ToString(DateTime.Now.Month) + "/" + System.Convert.ToString(DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)) + "/" + System.Convert.ToString(DateTime.Now.Year);
        }



        public static string SessionId(string UserCode, string Password)
        {
            return AdvantageFramework.Core.Security.Encryption.Encrypt(UserCode) + AdvantageFramework.Core.Security.Encryption.Encrypt(Password) + AdvantageFramework.Core.Security.Encryption.Encrypt(DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString());
        }

        public static string ParseClientIDPrefix(string ControlClientId)
        {
            try
            {
                string[] bufs;
                string ans;
                if (ControlClientId.IndexOf("_") > -1)
                {
                    bufs = ControlClientId.Split("_");
                    ans = bufs[Information.UBound(bufs)];
                    ans = ControlClientId.Replace("_" + ans, "_");
                }
                else
                    ans = ControlClientId;
                return ans;
            }
            catch (Exception ex)
            {
                return ControlClientId;
            }
        }

        public static string ParseNextToLastDot(string buf)
        {
            string[] bufs;
            string ans = "";

            if (buf.IndexOf(".") > 0)
            {
                bufs = buf.Split(".");
                ans = bufs[Information.UBound(bufs) - 1];
            }

            return ans;
        }

        public static string ParseLastDot(string buf)
        {
            string[] bufs;
            string ans;

            if (buf.IndexOf(".") > 0)
            {
                bufs = buf.Split(".");
                ans = bufs[Information.UBound(bufs)];
            }
            else
                ans = buf;

            return ans;
        }

        public static string ParseLast(string buf, string Delimiter)
        {
            string[] bufs;
            string ans;

            if (buf.IndexOf(Delimiter) > 0)
            {
                bufs = buf.Split(Delimiter);
                ans = bufs[Information.UBound(bufs)];
            }
            else
                ans = buf;

            return ans;
        }

        public static string CleanStringForSplit(string OriginalString, string Delimiter, bool RemoveSpaces = true, bool RemoveDuplicates = true, bool RemoveTrailingDelim = true, bool RemoveEmptyItems = true, bool RemoveLineFeeds = true)
        {
            try
            {
                string str = OriginalString;
                if (str.Length > 0)
                {
                    if (RemoveSpaces == true)
                        str = str.Replace(" ", "");
                    str = str.Replace(Delimiter + Delimiter, Delimiter);
                    if (RemoveDuplicates == true)
                        str = RemoveDuplicatesFromString(str, Delimiter);
                    if (RemoveTrailingDelim == true)
                        str = RemoveTrailingDelimiter(str, Delimiter);
                    if (RemoveEmptyItems == true)
                    {
                        if (RemoveSpaces == true)
                            str = str.Replace(" ", "");
                        str = str.Replace(Delimiter + Delimiter, Delimiter);
                        str = str.Replace(Delimiter + " " + Delimiter, Delimiter);
                    }
                    if (RemoveLineFeeds == true)
                        str = str.Replace(Environment.NewLine, "").Replace(Constants.vbCrLf, "").Replace(Constants.vbCr, "").Replace(Constants.vbLf, "");
                    return str;
                }
                else
                    return OriginalString;
            }
            catch (Exception ex)
            {
                return OriginalString;
            }
        }

        public static string RemoveTrailingDelimiter(string OriginalString, string delimiter)
        {
            try
            {
                OriginalString = Strings.RTrim(OriginalString);
                if (OriginalString.EndsWith(delimiter))
                    return OriginalString.Substring(0, OriginalString.Length - 1);
                else
                    return OriginalString;
            }
            catch (Exception ex)
            {
                return OriginalString;
            }
        }

        public static string LineBreak(DisplayMedium display)
        {
            if (display == DisplayMedium.web)
                return "<br />";
            else
                return @"\n";
        }

        public static string RemoveDuplicatesFromString(string OriginalString, string Delimiter, bool UseDelimiter = false)
        {
            try
            {
                string str = string.Empty;
                string strHolder = string.Empty;
                string[] strArr;
                strArr = OriginalString.Split(System.Convert.ToChar(Delimiter));
                ArrayList arrList = new ArrayList();
                for (int i = 0; i <= strArr.Length - 1; i++)
                {
                    if (!arrList.Contains(strArr[i]))
                        arrList.Add(strArr[i]);
                }
                for (int j = 0; j <= arrList.Count - 1; j++)
                {
                    if (UseDelimiter == true)
                        str += arrList[j].ToString() + Delimiter;
                    else
                        str += arrList[j].ToString() + ",";
                }
                str = str.Replace(Delimiter + Delimiter, Delimiter);
                if (str.EndsWith(Delimiter))
                    str = str.Substring(0, str.Length - 1);
                return str;
            }
            catch (Exception ex)
            {
                return OriginalString;
            }
        }

        public static bool IsLetter(string val)
        {
            int idx;
            string str;
            char[] chars = new char[3001];

            str = val;
            chars = str.ToCharArray();

            for (idx = 0; idx <= str.Length - 1; idx++)
            {
                if (!char.IsLetter(chars[idx]))
                    return false;
            }

            return true;
        }

        //public static string ListBoxToString(Telerik.Web.UI.RadListBox lb)
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    string str = "";
        //    if (lb.Items(0).Selected == true)
        //        str = "";
        //    else
        //    {
        //        for (int i = 0; i <= lb.Items.Count - 1; i++)
        //        {
        //            if (i > 0 & lb.Items(i).Selected == true)
        //            {
        //                {
        //                    var withBlock = sb;
        //                    withBlock.Append("'");
        //                    withBlock.Append(lb.Items(i).Value);
        //                    withBlock.Append("'");
        //                    withBlock.Append(",");
        //                }
        //            }
        //        }
        //        str = sb.ToString();
        //        str = MiscFN.CleanStringForSplit(ref str, ",");
        //    }
        //    return str;
        //}



        //public static bool IsMvcActive()
        //{
        //    try
        //    {
        //        return System.Configuration.ConfigurationManager.AppSettings("MvcActive").ToString.ToLower == "true";
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public static bool IsNTAuth()
        {
            try
            {
                string strAuthentication = System.Environment.GetEnvironmentVariable("Authentication");
                if (strAuthentication == "Forms")
                    return false;
                else
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Public Shared Function EnableBookmarks() As Boolean
        // Try
        // 'Return CType(System.Configuration.ConfigurationManager.AppSettings("EnableBookmarks"), Boolean)

        // Catch ex As Exception
        // Return False
        // End Try
        // End Function

        public static bool IsClientPortal()
        {
            string Version = "";
            string[] VersionKeys = null;
            Version = System.Environment.GetEnvironmentVariable("VCtrl");
            if (Version != "##DEV##")
            {
                Version = AdvantageFramework.Core.Security.Methods.DecryptVersionKey("VersionEncryptor2007", Version);
                VersionKeys = Version.Split("|");
                if (VersionKeys[4].ToString() == "1")
                    return true;
            }

            return false;
        }

        //public static DataTable PivotTable(DataTable source)
        //{
        //    DataTable dest = new DataTable("Pivoted" + source.TableName);

        //    dest.Columns.Add(" ");

        //    DataRow r;
        //    foreach (var r in source.Rows)
        //        dest.Columns.Add(r(0).ToString());
        //    int i;
        //    for (i = 0; i <= (source.Columns.Count - 1) - 1; i++)
        //        dest.Rows.Add(dest.NewRow());

        //    for (i = 0; i <= dest.Rows.Count - 1; i++)
        //    {
        //        int c;
        //        for (c = 0; c <= dest.Columns.Count - 1; c++)
        //        {
        //            if (c == 0)
        //                dest.Rows(i)(0) = source.Columns((i + 1)).ColumnName;
        //            else
        //                dest.Rows(i)(c) = source.Rows((c - 1))((i + 1));
        //        }
        //    }
        //    dest.AcceptChanges();
        //    return dest;
        //} // PivotTable

        //public static void UpdateNullToZero(string TableName, string FieldName)
        //{
        //    try
        //    {
        //        using (SqlConnection MyConn = new SqlConnection(HttpContext.Current.Session("ConnString")))
        //        {
        //            MyConn.Open();
        //            SqlTransaction MyTrans = MyConn.BeginTransaction;
        //            SqlCommand MyCmd = new SqlCommand("UPDATE " + TableName + " SET " + FieldName + " = 0 WHERE (" + FieldName + " IS NULL)", MyConn, MyTrans);
        //            try
        //            {
        //                MyCmd.ExecuteNonQuery();
        //                MyTrans.Commit();
        //            }
        //            catch (Exception ex)
        //            {
        //                MyTrans.Rollback();
        //            }
        //            finally
        //            {
        //                if (MyConn.State == ConnectionState.Open)
        //                    MyConn.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        public static int BoolToInt(bool TheBool)
        {
            if (TheBool == true)
                return 1;

            return 0;
        }

        public static bool IntToBool(int TheInt)
        {
            try
            {
                if (TheInt == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public static string GetOneValue(string TheSQL)
        //{
        //    try
        //    {
        //        using (SqlConnection MyConn = new SqlConnection(HttpContext.Current.Session("ConnString")))
        //        {
        //            MyConn.Open();
        //            SqlCommand MyCmd = new SqlCommand(TheSQL, MyConn);
        //            try
        //            {
        //                return System.Convert.ToString(MyCmd.ExecuteScalar());
        //            }
        //            catch (Exception ex)
        //            {
        //                return "";
        //            }
        //            finally
        //            {
        //                if (MyConn.State == ConnectionState.Open)
        //                    MyConn.Close();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}



        //public static string GetWeekString(ref CheckBoxList chk)
        //{
        //    try
        //    {
        //        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //        bool HasSelections = false;
        //        {
        //            var withBlock = sb;
        //            for (int i = 0; i <= chk.Items.Count - 1; i++)
        //            {
        //                if (chk.Items(i).Selected == true)
        //                {
        //                    HasSelections = true;
        //                    withBlock.Append(chk.Items(i).Value);
        //                    withBlock.Append(",");
        //                }
        //            }
        //        }
        //        string s = sb.ToString();
        //        if (HasSelections == true)
        //            return MiscFN.CleanStringForSplit(ref s, ",");
        //        else
        //            return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}

        //public static void SetWeekCheckboxList(ref CheckBoxList chk, string DaysString)
        //{
        //    try
        //    {
        //        string[] ar;
        //        ar = DaysString.Split(",");
        //        for (int i = 0; i <= ar.Length - 1; i++)
        //            chk.Items.FindByValue(ar[i]).Selected = true;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}


        //public static void SetListbox(ref Telerik.Web.UI.RadListBox TheListBox, string TheCSV_String)
        //{
        //    try
        //    {
        //        if (TheListBox.Items.Count > 0)
        //        {
        //            if (TheCSV_String == "" | TheCSV_String == "%" | TheCSV_String.IndexOf(",") == -1)
        //                TheListBox.SelectedIndex = 0;
        //            else
        //            {
        //                TheCSV_String = RemoveTrailingDelimiter(TheCSV_String, ",");
        //                string[] ar;
        //                ar = TheCSV_String.Split(",");
        //                for (int o = 0; o <= ar.Length - 1; o++)
        //                {
        //                    try
        //                    {
        //                        TheListBox.FindItemByValue(ar[o]).Selected = true;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }
        //                }
        //            }
        //        }
        //        else
        //            return;
        //    }
        //    catch (Exception ex)
        //    {
        //        return;
        //    }
        //}

        //public static void LimitTextbox(ref System.Web.UI.WebControls.TextBox TheTB, int TheLimit)
        //{
        //    // TheTB.Attributes.Add("onkeyup", "javascript:limitText(this.form." & TheTB.ClientID & "," & TheLimit.ToString() & ");")
        //    // TheTB.Attributes.Add("onchange", "javascript:limitText(this.form." & TheTB.ClientID & "," & TheLimit.ToString() & ");")
        //    {
        //        var withBlock = TheTB.Attributes;
        //        withBlock.Add("onkeyup", "limitText(this," + TheLimit + ");");
        //        withBlock.Add("onkeydown", "limitText(this," + TheLimit + ");");
        //    }
        //}

        //public static void ClearOtherTextbox(ref System.Web.UI.WebControls.TextBox The_Trigger_TB, ref System.Web.UI.WebControls.TextBox The_Target_TB_To_Clear)
        //{
        //}

        //public static void SetFocus(System.Web.UI.Control control)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    {
        //        var withBlock = sb;
        //        withBlock.Append("" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "<script language='JavaScript'>" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "");
        //        withBlock.Append("<!--" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "");
        //        withBlock.Append("function SetFocus()" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "");
        //        withBlock.Append("{" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "");
        //        withBlock.Append("" + Microsoft.VisualBasic.Chr(9) + "document.");
        //        // Dim p As System.Web.UI.Control = control.Parent
        //        // While Not (TypeOf p Is System.Web.UI.HtmlControls.HtmlForm)
        //        // p = p.Parent
        //        // End While
        //        // .Append(p.ClientID)
        //        // .Append("['")
        //        // .Append(control.UniqueID)
        //        // .Append("'].select();" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
        //        withBlock.Append("forms[0]." + control.ClientID + ".select();" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "");
        //        withBlock.Append("}" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "");
        //        withBlock.Append("window.onload = SetFocus;" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "");
        //        withBlock.Append("// -->" + Microsoft.VisualBasic.Chr(13) + "" + Microsoft.VisualBasic.Chr(10) + "");
        //        withBlock.Append("</script>");
        //    }
        //    control.Page.ClientScript.RegisterClientScriptBlock(control.GetType(), "SetFocus", sb.ToString());
        //}

        //public static Literal NewLiteral(string text)
        //{
        //    Literal lit;
        //    lit = new Literal();
        //    lit.Text = text;
        //    return lit;
        //}

        //public static bool IsEmptyTextbox(ref System.Web.UI.WebControls.TextBox tb)
        //{
        //    string str;
        //    str = tb.Text.Replace(" ", "");
        //    str = str.Trim();
        //    try
        //    {
        //        if (str.Length == 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}


        //public static System.Web.UI.Control FindControlRecursive(System.Web.UI.Control Root, string Id)
        //{
        //    if (Root.ID == Id)
        //        return Root;
        //    foreach (System.Web.UI.Control Ctl in Root.Controls)
        //    {
        //        System.Web.UI.Control FoundCtl = FindControlRecursive(Ctl, Id);
        //        if (!(FoundCtl == null))
        //            return FoundCtl;
        //    }
        //    return null;
        //}

        //public static Telerik.Web.UI.RadComboBoxItem NewListItem(string TheText, string TheValue)
        //{
        //    Telerik.Web.UI.RadComboBoxItem itm = new Telerik.Web.UI.RadComboBoxItem();
        //    {
        //        var withBlock = itm;
        //        withBlock.Text = TheText;
        //        withBlock.Value = TheValue;
        //    }
        //    return itm;
        //}


        //public static void ResponseRedirect(string URL, bool EndResponse = false)
        //{
        //    try
        //    {
        //        System.Web.HttpContext.Current.Response.Redirect(URL, EndResponse);
        //        if (EndResponse == false)
        //            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public static string JavascriptSafe(string StringToEncode)
        //{
        //    try
        //    {
        //        return HttpUtility.JavaScriptStringEncode(StringToEncode);
        //    }
        //    // Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
        //    // Sanitizer.AllowDataAttributes = True
        //    // Sanitizer.AllowedAttributes.Add("class")
        //    // Return Sanitizer.Sanitize(StringToEncode)

        //    // 'All WV messages are now HTML, should not need to encode to js safe
        //    // Return HttpUtility.HtmlEncode(StringToEncode)

        //    catch (Exception ex)
        //    {
        //        return StringToEncode;
        //    }
        //}

        public static string HTML_AppendAlertId(int AlertId, string HexColor)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            {
                var withBlock = sb;
                withBlock.Append("<font color=\"#" + HexColor + "\" bgcolor=\"#" + HexColor + "\">");
                withBlock.Append("##");
                withBlock.Append("LISTENER_ALERT_ID:");
                withBlock.Append(AlertId.ToString());
                withBlock.Append("##");
                withBlock.Append("</font>");
            }
            return sb.ToString();
        }

        //public static bool BrowserTypeIs(Browser_Types WhatAreYouLookingFor)
        //{
        //    switch (WhatAreYouLookingFor)
        //    {
        //        case Browser_Types.IE:
        //            {
        //                if (HttpContext.Current.Request.Browser.Type.ToString().IndexOf("IE6") > -1 | HttpContext.Current.Request.Browser.Type.ToString().IndexOf("IE7") > -1 | HttpContext.Current.Request.Browser.Type.ToString().IndexOf("IE8") > -1 | HttpContext.Current.Request.Browser.Type.ToString().IndexOf("IE9") > -1)
        //                    return true;
        //                else
        //                    return false;
        //                break;
        //            }

        //        case Browser_Types.Safari:
        //            {
        //                if (HttpContext.Current.Request.Browser.Type.ToString().IndexOf("Safari") > -1)
        //                    return true;
        //                else
        //                    return false;
        //                break;
        //            }

        //        case Browser_Types.Firefox:
        //            {
        //                if (HttpContext.Current.Request.Browser.Type.ToString().IndexOf("Firefox") > -1)
        //                    return true;
        //                else
        //                    return false;
        //                break;
        //            }

        //        case Browser_Types.Chrome:
        //            {
        //                if (HttpContext.Current.Request.Browser.Type.ToString().IndexOf("Chrome") > -1 | HttpContext.Current.Request.Browser.Type.ToString.IndexOf("Desktop") > -1)
        //                    return true;
        //                else
        //                    return false;
        //                break;
        //            }

        //        case Browser_Types.Opera:
        //            {
        //                if (HttpContext.Current.Request.Browser.Type.ToString().IndexOf("Opera") > -1)
        //                    return true;
        //                else
        //                    return false;
        //                break;
        //            }
        //    }
        //}

        //public static bool IsValidRequest(string TheURL)
        //{
        //    HttpWebRequest req = WebRequest.Create(TheURL);
        //    try
        //    {
        //        HttpWebResponse resp = req.GetResponse();
        //        return true;
        //    }
        //    catch (WebException WebEx)
        //    {
        //        return false;
        //    }
        //    catch (Exception Ex)
        //    {
        //        return false;
        //    }
        //}

        public static string HTMLPad(string str, int TotalLengthToPad, bool LeftPad = true)
        {
            int LengthToPad = TotalLengthToPad - str.Length;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int i = 1;

            if (LengthToPad <= 0)
                return str;
            else if (LeftPad == true)
            {
                for (i = 1; i <= LengthToPad; i++)
                    sb.Append("&nbsp;");
                sb.Append(str);
            }
            else
            {
                sb.Append(str);
                for (i = 1; i <= LengthToPad; i++)
                    sb.Append("&nbsp;");
            }
            return sb.ToString();
        }

        //public static string GetThePath(System.Web.UI.Page parent)
        //{
        //    try
        //    {
        //        return parent.Server.MapPath("").ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        return "Err: " + ex.Message.ToString();
        //    }
        //}

        public static string RemoveInputTag(string Str)
        {
            try
            {
                string temp = Str;
                string Rebuild = "";

                int iStart = temp.IndexOf("<input type=\"submit\"");
                int iEnd = temp.IndexOf("/>", iStart) + 2;


                Rebuild = temp.Substring(0, iStart) + temp.Substring(iEnd, temp.Length - iEnd);


                return Rebuild;
            }
            catch (Exception ex)
            {
                return Str;
            }
        }

        //public static string SetJavascriptAlertTimer()
        //{
        //    try
        //    {
        //        int TimeOut = System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("AlertRefresh"));
        //        if (TimeOut > 0)
        //            return "var AlertNotifyInterval = self.setInterval('OpenAlertNotifiy()', " + TimeOut.ToString() + ");";
        //        else
        //            return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}





        //public static void RadgridSavePageSize(ref Telerik.Web.UI.RadGrid grid, int PageSize = 15)
        //{
        //    try
        //    {
        //        grid.AllowPaging = true;
        //        grid.PageSize = PageSize;
        //        grid.MasterTableView.PageSize = PageSize;
        //        MiscFN.SavePageSize(grid.ID, PageSize);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public static void RadgridSetPageSize(ref Telerik.Web.UI.RadGrid grid)
        //{
        //    try
        //    {
        //        grid.AllowPaging = true;
        //        grid.PageSize = MiscFN.LoadPageSize(grid.ID);
        //        grid.MasterTableView.PageSize = MiscFN.LoadPageSize(grid.ID);
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public static int LoadPageSize(string GridName)
        //{
        //    try
        //    {
        //        var PageSize = 15;

        //        GridName = GridName.Trim();
        //        if (GridName != "")
        //        {
        //            cAppVars oAppVars = new cAppVars(cAppVars.Application.GRID_PAGE_SIZE);
        //            oAppVars.getAllAppVars();
        //            if (IsNumeric(oAppVars.getAppVar(GridName)) == true)
        //                PageSize = System.Convert.ToInt32(oAppVars.getAppVar(GridName));
        //        }

        //        if (PageSize < 0)
        //            PageSize = 15;

        //        return PageSize;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public static bool SavePageSize(string GridName, int PageSize)
        //{
        //    if (PageSize < 0)
        //        PageSize = 0;
        //    cAppVars oAppVars = new cAppVars(cAppVars.Application.GRID_PAGE_SIZE);
        //    {
        //        var withBlock = oAppVars;
        //        withBlock.getAllAppVars();
        //        withBlock.setAppVar(GridName, PageSize, "Integer");
        //        withBlock.SaveAllAppVars();
        //    }
        //    return true;
        //}

        // 'Public Shared Sub RadgridSaveSettings(ByRef grid As Telerik.Web.UI.RadGrid)
        // '    Try
        // '        Dim GridSettings As New AdvantageFramework.Web.Presentation.Controls.GridSettingsPersister(grid)
        // '        HttpContext.Current.Response.Cookies(grid.ID & "Settings").Value = GridSettings.SaveSettings()
        // '        HttpContext.Current.Response.Cookies(grid.ID & "Settings").Expires = DateTime.Now.AddDays(30)
        // '    Catch ex As Exception
        // '    End Try
        // 'End Sub

        // 'Public Shared Sub RadgridLoadSettings(ByRef grid As Telerik.Web.UI.RadGrid)
        // '    Try
        // '        If HttpContext.Current.Request.Cookies(grid.ID & "Settings") IsNot Nothing _
        // '            AndAlso HttpContext.Current.Request.Cookies(grid.ID & "Settings").Value IsNot Nothing Then
        // '            Dim GridSettings As New AdvantageFramework.Web.Presentation.Controls.GridSettingsPersister(grid)
        // '            GridSettings.LoadSettings(HttpContext.Current.Request.Cookies(grid.ID & "Settings").Value.ToString())
        // '        End If
        // '    Catch ex As Exception
        // '    End Try
        // 'End Sub

        //public static void RadWindowsClose(ref Telerik.Web.UI.RadWindowManager TheWindowManager)
        //{
        //    try
        //    {
        //        if (TheWindowManager.Windows.Count > 0)
        //        {
        //            for (int i = 0; i <= TheWindowManager.Windows.Count - 1; i++)
        //                TheWindowManager.Windows(i).VisibleOnPageLoad = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public static void SetTelerikAjaxTimerInterval(ref System.Web.UI.Timer TheAjaxTimer)
        //{
        //    try
        //    {
        //        int i = System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("AlertRefresh"));
        //        if (i == -1 | i < 3)
        //        {
        //            {
        //                var withBlock = TheAjaxTimer;
        //                withBlock.Interval = -1;
        //                withBlock.Enabled = false;
        //            }
        //        }
        //        else
        //        {
        //            var withBlock = TheAjaxTimer;
        //            withBlock.Interval = i;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        {
        //            var withBlock = TheAjaxTimer;
        //            withBlock.Interval = -1;
        //            withBlock.Enabled = false;
        //        }
        //    }
        //}

        //public static void SetAjaxTimerInterval(ref System.Web.UI.Timer TheAjaxTimer)
        //{
        //    try
        //    {
        //        int i = System.Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings("AlertRefresh"));
        //        if (i == -1 | i < 3)
        //        {
        //            {
        //                var withBlock = TheAjaxTimer;
        //                withBlock.Interval = -1;
        //                withBlock.Enabled = false;
        //            }
        //        }
        //        else
        //        {
        //            var withBlock = TheAjaxTimer;
        //            withBlock.Interval = i;
        //            withBlock.Enabled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        {
        //            var withBlock = TheAjaxTimer;
        //            withBlock.Interval = -1;
        //            withBlock.Enabled = false;
        //        }
        //    }
        //}

        //public static bool ValidDate(Telerik.Web.UI.RadDatePicker RadDatePicker, bool AllowNull = false)
        //{
        //    try
        //    {
        //        if (RadDatePicker.SelectedDate.HasValue == true)
        //            return true;
        //        string s = RadDatePicker.DateInput.Text.Trim();
        //        if (s == "")
        //        {
        //            if (AllowNull == true)
        //                return true;
        //            else
        //                return false;
        //        }
        //        else if (cGlobals.wvIsDate(s) == true)
        //        {
        //            RadDatePicker.SelectedDate = System.Convert.ToDateTime(s);
        //            return true;
        //        }
        //        else
        //        {
        //            RadDatePicker.SelectedDate = null;
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        //public static bool EmptyDate(Telerik.Web.UI.RadDatePicker RadDatePicker)
        //{
        //    try
        //    {
        //        if (RadDatePicker.SelectedDate.HasValue == false | RadDatePicker.DateInput.Text.Trim() == "")
        //            return true;
        //        DateTime val = default(DateTime);
        //        try
        //        {
        //            if (MiscFN.ValidDate(RadDatePicker) == true)
        //                return false;
        //            else
        //                return true;
        //        }
        //        catch (Exception ex)
        //        {
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return true;
        //    }
        //}

        //public static bool ValidDateRange(Telerik.Web.UI.RadDatePicker RadDatePickerStart, Telerik.Web.UI.RadDatePicker RadDatePickerEnd, bool FixStartBeforeEnd = true)
        //{
        //    if (MiscFN.ValidDate(RadDatePickerStart) == true & MiscFN.ValidDate(RadDatePickerEnd) == false)
        //        return false;
        //    else if (MiscFN.ValidDate(RadDatePickerStart) == false & MiscFN.ValidDate(RadDatePickerEnd) == true)
        //        return false;
        //    else if (MiscFN.ValidDate(RadDatePickerStart) == false & MiscFN.ValidDate(RadDatePickerEnd) == false)
        //        // maybe should return true if both are blank? (Handle non-required date ranges)
        //        return false;

        //    DateTime d1 = RadDatePickerStart.SelectedDate;
        //    DateTime d2 = RadDatePickerEnd.SelectedDate;
        //    int i = DateTime.DateDiff(DateInterval.Day, d1, d2);
        //    if (i >= 0)
        //        return true;
        //    else if (FixStartBeforeEnd == true)
        //    {
        //        {
        //            var withBlock = RadDatePickerStart;
        //            withBlock.SelectedDate = d2;
        //            withBlock.DateInput.Text = d2.ToShortDateString();
        //        }
        //        {
        //            var withBlock = RadDatePickerEnd;
        //            withBlock.SelectedDate = d1;
        //            withBlock.DateInput.Text = d1.ToShortDateString();
        //        }
        //        return true;
        //    }
        //    else
        //        return false;
        //}

        //public static void RadComboBoxSetIndex(ref Telerik.Web.UI.RadComboBox RadComboBox, string ListItemTextValue, bool FindTextInsteadOfValue, bool ForceOverride = false)
        //{
        //    try
        //    {
        //        if (!RadComboBox == null)
        //        {
        //            try
        //            {
        //                if (ListItemTextValue != "")
        //                {
        //                    {
        //                        var withBlock = RadComboBox;
        //                        withBlock.SelectedIndex = -1;
        //                        withBlock.ClearSelection();
        //                    }

        //                    Telerik.Web.UI.RadComboBoxItem FoundItem;
        //                    if (FindTextInsteadOfValue == true)
        //                        FoundItem = RadComboBox.FindItemByText(ListItemTextValue);
        //                    else
        //                        FoundItem = RadComboBox.FindItemByValue(ListItemTextValue);

        //                    if (!FoundItem == null)
        //                        FoundItem.Selected = true;
        //                    else if (ForceOverride == true)
        //                    {
        //                        RadComboBox.Items.Insert(0, new Telerik.Web.UI.RadComboBoxItem("[" + ListItemTextValue + "] **", ListItemTextValue));
        //                        RadComboBox.FindItemByValue(ListItemTextValue).Selected = true;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                RadComboBox.SelectedIndex = -1;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //public static void RadListBoxSetIndex(ref Telerik.Web.UI.RadListBox RadListBox, string ListItemTextValue, bool FindTextInsteadOfValue, bool ForceOverride = false)
        //{
        //    try
        //    {
        //        if (!RadListBox == null)
        //        {
        //            try
        //            {
        //                if (ListItemTextValue != "")
        //                {
        //                    {
        //                        var withBlock = RadListBox;
        //                        withBlock.SelectedIndex = -1;
        //                        withBlock.ClearSelection();
        //                    }

        //                    Telerik.Web.UI.RadListBoxItem FoundItem;
        //                    if (FindTextInsteadOfValue == true)
        //                        FoundItem = RadListBox.FindItemByText(ListItemTextValue);
        //                    else
        //                        FoundItem = RadListBox.FindItemByValue(ListItemTextValue);

        //                    if (!FoundItem == null)
        //                        FoundItem.Selected = true;
        //                    else if (ForceOverride == true)
        //                    {
        //                        RadListBox.Items.Insert(0, new Telerik.Web.UI.RadListBoxItem(ListItemTextValue + " **", ListItemTextValue));
        //                        RadListBox.FindItemByValue(ListItemTextValue).Selected = true;
        //                    }
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                RadListBox.SelectedIndex = -1;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

        //[CLSCompliant(false)]
        //public static bool SignOutOfWebvantage(ref AdvantageFramework.Security.Session SecuritySession, ref string ErrorMessage)
        //{
        //    bool Success = false;

        //    ErrorMessage = string.Empty;

        //    try
        //    {
        //        if (HttpContext.Current.Session("NewLicenseKey") != null && HttpContext.Current.Session("NewLicenseKey") == true && HttpContext.Current.Session("CurrentSessionId") != null && SecuritySession != null)
        //        {
        //            if (MiscFN.IsClientPortal() == true)
        //            {
        //                if (AdvantageFramework.Security.LicenseKey.Clear(SecuritySession, "", HttpContext.Current.Session("CurrentSessionId"), "") == true)
        //                {
        //                    try
        //                    {
        //                        using (var DbContext = new AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //                        {
        //                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.CP_USER WITH(ROWLOCK) SET WEB_ID = NULL WHERE USER_GUID = " + SecuritySession.ClientPortalUser.ID.ToString);
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Webvantage.SignalR.Classes.ChatHub.SignOut(SecuritySession, SecuritySession.UserCode, true);

        //                if (AdvantageFramework.Security.LicenseKey.Clear(SecuritySession, "", HttpContext.Current.Session("CurrentSessionId"), true, "") == true)
        //                {
        //                    try
        //                    {
        //                        using (var DbContext = new AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode))
        //                        {
        //                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.SEC_USER WITH(ROWLOCK) SET WEB_ID = NULL WHERE SEC_USER_ID = " + SecuritySession.User.ID);
        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                    }
        //                }
        //            }
        //        }
        //        else
        //            try
        //            {
        //                SecuritySession.UnregisterSecuritySession(HttpContext.Current.Session("CurrentSessionId"));
        //            }
        //            catch (Exception ex)
        //            {
        //            }

        //        cSecurity.DeleteCacheDependencyFile(HttpContext.Current.Session("CurrentSessionId"));

        //        AdvantageFramework.Security.SetUserLogoutAuditRecord(SecuritySession);

        //        System.Web.Security.FormsAuthentication.SignOut();
        //        ErrorMessage = string.Empty;
        //        Success = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        ErrorMessage = ex.Message.ToString();
        //        Success = false;
        //    }

        //    return Success;
        //}
    }
}

