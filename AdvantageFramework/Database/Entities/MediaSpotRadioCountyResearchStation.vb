Namespace Database.Entities

    <Table("MEDIA_SPOT_RADIO_COUNTY_RESEARCH_STATION")>
    Public Class MediaSpotRadioCountyResearchStation
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotRadioCountyResearchID
            CallLetters
            Band
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_RADIO_COUNTY_RESEARCH_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotRadioCountyResearchID() As Integer
        <Required>
        <MaxLength(4)>
        <Column("CALL_LETTERS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CallLetters() As String
        <Required>
        <MaxLength(2)>
        <Column("BAND", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Band() As String

        <ForeignKey("MediaSpotRadioCountyResearchID")>
        Public Overridable Property MediaSpotRadioCountyResearch As Database.Entities.MediaSpotRadioCountyResearch

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
