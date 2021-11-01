Namespace Database.Entities

    <Table("MEDIA_BROADCAST_WORKSHEET_TIME_SEPARATION_SETTING")>
    Public Class MediaBroadcastWorksheetTimeSeparationSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetSpotMatchingSettingID
            Length
            Separation
            CrossLengthSeparationEnabled
            CrossLengthSeparationValue
            MediaBroadcastWorksheetSpotMatchingSetting
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Column("MEDIA_BROADCAST_WORKSHEET_TIME_SEPARATION_SETTING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_SPOT_MATCHING_SETTING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetSpotMatchingSettingID() As Integer
        <Required>
        <Column("TIME_LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property Length() As Integer
        <Required>
        <Column("TIME_SEPARATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property Separation() As Integer
        <Column("CROSS_LENGTH_SEPARATION_ENABLED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CrossLengthSeparationEnabled() As Boolean
        <Column("CROSS_LENGTH_SEPARATION_VALUE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property CrossLengthSeparationValue() As Short

        <ForeignKey("MediaBroadcastWorksheetSpotMatchingSettingID")>
        Public Overridable Property MediaBroadcastWorksheetSpotMatchingSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetSpotMatchingSetting

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
