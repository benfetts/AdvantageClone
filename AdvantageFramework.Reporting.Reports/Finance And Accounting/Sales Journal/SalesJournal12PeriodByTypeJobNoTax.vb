Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.SalesJournal

    Public Class SalesJournal12PeriodByTypeJobNoTax
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


        Private Sub XrSubreport_Footer_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrSubreport_Footer.BeforePrint
            'objects
            Dim SalesJournal12PeriodFooterSubNoTax As SalesJournal12PeriodFooterSubNoTax = Nothing

            If TypeOf XrSubreport_Footer.ReportSource Is SalesJournal12PeriodFooterSubNoTax Then

                SalesJournal12PeriodFooterSubNoTax = XrSubreport_Footer.ReportSource

                Try
                    SalesJournal12PeriodFooterSubNoTax.StartPeriod.Value = Me.StartPeriod.Value
                    SalesJournal12PeriodFooterSubNoTax.EndPeriod.Value = Me.EndPeriod.Value
                    SalesJournal12PeriodFooterSubNoTax.DataSource = Me.DataSource
                    'SalesJournal12PeriodFooterSub.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Database.Classes.SalesJournalReport)).ToList.Where(Function(CPL) CPL.ClientCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.ClientCode.ToString) AndAlso
                    'CPL.DivisionCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.DivisionCode.ToString) AndAlso
                    'CPL.ProductCode = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.ClientPLDetail.Properties.ProductCode.ToString)).ToList

                    If SalesJournal12PeriodFooterSubNoTax.RowCount = 0 Then
                        Me.XrSubreport_Footer.Visible = False
                    Else
                        Me.XrSubreport_Footer.Visible = True
                    End If


                Catch ex As Exception
                    SalesJournal12PeriodFooterSubNoTax.DataSource = Nothing
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