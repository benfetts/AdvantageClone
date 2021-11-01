Namespace DTO.Nielsen

    <System.Runtime.Serialization.DataContract()>
    Public Class NielsenTVBook

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
            CollectionMethod
            ReportingService
            Exclusion
            Ethnicity
            DownloadFileID
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CollectionMethod() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ReportingService() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Exclusion() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Ethnicity() As String
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DownloadFileID() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook)

            Me.ID = NielsenTVBook.ID
            Me.NielsenMarketNumber = NielsenTVBook.NielsenMarketNumber
            Me.Year = NielsenTVBook.Year
            Me.Month = NielsenTVBook.Month
            Me.Stream = NielsenTVBook.Stream
            Me.StartDateTime = NielsenTVBook.StartDateTime
            Me.EndDateTime = NielsenTVBook.EndDateTime
            Me.MarketTimeZone = NielsenTVBook.MarketTimeZone
            Me.MarketClassCode = NielsenTVBook.MarketClassCode
            Me.IsDaylightSavingsMarket = NielsenTVBook.IsDaylightSavingsMarket
            Me.CreateDate = NielsenTVBook.CreateDate
            Me.Validated = False
            Me.CollectionMethod = NielsenTVBook.CollectionMethod
            Me.ReportingService = NielsenTVBook.ReportingService
            Me.Exclusion = NielsenTVBook.Exclusion
            Me.Ethnicity = NielsenTVBook.Ethnicity
            Me.DownloadFileID = NielsenTVBook.DownloadFileID

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
