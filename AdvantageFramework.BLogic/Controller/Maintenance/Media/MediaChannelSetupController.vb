Namespace Controller.Maintenance.Media

    Public Class MediaChannelSetupController
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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel

            'objects
            Dim MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel = Nothing
            Dim MediaChannel As AdvantageFramework.DTO.MediaChannel = Nothing

            MediaChannelSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaChannelSetupViewModel.MediaChannels = AdvantageFramework.Database.Procedures.MediaChannel.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.MediaChannel(Entity)).ToList

            End Using

            MediaChannelSetupViewModel.IsNewRow = False
            MediaChannelSetupViewModel.DeleteEnabled = False
            MediaChannelSetupViewModel.CancelEnabled = False

            Load = MediaChannelSetupViewModel

        End Function
        Public Function Add(ByRef MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel,
                            MediaChannelDTO As AdvantageFramework.DTO.MediaChannel,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim MediaChannel As AdvantageFramework.Database.Entities.MediaChannel = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaChannel = New AdvantageFramework.Database.Entities.MediaChannel

                MediaChannel.DbContext = DbContext

                MediaChannelDTO.SaveToEntity(MediaChannel)

                DbContext.MediaChannels.Add(MediaChannel)

                Try

                    DbContext.SaveChanges()

                    Added = True

                    MediaChannelDTO.ID = MediaChannel.ID

                Catch ex As SqlClient.SqlException
                    Added = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            Add = Added

        End Function
        Public Function Delete(ByRef MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim MediaChannel As AdvantageFramework.Database.Entities.MediaChannel = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaChannel = AdvantageFramework.Database.Procedures.MediaChannel.LoadByMediaChannelID(DbContext, MediaChannelSetupViewModel.SelectedMediaChannel.ID)

                If MediaChannel IsNot Nothing Then

                    DbContext.DeleteEntityObject(MediaChannel)

                    Try

                        DbContext.SaveChanges()

                        Deleted = MediaChannelSetupViewModel.MediaChannels.Remove(MediaChannelSetupViewModel.SelectedMediaChannel)

                    Catch ex As Exception
                        ErrorMessage = "This media channel is in use and cannot be deleted."
                    End Try

                Else

                    ErrorMessage &= System.Environment.NewLine & "This media channel is no longer valid in the system."

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Save(ByRef MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim MediaChannel As AdvantageFramework.Database.Entities.MediaChannel = Nothing
            Dim MediaChannels As Generic.List(Of AdvantageFramework.Database.Entities.MediaChannel) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaChannels = DbContext.MediaChannels.ToList

                For Each MediaChannelDTO In MediaChannelSetupViewModel.MediaChannels

                    MediaChannel = MediaChannels.SingleOrDefault(Function(Entity) Entity.ID = MediaChannelDTO.ID)

                    If MediaChannel IsNot Nothing Then

                        MediaChannelDTO.SaveToEntity(MediaChannel)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

            Save = Saved

        End Function
        Public Sub CancelNewItemRow(ByRef MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel)

            MediaChannelSetupViewModel.IsNewRow = False
            MediaChannelSetupViewModel.CancelEnabled = False
            MediaChannelSetupViewModel.DeleteEnabled = MediaChannelSetupViewModel.HasASelectedMediaChannel

        End Sub
        Public Sub SelectionChanged(ByRef MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel,
                                    IsNewItemRow As Boolean,
                                    SelectedMediaChannel As AdvantageFramework.DTO.MediaChannel)

            MediaChannelSetupViewModel.IsNewRow = IsNewItemRow
            MediaChannelSetupViewModel.CancelEnabled = IsNewItemRow
            MediaChannelSetupViewModel.DeleteEnabled = Not IsNewItemRow

            MediaChannelSetupViewModel.SelectedMediaChannel = SelectedMediaChannel

            If MediaChannelSetupViewModel.DeleteEnabled AndAlso MediaChannelSetupViewModel.SelectedMediaChannel Is Nothing Then

                MediaChannelSetupViewModel.DeleteEnabled = False

            End If

        End Sub
        Public Sub InitNewRowEvent(ByRef MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel)

            MediaChannelSetupViewModel.IsNewRow = True
            MediaChannelSetupViewModel.CancelEnabled = True
            MediaChannelSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub UserEntryChanged(ByRef MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel)

            MediaChannelSetupViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef MediaChannelSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.MediaChannelSetupViewModel)

            MediaChannelSetupViewModel.SaveEnabled = False

        End Sub
        Public Function ValidateEntity(MediaChannel As AdvantageFramework.DTO.MediaChannel, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaChannel, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(MediaChannel As AdvantageFramework.DTO.MediaChannel, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As String = String.Empty

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaChannel.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaChannel, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim MediaChannel As AdvantageFramework.DTO.MediaChannel = Nothing

            If PropertyName = AdvantageFramework.DTO.MediaChannel.Properties.Description.ToString Then

                MediaChannel = DTO

                PropertyValue = Value.ToString

                If AdvantageFramework.Database.Procedures.MediaChannel.Load(DbContext).Any(Function(Entity) Entity.ID <> MediaChannel.ID AndAlso
                                                                                                            Entity.Description.ToUpper = DirectCast(PropertyValue, String).ToUpper) Then

                    ErrorText = "Please enter unique description."
                    IsValid = False

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Function SetInactiveFlag(ByRef DTO As AdvantageFramework.DTO.MediaChannel, IsInactive As Boolean) As Boolean

            'objects
            Dim MediaChannel As AdvantageFramework.Database.Entities.MediaChannel = Nothing
            Dim Saved As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaChannel = DbContext.MediaChannels.Find(DTO.ID)

                If MediaChannel IsNot Nothing Then

                    DTO.IsInactive = IsInactive

                    DTO.SaveToEntity(MediaChannel)

                    DbContext.Entry(MediaChannel).State = Entity.EntityState.Modified

                    DbContext.SaveChanges()

                    Saved = True

                End If

            End Using

            SetInactiveFlag = Saved

        End Function

#End Region

    End Class

End Namespace
