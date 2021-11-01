Namespace Employee

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ExpenseItemsSubReport
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
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LineItemBreak = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelComments_Comments = New DevExpress.XtraReports.UI.XRLabel()
            Me.PictureBoxNonBillable = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.ShowNonBillableFlag = New DevExpress.XtraReports.UI.FormattingRule()
            Me.PictureBoxCreditCard = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.ShowCreditCardFlag = New DevExpress.XtraReports.UI.FormattingRule()
            Me.LabelAmount_Amount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRate_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelQuantity_Quantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFunctionCode_FunctionCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelJobAndComp_JobAndComp = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelComments = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelItemDate_ItemDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelCDP_CDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.LabelCDP = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelNonBillable = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelCreditCard = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelAmount = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelRate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelQuantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFunction = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelJobAndComponent = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelTotalDue_TotalDue = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelLessCreditCard_LessCreditCard = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelTotalExpenses_TotalExpenses = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelTotalDue = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelLessCreditCard = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelTotalExpenses = New DevExpress.XtraReports.UI.XRLabel()
            Me.ClientDivisionProduct = New DevExpress.XtraReports.UI.CalculatedField()
            Me.JobAndComponent = New DevExpress.XtraReports.UI.CalculatedField()
            Me.FunctionAndDescription = New DevExpress.XtraReports.UI.CalculatedField()
            Me.CreditCardAmount = New DevExpress.XtraReports.UI.CalculatedField()
            Me.AmountDue = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineItemBreak, Me.LabelComments_Comments, Me.PictureBoxNonBillable, Me.PictureBoxCreditCard, Me.LabelAmount_Amount, Me.LabelRate_Rate, Me.LabelQuantity_Quantity, Me.LabelFunctionCode_FunctionCode, Me.LabelJobAndComp_JobAndComp, Me.LabelComments, Me.LabelItemDate_ItemDate, Me.LabelCDP_CDP})
            Me.Detail.Dpi = 100.0!
            Me.Detail.HeightF = 60.00003!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineItemBreak
            '
            Me.LineItemBreak.Dpi = 100.0!
            Me.LineItemBreak.LocationFloat = New DevExpress.Utils.PointFloat(0!, 48.83334!)
            Me.LineItemBreak.Name = "LineItemBreak"
            Me.LineItemBreak.SizeF = New System.Drawing.SizeF(750.0!, 11.16669!)
            '
            'LabelComments_Comments
            '
            Me.LabelComments_Comments.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.LabelComments_Comments.Dpi = 100.0!
            Me.LabelComments_Comments.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelComments_Comments.LocationFloat = New DevExpress.Utils.PointFloat(84.41671!, 29.0!)
            Me.LabelComments_Comments.Name = "LabelComments_Comments"
            Me.LabelComments_Comments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelComments_Comments.SizeF = New System.Drawing.SizeF(665.5833!, 19.83332!)
            Me.LabelComments_Comments.StylePriority.UseFont = False
            Me.LabelComments_Comments.StylePriority.UseForeColor = False
            Me.LabelComments_Comments.Text = "LabelComments_Comments"
            '
            'PictureBoxNonBillable
            '
            Me.PictureBoxNonBillable.Dpi = 100.0!
            Me.PictureBoxNonBillable.FormattingRules.Add(Me.ShowNonBillableFlag)
            Me.PictureBoxNonBillable.LocationFloat = New DevExpress.Utils.PointFloat(703.0419!, 3.0!)
            Me.PictureBoxNonBillable.Name = "PictureBoxNonBillable"
            Me.PictureBoxNonBillable.SizeF = New System.Drawing.SizeF(46.95807!, 17.99999!)
            Me.PictureBoxNonBillable.Visible = False
            '
            'ShowNonBillableFlag
            '
            Me.ShowNonBillableFlag.Condition = "Iif([JobNumber] > 0 And [JobComponentNumber] > 0 And [NonBillable] == 1, True, Fa" &
    "lse)"
            '
            '
            '
            Me.ShowNonBillableFlag.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.ShowNonBillableFlag.Name = "ShowNonBillableFlag"
            '
            'PictureBoxCreditCard
            '
            Me.PictureBoxCreditCard.Dpi = 100.0!
            Me.PictureBoxCreditCard.FormattingRules.Add(Me.ShowCreditCardFlag)
            Me.PictureBoxCreditCard.LocationFloat = New DevExpress.Utils.PointFloat(659.2501!, 3.0!)
            Me.PictureBoxCreditCard.Name = "PictureBoxCreditCard"
            Me.PictureBoxCreditCard.SizeF = New System.Drawing.SizeF(43.79175!, 17.99999!)
            Me.PictureBoxCreditCard.Visible = False
            '
            'ShowCreditCardFlag
            '
            Me.ShowCreditCardFlag.Condition = "Iif([CreditCardFlag]==True, True, False)"
            '
            '
            '
            Me.ShowCreditCardFlag.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[True]
            Me.ShowCreditCardFlag.Name = "ShowCreditCardFlag"
            '
            'LabelAmount_Amount
            '
            Me.LabelAmount_Amount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.LabelAmount_Amount.Dpi = 100.0!
            Me.LabelAmount_Amount.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelAmount_Amount.LocationFloat = New DevExpress.Utils.PointFloat(605.0419!, 3.0!)
            Me.LabelAmount_Amount.Name = "LabelAmount_Amount"
            Me.LabelAmount_Amount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelAmount_Amount.SizeF = New System.Drawing.SizeF(54.20828!, 18.0!)
            Me.LabelAmount_Amount.StylePriority.UseFont = False
            Me.LabelAmount_Amount.StylePriority.UseForeColor = False
            Me.LabelAmount_Amount.Text = "LabelAmount_Amount"
            '
            'LabelRate_Rate
            '
            Me.LabelRate_Rate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Rate")})
            Me.LabelRate_Rate.Dpi = 100.0!
            Me.LabelRate_Rate.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelRate_Rate.LocationFloat = New DevExpress.Utils.PointFloat(550.8335!, 3.0!)
            Me.LabelRate_Rate.Name = "LabelRate_Rate"
            Me.LabelRate_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRate_Rate.SizeF = New System.Drawing.SizeF(54.20828!, 18.0!)
            Me.LabelRate_Rate.StylePriority.UseFont = False
            Me.LabelRate_Rate.StylePriority.UseForeColor = False
            Me.LabelRate_Rate.Text = "LabelRate_Rate"
            '
            'LabelQuantity_Quantity
            '
            Me.LabelQuantity_Quantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Quantity")})
            Me.LabelQuantity_Quantity.Dpi = 100.0!
            Me.LabelQuantity_Quantity.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelQuantity_Quantity.LocationFloat = New DevExpress.Utils.PointFloat(516.4168!, 3.0!)
            Me.LabelQuantity_Quantity.Name = "LabelQuantity_Quantity"
            Me.LabelQuantity_Quantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelQuantity_Quantity.SizeF = New System.Drawing.SizeF(34.41666!, 18.0!)
            Me.LabelQuantity_Quantity.StylePriority.UseFont = False
            Me.LabelQuantity_Quantity.StylePriority.UseForeColor = False
            Me.LabelQuantity_Quantity.Text = "LabelQuantity_Quantity"
            '
            'LabelFunctionCode_FunctionCode
            '
            Me.LabelFunctionCode_FunctionCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionAndDescription")})
            Me.LabelFunctionCode_FunctionCode.Dpi = 100.0!
            Me.LabelFunctionCode_FunctionCode.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelFunctionCode_FunctionCode.LocationFloat = New DevExpress.Utils.PointFloat(361.6881!, 3.0!)
            Me.LabelFunctionCode_FunctionCode.Name = "LabelFunctionCode_FunctionCode"
            Me.LabelFunctionCode_FunctionCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFunctionCode_FunctionCode.SizeF = New System.Drawing.SizeF(154.7286!, 18.0!)
            Me.LabelFunctionCode_FunctionCode.StylePriority.UseFont = False
            Me.LabelFunctionCode_FunctionCode.StylePriority.UseForeColor = False
            '
            'LabelJobAndComp_JobAndComp
            '
            Me.LabelJobAndComp_JobAndComp.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobAndComponent")})
            Me.LabelJobAndComp_JobAndComp.Dpi = 100.0!
            Me.LabelJobAndComp_JobAndComp.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelJobAndComp_JobAndComp.LocationFloat = New DevExpress.Utils.PointFloat(206.9581!, 3.0!)
            Me.LabelJobAndComp_JobAndComp.Name = "LabelJobAndComp_JobAndComp"
            Me.LabelJobAndComp_JobAndComp.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelJobAndComp_JobAndComp.SizeF = New System.Drawing.SizeF(154.73!, 18.0!)
            Me.LabelJobAndComp_JobAndComp.StylePriority.UseFont = False
            Me.LabelJobAndComp_JobAndComp.StylePriority.UseForeColor = False
            '
            'LabelComments
            '
            Me.LabelComments.BackColor = System.Drawing.Color.Transparent
            Me.LabelComments.BorderColor = System.Drawing.Color.Black
            Me.LabelComments.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelComments.BorderWidth = 1.0!
            Me.LabelComments.CanGrow = False
            Me.LabelComments.Dpi = 100.0!
            Me.LabelComments.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelComments.ForeColor = System.Drawing.Color.Black
            Me.LabelComments.LocationFloat = New DevExpress.Utils.PointFloat(0!, 29.0!)
            Me.LabelComments.Name = "LabelComments"
            Me.LabelComments.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelComments.SizeF = New System.Drawing.SizeF(84.41667!, 19.83332!)
            Me.LabelComments.StylePriority.UseFont = False
            Me.LabelComments.Text = "Comments:"
            Me.LabelComments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelItemDate_ItemDate
            '
            Me.LabelItemDate_ItemDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ItemDate", "{0:d}")})
            Me.LabelItemDate_ItemDate.Dpi = 100.0!
            Me.LabelItemDate_ItemDate.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelItemDate_ItemDate.LocationFloat = New DevExpress.Utils.PointFloat(0!, 3.0!)
            Me.LabelItemDate_ItemDate.Name = "LabelItemDate_ItemDate"
            Me.LabelItemDate_ItemDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelItemDate_ItemDate.SizeF = New System.Drawing.SizeF(72.95834!, 18.0!)
            Me.LabelItemDate_ItemDate.StylePriority.UseFont = False
            Me.LabelItemDate_ItemDate.StylePriority.UseForeColor = False
            Me.LabelItemDate_ItemDate.Text = "LabelItemDate_ItemDate"
            '
            'LabelCDP_CDP
            '
            Me.LabelCDP_CDP.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDivisionProduct")})
            Me.LabelCDP_CDP.Dpi = 100.0!
            Me.LabelCDP_CDP.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelCDP_CDP.LocationFloat = New DevExpress.Utils.PointFloat(72.95837!, 3.0!)
            Me.LabelCDP_CDP.Name = "LabelCDP_CDP"
            Me.LabelCDP_CDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelCDP_CDP.SizeF = New System.Drawing.SizeF(133.9997!, 18.0!)
            Me.LabelCDP_CDP.StylePriority.UseFont = False
            Me.LabelCDP_CDP.StylePriority.UseForeColor = False
            '
            'TopMargin
            '
            Me.TopMargin.Dpi = 100.0!
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Dpi = 100.0!
            Me.BottomMargin.HeightF = 13.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelCDP
            '
            Me.LabelCDP.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCDP.Dpi = 100.0!
            Me.LabelCDP.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelCDP.ForeColor = System.Drawing.Color.Black
            Me.LabelCDP.LocationFloat = New DevExpress.Utils.PointFloat(72.95837!, 0!)
            Me.LabelCDP.Multiline = True
            Me.LabelCDP.Name = "LabelCDP"
            Me.LabelCDP.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelCDP.SizeF = New System.Drawing.SizeF(133.9997!, 38.0!)
            Me.LabelCDP.StylePriority.UseBorders = False
            Me.LabelCDP.StylePriority.UseFont = False
            Me.LabelCDP.StylePriority.UseForeColor = False
            Me.LabelCDP.StylePriority.UseTextAlignment = False
            Me.LabelCDP.Text = "Client/Division/Product"
            Me.LabelCDP.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelDate
            '
            Me.LabelDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDate.Dpi = 100.0!
            Me.LabelDate.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelDate.ForeColor = System.Drawing.Color.Black
            Me.LabelDate.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDate.Name = "LabelDate"
            Me.LabelDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDate.SizeF = New System.Drawing.SizeF(72.95834!, 38.0!)
            Me.LabelDate.StylePriority.UseBorders = False
            Me.LabelDate.StylePriority.UseFont = False
            Me.LabelDate.StylePriority.UseForeColor = False
            Me.LabelDate.StylePriority.UseTextAlignment = False
            Me.LabelDate.Text = "Item Date"
            Me.LabelDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.LabelNonBillable, Me.LabelCreditCard, Me.LabelAmount, Me.LabelRate, Me.LabelQuantity, Me.LabelFunction, Me.LabelJobAndComponent, Me.LabelDate, Me.LabelCDP})
            Me.GroupHeader.Dpi = 100.0!
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 46.0!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'XrLine1
            '
            Me.XrLine1.Dpi = 100.0!
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 38.0!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(750.0!, 8.0!)
            '
            'LabelNonBillable
            '
            Me.LabelNonBillable.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelNonBillable.Dpi = 100.0!
            Me.LabelNonBillable.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelNonBillable.ForeColor = System.Drawing.Color.Black
            Me.LabelNonBillable.LocationFloat = New DevExpress.Utils.PointFloat(703.0419!, 0!)
            Me.LabelNonBillable.Name = "LabelNonBillable"
            Me.LabelNonBillable.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelNonBillable.SizeF = New System.Drawing.SizeF(46.95813!, 38.0!)
            Me.LabelNonBillable.StylePriority.UseBorders = False
            Me.LabelNonBillable.StylePriority.UseFont = False
            Me.LabelNonBillable.StylePriority.UseForeColor = False
            Me.LabelNonBillable.StylePriority.UseTextAlignment = False
            Me.LabelNonBillable.Text = "Non Billable"
            Me.LabelNonBillable.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelCreditCard
            '
            Me.LabelCreditCard.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCreditCard.Dpi = 100.0!
            Me.LabelCreditCard.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelCreditCard.ForeColor = System.Drawing.Color.Black
            Me.LabelCreditCard.LocationFloat = New DevExpress.Utils.PointFloat(659.2501!, 0!)
            Me.LabelCreditCard.Name = "LabelCreditCard"
            Me.LabelCreditCard.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelCreditCard.SizeF = New System.Drawing.SizeF(43.79175!, 38.0!)
            Me.LabelCreditCard.StylePriority.UseBorders = False
            Me.LabelCreditCard.StylePriority.UseFont = False
            Me.LabelCreditCard.StylePriority.UseForeColor = False
            Me.LabelCreditCard.StylePriority.UseTextAlignment = False
            Me.LabelCreditCard.Text = "Credit Card"
            Me.LabelCreditCard.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelAmount
            '
            Me.LabelAmount.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelAmount.Dpi = 100.0!
            Me.LabelAmount.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelAmount.ForeColor = System.Drawing.Color.Black
            Me.LabelAmount.LocationFloat = New DevExpress.Utils.PointFloat(605.0417!, 0!)
            Me.LabelAmount.Name = "LabelAmount"
            Me.LabelAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelAmount.SizeF = New System.Drawing.SizeF(54.20831!, 38.0!)
            Me.LabelAmount.StylePriority.UseBorders = False
            Me.LabelAmount.StylePriority.UseFont = False
            Me.LabelAmount.StylePriority.UseForeColor = False
            Me.LabelAmount.StylePriority.UseTextAlignment = False
            Me.LabelAmount.Text = "Amount"
            Me.LabelAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelRate
            '
            Me.LabelRate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelRate.Dpi = 100.0!
            Me.LabelRate.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelRate.ForeColor = System.Drawing.Color.Black
            Me.LabelRate.LocationFloat = New DevExpress.Utils.PointFloat(550.8334!, 0!)
            Me.LabelRate.Name = "LabelRate"
            Me.LabelRate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelRate.SizeF = New System.Drawing.SizeF(54.20831!, 38.0!)
            Me.LabelRate.StylePriority.UseBorders = False
            Me.LabelRate.StylePriority.UseFont = False
            Me.LabelRate.StylePriority.UseForeColor = False
            Me.LabelRate.StylePriority.UseTextAlignment = False
            Me.LabelRate.Text = "Rate"
            Me.LabelRate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelQuantity
            '
            Me.LabelQuantity.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelQuantity.Dpi = 100.0!
            Me.LabelQuantity.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelQuantity.ForeColor = System.Drawing.Color.Black
            Me.LabelQuantity.LocationFloat = New DevExpress.Utils.PointFloat(516.4167!, 0!)
            Me.LabelQuantity.Name = "LabelQuantity"
            Me.LabelQuantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelQuantity.SizeF = New System.Drawing.SizeF(34.41669!, 38.0!)
            Me.LabelQuantity.StylePriority.UseBorders = False
            Me.LabelQuantity.StylePriority.UseFont = False
            Me.LabelQuantity.StylePriority.UseForeColor = False
            Me.LabelQuantity.StylePriority.UseTextAlignment = False
            Me.LabelQuantity.Text = "Qty"
            Me.LabelQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelFunction
            '
            Me.LabelFunction.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelFunction.Dpi = 100.0!
            Me.LabelFunction.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelFunction.ForeColor = System.Drawing.Color.Black
            Me.LabelFunction.LocationFloat = New DevExpress.Utils.PointFloat(361.6881!, 0!)
            Me.LabelFunction.Name = "LabelFunction"
            Me.LabelFunction.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFunction.SizeF = New System.Drawing.SizeF(154.7286!, 38.0!)
            Me.LabelFunction.StylePriority.UseBorders = False
            Me.LabelFunction.StylePriority.UseFont = False
            Me.LabelFunction.StylePriority.UseForeColor = False
            Me.LabelFunction.StylePriority.UseTextAlignment = False
            Me.LabelFunction.Text = "Function / Category"
            Me.LabelFunction.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelJobAndComponent
            '
            Me.LabelJobAndComponent.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelJobAndComponent.Dpi = 100.0!
            Me.LabelJobAndComponent.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelJobAndComponent.ForeColor = System.Drawing.Color.Black
            Me.LabelJobAndComponent.LocationFloat = New DevExpress.Utils.PointFloat(206.9581!, 0!)
            Me.LabelJobAndComponent.Name = "LabelJobAndComponent"
            Me.LabelJobAndComponent.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelJobAndComponent.SizeF = New System.Drawing.SizeF(154.7299!, 38.0!)
            Me.LabelJobAndComponent.StylePriority.UseBorders = False
            Me.LabelJobAndComponent.StylePriority.UseFont = False
            Me.LabelJobAndComponent.StylePriority.UseForeColor = False
            Me.LabelJobAndComponent.StylePriority.UseTextAlignment = False
            Me.LabelJobAndComponent.Text = "Job/Comp"
            Me.LabelJobAndComponent.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelTotalDue_TotalDue, Me.LabelLessCreditCard_LessCreditCard, Me.LabelTotalExpenses_TotalExpenses, Me.LabelTotalDue, Me.LabelLessCreditCard, Me.LabelTotalExpenses})
            Me.GroupFooter.Dpi = 100.0!
            Me.GroupFooter.HeightF = 58.33333!
            Me.GroupFooter.Name = "GroupFooter"
            '
            'LabelTotalDue_TotalDue
            '
            Me.LabelTotalDue_TotalDue.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AmountDue")})
            Me.LabelTotalDue_TotalDue.Dpi = 100.0!
            Me.LabelTotalDue_TotalDue.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelTotalDue_TotalDue.LocationFloat = New DevExpress.Utils.PointFloat(605.0417!, 37.99998!)
            Me.LabelTotalDue_TotalDue.Name = "LabelTotalDue_TotalDue"
            Me.LabelTotalDue_TotalDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelTotalDue_TotalDue.SizeF = New System.Drawing.SizeF(108.4166!, 19.0!)
            Me.LabelTotalDue_TotalDue.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0:C2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelTotalDue_TotalDue.Summary = XrSummary1
            '
            'LabelLessCreditCard_LessCreditCard
            '
            Me.LabelLessCreditCard_LessCreditCard.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CreditCardAmount")})
            Me.LabelLessCreditCard_LessCreditCard.Dpi = 100.0!
            Me.LabelLessCreditCard_LessCreditCard.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelLessCreditCard_LessCreditCard.LocationFloat = New DevExpress.Utils.PointFloat(605.0417!, 18.99999!)
            Me.LabelLessCreditCard_LessCreditCard.Name = "LabelLessCreditCard_LessCreditCard"
            Me.LabelLessCreditCard_LessCreditCard.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelLessCreditCard_LessCreditCard.SizeF = New System.Drawing.SizeF(108.4167!, 19.0!)
            Me.LabelLessCreditCard_LessCreditCard.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0:C2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelLessCreditCard_LessCreditCard.Summary = XrSummary2
            '
            'LabelTotalExpenses_TotalExpenses
            '
            Me.LabelTotalExpenses_TotalExpenses.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Amount")})
            Me.LabelTotalExpenses_TotalExpenses.Dpi = 100.0!
            Me.LabelTotalExpenses_TotalExpenses.Font = New System.Drawing.Font("Arial", 7.75!)
            Me.LabelTotalExpenses_TotalExpenses.LocationFloat = New DevExpress.Utils.PointFloat(605.0417!, 0!)
            Me.LabelTotalExpenses_TotalExpenses.Name = "LabelTotalExpenses_TotalExpenses"
            Me.LabelTotalExpenses_TotalExpenses.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelTotalExpenses_TotalExpenses.SizeF = New System.Drawing.SizeF(108.4168!, 19.0!)
            Me.LabelTotalExpenses_TotalExpenses.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0:C2}"
            XrSummary3.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.LabelTotalExpenses_TotalExpenses.Summary = XrSummary3
            '
            'LabelTotalDue
            '
            Me.LabelTotalDue.BackColor = System.Drawing.Color.Transparent
            Me.LabelTotalDue.BorderColor = System.Drawing.Color.Black
            Me.LabelTotalDue.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelTotalDue.BorderWidth = 1.0!
            Me.LabelTotalDue.CanGrow = False
            Me.LabelTotalDue.Dpi = 100.0!
            Me.LabelTotalDue.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelTotalDue.ForeColor = System.Drawing.Color.Black
            Me.LabelTotalDue.LocationFloat = New DevExpress.Utils.PointFloat(488.5834!, 37.99998!)
            Me.LabelTotalDue.Name = "LabelTotalDue"
            Me.LabelTotalDue.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelTotalDue.SizeF = New System.Drawing.SizeF(116.4583!, 19.0!)
            Me.LabelTotalDue.StylePriority.UseFont = False
            Me.LabelTotalDue.Text = "Total Due:"
            Me.LabelTotalDue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelLessCreditCard
            '
            Me.LabelLessCreditCard.BackColor = System.Drawing.Color.Transparent
            Me.LabelLessCreditCard.BorderColor = System.Drawing.Color.Black
            Me.LabelLessCreditCard.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelLessCreditCard.BorderWidth = 1.0!
            Me.LabelLessCreditCard.CanGrow = False
            Me.LabelLessCreditCard.Dpi = 100.0!
            Me.LabelLessCreditCard.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelLessCreditCard.ForeColor = System.Drawing.Color.Black
            Me.LabelLessCreditCard.LocationFloat = New DevExpress.Utils.PointFloat(488.5834!, 18.99999!)
            Me.LabelLessCreditCard.Name = "LabelLessCreditCard"
            Me.LabelLessCreditCard.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelLessCreditCard.SizeF = New System.Drawing.SizeF(116.4583!, 19.0!)
            Me.LabelLessCreditCard.StylePriority.UseFont = False
            Me.LabelLessCreditCard.Text = "Less Credit Card:"
            Me.LabelLessCreditCard.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelTotalExpenses
            '
            Me.LabelTotalExpenses.BackColor = System.Drawing.Color.Transparent
            Me.LabelTotalExpenses.BorderColor = System.Drawing.Color.Black
            Me.LabelTotalExpenses.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelTotalExpenses.BorderWidth = 1.0!
            Me.LabelTotalExpenses.CanGrow = False
            Me.LabelTotalExpenses.Dpi = 100.0!
            Me.LabelTotalExpenses.Font = New System.Drawing.Font("Arial", 7.75!, System.Drawing.FontStyle.Bold)
            Me.LabelTotalExpenses.ForeColor = System.Drawing.Color.Black
            Me.LabelTotalExpenses.LocationFloat = New DevExpress.Utils.PointFloat(488.5834!, 0!)
            Me.LabelTotalExpenses.Name = "LabelTotalExpenses"
            Me.LabelTotalExpenses.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelTotalExpenses.SizeF = New System.Drawing.SizeF(116.4583!, 19.0!)
            Me.LabelTotalExpenses.StylePriority.UseFont = False
            Me.LabelTotalExpenses.Text = "Total Expenses:"
            Me.LabelTotalExpenses.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ClientDivisionProduct
            '
            Me.ClientDivisionProduct.Expression = "Concat(Iif(IsNullOrEmpty([ClientCode]), '', Concat([ClientCode], ' / ')), Iif(IsN" &
    "ullOrEmpty([DivisionCode]), '', Concat([DivisionCode], ' / ')), [ProductCode])"
            Me.ClientDivisionProduct.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.ClientDivisionProduct.Name = "ClientDivisionProduct"
            '
            'JobAndComponent
            '
            Me.JobAndComponent.Expression = "Concat(Iif([JobNumber] > 0, Concat(PadLeft(ToStr([JobNumber]), 6, '0'), '-'), '')" &
    ", Iif([JobComponentNumber] > 0, PadLeft(ToStr([JobComponentNumber]), 3, '0'), ''" &
    "), ' ' + [JobComponentDescription])"
            Me.JobAndComponent.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.JobAndComponent.Name = "JobAndComponent"
            '
            'FunctionAndDescription
            '
            Me.FunctionAndDescription.Expression = "Concat([FunctionCode], ' - ', [FunctionDescription])"
            Me.FunctionAndDescription.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.FunctionAndDescription.Name = "FunctionAndDescription"
            '
            'CreditCardAmount
            '
            Me.CreditCardAmount.Expression = "Iif([CreditCardFlag] == True, [Amount], 0)"
            Me.CreditCardAmount.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.CreditCardAmount.Name = "CreditCardAmount"
            '
            'AmountDue
            '
            Me.AmountDue.Expression = "Iif([CreditCardFlag] == True, 0, [Amount])"
            Me.AmountDue.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.AmountDue.Name = "AmountDue"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Reporting.Database.Classes.ExpenseReportDetailReport)
            '
            'ExpenseItemsSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.GroupFooter})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.ClientDivisionProduct, Me.JobAndComponent, Me.FunctionAndDescription, Me.CreditCardAmount, Me.AmountDue})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.ShowCreditCardFlag, Me.ShowNonBillableFlag})
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 13)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "16.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents LabelItemDate_ItemDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelCDP_CDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelCDP As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelNonBillable As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelCreditCard As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelQuantity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFunction As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelJobAndComponent As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelComments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelJobAndComp_JobAndComp As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PictureBoxNonBillable As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents PictureBoxCreditCard As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents LabelAmount_Amount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelRate_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelQuantity_Quantity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelFunctionCode_FunctionCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LineItemBreak As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelComments_Comments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelTotalDue_TotalDue As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelLessCreditCard_LessCreditCard As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelTotalExpenses_TotalExpenses As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelTotalDue As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelLessCreditCard As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelTotalExpenses As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents ClientDivisionProduct As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents JobAndComponent As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents FunctionAndDescription As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ShowNonBillableFlag As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents ShowCreditCardFlag As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents CreditCardAmount As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents AmountDue As DevExpress.XtraReports.UI.CalculatedField
    End Class

End Namespace