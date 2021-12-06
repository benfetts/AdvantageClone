Namespace Dashboard.Classes

    <Serializable()>
    Public Class EmployeeUtilizationGridUpdates

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            AlertID
            AlertCategoryID
            StartDate
            StartDateDirty
            DueDate
            DueDateDirty
            Priority
            PriorityDirty

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID As Integer?
        Public Property AlertCategoryID As Integer?
        Public Property StartDate As String = String.Empty
        Public Property StartDateDirty As Boolean = False
        Public Property DueDate As String = String.Empty
        Public Property DueDateDirty As Boolean = False
        Public Property Priority As String = String.Empty
        Public Property PriorityDirty As Boolean = False

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
