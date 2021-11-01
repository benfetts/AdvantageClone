Namespace MediaPlanning.FlowChart

    Public Class MediaPlanFlowChart

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        'Public Property PlanID() As Integer
        'Public Property PlanDescription() As String
        'Public Property ClientContact() As String
        'Public Property PlanStartDate() As Date
        'Public Property PlanEndDate() As Date
        'Public Property GrossBudget() As Nullable(Of Decimal)
        'Public Property CreatedByUserCode() As String
        'Public Property CreatedDate() As Date
        'Public Property ModifiedByUserCode() As String
        'Public Property ModifiedDate() As Nullable(Of Date)
        'Public Property EstimateID() As String
        'Public Property EstimateName() As String
        'Public Property IsCalendarMonth() As Boolean
        'Public Property MediaType() As String
        'Public Property SalesClassCode() As String
        'Public Property SalesClassDescription() As String
        'Public Property CampaignCode() As String
        'Public Property CampaignName() As String
        'Public Property MasterPlanID As Nullable(Of Integer)
        'Public Property MasterPlanName As String
        'Public Property MediaPlanFlowChartData As Generic.List(Of MediaPlanFlowChartData)
        'Public Property MediaPlanWeekDates As Generic.List(Of MediaPlanWeekDate)

#End Region

#Region " Methods "

        'Public Sub New(MediaPlanFlowChartData As Generic.List(Of MediaPlanFlowChartData))

        '    'objects
        '    Dim MPFCD As MediaPlanFlowChartData = Nothing

        '    If MediaPlanFlowChartData IsNot Nothing AndAlso MediaPlanFlowChartData.Count > 0 Then

        '        MPFCD = MediaPlanFlowChartData(0)

        '        Me.PlanID = MPFCD.PlanID
        '        Me.PlanDescription = MPFCD.PlanDescription
        '        Me.ClientContact = MPFCD.ClientContact
        '        Me.PlanStartDate = MPFCD.PlanStartDate
        '        Me.PlanEndDate = MPFCD.PlanEndDate
        '        Me.GrossBudget = MPFCD.GrossBudget
        '        Me.CreatedByUserCode = MPFCD.CreatedByUserCode
        '        Me.CreatedDate = MPFCD.CreatedDate
        '        Me.ModifiedByUserCode = MPFCD.ModifiedByUserCode
        '        Me.ModifiedDate = MPFCD.ModifiedDate
        '        Me.EstimateID = MPFCD.EstimateID
        '        Me.EstimateName = MPFCD.EstimateName
        '        Me.IsCalendarMonth = MPFCD.IsCalendarMonth
        '        Me.MediaType = MPFCD.MediaType
        '        Me.SalesClassCode = MPFCD.SalesClassCode
        '        Me.SalesClassDescription = MPFCD.SalesClassDescription
        '        Me.CampaignCode = MPFCD.CampaignCode
        '        Me.CampaignName = MPFCD.CampaignName
        '        Me.MasterPlanID = MPFCD.MasterPlanID
        '        Me.MasterPlanName = MPFCD.MasterPlanName

        '        Me.MediaPlanFlowChartData = MediaPlanFlowChartData
        '        Me.MediaPlanWeekDates = New Generic.List(Of MediaPlanWeekDate)

        '        For Each WeekDate In Me.MediaPlanFlowChartData.Select(Function(Entity) Entity.StartDateWeekDate).Distinct.OrderBy(Function(SD) SD).ToList

        '            MPFCD = Me.MediaPlanFlowChartData.FirstOrDefault(Function(Entity) Entity.StartDateWeekDate = WeekDate)

        '            If MPFCD IsNot Nothing Then

        '                Me.MediaPlanWeekDates.Add(New MediaPlanWeekDate(MPFCD))

        '            End If

        '        Next

        '    End If

        'End Sub

#End Region

    End Class

End Namespace