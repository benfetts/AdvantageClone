Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaTrafficProcessGenerateDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaTrafficProcessGenerateDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Process = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_DefaultEmailSettings = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDefaultEmailSettings_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.CheckBoxForm_CCToSender = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.TextBoxForm_Subject = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxForm_Body = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_Body = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Subject = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewForm_VendorReps = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelForm_Comment = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxNewComment = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.PanelForm_Form.Controls.Add(Me.TextBoxNewComment)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Comment)
            Me.PanelForm_Form.Controls.Add(Me.CheckBoxForm_CCToSender)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_Body)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Body)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_Subject)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_VendorReps)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1005, 407)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1005, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_DefaultEmailSettings)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1005, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_DefaultEmailSettings, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
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
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 562)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1005, 18)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Process, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(115, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 14
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
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.BeginGroup = True
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.RibbonWordWrap = False
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
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
            'RibbonBarOptions_DefaultEmailSettings
            '
            Me.RibbonBarOptions_DefaultEmailSettings.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_DefaultEmailSettings.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DefaultEmailSettings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DefaultEmailSettings.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_DefaultEmailSettings.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_DefaultEmailSettings.DragDropSupport = True
            Me.RibbonBarOptions_DefaultEmailSettings.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_DefaultEmailSettings.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDefaultEmailSettings_Save})
            Me.RibbonBarOptions_DefaultEmailSettings.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_DefaultEmailSettings.Location = New System.Drawing.Point(218, 0)
            Me.RibbonBarOptions_DefaultEmailSettings.MinimumSize = New System.Drawing.Size(133, 0)
            Me.RibbonBarOptions_DefaultEmailSettings.Name = "RibbonBarOptions_DefaultEmailSettings"
            Me.RibbonBarOptions_DefaultEmailSettings.SecurityEnabled = True
            Me.RibbonBarOptions_DefaultEmailSettings.Size = New System.Drawing.Size(133, 92)
            Me.RibbonBarOptions_DefaultEmailSettings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_DefaultEmailSettings.TabIndex = 16
            Me.RibbonBarOptions_DefaultEmailSettings.Text = "Default Email Settings"
            '
            '
            '
            Me.RibbonBarOptions_DefaultEmailSettings.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_DefaultEmailSettings.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_DefaultEmailSettings.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDefaultEmailSettings_Save
            '
            Me.ButtonItemDefaultEmailSettings_Save.BeginGroup = True
            Me.ButtonItemDefaultEmailSettings_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDefaultEmailSettings_Save.Name = "ButtonItemDefaultEmailSettings_Save"
            Me.ButtonItemDefaultEmailSettings_Save.RibbonWordWrap = False
            Me.ButtonItemDefaultEmailSettings_Save.SubItemsExpandWidth = 14
            Me.ButtonItemDefaultEmailSettings_Save.Text = "Save"
            '
            'CheckBoxForm_CCToSender
            '
            Me.CheckBoxForm_CCToSender.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_CCToSender.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CCToSender.CheckValue = 0
            Me.CheckBoxForm_CCToSender.CheckValueChecked = 1
            Me.CheckBoxForm_CCToSender.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CCToSender.CheckValueUnchecked = 0
            Me.CheckBoxForm_CCToSender.ChildControls = CType(resources.GetObject("CheckBoxForm_CCToSender.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CCToSender.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CCToSender.Location = New System.Drawing.Point(93, 178)
            Me.CheckBoxForm_CCToSender.Name = "CheckBoxForm_CCToSender"
            Me.CheckBoxForm_CCToSender.OldestSibling = Nothing
            Me.CheckBoxForm_CCToSender.SecurityEnabled = True
            Me.CheckBoxForm_CCToSender.SiblingControls = CType(resources.GetObject("CheckBoxForm_CCToSender.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CCToSender.Size = New System.Drawing.Size(900, 20)
            Me.CheckBoxForm_CCToSender.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CCToSender.TabIndex = 11
            Me.CheckBoxForm_CCToSender.TabOnEnter = True
            Me.CheckBoxForm_CCToSender.Text = "CC to Sender"
            '
            'TextBoxForm_Subject
            '
            Me.TextBoxForm_Subject.AgencyImportPath = Nothing
            Me.TextBoxForm_Subject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Subject.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Subject.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Subject.CheckSpellingOnValidate = False
            Me.TextBoxForm_Subject.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Subject.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Subject.DisplayName = ""
            Me.TextBoxForm_Subject.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Subject.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Subject.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Subject.FocusHighlightEnabled = True
            Me.TextBoxForm_Subject.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Subject.Location = New System.Drawing.Point(93, 6)
            Me.TextBoxForm_Subject.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Subject.Name = "TextBoxForm_Subject"
            Me.TextBoxForm_Subject.SecurityEnabled = True
            Me.TextBoxForm_Subject.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Subject.Size = New System.Drawing.Size(900, 21)
            Me.TextBoxForm_Subject.StartingFolderName = Nothing
            Me.TextBoxForm_Subject.TabIndex = 8
            Me.TextBoxForm_Subject.TabOnEnter = True
            '
            'TextBoxForm_Body
            '
            Me.TextBoxForm_Body.AcceptsReturn = True
            Me.TextBoxForm_Body.AgencyImportPath = Nothing
            Me.TextBoxForm_Body.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Body.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Body.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Body.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Body.CheckSpellingOnValidate = False
            Me.TextBoxForm_Body.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Body.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Body.DisplayName = ""
            Me.TextBoxForm_Body.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Body.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Body.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Body.FocusHighlightEnabled = True
            Me.TextBoxForm_Body.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Body.Location = New System.Drawing.Point(93, 33)
            Me.TextBoxForm_Body.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Body.Multiline = True
            Me.TextBoxForm_Body.Name = "TextBoxForm_Body"
            Me.TextBoxForm_Body.SecurityEnabled = True
            Me.TextBoxForm_Body.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Body.Size = New System.Drawing.Size(900, 139)
            Me.TextBoxForm_Body.StartingFolderName = Nothing
            Me.TextBoxForm_Body.TabIndex = 10
            Me.TextBoxForm_Body.TabOnEnter = False
            '
            'LabelForm_Body
            '
            Me.LabelForm_Body.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Body.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Body.Location = New System.Drawing.Point(12, 33)
            Me.LabelForm_Body.Name = "LabelForm_Body"
            Me.LabelForm_Body.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_Body.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Body.TabIndex = 9
            Me.LabelForm_Body.Text = "Body:"
            '
            'LabelForm_Subject
            '
            Me.LabelForm_Subject.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Subject.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Subject.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_Subject.Name = "LabelForm_Subject"
            Me.LabelForm_Subject.Size = New System.Drawing.Size(75, 21)
            Me.LabelForm_Subject.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Subject.TabIndex = 7
            Me.LabelForm_Subject.Text = "Subject:"
            '
            'DataGridViewForm_VendorReps
            '
            Me.DataGridViewForm_VendorReps.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_VendorReps.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_VendorReps.AutoUpdateViewCaption = True
            Me.DataGridViewForm_VendorReps.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_VendorReps.ItemDescription = "Vendor Rep(s)"
            Me.DataGridViewForm_VendorReps.Location = New System.Drawing.Point(12, 204)
            Me.DataGridViewForm_VendorReps.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_VendorReps.ModifyGridRowHeight = False
            Me.DataGridViewForm_VendorReps.MultiSelect = True
            Me.DataGridViewForm_VendorReps.Name = "DataGridViewForm_VendorReps"
            Me.DataGridViewForm_VendorReps.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_VendorReps.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_VendorReps.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_VendorReps.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_VendorReps.Size = New System.Drawing.Size(981, 197)
            Me.DataGridViewForm_VendorReps.TabIndex = 12
            Me.DataGridViewForm_VendorReps.UseEmbeddedNavigator = False
            Me.DataGridViewForm_VendorReps.ViewCaptionHeight = -1
            '
            'LabelForm_Comment
            '
            Me.LabelForm_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Comment.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_Comment.Name = "LabelForm_Comment"
            Me.LabelForm_Comment.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Comment.TabIndex = 14
            Me.LabelForm_Comment.Text = "Comment:"
            '
            'TextBoxNewComment
            '
            Me.TextBoxNewComment.AcceptsReturn = True
            Me.TextBoxNewComment.AgencyImportPath = Nothing
            Me.TextBoxNewComment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxNewComment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxNewComment.Border.Class = "TextBoxBorder"
            Me.TextBoxNewComment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxNewComment.CheckSpellingOnValidate = False
            Me.TextBoxNewComment.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxNewComment.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxNewComment.DisplayName = ""
            Me.TextBoxNewComment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxNewComment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxNewComment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxNewComment.FocusHighlightEnabled = True
            Me.TextBoxNewComment.ForeColor = System.Drawing.Color.Black
            Me.TextBoxNewComment.Location = New System.Drawing.Point(93, 6)
            Me.TextBoxNewComment.MaxFileSize = CType(0, Long)
            Me.TextBoxNewComment.Multiline = True
            Me.TextBoxNewComment.Name = "TextBoxNewComment"
            Me.TextBoxNewComment.SecurityEnabled = True
            Me.TextBoxNewComment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxNewComment.Size = New System.Drawing.Size(900, 395)
            Me.TextBoxNewComment.StartingFolderName = Nothing
            Me.TextBoxNewComment.TabIndex = 15
            Me.TextBoxNewComment.TabOnEnter = False
            '
            'MediaTrafficProcessGenerateDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1015, 582)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaTrafficProcessGenerateDialog"
            Me.Text = "Process Generated Traffic Instructions"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Process As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_DefaultEmailSettings As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemDefaultEmailSettings_Save As DevComponents.DotNetBar.ButtonItem
        Private WithEvents CheckBoxForm_CCToSender As WinForm.MVC.Presentation.Controls.CheckBox
        Private WithEvents TextBoxForm_Subject As WinForm.MVC.Presentation.Controls.TextBox
        Private WithEvents TextBoxForm_Body As WinForm.MVC.Presentation.Controls.TextBox
        Private WithEvents LabelForm_Body As WinForm.MVC.Presentation.Controls.Label
        Private WithEvents LabelForm_Subject As WinForm.MVC.Presentation.Controls.Label
        Private WithEvents DataGridViewForm_VendorReps As WinForm.MVC.Presentation.Controls.DataGridView
        Private WithEvents LabelForm_Comment As WinForm.MVC.Presentation.Controls.Label
        Private WithEvents TextBoxNewComment As WinForm.MVC.Presentation.Controls.TextBox
    End Class

End Namespace