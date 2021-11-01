Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class TaskAssignmentCard

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            SprintHeaderID
            SprintDetailID
            TaskSequenceNumber
            AlertID
            SequenceNumber
            JobNumber
            JobComponentNumber
            [Priority]
            StatusID
            EmployeeCode
            Title
            TaskDescription
            BoardColumnID
            BoardColumnStateCount
            [Description]
            CompleteDate
            CreateDate
            LastMovedDate
            FullName
            AssignedEmployeeCode
            AlertTemplateID
            AlertStateID
            AlertStateName
            IsWorkItem
            IsBoardBacklog
            ClientName
            JobName
            StartDate
            DueDate
            CardQueryID
            HoursAllowed
            BoardStateID
            BoardStateName
            IsTask
            AlertCategoryID
            AlertCategoryName
            Indicator
            CardStateName
            TimeDue
            LastModifiedDate
            LastModifiedBy
            MyTaskCompleted
            MyTask
            AssignNumber
            TotalChecklistItems
            TotalCheckedChecklistItems
            IsRead
            ShowChecklists
            ChecklistComplete
            ChecklistTotal
            ShowHours
            HoursAllocated
            HoursTotal

            Assignees

            DisplayPicture
            PriorityColorCode
            DueDateStr

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SprintHeaderID As Integer?
        Public Property SprintDetailID As Integer?
        Public Property TaskSequenceNumber As Short?
        Public Property AlertID As Integer?
        Public Property SequenceNumber As Short?
        Public Property JobNumber As Integer?
        Public Property JobComponentNumber As Short?
        Public Property [Priority] As Short?
        Public Property StatusID As Short?
        Public Property EmployeeCode As String = String.Empty
        Public Property Title As String = String.Empty
        Public Property TaskDescription As String = String.Empty
        Public Property BoardColumnID As Integer?
        Public Property BoardColumnStateCount As Integer?
        Public Property [Description] As String = String.Empty
        Public Property CompleteDate As Date?
        Public Property CreateDate As Date?
        Public Property LastMovedDate As Date?
        Public Property FullName As String = String.Empty
        Public Property AssignedEmployeeCode As String = String.Empty
        Public Property AlertTemplateID As Integer?
        Public Property AlertStateID As Integer?
        Public Property AlertStateName As String = String.Empty
        Public Property IsWorkItem As Boolean?
        Public Property IsBoardBacklog As Boolean?
        Public Property ClientName As String = String.Empty
        Public Property JobName As String = String.Empty
        Public Property StartDate As Date?
        Public Property DueDate As Date?
        Public Property CardQueryID As Integer?
        Public Property HoursAllowed As Decimal?
        Public Property BoardStateID As Integer?
        Public Property BoardStateName As String = String.Empty
        Public Property IsTask As Boolean?
        Public Property AlertCategoryID As Integer
        Public Property AlertCategoryName As String = String.Empty
        Public Property Indicator As String = String.Empty
        Public ReadOnly Property CardStateName As String
            Get
                'objects
                Dim CardStates As Generic.List(Of String) = New Generic.List(Of String)

                If Me.BoardColumnID = -2 Then

                    CardStates.Add("Completed")

                Else

                    If Not String.IsNullOrWhiteSpace(Me.BoardStateName) Then

                        CardStates.Add(Me.BoardStateName)

                    End If

                    If Not String.IsNullOrWhiteSpace(Me.AlertStateName) Then

                        CardStates.Add(Me.AlertStateName)

                    End If

                End If

                Return String.Join(", ", CardStates)

            End Get
        End Property
        Public Property TimeDue As String = String.Empty
        Public Property LastModifiedDate As Date?
        Public Property LastModifiedBy As String = String.Empty
        Public Property MyTask As Boolean?
        Public Property MyTaskCompleted As Boolean?
        Public Property TotalChecklistItems As Short?
        Public Property TotalCheckedItems As Short?
        Public Property AssignNumber As Integer?
        Public Property IsRead As Boolean?

        Public Property ShowChecklists As Boolean?
        Public Property ChecklistComplete As Integer?
        Public Property ChecklistTotal As Integer?

        Public Property ShowHours As Boolean?
        Public Property HoursAllocated As Decimal?
        Public Property HoursTotal As Decimal?
        Public Property CurrentBoardStateID As Integer?
        Public Property IsAutoRoute As Boolean? = False

        Public Property Assignees As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.CardAssignee)

        Public ReadOnly Property DisplayPictrue As String
            Get
                Return String.Empty
            End Get
        End Property
        Public ReadOnly Property PriorityColorCode As String
            Get

                Dim ColorCode As String = "#00BCD4"

                If Priority Is Nothing Then Priority = 3

                Select Case Priority
                    Case 1

                        ColorCode = "#E53935"

                    Case 2

                        ColorCode = "#FF9800"

                    Case 3

                        ColorCode = "#00BCD4"

                    Case 4

                        ColorCode = "#1976D2"

                    Case 5

                        ColorCode = "#0D47A1"

                    Case Else

                        ColorCode = "#00BCD4"

                End Select

                Return ColorCode

            End Get
        End Property
        Public ReadOnly Property DueDateStr As String
            Get
                'objects
                Dim Str As String = Nothing
                If Me.DueDate.HasValue Then
                    Str = Me.DueDate.Value.ToShortDateString()
                End If
                Return Str
            End Get
        End Property
        Public ReadOnly Property DueDateCSS As String
            Get
                Dim CSS As String = String.Empty
                Try
                    If Me.DueDate.HasValue AndAlso Me.DueDate < Today.Date Then
                        CSS = "task-due-overdue"
                    End If
                Catch ex As Exception
                    CSS = String.Empty
                End Try
                Return CSS
            End Get
        End Property
        Public ReadOnly Property DueDateToolTip As String
            Get
                Dim ToolTip As String = String.Empty
                Try
                    If Me.DueDate.HasValue AndAlso Me.DueDate < Today.Date Then
                        ToolTip = "Task is over due!"
                    End If
                Catch ex As Exception
                    ToolTip = String.Empty
                End Try
                Return ToolTip
            End Get
        End Property
        Public Property TsActive As Boolean = True

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace