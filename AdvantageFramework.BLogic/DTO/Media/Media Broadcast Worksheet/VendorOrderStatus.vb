Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class VendorOrderStatus
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaBroadcastWorksheetMarketID
            VendorCode
            VendorName
            Syscode
            CreateDate
            LastStatusDate
            Status
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID As Integer
        Public Property VendorCode As String
        Public Property VendorName As String
        Public Property Syscode As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property CreateDate As Date?
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property LastStatusDate As Nullable(Of Date)
        Public Property Status As String

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace
