Namespace Vendor

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class VendorPricingsSubReport
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
            Me.Label_Label = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.Label_FirmName = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Name = New DevExpress.XtraReports.UI.XRLabel()
            Me.Label_Code = New DevExpress.XtraReports.UI.XRLabel()
            Me.TopMargin = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMargin = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeader = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.LabelHeader_JobTypeCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Description = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Rate = New DevExpress.XtraReports.UI.XRLabel()
            Me.LabelHeader_Comments = New DevExpress.XtraReports.UI.XRLabel()
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.Label_Label, Me.XrLine1, Me.Label_FirmName, Me.Label_Name, Me.Label_Code})
            Me.Detail.HeightF = 33.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'Label_Label
            '
            Me.Label_Label.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Rate")})
            Me.Label_Label.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Label.LocationFloat = New DevExpress.Utils.PointFloat(324.0!, 0.0!)
            Me.Label_Label.Name = "Label_Label"
            Me.Label_Label.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Label.SizeF = New System.Drawing.SizeF(87.49982!, 18.0!)
            Me.Label_Label.StylePriority.UseFont = False
            Me.Label_Label.Text = "Label_Label"
            '
            'XrLine1
            '
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.9999593!, 18.0!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(748.0!, 15.0!)
            '
            'Label_FirmName
            '
            Me.Label_FirmName.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Description")})
            Me.Label_FirmName.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_FirmName.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 0.0!)
            Me.Label_FirmName.Name = "Label_FirmName"
            Me.Label_FirmName.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_FirmName.SizeF = New System.Drawing.SizeF(218.9999!, 18.0!)
            Me.Label_FirmName.StylePriority.UseFont = False
            Me.Label_FirmName.Text = "Label_FirmName"
            '
            'Label_Name
            '
            Me.Label_Name.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Notes")})
            Me.Label_Name.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Name.LocationFloat = New DevExpress.Utils.PointFloat(411.4998!, 0.0!)
            Me.Label_Name.Multiline = True
            Me.Label_Name.Name = "Label_Name"
            Me.Label_Name.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Name.SizeF = New System.Drawing.SizeF(336.5002!, 18.0!)
            Me.Label_Name.StylePriority.UseFont = False
            Me.Label_Name.Text = "Label_Name"
            '
            'Label_Code
            '
            Me.Label_Code.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "JobTypeCode")})
            Me.Label_Code.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.Label_Code.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.Label_Code.Name = "Label_Code"
            Me.Label_Code.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.Label_Code.SizeF = New System.Drawing.SizeF(105.0!, 18.0!)
            Me.Label_Code.StylePriority.UseFont = False
            Me.Label_Code.Text = "Label_Code"
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
            Me.BottomMargin.HeightF = 6.791592!
            Me.BottomMargin.Name = "BottomMargin"
            Me.BottomMargin.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100.0!)
            Me.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'GroupHeader
            '
            Me.GroupHeader.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.LabelHeader_Comments, Me.LabelHeader_Rate, Me.LabelHeader_Description, Me.LabelHeader_JobTypeCode})
            Me.GroupHeader.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeader.HeightF = 16.95835!
            Me.GroupHeader.Name = "GroupHeader"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Database.Entities.VendorPricing)
            '
            'LabelHeader_JobTypeCode
            '
            Me.LabelHeader_JobTypeCode.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_JobTypeCode.BorderWidth = 0
            Me.LabelHeader_JobTypeCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_JobTypeCode.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_JobTypeCode.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.LabelHeader_JobTypeCode.Name = "LabelHeader_JobTypeCode"
            Me.LabelHeader_JobTypeCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_JobTypeCode.SizeF = New System.Drawing.SizeF(105.0!, 16.95835!)
            Me.LabelHeader_JobTypeCode.StylePriority.UseBorders = False
            Me.LabelHeader_JobTypeCode.StylePriority.UseBorderWidth = False
            Me.LabelHeader_JobTypeCode.StylePriority.UseFont = False
            Me.LabelHeader_JobTypeCode.StylePriority.UseForeColor = False
            Me.LabelHeader_JobTypeCode.StylePriority.UseTextAlignment = False
            Me.LabelHeader_JobTypeCode.Text = "Job Type Code"
            Me.LabelHeader_JobTypeCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Description
            '
            Me.LabelHeader_Description.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Description.BorderWidth = 0
            Me.LabelHeader_Description.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Description.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Description.LocationFloat = New DevExpress.Utils.PointFloat(105.0001!, 0.0!)
            Me.LabelHeader_Description.Name = "LabelHeader_Description"
            Me.LabelHeader_Description.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Description.SizeF = New System.Drawing.SizeF(219.0!, 16.95835!)
            Me.LabelHeader_Description.StylePriority.UseBorders = False
            Me.LabelHeader_Description.StylePriority.UseBorderWidth = False
            Me.LabelHeader_Description.StylePriority.UseFont = False
            Me.LabelHeader_Description.StylePriority.UseForeColor = False
            Me.LabelHeader_Description.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Description.Text = "Description"
            Me.LabelHeader_Description.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Rate
            '
            Me.LabelHeader_Rate.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Rate.BorderWidth = 0
            Me.LabelHeader_Rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Rate.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Rate.LocationFloat = New DevExpress.Utils.PointFloat(324.0!, 0.0!)
            Me.LabelHeader_Rate.Name = "LabelHeader_Rate"
            Me.LabelHeader_Rate.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Rate.SizeF = New System.Drawing.SizeF(87.49982!, 16.95835!)
            Me.LabelHeader_Rate.StylePriority.UseBorders = False
            Me.LabelHeader_Rate.StylePriority.UseBorderWidth = False
            Me.LabelHeader_Rate.StylePriority.UseFont = False
            Me.LabelHeader_Rate.StylePriority.UseForeColor = False
            Me.LabelHeader_Rate.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Rate.Text = "Unit - Rate"
            Me.LabelHeader_Rate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'LabelHeader_Comments
            '
            Me.LabelHeader_Comments.Borders = DevExpress.XtraPrinting.BorderSide.Bottom
            Me.LabelHeader_Comments.BorderWidth = 0
            Me.LabelHeader_Comments.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelHeader_Comments.ForeColor = System.Drawing.Color.Black
            Me.LabelHeader_Comments.LocationFloat = New DevExpress.Utils.PointFloat(411.4998!, 0.0!)
            Me.LabelHeader_Comments.Name = "LabelHeader_Comments"
            Me.LabelHeader_Comments.Padding = New DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100.0!)
            Me.LabelHeader_Comments.SizeF = New System.Drawing.SizeF(336.5003!, 16.95835!)
            Me.LabelHeader_Comments.StylePriority.UseBorders = False
            Me.LabelHeader_Comments.StylePriority.UseBorderWidth = False
            Me.LabelHeader_Comments.StylePriority.UseFont = False
            Me.LabelHeader_Comments.StylePriority.UseForeColor = False
            Me.LabelHeader_Comments.StylePriority.UseTextAlignment = False
            Me.LabelHeader_Comments.Text = "Description"
            Me.LabelHeader_Comments.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomLeft
            '
            'VendorPricingsSubReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.TopMargin, Me.BottomMargin, Me.GroupHeader})
            Me.DataSource = Me.BindingSource
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(0, 101, 0, 7)
            Me.ReportPrintOptions.PrintOnEmptyDataSource = False
            Me.RequestParameters = False
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents TopMargin As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMargin As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents Label_Code As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeader As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents Label_Name As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents Label_FirmName As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents Label_Label As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Comments As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Rate As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_Description As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents LabelHeader_JobTypeCode As DevExpress.XtraReports.UI.XRLabel
    End Class

End Namespace