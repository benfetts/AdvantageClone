Namespace Database.Entities

	<Table("MEDIA_BROADCAST_WORKSHEET_SECONDARY_DEMO")>
	Public Class MediaBroadcastWorksheetSecondaryDemo
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetID
			MediaDemographicID
			MediaDemographic
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_SECONDARY_DEMO_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetID() As Integer
		<Required>
		<Column("MEDIA_DEMO_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaDemographicID() As Integer

		Public Overridable Property MediaBroadcastWorksheet As Database.Entities.MediaBroadcastWorksheet
		Public Overridable Property MediaDemographic As Database.Entities.MediaDemographic

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
