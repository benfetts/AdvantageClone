Namespace ProjectManagement.Reports.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class EstimatePrintingPrintDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EstimatePrintingPrintDialog))
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Process = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_ExportPath = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_ExportPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.RibbonBarOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.CheckBoxItemInclude_APDocuments = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItemInclude_ExpenseDocuments = New DevComponents.DotNetBar.CheckBoxItem()
            Me.RibbonBarOptions_Options = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemOptions_SendToDocumentManager = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOptions_IncludeCoverSheet = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_PackageOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPackageOptions_OneZipPerInvoice = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPackageOptions_OneZip = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(710, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_PackageOptions)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Include)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Options)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 54)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(710, 100)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Options, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Include, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_PackageOptions, 0)
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
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 98)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Visible = False
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.TextBoxForm_ExportPath)
            Me.PanelForm_Form.Controls.Add(Me.LabelForm_ExportPath)
            Me.PanelForm_Form.Size = New System.Drawing.Size(710, 100)
            Me.PanelForm_Form.TabIndex = 0
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 255)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(710, 18)
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
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(115, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 17
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
            'LabelForm_ExportPath
            '
            Me.LabelForm_ExportPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ExportPath.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ExportPath.Location = New System.Drawing.Point(12, 6)
            Me.LabelForm_ExportPath.Name = "LabelForm_ExportPath"
            Me.LabelForm_ExportPath.Size = New System.Drawing.Size(105, 20)
            Me.LabelForm_ExportPath.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ExportPath.TabIndex = 0
            Me.LabelForm_ExportPath.Text = "Export Path:"
            '
            'TextBoxForm_ExportPath
            '
            Me.TextBoxForm_ExportPath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_ExportPath.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_ExportPath.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_ExportPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_ExportPath.ButtonCustom.Visible = True
            Me.TextBoxForm_ExportPath.CheckSpellingOnValidate = False
            Me.TextBoxForm_ExportPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxForm_ExportPath.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_ExportPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_ExportPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_ExportPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_ExportPath.FocusHighlightEnabled = True
            Me.TextBoxForm_ExportPath.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_ExportPath.Location = New System.Drawing.Point(123, 6)
            Me.TextBoxForm_ExportPath.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_ExportPath.Name = "TextBoxForm_ExportPath"
            Me.TextBoxForm_ExportPath.SecurityEnabled = True
            Me.TextBoxForm_ExportPath.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_ExportPath.Size = New System.Drawing.Size(575, 21)
            Me.TextBoxForm_ExportPath.StartingFolderName = Nothing
            Me.TextBoxForm_ExportPath.TabIndex = 1
            Me.TextBoxForm_ExportPath.TabOnEnter = True
            '
            'RibbonBarOptions_Include
            '
            Me.RibbonBarOptions_Include.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Include.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Include.DragDropSupport = True
            Me.RibbonBarOptions_Include.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.CheckBoxItemInclude_APDocuments, Me.CheckBoxItemInclude_ExpenseDocuments})
            Me.RibbonBarOptions_Include.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Include.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Include.Location = New System.Drawing.Point(448, 0)
            Me.RibbonBarOptions_Include.Name = "RibbonBarOptions_Include"
            Me.RibbonBarOptions_Include.SecurityEnabled = True
            Me.RibbonBarOptions_Include.Size = New System.Drawing.Size(137, 98)
            Me.RibbonBarOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Include.TabIndex = 32
            Me.RibbonBarOptions_Include.Text = "Include"
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Include.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Include.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Include.Visible = False
            '
            'CheckBoxItemInclude_APDocuments
            '
            Me.CheckBoxItemInclude_APDocuments.Name = "CheckBoxItemInclude_APDocuments"
            Me.CheckBoxItemInclude_APDocuments.Text = "AP Documents"
            '
            'CheckBoxItemInclude_ExpenseDocuments
            '
            Me.CheckBoxItemInclude_ExpenseDocuments.Name = "CheckBoxItemInclude_ExpenseDocuments"
            Me.CheckBoxItemInclude_ExpenseDocuments.Text = "Expense Documents"
            '
            'RibbonBarOptions_Options
            '
            Me.RibbonBarOptions_Options.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Options.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Options.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Options.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Options.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Options.DragDropSupport = True
            Me.RibbonBarOptions_Options.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_Options.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOptions_SendToDocumentManager, Me.ButtonItemOptions_IncludeCoverSheet})
            Me.RibbonBarOptions_Options.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Options.Location = New System.Drawing.Point(218, 0)
            Me.RibbonBarOptions_Options.MinimumSize = New System.Drawing.Size(133, 0)
            Me.RibbonBarOptions_Options.Name = "RibbonBarOptions_Options"
            Me.RibbonBarOptions_Options.SecurityEnabled = True
            Me.RibbonBarOptions_Options.Size = New System.Drawing.Size(230, 98)
            Me.RibbonBarOptions_Options.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Options.TabIndex = 33
            Me.RibbonBarOptions_Options.Text = "Options"
            '
            '
            '
            Me.RibbonBarOptions_Options.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Options.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Options.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            Me.RibbonBarOptions_Options.Visible = False
            '
            'ButtonItemOptions_SendToDocumentManager
            '
            Me.ButtonItemOptions_SendToDocumentManager.AutoCheckOnClick = True
            Me.ButtonItemOptions_SendToDocumentManager.BeginGroup = True
            Me.ButtonItemOptions_SendToDocumentManager.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_SendToDocumentManager.Name = "ButtonItemOptions_SendToDocumentManager"
            Me.ButtonItemOptions_SendToDocumentManager.RibbonWordWrap = False
            Me.ButtonItemOptions_SendToDocumentManager.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_SendToDocumentManager.Text = "<span width=""25""></span>Send To <br></br>Document Manager"
            '
            'ButtonItemOptions_IncludeCoverSheet
            '
            Me.ButtonItemOptions_IncludeCoverSheet.AutoCheckOnClick = True
            Me.ButtonItemOptions_IncludeCoverSheet.BeginGroup = True
            Me.ButtonItemOptions_IncludeCoverSheet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemOptions_IncludeCoverSheet.Name = "ButtonItemOptions_IncludeCoverSheet"
            Me.ButtonItemOptions_IncludeCoverSheet.RibbonWordWrap = False
            Me.ButtonItemOptions_IncludeCoverSheet.SubItemsExpandWidth = 14
            Me.ButtonItemOptions_IncludeCoverSheet.Text = "<span width=""12""></span>Include <br></br>Cover Sheet"
            '
            'RibbonBarOptions_PackageOptions
            '
            Me.RibbonBarOptions_PackageOptions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PackageOptions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_PackageOptions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_PackageOptions.DragDropSupport = True
            Me.RibbonBarOptions_PackageOptions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemPackageOptions_OneZipPerInvoice, Me.ButtonItemPackageOptions_OneZip})
            Me.RibbonBarOptions_PackageOptions.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_PackageOptions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_PackageOptions.Location = New System.Drawing.Point(585, 0)
            Me.RibbonBarOptions_PackageOptions.Name = "RibbonBarOptions_PackageOptions"
            Me.RibbonBarOptions_PackageOptions.SecurityEnabled = True
            Me.RibbonBarOptions_PackageOptions.Size = New System.Drawing.Size(115, 98)
            Me.RibbonBarOptions_PackageOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PackageOptions.TabIndex = 34
            Me.RibbonBarOptions_PackageOptions.Text = "Package Options"
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_PackageOptions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_PackageOptions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            Me.RibbonBarOptions_PackageOptions.Visible = False
            '
            'ButtonItemPackageOptions_OneZipPerInvoice
            '
            Me.ButtonItemPackageOptions_OneZipPerInvoice.AutoCheckOnClick = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.BeginGroup = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemPackageOptions_OneZipPerInvoice.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Name = "ButtonItemPackageOptions_OneZipPerInvoice"
            Me.ButtonItemPackageOptions_OneZipPerInvoice.RibbonWordWrap = False
            Me.ButtonItemPackageOptions_OneZipPerInvoice.SecurityEnabled = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Stretch = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.SubItemsExpandWidth = 14
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Text = "One Zip Per Invoice"
            '
            'ButtonItemPackageOptions_OneZip
            '
            Me.ButtonItemPackageOptions_OneZip.AutoCheckOnClick = True
            Me.ButtonItemPackageOptions_OneZip.BeginGroup = True
            Me.ButtonItemPackageOptions_OneZip.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemPackageOptions_OneZip.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPackageOptions_OneZip.Name = "ButtonItemPackageOptions_OneZip"
            Me.ButtonItemPackageOptions_OneZip.RibbonWordWrap = False
            Me.ButtonItemPackageOptions_OneZip.SecurityEnabled = True
            Me.ButtonItemPackageOptions_OneZip.Stretch = True
            Me.ButtonItemPackageOptions_OneZip.SubItemsExpandWidth = 14
            Me.ButtonItemPackageOptions_OneZip.Text = "One Zip"
            '
            'EstimatePrintingPrintDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(720, 275)
            Me.CloseButtonVisible = False
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EstimatePrintingPrintDialog"
            Me.Text = "Printing"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Process As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TextBoxForm_ExportPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_ExportPath As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarOptions_Include As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents CheckBoxItemInclude_APDocuments As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItemInclude_ExpenseDocuments As DevComponents.DotNetBar.CheckBoxItem
        Private WithEvents RibbonBarOptions_Options As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemOptions_SendToDocumentManager As DevComponents.DotNetBar.ButtonItem
        Private WithEvents ButtonItemOptions_IncludeCoverSheet As DevComponents.DotNetBar.ButtonItem
        Private WithEvents RibbonBarOptions_PackageOptions As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemPackageOptions_OneZipPerInvoice As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemPackageOptions_OneZip As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

