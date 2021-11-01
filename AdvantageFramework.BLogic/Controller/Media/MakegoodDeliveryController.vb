Namespace Controller.Media

    Public Class MakegoodDeliveryController
        Inherits AdvantageFramework.Controller.BaseController

        Public Class OrderLine

            Public Sub New(OrderNumber As Integer, LineNumber As Integer, MediaType As String)

                _OrderNumber = OrderNumber
                _LineNumber = LineNumber
                _MediaType = MediaType

            End Sub

            Public Property OrderNumber As Integer
            Public Property LineNumber As Integer
            Public Property MediaType As String

        End Class

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum StagingDataColumns
            ID
            ParentID
            RowType
            Line
            MakegoodNumber
            IsOriginal
            CableNetwork
            CableNetworkCode
            DayPartID
            DayPartDescription
            Length
            Bookend
            AddedValue
            Program
            Days
            StartTime
            EndTime
            Comments
            DefaultRate
            TotalSpots
            PrimaryRating
            PrimaryGRP
            PrimaryCPP
            PrimaryImpressions
            PrimaryGIMP
            PrimaryCPM
            TotalGross
            RateDiffersFlag
            IsSubmitted
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub CreateStagingRows(DbContext As AdvantageFramework.Database.DbContext, MediaBroadcastWorksheetMarketDetailIDs As Generic.List(Of Integer),
                                      MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel)

            'objects
            Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetailDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate = Nothing

            For Each MediaBroadcastWorksheetMarketDetail In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.Load(DbContext)
                                                             Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.ID)
                                                             Select Entity).ToList

                MediaBroadcastWorksheetMarketStagingDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID)
                                                              Where Entity.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber AndAlso
                                                                    Entity.IsOriginal = True
                                                              Select Entity).SingleOrDefault

                If MediaBroadcastWorksheetMarketStagingDetail Is Nothing Then

                    MediaBroadcastWorksheetMarketStagingDetail = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail
                    MediaBroadcastWorksheetMarketStagingDetail.DbContext = DbContext
                    MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetail.ID
                    MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID
                    MediaBroadcastWorksheetMarketStagingDetail.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber
                    MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = MediaBroadcastWorksheetMarketDetail.MakegoodNumber
                    MediaBroadcastWorksheetMarketStagingDetail.MakegoodDate = MediaBroadcastWorksheetMarketDetail.MakegoodDate
                    MediaBroadcastWorksheetMarketStagingDetail.MakegoodSpots = MediaBroadcastWorksheetMarketDetail.MakegoodSpots
                    MediaBroadcastWorksheetMarketStagingDetail.RevisionNumber = MediaBroadcastWorksheetMarketDetail.RevisionNumber
                    MediaBroadcastWorksheetMarketStagingDetail.CableNetworkStationCode = MediaBroadcastWorksheetMarketDetail.CableNetworkStationCode
                    MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode = MediaBroadcastWorksheetMarketDetail.CableNetworkNielsenTVStationCode
                    MediaBroadcastWorksheetMarketStagingDetail.Program = MediaBroadcastWorksheetMarketDetail.Program
                    MediaBroadcastWorksheetMarketStagingDetail.DaypartID = MediaBroadcastWorksheetMarketDetail.DaypartID
                    MediaBroadcastWorksheetMarketStagingDetail.Length = MediaBroadcastWorksheetMarketDetail.Length
                    MediaBroadcastWorksheetMarketStagingDetail.Days = MediaBroadcastWorksheetMarketDetail.Days
                    MediaBroadcastWorksheetMarketStagingDetail.Sunday = MediaBroadcastWorksheetMarketDetail.Sunday
                    MediaBroadcastWorksheetMarketStagingDetail.Monday = MediaBroadcastWorksheetMarketDetail.Monday
                    MediaBroadcastWorksheetMarketStagingDetail.Tuesday = MediaBroadcastWorksheetMarketDetail.Tuesday
                    MediaBroadcastWorksheetMarketStagingDetail.Wednesday = MediaBroadcastWorksheetMarketDetail.Wednesday
                    MediaBroadcastWorksheetMarketStagingDetail.Thursday = MediaBroadcastWorksheetMarketDetail.Thursday
                    MediaBroadcastWorksheetMarketStagingDetail.Friday = MediaBroadcastWorksheetMarketDetail.Friday
                    MediaBroadcastWorksheetMarketStagingDetail.Saturday = MediaBroadcastWorksheetMarketDetail.Saturday
                    MediaBroadcastWorksheetMarketStagingDetail.StartTime = MediaBroadcastWorksheetMarketDetail.StartTime
                    MediaBroadcastWorksheetMarketStagingDetail.EndTime = MediaBroadcastWorksheetMarketDetail.EndTime
                    MediaBroadcastWorksheetMarketStagingDetail.StartHour = MediaBroadcastWorksheetMarketDetail.StartHour
                    MediaBroadcastWorksheetMarketStagingDetail.EndHour = MediaBroadcastWorksheetMarketDetail.EndHour
                    MediaBroadcastWorksheetMarketStagingDetail.Comments = MediaBroadcastWorksheetMarketDetail.Comments
                    MediaBroadcastWorksheetMarketStagingDetail.Bookend = MediaBroadcastWorksheetMarketDetail.Bookend
                    MediaBroadcastWorksheetMarketStagingDetail.DefaultRate = MediaBroadcastWorksheetMarketDetail.DefaultRate
                    MediaBroadcastWorksheetMarketStagingDetail.IsOriginal = True
                    MediaBroadcastWorksheetMarketStagingDetail.MadegoodNumber = MediaBroadcastWorksheetMarketDetail.MadegoodNumber

                    MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating = If(MakegoodDeliveryViewModel.MediaType = "T", MediaBroadcastWorksheetMarketDetail.PrimaryRating, MediaBroadcastWorksheetMarketDetail.PrimaryAQHRating)
                    MediaBroadcastWorksheetMarketStagingDetail.PrimaryCPP = 0
                    MediaBroadcastWorksheetMarketStagingDetail.PrimaryCPM = 0
                    MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions = If(MakegoodDeliveryViewModel.MediaType = "T", MediaBroadcastWorksheetMarketDetail.PrimaryImpressions, MediaBroadcastWorksheetMarketDetail.PrimaryAQH)

                    MediaBroadcastWorksheetMarketStagingDetail.SecondaryRating = 0
                    MediaBroadcastWorksheetMarketStagingDetail.SecondaryCPP = 0
                    MediaBroadcastWorksheetMarketStagingDetail.SecondaryCPM = 0
                    MediaBroadcastWorksheetMarketStagingDetail.SecondaryImpressions = 0

                    MediaBroadcastWorksheetMarketStagingDetail.CreatedByUserCode = DbContext.UserCode
                    MediaBroadcastWorksheetMarketStagingDetail.CreatedDate = Now

                    MediaBroadcastWorksheetMarketStagingDetail.ValueAdded = MediaBroadcastWorksheetMarketDetail.ValueAdded
                    MediaBroadcastWorksheetMarketStagingDetail.IsSubmitted = False

                    For Each MediaBroadcastWorksheetMarketDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID)
                                                                         Select Entity).ToList

                        MediaBroadcastWorksheetMarketStagingDetailDate = New AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate
                        MediaBroadcastWorksheetMarketStagingDetailDate.DbContext = DbContext
                        MediaBroadcastWorksheetMarketStagingDetailDate.Date = MediaBroadcastWorksheetMarketDetailDate.Date
                        MediaBroadcastWorksheetMarketStagingDetailDate.IsHiatus = MediaBroadcastWorksheetMarketDetailDate.IsHiatus
                        MediaBroadcastWorksheetMarketStagingDetailDate.Rate = MediaBroadcastWorksheetMarketDetailDate.Rate
                        MediaBroadcastWorksheetMarketStagingDetailDate.AllowSpotsToBeEntered = MediaBroadcastWorksheetMarketDetailDate.AllowSpotsToBeEntered

                        If MediaBroadcastWorksheetMarketDetailDate.OrderNumber.HasValue AndAlso MediaBroadcastWorksheetMarketDetailDate.OrderLineNumber.HasValue AndAlso
                                MakegoodDeliveryViewModel.LineNumbers.Contains(MediaBroadcastWorksheetMarketDetailDate.OrderLineNumber.Value) Then

                            MediaBroadcastWorksheetMarketStagingDetailDate.Spots = MediaBroadcastWorksheetMarketDetailDate.Spots

                        Else

                            MediaBroadcastWorksheetMarketStagingDetailDate.Spots = 0

                        End If

                        MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketStagingDetailDates.Add(MediaBroadcastWorksheetMarketStagingDetailDate)

                    Next

                    DbContext.MediaBroadcastWorksheetMarketStagingDetails.Add(MediaBroadcastWorksheetMarketStagingDetail)
                    DbContext.SaveChanges()

                End If

            Next

        End Sub
        Private Function DatesModified(ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel) As Boolean

            Dim IsModified As Boolean = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                    Where ViewModel.MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                          Entity.MediaBroadcastWorksheetOrderStatusID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified
                    Select Entity.MediaBroadcastWorksheetMarketDetailID).Any Then

                    IsModified = True

                End If

            End Using

            DatesModified = IsModified

        End Function
        Private Function BuildOriginalDataTable(DbContext As AdvantageFramework.Database.DbContext, MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer), MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel,
                                                DataTableToClone As System.Data.DataTable, Dayparts As Generic.List(Of AdvantageFramework.Database.Entities.Daypart)) As System.Data.DataTable

            Dim DataTable As System.Data.DataTable = Nothing
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim SpotColumnCounter As Integer = 0
            Dim TotalSpots As Integer = 0
            Dim RateDiffers As Boolean = False
            Dim DatesWithRateGreaterThanZeroCount As Integer = 0
            Dim AverageRateAmount As Decimal = 0
            Dim TotalRateAmount As Decimal = 0
            Dim TotalDollars As Decimal = 0

            DataTable = DataTableToClone.Clone

            DataTable.BeginLoadData()

            For Each MediaBroadcastWorksheetMarketDetailID In MediaBroadcastWorksheetMarketDetailIDs

                MediaBroadcastWorksheetMarketDetail = DbContext.MediaBroadcastWorksheetMarketDetails.Find(MediaBroadcastWorksheetMarketDetailID)

                If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                    If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                        MakegoodDeliveryViewModel.PrimaryDemographic = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.Description

                    End If

                    'If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic IsNot Nothing Then

                    '    MakegoodDeliveryViewModel.SecondaryDemographic = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.SecondaryMediaDemographic.Description

                    'End If

                    DataRow = DataTable.NewRow

                    SpotColumnCounter = 0

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = MediaBroadcastWorksheetMarketDetail.ID

                    If MediaBroadcastWorksheetMarketDetail.MakegoodNumber = 0 Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = System.DBNull.Value

                    Else

                        If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID)
                            Where Entity.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode AndAlso
                                  Entity.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber AndAlso
                                  Entity.MakegoodNumber = 0
                            Select Entity).Count = 1 Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID)
                                                                                                                                            Where Entity.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode AndAlso
                                                                                                                                                  Entity.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber AndAlso
                                                                                                                                                  Entity.MakegoodNumber = 0
                                                                                                                                            Select Entity).Single.ID

                        End If

                    End If

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketDetail.LineNumber.ToString.PadLeft(4, "0") & If(MediaBroadcastWorksheetMarketDetail.MakegoodNumber = 0, "", "-" & MediaBroadcastWorksheetMarketDetail.MakegoodNumber.ToString.PadLeft(2, "0"))
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.MakegoodNumber.ToString) = MediaBroadcastWorksheetMarketDetail.MakegoodNumber
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = True
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetwork.ToString) = MediaBroadcastWorksheetMarketDetail.CableNetworkStationCode
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetworkCode.ToString) = If(MediaBroadcastWorksheetMarketDetail.CableNetworkNielsenTVStationCode Is Nothing, System.DBNull.Value, MediaBroadcastWorksheetMarketDetail.CableNetworkNielsenTVStationCode)
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Days.ToString) = MediaBroadcastWorksheetMarketDetail.Days
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.StartTime.ToString) = MediaBroadcastWorksheetMarketDetail.StartTime
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.EndTime.ToString) = MediaBroadcastWorksheetMarketDetail.EndTime
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Program.ToString) = MediaBroadcastWorksheetMarketDetail.Program

                    If MediaBroadcastWorksheetMarketDetail.DaypartID.HasValue Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartID.ToString) = MediaBroadcastWorksheetMarketDetail.DaypartID

                    End If

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Length.ToString) = MediaBroadcastWorksheetMarketDetail.Length
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = MediaBroadcastWorksheetMarketDetail.Bookend
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = MediaBroadcastWorksheetMarketDetail.ValueAdded
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Comments.ToString) = MediaBroadcastWorksheetMarketDetail.Comments

                    If MediaBroadcastWorksheetMarketDetail.DaypartID.HasValue AndAlso MediaBroadcastWorksheetMarketDetail.DaypartID.Value > 0 Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString) = Dayparts.Where(Function(Entity) Entity.ID = MediaBroadcastWorksheetMarketDetail.DaypartID.Value).FirstOrDefault.Description

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString) = String.Empty

                    End If

                    TotalSpots = 0
                    DatesWithRateGreaterThanZeroCount = 0
                    TotalRateAmount = 0
                    TotalDollars = 0

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0

                    RateDiffers = False

                    For Each MediaBroadcastWorksheetMarketDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetail.ID)
                                                                         Select Entity).OrderBy(Function(E) E.Date).ToList

                        If MediaBroadcastWorksheetMarketDetailDate.Date >= MakegoodDeliveryViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketDetailDate.Date <= MakegoodDeliveryViewModel.MaxDate Then

                            If MediaBroadcastWorksheetMarketDetailDate.IsHiatus OrElse
                                    MediaBroadcastWorksheetMarketDetailDate.OrderNumber.HasValue = False Then 'OrElse MediaBroadcastWorksheetMarketDetailDate.AllowSpotsToBeEntered = False

                                DataRow("Spot" & SpotColumnCounter) = System.DBNull.Value
                                DataRow("Rate" & SpotColumnCounter) = System.DBNull.Value

                            Else

                                DataRow("Spot" & SpotColumnCounter) = MediaBroadcastWorksheetMarketDetailDate.Spots
                                DataRow("Rate" & SpotColumnCounter) = MediaBroadcastWorksheetMarketDetailDate.Rate
                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) += MediaBroadcastWorksheetMarketDetailDate.Spots * MediaBroadcastWorksheetMarketDetailDate.Rate

                                If MediaBroadcastWorksheetMarketDetailDate.Rate > 0 Then

                                    DatesWithRateGreaterThanZeroCount += 1

                                End If

                                If RateDiffers = False AndAlso MediaBroadcastWorksheetMarketDetail.DefaultRate <> MediaBroadcastWorksheetMarketDetailDate.Rate Then

                                    RateDiffers = True

                                End If

                                TotalRateAmount += MediaBroadcastWorksheetMarketDetailDate.Rate

                                TotalDollars += (MediaBroadcastWorksheetMarketDetailDate.Rate * CDec(MediaBroadcastWorksheetMarketDetailDate.Spots))

                                TotalSpots += MediaBroadcastWorksheetMarketDetailDate.Spots

                            End If

                            SpotColumnCounter += 1

                        End If

                    Next

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalSpots

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString) = MediaBroadcastWorksheetMarketDetail.DefaultRate
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RateDiffersFlag.ToString) = RateDiffers

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = If(MakegoodDeliveryViewModel.MediaType = "T", MediaBroadcastWorksheetMarketDetail.PrimaryRating, MediaBroadcastWorksheetMarketDetail.PrimaryAQHRating)
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) * TotalSpots

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) = If(MakegoodDeliveryViewModel.MediaType = "T", MediaBroadcastWorksheetMarketDetail.PrimaryImpressions, MediaBroadcastWorksheetMarketDetail.PrimaryAQH)

                    If MakegoodDeliveryViewModel.MediaType = "T" Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = FormatNumber(MediaBroadcastWorksheetMarketDetail.PrimaryImpressions * TotalSpots / 1000, 1)

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = FormatNumber(MediaBroadcastWorksheetMarketDetail.PrimaryAQH * TotalSpots / 100, 0)

                    End If

                    If TotalSpots = 0 Then

                        If DatesWithRateGreaterThanZeroCount > 0 Then

                            AverageRateAmount = TotalRateAmount / DatesWithRateGreaterThanZeroCount

                        Else

                            AverageRateAmount = 0

                        End If

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = 0, 0, Math.Round(AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString), 2))
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) <> 0, Math.Round((AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString)), 2), 0)

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0, 0, Math.Round(TotalDollars / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString), 2))
                        'DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) <> 0, Math.Round((TotalDollars / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString)), 2), 0)

                        If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) * TotalSpots = 0 Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                        Else

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = Math.Round((TotalDollars / (DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) * TotalSpots) * 1000), 2)

                        End If

                    End If

                    DataTable.Rows.Add(DataRow)

                End If

            Next

            DataTable.EndLoadData()

            BuildOriginalDataTable = DataTable

        End Function
        Private Function ConvertToDate(InputString As String) As Date

            ConvertToDate = DateSerial(InputString.Substring(0, 4), InputString.Substring(4, 2), InputString.Substring(6, 2))

        End Function
        Private Sub RefreshGridAdvantage(DataContext As AdvantageFramework.Database.DataContext, MediaType As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes,
                                         ByRef ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel)

            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing

            GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridTypeAndUserCodeAndGridSubtype(DataContext, Database.Entities.GridAdvantageType.MediaBroadcastWorksheetMakegoodOffers, Me.Session.UserCode, MediaType)

            If GridAdvantage IsNot Nothing Then

                ViewModel.GridAdvantage = New DTO.GridAdvantage(GridAdvantage)

            Else

                ViewModel.GridAdvantage = New DTO.GridAdvantage

                ViewModel.GridAdvantage.UserCode = Me.Session.UserCode
                ViewModel.GridAdvantage.GridType = Database.Entities.GridAdvantageType.MediaBroadcastWorksheetMakegoodOffers
                ViewModel.GridAdvantage.GridSubtype = MediaType

            End If

        End Sub

