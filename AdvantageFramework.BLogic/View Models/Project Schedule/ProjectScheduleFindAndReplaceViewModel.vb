Namespace ViewModels.ProjectSchedule

    Public Class ProjectScheduleFindAndReplaceViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SelectedCriteria As String
        Public Property FromDateSearchFor As Date?
        Public Property ToDateSearchFor As Date?
        Public Property DateReplaceWith As Date?
        <StringLength(6)>
        Public Property EmployeeCodeSearchFor As String
        <StringLength(6)>
        Public Property EmployeeCodeReplaceWith As String
        <StringLength(10)>
        Public Property TimeDueSearchFor As String
        <StringLength(10)>
        Public Property TimeDueReplaceWith As String
        <StringLength(10)>
        Public Property TaskCodeSearchFor As String
        <StringLength(6)>
        Public Property ManagerCodeSearchFor As String
        <StringLength(6)>
        Public Property ManagerCodeReplaceWith As String
        <StringLength(6)>
        Public Property ClientContactCodeSearchFor As String
        <StringLength(6)>
        Public Property ClientContactCodeReplaceWith As String
        Public Property TaskStatusSearchFor As String
        Public Property TaskStatusReplaceWith As String
        Public Property ClientCode As String
        Public Property SelectedJobComponents As String
        Public Property TaskCommentReplaceWith As String
        Public Property TaskStatuses As Dictionary(Of String, String)
        Public ReadOnly Property Criterias As Dictionary(Of String, String)
            Get

                'objects
                Dim CriteriaDictionary As Dictionary(Of String, String) = New Dictionary(Of String, String)

                CriteriaDictionary.Add("StartDate", "Start Date")
                CriteriaDictionary.Add("DueDate", "Due Date")
                CriteriaDictionary.Add("TimeDue", "Time Due")
                CriteriaDictionary.Add("CompletedDate", "Completed Date")
                CriteriaDictionary.Add("EmployeeAssignment", "Employee Assignment")

                If String.IsNullOrWhiteSpace(ClientCode) = False Then

                    CriteriaDictionary.Add("ClientContactAssignment", "Client Contact Assignment")

                End If

                CriteriaDictionary.Add("TaskStatus", "Task Status")
                CriteriaDictionary.Add("Manager", "Manager")
                CriteriaDictionary.Add("TaskComment", "Task Comment")
                CriteriaDictionary.Add("HeaderStartDate", "Header Start Date")
                CriteriaDictionary.Add("HeaderDueDate", "Header Due Date")
                CriteriaDictionary.Add("HeaderCompletedDate", "Header Completed Date")

                Return CriteriaDictionary

            End Get
        End Property
        Public Property Log As Generic.List(Of String)

#End Region

#Region " Methods "

        Public Sub New()

            Log = New Generic.List(Of String)
            TaskStatuses = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.ProjectSchedule.TaskStatus)).ToList.ToDictionary(Function(e) e.Code, Function(e) e.Description)

        End Sub

#End Region

    End Class

End Namespace
