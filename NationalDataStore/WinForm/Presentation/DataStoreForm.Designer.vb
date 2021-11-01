Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class DataStoreForm
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseRibbonForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DataStoreForm))
            Me.RichTextBoxForm_Log = New System.Windows.Forms.RichTextBox()
            Me.StyleManager = New DevComponents.DotNetBar.StyleManager(Me.components)
            Me.RibbonBarOptions_Maintain = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMaintain_Clients = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Service = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemService_Log = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemService_ProcessNow = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
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
            Me.PanelForm_Form.Controls.Add(Me.RichTextBoxForm_Log)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(1046, 327)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonControlForm_MainRibbon.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.Office2007StartButtonMainRibbon_Home})
            Me.RibbonControlForm_MainRibbon.Padding = New System.Windows.Forms.Padding(0)
            Me.RibbonControlForm_MainRibbon.Size = New System.Drawing.Size(1046, 154)
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
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Service)
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Maintain)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 56)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(1046, 98)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Maintain, 0)
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Service, 0)
            '
            'RibbonBarFilePanel_System
            '
            Me.RibbonBarFilePanel_System.AutoOverflowEnabled = True
            Me.RibbonBarFilePanel_System.AutoSizeItems = True
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
            Me.RibbonBarFilePanel_System.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarFilePanel_System.ResizeItemsToFit = True
            Me.RibbonBarFilePanel_System.Size = New System.Drawing.Size(100, 96)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 482)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(1046, 18)
            '
            'RichTextBoxForm_Log
            '
            Me.RichTextBoxForm_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.RichTextBoxForm_Log.Location = New System.Drawing.Point(12, 6)
            Me.RichTextBoxForm_Log.Name = "RichTextBoxForm_Log"
            Me.RichTextBoxForm_Log.ReadOnly = True
            Me.RichTextBoxForm_Log.Size = New System.Drawing.Size(1022, 315)
            Me.RichTextBoxForm_Log.TabIndex = 0
            Me.RichTextBoxForm_Log.Text = ""
            '
            'StyleManager
            '
            Me.StyleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016
            Me.StyleManager.MetroColorParameters = New DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.WhiteSmoke, System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(154, Byte), Integer)))
            '
            'RibbonBarOptions_Maintain
            '
            Me.RibbonBarOptions_Maintain.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Maintain.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Maintain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Maintain.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Maintain.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Maintain.DragDropSupport = True
            Me.RibbonBarOptions_Maintain.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMaintain_Clients})
            Me.RibbonBarOptions_Maintain.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Maintain.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Maintain.Name = "RibbonBarOptions_Maintain"
            Me.RibbonBarOptions_Maintain.SecurityEnabled = True
            Me.RibbonBarOptions_Maintain.Size = New System.Drawing.Size(94, 96)
            Me.RibbonBarOptions_Maintain.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Maintain.TabIndex = 29
            Me.RibbonBarOptions_Maintain.Text = "Maintain"
            '
            '
            '
            Me.RibbonBarOptions_Maintain.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Maintain.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Maintain.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemMaintain_Clients
            '
            Me.ButtonItemMaintain_Clients.BeginGroup = True
            Me.ButtonItemMaintain_Clients.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMaintain_Clients.Name = "ButtonItemMaintain_Clients"
            Me.ButtonItemMaintain_Clients.RibbonWordWrap = False
            Me.ButtonItemMaintain_Clients.SecurityEnabled = True
            Me.ButtonItemMaintain_Clients.SubItemsExpandWidth = 14
            Me.ButtonItemMaintain_Clients.Text = "Clients"
            '
            'RibbonBarOptions_Service
            '
            Me.RibbonBarOptions_Service.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Service.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Service.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Service.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Service.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Service.DragDropSupport = True
            Me.RibbonBarOptions_Service.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemService_Log, Me.ButtonItemService_ProcessNow})
            Me.RibbonBarOptions_Service.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Service.Location = New System.Drawing.Point(197, 0)
            Me.RibbonBarOptions_Service.Name = "RibbonBarOptions_Service"
            Me.RibbonBarOptions_Service.SecurityEnabled = True
            Me.RibbonBarOptions_Service.Size = New System.Drawing.Size(157, 96)
            Me.RibbonBarOptions_Service.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Service.TabIndex = 30
            Me.RibbonBarOptions_Service.Text = "Service"
            '
            '
            '
            Me.RibbonBarOptions_Service.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Service.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Service.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemService_Log
            '
            Me.ButtonItemService_Log.BeginGroup = True
            Me.ButtonItemService_Log.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemService_Log.Name = "ButtonItemService_Log"
            Me.ButtonItemService_Log.RibbonWordWrap = False
            Me.ButtonItemService_Log.SecurityEnabled = True
            Me.ButtonItemService_Log.SubItemsExpandWidth = 14
            Me.ButtonItemService_Log.Text = "Log"
            '
            'ButtonItemService_ProcessNow
            '
            Me.ButtonItemService_ProcessNow.BeginGroup = True
            Me.ButtonItemService_ProcessNow.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemService_ProcessNow.Name = "ButtonItemService_ProcessNow"
            Me.ButtonItemService_ProcessNow.RibbonWordWrap = False
            Me.ButtonItemService_ProcessNow.SecurityEnabled = True
            Me.ButtonItemService_ProcessNow.SubItemsExpandWidth = 14
            Me.ButtonItemService_ProcessNow.Text = "Process Now"
            '
            'DataStoreForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1056, 502)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "DataStoreForm"
            Me.Text = "Advantage Nielsen Data Store"
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
        Friend WithEvents RichTextBoxForm_Log As RichTextBox
        Protected Friend WithEvents StyleManager As DevComponents.DotNetBar.StyleManager
        Friend WithEvents RibbonBarOptions_Maintain As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMaintain_Clients As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents RibbonBarOptions_Service As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemService_Log As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemService_ProcessNow As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace
