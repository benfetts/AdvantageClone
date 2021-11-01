Namespace Database.Entities

    <Table("COMSCORE_CACHE_DETAIL")>
    Public Class ComscoreCacheDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ComscoreCacheHeaderID
            QuarterHour
            SeriesName
            Share
            Rating
            AverageAudience
            SIU
            Universe
            MeetsDemoThreshold
            MeetsHighQualityDemoThreshold
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("COMSCORE_CACHE_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Int64
        <Required>
        <Column("COMSCORE_CACHE_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ComscoreCacheHeaderID() As Integer
        <Required>
        <Column("QTR_HR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property QuarterHour() As Date
        <Required>
        <Column("SERIES_NAME")>
        <MaxLength(141)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SeriesName() As String
        <Required>
        <Column("SHARE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Share() As Decimal
        <Required>
        <Column("AVG_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(13, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AverageAudience() As Decimal
        <Required>
        <Column("SIU")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(7, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SIU() As Decimal
        <Required>
        <Column("UNIVERSE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Universe() As Integer
        <Required>
        <Column("MEETS_DEMO_THRESHOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MeetsDemoThreshold() As Boolean
        <Required>
        <Column("MEETS_HQ_DEMO_THRESHOLD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MeetsHighQualityDemoThreshold() As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
