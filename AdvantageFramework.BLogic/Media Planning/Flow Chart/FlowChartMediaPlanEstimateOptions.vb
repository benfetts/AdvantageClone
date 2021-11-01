Namespace MediaPlanning.FlowChart

    Public Class FlowChartMediaPlanEstimateOptions

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaPlanDetailID
            Print
            PrintFieldHeader
            PrintDateHeader
            DisplayValue
            ShowEstimateRowTotals
            ShowEstimateColumnTotals
            GroupByLevel
            FlowChartMediaPlanOptions
        End Enum

#End Region

#Region " Variables "

        Private _FlowChartMediaPlanOptions As FlowChartMediaPlanOptions = Nothing

#End Region

#Region " Properties "

        Public Property MediaPlanDetailID As Integer
        Public Property Estimate As String
        Public Property Print As Boolean
        Public Property PrintFieldHeader As Boolean
        Public Property PrintDateHeader As Boolean
        Public Property DisplayValue As Integer
        Public Property BlockingChart As Boolean
        Public Property ShowNote As Boolean
        Public Property ShowEstimateRowTotals As Boolean
        Public Property GroupByLevel As Integer
        Public ReadOnly Property FlowChartMediaPlanOptions As FlowChartMediaPlanOptions
            Get
                FlowChartMediaPlanOptions = _FlowChartMediaPlanOptions
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(FlowChartMediaPlanOptions As FlowChartMediaPlanOptions)

            _FlowChartMediaPlanOptions = FlowChartMediaPlanOptions

            Me.MediaPlanDetailID = 0
            Me.Estimate = String.Empty
            Me.Print = True
            Me.PrintFieldHeader = True
            Me.PrintDateHeader = False

            Me.DisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Dollars

            Me.BlockingChart = False
            Me.ShowNote = False
            Me.ShowEstimateRowTotals = False

        End Sub

#End Region

    End Class

End Namespace