Namespace MediaPlanning.FlowChart

    Public Class FlowChartMediaPlanOptions

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FlowChartMediaPlanEstimateOptions As Generic.List(Of FlowChartMediaPlanEstimateOptions) = Nothing

#End Region

#Region " Properties "

        Public Property MediaPlanID As Integer
        Public Property MediaPlanName As String
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property LocationID As String
        Public Property FlowChartDateHeaderOption As FlowChartDateHeaderOptions
        Public Property DateHeaderColor As System.Drawing.Color
        Public Property FlowChartDateOverrideOption As FlowChartDateOverrideOptions
        Public Property PrintYear As Boolean
        Public Property PrintQuarter As Boolean
        Public Property PrintMonth As Boolean
        Public Property PrintMonthName As Boolean
        Public Property PrintWeek As Boolean
        Public Property FlowChartWeekDisplayType As FlowChartWeekDisplayTypes
        Public Property PrintDay As Boolean
        Public Property PrintDate As Boolean
        Public Property FieldAreaColor As System.Drawing.Color
        Public Property PrintEstimateColumnTotals As Boolean
        Public Property EstimateColumnTotalsType As EstimateColumnTotalsTypes
        Public Property EstimateColumnTotalsAreaColor As System.Drawing.Color
        Public Property PrintGrandTotals As Boolean
        Public Property GrandTotalsType As GrandTotalsTypes
        Public Property GrandTotalsAreaColor As System.Drawing.Color
        Public Property GrandTotalsDisplayValue As AdvantageFramework.MediaPlanning.FlowChart.DataColumns
        Public Property FlowChartSummaryOption As FlowChartSummaryOptions
        Public ReadOnly Property FlowChartMediaPlanEstimateOptions As Generic.List(Of FlowChartMediaPlanEstimateOptions)
            Get
                FlowChartMediaPlanEstimateOptions = _FlowChartMediaPlanEstimateOptions
            End Get
        End Property
        Public Property ImageID As Nullable(Of Integer)
        Public Property RoundToNearestDollar() As Boolean

#End Region

