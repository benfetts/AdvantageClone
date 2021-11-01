Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeTimeForecastEmployeesDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeTimeForecastEmployeesDialog))
            Me.LabelForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_Office = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewForm_AvailableEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_CurrentEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_AddEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_RemoveEmployee = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_AddAllEmployees = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'LabelForm_Office
            '
            Me.LabelForm_Office.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Office.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Office.Name = "LabelForm_Office"
            Me.LabelForm_Office.Size = New System.Drawing.Size(39, 20)
            Me.LabelForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Office.TabIndex = 0
            Me.LabelForm_Office.Text = "Office:"
            '
            'ComboBoxForm_Office
            '
            Me.ComboBoxForm_Office.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_Office.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_Office.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_Office.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_Office.AutoFindItemInDataSource = False
            Me.ComboBoxForm_Office.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_Office.BookmarkingEnabled = False
            Me.ComboBoxForm_Office.ClientCode = ""
            Me.ComboBoxForm_Office.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Office
            Me.ComboBoxForm_Office.DisableMouseWheel = False
            Me.ComboBoxForm_Office.DisplayMember = "Name"
            Me.ComboBoxForm_Office.DisplayName = ""
            Me.ComboBoxForm_Office.DivisionCode = ""
            Me.ComboBoxForm_Office.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_Office.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxForm_Office.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_Office.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_Office.FocusHighlightEnabled = True
            Me.ComboBoxForm_Office.FormattingEnabled = True
            Me.ComboBoxForm_Office.ItemHeight = 14
            Me.ComboBoxForm_Office.Location = New System.Drawing.Point(57, 12)
            Me.ComboBoxForm_Office.Name = "ComboBoxForm_Office"
            Me.ComboBoxForm_Office.ReadOnly = False
            Me.ComboBoxForm_Office.SecurityEnabled = True
            Me.ComboBoxForm_Office.Size = New System.Drawing.Size(723, 20)
            Me.ComboBoxForm_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_Office.TabIndex = 1
            Me.ComboBoxForm_Office.TabOnEnter = True
            Me.ComboBoxForm_Office.ValueMember = "Code"
            Me.ComboBoxForm_Office.WatermarkText = "Select Office"
            '
            'DataGridViewForm_AvailableEmployees
            '
            Me.DataGridViewForm_AvailableEmployees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_AvailableEmployees.AllowDragAndDrop = False
            Me.DataGridViewForm_AvailableEmployees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_AvailableEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AvailableEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_AvailableEmployees.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_AvailableEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewForm_AvailableEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_AvailableEmployees.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AvailableEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_AvailableEmployees.DataSource = Nothing
            Me.DataGridViewForm_AvailableEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_AvailableEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AvailableEmployees.ItemDescription = "Available Employee(s)"
            Me.DataGridViewForm_AvailableEmployees.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_AvailableEmployees.MultiSelect = True
            Me.DataGridViewForm_AvailableEmployees.Name = "DataGridViewForm_AvailableEmployees"
            Me.DataGridViewForm_AvailableEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableEmployees.RunStandardValidation = True
            Me.DataGridViewForm_AvailableEmployees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_AvailableEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AvailableEmployees.Size = New System.Drawing.Size(300, 430)
            Me.DataGridViewForm_AvailableEmployees.TabIndex = 2
            Me.DataGridViewForm_AvailableEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableEmployees.ViewCaptionHeight = -1
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(705, 471)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 7
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_CurrentEmployees
            '
            Me.DataGridViewForm_CurrentEmployees.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_CurrentEmployees.AllowDragAndDrop = False
            Me.DataGridViewForm_CurrentEmployees.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_CurrentEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_CurrentEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_CurrentEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_CurrentEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewForm_CurrentEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_CurrentEmployees.AutoUpdateViewCaption = True
            Me.DataGridViewForm_CurrentEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_CurrentEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_CurrentEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_CurrentEmployees.ItemDescription = "Current Employee(s)"
            Me.DataGridViewForm_CurrentEmployees.Location = New System.Drawing.Point(399, 38)
            Me.DataGridViewForm_CurrentEmployees.MultiSelect = True
            Me.DataGridViewForm_CurrentEmployees.Name = "DataGridViewForm_CurrentEmployees"
            Me.DataGridViewForm_CurrentEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_CurrentEmployees.RunStandardValidation = True
            Me.DataGridViewForm_CurrentEmployees.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_CurrentEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_CurrentEmployees.Size = New System.Drawing.Size(300, 430)
            Me.DataGridViewForm_CurrentEmployees.TabIndex = 5
            Me.DataGridViewForm_CurrentEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_CurrentEmployees.ViewCaptionHeight = -1
            '
            'ButtonForm_AddEmployee
            '
            Me.ButtonForm_AddEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddEmployee.Location = New System.Drawing.Point(318, 38)
            Me.ButtonForm_AddEmployee.Name = "ButtonForm_AddEmployee"
            Me.ButtonForm_AddEmployee.SecurityEnabled = True
            Me.ButtonForm_AddEmployee.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddEmployee.TabIndex = 3
            Me.ButtonForm_AddEmployee.Text = ">"
            '
            'ButtonForm_RemoveEmployee
            '
            Me.ButtonForm_RemoveEmployee.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_RemoveEmployee.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_RemoveEmployee.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_RemoveEmployee.Location = New System.Drawing.Point(705, 38)
            Me.ButtonForm_RemoveEmployee.Name = "ButtonForm_RemoveEmployee"
            Me.ButtonForm_RemoveEmployee.SecurityEnabled = True
            Me.ButtonForm_RemoveEmployee.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_RemoveEmployee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_RemoveEmployee.TabIndex = 6
            Me.ButtonForm_RemoveEmployee.Text = "X"
            '
            'ButtonForm_AddAllEmployees
            '
            Me.ButtonForm_AddAllEmployees.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddAllEmployees.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddAllEmployees.Location = New System.Drawing.Point(318, 64)
            Me.ButtonForm_AddAllEmployees.Name = "ButtonForm_AddAllEmployees"
            Me.ButtonForm_AddAllEmployees.SecurityEnabled = True
            Me.ButtonForm_AddAllEmployees.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddAllEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddAllEmployees.TabIndex = 4
            Me.ButtonForm_AddAllEmployees.Text = ">>"
            '
            'EmployeeTimeForecastEmployeesDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(792, 503)
            Me.Controls.Add(Me.ButtonForm_AddAllEmployees)
            Me.Controls.Add(Me.ButtonForm_AddEmployee)
            Me.Controls.Add(Me.ButtonForm_RemoveEmployee)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.DataGridViewForm_AvailableEmployees)
            Me.Controls.Add(Me.LabelForm_Office)
            Me.Controls.Add(Me.ComboBoxForm_Office)
            Me.Controls.Add(Me.DataGridViewForm_CurrentEmployees)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeTimeForecastEmployeesDialog"
            Me.Text = "Add Employee Time Forecast Employees"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_Office As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_Office As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewForm_AvailableEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_CurrentEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_AddEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_RemoveEmployee As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddAllEmployees As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace