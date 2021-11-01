Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class SpotLength
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanEstimateTemplateID
            SpotLength
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MediaPlanEstimateTemplateID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n0", UseMaxValue:=True, UseMinValue:=True, MinValue:=0, MaxValue:=999)>
        Public Property SpotLength() As Short

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaPlanEstimateTemplateID = 0
            Me.SpotLength = Nothing

        End Sub
        Public Sub New(MediaPlanEstimateTemplateSpotLength As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateSpotLength)

            Me.ID = MediaPlanEstimateTemplateSpotLength.ID
            Me.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplateSpotLength.MediaPlanEstimateTemplateID
            Me.SpotLength = MediaPlanEstimateTemplateSpotLength.SpotLength

        End Sub
        Public Sub SaveToEntity(MediaPlanEstimateTemplateSpotLength As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplateSpotLength)

            MediaPlanEstimateTemplateSpotLength.MediaPlanEstimateTemplateID = Me.MediaPlanEstimateTemplateID
            MediaPlanEstimateTemplateSpotLength.SpotLength = Me.SpotLength

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
