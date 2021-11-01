Namespace Controller.Maintenance.ProjectManagement

    Public Class JobTypeSetupController

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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel

            Dim JobTypeSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel = Nothing

            JobTypeSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobTypeSetupViewModel.JobTypes = GetJobTypes(DbContext)

            End Using

            Load = JobTypeSetupViewModel

        End Function
        Public Function GetJobTypes() As Generic.List(Of AdvantageFramework.Database.Entities.JobType)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Return GetJobTypes(DbContext)

            End Using

        End Function
        Public Function GetJobTypes(ByVal DbContext As AdvantageFramework.Database.DbContext) As Generic.List(Of AdvantageFramework.Database.Entities.JobType)

            Return AdvantageFramework.Database.Procedures.JobType.Load(DbContext).ToList

        End Function

        Public Function JobTypeExists(Code As String) As Boolean

            JobTypeExists = False

            Dim JobTypes As List(Of Database.Entities.JobType) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobTypes = GetJobTypes(DbContext).Where(Function(x) x.Code.ToLower = Code.ToLower)

            End Using

            If JobTypes.Count > 0 Then

                JobTypeExists = True

            End If

        End Function
        Public Function Add(ByVal JobTypes As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Add = Add(DbContext, JobTypes.Select(Function(d) d.ToEntity(Nothing)).ToList)

            End Using

        End Function
        Public Function Add(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTypes As Generic.List(Of AdvantageFramework.Database.Entities.JobType)) As Boolean

            'objects
            Dim Added As Boolean = True

            For Each JobType In JobTypes

                If JobType.IsEntityBeingAdded() Then

                    JobType.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.JobType.Insert(DbContext, JobType) = False Then

                        Added = False

                    End If

                End If

            Next

            Return Added

        End Function

        Public Function Save(JobTypeSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, JobTypeSetupViewModel.JobTypes)

            End Using

        End Function
        Public Function Save(ByVal JobTypes As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType)) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = Save(DbContext, JobTypes.Select(Function(d) d.ToEntity(DbContext)).ToList)

            End Using

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTypes As Generic.List(Of AdvantageFramework.Database.Entities.JobType)) As Boolean

            'objects
            Dim Saved As Boolean = True

            For Each JobType In JobTypes

                If AdvantageFramework.Database.Procedures.JobType.Update(DbContext, JobType) = False Then

                    Saved = False

                End If

            Next

            Save = Saved

        End Function

        Public Function Delete(JobTypeSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim JobType As AdvantageFramework.Database.Entities.JobType = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each JobType In JobTypeSetupViewModel.SelectedJobTypes

                    If Delete(DbContext, JobType) Then

                        Deleted = True

                        If JobTypeSetupViewModel.JobTypes.Remove(JobType) = False Then

                            Deleted = False

                        End If

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTypes As Generic.List(Of AdvantageFramework.Database.Entities.JobType)) As Boolean

            'objects
            Dim Deleted As Boolean = False

            For Each JobType In JobTypes

                If Delete(DbContext, JobType) Then

                    Deleted = True

                End If

            Next

            Delete = Deleted

        End Function
        Public Function Delete(ByVal JobTypes As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.JobType)) As Boolean

            'objects
            Dim Deleted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each JobType In JobTypes.Select(Function(d) d.ToEntity(DbContext)).ToList

                    If Delete(DbContext, JobType) = False Then

                        Deleted = False

                    End If

                Next

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobType As AdvantageFramework.Database.Entities.JobType) As Boolean

            Return AdvantageFramework.Database.Procedures.JobType.Delete(DbContext, JobType)

        End Function


        Public Function UpdateInactiveFlag(JobType As AdvantageFramework.Database.Entities.JobType, Value As Short) As Boolean

            'objects
            Dim Saved As Boolean = False

            If JobType IsNot Nothing Then

                Try

                    JobType.IsInactive = Convert.ToInt16(Value)

                Catch ex As Exception
                    JobType.IsInactive = JobType.IsInactive
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Saved = AdvantageFramework.Database.Procedures.JobType.Update(DbContext, JobType)

                    End Using

                Catch ex As Exception

                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

            End If

            UpdateInactiveFlag = Saved

        End Function
        Public Sub CancelNewItemRow(JobTypeSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel)

            JobTypeSetupViewModel.IsNewRow = False
            JobTypeSetupViewModel.CancelEnabled = False
            JobTypeSetupViewModel.DeleteEnabled = JobTypeSetupViewModel.HasASelectedJobType

        End Sub
        Public Sub InitNewRowEvent(JobTypeSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel)

            JobTypeSetupViewModel.IsNewRow = True
            JobTypeSetupViewModel.CancelEnabled = True
            JobTypeSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub JobTypeSelectionChanged(JobTypeSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.JobTypeSetupViewModel,
                                                  IsNewItemRow As Boolean,
                                                  SelectedJobTypes As Generic.List(Of AdvantageFramework.Database.Entities.JobType))

            JobTypeSetupViewModel.IsNewRow = IsNewItemRow
            JobTypeSetupViewModel.CancelEnabled = IsNewItemRow
            JobTypeSetupViewModel.DeleteEnabled = Not IsNewItemRow

            JobTypeSetupViewModel.SelectedJobTypes = SelectedJobTypes

        End Sub

        Public Function LoadSalesClasses() As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Return AdvantageFramework.Database.Procedures.SalesClass.LoadAllActiveBySalesClassTypeCode(DbContext, "P").ToList

            End Using

        End Function

#End Region

#End Region

    End Class

End Namespace
