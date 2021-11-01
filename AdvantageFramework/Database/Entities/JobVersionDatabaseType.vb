Namespace Database.Entities

	<Table("JOB_VER_DTYPE")>
	Public Class JobVersionDatabaseType
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Description
			DatabaseTypeID
			Precision
			Scale
			Column
			IsList
			JobVersionTemplateDetails

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("JV_DTYPE_ID")>
		Public Property ID() As Integer
		<MaxLength(50)>
		<Column("JV_DTYPE_DESC", TypeName:="varchar")>
		Public Property Description() As String
		<Required>
		<Column("ADVAN_DTYPE_ID")>
		Public Property DatabaseTypeID() As Short
		<Column("JV_DTYPE_PREC")>
		Public Property Precision() As Nullable(Of Short)
		<Column("JV_DTYPE_SCALE")>
		Public Property Scale() As Nullable(Of Short)
		<MaxLength(50)>
		<Column("JV_DTYPE_DW_COL", TypeName:="varchar")>
		Public Property Column() As String
		<Column("VALUE_LIST_FLAG")>
		Public Property IsList() As Nullable(Of Short)

        Public Overridable Property JobVersionTemplateDetails As ICollection(Of Database.Entities.JobVersionTemplateDetail)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
