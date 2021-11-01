Namespace DTO.Media

	Public Class CableNetworkStation
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
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property ID() As Integer
		<Required>
		<MaxLength(10)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Code() As String
		<Required>
		<MaxLength(100)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property Description() As String
		<Required>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
		Public Property NielsenTVStationCode() As Integer


#End Region

#Region " Methods "

		Public Sub New()

			Me.ID = 0
			Me.Code = String.Empty
			Me.Description = String.Empty
			Me.NielsenTVStationCode = 0

		End Sub
		Public Sub New(CableNetworkStation As AdvantageFramework.Database.Entities.CableNetworkStation)

			Me.ID = CableNetworkStation.ID
			Me.Code = CableNetworkStation.Code
			Me.Description = CableNetworkStation.Description
			Me.NielsenTVStationCode = CableNetworkStation.NielsenTVStationCode

		End Sub
		Public Overrides Function ToString() As String

			ToString = Me.Code & " - " & Me.Description

		End Function

#End Region

	End Class

End Namespace
