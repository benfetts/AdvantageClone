Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class GLReportTemplateImportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GLReportTemplateImportForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Import = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_UserDefinedReportContentsFile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_UserDefinedReportContentsFile = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_CurrentAction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CurrentActionDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarForm_CurrentAction = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.ProgressBarForm_OverallProgress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.LabelForm_OverallProgress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_GLReportTemplateContentsFile = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_GLReportTemplateContentsFile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Import = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.RibbonBarMergeContainerForm_Options.SuspendLayout()
            Me.SuspendLayout()
            '
            'RibbonBarMergeContainerForm_Options
            '
            Me.RibbonBarMergeContainerForm_Options.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RibbonBarMergeContainerForm_Options.Controls.Add(Me.RibbonBarOptions_Actions)
            Me.RibbonBarMergeContainerForm_Options.Location = New System.Drawing.Point(12, 12)
            Me.RibbonBarMergeContainerForm_Options.Name = "RibbonBarMergeContainerForm_Options"
            Me.RibbonBarMergeContainerForm_Options.RibbonTabText = "Options"
            Me.RibbonBarMergeContainerForm_Options.Size = New System.Drawing.Size(234, 98)
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
            Me.RibbonBarMergeContainerForm_Options.TabIndex = 4
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
            Me.RibbonBarOptions_Actions.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemActions_Import})
            Me.RibbonBarOptions_Actions.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
            Me.RibbonBarOptions_Actions.Location = New System.Drawing.Point(0, 0)
            Me.RibbonBarOptions_Actions.Name = "RibbonBarOptions_Actions"
            Me.RibbonBarOptions_Actions.SecurityEnabled = True
            Me.RibbonBarOptions_Actions.Size = New System.Drawing.Size(81, 98)
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
            'LabelForm_UserDefinedReportContentsFile
            '
            Me.LabelForm_UserDefinedReportContentsFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_UserDefinedReportContentsFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_UserDefinedReportContentsFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_UserDefinedReportContentsFile.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_UserDefinedReportContentsFile.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelForm_UserDefinedReportContentsFile.Name = "LabelForm_UserDefinedReportContentsFile"
            Me.LabelForm_UserDefinedReportContentsFile.Size = New System.Drawing.Size(807, 20)
            Me.LabelForm_UserDefinedReportContentsFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_UserDefinedReportContentsFile.TabIndex = 5
            Me.LabelForm_UserDefinedReportContentsFile.Text = "User Defined Report Contents File (.repx):"
            '
            'TextBoxForm_UserDefinedReportContentsFile
            '
            Me.TextBoxForm_UserDefinedReportContentsFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_UserDefinedReportContentsFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_UserDefinedReportContentsFile.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_UserDefinedReportContentsFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_UserDefinedReportContentsFile.ButtonCustom.Visible = True
            Me.TextBoxForm_UserDefinedReportContentsFile.CheckSpellingOnValidate = False
            Me.TextBoxForm_UserDefinedReportContentsFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxForm_UserDefinedReportContentsFile.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_UserDefinedReportContentsFile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_UserDefinedReportContentsFile.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.REPX
            Me.TextBoxForm_UserDefinedReportContentsFile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_UserDefinedReportContentsFile.FocusHighlightEnabled = True
            Me.TextBoxForm_UserDefinedReportContentsFile.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_UserDefinedReportContentsFile.Location = New System.Drawing.Point(12, 90)
            Me.TextBoxForm_UserDefinedReportContentsFile.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxForm_UserDefinedReportContentsFile.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_UserDefinedReportContentsFile.Name = "TextBoxForm_UserDefinedReportContentsFile"
            Me.TextBoxForm_UserDefinedReportContentsFile.SecurityEnabled = True
            Me.TextBoxForm_UserDefinedReportContentsFile.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_UserDefinedReportContentsFile.Size = New System.Drawing.Size(807, 20)
            Me.TextBoxForm_UserDefinedReportContentsFile.StartingFolderName = Nothing
            Me.TextBoxForm_UserDefinedReportContentsFile.TabIndex = 6
            Me.TextBoxForm_UserDefinedReportContentsFile.TabOnEnter = True
            '
            'LabelForm_CurrentAction
            '
            Me.LabelForm_CurrentAction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CurrentAction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CurrentAction.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_CurrentAction.Name = "LabelForm_CurrentAction"
            Me.LabelForm_CurrentAction.Size = New System.Drawing.Size(78, 20)
            Me.LabelForm_CurrentAction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CurrentAction.TabIndex = 7
            Me.LabelForm_CurrentAction.Text = "Current Action:"
            '
            'LabelForm_CurrentActionDescription
            '
            Me.LabelForm_CurrentActionDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_CurrentActionDescription.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CurrentActionDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CurrentActionDescription.Location = New System.Drawing.Point(96, 116)
            Me.LabelForm_CurrentActionDescription.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelForm_CurrentActionDescription.Name = "LabelForm_CurrentActionDescription"
            Me.LabelForm_CurrentActionDescription.Size = New System.Drawing.Size(723, 20)
            Me.LabelForm_CurrentActionDescription.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CurrentActionDescription.TabIndex = 8
            '
            'ProgressBarForm_CurrentAction
            '
            Me.ProgressBarForm_CurrentAction.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.ProgressBarForm_CurrentAction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarForm_CurrentAction.Location = New System.Drawing.Point(12, 142)
            Me.ProgressBarForm_CurrentAction.Margin = New System.Windows.Forms.Padding(2)
            Me.ProgressBarForm_CurrentAction.Name = "ProgressBarForm_CurrentAction"
            Me.ProgressBarForm_CurrentAction.Size = New System.Drawing.Size(807, 23)
            Me.ProgressBarForm_CurrentAction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarForm_CurrentAction.TabIndex = 9
            Me.ProgressBarForm_CurrentAction.Text = "ProgressBar1"
            '
            'ProgressBarForm_OverallProgress
            '
            Me.ProgressBarForm_OverallProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.ProgressBarForm_OverallProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarForm_OverallProgress.Location = New System.Drawing.Point(12, 199)
            Me.ProgressBarForm_OverallProgress.Margin = New System.Windows.Forms.Padding(2)
            Me.ProgressBarForm_OverallProgress.Name = "ProgressBarForm_OverallProgress"
            Me.ProgressBarForm_OverallProgress.Size = New System.Drawing.Size(807, 23)
            Me.ProgressBarForm_OverallProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarForm_OverallProgress.TabIndex = 12
            Me.ProgressBarForm_OverallProgress.Text = "ProgressBar1"
            '
            'LabelForm_OverallProgress
            '
            Me.LabelForm_OverallProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_OverallProgress.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_OverallProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_OverallProgress.Location = New System.Drawing.Point(12, 173)
            Me.LabelForm_OverallProgress.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelForm_OverallProgress.Name = "LabelForm_OverallProgress"
            Me.LabelForm_OverallProgress.Size = New System.Drawing.Size(807, 20)
            Me.LabelForm_OverallProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_OverallProgress.TabIndex = 10
            Me.LabelForm_OverallProgress.Text = "Overall Progress:"
            '
            'TextBoxForm_Log
            '
            Me.TextBoxForm_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_Log.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_Log.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Log.CheckSpellingOnValidate = False
            Me.TextBoxForm_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Log.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Log.FocusHighlightEnabled = True
            Me.TextBoxForm_Log.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_Log.Location = New System.Drawing.Point(12, 228)
            Me.TextBoxForm_Log.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxForm_Log.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Log.Multiline = True
            Me.TextBoxForm_Log.Name = "TextBoxForm_Log"
            Me.TextBoxForm_Log.ReadOnly = True
            Me.TextBoxForm_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.TextBoxForm_Log.SecurityEnabled = True
            Me.TextBoxForm_Log.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Log.Size = New System.Drawing.Size(807, 84)
            Me.TextBoxForm_Log.StartingFolderName = Nothing
            Me.TextBoxForm_Log.TabIndex = 13
            Me.TextBoxForm_Log.TabOnEnter = True
            '
            'TextBoxForm_GLReportTemplateContentsFile
            '
            Me.TextBoxForm_GLReportTemplateContentsFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_GLReportTemplateContentsFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_GLReportTemplateContentsFile.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_GLReportTemplateContentsFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_GLReportTemplateContentsFile.ButtonCustom.Visible = True
            Me.TextBoxForm_GLReportTemplateContentsFile.CheckSpellingOnValidate = False
            Me.TextBoxForm_GLReportTemplateContentsFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxForm_GLReportTemplateContentsFile.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_GLReportTemplateContentsFile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_GLReportTemplateContentsFile.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.XML
            Me.TextBoxForm_GLReportTemplateContentsFile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_GLReportTemplateContentsFile.FocusHighlightEnabled = True
            Me.TextBoxForm_GLReportTemplateContentsFile.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_GLReportTemplateContentsFile.Location = New System.Drawing.Point(12, 38)
            Me.TextBoxForm_GLReportTemplateContentsFile.Margin = New System.Windows.Forms.Padding(2)
            Me.TextBoxForm_GLReportTemplateContentsFile.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_GLReportTemplateContentsFile.Name = "TextBoxForm_GLReportTemplateContentsFile"
            Me.TextBoxForm_GLReportTemplateContentsFile.SecurityEnabled = True
            Me.TextBoxForm_GLReportTemplateContentsFile.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_GLReportTemplateContentsFile.Size = New System.Drawing.Size(807, 20)
            Me.TextBoxForm_GLReportTemplateContentsFile.StartingFolderName = Nothing
            Me.TextBoxForm_GLReportTemplateContentsFile.TabIndex = 15
            Me.TextBoxForm_GLReportTemplateContentsFile.TabOnEnter = True
            '
            'LabelForm_GLReportTemplateContentsFile
            '
            Me.LabelForm_GLReportTemplateContentsFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_GLReportTemplateContentsFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GLReportTemplateContentsFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GLReportTemplateContentsFile.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_GLReportTemplateContentsFile.Margin = New System.Windows.Forms.Padding(2)
            Me.LabelForm_GLReportTemplateContentsFile.Name = "LabelForm_GLReportTemplateContentsFile"
            Me.LabelForm_GLReportTemplateContentsFile.Size = New System.Drawing.Size(807, 20)
            Me.LabelForm_GLReportTemplateContentsFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GLReportTemplateContentsFile.TabIndex = 14
            Me.LabelForm_GLReportTemplateContentsFile.Text = "GL Report Template Contents File (.xml):"
            '
            'ButtonForm_Import
            '
            Me.ButtonForm_Import.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Import.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Import.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Import.Location = New System.Drawing.Point(744, 90)
            Me.ButtonForm_Import.Name = "ButtonForm_Import"
            Me.ButtonForm_Import.SecurityEnabled = True
            Me.ButtonForm_Import.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Import.TabIndex = 16
            Me.ButtonForm_Import.Text = "Import"
            '
            'GLReportTemplateImportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(831, 324)
            Me.Controls.Add(Me.TextBoxForm_UserDefinedReportContentsFile)
            Me.Controls.Add(Me.ButtonForm_Import)
            Me.Controls.Add(Me.TextBoxForm_GLReportTemplateContentsFile)
            Me.Controls.Add(Me.LabelForm_GLReportTemplateContentsFile)
            Me.Controls.Add(Me.TextBoxForm_Log)
            Me.Controls.Add(Me.ProgressBarForm_OverallProgress)
            Me.Controls.Add(Me.LabelForm_OverallProgress)
            Me.Controls.Add(Me.ProgressBarForm_CurrentAction)
            Me.Controls.Add(Me.LabelForm_CurrentActionDescription)
            Me.Controls.Add(Me.LabelForm_CurrentAction)
            Me.Controls.Add(Me.LabelForm_UserDefinedReportContentsFile)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(5)
            Me.Name = "GLReportTemplateImportForm"
            Me.Text = "GL Report Import"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ProgressBarForm_CurrentAction As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents ProgressBarForm_OverallProgress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Import As DevComponents.DotNetBar.ButtonItem
        Private WithEvents LabelForm_UserDefinedReportContentsFile As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents TextBoxForm_UserDefinedReportContentsFile As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents LabelForm_CurrentAction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_CurrentActionDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_OverallProgress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents TextBoxForm_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents TextBoxForm_GLReportTemplateContentsFile As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents LabelForm_GLReportTemplateContentsFile As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Import As WinForm.MVC.Presentation.Controls.Button
    End Class

End Namespace