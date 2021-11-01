Namespace ViewModels.ProjectManagement.Proofing
    <Serializable()> Public Class ProofingExternalReviewer

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ProofingExternalReviewerID As Integer
        Public Property AlertID As Integer
        Public Property AlertTemplateID As Integer?
        Public Property AlertStateID As Integer?
        Public Property Name As String = String.Empty
        Public Property EmailAddress As String = String.Empty
        Public Property IsActive As Boolean = False
        Public Property ProofingStatusID As Integer? = Nothing

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace


