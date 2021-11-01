Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DocumentManagerSetupForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DocumentManagerSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_ProofHQ = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemProofHQ_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemProofHQ_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_CustomActions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemCustomActions_QuickDownload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Search = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxDocumentLevel_DocumentLevel = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.SearchableComboBoxOffice_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewOffice_Office = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.ItemContainerSearch_Search = New DevComponents.DotNetBar.ItemContainer()
            Me.ItemContainerSearch_DocumentLevel = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDocumentLevel_DocumentLevel = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDocumentLevel_DocumentLevel = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerSearch_Office = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemOffice_Office = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemOffice_Office = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ItemContainerSearch_DepartmentOrEmployee = New DevComponents.DotNetBar.ItemContainer()
            Me.LabelItemDepartmentOrEmployee_DepartmentOrEmployee = New DevComponents.DotNetBar.LabelItem()
            Me.ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemSearch_Search = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearch_Advanced = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ItemContainerSearch_SearchFilter = New DevComponents.DotNetBar.ItemContainer()
            Me.ButtonItemSearchFilter_All = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearchFilter_ItemsWithDocuments = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Upload = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemUpload_EmailLink = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Download = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_OpenURL = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Info = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_DocumentLevel = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DocumentManagerControlRightSection_DocumentManager = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_Search.SuspendLayout()
            CType(Me.SearchableComboBoxOffice_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewOffice_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_ProofHQ)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_CustomActions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Search)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 29)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(941, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_ProofHQ
            '
            Me.RibbonBarOptions_ProofHQ.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_ProofHQ.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ProofHQ.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ProofHQ.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_ProofHQ.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_ProofHQ.DragDropSupport = True
            Me.RibbonBarOptions_ProofHQ.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProofHQ_Upload, Me.ButtonItemProofHQ_Download})
            Me.RibbonBarOptions_ProofHQ.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_ProofHQ.Location = New System.Drawing.Point(942, 0)
            Me.RibbonBarOptions_ProofHQ.Name = "RibbonBarOptions_ProofHQ"
            Me.RibbonBarOptions_ProofHQ.SecurityEnabled = True
            Me.RibbonBarOptions_ProofHQ.Size = New System.Drawing.Size(106, 98)
            Me.RibbonBarOptions_ProofHQ.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_ProofHQ.TabIndex = 3
            Me.RibbonBarOptions_ProofHQ.Text = "Proof HQ"
            '
            '
            '
            Me.RibbonBarOptions_ProofHQ.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_ProofHQ.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_ProofHQ.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            Me.RibbonBarOptions_ProofHQ.Visible = False
            '
            'ButtonItemProofHQ_Upload
            '
            Me.ButtonItemProofHQ_Upload.BeginGroup = True
            Me.ButtonItemProofHQ_Upload.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemProofHQ_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProofHQ_Upload.Name = "ButtonItemProofHQ_Upload"
            Me.ButtonItemProofHQ_Upload.RibbonWordWrap = False
            Me.ButtonItemProofHQ_Upload.SecurityEnabled = True
            Me.ButtonItemProofHQ_Upload.Stretch = True
            Me.ButtonItemProofHQ_Upload.SubItemsExpandWidth = 14
            Me.ButtonItemProofHQ_Upload.Text = "Upload"
            '
            'ButtonItemProofHQ_Download
            '
            Me.ButtonItemProofHQ_Download.BeginGroup = True
            Me.ButtonItemProofHQ_Download.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemProofHQ_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProofHQ_Download.Name = "ButtonItemProofHQ_Download"
            Me.ButtonItemProofHQ_Download.RibbonWordWrap = False
            Me.ButtonItemProofHQ_Download.SecurityEnabled = True
            Me.ButtonItemProofHQ_Download.Stretch = True
            Me.ButtonItemProofHQ_Download.SubItemsExpandWidth = 14
            Me.ButtonItemProofHQ_Download.Text = "Download"
            '
            'RibbonBarOptions_CustomActions
            '
            Me.RibbonBarOptions_CustomActions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_CustomActions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CustomActions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CustomActions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_CustomActions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_CustomActions.DragDropSupport = True
            Me.RibbonBarOptions_CustomActions.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarOptions_CustomActions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments, Me.ButtonItemCustomActions_QuickDownload})
            Me.RibbonBarOptions_CustomActions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_CustomActions.Location = New System.Drawing.Point(796, 0)
            Me.RibbonBarOptions_CustomActions.MinimumSize = New System.Drawing.Size(94, 0)
            Me.RibbonBarOptions_CustomActions.Name = "RibbonBarOptions_CustomActions"
            Me.RibbonBarOptions_CustomActions.SecurityEnabled = True
            Me.RibbonBarOptions_CustomActions.Size = New System.Drawing.Size(146, 98)
            Me.RibbonBarOptions_CustomActions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_CustomActions.TabIndex = 2
            Me.RibbonBarOptions_CustomActions.Text = "Custom Actions"
            '
            '
            '
            Me.RibbonBarOptions_CustomActions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_CustomActions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_CustomActions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemCustomActions_QuickImportARInvoiceDocuments
            '
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.BeginGroup = True
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.Name = "ButtonItemCustomActions_QuickImportARInvoiceDocuments"
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.RibbonWordWrap = False
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.SecurityEnabled = True
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.Stretch = True
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.SubItemsExpandWidth = 14
            Me.ButtonItemCustomActions_QuickImportARInvoiceDocuments.Text = "Quick Import"
            '
            'ButtonItemCustomActions_QuickDownload
            '
            Me.ButtonItemCustomActions_QuickDownload.BeginGroup = True
            Me.ButtonItemCustomActions_QuickDownload.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemCustomActions_QuickDownload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemCustomActions_QuickDownload.Name = "ButtonItemCustomActions_QuickDownload"
            Me.ButtonItemCustomActions_QuickDownload.RibbonWordWrap = False
            Me.ButtonItemCustomActions_QuickDownload.SecurityEnabled = True
            Me.ButtonItemCustomActions_QuickDownload.Stretch = True
            Me.ButtonItemCustomActions_QuickDownload.SubItemsExpandWidth = 14
            Me.ButtonItemCustomActions_QuickDownload.Text = "Quick Download"
            '
            'RibbonBarOptions_Search
            '
            Me.RibbonBarOptions_Search.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Search.Controls.Add(Me.ComboBoxDocumentLevel_DocumentLevel)
            Me.RibbonBarOptions_Search.Controls.Add(Me.SearchableComboBoxOffice_Office)
            Me.RibbonBarOptions_Search.Controls.Add(Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee)
            Me.RibbonBarOptions_Search.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Search.DragDropSupport = True
            Me.RibbonBarOptions_Search.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_Search, Me.ButtonItemSearch_Search, Me.ButtonItemSearch_Advanced, Me.ItemContainerSearch_SearchFilter})
            Me.RibbonBarOptions_Search.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Search.Location = New System.Drawing.Point(285, 0)
            Me.RibbonBarOptions_Search.Name = "RibbonBarOptions_Search"
            Me.RibbonBarOptions_Search.SecurityEnabled = True
            Me.RibbonBarOptions_Search.Size = New System.Drawing.Size(511, 98)
            Me.RibbonBarOptions_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Search.TabIndex = 1
            Me.RibbonBarOptions_Search.Text = "Search"
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Search.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Search.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxDocumentLevel_DocumentLevel
            '
            Me.ComboBoxDocumentLevel_DocumentLevel.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxDocumentLevel_DocumentLevel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxDocumentLevel_DocumentLevel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxDocumentLevel_DocumentLevel.AutoFindItemInDataSource = False
            Me.ComboBoxDocumentLevel_DocumentLevel.AutoSelectSingleItemDatasource = False
            Me.ComboBoxDocumentLevel_DocumentLevel.BookmarkingEnabled = False
            Me.ComboBoxDocumentLevel_DocumentLevel.ClientCode = ""
            Me.ComboBoxDocumentLevel_DocumentLevel.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxDocumentLevel_DocumentLevel.DisableMouseWheel = False
            Me.ComboBoxDocumentLevel_DocumentLevel.DisplayMember = "Name"
            Me.ComboBoxDocumentLevel_DocumentLevel.DisplayName = ""
            Me.ComboBoxDocumentLevel_DocumentLevel.DivisionCode = ""
            Me.ComboBoxDocumentLevel_DocumentLevel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxDocumentLevel_DocumentLevel.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxDocumentLevel_DocumentLevel.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxDocumentLevel_DocumentLevel.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxDocumentLevel_DocumentLevel.FocusHighlightEnabled = True
            Me.ComboBoxDocumentLevel_DocumentLevel.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxDocumentLevel_DocumentLevel.FormattingEnabled = True
            Me.ComboBoxDocumentLevel_DocumentLevel.ItemHeight = 15
            Me.ComboBoxDocumentLevel_DocumentLevel.Location = New System.Drawing.Point(97, 9)
            Me.ComboBoxDocumentLevel_DocumentLevel.Name = "ComboBoxDocumentLevel_DocumentLevel"
            Me.ComboBoxDocumentLevel_DocumentLevel.ReadOnly = False
            Me.ComboBoxDocumentLevel_DocumentLevel.SecurityEnabled = True
            Me.ComboBoxDocumentLevel_DocumentLevel.Size = New System.Drawing.Size(150, 21)
            Me.ComboBoxDocumentLevel_DocumentLevel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxDocumentLevel_DocumentLevel.TabIndex = 2
            Me.ComboBoxDocumentLevel_DocumentLevel.TabOnEnter = True
            Me.ComboBoxDocumentLevel_DocumentLevel.ValueMember = "Value"
            Me.ComboBoxDocumentLevel_DocumentLevel.WatermarkText = "Select"
            '
            'SearchableComboBoxOffice_Office
            '
            Me.SearchableComboBoxOffice_Office.ActiveFilterString = ""
            Me.SearchableComboBoxOffice_Office.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxOffice_Office.AutoFillMode = False
            Me.SearchableComboBoxOffice_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxOffice_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxOffice_Office.DataSource = Nothing
            Me.SearchableComboBoxOffice_Office.DisableMouseWheel = False
            Me.SearchableComboBoxOffice_Office.DisplayName = ""
            Me.SearchableComboBoxOffice_Office.EnterMoveNextControl = True
            Me.SearchableComboBoxOffice_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.All
            Me.SearchableComboBoxOffice_Office.Location = New System.Drawing.Point(97, 32)
            Me.SearchableComboBoxOffice_Office.Name = "SearchableComboBoxOffice_Office"
            Me.SearchableComboBoxOffice_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxOffice_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxOffice_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxOffice_Office.Properties.PopupView = Me.SearchableComboBoxViewOffice_Office
            Me.SearchableComboBoxOffice_Office.Properties.ShowClearButton = False
            Me.SearchableComboBoxOffice_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxOffice_Office.SecurityEnabled = True
            Me.SearchableComboBoxOffice_Office.SelectedValue = Nothing
            Me.SearchableComboBoxOffice_Office.Size = New System.Drawing.Size(150, 20)
            Me.SearchableComboBoxOffice_Office.TabIndex = 7
            '
            'SearchableComboBoxViewOffice_Office
            '
            Me.SearchableComboBoxViewOffice_Office.AFActiveFilterString = ""
            Me.SearchableComboBoxViewOffice_Office.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewOffice_Office.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewOffice_Office.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewOffice_Office.DataSourceClearing = False
            Me.SearchableComboBoxViewOffice_Office.EnableDisabledRows = False
            Me.SearchableComboBoxViewOffice_Office.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewOffice_Office.Name = "SearchableComboBoxViewOffice_Office"
            Me.SearchableComboBoxViewOffice_Office.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewOffice_Office.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewOffice_Office.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewOffice_Office.RunStandardValidation = True
            Me.SearchableComboBoxViewOffice_Office.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewOffice_Office.SkipSettingFontOnModifyColumn = False
            '
            'SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee
            '
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.ActiveFilterString = ""
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.AutoFillMode = False
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.BookmarkingEnabled = False
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.DepartmentTeam
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.DataSource = Nothing
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.DisableMouseWheel = False
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.DisplayName = ""
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.EnterMoveNextControl = True
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.All
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Location = New System.Drawing.Point(97, 55)
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Name = "SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee"
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Properties.NullText = "Select Department / Team"
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Properties.PopupView = Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Properties.ShowClearButton = False
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Properties.ValueMember = "Code"
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.SecurityEnabled = True
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.SelectedValue = Nothing
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Size = New System.Drawing.Size(150, 20)
            Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.TabIndex = 8
            '
            'SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee
            '
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.AFActiveFilterString = ""
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.DataSourceClearing = False
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.EnableDisabledRows = False
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.Name = "SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee"
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.RunStandardValidation = True
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee.SkipSettingFontOnModifyColumn = False
            '
            'ItemContainerSearch_Search
            '
            '
            '
            '
            Me.ItemContainerSearch_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Search.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_Search.Name = "ItemContainerSearch_Search"
            Me.ItemContainerSearch_Search.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerSearch_DocumentLevel, Me.ItemContainerSearch_Office, Me.ItemContainerSearch_DepartmentOrEmployee})
            '
            '
            '
            Me.ItemContainerSearch_Search.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_Search.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ItemContainerSearch_DocumentLevel
            '
            '
            '
            '
            Me.ItemContainerSearch_DocumentLevel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_DocumentLevel.Name = "ItemContainerSearch_DocumentLevel"
            Me.ItemContainerSearch_DocumentLevel.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDocumentLevel_DocumentLevel, Me.ControlContainerItemDocumentLevel_DocumentLevel})
            '
            '
            '
            Me.ItemContainerSearch_DocumentLevel.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_DocumentLevel.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'LabelItemDocumentLevel_DocumentLevel
            '
            Me.LabelItemDocumentLevel_DocumentLevel.Height = 20
            Me.LabelItemDocumentLevel_DocumentLevel.Name = "LabelItemDocumentLevel_DocumentLevel"
            Me.LabelItemDocumentLevel_DocumentLevel.Text = "Document Level:"
            Me.LabelItemDocumentLevel_DocumentLevel.Width = 90
            '
            'ControlContainerItemDocumentLevel_DocumentLevel
            '
            Me.ControlContainerItemDocumentLevel_DocumentLevel.AllowItemResize = True
            Me.ControlContainerItemDocumentLevel_DocumentLevel.Control = Me.ComboBoxDocumentLevel_DocumentLevel
            Me.ControlContainerItemDocumentLevel_DocumentLevel.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDocumentLevel_DocumentLevel.Name = "ControlContainerItemDocumentLevel_DocumentLevel"
            Me.ControlContainerItemDocumentLevel_DocumentLevel.Text = "ControlContainerItem1"
            '
            'ItemContainerSearch_Office
            '
            '
            '
            '
            Me.ItemContainerSearch_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Office.Name = "ItemContainerSearch_Office"
            Me.ItemContainerSearch_Office.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemOffice_Office, Me.ControlContainerItemOffice_Office})
            '
            '
            '
            Me.ItemContainerSearch_Office.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_Office.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_Office.Visible = False
            '
            'LabelItemOffice_Office
            '
            Me.LabelItemOffice_Office.Height = 20
            Me.LabelItemOffice_Office.Name = "LabelItemOffice_Office"
            Me.LabelItemOffice_Office.Text = "Office:"
            Me.LabelItemOffice_Office.Width = 90
            '
            'ControlContainerItemOffice_Office
            '
            Me.ControlContainerItemOffice_Office.AllowItemResize = True
            Me.ControlContainerItemOffice_Office.Control = Me.SearchableComboBoxOffice_Office
            Me.ControlContainerItemOffice_Office.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemOffice_Office.Name = "ControlContainerItemOffice_Office"
            Me.ControlContainerItemOffice_Office.Text = "ControlContainerItem1"
            '
            'ItemContainerSearch_DepartmentOrEmployee
            '
            '
            '
            '
            Me.ItemContainerSearch_DepartmentOrEmployee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_DepartmentOrEmployee.Name = "ItemContainerSearch_DepartmentOrEmployee"
            Me.ItemContainerSearch_DepartmentOrEmployee.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItemDepartmentOrEmployee_DepartmentOrEmployee, Me.ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee})
            '
            '
            '
            Me.ItemContainerSearch_DepartmentOrEmployee.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_DepartmentOrEmployee.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_DepartmentOrEmployee.Visible = False
            '
            'LabelItemDepartmentOrEmployee_DepartmentOrEmployee
            '
            Me.LabelItemDepartmentOrEmployee_DepartmentOrEmployee.Height = 20
            Me.LabelItemDepartmentOrEmployee_DepartmentOrEmployee.Name = "LabelItemDepartmentOrEmployee_DepartmentOrEmployee"
            Me.LabelItemDepartmentOrEmployee_DepartmentOrEmployee.Text = "Department:"
            Me.LabelItemDepartmentOrEmployee_DepartmentOrEmployee.Width = 90
            '
            'ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee
            '
            Me.ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.AllowItemResize = True
            Me.ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Control = Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee
            Me.ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Name = "ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee"
            Me.ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee.Text = "ControlContainerItem2"
            '
            'ButtonItemSearch_Search
            '
            Me.ButtonItemSearch_Search.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Search.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Search.Name = "ButtonItemSearch_Search"
            Me.ButtonItemSearch_Search.RibbonWordWrap = False
            Me.ButtonItemSearch_Search.SecurityEnabled = True
            Me.ButtonItemSearch_Search.Stretch = True
            Me.ButtonItemSearch_Search.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Search.Text = "Search"
            '
            'ButtonItemSearch_Advanced
            '
            Me.ButtonItemSearch_Advanced.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearch_Advanced.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSearch_Advanced.Name = "ButtonItemSearch_Advanced"
            Me.ButtonItemSearch_Advanced.RibbonWordWrap = False
            Me.ButtonItemSearch_Advanced.SecurityEnabled = True
            Me.ButtonItemSearch_Advanced.Stretch = True
            Me.ButtonItemSearch_Advanced.SubItemsExpandWidth = 14
            Me.ButtonItemSearch_Advanced.Text = "Advanced"
            '
            'ItemContainerSearch_SearchFilter
            '
            '
            '
            '
            Me.ItemContainerSearch_SearchFilter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerSearch_SearchFilter.BeginGroup = True
            Me.ItemContainerSearch_SearchFilter.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.ItemContainerSearch_SearchFilter.Name = "ItemContainerSearch_SearchFilter"
            Me.ItemContainerSearch_SearchFilter.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSearchFilter_All, Me.ButtonItemSearchFilter_ItemsWithDocuments, Me.ButtonItemSearchFilter_ItemsWithoutDocuments})
            '
            '
            '
            Me.ItemContainerSearch_SearchFilter.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.ItemContainerSearch_SearchFilter.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSearchFilter_All
            '
            Me.ButtonItemSearchFilter_All.AutoCheckOnClick = True
            Me.ButtonItemSearchFilter_All.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearchFilter_All.Checked = True
            Me.ButtonItemSearchFilter_All.Name = "ButtonItemSearchFilter_All"
            Me.ButtonItemSearchFilter_All.OptionGroup = "SearchFilter"
            Me.ButtonItemSearchFilter_All.RibbonWordWrap = False
            Me.ButtonItemSearchFilter_All.SecurityEnabled = True
            Me.ButtonItemSearchFilter_All.Stretch = True
            Me.ButtonItemSearchFilter_All.Text = "All"
            '
            'ButtonItemSearchFilter_ItemsWithDocuments
            '
            Me.ButtonItemSearchFilter_ItemsWithDocuments.AutoCheckOnClick = True
            Me.ButtonItemSearchFilter_ItemsWithDocuments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearchFilter_ItemsWithDocuments.Name = "ButtonItemSearchFilter_ItemsWithDocuments"
            Me.ButtonItemSearchFilter_ItemsWithDocuments.OptionGroup = "SearchFilter"
            Me.ButtonItemSearchFilter_ItemsWithDocuments.RibbonWordWrap = False
            Me.ButtonItemSearchFilter_ItemsWithDocuments.SecurityEnabled = True
            Me.ButtonItemSearchFilter_ItemsWithDocuments.Stretch = True
            Me.ButtonItemSearchFilter_ItemsWithDocuments.Text = "Items With Documents"
            '
            'ButtonItemSearchFilter_ItemsWithoutDocuments
            '
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments.AutoCheckOnClick = True
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments.Name = "ButtonItemSearchFilter_ItemsWithoutDocuments"
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments.OptionGroup = "SearchFilter"
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments.RibbonWordWrap = False
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments.SecurityEnabled = True
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments.Stretch = True
            Me.ButtonItemSearchFilter_ItemsWithoutDocuments.Text = "Items Without Documents"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Upload, Me.ButtonItemActions_Download, Me.ButtonItemActions_OpenURL, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Info, Me.ButtonItemActions_Export})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(285, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
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
            'ButtonItemActions_Upload
            '
            Me.ButtonItemActions_Upload.BeginGroup = True
            Me.ButtonItemActions_Upload.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Upload.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Upload.Name = "ButtonItemActions_Upload"
            Me.ButtonItemActions_Upload.RibbonWordWrap = False
            Me.ButtonItemActions_Upload.SecurityEnabled = True
            Me.ButtonItemActions_Upload.SplitButton = True
            Me.ButtonItemActions_Upload.Stretch = True
            Me.ButtonItemActions_Upload.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemUpload_EmailLink})
            Me.ButtonItemActions_Upload.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Upload.Text = "Upload"
            '
            'ButtonItemUpload_EmailLink
            '
            Me.ButtonItemUpload_EmailLink.Name = "ButtonItemUpload_EmailLink"
            Me.ButtonItemUpload_EmailLink.Text = "Email Link"
            '
            'ButtonItemActions_Download
            '
            Me.ButtonItemActions_Download.BeginGroup = True
            Me.ButtonItemActions_Download.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Download.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Download.Name = "ButtonItemActions_Download"
            Me.ButtonItemActions_Download.RibbonWordWrap = False
            Me.ButtonItemActions_Download.SecurityEnabled = True
            Me.ButtonItemActions_Download.Stretch = True
            Me.ButtonItemActions_Download.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Download.Text = "Download"
            '
            'ButtonItemActions_OpenURL
            '
            Me.ButtonItemActions_OpenURL.BeginGroup = True
            Me.ButtonItemActions_OpenURL.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_OpenURL.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_OpenURL.Name = "ButtonItemActions_OpenURL"
            Me.ButtonItemActions_OpenURL.RibbonWordWrap = False
            Me.ButtonItemActions_OpenURL.SecurityEnabled = True
            Me.ButtonItemActions_OpenURL.Stretch = True
            Me.ButtonItemActions_OpenURL.SubItemsExpandWidth = 14
            Me.ButtonItemActions_OpenURL.Text = "Open URL"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Info
            '
            Me.ButtonItemActions_Info.BeginGroup = True
            Me.ButtonItemActions_Info.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Info.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Info.Name = "ButtonItemActions_Info"
            Me.ButtonItemActions_Info.RibbonWordWrap = False
            Me.ButtonItemActions_Info.SecurityEnabled = True
            Me.ButtonItemActions_Info.Stretch = True
            Me.ButtonItemActions_Info.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Info.Text = "Info"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_DocumentLevel)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(200, 421)
            Me.PanelForm_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_DocumentLevel
            '
            Me.DataGridViewLeftSection_DocumentLevel.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_DocumentLevel.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_DocumentLevel.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_DocumentLevel.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_DocumentLevel.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_DocumentLevel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_DocumentLevel.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_DocumentLevel.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_DocumentLevel.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_DocumentLevel.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewLeftSection_DocumentLevel.DataSource = Nothing
            Me.DataGridViewLeftSection_DocumentLevel.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_DocumentLevel.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_DocumentLevel.ItemDescription = ""
            Me.DataGridViewLeftSection_DocumentLevel.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_DocumentLevel.MultiSelect = True
            Me.DataGridViewLeftSection_DocumentLevel.Name = "DataGridViewLeftSection_DocumentLevel"
            Me.DataGridViewLeftSection_DocumentLevel.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_DocumentLevel.RunStandardValidation = True
            Me.DataGridViewLeftSection_DocumentLevel.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_DocumentLevel.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_DocumentLevel.Size = New System.Drawing.Size(182, 397)
            Me.DataGridViewLeftSection_DocumentLevel.TabIndex = 0
            Me.DataGridViewLeftSection_DocumentLevel.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_DocumentLevel.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(200, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 421)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 5
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.DocumentManagerControlRightSection_DocumentManager)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(206, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(740, 421)
            Me.PanelForm_RightSection.TabIndex = 6
            '
            'DocumentManagerControlRightSection_DocumentManager
            '
            Me.DocumentManagerControlRightSection_DocumentManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlRightSection_DocumentManager.Location = New System.Drawing.Point(6, 12)
            Me.DocumentManagerControlRightSection_DocumentManager.Name = "DocumentManagerControlRightSection_DocumentManager"
            Me.DocumentManagerControlRightSection_DocumentManager.Size = New System.Drawing.Size(722, 397)
            Me.DocumentManagerControlRightSection_DocumentManager.TabIndex = 0
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'DocumentManagerSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(946, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DocumentManagerSetupForm"
            Me.Text = "Document Manager"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_Search.ResumeLayout(False)
            CType(Me.SearchableComboBoxOffice_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewOffice_Office, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Search As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ItemContainerSearch_Search As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSearch_Search As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_DocumentLevel As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DocumentManagerControlRightSection_DocumentManager As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents ItemContainerSearch_DocumentLevel As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemActions_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearch_Advanced As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_OpenURL As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Info As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelItemDocumentLevel_DocumentLevel As DevComponents.DotNetBar.LabelItem
        Friend WithEvents RibbonBarOptions_CustomActions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemCustomActions_QuickImportARInvoiceDocuments As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearchFilter_ItemsWithDocuments As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerSearch_SearchFilter As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ButtonItemSearchFilter_All As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemSearchFilter_ItemsWithoutDocuments As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_ProofHQ As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        'Friend WithEvents ButtonItemActions_Export As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProofHQ_Upload As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemProofHQ_Download As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemCustomActions_QuickDownload As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ItemContainerSearch_Office As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemOffice_Office As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemOffice_Office As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ItemContainerSearch_DepartmentOrEmployee As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents LabelItemDepartmentOrEmployee_DepartmentOrEmployee As DevComponents.DotNetBar.LabelItem
        Friend WithEvents ControlContainerItemDepartmentOrEmployee_DepartmentOrEmployee As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents SearchableComboBoxOffice_Office As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewOffice_Office As WinForm.Presentation.Controls.GridView
        Friend WithEvents ControlContainerItemDocumentLevel_DocumentLevel As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ComboBoxDocumentLevel_DocumentLevel As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents SearchableComboBoxDepartmentOrEmployee_DepartmentOrEmployee As WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewDepartmentOrEmployee_DepartmentOrEmployee As WinForm.Presentation.Controls.GridView
        Friend WithEvents ButtonItemUpload_EmailLink As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace