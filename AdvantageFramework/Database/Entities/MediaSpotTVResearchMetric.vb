Namespace Database.Entities

    <Table("MEDIA_SPOT_TV_RESEARCH_METRIC")>
    Public Class MediaSpotTVResearchMetric
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotTVResearchID
            Order
            MediaMetricID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_TV_RESEARCH_METRIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_TV_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotTVResearchID() As Integer
        <Required>
        <Column("ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Order() As Short
        <Required>
        <Column("MEDIA_METRIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaMetricID() As AdvantageFramework.Database.Entities.MediaMetricID

        <ForeignKey("MediaSpotTVResearchID")>
        Public Overridable Property MediaSpotTVResearch As Database.Entities.MediaSpotTVResearch

        <ForeignKey("MediaMetricID")>
        Public Overridable Property MediaMetric As Database.Entities.MediaMetric

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
