Namespace MediaManager

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Public Class InternetOrderReport
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
            Dim XrSummary1 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary2 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.DetailLabel_Cancelled = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Instructions = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_RateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel4 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel9 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel8 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel7 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel6 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel5 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_Units = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_SizeLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_EndLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_EndLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_DimenstionsLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_TargetLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.Detail_Target = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_MarketDetail = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_MarketDetailLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel3 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetail_InstructionsLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_OrderDescription = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupHeaderOrderHeader_Top = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelHeaderOrderNumber_VendorCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_VenRepLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageInfo_Pages = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.LabelHeaderOrderNumber_PrintDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_DateLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_OrderNumber = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_Email = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_Buyer = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_OrderNumberLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_PageLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_BuyerLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumber_EmailLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrTableCampaignMarket = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowCampaignMarket_Campaign = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCampaignMarket_CampaignLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCampaignMarket_Campaign = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowCampaignMarket_Market = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCampaignMarket_MarketLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCampaignMarket_Market = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrPictureBoxHeaderLogo = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeaderOrderNumberTop_OrderLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooter = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.LabelPageFooter_LocationFooter = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterOrderNumber = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterOrderCommentTop = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_OrderCommentTop = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterOrderNumberSubreport_ChargeToSubReport = New DevExpress.XtraReports.UI.XRSubreport()
            Me.LabelGroupFooterOrderNumber_LineTotalActual = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_VendorTaxSum = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_NetChargeSum = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_DiscountSum = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooterOrderNumber_AmountSubtotal = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelFooterOrderNumber_SubtotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupFooterOrderNumberSubreport_VendorShippingSubReport = New DevExpress.XtraReports.UI.XRSubreport()
            Me.LabelGroupFooterOrderNumber_ShipToLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_Box = New DevExpress.XtraReports.UI.XRLabel()
            Me.SubBandSignatures = New DevExpress.XtraReports.UI.SubBand()
            Me.LabelGroupFooterOrderNumber_PrintDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate = New DevExpress.XtraReports.UI.XRLine()
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineGroupFooterOrderNumber_VendorAcceptance = New DevExpress.XtraReports.UI.XRLine()
            Me.LineGroupFooterOrderNumber_AgencyAuthorization = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelGroupFooterOrderNumber_VendorAcceptance = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrPictureBoxSignature = New DevExpress.XtraReports.UI.XRPictureBox()
            Me.SubBandCommentsBelowSignatures = New DevExpress.XtraReports.UI.SubBand()
            Me.LabelGroupFooterOrderComment = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_AgencyComment = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterOrderNumber_OrderComment = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderEveryPage2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrTableHeaderLeft = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowLeftStation = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCell2 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell3 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowLeftClient = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellClient_Client = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell9 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRow1 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellClient_Address1 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellClient_Address1Value = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRow2 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellClient_Address2 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellClient_Address2Value = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRow3 = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellClient_CityStateZip = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellClient_CityStateZipValue = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowLeftDivision = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellClient_Division = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell7 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableRowLeftProduct = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellClient_Product = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCell5 = New DevExpress.XtraReports.UI.XRTableCell()
            Me.GroupHeaderEveryPage = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupHeaderOrderNumberTopSubreportVendorAddress = New DevExpress.XtraReports.UI.XRSubreport()
            Me.GroupHeaderOrderNumberTopSubreportVendorRep2 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.GroupHeaderOrderNumberTopSubreportVendorRep1 = New DevExpress.XtraReports.UI.XRSubreport()
            Me.SubBand1 = New DevExpress.XtraReports.UI.SubBand()
            Me.LabelSubBand1_ExtraSpaceByDesign = New DevExpress.XtraReports.UI.XRLabel()
            Me.ReportHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.DetailReportFlightLines = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailFlightLines = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel1 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel14 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel13 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel12 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel10 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailReportFlightLinesHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.XrLabel15 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel16 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel17 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailReportFlightLinesHeader_Units = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel20 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailReportFlightLinesFooter = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourceFlightLines = New System.Windows.Forms.BindingSource(Me.components)
            Me.LineDetail_Bottom = New DevExpress.XtraReports.UI.XRLine()
            Me.DetailReportPackageAdSizes = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailPackageAdSizes = New DevExpress.XtraReports.UI.DetailBand()
            Me.LabelDetailPackageAdSizesPlacementName = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailPackageAdSizesAdSize = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailReportPackageAdSizesHeader = New DevExpress.XtraReports.UI.ReportHeaderBand()
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailReportPackageAdSizesHeader_Size = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSourcePackageAdSizes = New System.Windows.Forms.BindingSource(Me.components)
            Me.GroupHeaderFirstPageOnly2 = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrTableHeaderInfo = New DevExpress.XtraReports.UI.XRTable()
            Me.XrTableRowHeaderOrderComment = New DevExpress.XtraReports.UI.XRTableRow()
            Me.XrTableCellHeaderOrderInstructionsLabel = New DevExpress.XtraReports.UI.XRTableCell()
            Me.XrTableCellHeaderOrderComment = New DevExpress.XtraReports.UI.XRTableCell()
            Me.GroupHeaderTarget = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooterTarget = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.LabelGroupFooterTarget_URLLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterTarget_URL = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterTarget_Placement = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelGroupFooterTarget_PlacementLabel = New DevExpress.XtraReports.UI.XRLabel()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.DetailReportPackagePlacementNames = New DevExpress.XtraReports.UI.DetailReportBand()
            Me.DetailPackagePlacementNames = New DevExpress.XtraReports.UI.DetailBand()
            Me.XrLabel11 = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabel2 = New DevExpress.XtraReports.UI.XRLabel()
            Me.DetailReportPackagePlacementNamesHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLabel18 = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements = New DevExpress.XtraReports.UI.XRLabel()
            Me.ObjectDataSource1 = New DevExpress.DataAccess.ObjectBinding.ObjectDataSource(Me.components)
            CType(Me.XrTableCampaignMarket, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrTableHeaderLeft, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourceFlightLines, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSourcePackageAdSizes, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.XrTableHeaderInfo, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ObjectDataSource1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.DetailLabel_Cancelled, Me.LabelDetail_Instructions, Me.LabelDetail_Rate, Me.LabelDetail_RateLabel, Me.XrLabel4, Me.XrLabel9, Me.XrLabel8, Me.XrLabel7, Me.XrLabel6, Me.XrLabel5, Me.LabelDetail_Units, Me.LabelHeaderOrderNumber_SizeLabel, Me.LabelHeaderOrderNumber_EndLabel1, Me.LabelHeaderOrderNumber_EndLabel2, Me.LabelDetail_DimenstionsLabel, Me.LabelDetail_TargetLabel, Me.Detail_Target, Me.LabelDetail_MarketDetail, Me.LabelDetail_MarketDetailLabel, Me.XrLabel3, Me.LabelDetail_InstructionsLabel})
            Me.Detail.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.Detail.HeightF = 92.66995!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.StylePriority.UseFont = False
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'DetailLabel_Cancelled
            '
            Me.DetailLabel_Cancelled.BackColor = System.Drawing.Color.Yellow
            Me.DetailLabel_Cancelled.BorderColor = System.Drawing.Color.Black
            Me.DetailLabel_Cancelled.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.DetailLabel_Cancelled.BorderWidth = 1.0!
            Me.DetailLabel_Cancelled.CanGrow = False
            Me.DetailLabel_Cancelled.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.DetailLabel_Cancelled.ForeColor = System.Drawing.Color.Black
            Me.DetailLabel_Cancelled.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 18.99999!)
            Me.DetailLabel_Cancelled.Name = "DetailLabel_Cancelled"
            Me.DetailLabel_Cancelled.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.DetailLabel_Cancelled.SizeF = New System.Drawing.SizeF(104.1213!, 16.67!)
            Me.DetailLabel_Cancelled.StylePriority.UseBackColor = False
            Me.DetailLabel_Cancelled.StylePriority.UseFont = False
            Me.DetailLabel_Cancelled.StylePriority.UsePadding = False
            Me.DetailLabel_Cancelled.StylePriority.UseTextAlignment = False
            Me.DetailLabel_Cancelled.Text = "**CANCELLED**"
            Me.DetailLabel_Cancelled.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_Instructions
            '
            Me.LabelDetail_Instructions.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Instructions")})
            Me.LabelDetail_Instructions.LocationFloat = New DevExpress.Utils.PointFloat(83.33002!, 73.66994!)
            Me.LabelDetail_Instructions.Multiline = True
            Me.LabelDetail_Instructions.Name = "LabelDetail_Instructions"
            Me.LabelDetail_Instructions.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Instructions.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_Instructions.SizeF = New System.Drawing.SizeF(665.7997!, 18.99999!)
            '
            'LabelDetail_Rate
            '
            Me.LabelDetail_Rate.LocationFloat = New DevExpress.Utils.PointFloat(544.5552!, 54.66995!)
            Me.LabelDetail_Rate.Multiline = True
            Me.LabelDetail_Rate.Name = "LabelDetail_Rate"
            Me.LabelDetail_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_Rate.SizeF = New System.Drawing.SizeF(69.78821!, 18.99999!)
            Me.LabelDetail_Rate.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Rate.Text = "Rate"
            Me.LabelDetail_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.LabelDetail_Rate.TextFormatString = "{0:n4}"
            '
            'LabelDetail_RateLabel
            '
            Me.LabelDetail_RateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_RateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_RateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_RateLabel.BorderWidth = 1.0!
            Me.LabelDetail_RateLabel.CanGrow = False
            Me.LabelDetail_RateLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_RateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_RateLabel.LocationFloat = New DevExpress.Utils.PointFloat(544.5552!, 37.99998!)
            Me.LabelDetail_RateLabel.Name = "LabelDetail_RateLabel"
            Me.LabelDetail_RateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_RateLabel.SizeF = New System.Drawing.SizeF(69.78821!, 16.67!)
            Me.LabelDetail_RateLabel.StylePriority.UseFont = False
            Me.LabelDetail_RateLabel.StylePriority.UsePadding = False
            Me.LabelDetail_RateLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_RateLabel.Text = "Rate"
            Me.LabelDetail_RateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel4
            '
            Me.XrLabel4.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Dimensions")})
            Me.XrLabel4.LocationFloat = New DevExpress.Utils.PointFloat(0!, 54.66995!)
            Me.XrLabel4.Multiline = True
            Me.XrLabel4.Name = "XrLabel4"
            Me.XrLabel4.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 2, 0, 0, 100.0!)
            Me.XrLabel4.SizeF = New System.Drawing.SizeF(175.9632!, 18.99999!)
            Me.XrLabel4.StylePriority.UsePadding = False
            Me.XrLabel4.Text = "XrLabel4"
            '
            'XrLabel9
            '
            Me.XrLabel9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Cost")})
            Me.XrLabel9.LocationFloat = New DevExpress.Utils.PointFloat(619.3433!, 54.66995!)
            Me.XrLabel9.Multiline = True
            Me.XrLabel9.Name = "XrLabel9"
            Me.XrLabel9.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel9.SizeF = New System.Drawing.SizeF(129.7862!, 18.99999!)
            Me.XrLabel9.StylePriority.UseTextAlignment = False
            Me.XrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrLabel9.TextFormatString = "{0:n2}"
            '
            'XrLabel8
            '
            Me.XrLabel8.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Units")})
            Me.XrLabel8.LocationFloat = New DevExpress.Utils.PointFloat(419.9597!, 54.66995!)
            Me.XrLabel8.Multiline = True
            Me.XrLabel8.Name = "XrLabel8"
            Me.XrLabel8.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel8.SizeF = New System.Drawing.SizeF(114.1239!, 18.99999!)
            Me.XrLabel8.StylePriority.UseTextAlignment = False
            Me.XrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrLabel8.TextFormatString = "{0:#,#}"
            '
            'XrLabel7
            '
            Me.XrLabel7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CostStructure")})
            Me.XrLabel7.LocationFloat = New DevExpress.Utils.PointFloat(325.4181!, 54.66995!)
            Me.XrLabel7.Multiline = True
            Me.XrLabel7.Name = "XrLabel7"
            Me.XrLabel7.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel7.SizeF = New System.Drawing.SizeF(88.54166!, 18.99999!)
            Me.XrLabel7.Text = "XrLabel7"
            '
            'XrLabel6
            '
            Me.XrLabel6.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EndDate")})
            Me.XrLabel6.LocationFloat = New DevExpress.Utils.PointFloat(252.6732!, 54.66995!)
            Me.XrLabel6.Multiline = True
            Me.XrLabel6.Name = "XrLabel6"
            Me.XrLabel6.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel6.SizeF = New System.Drawing.SizeF(67.70999!, 18.99999!)
            Me.XrLabel6.TextFormatString = "{0:M/d/yyyy}"
            '
            'XrLabel5
            '
            Me.XrLabel5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StartDate")})
            Me.XrLabel5.LocationFloat = New DevExpress.Utils.PointFloat(179.9632!, 54.66995!)
            Me.XrLabel5.Multiline = True
            Me.XrLabel5.Name = "XrLabel5"
            Me.XrLabel5.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel5.SizeF = New System.Drawing.SizeF(67.70998!, 19.0!)
            Me.XrLabel5.TextFormatString = "{0:M/d/yyyy}"
            '
            'LabelDetail_Units
            '
            Me.LabelDetail_Units.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_Units.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_Units.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_Units.BorderWidth = 1.0!
            Me.LabelDetail_Units.CanGrow = False
            Me.LabelDetail_Units.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_Units.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_Units.LocationFloat = New DevExpress.Utils.PointFloat(419.9598!, 37.99998!)
            Me.LabelDetail_Units.Name = "LabelDetail_Units"
            Me.LabelDetail_Units.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_Units.SizeF = New System.Drawing.SizeF(124.5954!, 16.67!)
            Me.LabelDetail_Units.StylePriority.UseFont = False
            Me.LabelDetail_Units.StylePriority.UsePadding = False
            Me.LabelDetail_Units.StylePriority.UseTextAlignment = False
            Me.LabelDetail_Units.Text = "Units"
            Me.LabelDetail_Units.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_SizeLabel
            '
            Me.LabelHeaderOrderNumber_SizeLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_SizeLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_SizeLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_SizeLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_SizeLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_SizeLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_SizeLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_SizeLabel.LocationFloat = New DevExpress.Utils.PointFloat(325.3832!, 37.99998!)
            Me.LabelHeaderOrderNumber_SizeLabel.Name = "LabelHeaderOrderNumber_SizeLabel"
            Me.LabelHeaderOrderNumber_SizeLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_SizeLabel.SizeF = New System.Drawing.SizeF(88.57654!, 16.67!)
            Me.LabelHeaderOrderNumber_SizeLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_SizeLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_SizeLabel.StylePriority.UseTextAlignment = False
            Me.LabelHeaderOrderNumber_SizeLabel.Text = "Cost Structure"
            Me.LabelHeaderOrderNumber_SizeLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_EndLabel1
            '
            Me.LabelHeaderOrderNumber_EndLabel1.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_EndLabel1.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EndLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_EndLabel1.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_EndLabel1.CanGrow = False
            Me.LabelHeaderOrderNumber_EndLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_EndLabel1.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EndLabel1.LocationFloat = New DevExpress.Utils.PointFloat(252.6732!, 37.99998!)
            Me.LabelHeaderOrderNumber_EndLabel1.Name = "LabelHeaderOrderNumber_EndLabel1"
            Me.LabelHeaderOrderNumber_EndLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_EndLabel1.SizeF = New System.Drawing.SizeF(67.71002!, 16.67!)
            Me.LabelHeaderOrderNumber_EndLabel1.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_EndLabel1.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_EndLabel1.StylePriority.UseTextAlignment = False
            Me.LabelHeaderOrderNumber_EndLabel1.Text = "End Date"
            Me.LabelHeaderOrderNumber_EndLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_EndLabel2
            '
            Me.LabelHeaderOrderNumber_EndLabel2.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_EndLabel2.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EndLabel2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_EndLabel2.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_EndLabel2.CanGrow = False
            Me.LabelHeaderOrderNumber_EndLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_EndLabel2.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EndLabel2.LocationFloat = New DevExpress.Utils.PointFloat(179.9632!, 37.99998!)
            Me.LabelHeaderOrderNumber_EndLabel2.Name = "LabelHeaderOrderNumber_EndLabel2"
            Me.LabelHeaderOrderNumber_EndLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_EndLabel2.SizeF = New System.Drawing.SizeF(67.71004!, 16.67!)
            Me.LabelHeaderOrderNumber_EndLabel2.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_EndLabel2.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_EndLabel2.StylePriority.UseTextAlignment = False
            Me.LabelHeaderOrderNumber_EndLabel2.Text = "Start Date"
            Me.LabelHeaderOrderNumber_EndLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_DimenstionsLabel
            '
            Me.LabelDetail_DimenstionsLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_DimenstionsLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_DimenstionsLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_DimenstionsLabel.BorderWidth = 1.0!
            Me.LabelDetail_DimenstionsLabel.CanGrow = False
            Me.LabelDetail_DimenstionsLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_DimenstionsLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_DimenstionsLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 37.99998!)
            Me.LabelDetail_DimenstionsLabel.Name = "LabelDetail_DimenstionsLabel"
            Me.LabelDetail_DimenstionsLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_DimenstionsLabel.SizeF = New System.Drawing.SizeF(83.33002!, 16.67!)
            Me.LabelDetail_DimenstionsLabel.StylePriority.UseFont = False
            Me.LabelDetail_DimenstionsLabel.StylePriority.UsePadding = False
            Me.LabelDetail_DimenstionsLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_DimenstionsLabel.Text = "Dimensions"
            Me.LabelDetail_DimenstionsLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_TargetLabel
            '
            Me.LabelDetail_TargetLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_TargetLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_TargetLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_TargetLabel.BorderWidth = 1.0!
            Me.LabelDetail_TargetLabel.CanGrow = False
            Me.LabelDetail_TargetLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_TargetLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_TargetLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetail_TargetLabel.Name = "LabelDetail_TargetLabel"
            Me.LabelDetail_TargetLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_TargetLabel.SizeF = New System.Drawing.SizeF(52.04493!, 18.99999!)
            Me.LabelDetail_TargetLabel.StylePriority.UseFont = False
            Me.LabelDetail_TargetLabel.StylePriority.UsePadding = False
            Me.LabelDetail_TargetLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_TargetLabel.Text = "Target:"
            Me.LabelDetail_TargetLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Detail_Target
            '
            Me.Detail_Target.LocationFloat = New DevExpress.Utils.PointFloat(58.24331!, 0!)
            Me.Detail_Target.Multiline = True
            Me.Detail_Target.Name = "Detail_Target"
            Me.Detail_Target.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Detail_Target.SizeF = New System.Drawing.SizeF(443.8716!, 18.99999!)
            Me.Detail_Target.Text = "Detail_Target"
            '
            'LabelDetail_MarketDetail
            '
            Me.LabelDetail_MarketDetail.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LineMarketDescription")})
            Me.LabelDetail_MarketDetail.LocationFloat = New DevExpress.Utils.PointFloat(554.1598!, 0!)
            Me.LabelDetail_MarketDetail.Multiline = True
            Me.LabelDetail_MarketDetail.Name = "LabelDetail_MarketDetail"
            Me.LabelDetail_MarketDetail.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetail_MarketDetail.SizeF = New System.Drawing.SizeF(194.9698!, 18.99999!)
            '
            'LabelDetail_MarketDetailLabel
            '
            Me.LabelDetail_MarketDetailLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_MarketDetailLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_MarketDetailLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_MarketDetailLabel.BorderWidth = 1.0!
            Me.LabelDetail_MarketDetailLabel.CanGrow = False
            Me.LabelDetail_MarketDetailLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_MarketDetailLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_MarketDetailLabel.LocationFloat = New DevExpress.Utils.PointFloat(502.1149!, 0!)
            Me.LabelDetail_MarketDetailLabel.Name = "LabelDetail_MarketDetailLabel"
            Me.LabelDetail_MarketDetailLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_MarketDetailLabel.SizeF = New System.Drawing.SizeF(52.04493!, 18.99999!)
            Me.LabelDetail_MarketDetailLabel.StylePriority.UseFont = False
            Me.LabelDetail_MarketDetailLabel.StylePriority.UsePadding = False
            Me.LabelDetail_MarketDetailLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_MarketDetailLabel.Text = "Market:"
            Me.LabelDetail_MarketDetailLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel3
            '
            Me.XrLabel3.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel3.BorderColor = System.Drawing.Color.Black
            Me.XrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel3.BorderWidth = 1.0!
            Me.XrLabel3.CanGrow = False
            Me.XrLabel3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel3.ForeColor = System.Drawing.Color.Black
            Me.XrLabel3.LocationFloat = New DevExpress.Utils.PointFloat(619.3433!, 37.99998!)
            Me.XrLabel3.Name = "XrLabel3"
            Me.XrLabel3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel3.SizeF = New System.Drawing.SizeF(129.7863!, 16.67!)
            Me.XrLabel3.StylePriority.UseFont = False
            Me.XrLabel3.StylePriority.UsePadding = False
            Me.XrLabel3.StylePriority.UseTextAlignment = False
            Me.XrLabel3.Text = "Cost"
            Me.XrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetail_InstructionsLabel
            '
            Me.LabelDetail_InstructionsLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetail_InstructionsLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelDetail_InstructionsLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetail_InstructionsLabel.BorderWidth = 1.0!
            Me.LabelDetail_InstructionsLabel.CanGrow = False
            Me.LabelDetail_InstructionsLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetail_InstructionsLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelDetail_InstructionsLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0002543131!, 73.66994!)
            Me.LabelDetail_InstructionsLabel.Name = "LabelDetail_InstructionsLabel"
            Me.LabelDetail_InstructionsLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetail_InstructionsLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelDetail_InstructionsLabel.SizeF = New System.Drawing.SizeF(83.32965!, 19.00001!)
            Me.LabelDetail_InstructionsLabel.StylePriority.UseFont = False
            Me.LabelDetail_InstructionsLabel.StylePriority.UsePadding = False
            Me.LabelDetail_InstructionsLabel.StylePriority.UseTextAlignment = False
            Me.LabelDetail_InstructionsLabel.Text = "Instructions:"
            Me.LabelDetail_InstructionsLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 25.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 50.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.BottomMargin.Visible = False
            '
            'LabelHeaderOrderNumber_OrderDescriptionLabel
            '
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.LocationFloat = New DevExpress.Utils.PointFloat(424.0!, 76.66664!)
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.Name = "LabelHeaderOrderNumber_OrderDescriptionLabel"
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.SizeF = New System.Drawing.SizeF(95.95999!, 19.0!)
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.Text = "Description:"
            Me.LabelHeaderOrderNumber_OrderDescriptionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_OrderDescription
            '
            Me.LabelHeaderOrderNumber_OrderDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderDescription")})
            Me.LabelHeaderOrderNumber_OrderDescription.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelHeaderOrderNumber_OrderDescription.LocationFloat = New DevExpress.Utils.PointFloat(520.83!, 76.66667!)
            Me.LabelHeaderOrderNumber_OrderDescription.Name = "LabelHeaderOrderNumber_OrderDescription"
            Me.LabelHeaderOrderNumber_OrderDescription.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_OrderDescription.SizeF = New System.Drawing.SizeF(228.2997!, 19.00001!)
            Me.LabelHeaderOrderNumber_OrderDescription.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_OrderDescription.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_OrderDescription.Text = "LabelHeaderOrderNumber_OrderDescription"
            '
            'LineGroupHeaderOrderHeader_Top
            '
            Me.LineGroupHeaderOrderHeader_Top.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderOrderHeader_Top.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderOrderHeader_Top.BorderWidth = 1.0!
            Me.LineGroupHeaderOrderHeader_Top.ForeColor = System.Drawing.Color.Black
            Me.LineGroupHeaderOrderHeader_Top.LocationFloat = New DevExpress.Utils.PointFloat(0.0001430511!, 156.0!)
            Me.LineGroupHeaderOrderHeader_Top.Name = "LineGroupHeaderOrderHeader_Top"
            Me.LineGroupHeaderOrderHeader_Top.SizeF = New System.Drawing.SizeF(749.9999!, 7.499992!)
            Me.LineGroupHeaderOrderHeader_Top.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderOrderHeader_Top.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderOrderHeader_Top.StylePriority.UseForeColor = False
            '
            'LabelHeaderOrderNumber_VendorCode
            '
            Me.LabelHeaderOrderNumber_VendorCode.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorCode")})
            Me.LabelHeaderOrderNumber_VendorCode.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelHeaderOrderNumber_VendorCode.LocationFloat = New DevExpress.Utils.PointFloat(654.1598!, 19.00002!)
            Me.LabelHeaderOrderNumber_VendorCode.Name = "LabelHeaderOrderNumber_VendorCode"
            Me.LabelHeaderOrderNumber_VendorCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_VendorCode.SizeF = New System.Drawing.SizeF(95.83997!, 18.83332!)
            Me.LabelHeaderOrderNumber_VendorCode.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_VendorCode.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_VendorCode.Text = "LabelHeaderOrderNumber_VendorCode"
            '
            'LabelHeaderOrderNumber_VenRepLabel
            '
            Me.LabelHeaderOrderNumber_VenRepLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_VenRepLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_VenRepLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_VenRepLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_VenRepLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_VenRepLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_VenRepLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_VenRepLabel.LocationFloat = New DevExpress.Utils.PointFloat(591.6598!, 19.16666!)
            Me.LabelHeaderOrderNumber_VenRepLabel.Name = "LabelHeaderOrderNumber_VenRepLabel"
            Me.LabelHeaderOrderNumber_VenRepLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_VenRepLabel.SizeF = New System.Drawing.SizeF(62.5!, 18.66665!)
            Me.LabelHeaderOrderNumber_VenRepLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_VenRepLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_VenRepLabel.Text = "Ven/Rep:"
            Me.LabelHeaderOrderNumber_VenRepLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageInfo_Pages
            '
            Me.PageInfo_Pages.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.PageInfo_Pages.LocationFloat = New DevExpress.Utils.PointFloat(520.83!, 18.99999!)
            Me.PageInfo_Pages.Name = "PageInfo_Pages"
            Me.PageInfo_Pages.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.PageInfo_Pages.SizeF = New System.Drawing.SizeF(70.82996!, 18.66666!)
            Me.PageInfo_Pages.StylePriority.UseFont = False
            Me.PageInfo_Pages.StylePriority.UsePadding = False
            Me.PageInfo_Pages.StylePriority.UseTextAlignment = False
            Me.PageInfo_Pages.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.PageInfo_Pages.TextFormatString = "{0} of {1}"
            '
            'LabelHeaderOrderNumber_PrintDate
            '
            Me.LabelHeaderOrderNumber_PrintDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PrintDate", "{0:d}")})
            Me.LabelHeaderOrderNumber_PrintDate.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelHeaderOrderNumber_PrintDate.LocationFloat = New DevExpress.Utils.PointFloat(654.1598!, 0!)
            Me.LabelHeaderOrderNumber_PrintDate.Name = "LabelHeaderOrderNumber_PrintDate"
            Me.LabelHeaderOrderNumber_PrintDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_PrintDate.SizeF = New System.Drawing.SizeF(95.83997!, 18.83334!)
            Me.LabelHeaderOrderNumber_PrintDate.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_PrintDate.StylePriority.UsePadding = False
            '
            'LabelHeaderOrderNumber_DateLabel
            '
            Me.LabelHeaderOrderNumber_DateLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_DateLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_DateLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_DateLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_DateLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_DateLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_DateLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_DateLabel.LocationFloat = New DevExpress.Utils.PointFloat(591.6598!, 0!)
            Me.LabelHeaderOrderNumber_DateLabel.Name = "LabelHeaderOrderNumber_DateLabel"
            Me.LabelHeaderOrderNumber_DateLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_DateLabel.SizeF = New System.Drawing.SizeF(62.5!, 18.83334!)
            Me.LabelHeaderOrderNumber_DateLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_DateLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_DateLabel.Text = "Date:"
            Me.LabelHeaderOrderNumber_DateLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_OrderNumber
            '
            Me.LabelHeaderOrderNumber_OrderNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderNumber")})
            Me.LabelHeaderOrderNumber_OrderNumber.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelHeaderOrderNumber_OrderNumber.LocationFloat = New DevExpress.Utils.PointFloat(520.8299!, 0!)
            Me.LabelHeaderOrderNumber_OrderNumber.Name = "LabelHeaderOrderNumber_OrderNumber"
            Me.LabelHeaderOrderNumber_OrderNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_OrderNumber.SizeF = New System.Drawing.SizeF(70.83!, 19.00001!)
            Me.LabelHeaderOrderNumber_OrderNumber.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_OrderNumber.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_OrderNumber.Text = "LabelHeaderOrderNumber_OrderNumber"
            '
            'LabelHeaderOrderNumber_Email
            '
            Me.LabelHeaderOrderNumber_Email.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelHeaderOrderNumber_Email.LocationFloat = New DevExpress.Utils.PointFloat(520.83!, 57.50005!)
            Me.LabelHeaderOrderNumber_Email.Name = "LabelHeaderOrderNumber_Email"
            Me.LabelHeaderOrderNumber_Email.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_Email.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelHeaderOrderNumber_Email.SizeF = New System.Drawing.SizeF(228.2997!, 19.00001!)
            Me.LabelHeaderOrderNumber_Email.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_Email.StylePriority.UsePadding = False
            '
            'LabelHeaderOrderNumber_Buyer
            '
            Me.LabelHeaderOrderNumber_Buyer.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Buyer")})
            Me.LabelHeaderOrderNumber_Buyer.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelHeaderOrderNumber_Buyer.LocationFloat = New DevExpress.Utils.PointFloat(520.83!, 38.50005!)
            Me.LabelHeaderOrderNumber_Buyer.Name = "LabelHeaderOrderNumber_Buyer"
            Me.LabelHeaderOrderNumber_Buyer.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_Buyer.SizeF = New System.Drawing.SizeF(228.2997!, 18.99999!)
            Me.LabelHeaderOrderNumber_Buyer.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_Buyer.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_Buyer.Text = "LabelHeaderOrderNumber_Buyer"
            '
            'LabelHeaderOrderNumber_OrderNumberLabel
            '
            Me.LabelHeaderOrderNumber_OrderNumberLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_OrderNumberLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_OrderNumberLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_OrderNumberLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_OrderNumberLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_OrderNumberLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_OrderNumberLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_OrderNumberLabel.LocationFloat = New DevExpress.Utils.PointFloat(424.0!, 0!)
            Me.LabelHeaderOrderNumber_OrderNumberLabel.Name = "LabelHeaderOrderNumber_OrderNumberLabel"
            Me.LabelHeaderOrderNumber_OrderNumberLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_OrderNumberLabel.SizeF = New System.Drawing.SizeF(95.95981!, 19.0!)
            Me.LabelHeaderOrderNumber_OrderNumberLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_OrderNumberLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_OrderNumberLabel.Text = "Order No:"
            Me.LabelHeaderOrderNumber_OrderNumberLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_PageLabel
            '
            Me.LabelHeaderOrderNumber_PageLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_PageLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_PageLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_PageLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_PageLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_PageLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_PageLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_PageLabel.LocationFloat = New DevExpress.Utils.PointFloat(424.0!, 18.99999!)
            Me.LabelHeaderOrderNumber_PageLabel.Name = "LabelHeaderOrderNumber_PageLabel"
            Me.LabelHeaderOrderNumber_PageLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_PageLabel.SizeF = New System.Drawing.SizeF(95.96005!, 19.0!)
            Me.LabelHeaderOrderNumber_PageLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_PageLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_PageLabel.Text = "Page:"
            Me.LabelHeaderOrderNumber_PageLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_BuyerLabel
            '
            Me.LabelHeaderOrderNumber_BuyerLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_BuyerLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_BuyerLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_BuyerLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_BuyerLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_BuyerLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_BuyerLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_BuyerLabel.LocationFloat = New DevExpress.Utils.PointFloat(424.0!, 38.50009!)
            Me.LabelHeaderOrderNumber_BuyerLabel.Name = "LabelHeaderOrderNumber_BuyerLabel"
            Me.LabelHeaderOrderNumber_BuyerLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_BuyerLabel.SizeF = New System.Drawing.SizeF(95.95975!, 19.0!)
            Me.LabelHeaderOrderNumber_BuyerLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_BuyerLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_BuyerLabel.Text = "Buyer:"
            Me.LabelHeaderOrderNumber_BuyerLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelHeaderOrderNumber_EmailLabel
            '
            Me.LabelHeaderOrderNumber_EmailLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelHeaderOrderNumber_EmailLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EmailLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelHeaderOrderNumber_EmailLabel.BorderWidth = 1.0!
            Me.LabelHeaderOrderNumber_EmailLabel.CanGrow = False
            Me.LabelHeaderOrderNumber_EmailLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelHeaderOrderNumber_EmailLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelHeaderOrderNumber_EmailLabel.LocationFloat = New DevExpress.Utils.PointFloat(424.0!, 57.50008!)
            Me.LabelHeaderOrderNumber_EmailLabel.Name = "LabelHeaderOrderNumber_EmailLabel"
            Me.LabelHeaderOrderNumber_EmailLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumber_EmailLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelHeaderOrderNumber_EmailLabel.SizeF = New System.Drawing.SizeF(95.95975!, 18.99999!)
            Me.LabelHeaderOrderNumber_EmailLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumber_EmailLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumber_EmailLabel.Text = "Email:"
            Me.LabelHeaderOrderNumber_EmailLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrTableCampaignMarket
            '
            Me.XrTableCampaignMarket.LocationFloat = New DevExpress.Utils.PointFloat(0.0001271566!, 119.0!)
            Me.XrTableCampaignMarket.Name = "XrTableCampaignMarket"
            Me.XrTableCampaignMarket.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowCampaignMarket_Campaign, Me.XrTableRowCampaignMarket_Market})
            Me.XrTableCampaignMarket.SizeF = New System.Drawing.SizeF(366.6598!, 37.0!)
            '
            'XrTableRowCampaignMarket_Campaign
            '
            Me.XrTableRowCampaignMarket_Campaign.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCampaignMarket_CampaignLabel, Me.XrTableCampaignMarket_Campaign})
            Me.XrTableRowCampaignMarket_Campaign.Name = "XrTableRowCampaignMarket_Campaign"
            Me.XrTableRowCampaignMarket_Campaign.Weight = 1.0R
            '
            'XrTableCampaignMarket_CampaignLabel
            '
            Me.XrTableCampaignMarket_CampaignLabel.CanShrink = True
            Me.XrTableCampaignMarket_CampaignLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCampaignMarket_CampaignLabel.Name = "XrTableCampaignMarket_CampaignLabel"
            Me.XrTableCampaignMarket_CampaignLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCampaignMarket_CampaignLabel.StylePriority.UseFont = False
            Me.XrTableCampaignMarket_CampaignLabel.StylePriority.UsePadding = False
            Me.XrTableCampaignMarket_CampaignLabel.Text = "Campaign:"
            Me.XrTableCampaignMarket_CampaignLabel.Weight = 0.38561170244682386R
            '
            'XrTableCampaignMarket_Campaign
            '
            Me.XrTableCampaignMarket_Campaign.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CampaignName")})
            Me.XrTableCampaignMarket_Campaign.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrTableCampaignMarket_Campaign.Name = "XrTableCampaignMarket_Campaign"
            Me.XrTableCampaignMarket_Campaign.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCampaignMarket_Campaign.StylePriority.UseFont = False
            Me.XrTableCampaignMarket_Campaign.StylePriority.UsePadding = False
            Me.XrTableCampaignMarket_Campaign.StylePriority.UseTextAlignment = False
            Me.XrTableCampaignMarket_Campaign.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrTableCampaignMarket_Campaign.Weight = 1.3111187864648162R
            '
            'XrTableRowCampaignMarket_Market
            '
            Me.XrTableRowCampaignMarket_Market.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCampaignMarket_MarketLabel, Me.XrTableCampaignMarket_Market})
            Me.XrTableRowCampaignMarket_Market.Name = "XrTableRowCampaignMarket_Market"
            Me.XrTableRowCampaignMarket_Market.Weight = 1.0R
            '
            'XrTableCampaignMarket_MarketLabel
            '
            Me.XrTableCampaignMarket_MarketLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCampaignMarket_MarketLabel.Name = "XrTableCampaignMarket_MarketLabel"
            Me.XrTableCampaignMarket_MarketLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCampaignMarket_MarketLabel.StylePriority.UseFont = False
            Me.XrTableCampaignMarket_MarketLabel.StylePriority.UsePadding = False
            Me.XrTableCampaignMarket_MarketLabel.Text = "Market:"
            Me.XrTableCampaignMarket_MarketLabel.Weight = 0.24370293618403896R
            '
            'XrTableCampaignMarket_Market
            '
            Me.XrTableCampaignMarket_Market.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "MarketName")})
            Me.XrTableCampaignMarket_Market.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.XrTableCampaignMarket_Market.Name = "XrTableCampaignMarket_Market"
            Me.XrTableCampaignMarket_Market.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCampaignMarket_Market.StylePriority.UseFont = False
            Me.XrTableCampaignMarket_Market.StylePriority.UsePadding = False
            Me.XrTableCampaignMarket_Market.Weight = 0.82861495575669353R
            '
            'XrPictureBoxHeaderLogo
            '
            Me.XrPictureBoxHeaderLogo.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
            Me.XrPictureBoxHeaderLogo.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrPictureBoxHeaderLogo.Name = "XrPictureBoxHeaderLogo"
            Me.XrPictureBoxHeaderLogo.SizeF = New System.Drawing.SizeF(750.0!, 150.0!)
            '
            'LineGroupHeaderOrderHeaderTop_LocationHeader
            '
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.BorderColor = System.Drawing.Color.Black
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.BorderWidth = 1.0!
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.ForeColor = System.Drawing.Color.Black
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.LocationFloat = New DevExpress.Utils.PointFloat(0!, 68.99999!)
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.Name = "LineGroupHeaderOrderHeaderTop_LocationHeader"
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.SizeF = New System.Drawing.SizeF(749.9999!, 7.499992!)
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.StylePriority.UseBorderColor = False
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.StylePriority.UseBorderWidth = False
            Me.LineGroupHeaderOrderHeaderTop_LocationHeader.StylePriority.UseForeColor = False
            '
            'LabelGroupHeaderOrderNumberTop_LocationHeader
            '
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.CanGrow = False
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.CanShrink = True
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LocationHeader")})
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.Name = "LabelGroupHeaderOrderNumberTop_LocationHeader"
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.SizeF = New System.Drawing.SizeF(749.9998!, 68.99999!)
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.StylePriority.UseFont = False
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.StylePriority.UsePadding = False
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.StylePriority.UseTextAlignment = False
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.Text = "LabelGroupHeaderOrderNumberTop_LocationHeader"
            Me.LabelGroupHeaderOrderNumberTop_LocationHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter
            '
            'LabelHeaderOrderNumberTop_OrderLabel
            '
            Me.LabelHeaderOrderNumberTop_OrderLabel.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderLabel")})
            Me.LabelHeaderOrderNumberTop_OrderLabel.Font = New System.Drawing.Font("Arial", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeaderOrderNumberTop_OrderLabel.LocationFloat = New DevExpress.Utils.PointFloat(0!, 76.5!)
            Me.LabelHeaderOrderNumberTop_OrderLabel.Name = "LabelHeaderOrderNumberTop_OrderLabel"
            Me.LabelHeaderOrderNumberTop_OrderLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelHeaderOrderNumberTop_OrderLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelHeaderOrderNumberTop_OrderLabel.SizeF = New System.Drawing.SizeF(749.9998!, 25.0!)
            Me.LabelHeaderOrderNumberTop_OrderLabel.StylePriority.UseFont = False
            Me.LabelHeaderOrderNumberTop_OrderLabel.StylePriority.UsePadding = False
            Me.LabelHeaderOrderNumberTop_OrderLabel.StylePriority.UseTextAlignment = False
            Me.LabelHeaderOrderNumberTop_OrderLabel.Text = "LabelHeaderOrderNumberTop_OrderLabel"
            Me.LabelHeaderOrderNumberTop_OrderLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'PageFooter
            '
            Me.PageFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageFooter_LocationFooter})
            Me.PageFooter.HeightF = 33.33!
            Me.PageFooter.Name = "PageFooter"
            '
            'LabelPageFooter_LocationFooter
            '
            Me.LabelPageFooter_LocationFooter.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LocationFooter")})
            Me.LabelPageFooter_LocationFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.LabelPageFooter_LocationFooter.LocationFloat = New DevExpress.Utils.PointFloat(0.0001430511!, 14.33!)
            Me.LabelPageFooter_LocationFooter.Name = "LabelPageFooter_LocationFooter"
            Me.LabelPageFooter_LocationFooter.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelPageFooter_LocationFooter.SizeF = New System.Drawing.SizeF(749.9998!, 19.0!)
            Me.LabelPageFooter_LocationFooter.StylePriority.UseFont = False
            Me.LabelPageFooter_LocationFooter.StylePriority.UsePadding = False
            Me.LabelPageFooter_LocationFooter.StylePriority.UseTextAlignment = False
            Me.LabelPageFooter_LocationFooter.Text = "LabelPageFooter_LocationFooter"
            Me.LabelPageFooter_LocationFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter
            '
            'GroupFooterOrderNumber
            '
            Me.GroupFooterOrderNumber.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterOrderCommentTop, Me.LabelGroupFooterOrderNumber_AgencyCommentTop, Me.LabelGroupFooterOrderNumber_OrderCommentTop, Me.GroupFooterOrderNumberSubreport_ChargeToSubReport, Me.LabelGroupFooterOrderNumber_LineTotalActual, Me.LabelGroupFooterOrderNumber_AgencyCommissionSum, Me.LabelGroupFooterOrderNumber_VendorTaxSum, Me.LabelGroupFooterOrderNumber_NetChargeSum, Me.LabelGroupFooterOrderNumber_NetChargeSumLabel, Me.LabelGroupFooterOrderNumber_DiscountSumLabel, Me.LabelGroupFooterOrderNumber_DiscountSum, Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel, Me.LabelGroupFooterOrderNumber_VendorTaxLabel, Me.LabelFooterOrderNumber_AmountSubtotal, Me.LabelFooterOrderNumber_SubtotalLabel, Me.LabelGroupFooterOrderNumber_OrderTotalLabel, Me.GroupFooterOrderNumberSubreport_VendorShippingSubReport, Me.LabelGroupFooterOrderNumber_ShipToLabel, Me.LabelGroupFooterOrderNumber_Box})
            Me.GroupFooterOrderNumber.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.GroupFooterOrderNumber.HeightF = 221.3504!
            Me.GroupFooterOrderNumber.Level = 2
            Me.GroupFooterOrderNumber.Name = "GroupFooterOrderNumber"
            Me.GroupFooterOrderNumber.StylePriority.UseFont = False
            Me.GroupFooterOrderNumber.SubBands.AddRange(New DevExpress.XtraReports.UI.SubBand() {Me.SubBandSignatures, Me.SubBandCommentsBelowSignatures})
            '
            'LabelGroupFooterOrderCommentTop
            '
            Me.LabelGroupFooterOrderCommentTop.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderCommentTop.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderCommentTop.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderCommentTop.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderCommentTop.CanGrow = False
            Me.LabelGroupFooterOrderCommentTop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderCommentTop.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderCommentTop.LocationFloat = New DevExpress.Utils.PointFloat(52.07669!, 170.3749!)
            Me.LabelGroupFooterOrderCommentTop.Name = "LabelGroupFooterOrderCommentTop"
            Me.LabelGroupFooterOrderCommentTop.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderCommentTop.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderCommentTop.SizeF = New System.Drawing.SizeF(105.1663!, 17.00001!)
            Me.LabelGroupFooterOrderCommentTop.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderCommentTop.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderCommentTop.Text = "Order Comment:"
            Me.LabelGroupFooterOrderCommentTop.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupFooterOrderNumber_AgencyCommentTop
            '
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgencyComment")})
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.LocationFloat = New DevExpress.Utils.PointFloat(52.07668!, 202.3504!)
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.Multiline = True
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.Name = "LabelGroupFooterOrderNumber_AgencyCommentTop"
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.SizeF = New System.Drawing.SizeF(650.0!, 19.0!)
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_AgencyCommentTop.Text = "LabelGroupFooterOrderNumber_AgencyComment"
            '
            'LabelGroupFooterOrderNumber_OrderCommentTop
            '
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderComment")})
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.LocationFloat = New DevExpress.Utils.PointFloat(157.243!, 170.375!)
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.Multiline = True
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.Name = "LabelGroupFooterOrderNumber_OrderCommentTop"
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.SizeF = New System.Drawing.SizeF(544.8337!, 16.99994!)
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_OrderCommentTop.Text = "LabelGroupFooterOrderNumber_OrderComment"
            '
            'GroupFooterOrderNumberSubreport_ChargeToSubReport
            '
            Me.GroupFooterOrderNumberSubreport_ChargeToSubReport.CanShrink = True
            Me.GroupFooterOrderNumberSubreport_ChargeToSubReport.LocationFloat = New DevExpress.Utils.PointFloat(53.07706!, 144.7915!)
            Me.GroupFooterOrderNumberSubreport_ChargeToSubReport.Name = "GroupFooterOrderNumberSubreport_ChargeToSubReport"
            Me.GroupFooterOrderNumberSubreport_ChargeToSubReport.ReportSource = New AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport()
            Me.GroupFooterOrderNumberSubreport_ChargeToSubReport.SizeF = New System.Drawing.SizeF(510.0!, 18.99998!)
            Me.GroupFooterOrderNumberSubreport_ChargeToSubReport.Visible = False
            '
            'LabelGroupFooterOrderNumber_LineTotalActual
            '
            Me.LabelGroupFooterOrderNumber_LineTotalActual.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_LineTotalActual.LocationFloat = New DevExpress.Utils.PointFloat(607.7138!, 114.7914!)
            Me.LabelGroupFooterOrderNumber_LineTotalActual.Name = "LabelGroupFooterOrderNumber_LineTotalActual"
            Me.LabelGroupFooterOrderNumber_LineTotalActual.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_LineTotalActual.SizeF = New System.Drawing.SizeF(130.7862!, 19.00002!)
            Me.LabelGroupFooterOrderNumber_LineTotalActual.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_LineTotalActual.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_LineTotalActual.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0:n2}"
            Me.LabelGroupFooterOrderNumber_LineTotalActual.Summary = XrSummary1
            Me.LabelGroupFooterOrderNumber_LineTotalActual.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_AgencyCommissionSum
            '
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.CanGrow = False
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.LocationFloat = New DevExpress.Utils.PointFloat(639.5002!, 75.99998!)
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.Name = "LabelGroupFooterOrderNumber_AgencyCommissionSum"
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.SizeF = New System.Drawing.SizeF(97.99988!, 19.00002!)
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_AgencyCommissionSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_VendorTaxSum
            '
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.CanGrow = False
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.LocationFloat = New DevExpress.Utils.PointFloat(639.5002!, 18.99999!)
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.Name = "LabelGroupFooterOrderNumber_VendorTaxSum"
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.SizeF = New System.Drawing.SizeF(97.99988!, 19.00002!)
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_VendorTaxSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_NetChargeSum
            '
            Me.LabelGroupFooterOrderNumber_NetChargeSum.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_NetChargeSum.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_NetChargeSum.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_NetChargeSum.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_NetChargeSum.CanGrow = False
            Me.LabelGroupFooterOrderNumber_NetChargeSum.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_NetChargeSum.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_NetChargeSum.LocationFloat = New DevExpress.Utils.PointFloat(639.5002!, 37.99998!)
            Me.LabelGroupFooterOrderNumber_NetChargeSum.Name = "LabelGroupFooterOrderNumber_NetChargeSum"
            Me.LabelGroupFooterOrderNumber_NetChargeSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_NetChargeSum.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_NetChargeSum.SizeF = New System.Drawing.SizeF(97.99988!, 19.00002!)
            Me.LabelGroupFooterOrderNumber_NetChargeSum.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_NetChargeSum.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_NetChargeSum.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_NetChargeSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_NetChargeSumLabel
            '
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.CanGrow = False
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.LocationFloat = New DevExpress.Utils.PointFloat(358.2502!, 37.99998!)
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.Name = "LabelGroupFooterOrderNumber_NetChargeSumLabel"
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.SizeF = New System.Drawing.SizeF(270.8332!, 18.99961!)
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_NetChargeSumLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_DiscountSumLabel
            '
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.CanGrow = False
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.LocationFloat = New DevExpress.Utils.PointFloat(358.2502!, 56.99959!)
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.Name = "LabelGroupFooterOrderNumber_DiscountSumLabel"
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.SizeF = New System.Drawing.SizeF(270.8336!, 19.00002!)
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_DiscountSumLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_DiscountSum
            '
            Me.LabelGroupFooterOrderNumber_DiscountSum.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_DiscountSum.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_DiscountSum.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_DiscountSum.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_DiscountSum.CanGrow = False
            Me.LabelGroupFooterOrderNumber_DiscountSum.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_DiscountSum.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_DiscountSum.LocationFloat = New DevExpress.Utils.PointFloat(639.5001!, 56.99997!)
            Me.LabelGroupFooterOrderNumber_DiscountSum.Name = "LabelGroupFooterOrderNumber_DiscountSum"
            Me.LabelGroupFooterOrderNumber_DiscountSum.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_DiscountSum.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_DiscountSum.SizeF = New System.Drawing.SizeF(97.99988!, 19.00002!)
            Me.LabelGroupFooterOrderNumber_DiscountSum.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_DiscountSum.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_DiscountSum.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_DiscountSum.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_AgencyCommissionLabel
            '
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.CanGrow = False
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.LocationFloat = New DevExpress.Utils.PointFloat(358.2502!, 75.99945!)
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.Name = "LabelGroupFooterOrderNumber_AgencyCommissionLabel"
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.SizeF = New System.Drawing.SizeF(270.8337!, 19.0!)
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.Text = "Agency Commission:"
            Me.LabelGroupFooterOrderNumber_AgencyCommissionLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_VendorTaxLabel
            '
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.CanGrow = False
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.LocationFloat = New DevExpress.Utils.PointFloat(539.5832!, 18.99999!)
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.Name = "LabelGroupFooterOrderNumber_VendorTaxLabel"
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.SizeF = New System.Drawing.SizeF(89.50018!, 19.0!)
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.Text = "Sales Tax:"
            Me.LabelGroupFooterOrderNumber_VendorTaxLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelFooterOrderNumber_AmountSubtotal
            '
            Me.LabelFooterOrderNumber_AmountSubtotal.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Cost")})
            Me.LabelFooterOrderNumber_AmountSubtotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelFooterOrderNumber_AmountSubtotal.LocationFloat = New DevExpress.Utils.PointFloat(639.5002!, 0!)
            Me.LabelFooterOrderNumber_AmountSubtotal.Name = "LabelFooterOrderNumber_AmountSubtotal"
            Me.LabelFooterOrderNumber_AmountSubtotal.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelFooterOrderNumber_AmountSubtotal.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelFooterOrderNumber_AmountSubtotal.SizeF = New System.Drawing.SizeF(97.99976!, 19.0!)
            Me.LabelFooterOrderNumber_AmountSubtotal.StylePriority.UseFont = False
            Me.LabelFooterOrderNumber_AmountSubtotal.StylePriority.UsePadding = False
            Me.LabelFooterOrderNumber_AmountSubtotal.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0:n2}"
            XrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Report
            Me.LabelFooterOrderNumber_AmountSubtotal.Summary = XrSummary2
            Me.LabelFooterOrderNumber_AmountSubtotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            Me.LabelFooterOrderNumber_AmountSubtotal.TextFormatString = "{0:n2}"
            '
            'LabelFooterOrderNumber_SubtotalLabel
            '
            Me.LabelFooterOrderNumber_SubtotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelFooterOrderNumber_SubtotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelFooterOrderNumber_SubtotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelFooterOrderNumber_SubtotalLabel.BorderWidth = 1.0!
            Me.LabelFooterOrderNumber_SubtotalLabel.CanGrow = False
            Me.LabelFooterOrderNumber_SubtotalLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelFooterOrderNumber_SubtotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelFooterOrderNumber_SubtotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(539.5832!, 0!)
            Me.LabelFooterOrderNumber_SubtotalLabel.Name = "LabelFooterOrderNumber_SubtotalLabel"
            Me.LabelFooterOrderNumber_SubtotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelFooterOrderNumber_SubtotalLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelFooterOrderNumber_SubtotalLabel.SizeF = New System.Drawing.SizeF(89.50018!, 19.0!)
            Me.LabelFooterOrderNumber_SubtotalLabel.StylePriority.UseFont = False
            Me.LabelFooterOrderNumber_SubtotalLabel.StylePriority.UsePadding = False
            Me.LabelFooterOrderNumber_SubtotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelFooterOrderNumber_SubtotalLabel.Text = "Sub-Total:"
            Me.LabelFooterOrderNumber_SubtotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'LabelGroupFooterOrderNumber_OrderTotalLabel
            '
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.CanGrow = False
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.LocationFloat = New DevExpress.Utils.PointFloat(496.8304!, 114.7914!)
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.Name = "LabelGroupFooterOrderNumber_OrderTotalLabel"
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.SizeF = New System.Drawing.SizeF(85.33353!, 19.00002!)
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.Text = "Order Total:"
            Me.LabelGroupFooterOrderNumber_OrderTotalLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'GroupFooterOrderNumberSubreport_VendorShippingSubReport
            '
            Me.GroupFooterOrderNumberSubreport_VendorShippingSubReport.CanShrink = True
            Me.GroupFooterOrderNumberSubreport_VendorShippingSubReport.LocationFloat = New DevExpress.Utils.PointFloat(127.9524!, 106.7916!)
            Me.GroupFooterOrderNumberSubreport_VendorShippingSubReport.Name = "GroupFooterOrderNumberSubreport_VendorShippingSubReport"
            Me.GroupFooterOrderNumberSubreport_VendorShippingSubReport.ReportSource = New AdvantageFramework.Reporting.Reports.MediaManager.VendorShippingSubReport()
            Me.GroupFooterOrderNumberSubreport_VendorShippingSubReport.SizeF = New System.Drawing.SizeF(326.0!, 18.99998!)
            '
            'LabelGroupFooterOrderNumber_ShipToLabel
            '
            Me.LabelGroupFooterOrderNumber_ShipToLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_ShipToLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_ShipToLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_ShipToLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_ShipToLabel.CanGrow = False
            Me.LabelGroupFooterOrderNumber_ShipToLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_ShipToLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_ShipToLabel.LocationFloat = New DevExpress.Utils.PointFloat(53.07706!, 106.7916!)
            Me.LabelGroupFooterOrderNumber_ShipToLabel.Name = "LabelGroupFooterOrderNumber_ShipToLabel"
            Me.LabelGroupFooterOrderNumber_ShipToLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_ShipToLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_ShipToLabel.SizeF = New System.Drawing.SizeF(73.87515!, 19.0!)
            Me.LabelGroupFooterOrderNumber_ShipToLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_ShipToLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_ShipToLabel.Text = "Ship To:"
            Me.LabelGroupFooterOrderNumber_ShipToLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupFooterOrderNumber_Box
            '
            Me.LabelGroupFooterOrderNumber_Box.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_Box.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_Box.Borders = CType((((DevExpress.XtraPrinting.BorderSide.Left Or DevExpress.XtraPrinting.BorderSide.Top) _
            Or DevExpress.XtraPrinting.BorderSide.Right) _
            Or DevExpress.XtraPrinting.BorderSide.Bottom), DevExpress.XtraPrinting.BorderSide)
            Me.LabelGroupFooterOrderNumber_Box.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_Box.CanGrow = False
            Me.LabelGroupFooterOrderNumber_Box.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_Box.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_Box.LocationFloat = New DevExpress.Utils.PointFloat(471.8752!, 106.7916!)
            Me.LabelGroupFooterOrderNumber_Box.Name = "LabelGroupFooterOrderNumber_Box"
            Me.LabelGroupFooterOrderNumber_Box.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_Box.SizeF = New System.Drawing.SizeF(278.125!, 34.00012!)
            Me.LabelGroupFooterOrderNumber_Box.StylePriority.UseBorders = False
            Me.LabelGroupFooterOrderNumber_Box.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_Box.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_Box.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'SubBandSignatures
            '
            Me.SubBandSignatures.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterOrderNumber_PrintDate, Me.LineGroupFooterOrderNumber_VendorAcceptanceDate, Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate, Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate, Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate, Me.LineGroupFooterOrderNumber_VendorAcceptance, Me.LineGroupFooterOrderNumber_AgencyAuthorization, Me.LabelGroupFooterOrderNumber_VendorAcceptance, Me.LabelGroupFooterOrderNumber_AgencyAuthorization, Me.XrPictureBoxSignature})
            Me.SubBandSignatures.HeightF = 114.34!
            Me.SubBandSignatures.Name = "SubBandSignatures"
            '
            'LabelGroupFooterOrderNumber_PrintDate
            '
            Me.LabelGroupFooterOrderNumber_PrintDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PrintDate", "{0:d}")})
            Me.LabelGroupFooterOrderNumber_PrintDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelGroupFooterOrderNumber_PrintDate.LocationFloat = New DevExpress.Utils.PointFloat(590.7099!, 56.00001!)
            Me.LabelGroupFooterOrderNumber_PrintDate.Name = "LabelGroupFooterOrderNumber_PrintDate"
            Me.LabelGroupFooterOrderNumber_PrintDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_PrintDate.SizeF = New System.Drawing.SizeF(100.0!, 18.99998!)
            Me.LabelGroupFooterOrderNumber_PrintDate.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_PrintDate.StylePriority.UsePadding = False
            '
            'LineGroupFooterOrderNumber_VendorAcceptanceDate
            '
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.BorderColor = System.Drawing.Color.Black
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.BorderWidth = 1.0!
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.ForeColor = System.Drawing.Color.Black
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.LocationFloat = New DevExpress.Utils.PointFloat(577.1683!, 106.84!)
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.Name = "LineGroupFooterOrderNumber_VendorAcceptanceDate"
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.SizeF = New System.Drawing.SizeF(129.17!, 7.5!)
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.StylePriority.UseBorderColor = False
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.StylePriority.UseBorderWidth = False
            Me.LineGroupFooterOrderNumber_VendorAcceptanceDate.StylePriority.UseForeColor = False
            '
            'LineGroupFooterOrderNumber_AgencyAuthorizationDate
            '
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.BorderColor = System.Drawing.Color.Black
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.BorderWidth = 1.0!
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.ForeColor = System.Drawing.Color.Black
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.LocationFloat = New DevExpress.Utils.PointFloat(577.1683!, 75.0!)
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.Name = "LineGroupFooterOrderNumber_AgencyAuthorizationDate"
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.SizeF = New System.Drawing.SizeF(129.17!, 7.5!)
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.StylePriority.UseBorderColor = False
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.StylePriority.UseBorderWidth = False
            Me.LineGroupFooterOrderNumber_AgencyAuthorizationDate.StylePriority.UseForeColor = False
            '
            'LabelGroupFooterOrderNumber_AgencyAuthorizationDate
            '
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.CanGrow = False
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.KeepTogether = True
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.LocationFloat = New DevExpress.Utils.PointFloat(521.96!, 62.00002!)
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.Name = "LabelGroupFooterOrderNumber_AgencyAuthorizationDate"
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.SizeF = New System.Drawing.SizeF(44.71191!, 19.0!)
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.Text = "Date:"
            Me.LabelGroupFooterOrderNumber_AgencyAuthorizationDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelGroupFooterOrderNumber_VendorAcceptanceDate
            '
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.CanGrow = False
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.KeepTogether = True
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.LocationFloat = New DevExpress.Utils.PointFloat(521.96!, 95.33984!)
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.Name = "LabelGroupFooterOrderNumber_VendorAcceptanceDate"
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.SizeF = New System.Drawing.SizeF(44.71191!, 19.0!)
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.Text = "Date:"
            Me.LabelGroupFooterOrderNumber_VendorAcceptanceDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LineGroupFooterOrderNumber_VendorAcceptance
            '
            Me.LineGroupFooterOrderNumber_VendorAcceptance.BorderColor = System.Drawing.Color.Black
            Me.LineGroupFooterOrderNumber_VendorAcceptance.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooterOrderNumber_VendorAcceptance.BorderWidth = 1.0!
            Me.LineGroupFooterOrderNumber_VendorAcceptance.ForeColor = System.Drawing.Color.Black
            Me.LineGroupFooterOrderNumber_VendorAcceptance.LocationFloat = New DevExpress.Utils.PointFloat(201.1298!, 106.84!)
            Me.LineGroupFooterOrderNumber_VendorAcceptance.Name = "LineGroupFooterOrderNumber_VendorAcceptance"
            Me.LineGroupFooterOrderNumber_VendorAcceptance.SizeF = New System.Drawing.SizeF(306.25!, 7.5!)
            Me.LineGroupFooterOrderNumber_VendorAcceptance.StylePriority.UseBorderColor = False
            Me.LineGroupFooterOrderNumber_VendorAcceptance.StylePriority.UseBorderWidth = False
            Me.LineGroupFooterOrderNumber_VendorAcceptance.StylePriority.UseForeColor = False
            '
            'LineGroupFooterOrderNumber_AgencyAuthorization
            '
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.BorderColor = System.Drawing.Color.Black
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.BorderWidth = 1.0!
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.ForeColor = System.Drawing.Color.Black
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.LocationFloat = New DevExpress.Utils.PointFloat(201.1298!, 79.99992!)
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.Name = "LineGroupFooterOrderNumber_AgencyAuthorization"
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.SizeF = New System.Drawing.SizeF(306.25!, 7.5!)
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.StylePriority.UseBorderColor = False
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.StylePriority.UseBorderWidth = False
            Me.LineGroupFooterOrderNumber_AgencyAuthorization.StylePriority.UseForeColor = False
            '
            'LabelGroupFooterOrderNumber_VendorAcceptance
            '
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.CanGrow = False
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.KeepTogether = True
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.LocationFloat = New DevExpress.Utils.PointFloat(54.07682!, 95.33984!)
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.Name = "LabelGroupFooterOrderNumber_VendorAcceptance"
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.SizeF = New System.Drawing.SizeF(137.4168!, 19.0!)
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.Text = "Vendor Acceptance:"
            Me.LabelGroupFooterOrderNumber_VendorAcceptance.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelGroupFooterOrderNumber_AgencyAuthorization
            '
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.CanGrow = False
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.KeepTogether = True
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.LocationFloat = New DevExpress.Utils.PointFloat(54.07682!, 62.00002!)
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.Name = "LabelGroupFooterOrderNumber_AgencyAuthorization"
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.SizeF = New System.Drawing.SizeF(137.4168!, 19.0!)
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.Text = "Agency Authorization:"
            Me.LabelGroupFooterOrderNumber_AgencyAuthorization.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'XrPictureBoxSignature
            '
            Me.XrPictureBoxSignature.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter
            Me.XrPictureBoxSignature.LocationFloat = New DevExpress.Utils.PointFloat(201.1298!, 0!)
            Me.XrPictureBoxSignature.Name = "XrPictureBoxSignature"
            Me.XrPictureBoxSignature.SizeF = New System.Drawing.SizeF(275.0!, 75.0!)
            '
            'SubBandCommentsBelowSignatures
            '
            Me.SubBandCommentsBelowSignatures.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterOrderComment, Me.LabelGroupFooterOrderNumber_AgencyComment, Me.LabelGroupFooterOrderNumber_OrderComment})
            Me.SubBandCommentsBelowSignatures.HeightF = 49.99989!
            Me.SubBandCommentsBelowSignatures.Name = "SubBandCommentsBelowSignatures"
            '
            'LabelGroupFooterOrderComment
            '
            Me.LabelGroupFooterOrderComment.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterOrderComment.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderComment.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterOrderComment.BorderWidth = 1.0!
            Me.LabelGroupFooterOrderComment.CanGrow = False
            Me.LabelGroupFooterOrderComment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderComment.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterOrderComment.LocationFloat = New DevExpress.Utils.PointFloat(52.07668!, 0!)
            Me.LabelGroupFooterOrderComment.Name = "LabelGroupFooterOrderComment"
            Me.LabelGroupFooterOrderComment.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderComment.SizeF = New System.Drawing.SizeF(105.1663!, 17.00001!)
            Me.LabelGroupFooterOrderComment.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderComment.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterOrderComment.Text = "Order Comment:"
            Me.LabelGroupFooterOrderComment.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupFooterOrderNumber_AgencyComment
            '
            Me.LabelGroupFooterOrderNumber_AgencyComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AgencyComment")})
            Me.LabelGroupFooterOrderNumber_AgencyComment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterOrderNumber_AgencyComment.LocationFloat = New DevExpress.Utils.PointFloat(52.07669!, 30.99988!)
            Me.LabelGroupFooterOrderNumber_AgencyComment.Multiline = True
            Me.LabelGroupFooterOrderNumber_AgencyComment.Name = "LabelGroupFooterOrderNumber_AgencyComment"
            Me.LabelGroupFooterOrderNumber_AgencyComment.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_AgencyComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_AgencyComment.SizeF = New System.Drawing.SizeF(650.0!, 19.0!)
            Me.LabelGroupFooterOrderNumber_AgencyComment.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_AgencyComment.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_AgencyComment.Text = "LabelGroupFooterOrderNumber_AgencyComment"
            '
            'LabelGroupFooterOrderNumber_OrderComment
            '
            Me.LabelGroupFooterOrderNumber_OrderComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderComment")})
            Me.LabelGroupFooterOrderNumber_OrderComment.Font = New System.Drawing.Font("Arial", 9.0!)
            Me.LabelGroupFooterOrderNumber_OrderComment.LocationFloat = New DevExpress.Utils.PointFloat(157.243!, 0!)
            Me.LabelGroupFooterOrderNumber_OrderComment.Multiline = True
            Me.LabelGroupFooterOrderNumber_OrderComment.Name = "LabelGroupFooterOrderNumber_OrderComment"
            Me.LabelGroupFooterOrderNumber_OrderComment.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterOrderNumber_OrderComment.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterOrderNumber_OrderComment.SizeF = New System.Drawing.SizeF(544.8337!, 16.99991!)
            Me.LabelGroupFooterOrderNumber_OrderComment.StylePriority.UseFont = False
            Me.LabelGroupFooterOrderNumber_OrderComment.StylePriority.UsePadding = False
            Me.LabelGroupFooterOrderNumber_OrderComment.Text = "LabelGroupFooterOrderNumber_OrderComment"
            '
            'GroupHeaderEveryPage2
            '
            Me.GroupHeaderEveryPage2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableHeaderLeft, Me.XrTableCampaignMarket, Me.LabelHeaderOrderNumber_DateLabel, Me.LabelHeaderOrderNumber_BuyerLabel, Me.LabelHeaderOrderNumber_PageLabel, Me.LabelHeaderOrderNumber_OrderNumberLabel, Me.LabelHeaderOrderNumber_Buyer, Me.LabelHeaderOrderNumber_Email, Me.LabelHeaderOrderNumber_OrderNumber, Me.LabelHeaderOrderNumber_EmailLabel, Me.LabelHeaderOrderNumber_PrintDate, Me.PageInfo_Pages, Me.LabelHeaderOrderNumber_VenRepLabel, Me.LabelHeaderOrderNumber_VendorCode, Me.LabelHeaderOrderNumber_OrderDescription, Me.LabelHeaderOrderNumber_OrderDescriptionLabel, Me.LineGroupHeaderOrderHeader_Top})
            Me.GroupHeaderEveryPage2.HeightF = 163.5!
            Me.GroupHeaderEveryPage2.Level = 2
            Me.GroupHeaderEveryPage2.Name = "GroupHeaderEveryPage2"
            Me.GroupHeaderEveryPage2.RepeatEveryPage = True
            '
            'XrTableHeaderLeft
            '
            Me.XrTableHeaderLeft.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 0!)
            Me.XrTableHeaderLeft.Name = "XrTableHeaderLeft"
            Me.XrTableHeaderLeft.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowLeftStation, Me.XrTableRowLeftClient, Me.XrTableRow1, Me.XrTableRow2, Me.XrTableRow3, Me.XrTableRowLeftDivision, Me.XrTableRowLeftProduct})
            Me.XrTableHeaderLeft.SizeF = New System.Drawing.SizeF(366.66!, 119.0!)
            '
            'XrTableRowLeftStation
            '
            Me.XrTableRowLeftStation.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCell2, Me.XrTableCell3})
            Me.XrTableRowLeftStation.Name = "XrTableRowLeftStation"
            Me.XrTableRowLeftStation.Weight = 1.0R
            '
            'XrTableCell2
            '
            Me.XrTableCell2.CanShrink = True
            Me.XrTableCell2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCell2.Name = "XrTableCell2"
            Me.XrTableCell2.StylePriority.UseFont = False
            Me.XrTableCell2.Text = "Publisher:"
            Me.XrTableCell2.Weight = 0.6771465005371019R
            '
            'XrTableCell3
            '
            Me.XrTableCell3.CanShrink = True
            Me.XrTableCell3.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "VendorName")})
            Me.XrTableCell3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell3.Multiline = True
            Me.XrTableCell3.Name = "XrTableCell3"
            Me.XrTableCell3.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCell3.StylePriority.UseFont = False
            Me.XrTableCell3.StylePriority.UsePadding = False
            Me.XrTableCell3.Weight = 2.3023669238628721R
            '
            'XrTableRowLeftClient
            '
            Me.XrTableRowLeftClient.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellClient_Client, Me.XrTableCell9})
            Me.XrTableRowLeftClient.Name = "XrTableRowLeftClient"
            Me.XrTableRowLeftClient.Weight = 1.0R
            '
            'TableCellClient_Client
            '
            Me.TableCellClient_Client.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.TableCellClient_Client.Name = "TableCellClient_Client"
            Me.TableCellClient_Client.StylePriority.UseFont = False
            Me.TableCellClient_Client.Text = "Client:"
            Me.TableCellClient_Client.Weight = 0.6771465005371019R
            '
            'XrTableCell9
            '
            Me.XrTableCell9.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientName")})
            Me.XrTableCell9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell9.Name = "XrTableCell9"
            Me.XrTableCell9.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCell9.StylePriority.UseFont = False
            Me.XrTableCell9.StylePriority.UsePadding = False
            Me.XrTableCell9.Weight = 2.3023669238628721R
            '
            'XrTableRow1
            '
            Me.XrTableRow1.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellClient_Address1, Me.TableCellClient_Address1Value})
            Me.XrTableRow1.Name = "XrTableRow1"
            Me.XrTableRow1.Weight = 1.0R
            '
            'TableCellClient_Address1
            '
            Me.TableCellClient_Address1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.TableCellClient_Address1.Multiline = True
            Me.TableCellClient_Address1.Name = "TableCellClient_Address1"
            Me.TableCellClient_Address1.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.TableCellClient_Address1.StylePriority.UseFont = False
            Me.TableCellClient_Address1.Text = "Address1:"
            Me.TableCellClient_Address1.Weight = 0.6771465005371019R
            '
            'TableCellClient_Address1Value
            '
            Me.TableCellClient_Address1Value.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientAddress1")})
            Me.TableCellClient_Address1Value.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TableCellClient_Address1Value.Multiline = True
            Me.TableCellClient_Address1Value.Name = "TableCellClient_Address1Value"
            Me.TableCellClient_Address1Value.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TableCellClient_Address1Value.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.TableCellClient_Address1Value.StylePriority.UseFont = False
            Me.TableCellClient_Address1Value.StylePriority.UsePadding = False
            Me.TableCellClient_Address1Value.Weight = 2.3023669238628721R
            '
            'XrTableRow2
            '
            Me.XrTableRow2.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellClient_Address2, Me.TableCellClient_Address2Value})
            Me.XrTableRow2.Name = "XrTableRow2"
            Me.XrTableRow2.Weight = 1.0R
            '
            'TableCellClient_Address2
            '
            Me.TableCellClient_Address2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.TableCellClient_Address2.Multiline = True
            Me.TableCellClient_Address2.Name = "TableCellClient_Address2"
            Me.TableCellClient_Address2.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.TableCellClient_Address2.StylePriority.UseFont = False
            Me.TableCellClient_Address2.Text = "Address2:"
            Me.TableCellClient_Address2.Weight = 0.6771465005371019R
            '
            'TableCellClient_Address2Value
            '
            Me.TableCellClient_Address2Value.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientAddress2")})
            Me.TableCellClient_Address2Value.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TableCellClient_Address2Value.Multiline = True
            Me.TableCellClient_Address2Value.Name = "TableCellClient_Address2Value"
            Me.TableCellClient_Address2Value.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TableCellClient_Address2Value.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.TableCellClient_Address2Value.StylePriority.UseFont = False
            Me.TableCellClient_Address2Value.StylePriority.UsePadding = False
            Me.TableCellClient_Address2Value.Weight = 2.3023669238628721R
            '
            'XrTableRow3
            '
            Me.XrTableRow3.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellClient_CityStateZip, Me.TableCellClient_CityStateZipValue})
            Me.XrTableRow3.Name = "XrTableRow3"
            Me.XrTableRow3.Weight = 1.0R
            '
            'TableCellClient_CityStateZip
            '
            Me.TableCellClient_CityStateZip.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.TableCellClient_CityStateZip.Multiline = True
            Me.TableCellClient_CityStateZip.Name = "TableCellClient_CityStateZip"
            Me.TableCellClient_CityStateZip.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.TableCellClient_CityStateZip.StylePriority.UseFont = False
            Me.TableCellClient_CityStateZip.Text = "CSZ:"
            Me.TableCellClient_CityStateZip.Weight = 0.6771465005371019R
            '
            'TableCellClient_CityStateZipValue
            '
            Me.TableCellClient_CityStateZipValue.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientCSZ")})
            Me.TableCellClient_CityStateZipValue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.TableCellClient_CityStateZipValue.Multiline = True
            Me.TableCellClient_CityStateZipValue.Name = "TableCellClient_CityStateZipValue"
            Me.TableCellClient_CityStateZipValue.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TableCellClient_CityStateZipValue.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.TableCellClient_CityStateZipValue.StylePriority.UseFont = False
            Me.TableCellClient_CityStateZipValue.StylePriority.UsePadding = False
            Me.TableCellClient_CityStateZipValue.Weight = 2.3023669238628721R
            '
            'XrTableRowLeftDivision
            '
            Me.XrTableRowLeftDivision.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellClient_Division, Me.XrTableCell7})
            Me.XrTableRowLeftDivision.Name = "XrTableRowLeftDivision"
            Me.XrTableRowLeftDivision.Weight = 1.0R
            '
            'TableCellClient_Division
            '
            Me.TableCellClient_Division.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.TableCellClient_Division.Name = "TableCellClient_Division"
            Me.TableCellClient_Division.StylePriority.UseFont = False
            Me.TableCellClient_Division.Text = "Division:"
            Me.TableCellClient_Division.Weight = 0.6771465005371019R
            '
            'XrTableCell7
            '
            Me.XrTableCell7.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionName")})
            Me.XrTableCell7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell7.Name = "XrTableCell7"
            Me.XrTableCell7.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCell7.StylePriority.UseFont = False
            Me.XrTableCell7.StylePriority.UsePadding = False
            Me.XrTableCell7.Weight = 2.3023669238628721R
            '
            'XrTableRowLeftProduct
            '
            Me.XrTableRowLeftProduct.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellClient_Product, Me.XrTableCell5})
            Me.XrTableRowLeftProduct.Name = "XrTableRowLeftProduct"
            Me.XrTableRowLeftProduct.Weight = 1.0R
            '
            'TableCellClient_Product
            '
            Me.TableCellClient_Product.CanShrink = True
            Me.TableCellClient_Product.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.TableCellClient_Product.Name = "TableCellClient_Product"
            Me.TableCellClient_Product.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.Suppress
            Me.TableCellClient_Product.StylePriority.UseFont = False
            Me.TableCellClient_Product.Text = "Product:"
            Me.TableCellClient_Product.Weight = 0.6771465005371019R
            '
            'XrTableCell5
            '
            Me.XrTableCell5.CanShrink = True
            Me.XrTableCell5.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductionDescription")})
            Me.XrTableCell5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCell5.Multiline = True
            Me.XrTableCell5.Name = "XrTableCell5"
            Me.XrTableCell5.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCell5.StylePriority.UseFont = False
            Me.XrTableCell5.StylePriority.UsePadding = False
            Me.XrTableCell5.Weight = 2.3023669238628721R
            '
            'GroupHeaderEveryPage
            '
            Me.GroupHeaderEveryPage.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupHeaderOrderNumberTop_LocationHeader, Me.LineGroupHeaderOrderHeaderTop_LocationHeader, Me.LabelHeaderOrderNumberTop_OrderLabel, Me.GroupHeaderOrderNumberTopSubreportVendorAddress, Me.GroupHeaderOrderNumberTopSubreportVendorRep2, Me.GroupHeaderOrderNumberTopSubreportVendorRep1})
            Me.GroupHeaderEveryPage.HeightF = 169.4583!
            Me.GroupHeaderEveryPage.Level = 3
            Me.GroupHeaderEveryPage.Name = "GroupHeaderEveryPage"
            Me.GroupHeaderEveryPage.RepeatEveryPage = True
            Me.GroupHeaderEveryPage.SubBands.AddRange(New DevExpress.XtraReports.UI.SubBand() {Me.SubBand1})
            '
            'GroupHeaderOrderNumberTopSubreportVendorAddress
            '
            Me.GroupHeaderOrderNumberTopSubreportVendorAddress.CanShrink = True
            Me.GroupHeaderOrderNumberTopSubreportVendorAddress.LocationFloat = New DevExpress.Utils.PointFloat(52.07672!, 107.5!)
            Me.GroupHeaderOrderNumberTopSubreportVendorAddress.Name = "GroupHeaderOrderNumberTopSubreportVendorAddress"
            Me.GroupHeaderOrderNumberTopSubreportVendorAddress.ReportSource = New AdvantageFramework.Reporting.Reports.MediaManager.VendorAddressSubReport()
            Me.GroupHeaderOrderNumberTopSubreportVendorAddress.SizeF = New System.Drawing.SizeF(326.0!, 61.95831!)
            '
            'GroupHeaderOrderNumberTopSubreportVendorRep2
            '
            Me.GroupHeaderOrderNumberTopSubreportVendorRep2.CanShrink = True
            Me.GroupHeaderOrderNumberTopSubreportVendorRep2.LocationFloat = New DevExpress.Utils.PointFloat(424.0!, 126.5!)
            Me.GroupHeaderOrderNumberTopSubreportVendorRep2.Name = "GroupHeaderOrderNumberTopSubreportVendorRep2"
            Me.GroupHeaderOrderNumberTopSubreportVendorRep2.ReportSource = New AdvantageFramework.Reporting.Reports.MediaManager.VendorRepSubReport()
            Me.GroupHeaderOrderNumberTopSubreportVendorRep2.SizeF = New System.Drawing.SizeF(326.0!, 18.99998!)
            '
            'GroupHeaderOrderNumberTopSubreportVendorRep1
            '
            Me.GroupHeaderOrderNumberTopSubreportVendorRep1.CanShrink = True
            Me.GroupHeaderOrderNumberTopSubreportVendorRep1.LocationFloat = New DevExpress.Utils.PointFloat(424.0!, 107.5!)
            Me.GroupHeaderOrderNumberTopSubreportVendorRep1.Name = "GroupHeaderOrderNumberTopSubreportVendorRep1"
            Me.GroupHeaderOrderNumberTopSubreportVendorRep1.ReportSource = New AdvantageFramework.Reporting.Reports.MediaManager.VendorRepSubReport()
            Me.GroupHeaderOrderNumberTopSubreportVendorRep1.SizeF = New System.Drawing.SizeF(326.0!, 18.99998!)
            '
            'SubBand1
            '
            Me.SubBand1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelSubBand1_ExtraSpaceByDesign})
            Me.SubBand1.HeightF = 18.99999!
            Me.SubBand1.Name = "SubBand1"
            '
            'LabelSubBand1_ExtraSpaceByDesign
            '
            Me.LabelSubBand1_ExtraSpaceByDesign.BackColor = System.Drawing.Color.Transparent
            Me.LabelSubBand1_ExtraSpaceByDesign.BorderColor = System.Drawing.Color.Black
            Me.LabelSubBand1_ExtraSpaceByDesign.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelSubBand1_ExtraSpaceByDesign.BorderWidth = 1.0!
            Me.LabelSubBand1_ExtraSpaceByDesign.CanGrow = False
            Me.LabelSubBand1_ExtraSpaceByDesign.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelSubBand1_ExtraSpaceByDesign.ForeColor = System.Drawing.Color.Black
            Me.LabelSubBand1_ExtraSpaceByDesign.LocationFloat = New DevExpress.Utils.PointFloat(52.07672!, 0!)
            Me.LabelSubBand1_ExtraSpaceByDesign.Name = "LabelSubBand1_ExtraSpaceByDesign"
            Me.LabelSubBand1_ExtraSpaceByDesign.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelSubBand1_ExtraSpaceByDesign.SizeF = New System.Drawing.SizeF(52.04493!, 18.99999!)
            Me.LabelSubBand1_ExtraSpaceByDesign.StylePriority.UseFont = False
            Me.LabelSubBand1_ExtraSpaceByDesign.StylePriority.UsePadding = False
            Me.LabelSubBand1_ExtraSpaceByDesign.StylePriority.UseTextAlignment = False
            Me.LabelSubBand1_ExtraSpaceByDesign.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ReportHeader
            '
            Me.ReportHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPictureBoxHeaderLogo})
            Me.ReportHeader.HeightF = 150.0!
            Me.ReportHeader.Name = "ReportHeader"
            '
            'DetailReportFlightLines
            '
            Me.DetailReportFlightLines.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailFlightLines, Me.DetailReportFlightLinesHeader, Me.DetailReportFlightLinesFooter})
            Me.DetailReportFlightLines.DataSource = Me.BindingSourceFlightLines
            Me.DetailReportFlightLines.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DetailReportFlightLines.Level = 0
            Me.DetailReportFlightLines.Name = "DetailReportFlightLines"
            '
            'DetailFlightLines
            '
            Me.DetailFlightLines.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel1, Me.XrLabel14, Me.XrLabel13, Me.XrLabel12, Me.XrLabel10})
            Me.DetailFlightLines.HeightF = 19.0!
            Me.DetailFlightLines.Name = "DetailFlightLines"
            '
            'XrLabel1
            '
            Me.XrLabel1.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "EndDate")})
            Me.XrLabel1.LocationFloat = New DevExpress.Utils.PointFloat(252.6733!, 0!)
            Me.XrLabel1.Multiline = True
            Me.XrLabel1.Name = "XrLabel1"
            Me.XrLabel1.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel1.SizeF = New System.Drawing.SizeF(67.7099!, 18.99999!)
            Me.XrLabel1.Text = "XrLabel1"
            Me.XrLabel1.TextFormatString = "{0:M/d/yyyy}"
            '
            'XrLabel14
            '
            Me.XrLabel14.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "LineTotal")})
            Me.XrLabel14.LocationFloat = New DevExpress.Utils.PointFloat(619.3434!, 0!)
            Me.XrLabel14.Multiline = True
            Me.XrLabel14.Name = "XrLabel14"
            Me.XrLabel14.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel14.SizeF = New System.Drawing.SizeF(129.7862!, 18.99999!)
            Me.XrLabel14.StylePriority.UseTextAlignment = False
            Me.XrLabel14.Text = "XrLabel14"
            Me.XrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrLabel14.TextFormatString = "{0:n2}"
            '
            'XrLabel13
            '
            Me.XrLabel13.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CostRate")})
            Me.XrLabel13.LocationFloat = New DevExpress.Utils.PointFloat(544.5552!, 0!)
            Me.XrLabel13.Multiline = True
            Me.XrLabel13.Name = "XrLabel13"
            Me.XrLabel13.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel13.SizeF = New System.Drawing.SizeF(69.78821!, 18.99999!)
            Me.XrLabel13.StylePriority.UseTextAlignment = False
            Me.XrLabel13.Text = "XrLabel13"
            Me.XrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrLabel13.TextFormatString = "{0:n4}"
            '
            'XrLabel12
            '
            Me.XrLabel12.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "GuaranteedImpressions")})
            Me.XrLabel12.LocationFloat = New DevExpress.Utils.PointFloat(419.9598!, 0!)
            Me.XrLabel12.Multiline = True
            Me.XrLabel12.Name = "XrLabel12"
            Me.XrLabel12.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel12.SizeF = New System.Drawing.SizeF(114.1238!, 18.99999!)
            Me.XrLabel12.StylePriority.UseTextAlignment = False
            Me.XrLabel12.Text = "XrLabel12"
            Me.XrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrLabel12.TextFormatString = "{0:#,#}"
            '
            'XrLabel10
            '
            Me.XrLabel10.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "StartDate")})
            Me.XrLabel10.LocationFloat = New DevExpress.Utils.PointFloat(179.9632!, 0!)
            Me.XrLabel10.Multiline = True
            Me.XrLabel10.Name = "XrLabel10"
            Me.XrLabel10.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel10.SizeF = New System.Drawing.SizeF(67.70998!, 19.0!)
            Me.XrLabel10.Text = "XrLabel10"
            Me.XrLabel10.TextFormatString = "{0:M/d/yyyy}"
            '
            'DetailReportFlightLinesHeader
            '
            Me.DetailReportFlightLinesHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel15, Me.XrLabel16, Me.XrLabel17, Me.LabelDetailReportFlightLinesHeader_Units, Me.XrLabel20})
            Me.DetailReportFlightLinesHeader.HeightF = 25.00333!
            Me.DetailReportFlightLinesHeader.Name = "DetailReportFlightLinesHeader"
            '
            'XrLabel15
            '
            Me.XrLabel15.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel15.BorderColor = System.Drawing.Color.Black
            Me.XrLabel15.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel15.BorderWidth = 1.0!
            Me.XrLabel15.CanGrow = False
            Me.XrLabel15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel15.ForeColor = System.Drawing.Color.Black
            Me.XrLabel15.LocationFloat = New DevExpress.Utils.PointFloat(619.3433!, 8.333333!)
            Me.XrLabel15.Name = "XrLabel15"
            Me.XrLabel15.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel15.SizeF = New System.Drawing.SizeF(129.7863!, 16.67!)
            Me.XrLabel15.StylePriority.UseFont = False
            Me.XrLabel15.StylePriority.UsePadding = False
            Me.XrLabel15.StylePriority.UseTextAlignment = False
            Me.XrLabel15.Text = "Cost"
            Me.XrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel16
            '
            Me.XrLabel16.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel16.BorderColor = System.Drawing.Color.Black
            Me.XrLabel16.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel16.BorderWidth = 1.0!
            Me.XrLabel16.CanGrow = False
            Me.XrLabel16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel16.ForeColor = System.Drawing.Color.Black
            Me.XrLabel16.LocationFloat = New DevExpress.Utils.PointFloat(179.963!, 8.333333!)
            Me.XrLabel16.Name = "XrLabel16"
            Me.XrLabel16.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel16.SizeF = New System.Drawing.SizeF(67.71004!, 16.67!)
            Me.XrLabel16.StylePriority.UseFont = False
            Me.XrLabel16.StylePriority.UsePadding = False
            Me.XrLabel16.StylePriority.UseTextAlignment = False
            Me.XrLabel16.Text = "Start Date"
            Me.XrLabel16.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel17
            '
            Me.XrLabel17.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel17.BorderColor = System.Drawing.Color.Black
            Me.XrLabel17.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel17.BorderWidth = 1.0!
            Me.XrLabel17.CanGrow = False
            Me.XrLabel17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel17.ForeColor = System.Drawing.Color.Black
            Me.XrLabel17.LocationFloat = New DevExpress.Utils.PointFloat(252.6731!, 8.333333!)
            Me.XrLabel17.Name = "XrLabel17"
            Me.XrLabel17.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel17.SizeF = New System.Drawing.SizeF(67.71002!, 16.67!)
            Me.XrLabel17.StylePriority.UseFont = False
            Me.XrLabel17.StylePriority.UsePadding = False
            Me.XrLabel17.StylePriority.UseTextAlignment = False
            Me.XrLabel17.Text = "End Date"
            Me.XrLabel17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetailReportFlightLinesHeader_Units
            '
            Me.LabelDetailReportFlightLinesHeader_Units.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetailReportFlightLinesHeader_Units.BorderColor = System.Drawing.Color.Black
            Me.LabelDetailReportFlightLinesHeader_Units.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetailReportFlightLinesHeader_Units.BorderWidth = 1.0!
            Me.LabelDetailReportFlightLinesHeader_Units.CanGrow = False
            Me.LabelDetailReportFlightLinesHeader_Units.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetailReportFlightLinesHeader_Units.ForeColor = System.Drawing.Color.Black
            Me.LabelDetailReportFlightLinesHeader_Units.LocationFloat = New DevExpress.Utils.PointFloat(419.9598!, 8.333333!)
            Me.LabelDetailReportFlightLinesHeader_Units.Name = "LabelDetailReportFlightLinesHeader_Units"
            Me.LabelDetailReportFlightLinesHeader_Units.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetailReportFlightLinesHeader_Units.SizeF = New System.Drawing.SizeF(124.5953!, 16.67!)
            Me.LabelDetailReportFlightLinesHeader_Units.StylePriority.UseFont = False
            Me.LabelDetailReportFlightLinesHeader_Units.StylePriority.UsePadding = False
            Me.LabelDetailReportFlightLinesHeader_Units.StylePriority.UseTextAlignment = False
            Me.LabelDetailReportFlightLinesHeader_Units.Text = "Units"
            Me.LabelDetailReportFlightLinesHeader_Units.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabel20
            '
            Me.XrLabel20.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel20.BorderColor = System.Drawing.Color.Black
            Me.XrLabel20.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel20.BorderWidth = 1.0!
            Me.XrLabel20.CanGrow = False
            Me.XrLabel20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel20.ForeColor = System.Drawing.Color.Black
            Me.XrLabel20.LocationFloat = New DevExpress.Utils.PointFloat(544.5551!, 8.333333!)
            Me.XrLabel20.Name = "XrLabel20"
            Me.XrLabel20.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel20.SizeF = New System.Drawing.SizeF(69.78821!, 16.67!)
            Me.XrLabel20.StylePriority.UseFont = False
            Me.XrLabel20.StylePriority.UsePadding = False
            Me.XrLabel20.StylePriority.UseTextAlignment = False
            Me.XrLabel20.Text = "Rate"
            Me.XrLabel20.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'DetailReportFlightLinesFooter
            '
            Me.DetailReportFlightLinesFooter.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign})
            Me.DetailReportFlightLinesFooter.HeightF = 18.99999!
            Me.DetailReportFlightLinesFooter.Name = "DetailReportFlightLinesFooter"
            '
            'LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign
            '
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.BorderColor = System.Drawing.Color.Black
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.BorderWidth = 1.0!
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.CanGrow = False
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.ForeColor = System.Drawing.Color.Black
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.Name = "LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign"
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.SizeF = New System.Drawing.SizeF(52.04493!, 18.99999!)
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.StylePriority.UseFont = False
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.StylePriority.UsePadding = False
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.StylePriority.UseTextAlignment = False
            Me.LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSourceFlightLines
            '
            Me.BindingSourceFlightLines.DataSource = GetType(AdvantageFramework.Database.Entities.InternetOrderDetail)
            '
            'LineDetail_Bottom
            '
            Me.LineDetail_Bottom.BorderColor = System.Drawing.Color.Black
            Me.LineDetail_Bottom.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineDetail_Bottom.BorderWidth = 1.0!
            Me.LineDetail_Bottom.ForeColor = System.Drawing.Color.Black
            Me.LineDetail_Bottom.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
            Me.LineDetail_Bottom.LocationFloat = New DevExpress.Utils.PointFloat(0!, 37.99998!)
            Me.LineDetail_Bottom.Name = "LineDetail_Bottom"
            Me.LineDetail_Bottom.SizeF = New System.Drawing.SizeF(749.9999!, 7.499992!)
            Me.LineDetail_Bottom.StylePriority.UseBorderColor = False
            Me.LineDetail_Bottom.StylePriority.UseBorderWidth = False
            Me.LineDetail_Bottom.StylePriority.UseForeColor = False
            '
            'DetailReportPackageAdSizes
            '
            Me.DetailReportPackageAdSizes.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailPackageAdSizes, Me.DetailReportPackageAdSizesHeader})
            Me.DetailReportPackageAdSizes.DataSource = Me.BindingSourcePackageAdSizes
            Me.DetailReportPackageAdSizes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.DetailReportPackageAdSizes.Level = 2
            Me.DetailReportPackageAdSizes.Name = "DetailReportPackageAdSizes"
            '
            'DetailPackageAdSizes
            '
            Me.DetailPackageAdSizes.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailPackageAdSizesPlacementName, Me.LabelDetailPackageAdSizesAdSize})
            Me.DetailPackageAdSizes.HeightF = 19.0!
            Me.DetailPackageAdSizes.Name = "DetailPackageAdSizes"
            '
            'LabelDetailPackageAdSizesPlacementName
            '
            Me.LabelDetailPackageAdSizesPlacementName.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PlacementName")})
            Me.LabelDetailPackageAdSizesPlacementName.LocationFloat = New DevExpress.Utils.PointFloat(252.6731!, 0!)
            Me.LabelDetailPackageAdSizesPlacementName.Multiline = True
            Me.LabelDetailPackageAdSizesPlacementName.Name = "LabelDetailPackageAdSizesPlacementName"
            Me.LabelDetailPackageAdSizesPlacementName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailPackageAdSizesPlacementName.SizeF = New System.Drawing.SizeF(496.4565!, 19.0!)
            Me.LabelDetailPackageAdSizesPlacementName.Text = "LabelDetailPackageAdSizesPlacementName"
            '
            'LabelDetailPackageAdSizesAdSize
            '
            Me.LabelDetailPackageAdSizesAdSize.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdSizeDescription")})
            Me.LabelDetailPackageAdSizesAdSize.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetailPackageAdSizesAdSize.Multiline = True
            Me.LabelDetailPackageAdSizesAdSize.Name = "LabelDetailPackageAdSizesAdSize"
            Me.LabelDetailPackageAdSizesAdSize.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelDetailPackageAdSizesAdSize.SizeF = New System.Drawing.SizeF(252.6731!, 19.0!)
            '
            'DetailReportPackageAdSizesHeader
            '
            Me.DetailReportPackageAdSizesHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements, Me.LabelDetailReportPackageAdSizesHeader_Size})
            Me.DetailReportPackageAdSizesHeader.HeightF = 16.67!
            Me.DetailReportPackageAdSizesHeader.Name = "DetailReportPackageAdSizesHeader"
            '
            'LabelDetailReportPackageAdSizesHeader_PackagePlacements
            '
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.BorderColor = System.Drawing.Color.Black
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.BorderWidth = 1.0!
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.CanGrow = False
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.ForeColor = System.Drawing.Color.Black
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.LocationFloat = New DevExpress.Utils.PointFloat(252.6731!, 0!)
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.Name = "LabelDetailReportPackageAdSizesHeader_PackagePlacements"
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.SizeF = New System.Drawing.SizeF(186.4601!, 16.67!)
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.StylePriority.UseFont = False
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.StylePriority.UsePadding = False
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.StylePriority.UseTextAlignment = False
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.Text = "Package Placements"
            Me.LabelDetailReportPackageAdSizesHeader_PackagePlacements.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelDetailReportPackageAdSizesHeader_Size
            '
            Me.LabelDetailReportPackageAdSizesHeader_Size.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetailReportPackageAdSizesHeader_Size.BorderColor = System.Drawing.Color.Black
            Me.LabelDetailReportPackageAdSizesHeader_Size.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetailReportPackageAdSizesHeader_Size.BorderWidth = 1.0!
            Me.LabelDetailReportPackageAdSizesHeader_Size.CanGrow = False
            Me.LabelDetailReportPackageAdSizesHeader_Size.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetailReportPackageAdSizesHeader_Size.ForeColor = System.Drawing.Color.Black
            Me.LabelDetailReportPackageAdSizesHeader_Size.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetailReportPackageAdSizesHeader_Size.Name = "LabelDetailReportPackageAdSizesHeader_Size"
            Me.LabelDetailReportPackageAdSizesHeader_Size.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetailReportPackageAdSizesHeader_Size.SizeF = New System.Drawing.SizeF(247.6732!, 16.67!)
            Me.LabelDetailReportPackageAdSizesHeader_Size.StylePriority.UseFont = False
            Me.LabelDetailReportPackageAdSizesHeader_Size.StylePriority.UsePadding = False
            Me.LabelDetailReportPackageAdSizesHeader_Size.StylePriority.UseTextAlignment = False
            Me.LabelDetailReportPackageAdSizesHeader_Size.Text = "Ad Size(s)"
            Me.LabelDetailReportPackageAdSizesHeader_Size.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSourcePackageAdSizes
            '
            Me.BindingSourcePackageAdSizes.DataSource = GetType(AdvantageFramework.MediaManager.Classes.InternetOrderReportAdSize)
            '
            'GroupHeaderFirstPageOnly2
            '
            Me.GroupHeaderFirstPageOnly2.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrTableHeaderInfo})
            Me.GroupHeaderFirstPageOnly2.HeightF = 17.0!
            Me.GroupHeaderFirstPageOnly2.Level = 1
            Me.GroupHeaderFirstPageOnly2.Name = "GroupHeaderFirstPageOnly2"
            '
            'XrTableHeaderInfo
            '
            Me.XrTableHeaderInfo.LocationFloat = New DevExpress.Utils.PointFloat(0.0002441406!, 0!)
            Me.XrTableHeaderInfo.Name = "XrTableHeaderInfo"
            Me.XrTableHeaderInfo.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.XrTableRowHeaderOrderComment})
            Me.XrTableHeaderInfo.SizeF = New System.Drawing.SizeF(750.0!, 17.0!)
            '
            'XrTableRowHeaderOrderComment
            '
            Me.XrTableRowHeaderOrderComment.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.XrTableCellHeaderOrderInstructionsLabel, Me.XrTableCellHeaderOrderComment})
            Me.XrTableRowHeaderOrderComment.Name = "XrTableRowHeaderOrderComment"
            Me.XrTableRowHeaderOrderComment.Weight = 1.0R
            '
            'XrTableCellHeaderOrderInstructionsLabel
            '
            Me.XrTableCellHeaderOrderInstructionsLabel.CanShrink = True
            Me.XrTableCellHeaderOrderInstructionsLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrTableCellHeaderOrderInstructionsLabel.Name = "XrTableCellHeaderOrderInstructionsLabel"
            Me.XrTableCellHeaderOrderInstructionsLabel.StylePriority.UseFont = False
            Me.XrTableCellHeaderOrderInstructionsLabel.Text = "Order Comment:"
            Me.XrTableCellHeaderOrderInstructionsLabel.Weight = 0.52323065848811678R
            '
            'XrTableCellHeaderOrderComment
            '
            Me.XrTableCellHeaderOrderComment.CanShrink = True
            Me.XrTableCellHeaderOrderComment.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "OrderComment")})
            Me.XrTableCellHeaderOrderComment.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrTableCellHeaderOrderComment.Multiline = True
            Me.XrTableCellHeaderOrderComment.Name = "XrTableCellHeaderOrderComment"
            Me.XrTableCellHeaderOrderComment.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrTableCellHeaderOrderComment.StylePriority.UseFont = False
            Me.XrTableCellHeaderOrderComment.StylePriority.UsePadding = False
            Me.XrTableCellHeaderOrderComment.Weight = 2.4562827659118578R
            '
            'GroupHeaderTarget
            '
            Me.GroupHeaderTarget.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("StartDate", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("TargetGroup", DevExpress.XtraReports.UI.XRColumnSortOrder.None)})
            Me.GroupHeaderTarget.HeightF = 0!
            Me.GroupHeaderTarget.Name = "GroupHeaderTarget"
            Me.GroupHeaderTarget.Visible = False
            '
            'GroupFooterTarget
            '
            Me.GroupFooterTarget.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineDetail_Bottom, Me.LabelGroupFooterTarget_URLLabel, Me.LabelGroupFooterTarget_URL, Me.LabelGroupFooterTarget_Placement, Me.LabelGroupFooterTarget_PlacementLabel})
            Me.GroupFooterTarget.HeightF = 45.49997!
            Me.GroupFooterTarget.Name = "GroupFooterTarget"
            '
            'LabelGroupFooterTarget_URLLabel
            '
            Me.LabelGroupFooterTarget_URLLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterTarget_URLLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterTarget_URLLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterTarget_URLLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterTarget_URLLabel.CanGrow = False
            Me.LabelGroupFooterTarget_URLLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterTarget_URLLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterTarget_URLLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 18.99999!)
            Me.LabelGroupFooterTarget_URLLabel.Name = "LabelGroupFooterTarget_URLLabel"
            Me.LabelGroupFooterTarget_URLLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterTarget_URLLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterTarget_URLLabel.SizeF = New System.Drawing.SizeF(83.32952!, 19.00001!)
            Me.LabelGroupFooterTarget_URLLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterTarget_URLLabel.StylePriority.UsePadding = False
            Me.LabelGroupFooterTarget_URLLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterTarget_URLLabel.Text = "URL:"
            Me.LabelGroupFooterTarget_URLLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'LabelGroupFooterTarget_URL
            '
            Me.LabelGroupFooterTarget_URL.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "URL")})
            Me.LabelGroupFooterTarget_URL.LocationFloat = New DevExpress.Utils.PointFloat(83.3299!, 18.99999!)
            Me.LabelGroupFooterTarget_URL.Multiline = True
            Me.LabelGroupFooterTarget_URL.Name = "LabelGroupFooterTarget_URL"
            Me.LabelGroupFooterTarget_URL.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterTarget_URL.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterTarget_URL.SizeF = New System.Drawing.SizeF(666.6703!, 18.99999!)
            '
            'LabelGroupFooterTarget_Placement
            '
            Me.LabelGroupFooterTarget_Placement.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Placement")})
            Me.LabelGroupFooterTarget_Placement.LocationFloat = New DevExpress.Utils.PointFloat(83.33002!, 0!)
            Me.LabelGroupFooterTarget_Placement.Multiline = True
            Me.LabelGroupFooterTarget_Placement.Name = "LabelGroupFooterTarget_Placement"
            Me.LabelGroupFooterTarget_Placement.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelGroupFooterTarget_Placement.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterTarget_Placement.SizeF = New System.Drawing.SizeF(665.7995!, 18.99999!)
            '
            'LabelGroupFooterTarget_PlacementLabel
            '
            Me.LabelGroupFooterTarget_PlacementLabel.BackColor = System.Drawing.Color.Transparent
            Me.LabelGroupFooterTarget_PlacementLabel.BorderColor = System.Drawing.Color.Black
            Me.LabelGroupFooterTarget_PlacementLabel.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelGroupFooterTarget_PlacementLabel.BorderWidth = 1.0!
            Me.LabelGroupFooterTarget_PlacementLabel.CanGrow = False
            Me.LabelGroupFooterTarget_PlacementLabel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelGroupFooterTarget_PlacementLabel.ForeColor = System.Drawing.Color.Black
            Me.LabelGroupFooterTarget_PlacementLabel.LocationFloat = New DevExpress.Utils.PointFloat(0.0003814697!, 0!)
            Me.LabelGroupFooterTarget_PlacementLabel.Name = "LabelGroupFooterTarget_PlacementLabel"
            Me.LabelGroupFooterTarget_PlacementLabel.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelGroupFooterTarget_PlacementLabel.ProcessNullValues = DevExpress.XtraReports.UI.ValueSuppressType.SuppressAndShrink
            Me.LabelGroupFooterTarget_PlacementLabel.SizeF = New System.Drawing.SizeF(83.32952!, 19.00001!)
            Me.LabelGroupFooterTarget_PlacementLabel.StylePriority.UseFont = False
            Me.LabelGroupFooterTarget_PlacementLabel.StylePriority.UsePadding = False
            Me.LabelGroupFooterTarget_PlacementLabel.StylePriority.UseTextAlignment = False
            Me.LabelGroupFooterTarget_PlacementLabel.Text = "Placement:"
            Me.LabelGroupFooterTarget_PlacementLabel.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BindingSource
            '
            Me.BindingSource.AllowNew = False
            Me.BindingSource.DataSource = GetType(AdvantageFramework.MediaManager.Classes.InternetOrderReport)
            '
            'DetailReportPackagePlacementNames
            '
            Me.DetailReportPackagePlacementNames.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.DetailPackagePlacementNames, Me.DetailReportPackagePlacementNamesHeader})
            Me.DetailReportPackagePlacementNames.DataSource = Me.BindingSourcePackageAdSizes
            Me.DetailReportPackagePlacementNames.Level = 1
            Me.DetailReportPackagePlacementNames.Name = "DetailReportPackagePlacementNames"
            '
            'DetailPackagePlacementNames
            '
            Me.DetailPackagePlacementNames.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel11, Me.XrLabel2})
            Me.DetailPackagePlacementNames.HeightF = 19.0!
            Me.DetailPackagePlacementNames.Name = "DetailPackagePlacementNames"
            '
            'XrLabel11
            '
            Me.XrLabel11.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "AdSizeDescription")})
            Me.XrLabel11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel11.LocationFloat = New DevExpress.Utils.PointFloat(496.4565!, 0!)
            Me.XrLabel11.Multiline = True
            Me.XrLabel11.Name = "XrLabel11"
            Me.XrLabel11.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel11.SizeF = New System.Drawing.SizeF(252.6731!, 19.0!)
            Me.XrLabel11.StylePriority.UseFont = False
            Me.XrLabel11.Visible = False
            '
            'XrLabel2
            '
            Me.XrLabel2.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "PlacementName")})
            Me.XrLabel2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabel2.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.XrLabel2.Multiline = True
            Me.XrLabel2.Name = "XrLabel2"
            Me.XrLabel2.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.XrLabel2.SizeF = New System.Drawing.SizeF(496.4565!, 19.0!)
            Me.XrLabel2.StylePriority.UseFont = False
            Me.XrLabel2.Text = "LabelDetailPackageAdSizesPlacementName"
            '
            'DetailReportPackagePlacementNamesHeader
            '
            Me.DetailReportPackagePlacementNamesHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabel18, Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements})
            Me.DetailReportPackagePlacementNamesHeader.HeightF = 16.67!
            Me.DetailReportPackagePlacementNamesHeader.Name = "DetailReportPackagePlacementNamesHeader"
            '
            'XrLabel18
            '
            Me.XrLabel18.BackColor = System.Drawing.Color.Transparent
            Me.XrLabel18.BorderColor = System.Drawing.Color.Black
            Me.XrLabel18.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLabel18.BorderWidth = 1.0!
            Me.XrLabel18.CanGrow = False
            Me.XrLabel18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.XrLabel18.ForeColor = System.Drawing.Color.Black
            Me.XrLabel18.LocationFloat = New DevExpress.Utils.PointFloat(496.8304!, 0!)
            Me.XrLabel18.Name = "XrLabel18"
            Me.XrLabel18.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.XrLabel18.SizeF = New System.Drawing.SizeF(253.1699!, 16.67!)
            Me.XrLabel18.StylePriority.UseFont = False
            Me.XrLabel18.StylePriority.UsePadding = False
            Me.XrLabel18.StylePriority.UseTextAlignment = False
            Me.XrLabel18.Text = "Additional Ad Sizes"
            Me.XrLabel18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.XrLabel18.Visible = False
            '
            'LabelDetailReportPackagePlacementNamesHeader_PackagePlacements
            '
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.BackColor = System.Drawing.Color.Transparent
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.BorderColor = System.Drawing.Color.Black
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.BorderWidth = 1.0!
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.CanGrow = False
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.ForeColor = System.Drawing.Color.Black
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.Name = "LabelDetailReportPackagePlacementNamesHeader_PackagePlacements"
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.SizeF = New System.Drawing.SizeF(496.4565!, 16.67!)
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.StylePriority.UseFont = False
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.StylePriority.UsePadding = False
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.StylePriority.UseTextAlignment = False
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.Text = "Package Placements"
            Me.LabelDetailReportPackagePlacementNamesHeader_PackagePlacements.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'ObjectDataSource1
            '
            Me.ObjectDataSource1.DataSource = GetType(AdvantageFramework.Database.Entities.InternetPackageDetail)
            Me.ObjectDataSource1.Name = "ObjectDataSource1"
            '
            'InternetOrderReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageFooter, Me.GroupFooterOrderNumber, Me.GroupHeaderEveryPage, Me.GroupHeaderEveryPage2, Me.ReportHeader, Me.DetailReportFlightLines, Me.DetailReportPackageAdSizes, Me.GroupHeaderFirstPageOnly2, Me.GroupHeaderTarget, Me.GroupFooterTarget, Me.DetailReportPackagePlacementNames})
            Me.ComponentStorage.AddRange(New System.ComponentModel.IComponent() {Me.BindingSource, Me.BindingSourceFlightLines, Me.BindingSourcePackageAdSizes, Me.ObjectDataSource1})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Margins = New System.Drawing.Printing.Margins(50, 50, 25, 50)
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "20.1"
            CType(Me.XrTableCampaignMarket, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrTableHeaderLeft, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourceFlightLines, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSourcePackageAdSizes, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.XrTableHeaderInfo, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ObjectDataSource1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_TargetLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeaderOrderNumber_Email As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeaderOrderNumber_Buyer As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_OrderNumberLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_PageLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_BuyerLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_EmailLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrPictureBoxHeaderLogo As DevExpress.XtraReports.UI.XRPictureBox
        Friend WithEvents LabelHeaderOrderNumber_OrderNumber As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeaderOrderNumber_PrintDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_DateLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_VenRepLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageInfo_Pages As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents LabelHeaderOrderNumber_VendorCode As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderOrderHeader_Top As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelDetail_DimenstionsLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_EndLabel1 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_EndLabel2 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_Units As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelHeaderOrderNumber_SizeLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeaderOrderNumberTop_OrderLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupHeaderOrderHeaderTop_LocationHeader As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelGroupHeaderOrderNumberTop_LocationHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooter As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents LabelPageFooter_LocationFooter As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrTableCampaignMarket As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowCampaignMarket_Campaign As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCampaignMarket_CampaignLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCampaignMarket_Campaign As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowCampaignMarket_Market As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCampaignMarket_MarketLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCampaignMarket_Market As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents GroupFooterOrderNumber As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents LabelFooterOrderNumber_AmountSubtotal As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelFooterOrderNumber_SubtotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_VendorTaxLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_AgencyCommissionLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterOrderNumber_AgencyComment As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_OrderTotalLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_DiscountSum As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_DiscountSumLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupFooterOrderNumberSubreport_VendorShippingSubReport As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents GroupHeaderOrderNumberTopSubreportVendorRep1 As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents GroupHeaderOrderNumberTopSubreportVendorRep2 As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents GroupHeaderOrderNumberTopSubreportVendorAddress As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents LabelHeaderOrderNumber_OrderDescriptionLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeaderOrderNumber_OrderDescription As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_ShipToLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_NetChargeSumLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_NetChargeSum As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_Box As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_VendorTaxSum As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_AgencyCommissionSum As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterOrderNumber_LineTotalActual As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderEveryPage As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupHeaderEveryPage2 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents ReportHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Friend WithEvents GroupFooterOrderNumberSubreport_ChargeToSubReport As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents LabelGroupFooterOrderNumber_OrderComment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterOrderNumber_OrderCommentTop As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterOrderNumber_AgencyCommentTop As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderCommentTop As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderComment As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrPictureBoxSignature As DevExpress.XtraReports.UI.XRPictureBox
        Private WithEvents LabelGroupFooterOrderNumber_AgencyAuthorization As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterOrderNumber_VendorAcceptance As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupFooterOrderNumber_AgencyAuthorization As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupFooterOrderNumber_AgencyAuthorizationDate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterOrderNumber_PrintDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupFooterOrderNumber_VendorAcceptanceDate As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelGroupFooterOrderNumber_VendorAcceptanceDate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LineGroupFooterOrderNumber_VendorAcceptance As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LineGroupFooterOrderNumber_AgencyAuthorizationDate As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents SubBandSignatures As DevExpress.XtraReports.UI.SubBand
        Friend WithEvents SubBandCommentsBelowSignatures As DevExpress.XtraReports.UI.SubBand
        Friend WithEvents LabelDetail_MarketDetail As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Detail_Target As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_MarketDetailLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel3 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel9 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel8 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel7 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel6 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel5 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel4 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents SubBand1 As DevExpress.XtraReports.UI.SubBand
        Private WithEvents LabelSubBand1_ExtraSpaceByDesign As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportFlightLines As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailFlightLines As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents BindingSourceFlightLines As Windows.Forms.BindingSource
        Friend WithEvents XrLabel10 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel12 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel14 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel13 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportFlightLinesHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Private WithEvents XrLabel15 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel16 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel17 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetailReportFlightLinesHeader_Units As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents XrLabel20 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel1 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportPackageAdSizes As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailPackageAdSizes As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents BindingSourcePackageAdSizes As Windows.Forms.BindingSource
        Friend WithEvents DetailReportPackageAdSizesHeader As DevExpress.XtraReports.UI.ReportHeaderBand
        Private WithEvents LabelDetailReportPackageAdSizesHeader_Size As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderFirstPageOnly2 As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrTableHeaderInfo As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowHeaderOrderComment As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCellHeaderOrderInstructionsLabel As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCellHeaderOrderComment As DevExpress.XtraReports.UI.XRTableCell
        Private WithEvents LineDetail_Bottom As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelDetail_Rate As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_RateLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailPackageAdSizesPlacementName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetailPackageAdSizesAdSize As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetailReportPackageAdSizesHeader_PackagePlacements As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_InstructionsLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelDetail_Instructions As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderTarget As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterTarget As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents DetailReportFlightLinesFooter As DevExpress.XtraReports.UI.GroupFooterBand
        Private WithEvents LabelDetailReportFlichLinesFooter_ExtraSpacebyDesign As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterTarget_URLLabel As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterTarget_URL As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterTarget_Placement As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelGroupFooterTarget_PlacementLabel As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents DetailLabel_Cancelled As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportPackagePlacementNames As DevExpress.XtraReports.UI.DetailReportBand
        Friend WithEvents DetailPackagePlacementNames As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents XrLabel11 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabel2 As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents DetailReportPackagePlacementNamesHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Private WithEvents XrLabel18 As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetailReportPackagePlacementNamesHeader_PackagePlacements As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents ObjectDataSource1 As DevExpress.DataAccess.ObjectBinding.ObjectDataSource
        Friend WithEvents XrTableHeaderLeft As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents XrTableRowLeftStation As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents XrTableCell2 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCell3 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowLeftClient As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellClient_Client As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCell9 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRow1 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellClient_Address1 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellClient_Address1Value As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRow2 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellClient_Address2 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellClient_Address2Value As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRow3 As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellClient_CityStateZip As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellClient_CityStateZipValue As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowLeftDivision As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellClient_Division As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCell7 As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableRowLeftProduct As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellClient_Product As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents XrTableCell5 As DevExpress.XtraReports.UI.XRTableCell
    End Class

End Namespace
