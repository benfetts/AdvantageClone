Namespace Controller.Maintenance.ProjectSchedule

    Public Class PhaseSetupController

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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel

            Dim PhaseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel = Nothing

            PhaseSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                PhaseSetupViewModel.Phases = GetPhases(DbContext)

            End Using

            Load = PhaseSetupViewModel

        End Function
        Public Function GetPhases() As Generic.List(Of AdvantageFramework.Database.Entities.Phase)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Return GetPhases(DbContext)

            End Using

        End Function
        Public Function GetPhases(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.Phase)

            Return AdvantageFramework.Database.Procedures.Phase.Load(DbContext).ToList

        End Function

        Public Function PhaseExists(ID As Integer) As Boolean

            PhaseExists = False

            Dim Phases As List(Of Database.Entities.Phase) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Phases = GetPhases(DbContext).Where(Function(x) x.ID = ID)

            End Using

            If Phases.Count > 0 Then

                PhaseExists = True

            End If

        End Function
        Public Function Add(ByVal Phases As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase)) As Generic.List(Of AdvantageFramework.Database.Entities.Phase)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Add = Add(DbContext, Phases.Select(Function(d) d.ToEntity(Nothing)).ToList)

            End Using

        End Function
        Public Function Add(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Phases As Generic.List(Of AdvantageFramework.Database.Entities.Phase)) As Generic.List(Of AdvantageFramework.Database.Entities.Phase)

            'objects
            Dim Added As Boolean = True

            For Each Phase In Phases

                If Phase.IsEntityBeingAdded() Then

                    Phase.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.Phase.Insert(DbContext, Phase) = False Then

                        Added = False

                    End If

                End If

            Next

            Return Phases

        End Function

        Public Function Save(PhaseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, PhaseSetupViewModel.Phases)

            End Using

        End Function
        Public Function Save(ByVal Phases As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, Phases.Select(Function(d) d.ToEntity(DbContext)).ToList)

            End Using

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Phases As Generic.List(Of AdvantageFramework.Database.Entities.Phase)) As Boolean

            'objects
            Dim Saved As Boolean = True

            For Each Phase In Phases

                If AdvantageFramework.Database.Procedures.Phase.Update(DbContext, Phase) = False Then

                    Saved = False

                End If

            Next

            Save = Saved

        End Function

        Public Function Delete(PhaseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim Phase As AdvantageFramework.Database.Entities.Phase = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Phase In PhaseSetupViewModel.SelectedPhases

                    If Delete(DbContext, Phase) Then

                        Deleted = True

                        If PhaseSetupViewModel.Phases.Remove(Phase) = False Then

                            Deleted = False

                        End If

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Phases As Generic.List(Of AdvantageFramework.Database.Entities.Phase)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            For Each Phase In Phases

                If Delete(DbContext, Phase) Then

                    Deleted = True

                End If

            Next

            Delete = Deleted

        End Function
        Public Function Delete(ByVal Phases As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectSchedule.Phase)) As Boolean

            'objects
            Dim Deleted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Phase In Phases.Select(Function(d) d.ToEntity(DbContext)).ToList

                    If Delete(DbContext, Phase) = False Then

                        Deleted = False

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Phase As AdvantageFramework.Database.Entities.Phase) As Boolean

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.Phase.Delete(DbContext, DataContext, Phase)

            End Using

        End Function


        Public Function UpdateInactiveFlag(Phase As AdvantageFramework.Database.Entities.Phase, Value As Short) As Boolean

            'objects
            Dim Saved As Boolean = False

            If Phase IsNot Nothing Then

                Try

                    Phase.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    Phase.IsInactive = Phase.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.Phase.Update(DbContext, Phase)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

            UpdateInactiveFlag = Saved

        End Function
        Public Sub CancelNewItemRow(PhaseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel)

            PhaseSetupViewModel.IsNewRow = False
            PhaseSetupViewModel.CancelEnabled = False
            PhaseSetupViewModel.DeleteEnabled = PhaseSetupViewModel.HasASelectedPhase

        End Sub
        Public Sub InitNewRowEvent(PhaseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel)

            PhaseSetupViewModel.IsNewRow = True
            PhaseSetupViewModel.CancelEnabled = True
            PhaseSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub PhaseSelectionChanged(PhaseSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectSchedule.PhaseSetupViewModel,
                                                  IsNewItemRow As Boolean,
                                                  SelectedPhases As Generic.List(Of AdvantageFramework.Database.Entities.Phase))

            PhaseSetupViewModel.IsNewRow = IsNewItemRow
            PhaseSetupViewModel.CancelEnabled = IsNewItemRow
            PhaseSetupViewModel.DeleteEnabled = Not IsNewItemRow

            PhaseSetupViewModel.SelectedPhases = SelectedPhases

        End Sub

#End Region

#End Region

    End Class

End Namespace
