Namespace DTO

	Public Class Daypart
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Code
			Description
			DaypartTypeID
			IsInactive
			DaypartType
		End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
		Public Property ID() As Integer
		<Required>
		<MaxLength(6)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Code)>
		Public Property Code() As String
		<Required>
		<MaxLength(100)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Daypart Type", PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.DaypartTypeID)>
		Public Property DaypartTypeID() As Integer
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
		Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.Code = String.Empty
			Me.Description = String.Empty
			Me.DaypartTypeID = 0
			Me.IsInactive = False

		End Sub
		Public Sub New(Daypart As AdvantageFramework.Database.Entities.Daypart)

			Me.ID = Daypart.ID
			Me.Code = Daypart.Code
			Me.Description = Daypart.Description
			Me.DaypartTypeID = Daypart.DaypartTypeID
			Me.IsInactive = Daypart.IsInactive

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.Code & " - " & Me.Description

		End Function

#End Region

	End Class

End Namespace
