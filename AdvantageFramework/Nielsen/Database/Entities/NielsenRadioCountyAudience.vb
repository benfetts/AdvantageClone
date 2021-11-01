Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_COUNTY_AUDIENCE")>
    Public Class NielsenRadioCountyAudience
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenRadioCountyPeriodID
            NielsenRadioDaypartID
            NielsenRadioCountyStationID
            Persons12PlusAQH
            Persons12to34AQH
            Persons18PlusAQH
            Persons18to34AQH
            Persons25to54AQH
            Persons35PlusAQH
            Persons35to64AQH
            Males18PlusAQH
            Females18PlusAQH
            Persons12PlusRating
            Persons12to34Rating
            Persons18PlusRating
            Persons18to34Rating
            Persons25to54Rating
            Persons35PlusRating
            Persons35to64Rating
            Males18PlusRating
            Females18PlusRating
            Persons12PlusSSOC
            Persons12to34SSOC
            Persons18PlusSSOC
            Persons18to34SSOC
            Persons25to54SSOC
            Persons35PlusSSOC
            Persons35to64SSOC
            Males18PlusSSOC
            Females18PlusSSOC
            Persons12PlusCSOS
            Persons12to34CSOS
            Persons18PlusCSOS
            Persons18to34CSOS
            Persons25to54CSOS
            Persons35PlusCSOS
            Persons35to64CSOS
            Males18PlusCSOS
            Females18PlusCSOS
            Persons12PlusCUME
            Persons12to34CUME
            Persons18PlusCUME
            Persons18to34CUME
            Persons25to54CUME
            Persons35PlusCUME
            Persons35to64CUME
            Males18PlusCUME
            Females18PlusCUME
            Persons12PlusCUMERating
            Persons12to34CUMERating
            Persons18PlusCUMERating
            Persons18to34CUMERating
            Persons25to54CUMERating
            Persons35PlusCUMERating
            Persons35to64CUMERating
            Males18PlusCUMERating
            Females18PlusCUMERating
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_AUDIENCE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Int64
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_PERIOD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenRadioCountyPeriodID() As Integer
        <Required>
        <Column("NIELSEN_RADIO_DAYPART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenRadioDaypartID() As Integer
        <Required>
        <Column("NIELSEN_RADIO_COUNTY_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenRadioCountyStationID() As Integer
        <Required>
        <Column("PERSONS_12PLUS_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons12PlusAQH() As Integer
        <Required>
        <Column("PERSONS_12TO34_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons12to34AQH() As Integer
        <Required>
        <Column("PERSONS_18PLUS_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons18PlusAQH() As Integer
        <Required>
        <Column("PERSONS_18TO34_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons18to34AQH() As Integer
        <Required>
        <Column("PERSONS_25TO54_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons25to54AQH() As Integer
        <Required>
        <Column("PERSONS_35PLUS_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons35PlusAQH() As Integer
        <Required>
        <Column("PERSONS_35TO64_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons35to64AQH() As Integer
        <Required>
        <Column("MALES_18PLUS_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18PlusAQH() As Integer
        <Required>
        <Column("FEMALES_18PLUS_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18PlusAQH() As Integer
        <Required>
        <Column("PERSONS_12PLUS_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons12PlusRating() As Decimal
        <Required>
        <Column("PERSONS_12TO34_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons12to34Rating() As Decimal
        <Required>
        <Column("PERSONS_18PLUS_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons18PlusRating() As Decimal
        <Required>
        <Column("PERSONS_18TO34_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons18to34Rating() As Decimal
        <Required>
        <Column("PERSONS_25TO54_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons25to54Rating() As Decimal
        <Required>
        <Column("PERSONS_35PLUS_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons35PlusRating() As Decimal
        <Required>
        <Column("PERSONS_35TO64_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons35to64Rating() As Decimal
        <Required>
        <Column("MALES_18PLUS_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Males18PlusRating() As Decimal
        <Required>
        <Column("FEMALES_18PLUS_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Females18PlusRating() As Decimal
        <Required>
        <Column("PERSONS_12PLUS_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons12PlusSSOC() As Decimal
        <Required>
        <Column("PERSONS_12TO34_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons12to34SSOC() As Decimal
        <Required>
        <Column("PERSONS_18PLUS_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons18PlusSSOC() As Decimal
        <Required>
        <Column("PERSONS_18TO34_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons18to34SSOC() As Decimal
        <Required>
        <Column("PERSONS_25TO54_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons25to54SSOC() As Decimal
        <Required>
        <Column("PERSONS_35PLUS_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons35PlusSSOC() As Decimal
        <Required>
        <Column("PERSONS_35TO64_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons35to64SSOC() As Decimal
        <Required>
        <Column("MALES_18PLUS_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Males18PlusSSOC() As Decimal
        <Required>
        <Column("FEMALES_18PLUS_SSOC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Females18PlusSSOC() As Decimal
        <Required>
        <Column("PERSONS_12PLUS_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons12PlusCSOS() As Decimal
        <Required>
        <Column("PERSONS_12TO34_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons12to34CSOS() As Decimal
        <Required>
        <Column("PERSONS_18PLUS_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons18PlusCSOS() As Decimal
        <Required>
        <Column("PERSONS_18TO34_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons18to34CSOS() As Decimal
        <Required>
        <Column("PERSONS_25TO54_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons25to54CSOS() As Decimal
        <Required>
        <Column("PERSONS_35PLUS_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons35PlusCSOS() As Decimal
        <Required>
        <Column("PERSONS_35TO64_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons35to64CSOS() As Decimal
        <Required>
        <Column("MALES_18PLUS_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Males18PlusCSOS() As Decimal
        <Required>
        <Column("FEMALES_18PLUS_CSOS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Females18PlusCSOS() As Decimal
        <Required>
        <Column("PERSONS_12PLUS_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons12PlusCUME() As Integer
        <Required>
        <Column("PERSONS_12TO34_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons12to34CUME() As Integer
        <Required>
        <Column("PERSONS_18PLUS_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons18PlusCUME() As Integer
        <Required>
        <Column("PERSONS_18TO34_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons18to34CUME() As Integer
        <Required>
        <Column("PERSONS_25TO54_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons25to54CUME() As Integer
        <Required>
        <Column("PERSONS_35PLUS_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons35PlusCUME() As Integer
        <Required>
        <Column("PERSONS_35TO64_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Persons35to64CUME() As Integer
        <Required>
        <Column("MALES_18PLUS_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18PlusCUME() As Integer
        <Required>
        <Column("FEMALES_18PLUS_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18PlusCUME() As Integer
        <Required>
        <Column("PERSONS_12PLUS_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons12PlusCUMERating() As Decimal
        <Required>
        <Column("PERSONS_12TO34_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons12to34CUMERating() As Decimal
        <Required>
        <Column("PERSONS_18PLUS_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons18PlusCUMERating() As Decimal
        <Required>
        <Column("PERSONS_18TO34_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons18to34CUMERating() As Decimal
        <Required>
        <Column("PERSONS_25TO54_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons25to54CUMERating() As Decimal
        <Required>
        <Column("PERSONS_35PLUS_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons35PlusCUMERating() As Decimal
        <Required>
        <Column("PERSONS_35TO64_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Persons35to64CUMERating() As Decimal
        <Required>
        <Column("MALES_18PLUS_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Males18PlusCUMERating() As Decimal
        <Required>
        <Column("FEMALES_18PLUS_CUME_RATING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(4, 1)>
        Public Property Females18PlusCUMERating() As Decimal

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
