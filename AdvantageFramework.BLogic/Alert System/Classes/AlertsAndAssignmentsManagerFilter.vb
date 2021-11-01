Namespace AlertSystem.Classes

    <Serializable()>
    Public Class AlertsAndAssignmentsManagerFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            UserCode
            EmployeeCode
            SearchCriteria
            InboxType
            ShowAssignmentType
            IsJobAlertsPage
            JobNumber
            JobComponentNumber
            StartDate
            EndDate
            IncludeCompletedAssignments
            GroupBy
            RecordsToReturn
            IsCount
            RecordCount
            IncludeReviews
            IncludeBoardLevel
            IncludeBacklog
            ShowOnlyTempCompletedTasks
            EmployeeRole
            Department
            InitialLoadFlag
            ClientContactID
            IsClientPortal

        End Enum

        'TEMP
        Public Enum InboxTypes

            inbox = 1
            dismissed = 2
            all = 3
            drafts = 4

        End Enum
        Public Enum ShowAssignmentTypes

            myalertsandassignments ' (for job inbox, this shows ALL alerts & assignments)
            myalerts
            myalertassignments ' (for job inbox, this shows all alerts)
            myreviews
            allalertassignments
            unassigned

        End Enum


#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property UserCode As String = String.Empty
        Public Property EmployeeCode As String = String.Empty
        Public Property SearchCriteria As String = String.Empty
        Public Property InboxType As String = String.Empty
        Public Property ShowAssignmentType As String = String.Empty
        Public Property IsJobAlertsPage As Boolean? = False
        Public Property JobNumber As Integer? = 0
        Public Property JobComponentNumber As Short? = 0
        Public Property StartDate As Date? = Nothing
        Public Property EndDate As Date? = Nothing
        Public Property IncludeCompletedAssignments As Boolean? = False
        Public Property GroupBy As String = String.Empty
        Public Property RecordsToReturn As Integer? = 0
        Public Property IsCount As Boolean? = False
        Public Property RecordCount As Integer? = 0
        Public Property IncludeReviews As Boolean? = False
        Public Property IncludeBoardLevel As Boolean? = False
        Public Property IncludeBacklog As Boolean? = False
        Public Property ShowOnlyTempCompletedTasks As Boolean? = False
        Public Property EmployeeRole As String = String.Empty
        Public Property Department As String = String.Empty
        Public Property InitialLoadFlag As Boolean? = False
        Public Property ClientContactID As String = String.Empty
        Public Property IsClientPortal As Boolean? = False

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
