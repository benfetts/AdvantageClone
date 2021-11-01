Imports AdvantageFramework.Timesheet.Methods

Namespace ViewModels.Employee.Timesheet

    <Serializable()>
    Public Class TimesheetEntryViewModel

#Region " Constants "



#End Region

#Region " Enum "
        Public Enum Properties

            AlertSubject
            EmployeeTimeID
            EmployeeTimeDetailID
            SequenceNumber
            Hours
            [Date]
            Comments
            EditFlag
            TimeType
            HasStopwatch
            CannotEditDueToProcessingControl
            CommentsRequired
            CanDelete
            AlertID
            WebDataKey
            LineID
            JobNumber
            JobComponentNumber
            FunctionCategoryCode
            DepartmentTeamCode
            EmployeeCode
            ClientDisplay
            ClientName
            DivisionName
            ProductName
            JobDisplay
            AssignmentDisplay
            FunctionCategoryDisplay
            NonEditMessage
            EditFlagText

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertSubject As String = String.Empty
        Public Property EmployeeTimeID As Integer? = 0
        Public Property EmployeeTimeDetailID As Integer? = 0
        Public Property SequenceNumber As Short? = 0
        Public Property Hours As Double? = 0.0
        Public Property [Date] As Date
        Public Property Comments As String = String.Empty
        Public Property EditFlag As TimesheetEditType = TimesheetEditType.Edit
        Public Property TimeType As String = String.Empty
        Public Property HasStopwatch As Boolean? = False
        Public Property CannotEditDueToProcessingControl As Boolean
        Public Property CommentsRequired As Boolean? = False
        Public Property CanDelete As Boolean? = False
        Public Property AlertID As Integer? = 0
        Public Property WebDataKey As String = String.Empty
        Public Property LineID As String = String.Empty

        Public Property JobNumber As Integer? = 0
        Public Property JobComponentNumber As Short? = 0
        Public Property FunctionCategoryCode As String = String.Empty
        Public Property DepartmentTeamCode As String = String.Empty
        Public Property EmployeeCode As String = String.Empty

        Public Property ClientDisplay As String = String.Empty
        Public Property ClientName As String = String.Empty
        Public Property DivisionName As String = String.Empty
        Public Property ProductName As String = String.Empty
        Public Property JobDisplay As String = String.Empty
        Public Property AssignmentDisplay As String = String.Empty
        Public Property FunctionCategoryDisplay As String = String.Empty
        Public Property NonEditMessage As String = String.Empty

        Public ReadOnly Property EditFlagText As String
            Get
                Dim Text As String = String.Empty
                Select Case EditFlag
                    Case TimesheetEditType.ABFlag
                        Text = "Entry AB flag set."
                    Case TimesheetEditType.Approved
                        Text = "Entry approved."
                    Case TimesheetEditType.Billed
                        Text = "Entry billed."
                    Case TimesheetEditType.Billing
                        Text = "Entry selected for billing."
                    Case TimesheetEditType.Denied
                        Text = "Entry denied."
                    Case TimesheetEditType.Edit
                        Text = ""
                    Case TimesheetEditType.PendingApproval
                        Text = "Entry pending approval."
                    Case TimesheetEditType.Summarized
                        'Text = "Entry summarized."
                        Text = "Entry billed."
                End Select
                Return Text
            End Get
        End Property

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
