Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System
Imports System.Web

Public Class Workflow

    Public Enum WorkflowEvent

        Estimate_ClientApproval = 1
        Estimate_InternalApproval = 2
        ATB_Approval = 3

    End Enum

    Private Property ConnectionString As String = ""

    'alert level in here???
    Public Function ChangeAlertState(ByVal WorkflowType As AdvantageFramework.Database.Procedures.Workflow.WorkflowEvent, _
                                        Optional ByVal AllowAssignmentDemotion As Boolean = True, _
                                        Optional ByVal JobNumber As Integer = 0, _
                                        Optional ByVal JobComponentNbr As Integer = 0, _
                                        Optional ByVal OfficeCode As String = "", _
                                        Optional ByVal ClCode As String = "", _
                                        Optional ByVal DivCode As String = "", _
                                        Optional ByVal PrdCode As String = "", _
                                        Optional ByVal CmpCode As String = "", _
                                        Optional ByVal EstimateNbr As Integer = 0, _
                                        Optional ByVal EstComponentNbr As Integer = 0, _
                                        Optional ByVal EstQuoteNbr As Integer = 0, _
                                        Optional ByVal EstimateRevNbr As Integer = 0, _
                                        Optional ByVal VnCode As String = "", _
                                        Optional ByVal EmpCode As String = "", _
                                        Optional ByVal PoNumber As Integer = 0, _
                                        Optional ByVal PoRevision As Integer = 0, _
                                        Optional ByVal OrderNbr As Integer = 0, _
                                        Optional ByVal RevNbr As Integer = 0, _
                                        Optional ByVal CmpIdentifier As Integer = 0, _
                                        Optional ByVal BaBatchId As Integer = 0, _
                                        Optional ByVal TaskSeqNbr As Integer = -1, _
                                        Optional ByVal AlertStateId As Integer = 0, _
                                        Optional ByVal AlrtNotifyHdrId As Integer = 0
                                    ) As String

        Try

            Dim SbErrors As New System.Text.StringBuilder

            Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString").ToString(), HttpContext.Current.Session("UserCode").ToString())

                Dim WorkflowAlertsList As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.WorkflowAlert) = Nothing

                WorkflowAlertsList = AdvantageFramework.Database.Procedures.Workflow.LoadWorkflowAlertsToChange(DbContext, HttpContext.Current.Session("UserCode").ToString(),
                                                                                                                WorkflowType, AllowAssignmentDemotion, JobNumber, JobComponentNbr, OfficeCode, ClCode, DivCode, PrdCode, CmpCode, EstimateNbr, EstComponentNbr,
                                                                                                                EstQuoteNbr, EstimateRevNbr, VnCode, EmpCode, PoNumber, PoRevision, OrderNbr, RevNbr, CmpIdentifier, BaBatchId, TaskSeqNbr, AlertStateId, AlrtNotifyHdrId)

                If Not WorkflowAlertsList Is Nothing Then

                    Dim a As New cAlerts()
                    Dim s As String = ""
                    Dim _Session As New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("AdvantageUserLicenseInUseID"), HttpContext.Current.Session("ConnString"))

                    For Each WorkflowAlert As AdvantageFramework.Database.Classes.WorkflowAlert In WorkflowAlertsList

                        If a.SaveNotifyAssignmentAlertRecipient(WorkflowAlert.AlertID,
                                         WorkflowAlert.NewDefaultEmployeeCode,
                                         0,
                                         WorkflowAlert.NewAlertStateID,
                                         WorkflowAlert.CurrentAlertTemplateID,
                                         "", True, False, s) = True Then

                            Dim alrt As New Alert(HttpContext.Current.Session("ConnString"))
                            alrt.LoadByPrimaryKey(WorkflowAlert.AlertID)

                            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                      HttpContext.Current.Session("UserCode"),
                                      _Session,
                                      HttpContext.Current.Session("WebvantageURL"),
                                      HttpContext.Current.Session("ClientPortalURL"))
                            With eso

                                .AlertId = WorkflowAlert.AlertID
                                .Subject = "[Alert Updated]"
                                .EmployeeCodesToSendEmailTo = WorkflowAlert.NewDefaultEmployeeCode
                                .IsClientPortal = MiscFN.IsClientPortal
                                .IncludeOriginator = False

                            End With

                            eso.SendEmailOnSeparateThread()

                        Else

                            SbErrors.Append(s)
                            SbErrors.Append(Environment.NewLine)

                        End If

                    Next

                End If

            End Using

            Return SbErrors.ToString()

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try
    End Function


    Public Function GetTemplateStateWorkflowText(ByVal AlrtNotifyHdrId As Integer, ByVal AlertStateId As Integer, Optional ByRef WorkflowId As Integer = 0) As String
        Try
            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append(" SELECT      ")
                .Append(" 	WORKFLOW.WORKFLOW_ID, WORKFLOW.NAME, WORKFLOW_ALERT_STATE.ALRT_NOTIFY_HDR_ID, WORKFLOW_ALERT_STATE.ALERT_STATE_ID ")
                .Append(" FROM          ")
                .Append(" 	WORKFLOW WITH(NOLOCK) INNER JOIN ")
                .Append(" 	WORKFLOW_ALERT_STATE WITH(NOLOCK) ON WORKFLOW.WORKFLOW_ID = WORKFLOW_ALERT_STATE.WORKFLOW_ID ")
                .Append(" WHERE      ")
                .Append(" 	(WORKFLOW_ALERT_STATE.ALRT_NOTIFY_HDR_ID = " & AlrtNotifyHdrId & ") ")
                .Append(" 	AND (WORKFLOW_ALERT_STATE.ALERT_STATE_ID = " & AlertStateId & "); ")
            End With
            Dim dt As New DataTable
            dt = SqlHelper.ExecuteDataTable(Me.ConnectionString, CommandType.Text, SQL.ToString(), "DtData")
            If Not dt Is Nothing AndAlso dt.Rows.Count > 0 Then
                WorkflowId = CType(dt.Rows(0)("WORKFLOW_ID"), Integer)
                Return dt.Rows(0)("NAME").ToString()
            Else
                WorkflowId = 0
                Return ""
            End If
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Function GetWorkflows(Optional ByVal ShowAll As Boolean = False) As DataTable
        Try
            Dim sql As String = ""
            If ShowAll = True Then
                sql = "SELECT * FROM WORKFLOW WITH(NOLOCK) ORDER BY [NAME];"
            Else
                sql = "SELECT * FROM WORKFLOW WITH(NOLOCK) WHERE IS_ACTIVE IS NULL OR IS_ACTIVE = 1 ORDER BY [NAME];"
            End If
            Return SqlHelper.ExecuteDataTable(Me.ConnectionString, CommandType.Text, sql, "DtWorkflows")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetTemplateStateWorkflows(Optional ByVal WorkflowId As Integer = 0) As DataTable
        Try
            Dim SQL As New System.Text.StringBuilder
            With SQL
                .Append(" SELECT     WORKFLOW_ALERT_STATE.WORKFLOW_ALERT_STATE_ID, WORKFLOW.WORKFLOW_ID, WORKFLOW.NAME AS WorkflowName, ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID, ")
                .Append(" ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME AS TemplateName, ALERT_STATES.ALERT_STATE_ID, ALERT_STATES.ALERT_STATE_NAME AS StateName ")
                .Append(" FROM         WORKFLOW WITH (NOLOCK) INNER JOIN ")
                .Append(" WORKFLOW_ALERT_STATE WITH (NOLOCK) ON WORKFLOW.WORKFLOW_ID = WORKFLOW_ALERT_STATE.WORKFLOW_ID INNER JOIN ")
                .Append(" ALERT_NOTIFY_HDR WITH (NOLOCK) ON WORKFLOW_ALERT_STATE.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID INNER JOIN ")
                .Append(" ALERT_NOTIFY_STATES WITH (NOLOCK) ON ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_STATES.ALRT_NOTIFY_HDR_ID INNER JOIN ")
                .Append(" ALERT_STATES WITH (NOLOCK) ON WORKFLOW_ALERT_STATE.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID AND  ")
                .Append(" ALERT_NOTIFY_STATES.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID ")
                If WorkflowId > 0 Then
                    .Append(" WHERE WORKFLOW.WORKFLOW_ID = ")
                    .Append(WorkflowId.ToString())
                    .Append(" ")
                End If
                .Append(" ORDER BY WORKFLOW.NAME, ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME, ALERT_NOTIFY_STATES.SORT_ORDER; ")
            End With
            Return SqlHelper.ExecuteDataTable(Me.ConnectionString, CommandType.Text, SQL.ToString(), "DtTemplateStateWorkflows")
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub LoadWorkflowCombo(ByRef RadCombo As Telerik.Web.UI.RadComboBox, Optional ByVal TemplateId As Integer = 0, Optional ByVal StateId As Integer = 0, Optional ByVal ShowAll As Boolean = False)
        With RadCombo
            .Items.Clear()
            .DataSource = Me.GetWorkflows(ShowAll)
            .DataTextField = "NAME"
            .DataValueField = "WORKFLOW_ID"
            .DataBind()
            If TemplateId > 0 And StateId > 0 Then
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[None]", "0"))
            Else
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0"))
            End If
        End With
        If TemplateId > 0 And StateId > 0 Then
            Me.LoadExistingTemplateStateWorkflow(RadCombo, TemplateId, StateId)
        End If
    End Sub

    Public Overloads Function DeleteTemplateStateWorkflow(ByVal AlrtNotifyHdrId As Integer, ByVal AlertStateId As Integer) As String
        Try
            Return Me.SaveTemplateStateWorkflow(0, AlrtNotifyHdrId, AlertStateId)
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Public Overloads Function DeleteTemplateStateWorkflow(ByVal WorkflowAlertStateId As Integer) As String
        Try
            SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, "DELETE FROM WORKFLOW_ALERT_STATE WITH(ROWLOCK) WHERE WORKFLOW_ALERT_STATE.WORKFLOW_ALERT_STATE_ID = " & WorkflowAlertStateId.ToString() & ";")
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Public Function SaveTemplateStateWorkflow(ByVal WorkflowId As Integer, ByVal AlrtNotifyHdrId As Integer, ByVal AlertStateId As Integer) As String
        Try
            Dim SQL As New System.Text.StringBuilder
            With SQL
                'make sure the state doesn't have more than one association to any workflow
                .Append("DELETE FROM WORKFLOW_ALERT_STATE WITH(ROWLOCK)")
                .Append(" WHERE ")
                .Append(" 	WORKFLOW_ALERT_STATE.ALRT_NOTIFY_HDR_ID = " & AlrtNotifyHdrId.ToString() & " ")
                .Append(" 	AND WORKFLOW_ALERT_STATE.ALERT_STATE_ID  = " & AlertStateId.ToString() & "; ")
                If WorkflowId > 0 Then
                    'make sure the workflow does not have more than one association in the template
                    .Append("DELETE FROM WORKFLOW_ALERT_STATE WITH(ROWLOCK)")
                    .Append(" WHERE ")
                    .Append(" 	WORKFLOW_ALERT_STATE.ALRT_NOTIFY_HDR_ID = " & AlrtNotifyHdrId.ToString() & " ")
                    .Append(" 	AND WORKFLOW_ALERT_STATE.WORKFLOW_ID  = " & WorkflowId.ToString() & "; ")
                    'insert the workflow
                    .Append("INSERT INTO WORKFLOW_ALERT_STATE WITH(ROWLOCK) (WORKFLOW_ID,ALRT_NOTIFY_HDR_ID,ALERT_STATE_ID) VALUES(" & _
                             WorkflowId & ", " & AlrtNotifyHdrId & ", " & AlertStateId & ");")
                End If
            End With
            SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.Text, SQL.ToString())
            Return ""
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function

    Private Sub LoadExistingTemplateStateWorkflow(ByRef RadCombo As Telerik.Web.UI.RadComboBox, ByVal TemplateId As Integer, ByVal StateId As Integer)
        If TemplateId > 0 And StateId > 0 Then
            Dim arP(2) As SqlParameter

            Dim pTemplateId As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            pTemplateId.Value = TemplateId
            arP(0) = pTemplateId

            Dim pStateId As New SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
            pStateId.Value = StateId
            arP(1) = pStateId

            Dim dt As New DataTable
            dt = SqlHelper.ExecuteDataTable(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_WORKFLOW_ALERT_STATE_GET", "DtExistingData", arP)
            If Not dt Is Nothing Then
                If dt.Rows.Count > 0 Then
                    'Me.LabelTemplate.Text = dt.Rows(0)("TEMPLATE_TEXT").ToString()
                    'Me.LabelState.Text = dt.Rows(0)("STATE_TEXT").ToString()
                    If IsDBNull(dt.Rows(0)("CURRENT_WORKFLOW_ID")) = False Then
                        MiscFN.RadComboBoxSetIndex(RadCombo, dt.Rows(0)("CURRENT_WORKFLOW_ID").ToString(), False, True)
                    End If
                End If
            End If
        Else
            Exit Sub
        End If
    End Sub

    Sub New()

        Me.ConnectionString = HttpContext.Current.Session("ConnString").ToString()

    End Sub

End Class
