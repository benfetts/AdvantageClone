Namespace AlertSystem.Classes

    <Serializable()>
    Public Class AlertsAndAssignmentsManagerItem

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Subject
            Generated
            GeneratedNoTime
            LastUpdated
            LastUpdatedNoTime
            StartDate
            DueDate
            TimeDue
            AlertStateName
            Priority '10
            AssignedTo
            AssignedToEmpCode
            Category
            ClientName
            ClientCode
            GroupDivision
            DivisionCode
            GroupProduct
            ProductCode
            Job             ' 20
            JobNumber
            JobComponent
            ComponentNumber
            JobComponentDetailed
            JobAndComponentNumber
            JobDescription
            ComponentDescription
            ID
            SoftwareVersion
            SoftwareBuild   '30
            AlertTypeText
            AccountExecutive
            ProjectManager
            GroupOffice
            GroupCampaign
            GroupAlertTemplateName
            IsRead
            AlertCategoryID
            SprintID
            AlertID     '40
            IsTaskAssignment
            AttachmentCount
            IsRoutedAssignment
            IsRouted
            IsWorkItem
            IsCurrentAssignee
            IsDismissed
            IsNonRoutedAssignment
            IsCC
            IsMyAssignment '50
            IsMyAlert
            IsMyTask
            TaskStatus
            TaskComments
            HoursAllowed
            TaskDateDiff
            TaskDateIsWeekend
            EmployeeRoleCode
            EmployeeRoleDescription
            GroupPriority '60
            CDPCodes
            TaskSequenceNumber
            AssignedToLinkAddress
            AssignedToTitle
            IsMyTaskTempComplete
            IsOwnerAssignmentAlert
            UserName
            IsDraft
            TempCompleteDate
            TempCompleteDateNoTime
            CCEmployeeCodes '71
            CCEmployeeNames '72
            Board
            BoardState
            Sprint
            SprintStartDate
            IsBacklogItem

            IsStandardAlert

            IsMyAssignmentCompleted
            TaskStatusDescription
            'IsMyAlertCompleted
            'IsTaskCompleted ' 60
            'IsStandardAlert
            'GroupClient
            'GroupJob
            'GroupJobComponent
            'GroupTask
            'GroupEstimate
            'GroupEstimateComponent
            'GroupDueDate
            'GroupDueDateDisplay
            'AlertLevel
            'AlertLevelText
            'CampaignCode
            'CompletedAssigneesCount
            'OpenAssigneesCount
            'DismissedRecipientsCount
            'OpenRecipientsCount
            'AssignmentCompleted
            'UserOrder
            'IsUnAssigned
            'TaskJobComponentDescription


        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "
        Public Property Subject As String = String.Empty
        Public Property Generated As Date?
        Public Property GeneratedNoTime As Date?
        Public Property LastUpdated As Date?
        Public Property LastUpdatedNoTime As Date?
        Public Property StartDate As Date?
        Public Property DueDate As Date?
        Public Property TimeDue As String = String.Empty
        Public Property AlertStateName As String = String.Empty
        Public Property Priority As Short? = 3 '10
        Public Property AssignedTo As String = String.Empty
        Public Property AssignedToEmpCode As String = String.Empty
        Public Property Category As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property GroupDivision As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property GroupProduct As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Public Property Job As String = String.Empty             ' 20
        Public Property JobNumber As Integer?
        Public Property JobComponent As String = String.Empty
        Public Property ComponentNumber As Short?
        Public Property JobComponentDetailed As String = String.Empty
        Public Property JobAndComponentNumber As String = String.Empty
        Public Property JobDescription As String = String.Empty
        Public Property ComponentDescription As String = String.Empty
        Public Property ID As Integer?
        Public Property SoftwareVersion As String = String.Empty
        Public Property SoftwareBuild As String = String.Empty   '30
        Public Property AlertTypeText As String = String.Empty
        Public Property AccountExecutive As String = String.Empty
        Public Property ProjectManager As String = String.Empty
        Public Property GroupOffice As String = String.Empty
        Public Property GroupCampaign As String = String.Empty
        Public Property GroupAlertTemplateName As String = String.Empty
        Public Property IsRead As Boolean? = False
        Public Property AlertCategoryID As Integer?
        Public Property SprintID As Integer?
        Public Property AlertID As Integer?     '40
        Public Property IsTaskAssignment As Boolean? = False
        Public Property AttachmentCount As Integer?
        Public Property IsRoutedAssignment As Boolean? = False
        Public Property IsRouted As Boolean? = False
        Public Property IsWorkItem As Boolean? = False
        Public Property IsCurrentAssignee As Boolean? = False
        Public Property IsDismissed As Boolean? = False
        Public Property IsNonRoutedAssignment As Boolean? = False
        Public Property IsCC As Boolean? = False
        Public Property IsMyAssignment As Boolean? = False '50
        Public Property IsMyAlert As Boolean? = False
        Public Property IsMyTask As Boolean? = False
        Public Property TaskStatus As String = String.Empty
        Public Property TaskComments As String = String.Empty
        Public Property HoursAllowed As String = String.Empty
        Public Property TaskDateDiff As Integer?
        Public Property TaskDateIsWeekend As Boolean? = False
        Public Property EmployeeRoleCode As String = String.Empty
        Public Property EmployeeRoleDescription As String = String.Empty
        Public Property GroupPriority As String = String.Empty '60
        Public Property CDPCodes As String = String.Empty
        Public Property TaskSequenceNumber As Short?
        Public Property AssignedToLinkAddress As String = String.Empty
        Public Property AssignedToTitle As String = String.Empty
        Public Property IsMyTaskTempComplete As Boolean? = False
        Public Property IsOwnerAssignmentAlert As Boolean? = False
        Public Property UserName As String = String.Empty '67
        Public Property IsDraft As Boolean? = False ' 68
        Public Property TempCompleteDate As Date? '69
        Public Property TempCompleteDateNoTime As Date?
        Public Property CCEmployeeCodes As String = String.Empty
        Public Property CCEmployeeNames As String = String.Empty '72
        Public Property Board As String = String.Empty '73
        Public Property BoardState As String = String.Empty '74
        Public Property Sprint As String = String.Empty '75
        Public Property SprintStartDate As Date? '76
        Public Property IsBacklogItem As Boolean? = False
        Public Property TaskStatusDescription As String = String.Empty

        'Public Property AlertID As Integer? ' 1
        'Public Property ID As Integer?
        'Public Property LastUpdated As Date?
        'Public Property LastUpdatedNoTime As Date?
        'Public Property Generated As Date?
        'Public Property GeneratedNoTime As Date?
        'Public Property Priority As Short? = 3
        'Public Property AlertCategoryID As Integer?
        'Public Property AlertStateName As String = String.Empty
        'Public Property AlertLevel As String = String.Empty
        'Public Property AlertLevelText As String = String.Empty
        'Public Property Subject As String = String.Empty ' 10
        'Public Property AttachmentCount As Integer?
        'Public Property StartDate As Date?
        'Public Property DueDate As Date?
        'Public Property TimeDue As String = String.Empty
        'Public Property AlertTypeText As String = String.Empty
        'Public Property Category As String = String.Empty
        'Public Property ClientName As String = String.Empty
        'Public Property SoftwareVersion As String = String.Empty
        'Public Property SoftwareBuild As String = String.Empty

        'Public Property Job As String = String.Empty
        'Public Property JobNumber As Integer? ' 20
        'Public Property JobComponent As String = String.Empty
        'Public Property ComponentNumber As Short?
        'Public Property JobComponentDetailed As String = String.Empty
        'Public Property JobAndComponentNumber As String = String.Empty
        'Public Property JobDescription As String = String.Empty
        'Public Property ComponentDescription As String = String.Empty

        ''Public Property JobNumber As Integer? ' 20
        ''Public Property JobComponentNumber As Short? = 0
        ''Public Property JobComponentDescription As String = String.Empty
        ''Public Property JobComponentNumberCombined As String = String.Empty
        'Public Property SprintID As Integer?
        'Public Property TaskSequenceNumber As Short?
        'Public Property TaskStatus As String = String.Empty
        'Public Property GroupOffice As String = String.Empty
        'Public Property GroupClient As String = String.Empty
        'Public Property GroupDivision As String = String.Empty
        'Public Property GroupProduct As String = String.Empty
        ''Public Property GroupJob As String = String.Empty
        ''Public Property GroupJobComponent As String = String.Empty
        'Public Property GroupCampaign As String = String.Empty ' 30
        'Public Property GroupTask As String = String.Empty
        'Public Property GroupEstimate As String = String.Empty
        'Public Property GroupEstimateComponent As String = String.Empty
        'Public Property GroupDueDate As String = String.Empty
        'Public Property GroupDueDateDisplay As String = String.Empty
        'Public Property GroupPriority As String = String.Empty
        'Public Property GroupAlertTemplateName As String = String.Empty
        'Public Property ClientCode As String = String.Empty
        'Public Property DivisionCode As String = String.Empty
        'Public Property ProductCode As String = String.Empty ' 40
        'Public Property CampaignCode As String = String.Empty
        'Public Property IsCurrentAssignee As Boolean? = False
        'Public Property AssignedTo As String = String.Empty
        'Public Property AssignedToEmpCode As String = String.Empty
        'Public Property AssignedToLinkAddress = String.Empty
        'Public Property AssignedToTitle = String.Empty
        'Public Property IsRouted As Boolean? = False
        'Public Property IsWorkItem As Boolean? = False
        Public Property IsStandardAlert As Boolean? = False
        'Public Property IsCC As Boolean? = False
        'Public Property IsRoutedAssignment As Boolean? = False
        'Public Property IsNonRoutedAssignment As Boolean? = False
        'Public Property IsTaskAssignment As Boolean? = False ' 50
        'Public Property CompletedAssigneesCount As Short? = 0
        'Public Property OpenAssigneesCount As Short? = 0
        'Public Property DismissedRecipientsCount As Short? = 0
        'Public Property OpenRecipientsCount As Short? = 0
        'Public Property IsMyAssignment As Boolean? = False
        Public Property IsMyAssignmentCompleted As Boolean? = False
        'Public Property IsMyAlert As Boolean? = False
        'Public Property IsMyAlertCompleted As Boolean? = False
        'Public Property IsMyTask As Boolean? = False
        'Public Property IsTaskCompleted As Boolean? = False ' 60
        'Public Property IsDismissed As Boolean? = False
        'Public Property AssignmentCompleted As Boolean? = False
        'Public Property UserOrder As Integer?
        'Public Property IsUnAssigned As Boolean? = False
        'Public Property IsRead As Boolean? = False
        'Public Property AccountExecutive As String = String.Empty
        'Public Property ProjectManager As String = String.Empty
        'Public Property IsMyTaskTempComplete As Boolean? = False
        ''Public Property Job As String = String.Empty
        ''Public Property JobComponent As String = String.Empty
        ''Public Property TaskJobComponentDescription As String = String.Empty
        ''Public Property JobDescription As String = String.Empty
        'Public Property TaskComments As String = String.Empty
        'Public Property HoursAllowed As String = String.Empty
        'Public Property TaskDateDiff As Integer?
        'Public Property TaskDateDiffIsWeekend As Boolean? = False
        'Public Property EmployeeRoleCode As String = String.Empty
        'Public Property EmployeeRoleDescription As String = String.Empty
        'Public Property IsOwnerAssignmentAlert As Boolean? = False
        'Public Property CDPCodes As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
