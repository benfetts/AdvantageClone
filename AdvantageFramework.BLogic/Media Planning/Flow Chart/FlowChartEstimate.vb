Namespace MediaPlanning.FlowChart

    Public Class FlowChartEstimate

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property FlowChart As FlowChart
        Public ReadOnly Property MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate
        Public ReadOnly Property FlowChartEstimateLevels As Generic.List(Of FlowChartEstimateLevel)
        Public ReadOnly Property FlowChartMediaPlanEstimateOptions As FlowChartMediaPlanEstimateOptions

#End Region

#Region " Methods "

        Public Sub New(FlowChart As FlowChart,
                       MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate,
                       FlowChartMediaPlanEstimateOptions As FlowChartMediaPlanEstimateOptions)

            Me.FlowChart = FlowChart
            Me.MediaPlanEstimate = MediaPlanEstimate
            Me.FlowChartMediaPlanEstimateOptions = FlowChartMediaPlanEstimateOptions

            Me.FlowChartEstimateLevels = New Generic.List(Of FlowChartEstimateLevel)

            For Each MPDL In MediaPlanEstimate.MediaPlanDetailLevels.ToList

                Me.FlowChartEstimateLevels.Add(New FlowChartEstimateLevel(MPDL))

            Next

            If MediaPlanEstimate.ShowPackageName Then

                Me.FlowChartEstimateLevels.Add(New FlowChartEstimateLevel(MediaPlanEstimate.PackageNameCaption, MediaPlanEstimate.PackageLevelIndex, True, FlowChartEstimateCustomLevels.Package))

            End If

            If MediaPlanEstimate.ShowDateRange Then

                Me.FlowChartEstimateLevels.Add(New FlowChartEstimateLevel(MediaPlanEstimate.DateRangeCaption, MediaPlanEstimate.DateRangeIndex, True, FlowChartEstimateCustomLevels.DateRange))

            End If

            If MediaPlanEstimate.ShowAdSizes Then

                Me.FlowChartEstimateLevels.Add(New FlowChartEstimateLevel(MediaPlanEstimate.AdSizesCaption, MediaPlanEstimate.AdSizesIndex, True, FlowChartEstimateCustomLevels.AdSizes))

            End If

        End Sub

#End Region

    End Class

End Namespace