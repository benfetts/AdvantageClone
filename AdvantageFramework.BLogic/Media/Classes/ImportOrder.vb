Namespace Media.Classes

    <Serializable()>
    Public Class ImportOrder
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            OrderID
            LineNumber
            MediaPlanParentPackage
            MediaPlanPackage
            RevNbr
            MediaType
            MediaPlanOrderDescription
            LineDescription
            ClientCode
            DivisionCode
            ProductCode
            Campaign
            VendorCode
            StartDate
            EndDate
            NetGross
            NetRate
            GrossRate
            TotalSpots
            CostType
            SalesClassCode
            Cost
            NetCharge
            AddAmount
            MarkupPercent
            CampaignCode
            MediaNetAmount
            ClientPO
            RateType
            ImportAccountPayableMediaID
            MediaPlanDetailLevelLineDataIDs
            MediaPlanOrderComment
            MediaPlanBuyer
            MediaPlanMarketCode
            MediaPlanMarketDescription
            MediaPlanOrderLineMarketCode
            MediaPlanOrderLineMarketDescription
            MediaPlanAdSizeCode
            MediaPlanAdSizeDescription
            MediaPlanAdNumber
            MediaPlanHeadline
            MediaPlanIssue
            MediaPlanInternetType
            MediaPlanPlacement
            MediaPlanOutOfHomeType
            MediaPlanDaypart
            MediaPlanStartTime
            MediaPlanEndTime
            MediaPlanLength
            MediaPlanProgramming
            MediaPlanNetworkCode
            'IsSourceMediaPlanning
            IsRevision
            MediaPlanAirDate
            ImportSource
            MediaPlanURL
            MediaPlanTargetAudience
            MediaPlanSection
            MediaPlanMaterialNotes
            MediaPlanLocation
			MediaPlanOrderCopy
			MediaPlanMaterial
			MediaPlanPositionInfo
            MediaPlanCloseInfo
            MediaPlanRateInfo
            MediaPlanMiscInfo
            MediaPlanJobNumber
            MediaPlanJobComponentNumber
            CalendarType
            UserCode
			MediaPlanRemarks
			Spots1
			Spots2
			Spots3
			Spots4
			Spots5
			Spots6
			CableNetworkStationID
			DaypartID
			ValueAdded
            Bookend
            MediaPlanColumns
            MediaPlanInches
            MediaPlanMediaChannelID
            MediaPlanMediaTacticID
            MediaBroadcastWorksheetStationID
        End Enum

#End Region

