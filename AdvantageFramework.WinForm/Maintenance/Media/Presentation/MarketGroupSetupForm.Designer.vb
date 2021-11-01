Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MarketGroupSetupForm
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MarketGroupSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Markets = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMarkets_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMarkets_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMarkets_MoveUp = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMarkets_MoveDown = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Update = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_MarketGroups = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewRightSection_MarketGroupMarkets = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Markets)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(5, 0)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(811, 95)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Markets
            '
            Me.RibbonBarOptions_Markets.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Markets.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Markets.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Markets.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Markets.DragDropSupport = True
            Me.RibbonBarOptions_Markets.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMarkets_Add, Me.ButtonItemMarkets_Delete, Me.ButtonItemMarkets_MoveUp, Me.ButtonItemMarkets_MoveDown})
            Me.RibbonBarOptions_Markets.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Markets.Location = New System.Drawing.Point(217, 0)
            Me.RibbonBarOptions_Markets.Name = "RibbonBarOptions_Markets"
            Me.RibbonBarOptions_Markets.SecurityEnabled = True
            Me.RibbonBarOptions_Markets.Size = New System.Drawing.Size(217, 95)
            Me.RibbonBarOptions_Markets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Markets.TabIndex = 1
            Me.RibbonBarOptions_Markets.Text = "Markets"
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Markets.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Markets.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemMarkets_Add
            '
            Me.ButtonItemMarkets_Add.BeginGroup = True
            Me.ButtonItemMarkets_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMarkets_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_Add.Name = "ButtonItemMarkets_Add"
            Me.ButtonItemMarkets_Add.RibbonWordWrap = False
            Me.ButtonItemMarkets_Add.Stretch = True
            Me.ButtonItemMarkets_Add.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_Add.Text = "Add"
            '
            'ButtonItemMarkets_Delete
            '
            Me.ButtonItemMarkets_Delete.BeginGroup = True
            Me.ButtonItemMarkets_Delete.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMarkets_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_Delete.Name = "ButtonItemMarkets_Delete"
            Me.ButtonItemMarkets_Delete.RibbonWordWrap = False
            Me.ButtonItemMarkets_Delete.Stretch = True
            Me.ButtonItemMarkets_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_Delete.Text = "Delete"
            '
            'ButtonItemMarkets_MoveUp
            '
            Me.ButtonItemMarkets_MoveUp.BeginGroup = True
            Me.ButtonItemMarkets_MoveUp.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMarkets_MoveUp.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_MoveUp.Name = "ButtonItemMarkets_MoveUp"
            Me.ButtonItemMarkets_MoveUp.RibbonWordWrap = False
            Me.ButtonItemMarkets_MoveUp.Stretch = True
            Me.ButtonItemMarkets_MoveUp.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_MoveUp.Text = "Move Up"
            '
            'ButtonItemMarkets_MoveDown
            '
            Me.ButtonItemMarkets_MoveDown.BeginGroup = True
            Me.ButtonItemMarkets_MoveDown.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMarkets_MoveDown.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMarkets_MoveDown.Name = "ButtonItemMarkets_MoveDown"
            Me.ButtonItemMarkets_MoveDown.RibbonWordWrap = False
            Me.ButtonItemMarkets_MoveDown.Stretch = True
            Me.ButtonItemMarkets_MoveDown.SubItemsExpandWidth = 14
            Me.ButtonItemMarkets_MoveDown.Text = "Move Down"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Update, Me.ButtonItemActions_Delete, Me.ButtonItemActions_Export})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(217, 95)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.BeginGroup = True
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.Stretch = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
            '
            'ButtonItemActions_Update
            '
            Me.ButtonItemActions_Update.BeginGroup = True
            Me.ButtonItemActions_Update.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Update.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Update.Name = "ButtonItemActions_Update"
            Me.ButtonItemActions_Update.RibbonWordWrap = False
            Me.ButtonItemActions_Update.Stretch = True
            Me.ButtonItemActions_Update.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Update.Text = "Update"
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_MarketGroups)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(524, 503)
            Me.PanelForm_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_MarketGroups
            '
            Me.DataGridViewLeftSection_MarketGroups.AllowSelectGroupHeaderRow = True
            Me.DataGridViewLeftSection_MarketGroups.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_MarketGroups.AutoUpdateViewCaption = True
            Me.DataGridViewLeftSection_MarketGroups.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewLeftSection_MarketGroups.ItemDescription = "Market Group(s)"
            Me.DataGridViewLeftSection_MarketGroups.Location = New System.Drawing.Point(13, 13)
            Me.DataGridViewLeftSection_MarketGroups.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewLeftSection_MarketGroups.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewLeftSection_MarketGroups.ModifyGridRowHeight = False
            Me.DataGridViewLeftSection_MarketGroups.MultiSelect = True
            Me.DataGridViewLeftSection_MarketGroups.Name = "DataGridViewLeftSection_MarketGroups"
            Me.DataGridViewLeftSection_MarketGroups.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_MarketGroups.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewLeftSection_MarketGroups.ShowRowSelectionIfHidden = True
            Me.DataGridViewLeftSection_MarketGroups.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_MarketGroups.Size = New System.Drawing.Size(504, 477)
            Me.DataGridViewLeftSection_MarketGroups.TabIndex = 12
            Me.DataGridViewLeftSection_MarketGroups.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_MarketGroups.ViewCaptionHeight = -1
            '
            'ExpandableSplitterControlForm_LeftRight
            '
            Me.ExpandableSplitterControlForm_LeftRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.ExpandableSplitterControlForm_LeftRight.ExpandableControl = Me.PanelForm_LeftSection
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColor = System.Drawing.Color.FromArgb(CType(CType(101, Byte), Integer), CType(CType(147, Byte), Integer), CType(CType(207, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.ExpandableSplitterControlForm_LeftRight.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText
            Me.ExpandableSplitterControlForm_LeftRight.ForeColor = System.Drawing.Color.Black
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(524, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 503)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 5
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Appearance.BackColor = System.Drawing.Color.Transparent
            Me.PanelForm_RightSection.Appearance.Options.UseBackColor = True
            Me.PanelForm_RightSection.Controls.Add(Me.DataGridViewRightSection_MarketGroupMarkets)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(530, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(379, 503)
            Me.PanelForm_RightSection.TabIndex = 7
            '
            'DataGridViewRightSection_MarketGroupMarkets
            '
            Me.DataGridViewRightSection_MarketGroupMarkets.AllowSelectGroupHeaderRow = True
            Me.DataGridViewRightSection_MarketGroupMarkets.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewRightSection_MarketGroupMarkets.AutoUpdateViewCaption = True
            Me.DataGridViewRightSection_MarketGroupMarkets.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewRightSection_MarketGroupMarkets.ItemDescription = "Market(s)"
            Me.DataGridViewRightSection_MarketGroupMarkets.Location = New System.Drawing.Point(7, 13)
            Me.DataGridViewRightSection_MarketGroupMarkets.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewRightSection_MarketGroupMarkets.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewRightSection_MarketGroupMarkets.ModifyGridRowHeight = False
            Me.DataGridViewRightSection_MarketGroupMarkets.MultiSelect = True
            Me.DataGridViewRightSection_MarketGroupMarkets.Name = "DataGridViewRightSection_MarketGroupMarkets"
            Me.DataGridViewRightSection_MarketGroupMarkets.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewRightSection_MarketGroupMarkets.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewRightSection_MarketGroupMarkets.ShowRowSelectionIfHidden = True
            Me.DataGridViewRightSection_MarketGroupMarkets.ShowSelectDeselectAllButtons = False
            Me.DataGridViewRightSection_MarketGroupMarkets.Size = New System.Drawing.Size(359, 477)
            Me.DataGridViewRightSection_MarketGroupMarkets.TabIndex = 13
            Me.DataGridViewRightSection_MarketGroupMarkets.UseEmbeddedNavigator = False
            Me.DataGridViewRightSection_MarketGroupMarkets.ViewCaptionHeight = -1
            '
            'MarketGroupSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(909, 503)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MarketGroupSetupForm"
            Me.Text = "Market Group Maintenance"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_LeftSection.ResumeLayout(False)
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_RightSection.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Update As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewLeftSection_MarketGroups As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Markets As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMarkets_Add As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMarkets_MoveUp As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMarkets_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMarkets_MoveDown As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewRightSection_MarketGroupMarkets As WinForm.MVC.Presentation.Controls.DataGridView
    End Class

End Namespace

