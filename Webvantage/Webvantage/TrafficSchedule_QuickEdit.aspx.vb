Public Class TrafficSchedule_QuickEdit
    Inherits Webvantage.BaseChildPage

#Region " Enum "

    Private Enum QueryStringVars
        JobNum
        JobComp
        P
        Role
        Task
        Emp
        Cut
        Pend
        Proj
        Comp
    End Enum

    Private Enum SessionVars
        PS_Ignore_Filter
    End Enum

    Private Enum TreeViewControls
        LabelLevel
        LabelCode
        LabelTaskDescription
        ImageButtonMoveLeft
        ImageButtonMoveRight
        TextBoxJobOrder
    End Enum

#End Region

#Region " Variables "

    Private _JobNumber As Integer = Nothing
    Private _JobComponentNumber As Short = Nothing
    Private _EmployeeCode As String = ""
    Private _TaskCode As String = ""
    Private _RoleCode As String = ""
    Private _IncludeCompletedTasks As Boolean = False
    Private _IncludeOnlyPendingTasks As Boolean = False
    Private _ExcludeProjectedTasks As Boolean = False
    Private _CutOffDate As String = ""
    Private _TaskPhaseFilter As String = ""
    Private _UsingATaskLevelFilter As Boolean = False
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "

    Private ReadOnly Property TaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
        Get

            Dim ScheduleTaskList As Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask) = Nothing

            Try

                If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

                    If _UsingATaskLevelFilter = True AndAlso Session("PS_Ignore_Filter") = "0" Then

                        ScheduleTaskList = AdvantageFramework.ProjectSchedule.GetScheduleTasks(_DbContext, _JobNumber, _JobComponentNumber, "", _Session.UserCode, _EmployeeCode, _TaskCode, _RoleCode, _IncludeCompletedTasks, _IncludeCompletedTasks, _ExcludeProjectedTasks, _CutOffDate, _TaskPhaseFilter, False, False, False, False)

                    Else

                        ScheduleTaskList = AdvantageFramework.ProjectSchedule.GetScheduleTasks(_DbContext, _JobNumber, _JobComponentNumber, "", _Session.UserCode, "", "", "", _IncludeCompletedTasks, False, False, "", "no_filter", False, False, False, False)

                    End If

                End If

            Catch ex As Exception
                ScheduleTaskList = New Generic.List(Of AdvantageFramework.ProjectSchedule.Classes.ScheduleTask)
            End Try

            TaskList = ScheduleTaskList

        End Get
    End Property
    Private Property CalculateByPredecessor As Boolean
        Get
            Try

                CalculateByPredecessor = ViewState("CalculateByPredecessor")

            Catch ex As Exception
                CalculateByPredecessor = False
            End Try
        End Get
        Set(value As Boolean)
            ViewState("CalculateByPredecessor") = value
        End Set
    End Property
    Private Property NodeExpandedList As Generic.Dictionary(Of Short, Boolean)
        Get
            Try

                NodeExpandedList = ViewState("NodeExpandedList")

            Catch ex As Exception
                NodeExpandedList = Nothing
            End Try
        End Get
        Set(value As Generic.Dictionary(Of Short, Boolean))
            ViewState("NodeExpandedList") = value
        End Set
    End Property
    Private Property CanUserEdit As Boolean
        Get
            Try

                CanUserEdit = ViewState("CanUserEdit")

            Catch ex As Exception
                CanUserEdit = True
            End Try
        End Get
        Set(value As Boolean)
            ViewState("CanUserEdit") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub LoadTasks()

        If _JobNumber > 0 AndAlso _JobComponentNumber > 0 Then

            RadTreeViewTasks.DataSource = Me.TaskList
            RadTreeViewTasks.DataBind()

        End If

    End Sub
    Private Sub PerformDragAndDrop(ByVal DropPosition As Telerik.Web.UI.RadTreeViewDropPosition, ByVal SourceNode As Telerik.Web.UI.RadTreeNode, ByVal DestinationNode As Telerik.Web.UI.RadTreeNode)

        'objects
        Dim DropAllowed As Boolean = True
        Dim NodeAbove As Telerik.Web.UI.RadTreeNode = Nothing
        Dim NodeBelow As Telerik.Web.UI.RadTreeNode = Nothing
        Dim NodeAboveJobOrder As Integer? = Nothing
        Dim NodeBelowJobOrder As Integer? = Nothing
        Dim JobOrder As Integer? = Nothing

        If DropPosition = Telerik.Web.UI.RadTreeViewDropPosition.Over AndAlso Me.CalculateByPredecessor = False Then

            DropAllowed = False

        End If

        If DropAllowed Then

            If SourceNode.Equals(DestinationNode) OrElse SourceNode.IsAncestorOf(DestinationNode) Then

                Return

            End If

            SourceNode.Owner.Nodes.Remove(SourceNode)

            Select Case DropPosition

                Case Telerik.Web.UI.RadTreeViewDropPosition.Over

                    If Not SourceNode.IsAncestorOf(DestinationNode) Then

                        DestinationNode.Nodes.Add(SourceNode)

                    End If

                    Exit Select

                Case Telerik.Web.UI.RadTreeViewDropPosition.Above

                    DestinationNode.InsertBefore(SourceNode)

                    Exit Select

                Case Telerik.Web.UI.RadTreeViewDropPosition.Below

                    DestinationNode.InsertAfter(SourceNode)

                    Exit Select

            End Select

            If Me.CalculateByPredecessor = False Then

                Try

                    NodeAbove = SourceNode.TreeView.Nodes(SourceNode.Index - 1)

                Catch ex As Exception

                End Try

                Try

                    NodeBelow = SourceNode.TreeView.Nodes(SourceNode.Index + 1)

                Catch ex As Exception

                End Try

                If NodeAbove IsNot Nothing Then

                    With DirectCast(FindTreeViewControl(NodeAbove, TreeViewControls.TextBoxJobOrder), System.Web.UI.WebControls.TextBox)

                        If String.IsNullOrWhiteSpace(.Text) = False AndAlso IsNumeric(.Text) Then

                            NodeAboveJobOrder = CInt(.Text)

                        End If

                    End With

                End If

                If NodeBelow IsNot Nothing Then

                    With DirectCast(FindTreeViewControl(NodeBelow, TreeViewControls.TextBoxJobOrder), System.Web.UI.WebControls.TextBox)

                        If String.IsNullOrWhiteSpace(.Text) = False AndAlso IsNumeric(.Text) Then

                            NodeBelowJobOrder = CInt(.Text)

                        End If

                    End With

                End If

                If NodeAbove Is Nothing Then

                    'first node
                    If NodeBelowJobOrder.HasValue = True Then

                        JobOrder = NodeBelowJobOrder.GetValueOrDefault(-1) - 1

                    Else

                        JobOrder = Nothing

                    End If

                ElseIf NodeBelow Is Nothing Then

                    'last node
                    If NodeAboveJobOrder.HasValue = True Then

                        JobOrder = NodeAboveJobOrder.GetValueOrDefault(-1) + 1

                    Else

                        JobOrder = Nothing

                    End If

                ElseIf NodeAboveJobOrder.GetValueOrDefault(-1) < NodeBelowJobOrder.GetValueOrDefault(-1) Then

                    JobOrder = NodeAboveJobOrder.GetValueOrDefault(-1) + 1

                ElseIf NodeAboveJobOrder.GetValueOrDefault(-1) = NodeBelowJobOrder.GetValueOrDefault(-1) Then

                    JobOrder = NodeAboveJobOrder

                Else

                    With DirectCast(FindTreeViewControl(DestinationNode, TreeViewControls.TextBoxJobOrder), System.Web.UI.WebControls.TextBox)

                        If String.IsNullOrWhiteSpace(.Text) = False AndAlso IsNumeric(.Text) Then

                            JobOrder = CInt(.Text)

                        Else

                            JobOrder = Nothing

                        End If

                    End With

                End If

                With DirectCast(FindTreeViewControl(SourceNode, TreeViewControls.TextBoxJobOrder), System.Web.UI.WebControls.TextBox)

                    If JobOrder.HasValue Then

                        .Text = JobOrder

                    Else

                        .Text = Nothing

                    End If

                End With

            End If

        End If

    End Sub
    Private Sub UpdateNodeData()

        'objects
        Dim Level As String = Nothing
        Dim LabelLevel As System.Web.UI.WebControls.Label = Nothing
        Dim ImageButtonMoveLeft As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonMoveRight As System.Web.UI.WebControls.ImageButton = Nothing
        Dim CanMoveRight As Boolean = True
        Dim CanMoveLeft As Boolean = True

        For Each RadTreeNode In RadTreeViewTasks.GetAllNodes

            CanMoveRight = True
            CanMoveLeft = True

            ImageButtonMoveLeft = FindTreeViewControl(RadTreeNode, TreeViewControls.ImageButtonMoveLeft)
            ImageButtonMoveRight = FindTreeViewControl(RadTreeNode, TreeViewControls.ImageButtonMoveRight)

            If RadTreeNode.ParentNode IsNot Nothing Then

                Level = DirectCast(FindTreeViewControl(RadTreeNode.ParentNode, TreeViewControls.LabelLevel), System.Web.UI.WebControls.Label).Text & "." & (RadTreeNode.Index + 1).ToString

            Else

                If ImageButtonMoveLeft IsNot Nothing Then

                    CanMoveLeft = False

                End If

                Level = (RadTreeNode.Index + 1).ToString

            End If

            If RadTreeNode.Index = 0 Then

                If ImageButtonMoveRight IsNot Nothing Then

                    CanMoveRight = False

                End If

            End If

            LabelLevel = FindTreeViewControl(RadTreeNode, TreeViewControls.LabelLevel)

            If Me.CalculateByPredecessor = False Then

                CanMoveLeft = False
                CanMoveRight = False

            End If

            ImageButtonMoveLeft.Visible = CanMoveLeft
            ImageButtonMoveRight.Visible = CanMoveRight

            If Me.CanUserEdit = True Then

                ImageButtonMoveLeft.Enabled = True
                ImageButtonMoveRight.Enabled = True

            Else

                ImageButtonMoveLeft.Enabled = False
                ImageButtonMoveRight.Enabled = False

            End If

            LabelLevel.Text = Level

        Next

    End Sub
    Private Sub UpdateOrderAndRefreshData()

        'objects
        Dim TaskList As Generic.List(Of Integer) = New Generic.List(Of Integer)
        Dim FinalString As String = Nothing
        Dim StringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
        Dim Counter As Integer = 0
        Dim UpdateString As String = Nothing
        Dim ParentSequenceNumber As Short? = Nothing
        Dim Rebind As Boolean = False
        Dim JobOrderString As String = Nothing
        Dim ParentTaskSequenceNumbers As Generic.List(Of Short) = New Generic.List(Of Short)

        For Each RadTreeNode In RadTreeViewTasks.GetAllNodes

            If RadTreeNode.ParentNode IsNot Nothing Then

                ParentSequenceNumber = CShort(RadTreeNode.ParentNode.Value)

            Else

                ParentSequenceNumber = Nothing

            End If

            If Me.CalculateByPredecessor = False Then

                JobOrderString = DirectCast(FindTreeViewControl(RadTreeNode, TreeViewControls.TextBoxJobOrder), System.Web.UI.WebControls.TextBox).Text

                If String.IsNullOrWhiteSpace(JobOrderString) = True Then

                    JobOrderString = "NULL"

                End If

            Else

                If ParentSequenceNumber.HasValue Then

                    ParentTaskSequenceNumbers.Add(ParentSequenceNumber.Value)

                End If

                JobOrderString = "JOB_ORDER"

            End If

            StringBuilder.Append(String.Format("UPDATE dbo.JOB_TRAFFIC_DET SET GRID_ORDER = {0}, PARENT_TASK_SEQ = {1}, JOB_ORDER = {2} WHERE JOB_NUMBER = {3} AND JOB_COMPONENT_NBR = {4} AND SEQ_NBR = {5};",
                                                Counter,
                                                If(ParentSequenceNumber.HasValue, ParentSequenceNumber.Value, "NULL"),
                                                JobOrderString,
                                                _JobNumber,
                                                _JobComponentNumber,
                                                CInt(RadTreeNode.Value)))

            Counter = Counter + 1

        Next

        UpdateString = StringBuilder.ToString

        Try

            _DbContext.Database.ExecuteSqlCommand(UpdateString)

            If Me.CalculateByPredecessor = True Then

                If ParentTaskSequenceNumbers.Count > 0 Then

                    _DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.JOB_TRAFFIC_DET_PREDS WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND (SEQ_NBR IN ({2}) OR PREDECESSOR_SEQ_NBR IN ({2}));", _JobNumber, _JobComponentNumber, String.Join(",", ParentTaskSequenceNumbers)))

                End If

            End If

        Catch ex As Exception
            Rebind = True
        End Try

        If Rebind Then 'save failed

            LoadTasks()

        Else 'save successful, modify layout

            UpdateNodeData()

        End If

    End Sub
    Private Sub SetQueryStringVariables()

        'objects
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        Try

            If IsNumeric(GetQueryStringVariable(QueryStringVars.JobNum)) Then

                _JobNumber = CType(GetQueryStringVariable(QueryStringVars.JobNum), Integer)

            End If

        Catch ex As Exception
            _JobNumber = 0
        End Try

        Try

            If IsNumeric(GetQueryStringVariable(QueryStringVars.JobComp)) Then

                _JobComponentNumber = CType(GetQueryStringVariable(QueryStringVars.JobComp), Integer)

            End If

        Catch ex As Exception
            _JobComponentNumber = 0
        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.P) = Nothing Then

                _TaskPhaseFilter = GetQueryStringVariable(QueryStringVars.P).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Role) = Nothing Then

                _RoleCode = GetQueryStringVariable(QueryStringVars.Role).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Task) = Nothing Then

                _TaskCode = GetQueryStringVariable(QueryStringVars.Task).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Emp) = Nothing Then

                _EmployeeCode = GetQueryStringVariable(QueryStringVars.Emp).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Cut) = Nothing Then

                _CutOffDate = GetQueryStringVariable(QueryStringVars.Cut).ToString()

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Pend) = Nothing Then

                _IncludeOnlyPendingTasks = CType(GetQueryStringVariable(QueryStringVars.Pend).ToString(), Boolean)

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Proj) = Nothing Then

                _ExcludeProjectedTasks = CType(GetQueryStringVariable(QueryStringVars.Proj).ToString(), Boolean)

            End If

        Catch ex As Exception

        End Try

        Try

            If Not GetQueryStringVariable(QueryStringVars.Comp) = Nothing Then

                _IncludeCompletedTasks = CType(GetQueryStringVariable(QueryStringVars.Comp).ToString(), Boolean)

            End If

        Catch ex As Exception

        End Try

        Try

            If Session(Me.SessionVars.PS_Ignore_Filter.ToString) = Nothing Then

                Session(Me.SessionVars.PS_Ignore_Filter.ToString) = "0"

            End If

        Catch ex As Exception

        End Try

        'Clean up old querystring names by letting clean qs class override
        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        If QueryString.JobNumber > 0 Then

            _JobNumber = QueryString.JobNumber

        End If

        If QueryString.JobComponentNumber > 0 Then

            _JobComponentNumber = QueryString.JobComponentNumber

        End If

        If QueryString.PhaseFilter <> "" Then

            _TaskPhaseFilter = QueryString.PhaseFilter

        End If

        If QueryString.RoleCode <> "" Then

            _RoleCode = QueryString.RoleCode

        End If

        If QueryString.TaskCode <> "" Then

            _TaskCode = QueryString.TaskCode

        End If

        If QueryString.EmployeeCode <> "" Then

            _EmployeeCode = QueryString.EmployeeCode

        End If

        If QueryString.CutOffDate <> "" Then

            _CutOffDate = QueryString.CutOffDate

        End If

        If QueryString.IncludeOnlyPendingTasks = True Then

            _IncludeOnlyPendingTasks = QueryString.IncludeOnlyPendingTasks

        End If

        If QueryString.ExcludeProjectedTasks = True Then

            _ExcludeProjectedTasks = QueryString.ExcludeProjectedTasks

        End If

        If QueryString.IncludeCompletedTasks = True Then

            _IncludeCompletedTasks = QueryString.IncludeCompletedTasks

        End If

        If _TaskPhaseFilter <> "no_filter" AndAlso _TaskPhaseFilter <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _RoleCode.Trim <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _TaskCode.Trim <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _EmployeeCode.Trim <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _CutOffDate.Trim <> "" Then

            _UsingATaskLevelFilter = True

        End If

        If _IncludeOnlyPendingTasks = True Then

            _UsingATaskLevelFilter = True

        End If

        If _ExcludeProjectedTasks = True Then

            _UsingATaskLevelFilter = True

        End If

        If _IncludeCompletedTasks = True Then

            '_UsingATaskLevelFilter = True

        End If

    End Sub
    Private Function GetQueryStringVariable(ByVal QueryStringVar As QueryStringVars) As Object

        'objects
        Dim Value As Object = Nothing

        Try

            If Request.QueryString(QueryStringVar.ToString) IsNot Nothing Then

                Value = Request.QueryString(QueryStringVar.ToString)

            End If

        Catch ex As Exception
            Value = Nothing
        Finally
            GetQueryStringVariable = Value
        End Try

    End Function
    Private Sub SaveNodeExpandedList()

        'objects
        Dim ExpandedList As Generic.Dictionary(Of Short, Boolean) = Nothing

        If RadTreeViewTasks.Nodes IsNot Nothing AndAlso RadTreeViewTasks.Nodes.Count > 0 Then

            ExpandedList = New Generic.Dictionary(Of Short, Boolean)

            For Each RadTreeNode In RadTreeViewTasks.GetAllNodes.OfType(Of Telerik.Web.UI.RadTreeNode)()

                ExpandedList.Add(CShort(RadTreeNode.Value), RadTreeNode.Expanded)

            Next

        End If

        Me.NodeExpandedList = ExpandedList

    End Sub
    Private Sub ApplyNodeExpandedList()

        'objects
        Dim ExpandAll As Boolean = False
        Dim Expand As Boolean = False

        If RadTreeViewTasks.Nodes IsNot Nothing AndAlso RadTreeViewTasks.Nodes.Count > 0 Then

            If Me.NodeExpandedList Is Nothing OrElse Me.NodeExpandedList.Count = 0 Then

                ExpandAll = True

            End If

            For Each RadTreeNode In RadTreeViewTasks.GetAllNodes.OfType(Of Telerik.Web.UI.RadTreeNode)()

                If ExpandAll Then

                    ExpandOrCollapseNode(RadTreeNode, True)

                Else

                    Try

                        Expand = Me.NodeExpandedList(CShort(RadTreeNode.Value))

                    Catch ex As Exception
                        Expand = False
                    End Try

                    ExpandOrCollapseNode(RadTreeNode, Expand)

                End If

            Next

        End If

    End Sub
    Private Sub ExpandOrCollapseNode(ByVal RadTreeNode As Telerik.Web.UI.RadTreeNode, ByVal Expand As Boolean)

        RadTreeNode.Expanded = Expand

        If Expand = True Then

            RadTreeNode.ExpandChildNodes()

        Else

            RadTreeNode.CollapseChildNodes()

        End If

    End Sub
    Private Function FindTreeViewControl(ByVal RadTreeNode As Telerik.Web.UI.RadTreeNode, ByVal TreeViewControl As TreeViewControls) As System.Web.UI.WebControls.WebControl

        'objects
        Dim WebControl As System.Web.UI.WebControls.WebControl = Nothing

        Try

            If RadTreeNode IsNot Nothing Then

                WebControl = RadTreeNode.FindControl(TreeViewControl.ToString)

            End If

        Catch ex As Exception
            WebControl = Nothing
        Finally
            FindTreeViewControl = WebControl
        End Try

    End Function
    Private Sub SetUserPermissions()

        CanUserEdit = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule), True, False)

        If Me.CanUserEdit Then

            RadTreeViewTasks.EnableDragAndDrop = True
            RadTreeViewTasks.EnableDragAndDropBetweenNodes = True

        Else

            RadTreeViewTasks.EnableDragAndDrop = False
            RadTreeViewTasks.EnableDragAndDropBetweenNodes = False

        End If

    End Sub

