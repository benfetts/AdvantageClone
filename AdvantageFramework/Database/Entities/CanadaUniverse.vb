Namespace Database.Entities

    <Table("CDN_UNIVERSE")>
    Public Class CanadaUniverse
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Year
            MarketCode
            Males2Plus
            Males12Plus
            Males18Plus
            Males25Plus
            Males35Plus
            Males50Plus
            Males55Plus
            Males60Plus
            Males65Plus
            Females2Plus
            Females12Plus
            Females18Plus
            Females25Plus
            Females35Plus
            Females50Plus
            Females55Plus
            Females60Plus
            Females65Plus
            Market
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("CDN_UNIVERSE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <Column("YEAR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Year() As Integer
        <Required>
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MarketCode() As String
        <Required>
        <Column("MALES_2_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males2Plus() As Integer
        <Required>
        <Column("MALES_12_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males12Plus() As Integer
        <Required>
        <Column("MALES_18_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males18Plus() As Integer
        <Required>
        <Column("MALES_25_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males25Plus() As Integer
        <Required>
        <Column("MALES_35_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males35Plus() As Integer
        <Required>
        <Column("MALES_50_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males50Plus() As Integer
        <Required>
        <Column("MALES_55_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males55Plus() As Integer
        <Required>
        <Column("MALES_60_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males60Plus() As Integer
        <Required>
        <Column("MALES_65_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Males65Plus() As Integer
        <Required>
        <Column("FEMALES_2_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females2Plus() As Integer
        <Required>
        <Column("FEMALES_12_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females12Plus() As Integer
        <Required>
        <Column("FEMALES_18_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females18Plus() As Integer
        <Required>
        <Column("FEMALES_25_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females25Plus() As Integer
        <Required>
        <Column("FEMALES_35_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females35Plus() As Integer
        <Required>
        <Column("FEMALES_50_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females50Plus() As Integer
        <Required>
        <Column("FEMALES_55_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females55Plus() As Integer
        <Required>
        <Column("FEMALES_60_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females60Plus() As Integer
        <Required>
        <Column("FEMALES_65_PLUS_UE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Females65Plus() As Integer

        Public Overridable Property Market As Database.Entities.Market

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
