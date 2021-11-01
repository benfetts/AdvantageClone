Namespace Database.Classes

    <Serializable()>
    Public Class JobStatus

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            JobNumber
            JobDescription
            JobComponentNumber
            JobComponentDescription
            ScheduleStatusCode
            ScheduleStatusDescription
            ScheduleComments
            EstimateApprovalStatusClient
            EstimateApprovalStatusClientDate
            EstimateApprovalStatusInternal
            EstimateApprovalStatusInternalDate
            QuotedHours
            ActualHours
            RemainingHours
            QuotedDollars
            ActualDollars
            RemainingDollars
            PercentComplete
            ProjectedHours
            TotalTaskHours
            TaskActualHours
            ActualEmployeeTaskHours
            LastAlertID
            LastAlertSubject
            LastAlertDate
            OpenAlertCount
            TotalAlertCount
            OpenTasksCount
            TotalTasksCount
            TaskMinStartDate
            TaskMaxDueDate
            PercentCompleteScheduleHours
            PercentCompleteAlerts
            PercentCompleteTasks
            AccountExecutiveEmployeeCode
            AccountExecutiveFullName
            ScheduleManagerEmployeeCode
            ScheduleManagerFullName
            Assignment1EmployeeCode
            Assignment1FullName
            Assignment2EmployeeCode
            Assignment2FullName
            Assignment3EmployeeCode
            Assignment3FullName
            Assignment4EmployeeCode
            Assignment4FullName
            Assignment5EmployeeCode
            Assignment5FullName
            ScheduleStartDate
            ScheduleDueDate
            ScheduleEndDate
            ScheduleCompletedDate
            Duration
            Office
            Client
            Division
            Product
            Assignment1Label
            Assignment2Label
            Assignment3Label
            Assignment4Label
            Assignment5Label
            ScheduleGutPercentComplete
            JobProcessControlID
            JobProcessControl
            JobIsBillable
            ApprovedEstimateRequired
            LastAssignmentID
            LastAssignmentSubject
            LastAssignmentDate
            OpenAssignmentCount
            TotalAssignmentCount
            EstimateApprovalStatusClientComment
            EstimateApprovalStatusInternalComment
            TaskHoursUnassigned
            BatchText
            BatchID
            BatchDescription
            BatchCreatedByUser
            BatchDate
            BillingUser
            ABFlag
            ABFlagText
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property JobNumber() As Nullable(Of Integer)

        Public Property JobDescription() As String

        Public Property JobComponentNumber() As Nullable(Of Integer)

        Public Property JobComponentDescription() As String

        Public Property ScheduleStatusCode() As String

        Public Property ScheduleStatusDescription() As String

        Public Property ScheduleComments() As String

        Public Property EstimateApprovalStatusClient() As String

        Public Property EstimateApprovalStatusClientDate() As Nullable(Of Date)

        Public Property EstimateApprovalStatusInternal() As String

        Public Property EstimateApprovalStatusInternalDate() As Nullable(Of Date)

        Public Property QuotedHours() As Nullable(Of Decimal)

        Public Property ActualHours() As Nullable(Of Decimal)

        Public Property RemainingHours() As Nullable(Of Decimal)

        Public Property QuotedDollars() As Nullable(Of Decimal)

        Public Property ActualDollars() As Nullable(Of Decimal)

        Public Property RemainingDollars() As Nullable(Of Decimal)

        Public Property PercentComplete() As Nullable(Of Decimal)

        Public Property ProjectedHours() As Nullable(Of Decimal)

        Public Property TotalTaskHours() As Nullable(Of Decimal)

        Public Property TaskActualHours() As Nullable(Of Decimal)

        Public Property ActualEmployeeTaskHours() As Nullable(Of Decimal)

        Public Property LastAlertID() As Nullable(Of Integer)

        Public Property LastAlertSubject() As String

        Public Property LastAlertDate() As Nullable(Of Date)

        Public Property OpenAlertCount() As Nullable(Of Decimal)

        Public Property TotalAlertCount() As Nullable(Of Decimal)

        Public Property OpenTasksCount() As Nullable(Of Decimal)

        Public Property TotalTasksCount() As Nullable(Of Decimal)

        Public Property TaskMinStartDate() As Nullable(Of Date)

        Public Property TaskMaxDueDate() As Nullable(Of Date)

        Public Property PercentCompleteScheduleHours() As Nullable(Of Decimal)

        Public Property PercentCompleteAlerts() As Nullable(Of Decimal)

        Public Property PercentCompleteTasks() As Nullable(Of Decimal)

        Public Property AccountExecutiveEmployeeCode() As String

        Public Property AccountExecutiveFullName() As String

        Public Property ScheduleManagerEmployeeCode() As String

        Public Property ScheduleManagerFullName() As String

        Public Property Assignment1EmployeeCode() As String

        Public Property Assignment1FullName() As String

        Public Property Assignment2EmployeeCode() As String

        Public Property Assignment2FullName() As String

        Public Property Assignment3EmployeeCode() As String

        Public Property Assignment3FullName() As String

        Public Property Assignment4EmployeeCode() As String

        Public Property Assignment4FullName() As String

        Public Property Assignment5EmployeeCode() As String

        Public Property Assignment5FullName() As String

        Public Property ScheduleStartDate() As Nullable(Of Date)

        Public Property ScheduleDueDate() As Nullable(Of Date)

        Public Property ScheduleEndDate() As Nullable(Of Date)

        Public Property ScheduleCompletedDate() As Nullable(Of Date)

        Public Property Duration() As Nullable(Of Decimal)

        Public Property Office() As String

        Public Property Client() As String

        Public Property Division() As String

        Public Property Product() As String

        Public Property Assignment1Label() As String

        Public Property Assignment2Label() As String

        Public Property Assignment3Label() As String

        Public Property Assignment4Label() As String

        Public Property Assignment5Label() As String

        Public Property ScheduleGutPercentComplete() As Nullable(Of Decimal)

        Public Property JobProcessControlID() As Nullable(Of Short)

        Public Property JobProcessControl() As String

        Public Property JobIsBillable() As Nullable(Of Boolean)

        Public Property ApprovedEstimateRequired() As Nullable(Of Boolean)

        Public Property LastAssignmentID() As Nullable(Of Integer)

        Public Property LastAssignmentSubject() As String

        Public Property LastAssignmentDate() As Nullable(Of Date)

        Public Property OpenAssignmentCount() As Nullable(Of Decimal)

        Public Property TotalAssignmentCount() As Nullable(Of Decimal)

        Public Property EstimateApprovalStatusClientComment() As String

        Public Property EstimateApprovalStatusInternalComment() As String

        Public Property TaskHoursUnassigned() As Nullable(Of Decimal)

        Public Property BatchText() As String

        Public Property BatchID() As Nullable(Of Integer)

        Public Property BatchDescription() As String

        Public Property BatchCreatedByUser() As String

        Public Property BatchDate() As Nullable(Of Date)

        Public Property BillingUser() As String

        Public Property ABFlag() As Nullable(Of Short)

        Public Property ABFlagText() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.JobNumber.ToString

        End Function

#End Region

    End Class

End Namespace
