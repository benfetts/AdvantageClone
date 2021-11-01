Namespace Media.Presentation

	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Partial Class MediaBroadcastWorksheetMarketDetailCreateOrdersDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaBroadcastWorksheetMarketDetailCreateOrdersDialog))
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateEditForm_StartDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Button()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DateEditForm_EndDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.CheckBoxForm_CreateOrdersByWeek = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.DateEditForm_StartDate.Size = New System.Drawing.Size(181, 20)
            Me.DateEditForm_StartDate.TabIndex = 1
            Me.DateEditForm_StartDate.TabOnEnter = True
            Me.DateEditForm_StartDate.Tag = "9/2/2015"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(103, 90)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 5
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(184, 90)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 6
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(60, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 2
            Me.LabelForm_EndDate.Text = "End Date:"
            '
            'DateEditForm_EndDate
            '
            Me.DateEditForm_EndDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateEditForm_EndDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditForm_EndDate.DisplayName = ""
            Me.DateEditForm_EndDate.EditValue = Nothing
            Me.DateEditForm_EndDate.Location = New System.Drawing.Point(78, 38)
            Me.DateEditForm_EndDate.Name = "DateEditForm_EndDate"
            Me.DateEditForm_EndDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditForm_EndDate.Properties.AllowMouseWheel = False
            Me.DateEditForm_EndDate.Properties.Appearance.BackColor = System.Drawing.Color.White
            Me.DateEditForm_EndDate.Properties.Appearance.Options.UseBackColor = True
            Me.DateEditForm_EndDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditForm_EndDate.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
            Me.DateEditForm_EndDate.Properties.DisplayFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_EndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_EndDate.Properties.EditFormat.FormatString = "MM/dd/yyyy"
            Me.DateEditForm_EndDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
            Me.DateEditForm_EndDate.Properties.Mask.EditMask = ""
            Me.DateEditForm_EndDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
            Me.DateEditForm_EndDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditForm_EndDate.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditForm_EndDate.Size = New System.Drawing.Size(181, 20)
            Me.DateEditForm_EndDate.TabIndex = 3
            Me.DateEditForm_EndDate.TabOnEnter = True
            Me.DateEditForm_EndDate.Tag = "9/2/2015"
            '
            'CheckBoxForm_CreateOrdersByWeek
            '
            Me.CheckBoxForm_CreateOrdersByWeek.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_CreateOrdersByWeek.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CreateOrdersByWeek.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CreateOrdersByWeek.ChildControls = CType(resources.GetObject("CheckBoxForm_CreateOrdersByWeek.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CreateOrdersByWeek.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CreateOrdersByWeek.Location = New System.Drawing.Point(78, 64)
            Me.CheckBoxForm_CreateOrdersByWeek.Name = "CheckBoxForm_CreateOrdersByWeek"
            Me.CheckBoxForm_CreateOrdersByWeek.OldestSibling = Nothing
            Me.CheckBoxForm_CreateOrdersByWeek.SecurityEnabled = True
            Me.CheckBoxForm_CreateOrdersByWeek.SiblingControls = CType(resources.GetObject("CheckBoxForm_CreateOrdersByWeek.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CreateOrdersByWeek.Size = New System.Drawing.Size(181, 20)
            Me.CheckBoxForm_CreateOrdersByWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CreateOrdersByWeek.TabIndex = 4
            Me.CheckBoxForm_CreateOrdersByWeek.TabOnEnter = True
            Me.CheckBoxForm_CreateOrdersByWeek.Text = "Create Orders by Week"
            '
            'MediaBroadcastWorksheetMarketDetailCreateOrdersDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(271, 122)
            Me.Controls.Add(Me.CheckBoxForm_CreateOrdersByWeek)
            Me.Controls.Add(Me.LabelForm_EndDate)
            Me.Controls.Add(Me.DateEditForm_EndDate)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.LabelForm_StartDate)
            Me.Controls.Add(Me.DateEditForm_StartDate)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaBroadcastWorksheetMarketDetailCreateOrdersDialog"
            Me.Text = "Worksheet Create Orders"
            CType(Me.DateEditForm_StartDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_StartDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_EndDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditForm_EndDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents LabelForm_StartDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents DateEditForm_StartDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit
		Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
		Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.MVC.Presentation.Controls.Button
		Friend WithEvents LabelForm_EndDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.Label
		Friend WithEvents DateEditForm_EndDate As AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit
        Friend WithEvents CheckBoxForm_CreateOrdersByWeek As WinForm.MVC.Presentation.Controls.CheckBox
    End Class

End Namespace