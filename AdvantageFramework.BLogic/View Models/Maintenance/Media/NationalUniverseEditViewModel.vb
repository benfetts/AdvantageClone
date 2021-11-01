Namespace ViewModels.Maintenance.Media

    Public Class NationalUniverseEditViewModel

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

        Public Property NationalUniverseID As Integer
        Public Property NationalUniverse As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse

        Public Property MarketBreaks As Generic.List(Of AdvantageFramework.Database.Entities.MarketBreak)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = False
            Me.UpdateEnabled = False
            Me.CancelEnabled = False

            Me.NationalUniverseID = 0
            Me.NationalUniverse = Nothing

            Me.MarketBreaks = New Generic.List(Of AdvantageFramework.Database.Entities.MarketBreak)

        End Sub

#End Region

    End Class

End Namespace

