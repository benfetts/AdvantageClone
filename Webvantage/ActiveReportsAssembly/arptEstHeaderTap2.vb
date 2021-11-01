Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient

Public Class arptEstHeaderTap2
    Public estnum As Integer
    Public estcompnum As Integer
    Public quotenum As Integer
    Public revnum As Integer
    Public estdate As String
    Public page As String
    Public dt As DataTable
    Public dtInfo As DataTable
    Public addressOption As String
    Public addressInfo As DataTable
    Public dtPrintDef As DataTable
    Public mConnString As String
    Public client As String = ""
    Public division As String = ""
    Public product As String = ""
    Public jobcontact As String = ""
    Public rpttype As String
    Public job As Integer
    Public comp As Integer
    Public cmpname As String = ""
    Public ae As String = ""

    Public CultureCode As String = "en-US"
    Private Sub arptEstHeader_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'Me.DataSource = dt
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            Dim strCSZ As String = ""
            Me.TextBox17.Text = ae
            Me.TextBox18.Text = cmpname
            Me.TextBox10.Text = Now.Date.ToShortDateString

        Catch ex As Exception

        End Try

    End Sub
End Class
