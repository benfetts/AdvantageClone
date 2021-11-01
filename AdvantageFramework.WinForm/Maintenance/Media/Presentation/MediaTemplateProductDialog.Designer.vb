Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaTemplateProductDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaTemplateProductDialog))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_Products = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterForm_LeftMiddle = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.PanelRightSection_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ButtonRightSection_RemoveTemplate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonRightSection_AddTemplate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.DataGridViewRightSection_ProductTemplates = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterRightSection_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelRightSection_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewMiddleSection_Templates = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Default = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDefault_CheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDefault_UncheckAll = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_Form.SuspendLayout()
            Me.RibbonControlForm_MainRibbon.SuspendLayout()
            Me.RibbonPanelFile_FilePanel.SuspendLayout()
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelRightSection_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_RightSection.SuspendLayout()
            CType(Me.PanelRightSection_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelRightSection_LeftSection.SuspendLayout()
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
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_RightSection)
            Me.PanelForm_Form.Controls.Add(Me.ExpandableSplitterForm_LeftMiddle)
            Me.PanelForm_Form.Controls.Add(Me.PanelForm_LeftSection)
            Me.PanelForm_Form.LookAndFeel.SkinName = "Office 2013"
            Me.PanelForm_Form.LookAndFeel.UseDefaultLookAndFeel = False
            Me.PanelForm_Form.Size = New System.Drawing.Size(982, 555)
            '
            'RibbonControlForm_MainRibbon
            '
            '
            '
            '
            Me.RibbonControlForm_MainRibbon.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
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
            'RibbonPanelFile_FilePanel
            '
            Me.RibbonPanelFile_FilePanel.Controls.Add(Me.RibbonBarOptions_Default)
            Me.RibbonPanelFile_FilePanel.Location = New System.Drawing.Point(0, 57)
            Me.RibbonPanelFile_FilePanel.Size = New System.Drawing.Size(982, 94)
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
            Me.RibbonPanelFile_FilePanel.Controls.SetChildIndex(Me.RibbonBarOptions_Default, 0)
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
            Me.BarForm_StatusBar.Location = New System.Drawing.Point(5, 710)
            Me.BarForm_StatusBar.Size = New System.Drawing.Size(982, 18)
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_Products)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(188, 555)
            Me.PanelForm_LeftSection.TabIndex = 5
            '
            'DataGridViewLeftSection_Products
            '
            Me.DataGridViewLeftSection_Products.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_Products.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_Products.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_Products.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_Products.ItemDescription = "Client(s)"
            Me.DataGridViewLeftSection_Products.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_Products.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewLeftSection_Products.ModifyGridRowHeight = False
            Me.DataGridViewLeftSection_Products.MultiSelect = False
            Me.DataGridViewLeftSection_Products.Name = "DataGridViewLeftSection_Products"
            Me.DataGridViewLeftSection_Products.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_Products.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewLeftSection_Products.ShowRowSelectionIfHidden = True
            Me.DataGridViewLeftSection_Products.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_Products.Size = New System.Drawing.Size(170, 531)
            Me.DataGridViewLeftSection_Products.TabIndex = 0
            Me.DataGridViewLeftSection_Products.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_Products.ViewCaptionHeight = -1
            '
            'ExpandableSplitterForm_LeftMiddle
            '
            Me.ExpandableSplitterForm_LeftMiddle.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftMiddle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterForm_LeftMiddle.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftMiddle.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftMiddle.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftMiddle.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftMiddle.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterForm_LeftMiddle.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterForm_LeftMiddle.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftMiddle.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterForm_LeftMiddle.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterForm_LeftMiddle.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterForm_LeftMiddle.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterForm_LeftMiddle.Location = New System.Drawing.Point(188, 0)
            Me.ExpandableSplitterForm_LeftMiddle.Name = "ExpandableSplitterForm_LeftMiddle"
            Me.ExpandableSplitterForm_LeftMiddle.Size = New System.Drawing.Size(6, 555)
            Me.ExpandableSplitterForm_LeftMiddle.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterForm_LeftMiddle.TabIndex = 6
            Me.ExpandableSplitterForm_LeftMiddle.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_RightSection)
            Me.PanelForm_RightSection.Controls.Add(Me.ExpandableSplitterRightSection_LeftRight)
            Me.PanelForm_RightSection.Controls.Add(Me.PanelRightSection_LeftSection)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(194, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(788, 555)
            Me.PanelForm_RightSection.TabIndex = 7
            '
            'PanelRightSection_RightSection
            '
            Me.PanelRightSection_RightSection.Controls.Add(Me.ButtonRightSection_RemoveTemplate)
            Me.PanelRightSection_RightSection.Controls.Add(Me.ButtonRightSection_AddTemplate)
            Me.PanelRightSection_RightSection.Controls.Add(Me.DataGridViewRightSection_ProductTemplates)
            Me.PanelRightSection_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelRightSection_RightSection.Location = New System.Drawing.Point(208, 2)
            Me.PanelRightSection_RightSection.Name = "PanelRightSection_RightSection"
            Me.PanelRightSection_RightSection.Size = New System.Drawing.Size(578, 551)
            Me.PanelRightSection_RightSection.TabIndex = 15
            '
            'ButtonRightSection_RemoveTemplate
            '
            Me.ButtonRightSection_RemoveTemplate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_RemoveTemplate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_RemoveTemplate.Location = New System.Drawing.Point(6, 36)
            Me.ButtonRightSection_RemoveTemplate.Name = "ButtonRightSection_RemoveTemplate"
            Me.ButtonRightSection_RemoveTemplate.SecurityEnabled = True
            Me.ButtonRightSection_RemoveTemplate.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_RemoveTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_RemoveTemplate.TabIndex = 10
            Me.ButtonRightSection_RemoveTemplate.Text = "<"
            '
            'ButtonRightSection_AddTemplate
            '
            Me.ButtonRightSection_AddTemplate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonRightSection_AddTemplate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonRightSection_AddTemplate.Location = New System.Drawing.Point(6, 10)
            Me.ButtonRightSection_AddTemplate.Name = "ButtonRightSection_AddTemplate"
            Me.ButtonRightSection_AddTemplate.SecurityEnabled = True
            Me.ButtonRightSection_AddTemplate.Size = New System.Drawing.Size(75, 20)
            Me.ButtonRightSection_AddTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonRightSection_AddTemplate.TabIndex = 9
            Me.ButtonRightSection_AddTemplate.Text = ">"
            '
            'DataGridViewRightSection_ProductTemplates
            '
            Me.DataGridViewRightSection_ProductTemplates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_ProductTemplates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_ProductTemplates.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_ProductTemplates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_ProductTemplates.ItemDescription = "Client Template(s)"
            Me.DataGridViewRightSection_ProductTemplates.Location = New System.Drawing.Point(87, 10)
            Me.DataGridViewRightSection_ProductTemplates.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRightSection_ProductTemplates.ModifyGridRowHeight = False
            Me.DataGridViewRightSection_ProductTemplates.MultiSelect = True
            Me.DataGridViewRightSection_ProductTemplates.Name = "DataGridViewRightSection_ProductTemplates"
            Me.DataGridViewRightSection_ProductTemplates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_ProductTemplates.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRightSection_ProductTemplates.ShowRowSelectionIfHidden = True
            Me.DataGridViewRightSection_ProductTemplates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_ProductTemplates.Size = New System.Drawing.Size(481, 531)
            Me.DataGridViewRightSection_ProductTemplates.TabIndex = 1
            Me.DataGridViewRightSection_ProductTemplates.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_ProductTemplates.ViewCaptionHeight = -1
            '
            'ExpandableSplitterRightSection_LeftRight
            '
            Me.ExpandableSplitterRightSection_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterRightSection_LeftRight.ExpandableControl = Me.PanelRightSection_LeftSection
            Me.ExpandableSplitterRightSection_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterRightSection_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterRightSection_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterRightSection_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterRightSection_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterRightSection_LeftRight.Location = New System.Drawing.Point(202, 2)
            Me.ExpandableSplitterRightSection_LeftRight.Name = "ExpandableSplitterRightSection_LeftRight"
            Me.ExpandableSplitterRightSection_LeftRight.Size = New System.Drawing.Size(6, 551)
            Me.ExpandableSplitterRightSection_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterRightSection_LeftRight.TabIndex = 14
            Me.ExpandableSplitterRightSection_LeftRight.TabStop = False
            '
            'PanelRightSection_LeftSection
            '
            Me.PanelRightSection_LeftSection.Controls.Add(Me.DataGridViewMiddleSection_Templates)
            Me.PanelRightSection_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelRightSection_LeftSection.Location = New System.Drawing.Point(2, 2)
            Me.PanelRightSection_LeftSection.Name = "PanelRightSection_LeftSection"
            Me.PanelRightSection_LeftSection.Size = New System.Drawing.Size(200, 551)
            Me.PanelRightSection_LeftSection.TabIndex = 12
            '
            'DataGridViewMiddleSection_Templates
            '
            Me.DataGridViewMiddleSection_Templates.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMiddleSection_Templates.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMiddleSection_Templates.AutoUpdateViewCaption = True
            Me.DataGridViewMiddleSection_Templates.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMiddleSection_Templates.ItemDescription = "Template(s)"
            Me.DataGridViewMiddleSection_Templates.Location = New System.Drawing.Point(5, 10)
            Me.DataGridViewMiddleSection_Templates.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewMiddleSection_Templates.ModifyGridRowHeight = False
            Me.DataGridViewMiddleSection_Templates.MultiSelect = True
            Me.DataGridViewMiddleSection_Templates.Name = "DataGridViewMiddleSection_Templates"
            Me.DataGridViewMiddleSection_Templates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMiddleSection_Templates.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewMiddleSection_Templates.ShowRowSelectionIfHidden = True
            Me.DataGridViewMiddleSection_Templates.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMiddleSection_Templates.Size = New System.Drawing.Size(189, 531)
            Me.DataGridViewMiddleSection_Templates.TabIndex = 0
            Me.DataGridViewMiddleSection_Templates.UseEmbeddedNavigator = False
            Me.DataGridViewMiddleSection_Templates.ViewCaptionHeight = -1
            '
            'RibbonBarOptions_Default
            '
            Me.RibbonBarOptions_Default.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Default.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Default.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Default.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Default.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Default.DragDropSupport = True
            Me.RibbonBarOptions_Default.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDefault_CheckAll, Me.ButtonItemDefault_UncheckAll})
            Me.RibbonBarOptions_Default.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
            Me.RibbonBarOptions_Default.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Default.Location = New System.Drawing.Point(103, 0)
            Me.RibbonBarOptions_Default.Name = "RibbonBarOptions_Default"
            Me.RibbonBarOptions_Default.SecurityEnabled = True
            Me.RibbonBarOptions_Default.Size = New System.Drawing.Size(76, 92)
            Me.RibbonBarOptions_Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Default.TabIndex = 39
            Me.RibbonBarOptions_Default.Text = "Default"
            '
            '
            '
            Me.RibbonBarOptions_Default.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Default.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Default.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemDefault_CheckAll
            '
            Me.ButtonItemDefault_CheckAll.Name = "ButtonItemDefault_CheckAll"
            Me.ButtonItemDefault_CheckAll.SecurityEnabled = True
            Me.ButtonItemDefault_CheckAll.Stretch = True
            Me.ButtonItemDefault_CheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemDefault_CheckAll.Text = "Check All"
            '
            'ButtonItemDefault_UncheckAll
            '
            Me.ButtonItemDefault_UncheckAll.BeginGroup = True
            Me.ButtonItemDefault_UncheckAll.Name = "ButtonItemDefault_UncheckAll"
            Me.ButtonItemDefault_UncheckAll.SecurityEnabled = True
            Me.ButtonItemDefault_UncheckAll.SubItemsExpandWidth = 14
            Me.ButtonItemDefault_UncheckAll.Text = "Uncheck All"
            '
            'MediaTemplateProductDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaTemplateProductDialog"
            Me.Text = "Client Template Maintenance"
            Me.Controls.SetChildIndex(Me.BarForm_StatusBar, 0)
            Me.Controls.SetChildIndex(Me.RibbonControlForm_MainRibbon, 0)
            Me.Controls.SetChildIndex(Me.PanelForm_Form, 0)
            CType(Me.PanelForm_Form, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_Form.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.ResumeLayout(False)
            Me.RibbonControlForm_MainRibbon.PerformLayout()
            Me.RibbonPanelFile_FilePanel.ResumeLayout(False)
            CType(Me.BarForm_StatusBar, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelRightSection_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_RightSection.ResumeLayout(False)
            CType(Me.PanelRightSection_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelRightSection_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents PanelForm_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents PanelRightSection_RightSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonRightSection_RemoveTemplate As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonRightSection_AddTemplate As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents DataGridViewRightSection_ProductTemplates As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterRightSection_LeftRight As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelRightSection_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewMiddleSection_Templates As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterForm_LeftMiddle As WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_LeftSection As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_Products As WinForm.MVC.Presentation.Controls.DataGridView
        Private WithEvents RibbonBarOptions_Default As WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemDefault_CheckAll As WinForm.Presentation.Controls.ButtonItem
        Private WithEvents ButtonItemDefault_UncheckAll As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace

