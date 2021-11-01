Namespace ViewModels.Maintenance.Media

    Public Class CanadaUniverseEditViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property UpdateEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property CanadaUniverseID As Integer
        Public Property CanadaUniverse As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse

        Public Property AddAllMarkets As Boolean
        Public Property Markets As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Market)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = False
            Me.UpdateEnabled = False
            Me.CancelEnabled = False

            Me.CanadaUniverseID = 0
            Me.CanadaUniverse = Nothing

            Me.AddAllMarkets = False
            Me.Markets = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.Market)

        End Sub

#End Region

    End Class

End Namespace

