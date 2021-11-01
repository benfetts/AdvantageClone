Namespace JobForecast.Classes

    <Serializable()>
    Public Class JobForecastJobSummary

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobForecastID
            JobForecastRevisionID
            JobForecastJobID
            ClientCode
            ClientName
            SalesClassCode
            SalesClassDescription
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            Comments
            ApprovedEstimateBillingAmount
            ApprovedEstimateRevenueAmount
            ApprovedEstimateAmount
            Forecast
            Actual
            Variance
            Color
        End Enum

#End Region

#Region " Variables "

        Private _JobForecastID As Integer = Nothing
        Private _JobForecastRevisionID As Integer = Nothing
        Private _JobForecastJobID As Integer = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _SalesClassCode As String = Nothing
        Private _SalesClassDescription As String = Nothing
        Private _JobNumber As Integer = Nothing
        Private _JobDescription As String = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _JobComponentDescription As String = Nothing
        Private _Comments As String = Nothing
        Private _ApprovedEstimateBillingAmount As Decimal? = Nothing
        Private _ApprovedEstimateRevenueAmount As Decimal? = Nothing
        Private _ApprovedEstimateAmount As Decimal? = Nothing
        Private _Forecast As Decimal? = Nothing
        Private _Actual As Decimal? = Nothing
        Private _Variance As Decimal? = Nothing
        Private _Color As Integer? = Nothing

#End Region

#Region " Properties "

        Public Property JobForecastID() As Integer
            Get
                JobForecastID = _JobForecastID
            End Get
            Set(value As Integer)
                _JobForecastID = value
            End Set
        End Property
        Public Property JobForecastRevisionID() As Integer
            Get
                JobForecastRevisionID = _JobForecastRevisionID
            End Get
            Set(value As Integer)
                _JobForecastRevisionID = value
            End Set
        End Property
        Public Property JobForecastJobID() As Integer
            Get
                JobForecastJobID = _JobForecastJobID
            End Get
            Set(value As Integer)
                _JobForecastJobID = value
            End Set
        End Property
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        Public Property SalesClassCode() As String
            Get
                SalesClassCode = _SalesClassCode
            End Get
            Set(value As String)
                _SalesClassCode = value
            End Set
        End Property
        Public Property SalesClassDescription() As String
            Get
                SalesClassDescription = _SalesClassDescription
            End Get
            Set(value As String)
                _SalesClassDescription = value
            End Set
        End Property
        Public Property JobNumber() As Integer
            Get
                JobNumber = _JobNumber
            End Get
            Set(value As Integer)
                _JobNumber = value
            End Set
        End Property
        Public Property JobDescription() As String
            Get
                JobDescription = _JobDescription
            End Get
            Set(value As String)
                _JobDescription = value
            End Set
        End Property
        Public Property JobComponentNumber() As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(value As Short)
                _JobComponentNumber = value
            End Set
        End Property
        Public Property JobComponentDescription() As String
            Get
                JobComponentDescription = _JObComponentDescription
            End Get
            Set(value As String)
                _JObComponentDescription = value
            End Set
        End Property
        Public Property Comments() As String
            Get
                Comments = _Comments
            End Get
            Set(value As String)
                _Comments = value
            End Set
        End Property
        Public Property ApprovedEstimateBillingAmount() As Decimal?
            Get
                ApprovedEstimateBillingAmount = _ApprovedEstimateBillingAmount
            End Get
            Set(value As Decimal?)
                _ApprovedEstimateBillingAmount = value
            End Set
        End Property
        Public Property ApprovedEstimateRevenueAmount() As Decimal?
            Get
                ApprovedEstimateRevenueAmount = _ApprovedEstimateRevenueAmount
            End Get
            Set(value As Decimal?)
                _ApprovedEstimateRevenueAmount = value
            End Set
        End Property
        Public Property ApprovedEstimateAmount() As Decimal?
            Get
                ApprovedEstimateAmount = _ApprovedEstimateAmount
            End Get
            Set(value As Decimal?)
                _ApprovedEstimateAmount = value
            End Set
        End Property
        Public Property Forecast() As Decimal?
            Get
                Forecast = _Forecast
            End Get
            Set(value As Decimal?)
                _Forecast = value
            End Set
        End Property
        Public Property Actual() As Decimal?
            Get
                Actual = _Actual
            End Get
            Set(value As Decimal?)
                _Actual = value
            End Set
        End Property
        Public Property Variance() As Decimal?
            Get
                Variance = _Variance
            End Get
            Set(value As Decimal?)
                _Variance = value
            End Set
        End Property
        Public Property Color() As Integer?
            Get
                Color = _Color
            End Get
            Set(value As Integer?)
                _Color = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
