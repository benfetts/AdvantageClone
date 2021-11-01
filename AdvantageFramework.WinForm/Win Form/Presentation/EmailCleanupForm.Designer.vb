Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmailCleanupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmailCleanupForm))
            Me.TextBoxForm_EmailFile = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_EmailFile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Import = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Process = New DevComponents.DotNetBar.ButtonItem()
            Me.DataGridViewForm_Emails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'TextBoxForm_EmailFile
            '
            Me.TextBoxForm_EmailFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_EmailFile.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_EmailFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_EmailFile.ButtonCustom.Visible = True
            Me.TextBoxForm_EmailFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxForm_EmailFile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_EmailFile.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.CSV
            Me.TextBoxForm_EmailFile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_EmailFile.FocusHighlightEnabled = True
            Me.TextBoxForm_EmailFile.Location = New System.Drawing.Point(75, 12)
            Me.TextBoxForm_EmailFile.Name = "TextBoxForm_EmailFile"
            Me.TextBoxForm_EmailFile.Size = New System.Drawing.Size(678, 20)
            Me.TextBoxForm_EmailFile.TabIndex = 1
            Me.TextBoxForm_EmailFile.TabOnEnter = True
            '
            'LabelForm_EmailFile
            '
            Me.LabelForm_EmailFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EmailFile.BackgroundStyle.Class = ""
            Me.LabelForm_EmailFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EmailFile.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_EmailFile.Name = "LabelForm_EmailFile"
            Me.LabelForm_EmailFile.Size = New System.Drawing.Size(57, 20)
            Me.LabelForm_EmailFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EmailFile.TabIndex = 0
            Me.LabelForm_EmailFile.Text = "Email File:"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(369, 64)
            Me.RibbonBarMergeContainerForm_Options.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(209, 121)
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Import, Me.ButtonItemActions_Process})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Margin = New System.Windows.Forms.Padding(4)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(108, 121)
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
            Me.RibbonBarOptions_Actions.VerticalItemAlignment = DevComponents.DotNetBar.eVerticalItemsAlignment.Bottom
            '
            'ButtonItemActions_Import
            '
            Me.ButtonItemActions_Import.BeginGroup = True
            Me.ButtonItemActions_Import.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Import.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Import.Name = "ButtonItemActions_Import"
            Me.ButtonItemActions_Import.RibbonWordWrap = False
            Me.ButtonItemActions_Import.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Import.Text = "Import"
            '
            'ButtonItemActions_Process
            '
            Me.ButtonItemActions_Process.BeginGroup = True
            Me.ButtonItemActions_Process.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Process.Enabled = False
            Me.ButtonItemActions_Process.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Process.Name = "ButtonItemActions_Process"
            Me.ButtonItemActions_Process.RibbonWordWrap = False
            Me.ButtonItemActions_Process.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Process.Text = "Process"
            '
            'DataGridViewForm_Emails
            '
            Me.DataGridViewForm_Emails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Emails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Emails.ItemDescription = "Email Address(es)"
            Me.DataGridViewForm_Emails.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_Emails.MultiSelect = True
            Me.DataGridViewForm_Emails.Name = "DataGridViewForm_Emails"
            Me.DataGridViewForm_Emails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Emails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Emails.Size = New System.Drawing.Size(741, 409)
            Me.DataGridViewForm_Emails.TabIndex = 2
            '
            'EmailCleanupForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(765, 459)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.LabelForm_EmailFile)
            Me.Controls.Add(Me.TextBoxForm_EmailFile)
            Me.Controls.Add(Me.DataGridViewForm_Emails)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmailCleanupForm"
            Me.Text = "Email Cleanup"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxForm_EmailFile As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_EmailFile As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Import As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Process As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents DataGridViewForm_Emails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
    End Class

End Namespace

