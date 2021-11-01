Namespace Billing

    Public Class SummaryReportV2
        'Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Private _UserDefinedReportID As Integer = 0
        Private _HasCDPHeaderPrinted As Boolean = False

#End Region

#Region " Properties "

        'Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
        '    Get
        '        UserDefinedReportID = _UserDefinedReportID
        '    End Get
        '    Set(value As Integer)
        '        _UserDefinedReportID = value
        '    End Set
        'End Property
        'Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
        '    Get
        '        AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BillingWorksheetProduction
        '    End Get
        'End Property
        'Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
        '    Get
        '        BindingSourceControl = BindingSource
        '    End Get
        'End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub CDPJobCompFooter_AfterPrint(sender As Object, e As EventArgs) Handles CDPJobCompFooter.AfterPrint

            If Not _HasCDPHeaderPrinted Then

                _HasCDPHeaderPrinted = True

            End If

        End Sub
        Private Sub PageBreakCDPJobCompHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageBreakCDPJobCompHeader.BeforePrint

            e.Cancel = Not _HasCDPHeaderPrinted

        End Sub

#End Region

#End Region

    End Class

End Namespace
