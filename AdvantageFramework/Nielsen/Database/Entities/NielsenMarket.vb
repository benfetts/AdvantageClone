Namespace Nielsen.Database.Entities

    <Table("NIELSEN_MARKET")>
    Public Class NielsenMarket
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            NielsenTVCode
            NielsenTVDMACode
            NielsenRadioCode
            NielsenBlackRadioCode
            NielsenHispanicRadioCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <MaxLength(3)>
        <Column("MARKET_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Code() As String
        <MaxLength(40)>
        <Column("MARKET_DESC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Description() As String
        <Column("NIELSEN_TV_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenTVCode As String
        <Column("NIELSEN_TV_DMA_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenTVDMACode As String
        <Column("NIELSEN_RADIO_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenRadioCode As String
        <Column("NIELSEN_BLACK_RADIO_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenBlackRadioCode As String
        <Column("NIELSEN_HISPANIC_RADIO_CODE")>
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NielsenHispanicRadioCode As String

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
