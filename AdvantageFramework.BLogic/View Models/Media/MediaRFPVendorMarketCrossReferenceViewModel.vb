Namespace ViewModels.Media

    Public Class MediaRFPVendorMarketCrossReferenceViewModel

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

        Public ReadOnly Property HasASelectedMediaRFPVendorMarketCrossReference As Boolean
            Get
                HasASelectedMediaRFPVendorMarketCrossReference = (Me.SelectedMediaRFPVendorMarketCrossReference IsNot Nothing)
            End Get
        End Property

        Public Property SelectedMediaRFPVendorMarketCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference

        Public Property RepositoryMarketList As Generic.List(Of AdvantageFramework.DTO.Market)
        Public Property MediaRFPVendorMarketCrossReferenceList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference)

#End Region

#Region " Methods "

        Public Sub New()

            RepositoryMarketList = New Generic.List(Of AdvantageFramework.DTO.Market)
            MediaRFPVendorMarketCrossReferenceList = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPVendorMarketCrossReference)

        End Sub

#End Region

    End Class

End Namespace