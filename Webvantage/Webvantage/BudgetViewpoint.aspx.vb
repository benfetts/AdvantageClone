Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Imports Webvantage.cGlobals

Partial Public Class BudgetViewpoint
    Inherits Webvantage.BaseChildPage
    Public printJS As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '

        If Not Me.IsPostBack Then
            'printJS = "Javascript:window.open('dtp_BudgetViewpoint.aspx 'PopLookup','screenX=150,left=150,screenY=150,top=150,width=785,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;"
            'Me.PrintImage.Attributes.Add("onclick", printJS)

            'If Not Session("ProjectViewpointGroup") Is Nothing Then
            '    Me.ddGroupBy.SelectedValue = Session("ProjectViewpointGroup")
            'End If
            Session("ProjectViewpointGroup") = Me.ddGroupBy.SelectedValue

            Me.RadGridBudgetViewpoint.Rebind()


        End If

    End Sub

    Private Sub RadGridBudgetViewpoint_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBudgetViewpoint.NeedDataSource
        Dim oPV As cProjectViewpoint = New cProjectViewpoint()
        Dim month, year As String
        Dim cdpLevel As Integer
        Dim startDate As Date

        'If Not Request.Cookies("PVMonth") Is Nothing And Not Request.Cookies("PVMonth").Value Is Nothing Then
        '    month = Request.Cookies("PVMonth").Value
        '    If Not Request.Cookies("PVYear") Is Nothing And Not Request.Cookies("PVYear").Value Is Nothing Then
        '        year = Request.Cookies("PVYear").Value
        '    End If
        'Else
        If Not Session("startDatePV") Is Nothing Then
            startDate = Session("startDatePV")
        Else
            startDate = Date.Today
        End If
        'End If

        month = startDate.Month.ToString.PadLeft(2, "0")
        year = startDate.Year.ToString.PadLeft(4, "0")

        cdpLevel = Me.ddGroupBy.SelectedValue   '1-All	2-Type	3-Sales Class

        'Me.PVRadGrid.DataSource = oPV.getBudgetViewpoint(month, year, cdpLevel)
        Me.RadGridBudgetViewpoint.DataSource = oPV.getBudgetViewpoint(cdpLevel)

    End Sub

    Private Sub ddGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGroupBy.SelectedIndexChanged
        Session("ProjectViewpointGroup") = Me.ddGroupBy.SelectedValue   'needed for print report
        Me.RadGridBudgetViewpoint.Rebind()
    End Sub

    Private Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
        With sbScript
            .Append("<script type=""text/javascript"">")
            .Append("window.close();</script>")
        End With
        Try
            If Not Page.IsStartupScriptRegistered("BVBack") Then
                Dim str As String = sbScript.ToString
                Page.RegisterStartupScript("BVBack", str)
            End If
        Catch ex As Exception
            Me.ShowMessage("Error! " & ex.Message.ToString())
        End Try
    End Sub
End Class