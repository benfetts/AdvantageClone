Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog))
			Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.DateEditForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateEdit()
			Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'ButtonForm_Cancel
			'
			Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Cancel.Location = New System.Drawing.Point(176, 38)
			Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
			Me.ButtonForm_Cancel.SecurityEnabled = True
			Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Cancel.TabIndex = 3
			Me.ButtonForm_Cancel.Text = "Cancel"
			'
			'ButtonForm_OK
			'
			Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_OK.Location = New System.Drawing.Point(95, 38)
			Me.ButtonForm_OK.Name = "ButtonForm_OK"
			Me.ButtonForm_OK.SecurityEnabled = True
			Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_OK.TabIndex = 2
			Me.ButtonForm_OK.Text = "OK"
			'
			'DateEditForm_StartDate
			'
			Me.DateEditForm_StartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DateEditForm_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateEdit.Type.[Default]
			Me.DateEditForm_StartDate.DisplayName = ""
			Me.DateEditForm_StartDate.EditValue = Nothing
			Me.DateEditForm_StartDate.Location = New System.Drawing.Point(93, 12)
			Me.DateEditForm_StartDate.Name = "DateEditForm_StartDate"
			Me.DateEditForm_StartDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
			Me.DateEditForm_StartDate.Properties.AllowMouseWheel = False
			Me.DateEditForm_StartDate.Properties.Appearance.BackColor = System.Drawing.Color.White
			Me.DateEditForm_StartDate.Properties.Appearance.Options.UseBackColor = True
			Me.DateEditForm_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.DateEditForm_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.DateEditForm_StartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
			Me.DateEditForm_StartDate.Properties.DisplayFormat.FormatString = "d"
			Me.DateEditForm_StartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.DateEditForm_StartDate.Properties.EditFormat.FormatString = "d"
			Me.DateEditForm_StartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.DateEditForm_StartDate.Properties.Mask.EditMask = ""
			Me.DateEditForm_StartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
			Me.DateEditForm_StartDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
			Me.DateEditForm_StartDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
			Me.DateEditForm_StartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
			Me.DateEditForm_StartDate.Size = New System.Drawing.Size(158, 20)
			Me.DateEditForm_StartDate.TabIndex = 1
			Me.DateEditForm_StartDate.TabOnEnter = True
			Me.DateEditForm_StartDate.Tag = "9/2/2015"
			'
			'LabelForm_StartDate
			'
			Me.LabelForm_StartDate.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_StartDate.Location = New System.Drawing.Point(12, 12)
			Me.LabelForm_StartDate.Name = "LabelForm_StartDate"
			Me.LabelForm_StartDate.Size = New System.Drawing.Size(75, 20)
			Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_StartDate.TabIndex = 0
			Me.LabelForm_StartDate.Text = "Start Date:"
			'
			'MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(263, 70)
			Me.Controls.Add(Me.DateEditForm_StartDate)
			Me.Controls.Add(Me.LabelForm_StartDate)
			Me.Controls.Add(Me.ButtonForm_Cancel)
			Me.Controls.Add(Me.ButtonForm_OK)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "MediaPlanDetailLevelLineDataUpdate4WeekStartDateDialog"
			Me.Text = "Update 4 Week Start Date"
			CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
		Friend WithEvents DateEditForm_StartDate As WinForm.Presentation.Controls.DateEdit
		Friend WithEvents LabelForm_StartDate As WinForm.Presentation.Controls.Label
	End Class

End Namespace
