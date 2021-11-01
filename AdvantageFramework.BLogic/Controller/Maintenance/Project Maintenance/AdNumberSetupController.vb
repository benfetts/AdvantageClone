Namespace Controller.Maintenance.ProjectManagement

    Public Class AdNumberSetupController
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


#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load(Optional ByVal ClientCode As String = Nothing) As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel

            Dim AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel = Nothing

            AdNumberSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel
            AdNumberSetupViewModel.ClientCode = ClientCode
            AdNumberSetupViewModel.Session = Me.Session

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AdNumberSetupViewModel.UserCanUploadDocument = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_AdNumber)

                AdNumberSetupViewModel.IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                If ClientCode IsNot Nothing Then

                    AdNumberSetupViewModel.AdNumbers.AddRange(From Entity In AdvantageFramework.Database.Procedures.Ad.LoadByClientCode(DbContext, ClientCode).ToList
                                                              Select New AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber(Entity, DbContext))

                Else

                    AdNumberSetupViewModel.AdNumbers.AddRange(From Entity In AdvantageFramework.Database.Procedures.Ad.Load(DbContext).ToList
                                                              Select New AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber(Entity, DbContext))

                End If

                AdNumberSetupViewModel.Clients = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList

                AdNumberSetupViewModel.Blackplates = AdvantageFramework.Database.Procedures.Blackplate.Load(DbContext).ToList

                AdNumberSetupViewModel.MediaTypes = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.AccountPayableImportMediaType)).Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            Load = AdNumberSetupViewModel

        End Function
        Public Function GetRepositoryClients(ClientCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Client)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If String.IsNullOrWhiteSpace(ClientCode) Then

                    GetRepositoryClients = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList

                Else

                    GetRepositoryClients = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                                            Where Entity.Code = ClientCode
                                            Select Entity).ToList

                End If

            End Using

        End Function
        Public Function GetRepositoryDivisions(ClientCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Division)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GetRepositoryDivisions = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode).Where(Function(Entity) Entity.IsActive = 1).ToList

            End Using

        End Function
        Public Function GetRepositoryProducts(ClientCode As String, DivisionCode As String) As Generic.List(Of AdvantageFramework.Database.Entities.Product)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GetRepositoryProducts = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).Where(Function(Entity) Entity.IsActive = 1).ToList

            End Using

        End Function
        Public Sub ClientCodeChanged(ByRef AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel,
                                     ClientCode As String, ByRef AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber)

            'objects
            Dim DivisionViews As Generic.List(Of AdvantageFramework.Database.Views.DivisionView) = Nothing
            Dim ProductViews As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            If String.IsNullOrWhiteSpace(ClientCode) = False Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        DivisionViews = AdvantageFramework.Database.Procedures.DivisionView.LoadByClientCode(DbContext, ClientCode).ToList

                    End Using

                Catch ex As Exception

                End Try

                If DivisionViews IsNot Nothing AndAlso DivisionViews.Count = 1 Then

                    AdNumber.DivisionCode = DivisionViews.FirstOrDefault.DivisionCode

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            ProductViews = AdvantageFramework.Database.Procedures.ProductView.LoadByClientAndDivisionCode(DbContext, ClientCode, AdNumber.DivisionCode).ToList

                        End Using

                    Catch ex As Exception

                    End Try

                    If ProductViews IsNot Nothing AndAlso ProductViews.Count = 1 Then

                        AdNumber.ProductCode = ProductViews.FirstOrDefault.ProductCode

                    End If

                End If

            Else

                AdNumber.DivisionCode = Nothing
                AdNumber.ProductCode = Nothing

            End If

        End Sub
        Public Sub DivisionCodeChanged(ByRef AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel,
                                       DivisionCode As String, ByRef AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber)

            'objects
            Dim ProductViews As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing

            If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        ProductViews = AdvantageFramework.Database.Procedures.ProductView.LoadByClientAndDivisionCode(DbContext, AdNumber.ClientCode, DivisionCode).ToList

                    End Using

                Catch ex As Exception

                End Try

                If ProductViews IsNot Nothing AndAlso ProductViews.Count = 1 Then

                    AdNumber.ProductCode = ProductViews.FirstOrDefault.ProductCode

                End If

            Else

                AdNumber.ProductCode = Nothing

            End If

        End Sub
        Public Function GetRepositoryBlackplates() As Generic.List(Of AdvantageFramework.Database.Entities.Blackplate)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                GetRepositoryBlackplates = AdvantageFramework.Database.Procedures.Blackplate.LoadAllActive(DbContext).ToList

            End Using

        End Function
        Public Sub Save(AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel)

            'objects
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each AdNumber In AdNumberSetupViewModel.AdNumbers

                    Ad = DbContext.Ads.Find(AdNumber.Number)

                    If Ad IsNot Nothing Then

                        AdNumber.SaveToEntity(Ad)

                        AdvantageFramework.Database.Procedures.Ad.Update(DbContext, Ad)

                    End If

                Next

            End Using

        End Sub
        Public Function UpdateIsInactive(IsInactive As Boolean, ByRef AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel) As Boolean

            'objects
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim Updated As Boolean = False

            If AdNumberSetupViewModel.HasOnlyOneSelectedAdNumber Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Ad = DbContext.Ads.Find(AdNumberSetupViewModel.SelectedAdNumbers.First.Number)

                    If Ad IsNot Nothing Then

                        Ad.IsInactive = If(IsInactive, Nothing, 1)

                        Updated = AdvantageFramework.Database.Procedures.Ad.Update(DbContext, Ad)

                    End If

                End Using

            End If

            UpdateIsInactive = Updated

        End Function
        Public Sub Delete(ByRef AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel)

            Dim RemoveFromCollection As Generic.List(Of String) = Nothing

            RemoveFromCollection = New Generic.List(Of String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each AdNumber In AdNumberSetupViewModel.SelectedAdNumbers

                    If AdvantageFramework.Database.Procedures.Ad.DeleteByAdNumber(DbContext, AdNumber.Number) Then

                        RemoveFromCollection.Add(AdNumber.Number)

                    End If

                Next

            End Using

            AdNumberSetupViewModel.AdNumbers = (From Entity In AdNumberSetupViewModel.AdNumbers
                                                Where RemoveFromCollection.Contains(Entity.Number) = False
                                                Select Entity).ToList

            AdNumberSetupViewModel.SelectedAdNumbers = Nothing

        End Sub
        Public Sub AdNumbers_InitNewRowEvent(ByRef AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel)

            AdNumberSetupViewModel.IsNewRow = True
            AdNumberSetupViewModel.CancelEnabled = True
            AdNumberSetupViewModel.DeleteEnabled = False

        End Sub
        Public Sub AdNumbers_SelectedChanged(ByRef AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel,
                                             IsNewItemRow As Boolean,
                                             AdNumbers As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber))

            AdNumberSetupViewModel.SelectedAdNumbers = AdNumbers

            AdNumberSetupViewModel.IsNewRow = IsNewItemRow
            AdNumberSetupViewModel.CancelEnabled = IsNewItemRow
            AdNumberSetupViewModel.DeleteEnabled = (Not IsNewItemRow AndAlso AdNumberSetupViewModel.HasASelectedAdNumber)

        End Sub
        Public Function ValidateEntity(DTO As AdvantageFramework.DTO.BaseClass, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, DTO, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            If FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.StartDate.ToString OrElse
                    FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.ExpirationDate.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Ad = New AdvantageFramework.Database.Entities.Ad

                    AdNumber.SaveToEntity(Ad)

                    Ad.DbContext = DbContext

                    ErrorText = Ad.ValidateEntityProperty(FieldName, IsValid, Value)

                    AdNumber.SetPropertyError(FieldName, ErrorText)

                End Using

            End If

            ValidateProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber = Nothing

            If TypeOf DTO Is AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber Then

                AdNumber = DTO

                Select Case PropertyName

                    Case AdvantageFramework.Database.Entities.Ad.Properties.StartDate.ToString

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing Then

                            If AdNumber.ExpirationDate.HasValue Then

                                If AdNumber.ExpirationDate.Value < CDate(PropertyValue) Then

                                    IsValid = False

                                    ErrorText = "Please enter a valid start date."

                                End If

                            End If

                        End If

                    Case AdvantageFramework.Database.Entities.Ad.Properties.ExpirationDate.ToString

                        PropertyValue = Value

                        If PropertyValue IsNot Nothing Then

                            If AdNumber.StartDate.HasValue Then

                                If AdNumber.StartDate.Value > CDate(PropertyValue) Then

                                    IsValid = False

                                    ErrorText = "Please enter a valid expiration date."

                                End If

                            End If

                        End If

                End Select

            End If

            ValidateCustomProperties = ErrorText

        End Function
        Public Function AddAdNumber(ByRef AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel,
                                    AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber,
                                    ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Ad = New AdvantageFramework.Database.Entities.Ad
                Ad.DbContext = DbContext

                AdNumber.SaveToEntity(Ad)

                Added = AdvantageFramework.Database.Procedures.Ad.Insert(DbContext, Ad)

            End Using

            AddAdNumber = Added

        End Function
        Public Function DeleteDocument(AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel) As Boolean

            'objects
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Deleted As Boolean = False
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Document = DbContext.Documents.Find(AdNumberSetupViewModel.SelectedAdNumbers.First.DocumentID.Value)

                If Document IsNot Nothing Then

                    Deleted = AdvantageFramework.Database.Procedures.Document.Delete(DbContext, Document)

                    If Deleted Then

                        Ad = DbContext.Ads.Find(AdNumberSetupViewModel.SelectedAdNumbers.First.Number)

                        If Ad IsNot Nothing Then

                            Ad.DocumentID = Nothing

                            DbContext.Entry(Ad).State = Entity.EntityState.Modified
                            DbContext.SaveChanges()

                            AdNumberSetupViewModel.SelectedAdNumbers.First.DocumentIsURL = False
                            AdNumberSetupViewModel.SelectedAdNumbers.First.DocumentID = Nothing
                            AdNumberSetupViewModel.SelectedAdNumbers.First.DocumentName = Nothing

                        End If

                    End If

                End If

            End Using

            DeleteDocument = Deleted

        End Function
        Public Function GetDocument(DocumentID As Integer) As AdvantageFramework.Database.Entities.Document

            'objects
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Document = DbContext.Documents.Find(DocumentID)

            End Using

            GetDocument = Document

        End Function
        Public Sub RefreshDocument(AdNumberSetupViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel)

            'objects
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Ad = DbContext.Ads.Find(AdNumberSetupViewModel.SelectedAdNumbers.First.Number)

                If Ad IsNot Nothing AndAlso Ad.DocumentID.HasValue Then

                    Document = DbContext.Documents.Find(Ad.DocumentID.Value)

                    If Document IsNot Nothing Then

                        AdNumberSetupViewModel.SelectedAdNumbers.First.DocumentIsURL = False
                        AdNumberSetupViewModel.SelectedAdNumbers.First.DocumentID = Document.ID
                        AdNumberSetupViewModel.SelectedAdNumbers.First.DocumentName = Document.FileName

                        If Document.MIMEType = "URL" Then

                            AdNumberSetupViewModel.SelectedAdNumbers.First.DocumentIsURL = True

                        End If

                    End If

                End If

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
