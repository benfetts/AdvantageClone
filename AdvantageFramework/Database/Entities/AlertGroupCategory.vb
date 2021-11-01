Namespace Database.Entities

	<Table("ALERT_GROUP")>
	Public Class AlertGroupCategory
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			AlertGroupCode
			AlertCategoryID
			IsActive
			AlertCategory

		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<MaxLength(50)>
        <Column("E_GROUP", Order:=0, TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertGroupCode() As String
		<Key>
		<Required>
        <Column("ALERT_CAT_ID", Order:=1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property AlertCategoryID() As Integer
		<Column("ACTIVE_FLAG")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsActive() As Nullable(Of Short)

        Public Overridable Property AlertCategory As Database.Entities.AlertCategory

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.AlertGroupCode.ToString

        End Function

#End Region

	End Class

End Namespace
