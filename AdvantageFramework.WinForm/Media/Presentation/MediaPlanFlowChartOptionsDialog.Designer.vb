Namespace Media.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MediaPlanFlowChartOptionsDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MediaPlanFlowChartOptionsDialog))
            Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_Location = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_DateHeaderOption = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.GroupBoxForm_Levels = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.LabelLevels_WeekDisplayType = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxLevels_WeekDisplayType = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.CheckBoxLevels_PrintDay = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevels_PrintDate = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevels_PrintWeek = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevels_PrintMonthName = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevels_PrintMonth = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevels_PrintQuarter = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxLevels_PrintYear = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.SearchableComboBoxForm_Location = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBoxViewForm_Location = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.LabelForm_DateHeaderOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_DateOverrideOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_DateOverrideOption = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.DataGridViewForm_EstimateOptions = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.LabelForm_GrandTotalDisplayValue = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_GrandTotalDisplayValue = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_SummaryOption = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_SummaryOption = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelForm_DateHeaderColor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ColorPickerForm_DateHeaderColor = New DevComponents.DotNetBar.ColorPickerButton()
            Me.ColorPickerForm_FieldAreaColor = New DevComponents.DotNetBar.ColorPickerButton()
            Me.LabelForm_FieldAreaColor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonForm_Print = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_FooterImage = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ComboBoxForm_FooterImages = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ButtonForm_ManageImages = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerForm_StartDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerForm_EndDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.GroupBoxForm_EstimateColumnTotals = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.ColorPickerEstimateColumnTotals_AreaColor = New DevComponents.DotNetBar.ColorPickerButton()
            Me.LabelEstimateColumnTotals_AreaColor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonEstimateColumnTotals_Both = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonEstimateColumnTotals_ByMonth = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonEstimateColumnTotals_Default = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxEstimateColumnTotals_Show = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.GroupBoxForm_GrandTotals = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.ColorPickerGrandTotals_AreaColor = New DevComponents.DotNetBar.ColorPickerButton()
            Me.LabelGrandTotals_AreaColor = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.RadioButtonGrandTotals_Both = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonGrandTotals_ByMonth = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonGrandTotals_Default = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.CheckBoxGrandTotals_Show = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxForm_RoundToNearestDollar = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            CType(Me.GroupBoxForm_Levels, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_Levels.SuspendLayout()
            CType(Me.SearchableComboBoxForm_Location.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBoxViewForm_Location, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxForm_EstimateColumnTotals, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_EstimateColumnTotals.SuspendLayout()
            CType(Me.GroupBoxForm_GrandTotals, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxForm_GrandTotals.SuspendLayout()
            Me.SuspendLayout()
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(905, 698)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 28
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(824, 698)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 27
            Me.ButtonForm_OK.Text = "OK"
            '
            'LabelForm_Location
            '
            Me.LabelForm_Location.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Location.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Location.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_Location.Name = "LabelForm_Location"
            Me.LabelForm_Location.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_Location.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Location.TabIndex = 4
            Me.LabelForm_Location.Text = "Location Logo:"
            '
            'ComboBoxForm_DateHeaderOption
            '
            Me.ComboBoxForm_DateHeaderOption.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_DateHeaderOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_DateHeaderOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_DateHeaderOption.AutoFindItemInDataSource = False
            Me.ComboBoxForm_DateHeaderOption.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_DateHeaderOption.BookmarkingEnabled = False
            Me.ComboBoxForm_DateHeaderOption.ClientCode = ""
            Me.ComboBoxForm_DateHeaderOption.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_DateHeaderOption.DisableMouseWheel = False
            Me.ComboBoxForm_DateHeaderOption.DisplayMember = "Name"
            Me.ComboBoxForm_DateHeaderOption.DisplayName = ""
            Me.ComboBoxForm_DateHeaderOption.DivisionCode = ""
            Me.ComboBoxForm_DateHeaderOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_DateHeaderOption.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_DateHeaderOption.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_DateHeaderOption.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_DateHeaderOption.FocusHighlightEnabled = True
            Me.ComboBoxForm_DateHeaderOption.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_DateHeaderOption.FormattingEnabled = True
            Me.ComboBoxForm_DateHeaderOption.ItemHeight = 14
            Me.ComboBoxForm_DateHeaderOption.Location = New System.Drawing.Point(162, 64)
            Me.ComboBoxForm_DateHeaderOption.Name = "ComboBoxForm_DateHeaderOption"
            Me.ComboBoxForm_DateHeaderOption.ReadOnly = False
            Me.ComboBoxForm_DateHeaderOption.SecurityEnabled = True
            Me.ComboBoxForm_DateHeaderOption.Size = New System.Drawing.Size(123, 20)
            Me.ComboBoxForm_DateHeaderOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_DateHeaderOption.TabIndex = 7
            Me.ComboBoxForm_DateHeaderOption.TabOnEnter = True
            Me.ComboBoxForm_DateHeaderOption.ValueMember = "Value"
            Me.ComboBoxForm_DateHeaderOption.WatermarkText = "Select"
            '
            'GroupBoxForm_Levels
            '
            Me.GroupBoxForm_Levels.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_Levels.Controls.Add(Me.LabelLevels_WeekDisplayType)
            Me.GroupBoxForm_Levels.Controls.Add(Me.ComboBoxLevels_WeekDisplayType)
            Me.GroupBoxForm_Levels.Controls.Add(Me.CheckBoxLevels_PrintDay)
            Me.GroupBoxForm_Levels.Controls.Add(Me.CheckBoxLevels_PrintDate)
            Me.GroupBoxForm_Levels.Controls.Add(Me.CheckBoxLevels_PrintWeek)
            Me.GroupBoxForm_Levels.Controls.Add(Me.CheckBoxLevels_PrintMonthName)
            Me.GroupBoxForm_Levels.Controls.Add(Me.CheckBoxLevels_PrintMonth)
            Me.GroupBoxForm_Levels.Controls.Add(Me.CheckBoxLevels_PrintQuarter)
            Me.GroupBoxForm_Levels.Controls.Add(Me.CheckBoxLevels_PrintYear)
            Me.GroupBoxForm_Levels.GroupStyle = DevExpress.Utils.GroupStyle.Title
            Me.GroupBoxForm_Levels.Location = New System.Drawing.Point(162, 90)
            Me.GroupBoxForm_Levels.Name = "GroupBoxForm_Levels"
            Me.GroupBoxForm_Levels.Size = New System.Drawing.Size(818, 98)
            Me.GroupBoxForm_Levels.TabIndex = 12
            Me.GroupBoxForm_Levels.Text = "Levels"
            '
            'LabelLevels_WeekDisplayType
            '
            Me.LabelLevels_WeekDisplayType.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelLevels_WeekDisplayType.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelLevels_WeekDisplayType.Location = New System.Drawing.Point(129, 49)
            Me.LabelLevels_WeekDisplayType.Name = "LabelLevels_WeekDisplayType"
            Me.LabelLevels_WeekDisplayType.Size = New System.Drawing.Size(120, 20)
            Me.LabelLevels_WeekDisplayType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelLevels_WeekDisplayType.TabIndex = 5
            Me.LabelLevels_WeekDisplayType.Text = "Week Display Type:"
            '
            'ComboBoxLevels_WeekDisplayType
            '
            Me.ComboBoxLevels_WeekDisplayType.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxLevels_WeekDisplayType.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxLevels_WeekDisplayType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxLevels_WeekDisplayType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxLevels_WeekDisplayType.AutoFindItemInDataSource = False
            Me.ComboBoxLevels_WeekDisplayType.AutoSelectSingleItemDatasource = False
            Me.ComboBoxLevels_WeekDisplayType.BookmarkingEnabled = False
            Me.ComboBoxLevels_WeekDisplayType.ClientCode = ""
            Me.ComboBoxLevels_WeekDisplayType.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxLevels_WeekDisplayType.DisableMouseWheel = False
            Me.ComboBoxLevels_WeekDisplayType.DisplayMember = "Name"
            Me.ComboBoxLevels_WeekDisplayType.DisplayName = ""
            Me.ComboBoxLevels_WeekDisplayType.DivisionCode = ""
            Me.ComboBoxLevels_WeekDisplayType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxLevels_WeekDisplayType.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxLevels_WeekDisplayType.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxLevels_WeekDisplayType.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxLevels_WeekDisplayType.FocusHighlightEnabled = True
            Me.ComboBoxLevels_WeekDisplayType.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxLevels_WeekDisplayType.FormattingEnabled = True
            Me.ComboBoxLevels_WeekDisplayType.ItemHeight = 16
            Me.ComboBoxLevels_WeekDisplayType.Location = New System.Drawing.Point(255, 49)
            Me.ComboBoxLevels_WeekDisplayType.Name = "ComboBoxLevels_WeekDisplayType"
            Me.ComboBoxLevels_WeekDisplayType.ReadOnly = False
            Me.ComboBoxLevels_WeekDisplayType.SecurityEnabled = True
            Me.ComboBoxLevels_WeekDisplayType.Size = New System.Drawing.Size(560, 22)
            Me.ComboBoxLevels_WeekDisplayType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxLevels_WeekDisplayType.TabIndex = 6
            Me.ComboBoxLevels_WeekDisplayType.TabOnEnter = True
            Me.ComboBoxLevels_WeekDisplayType.ValueMember = "Value"
            Me.ComboBoxLevels_WeekDisplayType.WatermarkText = "Select"
            '
            'CheckBoxLevels_PrintDay
            '
            '
            '
            '
            Me.CheckBoxLevels_PrintDay.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevels_PrintDay.CheckValue = 0
            Me.CheckBoxLevels_PrintDay.CheckValueChecked = 1
            Me.CheckBoxLevels_PrintDay.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLevels_PrintDay.CheckValueUnchecked = 0
            Me.CheckBoxLevels_PrintDay.ChildControls = CType(resources.GetObject("CheckBoxLevels_PrintDay.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintDay.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevels_PrintDay.Location = New System.Drawing.Point(129, 75)
            Me.CheckBoxLevels_PrintDay.Name = "CheckBoxLevels_PrintDay"
            Me.CheckBoxLevels_PrintDay.OldestSibling = Nothing
            Me.CheckBoxLevels_PrintDay.SecurityEnabled = True
            Me.CheckBoxLevels_PrintDay.SiblingControls = CType(resources.GetObject("CheckBoxLevels_PrintDay.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintDay.Size = New System.Drawing.Size(120, 20)
            Me.CheckBoxLevels_PrintDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevels_PrintDay.TabIndex = 8
            Me.CheckBoxLevels_PrintDay.TabOnEnter = True
            Me.CheckBoxLevels_PrintDay.Text = "Print Day"
            '
            'CheckBoxLevels_PrintDate
            '
            '
            '
            '
            Me.CheckBoxLevels_PrintDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevels_PrintDate.CheckValue = 0
            Me.CheckBoxLevels_PrintDate.CheckValueChecked = 1
            Me.CheckBoxLevels_PrintDate.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLevels_PrintDate.CheckValueUnchecked = 0
            Me.CheckBoxLevels_PrintDate.ChildControls = CType(resources.GetObject("CheckBoxLevels_PrintDate.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevels_PrintDate.Location = New System.Drawing.Point(3, 75)
            Me.CheckBoxLevels_PrintDate.Name = "CheckBoxLevels_PrintDate"
            Me.CheckBoxLevels_PrintDate.OldestSibling = Nothing
            Me.CheckBoxLevels_PrintDate.SecurityEnabled = True
            Me.CheckBoxLevels_PrintDate.SiblingControls = CType(resources.GetObject("CheckBoxLevels_PrintDate.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintDate.Size = New System.Drawing.Size(120, 20)
            Me.CheckBoxLevels_PrintDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevels_PrintDate.TabIndex = 7
            Me.CheckBoxLevels_PrintDate.TabOnEnter = True
            Me.CheckBoxLevels_PrintDate.Text = "Print Date"
            '
            'CheckBoxLevels_PrintWeek
            '
            '
            '
            '
            Me.CheckBoxLevels_PrintWeek.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevels_PrintWeek.CheckValue = 0
            Me.CheckBoxLevels_PrintWeek.CheckValueChecked = 1
            Me.CheckBoxLevels_PrintWeek.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLevels_PrintWeek.CheckValueUnchecked = 0
            Me.CheckBoxLevels_PrintWeek.ChildControls = CType(resources.GetObject("CheckBoxLevels_PrintWeek.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintWeek.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevels_PrintWeek.Location = New System.Drawing.Point(3, 49)
            Me.CheckBoxLevels_PrintWeek.Name = "CheckBoxLevels_PrintWeek"
            Me.CheckBoxLevels_PrintWeek.OldestSibling = Nothing
            Me.CheckBoxLevels_PrintWeek.SecurityEnabled = True
            Me.CheckBoxLevels_PrintWeek.SiblingControls = CType(resources.GetObject("CheckBoxLevels_PrintWeek.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintWeek.Size = New System.Drawing.Size(120, 20)
            Me.CheckBoxLevels_PrintWeek.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevels_PrintWeek.TabIndex = 4
            Me.CheckBoxLevels_PrintWeek.TabOnEnter = True
            Me.CheckBoxLevels_PrintWeek.Text = "Print Week"
            '
            'CheckBoxLevels_PrintMonthName
            '
            '
            '
            '
            Me.CheckBoxLevels_PrintMonthName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevels_PrintMonthName.CheckValue = 0
            Me.CheckBoxLevels_PrintMonthName.CheckValueChecked = 1
            Me.CheckBoxLevels_PrintMonthName.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLevels_PrintMonthName.CheckValueUnchecked = 0
            Me.CheckBoxLevels_PrintMonthName.ChildControls = CType(resources.GetObject("CheckBoxLevels_PrintMonthName.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintMonthName.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevels_PrintMonthName.Location = New System.Drawing.Point(381, 23)
            Me.CheckBoxLevels_PrintMonthName.Name = "CheckBoxLevels_PrintMonthName"
            Me.CheckBoxLevels_PrintMonthName.OldestSibling = Nothing
            Me.CheckBoxLevels_PrintMonthName.SecurityEnabled = True
            Me.CheckBoxLevels_PrintMonthName.SiblingControls = CType(resources.GetObject("CheckBoxLevels_PrintMonthName.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintMonthName.Size = New System.Drawing.Size(120, 20)
            Me.CheckBoxLevels_PrintMonthName.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevels_PrintMonthName.TabIndex = 3
            Me.CheckBoxLevels_PrintMonthName.TabOnEnter = True
            Me.CheckBoxLevels_PrintMonthName.Text = "Print Month Name"
            '
            'CheckBoxLevels_PrintMonth
            '
            '
            '
            '
            Me.CheckBoxLevels_PrintMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevels_PrintMonth.CheckValue = 0
            Me.CheckBoxLevels_PrintMonth.CheckValueChecked = 1
            Me.CheckBoxLevels_PrintMonth.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLevels_PrintMonth.CheckValueUnchecked = 0
            Me.CheckBoxLevels_PrintMonth.ChildControls = CType(resources.GetObject("CheckBoxLevels_PrintMonth.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintMonth.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevels_PrintMonth.Location = New System.Drawing.Point(255, 23)
            Me.CheckBoxLevels_PrintMonth.Name = "CheckBoxLevels_PrintMonth"
            Me.CheckBoxLevels_PrintMonth.OldestSibling = Nothing
            Me.CheckBoxLevels_PrintMonth.SecurityEnabled = True
            Me.CheckBoxLevels_PrintMonth.SiblingControls = CType(resources.GetObject("CheckBoxLevels_PrintMonth.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintMonth.Size = New System.Drawing.Size(120, 20)
            Me.CheckBoxLevels_PrintMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevels_PrintMonth.TabIndex = 2
            Me.CheckBoxLevels_PrintMonth.TabOnEnter = True
            Me.CheckBoxLevels_PrintMonth.Text = "Print Month"
            '
            'CheckBoxLevels_PrintQuarter
            '
            '
            '
            '
            Me.CheckBoxLevels_PrintQuarter.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevels_PrintQuarter.CheckValue = 0
            Me.CheckBoxLevels_PrintQuarter.CheckValueChecked = 1
            Me.CheckBoxLevels_PrintQuarter.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLevels_PrintQuarter.CheckValueUnchecked = 0
            Me.CheckBoxLevels_PrintQuarter.ChildControls = CType(resources.GetObject("CheckBoxLevels_PrintQuarter.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintQuarter.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevels_PrintQuarter.Location = New System.Drawing.Point(129, 23)
            Me.CheckBoxLevels_PrintQuarter.Name = "CheckBoxLevels_PrintQuarter"
            Me.CheckBoxLevels_PrintQuarter.OldestSibling = Nothing
            Me.CheckBoxLevels_PrintQuarter.SecurityEnabled = True
            Me.CheckBoxLevels_PrintQuarter.SiblingControls = CType(resources.GetObject("CheckBoxLevels_PrintQuarter.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintQuarter.Size = New System.Drawing.Size(120, 20)
            Me.CheckBoxLevels_PrintQuarter.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevels_PrintQuarter.TabIndex = 1
            Me.CheckBoxLevels_PrintQuarter.TabOnEnter = True
            Me.CheckBoxLevels_PrintQuarter.Text = "Print Quarter"
            '
            'CheckBoxLevels_PrintYear
            '
            '
            '
            '
            Me.CheckBoxLevels_PrintYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxLevels_PrintYear.CheckValue = 0
            Me.CheckBoxLevels_PrintYear.CheckValueChecked = 1
            Me.CheckBoxLevels_PrintYear.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxLevels_PrintYear.CheckValueUnchecked = 0
            Me.CheckBoxLevels_PrintYear.ChildControls = CType(resources.GetObject("CheckBoxLevels_PrintYear.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxLevels_PrintYear.Location = New System.Drawing.Point(3, 23)
            Me.CheckBoxLevels_PrintYear.Name = "CheckBoxLevels_PrintYear"
            Me.CheckBoxLevels_PrintYear.OldestSibling = Nothing
            Me.CheckBoxLevels_PrintYear.SecurityEnabled = True
            Me.CheckBoxLevels_PrintYear.SiblingControls = CType(resources.GetObject("CheckBoxLevels_PrintYear.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxLevels_PrintYear.Size = New System.Drawing.Size(120, 20)
            Me.CheckBoxLevels_PrintYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxLevels_PrintYear.TabIndex = 0
            Me.CheckBoxLevels_PrintYear.TabOnEnter = True
            Me.CheckBoxLevels_PrintYear.Text = "Print Year"
            '
            'SearchableComboBoxForm_Location
            '
            Me.SearchableComboBoxForm_Location.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Location.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Location.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.SearchableComboBoxForm_Location.AutoFillMode = False
            Me.SearchableComboBoxForm_Location.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Location.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Location
            Me.SearchableComboBoxForm_Location.DataSource = Nothing
            Me.SearchableComboBoxForm_Location.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Location.DisplayName = ""
            Me.SearchableComboBoxForm_Location.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Location.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.None
            Me.SearchableComboBoxForm_Location.Location = New System.Drawing.Point(162, 38)
            Me.SearchableComboBoxForm_Location.Name = "SearchableComboBoxForm_Location"
            Me.SearchableComboBoxForm_Location.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Location.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Location.Properties.NullText = "Select Location"
            Me.SearchableComboBoxForm_Location.Properties.PopupView = Me.SearchableComboBoxViewForm_Location
            Me.SearchableComboBoxForm_Location.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Location.Properties.ValueMember = "ID"
            Me.SearchableComboBoxForm_Location.SecurityEnabled = True
            Me.SearchableComboBoxForm_Location.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Location.Size = New System.Drawing.Size(818, 20)
            Me.SearchableComboBoxForm_Location.TabIndex = 5
            '
            'SearchableComboBoxViewForm_Location
            '
            Me.SearchableComboBoxViewForm_Location.AFActiveFilterString = ""
            Me.SearchableComboBoxViewForm_Location.AllowExtraItemsInGridLookupEdits = True
            Me.SearchableComboBoxViewForm_Location.AutoFilterLookupColumns = False
            Me.SearchableComboBoxViewForm_Location.AutoloadRepositoryDatasource = True
            Me.SearchableComboBoxViewForm_Location.DataSourceClearing = False
            Me.SearchableComboBoxViewForm_Location.EnableDisabledRows = False
            Me.SearchableComboBoxViewForm_Location.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBoxViewForm_Location.Name = "SearchableComboBoxViewForm_Location"
            Me.SearchableComboBoxViewForm_Location.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBoxViewForm_Location.OptionsView.ShowGroupPanel = False
            Me.SearchableComboBoxViewForm_Location.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.SearchableComboBoxViewForm_Location.RunStandardValidation = True
            Me.SearchableComboBoxViewForm_Location.SkipAddingControlsOnModifyColumn = False
            Me.SearchableComboBoxViewForm_Location.SkipSettingFontOnModifyColumn = False
            '
            'LabelForm_DateHeaderOption
            '
            Me.LabelForm_DateHeaderOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DateHeaderOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DateHeaderOption.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_DateHeaderOption.Name = "LabelForm_DateHeaderOption"
            Me.LabelForm_DateHeaderOption.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_DateHeaderOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DateHeaderOption.TabIndex = 6
            Me.LabelForm_DateHeaderOption.Text = "Date Header Option:"
            '
            'LabelForm_DateOverrideOption
            '
            Me.LabelForm_DateOverrideOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DateOverrideOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DateOverrideOption.Location = New System.Drawing.Point(543, 64)
            Me.LabelForm_DateOverrideOption.Name = "LabelForm_DateOverrideOption"
            Me.LabelForm_DateOverrideOption.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_DateOverrideOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DateOverrideOption.TabIndex = 10
            Me.LabelForm_DateOverrideOption.Text = "Date Override Option:"
            '
            'ComboBoxForm_DateOverrideOption
            '
            Me.ComboBoxForm_DateOverrideOption.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_DateOverrideOption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_DateOverrideOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_DateOverrideOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_DateOverrideOption.AutoFindItemInDataSource = False
            Me.ComboBoxForm_DateOverrideOption.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_DateOverrideOption.BookmarkingEnabled = False
            Me.ComboBoxForm_DateOverrideOption.ClientCode = ""
            Me.ComboBoxForm_DateOverrideOption.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_DateOverrideOption.DisableMouseWheel = False
            Me.ComboBoxForm_DateOverrideOption.DisplayMember = "Name"
            Me.ComboBoxForm_DateOverrideOption.DisplayName = ""
            Me.ComboBoxForm_DateOverrideOption.DivisionCode = ""
            Me.ComboBoxForm_DateOverrideOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_DateOverrideOption.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_DateOverrideOption.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_DateOverrideOption.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_DateOverrideOption.FocusHighlightEnabled = True
            Me.ComboBoxForm_DateOverrideOption.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_DateOverrideOption.FormattingEnabled = True
            Me.ComboBoxForm_DateOverrideOption.ItemHeight = 14
            Me.ComboBoxForm_DateOverrideOption.Location = New System.Drawing.Point(669, 64)
            Me.ComboBoxForm_DateOverrideOption.Name = "ComboBoxForm_DateOverrideOption"
            Me.ComboBoxForm_DateOverrideOption.ReadOnly = False
            Me.ComboBoxForm_DateOverrideOption.SecurityEnabled = True
            Me.ComboBoxForm_DateOverrideOption.Size = New System.Drawing.Size(311, 20)
            Me.ComboBoxForm_DateOverrideOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_DateOverrideOption.TabIndex = 11
            Me.ComboBoxForm_DateOverrideOption.TabOnEnter = True
            Me.ComboBoxForm_DateOverrideOption.ValueMember = "Value"
            Me.ComboBoxForm_DateOverrideOption.WatermarkText = "Select"
            '
            'DataGridViewForm_EstimateOptions
            '
            Me.DataGridViewForm_EstimateOptions.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewForm_EstimateOptions.AllowDragAndDrop = False
            Me.DataGridViewForm_EstimateOptions.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewForm_EstimateOptions.AllowSelectGroupHeaderRow = True
            Me.DataGridViewForm_EstimateOptions.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewForm_EstimateOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewForm_EstimateOptions.AutoFilterLookupColumns = False
            Me.DataGridViewForm_EstimateOptions.AutoloadRepositoryDatasource = True
            Me.DataGridViewForm_EstimateOptions.AutoUpdateViewCaption = True
            Me.DataGridViewForm_EstimateOptions.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewForm_EstimateOptions.DataSource = Nothing
            Me.DataGridViewForm_EstimateOptions.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewForm_EstimateOptions.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewForm_EstimateOptions.ItemDescription = "Estimate Option(s)"
            Me.DataGridViewForm_EstimateOptions.Location = New System.Drawing.Point(12, 376)
            Me.DataGridViewForm_EstimateOptions.MultiSelect = True
            Me.DataGridViewForm_EstimateOptions.Name = "DataGridViewForm_EstimateOptions"
            Me.DataGridViewForm_EstimateOptions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewForm_EstimateOptions.RunStandardValidation = True
            Me.DataGridViewForm_EstimateOptions.ShowColumnMenuOnRightClick = False
            Me.DataGridViewForm_EstimateOptions.ShowSelectDeselectAllButtons = False
            Me.DataGridViewForm_EstimateOptions.Size = New System.Drawing.Size(968, 316)
            Me.DataGridViewForm_EstimateOptions.TabIndex = 22
            Me.DataGridViewForm_EstimateOptions.UseEmbeddedNavigator = False
            Me.DataGridViewForm_EstimateOptions.ViewCaptionHeight = -1
            '
            'LabelForm_GrandTotalDisplayValue
            '
            Me.LabelForm_GrandTotalDisplayValue.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_GrandTotalDisplayValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_GrandTotalDisplayValue.Location = New System.Drawing.Point(12, 324)
            Me.LabelForm_GrandTotalDisplayValue.Name = "LabelForm_GrandTotalDisplayValue"
            Me.LabelForm_GrandTotalDisplayValue.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_GrandTotalDisplayValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_GrandTotalDisplayValue.TabIndex = 18
            Me.LabelForm_GrandTotalDisplayValue.Text = "Grand Total Display Value:"
            '
            'ComboBoxForm_GrandTotalDisplayValue
            '
            Me.ComboBoxForm_GrandTotalDisplayValue.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_GrandTotalDisplayValue.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_GrandTotalDisplayValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_GrandTotalDisplayValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_GrandTotalDisplayValue.AutoFindItemInDataSource = False
            Me.ComboBoxForm_GrandTotalDisplayValue.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_GrandTotalDisplayValue.BookmarkingEnabled = False
            Me.ComboBoxForm_GrandTotalDisplayValue.ClientCode = ""
            Me.ComboBoxForm_GrandTotalDisplayValue.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxForm_GrandTotalDisplayValue.DisableMouseWheel = False
            Me.ComboBoxForm_GrandTotalDisplayValue.DisplayMember = "Name"
            Me.ComboBoxForm_GrandTotalDisplayValue.DisplayName = ""
            Me.ComboBoxForm_GrandTotalDisplayValue.DivisionCode = ""
            Me.ComboBoxForm_GrandTotalDisplayValue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_GrandTotalDisplayValue.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_GrandTotalDisplayValue.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_GrandTotalDisplayValue.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_GrandTotalDisplayValue.FocusHighlightEnabled = True
            Me.ComboBoxForm_GrandTotalDisplayValue.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_GrandTotalDisplayValue.FormattingEnabled = True
            Me.ComboBoxForm_GrandTotalDisplayValue.ItemHeight = 14
            Me.ComboBoxForm_GrandTotalDisplayValue.Location = New System.Drawing.Point(162, 324)
            Me.ComboBoxForm_GrandTotalDisplayValue.Name = "ComboBoxForm_GrandTotalDisplayValue"
            Me.ComboBoxForm_GrandTotalDisplayValue.ReadOnly = False
            Me.ComboBoxForm_GrandTotalDisplayValue.SecurityEnabled = True
            Me.ComboBoxForm_GrandTotalDisplayValue.Size = New System.Drawing.Size(818, 20)
            Me.ComboBoxForm_GrandTotalDisplayValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_GrandTotalDisplayValue.TabIndex = 19
            Me.ComboBoxForm_GrandTotalDisplayValue.TabOnEnter = True
            Me.ComboBoxForm_GrandTotalDisplayValue.ValueMember = "Value"
            Me.ComboBoxForm_GrandTotalDisplayValue.WatermarkText = "Select"
            '
            'LabelForm_SummaryOption
            '
            Me.LabelForm_SummaryOption.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_SummaryOption.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_SummaryOption.Location = New System.Drawing.Point(12, 350)
            Me.LabelForm_SummaryOption.Name = "LabelForm_SummaryOption"
            Me.LabelForm_SummaryOption.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_SummaryOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_SummaryOption.TabIndex = 20
            Me.LabelForm_SummaryOption.Text = "Summary Option:"
            '
            'ComboBoxForm_SummaryOption
            '
            Me.ComboBoxForm_SummaryOption.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_SummaryOption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_SummaryOption.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_SummaryOption.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_SummaryOption.AutoFindItemInDataSource = False
            Me.ComboBoxForm_SummaryOption.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_SummaryOption.BookmarkingEnabled = False
            Me.ComboBoxForm_SummaryOption.ClientCode = ""
            Me.ComboBoxForm_SummaryOption.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumObjects
            Me.ComboBoxForm_SummaryOption.DisableMouseWheel = False
            Me.ComboBoxForm_SummaryOption.DisplayMember = "Description"
            Me.ComboBoxForm_SummaryOption.DisplayName = ""
            Me.ComboBoxForm_SummaryOption.DivisionCode = ""
            Me.ComboBoxForm_SummaryOption.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_SummaryOption.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_SummaryOption.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxForm_SummaryOption.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_SummaryOption.FocusHighlightEnabled = True
            Me.ComboBoxForm_SummaryOption.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_SummaryOption.FormattingEnabled = True
            Me.ComboBoxForm_SummaryOption.ItemHeight = 14
            Me.ComboBoxForm_SummaryOption.Location = New System.Drawing.Point(162, 350)
            Me.ComboBoxForm_SummaryOption.Name = "ComboBoxForm_SummaryOption"
            Me.ComboBoxForm_SummaryOption.ReadOnly = False
            Me.ComboBoxForm_SummaryOption.SecurityEnabled = True
            Me.ComboBoxForm_SummaryOption.Size = New System.Drawing.Size(818, 20)
            Me.ComboBoxForm_SummaryOption.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_SummaryOption.TabIndex = 21
            Me.ComboBoxForm_SummaryOption.TabOnEnter = True
            Me.ComboBoxForm_SummaryOption.ValueMember = "Code"
            Me.ComboBoxForm_SummaryOption.WatermarkText = "Select"
            '
            'LabelForm_DateHeaderColor
            '
            Me.LabelForm_DateHeaderColor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_DateHeaderColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_DateHeaderColor.Location = New System.Drawing.Point(291, 64)
            Me.LabelForm_DateHeaderColor.Name = "LabelForm_DateHeaderColor"
            Me.LabelForm_DateHeaderColor.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_DateHeaderColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_DateHeaderColor.TabIndex = 8
            Me.LabelForm_DateHeaderColor.Text = "Date Header Color:"
            '
            'ColorPickerForm_DateHeaderColor
            '
            Me.ColorPickerForm_DateHeaderColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ColorPickerForm_DateHeaderColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ColorPickerForm_DateHeaderColor.Image = CType(resources.GetObject("ColorPickerForm_DateHeaderColor.Image"), System.Drawing.Image)
            Me.ColorPickerForm_DateHeaderColor.Location = New System.Drawing.Point(417, 64)
            Me.ColorPickerForm_DateHeaderColor.Name = "ColorPickerForm_DateHeaderColor"
            Me.ColorPickerForm_DateHeaderColor.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
            Me.ColorPickerForm_DateHeaderColor.Size = New System.Drawing.Size(37, 20)
            Me.ColorPickerForm_DateHeaderColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ColorPickerForm_DateHeaderColor.TabIndex = 9
            '
            'ColorPickerForm_FieldAreaColor
            '
            Me.ColorPickerForm_FieldAreaColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ColorPickerForm_FieldAreaColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ColorPickerForm_FieldAreaColor.Image = CType(resources.GetObject("ColorPickerForm_FieldAreaColor.Image"), System.Drawing.Image)
            Me.ColorPickerForm_FieldAreaColor.Location = New System.Drawing.Point(162, 194)
            Me.ColorPickerForm_FieldAreaColor.Name = "ColorPickerForm_FieldAreaColor"
            Me.ColorPickerForm_FieldAreaColor.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
            Me.ColorPickerForm_FieldAreaColor.Size = New System.Drawing.Size(37, 20)
            Me.ColorPickerForm_FieldAreaColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ColorPickerForm_FieldAreaColor.TabIndex = 14
            '
            'LabelForm_FieldAreaColor
            '
            Me.LabelForm_FieldAreaColor.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FieldAreaColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FieldAreaColor.Location = New System.Drawing.Point(12, 194)
            Me.LabelForm_FieldAreaColor.Name = "LabelForm_FieldAreaColor"
            Me.LabelForm_FieldAreaColor.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_FieldAreaColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FieldAreaColor.TabIndex = 13
            Me.LabelForm_FieldAreaColor.Text = "Field Area Color:"
            '
            'ButtonForm_Print
            '
            Me.ButtonForm_Print.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Print.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Print.Location = New System.Drawing.Point(743, 698)
            Me.ButtonForm_Print.Name = "ButtonForm_Print"
            Me.ButtonForm_Print.SecurityEnabled = True
            Me.ButtonForm_Print.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Print.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Print.TabIndex = 26
            Me.ButtonForm_Print.Text = "Print"
            '
            'LabelForm_FooterImage
            '
            Me.LabelForm_FooterImage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.LabelForm_FooterImage.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FooterImage.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FooterImage.Location = New System.Drawing.Point(12, 698)
            Me.LabelForm_FooterImage.Name = "LabelForm_FooterImage"
            Me.LabelForm_FooterImage.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_FooterImage.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FooterImage.TabIndex = 23
            Me.LabelForm_FooterImage.Text = "Footer Image:"
            '
            'ComboBoxForm_FooterImages
            '
            Me.ComboBoxForm_FooterImages.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxForm_FooterImages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxForm_FooterImages.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxForm_FooterImages.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxForm_FooterImages.AutoFindItemInDataSource = False
            Me.ComboBoxForm_FooterImages.AutoSelectSingleItemDatasource = False
            Me.ComboBoxForm_FooterImages.BookmarkingEnabled = False
            Me.ComboBoxForm_FooterImages.ClientCode = ""
            Me.ComboBoxForm_FooterImages.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Image
            Me.ComboBoxForm_FooterImages.DisableMouseWheel = False
            Me.ComboBoxForm_FooterImages.DisplayMember = "Name"
            Me.ComboBoxForm_FooterImages.DisplayName = ""
            Me.ComboBoxForm_FooterImages.DivisionCode = ""
            Me.ComboBoxForm_FooterImages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxForm_FooterImages.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxForm_FooterImages.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.PleaseSelect
            Me.ComboBoxForm_FooterImages.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxForm_FooterImages.FocusHighlightEnabled = True
            Me.ComboBoxForm_FooterImages.ForeColor = System.Drawing.Color.Black
            Me.ComboBoxForm_FooterImages.FormattingEnabled = True
            Me.ComboBoxForm_FooterImages.ItemHeight = 14
            Me.ComboBoxForm_FooterImages.Location = New System.Drawing.Point(162, 698)
            Me.ComboBoxForm_FooterImages.Name = "ComboBoxForm_FooterImages"
            Me.ComboBoxForm_FooterImages.ReadOnly = False
            Me.ComboBoxForm_FooterImages.SecurityEnabled = True
            Me.ComboBoxForm_FooterImages.Size = New System.Drawing.Size(480, 20)
            Me.ComboBoxForm_FooterImages.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxForm_FooterImages.TabIndex = 24
            Me.ComboBoxForm_FooterImages.TabOnEnter = True
            Me.ComboBoxForm_FooterImages.ValueMember = "ID"
            Me.ComboBoxForm_FooterImages.WatermarkText = "Select Image"
            '
            'ButtonForm_ManageImages
            '
            Me.ButtonForm_ManageImages.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_ManageImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_ManageImages.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_ManageImages.Location = New System.Drawing.Point(648, 698)
            Me.ButtonForm_ManageImages.Name = "ButtonForm_ManageImages"
            Me.ButtonForm_ManageImages.SecurityEnabled = True
            Me.ButtonForm_ManageImages.Size = New System.Drawing.Size(90, 20)
            Me.ButtonForm_ManageImages.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_ManageImages.TabIndex = 25
            Me.ButtonForm_ManageImages.Text = "Manage Images"
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
            Me.LabelForm_StartDate.Size = New System.Drawing.Size(144, 20)
            Me.LabelForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_StartDate.TabIndex = 0
            Me.LabelForm_StartDate.Text = "Start Date:"
            '
            'LabelForm_EndDate
            '
            Me.LabelForm_EndDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_EndDate.Location = New System.Drawing.Point(291, 12)
            Me.LabelForm_EndDate.Name = "LabelForm_EndDate"
            Me.LabelForm_EndDate.Size = New System.Drawing.Size(120, 20)
            Me.LabelForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_EndDate.TabIndex = 2
            Me.LabelForm_EndDate.Text = "End Date:"
            '
            'DateTimePickerForm_StartDate
            '
            Me.DateTimePickerForm_StartDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_StartDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_StartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_StartDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_StartDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_StartDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_StartDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_StartDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_StartDate.DisplayName = ""
            Me.DateTimePickerForm_StartDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_StartDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_StartDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_StartDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_StartDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_StartDate.Location = New System.Drawing.Point(165, 12)
            Me.DateTimePickerForm_StartDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_StartDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_StartDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_StartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_StartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_StartDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_StartDate.Name = "DateTimePickerForm_StartDate"
            Me.DateTimePickerForm_StartDate.ReadOnly = False
            Me.DateTimePickerForm_StartDate.Size = New System.Drawing.Size(120, 20)
            Me.DateTimePickerForm_StartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_StartDate.TabIndex = 1
            Me.DateTimePickerForm_StartDate.TabOnEnter = True
            Me.DateTimePickerForm_StartDate.Value = New Date(2018, 8, 30, 13, 37, 21, 258)
            '
            'DateTimePickerForm_EndDate
            '
            Me.DateTimePickerForm_EndDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerForm_EndDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerForm_EndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerForm_EndDate.ButtonDropDown.Visible = True
            Me.DateTimePickerForm_EndDate.ButtonFreeText.Checked = True
            Me.DateTimePickerForm_EndDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerForm_EndDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerForm_EndDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerForm_EndDate.DisplayName = ""
            Me.DateTimePickerForm_EndDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerForm_EndDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerForm_EndDate.FocusHighlightEnabled = True
            Me.DateTimePickerForm_EndDate.FreeTextEntryMode = True
            Me.DateTimePickerForm_EndDate.IsPopupCalendarOpen = False
            Me.DateTimePickerForm_EndDate.Location = New System.Drawing.Point(417, 12)
            Me.DateTimePickerForm_EndDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerForm_EndDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerForm_EndDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerForm_EndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.DisplayMonth = New Date(2018, 8, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerForm_EndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerForm_EndDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerForm_EndDate.Name = "DateTimePickerForm_EndDate"
            Me.DateTimePickerForm_EndDate.ReadOnly = False
            Me.DateTimePickerForm_EndDate.Size = New System.Drawing.Size(120, 20)
            Me.DateTimePickerForm_EndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerForm_EndDate.TabIndex = 3
            Me.DateTimePickerForm_EndDate.TabOnEnter = True
            Me.DateTimePickerForm_EndDate.Value = New Date(2018, 8, 30, 13, 37, 17, 152)
            '
            'GroupBoxForm_EstimateColumnTotals
            '
            Me.GroupBoxForm_EstimateColumnTotals.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_EstimateColumnTotals.Controls.Add(Me.ColorPickerEstimateColumnTotals_AreaColor)
            Me.GroupBoxForm_EstimateColumnTotals.Controls.Add(Me.LabelEstimateColumnTotals_AreaColor)
            Me.GroupBoxForm_EstimateColumnTotals.Controls.Add(Me.RadioButtonEstimateColumnTotals_Both)
            Me.GroupBoxForm_EstimateColumnTotals.Controls.Add(Me.RadioButtonEstimateColumnTotals_ByMonth)
            Me.GroupBoxForm_EstimateColumnTotals.Controls.Add(Me.RadioButtonEstimateColumnTotals_Default)
            Me.GroupBoxForm_EstimateColumnTotals.Controls.Add(Me.CheckBoxEstimateColumnTotals_Show)
            Me.GroupBoxForm_EstimateColumnTotals.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.BeforeText
            Me.GroupBoxForm_EstimateColumnTotals.GroupStyle = DevExpress.Utils.GroupStyle.Title
            Me.GroupBoxForm_EstimateColumnTotals.Location = New System.Drawing.Point(162, 220)
            Me.GroupBoxForm_EstimateColumnTotals.Name = "GroupBoxForm_EstimateColumnTotals"
            Me.GroupBoxForm_EstimateColumnTotals.Size = New System.Drawing.Size(818, 46)
            Me.GroupBoxForm_EstimateColumnTotals.TabIndex = 16
            Me.GroupBoxForm_EstimateColumnTotals.Text = "   Estimate Column Totals"
            '
            'ColorPickerEstimateColumnTotals_AreaColor
            '
            Me.ColorPickerEstimateColumnTotals_AreaColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ColorPickerEstimateColumnTotals_AreaColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ColorPickerEstimateColumnTotals_AreaColor.Enabled = False
            Me.ColorPickerEstimateColumnTotals_AreaColor.Image = CType(resources.GetObject("ColorPickerEstimateColumnTotals_AreaColor.Image"), System.Drawing.Image)
            Me.ColorPickerEstimateColumnTotals_AreaColor.Location = New System.Drawing.Point(507, 23)
            Me.ColorPickerEstimateColumnTotals_AreaColor.Name = "ColorPickerEstimateColumnTotals_AreaColor"
            Me.ColorPickerEstimateColumnTotals_AreaColor.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
            Me.ColorPickerEstimateColumnTotals_AreaColor.Size = New System.Drawing.Size(37, 20)
            Me.ColorPickerEstimateColumnTotals_AreaColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ColorPickerEstimateColumnTotals_AreaColor.TabIndex = 5
            '
            'LabelEstimateColumnTotals_AreaColor
            '
            Me.LabelEstimateColumnTotals_AreaColor.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelEstimateColumnTotals_AreaColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelEstimateColumnTotals_AreaColor.Enabled = False
            Me.LabelEstimateColumnTotals_AreaColor.Location = New System.Drawing.Point(381, 23)
            Me.LabelEstimateColumnTotals_AreaColor.Name = "LabelEstimateColumnTotals_AreaColor"
            Me.LabelEstimateColumnTotals_AreaColor.Size = New System.Drawing.Size(120, 20)
            Me.LabelEstimateColumnTotals_AreaColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelEstimateColumnTotals_AreaColor.TabIndex = 4
            Me.LabelEstimateColumnTotals_AreaColor.Text = "Area Color:"
            '
            'RadioButtonEstimateColumnTotals_Both
            '
            Me.RadioButtonEstimateColumnTotals_Both.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonEstimateColumnTotals_Both.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonEstimateColumnTotals_Both.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonEstimateColumnTotals_Both.Enabled = False
            Me.RadioButtonEstimateColumnTotals_Both.Location = New System.Drawing.Point(255, 23)
            Me.RadioButtonEstimateColumnTotals_Both.Name = "RadioButtonEstimateColumnTotals_Both"
            Me.RadioButtonEstimateColumnTotals_Both.SecurityEnabled = True
            Me.RadioButtonEstimateColumnTotals_Both.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonEstimateColumnTotals_Both.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonEstimateColumnTotals_Both.TabIndex = 3
            Me.RadioButtonEstimateColumnTotals_Both.TabOnEnter = True
            Me.RadioButtonEstimateColumnTotals_Both.TabStop = False
            Me.RadioButtonEstimateColumnTotals_Both.Text = "Both"
            '
            'RadioButtonEstimateColumnTotals_ByMonth
            '
            Me.RadioButtonEstimateColumnTotals_ByMonth.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonEstimateColumnTotals_ByMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonEstimateColumnTotals_ByMonth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonEstimateColumnTotals_ByMonth.Enabled = False
            Me.RadioButtonEstimateColumnTotals_ByMonth.Location = New System.Drawing.Point(129, 23)
            Me.RadioButtonEstimateColumnTotals_ByMonth.Name = "RadioButtonEstimateColumnTotals_ByMonth"
            Me.RadioButtonEstimateColumnTotals_ByMonth.SecurityEnabled = True
            Me.RadioButtonEstimateColumnTotals_ByMonth.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonEstimateColumnTotals_ByMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonEstimateColumnTotals_ByMonth.TabIndex = 2
            Me.RadioButtonEstimateColumnTotals_ByMonth.TabOnEnter = True
            Me.RadioButtonEstimateColumnTotals_ByMonth.TabStop = False
            Me.RadioButtonEstimateColumnTotals_ByMonth.Text = "By Month"
            '
            'RadioButtonEstimateColumnTotals_Default
            '
            Me.RadioButtonEstimateColumnTotals_Default.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonEstimateColumnTotals_Default.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonEstimateColumnTotals_Default.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonEstimateColumnTotals_Default.Checked = True
            Me.RadioButtonEstimateColumnTotals_Default.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonEstimateColumnTotals_Default.CheckValue = "Y"
            Me.RadioButtonEstimateColumnTotals_Default.Enabled = False
            Me.RadioButtonEstimateColumnTotals_Default.Location = New System.Drawing.Point(3, 23)
            Me.RadioButtonEstimateColumnTotals_Default.Name = "RadioButtonEstimateColumnTotals_Default"
            Me.RadioButtonEstimateColumnTotals_Default.SecurityEnabled = True
            Me.RadioButtonEstimateColumnTotals_Default.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonEstimateColumnTotals_Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonEstimateColumnTotals_Default.TabIndex = 1
            Me.RadioButtonEstimateColumnTotals_Default.TabOnEnter = True
            Me.RadioButtonEstimateColumnTotals_Default.Text = "Default"
            '
            'CheckBoxEstimateColumnTotals_Show
            '
            Me.CheckBoxEstimateColumnTotals_Show.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxEstimateColumnTotals_Show.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxEstimateColumnTotals_Show.CheckValue = 0
            Me.CheckBoxEstimateColumnTotals_Show.CheckValueChecked = 1
            Me.CheckBoxEstimateColumnTotals_Show.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxEstimateColumnTotals_Show.CheckValueUnchecked = 0
            Me.CheckBoxEstimateColumnTotals_Show.ChildControls = CType(resources.GetObject("CheckBoxEstimateColumnTotals_Show.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimateColumnTotals_Show.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxEstimateColumnTotals_Show.Location = New System.Drawing.Point(3, 0)
            Me.CheckBoxEstimateColumnTotals_Show.Name = "CheckBoxEstimateColumnTotals_Show"
            Me.CheckBoxEstimateColumnTotals_Show.OldestSibling = Nothing
            Me.CheckBoxEstimateColumnTotals_Show.SecurityEnabled = True
            Me.CheckBoxEstimateColumnTotals_Show.SiblingControls = CType(resources.GetObject("CheckBoxEstimateColumnTotals_Show.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxEstimateColumnTotals_Show.Size = New System.Drawing.Size(34, 20)
            Me.CheckBoxEstimateColumnTotals_Show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxEstimateColumnTotals_Show.TabIndex = 0
            Me.CheckBoxEstimateColumnTotals_Show.TabOnEnter = True
            '
            'GroupBoxForm_GrandTotals
            '
            Me.GroupBoxForm_GrandTotals.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxForm_GrandTotals.Controls.Add(Me.ColorPickerGrandTotals_AreaColor)
            Me.GroupBoxForm_GrandTotals.Controls.Add(Me.LabelGrandTotals_AreaColor)
            Me.GroupBoxForm_GrandTotals.Controls.Add(Me.RadioButtonGrandTotals_Both)
            Me.GroupBoxForm_GrandTotals.Controls.Add(Me.RadioButtonGrandTotals_ByMonth)
            Me.GroupBoxForm_GrandTotals.Controls.Add(Me.RadioButtonGrandTotals_Default)
            Me.GroupBoxForm_GrandTotals.Controls.Add(Me.CheckBoxGrandTotals_Show)
            Me.GroupBoxForm_GrandTotals.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.BeforeText
            Me.GroupBoxForm_GrandTotals.GroupStyle = DevExpress.Utils.GroupStyle.Title
            Me.GroupBoxForm_GrandTotals.Location = New System.Drawing.Point(162, 272)
            Me.GroupBoxForm_GrandTotals.Name = "GroupBoxForm_GrandTotals"
            Me.GroupBoxForm_GrandTotals.Size = New System.Drawing.Size(818, 46)
            Me.GroupBoxForm_GrandTotals.TabIndex = 17
            Me.GroupBoxForm_GrandTotals.Text = "    Grand Totals"
            '
            'ColorPickerGrandTotals_AreaColor
            '
            Me.ColorPickerGrandTotals_AreaColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ColorPickerGrandTotals_AreaColor.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ColorPickerGrandTotals_AreaColor.Enabled = False
            Me.ColorPickerGrandTotals_AreaColor.Image = CType(resources.GetObject("ColorPickerGrandTotals_AreaColor.Image"), System.Drawing.Image)
            Me.ColorPickerGrandTotals_AreaColor.Location = New System.Drawing.Point(507, 23)
            Me.ColorPickerGrandTotals_AreaColor.Name = "ColorPickerGrandTotals_AreaColor"
            Me.ColorPickerGrandTotals_AreaColor.SelectedColorImageRectangle = New System.Drawing.Rectangle(2, 2, 12, 12)
            Me.ColorPickerGrandTotals_AreaColor.Size = New System.Drawing.Size(37, 20)
            Me.ColorPickerGrandTotals_AreaColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ColorPickerGrandTotals_AreaColor.TabIndex = 5
            '
            'LabelGrandTotals_AreaColor
            '
            Me.LabelGrandTotals_AreaColor.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.LabelGrandTotals_AreaColor.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelGrandTotals_AreaColor.Enabled = False
            Me.LabelGrandTotals_AreaColor.Location = New System.Drawing.Point(381, 23)
            Me.LabelGrandTotals_AreaColor.Name = "LabelGrandTotals_AreaColor"
            Me.LabelGrandTotals_AreaColor.Size = New System.Drawing.Size(120, 20)
            Me.LabelGrandTotals_AreaColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelGrandTotals_AreaColor.TabIndex = 4
            Me.LabelGrandTotals_AreaColor.Text = "Area Color:"
            '
            'RadioButtonGrandTotals_Both
            '
            Me.RadioButtonGrandTotals_Both.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonGrandTotals_Both.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGrandTotals_Both.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGrandTotals_Both.Enabled = False
            Me.RadioButtonGrandTotals_Both.Location = New System.Drawing.Point(255, 23)
            Me.RadioButtonGrandTotals_Both.Name = "RadioButtonGrandTotals_Both"
            Me.RadioButtonGrandTotals_Both.SecurityEnabled = True
            Me.RadioButtonGrandTotals_Both.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonGrandTotals_Both.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGrandTotals_Both.TabIndex = 3
            Me.RadioButtonGrandTotals_Both.TabOnEnter = True
            Me.RadioButtonGrandTotals_Both.TabStop = False
            Me.RadioButtonGrandTotals_Both.Text = "Both"
            '
            'RadioButtonGrandTotals_ByMonth
            '
            Me.RadioButtonGrandTotals_ByMonth.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonGrandTotals_ByMonth.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGrandTotals_ByMonth.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGrandTotals_ByMonth.Enabled = False
            Me.RadioButtonGrandTotals_ByMonth.Location = New System.Drawing.Point(129, 23)
            Me.RadioButtonGrandTotals_ByMonth.Name = "RadioButtonGrandTotals_ByMonth"
            Me.RadioButtonGrandTotals_ByMonth.SecurityEnabled = True
            Me.RadioButtonGrandTotals_ByMonth.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonGrandTotals_ByMonth.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGrandTotals_ByMonth.TabIndex = 2
            Me.RadioButtonGrandTotals_ByMonth.TabOnEnter = True
            Me.RadioButtonGrandTotals_ByMonth.TabStop = False
            Me.RadioButtonGrandTotals_ByMonth.Text = "By Month"
            '
            'RadioButtonGrandTotals_Default
            '
            Me.RadioButtonGrandTotals_Default.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.RadioButtonGrandTotals_Default.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonGrandTotals_Default.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonGrandTotals_Default.Checked = True
            Me.RadioButtonGrandTotals_Default.CheckState = System.Windows.Forms.CheckState.Checked
            Me.RadioButtonGrandTotals_Default.CheckValue = "Y"
            Me.RadioButtonGrandTotals_Default.Enabled = False
            Me.RadioButtonGrandTotals_Default.Location = New System.Drawing.Point(3, 23)
            Me.RadioButtonGrandTotals_Default.Name = "RadioButtonGrandTotals_Default"
            Me.RadioButtonGrandTotals_Default.SecurityEnabled = True
            Me.RadioButtonGrandTotals_Default.Size = New System.Drawing.Size(120, 20)
            Me.RadioButtonGrandTotals_Default.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonGrandTotals_Default.TabIndex = 1
            Me.RadioButtonGrandTotals_Default.TabOnEnter = True
            Me.RadioButtonGrandTotals_Default.Text = "Default"
            '
            'CheckBoxGrandTotals_Show
            '
            Me.CheckBoxGrandTotals_Show.BackColor = System.Drawing.Color.Transparent
            '
            '
            '
            Me.CheckBoxGrandTotals_Show.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxGrandTotals_Show.CheckValue = 0
            Me.CheckBoxGrandTotals_Show.CheckValueChecked = 1
            Me.CheckBoxGrandTotals_Show.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxGrandTotals_Show.CheckValueUnchecked = 0
            Me.CheckBoxGrandTotals_Show.ChildControls = CType(resources.GetObject("CheckBoxGrandTotals_Show.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGrandTotals_Show.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxGrandTotals_Show.Location = New System.Drawing.Point(3, 0)
            Me.CheckBoxGrandTotals_Show.Name = "CheckBoxGrandTotals_Show"
            Me.CheckBoxGrandTotals_Show.OldestSibling = Nothing
            Me.CheckBoxGrandTotals_Show.SecurityEnabled = True
            Me.CheckBoxGrandTotals_Show.SiblingControls = CType(resources.GetObject("CheckBoxGrandTotals_Show.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxGrandTotals_Show.Size = New System.Drawing.Size(34, 20)
            Me.CheckBoxGrandTotals_Show.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxGrandTotals_Show.TabIndex = 0
            Me.CheckBoxGrandTotals_Show.TabOnEnter = True
            '
            'CheckBoxForm_RoundToNearestDollar
            '
            Me.CheckBoxForm_RoundToNearestDollar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_RoundToNearestDollar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_RoundToNearestDollar.CheckValue = 0
            Me.CheckBoxForm_RoundToNearestDollar.CheckValueChecked = 1
            Me.CheckBoxForm_RoundToNearestDollar.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_RoundToNearestDollar.CheckValueUnchecked = 0
            Me.CheckBoxForm_RoundToNearestDollar.ChildControls = CType(resources.GetObject("CheckBoxForm_RoundToNearestDollar.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_RoundToNearestDollar.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_RoundToNearestDollar.Location = New System.Drawing.Point(291, 194)
            Me.CheckBoxForm_RoundToNearestDollar.Name = "CheckBoxForm_RoundToNearestDollar"
            Me.CheckBoxForm_RoundToNearestDollar.OldestSibling = Nothing
            Me.CheckBoxForm_RoundToNearestDollar.SecurityEnabled = True
            Me.CheckBoxForm_RoundToNearestDollar.SiblingControls = CType(resources.GetObject("CheckBoxForm_RoundToNearestDollar.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_RoundToNearestDollar.Size = New System.Drawing.Size(689, 20)
            Me.CheckBoxForm_RoundToNearestDollar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_RoundToNearestDollar.TabIndex = 15
            Me.CheckBoxForm_RoundToNearestDollar.TabOnEnter = True
            Me.CheckBoxForm_RoundToNearestDollar.Text = "Round To Nearest Dollar"
            '
            'MediaPlanFlowChartOptionsDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(992, 730)
            Me.Controls.Add(Me.CheckBoxForm_RoundToNearestDollar)
            Me.Controls.Add(Me.GroupBoxForm_GrandTotals)
            Me.Controls.Add(Me.GroupBoxForm_EstimateColumnTotals)
            Me.Controls.Add(Me.DateTimePickerForm_EndDate)
            Me.Controls.Add(Me.DateTimePickerForm_StartDate)
            Me.Controls.Add(Me.LabelForm_EndDate)
            Me.Controls.Add(Me.LabelForm_StartDate)
            Me.Controls.Add(Me.ButtonForm_ManageImages)
            Me.Controls.Add(Me.ComboBoxForm_FooterImages)
            Me.Controls.Add(Me.LabelForm_FooterImage)
            Me.Controls.Add(Me.ButtonForm_Print)
            Me.Controls.Add(Me.ColorPickerForm_FieldAreaColor)
            Me.Controls.Add(Me.LabelForm_FieldAreaColor)
            Me.Controls.Add(Me.ColorPickerForm_DateHeaderColor)
            Me.Controls.Add(Me.LabelForm_DateHeaderColor)
            Me.Controls.Add(Me.LabelForm_SummaryOption)
            Me.Controls.Add(Me.ComboBoxForm_SummaryOption)
            Me.Controls.Add(Me.LabelForm_GrandTotalDisplayValue)
            Me.Controls.Add(Me.ComboBoxForm_GrandTotalDisplayValue)
            Me.Controls.Add(Me.DataGridViewForm_EstimateOptions)
            Me.Controls.Add(Me.LabelForm_DateOverrideOption)
            Me.Controls.Add(Me.ComboBoxForm_DateOverrideOption)
            Me.Controls.Add(Me.LabelForm_DateHeaderOption)
            Me.Controls.Add(Me.SearchableComboBoxForm_Location)
            Me.Controls.Add(Me.GroupBoxForm_Levels)
            Me.Controls.Add(Me.ComboBoxForm_DateHeaderOption)
            Me.Controls.Add(Me.LabelForm_Location)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "MediaPlanFlowChartOptionsDialog"
            Me.Text = "Flow Chart Options"
            CType(Me.GroupBoxForm_Levels, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_Levels.ResumeLayout(False)
            CType(Me.SearchableComboBoxForm_Location.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBoxViewForm_Location, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_StartDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerForm_EndDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxForm_EstimateColumnTotals, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_EstimateColumnTotals.ResumeLayout(False)
            CType(Me.GroupBoxForm_GrandTotals, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxForm_GrandTotals.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_Location As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_DateHeaderOption As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents GroupBoxForm_Levels As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents SearchableComboBoxForm_Location As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBoxViewForm_Location As AdvantageFramework.WinForm.Presentation.Controls.GridView
        Friend WithEvents LabelForm_DateHeaderOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelLevels_WeekDisplayType As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxLevels_WeekDisplayType As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents CheckBoxLevels_PrintDay As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevels_PrintDate As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevels_PrintWeek As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevels_PrintMonthName As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevels_PrintMonth As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevels_PrintQuarter As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxLevels_PrintYear As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_DateOverrideOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_DateOverrideOption As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents DataGridViewForm_EstimateOptions As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelForm_GrandTotalDisplayValue As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_GrandTotalDisplayValue As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_SummaryOption As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_SummaryOption As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents LabelForm_DateHeaderColor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ColorPickerForm_DateHeaderColor As DevComponents.DotNetBar.ColorPickerButton
        Friend WithEvents ColorPickerForm_FieldAreaColor As DevComponents.DotNetBar.ColorPickerButton
        Friend WithEvents LabelForm_FieldAreaColor As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ButtonForm_Print As WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_FooterImage As WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxForm_FooterImages As WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ButtonForm_ManageImages As WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_StartDate As WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_EndDate As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerForm_StartDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerForm_EndDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents GroupBoxForm_EstimateColumnTotals As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxEstimateColumnTotals_Show As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ColorPickerEstimateColumnTotals_AreaColor As DevComponents.DotNetBar.ColorPickerButton
        Friend WithEvents LabelEstimateColumnTotals_AreaColor As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonEstimateColumnTotals_Both As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonEstimateColumnTotals_ByMonth As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonEstimateColumnTotals_Default As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents GroupBoxForm_GrandTotals As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents ColorPickerGrandTotals_AreaColor As DevComponents.DotNetBar.ColorPickerButton
        Friend WithEvents LabelGrandTotals_AreaColor As WinForm.Presentation.Controls.Label
        Friend WithEvents RadioButtonGrandTotals_Both As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonGrandTotals_ByMonth As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonGrandTotals_Default As WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents CheckBoxGrandTotals_Show As WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxForm_RoundToNearestDollar As WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace