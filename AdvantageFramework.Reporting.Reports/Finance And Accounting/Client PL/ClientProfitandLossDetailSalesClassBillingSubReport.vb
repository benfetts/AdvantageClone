Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class ClientProfitandLossDetailSalesClassBillingSubReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Dim _TotalSalesClassCurrent As Decimal = 0.0
        Dim _TotalSalesClassTotalCurrent As Decimal = 0.0
        Dim _TotalSalesClassYTD As Decimal = 0.0
        Dim _TotalSalesClassTotalYTD As Decimal = 0.0
        Dim _TotalTypeCurrent As Decimal = 0.0
        Dim _TotalTypeTotalCurrent As Decimal = 0.0
        Dim _TotalTypeYTD As Decimal = 0.0
        Dim _TotalTypeTotalYTD As Decimal = 0.0
        Dim _TypeTotal As Decimal = 0.0
        Dim _BillingTotalCurrent As Decimal = 0.0
        Dim _BillingTotalYTD As Decimal = 0.0

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.ClientPLDetail
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property

        Private Sub label18_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label18.SummaryGetResult
            If _TotalSalesClassTotalYTD <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalSalesClassYTD / _TotalSalesClassTotalYTD))

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub

        Private Sub label18_SummaryReset(sender As Object, e As EventArgs) Handles label18.SummaryReset
            _TotalSalesClassYTD = 0
        End Sub

        Private Sub label18_SummaryRowChanged(sender As Object, e As EventArgs) Handles label18.SummaryRowChanged

            _TotalSalesClassYTD += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.BilledTotal.ToString))
            _TotalSalesClassTotalYTD = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SumofTotalBilledSalesClass.ToString))

        End Sub

        Private Sub label21_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label21.SummaryGetResult
            If _TotalTypeTotalYTD <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalTypeYTD / _TotalTypeTotalYTD))

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub

        Private Sub label21_SummaryReset(sender As Object, e As EventArgs) Handles label21.SummaryReset
            _TotalTypeYTD = 0
        End Sub

        Private Sub label21_SummaryRowChanged(sender As Object, e As EventArgs) Handles label21.SummaryRowChanged

            _TotalTypeYTD += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.BilledTotal.ToString))
            _TotalTypeTotalYTD = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SumofTotalBilledSalesClass.ToString))

        End Sub






#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace