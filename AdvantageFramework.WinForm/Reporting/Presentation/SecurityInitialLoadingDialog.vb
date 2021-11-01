Namespace Reporting.Presentation

    Public Class SecurityInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsUserDefinedReport As Boolean = False
        Private _AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvancedReportWriterReports.JobDetailAnalysisV1Summary
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Private _DynamicReport As AdvantageFramework.Reporting.DynamicReports = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary
            _DynamicReport = DynamicReport

        End Sub
        Private Sub LoadGroups()

            Using DbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DataGridViewSelectGroups_Groups.DataSource = (From Entity In AdvantageFramework.Security.Database.Procedures.Group.Load(DbContext)
                                                              Select [Code] = Entity.ID,
                                                                     [Name] = Entity.Description).ToList

                DataGridViewSelectGroups_Groups.CurrentView.BestFitColumns()

            End Using

        End Sub
        Private Sub LoadUsers()

            Dim SelectedGroups As Generic.List(Of Integer) = Nothing
            Dim GroupList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Group) = Nothing
            Dim Group As AdvantageFramework.Security.Database.Entities.Group = Nothing
            Dim GroupUsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim AllGroupUsersList As Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.User)) = Nothing
            Dim AddGroupUser As Boolean = True
            Dim FinalGroupUsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
            Dim UsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing

            Using DbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If RadioButtonSelectGroups_AllGroups.Checked = True OrElse DataGridViewSelectGroups_Groups.HasASelectedRow = False Then

                    If CheckBoxFrom_IncludeTerminated.Checked = False Then

                        DataGridViewSelectUsers_Users.DataSource = (From Entity In AdvantageFramework.Security.Database.Procedures.User.Load(DbContext).Include("Employee").ToList
                                                                    Where Entity.Employee.TerminationDate Is Nothing
                                                                    Select [Code] = Entity.ID,
                                                                           [Description] = Entity.UserCode).ToList

                    Else

                        DataGridViewSelectUsers_Users.DataSource = (From Entity In AdvantageFramework.Security.Database.Procedures.User.Load(DbContext)
                                                                    Select [Code] = Entity.ID,
                                                                           [Description] = Entity.UserCode).ToList

                    End If

                Else

                    If RadioButtonSelectGroups_ChooseGroups.Checked Then

                        SelectedGroups = DataGridViewSelectGroups_Groups.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                        GroupList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

                        For Each groupid In SelectedGroups

                            Group = AdvantageFramework.Security.Database.Procedures.Group.LoadByGroupID(DbContext, groupid)

                            If Group IsNot Nothing Then
                                GroupList.Add(Group)
                            End If

                        Next

                        If GroupList IsNot Nothing AndAlso GroupList.Count > 0 Then

                            AllGroupUsersList = New Generic.List(Of Generic.List(Of AdvantageFramework.Security.Database.Entities.User))

                            For Each Group In GroupList

                                GroupUsersList = Group.GroupUsers.Select(Function(GroupUser) GroupUser.User).ToList

                                AllGroupUsersList.Add(GroupUsersList)

                            Next

                            FinalGroupUsersList = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)

                            UsersList = AdvantageFramework.Security.Database.Procedures.User.Load(DbContext).Include("GroupUsers").Include("Employee").Include("Employee.Department").Include("Employee.Office").ToList

                            For Each User In UsersList

                                AddGroupUser = True

                                For Each GroupUsersList In AllGroupUsersList

                                    If GroupUsersList.Any(Function(GroupUser) GroupUser.ID = User.ID) = False Then

                                        AddGroupUser = False

                                    Else

                                        AddGroupUser = True
                                        Exit For

                                    End If

                                Next

                                If AddGroupUser Then

                                    If CheckBoxFrom_IncludeTerminated.Checked = False AndAlso User.Employee.TerminationDate Is Nothing Then
                                        FinalGroupUsersList.Add(User)
                                    ElseIf CheckBoxFrom_IncludeTerminated.Checked = True Then
                                        FinalGroupUsersList.Add(User)
                                    End If

                                End If

                            Next
                        End If


                        DataGridViewSelectUsers_Users.DataSource = (From Entity In FinalGroupUsersList
                                                                    Select [Code] = Entity.ID,
                                                                           [Description] = Entity.UserCode).ToList


                    End If


                End If


                DataGridViewSelectUsers_Users.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim SecurityInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.SecurityInitialLoadingDialog = Nothing

            SecurityInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.SecurityInitialLoadingDialog(DynamicReport, ParameterDictionary)

            ShowFormDialog = SecurityInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = SecurityInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub SecurityInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            TabControlForm_JDA.SelectedTab = TabItemJDA_VersionAndOptionsTab

            DataGridViewSelectGroups_Groups.ShowSelectDeselectAllButtons = True
            DataGridViewSelectGroups_Groups.MultiSelect = True

            DataGridViewSelectUsers_Users.ShowSelectDeselectAllButtons = True
            DataGridViewSelectUsers_Users.MultiSelect = True

            If _DynamicReport = DynamicReports.SecurityGroupModuleAccess Or _DynamicReport = DynamicReports.SecurityGroupSettings Then
                TabItemJDA_SelectUsersTab.Visible = False
                CheckBoxFrom_IncludeTerminated.Enabled = False
            End If

            If _DynamicReport = DynamicReports.SecurityUserModuleAccess Or _DynamicReport = DynamicReports.SecurityUserSettings Then
                TabItemJDA_SelectGroupsTab.Visible = False
            End If

            If _DynamicReport = DynamicReports.SecurityGroupSettings Or _DynamicReport = DynamicReports.SecurityUserSettings Or _DynamicReport = DynamicReports.SecurityGroupUserSettings Then
                CheckBoxForm_ShowOnlyAccessibleModules.Enabled = False
            End If


        End Sub
        Private Sub SecurityInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub RadioButtonSelectGroups_AllGroups_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectGroups_AllGroups.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectGroups_AllGroups.Checked Then

                    DataGridViewSelectGroups_Groups.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectGroups_ChooseGroups_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectGroups_ChooseGroups.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectGroups_ChooseGroups.Checked Then

                    If DataGridViewSelectGroups_Groups.HasRows = False Then

                        LoadGroups()

                    End If

                    DataGridViewSelectGroups_Groups.Enabled = True

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectUsers_AllUsers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonSelectUsers_AllUsers.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectUsers_AllUsers.Checked Then

                    DataGridViewSelectUsers_Users.Enabled = False

                End If

            End If

        End Sub
        Private Sub RadioButtonSelectUsers_ChooseUsers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectUsers_ChooseUsers.CheckedChanged

            If Me.FormShown Then

                If RadioButtonSelectUsers_ChooseUsers.Checked Then

                    'If DataGridViewSelectUsers_Users.HasRows = False Then

                    LoadUsers()

                    'End If

                    DataGridViewSelectUsers_Users.Enabled = True

                End If

            End If

        End Sub
        Private Sub ButtonForm_View_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_View.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.ShowOnlyAccessibleModules.ToString) = CheckBoxForm_ShowOnlyAccessibleModules.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.IncludeTerminatedEmployees.ToString) = CheckBoxFrom_IncludeTerminated.Checked

                If RadioButtonSelectGroups_AllGroups.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.SelectedGroups.ToString) = Nothing

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.SelectedGroups.ToString) = DataGridViewSelectGroups_Groups.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                End If

                If RadioButtonSelectUsers_AllUsers.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.SelectedUsers.ToString) = Nothing

                Else

                    _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.SelectedUsers.ToString) = DataGridViewSelectUsers_Users.GetAllSelectedRowsBookmarkValues(0).OfType(Of Integer).ToList

                End If



                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

        Private Sub CheckBoxFrom_IncludeTerminated_CheckValueChanged(sender As Object, e As EventArgs) Handles CheckBoxFrom_IncludeTerminated.CheckValueChanged
            If RadioButtonSelectUsers_ChooseUsers.Checked Then
                LoadUsers()
            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
