Namespace Nielsen.Database.Entities

    <Table("NIELSEN_TV_BOOK")>
    Public Class NielsenTVBook
        Inherits BaseClasses.Entity

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

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_TV_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("NIELSEN_MARKET_NUM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenMarketNumber() As Integer
        <Required>
        <Column("YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Year() As Short
        <Required>
        <Column("MONTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Month() As Short
        <Required>
        <MaxLength(2)>
        <Column("STREAM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Stream() As String
        <Required>
        <Column("START_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDateTime() As Date
        <Required>
        <Column("END_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDateTime() As Date
        <Required>
        <Column("MARKET_TIME_ZONE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MarketTimeZone() As Short
        <Required>
        <MaxLength(1)>
        <Column("MARKET_CLASS_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MarketClassCode() As String
        <Required>
        <Column("IS_DST_MARKET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsDaylightSavingsMarket() As Boolean
        <Required>
        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreateDate() As Date
        <Required>
        <Column("VALIDATED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Validated() As Boolean
        <Required>
        <MaxLength(2)>
        <Column("COLLECTION_METHOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CollectionMethod() As String
        <Required>
        <MaxLength(1)>
        <Column("REPORTING_SERVICE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ReportingService() As String
        <Required>
        <MaxLength(2)>
        <Column("EXCLUSION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Exclusion() As String
        <Required>
        <MaxLength(5)>
        <Column("ETHNICITY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Ethnicity() As String
        <Column("DOWNLOAD_FILE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DownloadFileID() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
