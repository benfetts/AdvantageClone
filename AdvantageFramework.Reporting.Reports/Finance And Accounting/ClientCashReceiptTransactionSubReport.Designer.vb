Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ClientCashReceiptTransactionSubReport
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
            Me.Label_DueFromCreditAdjustment = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueFromDebitAdjustment = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToDebitAdjustment = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToCreditAdjustment = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToDebit = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToCredit = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueFromDebit = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueFromCredit = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToAdjustment = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueFromAdjustment = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueTo = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueFrom = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
            Me.Label_DueFromDivision = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueFromProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToDivision = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueFromAdjustmentDivision = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueFromAdjustmentProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToAdjustmentDivision = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueToAdjustmentProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.LabelGroupFooterIntercompanyTransactions_Transactions = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterIntercompanyTransactions_Debit = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterIntercompanyTransactions_Credit = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterIntercompanyTransactions_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterIntercompanyTransactions_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_DueToAdjustmentProduct, Me.Label_DueToAdjustmentDivision, Me.Label_DueFromAdjustmentProduct, Me.Label_DueFromAdjustmentDivision, Me.Label_DueToProduct, Me.Label_DueToDivision, Me.Label_DueFromProduct, Me.Label_DueFromDivision, Me.Label_DueFromCreditAdjustment, Me.Label_DueFromDebitAdjustment, Me.Label_DueToDebitAdjustment, Me.Label_DueToCreditAdjustment, Me.Label_DueToDebit, Me.Label_DueToCredit, Me.Label_DueFromDebit, Me.Label_DueFromCredit, Me.Label_DueToAdjustment, Me.Label_DueFromAdjustment, Me.Label_DueTo, Me.Label_DueFrom})
            Me.Detail.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Detail.HeightF = 76.00001!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DueFromCreditAdjustment
            '
            Me.Label_DueFromCreditAdjustment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueFromCreditAdjustment", "{0:n2}")})
            Me.Label_DueFromCreditAdjustment.LocationFloat = New DevExpress.Utils.PointFloat(479.2501!, 38.00003!)
            Me.Label_DueFromCreditAdjustment.Name = "Label_DueFromCreditAdjustment"
            Me.Label_DueFromCreditAdjustment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromCreditAdjustment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromCreditAdjustment.SizeF = New System.Drawing.SizeF(94.79153!, 19.0!)
            Me.Label_DueFromCreditAdjustment.StylePriority.UseTextAlignment = False
            Me.Label_DueFromCreditAdjustment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DueFromDebitAdjustment
            '
            Me.Label_DueFromDebitAdjustment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueFromDebitAdjustment", "{0:n2}")})
            Me.Label_DueFromDebitAdjustment.LocationFloat = New DevExpress.Utils.PointFloat(374.2503!, 38.00003!)
            Me.Label_DueFromDebitAdjustment.Name = "Label_DueFromDebitAdjustment"
            Me.Label_DueFromDebitAdjustment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromDebitAdjustment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromDebitAdjustment.SizeF = New System.Drawing.SizeF(94.79153!, 19.0!)
            Me.Label_DueFromDebitAdjustment.StylePriority.UseTextAlignment = False
            Me.Label_DueFromDebitAdjustment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DueToDebitAdjustment
            '
            Me.Label_DueToDebitAdjustment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueToDebitAdjustment", "{0:n2}")})
            Me.Label_DueToDebitAdjustment.LocationFloat = New DevExpress.Utils.PointFloat(374.2503!, 57.00002!)
            Me.Label_DueToDebitAdjustment.Name = "Label_DueToDebitAdjustment"
            Me.Label_DueToDebitAdjustment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToDebitAdjustment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToDebitAdjustment.SizeF = New System.Drawing.SizeF(94.7916!, 18.99999!)
            Me.Label_DueToDebitAdjustment.StylePriority.UseTextAlignment = False
            Me.Label_DueToDebitAdjustment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DueToCreditAdjustment
            '
            Me.Label_DueToCreditAdjustment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueToCreditAdjustment", "{0:n2}")})
            Me.Label_DueToCreditAdjustment.LocationFloat = New DevExpress.Utils.PointFloat(479.2501!, 57.00002!)
            Me.Label_DueToCreditAdjustment.Name = "Label_DueToCreditAdjustment"
            Me.Label_DueToCreditAdjustment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToCreditAdjustment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToCreditAdjustment.SizeF = New System.Drawing.SizeF(94.79153!, 18.99998!)
            Me.Label_DueToCreditAdjustment.StylePriority.UseTextAlignment = False
            Me.Label_DueToCreditAdjustment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DueToDebit
            '
            Me.Label_DueToDebit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueToDebit", "{0:n2}")})
            Me.Label_DueToDebit.LocationFloat = New DevExpress.Utils.PointFloat(374.2502!, 18.99999!)
            Me.Label_DueToDebit.Name = "Label_DueToDebit"
            Me.Label_DueToDebit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToDebit.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToDebit.SizeF = New System.Drawing.SizeF(94.79163!, 19.00002!)
            Me.Label_DueToDebit.StylePriority.UseTextAlignment = False
            Me.Label_DueToDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DueToCredit
            '
            Me.Label_DueToCredit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueToCredit", "{0:n2}")})
            Me.Label_DueToCredit.LocationFloat = New DevExpress.Utils.PointFloat(479.2502!, 18.99999!)
            Me.Label_DueToCredit.Name = "Label_DueToCredit"
            Me.Label_DueToCredit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToCredit.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToCredit.SizeF = New System.Drawing.SizeF(94.7916!, 19.00002!)
            Me.Label_DueToCredit.StylePriority.UseTextAlignment = False
            Me.Label_DueToCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DueFromDebit
            '
            Me.Label_DueFromDebit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueFromDebit", "{0:n2}")})
            Me.Label_DueFromDebit.LocationFloat = New DevExpress.Utils.PointFloat(374.2502!, 0.0!)
            Me.Label_DueFromDebit.Name = "Label_DueFromDebit"
            Me.Label_DueFromDebit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromDebit.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromDebit.SizeF = New System.Drawing.SizeF(94.7916!, 19.00001!)
            Me.Label_DueFromDebit.StylePriority.UseTextAlignment = False
            Me.Label_DueFromDebit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DueFromCredit
            '
            Me.Label_DueFromCredit.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueFromCredit", "{0:n2}")})
            Me.Label_DueFromCredit.LocationFloat = New DevExpress.Utils.PointFloat(479.2501!, 0.0!)
            Me.Label_DueFromCredit.Name = "Label_DueFromCredit"
            Me.Label_DueFromCredit.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromCredit.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromCredit.SizeF = New System.Drawing.SizeF(94.79153!, 19.00001!)
            Me.Label_DueFromCredit.StylePriority.UseTextAlignment = False
            Me.Label_DueFromCredit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DueToAdjustment
            '
            Me.Label_DueToAdjustment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueToAdjustment")})
            Me.Label_DueToAdjustment.LocationFloat = New DevExpress.Utils.PointFloat(12.50022!, 57.00002!)
            Me.Label_DueToAdjustment.Name = "Label_DueToAdjustment"
            Me.Label_DueToAdjustment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToAdjustment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToAdjustment.SizeF = New System.Drawing.SizeF(351.1667!, 18.99999!)
            Me.Label_DueToAdjustment.Text = "Label_DueToAdjustment"
            '
            'Label_DueFromAdjustment
            '
            Me.Label_DueFromAdjustment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueFromAdjustment")})
            Me.Label_DueFromAdjustment.LocationFloat = New DevExpress.Utils.PointFloat(12.50019!, 38.00003!)
            Me.Label_DueFromAdjustment.Name = "Label_DueFromAdjustment"
            Me.Label_DueFromAdjustment.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromAdjustment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromAdjustment.SizeF = New System.Drawing.SizeF(351.1667!, 19.0!)
            Me.Label_DueFromAdjustment.Text = "Label_DueFromAdjustment"
            '
            'Label_DueTo
            '
            Me.Label_DueTo.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueTo")})
            Me.Label_DueTo.LocationFloat = New DevExpress.Utils.PointFloat(12.50019!, 18.99999!)
            Me.Label_DueTo.Name = "Label_DueTo"
            Me.Label_DueTo.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueTo.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueTo.SizeF = New System.Drawing.SizeF(351.1667!, 19.00002!)
            Me.Label_DueTo.Text = "Label_DueTo"
            '
            'Label_DueFrom
            '
            Me.Label_DueFrom.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueFrom")})
            Me.Label_DueFrom.LocationFloat = New DevExpress.Utils.PointFloat(12.50019!, 0.0!)
            Me.Label_DueFrom.Name = "Label_DueFrom"
            Me.Label_DueFrom.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFrom.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFrom.SizeF = New System.Drawing.SizeF(351.1667!, 19.00001!)
            Me.Label_DueFrom.Text = "Label_DueFrom"
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
            Me.BottomMargin.HeightF = 33.0!
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
            'Label_DueFromDivision
            '
            Me.Label_DueFromDivision.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerDetailDueFrom.DivisionCode")})
            Me.Label_DueFromDivision.LocationFloat = New DevExpress.Utils.PointFloat(588.0002!, 0.0!)
            Me.Label_DueFromDivision.Name = "Label_DueFromDivision"
            Me.Label_DueFromDivision.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromDivision.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromDivision.SizeF = New System.Drawing.SizeF(52.08331!, 19.00001!)
            Me.Label_DueFromDivision.Text = "Label_DueFromDivision"
            '
            'Label_DueFromProduct
            '
            Me.Label_DueFromProduct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerDetailDueFrom.ProductCode")})
            Me.Label_DueFromProduct.LocationFloat = New DevExpress.Utils.PointFloat(646.0002!, 0.0!)
            Me.Label_DueFromProduct.Name = "Label_DueFromProduct"
            Me.Label_DueFromProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromProduct.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromProduct.SizeF = New System.Drawing.SizeF(52.08325!, 19.00001!)
            Me.Label_DueFromProduct.Text = "Label_DueFromProduct"
            '
            'Label_DueToDivision
            '
            Me.Label_DueToDivision.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerDetailDueTo.DivisionCode")})
            Me.Label_DueToDivision.LocationFloat = New DevExpress.Utils.PointFloat(588.0002!, 19.00002!)
            Me.Label_DueToDivision.Name = "Label_DueToDivision"
            Me.Label_DueToDivision.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToDivision.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToDivision.SizeF = New System.Drawing.SizeF(52.08331!, 19.0!)
            Me.Label_DueToDivision.Text = "Label_DueToDivision"
            '
            'Label_DueToProduct
            '
            Me.Label_DueToProduct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerDetailDueTo.ProductCode")})
            Me.Label_DueToProduct.LocationFloat = New DevExpress.Utils.PointFloat(646.0002!, 19.00002!)
            Me.Label_DueToProduct.Name = "Label_DueToProduct"
            Me.Label_DueToProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToProduct.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToProduct.SizeF = New System.Drawing.SizeF(52.08331!, 19.00001!)
            Me.Label_DueToProduct.Text = "Label_DueToProduct"
            '
            'Label_DueFromAdjustmentDivision
            '
            Me.Label_DueFromAdjustmentDivision.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerDetailDueFromAdjustment.DivisionCode")})
            Me.Label_DueFromAdjustmentDivision.LocationFloat = New DevExpress.Utils.PointFloat(588.0003!, 38.00003!)
            Me.Label_DueFromAdjustmentDivision.Name = "Label_DueFromAdjustmentDivision"
            Me.Label_DueFromAdjustmentDivision.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromAdjustmentDivision.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromAdjustmentDivision.SizeF = New System.Drawing.SizeF(52.08331!, 19.0!)
            Me.Label_DueFromAdjustmentDivision.Text = "Label_DueFromAdjustmentDivision"
            '
            'Label_DueFromAdjustmentProduct
            '
            Me.Label_DueFromAdjustmentProduct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerDetailDueFromAdjustment.ProductCode")})
            Me.Label_DueFromAdjustmentProduct.LocationFloat = New DevExpress.Utils.PointFloat(645.9995!, 38.00003!)
            Me.Label_DueFromAdjustmentProduct.Name = "Label_DueFromAdjustmentProduct"
            Me.Label_DueFromAdjustmentProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueFromAdjustmentProduct.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueFromAdjustmentProduct.SizeF = New System.Drawing.SizeF(52.08344!, 19.0!)
            Me.Label_DueFromAdjustmentProduct.Text = "Label_DueFromAdjustmentProduct"
            '
            'Label_DueToAdjustmentDivision
            '
            Me.Label_DueToAdjustmentDivision.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerDetailDueToAdjustment.DivisionCode")})
            Me.Label_DueToAdjustmentDivision.LocationFloat = New DevExpress.Utils.PointFloat(588.0003!, 57.00002!)
            Me.Label_DueToAdjustmentDivision.Name = "Label_DueToAdjustmentDivision"
            Me.Label_DueToAdjustmentDivision.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToAdjustmentDivision.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToAdjustmentDivision.SizeF = New System.Drawing.SizeF(52.08325!, 18.99997!)
            Me.Label_DueToAdjustmentDivision.Text = "Label_DueToAdjustmentDivision"
            '
            'Label_DueToAdjustmentProduct
            '
            Me.Label_DueToAdjustmentProduct.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GeneralLedgerDetailDueToAdjustment.ProductCode")})
            Me.Label_DueToAdjustmentProduct.LocationFloat = New DevExpress.Utils.PointFloat(645.9996!, 57.00002!)
            Me.Label_DueToAdjustmentProduct.Name = "Label_DueToAdjustmentProduct"
            Me.Label_DueToAdjustmentProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DueToAdjustmentProduct.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.Label_DueToAdjustmentProduct.SizeF = New System.Drawing.SizeF(52.08331!, 18.99997!)
            Me.Label_DueToAdjustmentProduct.Text = "Label_DueToAdjustmentProduct"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.CashReceipts.Classes.ClientCashReceiptTransactionSubreport)
            '
            'LabelGroupFooterIntercompanyTransactions_Transactions
            '
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.BorderWidth = 1.0!
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.CanGrow = False
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.LocationFloat = New DevExpress.Utils.PointFloat(12.50019!, 0.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.Name = "LabelGroupFooterIntercompanyTransactions_Transactions"
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.SizeF = New System.Drawing.SizeF(302.0833!, 19.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.StylePriority.UseBorders = False
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.StylePriority.UseFont = False
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.Text = "Inter-Company Transactions"
            Me.LabelGroupFooterIntercompanyTransactions_Transactions.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupFooterIntercompanyTransactions_Debit
            '
            Me.LabelGroupFooterIntercompanyTransactions_Debit.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterIntercompanyTransactions_Debit.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Debit.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterIntercompanyTransactions_Debit.BorderWidth = 1.0!
            Me.LabelGroupFooterIntercompanyTransactions_Debit.CanGrow = False
            Me.LabelGroupFooterIntercompanyTransactions_Debit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterIntercompanyTransactions_Debit.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Debit.LocationFloat = New DevExpress.Utils.PointFloat(374.2502!, 0.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Debit.Name = "LabelGroupFooterIntercompanyTransactions_Debit"
            Me.LabelGroupFooterIntercompanyTransactions_Debit.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Debit.SizeF = New System.Drawing.SizeF(94.7916!, 19.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Debit.StylePriority.UseBorders = False
            Me.LabelGroupFooterIntercompanyTransactions_Debit.StylePriority.UseFont = False
            Me.LabelGroupFooterIntercompanyTransactions_Debit.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterIntercompanyTransactions_Debit.Text = "Debit"
            Me.LabelGroupFooterIntercompanyTransactions_Debit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterIntercompanyTransactions_Credit
            '
            Me.LabelGroupFooterIntercompanyTransactions_Credit.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterIntercompanyTransactions_Credit.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Credit.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterIntercompanyTransactions_Credit.BorderWidth = 1.0!
            Me.LabelGroupFooterIntercompanyTransactions_Credit.CanGrow = False
            Me.LabelGroupFooterIntercompanyTransactions_Credit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterIntercompanyTransactions_Credit.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Credit.LocationFloat = New DevExpress.Utils.PointFloat(479.2502!, 0.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Credit.Name = "LabelGroupFooterIntercompanyTransactions_Credit"
            Me.LabelGroupFooterIntercompanyTransactions_Credit.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Credit.SizeF = New System.Drawing.SizeF(94.79153!, 19.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Credit.StylePriority.UseBorders = False
            Me.LabelGroupFooterIntercompanyTransactions_Credit.StylePriority.UseFont = False
            Me.LabelGroupFooterIntercompanyTransactions_Credit.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterIntercompanyTransactions_Credit.Text = "Credit"
            Me.LabelGroupFooterIntercompanyTransactions_Credit.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterIntercompanyTransactions_Division
            '
            Me.LabelGroupFooterIntercompanyTransactions_Division.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterIntercompanyTransactions_Division.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Division.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterIntercompanyTransactions_Division.BorderWidth = 1.0!
            Me.LabelGroupFooterIntercompanyTransactions_Division.CanGrow = False
            Me.LabelGroupFooterIntercompanyTransactions_Division.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterIntercompanyTransactions_Division.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Division.LocationFloat = New DevExpress.Utils.PointFloat(588.0001!, 0.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Division.Name = "LabelGroupFooterIntercompanyTransactions_Division"
            Me.LabelGroupFooterIntercompanyTransactions_Division.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Division.SizeF = New System.Drawing.SizeF(52.08331!, 19.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Division.StylePriority.UseBorders = False
            Me.LabelGroupFooterIntercompanyTransactions_Division.StylePriority.UseFont = False
            Me.LabelGroupFooterIntercompanyTransactions_Division.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterIntercompanyTransactions_Division.Text = "Division"
            Me.LabelGroupFooterIntercompanyTransactions_Division.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupFooterIntercompanyTransactions_Product
            '
            Me.LabelGroupFooterIntercompanyTransactions_Product.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterIntercompanyTransactions_Product.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Product.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterIntercompanyTransactions_Product.BorderWidth = 1.0!
            Me.LabelGroupFooterIntercompanyTransactions_Product.CanGrow = False
            Me.LabelGroupFooterIntercompanyTransactions_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterIntercompanyTransactions_Product.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterIntercompanyTransactions_Product.LocationFloat = New DevExpress.Utils.PointFloat(646.0001!, 0.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Product.Name = "LabelGroupFooterIntercompanyTransactions_Product"
            Me.LabelGroupFooterIntercompanyTransactions_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Product.SizeF = New System.Drawing.SizeF(52.08331!, 19.0!)
            Me.LabelGroupFooterIntercompanyTransactions_Product.StylePriority.UseBorders = False
            Me.LabelGroupFooterIntercompanyTransactions_Product.StylePriority.UseFont = False
            Me.LabelGroupFooterIntercompanyTransactions_Product.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterIntercompanyTransactions_Product.Text = "Product"
            Me.LabelGroupFooterIntercompanyTransactions_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterIntercompanyTransactions_Credit, Me.LabelGroupFooterIntercompanyTransactions_Division, Me.LabelGroupFooterIntercompanyTransactions_Product, Me.LabelGroupFooterIntercompanyTransactions_Debit, Me.LabelGroupFooterIntercompanyTransactions_Transactions})
            Me.GroupHeader.HeightF = 19.0!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'ClientCashReceiptTransactionSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
            Me.Margins = New System.Drawing.Printing.Margins(75, 76, 0, 33)
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
        Friend WithEvents Label_DueTo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFrom As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromCredit As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToAdjustment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromAdjustment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromCreditAdjustment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromDebitAdjustment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToDebitAdjustment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToCreditAdjustment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToDebit As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToCredit As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromDebit As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromDivision As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToDivision As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromAdjustmentProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueFromAdjustmentDivision As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToAdjustmentProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DueToAdjustmentDivision As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterIntercompanyTransactions_Transactions As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterIntercompanyTransactions_Debit As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterIntercompanyTransactions_Credit As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterIntercompanyTransactions_Division As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterIntercompanyTransactions_Product As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
    End Class

End Namespace
