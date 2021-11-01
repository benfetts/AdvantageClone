Namespace Database.Entities

    <Table("NATIONAL_UNIVERSE")>
    Public Class NationalUniverse
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Year
            IsHispanic
            MarketBreakID
            Household
            Females2to5
            Females6to8
            Females9to11
            Females12to14
            Females15to17
            Females18to20
            Females21to24
            Females25to29
            Females30to34
            Females35to39
            Females40to44
            Females45to49
            Females50to54
            Females55to64
            Females65Plus
            Males2to5
            Males6to8
            Males9to11
            Males12to14
            Males15to17
            Males18to20
            Males21to24
            Males25to29
            Males30to34
            Males35to39
            Males40to44
            Males45to49
            Males50to54
            Males55to64
            Males65Plus
            WorkingWomen18to20
            WorkingWomen21to24
            WorkingWomen25to34
            WorkingWomen35to44
            WorkingWomen45to49
            WorkingWomen50to54
            WorkingWomen55Plus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NATIONAL_UNIVERSE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Year() As Integer
        <Required>
        <Column("IS_HISPANIC")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsHispanic() As Boolean
        <Required>
        <Column("MARKET_BREAK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MarketBreakID() As Integer
        <Required>
        <Column("HOUSEHOLD_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Household() As Integer
        <Required>
        <Column("FEMALES_2TO5_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females2to5() As Integer
        <Required>
        <Column("FEMALES_6TO8_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to8() As Integer
        <Required>
        <Column("FEMALES_9TO11_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females9to11() As Integer
        <Required>
        <Column("FEMALES_12TO14_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to14() As Integer
        <Required>
        <Column("FEMALES_15TO17_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females15to17() As Integer
        <Required>
        <Column("FEMALES_18TO20_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20() As Integer
        <Required>
        <Column("FEMALES_21TO24_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24() As Integer
        <Required>
        <Column("FEMALES_25TO29_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to29() As Integer
        <Required>
        <Column("FEMALES_30TO34_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females30to34() As Integer
        <Required>
        <Column("FEMALES_35TO39_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to39() As Integer
        <Required>
        <Column("FEMALES_40TO44_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females40to44() As Integer
        <Required>
        <Column("FEMALES_45TO49_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females45to49() As Integer
        <Required>
        <Column("FEMALES_50TO54_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54() As Integer
        <Required>
        <Column("FEMALES_55TO64_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64() As Integer
        <Required>
        <Column("FEMALES_65PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65Plus() As Integer
        <Required>
        <Column("MALES_2TO5_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males2to5() As Integer
        <Required>
        <Column("MALES_6TO8_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to8() As Integer
        <Required>
        <Column("MALES_9TO11_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males9to11() As Integer
        <Required>
        <Column("MALES_12TO14_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to14() As Integer
        <Required>
        <Column("MALES_15TO17_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males15to17() As Integer
        <Required>
        <Column("MALES_18TO20_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20() As Integer
        <Required>
        <Column("MALES_21TO24_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24() As Integer
        <Required>
        <Column("MALES_25TO29_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to29() As Integer
        <Required>
        <Column("MALES_30TO34_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males30to34() As Integer
        <Required>
        <Column("MALES_35TO39_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to39() As Integer
        <Required>
        <Column("MALES_40TO44_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males40to44() As Integer
        <Required>
        <Column("MALES_45TO49_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males45to49() As Integer
        <Required>
        <Column("MALES_50TO54_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54() As Integer
        <Required>
        <Column("MALES_55TO64_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64() As Integer
        <Required>
        <Column("MALES_65PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65Plus() As Integer
        <Required>
        <Column("WORKING_WOMEN_18TO20_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen18to20() As Integer
        <Required>
        <Column("WORKING_WOMEN_21TO24_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen21to24() As Integer
        <Required>
        <Column("WORKING_WOMEN_25TO34_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen25to34() As Integer
        <Required>
        <Column("WORKING_WOMEN_35TO44_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen35to44() As Integer
        <Required>
        <Column("WORKING_WOMEN_45TO49_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen45to49() As Integer
        <Required>
        <Column("WORKING_WOMEN_50TO54_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen50to54() As Integer
        <Required>
        <Column("WORKING_WOMEN_55PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen55Plus() As Integer

        <ForeignKey("MarketBreakID")>
        Public Overridable Property MarketBreak As AdvantageFramework.Database.Entities.MarketBreak

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
