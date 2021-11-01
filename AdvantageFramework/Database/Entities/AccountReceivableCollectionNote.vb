Namespace Database.Entities

	<Table("AR_COLL_NOTES")>
	Public Class AccountReceivableCollectionNote
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ARInvoiceNumber
			ARType
			ARInvoiceSequenceNumber
			Note

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("AR_INV_NBR", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARInvoiceNumber() As Integer
		<Key>
		<Required>
		<MaxLength(3)>
        <Column("AR_TYPE", Order:=1, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARType() As String
		<Key>
		<Required>
        <Column("AR_INV_SEQ", Order:=2)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ARInvoiceSequenceNumber() As Short
		<Column("COLLECT_NOTES")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Note() As String


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ARInvoiceNumber.ToString

        End Function

#End Region

	End Class

End Namespace
