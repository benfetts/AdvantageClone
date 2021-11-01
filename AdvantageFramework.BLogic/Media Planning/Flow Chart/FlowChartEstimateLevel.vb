Namespace MediaPlanning.FlowChart

    Public Class FlowChartEstimateLevel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property Description As String
        Public ReadOnly Property OrderNumber As Integer
        Public ReadOnly Property IsVisible As Boolean
        Public ReadOnly Property FlowChartEstimateCustomLevel As FlowChartEstimateCustomLevels
        Public ReadOnly Property FlowChartEstimateLevelLines As Generic.List(Of FlowChartEstimateLevelLine)

#End Region

#Region " Methods "

        Public Sub New(Description As String, OrderNumber As Integer, IsVisible As Boolean, FlowChartEstimateCustomLevel As FlowChartEstimateCustomLevels)

            Me.Description = Description
            Me.OrderNumber = OrderNumber
            Me.IsVisible = IsVisible
            Me.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevel

            Me.FlowChartEstimateLevelLines = New Generic.List(Of FlowChartEstimateLevelLine)

        End Sub
        Public Sub New(MediaPlanDetailLevel As AdvantageFramework.Database.Entities.MediaPlanDetailLevel)

            Me.Description = MediaPlanDetailLevel.Description
            Me.OrderNumber = MediaPlanDetailLevel.OrderNumber
            Me.IsVisible = MediaPlanDetailLevel.IsVisible
            Me.FlowChartEstimateCustomLevel = FlowChartEstimateCustomLevels.None

            Me.FlowChartEstimateLevelLines = New Generic.List(Of FlowChartEstimateLevelLine)

            For Each MPDLL In MediaPlanDetailLevel.MediaPlanDetailLevelLines

                Me.FlowChartEstimateLevelLines.Add(New FlowChartEstimateLevelLine(MPDLL, Me))

            Next

        End Sub

#End Region

    End Class

End Namespace