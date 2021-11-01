Namespace PurchaseOrder

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class PurchaseOrderDetailsSubReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.Label_BigDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_JobComp = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ClientProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_LineTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Quantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_LineNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubBand1 = New DevExpress.XtraReports.UI.SubBand()
            Me.Line_ItemSeparator = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_DetailDescriptionAndInstructions = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.LabelFooter_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooter_PurchaseOrderTotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineFooter_Separator = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelHeader_ItemNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelHeader_JobComp = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_ClientProduct = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Total = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Quantity = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_BigDescription, Me.Label_JobComp, Me.Label_ClientProduct, Me.Label_LineTotal, Me.Label_Rate, Me.Label_Quantity, Me.Label_Description, Me.Label_LineNumber})
            Me.Detail.HeightF = 18.0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.SubBands.AddRange(New DevExpress.XtraReports.UI.SubBand() {Me.SubBand1})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_BigDescription
            '
            Me.Label_BigDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LineDescription")})
            Me.Label_BigDescription.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_BigDescription.LocationFloat = New DevExpress.Utils.PointFloat(45.87504!, 0!)
            Me.Label_BigDescription.Multiline = True
            Me.Label_BigDescription.Name = "Label_BigDescription"
            Me.Label_BigDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_BigDescription.SizeF = New System.Drawing.SizeF(469.9587!, 18.0!)
            Me.Label_BigDescription.StylePriority.UseFont = False
            Me.Label_BigDescription.Text = "Label_Description"
            '
            'Label_JobComp
            '
            Me.Label_JobComp.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_JobComp.LocationFloat = New DevExpress.Utils.PointFloat(369.4168!, 0!)
            Me.Label_JobComp.Multiline = True
            Me.Label_JobComp.Name = "Label_JobComp"
            Me.Label_JobComp.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_JobComp.SizeF = New System.Drawing.SizeF(146.4169!, 18.0!)
            Me.Label_JobComp.StylePriority.UseFont = False
            '
            'Label_ClientProduct
            '
            Me.Label_ClientProduct.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_ClientProduct.LocationFloat = New DevExpress.Utils.PointFloat(200.8748!, 0!)
            Me.Label_ClientProduct.Multiline = True
            Me.Label_ClientProduct.Name = "Label_ClientProduct"
            Me.Label_ClientProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_ClientProduct.SizeF = New System.Drawing.SizeF(168.5416!, 18.0!)
            Me.Label_ClientProduct.StylePriority.UseFont = False
            '
            'Label_LineTotal
            '
            Me.Label_LineTotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExtendedAmount", "{0:c2}")})
            Me.Label_LineTotal.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_LineTotal.LocationFloat = New DevExpress.Utils.PointFloat(668.7084!, 0!)
            Me.Label_LineTotal.Name = "Label_LineTotal"
            Me.Label_LineTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_LineTotal.SizeF = New System.Drawing.SizeF(81.29163!, 18.0!)
            Me.Label_LineTotal.StylePriority.UseFont = False
            Me.Label_LineTotal.Text = "Label_LineTotal"
            '
            'Label_Rate
            '
            Me.Label_Rate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Rate")})
            Me.Label_Rate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Rate.LocationFloat = New DevExpress.Utils.PointFloat(597.8334!, 0!)
            Me.Label_Rate.Name = "Label_Rate"
            Me.Label_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Rate.SizeF = New System.Drawing.SizeF(70.87506!, 18.0!)
            Me.Label_Rate.StylePriority.UseFont = False
            Me.Label_Rate.TextFormatString = "{0:n4}"
            '
            'Label_Quantity
            '
            Me.Label_Quantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Quantity", "{0:n0}")})
            Me.Label_Quantity.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Quantity.LocationFloat = New DevExpress.Utils.PointFloat(515.8337!, 0!)
            Me.Label_Quantity.Name = "Label_Quantity"
            Me.Label_Quantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Quantity.SizeF = New System.Drawing.SizeF(81.99945!, 18.0!)
            Me.Label_Quantity.StylePriority.UseFont = False
            Me.Label_Quantity.Text = "Label_Quantity"
            '
            'Label_Description
            '
            Me.Label_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LineDescription")})
            Me.Label_Description.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Description.LocationFloat = New DevExpress.Utils.PointFloat(45.87504!, 0!)
            Me.Label_Description.Multiline = True
            Me.Label_Description.Name = "Label_Description"
            Me.Label_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Description.SizeF = New System.Drawing.SizeF(154.9998!, 18.0!)
            Me.Label_Description.StylePriority.UseFont = False
            Me.Label_Description.Text = "Label_Description"
            '
            'Label_LineNumber
            '
            Me.Label_LineNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LineNumber")})
            Me.Label_LineNumber.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_LineNumber.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.Label_LineNumber.Name = "Label_LineNumber"
            Me.Label_LineNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_LineNumber.SizeF = New System.Drawing.SizeF(45.875!, 18.0!)
            Me.Label_LineNumber.StylePriority.UseFont = False
            Me.Label_LineNumber.Text = "Label_LineNumber"
            '
            'SubBand1
            '
            Me.SubBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Line_ItemSeparator, Me.Label_DetailDescriptionAndInstructions})
            Me.SubBand1.HeightF = 31.83332!
            Me.SubBand1.Name = "SubBand1"
            '
            'Line_ItemSeparator
            '
            Me.Line_ItemSeparator.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid
            Me.Line_ItemSeparator.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.Line_ItemSeparator.LocationFloat = New DevExpress.Utils.PointFloat(0!, 18.83332!)
            Me.Line_ItemSeparator.Name = "Line_ItemSeparator"
            Me.Line_ItemSeparator.SizeF = New System.Drawing.SizeF(749.9999!, 13.0!)
            Me.Line_ItemSeparator.StylePriority.UseBorderDashStyle = False
            '
            'Label_DetailDescriptionAndInstructions
            '
            Me.Label_DetailDescriptionAndInstructions.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_DetailDescriptionAndInstructions.LocationFloat = New DevExpress.Utils.PointFloat(45.87504!, 0!)
            Me.Label_DetailDescriptionAndInstructions.Multiline = True
            Me.Label_DetailDescriptionAndInstructions.Name = "Label_DetailDescriptionAndInstructions"
            Me.Label_DetailDescriptionAndInstructions.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DetailDescriptionAndInstructions.SizeF = New System.Drawing.SizeF(703.1249!, 18.0!)
            Me.Label_DetailDescriptionAndInstructions.StylePriority.UseFont = False
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 6.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelFooter_Total
            '
            Me.LabelFooter_Total.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ExtendedAmount")})
            Me.LabelFooter_Total.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelFooter_Total.LocationFloat = New DevExpress.Utils.PointFloat(668.7084!, 14.49999!)
            Me.LabelFooter_Total.Name = "LabelFooter_Total"
            Me.LabelFooter_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelFooter_Total.SizeF = New System.Drawing.SizeF(81.29163!, 18.0!)
            Me.LabelFooter_Total.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0:c2}"
            XrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelFooter_Total.Summary = XrSummary1
            Me.LabelFooter_Total.Text = "LabelFooter_Total"
            '
            'LabelFooter_PurchaseOrderTotal
            '
            Me.LabelFooter_PurchaseOrderTotal.BackColor = System.Drawing.Color.Transparent
            Me.LabelFooter_PurchaseOrderTotal.BorderColor = System.Drawing.Color.Black
            Me.LabelFooter_PurchaseOrderTotal.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelFooter_PurchaseOrderTotal.BorderWidth = 1.0!
            Me.LabelFooter_PurchaseOrderTotal.CanGrow = False
            Me.LabelFooter_PurchaseOrderTotal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelFooter_PurchaseOrderTotal.ForeColor = System.Drawing.Color.Black
            Me.LabelFooter_PurchaseOrderTotal.LocationFloat = New DevExpress.Utils.PointFloat(528.3337!, 14.49999!)
            Me.LabelFooter_PurchaseOrderTotal.Name = "LabelFooter_PurchaseOrderTotal"
            Me.LabelFooter_PurchaseOrderTotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelFooter_PurchaseOrderTotal.SizeF = New System.Drawing.SizeF(140.3748!, 18.0!)
            Me.LabelFooter_PurchaseOrderTotal.StylePriority.UseFont = False
            Me.LabelFooter_PurchaseOrderTotal.Text = "Purchase Order Total:"
            Me.LabelFooter_PurchaseOrderTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LineFooter_Separator
            '
            Me.LineFooter_Separator.BorderColor = System.Drawing.Color.Silver
            Me.LineFooter_Separator.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineFooter_Separator.BorderWidth = 4.0!
            Me.LineFooter_Separator.ForeColor = System.Drawing.Color.Silver
            Me.LineFooter_Separator.LineWidth = 4.0!
            Me.LineFooter_Separator.LocationFloat = New DevExpress.Utils.PointFloat(0!, 5.0!)
            Me.LineFooter_Separator.Name = "LineFooter_Separator"
            Me.LineFooter_Separator.SizeF = New System.Drawing.SizeF(749.9999!, 4.0!)
            '
            'LabelHeader_ItemNumber
            '
            Me.LabelHeader_ItemNumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_ItemNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_ItemNumber.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_ItemNumber.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelHeader_ItemNumber.Name = "LabelHeader_ItemNumber"
            Me.LabelHeader_ItemNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_ItemNumber.SizeF = New System.Drawing.SizeF(45.875!, 27.99999!)
            Me.LabelHeader_ItemNumber.StylePriority.UseBorders = False
            Me.LabelHeader_ItemNumber.StylePriority.UseFont = False
            Me.LabelHeader_ItemNumber.StylePriority.UseForeColor = False
            Me.LabelHeader_ItemNumber.StylePriority.UseTextAlignment = False
            Me.LabelHeader_ItemNumber.Text = "Item #"
            Me.LabelHeader_ItemNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.LabelHeader_JobComp, Me.LabelHeader_ClientProduct, Me.LabelHeader_Total, Me.LabelHeader_Rate, Me.LabelHeader_Quantity, Me.LabelHeader_Description, Me.LabelHeader_ItemNumber})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 35.99999!
            Me.GroupHeader.Name = "GroupHeader"
            Me.GroupHeader.RepeatEveryPage = True
            '
            'XrLine1
            '
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 27.99999!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(750.0!, 8.0!)
            '
            'LabelHeader_JobComp
            '
            Me.LabelHeader_JobComp.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_JobComp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_JobComp.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_JobComp.LocationFloat = New DevExpress.Utils.PointFloat(369.4168!, 0!)
            Me.LabelHeader_JobComp.Name = "LabelHeader_JobComp"
            Me.LabelHeader_JobComp.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_JobComp.SizeF = New System.Drawing.SizeF(146.4169!, 27.99999!)
            Me.LabelHeader_JobComp.StylePriority.UseBorders = False
            Me.LabelHeader_JobComp.StylePriority.UseFont = False
            Me.LabelHeader_JobComp.StylePriority.UseForeColor = False
            Me.LabelHeader_JobComp.StylePriority.UseTextAlignment = False
            Me.LabelHeader_JobComp.Text = "Job / Comp"
            Me.LabelHeader_JobComp.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_ClientProduct
            '
            Me.LabelHeader_ClientProduct.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_ClientProduct.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_ClientProduct.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_ClientProduct.LocationFloat = New DevExpress.Utils.PointFloat(200.8748!, 0!)
            Me.LabelHeader_ClientProduct.Name = "LabelHeader_ClientProduct"
            Me.LabelHeader_ClientProduct.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_ClientProduct.SizeF = New System.Drawing.SizeF(168.5416!, 27.99999!)
            Me.LabelHeader_ClientProduct.StylePriority.UseBorders = False
            Me.LabelHeader_ClientProduct.StylePriority.UseFont = False
            Me.LabelHeader_ClientProduct.StylePriority.UseForeColor = False
            Me.LabelHeader_ClientProduct.StylePriority.UseTextAlignment = False
            Me.LabelHeader_ClientProduct.Text = "Client / Product"
            Me.LabelHeader_ClientProduct.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Total
            '
            Me.LabelHeader_Total.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Total.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Total.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Total.LocationFloat = New DevExpress.Utils.PointFloat(668.7084!, 0!)
            Me.LabelHeader_Total.Name = "LabelHeader_Total"
            Me.LabelHeader_Total.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Total.SizeF = New System.Drawing.SizeF(81.29163!, 28.00001!)
            Me.LabelHeader_Total.StylePriority.UseBorders = False
            Me.LabelHeader_Total.StylePriority.UseFont = False
            Me.LabelHeader_Total.StylePriority.UseForeColor = False
            Me.LabelHeader_Total.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Total.Text = "Total"
            Me.LabelHeader_Total.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Rate
            '
            Me.LabelHeader_Rate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Rate.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Rate.LocationFloat = New DevExpress.Utils.PointFloat(597.8334!, 0!)
            Me.LabelHeader_Rate.Name = "LabelHeader_Rate"
            Me.LabelHeader_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Rate.SizeF = New System.Drawing.SizeF(70.87506!, 27.99999!)
            Me.LabelHeader_Rate.StylePriority.UseBorders = False
            Me.LabelHeader_Rate.StylePriority.UseFont = False
            Me.LabelHeader_Rate.StylePriority.UseForeColor = False
            Me.LabelHeader_Rate.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Rate.Text = "Rate"
            Me.LabelHeader_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Quantity
            '
            Me.LabelHeader_Quantity.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Quantity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Quantity.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Quantity.LocationFloat = New DevExpress.Utils.PointFloat(515.8337!, 0!)
            Me.LabelHeader_Quantity.Name = "LabelHeader_Quantity"
            Me.LabelHeader_Quantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Quantity.SizeF = New System.Drawing.SizeF(81.99945!, 27.99999!)
            Me.LabelHeader_Quantity.StylePriority.UseBorders = False
            Me.LabelHeader_Quantity.StylePriority.UseFont = False
            Me.LabelHeader_Quantity.StylePriority.UseForeColor = False
            Me.LabelHeader_Quantity.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Quantity.Text = "Qty"
            Me.LabelHeader_Quantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Description
            '
            Me.LabelHeader_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Description.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Description.LocationFloat = New DevExpress.Utils.PointFloat(45.87501!, 0!)
            Me.LabelHeader_Description.Name = "LabelHeader_Description"
            Me.LabelHeader_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Description.SizeF = New System.Drawing.SizeF(154.9998!, 27.99999!)
            Me.LabelHeader_Description.StylePriority.UseBorders = False
            Me.LabelHeader_Description.StylePriority.UseFont = False
            Me.LabelHeader_Description.StylePriority.UseForeColor = False
            Me.LabelHeader_Description.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Description.Text = "Description"
            Me.LabelHeader_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.PurchaseOrderDetail)
            '
            'GroupFooter
            '
            Me.GroupFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineFooter_Separator, Me.LabelFooter_PurchaseOrderTotal, Me.LabelFooter_Total})
            Me.GroupFooter.HeightF = 38.5!
            Me.GroupFooter.Name = "GroupFooter"
            '
            'PurchaseOrderDetailsSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader, Me.GroupFooter})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 0, 6)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "18.1"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents Label_LineNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_ItemNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents LabelHeader_Total As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Quantity As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_LineTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Quantity As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineFooter_Separator As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents Line_ItemSeparator As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelFooter_Total As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelFooter_PurchaseOrderTotal As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents Label_JobComp As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_ClientProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_JobComp As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_ClientProduct As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DetailDescriptionAndInstructions As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_BigDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents SubBand1 As DevExpress.XtraReports.UI.SubBand
    End Class

End Namespace