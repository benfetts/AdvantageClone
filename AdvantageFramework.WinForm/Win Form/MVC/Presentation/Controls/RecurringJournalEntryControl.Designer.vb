Namespace WinForm.MVC.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class RecurringJournalEntryControl
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RecurringJournalEntryControl))
            Me.TextBoxControl_CreatedBy = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.NumericInputControl_ControlNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_LastPostingDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_CreatedBy = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_LastPostingPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_Cycle = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxControl_Type = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonType_Reversing = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonType_Standard = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_ControlNumber = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.CheckBoxControl_UnlimitedPostings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.NumericInputControl_NumberOfPostings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_NumberOfPostings = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.ComboBoxControl_StartingPostPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.LabelControl_StartingPostPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.NumericInputControl_TotalNumberPosted = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_TotalNumberPosted = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.TextBoxControl_LastPostingPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxControl_PostedBy = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_PostedBy = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.CheckBoxControl_Inactive = New AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox()
            Me.ComboBoxControl_Cycle = New AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox()
            Me.DateTimePickerControl_LastPostingDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DataGridViewControl_RJEDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            CType(Me.NumericInputControl_ControlNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxControl_Type, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Type.SuspendLayout()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.NumericInputControl_NumberOfPostings.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_TotalNumberPosted.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerControl_LastPostingDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TextBoxControl_CreatedBy
            '
            Me.TextBoxControl_CreatedBy.AgencyImportPath = Nothing
            Me.TextBoxControl_CreatedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_CreatedBy.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_CreatedBy.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_CreatedBy.CheckSpellingOnValidate = False
            Me.TextBoxControl_CreatedBy.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_CreatedBy.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_CreatedBy.DisplayName = ""
            Me.TextBoxControl_CreatedBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_CreatedBy.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_CreatedBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_CreatedBy.FocusHighlightEnabled = True
            Me.TextBoxControl_CreatedBy.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_CreatedBy.Location = New System.Drawing.Point(87, 54)
            Me.TextBoxControl_CreatedBy.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_CreatedBy.Name = "TextBoxControl_CreatedBy"
            Me.TextBoxControl_CreatedBy.SecurityEnabled = True
            Me.TextBoxControl_CreatedBy.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_CreatedBy.Size = New System.Drawing.Size(119, 21)
            Me.TextBoxControl_CreatedBy.StartingFolderName = Nothing
            Me.TextBoxControl_CreatedBy.TabIndex = 8
            Me.TextBoxControl_CreatedBy.TabOnEnter = True
            Me.TextBoxControl_CreatedBy.TabStop = False
            '
            'NumericInputControl_ControlNumber
            '
            Me.NumericInputControl_ControlNumber.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_ControlNumber.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputControl_ControlNumber.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_ControlNumber.EnterMoveNextControl = True
            Me.NumericInputControl_ControlNumber.Location = New System.Drawing.Point(87, 1)
            Me.NumericInputControl_ControlNumber.Name = "NumericInputControl_ControlNumber"
            Me.NumericInputControl_ControlNumber.Properties.AllowMouseWheel = False
            Me.NumericInputControl_ControlNumber.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_ControlNumber.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_ControlNumber.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_ControlNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_ControlNumber.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_ControlNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_ControlNumber.Properties.IsFloatValue = False
            Me.NumericInputControl_ControlNumber.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_ControlNumber.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_ControlNumber.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputControl_ControlNumber.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputControl_ControlNumber.SecurityEnabled = True
            Me.NumericInputControl_ControlNumber.Size = New System.Drawing.Size(119, 20)
            Me.NumericInputControl_ControlNumber.TabIndex = 1
            Me.NumericInputControl_ControlNumber.TabStop = False
            '
            'LabelControl_LastPostingDate
            '
            Me.LabelControl_LastPostingDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_LastPostingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_LastPostingDate.Location = New System.Drawing.Point(585, 0)
            Me.LabelControl_LastPostingDate.Name = "LabelControl_LastPostingDate"
            Me.LabelControl_LastPostingDate.Size = New System.Drawing.Size(111, 21)
            Me.LabelControl_LastPostingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_LastPostingDate.TabIndex = 15
            Me.LabelControl_LastPostingDate.Text = "Last Posting Date:"
            '
            'LabelControl_CreatedBy
            '
            Me.LabelControl_CreatedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_CreatedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_CreatedBy.Location = New System.Drawing.Point(0, 54)
            Me.LabelControl_CreatedBy.Name = "LabelControl_CreatedBy"
            Me.LabelControl_CreatedBy.Size = New System.Drawing.Size(81, 21)
            Me.LabelControl_CreatedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_CreatedBy.TabIndex = 7
            Me.LabelControl_CreatedBy.Text = "Created By:"
            '
            'LabelControl_LastPostingPeriod
            '
            Me.LabelControl_LastPostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_LastPostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_LastPostingPeriod.Location = New System.Drawing.Point(585, 27)
            Me.LabelControl_LastPostingPeriod.Name = "LabelControl_LastPostingPeriod"
            Me.LabelControl_LastPostingPeriod.Size = New System.Drawing.Size(111, 21)
            Me.LabelControl_LastPostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_LastPostingPeriod.TabIndex = 17
            Me.LabelControl_LastPostingPeriod.Text = "Last Posting Period:"
            '
            'LabelControl_Cycle
            '
            Me.LabelControl_Cycle.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Cycle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Cycle.Location = New System.Drawing.Point(0, 27)
            Me.LabelControl_Cycle.Name = "LabelControl_Cycle"
            Me.LabelControl_Cycle.Size = New System.Drawing.Size(81, 21)
            Me.LabelControl_Cycle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Cycle.TabIndex = 3
            Me.LabelControl_Cycle.Text = "Cycle:"
            '
            'GroupBoxControl_Type
            '
            Me.GroupBoxControl_Type.Controls.Add(Me.RadioButtonType_Reversing)
            Me.GroupBoxControl_Type.Controls.Add(Me.RadioButtonType_Standard)
            Me.GroupBoxControl_Type.Location = New System.Drawing.Point(494, 0)
            Me.GroupBoxControl_Type.Name = "GroupBoxControl_Type"
            Me.GroupBoxControl_Type.Size = New System.Drawing.Size(82, 74)
            Me.GroupBoxControl_Type.TabIndex = 14
            Me.GroupBoxControl_Type.TabStop = True
            Me.GroupBoxControl_Type.Text = "Type"
            '
            'RadioButtonType_Reversing
            '
            Me.RadioButtonType_Reversing.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonType_Reversing.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonType_Reversing.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonType_Reversing.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonType_Reversing.Name = "RadioButtonType_Reversing"
            Me.RadioButtonType_Reversing.SecurityEnabled = True
            Me.RadioButtonType_Reversing.Size = New System.Drawing.Size(72, 21)
            Me.RadioButtonType_Reversing.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonType_Reversing.TabIndex = 1
            Me.RadioButtonType_Reversing.TabOnEnter = True
            Me.RadioButtonType_Reversing.TabStop = False
            Me.RadioButtonType_Reversing.Tag = "2"
            Me.RadioButtonType_Reversing.Text = "Reversing"
            '
            'RadioButtonType_Standard
            '
            Me.RadioButtonType_Standard.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonType_Standard.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonType_Standard.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonType_Standard.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonType_Standard.Name = "RadioButtonType_Standard"
            Me.RadioButtonType_Standard.SecurityEnabled = True
            Me.RadioButtonType_Standard.Size = New System.Drawing.Size(72, 21)
            Me.RadioButtonType_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonType_Standard.TabIndex = 0
            Me.RadioButtonType_Standard.TabOnEnter = True
            Me.RadioButtonType_Standard.TabStop = False
            Me.RadioButtonType_Standard.Tag = "1"
            Me.RadioButtonType_Standard.Text = "Standard"
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.AgencyImportPath = Nothing
            Me.TextBoxControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_Description.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_Description.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_Description.CheckSpellingOnValidate = False
            Me.TextBoxControl_Description.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_Description.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_Description.DisplayName = ""
            Me.TextBoxControl_Description.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_Description.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_Description.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_Description.FocusHighlightEnabled = True
            Me.TextBoxControl_Description.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(87, 81)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.SecurityEnabled = True
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(492, 21)
            Me.TextBoxControl_Description.StartingFolderName = Nothing
            Me.TextBoxControl_Description.TabIndex = 13
            Me.TextBoxControl_Description.TabOnEnter = True
            '
            'LabelControl_Description
            '
            Me.LabelControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Description.Location = New System.Drawing.Point(0, 81)
            Me.LabelControl_Description.Name = "LabelControl_Description"
            Me.LabelControl_Description.Size = New System.Drawing.Size(81, 21)
            Me.LabelControl_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Description.TabIndex = 12
            Me.LabelControl_Description.Text = "Description:"
            '
            'LabelControl_ControlNumber
            '
            Me.LabelControl_ControlNumber.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_ControlNumber.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_ControlNumber.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_ControlNumber.Name = "LabelControl_ControlNumber"
            Me.LabelControl_ControlNumber.Size = New System.Drawing.Size(81, 21)
            Me.LabelControl_ControlNumber.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_ControlNumber.TabIndex = 0
            Me.LabelControl_ControlNumber.Text = "Control #:"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxControl_UnlimitedPostings)
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxControl_Type)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputControl_NumberOfPostings)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_NumberOfPostings)
            Me.PanelControl_Control.Controls.Add(Me.ComboBoxControl_StartingPostPeriod)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_StartingPostPeriod)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputControl_TotalNumberPosted)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_TotalNumberPosted)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_LastPostingPeriod)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_PostedBy)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_PostedBy)
            Me.PanelControl_Control.Controls.Add(Me.CheckBoxControl_Inactive)
            Me.PanelControl_Control.Controls.Add(Me.ComboBoxControl_Cycle)
            Me.PanelControl_Control.Controls.Add(Me.DateTimePickerControl_LastPostingDate)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewControl_RJEDetails)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputControl_ControlNumber)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_ControlNumber)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Description)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_CreatedBy)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Description)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Cycle)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_LastPostingPeriod)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_CreatedBy)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_LastPostingDate)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(796, 458)
            Me.PanelControl_Control.TabIndex = 0
            '
            'CheckBoxControl_UnlimitedPostings
            '
            '
            '
            '
            Me.CheckBoxControl_UnlimitedPostings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_UnlimitedPostings.CheckValue = 0
            Me.CheckBoxControl_UnlimitedPostings.CheckValueChecked = 1
            Me.CheckBoxControl_UnlimitedPostings.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_UnlimitedPostings.CheckValueUnchecked = 0
            Me.CheckBoxControl_UnlimitedPostings.ChildControls = CType(resources.GetObject("CheckBoxControl_UnlimitedPostings.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_UnlimitedPostings.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_UnlimitedPostings.Location = New System.Drawing.Point(370, 55)
            Me.CheckBoxControl_UnlimitedPostings.Name = "CheckBoxControl_UnlimitedPostings"
            Me.CheckBoxControl_UnlimitedPostings.OldestSibling = Nothing
            Me.CheckBoxControl_UnlimitedPostings.SecurityEnabled = True
            Me.CheckBoxControl_UnlimitedPostings.SiblingControls = CType(resources.GetObject("CheckBoxControl_UnlimitedPostings.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_UnlimitedPostings.Size = New System.Drawing.Size(118, 20)
            Me.CheckBoxControl_UnlimitedPostings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_UnlimitedPostings.TabIndex = 11
            Me.CheckBoxControl_UnlimitedPostings.TabOnEnter = True
            Me.CheckBoxControl_UnlimitedPostings.Text = "Unlimited"
            '
            'NumericInputControl_NumberOfPostings
            '
            Me.NumericInputControl_NumberOfPostings.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_NumberOfPostings.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputControl_NumberOfPostings.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_NumberOfPostings.EnterMoveNextControl = True
            Me.NumericInputControl_NumberOfPostings.Location = New System.Drawing.Point(326, 55)
            Me.NumericInputControl_NumberOfPostings.Name = "NumericInputControl_NumberOfPostings"
            Me.NumericInputControl_NumberOfPostings.Properties.AllowMouseWheel = False
            Me.NumericInputControl_NumberOfPostings.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_NumberOfPostings.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_NumberOfPostings.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_NumberOfPostings.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_NumberOfPostings.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_NumberOfPostings.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_NumberOfPostings.Properties.IsFloatValue = False
            Me.NumericInputControl_NumberOfPostings.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_NumberOfPostings.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_NumberOfPostings.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputControl_NumberOfPostings.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputControl_NumberOfPostings.SecurityEnabled = True
            Me.NumericInputControl_NumberOfPostings.Size = New System.Drawing.Size(38, 20)
            Me.NumericInputControl_NumberOfPostings.TabIndex = 10
            Me.NumericInputControl_NumberOfPostings.TabStop = False
            '
            'LabelControl_NumberOfPostings
            '
            Me.LabelControl_NumberOfPostings.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_NumberOfPostings.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_NumberOfPostings.Location = New System.Drawing.Point(212, 55)
            Me.LabelControl_NumberOfPostings.Name = "LabelControl_NumberOfPostings"
            Me.LabelControl_NumberOfPostings.Size = New System.Drawing.Size(108, 21)
            Me.LabelControl_NumberOfPostings.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_NumberOfPostings.TabIndex = 9
            Me.LabelControl_NumberOfPostings.Text = "Number of Postings:"
            '
            'ComboBoxControl_StartingPostPeriod
            '
            Me.ComboBoxControl_StartingPostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_StartingPostPeriod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_StartingPostPeriod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_StartingPostPeriod.AutoFindItemInDataSource = False
            Me.ComboBoxControl_StartingPostPeriod.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_StartingPostPeriod.BookmarkingEnabled = False
            Me.ComboBoxControl_StartingPostPeriod.DisableMouseWheel = False
            Me.ComboBoxControl_StartingPostPeriod.DisplayMember = "Code"
            Me.ComboBoxControl_StartingPostPeriod.DisplayName = ""
            Me.ComboBoxControl_StartingPostPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_StartingPostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_StartingPostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_StartingPostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_StartingPostPeriod.FocusHighlightEnabled = True
            Me.ComboBoxControl_StartingPostPeriod.FormattingEnabled = True
            Me.ComboBoxControl_StartingPostPeriod.ItemHeight = 16
            Me.ComboBoxControl_StartingPostPeriod.Location = New System.Drawing.Point(326, 26)
            Me.ComboBoxControl_StartingPostPeriod.Name = "ComboBoxControl_StartingPostPeriod"
            Me.ComboBoxControl_StartingPostPeriod.ReadOnly = False
            Me.ComboBoxControl_StartingPostPeriod.SecurityEnabled = True
            Me.ComboBoxControl_StartingPostPeriod.Size = New System.Drawing.Size(162, 22)
            Me.ComboBoxControl_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_StartingPostPeriod.TabIndex = 6
            Me.ComboBoxControl_StartingPostPeriod.TabOnEnter = True
            Me.ComboBoxControl_StartingPostPeriod.ValueMember = "Description"
            '
            'LabelControl_StartingPostPeriod
            '
            Me.LabelControl_StartingPostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_StartingPostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_StartingPostPeriod.Location = New System.Drawing.Point(212, 27)
            Me.LabelControl_StartingPostPeriod.Name = "LabelControl_StartingPostPeriod"
            Me.LabelControl_StartingPostPeriod.Size = New System.Drawing.Size(108, 21)
            Me.LabelControl_StartingPostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_StartingPostPeriod.TabIndex = 5
            Me.LabelControl_StartingPostPeriod.Text = "Start Post Period:"
            '
            'NumericInputControl_TotalNumberPosted
            '
            Me.NumericInputControl_TotalNumberPosted.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_TotalNumberPosted.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.NumericInputControl_TotalNumberPosted.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Integer]
            Me.NumericInputControl_TotalNumberPosted.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_TotalNumberPosted.Enabled = False
            Me.NumericInputControl_TotalNumberPosted.EnterMoveNextControl = True
            Me.NumericInputControl_TotalNumberPosted.Location = New System.Drawing.Point(702, 55)
            Me.NumericInputControl_TotalNumberPosted.Name = "NumericInputControl_TotalNumberPosted"
            Me.NumericInputControl_TotalNumberPosted.Properties.AllowMouseWheel = False
            Me.NumericInputControl_TotalNumberPosted.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_TotalNumberPosted.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_TotalNumberPosted.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputControl_TotalNumberPosted.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_TotalNumberPosted.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputControl_TotalNumberPosted.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_TotalNumberPosted.Properties.IsFloatValue = False
            Me.NumericInputControl_TotalNumberPosted.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_TotalNumberPosted.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_TotalNumberPosted.Properties.MaxValue = New Decimal(New Integer() {2147483647, 0, 0, 0})
            Me.NumericInputControl_TotalNumberPosted.Properties.MinValue = New Decimal(New Integer() {-2147483648, 0, 0, -2147483648})
            Me.NumericInputControl_TotalNumberPosted.SecurityEnabled = True
            Me.NumericInputControl_TotalNumberPosted.Size = New System.Drawing.Size(94, 20)
            Me.NumericInputControl_TotalNumberPosted.TabIndex = 20
            Me.NumericInputControl_TotalNumberPosted.TabStop = False
            '
            'LabelControl_TotalNumberPosted
            '
            Me.LabelControl_TotalNumberPosted.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_TotalNumberPosted.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_TotalNumberPosted.Location = New System.Drawing.Point(585, 54)
            Me.LabelControl_TotalNumberPosted.Name = "LabelControl_TotalNumberPosted"
            Me.LabelControl_TotalNumberPosted.Size = New System.Drawing.Size(111, 21)
            Me.LabelControl_TotalNumberPosted.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_TotalNumberPosted.TabIndex = 19
            Me.LabelControl_TotalNumberPosted.Text = "Total Number Posted:"
            '
            'TextBoxControl_LastPostingPeriod
            '
            Me.TextBoxControl_LastPostingPeriod.AgencyImportPath = Nothing
            Me.TextBoxControl_LastPostingPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_LastPostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_LastPostingPeriod.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_LastPostingPeriod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_LastPostingPeriod.CheckSpellingOnValidate = False
            Me.TextBoxControl_LastPostingPeriod.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_LastPostingPeriod.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_LastPostingPeriod.DisplayName = ""
            Me.TextBoxControl_LastPostingPeriod.Enabled = False
            Me.TextBoxControl_LastPostingPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_LastPostingPeriod.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_LastPostingPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_LastPostingPeriod.FocusHighlightEnabled = True
            Me.TextBoxControl_LastPostingPeriod.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_LastPostingPeriod.Location = New System.Drawing.Point(702, 27)
            Me.TextBoxControl_LastPostingPeriod.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_LastPostingPeriod.Name = "TextBoxControl_LastPostingPeriod"
            Me.TextBoxControl_LastPostingPeriod.SecurityEnabled = True
            Me.TextBoxControl_LastPostingPeriod.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_LastPostingPeriod.Size = New System.Drawing.Size(94, 21)
            Me.TextBoxControl_LastPostingPeriod.StartingFolderName = Nothing
            Me.TextBoxControl_LastPostingPeriod.TabIndex = 18
            Me.TextBoxControl_LastPostingPeriod.TabOnEnter = True
            Me.TextBoxControl_LastPostingPeriod.TabStop = False
            '
            'TextBoxControl_PostedBy
            '
            Me.TextBoxControl_PostedBy.AgencyImportPath = Nothing
            Me.TextBoxControl_PostedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.TextBoxControl_PostedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_PostedBy.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_PostedBy.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_PostedBy.CheckSpellingOnValidate = False
            Me.TextBoxControl_PostedBy.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_PostedBy.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_PostedBy.DisplayName = ""
            Me.TextBoxControl_PostedBy.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_PostedBy.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_PostedBy.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_PostedBy.FocusHighlightEnabled = True
            Me.TextBoxControl_PostedBy.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_PostedBy.Location = New System.Drawing.Point(702, 81)
            Me.TextBoxControl_PostedBy.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_PostedBy.Name = "TextBoxControl_PostedBy"
            Me.TextBoxControl_PostedBy.SecurityEnabled = True
            Me.TextBoxControl_PostedBy.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_PostedBy.Size = New System.Drawing.Size(94, 21)
            Me.TextBoxControl_PostedBy.StartingFolderName = Nothing
            Me.TextBoxControl_PostedBy.TabIndex = 22
            Me.TextBoxControl_PostedBy.TabOnEnter = True
            Me.TextBoxControl_PostedBy.TabStop = False
            '
            'LabelControl_PostedBy
            '
            Me.LabelControl_PostedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_PostedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_PostedBy.Location = New System.Drawing.Point(585, 81)
            Me.LabelControl_PostedBy.Name = "LabelControl_PostedBy"
            Me.LabelControl_PostedBy.Size = New System.Drawing.Size(111, 21)
            Me.LabelControl_PostedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_PostedBy.TabIndex = 21
            Me.LabelControl_PostedBy.Text = "Posted By:"
            '
            'CheckBoxControl_Inactive
            '
            '
            '
            '
            Me.CheckBoxControl_Inactive.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxControl_Inactive.CheckValue = 0
            Me.CheckBoxControl_Inactive.CheckValueChecked = 1
            Me.CheckBoxControl_Inactive.CheckValueType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxControl_Inactive.CheckValueUnchecked = 0
            Me.CheckBoxControl_Inactive.ChildControls = CType(resources.GetObject("CheckBoxControl_Inactive.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxControl_Inactive.Location = New System.Drawing.Point(212, 0)
            Me.CheckBoxControl_Inactive.Name = "CheckBoxControl_Inactive"
            Me.CheckBoxControl_Inactive.OldestSibling = Nothing
            Me.CheckBoxControl_Inactive.SecurityEnabled = True
            Me.CheckBoxControl_Inactive.SiblingControls = CType(resources.GetObject("CheckBoxControl_Inactive.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxControl_Inactive.Size = New System.Drawing.Size(276, 21)
            Me.CheckBoxControl_Inactive.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxControl_Inactive.TabIndex = 2
            Me.CheckBoxControl_Inactive.TabOnEnter = True
            Me.CheckBoxControl_Inactive.Text = "Inactive"
            '
            'ComboBoxControl_Cycle
            '
            Me.ComboBoxControl_Cycle.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxControl_Cycle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxControl_Cycle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxControl_Cycle.AutoFindItemInDataSource = False
            Me.ComboBoxControl_Cycle.AutoSelectSingleItemDatasource = False
            Me.ComboBoxControl_Cycle.BookmarkingEnabled = False
            Me.ComboBoxControl_Cycle.DisableMouseWheel = False
            Me.ComboBoxControl_Cycle.DisplayMember = "Code"
            Me.ComboBoxControl_Cycle.DisplayName = ""
            Me.ComboBoxControl_Cycle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxControl_Cycle.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxControl_Cycle.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxControl_Cycle.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxControl_Cycle.FocusHighlightEnabled = True
            Me.ComboBoxControl_Cycle.FormattingEnabled = True
            Me.ComboBoxControl_Cycle.ItemHeight = 16
            Me.ComboBoxControl_Cycle.Location = New System.Drawing.Point(87, 26)
            Me.ComboBoxControl_Cycle.Name = "ComboBoxControl_Cycle"
            Me.ComboBoxControl_Cycle.ReadOnly = False
            Me.ComboBoxControl_Cycle.SecurityEnabled = True
            Me.ComboBoxControl_Cycle.Size = New System.Drawing.Size(119, 22)
            Me.ComboBoxControl_Cycle.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxControl_Cycle.TabIndex = 4
            Me.ComboBoxControl_Cycle.TabOnEnter = True
            Me.ComboBoxControl_Cycle.ValueMember = "Description"
            '
            'DateTimePickerControl_LastPostingDate
            '
            Me.DateTimePickerControl_LastPostingDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateTimePickerControl_LastPostingDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerControl_LastPostingDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerControl_LastPostingDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastPostingDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerControl_LastPostingDate.ButtonDropDown.Visible = True
            Me.DateTimePickerControl_LastPostingDate.ButtonFreeText.Checked = True
            Me.DateTimePickerControl_LastPostingDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.[Default]
            Me.DateTimePickerControl_LastPostingDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerControl_LastPostingDate.DisplayName = ""
            Me.DateTimePickerControl_LastPostingDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerControl_LastPostingDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerControl_LastPostingDate.FocusHighlightEnabled = True
            Me.DateTimePickerControl_LastPostingDate.FreeTextEntryMode = True
            Me.DateTimePickerControl_LastPostingDate.IsPopupCalendarOpen = False
            Me.DateTimePickerControl_LastPostingDate.Location = New System.Drawing.Point(702, 0)
            Me.DateTimePickerControl_LastPostingDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerControl_LastPostingDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            '
            '
            '
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerControl_LastPostingDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerControl_LastPostingDate.Name = "DateTimePickerControl_LastPostingDate"
            Me.DateTimePickerControl_LastPostingDate.ReadOnly = False
            Me.DateTimePickerControl_LastPostingDate.Size = New System.Drawing.Size(94, 21)
            Me.DateTimePickerControl_LastPostingDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerControl_LastPostingDate.TabIndex = 16
            Me.DateTimePickerControl_LastPostingDate.TabOnEnter = True
            Me.DateTimePickerControl_LastPostingDate.TabStop = False
            Me.DateTimePickerControl_LastPostingDate.Value = New Date(2017, 1, 4, 13, 12, 31, 834)
            '
            'DataGridViewControl_RJEDetails
            '
            Me.DataGridViewControl_RJEDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_RJEDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_RJEDetails.AutoUpdateViewCaption = True
            Me.DataGridViewControl_RJEDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_RJEDetails.ItemDescription = "Detail(s)"
            Me.DataGridViewControl_RJEDetails.Location = New System.Drawing.Point(0, 109)
            Me.DataGridViewControl_RJEDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_RJEDetails.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_RJEDetails.ModifyGridRowHeight = False
            Me.DataGridViewControl_RJEDetails.MultiSelect = True
            Me.DataGridViewControl_RJEDetails.Name = "DataGridViewControl_RJEDetails"
            Me.DataGridViewControl_RJEDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_RJEDetails.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_RJEDetails.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_RJEDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_RJEDetails.Size = New System.Drawing.Size(796, 347)
            Me.DataGridViewControl_RJEDetails.TabIndex = 23
            Me.DataGridViewControl_RJEDetails.UseEmbeddedNavigator = False
            Me.DataGridViewControl_RJEDetails.ViewCaptionHeight = -1
            '
            'RecurringJournalEntryControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "RecurringJournalEntryControl"
            Me.Size = New System.Drawing.Size(796, 458)
            CType(Me.NumericInputControl_ControlNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxControl_Type, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Type.ResumeLayout(False)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.NumericInputControl_NumberOfPostings.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_TotalNumberPosted.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerControl_LastPostingDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GroupBoxControl_Type As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonType_Reversing As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonType_Standard As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxControl_Description As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Description As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_ControlNumber As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_Cycle As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_LastPostingPeriod As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_CreatedBy As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_LastPostingDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputControl_ControlNumber As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents TextBoxControl_CreatedBy As TextBox
        Friend WithEvents PanelControl_Control As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewControl_RJEDetails As DataGridView
        Friend WithEvents DateTimePickerControl_LastPostingDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents ComboBoxControl_Cycle As ComboBox
        Friend WithEvents TextBoxControl_PostedBy As TextBox
        Friend WithEvents LabelControl_PostedBy As Label
        Friend WithEvents CheckBoxControl_Inactive As CheckBox
        Friend WithEvents TextBoxControl_LastPostingPeriod As TextBox
        Friend WithEvents CheckBoxControl_UnlimitedPostings As CheckBox
        Friend WithEvents NumericInputControl_NumberOfPostings As NumericInput
        Friend WithEvents LabelControl_NumberOfPostings As Label
        Friend WithEvents ComboBoxControl_StartingPostPeriod As ComboBox
        Friend WithEvents LabelControl_StartingPostPeriod As Label
        Friend WithEvents NumericInputControl_TotalNumberPosted As NumericInput
        Friend WithEvents LabelControl_TotalNumberPosted As Label
    End Class

End Namespace