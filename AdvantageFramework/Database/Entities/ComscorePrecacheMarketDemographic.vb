Namespace Database.Entities

    <Table("COMSCORE_PRECACHE_MARKET_DEMOGRAPHIC")>
    Public Class ComscorePrecacheMarketDemographic
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ComscorePrecacheMarketID
            ComscoreDemoNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("COMSCORE_PRECACHE_MARKET_DEMOGRAPHIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("COMSCORE_PRECACHE_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ComscorePrecacheMarketID() As Integer
        <Required>
        <Column("COMSCORE_DEMO_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ComscoreDemoNumber() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
