Namespace PurchaseOrder

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class PurchaseOrderStandardFormatReport
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
            Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary11 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.SubReport_PurchaseOrderDetails = New DevExpress.XtraReports.UI.XRSubreport()
            Me.LineDetailSection = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_Originator = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_OriginatorLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DueDateLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_To = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_IssueDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PONumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_IssueDateLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_PONumberLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ToLbl = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.LabelFooter_LocationInfo = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Location = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.Label_Attention = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Attention = New DevExpress.XtraReports.UI.XRLabel()
            Me.PictureBoxHeader_Logo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.Line_HeaderBottom = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line_HeaderTop = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.BindingSource = New System.Windows.Forms.BindingSource()
            Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_FooterComments = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ShippingInstructions = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_ShippingInstructions = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SubReport_PurchaseOrderDetails, Me.LineDetailSection})
            Me.Detail.HeightF = 37.74999!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SubReport_PurchaseOrderDetails
            '
            Me.SubReport_PurchaseOrderDetails.Id = 0
            Me.SubReport_PurchaseOrderDetails.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.SubReport_PurchaseOrderDetails.Name = "SubReport_PurchaseOrderDetails"
            Me.SubReport_PurchaseOrderDetails.ReportSource = New AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderDetailsSubReport()
            Me.SubReport_PurchaseOrderDetails.SizeF = New System.Drawing.SizeF(675.9998!, 23.0!)
            '
            'LineDetailSection
            '
            Me.LineDetailSection.BorderColor = System.Drawing.Color.Silver
            Me.LineDetailSection.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineDetailSection.BorderWidth = 4
            Me.LineDetailSection.ForeColor = System.Drawing.Color.Silver
            Me.LineDetailSection.LineWidth = 4
            Me.LineDetailSection.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 31.04162!)
            Me.LineDetailSection.Name = "LineDetailSection"
            Me.LineDetailSection.SizeF = New System.Drawing.SizeF(676.0!, 4.000004!)
            '
            'Label_Originator
            '
            Me.Label_Originator.BackColor = System.Drawing.Color.Transparent
            Me.Label_Originator.BorderColor = System.Drawing.Color.Black
            Me.Label_Originator.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Originator.BorderWidth = 1
            Me.Label_Originator.CanGrow = False
            Me.Label_Originator.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Originator.LocationFloat = New DevExpress.Utils.PointFloat(526.1668!, 279.5833!)
            Me.Label_Originator.Name = "Label_Originator"
            Me.Label_Originator.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Originator.SizeF = New System.Drawing.SizeF(149.8331!, 19.0!)
            Me.Label_Originator.StylePriority.UseFont = False
            XrSummary1.FormatString = "{0}"
            Me.Label_Originator.Summary = XrSummary1
            Me.Label_Originator.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DueDate
            '
            Me.Label_DueDate.BackColor = System.Drawing.Color.Transparent
            Me.Label_DueDate.BorderColor = System.Drawing.Color.Black
            Me.Label_DueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DueDate.BorderWidth = 1
            Me.Label_DueDate.CanGrow = False
            Me.Label_DueDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DueDate", "{0:M/d/yyyy}")})
            Me.Label_DueDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DueDate.LocationFloat = New DevExpress.Utils.PointFloat(526.1668!, 260.5833!)
            Me.Label_DueDate.Name = "Label_DueDate"
            Me.Label_DueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_DueDate.SizeF = New System.Drawing.SizeF(149.8331!, 19.0!)
            Me.Label_DueDate.StylePriority.UseFont = False
            XrSummary2.FormatString = "{0}"
            Me.Label_DueDate.Summary = XrSummary2
            Me.Label_DueDate.Text = "Label_DueDate"
            Me.Label_DueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_OriginatorLbl
            '
            Me.Label_OriginatorLbl.BackColor = System.Drawing.Color.Transparent
            Me.Label_OriginatorLbl.BorderColor = System.Drawing.Color.Black
            Me.Label_OriginatorLbl.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_OriginatorLbl.BorderWidth = 1
            Me.Label_OriginatorLbl.CanGrow = False
            Me.Label_OriginatorLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_OriginatorLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_OriginatorLbl.LocationFloat = New DevExpress.Utils.PointFloat(458.209!, 279.5833!)
            Me.Label_OriginatorLbl.Name = "Label_OriginatorLbl"
            Me.Label_OriginatorLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_OriginatorLbl.SizeF = New System.Drawing.SizeF(67.95819!, 19.0!)
            Me.Label_OriginatorLbl.StylePriority.UseFont = False
            Me.Label_OriginatorLbl.Text = "Originator:"
            Me.Label_OriginatorLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DueDateLbl
            '
            Me.Label_DueDateLbl.BackColor = System.Drawing.Color.Transparent
            Me.Label_DueDateLbl.BorderColor = System.Drawing.Color.Black
            Me.Label_DueDateLbl.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DueDateLbl.BorderWidth = 1
            Me.Label_DueDateLbl.CanGrow = False
            Me.Label_DueDateLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_DueDateLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_DueDateLbl.LocationFloat = New DevExpress.Utils.PointFloat(458.2087!, 260.5833!)
            Me.Label_DueDateLbl.Name = "Label_DueDateLbl"
            Me.Label_DueDateLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_DueDateLbl.SizeF = New System.Drawing.SizeF(67.95819!, 19.0!)
            Me.Label_DueDateLbl.StylePriority.UseFont = False
            Me.Label_DueDateLbl.Text = "Due Date:"
            Me.Label_DueDateLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_To
            '
            Me.Label_To.BackColor = System.Drawing.Color.Transparent
            Me.Label_To.BorderColor = System.Drawing.Color.Black
            Me.Label_To.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_To.BorderWidth = 1
            Me.Label_To.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_To.LocationFloat = New DevExpress.Utils.PointFloat(30.00005!, 222.5833!)
            Me.Label_To.Multiline = True
            Me.Label_To.Name = "Label_To"
            Me.Label_To.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_To.SizeF = New System.Drawing.SizeF(203.1245!, 75.99998!)
            Me.Label_To.StylePriority.UseFont = False
            XrSummary3.FormatString = "{0}"
            Me.Label_To.Summary = XrSummary3
            Me.Label_To.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_IssueDate
            '
            Me.Label_IssueDate.BackColor = System.Drawing.Color.Transparent
            Me.Label_IssueDate.BorderColor = System.Drawing.Color.Black
            Me.Label_IssueDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_IssueDate.BorderWidth = 1
            Me.Label_IssueDate.CanGrow = False
            Me.Label_IssueDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Date", "{0:M/d/yyyy}")})
            Me.Label_IssueDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_IssueDate.LocationFloat = New DevExpress.Utils.PointFloat(526.1668!, 241.5833!)
            Me.Label_IssueDate.Name = "Label_IssueDate"
            Me.Label_IssueDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_IssueDate.SizeF = New System.Drawing.SizeF(149.8331!, 19.0!)
            Me.Label_IssueDate.StylePriority.UseFont = False
            XrSummary4.FormatString = "{0}"
            Me.Label_IssueDate.Summary = XrSummary4
            Me.Label_IssueDate.Text = "Label_IssueDate"
            Me.Label_IssueDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_PONumber
            '
            Me.Label_PONumber.BackColor = System.Drawing.Color.Transparent
            Me.Label_PONumber.BorderColor = System.Drawing.Color.Black
            Me.Label_PONumber.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_PONumber.BorderWidth = 1
            Me.Label_PONumber.CanGrow = False
            Me.Label_PONumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PONumber.LocationFloat = New DevExpress.Utils.PointFloat(526.1668!, 222.5833!)
            Me.Label_PONumber.Name = "Label_PONumber"
            Me.Label_PONumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_PONumber.SizeF = New System.Drawing.SizeF(149.8331!, 19.0!)
            Me.Label_PONumber.StylePriority.UseFont = False
            XrSummary5.FormatString = "{0}"
            Me.Label_PONumber.Summary = XrSummary5
            Me.Label_PONumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_IssueDateLbl
            '
            Me.Label_IssueDateLbl.BackColor = System.Drawing.Color.Transparent
            Me.Label_IssueDateLbl.BorderColor = System.Drawing.Color.Black
            Me.Label_IssueDateLbl.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_IssueDateLbl.BorderWidth = 1
            Me.Label_IssueDateLbl.CanGrow = False
            Me.Label_IssueDateLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_IssueDateLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_IssueDateLbl.LocationFloat = New DevExpress.Utils.PointFloat(458.209!, 241.5833!)
            Me.Label_IssueDateLbl.Name = "Label_IssueDateLbl"
            Me.Label_IssueDateLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_IssueDateLbl.SizeF = New System.Drawing.SizeF(67.95819!, 19.0!)
            Me.Label_IssueDateLbl.StylePriority.UseFont = False
            Me.Label_IssueDateLbl.Text = "Issue Date:"
            Me.Label_IssueDateLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_PONumberLbl
            '
            Me.Label_PONumberLbl.BackColor = System.Drawing.Color.Transparent
            Me.Label_PONumberLbl.BorderColor = System.Drawing.Color.Black
            Me.Label_PONumberLbl.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_PONumberLbl.BorderWidth = 1
            Me.Label_PONumberLbl.CanGrow = False
            Me.Label_PONumberLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_PONumberLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_PONumberLbl.LocationFloat = New DevExpress.Utils.PointFloat(458.2087!, 222.5833!)
            Me.Label_PONumberLbl.Name = "Label_PONumberLbl"
            Me.Label_PONumberLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_PONumberLbl.SizeF = New System.Drawing.SizeF(67.95819!, 19.0!)
            Me.Label_PONumberLbl.StylePriority.UseFont = False
            Me.Label_PONumberLbl.Text = "PO #:"
            Me.Label_PONumberLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Description
            '
            Me.Label_Description.BackColor = System.Drawing.Color.Transparent
            Me.Label_Description.BorderColor = System.Drawing.Color.Black
            Me.Label_Description.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Description.BorderWidth = 1
            Me.Label_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Description.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 298.5833!)
            Me.Label_Description.Multiline = True
            Me.Label_Description.Name = "Label_Description"
            Me.Label_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Description.SizeF = New System.Drawing.SizeF(675.9997!, 19.0!)
            Me.Label_Description.StylePriority.UseFont = False
            XrSummary6.FormatString = "{0}"
            Me.Label_Description.Summary = XrSummary6
            Me.Label_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ToLbl
            '
            Me.Label_ToLbl.BackColor = System.Drawing.Color.Transparent
            Me.Label_ToLbl.BorderColor = System.Drawing.Color.Black
            Me.Label_ToLbl.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_ToLbl.BorderWidth = 1
            Me.Label_ToLbl.CanGrow = False
            Me.Label_ToLbl.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ToLbl.ForeColor = System.Drawing.Color.Black
            Me.Label_ToLbl.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 222.5833!)
            Me.Label_ToLbl.Name = "Label_ToLbl"
            Me.Label_ToLbl.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_ToLbl.SizeF = New System.Drawing.SizeF(29.99998!, 19.0!)
            Me.Label_ToLbl.StylePriority.UseFont = False
            Me.Label_ToLbl.Text = "To:"
            Me.Label_ToLbl.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 39.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelFooter_LocationInfo})
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelFooter_LocationInfo
            '
            Me.LabelFooter_LocationInfo.BackColor = System.Drawing.Color.Transparent
            Me.LabelFooter_LocationInfo.BorderColor = System.Drawing.Color.Black
            Me.LabelFooter_LocationInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelFooter_LocationInfo.BorderWidth = 1
            Me.LabelFooter_LocationInfo.CanGrow = False
            Me.LabelFooter_LocationInfo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelFooter_LocationInfo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 9.999974!)
            Me.LabelFooter_LocationInfo.Multiline = True
            Me.LabelFooter_LocationInfo.Name = "LabelFooter_LocationInfo"
            Me.LabelFooter_LocationInfo.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelFooter_LocationInfo.SizeF = New System.Drawing.SizeF(675.9998!, 19.0!)
            Me.LabelFooter_LocationInfo.StylePriority.UseFont = False
            XrSummary7.FormatString = "{0}"
            Me.LabelFooter_LocationInfo.Summary = XrSummary7
            Me.LabelFooter_LocationInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeader_Location
            '
            Me.LabelHeader_Location.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Location.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Location.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Location.BorderWidth = 1
            Me.LabelHeader_Location.CanGrow = False
            Me.LabelHeader_Location.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Location.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 140.0!)
            Me.LabelHeader_Location.Multiline = True
            Me.LabelHeader_Location.Name = "LabelHeader_Location"
            Me.LabelHeader_Location.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Location.SizeF = New System.Drawing.SizeF(675.9997!, 19.0!)
            Me.LabelHeader_Location.StylePriority.UseFont = False
            XrSummary8.FormatString = "{0}"
            Me.LabelHeader_Location.Summary = XrSummary8
            Me.LabelHeader_Location.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_Attention, Me.LabelHeader_Attention, Me.PictureBoxHeader_Logo, Me.Line_HeaderBottom, Me.LabelPageHeader_Agency, Me.Line_HeaderTop, Me.LabelPageHeader_Title, Me.Label_ToLbl, Me.Label_Description, Me.Label_PONumberLbl, Me.Label_IssueDateLbl, Me.Label_PONumber, Me.Label_IssueDate, Me.Label_To, Me.Label_DueDateLbl, Me.Label_OriginatorLbl, Me.Label_DueDate, Me.Label_Originator, Me.LabelHeader_Location})
            Me.PageHeader.HeightF = 321.25!
            Me.PageHeader.Name = "PageHeader"
            '
            'Label_Attention
            '
            Me.Label_Attention.BackColor = System.Drawing.Color.Transparent
            Me.Label_Attention.BorderColor = System.Drawing.Color.Black
            Me.Label_Attention.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Attention.BorderWidth = 1
            Me.Label_Attention.CanGrow = False
            Me.Label_Attention.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_Attention.LocationFloat = New DevExpress.Utils.PointFloat(288.8747!, 222.5833!)
            Me.Label_Attention.Name = "Label_Attention"
            Me.Label_Attention.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Attention.SizeF = New System.Drawing.SizeF(149.8331!, 19.0!)
            Me.Label_Attention.StylePriority.UseFont = False
            XrSummary9.FormatString = "{0}"
            Me.Label_Attention.Summary = XrSummary9
            Me.Label_Attention.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeader_Attention
            '
            Me.LabelHeader_Attention.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Attention.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Attention.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Attention.BorderWidth = 1
            Me.LabelHeader_Attention.CanGrow = False
            Me.LabelHeader_Attention.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Attention.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Attention.LocationFloat = New DevExpress.Utils.PointFloat(251.583!, 222.5833!)
            Me.LabelHeader_Attention.Name = "LabelHeader_Attention"
            Me.LabelHeader_Attention.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Attention.SizeF = New System.Drawing.SizeF(37.29167!, 19.0!)
            Me.LabelHeader_Attention.StylePriority.UseFont = False
            Me.LabelHeader_Attention.Text = "Attn:"
            Me.LabelHeader_Attention.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PictureBoxHeader_Logo
            '
            Me.PictureBoxHeader_Logo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.PictureBoxHeader_Logo.Name = "PictureBoxHeader_Logo"
            Me.PictureBoxHeader_Logo.SizeF = New System.Drawing.SizeF(676.0!, 136.0!)
            Me.PictureBoxHeader_Logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
            '
            'Line_HeaderBottom
            '
            Me.Line_HeaderBottom.BorderColor = System.Drawing.Color.Silver
            Me.Line_HeaderBottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line_HeaderBottom.BorderWidth = 4
            Me.Line_HeaderBottom.ForeColor = System.Drawing.Color.Silver
            Me.Line_HeaderBottom.LineWidth = 4
            Me.Line_HeaderBottom.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 210.5833!)
            Me.Line_HeaderBottom.Name = "Line_HeaderBottom"
            Me.Line_HeaderBottom.SizeF = New System.Drawing.SizeF(676.0!, 4.000004!)
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(331.1668!, 180.0!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(308.833!, 19.0!)
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Line_HeaderTop
            '
            Me.Line_HeaderTop.BorderColor = System.Drawing.Color.Silver
            Me.Line_HeaderTop.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line_HeaderTop.BorderWidth = 4
            Me.Line_HeaderTop.ForeColor = System.Drawing.Color.Silver
            Me.Line_HeaderTop.LineWidth = 4
            Me.Line_HeaderTop.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 163.0!)
            Me.Line_HeaderTop.Name = "Line_HeaderTop"
            Me.Line_HeaderTop.SizeF = New System.Drawing.SizeF(675.9999!, 4.00002!)
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
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 173.0!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(321.1667!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Purchase Order"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrControlStyle1
            '
            Me.XrControlStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrControlStyle1.Name = "XrControlStyle1"
            Me.XrControlStyle1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.PurchaseOrder)
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine3, Me.XrLine4, Me.XrLine2, Me.XrLine1, Me.Label_FooterComments, Me.Label_ShippingInstructions, Me.LabelHeader_ShippingInstructions, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.XrLabel1})
            Me.GroupFooter1.HeightF = 125.0!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'XrLine3
            '
            Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(85.20838!, 78.33334!)
            Me.XrLine3.Name = "XrLine3"
            Me.XrLine3.SizeF = New System.Drawing.SizeF(245.9584!, 7.375!)
            '
            'XrLine4
            '
            Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(429.3752!, 78.33334!)
            Me.XrLine4.Name = "XrLine4"
            Me.XrLine4.SizeF = New System.Drawing.SizeF(245.9584!, 7.375!)
            '
            'XrLine2
            '
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(429.3752!, 54.33337!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(245.9584!, 7.375!)
            '
            'XrLine1
            '
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(85.20838!, 54.33337!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(245.9584!, 7.375!)
            '
            'Label_FooterComments
            '
            Me.Label_FooterComments.BackColor = System.Drawing.Color.Transparent
            Me.Label_FooterComments.BorderColor = System.Drawing.Color.Black
            Me.Label_FooterComments.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_FooterComments.BorderWidth = 1
            Me.Label_FooterComments.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Footer")})
            Me.Label_FooterComments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_FooterComments.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 90.99998!)
            Me.Label_FooterComments.Multiline = True
            Me.Label_FooterComments.Name = "Label_FooterComments"
            Me.Label_FooterComments.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_FooterComments.SizeF = New System.Drawing.SizeF(675.9996!, 19.0!)
            Me.Label_FooterComments.StylePriority.UseFont = False
            XrSummary10.FormatString = "{0}"
            Me.Label_FooterComments.Summary = XrSummary10
            Me.Label_FooterComments.Text = "Label_FooterComments"
            Me.Label_FooterComments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_ShippingInstructions
            '
            Me.Label_ShippingInstructions.BackColor = System.Drawing.Color.Transparent
            Me.Label_ShippingInstructions.BorderColor = System.Drawing.Color.Black
            Me.Label_ShippingInstructions.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_ShippingInstructions.BorderWidth = 1
            Me.Label_ShippingInstructions.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DeliveryInstruction")})
            Me.Label_ShippingInstructions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label_ShippingInstructions.LocationFloat = New DevExpress.Utils.PointFloat(133.125!, 0.0!)
            Me.Label_ShippingInstructions.Multiline = True
            Me.Label_ShippingInstructions.Name = "Label_ShippingInstructions"
            Me.Label_ShippingInstructions.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_ShippingInstructions.SizeF = New System.Drawing.SizeF(542.8746!, 19.0!)
            Me.Label_ShippingInstructions.StylePriority.UseFont = False
            XrSummary11.FormatString = "{0}"
            Me.Label_ShippingInstructions.Summary = XrSummary11
            Me.Label_ShippingInstructions.Text = "Label_ShippingInstructions"
            Me.Label_ShippingInstructions.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeader_ShippingInstructions
            '
            Me.LabelHeader_ShippingInstructions.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_ShippingInstructions.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_ShippingInstructions.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_ShippingInstructions.BorderWidth = 1
            Me.LabelHeader_ShippingInstructions.CanGrow = False
            Me.LabelHeader_ShippingInstructions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_ShippingInstructions.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_ShippingInstructions.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelHeader_ShippingInstructions.Name = "LabelHeader_ShippingInstructions"
            Me.LabelHeader_ShippingInstructions.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_ShippingInstructions.SizeF = New System.Drawing.SizeF(133.125!, 19.0!)
            Me.LabelHeader_ShippingInstructions.StylePriority.UseFont = False
            Me.LabelHeader_ShippingInstructions.StylePriority.UseTextAlignment = False
            Me.LabelHeader_ShippingInstructions.Text = "Shipping Instructions:"
            Me.LabelHeader_ShippingInstructions.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel4
            '
            Me.XrLabel4.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel4.BorderColor = System.Drawing.Color.Black
            Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel4.BorderWidth = 1
            Me.XrLabel4.CanGrow = False
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.ForeColor = System.Drawing.Color.Black
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(387.9168!, 66.70833!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(41.45833!, 19.0!)
            Me.XrLabel4.StylePriority.UseFont = False
            Me.XrLabel4.StylePriority.UseTextAlignment = False
            Me.XrLabel4.Text = "Date:"
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel3.ForeColor = System.Drawing.Color.Black
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(43.75!, 66.70833!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(41.45833!, 19.0!)
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "Date:"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel2
            '
            Me.XrLabel2.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel2.BorderColor = System.Drawing.Color.Black
            Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel2.BorderWidth = 1
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.ForeColor = System.Drawing.Color.Black
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(344.1668!, 30.20833!)
            Me.XrLabel2.Multiline = True
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(85.20832!, 31.50001!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            Me.XrLabel2.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Accepted By:"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel1
            '
            Me.XrLabel1.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel1.BorderColor = System.Drawing.Color.Black
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel1.BorderWidth = 1
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel1.ForeColor = System.Drawing.Color.Black
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 30.20833!)
            Me.XrLabel1.Multiline = True
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(85.20832!, 31.50001!)
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            Me.XrLabel1.Text = "Agency" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Authorization:"
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'PurchaseOrderStandardFormatReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupFooter1})
            Me.DataSource = Me.BindingSource
            Me.Margins = New System.Drawing.Printing.Margins(86, 88, 39, 100)
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
            Me.Version = "12.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents Line_HeaderTop As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Line_HeaderBottom As DevExpress.XtraReports.UI.XRLine
        Private WithEvents Label_ToLbl As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents Label_IssueDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_PONumber As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_IssueDateLbl As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_PONumberLbl As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_To As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Private WithEvents LineDetailSection As DevExpress.XtraReports.UI.XRLine
        Private WithEvents Label_Originator As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_DueDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_OriginatorLbl As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_DueDateLbl As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Location As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PictureBoxHeader_Logo As DevExpress.XtraReports.UI.XRPictureBox
        Private WithEvents LabelFooter_LocationInfo As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SubReport_PurchaseOrderDetails As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Private WithEvents Label_Attention As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_Attention As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents Label_FooterComments As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_ShippingInstructions As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeader_ShippingInstructions As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
