Namespace ProjectManagement.Agile.Classes

    <Serializable()>
    Public Class ProjectBoard

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum SwimLaneKey

            None = 0
            ClientName = 1
            JobName = 2
            FullName = 3

            AlertAndAssignments = 4

        End Enum
        Public Enum HardCodedColumn

            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("1", "To Do")>
            'ToDo
            '<AdvantageFramework.EnumUtilities.Attributes.EnumObject("2", "Completed")>
            'Completed
            Backlog = -1
            Completed = -2
            Available_States = -3

        End Enum
        Public Enum LoadBy

            SprintID
            EmployeeCode
            JobComponent

        End Enum
        Public Enum AllowedType

            Tasks = 1
            Assignments = 2
            TasksAndAssignments = 3
            AlertsAndAssignments = 4

        End Enum


        Public Enum FilterTypes

            [None]
            Client
            JobComponent
            Assignee
            AlertState
            AlertType

        End Enum

#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "

        Public Property SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing
        Public Property Board As AdvantageFramework.Database.Entities.Board = Nothing

        Public Property ShowSwimLaneBy As SwimLaneKey = SwimLaneKey.None
        Public Property BoardID As Integer?
        Public Property BoardHeaderID As Integer?
        Public Property SprintHeaderID As Integer?
        Public Property JobNumber As Integer?
        Public Property JobComponentNumber As Short?
        Public Property EmployeeCode As String = String.Empty

        Public Property JobDescription As String = String.Empty
        Public Property JobComponentDescription As String = String.Empty

        Public Property LoadDataBy As LoadBy = LoadBy.SprintID
        Public Property Allowed As AllowedType = AllowedType.TasksAndAssignments

        Public Property IsEdit As Boolean = False
        Public Property CanEdit As Boolean = True

        Public Property CanUserEdit As Boolean = True
        Public Property CanUserView As Boolean = True
        Public Property CanUserInsert As Boolean = True

        Public Property BoardColumns As Generic.List(Of AdvantageFramework.Database.Entities.BoardColumn) = Nothing
        Public Property StackedColumns As Generic.List(Of StackedColumn) = Nothing
        Public Property SwimLanes As Generic.List(Of AdvantageFramework.Database.Entities.BoardSwimLane) = Nothing
        Public Property Data As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)
        Public Property Filters As Generic.List(Of Filter)

        Public Property IsSequential As Boolean = False
        Public Property ForceAllColumns As Boolean = False

        Public Property TimesheetActive As Boolean = True

        Public ReadOnly Property StateList As String
            Get
                Return Newtonsoft.Json.JsonConvert.SerializeObject(_StateList)
            End Get
        End Property
        Private Property _StateList As Generic.List(Of AlertState)

        Public ReadOnly Property WeekSpan As Integer
            Get
                Dim i As Integer = 0
                Try
                    If SprintHeader IsNot Nothing AndAlso SprintHeader.NumberOfWeeks IsNot Nothing Then
                        i = SprintHeader.NumberOfWeeks
                    End If
                Catch ex As Exception
                    i = -1
                End Try
                Return i
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub Load()

            If Me._Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If SprintHeaderID IsNot Nothing AndAlso SprintHeaderID > 0 Then

                        Me.SprintHeader = Nothing
                        Me.SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintHeaderID(DbContext, SprintHeaderID)

                        If Me.SprintHeader IsNot Nothing Then

                            ''''Me.JobNumber = Me.SprintHeader.JobNumber
                            ''''Me.JobComponentNumber = Me.SprintHeader.JobComponentNumber
                            ' DUE TO CHANGE BY EC:  Me.BoardID = Me.SprintHeader.BoardHeaderID
                            Dim CardList As Generic.List(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard) = Nothing
                            Data = New List(Of TaskAssignmentCard)

                            Me.Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, Me.SprintHeader.BoardID)

                            Try

                                CardList = AdvantageFramework.ProjectManagement.Agile.LoadBoardTaskAssignmentCards(DbContext, SprintHeaderID, Me._Session.UserCode, BacklogSort.None)

                            Catch ex As Exception
                                CardList = Nothing
                            End Try

                            If CardList IsNot Nothing AndAlso CardList.Count > 0 Then

                                For Each c In CardList

                                    c.TsActive = Me.TimesheetActive
                                    Data.Add(c)

                                Next

                            End If

                        End If

                    End If

                    Try

                        Me.BoardHeaderID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT CAST(B.BOARD_HDR_ID AS INT) FROM SPRINT_HDR SH INNER JOIN BOARD B ON SH.BOARD_ID = B.ID WHERE SH.ID = {0};", Me.SprintHeader.ID)).SingleOrDefault

                    Catch ex As Exception
                        Me.BoardHeaderID = Nothing
                    End Try

                    'If Me.BoardHeaderID IsNot Nothing Then

                    '    Me.Header = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, Me.BoardHeaderID)

                    'Else

                    '    Me.Header = New Database.Entities.BoardHeader

                    'End If

                    Me.LoadColumnsAndStackedHeadersForBoard(DbContext)

                End Using

            End If
        End Sub
        Public Sub LoadAlertsAndAssignments()

            'objects
            Dim HighestPriorityBoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing
            Dim HighPriorityBoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing
            Dim NormalPriorityBoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing
            Dim LowPriorityBoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing
            Dim LowestPriorityBoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Data = DbContext.Database.SqlQuery(Of AdvantageFramework.ProjectManagement.Agile.Classes.TaskAssignmentCard)("EXEC [dbo].[advsp_alert_assignment_board];").ToList

                    Catch ex As Exception

                    End Try

                    Me.SprintHeader = New AdvantageFramework.Database.Entities.SprintHeader
                    Me.SprintHeader.Description = "Alerts & Assignments"
                    Me.SprintHeader.Comments = "Alerts & Assignments Board"

                    Me.BoardColumns = New List(Of AdvantageFramework.Database.Entities.BoardColumn)

                    LowestPriorityBoardColumn = New AdvantageFramework.Database.Entities.BoardColumn

                    LowestPriorityBoardColumn.ID = 1
                    LowestPriorityBoardColumn.Name = "Lowest Priority"
                    LowestPriorityBoardColumn.Description = "Lowest Priority"
                    LowestPriorityBoardColumn.ToolTip = "Lowest Priority"
                    LowestPriorityBoardColumn.SequenceNumber = 1

                    Me.BoardColumns.Add(LowestPriorityBoardColumn)

                    LowPriorityBoardColumn = New AdvantageFramework.Database.Entities.BoardColumn

                    LowPriorityBoardColumn.ID = 2
                    LowPriorityBoardColumn.Name = "Low Priority"
                    LowPriorityBoardColumn.Description = "Low Priority"
                    LowPriorityBoardColumn.ToolTip = "Low Priority"
                    LowPriorityBoardColumn.SequenceNumber = 2

                    Me.BoardColumns.Add(LowPriorityBoardColumn)

                    NormalPriorityBoardColumn = New AdvantageFramework.Database.Entities.BoardColumn

                    NormalPriorityBoardColumn.ID = 3
                    NormalPriorityBoardColumn.Name = "Normal Priority"
                    NormalPriorityBoardColumn.Description = "Normal Priority"
                    NormalPriorityBoardColumn.ToolTip = "Normal Priority"
                    NormalPriorityBoardColumn.SequenceNumber = 3

                    Me.BoardColumns.Add(NormalPriorityBoardColumn)

                    HighPriorityBoardColumn = New AdvantageFramework.Database.Entities.BoardColumn

                    HighPriorityBoardColumn.ID = 4
                    HighPriorityBoardColumn.Name = "High Priority"
                    HighPriorityBoardColumn.Description = "High Priority"
                    HighPriorityBoardColumn.ToolTip = "High Priority"
                    HighPriorityBoardColumn.SequenceNumber = 4

                    Me.BoardColumns.Add(HighPriorityBoardColumn)

                    HighestPriorityBoardColumn = New AdvantageFramework.Database.Entities.BoardColumn

                    HighestPriorityBoardColumn.ID = 5
                    HighestPriorityBoardColumn.Name = "Highest Priority"
                    HighestPriorityBoardColumn.Description = "Highest Priority"
                    HighestPriorityBoardColumn.ToolTip = "Highest Priority"
                    HighestPriorityBoardColumn.SequenceNumber = 5

                    Me.BoardColumns.Add(HighestPriorityBoardColumn)

                End Using

            End If

        End Sub
        'Public Sub __Load()

        '    If Me._Session IsNot Nothing Then

        '        'Me.CanUserView = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
        '        'Me.CanUserEdit = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)
        '        'Me.CanUserInsert = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)

        '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '            Select Case LoadDataBy

        '                Case LoadBy.SprintID

        '                    If SprintHeaderID IsNot Nothing AndAlso SprintHeaderID > 0 Then

        '                        Me.SprintHeader = Nothing
        '                        Me.SprintHeader = AdvantageFramework.Database.Procedures.SprintHeader.LoadBySprintID(DbContext, SprintHeaderID)

        '                        If Me.SprintHeader IsNot Nothing Then

        '                            Me.JobNumber = Me.SprintHeader.JobNumber
        '                            Me.JobComponentNumber = Me.SprintHeader.JobComponentNumber
        '                            Me.BoardID = Me.SprintHeader.BoardHeaderID

        '                            Try

        '                                Data = AdvantageFramework.Database.Procedures.SprintDetail.LoadWithAvailableBySprintID(DbContext, SprintHeaderID)

        '                            Catch ex As Exception
        '                                Data = Nothing
        '                            End Try

        '                        Else

        '                            Me.BoardID = 1

        '                        End If

        '                    Else

        '                        Me.BoardID = 1

        '                    End If

        '                    If SprintHeaderID Is Nothing AndAlso Me.BoardID = 1 Then

        '                        'Create initial sprint
        '                        Try

        '                            If Me.SprintHeader Is Nothing Then

        '                                Me.SprintHeader = New Database.Entities.SprintHeader

        '                                SprintHeader.Description = "Default project board"
        '                                SprintHeader.JobNumber = Me.JobNumber
        '                                SprintHeader.JobComponentNumber = Me.JobComponentNumber
        '                                SprintHeader.BoardHeaderID = 1

        '                                If AdvantageFramework.Database.Procedures.SprintHeader.Insert(DbContext, SprintHeader) = True Then

        '                                    Me.SprintHeaderID = SprintHeader.ID

        '                                End If

        '                            End If

        '                        Catch ex As Exception
        '                            SprintHeaderID = Nothing
        '                        End Try

        '                        If SprintHeaderID IsNot Nothing AndAlso SprintHeaderID > 0 Then

        '                            Try

        '                                Data = AdvantageFramework.Database.Procedures.SprintDetail.LoadWithAvailableBySprintID(DbContext, SprintHeaderID)

        '                            Catch ex As Exception
        '                                Data = Nothing
        '                            End Try

        '                        End If

        '                    End If

        '                    Me.Header = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, Me.BoardID)
        '                    Me.LoadColumnsAndStackedHeadersForBoard(DbContext)

        '                Case LoadBy.EmployeeCode

        '                    If String.IsNullOrWhiteSpace(EmployeeCode) = True Then

        '                        Me.SetNew()

        '                    Else

        '                        Me.BoardID = 1
        '                        Me.SprintHeader = New Database.Entities.SprintHeader

        '                        Try

        '                            Data = AdvantageFramework.Database.Procedures.SprintDetail.LoadAllForEmployee(DbContext, EmployeeCode)

        '                        Catch ex As Exception
        '                            Data = Nothing
        '                        End Try

        '                    End If

        '                    Me.Header = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, Me.BoardID)
        '                    Me.LoadColumnsAndStackedHeadersForBoard(DbContext)

        '                Case LoadBy.JobComponent

        '                    If JobNumber Is Nothing OrElse JobComponentNumber Is Nothing Then

        '                        Me.SetNew()

        '                    Else

        '                        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

        '                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

        '                        If JobComponent IsNot Nothing Then

        '                            Dim AlertTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing

        '                            AlertTemplate = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadByAlertAssignmentTemplateID(DbContext, JobComponent.AlertAssignmentTemplateID)

        '                            If AlertTemplate IsNot Nothing Then

        '                                Me.Header = Nothing
        '                                Me.Header = New Database.Entities.BoardHeader

        '                                Me.Header.ID = AlertTemplate.ID
        '                                Me.Header.Name = AlertTemplate.Name
        '                                Me.Header.CreatedBy = "SYSADM"
        '                                Me.Header.CreatedDate = Today.Date
        '                                Me.Header.IsSystem = True

        '                                Dim AlertStates As New Generic.List(Of AdvantageFramework.Database.Entities.AlertState)

        '                                AlertStates = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, JobComponent.AlertAssignmentTemplateID).ToList

        '                                If AlertStates IsNot Nothing Then

        '                                    Me.Columns = Nothing
        '                                    Me.Columns = New List(Of Database.Entities.BoardColumn)

        '                                    Dim BoardColumn As AdvantageFramework.Database.Entities.BoardColumn = Nothing
        '                                    Dim i As Integer = 0

        '                                    For Each AlertState As AdvantageFramework.Database.Entities.AlertState In AlertStates

        '                                        i += 1
        '                                        BoardColumn = New Database.Entities.BoardColumn

        '                                        BoardColumn.ID = i
        '                                        BoardColumn.BoardHeaderID = Me.Header.ID
        '                                        BoardColumn.Name = AlertState.Name
        '                                        BoardColumn.SequenceNumber = AlertState.SortOrder

        '                                        Me.Columns.Add(BoardColumn)

        '                                        BoardColumn = Nothing

        '                                    Next

        '                                    '''''data
        '                                    ''''Dim Assignments As Generic.List(Of AdvantageFramework.Database.Entities.Alert) = Nothing

        '                                    ''''Assignments = AdvantageFramework.Database.Procedures.Alert.LoadAssignmentsByJobAndComponent(DbContext, JobNumber, JobComponentNumber).ToList

        '                                    ''''If Assignments IsNot Nothing Then

        '                                    ''''    Me.Data = Nothing
        '                                    ''''    Me.Data = New List(Of Database.Entities.SprintDetail)
        '                                    ''''    Dim Card As AdvantageFramework.Database.Entities.SprintDetail = Nothing

        '                                    ''''    i = 0

        '                                    ''''    For Each Assignment As AdvantageFramework.Database.Entities.Alert In Assignments

        '                                    ''''        Card = New Database.Entities.SprintDetail

        '                                    ''''        Card.ID = Assignment.ID
        '                                    ''''        Card.SprintHeaderID = Header.ID
        '                                    ''''        Card.Title = Assignment.Subject
        '                                    ''''        Card.Description = Assignment.EmailBody
        '                                    ''''        Card.BoardColumnID = Assignment.AlertStateID

        '                                    ''''        Me.Data.Add(Card)

        '                                    ''''        Card = Nothing

        '                                    ''''    Next

        '                                    ''''End If

        '                                End If

        '                            End If

        '                        End If

        '                    End If


        '            End Select

        '            '''''Me.SwimLanes = AdvantageFramework.Database.Procedures.BoardSwimLane.LoadByBoardID(DbContext, Me.BoardID).ToList

        '            ''''If Me.Data IsNot Nothing AndAlso Me.Data.Count > 0 Then

        '            ''''    Me.ProcessToDoItems()
        '            ''''    Me.ProcessCompletedItems(DbContext)

        '            ''''End If

        '            If Me.Header Is Nothing Then Me.Header = New Database.Entities.BoardHeader
        '            If Me.Columns Is Nothing Then Me.Columns = New List(Of Database.Entities.BoardColumn)
        '            If Me.StackedColumns Is Nothing Then Me.StackedColumns = New List(Of StackedColumn)
        '            If Me.SwimLanes Is Nothing Then Me.SwimLanes = New List(Of Database.Entities.BoardSwimLane)
        '            If Me.Data Is Nothing Then Me.Data = New List(Of Database.Entities.SprintDetail)

        '            If JobNumber IsNot Nothing AndAlso JobNumber > 0 Then

        '                Dim Job As AdvantageFramework.Database.Entities.Job
        '                Job = Nothing
        '                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

        '                If Job IsNot Nothing Then

        '                    If String.IsNullOrWhiteSpace(Job.Description) = False Then

        '                        JobDescription = Job.Description

        '                    End If

        '                    If JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0 Then

        '                        Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent

        '                        JobComponent = Nothing
        '                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

        '                        If JobComponent IsNot Nothing Then

        '                            If String.IsNullOrWhiteSpace(JobComponent.Description) = False Then

        '                                JobComponentDescription = JobComponent.Description

        '                            End If

        '                        End If

        '                    End If

        '                End If

        '            End If

        '        End Using

        '    Else

        '        Me.SetNew()

        '    End If

        '    If Me.BoardID = 1 Then

        '        If Data Is Nothing Then

        '            Data = New List(Of Database.Entities.SprintDetail)

        '            Dim DemoItem As New Database.Entities.SprintDetail
        '            DemoItem.ID = 0
        '            DemoItem.SprintHeaderID = 0 'need to change this to sprint header!!!
        '            DemoItem.SequenceNumber = 0

        '            Data.Add(DemoItem)

        '        End If

        '    End If

        'End Sub
        Public Sub LoadAsNew()

            SetNew()

        End Sub

        Private Sub ProcessToDoItems()

            'For Each Card As Database.Entities.SprintDetail In Data.FindAll(Function(e) e.BoardColumnID Is Nothing)

            '    Card.BoardColumnID = -1

            'Next

        End Sub
        'Private Sub ProcessCompletedItems(ByRef DbContext As AdvantageFramework.Database.DbContext)

        '    Try
        '        Dim AssignmentDetails As Generic.List(Of Database.Entities.SprintDetail) = Nothing

        '        AssignmentDetails = (From SprintDetail In Me.Data
        '                             Join Assignments In DbContext.GetQuery(Of Database.Entities.Alert)
        '                                                 On SprintDetail.AlertID Equals Assignments.ID
        '                             Where Assignments.AssignmentCompleted IsNot Nothing AndAlso Assignments.AssignmentCompleted = True
        '                             Select SprintDetail).ToList

        '        If AssignmentDetails IsNot Nothing Then

        '            For Each Card As Database.Entities.SprintDetail In AssignmentDetails

        '                'Card.BoardColumnID = -2

        '            Next

        '        End If

        '    Catch ex As Exception
        '    End Try

        'End Sub

        Private Sub LoadColumnsAndStackedHeadersForBoard(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If Me.BoardColumns Is Nothing Then Me.BoardColumns = New List(Of AdvantageFramework.Database.Entities.BoardColumn)
            If Me.StackedColumns Is Nothing Then Me.StackedColumns = New List(Of StackedColumn)
            If Me._StateList Is Nothing Then Me._StateList = New List(Of AlertState)

            Dim DbColumns As Collections.Generic.List(Of AdvantageFramework.Database.Entities.BoardColumn) = Nothing

            DbColumns = AdvantageFramework.Database.Procedures.BoardColumn.LoadByBoardID(DbContext, Me.BoardHeaderID).ToList

            If DbColumns IsNot Nothing Then

                Dim AllDetails As Generic.List(Of AdvantageFramework.Database.Entities.BoardDetail) = Nothing
                Dim ChildCount As Integer = 0
                Dim StackedColumn As StackedColumn = Nothing
                Dim ChildList As Collections.Generic.List(Of AdvantageFramework.Database.Entities.BoardColumn) = Nothing

                Me.AddToDoColumn()

                AllDetails = AdvantageFramework.Database.Procedures.BoardDetail.LoadWithState(DbContext, Me.BoardHeaderID).ToList

                For Each BoardColumn As AdvantageFramework.Database.Entities.BoardColumn In DbColumns

                    If BoardColumn.BoardDetails IsNot Nothing Then

                        BoardColumn.Keys = String.Join(",", (From Entity In BoardColumn.BoardDetails
                                                             Select Entity.AlertStateID).ToList)


                        Dim AlertState As AlertState = Nothing
                        For Each Detail In BoardColumn.BoardDetails

                            AlertState = New AlertState

                            AlertState.AlertStateID = Detail.AlertStateID

                            Try

                                AlertState.Name = (From Entity In AllDetails
                                                   Where Entity.AlertStateID = Detail.AlertStateID
                                                   Select Entity.AlertState.Name).FirstOrDefault '.SingleOrDefault

                            Catch ex As Exception

                                Try

                                    For Each BoardDetail As AdvantageFramework.Database.Entities.BoardDetail In AllDetails

                                        If BoardDetail.AlertStateID = Detail.AlertStateID Then

                                            AlertState.Name = BoardDetail.AlertState.Name
                                            Exit For

                                        End If

                                    Next

                                Catch ex1 As Exception
                                    AlertState.Name = "DUPLICATE STATE"
                                End Try

                            End Try

                            _StateList.Add(AlertState)

                            AlertState = Nothing

                        Next

                    End If

                    ChildCount = 0

                    If BoardColumn.ParentColumnID Is Nothing Then

                        ChildList = Nothing
                        ChildList = (From Entity In DbColumns
                                     Where Entity.ParentColumnID = BoardColumn.ID).ToList

                        If ChildList IsNot Nothing Then

                            ChildCount = ChildList.Count

                            If ChildCount > 0 Then

                                Dim Children As String()
                                Children = (From Entity In ChildList
                                            Select Entity.Name).ToArray

                                StackedColumn = New StackedColumn
                                StackedColumn.Parent = BoardColumn.Name
                                StackedColumn.Children = String.Join(",", Children)

                                Me.StackedColumns.Add(StackedColumn)

                            Else

                                Me.BoardColumns.Add(BoardColumn)

                            End If

                        Else

                            Me.BoardColumns.Add(BoardColumn)

                        End If

                    Else

                        Me.BoardColumns.Add(BoardColumn)

                    End If

                Next

                Me.AddCompletedColumn()

            End If

        End Sub
        Private Sub AddToDoColumn()

            Dim AvailableColumn As New Database.Entities.BoardColumn

            AvailableColumn.ID = -1
            AvailableColumn.Name = HardCodedColumn.Backlog.ToString
            AvailableColumn.Description = "Items available for board"
            AvailableColumn.ToolTip = "Items available for board"
            AvailableColumn.SequenceNumber = 0
            AvailableColumn.BoardHeaderID = Me.BoardID
            AvailableColumn.Keys = "-1"

            Me.BoardColumns.Add(AvailableColumn)

        End Sub
        Private Sub AddCompletedColumn()

            Dim CompletedColumn As New Database.Entities.BoardColumn

            CompletedColumn.ID = -2
            CompletedColumn.Name = HardCodedColumn.Completed.ToString
            CompletedColumn.Description = "Items with completed status"
            CompletedColumn.ToolTip = "Items with completed status"
            CompletedColumn.SequenceNumber = 32000
            CompletedColumn.BoardHeaderID = Me.BoardID
            CompletedColumn.Keys = "-2"

            Me.BoardColumns.Add(CompletedColumn)

        End Sub

        Private Sub SetNew()

            SprintHeader = New AdvantageFramework.Database.Entities.SprintHeader
            BoardColumns = New List(Of AdvantageFramework.Database.Entities.BoardColumn)
            StackedColumns = New List(Of StackedColumn)
            SwimLanes = New List(Of AdvantageFramework.Database.Entities.BoardSwimLane)
            Data = New List(Of TaskAssignmentCard)

        End Sub

        Public Sub New(ByVal Session As AdvantageFramework.Security.Session)

            Me._Session = Session

        End Sub
        Sub New()

        End Sub
#End Region

#Region " Classes "

        <Serializable()>
        Public Class AlertState

            Public Property AlertStateID As Integer = 0
            Public Property Name As String = String.Empty

        End Class

        <Serializable()>
        Public Class StackedColumn

            Public Property Parent As String = String.Empty
            Public Property Children As String = String.Empty

        End Class

        <Serializable()>
        Public Class WorkflowTransitions

            Public Property Key As String = String.Empty
            Public Property AllowedTransitions As String = String.Empty

        End Class

        <Serializable()>
        Public Class Filter

            Public Property Label As String
            Public Property Field As String
            Public Property FilterType As FilterTypes
            Public Property Watermark As String
            Public Property Items As IEnumerable

        End Class

#End Region

    End Class

End Namespace
