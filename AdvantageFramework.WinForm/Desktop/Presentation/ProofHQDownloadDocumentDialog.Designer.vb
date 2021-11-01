Namespace Desktop.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProofHQDownloadDocumentDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProofHQDownloadDocumentDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Download = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Search = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewForm_Proofs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TextBoxForm_Search = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.ButtonForm_Search = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(630, 338)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 5
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Download
            '
            Me.ButtonForm_Download.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Download.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Download.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Download.Location = New System.Drawing.Point(549, 338)
            Me.ButtonForm_Download.Name = "ButtonForm_Download"
            Me.ButtonForm_Download.SecurityEnabled = True
            Me.ButtonForm_Download.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Download.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Download.TabIndex = 4
            Me.ButtonForm_Download.Text = "Download"
            '
            'LabelForm_Search
            '
            Me.LabelForm_Search.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Search.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Search.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_Search.Name = "LabelForm_Search"
            Me.LabelForm_Search.Size = New System.Drawing.Size(75, 20)
            Me.LabelForm_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Search.TabIndex = 0
            Me.LabelForm_Search.Text = "Search:"
            '
            'DataGridViewForm_Proofs
            '
            Me.DataGridViewForm_Proofs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Proofs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Proofs.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Proofs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Proofs.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Proofs.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Proofs.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Proofs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Proofs.DataSource = Nothing
            Me.DataGridViewForm_Proofs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Proofs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Proofs.ItemDescription = "Proof(s)"
            Me.DataGridViewForm_Proofs.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_Proofs.MultiSelect = False
            Me.DataGridViewForm_Proofs.Name = "DataGridViewForm_Proofs"
            Me.DataGridViewForm_Proofs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Proofs.RunStandardValidation = True
            Me.DataGridViewForm_Proofs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Proofs.Size = New System.Drawing.Size(693, 294)
            Me.DataGridViewForm_Proofs.TabIndex = 3
            Me.DataGridViewForm_Proofs.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Proofs.ViewCaptionHeight = -1
            '
            'TextBoxForm_Search
            '
            Me.TextBoxForm_Search.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_Search.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_Search.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_Search.CheckSpellingOnValidate = False
            Me.TextBoxForm_Search.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_Search.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_Search.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_Search.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_Search.FocusHighlightEnabled = True
            Me.TextBoxForm_Search.Location = New System.Drawing.Point(93, 12)
            Me.TextBoxForm_Search.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_Search.Name = "TextBoxForm_Search"
            Me.TextBoxForm_Search.PreventEnterBeep = False
            Me.TextBoxForm_Search.SecurityEnabled = True
            Me.TextBoxForm_Search.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_Search.Size = New System.Drawing.Size(531, 20)
            Me.TextBoxForm_Search.StartingFolderName = Nothing
            Me.TextBoxForm_Search.TabIndex = 1
            Me.TextBoxForm_Search.TabOnEnter = True
            '
            'ButtonForm_Search
            '
            Me.ButtonForm_Search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Search.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Search.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Search.Location = New System.Drawing.Point(630, 12)
            Me.ButtonForm_Search.Name = "ButtonForm_Search"
            Me.ButtonForm_Search.SecurityEnabled = True
            Me.ButtonForm_Search.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Search.TabIndex = 2
            Me.ButtonForm_Search.Text = "Search"
            '
            'ProofHQDownloadDocumentDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(717, 370)
            Me.Controls.Add(Me.ButtonForm_Search)
            Me.Controls.Add(Me.TextBoxForm_Search)
            Me.Controls.Add(Me.DataGridViewForm_Proofs)
            Me.Controls.Add(Me.LabelForm_Search)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_Download)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProofHQDownloadDocumentDialog"
            Me.Text = "Download Document(s) from Proof HQ"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Download As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Search As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents DataGridViewForm_Proofs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxForm_Search As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Search As AdvantageFramework.WinForm.Presentation.Controls.Button

    End Class

End Namespace