Namespace ConceptShare.Classes

	<Serializable()>
	Public Class ReviewSummary

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Review As AdvantageFramework.ConceptShareAPI.Review
        Public Property ReviewMembers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)
        Public Property ExternalReviewMembers As Generic.List(Of AdvantageFramework.ConceptShareAPI.ReviewMember)

        Public Property BaseImage As Byte()
		Public Property ReviewerCount As Integer = 0
        Public Property CompletedReviewerCount As Integer = 0

        Public Property ApprovedReviewerCount As Integer = 0 'Review response status 48
        Public Property RejectedReviewerCount As Integer = 0 'Review response status 49
        Public Property DeferredReviewerCount As Integer = 0 'Review response status 51

        Public ReadOnly Property Completed As String
            Get
                Return CompletedReviewerCount.ToString & "/" & ReviewerCount.ToString
            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

			Review = New ConceptShareAPI.Review
            ReviewMembers = New List(Of ConceptShareAPI.ReviewMember)
            ExternalReviewMembers = New List(Of ConceptShareAPI.ReviewMember)

        End Sub

#End Region

	End Class

End Namespace
