Namespace Database.Entities

	<Table("OFFICE_DOCUMENTS")>
	Public Class OfficeDocument
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			DocumentID
			OfficeCode
			Document
			Office

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("DOCUMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DocumentID() As Integer
		<MaxLength(4)>
		<Column("OFFICE_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property OfficeCode() As String

        <ForeignKey("DocumentID")>
        Public Overridable Property Document As Database.Entities.Document
        Public Overridable Property Office As Database.Entities.Office

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.DocumentID

        End Function

#End Region

	End Class

End Namespace
