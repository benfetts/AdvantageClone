Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient

Public Class arptAlertAssignment

    Public page As String
    Public dt As DataTable
    Public dtInfo As DataTable
    Public dtPrintDef As DataTable
    Public mConnString As String
    Public job As Integer
    Public comp As Integer
    Public seq As Integer
    Public StartDateLocation As Drawing.PointF?
    Public DueDateLocation As Drawing.PointF?

    Public CultureCode As String = "en-US"
    Private Sub arptAlertAssignment_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Dim dv As DataView = New DataView(dt)
        dv.RowFilter = "JOB_NUMBER = " & job & " AND JOB_COMPONENT_NBR = " & comp & " AND SEQ_NBR = " & seq
        Me.DataSource = dv.ToTable
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            If Me.txtStartDate.Text <> "" Then
                Me.txtStartDate.Text = CDate(Me.txtStartDate.Text).ToShortDateString
            End If
            If Me.txtDueDate.Text <> "" Then
                Me.txtDueDate.Text = CDate(Me.txtDueDate.Text).ToShortDateString
            End If
            If DueDateLocation.HasValue Then
                txtDueDate.Location = DueDateLocation
            End If
            If StartDateLocation.HasValue Then
                txtStartDate.Location = StartDateLocation
                txtAlertState.Size = New Drawing.SizeF(txtStartDate.Location.X - txtAlertState.Location.X - 0.07, txtAlertState.Size.Height)
            End If
        Catch ex As Exception

        End Try

    End Sub
End Class
