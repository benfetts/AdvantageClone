Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class CableNetworkStation
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			ID
			Code
			Description
            NielsenTVStationCode
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
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean


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
            Me.IsInactive = CableNetworkStation.IsInactive

        End Sub
        Public Sub New(NCCTVCablenet As AdvantageFramework.Nielsen.Database.Entities.NCCTVCablenet)

            Me.ID = NCCTVCablenet.ID
            Me.Code = NCCTVCablenet.NetworkCode
            Me.Description = NCCTVCablenet.NetworkName
            Me.NielsenTVStationCode = NCCTVCablenet.StationCode.GetValueOrDefault(0)
            Me.IsInactive = False

        End Sub
        Public Sub New(ComscoreTVStation As AdvantageFramework.Database.Entities.ComscoreTVStation)

            Me.ID = ComscoreTVStation.ID
            Me.Code = ComscoreTVStation.CallLetters
            Me.Description = ComscoreTVStation.Name
            Me.NielsenTVStationCode = ComscoreTVStation.Number
            Me.IsInactive = False

        End Sub
        Public Overrides Function ToString() As String

			ToString = Me.Code & " - " & Me.Description

		End Function

#End Region

	End Class

End Namespace
