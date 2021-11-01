Namespace Database.Entities

    <Table("MEDIA_SPOT_RADIO_COUNTY_RESEARCH_YEAR")>
    Public Class MediaSpotRadioCountyResearchYear
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaSpotRadioCountyResearchID
            Year1
            Year2
            Year3
            Year4
            Year5
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_SPOT_RADIO_COUNTY_RESEARCH_YEAR_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_SPOT_RADIO_COUNTY_RESEARCH_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MediaSpotRadioCountyResearchID() As Integer
        <Required>
        <Column("YEAR1")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year1() As Short
        <Column("YEAR2")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year2() As Nullable(Of Short)
        <Column("YEAR3")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year3() As Nullable(Of Short)
        <Column("YEAR4")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year4() As Nullable(Of Short)
        <Column("YEAR5")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year5() As Nullable(Of Short)

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
