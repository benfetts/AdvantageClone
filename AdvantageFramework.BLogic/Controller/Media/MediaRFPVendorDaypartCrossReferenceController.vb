Namespace Controller.Media

    Public Class MediaRFPVendorDaypartCrossReferenceController
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
        Public Function Load(VendorCode As String, MediaTypeCode As String, DaypartNames As IEnumerable(Of String)) As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel

            'objects
            Dim MediaRFPVendorDaypartCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel = Nothing
            Dim MediaRFPVendorDaypartCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference = Nothing

            MediaRFPVendorDaypartCrossReferenceViewModel = New AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                If MediaTypeCode = "T" Then

                    MediaRFPVendorDaypartCrossReferenceViewModel.RepositoryDaypartList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).OrderBy(Function(DP) DP.Code).ToList
                                                                                                Select New AdvantageFramework.DTO.Daypart(Entity))

                ElseIf MediaTypeCode = "R" Then

                    MediaRFPVendorDaypartCrossReferenceViewModel.RepositoryDaypartList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).OrderBy(Function(DP) DP.Code).ToList
                                                                                                Select New AdvantageFramework.DTO.Daypart(Entity))

                End If

                MediaRFPVendorDaypartCrossReferenceViewModel.MediaRFPVendorDaypartCrossReferenceList.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaRFPVendorDaypartCrossReference.LoadByVendorCode(DbContext, VendorCode).ToList
                                                                                                              Select New AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference(Entity))

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each DaypartName In DaypartNames

                        If Not MediaRFPVendorDaypartCrossReferenceViewModel.MediaRFPVendorDaypartCrossReferenceList.Where(Function(CR) CR.VendorDaypartCode = DaypartName).Any Then

                            MediaRFPVendorDaypartCrossReference = New AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference
                            MediaRFPVendorDaypartCrossReference.VendorCode = VendorCode
                            MediaRFPVendorDaypartCrossReference.VendorDaypartCode = DaypartName

                            MediaRFPVendorDaypartCrossReferenceViewModel.MediaRFPVendorDaypartCrossReferenceList.Add(MediaRFPVendorDaypartCrossReference)

                            ValidateDTO(DbContext, DataContext, MediaRFPVendorDaypartCrossReference, True)

                        End If

                    Next

                End Using

            End Using

            Load = MediaRFPVendorDaypartCrossReferenceViewModel

        End Function
        Public Function Add(MediaRFPVendorDaypartCrossReferenceDTO As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference,
                            ByRef ErrorMessage As String) As Boolean

            'objects
            Dim IsValid As Boolean = True
            Dim MediaRFPVendorDaypartCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaRFPVendorDaypartCrossReference = New AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference

                MediaRFPVendorDaypartCrossReference.DbContext = DbContext

                MediaRFPVendorDaypartCrossReferenceDTO.SaveToEntity(MediaRFPVendorDaypartCrossReference)

                DbContext.MediaRFPVendorDaypartCrossReferences.Add(MediaRFPVendorDaypartCrossReference)

                Try

                    DbContext.SaveChanges()

                    Added = True

                    MediaRFPVendorDaypartCrossReferenceDTO.ID = MediaRFPVendorDaypartCrossReference.ID

                Catch ex As SqlClient.SqlException
                    Added = False
                    ErrorMessage = ex.Message
                End Try

            End Using

            Add = Added

        End Function
        Public Function Delete(ByRef MediaRFPVendorDaypartCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel,
                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim MediaRFPVendorDaypartCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                If MediaRFPVendorDaypartCrossReferenceViewModel.SelectedMediaRFPVendorDaypartCrossReference.ID = 0 Then

                    Deleted = MediaRFPVendorDaypartCrossReferenceViewModel.MediaRFPVendorDaypartCrossReferenceList.Remove(MediaRFPVendorDaypartCrossReferenceViewModel.SelectedMediaRFPVendorDaypartCrossReference)

                Else

                    MediaRFPVendorDaypartCrossReference = AdvantageFramework.Database.Procedures.MediaRFPVendorDaypartCrossReference.LoadByMediaRFPVendorDaypartCrossReferenceID(DbContext, MediaRFPVendorDaypartCrossReferenceViewModel.SelectedMediaRFPVendorDaypartCrossReference.ID)

                    If MediaRFPVendorDaypartCrossReference IsNot Nothing Then

                        DbContext.DeleteEntityObject(MediaRFPVendorDaypartCrossReference)

                        DbContext.SaveChanges()

                        Deleted = MediaRFPVendorDaypartCrossReferenceViewModel.MediaRFPVendorDaypartCrossReferenceList.Remove(MediaRFPVendorDaypartCrossReferenceViewModel.SelectedMediaRFPVendorDaypartCrossReference)

                    Else

                        ErrorMessage &= System.Environment.NewLine & "This vendor daypart code is no longer valid in the system."

                    End If

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Save(ByRef MediaRFPVendorDaypartCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel) As Boolean

            'objects
            Dim Saved As Boolean = True
            Dim MediaRFPVendorDaypartCrossReference As AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference = Nothing
            Dim MediaRFPVendorDaypartCrossReferences As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                MediaRFPVendorDaypartCrossReferences = DbContext.MediaRFPVendorDaypartCrossReferences.ToList

                For Each MediaRFPVendorDaypartCrossReferenceDTO In MediaRFPVendorDaypartCrossReferenceViewModel.MediaRFPVendorDaypartCrossReferenceList

                    MediaRFPVendorDaypartCrossReference = MediaRFPVendorDaypartCrossReferences.SingleOrDefault(Function(Entity) Entity.ID = MediaRFPVendorDaypartCrossReferenceDTO.ID)

                    If MediaRFPVendorDaypartCrossReference IsNot Nothing Then

                        MediaRFPVendorDaypartCrossReferenceDTO.SaveToEntity(MediaRFPVendorDaypartCrossReference)

                    Else

                        MediaRFPVendorDaypartCrossReference = New AdvantageFramework.Database.Entities.MediaRFPVendorDaypartCrossReference
                        MediaRFPVendorDaypartCrossReference.VendorCode = MediaRFPVendorDaypartCrossReferenceDTO.VendorCode
                        MediaRFPVendorDaypartCrossReference.VendorDaypartCode = MediaRFPVendorDaypartCrossReferenceDTO.VendorDaypartCode.Trim.ToUpper
                        MediaRFPVendorDaypartCrossReference.DaypartID = MediaRFPVendorDaypartCrossReferenceDTO.DaypartID

                        DbContext.MediaRFPVendorDaypartCrossReferences.Add(MediaRFPVendorDaypartCrossReference)

                    End If

                Next

                DbContext.SaveChanges()

            End Using

            Save = Saved

        End Function
        Public Sub CancelNewItemRow(ByRef MediaRFPVendorDaypartCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel)

            MediaRFPVendorDaypartCrossReferenceViewModel.IsNewRow = False
            MediaRFPVendorDaypartCrossReferenceViewModel.CancelEnabled = False
            MediaRFPVendorDaypartCrossReferenceViewModel.DeleteEnabled = MediaRFPVendorDaypartCrossReferenceViewModel.HasASelectedMediaRFPVendorDaypartCrossReference

        End Sub
        Public Sub SelectionChanged(ByRef MediaRFPVendorDaypartCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel,
                                    IsNewItemRow As Boolean,
                                    SelectedMediaRFPVendorDaypartCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference)

            MediaRFPVendorDaypartCrossReferenceViewModel.IsNewRow = IsNewItemRow
            MediaRFPVendorDaypartCrossReferenceViewModel.CancelEnabled = IsNewItemRow
            MediaRFPVendorDaypartCrossReferenceViewModel.DeleteEnabled = Not IsNewItemRow

            MediaRFPVendorDaypartCrossReferenceViewModel.SelectedMediaRFPVendorDaypartCrossReference = SelectedMediaRFPVendorDaypartCrossReference

            If MediaRFPVendorDaypartCrossReferenceViewModel.DeleteEnabled AndAlso MediaRFPVendorDaypartCrossReferenceViewModel.SelectedMediaRFPVendorDaypartCrossReference Is Nothing Then

                MediaRFPVendorDaypartCrossReferenceViewModel.DeleteEnabled = False

            End If

        End Sub
        Public Sub InitNewRowEvent(ByRef MediaRFPVendorDaypartCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel)

            MediaRFPVendorDaypartCrossReferenceViewModel.IsNewRow = True
            MediaRFPVendorDaypartCrossReferenceViewModel.CancelEnabled = True
            MediaRFPVendorDaypartCrossReferenceViewModel.DeleteEnabled = False

        End Sub
        Public Sub UserEntryChanged(ByRef MediaRFPVendorDaypartCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel)

            MediaRFPVendorDaypartCrossReferenceViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef MediaRFPVendorDaypartCrossReferenceViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel)

            MediaRFPVendorDaypartCrossReferenceViewModel.SaveEnabled = False

        End Sub
        Public Function ValidateEntity(MediaRFPVendorDaypartCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, MediaRFPVendorDaypartCrossReference, IsValid)

                End Using

            End Using

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(MediaRFPVendorDaypartCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PropertyValue As String = String.Empty

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(MediaRFPVendorDaypartCrossReference.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTOProperty(DbContext, DataContext, MediaRFPVendorDaypartCrossReference, PropertyDescriptor, IsValid, Value)

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing
            Dim MediaRFPVendorDaypartCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference = Nothing

            If PropertyName = AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference.Properties.VendorDaypartCode.ToString Then

                MediaRFPVendorDaypartCrossReference = DTO

                PropertyValue = Value.ToString

                If (From Entity In AdvantageFramework.Database.Procedures.MediaRFPVendorDaypartCrossReference.Load(DbContext)
                    Where Entity.ID <> MediaRFPVendorDaypartCrossReference.ID AndAlso
                          Entity.VendorCode = MediaRFPVendorDaypartCrossReference.VendorCode AndAlso
                          Entity.VendorDaypartCode.ToUpper = DirectCast(PropertyValue, String).ToUpper).Any Then

                    ErrorText = "Please enter unique vendor daypart code."
                    IsValid = False

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
