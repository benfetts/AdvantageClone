Namespace ViewModels.Media

    Public Class MediaRFPMarketCrossReferenceViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property IsNewRow As Boolean
        Public Property SaveEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public ReadOnly Property HasASelectedMediaRFPMarketCrossReference As Boolean
            Get
                HasASelectedMediaRFPMarketCrossReference = (Me.SelectedMediaRFPMarketCrossReference IsNot Nothing)
            End Get
        End Property

        Public Property SelectedMediaRFPMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference

        Public Property RepositoryMarketList As Generic.List(Of AdvantageFramework.DTO.Market)
        Public Property MediaRFPMarketCrossReferenceList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference)

#End Region

#Region " Methods "

        Public Sub New()

            RepositoryMarketList = New Generic.List(Of AdvantageFramework.DTO.Market)
            MediaRFPMarketCrossReferenceList = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPMarketCrossReference)

        End Sub

#End Region

    End Class

End Namespace