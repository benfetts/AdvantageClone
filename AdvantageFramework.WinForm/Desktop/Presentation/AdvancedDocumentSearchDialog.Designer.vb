Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AdvancedDocumentSearchDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdvancedDocumentSearchDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DocumentManagerControlForm_DocumentManager = New AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl()
            Me.TextBoxForm_SearchCriteria = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_SearchCriteria = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Search = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Export = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(684, 464)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 3
            Me.ButtonForm_Close.Text = "Close"
            '
            'DocumentManagerControlForm_DocumentManager
            '
            Me.DocumentManagerControlForm_DocumentManager.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DocumentManagerControlForm_DocumentManager.Location = New System.Drawing.Point(12, 38)
            Me.DocumentManagerControlForm_DocumentManager.Name = "DocumentManagerControlForm_DocumentManager"
            Me.DocumentManagerControlForm_DocumentManager.Size = New System.Drawing.Size(747, 417)
            Me.DocumentManagerControlForm_DocumentManager.TabIndex = 4
            '
            'TextBoxForm_SearchCriteria
            '
            Me.TextBoxForm_SearchCriteria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_SearchCriteria.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_SearchCriteria.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_SearchCriteria.CheckSpellingOnValidate = False
            Me.TextBoxForm_SearchCriteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_SearchCriteria.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_SearchCriteria.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_SearchCriteria.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_SearchCriteria.FocusHighlightEnabled = True
            Me.TextBoxForm_SearchCriteria.Location = New System.Drawing.Point(101, 12)
            Me.TextBoxForm_SearchCriteria.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_SearchCriteria.Name = "TextBoxForm_SearchCriteria"
            Me.TextBoxForm_SearchCriteria.SecurityEnabled = True
            Me.TextBoxForm_SearchCriteria.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_SearchCriteria.Size = New System.Drawing.Size(577, 20)
            Me.TextBoxForm_SearchCriteria.StartingFolderName = Nothing
            Me.TextBoxForm_SearchCriteria.TabIndex = 5
            Me.TextBoxForm_SearchCriteria.TabOnEnter = True
            '
            'LabelForm_SearchCriteria
            '
            Me.LabelForm_SearchCriteria.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SearchCriteria.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SearchCriteria.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_SearchCriteria.Name = "LabelForm_SearchCriteria"
            Me.LabelForm_SearchCriteria.Size = New System.Drawing.Size(83, 20)
            Me.LabelForm_SearchCriteria.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SearchCriteria.TabIndex = 6
            Me.LabelForm_SearchCriteria.Text = "Search Criteria:"
            '
            'ButtonForm_Search
            '
            Me.ButtonForm_Search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Search.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Search.Location = New System.Drawing.Point(684, 12)
            Me.ButtonForm_Search.Name = "ButtonForm_Search"
            Me.ButtonForm_Search.SecurityEnabled = True
            Me.ButtonForm_Search.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Search.TabIndex = 7
            Me.ButtonForm_Search.Text = "Search"
            '
            'ButtonForm_Export
            '
            Me.ButtonForm_Export.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Export.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Export.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Export.Location = New System.Drawing.Point(600, 464)
            Me.ButtonForm_Export.Name = "ButtonForm_Export"
            Me.ButtonForm_Export.SecurityEnabled = True
            Me.ButtonForm_Export.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Export.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Export.TabIndex = 8
            Me.ButtonForm_Export.Text = "Export"
            '
            'AdvancedDocumentSearchDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(771, 493)
            Me.Controls.Add(Me.ButtonForm_Export)
            Me.Controls.Add(Me.ButtonForm_Search)
            Me.Controls.Add(Me.LabelForm_SearchCriteria)
            Me.Controls.Add(Me.TextBoxForm_SearchCriteria)
            Me.Controls.Add(Me.DocumentManagerControlForm_DocumentManager)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "AdvancedDocumentSearchDialog"
            Me.Text = "Advanced Document Search"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DocumentManagerControlForm_DocumentManager As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
        Friend WithEvents TextBoxForm_SearchCriteria As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_SearchCriteria As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Search As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Export As WinForm.Presentation.Controls.Button
    End Class

End Namespace