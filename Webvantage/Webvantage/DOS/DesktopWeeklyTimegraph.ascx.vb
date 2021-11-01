Imports System.Data.SqlClient
Imports cCharting
Imports Webvantage.wvTimeSheet

Public Class DesktopWeeklyTimegraph
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private DtGraphData As New DataTable

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ImageButtonRefresh_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRefresh.Click

        'LoadGraph()

    End Sub

#End Region
#Region " Page "

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If Not Me.IsPostBack Then

        LoadGraph()

        'End If
    End Sub

#End Region

    Private Sub LoadGraph()

        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        DtGraphData = oDO.GetTimesheetDTO(Session("EmpCode"))
        cCharting.GetBarChart_TimeGraph(RadHtmlChartWeeklyTimeGraph, DtGraphData, "")

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Me.DivTimeWarnings.Visible = oTS.LoadTimeWarning(Me.DivMissingTime, Me.ImageButtonMissingTime)

    End Sub

#End Region

End Class