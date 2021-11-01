Namespace GeneralLedger

    Public Class GLReportWriterAccountReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _AgencyName As String = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub AccountPayableBatchDetailReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _AgencyName = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName
            LabelPageHeader_TemplateName.Text = DirectCast(Me.GetCurrentRow(), AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport).ReportTemplateDescription

        End Sub
        Private Sub DetailReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReport.BeforePrint

            If DirectCast(Me.GetCurrentRow(), AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport).GLReportWriterAccountReportList Is Nothing OrElse
                    DirectCast(Me.GetCurrentRow(), AdvantageFramework.GeneralLedger.ReportWriter.Classes.GLReportWriterGLRowFormatReport).GLReportWriterAccountReportList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
