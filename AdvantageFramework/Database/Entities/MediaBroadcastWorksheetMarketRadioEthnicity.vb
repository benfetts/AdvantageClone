Namespace Database.Entities

	<Table("MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY")>
	Public Class MediaBroadcastWorksheetMarketRadioEthnicity
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Name
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_RADIO_ETHNICITY_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(25)>
		<Column("NAME", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Name() As String

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString & " - " & Me.Name.ToString

		End Function

#End Region

	End Class

End Namespace
