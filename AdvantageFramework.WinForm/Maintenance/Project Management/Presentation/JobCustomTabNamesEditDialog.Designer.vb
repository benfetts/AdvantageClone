Namespace Maintenance.ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class JobCustomTabNamesEditDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobCustomTabNamesEditDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_JobTab = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_JobTab = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_JobComponentTab = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_JobComponentTab = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(324, 66)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_JobTab
            '
            Me.LabelForm_JobTab.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_JobTab.BackgroundStyle.Class = ""
            Me.LabelForm_JobTab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_JobTab.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_JobTab.Name = "LabelForm_JobTab"
            Me.LabelForm_JobTab.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_JobTab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_JobTab.TabIndex = 0
            Me.LabelForm_JobTab.Text = "Job Tab:"
            '
            'TextBoxForm_JobTab
            '
            Me.TextBoxForm_JobTab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_JobTab.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_JobTab.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_JobTab.CheckSpellingOnValidate = False
            Me.TextBoxForm_JobTab.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_JobTab.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_JobTab.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_JobTab.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_JobTab.FocusHighlightEnabled = True
            Me.TextBoxForm_JobTab.Location = New System.Drawing.Point(121, 12)
            Me.TextBoxForm_JobTab.Name = "TextBoxForm_JobTab"
            Me.TextBoxForm_JobTab.Size = New System.Drawing.Size(278, 20)
            Me.TextBoxForm_JobTab.TabIndex = 1
            Me.TextBoxForm_JobTab.TabOnEnter = True
            '
            'TextBoxForm_JobComponentTab
            '
            Me.TextBoxForm_JobComponentTab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_JobComponentTab.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_JobComponentTab.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_JobComponentTab.CheckSpellingOnValidate = False
            Me.TextBoxForm_JobComponentTab.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_JobComponentTab.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_JobComponentTab.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_JobComponentTab.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_JobComponentTab.FocusHighlightEnabled = True
            Me.TextBoxForm_JobComponentTab.Location = New System.Drawing.Point(121, 38)
            Me.TextBoxForm_JobComponentTab.Name = "TextBoxForm_JobComponentTab"
            Me.TextBoxForm_JobComponentTab.Size = New System.Drawing.Size(278, 20)
            Me.TextBoxForm_JobComponentTab.TabIndex = 3
            Me.TextBoxForm_JobComponentTab.TabOnEnter = True
            '
            'LabelForm_JobComponentTab
            '
            Me.LabelForm_JobComponentTab.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_JobComponentTab.BackgroundStyle.Class = ""
            Me.LabelForm_JobComponentTab.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_JobComponentTab.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_JobComponentTab.Name = "LabelForm_JobComponentTab"
            Me.LabelForm_JobComponentTab.Size = New System.Drawing.Size(103, 20)
            Me.LabelForm_JobComponentTab.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_JobComponentTab.TabIndex = 2
            Me.LabelForm_JobComponentTab.Text = "Job Component Tab:"
            '
            'ButtonForm_Update
            '
            Me.ButtonForm_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Update.Location = New System.Drawing.Point(243, 66)
            Me.ButtonForm_Update.Name = "ButtonForm_Update"
            Me.ButtonForm_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Update.TabIndex = 4
            Me.ButtonForm_Update.Text = "Update"
            '
            'JobCustomTabNamesEditDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(411, 98)
            Me.Controls.Add(Me.ButtonForm_Update)
            Me.Controls.Add(Me.TextBoxForm_JobComponentTab)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.LabelForm_JobComponentTab)
            Me.Controls.Add(Me.LabelForm_JobTab)
            Me.Controls.Add(Me.TextBoxForm_JobTab)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "JobCustomTabNamesEditDialog"
            Me.Text = "Job Custom Tab Names"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_JobTab As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_JobTab As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_JobComponentTab As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_JobComponentTab As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
    End Class

End Namespace