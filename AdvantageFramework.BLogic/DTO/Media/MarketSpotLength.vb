Namespace DTO.Media

    Public Class MarketSpotLength
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MarketCode
            MarketDescription
            SpotLength
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketCode() As String
        Public Property MarketDescription() As String
        Public Property SpotLength() As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New(MediaPlanDetailGRPBudget As AdvantageFramework.DTO.Media.MediaPlanDetailGRPBudget)

            Me.MarketCode = MediaPlanDetailGRPBudget.MarketCode
            Me.MarketDescription = MediaPlanDetailGRPBudget.MarketDescription
            Me.SpotLength = MediaPlanDetailGRPBudget.SpotLength

        End Sub

#End Region

    End Class

End Namespace
