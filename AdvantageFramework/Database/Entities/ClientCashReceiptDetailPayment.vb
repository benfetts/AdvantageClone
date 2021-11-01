Namespace Database.Entities

	<Table("CR_CLIENT_DTL_PAYMENT")>
	Public Class ClientCashReceiptDetailPayment
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			ClientCashReceiptID
			ClientCashReceiptSequenceNumber
			ClientCashReceiptDetailItemID
			JobNumber
			JobComponentNumber
			FunctionCode
			OrderNumber
			OrderLineNumber
			PaymentAmount

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("CR_CLIENT_DTL_PAYMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("REC_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ClientCashReceiptID() As Integer
		<Required>
		<Column("SEQ_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ClientCashReceiptSequenceNumber() As Short
		<Required>
		<Column("REC_ITEM_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ClientCashReceiptDetailItemID() As Short
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
		<Column("ORDER_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderNumber() As Nullable(Of Integer)
		<Column("ORDER_LINE_NBR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OrderLineNumber() As Nullable(Of Short)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("PAYMENT_AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property PaymentAmount() As Decimal


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Function Copy() As AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment

            Dim EntityCopy As AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment = Nothing

            EntityCopy = New AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment

            With EntityCopy
                .ID = Me.ID
                .ClientCashReceiptID = Me.ClientCashReceiptID
                .ClientCashReceiptSequenceNumber = Me.ClientCashReceiptSequenceNumber
                .ClientCashReceiptDetailItemID = Me.ClientCashReceiptDetailItemID
                .JobNumber = Me.JobNumber
                .JobComponentNumber = Me.JobComponentNumber
                .FunctionCode = Me.FunctionCode
                .OrderNumber = Me.OrderNumber
                .OrderLineNumber = Me.OrderLineNumber
                .PaymentAmount = Me.PaymentAmount
            End With

            Copy = EntityCopy

        End Function

#End Region

    End Class

End Namespace
