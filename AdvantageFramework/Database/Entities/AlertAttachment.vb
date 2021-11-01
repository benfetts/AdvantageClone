Namespace Database.Entities

	<Table("ALERT_ATTACHMENT")>
	Public Class AlertAttachment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			AlertID
			UserCode
			GeneratedDate
			HasEmailBeenSent
			DocumentID
			ClientContactID
			Alert

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("ATTACHMENT_ID")>
		Public Property ID() As Integer
		<Required>
		<Column("ALERT_ID")>
		Public Property AlertID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("USER_CODE", TypeName:="varchar")>
		Public Property UserCode() As String
		<Required>
		<Column("GENERATED_DATE")>
		Public Property GeneratedDate() As Date
		<Required>
		<Column("EMAILSENT")>
		Public Property HasEmailBeenSent() As Boolean
		<Required>
		<Column("DOCUMENT_ID")>
		Public Property DocumentID() As Integer
		<Column("USER_CODE_CP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientContactID() As Nullable(Of Integer)
        <Column("THUMBNAIL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Thumbnail() As Byte()

        Public Overridable Property Alert As Database.Entities.Alert

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
