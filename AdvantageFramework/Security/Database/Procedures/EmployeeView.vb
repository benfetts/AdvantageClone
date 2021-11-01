Namespace Security.Database.Procedures.EmployeeView

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadWithOfficeLimits(ByVal DbContext As Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.SecurityEmployees, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal Employees As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Security.Database.Views.Employee), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadWithOfficeLimits = From Employee In Employees
                                   Where HasLimitedOfficeCodes = False OrElse
                                         OfficeCodes.Contains(Employee.OfficeCode)
                                   Select Employee

        End Function
        Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Security.Database.Views.Employee)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadAllEmployeesByUser(DbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllEmployeesByUserWithOfficeLimits(ByVal DbContext As Database.DbContext, ByVal Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadAllEmployeesByUserWithOfficeLimits = LoadAllEmployeesByUserWithOfficeLimits(DbContext, Session.UserCode, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllEmployeesByUserWithOfficeLimits(ByVal DbContext As Database.DbContext, UserCode As String, ByVal AccessibleOfficeCodes As List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadAllEmployeesByUserWithOfficeLimits = LoadWithOfficeLimits(LoadAllEmployeesByUser(DbContext, UserCode), AccessibleOfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveWithOfficeLimits(Session As AdvantageFramework.Security.Session, DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveEmployeesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Security.Database.Views.Employee)

            'objects
            Dim UserEmployeeAccessList As System.Collections.Generic.List(Of String) = Nothing

            Try

                UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(DbContext, UserCode).Select(Function(Entity) Entity.EmployeeCode).ToList

            Catch ex As Exception
                UserEmployeeAccessList = Nothing
            End Try

            If UserEmployeeAccessList IsNot Nothing AndAlso UserEmployeeAccessList.Count > 0 Then

                LoadAllActiveEmployeesByUser = From Employee In LoadAllActive(DbContext)
                                               Where UserEmployeeAccessList.Contains(Employee.Code) = True
                                               Select Employee

            Else

                LoadAllActiveEmployeesByUser = From Employee In LoadAllActive(DbContext)
                                               Select Employee

            End If

        End Function
        Public Function LoadAllEmployeesByUser(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Security.Database.Views.Employee)

            'objects
            Dim UserEmployeeAccessList As System.Collections.Generic.List(Of String) = Nothing

            Try

                UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(DbContext, UserCode).Select(Function(Entity) Entity.EmployeeCode).ToList

            Catch ex As Exception
                UserEmployeeAccessList = Nothing
            End Try

            If UserEmployeeAccessList IsNot Nothing AndAlso UserEmployeeAccessList.Count > 0 Then

                LoadAllEmployeesByUser = From Employee In Load(DbContext)
                                         Where UserEmployeeAccessList.Contains(Employee.Code) = True
                                         Select Employee

            Else

                LoadAllEmployeesByUser = From Employee In Load(DbContext)
                                         Select Employee

            End If

        End Function
        Public Function LoadAllActiveByOfficeCode(ByVal DbContext As Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Security.Database.Views.Employee)

            LoadAllActiveByOfficeCode = From Employee In LoadAllActive(DbContext)
                                        Where Employee.OfficeCode = OfficeCode
                                        Select Employee

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Security.Database.Views.Employee)

            LoadAllActive = From Employee In DbContext.SecurityEmployees
                            Where Employee.TerminationDate Is Nothing
                            Select Employee

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As AdvantageFramework.Security.Database.Views.Employee

            Try

                LoadByEmployeeCode = (From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                                      Where Employee.Code = EmployeeCode
                                      Select Employee).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As Database.DbContext, ByVal UserCode As String) As AdvantageFramework.Security.Database.Views.Employee

            Try

                Dim EmployeeCode As String = ""

                EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = '{0}';", UserCode.ToUpper())).ToString()

                LoadByUserCode = (From Employee In DbContext.SecurityEmployees
                                  Where Employee.Code = EmployeeCode
                                  Select Employee).SingleOrDefault

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Security.Database.Views.Employee)

            Load = From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                   Select Employee

        End Function

#End Region

    End Module

End Namespace
