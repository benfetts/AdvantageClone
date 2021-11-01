Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanMasterPlanAddDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanMasterPlanAddDialog))
            Me.ButtonBottomSection_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelTopSection_Comment = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelTopSection_Description = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonBottomSection_Add = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonBottomSection_Update = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.TextBoxTopSection_Comment = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.SuspendLayout()
            '
            'ButtonBottomSection_Cancel
            '
            Me.ButtonBottomSection_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonBottomSection_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonBottomSection_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonBottomSection_Cancel.Location = New System.Drawing.Point(416, 157)
            Me.ButtonBottomSection_Cancel.Name = "ButtonBottomSection_Cancel"
            Me.ButtonBottomSection_Cancel.SecurityEnabled = True
            Me.ButtonBottomSection_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonBottomSection_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonBottomSection_Cancel.TabIndex = 6
            Me.ButtonBottomSection_Cancel.Text = "Cancel"
            '
            'LabelTopSection_Comment
            '
            Me.LabelTopSection_Comment.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Comment.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Comment.Location = New System.Drawing.Point(12, 38)
            Me.LabelTopSection_Comment.Name = "LabelTopSection_Comment"
            Me.LabelTopSection_Comment.Size = New System.Drawing.Size(80, 20)
            Me.LabelTopSection_Comment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Comment.TabIndex = 2
            Me.LabelTopSection_Comment.Text = "Comment:"
            '
            'TextBoxTopSection_Description
            '
            Me.TextBoxTopSection_Description.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxTopSection_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_Description.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_Description.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxTopSection_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Description.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Description.Location = New System.Drawing.Point(98, 12)
            Me.TextBoxTopSection_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxTopSection_Description.Name = "TextBoxTopSection_Description"
            Me.TextBoxTopSection_Description.SecurityEnabled = True
            Me.TextBoxTopSection_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTopSection_Description.Size = New System.Drawing.Size(393, 20)
            Me.TextBoxTopSection_Description.StartingFolderName = Nothing
            Me.TextBoxTopSection_Description.TabIndex = 1
            Me.TextBoxTopSection_Description.TabOnEnter = True
            '
            'LabelTopSection_Description
            '
            Me.LabelTopSection_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelTopSection_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelTopSection_Description.Location = New System.Drawing.Point(12, 12)
            Me.LabelTopSection_Description.Name = "LabelTopSection_Description"
            Me.LabelTopSection_Description.Size = New System.Drawing.Size(80, 20)
            Me.LabelTopSection_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelTopSection_Description.TabIndex = 0
            Me.LabelTopSection_Description.Text = "Description:"
            '
            'ButtonBottomSection_Add
            '
            Me.ButtonBottomSection_Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonBottomSection_Add.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonBottomSection_Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonBottomSection_Add.Location = New System.Drawing.Point(335, 157)
            Me.ButtonBottomSection_Add.Name = "ButtonBottomSection_Add"
            Me.ButtonBottomSection_Add.SecurityEnabled = True
            Me.ButtonBottomSection_Add.Size = New System.Drawing.Size(75, 20)
            Me.ButtonBottomSection_Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonBottomSection_Add.TabIndex = 4
            Me.ButtonBottomSection_Add.Text = "Add"
            '
            'ButtonBottomSection_Update
            '
            Me.ButtonBottomSection_Update.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonBottomSection_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonBottomSection_Update.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonBottomSection_Update.Location = New System.Drawing.Point(335, 157)
            Me.ButtonBottomSection_Update.Name = "ButtonBottomSection_Update"
            Me.ButtonBottomSection_Update.SecurityEnabled = True
            Me.ButtonBottomSection_Update.Size = New System.Drawing.Size(75, 20)
            Me.ButtonBottomSection_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonBottomSection_Update.TabIndex = 5
            Me.ButtonBottomSection_Update.Text = "Update"
            '
            'TextBoxTopSection_Comment
            '
            Me.TextBoxTopSection_Comment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxTopSection_Comment.Border.Class = "TextBoxBorder"
            Me.TextBoxTopSection_Comment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxTopSection_Comment.CheckSpellingOnValidate = False
            Me.TextBoxTopSection_Comment.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxTopSection_Comment.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxTopSection_Comment.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxTopSection_Comment.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxTopSection_Comment.FocusHighlightEnabled = True
            Me.TextBoxTopSection_Comment.Location = New System.Drawing.Point(98, 38)
            Me.TextBoxTopSection_Comment.MaxFileSize = CType(0, Long)
            Me.TextBoxTopSection_Comment.Multiline = True
            Me.TextBoxTopSection_Comment.Name = "TextBoxTopSection_Comment"
            Me.TextBoxTopSection_Comment.SecurityEnabled = True
            Me.TextBoxTopSection_Comment.ShowSpellCheckCompleteMessage = True
            Me.TextBoxTopSection_Comment.Size = New System.Drawing.Size(393, 113)
            Me.TextBoxTopSection_Comment.StartingFolderName = Nothing
            Me.TextBoxTopSection_Comment.TabIndex = 3
            Me.TextBoxTopSection_Comment.TabOnEnter = False
            '
            'MediaPlanMasterPlanAddDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(503, 189)
            Me.Controls.Add(Me.LabelTopSection_Comment)
            Me.Controls.Add(Me.LabelTopSection_Description)
            Me.Controls.Add(Me.ButtonBottomSection_Add)
            Me.Controls.Add(Me.TextBoxTopSection_Description)
            Me.Controls.Add(Me.ButtonBottomSection_Cancel)
            Me.Controls.Add(Me.TextBoxTopSection_Comment)
            Me.Controls.Add(Me.ButtonBottomSection_Update)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanMasterPlanAddDialog"
            Me.Text = "Master Plan"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonBottomSection_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelTopSection_Comment As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxTopSection_Description As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelTopSection_Description As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonBottomSection_Add As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonBottomSection_Update As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents TextBoxTopSection_Comment As AdvantageFramework.WinForm.Presentation.Controls.TextBox
    End Class

End Namespace