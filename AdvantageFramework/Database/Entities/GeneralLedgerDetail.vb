Namespace Database.Entities

	<Table("GLENTTRL")>
	Public Class GeneralLedgerDetail
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			GLTransaction
			SequenceNumber
			GLACode
			DebitAmount
			CreditAmount
			Remark
			GLSourceCode
			ClientCode
			DivisionCode
			ProductCode
			RowID
			GeneralLedgerAccount
			Product

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
        <Column("GLETXACT", Order:=0)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLTransaction() As Integer
		<Key>
		<Required>
        <Column("GLETSEQ", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property SequenceNumber() As Short
		<Required>
		<MaxLength(30)>
		<Column("GLETCODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLACode() As String
		<Required>
		<Column("GLETAMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DebitAmount() As Double
		<Required>
		<Column("GLETFCAMT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreditAmount() As Double
		<MaxLength(150)>
		<Column("GLETREM", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Remark() As String
		<MaxLength(2)>
		<Column("GLETSOURCE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLSourceCode() As String
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
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ROWID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RowID() As Integer

        <ForeignKey("GLACode")>
        Public Overridable Property GeneralLedgerAccount As Database.Entities.GeneralLedgerAccount
        <ForeignKey("ClientCode, DivisionCode, ProductCode")>
        Public Overridable Property Product As Database.Entities.Product

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GLTransaction.ToString

        End Function

#End Region

	End Class

End Namespace
