Namespace Database.Entities

	<Table("GRID_COLUMN_SETTING")>
	Public Class DataGridViewColumnUserSetting
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			DataGridViewID
			DataGridViewColumnID
			UserCode
			IsVisible
			DataGridView
			DataGridViewColumn

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("GRIDCOLUMNSETTING_ID")>
		Public Property ID() As Integer
		<Required>
		<Column("GRID_ID")>
		Public Property DataGridViewID() As Integer
		<Required>
		<Column("GRID_COLUMN_ID")>
		Public Property DataGridViewColumnID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("USER_CODE", TypeName:="varchar")>
		Public Property UserCode() As String
		<Required>
		<Column("IS_VISIBLE")>
		Public Property IsVisible() As Boolean

        Public Overridable Property DataGridView As Database.Entities.DataGridView
        Public Overridable Property DataGridViewColumn As Database.Entities.DataGridViewColumn

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

	End Class

End Namespace
