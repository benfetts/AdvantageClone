Namespace Database.Entities

    <Table("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_STATION")>
    Public Class MediaSpotTVPuertoRicoResearchStation
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotTVPuertoRicoResearchID
            StationID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_TV_PUERTO_RICO_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotTVPuertoRicoResearchID() As Integer
        <Required>
        <Column("NPR_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StationID() As Integer

        <ForeignKey("MediaSpotTVPuertoRicoResearchID")>
        Public Overridable Property MediaSpotTVPuertoRicoResearch As Database.Entities.MediaSpotTVPuertoRicoResearch

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
