Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class ClientProfitandLossDetailSalesClassServiceCostSubReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Dim _DirectServiceCost As Decimal = 0.0
        Dim _DirectServiceCostTotal As Decimal = 0.0
        Dim _DirectServiceCostYTD As Decimal = 0.0
        Dim _DirectServiceCostTotalYTD As Decimal = 0.0

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

        'Private Sub label6_SummaryReset(sender As Object, e As EventArgs) Handles label6.SummaryReset
        '    _DirectServiceCostYTD = 0
        'End Sub

        'Private Sub label6_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label6.SummaryGetResult
        '    If _DirectServiceCostTotalYTD <> 0 Then

        '        e.Result = String.Format("{0:#,##0.00%}", (_DirectServiceCostYTD / _DirectServiceCostTotalYTD))
        '        label6.Visible = True

        '    Else

        '        e.Result = 0
        '        label6.Visible = False

        '    End If

        '    e.Handled = True
        'End Sub

        'Private Sub label6_SummaryRowChanged(sender As Object, e As EventArgs) Handles label6.SummaryRowChanged

        '    _DirectServiceCostYTD += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.DirectServiceCost.ToString))
        '    _DirectServiceCostTotalYTD = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.TotalGrossIncome.ToString))

        'End Sub

        'Private Sub label1_SummaryGetResult(sender As Object, e As SummaryGetResultEventArgs) Handles label1.SummaryGetResult

        '    If _DirectServiceCostTotal <> 0 Then

        '        e.Result = String.Format("{0:#,##0.00%}", (_DirectServiceCost / _DirectServiceCostTotal))
        '        label1.Visible = True

        '    Else

        '        e.Result = 0
        '        label1.Visible = False

        '    End If

        '    e.Handled = True
        'End Sub

        'Private Sub label1_SummaryReset(sender As Object, e As EventArgs) Handles label1.SummaryReset
        '    _DirectServiceCost = 0
        'End Sub

        'Private Sub label1_SummaryRowChanged(sender As Object, e As EventArgs) Handles label1.SummaryRowChanged

        '    _DirectServiceCost += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.DirectServiceCost.ToString))
        '    _DirectServiceCostTotal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.TotalGrossIncome.ToString))

        'End Sub

        ''Detail Percentage Income
        'Private Sub XrLabel1_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    If GrossBillingDetail <> 0 Then
        '        Me.XrLabel1.Text = String.Format("{0:#,##0.00%}", (GrossIncomeDetail / GrossBillingDetail))
        '    ElseIf GrossBillingDetail = 0 Or GrossIncomeDetail = 0 Then
        '        Me.XrLabel1.Text = String.Format("{0:#,##0.00%}", 0)
        '    End If
        'End Sub
        'Private Sub label34_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossBillingDetail = CDec(Me.label34.Text)
        '    GrossBillingDetailMargin = CDec(Me.label34.Text)
        'End Sub
        'Private Sub label40_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossIncomeDetail = CDec(Me.label40.Text)
        'End Sub

        ''Group Percentage Income
        'Private Sub XrLabel3_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    If GrossBillingGroup <> 0 Then
        '        Me.XrLabel3.Text = String.Format("{0:#,##0.00%}", (GrossIncomeGroup / GrossBillingGroup))
        '    ElseIf GrossBillingGroup = 0 Or GrossIncomeGroup = 0 Then
        '        Me.XrLabel3.Text = String.Format("{0:#,##0.00%}", 0)
        '    End If
        'End Sub
        'Private Sub label43_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossIncomeGroup = CDec(Me.label43.Text)
        'End Sub
        'Private Sub label49_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossBillingGroup = CDec(Me.label49.Text)
        '    GrossBillingGroupMargin = CDec(Me.label49.Text)
        'End Sub

        ''Report Percentage Income
        'Private Sub XrLabel5_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    If GrossBillingReport <> 0 Then
        '        Me.XrLabel5.Text = String.Format("{0:#,##0.00%}", (GrossIncomeReport / GrossBillingReport))
        '    ElseIf GrossBillingReport = 0 Or GrossIncomeReport = 0 Then
        '        Me.XrLabel5.Text = String.Format("{0:#,##0.00%}", 0)
        '    End If
        'End Sub
        'Private Sub label56_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossIncomeReport = CDec(Me.label56.Text)
        'End Sub
        'Private Sub label50_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossBillingReport = CDec(Me.label50.Text)
        '    GrossBillingReportMargin = CDec(Me.label50.Text)
        'End Sub

        ''Detail Percentage Margin
        'Private Sub XrLabel2_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    If GrossBillingDetailMargin <> 0 Then
        '        Me.XrLabel2.Text = String.Format("{0:#,##0.00%}", (GrossIncomeDetailMargin / GrossBillingDetailMargin))
        '    ElseIf GrossBillingDetailMargin = 0 Or GrossIncomeDetailMargin = 0 Then
        '        Me.XrLabel2.Text = String.Format("{0:#,##0.00%}", 0)
        '    End If
        'End Sub
        'Private Sub label36_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossIncomeDetailMargin = CDec(Me.label36.Text)
        'End Sub

        ''Group Percentage Margin
        'Private Sub XrLabel4_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    If GrossBillingGroupMargin <> 0 Then
        '        Me.XrLabel4.Text = String.Format("{0:#,##0.00%}", (GrossIncomeGroupMargin / GrossBillingGroupMargin))
        '    ElseIf GrossBillingGroupMargin = 0 Or GrossIncomeGroupMargin = 0 Then
        '        Me.XrLabel4.Text = String.Format("{0:#,##0.00%}", 0)
        '    End If
        'End Sub
        'Private Sub label47_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossIncomeGroupMargin = CDec(Me.label47.Text)
        'End Sub

        ''Report Percentage Margin
        'Private Sub XrLabel6_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    If GrossBillingReportMargin <> 0 Then
        '        Me.XrLabel6.Text = String.Format("{0:#,##0.00%}", (GrossIncomeReportMargin / GrossBillingReportMargin))
        '    ElseIf GrossBillingReportMargin = 0 Or GrossIncomeReportMargin = 0 Then
        '        Me.XrLabel6.Text = String.Format("{0:#,##0.00%}", 0)
        '    End If
        'End Sub
        'Private Sub label52_PrintOnPage(sender As Object, e As PrintOnPageEventArgs)
        '    GrossIncomeReportMargin = CDec(Me.label52.Text)
        'End Sub



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