Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Partial Public Class taskEmployees
    Inherits Webvantage.BaseChildPage

    Public JobNumber As Integer = 0
    Public JobCompNumber As Integer = 0
    Public SeqNum As Integer = 0
    Public EmpCode As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.JobNumber = Request.QueryString("JobNo")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNo")
            Me.EmpCode = Request.QueryString("EmplCode")

            If Me.EmpCode = "" Then
                Me.EmpCode = Session("EmpCode")
            End If
        End If
    End Sub

    Private Sub RadGridEmployees_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEmployees.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
            Dim str As String = e.Item.Cells(0).Text
            Dim str2 As String = e.Item.Cells(1).Text
            Dim str3 As String = e.Item.Cells(2).Text

            If e.Item.Cells(4).Text <> "" Then
                If e.Item.Cells(4).Text.Trim = "1/1/1900 12:00:00 AM" Then
                    e.Item.Cells(4).Text = ""
                Else
                    e.Item.Cells(4).Text = CDate(e.Item.Cells(4).Text).ToShortDateString
                End If
            End If
        End If

    End Sub

    Private Sub RadGridEmployees_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEmployees.NeedDataSource
        Dim dr As SqlDataReader
        Dim oTasks As cTasks = New cTasks(CStr(Session("ConnString")))
        dr = oTasks.GetTaskEmployees(Me.JobNumber, Me.JobCompNumber, Me.SeqNum, Me.EmpCode)
        Me.RadGridEmployees.DataSource = dr
    End Sub

End Class