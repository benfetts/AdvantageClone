Namespace DTO.Media

    Public Class TimeSeparationSetting
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SettingID
            SpotMatchingSettingID
            Length
            Separation
            CrossLengthSeparationEnabled
            CrossLengthSeparationValue
            Guid
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SettingID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SpotMatchingSettingID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property Length() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property Separation() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CrossLengthSeparationEnabled() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, MaxValue:=999, UseMaxValue:=True, MinValue:=0, UseMinValue:=True)>
        Public Property CrossLengthSeparationValue() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Guid() As Guid

#End Region

#Region " Methods "

        Public Sub New()

            Me.Guid = Guid.NewGuid

        End Sub
        Public Sub New(MediaBroadcastWorksheetTimeSeparationSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting)

            Me.SettingID = MediaBroadcastWorksheetTimeSeparationSetting.ID
            Me.SpotMatchingSettingID = MediaBroadcastWorksheetTimeSeparationSetting.MediaBroadcastWorksheetSpotMatchingSettingID
            Me.Length = MediaBroadcastWorksheetTimeSeparationSetting.Length
            Me.Separation = MediaBroadcastWorksheetTimeSeparationSetting.Separation
            Me.CrossLengthSeparationEnabled = MediaBroadcastWorksheetTimeSeparationSetting.CrossLengthSeparationEnabled
            Me.CrossLengthSeparationValue = MediaBroadcastWorksheetTimeSeparationSetting.CrossLengthSeparationValue

        End Sub
        Public Sub New(TimeSeparationSetting As AdvantageFramework.Database.Entities.TimeSeparationSetting)

            Me.SettingID = TimeSeparationSetting.ID
            Me.SpotMatchingSettingID = TimeSeparationSetting.InvoiceMatchingSettingID
            Me.Length = TimeSeparationSetting.Length
            Me.Separation = TimeSeparationSetting.Separation
            Me.CrossLengthSeparationEnabled = TimeSeparationSetting.CrossLengthSeparationEnabled
            Me.CrossLengthSeparationValue = TimeSeparationSetting.CrossLengthSeparationValue

        End Sub
        Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetTimeSeparationSetting As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetTimeSeparationSetting)

            MediaBroadcastWorksheetTimeSeparationSetting.Length = Me.Length
            MediaBroadcastWorksheetTimeSeparationSetting.Separation = Me.Separation
            MediaBroadcastWorksheetTimeSeparationSetting.CrossLengthSeparationEnabled = Me.CrossLengthSeparationEnabled
            MediaBroadcastWorksheetTimeSeparationSetting.CrossLengthSeparationValue = Me.CrossLengthSeparationValue

        End Sub
        Public Sub SaveToEntity(ByRef TimeSeparationSetting As AdvantageFramework.Database.Entities.TimeSeparationSetting)

            TimeSeparationSetting.Length = Me.Length
            TimeSeparationSetting.Separation = Me.Separation
            TimeSeparationSetting.CrossLengthSeparationEnabled = Me.CrossLengthSeparationEnabled
            TimeSeparationSetting.CrossLengthSeparationValue = Me.CrossLengthSeparationValue

        End Sub

#End Region

    End Class

End Namespace
