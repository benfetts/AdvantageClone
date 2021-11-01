Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient
Imports Webvantage
Imports System
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports System.Xml

Public Class arptPOHeader
    Public dtData As DataTable
    Public PODate As String
    Public LogoID As String
    Public CultureCode As String = "en-US"
    Private Sub arptCBHeader1_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        'Me.DataSource = dtData.Rows(0)
    End Sub

    Private Sub Detail1_Format(sender As Object, e As System.EventArgs) Handles Detail1.Format
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            If dtData.Rows.Count > 0 Then
                Me.txtClientName.Text = dtData.Rows(0)("CL_NAME")
                If Me.LogoID <> "" Then
                    Me.txtAgent.Text = LogoID
                Else
                    Me.txtAgent.Text = dtData.Rows(0)("AGENCY_NAME")
                End If
                Me.txtPONumber.Text = dtData.Rows(0)("PO_NUMBER")
                Me.txt_due_date.Text = dtData.Rows(0)("PO_DUE_DATE")
                Me.txt_Issue_Date.Text = dtData.Rows(0)("PO_DATE")
                Me.txt_IssueBy.Text = dtData.Rows(0)("ISSUE_BY")
            End If
            If Me.PODate <> "" Then
                Me.txt_Issue_Date.Text = PODate
            Else
                If Me.txt_Issue_Date.Text.Trim <> "" Then
                    Me.txt_Issue_Date.Text = CDate(Me.txt_Issue_Date.Text).ToShortDateString
                End If
            End If
            If Me.txt_due_date.Text.Trim <> "" Then
                Me.txt_due_date.Text = CDate(Me.txt_due_date.Text).ToShortDateString
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
