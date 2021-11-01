Namespace Database.Entities

	<Table("IMP_AP_GL")>
	Public Class ImportAccountPayableGL
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ImportAccountPayableID
			GLACode
			GLNetAmount
			GLComment
			ID
			OfficeCodeDetail
			ImportAccountPayable
			ImportAccountPayableErrors

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<Column("IMPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportAccountPayableID() As Integer
		<MaxLength(30)>
		<Column("GL_ACCOUNT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLACode() As String
        <AdvantageFramework.BaseClasses.Attributes.DecimalPrecision(14, 2)>
        <Column("GL_NET")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLNetAmount() As Nullable(Of Decimal)
		<MaxLength(255)>
		<Column("GL_COMMENT", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property GLComment() As String
		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<MaxLength(4)>
		<Column("OFFICE_CODE_DTL", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCodeDetail() As String

        <ForeignKey("ImportAccountPayableID")>
        Public Overridable Property ImportAccountPayable As Database.Entities.ImportAccountPayable

        Public Overridable Property ImportAccountPayableErrors As ICollection(Of Database.Entities.ImportAccountPayableError)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ImportAccountPayableID.ToString

        End Function

#End Region

	End Class

End Namespace
