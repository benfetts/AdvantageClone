Namespace DTO.Media

    Public Class Buy
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MEDIA
            CLIENT
            PRODUCT
            EST
            ESTIMATE
            BUY_DATES
            MARKET
            SYSCODE
            STATION
            LINE
            CABLE_NETWORK_CODE
            PROGRAMMING
            DAYPART
            LEN
            ROTATION
            TIMES
            COST_PER_SPOT
            RATING
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MEDIA() As String
        Public Property CLIENT() As String
        Public Property PRODUCT() As String
        Public Property EST() As Integer
        Public Property ESTIMATE() As String
        Public Property BUY_DATES() As String
        Public Property MARKET() As String
        Public Property SYSCODE() As Nullable(Of Integer)
        Public Property STATION() As String
        Public Property LINE() As Integer
        Public Property CABLE_NETWORK_CODE() As String
        Public Property PROGRAMMING() As String
        Public Property DAYPART() As String
        Public Property LEN() As Nullable(Of Short)
        Public Property ROTATION() As String
        Public Property TIMES() As String
        Public Property COST_PER_SPOT() As Decimal
        Public Property RATING() As Nullable(Of Decimal)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