#Region " Variables "

        Private _OrderID As Nullable(Of Integer) = Nothing
        Private _LineNumber As Nullable(Of Short) = Nothing
        Private _LineDescription As String = Nothing
        Private _MediaType As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _NetGross As Nullable(Of Integer) = Nothing
        Private _CommPct As Nullable(Of Decimal) = Nothing
        Private _NetRate As Nullable(Of Decimal) = Nothing
        Private _GrossRate As Nullable(Of Decimal) = Nothing
        Private _TotalSpots As Nullable(Of Integer) = Nothing
        Private _ImportAccountPayableMediaID As Nullable(Of Integer) = Nothing
        Private _RateType As String = Nothing
        Private _CostType As String = Nothing
        Private _Cost As Nullable(Of Decimal) = Nothing
        Private _MediaNetAmount As Nullable(Of Decimal) = Nothing
        Private _Columns As Nullable(Of Decimal) = Nothing
        Private _Inches As Nullable(Of Decimal) = Nothing
        Private _LinesCirculation As Nullable(Of Integer) = Nothing
        Private _NetCharge As Nullable(Of Decimal) = Nothing
        Private _AddAmount As Nullable(Of Decimal) = Nothing
        Private _MarkupPercent As Nullable(Of Decimal) = Nothing
        Private _CampaignCode As String = Nothing
        Private _ClientPO As String = Nothing
        Private _MediaPlanDetailLevelLineDataIDs As String = Nothing
        Private _MediaPlanOrderDescription As String = Nothing
        Private _MediaPlanOrderComment As String = Nothing
        Private _MediaPlanBuyer As String = Nothing
        Private _MediaPlanMarketCode As String = Nothing
        Private _MediaPlanMarketDescription As String = Nothing
        Private _MediaPlanAdSizeCode As String = Nothing
        Private _MediaPlanAdSizeDescription As String = Nothing
        Private _MediaPlanAdNumber As String = Nothing
        Private _MediaPlanHeadline As String = Nothing
        Private _MediaPlanIssue As String = Nothing
        Private _MediaPlanInternetType As String = Nothing
        Private _MediaPlanPlacement As String = Nothing
        Private _MediaPlanOutOfHomeType As String = Nothing
        Private _MediaPlanDaypart As String = Nothing
        Private _MediaPlanStartTime As String = Nothing
        Private _MediaPlanEndTime As String = Nothing
        Private _MediaPlanLength As String = Nothing
        Private _MediaPlanProgramming As String = Nothing
        Private _MediaPlanNetworkCode As String = Nothing
        'Private _IsSourceMediaPlanning As Boolean = False
        Private _IsRevision As Boolean = False
        Private _MediaPlanAirDate As Nullable(Of Date) = Nothing
        Private _ImportSource As AdvantageFramework.Media.ImportSource = Methods.ImportSource.Default
        Private _MediaPlanURL As String = Nothing
        Private _MediaPlanTargetAudience As String = Nothing
		Private _MediaPlanSection As String = Nothing
		Private _MediaPlanMaterial As String = Nothing
		Private _MediaPlanLocation As String = Nothing
		Private _MediaPlanOrderCopy As String = Nothing
		Private _MediaPlanMaterialNotes As String = Nothing
		Private _MediaPlanPositionInfo As String = Nothing
        Private _MediaPlanCloseInfo As String = Nothing
        Private _MediaPlanRateInfo As String = Nothing
        Private _MediaPlanMiscInfo As String = Nothing
        Private _MediaPlanJobNumber As Nullable(Of Integer) = Nothing
        Private _MediaPlanJobComponentNumber As Nullable(Of Short) = Nothing
        Private _MediaPlanMonday As Boolean = False
        Private _MediaPlanTuesday As Boolean = False
        Private _MediaPlanWednesday As Boolean = False
        Private _MediaPlanThursday As Boolean = False
        Private _MediaPlanFriday As Boolean = False
        Private _MediaPlanSaturday As Boolean = False
        Private _MediaPlanSunday As Boolean = False
        Private _OrderNumber As Nullable(Of Integer) = Nothing
        Private _OrderLineNumber As Nullable(Of Integer) = Nothing
        Private _CalendarType As String = Nothing
        Private _UserCode As String = Nothing
		Private _MediaPlanRemarks As String = Nothing

#End Region

