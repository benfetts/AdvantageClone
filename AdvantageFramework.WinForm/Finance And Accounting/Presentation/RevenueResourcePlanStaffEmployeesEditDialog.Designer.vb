Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RevenueResourcePlanStaffEmployeesEditDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RevenueResourcePlanStaffEmployeesEditDialog))
            Me.DataGridViewForm_AvailableEmployees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.DataGridViewForm_Employees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ButtonForm_AddEmployees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_DeleteEmployees = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_DeleteEmployees)
            Me.PanelForm_Form.Controls.Add(Me.ButtonForm_AddEmployees)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_Employees)
            Me.PanelForm_Form.Controls.Add(Me.DataGridViewForm_AvailableEmployees)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1045, 391)
            Me.PanelForm_Form.TabIndex = 0
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1045, 154)
            Me.RibbonControlForm_MainRibbon.SystemText.MaximizeRibbonText = "&Maximize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatAddItemText = "&Add to Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar..."
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogAddButton = "&Add >>"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCancelButton = "Cancel"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCaption = "Customize Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogCategoriesLabel = "&Choose commands from:"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogOkButton = "OK"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatDialogRemoveButton = "&Remove"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon"
            Me.RibbonControlForm_MainRibbon.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar"
            Me.RibbonControlForm_MainRibbon.Controls.SetChildIndex(Me.RibbonPanelFile_FilePanel, 0)
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1045, 94)
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderColor2 = System.Drawing.Color.DarkGray
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.RibbonBarFilePanel_System.BackgroundStyle.BorderRightWidth = 2
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 92)
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.Image = CType(resources.GetObject("ButtonItemSystem_Close.Image"), System.Drawing.Image)
            '
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 546)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1045, 18)
            '
            'DataGridViewForm_AvailableEmployees
            '
            Me.DataGridViewForm_AvailableEmployees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_AvailableEmployees.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_AvailableEmployees.AutoUpdateViewCaption = True
            Me.DataGridViewForm_AvailableEmployees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_AvailableEmployees.ItemDescription = "Employee(s)"
            Me.DataGridViewForm_AvailableEmployees.Location = New System.Drawing.Point(14, 8)
            Me.DataGridViewForm_AvailableEmployees.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewForm_AvailableEmployees.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_AvailableEmployees.ModifyGridRowHeight = False
            Me.DataGridViewForm_AvailableEmployees.MultiSelect = True
            Me.DataGridViewForm_AvailableEmployees.Name = "DataGridViewForm_AvailableEmployees"
            Me.DataGridViewForm_AvailableEmployees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_AvailableEmployees.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_AvailableEmployees.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_AvailableEmployees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_AvailableEmployees.Size = New System.Drawing.Size(426, 375)
            Me.DataGridViewForm_AvailableEmployees.TabIndex = 37
            Me.DataGridViewForm_AvailableEmployees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_AvailableEmployees.ViewCaptionHeight = -1
            '
            'DataGridViewForm_Employees
            '
            Me.DataGridViewForm_Employees.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Employees.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Employees.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Employees.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Employees.ItemDescription = "Employee(s)"
            Me.DataGridViewForm_Employees.Location = New System.Drawing.Point(531, 8)
            Me.DataGridViewForm_Employees.Margin = New System.Windows.Forms.Padding(5)
            Me.DataGridViewForm_Employees.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_Employees.ModifyGridRowHeight = False
            Me.DataGridViewForm_Employees.MultiSelect = True
            Me.DataGridViewForm_Employees.Name = "DataGridViewForm_Employees"
            Me.DataGridViewForm_Employees.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Employees.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_Employees.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_Employees.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Employees.Size = New System.Drawing.Size(419, 375)
            Me.DataGridViewForm_Employees.TabIndex = 38
            Me.DataGridViewForm_Employees.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Employees.ViewCaptionHeight = -1
            '
            'ButtonForm_AddEmployees
            '
            Me.ButtonForm_AddEmployees.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_AddEmployees.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_AddEmployees.Location = New System.Drawing.Point(448, 8)
            Me.ButtonForm_AddEmployees.Name = "ButtonForm_AddEmployees"
            Me.ButtonForm_AddEmployees.SecurityEnabled = True
            Me.ButtonForm_AddEmployees.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_AddEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_AddEmployees.TabIndex = 39
            Me.ButtonForm_AddEmployees.Text = "-->"
            '
            'ButtonForm_DeleteEmployees
            '
            Me.ButtonForm_DeleteEmployees.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_DeleteEmployees.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_DeleteEmployees.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_DeleteEmployees.Location = New System.Drawing.Point(958, 8)
            Me.ButtonForm_DeleteEmployees.Name = "ButtonForm_DeleteEmployees"
            Me.ButtonForm_DeleteEmployees.SecurityEnabled = True
            Me.ButtonForm_DeleteEmployees.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_DeleteEmployees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_DeleteEmployees.TabIndex = 40
            Me.ButtonForm_DeleteEmployees.Text = "X"
            '
            'RevenueResourcePlanStaffEmployeesEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1055, 566)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "RevenueResourcePlanStaffEmployeesEditDialog"
            Me.Text = "Staff Employees"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewForm_AvailableEmployees As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_DeleteEmployees As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_AddEmployees As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_Employees As WinForm.MVC.Presentation.Controls.DataGridView
    End Class

End Namespace