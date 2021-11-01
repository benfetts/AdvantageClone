Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ServiceFeeReconciliationFeeDetailSubReport
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
			Dim XrSummary4 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary5 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Dim XrSummary6 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
			Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
			Me.TableDetail_Details = New DevExpress.XtraReports.UI.XRTable()
			Me.TableRowDetails_Details = New DevExpress.XtraReports.UI.XRTableRow()
			Me.TableCellDetails_FeeDate = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellDetails_Description = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellDetails_FeeQuantity = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellDetails_FeeAmount = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellDetails_FeeTimeType = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
			Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
			Me.Campaign = New DevExpress.XtraReports.UI.CalculatedField()
			Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.Job = New DevExpress.XtraReports.UI.CalculatedField()
			Me.Component = New DevExpress.XtraReports.UI.CalculatedField()
			Me.SalesClass = New DevExpress.XtraReports.UI.CalculatedField()
			Me.CompFunction = New DevExpress.XtraReports.UI.CalculatedField()
			Me.Client = New DevExpress.XtraReports.UI.CalculatedField()
			Me.Division = New DevExpress.XtraReports.UI.CalculatedField()
			Me.Product = New DevExpress.XtraReports.UI.CalculatedField()
			Me.StandardFeeBilled = New DevExpress.XtraReports.UI.CalculatedField()
			Me.StandardTimePosted = New DevExpress.XtraReports.UI.CalculatedField()
			Me.StandardVariance = New DevExpress.XtraReports.UI.CalculatedField()
			Me.ProductionFeeBilled = New DevExpress.XtraReports.UI.CalculatedField()
			Me.ProductionTimePosted = New DevExpress.XtraReports.UI.CalculatedField()
			Me.ProductionVariance = New DevExpress.XtraReports.UI.CalculatedField()
			Me.MediaFeeBilled = New DevExpress.XtraReports.UI.CalculatedField()
			Me.MediaTimePosted = New DevExpress.XtraReports.UI.CalculatedField()
			Me.MediaVariance = New DevExpress.XtraReports.UI.CalculatedField()
			Me.TotalFeeBilled = New DevExpress.XtraReports.UI.CalculatedField()
			Me.TotalTimePosted = New DevExpress.XtraReports.UI.CalculatedField()
			Me.TotalVariance = New DevExpress.XtraReports.UI.CalculatedField()
			Me.GroupHeaderDetail = New DevExpress.XtraReports.UI.GroupHeaderBand()
			Me.LabelDetail_FeesPosted = New DevExpress.XtraReports.UI.XRLabel()
			Me.TableGroupHeaderDetail_Header = New DevExpress.XtraReports.UI.XRTable()
			Me.TableRowHeader_Header = New DevExpress.XtraReports.UI.XRTableRow()
			Me.TableCellHeader_FeeDate = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellHeader_Description = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellHeader_FeeQuantity = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellHeader_FeeAmount = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellHeader_FeeTimeType = New DevExpress.XtraReports.UI.XRTableCell()
			Me.GroupFooterDetail = New DevExpress.XtraReports.UI.GroupFooterBand()
			Me.LineGroupFooterDetail_Line = New DevExpress.XtraReports.UI.XRLine()
			Me.LabelGroupFooterDetail_FeeAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupFooterDetail_Totals = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupFooterDetail_FeeQuantity = New DevExpress.XtraReports.UI.XRLabel()
			Me.XrControlStyle1 = New DevExpress.XtraReports.UI.XRControlStyle()
			Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
			Me.IsServiceFeeJob = New DevExpress.XtraReports.UI.CalculatedField()
			CType(Me.TableDetail_Details, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.TableGroupHeaderDetail_Header, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
			'
			'Detail
			'
			Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.TableDetail_Details})
			Me.Detail.Dpi = 100.0!
			Me.Detail.HeightF = 21.0!
			Me.Detail.KeepTogether = True
			Me.Detail.Name = "Detail"
			Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
			Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'TableDetail_Details
			'
			Me.TableDetail_Details.Dpi = 100.0!
			Me.TableDetail_Details.Font = New System.Drawing.Font("Arial", 8.25!)
			Me.TableDetail_Details.KeepTogether = True
			Me.TableDetail_Details.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
			Me.TableDetail_Details.Name = "TableDetail_Details"
			Me.TableDetail_Details.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.TableRowDetails_Details})
			Me.TableDetail_Details.SizeF = New System.Drawing.SizeF(700.0!, 21.0!)
			Me.TableDetail_Details.StylePriority.UseFont = False
			'
			'TableRowDetails_Details
			'
			Me.TableRowDetails_Details.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellDetails_FeeDate, Me.TableCellDetails_Description, Me.TableCellDetails_FeeQuantity, Me.TableCellDetails_FeeAmount, Me.TableCellDetails_FeeTimeType})
			Me.TableRowDetails_Details.Dpi = 100.0!
			Me.TableRowDetails_Details.Name = "TableRowDetails_Details"
			Me.TableRowDetails_Details.Weight = 0.5305263328319777R
			'
			'TableCellDetails_FeeDate
			'
			Me.TableCellDetails_FeeDate.CanGrow = False
			Me.TableCellDetails_FeeDate.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FeeDate", "{0:d}")})
			Me.TableCellDetails_FeeDate.Dpi = 100.0!
			Me.TableCellDetails_FeeDate.Font = New System.Drawing.Font("Arial", 7.0!)
			Me.TableCellDetails_FeeDate.KeepTogether = True
			Me.TableCellDetails_FeeDate.Name = "TableCellDetails_FeeDate"
			Me.TableCellDetails_FeeDate.StylePriority.UseFont = False
			Me.TableCellDetails_FeeDate.StylePriority.UseTextAlignment = False
			XrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
			XrSummary1.IgnoreNullValues = True
			Me.TableCellDetails_FeeDate.Summary = XrSummary1
			Me.TableCellDetails_FeeDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellDetails_FeeDate.Weight = 0.29373248092954196R
			Me.TableCellDetails_FeeDate.WordWrap = False
			'
			'TableCellDetails_Description
			'
			Me.TableCellDetails_Description.CanGrow = False
			Me.TableCellDetails_Description.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
			Me.TableCellDetails_Description.Dpi = 100.0!
			Me.TableCellDetails_Description.Font = New System.Drawing.Font("Arial", 7.0!)
			Me.TableCellDetails_Description.KeepTogether = True
			Me.TableCellDetails_Description.Name = "TableCellDetails_Description"
			Me.TableCellDetails_Description.StylePriority.UseFont = False
			Me.TableCellDetails_Description.StylePriority.UseTextAlignment = False
			XrSummary2.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
			XrSummary2.IgnoreNullValues = True
			Me.TableCellDetails_Description.Summary = XrSummary2
			Me.TableCellDetails_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellDetails_Description.Weight = 1.3217960874135415R
			Me.TableCellDetails_Description.WordWrap = False
			'
			'TableCellDetails_FeeQuantity
			'
			Me.TableCellDetails_FeeQuantity.CanGrow = False
			Me.TableCellDetails_FeeQuantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FeeQuantity", "{0:n2}")})
			Me.TableCellDetails_FeeQuantity.Dpi = 100.0!
			Me.TableCellDetails_FeeQuantity.Font = New System.Drawing.Font("Arial", 7.0!)
			Me.TableCellDetails_FeeQuantity.KeepTogether = True
			Me.TableCellDetails_FeeQuantity.Name = "TableCellDetails_FeeQuantity"
			Me.TableCellDetails_FeeQuantity.StylePriority.UseFont = False
			Me.TableCellDetails_FeeQuantity.StylePriority.UseTextAlignment = False
			XrSummary3.FormatString = "{0:n2}"
			Me.TableCellDetails_FeeQuantity.Summary = XrSummary3
			Me.TableCellDetails_FeeQuantity.Text = "TableCellDetails_FeeQuantity"
			Me.TableCellDetails_FeeQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellDetails_FeeQuantity.Weight = 0.44059871104294934R
			Me.TableCellDetails_FeeQuantity.WordWrap = False
			'
			'TableCellDetails_FeeAmount
			'
			Me.TableCellDetails_FeeAmount.CanGrow = False
			Me.TableCellDetails_FeeAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FeeAmount", "{0:n2}")})
			Me.TableCellDetails_FeeAmount.Dpi = 100.0!
			Me.TableCellDetails_FeeAmount.Font = New System.Drawing.Font("Arial", 7.0!)
			Me.TableCellDetails_FeeAmount.KeepTogether = True
			Me.TableCellDetails_FeeAmount.Name = "TableCellDetails_FeeAmount"
			Me.TableCellDetails_FeeAmount.StylePriority.UseFont = False
			Me.TableCellDetails_FeeAmount.StylePriority.UseTextAlignment = False
			XrSummary4.FormatString = "{0:n2}"
			Me.TableCellDetails_FeeAmount.Summary = XrSummary4
			Me.TableCellDetails_FeeAmount.Text = "TableCellDetails_FeeAmount"
			Me.TableCellDetails_FeeAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellDetails_FeeAmount.Weight = 0.44059869861561818R
			Me.TableCellDetails_FeeAmount.WordWrap = False
			'
			'TableCellDetails_FeeTimeType
			'
			Me.TableCellDetails_FeeTimeType.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FeeTimeType")})
			Me.TableCellDetails_FeeTimeType.Dpi = 100.0!
			Me.TableCellDetails_FeeTimeType.Font = New System.Drawing.Font("Arial", 7.0!)
			Me.TableCellDetails_FeeTimeType.Name = "TableCellDetails_FeeTimeType"
			Me.TableCellDetails_FeeTimeType.StylePriority.UseFont = False
			Me.TableCellDetails_FeeTimeType.StylePriority.UseTextAlignment = False
			Me.TableCellDetails_FeeTimeType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellDetails_FeeTimeType.Weight = 1.6155286150162938R
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
			Me.BottomMargin.HeightF = 0!
			Me.BottomMargin.Name = "BottomMargin"
			Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
			'
			'Campaign
			'
			Me.Campaign.Expression = "[CampaignCode] + ' - ' + [CampaignName]"
			Me.Campaign.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.Campaign.Name = "Campaign"
			'
			'BindingSource
			'
			Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Views.ServiceFeeReconcileDetail)
			'
			'Job
			'
			Me.Job.Expression = "[JobNumber] + ' - ' + [JobDescription]"
			Me.Job.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.Job.Name = "Job"
			'
			'Component
			'
			Me.Component.Expression = "[ComponentNumber] + ' - ' + [ComponentDescription]"
			Me.Component.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.Component.Name = "Component"
			'
			'SalesClass
			'
			Me.SalesClass.Expression = "[SalesClassCode] + ' - ' + [SalesClassDescription]"
			Me.SalesClass.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.SalesClass.Name = "SalesClass"
			'
			'CompFunction
			'
			Me.CompFunction.DisplayName = "Function"
			Me.CompFunction.Expression = "[FunctionCode] + ' - ' + [FunctionDescription]"
			Me.CompFunction.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.CompFunction.Name = "CompFunction"
			'
			'Client
			'
			Me.Client.Expression = "[ClientCode] + ' - ' + [ClientDescription]"
			Me.Client.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.Client.Name = "Client"
			'
			'Division
			'
			Me.Division.Expression = "[DivisionCode] + ' - ' + [DivisionDescription]"
			Me.Division.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.Division.Name = "Division"
			'
			'Product
			'
			Me.Product.Expression = "[ProductCode] + ' - ' + [ProductDescription]"
			Me.Product.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.Product.Name = "Product"
			'
			'StandardFeeBilled
			'
			Me.StandardFeeBilled.Expression = "Iif([FeeTimeType] = 'Standard Billed',  [FeeAmount], 0)"
			Me.StandardFeeBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.StandardFeeBilled.Name = "StandardFeeBilled"
			'
			'StandardTimePosted
			'
			Me.StandardTimePosted.Expression = "Iif([FeeTimeType] = 'Standard',  [TotalAmount], 0)"
			Me.StandardTimePosted.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.StandardTimePosted.Name = "StandardTimePosted"
			'
			'StandardVariance
			'
			Me.StandardVariance.Expression = "Iif([FeeTimeType] = 'Standard Billed',  [FeeAmount], 0) - Iif([FeeTimeType] = 'St" &
	"andard',  [TotalAmount], 0)"
			Me.StandardVariance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.StandardVariance.Name = "StandardVariance"
			'
			'ProductionFeeBilled
			'
			Me.ProductionFeeBilled.Expression = "Iif([FeeTimeType] = 'Production Billed',  [FeeAmount], 0)"
			Me.ProductionFeeBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.ProductionFeeBilled.Name = "ProductionFeeBilled"
			'
			'ProductionTimePosted
			'
			Me.ProductionTimePosted.Expression = "Iif([FeeTimeType] = 'Production',  [TotalAmount], 0)"
			Me.ProductionTimePosted.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.ProductionTimePosted.Name = "ProductionTimePosted"
			'
			'ProductionVariance
			'
			Me.ProductionVariance.Expression = "Iif([FeeTimeType] = 'Production Billed',  [FeeAmount], 0) - Iif([FeeTimeType] = '" &
	"Production',  [TotalAmount], 0)"
			Me.ProductionVariance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.ProductionVariance.Name = "ProductionVariance"
			'
			'MediaFeeBilled
			'
			Me.MediaFeeBilled.Expression = "Iif([FeeTimeType] = 'Media Billed',  [FeeAmount], 0)"
			Me.MediaFeeBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.MediaFeeBilled.Name = "MediaFeeBilled"
			'
			'MediaTimePosted
			'
			Me.MediaTimePosted.Expression = "Iif([FeeTimeType] = 'Media',  [TotalAmount], 0)"
			Me.MediaTimePosted.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.MediaTimePosted.Name = "MediaTimePosted"
			'
			'MediaVariance
			'
			Me.MediaVariance.Expression = "Iif([FeeTimeType] = 'Media Billed',  [FeeAmount], 0) - Iif([FeeTimeType] = 'Media" &
	"',  [TotalAmount], 0)"
			Me.MediaVariance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.MediaVariance.Name = "MediaVariance"
			'
			'TotalFeeBilled
			'
			Me.TotalFeeBilled.Expression = "Iif(Contains([FeeTimeType], 'Billed'),  [FeeAmount], 0)"
			Me.TotalFeeBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.TotalFeeBilled.Name = "TotalFeeBilled"
			'
			'TotalTimePosted
			'
			Me.TotalTimePosted.Expression = "Iif(Contains([FeeTimeType], 'Billed') == False,  [TotalAmount], 0)"
			Me.TotalTimePosted.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.TotalTimePosted.Name = "TotalTimePosted"
			'
			'TotalVariance
			'
			Me.TotalVariance.Expression = "Iif(Contains([FeeTimeType], 'Billed'),  [FeeAmount], 0) - Iif(Contains([FeeTimeTy" &
	"pe], 'Billed') == False,  [TotalAmount], 0)"
			Me.TotalVariance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
			Me.TotalVariance.Name = "TotalVariance"
			'
			'GroupHeaderDetail
			'
			Me.GroupHeaderDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_FeesPosted, Me.TableGroupHeaderDetail_Header})
			Me.GroupHeaderDetail.Dpi = 100.0!
			Me.GroupHeaderDetail.HeightF = 42.0!
			Me.GroupHeaderDetail.KeepTogether = True
			Me.GroupHeaderDetail.Name = "GroupHeaderDetail"
			'
			'LabelDetail_FeesPosted
			'
			Me.LabelDetail_FeesPosted.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_FeesPosted.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_FeesPosted.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.LabelDetail_FeesPosted.BorderWidth = 1.0!
			Me.LabelDetail_FeesPosted.Dpi = 100.0!
			Me.LabelDetail_FeesPosted.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_FeesPosted.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_FeesPosted.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
			Me.LabelDetail_FeesPosted.Name = "LabelDetail_FeesPosted"
			Me.LabelDetail_FeesPosted.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelDetail_FeesPosted.SizeF = New System.Drawing.SizeF(700.0!, 21.0!)
			Me.LabelDetail_FeesPosted.StylePriority.UseBorders = False
			Me.LabelDetail_FeesPosted.StylePriority.UseFont = False
			Me.LabelDetail_FeesPosted.StylePriority.UseTextAlignment = False
			Me.LabelDetail_FeesPosted.Text = "Fees Billed"
			Me.LabelDetail_FeesPosted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			'
			'TableGroupHeaderDetail_Header
			'
			Me.TableGroupHeaderDetail_Header.Dpi = 100.0!
			Me.TableGroupHeaderDetail_Header.Font = New System.Drawing.Font("Arial", 7.0!)
			Me.TableGroupHeaderDetail_Header.KeepTogether = True
			Me.TableGroupHeaderDetail_Header.LocationFloat = New DevExpress.Utils.PointFloat(0!, 21.0!)
			Me.TableGroupHeaderDetail_Header.Name = "TableGroupHeaderDetail_Header"
			Me.TableGroupHeaderDetail_Header.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.TableRowHeader_Header})
			Me.TableGroupHeaderDetail_Header.SizeF = New System.Drawing.SizeF(700.0!, 21.0!)
			Me.TableGroupHeaderDetail_Header.StylePriority.UseFont = False
			'
			'TableRowHeader_Header
			'
			Me.TableRowHeader_Header.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellHeader_FeeDate, Me.TableCellHeader_Description, Me.TableCellHeader_FeeQuantity, Me.TableCellHeader_FeeAmount, Me.TableCellHeader_FeeTimeType})
			Me.TableRowHeader_Header.Dpi = 100.0!
			Me.TableRowHeader_Header.Name = "TableRowHeader_Header"
			Me.TableRowHeader_Header.Weight = 0.70736844377597019R
			'
			'TableCellHeader_FeeDate
			'
			Me.TableCellHeader_FeeDate.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.TableCellHeader_FeeDate.Dpi = 100.0!
			Me.TableCellHeader_FeeDate.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.TableCellHeader_FeeDate.KeepTogether = True
			Me.TableCellHeader_FeeDate.Name = "TableCellHeader_FeeDate"
			Me.TableCellHeader_FeeDate.StylePriority.UseBorders = False
			Me.TableCellHeader_FeeDate.StylePriority.UseFont = False
			Me.TableCellHeader_FeeDate.StylePriority.UseTextAlignment = False
			Me.TableCellHeader_FeeDate.Text = "Fee Date"
			Me.TableCellHeader_FeeDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellHeader_FeeDate.Weight = 0.29504374094609637R
			'
			'TableCellHeader_Description
			'
			Me.TableCellHeader_Description.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.TableCellHeader_Description.CanGrow = False
			Me.TableCellHeader_Description.Dpi = 100.0!
			Me.TableCellHeader_Description.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.TableCellHeader_Description.KeepTogether = True
			Me.TableCellHeader_Description.Name = "TableCellHeader_Description"
			Me.TableCellHeader_Description.StylePriority.UseBorders = False
			Me.TableCellHeader_Description.StylePriority.UseFont = False
			Me.TableCellHeader_Description.StylePriority.UseTextAlignment = False
			Me.TableCellHeader_Description.Text = "Description"
			Me.TableCellHeader_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellHeader_Description.Weight = 1.3276968943067564R
			'
			'TableCellHeader_FeeQuantity
			'
			Me.TableCellHeader_FeeQuantity.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.TableCellHeader_FeeQuantity.CanGrow = False
			Me.TableCellHeader_FeeQuantity.Dpi = 100.0!
			Me.TableCellHeader_FeeQuantity.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.TableCellHeader_FeeQuantity.KeepTogether = True
			Me.TableCellHeader_FeeQuantity.Name = "TableCellHeader_FeeQuantity"
			Me.TableCellHeader_FeeQuantity.StylePriority.UseBorders = False
			Me.TableCellHeader_FeeQuantity.StylePriority.UseFont = False
			Me.TableCellHeader_FeeQuantity.StylePriority.UseTextAlignment = False
			Me.TableCellHeader_FeeQuantity.Text = "Fee Hrs\Qty"
			Me.TableCellHeader_FeeQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellHeader_FeeQuantity.Weight = 0.44256561254418236R
			'
			'TableCellHeader_FeeAmount
			'
			Me.TableCellHeader_FeeAmount.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.TableCellHeader_FeeAmount.CanGrow = False
			Me.TableCellHeader_FeeAmount.Dpi = 100.0!
			Me.TableCellHeader_FeeAmount.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.TableCellHeader_FeeAmount.KeepTogether = True
			Me.TableCellHeader_FeeAmount.Name = "TableCellHeader_FeeAmount"
			Me.TableCellHeader_FeeAmount.StylePriority.UseBorders = False
			Me.TableCellHeader_FeeAmount.StylePriority.UseFont = False
			Me.TableCellHeader_FeeAmount.StylePriority.UseTextAlignment = False
			Me.TableCellHeader_FeeAmount.Text = "Fee Amount"
			Me.TableCellHeader_FeeAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellHeader_FeeAmount.Weight = 0.44256561309297276R
			'
			'TableCellHeader_FeeTimeType
			'
			Me.TableCellHeader_FeeTimeType.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.TableCellHeader_FeeTimeType.Dpi = 100.0!
			Me.TableCellHeader_FeeTimeType.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.TableCellHeader_FeeTimeType.Name = "TableCellHeader_FeeTimeType"
			Me.TableCellHeader_FeeTimeType.StylePriority.UseBorders = False
			Me.TableCellHeader_FeeTimeType.StylePriority.UseFont = False
			Me.TableCellHeader_FeeTimeType.StylePriority.UseTextAlignment = False
			Me.TableCellHeader_FeeTimeType.Text = "Fee Time Type"
			Me.TableCellHeader_FeeTimeType.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellHeader_FeeTimeType.Weight = 1.6227406236955466R
			'
			'GroupFooterDetail
			'
			Me.GroupFooterDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LineGroupFooterDetail_Line, Me.LabelGroupFooterDetail_FeeAmount, Me.LabelGroupFooterDetail_Totals, Me.LabelGroupFooterDetail_FeeQuantity})
			Me.GroupFooterDetail.Dpi = 100.0!
			Me.GroupFooterDetail.HeightF = 23.00001!
			Me.GroupFooterDetail.KeepTogether = True
			Me.GroupFooterDetail.Name = "GroupFooterDetail"
			'
			'LineGroupFooterDetail_Line
			'
			Me.LineGroupFooterDetail_Line.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Dash
			Me.LineGroupFooterDetail_Line.Dpi = 100.0!
			Me.LineGroupFooterDetail_Line.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash
			Me.LineGroupFooterDetail_Line.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
			Me.LineGroupFooterDetail_Line.Name = "LineGroupFooterDetail_Line"
			Me.LineGroupFooterDetail_Line.SizeF = New System.Drawing.SizeF(700.0!, 2.0!)
			Me.LineGroupFooterDetail_Line.StylePriority.UseBorderDashStyle = False
			'
			'LabelGroupFooterDetail_FeeAmount
			'
			Me.LabelGroupFooterDetail_FeeAmount.CanGrow = False
			Me.LabelGroupFooterDetail_FeeAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FeeAmount")})
			Me.LabelGroupFooterDetail_FeeAmount.Dpi = 100.0!
			Me.LabelGroupFooterDetail_FeeAmount.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.LabelGroupFooterDetail_FeeAmount.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 2.000014!)
			Me.LabelGroupFooterDetail_FeeAmount.Name = "LabelGroupFooterDetail_FeeAmount"
			Me.LabelGroupFooterDetail_FeeAmount.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.LabelGroupFooterDetail_FeeAmount.SizeF = New System.Drawing.SizeF(75.00009!, 21.0!)
			Me.LabelGroupFooterDetail_FeeAmount.StylePriority.UseFont = False
			Me.LabelGroupFooterDetail_FeeAmount.StylePriority.UseTextAlignment = False
			XrSummary5.FormatString = "{0:c2}"
			XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.LabelGroupFooterDetail_FeeAmount.Summary = XrSummary5
			Me.LabelGroupFooterDetail_FeeAmount.Text = "LabelGroupFooterDetail_FeeAmount"
			Me.LabelGroupFooterDetail_FeeAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			'
			'LabelGroupFooterDetail_Totals
			'
			Me.LabelGroupFooterDetail_Totals.Dpi = 100.0!
			Me.LabelGroupFooterDetail_Totals.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.LabelGroupFooterDetail_Totals.LocationFloat = New DevExpress.Utils.PointFloat(50.0!, 2.000014!)
			Me.LabelGroupFooterDetail_Totals.Name = "LabelGroupFooterDetail_Totals"
			Me.LabelGroupFooterDetail_Totals.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.LabelGroupFooterDetail_Totals.SizeF = New System.Drawing.SizeF(225.0001!, 21.0!)
			Me.LabelGroupFooterDetail_Totals.StylePriority.UseFont = False
			Me.LabelGroupFooterDetail_Totals.StylePriority.UseTextAlignment = False
			Me.LabelGroupFooterDetail_Totals.Text = "Totals:"
			Me.LabelGroupFooterDetail_Totals.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
			'
			'LabelGroupFooterDetail_FeeQuantity
			'
			Me.LabelGroupFooterDetail_FeeQuantity.CanGrow = False
			Me.LabelGroupFooterDetail_FeeQuantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FeeQuantity")})
			Me.LabelGroupFooterDetail_FeeQuantity.Dpi = 100.0!
			Me.LabelGroupFooterDetail_FeeQuantity.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.LabelGroupFooterDetail_FeeQuantity.LocationFloat = New DevExpress.Utils.PointFloat(275.0!, 2.000014!)
			Me.LabelGroupFooterDetail_FeeQuantity.Name = "LabelGroupFooterDetail_FeeQuantity"
			Me.LabelGroupFooterDetail_FeeQuantity.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
			Me.LabelGroupFooterDetail_FeeQuantity.SizeF = New System.Drawing.SizeF(75.0!, 21.0!)
			Me.LabelGroupFooterDetail_FeeQuantity.StylePriority.UseFont = False
			Me.LabelGroupFooterDetail_FeeQuantity.StylePriority.UseTextAlignment = False
			XrSummary6.FormatString = "{0:n2}"
			XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.LabelGroupFooterDetail_FeeQuantity.Summary = XrSummary6
			Me.LabelGroupFooterDetail_FeeQuantity.Text = "LabelGroupFooterDetail_FeeQuantity"
			Me.LabelGroupFooterDetail_FeeQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
			'IsServiceFeeJob
			'
			Me.IsServiceFeeJob.Expression = "Iif([IsServiceFeeJob] = True, 'Yes' , 'No' )"
			Me.IsServiceFeeJob.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
			Me.IsServiceFeeJob.Name = "IsServiceFeeJob"
			'
			'ServiceFeeReconciliationFeeDetailSubReport
			'
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeaderDetail, Me.GroupFooterDetail})
			Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Campaign, Me.Job, Me.Component, Me.SalesClass, Me.CompFunction, Me.Client, Me.Division, Me.Product, Me.StandardFeeBilled, Me.StandardTimePosted, Me.StandardVariance, Me.ProductionFeeBilled, Me.ProductionTimePosted, Me.ProductionVariance, Me.MediaFeeBilled, Me.MediaTimePosted, Me.MediaVariance, Me.TotalFeeBilled, Me.TotalTimePosted, Me.TotalVariance, Me.IsServiceFeeJob})
			Me.DataSource = Me.BindingSource
			Me.Font = New System.Drawing.Font("Arial", 9.75!)
			Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
			Me.Margins = New System.Drawing.Printing.Margins(75, 75, 0, 0)
			Me.ReportPrintOptions.PrintOnEmptyDataSource = False
			Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
			Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.XrControlStyle1})
			Me.Version = "16.2"
			CType(Me.TableDetail_Details, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.TableGroupHeaderDetail_Header, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

		End Sub
		Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Campaign As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Job As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Component As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents SalesClass As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CompFunction As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Client As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Division As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Product As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents StandardFeeBilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents StandardTimePosted As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents StandardVariance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ProductionFeeBilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ProductionTimePosted As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents ProductionVariance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents MediaFeeBilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents MediaTimePosted As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents MediaVariance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TotalFeeBilled As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TotalTimePosted As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TotalVariance As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents GroupHeaderDetail As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterDetail As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents IsServiceFeeJob As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TableGroupHeaderDetail_Header As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents TableRowHeader_Header As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellHeader_FeeDate As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_Description As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FeeQuantity As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FeeAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FeeTimeType As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableDetail_Details As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents TableRowDetails_Details As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellDetails_FeeDate As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_Description As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_FeeQuantity As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_FeeAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_FeeTimeType As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents LineGroupFooterDetail_Line As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelGroupFooterDetail_FeeAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterDetail_Totals As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterDetail_FeeQuantity As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelDetail_FeesPosted As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
