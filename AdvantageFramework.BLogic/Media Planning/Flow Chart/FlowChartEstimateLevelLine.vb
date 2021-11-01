Namespace MediaPlanning.FlowChart

    Public Class FlowChartEstimateLevelLine

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property Description As String
        Public ReadOnly Property RowIndex As Integer
        Public ReadOnly Property FlowChartEstimateLevel As FlowChartEstimateLevel

#End Region

#Region " Methods "

        Public Sub New(Description As String,
                       RowIndex As Integer,
                       FlowChartEstimateLevel As FlowChartEstimateLevel)

            Me.Description = Description
            Me.RowIndex = RowIndex
            Me.FlowChartEstimateLevel = FlowChartEstimateLevel

        End Sub
        Public Sub New(MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine,
                       FlowChartEstimateLevel As FlowChartEstimateLevel)

            Me.Description = MediaPlanDetailLevelLine.Description
            Me.RowIndex = MediaPlanDetailLevelLine.RowIndex
            Me.FlowChartEstimateLevel = FlowChartEstimateLevel

        End Sub

#End Region

    End Class

End Namespace