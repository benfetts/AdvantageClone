Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsReceivableStatementSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsReceivableStatementSetupForm))
            Me.TabControlForm_ARStatementSetup = New AdvantageFramework.WinForm.Presentation.Controls.TabControl()
            Me.TabControlPanelStatementCommentsTab_StatementComments = New DevComponents.DotNetBar.TabControlPanel()
            Me.TextBoxStatementComments_Comments = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TabItemARStatementSetup_StatementCommentsTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelClientSetupTab_ClientSetup = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewClientSetup_ClientARStatement = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemARStatementSetup_ClientSetupTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.TabControlPanelProductSetupTab_ProductSetup = New DevComponents.DotNetBar.TabControlPanel()
            Me.DataGridViewProductSetup_ProductARStatement = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TabItemARStatementSetup_ProductSetupTab = New DevComponents.DotNetBar.TabItem(Me.components)
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Comments = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemComments_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemComments_SpellCheck = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Product = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemProduct_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemProduct_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemProduct_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Client = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemClient_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemClient_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemClient_Cancel = New DevComponents.DotNetBar.ButtonItem()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.TabControlForm_ARStatementSetup, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.TabControlForm_ARStatementSetup.SuspendLayout()
            Me.TabControlPanelStatementCommentsTab_StatementComments.SuspendLayout()
            Me.TabControlPanelClientSetupTab_ClientSetup.SuspendLayout()
            Me.TabControlPanelProductSetupTab_ProductSetup.SuspendLayout()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'TabControlForm_ARStatementSetup
            '
            Me.TabControlForm_ARStatementSetup.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TabControlForm_ARStatementSetup.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
            Me.TabControlForm_ARStatementSetup.CanReorderTabs = False
            Me.TabControlForm_ARStatementSetup.Controls.Add(Me.TabControlPanelStatementCommentsTab_StatementComments)
            Me.TabControlForm_ARStatementSetup.Controls.Add(Me.TabControlPanelClientSetupTab_ClientSetup)
            Me.TabControlForm_ARStatementSetup.Controls.Add(Me.TabControlPanelProductSetupTab_ProductSetup)
            Me.TabControlForm_ARStatementSetup.Location = New System.Drawing.Point(12, 12)
            Me.TabControlForm_ARStatementSetup.Name = "TabControlForm_ARStatementSetup"
            Me.TabControlForm_ARStatementSetup.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
            Me.TabControlForm_ARStatementSetup.SelectedTabIndex = 0
            Me.TabControlForm_ARStatementSetup.Size = New System.Drawing.Size(950, 447)
            Me.TabControlForm_ARStatementSetup.Style = DevComponents.DotNetBar.eTabStripStyle.Metro
            Me.TabControlForm_ARStatementSetup.TabIndex = 22
            Me.TabControlForm_ARStatementSetup.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
            Me.TabControlForm_ARStatementSetup.Tabs.Add(Me.TabItemARStatementSetup_ClientSetupTab)
            Me.TabControlForm_ARStatementSetup.Tabs.Add(Me.TabItemARStatementSetup_ProductSetupTab)
            Me.TabControlForm_ARStatementSetup.Tabs.Add(Me.TabItemARStatementSetup_StatementCommentsTab)
            '
            'TabControlPanelStatementCommentsTab_StatementComments
            '
            Me.TabControlPanelStatementCommentsTab_StatementComments.Controls.Add(Me.TextBoxStatementComments_Comments)
            Me.TabControlPanelStatementCommentsTab_StatementComments.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelStatementCommentsTab_StatementComments.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelStatementCommentsTab_StatementComments.Name = "TabControlPanelStatementCommentsTab_StatementComments"
            Me.TabControlPanelStatementCommentsTab_StatementComments.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelStatementCommentsTab_StatementComments.Size = New System.Drawing.Size(950, 425)
            Me.TabControlPanelStatementCommentsTab_StatementComments.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelStatementCommentsTab_StatementComments.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelStatementCommentsTab_StatementComments.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelStatementCommentsTab_StatementComments.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelStatementCommentsTab_StatementComments.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelStatementCommentsTab_StatementComments.Style.GradientAngle = 90
            Me.TabControlPanelStatementCommentsTab_StatementComments.TabIndex = 8
            Me.TabControlPanelStatementCommentsTab_StatementComments.TabItem = Me.TabItemARStatementSetup_StatementCommentsTab
            '
            'TextBoxStatementComments_Comments
            '
            Me.TextBoxStatementComments_Comments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxStatementComments_Comments.Border.Class = "TextBoxBorder"
            Me.TextBoxStatementComments_Comments.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxStatementComments_Comments.CheckSpellingOnValidate = False
            Me.TextBoxStatementComments_Comments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxStatementComments_Comments.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxStatementComments_Comments.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxStatementComments_Comments.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxStatementComments_Comments.FocusHighlightEnabled = True
            Me.TextBoxStatementComments_Comments.Location = New System.Drawing.Point(6, 6)
            Me.TextBoxStatementComments_Comments.Multiline = True
            Me.TextBoxStatementComments_Comments.Name = "TextBoxStatementComments_Comments"
            Me.TextBoxStatementComments_Comments.Size = New System.Drawing.Size(938, 413)
            Me.TextBoxStatementComments_Comments.TabIndex = 0
            Me.TextBoxStatementComments_Comments.TabOnEnter = False
            '
            'TabItemARStatementSetup_StatementCommentsTab
            '
            Me.TabItemARStatementSetup_StatementCommentsTab.AttachedControl = Me.TabControlPanelStatementCommentsTab_StatementComments
            Me.TabItemARStatementSetup_StatementCommentsTab.Name = "TabItemARStatementSetup_StatementCommentsTab"
            Me.TabItemARStatementSetup_StatementCommentsTab.Text = "Statement Comments"
            '
            'TabControlPanelClientSetupTab_ClientSetup
            '
            Me.TabControlPanelClientSetupTab_ClientSetup.Controls.Add(Me.DataGridViewClientSetup_ClientARStatement)
            Me.TabControlPanelClientSetupTab_ClientSetup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelClientSetupTab_ClientSetup.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelClientSetupTab_ClientSetup.Name = "TabControlPanelClientSetupTab_ClientSetup"
            Me.TabControlPanelClientSetupTab_ClientSetup.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelClientSetupTab_ClientSetup.Size = New System.Drawing.Size(950, 425)
            Me.TabControlPanelClientSetupTab_ClientSetup.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelClientSetupTab_ClientSetup.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelClientSetupTab_ClientSetup.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelClientSetupTab_ClientSetup.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelClientSetupTab_ClientSetup.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelClientSetupTab_ClientSetup.Style.GradientAngle = 90
            Me.TabControlPanelClientSetupTab_ClientSetup.TabIndex = 1
            Me.TabControlPanelClientSetupTab_ClientSetup.TabItem = Me.TabItemARStatementSetup_ClientSetupTab
            '
            'DataGridViewClientSetup_ClientARStatement
            '
            Me.DataGridViewClientSetup_ClientARStatement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewClientSetup_ClientARStatement.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewClientSetup_ClientARStatement.ItemDescription = ""
            Me.DataGridViewClientSetup_ClientARStatement.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewClientSetup_ClientARStatement.MultiSelect = True
            Me.DataGridViewClientSetup_ClientARStatement.Name = "DataGridViewClientSetup_ClientARStatement"
            Me.DataGridViewClientSetup_ClientARStatement.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewClientSetup_ClientARStatement.ShowSelectDeselectAllButtons = False
            Me.DataGridViewClientSetup_ClientARStatement.Size = New System.Drawing.Size(938, 413)
            Me.DataGridViewClientSetup_ClientARStatement.TabIndex = 5
            '
            'TabItemARStatementSetup_ClientSetupTab
            '
            Me.TabItemARStatementSetup_ClientSetupTab.AttachedControl = Me.TabControlPanelClientSetupTab_ClientSetup
            Me.TabItemARStatementSetup_ClientSetupTab.Name = "TabItemARStatementSetup_ClientSetupTab"
            Me.TabItemARStatementSetup_ClientSetupTab.Text = "Client Setup"
            '
            'TabControlPanelProductSetupTab_ProductSetup
            '
            Me.TabControlPanelProductSetupTab_ProductSetup.Controls.Add(Me.DataGridViewProductSetup_ProductARStatement)
            Me.TabControlPanelProductSetupTab_ProductSetup.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TabControlPanelProductSetupTab_ProductSetup.Location = New System.Drawing.Point(0, 22)
            Me.TabControlPanelProductSetupTab_ProductSetup.Name = "TabControlPanelProductSetupTab_ProductSetup"
            Me.TabControlPanelProductSetupTab_ProductSetup.Padding = New System.Windows.Forms.Padding(1)
            Me.TabControlPanelProductSetupTab_ProductSetup.Size = New System.Drawing.Size(950, 425)
            Me.TabControlPanelProductSetupTab_ProductSetup.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(253, Byte), Integer), CType(CType(253, Byte), Integer), CType(CType(254, Byte), Integer))
            Me.TabControlPanelProductSetupTab_ProductSetup.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(157, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(227, Byte), Integer))
            Me.TabControlPanelProductSetupTab_ProductSetup.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
            Me.TabControlPanelProductSetupTab_ProductSetup.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(146, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(199, Byte), Integer))
            Me.TabControlPanelProductSetupTab_ProductSetup.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
                Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
            Me.TabControlPanelProductSetupTab_ProductSetup.Style.GradientAngle = 90
            Me.TabControlPanelProductSetupTab_ProductSetup.TabIndex = 5
            Me.TabControlPanelProductSetupTab_ProductSetup.TabItem = Me.TabItemARStatementSetup_ProductSetupTab
            '
            'DataGridViewProductSetup_ProductARStatement
            '
            Me.DataGridViewProductSetup_ProductARStatement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewProductSetup_ProductARStatement.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewProductSetup_ProductARStatement.DataSource = Nothing
            Me.DataGridViewProductSetup_ProductARStatement.ItemDescription = ""
            Me.DataGridViewProductSetup_ProductARStatement.Location = New System.Drawing.Point(6, 6)
            Me.DataGridViewProductSetup_ProductARStatement.MultiSelect = True
            Me.DataGridViewProductSetup_ProductARStatement.Name = "DataGridViewProductSetup_ProductARStatement"
            Me.DataGridViewProductSetup_ProductARStatement.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewProductSetup_ProductARStatement.ShowSelectDeselectAllButtons = False
            Me.DataGridViewProductSetup_ProductARStatement.Size = New System.Drawing.Size(938, 413)
            Me.DataGridViewProductSetup_ProductARStatement.TabIndex = 24
            '
            'TabItemARStatementSetup_ProductSetupTab
            '
            Me.TabItemARStatementSetup_ProductSetupTab.AttachedControl = Me.TabControlPanelProductSetupTab_ProductSetup
            Me.TabItemARStatementSetup_ProductSetupTab.Name = "TabItemARStatementSetup_ProductSetupTab"
            Me.TabItemARStatementSetup_ProductSetupTab.Text = "Product Setup"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Comments)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Product)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Client)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(301, 153)
            Me.RibbonBarMergeContainerForm_Options.MergeRibbonGroupName = "RibbonTabGroupDynamicReport"
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(496, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 23
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Comments
            '
            Me.RibbonBarOptions_Comments.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Comments.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_Comments.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Comments.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_Comments.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Comments.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Comments.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Comments.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemComments_Save, Me.ButtonItemComments_SpellCheck})
            Me.RibbonBarOptions_Comments.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Comments.Location = New System.Drawing.Point(290, 0)
            Me.RibbonBarOptions_Comments.Name = "RibbonBarOptions_Comments"
            Me.RibbonBarOptions_Comments.Size = New System.Drawing.Size(145, 98)
            Me.RibbonBarOptions_Comments.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Comments.TabIndex = 2
            Me.RibbonBarOptions_Comments.Text = "Comments"
            '
            '
            '
            Me.RibbonBarOptions_Comments.TitleStyle.Class = ""
            Me.RibbonBarOptions_Comments.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Comments.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_Comments.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Comments.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemComments_Save
            '
            Me.ButtonItemComments_Save.BeginGroup = True
            Me.ButtonItemComments_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemComments_Save.Name = "ButtonItemComments_Save"
            Me.ButtonItemComments_Save.RibbonWordWrap = False
            Me.ButtonItemComments_Save.SubItemsExpandWidth = 14
            Me.ButtonItemComments_Save.Text = "Save"
            '
            'ButtonItemComments_SpellCheck
            '
            Me.ButtonItemComments_SpellCheck.BeginGroup = True
            Me.ButtonItemComments_SpellCheck.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemComments_SpellCheck.Name = "ButtonItemComments_SpellCheck"
            Me.ButtonItemComments_SpellCheck.RibbonWordWrap = False
            Me.ButtonItemComments_SpellCheck.SubItemsExpandWidth = 14
            Me.ButtonItemComments_SpellCheck.Text = "Spell Check"
            '
            'RibbonBarOptions_Product
            '
            Me.RibbonBarOptions_Product.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Product.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_Product.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Product.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_Product.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Product.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Product.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Product.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemProduct_Save, Me.ButtonItemProduct_Delete, Me.ButtonItemProduct_Cancel})
            Me.RibbonBarOptions_Product.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Product.Location = New System.Drawing.Point(145, 0)
            Me.RibbonBarOptions_Product.Name = "RibbonBarOptions_Product"
            Me.RibbonBarOptions_Product.Size = New System.Drawing.Size(145, 98)
            Me.RibbonBarOptions_Product.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Product.TabIndex = 1
            Me.RibbonBarOptions_Product.Text = "Product"
            '
            '
            '
            Me.RibbonBarOptions_Product.TitleStyle.Class = ""
            Me.RibbonBarOptions_Product.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Product.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_Product.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Product.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemProduct_Save
            '
            Me.ButtonItemProduct_Save.BeginGroup = True
            Me.ButtonItemProduct_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Save.Name = "ButtonItemProduct_Save"
            Me.ButtonItemProduct_Save.RibbonWordWrap = False
            Me.ButtonItemProduct_Save.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Save.Text = "Save"
            '
            'ButtonItemProduct_Delete
            '
            Me.ButtonItemProduct_Delete.BeginGroup = True
            Me.ButtonItemProduct_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Delete.Name = "ButtonItemProduct_Delete"
            Me.ButtonItemProduct_Delete.RibbonWordWrap = False
            Me.ButtonItemProduct_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Delete.Text = "Delete"
            '
            'ButtonItemProduct_Cancel
            '
            Me.ButtonItemProduct_Cancel.BeginGroup = True
            Me.ButtonItemProduct_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemProduct_Cancel.Name = "ButtonItemProduct_Cancel"
            Me.ButtonItemProduct_Cancel.RibbonWordWrap = False
            Me.ButtonItemProduct_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemProduct_Cancel.Text = "Cancel"
            '
            'RibbonBarOptions_Client
            '
            Me.RibbonBarOptions_Client.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Client.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_Client.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Client.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_Client.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Client.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Client.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Client.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemClient_Save, Me.ButtonItemClient_Delete, Me.ButtonItemClient_Cancel})
            Me.RibbonBarOptions_Client.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Client.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Client.Name = "RibbonBarOptions_Client"
            Me.RibbonBarOptions_Client.Size = New System.Drawing.Size(145, 98)
            Me.RibbonBarOptions_Client.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Client.TabIndex = 0
            Me.RibbonBarOptions_Client.Text = "Client"
            '
            '
            '
            Me.RibbonBarOptions_Client.TitleStyle.Class = ""
            Me.RibbonBarOptions_Client.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Client.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_Client.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Client.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemClient_Save
            '
            Me.ButtonItemClient_Save.BeginGroup = True
            Me.ButtonItemClient_Save.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClient_Save.Name = "ButtonItemClient_Save"
            Me.ButtonItemClient_Save.RibbonWordWrap = False
            Me.ButtonItemClient_Save.SubItemsExpandWidth = 14
            Me.ButtonItemClient_Save.Text = "Save"
            '
            'ButtonItemClient_Delete
            '
            Me.ButtonItemClient_Delete.BeginGroup = True
            Me.ButtonItemClient_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClient_Delete.Name = "ButtonItemClient_Delete"
            Me.ButtonItemClient_Delete.RibbonWordWrap = False
            Me.ButtonItemClient_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemClient_Delete.Text = "Delete"
            '
            'ButtonItemClient_Cancel
            '
            Me.ButtonItemClient_Cancel.BeginGroup = True
            Me.ButtonItemClient_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemClient_Cancel.Name = "ButtonItemClient_Cancel"
            Me.ButtonItemClient_Cancel.RibbonWordWrap = False
            Me.ButtonItemClient_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemClient_Cancel.Text = "Cancel"
            '
            'AccountsReceivableStatementSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(974, 471)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TabControlForm_ARStatementSetup)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AccountsReceivableStatementSetupForm"
            Me.Text = "Accounts Receivable Statement Setup"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.TabControlForm_ARStatementSetup, System.ComponentModel.ISupportInitialize).EndInit()
            Me.TabControlForm_ARStatementSetup.ResumeLayout(False)
            Me.TabControlPanelStatementCommentsTab_StatementComments.ResumeLayout(False)
            Me.TabControlPanelClientSetupTab_ClientSetup.ResumeLayout(False)
            Me.TabControlPanelProductSetupTab_ProductSetup.ResumeLayout(False)
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TabControlForm_ARStatementSetup As AdvantageFramework.WinForm.Presentation.Controls.TabControl
        Friend WithEvents TabControlPanelClientSetupTab_ClientSetup As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemARStatementSetup_ClientSetupTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelProductSetupTab_ProductSetup As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemARStatementSetup_ProductSetupTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents TabControlPanelStatementCommentsTab_StatementComments As DevComponents.DotNetBar.TabControlPanel
        Friend WithEvents TabItemARStatementSetup_StatementCommentsTab As DevComponents.DotNetBar.TabItem
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Client As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemClient_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemClient_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemClient_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewClientSetup_ClientARStatement As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents DataGridViewProductSetup_ProductARStatement As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Comments As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemComments_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemComments_SpellCheck As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents RibbonBarOptions_Product As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemProduct_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemProduct_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemProduct_Cancel As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents TextBoxStatementComments_Comments As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    End Class

End Namespace

