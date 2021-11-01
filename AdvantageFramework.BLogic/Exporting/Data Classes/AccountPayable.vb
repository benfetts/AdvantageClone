Namespace Exporting.DataClasses

    <Serializable()>
    Public Class AccountPayable
        Implements AdvantageFramework.Exporting.Interfaces.IExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            VendorAccount
            VendorFederalTaxID
            VendorEmailAddress
            VCCStatusCode
            VCCStatusDescription
            InvoiceNumber
            ExpenseReportYN
            InvoiceDescription
            InvoiceDate
            DateToPay
            InvoiceAmount
            SalesTaxAmount
            IsOnHold
            GLACode
            PostPeriodCode
            OfficeCode
            Is1099Invoice
            EntryBy
            EntryDate
            ModifiedBy
            ModifiedDate
            BatchName
            DetailType
            DetailClientCode
            DetailDivisionCode
            DetailProductCode
            DetailFunctionCode
            DetailSalesClassCode
            DetailVendorTax
            DetailDisbursedAmount
            DetailOfficeCode
            DetailGLACode
            DetailGLACodeBilling
        End Enum

#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing
        Private _VendorAccount As String = Nothing
        Private _VendorFederalTaxID As String = Nothing
        Private _VendorEmailAddress As String = Nothing
        Private _VCCStatusCode As Nullable(Of Short) = Nothing
        Private _VCCStatusDescription As String = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _ExpenseReportYN As String = Nothing
        Private _InvoiceDescription As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _DateToPay As Date = Nothing
        Private _InvoiceAmount As Decimal = Nothing
        Private _SalesTaxAmount As Decimal = Nothing
        Private _IsOnHold As String = Nothing
        Private _GLACode As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _OfficeCode As String = Nothing
        Private _Is1099Invoice As String = Nothing
        Private _EntryBy As String = Nothing
        Private _EntryDate As Nullable(Of Date) = Nothing
        Private _ModifiedBy As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _BatchName As String = Nothing
        Private _DetailType As String = Nothing
        Private _DetailClientCode As String = Nothing
        Private _DetailDivisionCode As String = Nothing
        Private _DetailProductCode As String = Nothing
        Private _DetailFunctionCode As String = Nothing
        Private _DetailSalesClassCode As String = Nothing
        Private _DetailVendorTax As Nullable(Of Decimal) = Nothing
        Private _DetailDisbursedAmount As Nullable(Of Decimal) = Nothing
        Private _DetailOfficeCode As String = Nothing
        Private _DetailGLACode As String = Nothing
        Private _DetailGLACodeBilling As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorAccount() As String
            Get
                VendorAccount = _VendorAccount
            End Get
            Set(value As String)
                _VendorAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorFederalTaxID() As String
            Get
                VendorFederalTaxID = _VendorFederalTaxID
            End Get
            Set(value As String)
                _VendorFederalTaxID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorEmailAddress() As String
            Get
                VendorEmailAddress = _VendorEmailAddress
            End Get
            Set(value As String)
                _VendorEmailAddress = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VCCStatusCode() As Nullable(Of Short)
            Get
                VCCStatusCode = _VCCStatusCode
            End Get
            Set(value As Nullable(Of Short))
                _VCCStatusCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VCCStatusDescription() As String
            Get
                VCCStatusDescription = _VCCStatusDescription
            End Get
            Set(value As String)
                _VCCStatusDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(value As String)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ExpenseReportYN() As String
            Get
                ExpenseReportYN = _ExpenseReportYN
            End Get
            Set(value As String)
                _ExpenseReportYN = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceDescription() As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
            Set(value As String)
                _InvoiceDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(value As Date)
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DateToPay() As Date
            Get
                DateToPay = _DateToPay
            End Get
            Set(value As Date)
                _DateToPay = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property InvoiceAmount As Decimal
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(value As Decimal)
                _InvoiceAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property SalesTaxAmount() As Decimal
            Get
                SalesTaxAmount = _SalesTaxAmount
            End Get
            Set(value As Decimal)
                _SalesTaxAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property IsOnHold() As String
            Get
                IsOnHold = _IsOnHold
            End Get
            Set(value As String)
                _IsOnHold = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property GLACode() As String
            Get
                GLACode = _GLACode
            End Get
            Set(value As String)
                _GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Is 1099 Invoice")>
        Public Property Is1099Invoice() As String
            Get
                Is1099Invoice = _Is1099Invoice
            End Get
            Set(value As String)
                _Is1099Invoice = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EntryBy() As String
            Get
                EntryBy = _EntryBy
            End Get
            Set(value As String)
                _EntryBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EntryDate() As Nullable(Of Date)
            Get
                EntryDate = _EntryDate
            End Get
            Set(value As Nullable(Of Date))
                _EntryDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ModifiedBy() As String
            Get
                ModifiedBy = _ModifiedBy
            End Get
            Set(value As String)
                _ModifiedBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property BatchName() As String
            Get
                BatchName = _BatchName
            End Get
            Set(value As String)
                _BatchName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailType() As String
            Get
                DetailType = _DetailType
            End Get
            Set(value As String)
                _DetailType = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailClientCode() As String
            Get
                DetailClientCode = _DetailClientCode
            End Get
            Set(value As String)
                _DetailClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailDivisionCode() As String
            Get
                DetailDivisionCode = _DetailDivisionCode
            End Get
            Set(value As String)
                _DetailDivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailProductCode() As String
            Get
                DetailProductCode = _DetailProductCode
            End Get
            Set(value As String)
                _DetailProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailFunctionCode() As String
            Get
                DetailFunctionCode = _DetailFunctionCode
            End Get
            Set(value As String)
                _DetailFunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailSalesClassCode() As String
            Get
                DetailSalesClassCode = _DetailSalesClassCode
            End Get
            Set(value As String)
                _DetailSalesClassCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property DetailVendorTax() As Nullable(Of Decimal)
            Get
                DetailVendorTax = _DetailVendorTax
            End Get
            Set(value As Nullable(Of Decimal))
                _DetailVendorTax = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property DetailDisbursedAmount() As Nullable(Of Decimal)
            Get
                DetailDisbursedAmount = _DetailDisbursedAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _DetailDisbursedAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailOfficeCode() As String
            Get
                DetailOfficeCode = _DetailOfficeCode
            End Get
            Set(value As String)
                _DetailOfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailGLACode() As String
            Get
                DetailGLACode = _DetailGLACode
            End Get
            Set(value As String)
                _DetailGLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DetailGLACodeBilling() As String
            Get
                DetailGLACodeBilling = _DetailGLACodeBilling
            End Get
            Set(value As String)
                _DetailGLACodeBilling = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
