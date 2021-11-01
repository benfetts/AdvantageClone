Namespace ViewModels.Maintenance.Media

    Public Class NationalUniverseSetupViewModel

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

        Public ReadOnly Property HasASelectedNationalUniverse As Boolean
            Get
                HasASelectedNationalUniverse = (Me.SelectedNationalUniverse IsNot Nothing)
            End Get
        End Property

        Public Property NationalUniverses As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse)
        Public Property SelectedNationalUniverse As AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse
        Public Property SelectedNationalUniverseDetails As Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail)

#End Region

#Region " Methods "

        Public Sub New()

            Me.AddEnabled = True
            Me.SaveEnabled = False
            Me.CancelEnabled = False
            Me.DeleteEnabled = False

            Me.NationalUniverses = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverse)
            Me.SelectedNationalUniverse = Nothing
            Me.SelectedNationalUniverseDetails = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Media.NationalUniverse.NationalUniverseDetail)

        End Sub

#End Region

    End Class

End Namespace

