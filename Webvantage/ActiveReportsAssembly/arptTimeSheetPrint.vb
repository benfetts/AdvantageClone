Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class arptTimeSheetPrint 

    Public dt As DataTable
    Public EmpName As String
    Public EmpCode As String
    Public StartDate As DateTime
    Public EndDate As DateTime
    Public totalHours As Decimal
    Public prodcat As Boolean
    Public SigImage As System.Drawing.Image
    Public UseEmpSig As Boolean
    Public CultureCode As String = "en-US"

    Public UserCode As String = ""
    Public ConnectionString As String = ""

    Private DivisionLabel As String = ""
    Private ProductLabel As String = ""
    Private ProdCatLabel As String = ""
    Private JobLabel As String = ""
    Private JobComponentLabel As String = ""
    Private FuncCatLabel As String = ""

    Private Sub arptTimeSheetPrint_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

        ReportFunctions.SetCulture(Me, CultureCode)
        Me.DataSource = dt

        If Me.ConnectionString <> "" And Me.UserCode <> "" Then
            Dim s As String = ""
            Dim ts As New AdvantageFramework.Timesheet.TimesheetSettings(Me.ConnectionString, Me.UserCode)
            Dim settings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
            settings = ts.GetSettings(Me.UserCode, s)
            If Not settings Is Nothing Then
                With settings.Labels
                    Me.DivisionLabel = .Division
                    Me.ProductLabel = .Product
                    Me.ProdCatLabel = .ProdCat
                    Me.JobLabel = .Job
                    Me.JobComponentLabel = .JobComponent
                    Me.FuncCatLabel = .FuncCat
                End With
                'put the xxxLabel variables to the header 
                Me.TextBoxDivision.Text = Me.DivisionLabel
                Me.TextBoxProduct.Text = Me.ProductLabel
                Me.TextBoxJob.Text = Me.JobLabel
                Me.TextBoxJobComp.Text = Me.JobComponentLabel
                Me.TextBoxFuncCat.Text = Me.FuncCatLabel
            Else
                'error; display s somewhere
            End If
        End If

    End Sub

    Private Sub PageFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageFooter1.Format
        Me.lblDates.Text = "For Dates " & Me.StartDate.ToShortDateString & " thru " & Me.EndDate.ToShortDateString
        Me.lblEmpCode.Text = "Timesheet for (" & EmpCode & ") " & EmpName
    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format
        Me.lblTotal.Text = "Total for " & Convert.ToDateTime(Me.lblDate.Text).ToShortDateString & ":  "
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Me.lblGrandTotal.Text = "Total for " & EmpName & ":  "
    End Sub

    Private Sub GroupHeader3_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader3.Format
        Me.lblDate.Text = Convert.ToDateTime(Me.lblDate.Text).ToShortDateString
    End Sub
    Private Sub GroupFooter1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format

        Try

            If UseEmpSig Then

                Me.EmpSigPic.Image = SigImage
                Me.LabelDate.Text = Now.ToShortDateString

            End If

        Catch ex As Exception

        End Try

    End Sub

End Class
