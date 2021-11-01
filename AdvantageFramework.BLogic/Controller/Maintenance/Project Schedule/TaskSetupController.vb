Namespace Controller.Maintenance.ProjectSchedule

    Public Class TaskSetupController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property

#End Region

#Region " Methods "


#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            _Session = Session

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel

            Dim TaskSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel = Nothing

            TaskSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                TaskSetupViewModel.Tasks = GetTasks(DbContext)

            End Using

            Load = TaskSetupViewModel

        End Function
        Public Function GetTasks() As Generic.List(Of AdvantageFramework.Database.Entities.Task)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Return GetTasks(DbContext)

            End Using

        End Function
        Public Function GetTasks(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.Task)

            Return AdvantageFramework.Database.Procedures.Task.Load(DbContext).ToList

        End Function

        Public Function TaskExists(Code As String) As Boolean

            TaskExists = False

            Dim Tasks As List(Of Database.Entities.Task) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Tasks = GetTasks(DbContext).Where(Function(x) x.Code = Code)

            End Using

            If Tasks.Count > 0 Then

                TaskExists = True

            End If

        End Function
        Public Function Add(ByVal Tasks As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Add = Add(DbContext, Tasks.Select(Function(d) d.ToEntity(Nothing)).ToList)

            End Using

        End Function
        Public Function Add(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Tasks As Generic.List(Of AdvantageFramework.Database.Entities.Task)) As Boolean

            'objects
            Dim Added As Boolean = True

            For Each Task In Tasks

                If Task.IsEntityBeingAdded() Then

                    Task.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.Task.Insert(DbContext, Task) = False Then

                        Added = False

                    End If

                End If

            Next

            Return Added

        End Function

        Public Function Save(TaskSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, TaskSetupViewModel.Tasks)

            End Using

        End Function
        Public Function Save(ByVal Tasks As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, Tasks.Select(Function(d) d.ToEntity(DbContext)).ToList)

            End Using

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Tasks As Generic.List(Of AdvantageFramework.Database.Entities.Task)) As Boolean

            'objects
            Dim Saved As Boolean = True

            For Each Task In Tasks

                If AdvantageFramework.Database.Procedures.Task.Update(DbContext, Task) = False Then

                    Saved = False

                End If

            Next

            Save = Saved

        End Function

        Public Function Delete(TaskSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Task In TaskSetupViewModel.SelectedTasks

                    If Delete(DbContext, Task) Then

                        Deleted = True

                        If TaskSetupViewModel.Tasks.Remove(Task) = False Then

                            Deleted = False

                        End If

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Tasks As Generic.List(Of AdvantageFramework.Database.Entities.Task)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            For Each Task In Tasks

                If Delete(DbContext, Task) Then

                    Deleted = True

                End If

            Next

            Delete = Deleted

        End Function
        Public Function Delete(ByVal Tasks As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Task)) As Boolean

            'objects
            Dim Deleted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Task In Tasks.Select(Function(d) d.ToEntity(DbContext)).ToList

                    If Delete(DbContext, Task) = False Then

                        Deleted = False

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Task As AdvantageFramework.Database.Entities.Task) As Boolean

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Task.Delete(DbContext, DataContext, Task)

            End Using

        End Function


        Public Function UpdateInactiveFlag(Task As AdvantageFramework.Database.Entities.Task, Value As Short) As Boolean

            'objects
            Dim Saved As Boolean = False

            If Task IsNot Nothing Then

                Try

                    Task.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    Task.IsInactive = Task.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.Task.Update(DbContext, Task)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

            UpdateInactiveFlag = Saved

        End Function
        Public Sub CancelNewItemRow(TaskSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel)

            TaskSetupViewModel.IsNewRow = False
            TaskSetupViewModel.CancelEnabled = False
            TaskSetupViewModel.DeleteEnabled = TaskSetupViewModel.HasASelectedTask

        End Sub
        Public Sub InitNewRowEvent(TaskSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel)

            TaskSetupViewModel.IsNewRow = True
            TaskSetupViewModel.CancelEnabled = True
            TaskSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub TaskSelectionChanged(TaskSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.TaskSetupViewModel,
                                                  IsNewItemRow As Boolean,
                                                  SelectedTasks As Generic.List(Of AdvantageFramework.Database.Entities.Task))

            TaskSetupViewModel.IsNewRow = IsNewItemRow
            TaskSetupViewModel.CancelEnabled = IsNewItemRow
            TaskSetupViewModel.DeleteEnabled = Not IsNewItemRow

            TaskSetupViewModel.SelectedTasks = SelectedTasks

        End Sub
        Public Function LoadFunctionCodes() As Generic.List(Of AdvantageFramework.Database.Entities.Function)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Function.LoadAllActiveEmployeeFunctions(DbContext).ToList

            End Using

        End Function
        Public Function LoadRoles() As Generic.List(Of AdvantageFramework.Database.Entities.Role)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Role.LoadAllActive(DbContext).ToList

            End Using

        End Function

        Public Function LoadStatuses() As Generic.List(Of AdvantageFramework.Database.Entities.Status)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext).ToList

            End Using

        End Function

#End Region

#End Region

    End Class

End Namespace
