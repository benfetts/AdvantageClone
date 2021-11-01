Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVCumeBook

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            Year
            Month
            Stream
            StartDateTime
            EndDateTime
            MarketTimeZone
            MarketClassCode
            IsDaylightSavingsMarket
            CreateDate
            Validated
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ID() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property NielsenMarketNumber() As Integer
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Year() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Month() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Stream() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property StartDateTime() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property EndDateTime() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketTimeZone() As Short
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MarketClassCode() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property IsDaylightSavingsMarket() As Boolean
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CreateDate() As Date
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Validated() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenTVCumeBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVCumeBook)

            Me.ID = NielsenTVCumeBook.ID
            Me.NielsenMarketNumber = NielsenTVCumeBook.NielsenMarketNumber
            Me.Year = NielsenTVCumeBook.Year
            Me.Month = NielsenTVCumeBook.Month
            Me.Stream = NielsenTVCumeBook.Stream
            Me.StartDateTime = NielsenTVCumeBook.StartDateTime
            Me.EndDateTime = NielsenTVCumeBook.EndDateTime
            Me.MarketTimeZone = NielsenTVCumeBook.MarketTimeZone
            Me.MarketClassCode = NielsenTVCumeBook.MarketClassCode
            Me.IsDaylightSavingsMarket = NielsenTVCumeBook.IsDaylightSavingsMarket
            Me.CreateDate = NielsenTVCumeBook.CreateDate
            Me.Validated = False

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
