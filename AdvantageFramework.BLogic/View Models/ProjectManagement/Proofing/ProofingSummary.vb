Namespace ViewModels.ProjectManagement.Proofing

    <Serializable()> Public Class ProofingSummary

#Region " Constants "



#End Region

#Region " Enum "

        'Public Enum Properties

        '    AlertID
        '    Title
        '    Description
        '    Created
        '    CreatedByUserCode
        '    CreatedByName
        '    IsCompleted
        '    LastUpdatedName
        '    TotalReviewers
        '    TotalApproved
        '    TotalRejected
        '    TotalDeferred
        '    LastestThumbnail
        '    StatusDisplay
        '    LastestThumbnail

        'End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Public Property ID As Integer? = 0
        Public Property AlertID As Integer? = 0
        Public Property Title As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property Created As DateTime? = Nothing
        Public Property CreatedByUserCode As String = String.Empty
        Public Property CreatedByName As String = String.Empty
        Public Property IsRouted As Boolean? = False
        Public Property IsCompleted As Boolean? = False
        Public Property LastUpdatedName As String = String.Empty
        Public Property InternalTotalReviewers As Integer? = 0
        Public Property InternalTotalApproved As Integer? = 0
        Public Property InternalTotalRejected As Integer? = 0
        Public Property InternalTotalDeferred As Integer? = 0
        Public Property ExternalTotalReviewers As Integer? = 0
        Public Property ExternalTotalApproved As Integer? = 0
        Public Property ExternalTotalRejected As Integer? = 0
        Public Property ExternalTotalDeferred As Integer? = 0
        Public Property TotalReviewers As Integer? = 0
        Public Property TotalApproved As Integer? = 0
        Public Property TotalRejected As Integer? = 0
        Public Property TotalDeferred As Integer? = 0
        Public Property InternalStatusDisplay As String = String.Empty
        Public Property ExternalStatusDisplay As String = String.Empty
        Public Property StatusDisplay As String = String.Empty
        Public Property LatestDocumentID As Integer? = 0
        Public Property LatestThumbnail As Byte()
        Public Property AlertTemplateID As Integer? = 0
        Public Property AlertTemplateName As String = String.Empty
        Public Property AlertStateID As Integer? = 0
        Public Property AlertStateName As String = String.Empty
        Public Property CompletedText As String = String.Empty
        Public Property RoutedText As String = String.Empty
        Public Property InternalLastCommentFullName As String = String.Empty
        Public Property InternalLastCommentDate As DateTime? = Nothing
        Public Property ExternalLastCommentFullName As String = String.Empty
        Public Property ExternalLastCommentDate As DateTime? = Nothing
        Public Property InternalLastMarkupFullName As String = String.Empty
        Public Property InternalLastMarkupDate As DateTime? = Nothing
        Public Property ExternalLastMarkupFullName As String = String.Empty
        Public Property ExternalLastMarkupDate As DateTime? = Nothing
        Public Property TotalDocuments As Integer? = 0
        Public Property TotalMarkups As Integer? = 0
        Public Property TotalComments As Integer? = 0

#End Region

#Region " Methods "
        Sub New()

        End Sub

#End Region

    End Class

End Namespace
