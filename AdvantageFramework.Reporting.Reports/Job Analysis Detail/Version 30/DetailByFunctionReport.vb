Namespace JobAnalysisDetail.Version30

    Public Class DetailByFunctionReport
        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _UserDefinedReportID As Integer = 0

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV30Detail
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource1
            End Get
        End Property

#End Region


        Private Sub XrSubreport1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreport1.BeforePrint

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.XrSubreport1.ReportSource.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.JobDetailAnalysisQVADetail)(String.Format("EXEC [dbo].[advsp_job_detail_analysis_qva_detail_load] {0}, {1}, '{2}'", Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber")), Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber")), Me.GetCurrentColumnValue("FunctionCode"))).ToList

            End Using

        End Sub

    End Class

End Namespace






