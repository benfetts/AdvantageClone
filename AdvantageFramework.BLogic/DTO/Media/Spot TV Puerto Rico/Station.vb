Namespace DTO.Media.SpotTVPuertoRico

    Public Class Station
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Station
            IsSelected
            ETAMCrossReference
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Station() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsSelected() As Boolean

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ETAMCrossReference() As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New(NPRStation As AdvantageFramework.Database.Entities.NPRStation)

            Me.ID = NPRStation.ID
            Me.Station = NPRStation.Name
            Me.ETAMCrossReference = NPRStation.ETAMCrossReference

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
