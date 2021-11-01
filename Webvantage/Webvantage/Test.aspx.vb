Imports System.Collections.Generic
Imports System.Web.Configuration
Imports System.Web.Mvc
Imports AdvantageFramework
Imports Telerik.Web.UI

Public Class Test
    Inherits Webvantage.BaseChildPage

    Private Sub Test_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = True

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim TimeZones As System.Collections.Generic.List(Of TimeZoneInfo)
        'Dim OffsetTimeSpan As TimeSpan
        'Dim OffsetHours As Integer

        'TimeZones = TimeZoneInfo.GetSystemTimeZones.ToList

        'For Each TimeZone As TimeZoneInfo In TimeZones

        '    OffsetTimeSpan = TimeZone.GetUtcOffset(Now.Date)

        '    OffsetHours = OffsetTimeSpan.Hours

        '    Label1.Text &= String.Format("{0}, Offset:  {1},  Is DaylightSavingTime:  {2}<br />", TimeZone.StandardName, FormatNumber(OffsetHours, 2, TriState.False), TimeZone.IsDaylightSavingTime(Now.Date).ToString)

        '    'Me.RadComboBoxEmployeeTimeZone.Items.Add(New RadComboBoxItem(String.Format("{0} ({1})", TimeZone.StandardName, FormatNumber(OffsetHours, 2, TriState.False)), TimeZone.StandardName))

        '    'If TimeZone.IsDaylightSavingTime(Now.Date) = True Then

        '    '    Me.RadComboBoxEmployeeTimeZone.Items.Add(New RadComboBoxItem(String.Format("{0} ({1})", TimeZone.DaylightName, OffsetTimeSpan.Hours), TimeZone.StandardName))

        '    'Else

        '    '    Me.RadComboBoxEmployeeTimeZone.Items.Add(New RadComboBoxItem(String.Format("{0} ({1})", TimeZone.StandardName, OffsetTimeSpan.Hours), TimeZone.StandardName))

        '    'End If

        'Next


        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                'Using SecurityContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                '    Dim ClientPortalUser As AdvantageFramework.Security.Classes.ClientPortalUser

                '    ClientPortalUser = Nothing
                '    ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientContactID(SecurityContext, 15)

                '    If ClientPortalUser IsNot Nothing Then

                '        Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing
                '        APIReponse = AdvantageFramework.ConceptShare.UpdateConceptShareUser(DataContext, ClientPortalUser, ClientPortalUser.ConceptShareUserID,
                '                                                                            ClientPortalUser.ClientContact.FirstName, ClientPortalUser.ClientContact.LastName,
                '                                                                            "kcard.stran@gotoadvantage.com", "advantage", True)

                '    End If

                'End Using


                '''Dim SignedKey As String = AdvantageFramework.Security.LicenseKey.Encrypt(AdvantageFramework.Agency.Settings.CS_SIGNED.ToString)

                '''Try

                '''    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE AGY_SETTINGS SET AGY_SETTINGS_VALUE = '{0}' WHERE AGY_SETTINGS_CODE = '{1}';",
                '''                                                       SignedKey, AdvantageFramework.Agency.Settings.CS_SIGNED.ToString))

                '''Catch ex As Exception
                '''End Try

                'Dim Roles As Dictionary(Of Integer, String) = Nothing
                'Dim ProjectRoles As Dictionary(Of Integer, String) = Nothing
                'Roles = New Dictionary(Of Integer, String)

                'For Each Role In AdvantageFramework.ConceptShare.LoadRoles(DataContext)

                '    Roles.Add(Role.Id, Role.Name)

                'Next


                'ProjectRoles = New Dictionary(Of Integer, String)

                'For Each ProjectRole In AdvantageFramework.ConceptShare.LoadProjectRoles(DataContext)

                '    ProjectRoles.Add(ProjectRole.Id, ProjectRole.Name)

                'Next

                ''Dim Password As String = "parker07"
                ''Dim EncPwd As String
                ''EncPwd = AdvantageFramework.Security.LicenseKey.Encrypt(Password)

                'Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                'Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                'Dim ConceptShareConnectionAdmin As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                'Dim ConceptShareUser As AdvantageFramework.ConceptShareAPI.User

                'ConceptShareConnection = Nothing
                'ConceptShareConnectionAdmin = Nothing

                'ConceptShareConnectionAdmin = ConceptShareSession.CreateAdminConceptShareConnection
                'ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                'If ConceptShareConnectionAdmin IsNot Nothing Then

                '    'ConceptShareUser = ConceptShareConnectionAdmin.APIServiceClient.AddUser(ConceptShareConnectionAdmin.APIContext, True, "Dufuss", "McDorkDorkk", "dufusSSS.dorDDDDkdork@gotoadvantage.com", "advantage", 15, 1)

                '    'If ConceptShareUser IsNot Nothing Then

                '    '    ShowMessage("Created: " & ConceptShareUser.FullName)

                '    'End If

                '    'ConceptShareUser = ConceptShareConnection.APIServiceClient.GetUserProfile(ConceptShareConnection.APIContext, 0)

                'End If
                'If ConceptShareConnection IsNot Nothing Then



                'End If

                'AdvantageFramework.ConceptShare.CreateConceptShareUser(DataContext, "mtg", "Dufuss", "McDorkDorkk", "dufus.dorkdork@gotoadvantage.com", "advantage", True)

            End Using

        End Using

    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
        Dim ConceptShareConnectionAdmin As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
        Dim ConceptShareUser As AdvantageFramework.ConceptShareAPI.User

        ConceptShareConnection = Nothing
        ConceptShareConnectionAdmin = Nothing

        ConceptShareConnectionAdmin = ConceptShareSession.CreateAdminConceptShareConnection
        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        If ConceptShareConnectionAdmin IsNot Nothing Then

            'ConceptShareUser = ConceptShareConnectionAdmin.APIServiceClient.AddUser(ConceptShareConnectionAdmin.APIContext, True, "Dufuss", "McDorkDorkk", "dufusSSS.dorDDDDkdork@gotoadvantage.com", "advantage", 15, 1)

            'If ConceptShareUser IsNot Nothing Then

            '    ShowMessage("Created: " & ConceptShareUser.FullName)

            'End If

            ConceptShareUser = ConceptShareConnection.APIServiceClient.GetUserProfile(ConceptShareConnection.APIContext, Me.RadNumericTextBox1.Value)

            If ConceptShareUser IsNot Nothing Then

                Label2.Text = ConceptShareUser.IsRegistered

            End If

        End If
        If ConceptShareConnection IsNot Nothing Then



        End If


    End Sub
    Private Sub RadGrid1_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource

        'Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        'Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
        'Dim ConceptShareConnectionAdmin As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        'ConceptShareConnection = Nothing
        'ConceptShareConnectionAdmin = Nothing

        'ConceptShareConnectionAdmin = ConceptShareSession.CreateAdminConceptShareConnection
        'ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        'If ConceptShareConnectionAdmin IsNot Nothing Then

        '    Me.RadGrid1.DataSource = ConceptShareConnectionAdmin.APIServiceClient.GetSupportedLanguages().ToList

        'End If
        'If ConceptShareConnection IsNot Nothing Then



        'End If

    End Sub
    Private Sub RadGrid2_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGrid2.NeedDataSource

        'Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        'Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
        'Dim ConceptShareConnectionAdmin As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        'ConceptShareConnection = Nothing
        'ConceptShareConnectionAdmin = Nothing

        'ConceptShareConnectionAdmin = ConceptShareSession.CreateAdminConceptShareConnection
        'ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        'If ConceptShareConnectionAdmin IsNot Nothing Then

        '    Me.RadGrid2.DataSource = ConceptShareConnectionAdmin.APIServiceClient.GetSupportedTimeZones().ToList

        'End If
        'If ConceptShareConnection IsNot Nothing Then



        'End If

    End Sub
    Private Sub RadGridConceptShareRoles_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridConceptShareRoles.NeedDataSource

        'Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '    RadGridConceptShareRoles.DataSource = AdvantageFramework.ConceptShare.LoadAllProjectRoles(DataContext, Nothing)

        'End Using

    End Sub
    Private Sub RadGridCsCpAccountPermissions_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridCsCpAccountPermissions.NeedDataSource

        'Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '    RadGridCsCpAccountPermissions.DataSource = AdvantageFramework.ConceptShare.LoadClientPortalPermissions(DataContext, 1)

        'End Using

    End Sub
    Private Sub RadGridCsCpProjectPermissions_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridCsCpProjectPermissions.NeedDataSource

        'Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '    RadGridCsCpProjectPermissions.DataSource = AdvantageFramework.ConceptShare.LoadClientPortalPermissions(DataContext, 2)

        'End Using

    End Sub
    Private Sub RadGridProjects_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridProjects.NeedDataSource

        'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '        Dim Employee As AdvantageFramework.Database.Views.Employee

        '        Employee = Nothing

        '        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, HttpContext.Current.Session("EmpCode"))

        '        If Employee IsNot Nothing Then

        '            Me.RadGridProjects.DataSource = AdvantageFramework.ConceptShare.LoadProjects(DataContext, Employee)

        '        End If

        '    End Using

        'End Using

    End Sub
    Private Sub RadGridReviews_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridReviews.NeedDataSource

        'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

        '        Dim Employee As AdvantageFramework.Database.Views.Employee

        '        Employee = Nothing

        '        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, HttpContext.Current.Session("EmpCode"))

        '        If Employee IsNot Nothing Then

        '            Me.RadGridReviews.DataSource = AdvantageFramework.ConceptShare.LoadReviews(DataContext, Employee, 3)

        '        End If

        '    End Using

        'End Using

    End Sub
    Private Sub RadGridTimeZones_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridTimeZones.ItemDataBound

        'Select Case e.Item.ItemType
        '    Case GridItemType.AlternatingItem, GridItemType.Item

        '        Dim CurrentRow As GridDataItem = e.Item

        '        If CurrentRow IsNot Nothing Then

        '            Dim TimeZone As TimeZoneInfo

        '            TimeZone = e.Item.DataItem

        '            If TimeZone IsNot Nothing Then

        '                Dim MyLabel As Label = CurrentRow.FindControl("LabelMyLabel")
        '                Dim Offset As Decimal = 0

        '                If MyLabel IsNot Nothing Then

        '                    Offset = TimeZone.BaseUtcOffset.Hours + (TimeZone.BaseUtcOffset.Minutes / 60)

        '                    If TimeZone.IsDaylightSavingTime(Now.Date) = True Then

        '                        Offset += 1
        '                        MyLabel.CssClass = "highlight"

        '                    End If

        '                    MyLabel.Text = Offset

        '                End If

        '            End If

        '        End If

        'End Select

    End Sub
    Private Sub RadGridTimeZones_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridTimeZones.NeedDataSource

        'Dim TimeZones As System.Collections.Generic.List(Of TimeZoneInfo)

        'TimeZones = TimeZoneInfo.GetSystemTimeZones.ToList

        'RadGridTimeZones.DataSource = TimeZones


    End Sub
    Private Sub RadGridUploadParameters_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridUploadParameters.NeedDataSource

        'Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        'Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        'ConceptShareConnection = Nothing
        'ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        'If ConceptShareConnection IsNot Nothing Then

        '    Me.RadGridUploadParameters.DataSource = AdvantageFramework.ConceptShare.LoadUploadParameters(ConceptShareConnection, Nothing)

        'End If

    End Sub

    Private Sub ButtonAddCSUserToCSAccount_Click(sender As Object, e As EventArgs) Handles ButtonAddCSUserToCSAccount.Click

        'Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        'Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        'ConceptShareConnection = Nothing

        'ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

        'If ConceptShareConnection IsNot Nothing Then

        '    ConceptShareConnection.APIServiceClient.AddAccountUser(ConceptShareConnection)

        'End If


    End Sub

    Private Sub ButtonFixPermissions_Click(sender As Object, e As EventArgs) Handles ButtonFixPermissions.Click

        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            AdvantageFramework.ConceptShare.SetEmployeesRoles(DataContext)

        End Using

    End Sub

    Private Sub RadGridAccounts_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridAccounts.NeedDataSource
        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
        Dim ConceptShareConnectionAdmin As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

        ConceptShareConnection = Nothing
        ConceptShareConnectionAdmin = Nothing

        ConceptShareConnectionAdmin = ConceptShareSession.CreateAdminConceptShareConnection
        ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

        If ConceptShareConnectionAdmin IsNot Nothing Then

            'Me.RadGrid2.DataSource = ConceptShareConnectionAdmin.APIServiceClient.GetSupportedTimeZones().ToList

            Me.RadGridAccounts.DataSource = ConceptShareConnectionAdmin.APIServiceClient.GetAccountList(ConceptShareConnectionAdmin.APIContext, Nothing, "", "", "", "", Nothing).ToList

        End If
        If ConceptShareConnection IsNot Nothing Then



        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            'Webvantage.SignalR.Classes.NotificationHub.RefreshSprint(DbContext, 2, Me._Session.UserCode)
            ''Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, 453, 2, Me._Session.UserCode, "", True)

        End Using

    End Sub

    Private Sub ButtonDecryptQS_Click(sender As Object, e As EventArgs) Handles ButtonDecryptQS.Click

        'me.LabelDecryptQS.Text = adv
        Dim PageName As String = String.Empty

        Try

            'PageName = AdvantageFramework.Web.DecryptDeepLinkString(Me.TextBoxDecryptQS.Text)

            Dim s As String = "http://localhost:57420/Proofing?dl=bs+9yTkXGpcn4yw+RngTOpqx0wDrgCcKptamzVsQy2qUQ9ZJ3y/6yVLs9SHLPBV+PIvj3x3MBe4+zS+ikk6CKa5gBCfM7/DIOiQUQTGXChGjaulkDdgaLjKFL5yiHqjtDeFzOwpeX/7miLhS+KssV5CjlPuFnThDW+51cXs7rMMgaiKTaigWL6FVcFLHnjwlek+tZdHhmK9WtpMKJmiSE5kJJhmecTvHN8cwAMHVuT8znptmrywRbmzBnjwutabRehbUZIdjsZr3F+IVCcwvL6nOwEk+xdmrJY5T5qy+R5ywpczC8oysLaRkOf5faWALA"

            Dim qs As New AdvantageFramework.Web.QueryString

            qs.FromString(s)

            'Dim a As String = qs.ConnectionString

        Catch ex As Exception
            PageName = String.Empty
        End Try

        Me.LabelDecryptQS.Text = PageName

    End Sub

End Class
