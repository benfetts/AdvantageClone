Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ServiceFeeReconciliationTimeDetailSubReport
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
			Me.TableCellDetails_TotalHours = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellDetails_TotalAmount = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellDetails_FeeTimeType = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
			Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
			Me.Campaign = New DevExpress.XtraReports.UI.CalculatedField()
			Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.Job = New DevExpress.XtraReports.UI.CalculatedField()
			Me.Component = New DevExpress.XtraReports.UI.CalculatedField()
			Me.SalesClass = New DevExpress.XtraReports.UI.CalculatedField()
			Me.CompFunction = New DevExpress.XtraReports.UI.CalculatedField()
			Me.TableGroupHeaderDetail_Header = New DevExpress.XtraReports.UI.XRTable()
			Me.TableRowHeader_Header = New DevExpress.XtraReports.UI.XRTableRow()
			Me.TableCellHeader_FeeDate = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellHeader_Description = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellHeader_TotalHours = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellHeader_TotalAmount = New DevExpress.XtraReports.UI.XRTableCell()
			Me.TableCellHeader_FeeTimeType = New DevExpress.XtraReports.UI.XRTableCell()
			Me.LabelGroupFooterDetail_TotalAmount = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupFooterDetail_TotalHours = New DevExpress.XtraReports.UI.XRLabel()
			Me.LabelGroupFooterDetail_Totals = New DevExpress.XtraReports.UI.XRLabel()
			Me.LineGroupFooterDetail_Line = New DevExpress.XtraReports.UI.XRLine()
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
			Me.LabelDetail_TimePosted = New DevExpress.XtraReports.UI.XRLabel()
			Me.GroupFooterDetail = New DevExpress.XtraReports.UI.GroupFooterBand()
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
			Me.TableRowDetails_Details.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellDetails_FeeDate, Me.TableCellDetails_Description, Me.TableCellDetails_TotalHours, Me.TableCellDetails_TotalAmount, Me.TableCellDetails_FeeTimeType})
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
			Me.TableCellDetails_FeeDate.Weight = 0.29373245851953289R
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
			Me.TableCellDetails_Description.Weight = 1.3217962891036228R
			Me.TableCellDetails_Description.WordWrap = False
			'
			'TableCellDetails_TotalHours
			'
			Me.TableCellDetails_TotalHours.CanGrow = False
			Me.TableCellDetails_TotalHours.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalHours", "{0:n2}")})
			Me.TableCellDetails_TotalHours.Dpi = 100.0!
			Me.TableCellDetails_TotalHours.Font = New System.Drawing.Font("Arial", 7.0!)
			Me.TableCellDetails_TotalHours.KeepTogether = True
			Me.TableCellDetails_TotalHours.Name = "TableCellDetails_TotalHours"
			Me.TableCellDetails_TotalHours.StylePriority.UseFont = False
			Me.TableCellDetails_TotalHours.StylePriority.UseTextAlignment = False
			XrSummary3.FormatString = "{0:n2}"
			Me.TableCellDetails_TotalHours.Summary = XrSummary3
			Me.TableCellDetails_TotalHours.Text = "TableCellDetails_TotalHours"
			Me.TableCellDetails_TotalHours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellDetails_TotalHours.Weight = 0.44059853176287678R
			Me.TableCellDetails_TotalHours.WordWrap = False
			'
			'TableCellDetails_TotalAmount
			'
			Me.TableCellDetails_TotalAmount.CanGrow = False
			Me.TableCellDetails_TotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount", "{0:n2}")})
			Me.TableCellDetails_TotalAmount.Dpi = 100.0!
			Me.TableCellDetails_TotalAmount.Font = New System.Drawing.Font("Arial", 7.0!)
			Me.TableCellDetails_TotalAmount.KeepTogether = True
			Me.TableCellDetails_TotalAmount.Name = "TableCellDetails_TotalAmount"
			Me.TableCellDetails_TotalAmount.StylePriority.UseFont = False
			Me.TableCellDetails_TotalAmount.StylePriority.UseTextAlignment = False
			XrSummary4.FormatString = "{0:n2}"
			Me.TableCellDetails_TotalAmount.Summary = XrSummary4
			Me.TableCellDetails_TotalAmount.Text = "TableCellDetails_TotalAmount"
			Me.TableCellDetails_TotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellDetails_TotalAmount.Weight = 0.44059887789569074R
			Me.TableCellDetails_TotalAmount.WordWrap = False
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
			Me.TableCellDetails_FeeTimeType.Weight = 1.6155284357362212R
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
			Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Classes.ServiceFeeReconcileDetail)
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
			Me.TableRowHeader_Header.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellHeader_FeeDate, Me.TableCellHeader_Description, Me.TableCellHeader_TotalHours, Me.TableCellHeader_TotalAmount, Me.TableCellHeader_FeeTimeType})
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
			Me.TableCellHeader_FeeDate.Weight = 0.295043763456148R
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
			Me.TableCellHeader_Description.Weight = 1.327696871796705R
			'
			'TableCellHeader_TotalHours
			'
			Me.TableCellHeader_TotalHours.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.TableCellHeader_TotalHours.CanGrow = False
			Me.TableCellHeader_TotalHours.Dpi = 100.0!
			Me.TableCellHeader_TotalHours.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.TableCellHeader_TotalHours.KeepTogether = True
			Me.TableCellHeader_TotalHours.Name = "TableCellHeader_TotalHours"
			Me.TableCellHeader_TotalHours.StylePriority.UseBorders = False
			Me.TableCellHeader_TotalHours.StylePriority.UseFont = False
			Me.TableCellHeader_TotalHours.StylePriority.UseTextAlignment = False
			Me.TableCellHeader_TotalHours.Text = "Total Hrs\Qty"
			Me.TableCellHeader_TotalHours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellHeader_TotalHours.Weight = 0.44256561254418236R
			'
			'TableCellHeader_TotalAmount
			'
			Me.TableCellHeader_TotalAmount.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.TableCellHeader_TotalAmount.CanGrow = False
			Me.TableCellHeader_TotalAmount.Dpi = 100.0!
			Me.TableCellHeader_TotalAmount.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.TableCellHeader_TotalAmount.KeepTogether = True
			Me.TableCellHeader_TotalAmount.Name = "TableCellHeader_TotalAmount"
			Me.TableCellHeader_TotalAmount.StylePriority.UseBorders = False
			Me.TableCellHeader_TotalAmount.StylePriority.UseFont = False
			Me.TableCellHeader_TotalAmount.StylePriority.UseTextAlignment = False
			Me.TableCellHeader_TotalAmount.Text = "Total Amount"
			Me.TableCellHeader_TotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			Me.TableCellHeader_TotalAmount.Weight = 0.44256561309297265R
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
			'LabelGroupFooterDetail_TotalAmount
			'
			Me.LabelGroupFooterDetail_TotalAmount.CanGrow = False
			Me.LabelGroupFooterDetail_TotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
			Me.LabelGroupFooterDetail_TotalAmount.Dpi = 100.0!
			Me.LabelGroupFooterDetail_TotalAmount.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.LabelGroupFooterDetail_TotalAmount.LocationFloat = New DevExpress.Utils.PointFloat(350.0!, 2.000046!)
			Me.LabelGroupFooterDetail_TotalAmount.Name = "LabelGroupFooterDetail_TotalAmount"
			Me.LabelGroupFooterDetail_TotalAmount.SizeF = New System.Drawing.SizeF(75.00006!, 21.0!)
			Me.LabelGroupFooterDetail_TotalAmount.StylePriority.UseFont = False
			Me.LabelGroupFooterDetail_TotalAmount.StylePriority.UsePadding = False
			Me.LabelGroupFooterDetail_TotalAmount.StylePriority.UseTextAlignment = False
			XrSummary5.FormatString = "{0:c2}"
			XrSummary5.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.LabelGroupFooterDetail_TotalAmount.Summary = XrSummary5
			Me.LabelGroupFooterDetail_TotalAmount.Text = "LabelGroupFooterDetail_TotalAmount"
			Me.LabelGroupFooterDetail_TotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			'
			'LabelGroupFooterDetail_TotalHours
			'
			Me.LabelGroupFooterDetail_TotalHours.CanGrow = False
			Me.LabelGroupFooterDetail_TotalHours.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalHours")})
			Me.LabelGroupFooterDetail_TotalHours.Dpi = 100.0!
			Me.LabelGroupFooterDetail_TotalHours.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.LabelGroupFooterDetail_TotalHours.LocationFloat = New DevExpress.Utils.PointFloat(275.0002!, 2.000046!)
			Me.LabelGroupFooterDetail_TotalHours.Name = "LabelGroupFooterDetail_TotalHours"
			Me.LabelGroupFooterDetail_TotalHours.SizeF = New System.Drawing.SizeF(74.99997!, 21.0!)
			Me.LabelGroupFooterDetail_TotalHours.StylePriority.UseFont = False
			Me.LabelGroupFooterDetail_TotalHours.StylePriority.UsePadding = False
			Me.LabelGroupFooterDetail_TotalHours.StylePriority.UseTextAlignment = False
			XrSummary6.FormatString = "{0:n2}"
			XrSummary6.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
			Me.LabelGroupFooterDetail_TotalHours.Summary = XrSummary6
			Me.LabelGroupFooterDetail_TotalHours.Text = "0.00"
			Me.LabelGroupFooterDetail_TotalHours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			'
			'LabelGroupFooterDetail_Totals
			'
			Me.LabelGroupFooterDetail_Totals.Dpi = 100.0!
			Me.LabelGroupFooterDetail_Totals.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Bold)
			Me.LabelGroupFooterDetail_Totals.LocationFloat = New DevExpress.Utils.PointFloat(50.0!, 2.000046!)
			Me.LabelGroupFooterDetail_Totals.Name = "LabelGroupFooterDetail_Totals"
			Me.LabelGroupFooterDetail_Totals.SizeF = New System.Drawing.SizeF(225.0001!, 21.0!)
			Me.LabelGroupFooterDetail_Totals.StylePriority.UseFont = False
			Me.LabelGroupFooterDetail_Totals.StylePriority.UsePadding = False
			Me.LabelGroupFooterDetail_Totals.StylePriority.UseTextAlignment = False
			Me.LabelGroupFooterDetail_Totals.Text = "Totals:"
			Me.LabelGroupFooterDetail_Totals.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
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
			Me.GroupHeaderDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelDetail_TimePosted, Me.TableGroupHeaderDetail_Header})
			Me.GroupHeaderDetail.Dpi = 100.0!
			Me.GroupHeaderDetail.HeightF = 42.0!
			Me.GroupHeaderDetail.KeepTogether = True
			Me.GroupHeaderDetail.Name = "GroupHeaderDetail"
			'
			'LabelDetail_TimePosted
			'
			Me.LabelDetail_TimePosted.BackColor = System.Drawing.Color.Transparent
			Me.LabelDetail_TimePosted.BorderColor = System.Drawing.Color.Black
			Me.LabelDetail_TimePosted.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
			Me.LabelDetail_TimePosted.BorderWidth = 1.0!
			Me.LabelDetail_TimePosted.Dpi = 100.0!
			Me.LabelDetail_TimePosted.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
			Me.LabelDetail_TimePosted.ForeColor = System.Drawing.Color.Black
			Me.LabelDetail_TimePosted.LocationFloat = New DevExpress.Utils.PointFloat(0!, 0!)
			Me.LabelDetail_TimePosted.Name = "LabelDetail_TimePosted"
			Me.LabelDetail_TimePosted.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
			Me.LabelDetail_TimePosted.SizeF = New System.Drawing.SizeF(700.0!, 21.0!)
			Me.LabelDetail_TimePosted.StylePriority.UseBorders = False
			Me.LabelDetail_TimePosted.StylePriority.UseFont = False
			Me.LabelDetail_TimePosted.StylePriority.UseTextAlignment = False
			Me.LabelDetail_TimePosted.Text = "Time Posted"
			Me.LabelDetail_TimePosted.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
			'
			'GroupFooterDetail
			'
			Me.GroupFooterDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelGroupFooterDetail_Totals, Me.LineGroupFooterDetail_Line, Me.LabelGroupFooterDetail_TotalHours, Me.LabelGroupFooterDetail_TotalAmount})
			Me.GroupFooterDetail.Dpi = 100.0!
			Me.GroupFooterDetail.HeightF = 23.00005!
			Me.GroupFooterDetail.KeepTogether = True
			Me.GroupFooterDetail.Name = "GroupFooterDetail"
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
			'ServiceFeeReconciliationTimeDetailSubReport
			'
			Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeaderDetail, Me.GroupFooterDetail})
			Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Campaign, Me.Job, Me.Component, Me.SalesClass, Me.CompFunction, Me.Client, Me.Division, Me.Product, Me.StandardFeeBilled, Me.StandardTimePosted, Me.StandardVariance, Me.ProductionFeeBilled, Me.ProductionTimePosted, Me.ProductionVariance, Me.MediaFeeBilled, Me.MediaTimePosted, Me.MediaVariance, Me.TotalFeeBilled, Me.TotalTimePosted, Me.TotalVariance, Me.IsServiceFeeJob})
			Me.DataSource = Me.BindingSource
			Me.Font = New System.Drawing.Font("Arial", 7.0!)
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
        Friend WithEvents TableDetail_Details As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents TableRowDetails_Details As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellDetails_FeeDate As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_Description As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_TotalHours As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_TotalAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents Campaign As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Job As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Component As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents SalesClass As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents CompFunction As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Client As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Division As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents Product As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents LineGroupFooterDetail_Line As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents LabelGroupFooterDetail_Totals As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterDetail_TotalAmount As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelGroupFooterDetail_TotalHours As DevExpress.XtraReports.UI.XRLabel
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
        Friend WithEvents TableGroupHeaderDetail_Header As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents TableRowHeader_Header As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellHeader_FeeDate As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_Description As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_TotalHours As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_TotalAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents GroupHeaderDetail As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooterDetail As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents XrControlStyle1 As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents IsServiceFeeJob As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents TableCellDetails_FeeTimeType As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FeeTimeType As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Private WithEvents LabelDetail_TimePosted As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace
