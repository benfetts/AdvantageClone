Imports System.Data.SqlClient

Public Class Maintenance_AlertAssignments_StateWorkflow
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum PageMode

        PresetTemplateState = 0
        SelectTemplateState = 1

    End Enum
    Public Enum From

        MainMenu = 0
        AlertAssignmentMaintenance = 1

    End Enum

#End Region

#Region " Properties "

    Private Property _FromPage As Maintenance_AlertAssignments_StateWorkflow.From = From.MainMenu

#End Region

#Region " Variables "

    Private _PageMode As PageMode = PageMode.PresetTemplateState

    Private _TemplateId As Integer = 0
    Private _StateId As Integer = 0

    Private _CurrentWorkflowEvent As AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent
    Private _CurrentWorkflowTemplateID As Integer = 0
    Private _CurrentWorkflowStateID As Integer = 0

    Private _NewWorkflowEvent As AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent
    Private _NewWorkflowTemplateID As Integer = 0
    Private _NewWorkflowStateID As Integer = 0

#End Region

#Region " Page "

    Private Sub Maintenance_AlertAssignments_StateWorkflow_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()

        qs = qs.FromCurrent()

        If IsNumeric(qs.GetValue("pm")) = True Then Me._PageMode = CType(CType(qs.GetValue("pm"), Integer), PageMode)
        If IsNumeric(qs.GetValue("from")) = True Then Me._FromPage = CType(CType(qs.GetValue("from"), Integer), Maintenance_AlertAssignments_StateWorkflow.From)

        Me._TemplateId = qs.AlertTemplateID
        Me._StateId = qs.AlertStateID

        If Me._TemplateId = 0 Or Me._StateId = 0 Then Me._PageMode = PageMode.SelectTemplateState

    End Sub
    Private Sub Maintenance_AlertAssignments_StateWorkflow_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                'Load Workflow events
                Me.RadComboBoxOnAction.Items.Clear()
                Me.RadComboBoxOnAction.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))

                Dim WorkflowList As New Generic.List(Of AdvantageFramework.Database.Entities.Workflow)
                WorkflowList = Nothing
                WorkflowList = AdvantageFramework.Database.Procedures.Workflow.LoadAllActive(DbContext).ToList()

                If Not WorkflowList Is Nothing Then

                    For Each w As AdvantageFramework.Database.Entities.Workflow In WorkflowList

                        Me.RadComboBoxOnAction.Items.Add(New Telerik.Web.UI.RadComboBoxItem(w.Name, w.ID))

                    Next

                End If

                'Load All Available Templates
                Me.RadComboBoxTemplate.Items.Clear()
                Me.RadComboBoxTemplate.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))

                Dim AlertAssignmentTemplates As New Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplate)
                AlertAssignmentTemplates = Nothing
                AlertAssignmentTemplates = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext).ToList()

                If Not AlertAssignmentTemplates Is Nothing Then

                    For Each t As AdvantageFramework.Database.Entities.AlertAssignmentTemplate In AlertAssignmentTemplates

                        Me.RadComboBoxTemplate.Items.Add(New Telerik.Web.UI.RadComboBoxItem(t.Name, t.ID))

                    Next

                End If

                Select Case Me._PageMode
                    Case PageMode.PresetTemplateState

                        ' ''Me.DivPresetTemplateAndState.Visible = True
                        ' ''Me.DivSelectTemplateAndState.Visible = False

                        'Load this template/state
                        Dim CurrentAlertAssignmentTemplate As New AdvantageFramework.Database.Entities.AlertAssignmentTemplate
                        CurrentAlertAssignmentTemplate = Nothing

                        Dim CurrentAlertAssignmentState As New AdvantageFramework.Database.Entities.AlertState
                        CurrentAlertAssignmentState = Nothing

                        CurrentAlertAssignmentTemplate = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadByAlertAssignmentTemplateID(DbContext, Me._TemplateId)
                        CurrentAlertAssignmentState = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertStateID(DbContext, Me._StateId)

                        If Not CurrentAlertAssignmentTemplate Is Nothing AndAlso Not CurrentAlertAssignmentState Is Nothing Then

                            Me._CurrentWorkflowTemplateID = CurrentAlertAssignmentTemplate.ID
                            Me._CurrentWorkflowStateID = CurrentAlertAssignmentState.ID

                            ' ''Me.LabelTemplateState.Text = CurrentAlertAssignmentTemplate.Name & "/" & CurrentAlertAssignmentState.Name

                            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxTemplate, Me._CurrentWorkflowTemplateID, False)

                            Me.LoadRadListBoxAssignmentsWithState(Me._CurrentWorkflowTemplateID)
                            MiscFN.RadListBoxSetIndex(Me.RadListBoxAssignmentsWithState, Me._CurrentWorkflowStateID, False)

                            Me.LoadRadListBoxChangesToState(Me._CurrentWorkflowTemplateID)

                            Me.CheckBoxChangeAllStatesInTemplate.Visible = False

                        End If

                    Case PageMode.SelectTemplateState

                        ' ''Me.DivPresetTemplateAndState.Visible = False
                        ' ''Me.DivSelectTemplateAndState.Visible = True

                        Me.RadListBoxAssignmentsWithState.Items.Clear()
                        Me.RadListBoxAssignmentsWithState.Enabled = False

                End Select

                Me.RadToolBarMaintenanceAlertStateWorkflow.FindItemByValue("Delete").Visible = Me._PageMode = PageMode.PresetTemplateState

            End Using

        End If

    End Sub
    Private Sub Maintenance_AlertAssignments_StateWorkflow_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        If Me.CheckBoxChangeAllStatesInTemplate.Checked = True Then

            Me.RadListBoxAssignmentsWithState.SelectedIndex = -1
            Me.RadListBoxAssignmentsWithState.Enabled = False

        End If

    End Sub

