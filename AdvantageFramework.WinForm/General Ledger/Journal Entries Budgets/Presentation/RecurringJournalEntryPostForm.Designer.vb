Namespace GeneralLedger.JournalEntriesBudgets.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RecurringJournalEntryPostForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecurringJournalEntryPostForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Post = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.LabelForm_TransactionDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_Cycle = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelForm_PostingPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GridLookUpEditForm_PostPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridLookUpEdit()
            Me.GridLookUpEditViewForm_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.ComboBoxForm_Cycle = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.DateEditForm_TransactionDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DataGridViewForm_RecurringEntries = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.GridLookUpEditForm_PostPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridLookUpEditViewForm_PostPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_TransactionDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_TransactionDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(326, 233)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(243, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 8
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
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Post, Me.ButtonItemActions_Print})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(130, 98)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Post
            '
            Me.ButtonItemActions_Post.BeginGroup = True
            Me.ButtonItemActions_Post.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Post.Name = "ButtonItemActions_Post"
            Me.ButtonItemActions_Post.RibbonWordWrap = False
            Me.ButtonItemActions_Post.SecurityEnabled = True
            Me.ButtonItemActions_Post.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Post.Text = "Post"
            '
            'ButtonItemActions_Print
            '
            Me.ButtonItemActions_Print.BeginGroup = True
            Me.ButtonItemActions_Print.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Print.Name = "ButtonItemActions_Print"
            Me.ButtonItemActions_Print.RibbonWordWrap = False
            Me.ButtonItemActions_Print.SecurityEnabled = True
            Me.ButtonItemActions_Print.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Print.Text = "Print"
            '
            'LabelForm_TransactionDate
            '
            Me.LabelForm_TransactionDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_TransactionDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_TransactionDate.Location = New System.Drawing.Point(463, 12)
            Me.LabelForm_TransactionDate.Name = "LabelForm_TransactionDate"
            Me.LabelForm_TransactionDate.Size = New System.Drawing.Size(106, 20)
            Me.LabelForm_TransactionDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_TransactionDate.TabIndex = 4
            Me.LabelForm_TransactionDate.Text = "Transaction Date:"
            '
            'LabelForm_Cycle
            '
            Me.LabelForm_Cycle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Cycle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Cycle.Location = New System.Drawing.Point(250, 12)
            Me.LabelForm_Cycle.Name = "LabelForm_Cycle"
            Me.LabelForm_Cycle.Size = New System.Drawing.Size(39, 20)
            Me.LabelForm_Cycle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Cycle.TabIndex = 2
            Me.LabelForm_Cycle.Text = "Cycle:"
            '
            'LabelForm_PostingPeriod
            '
            Me.LabelForm_PostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PostingPeriod.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_PostingPeriod.Name = "LabelForm_PostingPeriod"
            Me.LabelForm_PostingPeriod.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PostingPeriod.TabIndex = 0
            Me.LabelForm_PostingPeriod.Text = "Posting Period:"
            '
            'GridLookUpEditForm_PostPeriod
            '
            Me.GridLookUpEditForm_PostPeriod.ActiveFilterString = ""
            Me.GridLookUpEditForm_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.GridLookUpEditForm_PostPeriod.AutoFillMode = False
            Me.GridLookUpEditForm_PostPeriod.BookmarkingEnabled = False
            Me.GridLookUpEditForm_PostPeriod.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.GridLookUpEdit.Type.PostPeriod
            Me.GridLookUpEditForm_PostPeriod.DataSource = Nothing
            Me.GridLookUpEditForm_PostPeriod.DisableMouseWheel = False
            Me.GridLookUpEditForm_PostPeriod.DisplayName = ""
            Me.GridLookUpEditForm_PostPeriod.EnterMoveNextControl = True
            Me.GridLookUpEditForm_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.GridLookUpEdit.ExtraComboBoxItems.[Nothing]
            Me.GridLookUpEditForm_PostPeriod.Location = New System.Drawing.Point(100, 12)
            Me.GridLookUpEditForm_PostPeriod.Name = "GridLookUpEditForm_PostPeriod"
            Me.GridLookUpEditForm_PostPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.GridLookUpEditForm_PostPeriod.Properties.DisplayMember = "Description"
            Me.GridLookUpEditForm_PostPeriod.Properties.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.GridLookUpEditForm_PostPeriod.Properties.LookAndFeel.UseDefaultLookAndFeel = False
            Me.GridLookUpEditForm_PostPeriod.Properties.NullText = "Select Post Period"
            Me.GridLookUpEditForm_PostPeriod.Properties.PopupView = Me.GridLookUpEditViewForm_PostPeriod
            Me.GridLookUpEditForm_PostPeriod.Properties.ValueMember = "Code"
            Me.GridLookUpEditForm_PostPeriod.SecurityEnabled = True
            Me.GridLookUpEditForm_PostPeriod.SelectedValue = Nothing
            Me.GridLookUpEditForm_PostPeriod.Size = New System.Drawing.Size(144, 20)
            Me.GridLookUpEditForm_PostPeriod.TabIndex = 1
            '
            'GridLookUpEditViewForm_PostPeriod
            '
            Me.GridLookUpEditViewForm_PostPeriod.AFActiveFilterString = ""
            Me.GridLookUpEditViewForm_PostPeriod.AllowExtraItemsInGridLookupEdits = True
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewForm_PostPeriod.AutoFilterLookupColumns = False
            Me.GridLookUpEditViewForm_PostPeriod.AutoloadRepositoryDatasource = True
            Me.GridLookUpEditViewForm_PostPeriod.DataSourceClearing = False
            Me.GridLookUpEditViewForm_PostPeriod.EnableDisabledRows = False
            Me.GridLookUpEditViewForm_PostPeriod.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridLookUpEditViewForm_PostPeriod.Name = "GridLookUpEditViewForm_PostPeriod"
            Me.GridLookUpEditViewForm_PostPeriod.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridLookUpEditViewForm_PostPeriod.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridLookUpEditViewForm_PostPeriod.OptionsBehavior.Editable = False
            Me.GridLookUpEditViewForm_PostPeriod.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridLookUpEditViewForm_PostPeriod.OptionsNavigation.AutoFocusNewRow = True
            Me.GridLookUpEditViewForm_PostPeriod.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridLookUpEditViewForm_PostPeriod.OptionsSelection.MultiSelect = True
            Me.GridLookUpEditViewForm_PostPeriod.OptionsView.ColumnAutoWidth = False
            Me.GridLookUpEditViewForm_PostPeriod.OptionsView.ShowGroupPanel = False
            Me.GridLookUpEditViewForm_PostPeriod.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridLookUpEditViewForm_PostPeriod.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridLookUpEditViewForm_PostPeriod.RunStandardValidation = True
            Me.GridLookUpEditViewForm_PostPeriod.SkipAddingControlsOnModifyColumn = False
            Me.GridLookUpEditViewForm_PostPeriod.SkipSettingFontOnModifyColumn = False
            '
            'ComboBoxForm_Cycle
            '
            Me.ComboBoxForm_Cycle.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Cycle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Cycle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Cycle.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Cycle.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Cycle.BookmarkingEnabled = False
            Me.ComboBoxForm_Cycle.DisableMouseWheel = False
            Me.ComboBoxForm_Cycle.DisplayMember = "Code"
            Me.ComboBoxForm_Cycle.DisplayName = ""
            Me.ComboBoxForm_Cycle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Cycle.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Cycle.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_Cycle.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Cycle.FocusHighlightEnabled = True
            Me.ComboBoxForm_Cycle.FormattingEnabled = True
            Me.ComboBoxForm_Cycle.ItemHeight = 14
            Me.ComboBoxForm_Cycle.Location = New System.Drawing.Point(295, 12)
            Me.ComboBoxForm_Cycle.Name = "ComboBoxForm_Cycle"
            Me.ComboBoxForm_Cycle.ReadOnly = False
            Me.ComboBoxForm_Cycle.SecurityEnabled = True
            Me.ComboBoxForm_Cycle.Size = New System.Drawing.Size(162, 20)
            Me.ComboBoxForm_Cycle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Cycle.TabIndex = 3
            Me.ComboBoxForm_Cycle.TabOnEnter = True
            Me.ComboBoxForm_Cycle.ValueMember = "Description"
            '
            'DateEditForm_TransactionDate
            '
            Me.DateEditForm_TransactionDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_TransactionDate.DisplayName = ""
            Me.DateEditForm_TransactionDate.EditValue = New Date(2020, 7, 15, 9, 31, 54, 178)
            Me.DateEditForm_TransactionDate.Location = New System.Drawing.Point(575, 12)
            Me.DateEditForm_TransactionDate.Name = "DateEditForm_TransactionDate"
            Me.DateEditForm_TransactionDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_TransactionDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_TransactionDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_TransactionDate.Properties.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.DateEditForm_TransactionDate.Properties.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DateEditForm_TransactionDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            Me.DateEditForm_TransactionDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_TransactionDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_TransactionDate.SecurityEnabled = True
            Me.DateEditForm_TransactionDate.Size = New System.Drawing.Size(110, 20)
            Me.DateEditForm_TransactionDate.TabIndex = 5
            Me.DateEditForm_TransactionDate.TabOnEnter = True
            '
            'DataGridViewForm_RecurringEntries
            '
            Me.DataGridViewForm_RecurringEntries.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_RecurringEntries.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_RecurringEntries.AutoUpdateViewCaption = True
            Me.DataGridViewForm_RecurringEntries.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_RecurringEntries.ItemDescription = "Entry(ies)"
            Me.DataGridViewForm_RecurringEntries.Location = New System.Drawing.Point(13, 39)
            Me.DataGridViewForm_RecurringEntries.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_RecurringEntries.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_RecurringEntries.ModifyGridRowHeight = False
            Me.DataGridViewForm_RecurringEntries.MultiSelect = False
            Me.DataGridViewForm_RecurringEntries.Name = "DataGridViewForm_RecurringEntries"
            Me.DataGridViewForm_RecurringEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_RecurringEntries.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_RecurringEntries.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_RecurringEntries.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_RecurringEntries.Size = New System.Drawing.Size(890, 487)
            Me.DataGridViewForm_RecurringEntries.TabIndex = 6
            Me.DataGridViewForm_RecurringEntries.UseEmbeddedNavigator = False
            Me.DataGridViewForm_RecurringEntries.ViewCaptionHeight = -1
            '
            'RecurringJournalEntryPostForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(916, 539)
            Me.Controls.Add(Me.DateEditForm_TransactionDate)
            Me.Controls.Add(Me.ComboBoxForm_Cycle)
            Me.Controls.Add(Me.GridLookUpEditForm_PostPeriod)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.LabelForm_TransactionDate)
            Me.Controls.Add(Me.LabelForm_Cycle)
            Me.Controls.Add(Me.LabelForm_PostingPeriod)
            Me.Controls.Add(Me.DataGridViewForm_RecurringEntries)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RecurringJournalEntryPostForm"
            Me.Text = "Recurring Journal Entry Post"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.GridLookUpEditForm_PostPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridLookUpEditViewForm_PostPeriod, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_TransactionDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_TransactionDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Post As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents LabelForm_TransactionDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_Cycle As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelForm_PostingPeriod As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents GridLookUpEditForm_PostPeriod As WinForm.MVC.Presentation.Controls.GridLookUpEdit
        Friend WithEvents GridLookUpEditViewForm_PostPeriod As WinForm.Presentation.Controls.GridView
        Friend WithEvents ComboBoxForm_Cycle As WinForm.MVC.Presentation.Controls.ComboBox
        Friend WithEvents DateEditForm_TransactionDate As WinForm.MVC.Presentation.Controls.DateEdit
        Friend WithEvents DataGridViewForm_RecurringEntries As WinForm.MVC.Presentation.Controls.DataGridView
    End Class

End Namespace

