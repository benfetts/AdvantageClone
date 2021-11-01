Namespace Controller.Maintenance.Media

    Public Class MediaTacticSetupController
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

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel

            'objects
            Dim MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel = Nothing
            Dim MediaTactic As AdvantageFramework.DTO.MediaTactic = Nothing

            MediaTacticSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaTacticSetupViewModel.MediaTactics = AdvantageFramework.Database.Procedures.MediaTactic.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.MediaTactic(Entity)).ToList

            End Using

            MediaTacticSetupViewModel.IsNewRow = False
            MediaTacticSetupViewModel.DeleteEnabled = False
            MediaTacticSetupViewModel.CancelEnabled = False

            Load = MediaTacticSetupViewModel

        End Function
        Public Function Add(ByRef MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel,
                            MediaTacticDTO As AdvantageFramework.DTO.MediaTactic,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim MediaTactic As AdvantageFramework.Database.Entities.MediaTactic = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTactic = New AdvantageFramework.Database.Entities.MediaTactic

                MediaTactic.DbContext = DbContext

                MediaTacticDTO.SaveToEntity(MediaTactic)

                DbContext.MediaTactics.Add(MediaTactic)

                Try

                    DbContext.SaveChanges()

                    Added = True

                    MediaTacticDTO.ID = MediaTactic.ID

                Catch ex As SqlClient.SqlException
                    Added = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            Add = Added

        End Function
        Public Function Delete(ByRef MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim MediaTactic As AdvantageFramework.Database.Entities.MediaTactic = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaTactic = AdvantageFramework.Database.Procedures.MediaTactic.LoadByMediaTacticID(DbContext, MediaTacticSetupViewModel.SelectedMediaTactic.ID)

                If MediaTactic IsNot Nothing Then

                    DbContext.DeleteEntityObject(MediaTactic)

                    Try

                        DbContext.SaveChanges()

                        Deleted = MediaTacticSetupViewModel.MediaTactics.Remove(MediaTacticSetupViewModel.SelectedMediaTactic)

                    Catch ex As Exception
                        ErrorMessage = "This media tactic is in use and cannot be deleted."
                    End Try

                Else

                    ErrorMessage &= System.Environment.NewLine & "This media tactic is no longer valid in the system."

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Save(ByRef MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim MediaTactic As AdvantageFramework.Database.Entities.MediaTactic = Nothing
            Dim MediaTactics As Generic.List(Of AdvantageFramework.Database.Entities.MediaTactic) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaTactics = DbContext.MediaTactics.ToList

                For Each MediaTacticDTO In MediaTacticSetupViewModel.MediaTactics

                    MediaTactic = MediaTactics.SingleOrDefault(Function(Entity) Entity.ID = MediaTacticDTO.ID)

                    If MediaTactic IsNot Nothing Then

                        MediaTacticDTO.SaveToEntity(MediaTactic)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

            Save = Saved

        End Function
        Public Sub CancelNewItemRow(ByRef MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel)

            MediaTacticSetupViewModel.IsNewRow = False
            MediaTacticSetupViewModel.CancelEnabled = False
            MediaTacticSetupViewModel.DeleteEnabled = MediaTacticSetupViewModel.HasASelectedMediaTactic

        End Sub
        Public Sub SelectionChanged(ByRef MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel,
                                    IsNewItemRow As Boolean,
                                    SelectedMediaTactic As AdvantageFramework.DTO.MediaTactic)

            MediaTacticSetupViewModel.IsNewRow = IsNewItemRow
            MediaTacticSetupViewModel.CancelEnabled = IsNewItemRow
            MediaTacticSetupViewModel.DeleteEnabled = Not IsNewItemRow

            MediaTacticSetupViewModel.SelectedMediaTactic = SelectedMediaTactic

            If MediaTacticSetupViewModel.DeleteEnabled AndAlso MediaTacticSetupViewModel.SelectedMediaTactic Is Nothing Then

                MediaTacticSetupViewModel.DeleteEnabled = False

            End If

        End Sub
        Public Sub InitNewRowEvent(ByRef MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel)

            MediaTacticSetupViewModel.IsNewRow = True
            MediaTacticSetupViewModel.CancelEnabled = True
            MediaTacticSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub UserEntryChanged(ByRef MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel)

            MediaTacticSetupViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef MediaTacticSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaTacticSetupViewModel)

            MediaTacticSetupViewModel.SaveEnabled = False

        End Sub
        Public Function ValidateEntity(MediaTactic As AdvantageFramework.DTO.MediaTactic, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaTactic, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(MediaTactic As AdvantageFramework.DTO.MediaTactic, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As String = String.Empty

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaTactic.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaTactic, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim MediaTactic As AdvantageFramework.DTO.MediaTactic = Nothing

            If PropertyName = AdvantageFramework.DTO.MediaTactic.Properties.Description.ToString Then

                MediaTactic = DTO

                PropertyValue = Value.ToString

                If AdvantageFramework.Database.Procedures.MediaTactic.Load(DbContext).Any(Function(Entity) Entity.ID <> MediaTactic.ID AndAlso
                                                                                                            Entity.Description.ToUpper = DirectCast(PropertyValue, String).ToUpper) Then

                    ErrorText = "Please enter unique description."
                    IsValid = False

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Function SetInactiveFlag(ByRef DTO As AdvantageFramework.DTO.MediaTactic, IsInactive As Boolean) As Boolean

            'objects
            Dim MediaTactic As AdvantageFramework.Database.Entities.MediaTactic = Nothing
            Dim Saved As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTactic = DbContext.MediaTactics.Find(DTO.ID)

                If MediaTactic IsNot Nothing Then

                    DTO.IsInactive = IsInactive

                    DTO.SaveToEntity(MediaTactic)

                    DbContext.Entry(MediaTactic).State = Entity.EntityState.Modified

                    DbContext.SaveChanges()

                    Saved = True

                End If

            End Using

            SetInactiveFlag = Saved

        End Function

#End Region

    End Class

End Namespace
