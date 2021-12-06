Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarket
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetID
			MarketCode
			MarketDescription
			MarketNielsenTVCode
            MarketNielsenTVDMACode
            MarketComscoreMarketNumber
            MarketNielsenRadioCode
			MarketNielsenBlackRadioCode
			MarketNielsenHispanicRadioCode
			BuyerEmployeeCode
            BuyerEmployeeName
            ExternalRadioSource
            SharebookNielsenTVBookID
			HUTPUTNielsenTVBookID
            SecondaryMediaDemographicID
            HasData
            MaxRevisionOrderStatus
            OrderStatus
			IsCable
			MediaBroadcastWorksheetMarketTVGeographyID
			MediaBroadcastWorksheetMarketRadioEthnicityID
			MediaBroadcastWorksheetMarketRadioGeographyID
			NeilsenRadioPeriodID1
			NeilsenRadioPeriodID2
			NeilsenRadioPeriodID3
			NeilsenRadioPeriodID4
            NeilsenRadioPeriodID5
            PeriodStart
            PeriodEnd
            CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
            ModifiedDate
            Length
            GoalTotalGRP
            GoalTotalBudgetAmount
            ShowVendorDemos
            LockedByUserCode
            CreateOrdersByWeek
            PendingMakegood
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="WS ID", IsReadOnlyColumn:=True)>
        Public Property MediaBroadcastWorksheetID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ID() As Integer
        <Required>
		<MaxLength(10)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode)>
		Public Property MarketCode() As String
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
		Public Property MarketDescription() As String
		<MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
		Public Property MarketNielsenTVCode As String
		<MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Nielsen TV DMA Code")>
        Public Property MarketNielsenTVDMACode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MarketComscoreMarketNumber As Nullable(Of Short)
        <MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
		Public Property MarketNielsenRadioCode As String
		<MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
		Public Property MarketNielsenBlackRadioCode As String
		<MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MarketNielsenHispanicRadioCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MarketEastlanRadioCode As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MarketEastlanBlackRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MarketEastlanHispanicRadioCode As Nullable(Of Short)
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.BuyerEmployeeCode, CustomColumnCaption:="Buyer Code")>
        Public Property BuyerEmployeeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Buyer Name")>
        Public Property BuyerEmployeeName() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Source")>
        Public Property ExternalRadioSource() As AdvantageFramework.Nielsen.Database.Entities.RadioSource
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.NielsenTVBook, CustomColumnCaption:="Share Book")>
        Public Property SharebookNielsenTVBookID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, PropertyType:=BaseClasses.PropertyTypes.NielsenTVBook, CustomColumnCaption:="H/PUT Book")>
        Public Property HUTPUTNielsenTVBookID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SecondaryMediaDemographicID() As Nullable(Of Integer)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property HasData() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Ordered")>
        Public Property MaxRevisionOrderStatus As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Ordered")>
        Public Property OrderStatus As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsCable() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Geography")>
        Public Property MediaBroadcastWorksheetMarketTVGeographyID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Geography")>
        Public Property MediaBroadcastWorksheetMarketRadioGeographyID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Ethnicity")>
        Public Property MediaBroadcastWorksheetMarketRadioEthnicityID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.NielsenRadioPeriod, CustomColumnCaption:="Book 1")>
        Public Property NeilsenRadioPeriodID1() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.NielsenRadioPeriod, CustomColumnCaption:="Book 2")>
        Public Property NeilsenRadioPeriodID2() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.NielsenRadioPeriod, CustomColumnCaption:="Book 3")>
        Public Property NeilsenRadioPeriodID3() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.NielsenRadioPeriod, CustomColumnCaption:="Book 4")>
        Public Property NeilsenRadioPeriodID4() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.NielsenRadioPeriod, CustomColumnCaption:="Book 5")>
        Public Property NeilsenRadioPeriodID5() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PeriodStart() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PeriodEnd() As Nullable(Of Date)
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CreatedByUserCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CreatedDate() As Date
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ModifiedByUserCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Length() As Short
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GoalTotalGRP As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property GoalTotalBudgetAmount As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ShowVendorDemos() As Boolean
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LockedByUserCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CreateOrdersByWeek() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property PendingMakegood() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MarketComscoreNewMarketNumber As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaBroadcastWorksheetID = 0
            Me.MarketCode = String.Empty
            Me.MarketDescription = String.Empty
            Me.BuyerEmployeeCode = Nothing
            Me.BuyerEmployeeName = String.Empty
            Me.ExternalRadioSource = AdvantageFramework.Nielsen.Database.Entities.RadioSource.Nielsen
            Me.MarketNielsenTVCode = String.Empty
            Me.MarketNielsenTVDMACode = String.Empty
            Me.MarketNielsenRadioCode = String.Empty
            Me.MarketNielsenBlackRadioCode = String.Empty
            Me.MarketNielsenHispanicRadioCode = String.Empty
            Me.MarketEastlanRadioCode = Nothing
            Me.MarketEastlanBlackRadioCode = Nothing
            Me.MarketEastlanHispanicRadioCode = Nothing
            Me.SharebookNielsenTVBookID = Nothing
            Me.HUTPUTNielsenTVBookID = Nothing
            Me.SecondaryMediaDemographicID = Nothing
            Me.HasData = False
            Me.MaxRevisionOrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered
            Me.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered
            Me.IsCable = False
            Me.MediaBroadcastWorksheetMarketTVGeographyID = Nothing
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = Nothing
            Me.MediaBroadcastWorksheetMarketRadioGeographyID = Nothing
            Me.NeilsenRadioPeriodID1 = Nothing
            Me.NeilsenRadioPeriodID2 = Nothing
            Me.NeilsenRadioPeriodID3 = Nothing
            Me.NeilsenRadioPeriodID4 = Nothing
            Me.NeilsenRadioPeriodID5 = Nothing
            Me.PeriodStart = Nothing
            Me.PeriodEnd = Nothing
            Me.CreatedByUserCode = String.Empty
            Me.CreatedDate = Date.MinValue
            Me.ModifiedByUserCode = Nothing
            Me.ModifiedDate = Nothing
            Me.Length = 0
            Me.GoalTotalGRP = 0
            Me.GoalTotalBudgetAmount = 0
            Me.ShowVendorDemos = False
            Me.LockedByUserCode = String.Empty
            Me.CreateOrdersByWeek = False

        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext, MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket)

            'objects
            Dim WorksheetMarketDetailDateOrderStatuses As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateOrderStatus) = Nothing
            Dim MaxRevisionWorksheetMarketDetailDateOrderStatuses As Generic.List(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateOrderStatus) = Nothing
            Dim RevisionNumber As Integer = 0

            Me.ID = MediaBroadcastWorksheetMarket.ID
            Me.MediaBroadcastWorksheetID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetID
            Me.MarketCode = MediaBroadcastWorksheetMarket.MarketCode
            Me.MarketDescription = MediaBroadcastWorksheetMarket.Market.Description
            Me.MarketNielsenTVCode = MediaBroadcastWorksheetMarket.Market.NielsenTVCode
            Me.MarketNielsenTVDMACode = MediaBroadcastWorksheetMarket.Market.NielsenTVDMACode
            Me.MarketNielsenRadioCode = MediaBroadcastWorksheetMarket.Market.NielsenRadioCode
            Me.MarketNielsenBlackRadioCode = MediaBroadcastWorksheetMarket.Market.NielsenBlackRadioCode
            Me.MarketNielsenHispanicRadioCode = MediaBroadcastWorksheetMarket.Market.NielsenHispanicRadioCode
            Me.MarketEastlanRadioCode = MediaBroadcastWorksheetMarket.Market.EastlanRadioCode
            Me.MarketEastlanBlackRadioCode = MediaBroadcastWorksheetMarket.Market.EastlanBlackRadioCode
            Me.MarketEastlanHispanicRadioCode = MediaBroadcastWorksheetMarket.Market.EastlanHispanicRadioCode
            Me.MarketComscoreMarketNumber = MediaBroadcastWorksheetMarket.Market.ComscoreMarketNumber
            Me.MarketComscoreNewMarketNumber = MediaBroadcastWorksheetMarket.Market.ComscoreNewMarketNumber
            Me.BuyerEmployeeCode = MediaBroadcastWorksheetMarket.BuyerEmployeeCode
            Me.BuyerEmployeeName = If(MediaBroadcastWorksheetMarket.BuyerEmployee IsNot Nothing, MediaBroadcastWorksheetMarket.BuyerEmployee.ToString, String.Empty)
            Me.ExternalRadioSource = MediaBroadcastWorksheetMarket.ExternalRadioSource
            Me.SharebookNielsenTVBookID = MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID
            Me.HUTPUTNielsenTVBookID = MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID
            Me.SecondaryMediaDemographicID = MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID

            WorksheetMarketDetailDateOrderStatuses = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarketDetailDateOrderStatus)(String.Format("EXEC [dbo].[advsp_media_broadcast_worksheet_market_order_status] {0}", MediaBroadcastWorksheetMarket.ID)).ToList

            If WorksheetMarketDetailDateOrderStatuses IsNot Nothing AndAlso WorksheetMarketDetailDateOrderStatuses.Count > 0 Then

                Me.HasData = True

                If WorksheetMarketDetailDateOrderStatuses.All(Function(Entity) Entity.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered) Then

                    Me.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered

                ElseIf WorksheetMarketDetailDateOrderStatuses.Any(Function(Entity) Entity.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified) Then

                    Me.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified

                ElseIf WorksheetMarketDetailDateOrderStatuses.All(Function(Entity) Entity.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered OrElse
                                                                                   (Entity.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered AndAlso Entity.Spots = 0)) Then

                    Me.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered

                Else

                    Me.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial

                End If

                RevisionNumber = WorksheetMarketDetailDateOrderStatuses.Select(Function(Entity) Entity.RevisionNumber).Max

                MaxRevisionWorksheetMarketDetailDateOrderStatuses = WorksheetMarketDetailDateOrderStatuses.Where(Function(Entity) Entity.RevisionNumber = RevisionNumber).ToList

                If MaxRevisionWorksheetMarketDetailDateOrderStatuses.All(Function(Entity) Entity.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered) Then

                    Me.MaxRevisionOrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered

                ElseIf MaxRevisionWorksheetMarketDetailDateOrderStatuses.Any(Function(Entity) Entity.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified) Then

                    Me.MaxRevisionOrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.OrderedModified

                ElseIf MaxRevisionWorksheetMarketDetailDateOrderStatuses.All(Function(Entity) Entity.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered OrElse
                                                                                              (Entity.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered AndAlso Entity.Spots = 0)) Then

                    Me.MaxRevisionOrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Ordered

                Else

                    Me.MaxRevisionOrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Partial

                End If

            Else

                Me.HasData = False

                Me.MaxRevisionOrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered
                Me.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered

            End If

            Me.IsCable = MediaBroadcastWorksheetMarket.IsCable
            Me.MediaBroadcastWorksheetMarketTVGeographyID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketTVGeographyID
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID
            Me.MediaBroadcastWorksheetMarketRadioGeographyID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioGeographyID
            Me.NeilsenRadioPeriodID1 = MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1
            Me.NeilsenRadioPeriodID2 = MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID2
            Me.NeilsenRadioPeriodID3 = MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID3
            Me.NeilsenRadioPeriodID4 = MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID4
            Me.NeilsenRadioPeriodID5 = MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID5
            Me.PeriodStart = MediaBroadcastWorksheetMarket.PeriodStart
            Me.PeriodEnd = MediaBroadcastWorksheetMarket.PeriodEnd
            Me.CreatedByUserCode = MediaBroadcastWorksheetMarket.CreatedByUserCode
            Me.CreatedDate = MediaBroadcastWorksheetMarket.CreatedDate
            Me.ModifiedByUserCode = MediaBroadcastWorksheetMarket.ModifiedByUserCode
            Me.ModifiedDate = MediaBroadcastWorksheetMarket.ModifiedDate
            Me.Length = MediaBroadcastWorksheetMarket.Length
            Me.GoalTotalGRP = MediaBroadcastWorksheetMarket.GoalTotalGRP
            Me.GoalTotalBudgetAmount = MediaBroadcastWorksheetMarket.GoalTotalBudgetAmount
            Me.ShowVendorDemos = MediaBroadcastWorksheetMarket.ShowVendorDemos
            Me.LockedByUserCode = MediaBroadcastWorksheetMarket.LockedByUserCode
            Me.CreateOrdersByWeek = MediaBroadcastWorksheetMarket.CreateOrdersByWeek

            If Me.LockedByUserCode Is Nothing Then

                Me.LockedByUserCode = String.Empty

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket)

			MediaBroadcastWorksheetMarket.ID = Me.ID
			MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetID = Me.MediaBroadcastWorksheetID
			MediaBroadcastWorksheetMarket.MarketCode = Me.MarketCode
            MediaBroadcastWorksheetMarket.BuyerEmployeeCode = Me.BuyerEmployeeCode
            MediaBroadcastWorksheetMarket.ExternalRadioSource = Me.ExternalRadioSource
            MediaBroadcastWorksheetMarket.SharebookNielsenTVBookID = Me.SharebookNielsenTVBookID
			MediaBroadcastWorksheetMarket.HUTPUTNielsenTVBookID = Me.HUTPUTNielsenTVBookID
			MediaBroadcastWorksheetMarket.SecondaryMediaDemographicID = Me.SecondaryMediaDemographicID
			MediaBroadcastWorksheetMarket.IsCable = Me.IsCable
			MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketTVGeographyID = Me.MediaBroadcastWorksheetMarketTVGeographyID
			MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID = Me.MediaBroadcastWorksheetMarketRadioEthnicityID
			MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioGeographyID = Me.MediaBroadcastWorksheetMarketRadioGeographyID
			MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID1 = Me.NeilsenRadioPeriodID1
			MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID2 = Me.NeilsenRadioPeriodID2
			MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID3 = Me.NeilsenRadioPeriodID3
			MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID4 = Me.NeilsenRadioPeriodID4
            MediaBroadcastWorksheetMarket.NeilsenRadioPeriodID5 = Me.NeilsenRadioPeriodID5
            MediaBroadcastWorksheetMarket.PeriodStart = Me.PeriodStart
            MediaBroadcastWorksheetMarket.PeriodEnd = Me.PeriodEnd
            MediaBroadcastWorksheetMarket.CreatedByUserCode = Me.CreatedByUserCode
			MediaBroadcastWorksheetMarket.CreatedDate = Me.CreatedDate
			MediaBroadcastWorksheetMarket.ModifiedByUserCode = Me.ModifiedByUserCode
			MediaBroadcastWorksheetMarket.ModifiedDate = Me.ModifiedDate
            MediaBroadcastWorksheetMarket.Length = Me.Length
            MediaBroadcastWorksheetMarket.GoalTotalGRP = Me.GoalTotalGRP
            MediaBroadcastWorksheetMarket.GoalTotalBudgetAmount = Me.GoalTotalBudgetAmount
            MediaBroadcastWorksheetMarket.ShowVendorDemos = Me.ShowVendorDemos
            MediaBroadcastWorksheetMarket.CreateOrdersByWeek = Me.CreateOrdersByWeek

        End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

    End Class

End Namespace
