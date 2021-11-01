Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleTaskEditDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectScheduleTaskEditDialog))
            Me.JobComponentTaskControlForm_Task = New AdvantageFramework.WinForm.Presentation.Controls.JobComponentTaskControl()
            Me.RibbonBarOptions_Employees = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemEmployees_Details = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Save = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_MarkCompleted = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_AddTime = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_NewAlert = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_NewAssignment = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemActions_Print = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemEmployees_ShowQuotedHours = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(795, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Employees)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(795, 95)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarFilePanel_System, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Actions, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Employees, 0)
            '
            'RibbonBarFilePanel_System
            '
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
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
            Me.ButtonItemSystem_Close.Image = AdvantageFramework.My.Resources.ExitImage
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Controls.Add(Me.JobComponentTaskControlForm_Task)
            Me.PanelForm_Form.Size = New System.Drawing.Size(795, 514)
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 669)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(795, 18)
            '
            'JobComponentTaskControlForm_Task
            '
            Me.JobComponentTaskControlForm_Task.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.JobComponentTaskControlForm_Task.Location = New System.Drawing.Point(3, 6)
            Me.JobComponentTaskControlForm_Task.Name = "JobComponentTaskControlForm_Task"
            Me.JobComponentTaskControlForm_Task.Size = New System.Drawing.Size(789, 505)
            Me.JobComponentTaskControlForm_Task.TabIndex = 0
            '
            'RibbonBarOptions_Employees
            '
            Me.RibbonBarOptions_Employees.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Employees.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employees.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employees.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Employees.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Employees.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemEmployees_Details, Me.ButtonItemEmployees_ShowQuotedHours})
            Me.RibbonBarOptions_Employees.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Employees.Location = New System.Drawing.Point(486, 0)
            Me.RibbonBarOptions_Employees.Name = "RibbonBarOptions_Employees"
            Me.RibbonBarOptions_Employees.Size = New System.Drawing.Size(168, 92)
            Me.RibbonBarOptions_Employees.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Employees.TabIndex = 2
            Me.RibbonBarOptions_Employees.Text = "Employees"
            '
            '
            '
            Me.RibbonBarOptions_Employees.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Employees.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Employees.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemEmployees_Details
            '
            Me.ButtonItemEmployees_Details.BeginGroup = True
            Me.ButtonItemEmployees_Details.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployees_Details.Name = "ButtonItemEmployees_Details"
            Me.ButtonItemEmployees_Details.RibbonWordWrap = False
            Me.ButtonItemEmployees_Details.SecurityEnabled = True
            Me.ButtonItemEmployees_Details.SubItemsExpandWidth = 14
            Me.ButtonItemEmployees_Details.Text = "Details"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Save, Me.ButtonItemActions_MarkCompleted, Me.ButtonItemActions_AddTime, Me.ButtonItemActions_NewAlert, Me.ButtonItemActions_NewAssignment, Me.ButtonItemActions_Print})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(383, 92)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 3
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
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SecurityEnabled = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_MarkCompleted
            '
            Me.ButtonItemActions_MarkCompleted.BeginGroup = True
            Me.ButtonItemActions_MarkCompleted.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_MarkCompleted.Name = "ButtonItemActions_MarkCompleted"
            Me.ButtonItemActions_MarkCompleted.RibbonWordWrap = False
            Me.ButtonItemActions_MarkCompleted.SecurityEnabled = True
            Me.ButtonItemActions_MarkCompleted.SubItemsExpandWidth = 14
            Me.ButtonItemActions_MarkCompleted.Text = "Mark Completed"
            '
            'ButtonItemActions_AddTime
            '
            Me.ButtonItemActions_AddTime.BeginGroup = True
            Me.ButtonItemActions_AddTime.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_AddTime.Name = "ButtonItemActions_AddTime"
            Me.ButtonItemActions_AddTime.RibbonWordWrap = False
            Me.ButtonItemActions_AddTime.SecurityEnabled = True
            Me.ButtonItemActions_AddTime.SubItemsExpandWidth = 14
            Me.ButtonItemActions_AddTime.Text = "Add Time"
            '
            'ButtonItemActions_NewAlert
            '
            Me.ButtonItemActions_NewAlert.BeginGroup = True
            Me.ButtonItemActions_NewAlert.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_NewAlert.Name = "ButtonItemActions_NewAlert"
            Me.ButtonItemActions_NewAlert.RibbonWordWrap = False
            Me.ButtonItemActions_NewAlert.SecurityEnabled = True
            Me.ButtonItemActions_NewAlert.SubItemsExpandWidth = 14
            Me.ButtonItemActions_NewAlert.Text = "New Alert"
            '
            'ButtonItemActions_NewAssignment
            '
            Me.ButtonItemActions_NewAssignment.BeginGroup = True
            Me.ButtonItemActions_NewAssignment.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_NewAssignment.Name = "ButtonItemActions_NewAssignment"
            Me.ButtonItemActions_NewAssignment.RibbonWordWrap = False
            Me.ButtonItemActions_NewAssignment.SecurityEnabled = True
            Me.ButtonItemActions_NewAssignment.SubItemsExpandWidth = 14
            Me.ButtonItemActions_NewAssignment.Text = "New Assignment"
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
            'ButtonItemEmployees_ShowQuotedHours
            '
            Me.ButtonItemEmployees_ShowQuotedHours.AutoCheckOnClick = True
            Me.ButtonItemEmployees_ShowQuotedHours.BeginGroup = True
            Me.ButtonItemEmployees_ShowQuotedHours.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemEmployees_ShowQuotedHours.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemEmployees_ShowQuotedHours.Name = "ButtonItemEmployees_ShowQuotedHours"
            Me.ButtonItemEmployees_ShowQuotedHours.RibbonWordWrap = False
            Me.ButtonItemEmployees_ShowQuotedHours.Stretch = True
            Me.ButtonItemEmployees_ShowQuotedHours.SubItemsExpandWidth = 14
            Me.ButtonItemEmployees_ShowQuotedHours.Text = "Show Quoted Hours"
            '
            'ProjectScheduleTaskEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(805, 689)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProjectScheduleTaskEditDialog"
            Me.Text = "Task Details"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents JobComponentTaskControlForm_Task As AdvantageFramework.WinForm.Presentation.Controls.JobComponentTaskControl
        Friend WithEvents RibbonBarOptions_Employees As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemEmployees_Details As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Save As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_MarkCompleted As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_AddTime As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_NewAlert As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_NewAssignment As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemActions_Print As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemEmployees_ShowQuotedHours As DevComponents.DotNetBar.ButtonItem

    End Class

End Namespace