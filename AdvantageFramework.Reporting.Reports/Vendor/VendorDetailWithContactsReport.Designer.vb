Namespace Vendor

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class VendorDetailWithContactsReport
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
            Me.Label_DefaultContact = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DefaultContact = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubReportVendorContacts = New DevExpress.XtraReports.UI.XRSubreport()
            Me.LabelDetail_Contacts = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubreportVendorDetails = New DevExpress.XtraReports.UI.XRSubreport()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelHeader_SortedBy = New DevExpress.XtraReports.UI.XRLabel()
            Me.Line1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.LabelPageFooter_DateAndUserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubreportVendorServiceTaxDetails = New DevExpress.XtraReports.UI.XRSubreport()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.SubreportVendorServiceTaxDetails, Me.Label_DefaultContact, Me.LabelDetail_DefaultContact, Me.SubReportVendorContacts, Me.LabelDetail_Contacts, Me.SubreportVendorDetails})
            Me.Detail.HeightF = 118.6667!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_DefaultContact
            '
            Me.Label_DefaultContact.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_DefaultContact.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 74.83331!)
            Me.Label_DefaultContact.Name = "Label_DefaultContact"
            Me.Label_DefaultContact.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_DefaultContact.SizeF = New System.Drawing.SizeF(275.2083!, 18.0!)
            Me.Label_DefaultContact.StylePriority.UseFont = False
            '
            'LabelDetail_DefaultContact
            '
            Me.LabelDetail_DefaultContact.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DefaultContact.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DefaultContact.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DefaultContact.BorderWidth = 1.0!
            Me.LabelDetail_DefaultContact.CanGrow = False
            Me.LabelDetail_DefaultContact.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_DefaultContact.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DefaultContact.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 74.83331!)
            Me.LabelDetail_DefaultContact.Name = "LabelDetail_DefaultContact"
            Me.LabelDetail_DefaultContact.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DefaultContact.SizeF = New System.Drawing.SizeF(105.0!, 19.0!)
            Me.LabelDetail_DefaultContact.StylePriority.UseFont = False
            Me.LabelDetail_DefaultContact.Text = "Default Contact:"
            Me.LabelDetail_DefaultContact.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SubReportVendorContacts
            '
            Me.SubReportVendorContacts.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 95.66667!)
            Me.SubReportVendorContacts.Name = "SubReportVendorContacts"
            Me.SubReportVendorContacts.ReportSource = New AdvantageFramework.Reporting.Reports.Vendor.VendorContactsSubReport()
            Me.SubReportVendorContacts.SizeF = New System.Drawing.SizeF(749.0!, 23.0!)
            '
            'LabelDetail_Contacts
            '
            Me.LabelDetail_Contacts.Borders = CType((DevExpress.XtraPrinting.BorderSide.Top Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.LabelDetail_Contacts.BorderWidth = 1.0!
            Me.LabelDetail_Contacts.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Contacts.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Contacts.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 48.0!)
            Me.LabelDetail_Contacts.Name = "LabelDetail_Contacts"
            Me.LabelDetail_Contacts.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Contacts.SizeF = New System.Drawing.SizeF(749.0!, 26.83331!)
            Me.LabelDetail_Contacts.StylePriority.UseBorders = False
            Me.LabelDetail_Contacts.StylePriority.UseBorderWidth = False
            Me.LabelDetail_Contacts.StylePriority.UseFont = False
            Me.LabelDetail_Contacts.StylePriority.UseForeColor = False
            Me.LabelDetail_Contacts.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Contacts.Text = "Contacts"
            Me.LabelDetail_Contacts.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'SubreportVendorDetails
            '
            Me.SubreportVendorDetails.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.SubreportVendorDetails.Name = "SubreportVendorDetails"
            Me.SubreportVendorDetails.ReportSource = New AdvantageFramework.Reporting.Reports.Vendor.VendorDetailsSubReport()
            Me.SubreportVendorDetails.SizeF = New System.Drawing.SizeF(749.0!, 23.0!)
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
            Me.PageHeader.HeightF = 79.5833!
            Me.PageHeader.Name = "PageHeader"
            '
            'LabelHeader_SortedBy
            '
            Me.LabelHeader_SortedBy.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelHeader_SortedBy.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 46.0!)
            Me.LabelHeader_SortedBy.Name = "LabelHeader_SortedBy"
            Me.LabelHeader_SortedBy.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_SortedBy.SizeF = New System.Drawing.SizeF(439.9167!, 18.0!)
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
            Me.Line1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 69.54163!)
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(449.9168!, 27.00001!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(289.0832!, 19.0!)
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
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
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
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(439.9167!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Vendor Report - 002 - Detail - Vendor Contacts"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.Vendor)
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.PageInfo_Pages, Me.LabelPageFooter_DateAndUserCode})
            Me.PageFooter.HeightF = 27.0!
            Me.PageFooter.Name = "PageFooter"
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
            'LabelPageFooter_DateAndUserCode
            '
            Me.LabelPageFooter_DateAndUserCode.BackColor = System.Drawing.Color.Transparent
            Me.LabelPageFooter_DateAndUserCode.BorderColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelPageFooter_DateAndUserCode.BorderWidth = 1.0!
            Me.LabelPageFooter_DateAndUserCode.CanGrow = False
            Me.LabelPageFooter_DateAndUserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_DateAndUserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 5.0!)
            Me.LabelPageFooter_DateAndUserCode.Name = "LabelPageFooter_DateAndUserCode"
            Me.LabelPageFooter_DateAndUserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_DateAndUserCode.SizeF = New System.Drawing.SizeF(490.0!, 19.0!)
            Me.LabelPageFooter_DateAndUserCode.StylePriority.UseFont = False
            Me.LabelPageFooter_DateAndUserCode.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_DateAndUserCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'SubreportVendorServiceTaxDetails
            '
            Me.SubreportVendorServiceTaxDetails.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 24.0!)
            Me.SubreportVendorServiceTaxDetails.Name = "SubreportVendorServiceTaxDetails"
            Me.SubreportVendorServiceTaxDetails.ReportSource = New AdvantageFramework.Reporting.Reports.Vendor.VendorServiceTaxSubReport()
            Me.SubreportVendorServiceTaxDetails.SizeF = New System.Drawing.SizeF(749.0!, 23.0!)
            '
            'VendorDetailWithContactsReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.PageFooter})
            Me.DataSource = Me.BindingSource
            Me.Margins = New System.Drawing.Printing.Margins(50, 51, 39, 59)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
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
        Private WithEvents Line1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents SubreportVendorDetails As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Friend WithEvents SubReportVendorContacts As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents LabelDetail_Contacts As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_DefaultContact As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DefaultContact As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_SortedBy As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Private WithEvents LabelPageFooter_DateAndUserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SubreportVendorServiceTaxDetails As DevExpress.XtraReports.UI.XRSubreport
    End Class

End Namespace
