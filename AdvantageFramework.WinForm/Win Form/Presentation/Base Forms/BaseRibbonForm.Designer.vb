Namespace WinForm.Presentation.BaseForms

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class BaseRibbonForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(BaseRibbonForm))
            Me._DefaultLookAndFeel = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
            Me.RibbonControlForm_MainRibbon = New DevComponents.DotNetBar.RibbonControl()
            Me.RibbonPanelFile_FilePanel = New DevComponents.DotNetBar.RibbonPanel()
            Me.RibbonBarFilePanel_System = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.Office2007StartButtonMainRibbon_Home = New DevComponents.DotNetBar.Office2007StartButton()
            Me.RibbonTabItemMainRibbon_File = New DevComponents.DotNetBar.RibbonTabItem()
            Me.BarForm_StatusBar = New DevComponents.DotNetBar.Bar()
            Me.ProgressBarItemStatusBar_ProgressBar = New DevComponents.DotNetBar.ProgressBarItem()
            Me.LabelItemStatusBar_Status = New DevComponents.DotNetBar.LabelItem()
            Me.ButtonItemSystem_Close = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_Form = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            '_DefaultLookAndFeel
            '
            Me._DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
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
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home, Me.RibbonTabItemMainRibbon_File})
            Me.RibbonControlForm_MainRibbon.KeyTipsFont = New System.Drawing.Font("Tahoma", 7.0!)
            Me.RibbonControlForm_MainRibbon.Location = New System.Drawing.Point(5, 1)
            Me.RibbonControlForm_MainRibbon.MdiSystemItemVisible = False
            Me.RibbonControlForm_MainRibbon.Name = "RibbonControlForm_MainRibbon"
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(787, 154)
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
            Me.RibbonControlForm_MainRibbon.TabIndex = 1
            Me.RibbonControlForm_MainRibbon.UseExternalCustomization = True
            '
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarFilePanel_System)
            Me.RibbonPanelFile_FilePanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Name = "RibbonPanelFile_FilePanel"
            Me.RibbonPanelFile_FilePanel.Padding = New System.Windows.Forms.Padding(3, 0, 3, 2)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(787, 97)
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
            Me.RibbonBarFilePanel_System.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemSystem_Close})
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
            Me.Office2007StartButtonMainRibbon_Home.Visible = False
            '
            'RibbonTabItemMainRibbon_File
            '
            Me.RibbonTabItemMainRibbon_File.Checked = True
            Me.RibbonTabItemMainRibbon_File.Name = "RibbonTabItemMainRibbon_File"
            Me.RibbonTabItemMainRibbon_File.Panel = Me.RibbonPanelFile_FilePanel
            Me.RibbonTabItemMainRibbon_File.Text = "File"
            '
            'BarForm_StatusBar
            '
            Me.BarForm_StatusBar.AccessibleDescription = "DotNetBar Bar (BarForm_StatusBar)"
            Me.BarForm_StatusBar.AccessibleName = "DotNetBar Bar"
            Me.BarForm_StatusBar.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar
            Me.BarForm_StatusBar.AntiAlias = True
            Me.BarForm_StatusBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar
            Me.BarForm_StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.BarForm_StatusBar.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.BarForm_StatusBar.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle
            Me.BarForm_StatusBar.IsMaximized = False
            Me.BarForm_StatusBar.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ProgressBarItemStatusBar_ProgressBar, Me.LabelItemStatusBar_Status})
            Me.BarForm_StatusBar.ItemSpacing = 3
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 416)
            Me.BarForm_StatusBar.Name = "BarForm_StatusBar"
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(787, 20)
            Me.BarForm_StatusBar.Stretch = True
            Me.BarForm_StatusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.BarForm_StatusBar.TabIndex = 16
            Me.BarForm_StatusBar.TabStop = False
            '
            'ProgressBarItemStatusBar_ProgressBar
            '
            '
            '
            '
            Me.ProgressBarItemStatusBar_ProgressBar.BackStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarItemStatusBar_ProgressBar.ChunkGradientAngle = 0!
            Me.ProgressBarItemStatusBar_ProgressBar.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
            Me.ProgressBarItemStatusBar_ProgressBar.Name = "ProgressBarItemStatusBar_ProgressBar"
            Me.ProgressBarItemStatusBar_ProgressBar.RecentlyUsed = False
            Me.ProgressBarItemStatusBar_ProgressBar.Visible = False
            Me.ProgressBarItemStatusBar_ProgressBar.Width = 300
            '
            'LabelItemStatusBar_Status
            '
            Me.LabelItemStatusBar_Status.Name = "LabelItemStatusBar_Status"
            Me.LabelItemStatusBar_Status.Stretch = True
            '
            'ButtonItemSystem_Close
            '
            Me.ButtonItemSystem_Close.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemSystem_Close.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemSystem_Close.Name = "ButtonItemSystem_Close"
            Me.ButtonItemSystem_Close.SubItemsExpandWidth = 14
            Me.ButtonItemSystem_Close.Text = "Close"
            '
            'PanelForm_Form
            '
            Me.PanelForm_Form.Appearance.BackColor = System.Drawing.Color.White
            Me.PanelForm_Form.Appearance.Options.UseBackColor = True
            Me.PanelForm_Form.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelForm_Form.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_Form.Location = New System.Drawing.Point(5, 155)
            Me.PanelForm_Form.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelForm_Form.Name = "PanelForm_Form"
            Me.PanelForm_Form.Size = New System.Drawing.Size(787, 261)
            Me.PanelForm_Form.TabIndex = 17
            '
            'BaseRibbonForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(797, 438)
            Me.Controls.Add(Me.PanelForm_Form)
            Me.Controls.Add(Me.RibbonControlForm_MainRibbon)
            Me.Controls.Add(Me.BarForm_StatusBar)
            Me.EnableGlass = False
            Me.Name = "BaseRibbonForm"
            Me.Text = "BaseRibbonForm"
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents _DefaultLookAndFeel As DevExpress.LookAndFeel.DefaultLookAndFeel
        Protected Friend WithEvents PanelForm_Form As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Protected WithEvents RibbonControlForm_MainRibbon As DevComponents.DotNetBar.RibbonControl
        Protected WithEvents RibbonPanelFile_FilePanel As DevComponents.DotNetBar.RibbonPanel
        Protected WithEvents RibbonBarFilePanel_System As Controls.RibbonBar
        Protected WithEvents ButtonItemSystem_Close As DevComponents.DotNetBar.ButtonItem
        Protected WithEvents Office2007StartButtonMainRibbon_Home As DevComponents.DotNetBar.Office2007StartButton
        Protected WithEvents RibbonTabItemMainRibbon_File As DevComponents.DotNetBar.RibbonTabItem
        Protected WithEvents LabelItemStatusBar_Status As DevComponents.DotNetBar.LabelItem
        Protected WithEvents ProgressBarItemStatusBar_ProgressBar As DevComponents.DotNetBar.ProgressBarItem
        Protected WithEvents BarForm_StatusBar As DevComponents.DotNetBar.Bar
    End Class

End Namespace