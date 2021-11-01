Namespace Maintenance

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class AccountExecutiveUpdateReport
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
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary3 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_CurrentAE = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_NewAE = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_NewAEDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_CurrentAEDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderCDP = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_ProductData = New DevExpress.XtraReports.UI.XRLabel()
            Me.Text31 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelCDP_ClientData = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelCDP_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label158 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterCDP = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1})
            Me.Detail.HeightF = 19.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel1
            '
            Me.XrLabel1.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel1.BorderColor = System.Drawing.Color.Black
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel1.BorderWidth = 1
            Me.XrLabel1.CanGrow = False
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "UpdateInformation")})
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(629.9995!, 19.0!)
            Me.XrLabel1.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0}"
            Me.XrLabel1.Summary = XrSummary1
            Me.XrLabel1.Text = "XrLabel1"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 38.54167!
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
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine1, Me.LabelPageHeader_CurrentAE, Me.LabelPageHeader_NewAE, Me.LabelPageHeader_NewAEDescription, Me.LabelPageHeader_CurrentAEDescription, Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_Title})
            Me.PageHeader.HeightF = 117.7083!
            Me.PageHeader.Name = "PageHeader"
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 55.0!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(649.0!, 4.000004!)
            '
            'LabelPageHeader_CurrentAE
            '
            Me.LabelPageHeader_CurrentAE.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_CurrentAE.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_CurrentAE.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_CurrentAE.BorderWidth = 1
            Me.LabelPageHeader_CurrentAE.CanGrow = False
            Me.LabelPageHeader_CurrentAE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_CurrentAE.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_CurrentAE.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 68.75!)
            Me.LabelPageHeader_CurrentAE.Name = "LabelPageHeader_CurrentAE"
            Me.LabelPageHeader_CurrentAE.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_CurrentAE.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.LabelPageHeader_CurrentAE.StylePriority.UseFont = False
            Me.LabelPageHeader_CurrentAE.Text = "Current A/E:"
            Me.LabelPageHeader_CurrentAE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_NewAE
            '
            Me.LabelPageHeader_NewAE.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_NewAE.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_NewAE.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_NewAE.BorderWidth = 1
            Me.LabelPageHeader_NewAE.CanGrow = False
            Me.LabelPageHeader_NewAE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_NewAE.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_NewAE.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 87.74999!)
            Me.LabelPageHeader_NewAE.Name = "LabelPageHeader_NewAE"
            Me.LabelPageHeader_NewAE.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_NewAE.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.LabelPageHeader_NewAE.StylePriority.UseFont = False
            Me.LabelPageHeader_NewAE.Text = "New A/E:"
            Me.LabelPageHeader_NewAE.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_NewAEDescription
            '
            Me.LabelPageHeader_NewAEDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_NewAEDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_NewAEDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_NewAEDescription.BorderWidth = 1
            Me.LabelPageHeader_NewAEDescription.CanGrow = False
            Me.LabelPageHeader_NewAEDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "NewAccountExecutive")})
            Me.LabelPageHeader_NewAEDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_NewAEDescription.LocationFloat = New DevExpress.Utils.PointFloat(140.0002!, 87.74999!)
            Me.LabelPageHeader_NewAEDescription.Name = "LabelPageHeader_NewAEDescription"
            Me.LabelPageHeader_NewAEDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_NewAEDescription.SizeF = New System.Drawing.SizeF(499.9997!, 19.0!)
            Me.LabelPageHeader_NewAEDescription.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0}"
            Me.LabelPageHeader_NewAEDescription.Summary = XrSummary2
            Me.LabelPageHeader_NewAEDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_CurrentAEDescription
            '
            Me.LabelPageHeader_CurrentAEDescription.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_CurrentAEDescription.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_CurrentAEDescription.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_CurrentAEDescription.BorderWidth = 1
            Me.LabelPageHeader_CurrentAEDescription.CanGrow = False
            Me.LabelPageHeader_CurrentAEDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CurrentAccountExecutive")})
            Me.LabelPageHeader_CurrentAEDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_CurrentAEDescription.LocationFloat = New DevExpress.Utils.PointFloat(140.0002!, 68.75!)
            Me.LabelPageHeader_CurrentAEDescription.Name = "LabelPageHeader_CurrentAEDescription"
            Me.LabelPageHeader_CurrentAEDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_CurrentAEDescription.SizeF = New System.Drawing.SizeF(499.9997!, 19.0!)
            Me.LabelPageHeader_CurrentAEDescription.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0}"
            Me.LabelPageHeader_CurrentAEDescription.Summary = XrSummary3
            Me.LabelPageHeader_CurrentAEDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(331.1668!, 27.00001!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(308.833!, 19.0!)
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(649.0!, 4.000004!)
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 20.00001!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(321.1667!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Account Executive Update Report"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeaderCDP
            '
            Me.GroupHeaderCDP.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine2, Me.LabelPageHeader_ProductData, Me.Text31, Me.LabelCDP_ClientData, Me.LabelCDP_Client, Me.Label158, Me.LabelPageHeader_Product})
            Me.GroupHeaderCDP.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Client", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("Division", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("Product", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderCDP.HeightF = 77.0!
            Me.GroupHeaderCDP.KeepTogether = True
            Me.GroupHeaderCDP.Name = "GroupHeaderCDP"
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Silver
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 4
            Me.XrLine2.ForeColor = System.Drawing.Color.Silver
            Me.XrLine2.LineWidth = 4
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 73.0!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(649.0!, 4.000004!)
            '
            'LabelPageHeader_ProductData
            '
            Me.LabelPageHeader_ProductData.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_ProductData.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_ProductData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_ProductData.BorderWidth = 1
            Me.LabelPageHeader_ProductData.CanGrow = False
            Me.LabelPageHeader_ProductData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Product")})
            Me.LabelPageHeader_ProductData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_ProductData.LocationFloat = New DevExpress.Utils.PointFloat(140.0002!, 47.99998!)
            Me.LabelPageHeader_ProductData.Name = "LabelPageHeader_ProductData"
            Me.LabelPageHeader_ProductData.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_ProductData.SizeF = New System.Drawing.SizeF(499.9996!, 19.0!)
            Me.LabelPageHeader_ProductData.StylePriority.UseFont = False
            XrSummary4.FormatString = "{0}"
            Me.LabelPageHeader_ProductData.Summary = XrSummary4
            Me.LabelPageHeader_ProductData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Text31
            '
            Me.Text31.BackColor = System.Drawing.Color.Transparent
            Me.Text31.BorderColor = System.Drawing.Color.Black
            Me.Text31.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Text31.BorderWidth = 1
            Me.Text31.CanGrow = False
            Me.Text31.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Division")})
            Me.Text31.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Text31.LocationFloat = New DevExpress.Utils.PointFloat(140.0002!, 29.0!)
            Me.Text31.Name = "Text31"
            Me.Text31.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Text31.SizeF = New System.Drawing.SizeF(499.9995!, 19.0!)
            Me.Text31.StylePriority.UseFont = False
            XrSummary5.FormatString = "{0}"
            Me.Text31.Summary = XrSummary5
            Me.Text31.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelCDP_ClientData
            '
            Me.LabelCDP_ClientData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Client")})
            Me.LabelCDP_ClientData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCDP_ClientData.LocationFloat = New DevExpress.Utils.PointFloat(140.0002!, 10.00001!)
            Me.LabelCDP_ClientData.Name = "LabelCDP_ClientData"
            Me.LabelCDP_ClientData.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelCDP_ClientData.SizeF = New System.Drawing.SizeF(499.9995!, 19.00001!)
            Me.LabelCDP_ClientData.StylePriority.UseFont = False
            '
            'LabelCDP_Client
            '
            Me.LabelCDP_Client.BackColor = System.Drawing.Color.Transparent
            Me.LabelCDP_Client.BorderColor = System.Drawing.Color.Black
            Me.LabelCDP_Client.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelCDP_Client.BorderWidth = 1
            Me.LabelCDP_Client.CanGrow = False
            Me.LabelCDP_Client.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelCDP_Client.ForeColor = System.Drawing.Color.Black
            Me.LabelCDP_Client.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 10.00001!)
            Me.LabelCDP_Client.Name = "LabelCDP_Client"
            Me.LabelCDP_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelCDP_Client.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.LabelCDP_Client.StylePriority.UseFont = False
            Me.LabelCDP_Client.Text = "Client:"
            Me.LabelCDP_Client.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label158
            '
            Me.Label158.BackColor = System.Drawing.Color.Transparent
            Me.Label158.BorderColor = System.Drawing.Color.Black
            Me.Label158.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label158.BorderWidth = 1
            Me.Label158.CanGrow = False
            Me.Label158.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label158.ForeColor = System.Drawing.Color.Black
            Me.Label158.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 29.0!)
            Me.Label158.Name = "Label158"
            Me.Label158.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label158.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.Label158.StylePriority.UseFont = False
            Me.Label158.Text = "Division:"
            Me.Label158.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelPageHeader_Product
            '
            Me.LabelPageHeader_Product.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Product.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Product.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Product.BorderWidth = 1
            Me.LabelPageHeader_Product.CanGrow = False
            Me.LabelPageHeader_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Product.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Product.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 47.99998!)
            Me.LabelPageHeader_Product.Name = "LabelPageHeader_Product"
            Me.LabelPageHeader_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Product.SizeF = New System.Drawing.SizeF(130.0!, 19.0!)
            Me.LabelPageHeader_Product.StylePriority.UseFont = False
            Me.LabelPageHeader_Product.Text = "Product:"
            Me.LabelPageHeader_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupFooterCDP
            '
            Me.GroupFooterCDP.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine3})
            Me.GroupFooterCDP.HeightF = 5.0!
            Me.GroupFooterCDP.Name = "GroupFooterCDP"
            '
            'XrLine3
            '
            Me.XrLine3.BorderColor = System.Drawing.Color.Silver
            Me.XrLine3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine3.BorderWidth = 4
            Me.XrLine3.ForeColor = System.Drawing.Color.Silver
            Me.XrLine3.LineWidth = 4
            Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLine3.Name = "XrLine3"
            Me.XrLine3.SizeF = New System.Drawing.SizeF(649.0!, 4.000004!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.AccountExecutiveUpdate)
            '
            'AccountExecutiveUpdateReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeaderCDP, Me.GroupFooterCDP})
            Me.DataSource = Me.BindingSource
            Me.Margins = New System.Drawing.Printing.Margins(100, 100, 39, 100)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_CurrentAE As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_NewAE As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_NewAEDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_CurrentAEDescription As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderCDP As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterCDP As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelPageHeader_ProductData As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Text31 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelCDP_ClientData As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelCDP_Client As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label158 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Product As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
    End Class

End Namespace
