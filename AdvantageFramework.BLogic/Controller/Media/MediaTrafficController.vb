Namespace Controller.Media

    Public Class MediaTrafficController
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

        Private Function AddMediaTraffic(DbContext As AdvantageFramework.Database.DbContext, Revision As AdvantageFramework.DTO.Media.Traffic.Revision, ByRef MediaTrafficID As Integer, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaTraffic As AdvantageFramework.Database.Entities.MediaTraffic = Nothing
            Dim MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision = Nothing
            Dim MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup = Nothing
            Dim Added As Boolean = False

            Try

                DbContext.Database.Connection.Open()

                DbTransaction = DbContext.Database.BeginTransaction

                MediaTraffic = New AdvantageFramework.Database.Entities.MediaTraffic

                MediaTraffic.DbContext = DbContext

                DbContext.MediaTraffics.Add(MediaTraffic)

                DbContext.SaveChanges()

                MediaTrafficID = MediaTraffic.ID

                MediaTrafficRevision = New AdvantageFramework.Database.Entities.MediaTrafficRevision
                MediaTrafficRevision.DbContext = DbContext
                MediaTrafficRevision.MediaTrafficID = MediaTrafficID
                MediaTrafficRevision.CreatedByUserCode = DbContext.UserCode
                MediaTrafficRevision.CreatedDate = Now

                Revision.SaveToEntity(MediaTrafficRevision)

                If AdvantageFramework.Database.Procedures.MediaTrafficRevision.Insert(DbContext, MediaTrafficRevision, ErrorMessage) Then

                    Revision.ID = MediaTrafficRevision.ID
                    Revision.MediaTrafficID = MediaTrafficID

                    MediaTrafficCreativeGroup = New AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup
                    MediaTrafficCreativeGroup.DbContext = DbContext
                    MediaTrafficCreativeGroup.MediaTrafficRevisionID = MediaTrafficRevision.ID
                    MediaTrafficCreativeGroup.Name = "Default"
                    MediaTrafficCreativeGroup.IsDefault = True

                    If AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.Insert(DbContext, MediaTrafficCreativeGroup, ErrorMessage) Then

                        DbTransaction.Commit()

                        Added = True

                    Else

                        Throw New Exception(ErrorMessage)

                    End If

                Else

                    Throw New Exception(ErrorMessage)

                End If

            Catch ex As Exception
                DbTransaction.Rollback()
                ErrorMessage = ex.Message
            Finally
                AddMediaTraffic = Added

                If DbContext.Database.Connection.State = ConnectionState.Open Then

                    DbContext.Database.Connection.Close()

                End If

            End Try

        End Function
        Private Function GetNewBookendDetail(MediaTrafficCreativeGroupID As Integer, BookendSequenceNumber As Short, Position As Short, Length As Short) As AdvantageFramework.DTO.Media.Traffic.Detail

            Dim Detail As AdvantageFramework.DTO.Media.Traffic.Detail = Nothing

            Detail = New AdvantageFramework.DTO.Media.Traffic.Detail()

            Detail.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroupID
            Detail.Length = Length
            Detail.IsBookend = True
            Detail.BookendSequenceNumber = BookendSequenceNumber
            Detail.BookendName = "Bookend " & Detail.BookendSequenceNumber.ToString
            Detail.Position = Position
            Detail.Modified = True

            GetNewBookendDetail = Detail

        End Function
        Private Sub LoadRevisions(DbContext As AdvantageFramework.Database.DbContext, ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim MediaTrafficIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision = Nothing

            MediaTrafficIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketTraffic.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaTrafficViewModel.MediaBroadcastWorksheetMarketID)
                               Select Entity.MediaTrafficID).Distinct.ToArray

            MediaTrafficViewModel.Revisions.Clear()

            For Each MediaTrafficID In MediaTrafficIDs

                MediaTrafficRevision = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficRevision.Load(DbContext).Include("MediaTrafficCreativeGroups")
                                        Where Entity.MediaTrafficID = MediaTrafficID
                                        Select Entity).OrderByDescending(Function(MTR) MTR.RevisionNumber).FirstOrDefault

                If MediaTrafficRevision IsNot Nothing Then

                    MediaTrafficViewModel.Revisions.Add(New AdvantageFramework.DTO.Media.Traffic.Revision(MediaTrafficRevision, DbContext, MediaTrafficViewModel.MediaBroadcastWorksheetStartDate, MediaTrafficViewModel.MediaBroadcastWorksheetEndDate))

                End If

            Next

            MediaTrafficViewModel.CreativeGroups.Clear()
            MediaTrafficViewModel.Details.Clear()

            MediaTrafficViewModel.SelectedRevision = Nothing
            MediaTrafficViewModel.SelectedCreativeGroup = Nothing
            MediaTrafficViewModel.SelectedDetails = Nothing

            LoadRepositoryMediaTrafficCreativeGroupList(DbContext, MediaTrafficViewModel)

        End Sub
        Private Sub ValidateDetailRotation(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            'Dim AdNumberLength As Generic.List(Of AdNumberLength) = Nothing
            Dim Length As Generic.List(Of Short) = Nothing
            Dim Pos As Short = 0
            Dim Rotation As Short = 0

            'validate non-bookends
            Length = New Generic.List(Of Short)
            For Each Dtl In (From Entity In MediaTrafficViewModel.Details
                             Where Entity.Position.GetValueOrDefault(0) = 0 AndAlso
                                   Entity.IsDeleted = False
                             Select New With {.Length = Entity.Length.GetValueOrDefault(0)}).Distinct.ToList

                Length.Add(Dtl.Length)

            Next

            For Each Item In Length

                Rotation = MediaTrafficViewModel.Details.Where(Function(Dtl) Dtl.Position.GetValueOrDefault(0) = 0 AndAlso Dtl.IsDeleted = False AndAlso Dtl.Length.GetValueOrDefault(0) = Item).Sum(Function(Dtl) Dtl.Rotation)

                If Rotation = 100 Then

                    For Each Dtl In MediaTrafficViewModel.Details.Where(Function(Entity) Entity.Position.GetValueOrDefault(0) = Pos AndAlso Entity.IsDeleted = False AndAlso Entity.Length.GetValueOrDefault(0) = Item)

                        Dtl.SetPropertyError(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Rotation.ToString, "")

                    Next

                Else

                    For Each Dtl In MediaTrafficViewModel.Details.Where(Function(Entity) Entity.Position.GetValueOrDefault(0) = Pos AndAlso Entity.IsDeleted = False AndAlso Entity.Length.GetValueOrDefault(0) = Item)

                        Dtl.SetPropertyError(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Rotation.ToString, "Rotation for Length does not total 100.")

                    Next

                End If

            Next

            'validate bookends
            For PosCounter As Integer = 1 To 2

                Pos = PosCounter

                Rotation = MediaTrafficViewModel.Details.Where(Function(Dtl) Dtl.Position.GetValueOrDefault(0) = Pos AndAlso Dtl.IsDeleted = False).Sum(Function(Dtl) Dtl.Rotation)

                If Rotation = 100 Then

                    For Each Dtl In MediaTrafficViewModel.Details.Where(Function(Entity) Entity.Position.GetValueOrDefault(0) = Pos)

                        Dtl.SetPropertyError(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Rotation.ToString, "")

                    Next

                Else

                    For Each Dtl In MediaTrafficViewModel.Details.Where(Function(Entity) Entity.Position.GetValueOrDefault(0) = Pos)

                        Dtl.SetPropertyError(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Rotation.ToString, "Rotation for postion " & Pos.ToString & " does not total 100.")

                    Next

                End If

            Next

            For Each Dtl In MediaTrafficViewModel.Details.Where(Function(Entity) Entity.IsDeleted)

                Dtl.SetPropertyError(AdvantageFramework.DTO.Media.Traffic.Detail.Properties.Rotation.ToString, "")

            Next

        End Sub
        Private Sub LoadMediaTrafficVendors(DbContext As AdvantageFramework.Database.DbContext, ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim RevisionIDs As IEnumerable(Of Integer) = Nothing

            RevisionIDs = (From Revision In MediaTrafficViewModel.Revisions
                           Select Revision.ID).ToArray

            MediaTrafficViewModel.Vendors.Clear()

            MediaTrafficViewModel.Vendors.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendor.LoadByMediaTrafficRevisionIDs(DbContext, RevisionIDs).Include("MediaTrafficRevision").Include("MediaTrafficVendorStatuses").ToList
                                                   Select New AdvantageFramework.DTO.Media.Traffic.Vendor(Entity))

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function GetDayparts(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel) As Generic.List(Of AdvantageFramework.DTO.Daypart)

            'objects
            Dim DaypartList As Generic.List(Of AdvantageFramework.DTO.Daypart) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If MediaTrafficViewModel.MediaType = "T" Then

                    DaypartList = (From DP In AdvantageFramework.Database.Procedures.Daypart.LoadByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList
                                   Select New AdvantageFramework.DTO.Daypart(DP)).OrderBy(Function(Entity) Entity.Code).ToList

                ElseIf MediaTrafficViewModel.MediaType = "R" Then

                    DaypartList = (From DP In AdvantageFramework.Database.Procedures.Daypart.LoadByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList
                                   Select New AdvantageFramework.DTO.Daypart(DP)).OrderBy(Function(Entity) Entity.Code).ToList

                End If

            End Using

            GetDayparts = DaypartList

        End Function
        Public Function GetAdNumbers(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel) As Generic.List(Of AdvantageFramework.DTO.AdNumber)

            'objects
            Dim AdNumberList As Generic.List(Of AdvantageFramework.DTO.AdNumber) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                AdNumberList = (From Ad In AdvantageFramework.Database.Procedures.Ad.LoadAllActiveByClientCodeAndNotExpired(DbContext, MediaTrafficViewModel.ClientCode).ToList
                                Select New AdvantageFramework.DTO.AdNumber(Ad)).ToList

            End Using

            GetAdNumbers = AdNumberList

        End Function
        Public Function GetVendors(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, MediaTrafficRevisionID As Integer) As Generic.List(Of AdvantageFramework.DTO.Vendor)

            Dim MediaBroadcastWorksheetMarketDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail) = Nothing
            Dim VendorCodes As Generic.List(Of String) = Nothing
            Dim VendorList As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.DTO.Vendor) = Nothing
            Dim MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision = Nothing

            Vendors = New Generic.List(Of AdvantageFramework.DTO.Vendor)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaTrafficRevision = AdvantageFramework.Database.Procedures.MediaTrafficRevision.LoadByID(DbContext, MediaTrafficRevisionID)

                MediaBroadcastWorksheetMarketDetails = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaTrafficViewModel.MediaBroadcastWorksheetMarketID).Include("MediaBroadcastWorksheetMarketDetailDates").ToList

                VendorCodes = New Generic.List(Of String)

                For Each MediaBroadcastWorksheetMarketDetail In MediaBroadcastWorksheetMarketDetails

                    If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketDetailDates.Any(Function(DD) DD.OrderNumber.HasValue) Then

                        If VendorCodes.Contains(MediaBroadcastWorksheetMarketDetail.VendorCode) = False AndAlso
                                MediaTrafficViewModel.Vendors.Where(Function(Vendor) Vendor.MediaTrafficRevisionID = MediaTrafficRevisionID AndAlso
                                                                                     Vendor.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode).Any = False Then

                            If (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendor.Load(DbContext)
                                Where Entity.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode AndAlso
                                      Entity.MediaTrafficRevisionID = MediaTrafficRevisionID).Any = False Then

                                VendorCodes.Add(MediaBroadcastWorksheetMarketDetail.VendorCode)

                            End If

                        End If

                    End If

                Next

                If VendorCodes.Count > 0 Then

                    VendorList = (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                  Where VendorCodes.Contains(Entity.Code)
                                  Select Entity).ToList

                    Vendors = (From Entity In VendorList
                               Select New AdvantageFramework.DTO.Vendor(Entity)).ToList

                End If

            End Using

            GetVendors = Vendors

        End Function
        Public Function GetCreativeGroups(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel) As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.CreativeGroup)

            Dim CreativeGroups As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.CreativeGroup) = Nothing
            Dim ExistingMediaTrafficCreativeGroupIDs As IEnumerable(Of Integer) = Nothing

            If MediaTrafficViewModel.SelectedVendor IsNot Nothing AndAlso MediaTrafficViewModel.SelectedVendor.MediaTrafficRevisionID.HasValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    ExistingMediaTrafficCreativeGroupIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.LoadByMediaTrafficMediaTrafficVendorID(DbContext, MediaTrafficViewModel.SelectedVendor.ID)
                                                            Select Entity.MediaTrafficCreativeGroupID).ToArray

                    CreativeGroups = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficViewModel.SelectedVendor.MediaTrafficRevisionID.Value).ToList
                                      Select New AdvantageFramework.DTO.Media.Traffic.CreativeGroup(Entity)).ToList

                    CreativeGroups = CreativeGroups.Where(Function(CG) ExistingMediaTrafficCreativeGroupIDs.Contains(CG.ID) = False).ToList

                End Using

            End If

            GetCreativeGroups = CreativeGroups

        End Function
        Public Function GetVendorCreativeGroups(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, MediaTrafficVendorID As Integer) As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                GetVendorCreativeGroups = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.LoadByMediaTrafficMediaTrafficVendorID(DbContext, MediaTrafficVendorID).Include("MediaTrafficVendor").ToList
                                           Select New AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup(Entity)).ToList

            End Using

        End Function
        Public Function GetCableNetworksByVendor(MediaBroadcastWorksheetMarketID As Integer, Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor, VendorCreativeGroup As AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup,
                                                 CableNetworkStations As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)) As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.CableNetworkStation)

            Dim MediaTrafficCreativeGroupIDs As IEnumerable(Of Integer) = Nothing
            Dim OmitCableNetworkStationCodes As Generic.List(Of String) = Nothing
            Dim CableNetworkCodes As IEnumerable(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaTrafficCreativeGroupIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, Vendor.MediaTrafficRevisionID)
                                                Where Entity.ID <> VendorCreativeGroup.MediaTrafficCreativeGroupID
                                                Select Entity.ID).ToArray

                OmitCableNetworkStationCodes = New Generic.List(Of String)

                For Each CNSC In (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.Load(DbContext)
                                  Where Entity.MediaTrafficVendorID = Vendor.ID AndAlso
                                        MediaTrafficCreativeGroupIDs.Contains(Entity.MediaTrafficCreativeGroupID)
                                  Select Entity.CableNetworkStationCodes).ToList

                    OmitCableNetworkStationCodes.AddRange(Split(CNSC, ",").ToArray)

                Next

                CableNetworkCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketID)
                                     Where Entity.VendorCode = Vendor.VendorCode AndAlso
                                           OmitCableNetworkStationCodes.Contains(Entity.CableNetworkStationCode) = False
                                     Select Entity.CableNetworkStationCode).Distinct.ToArray

                GetCableNetworksByVendor = (From Entity In CableNetworkStations
                                            Where CableNetworkCodes.Contains(Entity.Code) = True
                                            Select Entity).ToList

            End Using

        End Function
        Public Sub LoadMediaTrafficRevisions(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadRevisions(DbContext, MediaTrafficViewModel)

            End Using

        End Sub
        Public Sub LoadMediaTrafficCreativeGroups(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTrafficViewModel.CreativeGroups.Clear()

                MediaTrafficViewModel.CreativeGroups.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficViewModel.SelectedRevision.ID).ToList
                                                              Select New AdvantageFramework.DTO.Media.Traffic.CreativeGroup(Entity))

            End Using

        End Sub
        Public Sub LoadMediaTrafficDetail(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim SelectedDetails As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail) = Nothing

            SelectedDetails = MediaTrafficViewModel.SelectedDetails

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTrafficViewModel.Details.Clear()

                MediaTrafficViewModel.Details.AddRange(From Entity In AdvantageFramework.Database.Procedures.MediaTrafficDetail.LoadByMediaTrafficCreativeGroupID(DbContext, MediaTrafficViewModel.SelectedCreativeGroup.ID).Include("Ad").Include("MediaTrafficCreativeGroup").Include("MediaTrafficDetailDocuments").ToList
                                                       Select New AdvantageFramework.DTO.Media.Traffic.Detail(Entity))

                MediaTrafficViewModel.SelectedDetails = SelectedDetails

            End Using

        End Sub
        Public Sub LoadMediaTrafficVendors(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                LoadMediaTrafficVendors(DbContext, MediaTrafficViewModel)

            End Using

        End Sub
        Public Function LoadGuidelines(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel) As String

            'objects
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim Guidelines As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaTrafficViewModel.MediaBroadcastWorksheetMarketID)

                If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing Then

                    StandardComment = AdvantageFramework.Database.Procedures.StandardComment.LoadByOfficeCodeAndApplicationCode(DbContext, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Product.OfficeCode, "Media Traffic")

                    If StandardComment IsNot Nothing Then

                        Guidelines = StandardComment.HtmlComment

                    End If

                End If

            End Using

            LoadGuidelines = Guidelines

        End Function
        Public Sub LoadMediaTrafficStatuses(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaTrafficViewModel.VendorStatuses = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Traffic.VendorStatus)(String.Format("exec advsp_media_traffic_vendor_statuses {0}", MediaTrafficViewModel.SelectedVendor.ID)).ToList

            End Using

        End Sub
        Private Sub LoadRepositoryMediaTrafficCreativeGroupList(DbContext As AdvantageFramework.Database.DbContext, ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim MediaTrafficRevisionIDs As IEnumerable(Of Integer) = Nothing

            MediaTrafficRevisionIDs = MediaTrafficViewModel.Revisions.Select(Function(R) R.ID).Distinct.ToArray

            MediaTrafficViewModel.RepositoryMediaTrafficCreativeGroupList = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionIDs(DbContext, MediaTrafficRevisionIDs).ToList
                                                                             Select New AdvantageFramework.DTO.Media.Traffic.CreativeGroup(Entity)).ToList

        End Sub
        Public Function Load(MediaBroadcastWorksheetMarketID As Integer) As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel

            'objects
            Dim MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing
            Dim MediaBroadcastWorksheetMarketTraffic As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketTraffic = Nothing
            Dim VendorCodes As Generic.List(Of String) = Nothing

            MediaTrafficViewModel = New AdvantageFramework.ViewModels.Media.MediaTrafficViewModel()
            MediaTrafficViewModel.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaTrafficViewModel.DoesUserHaveAccessToAdNumberMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.Session, AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_AdNumber)

                MediaTrafficViewModel.IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)
                MediaTrafficViewModel.AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaTrafficViewModel.MediaBroadcastWorksheetMarketID)

                If MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.Count > 0 Then

                    MediaTrafficViewModel.DefaultLength = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails.First.Length

                End If

                If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing Then

                    MediaTrafficViewModel.MediaBroadcastWorksheetID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ID
                    MediaTrafficViewModel.MediaBroadcastWorksheetName = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Name

                    MediaTrafficViewModel.MediaBroadcastWorksheetStartDate = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.StartDate
                    MediaTrafficViewModel.MediaBroadcastWorksheetEndDate = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.EndDate
                    MediaTrafficViewModel.ClientCode = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ClientCode
                    MediaTrafficViewModel.MediaType = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode

                    If MediaTrafficViewModel.MediaType = "T" Then

                        MediaTrafficViewModel.RepositoryDaypartList = (From DP In AdvantageFramework.Database.Procedures.Daypart.LoadByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList
                                                                       Select New AdvantageFramework.DTO.Daypart(DP)).OrderBy(Function(Entity) Entity.Code).ToList

                    ElseIf MediaTrafficViewModel.MediaType = "R" Then

                        MediaTrafficViewModel.RepositoryDaypartList = (From DP In AdvantageFramework.Database.Procedures.Daypart.LoadByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList
                                                                       Select New AdvantageFramework.DTO.Daypart(DP)).OrderBy(Function(Entity) Entity.Code).ToList

                    End If

                    MediaTrafficViewModel.RepositoryAdNumberList = (From Ad In AdvantageFramework.Database.Procedures.Ad.LoadByClientCode(DbContext, MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.ClientCode).ToList
                                                                    Select New AdvantageFramework.DTO.AdNumber(Ad)).ToList

                    VendorCodes = New Generic.List(Of String)

                    For Each MediaBroadcastWorksheetMarketDetail In MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketDetails

                        If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketDetailDates.Any(Function(DD) DD.OrderNumber.HasValue) Then

                            If VendorCodes.Contains(MediaBroadcastWorksheetMarketDetail.VendorCode) = False Then

                                VendorCodes.Add(MediaBroadcastWorksheetMarketDetail.VendorCode)

                            End If

                        End If

                    Next

                    MediaTrafficViewModel.WorksheetMarketVendors = (From Entity In AdvantageFramework.Database.Procedures.Vendor.Load(DbContext)
                                                                    Where VendorCodes.Contains(Entity.Code)
                                                                    Select Entity).ToList

                    StandardComment = (From Entity In AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Media Traffic")
                                       Where Entity.OfficeCode = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Product.OfficeCode AndAlso
                                             Entity.MediaType = MediaTrafficViewModel.MediaType
                                       Select Entity).FirstOrDefault

                    If StandardComment Is Nothing Then

                        StandardComment = (From Entity In AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Media Traffic")
                                           Where Entity.OfficeCode = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.Product.OfficeCode
                                           Select Entity).FirstOrDefault

                        If StandardComment Is Nothing Then

                            StandardComment = (From Entity In AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Media Traffic")
                                               Where Entity.MediaType = MediaTrafficViewModel.MediaType
                                               Select Entity).FirstOrDefault

                            If StandardComment Is Nothing Then

                                StandardComment = (From Entity In AdvantageFramework.Database.Procedures.StandardComment.LoadByApplicationCode(DbContext, "Media Traffic")
                                                   Select Entity).FirstOrDefault

                            End If

                        End If

                    End If

                    If MediaBroadcastWorksheetMarket.TrafficGuidelines Is Nothing AndAlso StandardComment IsNot Nothing Then

                        MediaBroadcastWorksheetMarket.TrafficGuidelines = StandardComment.HtmlComment
                        DbContext.TryAttach(MediaBroadcastWorksheetMarket)
                        DbContext.Entry(MediaBroadcastWorksheetMarket).State = Entity.EntityState.Modified
                        DbContext.SaveChanges()

                        MediaTrafficViewModel.TrafficGuidelines = StandardComment.HtmlComment

                    Else

                        MediaTrafficViewModel.TrafficGuidelines = MediaBroadcastWorksheetMarket.TrafficGuidelines

                    End If

                    LoadPrintSettings(MediaTrafficViewModel, DbContext)

                End If

            End Using

            Load = MediaTrafficViewModel

        End Function
        Private Sub LoadPrintSettings(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, DbContext As AdvantageFramework.Database.DbContext)

            Dim MediaTrafficPrintSetting As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting = Nothing

            MediaTrafficPrintSetting = AdvantageFramework.Database.Procedures.MediaTrafficPrintSetting.LoadByUserCodeAndMediaType(DbContext, Me.Session.UserCode, MediaTrafficViewModel.MediaType)

            If MediaTrafficPrintSetting IsNot Nothing Then

                MediaTrafficViewModel.IncludeGuidelines = MediaTrafficPrintSetting.IncludeGuidelines

                If String.IsNullOrWhiteSpace(MediaTrafficPrintSetting.LocationID) = False Then

                    Using DataContext As New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        MediaTrafficViewModel.Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, MediaTrafficPrintSetting.LocationID)

                    End Using

                End If

            End If

        End Sub
        Public Sub RefreshLocation(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                LoadPrintSettings(MediaTrafficViewModel, DbContext)

            End Using

        End Sub
        Public Sub AddBookend(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim BookendSeqNumber As Short = 0
            Dim Percent As Integer = 0
            Dim FindBookendSequenceNumber As Short = 0
            Dim SumRotation As Integer = 0

            If MediaTrafficViewModel.Details.Where(Function(Entity) Entity.IsBookend).Any Then

                BookendSeqNumber = (From Entity In MediaTrafficViewModel.Details
                                    Where Entity.IsBookend
                                    Select Entity.BookendSequenceNumber).Max + 1

            Else

                BookendSeqNumber = 1

            End If

            Percent = 100 / BookendSeqNumber

            MediaTrafficViewModel.Details.Add(GetNewBookendDetail(MediaTrafficViewModel.SelectedRevision.ID, BookendSeqNumber, 1, MediaTrafficViewModel.DefaultLength))
            MediaTrafficViewModel.Details.Add(GetNewBookendDetail(MediaTrafficViewModel.SelectedRevision.ID, BookendSeqNumber, 2, MediaTrafficViewModel.DefaultLength))

            For i As Short = 1 To BookendSeqNumber

                FindBookendSequenceNumber = i

                For Each Detail In MediaTrafficViewModel.Details.Where(Function(D) D.BookendSequenceNumber = FindBookendSequenceNumber)

                    Detail.Rotation = Percent

                Next

                If i > 2 AndAlso i = BookendSeqNumber Then

                    SumRotation = MediaTrafficViewModel.Details.Where(Function(D) D.Position.HasValue AndAlso D.Position = 1 AndAlso D.BookendSequenceNumber <> BookendSeqNumber).Sum(Function(D) D.Rotation.GetValueOrDefault(0))

                    For Each Detail In MediaTrafficViewModel.Details.Where(Function(D) D.BookendSequenceNumber = BookendSeqNumber)

                        Detail.Rotation = 100 - SumRotation

                    Next

                End If

            Next

        End Sub
        Public Function HasTrafficInstructionBeenGenerated(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel) As Boolean

            Dim Generated As Boolean = False
            Dim MediaTrafficVendorIDs As IEnumerable(Of Integer) = Nothing

            If MediaTrafficViewModel.SelectedRevision IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaTrafficVendorIDs = AdvantageFramework.Database.Procedures.MediaTrafficVendor.LoadByMediaTrafficRevisionIDs(DbContext, {MediaTrafficViewModel.SelectedRevision.ID}).Select(Function(MTV) MTV.ID).ToArray

                    If AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorIDs(DbContext, MediaTrafficVendorIDs).Where(Function(MTVS) MTVS.MediaTrafficStatusID = AdvantageFramework.Database.Entities.Methods.MediaTrafficStatusID.Generated).Any Then

                        Generated = True

                    End If

                End Using

            End If

            HasTrafficInstructionBeenGenerated = Generated

        End Function
        Public Function DeleteTraffic(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByRef ErrorText As String) As Boolean

            Dim Deleted As Boolean = True

            If MediaTrafficViewModel.SelectedRevision IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Deleted = AdvantageFramework.Database.Procedures.MediaTrafficRevision.DeleteByID(DbContext, MediaTrafficViewModel.SelectedRevision.ID, ErrorText)

                    If Deleted Then

                        MediaTrafficViewModel.Revisions.Remove(MediaTrafficViewModel.SelectedRevision)

                        If MediaTrafficViewModel.SelectedRevision.RevisionNumber = 0 Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_TRAFFIC WHERE MEDIA_TRAFFIC_ID = {0}", MediaTrafficViewModel.SelectedRevision.MediaTrafficID))

                            DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.MEDIA_TRAFFIC WHERE MEDIA_TRAFFIC_ID = {0}", MediaTrafficViewModel.SelectedRevision.MediaTrafficID))

                        End If

                        MediaTrafficViewModel.SelectedRevision = Nothing
                        MediaTrafficViewModel.SelectedCreativeGroup = Nothing
                        MediaTrafficViewModel.SelectedDetails = Nothing

                    End If

                End Using

            End If

            DeleteTraffic = Deleted

        End Function
        'Public Function HasCreativeGroupBeenAccepted(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel) As Boolean

        '    Dim Accepted As Boolean = False

        '    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        If AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.HasAnyVendorAcceptedInstructionForCreativeGroupID(DbContext, MediaTrafficViewModel.SelectedCreativeGroup.ID) Then

        '            Accepted = True

        '        End If

        '    End Using

        '    HasCreativeGroupBeenAccepted = Accepted

        'End Function
        Public Function DeleteCreativeGroup(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByRef ErrorText As String) As Boolean

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DeleteCreativeGroup = AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.DeleteByID(DbContext, MediaTrafficViewModel.SelectedCreativeGroup.ID, ErrorText)

                If DeleteCreativeGroup Then

                    MediaTrafficViewModel.CreativeGroups.Remove(MediaTrafficViewModel.SelectedCreativeGroup)

                    MediaTrafficViewModel.SelectedCreativeGroup = Nothing

                    MediaTrafficViewModel.SelectedRevision.CreativeGroupCount -= 1

                    LoadRepositoryMediaTrafficCreativeGroupList(DbContext, MediaTrafficViewModel)

                End If

            End Using

        End Function
        Public Function DeleteDetail(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel) As Boolean

            Dim Deleted As Boolean = False
            Dim SelectedBookendSequenceNumbersToRemove As Generic.List(Of Short) = Nothing
            Dim SelectedBookendSequenceNumbersToFlagDeleted As Generic.List(Of Short) = Nothing
            Dim TempDetails As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SelectedBookendSequenceNumbersToRemove = MediaTrafficViewModel.SelectedDetails.Where(Function(D) D.ID = 0 AndAlso D.BookendSequenceNumber > 0).Select(Function(D) D.BookendSequenceNumber).Distinct.ToList
                SelectedBookendSequenceNumbersToFlagDeleted = MediaTrafficViewModel.SelectedDetails.Where(Function(D) D.ID > 0 AndAlso D.BookendSequenceNumber > 0).Select(Function(D) D.BookendSequenceNumber).Distinct.ToList

                For Each Detail In MediaTrafficViewModel.SelectedDetails.Where(Function(D) D.BookendSequenceNumber = 0)

                    If Detail.ID = 0 Then

                        If MediaTrafficViewModel.Details.Contains(Detail) Then

                            MediaTrafficViewModel.Details.Remove(Detail)

                        End If

                    Else

                        Detail.IsDeleted = Not Detail.IsDeleted

                    End If

                Next

                For Each Detail In MediaTrafficViewModel.Details.Where(Function(D) SelectedBookendSequenceNumbersToFlagDeleted.Contains(D.BookendSequenceNumber))

                    Detail.IsDeleted = Not Detail.IsDeleted

                Next

                TempDetails = MediaTrafficViewModel.Details.ToList

                For Each Detail In TempDetails.Where(Function(D) D.BookendSequenceNumber <> 0)

                    If SelectedBookendSequenceNumbersToRemove.Contains(Detail.BookendSequenceNumber) Then

                        MediaTrafficViewModel.Details.Remove(Detail)

                    End If

                Next

                ValidateDetailRotation(MediaTrafficViewModel)

                Deleted = True

            End Using

            DeleteDetail = Deleted

        End Function
        Public Function HasVendorInstructionBeenGenerated(MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByRef Message As String) As Boolean

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                HasVendorInstructionBeenGenerated = AdvantageFramework.Database.Procedures.MediaTrafficVendor.HasInstructionBeenGenerated(DbContext, MediaTrafficViewModel.SelectedVendor.ID, Message)

            End Using

        End Function
        Public Function DeleteVendor(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByRef ErrorText As String) As Boolean

            Dim Deleted As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.MediaTrafficVendor.DeleteByID(DbContext, MediaTrafficViewModel.SelectedVendor.ID, ErrorText) Then

                    Deleted = True

                    MediaTrafficViewModel.Vendors.Remove(MediaTrafficViewModel.SelectedVendor)

                    MediaTrafficViewModel.SelectedVendor = Nothing

                End If

            End Using

            DeleteVendor = Deleted

        End Function
        Public Function DeleteVendorCreativeGroup(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ID As Integer, ByRef ErrorText As String) As Boolean

            Dim Deleted As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.DeleteByID(DbContext, ID, ErrorText) Then

                    Deleted = True

                End If

            End Using

            DeleteVendorCreativeGroup = Deleted

        End Function
        Public Function AddToMediaBroadcastWorksheetMarket(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel,
                                                           Revision As AdvantageFramework.DTO.Media.Traffic.Revision,
                                                           ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaTrafficID As Integer = 0
            Dim MediaBroadcastWorksheetMarketTraffic As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketTraffic = Nothing
            Dim Added As Boolean = False
            Dim Vendors As Generic.List(Of AdvantageFramework.DTO.Vendor) = Nothing
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    If AddMediaTraffic(DbContext, Revision, MediaTrafficID, ErrorMessage) Then

                        MediaBroadcastWorksheetMarketTraffic = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketTraffic
                        MediaBroadcastWorksheetMarketTraffic.MediaBroadcastWorksheetMarketID = MediaTrafficViewModel.MediaBroadcastWorksheetMarketID
                        MediaBroadcastWorksheetMarketTraffic.MediaTrafficID = MediaTrafficID

                        Added = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketTraffic.Insert(DbContext, MediaBroadcastWorksheetMarketTraffic, ErrorMessage)

                    End If

                Catch ex As Exception
                    ErrorMessage = ex.Message
                End Try

            End Using

            AddToMediaBroadcastWorksheetMarket = Added

        End Function
        Public Function AddCreativeGroup(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel,
                                         CreativeGroup As AdvantageFramework.DTO.Media.Traffic.CreativeGroup,
                                         ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTrafficCreativeGroup = New AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup
                MediaTrafficCreativeGroup.MediaTrafficRevisionID = MediaTrafficViewModel.SelectedRevision.ID
                MediaTrafficCreativeGroup.Name = CreativeGroup.Name.Trim

                Added = AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.Insert(DbContext, MediaTrafficCreativeGroup, ErrorMessage)

                If Added Then

                    CreativeGroup.ID = MediaTrafficCreativeGroup.ID

                    MediaTrafficViewModel.SelectedRevision.CreativeGroupCount += 1

                    LoadRepositoryMediaTrafficCreativeGroupList(DbContext, MediaTrafficViewModel)

                End If

            End Using

            AddCreativeGroup = Added

        End Function
        Public Function AddVendor(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel,
                                  Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor,
                                  ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            Dim CableNetworkStationCodes As IEnumerable(Of String) = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTrafficVendor = New AdvantageFramework.Database.Entities.MediaTrafficVendor
                MediaTrafficVendor.DbContext = DbContext

                Vendor.SaveToEntity(MediaTrafficVendor)

                CableNetworkStationCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaTrafficViewModel.MediaBroadcastWorksheetMarketID)
                                            Where Entity.VendorCode = MediaTrafficVendor.VendorCode
                                            Select Entity.CableNetworkStationCode).ToArray

                Added = AdvantageFramework.Database.Procedures.MediaTrafficVendor.Insert(DbContext, MediaTrafficVendor, ErrorMessage)

            End Using

            AddVendor = Added

        End Function
        Public Function AddVendorCreativeGroup(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel,
                                               VendorCreativeGroup As AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup,
                                               ByRef ErrorMessage As String) As Boolean

            'objects
            Dim MediaTrafficVendorCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup = Nothing
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTrafficVendorCreativeGroup = New AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup
                MediaTrafficVendorCreativeGroup.DbContext = DbContext

                VendorCreativeGroup.SaveToEntity(MediaTrafficVendorCreativeGroup)

                If AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.Insert(DbContext, MediaTrafficVendorCreativeGroup, ErrorMessage) Then

                    Added = True

                    VendorCreativeGroup.ID = MediaTrafficVendorCreativeGroup.ID

                End If

            End Using

            AddVendorCreativeGroup = Added

        End Function
        Public Function SaveMediaBroadcastWorksheetMarketTrafficGuidelines(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel) As Boolean

            'objects
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim Saved As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaTrafficViewModel.MediaBroadcastWorksheetMarketID)

                If MediaBroadcastWorksheetMarket IsNot Nothing Then

                    MediaBroadcastWorksheetMarket.TrafficGuidelines = MediaTrafficViewModel.TrafficGuidelines

                    DbContext.TryAttach(MediaBroadcastWorksheetMarket)
                    DbContext.Entry(MediaBroadcastWorksheetMarket).State = Entity.EntityState.Modified

                    If DbContext.SaveChanges() = 1 Then

                        Saved = True

                    End If

                End If

            End Using

            SaveMediaBroadcastWorksheetMarketTrafficGuidelines = Saved

        End Function
        Public Sub SaveDetails(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim MediaTrafficDetail As AdvantageFramework.Database.Entities.MediaTrafficDetail = Nothing
            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Detail In MediaTrafficViewModel.Details.Where(Function(D) D.IsDeleted = True)

                    AdvantageFramework.Database.Procedures.MediaTrafficDetail.DeleteByID(DbContext, Detail.ID, ErrorText)

                Next

                For Each Detail In MediaTrafficViewModel.Details.Where(Function(D) D.Modified = True AndAlso D.IsDeleted = False)

                    If Detail.ID = 0 Then

                        MediaTrafficDetail = New AdvantageFramework.Database.Entities.MediaTrafficDetail
                        MediaTrafficDetail.MediaTrafficCreativeGroupID = MediaTrafficViewModel.SelectedCreativeGroup.ID

                        Detail.SaveToEntity(MediaTrafficDetail)

                        AdvantageFramework.Database.Procedures.MediaTrafficDetail.Insert(DbContext, MediaTrafficDetail, ErrorText)

                    Else

                        MediaTrafficDetail = AdvantageFramework.Database.Procedures.MediaTrafficDetail.LoadByID(DbContext, Detail.ID)

                        If MediaTrafficDetail IsNot Nothing Then

                            Detail.SaveToEntity(MediaTrafficDetail)

                            DbContext.Entry(MediaTrafficDetail).State = Entity.EntityState.Modified

                        End If

                    End If

                Next

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Sub SaveTraffic(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision = Nothing
            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each Revision In MediaTrafficViewModel.Revisions.Where(Function(R) R.Modified = True)

                    MediaTrafficRevision = AdvantageFramework.Database.Procedures.MediaTrafficRevision.LoadByID(DbContext, Revision.ID)

                    If MediaTrafficRevision IsNot Nothing Then

                        MediaTrafficRevision.ModifiedByUserCode = Session.UserCode
                        MediaTrafficRevision.ModifiedDate = Now

                        Revision.SaveToEntity(MediaTrafficRevision)

                        DbContext.Entry(MediaTrafficRevision).State = Entity.EntityState.Modified

                    End If

                Next

                DbContext.SaveChanges()

                LoadRevisions(DbContext, MediaTrafficViewModel)

            End Using

        End Sub
        Public Sub SaveCreativeGroups(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup = Nothing
            Dim ErrorText As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each CreativeGroup In MediaTrafficViewModel.CreativeGroups.Where(Function(R) R.Modified = True)

                    MediaTrafficCreativeGroup = AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByID(DbContext, CreativeGroup.ID)

                    If MediaTrafficCreativeGroup IsNot Nothing Then

                        CreativeGroup.SaveToEntity(MediaTrafficCreativeGroup)

                        DbContext.Entry(MediaTrafficCreativeGroup).State = Entity.EntityState.Modified

                    End If

                Next

                DbContext.SaveChanges()

                LoadMediaTrafficCreativeGroups(MediaTrafficViewModel)

            End Using

        End Sub
        Public Sub SetCreativeGroupModified(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByVal CreativeGroup As AdvantageFramework.DTO.Media.Traffic.CreativeGroup)

            MediaTrafficViewModel.CreativeGroups.Where(Function(CG) CG.ID = CreativeGroup.ID).FirstOrDefault.Modified = True

        End Sub
        Public Sub SetDetailModified(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByVal Detail As AdvantageFramework.DTO.Media.Traffic.Detail)

            MediaTrafficViewModel.Details.Where(Function(Dtl) Dtl.Guid = Detail.Guid).FirstOrDefault.Modified = True

            ValidateDetailRotation(MediaTrafficViewModel)

        End Sub
        Public Sub SetRevisionModified(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByVal Revision As AdvantageFramework.DTO.Media.Traffic.Revision)

            MediaTrafficViewModel.Revisions.Where(Function(Rev) Rev.ID = Revision.ID).FirstOrDefault.Modified = True

        End Sub
        Public Sub SetSelectedRevision(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, Revision As AdvantageFramework.DTO.Media.Traffic.Revision)

            Dim MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup = Nothing

            MediaTrafficViewModel.SelectedRevisionRevisionNumbers.Clear()

            MediaTrafficViewModel.SelectedRevision = Revision

            If Revision IsNot Nothing Then

                For RevisionNumber As Integer = 0 To Revision.MaxRevisionNumber

                    MediaTrafficViewModel.SelectedRevisionRevisionNumbers.Add(RevisionNumber)

                Next

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    MediaTrafficCreativeGroup = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, Revision.ID)
                                                 Select Entity).FirstOrDefault

                    If MediaTrafficCreativeGroup IsNot Nothing Then

                        MediaTrafficViewModel.SelectedCreativeGroup = New DTO.Media.Traffic.CreativeGroup(MediaTrafficCreativeGroup)

                    End If

                End Using

            End If

        End Sub
        Public Sub SetSelectedCreativeGroup(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, CreativeGroup As AdvantageFramework.DTO.Media.Traffic.CreativeGroup)

            MediaTrafficViewModel.SelectedCreativeGroup = CreativeGroup

        End Sub
        Public Sub SetSelectedDetail(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, Details As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Detail))

            MediaTrafficViewModel.SelectedDetails = Details

        End Sub
        Public Sub SetSelectedVendor(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor)

            MediaTrafficViewModel.SelectedVendor = Vendor

        End Sub
        Public Sub UpdateAdNumber(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, Detail As AdvantageFramework.DTO.Media.Traffic.Detail, AdNumber As String)

            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            For Each Detail In MediaTrafficViewModel.Details.Where(Function(Dtl) Dtl.Guid = Detail.Guid)

                If String.IsNullOrWhiteSpace(AdNumber) Then

                    Detail.AdNumber = Nothing
                    Detail.AdNumberDocument = False

                Else

                    Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Ad = DbContext.Ads.Find(AdNumber)

                        If Ad IsNot Nothing Then

                            If String.IsNullOrWhiteSpace(Ad.Description) = False Then

                                Detail.CreativeTitle = Ad.Description

                            End If

                            If Ad.DocumentID.HasValue Then

                                Detail.AdNumberDocument = True

                            End If

                            If Ad.Length.HasValue Then

                                Detail.Length = Ad.Length.Value

                            End If

                        End If

                    End Using

                End If

                Detail.Modified = True

            Next

            ValidateDetailRotation(MediaTrafficViewModel)

        End Sub
        Public Sub UpdateBookends(ByVal MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, Detail As AdvantageFramework.DTO.Media.Traffic.Detail, BookendName As String)

            For Each Detail In MediaTrafficViewModel.Details.Where(Function(Dtl) Dtl.BookendSequenceNumber = Detail.BookendSequenceNumber)

                Detail.BookendName = BookendName
                Detail.Modified = True

            Next

        End Sub
        Public Sub UpdateVendorCreativeGroup(VendorCreativeGroup As AdvantageFramework.DTO.Media.Traffic.VendorCreativeGroup)

            Dim MediaTrafficVendorCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaTrafficVendorCreativeGroup = DbContext.MediaTrafficVendorCreativeGroups.Find(VendorCreativeGroup.ID)

                If MediaTrafficVendorCreativeGroup IsNot Nothing Then

                    VendorCreativeGroup.SaveToEntity(MediaTrafficVendorCreativeGroup)

                    DbContext.Entry(MediaTrafficVendorCreativeGroup).State = Entity.EntityState.Modified
                    DbContext.SaveChanges()

                End If

            End Using

        End Sub
        Public Function ValidateProperty(DTO As AdvantageFramework.DTO.BaseClass, MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(DTO.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    ErrorText = Me.ValidateDTOProperty(DbContext, DataContext, DTO, PropertyDescriptor, IsValid, Value)

                    If DTO.GetType.Equals(GetType(AdvantageFramework.DTO.Media.Traffic.Revision)) Then

                        If FieldName = AdvantageFramework.DTO.Media.Traffic.Revision.Properties.StartDate.ToString Then

                            If Value IsNot Nothing AndAlso IsDate(Value) AndAlso Value < MediaTrafficViewModel.MediaBroadcastWorksheetStartDate Then

                                IsValid = False
                                ErrorText = "Start Date must be on or after the broadcast worksheet start date of " & MediaTrafficViewModel.MediaBroadcastWorksheetStartDate.ToString("MM/dd/yyyy") & "."

                            End If

                        ElseIf FieldName = AdvantageFramework.DTO.Media.Traffic.Revision.Properties.EndDate.ToString Then

                            If Value IsNot Nothing AndAlso IsDate(Value) AndAlso Value < MediaTrafficViewModel.MediaBroadcastWorksheetStartDate Then

                                IsValid = False
                                ErrorText = "End Date must be on or before the broadcast worksheet end date of " & MediaTrafficViewModel.MediaBroadcastWorksheetEndDate.ToString("MM/dd/yyyy") & "."

                            End If

                        End If

                    End If

                End Using

            End Using

            ValidateProperty = ErrorText

        End Function
        Public Function ValidateDetailEntity(Detail As AdvantageFramework.DTO.Media.Traffic.Detail, MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ErrorText = ValidateDTO(DbContext, DataContext, Detail, IsValid)

                    ValidateDetailRotation(MediaTrafficViewModel)

                    If MediaTrafficViewModel.Details.Where(Function(D) D.Guid = Detail.Guid).Count = 1 Then

                        ErrorText = MediaTrafficViewModel.Details.Where(Function(D) D.Guid = Detail.Guid).Single.Error

                    End If

                End Using

            End Using

            ValidateDetailEntity = ErrorText

        End Function
        Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
                                                           ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = String.Empty
            Dim PropertyValue As Object = Nothing
            Dim Detail As AdvantageFramework.DTO.Media.Traffic.Detail = Nothing
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim Revision As AdvantageFramework.DTO.Media.Traffic.Revision = Nothing
            Dim Ad As AdvantageFramework.Database.Entities.Ad = Nothing

            If DTO.GetType Is GetType(AdvantageFramework.DTO.Media.Traffic.Detail) Then

                Detail = DTO

                PropertyValue = Value

                If PropertyName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.StartTime.ToString Then

                    DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

                    DaysAndTime = New AdvantageFramework.DTO.DaysAndTime()

                    DaysAndTime.StartTime = PropertyValue
                    DaysAndTime.EndTime = Detail.EndTime

                    DaysAndTimeController.ParseTime(DaysAndTime, True, Value, IsValid)

                    If IsValid = False Then

                        ErrorText = "Invalid Time Entry"

                    End If

                ElseIf PropertyName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.EndTime.ToString Then

                    DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

                    DaysAndTime = New AdvantageFramework.DTO.DaysAndTime()

                    DaysAndTime.StartTime = Detail.StartTime
                    DaysAndTime.EndTime = PropertyValue

                    DaysAndTimeController.ParseTime(DaysAndTime, False, Value, IsValid)

                    If IsValid = False Then

                        ErrorText = "Invalid Time Entry"

                    End If

                ElseIf PropertyName = AdvantageFramework.DTO.Media.Traffic.Detail.Properties.AdNumber.ToString Then

                    If String.IsNullOrWhiteSpace(PropertyValue) = False Then

                        Ad = AdvantageFramework.Database.Procedures.Ad.LoadByAdNumber(DbContext, DirectCast(PropertyValue, String))

                        If Ad.ExpirationDate.HasValue AndAlso Ad.ExpirationDate.Value < Now Then

                            IsValid = False
                            ErrorText = "Ad number is expired."

                        End If

                    End If

                End If

            ElseIf DTO.GetType Is GetType(AdvantageFramework.DTO.Media.Traffic.Revision) Then

                Revision = DTO

                PropertyValue = Value

                Select Case PropertyName

                    Case AdvantageFramework.DTO.Media.Traffic.Revision.Properties.StartDate.ToString

                        If PropertyValue IsNot Nothing AndAlso IsDate(PropertyValue) Then

                            If Revision.BroadcastWorksheetStartDate > PropertyValue Then

                                IsValid = False
                                ErrorText = "Start Date must be on or after the broadcast worksheet start date of " & Revision.BroadcastWorksheetStartDate.ToString("MM/dd/yyyy") & "."

                            End If

                        End If

                    Case AdvantageFramework.DTO.Media.Traffic.Revision.Properties.EndDate.ToString

                        If PropertyValue IsNot Nothing AndAlso IsDate(PropertyValue) Then

                            If Revision.BroadcastWorksheetEndDate < PropertyValue Then

                                IsValid = False
                                ErrorText = "End Date must be on or before the broadcast worksheet end date " & Revision.BroadcastWorksheetEndDate.ToString("MM/dd/yyyy") & "."

                            End If

                        End If

                End Select

            End If

            ValidateCustomProperties = ErrorText

        End Function
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
        Public Sub AddAllVendorsToMediaTrafficRevision(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, Revision As AdvantageFramework.DTO.Media.Traffic.Revision)

            Dim Vendor As AdvantageFramework.DTO.Media.Traffic.Vendor = Nothing

            For Each WorksheetMarketVendor In MediaTrafficViewModel.WorksheetMarketVendors

                If MediaTrafficViewModel.Vendors.Where(Function(V) V.VendorCode = WorksheetMarketVendor.Code AndAlso V.MediaTrafficRevisionID = Revision.ID).Any = False Then

                    Vendor = New DTO.Media.Traffic.Vendor
                    Vendor.MediaTrafficRevisionID = Revision.ID
                    Vendor.VendorCode = WorksheetMarketVendor.Code

                    AddVendor(MediaTrafficViewModel, Vendor, Nothing)

                End If

            Next

        End Sub
        Public Function RemoveGeneratedVendors(Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)) As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)

            Dim UngeneratedVendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor) = Nothing

            UngeneratedVendors = New Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Vendor In Vendors

                    If (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, Vendor.ID)
                        Where Entity.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Generated).Any = False Then

                        UngeneratedVendors.Add(Vendor)

                    End If

                Next

            End Using

            RemoveGeneratedVendors = UngeneratedVendors

        End Function
        Public Sub DeleteVendors(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor))

            Dim Deleted As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Vendor In Vendors

                    If (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, Vendor.ID)
                        Where Entity.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Generated).Any = False Then

                        AdvantageFramework.Database.Procedures.MediaTrafficVendor.DeleteByID(DbContext, Vendor.ID, Nothing)

                    End If

                Next

                LoadMediaTrafficVendors(DbContext, MediaTrafficViewModel)

            End Using

        End Sub
        Public Sub CreateRevision(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            'objects
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision = Nothing
            Dim ErrorText As String = Nothing
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            Dim MediaTrafficVendorList As Generic.List(Of AdvantageFramework.Database.Entities.MediaTrafficVendor) = Nothing
            Dim MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup = Nothing
            Dim MediaTrafficVendorCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup = Nothing
            Dim VendorCode As String = Nothing
            Dim MediaTrafficDetail As AdvantageFramework.Database.Entities.MediaTrafficDetail = Nothing
            Dim MediaTrafficDetailDocument As AdvantageFramework.Database.Entities.MediaTrafficDetailDocument = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    DbContext.Database.Connection.Open()

                    DbTransaction = DbContext.Database.BeginTransaction

                    MediaTrafficRevision = New AdvantageFramework.Database.Entities.MediaTrafficRevision
                    MediaTrafficRevision.DbContext = DbContext

                    MediaTrafficRevision.MediaTrafficID = MediaTrafficViewModel.SelectedRevision.MediaTrafficID
                    MediaTrafficRevision.StartDate = MediaTrafficViewModel.SelectedRevision.StartDate
                    MediaTrafficRevision.EndDate = MediaTrafficViewModel.SelectedRevision.EndDate
                    MediaTrafficRevision.Description = MediaTrafficViewModel.SelectedRevision.Description
                    MediaTrafficRevision.CreatedByUserCode = Session.UserCode
                    MediaTrafficRevision.CreatedDate = Now

                    If AdvantageFramework.Database.Procedures.MediaTrafficRevision.Insert(DbContext, MediaTrafficRevision, ErrorText) = False Then

                        Throw New Exception("Failed to insert media traffic revision: " & ErrorText)

                    End If

                    MediaTrafficVendorList = AdvantageFramework.Database.Procedures.MediaTrafficVendor.LoadByMediaTrafficRevisionIDs(DbContext, {MediaTrafficViewModel.SelectedRevision.ID}).ToList

                    If MediaTrafficVendorList.Count = 0 Then

                        For Each MTCG In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficViewModel.SelectedRevision.ID).ToList

                            MediaTrafficCreativeGroup = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficRevision.ID)
                                                         Where Entity.Name = MTCG.Name
                                                         Select Entity).SingleOrDefault

                            If MediaTrafficCreativeGroup Is Nothing Then

                                MediaTrafficCreativeGroup = New AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup
                                MediaTrafficCreativeGroup.DbContext = DbContext
                                MediaTrafficCreativeGroup.MediaTrafficRevisionID = MediaTrafficRevision.ID
                                MediaTrafficCreativeGroup.Name = MTCG.Name
                                MediaTrafficCreativeGroup.IsDefault = MTCG.IsDefault

                                If AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.Insert(DbContext, MediaTrafficCreativeGroup, ErrorText) = False Then

                                    Throw New Exception("Failed to insert media traffic creative group: " & ErrorText)

                                End If

                                For Each MTD In AdvantageFramework.Database.Procedures.MediaTrafficDetail.LoadByMediaTrafficCreativeGroupID(DbContext, MTCG.ID).ToList

                                    MediaTrafficDetail = New AdvantageFramework.Database.Entities.MediaTrafficDetail
                                    MediaTrafficDetail.DbContext = DbContext
                                    MediaTrafficDetail.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroup.ID
                                    MediaTrafficDetail.DayPartID = MTD.DayPartID
                                    MediaTrafficDetail.Length = MTD.Length
                                    MediaTrafficDetail.StartTime = MTD.StartTime
                                    MediaTrafficDetail.EndTime = MTD.EndTime
                                    MediaTrafficDetail.AdNumber = MTD.AdNumber
                                    MediaTrafficDetail.CreativeTitle = MTD.CreativeTitle
                                    MediaTrafficDetail.Location = MTD.Location
                                    MediaTrafficDetail.IsBookend = MTD.IsBookend
                                    MediaTrafficDetail.BookendName = MTD.BookendName
                                    MediaTrafficDetail.BookendSequenceNumber = MTD.BookendSequenceNumber
                                    MediaTrafficDetail.Position = MTD.Position
                                    MediaTrafficDetail.Rotation = MTD.Rotation
                                    MediaTrafficDetail.Comment = MTD.Comment

                                    If AdvantageFramework.Database.Procedures.MediaTrafficDetail.Insert(DbContext, MediaTrafficDetail, ErrorText) = False Then

                                        Throw New Exception("Failed to insert media traffic detail: " & ErrorText)

                                    End If

                                    For Each MTDD In MTD.MediaTrafficDetailDocuments

                                        MediaTrafficDetailDocument = New AdvantageFramework.Database.Entities.MediaTrafficDetailDocument
                                        MediaTrafficDetailDocument.DbContext = DbContext
                                        MediaTrafficDetailDocument.MediaTrafficDetailID = MediaTrafficDetail.ID
                                        MediaTrafficDetailDocument.DocumentID = MTDD.DocumentID

                                        If AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Insert(DbContext, MediaTrafficDetailDocument, ErrorText) = False Then

                                            Throw New Exception("Failed to insert media traffic detail document: " & ErrorText)

                                        End If

                                    Next

                                Next

                            End If

                        Next

                    Else

                        For Each MTV In MediaTrafficVendorList

                            MediaTrafficVendor = New AdvantageFramework.Database.Entities.MediaTrafficVendor
                            MediaTrafficVendor.DbContext = DbContext
                            MediaTrafficVendor.MediaTrafficRevisionID = MediaTrafficRevision.ID
                            MediaTrafficVendor.VendorCode = MTV.VendorCode

                            If AdvantageFramework.Database.Procedures.MediaTrafficVendor.Insert(DbContext, MediaTrafficVendor, ErrorText) = False Then

                                Throw New Exception("Failed to insert media traffic vendor: " & ErrorText)

                            End If

                            For Each MTCG In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficViewModel.SelectedRevision.ID).ToList

                                MediaTrafficCreativeGroup = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficRevision.ID)
                                                             Where Entity.Name = MTCG.Name
                                                             Select Entity).SingleOrDefault

                                If MediaTrafficCreativeGroup Is Nothing Then

                                    MediaTrafficCreativeGroup = New AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup
                                    MediaTrafficCreativeGroup.DbContext = DbContext
                                    MediaTrafficCreativeGroup.MediaTrafficRevisionID = MediaTrafficRevision.ID
                                    MediaTrafficCreativeGroup.Name = MTCG.Name
                                    MediaTrafficCreativeGroup.IsDefault = MTCG.IsDefault

                                    If AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.Insert(DbContext, MediaTrafficCreativeGroup, ErrorText) = False Then

                                        Throw New Exception("Failed to insert media traffic creative group: " & ErrorText)

                                    End If

                                    For Each MTD In AdvantageFramework.Database.Procedures.MediaTrafficDetail.LoadByMediaTrafficCreativeGroupID(DbContext, MTCG.ID).ToList

                                        MediaTrafficDetail = New AdvantageFramework.Database.Entities.MediaTrafficDetail
                                        MediaTrafficDetail.DbContext = DbContext
                                        MediaTrafficDetail.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroup.ID
                                        MediaTrafficDetail.DayPartID = MTD.DayPartID
                                        MediaTrafficDetail.Length = MTD.Length
                                        MediaTrafficDetail.StartTime = MTD.StartTime
                                        MediaTrafficDetail.EndTime = MTD.EndTime
                                        MediaTrafficDetail.AdNumber = MTD.AdNumber
                                        MediaTrafficDetail.CreativeTitle = MTD.CreativeTitle
                                        MediaTrafficDetail.Location = MTD.Location
                                        MediaTrafficDetail.IsBookend = MTD.IsBookend
                                        MediaTrafficDetail.BookendName = MTD.BookendName
                                        MediaTrafficDetail.BookendSequenceNumber = MTD.BookendSequenceNumber
                                        MediaTrafficDetail.Position = MTD.Position
                                        MediaTrafficDetail.Rotation = MTD.Rotation
                                        MediaTrafficDetail.Comment = MTD.Comment

                                        If AdvantageFramework.Database.Procedures.MediaTrafficDetail.Insert(DbContext, MediaTrafficDetail, ErrorText) = False Then

                                            Throw New Exception("Failed to insert media traffic detail: " & ErrorText)

                                        End If

                                        For Each MTDD In MTD.MediaTrafficDetailDocuments

                                            MediaTrafficDetailDocument = New AdvantageFramework.Database.Entities.MediaTrafficDetailDocument
                                            MediaTrafficDetailDocument.DbContext = DbContext
                                            MediaTrafficDetailDocument.MediaTrafficDetailID = MediaTrafficDetail.ID
                                            MediaTrafficDetailDocument.DocumentID = MTDD.DocumentID

                                            If AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Insert(DbContext, MediaTrafficDetailDocument, ErrorText) = False Then

                                                Throw New Exception("Failed to insert media traffic detail document: " & ErrorText)

                                            End If

                                        Next

                                    Next

                                End If

                                For Each MTVCG In (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.LoadByMediaTrafficCreativeGroupID(DbContext, MTCG.ID)
                                                   Where Entity.MediaTrafficVendorID = MTV.ID
                                                   Select Entity).ToList

                                    MediaTrafficVendorCreativeGroup = New AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup
                                    MediaTrafficVendorCreativeGroup.DbContext = DbContext
                                    MediaTrafficVendorCreativeGroup.MediaTrafficVendorID = MediaTrafficVendor.ID
                                    MediaTrafficVendorCreativeGroup.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroup.ID
                                    MediaTrafficVendorCreativeGroup.CableNetworkStationCodes = MTVCG.CableNetworkStationCodes

                                    If AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.Insert(DbContext, MediaTrafficVendorCreativeGroup, ErrorText) = False Then

                                        Throw New Exception("Failed to insert media traffic vendor creative group: " & ErrorText)

                                    End If

                                Next

                            Next

                        Next

                    End If

                    DbTransaction.Commit()

                    LoadRevisions(DbContext, MediaTrafficViewModel)

                Catch ex As Exception
                    DbTransaction.Rollback()
                Finally

                    If DbContext.Database.Connection.State = ConnectionState.Open Then

                        DbContext.Database.Connection.Close()

                    End If

                End Try

            End Using

        End Sub
        Public Function DeleteRevision(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel, ByRef ErrorText As String) As Boolean

            Dim MediaTrafficIDs As IEnumerable(Of Integer) = Nothing
            Dim RevisionNumber As Integer = 0
            Dim MediaTrafficRevisionIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaTrafficVendorIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision = Nothing

            RevisionNumber = MediaTrafficViewModel.SelectedRevision.RevisionNumber

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTrafficIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketTraffic.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaTrafficViewModel.MediaBroadcastWorksheetMarketID)
                                   Select Entity.MediaTrafficID).ToArray

                MediaTrafficRevisionIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficRevision.Load(DbContext)
                                           Where MediaTrafficIDs.Contains(Entity.MediaTrafficID) AndAlso
                                                 Entity.RevisionNumber = RevisionNumber
                                           Select Entity.ID).ToArray

                MediaTrafficVendorIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendor.Load(DbContext)
                                         Where MediaTrafficRevisionIDs.Contains(Entity.MediaTrafficRevisionID)
                                         Select Entity.ID).ToArray

                If (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorIDs(DbContext, MediaTrafficVendorIDs)
                    Where Entity.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Generated).Any = False Then

                    Try

                        For Each MediaTrafficRevisionID In MediaTrafficRevisionIDs

                            MediaTrafficRevision = DbContext.MediaTrafficRevisions.Find(MediaTrafficRevisionID)

                            If MediaTrafficRevision IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.MediaTrafficRevision.DeleteByID(DbContext, MediaTrafficRevisionID, ErrorText) = False Then

                                    Throw New Exception(ErrorText)

                                End If

                            End If

                        Next

                        LoadRevisions(DbContext, MediaTrafficViewModel)

                        DeleteRevision = True

                    Catch ex As Exception
                        ErrorText = ex.Message
                        DeleteRevision = False
                    End Try

                Else

                    DeleteRevision = False

                    ErrorText = "Could not delete this revision, one or more instructions have been generated by the vendor."

                End If

            End Using

        End Function
        Public Sub UpdateSelectedDetailHasDocuments(ByRef MediaTrafficViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficViewModel)

            Dim MediaTrafficDetail As AdvantageFramework.Database.Entities.MediaTrafficDetail = Nothing
            Dim Detail As AdvantageFramework.DTO.Media.Traffic.Detail = Nothing

            If MediaTrafficViewModel.SelectedDetails IsNot Nothing AndAlso MediaTrafficViewModel.SelectedDetails.Count = 1 Then

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    MediaTrafficDetail = AdvantageFramework.Database.Procedures.MediaTrafficDetail.LoadByID(DbContext, MediaTrafficViewModel.SelectedDetails(0).ID)

                    If MediaTrafficDetail IsNot Nothing Then

                        Detail = New AdvantageFramework.DTO.Media.Traffic.Detail(MediaTrafficDetail)

                        MediaTrafficViewModel.SelectedDetails(0).HasDocuments = Detail.HasDocuments

                    End If

                End Using

            End If

        End Sub
        Public Function LoadMissingInstructions(MediaBroadcastWorksheetIDs As IEnumerable(Of Integer), MediaBroadcastWorksheetMarketID As Nullable(Of Integer)) As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.MissingInstruction)

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If MediaBroadcastWorksheetMarketID.HasValue Then

                    LoadMissingInstructions = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Traffic.MissingInstruction)(String.Format("exec dbo.advsp_media_traffic_missing_instructions '{0}', {1}, NULL", String.Join(",", MediaBroadcastWorksheetIDs.ToArray), MediaBroadcastWorksheetMarketID)).ToList

                Else

                    LoadMissingInstructions = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Traffic.MissingInstruction)(String.Format("exec dbo.advsp_media_traffic_missing_instructions '{0}', NULL, NULL", String.Join(",", MediaBroadcastWorksheetIDs.ToArray))).ToList

                End If

            End Using

        End Function

