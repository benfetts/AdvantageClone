Namespace FinanceAndAccounting.ClientPL

    Public Class GrossIncomeSummarybyCDPSCYTDMarginSubReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

        Private _MarginPctBilledTotal As Decimal = 0
        Private _MarginPctTotalGrossIncome As Decimal = 0

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

        Private Sub MarginPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles MarginPct.SummaryGetResult

            If _MarginPctBilledTotal <> 0 Then

                e.Result = (_MarginPctTotalGrossIncome / _MarginPctBilledTotal)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub MarginPct_SummaryReset(sender As Object, e As EventArgs) Handles MarginPct.SummaryReset

            _MarginPctBilledTotal = 0
            _MarginPctTotalGrossIncome = 0

        End Sub
        Private Sub MarginPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles MarginPct.SummaryRowChanged

            _MarginPctBilledTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.BilledTotal.ToString))
            _MarginPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

#End Region

#End Region

    End Class

End Namespace