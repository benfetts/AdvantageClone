<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InternalEmailCleanupUtilityForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InternalEmailCleanupUtilityForm))
        Me.SuperTabControlHome_Menu = New DevComponents.DotNetBar.SuperTabControl()
        Me.DotNetBarManager = New DevComponents.DotNetBar.DotNetBarManager(Me.components)
        Me.DockSite4 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite1 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite2 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite8 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite5 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite6 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite7 = New DevComponents.DotNetBar.DockSite()
        Me.DockSite3 = New DevComponents.DotNetBar.DockSite()
        Me.RibbonPanelFile_FilePanel.SuspendLayout()
        Me.RibbonControlForm_MainRibbon.SuspendLayout()
        CType(Me.SuperTabControlHome_Menu, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonPanelFile_FilePanel
        '
        Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 54)
        Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(916, 98)
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
        Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(916, 154)
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
        Me.Office2007StartButtonMainRibbon_Home.BackstageTab = Me.SuperTabControlHome_Menu
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
        Me.TabStripForm_MDIChildren.Size = New System.Drawing.Size(916, 20)
        '
        'SuperTabControlHome_Menu
        '
        Me.SuperTabControlHome_Menu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        '
        '
        '
        Me.SuperTabControlHome_Menu.ControlBox.CloseBox.Name = ""
        '
        '
        '
        Me.SuperTabControlHome_Menu.ControlBox.MenuBox.Name = ""
        Me.SuperTabControlHome_Menu.ControlBox.Name = ""
        Me.SuperTabControlHome_Menu.ControlBox.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.SuperTabControlHome_Menu.ControlBox.MenuBox, Me.SuperTabControlHome_Menu.ControlBox.CloseBox})
        Me.SuperTabControlHome_Menu.ControlBox.Visible = False
        Me.SuperTabControlHome_Menu.ItemPadding.Left = 6
        Me.SuperTabControlHome_Menu.ItemPadding.Right = 4
        Me.SuperTabControlHome_Menu.ItemPadding.Top = 4
        Me.SuperTabControlHome_Menu.Location = New System.Drawing.Point(5, 54)
        Me.SuperTabControlHome_Menu.Name = "SuperTabControlHome_Menu"
        Me.SuperTabControlHome_Menu.ReorderTabsEnabled = False
        Me.SuperTabControlHome_Menu.SelectedTabFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.SuperTabControlHome_Menu.SelectedTabIndex = 0
        Me.SuperTabControlHome_Menu.Size = New System.Drawing.Size(916, 451)
        Me.SuperTabControlHome_Menu.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Left
        Me.SuperTabControlHome_Menu.TabFont = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SuperTabControlHome_Menu.TabHorizontalSpacing = 16
        Me.SuperTabControlHome_Menu.TabIndex = 4
        Me.SuperTabControlHome_Menu.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue
        Me.SuperTabControlHome_Menu.TabVerticalSpacing = 8
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
        Me.DotNetBarManager.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003
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
        Me.DockSite4.Location = New System.Drawing.Point(5, 508)
        Me.DockSite4.Name = "DockSite4"
        Me.DockSite4.Size = New System.Drawing.Size(916, 0)
        Me.DockSite4.TabIndex = 8
        Me.DockSite4.TabStop = False
        '
        'DockSite1
        '
        Me.DockSite1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite1.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite1.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite1.Location = New System.Drawing.Point(5, 175)
        Me.DockSite1.Name = "DockSite1"
        Me.DockSite1.Size = New System.Drawing.Size(0, 333)
        Me.DockSite1.TabIndex = 5
        Me.DockSite1.TabStop = False
        '
        'DockSite2
        '
        Me.DockSite2.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite2.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite2.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite2.Location = New System.Drawing.Point(921, 175)
        Me.DockSite2.Name = "DockSite2"
        Me.DockSite2.Size = New System.Drawing.Size(0, 333)
        Me.DockSite2.TabIndex = 6
        Me.DockSite2.TabStop = False
        '
        'DockSite8
        '
        Me.DockSite8.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite8.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DockSite8.Location = New System.Drawing.Point(5, 508)
        Me.DockSite8.Name = "DockSite8"
        Me.DockSite8.Size = New System.Drawing.Size(916, 0)
        Me.DockSite8.TabIndex = 12
        Me.DockSite8.TabStop = False
        '
        'DockSite5
        '
        Me.DockSite5.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite5.Dock = System.Windows.Forms.DockStyle.Left
        Me.DockSite5.Location = New System.Drawing.Point(5, 1)
        Me.DockSite5.Name = "DockSite5"
        Me.DockSite5.Size = New System.Drawing.Size(0, 507)
        Me.DockSite5.TabIndex = 9
        Me.DockSite5.TabStop = False
        '
        'DockSite6
        '
        Me.DockSite6.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite6.Dock = System.Windows.Forms.DockStyle.Right
        Me.DockSite6.Location = New System.Drawing.Point(921, 1)
        Me.DockSite6.Name = "DockSite6"
        Me.DockSite6.Size = New System.Drawing.Size(0, 507)
        Me.DockSite6.TabIndex = 10
        Me.DockSite6.TabStop = False
        '
        'DockSite7
        '
        Me.DockSite7.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite7.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite7.Location = New System.Drawing.Point(5, 1)
        Me.DockSite7.Name = "DockSite7"
        Me.DockSite7.Size = New System.Drawing.Size(916, 0)
        Me.DockSite7.TabIndex = 11
        Me.DockSite7.TabStop = False
        '
        'DockSite3
        '
        Me.DockSite3.AccessibleRole = System.Windows.Forms.AccessibleRole.Window
        Me.DockSite3.Dock = System.Windows.Forms.DockStyle.Top
        Me.DockSite3.DocumentDockContainer = New DevComponents.DotNetBar.DocumentDockContainer()
        Me.DockSite3.Location = New System.Drawing.Point(5, 1)
        Me.DockSite3.Name = "DockSite3"
        Me.DockSite3.Size = New System.Drawing.Size(916, 0)
        Me.DockSite3.TabIndex = 7
        Me.DockSite3.TabStop = False
        '
        'InternalEmailCleanupUtilityForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 510)
        Me.Controls.Add(Me.SuperTabControlHome_Menu)
        Me.Controls.Add(Me.DockSite2)
        Me.Controls.Add(Me.DockSite1)
        Me.Controls.Add(Me.DockSite3)
        Me.Controls.Add(Me.DockSite4)
        Me.Controls.Add(Me.DockSite5)
        Me.Controls.Add(Me.DockSite6)
        Me.Controls.Add(Me.DockSite7)
        Me.Controls.Add(Me.DockSite8)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(0, 0)
        Me.Name = "InternalEmailCleanupUtilityForm"
        Me.Text = "Email Cleanup Utility"
        Me.Controls.SetChildIndex(Me.DockSite8, 0)
        Me.Controls.SetChildIndex(Me.DockSite7, 0)
        Me.Controls.SetChildIndex(Me.DockSite6, 0)
        Me.Controls.SetChildIndex(Me.DockSite5, 0)
        Me.Controls.SetChildIndex(Me.DockSite4, 0)
        Me.Controls.SetChildIndex(Me.DockSite3, 0)
        Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
        Me.Controls.SetChildIndex(Me.TabStripForm_MDIChildren, 0)
        Me.Controls.SetChildIndex(Me.DockSite1, 0)
        Me.Controls.SetChildIndex(Me.DockSite2, 0)
        Me.Controls.SetChildIndex(Me.SuperTabControlHome_Menu, 0)
        Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
        Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
        Me.RibbonControlForm_MainRibbon.PerformLayout()
        CType(Me.SuperTabControlHome_Menu, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SuperTabControlHome_Menu As DevComponents.DotNetBar.SuperTabControl
    Friend WithEvents DotNetBarManager As DevComponents.DotNetBar.DotNetBarManager
    Friend WithEvents DockSite4 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite1 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite2 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite3 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite5 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite6 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite7 As DevComponents.DotNetBar.DockSite
    Friend WithEvents DockSite8 As DevComponents.DotNetBar.DockSite
End Class
