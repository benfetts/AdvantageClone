Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketDetailDate
		Inherits AdvantageFramework.DTO.BaseClass

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
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketDetailID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property [Date]() As Date
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Rate() As Decimal
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Spots() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property IsHiatus() As Boolean
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetOrderStatusID() As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses
		Public Property LinkID() As Nullable(Of Integer)
		Public Property LinkLineID() As Nullable(Of Integer)
		Public Property OrderNumber() As Nullable(Of Integer)
        Public Property OrderLineNumber() As Nullable(Of Integer)
        Public Property VendorOrderLine() As Nullable(Of Integer)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AllowSpotsToBeEntered() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

			Me.ID = 0
			Me.MediaBroadcastWorksheetMarketDetailID = 0
			Me.[Date] = CDate(Date.MinValue.ToShortDateString)
			Me.Rate = 0
			Me.Spots = 0
			Me.IsHiatus = False
			Me.MediaBroadcastWorksheetOrderStatusID = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered
			Me.LinkID = Nothing
			Me.LinkLineID = Nothing
			Me.OrderNumber = Nothing
			Me.OrderLineNumber = Nothing
            Me.VendorOrderLine = Nothing
            Me.AllowSpotsToBeEntered = True

        End Sub
		Public Sub New(MediaBroadcastWorksheetMarketDetailDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate)

			Me.ID = MediaBroadcastWorksheetMarketDetailDate.ID
			Me.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetailID
			Me.[Date] = CDate(MediaBroadcastWorksheetMarketDetailDate.[Date].ToShortDateString)
			Me.Rate = MediaBroadcastWorksheetMarketDetailDate.Rate
			Me.Spots = MediaBroadcastWorksheetMarketDetailDate.Spots
			Me.IsHiatus = MediaBroadcastWorksheetMarketDetailDate.IsHiatus
			Me.MediaBroadcastWorksheetOrderStatusID = MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetOrderStatusID
			Me.LinkID = MediaBroadcastWorksheetMarketDetailDate.LinkID
			Me.LinkLineID = MediaBroadcastWorksheetMarketDetailDate.LinkLineID
			Me.OrderNumber = MediaBroadcastWorksheetMarketDetailDate.OrderNumber
			Me.OrderLineNumber = MediaBroadcastWorksheetMarketDetailDate.OrderLineNumber
            Me.VendorOrderLine = MediaBroadcastWorksheetMarketDetailDate.VendorOrderLine
            Me.AllowSpotsToBeEntered = MediaBroadcastWorksheetMarketDetailDate.AllowSpotsToBeEntered

        End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketDetailDate As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketDetailDate)

			MediaBroadcastWorksheetMarketDetailDate.ID = Me.ID
			MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetMarketDetailID = Me.MediaBroadcastWorksheetMarketDetailID
			MediaBroadcastWorksheetMarketDetailDate.[Date] = CDate(Me.[Date].ToShortDateString)
			MediaBroadcastWorksheetMarketDetailDate.Rate = Me.Rate
			MediaBroadcastWorksheetMarketDetailDate.Spots = Me.Spots
			MediaBroadcastWorksheetMarketDetailDate.IsHiatus = Me.IsHiatus
			MediaBroadcastWorksheetMarketDetailDate.MediaBroadcastWorksheetOrderStatusID = Me.MediaBroadcastWorksheetOrderStatusID
			MediaBroadcastWorksheetMarketDetailDate.LinkID = Me.LinkID
			MediaBroadcastWorksheetMarketDetailDate.LinkLineID = Me.LinkLineID
			MediaBroadcastWorksheetMarketDetailDate.OrderNumber = Me.OrderNumber
            MediaBroadcastWorksheetMarketDetailDate.OrderLineNumber = Me.OrderLineNumber
            MediaBroadcastWorksheetMarketDetailDate.VendorOrderLine = Me.VendorOrderLine
            MediaBroadcastWorksheetMarketDetailDate.AllowSpotsToBeEntered = Me.AllowSpotsToBeEntered

        End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
