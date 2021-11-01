Namespace Reporting.Database.Classes

    <Serializable>
    Public Class AccountsPayableBalanceByVendor

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            VendorCode
            VendorName
            VendorAddress1
            VendorAddress2
            VendorAddress3
            VendorCity
            VendorCounty
            VendorState
            VendorZip
            VendorCountry
            VendorPhone
            VendorPhoneExt
            VendorFaxNumber
            VendorFaxExt
            VendorEmail
            VendorPayToCode
            VendorPayToName
            VendorPayToAddress1
            VendorPayToAddress2
            VendorPayToAddress3
            VendorPayToCity
            VendorPayToCounty
            VendorPayToState
            VendorPayToZip
            VendorPayToCountry
            VendorPayToPhone
            VendorPayToPhoneExt
            VendorPayToFax
            VendorPayToFaxExt
            VendorPayToEmail
            VendorDefaultCategory
            VendorOfficeCode
            VendorOfficeName
            VendorVCCStatus
            VendorBankCode
            VendorBankName
            VendorSpecialTerms
            VendorNotes
            VendorServiceTaxCode
            VendorServiceTaxDescription
            EmployeeVendor
            SubjectToVST
            InvoiceAmount
            TaxAmount
            APTotalAmount
            DisbursedClientTotal
            DisbursedNonClientTotal
            APGLAccountCode
            APGLAccountDescription
            MappedAccount
            TargetAccount
            VendorServiceTaxAmount
            BalanceDue
            APTotalUnpaid
            AbsoluteAmount
            DebitOrCredit
        End Enum

#End Region

