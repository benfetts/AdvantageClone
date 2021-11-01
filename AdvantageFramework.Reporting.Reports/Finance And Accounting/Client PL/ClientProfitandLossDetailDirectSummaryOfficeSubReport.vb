Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class ClientProfitandLossDetailDirectSummaryOfficeSubReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Dim GrossBillingDetail As Decimal = 0.0
        Dim GrossIncomeDetail As Decimal = 0.0
        Dim GrossBillingGroup As Decimal = 0.0
        Dim GrossIncomeGroup As Decimal = 0.0
        Dim GrossBillingReport As Decimal = 0.0
        Dim GrossIncomeReport As Decimal = 0.0
        Dim GrossBillingDetailMargin As Decimal = 0.0
        Dim GrossIncomeDetailMargin As Decimal = 0.0
        Dim GrossBillingGroupMargin As Decimal = 0.0
        Dim GrossIncomeGroupMargin As Decimal = 0.0
        Dim GrossBillingReportMargin As Decimal = 0.0
        Dim GrossIncomeReportMargin As Decimal = 0.0

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


        Private Sub OfficeBillingSub_BeforePrint(sender As Object, e As PrintEventArgs) Handles OfficeBillingSub.BeforePrint
            'objects
            Dim ClientProfitandLossDetailOfficeBillingSubReport As ClientProfitandLossDetailOfficeBillingSubReport = Nothing

            If TypeOf OfficeBillingSub.ReportSource Is ClientProfitandLossDetailOfficeBillingSubReport Then

                ClientProfitandLossDetailOfficeBillingSubReport = OfficeBillingSub.ReportSource

                Try
                    ClientProfitandLossDetailOfficeBillingSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    ClientProfitandLossDetailOfficeBillingSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    ClientProfitandLossDetailOfficeBillingSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)).ToList.Where(Function(CPL) CPL.OfficeCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.OfficeCode.ToString) AndAlso
                                                                                                                                                                                                               CPL.BilledTotal <> 0).ToList

                    If ClientProfitandLossDetailOfficeBillingSubReport.RowCount = 0 Then
                        Me.OfficeBillingSub.Visible = False
                    Else
                        Me.OfficeBillingSub.Visible = True
                    End If
                Catch ex As Exception
                    ClientProfitandLossDetailOfficeBillingSubReport.DataSource = Nothing
                End Try

            End If
        End Sub

        Private Sub OfficeCOSSub_BeforePrint(sender As Object, e As PrintEventArgs) Handles OfficeCOSSub.BeforePrint
            'objects
            Dim ClientProfitandLossDetailOfficeCostofBillingSubReport As ClientProfitandLossDetailOfficeCostofBillingSubReport = Nothing

            If TypeOf OfficeCOSSub.ReportSource Is ClientProfitandLossDetailOfficeCostofBillingSubReport Then

                ClientProfitandLossDetailOfficeCostofBillingSubReport = OfficeCOSSub.ReportSource

                Try
                    ClientProfitandLossDetailOfficeCostofBillingSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    ClientProfitandLossDetailOfficeCostofBillingSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    ClientProfitandLossDetailOfficeCostofBillingSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)).ToList.Where(Function(CPL) CPL.OfficeCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.OfficeCode.ToString) AndAlso
                                                                                                                                                                                                               (CPL.BilledCostOfSales <> 0 Or CPL.CRClientCostOfSales <> 0 Or CPL.GLCostOfSales <> 0 Or CPL.NonbillableAPCostOfSales <> 0 Or CPL.ManualCOS <> 0)).ToList
                    If ClientProfitandLossDetailOfficeCostofBillingSubReport.RowCount = 0 Then
                        Me.OfficeCOSSub.Visible = False
                    Else
                        Me.OfficeCOSSub.Visible = True
                    End If
                Catch ex As Exception
                    ClientProfitandLossDetailOfficeCostofBillingSubReport.DataSource = Nothing
                End Try

            End If
        End Sub

        Private Sub OfficeDirectServCostSub_BeforePrint(sender As Object, e As PrintEventArgs) Handles OfficeDirectServCostSub.BeforePrint
            'objects
            Dim ClientProfitandLossDetailOfficeServiceCostSubReport As ClientProfitandLossDetailOfficeServiceCostSubReport = Nothing

            If TypeOf OfficeDirectServCostSub.ReportSource Is ClientProfitandLossDetailOfficeServiceCostSubReport Then

                ClientProfitandLossDetailOfficeServiceCostSubReport = OfficeDirectServCostSub.ReportSource

                Try
                    ClientProfitandLossDetailOfficeServiceCostSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    ClientProfitandLossDetailOfficeServiceCostSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    ClientProfitandLossDetailOfficeServiceCostSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)).ToList.Where(Function(CPL) CPL.OfficeCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.OfficeCode.ToString) AndAlso
                                                                                                                                                                                                               CPL.DirectServiceCost <> 0).ToList
                    ClientProfitandLossDetailOfficeServiceCostSubReport.ReportType = "Summary"

                    If ClientProfitandLossDetailOfficeServiceCostSubReport.RowCount = 0 Then
                        Me.OfficeDirectServCostSub.Visible = False
                    Else
                        Me.OfficeDirectServCostSub.Visible = True
                    End If
                Catch ex As Exception
                    ClientProfitandLossDetailOfficeServiceCostSubReport.DataSource = Nothing
                End Try

            End If
        End Sub

        Private Sub OfficeDirectExpSub_BeforePrint(sender As Object, e As PrintEventArgs) Handles OfficeDirectExpSub.BeforePrint
            'objects
            Dim ClientProfitandLossDetailOfficeDirectExpensesSubReport As ClientProfitandLossDetailOfficeDirectExpensesSubReport = Nothing

            If TypeOf OfficeDirectExpSub.ReportSource Is ClientProfitandLossDetailOfficeDirectExpensesSubReport Then

                ClientProfitandLossDetailOfficeDirectExpensesSubReport = OfficeDirectExpSub.ReportSource

                Try
                    ClientProfitandLossDetailOfficeDirectExpensesSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    ClientProfitandLossDetailOfficeDirectExpensesSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    ClientProfitandLossDetailOfficeDirectExpensesSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)).ToList.Where(Function(CPL) CPL.OfficeCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.OfficeCode.ToString) AndAlso
                                                                                                                                                                                                               (CPL.DirectExpense <> 0 Or CPL.CRClientDirectExpense <> 0 Or CPL.GLDirectExpense <> 0)).ToList
                    ClientProfitandLossDetailOfficeDirectExpensesSubReport.ReportType = "Summary"

                    If ClientProfitandLossDetailOfficeDirectExpensesSubReport.RowCount = 0 Then
                        Me.OfficeDirectExpSub.Visible = False
                    Else
                        Me.OfficeDirectExpSub.Visible = True
                    End If

                    'Dim d As Decimal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SumofDirectExpensesClient.ToString))

                    'If Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SumofDirectExpensesClient.ToString)) = 0 Then
                    '    Me.OfficeDirectExpSub.Visible = False
                    'Else
                    '    Me.OfficeDirectExpSub.Visible = True
                    'End If

                Catch ex As Exception
                    ClientProfitandLossDetailOfficeDirectExpensesSubReport.DataSource = Nothing
                End Try

            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace