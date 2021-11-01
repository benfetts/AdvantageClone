Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class PivotField
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanEstimateTemplateID
            FieldName
            Area
            AreaIndex
            Width
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MediaPlanEstimateTemplateID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property FieldName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Area() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property AreaIndex() As Short
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Width() As Short

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MediaPlanEstimateTemplateID = 0
            Me.FieldName = String.Empty
            Me.Area = 0
            Me.AreaIndex = 0
            Me.Width = 0

        End Sub
        Public Sub New(MediaPlanEstimateTemplatePivotField As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplatePivotField)

            Me.ID = MediaPlanEstimateTemplatePivotField.ID
            Me.MediaPlanEstimateTemplateID = MediaPlanEstimateTemplatePivotField.MediaPlanEstimateTemplateID
            Me.FieldName = MediaPlanEstimateTemplatePivotField.FieldName
            Me.Area = MediaPlanEstimateTemplatePivotField.Area
            Me.AreaIndex = MediaPlanEstimateTemplatePivotField.AreaIndex
            Me.Width = MediaPlanEstimateTemplatePivotField.Width

        End Sub
        Public Sub SaveToEntity(MediaPlanEstimateTemplatePivotField As AdvantageFramework.Database.Entities.MediaPlanEstimateTemplatePivotField)

            MediaPlanEstimateTemplatePivotField.MediaPlanEstimateTemplateID = Me.MediaPlanEstimateTemplateID
            MediaPlanEstimateTemplatePivotField.FieldName = Me.FieldName
            MediaPlanEstimateTemplatePivotField.Area = Me.Area
            MediaPlanEstimateTemplatePivotField.AreaIndex = Me.AreaIndex
            MediaPlanEstimateTemplatePivotField.Width = Me.Width

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