#End Region

#Region " Controls "

    Private Sub CheckBoxChangeAllStatesInTemplate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxChangeAllStatesInTemplate.CheckedChanged

        If Me.CheckBoxChangeAllStatesInTemplate.Checked = False Then

            Me.LoadSettings()
            Me.RadListBoxAssignmentsWithState.Enabled = True

        End If

    End Sub
    Private Sub RadComboBoxAllTemplates_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxTemplate.SelectedIndexChanged

        Me.LoadRadListBoxAssignmentsWithState(Me.RadComboBoxTemplate.SelectedItem.Value)

        Me.RadListBoxAssignmentsWithState.Enabled = Me.RadComboBoxTemplate.SelectedIndex > 0

        Me.LoadRadListBoxChangesToState(Me.RadComboBoxTemplate.SelectedItem.Value)

        If Me.RadComboBoxOnAction.SelectedIndex > 0 Then

            Me.LoadSettings()

        End If

    End Sub
    Private Sub RadComboBoxWorkflowEvents_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxOnAction.SelectedIndexChanged

        Me.LoadSettings()

    End Sub
    Private Sub RadListBoxAllTemplateStates_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadListBoxAssignmentsWithState.SelectedIndexChanged

        Me.LoadSettings()

    End Sub
    Private Sub RadToolBarMaintenanceAlertStateWorkflow_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarMaintenanceAlertStateWorkflow.ButtonClick

        Select Case e.Item.Value
            Case "Save"

                Dim Saved As Boolean = False

                Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    If Me.RadComboBoxOnAction.SelectedIndex = 0 Then

                        Me.ShowMessage("Please select a Workflow Action")
                        Exit Sub

                    End If

                    Me._TemplateId = Me.RadComboBoxTemplate.SelectedItem.Value
                    If Me._TemplateId = 0 Then

                        Me.ShowMessage("Please select a Template")
                        Exit Sub

                    End If

                    If Not Me.RadListBoxAssignmentsWithState.SelectedItem Is Nothing Then Me._StateId = Me.RadListBoxAssignmentsWithState.SelectedItem.Value
                    If Me._StateId = 0 And Me.CheckBoxChangeAllStatesInTemplate.Checked = False Then

                        Me.ShowMessage("Please select a State")
                        Exit Sub

                    End If


                    If Me.RadListBoxChangesToState.SelectedIndex = -1 Then

                        Me.ShowMessage("Please select a Change to State")
                        Exit Sub

                    Else

                        'If Me.RadListBoxChangesToState.SelectedIndex > 0 Then

                        Dim CurrentWorkflowState As New AdvantageFramework.Database.Entities.WorkflowAlertState
                        CurrentWorkflowState = Nothing

                        CurrentWorkflowState = AdvantageFramework.Database.Procedures.WorkflowAlertState.LoadByWorkflowIDAndAlertAssignmentTemplateIDAndStateID(DbContext, Me.RadComboBoxOnAction.SelectedItem.Value,
                                                                                                                                                                Me._TemplateId,
                                                                                                                                                                If(Me._StateId = 0, Nothing, Me._StateId))

                        If CurrentWorkflowState Is Nothing Then

                            Dim NewWorkflowAlertState As New AdvantageFramework.Database.Entities.WorkflowAlertState

                            NewWorkflowAlertState.WorkflowID = Me.RadComboBoxOnAction.SelectedItem.Value
                            NewWorkflowAlertState.AlertAssignmentTemplateID = Me._TemplateId
                            If Me._StateId > 0 Then NewWorkflowAlertState.AlertStateID = Me._StateId
                            NewWorkflowAlertState.EndAlertAssignmentTemplateID = Me._TemplateId
                            NewWorkflowAlertState.EndAlertStateID = Me.RadListBoxChangesToState.SelectedItem.Value
                            NewWorkflowAlertState.AllowAlertDemotion = False
                            NewWorkflowAlertState.ChangeAllStatesInTemplate = Me.CheckBoxChangeAllStatesInTemplate.Checked

                            If AdvantageFramework.Database.Procedures.WorkflowAlertState.Insert(DbContext, NewWorkflowAlertState) = True Then

                                Saved = True

                            End If

                        Else

                            CurrentWorkflowState.EndAlertStateID = Me.RadListBoxChangesToState.SelectedItem.Value
                            CurrentWorkflowState.ChangeAllStatesInTemplate = Me.CheckBoxChangeAllStatesInTemplate.Checked

                            If AdvantageFramework.Database.Procedures.WorkflowAlertState.Update(DbContext, CurrentWorkflowState) = True Then

                                Saved = True

                            End If

                        End If

                        'ElseIf Me.RadListBoxChangesToState.SelectedIndex = 0 Then

                        '    If AdvantageFramework.Database.Procedures.WorkflowAlertState.Delete(DbContext, Me.RadComboBoxOnAction.SelectedItem.Value, _
                        '                                                                            Me._TemplateId, _
                        '                                                                            If(Me._StateId = 0, Nothing, Me._StateId)) = True Then

                        '        Saved = True

                        '    End If

                        'End If

                    End If

                End Using

                If Saved = True Then

                    Select Case Me._PageMode
                        Case PageMode.PresetTemplateState

                            'Me.CloseThisWindow()

                        Case PageMode.SelectTemplateState

                            'Me.RefreshCaller("Maintenance_WorkflowAssignment.aspx")
                            Me.RefreshChildPageGrid("Maintenance_WorkflowAssignment.aspx")

                    End Select

                    Me.LoadSettings()

                Else

                    Me.ShowMessage("Error saving")

                End If

            Case "Delete"

                If Me.RadComboBoxOnAction.SelectedIndex > 0 AndAlso Me.RadComboBoxTemplate.SelectedIndex > 0 AndAlso
                   IsNumeric(Me.RadListBoxAssignmentsWithState.SelectedValue) AndAlso IsNumeric(Me.RadListBoxChangesToState.SelectedValue) Then

                    Me._TemplateId = Me.RadComboBoxTemplate.SelectedItem.Value
                    If Not Me.RadListBoxAssignmentsWithState.SelectedItem Is Nothing Then Me._StateId = Me.RadListBoxAssignmentsWithState.SelectedItem.Value

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                        Dim CurrentWorkflowState As New AdvantageFramework.Database.Entities.WorkflowAlertState
                        CurrentWorkflowState = Nothing

                        If AdvantageFramework.Database.Procedures.WorkflowAlertState.Delete(DbContext, Me.RadComboBoxOnAction.SelectedItem.Value,
                                                                                                Me._TemplateId,
                                                                                                If(Me._StateId = 0, Nothing, Me._StateId)) = True Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_AlertAssignments_StateWorkflow.aspx")

                        Else

                            Me.ShowMessage("Error deleting")

                        End If

                    End Using

                End If

            Case "ViewAllWorkflows"

                Me.OpenWindow("", "Maintenance_WorkflowAssignment.aspx")

        End Select

    End Sub

