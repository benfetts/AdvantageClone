Imports System.Globalization

Namespace DateUtilities

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Months
            January = 1
            February = 2
            March = 3
            April = 4
            May = 5
            June = 6
            July = 7
            August = 8
            September = 9
            October = 10
            November = 11
            December = 12
        End Enum

        Public Enum Days
            Monday = 1
            Tuesday = 2
            Wednesday = 3
            Thursday = 4
            Friday = 5
            Saturday = 6
            Sunday = 7
        End Enum

        Public Enum DateFormat
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("YMD", "YMD")>
            YMD
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("YDM", "YDM")>
            YDM
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MDY", "MDY")>
            MDY
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MYD", "MYD")>
            MYD
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("DMY", "DMY")>
            DMY
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("DYM", "DYM")>
            DYM
        End Enum

        Public Enum AbbreviatedMonths
            JAN = 1
            FEB = 2
            MAR = 3
            APR = 4
            MAY = 5
            JUN = 6
            JUL = 7
            AUG = 8
            SEP = 9
            OCT = 10
            NOV = 11
            DEC = 12
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function FriendlyDateDiff(ByVal StartDate As Date, ByVal EndDate As Date) As String

            Dim DateString As String = String.Empty

            Try

                Dim Diff As TimeSpan = EndDate - StartDate
                Dim Days As Double = Diff.TotalDays
                Dim Hours As Integer = Diff.Hours
                Dim Minutes As Integer = Diff.Minutes
                Dim Seconds As Integer = Diff.Seconds

                If Days > 0 Then Days = CType(Days, Integer)

                If Days = 1 Then

                    DateString = "One day"

                ElseIf Days > 1 Then

                    DateString = Days.ToString & " days"

                End If
                If String.IsNullOrWhiteSpace(DateString) = True Then

                    If Hours = 1 Then

                        DateString = "One hour"

                    ElseIf Hours > 1 Then

                        DateString = Hours.ToString & " hours"

                    End If

                Else

                    If Hours = 1 Then

                        DateString &= ", one hour"

                    ElseIf Hours > 1 Then

                        DateString &= ", " & Hours.ToString & " hours"

                    End If

                End If
                If String.IsNullOrWhiteSpace(DateString) = True Then

                    If Minutes = 1 Then

                        DateString = "One minute"

                    ElseIf Minutes > 1 Then

                        DateString = Minutes.ToString & " minutes"

                    End If

                Else

                    If Minutes = 1 Then

                        DateString &= ", one minute"

                    ElseIf Minutes > 1 Then

                        DateString &= ", " & Minutes.ToString & " minutes"

                    End If

                End If
                If String.IsNullOrWhiteSpace(DateString) = True AndAlso Seconds > 0 Then

                    DateString = "Less than a minute"

                End If
            Catch ex As Exception
                DateString = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(DateString) = True Then

                DateString = StartDate.ToString & " - " & EndDate.ToString

            End If

            Return DateString

        End Function
        Public Function FirstDayOfWeek(ByVal TheDate As Date) As Date
            Try

                Dim FirstDayOfWeekDate As Date
                Dim StartWeekOn As DayOfWeek = DayOfWeek.Sunday
                Dim dfi As DateTimeFormatInfo = DateTimeFormatInfo.CurrentInfo

                StartWeekOn = dfi.FirstDayOfWeek

                If TheDate = Nothing Then TheDate = Now.Date

                For i As Integer = 0 To 6 Step 1

                    FirstDayOfWeekDate = TheDate.AddDays(-i)

                    If FirstDayOfWeekDate.DayOfWeek = StartWeekOn Then

                        Exit For

                    End If

                Next

                Return FirstDayOfWeekDate

            Catch ex As Exception
                Return TheDate
            End Try
        End Function
        'Public Function ToShortDateString(ByVal TheDate As Nullable(Of Date), ByVal ReturnPlaceholder As Boolean) As String

        '    Dim DateAsString As String = String.Empty

        '    Try

        '        If TheDate IsNot Nothing AndAlso IsDate(TheDate) = True Then

        '            DateAsString = CDate(TheDate).ToShortDateString

        '        End If

        '    Catch ex As Exception
        '        DateAsString = String.Empty
        '    End Try

        '    If String.IsNullOrWhiteSpace(DateAsString) = True AndAlso ReturnPlaceholder = True Then

        '        DateAsString = "--"

        '    End If

        '    Return DateAsString

        'End Function

        Public Function ConvertShortDateStringToDate(ByVal ShortDateString As String) As Date

            'objects
            Dim ShortDate As Date = Nothing

            Try

                ShortDate = CDate(ShortDateString)

            Catch ex As Exception
                ShortDate = Nothing
            Finally

                If ShortDate <> Nothing AndAlso ShortDate.ToShortDateString = "01/01/1900" Then

                    ShortDate = Nothing

                End If

                ConvertShortDateStringToDate = ShortDate

            End Try

        End Function
        Public Function ConvertStringToShortDateString(ByVal DateString As String) As String

            'objects
            Dim ValidExpressionMatch As Boolean = True
            Dim Year As String = ""
            Dim Day As String = ""
            Dim Month As String = ""
            Dim ConvertedDate As String = ""
            Dim DateSectionsArray() As String = Nothing
            Dim DatePartSectionsArray() As String = Nothing
            Dim DatePartSection As String = Nothing
            Dim ShortDate As Date = Nothing

            If Date.TryParse(DateString, ShortDate) Then

                DateString = Date.Parse(DateString).Month & "/" & Date.Parse(DateString).Day & "/" & Date.Parse(DateString).Year

            Else

                If DateString.Length = 6 Then

                    If My.Application.Culture.DateTimeFormat IsNot Nothing Then

                        DatePartSectionsArray = My.Application.Culture.DateTimeFormat.ShortDatePattern.Split(My.Application.Culture.DateTimeFormat.DateSeparator)

                        If DatePartSectionsArray IsNot Nothing Then

                            DatePartSection = DatePartSectionsArray(0)

                            If DatePartSection.ToUpper.StartsWith("D") Then

                                Day = DateString.Substring(0, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("M") Then

                                Month = DateString.Substring(0, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("Y") Then

                                Year = DateString.Substring(0, 2)

                            End If

                            DatePartSection = DatePartSectionsArray(1)

                            If DatePartSection.ToUpper.StartsWith("D") Then

                                Day = DateString.Substring(2, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("M") Then

                                Month = DateString.Substring(2, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("Y") Then

                                Year = DateString.Substring(2, 2)

                            End If

                            DatePartSection = DatePartSectionsArray(2)

                            If DatePartSection.ToUpper.StartsWith("D") Then

                                Day = DateString.Substring(4, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("M") Then

                                Month = DateString.Substring(4, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("Y") Then

                                Year = DateString.Substring(4, 2)

                            End If

                        End If

                    Else

                        Month = DateString.Substring(0, 2)
                        Day = DateString.Substring(2, 2)
                        Year = DateString.Substring(4, 2)

                    End If

                    DateString = Month & "/" & Day & "/" & Year

                ElseIf DateString.Length = 7 Then

                    DateString = "0" & DateString.Substring(0, 1) & "/" & DateString.Substring(1, 2) & "/" & DateString.Substring(3, 4)

                ElseIf DateString.Length = 8 Then

                    If My.Application.Culture.DateTimeFormat IsNot Nothing Then

                        DatePartSectionsArray = My.Application.Culture.DateTimeFormat.ShortDatePattern.Split(My.Application.Culture.DateTimeFormat.DateSeparator)

                        If DatePartSectionsArray IsNot Nothing Then

                            DatePartSection = DatePartSectionsArray(0)

                            If DatePartSection.ToUpper.StartsWith("D") Then

                                Day = DateString.Substring(0, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("M") Then

                                Month = DateString.Substring(0, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("Y") Then

                                Year = DateString.Substring(0, 2)

                            End If

                            DatePartSection = DatePartSectionsArray(1)

                            If DatePartSection.ToUpper.StartsWith("D") Then

                                Day = DateString.Substring(2, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("M") Then

                                Month = DateString.Substring(2, 2)

                            ElseIf DatePartSection.ToUpper.StartsWith("Y") Then

                                Year = DateString.Substring(2, 2)

                            End If

                            DatePartSection = DatePartSectionsArray(2)

                            If DatePartSection.ToUpper.StartsWith("D") Then

                                Day = DateString.Substring(4, 4)

                            ElseIf DatePartSection.ToUpper.StartsWith("M") Then

                                Month = DateString.Substring(4, 4)

                            ElseIf DatePartSection.ToUpper.StartsWith("Y") Then

                                Year = DateString.Substring(4, 4)

                            End If

                        End If

                    Else

                        Month = DateString.Substring(0, 2)
                        Day = DateString.Substring(2, 2)
                        Year = DateString.Substring(4, 4)

                    End If

                    DateString = Month & "/" & Day & "/" & Year

                Else

                    Try

                        If Date.TryParse(DateString, ShortDate) Then

                            DateString = Date.Parse(DateString).Month & "/" & Date.Parse(DateString).Day & "/" & Date.Parse(DateString).Year

                        End If

                    Catch ex As Exception
                        ValidExpressionMatch = False
                    End Try

                End If

            End If

            Month = ""
            Day = ""
            Year = ""

            If ValidExpressionMatch Then

                If Date.TryParse(DateString, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), Globalization.DateTimeStyles.None, ShortDate) Then

                    ShortDate = Nothing

                    DateSectionsArray = Split(DateString, "/")

                    If DateSectionsArray.Length = 3 Then

                        Month = DateSectionsArray(0)
                        Day = DateSectionsArray(1)
                        Year = DateSectionsArray(2)

                    End If

                    If Year.Length = 2 Then

                        Year = "20" & Year

                    End If

                    ConvertedDate = Month & "/" & Day & "/" & Year

                    If Date.TryParse(ConvertedDate, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), Globalization.DateTimeStyles.None, ShortDate) Then

                        If ShortDate = Nothing Then

                            ConvertedDate = ""

                        Else

                            ConvertedDate = ShortDate.ToShortDateString

                        End If

                    Else

                        ConvertedDate = ""

                    End If

                End If

            End If

            ConvertStringToShortDateString = ConvertedDate

        End Function
        Public Function ConvertStringToShortDateString(ByVal DateString As String, ByVal DateFormat As String) As String

            'objects
            Dim ValidExpressionMatch As Boolean = True
            Dim Year As String = ""
            Dim Day As String = ""
            Dim Month As String = ""
            Dim ConvertedDate As String = ""
            Dim DateSectionsArray() As String = Nothing
            Dim ShortDate As Date = Nothing
            Dim NonNumericCharactersRegex As System.Text.RegularExpressions.Regex = Nothing
            Dim NumericOnlyString As String = Nothing

            If DateString.Contains("/") Then

                Select Case DateFormat

                    Case AdvantageFramework.DateUtilities.DateFormat.DMY.ToString

                        If AdvantageFramework.StringUtilities.IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.DateDDMMYYYYRegularExpressionString, DateString) Then

                            DateSectionsArray = Split(DateString, "/")

                            ConvertedDate = DateSectionsArray(1) & "/" & DateSectionsArray(0) & "/" & If(Len(DateSectionsArray(2)) = 2, "20" & DateSectionsArray(2), DateSectionsArray(2))

                        End If

                    Case AdvantageFramework.DateUtilities.DateFormat.DYM.ToString

                        If AdvantageFramework.StringUtilities.IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.DateDDYYYYMMRegularExpressionString, DateString) Then

                            DateSectionsArray = Split(DateString, "/")

                            ConvertedDate = DateSectionsArray(2) & "/" & DateSectionsArray(0) & "/" & If(Len(DateSectionsArray(1)) = 2, "20" & DateSectionsArray(1), DateSectionsArray(1))

                        End If

                    Case AdvantageFramework.DateUtilities.DateFormat.MDY.ToString

                        If AdvantageFramework.StringUtilities.IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.DateMMDDYYYYRegularExpressionString, DateString) Then

                            DateSectionsArray = Split(DateString, "/")

                            ConvertedDate = DateSectionsArray(0) & "/" & DateSectionsArray(1) & "/" & If(Len(DateSectionsArray(2)) = 2, "20" & DateSectionsArray(2), DateSectionsArray(2))

                        End If

                    Case AdvantageFramework.DateUtilities.DateFormat.MYD.ToString

                        If AdvantageFramework.StringUtilities.IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.DateMMYYYYDDRegularExpressionString, DateString) Then

                            DateSectionsArray = Split(DateString, "/")

                            ConvertedDate = DateSectionsArray(0) & "/" & DateSectionsArray(2) & "/" & If(Len(DateSectionsArray(1)) = 2, "20" & DateSectionsArray(1), DateSectionsArray(1))

                        End If

                    Case AdvantageFramework.DateUtilities.DateFormat.YMD.ToString

                        If AdvantageFramework.StringUtilities.IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.DateYYYYMMDDRegularExpressionString, DateString) Then

                            DateSectionsArray = Split(DateString, "/")

                            ConvertedDate = DateSectionsArray(1) & "/" & DateSectionsArray(2) & "/" & If(Len(DateSectionsArray(0)) = 2, "20" & DateSectionsArray(0), DateSectionsArray(0))

                        End If

                    Case AdvantageFramework.DateUtilities.DateFormat.YDM.ToString

                        If AdvantageFramework.StringUtilities.IsRegularExpressionAMatch(AdvantageFramework.StringUtilities.DateYYYYDDMMRegularExpressionString, DateString) Then

                            DateSectionsArray = Split(DateString, "/")

                            ConvertedDate = DateSectionsArray(2) & "/" & DateSectionsArray(1) & "/" & If(Len(DateSectionsArray(0)) = 2, "20" & DateSectionsArray(0), DateSectionsArray(0))

                        End If

                End Select

            End If

            If Not IsDate(ConvertedDate) Then

                ConvertedDate = ""

                NonNumericCharactersRegex = New System.Text.RegularExpressions.Regex("\D")

                NumericOnlyString = NonNumericCharactersRegex.Replace(DateString, String.Empty)

                If NumericOnlyString.Length = 8 Then

                    If DateFormat = DateUtilities.DateFormat.YMD.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(4, 2) & "/" & NumericOnlyString.Substring(6, 2) & "/" & NumericOnlyString.Substring(0, 4)

                    ElseIf DateFormat = DateUtilities.DateFormat.YDM.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(6, 2) & "/" & NumericOnlyString.Substring(4, 2) & "/" & NumericOnlyString.Substring(0, 4)

                    ElseIf DateFormat = DateUtilities.DateFormat.MDY.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(0, 2) & "/" & NumericOnlyString.Substring(2, 2) & "/" & NumericOnlyString.Substring(4, 4)

                    ElseIf DateFormat = DateUtilities.DateFormat.MYD.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(0, 2) & "/" & NumericOnlyString.Substring(6, 2) & "/" & NumericOnlyString.Substring(2, 4)

                    ElseIf DateFormat = DateUtilities.DateFormat.DMY.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(2, 2) & "/" & NumericOnlyString.Substring(0, 2) & "/" & NumericOnlyString.Substring(4, 4)

                    ElseIf DateFormat = DateUtilities.DateFormat.DYM.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(6, 2) & "/" & NumericOnlyString.Substring(0, 2) & "/" & NumericOnlyString.Substring(2, 4)

                    End If

                ElseIf NumericOnlyString.Length = 6 Then

                    If DateFormat = DateUtilities.DateFormat.YMD.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(2, 2) & "/" & NumericOnlyString.Substring(4, 2) & "/20" & NumericOnlyString.Substring(0, 2)

                    ElseIf DateFormat = DateUtilities.DateFormat.YDM.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(4, 2) & "/" & NumericOnlyString.Substring(2, 2) & "/20" & NumericOnlyString.Substring(0, 2)

                    ElseIf DateFormat = DateUtilities.DateFormat.MDY.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(0, 2) & "/" & NumericOnlyString.Substring(2, 2) & "/20" & NumericOnlyString.Substring(4, 2)

                    ElseIf DateFormat = DateUtilities.DateFormat.MYD.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(0, 2) & "/" & NumericOnlyString.Substring(4, 2) & "/20" & NumericOnlyString.Substring(2, 2)

                    ElseIf DateFormat = DateUtilities.DateFormat.DMY.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(2, 2) & "/" & NumericOnlyString.Substring(0, 2) & "/20" & NumericOnlyString.Substring(4, 2)

                    ElseIf DateFormat = DateUtilities.DateFormat.DYM.ToString Then

                        ConvertedDate = NumericOnlyString.Substring(4, 2) & "/" & NumericOnlyString.Substring(0, 2) & "/20" & NumericOnlyString.Substring(2, 2)

                    End If

                End If

                If Date.TryParse(ConvertedDate, System.Globalization.CultureInfo.CreateSpecificCulture("en-US"), Globalization.DateTimeStyles.None, ShortDate) Then

                    ConvertedDate = ShortDate.ToShortDateString

                Else

                    ConvertedDate = ""

                End If

            End If

            ConvertStringToShortDateString = ConvertedDate

        End Function
        Public Function GetQuarter(Month As Integer) As Integer

            'objects
            Dim Quarter As Integer = 0

            If Month > 0 AndAlso Month < 13 Then

                Quarter = CInt(Math.Ceiling(Month / 3))

            End If

            GetQuarter = Quarter

        End Function
        Public Function GetQuarter([Date] As Date, Optional ByRef Year As Integer = 0) As Integer

            'objects
            Dim Quarter As Integer = 0

            Year = 0

            If [Date] <> Nothing Then

                Quarter = CInt(Math.Ceiling([Date].Month / 3))
                Year = [Date].Year

            End If

            GetQuarter = Quarter

        End Function
        Public Sub GetQuarterStartDateAndEndDate([Date] As Date, ByRef StartDate As Date, ByRef EndDate As Date)

            'objects
            Dim Quarter As Integer = 0
            Dim Year As Integer = 0

            Quarter = GetQuarter([Date], Year)

            GetQuarterStartDateAndEndDate(Quarter, Year, StartDate, EndDate)

        End Sub
        Public Sub GetQuarterStartDateAndEndDate(Quarter As Integer, Year As Integer, ByRef StartDate As Date, ByRef EndDate As Date)

            If Quarter > 0 Then

                Select Case Quarter

                    Case 1

                        StartDate = New Date(Year, 1, 1)
                        EndDate = New Date(Year, 3, Date.DaysInMonth(Year, 3))

                    Case 2

                        StartDate = New Date(Year, 4, 1)
                        EndDate = New Date(Year, 6, Date.DaysInMonth(Year, 6))

                    Case 3

                        StartDate = New Date(Year, 7, 1)
                        EndDate = New Date(Year, 9, Date.DaysInMonth(Year, 9))

                    Case 4

                        StartDate = New Date(Year, 10, 1)
                        EndDate = New Date(Year, 12, Date.DaysInMonth(Year, 12))

                End Select

            End If

        End Sub

#End Region

    End Module

End Namespace

