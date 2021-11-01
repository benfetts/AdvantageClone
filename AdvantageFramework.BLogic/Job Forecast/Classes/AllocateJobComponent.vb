Namespace JobForecast.Classes

    <Serializable()>
    Public Class AllocateJobComponent
        Inherits JobForecastJobSummary

#Region " Constants "



#End Region

#Region " Enum "

        Public Shadows Enum Properties
            BillingAmountToAllocateByPostPeriod
            BillingAmountToAllocate
            RevenueAmountToAllocateByPostPeriod
            RevenueAmountToAllocate
        End Enum

#End Region

#Region " Variables "

        Private _BillingAmountToAllocateByPostPeriod As Decimal? = Nothing
        Private _BillingAmountToAllocate As Decimal? = Nothing
        Private _RevenueAmountToAllocateByPostPeriod As Decimal? = Nothing
        Private _RevenueAmountToAllocate As Decimal? = Nothing

#End Region

#Region " Properties "

        Public Property BillingAmountToAllocateByPostPeriod() As Decimal?
            Get
                BillingAmountToAllocateByPostPeriod = _BillingAmountToAllocateByPostPeriod
            End Get
            Set(value As Decimal?)
                _BillingAmountToAllocateByPostPeriod = value
            End Set
        End Property
        Public Property BillingAmountToAllocate() As Decimal?
            Get
                BillingAmountToAllocate = _BillingAmountToAllocate
            End Get
            Set(value As Decimal?)
                _BillingAmountToAllocate = value
            End Set
        End Property
        Public Property RevenueAmountToAllocateByPostPeriod() As Decimal?
            Get
                RevenueAmountToAllocateByPostPeriod = _RevenueAmountToAllocateByPostPeriod
            End Get
            Set(value As Decimal?)
                _RevenueAmountToAllocateByPostPeriod = value
            End Set
        End Property
        Public Property RevenueAmountToAllocate() As Decimal?
            Get
                RevenueAmountToAllocate = _RevenueAmountToAllocate
            End Get
            Set(value As Decimal?)
                _RevenueAmountToAllocate = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub
        Public Sub New(ByVal JobForecastJobSummary As AdvantageFramework.JobForecast.Classes.JobForecastJobSummary, Optional ByVal TotalPostPeriods As Integer = 0)

            Me.JobForecastID = JobForecastJobSummary.JobForecastID
            Me.JobForecastRevisionID = JobForecastJobSummary.JobForecastRevisionID
            Me.JobForecastJobID = JobForecastJobSummary.JobForecastJobID
            Me.ClientCode = JobForecastJobSummary.ClientCode
            Me.ClientName = JobForecastJobSummary.ClientName
            Me.JobNumber = JobForecastJobSummary.JobNumber
            Me.JobDescription = JobForecastJobSummary.JobDescription
            Me.JobComponentNumber = JobForecastJobSummary.JobComponentNumber
            Me.JobComponentDescription = JobForecastJobSummary.JobComponentDescription
            Me.Comments = JobForecastJobSummary.Comments
            Me.ApprovedEstimateBillingAmount = JobForecastJobSummary.ApprovedEstimateBillingAmount
            Me.ApprovedEstimateRevenueAmount = JobForecastJobSummary.ApprovedEstimateRevenueAmount
            Me.ApprovedEstimateAmount = JobForecastJobSummary.ApprovedEstimateAmount
            Me.Forecast = JobForecastJobSummary.Forecast
            Me.Actual = JobForecastJobSummary.Actual
            Me.Variance = JobForecastJobSummary.Variance
            Me.Color = JobForecastJobSummary.Color

            Me.RevenueAmountToAllocate = Me.ApprovedEstimateRevenueAmount
            Me.BillingAmountToAllocate = Me.ApprovedEstimateBillingAmount

            If TotalPostPeriods > 0 Then

                If Me.RevenueAmountToAllocate.HasValue Then

                    Me.RevenueAmountToAllocateByPostPeriod = Math.Round(Me.RevenueAmountToAllocate.Value / TotalPostPeriods, 2, MidpointRounding.AwayFromZero)

                End If

                If Me.BillingAmountToAllocate.HasValue Then

                    Me.BillingAmountToAllocateByPostPeriod = Math.Round(Me.BillingAmountToAllocate.Value / TotalPostPeriods, 2, MidpointRounding.AwayFromZero)

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
