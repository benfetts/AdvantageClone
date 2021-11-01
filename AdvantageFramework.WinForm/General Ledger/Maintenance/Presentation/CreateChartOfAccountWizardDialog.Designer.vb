Namespace GeneralLedger.Maintenance.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class CreateChartOfAccountWizardDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CreateChartOfAccountWizardDialog))
            Me.CompletionWizardPageForm_CompletionPage = New DevExpress.XtraWizard.CompletionWizardPage()
            Me.WelcomeWizardPageForm_WelcomePage = New DevExpress.XtraWizard.WelcomeWizardPage()
            Me.WizardControlForm_Wizard = New DevExpress.XtraWizard.WizardControl()
            Me.WizardPageWizard_SelectAccountTypesPage = New DevExpress.XtraWizard.WizardPage()
            Me.ButtonSelectAccountTypes_DeselectAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.GroupBoxSelectAccountTypes_Include = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_ExpenseOther = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_ExpenseOperating = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_ExpenseCOS = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_OtherIncome = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_Income = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_Equity = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_FixedAssets = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.CheckBoxSelectAccountTypes_CurrentAssets = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ButtonSelectAccountTypes_SelectAll = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.WizardPageWizard_SelectSourcePage = New DevExpress.XtraWizard.WizardPage()
            Me.GroupBoxSelectSource_CreateNewAccounts = New AdvantageFramework.WinForm.Presentation.Controls.GroupBox()
            Me.RadioButtonSelectSource_UsingTemplate = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.RadioButtonSelectSource_FromExistingBaseRange = New AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl()
            Me.WizardPageWizard_FinalizeChartOfAccountCreationPage = New DevExpress.XtraWizard.WizardPage()
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardPageWizard_SelectTemplatePage = New DevExpress.XtraWizard.WizardPage()
            Me.ComboBoxSelectTemplate_Template = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelSelectTemplate_Template = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.WizardPageWizard_SelectOfficesPage = New DevExpress.XtraWizard.WizardPage()
            Me.DataGridViewSelectOffices_GLOffices = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardPageWizard_SelectDepartmentsPage = New DevExpress.XtraWizard.WizardPage()
            Me.DataGridViewSelectDepartments_GLDepartments = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardPageWizard_SelectOthersPage = New DevExpress.XtraWizard.WizardPage()
            Me.DataGridViewSelectOthers_Others = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardPageWizard_AddingPage = New DevExpress.XtraWizard.WizardPage()
            Me.LabelAddingPage_OverallStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarAddingPage_OverallProgress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.WizardPageWizard_SelectRangePage = New DevExpress.XtraWizard.WizardPage()
            Me.ComboBoxSelectRange_BaseRangeTo = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.ComboBoxSelectRange_BaseRangeFrom = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelSelectRange_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.LabelSelectRange_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.WizardControlForm_Wizard.SuspendLayout()
            Me.WizardPageWizard_SelectAccountTypesPage.SuspendLayout()
            CType(Me.GroupBoxSelectAccountTypes_Include, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSelectAccountTypes_Include.SuspendLayout()
            Me.WizardPageWizard_SelectSourcePage.SuspendLayout()
            CType(Me.GroupBoxSelectSource_CreateNewAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GroupBoxSelectSource_CreateNewAccounts.SuspendLayout()
            Me.WizardPageWizard_FinalizeChartOfAccountCreationPage.SuspendLayout()
            Me.WizardPageWizard_SelectTemplatePage.SuspendLayout()
            Me.WizardPageWizard_SelectOfficesPage.SuspendLayout()
            Me.WizardPageWizard_SelectDepartmentsPage.SuspendLayout()
            Me.WizardPageWizard_SelectOthersPage.SuspendLayout()
            Me.WizardPageWizard_AddingPage.SuspendLayout()
            Me.WizardPageWizard_SelectRangePage.SuspendLayout()
            Me.SuspendLayout()
            '
            'CompletionWizardPageForm_CompletionPage
            '
            Me.CompletionWizardPageForm_CompletionPage.AllowBack = False
            Me.CompletionWizardPageForm_CompletionPage.AllowCancel = False
            Me.CompletionWizardPageForm_CompletionPage.Name = "CompletionWizardPageForm_CompletionPage"
            Me.CompletionWizardPageForm_CompletionPage.Size = New System.Drawing.Size(475, 266)
            Me.CompletionWizardPageForm_CompletionPage.Text = "Create Chart of Account Wizard Completed"
            '
            'WelcomeWizardPageForm_WelcomePage
            '
            Me.WelcomeWizardPageForm_WelcomePage.AllowBack = False
            Me.WelcomeWizardPageForm_WelcomePage.IntroductionText = "This wizard will help guide you through the process of creating a chart of accoun" & _
        "ts" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " in the Advantage system."
            Me.WelcomeWizardPageForm_WelcomePage.Name = "WelcomeWizardPageForm_WelcomePage"
            Me.WelcomeWizardPageForm_WelcomePage.Size = New System.Drawing.Size(475, 243)
            Me.WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Create Chart of Accounts Wizard"
            '
            'WizardControlForm_Wizard
            '
            Me.WizardControlForm_Wizard.Controls.Add(Me.WelcomeWizardPageForm_WelcomePage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectAccountTypesPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.CompletionWizardPageForm_CompletionPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectSourcePage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_FinalizeChartOfAccountCreationPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectTemplatePage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectOfficesPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectDepartmentsPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectOthersPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_AddingPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectRangePage)
            Me.WizardControlForm_Wizard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WizardControlForm_Wizard.ImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.WizardControlForm_Wizard.ImageWidth = 200
            Me.WizardControlForm_Wizard.Location = New System.Drawing.Point(0, 0)
            Me.WizardControlForm_Wizard.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.WizardControlForm_Wizard.LookAndFeel.UseDefaultLookAndFeel = False
            Me.WizardControlForm_Wizard.Name = "WizardControlForm_Wizard"
            Me.WizardControlForm_Wizard.NavigationMode = DevExpress.XtraWizard.NavigationMode.Stacked
            Me.WizardControlForm_Wizard.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() {Me.WelcomeWizardPageForm_WelcomePage, Me.WizardPageWizard_SelectSourcePage, Me.WizardPageWizard_SelectTemplatePage, Me.WizardPageWizard_SelectAccountTypesPage, Me.WizardPageWizard_SelectRangePage, Me.WizardPageWizard_SelectOfficesPage, Me.WizardPageWizard_SelectDepartmentsPage, Me.WizardPageWizard_SelectOthersPage, Me.WizardPageWizard_FinalizeChartOfAccountCreationPage, Me.WizardPageWizard_AddingPage, Me.CompletionWizardPageForm_CompletionPage})
            Me.WizardControlForm_Wizard.ShowHeaderImage = True
            Me.WizardControlForm_Wizard.Size = New System.Drawing.Size(707, 398)
            Me.WizardControlForm_Wizard.Text = ""
            '
            'WizardPageWizard_SelectAccountTypesPage
            '
            Me.WizardPageWizard_SelectAccountTypesPage.Controls.Add(Me.ButtonSelectAccountTypes_DeselectAll)
            Me.WizardPageWizard_SelectAccountTypesPage.Controls.Add(Me.GroupBoxSelectAccountTypes_Include)
            Me.WizardPageWizard_SelectAccountTypesPage.Controls.Add(Me.ButtonSelectAccountTypes_SelectAll)
            Me.WizardPageWizard_SelectAccountTypesPage.DescriptionText = ""
            Me.WizardPageWizard_SelectAccountTypesPage.Name = "WizardPageWizard_SelectAccountTypesPage"
            Me.WizardPageWizard_SelectAccountTypesPage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_SelectAccountTypesPage.Text = "Select Account Types"
            '
            'ButtonSelectAccountTypes_DeselectAll
            '
            Me.ButtonSelectAccountTypes_DeselectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSelectAccountTypes_DeselectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSelectAccountTypes_DeselectAll.Location = New System.Drawing.Point(181, 189)
            Me.ButtonSelectAccountTypes_DeselectAll.Name = "ButtonSelectAccountTypes_DeselectAll"
            Me.ButtonSelectAccountTypes_DeselectAll.SecurityEnabled = True
            Me.ButtonSelectAccountTypes_DeselectAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSelectAccountTypes_DeselectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSelectAccountTypes_DeselectAll.TabIndex = 10
            Me.ButtonSelectAccountTypes_DeselectAll.Text = "Deselect All"
            '
            'GroupBoxSelectAccountTypes_Include
            '
            Me.GroupBoxSelectAccountTypes_Include.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_ExpenseTaxes)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_ExpenseOther)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_ExpenseOperating)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_ExpenseCOS)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_OtherIncome)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_Income)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_Equity)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_CurrentLiabilities)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_FixedAssets)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_NonCurrentAssets)
            Me.GroupBoxSelectAccountTypes_Include.Controls.Add(Me.CheckBoxSelectAccountTypes_CurrentAssets)
            Me.GroupBoxSelectAccountTypes_Include.Location = New System.Drawing.Point(100, 46)
            Me.GroupBoxSelectAccountTypes_Include.Name = "GroupBoxSelectAccountTypes_Include"
            Me.GroupBoxSelectAccountTypes_Include.Size = New System.Drawing.Size(480, 137)
            Me.GroupBoxSelectAccountTypes_Include.TabIndex = 3
            Me.GroupBoxSelectAccountTypes_Include.Text = "Include"
            '
            'CheckBoxSelectAccountTypes_ExpenseTaxes
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_ExpenseTaxes.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.Location = New System.Drawing.Point(299, 103)
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.Name = "CheckBoxSelectAccountTypes_ExpenseTaxes"
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_ExpenseTaxes.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.TabIndex = 11
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.Tag = "16"
            Me.CheckBoxSelectAccountTypes_ExpenseTaxes.Text = "Expense Taxes"
            '
            'CheckBoxSelectAccountTypes_ExpenseOther
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_ExpenseOther.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_ExpenseOther.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_ExpenseOther.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_ExpenseOther.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_ExpenseOther.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_ExpenseOther.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_ExpenseOther.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_ExpenseOther.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_ExpenseOther.Location = New System.Drawing.Point(299, 77)
            Me.CheckBoxSelectAccountTypes_ExpenseOther.Name = "CheckBoxSelectAccountTypes_ExpenseOther"
            Me.CheckBoxSelectAccountTypes_ExpenseOther.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_ExpenseOther.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_ExpenseOther.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_ExpenseOther.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_ExpenseOther.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_ExpenseOther.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_ExpenseOther.TabIndex = 10
            Me.CheckBoxSelectAccountTypes_ExpenseOther.Tag = "15"
            Me.CheckBoxSelectAccountTypes_ExpenseOther.Text = "Expense Other"
            '
            'CheckBoxSelectAccountTypes_ExpenseOperating
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_ExpenseOperating.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.Location = New System.Drawing.Point(299, 51)
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.Name = "CheckBoxSelectAccountTypes_ExpenseOperating"
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_ExpenseOperating.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.TabIndex = 9
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.Tag = "14"
            Me.CheckBoxSelectAccountTypes_ExpenseOperating.Text = "Expense Operating"
            '
            'CheckBoxSelectAccountTypes_ExpenseCOS
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_ExpenseCOS.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.Location = New System.Drawing.Point(299, 25)
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.Name = "CheckBoxSelectAccountTypes_ExpenseCOS"
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_ExpenseCOS.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.TabIndex = 8
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.Tag = "13"
            Me.CheckBoxSelectAccountTypes_ExpenseCOS.Text = "Expense COS"
            '
            'CheckBoxSelectAccountTypes_OtherIncome
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_OtherIncome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_OtherIncome.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_OtherIncome.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_OtherIncome.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_OtherIncome.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_OtherIncome.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_OtherIncome.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_OtherIncome.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_OtherIncome.Location = New System.Drawing.Point(152, 102)
            Me.CheckBoxSelectAccountTypes_OtherIncome.Name = "CheckBoxSelectAccountTypes_OtherIncome"
            Me.CheckBoxSelectAccountTypes_OtherIncome.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_OtherIncome.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_OtherIncome.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_OtherIncome.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_OtherIncome.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_OtherIncome.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_OtherIncome.TabIndex = 7
            Me.CheckBoxSelectAccountTypes_OtherIncome.Tag = "9"
            Me.CheckBoxSelectAccountTypes_OtherIncome.Text = "Other Income"
            '
            'CheckBoxSelectAccountTypes_Income
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_Income.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_Income.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_Income.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_Income.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_Income.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_Income.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_Income.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_Income.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_Income.Location = New System.Drawing.Point(152, 76)
            Me.CheckBoxSelectAccountTypes_Income.Name = "CheckBoxSelectAccountTypes_Income"
            Me.CheckBoxSelectAccountTypes_Income.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_Income.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_Income.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_Income.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_Income.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_Income.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_Income.TabIndex = 6
            Me.CheckBoxSelectAccountTypes_Income.Tag = "8"
            Me.CheckBoxSelectAccountTypes_Income.Text = "Income"
            '
            'CheckBoxSelectAccountTypes_Equity
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_Equity.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_Equity.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_Equity.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_Equity.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_Equity.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_Equity.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_Equity.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_Equity.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_Equity.Location = New System.Drawing.Point(152, 24)
            Me.CheckBoxSelectAccountTypes_Equity.Name = "CheckBoxSelectAccountTypes_Equity"
            Me.CheckBoxSelectAccountTypes_Equity.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_Equity.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_Equity.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_Equity.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_Equity.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_Equity.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_Equity.TabIndex = 5
            Me.CheckBoxSelectAccountTypes_Equity.Tag = "20"
            Me.CheckBoxSelectAccountTypes_Equity.Text = "Equity"
            '
            'CheckBoxSelectAccountTypes_NonCurrentLiabilities
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_NonCurrentLiabilities.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.Location = New System.Drawing.Point(5, 103)
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.Name = "CheckBoxSelectAccountTypes_NonCurrentLiabilities"
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_NonCurrentLiabilities.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.TabIndex = 4
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.Tag = "4"
            Me.CheckBoxSelectAccountTypes_NonCurrentLiabilities.Text = "Non Current Liabilities"
            '
            'CheckBoxSelectAccountTypes_CurrentLiabilities
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_CurrentLiabilities.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.Location = New System.Drawing.Point(5, 77)
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.Name = "CheckBoxSelectAccountTypes_CurrentLiabilities"
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_CurrentLiabilities.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.TabIndex = 3
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.Tag = "5"
            Me.CheckBoxSelectAccountTypes_CurrentLiabilities.Text = "Current Liabilities"
            '
            'CheckBoxSelectAccountTypes_FixedAssets
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_FixedAssets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_FixedAssets.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_FixedAssets.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_FixedAssets.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_FixedAssets.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_FixedAssets.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_FixedAssets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_FixedAssets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_FixedAssets.Location = New System.Drawing.Point(152, 51)
            Me.CheckBoxSelectAccountTypes_FixedAssets.Name = "CheckBoxSelectAccountTypes_FixedAssets"
            Me.CheckBoxSelectAccountTypes_FixedAssets.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_FixedAssets.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_FixedAssets.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_FixedAssets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_FixedAssets.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_FixedAssets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_FixedAssets.TabIndex = 2
            Me.CheckBoxSelectAccountTypes_FixedAssets.Tag = "3"
            Me.CheckBoxSelectAccountTypes_FixedAssets.Text = "Fixed Assets"
            '
            'CheckBoxSelectAccountTypes_NonCurrentAssets
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_NonCurrentAssets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.Location = New System.Drawing.Point(5, 51)
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.Name = "CheckBoxSelectAccountTypes_NonCurrentAssets"
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_NonCurrentAssets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.TabIndex = 1
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.Tag = "1"
            Me.CheckBoxSelectAccountTypes_NonCurrentAssets.Text = "Non Current Assets"
            '
            'CheckBoxSelectAccountTypes_CurrentAssets
            '
            '
            '
            '
            Me.CheckBoxSelectAccountTypes_CurrentAssets.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectAccountTypes_CurrentAssets.CheckValue = 0
            Me.CheckBoxSelectAccountTypes_CurrentAssets.CheckValueChecked = 1
            Me.CheckBoxSelectAccountTypes_CurrentAssets.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectAccountTypes_CurrentAssets.CheckValueUnchecked = 0
            Me.CheckBoxSelectAccountTypes_CurrentAssets.ChildControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_CurrentAssets.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_CurrentAssets.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectAccountTypes_CurrentAssets.Location = New System.Drawing.Point(5, 25)
            Me.CheckBoxSelectAccountTypes_CurrentAssets.Name = "CheckBoxSelectAccountTypes_CurrentAssets"
            Me.CheckBoxSelectAccountTypes_CurrentAssets.OldestSibling = Nothing
            Me.CheckBoxSelectAccountTypes_CurrentAssets.SecurityEnabled = True
            Me.CheckBoxSelectAccountTypes_CurrentAssets.SiblingControls = CType(resources.GetObject("CheckBoxSelectAccountTypes_CurrentAssets.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectAccountTypes_CurrentAssets.Size = New System.Drawing.Size(141, 20)
            Me.CheckBoxSelectAccountTypes_CurrentAssets.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectAccountTypes_CurrentAssets.TabIndex = 0
            Me.CheckBoxSelectAccountTypes_CurrentAssets.Tag = "2"
            Me.CheckBoxSelectAccountTypes_CurrentAssets.Text = "Current Assets"
            '
            'ButtonSelectAccountTypes_SelectAll
            '
            Me.ButtonSelectAccountTypes_SelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSelectAccountTypes_SelectAll.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSelectAccountTypes_SelectAll.Location = New System.Drawing.Point(100, 189)
            Me.ButtonSelectAccountTypes_SelectAll.Name = "ButtonSelectAccountTypes_SelectAll"
            Me.ButtonSelectAccountTypes_SelectAll.SecurityEnabled = True
            Me.ButtonSelectAccountTypes_SelectAll.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSelectAccountTypes_SelectAll.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSelectAccountTypes_SelectAll.TabIndex = 9
            Me.ButtonSelectAccountTypes_SelectAll.Text = "Select All"
            '
            'WizardPageWizard_SelectSourcePage
            '
            Me.WizardPageWizard_SelectSourcePage.Controls.Add(Me.GroupBoxSelectSource_CreateNewAccounts)
            Me.WizardPageWizard_SelectSourcePage.DescriptionText = ""
            Me.WizardPageWizard_SelectSourcePage.Name = "WizardPageWizard_SelectSourcePage"
            Me.WizardPageWizard_SelectSourcePage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_SelectSourcePage.Text = "Select Source"
            '
            'GroupBoxSelectSource_CreateNewAccounts
            '
            Me.GroupBoxSelectSource_CreateNewAccounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBoxSelectSource_CreateNewAccounts.Controls.Add(Me.RadioButtonSelectSource_UsingTemplate)
            Me.GroupBoxSelectSource_CreateNewAccounts.Controls.Add(Me.RadioButtonSelectSource_FromExistingBaseRange)
            Me.GroupBoxSelectSource_CreateNewAccounts.Location = New System.Drawing.Point(217, 48)
            Me.GroupBoxSelectSource_CreateNewAccounts.Name = "GroupBoxSelectSource_CreateNewAccounts"
            Me.GroupBoxSelectSource_CreateNewAccounts.Size = New System.Drawing.Size(240, 85)
            Me.GroupBoxSelectSource_CreateNewAccounts.TabIndex = 4
            Me.GroupBoxSelectSource_CreateNewAccounts.Text = "Create New Accounts"
            '
            'RadioButtonSelectSource_UsingTemplate
            '
            Me.RadioButtonSelectSource_UsingTemplate.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectSource_UsingTemplate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectSource_UsingTemplate.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectSource_UsingTemplate.Location = New System.Drawing.Point(5, 24)
            Me.RadioButtonSelectSource_UsingTemplate.Name = "RadioButtonSelectSource_UsingTemplate"
            Me.RadioButtonSelectSource_UsingTemplate.SecurityEnabled = True
            Me.RadioButtonSelectSource_UsingTemplate.Size = New System.Drawing.Size(198, 20)
            Me.RadioButtonSelectSource_UsingTemplate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectSource_UsingTemplate.TabIndex = 3
            Me.RadioButtonSelectSource_UsingTemplate.TabStop = False
            Me.RadioButtonSelectSource_UsingTemplate.Text = "Using Template"
            '
            'RadioButtonSelectSource_FromExistingBaseRange
            '
            Me.RadioButtonSelectSource_FromExistingBaseRange.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.RadioButtonSelectSource_FromExistingBaseRange.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.RadioButtonSelectSource_FromExistingBaseRange.CheckBoxStyle = DevComponents.DotNetBar.eCheckBoxStyle.RadioButton
            Me.RadioButtonSelectSource_FromExistingBaseRange.Location = New System.Drawing.Point(5, 50)
            Me.RadioButtonSelectSource_FromExistingBaseRange.Name = "RadioButtonSelectSource_FromExistingBaseRange"
            Me.RadioButtonSelectSource_FromExistingBaseRange.SecurityEnabled = True
            Me.RadioButtonSelectSource_FromExistingBaseRange.Size = New System.Drawing.Size(198, 20)
            Me.RadioButtonSelectSource_FromExistingBaseRange.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.RadioButtonSelectSource_FromExistingBaseRange.TabIndex = 4
            Me.RadioButtonSelectSource_FromExistingBaseRange.TabStop = False
            Me.RadioButtonSelectSource_FromExistingBaseRange.Text = "From Existing Base Range"
            '
            'WizardPageWizard_FinalizeChartOfAccountCreationPage
            '
            Me.WizardPageWizard_FinalizeChartOfAccountCreationPage.Controls.Add(Me.DataGridViewFinalizeChartOfAccountCreation_COAs)
            Me.WizardPageWizard_FinalizeChartOfAccountCreationPage.DescriptionText = "* Note: Only those accounts selected in the grid below will be created.  Duplicat" & _
        "es have already been removed. *"
            Me.WizardPageWizard_FinalizeChartOfAccountCreationPage.Name = "WizardPageWizard_FinalizeChartOfAccountCreationPage"
            Me.WizardPageWizard_FinalizeChartOfAccountCreationPage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_FinalizeChartOfAccountCreationPage.Text = "Finalize Account Creation"
            '
            'DataGridViewFinalizeChartOfAccountCreation_COAs
            '
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.AllowSelectGroupHeaderRow = True
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.AlwaysForceShowRowSelectionOnUserInput = False
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.AutoFilterLookupColumns = False
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.AutoloadRepositoryDatasource = True
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.AutoUpdateViewCaption = True
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.DataSource = Nothing
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.ItemDescription = "Chart of Account(s)"
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.MultiSelect = True
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.Name = "DataGridViewFinalizeChartOfAccountCreation_COAs"
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.RunStandardValidation = True
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.ShowSelectDeselectAllButtons = False
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.Size = New System.Drawing.Size(669, 249)
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.TabIndex = 1
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.UseEmbeddedNavigator = False
            Me.DataGridViewFinalizeChartOfAccountCreation_COAs.ViewCaptionHeight = -1
            '
            'WizardPageWizard_SelectTemplatePage
            '
            Me.WizardPageWizard_SelectTemplatePage.Controls.Add(Me.ComboBoxSelectTemplate_Template)
            Me.WizardPageWizard_SelectTemplatePage.Controls.Add(Me.LabelSelectTemplate_Template)
            Me.WizardPageWizard_SelectTemplatePage.DescriptionText = ""
            Me.WizardPageWizard_SelectTemplatePage.Name = "WizardPageWizard_SelectTemplatePage"
            Me.WizardPageWizard_SelectTemplatePage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_SelectTemplatePage.Text = "Select Template"
            '
            'ComboBoxSelectTemplate_Template
            '
            Me.ComboBoxSelectTemplate_Template.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSelectTemplate_Template.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxSelectTemplate_Template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSelectTemplate_Template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSelectTemplate_Template.AutoFindItemInDataSource = False
            Me.ComboBoxSelectTemplate_Template.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSelectTemplate_Template.BookmarkingEnabled = False
            Me.ComboBoxSelectTemplate_Template.ClientCode = ""
            Me.ComboBoxSelectTemplate_Template.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxSelectTemplate_Template.DisableMouseWheel = False
            Me.ComboBoxSelectTemplate_Template.DisplayName = ""
            Me.ComboBoxSelectTemplate_Template.DivisionCode = ""
            Me.ComboBoxSelectTemplate_Template.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSelectTemplate_Template.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSelectTemplate_Template.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSelectTemplate_Template.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSelectTemplate_Template.FocusHighlightEnabled = True
            Me.ComboBoxSelectTemplate_Template.FormattingEnabled = True
            Me.ComboBoxSelectTemplate_Template.ItemHeight = 14
            Me.ComboBoxSelectTemplate_Template.Location = New System.Drawing.Point(68, 80)
            Me.ComboBoxSelectTemplate_Template.Name = "ComboBoxSelectTemplate_Template"
            Me.ComboBoxSelectTemplate_Template.PreventEnterBeep = False
            Me.ComboBoxSelectTemplate_Template.ReadOnly = False
            Me.ComboBoxSelectTemplate_Template.SecurityEnabled = True
            Me.ComboBoxSelectTemplate_Template.Size = New System.Drawing.Size(604, 20)
            Me.ComboBoxSelectTemplate_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSelectTemplate_Template.TabIndex = 8
            '
            'LabelSelectTemplate_Template
            '
            Me.LabelSelectTemplate_Template.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectTemplate_Template.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectTemplate_Template.Location = New System.Drawing.Point(3, 80)
            Me.LabelSelectTemplate_Template.Name = "LabelSelectTemplate_Template"
            Me.LabelSelectTemplate_Template.Size = New System.Drawing.Size(59, 20)
            Me.LabelSelectTemplate_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectTemplate_Template.TabIndex = 7
            Me.LabelSelectTemplate_Template.Text = "Template:"
            '
            'WizardPageWizard_SelectOfficesPage
            '
            Me.WizardPageWizard_SelectOfficesPage.Controls.Add(Me.DataGridViewSelectOffices_GLOffices)
            Me.WizardPageWizard_SelectOfficesPage.DescriptionText = ""
            Me.WizardPageWizard_SelectOfficesPage.Name = "WizardPageWizard_SelectOfficesPage"
            Me.WizardPageWizard_SelectOfficesPage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_SelectOfficesPage.Text = "Select Office(s)"
            '
            'DataGridViewSelectOffices_GLOffices
            '
            Me.DataGridViewSelectOffices_GLOffices.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectOffices_GLOffices.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectOffices_GLOffices.AlwaysForceShowRowSelectionOnUserInput = False
            Me.DataGridViewSelectOffices_GLOffices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectOffices_GLOffices.AutoFilterLookupColumns = False
            Me.DataGridViewSelectOffices_GLOffices.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectOffices_GLOffices.AutoUpdateViewCaption = True
            Me.DataGridViewSelectOffices_GLOffices.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSelectOffices_GLOffices.DataSource = Nothing
            Me.DataGridViewSelectOffices_GLOffices.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOffices_GLOffices.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOffices_GLOffices.ItemDescription = "GL Office(s)"
            Me.DataGridViewSelectOffices_GLOffices.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewSelectOffices_GLOffices.MultiSelect = True
            Me.DataGridViewSelectOffices_GLOffices.Name = "DataGridViewSelectOffices_GLOffices"
            Me.DataGridViewSelectOffices_GLOffices.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSelectOffices_GLOffices.RunStandardValidation = True
            Me.DataGridViewSelectOffices_GLOffices.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOffices_GLOffices.Size = New System.Drawing.Size(669, 249)
            Me.DataGridViewSelectOffices_GLOffices.TabIndex = 1
            Me.DataGridViewSelectOffices_GLOffices.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOffices_GLOffices.ViewCaptionHeight = -1
            '
            'WizardPageWizard_SelectDepartmentsPage
            '
            Me.WizardPageWizard_SelectDepartmentsPage.Controls.Add(Me.DataGridViewSelectDepartments_GLDepartments)
            Me.WizardPageWizard_SelectDepartmentsPage.DescriptionText = ""
            Me.WizardPageWizard_SelectDepartmentsPage.Name = "WizardPageWizard_SelectDepartmentsPage"
            Me.WizardPageWizard_SelectDepartmentsPage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_SelectDepartmentsPage.Text = "Select Department(s)"
            '
            'DataGridViewSelectDepartments_GLDepartments
            '
            Me.DataGridViewSelectDepartments_GLDepartments.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectDepartments_GLDepartments.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectDepartments_GLDepartments.AlwaysForceShowRowSelectionOnUserInput = False
            Me.DataGridViewSelectDepartments_GLDepartments.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectDepartments_GLDepartments.AutoFilterLookupColumns = False
            Me.DataGridViewSelectDepartments_GLDepartments.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectDepartments_GLDepartments.AutoUpdateViewCaption = True
            Me.DataGridViewSelectDepartments_GLDepartments.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSelectDepartments_GLDepartments.DataSource = Nothing
            Me.DataGridViewSelectDepartments_GLDepartments.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectDepartments_GLDepartments.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectDepartments_GLDepartments.ItemDescription = "GL Department(s)"
            Me.DataGridViewSelectDepartments_GLDepartments.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewSelectDepartments_GLDepartments.MultiSelect = True
            Me.DataGridViewSelectDepartments_GLDepartments.Name = "DataGridViewSelectDepartments_GLDepartments"
            Me.DataGridViewSelectDepartments_GLDepartments.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSelectDepartments_GLDepartments.RunStandardValidation = True
            Me.DataGridViewSelectDepartments_GLDepartments.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectDepartments_GLDepartments.Size = New System.Drawing.Size(669, 249)
            Me.DataGridViewSelectDepartments_GLDepartments.TabIndex = 2
            Me.DataGridViewSelectDepartments_GLDepartments.UseEmbeddedNavigator = False
            Me.DataGridViewSelectDepartments_GLDepartments.ViewCaptionHeight = -1
            '
            'WizardPageWizard_SelectOthersPage
            '
            Me.WizardPageWizard_SelectOthersPage.Controls.Add(Me.DataGridViewSelectOthers_Others)
            Me.WizardPageWizard_SelectOthersPage.DescriptionText = ""
            Me.WizardPageWizard_SelectOthersPage.Name = "WizardPageWizard_SelectOthersPage"
            Me.WizardPageWizard_SelectOthersPage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_SelectOthersPage.Text = "Select Other Code(s)"
            '
            'DataGridViewSelectOthers_Others
            '
            Me.DataGridViewSelectOthers_Others.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectOthers_Others.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectOthers_Others.AlwaysForceShowRowSelectionOnUserInput = False
            Me.DataGridViewSelectOthers_Others.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DataGridViewSelectOthers_Others.AutoFilterLookupColumns = False
            Me.DataGridViewSelectOthers_Others.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectOthers_Others.AutoUpdateViewCaption = True
            Me.DataGridViewSelectOthers_Others.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.EditableGrid
            Me.DataGridViewSelectOthers_Others.DataSource = Nothing
            Me.DataGridViewSelectOthers_Others.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectOthers_Others.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectOthers_Others.ItemDescription = "Other Code(s)"
            Me.DataGridViewSelectOthers_Others.Location = New System.Drawing.Point(3, 3)
            Me.DataGridViewSelectOthers_Others.MultiSelect = True
            Me.DataGridViewSelectOthers_Others.Name = "DataGridViewSelectOthers_Others"
            Me.DataGridViewSelectOthers_Others.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            Me.DataGridViewSelectOthers_Others.RunStandardValidation = True
            Me.DataGridViewSelectOthers_Others.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectOthers_Others.Size = New System.Drawing.Size(669, 249)
            Me.DataGridViewSelectOthers_Others.TabIndex = 3
            Me.DataGridViewSelectOthers_Others.UseEmbeddedNavigator = False
            Me.DataGridViewSelectOthers_Others.ViewCaptionHeight = -1
            '
            'WizardPageWizard_AddingPage
            '
            Me.WizardPageWizard_AddingPage.AllowBack = False
            Me.WizardPageWizard_AddingPage.AllowCancel = False
            Me.WizardPageWizard_AddingPage.Controls.Add(Me.LabelAddingPage_OverallStatus)
            Me.WizardPageWizard_AddingPage.Controls.Add(Me.ProgressBarAddingPage_OverallProgress)
            Me.WizardPageWizard_AddingPage.DescriptionText = ""
            Me.WizardPageWizard_AddingPage.Name = "WizardPageWizard_AddingPage"
            Me.WizardPageWizard_AddingPage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_AddingPage.Text = "Adding Selected Charts of Accounts..."
            '
            'LabelAddingPage_OverallStatus
            '
            Me.LabelAddingPage_OverallStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.LabelAddingPage_OverallStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelAddingPage_OverallStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelAddingPage_OverallStatus.Location = New System.Drawing.Point(3, 104)
            Me.LabelAddingPage_OverallStatus.Name = "LabelAddingPage_OverallStatus"
            Me.LabelAddingPage_OverallStatus.Size = New System.Drawing.Size(669, 20)
            Me.LabelAddingPage_OverallStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelAddingPage_OverallStatus.TabIndex = 5
            Me.LabelAddingPage_OverallStatus.Text = "Overall Progress..."
            '
            'ProgressBarAddingPage_OverallProgress
            '
            '
            '
            '
            Me.ProgressBarAddingPage_OverallProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarAddingPage_OverallProgress.Location = New System.Drawing.Point(3, 130)
            Me.ProgressBarAddingPage_OverallProgress.Name = "ProgressBarAddingPage_OverallProgress"
            Me.ProgressBarAddingPage_OverallProgress.Size = New System.Drawing.Size(669, 20)
            Me.ProgressBarAddingPage_OverallProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarAddingPage_OverallProgress.TabIndex = 4
            '
            'WizardPageWizard_SelectRangePage
            '
            Me.WizardPageWizard_SelectRangePage.Controls.Add(Me.ComboBoxSelectRange_BaseRangeTo)
            Me.WizardPageWizard_SelectRangePage.Controls.Add(Me.ComboBoxSelectRange_BaseRangeFrom)
            Me.WizardPageWizard_SelectRangePage.Controls.Add(Me.LabelSelectRange_To)
            Me.WizardPageWizard_SelectRangePage.Controls.Add(Me.LabelSelectRange_From)
            Me.WizardPageWizard_SelectRangePage.DescriptionText = ""
            Me.WizardPageWizard_SelectRangePage.Name = "WizardPageWizard_SelectRangePage"
            Me.WizardPageWizard_SelectRangePage.Size = New System.Drawing.Size(675, 255)
            Me.WizardPageWizard_SelectRangePage.Text = "Select Range"
            '
            'ComboBoxSelectRange_BaseRangeTo
            '
            Me.ComboBoxSelectRange_BaseRangeTo.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSelectRange_BaseRangeTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxSelectRange_BaseRangeTo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSelectRange_BaseRangeTo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSelectRange_BaseRangeTo.AutoFindItemInDataSource = False
            Me.ComboBoxSelectRange_BaseRangeTo.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSelectRange_BaseRangeTo.BookmarkingEnabled = False
            Me.ComboBoxSelectRange_BaseRangeTo.ClientCode = ""
            Me.ComboBoxSelectRange_BaseRangeTo.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxSelectRange_BaseRangeTo.DisableMouseWheel = False
            Me.ComboBoxSelectRange_BaseRangeTo.DisplayName = "To base account"
            Me.ComboBoxSelectRange_BaseRangeTo.DivisionCode = ""
            Me.ComboBoxSelectRange_BaseRangeTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSelectRange_BaseRangeTo.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSelectRange_BaseRangeTo.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSelectRange_BaseRangeTo.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSelectRange_BaseRangeTo.FocusHighlightEnabled = True
            Me.ComboBoxSelectRange_BaseRangeTo.FormattingEnabled = True
            Me.ComboBoxSelectRange_BaseRangeTo.ItemHeight = 14
            Me.ComboBoxSelectRange_BaseRangeTo.Location = New System.Drawing.Point(238, 130)
            Me.ComboBoxSelectRange_BaseRangeTo.Name = "ComboBoxSelectRange_BaseRangeTo"
            Me.ComboBoxSelectRange_BaseRangeTo.PreventEnterBeep = False
            Me.ComboBoxSelectRange_BaseRangeTo.ReadOnly = False
            Me.ComboBoxSelectRange_BaseRangeTo.SecurityEnabled = True
            Me.ComboBoxSelectRange_BaseRangeTo.Size = New System.Drawing.Size(240, 20)
            Me.ComboBoxSelectRange_BaseRangeTo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSelectRange_BaseRangeTo.TabIndex = 12
            '
            'ComboBoxSelectRange_BaseRangeFrom
            '
            Me.ComboBoxSelectRange_BaseRangeFrom.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSelectRange_BaseRangeFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ComboBoxSelectRange_BaseRangeFrom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSelectRange_BaseRangeFrom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSelectRange_BaseRangeFrom.AutoFindItemInDataSource = False
            Me.ComboBoxSelectRange_BaseRangeFrom.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSelectRange_BaseRangeFrom.BookmarkingEnabled = False
            Me.ComboBoxSelectRange_BaseRangeFrom.ClientCode = ""
            Me.ComboBoxSelectRange_BaseRangeFrom.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.[Default]
            Me.ComboBoxSelectRange_BaseRangeFrom.DisableMouseWheel = False
            Me.ComboBoxSelectRange_BaseRangeFrom.DisplayName = "From base account"
            Me.ComboBoxSelectRange_BaseRangeFrom.DivisionCode = ""
            Me.ComboBoxSelectRange_BaseRangeFrom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSelectRange_BaseRangeFrom.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.ComboBoxSelectRange_BaseRangeFrom.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSelectRange_BaseRangeFrom.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSelectRange_BaseRangeFrom.FocusHighlightEnabled = True
            Me.ComboBoxSelectRange_BaseRangeFrom.FormattingEnabled = True
            Me.ComboBoxSelectRange_BaseRangeFrom.ItemHeight = 14
            Me.ComboBoxSelectRange_BaseRangeFrom.Location = New System.Drawing.Point(238, 104)
            Me.ComboBoxSelectRange_BaseRangeFrom.Name = "ComboBoxSelectRange_BaseRangeFrom"
            Me.ComboBoxSelectRange_BaseRangeFrom.PreventEnterBeep = False
            Me.ComboBoxSelectRange_BaseRangeFrom.ReadOnly = False
            Me.ComboBoxSelectRange_BaseRangeFrom.SecurityEnabled = True
            Me.ComboBoxSelectRange_BaseRangeFrom.Size = New System.Drawing.Size(240, 20)
            Me.ComboBoxSelectRange_BaseRangeFrom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSelectRange_BaseRangeFrom.TabIndex = 11
            '
            'LabelSelectRange_To
            '
            Me.LabelSelectRange_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectRange_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectRange_To.Location = New System.Drawing.Point(197, 130)
            Me.LabelSelectRange_To.Name = "LabelSelectRange_To"
            Me.LabelSelectRange_To.Size = New System.Drawing.Size(35, 20)
            Me.LabelSelectRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectRange_To.TabIndex = 9
            Me.LabelSelectRange_To.Text = "To:"
            '
            'LabelSelectRange_From
            '
            Me.LabelSelectRange_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectRange_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectRange_From.Location = New System.Drawing.Point(197, 104)
            Me.LabelSelectRange_From.Name = "LabelSelectRange_From"
            Me.LabelSelectRange_From.Size = New System.Drawing.Size(35, 20)
            Me.LabelSelectRange_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectRange_From.TabIndex = 7
            Me.LabelSelectRange_From.Text = "From:"
            '
            'CreateChartOfAccountWizardDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(707, 398)
            Me.Controls.Add(Me.WizardControlForm_Wizard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "CreateChartOfAccountWizardDialog"
            Me.Text = "Chart of Accounts Wizard"
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.WizardControlForm_Wizard.ResumeLayout(False)
            Me.WizardPageWizard_SelectAccountTypesPage.ResumeLayout(False)
            CType(Me.GroupBoxSelectAccountTypes_Include, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSelectAccountTypes_Include.ResumeLayout(False)
            Me.WizardPageWizard_SelectSourcePage.ResumeLayout(False)
            CType(Me.GroupBoxSelectSource_CreateNewAccounts, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GroupBoxSelectSource_CreateNewAccounts.ResumeLayout(False)
            Me.WizardPageWizard_FinalizeChartOfAccountCreationPage.ResumeLayout(False)
            Me.WizardPageWizard_SelectTemplatePage.ResumeLayout(False)
            Me.WizardPageWizard_SelectOfficesPage.ResumeLayout(False)
            Me.WizardPageWizard_SelectDepartmentsPage.ResumeLayout(False)
            Me.WizardPageWizard_SelectOthersPage.ResumeLayout(False)
            Me.WizardPageWizard_AddingPage.ResumeLayout(False)
            Me.WizardPageWizard_SelectRangePage.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents WizardPageWizard_SelectAccountTypesPage As DevExpress.XtraWizard.WizardPage
        Protected WithEvents WizardControlForm_Wizard As DevExpress.XtraWizard.WizardControl
        Friend WithEvents WizardPageWizard_SelectSourcePage As DevExpress.XtraWizard.WizardPage
        Friend WithEvents WizardPageWizard_FinalizeChartOfAccountCreationPage As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewFinalizeChartOfAccountCreation_COAs As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Private WithEvents CompletionWizardPageForm_CompletionPage As DevExpress.XtraWizard.CompletionWizardPage
        Private WithEvents WelcomeWizardPageForm_WelcomePage As DevExpress.XtraWizard.WelcomeWizardPage
        Friend WithEvents GroupBoxSelectSource_CreateNewAccounts As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents GroupBoxSelectAccountTypes_Include As AdvantageFramework.WinForm.Presentation.Controls.GroupBox
        Friend WithEvents CheckBoxSelectAccountTypes_ExpenseTaxes As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_ExpenseOther As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_ExpenseOperating As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_ExpenseCOS As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_OtherIncome As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_Income As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_Equity As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_NonCurrentLiabilities As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_CurrentLiabilities As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_FixedAssets As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_NonCurrentAssets As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents CheckBoxSelectAccountTypes_CurrentAssets As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents RadioButtonSelectSource_UsingTemplate As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents RadioButtonSelectSource_FromExistingBaseRange As AdvantageFramework.WinForm.Presentation.Controls.RadioButtonControl
        Friend WithEvents WizardPageWizard_SelectTemplatePage As DevExpress.XtraWizard.WizardPage
        Private WithEvents LabelSelectTemplate_Template As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxSelectTemplate_Template As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents WizardPageWizard_SelectOfficesPage As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewSelectOffices_GLOffices As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents WizardPageWizard_SelectDepartmentsPage As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewSelectDepartments_GLDepartments As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents ButtonSelectAccountTypes_DeselectAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonSelectAccountTypes_SelectAll As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents WizardPageWizard_SelectOthersPage As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewSelectOthers_Others As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Friend WithEvents WizardPageWizard_AddingPage As DevExpress.XtraWizard.WizardPage
        Private WithEvents LabelAddingPage_OverallStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Protected WithEvents ProgressBarAddingPage_OverallProgress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents WizardPageWizard_SelectRangePage As DevExpress.XtraWizard.WizardPage
        Friend WithEvents LabelSelectRange_To As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents LabelSelectRange_From As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents ComboBoxSelectRange_BaseRangeTo As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Friend WithEvents ComboBoxSelectRange_BaseRangeFrom As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
    End Class

End Namespace