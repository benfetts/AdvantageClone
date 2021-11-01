Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RevenueResourcePlanStaffManageForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevenueResourcePlanStaffManageForm))
            Me.RibbonBarFilePanel_Actions = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemActions_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.DataGridViewForm_Staff = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarFilePanel_Employees = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemEmployees_Manage = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployees_AddAltEmployee = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployees_UpdateAltEmployee = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Clients = New DevComponents.DotNetBar.RibbonBar()
            Me.ButtonItemClients_Assignments = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarFilePanel_Actions
            '
            Me.RibbonBarFilePanel_Actions.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Actions.DragDropSupport = True
            Me.RibbonBarFilePanel_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Delete, Me.ButtonItemActions_Refresh})
            Me.RibbonBarFilePanel_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarFilePanel_Actions.Name = "RibbonBarFilePanel_Actions"
            Me.RibbonBarFilePanel_Actions.Size = New System.Drawing.Size(118, 98)
            Me.RibbonBarFilePanel_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Actions.TabIndex = 1
            Me.RibbonBarFilePanel_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SecurityEnabled = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'DataGridViewForm_Staff
            '
            Me.DataGridViewForm_Staff.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Staff.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Staff.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Staff.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Staff.ItemDescription = "Staff(s)"
            Me.DataGridViewForm_Staff.Location = New System.Drawing.Point(14, 8)
            Me.DataGridViewForm_Staff.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewForm_Staff.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Staff.ModifyGridRowHeight = False
            Me.DataGridViewForm_Staff.MultiSelect = False
            Me.DataGridViewForm_Staff.Name = "DataGridViewForm_Staff"
            Me.DataGridViewForm_Staff.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Staff.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Staff.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Staff.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Staff.Size = New System.Drawing.Size(937, 486)
            Me.DataGridViewForm_Staff.TabIndex = 37
            Me.DataGridViewForm_Staff.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Staff.ViewCaptionHeight = -1
            '
            'RibbonBarFilePanel_Employees
            '
            Me.RibbonBarFilePanel_Employees.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarFilePanel_Employees.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Employees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Employees.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_Employees.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_Employees.DragDropSupport = True
            Me.RibbonBarFilePanel_Employees.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFilePanel_Employees.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployees_Manage, Me.ButtonItemEmployees_AddAltEmployee, Me.ButtonItemEmployees_UpdateAltEmployee})
            Me.RibbonBarFilePanel_Employees.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_Employees.Location = New System.Drawing.Point(118, 0)
            Me.RibbonBarFilePanel_Employees.MinimumSize = New System.Drawing.Size(75, 92)
            Me.RibbonBarFilePanel_Employees.Name = "RibbonBarFilePanel_Employees"
            Me.RibbonBarFilePanel_Employees.Size = New System.Drawing.Size(202, 98)
            Me.RibbonBarFilePanel_Employees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_Employees.TabIndex = 2
            Me.RibbonBarFilePanel_Employees.Text = "Employees"
            '
            '
            '
            Me.RibbonBarFilePanel_Employees.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_Employees.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_Employees.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemEmployees_Manage
            '
            Me.ButtonItemEmployees_Manage.BeginGroup = True
            Me.ButtonItemEmployees_Manage.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployees_Manage.Name = "ButtonItemEmployees_Manage"
            Me.ButtonItemEmployees_Manage.RibbonWordWrap = False
            Me.ButtonItemEmployees_Manage.SecurityEnabled = True
            Me.ButtonItemEmployees_Manage.SubItemsExpandWidth = 14
            Me.ButtonItemEmployees_Manage.Text = "Manage"
            '
            'ButtonItemEmployees_AddAltEmployee
            '
            Me.ButtonItemEmployees_AddAltEmployee.BeginGroup = True
            Me.ButtonItemEmployees_AddAltEmployee.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployees_AddAltEmployee.Name = "ButtonItemEmployees_AddAltEmployee"
            Me.ButtonItemEmployees_AddAltEmployee.RibbonWordWrap = False
            Me.ButtonItemEmployees_AddAltEmployee.SecurityEnabled = True
            Me.ButtonItemEmployees_AddAltEmployee.SubItemsExpandWidth = 14
            Me.ButtonItemEmployees_AddAltEmployee.Text = "Add Alt " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Employee"
            '
            'ButtonItemEmployees_UpdateAltEmployee
            '
            Me.ButtonItemEmployees_UpdateAltEmployee.BeginGroup = True
            Me.ButtonItemEmployees_UpdateAltEmployee.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployees_UpdateAltEmployee.Name = "ButtonItemEmployees_UpdateAltEmployee"
            Me.ButtonItemEmployees_UpdateAltEmployee.RibbonWordWrap = False
            Me.ButtonItemEmployees_UpdateAltEmployee.SecurityEnabled = True
            Me.ButtonItemEmployees_UpdateAltEmployee.SubItemsExpandWidth = 14
            Me.ButtonItemEmployees_UpdateAltEmployee.Text = "Update Alt " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Employee"
            '
            'RibbonBarOptions_Clients
            '
            Me.RibbonBarOptions_Clients.AutoOverflowEnabled = True
            '
            '
            '
            Me.RibbonBarOptions_Clients.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Clients.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Clients.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Clients.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Clients.DragDropSupport = True
            Me.RibbonBarOptions_Clients.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemClients_Assignments})
            Me.RibbonBarOptions_Clients.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Clients.Location = New System.Drawing.Point(320, 0)
            Me.RibbonBarOptions_Clients.Name = "RibbonBarOptions_Clients"
            Me.RibbonBarOptions_Clients.Size = New System.Drawing.Size(93, 98)
            Me.RibbonBarOptions_Clients.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Clients.TabIndex = 3
            Me.RibbonBarOptions_Clients.Text = "Clients"
            '
            '
            '
            Me.RibbonBarOptions_Clients.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Clients.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Clients.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemClients_Assignments
            '
            Me.ButtonItemClients_Assignments.BeginGroup = True
            Me.ButtonItemClients_Assignments.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClients_Assignments.Name = "ButtonItemClients_Assignments"
            Me.ButtonItemClients_Assignments.RibbonWordWrap = False
            Me.ButtonItemClients_Assignments.SecurityEnabled = True
            Me.ButtonItemClients_Assignments.SubItemsExpandWidth = 14
            Me.ButtonItemClients_Assignments.Text = "Assignments"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Clients)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarFilePanel_Employees)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarFilePanel_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(40, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(782, 98)
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
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'RevenueResourcePlanStaffManageForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(975, 508)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_Staff)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RevenueResourcePlanStaffManageForm"
            Me.Text = "Revenue & Resource Plan Staff"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarFilePanel_Actions As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents DataGridViewForm_Staff As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Delete As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Clients As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents RibbonBarFilePanel_Employees As DevComponents.DotNetBar.RibbonBar
        Friend WithEvents ButtonItemEmployees_Manage As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployees_AddAltEmployee As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployees_UpdateAltEmployee As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemClients_Assignments As WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace