Namespace Nielsen.Database.Entities

    <Table("NIELSEN_RADIO_MARKET")>
    Public Class NielsenRadioMarket
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Number
            Name
            ID
            Source
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <Column("NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Number() As Integer
        <Required>
        <MaxLength(32)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String
        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_RADIO_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("SOURCE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Source() As AdvantageFramework.Nielsen.Database.Entities.RadioSource

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
