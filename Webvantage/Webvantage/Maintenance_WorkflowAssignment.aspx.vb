Public Class Maintenance_WorkflowAssignment
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Private Property _CurrentPageNumber As Integer = 0
    Private Property _CurrentNumberOfPages As Integer = 0

#End Region

#Region " Variables "

    Protected WithEvents RadComboBoxGroupBy As Global.Telerik.Web.UI.RadComboBox
    Private _HasAllStatesEntry As Boolean = False

#End Region

#Region " Page "

    Private Sub Maintenance_WorkflowAssignment_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.RadComboBoxGroupBy = CType(Me.RadToolBarMaintenanceWorkflowAssignmentMaintenance.FindItemByValue("RadToolBarButtonRadComboBoxGroupBy").FindControl("RadComboBoxGroupBy"), Telerik.Web.UI.RadComboBox)

    End Sub
    Private Sub Maintenance_WorkflowAssignment_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.LoadOptions()

        Else

            Select Case Me.EventTarget
                Case "RebindGrid"

                    Me.RadGridWorkflowAssignments.Rebind()

            End Select

        End If

    End Sub

#End Region

#Region " Controls "

    Private Sub CheckBoxDontChangeEmployee_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDontChangeEmployee.CheckedChanged

        Dim s As String = ""
        Dim asm As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)

        If asm.UpdateValue(AdvantageFramework.Agency.Settings.AUTO_ASSGN_KEEP_EMP, If(Me.CheckBoxDontChangeEmployee.Checked = True, 1, 0), s) = False Then

            Me.ShowMessage(s)

        End If

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim Data As Generic.List(Of AdvantageFramework.Database.Entities.WorkflowAlertState)
            Data = Nothing

            Data = AdvantageFramework.Database.Procedures.WorkflowAlertState.Load(DbContext).ToList()

            If Not Data Is Nothing Then

                Dim GridView As GridView = Nothing
                Dim DataView As DataView = Nothing
                Dim dt As DataTable = Nothing
                Dim row As DataRow = Nothing

                dt = New DataTable

                dt.Columns.Add("Action")
                dt.Columns.Add("Template")
                dt.Columns.Add("State")
                dt.Columns.Add("Change to State")

                For Each was As AdvantageFramework.Database.Entities.WorkflowAlertState In Data

                    If Not was Is Nothing Then

                        row = dt.NewRow

                        row(0) = was.Workflow.Name
                        row(1) = was.AlertAssignmentTemplate.Name
                        row(2) = If(was.AlertState Is Nothing, "All", was.AlertState.Name)
                        row(3) = was.EndAlertState.Name

                        dt.Rows.Add(row)

                    End If

                Next

                'AdvantageFramework.Web.Exporting.ToExcel("Automated_Assignments.xls", GridView)  <--- This doesn' work
                Me.DeliverGrid(dt, "Automated_Assignments") '<--- This does, please don't change unless you test!!!!

            End If

        End Using

    End Sub

    Protected Sub RadComboBoxTemplateState_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)

        Dim AvailableTemplateStatesRadComboBox As Telerik.Web.UI.RadComboBox = CType(sender, Telerik.Web.UI.RadComboBox)

        If Not AvailableTemplateStatesRadComboBox Is Nothing Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = CType(sender, Telerik.Web.UI.RadComboBox).Parent.Parent

            If Not CurrentGridRow Is Nothing Then

                Dim ID As Integer = CurrentGridRow.GetDataKeyValue("ID")
                Dim WorkflowID As Integer = CurrentGridRow.GetDataKeyValue("WorkflowID")
                Dim AlertAssignmentTemplateID As Integer = CurrentGridRow.GetDataKeyValue("AlertAssignmentTemplateID")
                Dim AlertStateID As Integer = CurrentGridRow.GetDataKeyValue("AlertStateID")
                Dim EndAlertStateID As Integer = AvailableTemplateStatesRadComboBox.SelectedItem.Value

                If AvailableTemplateStatesRadComboBox.SelectedIndex > 0 Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                        Dim CurrentWorkflowState As New AdvantageFramework.Database.Entities.WorkflowAlertState
                        CurrentWorkflowState = Nothing

                        CurrentWorkflowState = AdvantageFramework.Database.Procedures.WorkflowAlertState.LoadByID(DbContext, ID)

                        If CurrentWorkflowState Is Nothing Then

                            Dim NewWorkflowAlertState As New AdvantageFramework.Database.Entities.WorkflowAlertState

                            NewWorkflowAlertState.WorkflowID = WorkflowID
                            NewWorkflowAlertState.AlertAssignmentTemplateID = AlertAssignmentTemplateID
                            NewWorkflowAlertState.AlertStateID = AlertStateID
                            NewWorkflowAlertState.EndAlertAssignmentTemplateID = AlertAssignmentTemplateID
                            NewWorkflowAlertState.EndAlertStateID = AvailableTemplateStatesRadComboBox.SelectedItem.Value
                            NewWorkflowAlertState.AllowAlertDemotion = False

                            If AdvantageFramework.Database.Procedures.WorkflowAlertState.Insert(DbContext, NewWorkflowAlertState) = True Then

                                Me.RadGridWorkflowAssignments.Rebind()

                            End If

                        Else

                            CurrentWorkflowState.EndAlertStateID = AvailableTemplateStatesRadComboBox.SelectedItem.Value

                            If AdvantageFramework.Database.Procedures.WorkflowAlertState.Update(DbContext, CurrentWorkflowState) = True Then

                                Me.RadGridWorkflowAssignments.Rebind()

                            End If

                        End If

                    End Using

                End If

            End If

        End If

    End Sub
    Private Sub RadComboBoxGroupBy_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxGroupBy.SelectedIndexChanged

        Me.RadGridWorkflowAssignments.Rebind()

    End Sub

    Private Sub RadGridWorkflowAssignments_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridWorkflowAssignments.ItemCommand

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item

            If Not CurrentGridRow Is Nothing Then

                Dim ID As Integer = CurrentGridRow.GetDataKeyValue("ID")
                Dim WorkflowID As Integer = CurrentGridRow.GetDataKeyValue("WorkflowID")
                Dim AlertAssignmentTemplateID As Integer = CurrentGridRow.GetDataKeyValue("AlertAssignmentTemplateID")
                Dim AlertStateID As Integer = CurrentGridRow.GetDataKeyValue("AlertStateID")

                Select Case e.CommandName

                    Case "DeleteRow"
                        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                            AdvantageFramework.Database.Procedures.WorkflowAlertState.Delete(DbContext, WorkflowID, AlertAssignmentTemplateID, AlertStateID)
                            Me.RadGridWorkflowAssignments.Rebind()

                        End Using

                End Select

            End If

        End If

    End Sub
    Private Sub RadGridWorkflowAssignments_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridWorkflowAssignments.ItemDataBound

        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item

                If Not CurrentGridRow Is Nothing Then

                    Dim CurrentWorkflowAlertState As New AdvantageFramework.Database.Entities.WorkflowAlertState

                    CurrentWorkflowAlertState = CurrentGridRow.DataItem

                    If Not CurrentWorkflowAlertState Is Nothing Then

                        Dim AvailableStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing
                        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                            AvailableStates = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, CurrentWorkflowAlertState.AlertAssignmentTemplateID).ToList()

                        End Using

                        Dim StatesRadComboBox As New Telerik.Web.UI.RadComboBox
                        StatesRadComboBox = e.Item.FindControl("RadComboBoxTemplateState")

                        If Not StatesRadComboBox Is Nothing Then

                            StatesRadComboBox.Items.Clear()

                            ''StatesRadComboBox.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))

                            StatesRadComboBox.DataSource = AvailableStates
                            StatesRadComboBox.DataTextField = "Name"
                            StatesRadComboBox.DataValueField = "ID"
                            StatesRadComboBox.DataBind()

                        End If
                        If Not CurrentWorkflowAlertState.EndAlertStateID Is Nothing Then

                            MiscFN.RadComboBoxSetIndex(StatesRadComboBox, CurrentWorkflowAlertState.EndAlertStateID, False)

                        End If
                        If CurrentWorkflowAlertState.AlertState Is Nothing Then

                            CurrentGridRow("GridBoundColumnState").Text = "All*"
                            If Me._HasAllStatesEntry = False Then Me._HasAllStatesEntry = True

                        End If

                        Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton
                        DeleteImageButton = CurrentGridRow.FindControl("ImageButtonDelete")

                        If Not DeleteImageButton Is Nothing Then

                            DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
                            DeleteImageButton.CommandArgument = CurrentGridRow.GetDataKeyValue("ID")

                        End If

                    End If

                End If

            Case Telerik.Web.UI.GridItemType.Footer

                Me.LabelAllStatesMessage.Visible = Me._HasAllStatesEntry

        End Select

    End Sub
    Private Sub RadGridWorkflowAssignments_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridWorkflowAssignments.NeedDataSource

        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim list As Generic.List(Of AdvantageFramework.Database.Entities.WorkflowAlertState)
            list = Nothing

            list = AdvantageFramework.Database.Procedures.WorkflowAlertState.Load(DbContext).Include("Workflow").Include("AlertAssignmentTemplate").Include("AlertState").ToList

            If Not list Is Nothing Then

                Me.RadGridWorkflowAssignments.DataSource = list

            End If

        End Using

        If Not Me.RadComboBoxGroupBy Is Nothing AndAlso Not Me.RadComboBoxGroupBy.SelectedItem Is Nothing Then

            Select Case Me.RadComboBoxGroupBy.SelectedItem.Value
                Case "None"

                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnTemplate").Display = True
                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnState").Display = True
                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnWorkflow").Display = True

                    Me.RadGridWorkflowAssignments.MasterTableView.GroupByExpressions.Clear()


                Case "ViewByTemplateState"

                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnTemplate").Display = False
                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnState").Display = False
                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnWorkflow").Display = True

                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("AlertAssignmentTemplate.Name Template Group By AlertAssignmentTemplate.Name")
                    Dim GrpExpr1 As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("AlertState.Name State Group By AlertState.Name")

                    With Me.RadGridWorkflowAssignments

                        .MasterTableView.GroupByExpressions.Clear()

                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        '.MasterTableView.GroupByExpressions.Add(GrpExpr1)

                        .MasterTableView.GroupsDefaultExpanded = True

                    End With

                Case "ViewByAction"

                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnTemplate").Display = True
                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnState").Display = True
                    Me.RadGridWorkflowAssignments.MasterTableView.GetColumn("GridBoundColumnWorkflow").Display = False

                    Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("Workflow.Name Action Group By Workflow.Name")

                    With Me.RadGridWorkflowAssignments

                        .MasterTableView.GroupByExpressions.Clear()
                        .MasterTableView.GroupByExpressions.Add(GrpExpr)
                        .MasterTableView.GroupsDefaultExpanded = True

                    End With

            End Select

        End If

        Me.RadGridWorkflowAssignments.PageSize = MiscFN.LoadPageSize(Me.RadGridWorkflowAssignments.ID)

    End Sub
    Private Sub RadGridWorkflowAssignments_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridWorkflowAssignments.PageIndexChanged

        Me._CurrentPageNumber = e.NewPageIndex
        Me.RadGridWorkflowAssignments.Rebind()

    End Sub

    Private Sub RadGridWorkflowAssignments_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridWorkflowAssignments.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridWorkflowAssignments.ID, e.NewPageSize)
    End Sub
    Private Sub RadGridWorkflowAssignments_PreRender(sender As Object, e As EventArgs) Handles RadGridWorkflowAssignments.PreRender

        Try

            Me._CurrentNumberOfPages = Me.RadGridWorkflowAssignments.PageCount

            If Me._CurrentPageNumber <= Me._CurrentNumberOfPages Then

                Me.RadGridWorkflowAssignments.CurrentPageIndex = Me._CurrentPageNumber

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RadTabStripWorkflowAssignmentOptions_TabClick(sender As Object, e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripWorkflowAssignmentOptions.TabClick

    End Sub
    Private Sub RadToolBarMaintenanceWorkflowAssignmentMaintenance_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarMaintenanceWorkflowAssignmentMaintenance.ButtonClick

        Select Case e.Item.Value
            Case "Add"

                Dim qs As New AdvantageFramework.Web.QueryString()
                With qs

                    .Page = "Maintenance_AlertAssignments_StateWorkflow.aspx"
                    .Add("pm", CType(Webvantage.Maintenance_AlertAssignments_StateWorkflow.PageMode.SelectTemplateState, Integer))

                End With

                Me.OpenWindow(qs, "Automated Assignments")


        End Select

    End Sub

#End Region

#Region " Methods "

    Private Sub LoadOptions()

        Dim asm As New AdvantageFramework.Web.AgencySettings.Methods(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current)

        Me.CheckBoxDontChangeEmployee.Checked = asm.GetValue(AdvantageFramework.Agency.Settings.AUTO_ASSGN_KEEP_EMP, "") = "1"

    End Sub

#End Region

End Class
