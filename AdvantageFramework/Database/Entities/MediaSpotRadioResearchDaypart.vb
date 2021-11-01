Namespace Database.Entities

    <Table("MEDIA_SPOT_RADIO_RESEARCH_DAYPART")>
    Public Class MediaSpotRadioResearchDaypart
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotRadioResearchID
            NielsenRadioDaypartID
        End Enum

#End Region

#Region " Variables "

        Private _Days As String = Nothing

#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_RADIO_RESEARCH_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_RADIO_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotRadioResearchID() As Integer
        <Required>
        <Column("NIELSEN_RADIO_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property NielsenRadioDaypartID() As Integer

        <ForeignKey("MediaSpotRadioResearchID")>
        Public Overridable Property MediaSpotRadioResearch As Database.Entities.MediaSpotRadioResearch

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
