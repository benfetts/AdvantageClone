Namespace Database.Classes

	<Serializable()>
	Public Class AccountsPayableInvoiceWithBalanceAgingReport
		Inherits BaseClasses.BaseClass

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
			APIdentifier
			APType
			InvoiceNumber
			APDescription
            EntryDate
            PostedToSummary
            InvoiceDate
			DateToPay
			PostingPeriod
			InvoiceAmount
			TaxAmount
			APTotalAmount
			DiscountPercentage
			DiscountAmount
			APTotalDue
			DisbursedClientTotal
			DisbursedNonClientTotal
			VendorTermsCode
			VendorTermsDesc
            APGLXact
            APGLSequenceNumber
            APGLAccountCode
            APGLAccountDescription
            MappedAccount
            TargetAccount
            CurrencyCode
			CurrencyDescription
			CurrencyRate
			ExchangeGLAccountCode
			ExchangeGLAccountDescription
			OnPaymentHold
			Is1099Invoice
			PaidToVendor
			VendorServiceTaxAmount
			TotalPaidToVendor
			BalanceDue
			DiscountTaken
			LastCheckNumber
			LastCheckDate
            APTotalDueUnpaid
            AbsoluteAmount
            DebitOrCredit
            APTotalDueUnpaidCurrent
			APTotalDueUnpaid1to30Days
			APTotalDueUnpaid31to60Days
			APTotalDueUnpaid61to90Days
			APTotalDueUnpaid91to120Days
			APTotalDueUnpaid120PlusDays
			DaysToPayment
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
		Private _APIdentifier As Integer = Nothing
		Private _APType As String = Nothing
		Private _InvoiceNumber As String = Nothing
        Private _APDescription As String = Nothing
        Private _EntryDate As System.Nullable(Of Date) = Nothing
        Private _PostedToSummary As System.Nullable(Of Date) = Nothing
        Private _InvoiceDate As Date = Nothing
		Private _DateToPay As Date = Nothing
		Private _PostingPeriod As String = Nothing
		Private _InvoiceAmount As Decimal = Nothing
		Private _TaxAmount As Decimal = Nothing
		Private _APTotalAmount As Decimal = Nothing
		Private _DiscountPercentage As Nullable(Of Decimal) = Nothing
		Private _DiscountAmount As Decimal = Nothing
		Private _APTotalDue As Decimal = Nothing
		Private _DisbursedClientTotal As Decimal = Nothing
		Private _DisbursedNonClientTotal As Decimal = Nothing
		Private _VendorTermsCode As String = Nothing
		Private _VendorTermsDesc As String = Nothing
        Private _APGLXact As Integer = Nothing
        Private _APGLSequenceNumber As Short = Nothing
        Private _APGLAccountCode As String = Nothing
        Private _APGLAccountDescription As String = Nothing
        Private _MappedAccount As String = Nothing
        Private _TargetAccount As String = Nothing
        Private _CurrencyCode As String = Nothing
		Private _CurrencyDescription As String = Nothing
		Private _CurrencyRate As Nullable(Of Decimal) = Nothing
		Private _ExchangeGLAccountCode As String = Nothing
		Private _ExchangeGLAccountDescription As String = Nothing
		Private _OnPaymentHold As Boolean = Nothing
		Private _Is1099Invoice As Boolean = Nothing
		Private _PaidToVendor As Decimal = Nothing
		Private _VendorServiceTaxAmount As Decimal = Nothing
		Private _TotalPaidToVendor As Decimal = Nothing
		Private _BalanceDue As Decimal = Nothing
		Private _DiscountTaken As Decimal = Nothing
		Private _LastCheckNumber As Nullable(Of Integer) = Nothing
        Private _LastCheckDate As Nullable(Of Date) = Nothing
        Private _APTotalDueUnpaid As Nullable(Of Decimal) = Nothing
        Private _AbsoluteAmount As Nullable(Of Decimal) = Nothing
        Private _DebitOrCredit As String = Nothing
        Private _APTotalDueUnpaidCurrent As Nullable(Of Decimal) = Nothing
		Private _APTotalDueUnpaid1to30Days As Nullable(Of Decimal) = Nothing
		Private _APTotalDueUnpaid31to60Days As Nullable(Of Decimal) = Nothing
		Private _APTotalDueUnpaid61to90Days As Nullable(Of Decimal) = Nothing
		Private _APTotalDueUnpaid91to120Days As Nullable(Of Decimal) = Nothing
		Private _APTotalDueUnpaid120PlusDays As Nullable(Of Decimal) = Nothing
		Private _DaysToPayment As Nullable(Of Integer) = Nothing

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
		Public Property SubjectToVST() As String
			Get
				SubjectToVST = _SubjectToVST
			End Get
			Set(ByVal value As String)
				_SubjectToVST = value
			End Set
		End Property
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property APIdentifier() As Integer
			Get
				APIdentifier = _APIdentifier
			End Get
			Set(ByVal value As Integer)
				_APIdentifier = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APType() As String
			Get
				APType = _APType
			End Get
			Set(ByVal value As String)
				_APType = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceNumber() As String
			Get
				InvoiceNumber = _InvoiceNumber
			End Get
			Set(ByVal value As String)
				_InvoiceNumber = value
			End Set
		End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APDescription() As String
            Get
                APDescription = _APDescription
            End Get
            Set(ByVal value As String)
                _APDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="G")>
        Public Property EntryDate() As Nullable(Of Date)
            Get
                EntryDate = _EntryDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _EntryDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d")>
        Public Property PostedToSummary() As Nullable(Of Date)
            Get
                PostedToSummary = _PostedToSummary
            End Get
            Set(ByVal value As Nullable(Of Date))
                _PostedToSummary = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceDate() As Date
			Get
				InvoiceDate = _InvoiceDate
			End Get
			Set(ByVal value As Date)
				_InvoiceDate = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DateToPay() As Date
			Get
				DateToPay = _DateToPay
			End Get
			Set(ByVal value As Date)
				_DateToPay = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostingPeriod() As String
			Get
				PostingPeriod = _PostingPeriod
			End Get
			Set(ByVal value As String)
				_PostingPeriod = value
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
		Public Property APTotalAmount() As Decimal
			Get
				APTotalAmount = _APTotalAmount
			End Get
			Set(ByVal value As Decimal)
				_APTotalAmount = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
		Public Property DiscountPercentage() As Nullable(Of Decimal)
			Get
				DiscountPercentage = _DiscountPercentage
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_DiscountPercentage = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property DiscountAmount() As Decimal
			Get
				DiscountAmount = _DiscountAmount
			End Get
			Set(ByVal value As Decimal)
				_DiscountAmount = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Less Discount")>
		Public Property APTotalDue() As Decimal
			Get
				APTotalDue = _APTotalDue
			End Get
			Set(ByVal value As Decimal)
				_APTotalDue = value
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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorTermsCode() As String
			Get
				VendorTermsCode = _VendorTermsCode
			End Get
			Set(ByVal value As String)
				_VendorTermsCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorTermsDesc() As String
			Get
				VendorTermsDesc = _VendorTermsDesc
			End Get
			Set(ByVal value As String)
				_VendorTermsDesc = value
			End Set
		End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property APGLXact() As Integer
            Get
                APGLXact = _APGLXact
            End Get
            Set(ByVal value As Integer)
                _APGLXact = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property APGLSequenceNumber() As Short
            Get
                APGLSequenceNumber = _APGLSequenceNumber
            End Get
            Set(ByVal value As Short)
                _APGLSequenceNumber = value
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
		Public Property CurrencyCode() As String
			Get
				CurrencyCode = _CurrencyCode
			End Get
			Set(ByVal value As String)
				_CurrencyCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CurrencyDescription() As String
			Get
				CurrencyDescription = _CurrencyDescription
			End Get
			Set(ByVal value As String)
				_CurrencyDescription = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n6")>
		Public Property CurrencyRate() As Nullable(Of Decimal)
			Get
				CurrencyRate = _CurrencyRate
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_CurrencyRate = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExchangeGLAccountCode() As String
			Get
				ExchangeGLAccountCode = _ExchangeGLAccountCode
			End Get
			Set(ByVal value As String)
				_ExchangeGLAccountCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ExchangeGLAccountDescription() As String
			Get
				ExchangeGLAccountDescription = _ExchangeGLAccountDescription
			End Get
			Set(ByVal value As String)
				_ExchangeGLAccountDescription = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OnPaymentHold() As Boolean
			Get
				OnPaymentHold = _OnPaymentHold
			End Get
			Set(ByVal value As Boolean)
				_OnPaymentHold = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Is1099Invoice() As Boolean
			Get
				Is1099Invoice = _Is1099Invoice
			End Get
			Set(ByVal value As Boolean)
				_Is1099Invoice = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property PaidToVendor() As Nullable(Of Decimal)
			Get
				PaidToVendor = _PaidToVendor
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_PaidToVendor = value
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
		Public Property TotalPaidToVendor() As Nullable(Of Decimal)
			Get
				TotalPaidToVendor = _TotalPaidToVendor
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_TotalPaidToVendor = value
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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property DiscountTaken() As Decimal
			Get
				DiscountTaken = _DiscountTaken
			End Get
			Set(ByVal value As Decimal)
				_DiscountTaken = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property LastCheckNumber() As Nullable(Of Integer)
			Get
				LastCheckNumber = _LastCheckNumber
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_LastCheckNumber = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LastCheckDate() As Nullable(Of Date)
			Get
				LastCheckDate = _LastCheckDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_LastCheckDate = value
			End Set
		End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Unpaid")>
        Public Property APTotalDueUnpaid() As Nullable(Of Decimal)
            Get
                APTotalDueUnpaid = _APTotalDueUnpaid
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _APTotalDueUnpaid = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Unpaid Current")>
		Public Property APTotalDueUnpaidCurrent() As Nullable(Of Decimal)
			Get
				APTotalDueUnpaidCurrent = _APTotalDueUnpaidCurrent
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_APTotalDueUnpaidCurrent = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Unpaid 1 to 30 Days")>
		Public Property APTotalDueUnpaid1to30Days() As Nullable(Of Decimal)
			Get
				APTotalDueUnpaid1to30Days = _APTotalDueUnpaid1to30Days
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_APTotalDueUnpaid1to30Days = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Unpaid 31 to 60 Days")>
		Public Property APTotalDueUnpaid31to60Days() As Nullable(Of Decimal)
			Get
				APTotalDueUnpaid31to60Days = _APTotalDueUnpaid31to60Days
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_APTotalDueUnpaid31to60Days = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Unpaid 61 to 90 Days")>
		Public Property APTotalDueUnpaid61to90Days() As Nullable(Of Decimal)
			Get
				APTotalDueUnpaid61to90Days = _APTotalDueUnpaid61to90Days
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_APTotalDueUnpaid61to90Days = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Unpaid 91 to 120 Days")>
		Public Property APTotalDueUnpaid91to120Days() As Nullable(Of Decimal)
			Get
				APTotalDueUnpaid91to120Days = _APTotalDueUnpaid91to120Days
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_APTotalDueUnpaid91to120Days = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="AP Total Unpaid 120 Plus Days")>
		Public Property APTotalDueUnpaid120PlusDays() As Nullable(Of Decimal)
			Get
				APTotalDueUnpaid120PlusDays = _APTotalDueUnpaid120PlusDays
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_APTotalDueUnpaid120PlusDays = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Days to Payment")>
		Public Property DaysToPayment() As Nullable(Of Integer)
			Get
				DaysToPayment = _DaysToPayment
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_DaysToPayment = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub New()

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
