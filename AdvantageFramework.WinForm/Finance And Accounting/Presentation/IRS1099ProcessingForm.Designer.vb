Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IRS1099ProcessingForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IRS1099ProcessingForm))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Settings = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_PrintStandardReport = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_PrintStandardForm = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Print1099ReportAllVendorsSummary = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Print1099ReportWithAPDisbursement = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Transmit = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_1099Data = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOption_Maintenance = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMaintenance_FederalStateCodes = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Vendor = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemVendor_Edit = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTransmit_1099MISC = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemTransmit_1099NEC = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Settings, Me.ButtonItemActions_Search, Me.ButtonItemActions_Print, Me.ButtonItemActions_Transmit})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(199, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 4
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Settings
            '
            Me.ButtonItemActions_Settings.BeginGroup = True
            Me.ButtonItemActions_Settings.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Settings.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Settings.Name = "ButtonItemActions_Settings"
            Me.ButtonItemActions_Settings.SecurityEnabled = True
            Me.ButtonItemActions_Settings.Stretch = True
            Me.ButtonItemActions_Settings.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Settings.Text = "Settings"
            '
            'ButtonItemActions_Search
            '
            Me.ButtonItemActions_Search.BeginGroup = True
            Me.ButtonItemActions_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Search.Name = "ButtonItemActions_Search"
            Me.ButtonItemActions_Search.SecurityEnabled = True
            Me.ButtonItemActions_Search.Stretch = True
            Me.ButtonItemActions_Search.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Search.Text = "Search"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.AutoExpandOnClick = True
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SplitButton = True
            Me.ButtonItemActions_Print.Stretch = True
            Me.ButtonItemActions_Print.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_PrintStandardReport, Me.ButtonItemActions_PrintStandardForm, Me.ButtonItemActions_Print1099ReportAllVendorsSummary, Me.ButtonItemActions_Print1099ReportWithAPDisbursement})
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'ButtonItemActions_PrintStandardReport
            '
            Me.ButtonItemActions_PrintStandardReport.Name = "ButtonItemActions_PrintStandardReport"
            Me.ButtonItemActions_PrintStandardReport.Text = "Standard Report (Vendors Marked for 1099)"
            '
            'ButtonItemActions_PrintStandardForm
            '
            Me.ButtonItemActions_PrintStandardForm.Name = "ButtonItemActions_PrintStandardForm"
            Me.ButtonItemActions_PrintStandardForm.Text = "Standard Form (Laser)"
            '
            'ButtonItemActions_Print1099ReportAllVendorsSummary
            '
            Me.ButtonItemActions_Print1099ReportAllVendorsSummary.Name = "ButtonItemActions_Print1099ReportAllVendorsSummary"
            Me.ButtonItemActions_Print1099ReportAllVendorsSummary.Text = "1099 Report (Summary)"
            '
            'ButtonItemActions_Print1099ReportWithAPDisbursement
            '
            Me.ButtonItemActions_Print1099ReportWithAPDisbursement.Name = "ButtonItemActions_Print1099ReportWithAPDisbursement"
            Me.ButtonItemActions_Print1099ReportWithAPDisbursement.Text = "1099 Report - With AP Detail Disbursement"
            '
            'ButtonItemActions_Transmit
            '
            Me.ButtonItemActions_Transmit.AutoExpandOnClick = True
            Me.ButtonItemActions_Transmit.BeginGroup = True
            Me.ButtonItemActions_Transmit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Transmit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Transmit.Name = "ButtonItemActions_Transmit"
            Me.ButtonItemActions_Transmit.SecurityEnabled = True
            Me.ButtonItemActions_Transmit.Stretch = True
            Me.ButtonItemActions_Transmit.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemTransmit_1099MISC, Me.ButtonItemTransmit_1099NEC})
            Me.ButtonItemActions_Transmit.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Transmit.Text = "Transmit"
            '
            'DataGridViewForm_1099Data
            '
            Me.DataGridViewForm_1099Data.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_1099Data.AllowDragAndDrop = False
            Me.DataGridViewForm_1099Data.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_1099Data.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_1099Data.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_1099Data.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_1099Data.AutoFilterLookupColumns = False
            Me.DataGridViewForm_1099Data.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_1099Data.AutoUpdateViewCaption = True
            Me.DataGridViewForm_1099Data.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_1099Data.DataSource = Nothing
            Me.DataGridViewForm_1099Data.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_1099Data.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_1099Data.ItemDescription = "Vendor(s) For 1099 Processing"
            Me.DataGridViewForm_1099Data.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_1099Data.MultiSelect = True
            Me.DataGridViewForm_1099Data.Name = "DataGridViewForm_1099Data"
            Me.DataGridViewForm_1099Data.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_1099Data.RunStandardValidation = True
            Me.DataGridViewForm_1099Data.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_1099Data.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_1099Data.Size = New System.Drawing.Size(1080, 510)
            Me.DataGridViewForm_1099Data.TabIndex = 41
            Me.DataGridViewForm_1099Data.UseEmbeddedNavigator = False
            Me.DataGridViewForm_1099Data.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOption_Maintenance)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Vendor)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(819, 98)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 69
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOption_Maintenance
            '
            Me.RibbonBarOption_Maintenance.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOption_Maintenance.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOption_Maintenance.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOption_Maintenance.ContainerControlProcessDialogKey = True
            Me.RibbonBarOption_Maintenance.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOption_Maintenance.DragDropSupport = True
            Me.RibbonBarOption_Maintenance.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMaintenance_FederalStateCodes})
            Me.RibbonBarOption_Maintenance.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOption_Maintenance.Location = New System.Drawing.Point(251, 0)
            Me.RibbonBarOption_Maintenance.Name = "RibbonBarOption_Maintenance"
            Me.RibbonBarOption_Maintenance.SecurityEnabled = True
            Me.RibbonBarOption_Maintenance.Size = New System.Drawing.Size(128, 98)
            Me.RibbonBarOption_Maintenance.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOption_Maintenance.TabIndex = 24
            Me.RibbonBarOption_Maintenance.Text = "Maintenance"
            '
            '
            '
            Me.RibbonBarOption_Maintenance.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOption_Maintenance.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOption_Maintenance.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemMaintenance_FederalStateCodes
            '
            Me.ButtonItemMaintenance_FederalStateCodes.BeginGroup = True
            Me.ButtonItemMaintenance_FederalStateCodes.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMaintenance_FederalStateCodes.Name = "ButtonItemMaintenance_FederalStateCodes"
            Me.ButtonItemMaintenance_FederalStateCodes.RibbonWordWrap = False
            Me.ButtonItemMaintenance_FederalStateCodes.SubItemsExpandWidth = 14
            Me.ButtonItemMaintenance_FederalStateCodes.Text = "Federal State Codes"
            '
            'RibbonBarOptions_Vendor
            '
            Me.RibbonBarOptions_Vendor.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Vendor.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Vendor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Vendor.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Vendor.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Vendor.DragDropSupport = True
            Me.RibbonBarOptions_Vendor.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemVendor_Edit})
            Me.RibbonBarOptions_Vendor.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Vendor.Location = New System.Drawing.Point(199, 0)
            Me.RibbonBarOptions_Vendor.Name = "RibbonBarOptions_Vendor"
            Me.RibbonBarOptions_Vendor.SecurityEnabled = True
            Me.RibbonBarOptions_Vendor.Size = New System.Drawing.Size(52, 98)
            Me.RibbonBarOptions_Vendor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Vendor.TabIndex = 23
            Me.RibbonBarOptions_Vendor.Text = "Vendor"
            '
            '
            '
            Me.RibbonBarOptions_Vendor.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Vendor.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Vendor.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemVendor_Edit
            '
            Me.ButtonItemVendor_Edit.BeginGroup = True
            Me.ButtonItemVendor_Edit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemVendor_Edit.Name = "ButtonItemVendor_Edit"
            Me.ButtonItemVendor_Edit.RibbonWordWrap = False
            Me.ButtonItemVendor_Edit.SubItemsExpandWidth = 14
            Me.ButtonItemVendor_Edit.Text = "Edit"
            '
            'ButtonItemTransmit_1099MISC
            '
            Me.ButtonItemTransmit_1099MISC.Name = "ButtonItemTransmit_1099MISC"
            Me.ButtonItemTransmit_1099MISC.Text = "1099-MISC"
            '
            'ButtonItemTransmit_1099NEC
            '
            Me.ButtonItemTransmit_1099NEC.Name = "ButtonItemTransmit_1099NEC"
            Me.ButtonItemTransmit_1099NEC.Text = "1099-NEC"
            '
            'IRS1099ProcessingForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1104, 534)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_1099Data)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "IRS1099ProcessingForm"
            Me.Text = "1099 Processing"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DataGridViewForm_1099Data As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents ButtonItemActions_Search As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Transmit As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_PrintStandardReport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_PrintStandardForm As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Settings As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Vendor As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemVendor_Edit As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Print1099ReportAllVendorsSummary As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Print1099ReportWithAPDisbursement As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOption_Maintenance As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMaintenance_FederalStateCodes As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTransmit_1099MISC As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemTransmit_1099NEC As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace