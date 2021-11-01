Namespace Media

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class MediaATBReport
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
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelHeader_Canceled = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubReport_RevisionDetails = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Revision = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Revision = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Comments = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_SalesClass = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_ClientBudget = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Comments = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_SalesClass = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientBudget = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_EndingDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_DateOfRequest = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateOfRequest = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Campaign = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_EndingDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_BeginningDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_BeginningDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Campaign = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Number = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ATB = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_BillingComments = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DateToBill = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_ClientPO = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_BillingMethod = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelBillingInformation_Comments = New DevExpress.XtraReports.UI.XRLabel()
            Me.CheckBox_BillCommissionOnly = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.LabelBillingInformation_BillingDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelBillingInformation_ClientPO = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelBillingInformation_BillingMethod = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PictureBoxHeader_Logo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Agency = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_DateAndUserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.BindingSourceRevisionDetail = New System.Windows.Forms.BindingSource(Me.components)
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupHeader_Main = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabelLocationHeaderInfo = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSourceRevisionDetail, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelHeader_Canceled, Me.XrLabel16, Me.XrLabel17, Me.SubReport_RevisionDetails, Me.XrLabel10, Me.XrLabel6, Me.XrLabel7, Me.XrLabel5, Me.XrLabel1, Me.XrLabel4, Me.XrLabel3, Me.XrLabel2, Me.LabelDetail_Revision, Me.Label_Revision, Me.Label_Comments, Me.Label_SalesClass, Me.Label_ClientBudget, Me.Label_Description, Me.LabelDetail_Comments, Me.LabelDetail_SalesClass, Me.LabelDetail_ClientBudget, Me.LabelDetail_EndingDate, Me.Label_DateOfRequest, Me.LabelDetail_DateOfRequest, Me.Label_Campaign, Me.Label_EndingDate, Me.Label_BeginningDate, Me.Label_Product, Me.Label_Division, Me.LabelDetail_BeginningDate, Me.LabelDetail_Campaign, Me.LabelDetail_Product, Me.LabelDetail_Division, Me.Label_Client, Me.LabelDetail_Client, Me.Label_Number, Me.LabelDetail_ATB, Me.LabelDetail_BillingComments, Me.LabelDetail_DateToBill, Me.LabelDetail_ClientPO, Me.LabelDetail_BillingMethod, Me.LabelBillingInformation_Comments, Me.CheckBox_BillCommissionOnly, Me.LabelBillingInformation_BillingDate, Me.LabelBillingInformation_ClientPO, Me.LabelBillingInformation_BillingMethod})
            Me.Detail.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Detail.HeightF = 469.2083!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseBackColor = False
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeader_Canceled
            '
            Me.LabelHeader_Canceled.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeader_Canceled.BorderColor = System.Drawing.Color.Black
            Me.LabelHeader_Canceled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeader_Canceled.BorderWidth = 1
            Me.LabelHeader_Canceled.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Canceled.ForeColor = System.Drawing.Color.Red
            Me.LabelHeader_Canceled.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 25.29163!)
            Me.LabelHeader_Canceled.Name = "LabelHeader_Canceled"
            Me.LabelHeader_Canceled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeader_Canceled.SizeF = New System.Drawing.SizeF(738.416!, 7.541672!)
            Me.LabelHeader_Canceled.StylePriority.UseFont = False
            Me.LabelHeader_Canceled.StylePriority.UseForeColor = False
            Me.LabelHeader_Canceled.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0}"
            Me.LabelHeader_Canceled.Summary = XrSummary1
            Me.LabelHeader_Canceled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel16
            '
            Me.XrLabel16.BackColor = System.Drawing.Color.DarkGray
            Me.XrLabel16.BorderColor = System.Drawing.Color.Black
            Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel16.BorderWidth = 1
            Me.XrLabel16.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabel16.ForeColor = System.Drawing.Color.White
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(0.291748!, 417.4583!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(256.6238!, 20.0!)
            Me.XrLabel16.StylePriority.UseBackColor = False
            Me.XrLabel16.StylePriority.UseBorderColor = False
            Me.XrLabel16.StylePriority.UseBorders = False
            Me.XrLabel16.StylePriority.UseBorderWidth = False
            Me.XrLabel16.StylePriority.UseFont = False
            Me.XrLabel16.StylePriority.UseForeColor = False
            Me.XrLabel16.StylePriority.UseTextAlignment = False
            Me.XrLabel16.Text = "Details"
            Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabel17
            '
            Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel17.BorderWidth = 1
            Me.XrLabel17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel17.ForeColor = System.Drawing.Color.Black
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(256.9156!, 417.4583!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(492.0844!, 20.0!)
            Me.XrLabel17.StylePriority.UseBorders = False
            Me.XrLabel17.StylePriority.UseBorderWidth = False
            Me.XrLabel17.StylePriority.UseFont = False
            Me.XrLabel17.StylePriority.UseForeColor = False
            Me.XrLabel17.StylePriority.UseTextAlignment = False
            Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'SubReport_RevisionDetails
            '
            Me.SubReport_RevisionDetails.Id = 0
            Me.SubReport_RevisionDetails.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 440.75!)
            Me.SubReport_RevisionDetails.Name = "SubReport_RevisionDetails"
            Me.SubReport_RevisionDetails.ReportSource = New AdvantageFramework.Reporting.Reports.Media.MediaATBDetailsSubReport()
            Me.SubReport_RevisionDetails.SizeF = New System.Drawing.SizeF(750.0!, 23.0!)
            '
            'XrLabel10
            '
            Me.XrLabel10.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel10.BorderColor = System.Drawing.Color.Black
            Me.XrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel10.BorderWidth = 1
            Me.XrLabel10.CanGrow = False
            Me.XrLabel10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel10.ForeColor = System.Drawing.Color.Black
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(0.5836487!, 295.8333!)
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(134.9167!, 19.0!)
            Me.XrLabel10.StylePriority.UseFont = False
            Me.XrLabel10.StylePriority.UsePadding = False
            Me.XrLabel10.StylePriority.UseTextAlignment = False
            Me.XrLabel10.Text = "Bill Commission Only:"
            Me.XrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel6
            '
            Me.XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel6.BorderWidth = 1
            Me.XrLabel6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel6.ForeColor = System.Drawing.Color.Black
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(256.9156!, 343.8333!)
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(492.0844!, 20.0!)
            Me.XrLabel6.StylePriority.UseBorders = False
            Me.XrLabel6.StylePriority.UseBorderWidth = False
            Me.XrLabel6.StylePriority.UseFont = False
            Me.XrLabel6.StylePriority.UseForeColor = False
            Me.XrLabel6.StylePriority.UseTextAlignment = False
            Me.XrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'XrLabel7
            '
            Me.XrLabel7.BackColor = System.Drawing.Color.DarkGray
            Me.XrLabel7.BorderColor = System.Drawing.Color.Black
            Me.XrLabel7.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel7.BorderWidth = 1
            Me.XrLabel7.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabel7.ForeColor = System.Drawing.Color.White
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(0.2917767!, 343.8333!)
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(256.6238!, 20.0!)
            Me.XrLabel7.StylePriority.UseBackColor = False
            Me.XrLabel7.StylePriority.UseBorderColor = False
            Me.XrLabel7.StylePriority.UseBorders = False
            Me.XrLabel7.StylePriority.UseBorderWidth = False
            Me.XrLabel7.StylePriority.UseFont = False
            Me.XrLabel7.StylePriority.UseForeColor = False
            Me.XrLabel7.StylePriority.UseTextAlignment = False
            Me.XrLabel7.Text = "Comments"
            Me.XrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabel5
            '
            Me.XrLabel5.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel5.BorderColor = System.Drawing.Color.Black
            Me.XrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel5.BorderWidth = 1
            Me.XrLabel5.CanGrow = False
            Me.XrLabel5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel5.ForeColor = System.Drawing.Color.Black
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(0.2917925!, 51.8333!)
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
            Me.XrLabel5.StylePriority.UseFont = False
            Me.XrLabel5.StylePriority.UsePadding = False
            Me.XrLabel5.StylePriority.UseTextAlignment = False
            Me.XrLabel5.Text = "ATB Description:"
            Me.XrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'XrLabel1
            '
            Me.XrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel1.BorderWidth = 1
            Me.XrLabel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel1.ForeColor = System.Drawing.Color.Black
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(256.9156!, 0.0!)
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(492.0844!, 20.0!)
            Me.XrLabel1.StylePriority.UseBorders = False
            Me.XrLabel1.StylePriority.UseBorderWidth = False
            Me.XrLabel1.StylePriority.UseFont = False
            Me.XrLabel1.StylePriority.UseForeColor = False
            Me.XrLabel1.StylePriority.UseTextAlignment = False
            Me.XrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'XrLabel4
            '
            Me.XrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.XrLabel4.BorderWidth = 1
            Me.XrLabel4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel4.ForeColor = System.Drawing.Color.Black
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(256.9156!, 232.8333!)
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(492.0844!, 20.0!)
            Me.XrLabel4.StylePriority.UseBorders = False
            Me.XrLabel4.StylePriority.UseBorderWidth = False
            Me.XrLabel4.StylePriority.UseFont = False
            Me.XrLabel4.StylePriority.UseForeColor = False
            Me.XrLabel4.StylePriority.UseTextAlignment = False
            Me.XrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.DarkGray
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabel3.ForeColor = System.Drawing.Color.White
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(0.2918402!, 232.8333!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(256.6238!, 20.0!)
            Me.XrLabel3.StylePriority.UseBackColor = False
            Me.XrLabel3.StylePriority.UseBorderColor = False
            Me.XrLabel3.StylePriority.UseBorders = False
            Me.XrLabel3.StylePriority.UseBorderWidth = False
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.StylePriority.UseForeColor = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "Billing Information"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabel2
            '
            Me.XrLabel2.BackColor = System.Drawing.Color.DarkGray
            Me.XrLabel2.BorderColor = System.Drawing.Color.Black
            Me.XrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel2.BorderWidth = 1
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 10.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.XrLabel2.ForeColor = System.Drawing.Color.White
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0.2918402!, 0.0!)
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(256.6238!, 20.0!)
            Me.XrLabel2.StylePriority.UseBackColor = False
            Me.XrLabel2.StylePriority.UseBorderColor = False
            Me.XrLabel2.StylePriority.UseBorders = False
            Me.XrLabel2.StylePriority.UseBorderWidth = False
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.StylePriority.UseForeColor = False
            Me.XrLabel2.StylePriority.UseTextAlignment = False
            Me.XrLabel2.Text = "ATB Information"
            Me.XrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelDetail_Revision
            '
            Me.LabelDetail_Revision.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Revision.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Revision.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Revision.BorderWidth = 1
            Me.LabelDetail_Revision.CanGrow = False
            Me.LabelDetail_Revision.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Revision.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Revision.LocationFloat = New DevExpress.Utils.PointFloat(219.3337!, 32.83334!)
            Me.LabelDetail_Revision.Name = "LabelDetail_Revision"
            Me.LabelDetail_Revision.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
            Me.LabelDetail_Revision.SizeF = New System.Drawing.SizeF(36.24997!, 18.99999!)
            Me.LabelDetail_Revision.StylePriority.UseFont = False
            Me.LabelDetail_Revision.StylePriority.UsePadding = False
            Me.LabelDetail_Revision.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Revision.Text = "Rev:"
            Me.LabelDetail_Revision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_Revision
            '
            Me.Label_Revision.BackColor = System.Drawing.Color.Transparent
            Me.Label_Revision.BorderColor = System.Drawing.Color.Black
            Me.Label_Revision.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_Revision.BorderWidth = 1
            Me.Label_Revision.CanGrow = False
            Me.Label_Revision.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Revision.ForeColor = System.Drawing.Color.Black
            Me.Label_Revision.LocationFloat = New DevExpress.Utils.PointFloat(255.5837!, 32.83333!)
            Me.Label_Revision.Name = "Label_Revision"
            Me.Label_Revision.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Label_Revision.SizeF = New System.Drawing.SizeF(56.37469!, 18.99999!)
            Me.Label_Revision.StylePriority.UseFont = False
            Me.Label_Revision.Text = "Label_Revision"
            Me.Label_Revision.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Comments
            '
            Me.Label_Comments.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Comments")})
            Me.Label_Comments.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Comments.LocationFloat = New DevExpress.Utils.PointFloat(125.3754!, 368.8333!)
            Me.Label_Comments.Multiline = True
            Me.Label_Comments.Name = "Label_Comments"
            Me.Label_Comments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Comments.SizeF = New System.Drawing.SizeF(614.2084!, 18.99998!)
            Me.Label_Comments.StylePriority.UseFont = False
            Me.Label_Comments.Text = "Label_Comments"
            '
            'Label_SalesClass
            '
            Me.Label_SalesClass.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_SalesClass.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 203.8333!)
            Me.Label_SalesClass.Name = "Label_SalesClass"
            Me.Label_SalesClass.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_SalesClass.SizeF = New System.Drawing.SizeF(614.2082!, 18.99998!)
            Me.Label_SalesClass.StylePriority.UseFont = False
            '
            'Label_ClientBudget
            '
            Me.Label_ClientBudget.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientBudget", "{0:n2}")})
            Me.Label_ClientBudget.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_ClientBudget.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 184.8333!)
            Me.Label_ClientBudget.Name = "Label_ClientBudget"
            Me.Label_ClientBudget.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_ClientBudget.SizeF = New System.Drawing.SizeF(157.5416!, 18.99999!)
            Me.Label_ClientBudget.StylePriority.UseFont = False
            Me.Label_ClientBudget.Text = "Label_ClientBudget"
            '
            'Label_Description
            '
            Me.Label_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.Label_Description.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Description.LocationFloat = New DevExpress.Utils.PointFloat(125.0835!, 51.83332!)
            Me.Label_Description.Name = "Label_Description"
            Me.Label_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Description.SizeF = New System.Drawing.SizeF(613.9165!, 18.99999!)
            Me.Label_Description.StylePriority.UseFont = False
            Me.Label_Description.Text = "Label_Description"
            '
            'LabelDetail_Comments
            '
            Me.LabelDetail_Comments.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Comments.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Comments.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Comments.BorderWidth = 1
            Me.LabelDetail_Comments.CanGrow = False
            Me.LabelDetail_Comments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_Comments.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Comments.LocationFloat = New DevExpress.Utils.PointFloat(0.5836328!, 368.8333!)
            Me.LabelDetail_Comments.Name = "LabelDetail_Comments"
            Me.LabelDetail_Comments.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
            Me.LabelDetail_Comments.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
            Me.LabelDetail_Comments.StylePriority.UseFont = False
            Me.LabelDetail_Comments.StylePriority.UsePadding = False
            Me.LabelDetail_Comments.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Comments.Text = "ATB Comments:"
            Me.LabelDetail_Comments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_SalesClass
            '
            Me.LabelDetail_SalesClass.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_SalesClass.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_SalesClass.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_SalesClass.BorderWidth = 1
            Me.LabelDetail_SalesClass.CanGrow = False
            Me.LabelDetail_SalesClass.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_SalesClass.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_SalesClass.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 203.8333!)
            Me.LabelDetail_SalesClass.Name = "LabelDetail_SalesClass"
            Me.LabelDetail_SalesClass.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
            Me.LabelDetail_SalesClass.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
            Me.LabelDetail_SalesClass.StylePriority.UseFont = False
            Me.LabelDetail_SalesClass.StylePriority.UsePadding = False
            Me.LabelDetail_SalesClass.StylePriority.UseTextAlignment = False
            Me.LabelDetail_SalesClass.Text = "Sales Class:"
            Me.LabelDetail_SalesClass.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_ClientBudget
            '
            Me.LabelDetail_ClientBudget.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_ClientBudget.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_ClientBudget.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_ClientBudget.BorderWidth = 1
            Me.LabelDetail_ClientBudget.CanGrow = False
            Me.LabelDetail_ClientBudget.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_ClientBudget.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_ClientBudget.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 184.8333!)
            Me.LabelDetail_ClientBudget.Name = "LabelDetail_ClientBudget"
            Me.LabelDetail_ClientBudget.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
            Me.LabelDetail_ClientBudget.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
            Me.LabelDetail_ClientBudget.StylePriority.UseFont = False
            Me.LabelDetail_ClientBudget.StylePriority.UsePadding = False
            Me.LabelDetail_ClientBudget.StylePriority.UseTextAlignment = False
            Me.LabelDetail_ClientBudget.Text = "Client Budget:"
            Me.LabelDetail_ClientBudget.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelDetail_EndingDate
            '
            Me.LabelDetail_EndingDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_EndingDate.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_EndingDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_EndingDate.BorderWidth = 1
            Me.LabelDetail_EndingDate.CanGrow = False
            Me.LabelDetail_EndingDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelDetail_EndingDate.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_EndingDate.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 165.8333!)
            Me.LabelDetail_EndingDate.Name = "LabelDetail_EndingDate"
            Me.LabelDetail_EndingDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
            Me.LabelDetail_EndingDate.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
            Me.LabelDetail_EndingDate.StylePriority.UseFont = False
            Me.LabelDetail_EndingDate.StylePriority.UsePadding = False
            Me.LabelDetail_EndingDate.StylePriority.UseTextAlignment = False
            Me.LabelDetail_EndingDate.Text = "Ending Date:"
            Me.LabelDetail_EndingDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'Label_DateOfRequest
            '
            Me.Label_DateOfRequest.BackColor = System.Drawing.Color.Transparent
            Me.Label_DateOfRequest.BorderColor = System.Drawing.Color.Black
            Me.Label_DateOfRequest.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Label_DateOfRequest.BorderWidth = 1
            Me.Label_DateOfRequest.CanGrow = False
			Me.Label_DateOfRequest.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DateRequested", "{0:d}")})
			Me.Label_DateOfRequest.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.Label_DateOfRequest.ForeColor = System.Drawing.Color.Black
			Me.Label_DateOfRequest.LocationFloat = New DevExpress.Utils.PointFloat(626.3752!, 32.83334!)
			Me.Label_DateOfRequest.Name = "Label_DateOfRequest"
			Me.Label_DateOfRequest.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.Label_DateOfRequest.SizeF = New System.Drawing.SizeF(112.6247!, 18.99999!)
			Me.Label_DateOfRequest.StylePriority.UseFont = False
			Me.Label_DateOfRequest.Text = "Label_DateOfRequest"
			Me.Label_DateOfRequest.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'LabelDetail_DateOfRequest
			'
			Me.LabelDetail_DateOfRequest.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_DateOfRequest.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_DateOfRequest.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_DateOfRequest.BorderWidth = 1
			Me.LabelDetail_DateOfRequest.CanGrow = False
			Me.LabelDetail_DateOfRequest.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_DateOfRequest.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_DateOfRequest.LocationFloat = New DevExpress.Utils.PointFloat(522.4169!, 32.83334!)
			Me.LabelDetail_DateOfRequest.Name = "LabelDetail_DateOfRequest"
			Me.LabelDetail_DateOfRequest.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_DateOfRequest.SizeF = New System.Drawing.SizeF(103.9583!, 18.99999!)
			Me.LabelDetail_DateOfRequest.StylePriority.UseFont = False
			Me.LabelDetail_DateOfRequest.StylePriority.UsePadding = False
			Me.LabelDetail_DateOfRequest.StylePriority.UseTextAlignment = False
			Me.LabelDetail_DateOfRequest.Text = "Date of Request:"
			Me.LabelDetail_DateOfRequest.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'Label_Campaign
			'
			Me.Label_Campaign.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.Label_Campaign.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 127.8333!)
			Me.Label_Campaign.Name = "Label_Campaign"
			Me.Label_Campaign.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Label_Campaign.SizeF = New System.Drawing.SizeF(614.2083!, 18.99995!)
			Me.Label_Campaign.StylePriority.UseFont = False
			'
			'Label_EndingDate
			'
			Me.Label_EndingDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CampaignEndDate", "{0:d}")})
			Me.Label_EndingDate.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.Label_EndingDate.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 165.8333!)
			Me.Label_EndingDate.Name = "Label_EndingDate"
			Me.Label_EndingDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Label_EndingDate.SizeF = New System.Drawing.SizeF(157.5416!, 18.99999!)
			Me.Label_EndingDate.StylePriority.UseFont = False
			Me.Label_EndingDate.Text = "Label_EndingDate"
			'
			'Label_BeginningDate
			'
			Me.Label_BeginningDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CampaignStartDate", "{0:d}")})
			Me.Label_BeginningDate.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.Label_BeginningDate.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 146.8333!)
			Me.Label_BeginningDate.Name = "Label_BeginningDate"
			Me.Label_BeginningDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Label_BeginningDate.SizeF = New System.Drawing.SizeF(157.5417!, 18.99999!)
			Me.Label_BeginningDate.StylePriority.UseFont = False
			Me.Label_BeginningDate.Text = "Label_BeginningDate"
			'
			'Label_Product
			'
			Me.Label_Product.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.Label_Product.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 108.8333!)
			Me.Label_Product.Name = "Label_Product"
			Me.Label_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Label_Product.SizeF = New System.Drawing.SizeF(614.2083!, 19.00001!)
			Me.Label_Product.StylePriority.UseFont = False
			'
			'Label_Division
			'
			Me.Label_Division.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.Label_Division.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 89.83333!)
			Me.Label_Division.Name = "Label_Division"
			Me.Label_Division.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Label_Division.SizeF = New System.Drawing.SizeF(614.2082!, 18.99999!)
			Me.Label_Division.StylePriority.UseFont = False
			'
			'LabelDetail_BeginningDate
			'
			Me.LabelDetail_BeginningDate.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_BeginningDate.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_BeginningDate.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_BeginningDate.BorderWidth = 1
			Me.LabelDetail_BeginningDate.CanGrow = False
			Me.LabelDetail_BeginningDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_BeginningDate.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_BeginningDate.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 146.8333!)
			Me.LabelDetail_BeginningDate.Name = "LabelDetail_BeginningDate"
			Me.LabelDetail_BeginningDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_BeginningDate.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
			Me.LabelDetail_BeginningDate.StylePriority.UseFont = False
			Me.LabelDetail_BeginningDate.StylePriority.UsePadding = False
			Me.LabelDetail_BeginningDate.StylePriority.UseTextAlignment = False
			Me.LabelDetail_BeginningDate.Text = "Beginning Date:"
			Me.LabelDetail_BeginningDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelDetail_Campaign
			'
			Me.LabelDetail_Campaign.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_Campaign.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_Campaign.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_Campaign.BorderWidth = 1
			Me.LabelDetail_Campaign.CanGrow = False
			Me.LabelDetail_Campaign.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_Campaign.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_Campaign.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 127.8333!)
			Me.LabelDetail_Campaign.Name = "LabelDetail_Campaign"
			Me.LabelDetail_Campaign.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_Campaign.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
			Me.LabelDetail_Campaign.StylePriority.UseFont = False
			Me.LabelDetail_Campaign.StylePriority.UsePadding = False
			Me.LabelDetail_Campaign.StylePriority.UseTextAlignment = False
			Me.LabelDetail_Campaign.Text = "Campaign:"
			Me.LabelDetail_Campaign.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelDetail_Product
			'
			Me.LabelDetail_Product.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_Product.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_Product.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_Product.BorderWidth = 1
			Me.LabelDetail_Product.CanGrow = False
			Me.LabelDetail_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_Product.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_Product.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 108.8333!)
			Me.LabelDetail_Product.Name = "LabelDetail_Product"
			Me.LabelDetail_Product.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_Product.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
			Me.LabelDetail_Product.StylePriority.UseFont = False
			Me.LabelDetail_Product.StylePriority.UsePadding = False
			Me.LabelDetail_Product.StylePriority.UseTextAlignment = False
			Me.LabelDetail_Product.Text = "Product:"
			Me.LabelDetail_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelDetail_Division
			'
			Me.LabelDetail_Division.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_Division.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_Division.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_Division.BorderWidth = 1
			Me.LabelDetail_Division.CanGrow = False
			Me.LabelDetail_Division.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_Division.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_Division.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 89.83331!)
			Me.LabelDetail_Division.Name = "LabelDetail_Division"
			Me.LabelDetail_Division.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_Division.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
			Me.LabelDetail_Division.StylePriority.UseFont = False
			Me.LabelDetail_Division.StylePriority.UsePadding = False
			Me.LabelDetail_Division.StylePriority.UseTextAlignment = False
			Me.LabelDetail_Division.Text = "Division:"
			Me.LabelDetail_Division.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'Label_Client
			'
			Me.Label_Client.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.Label_Client.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 70.83332!)
			Me.Label_Client.Name = "Label_Client"
			Me.Label_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Label_Client.SizeF = New System.Drawing.SizeF(614.2084!, 18.99999!)
			Me.Label_Client.StylePriority.UseFont = False
			'
			'LabelDetail_Client
			'
			Me.LabelDetail_Client.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_Client.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_Client.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_Client.BorderWidth = 1
			Me.LabelDetail_Client.CanGrow = False
			Me.LabelDetail_Client.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_Client.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_Client.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 70.83331!)
			Me.LabelDetail_Client.Name = "LabelDetail_Client"
			Me.LabelDetail_Client.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_Client.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
			Me.LabelDetail_Client.StylePriority.UseFont = False
			Me.LabelDetail_Client.StylePriority.UsePadding = False
			Me.LabelDetail_Client.StylePriority.UseTextAlignment = False
			Me.LabelDetail_Client.Text = "Client:"
			Me.LabelDetail_Client.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'Label_Number
			'
			Me.Label_Number.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.Label_Number.LocationFloat = New DevExpress.Utils.PointFloat(124.7918!, 32.83333!)
			Me.Label_Number.Name = "Label_Number"
			Me.Label_Number.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.Label_Number.SizeF = New System.Drawing.SizeF(81.24998!, 18.99999!)
			Me.Label_Number.StylePriority.UseFont = False
			'
			'LabelDetail_ATB
			'
			Me.LabelDetail_ATB.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_ATB.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_ATB.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_ATB.BorderWidth = 1
			Me.LabelDetail_ATB.CanGrow = False
			Me.LabelDetail_ATB.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_ATB.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_ATB.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 32.83331!)
			Me.LabelDetail_ATB.Name = "LabelDetail_ATB"
			Me.LabelDetail_ATB.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_ATB.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
			Me.LabelDetail_ATB.StylePriority.UseFont = False
			Me.LabelDetail_ATB.StylePriority.UsePadding = False
			Me.LabelDetail_ATB.StylePriority.UseTextAlignment = False
			Me.LabelDetail_ATB.Text = "ATB Number:"
			Me.LabelDetail_ATB.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelDetail_BillingComments
			'
			Me.LabelDetail_BillingComments.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_BillingComments.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_BillingComments.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_BillingComments.BorderWidth = 1
			Me.LabelDetail_BillingComments.CanGrow = False
			Me.LabelDetail_BillingComments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_BillingComments.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_BillingComments.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 388.4583!)
			Me.LabelDetail_BillingComments.Name = "LabelDetail_BillingComments"
			Me.LabelDetail_BillingComments.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_BillingComments.SizeF = New System.Drawing.SizeF(124.5!, 19.0!)
			Me.LabelDetail_BillingComments.StylePriority.UseFont = False
			Me.LabelDetail_BillingComments.StylePriority.UsePadding = False
			Me.LabelDetail_BillingComments.StylePriority.UseTextAlignment = False
			Me.LabelDetail_BillingComments.Text = "Billing Comments:"
			Me.LabelDetail_BillingComments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelDetail_DateToBill
			'
			Me.LabelDetail_DateToBill.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_DateToBill.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_DateToBill.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_DateToBill.BorderWidth = 1
			Me.LabelDetail_DateToBill.CanGrow = False
			Me.LabelDetail_DateToBill.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_DateToBill.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_DateToBill.LocationFloat = New DevExpress.Utils.PointFloat(0.5836328!, 257.8332!)
			Me.LabelDetail_DateToBill.Name = "LabelDetail_DateToBill"
			Me.LabelDetail_DateToBill.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_DateToBill.SizeF = New System.Drawing.SizeF(134.9167!, 19.0!)
			Me.LabelDetail_DateToBill.StylePriority.UseFont = False
			Me.LabelDetail_DateToBill.StylePriority.UsePadding = False
			Me.LabelDetail_DateToBill.StylePriority.UseTextAlignment = False
			Me.LabelDetail_DateToBill.Text = "Date to Bill:"
			Me.LabelDetail_DateToBill.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelDetail_ClientPO
			'
			Me.LabelDetail_ClientPO.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_ClientPO.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_ClientPO.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_ClientPO.BorderWidth = 1
			Me.LabelDetail_ClientPO.CanGrow = False
			Me.LabelDetail_ClientPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_ClientPO.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_ClientPO.LocationFloat = New DevExpress.Utils.PointFloat(0.5836328!, 276.8333!)
			Me.LabelDetail_ClientPO.Name = "LabelDetail_ClientPO"
			Me.LabelDetail_ClientPO.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_ClientPO.SizeF = New System.Drawing.SizeF(134.9167!, 19.0!)
			Me.LabelDetail_ClientPO.StylePriority.UseFont = False
			Me.LabelDetail_ClientPO.StylePriority.UsePadding = False
			Me.LabelDetail_ClientPO.StylePriority.UseTextAlignment = False
			Me.LabelDetail_ClientPO.Text = "Client PO:"
			Me.LabelDetail_ClientPO.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelDetail_BillingMethod
			'
			Me.LabelDetail_BillingMethod.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_BillingMethod.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_BillingMethod.Borders = DevExpress.XtraPrinting.BorderSide.None
			Me.LabelDetail_BillingMethod.BorderWidth = 1
			Me.LabelDetail_BillingMethod.CanGrow = False
			Me.LabelDetail_BillingMethod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_BillingMethod.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_BillingMethod.LocationFloat = New DevExpress.Utils.PointFloat(0.5836328!, 314.8333!)
			Me.LabelDetail_BillingMethod.Name = "LabelDetail_BillingMethod"
			Me.LabelDetail_BillingMethod.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100.0!)
			Me.LabelDetail_BillingMethod.SizeF = New System.Drawing.SizeF(134.9167!, 19.0!)
			Me.LabelDetail_BillingMethod.StylePriority.UseFont = False
			Me.LabelDetail_BillingMethod.StylePriority.UsePadding = False
			Me.LabelDetail_BillingMethod.StylePriority.UseTextAlignment = False
			Me.LabelDetail_BillingMethod.Text = "Billing Method:"
			Me.LabelDetail_BillingMethod.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
			'
			'LabelBillingInformation_Comments
			'
			Me.LabelBillingInformation_Comments.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingComments")})
			Me.LabelBillingInformation_Comments.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.LabelBillingInformation_Comments.LocationFloat = New DevExpress.Utils.PointFloat(124.5!, 388.4582!)
			Me.LabelBillingInformation_Comments.Multiline = True
			Me.LabelBillingInformation_Comments.Name = "LabelBillingInformation_Comments"
			Me.LabelBillingInformation_Comments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.LabelBillingInformation_Comments.SizeF = New System.Drawing.SizeF(613.9163!, 18.99997!)
			Me.LabelBillingInformation_Comments.StylePriority.UseFont = False
			Me.LabelBillingInformation_Comments.Text = "LabelBillingInformation_Comments"
			'
			'CheckBox_BillCommissionOnly
			'
			Me.CheckBox_BillCommissionOnly.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("CheckState", Nothing, "CommissionOnlyFlag")})
			Me.CheckBox_BillCommissionOnly.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
			Me.CheckBox_BillCommissionOnly.LocationFloat = New DevExpress.Utils.PointFloat(135.5003!, 295.8333!)
			Me.CheckBox_BillCommissionOnly.Name = "CheckBox_BillCommissionOnly"
			Me.CheckBox_BillCommissionOnly.SizeF = New System.Drawing.SizeF(157.2499!, 18.99997!)
			Me.CheckBox_BillCommissionOnly.StylePriority.UseFont = False
			Me.CheckBox_BillCommissionOnly.StylePriority.UseTextAlignment = False
			'
			'LabelBillingInformation_BillingDate
			'
			Me.LabelBillingInformation_BillingDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "BillingDate", "{0:d}")})
			Me.LabelBillingInformation_BillingDate.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelBillingInformation_BillingDate.LocationFloat = New DevExpress.Utils.PointFloat(135.5003!, 257.8332!)
            Me.LabelBillingInformation_BillingDate.Name = "LabelBillingInformation_BillingDate"
            Me.LabelBillingInformation_BillingDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelBillingInformation_BillingDate.SizeF = New System.Drawing.SizeF(157.2498!, 19.0!)
            Me.LabelBillingInformation_BillingDate.StylePriority.UseFont = False
            Me.LabelBillingInformation_BillingDate.Text = "LabelBillingInformation_BillingDate"
            '
            'LabelBillingInformation_ClientPO
            '
            Me.LabelBillingInformation_ClientPO.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientPO")})
            Me.LabelBillingInformation_ClientPO.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelBillingInformation_ClientPO.LocationFloat = New DevExpress.Utils.PointFloat(135.5003!, 276.8333!)
            Me.LabelBillingInformation_ClientPO.Name = "LabelBillingInformation_ClientPO"
            Me.LabelBillingInformation_ClientPO.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelBillingInformation_ClientPO.SizeF = New System.Drawing.SizeF(157.2498!, 19.0!)
            Me.LabelBillingInformation_ClientPO.StylePriority.UseFont = False
            Me.LabelBillingInformation_ClientPO.Text = "LabelBillingInformation_ClientPO"
            '
            'LabelBillingInformation_BillingMethod
            '
            Me.LabelBillingInformation_BillingMethod.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.LabelBillingInformation_BillingMethod.LocationFloat = New DevExpress.Utils.PointFloat(135.5003!, 314.8332!)
            Me.LabelBillingInformation_BillingMethod.Name = "LabelBillingInformation_BillingMethod"
            Me.LabelBillingInformation_BillingMethod.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelBillingInformation_BillingMethod.SizeF = New System.Drawing.SizeF(259.0001!, 18.99998!)
            Me.LabelBillingInformation_BillingMethod.StylePriority.UseFont = False
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
            Me.BottomMargin.HeightF = 59.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PictureBoxHeader_Logo
            '
            Me.PictureBoxHeader_Logo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.PictureBoxHeader_Logo.Name = "PictureBoxHeader_Logo"
            Me.PictureBoxHeader_Logo.SizeF = New System.Drawing.SizeF(748.0!, 150.6!)
            Me.PictureBoxHeader_Logo.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.LineWidth = 4
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 213.8333!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(749.0!, 4.000004!)
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
            Me.LabelPageHeader_Agency.LocationFloat = New DevExpress.Utils.PointFloat(413.9165!, 188.8333!)
            Me.LabelPageHeader_Agency.Name = "LabelPageHeader_Agency"
            Me.LabelPageHeader_Agency.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Agency.SizeF = New System.Drawing.SizeF(324.4996!, 19.0!)
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
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 171.8333!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(749.0!, 4.000004!)
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
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(9.416453!, 181.8333!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(404.5!, 26.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.Text = "Authorization to Buy Digital Media"
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
            Me.LabelPageFooter_DateAndUserCode.BorderWidth = 1
            Me.LabelPageFooter_DateAndUserCode.CanGrow = False
            Me.LabelPageFooter_DateAndUserCode.Font = New System.Drawing.Font("Arial", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
            Me.LabelPageFooter_DateAndUserCode.ForeColor = System.Drawing.Color.Black
            Me.LabelPageFooter_DateAndUserCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 4.999987!)
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
            'BindingSourceRevisionDetail
            '
            Me.BindingSourceRevisionDetail.DataSource = GetType(AdvantageFramework.Database.Entities.MediaATBRevisionDetail)
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.MediaATBRevision)
            '
            'GroupHeader_Main
            '
            Me.GroupHeader_Main.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelLocationHeaderInfo, Me.PictureBoxHeader_Logo, Me.LineTopLine, Me.LabelPageHeader_Agency, Me.XrLine1, Me.LabelPageHeader_Title})
            Me.GroupHeader_Main.HeightF = 222.9167!
            Me.GroupHeader_Main.Name = "GroupHeader_Main"
            '
            'XrLabelLocationHeaderInfo
            '
            Me.XrLabelLocationHeaderInfo.BorderColor = System.Drawing.Color.Black
            Me.XrLabelLocationHeaderInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabelLocationHeaderInfo.BorderWidth = 1
            Me.XrLabelLocationHeaderInfo.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelLocationHeaderInfo.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 150.6!)
            Me.XrLabelLocationHeaderInfo.Name = "XrLabelLocationHeaderInfo"
            Me.XrLabelLocationHeaderInfo.SizeF = New System.Drawing.SizeF(748.0!, 17.0!)
            Me.XrLabelLocationHeaderInfo.StylePriority.UseBackColor = False
            Me.XrLabelLocationHeaderInfo.StylePriority.UseFont = False
            Me.XrLabelLocationHeaderInfo.StylePriority.UsePadding = False
            Me.XrLabelLocationHeaderInfo.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0}"
            Me.XrLabelLocationHeaderInfo.Summary = XrSummary2
            Me.XrLabelLocationHeaderInfo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'MediaATBReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter, Me.GroupHeader_Main})
            Me.DataSource = Me.BindingSource
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 39, 59)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic 
            Me.Version = "14.2"
            CType(Me.BindingSourceRevisionDetail, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Private WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelPageHeader_Agency As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents DepartmentTeamSubReport1 As AdvantageFramework.Reporting.Reports.Employee.DepartmentTeamSubReport
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Private WithEvents LabelPageFooter_DateAndUserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents Label_Number As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ATB As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_BeginningDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Campaign As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Product As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Division As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Client As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Client As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Product As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Division As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_EndingDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_BeginningDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents CheckBox_BillCommissionOnly As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents Label_Campaign As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSourceRevisionDetail As System.Windows.Forms.BindingSource
        Private WithEvents Label_DateOfRequest As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DateOfRequest As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Revision As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents Label_Revision As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Comments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_SalesClass As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_ClientBudget As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_Description As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Comments As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_SalesClass As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ClientBudget As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_EndingDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelBillingInformation_BillingMethod As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_BillingMethod As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelBillingInformation_ClientPO As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelBillingInformation_BillingDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_ClientPO As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_DateToBill As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelBillingInformation_Comments As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_BillingComments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents PictureBoxHeader_Logo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents GroupHeader_Main As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SubReport_RevisionDetails As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents LabelHeader_Canceled As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelLocationHeaderInfo As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
