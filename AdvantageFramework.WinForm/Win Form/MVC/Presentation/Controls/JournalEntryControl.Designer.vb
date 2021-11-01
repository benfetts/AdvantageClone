Namespace WinForm.MVC.Presentation.Controls

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class JournalEntryControl
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
            Me.TextBoxControl_CreatedBy = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.TextBoxControl_SourceCode = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.GridLookUpEditControl_PostPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.GridLookUpEdit()
            Me.GridLookUpEditViewControl_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.GridView()
            Me.NumericInputControl_Transaction = New AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput()
            Me.LabelControl_PostedToSummary = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_CreatedBy = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_TransactionDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_Source = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_PostPeriod = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.GroupBoxControl_Type = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonType_Reversing = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonType_Standard = New AdvantageFramework.WinForm.MVC.Presentation.Controls.RadioButtonControl()
            Me.TextBoxControl_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox()
            Me.LabelControl_Description = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_Transaction = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.PanelControl_Control = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.DateEditControl_CreateDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DateEditControl_TransactionDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.DateEditControl_PostedDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit()
            Me.LabelControl_CreateDate = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.LabelControl_Voided = New AdvantageFramework.WinForm.MVC.Presentation.Controls.Label()
            Me.DataGridViewControl_JEDetails = New AdvantageFramework.WinForm.MVC.Presentation.Controls.DataGridView()
            CType(Me.GridLookUpEditControl_PostPeriod.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GridLookUpEditViewControl_PostPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputControl_Transaction.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.GroupBoxControl_Type, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxControl_Type.SuspendLayout()
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelControl_Control.SuspendLayout()
            CType(Me.DateEditControl_CreateDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditControl_CreateDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditControl_TransactionDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditControl_TransactionDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditControl_PostedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateEditControl_PostedDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'TextBoxControl_CreatedBy
            '
            Me.TextBoxControl_CreatedBy.AgencyImportPath = Nothing
            Me.TextBoxControl_CreatedBy.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
            Me.TextBoxControl_CreatedBy.Location = New System.Drawing.Point(580, 25)
            Me.TextBoxControl_CreatedBy.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_CreatedBy.Name = "TextBoxControl_CreatedBy"
            Me.TextBoxControl_CreatedBy.SecurityEnabled = True
            Me.TextBoxControl_CreatedBy.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_CreatedBy.Size = New System.Drawing.Size(271, 21)
            Me.TextBoxControl_CreatedBy.StartingFolderName = Nothing
            Me.TextBoxControl_CreatedBy.TabIndex = 16
            Me.TextBoxControl_CreatedBy.TabOnEnter = True
            Me.TextBoxControl_CreatedBy.TabStop = False
            '
            'TextBoxControl_SourceCode
            '
            Me.TextBoxControl_SourceCode.AgencyImportPath = Nothing
            Me.TextBoxControl_SourceCode.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.TextBoxControl_SourceCode.Border.Class = "TextBoxBorder"
            Me.TextBoxControl_SourceCode.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxControl_SourceCode.CheckSpellingOnValidate = False
            Me.TextBoxControl_SourceCode.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxControl_SourceCode.DisabledBackColor = System.Drawing.Color.White
            Me.TextBoxControl_SourceCode.DisplayName = ""
            Me.TextBoxControl_SourceCode.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxControl_SourceCode.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxControl_SourceCode.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxControl_SourceCode.FocusHighlightEnabled = True
            Me.TextBoxControl_SourceCode.ForeColor = System.Drawing.Color.Black
            Me.TextBoxControl_SourceCode.Location = New System.Drawing.Point(295, 25)
            Me.TextBoxControl_SourceCode.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_SourceCode.Name = "TextBoxControl_SourceCode"
            Me.TextBoxControl_SourceCode.SecurityEnabled = True
            Me.TextBoxControl_SourceCode.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_SourceCode.Size = New System.Drawing.Size(46, 21)
            Me.TextBoxControl_SourceCode.StartingFolderName = Nothing
            Me.TextBoxControl_SourceCode.TabIndex = 6
            Me.TextBoxControl_SourceCode.TabOnEnter = True
            Me.TextBoxControl_SourceCode.TabStop = False
            '
            'GridLookUpEditControl_PostPeriod
            '
            Me.GridLookUpEditControl_PostPeriod.ActiveFilterString = ""
            Me.GridLookUpEditControl_PostPeriod.AddInactiveItemsOnSelectedValue = False
            Me.GridLookUpEditControl_PostPeriod.AutoFillMode = False
            Me.GridLookUpEditControl_PostPeriod.BookmarkingEnabled = False
            Me.GridLookUpEditControl_PostPeriod.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SearchableComboBox.Type.PostPeriod
            Me.GridLookUpEditControl_PostPeriod.DataSource = Nothing
            Me.GridLookUpEditControl_PostPeriod.DisableMouseWheel = False
            Me.GridLookUpEditControl_PostPeriod.DisplayName = ""
            Me.GridLookUpEditControl_PostPeriod.EnterMoveNextControl = True
            Me.GridLookUpEditControl_PostPeriod.ExtraComboBoxItem = AdvantageFramework.WinForm.MVC.Presentation.Controls.GridLookUpEdit.ExtraComboBoxItems.[Nothing]
            Me.GridLookUpEditControl_PostPeriod.Location = New System.Drawing.Point(87, 26)
            Me.GridLookUpEditControl_PostPeriod.Name = "GridLookUpEditControl_PostPeriod"
            Me.GridLookUpEditControl_PostPeriod.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.GridLookUpEditControl_PostPeriod.Properties.DisplayMember = "Description"
            Me.GridLookUpEditControl_PostPeriod.Properties.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.GridLookUpEditControl_PostPeriod.Properties.LookAndFeel.UseDefaultLookAndFeel = False
            Me.GridLookUpEditControl_PostPeriod.Properties.NullText = "Select Post Period"
            Me.GridLookUpEditControl_PostPeriod.Properties.PopupView = Me.GridLookUpEditViewControl_PostPeriod
            Me.GridLookUpEditControl_PostPeriod.Properties.ValueMember = "Code"
            Me.GridLookUpEditControl_PostPeriod.SecurityEnabled = True
            Me.GridLookUpEditControl_PostPeriod.SelectedValue = Nothing
            Me.GridLookUpEditControl_PostPeriod.Size = New System.Drawing.Size(144, 20)
            Me.GridLookUpEditControl_PostPeriod.TabIndex = 4
            '
            'GridLookUpEditViewControl_PostPeriod
            '
            Me.GridLookUpEditViewControl_PostPeriod.AFActiveFilterString = ""
            Me.GridLookUpEditViewControl_PostPeriod.AllowExtraItemsInGridLookupEdits = True
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.ColumnFilterButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.ColumnFilterButtonActive.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.CustomizationFormHint.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.DetailTip.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.Empty.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.FilterCloseButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.FixedLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.FocusedCell.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.FocusedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.GroupButton.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.GroupPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.HideSelectionRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.HorzLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.RowSeparator.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.SelectedRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.TopNewRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.VertLine.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.Appearance.ViewCaption.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.EvenRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.FilterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.FooterPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.GroupFooter.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.GroupRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.HeaderPanel.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.Lines.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.OddRow.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.Preview.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AppearancePrint.Row.Font = New System.Drawing.Font("Arial", 8.0!)
            Me.GridLookUpEditViewControl_PostPeriod.AutoFilterLookupColumns = False
            Me.GridLookUpEditViewControl_PostPeriod.AutoloadRepositoryDatasource = True
            Me.GridLookUpEditViewControl_PostPeriod.DataSourceClearing = False
            Me.GridLookUpEditViewControl_PostPeriod.EnableDisabledRows = False
            Me.GridLookUpEditViewControl_PostPeriod.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.GridLookUpEditViewControl_PostPeriod.Name = "GridLookUpEditViewControl_PostPeriod"
            Me.GridLookUpEditViewControl_PostPeriod.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridLookUpEditViewControl_PostPeriod.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.[False]
            Me.GridLookUpEditViewControl_PostPeriod.OptionsBehavior.Editable = False
            Me.GridLookUpEditViewControl_PostPeriod.OptionsCustomization.AllowQuickHideColumns = False
            Me.GridLookUpEditViewControl_PostPeriod.OptionsNavigation.AutoFocusNewRow = True
            Me.GridLookUpEditViewControl_PostPeriod.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.GridLookUpEditViewControl_PostPeriod.OptionsSelection.MultiSelect = True
            Me.GridLookUpEditViewControl_PostPeriod.OptionsView.ColumnAutoWidth = False
            Me.GridLookUpEditViewControl_PostPeriod.OptionsView.ShowGroupPanel = False
            Me.GridLookUpEditViewControl_PostPeriod.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
            Me.GridLookUpEditViewControl_PostPeriod.RestoredLayoutNonVisibleGridColumnList = Nothing
            Me.GridLookUpEditViewControl_PostPeriod.RunStandardValidation = True
            Me.GridLookUpEditViewControl_PostPeriod.SkipAddingControlsOnModifyColumn = False
            Me.GridLookUpEditViewControl_PostPeriod.SkipSettingFontOnModifyColumn = False
            '
            'NumericInputControl_Transaction
            '
            Me.NumericInputControl_Transaction.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputControl_Transaction.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputControl_Transaction.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputControl_Transaction.EnterMoveNextControl = True
            Me.NumericInputControl_Transaction.Location = New System.Drawing.Point(87, 0)
            Me.NumericInputControl_Transaction.Name = "NumericInputControl_Transaction"
            Me.NumericInputControl_Transaction.Properties.AllowMouseWheel = False
            Me.NumericInputControl_Transaction.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputControl_Transaction.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputControl_Transaction.Properties.DisplayFormat.FormatString = "f"
            Me.NumericInputControl_Transaction.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Transaction.Properties.EditFormat.FormatString = "f"
            Me.NumericInputControl_Transaction.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputControl_Transaction.Properties.Mask.EditMask = "f0"
            Me.NumericInputControl_Transaction.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputControl_Transaction.SecurityEnabled = True
            Me.NumericInputControl_Transaction.Size = New System.Drawing.Size(144, 20)
            Me.NumericInputControl_Transaction.TabIndex = 1
            Me.NumericInputControl_Transaction.TabStop = False
            '
            'LabelControl_PostedToSummary
            '
            Me.LabelControl_PostedToSummary.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_PostedToSummary.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_PostedToSummary.Location = New System.Drawing.Point(463, 52)
            Me.LabelControl_PostedToSummary.Name = "LabelControl_PostedToSummary"
            Me.LabelControl_PostedToSummary.Size = New System.Drawing.Size(111, 20)
            Me.LabelControl_PostedToSummary.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_PostedToSummary.TabIndex = 17
            Me.LabelControl_PostedToSummary.Text = "Posted To Summary:"
            '
            'LabelControl_CreatedBy
            '
            Me.LabelControl_CreatedBy.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_CreatedBy.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_CreatedBy.Location = New System.Drawing.Point(463, 25)
            Me.LabelControl_CreatedBy.Name = "LabelControl_CreatedBy"
            Me.LabelControl_CreatedBy.Size = New System.Drawing.Size(111, 20)
            Me.LabelControl_CreatedBy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_CreatedBy.TabIndex = 15
            Me.LabelControl_CreatedBy.Text = "Created By:"
            '
            'LabelControl_TransactionDate
            '
            Me.LabelControl_TransactionDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_TransactionDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_TransactionDate.Location = New System.Drawing.Point(463, 0)
            Me.LabelControl_TransactionDate.Name = "LabelControl_TransactionDate"
            Me.LabelControl_TransactionDate.Size = New System.Drawing.Size(111, 20)
            Me.LabelControl_TransactionDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_TransactionDate.TabIndex = 11
            Me.LabelControl_TransactionDate.Text = "Transaction Date:"
            '
            'LabelControl_Source
            '
            Me.LabelControl_Source.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Source.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Source.Location = New System.Drawing.Point(237, 26)
            Me.LabelControl_Source.Name = "LabelControl_Source"
            Me.LabelControl_Source.Size = New System.Drawing.Size(52, 20)
            Me.LabelControl_Source.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Source.TabIndex = 5
            Me.LabelControl_Source.Text = "Source:"
            '
            'LabelControl_PostPeriod
            '
            Me.LabelControl_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_PostPeriod.Location = New System.Drawing.Point(0, 26)
            Me.LabelControl_PostPeriod.Name = "LabelControl_PostPeriod"
            Me.LabelControl_PostPeriod.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_PostPeriod.TabIndex = 3
            Me.LabelControl_PostPeriod.Text = "Post Period:"
            '
            'GroupBoxControl_Type
            '
            Me.GroupBoxControl_Type.Controls.Add(Me.RadioButtonType_Reversing)
            Me.GroupBoxControl_Type.Controls.Add(Me.RadioButtonType_Standard)
            Me.GroupBoxControl_Type.Location = New System.Drawing.Point(375, 0)
            Me.GroupBoxControl_Type.Name = "GroupBoxControl_Type"
            Me.GroupBoxControl_Type.Size = New System.Drawing.Size(82, 80)
            Me.GroupBoxControl_Type.TabIndex = 10
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
            Me.RadioButtonType_Reversing.Size = New System.Drawing.Size(72, 20)
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
            Me.RadioButtonType_Standard.Size = New System.Drawing.Size(72, 20)
            Me.RadioButtonType_Standard.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonType_Standard.TabIndex = 0
            Me.RadioButtonType_Standard.TabOnEnter = True
            Me.RadioButtonType_Standard.TabStop = False
            Me.RadioButtonType_Standard.Tag = "1"
            Me.RadioButtonType_Standard.Text = "Standard"
            '
            'TextBoxControl_Description
            '
            Me.TextBoxControl_Description.AcceptsReturn = True
            Me.TextBoxControl_Description.AcceptsTab = True
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
            Me.TextBoxControl_Description.Location = New System.Drawing.Point(87, 52)
            Me.TextBoxControl_Description.MaxFileSize = CType(0, Long)
            Me.TextBoxControl_Description.Name = "TextBoxControl_Description"
            Me.TextBoxControl_Description.SecurityEnabled = True
            Me.TextBoxControl_Description.ShowSpellCheckCompleteMessage = True
            Me.TextBoxControl_Description.Size = New System.Drawing.Size(282, 21)
            Me.TextBoxControl_Description.StartingFolderName = Nothing
            Me.TextBoxControl_Description.TabIndex = 8
            Me.TextBoxControl_Description.TabOnEnter = False
            '
            'LabelControl_Description
            '
            Me.LabelControl_Description.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Description.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Description.Location = New System.Drawing.Point(0, 52)
            Me.LabelControl_Description.Name = "LabelControl_Description"
            Me.LabelControl_Description.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Description.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Description.TabIndex = 7
            Me.LabelControl_Description.Text = "Description:"
            '
            'LabelControl_Transaction
            '
            Me.LabelControl_Transaction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Transaction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Transaction.Location = New System.Drawing.Point(0, 0)
            Me.LabelControl_Transaction.Name = "LabelControl_Transaction"
            Me.LabelControl_Transaction.Size = New System.Drawing.Size(81, 20)
            Me.LabelControl_Transaction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Transaction.TabIndex = 0
            Me.LabelControl_Transaction.Text = "Transaction:"
            '
            'PanelControl_Control
            '
            Me.PanelControl_Control.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
            Me.PanelControl_Control.Controls.Add(Me.DateEditControl_CreateDate)
            Me.PanelControl_Control.Controls.Add(Me.DateEditControl_TransactionDate)
            Me.PanelControl_Control.Controls.Add(Me.DateEditControl_PostedDate)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_CreateDate)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Voided)
            Me.PanelControl_Control.Controls.Add(Me.DataGridViewControl_JEDetails)
            Me.PanelControl_Control.Controls.Add(Me.NumericInputControl_Transaction)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Transaction)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Description)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_CreatedBy)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_Description)
            Me.PanelControl_Control.Controls.Add(Me.GroupBoxControl_Type)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_PostPeriod)
            Me.PanelControl_Control.Controls.Add(Me.TextBoxControl_SourceCode)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_Source)
            Me.PanelControl_Control.Controls.Add(Me.GridLookUpEditControl_PostPeriod)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_TransactionDate)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_CreatedBy)
            Me.PanelControl_Control.Controls.Add(Me.LabelControl_PostedToSummary)
            Me.PanelControl_Control.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PanelControl_Control.Location = New System.Drawing.Point(0, 0)
            Me.PanelControl_Control.Margin = New System.Windows.Forms.Padding(2)
            Me.PanelControl_Control.Name = "PanelControl_Control"
            Me.PanelControl_Control.Size = New System.Drawing.Size(851, 525)
            Me.PanelControl_Control.TabIndex = 0
            '
            'DateEditControl_CreateDate
            '
            Me.DateEditControl_CreateDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateEditControl_CreateDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditControl_CreateDate.DisplayName = ""
            Me.DateEditControl_CreateDate.EditValue = New Date(2020, 7, 15, 9, 31, 54, 178)
            Me.DateEditControl_CreateDate.Location = New System.Drawing.Point(756, 0)
            Me.DateEditControl_CreateDate.Name = "DateEditControl_CreateDate"
            Me.DateEditControl_CreateDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditControl_CreateDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditControl_CreateDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditControl_CreateDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditControl_CreateDate.Properties.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.DateEditControl_CreateDate.Properties.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DateEditControl_CreateDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            Me.DateEditControl_CreateDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditControl_CreateDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditControl_CreateDate.SecurityEnabled = True
            Me.DateEditControl_CreateDate.Size = New System.Drawing.Size(95, 20)
            Me.DateEditControl_CreateDate.TabIndex = 14
            Me.DateEditControl_CreateDate.TabOnEnter = True
            Me.DateEditControl_CreateDate.TabStop = False
            '
            'DateEditControl_TransactionDate
            '
            Me.DateEditControl_TransactionDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditControl_TransactionDate.DisplayName = ""
            Me.DateEditControl_TransactionDate.EditValue = New Date(2020, 7, 15, 9, 31, 54, 178)
            Me.DateEditControl_TransactionDate.Location = New System.Drawing.Point(580, 0)
            Me.DateEditControl_TransactionDate.Name = "DateEditControl_TransactionDate"
            Me.DateEditControl_TransactionDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditControl_TransactionDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditControl_TransactionDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditControl_TransactionDate.Properties.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.DateEditControl_TransactionDate.Properties.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DateEditControl_TransactionDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            Me.DateEditControl_TransactionDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditControl_TransactionDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditControl_TransactionDate.SecurityEnabled = True
            Me.DateEditControl_TransactionDate.Size = New System.Drawing.Size(89, 20)
            Me.DateEditControl_TransactionDate.TabIndex = 12
            Me.DateEditControl_TransactionDate.TabOnEnter = True
            '
            'DateEditControl_PostedDate
            '
            Me.DateEditControl_PostedDate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DateEditControl_PostedDate.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.DateEdit.Type.[Default]
            Me.DateEditControl_PostedDate.DisplayName = ""
            Me.DateEditControl_PostedDate.EditValue = Nothing
            Me.DateEditControl_PostedDate.Location = New System.Drawing.Point(580, 52)
            Me.DateEditControl_PostedDate.Name = "DateEditControl_PostedDate"
            Me.DateEditControl_PostedDate.Properties.AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.[False]
            Me.DateEditControl_PostedDate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
            Me.DateEditControl_PostedDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditControl_PostedDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.DateEditControl_PostedDate.Properties.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.DateEditControl_PostedDate.Properties.LookAndFeel.UseDefaultLookAndFeel = False
            Me.DateEditControl_PostedDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret
            Me.DateEditControl_PostedDate.Properties.MaxValue = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateEditControl_PostedDate.Properties.MinValue = New Date(1900, 1, 1, 0, 0, 0, 0)
            Me.DateEditControl_PostedDate.SecurityEnabled = True
            Me.DateEditControl_PostedDate.Size = New System.Drawing.Size(271, 20)
            Me.DateEditControl_PostedDate.TabIndex = 18
            Me.DateEditControl_PostedDate.TabOnEnter = True
            Me.DateEditControl_PostedDate.TabStop = False
            '
            'LabelControl_CreateDate
            '
            Me.LabelControl_CreateDate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_CreateDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_CreateDate.Location = New System.Drawing.Point(675, 0)
            Me.LabelControl_CreateDate.Name = "LabelControl_CreateDate"
            Me.LabelControl_CreateDate.Size = New System.Drawing.Size(75, 20)
            Me.LabelControl_CreateDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_CreateDate.TabIndex = 13
            Me.LabelControl_CreateDate.Text = "Create Date:"
            '
            'LabelControl_Voided
            '
            Me.LabelControl_Voided.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelControl_Voided.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelControl_Voided.Font = New System.Drawing.Font("Tahoma", 8.25!)
            Me.LabelControl_Voided.ForeColor = System.Drawing.Color.Red
            Me.LabelControl_Voided.Location = New System.Drawing.Point(237, 0)
            Me.LabelControl_Voided.Name = "LabelControl_Voided"
            Me.LabelControl_Voided.Size = New System.Drawing.Size(132, 20)
            Me.LabelControl_Voided.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelControl_Voided.TabIndex = 2
            Me.LabelControl_Voided.Text = "VOID"
            Me.LabelControl_Voided.Visible = False
            '
            'DataGridViewControl_JEDetails
            '
            Me.DataGridViewControl_JEDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewControl_JEDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewControl_JEDetails.AutoUpdateViewCaption = True
            Me.DataGridViewControl_JEDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewControl_JEDetails.ItemDescription = "Detail(s)"
            Me.DataGridViewControl_JEDetails.Location = New System.Drawing.Point(0, 87)
            Me.DataGridViewControl_JEDetails.Margin = New System.Windows.Forms.Padding(4)
            Me.DataGridViewControl_JEDetails.ModifyColumnSettingsOnEachDataSource = True
            Me.DataGridViewControl_JEDetails.ModifyGridRowHeight = False
            Me.DataGridViewControl_JEDetails.MultiSelect = True
            Me.DataGridViewControl_JEDetails.Name = "DataGridViewControl_JEDetails"
            Me.DataGridViewControl_JEDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewControl_JEDetails.SelectRowsWhenSelectDeselectAllButtonClicked = True
            Me.DataGridViewControl_JEDetails.ShowRowSelectionIfHidden = True
            Me.DataGridViewControl_JEDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewControl_JEDetails.Size = New System.Drawing.Size(851, 438)
            Me.DataGridViewControl_JEDetails.TabIndex = 9
            Me.DataGridViewControl_JEDetails.UseEmbeddedNavigator = False
            Me.DataGridViewControl_JEDetails.ViewCaptionHeight = -1
            '
            'JournalEntryControl
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.PanelControl_Control)
            Me.Name = "JournalEntryControl"
            Me.Size = New System.Drawing.Size(851, 525)
            CType(Me.GridLookUpEditControl_PostPeriod.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GridLookUpEditViewControl_PostPeriod, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputControl_Transaction.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.GroupBoxControl_Type, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxControl_Type.ResumeLayout(False)
            CType(Me.PanelControl_Control, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelControl_Control.ResumeLayout(False)
            CType(Me.DateEditControl_CreateDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditControl_CreateDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditControl_TransactionDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditControl_TransactionDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditControl_PostedDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateEditControl_PostedDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        Friend WithEvents GroupBoxControl_Type As WinForm.Presentation.Controls.GroupBox
        Friend WithEvents RadioButtonType_Reversing As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonType_Standard As WinForm.MVC.Presentation.Controls.RadioButtonControl
        Friend WithEvents TextBoxControl_Description As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents LabelControl_Description As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_Transaction As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_PostPeriod As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_Source As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_TransactionDate As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_CreatedBy As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents LabelControl_PostedToSummary As WinForm.MVC.Presentation.Controls.Label
        Friend WithEvents NumericInputControl_Transaction As WinForm.MVC.Presentation.Controls.NumericInput
        Friend WithEvents GridLookUpEditControl_PostPeriod As WinForm.MVC.Presentation.Controls.GridLookUpEdit
        Friend WithEvents GridLookUpEditViewControl_PostPeriod As WinForm.Presentation.Controls.GridView
        Friend WithEvents TextBoxControl_SourceCode As WinForm.MVC.Presentation.Controls.TextBox
        Friend WithEvents TextBoxControl_CreatedBy As TextBox
        Friend WithEvents PanelControl_Control As WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewControl_JEDetails As DataGridView
        Friend WithEvents LabelControl_Voided As Label
        Friend WithEvents LabelControl_CreateDate As Label
        Friend WithEvents DateEditControl_CreateDate As DateEdit
        Friend WithEvents DateEditControl_TransactionDate As DateEdit
        Friend WithEvents DateEditControl_PostedDate As DateEdit
    End Class

End Namespace