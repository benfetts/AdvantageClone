Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayableImportExpenseReportSearchDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableImportExpenseReportSearchDialog))
        Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.GroupBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
        Me.SearchableComboBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.RadioButtonOffice_Selected = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonOffice_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.GroupBoxForm_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.SearchableComboBoxForm_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewForm_DepartmentTeam = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.RadioButtonDept_Selected = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonDept_All = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            CType(Me.GroupBoxForm_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Office.SuspendLayout()
            CType(Me.SearchableComboBoxForm_Office.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewForm_Office, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_DepartmentTeam, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_DepartmentTeam.SuspendLayout()
            CType(Me.SearchableComboBoxForm_DepartmentTeam.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewForm_DepartmentTeam, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(265, 160)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(346, 160)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 3
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'GroupBoxForm_Office
            '
            Me.GroupBoxForm_Office.Controls.Add(Me.SearchableComboBoxForm_Office)
            Me.GroupBoxForm_Office.Controls.Add(Me.RadioButtonOffice_Selected)
            Me.GroupBoxForm_Office.Controls.Add(Me.RadioButtonOffice_All)
            Me.GroupBoxForm_Office.Location = New System.Drawing.Point(12, 12)
            Me.GroupBoxForm_Office.Name = "GroupBoxForm_Office"
            Me.GroupBoxForm_Office.Size = New System.Drawing.Size(409, 68)
            Me.GroupBoxForm_Office.TabIndex = 0
            Me.GroupBoxForm_Office.Text = "Office"
            '
            'SearchableComboBoxForm_Office
            '
            Me.SearchableComboBoxForm_Office.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Office.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Office
            Me.SearchableComboBoxForm_Office.DataSource = Nothing
            Me.SearchableComboBoxForm_Office.DisableMouseWheel = True
            Me.SearchableComboBoxForm_Office.DisplayName = ""
            Me.SearchableComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Office.Location = New System.Drawing.Point(140, 24)
            Me.SearchableComboBoxForm_Office.Name = "SearchableComboBoxForm_Office"
            Me.SearchableComboBoxForm_Office.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Office.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Office.Properties.NullText = "Select Office"
            Me.SearchableComboBoxForm_Office.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Office.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Office.Properties.View = Me.SearchableComboBoxViewForm_Office
            Me.SearchableComboBoxForm_Office.SecurityEnabled = True
            Me.SearchableComboBoxForm_Office.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Office.Size = New System.Drawing.Size(264, 20)
            Me.SearchableComboBoxForm_Office.TabIndex = 2
            '
            'SearchableComboBoxViewForm_Office
            '
            Me.SearchableComboBoxViewForm_Office.AFActiveFilterString = ""
            Me.SearchableComboBoxViewForm_Office.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_Office.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewForm_Office.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewForm_Office.DataSourceClearing = False
            Me.SearchableComboBoxViewForm_Office.EnableDisabledRows = False
            Me.SearchableComboBoxViewForm_Office.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewForm_Office.Name = "SearchableComboBoxViewForm_Office"
            Me.SearchableComboBoxViewForm_Office.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewForm_Office.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewForm_Office.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewForm_Office.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewForm_Office.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewForm_Office.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewForm_Office.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewForm_Office.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewForm_Office.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewForm_Office.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewForm_Office.RunStandardValidation = True
            '
            'RadioButtonOffice_Selected
            '
            Me.RadioButtonOffice_Selected.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOffice_Selected.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOffice_Selected.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOffice_Selected.Location = New System.Drawing.Point(61, 24)
            Me.RadioButtonOffice_Selected.Name = "RadioButtonOffice_Selected"
            Me.RadioButtonOffice_Selected.SecurityEnabled = True
            Me.RadioButtonOffice_Selected.Size = New System.Drawing.Size(73, 23)
            Me.RadioButtonOffice_Selected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOffice_Selected.TabIndex = 1
            Me.RadioButtonOffice_Selected.Text = "Selected"
            '
            'RadioButtonOffice_All
            '
            Me.RadioButtonOffice_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonOffice_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonOffice_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonOffice_All.Checked = True
            Me.RadioButtonOffice_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonOffice_All.CheckValue = "Y"
            Me.RadioButtonOffice_All.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonOffice_All.Name = "RadioButtonOffice_All"
            Me.RadioButtonOffice_All.SecurityEnabled = True
            Me.RadioButtonOffice_All.Size = New System.Drawing.Size(50, 23)
            Me.RadioButtonOffice_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonOffice_All.TabIndex = 0
            Me.RadioButtonOffice_All.Text = "All"
            '
            'GroupBoxForm_DepartmentTeam
            '
            Me.GroupBoxForm_DepartmentTeam.Controls.Add(Me.SearchableComboBoxForm_DepartmentTeam)
            Me.GroupBoxForm_DepartmentTeam.Controls.Add(Me.RadioButtonDept_Selected)
            Me.GroupBoxForm_DepartmentTeam.Controls.Add(Me.RadioButtonDept_All)
            Me.GroupBoxForm_DepartmentTeam.Location = New System.Drawing.Point(12, 86)
            Me.GroupBoxForm_DepartmentTeam.Name = "GroupBoxForm_DepartmentTeam"
            Me.GroupBoxForm_DepartmentTeam.Size = New System.Drawing.Size(409, 68)
            Me.GroupBoxForm_DepartmentTeam.TabIndex = 1
            Me.GroupBoxForm_DepartmentTeam.Text = "Department / Team"
            '
            'SearchableComboBoxForm_DepartmentTeam
            '
            Me.SearchableComboBoxForm_DepartmentTeam.ActiveFilterString = ""
            Me.SearchableComboBoxForm_DepartmentTeam.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_DepartmentTeam.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_DepartmentTeam.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.DepartmentTeam
            Me.SearchableComboBoxForm_DepartmentTeam.DataSource = Nothing
            Me.SearchableComboBoxForm_DepartmentTeam.DisableMouseWheel = True
            Me.SearchableComboBoxForm_DepartmentTeam.DisplayName = ""
            Me.SearchableComboBoxForm_DepartmentTeam.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_DepartmentTeam.Location = New System.Drawing.Point(140, 24)
            Me.SearchableComboBoxForm_DepartmentTeam.Name = "SearchableComboBoxForm_DepartmentTeam"
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.DisplayMember = "Description"
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.NullText = "Select Department / Team"
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_DepartmentTeam.Properties.View = Me.SearchableComboBoxViewForm_DepartmentTeam
            Me.SearchableComboBoxForm_DepartmentTeam.SecurityEnabled = True
            Me.SearchableComboBoxForm_DepartmentTeam.SelectedValue = Nothing
            Me.SearchableComboBoxForm_DepartmentTeam.Size = New System.Drawing.Size(264, 20)
            Me.SearchableComboBoxForm_DepartmentTeam.TabIndex = 2
            '
            'SearchableComboBoxViewForm_DepartmentTeam
            '
            Me.SearchableComboBoxViewForm_DepartmentTeam.AFActiveFilterString = ""
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBoxViewForm_DepartmentTeam.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewForm_DepartmentTeam.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewForm_DepartmentTeam.DataSourceClearing = False
            Me.SearchableComboBoxViewForm_DepartmentTeam.EnableDisabledRows = False
            Me.SearchableComboBoxViewForm_DepartmentTeam.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewForm_DepartmentTeam.Name = "SearchableComboBoxViewForm_DepartmentTeam"
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsBehavior.Editable = False
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsSelection.MultiSelect = True
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewForm_DepartmentTeam.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBoxViewForm_DepartmentTeam.RunStandardValidation = True
            '
            'RadioButtonDept_Selected
            '
            Me.RadioButtonDept_Selected.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDept_Selected.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDept_Selected.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDept_Selected.Location = New System.Drawing.Point(61, 24)
            Me.RadioButtonDept_Selected.Name = "RadioButtonDept_Selected"
            Me.RadioButtonDept_Selected.SecurityEnabled = True
            Me.RadioButtonDept_Selected.Size = New System.Drawing.Size(73, 23)
            Me.RadioButtonDept_Selected.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDept_Selected.TabIndex = 1
            Me.RadioButtonDept_Selected.Text = "Selected"
            '
            'RadioButtonDept_All
            '
            Me.RadioButtonDept_All.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonDept_All.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonDept_All.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonDept_All.Checked = True
            Me.RadioButtonDept_All.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonDept_All.CheckValue = "Y"
            Me.RadioButtonDept_All.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonDept_All.Name = "RadioButtonDept_All"
            Me.RadioButtonDept_All.SecurityEnabled = True
            Me.RadioButtonDept_All.Size = New System.Drawing.Size(50, 23)
            Me.RadioButtonDept_All.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonDept_All.TabIndex = 0
            Me.RadioButtonDept_All.Text = "All"
            '
            'AccountsPayableImportExpenseReportSearchDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(433, 192)
            Me.Controls.Add(Me.GroupBoxForm_DepartmentTeam)
            Me.Controls.Add(Me.GroupBoxForm_Office)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsPayableImportExpenseReportSearchDialog"
            Me.Text = "Expense Report Search Criteria"
            CType(Me.GroupBoxForm_Office, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Office.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_Office.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewForm_Office, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_DepartmentTeam, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_DepartmentTeam.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_DepartmentTeam.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewForm_DepartmentTeam, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents GroupBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonOffice_Selected As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonOffice_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxForm_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonDept_Selected As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonDept_All As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents SearchableComboBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewForm_Office As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents SearchableComboBoxForm_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewForm_DepartmentTeam As AdvantageFramework.WinForm.Presentation.Controls.GridView
    End Class

End Namespace