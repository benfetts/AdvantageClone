Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class MediaPlanDetailAllocateDataDialog
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
			Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanDetailAllocateDataDialog))
			Me.DataGridViewForm_LevelLineData = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
			Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.LabelForm_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.LabelForm_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.LabelForm_ByDateType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
			Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
			Me.RadioButtonForm_Allocate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.RadioButtonForm_Update = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
			Me.DateEditForm_From = New DevExpress.XtraEditors.DateEdit()
			Me.DateEditForm_To = New DevExpress.XtraEditors.DateEdit()
			Me.CheckBoxForm_4WeekPeriodAllocation = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
			CType(Me.DateEditForm_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DateEditForm_From.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DateEditForm_To.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.DateEditForm_To.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			'
			'DataGridViewForm_LevelLineData
			'
			Me.DataGridViewForm_LevelLineData.AddFixedColumnCheckItemsToGridMenu = False
			Me.DataGridViewForm_LevelLineData.AllowDragAndDrop = False
			Me.DataGridViewForm_LevelLineData.AllowExtraItemsInGridLookupEdits = True
			Me.DataGridViewForm_LevelLineData.AllowSelectGroupHeaderRow = True
			Me.DataGridViewForm_LevelLineData.AlwaysForceShowRowSelectionOnUserInput = True
			Me.DataGridViewForm_LevelLineData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.DataGridViewForm_LevelLineData.AutoFilterLookupColumns = False
			Me.DataGridViewForm_LevelLineData.AutoloadRepositoryDatasource = True
			Me.DataGridViewForm_LevelLineData.AutoUpdateViewCaption = True
			Me.DataGridViewForm_LevelLineData.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
			Me.DataGridViewForm_LevelLineData.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
			Me.DataGridViewForm_LevelLineData.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
			Me.DataGridViewForm_LevelLineData.ItemDescription = "Data Line(s)"
			Me.DataGridViewForm_LevelLineData.Location = New System.Drawing.Point(12, 38)
			Me.DataGridViewForm_LevelLineData.MultiSelect = True
			Me.DataGridViewForm_LevelLineData.Name = "DataGridViewForm_LevelLineData"
			Me.DataGridViewForm_LevelLineData.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
			Me.DataGridViewForm_LevelLineData.RunStandardValidation = True
			Me.DataGridViewForm_LevelLineData.ShowColumnMenuOnRightClick = False
			Me.DataGridViewForm_LevelLineData.ShowSelectDeselectAllButtons = False
			Me.DataGridViewForm_LevelLineData.Size = New System.Drawing.Size(460, 84)
			Me.DataGridViewForm_LevelLineData.TabIndex = 5
			Me.DataGridViewForm_LevelLineData.UseEmbeddedNavigator = False
			Me.DataGridViewForm_LevelLineData.ViewCaptionHeight = -1
			'
			'ButtonForm_OK
			'
			Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_OK.Location = New System.Drawing.Point(316, 128)
			Me.ButtonForm_OK.Name = "ButtonForm_OK"
			Me.ButtonForm_OK.SecurityEnabled = True
			Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_OK.TabIndex = 9
			Me.ButtonForm_OK.Text = "OK"
			'
			'LabelForm_From
			'
			Me.LabelForm_From.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_From.Location = New System.Drawing.Point(12, 12)
			Me.LabelForm_From.Name = "LabelForm_From"
			Me.LabelForm_From.Size = New System.Drawing.Size(34, 20)
			Me.LabelForm_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_From.TabIndex = 0
			Me.LabelForm_From.Text = "From:"
			'
			'LabelForm_To
			'
			Me.LabelForm_To.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_To.Location = New System.Drawing.Point(158, 12)
			Me.LabelForm_To.Name = "LabelForm_To"
			Me.LabelForm_To.Size = New System.Drawing.Size(34, 20)
			Me.LabelForm_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_To.TabIndex = 2
			Me.LabelForm_To.Text = "To:"
			'
			'LabelForm_ByDateType
			'
			Me.LabelForm_ByDateType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.LabelForm_ByDateType.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.LabelForm_ByDateType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.LabelForm_ByDateType.Location = New System.Drawing.Point(304, 12)
			Me.LabelForm_ByDateType.Name = "LabelForm_ByDateType"
			Me.LabelForm_ByDateType.Size = New System.Drawing.Size(168, 20)
			Me.LabelForm_ByDateType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.LabelForm_ByDateType.TabIndex = 4
			Me.LabelForm_ByDateType.Text = "By: {0}"
			'
			'ButtonForm_Cancel
			'
			Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
			Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
			Me.ButtonForm_Cancel.Location = New System.Drawing.Point(397, 128)
			Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
			Me.ButtonForm_Cancel.SecurityEnabled = True
			Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
			Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.ButtonForm_Cancel.TabIndex = 10
			Me.ButtonForm_Cancel.Text = "Cancel"
			'
			'RadioButtonForm_Allocate
			'
			Me.RadioButtonForm_Allocate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.RadioButtonForm_Allocate.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonForm_Allocate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonForm_Allocate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonForm_Allocate.Checked = True
			Me.RadioButtonForm_Allocate.CheckState = System.Windows.Forms.CheckState.Checked
			Me.RadioButtonForm_Allocate.CheckValue = "Y"
			Me.RadioButtonForm_Allocate.Location = New System.Drawing.Point(12, 128)
			Me.RadioButtonForm_Allocate.Name = "RadioButtonForm_Allocate"
			Me.RadioButtonForm_Allocate.SecurityEnabled = True
			Me.RadioButtonForm_Allocate.Size = New System.Drawing.Size(67, 20)
			Me.RadioButtonForm_Allocate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonForm_Allocate.TabIndex = 6
			Me.RadioButtonForm_Allocate.TabOnEnter = True
			Me.RadioButtonForm_Allocate.Text = "Allocate"
			'
			'RadioButtonForm_Update
			'
			Me.RadioButtonForm_Update.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
			Me.RadioButtonForm_Update.BackColor = System.Drawing.Color.White
			'
			'
			'
			Me.RadioButtonForm_Update.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.RadioButtonForm_Update.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
			Me.RadioButtonForm_Update.Location = New System.Drawing.Point(85, 128)
			Me.RadioButtonForm_Update.Name = "RadioButtonForm_Update"
			Me.RadioButtonForm_Update.SecurityEnabled = True
			Me.RadioButtonForm_Update.Size = New System.Drawing.Size(67, 20)
			Me.RadioButtonForm_Update.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.RadioButtonForm_Update.TabIndex = 7
			Me.RadioButtonForm_Update.TabOnEnter = True
			Me.RadioButtonForm_Update.TabStop = False
			Me.RadioButtonForm_Update.Text = "Update"
			'
			'DateEditForm_From
			'
			Me.DateEditForm_From.EditValue = Nothing
			Me.DateEditForm_From.Location = New System.Drawing.Point(52, 12)
			Me.DateEditForm_From.Name = "DateEditForm_From"
			Me.DateEditForm_From.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
			Me.DateEditForm_From.Properties.AllowMouseWheel = False
			Me.DateEditForm_From.Properties.Appearance.BackColor = System.Drawing.Color.Cyan
			Me.DateEditForm_From.Properties.Appearance.Options.UseBackColor = True
			Me.DateEditForm_From.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.DateEditForm_From.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.DateEditForm_From.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
			Me.DateEditForm_From.Properties.DisplayFormat.FormatString = "d"
			Me.DateEditForm_From.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.DateEditForm_From.Properties.EditFormat.FormatString = "d"
			Me.DateEditForm_From.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.DateEditForm_From.Properties.Mask.EditMask = ""
			Me.DateEditForm_From.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
			Me.DateEditForm_From.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
			Me.DateEditForm_From.Size = New System.Drawing.Size(100, 20)
			Me.DateEditForm_From.TabIndex = 1
			'
			'DateEditForm_To
			'
			Me.DateEditForm_To.EditValue = Nothing
			Me.DateEditForm_To.Location = New System.Drawing.Point(198, 12)
			Me.DateEditForm_To.Name = "DateEditForm_To"
			Me.DateEditForm_To.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
			Me.DateEditForm_To.Properties.AllowMouseWheel = False
			Me.DateEditForm_To.Properties.Appearance.BackColor = System.Drawing.Color.Cyan
			Me.DateEditForm_To.Properties.Appearance.Options.UseBackColor = True
			Me.DateEditForm_To.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.DateEditForm_To.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.DateEditForm_To.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista
			Me.DateEditForm_To.Properties.DisplayFormat.FormatString = "d"
			Me.DateEditForm_To.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.DateEditForm_To.Properties.EditFormat.FormatString = "d"
			Me.DateEditForm_To.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
			Me.DateEditForm_To.Properties.Mask.EditMask = ""
			Me.DateEditForm_To.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
			Me.DateEditForm_To.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.[True]
			Me.DateEditForm_To.Size = New System.Drawing.Size(100, 20)
			Me.DateEditForm_To.TabIndex = 3
			'
			'CheckBoxForm_4WeekPeriodAllocation
			'
			Me.CheckBoxForm_4WeekPeriodAllocation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
			'
			'
			'
			Me.CheckBoxForm_4WeekPeriodAllocation.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
			Me.CheckBoxForm_4WeekPeriodAllocation.CheckValue = 0
			Me.CheckBoxForm_4WeekPeriodAllocation.CheckValueChecked = 1
			Me.CheckBoxForm_4WeekPeriodAllocation.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
			Me.CheckBoxForm_4WeekPeriodAllocation.CheckValueUnchecked = 0
			Me.CheckBoxForm_4WeekPeriodAllocation.ChildControls = CType(resources.GetObject("CheckBoxForm_4WeekPeriodAllocation.ChildControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_4WeekPeriodAllocation.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
			Me.CheckBoxForm_4WeekPeriodAllocation.Location = New System.Drawing.Point(158, 128)
			Me.CheckBoxForm_4WeekPeriodAllocation.Name = "CheckBoxForm_4WeekPeriodAllocation"
			Me.CheckBoxForm_4WeekPeriodAllocation.OldestSibling = Nothing
			Me.CheckBoxForm_4WeekPeriodAllocation.SecurityEnabled = True
			Me.CheckBoxForm_4WeekPeriodAllocation.SiblingControls = CType(resources.GetObject("CheckBoxForm_4WeekPeriodAllocation.SiblingControls"), System.Collections.Generic.List(Of Object))
			Me.CheckBoxForm_4WeekPeriodAllocation.Size = New System.Drawing.Size(152, 20)
			Me.CheckBoxForm_4WeekPeriodAllocation.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
			Me.CheckBoxForm_4WeekPeriodAllocation.TabIndex = 8
			Me.CheckBoxForm_4WeekPeriodAllocation.TabOnEnter = True
			Me.CheckBoxForm_4WeekPeriodAllocation.Text = "4 Week Period Allocation"
			Me.CheckBoxForm_4WeekPeriodAllocation.Visible = False
			'
			'MediaPlanDetailAllocateDataDialog
			'
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(484, 160)
			Me.Controls.Add(Me.CheckBoxForm_4WeekPeriodAllocation)
			Me.Controls.Add(Me.DateEditForm_To)
			Me.Controls.Add(Me.DateEditForm_From)
			Me.Controls.Add(Me.RadioButtonForm_Allocate)
			Me.Controls.Add(Me.RadioButtonForm_Update)
			Me.Controls.Add(Me.ButtonForm_Cancel)
			Me.Controls.Add(Me.LabelForm_ByDateType)
			Me.Controls.Add(Me.LabelForm_To)
			Me.Controls.Add(Me.LabelForm_From)
			Me.Controls.Add(Me.ButtonForm_OK)
			Me.Controls.Add(Me.DataGridViewForm_LevelLineData)
			Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
			Me.Name = "MediaPlanDetailAllocateDataDialog"
			Me.Text = "Allocate Data Lines"
			CType(Me.DateEditForm_From.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DateEditForm_From.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DateEditForm_To.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.DateEditForm_To.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub
		Friend WithEvents DataGridViewForm_LevelLineData As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_ByDateType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents RadioButtonForm_Allocate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonForm_Update As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents DateEditForm_From As DevExpress.XtraEditors.DateEdit
        Friend WithEvents DateEditForm_To As DevExpress.XtraEditors.DateEdit
		Friend WithEvents CheckBoxForm_4WeekPeriodAllocation As WinForm.Presentation.Controls.CheckBox
	End Class

End Namespace

