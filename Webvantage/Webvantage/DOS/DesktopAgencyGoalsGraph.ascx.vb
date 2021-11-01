Imports System
Imports System.Text
Imports System.Data
Imports System.Data.DataRow
Imports System.Data.SqlClient
Imports System.Xml
Imports Microsoft.VisualBasic
Imports Webvantage.MiscFN
Imports System.Collections.Generic

Partial Public Class DesktopAgencyGoalsGraph
    Inherits Webvantage.BaseDesktopObject


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Check Agency Maintenance Setting
        Dim agy_setting As Int16
        agy_setting = getAgencySetting()

        If agy_setting <> 1 Then
            'Do not display data
            Me.DivObject.Visible = False
            Exit Sub

        Else

            If Not Page.IsPostBack Then

                LoadDropDowns()
                GetCurrentPP()
                LoadData()

            End If

        End If

    End Sub

    Private Function getAgencySetting() As Int16

        Dim AgySetting As Int16
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        AgySetting = oDO.GetAgencySetting("AGENCY_GOALS_ON")
        Return AgySetting

    End Function

    Private Sub LoadDropDowns()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.ddPPBegin

            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()

        End With

        With Me.ddPPEnd

            .DataSource = oDD.GetPostperiods
            .DataValueField = "PPPERIOD"
            .DataTextField = "PPPERIOD"
            .DataBind()

        End With

        With Me.ddOffice

            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataValueField = "Code"
            .DataTextField = "Description"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))

        End With

        Session("OFFICE_AGLSG") = ""

    End Sub

    Private Function GetCurrentPP() As String

        Dim currentPeriod, firstPeriod As String
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))

        firstPeriod = oDO.getStartPeriod()
        currentPeriod = oDO.getEndPeriod()

        Me.ddPPBegin.SelectedValue = firstPeriod
        Me.ddPPEnd.SelectedValue = currentPeriod
        Session("PPBEGIN_AGLSG") = firstPeriod
        Session("PPEND_AGLSG") = currentPeriod

    End Function

    Public Shared Function LoadChart(ByRef Chart As Telerik.Web.UI.RadHtmlChart, ByVal StartPostPeriod As String, ByVal EndPostPeriod As String,
                                     ByVal OfficeCode As String, Optional ByRef ErrorMessage As String = "") As Boolean

        Dim DtGraphData As New DataTable
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(HttpContext.Current.Session("ConnString")))
        Dim descr As String
        Dim amt, total_amt As Double
        Dim goal_pct As Decimal

        Dim Colors As New AdvantageFramework.Web.Presentation.Colors
        Dim StandardColors As List(Of String)

        StandardColors = Colors.LoadBaseColors()

        If StartPostPeriod > EndPostPeriod Then

            ErrorMessage = "Please enter valid Periods"
            Return False

        End If

        HttpContext.Current.Session("PPBEGIN_AGLSG") = StartPostPeriod
        HttpContext.Current.Session("PPEND_AGLSG") = EndPostPeriod
        HttpContext.Current.Session("OFFICE_AGLSG") = OfficeCode

        If OfficeCode = "All" Then

            OfficeCode = ""

        End If

        Try

            DtGraphData = oDO.GetAgencyGoals(StartPostPeriod, EndPostPeriod, OfficeCode, HttpContext.Current.Session("UserCode"))

        Catch ex As Exception

            ErrorMessage = ex.Message.ToString()
            Return False

        End Try

        If DtGraphData IsNot Nothing AndAlso DtGraphData.Rows.Count > 0 Then

            Dim Charting As New AdvantageFramework.Web.Presentation.Charting

            'Need to add loglo formatting for currency symbol and number format
            Charting.AddChartColumn(Chart, "Billing", CDec(DtGraphData.Rows(0).Item(1)) / 1000000, AdvantageFramework.Web.Presentation.Colors.Color.Red)
            Charting.AddChartColumn(Chart, "Gross Income", CDec(DtGraphData.Rows(1).Item(1)) / 1000000, AdvantageFramework.Web.Presentation.Colors.Color.Blue)
            Charting.AddChartColumn(Chart, "Operating Expense", CDec(DtGraphData.Rows(2).Item(1)) / 1000000, AdvantageFramework.Web.Presentation.Colors.Color.Cyan)
            Charting.AddChartColumn(Chart, "Payroll", CDec(DtGraphData.Rows(3).Item(1)) / 1000000, AdvantageFramework.Web.Presentation.Colors.Color.Orange)
            Charting.AddChartColumn(Chart, "Overhead", CDec(DtGraphData.Rows(4).Item(1)) / 1000000, AdvantageFramework.Web.Presentation.Colors.Color.Teal)
            Charting.AddChartColumn(Chart, "Net Profit", CDec(DtGraphData.Rows(5).Item(1)) / 1000000, AdvantageFramework.Web.Presentation.Colors.Color.Gray)

        End If

        Return True

    End Function

    'Public Function WriteURL() As String
    '    Dim str As String = getFCXMLData_BarPie_agencyGoals(DtGraphData, "", False)
    '    Return str
    'End Function
    'Public Shared Function getFCXMLData_BarPie_agencyGoals(ByVal DtForGraph As DataTable, Optional ByVal strCaption As String = "", Optional ByVal isPie As Boolean = False) As String
    '    Try
    '        Dim strFCXMLData As String
    '        Dim sbFCXMLData As StringBuilder = New StringBuilder
    '        Dim strColor(10) As String
    '        strColor(0) = "D00000" '"AFD8F8" 'Baby blue
    '        strColor(1) = "F6BD0F" 'gold
    '        strColor(2) = "A66EDD" 'purple
    '        strColor(3) = "8BBA00" 'green
    '        strColor(4) = "FF8000" 'orange
    '        strColor(5) = "AFD8F8" 'baby blue
    '        strColor(6) = "999999" 'gray
    '        strColor(7) = "005500" 'dark green
    '        strColor(8) = "AA0000" 'dark red
    '        strColor(9) = "0372AB" 'darker blue

    '        With sbFCXMLData
    '            'Initialize the XML String
    '            If LoGlo.UserCultureGet() = "fr-FR" Then
    '                .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300' inThousandSeparator=' ' inDecimalSeparator=',' thousandSeparator=' ' decimalSeparator=','>" & vbCrLf)
    '            ElseIf LoGlo.UserCultureGet() <> "en-US" And LoGlo.UserCultureGet <> "zh-CN" Then
    '                .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300' inThousandSeparator='.' inDecimalSeparator=',' thousandSeparator='.' decimalSeparator=','>" & vbCrLf)
    '            Else
    '                .Append("<graph caption='" & strCaption & "' bgColor='FFFFFF' decimalPrecision='2' showPercentageValues='0' showNames='1' numberPrefix='$' numberSuffix='' showValues='0' showPercentageInLabel='1' pieYScale='30' pieBorderAlpha='40' pieFillAlpha='70' pieSliceDepth='35' pieRadius='300'>" & vbCrLf)
    '            End If
    '            .Append("<set name='Billing' value='" & DtForGraph.Rows(0).Item(1) & "' color='" & strColor(0 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Gross Income' value='" & DtForGraph.Rows(1).Item(1) & "' color='" & strColor(1 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Operating Expense' value='" & DtForGraph.Rows(2).Item(1) & "' color='" & strColor(2 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Payroll' value='" & DtForGraph.Rows(3).Item(1) & "' color='" & strColor(3 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Overhead' value='" & DtForGraph.Rows(4).Item(1) & "' color='" & strColor(4 Mod 10) & "'/>" & vbCrLf)
    '            .Append("<set name='Net Profit' value='" & DtForGraph.Rows(5).Item(1) & "' color='" & strColor(5 Mod 10) & "'/>" & vbCrLf)

    '            .Append("</graph>")
    '        End With

    '        strFCXMLData = cleanString(sbFCXMLData.ToString())

    '        Return strFCXMLData

    '    Catch ex As Exception
    '        Return "getFCXMLData_BarPie_agencyGoals Error: " & ex.Message.ToString
    '        Exit Function
    '    End Try
    'End Function
    'Public Shared Function cleanString(ByVal str As String) As String
    '    str = str.Replace("&", " and ")
    '    str = str.Replace("n's", "ns")
    '    str = str.Replace("12:00:00 AM", "")
    '    Return str
    'End Function

    Private Sub LoadData()

        Dim s As String
        If LoadChart(Me.RadHtmlChartAgencyGoals, Me.ddPPBegin.SelectedValue, Me.ddPPEnd.SelectedValue, Me.ddOffice.SelectedValue, s) = False Then

            Me.ShowMessage(s)

        End If

    End Sub
    Private Sub butRefresh_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefresh.Click

        LoadData()

    End Sub
    Private Sub ddOffice_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddOffice.SelectedIndexChanged

        LoadData()

    End Sub
    Private Sub ddPPBegin_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPBegin.SelectedIndexChanged

        LoadData()

    End Sub
    Private Sub ddPPEnd_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles ddPPEnd.SelectedIndexChanged

        LoadData()

    End Sub

    Private Sub ImageButtonBookmark_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonBookmark.Click
        Try
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            qs = qs.FromCurrent()

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.FinanceAccounting_AgencyGoalsGraph
                .UserCode = Session("UserCode")
                .Name = "Agency Goals Graph"
                .Description = "Agency Goals Graph"
                .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            Else
                Me.RefreshBookmarksDesktopObject()

            End If
        Catch ex As Exception

        End Try
    End Sub

End Class