#Region "  Page Methods "

    Private Sub TrafficSchedule_QuickEdit_Init(sender As Object, e As EventArgs) Handles Me.Init

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        SetQueryStringVariables()

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing
        Dim Validator As Webvantage.cValidations = Nothing

        Me.PageTitle = "Project Schedule - Quick Edit"

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule)

        SaveNodeExpandedList()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Validator = New cValidations(_Session.ConnectionString)

            If Validator.ValidateJobCompIsViewable(_Session.UserCode, _JobNumber, _JobComponentNumber) = False Then

                Me.ShowMessage("Access to this job/comp is denied")
                Me.CloseThisWindow()
                Exit Sub

            End If

            SetUserPermissions()

            JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(_DbContext, _JobNumber, _JobComponentNumber)

            If JobTraffic IsNot Nothing Then

                If JobTraffic.ScheduleCalculation.GetValueOrDefault(0) = 1 Then

                    Me.CalculateByPredecessor = True

                Else

                    Me.CalculateByPredecessor = False

                End If

                RadTreeViewTasks.DataFieldID = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.SequenceNumber.ToString
                RadTreeViewTasks.DataValueField = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.SequenceNumber.ToString

                If Me.CalculateByPredecessor = True Then

                    RadTreeViewTasks.OnClientNodeDropping = ""
                    RadTreeViewTasks.DataFieldParentID = AdvantageFramework.ProjectSchedule.Classes.ScheduleTask.Properties.ParentTaskSequenceNumber.ToString

                Else

                    RadTreeViewTasks.OnClientNodeDropping = "CheckDropLocation"
                    RadTreeViewTasks.DataFieldParentID = Nothing

                End If

                LoadTasks()

            End If

        End If

    End Sub
    Private Sub TrafficSchedule_QuickEdit_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region " Event Handlers "

    Private Sub RadTreeViewTasks_NodeDrop(sender As Object, e As Telerik.Web.UI.RadTreeNodeDragDropEventArgs) Handles RadTreeViewTasks.NodeDrop

        If e.DestDragNode IsNot Nothing Then

            If e.SourceDragNode.TreeView.SelectedNodes.Count <= 1 Then

                PerformDragAndDrop(e.DropPosition, e.SourceDragNode, e.DestDragNode)

            ElseIf e.SourceDragNode.TreeView.SelectedNodes.Count > 0 Then

                If e.DropPosition = Telerik.Web.UI.RadTreeViewDropPosition.Below Then

                    For I As Integer = e.SourceDragNode.TreeView.SelectedNodes.Count - 1 To 0 Step -1

                        PerformDragAndDrop(e.DropPosition, e.SourceDragNode.TreeView.SelectedNodes(I), e.DestDragNode)

                    Next

                Else

                    For Each RadTreeNode As Telerik.Web.UI.RadTreeNode In e.SourceDragNode.TreeView.SelectedNodes

                        PerformDragAndDrop(e.DropPosition, RadTreeNode, e.DestDragNode)

                    Next

                End If

                e.DestDragNode.Expanded = True
                e.SourceDragNode.TreeView.UnselectAllNodes()

            End If

            UpdateOrderAndRefreshData()

        End If

    End Sub
    Private Sub RadTreeViewTasks_PreRender(sender As Object, e As EventArgs) Handles RadTreeViewTasks.PreRender

        UpdateNodeData()
        ApplyNodeExpandedList()

    End Sub
    Protected Sub ImageButtonMoveLeft_Click(sender As Object, e As ImageClickEventArgs)

        'objects
        Dim RadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing
        Dim ParentRadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing

        Try

            RadTreeNode = DirectCast(DirectCast(sender, System.Web.UI.WebControls.ImageButton).Parent, Telerik.Web.UI.RadTreeNode)

        Catch ex As Exception

        End Try

        If RadTreeNode IsNot Nothing Then

            If RadTreeNode.ParentNode IsNot Nothing Then

                ParentRadTreeNode = RadTreeNode.ParentNode

                If ParentRadTreeNode IsNot Nothing Then

                    PerformDragAndDrop(Telerik.Web.UI.RadTreeViewDropPosition.Below, RadTreeNode, ParentRadTreeNode)

                    ParentRadTreeNode.Expanded = True
                    RadTreeNode.TreeView.UncheckAllNodes()

                    UpdateOrderAndRefreshData()

                End If

            End If

        End If

    End Sub
    Protected Sub ImageButtonMoveRight_Click(sender As Object, e As ImageClickEventArgs)

        'objects
        Dim RadTreeNode As Telerik.Web.UI.RadTreeNode = Nothing
        Dim SiblingTreeNode As Telerik.Web.UI.RadTreeNode = Nothing

        Try

            RadTreeNode = DirectCast(DirectCast(sender, System.Web.UI.WebControls.ImageButton).Parent, Telerik.Web.UI.RadTreeNode)

        Catch ex As Exception

        End Try

        If RadTreeNode IsNot Nothing Then

            Try

                SiblingTreeNode = RadTreeNode.Owner.Nodes(RadTreeNode.Index - 1)

            Catch ex As Exception

            End Try

            If SiblingTreeNode IsNot Nothing Then

                PerformDragAndDrop(Telerik.Web.UI.RadTreeViewDropPosition.Over, RadTreeNode, SiblingTreeNode)

                SiblingTreeNode.Expanded = True
                RadTreeNode.TreeView.UncheckAllNodes()

                UpdateOrderAndRefreshData()

            End If

        End If

    End Sub

#End Region

#End Region

End Class