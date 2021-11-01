Namespace Security

    Public Class PermissionReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _UserSettingsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.UserSetting) = Nothing
        Private _ApplicationsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.Application) = Nothing
        Private _UsersList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.SecurityPermission
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub PermissionReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _UserSettingsList = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadBySettingCode(SecurityDbContext, AdvantageFramework.Security.UserSettings.TIME_ENTRY_ONLY.ToString).Include("User").ToList

                End Using

            Catch ex As Exception
                _UserSettingsList = Nothing
            End Try

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _ApplicationsList = AdvantageFramework.Security.Database.Procedures.Application.Load(SecurityDbContext).Where(Function(Application) Application.ID <> AdvantageFramework.Security.Application.Client_Portal AndAlso Application.ID <> AdvantageFramework.Security.Application.Advantage_Update).ToList

                End Using

            Catch ex As Exception
                _ApplicationsList = Nothing
            End Try

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _UsersList = AdvantageFramework.Security.Database.Procedures.User.LoadWithAllOptions(SecurityDbContext).ToList

                End Using

            Catch ex As Exception
                _UsersList = Nothing
            End Try

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub XrSubreportParentModulesPermission_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportParentModulesPermission.BeforePrint

            'objects
            Dim UserPermissionsReportList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport) = Nothing
            Dim UserPermissionsRpt As AdvantageFramework.Security.Database.Views.UserPermissionsReport = Nothing

            UserPermissionsReportList = New Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport)

            For Each UserPermissionsRpt In DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport)).Where(Function(UserPermissionsReport) UserPermissionsReport.ModuleIsCategory = False AndAlso
                                                                                                                                                                                 UserPermissionsReport.UserID = Convert.ToInt32(Me.GetCurrentColumnValue("UserID")) AndAlso
                                                                                                                                                                                 UserPermissionsReport.ParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("ParentModuleID")) AndAlso
                                                                                                                                                                                 UserPermissionsReport.SubParentModuleID Is Nothing AndAlso
                                                                                                                                                                                 UserPermissionsReport.SubSubParentModuleID Is Nothing).ToList
                If UserPermissionsReportList.Any(Function(Entity) Entity.ModuleCode = UserPermissionsRpt.ModuleCode) = False Then

                    UserPermissionsReportList.Add(UserPermissionsRpt)

                End If

            Next

            XrSubreportParentModulesPermission.ReportSource.DataSource = UserPermissionsReportList

        End Sub
        Private Sub XrSubreportSubParentModulesPermission_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportSubParentModulesPermission.BeforePrint

            'objects
            Dim UserPermissionsReportList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport) = Nothing
            Dim UserPermissionsRpt As AdvantageFramework.Security.Database.Views.UserPermissionsReport = Nothing

            UserPermissionsReportList = New Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport)

            For Each UserPermissionsRpt In DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport)).Where(Function(UserPermissionsReport) UserPermissionsReport.ModuleIsCategory = False AndAlso
                                                                                                                                                                                                 UserPermissionsReport.UserID = Convert.ToInt32(Me.GetCurrentColumnValue("UserID")) AndAlso
                                                                                                                                                                                                 UserPermissionsReport.ParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("ParentModuleID")) AndAlso
                                                                                                                                                                                                 UserPermissionsReport.SubParentModuleID IsNot Nothing AndAlso
                                                                                                                                                                                                 UserPermissionsReport.SubParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("SubParentModuleID")) AndAlso
                                                                                                                                                                                                 UserPermissionsReport.SubSubParentModuleID Is Nothing).ToList

                If UserPermissionsReportList.Any(Function(Entity) Entity.ModuleCode = UserPermissionsRpt.ModuleCode) = False Then

                    UserPermissionsReportList.Add(UserPermissionsRpt)

                End If

            Next

            XrSubreportSubParentModulesPermission.ReportSource.DataSource = UserPermissionsReportList

        End Sub
        Private Sub XrSubreportSubSubParentModulesPermission_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportSubSubParentModulesPermission.BeforePrint

            'objects
            Dim UserPermissionsReportList As Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport) = Nothing
            Dim UserPermissionsRpt As AdvantageFramework.Security.Database.Views.UserPermissionsReport = Nothing

            UserPermissionsReportList = New Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport)

            For Each UserPermissionsRpt In DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Security.Database.Views.UserPermissionsReport)).Where(Function(UserPermissionsReport) UserPermissionsReport.ModuleIsCategory = False AndAlso
                                                                                                                                                                                                 UserPermissionsReport.UserID = Convert.ToInt32(Me.GetCurrentColumnValue("UserID")) AndAlso
                                                                                                                                                                                                 UserPermissionsReport.ParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("ParentModuleID")) AndAlso
                                                                                                                                                                                                 UserPermissionsReport.SubParentModuleID IsNot Nothing AndAlso
                                                                                                                                                                                                 UserPermissionsReport.SubParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("SubParentModuleID")) AndAlso
                                                                                                                                                                                                 UserPermissionsReport.SubSubParentModuleID IsNot Nothing AndAlso
                                                                                                                                                                                                 UserPermissionsReport.SubSubParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("SubSubParentModuleID"))).ToList

                If UserPermissionsReportList.Any(Function(Entity) Entity.ModuleCode = UserPermissionsRpt.ModuleCode) = False Then

                    UserPermissionsReportList.Add(UserPermissionsRpt)

                End If

            Next

            XrSubreportSubSubParentModulesPermission.ReportSource.DataSource = UserPermissionsReportList

        End Sub
        Private Sub XrLabelGroupsData_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelGroupsData.BeforePrint

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                XrLabelGroupsData.Text = Join(AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByUserID(SecurityDbContext, Convert.ToInt32(Me.GetCurrentColumnValue("UserID"))).Select(Function(GroupUser) GroupUser.Group.Name).Distinct.ToArray, ", ")

            End Using

        End Sub
        Private Sub XrLabelBlockedApplicationsData_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelBlockedApplicationsData.BeforePrint

            'objects
            Dim BlockedApplicationsList As Generic.List(Of String) = Nothing
            Dim UserID As Integer = 0
            Dim User As AdvantageFramework.Security.Classes.User = Nothing

            Try

                UserID = Convert.ToInt32(Me.GetCurrentColumnValue("UserID"))

            Catch ex As Exception
                UserID = 0
            End Try

            Try

                User = New AdvantageFramework.Security.Classes.User(_UsersList.SingleOrDefault(Function(Entity) Entity.ID = UserID))

            Catch ex As Exception
                User = Nothing
            End Try

            If User IsNot Nothing Then

                Try

                    BlockedApplicationsList = New Generic.List(Of String)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each Application In _ApplicationsList

                            If AdvantageFramework.Security.DoesUserHaveAccessToApplication(SecurityDbContext, User, Application.ID) = False Then

                                BlockedApplicationsList.Add(Application.Name)

                            End If

                        Next

                    End Using

                    XrLabelBlockedApplicationsData.Text = Join(BlockedApplicationsList.ToArray, ", ")

                Catch ex As Exception
                    XrLabelBlockedApplicationsData.Text = ""
                End Try

            End If

        End Sub
        Private Sub XrCheckBoxWebvantageOnly_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrCheckBoxWebvantageOnly.BeforePrint

            'objects
            Dim IsWebvantageOnly As Boolean = False
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Try

                UserSetting = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.User.UserCode = Me.GetCurrentColumnValue("UserCode"))

                If UserSetting IsNot Nothing Then

                    IsWebvantageOnly = (UserSetting.StringValue = "Y")

                End If

            Catch ex As Exception
                IsWebvantageOnly = False
            End Try

            XrCheckBoxWebvantageOnly.Checked = IsWebvantageOnly

        End Sub
        Private Sub XrCheckBoxCheckForUserAccess_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrCheckBoxCheckForUserAccess.BeforePrint

            'objects
            Dim CheckForUserAccess As Boolean = False
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing

            Try

                User = _UserSettingsList.SingleOrDefault(Function(Entity) Entity.User.UserCode = Me.GetCurrentColumnValue("UserCode")).User

                If User IsNot Nothing Then

                    CheckForUserAccess = User.CheckForUserAccess

                End If

            Catch ex As Exception
                CheckForUserAccess = False
            End Try

            XrCheckBoxCheckForUserAccess.Checked = CheckForUserAccess

        End Sub

#End Region

#End Region

    End Class

End Namespace
