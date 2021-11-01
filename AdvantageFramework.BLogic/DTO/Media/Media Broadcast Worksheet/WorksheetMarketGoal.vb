Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class WorksheetMarketGoal
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			MediaBroadcastWorksheetMarketID
			RowIndex
			DaypartID
			DaypartCode
			DaypartDescription
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
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property MediaBroadcastWorksheetMarketID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property RowIndex() As Integer
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property DaypartID() As Nullable(Of Integer)
		Public Property DaypartCode() As String
		Public Property DaypartDescription() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Length() As Short
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property GRP() As Decimal
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CPP() As Decimal
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property BudgetAmount() As Decimal
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property BudgetPercentage() As Decimal
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property WasRateImported() As Boolean
		<Required>
		<MaxLength(100)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CreatedByUserCode() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property CreatedDate() As Date
		<MaxLength(100)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedByUserCode() As String
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property ModifiedDate() As Nullable(Of Date)

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.MediaBroadcastWorksheetMarketID = 0
			Me.RowIndex = -1
			Me.DaypartID = Nothing
			Me.DaypartCode = String.Empty
			Me.DaypartDescription = String.Empty
			Me.Length = 0
			Me.GRP = 0
			Me.CPP = 0
			Me.BudgetAmount = 0
			Me.BudgetPercentage = 0
			Me.WasRateImported = False
			Me.CreatedByUserCode = String.Empty
			Me.CreatedDate = Date.MinValue
			Me.ModifiedByUserCode = Nothing
			Me.ModifiedDate = Nothing

		End Sub
		Public Sub New(MediaBroadcastWorksheetMarketGoal As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketGoal)

			Me.ID = MediaBroadcastWorksheetMarketGoal.ID
			Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketGoal.MediaBroadcastWorksheetMarketID
			Me.RowIndex = MediaBroadcastWorksheetMarketGoal.RowIndex
			Me.DaypartID = MediaBroadcastWorksheetMarketGoal.DaypartID
			Me.DaypartCode = If(MediaBroadcastWorksheetMarketGoal.Daypart IsNot Nothing, MediaBroadcastWorksheetMarketGoal.Daypart.Code, "")
			Me.DaypartDescription = If(MediaBroadcastWorksheetMarketGoal.Daypart IsNot Nothing, MediaBroadcastWorksheetMarketGoal.Daypart.Description, "")
			Me.Length = MediaBroadcastWorksheetMarketGoal.Length
			Me.GRP = MediaBroadcastWorksheetMarketGoal.GRP
			Me.CPP = MediaBroadcastWorksheetMarketGoal.CPP
			Me.BudgetAmount = MediaBroadcastWorksheetMarketGoal.BudgetAmount
			Me.BudgetPercentage = MediaBroadcastWorksheetMarketGoal.BudgetPercentage
			Me.WasRateImported = MediaBroadcastWorksheetMarketGoal.WasRateImported
			Me.CreatedByUserCode = MediaBroadcastWorksheetMarketGoal.CreatedByUserCode
			Me.CreatedDate = MediaBroadcastWorksheetMarketGoal.CreatedDate
			Me.ModifiedByUserCode = MediaBroadcastWorksheetMarketGoal.ModifiedByUserCode
			Me.ModifiedDate = MediaBroadcastWorksheetMarketGoal.ModifiedDate

		End Sub
		Public Sub SaveToEntity(ByRef MediaBroadcastWorksheetMarketGoal As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarketGoal)

			MediaBroadcastWorksheetMarketGoal.ID = Me.ID
			MediaBroadcastWorksheetMarketGoal.MediaBroadcastWorksheetMarketID = Me.MediaBroadcastWorksheetMarketID
			MediaBroadcastWorksheetMarketGoal.RowIndex = Me.RowIndex
			MediaBroadcastWorksheetMarketGoal.DaypartID = Me.DaypartID
			MediaBroadcastWorksheetMarketGoal.Length = Me.Length
			MediaBroadcastWorksheetMarketGoal.GRP = Me.GRP
			MediaBroadcastWorksheetMarketGoal.CPP = Me.CPP
			MediaBroadcastWorksheetMarketGoal.BudgetAmount = Me.BudgetAmount
			MediaBroadcastWorksheetMarketGoal.BudgetPercentage = Me.BudgetPercentage
			MediaBroadcastWorksheetMarketGoal.WasRateImported = Me.WasRateImported
			MediaBroadcastWorksheetMarketGoal.CreatedByUserCode = Me.CreatedByUserCode
			MediaBroadcastWorksheetMarketGoal.CreatedDate = Me.CreatedDate
			MediaBroadcastWorksheetMarketGoal.ModifiedByUserCode = Me.ModifiedByUserCode
			MediaBroadcastWorksheetMarketGoal.ModifiedDate = Me.ModifiedDate

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.ID.ToString

		End Function

#End Region

	End Class

End Namespace
