Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog))
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.DataGridViewForm_LineAllowSpotsToBeEntered = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            Me.LabelForm_Info = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(561, 79)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 2
            Me.ButtonForm_OK.Text = "OK"
            '
            'DataGridViewForm_LineAllowSpotsToBeEntered
            '
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.AutoUpdateViewCaption = True
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.ItemDescription = "Date Rate(s)"
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.Location = New System.Drawing.Point(12, 12)
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.ModifyGridRowHeight = False
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.MultiSelect = False
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.Name = "DataGridViewForm_LineAllowSpotsToBeEntered"
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.ShowRowSelectionIfHidden = True
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.Size = New System.Drawing.Size(624, 61)
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.TabIndex = 0
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.UseEmbeddedNavigator = False
            Me.DataGridViewForm_LineAllowSpotsToBeEntered.ViewCaptionHeight = -1
            '
            'LabelForm_Info
            '
            Me.LabelForm_Info.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Info.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Info.Location = New System.Drawing.Point(12, 79)
            Me.LabelForm_Info.Name = "LabelForm_Info"
            Me.LabelForm_Info.Size = New System.Drawing.Size(543, 20)
            Me.LabelForm_Info.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Info.TabIndex = 1
            Me.LabelForm_Info.Text = "Check to allow spots; uncheck to block spots"
            '
            'MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(648, 111)
            Me.Controls.Add(Me.LabelForm_Info)
            Me.Controls.Add(Me.DataGridViewForm_LineAllowSpotsToBeEntered)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog"
            Me.Text = "Override Spot Entry"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
        Friend WithEvents DataGridViewForm_LineAllowSpotsToBeEntered As WinForm.MVC.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_Info As WinForm.MVC.Presentation.Controls.Label
    End Class

End Namespace