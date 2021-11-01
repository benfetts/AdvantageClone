Namespace Database.Entities

	<Table("AP_HEADER")>
	Public Class AccountPayable
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            Type
            VendorCode
            InvoiceNumber
            InvoiceDescription
            InvoiceDate
            PaidDate
            InvoiceAmount
            ShippingAmount
            SalesTaxAmount
            DiscountPercentage
            CheckWriting
            CheckWritingUserCode
            IsOnHold
            GLACode
            IsCheckOnHold
            PostPeriodCode
            VendorTermCode
            GLTransaction
            GLSequenceNumber
            Deleted
            DeletedDate
            DeletedByUserCode
            Modified
            ModifiedDate
            ModifiedByUserCode
            IsArchived
            Voucher
            OfficeCode
            Is1099Invoice
            CBRBFlag
            RBFlag
            MFSent
            RBAPID
            CreatedByUserCode
            CreatedDate
            CurrencyCode
            CurrencyRate
            APGLACodeXChange
            BatchName
            VendorServiceTaxID
            VendorServiceTaxEnabled
            VendorTaxableAmount
            ExchangeAmount
            ForeignInvoiceAmount
            ForeignSalesTaxAmount
            QuickbooksBillID
            QuickbooksCreateDate
            QuickbooksCreateByUserCode

            Vendor
            GeneralLedgerAccount
            PostPeriod
            VendorTerm
            AccountPayablePayments
            AccountPayableRadios
            AccountPayableTVs
            Currency
            AccountPayableProduction
            GeneralLedger
            AccountPayableGLDistributions
            AccountPayableInternets
            AccountPayableMagazines
            AccountPayableOutOfHomes
            AccountPayableNewspapers
            Office
        End Enum

#End Region

#Region " Variables "

        Private _DoNotApplyCurrencyRequirement As Boolean = False

#End Region

