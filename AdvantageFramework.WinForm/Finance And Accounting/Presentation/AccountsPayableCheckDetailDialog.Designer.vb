Namespace FinanceAndAccounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class AccountsPayableCheckDetailDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AccountsPayableCheckDetailDialog))
            Me.PanelForm_MainSection = New AdvantageFramework.WinForm.Presentation.Controls.Panel()
            Me.GroupBoxPanel_Voided = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.TextBoxVoided_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxVoided_On = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxVoided_By = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelVoided_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelVoided_On = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelVoided_By = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.GroupBoxPanel_Check = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.NumericInputCheck_Amount = New AdvantageFramework.WinForm.Presentation.Controls.NumericInput()
            Me.TextBoxCheck_Date = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelCheck_Amount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheck_Date = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelCheck_Number = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxCheck_Cleared = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxCheck_Number = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_DiscountAccount = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_CashAccount = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPanel_DiscountAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_CashAccount = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.TextBoxPanel_PostPeriod = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_Bank = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_PaidTo = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.TextBoxPanel_GLTransaction = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelPanel_Bank = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_PaidTo = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_PostingPeriod = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelPanel_GLTransaction = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DataGridViewPanel_TransactionDetails = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.ButtonForm_Close = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            CType(Me.PanelForm_MainSection, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.PanelForm_MainSection.SuspendLayout()
            CType(Me.GroupBoxPanel_Voided, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPanel_Voided.SuspendLayout()
            CType(Me.GroupBoxPanel_Check, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxPanel_Check.SuspendLayout()
            CType(Me.NumericInputCheck_Amount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'PanelForm_MainSection
            '
            Me.PanelForm_MainSection.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.PanelForm_MainSection.Controls.Add(Me.GroupBoxPanel_Voided)
            Me.PanelForm_MainSection.Controls.Add(Me.GroupBoxPanel_Check)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_DiscountAccount)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_CashAccount)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_DiscountAccount)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_CashAccount)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_PostPeriod)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_Bank)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_PaidTo)
            Me.PanelForm_MainSection.Controls.Add(Me.TextBoxPanel_GLTransaction)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_Bank)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_PaidTo)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_PostingPeriod)
            Me.PanelForm_MainSection.Controls.Add(Me.LabelPanel_GLTransaction)
            Me.PanelForm_MainSection.Controls.Add(Me.DataGridViewPanel_TransactionDetails)
            Me.PanelForm_MainSection.Location = New System.Drawing.Point(12, 12)
            Me.PanelForm_MainSection.Name = "PanelForm_MainSection"
            Me.PanelForm_MainSection.Size = New System.Drawing.Size(852, 626)
            Me.PanelForm_MainSection.TabIndex = 0
            '
            'GroupBoxPanel_Voided
            '
            Me.GroupBoxPanel_Voided.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxPanel_Voided.Controls.Add(Me.TextBoxVoided_PostPeriod)
            Me.GroupBoxPanel_Voided.Controls.Add(Me.TextBoxVoided_On)
            Me.GroupBoxPanel_Voided.Controls.Add(Me.TextBoxVoided_By)
            Me.GroupBoxPanel_Voided.Controls.Add(Me.LabelVoided_PostPeriod)
            Me.GroupBoxPanel_Voided.Controls.Add(Me.LabelVoided_On)
            Me.GroupBoxPanel_Voided.Controls.Add(Me.LabelVoided_By)
            Me.GroupBoxPanel_Voided.Location = New System.Drawing.Point(630, 5)
            Me.GroupBoxPanel_Voided.Name = "GroupBoxPanel_Voided"
            Me.GroupBoxPanel_Voided.Size = New System.Drawing.Size(217, 124)
            Me.GroupBoxPanel_Voided.TabIndex = 13
            Me.GroupBoxPanel_Voided.Text = "Voided"
            '
            'TextBoxVoided_PostPeriod
            '
            '
            '
            '
            Me.TextBoxVoided_PostPeriod.Border.Class = "TextBoxBorder"
            Me.TextBoxVoided_PostPeriod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxVoided_PostPeriod.CheckSpellingOnValidate = False
            Me.TextBoxVoided_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxVoided_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxVoided_PostPeriod.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxVoided_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxVoided_PostPeriod.FocusHighlightEnabled = True
            Me.TextBoxVoided_PostPeriod.Location = New System.Drawing.Point(102, 76)
            Me.TextBoxVoided_PostPeriod.MaxFileSize = CType(0, Long)
            Me.TextBoxVoided_PostPeriod.Name = "TextBoxVoided_PostPeriod"
            Me.TextBoxVoided_PostPeriod.ReadOnly = True
            Me.TextBoxVoided_PostPeriod.SecurityEnabled = True
            Me.TextBoxVoided_PostPeriod.ShowSpellCheckCompleteMessage = True
            Me.TextBoxVoided_PostPeriod.Size = New System.Drawing.Size(110, 21)
            Me.TextBoxVoided_PostPeriod.StartingFolderName = Nothing
            Me.TextBoxVoided_PostPeriod.TabIndex = 5
            Me.TextBoxVoided_PostPeriod.TabOnEnter = True
            Me.TextBoxVoided_PostPeriod.TabStop = False
            '
            'TextBoxVoided_On
            '
            '
            '
            '
            Me.TextBoxVoided_On.Border.Class = "TextBoxBorder"
            Me.TextBoxVoided_On.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxVoided_On.CheckSpellingOnValidate = False
            Me.TextBoxVoided_On.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxVoided_On.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxVoided_On.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxVoided_On.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxVoided_On.FocusHighlightEnabled = True
            Me.TextBoxVoided_On.Location = New System.Drawing.Point(102, 50)
            Me.TextBoxVoided_On.MaxFileSize = CType(0, Long)
            Me.TextBoxVoided_On.Name = "TextBoxVoided_On"
            Me.TextBoxVoided_On.ReadOnly = True
            Me.TextBoxVoided_On.SecurityEnabled = True
            Me.TextBoxVoided_On.ShowSpellCheckCompleteMessage = True
            Me.TextBoxVoided_On.Size = New System.Drawing.Size(110, 21)
            Me.TextBoxVoided_On.StartingFolderName = Nothing
            Me.TextBoxVoided_On.TabIndex = 3
            Me.TextBoxVoided_On.TabOnEnter = True
            Me.TextBoxVoided_On.TabStop = False
            '
            'TextBoxVoided_By
            '
            '
            '
            '
            Me.TextBoxVoided_By.Border.Class = "TextBoxBorder"
            Me.TextBoxVoided_By.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxVoided_By.CheckSpellingOnValidate = False
            Me.TextBoxVoided_By.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxVoided_By.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxVoided_By.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxVoided_By.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxVoided_By.FocusHighlightEnabled = True
            Me.TextBoxVoided_By.Location = New System.Drawing.Point(102, 24)
            Me.TextBoxVoided_By.MaxFileSize = CType(0, Long)
            Me.TextBoxVoided_By.Name = "TextBoxVoided_By"
            Me.TextBoxVoided_By.ReadOnly = True
            Me.TextBoxVoided_By.SecurityEnabled = True
            Me.TextBoxVoided_By.ShowSpellCheckCompleteMessage = True
            Me.TextBoxVoided_By.Size = New System.Drawing.Size(110, 21)
            Me.TextBoxVoided_By.StartingFolderName = Nothing
            Me.TextBoxVoided_By.TabIndex = 1
            Me.TextBoxVoided_By.TabOnEnter = True
            Me.TextBoxVoided_By.TabStop = False
            '
            'LabelVoided_PostPeriod
            '
            Me.LabelVoided_PostPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVoided_PostPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVoided_PostPeriod.Location = New System.Drawing.Point(5, 76)
            Me.LabelVoided_PostPeriod.Name = "LabelVoided_PostPeriod"
            Me.LabelVoided_PostPeriod.Size = New System.Drawing.Size(91, 20)
            Me.LabelVoided_PostPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVoided_PostPeriod.TabIndex = 4
            Me.LabelVoided_PostPeriod.Text = "Post Period:"
            '
            'LabelVoided_On
            '
            Me.LabelVoided_On.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVoided_On.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVoided_On.Location = New System.Drawing.Point(5, 50)
            Me.LabelVoided_On.Name = "LabelVoided_On"
            Me.LabelVoided_On.Size = New System.Drawing.Size(91, 20)
            Me.LabelVoided_On.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVoided_On.TabIndex = 2
            Me.LabelVoided_On.Text = "On:"
            '
            'LabelVoided_By
            '
            Me.LabelVoided_By.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelVoided_By.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelVoided_By.Location = New System.Drawing.Point(5, 24)
            Me.LabelVoided_By.Name = "LabelVoided_By"
            Me.LabelVoided_By.Size = New System.Drawing.Size(91, 20)
            Me.LabelVoided_By.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelVoided_By.TabIndex = 0
            Me.LabelVoided_By.Text = "By:"
            '
            'GroupBoxPanel_Check
            '
            Me.GroupBoxPanel_Check.Controls.Add(Me.NumericInputCheck_Amount)
            Me.GroupBoxPanel_Check.Controls.Add(Me.TextBoxCheck_Date)
            Me.GroupBoxPanel_Check.Controls.Add(Me.LabelCheck_Amount)
            Me.GroupBoxPanel_Check.Controls.Add(Me.LabelCheck_Date)
            Me.GroupBoxPanel_Check.Controls.Add(Me.LabelCheck_Number)
            Me.GroupBoxPanel_Check.Controls.Add(Me.CheckBoxCheck_Cleared)
            Me.GroupBoxPanel_Check.Controls.Add(Me.TextBoxCheck_Number)
            Me.GroupBoxPanel_Check.Location = New System.Drawing.Point(435, 5)
            Me.GroupBoxPanel_Check.Name = "GroupBoxPanel_Check"
            Me.GroupBoxPanel_Check.Size = New System.Drawing.Size(190, 124)
            Me.GroupBoxPanel_Check.TabIndex = 12
            Me.GroupBoxPanel_Check.Text = "Check"
            '
            'NumericInputCheck_Amount
            '
            Me.NumericInputCheck_Amount.AllowKeyUpAndDownToIncrementValue = False
            Me.NumericInputCheck_Amount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.NumericInput.Type.[Decimal]
            Me.NumericInputCheck_Amount.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
            Me.NumericInputCheck_Amount.EnterMoveNextControl = True
            Me.NumericInputCheck_Amount.Location = New System.Drawing.Point(75, 76)
            Me.NumericInputCheck_Amount.Name = "NumericInputCheck_Amount"
            Me.NumericInputCheck_Amount.Properties.DisplayFormat.FormatString = "c2"
            Me.NumericInputCheck_Amount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCheck_Amount.Properties.EditFormat.FormatString = "c2"
            Me.NumericInputCheck_Amount.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
            Me.NumericInputCheck_Amount.Properties.Mask.EditMask = "f"
            Me.NumericInputCheck_Amount.Properties.Mask.UseMaskAsDisplayFormat = True
            Me.NumericInputCheck_Amount.SecurityEnabled = True
            Me.NumericInputCheck_Amount.Size = New System.Drawing.Size(110, 20)
            Me.NumericInputCheck_Amount.TabIndex = 5
            '
            'TextBoxCheck_Date
            '
            '
            '
            '
            Me.TextBoxCheck_Date.Border.Class = "TextBoxBorder"
            Me.TextBoxCheck_Date.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCheck_Date.CheckSpellingOnValidate = False
            Me.TextBoxCheck_Date.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCheck_Date.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCheck_Date.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCheck_Date.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCheck_Date.FocusHighlightEnabled = True
            Me.TextBoxCheck_Date.Location = New System.Drawing.Point(75, 50)
            Me.TextBoxCheck_Date.MaxFileSize = CType(0, Long)
            Me.TextBoxCheck_Date.Name = "TextBoxCheck_Date"
            Me.TextBoxCheck_Date.ReadOnly = True
            Me.TextBoxCheck_Date.SecurityEnabled = True
            Me.TextBoxCheck_Date.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCheck_Date.Size = New System.Drawing.Size(110, 21)
            Me.TextBoxCheck_Date.StartingFolderName = Nothing
            Me.TextBoxCheck_Date.TabIndex = 3
            Me.TextBoxCheck_Date.TabOnEnter = True
            Me.TextBoxCheck_Date.TabStop = False
            '
            'LabelCheck_Amount
            '
            Me.LabelCheck_Amount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheck_Amount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheck_Amount.Location = New System.Drawing.Point(5, 76)
            Me.LabelCheck_Amount.Name = "LabelCheck_Amount"
            Me.LabelCheck_Amount.Size = New System.Drawing.Size(64, 20)
            Me.LabelCheck_Amount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheck_Amount.TabIndex = 4
            Me.LabelCheck_Amount.Text = "Amount:"
            '
            'LabelCheck_Date
            '
            Me.LabelCheck_Date.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheck_Date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheck_Date.Location = New System.Drawing.Point(5, 50)
            Me.LabelCheck_Date.Name = "LabelCheck_Date"
            Me.LabelCheck_Date.Size = New System.Drawing.Size(64, 20)
            Me.LabelCheck_Date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheck_Date.TabIndex = 2
            Me.LabelCheck_Date.Text = "Date:"
            '
            'LabelCheck_Number
            '
            Me.LabelCheck_Number.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCheck_Number.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCheck_Number.Location = New System.Drawing.Point(5, 24)
            Me.LabelCheck_Number.Name = "LabelCheck_Number"
            Me.LabelCheck_Number.Size = New System.Drawing.Size(64, 20)
            Me.LabelCheck_Number.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCheck_Number.TabIndex = 0
            Me.LabelCheck_Number.Text = "Number:"
            '
            'CheckBoxCheck_Cleared
            '
            '
            '
            '
            Me.CheckBoxCheck_Cleared.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxCheck_Cleared.CheckValue = 0
            Me.CheckBoxCheck_Cleared.CheckValueChecked = 1
            Me.CheckBoxCheck_Cleared.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxCheck_Cleared.CheckValueUnchecked = 0
            Me.CheckBoxCheck_Cleared.ChildControls = Nothing
            Me.CheckBoxCheck_Cleared.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxCheck_Cleared.Enabled = False
            Me.CheckBoxCheck_Cleared.Location = New System.Drawing.Point(5, 102)
            Me.CheckBoxCheck_Cleared.Name = "CheckBoxCheck_Cleared"
            Me.CheckBoxCheck_Cleared.OldestSibling = Nothing
            Me.CheckBoxCheck_Cleared.SecurityEnabled = True
            Me.CheckBoxCheck_Cleared.SiblingControls = Nothing
            Me.CheckBoxCheck_Cleared.Size = New System.Drawing.Size(64, 20)
            Me.CheckBoxCheck_Cleared.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxCheck_Cleared.TabIndex = 6
            Me.CheckBoxCheck_Cleared.TabOnEnter = True
            Me.CheckBoxCheck_Cleared.Text = "Cleared"
            '
            'TextBoxCheck_Number
            '
            '
            '
            '
            Me.TextBoxCheck_Number.Border.Class = "TextBoxBorder"
            Me.TextBoxCheck_Number.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCheck_Number.CheckSpellingOnValidate = False
            Me.TextBoxCheck_Number.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCheck_Number.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCheck_Number.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCheck_Number.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCheck_Number.FocusHighlightEnabled = True
            Me.TextBoxCheck_Number.Location = New System.Drawing.Point(75, 24)
            Me.TextBoxCheck_Number.MaxFileSize = CType(0, Long)
            Me.TextBoxCheck_Number.Name = "TextBoxCheck_Number"
            Me.TextBoxCheck_Number.ReadOnly = True
            Me.TextBoxCheck_Number.SecurityEnabled = True
            Me.TextBoxCheck_Number.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCheck_Number.Size = New System.Drawing.Size(110, 21)
            Me.TextBoxCheck_Number.StartingFolderName = Nothing
            Me.TextBoxCheck_Number.TabIndex = 1
            Me.TextBoxCheck_Number.TabOnEnter = True
            Me.TextBoxCheck_Number.TabStop = False
            '
            'TextBoxPanel_DiscountAccount
            '
            '
            '
            '
            Me.TextBoxPanel_DiscountAccount.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_DiscountAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_DiscountAccount.CheckSpellingOnValidate = False
            Me.TextBoxPanel_DiscountAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_DiscountAccount.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_DiscountAccount.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_DiscountAccount.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_DiscountAccount.FocusHighlightEnabled = True
            Me.TextBoxPanel_DiscountAccount.Location = New System.Drawing.Point(110, 107)
            Me.TextBoxPanel_DiscountAccount.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_DiscountAccount.Name = "TextBoxPanel_DiscountAccount"
            Me.TextBoxPanel_DiscountAccount.ReadOnly = True
            Me.TextBoxPanel_DiscountAccount.SecurityEnabled = True
            Me.TextBoxPanel_DiscountAccount.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_DiscountAccount.Size = New System.Drawing.Size(319, 21)
            Me.TextBoxPanel_DiscountAccount.StartingFolderName = Nothing
            Me.TextBoxPanel_DiscountAccount.TabIndex = 11
            Me.TextBoxPanel_DiscountAccount.TabOnEnter = True
            Me.TextBoxPanel_DiscountAccount.TabStop = False
            '
            'TextBoxPanel_CashAccount
            '
            '
            '
            '
            Me.TextBoxPanel_CashAccount.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_CashAccount.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_CashAccount.CheckSpellingOnValidate = False
            Me.TextBoxPanel_CashAccount.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_CashAccount.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_CashAccount.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_CashAccount.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_CashAccount.FocusHighlightEnabled = True
            Me.TextBoxPanel_CashAccount.Location = New System.Drawing.Point(110, 81)
            Me.TextBoxPanel_CashAccount.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_CashAccount.Name = "TextBoxPanel_CashAccount"
            Me.TextBoxPanel_CashAccount.ReadOnly = True
            Me.TextBoxPanel_CashAccount.SecurityEnabled = True
            Me.TextBoxPanel_CashAccount.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_CashAccount.Size = New System.Drawing.Size(319, 21)
            Me.TextBoxPanel_CashAccount.StartingFolderName = Nothing
            Me.TextBoxPanel_CashAccount.TabIndex = 9
            Me.TextBoxPanel_CashAccount.TabOnEnter = True
            Me.TextBoxPanel_CashAccount.TabStop = False
            '
            'LabelPanel_DiscountAccount
            '
            Me.LabelPanel_DiscountAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_DiscountAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_DiscountAccount.Location = New System.Drawing.Point(5, 109)
            Me.LabelPanel_DiscountAccount.Name = "LabelPanel_DiscountAccount"
            Me.LabelPanel_DiscountAccount.Size = New System.Drawing.Size(99, 20)
            Me.LabelPanel_DiscountAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_DiscountAccount.TabIndex = 10
            Me.LabelPanel_DiscountAccount.Text = "Discount Account:"
            '
            'LabelPanel_CashAccount
            '
            Me.LabelPanel_CashAccount.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_CashAccount.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_CashAccount.Location = New System.Drawing.Point(5, 83)
            Me.LabelPanel_CashAccount.Name = "LabelPanel_CashAccount"
            Me.LabelPanel_CashAccount.Size = New System.Drawing.Size(99, 20)
            Me.LabelPanel_CashAccount.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_CashAccount.TabIndex = 8
            Me.LabelPanel_CashAccount.Text = "Cash Account:"
            '
            'TextBoxPanel_PostPeriod
            '
            '
            '
            '
            Me.TextBoxPanel_PostPeriod.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_PostPeriod.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_PostPeriod.CheckSpellingOnValidate = False
            Me.TextBoxPanel_PostPeriod.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_PostPeriod.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_PostPeriod.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_PostPeriod.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_PostPeriod.FocusHighlightEnabled = True
            Me.TextBoxPanel_PostPeriod.Location = New System.Drawing.Point(319, 5)
            Me.TextBoxPanel_PostPeriod.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_PostPeriod.Name = "TextBoxPanel_PostPeriod"
            Me.TextBoxPanel_PostPeriod.ReadOnly = True
            Me.TextBoxPanel_PostPeriod.SecurityEnabled = True
            Me.TextBoxPanel_PostPeriod.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_PostPeriod.Size = New System.Drawing.Size(110, 21)
            Me.TextBoxPanel_PostPeriod.StartingFolderName = Nothing
            Me.TextBoxPanel_PostPeriod.TabIndex = 3
            Me.TextBoxPanel_PostPeriod.TabOnEnter = True
            Me.TextBoxPanel_PostPeriod.TabStop = False
            '
            'TextBoxPanel_Bank
            '
            '
            '
            '
            Me.TextBoxPanel_Bank.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_Bank.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_Bank.CheckSpellingOnValidate = False
            Me.TextBoxPanel_Bank.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_Bank.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_Bank.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_Bank.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_Bank.FocusHighlightEnabled = True
            Me.TextBoxPanel_Bank.Location = New System.Drawing.Point(110, 57)
            Me.TextBoxPanel_Bank.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_Bank.Name = "TextBoxPanel_Bank"
            Me.TextBoxPanel_Bank.ReadOnly = True
            Me.TextBoxPanel_Bank.SecurityEnabled = True
            Me.TextBoxPanel_Bank.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_Bank.Size = New System.Drawing.Size(319, 21)
            Me.TextBoxPanel_Bank.StartingFolderName = Nothing
            Me.TextBoxPanel_Bank.TabIndex = 7
            Me.TextBoxPanel_Bank.TabOnEnter = True
            Me.TextBoxPanel_Bank.TabStop = False
            '
            'TextBoxPanel_PaidTo
            '
            '
            '
            '
            Me.TextBoxPanel_PaidTo.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_PaidTo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_PaidTo.CheckSpellingOnValidate = False
            Me.TextBoxPanel_PaidTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_PaidTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_PaidTo.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_PaidTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_PaidTo.FocusHighlightEnabled = True
            Me.TextBoxPanel_PaidTo.Location = New System.Drawing.Point(110, 31)
            Me.TextBoxPanel_PaidTo.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_PaidTo.Name = "TextBoxPanel_PaidTo"
            Me.TextBoxPanel_PaidTo.ReadOnly = True
            Me.TextBoxPanel_PaidTo.SecurityEnabled = True
            Me.TextBoxPanel_PaidTo.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_PaidTo.Size = New System.Drawing.Size(319, 21)
            Me.TextBoxPanel_PaidTo.StartingFolderName = Nothing
            Me.TextBoxPanel_PaidTo.TabIndex = 5
            Me.TextBoxPanel_PaidTo.TabOnEnter = True
            Me.TextBoxPanel_PaidTo.TabStop = False
            '
            'TextBoxPanel_GLTransaction
            '
            '
            '
            '
            Me.TextBoxPanel_GLTransaction.Border.Class = "TextBoxBorder"
            Me.TextBoxPanel_GLTransaction.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxPanel_GLTransaction.CheckSpellingOnValidate = False
            Me.TextBoxPanel_GLTransaction.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxPanel_GLTransaction.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxPanel_GLTransaction.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxPanel_GLTransaction.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxPanel_GLTransaction.FocusHighlightEnabled = True
            Me.TextBoxPanel_GLTransaction.Location = New System.Drawing.Point(110, 5)
            Me.TextBoxPanel_GLTransaction.MaxFileSize = CType(0, Long)
            Me.TextBoxPanel_GLTransaction.Name = "TextBoxPanel_GLTransaction"
            Me.TextBoxPanel_GLTransaction.ReadOnly = True
            Me.TextBoxPanel_GLTransaction.SecurityEnabled = True
            Me.TextBoxPanel_GLTransaction.ShowSpellCheckCompleteMessage = True
            Me.TextBoxPanel_GLTransaction.Size = New System.Drawing.Size(110, 21)
            Me.TextBoxPanel_GLTransaction.StartingFolderName = Nothing
            Me.TextBoxPanel_GLTransaction.TabIndex = 1
            Me.TextBoxPanel_GLTransaction.TabOnEnter = True
            Me.TextBoxPanel_GLTransaction.TabStop = False
            '
            'LabelPanel_Bank
            '
            Me.LabelPanel_Bank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_Bank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_Bank.Location = New System.Drawing.Point(5, 57)
            Me.LabelPanel_Bank.Name = "LabelPanel_Bank"
            Me.LabelPanel_Bank.Size = New System.Drawing.Size(99, 20)
            Me.LabelPanel_Bank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_Bank.TabIndex = 6
            Me.LabelPanel_Bank.Text = "Bank:"
            '
            'LabelPanel_PaidTo
            '
            Me.LabelPanel_PaidTo.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_PaidTo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_PaidTo.Location = New System.Drawing.Point(5, 31)
            Me.LabelPanel_PaidTo.Name = "LabelPanel_PaidTo"
            Me.LabelPanel_PaidTo.Size = New System.Drawing.Size(99, 20)
            Me.LabelPanel_PaidTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_PaidTo.TabIndex = 4
            Me.LabelPanel_PaidTo.Text = "Paid To:"
            '
            'LabelPanel_PostingPeriod
            '
            Me.LabelPanel_PostingPeriod.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_PostingPeriod.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_PostingPeriod.Location = New System.Drawing.Point(226, 5)
            Me.LabelPanel_PostingPeriod.Name = "LabelPanel_PostingPeriod"
            Me.LabelPanel_PostingPeriod.Size = New System.Drawing.Size(87, 20)
            Me.LabelPanel_PostingPeriod.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_PostingPeriod.TabIndex = 2
            Me.LabelPanel_PostingPeriod.Text = "Posting Period:"
            '
            'LabelPanel_GLTransaction
            '
            Me.LabelPanel_GLTransaction.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelPanel_GLTransaction.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelPanel_GLTransaction.Location = New System.Drawing.Point(5, 5)
            Me.LabelPanel_GLTransaction.Name = "LabelPanel_GLTransaction"
            Me.LabelPanel_GLTransaction.Size = New System.Drawing.Size(99, 20)
            Me.LabelPanel_GLTransaction.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelPanel_GLTransaction.TabIndex = 0
            Me.LabelPanel_GLTransaction.Text = "GL Transaction:"
            '
            'DataGridViewPanel_TransactionDetails
            '
            Me.DataGridViewPanel_TransactionDetails.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewPanel_TransactionDetails.AllowDragAndDrop = False
            Me.DataGridViewPanel_TransactionDetails.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewPanel_TransactionDetails.AllowSelectGroupHeaderRow = True
            Me.DataGridViewPanel_TransactionDetails.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewPanel_TransactionDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewPanel_TransactionDetails.AutoFilterLookupColumns = False
            Me.DataGridViewPanel_TransactionDetails.AutoloadRepositoryDatasource = True
            Me.DataGridViewPanel_TransactionDetails.AutoUpdateViewCaption = True
            Me.DataGridViewPanel_TransactionDetails.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewPanel_TransactionDetails.DataSource = Nothing
            Me.DataGridViewPanel_TransactionDetails.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewPanel_TransactionDetails.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewPanel_TransactionDetails.ItemDescription = "Transaction Detail"
            Me.DataGridViewPanel_TransactionDetails.Location = New System.Drawing.Point(5, 135)
            Me.DataGridViewPanel_TransactionDetails.MultiSelect = False
            Me.DataGridViewPanel_TransactionDetails.Name = "DataGridViewPanel_TransactionDetails"
            Me.DataGridViewPanel_TransactionDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewPanel_TransactionDetails.RunStandardValidation = True
            Me.DataGridViewPanel_TransactionDetails.ShowColumnMenuOnRightClick = False
            Me.DataGridViewPanel_TransactionDetails.ShowSelectDeselectAllButtons = False
            Me.DataGridViewPanel_TransactionDetails.Size = New System.Drawing.Size(842, 486)
            Me.DataGridViewPanel_TransactionDetails.TabIndex = 14
            Me.DataGridViewPanel_TransactionDetails.UseEmbeddedNavigator = False
            Me.DataGridViewPanel_TransactionDetails.ViewCaptionHeight = -1
            '
            'ButtonForm_Close
            '
            Me.ButtonForm_Close.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonForm_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonForm_Close.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonForm_Close.Location = New System.Drawing.Point(789, 644)
            Me.ButtonForm_Close.Name = "ButtonForm_Close"
            Me.ButtonForm_Close.SecurityEnabled = True
            Me.ButtonForm_Close.Size = New System.Drawing.Size(75, 20)
            Me.ButtonForm_Close.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonForm_Close.TabIndex = 1
            Me.ButtonForm_Close.Text = "Close"
            '
            'AccountsPayableCheckDetailDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(876, 676)
            Me.Controls.Add(Me.ButtonForm_Close)
            Me.Controls.Add(Me.PanelForm_MainSection)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "AccountsPayableCheckDetailDialog"
            Me.Text = "Query Transaction - Check Detail"
            CType(Me.PanelForm_MainSection, System.ComponentModel.ISupportInitialize).EndInit()
            Me.PanelForm_MainSection.ResumeLayout(False)
            CType(Me.GroupBoxPanel_Voided, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPanel_Voided.ResumeLayout(False)
            CType(Me.GroupBoxPanel_Check, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxPanel_Check.ResumeLayout(False)
            CType(Me.NumericInputCheck_Amount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents PanelForm_MainSection As AdvantageFramework.WinForm.Presentation.Controls.Panel
        Friend WithEvents DataGridViewPanel_TransactionDetails As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents LabelVoided_By As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_Bank As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_PaidTo As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_PostingPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_GLTransaction As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxCheck_Cleared As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents LabelCheck_Number As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPanel_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxCheck_Number As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_Bank As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_PaidTo As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_GLTransaction As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents ButtonForm_Close As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents LabelPanel_DiscountAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelPanel_CashAccount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxPanel_DiscountAccount As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxPanel_CashAccount As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents GroupBoxPanel_Voided As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxPanel_Check As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents LabelCheck_Amount As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelCheck_Date As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents TextBoxCheck_Date As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxVoided_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxVoided_On As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents TextBoxVoided_By As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents LabelVoided_PostPeriod As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelVoided_On As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents NumericInputCheck_Amount As AdvantageFramework.WinForm.Presentation.Controls.NumericInput
    End Class

End Namespace

