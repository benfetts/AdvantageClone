Namespace Database.Procedures.EmployeeView

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

#Region "  Core Entities "

        Public Function LoadCore(ByVal Employees As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)) As IEnumerable(Of AdvantageFramework.Database.Core.Employee)

            Try

                LoadCore = Employees _
                           .Select(Function(Entity) New With {Entity.Code,
                                                              Entity.FirstName,
                                                              Entity.LastName,
                                                              Entity.MiddleInitial,
                                                              Entity.TerminationDate}) _
                           .Select(Function(Entity) New AdvantageFramework.Database.Core.Employee With {.Code = Entity.Code,
                                                                                                        .FirstName = Entity.FirstName,
                                                                                                        .LastName = Entity.LastName,
                                                                                                        .MiddleInitial = Entity.MiddleInitial,
                                                                                                        .TerminationDate = Entity.TerminationDate}).ToList

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function
        Public Function LoadCore(ByVal DbContext As AdvantageFramework.Database.DbContext) As IEnumerable(Of AdvantageFramework.Database.Core.Employee)

            Try

                LoadCore = LoadCore(Load(DbContext))

            Catch ex As Exception
                LoadCore = Nothing
            End Try

        End Function

#End Region

        Public Function LoadActiveConceptShareEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadActiveConceptShareEmployees = From Employee In LoadAllActiveWithOfficeLimits(Session, DbContext)
                                              Where Employee.ConceptShareUserID IsNot Nothing AndAlso Employee.ConceptShareUserID > 0
                                              Select Employee

        End Function
        Public Function LoadByAlertAssignmentTemplateIDAndAlertStateID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                       ByVal UserCode As String, ByVal AlertAssignmentTemplateID As Integer, ByVal AlertStateID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            Dim TemplateStateEmployeeCodes As String() = Nothing

            Try

                TemplateStateEmployeeCodes = (From AlertAssignmentTemplateEmployee In AdvantageFramework.Database.Procedures.AlertAssignmentTemplateEmployee.LoadByAlertAssignmentTemplateIDAndAlertStateID(DbContext, AlertAssignmentTemplateID, AlertStateID)
                                              Select AlertAssignmentTemplateEmployee.EmployeeCode).ToArray


            Catch ex As Exception
                TemplateStateEmployeeCodes = Nothing
            End Try

            Try

                LoadByAlertAssignmentTemplateIDAndAlertStateID = From Employee In LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, UserCode)
                                                                 Where TemplateStateEmployeeCodes.Any(Function(TemplateStateEmployeeCode) TemplateStateEmployeeCode = Employee.Code)
                                                                 Select Employee

            Catch ex As Exception
                LoadByAlertAssignmentTemplateIDAndAlertStateID = Nothing
            End Try

        End Function

        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadWithOfficeLimits = LoadWithOfficeLimits(DbContext.Employees, OfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadWithOfficeLimits(ByVal Employees As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadWithOfficeLimits = LoadWithOfficeLimits(Employees, OfficeCodes, HasLimitedOfficeCodes, Nothing)

        End Function
		Public Function LoadWithOfficeLimits(ByVal Employees As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean, ByVal OfficeBypassedEmployeeCodes As String()) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

			If OfficeBypassedEmployeeCodes Is Nothing Then

				OfficeBypassedEmployeeCodes = {""}

			End If

			LoadWithOfficeLimits = From Employee In Employees
								   Where HasLimitedOfficeCodes = False OrElse
										 OfficeCodes.Contains(Employee.OfficeCode) OrElse
										 OfficeBypassedEmployeeCodes.Contains(Employee.Code)
								   Select Employee

		End Function
		Public Function LoadWithOfficeLimits(ByVal Employees As IEnumerable(Of AdvantageFramework.Database.Views.Employee), OfficeCodes As System.Collections.Generic.List(Of String), HasLimitedOfficeCodes As Boolean, ByVal OfficeBypassedEmployeeCodes As String()) As IEnumerable(Of Database.Views.Employee)

			If OfficeBypassedEmployeeCodes Is Nothing Then

				OfficeBypassedEmployeeCodes = {""}

			End If

			LoadWithOfficeLimits = From Employee In Employees
								   Where HasLimitedOfficeCodes = False OrElse
										 OfficeCodes.Contains(Employee.OfficeCode) OrElse
										 OfficeBypassedEmployeeCodes.Contains(Employee.Code)
								   Select Employee

		End Function
		Public Function LoadByUserCodeWithOfficeLimits(Session As AdvantageFramework.Security.Session, ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, Optional ByVal ForceCurrentEmployee As Boolean = False) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadByUserCodeWithOfficeLimits = LoadWithOfficeLimits(LoadAllEmployeesByUser(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes, {If(ForceCurrentEmployee, Session.User.EmployeeCode, "")})

        End Function
        Public Function LoadAllEmployeesByUserWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadAllEmployeesByUserWithOfficeLimits = LoadAllEmployeesByUserWithOfficeLimits(DbContext, SecurityDbContext, Session.UserCode, Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllEmployeesByUserWithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, UserCode As String, ByVal AccessibleOfficeCodes As List(Of String), HasLimitedOfficeCodes As Boolean) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadAllEmployeesByUserWithOfficeLimits = LoadWithOfficeLimits(LoadAllEmployeesByUser(DbContext, SecurityDbContext, UserCode), AccessibleOfficeCodes, HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveWithOfficeLimits(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadAllActiveWithOfficeLimits = LoadWithOfficeLimits(LoadAllActive(DbContext), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes)

        End Function
        Public Function LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.Employee)

            LoadAllActiveByUserCodeWithOfficeLimitsAndIncludeCurrentUser = LoadWithOfficeLimits(LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, Session.UserCode), Session.AccessibleOfficeCodes, Session.HasLimitedOfficeCodes, {Session.User.EmployeeCode})

        End Function
        Public Function LoadEmployeeVendorsByUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim VendorEmployeeCodes As String() = Nothing

            Try

                VendorEmployeeCodes = (From VendorEmployee In AdvantageFramework.Database.Procedures.Vendor.LoadEmployeeVendors(DbContext)
                                       Select VendorEmployee.Code).ToArray

            Catch ex As Exception
                VendorEmployeeCodes = Nothing
            End Try

            Try

                LoadEmployeeVendorsByUser = From Employee In LoadAllActiveEmployeesByUser(DbContext, SecurityDbContext, UserCode)
                                            Where VendorEmployeeCodes.Any(Function(VendorEmployeeCode) VendorEmployeeCode = Employee.EmployeeVendorCode)
                                            Select Employee

            Catch ex As Exception
                LoadEmployeeVendorsByUser = Nothing
            End Try

        End Function
        Public Function LoadAllActiveEmployeesByUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim UserEmployeeAccessList As System.Collections.Generic.List(Of String) = Nothing

            Try

                UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, UserCode).Select(Function(Entity) Entity.EmployeeCode).ToList

            Catch ex As Exception
                UserEmployeeAccessList = Nothing
            End Try

            If UserEmployeeAccessList IsNot Nothing AndAlso UserEmployeeAccessList.Count > 0 Then

                Dim ThisEmployeeCode As String = CType(DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = '{0}';", UserCode.ToUpper())).FirstOrDefault, String)

                If String.IsNullOrWhiteSpace(ThisEmployeeCode) = False AndAlso UserEmployeeAccessList.Contains(ThisEmployeeCode) = False Then

                    UserEmployeeAccessList.Add(ThisEmployeeCode)

                End If

                LoadAllActiveEmployeesByUser = From Employee In LoadAllActive(DbContext)
                                               Where UserEmployeeAccessList.Contains(Employee.Code) = True
                                               Select Employee

            Else

                LoadAllActiveEmployeesByUser = From Employee In LoadAllActive(DbContext)
                                               Select Employee

            End If

        End Function
        Public Function LoadAllActiveEmployeeCodesByUserOffice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As System.Collections.Generic.List(Of String)

            'objects
            Dim UserOfficeAccessList As System.Collections.Generic.List(Of String) = Nothing

            Try

                UserOfficeAccessList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).Select(Function(Entity) Entity.OfficeCode).ToList

            Catch ex As Exception
                UserOfficeAccessList = Nothing
            End Try

            If UserOfficeAccessList IsNot Nothing AndAlso UserOfficeAccessList.Count > 0 Then

                LoadAllActiveEmployeeCodesByUserOffice = (From Employee In LoadAllActive(DbContext)
                                                          Where UserOfficeAccessList.Contains(Employee.OfficeCode) = True AndAlso Employee.TerminationDate Is Nothing
                                                          Select Employee.Code).ToList

            Else

                LoadAllActiveEmployeeCodesByUserOffice = (From Employee In LoadAllActive(DbContext)
                                                          Where Employee.TerminationDate Is Nothing
                                                          Select Employee.Code).ToList

            End If

        End Function
        Public Function LoadAllActiveEmployeesByUserOffice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim UserOfficeAccessList As System.Collections.Generic.List(Of String) = Nothing

            Try

                UserOfficeAccessList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).Select(Function(Entity) Entity.OfficeCode).ToList

            Catch ex As Exception
                UserOfficeAccessList = Nothing
            End Try

            If UserOfficeAccessList IsNot Nothing AndAlso UserOfficeAccessList.Count > 0 Then

                LoadAllActiveEmployeesByUserOffice = From Employee In LoadAllActive(DbContext)
                                                     Where UserOfficeAccessList.Contains(Employee.OfficeCode) = True AndAlso Employee.TerminationDate Is Nothing
                                                     Select Employee

            Else

                LoadAllActiveEmployeesByUserOffice = From Employee In LoadAllActive(DbContext)
                                                     Where Employee.TerminationDate Is Nothing
                                                     Select Employee

            End If

        End Function
        Public Function LoadAllActiveEmployeesByUserandOffice(Session As AdvantageFramework.Security.Session, DbContext As AdvantageFramework.Database.DbContext, SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadAllActiveEmployeesByUserandOffice = LoadAllActiveEmployeesByUserandOffice(DbContext, SecurityDbContext, Session.UserCode, Session.User.EmployeeCode)

        End Function
        Public Function LoadAllActiveEmployeesByUserandOffice(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim UserEmployeeAccessList As System.Collections.Generic.List(Of String) = Nothing
            Dim UserOfficeAccessList As System.Collections.Generic.List(Of String) = Nothing
            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee) = Nothing

            Try

                UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, UserCode).Select(Function(Entity) Entity.EmployeeCode).ToList
                UserOfficeAccessList = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, EmployeeCode).Select(Function(Entity) Entity.OfficeCode).ToList

            Catch ex As Exception
                UserEmployeeAccessList = Nothing
            End Try

            If UserOfficeAccessList IsNot Nothing AndAlso UserOfficeAccessList.Count > 0 Then

                ResultQuery = From Employee In LoadAllActive(DbContext)
                              Where UserOfficeAccessList.Contains(Employee.OfficeCode) = True AndAlso Employee.TerminationDate Is Nothing
                              Select Employee

            Else

                ResultQuery = From Employee In LoadAllActive(DbContext)
                              Where Employee.TerminationDate Is Nothing
                              Select Employee

            End If

            If UserEmployeeAccessList IsNot Nothing AndAlso UserEmployeeAccessList.Count > 0 Then

                ResultQuery = ResultQuery.Where(Function(Emp) UserEmployeeAccessList.Contains(Emp.Code))

            End If

            LoadAllActiveEmployeesByUserandOffice = ResultQuery


        End Function
        Public Function LoadAllExpenseEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadAllExpenseEmployees = From Entity In Load(DbContext)
                                      Join Vendor In Vendor.Load(DbContext) On Vendor.Code Equals Entity.EmployeeVendorCode
                                      Where Entity.EmployeeVendorCode IsNot Nothing AndAlso
                                            Entity.EmployeeVendorCode <> ""
                                      Select Entity

        End Function
        Public Function LoadAllActiveExpenseEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadAllActiveExpenseEmployees = From Entity In LoadAllActive(DbContext)
                                            Join Vendor In Vendor.LoadAllActive(DbContext) On Vendor.Code Equals Entity.EmployeeVendorCode
                                            Where Entity.EmployeeVendorCode IsNot Nothing AndAlso
                                                  Entity.EmployeeVendorCode <> ""
                                            Select Entity

        End Function
        Public Function LoadAllEmployeesByUser(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            'objects
            Dim UserEmployeeAccessList As System.Collections.Generic.List(Of String) = Nothing

            Try

                UserEmployeeAccessList = AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, UserCode).Select(Function(Entity) Entity.EmployeeCode).ToList

            Catch ex As Exception
                UserEmployeeAccessList = Nothing
            End Try

            If UserEmployeeAccessList IsNot Nothing AndAlso UserEmployeeAccessList.Count > 0 Then

                Dim ThisEmployeeCode As String = CType(DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = '{0}';", UserCode.ToUpper())).FirstOrDefault, String)

                If String.IsNullOrWhiteSpace(ThisEmployeeCode) = False AndAlso UserEmployeeAccessList.Contains(ThisEmployeeCode) = False Then

                    UserEmployeeAccessList.Add(ThisEmployeeCode)

                End If

                LoadAllEmployeesByUser = From Employee In Load(DbContext)
                                         Where UserEmployeeAccessList.Contains(Employee.Code) = True
                                         Select Employee

            Else

                LoadAllEmployeesByUser = From Employee In Load(DbContext)
                                         Select Employee

            End If

        End Function
        Public Function LoadAllActiveByOfficeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OfficeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadAllActiveByOfficeCode = From Employee In LoadAllActive(DbContext)
                                        Where Employee.OfficeCode = OfficeCode
                                        Select Employee

        End Function
        Public Function LoadAllActiveByDepartmentTeamCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DepartmentTeamCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadAllActiveByDepartmentTeamCode = From Employee In LoadAllActive(DbContext)
                                                Join EmployeeDepartment In EmployeeDepartment.LoadByDepartmentTeamCode(DbContext, DepartmentTeamCode)
                                                On EmployeeDepartment.EmployeeCode Equals Employee.Code
                                                Select Employee

        End Function
        Public Function LoadAllActiveByRoleCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RoleCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadAllActiveByRoleCode = From Employee In LoadAllActive(DbContext)
                                      Join EmployeeRole In EmployeeRole.LoadByRoleCode(DbContext, RoleCode) On EmployeeRole.EmployeeCode Equals Employee.Code
                                      Select Employee

        End Function
        Public Function LoadAllActiveByAlertGroupCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertGroupCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadAllActiveByAlertGroupCode = From Employee In LoadAllActive(DbContext)
                                            Join AlertGroup In AlertGroup.LoadByAlertGroupCode(DbContext, AlertGroupCode) On AlertGroup.EmployeeCode Equals Employee.Code
                                            Select Employee

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadAllActive = From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                            Where Employee.TerminationDate Is Nothing
                            Select Employee

        End Function
        Public Function LoadByEmployeeEmail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeEmail As String) As AdvantageFramework.Database.Views.Employee

            Try

                LoadByEmployeeEmail = (From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                                       Where Employee.Email = EmployeeEmail
                                       Select Employee).FirstOrDefault

            Catch ex As Exception
                LoadByEmployeeEmail = Nothing
            End Try

        End Function
        Public Function LoadByConceptShareUserID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ConceptShareUserID As Integer) As AdvantageFramework.Database.Views.Employee

            Try

                LoadByConceptShareUserID = (From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                                            Where Employee.ConceptShareUserID = ConceptShareUserID
                                            Select Employee).FirstOrDefault

            Catch ex As Exception
                LoadByConceptShareUserID = Nothing
            End Try

        End Function
        Public Function LoadByConceptShareEmployeeEmail(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeEmail As String) As AdvantageFramework.Database.Views.Employee

            Try

                LoadByConceptShareEmployeeEmail = (From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                                                   Where Employee.Email = EmployeeEmail And Employee.ConceptShareUserID IsNot Nothing
                                                   Select Employee).FirstOrDefault

            Catch ex As Exception
                LoadByConceptShareEmployeeEmail = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As AdvantageFramework.Database.Views.Employee

            Try

                LoadByEmployeeCode = (From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                                      Where Employee.Code = EmployeeCode
                                      Select Employee).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As AdvantageFramework.Database.Views.Employee

            Try

                Dim EmployeeCode As String = ""

                EmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 EMP_CODE FROM SEC_USER WITH(NOLOCK) WHERE UPPER(USER_CODE) = '{0}' ORDER BY SEC_USER_ID DESC;", UserCode.ToUpper())).FirstOrDefault

                LoadByUserCode = (From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                                  Where Employee.Code = EmployeeCode
                                  Select Employee).SingleOrDefault

            Catch ex As Exception
                LoadByUserCode = Nothing
            End Try

        End Function
        Public Function LoadUserCodeByEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As String

            Try

                Return DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 USER_CODE FROM SEC_USER WITH(NOLOCK) WHERE EMP_CODE = '{0}' ORDER BY SEC_USER_ID DESC;", EmployeeCode)).SingleOrDefault

            Catch ex As Exception
                Return String.Empty
            End Try

        End Function
        Public Function LoadBySupervisorEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SupervisorEmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadBySupervisorEmployeeCode = From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                                           Where Employee.SupervisorEmployeeCode = SupervisorEmployeeCode
                                           Select Employee

        End Function
        Public Function LoadBySupervisorEmployeeCodewithOfficeLimits(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SupervisorEmployeeCode As String, Session As AdvantageFramework.Security.Session) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            LoadBySupervisorEmployeeCodewithOfficeLimits = From Employee In LoadAllActiveWithOfficeLimits(Session, DbContext)
                                                           Where Employee.SupervisorEmployeeCode = SupervisorEmployeeCode
                                                           Select Employee

        End Function

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Views.Employee)

            Load = From Employee In DbContext.GetQuery(Of Database.Views.Employee)
                   Select Employee

        End Function
        Public Sub ProcessPaidTimeOffAccruals(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Year As Integer, ByVal Month As Integer, ByRef ReturnValue As Integer)

            'objects
            Dim SqlParameterYear As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterMonth As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterReturnValue As System.Data.SqlClient.SqlParameter = Nothing

            Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@user_id", SqlDbType.VarChar)
            SqlParameterUserCode.Value = DbContext.UserCode

            SqlParameterYear = New System.Data.SqlClient.SqlParameter("@process_yr", SqlDbType.SmallInt)
			SqlParameterMonth = New System.Data.SqlClient.SqlParameter("@process_mo", SqlDbType.SmallInt)
			SqlParameterReturnValue = New System.Data.SqlClient.SqlParameter("@ret_val", SqlDbType.SmallInt)
			SqlParameterReturnValue.Direction = ParameterDirection.Output

            SqlParameterYear.Value = Year
            SqlParameterMonth.Value = Month
            SqlParameterReturnValue.Value = 0

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC dbo.advsp_emp_time_rule_process @process_yr, @process_mo, @ret_val OUTPUT, @user_id",
                    SqlParameterYear, SqlParameterMonth, SqlParameterReturnValue, SqlParameterUserCode)

            Catch ex As Exception

            End Try

            ReturnValue = SqlParameterReturnValue.Value

        End Sub
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim Initialized As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing

            Try

                If Initialize(DbContext, Employee) Then

                    Initialized = True

                    If SaveEmployee(DbContext, Employee) Then

                        Inserted = True

                        Try

                            If Employee.TerminationDate Is Nothing Then

                                SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                                SettingValue.DataContext = DataContext

                                SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString
                                SettingValue.DisplayText = Employee.FirstName & " " & If(Employee.MiddleInitial <> "", Employee.MiddleInitial & ". ", "") & Employee.LastName
                                SettingValue.Value = Employee.Code

                                AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)

                            End If

                        Catch ex As Exception

                        End Try

                    End If

                End If

            Catch ex As Exception
                Inserted = False
                ErrorText = "Failed trying to insert into the database. Please contact software support."
            Finally

                If Initialized AndAlso Inserted = False Then

                    Delete(DbContext, DataContext, Employee.Code)

                End If

                If ErrorText <> "" Then

                    Throw New System.Exception(ErrorText)

                End If

                Insert = Inserted

            End Try

        End Function
        Public Function Initialize(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            Dim Initialized As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim InsertStatement As String = Nothing

            Try

				InsertStatement = String.Format("INSERT INTO dbo.EMPLOYEE (EMP_CODE, DP_TM_CODE, EMP_LNAME, EMP_FNAME, EMP_MI, IS_ACTIVE_FREELANCE, IGNORE_CALENDAR_SYNC) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6})",
												If(Employee.Code IsNot Nothing, "'" & Employee.Code.Replace("'", "''") & "'", "NULL"),
												If(Employee.DepartmentTeamCode IsNot Nothing AndAlso Employee.DepartmentTeamCode <> "", "'" & Employee.DepartmentTeamCode.Replace("'", "''") & "'", "NULL"),
												If(Employee.LastName IsNot Nothing, "'" & Employee.LastName.Replace("'", "''") & "'", "NULL"),
												If(Employee.FirstName IsNot Nothing, "'" & Employee.FirstName.Replace("'", "''") & "'", "NULL"),
												If(Employee.MiddleInitial IsNot Nothing, "'" & Employee.MiddleInitial.Replace("'", "''") & "'", "NULL"),
												If(Employee.IsActiveFreelance, 1, 0),
												If(Employee.IgnoreCalendarSync, 1, 0))

				DbContext.Employees.Add(Employee)

                ErrorText = Employee.ValidateEntity(IsValid)

                If IsValid Then

                    If DbContext.Database.ExecuteSqlCommand(InsertStatement) > 0 Then

                        Initialized = True

                    End If

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Initialized = False
            Finally
                Initialize = Initialized
            End Try

        End Function
        Public Function UpdateDirectHours(DbContext As AdvantageFramework.Database.DbContext, EmployeeCode As String, DirectHours As Decimal) As Boolean

            'objects
            Dim Updated As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMPLOYEE SET DIRECT_HRS_PER = {0} WHERE EMP_CODE = '{1}'", DirectHours, EmployeeCode))

                Updated = True

            Catch ex As Exception
                Updated = False
            End Try

            UpdateDirectHours = Updated

        End Function
        Public Function UpdateDirectHours(DbContext As AdvantageFramework.Database.DbContext, Employee As AdvantageFramework.Database.Views.Employee, DirectHours As Decimal) As Boolean

            UpdateDirectHours = UpdateDirectHours(DbContext, Employee.Code, DirectHours)

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Updated As Boolean = False
            Dim SettingValue As AdvantageFramework.Database.Entities.SettingValue = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Try

                ErrorText = Employee.ValidateEntity(IsValid)

                If IsValid Then

                    If SaveEmployee(DbContext, Employee) Then

                        Updated = True

                        Try

                            If Employee.TerminationDate IsNot Nothing Then

                                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString)

                                If Setting IsNot Nothing Then

                                    If Setting.Value <> Employee.Code Then

                                        AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString, Employee.Code.Replace("'", "''"))

                                    End If

                                End If

                            Else

                                If AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString).Any(Function(Entity) Entity.Value.ToString = Employee.Code) = False Then

                                    SettingValue = New AdvantageFramework.Database.Entities.SettingValue

                                    SettingValue.DataContext = DataContext

                                    SettingValue.SettingCode = AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString
                                    SettingValue.DisplayText = Employee.FirstName & " " & If(Employee.MiddleInitial <> "", Employee.MiddleInitial & ". ", "") & Employee.LastName
                                    SettingValue.Value = Employee.Code

                                    AdvantageFramework.Database.Procedures.SettingValue.Insert(DataContext, SettingValue)

                                Else

                                    SettingValue = AdvantageFramework.Database.Procedures.SettingValue.LoadBySettingCodeAndValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString, Employee.Code.ToString)
                                    SettingValue.DisplayText = Employee.FirstName & " " & If(Employee.MiddleInitial <> "", Employee.MiddleInitial & ". ", "") & Employee.LastName
                                    AdvantageFramework.Database.Procedures.SettingValue.Update(DataContext, SettingValue)

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                    End If

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Private Function SaveEmployee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            'objects
            Dim ErrorText As String = ""
            Dim Saved As Boolean = False
            Dim UpdateStatement As String = Nothing

            UpdateStatement = String.Format(" UPDATE dbo.EMPLOYEE SET " &
                                            " EMP_ACCOUNT_NBR = {0}, " &
                                            " EMP_ADDRESS1 = {1}, " &
                                            " EMP_ADDRESS2 = {2}, " &
                                            " ALERT_EMAIL = {3}, " &
                                            " PO_GL_SELECTION = {4}, " &
                                            " EMP_PHONE_ALT = {5}, " &
                                            " STD_ANNUAL_HRS = {6}, " &
                                            " EMP_ANNUAL_SALARY = {7}, " &
                                            " EMP_BIRTH_DATE = {8}, " &
                                            " EMP_PHONE_CELL = {9}, " &
                                            " EMP_CITY = {10}, " &
                                            " EMP_COMMENT = {11}, " &
                                            " EMP_COST_RATE = {12}, " &
                                            " EMP_COUNTRY = {13}, " &
                                            " EMP_COUNTY = {14}, " &
                                            " CC_DESC = {15}, " &
                                            " CC_GL_ACCOUNT = {16}, " &
                                            " CC_NUMBER = {17}, " &
                                            " DP_TM_CODE = {18}, " &
                                            " DIRECT_HRS_PER = {19}, " &
                                            " EMP_EMAIL = {20}, " &
                                            " EMAIL_PWD = {21}, " &
                                            " EMAIL_USERNAME = {22}, " &
                                            " EMPLOYEE_TITLE_ID = {23}, " &
                                            " VN_CODE_EXP = {24}, " &
                                            " EMP_END_TIME = {25}, " &
                                            " EMP_FNAME = {26}, " &
                                            " FREELANCE = {27}, " &
                                            " FRI_HRS = {28}, " &
                                            " DEF_FNC_CODE = {29}, " &
                                            " MISSING_TIME = {30}, " &
                                            " EMP_LAST_INCREASE = {31}, " &
                                            " LAST_MODIFIED_BY = {32}, " &
                                            " LAST_MODIFIED_DATE = {33}, " &
                                            " EMP_LNAME = {34}, " &
                                            " PO_GL_LIMIT_BY_OFFICE = {35}, " &
                                            " EMP_MI = {36}, " &
                                            " MON_HRS = {37}, " &
                                            " MTH_HRS_GOAL = {38}, " &
                                            " EMP_MONTHLY_SALARY = {39}, " &
                                            " EMP_NEXT_REVIEW = {40}, " &
                                            " OFFICE_CODE = {41}, " &
                                            " EMP_PAY_TO_ADDR1 = {42}, " &
                                            " EMP_PAY_TO_ADDR2 = {43}, " &
                                            " EMP_PAY_TO_CITY = {44}, " &
                                            " EMP_PAY_TO_COUNTRY = {45}, " &
                                            " EMP_PAY_TO_COUNTY = {46}, " &
                                            " EMP_PAY_TO_STATE = {47}, " &
                                            " EMP_PAY_TO_ZIP = {48}, " &
                                            " PERS_HRS = {49}, " &
                                            " PERS_FROM_DATE = {50}, " &
                                            " PERS_TO_DATE = {51}, " &
                                            " EMP_PHONE = {52}, " &
                                            " PO_APPR_RULE_CODE = {53}, " &
                                            " PO_LIMIT = {54}, " &
                                            " EMAIL_REPLY_TO = {55}, " &
                                            " DEF_TRF_ROLE = {56}, " &
                                            " SAT_HRS = {57}, " &
                                            " SENIORITY = {58}, " &
                                            " SICK_FROM_DATE = {59}, " &
                                            " SICK_TO_DATE = {60}, " &
                                            " SICK_HRS = {61}, " &
                                            " SMTP_SERVER = {62}, " &
                                            " EMP_OTHER_INFO = {63}, " &
                                            " STD_WORK_HRS = {64}, " &
                                            " EMP_DATE = {65}, " &
                                            " EMP_START_TIME = {66}, " &
                                            " EMP_STATE = {67}, " &
                                            " STATUS = {68}, " &
                                            " SUN_HRS = {69}, " &
                                            " EXP_APPR_REQ = {70}, " &
                                            " SUPERVISOR_CODE = {71}, " &
                                            " EMP_TERM_DATE = {72}, " &
                                            " THU_HRS = {73}, " &
                                            " EMP_TIME_ALERT = {74}, " &
                                            " TUE_HRS = {75}, " &
                                            " VAC_FROM_DATE = {76}, " &
                                            " VAC_TO_DATE = {77}, " &
                                            " VAC_HRS = {78}, " &
                                            " WED_HRS = {79}, " &
                                            " WEEKLY_TIME = {80}, " &
                                            " EMP_WORK_DAYS = {81}, " &
                                            " EMP_PHONE_WORK = {82}, " &
                                            " EMP_PHONE_WORK_EXT = {83}, " &
                                            " EMP_ZIP = {84}, " &
                                            " EXP_RPT_APPROVER = {85}, " &
                                            " ALT_COST_RATE = {86}, " &
                                            " ALT_DATE_FRM = {87}, " &
                                            " ALT_DATE_TO = {88}, " &
                                            " EMP_END_TIME_FRI = {89}, " &
                                            " EMP_START_TIME_FRI = {90}, " &
                                            " EMP_END_TIME_MON = {91}, " &
                                            " EMP_START_TIME_MON = {92}, " &
                                            " PERS_TIME_RULE_ID = {93}, " &
                                            " SICK_TIME_RULE_ID  = {94}, " &
                                            " VAC_TIME_RULE_ID = {95}, " &
                                            " EMP_END_TIME_SAT = {96}, " &
                                            " EMP_START_TIME_SAT = {97}, " &
                                            " EMP_END_TIME_SUN = {98}, " &
                                            " EMP_START_TIME_SUN = {99}, " &
                                            " EMP_END_TIME_THU = {100}, " &
                                            " EMP_START_TIME_THU = {101}, " &
                                            " EMP_END_TIME_TUE = {102}, " &
                                            " EMP_START_TIME_TUE = {103}, " &
                                            " EMP_END_TIME_WED = {104}, " &
                                            " EMP_START_TIME_WED = {105}, " &
                                            " SIGNATURE_PATH = {106}, " &
                                            " EMP_CODE = {107}, " &
                                            " TS_APPR_FLAG = {108}, " &
                                            " IS_ACTIVE_FREELANCE = {109}, " &
                                            " SUGAR_USERNAME = {110}, " &
                                            " SUGAR_PASSWORD = {111}, " &
                                            " PROOFHQ_USERNAME = {112}, " &
                                            " PROOFHQ_PASSWORD = {113}, " &
                                            " IS_API_USER = {114}, " &
                                            " ADOBE_SIGNATURE_FILE_PASSWORD = {115}, " &
                                            " VCC_USERNAME = {116}, " &
                                            " VCC_PASSWORD = {117}, " &
                                            " EMP_OMIT_MISSING = {118}, " &
                                            " IGNORE_CALENDAR_SYNC = {119}, " &
                                            " CAL_TIME_TYPE = {120}, " &
                                            " CAL_TIME_EMAIL = {121}, " &
                                            " CAL_TIME_USERNAME = {122}, " &
                                            " CAL_TIME_PASSWORD = {123}, " &
                                            " CAL_TIME_HOST = {124}, " &
                                            " CAL_TIME_PORT = {125}, " &
                                            " CAL_TIME_SSL = {126}, " &
                                            " BILLABLE_HOURS_GOAL = {127} " &
                                            " WHERE EMP_CODE  = {128}",
                                            If(Employee.AccountNumber IsNot Nothing AndAlso Employee.AccountNumber <> "", "'" & Employee.AccountNumber.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.Address IsNot Nothing AndAlso Employee.Address <> "", "'" & Employee.Address.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.Address2 IsNot Nothing AndAlso Employee.Address2 <> "", "'" & Employee.Address2.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.AlertNotificationType IsNot Nothing, Employee.AlertNotificationType.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.AllowPOGLSelection IsNot Nothing, Employee.AllowPOGLSelection.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.AlternatePhoneNumber IsNot Nothing AndAlso Employee.AlternatePhoneNumber <> "", "'" & Employee.AlternatePhoneNumber.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.AnnualHours IsNot Nothing, Employee.AnnualHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.AnnualSalary IsNot Nothing, Employee.AnnualSalary.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.BirthDate IsNot Nothing, "'" & Employee.BirthDate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.CellPhoneNumber IsNot Nothing AndAlso Employee.CellPhoneNumber <> "", "'" & Employee.CellPhoneNumber.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.City IsNot Nothing AndAlso Employee.City <> "", "'" & Employee.City.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.Comments IsNot Nothing AndAlso Employee.Comments <> "", "'" & Employee.Comments.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.CostRate IsNot Nothing, Employee.CostRate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.Country IsNot Nothing AndAlso Employee.Country <> "", "'" & Employee.Country.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.County IsNot Nothing AndAlso Employee.County <> "", "'" & Employee.County.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.CreditCardDescription IsNot Nothing AndAlso Employee.CreditCardDescription <> "", "'" & Employee.CreditCardDescription.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.CreditCardGLAccount IsNot Nothing AndAlso Employee.CreditCardGLAccount <> "", "'" & Employee.CreditCardGLAccount.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.CreditCardNumber IsNot Nothing AndAlso Employee.CreditCardNumber <> "", "'" & Employee.CreditCardNumber.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.DepartmentTeamCode IsNot Nothing AndAlso Employee.DepartmentTeamCode <> "", "'" & Employee.DepartmentTeamCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.DirectHours IsNot Nothing, Employee.DirectHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.Email IsNot Nothing AndAlso Employee.Email <> "", "'" & Employee.Email.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.EmailPassword IsNot Nothing AndAlso Employee.EmailPassword <> "", "'" & Employee.EmailPassword.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.EmailUserName IsNot Nothing AndAlso Employee.EmailUserName <> "", "'" & Employee.EmailUserName.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.EmployeeTitleID IsNot Nothing, Employee.EmployeeTitleID.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.EmployeeVendorCode IsNot Nothing AndAlso Employee.EmployeeVendorCode <> "", "'" & Employee.EmployeeVendorCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.EndTime IsNot Nothing, "'" & Employee.EndTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.FirstName IsNot Nothing AndAlso Employee.FirstName <> "", "'" & Employee.FirstName.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.Freelance IsNot Nothing, Employee.Freelance.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.FridayHours IsNot Nothing, Employee.FridayHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.FunctionCode IsNot Nothing AndAlso Employee.FunctionCode <> "", "'" & Employee.FunctionCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.IsMissingTime IsNot Nothing, Employee.IsMissingTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.LastIncrease IsNot Nothing, "'" & Employee.LastIncrease.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.LastModifiedByUserCode IsNot Nothing AndAlso Employee.LastModifiedByUserCode <> "", "'" & Employee.LastModifiedByUserCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.LastModifiedDate IsNot Nothing, "'" & Employee.LastModifiedDate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.LastName IsNot Nothing AndAlso Employee.LastName <> "", "'" & Employee.LastName.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.LimitPOGLSelectionOffice IsNot Nothing, Employee.LimitPOGLSelectionOffice.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.MiddleInitial IsNot Nothing AndAlso Employee.MiddleInitial <> "", "'" & Employee.MiddleInitial.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.MondayHours IsNot Nothing, Employee.MondayHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.MonthHoursGoal IsNot Nothing, Employee.MonthHoursGoal.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.MonthlySalary IsNot Nothing, Employee.MonthlySalary.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.NextReview IsNot Nothing, "'" & Employee.NextReview.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.OfficeCode IsNot Nothing AndAlso Employee.OfficeCode <> "", "'" & Employee.OfficeCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PayToAddress IsNot Nothing AndAlso Employee.PayToAddress <> "", "'" & Employee.PayToAddress.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PayToAddress2 IsNot Nothing AndAlso Employee.PayToAddress2 <> "", "'" & Employee.PayToAddress2.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PayToCity IsNot Nothing AndAlso Employee.PayToCity <> "", "'" & Employee.PayToCity.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PayToCountry IsNot Nothing AndAlso Employee.PayToCountry <> "", "'" & Employee.PayToCountry.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PayToCounty IsNot Nothing AndAlso Employee.PayToCounty <> "", "'" & Employee.PayToCounty.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PayToState IsNot Nothing AndAlso Employee.PayToState <> "", "'" & Employee.PayToState.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PayToZip IsNot Nothing AndAlso Employee.PayToZip <> "", "'" & Employee.PayToZip.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PersonalHours IsNot Nothing, Employee.PersonalHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.PersonalHoursDateFrom IsNot Nothing, "'" & Employee.PersonalHoursDateFrom.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.PersonalHoursDateTo IsNot Nothing, "'" & Employee.PersonalHoursDateTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.PhoneNumber IsNot Nothing AndAlso Employee.PhoneNumber <> "", "'" & Employee.PhoneNumber.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PurchaseOrderApprovalRuleCode IsNot Nothing AndAlso Employee.PurchaseOrderApprovalRuleCode <> "", "'" & Employee.PurchaseOrderApprovalRuleCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.PurchaseOrderLimit IsNot Nothing, Employee.PurchaseOrderLimit.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.ReplyToEmail IsNot Nothing AndAlso Employee.ReplyToEmail <> "", "'" & Employee.ReplyToEmail.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.RoleCode IsNot Nothing AndAlso Employee.RoleCode <> "", "'" & Employee.RoleCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.SaturdayHours IsNot Nothing, Employee.SaturdayHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.Seniority IsNot Nothing, Employee.Seniority.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.SickDateFrom IsNot Nothing, "'" & Employee.SickDateFrom.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.SickDateTo IsNot Nothing, "'" & Employee.SickDateTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.SickHours IsNot Nothing, Employee.SickHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.SMTPServer IsNot Nothing AndAlso Employee.SMTPServer <> "", "'" & Employee.SMTPServer.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.OtherInfo IsNot Nothing AndAlso Employee.OtherInfo <> "", "'" & Employee.OtherInfo.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.StandardWorkHours IsNot Nothing, Employee.StandardWorkHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.StartDate IsNot Nothing, "'" & Employee.StartDate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.StartTime IsNot Nothing, "'" & Employee.StartTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.State IsNot Nothing AndAlso Employee.State <> "", "'" & Employee.State.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.Status IsNot Nothing, Employee.Status.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.SundayHours IsNot Nothing, Employee.SundayHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.SupervisorApprovalRequired IsNot Nothing, Employee.SupervisorApprovalRequired.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.SupervisorEmployeeCode IsNot Nothing AndAlso Employee.SupervisorEmployeeCode <> "", "'" & Employee.SupervisorEmployeeCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.TerminationDate IsNot Nothing, "'" & Employee.TerminationDate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.ThursdayHours IsNot Nothing, Employee.ThursdayHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.TimeAlert IsNot Nothing, Employee.TimeAlert.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.TuesdayHours IsNot Nothing, Employee.TuesdayHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.VacationDateFrom IsNot Nothing, "'" & Employee.VacationDateFrom.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.VacationDateTo IsNot Nothing, "'" & Employee.VacationDateTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.VacationHours IsNot Nothing, Employee.VacationHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.WednesdayHours IsNot Nothing, Employee.WednesdayHours.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.WeeklyTimeType IsNot Nothing, Employee.WeeklyTimeType.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.WorkDays IsNot Nothing AndAlso Employee.WorkDays <> "", "'" & Employee.WorkDays.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.WorkPhoneNumber IsNot Nothing AndAlso Employee.WorkPhoneNumber <> "", "'" & Employee.WorkPhoneNumber.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.WorkPhoneNumberExtension IsNot Nothing AndAlso Employee.WorkPhoneNumberExtension <> "", "'" & Employee.WorkPhoneNumberExtension.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.Zip IsNot Nothing AndAlso Employee.Zip <> "", "'" & Employee.Zip.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.AlternateApproverCode IsNot Nothing AndAlso Employee.AlternateApproverCode <> "", "'" & Employee.AlternateApproverCode.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.AlternateCostRate IsNot Nothing, Employee.AlternateCostRate.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.AlternateDateFrom IsNot Nothing, "'" & Employee.AlternateDateFrom.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.AlternateDateTo IsNot Nothing, "'" & Employee.AlternateDateTo.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.FridayEndTime IsNot Nothing, "'" & Employee.FridayEndTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.FridayStartTime IsNot Nothing, "'" & Employee.FridayStartTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.MondayEndTime IsNot Nothing, "'" & Employee.MondayEndTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.MondayStartTime IsNot Nothing, "'" & Employee.MondayStartTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.PersonalTimeRule IsNot Nothing, Employee.PersonalTimeRule.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.SickTimeRule IsNot Nothing, Employee.SickTimeRule.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.VacationTimeRule IsNot Nothing, Employee.VacationTimeRule.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.SaturdayEndTime IsNot Nothing, "'" & Employee.SaturdayEndTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.SaturdayStartTime IsNot Nothing, "'" & Employee.SaturdayStartTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.SundayEndTime IsNot Nothing, "'" & Employee.SundayEndTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.SundayStartTime IsNot Nothing, "'" & Employee.SundayStartTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.ThursdayEndTime IsNot Nothing, "'" & Employee.ThursdayEndTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.ThursdayStartTime IsNot Nothing, "'" & Employee.ThursdayStartTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.TuesdayEndTime IsNot Nothing, "'" & Employee.TuesdayEndTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.TuesdayStartTime IsNot Nothing, "'" & Employee.TuesdayStartTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.WednesdayEndTime IsNot Nothing, "'" & Employee.WednesdayEndTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.WednesdayStartTime IsNot Nothing, "'" & Employee.WednesdayStartTime.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) & "'", "NULL"),
                                            If(Employee.SignaturePath IsNot Nothing AndAlso Employee.SignaturePath <> "", "'" & Employee.SignaturePath.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.Code IsNot Nothing, "'" & Employee.Code.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.TimesheetApprovalFlag.HasValue, If(Employee.TimesheetApprovalFlag.Value, 1, 0), "NULL"),
                                            If(IsNothing(Employee.IsActiveFreelance) = False, CShort(If(Employee.IsActiveFreelance, 1, 0)), CShort(0)),
                                            If(Employee.SugarCRMUserName IsNot Nothing, "'" & Employee.SugarCRMUserName & "'", "NULL"),
                                            If(Employee.SugarCRMPassword IsNot Nothing, "'" & Employee.SugarCRMPassword & "'", "NULL"),
                                            If(Employee.ProofHQUserName IsNot Nothing, "'" & Employee.ProofHQUserName & "'", "NULL"),
                                            If(Employee.ProofHQPassword IsNot Nothing, "'" & Employee.ProofHQPassword & "'", "NULL"),
                                            If(Employee.IsAPIUser IsNot Nothing, "'" & Employee.IsAPIUser & "'", "NULL"),
                                            If(Employee.AdobeSignatureFilePassword IsNot Nothing, "'" & Employee.AdobeSignatureFilePassword & "'", "NULL"),
                                            If(Employee.VCCUserName IsNot Nothing, "'" & Employee.VCCUserName & "'", "NULL"),
                                            If(Employee.VCCPassword IsNot Nothing, "'" & Employee.VCCPassword & "'", "NULL"),
                                            If(Employee.OmitFromMissingTimeTracking IsNot Nothing, Employee.OmitFromMissingTimeTracking.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.IgnoreCalendarSync, 1, 0),
                                            If(Employee.CalendarTimeType.HasValue, Employee.CalendarTimeType.Value, "NULL"),
                                            If(Employee.CalendarTimeEmailAddress IsNot Nothing AndAlso Employee.CalendarTimeEmailAddress <> "", "'" & Employee.CalendarTimeEmailAddress.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.CalendarTimeUserName IsNot Nothing AndAlso Employee.CalendarTimeUserName <> "", "'" & Employee.CalendarTimeUserName.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.CalendarTimePassword IsNot Nothing AndAlso Employee.CalendarTimePassword <> "", "'" & Employee.CalendarTimePassword.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.CalendarTimeHost IsNot Nothing AndAlso Employee.CalendarTimeHost <> "", "'" & Employee.CalendarTimeHost.Replace("'", "''") & "'", "NULL"),
                                            If(Employee.CalendarTimePort IsNot Nothing, Employee.CalendarTimePort.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            If(Employee.CalendarTimeSSL, 1, 0),
                                            If(Employee.BillableHoursGoal IsNot Nothing, Employee.BillableHoursGoal.Value.ToString(System.Globalization.CultureInfo.InvariantCulture), "NULL"),
                                            "'" & Employee.Code.Replace("'", "''") & "'")

            Try

                If DbContext.Database.ExecuteSqlCommand(UpdateStatement) > 0 Then

                    Try

                        If Employee.SignatureImage IsNot Nothing Then

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET [EMP_SIG] = {0} WHERE [EMP_CODE] = {1}", Employee.SignatureImage, Employee.Code.Replace("'", "''"))

                        Else

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET [EMP_SIG] = NULL WHERE [EMP_CODE] = {0}", Employee.Code.Replace("'", "''"))

                        End If

                    Catch ex As Exception

                    End Try

                    Try

                        If Employee.AdobeSignatureFile IsNot Nothing Then

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET [ADOBE_SIGNATURE_FILE] = {0} WHERE [EMP_CODE] = {1}", Employee.AdobeSignatureFile, Employee.Code.Replace("'", "''"))

                        Else

                            DbContext.Database.ExecuteSqlCommand("UPDATE dbo.EMPLOYEE SET [ADOBE_SIGNATURE_FILE] = NULL WHERE [EMP_CODE] = {0}", Employee.Code.Replace("'", "''"))

                        End If

                    Catch ex As Exception

                    End Try

                    Saved = True

                End If

            Catch ex As Exception
                Saved = False
            Finally
                SaveEmployee = Saved
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment = Nothing
            Dim AlertGroup As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim EmployeeRole As AdvantageFramework.Database.Entities.EmployeeRole = Nothing

            Try

                If DbContext.Database.ExecuteSqlCommand(String.Format("EXEC dbo.advsp_delete_employee '{0}', 0", EmployeeCode.Replace("'", "''"))) > 0 Then

                    Deleted = True

                    For Each EmployeeDepartment In AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByEmployeeCode(DbContext, EmployeeCode).ToList

                        Try

                            DbContext.DeleteEntityObject(EmployeeDepartment)

                        Catch ex As Exception

                        End Try

                    Next

                    For Each EmployeeRole In AdvantageFramework.Database.Procedures.EmployeeRole.LoadByEmployeeCode(DbContext, EmployeeCode).ToList

                        Try

                            DbContext.DeleteEntityObject(EmployeeRole)

                        Catch ex As Exception

                        End Try

                    Next

                    For Each AlertGroup In AdvantageFramework.Database.Procedures.AlertGroup.LoadByEmployeeCode(DbContext, EmployeeCode).ToList

                        Try

                            DbContext.DeleteEntityObject(AlertGroup)

                        Catch ex As Exception

                        End Try

                    Next

                    Try

                        DbContext.SaveChanges()

                    Catch ex As Exception

                    End Try

                    Try

                        AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString, EmployeeCode.Replace("'", "''"))

                    Catch ex As Exception

                    End Try

                End If

            Catch ex As Exception
                Deleted = False
            End Try

            Delete = Deleted

        End Function
        Public Function Terminate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal Employee As AdvantageFramework.Database.Views.Employee, ByVal RemoveSecuritySettings As Boolean, ByRef ErrorText As String) As Boolean

            'objects
            Dim Terminated As Boolean = False
            Dim SercuritySettingsQueries As System.Collections.Generic.List(Of String) = Nothing
            Dim MediaBuyerQueries As System.Collections.Generic.List(Of String) = Nothing
            Dim IsValid As Boolean = True

            Try

                ErrorText = Employee.ValidateEntity(IsValid)

                If IsValid Then

                    If SaveEmployee(DbContext, Employee) Then

                        If RemoveSecuritySettings Then

                            SercuritySettingsQueries = New System.Collections.Generic.List(Of String)
                            SercuritySettingsQueries.Add(String.Format("DELETE FROM dbo.WV_USER_TABS WHERE USERID IN (SELECT USER_CODE FROM dbo.SEC_USER WHERE EMP_CODE ='{0}')", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("UPDATE dbo.EMPLOYEE_CLOAK SET WV_TMPLT_HDR_ID = NULL WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("DELETE FROM dbo.APPR_PASSWORD WHERE ACCT_EXEC = '{0}'", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("DELETE FROM dbo.QTE_APP_PWD WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("DELETE FROM dbo.EMAIL_GROUP WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("DELETE FROM dbo.EMP_TRAFFIC_ROLE WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("DELETE FROM dbo.EMP_TS_FNC WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("DELETE FROM dbo.EMP_OFFICE WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("DELETE FROM dbo.SEC_GROUP_USER WHERE SEC_USER_ID IN (SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE EMP_CODE ='{0}')", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("UPDATE dbo.SEC_USER_SETTING SET STRING_VALUE = NULL WHERE SEC_USER_ID IN ( SELECT SEC_USER_ID FROM dbo.SEC_USER WHERE EMP_CODE ='{0}')", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("UPDATE dbo.SEC_USER SET IS_INACTIVE = 1 WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))
                            SercuritySettingsQueries.Add(String.Format("UPDATE dbo.SEC_USER SET [PASSWORD] = '' WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))

                            For Each SecuritySettingsQuery In SercuritySettingsQueries.OfType(Of String)()

                                Try

                                    DbContext.Database.ExecuteSqlCommand(SecuritySettingsQuery)

                                Catch ex As Exception

                                End Try

                            Next

                        End If

                        MediaBuyerQueries = New System.Collections.Generic.List(Of String)
                        MediaBuyerQueries.Add(String.Format("UPDATE dbo.MEDIA_BUYER SET IS_INACTIVE = 1 WHERE EMP_CODE = '{0}'", Employee.Code.Replace("'", "''")))

                        For Each MediaBuyerQuery In MediaBuyerQueries.OfType(Of String)()

                            Try

                                DbContext.Database.ExecuteSqlCommand(MediaBuyerQuery)

                            Catch ex As Exception

                            End Try

                        Next

                        Terminated = True

                        Try

                            AdvantageFramework.Database.Procedures.SettingValue.DeleteBySettingCodeAndLookupValue(DataContext, AdvantageFramework.Agency.Settings.JR_DFLT_CONTACT.ToString, Employee.Code.Replace("'", "''"))

                        Catch ex As Exception

                        End Try

                    Else

                        ErrorText = "Failed saving employee data."

                    End If

                End If

            Catch ex As Exception
                Terminated = False
                ErrorText = ex.Message
            End Try

            Terminate = Terminated

        End Function

#End Region

    End Module

End Namespace
