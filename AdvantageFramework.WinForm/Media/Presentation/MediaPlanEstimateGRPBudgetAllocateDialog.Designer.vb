Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanEstimateGRPBudgetAllocateDialog
        Inherits AdvantageFramework.WinForm.MVC.Presentation.BaseForms.BaseForm

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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanEstimateGRPBudgetAllocateDialog))
            Me.NumericInputForm_Input = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.DataGridViewForm_LengthPercents = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelForm_GRPAmount = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            CType(Me.NumericInputForm_Input.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'NumericInputForm_Input
            '
            Me.NumericInputForm_Input.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_Input.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputForm_Input.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_Input.EnterMoveNextControl = True
            Me.NumericInputForm_Input.Location = New System.Drawing.Point(100, 12)
            Me.NumericInputForm_Input.Margin = New System.Windows.Forms.Padding(4)
            Me.NumericInputForm_Input.Name = "NumericInputForm_Input"
            Me.NumericInputForm_Input.Properties.AllowMouseWheel = False
            Me.NumericInputForm_Input.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.NumericInputForm_Input.Properties.Appearance.BackColor = System.Drawing.SystemColors.Control
            Me.NumericInputForm_Input.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_Input.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputForm_Input.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Input.Properties.EditFormat.FormatString = "f"
            Me.NumericInputForm_Input.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_Input.Properties.Mask.EditMask = "f"
            Me.NumericInputForm_Input.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_Input.SecurityEnabled = True
            Me.NumericInputForm_Input.Size = New System.Drawing.Size(220, 20)
            Me.NumericInputForm_Input.TabIndex = 5
            '
            'DataGridViewForm_LengthPercents
            '
            Me.DataGridViewForm_LengthPercents.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_LengthPercents.AutoUpdateViewCaption = True
            Me.DataGridViewForm_LengthPercents.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_LengthPercents.ItemDescription = "Length Percent(s)"
            Me.DataGridViewForm_LengthPercents.Location = New System.Drawing.Point(12, 40)
            Me.DataGridViewForm_LengthPercents.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewForm_LengthPercents.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_LengthPercents.ModifyGridRowHeight = False
            Me.DataGridViewForm_LengthPercents.MultiSelect = True
            Me.DataGridViewForm_LengthPercents.Name = "DataGridViewForm_LengthPercents"
            Me.DataGridViewForm_LengthPercents.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_LengthPercents.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_LengthPercents.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_LengthPercents.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_LengthPercents.Size = New System.Drawing.Size(308, 120)
            Me.DataGridViewForm_LengthPercents.TabIndex = 8
            Me.DataGridViewForm_LengthPercents.UseEmbeddedNavigator = False
            Me.DataGridViewForm_LengthPercents.ViewCaptionHeight = -1
            '
            'LabelForm_GRPAmount
            '
            Me.LabelForm_GRPAmount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GRPAmount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GRPAmount.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_GRPAmount.Name = "LabelForm_GRPAmount"
            Me.LabelForm_GRPAmount.Size = New System.Drawing.Size(81, 20)
            Me.LabelForm_GRPAmount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GRPAmount.TabIndex = 9
            Me.LabelForm_GRPAmount.Text = "GRP Amount:"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(164, 167)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 10
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(245, 167)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 11
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'MediaPlanEstimateGRPBudgetAllocateDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(333, 199)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.LabelForm_GRPAmount)
            Me.Controls.Add(Me.DataGridViewForm_LengthPercents)
            Me.Controls.Add(Me.NumericInputForm_Input)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "MediaPlanEstimateGRPBudgetAllocateDialog"
            Me.Text = "Enter Total GRP for:"
            CType(Me.NumericInputForm_Input.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents NumericInputForm_Input As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents DataGridViewForm_LengthPercents As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_GRPAmount As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents ButtonForm_OK As WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As WinForm.MVC.Presentation.Controls.Button
    End Class

End Namespace
