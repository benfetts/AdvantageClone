Namespace Employee.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ExpenseReportSubmitDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExpenseReportSubmitDialog))
        Me.ButtonForm_Submit = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.LabelForm_SelectApprover = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_EmployeeLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_SupervisorLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_AlternateApproverLabel = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Supervisor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.LabelForm_AlternateApprover = New AdvantageFramework.WinForm.Presentation.Controls.Label()
        Me.SearchableComboBoxForm_Approver = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
        Me.SearchableComboBox1View = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.CheckBoxForm_IncludeReceipts = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.SearchableComboBoxForm_Approver.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_Submit
            '
            Me.ButtonForm_Submit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Submit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Submit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Submit.Location = New System.Drawing.Point(193, 142)
            Me.ButtonForm_Submit.Name = "ButtonForm_Submit"
            Me.ButtonForm_Submit.SecurityEnabled = True
            Me.ButtonForm_Submit.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Submit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Submit.TabIndex = 8
            Me.ButtonForm_Submit.Text = "Submit"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(274, 142)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 9
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_SelectApprover
            '
            Me.LabelForm_SelectApprover.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectApprover.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectApprover.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_SelectApprover.Name = "LabelForm_SelectApprover"
            Me.LabelForm_SelectApprover.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_SelectApprover.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectApprover.TabIndex = 6
            Me.LabelForm_SelectApprover.Text = "Select Approver:"
            '
            'LabelForm_EmployeeLabel
            '
            Me.LabelForm_EmployeeLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EmployeeLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EmployeeLabel.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_EmployeeLabel.Name = "LabelForm_EmployeeLabel"
            Me.LabelForm_EmployeeLabel.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_EmployeeLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EmployeeLabel.TabIndex = 0
            Me.LabelForm_EmployeeLabel.Text = "Employee:"
            '
            'LabelForm_SupervisorLabel
            '
            Me.LabelForm_SupervisorLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SupervisorLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SupervisorLabel.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_SupervisorLabel.Name = "LabelForm_SupervisorLabel"
            Me.LabelForm_SupervisorLabel.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_SupervisorLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SupervisorLabel.TabIndex = 2
            Me.LabelForm_SupervisorLabel.Text = "Supervisor:"
            '
            'LabelForm_AlternateApproverLabel
            '
            Me.LabelForm_AlternateApproverLabel.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AlternateApproverLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AlternateApproverLabel.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_AlternateApproverLabel.Name = "LabelForm_AlternateApproverLabel"
            Me.LabelForm_AlternateApproverLabel.Size = New System.Drawing.Size(101, 20)
            Me.LabelForm_AlternateApproverLabel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AlternateApproverLabel.TabIndex = 4
            Me.LabelForm_AlternateApproverLabel.Text = "Alternate Approver:"
            '
            'LabelForm_Supervisor
            '
            Me.LabelForm_Supervisor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Supervisor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Supervisor.Location = New System.Drawing.Point(119, 38)
            Me.LabelForm_Supervisor.Name = "LabelForm_Supervisor"
            Me.LabelForm_Supervisor.Size = New System.Drawing.Size(230, 20)
            Me.LabelForm_Supervisor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Supervisor.TabIndex = 3
            Me.LabelForm_Supervisor.Text = "{0}"
            '
            'LabelForm_Employee
            '
            Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Employee.Location = New System.Drawing.Point(119, 12)
            Me.LabelForm_Employee.Name = "LabelForm_Employee"
            Me.LabelForm_Employee.Size = New System.Drawing.Size(230, 20)
            Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Employee.TabIndex = 1
            Me.LabelForm_Employee.Text = "{0}"
            '
            'LabelForm_AlternateApprover
            '
            Me.LabelForm_AlternateApprover.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_AlternateApprover.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_AlternateApprover.Location = New System.Drawing.Point(119, 64)
            Me.LabelForm_AlternateApprover.Name = "LabelForm_AlternateApprover"
            Me.LabelForm_AlternateApprover.Size = New System.Drawing.Size(230, 20)
            Me.LabelForm_AlternateApprover.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_AlternateApprover.TabIndex = 5
            Me.LabelForm_AlternateApprover.Text = "{0}"
            '
            'SearchableComboBoxForm_Approver
            '
            Me.SearchableComboBoxForm_Approver.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Approver.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Approver.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Approver.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_Approver.DataSource = Nothing
            Me.SearchableComboBoxForm_Approver.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Approver.DisplayName = ""
            Me.SearchableComboBoxForm_Approver.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Approver.Location = New System.Drawing.Point(119, 90)
            Me.SearchableComboBoxForm_Approver.Name = "SearchableComboBoxForm_Approver"
            Me.SearchableComboBoxForm_Approver.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Approver.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Approver.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxForm_Approver.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Approver.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Approver.Properties.View = Me.SearchableComboBox1View
            Me.SearchableComboBoxForm_Approver.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Approver.Size = New System.Drawing.Size(230, 20)
            Me.SearchableComboBoxForm_Approver.TabIndex = 10
            '
            'SearchableComboBox1View
            '
            Me.SearchableComboBox1View.AFActiveFilterString = ""
            Me.SearchableComboBox1View.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.SearchableComboBox1View.AutoFilterLookupColumns = False
            Me.SearchableComboBox1View.AutoloadRepositoryDatasource = True
            Me.SearchableComboBox1View.DataSourceClearing = False
            Me.SearchableComboBox1View.EnableDisabledRows = False
            Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
            Me.SearchableComboBox1View.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBox1View.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.SearchableComboBox1View.OptionsBehavior.Editable = False
            Me.SearchableComboBox1View.OptionsCustomization.AllowQuickHideColumns = False
            Me.SearchableComboBox1View.OptionsNavigation.AutoFocusNewRow = True
            Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1View.OptionsSelection.MultiSelect = True
            Me.SearchableComboBox1View.OptionsView.ColumnAutoWidth = False
            Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBox1View.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.SearchableComboBox1View.RunStandardValidation = True
            '
            'CheckBoxForm_IncludeReceipts
            '
            '
            '
            '
            Me.CheckBoxForm_IncludeReceipts.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IncludeReceipts.CheckValue = 0
            Me.CheckBoxForm_IncludeReceipts.CheckValueChecked = 1
            Me.CheckBoxForm_IncludeReceipts.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IncludeReceipts.CheckValueUnchecked = 0
            Me.CheckBoxForm_IncludeReceipts.ChildControls = CType(resources.GetObject("CheckBoxForm_IncludeReceipts.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeReceipts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IncludeReceipts.Location = New System.Drawing.Point(119, 116)
            Me.CheckBoxForm_IncludeReceipts.Name = "CheckBoxForm_IncludeReceipts"
            Me.CheckBoxForm_IncludeReceipts.OldestSibling = Nothing
            Me.CheckBoxForm_IncludeReceipts.SecurityEnabled = True
            Me.CheckBoxForm_IncludeReceipts.SiblingControls = CType(resources.GetObject("CheckBoxForm_IncludeReceipts.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IncludeReceipts.Size = New System.Drawing.Size(230, 20)
            Me.CheckBoxForm_IncludeReceipts.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IncludeReceipts.TabIndex = 11
            Me.CheckBoxForm_IncludeReceipts.Text = "Include receipts in Email and Alert"
            '
            'ExpenseReportSubmitDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(361, 174)
            Me.Controls.Add(Me.CheckBoxForm_IncludeReceipts)
            Me.Controls.Add(Me.SearchableComboBoxForm_Approver)
            Me.Controls.Add(Me.LabelForm_AlternateApprover)
            Me.Controls.Add(Me.LabelForm_Employee)
            Me.Controls.Add(Me.LabelForm_Supervisor)
            Me.Controls.Add(Me.LabelForm_AlternateApproverLabel)
            Me.Controls.Add(Me.LabelForm_SupervisorLabel)
            Me.Controls.Add(Me.LabelForm_EmployeeLabel)
            Me.Controls.Add(Me.LabelForm_SelectApprover)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Submit)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExpenseReportSubmitDialog"
            Me.Text = "Expense Report"
            CType(Me.SearchableComboBoxForm_Approver.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Submit As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_SelectApprover As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EmployeeLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_SupervisorLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AlternateApproverLabel As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Supervisor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_AlternateApprover As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents SearchableComboBoxForm_Approver As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents CheckBoxForm_IncludeReceipts As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace