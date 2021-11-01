Namespace Controller.Media

    Public Class MediaRFPMarketCrossReferenceController
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
        Public Function Load(SourceMarketNames As IEnumerable(Of String)) As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel

            'objects
            Dim MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel = Nothing
            Dim MediaRFPMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference = Nothing

            MediaRFPMarketCrossReferenceViewModel = New AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaRFPMarketCrossReferenceViewModel.RepositoryMarketList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Market.LoadByCountryID(DbContext, AdvantageFramework.DTO.Countries.Canada).OrderBy(Function(DP) DP.Code).ToList
                                                                                    Select New AdvantageFramework.DTO.Market(Entity))

                MediaRFPMarketCrossReferenceViewModel.MediaRFPMarketCrossReferenceList.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaRFPMarketCrossReference.Load(DbContext).Include("Market").ToList
                                                                                                Select New AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference(Entity))

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each SourceMarketName In SourceMarketNames

                        If Not MediaRFPMarketCrossReferenceViewModel.MediaRFPMarketCrossReferenceList.Where(Function(CR) CR.SourceMarketCode = SourceMarketName).Any Then

                            MediaRFPMarketCrossReference = New AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference
                            MediaRFPMarketCrossReference.SourceMarketCode = SourceMarketName

                            MediaRFPMarketCrossReferenceViewModel.MediaRFPMarketCrossReferenceList.Add(MediaRFPMarketCrossReference)

                            ValidateDTO(DbContext, DataContext, MediaRFPMarketCrossReference, True)

                        End If

                    Next

                End Using

            End Using

            Load = MediaRFPMarketCrossReferenceViewModel

        End Function
        Public Function Add(MediaRFPMarketCrossReferenceDTO As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim MediaRFPMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaRFPMarketCrossReference = New AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference

                MediaRFPMarketCrossReference.DbContext = DbContext

                MediaRFPMarketCrossReferenceDTO.SaveToEntity(MediaRFPMarketCrossReference)

                DbContext.MediaRFPMarketCrossReferences.Add(MediaRFPMarketCrossReference)

                Try

                    DbContext.SaveChanges()

                    Added = True

                    MediaRFPMarketCrossReferenceDTO.ID = MediaRFPMarketCrossReference.ID

                Catch ex As SqlClient.SqlException
                    Added = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            Add = Added

        End Function
        Public Function Delete(ByRef MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim MediaRFPMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                If MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference.ID = 0 Then

                    Deleted = MediaRFPMarketCrossReferenceViewModel.MediaRFPMarketCrossReferenceList.Remove(MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference)

                Else

                    MediaRFPMarketCrossReference = AdvantageFramework.Database.Procedures.MediaRFPMarketCrossReference.LoadByMediaRFPMarketCrossReferenceID(DbContext, MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference.ID)

                    If MediaRFPMarketCrossReference IsNot Nothing Then

                        DbContext.DeleteEntityObject(MediaRFPMarketCrossReference)

                        DbContext.SaveChanges()

                        Deleted = MediaRFPMarketCrossReferenceViewModel.MediaRFPMarketCrossReferenceList.Remove(MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference)

                    Else

                        ErrorMessage &= System.Environment.NewLine & "This market code is no longer valid in the system."

                    End If

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Save(ByRef MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim MediaRFPMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference = Nothing
            Dim MediaRFPMarketCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaRFPMarketCrossReferences = AdvantageFramework.Database.Procedures.MediaRFPMarketCrossReference.Load(DbContext).ToList

                For Each MediaRFPMarketCrossReferenceDTO In MediaRFPMarketCrossReferenceViewModel.MediaRFPMarketCrossReferenceList.Where(Function(E) E.HasError = False)

                    MediaRFPMarketCrossReference = MediaRFPMarketCrossReferences.SingleOrDefault(Function(Entity) Entity.ID = MediaRFPMarketCrossReferenceDTO.ID)

                    If MediaRFPMarketCrossReference IsNot Nothing Then

                        MediaRFPMarketCrossReferenceDTO.SaveToEntity(MediaRFPMarketCrossReference)

                        DbContext.Entry(MediaRFPMarketCrossReference).State = Entity.EntityState.Modified

                    Else

                        MediaRFPMarketCrossReference = New AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference
                        MediaRFPMarketCrossReference.SourceMarketCode = MediaRFPMarketCrossReferenceDTO.SourceMarketCode
                        MediaRFPMarketCrossReference.MarketCode = MediaRFPMarketCrossReferenceDTO.MarketCode

                        DbContext.MediaRFPMarketCrossReferences.Add(MediaRFPMarketCrossReference)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

            Save = Saved

        End Function
        Public Sub CancelNewItemRow(ByRef MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel)

            MediaRFPMarketCrossReferenceViewModel.IsNewRow = False
            MediaRFPMarketCrossReferenceViewModel.CancelEnabled = False
            MediaRFPMarketCrossReferenceViewModel.DeleteEnabled = MediaRFPMarketCrossReferenceViewModel.HasASelectedMediaRFPMarketCrossReference

        End Sub
        Public Sub SelectionChanged(ByRef MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel,
                                    IsNewItemRow As Boolean,
                                    SelectedMediaRFPMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference)

            MediaRFPMarketCrossReferenceViewModel.IsNewRow = IsNewItemRow
            MediaRFPMarketCrossReferenceViewModel.CancelEnabled = IsNewItemRow
            MediaRFPMarketCrossReferenceViewModel.DeleteEnabled = Not IsNewItemRow

            MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference = SelectedMediaRFPMarketCrossReference

            If MediaRFPMarketCrossReferenceViewModel.DeleteEnabled AndAlso MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference Is Nothing Then

                MediaRFPMarketCrossReferenceViewModel.DeleteEnabled = False

            End If

        End Sub
        Public Sub InitNewRowEvent(ByRef MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel)

            MediaRFPMarketCrossReferenceViewModel.IsNewRow = True
            MediaRFPMarketCrossReferenceViewModel.CancelEnabled = True
            MediaRFPMarketCrossReferenceViewModel.DeleteEnabled = False

        End Sub
        Public Sub SetMarketDescription(ByRef MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel, MarketCode As String)

            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            If String.IsNullOrWhiteSpace(MarketCode) Then

                MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference.MarketDescription = String.Empty

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                    If Market IsNot Nothing Then

                        MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference.MarketDescription = Market.Description

                    Else

                        MediaRFPMarketCrossReferenceViewModel.SelectedMediaRFPMarketCrossReference.MarketDescription = String.Empty

                    End If

                End Using

            End If

        End Sub
        Public Sub UserEntryChanged(ByRef MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel)

            MediaRFPMarketCrossReferenceViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef MediaRFPMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPMarketCrossReferenceViewModel)

            MediaRFPMarketCrossReferenceViewModel.SaveEnabled = False

        End Sub
        Public Function ValidateEntity(MediaRFPMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaRFPMarketCrossReference, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(MediaRFPMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As String = String.Empty

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaRFPMarketCrossReference.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaRFPMarketCrossReference, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim MediaRFPMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference = Nothing

            If PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference.Properties.SourceMarketCode.ToString Then

                MediaRFPMarketCrossReference = DTO

                PropertyValue = Value.ToString

                If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPMarketCrossReference.Load(DbContext)
                    Where Entity.ID <> MediaRFPMarketCrossReference.ID AndAlso
                          Entity.SourceMarketCode.ToUpper = DirectCast(PropertyValue, String).ToUpper).Any Then

                    ErrorText = "Please enter unique source market code."
                    IsValid = False

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
