Namespace WinForm.Presentation.BaseForms

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MDIApplicationForm
        Inherits DevComponents.DotNetBar.Office2007RibbonForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIApplicationForm))
            Me.RibbonControlForm_MainRibbon = New DevComponents.DotNetBar.RibbonControl()
            Me.RibbonPanelFile_FilePanel = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBarFilePanel_System = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemSystem_Exit = New DevComponents.DotNetBar.ButtonItem()
            Me.Office2007StartButtonMainRibbon_Home = New DevComponents.DotNetBar.Office2007StartButton()
            Me.RibbonTabItemMainRibbon_File = New DevComponents.DotNetBar.RibbonTabItem()
            Me.ButtonItemMainRibbon_Help = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMainRibbon_ShowAndHide = New DevComponents.DotNetBar.ButtonItem()
            Me.TabStripForm_MDIChildren = New DevComponents.DotNetBar.TabStrip()
            Me.StyleManager = New DevComponents.DotNetBar.StyleManager(Me.components)
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonControlForm_MainRibbon
            '
            Me.RibbonControlForm_MainRibbon.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.CanCustomize = False
            Me.RibbonControlForm_MainRibbon.CaptionVisible = True
            Me.RibbonControlForm_MainRibbon.Controls.Add(Me.RibbonPanelFile_FilePanel)
            Me.RibbonControlForm_MainRibbon.Dock = System.Windows.Forms.DockStyle.Top
            Me.RibbonControlForm_MainRibbon.EnableQatPlacement = False
            Me.RibbonControlForm_MainRibbon.ForeColor = System.Drawing.Color.Black
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home, Me.RibbonTabItemMainRibbon_File, Me.ButtonItemMainRibbon_Help, Me.ButtonItemMainRibbon_ShowAndHide})
            Me.RibbonControlForm_MainRibbon.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
            Me.RibbonControlForm_MainRibbon.Location = New System.Drawing.Point(5, 1)
            Me.RibbonControlForm_MainRibbon.MdiSystemItemVisible = False
            Me.RibbonControlForm_MainRibbon.Name = "RibbonControlForm_MainRibbon"
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(687, 154)
            Me.RibbonControlForm_MainRibbon.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
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
            Me.RibbonControlForm_MainRibbon.TabGroupHeight = 14
            Me.RibbonControlForm_MainRibbon.TabGroupsVisible = True
            Me.RibbonControlForm_MainRibbon.TabIndex = 0
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_System)
            Me.RibbonPanelFile_FilePanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Name = "RibbonPanelFile_FilePanel"
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(687, 97)
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
            Me.RibbonPanelFile_FilePanel.TabIndex = 1
            '
            'RibbonBarFilePanel_System
            '
            Me.RibbonBarFilePanel_System.AutoOverflowEnabled = False
            Me.RibbonBarFilePanel_System.AutoSizeItems = False
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.ContainerControlProcessDialogKey = True
            Me.RibbonBarFilePanel_System.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarFilePanel_System.DragDropSupport = True
            Me.RibbonBarFilePanel_System.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
            Me.RibbonBarFilePanel_System.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSystem_Exit})
            Me.RibbonBarFilePanel_System.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarFilePanel_System.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarFilePanel_System.Location = New System.Drawing.Point(3, 0)
            Me.RibbonBarFilePanel_System.Name = "RibbonBarFilePanel_System"
            Me.RibbonBarFilePanel_System.ResizeItemsToFit = False
            Me.RibbonBarFilePanel_System.SecurityEnabled = True
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 95)
            Me.RibbonBarFilePanel_System.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarFilePanel_System.TabIndex = 0
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarFilePanel_System.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarFilePanel_System.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemSystem_Exit
            '
            Me.ButtonItemSystem_Exit.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSystem_Exit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSystem_Exit.Name = "ButtonItemSystem_Exit"
            Me.ButtonItemSystem_Exit.SubItemsExpandWidth = 14
            Me.ButtonItemSystem_Exit.Text = "Exit"
            '
            'Office2007StartButtonMainRibbon_Home
            '
            Me.Office2007StartButtonMainRibbon_Home.AutoExpandOnClick = True
            Me.Office2007StartButtonMainRibbon_Home.CanCustomize = False
            Me.Office2007StartButtonMainRibbon_Home.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image
            Me.Office2007StartButtonMainRibbon_Home.Image = CType(resources.GetObject("Office2007StartButtonMainRibbon_Home.Image"), System.Drawing.Image)
            Me.Office2007StartButtonMainRibbon_Home.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingHorizontal = 0
            Me.Office2007StartButtonMainRibbon_Home.ImagePaddingVertical = 1
            Me.Office2007StartButtonMainRibbon_Home.Name = "Office2007StartButtonMainRibbon_Home"
            Me.Office2007StartButtonMainRibbon_Home.ShowSubItems = False
            Me.Office2007StartButtonMainRibbon_Home.Text = "Home"
            '
            'RibbonTabItemMainRibbon_File
            '
            Me.RibbonTabItemMainRibbon_File.Checked = True
            Me.RibbonTabItemMainRibbon_File.Name = "RibbonTabItemMainRibbon_File"
            Me.RibbonTabItemMainRibbon_File.Panel = Me.RibbonPanelFile_FilePanel
            Me.RibbonTabItemMainRibbon_File.Text = "File"
            '
            'ButtonItemMainRibbon_Help
            '
            Me.ButtonItemMainRibbon_Help.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMainRibbon_Help.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemMainRibbon_Help.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
            Me.ButtonItemMainRibbon_Help.Name = "ButtonItemMainRibbon_Help"
            '
            'ButtonItemMainRibbon_ShowAndHide
            '
            Me.ButtonItemMainRibbon_ShowAndHide.BeginGroup = True
            Me.ButtonItemMainRibbon_ShowAndHide.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMainRibbon_ShowAndHide.ImageFixedSize = New System.Drawing.Size(16, 16)
            Me.ButtonItemMainRibbon_ShowAndHide.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far
            Me.ButtonItemMainRibbon_ShowAndHide.Name = "ButtonItemMainRibbon_ShowAndHide"
            '
            'TabStripForm_MDIChildren
            '
            Me.TabStripForm_MDIChildren.AutoSelectAttachedControl = True
            Me.TabStripForm_MDIChildren.CanReorderTabs = False
            Me.TabStripForm_MDIChildren.CloseButtonOnTabsVisible = True
            Me.TabStripForm_MDIChildren.CloseButtonVisible = True
            Me.TabStripForm_MDIChildren.ColorScheme.TabBackground = System.Drawing.Color.White
            Me.TabStripForm_MDIChildren.ColorScheme.TabItemBackground = System.Drawing.Color.WhiteSmoke
            Me.TabStripForm_MDIChildren.ColorScheme.TabItemBackground2 = System.Drawing.Color.Gray
            Me.TabStripForm_MDIChildren.ColorScheme.TabItemSelectedBackground = System.Drawing.Color.White
            Me.TabStripForm_MDIChildren.ColorScheme.TabItemSelectedBorder = System.Drawing.Color.Empty
            Me.TabStripForm_MDIChildren.ColorScheme.TabItemSelectedText = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.TabStripForm_MDIChildren.ColorScheme.TabItemText = System.Drawing.Color.Black
            Me.TabStripForm_MDIChildren.ColorScheme.TabPanelBackground = System.Drawing.Color.White
            Me.TabStripForm_MDIChildren.Dock = System.Windows.Forms.DockStyle.Top
            Me.TabStripForm_MDIChildren.ForeColor = System.Drawing.Color.Black
            Me.TabStripForm_MDIChildren.Location = New System.Drawing.Point(5, 155)
            Me.TabStripForm_MDIChildren.MdiForm = Me
            Me.TabStripForm_MDIChildren.MdiTabbedDocuments = True
            Me.TabStripForm_MDIChildren.Name = "TabStripForm_MDIChildren"
            Me.TabStripForm_MDIChildren.SelectedTab = Nothing
            Me.TabStripForm_MDIChildren.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabStripForm_MDIChildren.ShowMdiChildIcon = False
            Me.TabStripForm_MDIChildren.Size = New System.Drawing.Size(687, 20)
            Me.TabStripForm_MDIChildren.TabAlignment = DevComponents.DotNetBar.eTabStripAlignment.Top
            Me.TabStripForm_MDIChildren.TabIndex = 2
            Me.TabStripForm_MDIChildren.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            '
            'StyleManager
            '
            Me.StyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
            Me.StyleManager.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer)))
            '
            'MDIApplicationForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(697, 441)
            Me.Controls.Add(Me.TabStripForm_MDIChildren)
            Me.Controls.Add(Me.RibbonControlForm_MainRibbon)
            Me.EnableGlass = False
            Me.IsMdiContainer = True
            Me.Name = "MDIApplicationForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "MDIApplicationForm"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Protected Friend WithEvents StyleManager As DevComponents.DotNetBar.StyleManager
        Protected WithEvents RibbonPanelFile_FilePanel As DevComponents.DotNetBar.RibbonPanel
		Protected WithEvents RibbonBarFilePanel_System As Controls.RibbonBar
		Protected WithEvents RibbonTabItemMainRibbon_File As DevComponents.DotNetBar.RibbonTabItem
		Protected WithEvents RibbonControlForm_MainRibbon As DevComponents.DotNetBar.RibbonControl
		Protected WithEvents ButtonItemSystem_Exit As DevComponents.DotNetBar.ButtonItem
		Protected WithEvents Office2007StartButtonMainRibbon_Home As DevComponents.DotNetBar.Office2007StartButton
		Protected WithEvents ButtonItemMainRibbon_Help As DevComponents.DotNetBar.ButtonItem
		Protected WithEvents ButtonItemMainRibbon_ShowAndHide As DevComponents.DotNetBar.ButtonItem
		Protected WithEvents TabStripForm_MDIChildren As DevComponents.DotNetBar.TabStrip
	End Class

End Namespace