Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class SalesClassFormatSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesClassFormatSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_CurrentView = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemExport_All = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewLeftSection_SalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_AllSalesClassFormats = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewRightSection_SalesClassFormats = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(275, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(345, 95)
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.Style.Class = ""
            Me.RibbonBarMergeContainerForm_Options.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.Class = ""
            Me.RibbonBarMergeContainerForm_Options.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.Class = ""
            Me.RibbonBarMergeContainerForm_Options.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Actions
            '
            Me.RibbonBarOptions_Actions.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_Actions.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_Actions.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Actions.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(210, 95)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
            Me.RibbonBarOptions_Actions.Text = "Actions"
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyle.Class = ""
            Me.RibbonBarOptions_Actions.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_Actions.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.AutoExpandOnClick = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SplitButton = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemExport_CurrentView, Me.ButtonItemExport_All})
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemExport_CurrentView
            '
            Me.ButtonItemExport_CurrentView.Name = "ButtonItemExport_CurrentView"
            Me.ButtonItemExport_CurrentView.Text = "Current View"
            '
            'ButtonItemExport_All
            '
            Me.ButtonItemExport_All.Name = "ButtonItemExport_All"
            Me.ButtonItemExport_All.Text = "All"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.Stretch = True
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.Stretch = True
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'ButtonItemActions_Cancel
            '
            Me.ButtonItemActions_Cancel.BeginGroup = True
            Me.ButtonItemActions_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Cancel.Enabled = False
            Me.ButtonItemActions_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Cancel.Name = "ButtonItemActions_Cancel"
            Me.ButtonItemActions_Cancel.RibbonWordWrap = False
            Me.ButtonItemActions_Cancel.Stretch = True
            Me.ButtonItemActions_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Cancel.Text = "Cancel"
            Me.ButtonItemActions_Cancel.Tooltip = "Cancel adding new row"
            '
            'DataGridViewLeftSection_SalesClasses
            '
            Me.DataGridViewLeftSection_SalesClasses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_SalesClasses.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_SalesClasses.ItemDescription = ""
            Me.DataGridViewLeftSection_SalesClasses.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_SalesClasses.MultiSelect = False
            Me.DataGridViewLeftSection_SalesClasses.Name = "DataGridViewLeftSection_SalesClasses"
            Me.DataGridViewLeftSection_SalesClasses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_SalesClasses.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_SalesClasses.Size = New System.Drawing.Size(231, 435)
            Me.DataGridViewLeftSection_SalesClasses.TabIndex = 0
            Me.DataGridViewLeftSection_SalesClasses.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_SalesClasses.ViewCaptionHeight = -1
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_AllSalesClassFormats)
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_SalesClassFormats)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(249, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(488, 459)
            Me.PanelForm_RightSection.TabIndex = 10
            '
            'DataGridViewRightSection_AllSalesClassFormats
            '
            Me.DataGridViewRightSection_AllSalesClassFormats.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.[Default]
            Me.DataGridViewRightSection_AllSalesClassFormats.DataSource = Nothing
            Me.DataGridViewRightSection_AllSalesClassFormats.ItemDescription = ""
            Me.DataGridViewRightSection_AllSalesClassFormats.Location = New System.Drawing.Point(284, 298)
            Me.DataGridViewRightSection_AllSalesClassFormats.MultiSelect = True
            Me.DataGridViewRightSection_AllSalesClassFormats.Name = "DataGridViewRightSection_AllSalesClassFormats"
            Me.DataGridViewRightSection_AllSalesClassFormats.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_AllSalesClassFormats.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_AllSalesClassFormats.Size = New System.Drawing.Size(180, 123)
            Me.DataGridViewRightSection_AllSalesClassFormats.TabIndex = 1
            Me.DataGridViewRightSection_AllSalesClassFormats.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_AllSalesClassFormats.ViewCaptionHeight = -1
            Me.DataGridViewRightSection_AllSalesClassFormats.Visible = False
            '
            'DataGridViewRightSection_SalesClassFormats
            '
            Me.DataGridViewRightSection_SalesClassFormats.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_SalesClassFormats.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewRightSection_SalesClassFormats.ItemDescription = ""
            Me.DataGridViewRightSection_SalesClassFormats.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewRightSection_SalesClassFormats.MultiSelect = True
            Me.DataGridViewRightSection_SalesClassFormats.Name = "DataGridViewRightSection_SalesClassFormats"
            Me.DataGridViewRightSection_SalesClassFormats.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewRightSection_SalesClassFormats.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_SalesClassFormats.Size = New System.Drawing.Size(464, 435)
            Me.DataGridViewRightSection_SalesClassFormats.TabIndex = 0
            Me.DataGridViewRightSection_SalesClassFormats.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_SalesClassFormats.ViewCaptionHeight = -1
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_SalesClasses)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(249, 459)
            Me.PanelForm_LeftSection.TabIndex = 8
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.Expandable = True
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(61, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2 = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(94, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2
            Me.ExpandableSplitterControlForm_LeftRight.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(249, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 459)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 11
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'SalesClassFormatSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(737, 459)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "SalesClassFormatSetupForm"
            Me.Text = "Sales Class Format Maintenance"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_CurrentView As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemExport_All As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewLeftSection_SalesClasses As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewRightSection_AllSalesClassFormats As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewRightSection_SalesClassFormats As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl

    End Class

End Namespace
