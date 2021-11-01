Namespace Exporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ExportYayPayInvoicesForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportYayPayInvoicesForm))
            Me.TextBoxForm_Folder = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelForm_Folder = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Export = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'TextBoxForm_Folder
            '
            Me.TextBoxForm_Folder.AgencyImportPath = Nothing
            Me.TextBoxForm_Folder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Folder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Folder.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Folder.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Folder.ButtonCustom.Visible = True
            Me.TextBoxForm_Folder.CheckSpellingOnValidate = False
            Me.TextBoxForm_Folder.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxForm_Folder.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Folder.DisplayName = ""
            Me.TextBoxForm_Folder.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Folder.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Folder.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Folder.FocusHighlightEnabled = True
            Me.TextBoxForm_Folder.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Folder.Location = New System.Drawing.Point(93, 13)
            Me.TextBoxForm_Folder.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Folder.Name = "TextBoxForm_Folder"
            Me.TextBoxForm_Folder.PreventEnterBeep = True
            Me.TextBoxForm_Folder.SecurityEnabled = True
            Me.TextBoxForm_Folder.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Folder.Size = New System.Drawing.Size(373, 20)
            Me.TextBoxForm_Folder.StartingFolderName = Nothing
            Me.TextBoxForm_Folder.TabIndex = 1
            Me.TextBoxForm_Folder.TabOnEnter = True
            '
            'LabelForm_Folder
            '
            Me.LabelForm_Folder.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Folder.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Folder.Location = New System.Drawing.Point(12, 13)
            Me.LabelForm_Folder.Name = "LabelForm_Folder"
            Me.LabelForm_Folder.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_Folder.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Folder.TabIndex = 0
            Me.LabelForm_Folder.Text = "Folder:"
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(15, -14)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(170, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 70
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Export})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(72, 98)
            Me.RibbonBarOptions_Actions.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarOptions_Actions.TabIndex = 4
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
            'ButtonItemActions_Export
            '
            Me.ButtonItemActions_Export.BeginGroup = True
            Me.ButtonItemActions_Export.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
            Me.ButtonItemActions_Export.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
            Me.ButtonItemActions_Export.Name = "ButtonItemActions_Export"
            Me.ButtonItemActions_Export.SecurityEnabled = True
            Me.ButtonItemActions_Export.Stretch = True
            Me.ButtonItemActions_Export.SubItemsExpandWidth = 14
            Me.ButtonItemActions_Export.Text = "Export"
            '
            'ExportYayPayInvoicesForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(478, 46)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.LabelForm_Folder)
            Me.Controls.Add(Me.TextBoxForm_Folder)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ExportYayPayInvoicesForm"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents TextBoxForm_Folder As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_Folder As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Friend WithEvents RibbonBarOptions_Actions As WinForm.Presentation.Controls.RibbonBar
        Friend WithEvents ButtonItemActions_Export As WinForm.Presentation.Controls.ButtonItem
    End Class

End Namespace
