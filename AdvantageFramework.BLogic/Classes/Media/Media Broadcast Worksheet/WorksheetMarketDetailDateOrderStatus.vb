Namespace Classes.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketDetailDateOrderStatus

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Spots
            OrderStatus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Spots() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderStatus() As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses

#End Region

#Region " Methods "

        Public Sub New()

            Me.Spots = 0
            Me.OrderStatus = AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.OrderStatuses.Unordered

        End Sub

#End Region

    End Class

End Namespace