#Region " Variables "

        Private _ID As System.Guid = Nothing
        Private _VendorCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _VendorAddress1 As String = Nothing
        Private _VendorAddress2 As String = Nothing
        Private _VendorAddress3 As String = Nothing
        Private _VendorCity As String = Nothing
        Private _VendorCounty As String = Nothing
        Private _VendorState As String = Nothing
        Private _VendorZip As String = Nothing
        Private _VendorCountry As String = Nothing
        Private _VendorPhone As String = Nothing
        Private _VendorPhoneExt As String = Nothing
        Private _VendorFaxNumber As String = Nothing
        Private _VendorFaxExt As String = Nothing
        Private _VendorEmail As String = Nothing
        Private _VendorPayToCode As String = Nothing
        Private _VendorPayToName As String = Nothing
        Private _VendorPayToAddress1 As String = Nothing
        Private _VendorPayToAddress2 As String = Nothing
        Private _VendorPayToAddress3 As String = Nothing
        Private _VendorPayToCity As String = Nothing
        Private _VendorPayToCounty As String = Nothing
        Private _VendorPayToState As String = Nothing
        Private _VendorPayToZip As String = Nothing
        Private _VendorPayToCountry As String = Nothing
        Private _VendorPayToPhone As String = Nothing
        Private _VendorPayToPhoneExt As String = Nothing
        Private _VendorPayToFax As String = Nothing
        Private _VendorPayToFaxExt As String = Nothing
        Private _VendorPayToEmail As String = Nothing
        Private _VendorDefaultCategory As String = Nothing
        Private _VendorOfficeCode As String = Nothing
        Private _VendorOfficeName As String = Nothing
        Private _VendorVCCStatus As String = Nothing
        Private _VendorBankCode As String = Nothing
        Private _VendorBankName As String = Nothing
        Private _VendorSpecialTerms As String = Nothing
        Private _VendorNotes As String = Nothing
        Private _VendorServiceTaxCode As String = Nothing
        Private _VendorServiceTaxDescription As String = Nothing
        Private _EmployeeVendor As String = Nothing
        Private _SubjectToVST As String = Nothing
        Private _InvoiceAmount As Decimal = Nothing
        Private _TaxAmount As Decimal = Nothing
        Private _APTotalAmount As Decimal = Nothing
        Private _DisbursedClientTotal As Decimal = Nothing
        Private _DisbursedNonClientTotal As Decimal = Nothing
        Private _APGLAccountCode As String = Nothing
        Private _APGLAccountDescription As String = Nothing
        Private _VendorServiceTaxAmount As Decimal = Nothing
        Private _BalanceDue As Decimal = Nothing
        Private _APTotalUnpaid As Nullable(Of Decimal) = Nothing
        Private _MappedAccount As String = Nothing
        Private _TargetAccount As String = Nothing
        Private _AbsoluteAmount As Decimal? = Nothing
        Private _DebitOrCredit As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As System.Guid
            Get
                ID = _ID
            End Get
            Set(ByVal value As System.Guid)
                _ID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorAddress1() As String
            Get
                VendorAddress1 = _VendorAddress1
            End Get
            Set(ByVal value As String)
                _VendorAddress1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorAddress2() As String
            Get
                VendorAddress2 = _VendorAddress2
            End Get
            Set(ByVal value As String)
                _VendorAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorAddress3() As String
            Get
                VendorAddress3 = _VendorAddress3
            End Get
            Set(ByVal value As String)
                _VendorAddress3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCity() As String
            Get
                VendorCity = _VendorCity
            End Get
            Set(ByVal value As String)
                _VendorCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCounty() As String
            Get
                VendorCounty = _VendorCounty
            End Get
            Set(ByVal value As String)
                _VendorCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorState() As String
            Get
                VendorState = _VendorState
            End Get
            Set(ByVal value As String)
                _VendorState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorZip() As String
            Get
                VendorZip = _VendorZip
            End Get
            Set(ByVal value As String)
                _VendorZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorCountry() As String
            Get
                VendorCountry = _VendorCountry
            End Get
            Set(ByVal value As String)
                _VendorCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPhone() As String
            Get
                VendorPhone = _VendorPhone
            End Get
            Set(ByVal value As String)
                _VendorPhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPhoneExt() As String
            Get
                VendorPhoneExt = _VendorPhoneExt
            End Get
            Set(ByVal value As String)
                _VendorPhoneExt = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorFaxNumber() As String
            Get
                VendorFaxNumber = _VendorFaxNumber
            End Get
            Set(ByVal value As String)
                _VendorFaxNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorFaxExt() As String
            Get
                VendorFaxExt = _VendorFaxExt
            End Get
            Set(ByVal value As String)
                _VendorFaxExt = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorEmail() As String
            Get
                VendorEmail = _VendorEmail
            End Get
            Set(ByVal value As String)
                _VendorEmail = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToCode() As String
            Get
                VendorPayToCode = _VendorPayToCode
            End Get
            Set(ByVal value As String)
                _VendorPayToCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToName() As String
            Get
                VendorPayToName = _VendorPayToName
            End Get
            Set(ByVal value As String)
                _VendorPayToName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToAddress1() As String
            Get
                VendorPayToAddress1 = _VendorPayToAddress1
            End Get
            Set(ByVal value As String)
                _VendorPayToAddress1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToAddress2() As String
            Get
                VendorPayToAddress2 = _VendorPayToAddress2
            End Get
            Set(ByVal value As String)
                _VendorPayToAddress2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToAddress3() As String
            Get
                VendorPayToAddress3 = _VendorPayToAddress3
            End Get
            Set(ByVal value As String)
                _VendorPayToAddress3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToCity() As String
            Get
                VendorPayToCity = _VendorPayToCity
            End Get
            Set(ByVal value As String)
                _VendorPayToCity = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToCounty() As String
            Get
                VendorPayToCounty = _VendorPayToCounty
            End Get
            Set(ByVal value As String)
                _VendorPayToCounty = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToState() As String
            Get
                VendorPayToState = _VendorPayToState
            End Get
            Set(ByVal value As String)
                _VendorPayToState = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToZip() As String
            Get
                VendorPayToZip = _VendorPayToZip
            End Get
            Set(ByVal value As String)
                _VendorPayToZip = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToCountry() As String
            Get
                VendorPayToCountry = _VendorPayToCountry
            End Get
            Set(ByVal value As String)
                _VendorPayToCountry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToPhone() As String
            Get
                VendorPayToPhone = _VendorPayToPhone
            End Get
            Set(ByVal value As String)
                _VendorPayToPhone = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToPhoneExt() As String
            Get
                VendorPayToPhoneExt = _VendorPayToPhoneExt
            End Get
            Set(ByVal value As String)
                _VendorPayToPhoneExt = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToFax() As String
            Get
                VendorPayToFax = _VendorPayToFax
            End Get
            Set(ByVal value As String)
                _VendorPayToFax = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToFaxExt() As String
            Get
                VendorPayToFaxExt = _VendorPayToFaxExt
            End Get
            Set(ByVal value As String)
                _VendorPayToFaxExt = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorPayToEmail() As String
            Get
                VendorPayToEmail = _VendorPayToEmail
            End Get
            Set(ByVal value As String)
                _VendorPayToEmail = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorDefaultCategory() As String
            Get
                VendorDefaultCategory = _VendorDefaultCategory
            End Get
            Set(ByVal value As String)
                _VendorDefaultCategory = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorOfficeCode() As String
            Get
                VendorOfficeCode = _VendorOfficeCode
            End Get
            Set(ByVal value As String)
                _VendorOfficeCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorOfficeName() As String
            Get
                VendorOfficeName = _VendorOfficeName
            End Get
            Set(ByVal value As String)
                _VendorOfficeName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorVCCStatus() As String
            Get
                VendorVCCStatus = _VendorVCCStatus
            End Get
            Set(ByVal value As String)
                _VendorVCCStatus = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorBankCode() As String
            Get
                VendorBankCode = _VendorBankCode
            End Get
            Set(ByVal value As String)
                _VendorBankCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorBankName() As String
            Get
                VendorBankName = _VendorBankName
            End Get
            Set(ByVal value As String)
                _VendorBankName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorSpecialTerms() As String
            Get
                VendorSpecialTerms = _VendorSpecialTerms
            End Get
            Set(ByVal value As String)
                _VendorSpecialTerms = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorNotes() As String
            Get
                VendorNotes = _VendorNotes
            End Get
            Set(ByVal value As String)
                _VendorNotes = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorServiceTaxCode() As String
            Get
                VendorServiceTaxCode = _VendorServiceTaxCode
            End Get
            Set(ByVal value As String)
                _VendorServiceTaxCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorServiceTaxDescription() As String
            Get
                VendorServiceTaxDescription = _VendorServiceTaxDescription
            End Get
            Set(ByVal value As String)
                _VendorServiceTaxDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property EmployeeVendor() As String
            Get
                EmployeeVendor = _EmployeeVendor
            End Get
            Set(ByVal value As String)
                _EmployeeVendor = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APGLAccountCode() As String
            Get
                APGLAccountCode = _APGLAccountCode
            End Get
            Set(ByVal value As String)
                _APGLAccountCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APGLAccountDescription() As String
            Get
                APGLAccountDescription = _APGLAccountDescription
            End Get
            Set(ByVal value As String)
                _APGLAccountDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MappedAccount() As String
            Get
                MappedAccount = _MappedAccount
            End Get
            Set(ByVal value As String)
                _MappedAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TargetAccount() As String
            Get
                TargetAccount = _TargetAccount
            End Get
            Set(ByVal value As String)
                _TargetAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property SubjectToVST() As String
            Get
                SubjectToVST = _SubjectToVST
            End Get
            Set(ByVal value As String)
                _SubjectToVST = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property InvoiceAmount() As Decimal
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(ByVal value As Decimal)
                _InvoiceAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property TaxAmount() As Decimal
            Get
                TaxAmount = _TaxAmount
            End Get
            Set(ByVal value As Decimal)
                _TaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorServiceTaxAmount() As Nullable(Of Decimal)
            Get
                VendorServiceTaxAmount = _VendorServiceTaxAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VendorServiceTaxAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property APTotalAmount() As Decimal
            Get
                APTotalAmount = _APTotalAmount
            End Get
            Set(ByVal value As Decimal)
                _APTotalAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DisbursedClientTotal() As Decimal
            Get
                DisbursedClientTotal = _DisbursedClientTotal
            End Get
            Set(ByVal value As Decimal)
                _DisbursedClientTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property DisbursedNonClientTotal() As Decimal
            Get
                DisbursedNonClientTotal = _DisbursedNonClientTotal
            End Get
            Set(ByVal value As Decimal)
                _DisbursedNonClientTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BalanceDue() As Nullable(Of Decimal)
            Get
                BalanceDue = _BalanceDue
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BalanceDue = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Unpaid")>
        Public Property APTotalUnpaid() As Nullable(Of Decimal)
            Get
                APTotalUnpaid = _APTotalUnpaid
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _APTotalUnpaid = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property AbsoluteAmount() As Nullable(Of Decimal)
            Get
                AbsoluteAmount = _AbsoluteAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _AbsoluteAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DebitOrCredit() As String
            Get
                DebitOrCredit = _DebitOrCredit
            End Get
            Set(ByVal value As String)
                _DebitOrCredit = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
