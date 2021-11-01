
Namespace ViewModels.Employee.ExpenseReport

    <Serializable()>
    Public Class ExpenseReportOptionsViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            InvoiceNumber
            EmployeeCode
            EmployeeFullName
            EmployeeSupervisorApprovalRequired
            SupervisorEmployeeCode
            SupervisorEmployeeFullName
            AlternateApproverEmployeeCode
            AlternateApproverEmployeeFullName
            IncludeReceiptsInEmailAndAlert
            AvailableApprovers

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property InvoiceNumber As Integer = 0
        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeFullName As String = String.Empty
        Public Property EmployeeSupervisorApprovalRequired As Boolean = False
        Public Property SupervisorEmployeeCode As String = String.Empty
        Public Property SupervisorEmployeeFullName As String = String.Empty
        Public Property AlternateApproverEmployeeCode As String = String.Empty
        Public Property AlternateApproverEmployeeFullName As String = String.Empty
        Public Property IncludeReceiptsInEmailAndAlert As Boolean = False

        Public Property AvailableApprovers As Generic.List(Of AvailableApprover) = Nothing

#End Region

#Region " Methods "

        Sub New()

            Me.AvailableApprovers = New List(Of AvailableApprover)

        End Sub

#End Region

    End Class

    <Serializable()>
    Public Class AvailableApprover

        Public Property EmployeeCode As String = String.Empty
        Public Property EmployeeFullName As String = String.Empty

        Sub New()

        End Sub

    End Class

End Namespace
