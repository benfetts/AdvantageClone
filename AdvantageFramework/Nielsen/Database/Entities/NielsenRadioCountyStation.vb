Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_COUNTY_STATION")>
    Public Class NielsenRadioCountyStation
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Year
            CallLetters
            Band
            CityLicense
            CountyLicense
            StateLicense
            Affiliation
            OtherAffiliations
            Frequency
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Year() As Short
        <Required>
        <MaxLength(4)>
        <Column("CALL_LETTERS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CallLetters() As String
        <Required>
        <MaxLength(2)>
        <Column("BAND", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Band() As String
        <Required>
        <MaxLength(19)>
        <Column("CITY_LICENSE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CityLicense() As String
        <Required>
        <MaxLength(18)>
        <Column("COUNTY_LICENSE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CountyLicense() As String
        <Required>
        <MaxLength(2)>
        <Column("STATE_LICENSE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StateLicense() As String
        <Required>
        <MaxLength(2)>
        <Column("AFFILIATION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Affiliation() As String
        <Required>
        <MaxLength(14)>
        <Column("OTHER_AFFILIATIONS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OtherAffiliations() As String
        <Required>
        <MaxLength(5)>
        <Column("FREQUENCY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Frequency() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
