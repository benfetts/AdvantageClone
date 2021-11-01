Namespace Controller.Maintenance.Media

    Public Class CableNetworkSetupController
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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel

            'objects
            Dim CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel = Nothing
            Dim CableNetworkStation As AdvantageFramework.DTO.CableNetworkStation = Nothing

            CableNetworkSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                CableNetworkSetupViewModel.CableNetworkStations = AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.CableNetworkStation(Entity)).ToList

            End Using

            CableNetworkSetupViewModel.IsNewRow = False
            CableNetworkSetupViewModel.DeleteEnabled = False
            CableNetworkSetupViewModel.CancelEnabled = False

            Load = CableNetworkSetupViewModel

        End Function
        Public Function Add(ByRef CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel,
                            CableNetworkStationDTO As AdvantageFramework.DTO.CableNetworkStation,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim CableNetworkStation As AdvantageFramework.Database.Entities.CableNetworkStation = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                CableNetworkStation = New AdvantageFramework.Database.Entities.CableNetworkStation

                CableNetworkStation.DbContext = DbContext

                CableNetworkStationDTO.SaveToEntity(CableNetworkStation)

                DbContext.CableNetworkStations.Add(CableNetworkStation)

                Try

                    DbContext.SaveChanges()

                    Added = True

                    CableNetworkStationDTO.ID = CableNetworkStation.ID

                Catch ex As SqlClient.SqlException
                    Added = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            Add = Added

        End Function
        Public Function Delete(ByRef CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim CableNetworkStation As AdvantageFramework.Database.Entities.CableNetworkStation = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                CableNetworkStation = AdvantageFramework.Database.Procedures.CableNetworkStation.LoadByCableNetworkStationID(DbContext, CableNetworkSetupViewModel.SelectedCableNetworkStation.ID)

                If CableNetworkStation IsNot Nothing Then

                    DbContext.DeleteEntityObject(CableNetworkStation)

                    DbContext.SaveChanges()

                    Deleted = CableNetworkSetupViewModel.CableNetworkStations.Remove(CableNetworkSetupViewModel.SelectedCableNetworkStation)

                Else

                    ErrorMessage &= System.Environment.NewLine & "This cable network station is no longer valid in the system."

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Save(ByRef CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim CableNetworkStation As AdvantageFramework.Database.Entities.CableNetworkStation = Nothing
            Dim CableNetworkStations As Generic.List(Of AdvantageFramework.Database.Entities.CableNetworkStation) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                CableNetworkStations = DbContext.CableNetworkStations.ToList

                For Each CableNetworkStationDTO In CableNetworkSetupViewModel.CableNetworkStations

                    CableNetworkStation = CableNetworkStations.SingleOrDefault(Function(Entity) Entity.ID = CableNetworkStationDTO.ID)

                    If CableNetworkStation IsNot Nothing Then

                        CableNetworkStationDTO.SaveToEntity(CableNetworkStation)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

            Save = Saved

        End Function
        Public Sub CancelNewItemRow(ByRef CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel)

            CableNetworkSetupViewModel.IsNewRow = False
            CableNetworkSetupViewModel.CancelEnabled = False
            CableNetworkSetupViewModel.DeleteEnabled = CableNetworkSetupViewModel.HasASelectedCableNetworkStation

        End Sub
        Public Sub SelectionChanged(ByRef CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel,
                                    IsNewItemRow As Boolean,
                                    SelectedCableNetworkStation As AdvantageFramework.DTO.CableNetworkStation)

            CableNetworkSetupViewModel.IsNewRow = IsNewItemRow
            CableNetworkSetupViewModel.CancelEnabled = IsNewItemRow
            CableNetworkSetupViewModel.DeleteEnabled = Not IsNewItemRow

            CableNetworkSetupViewModel.SelectedCableNetworkStation = SelectedCableNetworkStation

            If CableNetworkSetupViewModel.DeleteEnabled AndAlso CableNetworkSetupViewModel.SelectedCableNetworkStation Is Nothing Then

                CableNetworkSetupViewModel.DeleteEnabled = False

            End If

        End Sub
        Public Sub InitNewRowEvent(ByRef CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel)

            CableNetworkSetupViewModel.IsNewRow = True
            CableNetworkSetupViewModel.CancelEnabled = True
            CableNetworkSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub UserEntryChanged(ByRef CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel)

            CableNetworkSetupViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef CableNetworkSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Media.CableNetworkSetupViewModel)

            CableNetworkSetupViewModel.SaveEnabled = False

        End Sub
        Public Function ValidateEntity(CableNetworkStation As AdvantageFramework.DTO.CableNetworkStation, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, CableNetworkStation, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(CableNetworkStation As AdvantageFramework.DTO.CableNetworkStation, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As String = String.Empty

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(CableNetworkStation.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, CableNetworkStation, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim CableNetworkStation As AdvantageFramework.DTO.CableNetworkStation = Nothing

            If PropertyName = AdvantageFramework.DTO.CableNetworkStation.Properties.Code.ToString Then

                CableNetworkStation = DTO

                PropertyValue = Value.ToString

                If AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext).Any(Function(Entity) Entity.ID <> CableNetworkStation.ID AndAlso
                                                                                                                   Entity.Code.ToUpper = DirectCast(PropertyValue, String).ToUpper) Then

                    ErrorText = "Please enter unique code."
                    IsValid = False

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Function SetInactiveFlag(ByRef DTO As AdvantageFramework.DTO.CableNetworkStation, IsInactive As Boolean) As Boolean

            'objects
            Dim CableNetworkStation As AdvantageFramework.Database.Entities.CableNetworkStation = Nothing
            Dim Saved As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                CableNetworkStation = DbContext.CableNetworkStations.Find(DTO.ID)

                If CableNetworkStation IsNot Nothing Then

                    DTO.IsInactive = IsInactive

                    DTO.SaveToEntity(CableNetworkStation)

                    DbContext.Entry(CableNetworkStation).State = Entity.EntityState.Modified

                    DbContext.SaveChanges()

                    Saved = True

                End If

            End Using

            SetInactiveFlag = Saved

        End Function

#End Region

    End Class

End Namespace
