Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableExpenseImportBatchReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            InvoiceDescription
            InvoiceDate
            InvoiceAmount
            PostPeriodCode
            OfficeCode
            JobNumber
            JobComponentNumber
            FunctionCode
            Amount
            GLACode
            VendorCode
            VendorName
            EmployeeCode
            EmployeeName
            EmployeeDepartmentTeamCode
            IsDeletedInvoice
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As String = Nothing
        Private _InvoiceDescription As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _InvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _JobNumber As Nullable(Of Integer) = Nothing
        Private _JobComponentNumber As Nullable(Of Short) = Nothing
        Private _FunctionCode As String = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _GLACode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _EmployeeCode As String = Nothing
        Private _EmployeeName As String = Nothing
        Private _EmployeeDepartmentTeamCode As String = Nothing
        Private _IsDeletedInvoice As Boolean = False

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As String)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
            Set(ByVal value As String)
                _InvoiceDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Date)
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property InvoiceAmount() As Nullable(Of Decimal)
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _InvoiceAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(ByVal value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(ByVal value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobNumber() As Nullable(Of Integer)
            Get
                JobNumber = _JobNumber
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _JobNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property JobComponentNumber() As Nullable(Of Short)
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
            Set(ByVal value As Nullable(Of Short))
                _JobComponentNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(ByVal value As String)
                _GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeCode() As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
            Set(ByVal value As String)
                _EmployeeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeName() As String
            Get
                EmployeeName = _EmployeeName
            End Get
            Set(ByVal value As String)
                _EmployeeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeDepartmentTeamCode() As String
            Get
                EmployeeDepartmentTeamCode = _EmployeeDepartmentTeamCode
            End Get
            Set(ByVal value As String)
                _EmployeeDepartmentTeamCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsDeletedInvoice() As Boolean
            Get
                IsDeletedInvoice = _IsDeletedInvoice
            End Get
            Set(ByVal value As Boolean)
                _IsDeletedInvoice = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace