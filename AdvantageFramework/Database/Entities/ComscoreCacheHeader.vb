Namespace Database.Entities

    <Table("COMSCORE_CACHE_HEADER")>
    Public Class ComscoreCacheHeader
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            BookID
            MarketNumber
            StationNumber
            DemoNumber
            Warning
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("COMSCORE_CACHE_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("COMSCORE_TV_BOOK_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookID() As Integer
        <Required>
        <Column("MARKET_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MarketNumber() As Integer
        <Required>
        <Column("STATION_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StationNumber() As Integer
        <Required>
        <Column("DEMO_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DemoNumber() As Integer
        <Column("WARNING", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Warning() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
