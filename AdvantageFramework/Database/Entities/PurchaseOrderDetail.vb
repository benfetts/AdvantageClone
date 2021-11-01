Namespace Database.Entities

	<Table("PURCHASE_ORDER_DET")>
	Public Class PurchaseOrderDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			PurchaseOrderNumber
			LineNumber
			Description
			LineDescription
			Instructions
			Quantity
			Rate
			ExtendedAmount
			TaxPercent
			IsComplete
			JobNumber
			JobComponentNumber
			FunctionCode
			CommissionPercent
			ExtendedMarkupAmount
			GLACode
			BillingApprovalID
			[Function]
			GeneralLedgerAccount
			JobComponent
			PurchaseOrder
			Job

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("PO_NUMBER", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property PurchaseOrderNumber() As Integer
		<Key>
		<Required>
        <Column("LINE_NUMBER", Order:=1)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineNumber() As Integer
		<Column("DET_DESC")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<MaxLength(40)>
		<Column("LINE_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property LineDescription() As String
		<Column("DET_INSTRUCT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Instructions() As String
		<Column("PO_QTY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Quantity() As Nullable(Of Integer)
        <Column("PO_RATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(17, 4)>
        Public Property Rate() As Nullable(Of Decimal)
        <Column("PO_EXT_AMOUNT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        Public Property ExtendedAmount() As Nullable(Of Decimal)
		<Column("PO_TAX_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(8, 4)>
        Public Property TaxPercent() As Nullable(Of Decimal)
		<Column("PO_COMPLETE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsComplete() As Nullable(Of Short)
		<Column("JOB_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobNumber() As Nullable(Of Integer)
		<Column("JOB_COMPONENT_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property JobComponentNumber() As Nullable(Of Short)
		<MaxLength(6)>
		<Column("FNC_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FunctionCode() As String
		<Column("PO_COMM_PCT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(9, 3)>
        Public Property CommissionPercent() As Nullable(Of Decimal)
		<Column("EXT_MARKUP_AMT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        Public Property ExtendedMarkupAmount() As Nullable(Of Decimal)
		<MaxLength(30)>
		<Column("GLACODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACode() As String
		<Column("BA_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingApprovalID() As Nullable(Of Integer)

        Public Overridable Property [Function] As Database.Entities.Function
        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("JobNumber, JobComponentNumber")>
        Public Overridable Property JobComponent As Database.Entities.JobComponent
        Public Overridable Property PurchaseOrder As Database.Entities.PurchaseOrder
        Public Overridable Property Job As Database.Entities.Job

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.PurchaseOrderNumber.ToString

        End Function

#End Region

	End Class

End Namespace
