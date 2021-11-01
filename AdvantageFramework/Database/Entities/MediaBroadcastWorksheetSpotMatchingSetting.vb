Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING")>
    Public Class MediaBroadcastWorksheetSpotMatchingSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetID
            VerifyRate
            VerifyNetwork
            VerifySchedule
            VerifyDay
            VerifyTime
            VerifyTimeSep
            VerifyAdNumber
            VerifyLength
            AdjacencyBefore
            AdjacencyAfter
            BookendMaxSeparation
            MediaBroadcastWorksheetTimeSeparationSettings
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Column("MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaBroadcastWorksheetID() As Integer
        <Required>
        <Column("VERIFY_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VerifyRate() As Boolean
        <Required>
        <Column("VERIFY_NETWORK")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VerifyNetwork() As Boolean
        <Required>
        <Column("VERIFY_SCHEDULE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VerifySchedule() As Boolean
        <Required>
        <Column("VERIFY_DAY")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VerifyDay() As Boolean
        <Required>
        <Column("VERIFY_TIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VerifyTime() As Boolean
        <Required>
        <Column("VERIFY_TIME_SEP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VerifyTimeSep() As Boolean
        <Required>
        <Column("VERIFY_AD_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VerifyAdNumber() As Boolean
        <Required>
        <Column("VERIFY_LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VerifyLength() As Boolean
        <Required>
        <Column("ADJACENCY_BEFORE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=60)>
        Public Property AdjacencyBefore() As Short
        <Required>
        <Column("ADJACENCY_AFTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=60)>
        Public Property AdjacencyAfter() As Short
        <Required>
        <Column("BOOKEND_MAX_SEPARATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(UseMinValue:=True, UseMaxValue:=True, MinValue:=0, MaxValue:=5)>
        Public Property BookendMaxSeparation() As Short

        <ForeignKey("MediaBroadcastWorksheetID")>
        Public Overridable Property MediaBroadcastWorksheet As AdvantageFramework.Database.Entities.MediaBroadcastWorksheet

        Public Overridable Property MediaBroadcastWorksheetTimeSeparationSettings As ICollection(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
