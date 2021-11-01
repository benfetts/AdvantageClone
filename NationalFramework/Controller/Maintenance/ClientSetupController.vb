Namespace Controller.Maintenance

    Public Class ClientSetupController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ConnectionString As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function Delete(DbContext As NationalFramework.Database.DbContext, Client As NationalFramework.Database.Entities.Client,
                                ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True
            Dim Deleted As Boolean = False

            If IsValid Then

                Try

                    DbContext.Entry(Of NationalFramework.Database.Entities.Client)(Client).State = Entity.EntityState.Deleted

                    DbContext.SaveChanges()

                    Deleted = True

                Catch ex As SqlClient.SqlException
                    ErrorMessage = ex.Message & Space(1) & If(ex.InnerException IsNot Nothing, ex.InnerException.Message, "")
                End Try

            End If

            Delete = Deleted

        End Function

#Region " Public "

        Public Sub New(ConnectionString As String)

            _ConnectionString = ConnectionString

        End Sub
        Public Function Add(DTOClient As NationalFramework.DTO.Client,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Client As NationalFramework.Database.Entities.Client = Nothing
            Dim IsValid As Boolean = True
            Dim Added As Boolean = False

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                Client = New NationalFramework.Database.Entities.Client

                DTOClient.SaveToEntity(Client)

                ErrorMessage = Client.ValidateEntity(IsValid)

                If IsValid Then

                    Added = NationalFramework.Database.Procedures.Client.Insert(DbContext, Client, ErrorMessage)

                    If Added Then

                        DTOClient.ID = Client.ID

                    End If

                End If

            End Using

            Add = Added

        End Function
        Public Sub CancelNewItemRow(ClientSetupViewModel As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel)

            ClientSetupViewModel.IsNewRow = False

        End Sub
        Public Sub ClearChanged(ByRef ClientSetupViewModel As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel)

            ClientSetupViewModel.SaveEnabled = False

        End Sub
        Public Sub UserEntryChanged(ByRef ClientSetupViewModel As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel)

            ClientSetupViewModel.SaveEnabled = True

        End Sub
        Public Function Delete(ClientSetupViewModel As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                If ClientSetupViewModel.SelectedClient IsNot Nothing Then

                    If NationalFramework.Database.Procedures.Client.DeleteByID(DbContext, ClientSetupViewModel.SelectedClient.ID, ErrorMessage) Then

                        Deleted = True

                        ClientSetupViewModel.Clients.Remove(ClientSetupViewModel.SelectedClient)

                    End If

                End If

            End Using

            Delete = Deleted

        End Function
        Public Sub InitNewRowEvent(ClientSetupViewModel As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel)

            ClientSetupViewModel.IsNewRow = True

        End Sub
        Public Function Load() As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel

            Dim ClientSetupViewModel As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel = Nothing

            ClientSetupViewModel = New NationalFramework.ViewModels.Maintenance.ClientSetupViewModel

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                ClientSetupViewModel.Clients = New Generic.List(Of NationalFramework.DTO.Client)

                ClientSetupViewModel.Clients.AddRange(From Entity In NationalFramework.Database.Procedures.Client.Load(DbContext).OrderBy(Function(Entity) Entity.Name).ToList
                                                      Select New NationalFramework.DTO.Client(Entity))

            End Using

            Load = ClientSetupViewModel

        End Function
        Public Function Save(ClientSetupViewModel As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim Client As NationalFramework.Database.Entities.Client = Nothing
            Dim Clients As Generic.List(Of NationalFramework.Database.Entities.Client) = Nothing

            Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                Clients = NationalFramework.Database.Procedures.Client.Load(DbContext).ToList

                For Each DTOClient In ClientSetupViewModel.Clients

                    Client = Clients.SingleOrDefault(Function(Entity) Entity.ID = DTOClient.ID)

                    If Client IsNot Nothing Then

                        Client.DbContext = DbContext

                        DTOClient.SaveToEntity(Client)

                        DbContext.UpdateObject(Client)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

            Save = Saved

        End Function
        Public Sub ClientSelectionChanged(ClientSetupViewModel As NationalFramework.ViewModels.Maintenance.ClientSetupViewModel,
                                          IsNewItemRow As Boolean,
                                          SelectedClient As NationalFramework.DTO.Client)

            ClientSetupViewModel.IsNewRow = IsNewItemRow

            ClientSetupViewModel.SelectedClient = SelectedClient

        End Sub
        Public Function UpdateFlags(DTOClient As NationalFramework.DTO.Client,
                                    ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim IsValid As Boolean = True
            Dim Client As NationalFramework.Database.Entities.Client = Nothing

            If DTOClient IsNot Nothing Then

                Using DbContext = New NationalFramework.Database.DbContext(_ConnectionString)

                    Client = DbContext.Clients.Find(DTOClient.ID)

                    If Client IsNot Nothing Then

                        Client.IsInactive = DTOClient.IsInactive

                        ErrorMessage = Client.ValidateEntity(IsValid)

                        If IsValid Then

                            DbContext.Entry(Client).State = Entity.EntityState.Modified

                            DbContext.SaveChanges()

                            Saved = True

                        End If

                    End If

                End Using

            End If

            UpdateFlags = Saved

        End Function
        Public Function ValidateEntity(Client As NationalFramework.DTO.Client, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = Nothing
            Dim ClientEntity As NationalFramework.Database.Entities.Client = Nothing
            Dim DTOProperties As Generic.List(Of ComponentModel.PropertyDescriptor) = Nothing

            Using DbContext As New NationalFramework.Database.DbContext(_ConnectionString)

                ClientEntity = New NationalFramework.Database.Entities.Client

                Client.SaveToEntity(ClientEntity)

                ClientEntity.DbContext = DbContext

                ErrorText = ClientEntity.ValidateEntity(IsValid)

                Client.SetEntityError(ErrorText)

                DTOProperties = System.ComponentModel.TypeDescriptor.GetProperties(Client.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

                For Each PropertyDescriptor In System.ComponentModel.TypeDescriptor.GetProperties(ClientEntity.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)()

                    If DTOProperties.Contains(PropertyDescriptor) Then

                        Client.SetPropertyError(PropertyDescriptor.Name, ClientEntity.LoadErrorText(PropertyDescriptor.Name))

                    End If

                Next

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(Client As NationalFramework.DTO.Client, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = Nothing
            Dim ClientEntity As NationalFramework.Database.Entities.Client = Nothing

            Using DbContext As New NationalFramework.Database.DbContext(_ConnectionString)

                ClientEntity = New NationalFramework.Database.Entities.Client

                If FieldName = NationalFramework.DTO.Client.Properties.Code.ToString Then

                    Client.Code = Value

                ElseIf FieldName = NationalFramework.DTO.Client.Properties.Name.ToString Then

                    Client.Name = Value

                End If

                Client.SaveToEntity(ClientEntity)
                ClientEntity.DbContext = DbContext

                ErrorText = ClientEntity.ValidateEntityProperty(FieldName, IsValid, Value)

                Client.SetPropertyError(FieldName, ErrorText)

            End Using

            ValidateProperty = ErrorText

        End Function

#End Region

#End Region

    End Class

End Namespace
