Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaRFPPrintingOptionsDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaRFPPrintingOptionsDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_FormatLabel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Format = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.VerticalGridMediaRFP_Settings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.VerticalGrid()
            Me.RFPPrintSettingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.categoryOptionalDetailInformation = New DevExpress.XtraVerticalGrid.Rows.CategoryRow()
            Me.rowIncludeCPP = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            Me.rowIncludeGRP = New DevExpress.XtraVerticalGrid.Rows.EditorRow()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.VerticalGridMediaRFP_Settings, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.RFPPrintSettingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "DevExpress Design"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.VerticalGridMediaRFP_Settings)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Format)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_FormatLabel)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
            Me.PanelForm_Form.Size = New System.Drawing.Size(679, 245)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0, 0, 0, 4)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(679, 154)
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
            Me.RibbonPanelFile_FilePanel.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(4, 0, 4, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(679, 93)
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
            Me.RibbonPanelFile_FilePanel.Visible = True
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
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(4, 0)
            Me.RibbonBarFilePanel_System.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 91)
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
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 400)
            Me.BarForm_StatusBar.Margin = New System.Windows.Forms.Padding(4)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(679, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(104, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(142, 91)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 13
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
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'LabelForm_FormatLabel
            '
            Me.LabelForm_FormatLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FormatLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FormatLabel.Location = New System.Drawing.Point(12, 7)
            Me.LabelForm_FormatLabel.Name = "LabelForm_FormatLabel"
            Me.LabelForm_FormatLabel.Size = New System.Drawing.Size(51, 20)
            Me.LabelForm_FormatLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FormatLabel.TabIndex = 0
            Me.LabelForm_FormatLabel.Text = "Format:"
            '
            'LabelForm_Format
            '
            Me.LabelForm_Format.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Format.Location = New System.Drawing.Point(69, 7)
            Me.LabelForm_Format.Name = "LabelForm_Format"
            Me.LabelForm_Format.Size = New System.Drawing.Size(598, 20)
            Me.LabelForm_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Format.TabIndex = 1
            '
            'VerticalGridMediaRFP_Settings
            '
            Me.VerticalGridMediaRFP_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VerticalGridMediaRFP_Settings.Appearance.RowHeaderPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold)
            Me.VerticalGridMediaRFP_Settings.Appearance.RowHeaderPanel.Options.UseFont = True
            Me.VerticalGridMediaRFP_Settings.Cursor = System.Windows.Forms.Cursors.Default
            Me.VerticalGridMediaRFP_Settings.CustomizationFormBounds = New System.Drawing.Rectangle(1384, 433, 216, 265)
            Me.VerticalGridMediaRFP_Settings.DataSource = Me.RFPPrintSettingBindingSource
            Me.VerticalGridMediaRFP_Settings.LayoutStyle = DevExpress.XtraVerticalGrid.LayoutViewStyle.SingleRecordView
            Me.VerticalGridMediaRFP_Settings.Location = New System.Drawing.Point(12, 33)
            Me.VerticalGridMediaRFP_Settings.Name = "VerticalGridMediaRFP_Settings"
            Me.VerticalGridMediaRFP_Settings.OptionsBehavior.RecordsMouseWheel = True
            Me.VerticalGridMediaRFP_Settings.OptionsBehavior.ResizeRowHeaders = False
            Me.VerticalGridMediaRFP_Settings.OptionsBehavior.UseEnterAsTab = True
            Me.VerticalGridMediaRFP_Settings.RecordWidth = 88
            Me.VerticalGridMediaRFP_Settings.RowHeaderWidth = 112
            Me.VerticalGridMediaRFP_Settings.Rows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.categoryOptionalDetailInformation})
            Me.VerticalGridMediaRFP_Settings.ShowButtonMode = DevExpress.XtraVerticalGrid.ShowButtonModeEnum.ShowAlways
            Me.VerticalGridMediaRFP_Settings.Size = New System.Drawing.Size(655, 206)
            Me.VerticalGridMediaRFP_Settings.TabIndex = 2
            Me.VerticalGridMediaRFP_Settings.TreeButtonStyle = DevExpress.XtraVerticalGrid.TreeButtonStyle.TreeView
            '
            'RFPPrintSettingBindingSource
            '
            Me.RFPPrintSettingBindingSource.DataSource = GetType(AdvantageFramework.DTO.Media.RFP.PrintSetting)
            '
            'categoryOptionalDetailInformation
            '
            Me.categoryOptionalDetailInformation.ChildRows.AddRange(New DevExpress.XtraVerticalGrid.Rows.BaseRow() {Me.rowIncludeCPP, Me.rowIncludeGRP})
            Me.categoryOptionalDetailInformation.Name = "categoryOptionalDetailInformation"
            Me.categoryOptionalDetailInformation.Properties.Caption = "Optional Detail Information"
            '
            'rowIncludeCPP
            '
            Me.rowIncludeCPP.Name = "rowIncludeCPP"
            Me.rowIncludeCPP.Properties.Caption = "Include CPP"
            Me.rowIncludeCPP.Properties.FieldName = "IncludeCPP"
            '
            'rowIncludeGRP
            '
            Me.rowIncludeGRP.Name = "rowIncludeGRP"
            Me.rowIncludeGRP.Properties.Caption = "Include GRP"
            Me.rowIncludeGRP.Properties.FieldName = "IncludeGRP"
            '
            'MediaRFPPrintingOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(689, 420)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "MediaRFPPrintingOptionsDialog"
            Me.Text = "Media RFP Printing Options"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.VerticalGridMediaRFP_Settings, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.RFPPrintSettingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Private WithEvents LabelForm_FormatLabel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Private WithEvents LabelForm_Format As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents VerticalGridMediaRFP_Settings As WinForm.MVC.Presentation.Controls.VerticalGrid
        Friend WithEvents RFPPrintSettingBindingSource As Windows.Forms.BindingSource
        Friend WithEvents categoryOptionalDetailInformation As DevExpress.XtraVerticalGrid.Rows.CategoryRow
        Friend WithEvents rowIncludeCPP As DevExpress.XtraVerticalGrid.Rows.EditorRow
        Friend WithEvents rowIncludeGRP As DevExpress.XtraVerticalGrid.Rows.EditorRow
    End Class

End Namespace

