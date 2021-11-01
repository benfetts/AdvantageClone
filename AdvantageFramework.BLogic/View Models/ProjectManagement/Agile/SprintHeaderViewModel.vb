Namespace ViewModels.ProjectManagement.Agile

    <Serializable()>
    Public Class SprintHeaderViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer?
        Public Property Description As String = String.Empty
        Public Property Comments As String = String.Empty
        Public Property BoardID As Integer?
        Public Property SequenceNumber As Short?
        Public Property StartDate As DateTime?
        Public Property StartWeekNumber As Integer?
        Public Property NumberOfWeeks As Integer?
        Public Property CreatedByUserCode As String = String.Empty
        Public Property CreatedDate As DateTime?
        Public Property IsActive As Boolean?
        Public Property IsComplete As Boolean?
        Public Property CompletedDate As DateTime?
        Public Property TrackChanges As Boolean?
        Public Property EmailOnChange As Boolean?
        Public Property ItemCount As Integer?

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
