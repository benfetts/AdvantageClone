Namespace GeneralLedger.Maintenance.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class PostingPeriodsSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PostingPeriodsSetupForm))
            Me.DataGridViewForm_PostingPeriods = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_FiscalYearStartMonth = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PostingPeriodFormat = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_FiscalYearStartMonth = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_Format = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_FormatDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Statuses = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemStatus_MarkOpen = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemStatuses_MarkCurrent = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemStatuses_MarkClosed = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DataGridViewForm_PostingPeriods
            '
            Me.DataGridViewForm_PostingPeriods.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_PostingPeriods.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_PostingPeriods.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_PostingPeriods.AutoFilterLookupColumns = False
            Me.DataGridViewForm_PostingPeriods.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_PostingPeriods.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_PostingPeriods.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_PostingPeriods.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_PostingPeriods.ItemDescription = ""
            Me.DataGridViewForm_PostingPeriods.Location = New System.Drawing.Point(12, 64)
            Me.DataGridViewForm_PostingPeriods.MultiSelect = True
            Me.DataGridViewForm_PostingPeriods.Name = "DataGridViewForm_PostingPeriods"
            Me.DataGridViewForm_PostingPeriods.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_PostingPeriods.RunStandardValidation = True
            Me.DataGridViewForm_PostingPeriods.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_PostingPeriods.Size = New System.Drawing.Size(689, 345)
            Me.DataGridViewForm_PostingPeriods.TabIndex = 4
            Me.DataGridViewForm_PostingPeriods.UseEmbeddedNavigator = False
            Me.DataGridViewForm_PostingPeriods.ViewCaptionHeight = -1
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Statuses)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(98, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(473, 98)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(222, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.Stretch = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
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
            'LabelForm_FiscalYearStartMonth
            '
            Me.LabelForm_FiscalYearStartMonth.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FiscalYearStartMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FiscalYearStartMonth.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_FiscalYearStartMonth.Name = "LabelForm_FiscalYearStartMonth"
            Me.LabelForm_FiscalYearStartMonth.Size = New System.Drawing.Size(126, 20)
            Me.LabelForm_FiscalYearStartMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FiscalYearStartMonth.TabIndex = 5
            Me.LabelForm_FiscalYearStartMonth.Text = "Fiscal Year Start Month:"
            '
            'LabelForm_PostingPeriodFormat
            '
            Me.LabelForm_PostingPeriodFormat.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostingPeriodFormat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostingPeriodFormat.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_PostingPeriodFormat.Name = "LabelForm_PostingPeriodFormat"
            Me.LabelForm_PostingPeriodFormat.Size = New System.Drawing.Size(126, 20)
            Me.LabelForm_PostingPeriodFormat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostingPeriodFormat.TabIndex = 6
            Me.LabelForm_PostingPeriodFormat.Text = "Posting Period Format:"
            '
            'ComboBoxForm_FiscalYearStartMonth
            '
            Me.ComboBoxForm_FiscalYearStartMonth.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_FiscalYearStartMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_FiscalYearStartMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_FiscalYearStartMonth.AutoFindItemInDataSource = False
            Me.ComboBoxForm_FiscalYearStartMonth.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_FiscalYearStartMonth.BookmarkingEnabled = False
            Me.ComboBoxForm_FiscalYearStartMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Month
            Me.ComboBoxForm_FiscalYearStartMonth.DisableMouseWheel = False
            Me.ComboBoxForm_FiscalYearStartMonth.DisplayMember = "Value"
            Me.ComboBoxForm_FiscalYearStartMonth.DisplayName = ""
            Me.ComboBoxForm_FiscalYearStartMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_FiscalYearStartMonth.Enabled = False
            Me.ComboBoxForm_FiscalYearStartMonth.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_FiscalYearStartMonth.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_FiscalYearStartMonth.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_FiscalYearStartMonth.FocusHighlightEnabled = True
            Me.ComboBoxForm_FiscalYearStartMonth.FormattingEnabled = True
            Me.ComboBoxForm_FiscalYearStartMonth.ItemHeight = 14
            Me.ComboBoxForm_FiscalYearStartMonth.Location = New System.Drawing.Point(144, 12)
            Me.ComboBoxForm_FiscalYearStartMonth.Name = "ComboBoxForm_FiscalYearStartMonth"
            Me.ComboBoxForm_FiscalYearStartMonth.PreventEnterBeep = False
            Me.ComboBoxForm_FiscalYearStartMonth.ReadOnly = True
            Me.ComboBoxForm_FiscalYearStartMonth.SecurityEnabled = True
            Me.ComboBoxForm_FiscalYearStartMonth.Size = New System.Drawing.Size(137, 20)
            Me.ComboBoxForm_FiscalYearStartMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_FiscalYearStartMonth.TabIndex = 7
            Me.ComboBoxForm_FiscalYearStartMonth.ValueMember = "Key"
            Me.ComboBoxForm_FiscalYearStartMonth.WatermarkText = "Select Month"
            '
            'LabelForm_Format
            '
            Me.LabelForm_Format.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Format.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Format.Location = New System.Drawing.Point(144, 38)
            Me.LabelForm_Format.Name = "LabelForm_Format"
            Me.LabelForm_Format.Size = New System.Drawing.Size(88, 20)
            Me.LabelForm_Format.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Format.TabIndex = 8
            Me.LabelForm_Format.Text = "{0}"
            '
            'LabelForm_FormatDescription
            '
            Me.LabelForm_FormatDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_FormatDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FormatDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FormatDescription.ForeColor = System.Drawing.Color.Red
            Me.LabelForm_FormatDescription.Location = New System.Drawing.Point(238, 38)
            Me.LabelForm_FormatDescription.Name = "LabelForm_FormatDescription"
            Me.LabelForm_FormatDescription.Size = New System.Drawing.Size(463, 20)
            Me.LabelForm_FormatDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FormatDescription.TabIndex = 9
            Me.LabelForm_FormatDescription.Text = "{0}"
            '
            'DataGridViewForm_Export
            '
            Me.DataGridViewForm_Export.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Export.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Export.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Export.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Export.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Export.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Export.DataSource = Nothing
            Me.DataGridViewForm_Export.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Export.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Export.ItemDescription = ""
            Me.DataGridViewForm_Export.Location = New System.Drawing.Point(469, 230)
            Me.DataGridViewForm_Export.MultiSelect = True
            Me.DataGridViewForm_Export.Name = "DataGridViewForm_Export"
            Me.DataGridViewForm_Export.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Export.RunStandardValidation = True
            Me.DataGridViewForm_Export.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Export.Size = New System.Drawing.Size(217, 164)
            Me.DataGridViewForm_Export.TabIndex = 10
            Me.DataGridViewForm_Export.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Export.ViewCaptionHeight = -1
            Me.DataGridViewForm_Export.Visible = False
            '
            'RibbonBarOptions_Statuses
            '
            Me.RibbonBarOptions_Statuses.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Statuses.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Statuses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Statuses.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Statuses.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Statuses.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemStatus_MarkOpen, Me.ButtonItemStatuses_MarkCurrent, Me.ButtonItemStatuses_MarkClosed})
            Me.RibbonBarOptions_Statuses.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Statuses.Location = New System.Drawing.Point(222, 0)
            Me.RibbonBarOptions_Statuses.Name = "RibbonBarOptions_Statuses"
            Me.RibbonBarOptions_Statuses.Size = New System.Drawing.Size(222, 98)
            Me.RibbonBarOptions_Statuses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Statuses.TabIndex = 2
            Me.RibbonBarOptions_Statuses.Text = "Status"
            '
            '
            '
            Me.RibbonBarOptions_Statuses.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Statuses.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Statuses.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemStatus_MarkOpen
            '
            Me.ButtonItemStatus_MarkOpen.BeginGroup = True
            Me.ButtonItemStatus_MarkOpen.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatus_MarkOpen.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemStatus_MarkOpen.Name = "ButtonItemStatus_MarkOpen"
            Me.ButtonItemStatus_MarkOpen.RibbonWordWrap = False
            Me.ButtonItemStatus_MarkOpen.Stretch = True
            Me.ButtonItemStatus_MarkOpen.SubItemsExpandWidth = 14
            Me.ButtonItemStatus_MarkOpen.Text = "Mark Open"
            '
            'ButtonItemStatuses_MarkCurrent
            '
            Me.ButtonItemStatuses_MarkCurrent.BeginGroup = True
            Me.ButtonItemStatuses_MarkCurrent.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatuses_MarkCurrent.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemStatuses_MarkCurrent.Name = "ButtonItemStatuses_MarkCurrent"
            Me.ButtonItemStatuses_MarkCurrent.RibbonWordWrap = False
            Me.ButtonItemStatuses_MarkCurrent.Stretch = True
            Me.ButtonItemStatuses_MarkCurrent.SubItemsExpandWidth = 14
            Me.ButtonItemStatuses_MarkCurrent.Text = "Mark Current"
            '
            'ButtonItemStatuses_MarkClosed
            '
            Me.ButtonItemStatuses_MarkClosed.BeginGroup = True
            Me.ButtonItemStatuses_MarkClosed.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemStatuses_MarkClosed.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemStatuses_MarkClosed.Name = "ButtonItemStatuses_MarkClosed"
            Me.ButtonItemStatuses_MarkClosed.RibbonWordWrap = False
            Me.ButtonItemStatuses_MarkClosed.Stretch = True
            Me.ButtonItemStatuses_MarkClosed.SubItemsExpandWidth = 14
            Me.ButtonItemStatuses_MarkClosed.Text = "Mark Closed"
            '
            'PostingPeriodsSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.DataGridViewForm_Export)
            Me.Controls.Add(Me.LabelForm_FormatDescription)
            Me.Controls.Add(Me.LabelForm_Format)
            Me.Controls.Add(Me.ComboBoxForm_FiscalYearStartMonth)
            Me.Controls.Add(Me.LabelForm_PostingPeriodFormat)
            Me.Controls.Add(Me.LabelForm_FiscalYearStartMonth)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_PostingPeriods)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "PostingPeriodsSetupForm"
            Me.Text = "Posting Periods"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_PostingPeriods As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents LabelForm_FiscalYearStartMonth As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PostingPeriodFormat As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_FiscalYearStartMonth As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_Format As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_FormatDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_Export As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Statuses As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemStatus_MarkOpen As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemStatuses_MarkCurrent As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemStatuses_MarkClosed As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

