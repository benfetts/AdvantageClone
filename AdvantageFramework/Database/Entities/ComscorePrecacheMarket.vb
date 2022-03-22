Namespace Database.Entities

    <Table("COMSCORE_PRECACHE_MARKET")>
    Public Class ComscorePrecacheMarket
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MarketCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("COMSCORE_PRECACHE_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MarketCode() As String

        <ForeignKey("MarketCode")>
        Public Overridable Property Market As Database.Entities.Market

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
