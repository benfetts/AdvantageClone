Namespace Database.Entities

	<Table("CR_CLIENT_DTL")>
	Public Class ClientCashReceiptDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ClientCashReceiptID
			ClientCashReceiptSequenceNumber
			ItemID
			DivisionCode
			ProductCode
			ARInvoiceNumber
			ARInvoiceSequenceNumber
			ARType
			PaymentAmount
			AdjustmentAmount
			GLACodeAR
			GLACodeAdjustment
			GLTransaction
			GLSequenceNumberAR
			GLSequenceNumberAdjustment
			PostPeriodCode
			GLACodeDueFrom
			GLACodeDueTo
			GLSequenceNumberDueFrom
			GLSequenceNumberDueTo
			GLACodeDueFromAdjustment
			GLACodeDueToAdjustment
			GLSequenceNumberDueFromAdjustment
			GLSequenceNumberDueToAdjustment
			ModifyDelete
			AccountReceivable
			ClientCashReceipt
			GeneralLedgerAccountAdjustment
			GeneralLedgerAccountAR

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("REC_ID", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCashReceiptID() As Integer
		<Key>
		<Required>
        <Column("SEQ_NBR", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCashReceiptSequenceNumber() As Short
		<Key>
		<Required>
        <Column("REC_ITEM_ID", Order:=2)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ItemID() As Short
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<Column("AR_INV_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARInvoiceNumber() As Nullable(Of Integer)
		<Column("AR_INV_SEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARInvoiceSequenceNumber() As Nullable(Of Short)
		<MaxLength(3)>
		<Column("AR_TYPE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ARType() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("CR_PAY_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PaymentAmount() As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("CR_ADJ_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AdjustmentAmount() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("GLACODE_AR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeAR() As String
		<MaxLength(30)>
		<Column("GLACODE_ADJ", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeAdjustment() As String
		<Column("GLEXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Nullable(Of Integer)
		<Column("GLESEQ_AR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberAR() As Nullable(Of Short)
		<Column("GLESEQ_ADJ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberAdjustment() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
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
		<MaxLength(30)>
		<Column("GLACODE_DUE_FROM_ADJ", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeDueFromAdjustment() As String
		<MaxLength(30)>
		<Column("GLACODE_DUE_TO_ADJ", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeDueToAdjustment() As String
		<Column("GLESEQ_DUE_FROM_ADJ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberDueFromAdjustment() As Nullable(Of Short)
		<Column("GLESEQ_DUE_TO_ADJ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumberDueToAdjustment() As Nullable(Of Short)
		<Column("MODIFY_DELETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifyDelete() As Nullable(Of Boolean)

        <ForeignKey("ARInvoiceNumber, ARInvoiceSequenceNumber, ARType")>
        Public Overridable Property AccountReceivable As Database.Entities.AccountReceivable
        Public Overridable Property ClientCashReceipt As Database.Entities.ClientCashReceipt
        <ForeignKey("GLACodeAdjustment")>
        Public Overridable Property GeneralLedgerAccountAdjustment As Database.Entities.GeneralLedgerAccount
        <ForeignKey("GLACodeAR")>
        Public Overridable Property GeneralLedgerAccountAR As Database.Entities.GeneralLedgerAccount

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCashReceiptID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.ClientCashReceiptDetail

            Dim EntityCopy As AdvantageFramework.Database.Entities.ClientCashReceiptDetail = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.ClientCashReceiptDetail

            With EntityCopy
                .ClientCashReceiptID = Me.ClientCashReceiptID
                .ClientCashReceiptSequenceNumber = Me.ClientCashReceiptSequenceNumber
                .ItemID = Me.ItemID
                .DivisionCode = Me.DivisionCode
                .ProductCode = Me.ProductCode
                .ARInvoiceNumber = Me.ARInvoiceNumber
                .ARInvoiceSequenceNumber = Me.ARInvoiceSequenceNumber
                .ARType = Me.ARType
                .PaymentAmount = Me.PaymentAmount
                .AdjustmentAmount = Me.AdjustmentAmount
                .GLACodeAR = Me.GLACodeAR
                .GLACodeAdjustment = Me.GLACodeAdjustment
                .GLTransaction = Me.GLTransaction
                .GLSequenceNumberAR = Me.GLSequenceNumberAR
                .GLSequenceNumberAdjustment = Me.GLSequenceNumberAdjustment
            End With

            Copy = EntityCopy

        End Function

#End Region

	End Class

End Namespace
