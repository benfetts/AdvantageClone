Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class TacticMapping
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SuggestedTactic
            MediaTacticID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property SuggestedTactic() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MediaTacticID)>
        Public Property MediaTacticID() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaTacticID As Nullable(Of Integer), Description As String)

            Me.SuggestedTactic = Description
            Me.MediaTacticID = MediaTacticID

        End Sub

#End Region

    End Class

End Namespace
