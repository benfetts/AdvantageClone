Namespace WinForm.MVC.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class DaysAndTimeDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DaysAndTimeDialog))
			Me.TextBoxForm_Days = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
			Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
			Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
			Me.GroupBoxForm_Days = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
			Me.CheckBoxDays_Sunday = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
			Me.CheckBoxDays_Saturday = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
			Me.CheckBoxDays_Friday = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
			Me.CheckBoxDays_Thursday = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
			Me.CheckBoxDays_Wednesday = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
			Me.CheckBoxDays_Tuesday = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
			Me.CheckBoxDays_Monday = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
			Me.LabelForm_Days = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
			Me.LabelForm_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
			Me.LabelForm_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
			Me.TimeEditForm_StartTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TimeEdit()
			Me.TimeEditForm_EndTime = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TimeEdit()
			CType(Me.GroupBoxForm_Days, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.GroupBoxForm_Days.SuspendLayout()
			CType(Me.TimeEditForm_StartTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.TimeEditForm_EndTime.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'TextBoxForm_Days
			'
			'
			'
			'
			Me.TextBoxForm_Days.Border.Class = "TextBoxBorder"
			Me.TextBoxForm_Days.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.TextBoxForm_Days.CheckSpellingOnValidate = False
			Me.TextBoxForm_Days.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
			Me.TextBoxForm_Days.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
			Me.TextBoxForm_Days.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
			Me.TextBoxForm_Days.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
			Me.TextBoxForm_Days.FocusHighlightEnabled = True
			Me.TextBoxForm_Days.Location = New System.Drawing.Point(113, 94)
			Me.TextBoxForm_Days.MaxFileSize = CType(0, Long)
			Me.TextBoxForm_Days.Name = "TextBoxForm_Days"
			Me.TextBoxForm_Days.PreventEnterBeep = True
			Me.TextBoxForm_Days.SecurityEnabled = True
			Me.TextBoxForm_Days.ShowSpellCheckCompleteMessage = True
			Me.TextBoxForm_Days.Size = New System.Drawing.Size(269, 20)
			Me.TextBoxForm_Days.StartingFolderName = Nothing
			Me.TextBoxForm_Days.TabIndex = 2
			Me.TextBoxForm_Days.TabOnEnter = True
			'
			'ButtonForm_Cancel
			'
			Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Cancel.Location = New System.Drawing.Point(307, 171)
			Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
			Me.ButtonForm_Cancel.SecurityEnabled = True
			Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Cancel.TabIndex = 8
			Me.ButtonForm_Cancel.Text = "Cancel"
			'
			'ButtonForm_OK
			'
			Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_OK.Location = New System.Drawing.Point(226, 171)
			Me.ButtonForm_OK.Name = "ButtonForm_OK"
			Me.ButtonForm_OK.SecurityEnabled = True
			Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_OK.TabIndex = 7
			Me.ButtonForm_OK.Text = "OK"
			'
			'GroupBoxForm_Days
			'
			Me.GroupBoxForm_Days.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.GroupBoxForm_Days.Controls.Add(Me.CheckBoxDays_Sunday)
			Me.GroupBoxForm_Days.Controls.Add(Me.CheckBoxDays_Saturday)
			Me.GroupBoxForm_Days.Controls.Add(Me.CheckBoxDays_Friday)
			Me.GroupBoxForm_Days.Controls.Add(Me.CheckBoxDays_Thursday)
			Me.GroupBoxForm_Days.Controls.Add(Me.CheckBoxDays_Wednesday)
			Me.GroupBoxForm_Days.Controls.Add(Me.CheckBoxDays_Tuesday)
			Me.GroupBoxForm_Days.Controls.Add(Me.CheckBoxDays_Monday)
			Me.GroupBoxForm_Days.Location = New System.Drawing.Point(12, 12)
			Me.GroupBoxForm_Days.Name = "GroupBoxForm_Days"
			Me.GroupBoxForm_Days.Size = New System.Drawing.Size(370, 75)
			Me.GroupBoxForm_Days.TabIndex = 0
			Me.GroupBoxForm_Days.Text = "Days"
			'
			'CheckBoxDays_Sunday
			'
			Me.CheckBoxDays_Sunday.BackColor = System.Drawing.Color.Transparent
			'
			'
			'
			Me.CheckBoxDays_Sunday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxDays_Sunday.CheckValue = 0
			Me.CheckBoxDays_Sunday.CheckValueChecked = 1
			Me.CheckBoxDays_Sunday.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxDays_Sunday.CheckValueUnchecked = 0
			Me.CheckBoxDays_Sunday.ChildControls = Nothing
			Me.CheckBoxDays_Sunday.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxDays_Sunday.Location = New System.Drawing.Point(197, 50)
			Me.CheckBoxDays_Sunday.Name = "CheckBoxDays_Sunday"
			Me.CheckBoxDays_Sunday.OldestSibling = Nothing
			Me.CheckBoxDays_Sunday.SecurityEnabled = True
			Me.CheckBoxDays_Sunday.SiblingControls = Nothing
			Me.CheckBoxDays_Sunday.Size = New System.Drawing.Size(87, 20)
			Me.CheckBoxDays_Sunday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxDays_Sunday.TabIndex = 6
			Me.CheckBoxDays_Sunday.TabOnEnter = True
			Me.CheckBoxDays_Sunday.Text = "Sunday"
			'
			'CheckBoxDays_Saturday
			'
			Me.CheckBoxDays_Saturday.BackColor = System.Drawing.Color.Transparent
			'
			'
			'
			Me.CheckBoxDays_Saturday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxDays_Saturday.CheckValue = 0
			Me.CheckBoxDays_Saturday.CheckValueChecked = 1
			Me.CheckBoxDays_Saturday.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxDays_Saturday.CheckValueUnchecked = 0
			Me.CheckBoxDays_Saturday.ChildControls = Nothing
			Me.CheckBoxDays_Saturday.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxDays_Saturday.Location = New System.Drawing.Point(101, 50)
			Me.CheckBoxDays_Saturday.Name = "CheckBoxDays_Saturday"
			Me.CheckBoxDays_Saturday.OldestSibling = Nothing
			Me.CheckBoxDays_Saturday.SecurityEnabled = True
			Me.CheckBoxDays_Saturday.SiblingControls = Nothing
			Me.CheckBoxDays_Saturday.Size = New System.Drawing.Size(87, 20)
			Me.CheckBoxDays_Saturday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxDays_Saturday.TabIndex = 5
			Me.CheckBoxDays_Saturday.TabOnEnter = True
			Me.CheckBoxDays_Saturday.Text = "Saturday"
			'
			'CheckBoxDays_Friday
			'
			Me.CheckBoxDays_Friday.BackColor = System.Drawing.Color.Transparent
			'
			'
			'
			Me.CheckBoxDays_Friday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxDays_Friday.CheckValue = 0
			Me.CheckBoxDays_Friday.CheckValueChecked = 1
			Me.CheckBoxDays_Friday.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxDays_Friday.CheckValueUnchecked = 0
			Me.CheckBoxDays_Friday.ChildControls = Nothing
			Me.CheckBoxDays_Friday.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxDays_Friday.Location = New System.Drawing.Point(5, 50)
			Me.CheckBoxDays_Friday.Name = "CheckBoxDays_Friday"
			Me.CheckBoxDays_Friday.OldestSibling = Nothing
			Me.CheckBoxDays_Friday.SecurityEnabled = True
			Me.CheckBoxDays_Friday.SiblingControls = Nothing
			Me.CheckBoxDays_Friday.Size = New System.Drawing.Size(87, 20)
			Me.CheckBoxDays_Friday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxDays_Friday.TabIndex = 4
			Me.CheckBoxDays_Friday.TabOnEnter = True
			Me.CheckBoxDays_Friday.Text = "Friday"
			'
			'CheckBoxDays_Thursday
			'
			Me.CheckBoxDays_Thursday.BackColor = System.Drawing.Color.Transparent
			'
			'
			'
			Me.CheckBoxDays_Thursday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxDays_Thursday.CheckValue = 0
			Me.CheckBoxDays_Thursday.CheckValueChecked = 1
			Me.CheckBoxDays_Thursday.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxDays_Thursday.CheckValueUnchecked = 0
			Me.CheckBoxDays_Thursday.ChildControls = Nothing
			Me.CheckBoxDays_Thursday.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxDays_Thursday.Location = New System.Drawing.Point(293, 24)
			Me.CheckBoxDays_Thursday.Name = "CheckBoxDays_Thursday"
			Me.CheckBoxDays_Thursday.OldestSibling = Nothing
			Me.CheckBoxDays_Thursday.SecurityEnabled = True
			Me.CheckBoxDays_Thursday.SiblingControls = Nothing
			Me.CheckBoxDays_Thursday.Size = New System.Drawing.Size(87, 20)
			Me.CheckBoxDays_Thursday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxDays_Thursday.TabIndex = 3
			Me.CheckBoxDays_Thursday.TabOnEnter = True
			Me.CheckBoxDays_Thursday.Text = "Thursday"
			'
			'CheckBoxDays_Wednesday
			'
			Me.CheckBoxDays_Wednesday.BackColor = System.Drawing.Color.Transparent
			'
			'
			'
			Me.CheckBoxDays_Wednesday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxDays_Wednesday.CheckValue = 0
			Me.CheckBoxDays_Wednesday.CheckValueChecked = 1
			Me.CheckBoxDays_Wednesday.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxDays_Wednesday.CheckValueUnchecked = 0
			Me.CheckBoxDays_Wednesday.ChildControls = Nothing
			Me.CheckBoxDays_Wednesday.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxDays_Wednesday.Location = New System.Drawing.Point(197, 24)
			Me.CheckBoxDays_Wednesday.Name = "CheckBoxDays_Wednesday"
			Me.CheckBoxDays_Wednesday.OldestSibling = Nothing
			Me.CheckBoxDays_Wednesday.SecurityEnabled = True
			Me.CheckBoxDays_Wednesday.SiblingControls = Nothing
			Me.CheckBoxDays_Wednesday.Size = New System.Drawing.Size(87, 20)
			Me.CheckBoxDays_Wednesday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxDays_Wednesday.TabIndex = 2
			Me.CheckBoxDays_Wednesday.TabOnEnter = True
			Me.CheckBoxDays_Wednesday.Text = "Wednesday"
			'
			'CheckBoxDays_Tuesday
			'
			Me.CheckBoxDays_Tuesday.BackColor = System.Drawing.Color.Transparent
			'
			'
			'
			Me.CheckBoxDays_Tuesday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxDays_Tuesday.CheckValue = 0
			Me.CheckBoxDays_Tuesday.CheckValueChecked = 1
			Me.CheckBoxDays_Tuesday.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxDays_Tuesday.CheckValueUnchecked = 0
			Me.CheckBoxDays_Tuesday.ChildControls = Nothing
			Me.CheckBoxDays_Tuesday.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxDays_Tuesday.Location = New System.Drawing.Point(101, 24)
			Me.CheckBoxDays_Tuesday.Name = "CheckBoxDays_Tuesday"
			Me.CheckBoxDays_Tuesday.OldestSibling = Nothing
			Me.CheckBoxDays_Tuesday.SecurityEnabled = True
			Me.CheckBoxDays_Tuesday.SiblingControls = Nothing
			Me.CheckBoxDays_Tuesday.Size = New System.Drawing.Size(87, 20)
			Me.CheckBoxDays_Tuesday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxDays_Tuesday.TabIndex = 1
			Me.CheckBoxDays_Tuesday.TabOnEnter = True
			Me.CheckBoxDays_Tuesday.Text = "Tuesday"
			'
			'CheckBoxDays_Monday
			'
			Me.CheckBoxDays_Monday.BackColor = System.Drawing.Color.Transparent
			'
			'
			'
			Me.CheckBoxDays_Monday.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxDays_Monday.CheckValue = 0
			Me.CheckBoxDays_Monday.CheckValueChecked = 1
			Me.CheckBoxDays_Monday.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxDays_Monday.CheckValueUnchecked = 0
			Me.CheckBoxDays_Monday.ChildControls = Nothing
			Me.CheckBoxDays_Monday.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxDays_Monday.Location = New System.Drawing.Point(5, 24)
			Me.CheckBoxDays_Monday.Name = "CheckBoxDays_Monday"
			Me.CheckBoxDays_Monday.OldestSibling = Nothing
			Me.CheckBoxDays_Monday.SecurityEnabled = True
			Me.CheckBoxDays_Monday.SiblingControls = Nothing
			Me.CheckBoxDays_Monday.Size = New System.Drawing.Size(87, 20)
			Me.CheckBoxDays_Monday.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxDays_Monday.TabIndex = 0
			Me.CheckBoxDays_Monday.TabOnEnter = True
			Me.CheckBoxDays_Monday.Text = "Monday"
			'
			'LabelForm_Days
			'
			Me.LabelForm_Days.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_Days.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_Days.Location = New System.Drawing.Point(12, 93)
			Me.LabelForm_Days.Name = "LabelForm_Days"
			Me.LabelForm_Days.Size = New System.Drawing.Size(95, 20)
			Me.LabelForm_Days.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_Days.TabIndex = 1
			Me.LabelForm_Days.Text = "Days:"
			'
			'LabelForm_StartTime
			'
			Me.LabelForm_StartTime.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_StartTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_StartTime.Location = New System.Drawing.Point(12, 119)
			Me.LabelForm_StartTime.Name = "LabelForm_StartTime"
			Me.LabelForm_StartTime.Size = New System.Drawing.Size(95, 20)
			Me.LabelForm_StartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_StartTime.TabIndex = 3
			Me.LabelForm_StartTime.Text = "Start Time:"
			'
			'LabelForm_EndTime
			'
			Me.LabelForm_EndTime.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_EndTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_EndTime.Location = New System.Drawing.Point(12, 145)
			Me.LabelForm_EndTime.Name = "LabelForm_EndTime"
			Me.LabelForm_EndTime.Size = New System.Drawing.Size(95, 20)
			Me.LabelForm_EndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_EndTime.TabIndex = 5
			Me.LabelForm_EndTime.Text = "End Time:"
			'
			'TimeEditForm_StartTime
			'
			Me.TimeEditForm_StartTime.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TimeEdit.Type.[Default]
			Me.TimeEditForm_StartTime.DisplayName = ""
			Me.TimeEditForm_StartTime.EditValue = New Date(2017, 5, 27, 0, 0, 0, 0)
			Me.TimeEditForm_StartTime.Location = New System.Drawing.Point(113, 119)
			Me.TimeEditForm_StartTime.Name = "TimeEditForm_StartTime"
			Me.TimeEditForm_StartTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.TimeEditForm_StartTime.Properties.DisplayFormat.FormatString = "t"
			Me.TimeEditForm_StartTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.TimeEditForm_StartTime.Properties.EditFormat.FormatString = "t"
			Me.TimeEditForm_StartTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.TimeEditForm_StartTime.Properties.Mask.EditMask = "t"
			Me.TimeEditForm_StartTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
			Me.TimeEditForm_StartTime.Properties.Mask.SaveLiteral = False
			Me.TimeEditForm_StartTime.Properties.Mask.ShowPlaceHolders = False
			Me.TimeEditForm_StartTime.Size = New System.Drawing.Size(269, 20)
			Me.TimeEditForm_StartTime.TabIndex = 4
			Me.TimeEditForm_StartTime.TabOnEnter = True
			'
			'TimeEditForm_EndTime
			'
			Me.TimeEditForm_EndTime.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TimeEdit.Type.[Default]
			Me.TimeEditForm_EndTime.DisplayName = ""
			Me.TimeEditForm_EndTime.EditValue = New Date(2017, 5, 27, 0, 0, 0, 0)
			Me.TimeEditForm_EndTime.Location = New System.Drawing.Point(113, 145)
			Me.TimeEditForm_EndTime.Name = "TimeEditForm_EndTime"
			Me.TimeEditForm_EndTime.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.TimeEditForm_EndTime.Properties.DisplayFormat.FormatString = "t"
			Me.TimeEditForm_EndTime.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.TimeEditForm_EndTime.Properties.EditFormat.FormatString = "t"
			Me.TimeEditForm_EndTime.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.TimeEditForm_EndTime.Properties.Mask.EditMask = "t"
			Me.TimeEditForm_EndTime.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
			Me.TimeEditForm_EndTime.Properties.Mask.SaveLiteral = False
			Me.TimeEditForm_EndTime.Properties.Mask.ShowPlaceHolders = False
			Me.TimeEditForm_EndTime.Size = New System.Drawing.Size(269, 20)
			Me.TimeEditForm_EndTime.TabIndex = 6
			Me.TimeEditForm_EndTime.TabOnEnter = True
			'
			'DaysAndTimeDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(394, 203)
			Me.Controls.Add(Me.TimeEditForm_EndTime)
			Me.Controls.Add(Me.TimeEditForm_StartTime)
			Me.Controls.Add(Me.LabelForm_EndTime)
			Me.Controls.Add(Me.LabelForm_StartTime)
			Me.Controls.Add(Me.LabelForm_Days)
			Me.Controls.Add(Me.GroupBoxForm_Days)
			Me.Controls.Add(Me.ButtonForm_OK)
			Me.Controls.Add(Me.ButtonForm_Cancel)
			Me.Controls.Add(Me.TextBoxForm_Days)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "DaysAndTimeDialog"
			Me.Text = "Days & Time"
			CType(Me.GroupBoxForm_Days, System.ComponentModel.ISupportInitialize).EndInit()
			Me.GroupBoxForm_Days.ResumeLayout(False)
			CType(Me.TimeEditForm_StartTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.TimeEditForm_EndTime.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		Friend WithEvents TextBoxForm_Days As AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox
		Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
		Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
		Friend WithEvents GroupBoxForm_Days As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
		Friend WithEvents CheckBoxDays_Sunday As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents CheckBoxDays_Saturday As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents CheckBoxDays_Friday As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents CheckBoxDays_Thursday As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents CheckBoxDays_Wednesday As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents CheckBoxDays_Tuesday As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents CheckBoxDays_Monday As AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox
		Friend WithEvents LabelForm_Days As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_StartTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents LabelForm_EndTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents TimeEditForm_StartTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.TimeEdit
		Friend WithEvents TimeEditForm_EndTime As AdvantageFramework.WinForm.MVC.Presentation.Controls.TimeEdit
	End Class

End Namespace