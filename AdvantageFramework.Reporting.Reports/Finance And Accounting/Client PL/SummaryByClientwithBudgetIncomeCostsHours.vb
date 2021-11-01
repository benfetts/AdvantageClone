Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class SummaryByClientwithBudgetIncomeCostsHours
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

        Private _TotalGrossIncomeClient As Decimal = 0
        Private _TotalGrossIncomeClientTotal As Decimal = 0
        Private _TotalGrossIncomeTotal As Decimal = 0
        Private _TotalGrossIncomeTotalOffice As Decimal = 0
        Private _TotalGrossIncomeTotalOfficeTotal As Decimal = 0
        Private _TotalGrossIncomeTotalYear As Decimal = 0
        Private _TotalGrossIncomeYear As Decimal = 0
        Private _TotalGrossIncomeTotalYearTotal As Decimal = 0

        Private _DirectServiceCostClient As Decimal = 0
        Private _DirectServiceCostClientTotal As Decimal = 0
        Private _DirectServiceCostTotal As Decimal = 0
        Private _DirectServiceCostTotalOffice As Decimal = 0
        Private _DirectServiceCostTotalOfficeTotal As Decimal = 0
        Private _DirectServiceCostTotalYear As Decimal = 0
        Private _DirectServiceCostTotalYearTotal As Decimal = 0


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


        'Gross income
        'Client Header
        Private Sub label10_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label10.SummaryGetResult

            If _TotalGrossIncomeClient <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalGrossIncomeClient / _TotalGrossIncomeClientTotal))

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub label10_SummaryReset(sender As Object, e As EventArgs) Handles label10.SummaryReset

            _TotalGrossIncomeClient = 0
            _TotalGrossIncomeClientTotal = 0

        End Sub
        Private Sub label10_SummaryRowChanged(sender As Object, e As EventArgs) Handles label10.SummaryRowChanged

            _TotalGrossIncomeClient += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
            _TotalGrossIncomeClientTotal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.SumofTotalGrossIncomeOfficeYear.ToString))

        End Sub

        'Total Report
        Private Sub label50_SummaryReset(sender As Object, e As EventArgs) Handles label50.SummaryReset
            _TotalGrossIncomeTotal = 0
        End Sub
        Private Sub label50_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label50.SummaryGetResult
            If _TotalGrossIncomeTotal <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalGrossIncomeTotal / _TotalGrossIncomeTotal))

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub
        Private Sub label50_SummaryRowChanged(sender As Object, e As EventArgs) Handles label50.SummaryRowChanged
            _TotalGrossIncomeTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
        End Sub

        'Office Footer
        Private Sub label99_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label99.SummaryGetResult

            If _TotalGrossIncomeTotalOfficeTotal <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalGrossIncomeTotalOffice / _TotalGrossIncomeTotalOfficeTotal))

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub label99_SummaryReset(sender As Object, e As EventArgs) Handles label99.SummaryReset
            _TotalGrossIncomeTotalOffice = 0
            _TotalGrossIncomeTotalOfficeTotal = 0
        End Sub
        Private Sub label99_SummaryRowChanged(sender As Object, e As EventArgs) Handles label99.SummaryRowChanged
            _TotalGrossIncomeTotalOffice += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
            _TotalGrossIncomeTotalOfficeTotal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.SumofTotalGrossIncomeOffice.ToString))
        End Sub


        'Year Footer
        Private Sub label68_SummaryRowChanged(sender As Object, e As EventArgs) Handles label68.SummaryRowChanged
            _TotalGrossIncomeTotalYear += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
            _TotalGrossIncomeTotalYearTotal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.SumofTotalGrossIncomeOfficeYear.ToString))
        End Sub
        Private Sub label68_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label68.SummaryGetResult

            If _TotalGrossIncomeTotalYearTotal <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_TotalGrossIncomeTotalYear / _TotalGrossIncomeTotalYearTotal))

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub label68_SummaryReset(sender As Object, e As EventArgs) Handles label68.SummaryReset
            _TotalGrossIncomeTotalYear = 0
            _TotalGrossIncomeTotalYearTotal = 0
        End Sub


        'Direct Service Cost
        'Client
        Private Sub label12_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label12.SummaryGetResult
            If _DirectServiceCostClientTotal <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_DirectServiceCostClient / _DirectServiceCostClientTotal))

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub label12_SummaryReset(sender As Object, e As EventArgs) Handles label12.SummaryReset
            _DirectServiceCostClient = 0
            _DirectServiceCostClientTotal = 0
        End Sub
        Private Sub label12_SummaryRowChanged(sender As Object, e As EventArgs) Handles label12.SummaryRowChanged
            _DirectServiceCostClient += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.DirectServiceCost.ToString))
            _DirectServiceCostClientTotal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.SumofDirectServiceCostOfficeYear.ToString))
        End Sub

        'Total
        Private Sub label52_SummaryRowChanged(sender As Object, e As EventArgs) Handles label52.SummaryRowChanged
            _DirectServiceCostTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.DirectServiceCost.ToString))
        End Sub
        Private Sub label52_SummaryReset(sender As Object, e As EventArgs) Handles label52.SummaryReset
            _DirectServiceCostTotal = 0
        End Sub
        Private Sub label52_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label52.SummaryGetResult
            If _DirectServiceCostTotal <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_DirectServiceCostTotal / _DirectServiceCostTotal))

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub

        'Office
        Private Sub label97_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label97.SummaryGetResult
            If _DirectServiceCostTotalOfficeTotal <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_DirectServiceCostTotalOffice / _DirectServiceCostTotalOfficeTotal))

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub
        Private Sub label97_SummaryReset(sender As Object, e As EventArgs) Handles label97.SummaryReset
            _DirectServiceCostTotalOffice = 0
            _DirectServiceCostTotalOfficeTotal = 0
        End Sub
        Private Sub label97_SummaryRowChanged(sender As Object, e As EventArgs) Handles label97.SummaryRowChanged
            _DirectServiceCostTotalOffice += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.DirectServiceCost.ToString))
            _DirectServiceCostTotalOfficeTotal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.SumofDirectServiceCostOffice.ToString))
        End Sub

        'Year
        Private Sub label70_SummaryRowChanged(sender As Object, e As EventArgs) Handles label70.SummaryRowChanged
            _DirectServiceCostTotalYear += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.DirectServiceCost.ToString))
            _DirectServiceCostTotalYearTotal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.SumofDirectServiceCostOfficeYear.ToString))
        End Sub
        Private Sub label70_SummaryReset(sender As Object, e As EventArgs) Handles label70.SummaryReset
            _DirectServiceCostTotalYear = 0
            _DirectServiceCostTotalYearTotal = 0
        End Sub
        Private Sub label70_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label70.SummaryGetResult
            If _DirectServiceCostTotalYearTotal <> 0 Then

                e.Result = String.Format("{0:#,##0.00%}", (_DirectServiceCostTotalYear / _DirectServiceCostTotalYearTotal))

            Else

                e.Result = 0

            End If

            e.Handled = True
        End Sub




        'Current Year
        Private Sub ClientFooter_BeforePrint(sender As Object, e As PrintEventArgs) Handles ClientFooter.BeforePrint
            Dim _postperiodyear As String = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.PostingPeriod.ToString).ToString.Substring(0, 4)
            Dim _currentyear As String = Me.EndPeriod.Value.ToString.Substring(0, 4)

            If _currentyear <> _postperiodyear Then
                e.Cancel = True
            End If
        End Sub
        Private Sub ClientHeader_BeforePrint(sender As Object, e As PrintEventArgs) Handles ClientHeader.BeforePrint
            Dim _postperiodyear As String = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.PostingPeriod.ToString).ToString.Substring(0, 4)
            Dim _currentyear As String = Me.EndPeriod.Value.ToString.Substring(0, 4)

            If _currentyear <> _postperiodyear Then
                e.Cancel = True
            End If
        End Sub




#End Region

#End Region

    End Class

End Namespace