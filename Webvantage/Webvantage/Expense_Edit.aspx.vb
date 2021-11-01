Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN

Partial Public Class Expense_Edit
    Inherits Webvantage.BaseChildPage

    Private Sub Expense_Edit_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        qs.PassThroughTo("Expense_Edit_V2.aspx")

    End Sub

End Class