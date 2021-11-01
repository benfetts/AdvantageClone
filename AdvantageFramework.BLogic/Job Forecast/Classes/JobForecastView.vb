Namespace JobForecast.Classes

    <Serializable()>
    Public Class JobForecastView

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobForecastID
            JobForecastRevisionID
            RevisionNumber
            Description
            Comment
            Budget
            AssignedToEmployeeCode
            AssignedToEmployeeName
            IsApproved
            CreatedDate
            ModifiedDate
            PostPeriodStartDate
            PostPeriodEndDate
            IsHighestRevision
        End Enum

#End Region

#Region " Variables "

        Private _JobForecastID As Integer = Nothing
        Private _JobForecastRevisionID As Integer = Nothing
        Private _RevisionNumber As Integer = Nothing
        Private _Description As String = Nothing
        Private _Comment As String = Nothing
        Private _Budget As Nullable(Of Decimal) = Nothing
        Private _AssignedToEmployeeCode As String = Nothing
        Private _AssignedToEmployeeName As String = Nothing
        Private _IsApproved As Boolean = False
        Private _CreatedDate As Date = Nothing
        Private _ModifiedDate As Date? = Nothing
        Private _PostPeriodStartDate As Date? = Nothing
        Private _PostPeriodEndDate As Date? = Nothing
        Private _IsHighestRevision As Boolean = False

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
        Public Property RevisionNumber() As Integer
            Get
                RevisionNumber = _RevisionNumber
            End Get
            Set(value As Integer)
                _RevisionNumber = value
            End Set
        End Property
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(value As String)
                _Description = value
            End Set
        End Property
        Public Property Comment() As String
            Get
                Comment = _Comment
            End Get
            Set(value As String)
                _Comment = value
            End Set
        End Property
        Public Property Budget() As Nullable(Of Decimal)
            Get
                Budget = _Budget
            End Get
            Set(value As Nullable(Of Decimal))
                _Budget = value
            End Set
        End Property
        Public Property AssignedToEmployeeCode() As String
            Get
                AssignedToEmployeeCode = _AssignedToEmployeeCode
            End Get
            Set(value As String)
                _AssignedToEmployeeCode = value
            End Set
        End Property
        Public Property AssignedToEmployeeName() As String
            Get
                AssignedToEmployeeName = _AssignedToEmployeeName
            End Get
            Set(value As String)
                _AssignedToEmployeeName = value
            End Set
        End Property
        Public Property IsApproved() As Boolean
            Get
                IsApproved = _IsApproved
            End Get
            Set(value As Boolean)
                _IsApproved = value
            End Set
        End Property
        Public Property CreatedDate() As Date
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(value As Date)
                _CreatedDate = value
            End Set
        End Property
        Public Property ModifiedDate() As Date?
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Date?)
                _ModifiedDate = value
            End Set
        End Property
        Public Property PostPeriodStartDate() As Date?
            Get
                PostPeriodStartDate = _PostPeriodStartDate
            End Get
            Set(value As Date?)
                _PostPeriodStartDate = value
            End Set
        End Property
        Public Property PostPeriodEndDate() As Date?
            Get
                PostPeriodEndDate = _PostPeriodEndDate
            End Get
            Set(value As Date?)
                _PostPeriodEndDate = value
            End Set
        End Property
        Public Property IsHighestRevision() As Boolean
            Get
                IsHighestRevision = _IsHighestRevision
            End Get
            Set(value As Boolean)
                _IsHighestRevision = value
            End Set
        End Property

#End Region

#Region " Methods "


#End Region

    End Class

End Namespace