Namespace ProjectManagement.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ProjectScheduleSettingsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProjectScheduleSettingsDialog))
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewForm_Settings = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.SuspendLayout()
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(527, 438)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 14
            Me.ButtonForm_Close.Text = "Close"
            '
            'DataGridViewForm_Settings
            '
            Me.DataGridViewForm_Settings.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_Settings.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_Settings.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_Settings.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_Settings.AutoFilterLookupColumns = False
            Me.DataGridViewForm_Settings.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_Settings.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_Settings.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_Settings.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_Settings.ItemDescription = "Available Columns"
            Me.DataGridViewForm_Settings.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_Settings.MultiSelect = True
            Me.DataGridViewForm_Settings.Name = "DataGridViewForm_Settings"
            Me.DataGridViewForm_Settings.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_Settings.RunStandardValidation = True
            Me.DataGridViewForm_Settings.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_Settings.Size = New System.Drawing.Size(590, 420)
            Me.DataGridViewForm_Settings.TabIndex = 15
            Me.DataGridViewForm_Settings.UseEmbeddedNavigator = False
            Me.DataGridViewForm_Settings.ViewCaptionHeight = -1
            '
            'ProjectScheduleSettingsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(614, 470)
            Me.Controls.Add(Me.DataGridViewForm_Settings)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ProjectScheduleSettingsDialog"
            Me.Text = "Project Schedule - Setup"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_Settings As AdvantageFramework.WinForm.Presentation.Controls.DataGridView

    End Class

End Namespace