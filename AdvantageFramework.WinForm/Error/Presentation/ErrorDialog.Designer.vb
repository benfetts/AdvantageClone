Namespace [Error].Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ErrorDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ErrorDialog))
            Me.LabelForm_Message = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxForm_Details = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxDetails_ErrorDetails = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonItemOK_CloseWithSendingErrorToSupport = New DevComponents.DotNetBar.ButtonItem()
            Me.ButtonItemOK_CloseWithoutSendingErrorToSupport = New DevComponents.DotNetBar.ButtonItem()
            Me.LabelForm_MessageImage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.GroupBoxForm_Details, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Details.SuspendLayout()
            Me.SuspendLayout()
            '
            'LabelForm_Message
            '
            Me.LabelForm_Message.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_Message.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Message.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Message.Location = New System.Drawing.Point(55, 9)
            Me.LabelForm_Message.Name = "LabelForm_Message"
            Me.LabelForm_Message.Size = New System.Drawing.Size(308, 41)
            Me.LabelForm_Message.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Message.TabIndex = 1
            Me.LabelForm_Message.Text = "Error Message"
            Me.LabelForm_Message.WordWrap = True
            '
            'GroupBoxForm_Details
            '
            Me.GroupBoxForm_Details.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_Details.Controls.Add(Me.TextBoxDetails_ErrorDetails)
            Me.GroupBoxForm_Details.Location = New System.Drawing.Point(12, 79)
            Me.GroupBoxForm_Details.Name = "GroupBoxForm_Details"
            Me.GroupBoxForm_Details.Padding = New System.Windows.Forms.Padding(10, 20, 10, 10)
            Me.GroupBoxForm_Details.Size = New System.Drawing.Size(351, 422)
            Me.GroupBoxForm_Details.TabIndex = 2
            Me.GroupBoxForm_Details.Text = "Details"
            '
            'TextBoxDetails_ErrorDetails
            '
            '
            '
            '
            Me.TextBoxDetails_ErrorDetails.Border.Class = "TextBoxBorder"
            Me.TextBoxDetails_ErrorDetails.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxDetails_ErrorDetails.CheckSpellingOnValidate = False
            Me.TextBoxDetails_ErrorDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxDetails_ErrorDetails.Dock = System.Windows.Forms.DockStyle.Fill
            Me.TextBoxDetails_ErrorDetails.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxDetails_ErrorDetails.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxDetails_ErrorDetails.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxDetails_ErrorDetails.FocusHighlightEnabled = True
            Me.TextBoxDetails_ErrorDetails.Location = New System.Drawing.Point(12, 41)
            Me.TextBoxDetails_ErrorDetails.MaxFileSize = CType(0, Long)
            Me.TextBoxDetails_ErrorDetails.Multiline = True
            Me.TextBoxDetails_ErrorDetails.Name = "TextBoxDetails_ErrorDetails"
            Me.TextBoxDetails_ErrorDetails.ReadOnly = True
            Me.TextBoxDetails_ErrorDetails.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.TextBoxDetails_ErrorDetails.ShowSpellCheckCompleteMessage = True
            Me.TextBoxDetails_ErrorDetails.Size = New System.Drawing.Size(327, 369)
            Me.TextBoxDetails_ErrorDetails.TabIndex = 0
            Me.TextBoxDetails_ErrorDetails.TabOnEnter = True
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.AutoExpandOnClick = True
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(288, 53)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ButtonItemOK_CloseWithSendingErrorToSupport, Me.ButtonItemOK_CloseWithoutSendingErrorToSupport})
            Me.ButtonForm_OK.TabIndex = 3
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonItemOK_CloseWithSendingErrorToSupport
            '
            Me.ButtonItemOK_CloseWithSendingErrorToSupport.GlobalItem = False
            Me.ButtonItemOK_CloseWithSendingErrorToSupport.Name = "ButtonItemOK_CloseWithSendingErrorToSupport"
            Me.ButtonItemOK_CloseWithSendingErrorToSupport.Text = "Close with Sending Error To Support"
            '
            'ButtonItemOK_CloseWithoutSendingErrorToSupport
            '
            Me.ButtonItemOK_CloseWithoutSendingErrorToSupport.GlobalItem = False
            Me.ButtonItemOK_CloseWithoutSendingErrorToSupport.Name = "ButtonItemOK_CloseWithoutSendingErrorToSupport"
            Me.ButtonItemOK_CloseWithoutSendingErrorToSupport.Text = "Close without Sending To Support"
            '
            'LabelForm_MessageImage
            '
            Me.LabelForm_MessageImage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_MessageImage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_MessageImage.Location = New System.Drawing.Point(12, 9)
            Me.LabelForm_MessageImage.Name = "LabelForm_MessageImage"
            Me.LabelForm_MessageImage.Size = New System.Drawing.Size(37, 41)
            Me.LabelForm_MessageImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_MessageImage.TabIndex = 4
            '
            'ErrorDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(375, 513)
            Me.Controls.Add(Me.LabelForm_MessageImage)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.GroupBoxForm_Details)
            Me.Controls.Add(Me.LabelForm_Message)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ErrorDialog"
            Me.Text = "Error"
            CType(Me.GroupBoxForm_Details, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Details.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents LabelForm_Message As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents GroupBoxForm_Details As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_MessageImage As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxDetails_ErrorDetails As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonItemOK_CloseWithSendingErrorToSupport As DevComponents.DotNetBar.ButtonItem
        Friend WithEvents ButtonItemOK_CloseWithoutSendingErrorToSupport As DevComponents.DotNetBar.ButtonItem

    End Class

End Namespace