Namespace Database.Entities

	<Table("DOCUMENT_COMMENT")>
	Public Class DocumentComment
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			DocumentID
			UserCode
			CreatedDate
			ModifiedDate
			Comment
			PageNumber
			EmployeeCode
			XPosition
			YPosition
			FontSize
			FontFamily
			FontColor
			UserCodeCP
			Document

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("DOCUMENT_COMMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("DOCUMENT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DocumentID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("USER_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<Required>
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Date
		<Required>
		<Column("COMMENT", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Comment() As String
		<Required>
		<Column("PAGE_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PageNumber() As Integer
		<Required>
		<MaxLength(6)>
		<Column("EMP_CODE", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property EmployeeCode() As String
		<Column("X_POSITION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property XPosition() As Nullable(Of Integer)
		<Column("Y_POSITION")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property YPosition() As Nullable(Of Integer)
		<Column("FONT_SIZE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FontSize() As Nullable(Of Integer)
		<MaxLength(50)>
		<Column("FONT_FAMILY", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FontFamily() As String
		<MaxLength(50)>
		<Column("FONT_COLOR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FontColor() As String
		<Column("USER_CODE_CP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property UserCodeCP() As Nullable(Of Integer)

        Public Overridable Property Document As Database.Entities.Document

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
