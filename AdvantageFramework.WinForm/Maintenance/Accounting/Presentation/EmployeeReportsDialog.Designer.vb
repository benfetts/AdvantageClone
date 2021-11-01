Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeReportsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeReportsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_SecondarySort = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_ReportFormats = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_PrintOptions = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonControlSecondarySort_ByEmployeeCode = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.DataGridViewForm_SelectedEmployees = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ListBoxForm_Reports = New AdvantageFramework.WinForm.Presentation.Controls.ListBox()
            Me.RadioButtonControlPrimarySort_NoOffice = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControlPrimarySort_Office = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.LabelForm_PrimarySort = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.PanelForm_SecondarySort = New System.Windows.Forms.Panel()
            Me.PanelForm_PrimarySort = New System.Windows.Forms.Panel()
            Me.LabelForm_SelectEmployees = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.ListBoxForm_Reports, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_SecondarySort.SuspendLayout()
            Me.PanelForm_PrimarySort.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(727, 380)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 17
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(646, 380)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 16
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_SecondarySort
            '
            Me.LabelForm_SecondarySort.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SecondarySort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SecondarySort.Location = New System.Drawing.Point(0, 0)
            Me.LabelForm_SecondarySort.Name = "LabelForm_SecondarySort"
            Me.LabelForm_SecondarySort.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_SecondarySort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SecondarySort.TabIndex = 8
            Me.LabelForm_SecondarySort.Text = "Secondary Sort:"
            '
            'LabelForm_ReportFormats
            '
            Me.LabelForm_ReportFormats.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_ReportFormats.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ReportFormats.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_ReportFormats.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_ReportFormats.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_ReportFormats.Name = "LabelForm_ReportFormats"
            Me.LabelForm_ReportFormats.Size = New System.Drawing.Size(303, 20)
            Me.LabelForm_ReportFormats.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ReportFormats.TabIndex = 28
            Me.LabelForm_ReportFormats.Text = "Report Formats"
            '
            'LabelForm_PrintOptions
            '
            Me.LabelForm_PrintOptions.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PrintOptions.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_PrintOptions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PrintOptions.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_PrintOptions.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_PrintOptions.Location = New System.Drawing.Point(12, 242)
            Me.LabelForm_PrintOptions.Name = "LabelForm_PrintOptions"
            Me.LabelForm_PrintOptions.Size = New System.Drawing.Size(303, 20)
            Me.LabelForm_PrintOptions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PrintOptions.TabIndex = 29
            Me.LabelForm_PrintOptions.Text = "Print Options"
            '
            'RadioButtonControlSecondarySort_ByEmployeeCode
            '
            '
            '
            '
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.Location = New System.Drawing.Point(88, 0)
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.Name = "RadioButtonControlSecondarySort_ByEmployeeCode"
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.Size = New System.Drawing.Size(215, 20)
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.TabIndex = 32
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.TabStop = False
            Me.RadioButtonControlSecondarySort_ByEmployeeCode.Text = "By Employee Code"
            '
            'RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName
            '
            '
            '
            '
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.Location = New System.Drawing.Point(88, 26)
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.Name = "RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName"
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.Size = New System.Drawing.Size(215, 20)
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.TabIndex = 33
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.TabStop = False
            Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName.Text = "By Employee Last Name, First Name"
            '
            'DataGridViewForm_SelectedEmployees
            '
            Me.DataGridViewForm_SelectedEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_SelectedEmployees.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_SelectedEmployees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_SelectedEmployees.AutoFilterLookupColumns = False
            Me.DataGridViewForm_SelectedEmployees.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_SelectedEmployees.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewForm_SelectedEmployees.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_SelectedEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_SelectedEmployees.ItemDescription = ""
            Me.DataGridViewForm_SelectedEmployees.Location = New System.Drawing.Point(321, 38)
            Me.DataGridViewForm_SelectedEmployees.MultiSelect = True
            Me.DataGridViewForm_SelectedEmployees.Name = "DataGridViewForm_SelectedEmployees"
            Me.DataGridViewForm_SelectedEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_SelectedEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_SelectedEmployees.Size = New System.Drawing.Size(481, 336)
            Me.DataGridViewForm_SelectedEmployees.TabIndex = 36
            Me.DataGridViewForm_SelectedEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_SelectedEmployees.ViewCaptionHeight = -1
            '
            'ListBoxForm_Reports
            '
            Me.ListBoxForm_Reports.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ListBox.Type.Report
            Me.ListBoxForm_Reports.DisplayMember = "Description"
            Me.ListBoxForm_Reports.ExtraListBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ListBox.ExtraListBoxItems.[Nothing]
            Me.ListBoxForm_Reports.ExtraListBoxItemDisplayText = Nothing
            Me.ListBoxForm_Reports.ExtraListBoxItemValueObject = Nothing
            Me.ListBoxForm_Reports.Location = New System.Drawing.Point(12, 38)
            Me.ListBoxForm_Reports.Name = "ListBoxForm_Reports"
            Me.ListBoxForm_Reports.Size = New System.Drawing.Size(303, 198)
            Me.ListBoxForm_Reports.TabIndex = 38
            Me.ListBoxForm_Reports.ValueMember = "Code"
            '
            'RadioButtonControlPrimarySort_NoOffice
            '
            '
            '
            '
            Me.RadioButtonControlPrimarySort_NoOffice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlPrimarySort_NoOffice.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlPrimarySort_NoOffice.Location = New System.Drawing.Point(88, 26)
            Me.RadioButtonControlPrimarySort_NoOffice.Name = "RadioButtonControlPrimarySort_NoOffice"
            Me.RadioButtonControlPrimarySort_NoOffice.Size = New System.Drawing.Size(215, 20)
            Me.RadioButtonControlPrimarySort_NoOffice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlPrimarySort_NoOffice.TabIndex = 45
            Me.RadioButtonControlPrimarySort_NoOffice.TabStop = False
            Me.RadioButtonControlPrimarySort_NoOffice.Text = "No Office"
            '
            'RadioButtonControlPrimarySort_Office
            '
            '
            '
            '
            Me.RadioButtonControlPrimarySort_Office.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControlPrimarySort_Office.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControlPrimarySort_Office.Location = New System.Drawing.Point(88, 0)
            Me.RadioButtonControlPrimarySort_Office.Name = "RadioButtonControlPrimarySort_Office"
            Me.RadioButtonControlPrimarySort_Office.Size = New System.Drawing.Size(215, 20)
            Me.RadioButtonControlPrimarySort_Office.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControlPrimarySort_Office.TabIndex = 44
            Me.RadioButtonControlPrimarySort_Office.TabStop = False
            Me.RadioButtonControlPrimarySort_Office.Text = "Office"
            '
            'LabelForm_PrimarySort
            '
            Me.LabelForm_PrimarySort.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PrimarySort.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PrimarySort.Location = New System.Drawing.Point(-1, 0)
            Me.LabelForm_PrimarySort.Name = "LabelForm_PrimarySort"
            Me.LabelForm_PrimarySort.Size = New System.Drawing.Size(82, 20)
            Me.LabelForm_PrimarySort.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PrimarySort.TabIndex = 43
            Me.LabelForm_PrimarySort.Text = "Primary Sort:"
            '
            'PanelForm_SecondarySort
            '
            Me.PanelForm_SecondarySort.BackColor = System.Drawing.Color.White
            Me.PanelForm_SecondarySort.Controls.Add(Me.LabelForm_SecondarySort)
            Me.PanelForm_SecondarySort.Controls.Add(Me.RadioButtonControlSecondarySort_ByEmployeeCode)
            Me.PanelForm_SecondarySort.Controls.Add(Me.RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName)
            Me.PanelForm_SecondarySort.Location = New System.Drawing.Point(12, 324)
            Me.PanelForm_SecondarySort.Name = "PanelForm_SecondarySort"
            Me.PanelForm_SecondarySort.Size = New System.Drawing.Size(303, 50)
            Me.PanelForm_SecondarySort.TabIndex = 46
            '
            'PanelForm_PrimarySort
            '
            Me.PanelForm_PrimarySort.BackColor = System.Drawing.Color.White
            Me.PanelForm_PrimarySort.Controls.Add(Me.LabelForm_PrimarySort)
            Me.PanelForm_PrimarySort.Controls.Add(Me.RadioButtonControlPrimarySort_Office)
            Me.PanelForm_PrimarySort.Controls.Add(Me.RadioButtonControlPrimarySort_NoOffice)
            Me.PanelForm_PrimarySort.Location = New System.Drawing.Point(12, 268)
            Me.PanelForm_PrimarySort.Name = "PanelForm_PrimarySort"
            Me.PanelForm_PrimarySort.Size = New System.Drawing.Size(303, 50)
            Me.PanelForm_PrimarySort.TabIndex = 47
            '
            'LabelForm_SelectEmployees
            '
            Me.LabelForm_SelectEmployees.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_SelectEmployees.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderBottomWidth = 1
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectEmployees.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.LabelForm_SelectEmployees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SelectEmployees.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelForm_SelectEmployees.ForeColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(31, Byte), Integer), CType(CType(53, Byte), Integer))
            Me.LabelForm_SelectEmployees.Location = New System.Drawing.Point(321, 12)
            Me.LabelForm_SelectEmployees.Name = "LabelForm_SelectEmployees"
            Me.LabelForm_SelectEmployees.Size = New System.Drawing.Size(481, 20)
            Me.LabelForm_SelectEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SelectEmployees.TabIndex = 52
            Me.LabelForm_SelectEmployees.Text = "Select Employee(s)"
            '
            'EmployeeReportsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(814, 412)
            Me.Controls.Add(Me.LabelForm_SelectEmployees)
            Me.Controls.Add(Me.ListBoxForm_Reports)
            Me.Controls.Add(Me.PanelForm_PrimarySort)
            Me.Controls.Add(Me.DataGridViewForm_SelectedEmployees)
            Me.Controls.Add(Me.LabelForm_PrintOptions)
            Me.Controls.Add(Me.LabelForm_ReportFormats)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.PanelForm_SecondarySort)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.DoubleBuffered = True
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeReportsDialog"
            Me.Text = "Employee Reports"
            CType(Me.ListBoxForm_Reports, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_SecondarySort.ResumeLayout(False)
            Me.PanelForm_PrimarySort.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_SecondarySort As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ReportFormats As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_PrintOptions As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonControlSecondarySort_ByEmployeeCode As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlSecondarySort_ByEmployeeLastNameFirstName As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DataGridViewForm_SelectedEmployees As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ListBoxForm_Reports As AdvantageFramework.WinForm.Presentation.Controls.ListBox
        Friend WithEvents RadioButtonControlPrimarySort_NoOffice As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonControlPrimarySort_Office As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents LabelForm_PrimarySort As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents PanelForm_SecondarySort As System.Windows.Forms.Panel
        Friend WithEvents PanelForm_PrimarySort As System.Windows.Forms.Panel
        Friend WithEvents LabelForm_SelectEmployees As AdvantageFramework.WinForm.Presentation.Controls.Label

    End Class

End Namespace