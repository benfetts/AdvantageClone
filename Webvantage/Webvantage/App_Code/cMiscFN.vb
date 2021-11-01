Imports SR = System.Reflection
Imports System.Configuration
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Math
Imports System.Net
Imports System.Security.Principal
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Web.UI.WebControls

Imports Webvantage.cGlobals
Imports System.Collections.Generic
Imports System.Globalization

<Serializable()> Public Class MiscFN

    Public Const ShowErrorSessionKey As String = "ii8j47EohQAB5ZFYGE3cdqy"

    Public Enum DisplayMedium
        web = 0
        javascript = 1
    End Enum

    Public Enum Browser_Types
        IE = 0
        Safari = 1
        Firefox = 2
        Chrome = 3
        Opera = 4
    End Enum

    'pass the int using "f" for the querysting variable
    Public Enum Source_App

        Alert = 0
        JobJacket = 1
        JobJacketAlerts = 2
        ProjectSchedule = 3
        ProjectScheduleTask = 4
        Campaign = 5
        Estimate = 6 'multiple components (ALERT TYPE: ES)
        Desktop = 7
        PurchaseOrder = 8
        RequestForQuote = 9
        JobVersion = 10
        CreativeBrief = 11
        ProjectSchedule_Alerts = 12
        Campaign_Print = 13
        VendorQuote = 14
        EstimateComponent = 15 'One component (ALERT TYPE: EST)
        JobSpecs = 16
        CalendarActivity = 17
        AlertInbox = 18
        JobJacketMultiPrint = 19
        MediaATB = 20

    End Enum

    'Public Shared Function GetAdminConnection(ByVal SqlServerName As String, ByVal DatabaseName As String) As Admin

    '    Dim SqlConnectionStringBuilder As System.Data.SqlClient.SqlConnectionStringBuilder = Nothing
    '    Dim Admin As Admin = Nothing

    '    For Each ConnectionStringSetting In System.Configuration.ConfigurationManager.ConnectionStrings.OfType(Of System.Configuration.ConnectionStringSettings)

    '        SqlConnectionStringBuilder = Nothing

    '        Try

    '            SqlConnectionStringBuilder = New System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionStringSetting.ConnectionString)

    '        Catch ex As Exception
    '            SqlConnectionStringBuilder = Nothing
    '        End Try

    '        If SqlConnectionStringBuilder IsNot Nothing Then

    '            If SqlConnectionStringBuilder.DataSource = SqlServerName AndAlso SqlConnectionStringBuilder.InitialCatalog = DatabaseName Then

    '                Admin = New Admin
    '                Admin.ConnectionString = ConnectionStringSetting.ConnectionString
    '                Admin.UserCode = SqlConnectionStringBuilder.UserID
    '                Exit For

    '            End If

    '        End If

    '    Next

    '    Return Admin

    'End Function

    <Serializable>
    Public Class Admin
        Public Property UserCode As String = String.Empty
        Public Property ConnectionString As String = String.Empty
        Sub New()
        End Sub
    End Class

    Public Shared Function CheckForCodeBlock(ByVal Text As String, Optional ByVal Delimiter As String = "#CODE#") As String

        Dim DelimiterLength As Integer = Delimiter.Length
        Dim RebuiltText As New System.Text.StringBuilder
        Dim Index As Integer = Text.IndexOf(Delimiter)
        Dim EndIndex As Integer = 0
        Dim ReturnValue As String = ""

        If Index > -1 Then

            RebuiltText.Append(Text.Substring(0, Index))
            Text = Text.Substring(Index + DelimiterLength, Text.Length - (Index + DelimiterLength))
            EndIndex = Text.IndexOf(Delimiter)

            If EndIndex > -1 Then

                RebuiltText.Append(System.Web.HttpUtility.HtmlEncode(Text.Substring(0, EndIndex)))
                Text = Text.Substring(EndIndex + 6, Text.Length - (EndIndex + DelimiterLength))

            End If

            RebuiltText.Append(Text)
            Text = RebuiltText.ToString()

            If Text.IndexOf(Delimiter) > -1 Then

                CheckForCodeBlock(Text)

            Else

                Return Text

            End If

        Else

            RebuiltText.Append(Text)
            Return RebuiltText.ToString()

        End If

    End Function

    Public Shared Function EnumToDictionary(ByVal [Enumeration] As System.Type) As Dictionary(Of Integer, String)
        Dim Values As System.Array = System.Enum.GetValues([Enumeration])
        Dim [Container] As Dictionary(Of Integer, String)
        For Each Value As Integer In Values
            Dim [Text] As String = System.Enum.GetName([Enumeration], Value)
            [Container].Add(Value, [Text])
        Next
        Return [Container]
    End Function

    Public Shared Function SourceApp_ToInt(ByVal App As Source_App) As Integer
        Try
            Return CType(App, Integer)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Shared Function SourceApp_FromInt(ByVal IntVal As Integer) As Source_App
        Try
            Return CType(IntVal, Source_App)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function CharCount(ByVal OrigString As String, ByVal Chars As String, Optional ByVal CaseSensitive As Boolean = False) As Long

        '**********************************************
        'PURPOSE: Returns Number of occurrences of a character or
        'or a character sequencence within a string

        'PARAMETERS:
        'OrigString: String to Search in
        'Chars: Character(s) to search for
        'CaseSensitive (Optional): Do a case sensitive search
        'Defaults to false

        'RETURNS:
        'Number of Occurrences of Chars in OrigString

        'EXAMPLES:
        'Debug.Print CharCount("FreeVBCode.com", "E") -- returns 3
        'Debug.Print CharCount("FreeVBCode.com", "E", True) -- returns 0
        'Debug.Print CharCount("FreeVBCode.com", "co") -- returns 2
        ''**********************************************
        Try
            Dim lLen As Long
            Dim lCharLen As Long
            Dim lAns As Long
            Dim sInput As String
            Dim sChar As String
            Dim lCtr As Long
            Dim lEndOfLoop As Long
            Dim bytCompareType As Byte

            sInput = OrigString
            If sInput = "" Then Exit Function
            lLen = Len(sInput)
            lCharLen = Len(Chars)
            lEndOfLoop = (lLen - lCharLen) + 1
            bytCompareType = IIf(CaseSensitive, vbBinaryCompare,
               vbTextCompare)

            For lCtr = 1 To lEndOfLoop
                sChar = Mid(sInput, lCtr, lCharLen)
                If StrComp(sChar, Chars, bytCompareType) = 0 Then _
                    lAns = lAns + 1
            Next

            CharCount = lAns

        Catch ex As Exception
            Return -1
        End Try

    End Function

    Public Shared Function FileToByteArray(ByVal PathSource As String, Optional ByRef Mime_Type As String = "") As Byte()

        If PathSource.IndexOf(".pdf") > 0 Then
            Mime_Type = "application/pdf"
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = "application/msword"
        ElseIf PathSource.IndexOf(".ppt") > 0 Then
            Mime_Type = "application/mspowerpoint"
        ElseIf PathSource.IndexOf(".xls") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        ElseIf PathSource.IndexOf(".doc") > 0 Then
            Mime_Type = ""
        End If

        Try
            Using fsSource As FileStream = New FileStream(PathSource,
                FileMode.Open, FileAccess.Read)

                ' Read the source file into a byte array.
                Dim bytes() As Byte = New Byte((fsSource.Length) - 1) {}
                Dim numBytesToRead As Integer = CType(fsSource.Length, Integer)
                Dim numBytesRead As Integer = 0

                While (numBytesToRead > 0)
                    ' Read may return anything from 0 to numBytesToRead.
                    Dim n As Integer = fsSource.Read(bytes, numBytesRead,
                        numBytesToRead)
                    ' Break when the end of the file is reached.
                    If (n = 0) Then
                        Exit While
                    End If
                    numBytesRead = (numBytesRead + n)
                    numBytesToRead = (numBytesToRead - n)

                End While
                numBytesToRead = bytes.Length

                If numBytesToRead > 0 Then
                    Return bytes
                End If
            End Using
        Catch ioEx As FileNotFoundException

        End Try
    End Function

#Region " Numerical Functions "

    Public Overloads Shared Function NumberInRange(ByVal JobNumber As Integer, ByVal CompNumber As Integer) As Boolean
        If (JobNumber > 0 And JobNumber < 999999) AndAlso (CompNumber > 0 And CompNumber < 999999) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overloads Shared Function NumberInRange(ByVal TheNumber As Integer) As Boolean
        If TheNumber > 0 And TheNumber < 999999 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Function PadJobNum(ByVal str As String) As String
        Try
            If str <> "" And str <> "0" Then
                Return str.PadLeft(6, "0")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function PadJobCompNum(ByVal str As String) As String
        Try
            If str <> "" And str <> "0" Then
                Return str.PadLeft(2, "0")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Function ValidPerc(ByVal Val As String, Optional ByVal DefaultPerc As Decimal = 0.0, Optional ByRef IsValid As Boolean = False) As Decimal
        If IsNumeric(Val) = False Then
            IsValid = False
            Return DefaultPerc
        Else
            Dim d As Decimal = Val
            If d > 100 Then
                IsValid = False
                Return 100.0
            ElseIf d < 0 Then
                IsValid = False
                Return 0.0
            Else
                IsValid = True
                Return CType(Val, Decimal)
            End If
        End If
    End Function



#End Region

#Region " Date Time Functions "

    Public Shared Function IsValidTime(ByVal StringToCheck As String, ByVal AllowBlanks As Boolean) As Boolean
        If StringToCheck <> "" Then
            StringToCheck = StringToCheck.Replace(" ", "").Replace("AM", "").Replace("PM", "")
            Dim ArStart() As String
            Dim ValidTime As Boolean = True
            ArStart = StringToCheck.Split(":")
            If CType(ArStart(0), Integer) > 12 Or CType(ArStart(0), Integer) <= 0 Or CType(ArStart(1), Integer) < 0 Or CType(ArStart(1), Integer) > 59 Then
                Return False
            Else
                Return True
            End If
        Else
            If AllowBlanks Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    'Public Shared Function GUID_Date(Optional ByVal IncludeSpacer As Boolean = True,
    '                                 Optional ByVal IncludeTime As Boolean = True,
    '                                 Optional ByVal IncludeSeconds As Boolean = True,
    '                                 Optional ByVal IncludeMilliseconds As Boolean = False) As String

    '    Return AdvantageFramework.StringUtilities.GUID_Date(IncludeSpacer,
    '                                                        IncludeTime,
    '                                                        IncludeSeconds,
    '                                                        IncludeMilliseconds)

    'End Function

    Public Shared Function NormalizeDate(ByVal d As DateTime) As DateTime
        'function to set the date to today while retaining the original time...
        'use for comparing time ranges (like if a task starts at 8am, is emp available at 8am regardless of date)
        Try
            Return Convert.ToDateTime(Now.ToShortDateString() & " " & d.ToShortTimeString())
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function StartIsBeforeEnd(ByVal s1 As String, ByVal s2 As String) As Boolean
        Dim d1 As Date
        Dim d2 As Date
        If s1 = "" Or s2 = "" Then
            Return False
        End If
        If cGlobals.wvIsDate(s1) = False Or cGlobals.wvIsDate(s2) = False Then
            Return False
        End If
        Try
            d1 = cGlobals.wvCDate(s1)
        Catch ex As Exception
            Return False
        End Try
        Try
            d2 = cGlobals.wvCDate(s2)
        Catch ex As Exception
            Return False
        End Try
        Dim i As Integer = DateDiff(DateInterval.Day, d1, d2)
        If i >= 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Shared Function IsWeekendDay(ByVal TheDate As Date) As Boolean
        Try
            Select Case TheDate.DayOfWeek
                Case DayOfWeek.Saturday, DayOfWeek.Sunday
                    Return True
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GetWorkingDays(ByVal StartDate As String, ByVal EndDate As String) As Integer
        'NOTE: To get an employee's working days, use the db function: wvfn_get_emp_workday_count
        'This function simply gets work days M,T,W,R,F (excludes weekends)
        If cGlobals.wvIsDate(StartDate) = False Or cGlobals.wvIsDate(EndDate) = False Then
            Return 0
        Else
            Try
                Dim dStart As Date = CType(StartDate, Date)
                Dim dEnd As Date = CType(EndDate, Date)
                Dim i As Long = 0
                Dim daycounter As Integer = 0
                i = DateDiff(DateInterval.Day, dStart, dEnd)
                Dim currday As Date
                For j As Integer = 0 To i
                    currday = dStart.AddDays(CType(j, Double))
                    If currday.DayOfWeek <> DayOfWeek.Saturday And currday.DayOfWeek <> DayOfWeek.Sunday Then
                        daycounter += 1
                    End If
                Next
                Return daycounter
            Catch ex As Exception
                Return 0
            End Try
        End If
    End Function

    Public Shared Function GetTotalDays(ByVal StartDate As String, ByVal EndDate As String) As Integer
        If cGlobals.wvIsDate(StartDate) = False Or cGlobals.wvIsDate(EndDate) = False Then
            Return 0
        Else
            Try
                Dim dStart As Date = CType(StartDate, Date)
                Dim dEnd As Date = CType(EndDate, Date)
                Dim i As Long = 0
                Return DateDiff(DateInterval.Day, dStart, dEnd)
            Catch ex As Exception
                Return 0
            End Try
        End If
    End Function

    Public Shared Function FixRadTimePickerDate(ByRef tb As System.Web.UI.WebControls.TextBox, ByRef RTP As Telerik.Web.UI.RadTimePicker) As DateTime
        Try
            Dim TheCorrectDate As DateTime
            Dim StrRebuildTheDate As String
            If cGlobals.wvIsDate(tb.Text) = False Then
                Return Nothing
            Else
                StrRebuildTheDate = cGlobals.wvCDate(tb.Text).ToShortDateString() & " " & Convert.ToDateTime(RTP.SelectedDate).ToShortTimeString()
                Return Convert.ToDateTime(StrRebuildTheDate)
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function InvalidDateMessage() As String
        Dim sb As New StringBuilder
        With sb
            .Append("Invalid date.\n\n")
            .Append("Please provide the date in one of the following formats:\n")
            .Append("           090202                 mmddyy\n")
            .Append("           09022002             mmddyy\n")
            .Append("           09/02/02              mm/dd/yy\n")
            .Append("           09/02/2002          mm/dd/yyyy\n")
            .Append("           09-02-02               mm-dd-yy\n")
            .Append("           09-02-2002           mm-dd-yyyy\n\n")
        End With
        Return sb.ToString
    End Function

    Public Shared Function SetCurrentMonth(ByVal StartOfMonth As Boolean) As String
        If StartOfMonth = True Then
            Return CStr(Date.Now.Month) & "/1/" & CStr(Date.Now.Year)
        Else
            Return CStr(Date.Now.Month) & "/" & CStr(Date.DaysInMonth(Date.Now.Year, Date.Now.Month)) & "/" & CStr(Date.Now.Year)
        End If
    End Function

#End Region

#Region " Text/String Functions "

    Public Shared Function SessionId(ByVal UserCode As String, ByVal Password As String) As String
        Return AdvantageFramework.Security.Encryption.Encrypt(UserCode) & AdvantageFramework.Security.Encryption.Encrypt(Password) &
               AdvantageFramework.Security.Encryption.Encrypt(Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString())
    End Function

    Public Shared Function ParseClientIDPrefix(ByVal ControlClientId As String) As String
        Try
            Dim bufs() As String
            Dim ans As String
            If ControlClientId.IndexOf("_") > -1 Then
                bufs = ControlClientId.Split("_")
                ans = bufs(UBound(bufs))
                ans = ControlClientId.Replace("_" & ans, "_")
            Else
                ans = ControlClientId
            End If
            Return ans
        Catch ex As Exception
            Return ControlClientId
        End Try
    End Function

    Public Shared Function ParseNextToLastDot(ByVal buf As String) As String
        Dim bufs(), ans As String

        If buf.IndexOf(".") > 0 Then
            bufs = buf.Split(".")
            ans = bufs(UBound(bufs) - 1)
        End If

        Return ans
    End Function

    Public Shared Function ParseLastDot(ByVal buf As String) As String
        Dim bufs(), ans As String

        If buf.IndexOf(".") > 0 Then
            bufs = buf.Split(".")
            ans = bufs(UBound(bufs))
        Else
            ans = buf
        End If

        Return ans
    End Function

    Public Shared Function ParseLast(ByVal buf As String, ByVal Delimiter As String) As String
        Dim bufs(), ans As String

        If buf.IndexOf(Delimiter) > 0 Then
            bufs = buf.Split(Delimiter)
            ans = bufs(UBound(bufs))
        Else
            ans = buf
        End If

        Return ans
    End Function

    Public Shared Function CleanStringForSplit(ByRef OriginalString As String, ByVal Delimiter As String,
                                               Optional ByVal RemoveSpaces As Boolean = True, Optional ByVal RemoveDuplicates As Boolean = True,
                                               Optional ByVal RemoveTrailingDelim As Boolean = True, Optional ByVal RemoveEmptyItems As Boolean = True,
                                               Optional ByVal RemoveLineFeeds As Boolean = True) As String
        Try
            Dim str As String = OriginalString
            If str.Length > 0 Then
                If RemoveSpaces = True Then
                    str = str.Replace(" ", "")
                End If
                str = str.Replace(Delimiter & Delimiter, Delimiter)
                If RemoveDuplicates = True Then
                    str = RemoveDuplicatesFromString(str, Delimiter)
                End If
                If RemoveTrailingDelim = True Then
                    str = RemoveTrailingDelimiter(str, Delimiter)
                End If
                If RemoveEmptyItems = True Then
                    If RemoveSpaces = True Then
                        str = str.Replace(" ", "")
                    End If
                    str = str.Replace(Delimiter & Delimiter, Delimiter)
                    str = str.Replace(Delimiter & " " & Delimiter, Delimiter)
                End If
                If RemoveLineFeeds = True Then
                    str = str.Replace(Environment.NewLine, "").Replace(vbCrLf, "").Replace(vbCr, "").Replace(vbLf, "")
                End If
                Return str
            Else
                Return OriginalString
            End If
        Catch ex As Exception
            Return OriginalString
        End Try
    End Function

    Public Shared Function RemoveTrailingDelimiter(ByVal OriginalString As String, ByVal delimiter As String) As String
        Try
            OriginalString = RTrim(OriginalString)
            If OriginalString.EndsWith(delimiter) Then
                Return OriginalString.Substring(0, OriginalString.Length - 1)
            Else
                Return OriginalString
            End If
        Catch ex As Exception
            Return OriginalString
        End Try
    End Function

    Public Shared Function LineBreak(ByVal display As DisplayMedium) As String
        If display = DisplayMedium.web Then
            Return "<br />"
        Else
            Return "\n"
        End If
    End Function

    Public Shared Function RemoveDuplicatesFromString(ByVal OriginalString As String, ByVal Delimiter As String, Optional ByVal UseDelimiter As Boolean = False) As String
        Try
            Dim str As String = String.Empty
            Dim strHolder As String = String.Empty
            Dim strArr() As String
            strArr = OriginalString.Split(CType(Delimiter, Char))
            Dim arrList As New ArrayList
            For i As Integer = 0 To strArr.Length - 1
                If Not arrList.Contains(strArr(i)) Then
                    arrList.Add(strArr(i))
                End If
            Next
            For j As Integer = 0 To arrList.Count - 1
                If UseDelimiter = True Then
                    str &= arrList.Item(j).ToString() & Delimiter
                Else
                    str &= arrList.Item(j).ToString() & ","
                End If
            Next
            str = str.Replace(Delimiter & Delimiter, Delimiter)
            If str.EndsWith(Delimiter) Then
                str = str.Substring(0, str.Length - 1)
            End If
            Return str
        Catch ex As Exception
            Return OriginalString
        End Try
    End Function

    Public Shared Function IsLetter(ByVal val As String) As Boolean
        Dim idx As Integer
        Dim str As String
        Dim chars(3000) As Char

        str = val
        chars = str.ToCharArray()

        For idx = 0 To str.Length - 1
            If Not chars(idx).IsLetter(chars(idx)) Then
                Return False
            End If
        Next

        Return True

    End Function

    Public Shared Function ListBoxToString(ByVal lb As Telerik.Web.UI.RadListBox) As String
        Dim sb As New System.Text.StringBuilder
        Dim str As String = ""
        If lb.Items(0).Selected = True Then
            str = ""
        Else
            For i As Integer = 0 To lb.Items.Count - 1
                If i > 0 And lb.Items(i).Selected = True Then
                    With sb
                        .Append("'")
                        .Append(lb.Items(i).Value)
                        .Append("'")
                        .Append(",")
                    End With
                End If
            Next
            str = sb.ToString()
            str = MiscFN.CleanStringForSplit(str, ",")
        End If
        Return str
    End Function

#End Region

#Region " Data/Database-related Functions "

    Public Shared Function IsMvcActive() As Boolean
        Try

            Return System.Configuration.ConfigurationManager.AppSettings("MvcActive").ToString.ToLower = "true"

        Catch ex As Exception

            Return False

        End Try
    End Function

    Public Shared Function IsNTAuth() As Boolean
        Try
            Dim strAuthentication As String = System.Configuration.ConfigurationManager.AppSettings("Authentication")
            If strAuthentication = "Forms" Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    'Public Shared Function EnableBookmarks() As Boolean
    '    Try
    '        'Return CType(System.Configuration.ConfigurationManager.AppSettings("EnableBookmarks"), Boolean)

    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Public Shared Function IsClientPortal() As Boolean
        Try
            Dim Version As String = ""
            Dim VersionKeys() As String = Nothing
            Version = System.Configuration.ConfigurationManager.AppSettings("VCtrl")
            If Version <> "##DEV##" Then
                Version = AdvantageFramework.Security.DecryptVersionKey("VersionEncryptor2007", Version)
                VersionKeys = Version.Split("|")
                If VersionKeys(4).ToString = "1" Then
                    Return True
                Else
                    Return False
                End If
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function PivotTable(ByVal [source] As DataTable) As DataTable
        Dim dest As New DataTable("Pivoted" + [source].TableName)

        dest.Columns.Add(" ")

        Dim r As DataRow
        For Each r In [source].Rows
            dest.Columns.Add(r(0).ToString())
        Next r
        Dim i As Integer
        For i = 0 To ([source].Columns.Count - 1) - 1
            dest.Rows.Add(dest.NewRow())
        Next i

        For i = 0 To dest.Rows.Count - 1
            Dim c As Integer
            For c = 0 To dest.Columns.Count - 1
                If c = 0 Then
                    dest.Rows(i)(0) = [source].Columns((i + 1)).ColumnName
                Else
                    dest.Rows(i)(c) = [source].Rows((c - 1))((i + 1))
                End If
            Next c
        Next i
        dest.AcceptChanges()
        Return dest
    End Function 'PivotTable

    Public Shared Sub UpdateNullToZero(ByVal TableName As String, ByVal FieldName As String)
        Try
            Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                MyConn.Open()
                Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                Dim MyCmd As New SqlCommand("UPDATE " & TableName & " SET " & FieldName & " = 0 WHERE (" & FieldName & " IS NULL)", MyConn, MyTrans)
                Try
                    MyCmd.ExecuteNonQuery()
                    MyTrans.Commit()
                Catch ex As Exception
                    MyTrans.Rollback()
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function BoolToInt(ByVal TheBool As Boolean) As Integer
        Try
            If TheBool = True Then
                Return 1
            ElseIf TheBool = False Then
                Return 0
            End If
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Shared Function IntToBool(ByVal TheInt As Integer) As Boolean
        Try
            If TheInt = 1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function GetOneValue(ByVal TheSQL As String) As String
        Try
            Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                MyConn.Open()
                Dim MyCmd As New SqlCommand(TheSQL, MyConn)
                Try
                    Return CType(MyCmd.ExecuteScalar(), String)
                Catch ex As Exception
                    Return ""
                Finally
                    If MyConn.State = ConnectionState.Open Then MyConn.Close()
                End Try
            End Using
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

#Region " Controls Functions "

    Public Shared Function GetWeekString(ByRef chk As CheckBoxList) As String
        Try
            Dim sb As New System.Text.StringBuilder
            Dim HasSelections As Boolean = False
            With sb
                For i As Integer = 0 To chk.Items.Count - 1
                    If chk.Items(i).Selected = True Then
                        HasSelections = True
                        .Append(chk.Items(i).Value)
                        .Append(",")
                    End If
                Next
            End With
            Dim s As String = sb.ToString()
            If HasSelections = True Then
                Return MiscFN.CleanStringForSplit(s, ",")
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Shared Sub SetWeekCheckboxList(ByRef chk As CheckBoxList, ByVal DaysString As String)
        Try
            Dim ar() As String
            ar = DaysString.Split(",")
            For i As Integer = 0 To ar.Length - 1
                chk.Items.FindByValue(ar(i)).Selected = True
            Next
        Catch ex As Exception
        End Try
    End Sub


    Public Shared Sub SetListbox(ByRef TheListBox As Telerik.Web.UI.RadListBox, ByVal TheCSV_String As String)
        Try
            If TheListBox.Items.Count > 0 Then
                If TheCSV_String = "" Or TheCSV_String = "%" Or TheCSV_String.IndexOf(",") = -1 Then
                    TheListBox.SelectedIndex = 0
                Else
                    TheCSV_String = RemoveTrailingDelimiter(TheCSV_String, ",")
                    Dim ar() As String
                    ar = TheCSV_String.Split(",")
                    For o As Integer = 0 To ar.Length - 1
                        Try
                            TheListBox.FindItemByValue(ar(o)).Selected = True
                        Catch ex As Exception
                        End Try
                    Next
                End If
            Else
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Public Shared Sub LimitTextbox(ByRef TheTB As System.Web.UI.WebControls.TextBox, ByVal TheLimit As Integer)
        'TheTB.Attributes.Add("onkeyup", "javascript:limitText(this.form." & TheTB.ClientID & "," & TheLimit.ToString() & ");")
        'TheTB.Attributes.Add("onchange", "javascript:limitText(this.form." & TheTB.ClientID & "," & TheLimit.ToString() & ");")
        With TheTB.Attributes
            .Add("onkeyup", "limitText(this," & TheLimit & ");")
            .Add("onkeydown", "limitText(this," & TheLimit & ");")
        End With
    End Sub

    Public Shared Sub ClearOtherTextbox(ByRef The_Trigger_TB As System.Web.UI.WebControls.TextBox, ByRef The_Target_TB_To_Clear As System.Web.UI.WebControls.TextBox)

    End Sub

    Public Shared Sub SetFocus(ByVal control As System.Web.UI.Control)
        Dim sb As StringBuilder = New StringBuilder
        With sb
            .Append("" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "<script language='JavaScript'>" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("<!--" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("function SetFocus()" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("{" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("" & Microsoft.VisualBasic.Chr(9) & "document.")
            'Dim p As System.Web.UI.Control = control.Parent
            'While Not (TypeOf p Is System.Web.UI.HtmlControls.HtmlForm)
            '    p = p.Parent
            'End While
            '.Append(p.ClientID)
            '.Append("['")
            '.Append(control.UniqueID)
            '.Append("'].select();" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("forms[0]." & control.ClientID & ".select();" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("}" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("window.onload = SetFocus;" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("// -->" & Microsoft.VisualBasic.Chr(13) & "" & Microsoft.VisualBasic.Chr(10) & "")
            .Append("</script>")
        End With
        control.Page.ClientScript.RegisterClientScriptBlock(control.GetType, "SetFocus", sb.ToString())
    End Sub

    Public Shared Function NewLiteral(ByVal text As String) As Literal
        Dim lit As Literal
        lit = New Literal
        lit.Text = text
        Return lit
    End Function

    Public Shared Function IsEmptyTextbox(ByRef tb As System.Web.UI.WebControls.TextBox) As Boolean
        Dim str As String
        str = tb.Text.Replace(" ", "")
        str = str.Trim
        Try
            If str.Length = 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Shared Function FindControlRecursive(ByVal Root As System.Web.UI.Control, ByVal Id As String) As System.Web.UI.Control
        If Root.ID = Id Then
            Return Root
        End If
        For Each Ctl As System.Web.UI.Control In Root.Controls
            Dim FoundCtl As System.Web.UI.Control = FindControlRecursive(Ctl, Id)
            If Not (FoundCtl Is Nothing) Then
                Return FoundCtl
            End If
        Next
        Return Nothing
    End Function

    Public Shared Function NewListItem(ByVal TheText As String, ByVal TheValue As String) As Telerik.Web.UI.RadComboBoxItem
        Dim itm As New Telerik.Web.UI.RadComboBoxItem
        With itm
            .Text = TheText
            .Value = TheValue
        End With
        Return itm
    End Function
#End Region

#Region " Web/HTML/Javascript/CSS "

    Public Shared Sub ResponseRedirect(ByVal URL As String, Optional ByVal EndResponse As Boolean = False)
        Try
            System.Web.HttpContext.Current.Response.Redirect(URL, EndResponse)
            If EndResponse = False Then System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest()
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function JavascriptSafe(ByVal StringToEncode As String) As String

        Try

            Return HttpUtility.JavaScriptStringEncode(StringToEncode)
            'Dim Sanitizer As New Ganss.XSS.HtmlSanitizer
            'Sanitizer.AllowDataAttributes = True
            'Sanitizer.AllowedAttributes.Add("class")
            'Return Sanitizer.Sanitize(StringToEncode)

            ''All WV messages are now HTML, should not need to encode to js safe
            'Return HttpUtility.HtmlEncode(StringToEncode)

        Catch ex As Exception
            Return StringToEncode
        End Try

    End Function

    Public Shared Function HTML_AppendAlertId(ByVal AlertId As Integer, ByVal HexColor As String) As String
        Dim sb As New System.Text.StringBuilder
        With sb
            .Append("<font color=""#" & HexColor & """ bgcolor=""#" & HexColor & """>")
            .Append("##")
            .Append("LISTENER_ALERT_ID:")
            .Append(AlertId.ToString())
            .Append("##")
            .Append("</font>")
            '.Append(Environment.NewLine())
        End With
        Return sb.ToString()
    End Function

    Public Shared Function BrowserTypeIs(ByVal WhatAreYouLookingFor As Browser_Types) As Boolean
        Select Case WhatAreYouLookingFor
            Case Browser_Types.IE
                If HttpContext.Current.Request.Browser.Type.ToString().IndexOf("IE6") > -1 Or
                    HttpContext.Current.Request.Browser.Type.ToString().IndexOf("IE7") > -1 Or
                     HttpContext.Current.Request.Browser.Type.ToString().IndexOf("IE8") > -1 Or
                   HttpContext.Current.Request.Browser.Type.ToString().IndexOf("IE9") > -1 Then
                    Return True
                Else
                    Return False
                End If
            Case Browser_Types.Safari
                If HttpContext.Current.Request.Browser.Type.ToString().IndexOf("Safari") > -1 Then
                    Return True
                Else
                    Return False
                End If
            Case Browser_Types.Firefox
                If HttpContext.Current.Request.Browser.Type.ToString().IndexOf("Firefox") > -1 Then
                    Return True
                Else
                    Return False
                End If
            Case Browser_Types.Chrome
                If HttpContext.Current.Request.Browser.Type.ToString().IndexOf("Chrome") > -1 Or HttpContext.Current.Request.Browser.Type.ToString.IndexOf("Desktop") > -1 Then
                    Return True
                Else
                    Return False
                End If
            Case Browser_Types.Opera
                If HttpContext.Current.Request.Browser.Type.ToString().IndexOf("Opera") > -1 Then
                    Return True
                Else
                    Return False
                End If
        End Select
    End Function

    Public Shared Function IsValidRequest(ByVal TheURL As String) As Boolean
        Dim req As HttpWebRequest = WebRequest.Create(TheURL)
        Try
            Dim resp As HttpWebResponse = req.GetResponse()
            Return True
        Catch WebEx As WebException
            Return False
        Catch Ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function HTMLPad(ByVal str As String, ByVal TotalLengthToPad As Integer, Optional ByVal LeftPad As Boolean = True) As String
        Dim LengthToPad As Integer = TotalLengthToPad - str.Length
        Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim i As Integer = 1
        Try
            If LengthToPad <= 0 Then
                Return str
            Else
                If LeftPad = True Then
                    For i = 1 To LengthToPad
                        sb.Append("&nbsp;")
                    Next
                    sb.Append(str)
                Else
                    sb.Append(str)
                    For i = 1 To LengthToPad
                        sb.Append("&nbsp;")
                    Next
                End If
            End If
            Return sb.ToString
        Catch ex As Exception
            Err.Raise(Err.Number, "Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
        Finally
        End Try
    End Function

    Public Shared Function GetThePath(ByVal parent As System.Web.UI.Page) As String
        Try
            Return parent.Server.MapPath("").ToString()
        Catch ex As Exception
            Return "Err: " & ex.Message.ToString
        End Try
    End Function

    Public Shared Function RemoveInputTag(ByVal Str As String) As String
        Try
            Dim temp As String = Str
            Dim Rebuild As String = ""

            Dim iStart As Integer = temp.IndexOf("<input type=""submit""")
            Dim iEnd As Integer = temp.IndexOf("/>", iStart) + 2


            Rebuild = temp.Substring(0, iStart) & temp.Substring(iEnd, temp.Length - iEnd)


            Return Rebuild
        Catch ex As Exception
            Return Str
        End Try
    End Function

    Public Shared Function SetJavascriptAlertTimer() As String
        Try
            Dim TimeOut As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("AlertRefresh"), Integer)
            If TimeOut > 0 Then
                Return "var AlertNotifyInterval = self.setInterval('OpenAlertNotifiy()', " & TimeOut.ToString() & ");"
            Else
                Return ""
            End If
        Catch ex As Exception
            Return ""
        End Try
    End Function

#End Region

#Region " For Deletion "

#End Region

#Region " telerik Controls "

    Public Shared Sub RadgridSavePageSize(ByRef grid As Telerik.Web.UI.RadGrid, Optional ByVal PageSize As Integer = 15)
        Try
            grid.AllowPaging = True
            grid.PageSize = PageSize
            grid.MasterTableView.PageSize = PageSize
            MiscFN.SavePageSize(grid.ID, PageSize)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub RadgridSetPageSize(ByRef grid As Telerik.Web.UI.RadGrid)
        Try
            grid.AllowPaging = True
            grid.PageSize = MiscFN.LoadPageSize(grid.ID)
            grid.MasterTableView.PageSize = MiscFN.LoadPageSize(grid.ID)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function LoadPageSize(ByVal GridName As String) As Integer
        Try
            Dim PageSize = 15

            GridName = GridName.Trim()
            If GridName <> "" Then
                Dim oAppVars As New cAppVars(cAppVars.Application.GRID_PAGE_SIZE)
                oAppVars.getAllAppVars()
                If IsNumeric(oAppVars.getAppVar(GridName)) = True Then
                    PageSize = CType(oAppVars.getAppVar(GridName), Integer)
                End If
            End If

            If PageSize < 0 Then PageSize = 15

            Return PageSize

        Catch ex As Exception
        End Try
    End Function

    Public Shared Function SavePageSize(ByVal GridName As String, ByVal PageSize As Integer) As Boolean
        If PageSize < 0 Then PageSize = 0
        Dim oAppVars As New cAppVars(cAppVars.Application.GRID_PAGE_SIZE)
        With oAppVars
            .getAllAppVars()
            .setAppVar(GridName, PageSize, "Integer")
            .SaveAllAppVars()
        End With
        Return True
    End Function

    ''Public Shared Sub RadgridSaveSettings(ByRef grid As Telerik.Web.UI.RadGrid)
    ''    Try
    ''        Dim GridSettings As New AdvantageFramework.Web.Presentation.Controls.GridSettingsPersister(grid)
    ''        HttpContext.Current.Response.Cookies(grid.ID & "Settings").Value = GridSettings.SaveSettings()
    ''        HttpContext.Current.Response.Cookies(grid.ID & "Settings").Expires = DateTime.Now.AddDays(30)
    ''    Catch ex As Exception
    ''    End Try
    ''End Sub

    ''Public Shared Sub RadgridLoadSettings(ByRef grid As Telerik.Web.UI.RadGrid)
    ''    Try
    ''        If HttpContext.Current.Request.Cookies(grid.ID & "Settings") IsNot Nothing _
    ''            AndAlso HttpContext.Current.Request.Cookies(grid.ID & "Settings").Value IsNot Nothing Then
    ''            Dim GridSettings As New AdvantageFramework.Web.Presentation.Controls.GridSettingsPersister(grid)
    ''            GridSettings.LoadSettings(HttpContext.Current.Request.Cookies(grid.ID & "Settings").Value.ToString())
    ''        End If
    ''    Catch ex As Exception
    ''    End Try
    ''End Sub

    Public Shared Sub RadWindowsClose(ByRef TheWindowManager As Telerik.Web.UI.RadWindowManager)
        Try
            If TheWindowManager.Windows.Count > 0 Then
                For i As Integer = 0 To TheWindowManager.Windows.Count - 1
                    TheWindowManager.Windows(i).VisibleOnPageLoad = False
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub SetTelerikAjaxTimerInterval(ByRef TheAjaxTimer As System.Web.UI.Timer)
        Try
            Dim i As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("AlertRefresh"), Integer)
            If i = -1 Or i < 3 Then
                With TheAjaxTimer
                    .Interval = -1
                    .Enabled = False
                    '.Stop()
                End With
            Else
                With TheAjaxTimer
                    .Interval = i
                End With
            End If
        Catch ex As Exception
            With TheAjaxTimer
                .Interval = -1
                .Enabled = False
                '.Stop()
            End With
        End Try
    End Sub

    Public Shared Sub SetAjaxTimerInterval(ByRef TheAjaxTimer As System.Web.UI.Timer)
        Try
            Dim i As Integer = CType(System.Configuration.ConfigurationManager.AppSettings("AlertRefresh"), Integer)
            If i = -1 Or i < 3 Then
                With TheAjaxTimer
                    .Interval = -1
                    .Enabled = False
                    '.InitialDelayTime = -1
                    '.Stop()
                End With
            Else
                With TheAjaxTimer
                    .Interval = i
                    .Enabled = True
                    '.InitialDelayTime = i
                End With
            End If
        Catch ex As Exception
            With TheAjaxTimer
                .Interval = -1
                .Enabled = False
                '.InitialDelayTime = -1
                '.Stop()
            End With
        End Try
    End Sub

    Public Shared Function ValidDate(ByVal RadDatePicker As Telerik.Web.UI.RadDatePicker, Optional AllowNull As Boolean = False) As Boolean
        Try
            If RadDatePicker.SelectedDate.HasValue = True Then
                Return True
            End If
            Dim s As String = RadDatePicker.DateInput.Text.Trim()
            If s = "" Then
                If AllowNull = True Then
                    Return True
                Else
                    Return False
                End If
            Else
                If cGlobals.wvIsDate(s) = True Then
                    RadDatePicker.SelectedDate = CType(s, Date)
                    Return True
                Else
                    RadDatePicker.SelectedDate = Nothing
                    Return False
                End If
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Shared Function EmptyDate(ByVal RadDatePicker As Telerik.Web.UI.RadDatePicker) As Boolean
        Try
            If RadDatePicker.SelectedDate.HasValue = False Or
                RadDatePicker.DateInput.Text.Trim() = "" Then
                Return True
            End If
            Dim val As Date = Nothing
            Try
                If MiscFN.ValidDate(RadDatePicker) = True Then
                    Return False
                Else
                    Return True
                End If
            Catch ex As Exception
                Return True
            End Try
        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Shared Function ValidDateRange(ByVal RadDatePickerStart As Telerik.Web.UI.RadDatePicker, ByVal RadDatePickerEnd As Telerik.Web.UI.RadDatePicker, Optional ByVal FixStartBeforeEnd As Boolean = True) As Boolean
        If MiscFN.ValidDate(RadDatePickerStart) = True And MiscFN.ValidDate(RadDatePickerEnd) = False Then
            Return False
        ElseIf MiscFN.ValidDate(RadDatePickerStart) = False And MiscFN.ValidDate(RadDatePickerEnd) = True Then
            Return False
        ElseIf MiscFN.ValidDate(RadDatePickerStart) = False And MiscFN.ValidDate(RadDatePickerEnd) = False Then
            'maybe should return true if both are blank? (Handle non-required date ranges)
            Return False
        End If

        Dim d1 As Date = RadDatePickerStart.SelectedDate
        Dim d2 As Date = RadDatePickerEnd.SelectedDate
        Dim i As Integer = DateDiff(DateInterval.Day, d1, d2)
        If i >= 0 Then
            Return True
        Else
            If FixStartBeforeEnd = True Then
                With RadDatePickerStart
                    .SelectedDate = d2
                    .DateInput.Text = d2.ToShortDateString()
                End With
                With RadDatePickerEnd
                    .SelectedDate = d1
                    .DateInput.Text = d1.ToShortDateString()
                End With
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Shared Sub RadComboBoxSetIndex(ByRef RadComboBox As Telerik.Web.UI.RadComboBox, ByVal ListItemTextValue As String, ByVal FindTextInsteadOfValue As Boolean, Optional ByVal ForceOverride As Boolean = False)
        Try
            If Not RadComboBox Is Nothing Then
                Try

                    If ListItemTextValue <> "" Then

                        With RadComboBox
                            .SelectedIndex = -1
                            .ClearSelection()
                        End With

                        Dim FoundItem As Telerik.Web.UI.RadComboBoxItem
                        If FindTextInsteadOfValue = True Then
                            FoundItem = RadComboBox.FindItemByText(ListItemTextValue)
                        Else
                            FoundItem = RadComboBox.FindItemByValue(ListItemTextValue)
                        End If

                        If Not FoundItem Is Nothing Then
                            FoundItem.Selected = True
                        Else
                            If ForceOverride = True Then
                                RadComboBox.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[" & ListItemTextValue & "] **", ListItemTextValue))
                                RadComboBox.FindItemByValue(ListItemTextValue).Selected = True
                            End If
                        End If

                    End If

                Catch ex As Exception
                    RadComboBox.SelectedIndex = -1
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub RadListBoxSetIndex(ByRef RadListBox As Telerik.Web.UI.RadListBox, ByVal ListItemTextValue As String, ByVal FindTextInsteadOfValue As Boolean, Optional ByVal ForceOverride As Boolean = False)
        Try
            If Not RadListBox Is Nothing Then
                Try

                    If ListItemTextValue <> "" Then

                        With RadListBox
                            .SelectedIndex = -1
                            .ClearSelection()
                        End With

                        Dim FoundItem As Telerik.Web.UI.RadListBoxItem
                        If FindTextInsteadOfValue = True Then
                            FoundItem = RadListBox.FindItemByText(ListItemTextValue)
                        Else
                            FoundItem = RadListBox.FindItemByValue(ListItemTextValue)
                        End If

                        If Not FoundItem Is Nothing Then
                            FoundItem.Selected = True
                        Else
                            If ForceOverride = True Then
                                RadListBox.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem(ListItemTextValue & " **", ListItemTextValue))
                                RadListBox.FindItemByValue(ListItemTextValue).Selected = True
                            End If
                        End If

                    End If

                Catch ex As Exception
                    RadListBox.SelectedIndex = -1
                End Try
            End If
        Catch ex As Exception
        End Try
    End Sub

    <CLSCompliant(False)>
    Public Shared Function SignOutOfWebvantage(ByRef SecuritySession As AdvantageFramework.Security.Session, ByRef ErrorMessage As String) As Boolean

        Dim Success As Boolean = False

        ErrorMessage = String.Empty

        Try

            If HttpContext.Current.Session("NewLicenseKey") IsNot Nothing AndAlso HttpContext.Current.Session("NewLicenseKey") = True AndAlso
                HttpContext.Current.Session("CurrentSessionId") IsNot Nothing AndAlso SecuritySession IsNot Nothing Then

                If MiscFN.IsClientPortal = True Then

                    If AdvantageFramework.Security.LicenseKey.Clear(SecuritySession, "", HttpContext.Current.Session("CurrentSessionId"), "") = True Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                                DbContext.Database.ExecuteSqlCommand("UPDATE dbo.CP_USER WITH(ROWLOCK) SET WEB_ID = NULL WHERE USER_GUID = " & SecuritySession.ClientPortalUser.ID.ToString)

                            End Using

                        Catch ex As Exception
                        End Try

                    End If

                Else

                    Webvantage.SignalR.Classes.ChatHub.SignOut(SecuritySession, SecuritySession.UserCode, True)

                    If AdvantageFramework.Security.LicenseKey.Clear(SecuritySession, "", HttpContext.Current.Session("CurrentSessionId"), True, "") = True Then

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                                DbContext.Database.ExecuteSqlCommand("UPDATE dbo.SEC_USER WITH(ROWLOCK) SET WEB_ID = NULL WHERE SEC_USER_ID = " & SecuritySession.User.ID)

                            End Using

                        Catch ex As Exception
                        End Try

                    End If

                End If

            Else

                Try

                    SecuritySession.UnregisterSecuritySession(HttpContext.Current.Session("CurrentSessionId"))

                Catch ex As Exception
                End Try

            End If

            cSecurity.DeleteCacheDependencyFile(HttpContext.Current.Session("CurrentSessionId"))

            AdvantageFramework.Security.SetUserLogoutAuditRecord(SecuritySession)

            System.Web.Security.FormsAuthentication.SignOut()
            ErrorMessage = String.Empty
            Success = True

        Catch ex As Exception
            ErrorMessage = ex.Message.ToString
            Success = False
        End Try

        Return Success

    End Function

#End Region


End Class

'http://support.microsoft.com/kb/306158
Public Class AliasAccount
    Private Const LOGON32_PROVIDER_DEFAULT As Integer = 0
    Private Const LOGON32_LOGON_INTERACTIVE As Integer = 2
    Private Const LOGON32_LOGON_NETWORK As Integer = 3
    Private Const LOGON32_LOGON_BATCH As Integer = 4
    Private Const LOGON32_LOGON_SERVICE As Integer = 5
    Private Const LOGON32_LOGON_UNLOCK As Integer = 7
    Private Const LOGON32_LOGON_NETWORK_CLEARTEXT As Integer = 8
    Private Const LOGON32_LOGON_NEW_CREDENTIALS As Integer = 9
    Private Shared ImpersonationContext As WindowsImpersonationContext

    Public Function CheckNTAuthentication() As Boolean
        Try
            Dim strAuthentication As String = System.Configuration.ConfigurationManager.AppSettings("Authentication")
            If strAuthentication = "Forms" Then
                CheckNTAuthentication = False
            Else
                CheckNTAuthentication = True
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overloads Shared Function BeginImpersonation(ByVal strUserName As String,
             ByVal strDomain As String, ByVal strPassword As String) As Boolean
        Try
            'If CheckNTAuthentication() = False Then Exit Function
            Dim token As IntPtr = IntPtr.Zero
            Dim tokenDuplicate As IntPtr = IntPtr.Zero
            Dim tempWindowsIdentity As WindowsIdentity
            BeginImpersonation = False

            If RevertToSelf() Then
                If LogonUserA(strUserName, strDomain, strPassword, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, token) <> 0 Then
                    If DuplicateToken(token, 2, tokenDuplicate) <> 0 Then
                        tempWindowsIdentity = New WindowsIdentity(tokenDuplicate)
                        ImpersonationContext = tempWindowsIdentity.Impersonate()
                        If Not ImpersonationContext Is Nothing Then
                            BeginImpersonation = True
                        End If
                    Else
                        Dim win32ErrorNumber As Long = System.Runtime.InteropServices.Marshal.GetLastWin32Error()
                        Throw New ImpersonationException(win32ErrorNumber, GetErrorMessage(win32ErrorNumber), strUserName, strDomain)
                    End If
                End If
            End If

            If Not tokenDuplicate.Equals(IntPtr.Zero) Then
                CloseHandle(tokenDuplicate)
            End If
            If Not token.Equals(IntPtr.Zero) Then
                CloseHandle(token)
            End If
        Catch ex As Exception
        End Try
    End Function

    Public Overloads Shared Function BeginImpersonation() As Boolean
        Try
            'If CheckNTAuthentication() = False Then Exit Function
            Dim RepositorySecuritySettings As New vDocumentRepositorySettings(HttpContext.Current.Session("ConnString"))
            RepositorySecuritySettings.LoadAll()
            Dim UserDomain As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_DOMAIN
            Dim UserName As String = RepositorySecuritySettings.DOC_REPOSITORY_USER_NAME

            Dim UserPassword = AdvantageFramework.Security.Encryption.Decrypt(RepositorySecuritySettings.DOC_REPOSITORY_USER_PASSWORD)
            Dim Path = RepositorySecuritySettings.DOC_REPOSITORY_PATH


            If UserName.Trim() = "" Then Exit Function

            BeginImpersonation(UserName, UserDomain, UserPassword)

        Catch ex As Exception
        End Try
    End Function

    Public Overloads Shared Sub EndImpersonation()
        Try
            'If CheckNTAuthentication() = False Then Exit Sub
            ImpersonationContext.Dispose()
        Catch ex As Exception
        End Try
    End Sub

    Public Overloads Shared Sub EndImpersonation(ByVal OrigIdent As System.Security.Principal.WindowsIdentity)
        Try
            'If CheckNTAuthentication() = False Then Exit Sub
            ImpersonationContext.Dispose()
        Catch ex As Exception
        End Try
    End Sub

#Region "Exception Class"
    Public Class ImpersonationException
        Inherits System.Exception

        Public ReadOnly win32ErrorNumber As Integer

        Public Sub New(ByVal win32ErrorNumber As Integer, ByVal msg As String, ByVal username As String, ByVal domainname As String)
            MyBase.New(String.Format("Impersonation of {1}\{0} failed! [{2}] {3}", username, domainname, win32ErrorNumber, msg))
            Me.win32ErrorNumber = win32ErrorNumber
        End Sub
    End Class
#End Region

#Region "External Declarations and Helpers"


    Declare Function LogonUserA Lib "advapi32.dll" (
                            ByVal lpszUsername As String,
                            ByVal lpszDomain As String,
                            ByVal lpszPassword As String,
                            ByVal dwLogonType As Integer,
                            ByVal dwLogonProvider As Integer,
                            ByRef phToken As IntPtr) As Integer

    Declare Auto Function DuplicateToken Lib "advapi32.dll" (
                            ByVal ExistingTokenHandle As IntPtr,
                            ByVal ImpersonationLevel As Integer,
                            ByRef DuplicateTokenHandle As IntPtr) As Integer

    Declare Auto Function RevertToSelf Lib "advapi32.dll" () As Long

    Declare Auto Function CloseHandle Lib "kernel32.dll" (ByVal handle As IntPtr) As Long

    Private Declare Auto Function LogonUser Lib "advapi32.dll" (ByVal lpszUsername As [String],
            ByVal lpszDomain As [String], ByVal lpszPassword As [String],
            ByVal dwLogonType As Integer, ByVal dwLogonProvider As Integer,
            ByRef phToken As IntPtr) As Boolean



    <System.Runtime.InteropServices.DllImport("kernel32.dll")>
    Private Shared Function FormatMessage(ByVal dwFlags As Integer, ByRef lpSource As IntPtr,
            ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByRef lpBuffer As [String],
            ByVal nSize As Integer, ByRef Arguments As IntPtr) As Integer
    End Function


    Private Shared Function GetErrorMessage(ByVal errorCode As Integer) As String
        Dim FORMAT_MESSAGE_ALLOCATE_BUFFER As Integer = &H100
        Dim FORMAT_MESSAGE_IGNORE_INSERTS As Integer = &H200
        Dim FORMAT_MESSAGE_FROM_SYSTEM As Integer = &H1000

        Dim messageSize As Integer = 255
        Dim lpMsgBuf As String
        Dim dwFlags As Integer = FORMAT_MESSAGE_ALLOCATE_BUFFER Or FORMAT_MESSAGE_FROM_SYSTEM Or FORMAT_MESSAGE_IGNORE_INSERTS

        Dim ptrlpSource As IntPtr = IntPtr.Zero
        Dim prtArguments As IntPtr = IntPtr.Zero

        Dim retVal As Integer = FormatMessage(dwFlags, ptrlpSource, errorCode, 0, lpMsgBuf, messageSize, prtArguments)
        If 0 = retVal Then
            Throw New System.Exception("Failed to format message for error code " + errorCode.ToString() + ". ")
        End If

        Return lpMsgBuf
    End Function

#End Region

End Class

Public Class Standard_Deviation

    Private Function SafeDivide(ByVal dbl1 As Double, ByVal dbl2 As Double) As Double
        If (dbl1 = 0) Or (dbl2 = 0) Then Return 0 Else Return dbl1 / dbl2
    End Function

    Private Function Average(ByVal dblData As Double()) As Double
        Dim DataTotal As Double = 0
        For i As Integer = 0 To dblData.Length - 1
            DataTotal += dblData(i)
        Next
        Return SafeDivide(DataTotal, dblData.Length)
    End Function

    Public Function CalculateStandardDeviation(ByVal dblData As Double()) As Double

        Dim dblDataAverage As Double = 0
        Dim TotalVariance As Double = 0
        If dblData.Length = 0 Then Return 0
        dblDataAverage = Average(dblData)
        For i As Integer = 0 To dblData.Length - 1
            TotalVariance += Math.Pow(dblData(i) - dblDataAverage, 2)
        Next
        Return Math.Sqrt(SafeDivide(TotalVariance, dblData.Length))
    End Function

End Class

Public Class MimeTypes
    Public Shared contentTypes As Dictionary(Of String, String)

    Public Shared Sub InitializeMimeTypes()
        contentTypes = New Dictionary(Of String, String)
        With contentTypes
            .Add("3dm", "x-world/x-3dmf")
            .Add("3dmf", "x-world/x-3dmf")
            .Add("a", "application/octet-stream")
            .Add("aab", "application/x-authorware-bin")
            .Add("aam", "application/x-authorware-map")
            .Add("aas", "application/x-authorware-seg")
            .Add("abc", "text/vnd.abc")
            .Add("acgi", "text/html")
            .Add("afl", "video/animaflex")
            .Add("ai", "application/postscript")
            .Add("aif", "audio/aiff")
            .Add("aifc", "audio/aiff")
            .Add("aiff", "audio/aiff")
            .Add("aim", "application/x-aim")
            .Add("aip", "text/x-audiosoft-intra")
            .Add("ani", "application/x-navi-animation")
            .Add("aos", "application/x-nokia-9000-communicator-add-on-software")
            .Add("aps", "application/mime")
            .Add("arc", "application/octet-stream")
            .Add("arj", "application/arj")
            .Add("art", "image/x-jg")
            .Add("asf", "video/x-ms-asf")
            .Add("asm", "text/x-asm")
            .Add("asp", "text/asp")
            .Add("asx", "application/x-mplayer2")
            .Add("au", "audio/basic")
            .Add("avi", "video/avi")
            .Add("avs", "video/avs-video")
            .Add("bcpio", "application/x-bcpio")
            .Add("bin", "application/octet-stream")
            .Add("bm", "image/bmp")
            .Add("bmp", "image/bmp")
            .Add("boo", "application/book")
            .Add("book", "application/book")
            .Add("boz", "application/x-bzip2")
            .Add("bsh", "application/x-bsh")
            .Add("bz", "application/x-bzip")
            .Add("bz2", "application/x-bzip2")
            .Add("c", "text/plain")
            .Add("c++", "text/plain")
            .Add("cat", "application/vnd.ms-pki.seccat")
            .Add("cc", "text/plain")
            .Add("ccad", "application/clariscad")
            .Add("cco", "application/x-cocoa")
            .Add("cdf", "application/cdf")
            .Add("cer", "application/pkix-cert")
            .Add("cha", "application/x-chat")
            .Add("chat", "application/x-chat")
            .Add("class", "application/java")
            .Add("com", "application/octet-stream")
            .Add("conf", "text/plain")
            .Add("cpio", "application/x-cpio")
            .Add("cpp", "text/x-c")
            .Add("cpt", "application/x-cpt")
            .Add("crl", "application/pkcs-crl")
            .Add("css", "text/css")
            .Add("def", "text/plain")
            .Add("der", "application/x-x509-ca-cert")
            .Add("dif", "video/x-dv")
            .Add("dir", "application/x-director")
            .Add("dl", "video/dl")
            .Add("doc", "application/msword")
            .Add("dot", "application/msword")
            .Add("dp", "application/commonground")
            .Add("drw", "application/drafting")
            .Add("dump", "application/octet-stream")
            .Add("dv", "video/x-dv")
            .Add("dvi", "application/x-dvi")
            .Add("dwf", "drawing/x-dwf (old)")
            .Add("dwg", "application/acad")
            .Add("dxf", "application/dxf")
            .Add("eps", "application/postscript")
            .Add("es", "application/x-esrehber")
            .Add("etx", "text/x-setext")
            .Add("evy", "application/envoy")
            .Add("exe", "application/octet-stream")
            .Add("f", "text/plain")
            .Add("f90", "text/x-fortran")
            .Add("fdf", "application/vnd.fdf")
            .Add("fif", "image/fif")
            .Add("fli", "video/fli")
            .Add("for", "text/x-fortran")
            .Add("fpx", "image/vnd.fpx")
            .Add("g", "text/plain")
            .Add("g3", "image/g3fax")
            .Add("gif", "image/gif")
            .Add("gl", "video/gl")
            .Add("gsd", "audio/x-gsm")
            .Add("gtar", "application/x-gtar")
            .Add("gz", "application/x-compressed")
            .Add("h", "text/plain")
            .Add("help", "application/x-helpfile")
            .Add("hgl", "application/vnd.hp-hpgl")
            .Add("hh", "text/plain")
            .Add("hlp", "application/x-winhelp")
            .Add("htc", "text/x-component")
            .Add("htm", "text/html")
            .Add("html", "text/html")
            .Add("htmls", "text/html")
            .Add("htt", "text/webviewhtml")
            .Add("htx", "text/html")
            .Add("ice", "x-conference/x-cooltalk")
            .Add("ico", "image/x-icon")
            .Add("idc", "text/plain")
            .Add("ief", "image/ief")
            .Add("iefs", "image/ief")
            .Add("iges", "application/iges")
            .Add("igs", "application/iges")
            .Add("ima", "application/x-ima")
            .Add("imap", "application/x-httpd-imap")
            .Add("inf", "application/inf")
            .Add("ins", "application/x-internett-signup")
            .Add("ip", "application/x-ip2")
            .Add("isu", "video/x-isvideo")
            .Add("it", "audio/it")
            .Add("iv", "application/x-inventor")
            .Add("ivr", "i-world/i-vrml")
            .Add("ivy", "application/x-livescreen")
            .Add("jam", "audio/x-jam")
            .Add("jav", "text/plain")
            .Add("java", "text/plain")
            .Add("jcm", "application/x-java-commerce")
            .Add("jfif", "image/jpeg")
            .Add("jfif-tbnl", "image/jpeg")
            .Add("jpe", "image/jpeg")
            .Add("jpeg", "image/jpeg")
            .Add("jpg", "image/jpeg")
            .Add("jps", "image/x-jps")
            .Add("js", "application/x-javascript")
            .Add("jut", "image/jutvision")
            .Add("kar", "audio/midi")
            .Add("ksh", "application/x-ksh")
            .Add("la", "audio/nspaudio")
            .Add("lam", "audio/x-liveaudio")
            .Add("latex", "application/x-latex")
            .Add("lha", "application/lha")
            .Add("lhx", "application/octet-stream")
            .Add("list", "text/plain")
            .Add("lma", "audio/nspaudio")
            .Add("log", "text/plain")
            .Add("lsp", "application/x-lisp")
            .Add("lst", "text/plain")
            .Add("lsx", "text/x-la-asf")
            .Add("ltx", "application/x-latex")
            .Add("lzh", "application/octet-stream")
            .Add("lzx", "application/lzx")
            .Add("m", "text/plain")
            .Add("m1v", "video/mpeg")
            .Add("m2a", "audio/mpeg")
            .Add("m2v", "video/mpeg")
            .Add("m3u", "audio/x-mpequrl")
            .Add("man", "application/x-troff-man")
            .Add("map", "application/x-navimap")
            .Add("mar", "text/plain")
            .Add("mbd", "application/mbedlet")
            .Add("mc$", "application/x-magic-cap-package-1.0")
            .Add("mcd", "application/mcad")
            .Add("mcf", "image/vasa")
            .Add("mcp", "application/netmc")
            .Add("me", "application/x-troff-me")
            .Add("mht", "message/rfc822")
            .Add("mhtml", "message/rfc822")
            .Add("mid", "audio/midi")
            .Add("midi", "audio/midi")
            .Add("mif", "application/x-frame")
            .Add("mime", "message/rfc822")
            .Add("mjf", "audio/x-vnd.audioexplosion.mjuicemediafile")
            .Add("mjpg", "video/x-motion-jpeg")
            .Add("mm", "application/base64")
            .Add("mme", "application/base64")
            .Add("mod", "audio/mod")
            .Add("moov", "video/quicktime")
            .Add("mov", "video/quicktime")
            .Add("movie", "video/x-sgi-movie")
            .Add("mp2", "audio/mpeg")
            .Add("mp3", "audio/mpeg3")
            .Add("mpa", "audio/mpeg")
            .Add("mpc", "application/x-project")
            .Add("mpe", "video/mpeg")
            .Add("mpeg", "video/mpeg")
            .Add("mpg", "video/mpeg")
            .Add("mpga", "audio/mpeg")
            .Add("mpp", "application/vnd.ms-project")
            .Add("mpt", "application/x-project")
            .Add("mpv", "application/x-project")
            .Add("mpx", "application/x-project")
            .Add("mrc", "application/marc")
            .Add("ms", "application/x-troff-ms")
            .Add("mv", "video/x-sgi-movie")
            .Add("my", "audio/make")
            .Add("mzz", "application/x-vnd.audioexplosion.mzz")
            .Add("nap", "image/naplps")
            .Add("naplps", "image/naplps")
            .Add("nc", "application/x-netcdf")
            .Add("ncm", "application/vnd.nokia.configuration-message")
            .Add("nif", "image/x-niff")
            .Add("niff", "image/x-niff")
            .Add("nix", "application/x-mix-transfer")
            .Add("nsc", "application/x-conference")
            .Add("nvd", "application/x-navidoc")
            .Add("o", "application/octet-stream")
            .Add("oda", "application/oda")
            .Add("omc", "application/x-omc")
            .Add("omcd", "application/x-omcdatamaker")
            .Add("omcr", "application/x-omcregerator")
            .Add("p", "text/x-pascal")
            .Add("p10", "application/pkcs10")
            .Add("p12", "application/pkcs-12")
            .Add("p7a", "application/x-pkcs7-signature")
            .Add("p7c", "application/pkcs7-mime")
            .Add("pas", "text/pascal")
            .Add("pbm", "image/x-portable-bitmap")
            .Add("pcl", "application/vnd.hp-pcl")
            .Add("pct", "image/x-pict")
            .Add("pcx", "image/x-pcx")
            .Add("pdf", "application/pdf")
            .Add("pfunk", "audio/make")
            .Add("pgm", "image/x-portable-graymap")
            .Add("pic", "image/pict")
            .Add("pict", "image/pict")
            .Add("pkg", "application/x-newton-compatible-pkg")
            .Add("pko", "application/vnd.ms-pki.pko")
            .Add("pl", "text/plain")
            .Add("plx", "application/x-pixclscript")
            .Add("pm", "image/x-xpixmap")
            .Add("png", "image/png")
            .Add("pnm", "application/x-portable-anymap")
            .Add("pot", "application/mspowerpoint")
            .Add("pov", "model/x-pov")
            .Add("ppa", "application/vnd.ms-powerpoint")
            .Add("ppm", "image/x-portable-pixmap")
            .Add("pps", "application/mspowerpoint")
            .Add("ppt", "application/mspowerpoint")
            .Add("ppz", "application/mspowerpoint")
            .Add("pre", "application/x-freelance")
            .Add("prt", "application/pro_eng")
            .Add("ps", "application/postscript")
            .Add("psd", "application/octet-stream")
            .Add("pvu", "paleovu/x-pv")
            .Add("pwz", "application/vnd.ms-powerpoint")
            .Add("py", "text/x-script.phyton")
            .Add("pyc", "applicaiton/x-bytecode.python")
            .Add("qcp", "audio/vnd.qcelp")
            .Add("qd3", "x-world/x-3dmf")
            .Add("qd3d", "x-world/x-3dmf")
            .Add("qif", "image/x-quicktime")
            .Add("qt", "video/quicktime")
            .Add("qtc", "video/x-qtc")
            .Add("qti", "image/x-quicktime")
            .Add("qtif", "image/x-quicktime")
            .Add("ra", "audio/x-pn-realaudio")
            .Add("ram", "audio/x-pn-realaudio")
            .Add("ras", "application/x-cmu-raster")
            .Add("rast", "image/cmu-raster")
            .Add("rexx", "text/x-script.rexx")
            .Add("rf", "image/vnd.rn-realflash")
            .Add("rgb", "image/x-rgb")
            .Add("rm", "application/vnd.rn-realmedia")
            .Add("rmi", "audio/mid")
            .Add("rmm", "audio/x-pn-realaudio")
            .Add("rmp", "audio/x-pn-realaudio")
            .Add("rng", "application/ringing-tones")
            .Add("rnx", "application/vnd.rn-realplayer")
            .Add("roff", "application/x-troff")
            .Add("rp", "image/vnd.rn-realpix")
            .Add("rpm", "audio/x-pn-realaudio-plugin")
            .Add("rt", "text/richtext")
            .Add("rtf", "text/richtext")
            .Add("rtx", "application/rtf")
            .Add("rv", "video/vnd.rn-realvideo")
            .Add("s", "text/x-asm")
            .Add("s3m", "audio/s3m")
            .Add("saveme", "application/octet-stream")
            .Add("sbk", "application/x-tbook")
            .Add("scm", "application/x-lotusscreencam")
            .Add("sdml", "text/plain")
            .Add("sdp", "application/sdp")
            .Add("sdr", "application/sounder")
            .Add("sea", "application/sea")
            .Add("set", "application/set")
            .Add("sgm", "text/sgml")
            .Add("sgml", "text/sgml")
            .Add("sh", "application/x-bsh")
            .Add("shtml", "text/html")
            .Add("sid", "audio/x-psid")
            .Add("sit", "application/x-sit")
            .Add("skd", "application/x-koan")
            .Add("skm", "application/x-koan")
            .Add("skp", "application/x-koan")
            .Add("skt", "application/x-koan")
            .Add("sl", "application/x-seelogo")
            .Add("smi", "application/smil")
            .Add("smil", "application/smil")
            .Add("snd", "audio/basic")
            .Add("sol", "application/solids")
            .Add("spc", "application/x-pkcs7-certificates")
            .Add("spl", "application/futuresplash")
            .Add("spr", "application/x-sprite")
            .Add("sprite", "application/x-sprite")
            .Add("src", "application/x-wais-source")
            .Add("ssi", "text/x-server-parsed-html")
            .Add("ssm", "application/streamingmedia")
            .Add("sst", "application/vnd.ms-pki.certstore")
            .Add("step", "application/step")
            .Add("stl", "application/sla")
            .Add("stp", "application/step")
            .Add("sv4cpio", "application/x-sv4cpio")
            .Add("sv4crc", "application/x-sv4crc")
            .Add("svf", "image/vnd.dwg")
            .Add("svr", "application/x-world")
            .Add("swf", "application/x-shockwave-flash")
            .Add("t", "application/x-troff")
            .Add("talk", "text/x-speech")
            .Add("tar", "application/x-tar")
            .Add("tbk", "application/toolbook")
            .Add("tcl", "application/x-tcl")
            .Add("tcsh", "text/x-script.tcsh")
            .Add("tex", "application/x-tex")
            .Add("texi", "application/x-texinfo")
            .Add("texinfo", "application/x-texinfo")
            .Add("text", "text/plain")
            .Add("tgz", "application/x-compressed")
            .Add("tif", "image/tiff")
            .Add("tr", "application/x-troff")
            .Add("tsi", "audio/tsp-audio")
            .Add("tsp", "audio/tsplayer")
            .Add("tsv", "text/tab-separated-values")
            .Add("turbot", "image/florian")
            .Add("txt", "text/plain")
            .Add("uil", "text/x-uil")
            .Add("uni", "text/uri-list")
            .Add("unis", "text/uri-list")
            .Add("unv", "application/i-deas")
            .Add("uri", "text/uri-list")
            .Add("uris", "text/uri-list")
            .Add("ustar", "application/x-ustar")
            .Add("uu", "application/octet-stream")
            .Add("vcd", "application/x-cdlink")
            .Add("vcs", "text/x-vcalendar")
            .Add("vda", "application/vda")
            .Add("vdo", "video/vdo")
            .Add("vew", "application/groupwise")
            .Add("viv", "video/vivo")
            .Add("vivo", "video/vivo")
            .Add("vmd", "application/vocaltec-media-desc")
            .Add("vmf", "application/vocaltec-media-file")
            .Add("voc", "audio/voc")
            .Add("vos", "video/vosaic")
            .Add("vox", "audio/voxware")
            .Add("vqe", "audio/x-twinvq-plugin")
            .Add("vqf", "audio/x-twinvq")
            .Add("vql", "audio/x-twinvq-plugin")
            .Add("vrml", "application/x-vrml")
            .Add("vrt", "x-world/x-vrt")
            .Add("vsd", "application/x-visio")
            .Add("vst", "application/x-visio")
            .Add("vsw", "application/x-visio")
            .Add("w60", "application/wordperfect6.0")
            .Add("w61", "application/wordperfect6.1")
            .Add("w6w", "application/msword")
            .Add("wav", "audio/wav")
            .Add("wb1", "application/x-qpro")
            .Add("wbmp", "image/vnd.wap.wbmp")
            .Add("web", "application/vnd.xara")
            .Add("wiz", "application/msword")
            .Add("wk1", "application/x-123")
            .Add("wmf", "windows/metafile")
            .Add("wml", "text/vnd.wap.wml")
            .Add("wmlc", "application/vnd.wap.wmlc")
            .Add("wmls", "text/vnd.wap.wmlscript")
            .Add("wmlsc", "application/vnd.wap.wmlscriptc")
            .Add("word", "application/msword")
            .Add("wp", "application/wordperfect")
            .Add("wp5", "application/wordperfect")
            .Add("wp6", "application/wordperfect")
            .Add("wpd", "application/wordperfect")
            .Add("wq1", "application/x-lotus")
            .Add("wri", "application/mswrite")
            .Add("wrl", "application/x-world")
            .Add("wrz", "model/vrml")
            .Add("wsc", "text/scriplet")
            .Add("wsrc", "application/x-wais-source")
            .Add("wtk", "application/x-wintalk")
            .Add("xbm", "image/x-xbitmap")
            .Add("xdr", "video/x-amt-demorun")
            .Add("xgz", "xgl/drawing")
            .Add("xif", "image/vnd.xiff")
            .Add("xl", "application/excel")
            .Add("xla", "application/excel")
            .Add("xlb", "application/excel")
            .Add("xlc", "application/excel")
            .Add("xld", "application/excel")
            .Add("xlk", "application/excel")
            .Add("xll", "application/excel")
            .Add("xlm", "application/excel")
            .Add("xls", "application/excel")
            .Add("xlt", "application/excel")
            .Add("xlv", "application/excel")
            .Add("xlw", "application/excel")
            .Add("xm", "audio/xm")
            .Add("xml", "text/xml")
            .Add("xmz", "xgl/movie")
            .Add("xpix", "application/x-vnd.ls-xpix")
            .Add("xpm", "image/x-xpixmap")
            .Add("x-png", "image/png")
            .Add("xsr", "video/x-amt-showrun")
            .Add("xwd", "image/x-xwd")
            .Add("xyz", "chemical/x-pdb")
            .Add("z", "application/x-compress")
            .Add("zip", "application/x-compressed")
            .Add("zoo", "application/octet-stream")
            .Add("zsh", "text/x-script.zsh")
            'office 2007+
            .Add("docm", "application/vnd.ms-word.document.macroEnabled.12")
            .Add("docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            .Add("dotm", "application/vnd.ms-word.template.macroEnabled.12")
            .Add("dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template")
            .Add("potm", "application/vnd.ms-powerpoint.template.macroEnabled.12")
            .Add("potx", "application/vnd.openxmlformats-officedocument.presentationml.template")
            .Add("ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12")
            .Add("ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12")
            .Add("ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow")
            .Add("pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12")
            .Add("pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation")
            .Add("one", "application/onenote")
            .Add("onepkg", "application/onenote")
            .Add("onetmp", "application/onenote")
            .Add("onetoc2", "application/onenote")
            .Add("sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12")
            .Add("sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide")
            .Add("thmx", "application/vnd.ms-officetheme")
            .Add("xlam", "application/vnd.ms-excel.addin.macroEnabled.12")
            .Add("xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12")
            .Add("xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12")
            .Add("xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            .Add("xltm", "application/vnd.ms-excel.template.macroEnabled.12")
            .Add("xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template")
            .Add("xps", "application/vnd.ms-xpsdocument")
            'Open Document Format standard
            .Add("odt ", "application/vnd.oasis.opendocument.text ")
            .Add("ott", "application/vnd.oasis.opendocument.text-template")
            .Add("oth", "application/vnd.oasis.opendocument.text-web")
            .Add("odm", "application/vnd.oasis.opendocument.text-master")
            .Add("odg", "application/vnd.oasis.opendocument.graphics")
            .Add("otg", "application/vnd.oasis.opendocument.graphics-template")
            .Add("odp", "application/vnd.oasis.opendocument.presentation")
            .Add("otp", "application/vnd.oasis.opendocument.presentation-template")
            .Add("ods", "application/vnd.oasis.opendocument.spreadsheet")
            .Add("ots", "application/vnd.oasis.opendocument.spreadsheet-template")
            .Add("odc", "application/vnd.oasis.opendocument.chart")
            .Add("odf", "application/vnd.oasis.opendocument.formula")
            .Add("odb", "application/vnd.oasis.opendocument.database")
            .Add("odi", "application/vnd.oasis.opendocument.image")
            .Add("oxt", "application/vnd.openofficeorg.extension")
        End With
    End Sub

    Public Shared Function GetContentType(ByVal FileName As String, Optional ByVal PullExtensionFromFileName As Boolean = True) As String
        Try
            If contentTypes Is Nothing OrElse Not (contentTypes.Count > 0) Then
                InitializeMimeTypes()
            End If

            Dim extension As String = ""

            If PullExtensionFromFileName = False Then
                Dim fi = New FileInfo(FileName)
                extension = fi.Extension.Replace(".", "")
            Else
                extension = MiscFN.ParseLast(FileName, ".")
            End If

            Dim contentType As String = ""
            Dim FoundIt As Boolean = False
            FoundIt = contentTypes.TryGetValue(extension.ToLower(), contentType)

            If FoundIt = False OrElse String.IsNullOrEmpty(contentType) Then
                contentType = "application/octet-stream"
            End If

            Return contentType
        Catch ex As Exception
            Return "application/octet-stream"
        End Try
    End Function

    Public Sub New()

    End Sub

End Class

Public Class WVDataHelper

    Public Shared Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
        Dim lastValues() As Object
        Dim newTable As DataTable

        If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
            Throw New ArgumentNullException("FieldNames")
        End If

        lastValues = New Object(FieldNames.Length - 1) {}
        newTable = New DataTable

        For Each field As String In FieldNames
            newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
        Next

        For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
            If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
                newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

                setLastValues(lastValues, Row, FieldNames)
            End If
        Next

        Return newTable
    End Function

    Private Shared Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
        Dim areEqual As Boolean = True

        For i As Integer = 0 To fieldNames.Length - 1
            If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
                areEqual = False
                Exit For
            End If
        Next

        Return areEqual
    End Function

    Private Shared Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
        For Each field As String In fieldNames
            newRow(field) = sourceRow(field)
        Next

        Return newRow
    End Function

    Private Shared Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
        For i As Integer = 0 To fieldNames.Length - 1
            lastValues(i) = sourceRow(fieldNames(i))
        Next
    End Sub

    Sub New()

    End Sub
End Class

Public Class LoGlo

    Public Shared Function FormatDecimal(ByVal [Number] As String) As Decimal
        Try

            Dim s As String = [Number]
            s = LoGlo.FormatNumber(s)
            Return CType(s, Decimal)

        Catch ex As Exception
            Return [Number]
        End Try
    End Function
    Public Shared Function FormatNumber(ByVal [Number] As String) As String
        Try
            Dim ci As New System.Globalization.CultureInfo(LoGlo.UserCultureGet())

            Dim s As String = [Number]

            If IsNumeric(s) = False And LoGlo.IsEnglish = False Then
                'Culture is set correctly, yet "Number" is not valid
                'most likely string being passed in is English
                'HACK!
                Try
                    s = s.Replace(" ", "")
                    s = s.Replace(",", "")
                    Dim DecimalSeparator As String = ci.NumberFormat.NumberDecimalSeparator
                    s = s.Replace(".", DecimalSeparator)
                Catch ex As Exception
                    Return [Number]
                End Try
            End If

            Return Microsoft.VisualBasic.FormatNumber(s, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)

        Catch ex As Exception
            Return [Number]
        End Try
    End Function
    Public Shared Function FormatDate(ByVal [Date] As String) As String
        Try
            If ([Date].Trim().IndexOf("&nbsp;") > -1 Or [Date].Trim() = "" Or [Date].Trim() = "1/1/1900" Or [Date].Trim() = "01/01/1900" Or [Date].Trim() = "1/01/1900") Then Return ""
            Dim d As DateTime = Nothing
            Dim CurrentCulture As System.Globalization.CultureInfo

            Dim lg As New LoGlo()
            d = lg.SetDate(CurrentCulture, [Date])

            Return String.Format(CurrentCulture, "{0:d}", d)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function FormatLongDateTime(ByVal [Date] As String) As String
        Try
            If ([Date].Trim().IndexOf("&nbsp;") > -1 Or [Date].Trim() = "") Then Return ""
            Dim d As DateTime = Nothing
            Dim CurrentCulture As System.Globalization.CultureInfo

            Dim lg As New LoGlo()
            d = lg.SetDate(CurrentCulture, [Date])

            Return String.Format(CurrentCulture, "{0:D}", d)
        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function FormatDateTime(ByVal [Date] As String, Optional ByVal IncludeTime As Boolean = True) As String
        Try
            If ([Date].Trim().IndexOf("&nbsp;") > -1 Or [Date].Trim() = "") Then Return ""
            Dim d As DateTime = Nothing
            Dim CurrentCulture As System.Globalization.CultureInfo

            Dim lg As New LoGlo()
            d = lg.SetDate(CurrentCulture, [Date])

            'If ReturnLongDateTimeString = True Then
            '    Return String.Format(CurrentCulture, "{0:D}", d)
            'End If
            If IncludeTime = True Then
                Return String.Format(CurrentCulture, "{0:g}", d)
            Else
                Return String.Format(CurrentCulture, "{0:d}", d)
            End If

        Catch ex As Exception
            Return ""
        End Try
    End Function
    Public Shared Function FormatMonthText(ByVal [Date] As String) As String
        Try
            Dim CultureCode As String = ""
            Dim CurrentCulture As System.Globalization.CultureInfo
            With HttpContext.Current.Request
                If Not .Cookies("LoGloCode") Is Nothing And Not .Cookies("LoGloCode").Value Is Nothing Then
                    CultureCode = .Cookies("LoGloCode").Value
                Else
                    CultureCode = "en-US"
                    LoGlo.UserCultureSet(CultureCode)
                End If
            End With
            CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(CultureCode)
        Catch ex As Exception
            Return [Date]
        End Try
    End Function

    Public Overloads Shared Function FirstOfMonth() As Date
        Return Today.AddDays(-(Today.Day - 1))
    End Function
    Public Overloads Shared Function FirstOfMonth(ByVal [Date] As String) As Date
        If IsDate([Date]) Then
            Return CDate([Date]).AddDays(-(CDate([Date]).Day - 1))
        End If
    End Function
    Public Overloads Shared Function FirstOfMonth(ByVal Year As Integer, ByVal Month As Integer) As Date
        Dim d As New DateTime(Year, Month, 1)
        Return d
    End Function
    Public Overloads Shared Function LastOfMonth() As Date
        Return Today.AddMonths(1).AddDays(-(Today.Day))
    End Function
    Public Overloads Shared Function LastOfMonth(ByVal [Date] As String) As Date
        If IsDate([Date]) Then
            If CDate([Date]).Day = 31 Then
                If CDate([Date]).AddMonths(1).Month = 1 Or CDate([Date]).AddMonths(1).Month = 8 Then
                    Return CDate([Date]).AddMonths(1).AddDays(-(CDate([Date]).Day))
                Else
                    Return CDate([Date]).AddMonths(1).AddDays(-(CDate([Date]).Day - 1))
                End If
            Else
                Return CDate([Date]).AddMonths(1).AddDays(-(CDate([Date]).Day))
            End If
        End If
    End Function
    Public Shared Function FirstOfYear(Optional ByVal Year As Integer = 0) As Date
        If Year = 0 Then
            Year = Now.Year
        End If
        Dim d As New DateTime(Year, 1, 1)
        Return d

    End Function
    Public Shared Function LastOfYear(Optional ByVal Year As Integer = 0) As Date
        If Year = 0 Then
            Year = Now.Year
        End If
        Dim d As New DateTime(Year, 12, 31)
        Return d

    End Function

    Public Shared Function LoadMonths(Optional ByVal UseAbbreviations As Boolean = False) As DataTable

        Dim dt As New DataTable
        With dt.Columns
            .Add("code")
            .Add("description")
        End With

        Dim c As CultureInfo = LoGlo.GetCultureInfo
        ' Dim c As New System.Globalization.CultureInfo("en-US")


        For i As Integer = 1 To 12
            Dim r As DataRow
            r = dt.NewRow()
            r.Item("code") = i.ToString()
            If UseAbbreviations = False Then
                r.Item("description") = DayPilot.Utils.Year.GetMonthName(i).ToString()
            Else
                Dim d As New DateTime(DateTime.Now.Year, i, 1)
                r.Item("description") = String.Format(c, "{0:MMM}", d)
            End If
            dt.Rows.Add(r)
        Next

        Return dt

    End Function
    Public Sub MvcTimesheetHeader(ByVal [Date] As Date, ByRef DayText As String, ByRef DateText As String)

        TimesheetHeader([Date], False, False, DayText, DateText)

    End Sub
    Public Function TimesheetHeader(ByVal [Date] As String,
                                    Optional ByVal ShowOnlyAbbreviatedDay As Boolean = False,
                                    Optional ByVal ShowLongDate As Boolean = False,
                                    Optional ByRef DayText As String = "", Optional ByRef DateText As String = "") As String
        Try
            Dim c As CultureInfo = LoGlo.GetCultureInfo()
            Dim sb As New System.Text.StringBuilder
            Dim d As Date = CType([Date], Date)
            Dim TodayIndicator As String = ""

            If [Date] = Today.Date Then

                TodayIndicator = "*"

            End If

            With sb

                If ShowLongDate = True Then 'overrides ShowOnlyAbbreviatedDay

                    .Append(d.ToLongDateString())
                    DayText = d.ToLongDateString()
                    ShowOnlyAbbreviatedDay = True

                Else

                    DayText = String.Format(c, "{0:ddd}", d)
                    .Append(String.Format(c, "{0:ddd}", d)) 'abbreviated day

                End If

                '.Append(TodayIndicator)

                If ShowOnlyAbbreviatedDay = False Then

                    .Append("<br />")

                    'HACK!!!
                    If LoGlo.IsEnglish = True Then
                        .Append(String.Format(c, "{0:MM/dd}", d))
                        DateText = String.Format(c, "{0:MM/dd}", d)
                    Else
                        Try
                            Dim ar() As String
                            Dim ci As New System.Globalization.CultureInfo(LoGlo.UserCultureGet())
                            ar = String.Format(c, "{0:MM/dd}", d).Split(ci.DateTimeFormat.DateSeparator)
                            If ar.Length = 2 Then
                                .Append(ar(1))
                                .Append(c.DateTimeFormat.DateSeparator)
                                .Append(ar(0))
                            End If
                            DateText = ar(1) & c.DateTimeFormat.DateSeparator & ar(0)
                        Catch ex As Exception
                            Return [Date]
                        End Try
                    End If
                End If

            End With

            Return sb.ToString()

        Catch ex As Exception
            Return [Date]
        End Try
    End Function
    Public Function SetDate(ByRef ci As System.Globalization.CultureInfo, ByVal [Date] As String) As Date
        Try
            If ([Date].Trim().IndexOf("&nbsp;") > -1 Or [Date].Trim() = "") Then Return Nothing
            Dim d As DateTime = Nothing

            Dim CultureCode As String = ""
            'Dim CurrentCulture As System.Globalization.CultureInfo

            With HttpContext.Current.Request
                If Not .Cookies("LoGloCode") Is Nothing And Not .Cookies("LoGloCode").Value Is Nothing Then
                    CultureCode = .Cookies("LoGloCode").Value
                Else
                    CultureCode = "en-US"
                    LoGlo.UserCultureSet(CultureCode)
                End If
            End With
            ci = System.Globalization.CultureInfo.GetCultureInfo(CultureCode)

            If IsDate([Date]) = True Then
                d = CType([Date], DateTime)
            Else 'not a date according to culture set, most likely a string in en-US format

                'hack for now....
                Dim ar() As String = Nothing
                If [Date].IndexOf("/") > -1 Then
                    ar = [Date].Split("/")
                ElseIf [Date].IndexOf(".") > -1 Then
                    ar = [Date].Split(".")
                ElseIf [Date].IndexOf("-") > -1 Then
                    ar = [Date].Split("-")
                ElseIf [Date].IndexOf(",") > -1 Then
                    ar = [Date].Split(",")
                End If

                If ar.Length = 3 Then
                    d = CDate(ar(1) & ci.DateTimeFormat.DateSeparator & ar(0) & ci.DateTimeFormat.DateSeparator & ar(2))
                End If
            End If

            Return d
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Shared Function GetCultureInfo() As System.Globalization.CultureInfo

        Dim CultureCode As String = "en-US"

        Try

            If HttpContext.Current.Request IsNot Nothing AndAlso HttpContext.Current.Request.Cookies IsNot Nothing Then

                If HttpContext.Current.Request.Cookies("LoGloCode") IsNot Nothing AndAlso
                    String.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies("LoGloCode").Value) = False Then

                    CultureCode = HttpContext.Current.Request.Cookies("LoGloCode").Value

                Else

                    CultureCode = "en-US"

                End If

            End If

        Catch ex As Exception
            CultureCode = "en-US"
        End Try

        LoGlo.UserCultureSet(CultureCode)

        Return System.Globalization.CultureInfo.GetCultureInfo(CultureCode)

    End Function
    Public Shared Function IsEnglish() As Boolean

        Try

            Return LoGlo.UserCultureGet() = "en-US"

        Catch ex As Exception
            Return True
        End Try

    End Function

    Public Shared Function GetDateFormat() As String
        Dim info As CultureInfo = New CultureInfo(LoGlo.UserCultureGet())

        Return info.DateTimeFormat.ShortDatePattern

    End Function

    Public Shared Function GetDateInputFormat() As String()
        Dim _dateFormat As String = GetDateFormat()

        ' Month first
        If _dateFormat.StartsWith("M") Then
            Return {"MM-dd-yyyy", "MM-dd-yy", "MM/dd/yyyy", "MM/dd/yy", "MMddyyyy", "MMddyy"}
        End If

        Return {"dd-MM-yyyy", "dd-MM-yy", "dd/MM/yyyy", "dd/MM/yy", "ddMMyyyy", "ddMMyy"}

    End Function

    Public Shared Sub UserCultureSet(Optional ByVal CultureCode As String = "en-US")

        Try

            HttpContext.Current.Response.Cookies("LoGloCode").Value = CultureCode
            HttpContext.Current.Response.Cookies("LoGloCode").Expires = DateTime.Now.AddYears(1)

        Catch ex As Exception
        End Try

    End Sub
    Public Shared Function UserCultureGet() As String

        Try
            If HttpContext.Current.Request.Cookies("LoGloCode") IsNot Nothing AndAlso
               String.IsNullOrWhiteSpace(HttpContext.Current.Request.Cookies("LoGloCode").Value) = False Then

                Return HttpContext.Current.Request.Cookies("LoGloCode").Value.ToString().Trim()

            Else

                Return "en-US"

            End If

        Catch ex As Exception
            Return "en-US"
        End Try

    End Function
    Public Property UserCurrentCulture() As String
        Get
            Try
                With HttpContext.Current.Request
                    If Not .Cookies("LoGloCode") Is Nothing And Not .Cookies("LoGloCode").Value Is Nothing Then
                        Return .Cookies("LoGloCode").Value.ToString().Trim()
                    Else
                        UserCurrentCulture = "en-US"
                        Return "en-US"
                    End If
                End With
            Catch ex As Exception
                Return "en-US"
            End Try
        End Get
        Set(value As String)
            Try
                With HttpContext.Current.Response
                    .Cookies("LoGloCode").Value = value
                    .Cookies("LoGloCode").Expires = DateTime.Now.AddYears(1)
                End With
            Catch ex As Exception
                With HttpContext.Current.Response
                    .Cookies("LoGloCode").Value = "en-US"
                    .Cookies("LoGloCode").Expires = DateTime.Now.AddYears(1)
                End With
            End Try
        End Set
    End Property
    Public Shared Sub GetCultureCodesForUser(ByRef CultureCode As String, ByRef UICulture As String)

        Dim DatabaseCultureCode As String = "en-US"
        Dim AgencyCultureCode As String = "en-US"
        Dim EmployeeCultureCode As String = "en-US"

        EmployeeCultureCode = LoGlo.UserCultureGet

        If HttpContext.Current.Session("DatabaseCultureCode") Is Nothing Then

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                    DatabaseCultureCode = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseCultureCode(DbContext)

                End Using

            Catch ex As Exception
                DatabaseCultureCode = "en-US"
            End Try

            HttpContext.Current.Session("DatabaseCultureCode") = DatabaseCultureCode

        Else

            DatabaseCultureCode = HttpContext.Current.Session("DatabaseCultureCode")

        End If

        CultureCode = DatabaseCultureCode
        UICulture = EmployeeCultureCode

    End Sub
    Public Overloads Shared Sub PageCultureSet(ByVal [Page] As Page)
        With [Page]
            .Culture = LoGlo.UserCultureGet()
            .UICulture = LoGlo.UserCultureGet()
        End With
    End Sub
    Public Shared Sub PageCultureSetDatabaseAndUser(ByVal [Page] As Page)

        GetCultureCodesForUser(Page.Culture, Page.UICulture)

    End Sub

    Public Sub New()

    End Sub

End Class
