Namespace ViewModels.Media

    Public Class RequestForProposalProcessGenerateViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CCSender As Boolean
        Public Property EmailSubject As String
        Public Property EmailBody As String

        Public Property GenerateRFPVendorReps As Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep)
        Public Property EmailVendorRepContacts As Generic.List(Of AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact)
        Public Property ContactTypeList As Generic.List(Of AdvantageFramework.Database.Entities.ContactType)

#Region " Email "

        Public Property Email_AlertID As Integer
        Public Property Email_Comment As String

#End Region

#End Region

#Region " Methods "

        Public Sub New()

            GenerateRFPVendorReps = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.GenerateRFPVendorRep)
            EmailVendorRepContacts = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.EmailVendorRepContact)
            ContactTypeList = New Generic.List(Of AdvantageFramework.Database.Entities.ContactType)

        End Sub

#End Region

    End Class

End Namespace