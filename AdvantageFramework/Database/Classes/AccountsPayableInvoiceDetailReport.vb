Namespace Database.Classes

	<Serializable()>
	Public Class AccountsPayableInvoiceDetailReport
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
			VendorAccountNumber
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
			EntryBy
			ModifiedBy
            ModifiedDate
            IsDeleted
            BatchName
			InvoiceDate
			DateToPay
			PostingPeriod
			APGLXact
			APGLAccountCode
			APGLAccountDescription
			DaysOpen
			OnPaymentHold
			DisbursementType
			ClientCode
			ClientName
			DivisionCode
			DivisonName
			ProductCode
			ProductDescription
			JobNumber
			JobDescription
			JobComponentNbr
			JobComponentDesc
			JobComponent
			FunctionCode
			FunctionDescription
			PONumber
			POLineNumber
			POIssuedByEmployeeCode
			POIssuedByEmployeeName
			POLineTotal
			OrderNumber
			OrderLineNbr
			OrderPeriod
			OrderDescription
			DetailGLAccountCode
			DetailGLAccountDescription
			APDetailComment
            ARInvoiceNumberDirect
            ARInvoiceDateDirect
            Billed
			VendorTax
			DetailAmount
			TotalAmount
			PaidToVendor
			VendorServiceTaxAmount
			TotalPaidToVendor
			LastCheckNumber
            LastCheckDate
            BankCode
			BankDescription
			BalanceDue
			CampaignID
			CampaignCode
			CampaignDescription
			DaysToPayment
            ApprovalStatus
            NonBillable
            DetailPostingPeriod
            ARInvoiceAmount
            CashReceivedAmount
            PartialPaymentIndicator
            CashReceivedAmtByOrderLine
            BilledNetAmountByOrderLine
            BilledGrossAmountByOrderLine
            UnbilledAmountByOrderLine
            DetailModifiedBy
            DetailModifiedDate
            ClientPO
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
		Private _VendorAccountNumber As String = Nothing
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
		Private _EntryBy As String = Nothing
		Private _ModifiedBy As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _IsDeleted As String = Nothing
        Private _BatchName As String = Nothing
		Private _InvoiceDate As Date = Nothing
		Private _DateToPay As Date = Nothing
		Private _PostingPeriod As String = Nothing
		Private _APGLXact As Integer = Nothing
		Private _APGLAccountCode As String = Nothing
		Private _APGLAccountDescription As String = Nothing
		Private _DaysOpen As Integer = Nothing
		Private _OnPaymentHold As Boolean = Nothing
		Private _DisbursementType As String = Nothing
		Private _ClientCode As String = Nothing
		Private _ClientName As String = Nothing
		Private _DivisionCode As String = Nothing
		Private _DivisonName As String = Nothing
		Private _ProductCode As String = Nothing
		Private _ProductDescription As String = Nothing
		Private _JobNumber As Nullable(Of Integer) = Nothing
		Private _JobDescription As String = Nothing
		Private _JobComponentNbr As Nullable(Of Short) = Nothing
		Private _JobComponentDesc As String = Nothing
		Private _JobComponent As String = Nothing
		Private _FunctionCode As String = Nothing
		Private _FunctionDescription As String = Nothing
		Private _PONumber As Nullable(Of Integer) = Nothing
		Private _POLineNumber As Nullable(Of Short) = Nothing
		Private _POIssuedByEmployeeCode As String = Nothing
		Private _POIssuedByEmployeeName As String = Nothing
		Private _POLineTotal As Nullable(Of Decimal) = Nothing
		Private _OrderNumber As Nullable(Of Integer) = Nothing
		Private _OrderLineNbr As Nullable(Of Short) = Nothing
		Private _OrderPeriod As String = Nothing
		Private _OrderDescription As String = Nothing
		Private _DetailGLAccountCode As String = Nothing
		Private _DetailGLAccountDescription As String = Nothing
		Private _APDetailComment As String = Nothing
        Private _ARInvoiceNumberDirect As Nullable(Of Integer) = Nothing
        Private _ARInvoiceDateDirect As Nullable(Of Date) = Nothing
        Private _Billed As Boolean = Nothing
		Private _VendorTax As Nullable(Of Decimal) = Nothing
		Private _DetailAmount As Nullable(Of Decimal) = Nothing
		Private _TotalAmount As Nullable(Of Decimal) = Nothing
		Private _PaidToVendor As Nullable(Of Decimal) = Nothing
		Private _VendorServiceTaxAmount As Nullable(Of Decimal) = Nothing
		Private _TotalPaidToVendor As Nullable(Of Decimal) = Nothing
		Private _LastCheckNumber As Nullable(Of Integer) = Nothing
        Private _LastCheckDate As Nullable(Of Date) = Nothing
        Private _BankCode As String = Nothing
		Private _BankDescription As String = Nothing
		Private _BalanceDue As Nullable(Of Decimal) = Nothing
		Private _CampaignID As Nullable(Of Integer) = Nothing
		Private _CampaignCode As String = Nothing
		Private _CampaignDescription As String = Nothing
		Private _DaysToPayment As Nullable(Of Integer) = Nothing
        Private _ApprovalStatus As String = Nothing
        Private _NonBillable As String = Nothing
        Private _DetailPostingPeriod As String = Nothing
        Private _ARInvoiceAmount As Nullable(Of Decimal) = Nothing
        Private _CashReceivedAmount As Nullable(Of Decimal) = Nothing
        Private _PartialPaymentIndicator As String = Nothing

        Private _CashReceivedAmtByOrderLine As Nullable(Of Decimal) = Nothing
        Private _BilledNetAmountByOrderLine As Nullable(Of Decimal) = Nothing
        Private _BilledGrossAmountByOrderLine As Nullable(Of Decimal) = Nothing
        Private _UnbilledAmountByOrderLine As Nullable(Of Decimal) = Nothing

        Private _DetailModifiedBy As String = Nothing
        Private _DetailModifiedDate As Nullable(Of Date) = Nothing
        Private _ClientPO As String = Nothing

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
		Public Property VendorAccountNumber() As String
			Get
				VendorAccountNumber = _VendorAccountNumber
			End Get
			Set(ByVal value As String)
				_VendorAccountNumber = value
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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EntryDate() As Nullable(Of Date)
			Get
				EntryDate = _EntryDate
			End Get
			Set(ByVal value As Nullable(Of Date))
				_EntryDate = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EntryBy() As String
			Get
				EntryBy = _EntryBy
			End Get
			Set(ByVal value As String)
				_EntryBy = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
			Get
				ModifiedBy = _ModifiedBy
			End Get
			Set(ByVal value As String)
				_ModifiedBy = value
			End Set
		End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ModifiedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsDeleted() As String
            Get
                IsDeleted = _IsDeleted
            End Get
            Set(ByVal value As String)
                _IsDeleted = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchName() As String
			Get
				BatchName = _BatchName
			End Get
			Set(ByVal value As String)
				_BatchName = value
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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property APGLXact() As Integer
			Get
				APGLXact = _APGLXact
			End Get
			Set(ByVal value As Integer)
				_APGLXact = value
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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="Days Open Aging")>
		Public Property DaysOpen() As Integer
			Get
				DaysOpen = _DaysOpen
			End Get
			Set(ByVal value As Integer)
				_DaysOpen = value
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
		Public Property DisbursementType() As String
			Get
				DisbursementType = _DisbursementType
			End Get
			Set(ByVal value As String)
				_DisbursementType = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
			Get
				ClientCode = _ClientCode
			End Get
			Set(ByVal value As String)
				_ClientCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientName() As String
			Get
				ClientName = _ClientName
			End Get
			Set(ByVal value As String)
				_ClientName = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
			Get
				DivisionCode = _DivisionCode
			End Get
			Set(ByVal value As String)
				_DivisionCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisonName() As String
			Get
				DivisonName = _DivisonName
			End Get
			Set(ByVal value As String)
				_DivisonName = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
			Get
				ProductCode = _ProductCode
			End Get
			Set(ByVal value As String)
				_ProductCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductDescription() As String
			Get
				ProductDescription = _ProductDescription
			End Get
			Set(ByVal value As String)
				_ProductDescription = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property JobNumber() As Nullable(Of Integer)
			Get
				JobNumber = _JobNumber
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_JobNumber = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobDescription() As String
			Get
				JobDescription = _JobDescription
			End Get
			Set(ByVal value As String)
				_JobDescription = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property JobComponentNbr() As Nullable(Of Short)
			Get
				JobComponentNbr = _JobComponentNbr
			End Get
			Set(ByVal value As Nullable(Of Short))
				_JobComponentNbr = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentDesc() As String
			Get
				JobComponentDesc = _JobComponentDesc
			End Get
			Set(ByVal value As String)
				_JobComponentDesc = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponent() As String
			Get
				JobComponent = _JobComponent
			End Get
			Set(ByVal value As String)
				_JobComponent = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionCode() As String
			Get
				FunctionCode = _FunctionCode
			End Get
			Set(ByVal value As String)
				_FunctionCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionDescription() As String
			Get
				FunctionDescription = _FunctionDescription
			End Get
			Set(ByVal value As String)
				_FunctionDescription = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property PONumber() As Nullable(Of Integer)
			Get
				PONumber = _PONumber
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_PONumber = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property POLineNumber() As Nullable(Of Short)
			Get
				POLineNumber = _POLineNumber
			End Get
			Set(ByVal value As Nullable(Of Short))
				_POLineNumber = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POIssuedByEmployeeCode() As String
			Get
				POIssuedByEmployeeCode = _POIssuedByEmployeeCode
			End Get
			Set(ByVal value As String)
				_POIssuedByEmployeeCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property POIssuedByEmployeeName() As String
			Get
				POIssuedByEmployeeName = _POIssuedByEmployeeName
			End Get
			Set(ByVal value As String)
				_POIssuedByEmployeeName = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f2")>
		Public Property POLineTotal() As Nullable(Of Decimal)
			Get
				POLineTotal = _POLineTotal
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_POLineTotal = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property OrderNumber() As Nullable(Of Integer)
			Get
				OrderNumber = _OrderNumber
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_OrderNumber = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property OrderLineNbr() As Nullable(Of Short)
			Get
				OrderLineNbr = _OrderLineNbr
			End Get
			Set(ByVal value As Nullable(Of Short))
				_OrderLineNbr = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderPeriod() As String
			Get
				OrderPeriod = _OrderPeriod
			End Get
			Set(ByVal value As String)
				_OrderPeriod = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderDescription() As String
			Get
				OrderDescription = _OrderDescription
			End Get
			Set(ByVal value As String)
				_OrderDescription = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DetailGLAccountCode() As String
			Get
				DetailGLAccountCode = _DetailGLAccountCode
			End Get
			Set(ByVal value As String)
				_DetailGLAccountCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DetailGLAccountDescription() As String
			Get
				DetailGLAccountDescription = _DetailGLAccountDescription
			End Get
			Set(ByVal value As String)
				_DetailGLAccountDescription = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APDetailComment() As String
			Get
				APDetailComment = _APDetailComment
			End Get
			Set(ByVal value As String)
				_APDetailComment = value
			End Set
		End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property ARInvoiceNumberDirect() As Nullable(Of Integer)
            Get
                ARInvoiceNumberDirect = _ARInvoiceNumberDirect
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _ARInvoiceNumberDirect = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARInvoiceDateDirect() As Nullable(Of Date)
            Get
                ARInvoiceDateDirect = _ARInvoiceDateDirect
            End Get
            Set(ByVal value As Nullable(Of Date))
                _ARInvoiceDateDirect = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Billed() As Boolean
			Get
				Billed = _Billed
			End Get
			Set(ByVal value As Boolean)
				_Billed = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property DetailAmount() As Nullable(Of Decimal)
			Get
				DetailAmount = _DetailAmount
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_DetailAmount = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property VendorTax() As Nullable(Of Decimal)
			Get
				VendorTax = _VendorTax
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_VendorTax = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
		Public Property TotalAmount() As Nullable(Of Decimal)
			Get
				TotalAmount = _TotalAmount
			End Get
			Set(ByVal value As Nullable(Of Decimal))
				_TotalAmount = value
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
		<System.Runtime.Serialization.DataMemberAttribute(),
		AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
		Public Property BankCode() As String
			Get
				BankCode = _BankCode
			End Get
			Set(ByVal value As String)
				_BankCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False)>
		Public Property BankDescription() As String
			Get
				BankDescription = _BankDescription
			End Get
			Set(ByVal value As String)
				_BankDescription = value
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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
		Public Property CampaignID() As Nullable(Of Integer)
			Get
				CampaignID = _CampaignID
			End Get
			Set(ByVal value As Nullable(Of Integer))
				_CampaignID = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
		Public Property CampaignCode() As String
			Get
				CampaignCode = _CampaignCode
			End Get
			Set(ByVal value As String)
				_CampaignCode = value
			End Set
		End Property
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
		Public Property CampaignDescription() As String
			Get
				CampaignDescription = _CampaignDescription
			End Get
			Set(ByVal value As String)
				_CampaignDescription = value
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ApprovalStatus() As String
            Get
                ApprovalStatus = _ApprovalStatus
            End Get
            Set(ByVal value As String)
                _ApprovalStatus = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property NonBillable() As String
            Get
                NonBillable = _NonBillable
            End Get
            Set(ByVal value As String)
                _NonBillable = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DetailPostingPeriod() As String
            Get
                DetailPostingPeriod = _DetailPostingPeriod
            End Get
            Set(ByVal value As String)
                _DetailPostingPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ARInvoiceAmount() As Nullable(Of Decimal)
            Get
                ARInvoiceAmount = _ARInvoiceAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ARInvoiceAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CashReceivedAmount() As Nullable(Of Decimal)
            Get
                CashReceivedAmount = _CashReceivedAmount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CashReceivedAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PartialPaymentIndicator() As String
            Get
                PartialPaymentIndicator = _PartialPaymentIndicator
            End Get
            Set(ByVal value As String)
                _PartialPaymentIndicator = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property CashReceivedAmtByOrderLine() As Nullable(Of Decimal)
            Get
                CashReceivedAmtByOrderLine = _CashReceivedAmtByOrderLine
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _CashReceivedAmtByOrderLine = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledNetAmountByOrderLine() As Nullable(Of Decimal)
            Get
                BilledNetAmountByOrderLine = _BilledNetAmountByOrderLine
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledNetAmountByOrderLine = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property BilledGrossAmountByOrderLine() As Nullable(Of Decimal)
            Get
                BilledGrossAmountByOrderLine = _BilledGrossAmountByOrderLine
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _BilledGrossAmountByOrderLine = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property UnbilledAmountByOrderLine() As Nullable(Of Decimal)
            Get
                UnbilledAmountByOrderLine = _UnbilledAmountByOrderLine
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _UnbilledAmountByOrderLine = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DetailModifiedBy() As String
            Get
                DetailModifiedBy = _DetailModifiedBy
            End Get
            Set(ByVal value As String)
                _DetailModifiedBy = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DetailModifiedDate() As Nullable(Of Date)
            Get
                DetailModifiedDate = _DetailModifiedDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _DetailModifiedDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
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
