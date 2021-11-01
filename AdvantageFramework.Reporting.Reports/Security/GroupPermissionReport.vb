Namespace Security

    Public Class GroupPermissionReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(ByVal value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.GroupSecurityPermission
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



#End Region

#Region "  Control Event Handlers "

        Private Sub XrSubreportParentModulesPermission_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportParentModulesPermission.BeforePrint

            'objects
            Dim GroupPermissionsReportList As Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport) = Nothing
            Dim GroupPermissionsRpt As AdvantageFramework.Security.Database.Views.GroupPermissionsReport = Nothing

            GroupPermissionsReportList = New Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport)

            For Each GroupPermissionsRpt In DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport)).Where(Function(GroupPermissionsReport) GroupPermissionsReport.ModuleIsCategory = False AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.GroupID = Convert.ToInt32(Me.GetCurrentColumnValue("GroupID")) AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.ParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("ParentModuleID")) AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubParentModuleID Is Nothing AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubSubParentModuleID Is Nothing).ToList
                If GroupPermissionsReportList.Any(Function(Entity) Entity.ModuleCode = GroupPermissionsRpt.ModuleCode) = False Then

                    GroupPermissionsReportList.Add(GroupPermissionsRpt)

                End If

            Next

            XrSubreportParentModulesPermission.ReportSource.DataSource = GroupPermissionsReportList

        End Sub
        Private Sub XrSubreportSubParentModulesPermission_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportSubParentModulesPermission.BeforePrint

            'objects
            Dim GroupPermissionsReportList As Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport) = Nothing
            Dim GroupPermissionsRpt As AdvantageFramework.Security.Database.Views.GroupPermissionsReport = Nothing

            GroupPermissionsReportList = New Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport)

            For Each GroupPermissionsRpt In DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport)).Where(Function(GroupPermissionsReport) GroupPermissionsReport.ModuleIsCategory = False AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.GroupID = Convert.ToInt32(Me.GetCurrentColumnValue("GroupID")) AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.ParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("ParentModuleID")) AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubParentModuleID IsNot Nothing AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("SubParentModuleID")) AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubSubParentModuleID Is Nothing).ToList

                If GroupPermissionsReportList.Any(Function(Entity) Entity.ModuleCode = GroupPermissionsRpt.ModuleCode) = False Then

                    GroupPermissionsReportList.Add(GroupPermissionsRpt)

                End If

            Next

            XrSubreportSubParentModulesPermission.ReportSource.DataSource = GroupPermissionsReportList

        End Sub
        Private Sub XrSubreportSubSubParentModulesPermission_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportSubSubParentModulesPermission.BeforePrint

            'objects
            Dim GroupPermissionsReportList As Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport) = Nothing
            Dim GroupPermissionsRpt As AdvantageFramework.Security.Database.Views.GroupPermissionsReport = Nothing

            GroupPermissionsReportList = New Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport)

            For Each GroupPermissionsRpt In DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Security.Database.Views.GroupPermissionsReport)).Where(Function(GroupPermissionsReport) GroupPermissionsReport.ModuleIsCategory = False AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.GroupID = Convert.ToInt32(Me.GetCurrentColumnValue("GroupID")) AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.ParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("ParentModuleID")) AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubParentModuleID IsNot Nothing AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("SubParentModuleID")) AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubSubParentModuleID IsNot Nothing AndAlso _
                                                                                                                                                                                                 GroupPermissionsReport.SubSubParentModuleID = Convert.ToInt32(Me.GetCurrentColumnValue("SubSubParentModuleID"))).ToList

                If GroupPermissionsReportList.Any(Function(Entity) Entity.ModuleCode = GroupPermissionsRpt.ModuleCode) = False Then

                    GroupPermissionsReportList.Add(GroupPermissionsRpt)

                End If

            Next

            XrSubreportSubSubParentModulesPermission.ReportSource.DataSource = GroupPermissionsReportList

        End Sub
        Private Sub XrLabelUsersData_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelUsersData.BeforePrint

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                XrLabelUsersData.Text = Join(AdvantageFramework.Security.Database.Procedures.GroupUser.LoadByGroupID(SecurityDbContext, Convert.ToInt32(Me.GetCurrentColumnValue("GroupID"))).Select(Function(GroupUser) GroupUser.User.UserCode).Distinct.ToArray, ", ")

            End Using

        End Sub
        Private Sub XrLabelBlockedApplicationsData_BeforePrint(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelBlockedApplicationsData.BeforePrint

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                XrLabelBlockedApplicationsData.Text = Join(AdvantageFramework.Security.Database.Procedures.GroupApplicationAccess.LoadByGroupID(SecurityDbContext, Convert.ToInt32(Me.GetCurrentColumnValue("GroupID"))).Where(Function(Entity) Entity.IsBlocked = True AndAlso Entity.ApplicationID <> 3).Select(Function(GroupApplicationAccess) GroupApplicationAccess.Application.Name).Distinct.ToArray, ", ")

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
