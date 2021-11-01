Namespace Security

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class GroupSummaryReport
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
            Me.XrLabelEmployeeData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelUserCodeData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroup = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
            Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.PageHeaderBand = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLabelLabelHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelEmployee = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelUserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
            Me.PageFooterBand = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrPageInfoDate = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrPageInfoPageNumber = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.TopMarginBand = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMarginBand = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeaderBandGroups = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.GroupFooter1 = New DevExpress.XtraReports.UI.GroupFooterBand()
            Me.Users = New DevExpress.XtraReports.UI.CalculatedField()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelEmployeeData, Me.XrLabelUserCodeData})
            Me.Detail.Dpi = 254.0!
            Me.Detail.HeightF = 48.26006!
            Me.Detail.KeepTogether = True
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0!)
            Me.Detail.SortFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Employee", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("UserCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.Detail.StyleName = "DataField"
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
            '
            'XrLabelEmployeeData
            '
            Me.XrLabelEmployeeData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Employee")})
            Me.XrLabelEmployeeData.Dpi = 254.0!
            Me.XrLabelEmployeeData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelEmployeeData.LocationFloat = New DevExpress.Utils.PointFloat(631.7741!, 0.0!)
            Me.XrLabelEmployeeData.Name = "XrLabelEmployeeData"
            Me.XrLabelEmployeeData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelEmployeeData.SizeF = New System.Drawing.SizeF(483.8149!, 48.26!)
            Me.XrLabelEmployeeData.StylePriority.UseFont = False
            Me.XrLabelEmployeeData.StylePriority.UseTextAlignment = False
            Me.XrLabelEmployeeData.Text = "XrLabelEmployeeData"
            Me.XrLabelEmployeeData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelUserCodeData
            '
            Me.XrLabelUserCodeData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "UserCode")})
            Me.XrLabelUserCodeData.Dpi = 254.0!
            Me.XrLabelUserCodeData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelUserCodeData.LocationFloat = New DevExpress.Utils.PointFloat(1115.589!, 0.00008074442!)
            Me.XrLabelUserCodeData.Name = "XrLabelUserCodeData"
            Me.XrLabelUserCodeData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelUserCodeData.SizeF = New System.Drawing.SizeF(789.4102!, 48.25998!)
            Me.XrLabelUserCodeData.StylePriority.UseFont = False
            Me.XrLabelUserCodeData.StylePriority.UseTextAlignment = False
            Me.XrLabelUserCodeData.Text = "XrLabelUserCodeData"
            Me.XrLabelUserCodeData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelGroupData
            '
            Me.XrLabelGroupData.BackColor = System.Drawing.Color.White
            Me.XrLabelGroupData.BorderColor = System.Drawing.SystemColors.ControlText
            Me.XrLabelGroupData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Group")})
            Me.XrLabelGroupData.Dpi = 254.0!
            Me.XrLabelGroupData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelGroupData.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLabelGroupData.Name = "XrLabelGroupData"
            Me.XrLabelGroupData.NullValueText = "No Group"
            Me.XrLabelGroupData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelGroupData.SizeF = New System.Drawing.SizeF(631.7742!, 48.25999!)
            Me.XrLabelGroupData.StylePriority.UseBackColor = False
            Me.XrLabelGroupData.StylePriority.UseBorderColor = False
            Me.XrLabelGroupData.StylePriority.UseFont = False
            Me.XrLabelGroupData.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupData.Text = "XrLabelGroupData"
            Me.XrLabelGroupData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelGroup
            '
            Me.XrLabelGroup.Dpi = 254.0!
            Me.XrLabelGroup.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroup.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroup.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 168.1692!)
            Me.XrLabelGroup.Name = "XrLabelGroup"
            Me.XrLabelGroup.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelGroup.SizeF = New System.Drawing.SizeF(147.9593!, 48.25999!)
            Me.XrLabelGroup.StyleName = "FieldCaption"
            Me.XrLabelGroup.StylePriority.UseFont = False
            Me.XrLabelGroup.StylePriority.UseForeColor = False
            Me.XrLabelGroup.Text = "Group"
            '
            'XrLine4
            '
            Me.XrLine4.BorderColor = System.Drawing.Color.Transparent
            Me.XrLine4.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine4.BorderWidth = 4
            Me.XrLine4.Dpi = 254.0!
            Me.XrLine4.ForeColor = System.Drawing.Color.Silver
            Me.XrLine4.KeepTogether = False
            Me.XrLine4.LineWidth = 10
            Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(631.7741!, 48.25998!)
            Me.XrLine4.Name = "XrLine4"
            Me.XrLine4.SizeF = New System.Drawing.SizeF(1273.225!, 48.26006!)
            Me.XrLine4.StylePriority.UseBorderColor = False
            '
            'Title
            '
            Me.Title.BackColor = System.Drawing.Color.White
            Me.Title.BorderColor = System.Drawing.SystemColors.ControlText
            Me.Title.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.Title.BorderWidth = 1
            Me.Title.Font = New System.Drawing.Font("Arial", 20.0!, System.Drawing.FontStyle.Bold)
            Me.Title.ForeColor = System.Drawing.Color.Maroon
            Me.Title.Name = "Title"
            '
            'FieldCaption
            '
            Me.FieldCaption.BackColor = System.Drawing.Color.White
            Me.FieldCaption.BorderColor = System.Drawing.SystemColors.ControlText
            Me.FieldCaption.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.FieldCaption.BorderWidth = 1
            Me.FieldCaption.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
            Me.FieldCaption.ForeColor = System.Drawing.Color.Maroon
            Me.FieldCaption.Name = "FieldCaption"
            '
            'PageInfo
            '
            Me.PageInfo.BackColor = System.Drawing.Color.White
            Me.PageInfo.BorderColor = System.Drawing.SystemColors.ControlText
            Me.PageInfo.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.PageInfo.BorderWidth = 1
            Me.PageInfo.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold)
            Me.PageInfo.ForeColor = System.Drawing.SystemColors.ControlText
            Me.PageInfo.Name = "PageInfo"
            '
            'DataField
            '
            Me.DataField.BackColor = System.Drawing.Color.White
            Me.DataField.BorderColor = System.Drawing.SystemColors.ControlText
            Me.DataField.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.DataField.BorderWidth = 1
            Me.DataField.Font = New System.Drawing.Font("Arial", 10.0!)
            Me.DataField.ForeColor = System.Drawing.SystemColors.ControlText
            Me.DataField.Name = "DataField"
            Me.DataField.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            '
            'PageHeaderBand
            '
            Me.PageHeaderBand.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelLabelHeader, Me.LineTopLine, Me.XrLine1, Me.XrLabelGroup})
            Me.PageHeaderBand.Dpi = 254.0!
            Me.PageHeaderBand.HeightF = 216.4292!
            Me.PageHeaderBand.Name = "PageHeaderBand"
            '
            'XrLabelLabelHeader
            '
            Me.XrLabelLabelHeader.Dpi = 254.0!
            Me.XrLabelLabelHeader.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelLabelHeader.ForeColor = System.Drawing.Color.Black
            Me.XrLabelLabelHeader.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 51.7525!)
            Me.XrLabelLabelHeader.Name = "XrLabelLabelHeader"
            Me.XrLabelLabelHeader.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelLabelHeader.SizeF = New System.Drawing.SizeF(1905.0!, 83.81999!)
            Me.XrLabelLabelHeader.StyleName = "Title"
            Me.XrLabelLabelHeader.StylePriority.UseFont = False
            Me.XrLabelLabelHeader.StylePriority.UseForeColor = False
            Me.XrLabelLabelHeader.Text = "Group Summary"
            '
            'LineTopLine
            '
            Me.LineTopLine.BorderColor = System.Drawing.Color.Silver
            Me.LineTopLine.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.LineTopLine.BorderWidth = 4
            Me.LineTopLine.Dpi = 254.0!
            Me.LineTopLine.ForeColor = System.Drawing.Color.Silver
            Me.LineTopLine.KeepTogether = False
            Me.LineTopLine.LineWidth = 10
            Me.LineTopLine.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 150.8125!)
            Me.LineTopLine.Name = "LineTopLine"
            Me.LineTopLine.SizeF = New System.Drawing.SizeF(1905.0!, 10.16!)
            '
            'XrLine1
            '
            Me.XrLine1.BorderColor = System.Drawing.Color.Silver
            Me.XrLine1.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine1.BorderWidth = 4
            Me.XrLine1.Dpi = 254.0!
            Me.XrLine1.ForeColor = System.Drawing.Color.Silver
            Me.XrLine1.KeepTogether = False
            Me.XrLine1.LineWidth = 10
            Me.XrLine1.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 23.8125!)
            Me.XrLine1.Name = "XrLine1"
            Me.XrLine1.SizeF = New System.Drawing.SizeF(1905.0!, 10.16!)
            '
            'XrLabelEmployee
            '
            Me.XrLabelEmployee.Dpi = 254.0!
            Me.XrLabelEmployee.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelEmployee.ForeColor = System.Drawing.Color.Black
            Me.XrLabelEmployee.LocationFloat = New DevExpress.Utils.PointFloat(631.7741!, 0.0!)
            Me.XrLabelEmployee.Name = "XrLabelEmployee"
            Me.XrLabelEmployee.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelEmployee.SizeF = New System.Drawing.SizeF(483.8149!, 48.25999!)
            Me.XrLabelEmployee.StyleName = "FieldCaption"
            Me.XrLabelEmployee.StylePriority.UseFont = False
            Me.XrLabelEmployee.StylePriority.UseForeColor = False
            Me.XrLabelEmployee.Text = "Employee"
            '
            'XrLabelUserCode
            '
            Me.XrLabelUserCode.Dpi = 254.0!
            Me.XrLabelUserCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelUserCode.ForeColor = System.Drawing.Color.Black
            Me.XrLabelUserCode.LocationFloat = New DevExpress.Utils.PointFloat(1115.589!, 0.0!)
            Me.XrLabelUserCode.Name = "XrLabelUserCode"
            Me.XrLabelUserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelUserCode.SizeF = New System.Drawing.SizeF(224.6884!, 48.25999!)
            Me.XrLabelUserCode.StyleName = "FieldCaption"
            Me.XrLabelUserCode.StylePriority.UseFont = False
            Me.XrLabelUserCode.StylePriority.UseForeColor = False
            Me.XrLabelUserCode.Text = "User Code"
            '
            'XrLine3
            '
            Me.XrLine3.BackColor = System.Drawing.Color.Transparent
            Me.XrLine3.BorderColor = System.Drawing.Color.Transparent
            Me.XrLine3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine3.BorderWidth = 4
            Me.XrLine3.Dpi = 254.0!
            Me.XrLine3.ForeColor = System.Drawing.Color.Black
            Me.XrLine3.KeepTogether = False
            Me.XrLine3.LineWidth = 2
            Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
            Me.XrLine3.Name = "XrLine3"
            Me.XrLine3.SizeF = New System.Drawing.SizeF(1904.999!, 48.26!)
            Me.XrLine3.StylePriority.UseBackColor = False
            Me.XrLine3.StylePriority.UseBorderColor = False
            Me.XrLine3.StylePriority.UseForeColor = False
            '
            'PageFooterBand
            '
            Me.PageFooterBand.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrPageInfoDate, Me.XrPageInfoPageNumber})
            Me.PageFooterBand.Dpi = 254.0!
            Me.PageFooterBand.HeightF = 74.0!
            Me.PageFooterBand.Name = "PageFooterBand"
            '
            'XrPageInfoDate
            '
            Me.XrPageInfoDate.Dpi = 254.0!
            Me.XrPageInfoDate.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 15.24003!)
            Me.XrPageInfoDate.Name = "XrPageInfoDate"
            Me.XrPageInfoDate.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrPageInfoDate.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime
            Me.XrPageInfoDate.SizeF = New System.Drawing.SizeF(795.02!, 58.42!)
            Me.XrPageInfoDate.StyleName = "PageInfo"
            '
            'XrPageInfoPageNumber
            '
            Me.XrPageInfoPageNumber.Dpi = 254.0!
            Me.XrPageInfoPageNumber.Format = "Page {0} of {1}"
            Me.XrPageInfoPageNumber.LocationFloat = New DevExpress.Utils.PointFloat(1109.98!, 15.24003!)
            Me.XrPageInfoPageNumber.Name = "XrPageInfoPageNumber"
            Me.XrPageInfoPageNumber.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrPageInfoPageNumber.SizeF = New System.Drawing.SizeF(795.02!, 58.42!)
            Me.XrPageInfoPageNumber.StyleName = "PageInfo"
            Me.XrPageInfoPageNumber.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight
            '
            'TopMarginBand
            '
            Me.TopMarginBand.Dpi = 254.0!
            Me.TopMarginBand.HeightF = 127.0!
            Me.TopMarginBand.Name = "TopMarginBand"
            '
            'BottomMarginBand
            '
            Me.BottomMarginBand.Dpi = 254.0!
            Me.BottomMarginBand.HeightF = 127.0!
            Me.BottomMarginBand.Name = "BottomMarginBand"
            '
            'GroupHeaderBandGroups
            '
            Me.GroupHeaderBandGroups.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine4, Me.XrLabelUserCode, Me.XrLabelEmployee, Me.XrLabelGroupData})
            Me.GroupHeaderBandGroups.Dpi = 254.0!
            Me.GroupHeaderBandGroups.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("Group", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderBandGroups.HeightF = 96.52005!
            Me.GroupHeaderBandGroups.Level = 1
            Me.GroupHeaderBandGroups.Name = "GroupHeaderBandGroups"
            '
            'GroupFooter1
            '
            Me.GroupFooter1.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine3})
            Me.GroupFooter1.Dpi = 254.0!
            Me.GroupFooter1.HeightF = 48.26!
            Me.GroupFooter1.Name = "GroupFooter1"
            '
            'Users
            '
            Me.Users.Expression = "Concat([UserCode],',', [UserCode])"
            Me.Users.FieldType = DevExpress.XtraReports.UI.FieldType.[String]
            Me.Users.Name = "Users"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Security.Database.Views.EmployeeSummary)
            '
            'GroupSummaryReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeaderBand, Me.PageFooterBand, Me.TopMarginBand, Me.BottomMarginBand, Me.GroupHeaderBandGroups, Me.GroupFooter1})
            Me.CalculatedFields.AddRange(New DevExpress.XtraReports.UI.CalculatedField() {Me.Users})
            Me.DataSource = Me.BindingSource
            Me.Dpi = 254.0!
            Me.FilterString = "[UserCode] Is Not Null"
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.Margins = New System.Drawing.Printing.Margins(127, 127, 127, 127)
            Me.PageHeight = 2794
            Me.PageWidth = 2159
            Me.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter
            Me.RequestParameters = False
            Me.SnapGridSize = 2.54!
            Me.StyleSheet.AddRange(New DevExpress.XtraReports.UI.XRControlStyle() {Me.Title, Me.FieldCaption, Me.PageInfo, Me.DataField})
            Me.ScriptLanguage = DevExpress.XtraReports.ScriptLanguage.VisualBasic
            Me.Version = "14.2"
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
        Friend WithEvents Detail As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents Title As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents FieldCaption As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents PageInfo As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents DataField As DevExpress.XtraReports.UI.XRControlStyle
        Friend WithEvents PageHeaderBand As DevExpress.XtraReports.UI.PageHeaderBand
        Friend WithEvents XrLabelUserCode As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelEmployee As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelEmployeeData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooterBand As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents XrPageInfoDate As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrPageInfoPageNumber As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrLabelLabelHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMarginBand As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMarginBand As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelGroup As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderBandGroups As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents GroupFooter1 As DevExpress.XtraReports.UI.GroupFooterBand
        Friend WithEvents Users As DevExpress.XtraReports.UI.CalculatedField
        Friend WithEvents XrLabelUserCodeData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource

    End Class

End Namespace
