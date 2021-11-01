Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class TimeSeparationSettingsEditDialog
        Inherits WinForm.MVC.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TimeSeparationSettingsEditDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelForm_ClientLabel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Client = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewForm_TimeSeparationSettings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelForm_MediaTypeLabel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_MediaType = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.CheckBoxForm_CrossLengthSeparationEnabled = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.LabelForm_CrossLengthSeparationLabel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputForm_CrossLengthSeparation = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_CrossLengthSeparation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.NumericInputForm_CrossLengthSeparation)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_CrossLengthSeparationLabel)
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_CrossLengthSeparationEnabled)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_MediaType)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_MediaTypeLabel)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_TimeSeparationSettings)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Client)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_ClientLabel)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(519, 319)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(519, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(519, 94)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(52, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 0
            '
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 474)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(519, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel, Me.ButtonItemActions_Delete})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(55, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(291, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 12
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SecurityEnabled = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'LabelForm_ClientLabel
            '
            Me.LabelForm_ClientLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ClientLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ClientLabel.Location = New System.Drawing.Point(3, 32)
            Me.LabelForm_ClientLabel.Name = "LabelForm_ClientLabel"
            Me.LabelForm_ClientLabel.Size = New System.Drawing.Size(73, 20)
            Me.LabelForm_ClientLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ClientLabel.TabIndex = 2
            Me.LabelForm_ClientLabel.Text = "Client:"
            '
            'LabelForm_Client
            '
            Me.LabelForm_Client.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Client.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Client.Location = New System.Drawing.Point(82, 32)
            Me.LabelForm_Client.Name = "LabelForm_Client"
            Me.LabelForm_Client.Size = New System.Drawing.Size(434, 20)
            Me.LabelForm_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Client.TabIndex = 3
            '
            'DataGridViewForm_TimeSeparationSettings
            '
            Me.DataGridViewForm_TimeSeparationSettings.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_TimeSeparationSettings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_TimeSeparationSettings.AutoUpdateViewCaption = True
            Me.DataGridViewForm_TimeSeparationSettings.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_TimeSeparationSettings.ItemDescription = "Item(s)"
            Me.DataGridViewForm_TimeSeparationSettings.Location = New System.Drawing.Point(3, 84)
            Me.DataGridViewForm_TimeSeparationSettings.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_TimeSeparationSettings.ModifyGridRowHeight = False
            Me.DataGridViewForm_TimeSeparationSettings.MultiSelect = False
            Me.DataGridViewForm_TimeSeparationSettings.Name = "DataGridViewForm_TimeSeparationSettings"
            Me.DataGridViewForm_TimeSeparationSettings.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_TimeSeparationSettings.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_TimeSeparationSettings.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_TimeSeparationSettings.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_TimeSeparationSettings.Size = New System.Drawing.Size(513, 229)
            Me.DataGridViewForm_TimeSeparationSettings.TabIndex = 4
            Me.DataGridViewForm_TimeSeparationSettings.UseEmbeddedNavigator = False
            Me.DataGridViewForm_TimeSeparationSettings.ViewCaptionHeight = -1
            '
            'LabelForm_MediaTypeLabel
            '
            Me.LabelForm_MediaTypeLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaTypeLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaTypeLabel.Location = New System.Drawing.Point(3, 6)
            Me.LabelForm_MediaTypeLabel.Name = "LabelForm_MediaTypeLabel"
            Me.LabelForm_MediaTypeLabel.Size = New System.Drawing.Size(73, 20)
            Me.LabelForm_MediaTypeLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaTypeLabel.TabIndex = 0
            Me.LabelForm_MediaTypeLabel.Text = "Media Type:"
            '
            'LabelForm_MediaType
            '
            Me.LabelForm_MediaType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_MediaType.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MediaType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MediaType.Location = New System.Drawing.Point(82, 6)
            Me.LabelForm_MediaType.Name = "LabelForm_MediaType"
            Me.LabelForm_MediaType.Size = New System.Drawing.Size(434, 20)
            Me.LabelForm_MediaType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MediaType.TabIndex = 1
            '
            'CheckBoxForm_CrossLengthSeparationEnabled
            '
            Me.CheckBoxForm_CrossLengthSeparationEnabled.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.CheckBoxForm_CrossLengthSeparationEnabled.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CrossLengthSeparationEnabled.CheckValue = 0
            Me.CheckBoxForm_CrossLengthSeparationEnabled.CheckValueChecked = 1
            Me.CheckBoxForm_CrossLengthSeparationEnabled.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CrossLengthSeparationEnabled.CheckValueUnchecked = 0
            Me.CheckBoxForm_CrossLengthSeparationEnabled.ChildControls = Nothing
            Me.CheckBoxForm_CrossLengthSeparationEnabled.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CrossLengthSeparationEnabled.Location = New System.Drawing.Point(3, 58)
            Me.CheckBoxForm_CrossLengthSeparationEnabled.Name = "CheckBoxForm_CrossLengthSeparationEnabled"
            Me.CheckBoxForm_CrossLengthSeparationEnabled.OldestSibling = Nothing
            Me.CheckBoxForm_CrossLengthSeparationEnabled.SecurityEnabled = True
            Me.CheckBoxForm_CrossLengthSeparationEnabled.SiblingControls = Nothing
            Me.CheckBoxForm_CrossLengthSeparationEnabled.Size = New System.Drawing.Size(197, 20)
            Me.CheckBoxForm_CrossLengthSeparationEnabled.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CrossLengthSeparationEnabled.TabIndex = 4
            Me.CheckBoxForm_CrossLengthSeparationEnabled.TabOnEnter = True
            Me.CheckBoxForm_CrossLengthSeparationEnabled.Text = "Enable Cross-length separation"
            '
            'LabelForm_CrossLengthSeparationLabel
            '
            Me.LabelForm_CrossLengthSeparationLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CrossLengthSeparationLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CrossLengthSeparationLabel.Location = New System.Drawing.Point(206, 58)
            Me.LabelForm_CrossLengthSeparationLabel.Name = "LabelForm_CrossLengthSeparationLabel"
            Me.LabelForm_CrossLengthSeparationLabel.Size = New System.Drawing.Size(107, 20)
            Me.LabelForm_CrossLengthSeparationLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CrossLengthSeparationLabel.TabIndex = 5
            Me.LabelForm_CrossLengthSeparationLabel.Text = "Cross-length value:"
            '
            'NumericInputForm_CrossLengthSeparation
            '
            Me.NumericInputForm_CrossLengthSeparation.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_CrossLengthSeparation.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputForm_CrossLengthSeparation.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_CrossLengthSeparation.EnterMoveNextControl = True
            Me.NumericInputForm_CrossLengthSeparation.Location = New System.Drawing.Point(319, 59)
            Me.NumericInputForm_CrossLengthSeparation.Name = "NumericInputForm_CrossLengthSeparation"
            Me.NumericInputForm_CrossLengthSeparation.Properties.AllowMouseWheel = False
            Me.NumericInputForm_CrossLengthSeparation.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_CrossLengthSeparation.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_CrossLengthSeparation.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_CrossLengthSeparation.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_CrossLengthSeparation.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_CrossLengthSeparation.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_CrossLengthSeparation.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_CrossLengthSeparation.Properties.IsFloatValue = False
            Me.NumericInputForm_CrossLengthSeparation.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_CrossLengthSeparation.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_CrossLengthSeparation.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputForm_CrossLengthSeparation.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputForm_CrossLengthSeparation.SecurityEnabled = True
            Me.NumericInputForm_CrossLengthSeparation.Size = New System.Drawing.Size(41, 20)
            Me.NumericInputForm_CrossLengthSeparation.TabIndex = 6
            Me.NumericInputForm_CrossLengthSeparation.ToolTip = "Cross-length separation in minutes; 0 means ignore; range 0-999"
            '
            'TimeSeparationSettingsEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.ClientSize = New System.Drawing.Size(529, 494)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "TimeSeparationSettingsEditDialog"
            Me.Text = "Time Separation Settings"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_CrossLengthSeparation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Save As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelForm_Client As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_ClientLabel As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_TimeSeparationSettings As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_MediaType As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_MediaTypeLabel As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_CrossLengthSeparationLabel As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_CrossLengthSeparationEnabled As WinForm.MVC.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputForm_CrossLengthSeparation As WinForm.MVC.Presentation.Controls.NumericInput
    End Class

End Namespace