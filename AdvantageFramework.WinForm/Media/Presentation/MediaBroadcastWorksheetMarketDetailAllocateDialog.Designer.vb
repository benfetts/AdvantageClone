Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetMarketDetailAllocateDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailAllocateDialog))
			Me.LabelForm_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
			Me.DateEditForm_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
			Me.NumericInputForm_Spots = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
			Me.LabelForm_Spots = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
			Me.RadioButtonForm_EveryOtherDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.RadioButtonForm_Every3rdDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.RadioButtonForm_Every4thDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
			Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
			Me.RadioButtonForm_EveryDate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.NumericInputForm_Spots.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
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
			Me.LabelForm_StartDate.Size = New System.Drawing.Size(60, 20)
			Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_StartDate.TabIndex = 0
			Me.LabelForm_StartDate.Text = "Start Date:"
			'
			'DateEditForm_StartDate
			'
			Me.DateEditForm_StartDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DateEditForm_StartDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
			Me.DateEditForm_StartDate.DisplayName = ""
			Me.DateEditForm_StartDate.EditValue = Nothing
			Me.DateEditForm_StartDate.Location = New System.Drawing.Point(78, 12)
			Me.DateEditForm_StartDate.Name = "DateEditForm_StartDate"
			Me.DateEditForm_StartDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
			Me.DateEditForm_StartDate.Properties.AllowMouseWheel = False
			Me.DateEditForm_StartDate.Properties.Appearance.BackColor = System.Drawing.Color.White
			Me.DateEditForm_StartDate.Properties.Appearance.Options.UseBackColor = True
			Me.DateEditForm_StartDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.DateEditForm_StartDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.DateEditForm_StartDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
			Me.DateEditForm_StartDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
			Me.DateEditForm_StartDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.DateEditForm_StartDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
			Me.DateEditForm_StartDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.DateEditForm_StartDate.Properties.Mask.EditMask = ""
			Me.DateEditForm_StartDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
			Me.DateEditForm_StartDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
			Me.DateEditForm_StartDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
			Me.DateEditForm_StartDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
			Me.DateEditForm_StartDate.Size = New System.Drawing.Size(156, 20)
			Me.DateEditForm_StartDate.TabIndex = 1
			Me.DateEditForm_StartDate.TabOnEnter = True
			Me.DateEditForm_StartDate.Tag = "9/2/2015"
			'
			'NumericInputForm_Spots
			'
			Me.NumericInputForm_Spots.AllowKeyUpAndDownToIncrementValue = False
			Me.NumericInputForm_Spots.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.NumericInputForm_Spots.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Integer]
			Me.NumericInputForm_Spots.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
			Me.NumericInputForm_Spots.EnterMoveNextControl = True
			Me.NumericInputForm_Spots.Location = New System.Drawing.Point(78, 38)
			Me.NumericInputForm_Spots.Name = "NumericInputForm_Spots"
			Me.NumericInputForm_Spots.Properties.AllowMouseWheel = False
			Me.NumericInputForm_Spots.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
			Me.NumericInputForm_Spots.Properties.Appearance.Options.UseBackColor = True
			Me.NumericInputForm_Spots.Properties.DisplayFormat.FormatString = "f0"
			Me.NumericInputForm_Spots.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.NumericInputForm_Spots.Properties.EditFormat.FormatString = "f0"
			Me.NumericInputForm_Spots.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
			Me.NumericInputForm_Spots.Properties.IsFloatValue = False
			Me.NumericInputForm_Spots.Properties.Mask.EditMask = "f0"
			Me.NumericInputForm_Spots.Properties.Mask.UseMaskAsDisplayFormat = True
			Me.NumericInputForm_Spots.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
			Me.NumericInputForm_Spots.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
			Me.NumericInputForm_Spots.SecurityEnabled = True
			Me.NumericInputForm_Spots.Size = New System.Drawing.Size(156, 20)
			Me.NumericInputForm_Spots.TabIndex = 3
			Me.NumericInputForm_Spots.TabStop = False
			'
			'LabelForm_Spots
			'
			Me.LabelForm_Spots.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_Spots.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_Spots.Location = New System.Drawing.Point(12, 38)
			Me.LabelForm_Spots.Name = "LabelForm_Spots"
			Me.LabelForm_Spots.Size = New System.Drawing.Size(60, 20)
			Me.LabelForm_Spots.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_Spots.TabIndex = 2
			Me.LabelForm_Spots.Text = "Spots:"
			'
			'RadioButtonForm_EveryOtherDate
			'
			Me.RadioButtonForm_EveryOtherDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.RadioButtonForm_EveryOtherDate.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonForm_EveryOtherDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonForm_EveryOtherDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonForm_EveryOtherDate.Location = New System.Drawing.Point(78, 90)
			Me.RadioButtonForm_EveryOtherDate.Name = "RadioButtonForm_EveryOtherDate"
			Me.RadioButtonForm_EveryOtherDate.SecurityEnabled = True
			Me.RadioButtonForm_EveryOtherDate.Size = New System.Drawing.Size(156, 20)
			Me.RadioButtonForm_EveryOtherDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonForm_EveryOtherDate.TabIndex = 4
			Me.RadioButtonForm_EveryOtherDate.TabOnEnter = True
			Me.RadioButtonForm_EveryOtherDate.TabStop = False
			Me.RadioButtonForm_EveryOtherDate.Tag = "1"
			Me.RadioButtonForm_EveryOtherDate.Text = "Every Other Date"
			'
			'RadioButtonForm_Every3rdDate
			'
			Me.RadioButtonForm_Every3rdDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.RadioButtonForm_Every3rdDate.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonForm_Every3rdDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonForm_Every3rdDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonForm_Every3rdDate.Location = New System.Drawing.Point(78, 116)
			Me.RadioButtonForm_Every3rdDate.Name = "RadioButtonForm_Every3rdDate"
			Me.RadioButtonForm_Every3rdDate.SecurityEnabled = True
			Me.RadioButtonForm_Every3rdDate.Size = New System.Drawing.Size(156, 20)
			Me.RadioButtonForm_Every3rdDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonForm_Every3rdDate.TabIndex = 5
			Me.RadioButtonForm_Every3rdDate.TabOnEnter = True
			Me.RadioButtonForm_Every3rdDate.TabStop = False
			Me.RadioButtonForm_Every3rdDate.Tag = "1"
			Me.RadioButtonForm_Every3rdDate.Text = "Every 3rd Date"
			'
			'RadioButtonForm_Every4thDate
			'
			Me.RadioButtonForm_Every4thDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.RadioButtonForm_Every4thDate.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonForm_Every4thDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonForm_Every4thDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonForm_Every4thDate.Location = New System.Drawing.Point(78, 142)
			Me.RadioButtonForm_Every4thDate.Name = "RadioButtonForm_Every4thDate"
			Me.RadioButtonForm_Every4thDate.SecurityEnabled = True
			Me.RadioButtonForm_Every4thDate.Size = New System.Drawing.Size(156, 20)
			Me.RadioButtonForm_Every4thDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonForm_Every4thDate.TabIndex = 6
			Me.RadioButtonForm_Every4thDate.TabOnEnter = True
			Me.RadioButtonForm_Every4thDate.TabStop = False
			Me.RadioButtonForm_Every4thDate.Tag = "1"
			Me.RadioButtonForm_Every4thDate.Text = "Every 4th Date"
			'
			'ButtonForm_OK
			'
			Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_OK.Location = New System.Drawing.Point(78, 168)
			Me.ButtonForm_OK.Name = "ButtonForm_OK"
			Me.ButtonForm_OK.SecurityEnabled = True
			Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_OK.TabIndex = 7
			Me.ButtonForm_OK.Text = "OK"
			'
			'ButtonForm_Cancel
			'
			Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Cancel.Location = New System.Drawing.Point(159, 168)
			Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
			Me.ButtonForm_Cancel.SecurityEnabled = True
			Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Cancel.TabIndex = 8
			Me.ButtonForm_Cancel.Text = "Cancel"
			'
			'RadioButtonForm_EveryDate
			'
			Me.RadioButtonForm_EveryDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.RadioButtonForm_EveryDate.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonForm_EveryDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonForm_EveryDate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonForm_EveryDate.Checked = True
			Me.RadioButtonForm_EveryDate.CheckState = System.Windows.Forms.CheckState.Checked
			Me.RadioButtonForm_EveryDate.CheckValue = "Y"
			Me.RadioButtonForm_EveryDate.Location = New System.Drawing.Point(78, 64)
			Me.RadioButtonForm_EveryDate.Name = "RadioButtonForm_EveryDate"
			Me.RadioButtonForm_EveryDate.SecurityEnabled = True
			Me.RadioButtonForm_EveryDate.Size = New System.Drawing.Size(156, 20)
			Me.RadioButtonForm_EveryDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonForm_EveryDate.TabIndex = 9
			Me.RadioButtonForm_EveryDate.TabOnEnter = True
			Me.RadioButtonForm_EveryDate.Tag = "1"
			Me.RadioButtonForm_EveryDate.Text = "Every Date"
			'
			'MediaBroadcastWorksheetMarketDetailAllocateDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(246, 200)
			Me.Controls.Add(Me.RadioButtonForm_EveryDate)
			Me.Controls.Add(Me.ButtonForm_OK)
			Me.Controls.Add(Me.ButtonForm_Cancel)
			Me.Controls.Add(Me.RadioButtonForm_Every4thDate)
			Me.Controls.Add(Me.RadioButtonForm_Every3rdDate)
			Me.Controls.Add(Me.RadioButtonForm_EveryOtherDate)
			Me.Controls.Add(Me.NumericInputForm_Spots)
			Me.Controls.Add(Me.LabelForm_Spots)
			Me.Controls.Add(Me.LabelForm_StartDate)
			Me.Controls.Add(Me.DateEditForm_StartDate)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "MediaBroadcastWorksheetMarketDetailAllocateDialog"
			Me.Text = "Allocate Spots"
			CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.NumericInputForm_Spots.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		Friend WithEvents LabelForm_StartDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents DateEditForm_StartDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit
		Friend WithEvents NumericInputForm_Spots As AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput
		Friend WithEvents LabelForm_Spots As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents RadioButtonForm_EveryOtherDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
		Friend WithEvents RadioButtonForm_Every3rdDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
		Friend WithEvents RadioButtonForm_Every4thDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
		Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
		Friend WithEvents RadioButtonForm_EveryDate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
	End Class

End Namespace