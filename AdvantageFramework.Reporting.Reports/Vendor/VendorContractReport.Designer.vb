Namespace Vendor

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class VendorContractReport
        Inherits DevExpress.XtraReports.UI.XtraReport

        'XtraReport overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGeneral_Comments = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGeneral_ContractEndDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGeneral_ContractStartDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGeneral_VendorCodeName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGeneral_ContractCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGeneral_ContractName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGeneral_Vendor = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelSectionGeneral = New DevExpress.XtraReports.UI.XRLabel()
            Me.CheckBoxMisc_HasDocuments = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelHeader_SortedBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_DateAndUserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.DetailReportContractContacts = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailContractContacts = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel132 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelInternalContacts_EmployeeName = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrCheckBox3 = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrLabel42 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel41 = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderContractContacts = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.LabelSectionInternalContacts = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceContract = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupFooterContractContacts = New DevExpress.XtraReports.UI.GroupFooterBand()
            CType(Me.BindingSourceContract, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel7, Me.LabelGeneral_Comments, Me.LabelGeneral_ContractEndDate, Me.LabelGeneral_ContractStartDate, Me.XrLabel4, Me.XrLabel2, Me.LabelGeneral_VendorCodeName, Me.LabelGeneral_ContractCode, Me.LabelGeneral_ContractName, Me.LabelGeneral_Vendor, Me.XrLabel5, Me.XrLabel6, Me.LabelSectionGeneral, Me.CheckBoxMisc_HasDocuments})
            Me.Detail.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Detail.HeightF = 145.1666!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel7
            '
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Comments")})
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 102.8333!)
            Me.XrLabel7.Multiline = True
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(613.6662!, 19.0!)
            Me.XrLabel7.StylePriority.UseFont = False
            Me.XrLabel7.StylePriority.UseTextAlignment = False
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGeneral_Comments
            '
            Me.LabelGeneral_Comments.BackColor = System.Drawing.Color.Transparent
            Me.LabelGeneral_Comments.BorderColor = System.Drawing.Color.Black
            Me.LabelGeneral_Comments.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGeneral_Comments.BorderWidth = 1.0!
            Me.LabelGeneral_Comments.CanGrow = False
            Me.LabelGeneral_Comments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGeneral_Comments.ForeColor = System.Drawing.Color.Black
            Me.LabelGeneral_Comments.LocationFloat = New DevExpress.Utils.PointFloat(0!, 102.8333!)
            Me.LabelGeneral_Comments.Name = "LabelGeneral_Comments"
            Me.LabelGeneral_Comments.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGeneral_Comments.SizeF = New System.Drawing.SizeF(124.7917!, 19.0!)
            Me.LabelGeneral_Comments.StylePriority.UseFont = False
            Me.LabelGeneral_Comments.StylePriority.UseTextAlignment = False
            Me.LabelGeneral_Comments.Text = "Comments:"
            Me.LabelGeneral_Comments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGeneral_ContractEndDate
            '
            Me.LabelGeneral_ContractEndDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EndDate", "{0:d}")})
            Me.LabelGeneral_ContractEndDate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelGeneral_ContractEndDate.LocationFloat = New DevExpress.Utils.PointFloat(316.4583!, 83.83328!)
            Me.LabelGeneral_ContractEndDate.Name = "LabelGeneral_ContractEndDate"
            Me.LabelGeneral_ContractEndDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGeneral_ContractEndDate.SizeF = New System.Drawing.SizeF(79.41667!, 19.0!)
            Me.LabelGeneral_ContractEndDate.StylePriority.UseFont = False
            Me.LabelGeneral_ContractEndDate.StylePriority.UseTextAlignment = False
            Me.LabelGeneral_ContractEndDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGeneral_ContractStartDate
            '
            Me.LabelGeneral_ContractStartDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StartDate", "{0:d}")})
            Me.LabelGeneral_ContractStartDate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelGeneral_ContractStartDate.LocationFloat = New DevExpress.Utils.PointFloat(124.7917!, 83.83328!)
            Me.LabelGeneral_ContractStartDate.Name = "LabelGeneral_ContractStartDate"
            Me.LabelGeneral_ContractStartDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGeneral_ContractStartDate.SizeF = New System.Drawing.SizeF(79.41667!, 19.0!)
            Me.LabelGeneral_ContractStartDate.StylePriority.UseFont = False
            Me.LabelGeneral_ContractStartDate.StylePriority.UseTextAlignment = False
            Me.LabelGeneral_ContractStartDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 45.83333!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(286.7082!, 18.99996!)
            Me.XrLabel4.StylePriority.UseFont = False
            Me.XrLabel4.StylePriority.UseTextAlignment = False
            Me.XrLabel4.Text = "XrLabel4"
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Code")})
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 26.83334!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(99.99999!, 19.0!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            Me.XrLabel2.Text = "XrLabel2"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGeneral_VendorCodeName
            '
            Me.LabelGeneral_VendorCodeName.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelGeneral_VendorCodeName.LocationFloat = New DevExpress.Utils.PointFloat(124.7917!, 64.83329!)
            Me.LabelGeneral_VendorCodeName.Name = "LabelGeneral_VendorCodeName"
            Me.LabelGeneral_VendorCodeName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGeneral_VendorCodeName.SizeF = New System.Drawing.SizeF(286.7083!, 19.0!)
            Me.LabelGeneral_VendorCodeName.StylePriority.UseFont = False
            Me.LabelGeneral_VendorCodeName.StylePriority.UseTextAlignment = False
            Me.LabelGeneral_VendorCodeName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGeneral_ContractCode
            '
            Me.LabelGeneral_ContractCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelGeneral_ContractCode.BorderColor = System.Drawing.Color.Black
            Me.LabelGeneral_ContractCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGeneral_ContractCode.BorderWidth = 1.0!
            Me.LabelGeneral_ContractCode.CanGrow = False
            Me.LabelGeneral_ContractCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGeneral_ContractCode.ForeColor = System.Drawing.Color.Black
            Me.LabelGeneral_ContractCode.LocationFloat = New DevExpress.Utils.PointFloat(0!, 26.83331!)
            Me.LabelGeneral_ContractCode.Name = "LabelGeneral_ContractCode"
            Me.LabelGeneral_ContractCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGeneral_ContractCode.SizeF = New System.Drawing.SizeF(124.7917!, 19.0!)
            Me.LabelGeneral_ContractCode.StylePriority.UseFont = False
            Me.LabelGeneral_ContractCode.StylePriority.UseTextAlignment = False
            Me.LabelGeneral_ContractCode.Text = "Contract Code:"
            Me.LabelGeneral_ContractCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGeneral_ContractName
            '
            Me.LabelGeneral_ContractName.BackColor = System.Drawing.Color.Transparent
            Me.LabelGeneral_ContractName.BorderColor = System.Drawing.Color.Black
            Me.LabelGeneral_ContractName.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGeneral_ContractName.BorderWidth = 1.0!
            Me.LabelGeneral_ContractName.CanGrow = False
            Me.LabelGeneral_ContractName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGeneral_ContractName.ForeColor = System.Drawing.Color.Black
            Me.LabelGeneral_ContractName.LocationFloat = New DevExpress.Utils.PointFloat(0!, 45.8333!)
            Me.LabelGeneral_ContractName.Name = "LabelGeneral_ContractName"
            Me.LabelGeneral_ContractName.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGeneral_ContractName.SizeF = New System.Drawing.SizeF(124.7917!, 19.0!)
            Me.LabelGeneral_ContractName.StylePriority.UseFont = False
            Me.LabelGeneral_ContractName.StylePriority.UseTextAlignment = False
            Me.LabelGeneral_ContractName.Text = "Contract Name:"
            Me.LabelGeneral_ContractName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGeneral_Vendor
            '
            Me.LabelGeneral_Vendor.BackColor = System.Drawing.Color.Transparent
            Me.LabelGeneral_Vendor.BorderColor = System.Drawing.Color.Black
            Me.LabelGeneral_Vendor.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGeneral_Vendor.BorderWidth = 1.0!
            Me.LabelGeneral_Vendor.CanGrow = False
            Me.LabelGeneral_Vendor.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGeneral_Vendor.ForeColor = System.Drawing.Color.Black
            Me.LabelGeneral_Vendor.LocationFloat = New DevExpress.Utils.PointFloat(0!, 64.83329!)
            Me.LabelGeneral_Vendor.Name = "LabelGeneral_Vendor"
            Me.LabelGeneral_Vendor.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGeneral_Vendor.SizeF = New System.Drawing.SizeF(124.7917!, 19.0!)
            Me.LabelGeneral_Vendor.StylePriority.UseFont = False
            Me.LabelGeneral_Vendor.StylePriority.UseTextAlignment = False
            Me.LabelGeneral_Vendor.Text = "Vendor Code/Name:"
            Me.LabelGeneral_Vendor.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1.0!
            Me.XrLabel5.CanGrow = False
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.ForeColor = System.Drawing.Color.Black
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0!, 83.83328!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(124.7917!, 19.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.StylePriority.UseTextAlignment = False
            Me.XrLabel5.Text = "Start Date:"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel6
            '
            Me.XrLabel6.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel6.BorderColor = System.Drawing.Color.Black
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel6.BorderWidth = 1.0!
            Me.XrLabel6.CanGrow = False
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel6.ForeColor = System.Drawing.Color.Black
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(252.0834!, 83.83322!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(64.37498!, 19.0!)
            Me.XrLabel6.StylePriority.UseFont = False
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            Me.XrLabel6.Text = "End Date:"
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelSectionGeneral
            '
            Me.LabelSectionGeneral.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.LabelSectionGeneral.BorderWidth = 1.0!
            Me.LabelSectionGeneral.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSectionGeneral.ForeColor = System.Drawing.Color.Black
            Me.LabelSectionGeneral.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelSectionGeneral.Name = "LabelSectionGeneral"
            Me.LabelSectionGeneral.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelSectionGeneral.SizeF = New System.Drawing.SizeF(749.0!, 26.83331!)
            Me.LabelSectionGeneral.StylePriority.UseBorders = False
            Me.LabelSectionGeneral.StylePriority.UseBorderWidth = False
            Me.LabelSectionGeneral.StylePriority.UseFont = False
            Me.LabelSectionGeneral.StylePriority.UseForeColor = False
            Me.LabelSectionGeneral.StylePriority.UseTextAlignment = False
            Me.LabelSectionGeneral.Text = "General"
            Me.LabelSectionGeneral.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'CheckBoxMisc_HasDocuments
            '
            Me.CheckBoxMisc_HasDocuments.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.CheckBoxMisc_HasDocuments.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 123.1666!)
            Me.CheckBoxMisc_HasDocuments.Name = "CheckBoxMisc_HasDocuments"
            Me.CheckBoxMisc_HasDocuments.SizeF = New System.Drawing.SizeF(118.7501!, 19.0!)
            Me.CheckBoxMisc_HasDocuments.StylePriority.UseFont = False
            Me.CheckBoxMisc_HasDocuments.StylePriority.UseTextAlignment = False
            Me.CheckBoxMisc_HasDocuments.Text = "Has Documents"
            Me.CheckBoxMisc_HasDocuments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.BottomMargin.HeightF = 59.375!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelHeader_SortedBy, Me.Line1, Me.LabelPageHeader_Agency, Me.LineTopLine, Me.LabelPageHeader_Title})
            Me.PageHeader.HeightF = 82.7083!
            Me.PageHeader.Name = "PageHeader"
            '
            'LabelHeader_SortedBy
            '
            Me.LabelHeader_SortedBy.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_SortedBy.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_SortedBy.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_SortedBy.BorderWidth = 1.0!
            Me.LabelHeader_SortedBy.CanGrow = False
            Me.LabelHeader_SortedBy.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_SortedBy.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_SortedBy.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 46.0!)
            Me.LabelHeader_SortedBy.Name = "LabelHeader_SortedBy"
            Me.LabelHeader_SortedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_SortedBy.SizeF = New System.Drawing.SizeF(321.1667!, 19.0!)
            Me.LabelHeader_SortedBy.StylePriority.UseFont = False
            Me.LabelHeader_SortedBy.StylePriority.UseTextAlignment = False
            Me.LabelHeader_SortedBy.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'Line1
            '
            Me.Line1.BorderColor = System.Drawing.Color.Silver
            Me.Line1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Line1.BorderWidth = 4.0!
            Me.Line1.ForeColor = System.Drawing.Color.Silver
            Me.Line1.LineWidth = 4
            Me.Line1.LocationFloat = New DevExpress.Utils.PointFloat(0!, 71.54163!)
            Me.Line1.Name = "Line1"
            Me.Line1.SizeF = New System.Drawing.SizeF(749.0!, 4.0!)
            '
            'LabelPageHeader_Agency
            '
            Me.LabelPageHeader_Agency.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageHeader_Agency.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Agency.BorderWidth = 1.0!
            Me.LabelPageHeader_Agency.CanGrow = False
            Me.LabelPageHeader_Agency.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelPageHeader_Agency.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(402.0002!, 27.00001!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(336.9997!, 19.0!)
            Me.LabelPageHeader_Agency.StylePriority.UseFont = False
            Me.LabelPageHeader_Agency.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Agency.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.LineWidth = 4
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0!, 10.00001!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(749.0!, 4.000004!)
            '
            'LabelPageHeader_Title
            '
            Me.LabelPageHeader_Title.BackColor = System.Drawing.Color.White
            Me.LabelPageHeader_Title.BorderColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageHeader_Title.BorderWidth = 1.0!
            Me.LabelPageHeader_Title.CanGrow = False
            Me.LabelPageHeader_Title.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_Title.ForeColor = System.Drawing.Color.Black
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 20.00001!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(381.6666!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Vendor Report - 008 - Vendor Contracts"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_DateAndUserCode, Me.PageInfo_Pages})
            Me.PageFooter.HeightF = 27.0!
            Me.PageFooter.Name = "PageFooter"
            '
            'LabelPageFooter_DateAndUserCode
            '
            Me.LabelPageFooter_DateAndUserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_DateAndUserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_DateAndUserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_DateAndUserCode.CanGrow = False
            Me.LabelPageFooter_DateAndUserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_DateAndUserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.LocationFloat = New DevExpress.Utils.PointFloat(0!, 4.999987!)
            Me.LabelPageFooter_DateAndUserCode.Name = "LabelPageFooter_DateAndUserCode"
            Me.LabelPageFooter_DateAndUserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_DateAndUserCode.SizeF = New System.Drawing.SizeF(490.0!, 19.0!)
            Me.LabelPageFooter_DateAndUserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_DateAndUserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_DateAndUserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.PageInfo_Pages.Format = "Page {0} of {1}"
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(613.5417!, 5.0!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(135.4583!, 20.99997!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'DetailReportContractContacts
            '
            Me.DetailReportContractContacts.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailContractContacts, Me.GroupHeaderContractContacts, Me.GroupFooterContractContacts})
            Me.DetailReportContractContacts.DataMember = "VendorContractContacts"
            Me.DetailReportContractContacts.DataSource = Me.BindingSourceContract
            Me.DetailReportContractContacts.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.DetailReportContractContacts.Level = 0
            Me.DetailReportContractContacts.Name = "DetailReportContractContacts"
            '
            'DetailContractContacts
            '
            Me.DetailContractContacts.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel132, Me.LabelInternalContacts_EmployeeName, Me.XrCheckBox3, Me.XrLabel42, Me.XrLabel41})
            Me.DetailContractContacts.HeightF = 19.0!
            Me.DetailContractContacts.Name = "DetailContractContacts"
            '
            'XrLabel132
            '
            Me.XrLabel132.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel132.BorderColor = System.Drawing.Color.Black
            Me.XrLabel132.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel132.BorderWidth = 1.0!
            Me.XrLabel132.CanGrow = False
            Me.XrLabel132.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.XrLabel132.ForeColor = System.Drawing.Color.Black
            Me.XrLabel132.LocationFloat = New DevExpress.Utils.PointFloat(200.0!, 0!)
            Me.XrLabel132.Name = "XrLabel132"
            Me.XrLabel132.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel132.SizeF = New System.Drawing.SizeF(101.875!, 19.0!)
            Me.XrLabel132.StylePriority.UseFont = False
            Me.XrLabel132.Text = "Employee Name:"
            Me.XrLabel132.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelInternalContacts_EmployeeName
            '
            Me.LabelInternalContacts_EmployeeName.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelInternalContacts_EmployeeName.LocationFloat = New DevExpress.Utils.PointFloat(301.8751!, 0!)
            Me.LabelInternalContacts_EmployeeName.Name = "LabelInternalContacts_EmployeeName"
            Me.LabelInternalContacts_EmployeeName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelInternalContacts_EmployeeName.SizeF = New System.Drawing.SizeF(285.3335!, 19.0!)
            Me.LabelInternalContacts_EmployeeName.StylePriority.UseFont = False
            '
            'XrCheckBox3
            '
            Me.XrCheckBox3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckState", Nothing, "VendorContractContacts.IncludeInAlert")})
            Me.XrCheckBox3.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrCheckBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far
            Me.XrCheckBox3.LocationFloat = New DevExpress.Utils.PointFloat(638.7916!, 0!)
            Me.XrCheckBox3.Name = "XrCheckBox3"
            Me.XrCheckBox3.SizeF = New System.Drawing.SizeF(110.2083!, 19.0!)
            Me.XrCheckBox3.StylePriority.UseFont = False
            Me.XrCheckBox3.Text = "Include In Alert:"
            '
            'XrLabel42
            '
            Me.XrLabel42.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorContractContacts.EmployeeCode")})
            Me.XrLabel42.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabel42.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 0!)
            Me.XrLabel42.Name = "XrLabel42"
            Me.XrLabel42.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel42.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.XrLabel42.StylePriority.UseFont = False
            '
            'XrLabel41
            '
            Me.XrLabel41.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel41.BorderColor = System.Drawing.Color.Black
            Me.XrLabel41.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel41.BorderWidth = 1.0!
            Me.XrLabel41.CanGrow = False
            Me.XrLabel41.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel41.ForeColor = System.Drawing.Color.Black
            Me.XrLabel41.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabel41.Name = "XrLabel41"
            Me.XrLabel41.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel41.SizeF = New System.Drawing.SizeF(100.0!, 19.0!)
            Me.XrLabel41.StylePriority.UseFont = False
            Me.XrLabel41.Text = "Employee Code:"
            Me.XrLabel41.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeaderContractContacts
            '
            Me.GroupHeaderContractContacts.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelSectionInternalContacts})
            Me.GroupHeaderContractContacts.HeightF = 26.83331!
            Me.GroupHeaderContractContacts.Name = "GroupHeaderContractContacts"
            '
            'LabelSectionInternalContacts
            '
            Me.LabelSectionInternalContacts.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.LabelSectionInternalContacts.BorderWidth = 1.0!
            Me.LabelSectionInternalContacts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSectionInternalContacts.ForeColor = System.Drawing.Color.Black
            Me.LabelSectionInternalContacts.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelSectionInternalContacts.Name = "LabelSectionInternalContacts"
            Me.LabelSectionInternalContacts.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelSectionInternalContacts.SizeF = New System.Drawing.SizeF(749.0!, 26.83331!)
            Me.LabelSectionInternalContacts.StylePriority.UseBorders = False
            Me.LabelSectionInternalContacts.StylePriority.UseBorderWidth = False
            Me.LabelSectionInternalContacts.StylePriority.UseFont = False
            Me.LabelSectionInternalContacts.StylePriority.UseForeColor = False
            Me.LabelSectionInternalContacts.StylePriority.UseTextAlignment = False
            Me.LabelSectionInternalContacts.Text = "Internal Contacts"
            Me.LabelSectionInternalContacts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'BindingSourceContract
            '
            Me.BindingSourceContract.DataSource = GetType(AdvantageFramework.Database.Entities.VendorContract)
            '
            'GroupFooterContractContacts
            '
            Me.GroupFooterContractContacts.HeightF = 9.375!
            Me.GroupFooterContractContacts.Name = "GroupFooterContractContacts"
            '
            'VendorContractReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter, Me.DetailReportContractContacts})
            Me.DataSource = Me.BindingSourceContract
            Me.Margins = New System.Drawing.Printing.Margins(50, 51, 39, 59)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSourceContract, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Line1 As DevExpress.XtraReports.UI.XRLine
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Private WithEvents LabelHeader_SortedBy As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_DateAndUserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents LabelGeneral_VendorCodeName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGeneral_ContractCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGeneral_ContractName As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGeneral_Vendor As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelSectionGeneral As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSourceContract As System.Windows.Forms.BindingSource
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGeneral_ContractEndDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGeneral_ContractStartDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportContractContacts As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailContractContacts As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents XrCheckBox3 As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents XrLabel42 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel41 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderContractContacts As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents LabelSectionInternalContacts As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel132 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelInternalContacts_EmployeeName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CheckBoxMisc_HasDocuments As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGeneral_Comments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterContractContacts As DevExpress.XtraReports.UI.GroupFooterBand
    End Class

End Namespace
