Namespace Security

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Public Class PermissionReport
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
            Me.Title = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.FieldCaption = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.PageInfo = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.DataField = New DevExpress.XtraReports.UI.XRControlStyle()
            Me.PageHeaderBand = New DevExpress.XtraReports.UI.PageHeaderBand()
            Me.XrLabelBlockedApplications = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroups = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelUserCode = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelEmployee = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelLabelHeader = New DevExpress.XtraReports.UI.XRLabel()
            Me.LineTopLine = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine1 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderBandEmployee = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrCheckBoxWebvantageOnly = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrCheckBoxCheckForUserAccess = New DevExpress.XtraReports.UI.XRCheckBox()
            Me.XrLabelBlockedApplicationsData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelGroupsData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLine2 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelEmployeeData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelUserCodeData = New DevExpress.XtraReports.UI.XRLabel()
            Me.GroupHeaderBandParentModule = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrSubreportParentModulesPermission = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLine5 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine3 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLabelCategoryData = New DevExpress.XtraReports.UI.XRLabel()
            Me.PageFooterBand = New DevExpress.XtraReports.UI.PageFooterBand()
            Me.XrPageInfoDate = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.XrPageInfoPageNumber = New DevExpress.XtraReports.UI.XRPageInfo()
            Me.TopMarginBand = New DevExpress.XtraReports.UI.TopMarginBand()
            Me.BottomMarginBand = New DevExpress.XtraReports.UI.BottomMarginBand()
            Me.GroupHeaderBandSubParentModule = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLine6 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine4 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrSubreportSubParentModulesPermission = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabelSubCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelSubCategoryData = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRule1 = New DevExpress.XtraReports.UI.FormattingRule()
            Me.GroupHeaderBandSubSubParentModule = New DevExpress.XtraReports.UI.GroupHeaderBand()
            Me.XrLine7 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrLine8 = New DevExpress.XtraReports.UI.XRLine()
            Me.XrSubreportSubSubParentModulesPermission = New DevExpress.XtraReports.UI.XRSubreport()
            Me.XrLabelSubSubCategoryData = New DevExpress.XtraReports.UI.XRLabel()
            Me.XrLabelSubSubCategory = New DevExpress.XtraReports.UI.XRLabel()
            Me.FormattingRule2 = New DevExpress.XtraReports.UI.FormattingRule()
            Me.BindingSource = New System.Windows.Forms.BindingSource(Me.components)
            CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            '
            'Detail
            '
            Me.Detail.Dpi = 254.0!
            Me.Detail.HeightF = 0.0!
            Me.Detail.Name = "Detail"
            Me.Detail.Padding = New DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254.0!)
            Me.Detail.StyleName = "DataField"
            Me.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft
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
            Me.PageHeaderBand.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLabelBlockedApplications, Me.XrLabelGroups, Me.XrLabelUserCode, Me.XrLabelEmployee, Me.XrLabelLabelHeader, Me.LineTopLine, Me.XrLine1})
            Me.PageHeaderBand.Dpi = 254.0!
            Me.PageHeaderBand.HeightF = 216.4292!
            Me.PageHeaderBand.Name = "PageHeaderBand"
            '
            'XrLabelBlockedApplications
            '
            Me.XrLabelBlockedApplications.Dpi = 254.0!
            Me.XrLabelBlockedApplications.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelBlockedApplications.ForeColor = System.Drawing.Color.Black
            Me.XrLabelBlockedApplications.LocationFloat = New DevExpress.Utils.PointFloat(1540.963!, 168.1692!)
            Me.XrLabelBlockedApplications.Name = "XrLabelBlockedApplications"
            Me.XrLabelBlockedApplications.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelBlockedApplications.SizeF = New System.Drawing.SizeF(364.0365!, 48.26003!)
            Me.XrLabelBlockedApplications.StyleName = "FieldCaption"
            Me.XrLabelBlockedApplications.StylePriority.UseFont = False
            Me.XrLabelBlockedApplications.StylePriority.UseForeColor = False
            Me.XrLabelBlockedApplications.Text = "Blocked Applications"
            '
            'XrLabelGroups
            '
            Me.XrLabelGroups.Dpi = 254.0!
            Me.XrLabelGroups.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelGroups.ForeColor = System.Drawing.Color.Black
            Me.XrLabelGroups.LocationFloat = New DevExpress.Utils.PointFloat(708.5033!, 168.1692!)
            Me.XrLabelGroups.Name = "XrLabelGroups"
            Me.XrLabelGroups.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelGroups.SizeF = New System.Drawing.SizeF(224.6884!, 48.25999!)
            Me.XrLabelGroups.StyleName = "FieldCaption"
            Me.XrLabelGroups.StylePriority.UseFont = False
            Me.XrLabelGroups.StylePriority.UseForeColor = False
            Me.XrLabelGroups.Text = "Groups"
            '
            'XrLabelUserCode
            '
            Me.XrLabelUserCode.Dpi = 254.0!
            Me.XrLabelUserCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelUserCode.ForeColor = System.Drawing.Color.Black
            Me.XrLabelUserCode.LocationFloat = New DevExpress.Utils.PointFloat(483.8149!, 168.1692!)
            Me.XrLabelUserCode.Name = "XrLabelUserCode"
            Me.XrLabelUserCode.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelUserCode.SizeF = New System.Drawing.SizeF(224.6884!, 48.25999!)
            Me.XrLabelUserCode.StyleName = "FieldCaption"
            Me.XrLabelUserCode.StylePriority.UseFont = False
            Me.XrLabelUserCode.StylePriority.UseForeColor = False
            Me.XrLabelUserCode.Text = "User Code"
            '
            'XrLabelEmployee
            '
            Me.XrLabelEmployee.Dpi = 254.0!
            Me.XrLabelEmployee.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelEmployee.ForeColor = System.Drawing.Color.Black
            Me.XrLabelEmployee.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 168.1692!)
            Me.XrLabelEmployee.Name = "XrLabelEmployee"
            Me.XrLabelEmployee.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelEmployee.SizeF = New System.Drawing.SizeF(483.8149!, 48.25999!)
            Me.XrLabelEmployee.StyleName = "FieldCaption"
            Me.XrLabelEmployee.StylePriority.UseFont = False
            Me.XrLabelEmployee.StylePriority.UseForeColor = False
            Me.XrLabelEmployee.Text = "Employee"
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
            Me.XrLabelLabelHeader.Text = "Security Permission Report"
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
            'XrLabelCategory
            '
            Me.XrLabelCategory.Dpi = 254.0!
            Me.XrLabelCategory.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelCategory.ForeColor = System.Drawing.Color.Black
            Me.XrLabelCategory.LocationFloat = New DevExpress.Utils.PointFloat(24.99977!, 0.0!)
            Me.XrLabelCategory.Name = "XrLabelCategory"
            Me.XrLabelCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelCategory.SizeF = New System.Drawing.SizeF(186.2412!, 48.26!)
            Me.XrLabelCategory.StyleName = "FieldCaption"
            Me.XrLabelCategory.StylePriority.UseFont = False
            Me.XrLabelCategory.StylePriority.UseForeColor = False
            Me.XrLabelCategory.StylePriority.UseTextAlignment = False
            Me.XrLabelCategory.Text = "Category:"
            Me.XrLabelCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'GroupHeaderBandEmployee
            '
            Me.GroupHeaderBandEmployee.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrCheckBoxWebvantageOnly, Me.XrCheckBoxCheckForUserAccess, Me.XrLabelBlockedApplicationsData, Me.XrLabelGroupsData, Me.XrLine2, Me.XrLabelEmployeeData, Me.XrLabelUserCodeData})
            Me.GroupHeaderBandEmployee.Dpi = 254.0!
            Me.GroupHeaderBandEmployee.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("UserCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderBandEmployee.HeightF = 138.3125!
            Me.GroupHeaderBandEmployee.Level = 3
            Me.GroupHeaderBandEmployee.Name = "GroupHeaderBandEmployee"
            Me.GroupHeaderBandEmployee.PageBreak = DevExpress.XtraReports.UI.PageBreak.BeforeBand
            Me.GroupHeaderBandEmployee.RepeatEveryPage = True
            Me.GroupHeaderBandEmployee.StyleName = "DataField"
            '
            'XrCheckBoxWebvantageOnly
            '
            Me.XrCheckBoxWebvantageOnly.Dpi = 254.0!
            Me.XrCheckBoxWebvantageOnly.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrCheckBoxWebvantageOnly.LocationFloat = New DevExpress.Utils.PointFloat(1138.933!, 48.25998!)
            Me.XrCheckBoxWebvantageOnly.Name = "XrCheckBoxWebvantageOnly"
            Me.XrCheckBoxWebvantageOnly.SizeF = New System.Drawing.SizeF(400.0402!, 48.25998!)
            Me.XrCheckBoxWebvantageOnly.StylePriority.UseFont = False
            Me.XrCheckBoxWebvantageOnly.Text = "Webvantage Only"
            '
            'XrCheckBoxCheckForUserAccess
            '
            Me.XrCheckBoxCheckForUserAccess.Dpi = 254.0!
            Me.XrCheckBoxCheckForUserAccess.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrCheckBoxCheckForUserAccess.LocationFloat = New DevExpress.Utils.PointFloat(708.5033!, 48.25998!)
            Me.XrCheckBoxCheckForUserAccess.Name = "XrCheckBoxCheckForUserAccess"
            Me.XrCheckBoxCheckForUserAccess.SizeF = New System.Drawing.SizeF(430.4294!, 48.25998!)
            Me.XrCheckBoxCheckForUserAccess.StylePriority.UseFont = False
            Me.XrCheckBoxCheckForUserAccess.Text = "Check For User Access"
            '
            'XrLabelBlockedApplicationsData
            '
            Me.XrLabelBlockedApplicationsData.Dpi = 254.0!
            Me.XrLabelBlockedApplicationsData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelBlockedApplicationsData.LocationFloat = New DevExpress.Utils.PointFloat(1538.973!, 0.0!)
            Me.XrLabelBlockedApplicationsData.Name = "XrLabelBlockedApplicationsData"
            Me.XrLabelBlockedApplicationsData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelBlockedApplicationsData.SizeF = New System.Drawing.SizeF(364.0367!, 48.26!)
            Me.XrLabelBlockedApplicationsData.StylePriority.UseFont = False
            Me.XrLabelBlockedApplicationsData.StylePriority.UseTextAlignment = False
            Me.XrLabelBlockedApplicationsData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelGroupsData
            '
            Me.XrLabelGroupsData.Dpi = 254.0!
            Me.XrLabelGroupsData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelGroupsData.LocationFloat = New DevExpress.Utils.PointFloat(708.5033!, 0.0!)
            Me.XrLabelGroupsData.Name = "XrLabelGroupsData"
            Me.XrLabelGroupsData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelGroupsData.SizeF = New System.Drawing.SizeF(830.47!, 48.26!)
            Me.XrLabelGroupsData.StylePriority.UseFont = False
            Me.XrLabelGroupsData.StylePriority.UseTextAlignment = False
            Me.XrLabelGroupsData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLine2
            '
            Me.XrLine2.BorderColor = System.Drawing.Color.Silver
            Me.XrLine2.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine2.BorderWidth = 4
            Me.XrLine2.Dpi = 254.0!
            Me.XrLine2.ForeColor = System.Drawing.Color.Silver
            Me.XrLine2.KeepTogether = False
            Me.XrLine2.LineWidth = 10
            Me.XrLine2.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 112.0!)
            Me.XrLine2.Name = "XrLine2"
            Me.XrLine2.SizeF = New System.Drawing.SizeF(1905.0!, 10.16!)
            '
            'XrLabelEmployeeData
            '
            Me.XrLabelEmployeeData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "Employee")})
            Me.XrLabelEmployeeData.Dpi = 254.0!
            Me.XrLabelEmployeeData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelEmployeeData.LocationFloat = New DevExpress.Utils.PointFloat(0.0!, 0.0!)
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
            Me.XrLabelUserCodeData.LocationFloat = New DevExpress.Utils.PointFloat(483.8149!, 0.0!)
            Me.XrLabelUserCodeData.Name = "XrLabelUserCodeData"
            Me.XrLabelUserCodeData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelUserCodeData.SizeF = New System.Drawing.SizeF(224.6884!, 48.26!)
            Me.XrLabelUserCodeData.StylePriority.UseFont = False
            Me.XrLabelUserCodeData.StylePriority.UseTextAlignment = False
            Me.XrLabelUserCodeData.Text = "XrLabelUserCodeData"
            Me.XrLabelUserCodeData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'GroupHeaderBandParentModule
            '
            Me.GroupHeaderBandParentModule.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrSubreportParentModulesPermission, Me.XrLine5, Me.XrLine3, Me.XrLabelCategoryData, Me.XrLabelCategory})
            Me.GroupHeaderBandParentModule.Dpi = 254.0!
            Me.GroupHeaderBandParentModule.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("ParentModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderBandParentModule.HeightF = 134.0!
            Me.GroupHeaderBandParentModule.KeepTogether = True
            Me.GroupHeaderBandParentModule.Level = 2
            Me.GroupHeaderBandParentModule.Name = "GroupHeaderBandParentModule"
            Me.GroupHeaderBandParentModule.StyleName = "DataField"
            '
            'XrSubreportParentModulesPermission
            '
            Me.XrSubreportParentModulesPermission.Dpi = 254.0!
            Me.XrSubreportParentModulesPermission.LocationFloat = New DevExpress.Utils.PointFloat(211.241!, 48.25998!)
            Me.XrSubreportParentModulesPermission.Name = "XrSubreportParentModulesPermission"
            Me.XrSubreportParentModulesPermission.ReportSource = New AdvantageFramework.Reporting.Reports.Security.PermissionSubReport()
            Me.XrSubreportParentModulesPermission.SizeF = New System.Drawing.SizeF(1267.0!, 58.42!)
            '
            'XrLine5
            '
            Me.XrLine5.BorderColor = System.Drawing.Color.Silver
            Me.XrLine5.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine5.BorderWidth = 4
            Me.XrLine5.Dpi = 254.0!
            Me.XrLine5.ForeColor = System.Drawing.Color.Silver
            Me.XrLine5.KeepTogether = False
            Me.XrLine5.LineWidth = 10
            Me.XrLine5.LocationFloat = New DevExpress.Utils.PointFloat(24.99977!, 123.84!)
            Me.XrLine5.Name = "XrLine5"
            Me.XrLine5.SizeF = New System.Drawing.SizeF(1878.01!, 10.16!)
            '
            'XrLine3
            '
            Me.XrLine3.BackColor = System.Drawing.Color.Transparent
            Me.XrLine3.BorderColor = System.Drawing.Color.Transparent
            Me.XrLine3.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine3.BorderWidth = 4
            Me.XrLine3.Dpi = 254.0!
            Me.XrLine3.ForeColor = System.Drawing.Color.Silver
            Me.XrLine3.KeepTogether = False
            Me.XrLine3.LineWidth = 10
            Me.XrLine3.LocationFloat = New DevExpress.Utils.PointFloat(733.5031!, 0.0!)
            Me.XrLine3.Name = "XrLine3"
            Me.XrLine3.SizeF = New System.Drawing.SizeF(1171.496!, 48.26!)
            Me.XrLine3.StylePriority.UseBackColor = False
            Me.XrLine3.StylePriority.UseBorderColor = False
            '
            'XrLabelCategoryData
            '
            Me.XrLabelCategoryData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "ParentModule")})
            Me.XrLabelCategoryData.Dpi = 254.0!
            Me.XrLabelCategoryData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelCategoryData.LocationFloat = New DevExpress.Utils.PointFloat(211.241!, 0.0!)
            Me.XrLabelCategoryData.Name = "XrLabelCategoryData"
            Me.XrLabelCategoryData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelCategoryData.SizeF = New System.Drawing.SizeF(522.2621!, 48.26!)
            Me.XrLabelCategoryData.StylePriority.UseFont = False
            Me.XrLabelCategoryData.StylePriority.UseTextAlignment = False
            Me.XrLabelCategoryData.Text = "XrLabelCategoryData"
            Me.XrLabelCategoryData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
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
            'GroupHeaderBandSubParentModule
            '
            Me.GroupHeaderBandSubParentModule.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine6, Me.XrLine4, Me.XrSubreportSubParentModulesPermission, Me.XrLabelSubCategory, Me.XrLabelSubCategoryData})
            Me.GroupHeaderBandSubParentModule.Dpi = 254.0!
            Me.GroupHeaderBandSubParentModule.FormattingRules.Add(Me.FormattingRule1)
            Me.GroupHeaderBandSubParentModule.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SubParentModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderBandSubParentModule.HeightF = 134.0!
            Me.GroupHeaderBandSubParentModule.KeepTogether = True
            Me.GroupHeaderBandSubParentModule.Level = 1
            Me.GroupHeaderBandSubParentModule.Name = "GroupHeaderBandSubParentModule"
            '
            'XrLine6
            '
            Me.XrLine6.BorderColor = System.Drawing.Color.Silver
            Me.XrLine6.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine6.BorderWidth = 4
            Me.XrLine6.Dpi = 254.0!
            Me.XrLine6.ForeColor = System.Drawing.Color.Silver
            Me.XrLine6.KeepTogether = False
            Me.XrLine6.LineWidth = 10
            Me.XrLine6.LocationFloat = New DevExpress.Utils.PointFloat(211.241!, 123.84!)
            Me.XrLine6.Name = "XrLine6"
            Me.XrLine6.SizeF = New System.Drawing.SizeF(1691.771!, 10.16!)
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
            Me.XrLine4.LocationFloat = New DevExpress.Utils.PointFloat(997.016!, 0.0!)
            Me.XrLine4.Name = "XrLine4"
            Me.XrLine4.SizeF = New System.Drawing.SizeF(907.9836!, 48.26006!)
            Me.XrLine4.StylePriority.UseBorderColor = False
            '
            'XrSubreportSubParentModulesPermission
            '
            Me.XrSubreportSubParentModulesPermission.Dpi = 254.0!
            Me.XrSubreportSubParentModulesPermission.LocationFloat = New DevExpress.Utils.PointFloat(474.7662!, 50.57992!)
            Me.XrSubreportSubParentModulesPermission.Name = "XrSubreportSubParentModulesPermission"
            Me.XrSubreportSubParentModulesPermission.ReportSource = New AdvantageFramework.Reporting.Reports.Security.PermissionSubReport()
            Me.XrSubreportSubParentModulesPermission.SizeF = New System.Drawing.SizeF(1267.0!, 58.42!)
            '
            'XrLabelSubCategory
            '
            Me.XrLabelSubCategory.BackColor = System.Drawing.Color.White
            Me.XrLabelSubCategory.Dpi = 254.0!
            Me.XrLabelSubCategory.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelSubCategory.ForeColor = System.Drawing.Color.Black
            Me.XrLabelSubCategory.LocationFloat = New DevExpress.Utils.PointFloat(211.241!, 0.0!)
            Me.XrLabelSubCategory.Name = "XrLabelSubCategory"
            Me.XrLabelSubCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelSubCategory.SizeF = New System.Drawing.SizeF(263.5252!, 48.26!)
            Me.XrLabelSubCategory.StylePriority.UseFont = False
            Me.XrLabelSubCategory.StylePriority.UseForeColor = False
            Me.XrLabelSubCategory.StylePriority.UseTextAlignment = False
            Me.XrLabelSubCategory.Text = "Sub Category:"
            Me.XrLabelSubCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelSubCategoryData
            '
            Me.XrLabelSubCategoryData.BackColor = System.Drawing.Color.White
            Me.XrLabelSubCategoryData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SubParentModule")})
            Me.XrLabelSubCategoryData.Dpi = 254.0!
            Me.XrLabelSubCategoryData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelSubCategoryData.LocationFloat = New DevExpress.Utils.PointFloat(474.7662!, 0.0!)
            Me.XrLabelSubCategoryData.Name = "XrLabelSubCategoryData"
            Me.XrLabelSubCategoryData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelSubCategoryData.SizeF = New System.Drawing.SizeF(522.2495!, 48.26!)
            Me.XrLabelSubCategoryData.StylePriority.UseFont = False
            Me.XrLabelSubCategoryData.StylePriority.UseTextAlignment = False
            Me.XrLabelSubCategoryData.Text = "XrLabelSubCategoryData"
            Me.XrLabelSubCategoryData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'FormattingRule1
            '
            Me.FormattingRule1.Condition = "IsNull([SubParentModuleID]) == True"
            '
            '
            '
            Me.FormattingRule1.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRule1.Name = "FormattingRule1"
            '
            'GroupHeaderBandSubSubParentModule
            '
            Me.GroupHeaderBandSubSubParentModule.Controls.AddRange(New DevExpress.XtraReports.UI.XRControl() {Me.XrLine7, Me.XrLine8, Me.XrSubreportSubSubParentModulesPermission, Me.XrLabelSubSubCategoryData, Me.XrLabelSubSubCategory})
            Me.GroupHeaderBandSubSubParentModule.Dpi = 254.0!
            Me.GroupHeaderBandSubSubParentModule.FormattingRules.Add(Me.FormattingRule2)
            Me.GroupHeaderBandSubSubParentModule.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("SubSubParentModuleSortOrder", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("SubSubParentModuleID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
            Me.GroupHeaderBandSubSubParentModule.HeightF = 134.0!
            Me.GroupHeaderBandSubSubParentModule.KeepTogether = True
            Me.GroupHeaderBandSubSubParentModule.Name = "GroupHeaderBandSubSubParentModule"
            '
            'XrLine7
            '
            Me.XrLine7.BorderColor = System.Drawing.Color.Transparent
            Me.XrLine7.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine7.BorderWidth = 4
            Me.XrLine7.Dpi = 254.0!
            Me.XrLine7.ForeColor = System.Drawing.Color.Silver
            Me.XrLine7.KeepTogether = False
            Me.XrLine7.LineWidth = 10
            Me.XrLine7.LocationFloat = New DevExpress.Utils.PointFloat(1260.541!, 0.0!)
            Me.XrLine7.Name = "XrLine7"
            Me.XrLine7.SizeF = New System.Drawing.SizeF(642.4689!, 48.26!)
            Me.XrLine7.StylePriority.UseBorderColor = False
            '
            'XrLine8
            '
            Me.XrLine8.BorderColor = System.Drawing.Color.Silver
            Me.XrLine8.Borders = DevExpress.XtraPrinting.BorderSide.None
            Me.XrLine8.BorderWidth = 4
            Me.XrLine8.Dpi = 254.0!
            Me.XrLine8.ForeColor = System.Drawing.Color.Silver
            Me.XrLine8.KeepTogether = False
            Me.XrLine8.LineWidth = 10
            Me.XrLine8.LocationFloat = New DevExpress.Utils.PointFloat(474.7662!, 123.84!)
            Me.XrLine8.Name = "XrLine8"
            Me.XrLine8.SizeF = New System.Drawing.SizeF(1429.244!, 10.16!)
            '
            'XrSubreportSubSubParentModulesPermission
            '
            Me.XrSubreportSubSubParentModulesPermission.Dpi = 254.0!
            Me.XrSubreportSubSubParentModulesPermission.LocationFloat = New DevExpress.Utils.PointFloat(637.9998!, 50.57992!)
            Me.XrSubreportSubSubParentModulesPermission.Name = "XrSubreportSubSubParentModulesPermission"
            Me.XrSubreportSubSubParentModulesPermission.ReportSource = New AdvantageFramework.Reporting.Reports.Security.PermissionSubReport()
            Me.XrSubreportSubSubParentModulesPermission.SizeF = New System.Drawing.SizeF(1267.0!, 58.42!)
            '
            'XrLabelSubSubCategoryData
            '
            Me.XrLabelSubSubCategoryData.BackColor = System.Drawing.Color.White
            Me.XrLabelSubSubCategoryData.DataBindings.AddRange(New DevExpress.XtraReports.UI.XRBinding() {New DevExpress.XtraReports.UI.XRBinding("Text", Nothing, "SubSubParentModule")})
            Me.XrLabelSubSubCategoryData.Dpi = 254.0!
            Me.XrLabelSubSubCategoryData.Font = New System.Drawing.Font("Arial", 8.25!)
            Me.XrLabelSubSubCategoryData.LocationFloat = New DevExpress.Utils.PointFloat(738.2915!, 0.0!)
            Me.XrLabelSubSubCategoryData.Name = "XrLabelSubSubCategoryData"
            Me.XrLabelSubSubCategoryData.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelSubSubCategoryData.SizeF = New System.Drawing.SizeF(522.2495!, 48.26!)
            Me.XrLabelSubSubCategoryData.StylePriority.UseFont = False
            Me.XrLabelSubSubCategoryData.StylePriority.UseTextAlignment = False
            Me.XrLabelSubSubCategoryData.Text = "XrLabelSubSubCategoryData"
            Me.XrLabelSubSubCategoryData.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'XrLabelSubSubCategory
            '
            Me.XrLabelSubSubCategory.BackColor = System.Drawing.Color.White
            Me.XrLabelSubSubCategory.Dpi = 254.0!
            Me.XrLabelSubSubCategory.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.XrLabelSubSubCategory.ForeColor = System.Drawing.Color.Black
            Me.XrLabelSubSubCategory.LocationFloat = New DevExpress.Utils.PointFloat(474.7662!, 0.0!)
            Me.XrLabelSubSubCategory.Name = "XrLabelSubSubCategory"
            Me.XrLabelSubSubCategory.Padding = New DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254.0!)
            Me.XrLabelSubSubCategory.SizeF = New System.Drawing.SizeF(263.5252!, 48.26!)
            Me.XrLabelSubSubCategory.StylePriority.UseFont = False
            Me.XrLabelSubSubCategory.StylePriority.UseForeColor = False
            Me.XrLabelSubSubCategory.StylePriority.UseTextAlignment = False
            Me.XrLabelSubSubCategory.Text = "Sub Category:"
            Me.XrLabelSubSubCategory.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
            '
            'FormattingRule2
            '
            Me.FormattingRule2.Condition = "IsNull([SubSubParentModuleID]) == True"
            '
            '
            '
            Me.FormattingRule2.Formatting.Visible = DevExpress.Utils.DefaultBoolean.[False]
            Me.FormattingRule2.Name = "FormattingRule2"
            '
            'BindingSource
            '
            Me.BindingSource.DataSource = GetType(AdvantageFramework.Security.Database.Views.UserPermissionsReport)
            '
            'PermissionReport
            '
            Me.Bands.AddRange(New DevExpress.XtraReports.UI.Band() {Me.Detail, Me.PageHeaderBand, Me.GroupHeaderBandEmployee, Me.GroupHeaderBandParentModule, Me.PageFooterBand, Me.TopMarginBand, Me.BottomMarginBand, Me.GroupHeaderBandSubParentModule, Me.GroupHeaderBandSubSubParentModule})
            Me.DataSource = Me.BindingSource
            Me.Dpi = 254.0!
            Me.FilterString = "[UserCode] Is Not Null"
            Me.Font = New System.Drawing.Font("Arial", 9.75!)
            Me.FormattingRuleSheet.AddRange(New DevExpress.XtraReports.UI.FormattingRule() {Me.FormattingRule1, Me.FormattingRule2})
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
        Friend WithEvents XrLabelCategory As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderBandEmployee As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelUserCodeData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelEmployeeData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderBandParentModule As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelCategoryData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents PageFooterBand As DevExpress.XtraReports.UI.PageFooterBand
        Friend WithEvents XrPageInfoDate As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrPageInfoPageNumber As DevExpress.XtraReports.UI.XRPageInfo
        Friend WithEvents XrLabelLabelHeader As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents TopMarginBand As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents BottomMarginBand As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents LineTopLine As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine1 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents GroupHeaderBandSubParentModule As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLabelSubCategory As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelSubCategoryData As DevExpress.XtraReports.UI.XRLabel
        Protected Friend WithEvents XrSubreportSubParentModulesPermission As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents PermissionSubReport2 As AdvantageFramework.Reporting.Reports.Security.PermissionSubReport
        Friend WithEvents XrLine2 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine5 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine3 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine6 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine4 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLabelGroups As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelGroupsData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents GroupHeaderBandSubSubParentModule As DevExpress.XtraReports.UI.GroupHeaderBand
        Friend WithEvents XrLine7 As DevExpress.XtraReports.UI.XRLine
        Friend WithEvents XrLine8 As DevExpress.XtraReports.UI.XRLine
        Protected Friend WithEvents XrSubreportSubSubParentModulesPermission As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents PermissionSubReport3 As AdvantageFramework.Reporting.Reports.Security.PermissionSubReport
        Friend WithEvents XrLabelSubSubCategoryData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelSubSubCategory As DevExpress.XtraReports.UI.XRLabel
        Protected Friend WithEvents XrSubreportParentModulesPermission As DevExpress.XtraReports.UI.XRSubreport
        Private WithEvents PermissionSubReport1 As AdvantageFramework.Reporting.Reports.Security.PermissionSubReport
        Friend WithEvents FormattingRule1 As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents FormattingRule2 As DevExpress.XtraReports.UI.FormattingRule
        Friend WithEvents BindingSource As System.Windows.Forms.BindingSource
        Friend WithEvents XrLabelBlockedApplications As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrLabelBlockedApplicationsData As DevExpress.XtraReports.UI.XRLabel
        Friend WithEvents XrCheckBoxWebvantageOnly As DevExpress.XtraReports.UI.XRCheckBox
        Friend WithEvents XrCheckBoxCheckForUserAccess As DevExpress.XtraReports.UI.XRCheckBox

    End Class

End Namespace
