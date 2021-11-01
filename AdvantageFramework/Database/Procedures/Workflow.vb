Namespace Database.Procedures.Workflow

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum WorkflowEvent

            None = 0

            Estimate_ClientApproval = 1
            Estimate_ClientUnapprove = 2

            Estimate_InternalApproval = 3
            Estimate_InternalUnapprove = 4

            ATB_Approval = 5
            ATB_Unapprove = 6

            ATB_Cancel = 7
            ATB_Uncancel = 8

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Workflow)

            Load = From Workflow In DbContext.Workflows1
                   Order By Workflow.Name
                   Select Workflow

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.Workflow)

            LoadAllActive = From Workflow In DbContext.Workflows1
                            Where Workflow.IsActive = True
                            Order By Workflow.Name
                            Select Workflow

        End Function

        Public Function LoadWorkflowAlertsToChange(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal UserCode As String,
                                                   ByVal WorkflowEvent As Workflow.WorkflowEvent,
                                                   Optional ByVal AllowAssignmentDemotion As Boolean = True,
                                                   Optional ByVal JobNumber As Integer = 0,
                                                   Optional ByVal JobComponentNumber As Integer = 0,
                                                   Optional ByVal OfficeCode As String = "",
                                                   Optional ByVal ClientCode As String = "",
                                                   Optional ByVal DivisionCode As String = "",
                                                   Optional ByVal ProductCode As String = "",
                                                   Optional ByVal CampaignCode As String = "",
                                                   Optional ByVal EstimateNumber As Integer = 0,
                                                   Optional ByVal EstimateComponentNumber As Integer = 0,
                                                   Optional ByVal EstimateQuoteNumber As Integer = 0,
                                                   Optional ByVal EstimateRevisionNumber As Integer = 0,
                                                   Optional ByVal VendorCode As String = "",
                                                   Optional ByVal EmployeeCode As String = "",
                                                   Optional ByVal PurchaseOrderNumber As Integer = 0,
                                                   Optional ByVal PurchaseOrderRevision As Integer = 0,
                                                   Optional ByVal OrderNumber As Integer = 0,
                                                   Optional ByVal RevisionNumber As Integer = 0,
                                                   Optional ByVal CampaignIdentifier As Integer = 0,
                                                   Optional ByVal BillingApprovalBatchID As Integer = 0,
                                                   Optional ByVal TaskSequenceNumber As Integer = -1,
                                                   Optional ByVal AlertStateID As Integer = 0,
                                                   Optional ByVal AlertAssignmentTemplateID As Integer = 0,
                                                   Optional ByVal Version As String = "",
                                                   Optional ByVal Build As String = "",
                                                   Optional ByVal Version2 As String = "",
                                                   Optional ByVal Build2 As String = "",
                                                   Optional ByVal NonTaskID As Integer = 0,
                                                   Optional ByVal ApID As Integer = 0,
                                                   Optional ByVal ApSequenceNumber As Integer = 0,
                                                   Optional ByVal ATBRevisionID As Integer = 0,
                                                   Optional ByVal ATBNumber As Integer = 0,
                                                   Optional ByVal ATBRevisionNumber As Integer = 0) As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.WorkflowAlert)

            Dim WorkflowAlertsListObject As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.WorkflowAlert) = Nothing

            Try

                Dim AllowAssignmentDemotionInt As Integer = 0
                If AllowAssignmentDemotion = True Then AllowAssignmentDemotionInt = 1

                WorkflowAlertsListObject = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.WorkflowAlert)(String.Format("EXEC [dbo].[advsp_workflow_change_assignment_state] '{0}',{1},{2},{3},{4},'{5}','{6}','{7}','{8}','{9}',{10},{11},{12},{13},'{14}','{15}',{16},{17},{18},{19},{20},{21},{22},{23},{24},'{25}','{26}','{27}','{28}',{29},{30},{31},{32},{33},{34}",
                                                                                                                                               UserCode,
                                                                                                                                               AllowAssignmentDemotionInt,
                                                                                                                                               CType(WorkflowEvent, Integer),
                                                                                                                                               JobNumber,
                                                                                                                                               JobComponentNumber,
                                                                                                                                               OfficeCode,
                                                                                                                                               ClientCode,
                                                                                                                                               DivisionCode,
                                                                                                                                               ProductCode,
                                                                                                                                               CampaignCode,
                                                                                                                                               EstimateNumber,
                                                                                                                                               EstimateComponentNumber,
                                                                                                                                               EstimateQuoteNumber,
                                                                                                                                               EstimateRevisionNumber,
                                                                                                                                               VendorCode,
                                                                                                                                               EmployeeCode,
                                                                                                                                               PurchaseOrderNumber,
                                                                                                                                               PurchaseOrderRevision,
                                                                                                                                               OrderNumber,
                                                                                                                                               RevisionNumber,
                                                                                                                                               CampaignIdentifier,
                                                                                                                                               BillingApprovalBatchID,
                                                                                                                                               TaskSequenceNumber,
                                                                                                                                               AlertStateID,
                                                                                                                                               AlertAssignmentTemplateID,
                                                                                                                                               Version,
                                                                                                                                               Build,
                                                                                                                                               Version2,
                                                                                                                                               Build2,
                                                                                                                                               NonTaskID,
                                                                                                                                               ApID,
                                                                                                                                               ApSequenceNumber,
                                                                                                                                               ATBRevisionID,
                                                                                                                                               ATBNumber,
                                                                                                                                               ATBRevisionNumber)).ToList

            Catch ex As Exception

                WorkflowAlertsListObject = Nothing

            Finally

                LoadWorkflowAlertsToChange = WorkflowAlertsListObject

            End Try

        End Function
        Public Function UpdateAlertAssignments(ByVal Session As AdvantageFramework.Security.Session,
                                               ByVal UserCode As String,
                                               ByVal WorkflowEvent As Workflow.WorkflowEvent,
                                               Optional ByVal AllowAssignmentDemotion As Boolean = True,
                                               Optional ByVal JobNumber As Integer = 0,
                                               Optional ByVal JobComponentNumber As Integer = 0,
                                               Optional ByVal OfficeCode As String = "",
                                               Optional ByVal ClientCode As String = "",
                                               Optional ByVal DivisionCode As String = "",
                                               Optional ByVal ProductCode As String = "",
                                               Optional ByVal CampaignCode As String = "",
                                               Optional ByVal EstimateNumber As Integer = 0,
                                               Optional ByVal EstimateComponentNumber As Integer = 0,
                                               Optional ByVal EstimateQuoteNumber As Integer = 0,
                                               Optional ByVal EstimateRevisionNumber As Integer = 0,
                                               Optional ByVal VendorCode As String = "",
                                               Optional ByVal EmployeeCode As String = "",
                                               Optional ByVal PurchaseOrderNumber As Integer = 0,
                                               Optional ByVal PurchaseOrderRevision As Integer = 0,
                                               Optional ByVal OrderNumber As Integer = 0,
                                               Optional ByVal RevisionNumber As Integer = 0,
                                               Optional ByVal CampaignIdentifier As Integer = 0,
                                               Optional ByVal BillingApprovalBatchID As Integer = 0,
                                               Optional ByVal TaskSequenceNumber As Integer = -1,
                                               Optional ByVal AlertStateID As Integer = 0,
                                               Optional ByVal AlertAssignmentTemplateID As Integer = 0,
                                               Optional ByVal Version As String = "",
                                               Optional ByVal Build As String = "",
                                               Optional ByVal Version2 As String = "",
                                               Optional ByVal Build2 As String = "",
                                               Optional ByVal NonTaskID As Integer = 0,
                                               Optional ByVal ApID As Integer = 0,
                                               Optional ByVal ApSequenceNumber As Integer = 0,
                                               Optional ByVal ATBRevisionID As Integer = 0,
                                               Optional ByVal ATBNumber As Integer = 0,
                                               Optional ByVal ATBRevisionNumber As Integer = 0,
                                               Optional ByRef AlertList As List(Of Integer) = Nothing) As Boolean

            Dim WorkflowAlertsList As System.Collections.Generic.List(Of AdvantageFramework.Database.Classes.WorkflowAlert) = Nothing
            Dim Success As Boolean = False

            Try

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)


                    WorkflowAlertsList = LoadWorkflowAlertsToChange(DbContext,
                                                                    UserCode,
                                                                    WorkflowEvent,
                                                                    AllowAssignmentDemotion,
                                                                    JobNumber,
                                                                    JobComponentNumber,
                                                                    OfficeCode,
                                                                    ClientCode,
                                                                    DivisionCode,
                                                                    ProductCode,
                                                                    CampaignCode,
                                                                    EstimateNumber,
                                                                    EstimateComponentNumber,
                                                                    EstimateQuoteNumber,
                                                                    EstimateRevisionNumber,
                                                                    VendorCode,
                                                                    EmployeeCode,
                                                                    PurchaseOrderNumber,
                                                                    PurchaseOrderRevision,
                                                                    OrderNumber,
                                                                    RevisionNumber,
                                                                    CampaignIdentifier,
                                                                    BillingApprovalBatchID,
                                                                    TaskSequenceNumber,
                                                                    AlertStateID,
                                                                    AlertAssignmentTemplateID,
                                                                    Version,
                                                                    Build,
                                                                    Version2,
                                                                    Build2,
                                                                    NonTaskID,
                                                                    ApID,
                                                                    ApSequenceNumber,
                                                                    ATBRevisionID,
                                                                    ATBNumber,
                                                                    ATBRevisionNumber
                                                                    )

                    If Not WorkflowAlertsList Is Nothing Then

                        AlertList = New List(Of Integer)

                        Using dc = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            Dim Updated As Boolean = False
                            Dim Alert As AdvantageFramework.Database.Entities.Alert
                            Dim IsUnassigned As Boolean = False
                            Dim AgySetting As AdvantageFramework.Database.Entities.Setting
                            Dim DefaultSubjectType As String = String.Empty

                            AgySetting = Nothing
                            AgySetting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(dc, AdvantageFramework.Agency.Settings.ALRT_ASSGN_DFLT_SUB.ToString())

                            If AgySetting IsNot Nothing Then

                                DefaultSubjectType = AgySetting.Value.ToString().ToLower()

                            End If

                            For Each WorkflowAlert As AdvantageFramework.Database.Classes.WorkflowAlert In WorkflowAlertsList

                                Updated = False
                                Alert = Nothing

                                If (WorkflowAlert.NewDefaultEmployeeCode.Trim().ToLower().IndexOf("unassigned") > -1 OrElse
                                WorkflowAlert.NewDefaultEmployeeCode.Trim().ToLower().IndexOf("un-assigned") > -1) Then

                                    IsUnassigned = True

                                Else

                                    IsUnassigned = False

                                End If

                                'WorkflowAlert.NewStateIsUnassigned

                                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, WorkflowAlert.AlertID)

                                If Not Alert Is Nothing Then

                                    Updated = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[usp_wv_ALERT_NOTIFY_SAVE] '{0}', {1}, '{2}', {3}, {4}, {5}, '{6}', {7}, {8}, {9}",
                                                           If(Alert.IsCPAlert, Alert.ClientContactID, UserCode),
                                                           WorkflowAlert.AlertID,
                                                           WorkflowAlert.NewDefaultEmployeeCode,
                                                           0,
                                                           WorkflowAlert.NewAlertStateID,
                                                           WorkflowAlert.CurrentAlertTemplateID,
                                                           "",
                                                           If(IsUnassigned, 1, 0),
                                                           1,
                                                           0)).SingleOrDefault()

                                    If Updated = True Then

                                        Try

                                            If String.IsNullOrEmpty(DefaultSubjectType) = False Then

                                                Dim ds As New DefaultSubject
                                                Dim SQL As String = "SELECT ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME AS TemplateName, ALERT_STATES.ALERT_STATE_NAME AS StateName, ISNULL(JOB_COMPONENT.JOB_NUMBER, 0) AS JobNumber, ISNULL(JOB_COMPONENT.JOB_COMPONENT_NBR, 0) AS JobComponentNumber, JOB_COMPONENT.JOB_COMP_DESC AS JobComponentDescription FROM ALERT WITH(NOLOCK) LEFT OUTER JOIN ALERT_STATES WITH(NOLOCK) ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID LEFT OUTER JOIN JOB_COMPONENT WITH(NOLOCK) INNER JOIN ALERT_NOTIFY_HDR WITH(NOLOCK) ON JOB_COMPONENT.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID ON ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR AND ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID WHERE ALERT.ALERT_ID = {0};"

                                                Try

                                                    ds = dc.ExecuteQuery(Of DefaultSubject)(String.Format(SQL, Alert.ID)).SingleOrDefault

                                                Catch ex As Exception

                                                    ds = Nothing

                                                End Try

                                                Alert = Nothing
                                                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, WorkflowAlert.AlertID)

                                                If Alert IsNot Nothing AndAlso ds IsNot Nothing Then

                                                    Select Case DefaultSubjectType
                                                        Case "state"

                                                            If String.IsNullOrEmpty(ds.StateName) = False Then Alert.Subject = ds.StateName

                                                        Case "template"

                                                            If String.IsNullOrEmpty(ds.TemplateName) = False Then Alert.Subject = ds.TemplateName

                                                        Case "templateandstate"

                                                            If String.IsNullOrEmpty(ds.TemplateName) = False AndAlso String.IsNullOrEmpty(ds.StateName) = False Then Alert.Subject = ds.TemplateName & " | " & ds.StateName

                                                        Case "jjcts"

                                                            Dim s As String = String.Empty
                                                            If String.IsNullOrEmpty(ds.JobComponentDescription) = False AndAlso ds.JobNumber > 0 AndAlso ds.JobComponentNumber > 0 Then

                                                                s = ds.JobNumber.ToString().Trim().PadLeft(6, "0") & "/" & ds.JobComponentNumber.ToString().Trim().PadLeft(2, "0") & " - " & ds.JobComponentDescription

                                                            End If
                                                            If String.IsNullOrEmpty(s) = False Then

                                                                s = s & " | "

                                                            End If

                                                            Alert.Subject = "[" & s & If(String.IsNullOrEmpty(ds.TemplateName) = True, "", ds.TemplateName & " | ") & ds.StateName & "]"

                                                    End Select

                                                    'Updated = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)
                                                    AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                                                End If

                                            End If

                                        Catch ex As Exception

                                            'Updated = False

                                        End Try

                                        If Updated = True Then

                                            Updated = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[Alert Updated]", WorkflowAlert.NewDefaultEmployeeCode, "", , , , ,
                                                                                                            If(Alert.IsCPAlert Is Nothing, False, Alert.IsCPAlert), False)

                                            AlertList.Add(Alert.ID)

                                        End If

                                    End If

                                End If

                            Next

                        End Using

                    End If

                End Using

            Catch ex As Exception

                Success = False

            Finally

                UpdateAlertAssignments = Success

            End Try

        End Function

#End Region

    End Module

    Public Class DefaultSubject

        Public Property TemplateName As String = String.Empty
        Public Property StateName As String = String.Empty
        Public Property JobNumber As Integer = 0
        Public Property JobComponentNumber As Short = 0
        Public Property JobComponentDescription As String = String.Empty

        Sub New()

        End Sub

    End Class

End Namespace