Namespace ViewModels.Media

    Public Class MediaBroadcastWorksheetETAMExportViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property Filename As String
        Public Property OutputFolder As String
        Public Property Stations As Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station)
        Public Property HasExportableDetail As Boolean
        Public Property SelectedStations As Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station)
        Public Property StationOrderNumbers As Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.StationOrderNumber)

#End Region

#Region " Methods "

        Public Sub New()

            Stations = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station)
            SelectedStations = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.Station)
            StationOrderNumbers = New Generic.List(Of AdvantageFramework.DTO.Media.SpotTVPuertoRico.StationOrderNumber)

        End Sub

#End Region

    End Class

End Namespace
