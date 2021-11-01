﻿Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class VendorRepSetupForm
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(VendorRepSetupForm))
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_ExportVendorRepresentatives = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.DataGridViewLeftSection_VendorRepresentatives = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.VendorRepresentativeControlRightSection_VendorRep = New AdvantageFramework.WinForm.Presentation.Controls.VendorRepresentativeControl()
            Me.ButtonItemActions_Refresh = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_ExportVendorRepresentatives)
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_VendorRepresentatives)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(138, 453)
            Me.PanelForm_LeftSection.TabIndex = 0
            '
            'DataGridViewLeftSection_ExportVendorRepresentatives
            '
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.ItemDescription = ""
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.Location = New System.Drawing.Point(12, 171)
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.MultiSelect = True
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.Name = "DataGridViewLeftSection_ExportVendorRepresentatives"
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.RunStandardValidation = True
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.Size = New System.Drawing.Size(120, 270)
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.TabIndex = 4
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.ViewCaptionHeight = -1
            Me.DataGridViewLeftSection_ExportVendorRepresentatives.Visible = False
            '
            'DataGridViewLeftSection_VendorRepresentatives
            '
            Me.DataGridViewLeftSection_VendorRepresentatives.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewLeftSection_VendorRepresentatives.AllowDragAndDrop = False
            Me.DataGridViewLeftSection_VendorRepresentatives.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewLeftSection_VendorRepresentatives.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_VendorRepresentatives.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewLeftSection_VendorRepresentatives.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_VendorRepresentatives.AutoFilterLookupColumns = False
            Me.DataGridViewLeftSection_VendorRepresentatives.AutoloadRepositoryDatasource = True
            Me.DataGridViewLeftSection_VendorRepresentatives.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_VendorRepresentatives.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_VendorRepresentatives.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewLeftSection_VendorRepresentatives.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_VendorRepresentatives.ItemDescription = ""
            Me.DataGridViewLeftSection_VendorRepresentatives.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_VendorRepresentatives.MultiSelect = True
            Me.DataGridViewLeftSection_VendorRepresentatives.Name = "DataGridViewLeftSection_VendorRepresentatives"
            Me.DataGridViewLeftSection_VendorRepresentatives.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_VendorRepresentatives.RunStandardValidation = True
            Me.DataGridViewLeftSection_VendorRepresentatives.ShowColumnMenuOnRightClick = False
            Me.DataGridViewLeftSection_VendorRepresentatives.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_VendorRepresentatives.Size = New System.Drawing.Size(120, 429)
            Me.DataGridViewLeftSection_VendorRepresentatives.TabIndex = 1
            Me.DataGridViewLeftSection_VendorRepresentatives.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_VendorRepresentatives.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(138, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 453)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 1
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 0)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(313, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 7
            Me.RibbonBarMergeContainerForm_Options.Visible = False
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
            Me.RibbonBarOptions_Actions.DragDropSupport = True
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Refresh})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(247, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 0
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Save
            '
            Me.ButtonItemActions_Save.BeginGroup = True
            Me.ButtonItemActions_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Save.Name = "ButtonItemActions_Save"
            Me.ButtonItemActions_Save.RibbonWordWrap = False
            Me.ButtonItemActions_Save.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Save.Text = "Save"
            '
            'ButtonItemActions_Delete
            '
            Me.ButtonItemActions_Delete.BeginGroup = True
            Me.ButtonItemActions_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Delete.Name = "ButtonItemActions_Delete"
            Me.ButtonItemActions_Delete.RibbonWordWrap = False
            Me.ButtonItemActions_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Delete.Text = "Delete"
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.VendorRepresentativeControlRightSection_VendorRep)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(144, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(776, 453)
            Me.PanelForm_RightSection.TabIndex = 8
            '
            'VendorRepresentativeControlRightSection_VendorRep
            '
            Me.VendorRepresentativeControlRightSection_VendorRep.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.VendorRepresentativeControlRightSection_VendorRep.Location = New System.Drawing.Point(6, 12)
            Me.VendorRepresentativeControlRightSection_VendorRep.Name = "VendorRepresentativeControlRightSection_VendorRep"
            Me.VendorRepresentativeControlRightSection_VendorRep.Size = New System.Drawing.Size(758, 429)
            Me.VendorRepresentativeControlRightSection_VendorRep.TabIndex = 0
            '
            'ButtonItemActions_Refresh
            '
            Me.ButtonItemActions_Refresh.BeginGroup = True
            Me.ButtonItemActions_Refresh.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Refresh.Name = "ButtonItemActions_Refresh"
            Me.ButtonItemActions_Refresh.RibbonWordWrap = False
            Me.ButtonItemActions_Refresh.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Refresh.Text = "Refresh"
            '
            'VendorRepSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(920, 453)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "VendorRepSetupForm"
            Me.Text = "Vendor Rep Maintenance"
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_VendorRepresentatives As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents VendorRepresentativeControlRightSection_VendorRep As AdvantageFramework.WinForm.Presentation.Controls.VendorRepresentativeControl
        Friend WithEvents DataGridViewLeftSection_ExportVendorRepresentatives As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonItemActions_Refresh As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

