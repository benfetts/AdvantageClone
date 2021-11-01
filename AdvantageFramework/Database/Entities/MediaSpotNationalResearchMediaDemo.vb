Namespace Database.Entities

    <Table("MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO")>
    Public Class MediaSpotNationalResearchMediaDemo
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotNationalResearchID
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
        <Column("MEDIA_SPOT_NATIONAL_RESEARCH_MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_NATIONAL_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotNationalResearchID() As Integer
        <Required>
        <Column("ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Order() As Short
        <Required>
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaDemoID() As Integer

        <ForeignKey("MediaSpotNationalResearchID")>
        Public Overridable Property MediaSpotNationalResearch As Database.Entities.MediaSpotNationalResearch

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
