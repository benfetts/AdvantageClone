Namespace JobForecast.Classes

    Public Class JobForecastEntry

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            JobForecastID
            JobForecastRevisionID
            JobForecastJobID
            JobForecastDescription
            RevisionNumber
            IsHighestRevision
            IsRevisionApproved
            ForecastHasApprovedRevision
            BillingAmount
            RevenueAmount
            PostPeriodCode
            PostPeriodStartDate
            JobForecastCreateDate
            GroupOrder 'used in radgrid 
            ForecastType
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _JobForecastID As Integer = Nothing
        Private _JobForecastRevisionID As Integer = Nothing
        Private _JobForecastJobID As Integer = Nothing
        Private _JobForecastDescription As String = Nothing
        Private _RevisionNumber As Integer = Nothing
        Private _IsHighestRevision As Boolean = Nothing
        Private _IsRevisionApproved As Boolean = Nothing
        Private _ForecastHasApprovedRevision As Boolean = Nothing
        Private _BillingAmount As Decimal? = Nothing
        Private _RevenueAmount As Decimal? = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _PostPeriodStartDate As Date = Nothing
        Private _JobForecastCreateDate As Date = Nothing
        Private _GroupOrder As Integer = Nothing
        Private _ForecastType As AdvantageFramework.JobForecast.JobForecastTypes = JobForecastTypes.Billing

#End Region

#Region " Properties "

        Public Property ID As Integer
            Get
                ID = _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        Public Property JobForecastID As Integer
            Get
                JobForecastID = _JobForecastID
            End Get
            Set(value As Integer)
                _JobForecastID = value
            End Set
        End Property
        Public Property JobForecastRevisionID As Integer
            Get
                JobForecastRevisionID = _JobForecastRevisionID
            End Get
            Set(value As Integer)
                _JobForecastRevisionID = value
            End Set
        End Property
        Public Property JobForecastJobID As Integer
            Get
                JobForecastJobID = _JobForecastJobID
            End Get
            Set(value As Integer)
                _JobForecastJobID = value
            End Set
        End Property
        Public Property JobForecastDescription As String
            Get
                JobForecastDescription = _JobForecastDescription
            End Get
            Set(value As String)
                _JobForecastDescription = value
            End Set
        End Property
        Public Property RevisionNumber As Integer
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(value As Integer)
                _RevisionNumber = value
            End Set
        End Property
        Public Property IsHighestRevision As Boolean
            Get
                IsHighestRevision = _IsHighestRevision
            End Get
            Set(value As Boolean)
                _IsHighestRevision = value
            End Set
        End Property
        Public Property IsRevisionApproved As Boolean
            Get
                IsRevisionApproved = _IsRevisionApproved
            End Get
            Set(value As Boolean)
                _IsRevisionApproved = value
            End Set
        End Property
        Public Property ForecastHasApprovedRevision As Boolean
            Get
                ForecastHasApprovedRevision = _ForecastHasApprovedRevision
            End Get
            Set(value As Boolean)
                _ForecastHasApprovedRevision = value
            End Set
        End Property
        Public Property BillingAmount As Decimal?
            Get
                BillingAmount = _BillingAmount
            End Get
            Set(value As Decimal?)
                _BillingAmount = value
            End Set
        End Property
        Public Property RevenueAmount As Decimal?
            Get
                RevenueAmount = _RevenueAmount
            End Get
            Set(value As Decimal?)
                _RevenueAmount = value
            End Set
        End Property
        Public Property PostPeriodCode As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        Public Property PostPeriodStartDate As Date
            Get
                PostPeriodStartDate = _PostPeriodStartDate
            End Get
            Set(value As Date)
                _PostPeriodStartDate = value
            End Set
        End Property
        Public Property JobForecastCreateDate As Date
            Get
                JobForecastCreateDate = _JobForecastCreateDate
            End Get
            Set(value As Date)
                _JobForecastCreateDate = value
            End Set
        End Property
        Public Property GroupOrder As Integer
            Get
                GroupOrder = _GroupOrder
            End Get
            Set(value As Integer)
                _GroupOrder = value
            End Set
        End Property
        Public Property ForecastType As AdvantageFramework.JobForecast.JobForecastTypes
            Get
                ForecastType = _ForecastType
            End Get
            Set(value As AdvantageFramework.JobForecast.JobForecastTypes)
                _ForecastType = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Function AreAmountsEditable() As Boolean

            If IsRevisionApproved = True Then

                Return False

            Else

                Return IsHighestRevision

            End If

        End Function
        Public Function IsBillingEditable() As Boolean

            If Not AreAmountsEditable() Then

                Return False

            Else

                Return (Not _ForecastType = JobForecastTypes.Revenue)

            End If

        End Function
        Public Function IsRevenueEditable() As Boolean

            If Not AreAmountsEditable() Then

                Return False

            Else

                Return (Not _ForecastType = JobForecastTypes.Billing)

            End If

        End Function

#End Region

    End Class

End Namespace
