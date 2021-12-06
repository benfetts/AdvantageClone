Namespace Database.Entities

    <Table("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO")>
    Public Class MediaSpotTVPuertoRicoResearchDemo
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotTVPuertoRicoResearchID
            Order
            MediaDemoID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotTVPuertoRicoResearchID() As Integer
        <Required>
        <Column("ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Order() As Short
        <Required>
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaDemoID() As Integer

        <ForeignKey("MediaSpotTVPuertoRicoResearchID")>
        Public Overridable Property MediaSpotTVPuertoRicoResearch As Database.Entities.MediaSpotTVPuertoRicoResearch

        <ForeignKey("MediaDemoID")>
        Public Overridable Property MediaDemographic As Database.Entities.MediaDemographic

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
