Namespace Nielsen.Database.Entities

    <Table("NIELSEN_TV_STATION")>
    Public Class NielsenTVStation
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            StationCode
            CallLetters
            SourceType
            ParentPlusIndicator
            IsParent
            IsSatellite
            Affiliation
            CableName
            ChannelNum
            DistributorGroup
            StationType
            ReportabilityStatus
            HomeMarketNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_TV_STATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer
        <Required>
        <Column("NIELSEN_MARKET_NUM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NielsenMarketNumber() As Integer
        <Required>
        <Column("STATION_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StationCode() As Integer
        <Required>
        <MaxLength(12)>
        <Column("CALL_LETTERS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CallLetters() As String
        <Required>
        <MaxLength(1)>
        <Column("SOURCE_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property SourceType() As String
        <Required>
        <MaxLength(1)>
        <Column("PARENT_PLUS_INDICATOR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ParentPlusIndicator() As String
        <Required>
        <Column("IS_PARENT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsParent() As Boolean
        <Required>
        <Column("IS_SATELLITE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsSatellite() As Boolean
        <Required>
        <MaxLength(1)>
        <Column("AFFILIATION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Affiliation() As String
        <Required>
        <MaxLength(1)>
        <Column("CABLE_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CableName() As String
        <Required>
        <MaxLength(1)>
        <Column("CHANNEL_NUM", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ChannelNum() As String
        <Required>
        <Column("DISTRIBUTOR_GROUP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DistributorGroup() As Integer
        <Required>
        <Column("STATION_TYPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StationType() As Short
        <Required>
        <MaxLength(1)>
        <Column("REPORTABILITY_STATUS")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ReportabilityStatus() As String
        <Column("HOME_MARKET_NUM")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property HomeMarketNumber() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
