Namespace Maintenance.Accounting.Presentation

    Public Class EmployeeImportWizardDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub ImportingProgressUpdate(ByVal ProgressValue As Integer)

            ProgressBarImportingPage_Progress.Value = ProgressValue

            ProgressBarImportingPage_Progress.Refresh()

        End Sub
        Private Sub SetupImportingProgress(ByVal MinValue As Integer, ByVal MaxValue As Integer, ByVal Value As Integer)

            ProgressBarImportingPage_Progress.Minimum = MinValue
            ProgressBarImportingPage_Progress.Maximum = MaxValue
            ProgressBarImportingPage_Progress.Value = Value

            ProgressBarImportingPage_Progress.Refresh()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowWizardDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeImportWizardDialog As EmployeeImportWizardDialog = Nothing

            EmployeeImportWizardDialog = New EmployeeImportWizardDialog

            ShowWizardDialog = EmployeeImportWizardDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeImportWizardDialog_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

            RemoveHandler AdvantageFramework.Importing.ImportingProgressUpdateEvent, AddressOf ImportingProgressUpdate
            RemoveHandler AdvantageFramework.Importing.SetupImportingProgressEvent, AddressOf SetupImportingProgress

        End Sub
        Private Sub EmployeeImportWizardDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            AddHandler AdvantageFramework.Importing.ImportingProgressUpdateEvent, AddressOf ImportingProgressUpdate
            AddHandler AdvantageFramework.Importing.SetupImportingProgressEvent, AddressOf SetupImportingProgress

            TextBoxSelectImportOptions_ImportFile.SetAgencyImportPath("Employee", True)

            WizardControlForm_Wizard.Image = AdvantageFramework.My.Resources.AdvantageLogoImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If DbContext.ImportEmployeeStagings.Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please complete the pending employee import records prior to importing a new file.")
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub WizardControlForm_Wizard_NextClick(ByVal sender As Object, ByVal e As DevExpress.XtraWizard.WizardCommandButtonClickEventArgs) Handles WizardControlForm_Wizard.NextClick

            'objects
            Dim CanContinue As Boolean = True
            Dim Message As String = ""

            If e.Page Is WizardPageWizard_SelectImportOptions Then

                If Me.Validator = False Then

                    CanContinue = False
                    TextBoxSelectImportOptions_ImportFile.Focus()

                End If

                If CanContinue Then

                    If AdvantageFramework.FileSystem.IsFileInUse(TextBoxSelectImportOptions_ImportFile.Text) Then

                        CanContinue = False
                        TextBoxSelectImportOptions_ImportFile.Focus()
                        AdvantageFramework.WinForm.MessageBox.Show("The file selected is currently in use.  Please close the file and click next.")

                    End If

                End If

                If CanContinue Then

                    If AdvantageFramework.Importing.CheckForStandardDefinitionFile(Importing.ImportType.Employee, TextBoxSelectImportOptions_ImportFile.Text) = False Then

                        CanContinue = False
                        TextBoxSelectImportOptions_ImportFile.Focus()
                        AdvantageFramework.WinForm.MessageBox.Show("The file selected does not meet the file specifications.")

                    End If

                End If

            End If

            e.Handled = Not CanContinue

        End Sub
        Private Sub WizardControlForm_Wizard_FinishClick(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.FinishClick

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub WizardControlForm_Wizard_CancelClick(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles WizardControlForm_Wizard.CancelClick

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        End Sub
        Private Sub WizardControlForm_Wizard_SelectedPageChanged(ByVal sender As Object, ByVal e As DevExpress.XtraWizard.WizardPageChangedEventArgs) Handles WizardControlForm_Wizard.SelectedPageChanged

            'objects
            Dim FileName As String = ""
            Dim FileDirectory As String = ""

            If e.Direction = DevExpress.XtraWizard.Direction.Forward Then

                If e.Page Is WizardPageWizard_ImportingPage Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        WizardPageWizard_ImportingPage.AllowNext = False

                        If AdvantageFramework.Importing.ImportStandardDefinitionFile(Me.Session, Importing.ImportType.Employee, TextBoxSelectImportOptions_ImportFile.Text, CheckBoxSelectImportOptions_AutoTrimOverflowData.Checked) Then

                            FileDirectory = TextBoxSelectImportOptions_ImportFile.Text

                            FileName = My.Computer.FileSystem.GetFileInfo(TextBoxSelectImportOptions_ImportFile.Text).Name

                            FileDirectory = FileDirectory.Replace(FileName, "")

                            If Debugger.IsAttached = False Then

                                FileName = FileName.Replace(".csv", "_" & DbContext.UserCode & "_" & Now.ToFileTime & ".csv.old")

                                My.Computer.FileSystem.RenameFile(TextBoxSelectImportOptions_ImportFile.Text, FileName)

                            End If

                            CompletionWizardPageForm_CompletionPage.FinishText = "The wizard has been successfully completed."

                        Else

                            CompletionWizardPageForm_CompletionPage.FinishText = "The wizard completed with some errors."

                        End If

                        LabelImportingPage_ImportingStatus.Text = "Importing File Completed... Click Next to continue..."

                        WizardPageWizard_ImportingPage.AllowNext = True

                    End Using

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
