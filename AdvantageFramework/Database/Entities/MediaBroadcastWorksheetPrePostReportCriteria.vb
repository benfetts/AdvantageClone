Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_PRE_POST_REPORT_CRITERIA")>
    Public Class MediaBroadcastWorksheetPrePostReportCriteria
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketID
            UserCode
            IsPostBuy
            SharebookNielsonTVBookID
            HUTPUTNielsonTVBookID
            UsePrimaryDemo
            PrimaryMediaDemographicID
            SecondaryMediaDemographicID
            BroadcastStartYearMonth
            BroadcastEndYearMonth
            StartDate
            EndDate
            UseImpressions
            MediaType
            NeilsenRadioPeriodID1
            NeilsenRadioPeriodID2
            NeilsenRadioPeriodID3
            NeilsenRadioPeriodID4
            NeilsenRadioPeriodID5
            PeriodStart
            PeriodEnd
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_PRE_POST_REPORT_CRITERIA_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode() As String
        <Required>
        <Column("BUY_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BuyType() As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaBuyType
        <Column("SHAREBOOK_NIELSEN_TV_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SharebookNielsenTVBookID() As Nullable(Of Integer)
        <Column("HUTPUT_NIELSEN_TV_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HUTPUTNielsenTVBookID() As Nullable(Of Integer)
        <Required>
        <Column("USE_PRIMARY_DEMO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UsePrimaryDemo() As Boolean
        <Column("PRIMARY_MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PrimaryMediaDemographicID() As Nullable(Of Integer)
        <Column("SECONDARY_MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SecondaryMediaDemographicID() As Nullable(Of Integer)
        <Column("BROADCAST_START_YEAR_MONTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BroadcastStartYearMonth() As Nullable(Of Integer)
        <Column("BROADCAST_END_YEAR_MONTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BroadcastEndYearMonth() As Nullable(Of Integer)
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property StartDate() As Nullable(Of Date)
        <Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EndDate() As Nullable(Of Date)
        <Required>
        <Column("USE_IMPRESSIONS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UseImpressions() As Boolean
        <Required>
        <Column("MEDIA_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaType() As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetPrePostReportCriteriaMediaType
        <Column("NIELSEN_RADIO_PERIOD_ID1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NeilsenRadioPeriodID1() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_PERIOD_ID2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NeilsenRadioPeriodID2() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_PERIOD_ID3")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NeilsenRadioPeriodID3() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_PERIOD_ID4")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NeilsenRadioPeriodID4() As Nullable(Of Integer)
        <Column("NIELSEN_RADIO_PERIOD_ID5")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NeilsenRadioPeriodID5() As Nullable(Of Integer)
        <Column("PERIOD_START")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PeriodStart() As Nullable(Of Date)
        <Column("PERIOD_END")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PeriodEnd() As Nullable(Of Date)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
