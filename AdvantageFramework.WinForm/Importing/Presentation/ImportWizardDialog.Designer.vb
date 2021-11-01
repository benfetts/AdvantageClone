Namespace Importing.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class ImportWizardDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportWizardDialog))
            Me.CompletionWizardPageForm_CompletionPage = New DevExpress.XtraWizard.CompletionWizardPage()
            Me.WelcomeWizardPageForm_WelcomePage = New DevExpress.XtraWizard.WelcomeWizardPage()
            Me.WizardControlForm_Wizard = New DevExpress.XtraWizard.WizardControl()
            Me.WizardPageWizard_SelectImportOptions = New DevExpress.XtraWizard.WizardPage()
            Me.CheckBoxForm_ColumnHeaders = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.ComboBoxSelectImportOptions_Template = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelSelectImportOptions_Template = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.WizardPageWizard_ImportingPage = New DevExpress.XtraWizard.WizardPage()
            Me.LabelImportingPage_OverallImportingStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarImportingPage_OverallProgress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.LabelImportingPage_ImportingStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarImportingPage_Progress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.WizardPageWizard_SelectBank = New DevExpress.XtraWizard.WizardPage()
            Me.ComboBoxSelectBank_Bank = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelSelectBank_Bank = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.WizardPageWizard_SelectImportFiles = New DevExpress.XtraWizard.WizardPage()
            Me.LabelSelectImportFiles_Notice = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ButtonSelectImportFiles_LoadDefaultDirectory = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonSelectImportFiles_RemoveFiles = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.ButtonSelectImportFiles_SelectFiles = New AdvantageFramework.WinForm.Presentation.Controls.Button()
            Me.DataGridViewSelectImportFiles_Files = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
            Me.WizardPageWizard_CSIPreferredPartnerDownload = New DevExpress.XtraWizard.WizardPage()
            Me.ProgressBarCSIPreferredPartnerDownload_Progress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            Me.TextBoxCSIPreferredPartnerDownload_Log = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.WizardPageWizard_CSIPreferredPartnerTemplate = New DevExpress.XtraWizard.WizardPage()
            Me.ComboBoxCSIPreferredPartnerTemplate_Template = New AdvantageFramework.WinForm.Presentation.Controls.ComboBox()
            Me.LabelCSIPreferredPartnerTemplate_Template = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.WizardPageWizard_SelectDateRange = New DevExpress.XtraWizard.WizardPage()
            Me.LabelSelectDateRange_To = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.DateTimePickerDateRange_ToDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.DateTimePickerDateRange_FromDate = New AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker()
            Me.LabelSelectDateRange_From = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.WizardControlForm_Wizard.SuspendLayout()
            Me.WizardPageWizard_SelectImportOptions.SuspendLayout()
            Me.WizardPageWizard_ImportingPage.SuspendLayout()
            Me.WizardPageWizard_SelectBank.SuspendLayout()
            Me.WizardPageWizard_SelectImportFiles.SuspendLayout()
            Me.WizardPageWizard_CSIPreferredPartnerDownload.SuspendLayout()
            Me.WizardPageWizard_CSIPreferredPartnerTemplate.SuspendLayout()
            Me.WizardPageWizard_SelectDateRange.SuspendLayout()
            CType(Me.DateTimePickerDateRange_ToDate, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.DateTimePickerDateRange_FromDate, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'CompletionWizardPageForm_CompletionPage
            '
            Me.CompletionWizardPageForm_CompletionPage.AllowBack = False
            Me.CompletionWizardPageForm_CompletionPage.AllowCancel = False
            Me.CompletionWizardPageForm_CompletionPage.Name = "CompletionWizardPageForm_CompletionPage"
            Me.CompletionWizardPageForm_CompletionPage.Size = New System.Drawing.Size(443, 191)
            Me.CompletionWizardPageForm_CompletionPage.Text = "Import Wizard Completed"
            '
            'WelcomeWizardPageForm_WelcomePage
            '
            Me.WelcomeWizardPageForm_WelcomePage.AllowBack = False
            Me.WelcomeWizardPageForm_WelcomePage.IntroductionText = "This wizard will help guide you through the process of importing files" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " into the" &
    " Advantage system."
            Me.WelcomeWizardPageForm_WelcomePage.Name = "WelcomeWizardPageForm_WelcomePage"
            Me.WelcomeWizardPageForm_WelcomePage.Size = New System.Drawing.Size(443, 191)
            Me.WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Import Wizard"
            '
            'WizardControlForm_Wizard
            '
            Me.WizardControlForm_Wizard.Controls.Add(Me.WelcomeWizardPageForm_WelcomePage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectImportOptions)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_ImportingPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.CompletionWizardPageForm_CompletionPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectBank)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectImportFiles)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_CSIPreferredPartnerDownload)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_CSIPreferredPartnerTemplate)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectDateRange)
            Me.WizardControlForm_Wizard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WizardControlForm_Wizard.ImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.WizardControlForm_Wizard.ImageWidth = 200
            Me.WizardControlForm_Wizard.Location = New System.Drawing.Point(0, 0)
            Me.WizardControlForm_Wizard.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.WizardControlForm_Wizard.LookAndFeel.UseDefaultLookAndFeel = False
            Me.WizardControlForm_Wizard.Name = "WizardControlForm_Wizard"
            Me.WizardControlForm_Wizard.NavigationMode = DevExpress.XtraWizard.NavigationMode.Stacked
            Me.WizardControlForm_Wizard.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() {Me.WelcomeWizardPageForm_WelcomePage, Me.WizardPageWizard_SelectBank, Me.WizardPageWizard_SelectDateRange, Me.WizardPageWizard_CSIPreferredPartnerTemplate, Me.WizardPageWizard_CSIPreferredPartnerDownload, Me.WizardPageWizard_SelectImportOptions, Me.WizardPageWizard_SelectImportFiles, Me.WizardPageWizard_ImportingPage, Me.CompletionWizardPageForm_CompletionPage})
            Me.WizardControlForm_Wizard.ShowHeaderImage = True
            Me.WizardControlForm_Wizard.Size = New System.Drawing.Size(675, 323)
            Me.WizardControlForm_Wizard.Text = ""
            '
            'WizardPageWizard_SelectImportOptions
            '
            Me.WizardPageWizard_SelectImportOptions.Controls.Add(Me.CheckBoxForm_ColumnHeaders)
            Me.WizardPageWizard_SelectImportOptions.Controls.Add(Me.ComboBoxSelectImportOptions_Template)
            Me.WizardPageWizard_SelectImportOptions.Controls.Add(Me.LabelSelectImportOptions_Template)
            Me.WizardPageWizard_SelectImportOptions.Controls.Add(Me.CheckBoxSelectImportOptions_AutoTrimOverflowData)
            Me.WizardPageWizard_SelectImportOptions.DescriptionText = ""
            Me.WizardPageWizard_SelectImportOptions.Name = "WizardPageWizard_SelectImportOptions"
            Me.WizardPageWizard_SelectImportOptions.Size = New System.Drawing.Size(643, 180)
            Me.WizardPageWizard_SelectImportOptions.Text = "Select Import Options"
            '
            'CheckBoxForm_ColumnHeaders
            '
            Me.CheckBoxForm_ColumnHeaders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxForm_ColumnHeaders.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxForm_ColumnHeaders.CheckValue = 0
            Me.CheckBoxForm_ColumnHeaders.CheckValueChecked = 1
            Me.CheckBoxForm_ColumnHeaders.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxForm_ColumnHeaders.CheckValueUnchecked = 0
            Me.CheckBoxForm_ColumnHeaders.ChildControls = CType(resources.GetObject("CheckBoxForm_ColumnHeaders.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ColumnHeaders.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxForm_ColumnHeaders.Location = New System.Drawing.Point(70, 107)
            Me.CheckBoxForm_ColumnHeaders.Name = "CheckBoxForm_ColumnHeaders"
            Me.CheckBoxForm_ColumnHeaders.OldestSibling = Nothing
            Me.CheckBoxForm_ColumnHeaders.SecurityEnabled = True
            Me.CheckBoxForm_ColumnHeaders.SiblingControls = CType(resources.GetObject("CheckBoxForm_ColumnHeaders.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxForm_ColumnHeaders.Size = New System.Drawing.Size(570, 19)
            Me.CheckBoxForm_ColumnHeaders.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxForm_ColumnHeaders.TabIndex = 5
            Me.CheckBoxForm_ColumnHeaders.TabOnEnter = True
            Me.CheckBoxForm_ColumnHeaders.Text = "First Line Contains Column Headers"
            '
            'ComboBoxSelectImportOptions_Template
            '
            Me.ComboBoxSelectImportOptions_Template.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSelectImportOptions_Template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSelectImportOptions_Template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSelectImportOptions_Template.AutoFindItemInDataSource = False
            Me.ComboBoxSelectImportOptions_Template.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSelectImportOptions_Template.BookmarkingEnabled = False
            Me.ComboBoxSelectImportOptions_Template.ClientCode = ""
            Me.ComboBoxSelectImportOptions_Template.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.ImportTemplate
            Me.ComboBoxSelectImportOptions_Template.DisableMouseWheel = False
            Me.ComboBoxSelectImportOptions_Template.DisplayMember = "Name"
            Me.ComboBoxSelectImportOptions_Template.DisplayName = ""
            Me.ComboBoxSelectImportOptions_Template.DivisionCode = ""
            Me.ComboBoxSelectImportOptions_Template.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSelectImportOptions_Template.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxSelectImportOptions_Template.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSelectImportOptions_Template.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSelectImportOptions_Template.FocusHighlightEnabled = True
            Me.ComboBoxSelectImportOptions_Template.FormattingEnabled = True
            Me.ComboBoxSelectImportOptions_Template.ItemHeight = 14
            Me.ComboBoxSelectImportOptions_Template.Location = New System.Drawing.Point(70, 56)
            Me.ComboBoxSelectImportOptions_Template.Name = "ComboBoxSelectImportOptions_Template"
            Me.ComboBoxSelectImportOptions_Template.ReadOnly = False
            Me.ComboBoxSelectImportOptions_Template.SecurityEnabled = True
            Me.ComboBoxSelectImportOptions_Template.Size = New System.Drawing.Size(570, 20)
            Me.ComboBoxSelectImportOptions_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSelectImportOptions_Template.TabIndex = 1
            Me.ComboBoxSelectImportOptions_Template.TabOnEnter = True
            Me.ComboBoxSelectImportOptions_Template.ValueMember = "ID"
            Me.ComboBoxSelectImportOptions_Template.WatermarkText = "Select Import Template"
            '
            'LabelSelectImportOptions_Template
            '
            Me.LabelSelectImportOptions_Template.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectImportOptions_Template.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectImportOptions_Template.Location = New System.Drawing.Point(3, 56)
            Me.LabelSelectImportOptions_Template.Name = "LabelSelectImportOptions_Template"
            Me.LabelSelectImportOptions_Template.Size = New System.Drawing.Size(61, 20)
            Me.LabelSelectImportOptions_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectImportOptions_Template.TabIndex = 0
            Me.LabelSelectImportOptions_Template.Text = "Template:"
            '
            'CheckBoxSelectImportOptions_AutoTrimOverflowData
            '
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.CheckValue = 0
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.CheckValueChecked = 1
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.CheckValueType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.CheckValueTypes.[Integer]
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.CheckValueUnchecked = 0
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.ChildControls = CType(resources.GetObject("CheckBoxSelectImportOptions_AutoTrimOverflowData.ChildControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.ControlType = AdvantageFramework.WinForm.Presentation.Controls.CheckBox.Type.Checked1Unchecked0
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Location = New System.Drawing.Point(70, 82)
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Name = "CheckBoxSelectImportOptions_AutoTrimOverflowData"
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.OldestSibling = Nothing
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.SecurityEnabled = True
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.SiblingControls = CType(resources.GetObject("CheckBoxSelectImportOptions_AutoTrimOverflowData.SiblingControls"), System.Collections.Generic.List(Of Object))
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Size = New System.Drawing.Size(570, 19)
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.TabIndex = 4
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.TabOnEnter = True
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Text = "Auto Trim Overflow Data"
            '
            'WizardPageWizard_ImportingPage
            '
            Me.WizardPageWizard_ImportingPage.AllowBack = False
            Me.WizardPageWizard_ImportingPage.AllowCancel = False
            Me.WizardPageWizard_ImportingPage.Controls.Add(Me.LabelImportingPage_OverallImportingStatus)
            Me.WizardPageWizard_ImportingPage.Controls.Add(Me.ProgressBarImportingPage_OverallProgress)
            Me.WizardPageWizard_ImportingPage.Controls.Add(Me.LabelImportingPage_ImportingStatus)
            Me.WizardPageWizard_ImportingPage.Controls.Add(Me.ProgressBarImportingPage_Progress)
            Me.WizardPageWizard_ImportingPage.DescriptionText = ""
            Me.WizardPageWizard_ImportingPage.Name = "WizardPageWizard_ImportingPage"
            Me.WizardPageWizard_ImportingPage.Size = New System.Drawing.Size(643, 180)
            Me.WizardPageWizard_ImportingPage.Text = "Importing File(s)...."
            '
            'LabelImportingPage_OverallImportingStatus
            '
            Me.LabelImportingPage_OverallImportingStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelImportingPage_OverallImportingStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelImportingPage_OverallImportingStatus.Location = New System.Drawing.Point(3, 88)
            Me.LabelImportingPage_OverallImportingStatus.Name = "LabelImportingPage_OverallImportingStatus"
            Me.LabelImportingPage_OverallImportingStatus.Size = New System.Drawing.Size(637, 20)
            Me.LabelImportingPage_OverallImportingStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelImportingPage_OverallImportingStatus.TabIndex = 3
            Me.LabelImportingPage_OverallImportingStatus.Text = "Overall Progress..."
            '
            'ProgressBarImportingPage_OverallProgress
            '
            '
            '
            '
            Me.ProgressBarImportingPage_OverallProgress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarImportingPage_OverallProgress.Location = New System.Drawing.Point(3, 114)
            Me.ProgressBarImportingPage_OverallProgress.Name = "ProgressBarImportingPage_OverallProgress"
            Me.ProgressBarImportingPage_OverallProgress.Size = New System.Drawing.Size(637, 20)
            Me.ProgressBarImportingPage_OverallProgress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarImportingPage_OverallProgress.TabIndex = 2
            '
            'LabelImportingPage_ImportingStatus
            '
            Me.LabelImportingPage_ImportingStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelImportingPage_ImportingStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelImportingPage_ImportingStatus.Location = New System.Drawing.Point(3, 36)
            Me.LabelImportingPage_ImportingStatus.Name = "LabelImportingPage_ImportingStatus"
            Me.LabelImportingPage_ImportingStatus.Size = New System.Drawing.Size(637, 20)
            Me.LabelImportingPage_ImportingStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelImportingPage_ImportingStatus.TabIndex = 1
            Me.LabelImportingPage_ImportingStatus.Text = "Importing File..."
            '
            'ProgressBarImportingPage_Progress
            '
            '
            '
            '
            Me.ProgressBarImportingPage_Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarImportingPage_Progress.Location = New System.Drawing.Point(3, 62)
            Me.ProgressBarImportingPage_Progress.Name = "ProgressBarImportingPage_Progress"
            Me.ProgressBarImportingPage_Progress.Size = New System.Drawing.Size(637, 20)
            Me.ProgressBarImportingPage_Progress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarImportingPage_Progress.TabIndex = 0
            '
            'WizardPageWizard_SelectBank
            '
            Me.WizardPageWizard_SelectBank.Controls.Add(Me.ComboBoxSelectBank_Bank)
            Me.WizardPageWizard_SelectBank.Controls.Add(Me.LabelSelectBank_Bank)
            Me.WizardPageWizard_SelectBank.DescriptionText = ""
            Me.WizardPageWizard_SelectBank.Name = "WizardPageWizard_SelectBank"
            Me.WizardPageWizard_SelectBank.Size = New System.Drawing.Size(643, 180)
            Me.WizardPageWizard_SelectBank.Text = "Select A Bank"
            '
            'ComboBoxSelectBank_Bank
            '
            Me.ComboBoxSelectBank_Bank.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxSelectBank_Bank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxSelectBank_Bank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxSelectBank_Bank.AutoFindItemInDataSource = False
            Me.ComboBoxSelectBank_Bank.AutoSelectSingleItemDatasource = False
            Me.ComboBoxSelectBank_Bank.BookmarkingEnabled = False
            Me.ComboBoxSelectBank_Bank.ClientCode = ""
            Me.ComboBoxSelectBank_Bank.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.Bank
            Me.ComboBoxSelectBank_Bank.DisableMouseWheel = False
            Me.ComboBoxSelectBank_Bank.DisplayMember = "Description"
            Me.ComboBoxSelectBank_Bank.DisplayName = ""
            Me.ComboBoxSelectBank_Bank.DivisionCode = ""
            Me.ComboBoxSelectBank_Bank.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxSelectBank_Bank.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxSelectBank_Bank.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxSelectBank_Bank.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxSelectBank_Bank.FocusHighlightEnabled = True
            Me.ComboBoxSelectBank_Bank.FormattingEnabled = True
            Me.ComboBoxSelectBank_Bank.ItemHeight = 14
            Me.ComboBoxSelectBank_Bank.Location = New System.Drawing.Point(40, 79)
            Me.ComboBoxSelectBank_Bank.Name = "ComboBoxSelectBank_Bank"
            Me.ComboBoxSelectBank_Bank.ReadOnly = False
            Me.ComboBoxSelectBank_Bank.SecurityEnabled = True
            Me.ComboBoxSelectBank_Bank.Size = New System.Drawing.Size(600, 20)
            Me.ComboBoxSelectBank_Bank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxSelectBank_Bank.TabIndex = 1
            Me.ComboBoxSelectBank_Bank.TabOnEnter = True
            Me.ComboBoxSelectBank_Bank.ValueMember = "Code"
            Me.ComboBoxSelectBank_Bank.WatermarkText = "Select Bank"
            '
            'LabelSelectBank_Bank
            '
            Me.LabelSelectBank_Bank.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectBank_Bank.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectBank_Bank.Location = New System.Drawing.Point(3, 79)
            Me.LabelSelectBank_Bank.Name = "LabelSelectBank_Bank"
            Me.LabelSelectBank_Bank.Size = New System.Drawing.Size(31, 20)
            Me.LabelSelectBank_Bank.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectBank_Bank.TabIndex = 0
            Me.LabelSelectBank_Bank.Text = "Bank:"
            '
            'WizardPageWizard_SelectImportFiles
            '
            Me.WizardPageWizard_SelectImportFiles.Controls.Add(Me.LabelSelectImportFiles_Notice)
            Me.WizardPageWizard_SelectImportFiles.Controls.Add(Me.ButtonSelectImportFiles_LoadDefaultDirectory)
            Me.WizardPageWizard_SelectImportFiles.Controls.Add(Me.ButtonSelectImportFiles_RemoveFiles)
            Me.WizardPageWizard_SelectImportFiles.Controls.Add(Me.ButtonSelectImportFiles_SelectFiles)
            Me.WizardPageWizard_SelectImportFiles.Controls.Add(Me.DataGridViewSelectImportFiles_Files)
            Me.WizardPageWizard_SelectImportFiles.DescriptionText = ""
            Me.WizardPageWizard_SelectImportFiles.Name = "WizardPageWizard_SelectImportFiles"
            Me.WizardPageWizard_SelectImportFiles.Size = New System.Drawing.Size(643, 180)
            Me.WizardPageWizard_SelectImportFiles.Text = "Select File(s) to Import"
            '
            'LabelSelectImportFiles_Notice
            '
            Me.LabelSelectImportFiles_Notice.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectImportFiles_Notice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectImportFiles_Notice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.LabelSelectImportFiles_Notice.Location = New System.Drawing.Point(3, 0)
            Me.LabelSelectImportFiles_Notice.Name = "LabelSelectImportFiles_Notice"
            Me.LabelSelectImportFiles_Notice.Size = New System.Drawing.Size(637, 20)
            Me.LabelSelectImportFiles_Notice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectImportFiles_Notice.TabIndex = 8
            Me.LabelSelectImportFiles_Notice.Text = "* Note: All files listed in grid below will be imported. *"
            Me.LabelSelectImportFiles_Notice.TextAlignment = System.Drawing.StringAlignment.Center
            '
            'ButtonSelectImportFiles_LoadDefaultDirectory
            '
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.Location = New System.Drawing.Point(165, 157)
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.Name = "ButtonSelectImportFiles_LoadDefaultDirectory"
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.SecurityEnabled = True
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.TabIndex = 7
            Me.ButtonSelectImportFiles_LoadDefaultDirectory.Text = "Load Def Dir"
            '
            'ButtonSelectImportFiles_RemoveFiles
            '
            Me.ButtonSelectImportFiles_RemoveFiles.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSelectImportFiles_RemoveFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonSelectImportFiles_RemoveFiles.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSelectImportFiles_RemoveFiles.Location = New System.Drawing.Point(84, 157)
            Me.ButtonSelectImportFiles_RemoveFiles.Name = "ButtonSelectImportFiles_RemoveFiles"
            Me.ButtonSelectImportFiles_RemoveFiles.SecurityEnabled = True
            Me.ButtonSelectImportFiles_RemoveFiles.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSelectImportFiles_RemoveFiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSelectImportFiles_RemoveFiles.TabIndex = 6
            Me.ButtonSelectImportFiles_RemoveFiles.Text = "Remove Files"
            '
            'ButtonSelectImportFiles_SelectFiles
            '
            Me.ButtonSelectImportFiles_SelectFiles.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
            Me.ButtonSelectImportFiles_SelectFiles.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ButtonSelectImportFiles_SelectFiles.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
            Me.ButtonSelectImportFiles_SelectFiles.Location = New System.Drawing.Point(3, 157)
            Me.ButtonSelectImportFiles_SelectFiles.Name = "ButtonSelectImportFiles_SelectFiles"
            Me.ButtonSelectImportFiles_SelectFiles.SecurityEnabled = True
            Me.ButtonSelectImportFiles_SelectFiles.Size = New System.Drawing.Size(75, 20)
            Me.ButtonSelectImportFiles_SelectFiles.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ButtonSelectImportFiles_SelectFiles.TabIndex = 5
            Me.ButtonSelectImportFiles_SelectFiles.Text = "Select Files"
            '
            'DataGridViewSelectImportFiles_Files
            '
            Me.DataGridViewSelectImportFiles_Files.AddFixedColumnCheckItemsToGridMenu = False
            Me.DataGridViewSelectImportFiles_Files.AllowDragAndDrop = False
            Me.DataGridViewSelectImportFiles_Files.AllowExtraItemsInGridLookupEdits = True
            Me.DataGridViewSelectImportFiles_Files.AllowSelectGroupHeaderRow = True
            Me.DataGridViewSelectImportFiles_Files.AlwaysForceShowRowSelectionOnUserInput = True
            Me.DataGridViewSelectImportFiles_Files.AutoFilterLookupColumns = False
            Me.DataGridViewSelectImportFiles_Files.AutoloadRepositoryDatasource = True
            Me.DataGridViewSelectImportFiles_Files.AutoUpdateViewCaption = True
            Me.DataGridViewSelectImportFiles_Files.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.Type.NonEditableGrid
            Me.DataGridViewSelectImportFiles_Files.DataSource = Nothing
            Me.DataGridViewSelectImportFiles_Files.DataSourceViewOption = AdvantageFramework.WinForm.Presentation.Controls.DataGridView.DataSourceViewOptions.[Default]
            Me.DataGridViewSelectImportFiles_Files.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.[Default]
            Me.DataGridViewSelectImportFiles_Files.ItemDescription = "File(s) Chosen for Import"
            Me.DataGridViewSelectImportFiles_Files.Location = New System.Drawing.Point(3, 26)
            Me.DataGridViewSelectImportFiles_Files.MultiSelect = True
            Me.DataGridViewSelectImportFiles_Files.Name = "DataGridViewSelectImportFiles_Files"
            Me.DataGridViewSelectImportFiles_Files.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
            Me.DataGridViewSelectImportFiles_Files.RunStandardValidation = True
            Me.DataGridViewSelectImportFiles_Files.ShowColumnMenuOnRightClick = False
            Me.DataGridViewSelectImportFiles_Files.ShowSelectDeselectAllButtons = False
            Me.DataGridViewSelectImportFiles_Files.Size = New System.Drawing.Size(637, 125)
            Me.DataGridViewSelectImportFiles_Files.TabIndex = 1
            Me.DataGridViewSelectImportFiles_Files.UseEmbeddedNavigator = False
            Me.DataGridViewSelectImportFiles_Files.ViewCaptionHeight = -1
            '
            'WizardPageWizard_CSIPreferredPartnerDownload
            '
            Me.WizardPageWizard_CSIPreferredPartnerDownload.AllowBack = False
            Me.WizardPageWizard_CSIPreferredPartnerDownload.AllowCancel = False
            Me.WizardPageWizard_CSIPreferredPartnerDownload.Controls.Add(Me.ProgressBarCSIPreferredPartnerDownload_Progress)
            Me.WizardPageWizard_CSIPreferredPartnerDownload.Controls.Add(Me.TextBoxCSIPreferredPartnerDownload_Log)
            Me.WizardPageWizard_CSIPreferredPartnerDownload.DescriptionText = "Please wait as the wizard will download the files to be imported."
            Me.WizardPageWizard_CSIPreferredPartnerDownload.Name = "WizardPageWizard_CSIPreferredPartnerDownload"
            Me.WizardPageWizard_CSIPreferredPartnerDownload.Size = New System.Drawing.Size(643, 180)
            Me.WizardPageWizard_CSIPreferredPartnerDownload.Text = "Download Payment Files"
            '
            'ProgressBarCSIPreferredPartnerDownload_Progress
            '
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.Location = New System.Drawing.Point(0, 0)
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.Name = "ProgressBarCSIPreferredPartnerDownload_Progress"
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.ProgressType = DevComponents.DotNetBar.eProgressItemType.Marquee
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.Size = New System.Drawing.Size(643, 23)
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.TabIndex = 1
            Me.ProgressBarCSIPreferredPartnerDownload_Progress.Text = "ProgressBar1"
            '
            'TextBoxCSIPreferredPartnerDownload_Log
            '
            Me.TextBoxCSIPreferredPartnerDownload_Log.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxCSIPreferredPartnerDownload_Log.Border.Class = "TextBoxBorder"
            Me.TextBoxCSIPreferredPartnerDownload_Log.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxCSIPreferredPartnerDownload_Log.CheckSpellingOnValidate = False
            Me.TextBoxCSIPreferredPartnerDownload_Log.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.[Default]
            Me.TextBoxCSIPreferredPartnerDownload_Log.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.TextBoxCSIPreferredPartnerDownload_Log.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.[Default]
            Me.TextBoxCSIPreferredPartnerDownload_Log.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.TextBoxCSIPreferredPartnerDownload_Log.FocusHighlightEnabled = True
            Me.TextBoxCSIPreferredPartnerDownload_Log.Location = New System.Drawing.Point(0, 33)
            Me.TextBoxCSIPreferredPartnerDownload_Log.MaxFileSize = CType(0, Long)
            Me.TextBoxCSIPreferredPartnerDownload_Log.Multiline = True
            Me.TextBoxCSIPreferredPartnerDownload_Log.Name = "TextBoxCSIPreferredPartnerDownload_Log"
            Me.TextBoxCSIPreferredPartnerDownload_Log.ReadOnly = True
            Me.TextBoxCSIPreferredPartnerDownload_Log.SecurityEnabled = True
            Me.TextBoxCSIPreferredPartnerDownload_Log.ShowSpellCheckCompleteMessage = True
            Me.TextBoxCSIPreferredPartnerDownload_Log.Size = New System.Drawing.Size(643, 147)
            Me.TextBoxCSIPreferredPartnerDownload_Log.StartingFolderName = Nothing
            Me.TextBoxCSIPreferredPartnerDownload_Log.TabIndex = 0
            Me.TextBoxCSIPreferredPartnerDownload_Log.TabOnEnter = True
            '
            'WizardPageWizard_CSIPreferredPartnerTemplate
            '
            Me.WizardPageWizard_CSIPreferredPartnerTemplate.Controls.Add(Me.ComboBoxCSIPreferredPartnerTemplate_Template)
            Me.WizardPageWizard_CSIPreferredPartnerTemplate.Controls.Add(Me.LabelCSIPreferredPartnerTemplate_Template)
            Me.WizardPageWizard_CSIPreferredPartnerTemplate.DescriptionText = "Please select the appropriate file template"
            Me.WizardPageWizard_CSIPreferredPartnerTemplate.Name = "WizardPageWizard_CSIPreferredPartnerTemplate"
            Me.WizardPageWizard_CSIPreferredPartnerTemplate.Size = New System.Drawing.Size(643, 180)
            Me.WizardPageWizard_CSIPreferredPartnerTemplate.Text = "CSI File Template"
            '
            'ComboBoxCSIPreferredPartnerTemplate_Template
            '
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.AddInactiveItemsOnSelectedValue = False
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.AutoFindItemInDataSource = False
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.AutoSelectSingleItemDatasource = False
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.BookmarkingEnabled = False
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.ClientCode = ""
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.ControlType = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.Type.EnumDataTable
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.DisableMouseWheel = False
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.DisplayMember = "Name"
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.DisplayName = ""
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.DivisionCode = ""
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleLeft
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.ComboBox.ExtraComboBoxItems.[Nothing]
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.FocusHighlightEnabled = True
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.FormattingEnabled = True
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.ItemHeight = 14
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.Location = New System.Drawing.Point(73, 80)
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.Name = "ComboBoxCSIPreferredPartnerTemplate_Template"
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.ReadOnly = False
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.SecurityEnabled = True
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.Size = New System.Drawing.Size(567, 20)
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.TabIndex = 1
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.TabOnEnter = True
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.ValueMember = "Value"
            Me.ComboBoxCSIPreferredPartnerTemplate_Template.WatermarkText = "Select"
            '
            'LabelCSIPreferredPartnerTemplate_Template
            '
            Me.LabelCSIPreferredPartnerTemplate_Template.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelCSIPreferredPartnerTemplate_Template.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelCSIPreferredPartnerTemplate_Template.Location = New System.Drawing.Point(3, 80)
            Me.LabelCSIPreferredPartnerTemplate_Template.Name = "LabelCSIPreferredPartnerTemplate_Template"
            Me.LabelCSIPreferredPartnerTemplate_Template.Size = New System.Drawing.Size(64, 20)
            Me.LabelCSIPreferredPartnerTemplate_Template.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelCSIPreferredPartnerTemplate_Template.TabIndex = 0
            Me.LabelCSIPreferredPartnerTemplate_Template.Text = "Template:"
            '
            'WizardPageWizard_SelectDateRange
            '
            Me.WizardPageWizard_SelectDateRange.Controls.Add(Me.LabelSelectDateRange_To)
            Me.WizardPageWizard_SelectDateRange.Controls.Add(Me.DateTimePickerDateRange_ToDate)
            Me.WizardPageWizard_SelectDateRange.Controls.Add(Me.DateTimePickerDateRange_FromDate)
            Me.WizardPageWizard_SelectDateRange.Controls.Add(Me.LabelSelectDateRange_From)
            Me.WizardPageWizard_SelectDateRange.DescriptionText = ""
            Me.WizardPageWizard_SelectDateRange.Name = "WizardPageWizard_SelectDateRange"
            Me.WizardPageWizard_SelectDateRange.Size = New System.Drawing.Size(643, 180)
            Me.WizardPageWizard_SelectDateRange.Text = "Select Date Range"
            '
            'LabelSelectDateRange_To
            '
            Me.LabelSelectDateRange_To.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectDateRange_To.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectDateRange_To.Location = New System.Drawing.Point(250, 93)
            Me.LabelSelectDateRange_To.Name = "LabelSelectDateRange_To"
            Me.LabelSelectDateRange_To.Size = New System.Drawing.Size(40, 20)
            Me.LabelSelectDateRange_To.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectDateRange_To.TabIndex = 14
            Me.LabelSelectDateRange_To.Text = "To:"
            '
            'DateTimePickerDateRange_ToDate
            '
            Me.DateTimePickerDateRange_ToDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDateRange_ToDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDateRange_ToDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateRange_ToDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDateRange_ToDate.ButtonDropDown.Visible = True
            Me.DateTimePickerDateRange_ToDate.ButtonFreeText.Checked = True
            Me.DateTimePickerDateRange_ToDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerDateRange_ToDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerDateRange_ToDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDateRange_ToDate.DisplayName = ""
            Me.DateTimePickerDateRange_ToDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDateRange_ToDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDateRange_ToDate.FocusHighlightEnabled = True
            Me.DateTimePickerDateRange_ToDate.FreeTextEntryMode = True
            Me.DateTimePickerDateRange_ToDate.IsPopupCalendarOpen = False
            Me.DateTimePickerDateRange_ToDate.Location = New System.Drawing.Point(296, 93)
            Me.DateTimePickerDateRange_ToDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDateRange_ToDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDateRange_ToDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDateRange_ToDate.Name = "DateTimePickerDateRange_ToDate"
            Me.DateTimePickerDateRange_ToDate.ReadOnly = False
            Me.DateTimePickerDateRange_ToDate.Size = New System.Drawing.Size(97, 20)
            Me.DateTimePickerDateRange_ToDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDateRange_ToDate.TabIndex = 13
            Me.DateTimePickerDateRange_ToDate.TabOnEnter = True
            Me.DateTimePickerDateRange_ToDate.Value = New Date(2016, 3, 4, 12, 13, 46, 341)
            '
            'DateTimePickerDateRange_FromDate
            '
            Me.DateTimePickerDateRange_FromDate.AutoResolveFreeTextEntries = False
            '
            '
            '
            Me.DateTimePickerDateRange_FromDate.BackgroundStyle.Class = "DateTimeInputBackground"
            Me.DateTimePickerDateRange_FromDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateRange_FromDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown
            Me.DateTimePickerDateRange_FromDate.ButtonDropDown.Visible = True
            Me.DateTimePickerDateRange_FromDate.ButtonFreeText.Checked = True
            Me.DateTimePickerDateRange_FromDate.ControlType = AdvantageFramework.WinForm.Presentation.Controls.DateTimePicker.Type.ShortDate
            Me.DateTimePickerDateRange_FromDate.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.DateSelector
            Me.DateTimePickerDateRange_FromDate.DisabledForeColor = System.Drawing.SystemColors.WindowText
            Me.DateTimePickerDateRange_FromDate.DisplayName = ""
            Me.DateTimePickerDateRange_FromDate.ErrorIconAlignment = System.Windows.Forms.ErrorIconAlignment.MiddleRight
            Me.DateTimePickerDateRange_FromDate.FocusHighlightColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(141, Byte), Integer))
            Me.DateTimePickerDateRange_FromDate.FocusHighlightEnabled = True
            Me.DateTimePickerDateRange_FromDate.FreeTextEntryMode = True
            Me.DateTimePickerDateRange_FromDate.IsPopupCalendarOpen = False
            Me.DateTimePickerDateRange_FromDate.Location = New System.Drawing.Point(296, 67)
            Me.DateTimePickerDateRange_FromDate.MaxDate = New Date(2079, 6, 6, 0, 0, 0, 0)
            Me.DateTimePickerDateRange_FromDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
            '
            '
            '
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.AnnuallyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.BackgroundStyle.BackColor = System.Drawing.SystemColors.Window
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.ClearButtonVisible = True
            '
            '
            '
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.DisplayMonth = New Date(2012, 3, 1, 0, 0, 0, 0)
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.MarkedDates = New Date(-1) {}
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.MonthlyMarkedDates = New Date(-1) {}
            '
            '
            '
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.TodayButtonVisible = True
            Me.DateTimePickerDateRange_FromDate.MonthCalendar.WeeklyMarkedDays = New System.DayOfWeek(-1) {}
            Me.DateTimePickerDateRange_FromDate.Name = "DateTimePickerDateRange_FromDate"
            Me.DateTimePickerDateRange_FromDate.ReadOnly = False
            Me.DateTimePickerDateRange_FromDate.Size = New System.Drawing.Size(97, 20)
            Me.DateTimePickerDateRange_FromDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.DateTimePickerDateRange_FromDate.TabIndex = 12
            Me.DateTimePickerDateRange_FromDate.TabOnEnter = True
            Me.DateTimePickerDateRange_FromDate.Value = New Date(2016, 3, 4, 12, 13, 51, 650)
            '
            'LabelSelectDateRange_From
            '
            Me.LabelSelectDateRange_From.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectDateRange_From.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectDateRange_From.Location = New System.Drawing.Point(250, 67)
            Me.LabelSelectDateRange_From.Name = "LabelSelectDateRange_From"
            Me.LabelSelectDateRange_From.Size = New System.Drawing.Size(40, 20)
            Me.LabelSelectDateRange_From.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectDateRange_From.TabIndex = 1
            Me.LabelSelectDateRange_From.Text = "From:"
            '
            'ImportWizardDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(675, 323)
            Me.Controls.Add(Me.WizardControlForm_Wizard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "ImportWizardDialog"
            Me.Text = "Import Wizard"
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.WizardControlForm_Wizard.ResumeLayout(False)
            Me.WizardPageWizard_SelectImportOptions.ResumeLayout(False)
            Me.WizardPageWizard_ImportingPage.ResumeLayout(False)
            Me.WizardPageWizard_SelectBank.ResumeLayout(False)
            Me.WizardPageWizard_SelectImportFiles.ResumeLayout(False)
            Me.WizardPageWizard_CSIPreferredPartnerDownload.ResumeLayout(False)
            Me.WizardPageWizard_CSIPreferredPartnerTemplate.ResumeLayout(False)
            Me.WizardPageWizard_SelectDateRange.ResumeLayout(False)
            CType(Me.DateTimePickerDateRange_ToDate, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.DateTimePickerDateRange_FromDate, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents WizardPageWizard_SelectImportOptions As DevExpress.XtraWizard.WizardPage
        Protected WithEvents WizardPageWizard_ImportingPage As DevExpress.XtraWizard.WizardPage
        Protected WithEvents LabelImportingPage_ImportingStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Protected WithEvents ProgressBarImportingPage_Progress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Protected WithEvents WizardControlForm_Wizard As DevExpress.XtraWizard.WizardControl
        Friend WithEvents CheckBoxSelectImportOptions_AutoTrimOverflowData As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents ComboBoxSelectImportOptions_Template As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Protected WithEvents LabelSelectImportOptions_Template As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents CheckBoxForm_ColumnHeaders As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
        Friend WithEvents WizardPageWizard_SelectBank As DevExpress.XtraWizard.WizardPage
        Friend WithEvents ComboBoxSelectBank_Bank As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Protected WithEvents LabelSelectBank_Bank As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents WizardPageWizard_SelectImportFiles As DevExpress.XtraWizard.WizardPage
        Friend WithEvents DataGridViewSelectImportFiles_Files As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
        Protected WithEvents LabelImportingPage_OverallImportingStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Protected WithEvents ProgressBarImportingPage_OverallProgress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Private WithEvents CompletionWizardPageForm_CompletionPage As DevExpress.XtraWizard.CompletionWizardPage
        Private WithEvents WelcomeWizardPageForm_WelcomePage As DevExpress.XtraWizard.WelcomeWizardPage
        Friend WithEvents ButtonSelectImportFiles_RemoveFiles As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonSelectImportFiles_SelectFiles As AdvantageFramework.WinForm.Presentation.Controls.Button
        Friend WithEvents ButtonSelectImportFiles_LoadDefaultDirectory As AdvantageFramework.WinForm.Presentation.Controls.Button
        Protected WithEvents LabelSelectImportFiles_Notice As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents WizardPageWizard_CSIPreferredPartnerDownload As DevExpress.XtraWizard.WizardPage
        Friend WithEvents ProgressBarCSIPreferredPartnerDownload_Progress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Friend WithEvents TextBoxCSIPreferredPartnerDownload_Log As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents WizardPageWizard_CSIPreferredPartnerTemplate As DevExpress.XtraWizard.WizardPage
        Friend WithEvents ComboBoxCSIPreferredPartnerTemplate_Template As AdvantageFramework.WinForm.Presentation.Controls.ComboBox
        Protected WithEvents LabelCSIPreferredPartnerTemplate_Template As AdvantageFramework.WinForm.Presentation.Controls.Label
        Friend WithEvents WizardPageWizard_SelectDateRange As DevExpress.XtraWizard.WizardPage
        Protected WithEvents LabelSelectDateRange_From As WinForm.Presentation.Controls.Label
        Protected WithEvents LabelSelectDateRange_To As WinForm.Presentation.Controls.Label
        Friend WithEvents DateTimePickerDateRange_ToDate As WinForm.Presentation.Controls.DateTimePicker
        Friend WithEvents DateTimePickerDateRange_FromDate As WinForm.Presentation.Controls.DateTimePicker
    End Class

End Namespace