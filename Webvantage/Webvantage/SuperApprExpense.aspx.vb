'This page is needed for old expense approval alerts prior to blue
Public Class SuperApprExpense
    Inherits Webvantage.BaseChildPage

    Private Sub SuperApprExpense_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs.PassThroughTo("SupervisorApproval_Expense.aspx")
    End Sub

End Class