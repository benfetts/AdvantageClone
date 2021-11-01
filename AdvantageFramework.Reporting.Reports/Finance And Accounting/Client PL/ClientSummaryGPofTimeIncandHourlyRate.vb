Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class ClientSummaryGPofTimeIncandHourlyRate
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

        Private _CDPTotalIncomeCDP As Decimal = 0
        Private _CDPTotalGrossIncomeMargin As Decimal = 0
        Private _CDPTotalGrossIncomeNetProfit As Decimal = 0
        Private _CDPTotalGrossIncomeReport As Decimal = 0
        Private _CDPLessOverhead As Decimal = 0
        Private _CDPHours As Decimal = 0

        Private _OfficeTotalIncome As Decimal = 0
        Private _OfficeTotalGrossIncomeMargin As Decimal = 0
        Private _OfficeTotalGrossIncomeNetProfit As Decimal = 0
        Private _OfficeTotalGrossIncomeReport As Decimal = 0
        Private _OfficeLessOverhead As Decimal = 0
        Private _OfficeHours As Decimal = 0

        Private _ReportTotalIncome As Decimal = 0
        Private _ReportTotalGrossIncomeMargin As Decimal = 0
        Private _ReportTotalGrossIncomeNetProfit As Decimal = 0
        Private _ReportTotalGrossIncomeReport As Decimal = 0
        Private _ReportLessOverhead As Decimal = 0
        Private _ReportHours As Decimal = 0

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ClientPL
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property

#End Region

#Region " Methods "

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub XrLabel_MarginPctCDP_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_MarginPctCDP.SummaryGetResult

            If _CDPTotalGrossIncomeMargin <> 0 Then

                e.Result = (_CDPTotalIncomeCDP / _CDPTotalGrossIncomeMargin)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_MarginPctCDP_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_MarginPctCDP.SummaryReset

            _CDPTotalIncomeCDP = 0
            _CDPTotalGrossIncomeMargin = 0

        End Sub
        Private Sub XrLabel_MarginPctCDP_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_MarginPctCDP.SummaryRowChanged

            _CDPTotalIncomeCDP += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _CDPTotalGrossIncomeMargin += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub XrLabel_MarginPctOffice_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_MarginPctOffice.SummaryGetResult

            If _OfficeTotalGrossIncomeMargin <> 0 Then

                e.Result = (_OfficeTotalIncome / _OfficeTotalGrossIncomeMargin)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_MarginPctOffice_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_MarginPctOffice.SummaryReset

            _OfficeTotalIncome = 0
            _OfficeTotalGrossIncomeMargin = 0

        End Sub
        Private Sub XrLabel_MarginPctOffice_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_MarginPctOffice.SummaryRowChanged

            _OfficeTotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _OfficeTotalGrossIncomeMargin += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub XrLabel_MarginPctReport_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_MarginPctReport.SummaryGetResult

            If _ReportTotalGrossIncomeMargin <> 0 Then

                e.Result = (_ReportTotalIncome / _ReportTotalGrossIncomeMargin)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_MarginPctReport_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_MarginPctReport.SummaryReset

            _ReportTotalIncome = 0
            _ReportTotalGrossIncomeMargin = 0

        End Sub
        Private Sub XrLabel_MarginPctReport_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_MarginPctReport.SummaryRowChanged

            _ReportTotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _ReportTotalGrossIncomeMargin += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub XrLabel_NetProfitPctCDP_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_NetProfitPctCDP.SummaryGetResult

            If _CDPTotalGrossIncomeNetProfit <> 0 Then

                e.Result = (_CDPLessOverhead / _CDPTotalGrossIncomeNetProfit)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_NetProfitPctCDP_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_NetProfitPctCDP.SummaryReset

            _CDPLessOverhead = 0
            _CDPTotalGrossIncomeNetProfit = 0

        End Sub
        Private Sub XrLabel_NetProfitPctCDP_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_NetProfitPctCDP.SummaryRowChanged

            _CDPLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))
            _CDPTotalGrossIncomeNetProfit += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub XrLabel_NetProfitPctOffice_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_NetProfitPctOffice.SummaryGetResult

            If _OfficeTotalGrossIncomeNetProfit <> 0 Then

                e.Result = (_OfficeLessOverhead / _OfficeTotalGrossIncomeNetProfit)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_NetProfitPctOffice_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_NetProfitPctOffice.SummaryReset

            _OfficeLessOverhead = 0
            _OfficeTotalGrossIncomeNetProfit = 0

        End Sub
        Private Sub XrLabel_NetProfitPctOffice_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_NetProfitPctOffice.SummaryRowChanged

            _OfficeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))
            _OfficeTotalGrossIncomeNetProfit += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub XrLabel_NetProfitPctReport_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_NetProfitPctReport.SummaryGetResult

            If _ReportTotalGrossIncomeNetProfit <> 0 Then

                e.Result = (_ReportLessOverhead / _ReportTotalGrossIncomeNetProfit)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_NetProfitPctReport_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_NetProfitPctReport.SummaryReset

            _ReportLessOverhead = 0
            _ReportTotalGrossIncomeNetProfit = 0

        End Sub
        Private Sub XrLabel_NetProfitPctReport_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_NetProfitPctReport.SummaryRowChanged

            _ReportLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))
            _ReportTotalGrossIncomeNetProfit += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub XrLabel_RateCDP_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_RateCDP.SummaryGetResult

            If _CDPHours <> 0 Then

                e.Result = (_CDPTotalGrossIncomeReport / _CDPHours)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_RateCDP_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_RateCDP.SummaryReset

            _CDPHours = 0
            _CDPTotalGrossIncomeReport = 0

        End Sub
        Private Sub XrLabel_RateCDP_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_RateCDP.SummaryRowChanged

            _CDPHours += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.Hours.ToString))
            _CDPTotalGrossIncomeReport += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub XrLabel_RateOffice_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_RateOffice.SummaryGetResult

            If _OfficeHours <> 0 Then

                e.Result = (_OfficeTotalGrossIncomeReport / _OfficeHours)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_RateOffice_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_RateOffice.SummaryReset

            _OfficeHours = 0
            _OfficeTotalGrossIncomeReport = 0

        End Sub
        Private Sub XrLabel_RateOffice_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_RateOffice.SummaryRowChanged

            _OfficeHours += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.Hours.ToString))
            _OfficeTotalGrossIncomeReport += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub XrLabel_RateReport_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_RateReport.SummaryGetResult

            If _ReportHours <> 0 Then

                e.Result = (_ReportTotalGrossIncomeReport / _ReportHours)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel_RateReport_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_RateReport.SummaryReset

            _ReportHours = 0
            _ReportTotalGrossIncomeReport = 0

        End Sub
        Private Sub XrLabel_RateReport_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_RateReport.SummaryRowChanged

            _ReportHours += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.Hours.ToString))
            _ReportTotalGrossIncomeReport += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub





#End Region

#End Region

    End Class

End Namespace