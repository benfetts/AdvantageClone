Namespace Database.Procedures.EmployeeNonTask

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

        Public Function LoadByEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeNonTask)

            LoadByEmployeeCode = From EmployeeNonTask In DbContext.GetQuery(Of Database.Entities.EmployeeNonTask)
                                 Where EmployeeNonTask.EmployeeCode = EmployeeCode
                                 Select EmployeeNonTask

        End Function
        Public Function IsDateEmployeeHoliday(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal [Date] As Date) As Boolean

            IsDateEmployeeHoliday = (From EmployeeNonTask In AdvantageFramework.Database.Procedures.EmployeeNonTask.Load(DbContext)
                                     Where EmployeeNonTask.StartDate = [Date] AndAlso
                                            EmployeeNonTask.EndDate = [Date] AndAlso
                                            EmployeeNonTask.Type = "H"
                                     Select EmployeeNonTask).Any

        End Function
        Public Function LoadByGoogleID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal GoogleID As String) As AdvantageFramework.Database.Entities.EmployeeNonTask

            Try

                LoadByGoogleID = (From EmployeeNonTask In DbContext.GetQuery(Of Database.Entities.EmployeeNonTask)
                                  Where EmployeeNonTask.GoogleID = GoogleID
                                  Select EmployeeNonTask).SingleOrDefault

            Catch ex As Exception
                LoadByGoogleID = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeNonTaskID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeNonTaskID As Long) As AdvantageFramework.Database.Entities.EmployeeNonTask

            Try

                LoadByEmployeeNonTaskID = (From EmployeeNonTask In DbContext.GetQuery(Of Database.Entities.EmployeeNonTask)
                                           Where EmployeeNonTask.ID = EmployeeNonTaskID
                                           Select EmployeeNonTask).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeNonTaskID = Nothing
            End Try

        End Function
        Public Function LoadByRecurrenceParentID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RecurrenceParentID As Long) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeNonTask)

            Try

                LoadByRecurrenceParentID = From EmployeeNonTask In DbContext.GetQuery(Of Database.Entities.EmployeeNonTask)
                                           Where EmployeeNonTask.RecurrenceParent = RecurrenceParentID
                                           Select EmployeeNonTask

            Catch ex As Exception
                LoadByRecurrenceParentID = Nothing
            End Try

        End Function
        Public Function LoadByCallMeetingToDoAndClientAndDivisionAndProductCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Type As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeNonTask)

            LoadByCallMeetingToDoAndClientAndDivisionAndProductCode = From EmployeeNonTask In DbContext.GetQuery(Of Database.Entities.EmployeeNonTask)
                                                                      Where (EmployeeNonTask.Type = "C" OrElse
                                                                             EmployeeNonTask.Type = "M" OrElse
                                                                             EmployeeNonTask.Type = "TD" OrElse
                                                                             EmployeeNonTask.Type = "EL") AndAlso
                                                                            EmployeeNonTask.ClientCode = ClientCode AndAlso
                                                                            EmployeeNonTask.DivisionCode = DivisionCode AndAlso
                                                                            EmployeeNonTask.ProductCode = ProductCode
                                                                      Select EmployeeNonTask

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.EmployeeNonTask)

            Load = From EmployeeNonTask In DbContext.GetQuery(Of Database.Entities.EmployeeNonTask)
                   Select EmployeeNonTask

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.EmployeeNonTasks.Add(EmployeeNonTask)

                ErrorText = EmployeeNonTask.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(EmployeeNonTask)

                ErrorText = EmployeeNonTask.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(EmployeeNonTask)

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

        Public Function DeleteByNonTaskId(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal NonTaskId As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try
                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.EMP_NON_TASKS_EMPS WHERE NON_TASK_ID = '" & NonTaskId & "'")

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.EMP_NON_TASKS WHERE NON_TASK_ID = '" & NonTaskId & "'")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByNonTaskId = Deleted
            End Try

        End Function

        Public Function DeleteByRecurrenceParent(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RecurrenceParent As Integer) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.EMP_NON_TASKS WHERE RECURRENCE_PARENT = '" & RecurrenceParent & "'")

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteByRecurrenceParent = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
