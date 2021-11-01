Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_COUNTY_INTAB")>
    Public Class NielsenRadioCountyIntab
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioCountyPeriodID
            Persons12Plus
            Persons12to34
            Persons18Plus
            Persons18to34
            Persons25to54
            Persons35Plus
            Persons35to64
            Males18Plus
            Females18Plus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_INTAB_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Int64
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_PERIOD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenRadioCountyPeriodID() As Integer
        <Required>
        <Column("PERSONS_12PLUS_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons12Plus() As Integer
        <Required>
        <Column("PERSONS_12TO34_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons12to34() As Integer
        <Required>
        <Column("PERSONS_18PLUS_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons18Plus() As Integer
        <Required>
        <Column("PERSONS_18TO34_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons18to34() As Integer
        <Required>
        <Column("PERSONS_25TO54_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons25to54() As Integer
        <Required>
        <Column("PERSONS_35PLUS_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons35Plus() As Integer
        <Required>
        <Column("PERSONS_35TO64_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons35to64() As Integer
        <Required>
        <Column("MALES_18PLUS_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18Plus() As Integer
        <Required>
        <Column("FEMALES_18PLUS_INTAB")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18Plus() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
