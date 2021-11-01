Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace ProductionWIP
    Public Class ProductionWIPAgedSummarybyClient

        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _Grouping As String = ""
        Friend WithEvents TopMarginBand1 As TopMarginBand
        Friend WithEvents DetailBand1 As DetailBand

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = Nothing
            End Get
        End Property
        Public WriteOnly Property Grouping As String
            Set(value As String)
                _Grouping = value
            End Set
        End Property

        Private Sub InitializeComponent()
            Me.TopMarginBand1 = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.DetailBand1 = New DevExpress.XtraReports.UI.DetailBand()
            Me.BottomMarginBand1 = New DevExpress.XtraReports.UI.BottomMarginBand()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'TopMarginBand1
            '
            Me.TopMarginBand1.Name = "TopMarginBand1"
            '
            'DetailBand1
            '
            Me.DetailBand1.Name = "DetailBand1"
            '
            'BottomMarginBand1
            '
            Me.BottomMarginBand1.Name = "BottomMarginBand1"
            '
            'ProductionWIPAgedSummarybyClient
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.TopMarginBand1, Me.DetailBand1, Me.BottomMarginBand1})
            Me.Version = "18.1"
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub

        Friend WithEvents BottomMarginBand1 As BottomMarginBand

#End Region
    End Class

End Namespace