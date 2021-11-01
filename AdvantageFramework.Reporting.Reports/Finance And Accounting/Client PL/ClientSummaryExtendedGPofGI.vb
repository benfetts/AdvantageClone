Namespace FinanceAndAccounting.ClientPL

    Public Class ClientSummaryExtendedGPofGI
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

        Private _IncomeGIPctGrossIncome As Decimal = 0
        Private _GrossMarginPctOfGITotalIncome As Decimal = 0
        Private _GrossMarginPctOfGITotalGrossIncome As Decimal = 0
        Private _NetProfitPctOfGITotalGrossIncome As Decimal = 0
        Private _NetProfitPctOfGIIncomeLessOverhead As Decimal = 0

        Private _OfficeIncomeGIPctGrossIncome As Decimal = 0
        Private _OfficeGrossMarginPctOfGITotalIncome As Decimal = 0
        Private _OfficeGrossMarginPctOfGITotalGrossIncome As Decimal = 0
        Private _OfficeNetProfitPctOfGITotalGrossIncome As Decimal = 0
        Private _OfficeNetProfitPctOfGIIncomeLessOverhead As Decimal = 0

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

        Private Sub TotalIncomeGIPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles TotalIncomeGIPct.SummaryGetResult

            Dim ReportTotalGrossIncome As Decimal = 0

            ReportTotalGrossIncome = Convert.ToDecimal(Me.GetCurrentColumnValue("ReportTotalGrossIncome"))

            If ReportTotalGrossIncome <> 0 Then

                e.Result = (_IncomeGIPctGrossIncome / ReportTotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub TotalIncomeGIPct_SummaryReset(sender As Object, e As EventArgs) Handles TotalIncomeGIPct.SummaryReset

            _IncomeGIPctGrossIncome = 0

        End Sub
        Private Sub TotalIncomeGIPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles TotalIncomeGIPct.SummaryRowChanged

            _IncomeGIPctGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub GrossMarginPctOfGI_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles GrossMarginPctOfGI.SummaryGetResult

            If _GrossMarginPctOfGITotalGrossIncome <> 0 Then

                e.Result = (_GrossMarginPctOfGITotalIncome / _GrossMarginPctOfGITotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub GrossMarginPctOfGI_SummaryReset(sender As Object, e As EventArgs) Handles GrossMarginPctOfGI.SummaryReset

            _GrossMarginPctOfGITotalIncome = 0
            _GrossMarginPctOfGITotalGrossIncome = 0

        End Sub
        Private Sub GrossMarginPctOfGI_SummaryRowChanged(sender As Object, e As EventArgs) Handles GrossMarginPctOfGI.SummaryRowChanged

            _GrossMarginPctOfGITotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _GrossMarginPctOfGITotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub NetProfitPctOfGI_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles NetProfitPctOfGI.SummaryGetResult

            If _NetProfitPctOfGITotalGrossIncome <> 0 Then

                e.Result = (_NetProfitPctOfGIIncomeLessOverhead / _NetProfitPctOfGITotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub NetProfitPctOfGI_SummaryReset(sender As Object, e As EventArgs) Handles NetProfitPctOfGI.SummaryReset

            _NetProfitPctOfGIIncomeLessOverhead = 0
            _NetProfitPctOfGITotalGrossIncome = 0

        End Sub
        Private Sub NetProfitPctOfGI_SummaryRowChanged(sender As Object, e As EventArgs) Handles NetProfitPctOfGI.SummaryRowChanged

            _NetProfitPctOfGIIncomeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))
            _NetProfitPctOfGITotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub OfficeTotalIncomeGIPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles OfficeTotalIncomeGIPct.SummaryGetResult

            Dim ReportTotalGrossIncome As Decimal = 0

            ReportTotalGrossIncome = Convert.ToDecimal(Me.GetCurrentColumnValue("ReportTotalGrossIncome"))

            If ReportTotalGrossIncome <> 0 Then

                e.Result = (_OfficeIncomeGIPctGrossIncome / ReportTotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub OfficeTotalIncomeGIPct_SummaryReset(sender As Object, e As EventArgs) Handles OfficeTotalIncomeGIPct.SummaryReset

            _OfficeIncomeGIPctGrossIncome = 0

        End Sub
        Private Sub OfficeTotalIncomeGIPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles OfficeTotalIncomeGIPct.SummaryRowChanged

            _OfficeIncomeGIPctGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub OfficeGrossMarginPctOfGI_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles OfficeGrossMarginPctOfGI.SummaryGetResult

            If _OfficeGrossMarginPctOfGITotalGrossIncome <> 0 Then

                e.Result = (_OfficeGrossMarginPctOfGITotalIncome / _OfficeGrossMarginPctOfGITotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub OfficeGrossMarginPctOfGI_SummaryReset(sender As Object, e As EventArgs) Handles OfficeGrossMarginPctOfGI.SummaryReset

            _OfficeGrossMarginPctOfGITotalIncome = 0
            _OfficeGrossMarginPctOfGITotalGrossIncome = 0

        End Sub
        Private Sub OfficeGrossMarginPctOfGI_SummaryRowChanged(sender As Object, e As EventArgs) Handles OfficeGrossMarginPctOfGI.SummaryRowChanged

            _OfficeGrossMarginPctOfGITotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _OfficeGrossMarginPctOfGITotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub OfficeNetProfitPctOfGI_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles OfficeNetProfitPctOfGI.SummaryGetResult

            If _OfficeNetProfitPctOfGITotalGrossIncome <> 0 Then

                e.Result = (_OfficeNetProfitPctOfGIIncomeLessOverhead / _OfficeNetProfitPctOfGITotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub OfficeNetProfitPctOfGI_SummaryReset(sender As Object, e As EventArgs) Handles OfficeNetProfitPctOfGI.SummaryReset

            _OfficeNetProfitPctOfGIIncomeLessOverhead = 0
            _OfficeNetProfitPctOfGITotalGrossIncome = 0

        End Sub
        Private Sub OfficeNetProfitPctOfGI_SummaryRowChanged(sender As Object, e As EventArgs) Handles OfficeNetProfitPctOfGI.SummaryRowChanged

            _OfficeNetProfitPctOfGIIncomeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))
            _OfficeNetProfitPctOfGITotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

#End Region

#End Region

    End Class

End Namespace