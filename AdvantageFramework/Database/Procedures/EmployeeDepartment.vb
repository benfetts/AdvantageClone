Namespace Database.Procedures.EmployeeDepartment

    <HideModuleName()> _
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

        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeDepartment)

            LoadByEmployeeCode = From EmployeeDepartment In DbContext.GetQuery(Of Database.Entities.EmployeeDepartment)
                                 Where EmployeeDepartment.EmployeeCode = EmployeeCode
                                 Select EmployeeDepartment

        End Function
        Public Function LoadByDepartmentTeamCode(ByVal DbContext As Database.DbContext, ByVal DepartmentTeamCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeDepartment)

            LoadByDepartmentTeamCode = From EmployeeDepartment In DbContext.GetQuery(Of Database.Entities.EmployeeDepartment)
                                       Where EmployeeDepartment.DepartmentTeamCode = DepartmentTeamCode
                                       Select EmployeeDepartment

        End Function
        Public Function LoadByEmployeeCodeAndDepartmentTeamCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, ByVal DepartmentTeamCode As String) As Database.Entities.EmployeeDepartment

            Try

                LoadByEmployeeCodeAndDepartmentTeamCode = (From EmployeeDepartment In DbContext.GetQuery(Of Database.Entities.EmployeeDepartment)
                                                           Where EmployeeDepartment.EmployeeCode = EmployeeCode AndAlso
                                                                 EmployeeDepartment.DepartmentTeamCode = DepartmentTeamCode
                                                           Select EmployeeDepartment).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeCodeAndDepartmentTeamCode = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeDepartment)

            Load = From EmployeeDepartment In DbContext.GetQuery(Of Database.Entities.EmployeeDepartment)
                   Select EmployeeDepartment

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String, _
                               ByVal DepartmentTeamCode As String, ByVal DepartmentName As String, _
                               ByRef EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                EmployeeDepartment = New AdvantageFramework.Database.Entities.EmployeeDepartment

                EmployeeDepartment.DbContext = DbContext
                EmployeeDepartment.EmployeeCode = EmployeeCode
                EmployeeDepartment.DepartmentTeamCode = DepartmentTeamCode
                EmployeeDepartment.DepartmentName = DepartmentName

                Inserted = Insert(DbContext, EmployeeDepartment)

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeDepartments.Add(EmployeeDepartment)

                ErrorText = EmployeeDepartment.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeDepartment)

                ErrorText = EmployeeDepartment.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeDepartment As AdvantageFramework.Database.Entities.EmployeeDepartment) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeDepartment)

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
