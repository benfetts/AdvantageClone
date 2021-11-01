<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdvantageSecuritySetupAssistantForm
    Inherits AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvantageSecuritySetupAssistantForm))
        Me.BarForm_StatusBar = New DevComponents.DotNetBar.Bar()
        Me.LabelItemStatusBar_Database = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItemStatusBar_UserName = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItemStatusBar_Time = New DevComponents.DotNetBar.LabelItem()
        Me.DotNetBarManager = New DevComponents.DotNetBar.DotNetBarManager(Me.components)
        Me.DockSite4 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite1 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite2 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite8 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite5 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite6 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite7 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite3 = New DevComponents.DotNetBar.DockSite()
        Me.ProgressBarItemStatusBar_ProgressBar = New DevComponents.DotNetBar.ProgressBarItem()
        Me.RibbonPanelFile_FilePanel.SuspendLayout()
        Me.RibbonControlForm_MainRibbon.SuspendLayout()
        CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonPanelFile_FilePanel
        '
        Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 54)
        Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 98)
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.Style.Class = ""
        Me.RibbonPanelFile_FilePanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.StyleMouseDown.Class = ""
        Me.RibbonPanelFile_FilePanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonPanelFile_FilePanel.StyleMouseOver.Class = ""
        Me.RibbonPanelFile_FilePanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'RibbonBarFilePanel_System
        '
        '
        '
        '
        Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.Class = ""
        Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.BackgroundStyle.Class = ""
        Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.TitleStyle.Class = ""
        Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.RibbonBarFilePanel_System.TitleStyleMouseOver.Class = ""
        Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'RibbonControlForm_MainRibbon
        '
        '
        '
        '
        Me.RibbonControlForm_MainRibbon.BackgroundStyle.Class = ""
        Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.RibbonControlForm_MainRibbon.CanCustomize = False
        Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(982, 154)
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
        'ButtonItemSystem_Exit
        '
        Me.ButtonItemSystem_Exit.Image = CType(resources.GetObject("ButtonItemSystem_Exit.Image"), System.Drawing.Image)
        '
        'Office2007StartButtonMainRibbon_Home
        '
        Me.Office2007StartButtonMainRibbon_Home.Enabled = False
        '
        'ButtonItemMainRibbon_Help
        '
        Me.ButtonItemMainRibbon_Help.Image = CType(resources.GetObject("ButtonItemMainRibbon_Help.Image"), System.Drawing.Image)
        '
        'ButtonItemMainRibbon_ShowAndHide
        '
        Me.ButtonItemMainRibbon_ShowAndHide.Image = CType(resources.GetObject("ButtonItemMainRibbon_ShowAndHide.Image"), System.Drawing.Image)
        '
        'TabStripForm_MDIChildren
        '
        Me.TabStripForm_MDIChildren.Size = New System.Drawing.Size(982, 20)
        '
        'BarForm_StatusBar
        '
        Me.BarForm_StatusBar.AccessibleDescription = "DotNetBar Bar (BarForm_StatusBar)"
        Me.BarForm_StatusBar.AccessibleName = "DotNetBar Bar"
        Me.BarForm_StatusBar.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar
        Me.BarForm_StatusBar.AntiAlias = True
        Me.BarForm_StatusBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar
        Me.BarForm_StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BarForm_StatusBar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle
        Me.BarForm_StatusBar.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ProgressBarItemStatusBar_ProgressBar, Me.LabelItemStatusBar_Database, Me.LabelItemStatusBar_UserName, Me.LabelItemStatusBar_Time})
        Me.BarForm_StatusBar.ItemSpacing = 3
        Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 709)
        Me.BarForm_StatusBar.Name = "BarForm_StatusBar"
        Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 19)
        Me.BarForm_StatusBar.Stretch = True
        Me.BarForm_StatusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.BarForm_StatusBar.TabIndex = 6
        Me.BarForm_StatusBar.TabStop = False
        '
        'LabelItemStatusBar_Database
        '
        Me.LabelItemStatusBar_Database.BeginGroup = True
        Me.LabelItemStatusBar_Database.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.LabelItemStatusBar_Database.Name = "LabelItemStatusBar_Database"
        Me.LabelItemStatusBar_Database.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelItemStatusBar_UserName
        '
        Me.LabelItemStatusBar_UserName.BeginGroup = True
        Me.LabelItemStatusBar_UserName.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.LabelItemStatusBar_UserName.Name = "LabelItemStatusBar_UserName"
        Me.LabelItemStatusBar_UserName.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'LabelItemStatusBar_Time
        '
        Me.LabelItemStatusBar_Time.BeginGroup = True
        Me.LabelItemStatusBar_Time.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
        Me.LabelItemStatusBar_Time.Name = "LabelItemStatusBar_Time"
        Me.LabelItemStatusBar_Time.TextAlignment = System.Drawing.StringAlignment.Center
        '
        'DotNetBarManager
        '
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.F1)
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlC)
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlA)
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlV)
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlX)
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlZ)
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.CtrlY)
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Del)
        Me.DotNetBarManager.AutoDispatchShortcuts.Add(DevComponents.DotNetBar.eShortcut.Ins)
        Me.DotNetBarManager.BottomDockSite = Me.DockSite4
        Me.DotNetBarManager.EnableFullSizeDock = False
        Me.DotNetBarManager.LeftDockSite = Me.DockSite1
        Me.DotNetBarManager.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.DotNetBarManager.ParentForm = Me
        Me.DotNetBarManager.RightDockSite = Me.DockSite2
        Me.DotNetBarManager.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.DotNetBarManager.ToolbarBottomDockSite = Me.DockSite8
        Me.DotNetBarManager.ToolbarLeftDockSite = Me.DockSite5
        Me.DotNetBarManager.ToolbarRightDockSite = Me.DockSite6
        Me.DotNetBarManager.ToolbarTopDockSite = Me.DockSite7
        Me.DotNetBarManager.TopDockSite = Me.DockSite3
        '
        'DockSite4
        '
        Me.DockSite4.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite4.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite4.Location = New System.Drawing.Point(5, 728)
        Me.DockSite4.Name = "DockSite4"
        Me.DockSite4.Size = New System.Drawing.Size(982, 0)
        Me.DockSite4.TabIndex = 10
        Me.DockSite4.TabStop = False
        '
        'DockSite1
        '
        Me.DockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite1.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite1.Location = New System.Drawing.Point(5, 175)
        Me.DockSite1.Name = "DockSite1"
        Me.DockSite1.Size = New System.Drawing.Size(0, 534)
        Me.DockSite1.TabIndex = 7
        Me.DockSite1.TabStop = False
        '
        'DockSite2
        '
        Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite2.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite2.Location = New System.Drawing.Point(987, 175)
        Me.DockSite2.Name = "DockSite2"
        Me.DockSite2.Size = New System.Drawing.Size(0, 534)
        Me.DockSite2.TabIndex = 8
        Me.DockSite2.TabStop = False
        '
        'DockSite8
        '
        Me.DockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite8.Location = New System.Drawing.Point(5, 728)
        Me.DockSite8.Name = "DockSite8"
        Me.DockSite8.Size = New System.Drawing.Size(982, 0)
        Me.DockSite8.TabIndex = 14
        Me.DockSite8.TabStop = False
        '
        'DockSite5
        '
        Me.DockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite5.Location = New System.Drawing.Point(5, 155)
        Me.DockSite5.Name = "DockSite5"
        Me.DockSite5.Size = New System.Drawing.Size(0, 573)
        Me.DockSite5.TabIndex = 11
        Me.DockSite5.TabStop = False
        '
        'DockSite6
        '
        Me.DockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite6.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite6.Location = New System.Drawing.Point(987, 155)
        Me.DockSite6.Name = "DockSite6"
        Me.DockSite6.Size = New System.Drawing.Size(0, 573)
        Me.DockSite6.TabIndex = 12
        Me.DockSite6.TabStop = False
        '
        'DockSite7
        '
        Me.DockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite7.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite7.Location = New System.Drawing.Point(5, 155)
        Me.DockSite7.Name = "DockSite7"
        Me.DockSite7.Size = New System.Drawing.Size(982, 0)
        Me.DockSite7.TabIndex = 13
        Me.DockSite7.TabStop = False
        '
        'DockSite3
        '
        Me.DockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite3.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite3.Location = New System.Drawing.Point(5, 155)
        Me.DockSite3.Name = "DockSite3"
        Me.DockSite3.Size = New System.Drawing.Size(982, 0)
        Me.DockSite3.TabIndex = 9
        Me.DockSite3.TabStop = False
        '
        'ProgressBarItemStatusBar_ProgressBar
        '
        '
        '
        '
        Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.Class = ""
        Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBarItemStatusBar_ProgressBar.ChunkGradientAngle = 0.0!
        Me.ProgressBarItemStatusBar_ProgressBar.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ProgressBarItemStatusBar_ProgressBar.Name = "ProgressBarItemStatusBar_ProgressBar"
        Me.ProgressBarItemStatusBar_ProgressBar.RecentlyUsed = False
        Me.ProgressBarItemStatusBar_ProgressBar.Stretch = True
        Me.ProgressBarItemStatusBar_ProgressBar.Visible = False
        '
        'AdvantageSecuritySetupAssistantForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 730)
        Me.Controls.Add(Me.DockSite2)
        Me.Controls.Add(Me.DockSite1)
        Me.Controls.Add(Me.BarForm_StatusBar)
        Me.Controls.Add(Me.DockSite3)
        Me.Controls.Add(Me.DockSite4)
        Me.Controls.Add(Me.DockSite5)
        Me.Controls.Add(Me.DockSite6)
        Me.Controls.Add(Me.DockSite7)
        Me.Controls.Add(Me.DockSite8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AdvantageSecuritySetupAssistantForm"
        Me.Text = "Advantage Security Setup Assistant"
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
        Me.Controls.SetChildIndex(Me.DockSite8, 0)
        Me.Controls.SetChildIndex(Me.DockSite7, 0)
        Me.Controls.SetChildIndex(Me.DockSite6, 0)
        Me.Controls.SetChildIndex(Me.DockSite5, 0)
        Me.Controls.SetChildIndex(Me.DockSite4, 0)
        Me.Controls.SetChildIndex(Me.DockSite3, 0)
        Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
        Me.Controls.SetChildIndex(Me.TabStripForm_MDIChildren, 0)
        Me.Controls.SetChildIndex(Me.DockSite1, 0)
        Me.Controls.SetChildIndex(Me.DockSite2, 0)
        Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
        Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
        Me.RibbonControlForm_MainRibbon.PerformLayout()
        CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BarForm_StatusBar As DevComponents.DotNetBar.Bar
    Friend WithEvents DotNetBarManager As DevComponents.DotNetBar.DotNetBarManager
    Friend WithEvents DockSite4 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite1 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite3 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite5 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite6 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite7 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite8 As DevComponents.DotNetBar.DockSite
    Friend WithEvents LabelItemStatusBar_UserName As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItemStatusBar_Time As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItemStatusBar_Database As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ProgressBarItemStatusBar_ProgressBar As DevComponents.DotNetBar.ProgressBarItem

End Class
