Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class DocumentPrintDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentPrintDialog))
            Me.DataGridViewForm_Documents = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Package = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_PackageOptions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemPackageOptions_OneZipPerInvoice = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemPackageOptions_OneZip = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Include = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.CheckBoxItemInclude_APDocuments = New DevComponents.DotNetBar.CheckBoxItem()
            Me.CheckBoxItemInclude_ExpenseDocuments = New DevComponents.DotNetBar.CheckBoxItem()
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
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(932, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(932, 95)
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
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Documents)
            Me.PanelForm_Form.Size = New System.Drawing.Size(932, 391)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 546)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(932, 18)
            '
            'DataGridViewForm_Documents
            '
            Me.DataGridViewForm_Documents.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Documents.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Documents.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Documents.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Documents.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Documents.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Documents.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Documents.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Documents.Dock = System.Windows.Forms.DockStyle.Fill
            Me.DataGridViewForm_Documents.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Documents.ItemDescription = "Document(s)"
            Me.DataGridViewForm_Documents.Location = New System.Drawing.Point(0, 0)
            Me.DataGridViewForm_Documents.MultiSelect = True
            Me.DataGridViewForm_Documents.Name = "DataGridViewForm_Documents"
            Me.DataGridViewForm_Documents.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Documents.RunStandardValidation = True
            Me.DataGridViewForm_Documents.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_Documents.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Documents.Size = New System.Drawing.Size(932, 391)
            Me.DataGridViewForm_Documents.TabIndex = 12
            Me.DataGridViewForm_Documents.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Documents.ViewCaptionHeight = -1
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Package})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(95, 92)
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
            'ButtonItemActions_Package
            '
            Me.ButtonItemActions_Package.BeginGroup = True
            Me.ButtonItemActions_Package.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Package.Name = "ButtonItemActions_Package"
            Me.ButtonItemActions_Package.RibbonWordWrap = False
            Me.ButtonItemActions_Package.SecurityEnabled = True
            Me.ButtonItemActions_Package.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Package.Text = "Package"
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
            Me.RibbonBarOptions_PackageOptions.Location = New System.Drawing.Point(335, 0)
            Me.RibbonBarOptions_PackageOptions.Name = "RibbonBarOptions_PackageOptions"
            Me.RibbonBarOptions_PackageOptions.SecurityEnabled = True
            Me.RibbonBarOptions_PackageOptions.Size = New System.Drawing.Size(139, 92)
            Me.RibbonBarOptions_PackageOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_PackageOptions.TabIndex = 24
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
            '
            'ButtonItemPackageOptions_OneZipPerInvoice
            '
            Me.ButtonItemPackageOptions_OneZipPerInvoice.BeginGroup = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemPackageOptions_OneZipPerInvoice.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Name = "ButtonItemPackageOptions_OneZipPerInvoice"
            Me.ButtonItemPackageOptions_OneZipPerInvoice.OptionGroup = "ZeroInvoices"
            Me.ButtonItemPackageOptions_OneZipPerInvoice.RibbonWordWrap = False
            Me.ButtonItemPackageOptions_OneZipPerInvoice.SecurityEnabled = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Stretch = True
            Me.ButtonItemPackageOptions_OneZipPerInvoice.SubItemsExpandWidth = 14
            Me.ButtonItemPackageOptions_OneZipPerInvoice.Text = "One Zip Per Invoice"
            '
            'ButtonItemPackageOptions_OneZip
            '
            Me.ButtonItemPackageOptions_OneZip.BeginGroup = True
            Me.ButtonItemPackageOptions_OneZip.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.TextOnlyAlways
            Me.ButtonItemPackageOptions_OneZip.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemPackageOptions_OneZip.Name = "ButtonItemPackageOptions_OneZip"
            Me.ButtonItemPackageOptions_OneZip.OptionGroup = "ZeroInvoices"
            Me.ButtonItemPackageOptions_OneZip.RibbonWordWrap = False
            Me.ButtonItemPackageOptions_OneZip.SecurityEnabled = True
            Me.ButtonItemPackageOptions_OneZip.Stretch = True
            Me.ButtonItemPackageOptions_OneZip.SubItemsExpandWidth = 14
            Me.ButtonItemPackageOptions_OneZip.Text = "One Zip"
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
            Me.RibbonBarOptions_Include.Location = New System.Drawing.Point(198, 0)
            Me.RibbonBarOptions_Include.Name = "RibbonBarOptions_Include"
            Me.RibbonBarOptions_Include.SecurityEnabled = True
            Me.RibbonBarOptions_Include.Size = New System.Drawing.Size(137, 92)
            Me.RibbonBarOptions_Include.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Include.TabIndex = 25
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
            'DocumentPrintDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(942, 566)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DocumentPrintDialog"
            Me.Text = "Document Print Dialog"
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
        Friend WithEvents DataGridViewForm_Documents As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Package As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents RibbonBarOptions_PackageOptions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemPackageOptions_OneZipPerInvoice As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemPackageOptions_OneZip As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Include As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents CheckBoxItemInclude_APDocuments As DevComponents.DotNetBar.CheckBoxItem
        Friend WithEvents CheckBoxItemInclude_ExpenseDocuments As DevComponents.DotNetBar.CheckBoxItem
    End Class

End Namespace

