Namespace DTO.Maintenance.Media.PlanTemplate

    Public Class PlanTemplate
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Description
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Description = String.Empty
            Me.IsInactive = False

        End Sub
        Public Sub New(MediaPlanTemplateHeader As AdvantageFramework.Database.Entities.MediaPlanTemplateHeader)

            Me.ID = MediaPlanTemplateHeader.ID
            Me.Description = MediaPlanTemplateHeader.Description
            Me.IsInactive = MediaPlanTemplateHeader.IsInactive

        End Sub
        Public Sub SaveToEntity(MediaPlanTemplateHeader As AdvantageFramework.Database.Entities.MediaPlanTemplateHeader)

            MediaPlanTemplateHeader.Description = Me.Description
            MediaPlanTemplateHeader.IsInactive = Me.IsInactive

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