#Region " Generate "

        Private Sub Generate_SetStatus(Generate As AdvantageFramework.DTO.Media.Traffic.Generate, MediaTrafficVendorStatuses As Generic.List(Of AdvantageFramework.Database.Entities.MediaTrafficVendorStatus))

            'objects
            Dim MediaTrafficVendorStatus As AdvantageFramework.Database.Entities.MediaTrafficVendorStatus = Nothing

            If MediaTrafficVendorStatuses IsNot Nothing AndAlso MediaTrafficVendorStatuses.Count > 0 Then

                MediaTrafficVendorStatus = MediaTrafficVendorStatuses.OrderByDescending(Function(S) S.CreatedDate).FirstOrDefault

                If MediaTrafficVendorStatus IsNot Nothing Then

                    Generate.TrafficStatus = MediaTrafficVendorStatus.MediaTrafficStatus.StatusDescription

                End If

                MediaTrafficVendorStatus = MediaTrafficVendorStatuses.Where(Function(Entity) Entity.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Generated).OrderByDescending(Function(S) S.CreatedDate).FirstOrDefault

                If MediaTrafficVendorStatus IsNot Nothing Then

                    Generate.LastGeneratedDate = MediaTrafficVendorStatus.CreatedDate

                End If

                MediaTrafficVendorStatus = MediaTrafficVendorStatuses.Where(Function(Entity) Entity.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Generated).OrderBy(Function(S) S.CreatedDate).FirstOrDefault

                If MediaTrafficVendorStatus IsNot Nothing Then

                    Generate.CreatedDate = MediaTrafficVendorStatus.CreatedDate

                End If

            End If

        End Sub
        Public Function Generate_Load(Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)) As AdvantageFramework.ViewModels.Media.MediaTrafficGenerateViewModel

            'objects
            Dim MediaTrafficGenerateViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficGenerateViewModel = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Generate As AdvantageFramework.DTO.Media.Traffic.Generate = Nothing
            Dim MediaTrafficVendorStatuses As Generic.List(Of AdvantageFramework.Database.Entities.MediaTrafficVendorStatus) = Nothing
            Dim VendorRepresentatives As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentative) = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

            MediaTrafficGenerateViewModel = New AdvantageFramework.ViewModels.Media.MediaTrafficGenerateViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Generate_LoadContactTypes(MediaTrafficGenerateViewModel)

                MediaTrafficGenerateViewModel.ContactTypeList = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).ToList

                Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                    For Each Vndr In Vendors

                        Vendor = DbContext.Vendors.Find(Vndr.VendorCode)

                        Generate = New AdvantageFramework.DTO.Media.Traffic.Generate

                        If Vendor IsNot Nothing Then

                            Generate.DefaultCorrespondenceMethod = Vendor.DefaultCorrespondenceMethod.GetValueOrDefault(1)

                        Else

                            Generate.DefaultCorrespondenceMethod = 1

                        End If

                        If MediaTrafficGenerateViewModel.ContactTypeIDs.Count > 0 Then

                            VendorRepresentatives = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Vndr.VendorCode)
                                                     Where Entity.EmailAddress IsNot Nothing AndAlso
                                                           Entity.EmailAddress <> "" AndAlso
                                                           MediaTrafficGenerateViewModel.ContactTypeIDs.Contains(Entity.ContactTypeID.GetValueOrDefault(0))).ToList

                        Else

                            VendorRepresentatives = (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Vndr.VendorCode)
                                                     Where Entity.EmailAddress IsNot Nothing AndAlso
                                                           Entity.EmailAddress <> "").ToList

                        End If

                        MediaTrafficVendorStatuses = AdvantageFramework.Database.Procedures.MediaTrafficVendorStatus.LoadByMediaTrafficVendorID(DbContext, Vndr.ID).ToList

                        Generate_SetStatus(Generate, MediaTrafficVendorStatuses)

                        Generate.MediaTrafficVendorID = Vndr.ID
                        Generate.Instruction = Vndr.MediaTrafficRevisionDescription
                        Generate.MediaTrafficRevisionID = Vndr.MediaTrafficRevisionID
                        Generate.VendorCode = Vndr.VendorCode
                        Generate.VendorName = Vndr.VendorName

                        If VendorRepresentatives IsNot Nothing AndAlso VendorRepresentatives.Count > 0 Then

                            Generate.Status = True

                        Else

                            Generate.Status = False

                        End If

                        'Generate.RecipientCount = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.MediaManagerRFPVendorRecipient)(String.Format("exec dbo.advsp_media_manager_rfp_recipients '{0}'", MediaRFPHeader.ID)).Count

                        If Vndr.AlertID.HasValue Then

                            AlertRecipients = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.AlertRecipient)("EXEC [dbo].[advsp_alert_recipient_get] {0}", Vndr.AlertID.Value).ToList
                                               Where Entity.EmployeeCode <> Session.User.EmployeeCode AndAlso
                                                     Entity.IsCurrentRecipient = True
                                               Select Entity).ToList

                            Generate.AlertRecipientEmployeeCodes = AlertRecipients.Select(Function(AR) AR.EmployeeCode).ToList

                            Generate.AlertRecipients = String.Join(", ", AlertRecipients.Select(Function(AR) AR.FullName).ToArray)

                        End If

                        MediaTrafficGenerateViewModel.GenerateList.Add(Generate)

                    Next

                End Using

            End Using

            Generate_Load = MediaTrafficGenerateViewModel

        End Function
        Private Sub Generate_LoadContactTypes(ByRef MediaTrafficGenerateViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficGenerateViewModel)

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim ContactTypes As String = Nothing
            Dim ContactTypeIDs As Generic.List(Of String) = Nothing

            Try

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficContactTypes.ToString)

                    If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                        ContactTypes = UserSetting.StringValue

                    End If

                    If String.IsNullOrWhiteSpace(ContactTypes) = False Then

                        ContactTypeIDs = Split(ContactTypes, ",").ToList

                    End If

                End Using

            Catch ex As Exception

            Finally

                If ContactTypeIDs Is Nothing Then

                    ContactTypeIDs = New Generic.List(Of String)

                End If

            End Try

            MediaTrafficGenerateViewModel.ContactTypeIDs = ContactTypeIDs

        End Sub
        Public Function Generate_SaveContactTypes(ContactTypes As String) As Boolean

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim Saved As Boolean = False

            Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficContactTypes.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = ContactTypes

                    Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    Saved = AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficContactTypes.ToString, ContactTypes, Nothing, Nothing, UserSetting)

                End If

            End Using

            Generate_SaveContactTypes = Saved

        End Function

