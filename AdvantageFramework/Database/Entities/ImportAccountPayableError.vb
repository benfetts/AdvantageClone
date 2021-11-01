Namespace Database.Entities

	<Table("IMP_AP_ERROR")>
	Public Class ImportAccountPayableError
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			ImportAccountPayableID
			PropertyName
			ErrorDescription
			ImportAccountPayableGLID
			ImportAccountPayableJobID
			ImportAccountPayableMediaID
			ImportAccountPayable
			ImportAccountPayableGL
			ImportAccountPayableJob
			ImportAccountPayableMedia

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("IMP_AP_ERROR_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("IMPORT_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportAccountPayableID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("PROPERTY_NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property PropertyName() As String
		<Required>
		<MaxLength(100)>
		<Column("ERROR", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ErrorDescription() As String
		<Column("IMPORT_GL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportAccountPayableGLID() As Nullable(Of Integer)
		<Column("IMPORT_JOB_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportAccountPayableJobID() As Nullable(Of Integer)
		<Column("IMPORT_MEDIA_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ImportAccountPayableMediaID() As Nullable(Of Integer)

        <ForeignKey("ImportAccountPayableID")>
        Public Overridable Property ImportAccountPayable As Database.Entities.ImportAccountPayable

        <ForeignKey("ImportAccountPayableGLID")>
        Public Overridable Property ImportAccountPayableGL As Database.Entities.ImportAccountPayableGL

        <ForeignKey("ImportAccountPayableJobID")>
        Public Overridable Property ImportAccountPayableJob As Database.Entities.ImportAccountPayableJob

        <ForeignKey("ImportAccountPayableMediaID")>
        Public Overridable Property ImportAccountPayableMedia As Database.Entities.ImportAccountPayableMedia

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
