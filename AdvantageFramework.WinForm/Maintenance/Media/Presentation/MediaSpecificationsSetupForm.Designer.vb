Namespace Maintenance.Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaSpecificationsSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaSpecificationsSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_MediaTypes = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemMediaTypes_Internet = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMediaTypes_Magazine = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMediaTypes_Newspaper = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemMediaTypes_OutOfHome = New DevComponents.DotNetBar.ButtonItem()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_MediaSpecifications = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_MediaTypes)
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(98, 126)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(473, 98)
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
            'RibbonBarOptions_MediaTypes
            '
            Me.RibbonBarOptions_MediaTypes.AutoOverflowEnabled = False
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.BackgroundMouseOverStyle.Class = ""
            Me.RibbonBarOptions_MediaTypes.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.BackgroundStyle.Class = ""
            Me.RibbonBarOptions_MediaTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaTypes.ContainerControlProcessDialogKey = True
            Me.RibbonBarOptions_MediaTypes.Dock = System.Windows.Forms.DockStyle.Left
            Me.RibbonBarOptions_MediaTypes.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemMediaTypes_Internet, Me.ButtonItemMediaTypes_Magazine, Me.ButtonItemMediaTypes_Newspaper, Me.ButtonItemMediaTypes_OutOfHome})
            Me.RibbonBarOptions_MediaTypes.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_MediaTypes.Location = New System.Drawing.Point(130, 0)
            Me.RibbonBarOptions_MediaTypes.Name = "RibbonBarOptions_MediaTypes"
            Me.RibbonBarOptions_MediaTypes.Size = New System.Drawing.Size(271, 98)
            Me.RibbonBarOptions_MediaTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_MediaTypes.TabIndex = 1
            Me.RibbonBarOptions_MediaTypes.Text = "Media Types"
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.TitleStyle.Class = ""
            Me.RibbonBarOptions_MediaTypes.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            '
            '
            '
            Me.RibbonBarOptions_MediaTypes.TitleStyleMouseOver.Class = ""
            Me.RibbonBarOptions_MediaTypes.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RibbonBarOptions_MediaTypes.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Middle
            '
            'ButtonItemMediaTypes_Internet
            '
            Me.ButtonItemMediaTypes_Internet.AutoCheckOnClick = True
            Me.ButtonItemMediaTypes_Internet.BeginGroup = True
            Me.ButtonItemMediaTypes_Internet.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaTypes_Internet.Checked = True
            Me.ButtonItemMediaTypes_Internet.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaTypes_Internet.Name = "ButtonItemMediaTypes_Internet"
            Me.ButtonItemMediaTypes_Internet.OptionGroup = "MediaTypes"
            Me.ButtonItemMediaTypes_Internet.RibbonWordWrap = False
            Me.ButtonItemMediaTypes_Internet.Stretch = True
            Me.ButtonItemMediaTypes_Internet.SubItemsExpandWidth = 14
            Me.ButtonItemMediaTypes_Internet.Text = "Internet"
            '
            'ButtonItemMediaTypes_Magazine
            '
            Me.ButtonItemMediaTypes_Magazine.AutoCheckOnClick = True
            Me.ButtonItemMediaTypes_Magazine.BeginGroup = True
            Me.ButtonItemMediaTypes_Magazine.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaTypes_Magazine.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaTypes_Magazine.Name = "ButtonItemMediaTypes_Magazine"
            Me.ButtonItemMediaTypes_Magazine.OptionGroup = "MediaTypes"
            Me.ButtonItemMediaTypes_Magazine.RibbonWordWrap = False
            Me.ButtonItemMediaTypes_Magazine.Stretch = True
            Me.ButtonItemMediaTypes_Magazine.SubItemsExpandWidth = 14
            Me.ButtonItemMediaTypes_Magazine.Text = "Magazine"
            '
            'ButtonItemMediaTypes_Newspaper
            '
            Me.ButtonItemMediaTypes_Newspaper.AutoCheckOnClick = True
            Me.ButtonItemMediaTypes_Newspaper.BeginGroup = True
            Me.ButtonItemMediaTypes_Newspaper.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaTypes_Newspaper.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaTypes_Newspaper.Name = "ButtonItemMediaTypes_Newspaper"
            Me.ButtonItemMediaTypes_Newspaper.OptionGroup = "MediaTypes"
            Me.ButtonItemMediaTypes_Newspaper.RibbonWordWrap = False
            Me.ButtonItemMediaTypes_Newspaper.Stretch = True
            Me.ButtonItemMediaTypes_Newspaper.SubItemsExpandWidth = 14
            Me.ButtonItemMediaTypes_Newspaper.Text = "Newspaper"
            '
            'ButtonItemMediaTypes_OutOfHome
            '
            Me.ButtonItemMediaTypes_OutOfHome.AutoCheckOnClick = True
            Me.ButtonItemMediaTypes_OutOfHome.BeginGroup = True
            Me.ButtonItemMediaTypes_OutOfHome.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemMediaTypes_OutOfHome.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemMediaTypes_OutOfHome.Name = "ButtonItemMediaTypes_OutOfHome"
            Me.ButtonItemMediaTypes_OutOfHome.OptionGroup = "MediaTypes"
            Me.ButtonItemMediaTypes_OutOfHome.RibbonWordWrap = False
            Me.ButtonItemMediaTypes_OutOfHome.Stretch = True
            Me.ButtonItemMediaTypes_OutOfHome.SubItemsExpandWidth = 14
            Me.ButtonItemMediaTypes_OutOfHome.Text = "Out Of Home"
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export, Me.ButtonItemActions_Save, Me.ButtonItemActions_Cancel})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(130, 98)
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
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.RibbonWordWrap = False
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
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
            'DataGridViewForm_MediaSpecifications
            '
            Me.DataGridViewForm_MediaSpecifications.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_MediaSpecifications.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_MediaSpecifications.ItemDescription = ""
            Me.DataGridViewForm_MediaSpecifications.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_MediaSpecifications.MultiSelect = True
            Me.DataGridViewForm_MediaSpecifications.Name = "DataGridViewForm_MediaSpecifications"
            Me.DataGridViewForm_MediaSpecifications.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_MediaSpecifications.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_MediaSpecifications.Size = New System.Drawing.Size(689, 397)
            Me.DataGridViewForm_MediaSpecifications.TabIndex = 4
            '
            'MediaSpecificationsSetupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(713, 421)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_MediaSpecifications)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaSpecificationsSetupForm"
            Me.Text = "Media Specs"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents DataGridViewForm_MediaSpecifications As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_MediaTypes As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemMediaTypes_Internet As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMediaTypes_Magazine As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMediaTypes_Newspaper As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemMediaTypes_OutOfHome As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace

