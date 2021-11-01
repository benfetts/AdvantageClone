Namespace Security.Setup.Presentation

    Public Class UserDefinedReportAccessForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GroupUserDefinedReportAccessList As Generic.List(Of AdvantageFramework.Security.Database.Classes.GroupUserDefinedReportAccess) = Nothing
        Private _UserUserDefinedReportAccessList As Generic.List(Of AdvantageFramework.Security.Database.Classes.UserUserDefinedReportAccess) = Nothing
        Private _SelectedUserDefinedReportList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Public Sub LoadUserDefinedReports()

            'objects
            Dim AddUserDefinedReport As Boolean = False
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing
            Dim UserDefinedReportList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport) = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ButtonItemShowBy_All.Checked = False Then

                        UserDefinedReportList = New Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport)

                        For Each UserDefinedReport In AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Load(ReportingDbContext).ToList

                            AddUserDefinedReport = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess).Where(Function(UserUDRAccess) UserUDRAccess.UserDefinedReportID = UserDefinedReport.ID).Any

                            If AddUserDefinedReport = False Then

                                AddUserDefinedReport = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess).Where(Function(GroupUDRAccess) GroupUDRAccess.UserDefinedReportID = UserDefinedReport.ID).Any

                            End If

                            If AddUserDefinedReport = False AndAlso ButtonItemShowBy_AllBlocked.Checked Then

                                AddUserDefinedReport = True

                            ElseIf AddUserDefinedReport = False AndAlso ButtonItemShowBy_AllUnblocked.Checked Then

                                AddUserDefinedReport = False

                            Else

                                If ButtonItemShowBy_AllBlocked.Checked Then

                                    AddUserDefinedReport = Not SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess).Where(Function(UserUDRAccess) UserUDRAccess.UserDefinedReportID = UserDefinedReport.ID).Any(Function(UserUDRAccess) UserUDRAccess.IsBlocked = False)

                                Else

                                    AddUserDefinedReport = Not SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess).Where(Function(UserUDRAccess) UserUDRAccess.UserDefinedReportID = UserDefinedReport.ID).Any(Function(UserUDRAccess) UserUDRAccess.IsBlocked = True)

                                End If

                                If AddUserDefinedReport Then

                                    If ButtonItemShowBy_AllBlocked.Checked Then

                                        AddUserDefinedReport = Not SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess).Where(Function(GroupUDRAccess) GroupUDRAccess.UserDefinedReportID = UserDefinedReport.ID).Any(Function(GroupUDRAccess) GroupUDRAccess.IsBlocked = False)

                                    Else

                                        AddUserDefinedReport = Not SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess).Where(Function(GroupUDRAccess) GroupUDRAccess.UserDefinedReportID = UserDefinedReport.ID).Any(Function(GroupUDRAccess) GroupUDRAccess.IsBlocked = True)

                                    End If

                                End If

                            End If

                            If AddUserDefinedReport Then

                                UserDefinedReportList.Add(UserDefinedReport)

                            End If

                        Next

                    Else

                        UserDefinedReportList = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.Load(ReportingDbContext).ToList

                    End If

                    DataGridViewForm_UserDefinedReports.DataSource = UserDefinedReportList

                    DataGridViewForm_UserDefinedReports.CurrentView.BestFitColumns()

                End Using

            End Using

        End Sub
        Private Sub SetAllUserUserDefinedReportAccess(ByVal IsBlocked As Boolean)

            'objects
            Dim UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess = Nothing

            If _UserUserDefinedReportAccessList IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each UserDefinedReportID In DataGridViewForm_UserDefinedReports.GetAllRowsBookmarkValues

                        For Each UserUDRAccess In _UserUserDefinedReportAccessList

                            UserUserDefinedReportAccess = AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.LoadByUserDefinedReportIDAndUserID(SecurityDbContext, UserDefinedReportID, UserUDRAccess.UserID)

                            If UserUserDefinedReportAccess IsNot Nothing Then

                                UserUserDefinedReportAccess.IsBlocked = IsBlocked

                                AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.Update(SecurityDbContext, UserUserDefinedReportAccess)

                            Else

                                AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.Insert(SecurityDbContext, UserUDRAccess.UserID, UserDefinedReportID, IsBlocked, Nothing)

                            End If

                        Next

                    Next

                End Using

            End If

            RefreshUserAccessGrid()

        End Sub
        Private Sub SetAllGroupUserDefinedReportAccess(ByVal IsBlocked As Boolean)

            'objects
            Dim GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess = Nothing

            If _GroupUserDefinedReportAccessList IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each UserDefinedReportID In DataGridViewForm_UserDefinedReports.GetAllRowsBookmarkValues

                        For Each GroupUDRAccess In _GroupUserDefinedReportAccessList

                            GroupUserDefinedReportAccess = AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.LoadByUserDefinedReportIDAndGroupID(SecurityDbContext, UserDefinedReportID, GroupUDRAccess.GroupID)

                            If GroupUserDefinedReportAccess IsNot Nothing Then

                                GroupUserDefinedReportAccess.IsBlocked = IsBlocked

                                AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.Update(SecurityDbContext, GroupUserDefinedReportAccess)

                            Else

                                AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.Insert(SecurityDbContext, GroupUDRAccess.GroupID, UserDefinedReportID, IsBlocked, Nothing)

                            End If

                        Next

                    Next

                End Using

            End If

            RefreshGroupAccessGrids()

        End Sub
        Private Sub ClearGroupAccessList()

            For Each GroupUserDefinedReportAccess In _GroupUserDefinedReportAccessList

                GroupUserDefinedReportAccess.Clear()

            Next

        End Sub
        Private Sub RefreshGroupAccessGrids()

            ClearGroupAccessList()

            If DataGridViewForm_UserDefinedReports.HasASelectedRow Then

                For Each GroupUserDefinedReportAccess In _GroupUserDefinedReportAccessList

                    GroupUserDefinedReportAccess.SetUserDefinedReportAccess(Me.Session, _SelectedUserDefinedReportList)

                Next

                DataGridViewForm_GroupAccess.DataSource = _GroupUserDefinedReportAccessList

                If DataGridViewForm_GroupAccess.Columns("IsBlocked") IsNot Nothing Then

                    If DataGridViewForm_GroupAccess.Columns("IsBlocked").Visible = False Then

                        DataGridViewForm_GroupAccess.Columns("IsBlocked").Visible = True

                    End If

                End If

                DataGridViewForm_GroupAccess.CurrentView.BestFitColumns()

                ButtonItemGroupBlocking_BlockAll.Enabled = True
                ButtonItemGroupBlocking_UnblockAll.Enabled = True

            Else

                DataGridViewForm_GroupAccess.DataSource = _GroupUserDefinedReportAccessList

                If DataGridViewForm_GroupAccess.Columns("IsBlocked") IsNot Nothing Then

                    If DataGridViewForm_GroupAccess.Columns("IsBlocked").Visible Then

                        DataGridViewForm_GroupAccess.Columns("IsBlocked").Visible = False

                    End If

                End If

                DataGridViewForm_GroupAccess.CurrentView.BestFitColumns()

                ButtonItemGroupBlocking_BlockAll.Enabled = False
                ButtonItemGroupBlocking_UnblockAll.Enabled = False

            End If

        End Sub
        Private Sub LoadSelectedUserDefinedReportsList()

            'objects
            Dim UserDefinedReport As AdvantageFramework.Reporting.Database.Entities.UserDefinedReport = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _SelectedUserDefinedReportList = New Generic.List(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReport)

                For Each UserDefinedReportID In DataGridViewForm_UserDefinedReports.GetAllSelectedRowsBookmarkValues

                    UserDefinedReport = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReport.LoadByUserDefinedReportID(ReportingDbContext, UserDefinedReportID)

                    If UserDefinedReport IsNot Nothing Then

                        _SelectedUserDefinedReportList.Add(UserDefinedReport)

                    End If

                Next

            End Using

        End Sub
        Private Sub ClearUserAccessList()

            For Each UserUserDefinedReportAccess In _UserUserDefinedReportAccessList

                UserUserDefinedReportAccess.Clear()

            Next

        End Sub
        Private Sub RefreshUserAccessGrid()

            ClearUserAccessList()

            If DataGridViewForm_UserDefinedReports.HasASelectedRow Then

                For Each UserUserDefinedReportAccess In _UserUserDefinedReportAccessList

                    UserUserDefinedReportAccess.SetUserDefinedReportAccess(Me.Session, _SelectedUserDefinedReportList)

                Next

                DataGridViewForm_UserAccess.DataSource = _UserUserDefinedReportAccessList

                If DataGridViewForm_UserAccess.Columns("IsBlocked") IsNot Nothing Then

                    If DataGridViewForm_UserAccess.Columns("IsBlocked").Visible = False Then

                        DataGridViewForm_UserAccess.Columns("IsBlocked").Visible = True

                    End If

                End If

                DataGridViewForm_UserAccess.CurrentView.BestFitColumns()

                ButtonItemUserBlocking_BlockAll.Enabled = True
                ButtonItemUserBlocking_UnblockAll.Enabled = True

            Else

                DataGridViewForm_UserAccess.DataSource = _UserUserDefinedReportAccessList


                If DataGridViewForm_UserAccess.Columns("IsBlocked") IsNot Nothing Then

                    If DataGridViewForm_UserAccess.Columns("IsBlocked").Visible Then

                        DataGridViewForm_UserAccess.Columns("IsBlocked").Visible = False

                    End If

                End If

                DataGridViewForm_UserAccess.CurrentView.BestFitColumns()

                ButtonItemUserBlocking_BlockAll.Enabled = False
                ButtonItemUserBlocking_UnblockAll.Enabled = False

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim UserDefinedReportAccessForm As AdvantageFramework.Security.Setup.Presentation.UserDefinedReportAccessForm = Nothing

            UserDefinedReportAccessForm = New AdvantageFramework.Security.Setup.Presentation.UserDefinedReportAccessForm()

            UserDefinedReportAccessForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub UserDefinedReportAccessForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_UserDefinedReports.OptionsView.ShowFooter = False
            DataGridViewForm_GroupAccess.OptionsView.ShowFooter = False
            DataGridViewForm_UserAccess.OptionsView.ShowFooter = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _GroupUserDefinedReportAccessList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.GroupUserDefinedReportAccess)

                For Each Group In AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext)

                    _GroupUserDefinedReportAccessList.Add(New AdvantageFramework.Security.Database.Classes.GroupUserDefinedReportAccess(Group))

                Next

                _UserUserDefinedReportAccessList = New Generic.List(Of AdvantageFramework.Security.Database.Classes.UserUserDefinedReportAccess)

                For Each User In AdvantageFramework.Security.Database.Procedures.User.Load(SecurityDbContext)

                    _UserUserDefinedReportAccessList.Add(New AdvantageFramework.Security.Database.Classes.UserUserDefinedReportAccess(User))

                Next

                DataGridViewForm_GroupAccess.DataSource = _GroupUserDefinedReportAccessList
                DataGridViewForm_UserAccess.DataSource = _UserUserDefinedReportAccessList

                If DataGridViewForm_GroupAccess.Columns("IsBlocked") IsNot Nothing Then

                    If DataGridViewForm_GroupAccess.Columns("IsBlocked").Visible Then

                        DataGridViewForm_GroupAccess.Columns("IsBlocked").Visible = False

                    End If

                End If

                If DataGridViewForm_UserAccess.Columns("IsBlocked") IsNot Nothing Then

                    If DataGridViewForm_UserAccess.Columns("IsBlocked").Visible Then

                        DataGridViewForm_UserAccess.Columns("IsBlocked").Visible = False

                    End If

                End If

            End Using

            ButtonItemUserBlocking_BlockAll.Enabled = False
            ButtonItemUserBlocking_UnblockAll.Enabled = False

            ButtonItemGroupBlocking_BlockAll.Enabled = False
            ButtonItemGroupBlocking_UnblockAll.Enabled = False

        End Sub
        Private Sub UserDefinedReportAccessForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm()

            Try

                LoadUserDefinedReports()

                LoadSelectedUserDefinedReportsList()

                RefreshGroupAccessGrids()

                RefreshUserAccessGrid()

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()
            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewForm_UserDefinedReports_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_UserDefinedReports.SelectionChangedEvent

            If Me.HasLoaded AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                Me.ShowWaitForm()

                Try

                    LoadSelectedUserDefinedReportsList()

                    RefreshGroupAccessGrids()

                    RefreshUserAccessGrid()

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_GroupAccess_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_GroupAccess.CellValueChangingEvent

            'objects
            Dim GroupUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.GroupUserDefinedReportAccess = Nothing
            Dim GroupUDRAccess As AdvantageFramework.Security.Database.Classes.GroupUserDefinedReportAccess = Nothing

            GroupUDRAccess = DataGridViewForm_GroupAccess.CurrentView.GetRow(e.RowHandle)

            If GroupUDRAccess IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each UserDefinedReportID In DataGridViewForm_UserDefinedReports.GetAllSelectedRowsBookmarkValues

                        GroupUserDefinedReportAccess = AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.LoadByUserDefinedReportIDAndGroupID(SecurityDbContext, UserDefinedReportID, GroupUDRAccess.GroupID)

                        If GroupUserDefinedReportAccess IsNot Nothing Then

                            GroupUserDefinedReportAccess.IsBlocked = e.Value

                            AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.Update(SecurityDbContext, GroupUserDefinedReportAccess)

                        Else

                            AdvantageFramework.Security.Database.Procedures.GroupUserDefinedReportAccess.Insert(SecurityDbContext, GroupUDRAccess.GroupID, UserDefinedReportID, e.Value, Nothing)

                        End If

                    Next

                End Using

            End If

            RefreshGroupAccessGrids()

        End Sub
        Private Sub DataGridViewForm_UserAccess_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_UserAccess.CellValueChangingEvent

            'objects
            Dim UserUserDefinedReportAccess As AdvantageFramework.Security.Database.Entities.UserUserDefinedReportAccess = Nothing
            Dim UserUDRAccess As AdvantageFramework.Security.Database.Classes.UserUserDefinedReportAccess = Nothing

            UserUDRAccess = DataGridViewForm_UserAccess.CurrentView.GetRow(e.RowHandle)

            If UserUDRAccess IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each UserDefinedReportID In DataGridViewForm_UserDefinedReports.GetAllSelectedRowsBookmarkValues

                        UserUserDefinedReportAccess = AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.LoadByUserDefinedReportIDAndUserID(SecurityDbContext, UserDefinedReportID, UserUDRAccess.UserID)

                        If UserUserDefinedReportAccess IsNot Nothing Then

                            UserUserDefinedReportAccess.IsBlocked = e.Value

                            AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.Update(SecurityDbContext, UserUserDefinedReportAccess)

                        Else

                            AdvantageFramework.Security.Database.Procedures.UserUserDefinedReportAccess.Insert(SecurityDbContext, UserUDRAccess.UserID, UserDefinedReportID, e.Value, Nothing)

                        End If

                    Next

                End Using

            End If

            RefreshUserAccessGrid()

        End Sub
        Private Sub ButtonItemUserBlocking_BlockAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemUserBlocking_BlockAll.Click

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserUserDefinedReportAccess(True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemUserBlocking_UnblockAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemUserBlocking_UnblockAll.Click

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllUserUserDefinedReportAccess(False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemGroupBlocking_BlockAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemGroupBlocking_BlockAll.Click

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupUserDefinedReportAccess(True)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemGroupBlocking_UnblockAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemGroupBlocking_UnblockAll.Click

            Me.ShowWaitForm()
            Me.ShowWaitForm("Processing...")

            Try

                SetAllGroupUserDefinedReportAccess(False)

            Catch ex As Exception

            End Try

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemShowBy_All_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemShowBy_All.CheckedChanged

            If ButtonItemShowBy_All.Checked Then

                If Me.HasLoaded Then
                    
                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        LoadUserDefinedReports()

                        LoadSelectedUserDefinedReportsList()

                        RefreshGroupAccessGrids()

                        RefreshUserAccessGrid()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ButtonItemShowBy_AllBlocked_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemShowBy_AllBlocked.CheckedChanged

            If ButtonItemShowBy_AllBlocked.Checked Then

                If Me.HasLoaded Then
                    
                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        LoadUserDefinedReports()

                        LoadSelectedUserDefinedReportsList()

                        RefreshGroupAccessGrids()

                        RefreshUserAccessGrid()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ButtonItemShowBy_AllUnblocked_CheckedChanged(sender As Object, e As System.EventArgs) Handles ButtonItemShowBy_AllUnblocked.CheckedChanged

            If ButtonItemShowBy_AllUnblocked.Checked Then

                If Me.HasLoaded Then
                    
                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        LoadUserDefinedReports()

                        LoadSelectedUserDefinedReportsList()

                        RefreshGroupAccessGrids()

                        RefreshUserAccessGrid()

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()
                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace