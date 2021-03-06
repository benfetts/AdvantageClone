Namespace FinanceAndAccounting

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class ServiceFeeReconciliationDetailReport
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
            Dim XrSummary7 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary8 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary9 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Dim XrSummary10 As DevExpress.XtraReports.UI.XRSummary = New DevExpress.XtraReports.UI.XRSummary()
            Me.Detail = New DevExpress.XtraReports.UI.DetailBand()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.PageHeader = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.LabelPageHeader_FeesTimePostedFrom = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelPageHeader_FeesBilledFrom = New DevExpress.XtraReports.UI.XRLabel()
            Me.LinePageHeader_BottomLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LinePageHeader_TopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.LabelPageHeader_Title = New DevExpress.XtraReports.UI.XRLabel()
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
            Me.ControlStyle = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
            Me.IsServiceFeeJob = New DevExpress.XtraReports.UI.CalculatedField()
            Me.LabelClientDivisionProduct_ProductData = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelClientDivisionProduct_Division = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelClientDivisionProduct_Client = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelClientDivisionProduct_ClientData = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelClientDivisionProduct_DivisionData = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelClientDivisionProduct_Product = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderDetail = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.TableDetail_Details = New DevExpress.XtraReports.UI.XRTable()
            Me.TableRowDetails_Details = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellDetails_JobNumber = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_JobDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_ComponentNumber = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_ComponentDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_FunctionDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_CampaignDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_FunctionConsolidation = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_FunctionHeading = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_FeeQuantity = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_FeeAmount = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_TotalHours = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellDetails_TotalAmount = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableClientDivisionProduct_Header = New DevExpress.XtraReports.UI.XRTable()
            Me.TableRowHeader_Header = New DevExpress.XtraReports.UI.XRTableRow()
            Me.TableCellHeader_JobNumber = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_JobDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_ComponentNumber = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_ComponentDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_FunctionDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_CampaignDescription = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_FunctionConsolidation = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_FunctionHeading = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_FeeQuantity = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_FeeAmount = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_TotalHours = New DevExpress.XtraReports.UI.XRTableCell()
            Me.TableCellHeader_TotalAmount = New DevExpress.XtraReports.UI.XRTableCell()
            Me.SubreportDetail_FeesPosted = New DevExpress.XtraReports.UI.XRSubreport()
            Me.FeeDetailSubReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationFeeDetailSubReport()
            Me.SubreportDetail_TimePosted = New DevExpress.XtraReports.UI.XRSubreport()
            Me.TimeDetailSubReport = New AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationTimeDetailSubReport()
            Me.GroupHeaderClientDivisionProduct = New DevExpress.XtraReports.UI.GroupHeaderBand()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TableDetail_Details, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TableClientDivisionProduct_Header, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.FeeDetailSubReport, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TimeDetailSubReport, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.HeightF = 0.0!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'TopMargin
            '
            Me.TopMargin.HeightF = 0.0!
            Me.TopMargin.Name = "TopMargin"
            Me.TopMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'BottomMargin
            '
            Me.BottomMargin.HeightF = 0.0!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'PageHeader
            '
            Me.PageHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelPageHeader_FeesTimePostedFrom, Me.LabelPageHeader_FeesBilledFrom, Me.LinePageHeader_BottomLine, Me.LinePageHeader_TopLine, Me.LabelPageHeader_Title})
            Me.PageHeader.HeightF = 64.0!
            Me.PageHeader.Name = "PageHeader"
            '
            'LabelPageHeader_FeesTimePostedFrom
            '
            Me.LabelPageHeader_FeesTimePostedFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_FeesTimePostedFrom.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 37.0!)
            Me.LabelPageHeader_FeesTimePostedFrom.Name = "LabelPageHeader_FeesTimePostedFrom"
            Me.LabelPageHeader_FeesTimePostedFrom.SizeF = New System.Drawing.SizeF(400.0!, 23.0!)
            Me.LabelPageHeader_FeesTimePostedFrom.StylePriority.UseFont = False
            Me.LabelPageHeader_FeesTimePostedFrom.StylePriority.UsePadding = False
            Me.LabelPageHeader_FeesTimePostedFrom.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_FeesTimePostedFrom.Text = "Fees Time Posted from {0} to {1}"
            Me.LabelPageHeader_FeesTimePostedFrom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelPageHeader_FeesBilledFrom
            '
            Me.LabelPageHeader_FeesBilledFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
            Me.LabelPageHeader_FeesBilledFrom.LocationFloat = New DevExpress.Utils.PointFloat(500.0!, 14.0!)
            Me.LabelPageHeader_FeesBilledFrom.Name = "LabelPageHeader_FeesBilledFrom"
            Me.LabelPageHeader_FeesBilledFrom.SizeF = New System.Drawing.SizeF(400.0!, 23.0!)
            Me.LabelPageHeader_FeesBilledFrom.StylePriority.UseFont = False
            Me.LabelPageHeader_FeesBilledFrom.StylePriority.UsePadding = False
            Me.LabelPageHeader_FeesBilledFrom.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_FeesBilledFrom.Text = "Fees Billed from {0} to {1}"
            Me.LabelPageHeader_FeesBilledFrom.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LinePageHeader_BottomLine
            '
            Me.LinePageHeader_BottomLine.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_BottomLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_BottomLine.BorderWidth = 4
            Me.LinePageHeader_BottomLine.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_BottomLine.LineWidth = 4
            Me.LinePageHeader_BottomLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 60.0!)
            Me.LinePageHeader_BottomLine.Name = "LinePageHeader_BottomLine"
            Me.LinePageHeader_BottomLine.SizeF = New System.Drawing.SizeF(900.0!, 4.000004!)
            '
            'LinePageHeader_TopLine
            '
            Me.LinePageHeader_TopLine.BorderColor = System.Drawing.Color.Silver
            Me.LinePageHeader_TopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LinePageHeader_TopLine.BorderWidth = 4
            Me.LinePageHeader_TopLine.ForeColor = System.Drawing.Color.Silver
            Me.LinePageHeader_TopLine.LineWidth = 4
            Me.LinePageHeader_TopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 10.00001!)
            Me.LinePageHeader_TopLine.Name = "LinePageHeader_TopLine"
            Me.LinePageHeader_TopLine.SizeF = New System.Drawing.SizeF(900.0!, 4.000004!)
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
            Me.LabelPageHeader_Title.LocationFloat = New DevExpress.Utils.PointFloat(10.0001!, 14.0!)
            Me.LabelPageHeader_Title.Name = "LabelPageHeader_Title"
            Me.LabelPageHeader_Title.SizeF = New System.Drawing.SizeF(489.9999!, 46.0!)
            Me.LabelPageHeader_Title.StylePriority.UseFont = False
            Me.LabelPageHeader_Title.StylePriority.UseForeColor = False
            Me.LabelPageHeader_Title.StylePriority.UsePadding = False
            Me.LabelPageHeader_Title.StylePriority.UseTextAlignment = False
            Me.LabelPageHeader_Title.Text = "Service Fee Analysis Detail Report"
            Me.LabelPageHeader_Title.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'Campaign
            '
            Me.Campaign.DataSource = Me.BindingSource
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
            Me.Job.DataSource = Me.BindingSource
            Me.Job.Expression = "[JobNumber] + ' - ' + [JobDescription]"
            Me.Job.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.Job.Name = "Job"
            '
            'Component
            '
            Me.Component.DataSource = Me.BindingSource
            Me.Component.Expression = "[ComponentNumber] + ' - ' + [ComponentDescription]"
            Me.Component.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.Component.Name = "Component"
            '
            'SalesClass
            '
            Me.SalesClass.DataSource = Me.BindingSource
            Me.SalesClass.Expression = "[SalesClassCode] + ' - ' + [SalesClassDescription]"
            Me.SalesClass.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.SalesClass.Name = "SalesClass"
            '
            'CompFunction
            '
            Me.CompFunction.DataSource = Me.BindingSource
            Me.CompFunction.DisplayName = "Function"
            Me.CompFunction.Expression = "[FunctionCode] + ' - ' + [FunctionDescription]"
            Me.CompFunction.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.CompFunction.Name = "CompFunction"
            '
            'Client
            '
            Me.Client.DataSource = Me.BindingSource
            Me.Client.Expression = "[ClientCode] + ' - ' + [ClientDescription]"
            Me.Client.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.Client.Name = "Client"
            '
            'Division
            '
            Me.Division.DataSource = Me.BindingSource
            Me.Division.Expression = "[DivisionCode] + ' - ' + [DivisionDescription]"
            Me.Division.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.Division.Name = "Division"
            '
            'Product
            '
            Me.Product.DataSource = Me.BindingSource
            Me.Product.Expression = "[ProductCode] + ' - ' + [ProductDescription]"
            Me.Product.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.Product.Name = "Product"
            '
            'StandardFeeBilled
            '
            Me.StandardFeeBilled.DataSource = Me.BindingSource
            Me.StandardFeeBilled.Expression = "Iif([FeeTimeType] = 'Standard Billed',  [FeeAmount], 0)"
            Me.StandardFeeBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.StandardFeeBilled.Name = "StandardFeeBilled"
            '
            'StandardTimePosted
            '
            Me.StandardTimePosted.DataSource = Me.BindingSource
            Me.StandardTimePosted.Expression = "Iif([FeeTimeType] = 'Standard',  [TotalAmount], 0)"
            Me.StandardTimePosted.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.StandardTimePosted.Name = "StandardTimePosted"
            '
            'StandardVariance
            '
            Me.StandardVariance.DataSource = Me.BindingSource
            Me.StandardVariance.Expression = "Iif([FeeTimeType] = 'Standard Billed',  [FeeAmount], 0) - Iif([FeeTimeType] = 'St" & _
                "andard',  [TotalAmount], 0)"
            Me.StandardVariance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.StandardVariance.Name = "StandardVariance"
            '
            'ProductionFeeBilled
            '
            Me.ProductionFeeBilled.DataSource = Me.BindingSource
            Me.ProductionFeeBilled.Expression = "Iif([FeeTimeType] = 'Production Billed',  [FeeAmount], 0)"
            Me.ProductionFeeBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.ProductionFeeBilled.Name = "ProductionFeeBilled"
            '
            'ProductionTimePosted
            '
            Me.ProductionTimePosted.DataSource = Me.BindingSource
            Me.ProductionTimePosted.Expression = "Iif([FeeTimeType] = 'Production',  [TotalAmount], 0)"
            Me.ProductionTimePosted.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.ProductionTimePosted.Name = "ProductionTimePosted"
            '
            'ProductionVariance
            '
            Me.ProductionVariance.DataSource = Me.BindingSource
            Me.ProductionVariance.Expression = "Iif([FeeTimeType] = 'Production Billed',  [FeeAmount], 0) - Iif([FeeTimeType] = '" & _
                "Production',  [TotalAmount], 0)"
            Me.ProductionVariance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.ProductionVariance.Name = "ProductionVariance"
            '
            'MediaFeeBilled
            '
            Me.MediaFeeBilled.DataSource = Me.BindingSource
            Me.MediaFeeBilled.Expression = "Iif([FeeTimeType] = 'Media Billed',  [FeeAmount], 0)"
            Me.MediaFeeBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.MediaFeeBilled.Name = "MediaFeeBilled"
            '
            'MediaTimePosted
            '
            Me.MediaTimePosted.DataSource = Me.BindingSource
            Me.MediaTimePosted.Expression = "Iif([FeeTimeType] = 'Media',  [TotalAmount], 0)"
            Me.MediaTimePosted.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.MediaTimePosted.Name = "MediaTimePosted"
            '
            'MediaVariance
            '
            Me.MediaVariance.DataSource = Me.BindingSource
            Me.MediaVariance.Expression = "Iif([FeeTimeType] = 'Media Billed',  [FeeAmount], 0) - Iif([FeeTimeType] = 'Media" & _
                "',  [TotalAmount], 0)"
            Me.MediaVariance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.MediaVariance.Name = "MediaVariance"
            '
            'TotalFeeBilled
            '
            Me.TotalFeeBilled.DataSource = Me.BindingSource
            Me.TotalFeeBilled.Expression = "Iif(Contains([FeeTimeType], 'Billed'),  [FeeAmount], 0)"
            Me.TotalFeeBilled.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.TotalFeeBilled.Name = "TotalFeeBilled"
            '
            'TotalTimePosted
            '
            Me.TotalTimePosted.DataSource = Me.BindingSource
            Me.TotalTimePosted.Expression = "Iif(Contains([FeeTimeType], 'Billed') == False,  [TotalAmount], 0)"
            Me.TotalTimePosted.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.TotalTimePosted.Name = "TotalTimePosted"
            '
            'TotalVariance
            '
            Me.TotalVariance.DataSource = Me.BindingSource
            Me.TotalVariance.Expression = "Iif(Contains([FeeTimeType], 'Billed'),  [FeeAmount], 0) - Iif(Contains([FeeTimeTy" & _
                "pe], 'Billed') == False,  [TotalAmount], 0)"
            Me.TotalVariance.FieldType = DevExpress.XtraReports.UI.FieldType.[Decimal]
            Me.TotalVariance.Name = "TotalVariance"
            '
            'ControlStyle
            '
            Me.ControlStyle.Name = "ControlStyle"
            Me.ControlStyle.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            '
            'FormattingRule1
            '
            Me.FormattingRule1.Name = "FormattingRule1"
            '
            'IsServiceFeeJob
            '
            Me.IsServiceFeeJob.DataSource = Me.BindingSource
            Me.IsServiceFeeJob.Expression = "Iif([IsServiceFeeJob] = True, 'Yes' , 'No' )"
            Me.IsServiceFeeJob.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.IsServiceFeeJob.Name = "IsServiceFeeJob"
            '
            'LabelClientDivisionProduct_ProductData
            '
            Me.LabelClientDivisionProduct_ProductData.BackColor = System.Drawing.Color.Transparent
            Me.LabelClientDivisionProduct_ProductData.BorderColor = System.Drawing.Color.Black
            Me.LabelClientDivisionProduct_ProductData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelClientDivisionProduct_ProductData.BorderWidth = 1
            Me.LabelClientDivisionProduct_ProductData.CanGrow = False
            Me.LabelClientDivisionProduct_ProductData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ProductDescription")})
            Me.LabelClientDivisionProduct_ProductData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelClientDivisionProduct_ProductData.LocationFloat = New DevExpress.Utils.PointFloat(67.50005!, 50.00003!)
            Me.LabelClientDivisionProduct_ProductData.Name = "LabelClientDivisionProduct_ProductData"
            Me.LabelClientDivisionProduct_ProductData.SizeF = New System.Drawing.SizeF(420.0!, 20.0!)
            Me.LabelClientDivisionProduct_ProductData.StylePriority.UseFont = False
            Me.LabelClientDivisionProduct_ProductData.StylePriority.UsePadding = False
            Me.LabelClientDivisionProduct_ProductData.StylePriority.UseTextAlignment = False
            XrSummary1.FormatString = "{0}"
            Me.LabelClientDivisionProduct_ProductData.Summary = XrSummary1
            Me.LabelClientDivisionProduct_ProductData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelClientDivisionProduct_Division
            '
            Me.LabelClientDivisionProduct_Division.BackColor = System.Drawing.Color.Transparent
            Me.LabelClientDivisionProduct_Division.BorderColor = System.Drawing.Color.Black
            Me.LabelClientDivisionProduct_Division.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelClientDivisionProduct_Division.BorderWidth = 1
            Me.LabelClientDivisionProduct_Division.CanGrow = False
            Me.LabelClientDivisionProduct_Division.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelClientDivisionProduct_Division.ForeColor = System.Drawing.Color.Black
            Me.LabelClientDivisionProduct_Division.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 30.00005!)
            Me.LabelClientDivisionProduct_Division.Name = "LabelClientDivisionProduct_Division"
            Me.LabelClientDivisionProduct_Division.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
            Me.LabelClientDivisionProduct_Division.StylePriority.UseFont = False
            Me.LabelClientDivisionProduct_Division.StylePriority.UsePadding = False
            Me.LabelClientDivisionProduct_Division.StylePriority.UseTextAlignment = False
            Me.LabelClientDivisionProduct_Division.Text = "Division:"
            Me.LabelClientDivisionProduct_Division.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelClientDivisionProduct_Client
            '
            Me.LabelClientDivisionProduct_Client.BackColor = System.Drawing.Color.Transparent
            Me.LabelClientDivisionProduct_Client.BorderColor = System.Drawing.Color.Black
            Me.LabelClientDivisionProduct_Client.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelClientDivisionProduct_Client.BorderWidth = 1
            Me.LabelClientDivisionProduct_Client.CanGrow = False
            Me.LabelClientDivisionProduct_Client.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelClientDivisionProduct_Client.ForeColor = System.Drawing.Color.Black
            Me.LabelClientDivisionProduct_Client.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 10.00001!)
            Me.LabelClientDivisionProduct_Client.Name = "LabelClientDivisionProduct_Client"
            Me.LabelClientDivisionProduct_Client.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
            Me.LabelClientDivisionProduct_Client.StylePriority.UseFont = False
            Me.LabelClientDivisionProduct_Client.StylePriority.UsePadding = False
            Me.LabelClientDivisionProduct_Client.StylePriority.UseTextAlignment = False
            Me.LabelClientDivisionProduct_Client.Text = "Client:"
            Me.LabelClientDivisionProduct_Client.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelClientDivisionProduct_ClientData
            '
            Me.LabelClientDivisionProduct_ClientData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ClientDescription")})
            Me.LabelClientDivisionProduct_ClientData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelClientDivisionProduct_ClientData.LocationFloat = New DevExpress.Utils.PointFloat(67.50005!, 9.999974!)
            Me.LabelClientDivisionProduct_ClientData.Name = "LabelClientDivisionProduct_ClientData"
            Me.LabelClientDivisionProduct_ClientData.SizeF = New System.Drawing.SizeF(420.0!, 20.0!)
            Me.LabelClientDivisionProduct_ClientData.StylePriority.UseFont = False
            Me.LabelClientDivisionProduct_ClientData.StylePriority.UsePadding = False
            Me.LabelClientDivisionProduct_ClientData.StylePriority.UseTextAlignment = False
            Me.LabelClientDivisionProduct_ClientData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelClientDivisionProduct_DivisionData
            '
            Me.LabelClientDivisionProduct_DivisionData.BackColor = System.Drawing.Color.Transparent
            Me.LabelClientDivisionProduct_DivisionData.BorderColor = System.Drawing.Color.Black
            Me.LabelClientDivisionProduct_DivisionData.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelClientDivisionProduct_DivisionData.BorderWidth = 1
            Me.LabelClientDivisionProduct_DivisionData.CanGrow = False
            Me.LabelClientDivisionProduct_DivisionData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "DivisionDescription")})
            Me.LabelClientDivisionProduct_DivisionData.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelClientDivisionProduct_DivisionData.LocationFloat = New DevExpress.Utils.PointFloat(67.50005!, 30.00005!)
            Me.LabelClientDivisionProduct_DivisionData.Name = "LabelClientDivisionProduct_DivisionData"
            Me.LabelClientDivisionProduct_DivisionData.SizeF = New System.Drawing.SizeF(420.0!, 20.0!)
            Me.LabelClientDivisionProduct_DivisionData.StylePriority.UseFont = False
            Me.LabelClientDivisionProduct_DivisionData.StylePriority.UsePadding = False
            Me.LabelClientDivisionProduct_DivisionData.StylePriority.UseTextAlignment = False
            XrSummary2.FormatString = "{0}"
            Me.LabelClientDivisionProduct_DivisionData.Summary = XrSummary2
            Me.LabelClientDivisionProduct_DivisionData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'LabelClientDivisionProduct_Product
            '
            Me.LabelClientDivisionProduct_Product.BackColor = System.Drawing.Color.Transparent
            Me.LabelClientDivisionProduct_Product.BorderColor = System.Drawing.Color.Black
            Me.LabelClientDivisionProduct_Product.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LabelClientDivisionProduct_Product.BorderWidth = 1
            Me.LabelClientDivisionProduct_Product.CanGrow = False
            Me.LabelClientDivisionProduct_Product.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelClientDivisionProduct_Product.ForeColor = System.Drawing.Color.Black
            Me.LabelClientDivisionProduct_Product.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 50.00006!)
            Me.LabelClientDivisionProduct_Product.Name = "LabelClientDivisionProduct_Product"
            Me.LabelClientDivisionProduct_Product.SizeF = New System.Drawing.SizeF(55.0!, 20.0!)
            Me.LabelClientDivisionProduct_Product.StylePriority.UseFont = False
            Me.LabelClientDivisionProduct_Product.StylePriority.UsePadding = False
            Me.LabelClientDivisionProduct_Product.StylePriority.UseTextAlignment = False
            Me.LabelClientDivisionProduct_Product.Text = "Product:"
            Me.LabelClientDivisionProduct_Product.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'GroupHeaderDetail
            '
            Me.GroupHeaderDetail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.TableDetail_Details, Me.TableClientDivisionProduct_Header, Me.SubreportDetail_FeesPosted, Me.SubreportDetail_TimePosted})
            Me.GroupHeaderDetail.HeightF = 94.49997!
            Me.GroupHeaderDetail.KeepTogether = True
            Me.GroupHeaderDetail.Name = "GroupHeaderDetail"
            '
            'TableDetail_Details
            '
            Me.TableDetail_Details.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.TableDetail_Details.KeepTogether = True
            Me.TableDetail_Details.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 28.00001!)
            Me.TableDetail_Details.Name = "TableDetail_Details"
            Me.TableDetail_Details.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.TableRowDetails_Details})
            Me.TableDetail_Details.SizeF = New System.Drawing.SizeF(875.0!, 21.0!)
            Me.TableDetail_Details.StylePriority.UseFont = False
            '
            'TableRowDetails_Details
            '
            Me.TableRowDetails_Details.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellDetails_JobNumber, Me.TableCellDetails_JobDescription, Me.TableCellDetails_ComponentNumber, Me.TableCellDetails_ComponentDescription, Me.TableCellDetails_FunctionDescription, Me.TableCellDetails_CampaignDescription, Me.TableCellDetails_FunctionConsolidation, Me.TableCellDetails_FunctionHeading, Me.TableCellDetails_FeeQuantity, Me.TableCellDetails_FeeAmount, Me.TableCellDetails_TotalHours, Me.TableCellDetails_TotalAmount})
            Me.TableRowDetails_Details.Name = "TableRowDetails_Details"
            Me.TableRowDetails_Details.Weight = 0.5305263328319777R
            '
            'TableCellDetails_JobNumber
            '
            Me.TableCellDetails_JobNumber.CanGrow = False
            Me.TableCellDetails_JobNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobNumber", "{0:00000#}")})
            Me.TableCellDetails_JobNumber.KeepTogether = True
            Me.TableCellDetails_JobNumber.Name = "TableCellDetails_JobNumber"
            Me.TableCellDetails_JobNumber.StylePriority.UseTextAlignment = False
            XrSummary3.FormatString = "{0:00000#}"
            XrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
            XrSummary3.IgnoreNullValues = True
            Me.TableCellDetails_JobNumber.Summary = XrSummary3
            Me.TableCellDetails_JobNumber.Text = "TableCellDetails_JobNumber"
            Me.TableCellDetails_JobNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellDetails_JobNumber.Weight = 0.21340567014262285R
            Me.TableCellDetails_JobNumber.WordWrap = False
            '
            'TableCellDetails_JobDescription
            '
            Me.TableCellDetails_JobDescription.CanGrow = False
            Me.TableCellDetails_JobDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobDescription")})
            Me.TableCellDetails_JobDescription.KeepTogether = True
            Me.TableCellDetails_JobDescription.Name = "TableCellDetails_JobDescription"
            Me.TableCellDetails_JobDescription.StylePriority.UseTextAlignment = False
            Me.TableCellDetails_JobDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellDetails_JobDescription.Weight = 0.26675696976126773R
            Me.TableCellDetails_JobDescription.WordWrap = False
            '
            'TableCellDetails_ComponentNumber
            '
            Me.TableCellDetails_ComponentNumber.CanGrow = False
            Me.TableCellDetails_ComponentNumber.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ComponentNumber", "{0:0#}")})
            Me.TableCellDetails_ComponentNumber.KeepTogether = True
            Me.TableCellDetails_ComponentNumber.Name = "TableCellDetails_ComponentNumber"
            Me.TableCellDetails_ComponentNumber.StylePriority.UseTextAlignment = False
            XrSummary4.FormatString = "{0:0#}"
            XrSummary4.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
            XrSummary4.IgnoreNullValues = True
            Me.TableCellDetails_ComponentNumber.Summary = XrSummary4
            Me.TableCellDetails_ComponentNumber.Text = "TableCellDetails_ComponentNumber"
            Me.TableCellDetails_ComponentNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellDetails_ComponentNumber.Weight = 0.23118949172885697R
            Me.TableCellDetails_ComponentNumber.WordWrap = False
            '
            'TableCellDetails_ComponentDescription
            '
            Me.TableCellDetails_ComponentDescription.CanGrow = False
            Me.TableCellDetails_ComponentDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ComponentDescription")})
            Me.TableCellDetails_ComponentDescription.KeepTogether = True
            Me.TableCellDetails_ComponentDescription.Name = "TableCellDetails_ComponentDescription"
            Me.TableCellDetails_ComponentDescription.StylePriority.UseTextAlignment = False
            Me.TableCellDetails_ComponentDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellDetails_ComponentDescription.Weight = 0.26675704289857305R
            Me.TableCellDetails_ComponentDescription.WordWrap = False
            '
            'TableCellDetails_FunctionDescription
            '
            Me.TableCellDetails_FunctionDescription.CanGrow = False
            Me.TableCellDetails_FunctionDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionDescription")})
            Me.TableCellDetails_FunctionDescription.KeepTogether = True
            Me.TableCellDetails_FunctionDescription.Name = "TableCellDetails_FunctionDescription"
            Me.TableCellDetails_FunctionDescription.StylePriority.UseTextAlignment = False
            XrSummary5.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
            XrSummary5.IgnoreNullValues = True
            Me.TableCellDetails_FunctionDescription.Summary = XrSummary5
            Me.TableCellDetails_FunctionDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellDetails_FunctionDescription.Weight = 0.26675713423206826R
            Me.TableCellDetails_FunctionDescription.WordWrap = False
            '
            'TableCellDetails_CampaignDescription
            '
            Me.TableCellDetails_CampaignDescription.CanGrow = False
            Me.TableCellDetails_CampaignDescription.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "CampaignName")})
            Me.TableCellDetails_CampaignDescription.KeepTogether = True
            Me.TableCellDetails_CampaignDescription.Name = "TableCellDetails_CampaignDescription"
            Me.TableCellDetails_CampaignDescription.StylePriority.UseTextAlignment = False
            XrSummary6.Func = DevExpress.XtraReports.UI.SummaryFunc.Max
            XrSummary6.IgnoreNullValues = True
            Me.TableCellDetails_CampaignDescription.Summary = XrSummary6
            Me.TableCellDetails_CampaignDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellDetails_CampaignDescription.Weight = 0.26675682111366805R
            Me.TableCellDetails_CampaignDescription.WordWrap = False
            '
            'TableCellDetails_FunctionConsolidation
            '
            Me.TableCellDetails_FunctionConsolidation.CanGrow = False
            Me.TableCellDetails_FunctionConsolidation.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionConsolidation")})
            Me.TableCellDetails_FunctionConsolidation.KeepTogether = True
            Me.TableCellDetails_FunctionConsolidation.Name = "TableCellDetails_FunctionConsolidation"
            Me.TableCellDetails_FunctionConsolidation.StylePriority.UseTextAlignment = False
            Me.TableCellDetails_FunctionConsolidation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellDetails_FunctionConsolidation.Weight = 0.28454062383445555R
            Me.TableCellDetails_FunctionConsolidation.WordWrap = False
            '
            'TableCellDetails_FunctionHeading
            '
            Me.TableCellDetails_FunctionHeading.CanGrow = False
            Me.TableCellDetails_FunctionHeading.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FunctionHeading")})
            Me.TableCellDetails_FunctionHeading.KeepTogether = True
            Me.TableCellDetails_FunctionHeading.Name = "TableCellDetails_FunctionHeading"
            Me.TableCellDetails_FunctionHeading.StylePriority.UseTextAlignment = False
            Me.TableCellDetails_FunctionHeading.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            Me.TableCellDetails_FunctionHeading.Weight = 0.24897355850075997R
            Me.TableCellDetails_FunctionHeading.WordWrap = False
            '
            'TableCellDetails_FeeQuantity
            '
            Me.TableCellDetails_FeeQuantity.CanGrow = False
            Me.TableCellDetails_FeeQuantity.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FeeQuantity")})
            Me.TableCellDetails_FeeQuantity.KeepTogether = True
            Me.TableCellDetails_FeeQuantity.Name = "TableCellDetails_FeeQuantity"
            Me.TableCellDetails_FeeQuantity.StylePriority.UseTextAlignment = False
            XrSummary7.FormatString = "{0:n2}"
            XrSummary7.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.TableCellDetails_FeeQuantity.Summary = XrSummary7
            Me.TableCellDetails_FeeQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.TableCellDetails_FeeQuantity.Weight = 0.26675704727543537R
            Me.TableCellDetails_FeeQuantity.WordWrap = False
            '
            'TableCellDetails_FeeAmount
            '
            Me.TableCellDetails_FeeAmount.CanGrow = False
            Me.TableCellDetails_FeeAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "FeeAmount")})
            Me.TableCellDetails_FeeAmount.KeepTogether = True
            Me.TableCellDetails_FeeAmount.Name = "TableCellDetails_FeeAmount"
            Me.TableCellDetails_FeeAmount.StylePriority.UseTextAlignment = False
            XrSummary8.FormatString = "{0:n2}"
            XrSummary8.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.TableCellDetails_FeeAmount.Summary = XrSummary8
            Me.TableCellDetails_FeeAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.TableCellDetails_FeeAmount.Weight = 0.26675682010473833R
            Me.TableCellDetails_FeeAmount.WordWrap = False
            '
            'TableCellDetails_TotalHours
            '
            Me.TableCellDetails_TotalHours.CanGrow = False
            Me.TableCellDetails_TotalHours.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalHours")})
            Me.TableCellDetails_TotalHours.KeepTogether = True
            Me.TableCellDetails_TotalHours.Name = "TableCellDetails_TotalHours"
            Me.TableCellDetails_TotalHours.StylePriority.UseTextAlignment = False
            XrSummary9.FormatString = "{0:n2}"
            XrSummary9.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.TableCellDetails_TotalHours.Summary = XrSummary9
            Me.TableCellDetails_TotalHours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.TableCellDetails_TotalHours.Weight = 0.26675746930223687R
            Me.TableCellDetails_TotalHours.WordWrap = False
            '
            'TableCellDetails_TotalAmount
            '
            Me.TableCellDetails_TotalAmount.CanGrow = False
            Me.TableCellDetails_TotalAmount.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "TotalAmount")})
            Me.TableCellDetails_TotalAmount.KeepTogether = True
            Me.TableCellDetails_TotalAmount.Name = "TableCellDetails_TotalAmount"
            Me.TableCellDetails_TotalAmount.StylePriority.UseTextAlignment = False
            XrSummary10.FormatString = "{0:n2}"
            XrSummary10.Running = DevExpress.XtraReports.UI.SummaryRunning.Group
            Me.TableCellDetails_TotalAmount.Summary = XrSummary10
            Me.TableCellDetails_TotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
            Me.TableCellDetails_TotalAmount.Weight = 0.26675682724313593R
            Me.TableCellDetails_TotalAmount.WordWrap = False
            '
            'TableClientDivisionProduct_Header
            '
            Me.TableClientDivisionProduct_Header.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.TableClientDivisionProduct_Header.KeepTogether = True
            Me.TableClientDivisionProduct_Header.LocationFloat = New DevExpress.Utils.PointFloat(12.5!, 0.0!)
            Me.TableClientDivisionProduct_Header.Name = "TableClientDivisionProduct_Header"
            Me.TableClientDivisionProduct_Header.Rows.AddRange(New DevExpress.XtraReports.UI.XRTableRow() {Me.TableRowHeader_Header})
            Me.TableClientDivisionProduct_Header.SizeF = New System.Drawing.SizeF(875.0!, 28.0!)
            Me.TableClientDivisionProduct_Header.StylePriority.UseFont = False
            '
            'TableRowHeader_Header
            '
            Me.TableRowHeader_Header.Cells.AddRange(New DevExpress.XtraReports.UI.XRTableCell() {Me.TableCellHeader_JobNumber, Me.TableCellHeader_JobDescription, Me.TableCellHeader_ComponentNumber, Me.TableCellHeader_ComponentDescription, Me.TableCellHeader_FunctionDescription, Me.TableCellHeader_CampaignDescription, Me.TableCellHeader_FunctionConsolidation, Me.TableCellHeader_FunctionHeading, Me.TableCellHeader_FeeQuantity, Me.TableCellHeader_FeeAmount, Me.TableCellHeader_TotalHours, Me.TableCellHeader_TotalAmount})
            Me.TableRowHeader_Header.Name = "TableRowHeader_Header"
            Me.TableRowHeader_Header.Weight = 0.70736844377597019R
            '
            'TableCellHeader_JobNumber
            '
            Me.TableCellHeader_JobNumber.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_JobNumber.CanGrow = False
            Me.TableCellHeader_JobNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_JobNumber.KeepTogether = True
            Me.TableCellHeader_JobNumber.Multiline = True
            Me.TableCellHeader_JobNumber.Name = "TableCellHeader_JobNumber"
            Me.TableCellHeader_JobNumber.StylePriority.UseBorders = False
            Me.TableCellHeader_JobNumber.StylePriority.UseFont = False
            Me.TableCellHeader_JobNumber.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_JobNumber.Text = "Job " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Number"
            Me.TableCellHeader_JobNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_JobNumber.Weight = 0.21364541437832024R
            '
            'TableCellHeader_JobDescription
            '
            Me.TableCellHeader_JobDescription.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_JobDescription.CanGrow = False
            Me.TableCellHeader_JobDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_JobDescription.Multiline = True
            Me.TableCellHeader_JobDescription.Name = "TableCellHeader_JobDescription"
            Me.TableCellHeader_JobDescription.StylePriority.UseBorders = False
            Me.TableCellHeader_JobDescription.StylePriority.UseFont = False
            Me.TableCellHeader_JobDescription.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_JobDescription.Text = "Job " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
            Me.TableCellHeader_JobDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_JobDescription.Weight = 0.26705676771423981R
            '
            'TableCellHeader_ComponentNumber
            '
            Me.TableCellHeader_ComponentNumber.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_ComponentNumber.CanGrow = False
            Me.TableCellHeader_ComponentNumber.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_ComponentNumber.KeepTogether = True
            Me.TableCellHeader_ComponentNumber.Multiline = True
            Me.TableCellHeader_ComponentNumber.Name = "TableCellHeader_ComponentNumber"
            Me.TableCellHeader_ComponentNumber.StylePriority.UseBorders = False
            Me.TableCellHeader_ComponentNumber.StylePriority.UseFont = False
            Me.TableCellHeader_ComponentNumber.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_ComponentNumber.Text = "Component" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Number"
            Me.TableCellHeader_ComponentNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_ComponentNumber.Weight = 0.23144919681477555R
            '
            'TableCellHeader_ComponentDescription
            '
            Me.TableCellHeader_ComponentDescription.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_ComponentDescription.CanGrow = False
            Me.TableCellHeader_ComponentDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_ComponentDescription.Multiline = True
            Me.TableCellHeader_ComponentDescription.Name = "TableCellHeader_ComponentDescription"
            Me.TableCellHeader_ComponentDescription.StylePriority.UseBorders = False
            Me.TableCellHeader_ComponentDescription.StylePriority.UseFont = False
            Me.TableCellHeader_ComponentDescription.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_ComponentDescription.Text = "Component" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
            Me.TableCellHeader_ComponentDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_ComponentDescription.Weight = 0.26705676570538861R
            '
            'TableCellHeader_FunctionDescription
            '
            Me.TableCellHeader_FunctionDescription.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_FunctionDescription.CanGrow = False
            Me.TableCellHeader_FunctionDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_FunctionDescription.KeepTogether = True
            Me.TableCellHeader_FunctionDescription.Multiline = True
            Me.TableCellHeader_FunctionDescription.Name = "TableCellHeader_FunctionDescription"
            Me.TableCellHeader_FunctionDescription.StylePriority.UseBorders = False
            Me.TableCellHeader_FunctionDescription.StylePriority.UseFont = False
            Me.TableCellHeader_FunctionDescription.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_FunctionDescription.Text = "Function" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
            Me.TableCellHeader_FunctionDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_FunctionDescription.Weight = 0.26705676211614571R
            '
            'TableCellHeader_CampaignDescription
            '
            Me.TableCellHeader_CampaignDescription.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_CampaignDescription.CanGrow = False
            Me.TableCellHeader_CampaignDescription.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_CampaignDescription.KeepTogether = True
            Me.TableCellHeader_CampaignDescription.Multiline = True
            Me.TableCellHeader_CampaignDescription.Name = "TableCellHeader_CampaignDescription"
            Me.TableCellHeader_CampaignDescription.StylePriority.UseBorders = False
            Me.TableCellHeader_CampaignDescription.StylePriority.UseFont = False
            Me.TableCellHeader_CampaignDescription.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_CampaignDescription.Text = "Campaign" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Description"
            Me.TableCellHeader_CampaignDescription.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_CampaignDescription.Weight = 0.26705676905279541R
            '
            'TableCellHeader_FunctionConsolidation
            '
            Me.TableCellHeader_FunctionConsolidation.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_FunctionConsolidation.CanGrow = False
            Me.TableCellHeader_FunctionConsolidation.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_FunctionConsolidation.KeepTogether = True
            Me.TableCellHeader_FunctionConsolidation.Multiline = True
            Me.TableCellHeader_FunctionConsolidation.Name = "TableCellHeader_FunctionConsolidation"
            Me.TableCellHeader_FunctionConsolidation.StylePriority.UseBorders = False
            Me.TableCellHeader_FunctionConsolidation.StylePriority.UseFont = False
            Me.TableCellHeader_FunctionConsolidation.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_FunctionConsolidation.Text = "Function" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Consolidation"
            Me.TableCellHeader_FunctionConsolidation.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_FunctionConsolidation.Weight = 0.28486055349810191R
            '
            'TableCellHeader_FunctionHeading
            '
            Me.TableCellHeader_FunctionHeading.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_FunctionHeading.CanGrow = False
            Me.TableCellHeader_FunctionHeading.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_FunctionHeading.KeepTogether = True
            Me.TableCellHeader_FunctionHeading.Multiline = True
            Me.TableCellHeader_FunctionHeading.Name = "TableCellHeader_FunctionHeading"
            Me.TableCellHeader_FunctionHeading.StylePriority.UseBorders = False
            Me.TableCellHeader_FunctionHeading.StylePriority.UseFont = False
            Me.TableCellHeader_FunctionHeading.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_FunctionHeading.Text = "Function" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Heading"
            Me.TableCellHeader_FunctionHeading.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_FunctionHeading.Weight = 0.249252986980686R
            '
            'TableCellHeader_FeeQuantity
            '
            Me.TableCellHeader_FeeQuantity.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_FeeQuantity.CanGrow = False
            Me.TableCellHeader_FeeQuantity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_FeeQuantity.KeepTogether = True
            Me.TableCellHeader_FeeQuantity.Multiline = True
            Me.TableCellHeader_FeeQuantity.Name = "TableCellHeader_FeeQuantity"
            Me.TableCellHeader_FeeQuantity.StylePriority.UseBorders = False
            Me.TableCellHeader_FeeQuantity.StylePriority.UseFont = False
            Me.TableCellHeader_FeeQuantity.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_FeeQuantity.Text = "Fee" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Quantity"
            Me.TableCellHeader_FeeQuantity.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_FeeQuantity.Weight = 0.26705676712891768R
            '
            'TableCellHeader_FeeAmount
            '
            Me.TableCellHeader_FeeAmount.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_FeeAmount.CanGrow = False
            Me.TableCellHeader_FeeAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_FeeAmount.KeepTogether = True
            Me.TableCellHeader_FeeAmount.Multiline = True
            Me.TableCellHeader_FeeAmount.Name = "TableCellHeader_FeeAmount"
            Me.TableCellHeader_FeeAmount.StylePriority.UseBorders = False
            Me.TableCellHeader_FeeAmount.StylePriority.UseFont = False
            Me.TableCellHeader_FeeAmount.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_FeeAmount.Text = "Fee" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.TableCellHeader_FeeAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_FeeAmount.Weight = 0.26705676635665709R
            '
            'TableCellHeader_TotalHours
            '
            Me.TableCellHeader_TotalHours.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_TotalHours.CanGrow = False
            Me.TableCellHeader_TotalHours.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_TotalHours.KeepTogether = True
            Me.TableCellHeader_TotalHours.Multiline = True
            Me.TableCellHeader_TotalHours.Name = "TableCellHeader_TotalHours"
            Me.TableCellHeader_TotalHours.StylePriority.UseBorders = False
            Me.TableCellHeader_TotalHours.StylePriority.UseFont = False
            Me.TableCellHeader_TotalHours.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_TotalHours.Text = "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Hours"
            Me.TableCellHeader_TotalHours.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_TotalHours.Weight = 0.26705675788899108R
            '
            'TableCellHeader_TotalAmount
            '
            Me.TableCellHeader_TotalAmount.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.TableCellHeader_TotalAmount.CanGrow = False
            Me.TableCellHeader_TotalAmount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TableCellHeader_TotalAmount.KeepTogether = True
            Me.TableCellHeader_TotalAmount.Multiline = True
            Me.TableCellHeader_TotalAmount.Name = "TableCellHeader_TotalAmount"
            Me.TableCellHeader_TotalAmount.StylePriority.UseBorders = False
            Me.TableCellHeader_TotalAmount.StylePriority.UseFont = False
            Me.TableCellHeader_TotalAmount.StylePriority.UseTextAlignment = False
            Me.TableCellHeader_TotalAmount.Text = "Total" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Amount"
            Me.TableCellHeader_TotalAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            Me.TableCellHeader_TotalAmount.Weight = 0.26705677029362573R
            '
            'SubreportDetail_FeesPosted
            '
            Me.SubreportDetail_FeesPosted.CanShrink = True
            Me.SubreportDetail_FeesPosted.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 49.00001!)
            Me.SubreportDetail_FeesPosted.Name = "SubreportDetail_FeesPosted"
            Me.SubreportDetail_FeesPosted.ReportSource = Me.FeeDetailSubReport
            Me.SubreportDetail_FeesPosted.SizeF = New System.Drawing.SizeF(700.0!, 22.75!)
            '
            'SubreportDetail_TimePosted
            '
            Me.SubreportDetail_TimePosted.CanShrink = True
            Me.SubreportDetail_TimePosted.LocationFloat = New DevExpress.Utils.PointFloat(100.0!, 71.74997!)
            Me.SubreportDetail_TimePosted.Name = "SubreportDetail_TimePosted"
            Me.SubreportDetail_TimePosted.ReportSource = Me.TimeDetailSubReport
            Me.SubreportDetail_TimePosted.SizeF = New System.Drawing.SizeF(700.0!, 22.75!)
            '
            'GroupHeaderClientDivisionProduct
            '
            Me.GroupHeaderClientDivisionProduct.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelClientDivisionProduct_Client, Me.LabelClientDivisionProduct_Division, Me.LabelClientDivisionProduct_ProductData, Me.LabelClientDivisionProduct_Product, Me.LabelClientDivisionProduct_DivisionData, Me.LabelClientDivisionProduct_ClientData})
            Me.GroupHeaderClientDivisionProduct.HeightF = 81.25!
            Me.GroupHeaderClientDivisionProduct.Level = 1
            Me.GroupHeaderClientDivisionProduct.Name = "GroupHeaderClientDivisionProduct"
            '
            'ServiceFeeReconciliationDetailReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.PageHeader, Me.GroupHeaderDetail, Me.GroupHeaderClientDivisionProduct})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Campaign, Me.Job, Me.Component, Me.SalesClass, Me.CompFunction, Me.Client, Me.Division, Me.Product, Me.StandardFeeBilled, Me.StandardTimePosted, Me.StandardVariance, Me.ProductionFeeBilled, Me.ProductionTimePosted, Me.ProductionVariance, Me.MediaFeeBilled, Me.MediaTimePosted, Me.MediaVariance, Me.TotalFeeBilled, Me.TotalTimePosted, Me.TotalVariance, Me.IsServiceFeeJob})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1})
            Me.Landscape = True
            Me.Margins = New System.Drawing.Printing.Margins(100, 100, 0, 0)
            Me.PageHeight = 850
            Me.PageWidth = 1100
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.ControlStyle})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TableDetail_Details, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TableClientDivisionProduct_Header, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.FeeDetailSubReport, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TimeDetailSubReport, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents PageHeader As DevExpress.XtraReports.UI.PageHeaderBand
        Private WithEvents LinePageHeader_TopLine As DevExpress.XtraReports.UI.XRLine
        Private WithEvents LabelPageHeader_Title As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LinePageHeader_BottomLine As DevExpress.XtraReports.UI.XRLine
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
        Friend WithEvents ControlStyle As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents IsServiceFeeJob As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents SubreportDetail_FeesPosted As DevExpress.XtraReports.UI.XRSubreport
        Friend WithEvents SubreportDetail_TimePosted As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents FeeDetailSubReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationFeeDetailSubReport
        Private WithEvents TimeDetailSubReport As AdvantageFramework.Reporting.Reports.FinanceAndAccounting.ServiceFeeReconciliationTimeDetailSubReport
        Friend WithEvents LabelClientDivisionProduct_ClientData As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelClientDivisionProduct_DivisionData As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelClientDivisionProduct_Product As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelClientDivisionProduct_ProductData As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelClientDivisionProduct_Division As DevExpress.XtraReports.UI.XRLabel
        Private WithEvents LabelClientDivisionProduct_Client As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderDetail As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupHeaderClientDivisionProduct As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents LabelPageHeader_FeesTimePostedFrom As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelPageHeader_FeesBilledFrom As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TableClientDivisionProduct_Header As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents TableRowHeader_Header As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellHeader_JobNumber As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_JobDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_ComponentNumber As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_ComponentDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FunctionDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_CampaignDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FunctionConsolidation As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FunctionHeading As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FeeQuantity As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_FeeAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_TotalHours As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellHeader_TotalAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableDetail_Details As DevExpress.XtraReports.UI.XRTable
        Friend WithEvents TableRowDetails_Details As DevExpress.XtraReports.UI.XRTableRow
        Friend WithEvents TableCellDetails_JobNumber As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_JobDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_ComponentNumber As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_ComponentDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_FunctionDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_CampaignDescription As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_FunctionConsolidation As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_FunctionHeading As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_FeeQuantity As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_FeeAmount As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_TotalHours As DevExpress.XtraReports.UI.XRTableCell
        Friend WithEvents TableCellDetails_TotalAmount As DevExpress.XtraReports.UI.XRTableCell
    End Class

End Namespace
