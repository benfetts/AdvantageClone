Namespace ViewModels.Maintenance.Accounting

    Public Class VendorStationsViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property VendorStations As Generic.List(Of AdvantageFramework.DTO.VendorStation)

        Public Property RepositoryMarkets As Generic.List(Of AdvantageFramework.DTO.Market)
        Public Property RepositoryNCCTVSyscodes As Generic.List(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)
        Public Property RepositoryNielsenRadioStations As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)
        Public Property RepositoryNielsenTVStations As Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)

#End Region

#Region " Methods "

        Public Sub New()

            Me.SaveEnabled = False
            Me.CancelEnabled = True
            Me.VendorStations = New Generic.List(Of AdvantageFramework.DTO.VendorStation)
            Me.RepositoryMarkets = New Generic.List(Of AdvantageFramework.DTO.Market)
            Me.RepositoryNCCTVSyscodes = New Generic.List(Of AdvantageFramework.Nielsen.Database.Classes.NCCTVSyscode)
            Me.RepositoryNielsenRadioStations = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenRadioStation)
            Me.RepositoryNielsenTVStations = New Generic.List(Of AdvantageFramework.Nielsen.Database.Entities.NielsenTVStation)

        End Sub

#End Region

    End Class

End Namespace