#Region " Properties "

        <Key>
		<Required>
        <Column("AP_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Key>
		<Required>
        <Column("AP_SEQ", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property SequenceNumber() As Short
		<Required>
		<MaxLength(1)>
		<Column("AP_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Type() As String
		<Required>
		<MaxLength(6)>
		<Column("VN_FRL_EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorCode)>
		Public Property VendorCode() As String
		<Required>
		<MaxLength(20)>
		<Column("AP_INV_VCHR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property InvoiceNumber() As String
		<MaxLength(30)>
		<Column("AP_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InvoiceDescription() As String
		<Required>
		<Column("AP_INV_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property InvoiceDate() As Date
		<Required>
		<Column("AP_DATE_PAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property PaidDate() As Date
		<Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AP_INV_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public Property InvoiceAmount() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("AP_SHIPPING")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ShippingAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("AP_SALES_TAX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property SalesTaxAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(6, 3)>
        <Column("AP_DISC_PCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3")>
		Public Property DiscountPercentage() As Nullable(Of Decimal)
		<Column("AP_CKWRITING")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckWriting() As Nullable(Of Short)
		<MaxLength(100)>
		<Column("CHKWRITING_USER", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CheckWritingUserCode() As String
		<Column("PAYMENT_HOLD")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsOnHold() As Nullable(Of Short)
		<Required>
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
		Public Property GLACode() As String
		<Column("CHECK_HOLD_CODE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsCheckOnHold() As Nullable(Of Short)
		<Required>
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.PostPeriodCode)>
		Public Property PostPeriodCode() As String
		<MaxLength(3)>
		<Column("VT_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.VendorTermCode)>
		Public Property VendorTermCode() As String
        <Column("GLEXACT")>
        <ForeignKey("GeneralLedger")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Nullable(Of Integer)
		<Column("GLESEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumber() As Nullable(Of Short)
		<Column("DELETE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Deleted() As Nullable(Of Short)
		<Column("DELETE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeletedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("DELETED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DeletedByUserCode() As String
		<Column("MODIFY_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Modified() As Nullable(Of Short)
		<Column("MODIFY_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("MODIFIED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("ARCHIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsArchived() As Nullable(Of Short)
		<Column("VOUCHER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Voucher() As Nullable(Of Integer)
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Office", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.OfficeCode)>
		Public Property OfficeCode() As String
		<Column("FLAG_1099")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Is1099Invoice() As Nullable(Of Short)
		<Column("CB_RB_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CBRBFlag() As Nullable(Of Short)
		<Column("RB_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RBFlag() As Nullable(Of Short)
		<Column("MF_SENT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property MFSent() As Nullable(Of Short)
		<Column("RB_AP_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RBAPID() As Nullable(Of Integer)
		<MaxLength(100)>
		<Column("CREATED_BY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Nullable(Of Date)
		<MaxLength(5)>
		<Column("CURRENCY_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.CurrencyCode)>
        Public Property CurrencyCode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(12, 6)>
        <Column("CURRENCY_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n6", UseMinValue:=True, MinValue:=0.000001)>
        Public Property CurrencyRate() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("AP_GLACODE_XCHG", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property APGLACodeXChange() As String
		<MaxLength(50)>
		<Column("BATCH_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BatchName() As String
		<Column("VENDOR_SERVICE_TAX_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property VendorServiceTaxID() As Nullable(Of Integer)
		<Column("SERVICE_TAX_ENABLED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VendorServiceTaxEnabled() As Nullable(Of Boolean)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("VENDOR_TAXABLE_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="VST Amount")>
        Public Property VendorTaxableAmount() As Nullable(Of Decimal)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXCHANGE_AMOUNT")>
		Public Property ExchangeAmount() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("FOREIGN_INV_AMOUNT")>
        Public Property ForeignInvoiceAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("FOREIGN_SALES_TAX")>
        Public Property ForeignSalesTaxAmount() As Nullable(Of Decimal)
        <MaxLength(21)>
        <Column("QUICKBOOKS_BILL_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuickbooksBillID() As String
        <Column("QB_CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuickbooksCreateDate() As Nullable(Of Date)
        <MaxLength(100)>
        <Column("QB_CREATE_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property QuickbooksCreateByUserCode() As String

        <NotMapped>
        Public Property DoNotApplyCurrencyRequirement() As Boolean
            Get
                DoNotApplyCurrencyRequirement = _DoNotApplyCurrencyRequirement
            End Get
            Set(value As Boolean)
                _DoNotApplyCurrencyRequirement = value
            End Set
        End Property

        Public Overridable Property Vendor As Database.Entities.Vendor
        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property PostPeriod As Database.Entities.PostPeriod
        Public Overridable Property VendorTerm As Database.Entities.VendorTerm
        Public Overridable Property AccountPayablePayments As ICollection(Of Database.Entities.AccountPayablePayment)
        Public Overridable Property AccountPayableRadios As ICollection(Of Database.Entities.AccountPayableRadio)
        Public Overridable Property AccountPayableTVs As ICollection(Of Database.Entities.AccountPayableTV)
        Public Overridable Property Currency As Database.Entities.Currency
        Public Overridable Property AccountPayableProduction As ICollection(Of Database.Entities.AccountPayableProduction)
        Public Overridable Property GeneralLedger As Database.Entities.GeneralLedger
        Public Overridable Property AccountPayableGLDistributions As ICollection(Of Database.Entities.AccountPayableGLDistribution)
        Public Overridable Property AccountPayableInternets As ICollection(Of Database.Entities.AccountPayableInternet)
        Public Overridable Property AccountPayableMagazines As ICollection(Of Database.Entities.AccountPayableMagazine)
        Public Overridable Property AccountPayableOutOfHomes As ICollection(Of Database.Entities.AccountPayableOutOfHome)
        Public Overridable Property AccountPayableNewspapers As ICollection(Of Database.Entities.AccountPayableNewspaper)
        Public Overridable Property Office As Database.Entities.Office

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            SetRequiredFields()

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function
        Public Overrides Sub SetRequiredFields()

            Dim IsMultiCurrencyEnabled As Boolean = False

            SetRequired(AdvantageFramework.Database.Entities.AccountPayable.Properties.VendorServiceTaxID.ToString, Me.VendorServiceTaxEnabled.GetValueOrDefault(False))

            SetRequired(AdvantageFramework.Database.Entities.AccountPayable.Properties.VendorTaxableAmount.ToString, Me.VendorServiceTaxEnabled.GetValueOrDefault(False))

            IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

            SetRequired(AdvantageFramework.Database.Entities.AccountPayable.Properties.CurrencyRate.ToString, IsMultiCurrencyEnabled AndAlso Not _DoNotApplyCurrencyRequirement)
            SetRequired(AdvantageFramework.Database.Entities.AccountPayable.Properties.CurrencyCode.ToString, IsMultiCurrencyEnabled AndAlso Not _DoNotApplyCurrencyRequirement)

        End Sub
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.AccountPayable.Properties.VendorTaxableAmount.ToString

                    PropertyValue = Value

                    If Me.VendorServiceTaxEnabled.GetValueOrDefault(False) Then

                        Select Case Math.Sign(Me.InvoiceAmount + Me.SalesTaxAmount.GetValueOrDefault(0))

                            Case -1

                                If PropertyValue IsNot Nothing AndAlso (PropertyValue > 0 OrElse PropertyValue < (Me.InvoiceAmount + Me.SalesTaxAmount.GetValueOrDefault(0))) Then

                                    IsValid = False

                                    ErrorText = "VST amount must be between " & Me.InvoiceAmount + Me.SalesTaxAmount.GetValueOrDefault(0) & " and 0."

                                End If

                            Case 0

                                If PropertyValue IsNot Nothing AndAlso PropertyValue <> 0 Then

                                    IsValid = False

                                    ErrorText = "VST amount must be 0."

                                End If

                            Case 1

                                If PropertyValue IsNot Nothing AndAlso (PropertyValue < 0 OrElse PropertyValue > (Me.InvoiceAmount + Me.SalesTaxAmount.GetValueOrDefault(0))) Then

                                    IsValid = False

                                    ErrorText = "VST amount must be between 0 and " & Me.InvoiceAmount + Me.SalesTaxAmount.GetValueOrDefault(0) & "."

                                End If

                        End Select

                    End If

                Case AdvantageFramework.Database.Entities.AccountPayable.Properties.CurrencyRate.ToString

                    PropertyValue = Value

                    If Not _DoNotApplyCurrencyRequirement AndAlso AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                        If PropertyValue Is Nothing OrElse PropertyValue <= 0 Then

                            IsValid = False

                            ErrorText = "Currency rate must be greater than zero."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
