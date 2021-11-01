Namespace Maintenance.Management.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OverheadAccountSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OverheadAccountSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Details = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemDetails_Delete = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.ButtonItemDetails_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Add = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.PanelForm_LeftSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DataGridViewLeftSection_OverheadAccounts = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ExpandableSplitterControlForm_LeftRight = New AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl()
            Me.PanelForm_RightSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.OverheadAccountControlRightSection_OverheadAccount = New AdvantageFramework.WinForm.Presentation.Controls.OverheadAccountControl()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            CType(Me.PanelForm_LeftSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_LeftSection.SuspendLayout()
            CType(Me.PanelForm_RightSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_RightSection.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Details)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 5)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(467, 95)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 3
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'RibbonBarOptions_Details
            '
            Me.RibbonBarOptions_Details.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_Details.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_Details.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_Details.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_Details.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemDetails_Delete, Me.ButtonItemDetails_Cancel})
            Me.RibbonBarOptions_Details.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Details.Location = New System.Drawing.Point(131, 0)
            Me.RibbonBarOptions_Details.Name = "RibbonBarOptions_Details"
            Me.RibbonBarOptions_Details.Size = New System.Drawing.Size(216, 95)
            Me.RibbonBarOptions_Details.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Details.TabIndex = 2
            Me.RibbonBarOptions_Details.Text = "Details"
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyle.Class = ""
            Me.RibbonBarOptions_Details.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_Details.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_Details.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_Details.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemDetails_Delete
            '
            Me.ButtonItemDetails_Delete.BeginGroup = True
            Me.ButtonItemDetails_Delete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Delete.Name = "ButtonItemDetails_Delete"
            Me.ButtonItemDetails_Delete.RibbonWordWrap = False
            Me.ButtonItemDetails_Delete.SecurityEnabled = True
            Me.ButtonItemDetails_Delete.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Delete.Text = "Delete"
            '
            'ButtonItemDetails_Cancel
            '
            Me.ButtonItemDetails_Cancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemDetails_Cancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemDetails_Cancel.Name = "ButtonItemDetails_Cancel"
            Me.ButtonItemDetails_Cancel.SecurityEnabled = True
            Me.ButtonItemDetails_Cancel.Stretch = True
            Me.ButtonItemDetails_Cancel.SubItemsExpandWidth = 14
            Me.ButtonItemDetails_Cancel.Text = "Cancel"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Add, Me.ButtonItemActions_Save, Me.ButtonItemActions_Delete})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(131, 95)
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
            'ButtonItemActions_Add
            '
            Me.ButtonItemActions_Add.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Add.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Add.Name = "ButtonItemActions_Add"
            Me.ButtonItemActions_Add.RibbonWordWrap = False
            Me.ButtonItemActions_Add.Stretch = True
            Me.ButtonItemActions_Add.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Add.Text = "Add"
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
            'PanelForm_LeftSection
            '
            Me.PanelForm_LeftSection.Controls.Add(Me.DataGridViewLeftSection_OverheadAccounts)
            Me.PanelForm_LeftSection.Dock = System.Windows.Forms.DockStyle.Left
            Me.PanelForm_LeftSection.Location = New System.Drawing.Point(0, 0)
            Me.PanelForm_LeftSection.Name = "PanelForm_LeftSection"
            Me.PanelForm_LeftSection.Size = New System.Drawing.Size(403, 492)
            Me.PanelForm_LeftSection.TabIndex = 4
            '
            'DataGridViewLeftSection_OverheadAccounts
            '
            Me.DataGridViewLeftSection_OverheadAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewLeftSection_OverheadAccounts.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewLeftSection_OverheadAccounts.ItemDescription = "Overhead Accounts"
            Me.DataGridViewLeftSection_OverheadAccounts.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewLeftSection_OverheadAccounts.MultiSelect = False
            Me.DataGridViewLeftSection_OverheadAccounts.Name = "DataGridViewLeftSection_OverheadAccounts"
            Me.DataGridViewLeftSection_OverheadAccounts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewLeftSection_OverheadAccounts.ShowSelectDeselectAllButtons = False
            Me.DataGridViewLeftSection_OverheadAccounts.Size = New System.Drawing.Size(385, 468)
            Me.DataGridViewLeftSection_OverheadAccounts.TabIndex = 0
            Me.DataGridViewLeftSection_OverheadAccounts.UseEmbeddedNavigator = False
            Me.DataGridViewLeftSection_OverheadAccounts.ViewCaptionHeight = -1
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
            Me.ExpandableSplitterControlForm_LeftRight.Location = New System.Drawing.Point(403, 0)
            Me.ExpandableSplitterControlForm_LeftRight.Name = "ExpandableSplitterControlForm_LeftRight"
            Me.ExpandableSplitterControlForm_LeftRight.Size = New System.Drawing.Size(6, 492)
            Me.ExpandableSplitterControlForm_LeftRight.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007
            Me.ExpandableSplitterControlForm_LeftRight.TabIndex = 5
            Me.ExpandableSplitterControlForm_LeftRight.TabStop = False
            '
            'PanelForm_RightSection
            '
            Me.PanelForm_RightSection.Controls.Add(Me.OverheadAccountControlRightSection_OverheadAccount)
            Me.PanelForm_RightSection.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelForm_RightSection.Location = New System.Drawing.Point(409, 0)
            Me.PanelForm_RightSection.Name = "PanelForm_RightSection"
            Me.PanelForm_RightSection.Size = New System.Drawing.Size(532, 492)
            Me.PanelForm_RightSection.TabIndex = 7
            '
            'OverheadAccountControlRightSection_OverheadAccount
            '
            Me.OverheadAccountControlRightSection_OverheadAccount.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.OverheadAccountControlRightSection_OverheadAccount.Location = New System.Drawing.Point(6, 12)
            Me.OverheadAccountControlRightSection_OverheadAccount.Name = "OverheadAccountControlRightSection_OverheadAccount"
            Me.OverheadAccountControlRightSection_OverheadAccount.Size = New System.Drawing.Size(514, 468)
            Me.OverheadAccountControlRightSection_OverheadAccount.TabIndex = 0
            '
            'OverheadAccountSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(941, 492)
            Me.Controls.Add(Me.PanelForm_RightSection)
            Me.Controls.Add(Me.ExpandableSplitterControlForm_LeftRight)
            Me.Controls.Add(Me.PanelForm_LeftSection)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "OverheadAccountSetupForm"
            Me.Text = "Overhead Account Maintenance"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
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
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents PanelForm_LeftSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewLeftSection_OverheadAccounts As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ExpandableSplitterControlForm_LeftRight As AdvantageFramework.WinForm.Presentation.Controls.ExpandableSplitterControl
        Friend WithEvents PanelForm_RightSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents RibbonBarOptions_Details As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemDetails_Delete As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents ButtonItemDetails_Cancel As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
        Friend WithEvents OverheadAccountControlRightSection_OverheadAccount As AdvantageFramework.WinForm.Presentation.Controls.OverheadAccountControl
    End Class

End Namespace

