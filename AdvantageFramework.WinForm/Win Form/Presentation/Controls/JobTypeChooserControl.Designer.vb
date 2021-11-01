Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class JobTypeChooserControl
        Inherits AdvantageFramework.WinForm.Presentation.Controls.BaseControls.BaseUserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.DataGridViewControl_JobTypes = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControl_AllJobTypes = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ChooseJobTypes = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'DataGridViewControl_JobTypes
            '
            Me.DataGridViewControl_JobTypes.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_JobTypes.AllowDragAndDrop = False
            Me.DataGridViewControl_JobTypes.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_JobTypes.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_JobTypes.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_JobTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_JobTypes.AutoFilterLookupColumns = False
            Me.DataGridViewControl_JobTypes.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_JobTypes.AutoUpdateViewCaption = True
            Me.DataGridViewControl_JobTypes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewControl_JobTypes.DataSource = Nothing
            Me.DataGridViewControl_JobTypes.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_JobTypes.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_JobTypes.ItemDescription = "Job Type(s)"
            Me.DataGridViewControl_JobTypes.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewControl_JobTypes.MultiSelect = True
            Me.DataGridViewControl_JobTypes.Name = "DataGridViewControl_JobTypes"
            Me.DataGridViewControl_JobTypes.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_JobTypes.RunStandardValidation = True
            Me.DataGridViewControl_JobTypes.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_JobTypes.ShowSelectDeselectAllButtons = True
            Me.DataGridViewControl_JobTypes.Size = New System.Drawing.Size(571, 356)
            Me.DataGridViewControl_JobTypes.TabIndex = 15
            Me.DataGridViewControl_JobTypes.UseEmbeddedNavigator = False
            Me.DataGridViewControl_JobTypes.ViewCaptionHeight = -1
            '
            'RadioButtonControl_AllJobTypes
            '
            Me.RadioButtonControl_AllJobTypes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_AllJobTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_AllJobTypes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_AllJobTypes.Checked = True
            Me.RadioButtonControl_AllJobTypes.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_AllJobTypes.CheckValue = "Y"
            Me.RadioButtonControl_AllJobTypes.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_AllJobTypes.Name = "RadioButtonControl_AllJobTypes"
            Me.RadioButtonControl_AllJobTypes.SecurityEnabled = True
            Me.RadioButtonControl_AllJobTypes.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControl_AllJobTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_AllJobTypes.TabIndex = 16
            Me.RadioButtonControl_AllJobTypes.TabOnEnter = True
            Me.RadioButtonControl_AllJobTypes.Text = "All Job Types"
            '
            'RadioButtonControl_ChooseJobTypes
            '
            Me.RadioButtonControl_ChooseJobTypes.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseJobTypes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseJobTypes.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseJobTypes.Location = New System.Drawing.Point(142, 0)
            Me.RadioButtonControl_ChooseJobTypes.Name = "RadioButtonControl_ChooseJobTypes"
            Me.RadioButtonControl_ChooseJobTypes.SecurityEnabled = True
            Me.RadioButtonControl_ChooseJobTypes.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonControl_ChooseJobTypes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseJobTypes.TabIndex = 17
            Me.RadioButtonControl_ChooseJobTypes.TabOnEnter = True
            Me.RadioButtonControl_ChooseJobTypes.TabStop = False
            Me.RadioButtonControl_ChooseJobTypes.Text = "Choose Job Types"
            '
            'JobTypeChooserControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.RadioButtonControl_AllJobTypes)
            Me.Controls.Add(Me.RadioButtonControl_ChooseJobTypes)
            Me.Controls.Add(Me.DataGridViewControl_JobTypes)
            Me.Name = "JobTypeChooserControl"
            Me.Size = New System.Drawing.Size(571, 382)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewControl_JobTypes As DataGridView
        Friend WithEvents RadioButtonControl_AllJobTypes As RadioButtonControl
        Friend WithEvents RadioButtonControl_ChooseJobTypes As RadioButtonControl
    End Class

End Namespace