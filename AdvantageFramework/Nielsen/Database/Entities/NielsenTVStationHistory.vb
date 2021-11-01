Namespace Nielsen.Database.Entities

    <Table("NIELSEN_TV_STATION_HISTORY")>
    Public Class NielsenTVStationHistory
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            NielsenMarketNumber
            StationCode
            OldCallLetters
            ChangedOn
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("NIELSEN_TV_STATION_HISTORY_ID")>
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
        <Column("OLD_CALL_LETTERS", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property CallLetters() As String
        <Required>
        <Column("CHANGED_ON")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ChangedOn() As Date

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
