Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Public Class Expense
    Inherits Webvantage.BaseChildPage

    Private Sub Expense_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()
        qs.PassThroughTo("Expense_V2.aspx")

    End Sub

End Class