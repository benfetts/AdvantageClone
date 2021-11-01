Namespace Controller.Media

    Public Class ShareHPUTBookController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum MoveItemDirection
            Down
            Up
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Function ValidateAllBooks(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel,
                                          ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = True

            If ShareHPUTBookViewModel Is Nothing Then

                IsValid = False
                ErrorMessage = "Please select 'Use Latest' or include at least one share book."

            ElseIf Not ShareHPUTBookViewModel.UseLatest Then

                If ShareHPUTBookViewModel.ShareHPUTBooks.Count = 0 Then

                    IsValid = False
                    ErrorMessage = "Please select at least one share book."

                ElseIf (From Entity In ShareHPUTBookViewModel.ShareHPUTBooks
                        Where Entity.HasError
                        Select Entity).Any Then

                    IsValid = False
                    ErrorMessage = "Please resolve errors with share h/put books."

                End If

            End If

            ValidateAllBooks = IsValid

        End Function
        Private Function SaveViewModel(DbContext As AdvantageFramework.Database.DbContext, ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel,
                                       MediaSpotTVResearchID As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim MediaSpotTVResearchBook As AdvantageFramework.Database.Entities.MediaSpotTVResearchBook = Nothing

            If ValidateAllBooks(ShareHPUTBookViewModel, ErrorMessage) Then

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_SPOT_TV_RESEARCH_BOOK WHERE MEDIA_SPOT_TV_RESEARCH_ID={0}", MediaSpotTVResearchID))

                If ShareHPUTBookViewModel.UseLatest Then

                    MediaSpotTVResearchBook = New AdvantageFramework.Database.Entities.MediaSpotTVResearchBook
                    MediaSpotTVResearchBook.MediaSpotTVResearchID = MediaSpotTVResearchID
                    MediaSpotTVResearchBook.UseLatest = True
                    MediaSpotTVResearchBook.LatestStream = ShareHPUTBookViewModel.LatestStream

                    DbContext.MediaSpotTVResearchBooks.Add(MediaSpotTVResearchBook)

                Else

                    For Each ShareHPUTBook In ShareHPUTBookViewModel.ShareHPUTBooks

                        MediaSpotTVResearchBook = New AdvantageFramework.Database.Entities.MediaSpotTVResearchBook
                        MediaSpotTVResearchBook.MediaSpotTVResearchID = MediaSpotTVResearchID
                        MediaSpotTVResearchBook.UseLatest = False
                        MediaSpotTVResearchBook.LatestStream = Nothing
                        MediaSpotTVResearchBook.ShareBookID = ShareHPUTBook.ShareBookID
                        MediaSpotTVResearchBook.HPUTBookID = ShareHPUTBook.HPUTBookID

                        DbContext.MediaSpotTVResearchBooks.Add(MediaSpotTVResearchBook)

                    Next

                End If

                DbContext.SaveChanges()

                Saved = True

            End If

            SaveViewModel = Saved

        End Function
        Private Sub LatestStream(ByRef ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel, Stream As String)

            If String.IsNullOrWhiteSpace(ShareHPUTBookViewModel.LatestStream) Then

                ShareHPUTBookViewModel.LatestStream = Stream

            End If

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Sub DeleteSelectedBooks(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel)

            'objects
            Dim ShareHPUTBooks As Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook) = Nothing

            ShareHPUTBooks = ShareHPUTBookViewModel.SelectedShareHPUTBooks.ToList

            For Each ShareHPUTBook In ShareHPUTBooks

                ShareHPUTBookViewModel.ShareHPUTBooks.Remove(ShareHPUTBook)
                ShareHPUTBookViewModel.SelectedShareHPUTBooks.Remove(ShareHPUTBook)

            Next

        End Sub
        Public Function GetRepositoryNielsenTVBooks(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel, Optional ShareBookID As Nullable(Of Integer) = Nothing) As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            GetRepositoryNielsenTVBooks = GetRepositoryNielsenTVBooks(ShareHPUTBookViewModel.MarketNumber, ShareHPUTBookViewModel.RatingsServiceID, ShareBookID)

        End Function
        Public Function GetRepositoryNielsenTVBooks(NielsenMarketNumber As Integer, Optional RatingsSourceID As Integer = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen,
                                                    Optional ShareBookID As Nullable(Of Integer) = Nothing) As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            'objects
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim BookIDs As IEnumerable(Of Integer) = Nothing
            Dim ImpactCollectionMethods As IEnumerable(Of String) = {"5", "7", "8", "9", "10", "11", "12", "13"}
            Dim NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing
            Dim IsImpactBook As Boolean = False

            If RatingsSourceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                If Session.IsNielsenSetup Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            If ShareBookID.HasValue Then

                                NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, ShareBookID.Value)

                                If NielsenTVBook IsNot Nothing AndAlso ImpactCollectionMethods.Contains(NielsenTVBook.CollectionMethod) Then

                                    IsImpactBook = True

                                End If

                            End If

                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                BookIDs = NielsenDbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC advsp_hosted_spottv_get_book_ids '{0}', {1}", Session.NielsenClientCodeForHosted, NielsenMarketNumber)).ToList

                                If NielsenTVBook IsNot Nothing Then

                                    NielsenTVBooks = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidatedByNielsenMarketNumberAndBookIDs(NielsenDbContext, NielsenMarketNumber, BookIDs).ToList
                                                      Where Entity.Ethnicity = NielsenTVBook.Ethnicity AndAlso
                                                            Entity.Exclusion = NielsenTVBook.Exclusion
                                                      Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                                Else

                                    NielsenTVBooks = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidatedByNielsenMarketNumberAndBookIDs(NielsenDbContext, NielsenMarketNumber, BookIDs).ToList
                                                      Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                                End If

                            Else

                                If NielsenTVBook IsNot Nothing Then

                                    NielsenTVBooks = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidatedByNielsenMarketNumber(NielsenDbContext, NielsenMarketNumber).ToList
                                                      Where Entity.Ethnicity = NielsenTVBook.Ethnicity AndAlso
                                                            Entity.Exclusion = NielsenTVBook.Exclusion
                                                      Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                                Else

                                    NielsenTVBooks = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidatedByNielsenMarketNumber(NielsenDbContext, NielsenMarketNumber).ToList
                                                      Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                                End If

                            End If

                            If ShareBookID.HasValue Then

                                If IsImpactBook Then

                                    NielsenTVBooks = NielsenTVBooks.Where(Function(B) ImpactCollectionMethods.Contains(B.CollectionMethod) = True).ToList

                                Else

                                    NielsenTVBooks = NielsenTVBooks.Where(Function(B) ImpactCollectionMethods.Contains(B.CollectionMethod) = False).ToList

                                End If

                            End If

                        End Using

                    End Using

                Else

                    NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

                End If

            ElseIf RatingsSourceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    NielsenTVBooks = (From Entity In AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadAvailable(DbContext).ToList
                                      Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                End Using

            End If

            GetRepositoryNielsenTVBooks = NielsenTVBooks

        End Function
        Public Function GetRepositoryNielsenTVBooksForCableCDMA(NielsenMarketNumber As Integer, Optional ByVal ShareBookID As Nullable(Of Integer) = Nothing) As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            'objects
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim BookIDs As IEnumerable(Of Integer) = Nothing
            Dim NCCTVAIUELogList As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NCCTVAIUELog) = Nothing
            Dim IDs As IEnumerable(Of Long) = Nothing

            If Session.IsNielsenSetup Then

                'If AllowImpactBooks Then

                NielsenTVBooks = GetRepositoryNielsenTVBooks(NielsenMarketNumber, ShareBookID:=ShareBookID).OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.Month).ThenBy(Function(NB) NB.StreamSort).ToList

                'Else

                '    NielsenTVBooks = GetRepositoryNonImpactNielsenTVBooks(NielsenMarketNumber).OrderByDescending(Function(NB) NB.Year).ThenByDescending(Function(NB) NB.Month).ThenBy(Function(NB) NB.StreamSort).ToList

                'End If

                Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    NielsenDbContext.Database.Connection.Open()

                    NCCTVAIUELogList = AdvantageFramework.Nielsen.Database.Procedures.NCCTVAIUELog.Load(NielsenDbContext).Where(Function(Entity) Entity.Validated = True).ToList

                    For Each NielsenTVBook In NielsenTVBooks.ToList

                        If NCCTVAIUELogList.Any(Function(Entity) CShort(Entity.Year.ToString.Substring(2)) = NielsenTVBook.Year AndAlso
                                                                 Entity.Month = NielsenTVBook.Month) = False Then

                            NielsenTVBooks.Remove(NielsenTVBook)

                        End If

                    Next

                End Using

            Else

                NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            End If

            GetRepositoryNielsenTVBooksForCableCDMA = NielsenTVBooks

        End Function
        Public Function GetRepositoryAllNielsenTVBooks() As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

			'objects
			Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing

			If Session.IsNielsenSetup Then

				Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                    NielsenTVBooks = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidated(NielsenDbContext).ToList
                                      Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                End Using

			Else

				NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

			End If

			GetRepositoryAllNielsenTVBooks = NielsenTVBooks

		End Function
        Public Function Load(MediaSpotTVResearchID As Nullable(Of Integer), MarketCode As String, RatingsServiceID As Integer) As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel

            'objects
            Dim ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel = Nothing
            Dim MediaSpotTVResearchBooks As Generic.List(Of AdvantageFramework.Database.Entities.MediaSpotTVResearchBook) = Nothing
            Dim ShareBookIDs As IEnumerable(Of Integer) = Nothing
            Dim Market As AdvantageFramework.Database.Entities.Market = Nothing

            ShareHPUTBookViewModel = New AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel
            ShareHPUTBookViewModel.RatingsServiceID = RatingsServiceID

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Market = AdvantageFramework.Database.Procedures.Market.LoadByCode(DbContext, MarketCode)

                If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                    If Market IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Market.NielsenTVCode) Then

                        ShareHPUTBookViewModel.MarketNumber = CInt(Market.NielsenTVCode)

                    End If

                ElseIf RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                    If Market IsNot Nothing AndAlso Market.ComscoreNewMarketNumber.HasValue Then

                        ShareHPUTBookViewModel.MarketNumber = Market.ComscoreNewMarketNumber.Value

                    End If

                End If

                ShareHPUTBookViewModel.RepositoryNielsenTVBooks = GetRepositoryNielsenTVBooks(ShareHPUTBookViewModel)

                If MediaSpotTVResearchID.HasValue Then

                    ShareHPUTBookViewModel.ShareHPUTBooks = New Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook)

                    MediaSpotTVResearchBooks = (From Entity In AdvantageFramework.Database.Procedures.MediaSpotTVResearchBook.LoadByMediaSpotTVResearchID(DbContext, MediaSpotTVResearchID.Value)
                                                Select Entity).ToList

                    ShareHPUTBookViewModel.UseLatest = MediaSpotTVResearchBooks.Where(Function(E) E.ShareBookID Is Nothing AndAlso E.UseLatest = True).Any

                    If ShareHPUTBookViewModel.UseLatest Then

                        GetLatestStreamsAvailable(ShareHPUTBookViewModel)

                        ShareHPUTBookViewModel.LatestStream = MediaSpotTVResearchBooks.Where(Function(E) E.ShareBookID Is Nothing AndAlso E.UseLatest = True).FirstOrDefault.LatestStream

                    Else

                        ShareBookIDs = MediaSpotTVResearchBooks.Select(Function(RB) RB.ShareBookID.Value).ToArray

                        If (From Entity In ShareHPUTBookViewModel.RepositoryNielsenTVBooks
                            Where ShareBookIDs.Contains(Entity.ID)
                            Select Entity).Any Then

                            ShareHPUTBookViewModel.ShareHPUTBooks = (From Entity In MediaSpotTVResearchBooks
                                                                     Where Entity.ShareBookID IsNot Nothing
                                                                     Select New AdvantageFramework.DTO.Media.ShareHPUTBook(Entity)).ToList

                        End If

                    End If

                Else

                    ShareHPUTBookViewModel.ShareHPUTBooks = New Generic.List(Of AdvantageFramework.DTO.Media.ShareHPUTBook)

                End If

            End Using

            Load = ShareHPUTBookViewModel

        End Function
        Public Function Save(DbContext As AdvantageFramework.Database.DbContext, ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel, MediaSpotTVResearchID As Integer,
                             ByRef ErrorMessage As String) As Boolean

            Save = SaveViewModel(DbContext, ShareHPUTBookViewModel, MediaSpotTVResearchID, ErrorMessage)

        End Function
        Public Function Save(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel, MediaSpotTVResearchID As Integer,
                             ByRef ErrorMessage As String) As Boolean

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Save = SaveViewModel(DbContext, ShareHPUTBookViewModel, MediaSpotTVResearchID, ErrorMessage)

            End Using

        End Function
        Public Function GetLatestStreamsAvailable(ByRef ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel) As Boolean

            'objects
            Dim StreamsAvailable As Boolean = False
            Dim Streams As IEnumerable(Of String) = Nothing

            If ShareHPUTBookViewModel.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                Using DbContext = New AdvantageFramework.Nielsen.Database.DbContext(Me.Session.NielsenConnectionString, Nothing)

                    Streams = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidatedByNielsenMarketNumber(DbContext, ShareHPUTBookViewModel.MarketNumber)
                               Select Entity.Stream).Distinct.ToArray

                End Using

            ElseIf ShareHPUTBookViewModel.RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Streams = (From Entity In AdvantageFramework.Database.Procedures.ComscoreTVBook.Load(DbContext)
                               Select Entity.Stream).Distinct.ToArray

                End Using

            End If

            ShareHPUTBookViewModel.LatestLOEnabled = False
            ShareHPUTBookViewModel.LatestLSEnabled = False
            ShareHPUTBookViewModel.LatestL1Enabled = False
            ShareHPUTBookViewModel.LatestL3Enabled = False
            ShareHPUTBookViewModel.LatestL7Enabled = False
            ShareHPUTBookViewModel.UseLatest = False
            ShareHPUTBookViewModel.LatestStream = Nothing

            If Streams IsNot Nothing AndAlso Streams.Count > 0 Then

                StreamsAvailable = True
                ShareHPUTBookViewModel.UseLatest = True

                For Each Stream In Streams

                    Select Case Stream

                        Case "LO"

                            ShareHPUTBookViewModel.LatestLOEnabled = True
                            LatestStream(ShareHPUTBookViewModel, "LO")

                        Case "LS"

                            ShareHPUTBookViewModel.LatestLSEnabled = True
                            LatestStream(ShareHPUTBookViewModel, "LS")

                        Case "L1"

                            ShareHPUTBookViewModel.LatestL1Enabled = True
                            LatestStream(ShareHPUTBookViewModel, "L1")

                        Case "L3"

                            ShareHPUTBookViewModel.LatestL3Enabled = True
                            LatestStream(ShareHPUTBookViewModel, "L3")

                        Case "L7"

                            ShareHPUTBookViewModel.LatestL7Enabled = True
                            LatestStream(ShareHPUTBookViewModel, "L7")

                    End Select

                Next

            End If

            GetLatestStreamsAvailable = StreamsAvailable

        End Function
        Public Sub SetSelectedShareHPUTBooks(ByRef ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel,
                                             ShareHPUTBooks As IEnumerable(Of AdvantageFramework.DTO.Media.ShareHPUTBook))

            ShareHPUTBookViewModel.SelectedShareHPUTBooks = ShareHPUTBooks.ToList

        End Sub
        Public Sub SetLatestStream(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel, LatestStream As String)

            ShareHPUTBookViewModel.LatestStream = LatestStream

        End Sub
        Public Sub UseLatest(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel, UseLatest As Boolean, LatestStream As String)

            If UseLatest Then

                ShareHPUTBookViewModel.SelectedShareHPUTBooks.Clear()
                ShareHPUTBookViewModel.ShareHPUTBooks.Clear()

            End If

            ShareHPUTBookViewModel.LatestStream = LatestStream

            ShareHPUTBookViewModel.UseLatest = UseLatest

        End Sub
        Public Sub ValidateShareHPUTBooks(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel)

            'objects
            Dim IsValid As Boolean = True

            For Each ShareHPUTBook In ShareHPUTBookViewModel.ShareHPUTBooks

                Me.ValidateEntity(ShareHPUTBookViewModel, ShareHPUTBook, IsValid)

            Next

        End Sub
        Public Function ValidateEntity(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel,
                                       ShareHPUTBook As AdvantageFramework.DTO.Media.ShareHPUTBook, ByRef IsValid As Boolean) As String

            'objects
            Dim ShareBookIsValid As Boolean = True
            Dim HPUTBookIsValid As Boolean = True
            Dim PropertyErrorText As String = String.Empty
            Dim ErrorText As String = String.Empty

            PropertyErrorText = Me.ValidateProperty(ShareHPUTBookViewModel, ShareHPUTBook, AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.ShareBookID.ToString, ShareBookIsValid, ShareHPUTBook.ShareBookID)

            ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

            PropertyErrorText = Me.ValidateProperty(ShareHPUTBookViewModel, ShareHPUTBook, AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.HPUTBookID.ToString, HPUTBookIsValid, ShareHPUTBook.HPUTBookID)

            ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

            IsValid = (ShareBookIsValid AndAlso HPUTBookIsValid)

            ShareHPUTBook.SetEntityError(ErrorText)

            ValidateEntity = ErrorText

        End Function
        Public Function ValidateProperty(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel,
                                         ShareHPUTBook As AdvantageFramework.DTO.Media.ShareHPUTBook, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyValue As Object = Nothing

            Select Case FieldName

                Case AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.ShareBookID.ToString

                    PropertyValue = Value

                    If PropertyValue Is Nothing OrElse PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Share book is invalid."

                    ElseIf (From Entity In ShareHPUTBookViewModel.ShareHPUTBooks
                            Where Entity.ShareBookID.GetValueOrDefault(0) = DirectCast(PropertyValue, Nullable(Of Integer)).GetValueOrDefault(0) AndAlso
                                  Entity.HPUTBookID.GetValueOrDefault(0) = ShareHPUTBook.HPUTBookID.GetValueOrDefault(0) AndAlso
                                  Entity.ID <> ShareHPUTBook.ID
                            Select Entity.ID).Any Then

                        IsValid = False

                        If ShareHPUTBook.HPUTBookID.HasValue Then

                            ErrorText = "Duplicate share h/put book."

                        Else

                            ErrorText = "Duplicate share book."

                        End If

                    End If

                Case AdvantageFramework.DTO.Media.ShareHPUTBook.Properties.HPUTBookID.ToString

                    PropertyValue = Value

                    If ShareHPUTBook.ShareBookID IsNot Nothing AndAlso PropertyValue IsNot Nothing AndAlso ShareHPUTBook.ShareBookID.GetValueOrDefault(0) = DirectCast(PropertyValue, Nullable(Of Integer)).GetValueOrDefault(0) Then

                        IsValid = False

                        ErrorText = "HPUT Book cannot be the same as the share book."

                    End If

            End Select

            ShareHPUTBook.SetPropertyError(FieldName, ErrorText)

            ValidateProperty = ErrorText

        End Function
        Public Sub MoveBook(ShareHPUTBookViewModel As AdvantageFramework.ViewModels.Media.ShareHPUTBookViewModel,
                            ShareHPUTBook As DTO.Media.ShareHPUTBook, Direction As MoveItemDirection)

            'objects
            Dim OldIndex As Integer = -1

            OldIndex = ShareHPUTBookViewModel.ShareHPUTBooks.IndexOf(ShareHPUTBook)

            ShareHPUTBookViewModel.ShareHPUTBooks.RemoveAt(OldIndex)

            If Direction = MoveItemDirection.Down Then

                ShareHPUTBookViewModel.ShareHPUTBooks.Insert(OldIndex + 1, ShareHPUTBook)

            Else

                ShareHPUTBookViewModel.ShareHPUTBooks.Insert(OldIndex - 1, ShareHPUTBook)

            End If

        End Sub
        Public Function GetRepositoryAllComscoreTVBooks() As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            'objects
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing

            If Session.IsComscoreSetup Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    NielsenTVBooks = (From Entity In AdvantageFramework.Database.Procedures.ComscoreTVBook.Load(DbContext).ToList
                                      Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                End Using

            Else

                NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            End If

            GetRepositoryAllComscoreTVBooks = NielsenTVBooks

        End Function
        Public Function GetRepositoryNonImpactNielsenTVBooks(NielsenMarketNumber As Integer, Optional RatingsSourceID As Integer = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen) As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

            'objects
            Dim NielsenTVBooks As Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook) = Nothing
            Dim BookIDs As IEnumerable(Of Integer) = Nothing
            Dim ImpactCollectionMethods As IEnumerable(Of String) = {"5", "7", "8", "9", "10", "11", "12", "13"}

            If RatingsSourceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                If Session.IsNielsenSetup Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                BookIDs = NielsenDbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC advsp_hosted_spottv_get_book_ids '{0}', {1}", Session.NielsenClientCodeForHosted, NielsenMarketNumber)).ToList

                                NielsenTVBooks = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidatedByNielsenMarketNumberAndBookIDs(NielsenDbContext, NielsenMarketNumber, BookIDs).ToList
                                                  Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                            Else

                                NielsenTVBooks = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadValidatedByNielsenMarketNumber(NielsenDbContext, NielsenMarketNumber).ToList
                                                  Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                            End If

                            NielsenTVBooks = NielsenTVBooks.Where(Function(B) ImpactCollectionMethods.Contains(B.CollectionMethod) = False).ToList

                        End Using

                    End Using

                Else

                    NielsenTVBooks = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook)

                End If

            ElseIf RatingsSourceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    NielsenTVBooks = (From Entity In AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadAvailable(DbContext).ToList
                                      Select New AdvantageFramework.DTO.Media.SpotTV.NielsenTVBook(Entity)).ToList

                End Using

            End If

            GetRepositoryNonImpactNielsenTVBooks = NielsenTVBooks

        End Function

#End Region

#End Region

    End Class

End Namespace