#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Sub CreateWSDataTable(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, ByRef ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel)

            'objects
            'Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            'Dim RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim MediaBroadcastWorksheetMarketDetailIDs As Generic.List(Of Integer) = Nothing
            Dim IsHiatus As Boolean = False
            Dim SpotCounter As Integer = 0
            'Dim LineNumbers As IEnumerable(Of Short) = Nothing
            Dim MaxRevisionNumber As Integer = 0
            Dim MaxDate As Date = Nothing

            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                      Where Entity.OrderNumber = OrderNumber
                                                      Select Entity.MediaBroadcastWorksheetMarketDetailID).Distinct.ToList

            ViewModel.MinDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                 Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                 Select Entity.Date).Min

            ViewModel.MaxDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                 Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                 Select Entity.Date).Max

            MaxDate = ViewModel.MaxDate

            ViewModel.StartDates = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                    Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                          Entity.Date <> MaxDate
                                    Select Entity.Date).Distinct.ToList.Select(Function(D) New With {.Code = D.ToString("MM/dd/yyyy"),
                                                                                                     .Description = D.ToString("MM/dd/yyyy")}).Distinct.ToList

            'LineNumbers = ViewModel.LineNumbers.ToArray

            'If ViewModel.MediaType = "T" Then

            '    TVOrderDetails = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber).ToList

            '    ViewModel.MinDate = (From Entity In TVOrderDetails
            '                         Where LineNumbers.Contains(Entity.LineNumber)
            '                         Select Entity.StartDate).Min

            '    ViewModel.MaxDate = (From Entity In TVOrderDetails
            '                         Where LineNumbers.Contains(Entity.LineNumber)
            '                         Select Entity.EndDate).Max

            'ElseIf ViewModel.MediaType = "R" Then

            '    RadioOrderDetails = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber).ToList

            '    ViewModel.MinDate = (From Entity In RadioOrderDetails
            '                         Where LineNumbers.Contains(Entity.LineNumber)
            '                         Select Entity.StartDate).Min

            '    ViewModel.MaxDate = (From Entity In RadioOrderDetails
            '                         Where LineNumbers.Contains(Entity.LineNumber)
            '                         Select Entity.EndDate).Max

            'End If

            ViewModel.BroadcastCalendars = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.BroadcastCalendar)("exec dbo.[advsp_broadcast_weeks]").ToList

            ViewModel.SpotDates = New Dictionary(Of String, Integer)
            ViewModel.SpotDateBroadcastYearMonth = New Dictionary(Of Integer, String)

            DataTable = New System.Data.DataTable

            DataColumn = DataTable.Columns.Add(StagingDataColumns.ID.ToString)
            DataColumn.DataType = GetType(Integer)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.ParentID.ToString)
            DataColumn.DataType = GetType(Integer)
            DataColumn.AllowDBNull = True

            DataColumn = DataTable.Columns.Add(StagingDataColumns.RowType.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.Line.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.MakegoodNumber.ToString)
            DataColumn.DataType = GetType(Integer)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.IsOriginal.ToString)
            DataColumn.DataType = GetType(Boolean)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.CableNetwork.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.CableNetworkCode.ToString)
            DataColumn.DataType = GetType(Integer)
            DataColumn.AllowDBNull = True

            DataColumn = DataTable.Columns.Add(StagingDataColumns.DayPartID.ToString)
            DataColumn.DataType = GetType(Integer)
            DataColumn.AllowDBNull = True

            DataColumn = DataTable.Columns.Add(StagingDataColumns.DayPartDescription.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.Length.ToString)
            DataColumn.DataType = GetType(Short)
            DataColumn.AllowDBNull = True

            DataColumn = DataTable.Columns.Add(StagingDataColumns.Bookend.ToString)
            DataColumn.DataType = GetType(Boolean)
            DataColumn.AllowDBNull = False

            DataColumn = DataTable.Columns.Add(StagingDataColumns.AddedValue.ToString)
            DataColumn.DataType = GetType(Boolean)
            DataColumn.AllowDBNull = False

            DataColumn = DataTable.Columns.Add(StagingDataColumns.Program.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.Days.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.StartTime.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.EndTime.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.Comments.ToString)
            DataColumn.DataType = GetType(String)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.DefaultRate.ToString)
            DataColumn.DataType = GetType(Decimal)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.RateDiffersFlag.ToString)
            DataColumn.DataType = GetType(Boolean)

            'MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
            '                                          Where Entity.OrderNumber = OrderNumber AndAlso
            '                                                Entity.OrderLineNumber IsNot Nothing AndAlso
            '                                                LineNumbers.Contains(Entity.OrderLineNumber)
            '                                          Select Entity.MediaBroadcastWorksheetMarketDetailID).Distinct.ToList

            MaxRevisionNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketDetailIDs(DbContext, MediaBroadcastWorksheetMarketDetailIDs)
                                 Select Entity).Max(Function(Entity) Entity.RevisionNumber)

            ViewModel.MaxRevisionNumber = MaxRevisionNumber

            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketDetailIDs(DbContext, MediaBroadcastWorksheetMarketDetailIDs)
                                                      Where Entity.RevisionNumber = MaxRevisionNumber
                                                      Select Entity.ID).ToList

            If MediaBroadcastWorksheetMarketDetailIDs IsNot Nothing AndAlso MediaBroadcastWorksheetMarketDetailIDs.Count > 0 Then

                For Each MediaBroadcastWorksheetMarketDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                     Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                                     Select Entity.Date).ToList.OrderBy(Function(Entity) Entity.Date).Distinct.ToList

                    If MediaBroadcastWorksheetMarketDetailDate >= ViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketDetailDate <= ViewModel.MaxDate Then

                        IsHiatus = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                    Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                          Entity.Date = MediaBroadcastWorksheetMarketDetailDate
                                    Select Entity).First.IsHiatus


                        DataColumn = DataTable.Columns.Add("Spot" & SpotCounter)
                        DataColumn.Caption = MediaBroadcastWorksheetMarketDetailDate.ToString("yyyyMMdd")
                        DataColumn.DataType = GetType(Integer)
                        DataColumn.AllowDBNull = True
                        DataColumn.ReadOnly = IsHiatus

                        ViewModel.SpotDates.Add("Spot" & SpotCounter, CInt(DataColumn.Caption))
                        ViewModel.SpotDateBroadcastYearMonth.Add(CInt(DataColumn.Caption), ViewModel.BroadcastCalendars.Where(Function(D) D.BroadcastWeekStart <= MediaBroadcastWorksheetMarketDetailDate AndAlso
                                                                                                                                          D.BroadcastWeekEnd >= MediaBroadcastWorksheetMarketDetailDate).First.YearMonth)

                        DataColumn = DataTable.Columns.Add("Rate" & SpotCounter)
                        DataColumn.Caption = "Rate"
                        DataColumn.DataType = GetType(Decimal)
                        DataColumn.AllowDBNull = True
                        DataColumn.ReadOnly = IsHiatus

                        SpotCounter += 1

                    End If

                Next

            End If

            DataColumn = DataTable.Columns.Add(StagingDataColumns.TotalSpots.ToString)
            DataColumn.DataType = GetType(Integer)
            DataColumn.AllowDBNull = True

            DataColumn = DataTable.Columns.Add(StagingDataColumns.PrimaryRating.ToString)
            DataColumn.DataType = GetType(Decimal)
            DataColumn.AllowDBNull = True

            DataColumn = DataTable.Columns.Add(StagingDataColumns.PrimaryGRP.ToString)
            DataColumn.DataType = GetType(Decimal)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.PrimaryCPP.ToString)
            DataColumn.DataType = GetType(Decimal)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.PrimaryImpressions.ToString)
            DataColumn.DataType = GetType(Decimal)
            DataColumn.AllowDBNull = True

            DataColumn = DataTable.Columns.Add(StagingDataColumns.PrimaryGIMP.ToString)
            DataColumn.DataType = GetType(Decimal)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.PrimaryCPM.ToString)
            DataColumn.DataType = GetType(Decimal)

            DataColumn = DataTable.Columns.Add(StagingDataColumns.TotalGross.ToString)
            DataColumn.DataType = GetType(Decimal)
            DataColumn.AllowDBNull = True

            DataColumn = DataTable.Columns.Add(StagingDataColumns.IsSubmitted.ToString)
            DataColumn.DataType = GetType(Boolean)

            ViewModel.SpotCount = SpotCounter

            ViewModel.MakegoodDataTable = DataTable

        End Sub
        Public Function Load(MediaBroadcastWorksheetMarketDetailID As Integer, Optional LoadMakegoodsForBuyer As Boolean = False) As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel

            Dim ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel = Nothing
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket = Nothing
            Dim MediaType As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio

            ViewModel = New AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheetMarketDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.Load(DbContext)
                                                       Where Entity.ID = MediaBroadcastWorksheetMarketDetailID
                                                       Select Entity).SingleOrDefault

                If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                    ViewModel.VendorName = MediaBroadcastWorksheetMarketDetail.Vendor.Name

                    ViewModel.MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarketID)
                                                                        Where Entity.VendorCode = MediaBroadcastWorksheetMarketDetail.VendorCode AndAlso
                                                                              Entity.RevisionNumber = MediaBroadcastWorksheetMarketDetail.RevisionNumber
                                                                        Select Entity.ID).Distinct.ToArray

                    ViewModel.OrderNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                             Where ViewModel.MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                   Entity.OrderNumber.HasValue
                                             Select Entity.OrderNumber.Value).FirstOrDefault

                    If (From Entity In AdvantageFramework.Database.Procedures.MediaManagerGeneratedReport.Load(DbContext)
                        Where Entity.OrderNumber = ViewModel.OrderNumber
                        Select Entity).Any Then

                        ViewModel.LineNumbers = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT DISTINCT b.LINE_NBR 
                                                                                                     FROM dbo.MEDIA_MGR_GENERATED_REPORT a
	                                                                                                    INNER JOIN dbo.MEDIA_MGR_GENERATED_REPORT_DETAIL b ON a.MEDIA_MGR_GENERATED_REPORT_ID = b.MEDIA_MGR_GENERATED_REPORT_ID 
                                                                                                     WHERE a.ORDER_NBR = {0}", ViewModel.OrderNumber)).ToArray

                        MediaBroadcastWorksheetMarket = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.ID)

                        If MediaBroadcastWorksheetMarket IsNot Nothing AndAlso MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet IsNot Nothing Then

                            ViewModel.MediaType = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode

                            GetOrderInfo(DbContext, ViewModel.OrderNumber, ViewModel.MediaType, ViewModel)

                            CreateWSDataTable(DbContext, ViewModel.OrderNumber, ViewModel)

                            PopulateWSDataTable(DbContext, ViewModel.OrderNumber, ViewModel, LoadMakegoodsForBuyer)

                            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                If ViewModel.MediaType = "T" Then

                                    MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV

                                End If

                                RefreshGridAdvantage(DataContext, MediaType, ViewModel)

                            End Using

                        End If

                    End If

                End If

            End Using

            Load = ViewModel

        End Function
        Public Function AcceptMakegoodsFromStaging(ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel, ByRef ErrorMessage As String,
                                                   ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel,
                                                   ByRef Refresh As Boolean) As Boolean

            Dim Saved As Boolean = False
            Dim MediaBroadcastWorksheetController As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing
            Dim OriginalDataRow As System.Data.DataRow = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketDetailsMakegoodViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsMakegoodViewModel = Nothing
            Dim RowIndex As Integer = 0
            Dim Daypart As AdvantageFramework.Database.Entities.Daypart = Nothing
            Dim DaysAndTime As AdvantageFramework.DTO.DaysAndTime = Nothing
            Dim RateColumnName As String = String.Empty
            Dim TotalSpots As Integer = 0
            Dim DatesWithRateGreaterThanZeroCount As Integer = 0
            Dim AverageRateAmount As Decimal = 0
            Dim TotalRateAmount As Decimal = 0
            Dim TotalDollars As Decimal = 0
            Dim DaysAndTimeController As AdvantageFramework.Controller.DaysAndTimeController = Nothing
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim NonAiringSpotsDataRow As System.Data.DataRow = Nothing
            Dim LineNumbers As Generic.List(Of Integer) = Nothing

            LineNumbers = New Generic.List(Of Integer)

            For RowCounter As Integer = 0 To ViewModel.MakegoodDataTable.Rows.Count - 1

                If IsNumeric(ViewModel.MakegoodDataTable.Rows(RowCounter).Item("Line")) AndAlso LineNumbers.Contains(CInt(ViewModel.MakegoodDataTable.Rows(RowCounter).Item("Line"))) = False Then

                    LineNumbers.Add(CInt(ViewModel.MakegoodDataTable.Rows(RowCounter).Item("Line")))

                End If

            Next

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If DatesModified(ViewModel) Then

                    ErrorMessage = "Schedule has been modified since vendor submitted makegoods.  Makegoods cannot be applied."

                ElseIf (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext)
                        Where ViewModel.MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                              Entity.IsOriginal = False AndAlso
                              Entity.IsSubmitted = True AndAlso
                              LineNumbers.Contains(Entity.LineNumber) = False
                        Select Entity).Any Then

                    Refresh = True

                Else

                    MediaBroadcastWorksheetController = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

                    MediaBroadcastWorksheetMarketDetailsViewModel.SetAcceptMakegoodMode(ViewModel.OrderNumber, ViewModel.MediaType)
                    MediaBroadcastWorksheetMarketDetailsViewModel.WorksheetLineNumbersAccepted = LineNumbers

                    For Each MediaBroadcastWorksheetMarketDetailID In ViewModel.MediaBroadcastWorksheetMarketDetailIDs

                        For Each MediaBroadcastWorksheetMarketStagingDetail In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketDetailID).Include("MediaBroadcastWorksheetMarketStagingDetailDates")
                                                                                Where Entity.IsOriginal = False AndAlso
                                                                                      Entity.IsSubmitted = True
                                                                                Select Entity).OrderBy(Function(Entity) Entity.MakegoodNumber).ToList

                            OriginalDataRow = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).SingleOrDefault(Function(DR) DR(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.WorksheetMarketDetailID.ToString) = MediaBroadcastWorksheetMarketDetailID)

                            RowIndex = MediaBroadcastWorksheetMarketDetailsViewModel.DataTable.Rows.IndexOf(OriginalDataRow)

                            MediaBroadcastWorksheetMarketDetailsMakegoodViewModel = MediaBroadcastWorksheetController.MarketDetailsMakegood_Load(MediaBroadcastWorksheetMarketDetailsViewModel, RowIndex)

                            NonAiringSpotsDataRow = MediaBroadcastWorksheetMarketDetailsMakegoodViewModel.DataTable.Select("RowType = '" & AdvantageFramework.Media.NonAiringSpots & "'").FirstOrDefault
                            DataRow = MediaBroadcastWorksheetMarketDetailsMakegoodViewModel.DataTable.Select("RowType = '" & AdvantageFramework.Media.NewRow & "'").FirstOrDefault

                            NonAiringSpotsDataRow.BeginEdit()
                            DataRow.BeginEdit()

                            Daypart = DbContext.Dayparts.Where(Function(DP) DP.ID = MediaBroadcastWorksheetMarketStagingDetail.DaypartID).FirstOrDefault

                            DaysAndTime = CType(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString), AdvantageFramework.DTO.DaysAndTime).Clone

                            DaysAndTime.Days = MediaBroadcastWorksheetMarketStagingDetail.Days
                            DaysAndTime.StartTime = MediaBroadcastWorksheetMarketStagingDetail.StartTime
                            DaysAndTime.EndTime = MediaBroadcastWorksheetMarketStagingDetail.EndTime

                            DaysAndTimeController = New AdvantageFramework.Controller.DaysAndTimeController(Me.Session)

                            DaysAndTimeController.ParseDays(DaysAndTime, DaysAndTime.Days, True) 'necessary to check Monday, Tuesday, properties etc.

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DaysAndTime.ToString) = DaysAndTime
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Days.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Days
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.StartTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.StartTime
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.EndTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.EndTime
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Program.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Program
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Daypart.ToString) = If(Daypart IsNot Nothing, Daypart.Code, "")
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Length.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Length
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Comments.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Comments
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ValueAdded.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ValueAdded
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.Bookend.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Bookend
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.DefaultRate.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DefaultRate
                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkStationCode.ToString) = MediaBroadcastWorksheetMarketStagingDetail.CableNetworkStationCode

                            If MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode.HasValue Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.CableNetworkNielsenTVStationCode.ToString) = MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode.Value

                            End If

                            MediaBroadcastWorksheetMarketDetail = DbContext.MediaBroadcastWorksheetMarketDetails.Find(MediaBroadcastWorksheetMarketDetailID)

                            If ViewModel.MediaType = "T" Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions

                            ElseIf ViewModel.MediaType = "R" Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions

                            End If

                            TotalSpots = 0
                            DatesWithRateGreaterThanZeroCount = 0
                            TotalRateAmount = 0
                            TotalDollars = 0

                            For Each MediaBroadcastWorksheetMarketStagingDetailDate In MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketStagingDetailDates

                                If MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.ContainsValue(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(MediaBroadcastWorksheetMarketStagingDetailDate.Date)) AndAlso
                                        MediaBroadcastWorksheetMarketStagingDetailDate.Date >= ViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketStagingDetailDate.Date <= ViewModel.MaxDate Then

                                    NonAiringSpotsDataRow(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(MediaBroadcastWorksheetMarketStagingDetailDate.Date)) = MediaBroadcastWorksheetMarketStagingDetailDate.MakegoodSpots

                                    DataRow(MediaBroadcastWorksheetMarketDetailsViewModel.DetailDates.Item(MediaBroadcastWorksheetMarketStagingDetailDate.Date)) = MediaBroadcastWorksheetMarketStagingDetailDate.Spots

                                    TotalSpots += MediaBroadcastWorksheetMarketStagingDetailDate.Spots

                                    RateColumnName = MediaBroadcastWorksheetMarketDetailsViewModel.RateDates(MediaBroadcastWorksheetMarketStagingDetailDate.Date)

                                    DataRow(RateColumnName) = MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                    If MediaBroadcastWorksheetMarketStagingDetailDate.Rate > 0 Then

                                        DatesWithRateGreaterThanZeroCount += 1

                                    End If

                                    TotalRateAmount += MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                    TotalDollars += (MediaBroadcastWorksheetMarketStagingDetailDate.Rate * CDec(MediaBroadcastWorksheetMarketStagingDetailDate.Spots))

                                End If

                            Next

                            'see MediaBroadcastWorksheetController - MarketDetails_RefreshColumnTotalsDataTable for the following definitions

                            If ViewModel.MediaType = "T" Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString) = TotalSpots * DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString)
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString) = (TotalSpots * DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString))
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString) = MediaBroadcastWorksheetController.CalculateCumlessReach(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString), TotalSpots)

                            ElseIf ViewModel.MediaType = "R" Then

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString) = TotalSpots * DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString)
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString) = (TotalSpots * DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQH.ToString))
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryReach.ToString) = MediaBroadcastWorksheetController.CalculateCumlessReach(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryAQHRating.ToString), TotalSpots)

                            End If

                            If TotalSpots = 0 Then

                                If DatesWithRateGreaterThanZeroCount > 0 Then

                                    AverageRateAmount = TotalRateAmount / DatesWithRateGreaterThanZeroCount

                                Else

                                    AverageRateAmount = 0

                                End If

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString) = 0, 0, Math.Round(AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryRating.ToString), 2))
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString) <> 0, Math.Round((AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryImpressions.ToString)) * 1000, 2), 0)

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString) = 0, 0, Math.Round(TotalDollars / DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGRP.ToString), 2))
                                DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryCPM.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString) <> 0, Math.Round((TotalDollars / DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.PrimaryGrossImpressions.ToString)) * 1000, 2), 0)

                            End If

                            DataRow.EndEdit()
                            NonAiringSpotsDataRow.EndEdit()

                            MediaBroadcastWorksheetController.MarketDetailsMakegood_Makegood(MediaBroadcastWorksheetMarketDetailsMakegoodViewModel, MediaBroadcastWorksheetMarketDetailsViewModel, True)

                        Next

                    Next

                    Saved = True

                End If

            End Using

            AcceptMakegoodsFromStaging = Saved

        End Function
        Public Sub PopulateWSDataTable(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel,
                                       LoadMakegoodsForBuyer As Boolean)

            'objects
            Dim MediaBroadcastWorksheetMarketDetailIDs As Generic.List(Of Integer) = Nothing
            Dim RatingsServiceID As Nullable(Of Integer) = Nothing
            Dim Dayparts As Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate) = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail) = Nothing
            Dim SpotColumnCounter As Integer = 0
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim TotalSpots As Integer = 0
            Dim MediaBroadcastWorksheetMarketStagingDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim OriginalDataRow As System.Data.DataRow = Nothing
            Dim RevisedDataRow As System.Data.DataRow = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataTableForOriginalSums As System.Data.DataTable = Nothing
            Dim DatesWithRateGreaterThanZeroCount As Integer = 0
            Dim AverageRateAmount As Decimal = 0
            Dim TotalRateAmount As Decimal = 0
            Dim TotalDollars As Decimal = 0
            Dim BuyerLineNumbers As IEnumerable(Of Integer) = Nothing
            Dim RateDiffers As Boolean = False
            Dim DetailDate As Date = Nothing
            Dim TotalNonAiringDataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim TotalGross As Decimal = 0
            Dim MakegoodNumber As Integer = 0
            Dim MadegoodNumber As Integer = 0
            Dim MediaBroadcastWorksheetMarketDetailDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate = Nothing

            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetails")
                                                      Where Entity.OrderNumber = OrderNumber AndAlso
                                                            Entity.MediaBroadcastWorksheetMarketDetail.RevisionNumber = MakegoodDeliveryViewModel.MaxRevisionNumber AndAlso
                                                            Entity.OrderLineNumber IsNot Nothing AndAlso
                                                            MakegoodDeliveryViewModel.LineNumbers.Contains(Entity.OrderLineNumber)
                                                      Select Entity.MediaBroadcastWorksheetMarketDetailID).Distinct.ToList

            If MediaBroadcastWorksheetMarketDetailIDs IsNot Nothing AndAlso MediaBroadcastWorksheetMarketDetailIDs.Count > 0 Then

                If MakegoodDeliveryViewModel.MediaType = "T" Then

                    RatingsServiceID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 COALESCE(MBW.RATINGS_SERVICE_ID, -1) FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET] MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID WHERE SHAREBOOK_NIELSEN_TV_BOOK_ID IS NOT NULL AND ORDER_NBR = {0}", OrderNumber)).FirstOrDefault

                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList

                    TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If TVOrder IsNot Nothing AndAlso TVOrder.Vendor IsNot Nothing Then

                        If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not TVOrder.Vendor.IsNielsenSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

                        ElseIf RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not TVOrder.Vendor.IsComscoreSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " Comscore"

                        End If

                    End If

                ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                    RatingsServiceID = DbContext.Database.SqlQuery(Of Integer)(String.Format("Select Top 1 COALESCE(CAST(MBWM.EXTERNAL_RADIO_SOURCE As int), -1) From [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                            "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                            "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID  " &
                            "WHERE NIELSEN_RADIO_PERIOD_ID1 IS NOT NULL AND ORDER_NBR = {0}", OrderNumber)).FirstOrDefault

                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList

                    RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If RadioOrder IsNot Nothing AndAlso RadioOrder.Vendor IsNot Nothing Then

                        If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not RadioOrder.Vendor.IsNielsenSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

                        ElseIf RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                            MakegoodDeliveryViewModel.SuppressRatings = False
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " EASTLAN"

                        End If

                    End If

                End If

                If MakegoodDeliveryViewModel.IsOriginalOrderMode Then

                    DataTable = BuildOriginalDataTable(DbContext, MediaBroadcastWorksheetMarketDetailIDs, MakegoodDeliveryViewModel, MakegoodDeliveryViewModel.MakegoodDataTable, Dayparts)

                Else

                    DataTable = MakegoodDeliveryViewModel.MakegoodDataTable.Clone

                    DataTable.BeginLoadData()

                    CreateStagingRows(DbContext, MediaBroadcastWorksheetMarketDetailIDs, MakegoodDeliveryViewModel)

                    If LoadMakegoodsForBuyer Then

                        BuyerLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext)
                                            Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                  Entity.IsOriginal = False AndAlso
                                                  Entity.IsSubmitted = True
                                            Select Entity.LineNumber).Distinct.ToArray

                        MediaBroadcastWorksheetMarketStagingDetails = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext)
                                                                       Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                                             BuyerLineNumbers.Contains(Entity.LineNumber)
                                                                       Select Entity).OrderBy(Function(Entity) Entity.LineNumber).ThenBy(Function(Entity) Entity.MakegoodNumber).ToList

                        DataTableForOriginalSums = BuildOriginalDataTable(DbContext, MediaBroadcastWorksheetMarketStagingDetails.Select(Function(SD) SD.MediaBroadcastWorksheetMarketDetailID).Distinct.ToArray, MakegoodDeliveryViewModel, MakegoodDeliveryViewModel.MakegoodDataTable, Dayparts)

                    Else

                        MediaBroadcastWorksheetMarketStagingDetails = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext)
                                                                       Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                                       Select Entity).OrderBy(Function(Entity) Entity.LineNumber).ThenBy(Function(Entity) Entity.MakegoodNumber).ToList

                        DataTableForOriginalSums = BuildOriginalDataTable(DbContext, MediaBroadcastWorksheetMarketDetailIDs, MakegoodDeliveryViewModel, MakegoodDeliveryViewModel.MakegoodDataTable, Dayparts)

                    End If

                    For Each MediaBroadcastWorksheetMarketStagingDetail In MediaBroadcastWorksheetMarketStagingDetails

                        MakegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber
                        MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MadegoodNumber

                        MediaBroadcastWorksheetMarketDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.Load(DbContext)
                                                               Where Entity.ID = MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID
                                                               Select Entity).SingleOrDefault

                        If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                            DataRow = DataTable.NewRow

                            SpotColumnCounter = 0

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ID

                            If MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = System.DBNull.Value

                            ElseIf (From Entity In MediaBroadcastWorksheetMarketStagingDetails
                                    Where MediaBroadcastWorksheetMarketDetailIDs.Contains(MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                          Entity.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber AndAlso
                                          Entity.MakegoodNumber = 0
                                    Select Entity).Count = 1 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = (From Entity In MediaBroadcastWorksheetMarketStagingDetails
                                                                                                                                                Where MediaBroadcastWorksheetMarketDetailIDs.Contains(MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                                                                                                                      Entity.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber AndAlso
                                                                                                                                                      Entity.MakegoodNumber = 0
                                                                                                                                                Select Entity).Single.ID

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = System.DBNull.Value

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0") & If(MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0, "", "-" & MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber.ToString.PadLeft(2, "0"))
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = MediaBroadcastWorksheetMarketStagingDetail.IsOriginal
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetwork.ToString) = MediaBroadcastWorksheetMarketStagingDetail.CableNetworkStationCode
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetworkCode.ToString) = If(MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode Is Nothing, System.DBNull.Value, MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode)
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Days.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Days
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.StartTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.StartTime
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.EndTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.EndTime
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Program.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Program

                            If MediaBroadcastWorksheetMarketStagingDetail.DaypartID.HasValue Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartID.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DaypartID

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Length.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Length
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Bookend
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ValueAdded
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Comments.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Comments
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DefaultRate

                            If MediaBroadcastWorksheetMarketStagingDetail.DaypartID.HasValue AndAlso MediaBroadcastWorksheetMarketStagingDetail.DaypartID.Value > 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString) = Dayparts.Where(Function(Entity) Entity.ID = MediaBroadcastWorksheetMarketStagingDetail.DaypartID.Value).FirstOrDefault.Description

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString) = String.Empty

                            End If

                            TotalSpots = 0
                            DatesWithRateGreaterThanZeroCount = 0
                            TotalRateAmount = 0
                            TotalDollars = 0

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0

                            RateDiffers = False

                            For Each MediaBroadcastWorksheetMarketStagingDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.ID)
                                                                                        Select Entity).OrderBy(Function(E) E.Date).ToList

                                If MediaBroadcastWorksheetMarketStagingDetailDate.Date >= MakegoodDeliveryViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketStagingDetailDate.Date <= MakegoodDeliveryViewModel.MaxDate AndAlso
                                        DataTable.Columns.Contains("Spot" & SpotColumnCounter) Then

                                    If MediaBroadcastWorksheetMarketStagingDetailDate.IsHiatus Then

                                        DataRow("Spot" & SpotColumnCounter) = System.DBNull.Value
                                        DataRow("Rate" & SpotColumnCounter) = System.DBNull.Value

                                    Else

                                        If LoadMakegoodsForBuyer Then

                                            DataRow("Spot" & SpotColumnCounter) = 0

                                            If MediaBroadcastWorksheetMarketStagingDetail.IsOriginal Then

                                                MediaBroadcastWorksheetMarketDetailDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID)
                                                                                           Where Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                                                                                           Select Entity).SingleOrDefault

                                                If MediaBroadcastWorksheetMarketDetailDate IsNot Nothing Then

                                                    DataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketDetailDate.Spots

                                                End If

                                                MediaBroadcastWorksheetMarketDetailDateMakegoods = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                                                    Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                                                                          Entity.MediaBroadcastWorksheetMarketDetail.LineNumber = MediaBroadcastWorksheetMarketStagingDetail.LineNumber
                                                                                                    Select Entity).ToList

                                                If MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                                       DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MakegoodNumber).Any Then

                                                    DataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                                                                               DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MakegoodNumber).Sum(Function(DD) DD.MakegoodSpots)

                                                    'Else

                                                    '    MediaBroadcastWorksheetMarketDetailDate = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.LoadByMediaBroadcastWorksheetMarketDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID)
                                                    '                                               Where Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                                                    '                                               Select Entity).SingleOrDefault

                                                    '    If MediaBroadcastWorksheetMarketDetailDate IsNot Nothing Then

                                                    '        DataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketDetailDate.Spots

                                                    '    End If

                                                    '    DataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketStagingDetailDate.Spots

                                                End If

                                            Else

                                                DataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketStagingDetailDate.Spots

                                            End If

                                        Else

                                            DataRow("Spot" & SpotColumnCounter) = MediaBroadcastWorksheetMarketStagingDetailDate.Spots

                                        End If

                                        DataRow("Rate" & SpotColumnCounter) = MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                        If MediaBroadcastWorksheetMarketStagingDetailDate.Rate > 0 Then

                                            DatesWithRateGreaterThanZeroCount += 1

                                        End If

                                        If RateDiffers = False AndAlso MediaBroadcastWorksheetMarketStagingDetail.DefaultRate <> MediaBroadcastWorksheetMarketStagingDetailDate.Rate Then

                                            RateDiffers = True

                                        End If

                                        TotalRateAmount += MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                        TotalDollars += (MediaBroadcastWorksheetMarketStagingDetailDate.Rate * DataRow("Spot" & SpotColumnCounter))

                                        TotalSpots += DataRow("Spot" & SpotColumnCounter)

                                    End If

                                    SpotColumnCounter += 1

                                End If

                            Next

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RateDiffersFlag.ToString) = RateDiffers

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalSpots
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = TotalDollars

                            If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                                MakegoodDeliveryViewModel.PrimaryDemographic = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.Description

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = TotalSpots * DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString)

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots

                            If TotalSpots = 0 Then

                                If DatesWithRateGreaterThanZeroCount > 0 Then

                                    AverageRateAmount = TotalRateAmount / DatesWithRateGreaterThanZeroCount

                                Else

                                    AverageRateAmount = 0

                                End If

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = 0, 0, Math.Round(AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString), 2))
                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) <> 0, Math.Round((AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString)), 2), 0)

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0, 0, Math.Round(TotalDollars / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString), 2))

                                If MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots = 0 Then

                                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                                Else

                                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = Math.Round((TotalDollars / (MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots) * 1000), 2)

                                End If

                            End If

                        End If

                        If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = True Then

                            If LoadMakegoodsForBuyer AndAlso MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Original spots"

                            ElseIf LoadMakegoodsForBuyer AndAlso MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber > 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Makegood"

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Ordered spots"

                            End If

                        Else

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Makegood"

                        End If

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsSubmitted.ToString) = MediaBroadcastWorksheetMarketStagingDetail.IsSubmitted

                        DataTable.Rows.Add(DataRow)

                        If LoadMakegoodsForBuyer AndAlso MediaBroadcastWorksheetMarketStagingDetail.IsOriginal Then

                            AddNonAiringRowForBuyer(DbContext, DataTable, MediaBroadcastWorksheetMarketStagingDetail, MediaBroadcastWorksheetMarketStagingDetails, MakegoodDeliveryViewModel, MediaBroadcastWorksheetMarketDetailIDs)

                        End If

                        If LoadMakegoodsForBuyer AndAlso (MediaBroadcastWorksheetMarketStagingDetails.IndexOf(MediaBroadcastWorksheetMarketStagingDetail) = MediaBroadcastWorksheetMarketStagingDetails.Count - 1 OrElse
                                MediaBroadcastWorksheetMarketStagingDetails(MediaBroadcastWorksheetMarketStagingDetails.IndexOf(MediaBroadcastWorksheetMarketStagingDetail)).LineNumber <> MediaBroadcastWorksheetMarketStagingDetails(MediaBroadcastWorksheetMarketStagingDetails.IndexOf(MediaBroadcastWorksheetMarketStagingDetail) + 1).LineNumber) Then

                            'add variance row
                            DataRow = DataTable.NewRow

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -MediaBroadcastWorksheetMarketStagingDetail.ID - 9000
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                            DataRow.SetField(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString, "Variance")

                            SpotColumnCounter = 0
                            TotalSpots = 0

                            If LoadMakegoodsForBuyer Then

                                MediaBroadcastWorksheetMarketStagingDetailIDs = (From Entity In MediaBroadcastWorksheetMarketStagingDetails
                                                                                 Where Entity.MakegoodNumber <> 0 AndAlso
                                                                                       Entity.LineNumber = MediaBroadcastWorksheetMarketStagingDetail.LineNumber
                                                                                 Select Entity.ID).ToArray

                            End If

                            For Each MediaBroadcastWorksheetMarketStagingDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.ID)
                                                                                        Select Entity).OrderBy(Function(E) E.Date).ToList

                                Dim NonAiringSpots As Integer = DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso IsDBNull(DR("Spot" & SpotColumnCounter)) = False AndAlso
                                                                                                                                 DR("RowType") = "Non-Airing" AndAlso DR("Line").ToString.Substring(0, 4) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")).Select(Function(DR) CInt(DR("Spot" & SpotColumnCounter))).Sum()

                                DataRow("Spot" & SpotColumnCounter) = DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso IsDBNull(DR("Spot" & SpotColumnCounter)) = False AndAlso
                                                                                                                                   DR("RowType") = "Makegood" AndAlso DR("Line").ToString.Substring(0, 4) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")).Select(Function(DR) CInt(DR("Spot" & SpotColumnCounter))).Sum() + NonAiringSpots

                                TotalSpots += DataRow("Spot" & SpotColumnCounter)

                                SpotColumnCounter += 1

                            Next

                            DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString) = TotalSpots

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) =
                                DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Non-Airing" AndAlso DR("Line").ToString.Substring(0, 4) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")).Select(Function(DR) CDec(DR("TotalGross"))).Sum() +
                                DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Makegood" AndAlso DR("Line").ToString.Substring(0, 4) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")).Select(Function(DR) CDec(DR("TotalGross"))).Sum()

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) =
                                DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Non-Airing" AndAlso DR("Line").ToString.Substring(0, 4) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")).Select(Function(DR) CDec(DR("PrimaryGRP"))).Sum() +
                                DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Makegood" AndAlso DR("Line").ToString.Substring(0, 4) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")).Select(Function(DR) CDec(DR("PrimaryGRP"))).Sum()

                            If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) =
                                DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Non-Airing" AndAlso DR("Line").ToString.Substring(0, 4) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")).Select(Function(DR) CDec(DR("PrimaryGIMP"))).Sum() +
                                DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Makegood" AndAlso DR("Line").ToString.Substring(0, 4) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")).Select(Function(DR) CDec(DR("PrimaryGIMP"))).Sum()

                            If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000 * -1

                            End If

                            DataTable.Rows.Add(DataRow)

                        End If

                    Next

                    'add original row
                    OriginalDataRow = DataTable.NewRow

                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -1
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Total Original:"
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = DataTableForOriginalSums.Compute("Sum(TotalSpots)", "ID > 0")
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = DataTableForOriginalSums.Compute("Sum(PrimaryGRP)", "ID > 0")
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = DataTableForOriginalSums.Compute("Sum(TotalGross)", "ID > 0")

                    If MakegoodDeliveryViewModel.MediaType = "T" Then

                        If DataTableForOriginalSums.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) IsNot DBNull.Value AndAlso
                                                                                                           DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) > 0 AndAlso
                                                                                                           DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) > 0).Any Then

                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = DataTableForOriginalSums.Compute("Sum(PrimaryGIMP)", "ID > 0") * 1000

                        End If

                    ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                        If DataTableForOriginalSums.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) IsNot DBNull.Value AndAlso
                                                                                                           DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) > 0 AndAlso
                                                                                                           DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) > 0).Any Then

                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = DataTableForOriginalSums.Compute("Sum(PrimaryGIMP)", "ID > 0") * 100

                        End If

                    End If

                    If OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) OrElse
                                OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Equals(System.DBNull.Value) OrElse
                                OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000

                        End If

                    End If

                    If OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) OrElse
                                OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString).Equals(System.DBNull.Value) OrElse
                                OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                        OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    For SpotColumnCounter = 0 To MakegoodDeliveryViewModel.SpotCount - 1

                        OriginalDataRow("Spot" & SpotColumnCounter) =
                            DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso IsDBNull(DR("Spot" & SpotColumnCounter)) = False AndAlso
                                                                                             DR("RowType") = "Original spots").Select(Function(DR) CInt(DR("Spot" & SpotColumnCounter))).Sum()

                        'OriginalDataRow("Spot" & SpotColumnCounter) = DataTableForOriginalSums.Compute("Sum(Spot" & SpotColumnCounter & ")", "ID > 0 AND MakegoodNumber = 0")

                        If OriginalDataRow("Spot" & SpotColumnCounter).Equals(System.DBNull.Value) Then

                            OriginalDataRow("Spot" & SpotColumnCounter) = 0

                        End If

                    Next

                    DataTable.Rows.Add(OriginalDataRow)

                    'add total non-airing row
                    TotalNonAiringDataRow = DataTable.NewRow

                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -2
                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Total Non-Airing:"
                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    For SpotColumnCounter = 0 To MakegoodDeliveryViewModel.SpotCount - 1

                        If OriginalDataRow("Spot" & SpotColumnCounter).Equals(System.DBNull.Value) Then

                            TotalNonAiringDataRow("Spot" & SpotColumnCounter) = 0

                        Else

                            TotalNonAiringDataRow("Spot" & SpotColumnCounter) = DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Non-Airing" AndAlso IsDBNull(DR("Spot" & SpotColumnCounter)) = False).Select(Function(DR) CInt(DR("Spot" & SpotColumnCounter))).Sum()

                        End If

                    Next

                    TotalSpots = 0
                    TotalGross = 0

                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) =
                        DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Non-Airing").Select(Function(DR) CInt(DR("TotalSpots"))).Sum()

                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) =
                        DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Non-Airing").Select(Function(DR) CDec(DR("TotalGross"))).Sum()

                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) =
                        DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Non-Airing").Select(Function(DR) CDec(DR("PrimaryGRP"))).Sum()

                    TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) =
                        DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Non-Airing").Select(Function(DR) CDec(DR("PrimaryGIMP"))).Sum()

                    If TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString).Equals(System.DBNull.Value) OrElse
                            TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                        TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                       TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) * -1

                    End If

                    If TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Equals(System.DBNull.Value) OrElse
                            TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                           TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000 * -1

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                           TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000 * -1

                        End If

                    End If

                    DataTable.Rows.Add(TotalNonAiringDataRow)

                    'add revised row
                    RevisedDataRow = DataTable.NewRow

                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -3
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Total Makegood:"
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    TotalSpots = 0
                    TotalGross = 0

                    MediaBroadcastWorksheetMarketStagingDetailIDs = MediaBroadcastWorksheetMarketStagingDetails.Where(Function(D) D.IsOriginal = False).Select(Function(D) D.ID).Distinct.ToArray

                    If MediaBroadcastWorksheetMarketStagingDetailIDs IsNot Nothing AndAlso MediaBroadcastWorksheetMarketStagingDetailIDs.Count > 0 Then

                        For SpotColumnCounter = 0 To MakegoodDeliveryViewModel.SpotCount - 1

                            DetailDate = ConvertToDate(MakegoodDeliveryViewModel.SpotDates.Values(SpotColumnCounter).ToString)

                            If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                                      Entity.Date = DetailDate AndAlso
                                      Entity.IsHiatus = True
                                Select Entity).Any = True Then

                                RevisedDataRow("Spot" & SpotColumnCounter) = 0

                            Else

                                'RevisedDataRow("Spot" & SpotColumnCounter) = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                '                                              Where Entity.Date = DetailDate AndAlso
                                '                                                    MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID)
                                '                                              Select Entity.Spots).Sum()

                                'TotalGross += (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                '               Where Entity.Date = DetailDate AndAlso
                                '                     MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID)
                                '               Select Entity.Spots * Entity.Rate).Sum()

                                'TotalSpots += RevisedDataRow("Spot" & SpotColumnCounter)

                                RevisedDataRow("Spot" & SpotColumnCounter) =
                                    DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso
                                                                                                     DR("RowType") = "Makegood" AndAlso
                                                                                                     IsDBNull(DR("Spot" & SpotColumnCounter)) = False).Select(Function(DR) CInt(DR("Spot" & SpotColumnCounter))).Sum()

                            End If

                        Next

                    End If

                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) =
                                DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Makegood").Select(Function(DR) CInt(DR("TotalSpots"))).Sum()

                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) =
                                DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso DR("RowType") = "Makegood").Select(Function(DR) CDec(DR("TotalGross"))).Sum()

                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = DataTable.Compute("Sum(PrimaryGRP)", "RowType = 'Makegood'")
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = DataTable.Compute("Sum(PrimaryGIMP)", "RowType = 'Makegood'")

                    If IsDBNull(RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)) OrElse
                            RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                        RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    If IsDBNull(RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString)) OrElse
                            RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000

                        End If

                    End If

                    DataTable.Rows.Add(RevisedDataRow)

                    'add change row
                    DataRow = DataTable.NewRow

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -4
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Total Variance:"
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    For SpotColumnCounter = 0 To MakegoodDeliveryViewModel.SpotCount - 1

                        If TotalNonAiringDataRow("Spot" & SpotColumnCounter).Equals(System.DBNull.Value) OrElse RevisedDataRow("Spot" & SpotColumnCounter).Equals(System.DBNull.Value) Then

                            DataRow("Spot" & SpotColumnCounter) = 0

                        Else

                            DataRow("Spot" & SpotColumnCounter) = TotalNonAiringDataRow("Spot" & SpotColumnCounter) + RevisedDataRow("Spot" & SpotColumnCounter)

                        End If

                    Next

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalNonAiringDataRow("TotalSpots") + RevisedDataRow("TotalSpots")

                    If RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) OrElse
                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) + RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString)

                    End If

                    If RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString).Equals(System.DBNull.Value) OrElse
                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString).Equals(System.DBNull.Value) Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) + RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    If RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Equals(System.DBNull.Value) OrElse
                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Equals(System.DBNull.Value) Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = TotalNonAiringDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) + RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString)

                    End If

                    If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000 * -1

                    End If

                    DataTable.Rows.Add(DataRow)

                    DataTable.Columns.Remove("MakegoodNumber")

                    DataTable.EndLoadData()

                End If

            End If

            MakegoodDeliveryViewModel.MakegoodDataTable = DataTable.DefaultView.ToTable

        End Sub
        Public Sub GetOrderInfo(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MediaFrom As String, ByRef MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel)

            'objects
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim RadioOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.RadioOrderDetail) = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim TVOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.TVOrderDetail) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim NCCTVSyscode As AdvantageFramework.Nielsen.Database.Entities.NCCTVSyscode = Nothing
            Dim NielsenRadioStation As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation = Nothing
            Dim NielsenTVStation As AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation = Nothing
            Dim NielsenMarketNumber As Nullable(Of Integer) = Nothing
            Dim WorksheetMarketDetailVendorMakegoodStatuses As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendorMakegoodStatus) = Nothing
            Dim LineNumbers As IEnumerable(Of Short) = Nothing
            Dim ClientName As String = Nothing
            Dim DivisionName As String = Nothing
            Dim MediaBroadcastWorksheetMarketID As Integer = 0
            Dim MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet = Nothing

            LineNumbers = MakegoodDeliveryViewModel.LineNumbers.ToArray

            If MediaFrom.ToUpper.StartsWith("R") Then

                RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If RadioOrder IsNot Nothing Then

                    MakegoodDeliveryViewModel.MediaType = "R"
                    MakegoodDeliveryViewModel.AlertID = RadioOrder.AlertID
                    MakegoodDeliveryViewModel.OrderPlaced = RadioOrder.CreatedDate
                    MakegoodDeliveryViewModel.VendorIsCableSystem = False
                    MakegoodDeliveryViewModel.NetGross = RadioOrder.NetGross.GetValueOrDefault(0)

                    If RadioOrder.OrderProcessControl.GetValueOrDefault(1) <> 1 Then

                        MakegoodDeliveryViewModel.InDifferentOrderState = True

                    End If

                    If String.IsNullOrWhiteSpace(RadioOrder.BuyerEmployeeCode) = False Then

                        Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.Code = RadioOrder.BuyerEmployeeCode)

                    ElseIf String.IsNullOrWhiteSpace(RadioOrder.Buyer) = False Then

                        Try

                            Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.FirstName & " " & Entity.LastName = RadioOrder.Buyer)

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                    End If

                    MakegoodDeliveryViewModel.OrderComments = RadioOrder.OrderComment

                    ClientName = RadioOrder.Product.Client.Name & ""
                    DivisionName = RadioOrder.Product.Division.Name & ""

                    If ClientName.ToUpper = DivisionName.ToUpper Then

                        MakegoodDeliveryViewModel.ClientName = ClientName

                    ElseIf ClientName.Trim = "" Then

                        MakegoodDeliveryViewModel.ClientName = DivisionName

                    ElseIf DivisionName.Trim = "" Then

                        MakegoodDeliveryViewModel.ClientName = ClientName

                    Else

                        MakegoodDeliveryViewModel.ClientName = ClientName & "/" & DivisionName

                    End If

                    MakegoodDeliveryViewModel.ProductName = RadioOrder.Product.Name & ""

                    RadioOrderDetails = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                         Where LineNumbers.Contains(Entity.LineNumber)
                                         Select Entity).ToList

                    'MakegoodDeliveryViewModel.FlightDates = RadioOrderDetails.Min(Function(Entity) Entity.StartDate.Value).ToShortDateString() & " - " & RadioOrderDetails.Max(Function(Entity) Entity.EndDate.Value).ToShortDateString()

                    If (From Entity In RadioOrderDetails
                        Where Entity.RevisionNumber > 0).Any Then

                        MakegoodDeliveryViewModel.RevisedString = "(Revised)"

                    End If

                End If

                If RadioOrder.Market IsNot Nothing Then

                    MakegoodDeliveryViewModel.MarketDescription = RadioOrder.Market.Description

                    If IsNumeric(RadioOrder.Market.NielsenRadioCode) Then

                        NielsenMarketNumber = RadioOrder.Market.NielsenRadioCode

                    End If

                End If

                If Session.IsNielsenSetup Then

                    Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                        If RadioOrder.Vendor.NielsenRadioStationComboID.HasValue AndAlso NielsenMarketNumber.HasValue Then

                            NielsenRadioStation = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByNielsenRadioMarketNumberRadioSource(NielsenDbContext, NielsenMarketNumber.Value, AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen)
                                                   Where Entity.ComboID = RadioOrder.Vendor.NielsenRadioStationComboID.Value
                                                   Select Entity).FirstOrDefault

                            If NielsenRadioStation IsNot Nothing Then

                                MakegoodDeliveryViewModel.StationName = NielsenRadioStation.CallLetters & "-" & NielsenRadioStation.Band

                            End If

                        ElseIf RadioOrder.Vendor.EastlanRadioStationComboID.HasValue AndAlso NielsenMarketNumber.HasValue Then

                            NielsenRadioStation = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioStation.LoadByNielsenRadioMarketNumberRadioSource(NielsenDbContext, NielsenMarketNumber.Value, AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan)
                                                   Where Entity.ComboID = RadioOrder.Vendor.EastlanRadioStationComboID.Value
                                                   Select Entity).FirstOrDefault

                            If NielsenRadioStation IsNot Nothing Then

                                MakegoodDeliveryViewModel.StationName = NielsenRadioStation.CallLetters & "-" & NielsenRadioStation.Band

                            End If

                        End If

                    End Using

                End If

                If String.IsNullOrWhiteSpace(MakegoodDeliveryViewModel.StationName) Then

                    MakegoodDeliveryViewModel.StationName = RadioOrder.Vendor.Name

                End If

                If Not String.IsNullOrWhiteSpace(MakegoodDeliveryViewModel.MarketDescription) Then

                    MakegoodDeliveryViewModel.StationName += " (" & MakegoodDeliveryViewModel.MarketDescription & ")"

                End If

            ElseIf MediaFrom.ToUpper.StartsWith("T") Then

                TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                If TVOrder IsNot Nothing Then

                    MakegoodDeliveryViewModel.MediaType = "T"
                    MakegoodDeliveryViewModel.AlertID = TVOrder.AlertID
                    MakegoodDeliveryViewModel.OrderPlaced = TVOrder.CreatedDate
                    MakegoodDeliveryViewModel.VendorIsCableSystem = TVOrder.Vendor.IsCableSystem
                    MakegoodDeliveryViewModel.NetGross = TVOrder.NetGross.GetValueOrDefault(0)

                    If TVOrder.OrderProcessControl.GetValueOrDefault(1) <> 1 Then

                        MakegoodDeliveryViewModel.InDifferentOrderState = True

                    End If

                    If String.IsNullOrWhiteSpace(TVOrder.BuyerEmployeeCode) = False Then

                        Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.Code = TVOrder.BuyerEmployeeCode)

                    ElseIf String.IsNullOrWhiteSpace(TVOrder.Buyer) = False Then

                        Try

                            Employee = DbContext.Employees.SingleOrDefault(Function(Entity) Entity.FirstName & " " & Entity.LastName = TVOrder.Buyer)

                        Catch ex As Exception
                            Employee = Nothing
                        End Try

                    End If

                    MakegoodDeliveryViewModel.OrderComments = TVOrder.OrderComment

                    ClientName = TVOrder.Product.Client.Name & ""
                    DivisionName = TVOrder.Product.Division.Name & ""

                    If ClientName.ToUpper = DivisionName.ToUpper Then

                        MakegoodDeliveryViewModel.ClientName = ClientName

                    ElseIf ClientName.Trim = "" Then

                        MakegoodDeliveryViewModel.ClientName = DivisionName

                    ElseIf DivisionName.Trim = "" Then

                        MakegoodDeliveryViewModel.ClientName = ClientName

                    Else

                        MakegoodDeliveryViewModel.ClientName = ClientName & "/" & DivisionName

                    End If

                    MakegoodDeliveryViewModel.ProductName = TVOrder.Product.Name & ""

                    TVOrderDetails = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, OrderNumber)
                                      Where LineNumbers.Contains(Entity.LineNumber)
                                      Select Entity).ToList

                    'MakegoodDeliveryViewModel.FlightDates = TVOrderDetails.Min(Function(Entity) Entity.StartDate.Value).ToShortDateString() & " - " & TVOrderDetails.Max(Function(Entity) Entity.EndDate.Value).ToShortDateString()

                    If (From Entity In TVOrderDetails
                        Where Entity.RevisionNumber > 0).Any Then

                        MakegoodDeliveryViewModel.RevisedString = "(Revised)"

                    End If

                    If TVOrder.Market IsNot Nothing Then

                        MakegoodDeliveryViewModel.MarketDescription = TVOrder.Market.Description

                        If IsNumeric(TVOrder.Market.NielsenTVCode) Then

                            NielsenMarketNumber = TVOrder.Market.NielsenTVCode

                        End If

                    End If

                    If Session.IsNielsenSetup Then

                        Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            If TVOrder.Vendor.IsCableSystem AndAlso TVOrder.Vendor.NCCTVSyscodeID.HasValue Then

                                NCCTVSyscode = AdvantageFramework.Nielsen.Database.Procedures.NCCTVSyscode.LoadByID(NielsenDbContext, TVOrder.Vendor.NCCTVSyscodeID.Value)

                                If NCCTVSyscode IsNot Nothing Then

                                    MakegoodDeliveryViewModel.StationName = NCCTVSyscode.SystemName

                                End If

                            ElseIf TVOrder.Vendor.NielsenTVStationCode.HasValue AndAlso NielsenMarketNumber.HasValue Then

                                NielsenTVStation = (From Entity In AdvantageFramework.Nielsen.Database.Procedures.NielsenTVStation.LoadByNielsenMarketNumber(NielsenDbContext, NielsenMarketNumber.Value)
                                                    Where Entity.StationCode = TVOrder.Vendor.NielsenTVStationCode.Value
                                                    Select Entity).FirstOrDefault

                                If NielsenTVStation IsNot Nothing Then

                                    MakegoodDeliveryViewModel.StationName = NielsenTVStation.CallLetters

                                End If

                            End If

                        End Using

                    End If

                    If String.IsNullOrWhiteSpace(MakegoodDeliveryViewModel.StationName) Then

                        MakegoodDeliveryViewModel.StationName = TVOrder.Vendor.Name

                    End If

                    If Not String.IsNullOrWhiteSpace(MakegoodDeliveryViewModel.MarketDescription) Then

                        MakegoodDeliveryViewModel.StationName += " (" & MakegoodDeliveryViewModel.MarketDescription & ")"

                    End If

                End If

            End If

            If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                Where Entity.OrderNumber = OrderNumber
                Select Entity.MediaBroadcastWorksheetMarketDetail).Any Then

                MediaBroadcastWorksheetMarketID = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                   Where Entity.OrderNumber = OrderNumber
                                                   Select Entity.MediaBroadcastWorksheetMarketDetail).FirstOrDefault.MediaBroadcastWorksheetMarketID

                MakegoodDeliveryViewModel.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID

                MakegoodDeliveryViewModel.MaxRevisionNumber = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.Load(DbContext)
                                                               Where Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                                                               Select Entity.RevisionNumber).Max

                WorksheetMarketDetailVendorMakegoodStatuses = (From Entity In DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailVendorMakegoodStatus)(String.Format("exec [dbo].[advsp_makegood_vendor_status] {0}, {1}", MakegoodDeliveryViewModel.MediaBroadcastWorksheetMarketID, MakegoodDeliveryViewModel.MaxRevisionNumber)).ToList
                                                               Where Entity.OrderNumber = OrderNumber).ToList

                If (From Entity In WorksheetMarketDetailVendorMakegoodStatuses
                    Where Entity.OrderNumber = OrderNumber
                    Select Entity.Status).Distinct.Count = 1 Then

                    'If WorksheetMarketDetailVendorMakegoodStatuses.Where(Function(Entity) Entity.OrderNumber = OrderNumber).First.Status = Database.Entities.Methods.OrderStatusType.MakegoodOfferSubmitted Then

                    '    MakegoodDeliveryViewModel.VendorEditLocked = True

                    'Else
                    If WorksheetMarketDetailVendorMakegoodStatuses.Where(Function(Entity) Entity.OrderNumber = OrderNumber).First.Status = Database.Entities.Methods.OrderStatusType.OrderRejected Then

                        MakegoodDeliveryViewModel.VendorEditLocked = True

                    End If

                End If

                MakegoodDeliveryViewModel.IsOriginalOrderMode = (From Entity In WorksheetMarketDetailVendorMakegoodStatuses
                                                                 Where Entity.Status = Database.Entities.Methods.OrderStatusType.OrderGenerated).Any

                MakegoodDeliveryViewModel.WorksheetDateTypeName = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MakegoodDeliveryViewModel.MediaBroadcastWorksheetMarketID).MediaBroadcastWorksheet.MediaBroadcastWorksheetDateType.Name

                MediaBroadcastWorksheet = AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarket.LoadByMediaBroadcastWorksheetMarketID(DbContext, MakegoodDeliveryViewModel.MediaBroadcastWorksheetMarketID).MediaBroadcastWorksheet

                MakegoodDeliveryViewModel.WorksheetName = MediaBroadcastWorksheet.Name

                MakegoodDeliveryViewModel.FlightDates = MediaBroadcastWorksheet.StartDate.ToShortDateString & " - " & MediaBroadcastWorksheet.EndDate.ToShortDateString

                MakegoodDeliveryViewModel.CableNetworks = New Generic.List(Of Object)

                If MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                    If Session.IsNielsenSetup Then

                        Using NielsenDbContext As New AdvantageFramework.Nielsen.Database.DbContext(Session.NielsenConnectionString, Nothing)

                            NielsenDbContext.Database.Connection.Open()

                            If AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext).Any Then

                                MakegoodDeliveryViewModel.CableNetworks.AddRange((From Entity In AdvantageFramework.Nielsen.Database.Procedures.NCCTVCablenet.Load(NielsenDbContext)
                                                                                  Select New With {.Code = Entity.NetworkCode, .Description = Entity.NetworkName}).OrderBy(Function(Entity) Entity.Description).ToList)

                            Else

                                MakegoodDeliveryViewModel.CableNetworks.AddRange((From Entity In AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext)
                                                                                  Select Entity.Code, Entity.Description).OrderBy(Function(Entity) Entity.Description).ToList)

                            End If

                        End Using

                    Else

                        MakegoodDeliveryViewModel.CableNetworks.AddRange((From Entity In AdvantageFramework.Database.Procedures.CableNetworkStation.Load(DbContext)
                                                                          Select Entity.Code, Entity.Description).OrderBy(Function(Entity) Entity.Description).ToList)

                    End If

                ElseIf MediaBroadcastWorksheet.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore AndAlso Session.IsComscoreSetup Then

                    MakegoodDeliveryViewModel.CableNetworks.AddRange((From Entity In AdvantageFramework.Database.Procedures.ComscoreTVStation.LoadCableNetworks(DbContext)
                                                                      Select New With {.Code = Entity.CallLetters, .Description = Entity.Name}).OrderBy(Function(Entity) Entity.Description).ToList)
                End If

            End If

            If Employee IsNot Nothing Then

                MakegoodDeliveryViewModel.BuyerName = Employee.FirstName & " " & Employee.LastName
                MakegoodDeliveryViewModel.BuyerPhone = Replace(Employee.WorkPhoneNumber, ")", ") ") & If(String.IsNullOrWhiteSpace(Employee.WorkPhoneNumberExtension) = False, "  " & Employee.WorkPhoneNumberExtension, "")
                MakegoodDeliveryViewModel.BuyerEmail = Employee.Email

            End If

            MakegoodDeliveryViewModel.AgencyName = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

        End Sub
        Public Sub RejectMakegoodOffer(ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel, ConnectionString As String, UserCode As String, EmployeeName As String, Comment As String)

            Dim MediaRequestForProposalController As AdvantageFramework.Controller.Media.MediaRequestForProposalController = Nothing
            Dim RequestForProposalProcessGenerateViewModel As AdvantageFramework.ViewModels.Media.RequestForProposalProcessGenerateViewModel = Nothing
            Dim ErrorMessage As String = String.Empty
            Dim MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim UnSubmittedWorksheetLineNumbers As IEnumerable(Of Integer) = Nothing
            Dim SubmittedWorksheetLineNumbers As IEnumerable(Of Integer) = Nothing
            Dim OrderLineNumbers As IEnumerable(Of Integer) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                          Where Entity.OrderNumber = ViewModel.OrderNumber
                                                          Select Entity.MediaBroadcastWorksheetMarketDetailID).Distinct.ToArray

                UnSubmittedWorksheetLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail")
                                                   Where Entity.IsSubmitted = False AndAlso
                                                         MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                   Select Entity.MediaBroadcastWorksheetMarketDetail.LineNumber).Distinct.ToArray

                SubmittedWorksheetLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetail")
                                                 Where Entity.IsSubmitted = True AndAlso
                                                       Entity.IsOriginal = False AndAlso
                                                       MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                 Select Entity.MediaBroadcastWorksheetMarketDetail.LineNumber).Distinct.ToArray

                SubmittedWorksheetLineNumbers = (From SubmittedWorksheetLineNumber In SubmittedWorksheetLineNumbers
                                                 Where UnSubmittedWorksheetLineNumbers.Contains(SubmittedWorksheetLineNumber) = False
                                                 Select SubmittedWorksheetLineNumber).Distinct.ToArray

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL SET IS_SUBMITTED = 0 WHERE MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID IN ({0})", String.Join(",", ViewModel.MediaBroadcastWorksheetMarketDetailIDs.ToArray)))

                If ViewModel.MediaType = "T" Then

                    OrderLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.TVOrderDetail.LoadActiveByOrderNumber(DbContext, ViewModel.OrderNumber)
                                        Where SubmittedWorksheetLineNumbers.Contains(Entity.LinkLineNumber)
                                        Select CInt(Entity.LineNumber)).Distinct.ToArray

                ElseIf ViewModel.MediaType = "R" Then

                    OrderLineNumbers = (From Entity In AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadActiveByOrderNumber(DbContext, ViewModel.OrderNumber)
                                        Where SubmittedWorksheetLineNumbers.Contains(Entity.LinkLineNumber)
                                        Select CInt(Entity.LineNumber)).Distinct.ToArray

                End If

            End Using

            AdvantageFramework.MediaManager.AddUpdateOrderStatus(ViewModel.MediaType, ViewModel.OrderNumber, ConnectionString, UserCode, EmployeeName, AdvantageFramework.Database.Entities.OrderStatusType.MakegoodOfferRejected, OrderLineNumbers)

            MediaRequestForProposalController = New AdvantageFramework.Controller.Media.MediaRequestForProposalController(Me.Session)
            RequestForProposalProcessGenerateViewModel = MediaRequestForProposalController.Email_Load(ViewModel.AlertID.Value)
            RequestForProposalProcessGenerateViewModel.Email_Comment = "Makegood offer rejected.  " & Comment

            MediaRequestForProposalController.Email_SendEmails(RequestForProposalProcessGenerateViewModel, ErrorMessage)

        End Sub
        Public Sub DeleteStagingTables(OrderNumber As Integer)

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE AA " &
                    "From dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_DATE AA " &
                    "INNER Join dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL BB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID = BB.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL_ID " &
                    "INNER Join dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON BB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                    "WHERE AB.ORDER_NBR = {0}", OrderNumber))

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE AA " &
                    "From dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_STAGING_DETAIL AA " &
                    "INNER Join dbo.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE AB ON AA.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = AB.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                    "WHERE AB.ORDER_NBR = {0}", OrderNumber))

            End Using

        End Sub
        Public Sub PopulateWSDataTableForWebvantageEdit(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel)

            'objects
            Dim MediaBroadcastWorksheetMarketDetailIDs As Generic.List(Of Integer) = Nothing
            Dim RatingsServiceID As Nullable(Of Integer) = Nothing
            Dim Dayparts As Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate) = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail) = Nothing
            Dim SpotColumnCounter As Integer = 0
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim TotalSpots As Integer = 0
            Dim MediaBroadcastWorksheetMarketStagingDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim OriginalDataRow As System.Data.DataRow = Nothing
            Dim RevisedDataRow As System.Data.DataRow = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DatesWithRateGreaterThanZeroCount As Integer = 0
            Dim AverageRateAmount As Decimal = 0
            Dim TotalRateAmount As Decimal = 0
            Dim TotalDollars As Decimal = 0
            Dim RateDiffers As Boolean = False
            Dim NonairingDataRow As System.Data.DataRow = Nothing
            Dim NonairingLineNumbers As Generic.List(Of String) = Nothing
            Dim DetailDate As Date = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim TotalGross As Decimal = 0
            Dim GRP As Decimal = 0
            Dim GIMP As Decimal = 0
            Dim GrandTotalDataRow As System.Data.DataRow = Nothing
            Dim OriginalStagingDetailID As Integer = 0
            Dim MediaBroadcastWorksheetMarketDetailDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate = Nothing
            Dim DateSpots As Integer = 0
            Dim NonairingDataRowList As Generic.List(Of System.Data.DataRow) = Nothing
            Dim MGOnlyDataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail) = Nothing
            Dim OriginalDataTable As System.Data.DataTable = Nothing

            NonairingDataRowList = New Generic.List(Of System.Data.DataRow)

            NonairingLineNumbers = New Generic.List(Of String)

            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetails")
                                                      Where Entity.OrderNumber = OrderNumber AndAlso
                                                            Entity.MediaBroadcastWorksheetMarketDetail.RevisionNumber = MakegoodDeliveryViewModel.MaxRevisionNumber AndAlso
                                                            Entity.OrderLineNumber IsNot Nothing AndAlso
                                                            MakegoodDeliveryViewModel.LineNumbers.Contains(Entity.OrderLineNumber)
                                                      Select Entity.MediaBroadcastWorksheetMarketDetailID).Distinct.ToList

            If MediaBroadcastWorksheetMarketDetailIDs IsNot Nothing AndAlso MediaBroadcastWorksheetMarketDetailIDs.Count > 0 Then

                If MakegoodDeliveryViewModel.MediaType = "T" Then

                    RatingsServiceID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 COALESCE(MBW.RATINGS_SERVICE_ID, -1) FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET] MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID WHERE SHAREBOOK_NIELSEN_TV_BOOK_ID IS NOT NULL AND ORDER_NBR = {0}", OrderNumber)).FirstOrDefault

                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList

                    TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If TVOrder IsNot Nothing AndAlso TVOrder.Vendor IsNot Nothing Then

                        If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not TVOrder.Vendor.IsNielsenSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

                        ElseIf RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not TVOrder.Vendor.IsComscoreSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " Comscore"

                        End If

                    End If

                ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                    RatingsServiceID = DbContext.Database.SqlQuery(Of Integer)(String.Format("Select Top 1 COALESCE(CAST(MBWM.EXTERNAL_RADIO_SOURCE As int), -1) From [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                            "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                            "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID  " &
                            "WHERE NIELSEN_RADIO_PERIOD_ID1 IS NOT NULL AND ORDER_NBR = {0}", OrderNumber)).FirstOrDefault

                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList

                    RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If RadioOrder IsNot Nothing AndAlso RadioOrder.Vendor IsNot Nothing Then

                        If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not RadioOrder.Vendor.IsNielsenSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

                        ElseIf RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                            MakegoodDeliveryViewModel.SuppressRatings = False
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " EASTLAN"

                        End If

                    End If

                End If

                If MakegoodDeliveryViewModel.IsOriginalOrderMode Then

                    DataTable = BuildOriginalDataTable(DbContext, MediaBroadcastWorksheetMarketDetailIDs, MakegoodDeliveryViewModel, MakegoodDeliveryViewModel.MakegoodDataTable, Dayparts)

                Else

                    DataTable = MakegoodDeliveryViewModel.MakegoodDataTable.Clone

                    DataTable.BeginLoadData()

                    CreateStagingRows(DbContext, MediaBroadcastWorksheetMarketDetailIDs, MakegoodDeliveryViewModel)

                    MediaBroadcastWorksheetMarketStagingDetails = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext)
                                                                   Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                                   Select Entity).OrderBy(Function(Entity) Entity.LineNumber).ThenBy(Function(Entity) Entity.MakegoodNumber).ToList

                    OriginalDataTable = LoadOriginalRows(DbContext, MediaBroadcastWorksheetMarketStagingDetails, MakegoodDeliveryViewModel, MakegoodDeliveryViewModel.MakegoodDataTable, MediaBroadcastWorksheetMarketDetailIDs)

                    For Each MediaBroadcastWorksheetMarketStagingDetail In MediaBroadcastWorksheetMarketStagingDetails

                        MediaBroadcastWorksheetMarketDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.Load(DbContext)
                                                               Where Entity.ID = MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID
                                                               Select Entity).SingleOrDefault

                        If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                            DataRow = DataTable.NewRow

                            SpotColumnCounter = 0

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ID

                            If MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = System.DBNull.Value

                            ElseIf (From Entity In MediaBroadcastWorksheetMarketStagingDetails
                                    Where MediaBroadcastWorksheetMarketDetailIDs.Contains(MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                          Entity.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber AndAlso
                                          Entity.MakegoodNumber = 0
                                    Select Entity).Count = 1 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = (From Entity In MediaBroadcastWorksheetMarketStagingDetails
                                                                                                                                                Where MediaBroadcastWorksheetMarketDetailIDs.Contains(MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                                                                                                                      Entity.LineNumber = MediaBroadcastWorksheetMarketDetail.LineNumber AndAlso
                                                                                                                                                      Entity.MakegoodNumber = 0
                                                                                                                                                Select Entity).Single.ID

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = System.DBNull.Value

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0") & If(MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0, "", "-" & MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber.ToString.PadLeft(2, "0"))
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.MakegoodNumber.ToString) = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = MediaBroadcastWorksheetMarketStagingDetail.IsOriginal
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetwork.ToString) = MediaBroadcastWorksheetMarketStagingDetail.CableNetworkStationCode
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetworkCode.ToString) = If(MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode Is Nothing, System.DBNull.Value, MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode)
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Days.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Days
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.StartTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.StartTime
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.EndTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.EndTime
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Program.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Program

                            If MediaBroadcastWorksheetMarketStagingDetail.DaypartID.HasValue Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartID.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DaypartID

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Length.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Length
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Bookend
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ValueAdded
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Comments.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Comments
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DefaultRate

                            If MediaBroadcastWorksheetMarketStagingDetail.DaypartID.HasValue AndAlso MediaBroadcastWorksheetMarketStagingDetail.DaypartID.Value > 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString) = Dayparts.Where(Function(Entity) Entity.ID = MediaBroadcastWorksheetMarketStagingDetail.DaypartID.Value).FirstOrDefault.Description

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString) = String.Empty

                            End If

                            TotalSpots = 0
                            DatesWithRateGreaterThanZeroCount = 0
                            TotalRateAmount = 0
                            TotalDollars = 0

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0

                            RateDiffers = False

                            For Each MediaBroadcastWorksheetMarketStagingDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.ID)
                                                                                        Select Entity).OrderBy(Function(E) E.Date).ToList

                                If MediaBroadcastWorksheetMarketStagingDetailDate.Date >= MakegoodDeliveryViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketStagingDetailDate.Date <= MakegoodDeliveryViewModel.MaxDate AndAlso
                                        DataTable.Columns.Contains("Spot" & SpotColumnCounter) Then

                                    If MediaBroadcastWorksheetMarketStagingDetailDate.IsHiatus Then

                                        DataRow("Spot" & SpotColumnCounter) = System.DBNull.Value
                                        DataRow("Rate" & SpotColumnCounter) = System.DBNull.Value

                                    Else

                                        DataRow("Spot" & SpotColumnCounter) = MediaBroadcastWorksheetMarketStagingDetailDate.Spots
                                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) += MediaBroadcastWorksheetMarketStagingDetailDate.Spots * MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                        DataRow("Rate" & SpotColumnCounter) = MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                        If MediaBroadcastWorksheetMarketStagingDetailDate.Rate > 0 Then

                                            DatesWithRateGreaterThanZeroCount += 1

                                        End If

                                        If RateDiffers = False AndAlso MediaBroadcastWorksheetMarketStagingDetail.DefaultRate <> MediaBroadcastWorksheetMarketStagingDetailDate.Rate Then

                                            RateDiffers = True

                                        End If

                                        TotalRateAmount += MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                        TotalDollars += (MediaBroadcastWorksheetMarketStagingDetailDate.Rate * CDec(MediaBroadcastWorksheetMarketStagingDetailDate.Spots))

                                        TotalSpots += DataRow("Spot" & SpotColumnCounter)

                                    End If

                                    SpotColumnCounter += 1

                                End If

                            Next

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RateDiffersFlag.ToString) = RateDiffers

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalSpots

                            If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                                MakegoodDeliveryViewModel.PrimaryDemographic = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.Description

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = TotalSpots * DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString)

                            If MakegoodDeliveryViewModel.MediaType = "T" Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = FormatNumber(MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots / 1000, 1)

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = FormatNumber(MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots / 100, 0)

                            End If

                            If TotalSpots = 0 Then

                                If DatesWithRateGreaterThanZeroCount > 0 Then

                                    AverageRateAmount = TotalRateAmount / DatesWithRateGreaterThanZeroCount

                                Else

                                    AverageRateAmount = 0

                                End If

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = 0, 0, Math.Round(AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString), 2))
                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) <> 0, Math.Round((AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString)), 2), 0)

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0, 0, Math.Round(TotalDollars / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString), 2))

                                If MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots = 0 Then

                                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                                Else

                                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = Math.Round((TotalDollars / (MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots) * 1000), 2)

                                End If

                            End If

                            If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = True Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Ordered spots"

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Makegood"

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsSubmitted.ToString) = MediaBroadcastWorksheetMarketStagingDetail.IsSubmitted

                            DataTable.Rows.Add(DataRow)

                        End If

                    Next

                    'add original row
                    OriginalDataRow = DataTable.NewRow

                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -1
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Total:"
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = DataTable.Compute("Sum(TotalSpots)", "MakegoodNumber = 0")
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = DataTable.Compute("Sum(PrimaryGRP)", "MakegoodNumber = 0")
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = DataTable.Compute("Sum(TotalGross)", "MakegoodNumber = 0")
                    OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = DataTable.Compute("Sum(PrimaryGIMP)", "MakegoodNumber = 0")

                    If OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) OrElse
                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Equals(System.DBNull.Value) OrElse
                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString)

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / (OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 100) * 1000

                        End If

                    End If

                    If OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) OrElse
                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString).Equals(System.DBNull.Value) OrElse
                            OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                        OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    For SpotColumnCounter = 0 To MakegoodDeliveryViewModel.SpotCount - 1

                        OriginalDataRow("Spot" & SpotColumnCounter) = DataTable.Compute("Sum(Spot" & SpotColumnCounter & ")", "MakegoodNumber = 0")

                        If OriginalDataRow("Spot" & SpotColumnCounter).Equals(System.DBNull.Value) Then

                            OriginalDataRow("Spot" & SpotColumnCounter) = System.DBNull.Value

                        End If

                    Next

                    DataTable.Rows.Add(OriginalDataRow)

                    'add Total Makegood row
                    RevisedDataRow = DataTable.NewRow

                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -3
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Total Makegood:"
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    TotalSpots = 0
                    TotalGross = 0
                    GRP = 0
                    GIMP = 0

                    MediaBroadcastWorksheetMarketStagingDetailIDs = MediaBroadcastWorksheetMarketStagingDetails.Where(Function(D) D.MakegoodNumber > 0).Select(Function(D) D.ID).Distinct.ToArray

                    If MediaBroadcastWorksheetMarketStagingDetailIDs IsNot Nothing AndAlso MediaBroadcastWorksheetMarketStagingDetailIDs.Count > 0 Then

                        For Each MediaBroadcastWorksheetMarketStagingDetail In MediaBroadcastWorksheetMarketStagingDetails.Where(Function(D) D.MakegoodNumber > 0).ToList

                            GRP += MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating * MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketStagingDetailDates.Sum(Function(DD) DD.Spots)
                            GIMP += MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketStagingDetailDates.Sum(Function(DD) DD.Spots)

                        Next

                        For SpotColumnCounter = 0 To MakegoodDeliveryViewModel.SpotCount - 1

                            DetailDate = ConvertToDate(MakegoodDeliveryViewModel.SpotDates.Values(SpotColumnCounter).ToString)

                            If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                                      Entity.Date = DetailDate AndAlso
                                      Entity.IsHiatus = True
                                Select Entity).Any = True Then

                                RevisedDataRow("Spot" & SpotColumnCounter) = System.DBNull.Value

                            Else

                                If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                    Where Entity.Date = DetailDate AndAlso
                                          MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID)
                                    Select Entity.Spots).Any Then

                                    RevisedDataRow("Spot" & SpotColumnCounter) = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                                                                  Where Entity.Date = DetailDate AndAlso
                                                                                        MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID)
                                                                                  Select Entity.Spots).Sum()

                                    TotalGross += (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                                   Where Entity.Date = DetailDate AndAlso
                                                         MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID)
                                                   Select Entity.Spots * Entity.Rate).Sum()

                                    TotalSpots += RevisedDataRow("Spot" & SpotColumnCounter)

                                End If

                            End If

                        Next

                    End If

                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalSpots
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = GRP
                    RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = TotalGross

                    If MakegoodDeliveryViewModel.MediaType = "T" Then

                        RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = GIMP / 1000

                    ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                        RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = GIMP / 100

                    End If

                    If RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) OrElse RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Equals(System.DBNull.Value) OrElse RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString)

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / (RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 100) * 1000

                        End If

                    End If

                    If RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) OrElse RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                        RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) / RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    DataTable.Rows.Add(RevisedDataRow)

                    'add Makegood-only row to determine Variance
                    MGOnlyDataRow = DataTable.NewRow

                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -3
                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Makegood Only:"
                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    TotalSpots = OriginalDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CInt(DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString))).Sum()
                    TotalGross = OriginalDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CDec(DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString))).Sum()

                    GRP = OriginalDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CDec(DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString))).Sum()
                    GIMP = OriginalDataTable.Rows.OfType(Of System.Data.DataRow).Select(Function(DR) CDec(DR(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString))).Sum()

                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalSpots
                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = TotalGross
                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = GRP
                    MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = GIMP

                    If GRP = 0 Then

                        MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) =
                            MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                            MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    If MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                       (MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000) * 1000

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                       (MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 100) * 1000

                        End If

                    End If

                    DataTable.Rows.Add(MGOnlyDataRow)

                    'add Grand Total row
                    GrandTotalDataRow = DataTable.NewRow

                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -4
                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Grand Total:"
                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    TotalSpots = 0

                    For SpotColumnCounter = 0 To MakegoodDeliveryViewModel.SpotCount - 1

                        If OriginalDataRow("Spot" & SpotColumnCounter).Equals(System.DBNull.Value) OrElse RevisedDataRow("Spot" & SpotColumnCounter).Equals(System.DBNull.Value) Then

                            GrandTotalDataRow("Spot" & SpotColumnCounter) = System.DBNull.Value

                        Else

                            GrandTotalDataRow("Spot" & SpotColumnCounter) = OriginalDataRow("Spot" & SpotColumnCounter) + RevisedDataRow("Spot" & SpotColumnCounter)

                        End If

                    Next

                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) +
                                                                                                                                               RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString)

                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) +
                                                                                                                                               RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString)

                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) +
                                                                                                                                               RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = OriginalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) +
                                                                                                                                                RevisedDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString)

                    If GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                        GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                   GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    If GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                       (GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000) * 1000

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                       (GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 100) * 1000

                        End If

                    End If

                    DataTable.Rows.Add(GrandTotalDataRow)

                    'add change row
                    DataRow = DataTable.NewRow

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -5
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = "Total Variance:"
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    For SpotColumnCounter = 0 To MakegoodDeliveryViewModel.SpotCount - 1

                        DataRow("Spot" & SpotColumnCounter) = System.DBNull.Value

                    Next

                    If GrandTotalDataRow("TotalSpots").Equals(System.DBNull.Value) OrElse MGOnlyDataRow("TotalSpots").Equals(System.DBNull.Value) Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = GrandTotalDataRow("TotalSpots") - MGOnlyDataRow("TotalSpots")

                    End If

                    If GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) OrElse
                            MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString).Equals(System.DBNull.Value) Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) - MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString)

                    End If

                    If GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString).Equals(System.DBNull.Value) OrElse
                            MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString).Equals(System.DBNull.Value) Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) - MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)

                    End If

                    If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                         DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString)
                    End If

                    If GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Equals(System.DBNull.Value) OrElse
                            MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString).Equals(System.DBNull.Value) Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) - MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) '/ 1000)

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = GrandTotalDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) - MGOnlyDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) '/ 100)

                        End If

                        If Math.Abs(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString)) < 0.1 Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0

                        End If

                    End If

                    If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    Else

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                             (DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000) * 1000

                        ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                             (DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 100) * 1000

                        End If

                    End If

                    DataTable.Rows.Add(DataRow)

                    DataRow = DataTable.NewRow

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -1000
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = ""
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Non-airing spots"
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                    TotalSpots = 0

                    For i As Integer = 0 To SpotColumnCounter - 1

                        DataRow("Spot" & i) = 0

                    Next

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalSpots

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                    DataTable.Rows.Add(DataRow)

                    DataTable.Rows.Remove(MGOnlyDataRow)

                    DataTable.EndLoadData()

                End If

            End If

            MakegoodDeliveryViewModel.MakegoodDataTable = DataTable.DefaultView.ToTable

        End Sub
        Public Sub PopulateWSDataTableLoadForWebvantageReview(DbContext As AdvantageFramework.Database.DbContext, OrderNumber As Integer, MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel,
                                                              ReviewLineNumber As Integer)

            'objects
            Dim MediaBroadcastWorksheetMarketDetailIDs As Generic.List(Of Integer) = Nothing
            Dim RatingsServiceID As Nullable(Of Integer) = Nothing
            Dim Dayparts As Generic.List(Of AdvantageFramework.Database.Entities.Daypart) = Nothing
            Dim TVOrder As AdvantageFramework.Database.Entities.TVOrder = Nothing
            Dim RadioOrder As AdvantageFramework.Database.Entities.RadioOrder = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail) = Nothing
            Dim SpotColumnCounter As Integer = 0
            Dim MediaBroadcastWorksheetMarketDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetail = Nothing
            Dim TotalSpots As Integer = 0
            Dim MediaBroadcastWorksheetMarketStagingDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim OriginalDataRow As System.Data.DataRow = Nothing
            Dim RevisedDataRow As System.Data.DataRow = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DatesWithRateGreaterThanZeroCount As Integer = 0
            Dim AverageRateAmount As Decimal = 0
            Dim TotalRateAmount As Decimal = 0
            Dim TotalDollars As Decimal = 0
            Dim DetailDate As Date = Nothing
            Dim TotalNonAiringDataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim TotalGross As Decimal = 0

            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext).Include("MediaBroadcastWorksheetMarketDetails")
                                                      Where Entity.OrderNumber = OrderNumber AndAlso
                                                            Entity.MediaBroadcastWorksheetMarketDetail.RevisionNumber = MakegoodDeliveryViewModel.MaxRevisionNumber AndAlso
                                                            Entity.OrderLineNumber IsNot Nothing AndAlso
                                                            MakegoodDeliveryViewModel.LineNumbers.Contains(Entity.OrderLineNumber) AndAlso
                                                            Entity.MediaBroadcastWorksheetMarketDetail.LineNumber = ReviewLineNumber
                                                      Select Entity.MediaBroadcastWorksheetMarketDetailID).Distinct.ToList

            If MediaBroadcastWorksheetMarketDetailIDs IsNot Nothing AndAlso MediaBroadcastWorksheetMarketDetailIDs.Count > 0 Then

                If MakegoodDeliveryViewModel.MediaType = "T" Then

                    RatingsServiceID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 COALESCE(MBW.RATINGS_SERVICE_ID, -1) FROM [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID " &
                            "INNER JOIN [dbo].[MEDIA_BROADCAST_WORKSHEET] MBW ON MBWM.MEDIA_BROADCAST_WORKSHEET_ID = MBW.MEDIA_BROADCAST_WORKSHEET_ID WHERE SHAREBOOK_NIELSEN_TV_BOOK_ID IS NOT NULL AND ORDER_NBR = {0}", OrderNumber)).FirstOrDefault

                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_TV).ToList

                    TVOrder = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If TVOrder IsNot Nothing AndAlso TVOrder.Vendor IsNot Nothing Then

                        If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Nielsen Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not TVOrder.Vendor.IsNielsenSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

                        ElseIf RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not TVOrder.Vendor.IsComscoreSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " Comscore"

                        End If

                    End If

                ElseIf MakegoodDeliveryViewModel.MediaType = "R" Then

                    RatingsServiceID = DbContext.Database.SqlQuery(Of Integer)(String.Format("Select Top 1 COALESCE(CAST(MBWM.EXTERNAL_RADIO_SOURCE As int), -1) From [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL] MBWMD " &
                            "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE] MBWMDD ON MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID = MBWMDD.MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID " &
                            "INNER Join [dbo].[MEDIA_BROADCAST_WORKSHEET_MARKET] MBWM ON MBWM.MEDIA_BROADCAST_WORKSHEET_MARKET_ID = MBWMD.MEDIA_BROADCAST_WORKSHEET_MARKET_ID  " &
                            "WHERE NIELSEN_RADIO_PERIOD_ID1 IS NOT NULL AND ORDER_NBR = {0}", OrderNumber)).FirstOrDefault

                    Dayparts = AdvantageFramework.Database.Procedures.Daypart.LoadActiveByDaypartTypeID(DbContext, AdvantageFramework.Database.Entities.DayPartTypeID.Local_Radio).ToList

                    RadioOrder = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                    If RadioOrder IsNot Nothing AndAlso RadioOrder.Vendor IsNot Nothing Then

                        If RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen Then

                            MakegoodDeliveryViewModel.SuppressRatings = Not RadioOrder.Vendor.IsNielsenSubsciber
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " The Nielsen Company"

                        ElseIf RatingsServiceID = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Eastlan Then

                            MakegoodDeliveryViewModel.SuppressRatings = False
                            MakegoodDeliveryViewModel.Copyright = "Copyright © " & Now.Year.ToString & " EASTLAN"

                        End If

                    End If

                End If

                DataTable = MakegoodDeliveryViewModel.MakegoodDataTable.Clone

                DataTable.BeginLoadData()

                CreateStagingRows(DbContext, MediaBroadcastWorksheetMarketDetailIDs, MakegoodDeliveryViewModel)

                MediaBroadcastWorksheetMarketStagingDetails = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetail.Load(DbContext)
                                                               Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                                     Entity.LineNumber = ReviewLineNumber
                                                               Select Entity).OrderBy(Function(Entity) Entity.LineNumber).ThenBy(Function(Entity) Entity.MakegoodNumber).ToList

                For Each MediaBroadcastWorksheetMarketStagingDetail In MediaBroadcastWorksheetMarketStagingDetails.OrderBy(Function(Entity) Entity.MakegoodNumber)

                    MediaBroadcastWorksheetMarketDetail = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetail.Load(DbContext)
                                                           Where Entity.ID = MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID
                                                           Select Entity).SingleOrDefault

                    If MediaBroadcastWorksheetMarketDetail IsNot Nothing Then

                        DataRow = DataTable.NewRow

                        SpotColumnCounter = 0

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ID
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = System.DBNull.Value

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0") & If(MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0, "", "-" & MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber.ToString.PadLeft(2, "0"))
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = MediaBroadcastWorksheetMarketStagingDetail.IsOriginal
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetwork.ToString) = MediaBroadcastWorksheetMarketStagingDetail.CableNetworkStationCode
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetworkCode.ToString) = If(MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode Is Nothing, System.DBNull.Value, MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode)
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Days.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Days
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.StartTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.StartTime
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.EndTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.EndTime
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Program.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Program

                        If MediaBroadcastWorksheetMarketStagingDetail.DaypartID.HasValue Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartID.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DaypartID

                        End If

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Length.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Length
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Bookend
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ValueAdded
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Comments.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Comments
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DefaultRate

                        If MediaBroadcastWorksheetMarketStagingDetail.DaypartID.HasValue AndAlso MediaBroadcastWorksheetMarketStagingDetail.DaypartID.Value > 0 Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString) = Dayparts.Where(Function(Entity) Entity.ID = MediaBroadcastWorksheetMarketStagingDetail.DaypartID.Value).FirstOrDefault.Description

                        Else

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartDescription.ToString) = String.Empty

                        End If

                        TotalSpots = 0
                        DatesWithRateGreaterThanZeroCount = 0
                        TotalRateAmount = 0
                        TotalDollars = 0

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0

                        For Each MediaBroadcastWorksheetMarketStagingDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.ID)
                                                                                    Select Entity).OrderBy(Function(E) E.Date).ToList

                            If MediaBroadcastWorksheetMarketStagingDetailDate.Date >= MakegoodDeliveryViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketStagingDetailDate.Date <= MakegoodDeliveryViewModel.MaxDate AndAlso
                                        DataTable.Columns.Contains("Spot" & SpotColumnCounter) Then

                                If MediaBroadcastWorksheetMarketStagingDetailDate.IsHiatus Then

                                    DataRow("Spot" & SpotColumnCounter) = 0
                                    DataRow("Rate" & SpotColumnCounter) = 0

                                Else

                                    If MediaBroadcastWorksheetMarketStagingDetail.IsOriginal Then

                                        MediaBroadcastWorksheetMarketDetailDateMakegoods = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                                            Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                                                                  Entity.MediaBroadcastWorksheetMarketDetail.LineNumber = MediaBroadcastWorksheetMarketStagingDetail.LineNumber
                                                                                            Select Entity).ToList

                                        If MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                               DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber AndAlso
                                                                                                               DD.MakegoodSpots > 0).Any Then

                                            DataRow("Spot" & SpotColumnCounter) = MediaBroadcastWorksheetMarketStagingDetailDate.Spots +
                                                    MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                                        DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber AndAlso
                                                                                                                        DD.MakegoodSpots > 0).First.MakegoodSpots

                                        Else

                                            If MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID AndAlso
                                                                                                                   DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date).Any Then

                                                DataRow("Spot" & SpotColumnCounter) = MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketStagingDetail.MediaBroadcastWorksheetMarketDetailID AndAlso
                                                                                                                                                          DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date).First.Spots

                                            Else

                                                DataRow("Spot" & SpotColumnCounter) = 0

                                            End If

                                        End If

                                    Else

                                        DataRow("Spot" & SpotColumnCounter) = MediaBroadcastWorksheetMarketStagingDetailDate.Spots
                                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) += MediaBroadcastWorksheetMarketStagingDetailDate.Spots * MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                    End If

                                    DataRow("Rate" & SpotColumnCounter) = MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                    If MediaBroadcastWorksheetMarketStagingDetailDate.Rate > 0 Then

                                        DatesWithRateGreaterThanZeroCount += 1

                                    End If

                                    TotalRateAmount += MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                                    TotalDollars += (MediaBroadcastWorksheetMarketStagingDetailDate.Rate * CDec(MediaBroadcastWorksheetMarketStagingDetailDate.Spots))

                                    TotalSpots += DataRow("Spot" & SpotColumnCounter)

                                End If

                                SpotColumnCounter += 1

                            End If

                        Next

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalSpots

                        'If MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic IsNot Nothing Then

                        '    MakegoodDeliveryViewModel.PrimaryDemographic = MediaBroadcastWorksheetMarketDetail.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.PrimaryMediaDemographic.Description

                        'End If

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = TotalSpots * DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString)

                        If MakegoodDeliveryViewModel.MediaType = "T" Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = FormatNumber(MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots / 1000, 1)

                        Else

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = FormatNumber(MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots / 100, 0)

                        End If

                        If TotalSpots = 0 Then

                            If DatesWithRateGreaterThanZeroCount > 0 Then

                                AverageRateAmount = TotalRateAmount / DatesWithRateGreaterThanZeroCount

                            Else

                                AverageRateAmount = 0

                            End If

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = 0, 0, Math.Round(AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString), 2))
                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) <> 0, Math.Round((AverageRateAmount / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString)), 2), 0)

                        Else

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0, 0, Math.Round(TotalDollars / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString), 2))

                            If MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots = 0 Then

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                            Else

                                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = Math.Round((TotalDollars / (MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots) * 1000), 2)

                            End If

                        End If

                    End If

                    If DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = True Then

                        If MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0 Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Original spots"

                        ElseIf MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber > 0 Then

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Makegood"

                        Else

                            DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Ordered spots"

                        End If

                    Else

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString) = "Makegood"

                    End If

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsSubmitted.ToString) = MediaBroadcastWorksheetMarketStagingDetail.IsSubmitted

                    DataTable.Rows.Add(DataRow)

                    If MediaBroadcastWorksheetMarketStagingDetail.IsOriginal Then

                        AddNonAiringRowForBuyer(DbContext, DataTable, MediaBroadcastWorksheetMarketStagingDetail, MediaBroadcastWorksheetMarketStagingDetails, MakegoodDeliveryViewModel, MediaBroadcastWorksheetMarketDetailIDs)

                    End If

                    If (MediaBroadcastWorksheetMarketStagingDetails.IndexOf(MediaBroadcastWorksheetMarketStagingDetail) = MediaBroadcastWorksheetMarketStagingDetails.Count - 1 OrElse
                                MediaBroadcastWorksheetMarketStagingDetails(MediaBroadcastWorksheetMarketStagingDetails.IndexOf(MediaBroadcastWorksheetMarketStagingDetail)).LineNumber <> MediaBroadcastWorksheetMarketStagingDetails(MediaBroadcastWorksheetMarketStagingDetails.IndexOf(MediaBroadcastWorksheetMarketStagingDetail) + 1).LineNumber) Then

                        'add variance row
                        DataRow = DataTable.NewRow

                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -MediaBroadcastWorksheetMarketStagingDetail.ID - 9000
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

                        DataRow.SetField(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString, "Variance")

                        SpotColumnCounter = 0
                        TotalSpots = 0

                        For Each MediaBroadcastWorksheetMarketStagingDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.ID)
                                                                                    Select Entity).OrderBy(Function(E) E.Date).ToList

                            Dim NonAiringSpots As Integer = DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso IsDBNull(DR("Spot" & SpotColumnCounter)) = False AndAlso
                                                                                                                                      DR("RowType") = "Non-Airing").Select(Function(DR) CInt(DR("Spot" & SpotColumnCounter))).Sum()

                            DataRow("Spot" & SpotColumnCounter) = DataTable.Rows.OfType(Of System.Data.DataRow).Where(Function(DR) IsDBNull(DR("RowType")) = False AndAlso IsDBNull(DR("Spot" & SpotColumnCounter)) = False AndAlso
                                                                                                                                   DR("RowType") = "Makegood").Select(Function(DR) CInt(DR("Spot" & SpotColumnCounter))).Sum() + NonAiringSpots

                            TotalSpots += DataRow("Spot" & SpotColumnCounter)

                            SpotColumnCounter += 1

                        Next

                        DataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString) = TotalSpots
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0
                        DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                        DataTable.Rows.Add(DataRow)

                    End If

                Next

                DataTable.EndLoadData()

            End If

            MakegoodDeliveryViewModel.MakegoodDataTable = DataTable.DefaultView.ToTable

        End Sub
        Private Sub AddNonAiringRow(DbContext As AdvantageFramework.Database.DbContext, DataTable As System.Data.DataTable, MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail,
                                    MediaBroadcastWorksheetMarketStagingDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail),
                                    MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel, IsMadegood As Boolean)

            'objects
            Dim NonairingDataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim SpotColumnCounter As Integer = 0
            Dim TotalSpots As Integer = 0

            NonairingDataRow = DataTable.NewRow

            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -MediaBroadcastWorksheetMarketStagingDetail.ID

            If DataTable.Rows.Count = 1 Then

                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0")

            Else

                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0") & "-" &
                                        If(MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber > 0, MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber.ToString.PadLeft(2, "0"), "")
            End If

            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

            NonairingDataRow.SetField(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString, "Non-Airing")
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0

            SpotColumnCounter = 0
            TotalSpots = 0

            MediaBroadcastWorksheetMarketDetailIDs = (From Entity In MediaBroadcastWorksheetMarketStagingDetails
                                                      Where Entity.MakegoodNumber <> 0
                                                      Select Entity.MediaBroadcastWorksheetMarketDetailID).Distinct.ToArray

            MediaBroadcastWorksheetMarketStagingDetailIDs = (From Entity In MediaBroadcastWorksheetMarketStagingDetails
                                                             Where Entity.MakegoodNumber <> 0
                                                             Select Entity.ID).ToArray

            MediaBroadcastWorksheetMarketDetailDateMakegoods = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                                Select Entity).ToList

            For Each MediaBroadcastWorksheetMarketStagingDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.ID)
                                                                        Select Entity).OrderBy(Function(E) E.Date).ToList

                If MediaBroadcastWorksheetMarketStagingDetailDate.Date >= MakegoodDeliveryViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketStagingDetailDate.Date <= MakegoodDeliveryViewModel.MaxDate AndAlso
                                            DataTable.Columns.Contains("Spot" & SpotColumnCounter) Then

                    If MediaBroadcastWorksheetMarketStagingDetailDate.IsHiatus Then

                        NonairingDataRow("Spot" & SpotColumnCounter) = 0

                    Else

                        NonairingDataRow("Spot" & SpotColumnCounter) = 0

                        'try to use this
                        'If MediaBroadcastWorksheetMarketStagingDetail.IsOriginal Then

                        '    If MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                        '                                                                           DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber).Any Then

                        '        NonairingDataRow("Spot" & SpotColumnCounter) = -1 *
                        '                MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                        '                                                                                    DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber).Sum(Function(DD) DD.MakegoodSpots)

                        '        NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) +=
                        '                            (From Entity In MediaBroadcastWorksheetMarketDetailDateMakegoods
                        '                             Where Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                        '                                   Entity.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber
                        '                             Select Entity.MakegoodSpots * Entity.Rate).Sum * -1

                        '    End If

                        '    MediaBroadcastWorksheetMarketStagingDetailDates = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                        '                                                       Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                        '                                                             Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                        '                                                             Entity.MediaBroadcastWorksheetMarketStagingDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber
                        '                                                       Select Entity).ToList

                        '    If MediaBroadcastWorksheetMarketStagingDetailDates IsNot Nothing AndAlso MediaBroadcastWorksheetMarketStagingDetailDates.Count > 0 Then

                        '        NonairingDataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketStagingDetailDates.Sum(Function(Entity) Entity.MakegoodSpots) * -1

                        '        NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) +=
                        '                MediaBroadcastWorksheetMarketStagingDetailDates.Sum(Function(Entity) Entity.MakegoodSpots * Entity.Rate) * -1

                        '    End If

                        'Else

                        '    If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                        '        Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                        '              Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                        '        Select Entity.MakegoodSpots).Any Then

                        '        NonairingDataRow("Spot" & SpotColumnCounter) = -1 *
                        '                            (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                        '                             Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                        '                                   Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                        '                             Select Entity.MakegoodSpots).Sum

                        '        NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) += -1 *
                        '                            (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                        '                             Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                        '                                   Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                        '                             Select Entity.MakegoodSpots * Entity.Rate).Sum

                        '    End If

                        'End If

                        'If IsMadegood = False Then

                        '    If MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                        '                                                                           DD.MakegoodSpots > 0).Any Then

                        '        NonairingDataRow("Spot" & SpotColumnCounter) = -1 *
                        '                MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date).Sum(Function(DD) DD.MakegoodSpots)

                        '    End If

                        '    NonairingDataRow("Spot" & SpotColumnCounter) +=
                        '                            (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                        '                             Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                        '                                   Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                        '                                   Entity.MediaBroadcastWorksheetMarketStagingDetail.MadegoodNumber = 0
                        '                             Select Entity.MakegoodSpots).Sum * -1

                        'Else

                        '    If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                        '        Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                        '              Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                        '        Select Entity.MakegoodSpots).Any Then

                        '        NonairingDataRow("Spot" & SpotColumnCounter) = -1 *
                        '                            (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                        '                             Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                        '                                   Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                        '                             Select Entity.MakegoodSpots).Sum

                        '    End If

                        'End If

                    End If

                    TotalSpots += NonairingDataRow("Spot" & SpotColumnCounter)
                    SpotColumnCounter += 1

                End If

            Next

            NonairingDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString) = TotalSpots

            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

            DataTable.Rows.Add(NonairingDataRow)

        End Sub
        Public Sub AcceptOrderForVendorRep(OrderLines As Generic.List(Of AdvantageFramework.Controller.Media.MakegoodDeliveryController.OrderLine), EmployeeCode As String)

            Dim RevisedDate As String = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                RevisedDate = AdvantageFramework.Database.Procedures.Generic.LoadDatabaseTimeMilliseconds(DbContext)

                For Each OrderLine In OrderLines

                    DbContext.Database.ExecuteSqlCommand(String.Format("exec advsp_media_broadcast_worksheet_accept_order_for_vendor_rep {0}, {1}, '{2}', '{3}'", OrderLine.OrderNumber, OrderLine.LineNumber, OrderLine.MediaType, RevisedDate))

                    DbContext.Database.ExecuteSqlCommand(String.Format("exec dbo.advsp_makegood_staging_delete_by_order_line {0}, {1}", OrderLine.OrderNumber, OrderLine.LineNumber))

                Next

            End Using

        End Sub
        Private Sub AddNonAiringRowForBuyer(DbContext As AdvantageFramework.Database.DbContext, DataTable As System.Data.DataTable, MediaBroadcastWorksheetMarketStagingDetail As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail,
                                            MediaBroadcastWorksheetMarketStagingDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail),
                                            MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel,
                                            MediaBroadcastWorksheetMarketDetailIDs As Generic.List(Of Integer))

            'objects
            Dim NonairingDataRow As System.Data.DataRow = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim MediaBroadcastWorksheetMarketDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim SpotColumnCounter As Integer = 0
            Dim TotalSpots As Integer = 0
            Dim MediaBroadcastWorksheetMarketStagingDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate) = Nothing

            NonairingDataRow = DataTable.NewRow

            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = -MediaBroadcastWorksheetMarketStagingDetail.ID
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0") & If(MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0, "", "-" & MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber.ToString.PadLeft(2, "0"))
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = False
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = False
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = False

            NonairingDataRow.SetField(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.RowType.ToString, "Non-Airing")
            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = 0 'initialize for below

            SpotColumnCounter = 0
            TotalSpots = 0

            MediaBroadcastWorksheetMarketStagingDetailIDs = (From Entity In MediaBroadcastWorksheetMarketStagingDetails
                                                             Where Entity.MakegoodNumber <> 0 AndAlso
                                                                   Entity.LineNumber = MediaBroadcastWorksheetMarketStagingDetail.LineNumber
                                                             Select Entity.ID).ToArray

            For Each MediaBroadcastWorksheetMarketStagingDetailDate In (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.LoadByMediaBroadcastWorksheetMarketStagingDetailID(DbContext, MediaBroadcastWorksheetMarketStagingDetail.ID)
                                                                        Select Entity).OrderBy(Function(E) E.Date).ToList

                If MediaBroadcastWorksheetMarketStagingDetailDate.Date >= MakegoodDeliveryViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketStagingDetailDate.Date <= MakegoodDeliveryViewModel.MaxDate AndAlso
                                            DataTable.Columns.Contains("Spot" & SpotColumnCounter) Then

                    If MediaBroadcastWorksheetMarketStagingDetailDate.IsHiatus Then

                        NonairingDataRow("Spot" & SpotColumnCounter) = System.DBNull.Value

                    Else

                        MediaBroadcastWorksheetMarketDetailDateMakegoods = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                            Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                                                  Entity.MediaBroadcastWorksheetMarketDetail.LineNumber = MediaBroadcastWorksheetMarketStagingDetail.LineNumber
                                                                            Select Entity).ToList

                        If NonairingDataRow("Spot" & SpotColumnCounter).Equals(System.DBNull.Value) Then

                            NonairingDataRow("Spot" & SpotColumnCounter) = 0

                        End If

                        If MediaBroadcastWorksheetMarketStagingDetail.IsOriginal Then

                            If MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                   DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber AndAlso
                                                                                                   DD.MakegoodSpots > 0).Any Then

                                NonairingDataRow("Spot" & SpotColumnCounter) = -1 *
                                        MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                            DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber AndAlso
                                                                                                            DD.MakegoodSpots > 0).Sum(Function(DD) DD.MakegoodSpots)

                                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) +=
                                                    (From Entity In MediaBroadcastWorksheetMarketDetailDateMakegoods
                                                     Where Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                           Entity.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber AndAlso
                                                           Entity.MakegoodSpots > 0
                                                     Select Entity.MakegoodSpots).Sum * MediaBroadcastWorksheetMarketStagingDetailDate.Rate * -1

                            End If

                            MediaBroadcastWorksheetMarketStagingDetailDates = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                                                               Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                                                                                     Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                     Entity.MediaBroadcastWorksheetMarketStagingDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber
                                                                               Select Entity).ToList

                            If MediaBroadcastWorksheetMarketStagingDetailDates IsNot Nothing AndAlso MediaBroadcastWorksheetMarketStagingDetailDates.Count > 0 Then

                                NonairingDataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketStagingDetailDates.Sum(Function(Entity) Entity.MakegoodSpots) * -1

                                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) +=
                                        MediaBroadcastWorksheetMarketStagingDetailDates.Sum(Function(Entity) Entity.MakegoodSpots) * MediaBroadcastWorksheetMarketStagingDetailDate.Rate * -1

                            End If

                        Else

                            If (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                                      Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                                Select Entity.MakegoodSpots).Any Then

                                NonairingDataRow("Spot" & SpotColumnCounter) = -1 *
                                                    (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                                     Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                                                           Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                                                     Select Entity.MakegoodSpots).Sum

                                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) += -1 *
                                                    (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                                     Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                                                           Entity.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date
                                                     Select Entity.MakegoodSpots * Entity.Rate).Sum

                            End If

                        End If

                        NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating

                        NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions

                        TotalSpots += NonairingDataRow("Spot" & SpotColumnCounter)

                    End If

                    SpotColumnCounter += 1

                End If

            Next

            NonairingDataRow(AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.TotalSpots.ToString) = TotalSpots

            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = TotalSpots * NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString)

            NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = TotalSpots * NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString)

            If NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0 Then

                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = 0

            Else

                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                              NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) * -1

            End If

            If NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = 0 Then

                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

            Else

                NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) /
                                                                                                                                                              NonairingDataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) * 1000 * -1

            End If

            If TotalSpots <> 0 Then

                DataTable.Rows.Add(NonairingDataRow)

            End If

        End Sub
        Private Function LoadOriginalRows(DbContext As AdvantageFramework.Database.DbContext, MediaBroadcastWorksheetMarketStagingDetails As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetail),
                                          MakegoodDeliveryViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel, DataTableToClone As System.Data.DataTable,
                                          MediaBroadcastWorksheetMarketDetailIDs As Generic.List(Of Integer)) As System.Data.DataTable

            'objects
            Dim DataTable As System.Data.DataTable = Nothing
            Dim DataRow As System.Data.DataRow = Nothing
            Dim SpotColumnCounter As Integer = 0
            Dim TotalSpots As Integer = 0
            Dim TotalDollars As Decimal = 0
            Dim MediaBroadcastWorksheetMarketDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate) = Nothing
            Dim MediaBroadcastWorksheetMarketStagingDetailIDs As IEnumerable(Of Integer) = Nothing
            Dim AllMediaBroadcastWorksheetMarketDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate) = Nothing
            Dim AllMediaBroadcastWorksheetMarketStagingDetailDateMakegoods As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketStagingDetailDate) = Nothing

            DataTable = DataTableToClone.Clone

            DataTable.BeginLoadData()

            MediaBroadcastWorksheetMarketStagingDetailIDs = MediaBroadcastWorksheetMarketStagingDetails.Select(Function(SD) SD.ID).Distinct.ToArray

            AllMediaBroadcastWorksheetMarketDetailDateMakegoods = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketDetailDate.Load(DbContext)
                                                                   Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID)
                                                                   Select Entity).ToList

            AllMediaBroadcastWorksheetMarketStagingDetailDateMakegoods = (From Entity In AdvantageFramework.Database.Procedures.MediaBroadcastWorksheetMarketStagingDetailDate.Load(DbContext)
                                                                          Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID)
                                                                          Select Entity).ToList

            For Each MediaBroadcastWorksheetMarketStagingDetail In MediaBroadcastWorksheetMarketStagingDetails.Where(Function(SD) SD.MakegoodNumber = 0)

                DataRow = DataTable.NewRow

                SpotColumnCounter = 0

                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ID.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ID
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.ParentID.ToString) = System.DBNull.Value

                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Line.ToString) = MediaBroadcastWorksheetMarketStagingDetail.LineNumber.ToString.PadLeft(4, "0") & If(MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber = 0, "", "-" & MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber.ToString.PadLeft(2, "0"))
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.IsOriginal.ToString) = MediaBroadcastWorksheetMarketStagingDetail.IsOriginal
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetwork.ToString) = MediaBroadcastWorksheetMarketStagingDetail.CableNetworkStationCode
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.CableNetworkCode.ToString) = If(MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode Is Nothing, System.DBNull.Value, MediaBroadcastWorksheetMarketStagingDetail.CableNetworkNielsenTVStationCode)
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Days.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Days
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.StartTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.StartTime
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.EndTime.ToString) = MediaBroadcastWorksheetMarketStagingDetail.EndTime
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Program.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Program

                If MediaBroadcastWorksheetMarketStagingDetail.DaypartID.HasValue Then

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DayPartID.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DaypartID

                End If

                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Length.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Length
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Bookend.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Bookend
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.AddedValue.ToString) = MediaBroadcastWorksheetMarketStagingDetail.ValueAdded
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.Comments.ToString) = MediaBroadcastWorksheetMarketStagingDetail.Comments
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.DefaultRate.ToString) = MediaBroadcastWorksheetMarketStagingDetail.DefaultRate

                TotalSpots = 0
                TotalDollars = 0

                For Each MediaBroadcastWorksheetMarketStagingDetailDate In (From Entity In AllMediaBroadcastWorksheetMarketStagingDetailDateMakegoods
                                                                            Where Entity.MediaBroadcastWorksheetMarketStagingDetailID = MediaBroadcastWorksheetMarketStagingDetail.ID
                                                                            Select Entity).OrderBy(Function(E) E.Date).ToList

                    If MediaBroadcastWorksheetMarketStagingDetailDate.Date >= MakegoodDeliveryViewModel.MinDate AndAlso MediaBroadcastWorksheetMarketStagingDetailDate.Date <= MakegoodDeliveryViewModel.MaxDate AndAlso
                                    DataTable.Columns.Contains("Spot" & SpotColumnCounter) Then

                        If MediaBroadcastWorksheetMarketStagingDetailDate.IsHiatus Then

                            DataRow("Spot" & SpotColumnCounter) = 0
                            DataRow("Rate" & SpotColumnCounter) = 0

                        Else

                            DataRow("Spot" & SpotColumnCounter) = 0

                            MediaBroadcastWorksheetMarketDetailDateMakegoods = (From Entity In AllMediaBroadcastWorksheetMarketDetailDateMakegoods
                                                                                Where MediaBroadcastWorksheetMarketDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketDetailID) AndAlso
                                                                                      Entity.MediaBroadcastWorksheetMarketDetail.LineNumber = MediaBroadcastWorksheetMarketStagingDetail.LineNumber
                                                                                Select Entity).ToList

                            'MediaBroadcastWorksheetMarketStagingDetailIDs = MediaBroadcastWorksheetMarketStagingDetails.Select(Function(SD) SD.ID).Distinct.ToArray

                            MediaBroadcastWorksheetMarketStagingDetailDateMakegoods = (From Entity In AllMediaBroadcastWorksheetMarketStagingDetailDateMakegoods
                                                                                       Where MediaBroadcastWorksheetMarketStagingDetailIDs.Contains(Entity.MediaBroadcastWorksheetMarketStagingDetailID) AndAlso
                                                                                             Entity.MediaBroadcastWorksheetMarketStagingDetail.LineNumber = MediaBroadcastWorksheetMarketStagingDetail.LineNumber
                                                                                       Select Entity).ToList

                            If MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                   DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber).Any Then

                                DataRow("Spot" & SpotColumnCounter) +=
                                        MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                            DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber).Sum(Function(DD) DD.MakegoodSpots)

                                TotalDollars +=
                                        MediaBroadcastWorksheetMarketDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                            DD.MediaBroadcastWorksheetMarketDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber).Sum(Function(DD) DD.MakegoodSpots) * MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                            End If

                            DataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketStagingDetailDate.Spots

                            TotalDollars += MediaBroadcastWorksheetMarketStagingDetailDate.Spots * MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                            If MediaBroadcastWorksheetMarketStagingDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                          DD.MediaBroadcastWorksheetMarketStagingDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber AndAlso
                                                                                                          DD.MakegoodSpots > 0).Any Then

                                DataRow("Spot" & SpotColumnCounter) += MediaBroadcastWorksheetMarketStagingDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                      DD.MediaBroadcastWorksheetMarketStagingDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber AndAlso
                                                                                                      DD.MakegoodSpots > 0).Sum(Function(DD) DD.MakegoodSpots)

                                TotalDollars += MediaBroadcastWorksheetMarketStagingDetailDateMakegoods.Where(Function(DD) DD.Date = MediaBroadcastWorksheetMarketStagingDetailDate.Date AndAlso
                                                                                                      DD.MediaBroadcastWorksheetMarketStagingDetail.MadegoodNumber = MediaBroadcastWorksheetMarketStagingDetail.MakegoodNumber AndAlso
                                                                                                      DD.MakegoodSpots > 0).Sum(Function(DD) DD.MakegoodSpots) * MediaBroadcastWorksheetMarketStagingDetailDate.Rate

                            End If

                            TotalSpots += DataRow("Spot" & SpotColumnCounter)

                        End If

                        SpotColumnCounter += 1

                    End If

                Next

                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalSpots.ToString) = TotalSpots
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.TotalGross.ToString) = TotalDollars

                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryRating
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryImpressions.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions
                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = TotalSpots * DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryRating.ToString)

                If MakegoodDeliveryViewModel.MediaType = "T" Then

                    'DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = FormatNumber(MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots / 1000, 1)
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots / 1000

                Else

                    'DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = FormatNumber(MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots / 100, 0)
                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGIMP.ToString) = MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots / 100

                End If

                DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPP.ToString) = If(DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString) = 0, 0, Math.Round(TotalDollars / DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryGRP.ToString), 2))

                If MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots = 0 Then

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = 0

                Else

                    DataRow(AdvantageFramework.Controller.Media.MakegoodDeliveryController.StagingDataColumns.PrimaryCPM.ToString) = Math.Round((TotalDollars / (MediaBroadcastWorksheetMarketStagingDetail.PrimaryImpressions * TotalSpots) * 1000), 2)

                End If

                DataTable.Rows.Add(DataRow)

            Next

            DataTable.EndLoadData()

            LoadOriginalRows = DataTable

        End Function
        Public Sub SaveGrid(ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel)

            Dim GridAdvantage As AdvantageFramework.Database.Entities.GridAdvantage = Nothing

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If ViewModel.GridAdvantage.ID > 0 Then

                    GridAdvantage = AdvantageFramework.Database.Procedures.GridAdvantage.LoadByGridAdvantageID(DataContext, ViewModel.GridAdvantage.ID)

                End If

                If GridAdvantage IsNot Nothing Then

                    ViewModel.GridAdvantage.SaveToEntity(GridAdvantage)

                    AdvantageFramework.Database.Procedures.GridAdvantage.Update(DataContext, GridAdvantage)

                Else

                    GridAdvantage = New AdvantageFramework.Database.Entities.GridAdvantage
                    GridAdvantage.DataContext = DataContext

                    ViewModel.GridAdvantage.SaveToEntity(GridAdvantage)

                    AdvantageFramework.Database.Procedures.GridAdvantage.Insert(DataContext, GridAdvantage)

                End If

            End Using

        End Sub
        Public Sub RestoreDefaults(ByRef ViewModel As AdvantageFramework.ViewModels.Media.MakegoodDeliveryViewModel)

            Dim MediaType As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.MediaTypes = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotRadio

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                If ViewModel.MediaType = "T" Then

                    MediaType = DTO.Media.MediaBroadcastWorksheet.Methods.MediaTypes.SpotTV

                End If

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.MediaBroadcastWorksheetMakegoodOffers, Session.UserCode, MediaType)

                RefreshGridAdvantage(DataContext, MediaType, ViewModel)

            End Using

        End Sub

