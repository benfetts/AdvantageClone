Namespace ViewModels.Media

    Public Class RequestForProposalGenerateViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property GenerateRFPList As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFP)

        Public Property ContactTypeList As Generic.List(Of AdvantageFramework.Database.Entities.ContactType)

        Public Property ContactTypeIDs As Generic.List(Of String)

#End Region

#Region " Methods "

        Public Sub New()

            GenerateRFPList = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFP)

            ContactTypeList = New Generic.List(Of AdvantageFramework.Database.Entities.ContactType)

        End Sub

#End Region

    End Class

End Namespace