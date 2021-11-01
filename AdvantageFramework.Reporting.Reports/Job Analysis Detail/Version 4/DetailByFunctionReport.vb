Imports System.Drawing.Printing

Namespace JobAnalysisDetail.Version4

    Public Class DetailByFunctionReport
        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _Grouping As String = ""

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV4Detail
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public WriteOnly Property Grouping As String
            Set(value As String)
                _Grouping = value
            End Set
        End Property

#End Region

        Private Sub XrSubreport1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreport1.BeforePrint

            CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, AdvancedBillingHistorySubReport).JobNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber"))

            CType((CType(sender, DevExpress.XtraReports.UI.XRSubreport)).ReportSource, AdvancedBillingHistorySubReport).JobComponentNumb.Value = Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber"))

            If TypeOf Me.XrSubreport1.ReportSource.DataSource Is Generic.List(Of AdvantageFramework.Database.Classes.AdvancedBillingHistory) Then

                If DirectCast(Me.XrSubreport1.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.AdvancedBillingHistory)).Any(Function(ABH) ABH.JobNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber")) AndAlso ABH.JobComponentNumber = Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber"))) Then

                    XrSubreport1.Visible = True

                Else

                    XrSubreport1.Visible = False

                End If

            End If

        End Sub

        Private Sub DetailByFunctionReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
            If _Grouping <> "AccountExecutive" Then

                Me.GroupHeader4.GroupFields.Clear()
                Me.GroupHeader4.Visible = False
                Me.GroupFooter5.Visible = False

            Else

                Me.LabelPageHeader_SortBy.Text = "Sorted by Account Executive "

            End If
        End Sub
    End Class

End Namespace







