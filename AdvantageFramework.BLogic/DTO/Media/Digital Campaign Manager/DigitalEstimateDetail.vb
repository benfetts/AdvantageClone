Namespace DTO.Media.DigitalCampaignManager

    Public Class DigitalEstimateDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            EstimateLine
            RowIndex
            CampaignName
            VendorName
            Type
            Tactic
            StartDate
            EndDate
            CostType
            PlanImpressions
            PlanRate
            PlanSpend
            OrigPlanSpend
            PlanNetCharge
            PlanRevenue
            ActualImpressions
            ActualRate
            ActualSpend
            ActualNetCharge
            ActualRevenue
            RemainingImpressions
            RemainingSpend
            RemainingNetCharge
            RemainingRevenue
            DaysRemaining
            DaysElapsed
            WeeksRemaining
            WeeksElapsed
            MonthsRemaining
            MonthsElapsed
            OrderNumber
            OrderLineNumber
            Month
            YearMonth
            MonthString
            Year
            HasInvoice
            IsCPM
            IsClicksCPM
            IsImpressionsCPM
            IsUnitsCPM
            IsEstimateGrossAmount
            MediaPlanID
            PlanDescription
            MediaPlanDetailID
            EstimateName
            EstimateBuyer
            ClientName
            DivisionName
            ProductName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property EstimateLine As Integer
            Get
                EstimateLine = Me.RowIndex + 1
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property EstimateLineString As String
            Get
                EstimateLineString = "ES" & CStr(Me.RowIndex + 1)
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property RowIndex As Integer

        Public Property CampaignName As String
        Public Property VendorName As String
        Public Property Type As String
        Public Property Tactic As String
        Public Property StartDate As Date
        Public Property EndDate As Date

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CostType As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property PlanImpressions As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanRate As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanSpend As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanNetCharge As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property PlanRevenue As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public Property ActualImpressions As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Cost Per")>
        Public ReadOnly Property ActualRate As Decimal
            Get
                If Me.ActualImpressions = 0 Then
                    ActualRate = 0
                Else
                    ActualRate = Me.ActualSpend / (Me.ActualImpressions / If(Me.IsCPM, 1000.0, 1.0))
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualSpend As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualNetCharge As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ActualRevenue As Decimal

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n0")>
        Public ReadOnly Property RemainingImpressions As Decimal
            Get
                RemainingImpressions = Me.PlanImpressions.GetValueOrDefault(0) - Me.ActualImpressions
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property RemainingSpend As Decimal
            Get
                RemainingSpend = Me.PlanSpend - Me.ActualSpend
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property RemainingNetCharge As Decimal
            Get
                RemainingNetCharge = Me.PlanNetCharge - Me.ActualNetCharge
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public ReadOnly Property RemainingRevenue As Decimal
            Get
                RemainingRevenue = Me.PlanRevenue - Me.ActualRevenue
            End Get
        End Property

        Public ReadOnly Property DaysElapsed As Integer
            Get
                DaysElapsed = If(Me.StartDate >= Now, 0, DateDiff(DateInterval.Day, Me.StartDate, Now))
            End Get
        End Property
        Public ReadOnly Property DaysRemaining As Integer
            Get
                DaysRemaining = If(Now >= Me.EndDate, 0, DateDiff(DateInterval.Day, Now, Me.EndDate))
            End Get
        End Property

        Public ReadOnly Property WeeksRemaining As Integer
            Get
                WeeksRemaining = Me.DaysRemaining / 7
            End Get
        End Property
        Public ReadOnly Property WeeksElapsed As Integer
            Get
                WeeksElapsed = Me.DaysElapsed / 7
            End Get
        End Property

        Public ReadOnly Property MonthsRemaining As Integer
            Get
                MonthsRemaining = If(Now >= Me.EndDate, 0, DateDiff(DateInterval.Month, Now, Me.EndDate))
            End Get
        End Property
        Public ReadOnly Property MonthsElapsed As Integer
            Get
                MonthsElapsed = If(Me.StartDate >= Now, 0, DateDiff(DateInterval.Month, Me.StartDate, Now))
            End Get
        End Property

        Public Property OrderNumber As Integer?
        Public Property OrderLineNumber As Integer?

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Month As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property YearMonth As Integer
            Get
                YearMonth = CInt(Me.Year.ToString & Me.Month.ToString.PadLeft(2, "0"))
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Month")>
        Public ReadOnly Property MonthString As String
            Get
                If Me.Month <> 0 Then
                    MonthString = MonthName(Me.Month, True)
                Else
                    MonthString = ""
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Year As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailLevelLineDataID As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property HasInvoice As Integer
            Get
                If Me.PlanSpend > 0 AndAlso Me.ActualSpend = 0 Then
                    HasInvoice = 0
                ElseIf Me.PlanSpend > 0 AndAlso Me.ActualSpend > 0 Then
                    HasInvoice = 1
                Else
                    HasInvoice = -1
                End If
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property IsCPM As Boolean
            Get
                IsCPM = (Me.CostType = "CPA" AndAlso Me.IsUnitsCPM) OrElse (Me.CostType = "CPC" AndAlso Me.IsClicksCPM) OrElse (Me.CostType = "CPI" AndAlso Me.IsImpressionsCPM)
            End Get
        End Property

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsClicksCPM As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsImpressionsCPM As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsUnitsCPM As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsDirty As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Original Plan Spend")>
        Public Property OrigPlanSpend As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsEstimateGrossAmount As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesClassType As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property SalesClassCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ClientCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DivisionCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ProductCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ProductUsesNetAmount As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ProductRebateAmount As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ProductMarkupAmount As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AgencyFee As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorCommission As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property VendorMarkup As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Plan Number")>
        Public Property MediaPlanID As Integer
        Public Property PlanDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Estimate Number")>
        Public Property MediaPlanDetailID As Integer
        Public Property EstimateName As String
        Public Property EstimateBuyer As String
        Public Property ClientName As String
        Public Property DivisionName As String
        Public Property ProductName As String

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsGross As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsActualized As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.IsActualized = False

        End Sub

#End Region

    End Class

End Namespace
