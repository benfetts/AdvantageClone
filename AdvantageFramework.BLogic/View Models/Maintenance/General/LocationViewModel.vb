Namespace ViewModels.Maintenance.General

    Public Class LocationViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Locations As List(Of AdvantageFramework.DTO.Maintenance.General.Location.Location)
        Public Property LocationDetails As AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails
        Public Property LocationLogo As AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo

#End Region

#Region " Methods "

        Sub New()

            Me.Locations = New List(Of AdvantageFramework.DTO.Maintenance.General.Location.Location)
            Me.LocationDetails = New AdvantageFramework.DTO.Maintenance.General.Location.LocationDetails
            Me.LocationLogo = New AdvantageFramework.DTO.Maintenance.General.Location.LocationLogo

        End Sub

#End Region

    End Class

End Namespace