#Region " Methods "

        Public Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly)

            Me.New()

            Me.MediaPlanID = MediaPlan.ID
            Me.MediaPlanName = MediaPlan.Description
            Me.StartDate = MediaPlan.StartDate
            Me.EndDate = MediaPlan.EndDate

        End Sub
        Public Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlanReadOnly, MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions)

            Me.New(MediaPlan)

            Me.LocationID = MediaPlanFlowChartOptions.LocationID

            Me.FlowChartDateHeaderOption = MediaPlanFlowChartOptions.DateHeaderOption
            Me.DateHeaderColor = System.Drawing.Color.FromArgb(MediaPlanFlowChartOptions.DateHeaderColor)
            Me.FlowChartDateOverrideOption = MediaPlanFlowChartOptions.DateOverrideOption

            Me.PrintYear = MediaPlanFlowChartOptions.PrintYear
            Me.PrintQuarter = MediaPlanFlowChartOptions.PrintQuarter
            Me.PrintMonth = MediaPlanFlowChartOptions.PrintMonth
            Me.PrintMonthName = MediaPlanFlowChartOptions.PrintMonthName
            Me.PrintWeek = MediaPlanFlowChartOptions.PrintWeek
            Me.FlowChartWeekDisplayType = MediaPlanFlowChartOptions.WeekDisplayType
            Me.PrintDay = MediaPlanFlowChartOptions.PrintDay
            Me.PrintDate = MediaPlanFlowChartOptions.PrintDate

            Me.FieldAreaColor = System.Drawing.Color.FromArgb(MediaPlanFlowChartOptions.FieldAreaColor)

            Me.PrintEstimateColumnTotals = MediaPlanFlowChartOptions.PrintEstimateColumnTotals
            Me.EstimateColumnTotalsType = MediaPlanFlowChartOptions.EstimateColumnTotalsType
            Me.EstimateColumnTotalsAreaColor = System.Drawing.Color.FromArgb(MediaPlanFlowChartOptions.EstimateColumnTotalsAreaColor)

            Me.PrintGrandTotals = MediaPlanFlowChartOptions.PrintGrandTotals
            Me.GrandTotalsType = MediaPlanFlowChartOptions.GrandTotalsType
            Me.GrandTotalsAreaColor = System.Drawing.Color.FromArgb(MediaPlanFlowChartOptions.GrandTotalsAreaColor)

            Me.GrandTotalsDisplayValue = MediaPlanFlowChartOptions.GrandTotalsDisplayValue

            Me.FlowChartSummaryOption = MediaPlanFlowChartOptions.SummaryOption

            Me.ImageID = MediaPlanFlowChartOptions.ImageID

            Me.RoundToNearestDollar = MediaPlanFlowChartOptions.RoundToNearestDollar

        End Sub
        Public Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            Me.New()

            Me.MediaPlanID = MediaPlan.ID
            Me.MediaPlanName = MediaPlan.Description
            Me.StartDate = MediaPlan.StartDate
            Me.EndDate = MediaPlan.EndDate

        End Sub
        Public Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions)

            Me.New(MediaPlan)

            Me.LocationID = MediaPlanFlowChartOptions.LocationID

            Me.FlowChartDateHeaderOption = MediaPlanFlowChartOptions.DateHeaderOption
            Me.DateHeaderColor = System.Drawing.Color.FromArgb(MediaPlanFlowChartOptions.DateHeaderColor)
            Me.FlowChartDateOverrideOption = MediaPlanFlowChartOptions.DateOverrideOption

            Me.PrintYear = MediaPlanFlowChartOptions.PrintYear
            Me.PrintQuarter = MediaPlanFlowChartOptions.PrintQuarter
            Me.PrintMonth = MediaPlanFlowChartOptions.PrintMonth
            Me.PrintMonthName = MediaPlanFlowChartOptions.PrintMonthName
            Me.PrintWeek = MediaPlanFlowChartOptions.PrintWeek
            Me.FlowChartWeekDisplayType = MediaPlanFlowChartOptions.WeekDisplayType
            Me.PrintDay = MediaPlanFlowChartOptions.PrintDay
            Me.PrintDate = MediaPlanFlowChartOptions.PrintDate

            Me.FieldAreaColor = System.Drawing.Color.FromArgb(MediaPlanFlowChartOptions.FieldAreaColor)

            Me.PrintEstimateColumnTotals = MediaPlanFlowChartOptions.PrintEstimateColumnTotals
            Me.EstimateColumnTotalsType = MediaPlanFlowChartOptions.EstimateColumnTotalsType
            Me.EstimateColumnTotalsAreaColor = System.Drawing.Color.FromArgb(MediaPlanFlowChartOptions.EstimateColumnTotalsAreaColor)

            Me.PrintGrandTotals = MediaPlanFlowChartOptions.PrintGrandTotals
            Me.GrandTotalsType = MediaPlanFlowChartOptions.GrandTotalsType
            Me.GrandTotalsAreaColor = System.Drawing.Color.FromArgb(MediaPlanFlowChartOptions.GrandTotalsAreaColor)

            Me.GrandTotalsDisplayValue = MediaPlanFlowChartOptions.GrandTotalsDisplayValue

            Me.FlowChartSummaryOption = MediaPlanFlowChartOptions.SummaryOption

            Me.ImageID = MediaPlanFlowChartOptions.ImageID

            Me.RoundToNearestDollar = MediaPlanFlowChartOptions.RoundToNearestDollar

        End Sub
        Public Sub New()

            Me.MediaPlanID = 0
            Me.MediaPlanName = String.Empty

            Me.StartDate = CDate(Now.ToShortDateString)
            Me.EndDate = CDate(Now.ToShortDateString)
            Me.LocationID = String.Empty

            Me.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.FromPlan
            Me.DateHeaderColor = System.Drawing.Color.FromArgb(212, 208, 200)
            Me.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None

            Me.PrintYear = False
            Me.PrintQuarter = False
            Me.PrintMonth = False
            Me.PrintMonthName = False
            Me.PrintWeek = False
            Me.FlowChartWeekDisplayType = FlowChartWeekDisplayTypes.FromPlan
            Me.PrintDay = False
            Me.PrintDate = False

            Me.FieldAreaColor = System.Drawing.Color.FromArgb(212, 208, 200)

            Me.PrintEstimateColumnTotals = True
            Me.EstimateColumnTotalsType = EstimateColumnTotalsTypes.Default
            Me.EstimateColumnTotalsAreaColor = System.Drawing.Color.FromArgb(155, 200, 230)

            Me.PrintGrandTotals = True
            Me.GrandTotalsType = GrandTotalsTypes.Default
            Me.GrandTotalsAreaColor = System.Drawing.Color.FromArgb(155, 200, 230)

            Me.GrandTotalsDisplayValue = AdvantageFramework.MediaPlanning.FlowChart.DataColumns.Dollars

            Me.FlowChartSummaryOption = FlowChartSummaryOptions.None

            _FlowChartMediaPlanEstimateOptions = New Generic.List(Of FlowChartMediaPlanEstimateOptions)

            Me.ImageID = Nothing

            Me.RoundToNearestDollar = False

        End Sub
        Public Sub Save(ByRef MediaPlanFlowChartOptions As AdvantageFramework.Database.Entities.MediaPlanFlowChartOptions)

            MediaPlanFlowChartOptions.LocationID = Me.LocationID

            MediaPlanFlowChartOptions.DateHeaderOption = Me.FlowChartDateHeaderOption
            MediaPlanFlowChartOptions.DateHeaderColor = Me.DateHeaderColor.ToArgb
            MediaPlanFlowChartOptions.DateOverrideOption = Me.FlowChartDateOverrideOption

            MediaPlanFlowChartOptions.PrintYear = Me.PrintYear
            MediaPlanFlowChartOptions.PrintQuarter = Me.PrintQuarter
            MediaPlanFlowChartOptions.PrintMonth = Me.PrintMonth
            MediaPlanFlowChartOptions.PrintMonthName = Me.PrintMonthName
            MediaPlanFlowChartOptions.PrintWeek = Me.PrintWeek
            MediaPlanFlowChartOptions.WeekDisplayType = Me.FlowChartWeekDisplayType
            MediaPlanFlowChartOptions.PrintDay = Me.PrintDay
            MediaPlanFlowChartOptions.PrintDate = Me.PrintDate

            MediaPlanFlowChartOptions.FieldAreaColor = Me.FieldAreaColor.ToArgb

            MediaPlanFlowChartOptions.PrintEstimateColumnTotals = Me.PrintEstimateColumnTotals
            MediaPlanFlowChartOptions.EstimateColumnTotalsType = Me.EstimateColumnTotalsType
            MediaPlanFlowChartOptions.EstimateColumnTotalsAreaColor = Me.EstimateColumnTotalsAreaColor.ToArgb

            MediaPlanFlowChartOptions.PrintGrandTotals = Me.PrintGrandTotals
            MediaPlanFlowChartOptions.GrandTotalsType = Me.GrandTotalsType
            MediaPlanFlowChartOptions.GrandTotalsAreaColor = Me.GrandTotalsAreaColor.ToArgb

            MediaPlanFlowChartOptions.GrandTotalsDisplayValue = Me.GrandTotalsDisplayValue

            MediaPlanFlowChartOptions.SummaryOption = Me.FlowChartSummaryOption

            MediaPlanFlowChartOptions.ImageID = Me.ImageID

            MediaPlanFlowChartOptions.RoundToNearestDollar = Me.RoundToNearestDollar

        End Sub

#End Region

    End Class

End Namespace