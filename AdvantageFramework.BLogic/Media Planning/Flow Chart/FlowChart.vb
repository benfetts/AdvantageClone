Namespace MediaPlanning.FlowChart

    Public Class FlowChart

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        'Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        'Private _FlowChartMediaPlanOptions As FlowChartMediaPlanOptions = Nothing
        Private _FlowChartDates As Generic.List(Of FlowChartDate) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
        End Property
        Public ReadOnly Property MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan
        Public ReadOnly Property HighestDateDataColumn As AdvantageFramework.MediaPlanning.DataColumns
        Public ReadOnly Property NumberOfLevels As Integer
        Public ReadOnly Property FlowChartMediaPlanOptions As FlowChartMediaPlanOptions
        Public ReadOnly Property FlowChartEstimateDates As Generic.List(Of FlowChartEstimateDate)
        Public ReadOnly Property FlowChartEstimates As Generic.List(Of FlowChartEstimate)
        Public ReadOnly Property IsUsingBroadcastDates As Boolean

#End Region

#Region " Methods "

        Public Sub New(Session As AdvantageFramework.Security.Session, FlowChartMediaPlanOptions As FlowChartMediaPlanOptions)

            Me.New(Session, FlowChartMediaPlanOptions, New AdvantageFramework.MediaPlanning.Classes.MediaPlan(Session.ConnectionString, Session.UserCode, FlowChartMediaPlanOptions.MediaPlanID))

        End Sub
        Public Sub New(Session As AdvantageFramework.Security.Session, FlowChartMediaPlanOptions As FlowChartMediaPlanOptions, MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            'objects
            Dim MediaPlanDetailField As AdvantageFramework.Database.Entities.MediaPlanDetailField = Nothing
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim AllFlowChartEstimateDates As Generic.List(Of FlowChartEstimateDate) = Nothing
            Dim CalendarFlowChartEstimateDates As Generic.List(Of FlowChartEstimateDate) = Nothing
            Dim BroadcastFlowChartEstimateDates As Generic.List(Of FlowChartEstimateDate) = Nothing
            Dim BroadcastCalendarWeeks As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.BroadcastCalendarWeek) = Nothing
            Dim HasBroadcastEstimate As Boolean = False
            Dim HasCalendarEstimate As Boolean = False
            Dim FoundEstimate As Boolean = False
            Dim EstimateNumberOfLevels As Integer = 0

            _Session = Session
            Me.FlowChartMediaPlanOptions = FlowChartMediaPlanOptions

            Me.MediaPlan = MediaPlan

            BroadcastCalendarWeeks = Me.MediaPlan.BroadcastCalendarWeeks.ToList

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _FlowChartDates = DbContext.Database.SqlQuery(Of FlowChartDate)(String.Format("EXEC [dbo].[advsp_mediaplan_flowchart_dates] {0}", FlowChartMediaPlanOptions.MediaPlanID)).ToList

            End Using

            Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.Methods.DataColumns.Year
            Me.NumberOfLevels = 0

            Me.FlowChartEstimates = New Generic.List(Of FlowChartEstimate)

            AllFlowChartEstimateDates = New Generic.List(Of FlowChartEstimateDate)

            For Each FlowChartDate In _FlowChartDates

                If FlowChartDate.Date >= Me.FlowChartMediaPlanOptions.StartDate AndAlso FlowChartDate.Date <= Me.FlowChartMediaPlanOptions.EndDate Then

                    AllFlowChartEstimateDates.Add(New FlowChartEstimateDate(FlowChartDate, BroadcastCalendarWeeks))

                End If

            Next

            If FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.FromPlan Then

                For Each FCMPEO In FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions

                    If FCMPEO.Print AndAlso FCMPEO.PrintDateHeader Then

                        MediaPlanEstimate = Me.MediaPlan.GetMediaPlanEstimateByMediaPlanDetailID(FCMPEO.MediaPlanDetailID)

                        If MediaPlanEstimate IsNot Nothing Then

                            FoundEstimate = True

                            If MediaPlanEstimate.IsCalendarMonth Then

                                HasCalendarEstimate = True

                            End If

                            If MediaPlanEstimate.IsCalendarMonth = False Then

                                HasBroadcastEstimate = True

                            End If

                            MediaPlanDetailField = MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).OrderByDescending(Function(Entity) Entity.AreaIndex).FirstOrDefault

                            If MediaPlanDetailField IsNot Nothing AndAlso MediaPlanDetailField.Index > Me.HighestDateDataColumn Then

                                Me.HighestDateDataColumn = MediaPlanDetailField.Index

                            End If

                        End If

                    End If

                Next

                If FoundEstimate = False AndAlso Me.MediaPlan.MediaPlanEstimates.Values.Count > 0 Then

                    MediaPlanEstimate = Me.MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).First

                    If MediaPlanEstimate IsNot Nothing Then

                        If MediaPlanEstimate.IsCalendarMonth Then

                            HasCalendarEstimate = True

                        End If

                        If MediaPlanEstimate.IsCalendarMonth = False Then

                            HasBroadcastEstimate = True

                        End If

                        MediaPlanDetailField = MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible = True).OrderByDescending(Function(Entity) Entity.AreaIndex).FirstOrDefault

                        If MediaPlanDetailField IsNot Nothing AndAlso MediaPlanDetailField.Index > Me.HighestDateDataColumn Then

                            Me.HighestDateDataColumn = MediaPlanDetailField.Index

                        End If

                    End If

                End If

            ElseIf FlowChartMediaPlanOptions.FlowChartDateHeaderOption = FlowChartDateHeaderOptions.ChooseLevels Then

                For Each FCMPEO In FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions

                    If FCMPEO.Print AndAlso FCMPEO.PrintDateHeader Then

                        MediaPlanEstimate = Me.MediaPlan.GetMediaPlanEstimateByMediaPlanDetailID(FCMPEO.MediaPlanDetailID)

                        If MediaPlanEstimate IsNot Nothing Then

                            FoundEstimate = True

                            If MediaPlanEstimate.IsCalendarMonth Then

                                HasCalendarEstimate = True

                            End If

                            If MediaPlanEstimate.IsCalendarMonth = False Then

                                HasBroadcastEstimate = True

                            End If

                        End If

                    End If

                Next

                If FoundEstimate = False AndAlso Me.MediaPlan.MediaPlanEstimates.Values.Count > 0 Then

                    MediaPlanEstimate = Me.MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).First

                    If MediaPlanEstimate IsNot Nothing Then

                        If MediaPlanEstimate.IsCalendarMonth Then

                            HasCalendarEstimate = True

                        End If

                        If MediaPlanEstimate.IsCalendarMonth = False Then

                            HasBroadcastEstimate = True

                        End If

                    End If

                End If

                If FlowChartMediaPlanOptions.PrintDate Then

                    Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Date

                ElseIf FlowChartMediaPlanOptions.PrintDay Then

                    Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Day

                ElseIf FlowChartMediaPlanOptions.PrintWeek Then

                    Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Week

                ElseIf FlowChartMediaPlanOptions.PrintMonth Then

                    Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month

                ElseIf FlowChartMediaPlanOptions.PrintMonthName Then

                    Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.MonthName

                ElseIf FlowChartMediaPlanOptions.PrintQuarter Then

                    Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Quarter

                ElseIf FlowChartMediaPlanOptions.PrintYear Then

                    Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Year

                End If

            End If

            For Each FCMPEO In FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions

                If FCMPEO.Print Then

                    MediaPlanEstimate = Me.MediaPlan.GetMediaPlanEstimateByMediaPlanDetailID(FCMPEO.MediaPlanDetailID)

                    If MediaPlanEstimate IsNot Nothing Then

                        Me.FlowChartEstimates.Add(New FlowChartEstimate(Me, MediaPlanEstimate, FCMPEO))

                    End If

                End If

            Next

            For Each FlowChartEstimate In Me.FlowChartEstimates

                If FlowChartEstimate.FlowChartMediaPlanEstimateOptions.GroupByLevel = GroupByLevels.None Then

                    EstimateNumberOfLevels = FlowChartEstimate.FlowChartEstimateLevels.Where(Function(Entity) Entity.IsVisible = True).Count

                Else

                    EstimateNumberOfLevels = FlowChartEstimate.FlowChartMediaPlanEstimateOptions.GroupByLevel

                End If

                If Me.NumberOfLevels < EstimateNumberOfLevels Then

                    Me.NumberOfLevels = EstimateNumberOfLevels

                End If

            Next

            'For Each FCMPEO In FlowChartMediaPlanOptions.FlowChartMediaPlanEstimateOptions

            '    If FCMPEO.Print Then

            '        MediaPlanEstimate = Me.MediaPlan.GetMediaPlanEstimateByMediaPlanDetailID(FCMPEO.MediaPlanDetailID)

            '        If MediaPlanEstimate IsNot Nothing Then

            '            If Me.NumberOfLevels < MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.IsVisible = True).Count Then

            '                Me.NumberOfLevels = MediaPlanEstimate.MediaPlanDetailLevels.Where(Function(Entity) Entity.IsVisible = True).Count

            '            End If

            '        End If

            '    End If

            'Next

            If FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.None Then

                If HasBroadcastEstimate = False AndAlso HasCalendarEstimate Then

                    Me.FlowChartEstimateDates = GetFlowChartDates(AllFlowChartEstimateDates, False)
                    Me.IsUsingBroadcastDates = False

                ElseIf HasBroadcastEstimate AndAlso HasCalendarEstimate = False Then

                    Me.FlowChartEstimateDates = GetFlowChartDates(AllFlowChartEstimateDates, True)
                    Me.IsUsingBroadcastDates = True

                Else

                    CalendarFlowChartEstimateDates = GetFlowChartDates(AllFlowChartEstimateDates, False)
                    BroadcastFlowChartEstimateDates = GetFlowChartDates(AllFlowChartEstimateDates, True)

                    If CalendarFlowChartEstimateDates.Count >= BroadcastFlowChartEstimateDates.Count Then

                        Me.FlowChartEstimateDates = CalendarFlowChartEstimateDates
                        Me.IsUsingBroadcastDates = False

                    Else

                        Me.FlowChartEstimateDates = BroadcastFlowChartEstimateDates
                        Me.IsUsingBroadcastDates = True

                    End If

                End If

            ElseIf FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.BroadcastCalendar Then

                Me.FlowChartEstimateDates = GetFlowChartDates(AllFlowChartEstimateDates, True)
                Me.IsUsingBroadcastDates = True

            ElseIf FlowChartMediaPlanOptions.FlowChartDateOverrideOption = FlowChartDateOverrideOptions.Calendar Then

                Me.FlowChartEstimateDates = GetFlowChartDates(AllFlowChartEstimateDates, False)
                Me.IsUsingBroadcastDates = False

            End If

        End Sub
        Private Function GetFlowChartDates(AllFlowChartEstimateDates As Generic.List(Of FlowChartEstimateDate), UseBroadcastDates As Boolean) As Generic.List(Of FlowChartEstimateDate)

            'objects
            Dim FlowChartEstimateDates As Generic.List(Of FlowChartEstimateDate) = Nothing
            Dim AllDates As Generic.List(Of Date) = Nothing
            Dim FlowChartEstimateDate As FlowChartEstimateDate = Nothing

            FlowChartEstimateDates = New Generic.List(Of FlowChartEstimateDate)

            If Me.HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Year Then

                If UseBroadcastDates Then

                    AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.BroadcastYearStartDate).Distinct.ToList

                Else

                    AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.YearStartDate).Distinct.ToList

                End If

                For Each [Date] In AllDates

                    If UseBroadcastDates Then

                        FlowChartEstimateDate = AllFlowChartEstimateDates.FirstOrDefault(Function(Entity) Entity.BroadcastYearStartDate = [Date])

                    Else

                        FlowChartEstimateDate = AllFlowChartEstimateDates.FirstOrDefault(Function(Entity) Entity.YearStartDate = [Date])

                    End If

                    If FlowChartEstimateDate IsNot Nothing Then

                        FlowChartEstimateDates.Add(FlowChartEstimateDate)

                    End If

                Next

            ElseIf HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Quarter Then

                If UseBroadcastDates Then

                    AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.BroadcastQuarterStartDate).Distinct.ToList

                Else

                    AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.QuarterStartDate).Distinct.ToList

                End If

                For Each [Date] In AllDates

                    If UseBroadcastDates Then

                        FlowChartEstimateDate = AllFlowChartEstimateDates.FirstOrDefault(Function(Entity) Entity.BroadcastQuarterStartDate = [Date])

                    Else

                        FlowChartEstimateDate = AllFlowChartEstimateDates.FirstOrDefault(Function(Entity) Entity.QuarterStartDate = [Date])

                    End If

                    If FlowChartEstimateDate IsNot Nothing Then

                        FlowChartEstimateDates.Add(FlowChartEstimateDate)

                    End If

                Next

            ElseIf HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Month OrElse
                    HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.MonthName Then

                If UseBroadcastDates Then

                    AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.BroadcastMonthStartDate).Distinct.ToList

                Else

                    AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.MonthStartDate).Distinct.ToList

                End If

                For Each [Date] In AllDates

                    If UseBroadcastDates Then

                        FlowChartEstimateDate = AllFlowChartEstimateDates.FirstOrDefault(Function(Entity) Entity.BroadcastMonthStartDate = [Date])

                    Else

                        FlowChartEstimateDate = AllFlowChartEstimateDates.FirstOrDefault(Function(Entity) Entity.MonthStartDate = [Date])

                    End If

                    If FlowChartEstimateDate IsNot Nothing Then

                        FlowChartEstimateDates.Add(FlowChartEstimateDate)

                    End If

                Next

            ElseIf HighestDateDataColumn = AdvantageFramework.MediaPlanning.DataColumns.Week Then

                If UseBroadcastDates Then

                    AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.BroadcastWeekStartDate).Distinct.ToList

                Else

                    AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.WeekStartDate).Distinct.ToList

                End If

                For Each [Date] In AllDates

                    If UseBroadcastDates Then

                        FlowChartEstimateDate = AllFlowChartEstimateDates.FirstOrDefault(Function(Entity) Entity.BroadcastWeekStartDate = [Date])

                    Else

                        FlowChartEstimateDate = AllFlowChartEstimateDates.FirstOrDefault(Function(Entity) Entity.WeekStartDate = [Date])

                    End If

                    If FlowChartEstimateDate IsNot Nothing Then

                        FlowChartEstimateDates.Add(FlowChartEstimateDate)

                    End If

                Next

            Else

                'AllDates = AllFlowChartEstimateDates.Select(Function(Entity) Entity.Date).Distinct.ToList

                For Each FlowChartEstimateDate In AllFlowChartEstimateDates

                    FlowChartEstimateDates.Add(FlowChartEstimateDate)

                Next

            End If

            GetFlowChartDates = FlowChartEstimateDates

        End Function

#End Region

    End Class

End Namespace
