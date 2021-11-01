Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class AEChooserControl
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
            Me.components = New System.ComponentModel.Container()
            Me.DataGridViewControl_AccountExecutives = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControl_AllAccountExecutives = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ChooseAccountExecutives = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'DataGridViewControl_AccountExecutives
            '
            Me.DataGridViewControl_AccountExecutives.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_AccountExecutives.AllowDragAndDrop = False
            Me.DataGridViewControl_AccountExecutives.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_AccountExecutives.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_AccountExecutives.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_AccountExecutives.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_AccountExecutives.AutoFilterLookupColumns = False
            Me.DataGridViewControl_AccountExecutives.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_AccountExecutives.AutoUpdateViewCaption = True
            Me.DataGridViewControl_AccountExecutives.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewControl_AccountExecutives.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_AccountExecutives.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_AccountExecutives.ItemDescription = "Account Executive(s)"
            Me.DataGridViewControl_AccountExecutives.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewControl_AccountExecutives.MultiSelect = True
            Me.DataGridViewControl_AccountExecutives.Name = "DataGridViewControl_AccountExecutives"
            Me.DataGridViewControl_AccountExecutives.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_AccountExecutives.RunStandardValidation = True
            Me.DataGridViewControl_AccountExecutives.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_AccountExecutives.ShowSelectDeselectAllButtons = True
            Me.DataGridViewControl_AccountExecutives.Size = New System.Drawing.Size(571, 356)
            Me.DataGridViewControl_AccountExecutives.TabIndex = 15
            Me.DataGridViewControl_AccountExecutives.UseEmbeddedNavigator = False
            Me.DataGridViewControl_AccountExecutives.ViewCaptionHeight = -1
            '
            'RadioButtonControl_AllAccountExecutives
            '
            Me.RadioButtonControl_AllAccountExecutives.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_AllAccountExecutives.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_AllAccountExecutives.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_AllAccountExecutives.Checked = True
            Me.RadioButtonControl_AllAccountExecutives.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_AllAccountExecutives.CheckValue = "Y"
            Me.RadioButtonControl_AllAccountExecutives.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_AllAccountExecutives.Name = "RadioButtonControl_AllAccountExecutives"
            Me.RadioButtonControl_AllAccountExecutives.SecurityEnabled = True
            Me.RadioButtonControl_AllAccountExecutives.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControl_AllAccountExecutives.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_AllAccountExecutives.TabIndex = 16
            Me.RadioButtonControl_AllAccountExecutives.TabOnEnter = True
            Me.RadioButtonControl_AllAccountExecutives.Text = "All Account Executives"
            '
            'RadioButtonControl_ChooseAccountExecutives
            '
            Me.RadioButtonControl_ChooseAccountExecutives.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseAccountExecutives.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseAccountExecutives.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseAccountExecutives.Location = New System.Drawing.Point(142, 0)
            Me.RadioButtonControl_ChooseAccountExecutives.Name = "RadioButtonControl_ChooseAccountExecutives"
            Me.RadioButtonControl_ChooseAccountExecutives.SecurityEnabled = True
            Me.RadioButtonControl_ChooseAccountExecutives.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonControl_ChooseAccountExecutives.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseAccountExecutives.TabIndex = 17
            Me.RadioButtonControl_ChooseAccountExecutives.TabOnEnter = True
            Me.RadioButtonControl_ChooseAccountExecutives.TabStop = False
            Me.RadioButtonControl_ChooseAccountExecutives.Text = "Choose Account Executives"
            '
            'AEChooserControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.RadioButtonControl_AllAccountExecutives)
            Me.Controls.Add(Me.RadioButtonControl_ChooseAccountExecutives)
            Me.Controls.Add(Me.DataGridViewControl_AccountExecutives)
            Me.Name = "AEChooserControl"
            Me.Size = New System.Drawing.Size(571, 382)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewControl_AccountExecutives As DataGridView
        Friend WithEvents RadioButtonControl_AllAccountExecutives As RadioButtonControl
        Friend WithEvents RadioButtonControl_ChooseAccountExecutives As RadioButtonControl
    End Class

End Namespace