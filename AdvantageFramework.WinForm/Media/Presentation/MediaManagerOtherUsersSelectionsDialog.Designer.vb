Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaManagerOtherUsersSelectionsDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

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
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaManagerOtherUsersSelectionsDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewMediaManager_Selections = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Delete = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(699, 406)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 1
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewMediaManager_Selections
            '
            Me.DataGridViewMediaManager_Selections.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewMediaManager_Selections.AllowDragAndDrop = False
            Me.DataGridViewMediaManager_Selections.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewMediaManager_Selections.AllowSelectGroupHeaderRow = True
            Me.DataGridViewMediaManager_Selections.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewMediaManager_Selections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewMediaManager_Selections.AutoFilterLookupColumns = False
            Me.DataGridViewMediaManager_Selections.AutoloadRepositoryDatasource = False
            Me.DataGridViewMediaManager_Selections.AutoUpdateViewCaption = True
            Me.DataGridViewMediaManager_Selections.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewMediaManager_Selections.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewMediaManager_Selections.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewMediaManager_Selections.ItemDescription = ""
            Me.DataGridViewMediaManager_Selections.Location = New System.Drawing.Point(13, 13)
            Me.DataGridViewMediaManager_Selections.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewMediaManager_Selections.MultiSelect = True
            Me.DataGridViewMediaManager_Selections.Name = "DataGridViewMediaManager_Selections"
            Me.DataGridViewMediaManager_Selections.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewMediaManager_Selections.RunStandardValidation = True
            Me.DataGridViewMediaManager_Selections.ShowColumnMenuOnRightClick = False
            Me.DataGridViewMediaManager_Selections.ShowSelectDeselectAllButtons = False
            Me.DataGridViewMediaManager_Selections.Size = New System.Drawing.Size(760, 386)
            Me.DataGridViewMediaManager_Selections.TabIndex = 2
            Me.DataGridViewMediaManager_Selections.UseEmbeddedNavigator = False
            Me.DataGridViewMediaManager_Selections.ViewCaptionHeight = -1
            '
            'ButtonForm_Delete
            '
            Me.ButtonForm_Delete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Delete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Delete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Delete.Location = New System.Drawing.Point(13, 406)
            Me.ButtonForm_Delete.Name = "ButtonForm_Delete"
            Me.ButtonForm_Delete.SecurityEnabled = True
            Me.ButtonForm_Delete.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Delete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Delete.TabIndex = 3
            Me.ButtonForm_Delete.Text = "Delete"
            '
            'MediaManagerOtherUsersSelectionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(786, 438)
            Me.Controls.Add(Me.ButtonForm_Delete)
            Me.Controls.Add(Me.DataGridViewMediaManager_Selections)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaManagerOtherUsersSelectionsDialog"
            Me.Text = "Media Manager Selections By Other Users"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewMediaManager_Selections As WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_Delete As WinForm.Presentation.Controls.Button
    End Class

End Namespace