Partial Public Class BackupDatabasePage
    Inherits BaseWizardPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _BackupFolder As String = String.Empty

#End Region

#Region " Properties "

    Public Property BackupFolder As String
        Get
            BackupFolder = _BackupFolder
        End Get
        Set(value As String)
            _BackupFolder = value
        End Set
    End Property

#End Region

#Region " Methods "

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Sub BackupDatabase()

        SimpleButtonForm_Yes.PerformClick()

    End Sub
    Public Sub DoNotBackupDatabase()

        SimpleButtonForm_No.PerformClick()

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub SimpleButtonForm_Yes_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_Yes.Click

        Dim IsDatabaseBackupComplete As Boolean = False
        Dim FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog = Nothing
        Dim Folder As String = String.Empty
        Dim ValidFolder As Boolean = False
        Dim StreamWriter As System.IO.StreamWriter = Nothing
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        Dim ErrorMessage As String = String.Empty
        Dim ShowFolderBrowserDialog As Boolean = True

        If String.IsNullOrWhiteSpace(_BackupFolder) = False Then

            If My.Computer.FileSystem.DirectoryExists(_BackupFolder) Then

                Folder = _BackupFolder
                ShowFolderBrowserDialog = False

            End If

        End If

        If ShowFolderBrowserDialog AndAlso CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode = False Then

            FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()

            If FolderBrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                Folder = FolderBrowserDialog.SelectedPath

            End If

        End If

        If String.IsNullOrWhiteSpace(Folder) = False Then

            If My.Computer.FileSystem.DirectoryExists(Folder) Then

                OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

                Try

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                        Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Folder, "\")

                        If My.Computer.FileSystem.FileExists(Folder & Me.WizardViewModel.WizardInputs.Database & "_6700700_upgrade.bak") Then

                            My.Computer.FileSystem.DeleteFile(Folder & Me.WizardViewModel.WizardInputs.Database & "_6700700_upgrade.bak")

                        End If

                        StreamWriter = New System.IO.StreamWriter(Folder & Me.WizardViewModel.WizardInputs.Database & "_6700700_upgrade.bak", False)

                        StreamWriter.Close()

                        StreamWriter.Dispose()

                        StreamWriter = Nothing

                        SecurityDbContext.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction, String.Format("BACKUP DATABASE {0} TO DISK='{1}'", Me.WizardViewModel.WizardInputs.Database, Folder & Me.WizardViewModel.WizardInputs.Database & "_6700700_upgrade.bak"))

                        IsDatabaseBackupComplete = True

                    End Using

                Catch ex As Exception

                    IsDatabaseBackupComplete = False

                    ErrorMessage = ex.Message

                    If ex.InnerException IsNot Nothing Then

                        ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        If ex.InnerException.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.InnerException.Message

                        End If

                    End If

                End Try

                DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

                If IsDatabaseBackupComplete = False Then

                    If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                        CType(Me.WizardViewModel, WizardViewModel).AddToErrors("Backup", "Failed to backup database." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                    Else

                        DevExpress.XtraEditors.XtraMessageBox.Show("Failed to backup database." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                    End If

                End If

            End If

        Else

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("Backup", "Please select a valid folder.")

            Else

                DevExpress.XtraEditors.XtraMessageBox.Show("Please select a valid folder.")

            End If

        End If

        If IsDatabaseBackupComplete Then

            CType(PageViewModel, BackupDatabasePageViewModel).SetIsComplete(True)

            Me.WizardViewModel.PageCompleted()

        Else

            CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
            CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

            CType(PageViewModel, BackupDatabasePageViewModel).SetIsComplete(True)

            Me.WizardViewModel.GoToPage(10)

        End If

    End Sub
    Private Sub SimpleButtonForm_No_Click(sender As Object, e As EventArgs) Handles SimpleButtonForm_No.Click

        CType(PageViewModel, BackupDatabasePageViewModel).SetIsComplete(True)

        Me.WizardViewModel.PageCompleted()

    End Sub

#End Region

#End Region

End Class
