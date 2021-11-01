Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class UserDefinedValueSetupForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserDefinedValueSetupForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.LabelForm_Label = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Label = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.CheckBoxForm_UseLookup = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.DataGridViewForm_UserDefinedValues = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Save = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Delete = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemActions_Cancel = New DevComponents.DotNetBar.ButtonItem()
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
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(67, 136)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(336, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 4
            Me.RibbonBarMergeContainerForm_Options.Visible = False
            '
            'LabelForm_Label
            '
            Me.LabelForm_Label.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Label.BackgroundStyle.Class = ""
            Me.LabelForm_Label.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Label.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Label.Name = "LabelForm_Label"
            Me.LabelForm_Label.Size = New System.Drawing.Size(34, 20)
            Me.LabelForm_Label.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Label.TabIndex = 5
            Me.LabelForm_Label.Text = "Label:"
            '
            'TextBoxForm_Label
            '
            Me.TextBoxForm_Label.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Label.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Label.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Label.CheckSpellingOnValidate = False
            Me.TextBoxForm_Label.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Label.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Label.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Label.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Label.FocusHighlightEnabled = True
            Me.TextBoxForm_Label.Location = New System.Drawing.Point(52, 12)
            Me.TextBoxForm_Label.Name = "TextBoxForm_Label"
            Me.TextBoxForm_Label.Size = New System.Drawing.Size(343, 20)
            Me.TextBoxForm_Label.TabIndex = 6
            Me.TextBoxForm_Label.TabOnEnter = True
            '
            'CheckBoxForm_UseLookup
            '
            Me.CheckBoxForm_UseLookup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_UseLookup.BackgroundStyle.Class = ""
            Me.CheckBoxForm_UseLookup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_UseLookup.CheckValue = 1
            Me.CheckBoxForm_UseLookup.CheckValueChecked = 0
            Me.CheckBoxForm_UseLookup.CheckValueUnchecked = 1
            Me.CheckBoxForm_UseLookup.ChildControls = CType(resources.GetObject("CheckBoxForm_UseLookup.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseLookup.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked0Unchecked1
            Me.CheckBoxForm_UseLookup.Location = New System.Drawing.Point(401, 12)
            Me.CheckBoxForm_UseLookup.Name = "CheckBoxForm_UseLookup"
            Me.CheckBoxForm_UseLookup.OldestSibling = Nothing
            Me.CheckBoxForm_UseLookup.SiblingControls = CType(resources.GetObject("CheckBoxForm_UseLookup.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_UseLookup.Size = New System.Drawing.Size(84, 20)
            Me.CheckBoxForm_UseLookup.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_UseLookup.TabIndex = 7
            Me.CheckBoxForm_UseLookup.Text = "Use Lookup"
            '
            'DataGridViewForm_UserDefinedValues
            '
            Me.DataGridViewForm_UserDefinedValues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_UserDefinedValues.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_UserDefinedValues.Enabled = False
            Me.DataGridViewForm_UserDefinedValues.ItemDescription = "User Defined Value(s)"
            Me.DataGridViewForm_UserDefinedValues.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_UserDefinedValues.MultiSelect = True
            Me.DataGridViewForm_UserDefinedValues.Name = "DataGridViewForm_UserDefinedValues"
            Me.DataGridViewForm_UserDefinedValues.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewForm_UserDefinedValues.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_UserDefinedValues.Size = New System.Drawing.Size(473, 320)
            Me.DataGridViewForm_UserDefinedValues.TabIndex = 8
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
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(209, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 1
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
            'BaseUserDefinedValueForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(497, 370)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.DataGridViewForm_UserDefinedValues)
            Me.Controls.Add(Me.TextBoxForm_Label)
            Me.Controls.Add(Me.LabelForm_Label)
            Me.Controls.Add(Me.CheckBoxForm_UseLookup)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "UserDefinedValueSetupForm"
            Me.Text = "User Defined Value"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents LabelForm_Label As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_Label As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxForm_UseLookup As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents DataGridViewForm_UserDefinedValues As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Save As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Delete As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemActions_Cancel As DevComponents.DotNetBar.ButtonItem
    End Class

End Namespace
