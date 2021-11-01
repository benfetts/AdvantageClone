Namespace ViewModels.Maintenance.Media

    Public Class TimeSeparationSettingViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum TimeSeparationSettingSource
            [Default]
            Worksheet
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property TimeSeparationSettings As Generic.List(Of AdvantageFramework.DTO.Media.TimeSeparationSetting)
        Public Property SpotMatchingSetting As AdvantageFramework.DTO.Media.SpotMatchingSetting
        Public Property Client As AdvantageFramework.Database.Entities.Client
        Public ReadOnly Property HasASelectedTimeSeparationSetting As Boolean
            Get
                HasASelectedTimeSeparationSetting = SelectedTimeSeparationSettings IsNot Nothing AndAlso SelectedTimeSeparationSettings.Count > 0
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedTimeSeparationSettings As Generic.List(Of AdvantageFramework.DTO.Media.TimeSeparationSetting)
        Public Property CrossLengthSeparationEnabled As Boolean
        Public Property CrossLengthSeparationValue As Short
        Public Property IsDirty As Boolean
        Public Property Source As TimeSeparationSettingSource
        Public Property MediaTypeCode As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Source = TimeSeparationSettingSource.Default

        End Sub

#End Region

    End Class

End Namespace

