Namespace Database.Entities

	<Table("GRID_COLUMN")>
	Public Class DataGridViewColumn
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			DataGridViewID
			Name
			IsEditable
			DataGridView
			DataGridViewColumnUserSettings

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("GRID_COLUMN_ID")>
		Public Property ID() As Integer
		<Required>
		<Column("GRID_ID")>
		Public Property DataGridViewID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("NAME", TypeName:="varchar")>
		Public Property Name() As String
		<Required>
		<Column("IS_EDITABLE")>
		Public Property IsEditable() As Boolean

        Public Overridable Property DataGridView As Database.Entities.DataGridView
        Public Overridable Property DataGridViewColumnUserSettings As ICollection(Of Database.Entities.DataGridViewColumnUserSetting)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