#End Region

#Region " Process Generate "

        Public Function LoadMediaTrafficProcessGenerateViewModel(Generates As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Generate), ContactTypeIDs As Generic.List(Of String)) As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel

            'objects
            Dim MediaTrafficProcessGenerateViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel = Nothing
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing
            Dim GenerateVendorRep As AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep = Nothing

            MediaTrafficProcessGenerateViewModel = New AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficCCSender.ToString)

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    MediaTrafficProcessGenerateViewModel.CCSender = If(UserSetting.StringValue = "Y", True, False)

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficEmailBody.ToString)

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    MediaTrafficProcessGenerateViewModel.EmailBody = UserSetting.StringValue

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficEmailSubject.ToString)

                If UserSetting IsNot Nothing AndAlso String.IsNullOrWhiteSpace(UserSetting.StringValue) = False Then

                    MediaTrafficProcessGenerateViewModel.EmailSubject = UserSetting.StringValue

                End If

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTrafficProcessGenerateViewModel.ContactTypeList = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).ToList

            End Using

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Generate In Generates

                    If ContactTypeIDs IsNot Nothing AndAlso ContactTypeIDs.Count > 0 Then

                        For Each VenRep In From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Generate.VendorCode).ToList
                                           Where ContactTypeIDs.Contains(Entity.ContactTypeID.GetValueOrDefault(0))

                            GenerateVendorRep = MediaTrafficProcessGenerateViewModel.GenerateVendorReps.Where(Function(VR) VR.VendorCode = VenRep.VendorCode AndAlso VR.VendorRepCode = VenRep.Code).FirstOrDefault

                            If GenerateVendorRep IsNot Nothing Then

                                GenerateVendorRep.MediaTrafficRevisionIDs.Add(Generate.MediaTrafficRevisionID)

                            Else

                                MediaTrafficProcessGenerateViewModel.GenerateVendorReps.Add(New DTO.Media.Traffic.GenerateVendorRep(VenRep, Generate))

                            End If

                        Next

                        'MediaTrafficProcessGenerateViewModel.GenerateVendorReps.AddRange(From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Generate.VendorCode).ToList
                        '                                                                 Where ContactTypeIDs.Contains(Entity.ContactTypeID.GetValueOrDefault(0))
                        '                                                                 Select New AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep(Entity, Generate))

                    Else

                        For Each VenRep In From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Generate.VendorCode).ToList

                            GenerateVendorRep = MediaTrafficProcessGenerateViewModel.GenerateVendorReps.Where(Function(VR) VR.VendorCode = VenRep.VendorCode AndAlso VR.VendorRepCode = VenRep.Code).FirstOrDefault

                            If GenerateVendorRep IsNot Nothing Then

                                GenerateVendorRep.MediaTrafficRevisionIDs.Add(Generate.MediaTrafficRevisionID)

                            Else

                                MediaTrafficProcessGenerateViewModel.GenerateVendorReps.Add(New DTO.Media.Traffic.GenerateVendorRep(VenRep, Generate))

                            End If

                        Next

                        'MediaTrafficProcessGenerateViewModel.GenerateVendorReps.AddRange(From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Generate.VendorCode).ToList
                        '                                                                 Select New AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep(Entity, Generate))

                    End If

                Next

            End Using

            LoadMediaTrafficProcessGenerateViewModel = MediaTrafficProcessGenerateViewModel

        End Function
        Public Sub SaveEmailSettings(MediaTrafficProcessGenerateViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel)

            'objects
            Dim UserSetting As AdvantageFramework.Security.Database.Entities.UserSetting = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficCCSender.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = If(MediaTrafficProcessGenerateViewModel.CCSender, "Y", "N")

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficCCSender.ToString, If(MediaTrafficProcessGenerateViewModel.CCSender, "Y", "N"), Nothing, Nothing, UserSetting)

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficEmailBody.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = MediaTrafficProcessGenerateViewModel.EmailBody

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficEmailBody.ToString, MediaTrafficProcessGenerateViewModel.EmailBody, Nothing, Nothing, UserSetting)

                End If

                UserSetting = AdvantageFramework.Security.Database.Procedures.UserSetting.LoadByUserIDAndSettingCode(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficEmailSubject.ToString)

                If UserSetting IsNot Nothing Then

                    UserSetting.StringValue = MediaTrafficProcessGenerateViewModel.EmailSubject

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Update(SecurityDbContext, UserSetting)

                ElseIf UserSetting Is Nothing Then

                    AdvantageFramework.Security.Database.Procedures.UserSetting.Insert(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.UserSettings.MediaTrafficEmailSubject.ToString, MediaTrafficProcessGenerateViewModel.EmailSubject, Nothing, Nothing, UserSetting)

                End If

            End Using

        End Sub
        Public Sub Generate_CheckUncheck(ByRef ViewNodel As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel, GenerateVendorRep As AdvantageFramework.DTO.Media.Traffic.GenerateVendorRep, Checked As Boolean)

            ViewNodel.GenerateVendorReps.Where(Function(Entity) Entity.Equals(GenerateVendorRep)).First.Process = Checked

        End Sub
        Public Function Email_Load(AlertID As Integer) As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel

            'objects
            Dim MediaTrafficProcessGenerateViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim VendorRepCodes As IEnumerable(Of String) = Nothing
            Dim VendorContactCodes As IEnumerable(Of String) = Nothing

            MediaTrafficProcessGenerateViewModel = New AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    MediaTrafficProcessGenerateViewModel.Email_AlertID = AlertID

                    VendorRepCodes = (From Entity In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, AlertID)
                                      Where Entity.VendorRepresentativeCode IsNot Nothing AndAlso
                                            Entity.VendorRepresentativeCode <> ""
                                      Select Entity.VendorRepresentativeCode).ToArray

                    VendorContactCodes = (From Entity In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, AlertID)
                                          Where Entity.VendorContactCode IsNot Nothing AndAlso
                                                Entity.VendorContactCode <> ""
                                          Select Entity.VendorContactCode).ToArray

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If VendorRepCodes IsNot Nothing AndAlso VendorRepCodes.Count > 0 Then

                            MediaTrafficProcessGenerateViewModel.EmailVendorRepContacts.AddRange(From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.Load(DataContext)
                                                                                                 Where VendorRepCodes.Contains(Entity.Code) AndAlso
                                                                                                       Entity.VendorCode = Alert.VendorCode
                                                                                                 Select New AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact(Entity))

                        End If

                        If VendorContactCodes IsNot Nothing AndAlso VendorContactCodes.Count > 0 Then

                            MediaTrafficProcessGenerateViewModel.EmailVendorRepContacts.AddRange(From Entity In AdvantageFramework.Database.Procedures.VendorContact.Load(DbContext)
                                                                                                 Where VendorContactCodes.Contains(Entity.Code) AndAlso
                                                                                                       Entity.VendorCode = Alert.VendorCode
                                                                                                 Select New AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact(Entity))

                        End If

                    End Using

                End If

            End Using

            Email_Load = MediaTrafficProcessGenerateViewModel

        End Function
        Public Sub Email_CheckUncheck(ByRef ViewNodel As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel, EmailVendorRepContact As AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact, Checked As Boolean)

            ViewNodel.EmailVendorRepContacts.Where(Function(Entity) Entity.Equals(EmailVendorRepContact)).First.Include = Checked

        End Sub
        Public Function Email_SendEmails(ViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficProcessGenerateViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim Sent As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Alert = DbContext.Alerts.Find(ViewModel.Email_AlertID)

                If Alert IsNot Nothing Then

                    AlertComment = New AdvantageFramework.Database.Entities.AlertComment
                    AlertComment.DbContext = DbContext

                    AlertComment.AlertID = ViewModel.Email_AlertID
                    AlertComment.UserCode = DbContext.UserCode
                    AlertComment.GeneratedDate = Now
                    AlertComment.Comment = ViewModel.Email_Comment

                    If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Sent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(SecurityDbContext, DbContext, Alert, Alert.Subject, IncludeOriginator:=True, ErrorMessage:=ErrorMessage)

                        End Using

                    Else

                        ErrorMessage = "Cannot insert alert comment. Please contact software support."

                    End If

                Else

                    ErrorMessage = "Cannot find alert. Please contact software support."

                End If

            End Using

            Email_SendEmails = Sent

        End Function

#End Region

#Region " Responses "

        Public Function Response_Load(Vendors As Generic.List(Of AdvantageFramework.DTO.Media.Traffic.Vendor)) As AdvantageFramework.ViewModels.Media.MediaTrafficResponseViewModel

            'objects
            Dim MediaTrafficResponseViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficResponseViewModel = Nothing
            Dim MediaTrafficVendorIDs As IEnumerable(Of Integer) = Nothing
            Dim AlertIDs As IEnumerable(Of Integer) = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient) = Nothing

            MediaTrafficResponseViewModel = New AdvantageFramework.ViewModels.Media.MediaTrafficResponseViewModel
            MediaTrafficResponseViewModel.Vendors = Vendors

            MediaTrafficVendorIDs = Vendors.Select(Function(V) V.ID).ToArray

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaTrafficResponseViewModel.AlertComments = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Traffic.AlertComment)(String.Format("exec dbo.advsp_media_traffic_alert_comments '{0}'", String.Join(",", MediaTrafficVendorIDs.ToArray))).ToList

                If Session.User IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session.User.EmployeeCode) Then

                    AlertIDs = (From Entity In Vendors
                                Where Entity.AlertID.HasValue
                                Select Entity.AlertID.Value).ToArray

                    AlertRecipients = (From Entity In AdvantageFramework.Database.Procedures.AlertRecipient.Load(DbContext)
                                       Where Entity.EmployeeCode = Session.User.EmployeeCode AndAlso
                                             AlertIDs.Contains(Entity.AlertID) AndAlso
                                             Entity.HasBeenRead <> 1
                                       Select Entity).ToList

                    For Each AlertRecipient In AlertRecipients

                        AlertRecipient.HasBeenRead = 1
                        DbContext.Entry(AlertRecipient).State = Entity.EntityState.Modified

                    Next

                    DbContext.SaveChanges()

                End If

            End Using

            Response_Load = MediaTrafficResponseViewModel

        End Function

