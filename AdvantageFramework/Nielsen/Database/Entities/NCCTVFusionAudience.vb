Namespace Nielsen.Database.Entities

    <Table("NCC_TV_FUSION_AUDIENCE")>
    Public Class NCCTVFusionAudience
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NCCTVFusionUniverseID
            StationCode
            AudienceDatetime
            Household
            Children2to5
            Children6to11
            Males12to17
            Males18to20
            Males21to24
            Males25to34
            Males35to49
            Males50to54
            Males55to64
            Males65Plus
            Females12to17
            Females18to20
            Females21to24
            Females25to34
            Females35to49
            Females50to54
            Females55to64
            Females65Plus
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NCC_TV_FUSION_AUDIENCE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Int64
        <Required>
        <Column("NCC_TV_FUSION_UE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NCCTVFusionUniverseID() As Int64
        <Required>
        <Column("STATION_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StationCode() As Integer
        <Required>
        <Column("AUDIENCE_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AudienceDatetime() As Date
        <Required>
        <Column("HOUSEHOLD_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Household() As Integer
        <Required>
        <Column("CHILDREN_2TO5_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Children2to5() As Integer
        <Required>
        <Column("CHILDREN_6TO11_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Children6to11() As Integer
        <Required>
        <Column("MALES_12TO17_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males12to17() As Integer
        <Required>
        <Column("MALES_18TO20_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males18to20() As Integer
        <Required>
        <Column("MALES_21TO24_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males21to24() As Integer
        <Required>
        <Column("MALES_25TO34_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males25to34() As Integer
        <Required>
        <Column("MALES_35TO49_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males35to49() As Integer
        <Required>
        <Column("MALES_50TO54_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males50to54() As Integer
        <Required>
        <Column("MALES_55TO64_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males55to64() As Integer
        <Required>
        <Column("MALES_65PLUS_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Males65Plus() As Integer
        <Required>
        <Column("FEMALES_12TO17_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females12to17() As Integer
        <Required>
        <Column("FEMALES_18TO20_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females18to20() As Integer
        <Required>
        <Column("FEMALES_21TO24_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females21to24() As Integer
        <Required>
        <Column("FEMALES_25TO34_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females25to34() As Integer
        <Required>
        <Column("FEMALES_35TO49_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females35to49() As Integer
        <Required>
        <Column("FEMALES_50TO54_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females50to54() As Integer
        <Required>
        <Column("FEMALES_55TO64_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females55to64() As Integer
        <Required>
        <Column("FEMALES_65PLUS_AUD")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Females65Plus() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
