Namespace Database.Entities

    <Table("MEDIA_RFP_DEMO")>
    Public Class MediaRFPDemo
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaRFPAvailLineID
            IDRank
            Type
            Group
            AgeFrom
            AgeTo
            Value
            MediaDemoID
            SourceMarketName
            MarketCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_RFP_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_RFP_AVAILABLE_LINE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaRFPAvailLineID() As Integer
        <Required>
        <MaxLength(10)>
        <Column("ID_RANK", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IDRank() As String
        <MaxLength(20)>
        <Column("TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Type() As String
        <Required>
        <MaxLength(20)>
        <Column("GROUP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Group() As String
        <Required>
        <Column("AGE_FROM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AgeFrom() As Short
        <Required>
        <Column("AGE_TO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AgeTo() As Short
        <Required>
        <Column("VALUE")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(11, 4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Value() As Decimal
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaDemoID() As Nullable(Of Integer)
        <MaxLength(50)>
        <Column("SOURCE_MARKET_NAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property SourceMarketName() As String
        <MaxLength(10)>
        <Column("MARKET_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property MarketCode() As String

        <ForeignKey("MediaRFPAvailLineID")>
        Public Overridable Property MediaRFPAvailLine As Database.Entities.MediaRFPAvailLine
        <ForeignKey("MediaDemoID")>
        Public Overridable Property MediaDemographic As Database.Entities.MediaDemographic

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
