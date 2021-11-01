Namespace GeneralLedger.Maintenance.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GeneralLedgerMappingSetupForm
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GeneralLedgerMappingSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ComboBoxRecordSource_RecordSource = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ItemContainerRecordSource_RecordSource = New DevComponents.DotNetBar.ItemContainer()
            Me.ControlContainerItemRecordSource_RecordSource = New DevComponents.DotNetBar.ControlContainerItem()
            Me.ButtonItemRecordSource_Manage = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_GLMapping = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.RibbonBarOptions_RecordSource.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_RecordSource)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(98, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(540, 98)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(272, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(185, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 7
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.Enabled = False
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_RecordSource
            '
            Me.RibbonBarOptions_RecordSource.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_RecordSource.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RecordSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RecordSource.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_RecordSource.Controls.Add(Me.ComboBoxRecordSource_RecordSource)
            Me.RibbonBarOptions_RecordSource.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_RecordSource.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainerRecordSource_RecordSource, Me.ButtonItemRecordSource_Manage})
            Me.RibbonBarOptions_RecordSource.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_RecordSource.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_RecordSource.Name = "RibbonBarOptions_RecordSource"
            Me.RibbonBarOptions_RecordSource.Size = New System.Drawing.Size(272, 98)
            Me.RibbonBarOptions_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_RecordSource.TabIndex = 6
            Me.RibbonBarOptions_RecordSource.Text = "Record Source"
            '
            '
            '
            Me.RibbonBarOptions_RecordSource.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_RecordSource.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_RecordSource.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ComboBoxRecordSource_RecordSource
            '
            Me.ComboBoxRecordSource_RecordSource.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxRecordSource_RecordSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxRecordSource_RecordSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxRecordSource_RecordSource.AutoFindItemInDataSource = False
            Me.ComboBoxRecordSource_RecordSource.AutoSelectSingleItemDatasource = False
            Me.ComboBoxRecordSource_RecordSource.BookmarkingEnabled = False
            Me.ComboBoxRecordSource_RecordSource.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.RecordSource
            Me.ComboBoxRecordSource_RecordSource.DisableMouseWheel = False
            Me.ComboBoxRecordSource_RecordSource.DisplayMember = "Name"
            Me.ComboBoxRecordSource_RecordSource.DisplayName = ""
            Me.ComboBoxRecordSource_RecordSource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxRecordSource_RecordSource.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxRecordSource_RecordSource.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxRecordSource_RecordSource.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxRecordSource_RecordSource.FocusHighlightEnabled = True
            Me.ComboBoxRecordSource_RecordSource.FormattingEnabled = True
            Me.ComboBoxRecordSource_RecordSource.ItemHeight = 14
            Me.ComboBoxRecordSource_RecordSource.Location = New System.Drawing.Point(6, 53)
            Me.ComboBoxRecordSource_RecordSource.Name = "ComboBoxRecordSource_RecordSource"
            Me.ComboBoxRecordSource_RecordSource.PreventEnterBeep = False
            Me.ComboBoxRecordSource_RecordSource.ReadOnly = False
            Me.ComboBoxRecordSource_RecordSource.SecurityEnabled = True
            Me.ComboBoxRecordSource_RecordSource.Size = New System.Drawing.Size(200, 20)
            Me.ComboBoxRecordSource_RecordSource.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxRecordSource_RecordSource.TabIndex = 70
            Me.ComboBoxRecordSource_RecordSource.ValueMember = "ID"
            Me.ComboBoxRecordSource_RecordSource.WatermarkText = "Select Record Source"
            '
            'ItemContainerRecordSource_RecordSource
            '
            '
            '
            '
            Me.ItemContainerRecordSource_RecordSource.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRecordSource_RecordSource.Name = "ItemContainerRecordSource_RecordSource"
            Me.ItemContainerRecordSource_RecordSource.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItemRecordSource_RecordSource})
            '
            '
            '
            Me.ItemContainerRecordSource_RecordSource.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ItemContainerRecordSource_RecordSource.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ControlContainerItemRecordSource_RecordSource
            '
            Me.ControlContainerItemRecordSource_RecordSource.AllowItemResize = True
            Me.ControlContainerItemRecordSource_RecordSource.Control = Me.ComboBoxRecordSource_RecordSource
            Me.ControlContainerItemRecordSource_RecordSource.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ControlContainerItemRecordSource_RecordSource.Name = "ControlContainerItemRecordSource_RecordSource"
            Me.ControlContainerItemRecordSource_RecordSource.Text = "ControlContainerItem2"
            '
            'ButtonItemRecordSource_Manage
            '
            Me.ButtonItemRecordSource_Manage.BeginGroup = True
            Me.ButtonItemRecordSource_Manage.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemRecordSource_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemRecordSource_Manage.Name = "ButtonItemRecordSource_Manage"
            Me.ButtonItemRecordSource_Manage.RibbonWordWrap = False
            Me.ButtonItemRecordSource_Manage.Stretch = True
            Me.ButtonItemRecordSource_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemRecordSource_Manage.Text = "Manage"
            '
            'DataGridViewForm_GLMapping
            '
            Me.DataGridViewForm_GLMapping.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_GLMapping.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_GLMapping.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_GLMapping.AutoFilterLookupColumns = False
            Me.DataGridViewForm_GLMapping.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_GLMapping.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_GLMapping.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_GLMapping.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_GLMapping.ItemDescription = "General Ledger Mapping(s)"
            Me.DataGridViewForm_GLMapping.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_GLMapping.MultiSelect = True
            Me.DataGridViewForm_GLMapping.Name = "DataGridViewForm_GLMapping"
            Me.DataGridViewForm_GLMapping.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_GLMapping.RunStandardValidation = True
            Me.DataGridViewForm_GLMapping.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_GLMapping.Size = New System.Drawing.Size(689, 397)
            Me.DataGridViewForm_GLMapping.TabIndex = 4
            Me.DataGridViewForm_GLMapping.UseEmbeddedNavigator = False
            Me.DataGridViewForm_GLMapping.ViewCaptionHeight = -1
            '
            'GeneralLedgerMappingSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_GLMapping)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "GeneralLedgerMappingSetupForm"
            Me.Text = "GL Mapping Maintenance"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.RibbonBarOptions_RecordSource.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents DataGridViewForm_GLMapping As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_RecordSource As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ComboBoxRecordSource_RecordSource As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ItemContainerRecordSource_RecordSource As DevComponents.DotNetBar.ItemContainer
        Friend WithEvents ControlContainerItemRecordSource_RecordSource As DevComponents.DotNetBar.ControlContainerItem
        Friend WithEvents ButtonItemRecordSource_Manage As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

