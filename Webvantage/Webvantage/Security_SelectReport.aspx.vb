Public Class Security_SelectReport
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub SetupFormForSelectedReport()

        'objects
        Dim SecurityReportType As AdvantageFramework.Reporting.SecurityReportTypes = AdvantageFramework.Reporting.SecurityReportTypes.SecurityPermission

        RadListBoxEmployees.ClearSelection()
        RadListBoxGroups.ClearSelection()
        RadListBoxUsers.ClearSelection()

        If RadComboBoxReport.SelectedValue IsNot Nothing AndAlso IsNumeric(RadComboBoxReport.SelectedValue) Then

            RadButtonAll.Enabled = True
            RadButtonSelect.Enabled = True
            RadListBoxEmployees.Enabled = False
            RadListBoxGroups.Enabled = False
            RadListBoxUsers.Enabled = False
            CheckBoxShowOnlyAccessibleModules.Enabled = True
            RadToolBarButtonView.Enabled = True

            SecurityReportType = DirectCast(CInt(RadComboBoxReport.SelectedValue), AdvantageFramework.Reporting.SecurityReportTypes)

            RadButtonAll.Checked = True

            CheckBoxShowOnlyAccessibleModules.Checked = False

            If SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.SecurityPermission Then

                CheckBoxShowOnlyAccessibleModules.Visible = True

                RadListBoxEmployees.Visible = False
                RadListBoxGroups.Visible = False
                RadListBoxUsers.Visible = True

            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.EmployeeSummary Then

                CheckBoxShowOnlyAccessibleModules.Visible = False

                RadListBoxEmployees.Visible = True
                RadListBoxGroups.Visible = False
                RadListBoxUsers.Visible = False

            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.GroupSecurityPermission Then

                CheckBoxShowOnlyAccessibleModules.Visible = True

                RadListBoxEmployees.Visible = False
                RadListBoxGroups.Visible = True
                RadListBoxUsers.Visible = False

            ElseIf SecurityReportType = AdvantageFramework.Reporting.SecurityReportTypes.GroupSummary Then

                CheckBoxShowOnlyAccessibleModules.Visible = False

                RadListBoxEmployees.Visible = False
                RadListBoxGroups.Visible = True
                RadListBoxUsers.Visible = False

            End If

        Else

            RadButtonAll.Enabled = False
            RadButtonSelect.Enabled = False
            RadListBoxEmployees.Enabled = False
            RadListBoxGroups.Enabled = False
            RadListBoxUsers.Enabled = False
            CheckBoxShowOnlyAccessibleModules.Enabled = False
            RadToolBarButtonView.Enabled = False

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub Security_SelectReport_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            RadComboBoxReport.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Reporting.SecurityReportTypes), False)
            RadComboBoxReport.DataBind()

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadListBoxEmployees.DataSource = (From Employee In AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, _Session).Include("Users").Where(Function(Entity) Entity.Users.Any).ToList
                                                  Select [Code] = Employee.Code,
                                                         [Name] = Employee.ToString).ToList

                RadListBoxEmployees.DataBind()

                RadListBoxGroups.DataSource = (From Group In AdvantageFramework.Security.Database.Procedures.Group.Load(SecurityDbContext).ToList
                                               Select [Code] = Group.Name,
                                                      [Name] = Group.Name).ToList

                RadListBoxGroups.DataBind()

                RadListBoxUsers.DataSource = (From User In AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, _Session).Include("Users").Include("Department") _
                                                                                                                                             .SelectMany(Function(Employee) Employee.Users).Distinct.OrderBy(Function(User) User.UserCode).ToList
                                              Select [ID] = User.ID,
                                                     [Name] = User.UserCode).ToList

                RadListBoxUsers.DataBind()

            End Using

            SetupFormForSelectedReport()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadComboBoxReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxReport.SelectedIndexChanged

        SetupFormForSelectedReport()

    End Sub
    Private Sub RadButtonAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonAll.CheckedChanged

        If RadButtonAll.Checked Then

            RadListBoxEmployees.Enabled = False
            RadListBoxGroups.Enabled = False
            RadListBoxUsers.Enabled = False

        End If

    End Sub
    Private Sub RadButtonSelect_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonSelect.CheckedChanged

        If RadButtonSelect.Checked Then

            RadListBoxEmployees.Enabled = True
            RadListBoxGroups.Enabled = True
            RadListBoxUsers.Enabled = True

        End If

    End Sub
    Private Sub RadToolBarSecurityReport_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarSecurityReport.ButtonClick

        'objects
        Dim ReportType As AdvantageFramework.Reporting.SecurityReportTypes = AdvantageFramework.Reporting.ReportTypes.SecurityPermission
        Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
        Dim UserIDsList As Generic.List(Of Integer) = Nothing
        Dim EmployeeCodesList As Generic.List(Of String) = Nothing
        Dim GroupNamesList As Generic.List(Of String) = Nothing

        Select Case e.Item.Value

            Case "View"

                If RadComboBoxReport.SelectedValue IsNot Nothing AndAlso IsNumeric(RadComboBoxReport.SelectedValue) Then

                    If RadButtonAll.Checked OrElse (RadButtonSelect.Checked AndAlso (RadListBoxEmployees.SelectedItems.Any OrElse RadListBoxGroups.SelectedItems.Any OrElse RadListBoxUsers.SelectedItems.Any)) Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ReportType = DirectCast(CInt(RadComboBoxReport.SelectedValue), AdvantageFramework.Reporting.ReportTypes)

                            Session("SecurityReportParameterDictionary") = Nothing

                            If RadButtonSelect.Checked AndAlso (RadListBoxEmployees.SelectedItems.Any OrElse RadListBoxGroups.SelectedItems.Any OrElse RadListBoxUsers.SelectedItems.Any) Then

                                ParameterDictionary = New Generic.Dictionary(Of String, Object)

                                If ReportType = AdvantageFramework.Reporting.ReportTypes.SecurityPermission Then

                                    UserIDsList = RadListBoxUsers.SelectedItems.Select(Function(RadListBoxItem) CInt(RadListBoxItem.Value)).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.UserPermissionsReportView.Load(SecurityDbContext)
                                                                         Where UserIDsList.Contains(Entity.UserID) = True AndAlso
                                                                               Entity.ApplicationIsBlocked = False
                                                                         Select Entity).ToList

                                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission Then

                                    GroupNamesList = RadListBoxGroups.SelectedItems.Select(Function(RadListBoxItem) RadListBoxItem.Value).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.GroupPermissionsReportView.Load(SecurityDbContext)
                                                                         Where GroupNamesList.Contains(Entity.GroupName) = True AndAlso
                                                                               Entity.ApplicationIsBlocked = False
                                                                         Select Entity).ToList

                                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.EmployeeSummary Then

                                    EmployeeCodesList = RadListBoxEmployees.SelectedItems.Select(Function(RadListBoxItem) RadListBoxItem.Value).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.EmployeeSummaryView.Load(SecurityDbContext)
                                                                         Where EmployeeCodesList.Contains(Entity.EmployeeCode) = True
                                                                         Select Entity).ToList

                                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSummary Then

                                    GroupNamesList = RadListBoxGroups.SelectedItems.Select(Function(RadListBoxItem) RadListBoxItem.Value).ToList

                                    ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.EmployeeSummaryView.Load(SecurityDbContext)
                                                                         Where GroupNamesList.Contains(Entity.GroupName) = True
                                                                         Select Entity).ToList

                                End If

                            End If

                            If CheckBoxShowOnlyAccessibleModules.Checked Then

                                If ParameterDictionary Is Nothing Then

                                    ParameterDictionary = New Generic.Dictionary(Of String, Object)

                                End If

                                If ReportType = AdvantageFramework.Reporting.ReportTypes.SecurityPermission Then

                                    If ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                                        ParameterDictionary("DataSource") = (From Entity In DirectCast(ParameterDictionary("DataSource"), Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport))
                                                                             Where Entity.IsBlocked = False
                                                                             Select Entity).ToList

                                    Else

                                        UserIDsList = AdvantageFramework.Security.Database.Procedures.EmployeeView.LoadWithOfficeLimits(SecurityDbContext, _Session).Include("Users").SelectMany(Function(Employee) Employee.Users).Distinct.ToList.Select(Function(Entity) Entity.ID).Distinct.ToList

                                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.UserPermissionsReportView.Load(SecurityDbContext)
                                                                             Where UserIDsList.Contains(Entity.UserID) = True AndAlso
                                                                                   Entity.IsBlocked = False AndAlso
                                                                                   Entity.ApplicationIsBlocked = False
                                                                             Select Entity).ToList

                                    End If

                                ElseIf ReportType = AdvantageFramework.Reporting.ReportTypes.GroupSecurityPermission Then

                                    If ParameterDictionary.ContainsKey("DataSource") AndAlso ParameterDictionary("DataSource") IsNot Nothing Then

                                        ParameterDictionary("DataSource") = (From Entity In DirectCast(ParameterDictionary("DataSource"), Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport))
                                                                             Where Entity.IsBlocked = False
                                                                             Select Entity).ToList

                                    Else

                                        ParameterDictionary("DataSource") = (From Entity In AdvantageFramework.Security.Database.Procedures.GroupPermissionsReportView.Load(SecurityDbContext)
                                                                             Where Entity.IsBlocked = False AndAlso
                                                                                   Entity.ApplicationIsBlocked = False
                                                                             Select Entity).ToList

                                    End If

                                End If

                            End If

                            Session("SecurityReportParameterDictionary") = ParameterDictionary

                            MiscFN.ResponseRedirect("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), ReportType) & "")

                        End Using

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox("Please select a row from the grid.")

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox("Please select a report.")

                End If

        End Select

    End Sub

#End Region

#End Region

End Class