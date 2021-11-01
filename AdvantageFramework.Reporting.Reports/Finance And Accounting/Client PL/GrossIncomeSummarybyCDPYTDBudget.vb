Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class GrossIncomeSummarybyCDPYTDBudget
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

        Private _MarginPctBilledTotal As Decimal = 0
        Private _MarginPctTotalGrossIncome As Decimal = 0

        Private _ClientMarginPctBilledTotal As Decimal = 0
        Private _ClientMarginPctTotalGrossIncome As Decimal = 0

        Private _OfficeMarginPctBilledTotal As Decimal = 0
        Private _OfficeMarginPctTotalGrossIncome As Decimal = 0

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

        Private Sub XrLabel1_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles XrLabel_MarginPctCDP.SummaryGetResult

            If _MarginPctBilledTotal <> 0 Then

                e.Result = (_MarginPctTotalGrossIncome / _MarginPctBilledTotal)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub XrLabel1_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_MarginPctCDP.SummaryReset

            _MarginPctBilledTotal = 0
            _MarginPctTotalGrossIncome = 0

        End Sub
        Private Sub XrLabel1_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_MarginPctCDP.SummaryRowChanged

            _MarginPctBilledTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.BilledTotal.ToString))
            _MarginPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub TotalMarginPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles XrLabel_MarginPctOffice.SummaryGetResult

            If _ClientMarginPctBilledTotal <> 0 Then

                e.Result = (_ClientMarginPctTotalGrossIncome / _ClientMarginPctBilledTotal)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub TotalMarginPct_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_MarginPctOffice.SummaryReset

            _ClientMarginPctBilledTotal = 0
            _ClientMarginPctTotalGrossIncome = 0

        End Sub
        Private Sub TotalMarginPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_MarginPctOffice.SummaryRowChanged

            _ClientMarginPctBilledTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.BilledTotal.ToString))
            _ClientMarginPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub OfficeMarginPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles XrLabel_MarginPctReport.SummaryGetResult

            If _OfficeMarginPctBilledTotal <> 0 Then

                e.Result = (_OfficeMarginPctTotalGrossIncome / _OfficeMarginPctBilledTotal)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub OfficeMarginPct_SummaryReset(sender As Object, e As EventArgs) Handles XrLabel_MarginPctReport.SummaryReset

            _OfficeMarginPctBilledTotal = 0
            _OfficeMarginPctTotalGrossIncome = 0

        End Sub
        Private Sub OfficeMarginPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles XrLabel_MarginPctReport.SummaryRowChanged

            _OfficeMarginPctBilledTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.BilledTotal.ToString))
            _OfficeMarginPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub



#End Region

#End Region

    End Class

End Namespace