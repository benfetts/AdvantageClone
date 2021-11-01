Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient

Public Class arptEstHeaderSS1
    Public estnum As Integer
    Public estcompnum As Integer
    Public quotenum As Integer
    Public revnum As Integer
    Public estdate As String
    Public page As String
    Public dt As DataTable
    Public addressOption As String
    Public addressInfo As DataTable
    Public dtPrintDef As DataTable
    Public connstring As String
    Public client As String = ""
    Public division As String = ""
    Public product As String = ""
    Public jobcontact As String = ""

    Public CultureCode As String = "en-US"
    Private Sub arptEstHeader_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            'Dim est As String = estnum.ToString & "/" & quotenum.ToString
            Dim dv As DataView = New DataView(dt)
            dv.RowFilter = "EST_QUOTE_NBR = '" & quotenum.ToString & "'"
            dt = dv.ToTable()
            Me.DataSource = dt
        Catch ex As Exception

        End Try

    End Sub


    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
           
        Catch ex As Exception

        End Try
    End Sub
End Class