#End Region

#Region " Methods "

    Private Sub LoadRadListBoxChangesToState(ByVal AlertAssignmentTemplateID As Integer)

        'Load Available States
        Me.RadListBoxChangesToState.Items.Clear()
        ''Me.RadListBoxChangesToState.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("[Don't change]", "0"))

        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim AlertStates As New Generic.List(Of AdvantageFramework.Database.Entities.AlertState)
            AlertStates = Nothing
            AlertStates = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, AlertAssignmentTemplateID).ToList()

            If Not AlertStates Is Nothing Then

                For Each s As AdvantageFramework.Database.Entities.AlertState In AlertStates

                    Me.RadListBoxChangesToState.Items.Add(New Telerik.Web.UI.RadListBoxItem(s.Name, s.ID))

                Next

            End If

        End Using

    End Sub
    Private Sub LoadRadListBoxAssignmentsWithState(ByVal AlertAssignmentTemplateID As Integer)

        'Load Available States
        Me.RadListBoxAssignmentsWithState.Items.Clear()
        ''Me.RadListBoxAssignmentsWithState.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("[Please select]", "0"))

        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim AlertStates As New Generic.List(Of AdvantageFramework.Database.Entities.AlertState)
            AlertStates = Nothing
            AlertStates = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, AlertAssignmentTemplateID).ToList()

            If Not AlertStates Is Nothing Then

                For Each s As AdvantageFramework.Database.Entities.AlertState In AlertStates

                    Me.RadListBoxAssignmentsWithState.Items.Add(New Telerik.Web.UI.RadListBoxItem(s.Name, s.ID))

                Next

            End If

        End Using

    End Sub
    Private Sub LoadSettings()

        If Not Me.RadComboBoxTemplate.SelectedItem Is Nothing Then Me._TemplateId = Me.RadComboBoxTemplate.SelectedItem.Value
        If Not Me.RadListBoxAssignmentsWithState.SelectedItem Is Nothing Then Me._StateId = Me.RadListBoxAssignmentsWithState.SelectedItem.Value

        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            Dim SelectedWorkflow As New AdvantageFramework.Database.Entities.WorkflowAlertState
            SelectedWorkflow = Nothing

            SelectedWorkflow = AdvantageFramework.Database.Procedures.WorkflowAlertState.LoadByWorkflowIDAndAlertAssignmentTemplateIDAndStateID(DbContext,
                                                                                                                                                Me.RadComboBoxOnAction.SelectedItem.Value,
                                                                                                                                                Me._TemplateId,
                                                                                                                                                Me._StateId)
            Me.RadToolBarMaintenanceAlertStateWorkflow.FindItemByValue("Delete").Visible = False

            If Not SelectedWorkflow Is Nothing Then

                Me._CurrentWorkflowEvent = CType(SelectedWorkflow.WorkflowID, AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent)

                Me.LoadRadListBoxChangesToState(SelectedWorkflow.AlertAssignmentTemplateID)

                MiscFN.RadListBoxSetIndex(Me.RadListBoxChangesToState, SelectedWorkflow.EndAlertStateID, False)

                If Me._TemplateId > 0 AndAlso Me._StateId > 0 Then

                    Me.RadToolBarMaintenanceAlertStateWorkflow.FindItemByValue("Delete").Visible = True

                End If

            Else

                Me.LoadRadListBoxChangesToState(Me._TemplateId)

            End If

        End Using

    End Sub

#End Region

End Class
' ''Load Current Workflow Detail
''Dim CurrentWorkflow As New AdvantageFramework.Database.Entities.WorkflowAlertState
''CurrentWorkflow = Nothing

''CurrentWorkflow = AdvantageFramework.Database.Procedures.WorkflowAlertState.LoadByWorkflowIDAndAlertAssignmentTemplateIDAndStateID(DbContext, _
''                                                                                                                                   Me.RadComboBoxOnAction.SelectedItem.Value, _
''                                                                                                                                   Me._TemplateId, _
''                                                                                                                                   Me._StateId)

''If Not CurrentWorkflow Is Nothing Then

''    Me._CurrentWorkflowEvent = CType(CurrentWorkflow.WorkflowID, AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent)

''    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxTemplates, CurrentWorkflow.AlertAssignmentTemplateID, False)
''    Me.LoadStatesComboBox(CurrentWorkflow.AlertAssignmentTemplateID)

''    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxTemplateStates, CurrentWorkflow.AlertStateID, False)

''End If
