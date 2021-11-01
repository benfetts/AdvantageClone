Namespace Database.Entities

	<Table("CR_ON_ACCT")>
	Public Class ClientCashReceiptOnAccount
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ClientCashReceiptID
			ClientCashReceiptSequenceNumber
			ItemID
			ClientCode
			DivisionCode
			ProductCode
			CampaignCode
			Amount
			GLACodeOnAccount
			GLTransaction
			GLSequenceNumber
			Distributed
			PostPeriodCode
			OfficeCode
			GLACodeDueFrom
			GLACodeDueTo
			GLSequenceNumberDueFrom
			GLSequenceNumberDueTo
			Comment
			ClientCashReceipt
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
		<Column("CL_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientCode() As String
		<MaxLength(6)>
		<Column("DIV_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DivisionCode() As String
		<MaxLength(6)>
		<Column("PRD_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ProductCode() As String
		<MaxLength(6)>
		<Column("CMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CampaignCode() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
		<Column("CR_OA_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Amount() As Decimal
		<Required>
		<MaxLength(30)>
		<Column("GLACODE_OA", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACodeOnAccount() As String
		<Required>
		<Column("GLEXACT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Integer
		<Required>
		<Column("GLESEQ")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSequenceNumber() As Short
		<MaxLength(1)>
		<Column("CR_OA_DIST", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Distributed() As String
		<MaxLength(6)>
		<Column("POST_PERIOD", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PostPeriodCode() As String
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String
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
		<MaxLength(254)>
		<Column("OA_COMMENT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String

        Public Overridable Property ClientCashReceipt As Database.Entities.ClientCashReceipt

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCashReceiptID.ToString

        End Function

#End Region

	End Class

End Namespace
