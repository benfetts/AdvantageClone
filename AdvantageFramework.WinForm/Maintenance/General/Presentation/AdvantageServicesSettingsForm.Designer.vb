Namespace Maintenance.General.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdvantageServicesSettingsForm
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageServicesSettingsForm))
            Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemSearch_Month = New DevComponents.DotNetBar.ControlContainerItem()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarFilePanel_Settings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSettings_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarFilePanel_Service = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemService_Enabled = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemService_ProcessNow = New DevComponents.DotNetBar.ButtonItem()
            Me.AdvantageServicesSettingsForm_Settings = New AdvantageFramework.WinForm.Presentation.Controls.AdvantageServicesSettingsControl()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'ItemContainerDatabaseProfiles_CurrentDatabaseProfile
            '
            '
            '
            '
            Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.Name = "ItemContainerDatabaseProfiles_CurrentDatabaseProfile"
            Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile, Me.ControlContainerItemSearch_Month})
            '
            '
            '
            Me.ItemContainerDatabaseProfiles_CurrentDatabaseProfile.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile
            '
            Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile.Name = "LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile"
            Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile.Text = "Current:"
            Me.LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile.Width = 58
            '
            'ControlContainerItemSearch_Month
            '
            Me.ControlContainerItemSearch_Month.AllowItemResize = True
            Me.ControlContainerItemSearch_Month.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemSearch_Month.Name = "ControlContainerItemSearch_Month"
            Me.ControlContainerItemSearch_Month.Text = "ControlContainerItem2"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarFilePanel_Settings)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarFilePanel_Service)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(52, 252)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(909, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 9
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarFilePanel_Settings
            '
            Me.RibbonBarFilePanel_Settings.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Settings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Settings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Settings.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Settings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Settings.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFilePanel_Settings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSettings_Save})
            Me.RibbonBarFilePanel_Settings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Settings.Location = New System.Drawing.Point(192, 0)
            Me.RibbonBarFilePanel_Settings.Name = "RibbonBarFilePanel_Settings"
            Me.RibbonBarFilePanel_Settings.Size = New System.Drawing.Size(100, 98)
            Me.RibbonBarFilePanel_Settings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Settings.TabIndex = 7
            Me.RibbonBarFilePanel_Settings.Text = "Settings"
            '
            '
            '
            Me.RibbonBarFilePanel_Settings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Settings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Settings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemSettings_Save
            '
            Me.ButtonItemSettings_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSettings_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSettings_Save.Name = "ButtonItemSettings_Save"
            Me.ButtonItemSettings_Save.SubItemsExpandWidth = 14
            Me.ButtonItemSettings_Save.Text = "Save"
            '
            'RibbonBarFilePanel_Service
            '
            Me.RibbonBarFilePanel_Service.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Service.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Service.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Service.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Service.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Service.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFilePanel_Service.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemService_Enabled, Me.ButtonItemService_ProcessNow})
            Me.RibbonBarFilePanel_Service.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Service.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarFilePanel_Service.Name = "RibbonBarFilePanel_Service"
            Me.RibbonBarFilePanel_Service.Size = New System.Drawing.Size(192, 98)
            Me.RibbonBarFilePanel_Service.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Service.TabIndex = 10
            Me.RibbonBarFilePanel_Service.Text = "Service"
            '
            '
            '
            Me.RibbonBarFilePanel_Service.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Service.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Service.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemService_Enabled
            '
            Me.ButtonItemService_Enabled.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemService_Enabled.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemService_Enabled.Name = "ButtonItemService_Enabled"
            Me.ButtonItemService_Enabled.SubItemsExpandWidth = 14
            Me.ButtonItemService_Enabled.Text = "Enabled"
            '
            'ButtonItemService_ProcessNow
            '
            Me.ButtonItemService_ProcessNow.BeginGroup = True
            Me.ButtonItemService_ProcessNow.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemService_ProcessNow.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemService_ProcessNow.Name = "ButtonItemService_ProcessNow"
            Me.ButtonItemService_ProcessNow.SubItemsExpandWidth = 14
            Me.ButtonItemService_ProcessNow.Text = "Process Now"
            '
            'AdvantageServicesSettingsForm_Settings
            '
            Me.AdvantageServicesSettingsForm_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.AdvantageServicesSettingsForm_Settings.BackColor = System.Drawing.Color.White
            Me.AdvantageServicesSettingsForm_Settings.Location = New System.Drawing.Point(12, 12)
            Me.AdvantageServicesSettingsForm_Settings.Name = "AdvantageServicesSettingsForm_Settings"
            Me.AdvantageServicesSettingsForm_Settings.Size = New System.Drawing.Size(989, 579)
            Me.AdvantageServicesSettingsForm_Settings.TabIndex = 10
            '
            'AdvantageServicesSettingsForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1013, 603)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.AdvantageServicesSettingsForm_Settings)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AdvantageServicesSettingsForm"
            Me.Text = "Advantage Services Settings"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ItemContainerDatabaseProfiles_CurrentDatabaseProfile As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemCurrentDatabaseProfile_CurrentDatabaseProfile As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemSearch_Month As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarFilePanel_Settings As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemSettings_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarFilePanel_Service As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemService_Enabled As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemService_ProcessNow As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents AdvantageServicesSettingsForm_Settings As AdvantageFramework.WinForm.Presentation.Controls.AdvantageServicesSettingsControl
    End Class

End Namespace
