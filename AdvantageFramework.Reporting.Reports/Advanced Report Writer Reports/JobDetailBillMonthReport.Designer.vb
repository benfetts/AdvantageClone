Namespace AdvancedReportWriterReports

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class JobDetailBillMonthReport
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Designer
        'It can be modified using the Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ParameterCriteria = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterDateFrom = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterDateTo = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterCutoffsEmployeeTimeDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterCutoffsIncomeOnlyDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterCutoffsAPPostingPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterCurrentStartDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterCurrentEndDate = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterCurrentPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterBilledRecordsStartingPostPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            Me.ParameterBilledRecordsEndingPostPeriod = New DevExpress.XtraReports.Parameters.Parameter()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.JobDetailBillMonthReport)
            '
            'ParameterCriteria
            '
            Me.ParameterCriteria.Name = "ParameterCriteria"
            Me.ParameterCriteria.Visible = False
            '
            'ParameterDateFrom
            '
            Me.ParameterDateFrom.Name = "ParameterDateFrom"
            Me.ParameterDateFrom.Visible = False
            '
            'ParameterDateTo
            '
            Me.ParameterDateTo.Name = "ParameterDateTo"
            Me.ParameterDateTo.Visible = False
            '
            'ParameterCutoffsEmployeeTimeDate
            '
            Me.ParameterCutoffsEmployeeTimeDate.Name = "ParameterCutoffsEmployeeTimeDate"
            Me.ParameterCutoffsEmployeeTimeDate.Visible = False
            '
            'ParameterCutoffsIncomeOnlyDate
            '
            Me.ParameterCutoffsIncomeOnlyDate.Name = "ParameterCutoffsIncomeOnlyDate"
            Me.ParameterCutoffsIncomeOnlyDate.Visible = False
            '
            'ParameterCutoffsAPPostingPeriod
            '
            Me.ParameterCutoffsAPPostingPeriod.Name = "ParameterCutoffsAPPostingPeriod"
            Me.ParameterCutoffsAPPostingPeriod.Visible = False
            '
            'ParameterCurrentStartDate
            '
            Me.ParameterCurrentStartDate.Name = "ParameterCurrentStartDate"
            Me.ParameterCurrentStartDate.Visible = False
            '
            'ParameterCurrentEndDate
            '
            Me.ParameterCurrentEndDate.Name = "ParameterCurrentEndDate"
            Me.ParameterCurrentEndDate.Visible = False
            '
            'ParameterCurrentPeriod
            '
            Me.ParameterCurrentPeriod.Name = "ParameterCurrentPeriod"
            Me.ParameterCurrentPeriod.Visible = False
            '
            'ParameterBilledRecordsStartingPostPeriod
            '
            Me.ParameterBilledRecordsStartingPostPeriod.Name = "ParameterBilledRecordsStartingPostPeriod"
            Me.ParameterBilledRecordsStartingPostPeriod.Visible = False
            '
            'ParameterBilledRecordsEndingPostPeriod
            '
            Me.ParameterBilledRecordsEndingPostPeriod.Name = "ParameterBilledRecordsEndingPostPeriod"
            Me.ParameterBilledRecordsEndingPostPeriod.Visible = False
            '
            'JobDetailBillMonthReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin})
            Me.DataSource = Me.BindingSource
            Me.Parameters.AddRange(New DevExpress.XtraReports.Parameters.Parameter() {Me.ParameterCriteria, Me.ParameterDateFrom, Me.ParameterDateTo, Me.ParameterCutoffsEmployeeTimeDate, Me.ParameterCutoffsIncomeOnlyDate, Me.ParameterCutoffsAPPostingPeriod, Me.ParameterCurrentStartDate, Me.ParameterCurrentEndDate, Me.ParameterCurrentPeriod, Me.ParameterBilledRecordsStartingPostPeriod, Me.ParameterBilledRecordsEndingPostPeriod})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents ParameterCriteria As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterDateFrom As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterDateTo As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterCutoffsEmployeeTimeDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterCutoffsIncomeOnlyDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterCutoffsAPPostingPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterCurrentStartDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterCurrentEndDate As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterCurrentPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterBilledRecordsStartingPostPeriod As DevExpress.XtraReports.Parameters.Parameter
        Friend WithEvents ParameterBilledRecordsEndingPostPeriod As DevExpress.XtraReports.Parameters.Parameter
    End Class


End Namespace
