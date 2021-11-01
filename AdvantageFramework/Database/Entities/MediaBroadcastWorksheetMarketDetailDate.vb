Namespace Database.Entities

	<Table("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE")>
	Public Class MediaBroadcastWorksheetMarketDetailDate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketDetailID
			[Date]
			Rate
			Spots
			IsHiatus
			MediaBroadcastWorksheetOrderStatusID
			LinkID
			LinkLineID
			OrderNumber
            OrderLineNumber
            VendorOrderLine
            AllowSpotsToBeEntered
            MakegoodSpots
            MediaBroadcastWorksheetMarketDetail
			MediaBroadcastWorksheetOrderStatus
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_DATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_DETAIL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketDetailID() As Integer
		<Required>
		<Column("DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property [Date]() As Date
		<Required>
		<Column("RATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(16, 4)>
        Public Property Rate() As Decimal
		<Required>
		<Column("SPOTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Spots() As Integer
		<Required>
		<Column("IS_HIATUS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property IsHiatus() As Boolean
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_ORDER_STATUS_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetOrderStatusID() As Integer
		<Column("LINK_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkID() As Nullable(Of Integer)
		<Column("LINK_LINE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LinkLineID() As Nullable(Of Integer)
		<Column("ORDER_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Nullable(Of Integer)
		<Column("ORDER_LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderLineNumber() As Nullable(Of Integer)
        <Column("VENDOR_ORDER_LINE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorOrderLine() As Nullable(Of Integer)
        <Required>
        <Column("ALLOW_SPOTS_TO_BE_ENTERED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AllowSpotsToBeEntered() As Boolean
        <Required>
        <Column("MAKEGOOD_SPOTS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MakegoodSpots() As Integer

        Public Overridable Property MediaBroadcastWorksheetMarketDetail As Database.Entities.MediaBroadcastWorksheetMarketDetail
		Public Overridable Property MediaBroadcastWorksheetOrderStatus As Database.Entities.MediaBroadcastWorksheetOrderStatus

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