#End Region

#Region " Responses "

        Public Function Response_Load(MediaBroadcastWorksheetmarketDetailIDs As IEnumerable(Of Integer)) As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheetMakegoodResponseViewModel

            'objects
            Dim MediaBroadcastWorksheetMakegoodResponseViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheetMakegoodResponseViewModel = Nothing
            Dim AlertIDs As IEnumerable(Of Integer) = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient) = Nothing

            MediaBroadcastWorksheetMakegoodResponseViewModel = New AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheetMakegoodResponseViewModel

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaBroadcastWorksheetMakegoodResponseViewModel.IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                MediaBroadcastWorksheetMakegoodResponseViewModel.OrderAlertComments = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.OrderAlertComment)(String.Format("exec dbo.advsp_media_broadcast_worksheet_order_alert_comments '{0}'", String.Join(",", MediaBroadcastWorksheetmarketDetailIDs.ToArray))).ToList

                If Session.User IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Session.User.EmployeeCode) Then

                    AlertIDs = (From Entity In MediaBroadcastWorksheetMakegoodResponseViewModel.OrderAlertComments
                                Select Entity.AlertID).ToArray

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

            Response_Load = MediaBroadcastWorksheetMakegoodResponseViewModel

        End Function

#End Region

#End Region

    End Class

End Namespace
