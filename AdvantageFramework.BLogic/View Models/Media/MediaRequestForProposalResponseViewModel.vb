Namespace ViewModels.Media

    Public Class MediaRequestForProposalResponseViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property MediaRFPHeaders As Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader)

        Public Property AlertComments As Generic.List(Of AdvantageFramework.DTO.Media.RFP.AlertComment)

        Public Property IsAgencyASP As Boolean

        Public Property MediaBroadcastWorksheetMarketID As Integer

#End Region

#Region " Methods "

        Public Sub New()

            MediaRFPHeaders = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.MediaRFPHeader)

            AlertComments = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.AlertComment)

        End Sub

#End Region

    End Class

End Namespace