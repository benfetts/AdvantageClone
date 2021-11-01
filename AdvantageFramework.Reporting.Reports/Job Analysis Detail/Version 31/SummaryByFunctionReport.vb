Imports DevExpress.XtraReports.UI

Namespace JobAnalysisDetail.Version31

    Public Class SummaryByFunctionReport
        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _UserDefinedReportID As Integer = 0

        Dim _TotalEmployeeTimeQuote As Decimal = 0.0
        Dim _TotalEmployeeTimeAmount As Decimal = 0.0

        Dim _TotalJobQuote As Decimal = 0.0
        Dim _TotalJobAmount As Decimal = 0.0

        Dim _TotalEmployeeTimeQuoteClient As Decimal = 0.0
        Dim _TotalEmployeeTimeAmountClient As Decimal = 0.0

        Dim _TotalJobQuoteClient As Decimal = 0.0
        Dim _TotalJobAmountClient As Decimal = 0.0



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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV31
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource1
            End Get
        End Property

        Private Sub XrLabel41_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel41.SummaryRowChanged

            _TotalEmployeeTimeQuote += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Database.Classes.JobDetailAnalysisQVA.Properties.SumOfEstimateNetEmployeeTime.ToString))
            _TotalJobQuote += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Database.Classes.JobDetailAnalysisQVA.Properties.SumOfEstimateNet.ToString))

        End Sub
        Private Sub XrLabel41_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel41.SummaryReset

            _TotalEmployeeTimeQuote = 0
            _TotalJobQuote = 0

        End Sub
        Private Sub XrLabel41_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel41.SummaryGetResult

            If _TotalJobQuote <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalEmployeeTimeQuote / _TotalJobQuote))

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel43_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel43.SummaryRowChanged

            _TotalEmployeeTimeAmount += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Database.Classes.JobDetailAnalysisQVA.Properties.SumOfActualNetEmployeeTime.ToString))
            _TotalJobAmount += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Database.Classes.JobDetailAnalysisQVA.Properties.SumOfActualNet.ToString))

        End Sub
        Private Sub XrLabel43_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel43.SummaryReset

            _TotalEmployeeTimeAmount = 0
            _TotalJobAmount = 0

        End Sub
        Private Sub XrLabel43_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel43.SummaryGetResult

            If _TotalJobAmount <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalEmployeeTimeAmount / _TotalJobAmount))

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub

        Private Sub XrLabel44_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel44.SummaryRowChanged

            _TotalEmployeeTimeQuoteClient += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Database.Classes.JobDetailAnalysisQVA.Properties.SumOfEstimateNetEmployeeTime.ToString))
            _TotalJobQuoteClient += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Database.Classes.JobDetailAnalysisQVA.Properties.SumOfEstimateNet.ToString))

        End Sub

        Private Sub XrLabel44_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel44.SummaryReset

            _TotalEmployeeTimeQuoteClient = 0
            _TotalJobQuoteClient = 0

        End Sub

        Private Sub XrLabel44_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel44.SummaryGetResult

            If _TotalJobQuoteClient <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalEmployeeTimeQuoteClient / _TotalJobQuoteClient))

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub

        Private Sub XrLabel46_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel46.SummaryRowChanged

            _TotalEmployeeTimeAmountClient += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Database.Classes.JobDetailAnalysisQVA.Properties.SumOfActualNetEmployeeTime.ToString))
            _TotalJobAmountClient += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Database.Classes.JobDetailAnalysisQVA.Properties.SumOfActualNet.ToString))

        End Sub

        Private Sub XrLabel46_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel46.SummaryReset

            _TotalEmployeeTimeAmountClient = 0
            _TotalJobAmountClient = 0

        End Sub

        Private Sub XrLabel46_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel46.SummaryGetResult

            If _TotalJobAmountClient <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalEmployeeTimeAmountClient / _TotalJobAmountClient))

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub


#End Region


        'Private Sub XrSubreport1_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs)

        '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '        Me.XrSubreport1.ReportSource.DataSource = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.JobDetailAnalysisQVADetail)(String.Format("EXEC [dbo].[advsp_job_detail_analysis_qva_detail_load] {0}, {1}, '{2}'", Convert.ToInt32(Me.GetCurrentColumnValue("JobNumber")), Convert.ToInt32(Me.GetCurrentColumnValue("JobComponentNumber")), Me.GetCurrentColumnValue("FunctionCode"))).ToList

        '    End Using

        'End Sub

    End Class

End Namespace






