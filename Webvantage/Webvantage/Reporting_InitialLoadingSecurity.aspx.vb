Public Class Reporting_InitialLoadingSecurity
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DynamicReportType As Integer = -1
    Private _DynamicReportTemplateID As Integer = 0
    Private _UserDefinedReportID As Integer = 0
    Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadDynamicReport()

        _DynamicReportType = CType(Session("DRPT_Type"), Integer)

        Try

            If Request.QueryString("DynamicReportTemplateID") IsNot Nothing Then

                _DynamicReportTemplateID = CType(Request.QueryString("DynamicReportTemplateID"), Integer)

            End If

        Catch ex As Exception
            _DynamicReportTemplateID = 0
        End Try

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

    End Sub
    Private Sub LoadGroups()

        Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridGroups.DataSource = (From Entity In AdvantageFramework.Security.Database.Procedures.Group.Load(DbContext)
                                        Select [Code] = Entity.ID,
                                               [Name] = Entity.Description).ToList
            RadGridGroups.DataBind()

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

        Using DbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If RadioButtonAllGroups.Checked = True OrElse RadGridGroups.SelectedItems.Count = 0 Then

                If CheckBoxIncludeTerminatedEmployees.Checked = False Then

                    RadGridUsers.DataSource = (From Entity In AdvantageFramework.Security.Database.Procedures.User.Load(DbContext).Include("Employee").ToList
                                               Where Entity.Employee.TerminationDate Is Nothing
                                               Select [Code] = Entity.ID,
                                                      [Name] = Entity.UserCode).ToList

                Else

                    RadGridUsers.DataSource = (From Entity In AdvantageFramework.Security.Database.Procedures.User.Load(DbContext)
                                               Select [Code] = Entity.ID,
                                                      [Name] = Entity.UserCode).ToList

                End If

            Else

                If RadioButtonChooseGroups.Checked Then

                    SelectedGroups = New Generic.List(Of Integer)

                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridGroups.MasterTableView.Items
                        If gridDataItem.Selected = True Then
                            SelectedGroups.Add(gridDataItem.GetDataKeyValue("Code"))
                        End If
                    Next

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

                                If CheckBoxIncludeTerminatedEmployees.Checked = False AndAlso User.Employee.TerminationDate Is Nothing Then
                                    FinalGroupUsersList.Add(User)
                                ElseIf CheckBoxIncludeTerminatedEmployees.Checked = True Then
                                    FinalGroupUsersList.Add(User)
                                End If

                            End If

                        Next
                    End If


                    RadGridUsers.DataSource = (From Entity In FinalGroupUsersList
                                               Select [Code] = Entity.ID,
                                                      [Name] = Entity.UserCode).ToList


                End If


            End If

            RadGridUsers.DataBind()

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Reporting_InitialLoadingSecurity_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadDynamicReport()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityGroupModuleAccess Or _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityGroupSettings Then
                RadTabStripSecurity.FindTabByValue("2").Visible = False
                CheckBoxIncludeTerminatedEmployees.Enabled = False
            End If

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityUserModuleAccess Or _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityUserSettings Then
                RadTabStripSecurity.FindTabByValue("1").Visible = False
            End If

            If _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityGroupSettings Or _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityUserSettings Or _DynamicReportType = AdvantageFramework.Reporting.DynamicReports.SecurityGroupUserSettings Then
                CheckBoxShowOnlyAccessibleModules.Enabled = False
            End If

            If _ParameterDictionary IsNot Nothing Then


            End If

            RadGridGroups.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)

            RadGridUsers.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolBarDynamicReportInitialLoading_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarDynamicReportInitialLoading.ButtonClick

        LoadDynamicReport()

        Select Case e.Item.Value

            Case RadToolBarButtonOK.Value

                Session("DRPT_ParameterDictionary") = Nothing

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.ShowOnlyAccessibleModules.ToString) = CheckBoxShowOnlyAccessibleModules.Checked
                _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.IncludeTerminatedEmployees.ToString) = CheckBoxIncludeTerminatedEmployees.Checked

                Dim GroupList As Generic.List(Of Integer) = Nothing
                Dim UserList As Generic.List(Of Integer) = Nothing

                If RadioButtonAllGroups.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.SelectedGroups.ToString) = Nothing

                Else

                    If RadGridGroups.Items.Count > 0 Then
                        GroupList = New Generic.List(Of Integer)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridGroups.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                GroupList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.SelectedGroups.ToString) = GroupList

                End If

                If RadioButtonAllUsers.Checked Then

                    _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.SelectedUsers.ToString) = Nothing

                Else

                    If RadGridUsers.Items.Count > 0 Then
                        UserList = New Generic.List(Of Integer)
                        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridUsers.MasterTableView.Items
                            If gridDataItem.Selected = True Then
                                UserList.Add(gridDataItem.GetDataKeyValue("Code"))
                            End If
                        Next
                    End If

                    _ParameterDictionary(AdvantageFramework.Reporting.SecurityParameters.SelectedUsers.ToString) = UserList

                End If


                Session("DRPT_Criteria") = Nothing
                Session("DRPT_FilterString") = Nothing
                Session("DRPT_UseBlankData") = False
                Session("DRPT_DashboardLoaded") = False
                Session("DRPT_From") = Nothing
                Session("DRPT_To") = Nothing
                Session("DRPT_ShowJobsWithNoDetails") = Nothing
                Session("DRPT_ParameterDictionary") = _ParameterDictionary


                If _UserDefinedReportID = 0 Then

                    If _DynamicReportTemplateID <> 0 Then

                        Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                    Else

                        Me.CloseThisWindowAndRefreshCaller("Reporting_DynamicReportEdit.aspx", False, True)

                    End If

                Else

                    Session("UserDefinedReportID") = _UserDefinedReportID

                    Me.CloseThisWindowAndOpenNewWindow("Reporting_ViewReport.aspx?Report=" & CType(AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), AdvantageFramework.Reporting.ReportTypes.UserDefined.ToString), String) & "")

                End If

            Case RadToolBarButtonCancel.Value

                'Session("DRPT_Criteria") = Nothing
                'Session("DRPT_FilterString") = Nothing
                'Session("DRPT_UseBlankData") = True
                'Session("DRPT_DashboardLoaded") = False
                'Session("DRPT_From") = Nothing
                'Session("DRPT_To") = Nothing
                'Session("DRPT_ShowJobsWithNoDetails") = Nothing
                'Session("DRPT_ParameterDictionary") = Nothing

                'If _DynamicReportTemplateID <> 0 Then

                '    Me.CloseThisWindowAndRefreshCaller([String].Format("Reporting_DynamicReportEdit.aspx?DynamicReportTemplateID={0}", _DynamicReportTemplateID), True, True)

                'Else

                Me.CloseThisWindow()

                'End If

        End Select

    End Sub

    Private Sub RadioButtonAllGroups_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllGroups.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonAllGroups.Checked Then

            RadGridGroups.Enabled = False
            RadGridGroups.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.Group)
            RadGridGroups.DataBind()

        End If

        'End If

    End Sub
    Private Sub RadioButtonChooseGroups_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseGroups.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChooseGroups.Checked Then

            If RadGridGroups.Items.Count = 0 Then

                LoadGroups()

            End If

            RadGridGroups.Enabled = True

        End If

        'End If

    End Sub
    Private Sub RadioButtonAllUsers_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAllUsers.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonAllUsers.Checked Then

            RadGridUsers.Enabled = False
            RadGridUsers.DataSource = New Generic.List(Of AdvantageFramework.Security.Database.Entities.User)
            RadGridUsers.DataBind()

        End If

        'End If

    End Sub
    Private Sub RadioButtonChooseUsers_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonChooseUsers.CheckedChanged

        'If Me.FormShown Then

        If RadioButtonChooseUsers.Checked Then

            'If RadGridUsers.Items.Count = 0 Then

            LoadUsers()

            'End If

            RadGridUsers.Enabled = True

        End If

        'End If

    End Sub

    Private Sub CheckBoxIncludeTerminatedEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeTerminatedEmployees.CheckedChanged
        If RadioButtonChooseUsers.Checked Then
            LoadUsers()
        End If

    End Sub


#End Region

#End Region

End Class
