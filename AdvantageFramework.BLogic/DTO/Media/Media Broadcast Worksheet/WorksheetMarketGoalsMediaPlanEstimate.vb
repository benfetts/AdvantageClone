Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketGoalsMediaPlanEstimate
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            EstimateID
            Estimate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Selected() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EstimateID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Estimate() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Selected = False
            Me.EstimateID = 0
            Me.Estimate = String.Empty

        End Sub
        Public Sub New(MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            Me.Selected = False
            Me.EstimateID = MediaPlanEstimate.ID
            Me.Estimate = MediaPlanEstimate.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.EstimateID.ToString & " - " & Me.Estimate

        End Function

#End Region

    End Class

End Namespace
