Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ClientCashReceiptPartialPaymentSubReport
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
            Me.LabelDetail_OrderNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_JobNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_FunctionCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_JobComponent = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_PaymentAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.LabelGroupHeader_PaymentAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelGroupHeader_OrderLine = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_OrderNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_Function = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_JobComp = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupHeader_Job = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_OrderNumber, Me.LabelDetail_JobNumber, Me.LabelDetail_FunctionCode, Me.LabelDetail_JobComponent, Me.LabelDetail_OrderLine, Me.LabelDetail_PaymentAmount})
            Me.Detail.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Detail.HeightF = 19.00002!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_OrderNumber
            '
            Me.LabelDetail_OrderNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderNumber")})
            Me.LabelDetail_OrderNumber.LocationFloat = New DevExpress.Utils.PointFloat(343.75!, 0.0!)
            Me.LabelDetail_OrderNumber.Name = "LabelDetail_OrderNumber"
            Me.LabelDetail_OrderNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_OrderNumber.SizeF = New System.Drawing.SizeF(100.0!, 19.00001!)
            Me.LabelDetail_OrderNumber.Text = "LabelDetail_OrderNumber"
            '
            'LabelDetail_JobNumber
            '
            Me.LabelDetail_JobNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber")})
            Me.LabelDetail_JobNumber.LocationFloat = New DevExpress.Utils.PointFloat(101.0419!, 0.0!)
            Me.LabelDetail_JobNumber.Name = "LabelDetail_JobNumber"
            Me.LabelDetail_JobNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_JobNumber.SizeF = New System.Drawing.SizeF(100.0!, 19.00001!)
            Me.LabelDetail_JobNumber.Text = "LabelDetail_JobNumber"
            '
            'LabelDetail_FunctionCode
            '
            Me.LabelDetail_FunctionCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionCode")})
            Me.LabelDetail_FunctionCode.LocationFloat = New DevExpress.Utils.PointFloat(260.4169!, 0.0!)
            Me.LabelDetail_FunctionCode.Name = "LabelDetail_FunctionCode"
            Me.LabelDetail_FunctionCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_FunctionCode.SizeF = New System.Drawing.SizeF(66.66667!, 19.00002!)
            Me.LabelDetail_FunctionCode.Text = "LabelDetail_FunctionCode"
            '
            'LabelDetail_JobComponent
            '
            Me.LabelDetail_JobComponent.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobComponentNumber")})
            Me.LabelDetail_JobComponent.LocationFloat = New DevExpress.Utils.PointFloat(201.0419!, 0.0!)
            Me.LabelDetail_JobComponent.Name = "LabelDetail_JobComponent"
            Me.LabelDetail_JobComponent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_JobComponent.SizeF = New System.Drawing.SizeF(59.37499!, 19.00002!)
            Me.LabelDetail_JobComponent.Text = "LabelDetail_JobComponent"
            '
            'LabelDetail_OrderLine
            '
            Me.LabelDetail_OrderLine.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderLineNumber")})
            Me.LabelDetail_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(443.75!, 0.0!)
            Me.LabelDetail_OrderLine.Name = "LabelDetail_OrderLine"
            Me.LabelDetail_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_OrderLine.SizeF = New System.Drawing.SizeF(59.37499!, 19.00001!)
            Me.LabelDetail_OrderLine.Text = "LabelDetail_OrderLine"
            '
            'LabelDetail_PaymentAmount
            '
            Me.LabelDetail_PaymentAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PaymentAmount")})
            Me.LabelDetail_PaymentAmount.LocationFloat = New DevExpress.Utils.PointFloat(521.3334!, 0.0!)
            Me.LabelDetail_PaymentAmount.Name = "LabelDetail_PaymentAmount"
            Me.LabelDetail_PaymentAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_PaymentAmount.SizeF = New System.Drawing.SizeF(100.0!, 19.00001!)
            Me.LabelDetail_PaymentAmount.StylePriority.UseTextAlignment = False
            Me.LabelDetail_PaymentAmount.Text = "LabelDetail_PaymentAmount"
            Me.LabelDetail_PaymentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 25.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'XrControlStyle1
            '
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'FormattingRule1
            '
            Me.FormattingRule1.Name = "FormattingRule1"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment)
            '
            'LabelGroupHeader_PaymentAmount
            '
            Me.LabelGroupHeader_PaymentAmount.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_PaymentAmount.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_PaymentAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_PaymentAmount.BorderWidth = 1.0!
            Me.LabelGroupHeader_PaymentAmount.CanGrow = False
            Me.LabelGroupHeader_PaymentAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_PaymentAmount.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_PaymentAmount.LocationFloat = New DevExpress.Utils.PointFloat(521.3333!, 5.499983!)
            Me.LabelGroupHeader_PaymentAmount.Name = "LabelGroupHeader_PaymentAmount"
            Me.LabelGroupHeader_PaymentAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_PaymentAmount.SizeF = New System.Drawing.SizeF(100.0001!, 19.0!)
            Me.LabelGroupHeader_PaymentAmount.StylePriority.UseBorders = False
            Me.LabelGroupHeader_PaymentAmount.StylePriority.UseFont = False
            Me.LabelGroupHeader_PaymentAmount.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_PaymentAmount.Text = "Partial Payment"
            Me.LabelGroupHeader_PaymentAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeader_OrderLine, Me.LabelGroupHeader_OrderNumber, Me.LabelGroupHeader_Function, Me.LabelGroupHeader_JobComp, Me.LabelGroupHeader_Job, Me.LabelGroupHeader_PaymentAmount})
            Me.GroupHeader.HeightF = 24.49999!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'LabelGroupHeader_OrderLine
            '
            Me.LabelGroupHeader_OrderLine.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_OrderLine.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_OrderLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_OrderLine.BorderWidth = 1.0!
            Me.LabelGroupHeader_OrderLine.CanGrow = False
            Me.LabelGroupHeader_OrderLine.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_OrderLine.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_OrderLine.LocationFloat = New DevExpress.Utils.PointFloat(443.75!, 5.499983!)
            Me.LabelGroupHeader_OrderLine.Name = "LabelGroupHeader_OrderLine"
            Me.LabelGroupHeader_OrderLine.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_OrderLine.SizeF = New System.Drawing.SizeF(59.375!, 19.0!)
            Me.LabelGroupHeader_OrderLine.StylePriority.UseBorders = False
            Me.LabelGroupHeader_OrderLine.StylePriority.UseFont = False
            Me.LabelGroupHeader_OrderLine.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_OrderLine.Text = "Line"
            Me.LabelGroupHeader_OrderLine.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_OrderNumber
            '
            Me.LabelGroupHeader_OrderNumber.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_OrderNumber.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_OrderNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_OrderNumber.BorderWidth = 1.0!
            Me.LabelGroupHeader_OrderNumber.CanGrow = False
            Me.LabelGroupHeader_OrderNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_OrderNumber.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_OrderNumber.LocationFloat = New DevExpress.Utils.PointFloat(343.75!, 5.499983!)
            Me.LabelGroupHeader_OrderNumber.Name = "LabelGroupHeader_OrderNumber"
            Me.LabelGroupHeader_OrderNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_OrderNumber.SizeF = New System.Drawing.SizeF(100.0001!, 19.0!)
            Me.LabelGroupHeader_OrderNumber.StylePriority.UseBorders = False
            Me.LabelGroupHeader_OrderNumber.StylePriority.UseFont = False
            Me.LabelGroupHeader_OrderNumber.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_OrderNumber.Text = "Order"
            Me.LabelGroupHeader_OrderNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_Function
            '
            Me.LabelGroupHeader_Function.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_Function.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_Function.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_Function.BorderWidth = 1.0!
            Me.LabelGroupHeader_Function.CanGrow = False
            Me.LabelGroupHeader_Function.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_Function.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_Function.LocationFloat = New DevExpress.Utils.PointFloat(260.4169!, 5.499983!)
            Me.LabelGroupHeader_Function.Name = "LabelGroupHeader_Function"
            Me.LabelGroupHeader_Function.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_Function.SizeF = New System.Drawing.SizeF(66.66667!, 19.0!)
            Me.LabelGroupHeader_Function.StylePriority.UseBorders = False
            Me.LabelGroupHeader_Function.StylePriority.UseFont = False
            Me.LabelGroupHeader_Function.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_Function.Text = "Function"
            Me.LabelGroupHeader_Function.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_JobComp
            '
            Me.LabelGroupHeader_JobComp.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_JobComp.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_JobComp.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_JobComp.BorderWidth = 1.0!
            Me.LabelGroupHeader_JobComp.CanGrow = False
            Me.LabelGroupHeader_JobComp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_JobComp.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_JobComp.LocationFloat = New DevExpress.Utils.PointFloat(201.042!, 5.499983!)
            Me.LabelGroupHeader_JobComp.Name = "LabelGroupHeader_JobComp"
            Me.LabelGroupHeader_JobComp.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_JobComp.SizeF = New System.Drawing.SizeF(59.37492!, 19.0!)
            Me.LabelGroupHeader_JobComp.StylePriority.UseBorders = False
            Me.LabelGroupHeader_JobComp.StylePriority.UseFont = False
            Me.LabelGroupHeader_JobComp.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_JobComp.Text = "Comp"
            Me.LabelGroupHeader_JobComp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupHeader_Job
            '
            Me.LabelGroupHeader_Job.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupHeader_Job.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_Job.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupHeader_Job.BorderWidth = 1.0!
            Me.LabelGroupHeader_Job.CanGrow = False
            Me.LabelGroupHeader_Job.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupHeader_Job.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupHeader_Job.LocationFloat = New DevExpress.Utils.PointFloat(101.0419!, 5.499983!)
            Me.LabelGroupHeader_Job.Name = "LabelGroupHeader_Job"
            Me.LabelGroupHeader_Job.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeader_Job.SizeF = New System.Drawing.SizeF(100.0001!, 19.0!)
            Me.LabelGroupHeader_Job.StylePriority.UseBorders = False
            Me.LabelGroupHeader_Job.StylePriority.UseFont = False
            Me.LabelGroupHeader_Job.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeader_Job.Text = "Job"
            Me.LabelGroupHeader_Job.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ClientCashReceiptPartialPaymentSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
            Me.Margins = New System.Drawing.Printing.Margins(75, 76, 0, 25)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
        Private WithEvents LabelGroupHeader_PaymentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents LabelDetail_JobNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_PaymentAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_OrderNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_FunctionCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_JobComponent As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_OrderLine As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_OrderNumber As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_Function As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_JobComp As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupHeader_Job As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