#End Region

#Region " Print Settings "

        Private Function GetTrafficPrintSetting(MediaType As String) As AdvantageFramework.DTO.Media.Traffic.PrintSetting

            'objects
            Dim MediaTrafficPrintSetting As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting = Nothing
            Dim PrintSetting As AdvantageFramework.DTO.Media.Traffic.PrintSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaTrafficPrintSetting = AdvantageFramework.Database.Procedures.MediaTrafficPrintSetting.LoadByUserCodeAndMediaType(DbContext, Session.UserCode, MediaType)

                If MediaTrafficPrintSetting IsNot Nothing Then

                    PrintSetting = New AdvantageFramework.DTO.Media.Traffic.PrintSetting(MediaTrafficPrintSetting)

                Else

                    PrintSetting = New AdvantageFramework.DTO.Media.Traffic.PrintSetting(Session.UserCode, MediaType)

                    MediaTrafficPrintSetting = New AdvantageFramework.Database.Entities.MediaTrafficPrintSetting

                    PrintSetting.SaveToEntity(MediaTrafficPrintSetting)

                    MediaTrafficPrintSetting.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.MediaTrafficPrintSetting.Insert(DbContext, MediaTrafficPrintSetting, Nothing)

                    PrintSetting = New AdvantageFramework.DTO.Media.Traffic.PrintSetting(MediaTrafficPrintSetting)

                End If

            End Using

            GetTrafficPrintSetting = PrintSetting

        End Function
        Public Function PrintSettings_Load(MediaType As String) As AdvantageFramework.ViewModels.Media.MediaTrafficPrintSettingViewModel

            Dim MediaTrafficPrintSettingViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficPrintSettingViewModel = Nothing

            MediaTrafficPrintSettingViewModel = New AdvantageFramework.ViewModels.Media.MediaTrafficPrintSettingViewModel

            MediaTrafficPrintSettingViewModel.PrintSettings.Add(GetTrafficPrintSetting(MediaType))

            PrintSettings_Load = MediaTrafficPrintSettingViewModel

        End Function
        Public Function PrintSettings_Save(ViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficPrintSettingViewModel) As Boolean

            Dim Saved As Boolean = False
            Dim PrintSetting As AdvantageFramework.DTO.Media.Traffic.PrintSetting = Nothing
            Dim MediaTrafficPrintSetting As AdvantageFramework.Database.Entities.MediaTrafficPrintSetting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ViewModel.PrintSettings IsNot Nothing AndAlso ViewModel.PrintSettings.Count > 0 Then

                    PrintSetting = ViewModel.PrintSettings.Item(0)

                    MediaTrafficPrintSetting = DbContext.MediaTrafficPrintSettings.Find(PrintSetting.ID)

                    If MediaTrafficPrintSetting IsNot Nothing Then

                        PrintSetting.SaveToEntity(MediaTrafficPrintSetting)

                        DbContext.Entry(MediaTrafficPrintSetting).State = Entity.EntityState.Modified

                        DbContext.SaveChanges()

                        Saved = True

                    End If

                End If

            End Using

            PrintSettings_Save = Saved

        End Function

