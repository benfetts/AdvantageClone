Namespace Database.Entities

	<Table("CR_OTHER_DTL")>
	Public Class OtherCashReceiptDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			OtherCashReceiptID
			OtherCashReceiptSequenceNumber
			GLACode
			Amount
			GLTransaction
			GLSequenceNumber
			PostPeriodCode
			ItemID
			GLACodeDueFrom
			GLACodeDueTo
			GLSequenceNumberDueFrom
			GLSequenceNumberDueTo
			Comment
			ModifyDelete
			OtherCashReceipt
			GeneralLedgerAccount

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("REC_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OtherCashReceiptID() As Integer
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OtherCashReceiptSequenceNumber() As Short
		<Required>
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property GLACode() As String
		<Column("CR_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(14, 2)>
        Public Property Amount() As Nullable(Of Decimal)
		<Required>
		<Column("GLEXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Integer
		<Required>
		<Column("GLESEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumber() As Short
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<Key>
		<Required>
        <Column("REC_ITEM_ID", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ItemID() As Short
		<MaxLength(30)>
		<Column("GLACODE_DUE_FROM", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeDueFrom() As String
		<MaxLength(30)>
		<Column("GLACODE_DUE_TO", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeDueTo() As String
		<Column("GLESEQ_DUE_FROM")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberDueFrom() As Nullable(Of Short)
		<Column("GLESEQ_DUE_TO")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberDueTo() As Nullable(Of Short)
		<MaxLength(40)>
		<Column("COMMENT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String
		<Required>
		<Column("MODIFY_DELETE")>
		Public Property ModifyDelete() As Boolean

        Public Overridable Property OtherCashReceipt As Database.Entities.OtherCashReceipt
        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.OtherCashReceiptID.ToString

        End Function

#End Region

	End Class

End Namespace
