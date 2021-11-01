Namespace Database.Procedures.EmployeeTimesheetFunction

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

        Public Function LoadByGroupCode(ByVal DbContext As Database.DbContext, ByVal GroupCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimesheetFunction)

            LoadByGroupCode = From EmployeeTimesheetFunction In DbContext.GetQuery(Of Database.Entities.EmployeeTimesheetFunction)
                              Where EmployeeTimesheetFunction.GroupCode = GroupCode
                              Select EmployeeTimesheetFunction

        End Function
        Public Function LoadByEmployeeCode(ByVal DbContext As Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimesheetFunction)

            LoadByEmployeeCode = From EmployeeTimesheetFunction In DbContext.GetQuery(Of Database.Entities.EmployeeTimesheetFunction)
                                 Where EmployeeTimesheetFunction.EmployeeCode = EmployeeCode
                                 Select EmployeeTimesheetFunction

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EmployeeTimesheetFunction)

            Load = From EmployeeTimesheetFunction In DbContext.GetQuery(Of Database.Entities.EmployeeTimesheetFunction)
                   Select EmployeeTimesheetFunction

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimesheetFunction As AdvantageFramework.Database.Entities.EmployeeTimesheetFunction) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeTimesheetFunctions.Add(EmployeeTimesheetFunction)

                ErrorText = EmployeeTimesheetFunction.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimesheetFunction As AdvantageFramework.Database.Entities.EmployeeTimesheetFunction) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeTimesheetFunction)

                ErrorText = EmployeeTimesheetFunction.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeTimesheetFunction As AdvantageFramework.Database.Entities.EmployeeTimesheetFunction) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeTimesheetFunction)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    For Each EntityClass In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.EmployeeTimesheetFunction).Where(Function(EmpOffice) EmpOffice.EmployeeCode = EmployeeCode)

                        DbContext.DeleteEntityObject(EntityClass)

                    Next

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
