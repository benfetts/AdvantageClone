Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class IRS1099ProcessingTransmitDialog
        Inherits AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IRS1099ProcessingTransmitDialog))
        Me.ButtonForm_OK = New AdvantageFramework.WinForm.Presentation.Controls.Button()
        Me.ButtonForm_Cancel = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.LabelForm_PaymentYear = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_TestFile = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_FederalTaxID = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelForm_IRSTCC = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_CombinedFederalStateFiling = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxForm_OutputPath = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_FederalTaxID = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxForm_IRSTCC = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.SearchableComboBoxForm_Employee = New AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox()
            Me.SearchableComboBox1View = New DevExpress.XtraGrid.Views.Grid.GridView()
            Me.CheckBoxForm_LastFiling = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.LabelForm_OutputDirectory = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxForm_IsCorrectionFile = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.NumericInputForm_PaymentYear = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            CType(Me.SearchableComboBoxForm_Employee.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.NumericInputForm_PaymentYear.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'ButtonForm_OK
            '
            Me.ButtonForm_OK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_OK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_OK.Location = New System.Drawing.Point(452, 268)
            Me.ButtonForm_OK.Name = "ButtonForm_OK"
            Me.ButtonForm_OK.SecurityEnabled = True
            Me.ButtonForm_OK.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_OK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_OK.TabIndex = 15
            Me.ButtonForm_OK.Text = "OK"
            '
            'ButtonForm_Cancel
            '
            Me.ButtonForm_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Cancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Cancel.Location = New System.Drawing.Point(533, 268)
            Me.ButtonForm_Cancel.Name = "ButtonForm_Cancel"
            Me.ButtonForm_Cancel.SecurityEnabled = True
            Me.ButtonForm_Cancel.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Cancel.TabIndex = 16
            Me.ButtonForm_Cancel.Text = "Cancel"
            '
            'LabelForm_PaymentYear
            '
            Me.LabelForm_PaymentYear.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_PaymentYear.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_PaymentYear.Location = New System.Drawing.Point(12, 12)
            Me.LabelForm_PaymentYear.Name = "LabelForm_PaymentYear"
            Me.LabelForm_PaymentYear.Size = New System.Drawing.Size(159, 20)
            Me.LabelForm_PaymentYear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_PaymentYear.TabIndex = 0
            Me.LabelForm_PaymentYear.Text = "Payment Year:"
            '
            'CheckBoxForm_TestFile
            '
            '
            '
            '
            Me.CheckBoxForm_TestFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_TestFile.CheckValue = 0
            Me.CheckBoxForm_TestFile.CheckValueChecked = 1
            Me.CheckBoxForm_TestFile.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_TestFile.CheckValueUnchecked = 0
            Me.CheckBoxForm_TestFile.ChildControls = CType(resources.GetObject("CheckBoxForm_TestFile.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TestFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_TestFile.Location = New System.Drawing.Point(12, 203)
            Me.CheckBoxForm_TestFile.Name = "CheckBoxForm_TestFile"
            Me.CheckBoxForm_TestFile.OldestSibling = Nothing
            Me.CheckBoxForm_TestFile.SecurityEnabled = True
            Me.CheckBoxForm_TestFile.SiblingControls = CType(resources.GetObject("CheckBoxForm_TestFile.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_TestFile.Size = New System.Drawing.Size(241, 23)
            Me.CheckBoxForm_TestFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_TestFile.TabIndex = 12
            Me.CheckBoxForm_TestFile.TabOnEnter = True
            Me.CheckBoxForm_TestFile.Text = "Is Test File"
            '
            'LabelForm_FederalTaxID
            '
            Me.LabelForm_FederalTaxID.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_FederalTaxID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_FederalTaxID.Location = New System.Drawing.Point(12, 38)
            Me.LabelForm_FederalTaxID.Name = "LabelForm_FederalTaxID"
            Me.LabelForm_FederalTaxID.Size = New System.Drawing.Size(159, 20)
            Me.LabelForm_FederalTaxID.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_FederalTaxID.TabIndex = 3
            Me.LabelForm_FederalTaxID.Text = "Federal Tax ID:"
            '
            'LabelForm_IRSTCC
            '
            Me.LabelForm_IRSTCC.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_IRSTCC.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_IRSTCC.Location = New System.Drawing.Point(12, 64)
            Me.LabelForm_IRSTCC.Name = "LabelForm_IRSTCC"
            Me.LabelForm_IRSTCC.Size = New System.Drawing.Size(159, 20)
            Me.LabelForm_IRSTCC.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_IRSTCC.TabIndex = 5
            Me.LabelForm_IRSTCC.Text = "IRS Transmitter Control Code:"
            '
            'CheckBoxForm_CombinedFederalStateFiling
            '
            '
            '
            '
            Me.CheckBoxForm_CombinedFederalStateFiling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_CombinedFederalStateFiling.CheckValue = 0
            Me.CheckBoxForm_CombinedFederalStateFiling.CheckValueChecked = 1
            Me.CheckBoxForm_CombinedFederalStateFiling.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_CombinedFederalStateFiling.CheckValueUnchecked = 0
            Me.CheckBoxForm_CombinedFederalStateFiling.ChildControls = CType(resources.GetObject("CheckBoxForm_CombinedFederalStateFiling.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CombinedFederalStateFiling.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_CombinedFederalStateFiling.Location = New System.Drawing.Point(12, 116)
            Me.CheckBoxForm_CombinedFederalStateFiling.Name = "CheckBoxForm_CombinedFederalStateFiling"
            Me.CheckBoxForm_CombinedFederalStateFiling.OldestSibling = Nothing
            Me.CheckBoxForm_CombinedFederalStateFiling.SecurityEnabled = True
            Me.CheckBoxForm_CombinedFederalStateFiling.SiblingControls = CType(resources.GetObject("CheckBoxForm_CombinedFederalStateFiling.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_CombinedFederalStateFiling.Size = New System.Drawing.Size(241, 23)
            Me.CheckBoxForm_CombinedFederalStateFiling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_CombinedFederalStateFiling.TabIndex = 9
            Me.CheckBoxForm_CombinedFederalStateFiling.TabOnEnter = True
            Me.CheckBoxForm_CombinedFederalStateFiling.Text = "Combined Federal/State Filing"
            '
            'LabelForm_Employee
            '
            Me.LabelForm_Employee.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_Employee.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_Employee.Location = New System.Drawing.Point(12, 90)
            Me.LabelForm_Employee.Name = "LabelForm_Employee"
            Me.LabelForm_Employee.Size = New System.Drawing.Size(159, 20)
            Me.LabelForm_Employee.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_Employee.TabIndex = 7
            Me.LabelForm_Employee.Text = "Internal Contact:"
            '
            'TextBoxForm_OutputPath
            '
            '
            '
            '
            Me.TextBoxForm_OutputPath.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_OutputPath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_OutputPath.ButtonCustom.Visible = True
            Me.TextBoxForm_OutputPath.CheckSpellingOnValidate = False
            Me.TextBoxForm_OutputPath.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.Folder
            Me.TextBoxForm_OutputPath.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_OutputPath.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_OutputPath.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_OutputPath.FocusHighlightEnabled = True
            Me.TextBoxForm_OutputPath.Location = New System.Drawing.Point(177, 232)
            Me.TextBoxForm_OutputPath.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_OutputPath.Name = "TextBoxForm_OutputPath"
            Me.TextBoxForm_OutputPath.SecurityEnabled = True
            Me.TextBoxForm_OutputPath.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_OutputPath.Size = New System.Drawing.Size(431, 20)
            Me.TextBoxForm_OutputPath.StartingFolderName = Nothing
            Me.TextBoxForm_OutputPath.TabIndex = 14
            Me.TextBoxForm_OutputPath.TabOnEnter = True
            '
            'TextBoxForm_FederalTaxID
            '
            '
            '
            '
            Me.TextBoxForm_FederalTaxID.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_FederalTaxID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_FederalTaxID.CheckSpellingOnValidate = False
            Me.TextBoxForm_FederalTaxID.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_FederalTaxID.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_FederalTaxID.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_FederalTaxID.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_FederalTaxID.FocusHighlightEnabled = True
            Me.TextBoxForm_FederalTaxID.Location = New System.Drawing.Point(177, 38)
            Me.TextBoxForm_FederalTaxID.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_FederalTaxID.Name = "TextBoxForm_FederalTaxID"
            Me.TextBoxForm_FederalTaxID.SecurityEnabled = True
            Me.TextBoxForm_FederalTaxID.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_FederalTaxID.Size = New System.Drawing.Size(113, 20)
            Me.TextBoxForm_FederalTaxID.StartingFolderName = Nothing
            Me.TextBoxForm_FederalTaxID.TabIndex = 4
            Me.TextBoxForm_FederalTaxID.TabOnEnter = True
            '
            'TextBoxForm_IRSTCC
            '
            '
            '
            '
            Me.TextBoxForm_IRSTCC.Border.Class = "TextBoxBorder"
            Me.TextBoxForm_IRSTCC.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxForm_IRSTCC.CheckSpellingOnValidate = False
            Me.TextBoxForm_IRSTCC.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxForm_IRSTCC.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxForm_IRSTCC.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxForm_IRSTCC.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxForm_IRSTCC.FocusHighlightEnabled = True
            Me.TextBoxForm_IRSTCC.Location = New System.Drawing.Point(177, 64)
            Me.TextBoxForm_IRSTCC.MaxFileSize = CType(0, Long)
            Me.TextBoxForm_IRSTCC.Name = "TextBoxForm_IRSTCC"
            Me.TextBoxForm_IRSTCC.SecurityEnabled = True
            Me.TextBoxForm_IRSTCC.ShowSpellCheckCompleteMessage = True
            Me.TextBoxForm_IRSTCC.Size = New System.Drawing.Size(113, 20)
            Me.TextBoxForm_IRSTCC.StartingFolderName = Nothing
            Me.TextBoxForm_IRSTCC.TabIndex = 6
            Me.TextBoxForm_IRSTCC.TabOnEnter = True
            '
            'SearchableComboBoxForm_Employee
            '
            Me.SearchableComboBoxForm_Employee.ActiveFilterString = ""
            Me.SearchableComboBoxForm_Employee.AddInactiveItemsOnSelectedValue = False
            Me.SearchableComboBoxForm_Employee.AutoFillMode = False
            Me.SearchableComboBoxForm_Employee.BookmarkingEnabled = False
            Me.SearchableComboBoxForm_Employee.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Employee
            Me.SearchableComboBoxForm_Employee.DataSource = Nothing
            Me.SearchableComboBoxForm_Employee.DisableMouseWheel = False
            Me.SearchableComboBoxForm_Employee.DisplayName = ""
            Me.SearchableComboBoxForm_Employee.EnterMoveNextControl = True
            Me.SearchableComboBoxForm_Employee.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.ExtraComboBoxItems.[Nothing]
            Me.SearchableComboBoxForm_Employee.Location = New System.Drawing.Point(177, 90)
            Me.SearchableComboBoxForm_Employee.Name = "SearchableComboBoxForm_Employee"
            Me.SearchableComboBoxForm_Employee.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
            Me.SearchableComboBoxForm_Employee.Properties.DisplayMember = "Name"
            Me.SearchableComboBoxForm_Employee.Properties.NullText = "Select Employee"
            Me.SearchableComboBoxForm_Employee.Properties.PopupView = Me.SearchableComboBox1View
            Me.SearchableComboBoxForm_Employee.Properties.ShowClearButton = False
            Me.SearchableComboBoxForm_Employee.Properties.ValueMember = "Code"
            Me.SearchableComboBoxForm_Employee.SecurityEnabled = True
            Me.SearchableComboBoxForm_Employee.SelectedValue = Nothing
            Me.SearchableComboBoxForm_Employee.Size = New System.Drawing.Size(113, 20)
            Me.SearchableComboBoxForm_Employee.TabIndex = 8
            '
            'SearchableComboBox1View
            '
            Me.SearchableComboBox1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
            Me.SearchableComboBox1View.Name = "SearchableComboBox1View"
            Me.SearchableComboBox1View.OptionsSelection.EnableAppearanceFocusedCell = False
            Me.SearchableComboBox1View.OptionsView.ShowGroupPanel = False
            '
            'CheckBoxForm_LastFiling
            '
            '
            '
            '
            Me.CheckBoxForm_LastFiling.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_LastFiling.CheckValue = 0
            Me.CheckBoxForm_LastFiling.CheckValueChecked = 1
            Me.CheckBoxForm_LastFiling.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_LastFiling.CheckValueUnchecked = 0
            Me.CheckBoxForm_LastFiling.ChildControls = CType(resources.GetObject("CheckBoxForm_LastFiling.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_LastFiling.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_LastFiling.Location = New System.Drawing.Point(12, 145)
            Me.CheckBoxForm_LastFiling.Name = "CheckBoxForm_LastFiling"
            Me.CheckBoxForm_LastFiling.OldestSibling = Nothing
            Me.CheckBoxForm_LastFiling.SecurityEnabled = True
            Me.CheckBoxForm_LastFiling.SiblingControls = CType(resources.GetObject("CheckBoxForm_LastFiling.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_LastFiling.Size = New System.Drawing.Size(241, 23)
            Me.CheckBoxForm_LastFiling.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_LastFiling.TabIndex = 10
            Me.CheckBoxForm_LastFiling.TabOnEnter = True
            Me.CheckBoxForm_LastFiling.Text = "Is Last Filing"
            '
            'LabelForm_OutputDirectory
            '
            Me.LabelForm_OutputDirectory.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelForm_OutputDirectory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelForm_OutputDirectory.Location = New System.Drawing.Point(12, 232)
            Me.LabelForm_OutputDirectory.Name = "LabelForm_OutputDirectory"
            Me.LabelForm_OutputDirectory.Size = New System.Drawing.Size(159, 20)
            Me.LabelForm_OutputDirectory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelForm_OutputDirectory.TabIndex = 13
            Me.LabelForm_OutputDirectory.Text = "Output Directory:"
            '
            'CheckBoxForm_IsCorrectionFile
            '
            '
            '
            '
            Me.CheckBoxForm_IsCorrectionFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_IsCorrectionFile.CheckValue = 0
            Me.CheckBoxForm_IsCorrectionFile.CheckValueChecked = 1
            Me.CheckBoxForm_IsCorrectionFile.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_IsCorrectionFile.CheckValueUnchecked = 0
            Me.CheckBoxForm_IsCorrectionFile.ChildControls = CType(resources.GetObject("CheckBoxForm_IsCorrectionFile.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsCorrectionFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_IsCorrectionFile.Location = New System.Drawing.Point(12, 174)
            Me.CheckBoxForm_IsCorrectionFile.Name = "CheckBoxForm_IsCorrectionFile"
            Me.CheckBoxForm_IsCorrectionFile.OldestSibling = Nothing
            Me.CheckBoxForm_IsCorrectionFile.SecurityEnabled = True
            Me.CheckBoxForm_IsCorrectionFile.SiblingControls = CType(resources.GetObject("CheckBoxForm_IsCorrectionFile.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_IsCorrectionFile.Size = New System.Drawing.Size(241, 23)
            Me.CheckBoxForm_IsCorrectionFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_IsCorrectionFile.TabIndex = 11
            Me.CheckBoxForm_IsCorrectionFile.TabOnEnter = True
            Me.CheckBoxForm_IsCorrectionFile.Text = "Is Correction File"
            '
            'NumericInputForm_PaymentYear
            '
            Me.NumericInputForm_PaymentYear.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputForm_PaymentYear.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Short]
            Me.NumericInputForm_PaymentYear.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputForm_PaymentYear.EnterMoveNextControl = True
            Me.NumericInputForm_PaymentYear.Location = New System.Drawing.Point(177, 12)
            Me.NumericInputForm_PaymentYear.Name = "NumericInputForm_PaymentYear"
            Me.NumericInputForm_PaymentYear.Properties.AllowMouseWheel = False
            Me.NumericInputForm_PaymentYear.Properties.Appearance.BackColor = System.Drawing.SystemColors.Window
            Me.NumericInputForm_PaymentYear.Properties.Appearance.Options.UseBackColor = True
            Me.NumericInputForm_PaymentYear.Properties.DisplayFormat.FormatString = "f0"
            Me.NumericInputForm_PaymentYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_PaymentYear.Properties.EditFormat.FormatString = "f0"
            Me.NumericInputForm_PaymentYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputForm_PaymentYear.Properties.IsFloatValue = False
            Me.NumericInputForm_PaymentYear.Properties.Mask.EditMask = "f0"
            Me.NumericInputForm_PaymentYear.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputForm_PaymentYear.Properties.MaxValue = New Decimal(New Integer() {32767, 0, 0, 0})
            Me.NumericInputForm_PaymentYear.Properties.MinValue = New Decimal(New Integer() {32768, 0, 0, -2147483648})
            Me.NumericInputForm_PaymentYear.SecurityEnabled = True
            Me.NumericInputForm_PaymentYear.Size = New System.Drawing.Size(113, 20)
            Me.NumericInputForm_PaymentYear.TabIndex = 1
            '
            'IRS1099ProcessingTransmitDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(620, 300)
            Me.Controls.Add(Me.NumericInputForm_PaymentYear)
            Me.Controls.Add(Me.CheckBoxForm_IsCorrectionFile)
            Me.Controls.Add(Me.LabelForm_OutputDirectory)
            Me.Controls.Add(Me.CheckBoxForm_LastFiling)
            Me.Controls.Add(Me.SearchableComboBoxForm_Employee)
            Me.Controls.Add(Me.TextBoxForm_IRSTCC)
            Me.Controls.Add(Me.TextBoxForm_FederalTaxID)
            Me.Controls.Add(Me.TextBoxForm_OutputPath)
            Me.Controls.Add(Me.LabelForm_Employee)
            Me.Controls.Add(Me.CheckBoxForm_CombinedFederalStateFiling)
            Me.Controls.Add(Me.LabelForm_IRSTCC)
            Me.Controls.Add(Me.LabelForm_FederalTaxID)
            Me.Controls.Add(Me.CheckBoxForm_TestFile)
            Me.Controls.Add(Me.LabelForm_PaymentYear)
            Me.Controls.Add(Me.ButtonForm_OK)
            Me.Controls.Add(Me.ButtonForm_Cancel)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "IRS1099ProcessingTransmitDialog"
            Me.Text = "IRS 1099 Transmit"
            CType(Me.SearchableComboBoxForm_Employee.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.SearchableComboBox1View, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.NumericInputForm_PaymentYear.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents ButtonForm_OK As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonForm_Cancel As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelForm_PaymentYear As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_TestFile As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_FederalTaxID As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelForm_IRSTCC As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_CombinedFederalStateFiling As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxForm_OutputPath As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_FederalTaxID As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxForm_IRSTCC As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents SearchableComboBoxForm_Employee As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox
        Friend WithEvents SearchableComboBox1View As DevExpress.XtraGrid.Views.Grid.GridView
        Friend WithEvents CheckBoxForm_LastFiling As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelForm_OutputDirectory As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_IsCorrectionFile As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents NumericInputForm_PaymentYear As WinForm.Presentation.Controls.NumericInput
    End Class

End Namespace