Namespace Maintenance.Accounting.Presentation

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class EmployeeImportWizardDialog
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EmployeeImportWizardDialog))
            Me.CompletionWizardPageForm_CompletionPage = New DevExpress.XtraWizard.CompletionWizardPage()
            Me.WelcomeWizardPageForm_WelcomePage = New DevExpress.XtraWizard.WelcomeWizardPage()
            Me.WizardControlForm_Wizard = New DevExpress.XtraWizard.WizardControl()
            Me.WizardPageWizard_SelectImportOptions = New DevExpress.XtraWizard.WizardPage()
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData = New AdvantageFramework.WinForm.Presentation.Controls.CheckBox()
            Me.TextBoxSelectImportOptions_ImportFile = New AdvantageFramework.WinForm.Presentation.Controls.TextBox()
            Me.LabelSelectImportOptions_ImportFile = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.WizardPageWizard_ImportingPage = New DevExpress.XtraWizard.WizardPage()
            Me.LabelImportingPage_ImportingStatus = New AdvantageFramework.WinForm.Presentation.Controls.Label()
            Me.ProgressBarImportingPage_Progress = New AdvantageFramework.WinForm.Presentation.Controls.ProgressBar()
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.WizardControlForm_Wizard.SuspendLayout()
            Me.WizardPageWizard_SelectImportOptions.SuspendLayout()
            Me.WizardPageWizard_ImportingPage.SuspendLayout()
            Me.SuspendLayout()
            '
            'DefaultLookAndFeelOffice2010Blue
            '
            Me.DefaultLookAndFeel.LookAndFeel.SkinName = "Office 2016 Colorful"
            '
            'CompletionWizardPageForm_CompletionPage
            '
            Me.CompletionWizardPageForm_CompletionPage.AllowBack = False
            Me.CompletionWizardPageForm_CompletionPage.AllowCancel = False
            Me.CompletionWizardPageForm_CompletionPage.Name = "CompletionWizardPageForm_CompletionPage"
            Me.CompletionWizardPageForm_CompletionPage.Size = New System.Drawing.Size(443, 190)
            Me.CompletionWizardPageForm_CompletionPage.Text = "Employee Import Wizard Completed"
            '
            'WelcomeWizardPageForm_WelcomePage
            '
            Me.WelcomeWizardPageForm_WelcomePage.AllowBack = False
            Me.WelcomeWizardPageForm_WelcomePage.IntroductionText = "This wizard will guide help guide you through the process of importing a file int" &
        "o the Advantage system."
            Me.WelcomeWizardPageForm_WelcomePage.Name = "WelcomeWizardPageForm_WelcomePage"
            Me.WelcomeWizardPageForm_WelcomePage.Size = New System.Drawing.Size(443, 190)
            Me.WelcomeWizardPageForm_WelcomePage.Text = "Welcome to the Employee Import Wizard"
            '
            'WizardControlForm_Wizard
            '
            Me.WizardControlForm_Wizard.Controls.Add(Me.WelcomeWizardPageForm_WelcomePage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_SelectImportOptions)
            Me.WizardControlForm_Wizard.Controls.Add(Me.WizardPageWizard_ImportingPage)
            Me.WizardControlForm_Wizard.Controls.Add(Me.CompletionWizardPageForm_CompletionPage)
            Me.WizardControlForm_Wizard.Dock = System.Windows.Forms.DockStyle.Fill
            Me.WizardControlForm_Wizard.ImageLayout = System.Windows.Forms.ImageLayout.Zoom
            Me.WizardControlForm_Wizard.ImageWidth = 200
            Me.WizardControlForm_Wizard.Location = New System.Drawing.Point(0, 0)
            Me.WizardControlForm_Wizard.LookAndFeel.SkinName = "Office 2016 Colorful"
            Me.WizardControlForm_Wizard.LookAndFeel.UseDefaultLookAndFeel = False
            Me.WizardControlForm_Wizard.Name = "WizardControlForm_Wizard"
            Me.WizardControlForm_Wizard.NavigationMode = DevExpress.XtraWizard.NavigationMode.Stacked
            Me.WizardControlForm_Wizard.Pages.AddRange(New DevExpress.XtraWizard.BaseWizardPage() {Me.WelcomeWizardPageForm_WelcomePage, Me.WizardPageWizard_SelectImportOptions, Me.WizardPageWizard_ImportingPage, Me.CompletionWizardPageForm_CompletionPage})
            Me.WizardControlForm_Wizard.ShowHeaderImage = True
            Me.WizardControlForm_Wizard.Size = New System.Drawing.Size(675, 323)
            Me.WizardControlForm_Wizard.Text = ""
            '
            'WizardPageWizard_SelectImportOptions
            '
            Me.WizardPageWizard_SelectImportOptions.Controls.Add(Me.CheckBoxSelectImportOptions_AutoTrimOverflowData)
            Me.WizardPageWizard_SelectImportOptions.Controls.Add(Me.TextBoxSelectImportOptions_ImportFile)
            Me.WizardPageWizard_SelectImportOptions.Controls.Add(Me.LabelSelectImportOptions_ImportFile)
            Me.WizardPageWizard_SelectImportOptions.DescriptionText = ""
            Me.WizardPageWizard_SelectImportOptions.Name = "WizardPageWizard_SelectImportOptions"
            Me.WizardPageWizard_SelectImportOptions.Size = New System.Drawing.Size(643, 178)
            Me.WizardPageWizard_SelectImportOptions.Text = "Select a file to import"
            '
            'CheckBoxSelectImportOptions_AutoTrimOverflowData
            '
            '
            '
            '
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.BackgroundStyle.Class = ""
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Checked = True
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.CheckState = System.Windows.Forms.CheckState.Checked
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.CheckValue = "Y"
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Location = New System.Drawing.Point(70, 93)
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Name = "CheckBoxSelectImportOptions_AutoTrimOverflowData"
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Size = New System.Drawing.Size(539, 19)
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.TabIndex = 4
            Me.CheckBoxSelectImportOptions_AutoTrimOverflowData.Text = "Auto Trim Overflow Data"
            '
            'TextBoxSelectImportOptions_ImportFile
            '
            Me.TextBoxSelectImportOptions_ImportFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            '
            '
            '
            Me.TextBoxSelectImportOptions_ImportFile.Border.Class = "TextBoxBorder"
            Me.TextBoxSelectImportOptions_ImportFile.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.TextBoxSelectImportOptions_ImportFile.ButtonCustom.Visible = True
            Me.TextBoxSelectImportOptions_ImportFile.ControlType = AdvantageFramework.WinForm.Presentation.Controls.TextBox.Type.File
            Me.TextBoxSelectImportOptions_ImportFile.FileFilter = AdvantageFramework.FileSystem.Methods.FileFilters.CSV
            Me.TextBoxSelectImportOptions_ImportFile.FocusHighlightEnabled = True
            Me.TextBoxSelectImportOptions_ImportFile.Location = New System.Drawing.Point(70, 67)
            Me.TextBoxSelectImportOptions_ImportFile.Name = "TextBoxSelectImportOptions_ImportFile"
            Me.TextBoxSelectImportOptions_ImportFile.Size = New System.Drawing.Size(539, 20)
            Me.TextBoxSelectImportOptions_ImportFile.TabIndex = 3
            Me.TextBoxSelectImportOptions_ImportFile.TabOnEnter = True
            '
            'LabelSelectImportOptions_ImportFile
            '
            Me.LabelSelectImportOptions_ImportFile.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelSelectImportOptions_ImportFile.BackgroundStyle.Class = ""
            Me.LabelSelectImportOptions_ImportFile.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelSelectImportOptions_ImportFile.Location = New System.Drawing.Point(3, 67)
            Me.LabelSelectImportOptions_ImportFile.Name = "LabelSelectImportOptions_ImportFile"
            Me.LabelSelectImportOptions_ImportFile.Size = New System.Drawing.Size(61, 20)
            Me.LabelSelectImportOptions_ImportFile.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.LabelSelectImportOptions_ImportFile.TabIndex = 2
            Me.LabelSelectImportOptions_ImportFile.Text = "Import File:"
            '
            'WizardPageWizard_ImportingPage
            '
            Me.WizardPageWizard_ImportingPage.AllowBack = False
            Me.WizardPageWizard_ImportingPage.AllowCancel = False
            Me.WizardPageWizard_ImportingPage.Controls.Add(Me.LabelImportingPage_ImportingStatus)
            Me.WizardPageWizard_ImportingPage.Controls.Add(Me.ProgressBarImportingPage_Progress)
            Me.WizardPageWizard_ImportingPage.DescriptionText = ""
            Me.WizardPageWizard_ImportingPage.Name = "WizardPageWizard_ImportingPage"
            Me.WizardPageWizard_ImportingPage.Size = New System.Drawing.Size(643, 178)
            Me.WizardPageWizard_ImportingPage.Text = "Importing File...."
            '
            'LabelImportingPage_ImportingStatus
            '
            Me.LabelImportingPage_ImportingStatus.BackColor = System.Drawing.Color.White
            '
            '
            '
            Me.LabelImportingPage_ImportingStatus.BackgroundStyle.Class = ""
            Me.LabelImportingPage_ImportingStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.LabelImportingPage_ImportingStatus.Location = New System.Drawing.Point(3, 66)
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
            Me.ProgressBarImportingPage_Progress.BackgroundStyle.Class = ""
            Me.ProgressBarImportingPage_Progress.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
            Me.ProgressBarImportingPage_Progress.Location = New System.Drawing.Point(3, 92)
            Me.ProgressBarImportingPage_Progress.Name = "ProgressBarImportingPage_Progress"
            Me.ProgressBarImportingPage_Progress.Size = New System.Drawing.Size(637, 20)
            Me.ProgressBarImportingPage_Progress.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.ProgressBarImportingPage_Progress.TabIndex = 0
            '
            'EmployeeImportWizardDialog
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(675, 323)
            Me.Controls.Add(Me.WizardControlForm_Wizard)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "EmployeeImportWizardDialog"
            Me.Text = "Employee Import Wizard"
            CType(Me.ErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.WizardControlForm_Wizard, System.ComponentModel.ISupportInitialize).EndInit()
            Me.WizardControlForm_Wizard.ResumeLayout(False)
            Me.WizardPageWizard_SelectImportOptions.ResumeLayout(False)
            Me.WizardPageWizard_ImportingPage.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Protected WithEvents WizardPageWizard_SelectImportOptions As DevExpress.XtraWizard.WizardPage
        Protected WithEvents LabelSelectImportOptions_ImportFile As AdvantageFramework.WinForm.Presentation.Controls.Label
        Protected WithEvents WizardPageWizard_ImportingPage As DevExpress.XtraWizard.WizardPage
        Protected WithEvents LabelImportingPage_ImportingStatus As AdvantageFramework.WinForm.Presentation.Controls.Label
        Protected WithEvents ProgressBarImportingPage_Progress As AdvantageFramework.WinForm.Presentation.Controls.ProgressBar
        Protected WithEvents CompletionWizardPageForm_CompletionPage As DevExpress.XtraWizard.CompletionWizardPage
        Protected WithEvents WelcomeWizardPageForm_WelcomePage As DevExpress.XtraWizard.WelcomeWizardPage
        Protected WithEvents WizardControlForm_Wizard As DevExpress.XtraWizard.WizardControl
        Friend WithEvents TextBoxSelectImportOptions_ImportFile As AdvantageFramework.WinForm.Presentation.Controls.TextBox
        Friend WithEvents CheckBoxSelectImportOptions_AutoTrimOverflowData As AdvantageFramework.WinForm.Presentation.Controls.CheckBox
    End Class

End Namespace