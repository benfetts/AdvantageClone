Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports System.Data.SqlClient
Imports Webvantage

Public Class arptEstHeaderQuarry
    Public estnum As Integer
    Public estcompnum As Integer
    Public quotenum As String
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
    Public rpttype As String = ""

    Public CultureCode As String = "en-US"
    Private Sub arptEstHeader_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        ReportFunctions.SetCulture(Me, CultureCode)
        Try
            'Dim est As String = estnum.ToString & "/" & quotenum.ToString
            Dim dv As DataView = New DataView(dt)
            dv.RowFilter = "CMPQUOTE = '" & quotenum.ToString & "'"
            dt = dv.ToTable()
            Me.DataSource = dt
            If rpttype = "EstimatingTAP" Or rpttype = "EstimatingTAP2" Then
                Me.GroupHeader1.Visible = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Detail1_BeforePrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.BeforePrint
        Try
            Me.txtTotalForEst.Text = String.Format("{0:#,##0.00}", CDec(Me.txtTotalForEst.Text))
            Me.TextBox3.Text = String.Format("{0:#,##0.00}", CDec(Me.TextBox3.Text))
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            Me.txtJC.Text = Me.txtJob.Text.PadLeft(6, "0") & " - " & Me.txtComp.Text.PadLeft(2, "0")
            Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtMarkupAmtGrouping.Text)

            If rpttype = "EstimatingTAP" Or rpttype = "EstimatingTAP2" Then
                Me.TextBoxCompDesc.Visible = True
                Me.TextBox3.Visible = True
                Me.TextBox3.Text = CDec(Me.TextBox3.Text) + CDec(Me.txtMarkupAmtGrouping.Text)
                Me.txtTotalForEst.Text = CDec(Me.txtTotalForEst.Text) + CDec(Me.txtTax.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_BeforePrint(sender As Object, e As System.EventArgs) Handles GroupFooter1.BeforePrint
        Try
            Me.TextBox1.Text = String.Format("{0:#,##0.00}", CDec(Me.TextBox1.Text))
            Me.TextBox4.Text = String.Format("{0:#,##0.00}", CDec(Me.TextBox4.Text))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub GroupFooter1_Format(sender As Object, e As System.EventArgs) Handles GroupFooter1.Format
        Try
            If rpttype = "EstimatingTAP" Or rpttype = "EstimatingTAP2" Then
                Me.TextBox4.Visible = True
                Me.TextBox4.Text = CDec(Me.TextBox4.Text) + CDec(Me.TextBoxMarkup.Text)
                Me.TextBox1.Text = CDec(Me.TextBox1.Text) + CDec(Me.txtTaxTotal.Text) + CDec(Me.TextBoxMarkup.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
