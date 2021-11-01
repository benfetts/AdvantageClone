Namespace Database.Entities

	<Table("IMPORT_TEMPLATE")>
	Public Class ImportTemplate
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Type
			Name
			FileType
			CreatedBy
			CreatedDate
			ModifiedBy
			ModifiedDate
			IsSystemTemplate
			DefaultDirectory
			RecordSourceID
			ImportTemplateDetails
			RecordSource
			AdvantageServiceImports

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("TEMPLATE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Short
		<Required>
		<Column("TEMPLATE_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Type() As Short
		<Required>
		<MaxLength(100)>
		<Column("TEMPLATE_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<Required>
		<Column("FILE_TYPE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property FileType() As Short
		<MaxLength(100)>
		<Column("CREATE_USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedBy() As String
		<Column("CREATE_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property CreatedDate() As Nullable(Of Date)
		<MaxLength(100)>
		<Column("MOD_USER_ID", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedBy() As String
		<Column("MOD_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)
		<Required>
		<Column("SYSTEM_TEMPLATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsSystemTemplate() As Boolean
		<Column("DEFAULT_DIRECTORY", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DefaultDirectory() As String
		<Column("RECORD_SOURCE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property RecordSourceID() As Nullable(Of Integer)

        Public Overridable Property ImportTemplateDetails As ICollection(Of Database.Entities.ImportTemplateDetail)
        Public Overridable Property RecordSource As Database.Entities.RecordSource
        Public Overridable Property AdvantageServiceImports As ICollection(Of Database.Entities.AdvantageServiceImport)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.Database.Entities.ImportTemplate.Properties.Name.ToString

                    If Me.IsEntityBeingAdded() Then

                        PropertyValue = Value

						If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ImportTemplates
							Where Entity.Type = Me.Type AndAlso
								  Entity.Name.ToUpper = DirectCast(PropertyValue, String).ToUpper
							Select Entity).Any Then

							IsValid = False

							ErrorText = "Please enter a unique template name."

						End If

						If Value <> AdvantageFramework.StringUtilities.RemoveAllNonAlphaNumeric(PropertyValue) Then

                            IsValid = False

                            ErrorText = "Specials characters are not allowed."

                        End If

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

	End Class

End Namespace
