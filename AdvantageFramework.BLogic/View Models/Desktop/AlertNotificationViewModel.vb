Namespace ViewModels.Desktop

    <Serializable()>
    Public Class AlertNotification

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID As Integer?
        Public Property LastUpdated As DateTime?
        Public Property Generated As DateTime?
        Public Property Priority As Short?
        Public Property ShortSubject As String = String.Empty
        Public Property Subject As String = String.Empty
        Public Property IsAssignment As Boolean?
        Public Property JobNumber As Integer?
        Public Property JobComponentNumber As Short?
        Public Property SequenceNumber As Short?
        Public Property IsConceptShareReview As Boolean?
        Public Property ConceptShareProjectID As Integer?
        Public Property ConceptShareReviewID As Integer?
        Public Property AssignedEmployeeCode As String = String.Empty
        Public Property CurrentNotify As Boolean?
        Public Property IsWorkItem As Boolean?
        Public Property SprintID As Integer?
        Public Property LastUpdatedFullName As String = String.Empty
        Public Property LastUpdatedEmployeeCode As String = String.Empty
        Public Property AlertCategoryDescription As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
