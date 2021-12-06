Namespace Database.Entities

	<Table("MEDIA_BROADCAST_WORKSHEET_MARKET")>
	Public Class MediaBroadcastWorksheetMarket
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetID
			MarketCode
			BuyerEmployeeCode
			SharebookNielsonTVBookID
			HUTPUTNielsonTVBookID
			SecondaryMediaDemographicID
			IsCable
			MediaBroadcastWorksheetMarketTVGeographyID
			MediaBroadcastWorksheetMarketRadioEthnicityID
			MediaBroadcastWorksheetMarketRadioGeographyID
			NeilsenRadioPeriodID1
			NeilsenRadioPeriodID2
			NeilsenRadioPeriodID3
			NeilsenRadioPeriodID4
			NeilsenRadioPeriodID5
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
            ModifiedDate
            Length
            GoalTotalGRP
            GoalTotalBudgetAmount
            ShowVendorDemos
            ExternalRadioSource
            RFPGuidelines
            TrafficGuidelines
            LockedByUserCode
            CreateOrdersByWeek
            PeriodStart
            PeriodEnd
            MediaBroadcastWorksheet
			Market
			BuyerEmployee
			MediaBroadcastWorksheetMarketDetails
			SecondaryMediaDemographic
			MediaBroadcastWorksheetMarketGoals
			MediaBroadcastWorksheetMarketRevisions
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetID() As Integer
		<Required>
		<MaxLength(10)>
		<Column("MARKET_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode)>
		Public Property MarketCode() As String
		<MaxLength(6)>
		<Column("BUYER_EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.BuyerEmployeeCode)>
		Public Property BuyerEmployeeCode() As String
		<Column("SHAREBOOK_NIELSEN_TV_BOOK_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SharebookNielsenTVBookID() As Nullable(Of Integer)
		<Column("HUTPUT_NIELSEN_TV_BOOK_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property HUTPUTNielsenTVBookID() As Nullable(Of Integer)
		<Column("SECONDARY_MEDIA_DEMO_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SecondaryMediaDemographicID() As Nullable(Of Integer)
		<Required>
		<Column("IS_CABLE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property IsCable() As Boolean
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_TV_GEOGRAPHY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketTVGeographyID() As Nullable(Of Integer)
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_GEOGRAPHY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketRadioGeographyID() As Nullable(Of Integer)
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketRadioEthnicityID() As Nullable(Of Integer)
		<Column("NIELSEN_RADIO_PERIOD_ID1")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NeilsenRadioPeriodID1() As Nullable(Of Integer)
		<Column("NIELSEN_RADIO_PERIOD_ID2")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NeilsenRadioPeriodID2() As Nullable(Of Integer)
		<Column("NIELSEN_RADIO_PERIOD_ID3")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NeilsenRadioPeriodID3() As Nullable(Of Integer)
		<Column("NIELSEN_RADIO_PERIOD_ID4")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NeilsenRadioPeriodID4() As Nullable(Of Integer)
		<Column("NIELSEN_RADIO_PERIOD_ID5")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property NeilsenRadioPeriodID5() As Nullable(Of Integer)
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
        <Required>
        <Column("LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Length() As Short
        <Required>
        <Column("GOAL_TOTAL_GRP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
        Public Property GoalTotalGRP As Decimal
        <Required>
        <Column("GOAL_TOTAL_BUDGET_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
        Public Property GoalTotalBudgetAmount As Decimal
        <Required>
        <Column("SHOW_VENDOR_DEMOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ShowVendorDemos() As Boolean
        <Required>
        <Column("EXTERNAL_RADIO_SOURCE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ExternalRadioSource() As Short
        <Column("RFP_GUIDELINES", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RFPGuidelines() As String
        <MaxLength(100)>
        <Column("LOCKED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property LockedByUserCode() As String
        <Column("TRAFFIC_GUIDELINES", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TrafficGuidelines() As String
        <Required>
        <Column("CREATE_ORDERS_BY_WEEK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreateOrdersByWeek() As Boolean
        <Column("PERIOD_START")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PeriodStart() As Nullable(Of Date)
        <Column("PERIOD_END")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PeriodEnd() As Nullable(Of Date)

        Public Overridable Property MediaBroadcastWorksheet As Database.Entities.MediaBroadcastWorksheet
		Public Overridable Property Market As Database.Entities.Market
		<ForeignKey("BuyerEmployeeCode")>
		Public Overridable Property BuyerEmployee As Database.Views.Employee
		Public Overridable Property MediaBroadcastWorksheetMarketDetails As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketDetail)
		<ForeignKey("SecondaryMediaDemographicID")>
		Public Overridable Property SecondaryMediaDemographic As Database.Entities.MediaDemographic
		Public Overridable Property MediaBroadcastWorksheetMarketGoals As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketGoal)
        Public Overridable Property MediaBroadcastWorksheetMarketRevisions As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketRevision)

        Public ReadOnly Property NeilsenRadioPeriodIDs() As Generic.List(Of Integer)
            Get

                Dim BookIDs As Generic.List(Of Integer) = Nothing

                BookIDs = New Generic.List(Of Integer)

                If Me.NeilsenRadioPeriodID1.HasValue Then

                    BookIDs.Add(Me.NeilsenRadioPeriodID1.Value)

                End If

                If Me.NeilsenRadioPeriodID2.HasValue Then

                    BookIDs.Add(Me.NeilsenRadioPeriodID2.Value)

                End If

                If Me.NeilsenRadioPeriodID3.HasValue Then

                    BookIDs.Add(Me.NeilsenRadioPeriodID3.Value)

                End If

                If Me.NeilsenRadioPeriodID4.HasValue Then

                    BookIDs.Add(Me.NeilsenRadioPeriodID4.Value)

                End If

                If Me.NeilsenRadioPeriodID5.HasValue Then

                    BookIDs.Add(Me.NeilsenRadioPeriodID5.Value)

                End If

                NeilsenRadioPeriodIDs = BookIDs

            End Get
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function
        Public Function GetNeilsenRadioPeriodIDs() As Generic.List(Of String)

            Dim BookIDs As Generic.List(Of String) = Nothing

            BookIDs = New Generic.List(Of String)

            If Me.NeilsenRadioPeriodID1.HasValue Then

                BookIDs.Add(Me.NeilsenRadioPeriodID1.Value)

            End If

            If Me.NeilsenRadioPeriodID2.HasValue Then

                BookIDs.Add(Me.NeilsenRadioPeriodID2.Value)

            End If

            If Me.NeilsenRadioPeriodID3.HasValue Then

                BookIDs.Add(Me.NeilsenRadioPeriodID3.Value)

            End If

            If Me.NeilsenRadioPeriodID4.HasValue Then

                BookIDs.Add(Me.NeilsenRadioPeriodID4.Value)

            End If

            If Me.NeilsenRadioPeriodID5.HasValue Then

                BookIDs.Add(Me.NeilsenRadioPeriodID5.Value)

            End If

            GetNeilsenRadioPeriodIDs = BookIDs

        End Function

#End Region

    End Class

End Namespace
