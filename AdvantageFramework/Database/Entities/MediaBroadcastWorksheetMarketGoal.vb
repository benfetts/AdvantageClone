Namespace Database.Entities

	<Table("MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL")>
	Public Class MediaBroadcastWorksheetMarketGoal
		Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketID
			RowIndex
			DaypartID
			Length
			GRP
			CPP
			BudgetAmount
			BudgetPercentage
			WasRateImported
			CreatedByUserCode
			CreatedDate
			ModifiedByUserCode
			ModifiedDate
			MediaBroadcastWorksheetMarket
			Daypart
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Key>
		<System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_GOAL_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketID() As Integer
		<Required>
		<Column("ROW_INDEX")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property RowIndex() As Integer
		<Column("DAY_PART_ID")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DaypartID() As Nullable(Of Integer)
		<Required>
		<Column("LENGTH")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property Length() As Short
		<Required>
		<Column("GRP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 1)>
		Public Property GRP() As Decimal
		<Required>
		<Column("CPP")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 4)>
		Public Property CPP() As Decimal
		<Required>
		<Column("BUDGET_AMOUNT")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
		Public Property BudgetAmount() As Decimal
		<Required>
		<Column("BUDGET_PERCENTAGE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		<AdvantageFramework.BaseClasses.Attributes.DecimalPrecisionAttribute(10, 2)>
		Public Property BudgetPercentage() As Decimal
		<Required>
		<Column("WAS_RATE_IMPORTED")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property WasRateImported() As Boolean
		<Required>
		<MaxLength(100)>
		<Column("USER_CREATED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<Column("CREATED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<Column("USER_MODIFIED", TypeName:="varchar")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<Column("MODIFIED_DATE")>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)

		Public Overridable Property Daypart As Database.Entities.Daypart
		Public Overridable Property MediaBroadcastWorksheetMarket As Database.Entities.MediaBroadcastWorksheetMarket
		Public Overridable Property MediaBroadcastWorksheetMarketGoalDates As ICollection(Of Database.Entities.MediaBroadcastWorksheetMarketGoalDate)

#End Region

#Region " Methods "

		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
