Namespace Database.Classes

    <Serializable()>
    Public Class ExpenseReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            EmployeeCode
            VendorCode
            InvoiceDate
            CreatedDate
            Description
            Details
            DateFrom
            DateTo
            InvoiceAmount
            ApprovedBy
            ApprovedDate
            Status
            ApproverNotes
            IsSubmitted
            SubmittedTo
            IsApproved
            TotalNonBillable
            TotalBillable
            TotalAmount
            Paid
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As Integer = Nothing
        Private _EmployeeCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _InvoiceDate As Nullable(Of Date) = Nothing
        Private _CreatedDate As Nullable(Of Date) = Nothing
        Private _Description As String = Nothing
        Private _Details As String = Nothing
        Private _DateFrom As Nullable(Of Date) = Nothing
        Private _DateTo As Nullable(Of Date) = Nothing
        Private _InvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _ApprovedBy As String = Nothing
        Private _ApprovedDate As Nullable(Of Date) = Nothing
        Private _Status As Nullable(Of Integer) = Nothing
        Private _ApproverNotes As String = Nothing
        Private _IsSubmitted As Nullable(Of Short) = Nothing
        Private _SubmittedTo As String = Nothing
        Private _IsApproved As Nullable(Of Short) = Nothing
        Private _TotalNonBillable As Nullable(Of Decimal) = Nothing
        Private _TotalBillable As Nullable(Of Decimal) = Nothing
        Private _TotalAmount As Nullable(Of Decimal) = Nothing
        Private _DetailStatus As String = Nothing
        Private _Paid As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumber() As Integer
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Report Date")>
        Public Property InvoiceDate() As Nullable(Of Date)
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Nullable(Of Date))
                _InvoiceDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Created Date")>
        Public Property CreatedDate() As Nullable(Of Date)
            Get
                CreatedDate = _CreatedDate
            End Get
            Set(value As Nullable(Of Date))
                _CreatedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Details() As String
            Get
                Details = _Details
            End Get
            Set(ByVal value As String)
                _Details = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DateFrom() As Nullable(Of Date)
            Get
                DateFrom = _DateFrom
            End Get
            Set(value As Nullable(Of Date))
                _DateFrom = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property DateTo() As Nullable(Of Date)
            Get
                DateTo = _DateTo
            End Get
            Set(value As Nullable(Of Date))
                _DateTo = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property InvoiceAmount() As Nullable(Of Decimal)
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _InvoiceAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ApprovedBy() As String
            Get
                ApprovedBy = _ApprovedBy
            End Get
            Set(value As String)
                _ApprovedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ApprovedDate() As Nullable(Of Date)
            Get
                ApprovedDate = _ApprovedDate
            End Get
            Set(value As Nullable(Of Date))
                _ApprovedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property Status() As Nullable(Of Integer)
            Get
                Status = _Status
            End Get
            Set(value As Nullable(Of Integer))
                _Status = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Status")>
        Public Property DetailStatus() As String
            Get
                DetailStatus = _DetailStatus
            End Get
            Set(value As String)
                _DetailStatus = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ApproverNotes() As String
            Get
                ApproverNotes = _ApproverNotes
            End Get
            Set(value As String)
                _ApproverNotes = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsSubmitted() As Nullable(Of Short)
            Get
                IsSubmitted = _IsSubmitted
            End Get
            Set(value As Nullable(Of Short))
                _IsSubmitted = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property SubmittedTo() As String
            Get
                SubmittedTo = _SubmittedTo
            End Get
            Set(value As String)
                _SubmittedTo = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property IsApproved() As Nullable(Of Short)
            Get
                IsApproved = _IsApproved
            End Get
            Set(value As Nullable(Of Short))
                _IsApproved = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="C2")>
        Public Property TotalNonBillable() As Nullable(Of Decimal)
            Get
                TotalNonBillable = _TotalNonBillable
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalNonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="C2")>
        Public Property TotalBillable() As Nullable(Of Decimal)
            Get
                TotalBillable = _TotalBillable
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="C2")>
        Public Property TotalAmount() As Nullable(Of Decimal)
            Get
                TotalAmount = _TotalAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _TotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ImageWhenCheckedCheckBox)>
        Public Property Paid() As Boolean
            Get
                Paid = _Paid
            End Get
            Set(value As Boolean)
                _Paid = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport, ByVal DbContext As AdvantageFramework.Database.DbContext)

            _InvoiceNumber = ExpenseReport.InvoiceNumber
            _EmployeeCode = ExpenseReport.EmployeeCode
            _VendorCode = ExpenseReport.VendorCode
            _InvoiceDate = ExpenseReport.InvoiceDate
            _CreatedDate = ExpenseReport.CreatedDate
            _Description = ExpenseReport.Description
            _Details = ExpenseReport.Details
            _DateFrom = ExpenseReport.DateFrom
            _DateTo = ExpenseReport.DateTo
            _InvoiceAmount = ExpenseReport.InvoiceAmount
            _ApprovedBy = ExpenseReport.ApprovedBy
            _ApprovedDate = ExpenseReport.ApprovedDate
            _Status = ExpenseReport.Status
            _ApproverNotes = ExpenseReport.ApproverNotes
            _IsSubmitted = ExpenseReport.IsSubmitted
            _SubmittedTo = ExpenseReport.SubmittedTo
            _IsApproved = ExpenseReport.IsApproved

            _Paid = AdvantageFramework.ExpenseReports.HasExpenseReportBeenPaid(DbContext, _EmployeeCode, _InvoiceNumber)
            _DetailStatus = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.ExpenseReports.ExpenseReportStatus), AdvantageFramework.ExpenseReports.LoadExpenseReportStatus(ExpenseReport))

            AdvantageFramework.ExpenseReports.LoadExpenseReportTotals(DbContext, Me)

        End Sub
        'Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

        '    ' Objects
        '    Dim ErrorText As String = ""

        '    ErrorText = _Employee.ValidateEntityProperty(PropertyName, IsValid, Value)

        '    ValidateCustomProperties = ErrorText

        'End Function

#End Region

    End Class

End Namespace