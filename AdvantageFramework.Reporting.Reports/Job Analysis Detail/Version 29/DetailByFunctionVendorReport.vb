Namespace JobAnalysisDetail.Version29

    Public Class DetailByFunctionVendorReport
        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

#End Region

#Region " Properties "

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV29
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property

#End Region

        Private Sub XrSubreport3_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrSubreport3.BeforePrint

            CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, AdvancedBillingHistorySubReport).JobNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber"))

            CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, AdvancedBillingHistorySubReport).JobComponentNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber"))

            If TypeOf Me.XrSubreport3.ReportSource.DataSource Is Generic.List(Of AdvantageFramework.Database.Classes.AdvancedBillingHistory) Then

                If DirectCast(Me.XrSubreport3.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.AdvancedBillingHistory)).Any(Function(ABH) ABH.JobNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber")) AndAlso ABH.JobComponentNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber"))) Then

                    XrSubreport3.Visible = True

                Else

                    XrSubreport3.Visible = False

                End If

            End If

        End Sub

    End Class

End Namespace







