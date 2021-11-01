Namespace Database.Entities

	<Table("MEDIA_BROADCAST_WORKSHEET_MARKET_REVISION")>
	Public Class MediaBroadcastWorksheetMarketRevision
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketID
			RevisionNumber
			Comment
			CreatedByUserCode
			CreatedDate
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_REVISION_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketID() As Integer
		<Required>
		<Column("REVISION_NUMBER")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property RevisionNumber() As Integer
		<Required>
		<Column("COMMENT", TypeName:="varchar(MAX)")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Comment() As String
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CreatedDate() As Date

		Public Overridable Property MediaBroadcastWorksheetMarket As Database.Entities.MediaBroadcastWorksheetMarket

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
