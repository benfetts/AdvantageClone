Namespace Security.Presentation

    Public Class SecuritySetupAssistantForm

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Actions
            Save
            Validate
            AddDomain
        End Enum

#End Region

#Region " Variables "

        Private WithEvents _BackgroundWorker As System.ComponentModel.BackgroundWorker = Nothing
        Private _Action As SecuritySetupAssistantForm.Actions = Actions.Save
        Private _DomainName As String = ""
        Private _SelectedRowHandlesList As Generic.List(Of Integer) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadUsers()

            'objects
            Dim SecurityUsersList As Generic.List(Of AdvantageFramework.Security.Database.Classes.SecurityUser) = Nothing
            Dim HasValidSQLUser As Boolean = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                SecurityUsersList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.SecurityUser)

                For Each User In AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext).ToList

                    'HasValidSQLUser = (AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, User.UserName) IsNot Nothing)

                    SecurityUsersList.Add(New AdvantageFramework.Security.Database.Classes.SecurityUser(User))

                Next

                DataGridViewForm_Users.DataSource = SecurityUsersList

                DataGridViewForm_Users.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub CloseGridEditorAndSaveValueToDataSource()

            If DataGridViewForm_Users.CurrentView.PostEditor() Then

                DataGridViewForm_Users.CurrentView.UpdateCurrentRow()

            End If

            DataGridViewForm_Users.CurrentView.RefreshData()

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim SecuritySetupAssistantForm As AdvantageFramework.Security.Presentation.SecuritySetupAssistantForm = Nothing

            SecuritySetupAssistantForm = New AdvantageFramework.Security.Presentation.SecuritySetupAssistantForm()

            SecuritySetupAssistantForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub SecuritySetupAssistantForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            Me.Text = Me.Session.DatabaseName

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Validate.Image = AdvantageFramework.My.Resources.ValidateImage
            ButtonItemActions_AddDomain.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            LoadUsers()

            ButtonItemActions_AddDomain.Enabled = DataGridViewForm_Users.HasASelectedRow

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Refresh.Click

            CloseGridEditorAndSaveValueToDataSource()

            LoadUsers()

            ButtonItemActions_AddDomain.Enabled = DataGridViewForm_Users.HasASelectedRow

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Save.Click

            CloseGridEditorAndSaveValueToDataSource()

            TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetupProgressBar(0, DataGridViewForm_Users.CurrentView.RowCount, 0)

            _Action = Actions.Save

            _BackgroundWorker = New System.ComponentModel.BackgroundWorker

            _BackgroundWorker.WorkerReportsProgress = True

            _BackgroundWorker.RunWorkerAsync(DataGridViewForm_Users.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Security.Database.Classes.SecurityUser).ToList)

            Me.ShowWaitForm("Processing...")

        End Sub
        Private Sub ButtonItemActions_AddDomain_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_AddDomain.Click

            'objects
            Dim DomainName As String = ""

            CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Add Domain", "Enter a domain:", "", DomainName) = Windows.Forms.DialogResult.OK Then

                If DomainName IsNot Nothing AndAlso DomainName <> "" Then

                    TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetupProgressBar(0, DataGridViewForm_Users.CurrentView.SelectedRowsCount, 0)

                    _Action = Actions.AddDomain
                    _DomainName = DomainName
                    _SelectedRowHandlesList = DataGridViewForm_Users.CurrentView.GetSelectedRows.ToList

                    _BackgroundWorker = New System.ComponentModel.BackgroundWorker

                    _BackgroundWorker.WorkerReportsProgress = True

                    _BackgroundWorker.RunWorkerAsync(DataGridViewForm_Users.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Security.Database.Classes.SecurityUser).ToList)

                    Me.ShowWaitForm("Processing...")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Domain name cannot be left blank.")

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Validate_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Validate.Click

            CloseGridEditorAndSaveValueToDataSource()

            TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetupProgressBar(0, DataGridViewForm_Users.CurrentView.RowCount, 0)

            _Action = Actions.Validate

            _BackgroundWorker = New System.ComponentModel.BackgroundWorker

            _BackgroundWorker.WorkerReportsProgress = True

            _BackgroundWorker.RunWorkerAsync(DataGridViewForm_Users.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Security.Database.Classes.SecurityUser).ToList)

            Me.ShowWaitForm("Processing...")

        End Sub
        Private Sub _BackgroundWorker_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _BackgroundWorker.DoWork

            'objects
            Dim SecurityUsersList As Generic.List(Of AdvantageFramework.Security.Database.Classes.SecurityUser) = Nothing
            Dim ProgressValue As Integer = 1

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Try

                        SecurityUsersList = e.Argument

                    Catch ex As Exception
                        SecurityUsersList = Nothing
                    End Try

                    If SecurityUsersList IsNot Nothing Then

                        For Each SecurityUser In SecurityUsersList

                            If _Action = Actions.Save Then

                                Try

                                    SecurityDbContext.Database.ExecuteSqlCommand("UPDATE dbo.SEC_USER SET USER_CODE = '" & SecurityUser.UserCode & "', USER_NAME = '" & SecurityUser.UserName & "', SID = '" & SecurityUser.SID & "' WHERE SEC_USER_ID = " & SecurityUser.ID)

                                Catch ex As Exception

                                End Try

                            ElseIf _Action = Actions.Validate Then

                                SecurityUser.UserNameChanged()

                            ElseIf _Action = Actions.AddDomain Then

                                If _SelectedRowHandlesList.Contains(SecurityUsersList.IndexOf(SecurityUser)) Then

                                    If String.IsNullOrWhiteSpace(SecurityUser.UserName) = False AndAlso SecurityUser.UserName.Contains("\") Then

                                        SecurityUser.UserName = SecurityUser.UserName.Substring(SecurityUser.UserName.IndexOf("\") + 1)

                                    End If

                                    SecurityUser.UserName = AdvantageFramework.StringUtilities.AppendTrailingCharacter(_DomainName, "\") & SecurityUser.UserName

                                End If

                            End If

                            ProgressValue += 1

                            _BackgroundWorker.ReportProgress(ProgressValue)

                        Next

                    End If

                End Using

            Catch ex As Exception
                e.Cancel = True
            End Try

            e.Result = SecurityUsersList

        End Sub
        Private Sub _BackgroundWorker_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles _BackgroundWorker.ProgressChanged

            TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).SetProgressBarValue(e.ProgressPercentage)

        End Sub
        Private Sub _BackgroundWorker_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _BackgroundWorker.RunWorkerCompleted

            'objects
            Dim SecurityUsersList As Generic.List(Of AdvantageFramework.Security.Database.Classes.SecurityUser) = Nothing

            Try

                If e.Cancelled Then

                    AdvantageFramework.WinForm.MessageBox.Show("Failed " & AdvantageFramework.StringUtilities.GetNameAsWords(_Action.ToString) & ".")

                Else

                    SecurityUsersList = e.Result

                    DataGridViewForm_Users.DataSource = SecurityUsersList

                    DataGridViewForm_Users.CurrentView.BestFitColumns()

                    ButtonItemActions_AddDomain.Enabled = DataGridViewForm_Users.HasASelectedRow

                End If

            Catch ex As Exception

            End Try

            TryCast(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CloseProgressBar()

            Me.CloseWaitForm()

        End Sub
        Private Sub DataGridViewForm_Users_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_Users.SelectionChangedEvent

            ButtonItemActions_AddDomain.Enabled = DataGridViewForm_Users.HasASelectedRow

        End Sub
        Private Sub DataGridViewForm_Users_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewForm_Users.ColumnValueChangedEvent

            DataGridViewForm_Users.CurrentView.RefreshData()

        End Sub

#End Region

#End Region

    End Class

End Namespace