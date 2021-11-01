Namespace Controller.Media

    Public Class MediaRFPVendorMarketCrossReferenceController
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
        Public Function Load(VendorCode As String, SourceMarketNames As IEnumerable(Of String)) As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel

            'objects
            Dim MediaRFPVendorMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel = Nothing
            Dim MediaRFPVendorMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference = Nothing

            MediaRFPVendorMarketCrossReferenceViewModel = New AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaRFPVendorMarketCrossReferenceViewModel.RepositoryMarketList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Market.LoadByCountryID(DbContext, AdvantageFramework.DTO.Countries.Canada).OrderBy(Function(DP) DP.Code).ToList
                                                                                          Select New AdvantageFramework.DTO.Market(Entity))

                MediaRFPVendorMarketCrossReferenceViewModel.MediaRFPVendorMarketCrossReferenceList.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaRFPVendorMarketCrossReference.LoadByVendorCode(DbContext, VendorCode).ToList
                                                                                                            Select New AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference(Entity))

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each SourceMarketName In SourceMarketNames

                        If Not MediaRFPVendorMarketCrossReferenceViewModel.MediaRFPVendorMarketCrossReferenceList.Where(Function(CR) CR.VendorMarketCode = SourceMarketName).Any Then

                            MediaRFPVendorMarketCrossReference = New AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference
                            MediaRFPVendorMarketCrossReference.VendorCode = VendorCode
                            MediaRFPVendorMarketCrossReference.VendorMarketCode = SourceMarketName

                            MediaRFPVendorMarketCrossReferenceViewModel.MediaRFPVendorMarketCrossReferenceList.Add(MediaRFPVendorMarketCrossReference)

                            ValidateDTO(DbContext, DataContext, MediaRFPVendorMarketCrossReference, True)

                        End If

                    Next

                End Using

            End Using

            Load = MediaRFPVendorMarketCrossReferenceViewModel

        End Function
        Public Function Add(MediaRFPVendorMarketCrossReferenceDTO As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim MediaRFPVendorMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorMarketCrossReference = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaRFPVendorMarketCrossReference = New AdvantageFramework.Database.Entities.MediaRFPVendorMarketCrossReference

                MediaRFPVendorMarketCrossReference.DbContext = DbContext

                MediaRFPVendorMarketCrossReferenceDTO.SaveToEntity(MediaRFPVendorMarketCrossReference)

                DbContext.MediaRFPVendorMarketCrossReferences.Add(MediaRFPVendorMarketCrossReference)

                Try

                    DbContext.SaveChanges()

                    Added = True

                    MediaRFPVendorMarketCrossReferenceDTO.ID = MediaRFPVendorMarketCrossReference.ID

                Catch ex As SqlClient.SqlException
                    Added = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            Add = Added

        End Function
        Public Function Delete(ByRef MediaRFPVendorMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim MediaRFPVendorMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorMarketCrossReference = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                If MediaRFPVendorMarketCrossReferenceViewModel.SelectedMediaRFPVendorMarketCrossReference.ID = 0 Then

                    Deleted = MediaRFPVendorMarketCrossReferenceViewModel.MediaRFPVendorMarketCrossReferenceList.Remove(MediaRFPVendorMarketCrossReferenceViewModel.SelectedMediaRFPVendorMarketCrossReference)

                Else

                    MediaRFPVendorMarketCrossReference = AdvantageFramework.Database.Procedures.MediaRFPVendorMarketCrossReference.LoadByMediaRFPVendorMarketCrossReferenceID(DbContext, MediaRFPVendorMarketCrossReferenceViewModel.SelectedMediaRFPVendorMarketCrossReference.ID)

                    If MediaRFPVendorMarketCrossReference IsNot Nothing Then

                        DbContext.DeleteEntityObject(MediaRFPVendorMarketCrossReference)

                        DbContext.SaveChanges()

                        Deleted = MediaRFPVendorMarketCrossReferenceViewModel.MediaRFPVendorMarketCrossReferenceList.Remove(MediaRFPVendorMarketCrossReferenceViewModel.SelectedMediaRFPVendorMarketCrossReference)

                    Else

                        ErrorMessage &= System.Environment.NewLine & "This vendor market code is no longer valid in the system."

                    End If

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Save(ByRef MediaRFPVendorMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim MediaRFPVendorMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorMarketCrossReference = Nothing
            Dim MediaRFPVendorMarketCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPVendorMarketCrossReference) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaRFPVendorMarketCrossReferences = DbContext.MediaRFPVendorMarketCrossReferences.ToList

                For Each MediaRFPVendorMarketCrossReferenceDTO In MediaRFPVendorMarketCrossReferenceViewModel.MediaRFPVendorMarketCrossReferenceList.Where(Function(E) E.HasError = False)

                    MediaRFPVendorMarketCrossReference = MediaRFPVendorMarketCrossReferences.SingleOrDefault(Function(Entity) Entity.ID = MediaRFPVendorMarketCrossReferenceDTO.ID)

                    If MediaRFPVendorMarketCrossReference IsNot Nothing Then

                        MediaRFPVendorMarketCrossReferenceDTO.SaveToEntity(MediaRFPVendorMarketCrossReference)

                    Else

                        MediaRFPVendorMarketCrossReference = New AdvantageFramework.Database.Entities.MediaRFPVendorMarketCrossReference
                        MediaRFPVendorMarketCrossReference.VendorCode = MediaRFPVendorMarketCrossReferenceDTO.VendorCode
                        MediaRFPVendorMarketCrossReference.VendorMarketCode = MediaRFPVendorMarketCrossReferenceDTO.VendorMarketCode
                        MediaRFPVendorMarketCrossReference.MarketCode = MediaRFPVendorMarketCrossReferenceDTO.MarketCode

                        DbContext.MediaRFPVendorMarketCrossReferences.Add(MediaRFPVendorMarketCrossReference)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

            Save = Saved

        End Function
        Public Sub CancelNewItemRow(ByRef MediaRFPVendorMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel)

            MediaRFPVendorMarketCrossReferenceViewModel.IsNewRow = False
            MediaRFPVendorMarketCrossReferenceViewModel.CancelEnabled = False
            MediaRFPVendorMarketCrossReferenceViewModel.DeleteEnabled = MediaRFPVendorMarketCrossReferenceViewModel.HasASelectedMediaRFPVendorMarketCrossReference

        End Sub
        Public Sub SelectionChanged(ByRef MediaRFPVendorMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel,
                                    IsNewItemRow As Boolean,
                                    SelectedMediaRFPVendorMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference)

            MediaRFPVendorMarketCrossReferenceViewModel.IsNewRow = IsNewItemRow
            MediaRFPVendorMarketCrossReferenceViewModel.CancelEnabled = IsNewItemRow
            MediaRFPVendorMarketCrossReferenceViewModel.DeleteEnabled = Not IsNewItemRow

            MediaRFPVendorMarketCrossReferenceViewModel.SelectedMediaRFPVendorMarketCrossReference = SelectedMediaRFPVendorMarketCrossReference

            If MediaRFPVendorMarketCrossReferenceViewModel.DeleteEnabled AndAlso MediaRFPVendorMarketCrossReferenceViewModel.SelectedMediaRFPVendorMarketCrossReference Is Nothing Then

                MediaRFPVendorMarketCrossReferenceViewModel.DeleteEnabled = False

            End If

        End Sub
        Public Sub InitNewRowEvent(ByRef MediaRFPVendorMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel)

            MediaRFPVendorMarketCrossReferenceViewModel.IsNewRow = True
            MediaRFPVendorMarketCrossReferenceViewModel.CancelEnabled = True
            MediaRFPVendorMarketCrossReferenceViewModel.DeleteEnabled = False

        End Sub
        Public Sub UserEntryChanged(ByRef MediaRFPVendorMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel)

            MediaRFPVendorMarketCrossReferenceViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef MediaRFPVendorMarketCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorMarketCrossReferenceViewModel)

            MediaRFPVendorMarketCrossReferenceViewModel.SaveEnabled = False

        End Sub
        Public Function ValidateEntity(MediaRFPVendorMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaRFPVendorMarketCrossReference, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(MediaRFPVendorMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As String = String.Empty

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaRFPVendorMarketCrossReference.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaRFPVendorMarketCrossReference, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim MediaRFPVendorMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference = Nothing

            If PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference.Properties.VendorMarketCode.ToString Then

                MediaRFPVendorMarketCrossReference = DTO

                PropertyValue = Value.ToString

                If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPVendorMarketCrossReference.Load(DbContext)
                    Where Entity.ID <> MediaRFPVendorMarketCrossReference.ID AndAlso
                          Entity.VendorCode = MediaRFPVendorMarketCrossReference.VendorCode AndAlso
                          Entity.VendorMarketCode.ToUpper = DirectCast(PropertyValue, String).ToUpper).Any Then

                    ErrorText = "Please enter unique vendor market code."
                    IsValid = False

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
