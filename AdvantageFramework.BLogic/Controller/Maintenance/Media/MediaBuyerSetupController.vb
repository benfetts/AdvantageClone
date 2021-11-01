Namespace Controller.Maintenance.Media

    Public Class MediaBuyerSetupController
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

        Private Function Delete(DbContext As AdvantageFramework.Database.DbContext, MediaBuyer As AdvantageFramework.Database.Entities.MediaBuyer,
                                ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True
            Dim Deleted As Boolean = False

            'If AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByDepartmentTeamCode(DbContext, DepartmentTeam.Code).Any Then

            '    IsValid = False
            '    ErrorMessage = "This code is in use and cannot be deleted."

            'End If

            If IsValid Then

                Try

                    DbContext.DeleteEntityObject(MediaBuyer)

                    DbContext.SaveChanges()

                    Deleted = True

                Catch ex As SqlClient.SqlException
                    ErrorMessage = ex.Message & Space(1) & If(ex.InnerException IsNot Nothing, ex.InnerException.Message, "")
                End Try

            End If

            Delete = Deleted

        End Function

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Add(MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.IsEntityBeingAdded() Then

                    MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.DbContext = DbContext

                    Try

                        DbContext.MediaBuyers.Add(MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity)

                        ErrorMessage = MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.ValidateEntity(IsValid)

                        If IsValid Then

                            DbContext.SaveChanges()

                            Added = True

                        End If

                    Catch ex As SqlClient.SqlException
                        Added = False
                        ErrorMessage = ex.Message
                    End Try

                End If

            End Using

            Add = Added

        End Function
        Public Sub CancelNewItemRow(MediaBuyerSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel)

            MediaBuyerSetupViewModel.IsNewRow = False
            MediaBuyerSetupViewModel.CancelEnabled = False
            MediaBuyerSetupViewModel.DeleteEnabled = MediaBuyerSetupViewModel.HasASelectedMediaBuyer

        End Sub
        Public Function Delete(MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim ErrorText As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Deleted = Delete(DbContext, MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity, ErrorText)

            End Using

            Delete = Deleted

        End Function
        Public Function Delete(MediaBuyerSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim MediaBuyer As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel = Nothing
            Dim ErrorText As String = ""
            Dim FailedOnce As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each MediaBuyer In MediaBuyerSetupViewModel.SelectedMediaBuyers

                    Deleted = Delete(DbContext, MediaBuyer.GetMediaBuyerEntity, ErrorText)

                    If Deleted Then

                        MediaBuyerSetupViewModel.MediaBuyers.Remove(MediaBuyer)

                    Else

                        FailedOnce = True
                        ErrorMessage = ErrorText

                    End If

                Next

            End Using

            Delete = Not FailedOnce

        End Function
        Public Sub InitNewRowEvent(MediaBuyerSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel)

            MediaBuyerSetupViewModel.IsNewRow = True
            MediaBuyerSetupViewModel.CancelEnabled = True
            MediaBuyerSetupViewModel.DeleteEnabled = False

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel

            Dim MediaBuyerSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel = Nothing

            MediaBuyerSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBuyerSetupViewModel.MediaBuyers = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel)

                MediaBuyerSetupViewModel.MediaBuyers.AddRange(From MediaBuyer In DbContext.GetQuery(Of Database.Entities.MediaBuyer).Include("Employee").OrderBy(Function(MB) MB.EmployeeCode).ToList
                                                              Select New AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel(MediaBuyer))

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    MediaBuyerSetupViewModel.RepositoryEmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(Session, DbContext, SecurityDbContext))

                End Using

            End Using

            Load = MediaBuyerSetupViewModel

        End Function
		Public Sub MediaBuyerSelectionChanged(MediaBuyerSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel,
											  IsNewItemRow As Boolean,
											  SelectedMediaBuyers As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel))

			MediaBuyerSetupViewModel.IsNewRow = IsNewItemRow
			MediaBuyerSetupViewModel.CancelEnabled = IsNewItemRow
			MediaBuyerSetupViewModel.DeleteEnabled = Not IsNewItemRow

			MediaBuyerSetupViewModel.SelectedMediaBuyers = SelectedMediaBuyers

		End Sub
        Public Function UpdateInactiveFlag(MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel, Value As Short,
                                           ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim IsValid As Boolean = True

            If MediaBuyerSetupDetailViewModel IsNot Nothing Then

                MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.IsInactive = Convert.ToBoolean(Value)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.UpdateObject(MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity)

                    ErrorMessage = MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.ValidateEntity(IsValid)

                    If IsValid Then

                        DbContext.SaveChanges()

                        Saved = True

                    End If

                End Using

            End If

            UpdateInactiveFlag = Saved

        End Function
        Public Function ValidateEntity(MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel, ByRef IsValid As Boolean) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.DbContext = DbContext

                ErrorText = MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.ValidateEntity(IsValid)

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(MediaBuyerSetupDetailViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupDetailViewModel, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.DbContext = DbContext

                ErrorText = MediaBuyerSetupDetailViewModel.GetMediaBuyerEntity.ValidateEntityProperty(FieldName, IsValid, Value)

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Function GetRepositoryEmployeeName(MediaBuyerSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaBuyerSetupViewModel, EmployeeCode As String) As String

            Dim EmployeeName As String = Nothing

            If MediaBuyerSetupViewModel.RepositoryEmployeeList IsNot Nothing AndAlso MediaBuyerSetupViewModel.RepositoryEmployeeList.Where(Function(Employee) Employee.Code = EmployeeCode).FirstOrDefault IsNot Nothing Then

                EmployeeName = MediaBuyerSetupViewModel.RepositoryEmployeeList.Where(Function(Employee) Employee.Code = EmployeeCode).FirstOrDefault.ToString

            End If

            GetRepositoryEmployeeName = EmployeeName

        End Function

#End Region

#End Region

    End Class

End Namespace
