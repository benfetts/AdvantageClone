Namespace Database.Entities

    <Table("NPR_UNIVERSE")>
    Public Class NPRUniverse
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            [Date]
            Homes
            People2Plus
            Males2Plus
            Males2to5
            Males6to11
            Males12to14
            Males15to17
            Males18to20
            Males21to24
            Males25to34
            Males35to44
            Males45to49
            Males50to54
            Males55to64
            Males65Plus
            Females2Plus
            Females2to5
            Females6to11
            Females12to14
            Females15to17
            Females18to20
            Females21to24
            Females25to34
            Females35to44
            Females45to49
            Females50to54
            Females55to64
            Females65Plus
            WorkingWomen
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NPR_UNIVERSE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property [Date]() As Date
        <Required>
        <Column("HOMES_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Homes() As Integer
        <Required>
        <Column("PEOPLE_2PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property People2Plus() As Integer
        <Required>
        <Column("MALES_2PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males2Plus() As Integer
        <Required>
        <Column("MALES_2TO5_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males2to5() As Integer
        <Required>
        <Column("MALES_6TO11_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to11() As Integer
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
        <Column("MALES_25TO34_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to34() As Integer
        <Required>
        <Column("MALES_35TO44_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to44() As Integer
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
        <Column("FEMALES_2PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females2Plus() As Integer
        <Required>
        <Column("FEMALES_2TO5_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females2to5() As Integer
        <Required>
        <Column("FEMALES_6TO11_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to11() As Integer
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
        <Column("FEMALES_25TO34_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to34() As Integer
        <Required>
        <Column("FEMALES_35TO44_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to44() As Integer
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
        <Column("WORKING_WOMEN_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property WorkingWomen() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
