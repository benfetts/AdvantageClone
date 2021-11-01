Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketSubmarket
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketID
            MarketCode
            Market
            Order
            StateProvince
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Required>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MarketCode() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Market() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Order() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property StateProvince() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.MarketCode = Nothing
            Me.Market = String.Empty
            Me.Order = 0
            Me.StateProvince = String.Empty

        End Sub
        Public Sub New(MediaBroadcastWorksheetMarketSubmarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketSubmarket)

            Me.ID = MediaBroadcastWorksheetMarketSubmarket.ID
            Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketSubmarket.MediaBroadcastWorksheetMarketID
            Me.MarketCode = MediaBroadcastWorksheetMarketSubmarket.MarketCode
            Me.Market = If(MediaBroadcastWorksheetMarketSubmarket.Market IsNot Nothing, MediaBroadcastWorksheetMarketSubmarket.Market.Description, String.Empty)
            Me.Order = MediaBroadcastWorksheetMarketSubmarket.Order

            If MediaBroadcastWorksheetMarketSubmarket.Market.State IsNot Nothing Then

                Me.StateProvince = MediaBroadcastWorksheetMarketSubmarket.Market.State.StateName

            Else

                Me.StateProvince = String.Empty

            End If

        End Sub
        Public Sub New(Market As AdvantageFramework.Database.Entities.Market)

            Me.ID = 0
            Me.MediaBroadcastWorksheetMarketID = 0
            Me.MarketCode = Market.Code
            Me.Market = Market.Description
            Me.Order = 0

            If Market.State IsNot Nothing Then

                Me.StateProvince = Market.State.StateName

            Else

                Me.StateProvince = String.Empty

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketSubmarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketSubmarket)

            MediaBroadcastWorksheetMarketSubmarket.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
            MediaBroadcastWorksheetMarketSubmarket.MarketCode = Me.MarketCode
            MediaBroadcastWorksheetMarketSubmarket.Order = Me.Order

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.MediaBroadcastWorksheetMarketID.ToString & " - " & Me.MarketCode

        End Function

#End Region

    End Class

End Namespace
