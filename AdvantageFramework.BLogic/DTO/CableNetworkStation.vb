Namespace DTO

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
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
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
        Public Property NielsenTVStationCode() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.NielsenTVStationCode = Nothing
            Me.IsInactive = False

        End Sub
        Public Sub New(CableNetworkStation As AdvantageFramework.Database.Entities.CableNetworkStation)

            Me.ID = CableNetworkStation.ID
            Me.Code = CableNetworkStation.Code
            Me.Description = CableNetworkStation.Description
            Me.NielsenTVStationCode = CableNetworkStation.NielsenTVStationCode
            Me.IsInactive = CableNetworkStation.IsInactive

        End Sub
        Public Sub SaveToEntity(ByRef CableNetworkStation As AdvantageFramework.Database.Entities.CableNetworkStation)

            CableNetworkStation.ID = Me.ID
            CableNetworkStation.Code = Me.Code
            CableNetworkStation.Description = Me.Description
            CableNetworkStation.NielsenTVStationCode = Me.NielsenTVStationCode
            CableNetworkStation.IsInactive = Me.IsInactive

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
