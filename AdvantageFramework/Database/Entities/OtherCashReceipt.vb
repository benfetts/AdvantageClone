Namespace Database.Entities

	<Table("CR_OTHER")>
	Public Class OtherCashReceipt
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			SequenceNumber
			CheckNumber
			CheckDate
			CheckAmount
			DepositDate
			Description
			PostPeriodCode
			OfficeCode
			BankCode
			GLACode
			GLTransaction
			GLSequenceNumber
			Status
			IsCleared
			ReconcileStatementDate
			IsReconciled
			CashReceiptPaymentTypeID
			Bank
			OtherCashReceiptDetails
			GeneralLedgerAccount
			Office
			PostPeriod

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("REC_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SequenceNumber() As Short
		<Required>
		<MaxLength(15)>
		<Column("CR_CHECK_NBR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CheckNumber() As String
		<Required>
		<Column("CR_CHECK_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CheckDate() As Date
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<Column("CR_CHECK_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CheckAmount() As Decimal
		<Column("CR_DEP_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property DepositDate() As Nullable(Of Date)
		<MaxLength(40)>
		<Column("CR_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<Required>
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property OfficeCode() As String
		<Required>
		<MaxLength(4)>
		<Column("BK_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property BankCode() As String
		<Required>
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property GLACode() As String
		<Required>
		<Column("GLEXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property GLTransaction() As Integer
		<Required>
		<Column("GLESEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property GLSequenceNumber() As Short
		<MaxLength(1)>
		<Column("STATUS", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Status() As String
		<Column("CLEARED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsCleared() As Nullable(Of Short)
		<Column("REC_STMT_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ReconcileStatementDate() As Nullable(Of Date)
		<Column("RECON_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsReconciled() As Nullable(Of Short)
		<Column("CR_PAYMENT_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CashReceiptPaymentTypeID() As Nullable(Of Integer)

        Public Overridable Property Bank As Database.Entities.Bank
        Public Overridable Property OtherCashReceiptDetails As ICollection(Of Database.Entities.OtherCashReceiptDetail)
        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        Public Overridable Property Office As Database.Entities.Office
        Public Overridable Property PostPeriod As Database.Entities.PostPeriod

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
