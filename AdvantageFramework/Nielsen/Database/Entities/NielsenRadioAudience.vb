Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_AUDIENCE")>
    Public Class NielsenRadioAudience
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SegmentParentID
            SegmentChildID
            Males6to11AQH
            Males12to17AQH
            Males18to20AQH
            Males18to24AQH
            Males21to24AQH
            Males25to34AQH
            Males35to44AQH
            Males35to49AQH
            Males45to49AQH
            Males50to54AQH
            Males55to64AQH
            Males65PlusAQH
            Females6to11AQH
            Females12to17AQH
            Females18to20AQH
            Females18to24AQH
            Females21to24AQH
            Females25to34AQH
            Females35to44AQH
            Females35to49AQH
            Females45to49AQH
            Females50to54AQH
            Females55to64AQH
            Females65PlusAQH
            Males6to11CUME
            Males12to17CUME
            Males18to20CUME
            Males18to24CUME
            Males21to24CUME
            Males25to34CUME
            Males35to44CUME
            Males35to49CUME
            Males45to49CUME
            Males50to54CUME
            Males55to64CUME
            Males65PlusCUME
            Females6to11CUME
            Females12to17CUME
            Females18to20CUME
            Females18to24CUME
            Females21to24CUME
            Females25to34CUME
            Females35to44CUME
            Females35to49CUME
            Females45to49CUME
            Females50to54CUME
            Females55to64CUME
            Females65PlusCUME
            Males6to11ECUME
            Males12to17ECUME
            Males18to20ECUME
            Males18to24ECUME
            Males21to24ECUME
            Males25to34ECUME
            Males35to44ECUME
            Males35to49ECUME
            Males45to49ECUME
            Males50to54ECUME
            Males55to64ECUME
            Males65PlusECUME
            Females6to11ECUME
            Females12to17ECUME
            Females18to20ECUME
            Females18to24ECUME
            Females21to24ECUME
            Females25to34ECUME
            Females35to44ECUME
            Females35to49ECUME
            Females45to49ECUME
            Females50to54ECUME
            Females55to64ECUME
            Females65PlusECUME
            Males6to11TLH
            Males12to17TLH
            Males18to20TLH
            Males18to24TLH
            Males21to24TLH
            Males25to34TLH
            Males35to44TLH
            Males35to49TLH
            Males45to49TLH
            Males50to54TLH
            Males55to64TLH
            Males65PlusTLH
            Females6to11TLH
            Females12to17TLH
            Females18to20TLH
            Females18to24TLH
            Females21to24TLH
            Females25to34TLH
            Females35to44TLH
            Females35to49TLH
            Females45to49TLH
            Females50to54TLH
            Females55to64TLH
            Females65PlusTLH
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_AUDIENCE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Int64
        <Required>
        <Column("NIELSEN_RADIO_SEGMENT_PARENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SegmentParentID() As Integer
        <Required>
        <Column("NIELSEN_RADIO_SEGMENT_CHILD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SegmentChildID() As Integer
        <Required>
        <Column("MALES_6TO11_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to11AQH() As Integer
        <Required>
        <Column("MALES_12TO17_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to17AQH() As Integer
        <Required>
        <Column("MALES_18TO20_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20AQH() As Integer
        <Required>
        <Column("MALES_18TO24_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to24AQH() As Integer
        <Required>
        <Column("MALES_21TO24_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24AQH() As Integer
        <Required>
        <Column("MALES_25TO34_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to34AQH() As Integer
        <Required>
        <Column("MALES_35TO44_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to44AQH() As Integer
        <Required>
        <Column("MALES_35TO49_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to49AQH() As Integer
        <Required>
        <Column("MALES_45TO49_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males45to49AQH() As Integer
        <Required>
        <Column("MALES_50TO54_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54AQH() As Integer
        <Required>
        <Column("MALES_55TO64_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64AQH() As Integer
        <Required>
        <Column("MALES_65PLUS_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65PlusAQH() As Integer
        <Required>
        <Column("FEMALES_6TO11_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to11AQH() As Integer
        <Required>
        <Column("FEMALES_12TO17_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to17AQH() As Integer
        <Required>
        <Column("FEMALES_18TO20_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20AQH() As Integer
        <Required>
        <Column("FEMALES_18TO24_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to24AQH() As Integer
        <Required>
        <Column("FEMALES_21TO24_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24AQH() As Integer
        <Required>
        <Column("FEMALES_25TO34_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to34AQH() As Integer
        <Required>
        <Column("FEMALES_35TO44_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to44AQH() As Integer
        <Required>
        <Column("FEMALES_35TO49_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to49AQH() As Integer
        <Required>
        <Column("FEMALES_45TO49_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females45to49AQH() As Integer
        <Required>
        <Column("FEMALES_50TO54_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54AQH() As Integer
        <Required>
        <Column("FEMALES_55TO64_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64AQH() As Integer
        <Required>
        <Column("FEMALES_65PLUS_AQH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65PlusAQH() As Integer
        <Required>
        <Column("MALES_6TO11_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to11CUME() As Integer
        <Required>
        <Column("MALES_12TO17_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to17CUME() As Integer
        <Required>
        <Column("MALES_18TO20_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20CUME() As Integer
        <Required>
        <Column("MALES_18TO24_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to24CUME() As Integer
        <Required>
        <Column("MALES_21TO24_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24CUME() As Integer
        <Required>
        <Column("MALES_25TO34_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to34CUME() As Integer
        <Required>
        <Column("MALES_35TO44_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to44CUME() As Integer
        <Required>
        <Column("MALES_35TO49_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to49CUME() As Integer
        <Required>
        <Column("MALES_45TO49_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males45to49CUME() As Integer
        <Required>
        <Column("MALES_50TO54_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54CUME() As Integer
        <Required>
        <Column("MALES_55TO64_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64CUME() As Integer
        <Required>
        <Column("MALES_65PLUS_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65PlusCUME() As Integer
        <Required>
        <Column("FEMALES_6TO11_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to11CUME() As Integer
        <Required>
        <Column("FEMALES_12TO17_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to17CUME() As Integer
        <Required>
        <Column("FEMALES_18TO20_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20CUME() As Integer
        <Required>
        <Column("FEMALES_18TO24_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to24CUME() As Integer
        <Required>
        <Column("FEMALES_21TO24_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24CUME() As Integer
        <Required>
        <Column("FEMALES_25TO34_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to34CUME() As Integer
        <Required>
        <Column("FEMALES_35TO44_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to44CUME() As Integer
        <Required>
        <Column("FEMALES_35TO49_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to49CUME() As Integer
        <Required>
        <Column("FEMALES_45TO49_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females45to49CUME() As Integer
        <Required>
        <Column("FEMALES_50TO54_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54CUME() As Integer
        <Required>
        <Column("FEMALES_55TO64_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64CUME() As Integer
        <Required>
        <Column("FEMALES_65PLUS_CUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65PlusCUME() As Integer
        <Required>
        <Column("MALES_6TO11_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to11ECUME() As Integer
        <Required>
        <Column("MALES_12TO17_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to17ECUME() As Integer
        <Required>
        <Column("MALES_18TO20_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20ECUME() As Integer
        <Required>
        <Column("MALES_18TO24_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to24ECUME() As Integer
        <Required>
        <Column("MALES_21TO24_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24ECUME() As Integer
        <Required>
        <Column("MALES_25TO34_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to34ECUME() As Integer
        <Required>
        <Column("MALES_35TO44_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to44ECUME() As Integer
        <Required>
        <Column("MALES_35TO49_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to49ECUME() As Integer
        <Required>
        <Column("MALES_45TO49_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males45to49ECUME() As Integer
        <Required>
        <Column("MALES_50TO54_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54ECUME() As Integer
        <Required>
        <Column("MALES_55TO64_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64ECUME() As Integer
        <Required>
        <Column("MALES_65PLUS_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65PlusECUME() As Integer
        <Required>
        <Column("FEMALES_6TO11_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to11ECUME() As Integer
        <Required>
        <Column("FEMALES_12TO17_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to17ECUME() As Integer
        <Required>
        <Column("FEMALES_18TO20_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20ECUME() As Integer
        <Required>
        <Column("FEMALES_18TO24_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to24ECUME() As Integer
        <Required>
        <Column("FEMALES_21TO24_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24ECUME() As Integer
        <Required>
        <Column("FEMALES_25TO34_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to34ECUME() As Integer
        <Required>
        <Column("FEMALES_35TO44_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to44ECUME() As Integer
        <Required>
        <Column("FEMALES_35TO49_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to49ECUME() As Integer
        <Required>
        <Column("FEMALES_45TO49_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females45to49ECUME() As Integer
        <Required>
        <Column("FEMALES_50TO54_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54ECUME() As Integer
        <Required>
        <Column("FEMALES_55TO64_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64ECUME() As Integer
        <Required>
        <Column("FEMALES_65PLUS_ECUME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65PlusECUME() As Integer
        <Required>
        <Column("MALES_6TO11_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males6to11TLH() As Integer
        <Required>
        <Column("MALES_12TO17_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to17TLH() As Integer
        <Required>
        <Column("MALES_18TO20_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20TLH() As Integer
        <Required>
        <Column("MALES_18TO24_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to24TLH() As Integer
        <Required>
        <Column("MALES_21TO24_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24TLH() As Integer
        <Required>
        <Column("MALES_25TO34_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to34TLH() As Integer
        <Required>
        <Column("MALES_35TO44_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to44TLH() As Integer
        <Required>
        <Column("MALES_35TO49_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to49TLH() As Integer
        <Required>
        <Column("MALES_45TO49_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males45to49TLH() As Integer
        <Required>
        <Column("MALES_50TO54_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54TLH() As Integer
        <Required>
        <Column("MALES_55TO64_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64TLH() As Integer
        <Required>
        <Column("MALES_65PLUS_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65PlusTLH() As Integer
        <Required>
        <Column("FEMALES_6TO11_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females6to11TLH() As Integer
        <Required>
        <Column("FEMALES_12TO17_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to17TLH() As Integer
        <Required>
        <Column("FEMALES_18TO20_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20TLH() As Integer
        <Required>
        <Column("FEMALES_18TO24_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to24TLH() As Integer
        <Required>
        <Column("FEMALES_21TO24_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24TLH() As Integer
        <Required>
        <Column("FEMALES_25TO34_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to34TLH() As Integer
        <Required>
        <Column("FEMALES_35TO44_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to44TLH() As Integer
        <Required>
        <Column("FEMALES_35TO49_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to49TLH() As Integer
        <Required>
        <Column("FEMALES_45TO49_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females45to49TLH() As Integer
        <Required>
        <Column("FEMALES_50TO54_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54TLH() As Integer
        <Required>
        <Column("FEMALES_55TO64_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64TLH() As Integer
        <Required>
        <Column("FEMALES_65PLUS_TLH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65PlusTLH() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Sub ZeroAllValues()

            Males6to11AQH = 0
            Males12to17AQH = 0
            Males18to20AQH = 0
            Males18to24AQH = 0
            Males21to24AQH = 0
            Males25to34AQH = 0
            Males35to44AQH = 0
            Males35to49AQH = 0
            Males45to49AQH = 0
            Males50to54AQH = 0
            Males55to64AQH = 0
            Males65PlusAQH = 0
            Females6to11AQH = 0
            Females12to17AQH = 0
            Females18to20AQH = 0
            Females18to24AQH = 0
            Females21to24AQH = 0
            Females25to34AQH = 0
            Females35to44AQH = 0
            Females35to49AQH = 0
            Females45to49AQH = 0
            Females50to54AQH = 0
            Females55to64AQH = 0
            Females65PlusAQH = 0
            Males6to11CUME = 0
            Males12to17CUME = 0
            Males18to20CUME = 0
            Males18to24CUME = 0
            Males21to24CUME = 0
            Males25to34CUME = 0
            Males35to44CUME = 0
            Males35to49CUME = 0
            Males45to49CUME = 0
            Males50to54CUME = 0
            Males55to64CUME = 0
            Males65PlusCUME = 0
            Females6to11CUME = 0
            Females12to17CUME = 0
            Females18to20CUME = 0
            Females18to24CUME = 0
            Females21to24CUME = 0
            Females25to34CUME = 0
            Females35to44CUME = 0
            Females35to49CUME = 0
            Females45to49CUME = 0
            Females50to54CUME = 0
            Females55to64CUME = 0
            Females65PlusCUME = 0
            Males6to11ECUME = 0
            Males12to17ECUME = 0
            Males18to20ECUME = 0
            Males18to24ECUME = 0
            Males21to24ECUME = 0
            Males25to34ECUME = 0
            Males35to44ECUME = 0
            Males35to49ECUME = 0
            Males45to49ECUME = 0
            Males50to54ECUME = 0
            Males55to64ECUME = 0
            Males65PlusECUME = 0
            Females6to11ECUME = 0
            Females12to17ECUME = 0
            Females18to20ECUME = 0
            Females18to24ECUME = 0
            Females21to24ECUME = 0
            Females25to34ECUME = 0
            Females35to44ECUME = 0
            Females35to49ECUME = 0
            Females45to49ECUME = 0
            Females50to54ECUME = 0
            Females55to64ECUME = 0
            Females65PlusECUME = 0
            Males6to11TLH = 0
            Males12to17TLH = 0
            Males18to20TLH = 0
            Males18to24TLH = 0
            Males21to24TLH = 0
            Males25to34TLH = 0
            Males35to44TLH = 0
            Males35to49TLH = 0
            Males45to49TLH = 0
            Males50to54TLH = 0
            Males55to64TLH = 0
            Males65PlusTLH = 0
            Females6to11TLH = 0
            Females12to17TLH = 0
            Females18to20TLH = 0
            Females18to24TLH = 0
            Females21to24TLH = 0
            Females25to34TLH = 0
            Females35to44TLH = 0
            Females35to49TLH = 0
            Females45to49TLH = 0
            Females50to54TLH = 0
            Females55to64TLH = 0
            Females65PlusTLH = 0

        End Sub

#End Region

    End Class

End Namespace
