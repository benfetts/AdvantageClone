Namespace Database.Entities

	<Table("MEDIA_CALENDAR_TYPE")>
	Public Class MediaCalendarType
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Name
			Sunday
			Monday
			Tuesday
			Wednesday
			Thursday
			Friday
			Saturday
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("MEDIA_CALENDAR_TYPE_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(100)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String
		<Required>
		<Column("SUNDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Sunday() As Boolean
		<Required>
		<Column("MONDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Monday() As Boolean
		<Required>
		<Column("TUESDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Tuesday() As Boolean
		<Required>
		<Column("WEDNESDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Wednesday() As Boolean
		<Required>
		<Column("THURSDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Thursday() As Boolean
		<Required>
		<Column("FRIDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Friday() As Boolean
		<Required>
		<Column("SATURDAY")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Saturday() As Boolean

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString & " - " & Me.Name.ToString

		End Function

#End Region

	End Class

End Namespace