#Region " Properties "

		<System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderID() As Nullable(Of Integer)
            Get
                OrderID = _OrderID
            End Get
            Set(value As Nullable(Of Integer))
                _OrderID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Nullable(Of Short)
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Nullable(Of Short))
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Parent Package")>
        Public Property MediaPlanParentPackage() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Package")>
        Public Property MediaPlanPackage() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
		Public ReadOnly Property RevNbr() As Integer
			Get
				RevNbr = 0
			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
		Public Property MediaType() As String
			Get
				MediaType = _MediaType
			End Get
			Set(value As String)
				_MediaType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Order Description")>
		Public Property MediaPlanOrderDescription() As String
			Get
				MediaPlanOrderDescription = _MediaPlanOrderDescription
			End Get
			Set(value As String)
				_MediaPlanOrderDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Line Description")>
		Public Property LineDescription() As String
			Get
				LineDescription = _LineDescription
			End Get
			Set(value As String)
				_LineDescription = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode, IsReadOnlyColumn:=True)>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(value As String)
				_ClientCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode, IsReadOnlyColumn:=True)>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(value As String)
				_DivisionCode = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode, IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Campaign() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, PropertyType:=BaseClasses.PropertyTypes.VendorCode, CustomColumnCaption:="Vendor")>
		Public Property VendorCode() As String
			Get
				VendorCode = _VendorCode
			End Get
			Set(value As String)
				_VendorCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property StartDate() As Nullable(Of Date)
			Get
				StartDate = _StartDate
			End Get
			Set(value As Nullable(Of Date))
				_StartDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property EndDate() As Nullable(Of Date)
			Get
				EndDate = _EndDate
			End Get
			Set(value As Nullable(Of Date))
				_EndDate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property NetGross() As Nullable(Of Integer)
			Get
				NetGross = _NetGross
			End Get
			Set(value As Nullable(Of Integer))
				_NetGross = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4", IsReadOnlyColumn:=True)>
		Public Property NetRate() As Nullable(Of Decimal)
			Get
				NetRate = _NetRate
			End Get
			Set(value As Nullable(Of Decimal))
				_NetRate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n4", IsReadOnlyColumn:=True)>
		Public Property GrossRate() As Nullable(Of Decimal)
			Get
				GrossRate = _GrossRate
			End Get
			Set(value As Nullable(Of Decimal))
				_GrossRate = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, CustomColumnCaption:="Quantity")>
		Public Property TotalSpots() As Nullable(Of Integer)
			Get
				TotalSpots = _TotalSpots
			End Get
			Set(value As Nullable(Of Integer))
				_TotalSpots = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CostType() As String
			Get
				CostType = _CostType
			End Get
			Set(value As String)
				_CostType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property SalesClassCode() As String
			Get
				SalesClassCode = _SalesClassCode
			End Get
			Set(value As String)
				_SalesClassCode = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
		Public ReadOnly Property Cost() As Nullable(Of Decimal)
			Get

				If Me.MediaType = "N" Then

					If Me.RateType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then

						If Me.TotalSpots <> 0 Then

							_Cost = Me.TotalSpots.GetValueOrDefault(0) * Me.NetRate.GetValueOrDefault(0) / 1000

						Else

							_Cost = _MediaNetAmount

						End If

					Else

						_Cost = _MediaNetAmount

					End If

				Else

					If Me.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then

						If Me.TotalSpots <> 0 Then

							_Cost = Me.TotalSpots.GetValueOrDefault(0) * Me.NetRate.GetValueOrDefault(0) / 1000

						Else

							_Cost = _MediaNetAmount

						End If

					Else

						_Cost = _MediaNetAmount

					End If

				End If

				Cost = _Cost

			End Get
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
		Public Property NetCharge() As Nullable(Of Decimal)
			Get
				NetCharge = _NetCharge
			End Get
			Set(value As Nullable(Of Decimal))
				_NetCharge = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True, CustomColumnCaption:="Agency Fee")>
        Public Property AddAmount() As Nullable(Of Decimal)
            Get
                AddAmount = _AddAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _AddAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n4", IsReadOnlyColumn:=True, CustomColumnCaption:="Markup Percent")>
        Public Property MarkupPercent() As Nullable(Of Decimal)
            Get
                MarkupPercent = _MarkupPercent
            End Get
            Set(value As Nullable(Of Decimal))
                _MarkupPercent = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CampaignCode() As String
            Get
                CampaignCode = _CampaignCode
            End Get
            Set(value As String)
                _CampaignCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property ClientPO() As String
			Get
				ClientPO = _ClientPO
			End Get
			Set(value As String)
				_ClientPO = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2", IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Media Amount")>
		Public Property MediaNetAmount() As Nullable(Of Decimal)
			Get
				MediaNetAmount = _MediaNetAmount
			End Get
			Set(value As Nullable(Of Decimal))
				_MediaNetAmount = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property RateType() As String
			Get
				If _RateType Is Nothing Then

					If Me.CostType = AdvantageFramework.Database.Entities.CostType.CPM.ToString Then

						_RateType = "CPM"

					Else

						_RateType = "STD"

					End If

				End If
				RateType = _RateType
			End Get
			Set(value As String)
				_RateType = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public ReadOnly Property ImportAccountPayableMediaID() As Nullable(Of Integer)
			Get
				ImportAccountPayableMediaID = _ImportAccountPayableMediaID
			End Get
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailLevelLineDataIDs() As String
			Get
				MediaPlanDetailLevelLineDataIDs = _MediaPlanDetailLevelLineDataIDs
			End Get
			Set(value As String)
				_MediaPlanDetailLevelLineDataIDs = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Order Comment")>
        Public Property MediaPlanOrderComment() As String
			Get
				MediaPlanOrderComment = _MediaPlanOrderComment
			End Get
			Set(value As String)
				_MediaPlanOrderComment = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Buyer")>
        Public Property MediaPlanBuyer() As String
            Get
                MediaPlanBuyer = _MediaPlanBuyer
            End Get
            Set(value As String)
                _MediaPlanBuyer = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Market Code")>
        Public Property MediaPlanMarketCode() As String
			Get
				MediaPlanMarketCode = _MediaPlanMarketCode
			End Get
			Set(value As String)
				_MediaPlanMarketCode = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Market Desc")>
        Public Property MediaPlanMarketDescription() As String
            Get
                MediaPlanMarketDescription = _MediaPlanMarketDescription
            End Get
            Set(value As String)
                _MediaPlanMarketDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Order Line Market Code")>
        Public Property MediaPlanOrderLineMarketCode() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="", CustomColumnCaption:="Order Line Market Desc")>
        Public Property MediaPlanOrderLineMarketDescription() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Ad Size Code")>
        Public Property MediaPlanAdSizeCode() As String
			Get
				MediaPlanAdSizeCode = _MediaPlanAdSizeCode
			End Get
			Set(value As String)
				_MediaPlanAdSizeCode = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Ad Size Desc")>
        Public Property MediaPlanAdSizeDescription() As String
			Get
				MediaPlanAdSizeDescription = _MediaPlanAdSizeDescription
			End Get
			Set(value As String)
				_MediaPlanAdSizeDescription = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Ad Number")>
        Public Property MediaPlanAdNumber() As String
			Get
				MediaPlanAdNumber = _MediaPlanAdNumber
			End Get
			Set(value As String)
				_MediaPlanAdNumber = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Headline")>
        Public Property MediaPlanHeadline() As String
			Get
				MediaPlanHeadline = _MediaPlanHeadline
			End Get
			Set(value As String)
				_MediaPlanHeadline = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Issue")>
        Public Property MediaPlanIssue() As String
			Get
				MediaPlanIssue = _MediaPlanIssue
			End Get
			Set(value As String)
				_MediaPlanIssue = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Internet Type")>
        Public Property MediaPlanInternetType() As String
			Get
				MediaPlanInternetType = _MediaPlanInternetType
			End Get
			Set(value As String)
				_MediaPlanInternetType = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Placement")>
        Public Property MediaPlanPlacement() As String
			Get
				MediaPlanPlacement = _MediaPlanPlacement
			End Get
			Set(value As String)
				_MediaPlanPlacement = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Out of Home Type")>
        Public Property MediaPlanOutOfHomeType() As String
			Get
				MediaPlanOutOfHomeType = _MediaPlanOutOfHomeType
			End Get
			Set(value As String)
				_MediaPlanOutOfHomeType = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Daypart")>
        Public Property MediaPlanDaypart() As String
			Get
				MediaPlanDaypart = _MediaPlanDaypart
			End Get
			Set(value As String)
				_MediaPlanDaypart = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Start Time")>
        Public Property MediaPlanStartTime() As String
			Get
				MediaPlanStartTime = _MediaPlanStartTime
			End Get
			Set(value As String)
				_MediaPlanStartTime = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="End Time")>
        Public Property MediaPlanEndTime() As String
			Get
				MediaPlanEndTime = _MediaPlanEndTime
			End Get
			Set(value As String)
				_MediaPlanEndTime = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Length")>
        Public Property MediaPlanLength() As String
            Get
                MediaPlanLength = _MediaPlanLength
            End Get
            Set(value As String)
                _MediaPlanLength = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Circulation")>
        Public Property MediaPlanCirculation() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Impressions")>
        Public Property MediaPlanImpressions() As Nullable(Of Integer)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Programming")>
        Public Property MediaPlanProgramming() As String
			Get
				MediaPlanProgramming = _MediaPlanProgramming
			End Get
			Set(value As String)
				_MediaPlanProgramming = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Network Code")>
        Public Property MediaPlanNetworkCode() As String
			Get
				MediaPlanNetworkCode = _MediaPlanNetworkCode
			End Get
			Set(value As String)
				_MediaPlanNetworkCode = value
			End Set
		End Property
        '<System.Runtime.Serialization.DataMemberAttribute(),
        'AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        'Public Property IsSourceMediaPlanning() As Boolean
        '    Get
        '        IsSourceMediaPlanning = _IsSourceMediaPlanning
        '    End Get
        '    Set(value As Boolean)
        '        _IsSourceMediaPlanning = value
        '    End Set
        'End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsRevision() As Boolean
			Get
				IsRevision = _IsRevision
			End Get
			Set(value As Boolean)
				_IsRevision = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Air Date")>
        Public Property MediaPlanAirDate() As Nullable(Of Date)
			Get
				MediaPlanAirDate = _MediaPlanAirDate
			End Get
			Set(value As Nullable(Of Date))
				_MediaPlanAirDate = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property ImportSource() As AdvantageFramework.Media.ImportSource
			Get
				ImportSource = _ImportSource
			End Get
			Set(value As AdvantageFramework.Media.ImportSource)
				_ImportSource = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="URL")>
        Public Property MediaPlanURL() As String
			Get
				MediaPlanURL = _MediaPlanURL
			End Get
			Set(value As String)
				_MediaPlanURL = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Target Audience")>
        Public Property MediaPlanTargetAudience() As String
			Get
				MediaPlanTargetAudience = _MediaPlanTargetAudience
			End Get
			Set(value As String)
				_MediaPlanTargetAudience = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Section")>
        Public Property MediaPlanSection() As String
			Get
				MediaPlanSection = _MediaPlanSection
			End Get
			Set(value As String)
				_MediaPlanSection = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Material")>
        Public Property MediaPlanMaterial() As String
			Get
				MediaPlanMaterial = _MediaPlanMaterial
			End Get
			Set(value As String)
				_MediaPlanMaterial = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Location")>
        Public Property MediaPlanLocation() As String
			Get
				MediaPlanLocation = _MediaPlanLocation
			End Get
			Set(value As String)
				_MediaPlanLocation = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Order Copy")>
        Public Property MediaPlanOrderCopy() As String
			Get
				MediaPlanOrderCopy = _MediaPlanOrderCopy
			End Get
			Set(value As String)
				_MediaPlanOrderCopy = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Material Notes")>
        Public Property MediaPlanMaterialNotes() As String
			Get
				MediaPlanMaterialNotes = _MediaPlanMaterialNotes
			End Get
			Set(value As String)
				_MediaPlanMaterialNotes = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Position Info")>
        Public Property MediaPlanPositionInfo() As String
			Get
				MediaPlanPositionInfo = _MediaPlanPositionInfo
			End Get
			Set(value As String)
				_MediaPlanPositionInfo = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Close Info")>
        Public Property MediaPlanCloseInfo() As String
			Get
				MediaPlanCloseInfo = _MediaPlanCloseInfo
			End Get
			Set(value As String)
				_MediaPlanCloseInfo = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Rate Info")>
        Public Property MediaPlanRateInfo() As String
			Get
				MediaPlanRateInfo = _MediaPlanRateInfo
			End Get
			Set(value As String)
				_MediaPlanRateInfo = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Misc Info")>
        Public Property MediaPlanMiscInfo() As String
			Get
				MediaPlanMiscInfo = _MediaPlanMiscInfo
			End Get
			Set(value As String)
				_MediaPlanMiscInfo = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Job Number")>
        Public Property MediaPlanJobNumber() As Nullable(Of Integer)
			Get
				MediaPlanJobNumber = _MediaPlanJobNumber
			End Get
			Set(value As Nullable(Of Integer))
				_MediaPlanJobNumber = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Job Comp Number")>
        Public Property MediaPlanJobComponentNumber() As Nullable(Of Short)
			Get
				MediaPlanJobComponentNumber = _MediaPlanJobComponentNumber
			End Get
			Set(value As Nullable(Of Short))
				_MediaPlanJobComponentNumber = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Monday")>
        Public Property MediaPlanMonday() As Boolean
			Get
				MediaPlanMonday = _MediaPlanMonday
			End Get
			Set(value As Boolean)
				_MediaPlanMonday = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Tuesday")>
        Public Property MediaPlanTuesday() As Boolean
			Get
				MediaPlanTuesday = _MediaPlanTuesday
			End Get
			Set(value As Boolean)
				_MediaPlanTuesday = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Wednesday")>
        Public Property MediaPlanWednesday() As Boolean
			Get
				MediaPlanWednesday = _MediaPlanWednesday
			End Get
			Set(value As Boolean)
				_MediaPlanWednesday = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Thursday")>
        Public Property MediaPlanThursday() As Boolean
			Get
				MediaPlanThursday = _MediaPlanThursday
			End Get
			Set(value As Boolean)
				_MediaPlanThursday = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Friday")>
        Public Property MediaPlanFriday() As Boolean
			Get
				MediaPlanFriday = _MediaPlanFriday
			End Get
			Set(value As Boolean)
				_MediaPlanFriday = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Saturday")>
        Public Property MediaPlanSaturday() As Boolean
			Get
				MediaPlanSaturday = _MediaPlanSaturday
			End Get
			Set(value As Boolean)
				_MediaPlanSaturday = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Sunday")>
        Public Property MediaPlanSunday() As Boolean
			Get
				MediaPlanSunday = _MediaPlanSunday
			End Get
			Set(value As Boolean)
				_MediaPlanSunday = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property OrderNumber() As Nullable(Of Integer)
			Get
				OrderNumber = _OrderNumber
			End Get
			Set(value As Nullable(Of Integer))
				_OrderNumber = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property OrderLineNumber() As Nullable(Of Integer)
			Get
				OrderLineNumber = _OrderLineNumber
			End Get
			Set(value As Nullable(Of Integer))
				_OrderLineNumber = value
			End Set
		End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property CalendarType() As String
            Get
                CalendarType = _CalendarType
            End Get
            Set(value As String)
                _CalendarType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set(value As String)
                _UserCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Remarks")>
        Public Property MediaPlanRemarks() As String
            Get
                MediaPlanRemarks = _MediaPlanRemarks
            End Get
            Set(value As String)
                _MediaPlanRemarks = value
            End Set
        End Property
		<System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property Spots1() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property Spots2() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property Spots3() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property Spots4() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property Spots5() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property Spots6() As Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property Units() As String
		<System.ComponentModel.Browsable(False)>
		<Xml.Serialization.XmlIgnore()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property MediaPlanRate As Decimal?
		<System.ComponentModel.Browsable(False)>
		<Xml.Serialization.XmlIgnore()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="Day of Weeks")>
        Public Property MediaPlanDayOfWeeks As String
		<System.ComponentModel.Browsable(False)>
		<Xml.Serialization.XmlIgnore()>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property MediaPlanRowIndex As Integer
		<System.Runtime.Serialization.DataMemberAttribute()>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Cable Network")>
		Public Property CableNetworkStationCode() As String
		<System.Runtime.Serialization.DataMemberAttribute()>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DaypartID, IsReadOnlyColumn:=True, CustomColumnCaption:="Daypart")>
		Public Property DaypartID() As System.Nullable(Of Integer)
		<System.Runtime.Serialization.DataMemberAttribute()>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Added Value")>
		Public Property ValueAdded() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Bookend() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property MediaPlanColumns As System.Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        Public Property MediaPlanInches As System.Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanMediaChannelID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanMediaTacticID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsMakegood() As Boolean

        '<System.ComponentModel.Browsable(False)>
        '<Xml.Serialization.XmlIgnore()>
        '<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False, CustomColumnCaption:="")>
        'Public Property VendorOrderLine() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()



		End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

            MyBase.New()

            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Me.DbContext = DbContext

            _MediaType = ImportAccountPayable.MediaType

            _OrderID = ImportAccountPayable.OrderID

            If _OrderID Is Nothing Then

                _LineNumber = Nothing

            Else

                _LineNumber = CShort(ImportAccountPayable.OrderLineID)

            End If

            If _OrderID IsNot Nothing AndAlso _LineNumber IsNot Nothing Then

                _IsRevision = True

            End If

            _OrderNumber = ImportAccountPayable.OrderNumber
            _OrderLineNumber = ImportAccountPayable.OrderLineNumber

            _SalesClassCode = ImportAccountPayable.SalesClassCode
            _ClientCode = ImportAccountPayable.MediaClientCode
            _DivisionCode = ImportAccountPayable.MediaDivisionCode
            _ProductCode = ImportAccountPayable.MediaProductCode
            _VendorCode = ImportAccountPayable.VendorCode
            _StartDate = ImportAccountPayable.LineDate
            _CommPct = ImportAccountPayable.MediaMarkupPercent
            _MarkupPercent = ImportAccountPayable.MediaMarkupPercent
            _AddAmount = ImportAccountPayable.MediaAddAmount

            If _MediaType = "I" AndAlso IsDate(ImportAccountPayable.LineDate) Then

                _EndDate = New Date(CDate(ImportAccountPayable.LineDate).Year, CDate(ImportAccountPayable.LineDate).Month, 1).AddMonths(1).AddDays(-1).ToShortDateString

            Else

                _EndDate = ImportAccountPayable.LineDate

            End If

            _NetCharge = ImportAccountPayable.MediaNetCharge

            _MediaNetAmount = ImportAccountPayable.MediaNetAmount

            If _MediaType = "R" OrElse _MediaType = "T" Then

                If ImportAccountPayable.MediaQuantity.GetValueOrDefault(0) = 0 AndAlso
                        (_AddAmount.GetValueOrDefault(0) <> 0 OrElse _NetCharge.GetValueOrDefault(0) <> 0 OrElse _MediaNetAmount.GetValueOrDefault(0) <> 0) Then

                    _TotalSpots = 1

                Else

                    _TotalSpots = ImportAccountPayable.MediaQuantity

                End If

            ElseIf _MediaType = "I" Then

                _TotalSpots = ImportAccountPayable.MediaQuantity

                If ImportAccountPayable.MediaQuantity Is Nothing Then

                    _CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                Else

                    _CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString 'default to NA

                End If

            ElseIf _MediaType = "N" Then

                _TotalSpots = ImportAccountPayable.MediaQuantity

                If ImportAccountPayable.MediaQuantity Is Nothing Then

                    _CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString

                Else

                    _CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString 'default to NA

                End If

            ElseIf _MediaType = "M" Then

                _TotalSpots = ImportAccountPayable.MediaQuantity

            ElseIf _MediaType = "O" Then

                _TotalSpots = ImportAccountPayable.MediaQuantity

            End If

            _NetGross = 0

            _ImportAccountPayableMediaID = ImportAccountPayable.ImportAccountPayableMediaID

            _UserCode = DbContext.UserCode

            CalculateGross(ImportAccountPayable)

            If ImportAccountPayable.MediaCampaignID.HasValue Then

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, ImportAccountPayable.MediaCampaignID.Value)

                If Campaign IsNot Nothing Then

                    _CampaignCode = Campaign.Code
                    Me.Campaign = Campaign.Name

                End If

            End If

        End Sub
        Public Sub New(ByVal CommPct As Decimal?, ByVal ImportAccountPayableMediaID As Integer?, ByVal Cost As Decimal?,
					   ByVal Columns As Decimal?, ByVal Inches As Decimal?, ByVal LinesCirculation As Integer?)

			MyBase.New()

			_CommPct = CommPct
			_ImportAccountPayableMediaID = ImportAccountPayableMediaID
			_Cost = Cost
			_Columns = Columns
			_Inches = Inches
			_LinesCirculation = LinesCirculation

		End Sub
		Private Sub CalculateGross(ByVal ImportAccountPayable As AdvantageFramework.AccountPayable.Classes.ImportAccountPayable)

			Dim CommissionAmount As Decimal = 0
			Dim GrossAmount As Decimal = 0

			If ImportAccountPayable.MediaQuantity.GetValueOrDefault(0) = 0 Then

				_NetRate = ImportAccountPayable.MediaNetAmount

			Else

				_NetRate = ImportAccountPayable.MediaNetAmount.GetValueOrDefault(0) / ImportAccountPayable.MediaQuantity

			End If

			CommissionAmount = FormatNumber(ImportAccountPayable.MediaNetAmount.GetValueOrDefault(0) * _CommPct.GetValueOrDefault(0) / 100, 2)

			GrossAmount = FormatNumber(ImportAccountPayable.MediaNetAmount.GetValueOrDefault(0) + CommissionAmount, 2)

			If ImportAccountPayable.MediaQuantity.GetValueOrDefault(0) = 0 Then

				_GrossRate = GrossAmount

			Else

				_GrossRate = GrossAmount / ImportAccountPayable.MediaQuantity

			End If

		End Sub
		Public Function GetCommPct() As Decimal?

			GetCommPct = _CommPct

		End Function
		Public Function GetColumns() As Decimal?

			GetColumns = _Columns

		End Function
		Public Function GetInches() As Decimal?

			GetInches = _Inches

		End Function
		Public Function GetLinesCirculation() As Integer?

			GetLinesCirculation = _LinesCirculation

		End Function
		Public Overrides Function ToString() As String

			ToString = _OrderID.ToString

		End Function
		Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

			SetRequiredFields()

			ValidateEntity = MyBase.ValidateEntity(IsValid)

		End Function
		Public Overrides Sub SetRequiredFields()

			Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

			PropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(Me).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList

			For Each PropertyDescriptor In PropertyDescriptors

				Select Case PropertyDescriptor.Name

					Case AdvantageFramework.Media.Classes.ImportOrder.Properties.CostType.ToString

						If Me.MediaType = "I" OrElse Me.MediaType = "N" Then

							SetRequired(PropertyDescriptor, True)

						Else

							SetRequired(PropertyDescriptor, False)

						End If

					Case AdvantageFramework.Media.Classes.ImportOrder.Properties.NetRate.ToString

						If Me.MediaType = "I" AndAlso Me.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString Then

							SetRequired(PropertyDescriptor, False)

						Else

							SetRequired(PropertyDescriptor, True)

						End If

					Case AdvantageFramework.Media.Classes.ImportOrder.Properties.GrossRate.ToString

						If Me.MediaType = "I" AndAlso Me.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString Then

							SetRequired(PropertyDescriptor, False)

						Else

							SetRequired(PropertyDescriptor, True)

						End If

					Case AdvantageFramework.Media.Classes.ImportOrder.Properties.TotalSpots.ToString

						If Me.MediaType = "I" Then

							If Me.CostType = AdvantageFramework.Database.Entities.CostType.NA.ToString Then

								SetRequired(PropertyDescriptor, False)

							Else

								SetRequired(PropertyDescriptor, True)

							End If

						ElseIf Me.MediaType = "N" OrElse Me.MediaType = "M" OrElse Me.MediaType = "O" Then

							SetRequired(PropertyDescriptor, False)

						ElseIf Me.MediaType = "R" OrElse Me.MediaType = "T" Then

							SetRequired(PropertyDescriptor, True)

						End If

					Case AdvantageFramework.Media.Classes.ImportOrder.Properties.Cost.ToString

						If Me.MediaType = "I" OrElse Me.MediaType = "N" Then

							SetRequired(PropertyDescriptor, True)

						Else

							SetRequired(PropertyDescriptor, False)

						End If

					Case AdvantageFramework.Media.Classes.ImportOrder.Properties.EndDate.ToString

						If Me.MediaType = "N" OrElse Me.MediaType = "M" Then

							SetRequired(PropertyDescriptor, False)

						Else

							SetRequired(PropertyDescriptor, True)

						End If

					Case AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOrderDescription.ToString

						If Me.ImportSource = Methods.ImportSource.MediaPlanning Then

							SetRequired(PropertyDescriptor, True)

						Else

							SetRequired(PropertyDescriptor, False)

						End If

				End Select

			Next

		End Sub
		Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Media.Classes.ImportOrder.Properties.OrderID.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Order ID is required and cannot be zero."

                    End If

                Case AdvantageFramework.Media.Classes.ImportOrder.Properties.LineNumber.ToString

                    PropertyValue = Value

                    If PropertyValue IsNot Nothing AndAlso PropertyValue = 0 Then

                        IsValid = False

                        ErrorText = "Line Number is required and cannot be zero."

                    End If

				Case AdvantageFramework.Media.Classes.ImportOrder.Properties.MediaPlanOrderDescription.ToString

					PropertyValue = Value

					If String.IsNullOrWhiteSpace(PropertyValue) = False AndAlso DirectCast(PropertyValue, String).Length > 40 Then

						IsValid = False

						ErrorText = "Order Description exceeds the maximum length of 40. "

					End If

				Case AdvantageFramework.Media.Classes.ImportOrder.Properties.StartDate.ToString,
						AdvantageFramework.Media.Classes.ImportOrder.Properties.EndDate.ToString

					If Me.StartDate.HasValue AndAlso Me.EndDate.HasValue AndAlso CDate(Me.StartDate.Value.ToShortDateString) > CDate(Me.EndDate.Value.ToShortDateString) Then

						IsValid = False

						ErrorText = "Start Date needs to be before or equal to end date. "

					End If

			End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
