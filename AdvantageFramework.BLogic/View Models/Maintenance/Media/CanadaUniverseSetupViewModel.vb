Namespace ViewModels.Maintenance.Media

    Public Class CanadaUniverseSetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AddEnabled As Boolean
        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean

        Public ReadOnly Property HasASelectedCanadaUniverse As Boolean
            Get
                HasASelectedCanadaUniverse = (Me.SelectedCanadaUniverse IsNot Nothing)
            End Get
        End Property

        Public Property CanadaUniverses As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse)
        Public Property SelectedCanadaUniverse As AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse
        Public Property SelectedCanadaUniverseDetails As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.SaveEnabled = False
            Me.CancelEnabled = False
            Me.DeleteEnabled = False

            Me.CanadaUniverses = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverse)
            Me.SelectedCanadaUniverse = Nothing
            Me.SelectedCanadaUniverseDetails = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.CanadaUniverse.CanadaUniverseDetail)

        End Sub

#End Region

    End Class

End Namespace

