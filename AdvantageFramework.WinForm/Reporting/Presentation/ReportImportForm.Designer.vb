Namespace Reporting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ReportImportForm
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportImportForm))
            Me.RibbonBarMergeContainerForm_Options = New DevComponents.DotNetBar.RibbonBarMergeContainer()
            Me.RibbonBarOptions_Actions = New AdvantageFramework.WinForm.Presentation.Controls.RibbonBar()
            Me.ButtonItemActions_Import = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_ApplicationContentsFile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_ApplicationContentsFile = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_CurrentAction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_CurrentActionDescription = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarForm_CurrentAction = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.ProgressBarForm_OverallProgress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.LabelForm_OverallProgress = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
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
            'LabelForm_ApplicationContentsFile
            '
            Me.LabelForm_ApplicationContentsFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_ApplicationContentsFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_ApplicationContentsFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_ApplicationContentsFile.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_ApplicationContentsFile.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.LabelForm_ApplicationContentsFile.Name = "LabelForm_ApplicationContentsFile"
            Me.LabelForm_ApplicationContentsFile.Size = New System.Drawing.Size(807, 20)
            Me.LabelForm_ApplicationContentsFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_ApplicationContentsFile.TabIndex = 5
            Me.LabelForm_ApplicationContentsFile.Text = "Application Contents File (.repx):"
            '
            'TextBoxForm_ApplicationContentsFile
            '
            Me.TextBoxForm_ApplicationContentsFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxForm_ApplicationContentsFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxForm_ApplicationContentsFile.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_ApplicationContentsFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_ApplicationContentsFile.ButtonCustom.Visible = True
            Me.TextBoxForm_ApplicationContentsFile.CheckSpellingOnValidate = False
            Me.TextBoxForm_ApplicationContentsFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxForm_ApplicationContentsFile.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxForm_ApplicationContentsFile.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_ApplicationContentsFile.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.REPX
            Me.TextBoxForm_ApplicationContentsFile.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_ApplicationContentsFile.FocusHighlightEnabled = True
            Me.TextBoxForm_ApplicationContentsFile.ForeColor = System.Drawing.Color.Black
            Me.TextBoxForm_ApplicationContentsFile.Location = New System.Drawing.Point(12, 38)
            Me.TextBoxForm_ApplicationContentsFile.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.TextBoxForm_ApplicationContentsFile.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_ApplicationContentsFile.Name = "TextBoxForm_ApplicationContentsFile"
            Me.TextBoxForm_ApplicationContentsFile.SecurityEnabled = True
            Me.TextBoxForm_ApplicationContentsFile.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_ApplicationContentsFile.Size = New System.Drawing.Size(807, 20)
            Me.TextBoxForm_ApplicationContentsFile.StartingFolderName = Nothing
            Me.TextBoxForm_ApplicationContentsFile.TabIndex = 6
            Me.TextBoxForm_ApplicationContentsFile.TabOnEnter = True
            '
            'LabelForm_CurrentAction
            '
            Me.LabelForm_CurrentAction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CurrentAction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CurrentAction.Location = New System.Drawing.Point(12, 64)
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
            Me.LabelForm_CurrentActionDescription.Location = New System.Drawing.Point(96, 64)
            Me.LabelForm_CurrentActionDescription.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
            Me.ProgressBarForm_CurrentAction.Location = New System.Drawing.Point(12, 90)
            Me.ProgressBarForm_CurrentAction.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
            Me.ProgressBarForm_OverallProgress.Location = New System.Drawing.Point(12, 142)
            Me.ProgressBarForm_OverallProgress.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
            Me.LabelForm_OverallProgress.Location = New System.Drawing.Point(12, 116)
            Me.LabelForm_OverallProgress.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
            Me.TextBoxForm_Log.Location = New System.Drawing.Point(12, 171)
            Me.TextBoxForm_Log.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
            Me.TextBoxForm_Log.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Log.Multiline = True
            Me.TextBoxForm_Log.Name = "TextBoxForm_Log"
            Me.TextBoxForm_Log.ReadOnly = True
            Me.TextBoxForm_Log.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.TextBoxForm_Log.SecurityEnabled = True
            Me.TextBoxForm_Log.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Log.Size = New System.Drawing.Size(807, 141)
            Me.TextBoxForm_Log.StartingFolderName = Nothing
            Me.TextBoxForm_Log.TabIndex = 13
            Me.TextBoxForm_Log.TabOnEnter = True
            '
            'ButtonForm_Import
            '
            Me.ButtonForm_Import.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Import.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Import.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Import.Location = New System.Drawing.Point(744, 38)
            Me.ButtonForm_Import.Name = "ButtonForm_Import"
            Me.ButtonForm_Import.SecurityEnabled = True
            Me.ButtonForm_Import.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Import.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Import.TabIndex = 15
            Me.ButtonForm_Import.Text = "Import"
            '
            'ReportImportForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(831, 324)
            Me.Controls.Add(Me.RibbonBarMergeContainerForm_Options)
            Me.Controls.Add(Me.TextBoxForm_Log)
            Me.Controls.Add(Me.ProgressBarForm_OverallProgress)
            Me.Controls.Add(Me.LabelForm_OverallProgress)
            Me.Controls.Add(Me.ProgressBarForm_CurrentAction)
            Me.Controls.Add(Me.LabelForm_CurrentActionDescription)
            Me.Controls.Add(Me.LabelForm_CurrentAction)
            Me.Controls.Add(Me.TextBoxForm_ApplicationContentsFile)
            Me.Controls.Add(Me.LabelForm_ApplicationContentsFile)
            Me.Controls.Add(Me.ButtonForm_Import)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
            Me.Name = "ReportImportForm"
            Me.Text = "Report Import"
            Me.RibbonBarMergeContainerForm_Options.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ProgressBarForm_CurrentAction As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents ProgressBarForm_OverallProgress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Private WithEvents RibbonBarMergeContainerForm_Options As DevComponents.DotNetBar.RibbonBarMergeContainer
        Private WithEvents RibbonBarOptions_Actions As AdvantageFramework.WinForm.Presentation.Controls.RibbonBar
        Private WithEvents ButtonItemActions_Import As DevComponents.DotNetBar.ButtonItem
        Private WithEvents LabelForm_ApplicationContentsFile As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents TextBoxForm_ApplicationContentsFile As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Private WithEvents LabelForm_CurrentAction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_CurrentActionDescription As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents LabelForm_OverallProgress As AdvantageFramework.WinForm.Presentation.Controls.Label
        Private WithEvents TextBoxForm_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Import As WinForm.MVC.Presentation.Controls.Button
    End Class

End Namespace