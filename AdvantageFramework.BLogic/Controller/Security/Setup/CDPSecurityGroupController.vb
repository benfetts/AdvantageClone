Namespace Controller.Security.Setup

    Public Class CDPSecurityGroupController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load(CDPSecurityGroupID As Integer) As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel

            'objects
            Dim CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel = Nothing
            Dim CDPSecurityGroup As AdvantageFramework.Database.Entities.CDPSecurityGroup = Nothing
            Dim Employee As AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee = Nothing
            Dim CDP As AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP = Nothing

            CDPSecurityGroupViewModel = New AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                CDPSecurityGroupViewModel.Employees = DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).Include("Office").Include("DepartmentTeam").ToList.
                                                        Select(Function(Entity) New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee(Entity)).ToList

                CDPSecurityGroupViewModel.CDPs = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).Include("Office").Include("Client").Include("Division").
                                                   Select(Function(Entity) New With {.CDPSecurityGroupID = Entity.CDPSecurityGroupID,
                                                                                     .OfficeCode = Entity.OfficeCode,
                                                                                     .OfficeName = Entity.Office.Name,
                                                                                     .ClientCode = Entity.ClientCode,
                                                                                     .ClientName = Entity.Client.Name,
                                                                                     .ClientIsActive = Entity.Client.IsActive,
                                                                                     .DivisionCode = Entity.DivisionCode,
                                                                                     .DivisionName = Entity.Division.Name,
                                                                                     .DivisionIsActive = Entity.Division.IsActive,
                                                                                     .ProductCode = Entity.Code,
                                                                                     .ProductName = Entity.Name,
                                                                                     .IsActive = Entity.IsActive}).ToList.
                                                   Select(Function(Entity) New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP With {.CDPSecurityGroupID = Entity.CDPSecurityGroupID.GetValueOrDefault(0),
                                                                                                                                            .OfficeCode = Entity.OfficeCode,
                                                                                                                                            .OfficeName = Entity.OfficeName,
                                                                                                                                            .ClientCode = Entity.ClientCode,
                                                                                                                                            .ClientName = Entity.ClientName,
                                                                                                                                            .DivisionCode = Entity.DivisionCode,
                                                                                                                                            .DivisionName = Entity.DivisionName,
                                                                                                                                            .ProductCode = Entity.ProductCode,
                                                                                                                                            .ProductName = Entity.ProductName,
                                                                                                                                            .IsActive = CBool(If(Entity.ClientIsActive.GetValueOrDefault(0) = 1 AndAlso Entity.DivisionIsActive.GetValueOrDefault(0) = 1, Entity.IsActive.GetValueOrDefault(0), 0))}).ToList

                If CDPSecurityGroupID > 0 Then

                    CDPSecurityGroup = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.CDPSecurityGroup).Include("CDPSecurityGroupEmployees").SingleOrDefault(Function(Entity) Entity.ID = CDPSecurityGroupID)

                    If CDPSecurityGroup IsNot Nothing Then

                        CDPSecurityGroupViewModel.CDPSecurityGroup = New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup(CDPSecurityGroup)

                        CDPSecurityGroupViewModel.AvailableEmployees.AddRange(CDPSecurityGroupViewModel.Employees.ToList)

                        For Each CDPSecurityGroupEmployee In CDPSecurityGroup.CDPSecurityGroupEmployees

                            CDPSecurityGroupViewModel.CDPSecurityGroupEmployees.Add(New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroupEmployee(CDPSecurityGroupEmployee))

                            Try

                                Employee = CDPSecurityGroupViewModel.AvailableEmployees.SingleOrDefault(Function(Entity) Entity.EmployeeCode = CDPSecurityGroupEmployee.EmployeeCode)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                Employee.CDPSecurityGroupID = CDPSecurityGroupID

                                CDPSecurityGroupViewModel.AvailableEmployees.Remove(Employee)
                                CDPSecurityGroupViewModel.GroupEmployees.Add(Employee)

                            End If

                        Next

                        For Each [Employee] In CDPSecurityGroupViewModel.AvailableEmployees

                            Employee.CDPSecurityGroupID = 0

                        Next

                        CDPSecurityGroupViewModel.AvailableCDPs.AddRange(CDPSecurityGroupViewModel.CDPs.ToList)

                        For Each CDP In CDPSecurityGroupViewModel.AvailableCDPs.Where(Function(Entity) Entity.CDPSecurityGroupID = CDPSecurityGroupID).ToList

                            CDPSecurityGroupViewModel.AvailableCDPs.Remove(CDP)
                            CDPSecurityGroupViewModel.GroupCDPs.Add(CDP)

                        Next

                        For Each CDP In CDPSecurityGroupViewModel.AvailableCDPs.Where(Function(Entity) Entity.CDPSecurityGroupID <> 0).ToList

                            CDPSecurityGroupViewModel.AvailableCDPs.Remove(CDP)

                        Next

                    End If

                Else

                    CDPSecurityGroupViewModel.CDPSecurityGroup = New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup()
                    CDPSecurityGroupViewModel.CDPSecurityGroupEmployees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroupEmployee)

                    CDPSecurityGroupViewModel.AvailableEmployees.AddRange(CDPSecurityGroupViewModel.Employees.ToList)
                    CDPSecurityGroupViewModel.AvailableCDPs.AddRange(CDPSecurityGroupViewModel.CDPs.ToList)

                End If

            End Using

            Load = CDPSecurityGroupViewModel

        End Function
        Public Function Load(CDPSecurityGroupID As Integer, Employees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee),
                             CDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP)) As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel

            'objects
            Dim CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel = Nothing
            Dim CDPSecurityGroup As AdvantageFramework.Database.Entities.CDPSecurityGroup = Nothing
            Dim Employee As AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee = Nothing
            Dim CDP As AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP = Nothing

            CDPSecurityGroupViewModel = New AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                CDPSecurityGroupViewModel.Employees = Employees

                CDPSecurityGroupViewModel.CDPs = CDPs

                If CDPSecurityGroupID > 0 Then

                    CDPSecurityGroup = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.CDPSecurityGroup).Include("CDPSecurityGroupEmployees").SingleOrDefault(Function(Entity) Entity.ID = CDPSecurityGroupID)

                    If CDPSecurityGroup IsNot Nothing Then

                        CDPSecurityGroupViewModel.CDPSecurityGroup = New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup(CDPSecurityGroup)

                        CDPSecurityGroupViewModel.AvailableEmployees.AddRange(CDPSecurityGroupViewModel.Employees.ToList)

                        For Each CDPSecurityGroupEmployee In CDPSecurityGroup.CDPSecurityGroupEmployees

                            CDPSecurityGroupViewModel.CDPSecurityGroupEmployees.Add(New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroupEmployee(CDPSecurityGroupEmployee))

                            Try

                                Employee = CDPSecurityGroupViewModel.AvailableEmployees.SingleOrDefault(Function(Entity) Entity.EmployeeCode = CDPSecurityGroupEmployee.EmployeeCode)

                            Catch ex As Exception
                                Employee = Nothing
                            End Try

                            If Employee IsNot Nothing Then

                                Employee.CDPSecurityGroupID = CDPSecurityGroupID

                                CDPSecurityGroupViewModel.AvailableEmployees.Remove(Employee)
                                CDPSecurityGroupViewModel.GroupEmployees.Add(Employee)

                            End If

                        Next

                        For Each [Employee] In CDPSecurityGroupViewModel.AvailableEmployees

                            Employee.CDPSecurityGroupID = 0

                        Next

                        CDPSecurityGroupViewModel.AvailableCDPs.AddRange(CDPSecurityGroupViewModel.CDPs.ToList)

                        For Each CDP In CDPSecurityGroupViewModel.AvailableCDPs.Where(Function(Entity) Entity.CDPSecurityGroupID = CDPSecurityGroupID).ToList

                            CDPSecurityGroupViewModel.AvailableCDPs.Remove(CDP)
                            CDPSecurityGroupViewModel.GroupCDPs.Add(CDP)

                        Next

                        For Each CDP In CDPSecurityGroupViewModel.AvailableCDPs.Where(Function(Entity) Entity.CDPSecurityGroupID <> 0).ToList

                            CDPSecurityGroupViewModel.AvailableCDPs.Remove(CDP)

                        Next

                    End If

                Else

                    CDPSecurityGroupViewModel.CDPSecurityGroup = New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup()
                    CDPSecurityGroupViewModel.CDPSecurityGroupEmployees = New Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroupEmployee)

                    CDPSecurityGroupViewModel.AvailableEmployees.AddRange(CDPSecurityGroupViewModel.Employees.ToList)

                    For Each [Employee] In CDPSecurityGroupViewModel.AvailableEmployees

                        Employee.CDPSecurityGroupID = 0

                    Next

                    CDPSecurityGroupViewModel.AvailableCDPs.AddRange(CDPSecurityGroupViewModel.CDPs.ToList)

                End If

            End Using

            Load = CDPSecurityGroupViewModel

        End Function
        Public Function Add(ByRef CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel, CDPSecurityGroupName As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim CDPSecurityGroup As AdvantageFramework.Database.Entities.CDPSecurityGroup = Nothing
            Dim CDPSecurityGroupEmployee As AdvantageFramework.Database.Entities.CDPSecurityGroupEmployee = Nothing
            Dim CDPSecurityGroupID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                DbTransaction = DbContext.Database.BeginTransaction

                Try

                    CDPSecurityGroup = New AdvantageFramework.Database.Entities.CDPSecurityGroup

                    CDPSecurityGroup.Name = CDPSecurityGroupName

                    DbContext.CDPSecurityGroups.Add(CDPSecurityGroup)

                    DbContext.Configuration.AutoDetectChangesEnabled = True

                    Added = (DbContext.SaveChanges() > 0)

                Catch ex As Exception

                    Added = False

                    ErrorMessage = ex.Message

                Finally

                    If Added Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                End Try

            End Using

            Add = Added

        End Function
        Public Function Save(ByRef CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim CDPSecurityGroup As AdvantageFramework.Database.Entities.CDPSecurityGroup = Nothing
            Dim CDPSecurityGroupEmployee As AdvantageFramework.Database.Entities.CDPSecurityGroupEmployee = Nothing
            Dim Employee As AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                DbTransaction = DbContext.Database.BeginTransaction

                Try

                    CDPSecurityGroup = DbContext.CDPSecurityGroups.Find(CDPSecurityGroupViewModel.CDPSecurityGroup.ID)

                    DbContext.Entry(CDPSecurityGroup).Collection(Function(Entity) Entity.CDPSecurityGroupEmployees).Load()

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM 
	                                                                        dbo.SEC_CLIENT 
                                                                        WHERE 
	                                                                        CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE IN (SELECT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE FROM dbo.PRODUCT WHERE CDP_GROUP_ID = {0})
	                                                                        AND USER_ID IN (SELECT USER_CODE FROM dbo.SEC_USER WHERE EMP_CODE IN (SELECT EMP_CODE FROM dbo.CDP_GROUP_EMPLOYEE WHERE CDP_GROUP_ID = {0}))", CDPSecurityGroup.ID))

                    CDPSecurityGroup.Name = CDPSecurityGroupViewModel.CDPSecurityGroup.Name

                    For Each [Employee] In CDPSecurityGroupViewModel.AvailableEmployees.Where(Function(Entity) Entity.CDPSecurityGroupID = CDPSecurityGroup.ID).ToList

                        DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CDP_GROUP_EMPLOYEE WHERE CDP_GROUP_ID = {0} AND EMP_CODE = '{1}'", Employee.CDPSecurityGroupID, Employee.EmployeeCode))

                        Employee.CDPSecurityGroupID = 0

                    Next

                    For Each [Employee] In CDPSecurityGroupViewModel.GroupEmployees.ToList

                        If Employee.CDPSecurityGroupID <> CDPSecurityGroup.ID Then

                            Employee.CDPSecurityGroupID = CDPSecurityGroup.ID

                            CDPSecurityGroupEmployee = New AdvantageFramework.Database.Entities.CDPSecurityGroupEmployee

                            CDPSecurityGroupEmployee.CDPSecurityGroupID = CDPSecurityGroup.ID
                            CDPSecurityGroupEmployee.EmployeeCode = [Employee].EmployeeCode

                            DbContext.CDPSecurityGroupEmployees.Add(CDPSecurityGroupEmployee)

                        End If

                    Next

                    For Each CDP In CDPSecurityGroupViewModel.AvailableCDPs.Where(Function(Entity) Entity.CDPSecurityGroupID = CDPSecurityGroup.ID).ToList

                        CDP.CDPSecurityGroupID = 0

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PRODUCT SET CDP_GROUP_ID = NULL WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}'", CDP.ClientCode, CDP.DivisionCode, CDP.ProductCode))

                    Next

                    For Each CDP In CDPSecurityGroupViewModel.GroupCDPs.ToList

                        If CDP.CDPSecurityGroupID <> CDPSecurityGroup.ID Then

                            CDP.CDPSecurityGroupID = CDPSecurityGroup.ID

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PRODUCT SET CDP_GROUP_ID = {3} WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}'", CDP.ClientCode, CDP.DivisionCode, CDP.ProductCode, CDP.CDPSecurityGroupID))

                        End If

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True

                    DbContext.SaveChanges()

                    DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.SEC_CLIENT([USER_ID], CL_CODE, DIV_CODE, PRD_CODE)	
                                                                        SELECT 
	                                                                        SU.USER_CODE,
	                                                                        P.CL_CODE, 
	                                                                        P.DIV_CODE, 
	                                                                        P.PRD_CODE
                                                                        FROM 
	                                                                        dbo.SEC_USER SU CROSS JOIN
	                                                                        dbo.PRODUCT P
                                                                        WHERE
	                                                                        SU.EMP_CODE IN (SELECT EMP_CODE FROM dbo.CDP_GROUP_EMPLOYEE WHERE CDP_GROUP_ID = {0}) AND
	                                                                        P.CDP_GROUP_ID = {0} AND
                                                                            P.CL_CODE + '|' + P.DIV_CODE + '|' + P.PRD_CODE NOT IN (SELECT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE FROM dbo.SEC_CLIENT WHERE [USER_ID] = SU.USER_CODE)", CDPSecurityGroup.ID))

                    Saved = True

                Catch ex As Exception

                    Saved = False

                    ErrorMessage = ex.Message

                Finally

                    If Saved Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                End Try

            End Using

            Save = Saved

        End Function
        Public Function Delete(ByRef CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim CDPSecurityGroup As AdvantageFramework.Database.Entities.CDPSecurityGroup = Nothing
            Dim CDPSecurityGroupEmployee As AdvantageFramework.Database.Entities.CDPSecurityGroupEmployee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                DbTransaction = DbContext.Database.BeginTransaction

                Try

                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM 
	                                                                        dbo.SEC_CLIENT 
                                                                        WHERE 
	                                                                        CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE IN (SELECT CL_CODE + '|' + DIV_CODE + '|' + PRD_CODE FROM dbo.PRODUCT WHERE CDP_GROUP_ID = {0})
	                                                                        AND USER_ID IN (SELECT USER_CODE FROM dbo.SEC_USER WHERE EMP_CODE IN (SELECT EMP_CODE FROM dbo.CDP_GROUP_EMPLOYEE WHERE CDP_GROUP_ID = {0}))", CDPSecurityGroupViewModel.CDPSecurityGroup.ID))

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.PRODUCT SET CDP_GROUP_ID = NULL WHERE CDP_GROUP_ID = '{0}'", CDPSecurityGroupViewModel.CDPSecurityGroup.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CDP_GROUP_EMPLOYEE WHERE CDP_GROUP_ID = {0}", CDPSecurityGroupViewModel.CDPSecurityGroup.ID))
                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.CDP_GROUP WHERE CDP_GROUP_ID = {0}", CDPSecurityGroupViewModel.CDPSecurityGroup.ID))

                    DbContext.Configuration.AutoDetectChangesEnabled = True

                    DbContext.SaveChanges()

                    Deleted = True

                Catch ex As Exception

                    Deleted = False

                    ErrorMessage = ex.Message

                Finally

                    If Deleted Then

                        DbTransaction.Commit()

                    Else

                        DbTransaction.Rollback()

                    End If

                End Try

            End Using

            If Deleted Then

                For Each CDP In CDPSecurityGroupViewModel.GroupCDPs.ToList

                    CDP.CDPSecurityGroupID = 0

                Next

            End If

            Delete = Deleted

        End Function
        Public Sub AddEmployees(ByRef CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel)

            CDPSecurityGroupViewModel.GroupEmployees.AddRange(CDPSecurityGroupViewModel.SelectedAvailableEmployees)

            For Each AvailableEmployee In CDPSecurityGroupViewModel.SelectedAvailableEmployees

                CDPSecurityGroupViewModel.AvailableEmployees.Remove(AvailableEmployee)

            Next

            CDPSecurityGroupViewModel.AvailableEmployees = CDPSecurityGroupViewModel.AvailableEmployees.OrderBy(Function(Entity) Entity.EmployeeCode).ToList
            CDPSecurityGroupViewModel.GroupEmployees = CDPSecurityGroupViewModel.GroupEmployees.OrderBy(Function(Entity) Entity.EmployeeCode).ToList

            CDPSecurityGroupViewModel.SelectedAvailableEmployees.Clear()

        End Sub
        Public Sub RemoveEmployees(ByRef CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel)

            CDPSecurityGroupViewModel.AvailableEmployees.AddRange(CDPSecurityGroupViewModel.SelectedGroupEmployees)

            For Each GroupEmployee In CDPSecurityGroupViewModel.SelectedGroupEmployees

                CDPSecurityGroupViewModel.GroupEmployees.Remove(GroupEmployee)

            Next

            CDPSecurityGroupViewModel.AvailableEmployees = CDPSecurityGroupViewModel.AvailableEmployees.OrderBy(Function(Entity) Entity.EmployeeCode).ToList
            CDPSecurityGroupViewModel.GroupEmployees = CDPSecurityGroupViewModel.GroupEmployees.OrderBy(Function(Entity) Entity.EmployeeCode).ToList

            CDPSecurityGroupViewModel.SelectedGroupEmployees.Clear()

        End Sub
        Public Sub AddCDPs(ByRef CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel)

            CDPSecurityGroupViewModel.GroupCDPs.AddRange(CDPSecurityGroupViewModel.SelectedAvailableCDPs)

            For Each AvailableEmployee In CDPSecurityGroupViewModel.SelectedAvailableCDPs

                CDPSecurityGroupViewModel.AvailableCDPs.Remove(AvailableEmployee)

            Next

            CDPSecurityGroupViewModel.AvailableCDPs = CDPSecurityGroupViewModel.AvailableCDPs.OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.DivisionCode).ThenBy(Function(Entity) Entity.ProductCode).ToList
            CDPSecurityGroupViewModel.GroupCDPs = CDPSecurityGroupViewModel.GroupCDPs.OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.DivisionCode).ThenBy(Function(Entity) Entity.ProductCode).ToList

            CDPSecurityGroupViewModel.SelectedAvailableCDPs.Clear()

        End Sub
        Public Sub RemoveCDPs(ByRef CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel)

            CDPSecurityGroupViewModel.AvailableCDPs.AddRange(CDPSecurityGroupViewModel.SelectedGroupCDPs)

            For Each GroupEmployee In CDPSecurityGroupViewModel.SelectedGroupCDPs

                CDPSecurityGroupViewModel.GroupCDPs.Remove(GroupEmployee)

            Next

            CDPSecurityGroupViewModel.AvailableCDPs = CDPSecurityGroupViewModel.AvailableCDPs.OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.DivisionCode).ThenBy(Function(Entity) Entity.ProductCode).ToList
            CDPSecurityGroupViewModel.GroupCDPs = CDPSecurityGroupViewModel.GroupCDPs.OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.DivisionCode).ThenBy(Function(Entity) Entity.ProductCode).ToList

            CDPSecurityGroupViewModel.SelectedGroupCDPs.Clear()

        End Sub

#End Region

    End Class

End Namespace