#End Region

#Region " Copy Instruction "

        Public Function Copy_LoadWorksheetMarkets(MediaTrafficRevisionID As Integer) As AdvantageFramework.ViewModels.Media.MediaTrafficInstructionCopyViewModel

            Dim MediaTrafficInstructionCopyViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficInstructionCopyViewModel = Nothing

            MediaTrafficInstructionCopyViewModel = New AdvantageFramework.ViewModels.Media.MediaTrafficInstructionCopyViewModel

            MediaTrafficInstructionCopyViewModel.MediaTrafficRevisionID = MediaTrafficRevisionID

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaTrafficInstructionCopyViewModel.Worksheets = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.Traffic.Worksheet)(String.Format("exec dbo.advsp_media_traffic_instruction_copy_get_worksheet_markets {0}", MediaTrafficRevisionID)).ToList

            End Using

            Copy_LoadWorksheetMarkets = MediaTrafficInstructionCopyViewModel

        End Function
        Public Sub Copy_Copy(MediaTrafficInstructionCopyViewModel As AdvantageFramework.ViewModels.Media.MediaTrafficInstructionCopyViewModel, ByRef ErrorText As String)

            'objects
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim MediaTraffic As AdvantageFramework.Database.Entities.MediaTraffic = Nothing
            Dim MediaBroadcastWorksheetMarketTraffic As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketTraffic = Nothing
            Dim MediaTrafficRevisionToCopy As AdvantageFramework.Database.Entities.MediaTrafficRevision = Nothing
            Dim MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision = Nothing
            Dim MediaTrafficCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup = Nothing
            Dim MediaTrafficDetail As AdvantageFramework.Database.Entities.MediaTrafficDetail = Nothing
            Dim MediaTrafficDetailDocument As AdvantageFramework.Database.Entities.MediaTrafficDetailDocument = Nothing
            Dim VendorCodes As IEnumerable(Of String) = Nothing
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing
            'Dim MediaTrafficVendorCreativeGroup As AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup = Nothing
            'Dim VendorCode As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                Try

                    DbTransaction = DbContext.Database.BeginTransaction

                    For Each MediaBroadcastWorksheetMarketID In MediaTrafficInstructionCopyViewModel.MediaBroadcastWorksheetMarketIDs

                        MediaTrafficRevisionToCopy = DbContext.MediaTrafficRevisions.Find(MediaTrafficInstructionCopyViewModel.MediaTrafficRevisionID)

                        If MediaTrafficRevisionToCopy IsNot Nothing Then

                            MediaTraffic = New AdvantageFramework.Database.Entities.MediaTraffic
                            MediaTraffic.DbContext = DbContext
                            DbContext.MediaTraffics.Add(MediaTraffic)
                            DbContext.SaveChanges()

                            MediaBroadcastWorksheetMarketTraffic = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketTraffic
                            MediaBroadcastWorksheetMarketTraffic.DbContext = DbContext
                            MediaBroadcastWorksheetMarketTraffic.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                            MediaBroadcastWorksheetMarketTraffic.MediaTrafficID = MediaTraffic.ID
                            DbContext.MediaBroadcastWorksheetMarketTraffics.Add(MediaBroadcastWorksheetMarketTraffic)
                            DbContext.SaveChanges()

                            MediaTrafficRevision = New AdvantageFramework.Database.Entities.MediaTrafficRevision
                            MediaTrafficRevision.DbContext = DbContext
                            MediaTrafficRevision.MediaTrafficID = MediaTraffic.ID
                            MediaTrafficRevision.StartDate = MediaTrafficRevisionToCopy.StartDate
                            MediaTrafficRevision.EndDate = MediaTrafficRevisionToCopy.EndDate
                            MediaTrafficRevision.Description = MediaTrafficRevisionToCopy.Description
                            MediaTrafficRevision.CreatedByUserCode = Session.UserCode
                            MediaTrafficRevision.CreatedDate = Now

                            If AdvantageFramework.Database.Procedures.MediaTrafficRevision.Insert(DbContext, MediaTrafficRevision, ErrorText) = False Then

                                Throw New Exception("Failed to insert media traffic revision: " & ErrorText)

                            End If

                            For Each MTCG In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficRevisionToCopy.ID).ToList

                                MediaTrafficCreativeGroup = New AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup
                                MediaTrafficCreativeGroup.DbContext = DbContext
                                MediaTrafficCreativeGroup.MediaTrafficRevisionID = MediaTrafficRevision.ID
                                MediaTrafficCreativeGroup.Name = MTCG.Name
                                MediaTrafficCreativeGroup.IsDefault = MTCG.IsDefault

                                If AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.Insert(DbContext, MediaTrafficCreativeGroup, ErrorText) = False Then

                                    Throw New Exception("Failed to insert media traffic creative group: " & ErrorText)

                                End If

                                For Each MTD In AdvantageFramework.Database.Procedures.MediaTrafficDetail.LoadByMediaTrafficCreativeGroupID(DbContext, MTCG.ID).ToList

                                    MediaTrafficDetail = New AdvantageFramework.Database.Entities.MediaTrafficDetail
                                    MediaTrafficDetail.DbContext = DbContext
                                    MediaTrafficDetail.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroup.ID
                                    MediaTrafficDetail.DayPartID = MTD.DayPartID
                                    MediaTrafficDetail.Length = MTD.Length
                                    MediaTrafficDetail.StartTime = MTD.StartTime
                                    MediaTrafficDetail.EndTime = MTD.EndTime
                                    MediaTrafficDetail.AdNumber = MTD.AdNumber
                                    MediaTrafficDetail.CreativeTitle = MTD.CreativeTitle
                                    MediaTrafficDetail.Location = MTD.Location
                                    MediaTrafficDetail.IsBookend = MTD.IsBookend
                                    MediaTrafficDetail.BookendName = MTD.BookendName
                                    MediaTrafficDetail.BookendSequenceNumber = MTD.BookendSequenceNumber
                                    MediaTrafficDetail.Position = MTD.Position
                                    MediaTrafficDetail.Rotation = MTD.Rotation
                                    MediaTrafficDetail.Comment = MTD.Comment

                                    If AdvantageFramework.Database.Procedures.MediaTrafficDetail.Insert(DbContext, MediaTrafficDetail, ErrorText) = False Then

                                        Throw New Exception("Failed to insert media traffic detail: " & ErrorText)

                                    End If

                                    For Each MTDD In MTD.MediaTrafficDetailDocuments

                                        MediaTrafficDetailDocument = New AdvantageFramework.Database.Entities.MediaTrafficDetailDocument
                                        MediaTrafficDetailDocument.DbContext = DbContext
                                        MediaTrafficDetailDocument.MediaTrafficDetailID = MediaTrafficDetail.ID
                                        MediaTrafficDetailDocument.DocumentID = MTDD.DocumentID

                                        If AdvantageFramework.Database.Procedures.MediaTrafficDetailDocument.Insert(DbContext, MediaTrafficDetailDocument, ErrorText) = False Then

                                            Throw New Exception("Failed to insert media traffic detail document: " & ErrorText)

                                        End If

                                    Next

                                Next

                            Next

                            If MediaTrafficInstructionCopyViewModel.CopyAllVendors Then

                                VendorCodes = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail")
                                               Where Entity.OrderNumber IsNot Nothing AndAlso
                                                     Entity.MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                                               Select Entity.MediaBroadcastWorksheetMarketDetail.VendorCode).Distinct.ToArray

                                For Each VendorCode In VendorCodes

                                    MediaTrafficVendor = New AdvantageFramework.Database.Entities.MediaTrafficVendor
                                    MediaTrafficVendor.DbContext = DbContext
                                    MediaTrafficVendor.MediaTrafficRevisionID = MediaTrafficRevision.ID
                                    MediaTrafficVendor.VendorCode = VendorCode

                                    If AdvantageFramework.Database.Procedures.MediaTrafficVendor.Insert(DbContext, MediaTrafficVendor, ErrorText) = False Then

                                        Throw New Exception("Failed to insert media traffic vendor: " & ErrorText)

                                    End If


                                Next

                            End If

                            'For Each MTV In MediaTrafficVendorList

                            '    For Each MTCG In AdvantageFramework.Database.Procedures.MediaTrafficCreativeGroup.LoadByMediaTrafficRevisionID(DbContext, MediaTrafficViewModel.SelectedRevision.ID).ToList


                            '        For Each MTVCG In (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.LoadByMediaTrafficCreativeGroupID(DbContext, MTCG.ID)
                            '                           Where Entity.MediaTrafficVendorID = MTV.ID
                            '                           Select Entity).ToList

                            '            MediaTrafficVendorCreativeGroup = New AdvantageFramework.Database.Entities.MediaTrafficVendorCreativeGroup
                            '            MediaTrafficVendorCreativeGroup.DbContext = DbContext
                            '            MediaTrafficVendorCreativeGroup.MediaTrafficVendorID = MediaTrafficVendor.ID
                            '            MediaTrafficVendorCreativeGroup.MediaTrafficCreativeGroupID = MediaTrafficCreativeGroup.ID
                            '            MediaTrafficVendorCreativeGroup.CableNetworkStationCodes = MTVCG.CableNetworkStationCodes

                            '            If AdvantageFramework.Database.Procedures.MediaTrafficVendorCreativeGroup.Insert(DbContext, MediaTrafficVendorCreativeGroup, ErrorText) = False Then

                            '                Throw New Exception("Failed to insert media traffic vendor creative group: " & ErrorText)

                            '            End If

                            '        Next

                            '    Next

                            'Next

                        End If

                    Next

                    DbTransaction.Commit()

                Catch ex As Exception
                    DbTransaction.Rollback()
                Finally

                    If DbContext.Database.Connection.State = ConnectionState.Open Then

                        DbContext.Database.Connection.Close()

                    End If

                End Try

            End Using

        End Sub

#End Region

#End Region

#End Region

    End Class

    'Friend Class AdNumberLength

    '    Public Property AdNumber As String
    '    Public Property Length As Integer

    '    Public Sub New(AdNumber As String, Length As Integer)

    '        Me.AdNumber = AdNumber
    '        Me.Length = Length

    '    End Sub

    'End Class

End Namespace
