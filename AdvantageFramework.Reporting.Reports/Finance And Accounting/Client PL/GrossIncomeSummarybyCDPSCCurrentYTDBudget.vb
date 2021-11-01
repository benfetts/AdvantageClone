Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace FinanceAndAccounting.ClientPL

    Public Class GrossIncomeSummarybyCDPSCCurrentYTDBudget
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


        Private Sub XRSubreportAllGroups_BeforePrint(sender As Object, e As PrintEventArgs) Handles XRSubreportAllGroups.BeforePrint

            Dim GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport As GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport = Nothing

            If TypeOf XRSubreportAllGroups.ReportSource Is GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport Then

                GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport = XRSubreportAllGroups.ReportSource

                Try

                    GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport.StartPeriod.Value = Me.StartPeriod.Value
                    GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport.EndPeriod.Value = Me.EndPeriod.Value
                    GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport.DataSource = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.ClientPL)).ToList

                Catch ex As Exception
                    GrossIncomeSummarybyCDPSCCurrentYTDBudgetSubReport.DataSource = Nothing
                End Try

            End If

        End Sub


#End Region

#End Region

    End Class

End Namespace