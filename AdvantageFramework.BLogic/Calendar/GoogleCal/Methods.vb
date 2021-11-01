Namespace Calendar.GoogleCal

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const ExtendedPropertyName As String = "BillingInformation"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function SyncEmployeeNonTask(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeNonTaskID As Integer, ByVal IsDeleting As Boolean, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                        Syncd = SyncEmployeeNonTask(DbContext, SecurityDbContext, UserCode, AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, EmployeeNonTaskID), IsDeleting, IsWebvantage, UseWindowsAuthentication)

                    End Using

                End Using

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Function SyncEmployeeNonTask(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                            ByVal UserCode As String,
                                            ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask,
                                            ByVal IsDeleting As Boolean, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean) As Boolean

            'objects
            Dim Syncd As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                If DbContext IsNot Nothing Then

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If EmployeeNonTask IsNot Nothing AndAlso Agency IsNot Nothing Then

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeNonTask.EmployeeCode)

                        If Employee IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.Email) = False AndAlso Employee.IgnoreCalendarSync = False Then

                            Syncd = AdvantageFramework.GoogleServices.Service.SyncEmployeeNonTask(DbContext.ConnectionString, UserCode, Employee.Code, EmployeeNonTask, IsDeleting, IsWebvantage, UseWindowsAuthentication)

                        End If

                    End If

                End If

            Catch ex As Exception
                Syncd = False
            Finally
                SyncEmployeeNonTask = Syncd
            End Try

        End Function
        Public Function IsSyncWithGoogleCalendarEnabled(ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim GoogleCalendar As Boolean = True

            Try

                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.SYNC_GOOGLECALENDAR.ToString)

            Catch ex As Exception
                Setting = Nothing
            End Try

            If Setting IsNot Nothing Then

                If IsNumeric(Setting.Value) Then

                    If Setting.Value = 0 Then

                        GoogleCalendar = False

                    End If

                End If

            End If

            IsSyncWithGoogleCalendarEnabled = GoogleCalendar

        End Function

#End Region

    End Module

End Namespace
