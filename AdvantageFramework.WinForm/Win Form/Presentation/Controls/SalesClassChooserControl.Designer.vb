Namespace WinForm.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SalesClassChooserControl
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
            Me.DataGridViewControl_SalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.RadioButtonControl_AllSalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonControl_ChooseSalesClasses = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.SuspendLayout()
            '
            'DataGridViewControl_SalesClasses
            '
            Me.DataGridViewControl_SalesClasses.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewControl_SalesClasses.AllowDragAndDrop = False
            Me.DataGridViewControl_SalesClasses.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewControl_SalesClasses.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_SalesClasses.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewControl_SalesClasses.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_SalesClasses.AutoFilterLookupColumns = False
            Me.DataGridViewControl_SalesClasses.AutoloadRepositoryDatasource = True
            Me.DataGridViewControl_SalesClasses.AutoUpdateViewCaption = True
            Me.DataGridViewControl_SalesClasses.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewControl_SalesClasses.DataSource = Nothing
            Me.DataGridViewControl_SalesClasses.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewControl_SalesClasses.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_SalesClasses.ItemDescription = "Sales Class(es)"
            Me.DataGridViewControl_SalesClasses.Location = New System.Drawing.Point(0, 26)
            Me.DataGridViewControl_SalesClasses.MultiSelect = False
            Me.DataGridViewControl_SalesClasses.Name = "DataGridViewControl_SalesClasses"
            Me.DataGridViewControl_SalesClasses.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewControl_SalesClasses.RunStandardValidation = True
            Me.DataGridViewControl_SalesClasses.ShowColumnMenuOnRightClick = False
            Me.DataGridViewControl_SalesClasses.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_SalesClasses.Size = New System.Drawing.Size(571, 356)
            Me.DataGridViewControl_SalesClasses.TabIndex = 15
            Me.DataGridViewControl_SalesClasses.UseEmbeddedNavigator = False
            Me.DataGridViewControl_SalesClasses.ViewCaptionHeight = -1
            '
            'RadioButtonControl_AllSalesClasses
            '
            Me.RadioButtonControl_AllSalesClasses.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_AllSalesClasses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_AllSalesClasses.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_AllSalesClasses.Checked = True
            Me.RadioButtonControl_AllSalesClasses.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonControl_AllSalesClasses.CheckValue = "Y"
            Me.RadioButtonControl_AllSalesClasses.Location = New System.Drawing.Point(0, 0)
            Me.RadioButtonControl_AllSalesClasses.Name = "RadioButtonControl_AllSalesClasses"
            Me.RadioButtonControl_AllSalesClasses.SecurityEnabled = True
            Me.RadioButtonControl_AllSalesClasses.Size = New System.Drawing.Size(136, 20)
            Me.RadioButtonControl_AllSalesClasses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_AllSalesClasses.TabIndex = 16
            Me.RadioButtonControl_AllSalesClasses.TabOnEnter = True
            Me.RadioButtonControl_AllSalesClasses.Text = "All Sales Classes"
            '
            'RadioButtonControl_ChooseSalesClasses
            '
            Me.RadioButtonControl_ChooseSalesClasses.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonControl_ChooseSalesClasses.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonControl_ChooseSalesClasses.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonControl_ChooseSalesClasses.Location = New System.Drawing.Point(142, 0)
            Me.RadioButtonControl_ChooseSalesClasses.Name = "RadioButtonControl_ChooseSalesClasses"
            Me.RadioButtonControl_ChooseSalesClasses.SecurityEnabled = True
            Me.RadioButtonControl_ChooseSalesClasses.Size = New System.Drawing.Size(164, 20)
            Me.RadioButtonControl_ChooseSalesClasses.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonControl_ChooseSalesClasses.TabIndex = 17
            Me.RadioButtonControl_ChooseSalesClasses.TabOnEnter = True
            Me.RadioButtonControl_ChooseSalesClasses.TabStop = False
            Me.RadioButtonControl_ChooseSalesClasses.Text = "Choose Sales Classes"
            '
            'SalesClassChooserControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.RadioButtonControl_AllSalesClasses)
            Me.Controls.Add(Me.RadioButtonControl_ChooseSalesClasses)
            Me.Controls.Add(Me.DataGridViewControl_SalesClasses)
            Me.Name = "SalesClassChooserControl"
            Me.Size = New System.Drawing.Size(571, 382)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents DataGridViewControl_SalesClasses As DataGridView
        Friend WithEvents RadioButtonControl_AllSalesClasses As RadioButtonControl
        Friend WithEvents RadioButtonControl_ChooseSalesClasses As RadioButtonControl
    End Class

End Namespace