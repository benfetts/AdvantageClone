Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleInitialLoadingDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
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
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectScheduleInitialLoadingDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Phase = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Role = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewCriteria_Criteria = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_Role = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SearchableComboBoxForm_Task = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView1 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.SearchableComboBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView2 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.DateTimePickerForm_DateCutoff = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.CheckBoxForm_OnlyPendingTasks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_IncludeCompletedTasks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_ExcludeProjectedTasks = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SearchableComboBoxForm_Phase = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.GridView3 = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_Task = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DateCutoff = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.SearchableComboBoxForm_Role.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewCriteria_Criteria, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Task.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Employee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_DateCutoff, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxForm_Phase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(147, 220)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 13
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(228, 220)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 14
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_Phase
            '
            Me.LabelForm_Phase.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Phase.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Phase.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Phase.Name = "LabelForm_Phase"
            Me.LabelForm_Phase.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_Phase.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Phase.TabIndex = 0
            Me.LabelForm_Phase.Text = "Phase:"
            '
            'SearchableComboBoxForm_Role
            '
            Me.SearchableComboBoxForm_Role.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Role.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Role.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Role.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Role
            Me.SearchableComboBoxForm_Role.DataSource = Nothing
            Me.SearchableComboBoxForm_Role.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Role.DisplayName = ""
            Me.SearchableComboBoxForm_Role.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_Role.Location = New System.Drawing.Point(87, 38)
            Me.SearchableComboBoxForm_Role.Name = "SearchableComboBoxForm_Role"
            Me.SearchableComboBoxForm_Role.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Role.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_Role.Properties.NullText = "Select Role"
            Me.SearchableComboBoxForm_Role.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Role.Properties.View = Me.SearchableComboBoxViewCriteria_Criteria
            Me.SearchableComboBoxForm_Role.SecurityEnabled = True
            Me.SearchableComboBoxForm_Role.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Role.Size = New System.Drawing.Size(216, 20)
            Me.SearchableComboBoxForm_Role.TabIndex = 3
            '
            'SearchableComboBoxViewCriteria_Criteria
            '
            Me.SearchableComboBoxViewCriteria_Criteria.AFActiveFilterString = ""
            Me.SearchableComboBoxViewCriteria_Criteria.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewCriteria_Criteria.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewCriteria_Criteria.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewCriteria_Criteria.DataSourceClearing = False
            Me.SearchableComboBoxViewCriteria_Criteria.EnableDisabledRows = False
            Me.SearchableComboBoxViewCriteria_Criteria.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewCriteria_Criteria.Name = "SearchableComboBoxViewCriteria_Criteria"
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewCriteria_Criteria.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewCriteria_Criteria.RunStandardValidation = True
            '
            'LabelForm_Role
            '
            Me.LabelForm_Role.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Role.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Role.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Role.Name = "LabelForm_Role"
            Me.LabelForm_Role.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_Role.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Role.TabIndex = 2
            Me.LabelForm_Role.Text = "Role:"
            '
            'SearchableComboBoxForm_Task
            '
            Me.SearchableComboBoxForm_Task.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Task.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Task.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Task.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Task
            Me.SearchableComboBoxForm_Task.DataSource = Nothing
            Me.SearchableComboBoxForm_Task.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Task.DisplayName = ""
            Me.SearchableComboBoxForm_Task.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_Task.Location = New System.Drawing.Point(87, 64)
            Me.SearchableComboBoxForm_Task.Name = "SearchableComboBoxForm_Task"
            Me.SearchableComboBoxForm_Task.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Task.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_Task.Properties.NullText = "Select Task"
            Me.SearchableComboBoxForm_Task.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Task.Properties.View = Me.GridView1
            Me.SearchableComboBoxForm_Task.SecurityEnabled = True
            Me.SearchableComboBoxForm_Task.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Task.Size = New System.Drawing.Size(216, 20)
            Me.SearchableComboBoxForm_Task.TabIndex = 5
            '
            'GridView1
            '
            Me.GridView1.AFActiveFilterString = ""
            Me.GridView1.AllowExtraItemsInGridLookupEdits = True
            Me.GridView1.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView1.AutoFilterLookupColumns = False
            Me.GridView1.AutoloadRepositoryDatasource = True
            Me.GridView1.DataSourceClearing = False
            Me.GridView1.EnableDisabledRows = False
            Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView1.Name = "GridView1"
            Me.GridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView1.OptionsBehavior.Editable = False
            Me.GridView1.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView1.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView1.OptionsSelection.MultiSelect = True
            Me.GridView1.OptionsView.ColumnAutoWidth = False
            Me.GridView1.OptionsView.ShowGroupPanel = False
            Me.GridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView1.RunStandardValidation = True
            '
            'SearchableComboBoxForm_Employee
            '
            Me.SearchableComboBoxForm_Employee.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Employee.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Employee.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_Employee.DataSource = Nothing
            Me.SearchableComboBoxForm_Employee.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Employee.DisplayName = ""
            Me.SearchableComboBoxForm_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_Employee.Location = New System.Drawing.Point(87, 90)
            Me.SearchableComboBoxForm_Employee.Name = "SearchableComboBoxForm_Employee"
            Me.SearchableComboBoxForm_Employee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Employee.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Employee.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxForm_Employee.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Employee.Properties.View = Me.GridView2
            Me.SearchableComboBoxForm_Employee.SecurityEnabled = True
            Me.SearchableComboBoxForm_Employee.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Employee.Size = New System.Drawing.Size(216, 20)
            Me.SearchableComboBoxForm_Employee.TabIndex = 7
            '
            'GridView2
            '
            Me.GridView2.AFActiveFilterString = ""
            Me.GridView2.AllowExtraItemsInGridLookupEdits = True
            Me.GridView2.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView2.AutoFilterLookupColumns = False
            Me.GridView2.AutoloadRepositoryDatasource = True
            Me.GridView2.DataSourceClearing = False
            Me.GridView2.EnableDisabledRows = False
            Me.GridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView2.Name = "GridView2"
            Me.GridView2.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView2.OptionsBehavior.Editable = False
            Me.GridView2.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView2.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView2.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView2.OptionsSelection.MultiSelect = True
            Me.GridView2.OptionsView.ColumnAutoWidth = False
            Me.GridView2.OptionsView.ShowGroupPanel = False
            Me.GridView2.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView2.RunStandardValidation = True
            '
            'DateTimePickerForm_DateCutoff
            '
            Me.DateTimePickerForm_DateCutoff.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_DateCutoff.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_DateCutoff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateCutoff.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_DateCutoff.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_DateCutoff.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_DateCutoff.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerForm_DateCutoff.CustomFormat = ""
            Me.DateTimePickerForm_DateCutoff.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_DateCutoff.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_DateCutoff.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_DateCutoff.FocusHighlightEnabled = True
            Me.DateTimePickerForm_DateCutoff.Format = DevComponents.Editors.eDateTimePickerFormat.Short
            Me.DateTimePickerForm_DateCutoff.FreeTextEntryMode = True
            Me.DateTimePickerForm_DateCutoff.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_DateCutoff.Location = New System.Drawing.Point(87, 116)
            Me.DateTimePickerForm_DateCutoff.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.DisplayMonth = New Date(2013, 8, 1, 0, 0, 0, 0)
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_DateCutoff.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerForm_DateCutoff.Name = "DateTimePickerForm_DateCutoff"
            Me.DateTimePickerForm_DateCutoff.ReadOnly = False
            Me.DateTimePickerForm_DateCutoff.Size = New System.Drawing.Size(124, 20)
            Me.DateTimePickerForm_DateCutoff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_DateCutoff.TabIndex = 9
            Me.DateTimePickerForm_DateCutoff.Value = New Date(2013, 8, 5, 14, 7, 4, 364)
            '
            'CheckBoxForm_OnlyPendingTasks
            '
            '
            '
            '
            Me.CheckBoxForm_OnlyPendingTasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_OnlyPendingTasks.CheckValue = 0
            Me.CheckBoxForm_OnlyPendingTasks.CheckValueChecked = 1
            Me.CheckBoxForm_OnlyPendingTasks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_OnlyPendingTasks.CheckValueUnchecked = 0
            Me.CheckBoxForm_OnlyPendingTasks.ChildControls = CType(resources.GetObject("CheckBoxForm_OnlyPendingTasks.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_OnlyPendingTasks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_OnlyPendingTasks.Location = New System.Drawing.Point(87, 142)
            Me.CheckBoxForm_OnlyPendingTasks.Name = "CheckBoxForm_OnlyPendingTasks"
            Me.CheckBoxForm_OnlyPendingTasks.OldestSibling = Nothing
            Me.CheckBoxForm_OnlyPendingTasks.SecurityEnabled = True
            Me.CheckBoxForm_OnlyPendingTasks.SiblingControls = CType(resources.GetObject("CheckBoxForm_OnlyPendingTasks.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_OnlyPendingTasks.Size = New System.Drawing.Size(216, 20)
            Me.CheckBoxForm_OnlyPendingTasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_OnlyPendingTasks.TabIndex = 10
            Me.CheckBoxForm_OnlyPendingTasks.Text = "Only Pending Tasks"
            '
            'CheckBoxForm_IncludeCompletedTasks
            '
            '
            '
            '
            Me.CheckBoxForm_IncludeCompletedTasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeCompletedTasks.CheckValue = 0
            Me.CheckBoxForm_IncludeCompletedTasks.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeCompletedTasks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeCompletedTasks.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeCompletedTasks.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeCompletedTasks.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeCompletedTasks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeCompletedTasks.Location = New System.Drawing.Point(87, 194)
            Me.CheckBoxForm_IncludeCompletedTasks.Name = "CheckBoxForm_IncludeCompletedTasks"
            Me.CheckBoxForm_IncludeCompletedTasks.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeCompletedTasks.SecurityEnabled = True
            Me.CheckBoxForm_IncludeCompletedTasks.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeCompletedTasks.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeCompletedTasks.Size = New System.Drawing.Size(216, 20)
            Me.CheckBoxForm_IncludeCompletedTasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeCompletedTasks.TabIndex = 12
            Me.CheckBoxForm_IncludeCompletedTasks.Text = "Include Completed Tasks"
            '
            'CheckBoxForm_ExcludeProjectedTasks
            '
            '
            '
            '
            Me.CheckBoxForm_ExcludeProjectedTasks.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ExcludeProjectedTasks.CheckValue = 0
            Me.CheckBoxForm_ExcludeProjectedTasks.CheckValueChecked = 1
            Me.CheckBoxForm_ExcludeProjectedTasks.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ExcludeProjectedTasks.CheckValueUnchecked = 0
            Me.CheckBoxForm_ExcludeProjectedTasks.ChildControls = CType(resources.GetObject("CheckBoxForm_ExcludeProjectedTasks.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeProjectedTasks.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ExcludeProjectedTasks.Location = New System.Drawing.Point(87, 168)
            Me.CheckBoxForm_ExcludeProjectedTasks.Name = "CheckBoxForm_ExcludeProjectedTasks"
            Me.CheckBoxForm_ExcludeProjectedTasks.OldestSibling = Nothing
            Me.CheckBoxForm_ExcludeProjectedTasks.SecurityEnabled = True
            Me.CheckBoxForm_ExcludeProjectedTasks.SiblingControls = CType(resources.GetObject("CheckBoxForm_ExcludeProjectedTasks.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ExcludeProjectedTasks.Size = New System.Drawing.Size(216, 20)
            Me.CheckBoxForm_ExcludeProjectedTasks.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ExcludeProjectedTasks.TabIndex = 11
            Me.CheckBoxForm_ExcludeProjectedTasks.Text = "Exclude Projected Tasks"
            '
            'SearchableComboBoxForm_Phase
            '
            Me.SearchableComboBoxForm_Phase.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Phase.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Phase.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Phase.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Phase
            Me.SearchableComboBoxForm_Phase.DataSource = Nothing
            Me.SearchableComboBoxForm_Phase.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Phase.DisplayName = ""
            Me.SearchableComboBoxForm_Phase.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.PleaseSelect
            Me.SearchableComboBoxForm_Phase.Location = New System.Drawing.Point(87, 12)
            Me.SearchableComboBoxForm_Phase.Name = "SearchableComboBoxForm_Phase"
            Me.SearchableComboBoxForm_Phase.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Phase.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_Phase.Properties.NullText = "Select Phase"
            Me.SearchableComboBoxForm_Phase.Properties.ValueMember = "ID"
            Me.SearchableComboBoxForm_Phase.Properties.View = Me.GridView3
            Me.SearchableComboBoxForm_Phase.SecurityEnabled = True
            Me.SearchableComboBoxForm_Phase.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Phase.Size = New System.Drawing.Size(216, 20)
            Me.SearchableComboBoxForm_Phase.TabIndex = 1
            '
            'GridView3
            '
            Me.GridView3.AFActiveFilterString = ""
            Me.GridView3.AllowExtraItemsInGridLookupEdits = True
            Me.GridView3.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridView3.AutoFilterLookupColumns = False
            Me.GridView3.AutoloadRepositoryDatasource = True
            Me.GridView3.DataSourceClearing = False
            Me.GridView3.EnableDisabledRows = False
            Me.GridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridView3.Name = "GridView3"
            Me.GridView3.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridView3.OptionsBehavior.Editable = False
            Me.GridView3.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridView3.OptionsNavigation.AutoFocusNewRow = True
            Me.GridView3.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridView3.OptionsSelection.MultiSelect = True
            Me.GridView3.OptionsView.ColumnAutoWidth = False
            Me.GridView3.OptionsView.ShowGroupPanel = False
            Me.GridView3.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridView3.RunStandardValidation = True
            '
            'LabelForm_Task
            '
            Me.LabelForm_Task.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Task.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Task.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_Task.Name = "LabelForm_Task"
            Me.LabelForm_Task.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_Task.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Task.TabIndex = 4
            Me.LabelForm_Task.Text = "Task:"
            '
            'LabelForm_Employee
            '
            Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Employee.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Employee.Name = "LabelForm_Employee"
            Me.LabelForm_Employee.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Employee.TabIndex = 6
            Me.LabelForm_Employee.Text = "Employee:"
            '
            'LabelForm_DateCutoff
            '
            Me.LabelForm_DateCutoff.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DateCutoff.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DateCutoff.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_DateCutoff.Name = "LabelForm_DateCutoff"
            Me.LabelForm_DateCutoff.Size = New System.Drawing.Size(69, 20)
            Me.LabelForm_DateCutoff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DateCutoff.TabIndex = 8
            Me.LabelForm_DateCutoff.Text = "Date Cutoff:"
            '
            'ProjectScheduleInitialLoadingDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(315, 252)
            Me.Controls.Add(Me.LabelForm_DateCutoff)
            Me.Controls.Add(Me.LabelForm_Employee)
            Me.Controls.Add(Me.LabelForm_Task)
            Me.Controls.Add(Me.SearchableComboBoxForm_Phase)
            Me.Controls.Add(Me.CheckBoxForm_ExcludeProjectedTasks)
            Me.Controls.Add(Me.CheckBoxForm_IncludeCompletedTasks)
            Me.Controls.Add(Me.CheckBoxForm_OnlyPendingTasks)
            Me.Controls.Add(Me.DateTimePickerForm_DateCutoff)
            Me.Controls.Add(Me.SearchableComboBoxForm_Employee)
            Me.Controls.Add(Me.SearchableComboBoxForm_Task)
            Me.Controls.Add(Me.LabelForm_Role)
            Me.Controls.Add(Me.LabelForm_Phase)
            Me.Controls.Add(Me.SearchableComboBoxForm_Role)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProjectScheduleInitialLoadingDialog"
            Me.Text = "Set Initial Criteria"
            CType(Me.SearchableComboBoxForm_Role.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewCriteria_Criteria, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Task.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Employee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_DateCutoff, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxForm_Phase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Phase As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Role As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewCriteria_Criteria As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Role As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Task As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView1 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView2 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents DateTimePickerForm_DateCutoff As AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents CheckBoxForm_OnlyPendingTasks As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_IncludeCompletedTasks As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_ExcludeProjectedTasks As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents SearchableComboBoxForm_Phase As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents GridView3 As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_Task As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_DateCutoff As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace