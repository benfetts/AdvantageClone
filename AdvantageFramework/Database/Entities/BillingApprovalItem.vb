Namespace Database.Entities

	<Table("BILL_APPR_ITEM")>
	Public Class BillingApprovalItem
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			BillingApprovalDetailID
			RecType
			RecID
			ApprovedAmount
			ItemComment
			InstrFlag
			ClientComment
			RecDetailID
			BillingApprovalDetail

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("BA_ITEM_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("BA_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property BillingApprovalDetailID() As Integer
		<Required>
		<MaxLength(1)>
		<Column("REC_TYPE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RecType() As String
		<Column("REC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RecID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(15, 2)>
        <Column("APPROVED_AMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ApprovedAmount() As Nullable(Of Decimal)
		<Column("ITEM_COMMENTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ItemComment() As String
		<Required>
		<Column("INSTR")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property InstrFlag() As Byte
		<Column("CLIENT_COMMENTS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ClientComment() As String
		<Column("REC_DTL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RecDetailID() As Nullable(Of Integer)


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
