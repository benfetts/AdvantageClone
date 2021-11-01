Namespace Database.Entities

    <Table("MARKET_GROUP_MARKET")>
    Public Class MarketGroupMarket
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MarketGroupID
            MarketCode
            Order
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MARKET_GROUP_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("MARKET_GROUP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MarketGroupID() As Integer
        <Required>
        <MaxLength(10)>
        <Column("MARKET_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property MarketCode() As String
        <Required>
        <Column("ORDER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Order() As Integer

        Public Overridable Property MarketGroup As Database.Entities.MarketGroup
        Public Overridable Property Market As Database.Entities.Market

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.MarketCode

        End Function

#End Region

    End Class

End Namespace
