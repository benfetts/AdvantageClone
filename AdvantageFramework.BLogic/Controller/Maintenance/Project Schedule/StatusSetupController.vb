Namespace Controller.Maintenance.ProjectSchedule

    Public Class StatusSetupController

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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel

            Dim StatusSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel = Nothing

            StatusSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                StatusSetupViewModel.Statuses = GetStatuses(DbContext)

            End Using

            Load = StatusSetupViewModel

        End Function
        Public Function GetStatuses() As Generic.List(Of AdvantageFramework.Database.Entities.Status)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Return GetStatuses(DbContext)

            End Using

        End Function
        Public Function GetStatuses(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.Status)

            Return AdvantageFramework.Database.Procedures.Status.Load(DbContext).ToList

        End Function

        Public Function StatusExists(Code As String) As Boolean

            StatusExists = False

            Dim Statuses As List(Of Database.Entities.Status) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Statuses = GetStatuses(DbContext).Where(Function(x) x.Code = Code)

            End Using

            If Statuses.Count > 0 Then

                StatusExists = True

            End If

        End Function
        Public Function Add(ByVal Statuses As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Add = Add(DbContext, DataContext, Statuses.Select(Function(d) d.ToEntity(Nothing)).ToList)

                End Using


            End Using

        End Function
        Public Function Add(ByVal DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, ByVal Statuses As Generic.List(Of AdvantageFramework.Database.Entities.Status)) As Boolean

            'objects
            Dim Added As Boolean = True

            For Each Status In Statuses

                If Status.IsEntityBeingAdded() Then

                    Status.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.Status.Insert(DbContext, DataContext, Status) = False Then

                        Added = False

                    End If

                End If

            Next

            Return Added

        End Function

        Public Function Save(StatusSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Save = Save(DbContext, DataContext, StatusSetupViewModel.Statuses)

                End Using


            End Using

        End Function
        Public Function Save(ByVal Statuses As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Save = Save(DbContext, DataContext, Statuses.Select(Function(d) d.ToEntity(DbContext)).ToList)

                End Using

            End Using

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext, DataContext As AdvantageFramework.Database.DataContext, ByVal Statuses As Generic.List(Of AdvantageFramework.Database.Entities.Status)) As Boolean

            'objects
            Dim Saved As Boolean = True

            For Each Status In Statuses

                If AdvantageFramework.Database.Procedures.Status.Update(DbContext, DataContext, Status) = False Then

                    Saved = False

                End If

            Next

            Save = Saved

        End Function

        Public Function Delete(StatusSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim Status As AdvantageFramework.Database.Entities.Status = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Status In StatusSetupViewModel.SelectedStatuses

                    If Delete(DbContext, Status) Then

                        Deleted = True

                        If StatusSetupViewModel.Statuses.Remove(Status) = False Then

                            Deleted = False

                        End If

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Statuses As Generic.List(Of AdvantageFramework.Database.Entities.Status)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            For Each Status In Statuses

                If Delete(DbContext, Status) Then

                    Deleted = True

                End If

            Next

            Delete = Deleted

        End Function
        Public Function Delete(ByVal Statuses As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Status)) As Boolean

            'objects
            Dim Deleted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Status In Statuses.Select(Function(d) d.ToEntity(DbContext)).ToList

                    If Delete(DbContext, Status) = False Then

                        Deleted = False

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Status As AdvantageFramework.Database.Entities.Status) As Boolean

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Status.Delete(DbContext, DataContext, Status)

            End Using

        End Function


        Public Function UpdateInactiveFlag(Status As AdvantageFramework.Database.Entities.Status, Value As Short) As Boolean

            'objects
            Dim Saved As Boolean = False

            If Status IsNot Nothing Then

                Try

                    Status.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    Status.IsInactive = Status.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.Status.Update(DbContext, DataContext, Status)

                        End Using

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

            UpdateInactiveFlag = Saved

        End Function
        Public Sub CancelNewItemRow(StatusSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel)

            StatusSetupViewModel.IsNewRow = False
            StatusSetupViewModel.CancelEnabled = False
            StatusSetupViewModel.DeleteEnabled = StatusSetupViewModel.HasASelectedStatus

        End Sub
        Public Sub InitNewRowEvent(StatusSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel)

            StatusSetupViewModel.IsNewRow = True
            StatusSetupViewModel.CancelEnabled = True
            StatusSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub StatusSelectionChanged(StatusSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.StatusSetupViewModel,
                                                  IsNewItemRow As Boolean,
                                                  SelectedStatuses As Generic.List(Of AdvantageFramework.Database.Entities.Status))

            StatusSetupViewModel.IsNewRow = IsNewItemRow
            StatusSetupViewModel.CancelEnabled = IsNewItemRow
            StatusSetupViewModel.DeleteEnabled = Not IsNewItemRow

            StatusSetupViewModel.SelectedStatuses = SelectedStatuses

        End Sub

#End Region

#End Region

    End Class

End Namespace
