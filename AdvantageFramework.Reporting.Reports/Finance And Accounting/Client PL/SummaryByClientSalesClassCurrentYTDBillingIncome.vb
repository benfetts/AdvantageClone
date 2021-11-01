Imports System.Drawing.Printing

Namespace FinanceAndAccounting.ClientPL

    Public Class SummaryByClientSalesClassCurrentYTDBillingIncome
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

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
        Private Sub XRSubreportAllGroups_BeforePrint(sender As Object, e As PrintEventArgs) Handles XRSubreportAllGroups.BeforePrint
            'objects
            Dim SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport As SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport = Nothing

            If TypeOf XRSubreportAllGroups.ReportSource Is SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport Then

                SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport = XRSubreportAllGroups.ReportSource

                Try
                    SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPL)).ToList

                Catch ex As Exception
                    SummaryByClientSalesClassCurrentYTDBillingIncomeSubReport.DataSource = Nothing
                End Try

            End If
        End Sub

#End Region

#End Region

    End Class

End Namespace