Namespace WinForm.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class FolderBrowserDialog
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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FolderBrowserDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_Select = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_Files = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.TextBoxForm_CurrentDirectory = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelForm_CurrentDirectory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(600, 362)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 4
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_Select
            '
            Me.ButtonForm_Select.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Select.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Select.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Select.Location = New System.Drawing.Point(519, 362)
            Me.ButtonForm_Select.Name = "ButtonForm_Select"
            Me.ButtonForm_Select.SecurityEnabled = True
            Me.ButtonForm_Select.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Select.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Select.TabIndex = 3
            Me.ButtonForm_Select.Text = "Select"
            '
            'DataGridViewForm_Files
            '
            Me.DataGridViewForm_Files.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Files.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Files.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Files.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Files.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Files.AutoUpdateViewCaption = True
            Me.DataGridViewForm_Files.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewForm_Files.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Files.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Files.ItemDescription = "File(s)"
            Me.DataGridViewForm_Files.Location = New System.Drawing.Point(12, 38)
            Me.DataGridViewForm_Files.MultiSelect = True
            Me.DataGridViewForm_Files.Name = "DataGridViewForm_Files"
            Me.DataGridViewForm_Files.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Files.RunStandardValidation = True
            Me.DataGridViewForm_Files.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Files.Size = New System.Drawing.Size(663, 318)
            Me.DataGridViewForm_Files.TabIndex = 2
            Me.DataGridViewForm_Files.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Files.ViewCaptionHeight = -1
            '
            'TextBoxForm_CurrentDirectory
            '
            Me.TextBoxForm_CurrentDirectory.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxForm_CurrentDirectory.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_CurrentDirectory.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_CurrentDirectory.ButtonCustom.Visible = True
            Me.TextBoxForm_CurrentDirectory.CheckSpellingOnValidate = False
            Me.TextBoxForm_CurrentDirectory.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxForm_CurrentDirectory.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.TextBoxForm_CurrentDirectory.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.CSV
            Me.TextBoxForm_CurrentDirectory.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_CurrentDirectory.FocusHighlightEnabled = True
            Me.TextBoxForm_CurrentDirectory.Location = New System.Drawing.Point(114, 12)
            Me.TextBoxForm_CurrentDirectory.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_CurrentDirectory.Name = "TextBoxForm_CurrentDirectory"
            Me.TextBoxForm_CurrentDirectory.SecurityEnabled = True
            Me.TextBoxForm_CurrentDirectory.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_CurrentDirectory.Size = New System.Drawing.Size(561, 20)
            Me.TextBoxForm_CurrentDirectory.StartingFolderName = Nothing
            Me.TextBoxForm_CurrentDirectory.TabIndex = 1
            Me.TextBoxForm_CurrentDirectory.TabOnEnter = True
            '
            'LabelForm_CurrentDirectory
            '
            Me.LabelForm_CurrentDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_CurrentDirectory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_CurrentDirectory.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_CurrentDirectory.Name = "LabelForm_CurrentDirectory"
            Me.LabelForm_CurrentDirectory.Size = New System.Drawing.Size(96, 20)
            Me.LabelForm_CurrentDirectory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_CurrentDirectory.TabIndex = 0
            Me.LabelForm_CurrentDirectory.Text = "Current Directory:"
            '
            'FolderBrowserDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(687, 394)
            Me.Controls.Add(Me.LabelForm_CurrentDirectory)
            Me.Controls.Add(Me.TextBoxForm_CurrentDirectory)
            Me.Controls.Add(Me.DataGridViewForm_Files)
            Me.Controls.Add(Me.ButtonForm_Select)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "FolderBrowserDialog"
            Me.Text = "Folder Browser"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Select As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_Files As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents TextBoxForm_CurrentDirectory As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelForm_CurrentDirectory As AdvantageFramework.WinForm.Presentation.Controls.Label
    End Class

End Namespace