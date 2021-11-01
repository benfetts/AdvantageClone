Namespace Database.Procedures.EmployeeNonTask

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

        Public Function Load(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext) As IQueryable(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask)

            Load = From EmployeeNonTask In DataContext.EmployeeNonTasks
                   Select EmployeeNonTask

        End Function
        Public Function LoadByGoogleID(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal GoogleID As String) As AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask

            Try

                LoadByGoogleID = (From EmployeeNonTask In DataContext.EmployeeNonTasks
                                  Where EmployeeNonTask.GoogleID = GoogleID
                                  Select EmployeeNonTask).SingleOrDefault

            Catch ex As Exception
                LoadByGoogleID = Nothing
            End Try

        End Function
        Public Function LoadByGoogleIDandEmployeeCode(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal GoogleID As String, ByVal EmpCode As String) As AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask

            Try
                Dim EmpNonTasks As List(Of AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask) = Nothing
                Dim NontaskID As Integer

                EmpNonTasks = (From EmployeeNonTask In DataContext.EmployeeNonTasks
                               Where EmployeeNonTask.GoogleID = GoogleID
                               Select EmployeeNonTask).OrderBy(Function(ENT) ENT.ID).ToList

                If EmpNonTasks.Count > 1 Then
                    For Each en In EmpNonTasks
                        If DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM [dbo].[EMP_NON_TASKS_EMPS] WHERE [NON_TASK_ID] = {0} AND [EMP_CODE] = '{1}'", en.ID, EmpCode)).FirstOrDefault = 1 Then
                            NontaskID = en.ID
                            Exit For
                        End If
                    Next

                    LoadByGoogleIDandEmployeeCode = (From EmployeeNonTask In DataContext.EmployeeNonTasks
                                                     Where EmployeeNonTask.ID = NontaskID
                                                     Select EmployeeNonTask).SingleOrDefault
                Else

                    LoadByGoogleIDandEmployeeCode = (From EmployeeNonTask In DataContext.EmployeeNonTasks
                                                     Where EmployeeNonTask.GoogleID = GoogleID
                                                     Select EmployeeNonTask).SingleOrDefault

                End If



            Catch ex As Exception
                LoadByGoogleIDandEmployeeCode = Nothing
            End Try

        End Function
        Public Function LoadByEmployeeNonTaskID(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeNonTaskID As Long) As AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask

            Try

                LoadByEmployeeNonTaskID = (From EmployeeNonTask In DataContext.EmployeeNonTasks
                                           Where EmployeeNonTask.ID = EmployeeNonTaskID
                                           Select EmployeeNonTask).SingleOrDefault

            Catch ex As Exception
                LoadByEmployeeNonTaskID = Nothing
            End Try

        End Function
        Public Function Insert(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeNonTask As AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Try

                DataContext.EmployeeNonTasks.InsertOnSubmit(EmployeeNonTask)

                DataContext.SubmitChanges()

                Inserted = True

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeNonTask As AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DataContext.SubmitChanges()

                Updated = True

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DataContext As AdvantageFramework.GoogleServices.Database.DataContext, ByVal EmployeeNonTask As AdvantageFramework.GoogleServices.Database.Entities.EmployeeNonTask) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DataContext.EmployeeNonTasks.DeleteOnSubmit(EmployeeNonTask)

                DataContext.SubmitChanges()

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
