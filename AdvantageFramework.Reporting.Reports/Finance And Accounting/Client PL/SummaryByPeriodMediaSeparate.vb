Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class SummaryByPeriodMediaSeparate
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

        Private _MarginPctTotalIncome As Decimal = 0
        Private _MarginPctTotalGrossIncome As Decimal = 0

        Private _OfficeMarginPctTotalIncome As Decimal = 0
        Private _OfficeMarginPctTotalGrossIncome As Decimal = 0

        Private _Hours As Decimal = 0
        Private _TotalGrossIncome As Decimal = 0

        Private _OfficeHours As Decimal = 0
        Private _OfficeTotalGrossIncome As Decimal = 0

        Private _TotalHours As Decimal = 0
        Private _TotalTotalGrossIncome As Decimal = 0

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

            If _MarginPctTotalGrossIncome <> 0 Then

                e.Result = (_MarginPctTotalIncome / _MarginPctTotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub MarginPct_SummaryReset(sender As Object, e As EventArgs) Handles MarginPct.SummaryReset

            _MarginPctTotalIncome = 0
            _MarginPctTotalGrossIncome = 0

        End Sub
        Private Sub MarginPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles MarginPct.SummaryRowChanged

            _MarginPctTotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _MarginPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub OfficeMarginPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles OfficeMarginPct.SummaryGetResult

            If _OfficeMarginPctTotalGrossIncome <> 0 Then

                e.Result = (_OfficeMarginPctTotalIncome / _OfficeMarginPctTotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub OfficeMarginPct_SummaryReset(sender As Object, e As EventArgs) Handles OfficeMarginPct.SummaryReset

            _OfficeMarginPctTotalIncome = 0
            _OfficeMarginPctTotalGrossIncome = 0

        End Sub
        Private Sub OfficeMarginPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles OfficeMarginPct.SummaryRowChanged

            _OfficeMarginPctTotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _OfficeMarginPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub

        Private Sub label46_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label46.SummaryGetResult

            If _Hours <> 0 Then

                e.Result = (_TotalGrossIncome / _Hours)

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub

        Private Sub label46_SummaryReset(sender As Object, e As EventArgs) Handles label46.SummaryReset
            _Hours = 0
            _TotalGrossIncome = 0
        End Sub

        Private Sub label46_SummaryRowChanged(sender As Object, e As EventArgs) Handles label46.SummaryRowChanged
            _Hours += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.Hours.ToString))
            _TotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
        End Sub

        Private Sub label47_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label47.SummaryGetResult

            If _TotalHours <> 0 Then

                e.Result = (_TotalTotalGrossIncome / _TotalHours)

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub

        Private Sub label47_SummaryReset(sender As Object, e As EventArgs) Handles label47.SummaryReset
            _TotalHours = 0
            _TotalTotalGrossIncome = 0
        End Sub

        Private Sub label47_SummaryRowChanged(sender As Object, e As EventArgs) Handles label47.SummaryRowChanged
            _TotalHours += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.Hours.ToString))
            _TotalTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
        End Sub

        Private Sub label57_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label57.SummaryGetResult

            If _OfficeHours <> 0 Then

                e.Result = (_OfficeTotalGrossIncome / _OfficeHours)

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub

        Private Sub label57_SummaryReset(sender As Object, e As EventArgs) Handles label57.SummaryReset
            _OfficeHours = 0
            _OfficeTotalGrossIncome = 0
        End Sub

        Private Sub label57_SummaryRowChanged(sender As Object, e As EventArgs) Handles label57.SummaryRowChanged
            _OfficeHours += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.Hours.ToString))
            _OfficeTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
        End Sub

#End Region

#End Region

    End Class

End Namespace