Namespace Database.Entities

	<Table("ORDER_STATUS")>
	Public Class OrderStatus
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
			ID
			Description
			IsInactive
			InternetOrderStatuses
			MagazineOrderStatuses
			NewspaperOrderStatuses
			OutOfHomeOrderStatuses
			RadioOrderStatuses
			TVOrderStatuses

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("STATUS")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ID() As Short
		<Required>
		<MaxLength(100)>
		<Column("STATUS_DESC", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<Column("INACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsInactive() As Short


#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

	End Class

End Namespace
