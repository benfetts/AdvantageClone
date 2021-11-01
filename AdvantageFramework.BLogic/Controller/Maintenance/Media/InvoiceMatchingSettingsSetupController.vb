Namespace Controller.Maintenance.Media

    Public Class InvoiceMatchingSettingSetupController

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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel

            Dim InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel = Nothing

            InvoiceMatchingSettingViewModel = New AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                InvoiceMatchingSettingViewModel.InvoiceMatchingSettings = (From Item In AdvantageFramework.Database.Procedures.InvoiceMatchingSetting.Load(DbContext).Include("Client")
                                                                           Select Item).OrderBy(Function(dtl) dtl.ClientCode).ToList

                InvoiceMatchingSettingViewModel.Clients = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList

                InvoiceMatchingSettingViewModel.MediaTypes = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes))
                                                              Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            Load = InvoiceMatchingSettingViewModel

        End Function
        Public Function Add(InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If InvoiceMatchingSetting.IsEntityBeingAdded() Then

                    InvoiceMatchingSetting.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.InvoiceMatchingSetting.Insert(DbContext, InvoiceMatchingSetting, ErrorMessage) Then

                        Added = True

                    End If

                End If

            End Using

            Add = Added

        End Function
        Public Function Delete(InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel) As Boolean

            'objects
            Dim Deleted As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.InvoiceMatchingSetting.Delete(DbContext, InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting) Then

                        If InvoiceMatchingSettingViewModel.InvoiceMatchingSettings.Remove(InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting) = False Then

                            Deleted = False

                        End If

                    End If

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Save(InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each InvoiceMatchingSetting In InvoiceMatchingSettingViewModel.InvoiceMatchingSettings

                    If AdvantageFramework.Database.Procedures.InvoiceMatchingSetting.Update(DbContext, InvoiceMatchingSetting) = False Then

                        Saved = False

                    End If

                Next

            End Using

            Save = Saved

        End Function
        Public Sub CancelNewItemRow(InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel)

            InvoiceMatchingSettingViewModel.IsNewRow = False
            InvoiceMatchingSettingViewModel.CancelEnabled = False
            InvoiceMatchingSettingViewModel.DeleteEnabled = InvoiceMatchingSettingViewModel.HasASelectedInvoiceMatchingSetting AndAlso InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.ClientCode IsNot Nothing

        End Sub
        Public Sub InitNewRowEvent(InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel)

            InvoiceMatchingSettingViewModel.IsNewRow = True
            InvoiceMatchingSettingViewModel.CancelEnabled = True
            InvoiceMatchingSettingViewModel.DeleteEnabled = False

        End Sub
        Public Sub InvoiceMatchingSettingSelectionChanged(InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel,
                                                          IsNewItemRow As Boolean,
                                                          SelectedInvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting)

            InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting = SelectedInvoiceMatchingSetting

            InvoiceMatchingSettingViewModel.IsNewRow = IsNewItemRow
            InvoiceMatchingSettingViewModel.CancelEnabled = IsNewItemRow
            InvoiceMatchingSettingViewModel.DeleteEnabled = Not IsNewItemRow AndAlso InvoiceMatchingSettingViewModel.HasASelectedInvoiceMatchingSetting AndAlso InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.ClientCode IsNot Nothing

        End Sub
        Public Function ValidateEntity(InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting, ByRef IsValid As Boolean) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                InvoiceMatchingSetting.DbContext = DbContext

                ErrorText = InvoiceMatchingSetting.ValidateEntity(IsValid)

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                InvoiceMatchingSetting.DbContext = DbContext

                ErrorText = InvoiceMatchingSetting.ValidateEntityProperty(FieldName, IsValid, Value)

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Sub CopyTo(InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel, SelectedClients As IEnumerable)

            Dim InvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each SelectedClient In SelectedClients

                    InvoiceMatchingSetting = New Database.Entities.InvoiceMatchingSetting
                    InvoiceMatchingSetting.DbContext = DbContext

                    InvoiceMatchingSetting.ClientCode = SelectedClient.Code
                    InvoiceMatchingSetting.ClientName = DbContext.Clients.Find(SelectedClient.Code).Name

                    InvoiceMatchingSetting.MediaTypeCode = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.MediaTypeCode
                    InvoiceMatchingSetting.VerifyRate = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.VerifyRate
                    InvoiceMatchingSetting.VerifyNetwork = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.VerifyNetwork
                    InvoiceMatchingSetting.VerifySchedule = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.VerifySchedule
                    InvoiceMatchingSetting.VerifyDay = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.VerifyDay
                    InvoiceMatchingSetting.VerifyTime = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.VerifyTime
                    InvoiceMatchingSetting.VerifyTimeSep = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.VerifyTimeSep
                    InvoiceMatchingSetting.VerifyAdNumber = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.VerifyAdNumber
                    InvoiceMatchingSetting.VerifyLength = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.VerifyLength
                    InvoiceMatchingSetting.AdjacencyBefore = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.AdjacencyBefore
                    InvoiceMatchingSetting.AdjacencyAfter = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.AdjacencyAfter
                    InvoiceMatchingSetting.BookendMaxSeparation = InvoiceMatchingSettingViewModel.SelectedInvoiceMatchingSetting.BookendMaxSeparation

                    If AdvantageFramework.Database.Procedures.InvoiceMatchingSetting.Insert(DbContext, InvoiceMatchingSetting, Nothing) Then

                        InvoiceMatchingSettingViewModel.InvoiceMatchingSettings.Add(InvoiceMatchingSetting)

                    End If

                Next

            End Using

        End Sub
        Public Function GetAvailableClients(InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel, MediaTypeCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Client)

            Dim ClientCodes As IEnumerable(Of String) = Nothing

            ClientCodes = InvoiceMatchingSettingViewModel.InvoiceMatchingSettings.Where(Function(Entity) Entity.MediaTypeCode = MediaTypeCode AndAlso Entity.ClientCode IsNot Nothing).Select(Function(Entity) Entity.ClientCode).ToArray

            GetAvailableClients = (From Entity In InvoiceMatchingSettingViewModel.Clients
                                   Where ClientCodes.Contains(Entity.Code) = False
                                   Select Entity).ToList

        End Function
        Public Function GetClientName(ByRef InvoiceMatchingSettingViewModel As AdvantageFramework.ViewModels.Maintenance.Media.InvoiceMatchingSettingViewModel, ClientCode As String) As String

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            Client = (From Entity In InvoiceMatchingSettingViewModel.Clients
                      Where Entity.Code = ClientCode
                      Select Entity).SingleOrDefault

            If Client IsNot Nothing Then

                GetClientName = Client.Name

            Else

                GetClientName = ""

            End If

        End Function

#End Region

#End Region

    End Class

End Namespace
