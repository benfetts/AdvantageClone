Namespace Database.Entities

	<Table("AP_PMT_HIST")>
	Public Class AccountPayablePayment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AccountPayableID
			AccountPayableSequenceNumber
			BankCode
			CheckNumber
			CheckSequenceNumber
			CheckDate
			CheckAmount
			IsOnHold
			CheckMailedDate
			HasCheckCleared
			PostPeriodCode
			CreatedDate
			UserCode
			GLACodeCash
			GLACodeAP
			GLTransaction
			GLESeqCash
			GLESeqAP
			AccountsPayableDiscountGLACode
			DiscountAmount
			GeneralLedgerAccount
			CashGeneralLedgerAccount
			AccountPayableDiscountGeneralLedgerAccount
			AccountPayable
			Bank
            CheckRegister
            ExchangeAmountApplied
            GLACodeCurrency
            ExchangeAmount
            HomeCurrencyCode
            BankCurrencyCode
            APCurrencyCode

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("AP_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountPayableID() As Integer

        <Required>
        <Column("AP_SEQ")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountPayableSequenceNumber() As Short

        <Key>
		<Required>
		<MaxLength(4)>
        <Column("BK_CODE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankCode() As String

        <Key>
		<Required>
        <Column("AP_CHK_NBR", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckNumber() As Integer

        <Key>
		<Required>
        <Column("CHK_SEQ", Order:=3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckSequenceNumber() As Short

        <Required>
		<Column("AP_CHK_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckDate() As Date

        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("AP_CHK_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckAmount() As Nullable(Of Decimal)

        <Column("AP_CHK_HOLD_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsOnHold() As Nullable(Of Short)

        <Column("AP_CHK_MAILED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckMailedDate() As Nullable(Of Date)

        <Column("AP_CHK_CLEAR_FLAG")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HasCheckCleared() As Nullable(Of Short)

        <Required>
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriodCode() As String

        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate() As Nullable(Of Date)

        <MaxLength(100)>
		<Column("USERID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UserCode() As String

        <Required>
		<MaxLength(30)>
		<Column("GLACODE_CASH", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeCash() As String

        <Required>
		<MaxLength(30)>
		<Column("GLACODE_AP", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeAP() As String

        <Required>
		<Column("GLEXACT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLTransaction() As Integer

        <Required>
		<Column("GLESEQ_CASH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLESeqCash() As Short

        <Required>
		<Column("GLESEQ_AP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLESeqAP() As Short

        <MaxLength(30)>
		<Column("GLACODE_DISC", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AccountsPayableDiscountGLACode() As String

        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(11, 2)>
        <Column("AP_DISC_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DiscountAmount() As Nullable(Of Decimal)

        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXCHANGE_AMOUNT_APPLIED")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExchangeAmountApplied() As Nullable(Of Decimal)

        <MaxLength(30)>
        <Column("GLACODE_CRNCY_UNREALIZED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACodeCurrency() As String

        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("EXCHANGE_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ExchangeAmount() As Nullable(Of Decimal)

        <MaxLength(5)>
        <Column("HOME_CURRENCY_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property HomeCurrencyCode() As String

        <MaxLength(5)>
        <Column("BANK_CURRENCY_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankCurrencyCode() As String

        <MaxLength(5)>
        <Column("AP_CURRENCY_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property APCurrencyCode() As String

        <ForeignKey("GLACodeAP")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("GLACodeCash")>
        Public Overridable Property CashGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("AccountsPayableDiscountGLACode")>
        Public Overridable Property AccountPayableDiscountGeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property AccountPayable As Database.Entities.AccountPayable
        Public Overridable Property Bank As Database.Entities.Bank
        Public Overridable Property CheckRegister As Database.Entities.CheckRegister

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AccountPayableID

        End Function

#End Region

	End Class

End Namespace
