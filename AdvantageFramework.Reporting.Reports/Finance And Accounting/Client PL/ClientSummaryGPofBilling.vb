Namespace FinanceAndAccounting.ClientPL

    Public Class ClientSummaryGPofBilling
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

        Private _IncomeGIPctTotalIncome As Decimal = 0
        Private _IncomeGIPctTotalGrossIncome As Decimal = 0
        Private _LessOverheadBillPctBilledTotal As Decimal = 0
        Private _LessOverheadBillPctIncomeLessOverhead As Decimal = 0
        Private _LessOverheadGIPctTotalGrossIncome As Decimal = 0
        Private _LessOverheadGIPctProductIncomeLessOverhead As Decimal = 0

        Private _OfficeIncomeGIPctTotalIncome As Decimal = 0
        Private _OfficeIncomeGIPctTotalGrossIncome As Decimal = 0
        Private _OfficeLessOverheadBillPctBilledTotal As Decimal = 0
        Private _OfficeLessOverheadBillPctIncomeLessOverhead As Decimal = 0
        Private _OfficeLessOverheadGIPctTotalGrossIncome As Decimal = 0
        Private _OfficeLessOverheadGIPctProductIncomeLessOverhead As Decimal = 0

        Private _ReportIncomeGIPctTotalIncome As Decimal = 0
        Private _ReportIncomeGIPctTotalGrossIncome As Decimal = 0
        Private _ReportLessOverheadBillPctBilledTotal As Decimal = 0
        Private _ReportLessOverheadBillPctIncomeLessOverhead As Decimal = 0
        Private _ReportLessOverheadGIPctTotalGrossIncome As Decimal = 0
        Private _ReportLessOverheadGIPctProductIncomeLessOverhead As Decimal = 0

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

            'IIf([TotalGrossIncome] = 0, 0, [TotalIncome] / [TotalGrossIncome])

            If _IncomeGIPctTotalGrossIncome <> 0 Then

                e.Result = (_IncomeGIPctTotalIncome / _IncomeGIPctTotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub TotalIncomeGIPct_SummaryReset(sender As Object, e As EventArgs) Handles TotalIncomeGIPct.SummaryReset

            _IncomeGIPctTotalIncome = 0
            _IncomeGIPctTotalGrossIncome = 0

        End Sub
        Private Sub TotalIncomeGIPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles TotalIncomeGIPct.SummaryRowChanged

            _IncomeGIPctTotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _IncomeGIPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub
        Private Sub IncomeLessOverheadBillPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles IncomeLessOverheadBillPct.SummaryGetResult

            '[IncomeLessOverhead] / [BilledTotal]

            If _LessOverheadBillPctBilledTotal <> 0 Then

                e.Result = (_LessOverheadBillPctIncomeLessOverhead / _LessOverheadBillPctBilledTotal)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub IncomeLessOverheadBillPct_SummaryReset(sender As Object, e As EventArgs) Handles IncomeLessOverheadBillPct.SummaryReset

            _LessOverheadBillPctBilledTotal = 0
            _LessOverheadBillPctIncomeLessOverhead = 0

        End Sub
        Private Sub IncomeLessOverheadBillPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles IncomeLessOverheadBillPct.SummaryRowChanged

            _LessOverheadBillPctBilledTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.BilledTotal.ToString))
            _LessOverheadBillPctIncomeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))

        End Sub
        Private Sub IncomeLessOverheadGIPctProduct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles IncomeLessOverheadGIPctProduct.SummaryGetResult

            'IIf([TotalGrossIncome]=0,0,[IncomeLessOverhead] / [TotalGrossIncome])

            If _LessOverheadGIPctTotalGrossIncome <> 0 Then

                e.Result = (_LessOverheadGIPctProductIncomeLessOverhead / _LessOverheadGIPctTotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub IncomeLessOverheadGIPctProduct_SummaryReset(sender As Object, e As EventArgs) Handles IncomeLessOverheadGIPctProduct.SummaryReset

            _LessOverheadGIPctTotalGrossIncome = 0
            _LessOverheadGIPctProductIncomeLessOverhead = 0

        End Sub
        Private Sub IncomeLessOverheadGIPctProduct_SummaryRowChanged(sender As Object, e As EventArgs) Handles IncomeLessOverheadGIPctProduct.SummaryRowChanged

            _LessOverheadGIPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
            _LessOverheadGIPctProductIncomeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))

        End Sub

        Private Sub OfficeTotalIncomeGIPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles OfficeTotalIncomeGIPct.SummaryGetResult

            'IIf([TotalGrossIncome] = 0, 0, [TotalIncome] / [TotalGrossIncome])

            If _OfficeIncomeGIPctTotalGrossIncome <> 0 Then

                e.Result = (_OfficeIncomeGIPctTotalIncome / _OfficeIncomeGIPctTotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub OfficeTotalIncomeGIPct_SummaryReset(sender As Object, e As EventArgs) Handles OfficeTotalIncomeGIPct.SummaryReset

            _OfficeIncomeGIPctTotalIncome = 0
            _OfficeIncomeGIPctTotalGrossIncome = 0

        End Sub
        Private Sub OfficeTotalIncomeGIPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles OfficeTotalIncomeGIPct.SummaryRowChanged

            _OfficeIncomeGIPctTotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
            _OfficeIncomeGIPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        End Sub
        Private Sub OfficeIncomeLessOverheadBillPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles OfficeIncomeLessOverheadBillPct.SummaryGetResult

            '[IncomeLessOverhead] / [BilledTotal]

            If _OfficeLessOverheadBillPctBilledTotal <> 0 Then

                e.Result = (_OfficeLessOverheadBillPctIncomeLessOverhead / _OfficeLessOverheadBillPctBilledTotal)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub OfficeIncomeLessOverheadBillPct_SummaryReset(sender As Object, e As EventArgs) Handles OfficeIncomeLessOverheadBillPct.SummaryReset

            _OfficeLessOverheadBillPctBilledTotal = 0
            _OfficeLessOverheadBillPctIncomeLessOverhead = 0

        End Sub
        Private Sub OfficeIncomeLessOverheadBillPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles OfficeIncomeLessOverheadBillPct.SummaryRowChanged

            _OfficeLessOverheadBillPctBilledTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.BilledTotal.ToString))
            _OfficeLessOverheadBillPctIncomeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))

        End Sub
        Private Sub OfficeIncomeLessOverheadGIPctProduct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles OfficeIncomeLessOverheadGIPctProduct.SummaryGetResult

            'IIf([TotalGrossIncome]=0,0,[IncomeLessOverhead] / [TotalGrossIncome])

            If _OfficeLessOverheadGIPctTotalGrossIncome <> 0 Then

                e.Result = (_OfficeLessOverheadGIPctProductIncomeLessOverhead / _OfficeLessOverheadGIPctTotalGrossIncome)

            Else

                e.Result = 0

            End If

            e.Handled = True

        End Sub
        Private Sub OfficeIncomeLessOverheadGIPctProduct_SummaryReset(sender As Object, e As EventArgs) Handles OfficeIncomeLessOverheadGIPctProduct.SummaryReset

            _OfficeLessOverheadGIPctTotalGrossIncome = 0
            _OfficeLessOverheadGIPctProductIncomeLessOverhead = 0

        End Sub
        Private Sub OfficeIncomeLessOverheadGIPctProduct_SummaryRowChanged(sender As Object, e As EventArgs) Handles OfficeIncomeLessOverheadGIPctProduct.SummaryRowChanged

            _OfficeLessOverheadGIPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
            _OfficeLessOverheadGIPctProductIncomeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))

        End Sub

        'Private Sub ReportTotalIncomeGIPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles ReportTotalIncomeGIPct.SummaryGetResult

        '    'IIf([TotalGrossIncome] = 0, 0, [TotalIncome] / [TotalGrossIncome])

        '    'If _ReportIncomeGIPctTotalGrossIncome <> 0 Then

        '    '    e.Result = CDec(FormatNumber((_ReportIncomeGIPctTotalIncome / _ReportIncomeGIPctTotalGrossIncome), 5))

        '    'Else

        '    '    e.Result = 0

        '    'End If

        '    'e.Handled = True

        'End Sub
        'Private Sub ReportTotalIncomeGIPct_SummaryReset(sender As Object, e As EventArgs) Handles ReportTotalIncomeGIPct.SummaryReset

        '    '_ReportIncomeGIPctTotalIncome = 0
        '    '_ReportIncomeGIPctTotalGrossIncome = 0

        'End Sub
        'Private Sub ReportTotalIncomeGIPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles ReportTotalIncomeGIPct.SummaryRowChanged

        '    _ReportIncomeGIPctTotalIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalIncome.ToString))
        '    _ReportIncomeGIPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))

        'End Sub
        'Private Sub ReportIncomeLessOverheadBillPct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles ReportIncomeLessOverheadBillPct.SummaryGetResult

        '    '[IncomeLessOverhead] / [BilledTotal]

        '    If _ReportLessOverheadBillPctBilledTotal <> 0 Then

        '        e.Result = (_ReportLessOverheadBillPctIncomeLessOverhead / _ReportLessOverheadBillPctBilledTotal)

        '    Else

        '        e.Result = 0

        '    End If

        '    e.Handled = True

        'End Sub
        'Private Sub ReportIncomeLessOverheadBillPct_SummaryReset(sender As Object, e As EventArgs) Handles ReportIncomeLessOverheadBillPct.SummaryReset

        '    _ReportLessOverheadBillPctBilledTotal = 0
        '    _ReportLessOverheadBillPctIncomeLessOverhead = 0

        'End Sub
        'Private Sub ReportIncomeLessOverheadBillPct_SummaryRowChanged(sender As Object, e As EventArgs) Handles ReportIncomeLessOverheadBillPct.SummaryRowChanged

        '    _ReportLessOverheadBillPctBilledTotal += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.BilledTotal.ToString))
        '    _ReportLessOverheadBillPctIncomeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))

        'End Sub
        'Private Sub ReportIncomeLessOverheadGIPctProduct_SummaryGetResult(sender As Object, e As DevExpress.XtraReports.UI.SummaryGetResultEventArgs) Handles ReportIncomeLessOverheadGIPctProduct.SummaryGetResult

        '    'IIf([TotalGrossIncome]=0,0,[IncomeLessOverhead] / [TotalGrossIncome])

        '    If _ReportLessOverheadGIPctTotalGrossIncome <> 0 Then

        '        e.Result = (_ReportLessOverheadGIPctProductIncomeLessOverhead / _ReportLessOverheadGIPctTotalGrossIncome)

        '    Else

        '        e.Result = 0

        '    End If

        '    e.Handled = True

        'End Sub
        'Private Sub ReportIncomeLessOverheadGIPctProduct_SummaryReset(sender As Object, e As EventArgs) Handles ReportIncomeLessOverheadGIPctProduct.SummaryReset

        '    _ReportLessOverheadGIPctTotalGrossIncome = 0
        '    _ReportLessOverheadGIPctProductIncomeLessOverhead = 0

        'End Sub
        'Private Sub ReportIncomeLessOverheadGIPctProduct_SummaryRowChanged(sender As Object, e As EventArgs) Handles ReportIncomeLessOverheadGIPctProduct.SummaryRowChanged

        '    _ReportLessOverheadGIPctTotalGrossIncome += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.TotalGrossIncome.ToString))
        '    _ReportLessOverheadGIPctProductIncomeLessOverhead += Convert.ToDecimal(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPL.Properties.IncomeLessOverhead.ToString))

        'End Sub

#End Region

#End Region

    End Class

End Namespace