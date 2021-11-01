Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class ClientProfitandLossDetailSalesClass
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


        Private Sub BillingSub_BeforePrint(sender As Object, e As PrintEventArgs) Handles BillingSub.BeforePrint
            'objects
            Dim ClientProfitandLossDetailBillingSubReport As ClientProfitandLossDetailSalesClassBillingSubReport = Nothing

            If TypeOf BillingSub.ReportSource Is ClientProfitandLossDetailSalesClassBillingSubReport Then

                ClientProfitandLossDetailBillingSubReport = BillingSub.ReportSource

                Try
                    ClientProfitandLossDetailBillingSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    ClientProfitandLossDetailBillingSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    ClientProfitandLossDetailBillingSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)).ToList.Where(Function(CPL) CPL.SalesClassCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SalesClassCode.ToString) AndAlso
                                                                                                                                                                                                               CPL.BilledTotal <> 0).ToList

                    If ClientProfitandLossDetailBillingSubReport.RowCount = 0 Then
                        Me.BillingSub.Visible = False
                    Else
                        Me.BillingSub.Visible = True
                    End If


                Catch ex As Exception
                    ClientProfitandLossDetailBillingSubReport.DataSource = Nothing
                End Try

            End If
        End Sub
        Private Sub CostOfBillingSub_BeforePrint(sender As Object, e As PrintEventArgs) Handles CostOfBillingSub.BeforePrint
            'objects
            Dim ClientProfitandLossDetailCostofBillingSubReport As ClientProfitandLossDetailSalesClassCostofBillingSubReport = Nothing

            If TypeOf CostOfBillingSub.ReportSource Is ClientProfitandLossDetailSalesClassCostofBillingSubReport Then

                ClientProfitandLossDetailCostofBillingSubReport = CostOfBillingSub.ReportSource

                Try
                    ClientProfitandLossDetailCostofBillingSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    ClientProfitandLossDetailCostofBillingSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    ClientProfitandLossDetailCostofBillingSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)).ToList.Where(Function(CPL) CPL.SalesClassCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SalesClassCode.ToString)).ToList

                    If ClientProfitandLossDetailCostofBillingSubReport.RowCount = 0 Then
                        Me.CostOfBillingSub.Visible = False
                    Else
                        Me.CostOfBillingSub.Visible = True
                    End If
                Catch ex As Exception
                    ClientProfitandLossDetailCostofBillingSubReport.DataSource = Nothing
                End Try

            End If
        End Sub
        Private Sub DirectServiceCostSub_BeforePrint(sender As Object, e As PrintEventArgs) Handles DirectServiceCostSub.BeforePrint
            'objects
            Dim ClientProfitandLossDetailServiceCostSubReport As ClientProfitandLossDetailSalesClassServiceCostSubReport = Nothing

            If TypeOf DirectServiceCostSub.ReportSource Is ClientProfitandLossDetailSalesClassServiceCostSubReport Then

                ClientProfitandLossDetailServiceCostSubReport = DirectServiceCostSub.ReportSource

                Try
                    ClientProfitandLossDetailServiceCostSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    ClientProfitandLossDetailServiceCostSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    ClientProfitandLossDetailServiceCostSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)).ToList.Where(Function(CPL) CPL.SalesClassCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SalesClassCode.ToString) AndAlso
                                                                                                                                                                                                               CPL.DirectServiceCost <> 0).ToList
                    If ClientProfitandLossDetailServiceCostSubReport.RowCount = 0 Then
                        Me.DirectServiceCostSub.Visible = False
                    Else
                        Me.DirectServiceCostSub.Visible = True
                    End If
                Catch ex As Exception
                    ClientProfitandLossDetailServiceCostSubReport.DataSource = Nothing
                End Try

            End If
        End Sub
        Private Sub DirectExpensesSub_BeforePrint(sender As Object, e As PrintEventArgs) Handles DirectExpensesSub.BeforePrint
            'objects
            Dim ClientProfitandLossDetailDirectExpensesSubReport As ClientProfitandLossDetailSalesClassDirectExpensesSubReport = Nothing

            If TypeOf DirectExpensesSub.ReportSource Is ClientProfitandLossDetailSalesClassDirectExpensesSubReport Then

                ClientProfitandLossDetailDirectExpensesSubReport = DirectExpensesSub.ReportSource

                Try
                    ClientProfitandLossDetailDirectExpensesSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    ClientProfitandLossDetailDirectExpensesSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    ClientProfitandLossDetailDirectExpensesSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPLDetail)).ToList.Where(Function(CPL) CPL.SalesClassCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SalesClassCode.ToString) AndAlso
                                                                                                                                                                                                               CPL.DirectExpense <> 0).ToList

                    If ClientProfitandLossDetailDirectExpensesSubReport.RowCount = 0 Then
                        Me.DirectExpensesSub.Visible = False
                    Else
                        Me.DirectExpensesSub.Visible = True
                    End If
                    'Dim d As Decimal = Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SumofDirectExpensesClient.ToString))

                    'If Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.SumofDirectExpensesClient.ToString)) = 0 Then
                    '    Me.DirectExpensesSub.Visible = False
                    'Else
                    '    Me.DirectExpensesSub.Visible = True
                    'End If

                Catch ex As Exception
                    ClientProfitandLossDetailDirectExpensesSubReport.DataSource = Nothing
                End Try

            End If
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