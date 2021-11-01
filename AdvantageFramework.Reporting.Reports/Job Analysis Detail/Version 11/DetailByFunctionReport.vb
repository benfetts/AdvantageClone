Namespace JobAnalysisDetail.Version11

    Public Class DetailByFunctionReport
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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV11Detail
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property

#End Region

        Private Sub XrSubreport1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreport1.BeforePrint

            If TypeOf Me.XrSubreport1.ReportSource.DataSource Is Generic.List(Of AdvantageFramework.Database.Classes.AdvanceReconciliationReport) Then

                If DirectCast(Me.XrSubreport1.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.AdvanceReconciliationReport)).Any(Function(ABH) ABH.JobNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber")) AndAlso ABH.JobComponentNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber"))) Then

                    CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, AdvanceReconciliationHistorySubReport).JobNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber"))

                    CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, AdvanceReconciliationHistorySubReport).JobComponentNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber"))

                    XrSubreport1.Visible = True

                ElseIf DirectCast(Me.XrSubreport1.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.AdvanceReconciliationReport)).Any(Function(ABH) ABH.JobNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber"))) Then

                    CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, AdvanceReconciliationHistorySubReport).JobNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber"))

                    CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, AdvanceReconciliationHistorySubReport).JobComponentNumb.Value = 0

                    XrSubreport1.Visible = True

                Else

                    XrSubreport1.Visible = False

                End If

            End If

        End Sub

        Private Sub XrSubreport2_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrSubreport2.BeforePrint

            If TypeOf Me.XrSubreport2.ReportSource.DataSource Is Generic.List(Of AdvantageFramework.Database.Classes.BillingPaymentsReport) Then

                If DirectCast(Me.XrSubreport2.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.BillingPaymentsReport)).Any(Function(ABH) ABH.JobNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber")) AndAlso ABH.JobComponentNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber"))) Then

                    CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, BillingHistorySubReport).JobNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber"))

                    CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, BillingHistorySubReport).JobComponentNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber"))

                    XrSubreport2.Visible = True

                ElseIf DirectCast(Me.XrSubreport2.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.BillingPaymentsReport)).Any(Function(ABH) ABH.JobNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber"))) Then

                    CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, BillingHistorySubReport).JobNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber"))

                    CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, BillingHistorySubReport).JobComponentNumb.Value = 0

                    XrSubreport2.Visible = True

                Else

                    XrSubreport2.Visible = False

                End If

            End If
        End Sub

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







