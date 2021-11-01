Imports System.Web

Public Class ReportFunctions

    Public Shared Function WrapRtfInFontTag(ByVal Text As String) As String

        Return String.Format("<font face=""Arial"" size=""2"">{0}</font>", Text)

    End Function
    Public Shared Sub SetBillingApprovalBillingRateLabel(ByVal QtyHours As String, ByRef BillingRate As String)

        If QtyHours = "" AndAlso BillingRate = "0.00" Then

            BillingRate = ""

        ElseIf QtyHours = "" AndAlso BillingRate <> "0.00" Then

            BillingRate = ""

        ElseIf QtyHours <> "" AndAlso BillingRate = "0.00" Then

            BillingRate = QtyHours & " hrs"

        ElseIf QtyHours <> "" AndAlso BillingRate <> "0.00" Then

            BillingRate = QtyHours & " hrs " & "@" & BillingRate & "/hr"

        End If
        If String.IsNullOrWhiteSpace(QtyHours) = True OrElse
                (IsNumeric(QtyHours) = True AndAlso CType(QtyHours, Decimal) = 0.0) Then

            BillingRate = ""

        End If

    End Sub
    Public Shared Function SetCulture(ByVal [Report] As DataDynamics.ActiveReports.ActiveReport, Optional ByVal CultureCode As String = "en-US")
        Try
            Dim ci As New System.Globalization.CultureInfo(CultureCode)
            Threading.Thread.CurrentThread.CurrentCulture = ci
        Catch ex As Exception
        End Try
    End Function

    Public Shared Function FormatDecimal(ByVal [Number] As String) As Decimal
        Try

            Dim s As String = [Number]
            s = ReportFunctions.FormatNumber(s)
            Return CType(s, Decimal)

        Catch ex As Exception
            Return [Number]
        End Try
    End Function

    Public Shared Function FormatNumber(ByVal [Number] As String) As String
        Try
            Dim ci As New System.Globalization.CultureInfo(ReportFunctions.UserCultureGet())

            Dim s As String = [Number]

            If IsNumeric(s) = False And ReportFunctions.IsEnglish = False Then
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
        If ([Date].Trim().IndexOf("&nbsp;") > -1 Or [Date].Trim() = "" Or [Date].Trim() = "1/1/1900" Or [Date].Trim() = "01/01/1900") Then Return ""
        Dim d As DateTime = Nothing
        Dim CurrentCulture As System.Globalization.CultureInfo

        Dim lg As New ReportFunctions
        d = lg.SetDate(CurrentCulture, [Date])

        Return String.Format(CurrentCulture, "{0:d}", d)

    End Function

    Public Shared Function FormatLongDateTime(ByVal [Date] As String) As String
        If ([Date].Trim().IndexOf("&nbsp;") > -1 Or [Date].Trim() = "") Then Return ""
        Dim d As DateTime = Nothing
        Dim CurrentCulture As System.Globalization.CultureInfo

        Dim lg As New ReportFunctions
        d = lg.SetDate(CurrentCulture, [Date])

        Return String.Format(CurrentCulture, "{0:D}", d)

    End Function

    Public Shared Function FormatDateTime(ByVal [Date] As String, Optional ByVal IncludeTime As Boolean = True) As String
        If ([Date].Trim().IndexOf("&nbsp;") > -1 Or [Date].Trim() = "") Then Return ""
        Try
            Dim d As DateTime = Nothing
            Dim CurrentCulture As System.Globalization.CultureInfo

            Dim lg As New ReportFunctions
            d = lg.SetDate(CurrentCulture, [Date])

            'If ReturnLongDateTimeString = True Then
            '    Return String.Format(CurrentCulture, "{0:D}", d)
            'End If
            'If IncludeTime = True Then
            Return String.Format(CurrentCulture, "{0:g}", d)
            'Else
            '    Return String.Format(CurrentCulture, "{0:d}", d)
            'End If

        Catch ex As Exception
            Return [Date]
        End Try
    End Function

    Private Function SetDate(ByRef ci As System.Globalization.CultureInfo, ByVal [Date] As String) As Date
        If ([Date].Trim().IndexOf("&nbsp;") > -1 Or [Date].Trim() = "") Then Return Nothing
        Try
            Dim d As DateTime = Nothing

            Dim CultureCode As String = ""
            'Dim CurrentCulture As System.Globalization.CultureInfo

            With HttpContext.Current.Request
                If Not .Cookies("LoGloCode") Is Nothing And Not .Cookies("LoGloCode").Value Is Nothing Then
                    CultureCode = .Cookies("LoGloCode").Value
                Else
                    CultureCode = "en-US"
                    ReportFunctions.UserCultureSet(CultureCode)
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

    Public Shared Function IsEnglish() As Boolean
        Try
            Return ReportFunctions.UserCultureGet() = "en-US"
        Catch ex As Exception
            Return True
        End Try
    End Function

    Public Shared Sub UserCultureSet(Optional ByVal CultureCode As String = "en-US")
        With HttpContext.Current.Response
            .Cookies("LoGloCode").Value = CultureCode
            .Cookies("LoGloCode").Expires = DateTime.Now.AddYears(1)
        End With
    End Sub

    Public Shared Function UserCultureGet() As String
        Try
            With HttpContext.Current.Request
                If Not .Cookies("LoGloCode") Is Nothing And Not .Cookies("LoGloCode").Value Is Nothing Then
                    Return .Cookies("LoGloCode").Value.ToString().Trim()
                Else
                    Return "en-US"
                End If
            End With
        Catch ex As Exception
            Return "en-US"
        End Try

    End Function

End Class
