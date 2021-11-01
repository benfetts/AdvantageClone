Namespace Database.Procedures.SprintEmployee

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

        'Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SprintEmployee)

        '    Load = From SprintEmployee In DbContext.GetQuery(Of Database.Entities.SprintEmployee)
        '           Select SprintEmployee

        'End Function
        Public Function LoadByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal AlertID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.SprintEmployee)

            LoadByAlertID = From SprintEmployee In DbContext.GetQuery(Of Database.Entities.SprintEmployee)
                            Where SprintEmployee.AlertID = AlertID
                            Select SprintEmployee

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintEmployeeID As Integer) As AdvantageFramework.Database.Entities.SprintEmployee

            LoadByID = (From SprintEmployee In DbContext.GetQuery(Of Database.Entities.SprintEmployee)
                        Where SprintEmployee.ID = SprintEmployeeID
                        Select SprintEmployee).SingleOrDefault

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintEmployee As AdvantageFramework.Database.Entities.SprintEmployee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.SprintEmployees.Add(SprintEmployee)

                ErrorText = SprintEmployee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SprintEmployee As AdvantageFramework.Database.Entities.SprintEmployee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(SprintEmployee)

                ErrorText = SprintEmployee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Dim Deleted As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM SPRINT_EMPLOYEE WITH(ROWLOCK) WHERE ALERT_ID = {0} AND EMP_CODE = '{1}';", AlertID, EmployeeCode))

            Catch ex As Exception
                Deleted = False
            End Try

            Return Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal SprintEmployee As AdvantageFramework.Database.Entities.SprintEmployee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'If AdvantageFramework.Database.Procedures.SprintEmployee.IsInUse(DataContext, SprintEmployee.Code) = True OrElse
                '       AdvantageFramework.Database.Procedures.SprintEmployeeRole.LoadBySprintEmployeeCode(DataContext, SprintEmployee.Code).Count > 0 Then

                '    ErrorText = "The task is in use and cannot be deleted."
                '    IsValid = False

                'End If

                If IsValid Then

                    DbContext.DeleteEntityObject(SprintEmployee)

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
