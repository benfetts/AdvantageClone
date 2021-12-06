Imports System.Data.SqlClient

Namespace AlertSystem

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Public Const Unassigned As String = "*Unassigned"

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Alert "
        Public Function IsUnassigned(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal AlertID As Integer) As Boolean

            Dim Unassigned As Boolean = False

            Try

                Unassigned = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[advsp_alert_assignment_is_unassigned]  {0};", AlertID)).SingleOrDefault

            Catch ex As Exception
                Unassigned = 0
            End Try

            Return Unassigned

        End Function
        Public Function GetJobDefaultEmailGroup(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal JobNumber As Integer,
                                                ByVal JobComponentNumber As Short) As String

            Dim EmailGroup As String = String.Empty

            Try

                EmailGroup = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT JC.EMAIL_GR_CODE FROM JOB_COMPONENT JC WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};",
                                                                                                      JobNumber, JobComponentNumber)).SingleOrDefault

            Catch ex As Exception
                EmailGroup = String.Empty
            End Try

            Return EmailGroup

        End Function
        Public Function GetEmailGroupsTreeviewDataSimple(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                         ByVal EmailGroupCode As String,
                                                         ByVal JobNumber As Integer?,
                                                         ByVal JobComponentNumber As Short?,
                                                         ByVal AutoGroup As Boolean?) As Generic.List(Of AlertSystem.Classes.EmailGroupTreeViewDataSimple)

            Dim TreeviewData As New Generic.List(Of AlertSystem.Classes.EmailGroupTreeViewDataSimple)
            Dim AllData As Generic.List(Of AlertSystem.Classes.EmailGroup) = Nothing
            Dim JobEmailGroupCode As String = String.Empty

            Try

                AllData = GetEmailGroups(DbContext, EmailGroupCode, JobNumber, JobComponentNumber, AutoGroup)

                If AllData IsNot Nothing AndAlso AllData.Count > 0 Then

                    Dim EmailGroup As AlertSystem.Classes.EmailGroupTreeViewDataSimple = Nothing
                    Dim Group As Generic.List(Of AlertSystem.Classes.EmailGroup) = Nothing
                    Dim GroupMembers As Generic.List(Of AlertSystem.Classes.EmailGroup) = Nothing
                    Dim Item As AlertSystem.Classes.TreeNode = Nothing
                    Dim SubItem As AlertSystem.Classes.TreeNode = Nothing
                    Dim CheckedEmployeeCodes As New Generic.List(Of String)

                    If JobNumber IsNot Nothing AndAlso JobNumber > 0 AndAlso JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0 Then

                        JobEmailGroupCode = GetJobDefaultEmailGroup(DbContext, JobNumber, JobComponentNumber)

                    End If

                    Group = (From Entity In AllData
                             Where Entity.IsGroup = True).ToList

                    If Group IsNot Nothing Then

                        For Each Header As AlertSystem.Classes.EmailGroup In Group

                            EmailGroup = Nothing
                            EmailGroup = New Classes.EmailGroupTreeViewDataSimple

                            Item = Nothing
                            Item = New Classes.TreeNode

                            Item.id = Header.Code
                            Item.text = Header.Description
                            Item.expanded = True

                            EmailGroup.id = Header.Code
                            EmailGroup.text = Header.Description

                            If String.IsNullOrWhiteSpace(JobEmailGroupCode) = False AndAlso
                               Header.Code = JobEmailGroupCode Then

                                EmailGroup.expanded = True
                                EmailGroup.checked = True

                            Else

                                EmailGroup.expanded = True
                                EmailGroup.checked = False

                            End If

                            GroupMembers = Nothing
                            GroupMembers = (From Entity In AllData
                                            Where Entity.EmailGroupCode = Header.Code).ToList

                            If GroupMembers IsNot Nothing Then

                                For Each Employee As Classes.EmailGroup In GroupMembers

                                    Item = Nothing
                                    Item = New Classes.TreeNode

                                    Item.id = Employee.Code
                                    Item.text = Employee.EmployeeFullName
                                    Item.expanded = False
                                    Item.isClientContact = Employee.IsContacts
                                    Item.clientContactId = Employee.ClientContactID

                                    If EmailGroup.checked = True Then

                                        Item.checked = True

                                        If CheckedEmployeeCodes.Contains(Employee.Code) = False Then

                                            CheckedEmployeeCodes.Add(Employee.Code)

                                        End If

                                    Else

                                        Item.checked = False

                                    End If

                                    EmailGroup.items.Add(Item)

                                Next

                            End If

                            TreeviewData.Add(EmailGroup)

                        Next

                    End If

                    'Check all nodes for duplicates to check
                    If TreeviewData IsNot Nothing AndAlso CheckedEmployeeCodes.Count > 0 Then

                        For Each Node As AlertSystem.Classes.EmailGroupTreeViewDataSimple In TreeviewData

                            If Node.items IsNot Nothing Then

                                For Each Item In Node.items

                                    If CheckedEmployeeCodes.Contains(Item.id) = True Then

                                        Item.checked = True

                                    End If

                                Next

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
            End Try

            If TreeviewData Is Nothing Then TreeviewData = New List(Of Classes.EmailGroupTreeViewDataSimple)

            Return TreeviewData

        End Function
        Public Function GetEmailGroupsTreeviewData(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal EmailGroupCode As String,
                                                   ByVal JobNumber As Integer?,
                                                   ByVal JobComponentNumber As Short?,
                                                   ByVal AutoGroup As Boolean?) As Generic.List(Of AlertSystem.Classes.EmailGroupTreeViewData)

            Dim TreeviewData As New Generic.List(Of AlertSystem.Classes.EmailGroupTreeViewData)
            Dim AllData As Generic.List(Of AlertSystem.Classes.EmailGroup) = Nothing

            Try

                AllData = GetEmailGroups(DbContext, EmailGroupCode, JobNumber, JobComponentNumber, AutoGroup)

                If AllData IsNot Nothing AndAlso AllData.Count > 0 Then

                    Dim EmailGroup As AlertSystem.Classes.EmailGroupTreeViewData = Nothing
                    Dim Group As Generic.List(Of AlertSystem.Classes.EmailGroup) = Nothing
                    Dim GroupMembers As Generic.List(Of AlertSystem.Classes.EmailGroup) = Nothing

                    Group = (From Entity In AllData
                             Where Entity.IsGroup = True).ToList

                    If Group IsNot Nothing Then

                        For Each Header As AlertSystem.Classes.EmailGroup In Group

                            EmailGroup = Nothing
                            EmailGroup = New Classes.EmailGroupTreeViewData

                            EmailGroup.Group = Header
                            EmailGroup.Members = (From Entity In AllData
                                                  Where Entity.EmailGroupCode = Header.Code).ToList

                            TreeviewData.Add(EmailGroup)

                        Next

                    End If

                End If

            Catch ex As Exception
            End Try

            If TreeviewData Is Nothing Then TreeviewData = New List(Of Classes.EmailGroupTreeViewData)

            Return TreeviewData

        End Function
        Public Function GetEmailGroups(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal EmailGroupCode As String,
                                       ByVal JobNumber As Integer?,
                                       ByVal JobComponentNumber As Short?,
                                       ByVal AutoGroup As Boolean?) As Generic.List(Of AlertSystem.Classes.EmailGroup)

            'usp_wv_Get_Alert_EmailGroups
            'usp_wv_getCPUsersAlerts
            'usp_cp_GetAlertRecipients
            Dim List As Generic.List(Of AlertSystem.Classes.EmailGroup) = Nothing

            Try

                Dim EmailGroupCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AutoGroupSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                EmailGroupCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMAIL_GRP_CODE", SqlDbType.VarChar, 50)
                JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                AutoGroupSqlParameter = New System.Data.SqlClient.SqlParameter("@AUTO_GROUP", SqlDbType.SmallInt)

                If String.IsNullOrWhiteSpace(EmailGroupCode) = False Then

                    EmailGroupCodeSqlParameter.Value = EmailGroupCode

                Else

                    EmailGroupCodeSqlParameter.Value = System.DBNull.Value

                End If
                If JobNumber IsNot Nothing AndAlso JobNumber > 0 Then

                    JobNumberSqlParameter.Value = JobNumber

                Else

                    JobNumberSqlParameter.Value = System.DBNull.Value

                End If
                If JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0 Then

                    JobComponentNumberSqlParameter.Value = JobComponentNumber

                Else

                    JobComponentNumberSqlParameter.Value = System.DBNull.Value

                End If
                If AutoGroup IsNot Nothing AndAlso AutoGroup = True Then

                    AutoGroupSqlParameter.Value = 1

                Else

                    AutoGroupSqlParameter.Value = 0

                End If

                List = DbContext.Database.SqlQuery(Of AlertSystem.Classes.EmailGroup)(" SELECT EG.IsGroup, EG.EmailGroupCode, EG.Code, [Description] = Description1, EG.IsChecked, EG.[Order], EG.EmployeeFullName, EG.IsContacts, EG.ClientContactID " &
                                                                                      " FROM [dbo].[advtf_get_email_groups] (@EMAIL_GRP_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @AUTO_GROUP) AS EG;",
                                                                                        EmailGroupCodeSqlParameter,
                                                                                        JobNumberSqlParameter,
                                                                                        JobComponentNumberSqlParameter,
                                                                                        AutoGroupSqlParameter).ToList

            Catch ex As Exception
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.EmailGroup)

            Return List

        End Function
        Public Function ResetWorkflow(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal AlertID As Integer) As Boolean

            Dim WorkflowReset As Boolean = True

            Try

                Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

                AlertIDSqlParameter.Value = AlertID
                UserCodeSqlParameter.Value = DbContext.UserCode

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_alert_reset_routed_assignment] @ALERT_ID, @USER_CODE;",
                                                      AlertIDSqlParameter,
                                                      UserCodeSqlParameter)

            Catch ex As Exception
                WorkflowReset = False
            End Try

            Return WorkflowReset

        End Function
        Public Function AddAssigneeToTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal UserCode As String,
                                              ByVal AlertID As Integer,
                                              ByVal AlertTemplateID As Integer,
                                              ByVal AlertStateID As Integer,
                                              ByVal EmployeeCode As String,
                                              ByVal DocumentID As Integer,
                                              ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = True

            Try

                Dim SqlParameterAlertID As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAlertTemplateID As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAlertStateID As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                SqlParameterAlertTemplateID = New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
                SqlParameterAlertStateID = New System.Data.SqlClient.SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

                SqlParameterAlertID.Value = AlertID
                SqlParameterAlertTemplateID.Value = AlertTemplateID
                SqlParameterAlertStateID.Value = AlertStateID
                SqlParameterEmployeeCode.Value = EmployeeCode

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_alert_assignment_template_add_employee_to_state] @ALERT_ID, @ALRT_NOTIFY_HDR_ID, @ALERT_STATE_ID, @EMP_CODE;",
                                                     SqlParameterAlertID, SqlParameterAlertTemplateID, SqlParameterAlertStateID, SqlParameterEmployeeCode)

            Catch ex As Exception
                Added = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Added

        End Function
        Public Function DeleteAssigneeFromTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal UserCode As String,
                                                   ByVal AlertID As Integer,
                                                   ByVal AlertTemplateID As Integer,
                                                   ByVal AlertStateID As Integer,
                                                   ByVal EmployeeCode As String,
                                                   ByVal DocumentID As Integer,
                                                   ByRef ErrorMessage As String) As Boolean

            Dim Deleted As Boolean = True

            Try

                Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAlertID As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAlertTemplateID As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAlertStateID As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterDocumentID As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                SqlParameterAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                SqlParameterAlertTemplateID = New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
                SqlParameterAlertStateID = New System.Data.SqlClient.SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                SqlParameterDocumentID = New System.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int)

                SqlParameterUserCode.Value = UserCode
                SqlParameterAlertID.Value = AlertID
                SqlParameterAlertTemplateID.Value = AlertTemplateID
                SqlParameterAlertStateID.Value = AlertStateID
                SqlParameterEmployeeCode.Value = EmployeeCode
                SqlParameterDocumentID.Value = DocumentID

                'If HasAssignee(DbContext, AlertID, AlertTemplateID, AlertStateID, EmployeeCode) = True Then

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_alert_assignment_template_delete_employee_from_state] @USER_CODE, @ALERT_ID, @ALRT_NOTIFY_HDR_ID, @ALERT_STATE_ID, @EMP_CODE, @DOCUMENT_ID;",
                                                     SqlParameterUserCode,
                                                     SqlParameterAlertID,
                                                     SqlParameterAlertTemplateID,
                                                     SqlParameterAlertStateID,
                                                     SqlParameterEmployeeCode,
                                                     SqlParameterDocumentID)

                'Else

                '    ErrorMessage = "Must have at least one assignee."
                '    Deleted = False

                'End If


            Catch ex As Exception
                Deleted = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Deleted

        End Function
        Public Function HasAssignee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal AlertID As Integer,
                                    ByVal AlertTemplateID As Integer,
                                    ByVal AlertStateID As Integer,
                                    ByVal EmployeeCode As String) As Boolean

            Dim SqlParameterAlertID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertTemplateID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertStateID As System.Data.SqlClient.SqlParameter = Nothing
            Dim AssignmentHasAssignee As Boolean = False
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            SqlParameterAlertTemplateID = New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            SqlParameterAlertStateID = New System.Data.SqlClient.SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

            SqlParameterAlertID.Value = AlertID
            SqlParameterAlertTemplateID.Value = AlertTemplateID
            SqlParameterAlertStateID.Value = AlertStateID
            SqlParameterEmployeeCode.Value = EmployeeCode

            Try

                AssignmentHasAssignee = DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_proofing_has_assignee] @ALERT_ID, @ALRT_NOTIFY_HDR_ID, @ALERT_STATE_ID, @EMP_CODE;",
                                                                                SqlParameterAlertID,
                                                                                SqlParameterAlertTemplateID,
                                                                                SqlParameterAlertStateID,
                                                                                SqlParameterEmployeeCode).SingleOrDefault()

            Catch ex As Exception
                AssignmentHasAssignee = True
            End Try


            Return AssignmentHasAssignee

        End Function
        Public Function AddAssignee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal SecuritySession As AdvantageFramework.Security.Session,
                                    ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Added As Boolean = False

            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

            If Alert IsNot Nothing Then

                Added = AddAssignee(DbContext, SecuritySession, Alert, EmployeeCode, Alert.AlertAssignmentTemplateID, Alert.AlertStateID)

            End If

            AddAssignee = Added

        End Function
        Public Function AddAssignee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                    ByVal SecuritySession As AdvantageFramework.Security.Session,
                                    ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                    ByVal EmployeeCode As String,
                                    ByVal AlertTemplateID As Integer?,
                                    ByVal AlertStateID As Integer?) As Boolean

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim JobComponentTaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing
            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
            Dim Added As Boolean = False
            Dim IsNew As Boolean = False
            Dim RightNow As DateTime = Now

            Try

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    If IsBoardTaskAlert(Alert) Then

                        JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, Alert.JobNumber.GetValueOrDefault(0), Alert.JobComponentNumber.GetValueOrDefault(0), Alert.TaskSequenceNumber.GetValueOrDefault(0))

                        If JobComponentTask IsNot Nothing Then

                            JobComponentTaskEmployee = New AdvantageFramework.Database.Entities.JobComponentTaskEmployee
                            JobComponentTaskEmployee.JobNumber = JobComponentTask.JobNumber
                            JobComponentTaskEmployee.JobComponentNumber = JobComponentTask.JobComponentNumber
                            JobComponentTaskEmployee.SequenceNumber = JobComponentTask.SequenceNumber
                            JobComponentTaskEmployee.EmployeeCode = Employee.Code
                            JobComponentTaskEmployee.Hours = JobComponentTask.Hours
                            JobComponentTaskEmployee.ReadAlert = 0

                            Added = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, JobComponentTaskEmployee)

                        End If

                    Else

                        AlertRecipient = (From Item In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Alert.ID)
                                          Where Item.EmployeeCode = EmployeeCode AndAlso
                                                Item.IsCurrentNotify = 1 AndAlso
                                                Item.AlertTemplateID = AlertTemplateID AndAlso
                                                Item.AlertStateID = AlertStateID
                                          Select Item).SingleOrDefault

                        AlertRecipientDismissed = (From Item In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, Alert.ID)
                                                   Where Item.EmployeeCode = EmployeeCode AndAlso
                                                         Item.IsCurrentNotify = 1 AndAlso
                                                         Item.AlertTemplateID = AlertTemplateID AndAlso
                                                         Item.AlertStateID = AlertStateID
                                                   Select Item).SingleOrDefault

                        Added = AddAssignee(DbContext, Alert, Employee, Alert.AlertAssignmentTemplateID, Alert.AlertStateID,
                                            AlertRecipient, AlertRecipientDismissed, "")

                    End If
                    'If Added = True Then

                    '    Dim Comment = New AdvantageFramework.Database.Entities.AlertComment

                    '    Comment.AlertID = Alert.ID
                    '    Comment.UserCode = DbContext.UserCode
                    '    Comment.GeneratedDate = RightNow
                    '    Comment.Comment = String.Format("{0} | {1}", Employee.ToString, "")
                    '    Comment.HasEmailBeenSent = False
                    '    Comment.AssignedEmployeeCode = Employee.Code
                    '    Comment.CustodyStart = Comment.GeneratedDate

                    '    If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then


                    '    End If

                    'End If
                    Try

                        Dim BackgroundWork As New AdvantageFramework.ProjectManagement.Agile.Classes.WorkItemAsync(SecuritySession)
                        BackgroundWork.AlertID = Alert.ID
                        BackgroundWork.CheckSprintEmployeeRecordsWithCheckAsync()

                    Catch ex As Exception
                    End Try

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddAssignee = Added
            End Try

        End Function
        Public Function AddAssignee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                     ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                     ByVal AlertTemplateID As Integer?,
                                     ByVal AlertStateID As Integer?,
                                     ByVal AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient,
                                     ByVal AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed,
                                     ByVal Comment As String) As Boolean

            Return AddAssigneeOrRecipient(DbContext, Alert, Employee, AlertTemplateID, AlertStateID, AlertRecipient, AlertRecipientDismissed, True, Comment)

        End Function
        Public Function AddAssigneeOrRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                                ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                ByVal AlertTemplateID As Integer?,
                                                ByVal AlertStateID As Integer?,
                                                ByVal AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient,
                                                ByVal AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed,
                                                ByVal IsAssignment As Boolean,
                                                ByVal Comment As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim IsNew As Boolean = False
            Dim UserEmployeeCode As String = String.Empty
            Dim IsRoutedAssignment As Boolean = False
            Dim IsTask As Boolean = False
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim AlertState As AdvantageFramework.Database.Entities.AlertState = Nothing
            Dim StateName As String = String.Empty

            Try

                If Employee IsNot Nothing Then

                    If AlertTemplateID IsNot Nothing AndAlso AlertTemplateID = 0 Then AlertTemplateID = Nothing
                    If AlertStateID IsNot Nothing AndAlso AlertStateID = 0 Then AlertStateID = Nothing

                    If Alert IsNot Nothing Then

                        Try

                            If Alert.AlertLevel = "BRD" OrElse Alert.AlertLevel = "PST" Then IsTask = True

                        Catch ex As Exception
                            IsTask = False
                        End Try

                    End If
                    If AlertRecipient Is Nothing Then

                        IsNew = True

                        AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                        AlertRecipient.DbContext = DbContext
                        AlertRecipient.EmployeeCode = Employee.Code
                        AlertRecipient.AlertID = Alert.ID

                        If AlertRecipientDismissed IsNot Nothing Then

                            AlertRecipient.IsCurrentRecipient = AlertRecipientDismissed.IsCurrentRecipient
                            AlertRecipient.IsCurrentNotify = AlertRecipientDismissed.IsCurrentNotify

                        Else

                            AlertRecipient.IsNewAlert = 1

                        End If

                    Else

                        AlertRecipient.IsNewAlert = Nothing

                    End If
                    If IsAssignment = True Then

                        AlertRecipient.IsCurrentNotify = 1
                        AlertRecipient.IsCurrentRecipient = Nothing
                        AlertRecipient.AlertTemplateID = AlertTemplateID
                        AlertRecipient.AlertStateID = AlertStateID
                        AlertRecipient.HoursAllowed = Alert.HoursAllowed

                    Else

                        AlertRecipient.IsCurrentNotify = Nothing
                        AlertRecipient.IsCurrentRecipient = Nothing
                        AlertRecipient.AlertTemplateID = Nothing
                        AlertRecipient.AlertStateID = Nothing

                    End If

                    AlertRecipient.HasBeenRead = Nothing

                    If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForEmail(Employee) Then

                        AlertRecipient.EmployeeEmail = AdvantageFramework.AlertSystem.LoadEmployeeEmailAddress(Employee)

                    ElseIf AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForAlert(Employee) Then

                        AlertRecipient.EmployeeEmail = ""

                    End If
                    If IsNew Then

                        Added = AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                        If Added AndAlso AlertRecipientDismissed IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Delete(DbContext, AlertRecipientDismissed)

                        End If

                    Else

                        Added = AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRecipient)

                    End If
                    If Added = True AndAlso IsAssignment = True Then

                        If AlertStateID IsNot Nothing AndAlso AlertStateID > 0 Then

                            AlertState = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertStateID(DbContext, AlertStateID)

                            If AlertState IsNot Nothing Then

                                StateName = AlertState.Name

                            End If

                        End If

                        AlertComment = New Database.Entities.AlertComment

                        AlertComment.AlertID = Alert.ID
                        AlertComment.UserCode = DbContext.UserCode
                        AlertComment.GeneratedDate = Now

                        If String.IsNullOrWhiteSpace(StateName) = False Then

                            AlertComment.Comment = StateName.ToUpper() & " | "

                        End If

                        AlertComment.Comment &= Employee.ToString

                        If String.IsNullOrWhiteSpace(Comment) = False Then

                            AlertComment.Comment &= Comment

                        Else

                            AlertComment.IsSystem = True

                        End If

                        AlertComment.HasEmailBeenSent = False
                        AlertComment.AssignedEmployeeCode = Employee.Code
                        If AlertTemplateID IsNot Nothing AndAlso AlertTemplateID > 0 Then AlertComment.AlertAssignmentTemplateID = AlertTemplateID
                        If AlertStateID IsNot Nothing AndAlso AlertStateID > 0 Then AlertComment.AlertStateID = AlertStateID
                        AlertComment.CustodyStart = AlertComment.GeneratedDate

                        AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment)

                    End If
                    If IsTask = True Then

                        Try

                            If AlertRecipient.HasBeenRead Is Nothing OrElse AlertRecipient.HasBeenRead = 0 Then

                                AdvantageFramework.ProjectSchedule.MarkTaskNotRead(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, Employee.Code)

                            End If

                        Catch ex As Exception
                        End Try

                    End If

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddAssigneeOrRecipient = Added
            End Try

        End Function
        Public Function AddRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Added As Boolean = False

            Try

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    Added = AddRecipient(DbContext, Alert, EmployeeCode, "")

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddRecipient = Added
            End Try

        End Function
        Public Function AddRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                     ByVal EmployeeCode As String, ByVal Comment As String)

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
            Dim Added As Boolean = False

            Try

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    AlertRecipient = (From Item In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, Alert.ID)
                                      Where Item.EmployeeCode = EmployeeCode AndAlso
                                            Item.IsCurrentNotify <> 1
                                      Select Item).SingleOrDefault


                    AlertRecipientDismissed = (From Item In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, Alert.ID)
                                               Where Item.EmployeeCode = EmployeeCode AndAlso
                                                     Item.IsCurrentNotify <> 1
                                               Select Item).SingleOrDefault

                    Added = AdvantageFramework.AlertSystem.AddAssigneeOrRecipient(DbContext, Alert, Employee, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, AlertRecipient, AlertRecipientDismissed, False, Comment)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddRecipient = Added
            End Try

        End Function
        Public Function DeleteAssignee(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Dim Deleted As Boolean = False

            Try

                Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

                AlertIDSqlParameter.Value = AlertID
                EmployeeCodeSqlParameter.Value = EmployeeCode

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_alert_delete_assignee] @ALERT_ID, @EMP_CODE;",
                                                      AlertIDSqlParameter,
                                                      EmployeeCodeSqlParameter)

                Deleted = True

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteAssignee = Deleted
            End Try

        End Function
        Public Function DeleteRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertRecipientDismissed As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
            Dim Deleted As Boolean = False

            Try

                AlertRecipient = (From Item In AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, AlertID)
                                  Where Item.EmployeeCode = EmployeeCode AndAlso
                                        Item.IsCurrentNotify <> 1
                                  Select Item).SingleOrDefault

                If AlertRecipient IsNot Nothing Then

                    AlertRecipient.IsCurrentRecipient = 1 ' 0/null = recipient, 1 = not recipient

                    Deleted = AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRecipient)

                Else

                    AlertRecipientDismissed = (From Item In AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, AlertID)
                                               Where Item.EmployeeCode = EmployeeCode AndAlso
                                                     Item.IsCurrentNotify <> 1
                                               Select Item).SingleOrDefault

                    If AlertRecipientDismissed IsNot Nothing Then

                        AlertRecipientDismissed.IsCurrentRecipient = 1 ' 0/null = recipient, 1 = not recipient

                        Deleted = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Update(DbContext, AlertRecipientDismissed)

                    End If

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteRecipient = Deleted
            End Try

        End Function
        Public Function MilitaryTimeStringToStandardTimeString(ByVal MilitaryTimeString As String) As String
            Try

                If MilitaryTimeString.Contains(":") = True Then

                    Dim StandardTime As String = MilitaryTimeString
                    Dim TimeParts As String()

                    TimeParts = MilitaryTimeString.Split(":")

                    If TimeParts.Length = 2 AndAlso IsNumeric(TimeParts(0)) = True AndAlso IsNumeric(TimeParts(1)) Then

                        StandardTime = DateTime.Parse(MilitaryTimeString).ToString("h:mm tt")

                    End If

                    Return StandardTime

                Else

                    Return MilitaryTimeString

                End If

            Catch ex As Exception
                Return MilitaryTimeString
            End Try
        End Function
        Public Function LoadAlertLevels() As Dictionary(Of String, String)
            Dim dict As New Dictionary(Of String, String)

            dict.Add("OF", "Office")
            dict.Add("CL", "Client")
            dict.Add("DI", "Division")
            dict.Add("PR", "Product")
            dict.Add("CM", "Campaign")
            dict.Add("JO", "Job")
            dict.Add("JC", "Job Component")
            dict.Add("ES", "Estimate")
            dict.Add("EST", "Estimate Component")
            dict.Add("PS", "Project Schedule")
            dict.Add("PST", "Task")
            dict.Add("PO", "Purchase Order")
            dict.Add("AB", "Authorization to Buy")
            dict.Add("AP", "Accounts Payable")

            LoadAlertLevels = dict

        End Function
        Public Function CheckForTaskPrompts(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal SecuritySession As AdvantageFramework.Security.Session,
                                            ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                            ByRef ShowTaskFullyCompletePrompt As Boolean,
                                            ByRef ShowTaskTempCompletePrompt As Boolean,
                                            ByRef ErrorMessage As String) As Boolean

            ShowTaskFullyCompletePrompt = False
            ShowTaskTempCompletePrompt = False

            Try

                If Alert.AlertLevel = "PST" Then

                    Dim EmployeeDismissingIsAssignee As Boolean = False
                    Dim FullCompleteTaskAgencySettingValue As Short = 0

                    If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) = True Then

                        Dim CurrentAssigneeEmployeeCode As String = String.Empty
                        Dim SQL As String = " SELECT ISNULL(EMP_CODE, '') FROM ALERT_RCPT WITH(NOLOCK) WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND CURRENT_NOTIFY = 1 " &
                                            " UNION " &
                                            " SELECT ISNULL(EMP_CODE, '') FROM ALERT_RCPT_DISMISSED WITH(NOLOCK) WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND CURRENT_NOTIFY = 1 "

                        Try

                            CurrentAssigneeEmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format(SQL, Alert.ID, SecuritySession.User.EmployeeCode)).FirstOrDefault

                        Catch ex As Exception
                            CurrentAssigneeEmployeeCode = String.Empty
                        End Try

                        EmployeeDismissingIsAssignee = String.IsNullOrWhiteSpace(CurrentAssigneeEmployeeCode) = False

                    End If
                    Try

                        FullCompleteTaskAgencySettingValue = CShort(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.TRF_COMP_ALERT))

                    Catch ex As Exception
                        FullCompleteTaskAgencySettingValue = 0
                    End Try
                    Select Case FullCompleteTaskAgencySettingValue
                        Case 0 'Check temp complete here

                            Dim TempCompleteTaskAgencySettingValue As Short = 0
                            Try

                                TempCompleteTaskAgencySettingValue = DbContext.Database.SqlQuery(Of Short)("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS SMALLINT) " &
                                                                                                           "FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_TEMP_COMP_ALERT';").FirstOrDefault
                                'TempCompleteTaskAgencySettingValue = CShort(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.TRF_TEMP_COMP_ALERT))

                            Catch ex As Exception
                                TempCompleteTaskAgencySettingValue = 0
                            End Try

                            Select Case TempCompleteTaskAgencySettingValue
                                Case 1 'Temp complete without prompt

                                    If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) = False Then

                                        Using sc As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                                            AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, SecuritySession.User.EmployeeCode, CType(Now, DateTime))

                                        End Using

                                    Else

                                        If EmployeeDismissingIsAssignee = True Then

                                            AdvantageFramework.ProjectSchedule.MarkAllEmployeesTempComplete(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                                        End If

                                    End If

                                Case 2

                                    ShowTaskTempCompletePrompt = True

                            End Select

                        Case 1 'Fully complete without prompt

                            If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) = False Then

                                Using sc As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                                    AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, SecuritySession.User.EmployeeCode, CType(Now, DateTime))

                                End Using

                            Else

                                If EmployeeDismissingIsAssignee = True Then

                                    AdvantageFramework.ProjectSchedule.MarkAllEmployeesTempComplete(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                                End If

                            End If

                            AdvantageFramework.ProjectSchedule.CompleteTaskFromAlertOrAssignment(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, SecuritySession.User.EmployeeCode, False)

                        Case 2

                            ShowTaskFullyCompletePrompt = True

                    End Select

                End If

                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function DismissAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal AlertID As Integer, ByVal EmployeeCode As String, ByVal UserCode As String,
                                     ByVal ClientContactID As Integer, ByVal ForceAssignmentComplete As Boolean,
                                     ByRef ShowTaskFullyCompletePrompt As Boolean, ByRef ShowTaskTempCompletePrompt As Boolean,
                                     ByRef ErrorMessage As String) As Boolean

            Try

                Dim IsDismissingProjectScheduleTask As Boolean = False
                Dim SqlParameterAlertId As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterIsClientPortal As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterClientPortalId As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterForceAssignmentComplete As System.Data.SqlClient.SqlParameter = Nothing
                Dim IsClientPortal As Boolean = False
                Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                ShowTaskFullyCompletePrompt = False
                ShowTaskTempCompletePrompt = False

                SqlParameterAlertId = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar)
                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar)
                SqlParameterIsClientPortal = New System.Data.SqlClient.SqlParameter("@CP", SqlDbType.Int)
                SqlParameterClientPortalId = New System.Data.SqlClient.SqlParameter("@CPID", SqlDbType.Int)
                SqlParameterForceAssignmentComplete = New System.Data.SqlClient.SqlParameter("@FORCE_ASSIGNMENT_COMPLETE", SqlDbType.Bit)

                If ClientContactID > 0 Then

                    IsClientPortal = True

                End If

                SqlParameterAlertId.Value = AlertID
                SqlParameterUserCode.Value = UserCode
                If String.IsNullOrWhiteSpace(EmployeeCode) Then
                    SqlParameterEmployeeCode.Value = System.DBNull.Value
                Else
                    SqlParameterEmployeeCode.Value = EmployeeCode
                End If
                SqlParameterIsClientPortal.Value = If(IsClientPortal, 1, 0)
                SqlParameterClientPortalId.Value = ClientContactID
                SqlParameterForceAssignmentComplete.Value = ForceAssignmentComplete

                'If Alert.IsWorkItem IsNot Nothing AndAlso Alert.IsWorkItem = True Then

                '    CompleteAssignment(DbContext, Alert, EmployeeCode, UserCode, ErrorMessage)

                'Else

                IsDismissingProjectScheduleTask = DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[usp_wv_ALERT_DISMISS] @ALERT_ID, @USER_CODE, @EMP_CODE, @CP, @CPID, @FORCE_ASSIGNMENT_COMPLETE",
                                                                                           SqlParameterAlertId, SqlParameterUserCode, SqlParameterEmployeeCode, SqlParameterIsClientPortal,
                                                                                           SqlParameterClientPortalId, SqlParameterForceAssignmentComplete).FirstOrDefault()

                'End If



                If Alert.AlertLevel = "PST" Then

                    Dim EmployeeDismissingIsAssignee As Boolean = False

                    If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) = True Then

                        Dim CurrentAssigneeEmployeeCode As String = String.Empty
                        CurrentAssigneeEmployeeCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(ASSIGNED_EMP_CODE, '') FROM ALERT WITH(NOLOCK) WHERE ALERT_ID = {0};", Alert.ID)).FirstOrDefault

                        EmployeeDismissingIsAssignee = CurrentAssigneeEmployeeCode = EmployeeCode

                    End If

                    Dim FullCompleteTaskAgencySettingValue As Short = 0
                    Try

                        FullCompleteTaskAgencySettingValue = CShort(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.TRF_COMP_ALERT))

                    Catch ex As Exception
                        FullCompleteTaskAgencySettingValue = 0
                    End Try

                    Select Case FullCompleteTaskAgencySettingValue
                        Case 0 'Check temp complete here

                            Dim TempCompleteTaskAgencySettingValue As Short = 0
                            Try

                                TempCompleteTaskAgencySettingValue = DbContext.Database.SqlQuery(Of Short)("SELECT CAST(ISNULL(AGY_SETTINGS_VALUE, 0) AS SMALLINT) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'TRF_TEMP_COMP_ALERT';").FirstOrDefault
                                'TempCompleteTaskAgencySettingValue = CShort(AdvantageFramework.Agency.GetValue(DbContext, AdvantageFramework.Agency.Methods.Settings.TRF_TEMP_COMP_ALERT))

                            Catch ex As Exception
                                TempCompleteTaskAgencySettingValue = 0
                            End Try

                            Select Case TempCompleteTaskAgencySettingValue
                                Case 1 'Temp complete without prompt

                                    If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) = False Then

                                        Using sc As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, UserCode)

                                            AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, EmployeeCode, CType(Now, DateTime))

                                        End Using

                                    Else

                                        If EmployeeDismissingIsAssignee = True Then

                                            AdvantageFramework.ProjectSchedule.MarkAllEmployeesTempComplete(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                                        End If

                                    End If

                                Case 2

                                    ShowTaskTempCompletePrompt = True

                            End Select

                        Case 1 'Fully complete without prompt

                            If AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(Alert) = False Then

                                Using sc As New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, UserCode)

                                    AdvantageFramework.ProjectSchedule.MarkTempComplete(DbContext, sc, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, EmployeeCode, CType(Now, DateTime))

                                End Using

                            Else

                                If EmployeeDismissingIsAssignee = True Then

                                    AdvantageFramework.ProjectSchedule.MarkAllEmployeesTempComplete(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber)

                                End If

                            End If

                            AdvantageFramework.ProjectSchedule.CompleteTaskFromAlertOrAssignment(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, EmployeeCode, IsClientPortal)

                        Case 2

                            ShowTaskFullyCompletePrompt = True

                    End Select

                End If

                ErrorMessage = String.Empty
                Return True

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try

        End Function
        Public Function CompleteTempComplete(ByVal DbContext As AdvantageFramework.Database.DbContext, UserCode As String, AssignedEmployee As String,
                                             Role As String, ProjectManager As String, Office As String,
                                             TaskStatus As String, SearchCriteria As String, AlertId As String) _
                                             As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerJobDetail)

            Dim CompletedTasks As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerJobDetail) = Nothing
            Dim ErrorMessage As String = Nothing

            Try
                Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAssignedEmployee As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterRole As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterProjectManager As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterOffice As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterTaskStatus As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterSearchCriteria As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterAlertId As System.Data.SqlClient.SqlParameter = Nothing

                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@UserID", SqlDbType.VarChar, 100)
                SqlParameterAssignedEmployee = New System.Data.SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 140)
                SqlParameterRole = New System.Data.SqlClient.SqlParameter("@Role", SqlDbType.VarChar, 140)
                SqlParameterProjectManager = New System.Data.SqlClient.SqlParameter("@ManagerCode", SqlDbType.VarChar, 6)
                SqlParameterOffice = New System.Data.SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 4)
                SqlParameterTaskStatus = New System.Data.SqlClient.SqlParameter("@TaskStatus", SqlDbType.VarChar, 10)
                SqlParameterSearchCriteria = New System.Data.SqlClient.SqlParameter("@Search", SqlDbType.VarChar, 500)
                SqlParameterAlertId = New System.Data.SqlClient.SqlParameter("@AlertId", SqlDbType.VarChar, 1000)

                SqlParameterUserCode.Value = UserCode
                SqlParameterAssignedEmployee.Value = AssignedEmployee
                SqlParameterRole.Value = Role
                SqlParameterProjectManager.Value = ProjectManager
                SqlParameterOffice.Value = Office
                SqlParameterTaskStatus.Value = TaskStatus
                SqlParameterSearchCriteria.Value = SearchCriteria
                SqlParameterAlertId.Value = AlertId

                CompletedTasks = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerJobDetail)(
                                        "EXEC [dbo].[usp_wv_AAMCompleteTempComplete] @UserID,@EmpCode,@Role,@ManagerCode,@Office,@TaskStatus,@Search, @AlertId;",
                        SqlParameterUserCode,
                        SqlParameterAssignedEmployee,
                        SqlParameterRole,
                        SqlParameterProjectManager,
                        SqlParameterOffice,
                        SqlParameterTaskStatus,
                        SqlParameterSearchCriteria,
                        SqlParameterAlertId
                ).ToList

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                CompletedTasks = Nothing
            End Try

            If CompletedTasks Is Nothing Then CompletedTasks = New List(Of Classes.AlertsAndAssignmentsManagerJobDetail)

            Return CompletedTasks

        End Function
        Public Function UploadAttachmentToProofHQ(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext,
                                                  ByVal EmployeeCode As String, ByVal DocumentID As Long, ByVal AlertID As Integer) As Boolean

            'objects
            Dim Agency As AdvantageFramework.Database.Entities.Agency
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim ProofHQUrl As String = ""
            Dim ByteFile() As Byte = Nothing
            Dim ProofHQFileID As Integer = 0
            Dim ParentProofHQFileID As Integer = 0
            Dim DocumentIDs() As Integer = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim ParentDocument As AdvantageFramework.Database.Entities.Document = Nothing
            Dim ProofHQUploaded As Boolean = False

            Try

                Agency = Nothing
                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                    If Document IsNot Nothing Then

                        Try

                            DocumentIDs = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, AlertID).Where(Function(Entity) Entity.DocumentID <> DocumentID).Select(Function(Entity) Entity.DocumentID).ToArray

                        Catch ex As Exception
                            DocumentIDs = Nothing
                        End Try

                        If DocumentIDs IsNot Nothing Then

                            Try

                                Documents = (From Entity In AdvantageFramework.Database.Procedures.Document.Load(DbContext).ToList
                                             Where DocumentIDs.Any(Function(DocID) DocID = Entity.ID) AndAlso
                                               Entity.FileName = Document.FileName
                                             Select Entity).ToList()

                            Catch ex As Exception
                                Documents = Nothing
                            End Try

                            If Documents IsNot Nothing Then

                                Try

                                    ParentDocument = Documents.Where(Function(Entity) Entity.ProofHQFileID.GetValueOrDefault(0) > 0).OrderBy(Function(Entity) Entity.ID).FirstOrDefault

                                Catch ex As Exception
                                    ParentDocument = Nothing
                                End Try

                                If ParentDocument IsNot Nothing Then

                                    ParentProofHQFileID = ParentDocument.ProofHQFileID.GetValueOrDefault(0)

                                End If

                            End If

                        End If

                        If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile) Then

                            If ParentProofHQFileID > 0 Then

                                ProofHQUploaded = AdvantageFramework.ProofHQ.UploadNewVersion(DbContext, DataContext, EmployeeCode, ByteFile, ParentProofHQFileID, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID)

                            Else

                                ProofHQUploaded = AdvantageFramework.ProofHQ.UploadFile(DbContext, DataContext, EmployeeCode, ByteFile, Document.FileName, Document.FileName, "", "", 0, ProofHQUrl, ProofHQFileID)

                            End If

                            If ProofHQUploaded Then

                                Document.ProofHQUrl = ProofHQUrl
                                Document.ProofHQFileID = ProofHQFileID

                                AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                            End If

                        End If

                    End If

                End If

                Return True

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function IsEmployeeACC(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Try

                Dim i As Integer = 0

                i = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM (SELECT EMP_CODE FROM ALERT_RCPT WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0) UNION SELECT EMP_CODE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0)) AS A;", AlertID, EmployeeCode)).FirstOrDefault

                Return i > 0

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function IsEmployeeAnAssignee(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Try

                Dim i As Integer = 0

                i = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM (SELECT EMP_CODE FROM ALERT_RCPT WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND CURRENT_NOTIFY = 1 UNION SELECT EMP_CODE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND CURRENT_NOTIFY = 1) AS A;", AlertID, EmployeeCode)).FirstOrDefault

                Return i > 0

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function IsEmployeeARecipient(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            Try

                Dim i As Integer = 0

                i = DataContext.ExecuteQuery(Of Integer)(String.Format("SELECT COUNT(1) FROM (SELECT EMP_CODE FROM ALERT_RCPT WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' UNION SELECT EMP_CODE FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = {0} AND EMP_CODE = '{1}') AS A;", AlertID, EmployeeCode)).FirstOrDefault

                Return i > 0

            Catch ex As Exception
                Return False
            End Try

        End Function
        Public Function CopyAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                  ByVal CopyFromAlertID As Integer,
                                  ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                  ByVal AlertTemplateID As Integer, ByVal AlertStateID As Integer, ByVal AssignedEmployeeCode As String,
                                  ByVal BoardID As Integer, SprintID As Integer, BoardStateID As Integer,
                                  ByVal CopyComments As Boolean,
                                  ByVal CopyAttachments As Boolean,
                                  ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                  ByVal SecuritySession As AdvantageFramework.Security.Session) As Integer

            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim DocumentPrefix As String = ""
            Dim NewDocument As AdvantageFramework.Database.Entities.Document = Nothing
            Dim CopyFromAlert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertCommentGeneratedDate As Date = Nothing
            Dim NewAlertID As Integer = 0
            Dim IsCopyingRoutedAssignment As Boolean = False
            Dim AddBoardInfo As Boolean = False
            Dim NewAlert As New AdvantageFramework.Database.Entities.Alert
            Dim IsTask As Boolean = False
            Dim Comment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim RightNow As DateTime = Now
            Dim AlertState As AdvantageFramework.Database.Entities.AlertState = Nothing
            Dim ErrorMessage As String = String.Empty
            Dim IsProof As Boolean = False

            If BoardStateID = 0 Then BoardStateID = -1

            If CopyFromAlertID > 0 Then

                CopyFromAlert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, CopyFromAlertID)

                If CopyFromAlert IsNot Nothing Then

                    IsProof = CopyFromAlert.AlertCategoryID = 79

                    If CopyFromAlert.AlertLevel = "BRD" Then

                        Dim NewTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing

                        NewTask = AdvantageFramework.ProjectSchedule.CopyTask(DbContext, CopyFromAlert.JobNumber, CopyFromAlert.JobComponentNumber, CopyFromAlert.TaskSequenceNumber,
                                                                              JobNumber, JobComponentNumber, True, False, True, True)

                        If NewTask IsNot Nothing Then

                            IsTask = True

                            Try

                                NewAlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ALERT_ID FROM ALERT WHERE ALERT_LEVEL = 'BRD' AND JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND TASK_SEQ_NBR = {2};",
                                                                                                   NewTask.JobNumber, NewTask.JobComponentNumber, NewTask.SequenceNumber)).SingleOrDefault
                            Catch ex As Exception
                                NewAlertID = 0
                            End Try
                            If NewAlertID > 0 Then

                                Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

                                Board = AdvantageFramework.Database.Procedures.Board.LoadByBoardID(DbContext, BoardID)

                                If Board IsNot Nothing Then

                                    Dim BoardHeader As AdvantageFramework.Database.Entities.BoardHeader = Nothing
                                    BoardHeader = AdvantageFramework.Database.Procedures.BoardHeader.LoadByBoardID(DbContext, Board.BoardHeaderID)

                                    If BoardHeader IsNot Nothing Then

                                        If BoardHeader.ExcludeTasks IsNot Nothing AndAlso BoardHeader.ExcludeTasks = True Then

                                            BoardID = 0
                                            SprintID = 0

                                        End If

                                    End If

                                End If

                                If BoardID > 0 AndAlso SprintID > 0 Then

                                    AddBoardInfo = True

                                End If

                            End If

                        End If

                    Else

                        Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
                        Dim ExistingAlertSequenceNumber As Short = 0
                        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

                        Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)
                        NewAlert = CopyFromAlert.DuplicateEntity

                        'NewAlert.IsDraft = True
                        NewAlert.JobNumber = JobNumber
                        NewAlert.JobComponentNumber = JobComponentNumber
                        NewAlert.BacklogSequenceNumber = Nothing
                        NewAlert.EpicID = Nothing
                        NewAlert.GeneratedDate = Now
                        NewAlert.UserCode = DbContext.UserCode

                        Try

                            NewAlert.EmployeeCode = AdvantageFramework.Database.Procedures.EmployeeView.LoadByUserCode(DbContext, DbContext.UserCode).Code

                        Catch ex As Exception
                            NewAlert.EmployeeCode = Nothing
                        End Try

                        NewAlert.IsDraft = False

                        If BoardID > 0 AndAlso SprintID > 0 Then

                            AddBoardInfo = True
                            NewAlert.BoardStateID = BoardStateID

                        End If
                        If AlertTemplateID > 0 AndAlso AlertStateID > 0 Then

                            IsCopyingRoutedAssignment = True

                            NewAlert.AlertAssignmentTemplateID = AlertTemplateID
                            NewAlert.AlertStateID = AlertStateID

                        Else

                            NewAlert.AlertAssignmentTemplateID = Nothing
                            NewAlert.AlertStateID = Nothing
                            NewAlert.AssignedEmployeeEmployeeCode = Nothing
                            NewAlert.AssignedEmployeeFullName = Nothing

                        End If

                        NewAlert.AssignmentCompleted = Nothing

                        If Job IsNot Nothing Then

                            NewAlert.ClientCode = Job.ClientCode
                            NewAlert.DivisionCode = Job.DivisionCode
                            NewAlert.ProductCode = Job.ProductCode

                        End If

                        Dim NewAlertSequenceNumber As Short = 0
                        Try


                            NewAlertSequenceNumber = DbContext.Database.SqlQuery(Of Short)(String.Format("SELECT ISNULL(MAX(ALERT_SEQ_NBR), 0) FROM ALERT WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};",
                                                                                                         JobNumber, JobComponentNumber)).SingleOrDefault

                        Catch ex As Exception
                            NewAlertSequenceNumber = 0
                        End Try

                        NewAlert.AlertSequenceNumber = NewAlertSequenceNumber + 1

                        If CopyAttachments = False Then NewAlert.AttachmentCount = 0

                        If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, NewAlert) = True Then

                            NewAlertID = NewAlert.ID

                        End If
                        If NewAlertID > 0 AndAlso IsCopyingRoutedAssignment = True Then

                            'Assignees
                            ''''Try

                            ''''    Dim Assignees As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing
                            ''''    'Assignees = (From Entity In AdvantageFramework.AlertSystem.LoadAlertRecipients(DbContext, CopyFromAlertID)
                            ''''    '             Where Entity.IsCurrentAssignee = True).ToList

                            ''''    If Assignees IsNot Nothing AndAlso Assignees.Count > 0 Then

                            ''''        Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
                            ''''        For Each Assignee As AdvantageFramework.DTO.Desktop.AlertRecipient In Assignees

                            ''''            Recipient = New Database.Entities.AlertRecipient

                            ''''            Recipient.AlertID = NewAlert.ID
                            ''''            Recipient.EmployeeCode = Assignee.EmployeeCode
                            ''''            Recipient.EmployeeEmail = Assignee.EmployeeEmail
                            ''''            Recipient.IsNewAlert = True
                            ''''            Recipient.IsCurrentNotify = 1
                            ''''            Recipient.AlertTemplateID = NewAlert.AlertAssignmentTemplateID
                            ''''            Recipient.AlertStateID = NewAlert.AlertStateID

                            ''''            AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient)

                            ''''            Recipient = Nothing

                            ''''        Next

                            ''''    End If

                            ''''Catch ex As Exception
                            ''''End Try

                            If NewAlert IsNot Nothing AndAlso NewAlert.AlertStateID IsNot Nothing AndAlso NewAlert.AlertStateID > 0 Then

                                AlertState = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertStateID(DbContext, NewAlert.AlertStateID)

                            End If
                            If IsProof = True AndAlso IsCopyingRoutedAssignment = True Then

                                If AdvantageFramework.Proofing.CheckForTemplateAssignees(DbContext, NewAlertID, CopyFromAlertID, ErrorMessage) = False Then

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then


                                    End If

                                End If

                            End If

                            If Alert.Assignees IsNot Nothing AndAlso Alert.Assignees.Count > 0 Then

                                ProcessAssignees(DbContext, SecuritySession.User.EmployeeCode, NewAlert, Alert.Assignees.ToList, True, ErrorMessage)

                            End If
                            'If String.IsNullOrWhiteSpace(AssignedEmployeeCode) = False AndAlso AssignedEmployeeCode.ToLower <> "unassigned" Then

                            '    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AssignedEmployeeCode)

                            '    If Employee IsNot Nothing Then

                            '        Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
                            '        Recipient = New Database.Entities.AlertRecipient

                            '        Recipient.AlertID = NewAlert.ID
                            '        Recipient.EmployeeCode = Employee.Code
                            '        Recipient.EmployeeEmail = Employee.Email
                            '        Recipient.IsNewAlert = True
                            '        Recipient.IsCurrentNotify = 1
                            '        Recipient.AlertTemplateID = NewAlert.AlertAssignmentTemplateID
                            '        Recipient.AlertStateID = NewAlert.AlertStateID

                            '        If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient) = True Then

                            '            Comment = New Database.Entities.AlertComment

                            '            Comment.AlertID = NewAlert.ID
                            '            Comment.UserCode = DbContext.UserCode
                            '            Comment.GeneratedDate = Now
                            '            If AlertState IsNot Nothing Then

                            '                Comment.Comment = String.Format("{0} | {1} | ", AlertState.Name.ToUpper, Employee.ToString)

                            '            Else

                            '                Comment.Comment = String.Format("{0} | ", Employee.ToString)

                            '            End If
                            '            Comment.HasEmailBeenSent = False
                            '            Comment.AssignedEmployeeCode = Employee.Code
                            '            Comment.AlertAssignmentTemplateID = NewAlert.AlertAssignmentTemplateID
                            '            Comment.AlertStateID = NewAlert.AlertStateID
                            '            Comment.CustodyStart = Comment.GeneratedDate

                            '            AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment)

                            '        End If

                            '    End If

                            'Else

                            '    Comment = New Database.Entities.AlertComment

                            '    Comment.AlertID = NewAlert.ID
                            '    Comment.UserCode = DbContext.UserCode
                            '    Comment.GeneratedDate = Now
                            '    Comment.HasEmailBeenSent = False
                            '    Comment.AlertAssignmentTemplateID = NewAlert.AlertAssignmentTemplateID
                            '    Comment.AlertStateID = NewAlert.AlertStateID

                            '    If AlertState IsNot Nothing Then

                            '        Comment.Comment = String.Format("{0} | {1} |", AlertState.Name.ToUpper, "UNASSIGNED")

                            '    Else

                            '        Comment.Comment = String.Format("{0} | ", "UNASSIGNED")

                            '    End If

                            '    AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment)

                            'End If

                        End If

                    End If
                    If NewAlertID > 0 Then

                        If AddBoardInfo = True Then

                            If IsTask = True Then

                                Try

                                    NewAlert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, NewAlertID)

                                Catch ex As Exception
                                    NewAlert = Nothing
                                End Try
                                If NewAlert IsNot Nothing AndAlso BoardStateID > 0 Then

                                    NewAlert.BoardStateID = BoardStateID

                                    AdvantageFramework.Database.Procedures.Alert.Update(DbContext, NewAlert)

                                End If

                            End If

                            Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing

                            SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, SprintID, NewAlertID)

                            If SprintDetail Is Nothing Then

                                SprintDetail = New Database.Entities.SprintDetail
                                SprintDetail.AlertID = NewAlertID
                                SprintDetail.SprintHeaderID = SprintID

                                AdvantageFramework.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail)

                            End If

                        End If

                        ''Recipients
                        'Dim NewRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
                        'Dim NewClientContact As AdvantageFramework.Database.Entities.ClientPortalAlertRecipient = Nothing

                        'For Each AlertRecipient In CopyFromAlert.AlertRecipients

                        '    NewRecipient = New Database.Entities.AlertRecipient

                        '    NewRecipient.AlertID = NewAlertID
                        '    NewRecipient.ID = AlertRecipient.ID
                        '    NewRecipient.EmployeeCode = AlertRecipient.EmployeeCode
                        '    NewRecipient.EmployeeEmail = AlertRecipient.EmployeeEmail
                        '    NewRecipient.IsNewAlert = 1
                        '    NewRecipient.IsConceptShareReviewer = AlertRecipient.IsConceptShareReviewer
                        '    NewRecipient.IsCurrentNotify = AlertRecipient.IsCurrentNotify

                        '    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, NewRecipient)

                        '    NewRecipient = Nothing

                        'Next
                        'For Each AlertRecipient In CopyFromAlert.AlertRecipientDismisseds

                        '    NewRecipient = New Database.Entities.AlertRecipient

                        '    NewRecipient.AlertID = NewAlertID
                        '    NewRecipient.ID = AlertRecipient.ID
                        '    NewRecipient.EmployeeCode = AlertRecipient.EmployeeCode
                        '    NewRecipient.EmployeeEmail = AlertRecipient.EmployeeEmail
                        '    NewRecipient.IsNewAlert = 1
                        '    NewRecipient.IsConceptShareReviewer = AlertRecipient.IsConceptShareReviewer
                        '    NewRecipient.IsCurrentNotify = AlertRecipient.IsCurrentNotify

                        '    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, NewRecipient)

                        '    NewRecipient = Nothing

                        'Next
                        'For Each ClientContact In CopyFromAlert.ClientPortalAlertRecipients

                        '    NewClientContact = New Database.Entities.ClientPortalAlertRecipient

                        '    NewClientContact.AlertID = NewAlertID
                        '    NewClientContact.ClientContactID = ClientContact.ClientContactID
                        '    NewClientContact.EmailAddress = ClientContact.EmailAddress
                        '    NewClientContact.IsNewAlert = 1
                        '    NewClientContact.IsConceptShareReviewer = ClientContact.IsConceptShareReviewer
                        '    NewClientContact.AlertRecipientID = ClientContact.AlertRecipientID
                        '    AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Insert(DbContext, NewClientContact)

                        '    NewRecipient = Nothing

                        'Next
                        'For Each ClientContact In CopyFromAlert.ClientPortalAlertRecipientDismisseds

                        '    NewClientContact = New Database.Entities.ClientPortalAlertRecipient

                        '    NewClientContact.AlertID = NewAlertID
                        '    NewClientContact.ClientContactID = ClientContact.ClientContactID
                        '    NewClientContact.EmailAddress = ClientContact.EmailAddress
                        '    NewClientContact.IsNewAlert = 1
                        '    NewClientContact.IsConceptShareReviewer = ClientContact.IsConceptShareReviewer
                        '    NewClientContact.AlertRecipientID = ClientContact.AlertRecipientID
                        '    AdvantageFramework.Database.Procedures.ClientPortalAlertRecipient.Insert(DbContext, NewClientContact)

                        '    NewRecipient = Nothing

                        'Next

                        'Comments
                        If CopyComments = True Then

                            For Each AlertComment In CopyFromAlert.AlertComments

                                'AlertCommentGeneratedDate = AlertComment.GeneratedDate.GetValueOrDefault(Now)
                                AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, NewAlertID, AlertComment.UserCode, AlertComment.GeneratedDate, AlertComment.Comment, False, Nothing)

                            Next

                        End If

                        ''''''Dim TrackingComment As New AdvantageFramework.Database.Entities.AlertComment

                        ''''''TrackingComment.AlertID = NewAlertID
                        ''''''TrackingComment.UserCode = DbContext.UserCode
                        ''''''TrackingComment.GeneratedDate = DateTime.Now
                        ''''''TrackingComment.Comment = String.Format("Copied from: {0}/{1}/{2} - {3}", CopyFromAlert.JobNumber.ToString.PadLeft(6, "0"),
                        ''''''                                                                          CopyFromAlert.JobComponentNumber.ToString.PadLeft(2, "0"),
                        ''''''                                                                          If(CopyFromAlert.AlertSequenceNumber Is Nothing, CopyFromAlert.ID, CopyFromAlert.AlertSequenceNumber),
                        ''''''                                                                          CopyFromAlert.Subject)

                        ''''''AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, TrackingComment)

                        'Attachments
                        If CopyAttachments = True Then

                            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                            Dim Documents As New Generic.List(Of AdvantageFramework.Database.Entities.Document)
                            Dim Attachments As New Generic.List(Of Email.Classes.Attachment)
                            Dim CopiedFromText As String = ""
                            Dim ByteFile As Byte() = Nothing
                            Dim FileExists As Boolean = False
                            Dim DocumentSource As AdvantageFramework.FileSystem.DocumentSource = FileSystem.DocumentSource.Alert
                            Dim NumberCopied As Integer = 0

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            Try

                                If CopyFromAlert.AlertSequenceNumber IsNot Nothing AndAlso CopyFromAlert.AlertSequenceNumber > 0 Then

                                    CopiedFromText = String.Format("(Copied from {0}/{1}/{2} - {3})", CopyFromAlert.JobNumber, CopyFromAlert.JobComponentNumber,
                                                                                                      CopyFromAlert.AlertSequenceNumber, CopyFromAlert.Subject)

                                Else

                                    CopiedFromText = String.Format("(Copied from {0} - {1})", CopyFromAlert.ID, CopyFromAlert.Subject)

                                End If

                            Catch ex As Exception
                                CopiedFromText = ""
                            End Try

                            For Each AlertAttachment In CopyFromAlert.AlertAttachments

                                DocumentPrefix = ""
                                Document = Nothing
                                ByteFile = Nothing
                                FileExists = False
                                NewDocument = Nothing

                                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, AlertAttachment.DocumentID)

                                If Document IsNot Nothing Then

                                    If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists) Then

                                        If ByteFile IsNot Nothing Then

                                            If Document.FileSystemFileName.StartsWith("d_") Then

                                                DocumentPrefix = "d_"
                                                DocumentSource = FileSystem.DocumentSource.DocumentUpload

                                            Else

                                                DocumentPrefix = "a_"
                                                DocumentSource = FileSystem.DocumentSource.Alert

                                            End If

                                            NewDocument = New AdvantageFramework.Database.Entities.Document

                                            NewDocument.DbContext = DbContext
                                            NewDocument.FileName = Document.FileName
                                            NewDocument.MIMEType = Document.MIMEType

                                            If String.IsNullOrWhiteSpace(NewDocument.MIMEType) = True OrElse NewDocument.MIMEType.Contains("unknown") = True Then

                                                NewDocument.MIMEType = AdvantageFramework.FileSystem.GetMIMETypeByExtension(AdvantageFramework.StringUtilities.ParseLastDot(NewDocument.FileName))

                                            End If

                                            If String.IsNullOrWhiteSpace(Document.Description) = True Then

                                                NewDocument.Description = CopiedFromText

                                            Else

                                                NewDocument.Description = Document.Description & "  " & CopiedFromText

                                            End If

                                            NewDocument.Keywords = Document.Keywords
                                            NewDocument.UploadedDate = Now
                                            NewDocument.UserCode = DbContext.UserCode
                                            NewDocument.FileSize = Document.FileSize
                                            NewDocument.IsPrivate = Document.IsPrivate.GetValueOrDefault(Nothing)
                                            NewDocument.DocumentTypeID = Document.DocumentTypeID.GetValueOrDefault(Nothing)

                                            AdvantageFramework.FileSystem.Add(Agency, NewDocument.FileName, NewDocument.Description, NewDocument.Keywords, DbContext.UserCode,
                                                                              "Copied Alert", "Copied Document", DocumentSource, Nothing, ByteFile, NewDocument.FileSystemFileName, Nothing)

                                            If NewDocument.FileSystemFileName IsNot Nothing Then

                                                If AdvantageFramework.Database.Procedures.Document.Insert(DbContext, NewDocument) Then

                                                    AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, NewAlertID, AlertAttachment.UserCode, AlertAttachment.GeneratedDate,
                                                                                                                  AlertAttachment.HasEmailBeenSent, NewDocument.ID, Nothing)

                                                    Documents.Add(NewDocument)
                                                    NumberCopied += 1

                                                End If

                                            End If

                                        End If

                                    End If

                                End If

                            Next

                            AdvantageFramework.DocumentManager.AddToAttachments(Agency, Documents, Attachments)

                            If NewAlert IsNot Nothing AndAlso NumberCopied > 0 Then

                                NewAlert.AttachmentCount = NumberCopied

                                AdvantageFramework.Database.Procedures.Alert.Update(DbContext, NewAlert)

                            End If

                        End If

                        Dim ChecklistHeaders As Generic.List(Of AdvantageFramework.Database.Entities.ChecklistHeader) = Nothing
                        Dim ChecklistDetails As Generic.List(Of AdvantageFramework.Database.Entities.ChecklistDetail) = Nothing
                        Dim ChecklistHeaderList As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) = Nothing
                        Dim ChecklistHdr As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader = Nothing

                        ChecklistHeaders = AdvantageFramework.Database.Procedures.ChecklistHeader.LoadByAlertID(DbContext, CopyFromAlert.ID).ToList

                        If ChecklistHeaders IsNot Nothing AndAlso ChecklistHeaders.Count > 0 Then

                            ChecklistHeaderList = New List(Of DTO.Desktop.Alert.ChecklistHeader)

                            For Each ChecklistHeader In ChecklistHeaders

                                Dim header As AdvantageFramework.Database.Entities.ChecklistHeader = Nothing
                                header = New AdvantageFramework.Database.Entities.ChecklistHeader

                                header.AlertID = NewAlertID
                                header.Description = ChecklistHeader.Description
                                header.CreatedBy = SecuritySession.User.EmployeeCode
                                header.CreatedDate = Now.Date

                                AdvantageFramework.Database.Procedures.ChecklistHeader.Insert(DbContext, header)

                                If header.ID > 0 Then

                                    ChecklistDetails = AdvantageFramework.Database.Procedures.ChecklistDetail.LoadByChecklistID(DbContext, ChecklistHeader.ID).ToList

                                    If ChecklistDetails IsNot Nothing AndAlso ChecklistDetails.Count > 0 Then

                                        For Each ChecklistDetail In ChecklistDetails

                                            Dim detail As AdvantageFramework.Database.Entities.ChecklistDetail = Nothing
                                            detail = New AdvantageFramework.Database.Entities.ChecklistDetail

                                            detail.ChecklistID = header.ID
                                            detail.Description = ChecklistDetail.Description
                                            detail.SortOrder = ChecklistDetail.SortOrder
                                            detail.CreatedBy = SecuritySession.User.EmployeeCode
                                            detail.CreatedDate = Now.Date

                                            AdvantageFramework.Database.Procedures.ChecklistDetail.Insert(DbContext, detail)

                                        Next

                                    End If

                                End If

                            Next

                        End If


                    End If

                End If

            End If

            Return NewAlertID

        End Function
        Public Function ProcessAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal EmployeeCode As String,
                                         ByVal AlertEntity As AdvantageFramework.Database.Entities.Alert,
                                         ByVal AssigneesEmpCodes As Generic.List(Of String),
                                         ByVal IsCreatingNewAssignment As Boolean,
                                         ByRef Message As String) As Boolean

            Dim AlertView As AdvantageFramework.DTO.Desktop.Alert = Nothing
            Dim StateChanged As Boolean = False

            AlertView = LoadAlertView(DbContext, EmployeeCode, AlertEntity.ID, 0, 0, 0, False)

            If AlertView IsNot Nothing Then

                ProcessAssignees(DbContext, AlertView, AssigneesEmpCodes, False, IsCreatingNewAssignment, StateChanged, Message)

            End If

            Return True

        End Function
        Public Function ProcessAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                         ByVal AssigneesEmpCodes As Generic.List(Of String),
                                         ByVal AddUpdatedComment As Boolean,
                                         ByVal IsCreatingNewAssignment As Boolean,
                                         ByRef StateChanged As Boolean,
                                         ByRef Message As String) As Boolean

            Dim Saved As Boolean = True
            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Comment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim EmployeeNames As New Generic.List(Of String)
            Dim CurrentAssigneesEmpCodes As Generic.List(Of String) = Nothing
            Dim StateName As String = String.Empty
            Dim RightNow As DateTime = Now
            Dim IsRouted As Boolean = True
            Dim AlertEntityTemplateID As Integer = 0
            Dim AlertEntityStateID As Integer = 0
            Dim AddSendAssignmentComment As Boolean = False
            Dim AddGroupComment As Boolean = False
            Dim AssigneeCommentAdded As Boolean = False
            Dim HasAssigneeChangee As Boolean = False
            Dim IsProof As Boolean = False
            Dim ProofingMovedToNextState As Boolean = False

            Try

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                If AlertEntity IsNot Nothing Then

                    If Alert.IsWorkItem = True AndAlso
                        (Alert.AlertAssignmentTemplateID Is Nothing OrElse String.IsNullOrWhiteSpace(Alert.AlertAssignmentTemplateID) = True) Then

                        IsRouted = False

                    End If
                    If Alert.SendAssignmentComment IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Alert.SendAssignmentComment) = False Then

                        AddSendAssignmentComment = True

                    End If

                    IsProof = AlertEntity.AlertCategoryID = 79

                    'If AlertEntity.AlertStateID IsNot Nothing Then

                    '    StateName = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(ALERT_STATE_NAME, '') FROM ALERT_STATES WITH(NOLOCK) WHERE ALERT_STATE_ID = {0};", AlertEntity.AlertStateID)).SingleOrDefault()

                    'End If

                    If Alert.AlertLevel.ToUpper = "BRD" OrElse Alert.AlertCategoryID = 71 Then

                        Dim TaskEmployees As Generic.List(Of String) = Nothing

                        If Alert.Assignees IsNot Nothing AndAlso Alert.Assignees.Count > 0 Then

                            TaskEmployees = Alert.Assignees.ToList

                        Else

                            TaskEmployees = New List(Of String)

                        End If
                        If ProcessTaskEmployees(DbContext, AlertEntity, TaskEmployees, RightNow, Alert.SendAssignmentComment, Message) = False Then

                            If String.IsNullOrWhiteSpace(Message) = False Then

                                Saved = False

                            End If

                        End If

                    Else

                        If IsRouted = True Then

                            Try

                                If Alert.AlertStateID <> AlertEntity.AlertStateID Then

                                    StateChanged = True

                                End If

                            Catch ex As Exception
                            End Try

                            AlertEntity.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID
                            AlertEntity.AlertStateID = Alert.AlertStateID

                            Saved = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, AlertEntity)

                        Else

                            'Need to do anything for non-routed only?
                            Saved = True

                        End If
                        If Saved = True Then

                            If AlertEntity.AlertStateID IsNot Nothing Then

                                StateName = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(ALERT_STATE_NAME, '') FROM ALERT_STATES WITH(NOLOCK) WHERE ALERT_STATE_ID = {0};", AlertEntity.AlertStateID)).SingleOrDefault()

                            End If

                            Dim Added As Boolean = False
                            Dim Updated As Boolean = False
                            Dim IsUnassigned As Boolean = False
                            Dim ErrorMessage As String = String.Empty
                            Dim ErrorMessages As New Generic.List(Of String)

                            If AssigneesEmpCodes Is Nothing Then AssigneesEmpCodes = New List(Of String)

                            If AssigneesEmpCodes.Count > 0 Then

                                Dim Recipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
                                Dim DismissedRecipient As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing

                                For Each EmployeeCode As String In AssigneesEmpCodes

                                    Recipient = Nothing
                                    DismissedRecipient = Nothing
                                    Employee = Nothing
                                    Added = False
                                    Updated = False
                                    Comment = Nothing

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                                    If IsRouted = True Then

                                        Recipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadAssigneeByAlertIDEmployeeCodeTemplateState(DbContext, AlertEntity, EmployeeCode)
                                        DismissedRecipient = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadAssigneeByAlertIDEmployeeCodeTemplateState(DbContext, AlertEntity, EmployeeCode)

                                    Else

                                        Recipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadAssigneeByAlertIDAndEmployeeCode(DbContext, Alert.ID, EmployeeCode)
                                        DismissedRecipient = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadAssigneeByAlertIDAndEmployeeCode(DbContext, Alert.ID, EmployeeCode)

                                    End If

                                    If Employee IsNot Nothing Then

                                        If Recipient Is Nothing Then

                                            Recipient = New AdvantageFramework.Database.Entities.AlertRecipient

                                            If DismissedRecipient IsNot Nothing Then 'Move back to active

                                                If Alert.AlertStateID.GetValueOrDefault(0) <> DismissedRecipient.AlertStateID.GetValueOrDefault(0) OrElse
                                                       Alert.AlertAssignmentTemplateID.GetValueOrDefault(0) <> DismissedRecipient.AlertTemplateID.GetValueOrDefault(0) Then

                                                    Recipient.AlertID = DismissedRecipient.AlertID
                                                    Recipient.ID = 0
                                                    Recipient.EmployeeCode = DismissedRecipient.EmployeeCode
                                                    Recipient.EmployeeEmail = DismissedRecipient.EmployeeEmail
                                                    Recipient.ProcessedDate = Nothing
                                                    Recipient.IsNewAlert = 1
                                                    Recipient.HasBeenRead = Nothing
                                                    Recipient.IsCurrentRecipient = DismissedRecipient.IsCurrentRecipient
                                                    Recipient.IsCurrentNotify = 1
                                                    Recipient.AlertTemplateID = AlertEntity.AlertAssignmentTemplateID
                                                    Recipient.AlertStateID = AlertEntity.AlertStateID
                                                    Recipient.HoursAllowed = DismissedRecipient.HoursAllowed

                                                    Added = AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient)

                                                    If Added = True Then

                                                        EmployeeNames.Add(Employee.ToString)
                                                        AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Delete(DbContext, DismissedRecipient)

                                                    End If

                                                End If

                                            Else

                                                Recipient.AlertID = Alert.ID
                                                Recipient.ID = 0
                                                Recipient.EmployeeCode = EmployeeCode
                                                Recipient.EmployeeEmail = Employee.Email
                                                Recipient.ProcessedDate = Nothing
                                                Recipient.IsNewAlert = 1
                                                Recipient.HasBeenRead = Nothing
                                                Recipient.IsCurrentNotify = 1
                                                Recipient.AlertTemplateID = AlertEntity.AlertAssignmentTemplateID
                                                Recipient.AlertStateID = AlertEntity.AlertStateID
                                                Recipient.HoursAllowed = AlertEntity.HoursAllowed

                                                Added = AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient)

                                                If Added = True Then

                                                    EmployeeNames.Add(Employee.ToString)

                                                End If

                                            End If

                                        Else

                                            If IsRouted = True AndAlso (StateChanged = True OrElse AssigneeIsInCurrentState(DbContext, Alert.ID, EmployeeCode) = False) Then

                                                Recipient.AlertTemplateID = AlertEntity.AlertAssignmentTemplateID
                                                Recipient.AlertStateID = AlertEntity.AlertStateID

                                                Recipient.ProcessedDate = Nothing
                                                Recipient.IsNewAlert = 1

                                                Updated = AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, Recipient)

                                                If Updated = True Then

                                                    EmployeeNames.Add(Employee.ToString)

                                                End If

                                            End If

                                        End If

                                        If Added = True OrElse StateChanged = True OrElse Updated = True Then

                                            Comment = New Database.Entities.AlertComment

                                            If IsRouted = True Then

                                                Try

                                                    AddAssigneeToTemplate(DbContext, AlertEntity.ID, AlertEntity.AlertAssignmentTemplateID,
                                                                          AlertEntity.AlertStateID, Employee.Code, ErrorMessage)

                                                Catch ex As Exception
                                                End Try

                                                If AssigneeHasCommentAtCurrentState(DbContext, AlertEntity.ID, Employee.Code) = False OrElse
                                                       StateChanged = True OrElse Added = True Then

                                                    Comment.AlertID = AlertEntity.ID
                                                    Comment.UserCode = DbContext.UserCode
                                                    Comment.GeneratedDate = RightNow

                                                    If String.IsNullOrWhiteSpace(Alert.SendAssignmentComment) = True OrElse IsProof = True Then

                                                        Comment.Comment = String.Format("{0} | {1}", StateName.ToUpper, Employee.ToString)

                                                    Else

                                                        Comment.Comment = String.Format("{0} | {1} | {2}", StateName.ToUpper, Employee.ToString, Alert.SendAssignmentComment)

                                                    End If

                                                    Comment.HasEmailBeenSent = False
                                                    Comment.AssignedEmployeeCode = Employee.Code
                                                    Comment.AlertAssignmentTemplateID = AlertEntity.AlertAssignmentTemplateID
                                                    Comment.AlertStateID = AlertEntity.AlertStateID
                                                    Comment.CustodyStart = Comment.GeneratedDate

                                                    If String.IsNullOrWhiteSpace(Alert.SendAssignmentComment) = True Then

                                                        Comment.IsSystem = True

                                                    End If

                                                    If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then

                                                        AssigneeCommentAdded = True

                                                    End If

                                                End If

                                            Else

                                                Comment.AlertID = AlertEntity.ID
                                                Comment.UserCode = DbContext.UserCode
                                                Comment.GeneratedDate = RightNow

                                                If String.IsNullOrWhiteSpace(Alert.SendAssignmentComment) = False Then

                                                    Comment.Comment = String.Format("{0} | {1}", Employee.ToString, Alert.SendAssignmentComment)

                                                Else

                                                    Comment.Comment = String.Format("{0}", Employee.ToString)

                                                End If

                                                Comment.HasEmailBeenSent = False
                                                Comment.AssignedEmployeeCode = Employee.Code
                                                Comment.CustodyStart = Comment.GeneratedDate

                                                If String.IsNullOrWhiteSpace(Alert.SendAssignmentComment) = True Then

                                                    Comment.IsSystem = True

                                                End If
                                                If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then

                                                    AssigneeCommentAdded = True

                                                End If

                                            End If

                                        End If

                                    End If

                                Next
                                If AddUpdatedComment = True AndAlso AssigneeCommentAdded = False Then

                                    AddAssignmentUpdatedComment(DbContext, AlertEntity, IsRouted, RightNow, Alert.SendAssignmentComment, False)

                                End If

                                CheckForRemovedAssignees(DbContext, AlertEntity, AssigneesEmpCodes, RightNow)

                            Else

                                CheckForRemovedAssignees(DbContext, AlertEntity, AssigneesEmpCodes, RightNow)

                                Try

                                    IsUnassigned = AddAssignmentUpdatedComment(DbContext, AlertEntity, IsRouted, RightNow, Alert.SendAssignmentComment, True)

                                Catch ex As Exception
                                End Try

                            End If
                            If IsProof = True Then

                                If IsCreatingNewAssignment = False Then

                                    If AdvantageFramework.AlertSystem.IsUnassigned(DbContext, AlertEntity.ID) = False Then

                                        If AdvantageFramework.Proofing.MoveToNextState(DbContext, AlertEntity.ID) = True Then

                                            If StateChanged = False Then StateChanged = True

                                        End If

                                        Saved = True

                                    End If

                                Else

                                    'If IsRouted = True Then

                                    '    If AdvantageFramework.Proofing.CheckForTemplateAssignees(DbContext, AlertEntity.ID, ErrorMessage) = False Then

                                    '        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                    '            ErrorMessages.Add(ErrorMessage)

                                    '        End If

                                    '    End If

                                    'End If

                                End If

                            End If
                            'Need this at all?
                            If (StateChanged = True AndAlso (Added = True OrElse Updated = True)) OrElse IsUnassigned = True Then

                                UpdateCustodyEnd(DbContext, AlertEntity.ID, RightNow)

                            End If
                        End If
                        If (IsRouted = True AndAlso StateChanged = True) Then

                            ClearNonCurrentState(DbContext, AlertEntity.ID)

                        End If
                        If IsProof = True Then

                            CleanupProofingActiveAssignees(DbContext, AlertEntity.ID)

                        End If
                    End If

                End If

            Catch ex As Exception
                Saved = False
                Message = ex.Message.ToString
            End Try

            Return Saved

        End Function
        Private Function CleanupProofingActiveAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal AlertID As Integer) As Boolean

            Dim Cleaned As Boolean = True
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            AlertIDSqlParameter.Value = AlertID

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_proofing_cleanup_assignees] @ALERT_ID;", AlertIDSqlParameter)

            Catch ex As Exception
                Cleaned = False
            End Try

            Return Cleaned

        End Function

        Private Function AddAssignmentUpdatedComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                                     ByVal IsRouted As Boolean,
                                                     ByVal RightNow As DateTime,
                                                     ByVal SendAssignmentComment As String,
                                                     ByVal IsUnassigned As Boolean) As Boolean

            Dim Comment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim StateName As String = String.Empty
            Dim IsProof As Boolean = False

            IsProof = Alert.AlertCategoryID = 79

            Comment = Nothing
            Comment = New Database.Entities.AlertComment

            Comment.AlertID = Alert.ID
            Comment.UserCode = DbContext.UserCode
            Comment.GeneratedDate = RightNow
            Comment.HasEmailBeenSent = False
            Comment.IsSystem = True

            If IsProof = False Then
            End If

            If IsUnassigned = True Then

                If IsRouted = True Then

                    If Alert.AlertStateID IsNot Nothing AndAlso Alert.AlertStateID > 0 Then

                        StateName = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ALERT_STATE_NAME FROM ALERT_STATES WITH(NOLOCK) WHERE ALERT_STATE_ID = {0};", Alert.AlertStateID)).SingleOrDefault

                    End If
                    If SendAssignmentComment IsNot Nothing AndAlso String.IsNullOrWhiteSpace(SendAssignmentComment) = False Then

                        Comment.Comment = String.Format("{0} | {1} | {2}", StateName.ToUpper, "UNASSIGNED", SendAssignmentComment)

                    Else

                        Comment.Comment = String.Format("{0} | {1}", StateName.ToUpper, "UNASSIGNED")

                    End If

                    Comment.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID
                    Comment.AlertStateID = Alert.AlertStateID

                Else

                    If SendAssignmentComment IsNot Nothing AndAlso String.IsNullOrWhiteSpace(SendAssignmentComment) = False Then

                        Comment.Comment = String.Format("{0} | {1}", "UNASSIGNED", SendAssignmentComment)

                    Else

                        Comment.Comment = String.Format("{0}", "UNASSIGNED")

                    End If

                End If

            Else

                If SendAssignmentComment IsNot Nothing AndAlso String.IsNullOrWhiteSpace(SendAssignmentComment) = False Then

                    Comment.Comment = String.Format("{0} | {1}", "Update Sent to All Assignees", SendAssignmentComment)

                Else

                    Comment.Comment = String.Format("{0}", "Update Sent to All Assignees")

                End If

            End If

            If IsRouted = True Then

                Comment.AlertAssignmentTemplateID = Alert.AlertAssignmentTemplateID
                Comment.AlertStateID = Alert.AlertStateID

            End If

            If String.IsNullOrWhiteSpace(SendAssignmentComment) = True Then

                Comment.IsSystem = True

            End If

            If IsProof = True AndAlso IsUnassigned = True Then

                Return True

            Else

                Return AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment)

            End If

        End Function
        Public Function ProcessTaskEmployees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal AlertEntity As AdvantageFramework.Database.Entities.Alert,
                                             ByVal AlertAssignees As Generic.List(Of String),
                                             ByVal CustodyDate As DateTime,
                                             ByVal SendAssignmentComment As String,
                                             ByRef ErrorMessage As String) As Boolean

            Dim Processed As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Task As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim UpdateReadFlag As Boolean = True
            Dim Comment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim AssigneeCommentAdded As Boolean = False

            ErrorMessage = String.Empty

            Task = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext,
                                                                                                                                 AlertEntity.JobNumber,
                                                                                                                                 AlertEntity.JobComponentNumber,
                                                                                                                                 AlertEntity.TaskSequenceNumber)

            If Task IsNot Nothing Then

                Try

                    Dim CurrentAssignees As Generic.List(Of String) = Nothing
                    Dim TaskEmployee As AdvantageFramework.Database.Entities.JobComponentTaskEmployee = Nothing

                    CurrentAssignees = GetCurrentAssignees(DbContext, AlertEntity.ID)

                    If AlertAssignees IsNot Nothing AndAlso AlertAssignees.Count = 0 Then

                        AlertAssignees = Nothing

                    End If
                    If CurrentAssignees IsNot Nothing AndAlso AlertAssignees IsNot Nothing Then

                        For Each AlertAssigneeEmployeeCode As String In AlertAssignees

                            If CurrentAssignees.Contains(AlertAssigneeEmployeeCode) = False Then

                                'add to db
                                TaskEmployee = Nothing
                                TaskEmployee = New Database.Entities.JobComponentTaskEmployee

                                TaskEmployee.JobNumber = Task.JobNumber
                                TaskEmployee.JobComponentNumber = Task.JobComponentNumber
                                TaskEmployee.SequenceNumber = Task.SequenceNumber
                                TaskEmployee.EmployeeCode = AlertAssigneeEmployeeCode
                                TaskEmployee.Hours = Task.Hours

                                If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, TaskEmployee) Then

                                    Employee = Nothing
                                    'Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AlertAssigneeEmployeeCode)

                                    'If Employee IsNot Nothing Then

                                    '    Comment = Nothing
                                    '    Comment = New AdvantageFramework.Database.Entities.AlertComment

                                    '    Comment.AlertID = AlertEntity.ID
                                    '    Comment.UserCode = DbContext.UserCode
                                    '    Comment.GeneratedDate = CustodyDate
                                    '    If SendAssignmentComment IsNot Nothing AndAlso String.IsNullOrWhiteSpace(SendAssignmentComment) = False Then

                                    '        Comment.Comment = String.Format("{0} | {1}", Employee.ToString, SendAssignmentComment)

                                    '    Else

                                    '        Comment.Comment = String.Format("{0}", Employee.ToString)

                                    '    End If

                                    '    Comment.HasEmailBeenSent = False
                                    '    Comment.AssignedEmployeeCode = Employee.Code
                                    '    Comment.CustodyStart = Comment.GeneratedDate

                                    '    If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then

                                    '        AssigneeCommentAdded = True

                                    '    End If

                                    'End If

                                End If

                            End If

                        Next
                        For Each CurrentAssigneeEmployeeCode As String In CurrentAssignees

                            If AlertAssignees.Contains(CurrentAssigneeEmployeeCode) = False Then

                                'remove from db
                                TaskEmployee = Nothing
                                TaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, Task.JobNumber, Task.JobComponentNumber, Task.SequenceNumber, CurrentAssigneeEmployeeCode)

                                If TaskEmployee IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Delete(DbContext, TaskEmployee) Then

                                        'Update custody end
                                        UpdateCustodyEnd(DbContext, AlertEntity.ID, Nothing, Nothing, CurrentAssigneeEmployeeCode, CustodyDate)

                                    End If

                                End If

                            End If

                        Next

                    ElseIf CurrentAssignees Is Nothing AndAlso AlertAssignees IsNot Nothing Then
                        'Add all to DB

                        For Each AlertAssigneeEmployeeCode As String In AlertAssignees

                            TaskEmployee = Nothing
                            TaskEmployee = New Database.Entities.JobComponentTaskEmployee

                            TaskEmployee.JobNumber = Task.JobNumber
                            TaskEmployee.JobComponentNumber = Task.JobComponentNumber
                            TaskEmployee.SequenceNumber = Task.SequenceNumber
                            TaskEmployee.EmployeeCode = AlertAssigneeEmployeeCode
                            TaskEmployee.Hours = Task.Hours

                            If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Insert(DbContext, TaskEmployee) Then

                                'Add comment
                                'Employee = Nothing
                                'Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, AlertAssigneeEmployeeCode)

                                'If Employee IsNot Nothing Then

                                '    Comment = Nothing
                                '    Comment = New AdvantageFramework.Database.Entities.AlertComment

                                '    Comment.AlertID = AlertEntity.ID
                                '    Comment.UserCode = DbContext.UserCode
                                '    Comment.GeneratedDate = CustodyDate
                                '    Comment.Comment = String.Format("{0} | {1}", Employee.ToString, SendAssignmentComment)
                                '    Comment.HasEmailBeenSent = False
                                '    Comment.AssignedEmployeeCode = Employee.Code
                                '    Comment.CustodyStart = Comment.GeneratedDate

                                '    If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then

                                '        AssigneeCommentAdded = True

                                '    End If

                                'End If

                            End If

                        Next

                    ElseIf CurrentAssignees IsNot Nothing AndAlso AlertAssignees Is Nothing Then

                        'Remove all from DB,
                        'Update custody end
                        AlertAssignees = New List(Of String)
                        For Each CurrentAssigneeEmployeeCode As String In CurrentAssignees

                            If AlertAssignees.Contains(CurrentAssigneeEmployeeCode) = False Then

                                'remove from db
                                TaskEmployee = Nothing
                                TaskEmployee = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeqEmp(DbContext, Task.JobNumber, Task.JobComponentNumber, Task.SequenceNumber, CurrentAssigneeEmployeeCode)

                                If TaskEmployee IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.Delete(DbContext, TaskEmployee) Then

                                        'Clean up
                                        AdvantageFramework.Database.Procedures.SprintEmployee.Delete(DbContext, AlertEntity.ID, TaskEmployee.EmployeeCode)

                                        ''Update custody end
                                        'UpdateCustodyEnd(DbContext, AlertEntity.ID, Nothing, Nothing, CurrentAssigneeEmployeeCode, CustodyDate)

                                    End If

                                End If

                            End If

                        Next

                        UpdateReadFlag = False

                    ElseIf CurrentAssignees Is Nothing AndAlso AlertAssignees Is Nothing Then

                        'Do nothing
                        UpdateReadFlag = False

                    End If
                    If UpdateReadFlag = True Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE JOB_TRAFFIC_DET_EMPS WITH(ROWLOCK) SET READ_ALERT = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2};",
                                                                        AlertEntity.JobNumber, AlertEntity.JobComponentNumber, AlertEntity.TaskSequenceNumber))

                    End If

                    Processed = True
                    ErrorMessage = String.Empty

                Catch ex As Exception
                    Processed = False
                    ErrorMessage = ex.Message.ToString
                End Try

            Else

                Processed = False
                ErrorMessage = "Could not get task"

            End If

            Return Processed

        End Function
        Public Function AddAssigneeToTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertID As Integer,
                                              ByVal AlertTemplateID As Integer,
                                              ByVal AlertStateID As Integer,
                                              ByVal EmployeeCode As String,
                                              ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_assignment_template_add_employee_to_template] {0}, {1}, {2}, '{3}';",
                                                                   AlertID, AlertTemplateID, AlertStateID, EmployeeCode))

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Added = False
            End Try

            Return Added

        End Function
        Public Function RemoveAssigneeFromTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                   ByVal AlertID As Integer,
                                                   ByVal AlertTemplateID As Integer,
                                                   ByVal AlertStateID As Integer,
                                                   ByVal EmployeeCode As String,
                                                   ByRef ErrorMessage As String) As Boolean

            Dim Added As Boolean = True

            Try

                'DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_alert_assignment_template_delete_employee_from_state] {0}, {1}, {2}, '{3}', NULL;",
                '                                                    AlertID, AlertTemplateID, AlertStateID, EmployeeCode))

                DeleteAssigneeFromTemplate(DbContext, DbContext.UserCode, AlertID, AlertTemplateID, AlertStateID, EmployeeCode, 0, ErrorMessage)

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Added = False
            End Try

            Return Added

        End Function
        Public Function CheckForRemovedAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                                 ByVal AssigneesEmpCodes As Generic.List(Of String),
                                                 ByVal CustodyEndDate As DateTime) As Boolean
            'Check for removed assignees
            Dim Checked As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Try

                Dim CurrentAssignees As Generic.List(Of String) = Nothing
                Dim Assignee As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

                CurrentAssignees = GetCurrentAssignees(DbContext, Alert.ID)

                If CurrentAssignees IsNot Nothing AndAlso CurrentAssignees.Count > 0 Then

                    For Each EmployeeCode As String In CurrentAssignees

                        Assignee = Nothing

                        If AssigneesEmpCodes.Contains(EmployeeCode) = False Then

                            If Alert.AlertAssignmentTemplateID Is Nothing AndAlso Alert.AlertStateID Is Nothing Then

                                If DeleteAssignee(DbContext, Alert.ID, EmployeeCode) Then

                                    'Clean up
                                    AdvantageFramework.Database.Procedures.SprintEmployee.Delete(DbContext, Alert.ID, EmployeeCode)

                                End If

                            Else

                                Assignee = AdvantageFramework.Database.Procedures.AlertRecipient.LoadAssigneeByAlertIDEmployeeCodeTemplateState(DbContext, Alert, EmployeeCode)

                                If Assignee IsNot Nothing Then

                                    If DeleteAssignee(DbContext, Alert.ID, EmployeeCode) Then

                                        'Clean up
                                        AdvantageFramework.Database.Procedures.SprintEmployee.Delete(DbContext, Alert.ID, EmployeeCode)

                                    End If

                                Else

                                    UnsetAssigneeState(DbContext, Alert.ID, EmployeeCode) '??

                                End If

                            End If

                            RemoveAssigneeFromTemplate(DbContext, Alert.ID, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, EmployeeCode, ErrorMessage)
                            UpdateCustodyEnd(DbContext, Alert.ID, Alert.AlertAssignmentTemplateID, Alert.AlertStateID, EmployeeCode, CustodyEndDate)

                        End If

                    Next

                End If

            Catch ex As Exception
                Checked = False
            End Try

            Return Checked

        End Function
        Public Function UnsetAssigneeState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal AlertID As Integer,
                                           ByVal EmployeeCode As String) As Boolean

            Dim Unset As Boolean = False
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

            AlertRecipient = AdvantageFramework.Database.Procedures.AlertRecipient.LoadAssigneeByAlertIDAndEmployeeCode(DbContext, AlertID, EmployeeCode)

            If AlertRecipient IsNot Nothing Then

                AlertRecipient.AlertStateID = Nothing

                Unset = AdvantageFramework.Database.Procedures.AlertRecipient.Update(DbContext, AlertRecipient)

            End If

            Return Unset

        End Function
        Public Function MoveAssigneeRecordToDismissed(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal AlertID As Integer,
                                                       ByVal EmployeeCode As String) As Boolean

            Dim Moved As Boolean = False
            Dim Assignee As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim DismissedAssignee As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            Assignee = AdvantageFramework.Database.Procedures.AlertRecipient.LoadAssigneeByAlertIDAndEmployeeCode(DbContext, AlertID, EmployeeCode)
            DismissedAssignee = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadAssigneeByAlertIDAndEmployeeCode(DbContext, AlertID, EmployeeCode)

            If Assignee IsNot Nothing AndAlso DismissedAssignee Is Nothing Then

                DismissedAssignee = New Database.Entities.AlertRecipientDismissed

                DismissedAssignee.AlertID = AlertID
                DismissedAssignee.EmployeeCode = EmployeeCode
                DismissedAssignee.EmployeeEmail = Assignee.EmployeeEmail
                DismissedAssignee.ProcessedDate = Assignee.ProcessedDate
                DismissedAssignee.IsNewAlert = Assignee.IsNewAlert
                DismissedAssignee.HasBeenRead = Assignee.HasBeenRead
                DismissedAssignee.IsCurrentRecipient = Assignee.IsCurrentRecipient
                DismissedAssignee.IsCurrentNotify = Assignee.IsCurrentNotify
                DismissedAssignee.CardSequenceNumber = Assignee.CardSequenceNumber
                DismissedAssignee.IsConceptShareReviewer = Assignee.IsConceptShareReviewer
                DismissedAssignee.AlertTemplateID = Assignee.AlertTemplateID
                DismissedAssignee.AlertStateID = Assignee.AlertStateID
                DismissedAssignee.PercentComplete = Assignee.PercentComplete
                DismissedAssignee.CompletedDate = Assignee.CompletedDate
                DismissedAssignee.TempCompleteDate = Assignee.TempCompleteDate
                DismissedAssignee.HoursAllowed = Assignee.HoursAllowed

                If AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Insert(DbContext, DismissedAssignee) = True Then

                    Moved = AdvantageFramework.Database.Procedures.AlertRecipient.Delete(DbContext, Assignee)

                End If

            ElseIf Assignee IsNot Nothing AndAlso DismissedAssignee IsNot Nothing Then

                DismissedAssignee.AlertID = AlertID
                DismissedAssignee.EmployeeCode = EmployeeCode
                DismissedAssignee.EmployeeEmail = Assignee.EmployeeEmail
                DismissedAssignee.ProcessedDate = Assignee.ProcessedDate
                DismissedAssignee.IsNewAlert = Assignee.IsNewAlert
                DismissedAssignee.HasBeenRead = Assignee.HasBeenRead
                DismissedAssignee.IsCurrentRecipient = Assignee.IsCurrentRecipient
                DismissedAssignee.IsCurrentNotify = 1
                DismissedAssignee.CardSequenceNumber = Assignee.CardSequenceNumber
                DismissedAssignee.IsConceptShareReviewer = Assignee.IsConceptShareReviewer
                DismissedAssignee.AlertTemplateID = Assignee.AlertTemplateID
                DismissedAssignee.AlertStateID = Assignee.AlertStateID
                DismissedAssignee.PercentComplete = Assignee.PercentComplete
                DismissedAssignee.CompletedDate = Assignee.CompletedDate
                DismissedAssignee.TempCompleteDate = Assignee.TempCompleteDate
                DismissedAssignee.HoursAllowed = Assignee.HoursAllowed

                If AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Update(DbContext, DismissedAssignee) = True Then

                    Moved = AdvantageFramework.Database.Procedures.AlertRecipient.Delete(DbContext, Assignee)

                End If

            ElseIf Assignee Is Nothing AndAlso DismissedAssignee Is Nothing Then 'Never happen but possible

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)
                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                DismissedAssignee = New Database.Entities.AlertRecipientDismissed

                DismissedAssignee.AlertID = AlertID
                DismissedAssignee.EmployeeCode = EmployeeCode

                If Employee IsNot Nothing Then

                    DismissedAssignee.EmployeeEmail = Employee.Email

                End If

                DismissedAssignee.IsCurrentNotify = 1

                If Alert IsNot Nothing Then

                    DismissedAssignee.AlertTemplateID = Assignee.AlertTemplateID
                    DismissedAssignee.AlertStateID = Assignee.AlertStateID

                End If

                Moved = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.Insert(DbContext, DismissedAssignee)

            ElseIf Assignee Is Nothing AndAlso DismissedAssignee IsNot Nothing Then
                'No need to move anything
            End If

            Return Moved

        End Function
        Private Function AssigneeIsInCurrentState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal AlertID As Integer,
                                                  ByVal EmployeeCode As String) As Boolean

            Dim IsInCurrentState As Boolean = False
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

            AlertIDSqlParameter.Value = AlertID
            EmployeeCodeSqlParameter.Value = EmployeeCode

            Try

                IsInCurrentState = DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_alert_assignee_is_in_current_state] @ALERT_ID, @EMP_CODE;",
                                                                            AlertIDSqlParameter, EmployeeCodeSqlParameter).SingleOrDefault

            Catch ex As Exception
                IsInCurrentState = False
            End Try


            Return IsInCurrentState

        End Function
        Private Function AssigneeHasRecipientRecord(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                                    ByVal EmployeeCode As String) As Boolean

            Dim HasRecipientRecord As Boolean = False
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

            AlertRecipient = (From Entity In DbContext.GetQuery(Of Database.Entities.AlertRecipient)
                              Where Entity.AlertID = Alert.ID And
                                    Entity.AlertTemplateID = Alert.AlertAssignmentTemplateID And
                                    Entity.AlertStateID = Alert.AlertStateID And
                                    Entity.EmployeeCode = EmployeeCode And
                                    Entity.IsCurrentNotify = 1
                              Select Entity).SingleOrDefault

            Return HasRecipientRecord

        End Function
        Public Function GetCurrentAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal AlertID As Integer) As Generic.List(Of String)

            Dim EmployeeCodes As Generic.List(Of String) = Nothing

            Try

                Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                AlertIDSqlParameter.Value = AlertID

                Try

                    EmployeeCodes = DbContext.Database.SqlQuery(Of String)("EXEC [dbo].[advsp_alert_get_current_assignees] @ALERT_ID;",
                                                                           AlertIDSqlParameter).ToList

                Catch ex As Exception
                    EmployeeCodes = Nothing
                End Try

            Catch ex As Exception
                EmployeeCodes = Nothing
            End Try

            Return EmployeeCodes

        End Function
        Public Function AssignmentHasAssignmentChanges(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                                       ByRef StateChanged As Boolean,
                                                       ByRef AssigneesChanged As Boolean) As Boolean


            Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing

            AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

            Return AssignmentHasAssignmentChanges(DbContext, Alert, AlertEntity, StateChanged, AssigneesChanged)

        End Function
        Public Function AssignmentHasAssignmentChanges(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                                       ByVal AlertEntity As AdvantageFramework.Database.Entities.Alert,
                                                       ByRef StateChanged As Boolean,
                                                       ByRef AssigneesChanged As Boolean) As Boolean

            Dim AssigneesBefore As List(Of String) = Nothing
            Dim AssigneesAfter As List(Of String) = Nothing
            Dim Changed As Boolean = False

            If Alert.Assignees IsNot Nothing Then AssigneesBefore = Alert.Assignees.ToList

            If (AlertEntity.AlertStateID Is Nothing AndAlso Alert.AlertStateID IsNot Nothing) OrElse
                            (AlertEntity.AlertStateID IsNot Nothing AndAlso Alert.AlertStateID Is Nothing) OrElse
                            (AlertEntity.AlertStateID <> Alert.AlertStateID) Then

                StateChanged = True

            End If

            AssigneesAfter = GetCurrentAssignees(DbContext, Alert.ID)

            Try
                If AssigneesBefore Is Nothing Then AssigneesBefore = New List(Of String)
                If AssigneesAfter Is Nothing Then AssigneesAfter = New List(Of String)

                If AssigneesBefore.Count <> AssigneesAfter.Count Then

                    AssigneesChanged = True

                End If
                If AssigneesChanged = False AndAlso AssigneesBefore.Except(AssigneesAfter).Count > 0 Then

                    AssigneesChanged = True

                End If
            Catch ex As Exception
                AssigneesChanged = False
            End Try

            If AssigneesChanged = True OrElse StateChanged = True Then

                Changed = True

            End If

            Return Changed

        End Function
        Private Function AssigneeHasCommentAtCurrentState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                          ByVal AlertID As Integer,
                                                          ByVal EmployeeCode As String) As Boolean

            Dim HasComment As Boolean = False
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

            AlertIDSqlParameter.Value = AlertID
            EmployeeCodeSqlParameter.Value = EmployeeCode

            Try

                HasComment = DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_alert_assignee_has_current_state_comment] @ALERT_ID, @EMP_CODE;",
                                                                      AlertIDSqlParameter, EmployeeCodeSqlParameter).SingleOrDefault

            Catch ex As Exception
                HasComment = False
            End Try

            Return HasComment

        End Function
        Public Function UpdateTaskCustodyEnd(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short,
                                             ByVal EmployeeCode As String,
                                             ByVal CustodyEndDate As DateTime) As Boolean

            Dim CustodyEndUpdated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            Alert = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber)

            If Alert IsNot Nothing Then

                CustodyEndUpdated = UpdateCustodyEnd(DbContext,
                                                     Alert.ID, Alert.AlertAssignmentTemplateID, Alert.AlertStateID,
                                                     EmployeeCode,
                                                     CustodyEndDate)

            End If

            Return CustodyEndUpdated

        End Function
        Public Function UpdateCustodyEnd(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal AlertID As Integer, ByVal AlertTemplateID As Integer?, ByVal AlertStateID As Integer?,
                                         ByVal EmployeeCode As String,
                                         ByVal CustodyEndDate As DateTime) As Boolean

            Dim CustodyEndUpdated As Boolean = False
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim AlertTemplateIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim AlertStateIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CustodyEndDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            AlertTemplateIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
            AlertStateIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)
            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            CustodyEndDateSqlParameter = New System.Data.SqlClient.SqlParameter("@CUSTODY_END_DATE", SqlDbType.SmallDateTime)

            AlertIDSqlParameter.Value = AlertID
            AlertTemplateIDSqlParameter.Value = AlertTemplateID
            AlertStateIDSqlParameter.Value = AlertStateID
            EmployeeCodeSqlParameter.Value = EmployeeCode
            CustodyEndDateSqlParameter.Value = CustodyEndDate

            Try

                If AlertTemplateID Is Nothing OrElse AlertStateID Is Nothing Then

                    DbContext.Database.ExecuteSqlCommand("UPDATE ALERT_COMMENT WITH(ROWLOCK) SET CUSTODY_END = @CUSTODY_END_DATE " &
                                                         " WHERE ALERT_ID = @ALERT_ID AND ALRT_NOTIFY_HDR_ID IS NULL " &
                                                         " AND ALERT_STATE_ID IS NULL AND ASSIGNED_EMP_CODE = @EMP_CODE " &
                                                         " AND CUSTODY_END IS NULL AND COMMENT NOT LIKE 'COMPLETED%';",
                                                         AlertIDSqlParameter,
                                                         EmployeeCodeSqlParameter,
                                                         CustodyEndDateSqlParameter)

                Else

                    DbContext.Database.ExecuteSqlCommand("UPDATE ALERT_COMMENT WITH(ROWLOCK) SET CUSTODY_END = @CUSTODY_END_DATE " &
                                                         " WHERE ALERT_ID = @ALERT_ID AND ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID " &
                                                         " AND ALERT_STATE_ID = @ALERT_STATE_ID AND ASSIGNED_EMP_CODE = @EMP_CODE " &
                                                         " AND CUSTODY_END IS NULL AND COMMENT NOT LIKE 'COMPLETED%';",
                                                         AlertIDSqlParameter,
                                                         AlertTemplateIDSqlParameter,
                                                         AlertStateIDSqlParameter,
                                                         EmployeeCodeSqlParameter,
                                                         CustodyEndDateSqlParameter)

                End If


            Catch ex As Exception
                CustodyEndUpdated = False
            End Try

            Return CustodyEndUpdated

        End Function
        Public Function UpdateCustodyEnd(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                          ByVal AlertID As Integer,
                                          ByVal CustodyEndDate As DateTime) As Boolean

            Dim CustodyEndUpdated As Boolean = False
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CustodyEndDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            CustodyEndDateSqlParameter = New System.Data.SqlClient.SqlParameter("@CUSTODY_END_DATE", SqlDbType.SmallDateTime)

            AlertIDSqlParameter.Value = AlertID
            CustodyEndDateSqlParameter.Value = CustodyEndDate

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_alert_update_custody_end] @ALERT_ID, @CUSTODY_END_DATE;",
                                                      AlertIDSqlParameter, CustodyEndDateSqlParameter)

            Catch ex As Exception
                CustodyEndUpdated = False
            End Try

            Return CustodyEndUpdated

        End Function
        Private Function ClearNonCurrentState(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertID As Integer) As Boolean

            Dim StateCleared As Boolean = False
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)

            AlertIDSqlParameter.Value = AlertID

            Try

                StateCleared = DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[advsp_alert_clear_noncurrent_state] @ALERT_ID;",
                                                                        AlertIDSqlParameter).SingleOrDefault

            Catch ex As Exception
                StateCleared = False
            End Try

            Return StateCleared

        End Function
        Public Function AddReopenComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal JobNumber As Integer,
                                         ByVal JobComponentNumber As Short,
                                         ByVal TaskSequenceNumber As Short,
                                         ByVal EmployeeCode As String,
                                         ByVal ReopenDate As DateTime) As Boolean

            Dim ReopenCommentAdded As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Comment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Alert = AdvantageFramework.Database.Procedures.Alert.LoadTaskWorkItem(DbContext, JobNumber, JobComponentNumber, TaskSequenceNumber)

            If Alert IsNot Nothing Then

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    Comment = New AdvantageFramework.Database.Entities.AlertComment
                    Comment.AlertID = Alert.ID
                    Comment.UserCode = DbContext.UserCode
                    Comment.GeneratedDate = ReopenDate
                    Comment.Comment = String.Format("{0} | {1}", "RE-OPENED", Employee.ToString)
                    Comment.HasEmailBeenSent = False
                    Comment.AssignedEmployeeCode = Employee.Code
                    Comment.CustodyStart = Comment.GeneratedDate
                    Comment.IsSystem = True

                    ReopenCommentAdded = AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment)

                End If

            End If

            Return ReopenCommentAdded

        End Function
        Public Function LoadAlertView(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal EmployeeCode As String,
                                      ByVal AlertID As Integer,
                                      ByVal CDPContactID As Integer,
                                      ByVal Offset As Decimal,
                                      ByVal SprintID As Integer,
                                      ByVal IsClientPortal As Boolean) As AdvantageFramework.DTO.Desktop.Alert

            'objects
            Dim Alert As AdvantageFramework.DTO.Desktop.Alert = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CDPContactIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OffsetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SprintIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("AlertID", AlertID)
            If IsClientPortal = True Then
                EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EmployeeCode", "")
            Else
                EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EmployeeCode", EmployeeCode)
            End If
            CDPContactIDSqlParameter = New System.Data.SqlClient.SqlParameter("CDPContactID", CDPContactID)
            OffsetSqlParameter = New System.Data.SqlClient.SqlParameter("Offset", Offset)
            SprintIDSqlParameter = New System.Data.SqlClient.SqlParameter("SprintID", SprintID)

            Try

                Alert = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.Alert)("EXEC [dbo].[advsp_alert_get] @AlertID, @EmployeeCode, @CDPContactID, @Offset, @SprintID", AlertIDSqlParameter, EmployeeCodeSqlParameter, CDPContactIDSqlParameter, OffsetSqlParameter, SprintIDSqlParameter).SingleOrDefault

            Catch ex As Exception
                Alert = Nothing
            End Try
            Try

                If Alert IsNot Nothing Then

                    If Alert.AlertLevel = "BRD" OrElse Alert.AlertLevel = "PST" Then

                        AdvantageFramework.ProjectSchedule.MarkTaskRead(DbContext, Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, EmployeeCode)

                    End If

                End If

            Catch ex As Exception
            End Try

            Return Alert

        End Function
        Public Function LoadAlertRecipients(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient)

            'objects
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("AlertID", AlertID)

            Try

                AlertRecipients = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.AlertRecipient)("EXEC [dbo].[advsp_alert_recipient_get] @AlertID", AlertIDSqlParameter).ToList

            Catch ex As Exception

            End Try

            Return AlertRecipients

        End Function
        Public Function TransferAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                      ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                      ByVal BoardID As Integer, ByVal BoardSprintID As Integer, ByVal BoardStateID As Integer) As Boolean

            Dim Transferred As Boolean = False

            If Alert IsNot Nothing Then

                Try

                    If BoardStateID = 0 Then BoardStateID = -1
                    Transferred = DbContext.Database.SqlQuery(Of Boolean)(String.Format("[dbo].[advsp_alert_transfer] {0}, {1}, {2}, {3}, {4}, {5}, '{6}';",
                                                                                         Alert.ID, JobNumber, JobComponentNumber,
                                                                                         BoardID, BoardSprintID, BoardStateID,
                                                                                         DbContext.UserCode)).SingleOrDefault

                Catch ex As Exception
                    Transferred = False
                End Try
                If Transferred = True Then

                    If BoardStateID > 0 Then

                        Dim SprintDetail As AdvantageFramework.Database.Entities.SprintDetail = Nothing

                        SprintDetail = AdvantageFramework.Database.Procedures.SprintDetail.LoadBySprintIDAlertID(DbContext, BoardSprintID, Alert.ID)

                        If SprintDetail Is Nothing Then

                            SprintDetail = New Database.Entities.SprintDetail
                            SprintDetail.AlertID = Alert.ID
                            SprintDetail.SprintHeaderID = BoardSprintID

                            AdvantageFramework.Database.Procedures.SprintDetail.Insert(DbContext, SprintDetail)

                        End If

                    End If

                End If

            End If

            Return Transferred

        End Function
        ''Public Function TransferAlert(ByVal AlertID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As Boolean

        ''    Dim Transferred As Boolean = False

        ''    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        ''            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

        ''            Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

        ''            If Alert IsNot Nothing Then

        ''                Dim OldComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

        ''                OldComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Alert.JobNumber, Alert.JobComponentNumber)

        ''                If OldComponent IsNot Nothing Then

        ''                    Dim NewJob As AdvantageFramework.Database.Entities.Job = Nothing

        ''                    NewJob = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

        ''                    If NewJob IsNot Nothing Then

        ''                        Dim NewComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

        ''                        NewComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

        ''                        If NewComponent IsNot Nothing Then

        ''                            Alert.ClientCode = NewJob.ClientCode
        ''                            Alert.DivisionCode = NewJob.DivisionCode
        ''                            Alert.ProductCode = NewJob.ProductCode
        ''                            Alert.JobNumber = NewJob.Number
        ''                            Alert.JobComponentNumber = NewComponent.Number

        ''                            Transferred = AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

        ''                        If Transferred = True Then

        ''                            Dim TransferIsOnSameSprint As Boolean = False

        ''                            TransferIsOnSameSprint = DbContext.Database.SqlQuery(Of Boolean)(String.Format("")).SingleOrDefault

        ''                            AdvantageFramework.Database.Procedures.SprintDetail.DeleteSprintDetailByAlertID(DbContext, Alert.ID)



        ''                            Dim OldComponentDescription As String = String.Format("{0}/{1} - {2}",
        ''                                                                                  OldComponent.JobNumber.ToString.PadLeft(6, "0"),
        ''                                                                                  OldComponent.Number.ToString.PadLeft(2, "0"),
        ''                                                                                  OldComponent.Description)

        ''                            Dim NewComponentDescription As String = String.Format("{0}/{1} - {2}",
        ''                                                                                  NewComponent.JobNumber.ToString.PadLeft(6, "0"),
        ''                                                                                  NewComponent.Number.ToString.PadLeft(2, "0"),
        ''                                                                                  NewComponent.Description)


        ''                            Dim Comment As New AdvantageFramework.Database.Entities.AlertComment

        ''                            Comment.Comment = String.Format("MOVE | {0} |<br/><b>From:</b>&nbsp;&nbsp;{1}<br/><b>To:</b>&nbsp;&nbsp;{2}",
        ''                                                            Me.Session.EmployeeName,
        ''                                                            OldComponentDescription,
        ''                                                            NewComponentDescription)
        ''                            Comment.AlertID = Alert.ID
        ''                            Comment.GeneratedDate = Now
        ''                            Comment.UserCode = Me.Session.UserCode
        ''                            Comment.AssignedEmployeeCode = Alert.AssignedEmployeeEmployeeCode
        ''                            Comment.IsSystem = True

        ''                            If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, Comment) = True Then

        ''                                NotifyAlertRecipientsOfChanges(DbContext, Alert)

        ''                            End If

        ''                        End If

        ''                    End If

        ''                    End If

        ''                End If

        ''            End If

        ''        End Using

        ''    Return Transferred

        ''End Function
        Public Function SaveNotifyAssignmentAlertRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal AlertID As Integer, ByVal EmployeeCode As String, ByVal CommentType As Integer, ByVal AlertStateID As Integer,
                                                           ByVal AlertNotifyHeaderID As Integer, ByVal AlertComment As String, ByVal SaveUnassigned As Boolean,
                                                           ByVal IsNewAssignment As Boolean, Optional ByVal ErrorMessage As String = "") As Boolean

            'objects
            Dim IsUnassigned As Boolean = False
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CommentTypeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim AlertStateIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim AlertNotifyHeaderIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim AlertCommentSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IsUnassignedSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim SaveUnassignedSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim IsNewAssignmentSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            If String.IsNullOrWhiteSpace(EmployeeCode) OrElse {"unassigned".ToUpper, "un-assigned".ToUpper}.Contains(EmployeeCode.ToUpper) Then

                IsUnassigned = True

            End If

            If Not String.IsNullOrWhiteSpace(AlertComment) Then

                AlertComment = AlertComment.Trim

            End If

            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("USER_CODE", DbContext.UserCode)
            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("ALERT_ID", AlertID)
            EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("EMP_CODE", EmployeeCode)
            CommentTypeSqlParameter = New System.Data.SqlClient.SqlParameter("COMMENT_TYPE", CommentType)
            AlertStateIDSqlParameter = New System.Data.SqlClient.SqlParameter("ALERT_STATE_ID", AlertStateID)
            AlertNotifyHeaderIDSqlParameter = New System.Data.SqlClient.SqlParameter("ALRT_NOTIFY_HDR_ID", AlertNotifyHeaderID)
            AlertCommentSqlParameter = New System.Data.SqlClient.SqlParameter("ALERT_COMMENT", AlertComment)

            If String.IsNullOrWhiteSpace(AlertComment) Then

                AlertCommentSqlParameter.Value = DBNull.Value

            End If

            IsUnassignedSqlParameter = New System.Data.SqlClient.SqlParameter("IS_UNASSIGNED", If(IsUnassigned, 1, 0))
            SaveUnassignedSqlParameter = New System.Data.SqlClient.SqlParameter("SAVE_UNASSIGNED", If(SaveUnassigned, 1, 0))
            IsNewAssignmentSqlParameter = New System.Data.SqlClient.SqlParameter("IS_NEW_ASSIGNMENT", If(IsNewAssignment, 1, 0))

            Try

                Return DbContext.Database.SqlQuery(Of Boolean)("EXEC [dbo].[usp_wv_ALERT_NOTIFY_SAVE] @USER_CODE, @ALERT_ID, @EMP_CODE, @COMMENT_TYPE, @ALERT_STATE_ID, @ALRT_NOTIFY_HDR_ID, @ALERT_COMMENT, @IS_UNASSIGNED, @SAVE_UNASSIGNED, @IS_NEW_ASSIGNMENT;",
                                                                UserCodeSqlParameter, AlertIDSqlParameter, EmployeeCodeSqlParameter, CommentTypeSqlParameter, AlertStateIDSqlParameter, AlertNotifyHeaderIDSqlParameter,
                                                                AlertCommentSqlParameter, IsUnassignedSqlParameter, SaveUnassignedSqlParameter, IsNewAssignmentSqlParameter).SingleOrDefault

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Return False
            End Try

        End Function
        Public Function AlertHasWeeklyHours(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal AlertID As Integer) As Boolean

            Dim HasWeeklyHours As Boolean = False

            HasWeeklyHours = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[advsp_alert_has_weekly_hours] {0};", AlertID)).SingleOrDefault

            Return HasWeeklyHours

        End Function
        Public Function AssignmentStillHasAssignees(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer) As Boolean

            Dim StillHasAssignees As Boolean = False

            Try

                Dim SQL As String = "IF EXISTS (SELECT 1 FROM ALERT_RCPT WHERE ALERT_ID = {0} AND CURRENT_NOTIFY = 1) BEGIN SELECT CAST(1 AS BIT) END ELSE BEGIN SELECT CAST(0 AS BIT) END"

                StillHasAssignees = DbContext.Database.SqlQuery(Of Boolean)(String.Format(SQL, AlertID)).SingleOrDefault

            Catch ex As Exception
                StillHasAssignees = False
            End Try

            Return StillHasAssignees

        End Function
        Public Function IsAlertRealAssignment(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim AlertIsRealAssignment As Boolean = False

            If (Alert.AlertAssignmentTemplateID.GetValueOrDefault(0) > 0) AndAlso
                (Alert.AlertStateID.GetValueOrDefault(0) > 0) AndAlso
                Alert.AlertLevel <> "BRD" Then

                AlertIsRealAssignment = True

            End If

            Return AlertIsRealAssignment

        End Function
        Public Function IsBoardTaskAlert(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            Dim IsBoardTask As Boolean = False

            If Alert.AlertLevel = "BRD" OrElse IsBoardTaskAlert(Alert.AlertCategoryID) = True Then

                IsBoardTask = True

            End If

            Return IsBoardTask

        End Function
        Public Function IsBoardTaskAlert(ByVal AlertCategoryID As Integer) As Boolean

            Return If(AlertCategoryID = 71, True, False)

        End Function

#End Region

#Region "  Employee Time Forecast "

        Public Function CreateAlertForEmployeeTimeForcast(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                            ByVal User As AdvantageFramework.Security.Database.Entities.User,
                                                            ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                            ByVal EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary As Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee, Decimal),
                                                            ByVal SupervisorEmployeeCode As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim SupervisorEmployee As AdvantageFramework.Database.Views.Employee = Nothing

            If DbContext IsNot Nothing Then

                If User IsNot Nothing Then

                    If EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary IsNot Nothing AndAlso
                            EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary.Count > 0 Then

                        SupervisorEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SupervisorEmployeeCode)

                        If SupervisorEmployee IsNot Nothing Then

                            AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.EmployeeTimeForecast.ToString))

                            If AlertType IsNot Nothing Then

                                AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(EmployeeTimeForecastAlertCategory.HoursChangedForSupervisedEmployee.ToString))

                                If AlertCategory IsNot Nothing Then

                                    AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyHeaderForEmployeeTimeForecast(DbContext, User, EmployeeTimeForecastOfficeDetail, SupervisorEmployee, EmployeeTimeForecastAlertCategory.HoursChangedForSupervisedEmployee)
                                    AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyHeaderForEmployeeTimeForecast(DbContext, User, EmployeeTimeForecastOfficeDetail, SupervisorEmployee, EmployeeTimeForecastAlertCategory.HoursChangedForSupervisedEmployee)

                                    For Each KeyValue In EmployeeTimeForecastOfficeDetailJobComponentEmployeeDictionary.Where(Function(KeyValuePair) KeyValuePair.Key.EmployeeTimeForecastOfficeDetailEmployee.Employee.SupervisorEmployeeCode = SupervisorEmployeeCode)

                                        AlertBody &= vbCrLf & AdvantageFramework.AlertSystem.CreateAlertBodyDetailForEmployeeTimeForecast(DbContext, KeyValue.Key, KeyValue.Value)
                                        AlertEmailBody &= vbCrLf & AdvantageFramework.AlertSystem.CreateAlertEmailBodyDetailForEmployeeTimeForecast(DbContext, KeyValue.Key, KeyValue.Value)

                                    Next

                                    AlertEmailBody &= vbCrLf & "</table>"

                                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, AlertType.ID, AlertCategory.ID, "Hours Forecast Changed for Supervised Employee(s)",
                                                                                                AlertBody, Now, 2, SupervisorEmployee.Code, User.UserCode, "",
                                                                                                AlertEmailBody, Alert) Then

                                        AlertCreated = True

                                        If CheckEmployeeAlertNotificationForAlert(SupervisorEmployee) Then

                                            If SupervisorEmployee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                                EmployeeEmail = SupervisorEmployee.Email

                                            End If

                                            AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, SupervisorEmployee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                        End If

                                        If CheckEmployeeAlertNotificationForEmail(SupervisorEmployee) Then

                                            Dim Body As String = Alert.EmailBody
                                            Try

                                                If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                                    Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, True)

                                                End If

                                            Catch ex As Exception
                                            End Try

                                            AdvantageFramework.Email.Send(DbContext, SecurityDbContext, SupervisorEmployee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", 2, SendingEmailStatus)

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            End If

            CreateAlertForEmployeeTimeForcast = AlertCreated

        End Function
        Private Function CreateAlertBodyHeaderForEmployeeTimeForecast(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                        ByVal User As AdvantageFramework.Security.Database.Entities.User,
                                                                        ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                        ByVal SupervisorEmployee As AdvantageFramework.Database.Views.Employee,
                                                                        ByVal EmployeeTimeForecastAlertCategory As AdvantageFramework.AlertSystem.EmployeeTimeForecastAlertCategory) As String

            'objects
            Dim AlertBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If SupervisorEmployee IsNot Nothing Then

                        StringBuilder = New System.Text.StringBuilder

                        If EmployeeTimeForecastAlertCategory = AdvantageFramework.AlertSystem.EmployeeTimeForecastAlertCategory.HoursChangedForSupervisedEmployee Then

                            StringBuilder.AppendLine("The Hours Forecast for Supervised Employee(s) has been changed by someone other than you.")
                            StringBuilder.AppendLine("")
                            StringBuilder.AppendLine("Generated: " & Now & " By " & User.Employee.ToString)
                            StringBuilder.AppendLine("")
                            StringBuilder.AppendLine("Forecast for " & AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DateUtilities.Months), EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Month.GetValueOrDefault(0)) &
                                                        " and " & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Year)
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Description:", 25) & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description)
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Office:", 25) & EmployeeTimeForecastOfficeDetail.Office.Name)
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Assigned Employee:", 25) & EmployeeTimeForecastOfficeDetail.AssignedToEmployee.ToString)
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Supervisor:", 25) & SupervisorEmployee.ToString)
                            StringBuilder.AppendLine("")
                            StringBuilder.AppendLine("The following supervised employees' forecasted hours have been changed by someone other than you.")
                            StringBuilder.AppendLine("")
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Employee", 50) &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter("Job/Component", 20) &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter("Component Description", 40) &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter("Original Hours", 20) &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter("New Hours", 20) &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter("Variance", 20))

                        ElseIf EmployeeTimeForecastAlertCategory = AdvantageFramework.AlertSystem.EmployeeTimeForecastAlertCategory.HoursOverbookedForEmployee Then

                            StringBuilder.AppendLine("Total Hours Forecasted Exceeds Hours Available for Supervised Employee(s)")
                            StringBuilder.AppendLine("")
                            StringBuilder.AppendLine("Generated: " & Now & " By " & User.Employee.ToString)
                            StringBuilder.AppendLine("")
                            StringBuilder.AppendLine("Forecast for " & AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DateUtilities.Months), EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Month.GetValueOrDefault(0)) &
                                                        " and " & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Year)
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Description:", 25) & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description)
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Office:", 25) & EmployeeTimeForecastOfficeDetail.Office.Name)
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Assigned Employee:", 25) & EmployeeTimeForecastOfficeDetail.AssignedToEmployee.ToString)
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Supervisor:", 25) & SupervisorEmployee.ToString)
                            StringBuilder.AppendLine("")
                            StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Employee", 50) &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter("Forecasted Hours", 20) &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter("Available Hours", 20) &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter("Variance", 20))

                        End If

                        AlertBodyHeader = StringBuilder.ToString

                    End If

                End If

            Catch ex As Exception
                AlertBodyHeader = ""
            Finally
                CreateAlertBodyHeaderForEmployeeTimeForecast = AlertBodyHeader
            End Try

        End Function
        Private Function CreateAlertBodyDetailForEmployeeTimeForecast(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                        ByVal EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee,
                                                                        ByVal OriginalHours As Decimal) As String

            'objects
            Dim AlertBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.Employee.ToString, 50) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailJobComponent.JobComponent.ToString(True, False), 20) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailJobComponent.JobComponent.Description, 40) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(FormatNumber(OriginalHours, 2), 20) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(FormatNumber(EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours, 2), 20) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(FormatNumber(System.Math.Abs(EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours - OriginalHours), 2), 20))

                    AlertBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertBodyDetail = ""
            Finally
                CreateAlertBodyDetailForEmployeeTimeForecast = AlertBodyDetail
            End Try

        End Function
        Private Function CreateAlertEmailBodyHeaderForEmployeeTimeForecast(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                            ByVal User As AdvantageFramework.Security.Database.Entities.User,
                                                                            ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                                            ByVal SupervisorEmployee As AdvantageFramework.Database.Views.Employee,
                                                                            ByVal EmployeeTimeForecastAlertCategory As AdvantageFramework.AlertSystem.EmployeeTimeForecastAlertCategory) As String

            'objects
            Dim AlertEmailBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    If SupervisorEmployee IsNot Nothing Then

                        StringBuilder = New System.Text.StringBuilder

                        If EmployeeTimeForecastAlertCategory = AdvantageFramework.AlertSystem.EmployeeTimeForecastAlertCategory.HoursChangedForSupervisedEmployee Then

                            StringBuilder.AppendLine("<table width=""98%"" style=""vertical-align:top"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF""><tr>")
                            StringBuilder.AppendLine("<td colspan=""2"" height=""18"" align=""left"" valign=""top"" bgcolor=""#92B4E0""><font size=""2"" face=""Verdana,Arial,Helvetica,sans-serif"" color=""#FFFFFF"">")
                            StringBuilder.AppendLine("<strong> The Hours Forecast for Supervised Employee(s) has been changed by someone other than you. </strong></font></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""2"" face=""Verdana,Arial"">Generated: " & Now & " By " & User.Employee.ToString & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""></td></tr>")

                            StringBuilder.AppendLine("<tr><td align=""left"" colspan=""2""><font size=""2"" face=""Verdana,Arial"">Forecast for " & AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DateUtilities.Months), EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Month.GetValueOrDefault(0)) &
                                                        " and " & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Year & " </font></td></tr>")
                            StringBuilder.AppendLine("<tr><td align=""left"" width=""30%""><font size=""2"" face=""Verdana,Arial"">Description:</font></td>" &
                                                        "<td align=""left""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td align=""left"" width=""30%""><font size=""2"" face=""Verdana,Arial"">Office:</font></td>" &
                                                        "<td align=""left""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetail.Office.Name & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td align=""left"" width=""30%""><font size=""2"" face=""Verdana,Arial"">Assigned Employee:</font></td>" &
                                                        "<td align=""left""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetail.AssignedToEmployee.ToString & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td align=""left"" width=""30%""><font size=""2"" face=""Verdana,Arial"">Supervisor:</font></td>" &
                                                        "<td align=""left""><font size=""2"" face=""Verdana,Arial"">" & SupervisorEmployee.ToString & "</font></td></tr>")

                            StringBuilder.AppendLine("<tr><td colspan=""2""></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""2"" face=""Verdana,Arial""><strong>The following supervised employees' forecasted hours have been changed by someone other than you.</strong></font></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""></td></tr>")
                            StringBuilder.AppendLine("</table>")

                            StringBuilder.AppendLine("<table width=""98%"" style=""vertical-align:top"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                            StringBuilder.AppendLine("<tr>")
                            StringBuilder.AppendLine("<td width=""30%""><font size=""2"" face=""Verdana,Arial""><strong>Employee</strong></font></td>")
                            StringBuilder.AppendLine("<td width=""12%""><font size=""2"" face=""Verdana,Arial""><strong>Job/Component</strong></font></td>")
                            StringBuilder.AppendLine("<td width=""22%""><font size=""2"" face=""Verdana,Arial""><strong>Component Description</strong></font></td>")
                            StringBuilder.AppendLine("<td width=""12%""><font size=""2"" face=""Verdana,Arial""><strong>Original Hours</strong></font></td>")
                            StringBuilder.AppendLine("<td width=""12%""><font size=""2"" face=""Verdana,Arial""><strong>New Hours</strong></font></td>")
                            StringBuilder.AppendLine("<td width=""12%""><font size=""2"" face=""Verdana,Arial""><strong>Variance</strong></font></td>")
                            StringBuilder.AppendLine("</tr>")

                        ElseIf EmployeeTimeForecastAlertCategory = AdvantageFramework.AlertSystem.EmployeeTimeForecastAlertCategory.HoursOverbookedForEmployee Then

                            StringBuilder.AppendLine("<table width=""98%"" style=""vertical-align:top"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF""><tr>")
                            StringBuilder.AppendLine("<td colspan=""2"" height=""18"" align=""left"" valign=""top"" bgcolor=""#92B4E0""><font size=""2"" face=""Verdana,Arial,Helvetica,sans-serif"" color=""#FFFFFF"">")
                            StringBuilder.AppendLine("<strong> Total Hours Forecasted Exceeds Hours Available for Supervised Employee(s) </strong></font></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""><font size=""2"" face=""Verdana,Arial"">Generated: " & Now & " By " & User.Employee.ToString & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td colspan=""2""></td></tr>")

                            StringBuilder.AppendLine("<tr><td align=""left"" colspan=""2""><font size=""2"" face=""Verdana,Arial"">Forecast for " & AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.DateUtilities.Months), EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Month.GetValueOrDefault(0)) &
                                                        " and " & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.PostPeriod.Year & " </font></td></tr>")
                            StringBuilder.AppendLine("<tr><td align=""left"" width=""30%""><font size=""2"" face=""Verdana,Arial"">Description:</font></td>" &
                                                        "<td align=""left""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetail.EmployeeTimeForecast.Description & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td align=""left"" width=""30%""><font size=""2"" face=""Verdana,Arial"">Office:</font></td>" &
                                                        "<td align=""left""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetail.Office.Name & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td align=""left"" width=""30%""><font size=""2"" face=""Verdana,Arial"">Assigned Employee:</font></td>" &
                                                        "<td align=""left""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetail.AssignedToEmployee.ToString & "</font></td></tr>")
                            StringBuilder.AppendLine("<tr><td align=""left"" width=""30%""><font size=""2"" face=""Verdana,Arial"">Supervisor:</font></td>" &
                                                        "<td align=""left""><font size=""2"" face=""Verdana,Arial"">" & SupervisorEmployee.ToString & "</font></td></tr>")
                            StringBuilder.AppendLine("</table>")

                            StringBuilder.AppendLine("<table width=""98%"" style=""vertical-align:top"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                            StringBuilder.AppendLine("<tr>")
                            StringBuilder.AppendLine("<td width=""46%""><font size=""2"" face=""Verdana,Arial""><strong>Employee</strong></font></td>")
                            StringBuilder.AppendLine("<td width=""18%""><font size=""2"" face=""Verdana,Arial""><strong>Forecasted Hours</strong></font></td>")
                            StringBuilder.AppendLine("<td width=""18%""><font size=""2"" face=""Verdana,Arial""><strong>Available Hours</strong></font></td>")
                            StringBuilder.AppendLine("<td width=""18%""><font size=""2"" face=""Verdana,Arial""><strong>Variance</strong></font></td>")
                            StringBuilder.AppendLine("</tr>")

                        End If

                        AlertEmailBodyHeader = StringBuilder.ToString

                    End If

                End If

            Catch ex As Exception
                AlertEmailBodyHeader = ""
            Finally
                CreateAlertEmailBodyHeaderForEmployeeTimeForecast = AlertEmailBodyHeader
            End Try

        End Function
        Private Function CreateAlertEmailBodyDetailForEmployeeTimeForecast(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                            ByVal EmployeeTimeForecastOfficeDetailJobComponentEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailJobComponentEmployee,
                                                                            ByVal OriginalHours As Decimal) As String

            'objects
            Dim AlertEmailBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    StringBuilder.AppendLine("<tr>")
                    StringBuilder.AppendLine("<td width=""30%""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailEmployee.Employee.ToString & "</font></td>")
                    StringBuilder.AppendLine("<td width=""12%""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailJobComponent.JobComponent.ToString(True, False) & "</font></td>")
                    StringBuilder.AppendLine("<td width=""22%""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetailJobComponentEmployee.EmployeeTimeForecastOfficeDetailJobComponent.JobComponent.Description & "</font></td>")
                    StringBuilder.AppendLine("<td width=""12%""><font size=""2"" face=""Verdana,Arial"">" & FormatNumber(OriginalHours, 2) & "</font></td>")
                    StringBuilder.AppendLine("<td width=""12%""><font size=""2"" face=""Verdana,Arial"">" & FormatNumber(EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours, 2) & "</font></td>")
                    StringBuilder.AppendLine("<td width=""12%""><font size=""2"" face=""Verdana,Arial"">" & FormatNumber(System.Math.Abs(EmployeeTimeForecastOfficeDetailJobComponentEmployee.Hours - OriginalHours), 2) & "</font></td>")
                    StringBuilder.AppendLine("</tr>")

                    AlertEmailBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyDetail = ""
            Finally
                CreateAlertEmailBodyDetailForEmployeeTimeForecast = AlertEmailBodyDetail
            End Try

        End Function
        Public Function CreateAlertForEmployeeTimeForcast(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                            ByVal User As AdvantageFramework.Security.Database.Entities.User,
                                                            ByVal EmployeeTimeForecastOfficeDetail As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetail,
                                                            ByVal EmployeeTimeForecastOfficeDetailEmployeeDictionary As Generic.Dictionary(Of AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee, Decimal),
                                                            ByVal SupervisorEmployeeCode As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim SupervisorEmployee As AdvantageFramework.Database.Views.Employee = Nothing

            If DbContext IsNot Nothing Then

                If EmployeeTimeForecastOfficeDetailEmployeeDictionary IsNot Nothing AndAlso
                        EmployeeTimeForecastOfficeDetailEmployeeDictionary.Count > 0 Then

                    If User IsNot Nothing Then

                        SupervisorEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SupervisorEmployeeCode)

                        If SupervisorEmployee IsNot Nothing Then

                            AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.EmployeeTimeForecast.ToString))

                            If AlertType IsNot Nothing Then

                                AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(EmployeeTimeForecastAlertCategory.HoursOverbookedForEmployee.ToString))

                                If AlertCategory IsNot Nothing Then

                                    AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyHeaderForEmployeeTimeForecast(DbContext, User, EmployeeTimeForecastOfficeDetail, SupervisorEmployee, EmployeeTimeForecastAlertCategory.HoursOverbookedForEmployee)
                                    AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyHeaderForEmployeeTimeForecast(DbContext, User, EmployeeTimeForecastOfficeDetail, SupervisorEmployee, EmployeeTimeForecastAlertCategory.HoursOverbookedForEmployee)

                                    For Each KeyValue In EmployeeTimeForecastOfficeDetailEmployeeDictionary

                                        AlertBody &= vbCrLf & AdvantageFramework.AlertSystem.CreateAlertBodyDetailForEmployeeTimeForecast(DbContext, KeyValue.Key, KeyValue.Value)
                                        AlertEmailBody &= vbCrLf & AdvantageFramework.AlertSystem.CreateAlertEmailBodyDetailForEmployeeTimeForecast(DbContext, KeyValue.Key, KeyValue.Value)

                                    Next

                                    AlertEmailBody &= vbCrLf & "</table>"

                                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, AlertType.ID, AlertCategory.ID,
                                                                                                "Total Hours Forecasted Exceeds Hours Available for Supervised Employee(s)",
                                                                                                AlertBody,
                                                                                                Now, 2, SupervisorEmployee.Code, User.UserCode, "",
                                                                                                AlertEmailBody, Alert) Then

                                        If CheckEmployeeAlertNotificationForAlert(SupervisorEmployee) Then

                                            If SupervisorEmployee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                                EmployeeEmail = SupervisorEmployee.Email

                                            End If

                                            AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, SupervisorEmployee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                        End If

                                        If CheckEmployeeAlertNotificationForEmail(SupervisorEmployee) Then

                                            Dim Body As String = Alert.EmailBody
                                            Try

                                                If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                                    Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, True)

                                                End If

                                            Catch ex As Exception
                                            End Try

                                            AdvantageFramework.Email.Send(DbContext, SecurityDbContext, SupervisorEmployee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", 2, SendingEmailStatus)

                                        End If

                                    End If

                                End If

                            End If

                        End If

                    End If

                End If

            End If

            CreateAlertForEmployeeTimeForcast = AlertCreated

        End Function
        Private Function CreateAlertBodyDetailForEmployeeTimeForecast(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                        ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee,
                                                                        ByVal HoursAvailable As Decimal) As String

            'objects
            Dim AlertBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HoursWorked As Decimal = 0

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    HoursWorked = EmployeeTimeForecastOfficeDetailEmployee.EmployeeTimeForecastOfficeDetailJobComponentEmployees.Sum(Function(OfficeDetailJobComponentEmployee) OfficeDetailJobComponentEmployee.Hours)

                    StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTimeForecastOfficeDetailEmployee.Employee.ToString, 50) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(FormatNumber(HoursWorked, 2), 20) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(FormatNumber(HoursAvailable, 2), 20) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(FormatNumber(System.Math.Abs(HoursWorked - HoursAvailable), 2), 20))

                    AlertBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertBodyDetail = ""
            Finally
                CreateAlertBodyDetailForEmployeeTimeForecast = AlertBodyDetail
            End Try

        End Function
        Private Function CreateAlertEmailBodyDetailForEmployeeTimeForecast(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                            ByVal EmployeeTimeForecastOfficeDetailEmployee As AdvantageFramework.Database.Entities.EmployeeTimeForecastOfficeDetailEmployee,
                                                                            ByVal HoursAvailable As Decimal) As String

            'objects
            Dim AlertEmailBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HoursWorked As Decimal = 0

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    HoursWorked = EmployeeTimeForecastOfficeDetailEmployee.EmployeeTimeForecastOfficeDetailJobComponentEmployees.Sum(Function(OfficeDetailJobComponentEmployee) OfficeDetailJobComponentEmployee.Hours)

                    StringBuilder.AppendLine("<tr>")
                    StringBuilder.AppendLine("<td width=""46%""><font size=""2"" face=""Verdana,Arial"">" & EmployeeTimeForecastOfficeDetailEmployee.Employee.ToString & "</font></td>")
                    StringBuilder.AppendLine("<td width=""18%""><font size=""2"" face=""Verdana,Arial"">" & FormatNumber(HoursWorked, 2) & "</font></td>")
                    StringBuilder.AppendLine("<td width=""18%""><font size=""2"" face=""Verdana,Arial"">" & FormatNumber(HoursAvailable, 2) & "</font></td>")
                    StringBuilder.AppendLine("<td width=""18%""><font size=""2"" face=""Verdana,Arial"">" & FormatNumber(System.Math.Abs(HoursWorked - HoursAvailable), 2) & "</font></td>")
                    StringBuilder.AppendLine("</tr>")

                    AlertEmailBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyDetail = ""
            Finally
                CreateAlertEmailBodyDetailForEmployeeTimeForecast = AlertEmailBodyDetail
            End Try

        End Function

#End Region

#Region "  Task Notification "

#Region "   Alert "
        Public Function CreateAlertForTaskNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                       ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                       ByVal EmployeeCode As String,
                                                       ByVal AlertCategoryEnum As AdvantageFramework.AlertSystem.TaskNotificationAlertCategory,
                                                       ByVal CustomMessage As String,
                                                       ByVal UseProductName As Boolean, ByVal RemoveTaskComments As Boolean,
                                                       ByVal EmployeeTaskList As List(Of AdvantageFramework.Database.Classes.NotifyTaskData)) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertHeader As String = ""
            Dim AlertDetail As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertEmailHeader As String = ""
            Dim AlertEmailDetail As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim Priority As Integer = 1
            Dim AlertUser As String = ""

            If DbContext IsNot Nothing Then

                If EmployeeTaskList IsNot Nothing AndAlso EmployeeTaskList.Count > 0 Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString()

                        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ProjectSchedule.ToString))

                        If AlertType IsNot Nothing Then

                            If AlertCategoryEnum = AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask Then

                                AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask.ToString))

                            Else

                                AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.UpcomingTask.ToString))

                            End If

                            If AlertCategory IsNot Nothing Then

                                AlertHeader = AdvantageFramework.AlertSystem.CreateAlertBodyHeaderForTaskNotification(DbContext, EmployeeName, AlertCategoryEnum, UseProductName, RemoveTaskComments, CustomMessage)
                                AlertEmailHeader = AdvantageFramework.AlertSystem.CreateAlertEmailBodyHeaderForTaskNotification(DbContext, EmployeeName, AlertCategoryEnum, UseProductName, RemoveTaskComments, CustomMessage)

                                AlertDetail = AdvantageFramework.AlertSystem.CreateAlertBodyDetailForTaskNotification(DbContext, AlertCategoryEnum, UseProductName, RemoveTaskComments, EmployeeTaskList)
                                AlertEmailDetail = AdvantageFramework.AlertSystem.CreateAlertEmailBodyDetailForTaskNotification(DbContext, AlertCategoryEnum, UseProductName, RemoveTaskComments, EmployeeTaskList)

                                AlertBody = AlertHeader + vbCrLf + AlertDetail
                                AlertEmailBody = AlertEmailHeader + vbCrLf + AlertEmailDetail

                                If AlertCategoryEnum = AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask Then

                                    AlertSubject = "Past Due Tasks for " & EmployeeName
                                    Priority = 1

                                Else

                                    AlertSubject = "Upcoming Tasks for " & EmployeeName
                                    Priority = 2

                                End If

                                AlertUser = DbContext.UserCode

                                If AlertUser.Length = 0 Then

                                    AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                                End If

                                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, AlertType.ID, AlertCategory.ID,
                                                                                        AlertSubject, AlertBody,
                                                                                        Now, Priority, EmployeeCode, AlertUser, "",
                                                                                        AlertEmailBody, Alert) Then

                                    If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                        If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                            EmployeeEmail = Employee.Email

                                        End If

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                    End If

                                    If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                        Dim Body As String = Alert.EmailBody
                                        Try

                                            If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                                Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, True)

                                            End If

                                        Catch ex As Exception
                                        End Try
                                        AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", 2, SendingEmailStatus)

                                    End If

                                End If

                            Else

                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                                Console.WriteLine(AlertSubject)
                                Console.WriteLine(AlertBody)

                            End If

                        End If

                    End If

                End If

            End If

            CreateAlertForTaskNotification = AlertCreated

        End Function
        Private Function CreateAlertBodyHeaderForTaskNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                  ByVal EmployeeName As String,
                                                                  ByVal TaskNotificationAlertCategory As AdvantageFramework.AlertSystem.TaskNotificationAlertCategory,
                                                                  ByVal UseProductName As Boolean, ByVal RemoveTaskComments As Boolean,
                                                                  ByVal CustomMessage As String)

            'objects
            Dim AlertBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderString As String = ""
            Dim DaysOverdueString As String = ""
            Dim DaysOverdueLength As Integer = 0
            Dim HeaderDescriptions As String = ""

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If TaskNotificationAlertCategory = AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask Then

                        HeaderString = "The following tasks are past due for " & EmployeeName
                        DaysOverdueString = "Days Overdue"
                        DaysOverdueLength = 15

                    Else

                        HeaderString = "The following tasks are upcoming for " & EmployeeName
                        DaysOverdueString = ""
                        DaysOverdueLength = 0

                    End If

                    StringBuilder.AppendLine(HeaderString)
                    StringBuilder.AppendLine("")
                    StringBuilder.AppendLine(CustomMessage)
                    StringBuilder.AppendLine("")

                    If UseProductName Then

                        HeaderDescriptions &= AdvantageFramework.StringUtilities.PadWithCharacter("Product Name", 45)

                    Else

                        HeaderDescriptions &= AdvantageFramework.StringUtilities.PadWithCharacter("Client Name", 45)

                    End If

                    HeaderDescriptions &= AdvantageFramework.StringUtilities.PadWithCharacter("Job Component", 15) &
                                          AdvantageFramework.StringUtilities.PadWithCharacter("Component", 65) &
                                          AdvantageFramework.StringUtilities.PadWithCharacter("Task", 45) &
                                          AdvantageFramework.StringUtilities.PadWithCharacter("Start Date", 15) &
                                          AdvantageFramework.StringUtilities.PadWithCharacter("Due Date", 15) &
                                          AdvantageFramework.StringUtilities.PadWithCharacter(DaysOverdueString, DaysOverdueLength) &
                                          AdvantageFramework.StringUtilities.PadWithCharacter("Hours Allowed", 15)

                    If RemoveTaskComments = False Then

                        HeaderDescriptions &= AdvantageFramework.StringUtilities.PadWithCharacter("Task Comment", 25)

                    End If

                    StringBuilder.AppendLine()

                End If

                AlertBodyHeader = StringBuilder.ToString

            Catch ex As Exception
                AlertBodyHeader = ""
            Finally
                CreateAlertBodyHeaderForTaskNotification = AlertBodyHeader
            End Try

        End Function
        Private Function CreateAlertBodyDetailForTaskNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                  ByVal TaskNotificationAlertCategory As AdvantageFramework.AlertSystem.TaskNotificationAlertCategory,
                                                                  ByVal UseProductName As Boolean, ByVal RemoveTaskComments As Boolean,
                                                                  ByVal NotifyTaskDataList As List(Of AdvantageFramework.Database.Classes.NotifyTaskData))

            'objects
            Dim AlertBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim EMailString As String = ""
            Dim ClientNameString As String = ""
            Dim JobComponentNumber As String = ""
            Dim JobComponentDescription As String = ""
            Dim TaskDescriptionString As String = ""
            Dim StartDate As DateTime = Nothing
            Dim DueDate As DateTime = Nothing
            Dim StartDateString As String = ""
            Dim DueDateString As String = ""
            Dim HoursAllowedString As String = ""
            Dim Comment As String = ""
            Dim DaysOverdueString As String = ""
            Dim DaysOverdueLength As Integer = 0
            Dim Job As AdvantageFramework.Database.Views.JobView = Nothing
            Dim DetailLine As String = ""

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    For Each NotifyTaskData In NotifyTaskDataList

                        If NotifyTaskData.EMAIL IsNot Nothing Then

                            EMailString = NotifyTaskData.EMAIL

                        Else

                            EMailString = ""

                        End If

                        Job = AdvantageFramework.Database.Procedures.JobView.LoadByJobNumber(DbContext, NotifyTaskData.JOB_NUMBER)

                        If Job IsNot Nothing Then

                            If UseProductName Then

                                ClientNameString = Job.ProductDescription

                            Else

                                ClientNameString = Job.ClientName

                            End If

                        Else

                            ClientNameString = ""

                        End If

                        JobComponentNumber = AdvantageFramework.StringUtilities.PadWithCharacter(NotifyTaskData.JOB_NUMBER, 6, "0", True) + "-" +
                                                AdvantageFramework.StringUtilities.PadWithCharacter(NotifyTaskData.COMPONENT_NUMBER, 2, "0", True)

                        JobComponentDescription = NotifyTaskData.COMPONENT_DESC

                        If NotifyTaskData.TASK_DESC IsNot Nothing Then

                            TaskDescriptionString = NotifyTaskData.TASK_DESC.TrimStart()

                        Else

                            TaskDescriptionString = ""

                        End If

                        If NotifyTaskData.START_DATE IsNot Nothing Then

                            StartDate = NotifyTaskData.START_DATE
                            StartDateString = StartDate.ToShortDateString()

                        Else

                            StartDateString = ""

                        End If

                        If NotifyTaskData.DUE_DATE IsNot Nothing Then

                            DueDate = NotifyTaskData.DUE_DATE
                            DueDateString = DueDate.ToShortDateString()

                        Else

                            DueDateString = ""

                        End If

                        If NotifyTaskData.HOURS_ALLOWED IsNot Nothing Then

                            HoursAllowedString = NotifyTaskData.HOURS_ALLOWED.ToString()

                        Else

                            HoursAllowedString = ""

                        End If

                        If NotifyTaskData.COMMENT IsNot Nothing Then

                            Comment = NotifyTaskData.COMMENT.Substring(0, 25)

                        Else

                            Comment = ""

                        End If

                        If TaskNotificationAlertCategory = AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask Then

                            DaysOverdueString = (0 - NotifyTaskData.DATE_DIFF).ToString()
                            DaysOverdueLength = 15

                        Else

                            DaysOverdueString = ""
                            DaysOverdueLength = 0

                        End If

                        DetailLine = ""

                        DetailLine &= AdvantageFramework.StringUtilities.PadWithCharacter(ClientNameString, 45) &
                                      AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentNumber, 15) &
                                      AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentDescription, 65) &
                                      AdvantageFramework.StringUtilities.PadWithCharacter(TaskDescriptionString, 45) &
                                      AdvantageFramework.StringUtilities.PadWithCharacter(StartDateString, 15) &
                                      AdvantageFramework.StringUtilities.PadWithCharacter(DueDateString, 15) &
                                      AdvantageFramework.StringUtilities.PadWithCharacter(DaysOverdueString, DaysOverdueLength) &
                                      AdvantageFramework.StringUtilities.PadWithCharacter(HoursAllowedString, 15)

                        If RemoveTaskComments = False Then

                            DetailLine &= AdvantageFramework.StringUtilities.PadWithCharacter(Comment, 25)

                        End If

                        StringBuilder.AppendLine(DetailLine)

                    Next

                    AlertBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertBodyDetail = ""
            Finally
                CreateAlertBodyDetailForTaskNotification = AlertBodyDetail
            End Try

        End Function
        Public Function CreateAlertForTaskTempCompleteNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                        ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                        ByVal Manager As AdvantageFramework.Database.Views.Employee,
                                                        ByVal Task As AdvantageFramework.Database.Entities.JobComponentTask) As Boolean

            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings

            Dim AlertCreated As Boolean = False
            Dim ManagerEmail As String = Nothing
            Dim AlertBody As String = ""
            Dim AlertHeader As String = ""
            Dim AlertDetail As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertEmailHeader As String = ""
            Dim AlertEmailDetail As String = ""
            Dim AlertSubject As String = ""
            Dim EmployeeName As String = ""
            Dim Priority As Integer = 1
            Dim AlertUser As String = ""

            If Not Employee Is Nothing And Not Manager Is Nothing Then

                EmployeeName = Employee.ToString()

                AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext,
                                                                                                        AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ProjectSchedule.ToString))

                If AlertType IsNot Nothing Then

                    AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByID(DbContext, 63)

                    If AlertCategory IsNot Nothing Then

                        Alert = New AdvantageFramework.Database.Entities.Alert

                        With Alert

                            .DbContext = DbContext

                            .AlertCategoryID = AlertCategory.ID
                            .AlertTypeID = AlertType.ID
                            .UserCode = DbContext.UserCode
                            .EmployeeCode = Employee.Code
                            .GeneratedDate = Now
                            .PriorityLevel = AdvantageFramework.AlertSystem.PriorityLevels.Normal

                            .AlertLevel = "PST"
                            .JobNumber = Task.JobNumber
                            .JobComponentNumber = Task.JobComponentNumber
                            .TaskSequenceNumber = Task.SequenceNumber

                            .Subject = "Job " & Task.JobNumber & "-" & Task.JobComponentNumber & ": " & EmployeeName & " marked task " & Task.Description & " temp complete"
                            .Body = CreateAlertEmailBodyForTaskDetails(DbContext, Task)
                            .EmailBody = .Body

                        End With

                        If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) = True Then

                            If CheckEmployeeAlertNotificationForAlert(Manager) = True Then

                                If Manager.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                    ManagerEmail = Manager.Email

                                End If
                                Dim Recipient As New AdvantageFramework.Database.Entities.AlertRecipient
                                With Recipient

                                    .DbContext = DbContext

                                    .AlertID = Alert.ID
                                    .EmployeeCode = Manager.Code
                                    .EmployeeEmail = Manager.Email
                                    .IsNewAlert = 1

                                End With
                                If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient) = True Then

                                    AlertCreated = True

                                End If

                            End If
                            If CheckEmployeeAlertNotificationForEmail(Manager) = True Then

                                Dim Body As String = Alert.EmailBody
                                Try

                                    If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                        Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, False)

                                    End If

                                Catch ex As Exception
                                End Try

                                AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Manager, Alert.Subject, Body, 2, SendingEmailStatus)

                            End If

                        End If

                    End If

                End If

            End If

            Return AlertCreated

        End Function

#End Region

#Region "   EMail "
        Private Function CreateAlertEmailBodyHeaderForTaskNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal EmployeeName As String,
                                                                       ByVal TaskNotificationAlertCategory As AdvantageFramework.AlertSystem.TaskNotificationAlertCategory,
                                                                       ByVal UseProductName As Boolean, ByVal RemoveTaskComments As Boolean,
                                                                       ByVal CustomMessage As String)

            'objects
            Dim AlertEmailBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderString As String

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If TaskNotificationAlertCategory = AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask Then

                        HeaderString = "The following tasks are past due for " & EmployeeName

                    Else

                        HeaderString = "The following tasks for " & EmployeeName & " are due soon"

                    End If

                    StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr><td colspan=""2"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """>")
                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """>")
                    StringBuilder.AppendLine("<strong>" & HeaderString & "</strong></font></td></tr>")
                    StringBuilder.AppendLine("</table>")

                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """><br/></font>")
                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """>" + CustomMessage + "<br/><br/></font>")

                    StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr>")

                    If UseProductName Then

                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Product Name</strong></font></td>")

                    Else

                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Client Name</strong></font></td>")

                    End If

                    StringBuilder.AppendLine("<td width=110 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Job Component</strong></font></td>")
                    StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Component</strong></font></td>")
                    StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Task</strong></font></td>")
                    StringBuilder.AppendLine("<td width=85  align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """ style='text-align:right'><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Start Date</strong></font></td>")
                    StringBuilder.AppendLine("<td width=85  align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """ style='text-align:right'><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Due Date</strong></font></td>")

                    If TaskNotificationAlertCategory = AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask Then

                        StringBuilder.AppendLine("<td width=110 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """ style='text-align:right'><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Days Overdue</strong></font></td>")

                    End If

                    StringBuilder.AppendLine("<td width=110 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """ style='text-align:right'><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Hours Allowed</strong></font></td>")

                    If RemoveTaskComments = False Then

                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Task Comment</strong></font></td>")

                    End If

                    StringBuilder.AppendLine("</tr>")

                    StringBuilder.Append("<hr size=""1"" color=""" & AdvantageFramework.Email.HeaderFontColor & """ />")

                    AlertEmailBodyHeader = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyHeader = ""
            Finally
                CreateAlertEmailBodyHeaderForTaskNotification = AlertEmailBodyHeader
            End Try

        End Function
        Private Function CreateAlertEmailBodyDetailForTaskNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                       ByVal TaskNotificationAlertCategory As AdvantageFramework.AlertSystem.TaskNotificationAlertCategory,
                                                                       ByVal UseProductName As Boolean, ByVal RemoveTaskComments As Boolean,
                                                                       ByVal NotifyTaskDataList As List(Of AdvantageFramework.Database.Classes.NotifyTaskData)) As String
            'objects
            Dim AlertEmailBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim EMailString As String = ""
            Dim ClientNameString As String = ""
            Dim JobComponentNumber As String = ""
            Dim JobComponentDescription As String = ""
            Dim TaskDescriptionString As String = ""
            Dim StartDate As DateTime = Nothing
            Dim DueDate As DateTime = Nothing
            Dim StartDateString As String = ""
            Dim DueDateString As String = ""
            Dim HoursAllowedString As String = ""
            Dim Comment As String = ""
            Dim DaysOverdueString As String = ""
            Dim Job As AdvantageFramework.Database.Views.JobView = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    For Each EmployeeTask In NotifyTaskDataList

                        If EmployeeTask.EMAIL IsNot Nothing Then

                            EMailString = EmployeeTask.EMAIL

                        Else

                            EMailString = ""

                        End If

                        Job = AdvantageFramework.Database.Procedures.JobView.LoadByJobNumber(DbContext, EmployeeTask.JOB_NUMBER)

                        If Job IsNot Nothing Then

                            If UseProductName Then

                                ClientNameString = Job.ProductDescription

                            Else

                                ClientNameString = Job.ClientName

                            End If

                        Else

                            ClientNameString = ""

                        End If

                        JobComponentNumber = AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTask.JOB_NUMBER, 6, "0", True) + "-" +
                                                AdvantageFramework.StringUtilities.PadWithCharacter(EmployeeTask.COMPONENT_NUMBER, 2, "0", True)

                        JobComponentDescription = EmployeeTask.COMPONENT_DESC

                        If EmployeeTask.TASK_DESC IsNot Nothing Then

                            TaskDescriptionString = EmployeeTask.TASK_DESC.TrimStart()

                        Else

                            TaskDescriptionString = ""

                        End If

                        If EmployeeTask.START_DATE IsNot Nothing Then

                            StartDate = EmployeeTask.START_DATE
                            StartDateString = StartDate.ToShortDateString()

                        Else

                            StartDateString = ""

                        End If

                        If EmployeeTask.DUE_DATE IsNot Nothing Then

                            DueDate = EmployeeTask.DUE_DATE
                            DueDateString = DueDate.ToShortDateString()

                        Else

                            DueDateString = ""

                        End If

                        If EmployeeTask.HOURS_ALLOWED IsNot Nothing Then

                            HoursAllowedString = EmployeeTask.HOURS_ALLOWED.ToString()

                        Else

                            HoursAllowedString = ""

                        End If

                        If EmployeeTask.COMMENT IsNot Nothing Then

                            Comment = EmployeeTask.COMMENT

                        Else

                            Comment = ""

                        End If

                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ClientNameString & "</font></td>")
                        StringBuilder.AppendLine("<td width=""110"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & JobComponentNumber & "</font></td>")
                        StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & JobComponentDescription & "</font></td>")
                        StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & TaskDescriptionString & "</font></td>")
                        StringBuilder.AppendLine("<td width=""85""  valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """  style='text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & StartDateString & "</font></td>")
                        StringBuilder.AppendLine("<td width=""85""  valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & DueDateString & "</font></td>")

                        If TaskNotificationAlertCategory = AdvantageFramework.AlertSystem.TaskNotificationAlertCategory.PastDueTask Then

                            DaysOverdueString = (0 - EmployeeTask.DATE_DIFF).ToString()
                            StringBuilder.AppendLine("<td width=""110"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & DaysOverdueString & "</font></td>")

                        End If

                        StringBuilder.AppendLine("<td width=""110"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & HoursAllowedString & "</font></td>")

                        If RemoveTaskComments = False Then

                            StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & Comment & "</font></td>")

                        End If

                        StringBuilder.AppendLine("</tr>")

                    Next

                    StringBuilder.AppendLine("</table>")

                    AlertEmailBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyDetail = ""
            Finally
                CreateAlertEmailBodyDetailForTaskNotification = AlertEmailBodyDetail
            End Try

        End Function
        Private Function CreateAlertEmailBodyForTaskDetails(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal Task As AdvantageFramework.Database.Entities.JobComponentTask, Optional ByVal AlertID As Integer = 0) As String

            Dim HtmlEmail As New AdvantageFramework.Email.Classes.HtmlEmail(False)
            Dim TaskEmployees As New Generic.List(Of AdvantageFramework.Database.Entities.JobComponentTaskEmployee)

            TaskEmployees = AdvantageFramework.Database.Procedures.JobComponentTaskEmployee.LoadByJobCompSeq(DbContext,
                                                                                                             Task.JobNumber,
                                                                                                             Task.JobComponentNumber,
                                                                                                             Task.SequenceNumber).ToList()

            With HtmlEmail

                .AddHeaderRow("Client/Job Information")

                .AddKeyValueRow("Client", Task.JobComponent.Job.Client.Name)
                .AddKeyValueRow("Division", Task.JobComponent.Job.Division.Name)
                .AddKeyValueRow("Product", Task.JobComponent.Job.Product.Name)
                .AddKeyValueRow("Job", Task.JobComponent.JobNumber & " - " & Task.JobComponent.Job.Description)
                .AddKeyValueRow("Component", Task.JobComponent.Number & " - " & Task.JobComponent.Description)

                .AddHeaderRow("Task Information")

                If Not Task.TaskCode Is Nothing Then
                    .AddKeyValueRow("Task", Task.TaskCode & " - " & Task.Description)
                Else
                    .AddKeyValueRow("Task", Task.Description)
                End If

                .AddKeyValueRow("Start - Due", Task.StartDate & " - " & Task.DueDate)

                .AddHeaderRow("Employees")

                .AddCustomRow("<table width=""100%"" border=""0"" cellspacing=""2"" cellpadding=""0"">")
                .AddCustomRow("<tr><td><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" &
                              AdvantageFramework.Email.RowFontColor & """>Employees</font></td><td><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" &
                              AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>Temp Complete Date</font></td></tr>")

                Dim DateDisplay As String = "N/A"

                For Each TaskEmployee In TaskEmployees

                    If Not TaskEmployee.TempCompletionDate Is Nothing AndAlso IsDate(TaskEmployee.TempCompletionDate) = True Then

                        DateDisplay = CType(TaskEmployee.TempCompletionDate, Date).ToShortDateString()

                    Else

                        DateDisplay = "N/A"

                    End If

                    .AddCustomRow(String.Format("<tr><td><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" &
                                                AdvantageFramework.Email.RowFontColor & """>{0}</font></td><td><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" &
                                                AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>{1}</font></td></tr>",
                                                AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, TaskEmployee.EmployeeCode).ToString(),
                                                DateDisplay)
                                 )

                Next

                .AddCustomRow("</table>")

                .Finish()

            End With

            Return HtmlEmail.ToString(AlertID)

        End Function

#End Region

#End Region

#Region "  QvA "

#Region "   Alert "
        Public Function CreateAlertForQvANotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                        ByVal EmployeeCode As String,
                                                        ByVal ThresholdLevel As Integer,
                                                        ByVal ThresholdLevelStart As Decimal,
                                                        ByVal ThresholdLevelEnd As Decimal,
                                                        ByVal ThresholdDescription As String,
                                                        ByVal ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel,
                                                        ByRef JobsList As List(Of AdvantageFramework.Services.QvAAlert.Classes.QvAJob)) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertTypeString As String
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim AlertCategoryString As String
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertHeader As String = ""
            Dim AlertDetail As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertEmailHeader As String = ""
            Dim AlertEmailDetail As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim Priority As Integer = 1
            Dim AlertUser As String = ""
            Dim NewThresholdDescription As String = ""

            If DbContext IsNot Nothing Then

                If JobsList IsNot Nothing AndAlso JobsList.Count > 0 Then

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString()

                        AlertTypeString = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.Production.ToString)

                        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AlertTypeString)

                        If AlertType IsNot Nothing Then

                            AlertCategoryString = AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.QvANotificationAlertCategory.QuoteVsActualAlert.ToString)

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AlertCategoryString)

                            If AlertCategory IsNot Nothing Then

                                AlertHeader = AdvantageFramework.AlertSystem.CreateAlertBodyHeaderForQvANotification(DbContext, ThresholdLevel, ThresholdLevelStart, ThresholdLevelEnd, ShowLevel)
                                AlertEmailHeader = AdvantageFramework.AlertSystem.CreateAlertEmailBodyHeaderForQvANotification(DbContext, ThresholdLevel, ThresholdLevelStart, ThresholdLevelEnd, ShowLevel)

                                AlertDetail = AdvantageFramework.AlertSystem.CreateAlertBodyDetailForQvANotification(DbContext, ShowLevel, JobsList)
                                AlertEmailDetail = AdvantageFramework.AlertSystem.CreateAlertEmailBodyDetailForQvANotification(DbContext, ShowLevel, JobsList)

                                AlertBody = AlertHeader + vbCrLf + AlertDetail
                                AlertEmailBody = AlertEmailHeader + vbCrLf + AlertEmailDetail

                                If ThresholdDescription.Length = 0 Then

                                    If ThresholdLevel = 3 Then

                                        NewThresholdDescription = "Actual to Estimate Ratio is " + ThresholdLevelStart.ToString() + "% or over"

                                    Else

                                        NewThresholdDescription = "Actual to Estimate Ratio is between " + ThresholdLevelStart.ToString() + "% and " + ThresholdLevelEnd.ToString() + "%"

                                    End If

                                Else

                                    NewThresholdDescription = ThresholdDescription

                                End If

                                AlertSubject = "Quote vs. Actual Results - Alert Level " + ThresholdLevel.ToString() + " - " + NewThresholdDescription
                                Priority = 1

                                AlertUser = DbContext.UserCode

                                If AlertUser.Length = 0 Then

                                    AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                                End If

                                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, AlertType.ID, AlertCategory.ID,
                                                                                        AlertSubject, AlertBody,
                                                                                        Now, Priority, EmployeeCode, AlertUser, "",
                                                                                        AlertEmailBody, Alert) Then

                                    If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                        If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                            EmployeeEmail = Employee.Email

                                        End If

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                    End If

                                    If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                        Dim Body As String = Alert.EmailBody
                                        Try

                                            If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                                Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, True)

                                            End If

                                        Catch ex As Exception
                                        End Try

                                        AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", 2, SendingEmailStatus)

                                    End If

                                End If

                            Else

                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                                Console.WriteLine("Alert Sent To: " + EmployeeName)
                                Console.WriteLine(AlertSubject)
                                Console.WriteLine(AlertBody)

                            End If

                        End If

                    End If

                End If

            End If

            CreateAlertForQvANotification = AlertCreated

        End Function
        Private Function CreateAlertBodyHeaderForQvANotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                    ByVal ThresholdLevel As Integer,
                                                                    ByVal ThresholdLevelStart As Decimal,
                                                                    ByVal ThresholdLevelEnd As Decimal,
                                                                    ByVal ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel) As String

            'objects
            Dim AlertBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderString As String = ""
            Dim FunctionDescriptionAndType As String = ""
            Dim FunctionDescriptionAndTypeLength As Integer = 0

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If ThresholdLevel = 3 Then

                        HeaderString = "Actual to Estimate Ratio is " + ThresholdLevelStart.ToString() + "% or over"

                    Else

                        HeaderString = "Actual to Estimate Ratio is between " + ThresholdLevelStart.ToString() + "% and " + ThresholdLevelEnd.ToString() + "%"

                    End If

                    If ShowLevel = AdvantageFramework.Services.QvAAlert.ShowLevel.JobAndFunctions Then

                        FunctionDescriptionAndType = "Function Description (Type)"
                        FunctionDescriptionAndTypeLength = 45

                    End If

                    StringBuilder.AppendLine("The following jobs meet the threshold rule:")
                    StringBuilder.AppendLine("")
                    StringBuilder.AppendLine(HeaderString)
                    StringBuilder.AppendLine("")
                    StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter("Client Name", 45) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter("Job Component", 15) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter("Component Description", 65) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(FunctionDescriptionAndType, FunctionDescriptionAndTypeLength) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter("Quote Total", 12, " ", True) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(" ", 5) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter("Actual Total", 12, " ", True) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter(" ", 5) &
                                                AdvantageFramework.StringUtilities.PadWithCharacter("% of Quote", 10))

                End If

                AlertBodyHeader = StringBuilder.ToString

            Catch ex As Exception
                AlertBodyHeader = ""
            Finally
                CreateAlertBodyHeaderForQvANotification = AlertBodyHeader
            End Try

        End Function
        Private Function CreateAlertBodyDetailForQvANotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                    ByVal ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel,
                                                                    ByRef JobsList As List(Of AdvantageFramework.Services.QvAAlert.Classes.QvAJob)) As String

            'objects
            Dim AlertBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim ClientCodeString As String = ""
            Dim JobComponentNumberString As String = ""
            Dim ComponentDescriptionString As String = ""
            Dim PercentString As String = ""
            Dim FunctionDescriptionAndType As String
            Dim FunctionDescriptionAndTypeLength As Integer = 0
            Dim QuotedString As String = ""
            Dim ActualString As String = ""

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    For Each Job In JobsList

                        If Job.ClientName IsNot Nothing Then

                            ClientCodeString = Job.ClientName

                        Else

                            ClientCodeString = ""

                        End If

                        JobComponentNumberString = AdvantageFramework.StringUtilities.PadWithCharacter(Job.JobNumber, 6, "0", True) + "-" +
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(Job.ComponentNumber, 2, "0", True)

                        If Job.ComponentDescription IsNot Nothing Then

                            ComponentDescriptionString = Job.ComponentDescription

                        Else

                            ComponentDescriptionString = ""

                        End If

                        If ShowLevel = AdvantageFramework.Services.QvAAlert.ShowLevel.JobAndFunctions Then

                            FunctionDescriptionAndTypeLength = 45

                        End If

                        QuotedString = FormatCurrency(Job.Quoted).TrimStart("$")
                        ActualString = FormatCurrency(Job.Actual).TrimStart("$")
                        PercentString = String.Format("{0:F}", Job.QvA)

                        StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter(ClientCodeString, 45) &
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(JobComponentNumberString, 15) &
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(ComponentDescriptionString, 65) &
                                                    AdvantageFramework.StringUtilities.PadWithCharacter("", FunctionDescriptionAndTypeLength) &
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(QuotedString, 12, " ", True) &
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(" ", 5) &
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(ActualString, 12, " ", True) &
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(" ", 5) &
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(PercentString, 10, " ", True))

                        If ShowLevel = AdvantageFramework.Services.QvAAlert.ShowLevel.JobAndFunctions Then

                            If Job.FunctionList IsNot Nothing Then

                                For Each [Function] In Job.FunctionList

                                    FunctionDescriptionAndType = [Function].FunctionDescription + " (" + [Function].FunctionTypeCode + ")"

                                    QuotedString = FormatCurrency([Function].Quoted).TrimStart("$")
                                    ActualString = FormatCurrency([Function].Actual).TrimStart("$")
                                    PercentString = String.Format("{0:F}", [Function].QvA)

                                    StringBuilder.AppendLine(AdvantageFramework.StringUtilities.PadWithCharacter(" ", 25) &
                                                                AdvantageFramework.StringUtilities.PadWithCharacter(" ", 15) &
                                                                AdvantageFramework.StringUtilities.PadWithCharacter(" ", 65) &
                                                                AdvantageFramework.StringUtilities.PadWithCharacter(FunctionDescriptionAndType, FunctionDescriptionAndTypeLength) &
                                                                AdvantageFramework.StringUtilities.PadWithCharacter(QuotedString, 12, " ", True) &
                                                                AdvantageFramework.StringUtilities.PadWithCharacter(" ", 5) &
                                                                AdvantageFramework.StringUtilities.PadWithCharacter(ActualString, 12, " ", True) &
                                                                AdvantageFramework.StringUtilities.PadWithCharacter(" ", 5) &
                                                                AdvantageFramework.StringUtilities.PadWithCharacter(PercentString, 10, " ", True))

                                Next

                            End If

                            StringBuilder.AppendLine()

                        End If

                    Next

                    AlertBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertBodyDetail = ""
            Finally
                CreateAlertBodyDetailForQvANotification = AlertBodyDetail
            End Try

        End Function

#End Region

#Region "   EMail "
        Private Function CreateAlertEmailBodyHeaderForQvANotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                        ByVal ThresholdLevel As Integer,
                                                                        ByVal ThresholdLevelStart As Decimal,
                                                                        ByVal ThresholdLevelEnd As Decimal,
                                                                        ByVal ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel)

            'objects
            Dim AlertEmailBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderString As String

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If ThresholdLevel = 3 Then

                        HeaderString = "Actual to Estimate Ratio is " + ThresholdLevelStart.ToString() + "% or over"

                    Else

                        HeaderString = "Actual to Estimate Ratio is between " + ThresholdLevelStart.ToString() + "% and " + ThresholdLevelEnd.ToString() + "%"

                    End If

                    StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr><td colspan=""2"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """>")
                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """>")
                    StringBuilder.AppendLine("<strong>The following jobs meet the threshold rule:</strong></font></td></tr>")
                    StringBuilder.AppendLine("</table>")

                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><br/></font>")
                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """>" + HeaderString + "<br/><br/></font>")

                    StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr>")
                    StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Client Name</strong></font></td>")
                    StringBuilder.AppendLine("<td width=""110"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Job Component</strong></font></td>")
                    StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Component Description</strong></font></td>")

                    If ShowLevel = AdvantageFramework.Services.QvAAlert.ShowLevel.JobAndFunctions Then

                        StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Function Description (Type)</strong></font></td>")

                    End If

                    StringBuilder.AppendLine("<td width=""100"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Quote Total</strong></font></td>")
                    StringBuilder.AppendLine("<td width=""100"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>Actual Total</strong></font></td>")
                    StringBuilder.AppendLine("<td width=""100"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """><font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """><strong>% of Quote</strong></font></td>")
                    StringBuilder.AppendLine("</tr>")

                    If ShowLevel = AdvantageFramework.Services.QvAAlert.ShowLevel.JobAndFunctions Then
                        StringBuilder.AppendLine("<tr><td colspan=""7"">")
                    Else
                        StringBuilder.AppendLine("<tr><td colspan=""6"">")
                    End If
                    StringBuilder.Append("<hr size=""1"" color=""" & AdvantageFramework.Email.HeaderFontColor & """ />")
                    StringBuilder.AppendLine("</td></tr>")

                    AlertEmailBodyHeader = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyHeader = ""
            Finally
                CreateAlertEmailBodyHeaderForQvANotification = AlertEmailBodyHeader
            End Try

        End Function
        Private Function CreateAlertEmailBodyDetailForQvANotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                        ByVal ShowLevel As AdvantageFramework.Services.QvAAlert.ShowLevel,
                                                                        ByRef JobsList As List(Of AdvantageFramework.Services.QvAAlert.Classes.QvAJob)) As String

            'objects
            Dim AlertEmailBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim ClientCodeString As String = ""
            Dim JobComponentNumberString As String = ""
            Dim ComponentDescriptionString As String = ""
            Dim PercentString As String = ""
            Dim FunctionDescriptionAndType As String = ""
            Dim FunctionDescriptionAndTypeLength As Integer = 0
            Dim QuotedString As String = ""
            Dim ActualString As String = ""

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    For Each Job In JobsList

                        If Job.ClientName IsNot Nothing Then

                            ClientCodeString = Job.ClientName

                        Else

                            ClientCodeString = ""

                        End If

                        JobComponentNumberString = AdvantageFramework.StringUtilities.PadWithCharacter(Job.JobNumber, 6, "0", True) + "-" +
                                                    AdvantageFramework.StringUtilities.PadWithCharacter(Job.ComponentNumber, 2, "0", True)

                        If Job.ComponentDescription IsNot Nothing Then

                            ComponentDescriptionString = Job.ComponentDescription

                        Else

                            ComponentDescriptionString = ""

                        End If

                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & "'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ClientCodeString & "</font></td>")
                        StringBuilder.AppendLine("<td width=""110"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & "'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & JobComponentNumberString & "</font></td>")
                        StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & "'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ComponentDescriptionString & "</font></td>")

                        If ShowLevel = AdvantageFramework.Services.QvAAlert.ShowLevel.JobAndFunctions Then

                            StringBuilder.AppendLine("<td width=""200"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & "'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>&nbsp;</font></td>")

                        End If

                        QuotedString = FormatCurrency(Job.Quoted).TrimStart("$")
                        ActualString = FormatCurrency(Job.Actual).TrimStart("$")
                        PercentString = String.Format("{0:F}", Job.QvA)

                        StringBuilder.AppendLine("<td width=""100"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & ";text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & QuotedString & "</font></td>")
                        StringBuilder.AppendLine("<td width=""100"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & ";text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ActualString & "</font></td>")
                        StringBuilder.AppendLine("<td width=""100"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & ";text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & PercentString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")

                        If ShowLevel = AdvantageFramework.Services.QvAAlert.ShowLevel.JobAndFunctions Then

                            If Job.FunctionList IsNot Nothing Then

                                For Each [Function] In Job.FunctionList

                                    FunctionDescriptionAndType = [Function].FunctionDescription + " (" + [Function].FunctionTypeCode + ")"

                                    QuotedString = FormatCurrency([Function].Quoted).TrimStart("$")
                                    ActualString = FormatCurrency([Function].Actual).TrimStart("$")
                                    PercentString = String.Format("{0:F}", [Function].QvA)

                                    StringBuilder.AppendLine("<tr>")
                                    StringBuilder.AppendLine("<td width=""200"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & "'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>&nbsp;</font></td>")
                                    StringBuilder.AppendLine("<td width=""110"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & "'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>&nbsp;</font></td>")
                                    StringBuilder.AppendLine("<td width=""200"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & "'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>&nbsp;</font></td>")
                                    StringBuilder.AppendLine("<td width=""200"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & "'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & FunctionDescriptionAndType & " </font></td>")
                                    StringBuilder.AppendLine("<td width=""100"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & ";text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & QuotedString & "</font></td>")
                                    StringBuilder.AppendLine("<td width=""100"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & ";text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ActualString & "</font></td>")
                                    StringBuilder.AppendLine("<td width=""100"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """ style='border:solid windowtext 1.0pt;border-color:" & AdvantageFramework.Email.RowBackgroundColor & ";text-align:right'><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & PercentString & "</font></td>")
                                    StringBuilder.AppendLine("</tr>")

                                Next

                            End If

                            StringBuilder.AppendLine()

                        End If

                    Next

                    StringBuilder.AppendLine("</table>")

                    AlertEmailBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyDetail = ""
            Finally
                CreateAlertEmailBodyDetailForQvANotification = AlertEmailBodyDetail
            End Try

        End Function

#End Region

#End Region

#Region "  Missing Time "

#Region "   Alert "
        Public Function CreateAlertForMissingTimeNotificationForSupervisor(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                            ByRef DataContext As AdvantageFramework.Database.DataContext,
                                                                            ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                            ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                                                            ByVal Supervisor As AdvantageFramework.Database.Views.Employee,
                                                                            ByVal AlertSubject As String,
                                                                            ByVal CustomMessage As String,
                                                                            ByVal Priority As Integer,
                                                                            ByVal EndDate As Date,
                                                                            ByVal SupervisorEndDate As Date,
                                                                            ByVal AlertTypeID As Integer,
                                                                            ByVal AlertCategoryID As Integer,
                                                                            ByRef EventLogRef As EventLog,
                                                                            ByVal MissingTimeOnly As Boolean,
                                                                            ByVal IncludeOnlyDaysThatAreLate As Boolean) As Boolean
            'objects
            Dim AlertCreated As Boolean = False
            Dim EmployeeListForSupervisor As List(Of String) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim OneAlertBody As String = ""
            Dim OneAlertEmailBody As String = ""
            Dim OneAlertExists As Boolean = False

            Try

                EmployeeListForSupervisor = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadDistinctEmployeeCodesBySupervisorEmployeeCodesAndLessThanOrEqualToDate(DataContext, Supervisor.Code, EndDate).ToList()

                For Each EmployeeCode In EmployeeListForSupervisor

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        If GenerateAlertForMissingTimeNotification(DataContext, Agency, Employee, CustomMessage,
                                                                    EventLogRef, OneAlertBody, OneAlertEmailBody, MissingTimeOnly,
                                                                    EndDate, SupervisorEndDate, IncludeOnlyDaysThatAreLate) Then

                            OneAlertExists = True

                            If AlertBody.Length > 0 Then

                                AlertBody += vbCrLf

                            End If

                            AlertBody += OneAlertBody

                            If AlertEmailBody.Length > 0 Then

                                AlertEmailBody += vbCrLf

                            End If

                            AlertEmailBody += OneAlertEmailBody

                        End If

                    End If

                Next

                If OneAlertExists Then

                    If PostAlertForMissingTimeNotification(DbContext,
                                                            SecurityDbContext,
                                                            Supervisor,
                                                            AlertSubject,
                                                            Priority,
                                                            AlertTypeID,
                                                            AlertCategoryID,
                                                            EventLogRef,
                                                            AlertBody,
                                                            AlertEmailBody,
                                                            MissingTimeOnly) Then

                        AlertCreated = True

                    End If

                End If

            Catch ex As Exception

                AlertCreated = False

            End Try

            CreateAlertForMissingTimeNotificationForSupervisor = AlertCreated

        End Function
        Public Function CreateAlertForMissingTimeNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                ByRef DataContext As AdvantageFramework.Database.DataContext,
                                                                ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                                                ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                                ByVal AlertSubject As String,
                                                                ByVal CustomMessage As String,
                                                                ByVal Priority As Integer,
                                                                ByVal AlertTypeID As Integer,
                                                                ByVal AlertCategoryID As Integer,
                                                                ByVal MissingTimeOnly As Boolean,
                                                                ByVal EndDate As Date,
                                                                ByVal EmployeeEndDate As Date,
                                                                ByVal IncludeOnlyDaysThatAreLate As Boolean,
                                                                ByRef EventLog As EventLog) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""

            Try

                If GenerateAlertForMissingTimeNotification(DataContext, Agency, Employee, CustomMessage,
                                                            EventLog, AlertBody, AlertEmailBody, MissingTimeOnly, EndDate, EmployeeEndDate, IncludeOnlyDaysThatAreLate) Then

                    If PostAlertForMissingTimeNotification(DbContext, SecurityDbContext, Employee, AlertSubject, Priority,
                                                            AlertTypeID, AlertCategoryID, EventLog, AlertBody, AlertEmailBody, MissingTimeOnly) Then

                        AlertCreated = True

                    End If

                End If

            Catch ex As Exception
                AlertCreated = False
            End Try

            CreateAlertForMissingTimeNotification = AlertCreated

        End Function
        Public Function MissingTimeListValid(ByRef MissingTimeList As List(Of AdvantageFramework.Database.Entities.MissingTimeDetail), ByVal WeeklyTimeType As Integer,
                                                ByVal MissingTimeOnly As Boolean) As Boolean

            'objects
            Dim IsMissingTimeListValid As Boolean = False
            Dim NumberOfMissingDays As Integer = 0

            Try

                If MissingTimeList IsNot Nothing AndAlso MissingTimeList.Count > 0 Then

                    If WeeklyTimeType = 0 Then

                        If MissingTimeOnly Then

                            NumberOfMissingDays = (From MissingTimeDetail In MissingTimeList
                                                   Where MissingTimeDetail.StandardHours > 0 AndAlso
                                                           MissingTimeDetail.StandardHours = MissingTimeDetail.HoursDifference
                                                   Select MissingTimeDetail).Count()

                            If NumberOfMissingDays > 0 Then

                                IsMissingTimeListValid = True

                            End If

                        Else

                            NumberOfMissingDays = (From MissingTimeDetail In MissingTimeList
                                                   Where MissingTimeDetail.HoursDifference > 0
                                                   Select MissingTimeDetail).Count()

                            If NumberOfMissingDays > 0 Then

                                IsMissingTimeListValid = True

                            End If

                        End If

                    Else

                        If MissingTimeOnly Then

                            For Each TotalWeeklyDetails In (From MissingTimeDetail In MissingTimeList
                                                            Group MissingTimeDetail By WeekStart = MissingTimeDetail.StartOfWeekDate Into Group
                                                            Order By WeekStart
                                                            Select WeekStart,
                                                                    StandardHours = (From OneInWeek In Group Select OneInWeek.StandardHours).Sum,
                                                                    HoursWorked = (From OneInWeek In Group Select OneInWeek.HoursWorked).Sum,
                                                                    HoursDifference = (From OneInWeek In Group Select OneInWeek.HoursDifference).Sum)

                                If TotalWeeklyDetails.StandardHours > 0 AndAlso
                                        TotalWeeklyDetails.StandardHours = TotalWeeklyDetails.HoursDifference Then

                                    IsMissingTimeListValid = True
                                    Exit For

                                End If

                            Next

                        Else

                            For Each TotalWeeklyHoursDifference In (From MissingTimeDetail In MissingTimeList
                                                                    Group MissingTimeDetail By WeekStart = MissingTimeDetail.StartOfWeekDate Into Group
                                                                    Order By WeekStart
                                                                    Select WeekStart, (From OneInWeek In Group
                                                                                       Select OneInWeek.HoursDifference).Sum)

                                If TotalWeeklyHoursDifference.Sum > 0 Then

                                    IsMissingTimeListValid = True
                                    Exit For

                                End If

                            Next

                        End If

                    End If

                End If

            Catch ex As Exception
                IsMissingTimeListValid = False
            End Try

            MissingTimeListValid = IsMissingTimeListValid

        End Function
        Public Function GenerateAlertForMissingTimeNotification(ByRef DataContext As AdvantageFramework.Database.DataContext,
                                                                ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                                                ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                                ByVal CustomMessage As String,
                                                                ByRef EventLogRef As EventLog,
                                                                ByRef AlertBody As String,
                                                                ByRef AlertEmailBody As String,
                                                                ByVal MissingTimeOnly As Boolean,
                                                                ByVal EndDate As Date,
                                                                ByVal SupervisorEmployeeEndDate As Date,
                                                                ByVal IncludeOnlyDaysThatAreLate As Boolean) As Boolean

            'objects
            Dim AlertGenerated As Boolean = False
            Dim MissingTimeList As List(Of AdvantageFramework.Database.Entities.MissingTimeDetail) = Nothing
            Dim WeeklyTimeType As Integer = 0
            Dim ValidList As Boolean = False

            Try

                If Employee IsNot Nothing Then

                    WeeklyTimeType = Employee.WeeklyTimeType.GetValueOrDefault(2)

                    If WeeklyTimeType = 2 Then

                        If Agency IsNot Nothing Then

                            WeeklyTimeType = Agency.WeeklyTimeType.GetValueOrDefault(0)

                        Else

                            WeeklyTimeType = 0

                        End If

                    End If

                    MissingTimeList = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCodeAndLessThanOrEqualToDate(DataContext, Employee.Code, SupervisorEmployeeEndDate).ToList

                    If MissingTimeListValid(MissingTimeList, WeeklyTimeType, MissingTimeOnly) Then

                        If IncludeOnlyDaysThatAreLate Then

                            MissingTimeList = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCodeAndLessThanOrEqualToDate(DataContext, Employee.Code, SupervisorEmployeeEndDate).ToList

                        Else

                            MissingTimeList = AdvantageFramework.Database.Procedures.MissingTimeDetail.LoadByEmployeeCodeAndLessThanOrEqualToDate(DataContext, Employee.Code, EndDate).ToList

                        End If

                        If EventLogRef IsNot Nothing Then

                            EventLogRef.WriteEntry("Found " & MissingTimeList.Count.ToString() & " detail records for Employee --> " & Employee.Code & " - " & Employee.ToString())

                        End If

                        AlertEmailBody = CreateAlertEmailBodyForMissingTimeNotification(MissingTimeList, CustomMessage, Employee.Code, Employee.ToString(), (WeeklyTimeType = 0), MissingTimeOnly, Agency.WebvantageURL)
                        AlertBody = AlertEmailBody

                        ' AlertBody = CreateAlertBodyForMissingTimeNotification(MissingTimeList, CustomMessage, (WeeklyTimeType = 0), MissingTimeOnly)

                        If EventLogRef IsNot Nothing Then

                            EventLogRef.WriteEntry("Alert Generated for Employee --> " & Employee.Code & " - " & Employee.ToString())

                        End If

                        AlertGenerated = True

                    End If

                End If

            Catch ex As Exception
                AlertGenerated = False
            End Try

            GenerateAlertForMissingTimeNotification = AlertGenerated

        End Function
        Public Function PostAlertForMissingTimeNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                            ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                                            ByVal AlertSubject As String,
                                                            ByVal Priority As Integer,
                                                            ByVal AlertTypeID As Integer,
                                                            ByVal AlertCategoryID As Integer,
                                                            ByRef EventLogRef As EventLog,
                                                            ByRef AlertBody As String,
                                                            ByRef AlertEmailBody As String,
                                                            ByVal MissingTimeOnly As Boolean) As Boolean

            'objects
            Dim AlertPosted As Boolean = False
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertUser As String = ""
            Dim EmployeeEmail As String = ""

            Try

                If Employee IsNot Nothing Then

                    AlertUser = DbContext.UserCode

                    If AlertUser.Length = 0 Then

                        AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                    End If

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, AlertTypeID, AlertCategoryID,
                                                                            AlertSubject, AlertBody,
                                                                            Now, Priority, Employee.Code, AlertUser, "",
                                                                            AlertEmailBody, Alert) Then

                        If EventLogRef IsNot Nothing Then

                            EventLogRef.WriteEntry("Alert Inserted for Employee --> " & Employee.Code + " - " & Employee.ToString())

                        End If

                        If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForAlert(Employee) Then

                            If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                EmployeeEmail = Employee.Email

                            End If

                            If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail,
                                                                                                Nothing, Nothing, Nothing, Nothing) Then

                                If EventLogRef IsNot Nothing Then

                                    EventLogRef.WriteEntry("Alert Recipient Inserted for Employee --> " & Employee.Code & " - " & Employee.ToString())

                                End If

                                AlertPosted = True

                            Else

                                If EventLogRef IsNot Nothing Then

                                    EventLogRef.WriteEntry("Failed to Insert Alert Recipient for Employee --> " & Employee.Code & " - " & Employee.ToString())

                                End If

                            End If

                        End If

                        If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotificationForEmail(Employee) Then

                            Dim Body As String = Alert.EmailBody
                            Try

                                If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                    Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, True)

                                End If

                            Catch ex As Exception
                            End Try

                            If AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", Priority, SendingEmailStatus) Then

                                If EventLogRef IsNot Nothing Then

                                    EventLogRef.WriteEntry("Email sent to Employee --> " & Employee.Code & " - " & Employee.ToString())

                                End If

                            Else

                                If SendingEmailStatus = Email.SendingEmailStatus.FailedToConnect Then

                                    If EventLogRef IsNot Nothing Then

                                        EventLogRef.WriteEntry("Failed to connect to email server for Employee --> " & Employee.Code & " - " & Employee.ToString())

                                    End If

                                ElseIf SendingEmailStatus = Email.SendingEmailStatus.FailedToSend Then

                                    If EventLogRef IsNot Nothing Then

                                        EventLogRef.WriteEntry("Failed to send email to Employee --> " & Employee.Code & " - " & Employee.ToString())

                                    End If

                                ElseIf SendingEmailStatus = Email.SendingEmailStatus.FailedToLoadSettings Then

                                    If EventLogRef IsNot Nothing Then

                                        EventLogRef.WriteEntry("Failed to load settings --> " & Employee.Code & " - " & Employee.ToString())

                                    End If

                                End If

                            End If

                        End If

                    Else

                        If EventLogRef IsNot Nothing Then

                            EventLogRef.WriteEntry("Failed to create alert for Employee --> " & Employee.Code & " - " & Employee.ToString())

                        End If

                    End If

                End If

            Catch ex As Exception

                AlertPosted = False

            End Try

            PostAlertForMissingTimeNotification = AlertPosted

        End Function
        Private Function CreateAlertBodyForMissingTimeNotification(ByRef MissingTimeDetails As List(Of AdvantageFramework.Database.Entities.MissingTimeDetail),
                                                                    ByVal CustomMessage As String,
                                                                    ByVal IsDaily As Boolean,
                                                                    ByVal MissingTimeOnly As Boolean) As String

            'objects
            Dim Body As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim CountOfStandardHours As Decimal = 0
            Dim CountOfHoursWorked As Decimal = 0
            Dim CountOfHoursDifference As Decimal = 0
            Dim StartOfWeekDate As Date = Nothing

            If MissingTimeDetails.Count > 0 Then

                StringBuilder = New System.Text.StringBuilder

                If CustomMessage <> "" Then

                    StringBuilder.AppendLine(CustomMessage)
                    StringBuilder.AppendLine(vbCrLf)

                End If

                If IsDaily Then

                    StringBuilder.AppendLine("Date")
                    StringBuilder.AppendLine(vbTab & "Day")
                    StringBuilder.AppendLine(vbTab & "Standard Hours")
                    StringBuilder.AppendLine(vbTab & "Hours Worked")
                    StringBuilder.AppendLine(vbTab & "Variance")

                    For Each MissingTimeDetail In MissingTimeDetails.OrderBy(Function(Detail) Detail.Date)

                        If MissingTimeOnly Then

                            If MissingTimeDetail.StandardHours > 0 AndAlso
                                    MissingTimeDetail.StandardHours = MissingTimeDetail.HoursDifference Then

                                StringBuilder.AppendLine(vbTab & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString)
                                StringBuilder.AppendLine(vbTab & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString)
                                StringBuilder.AppendLine(vbTab & MissingTimeDetail.StandardHours.GetValueOrDefault(0))

                                If MissingTimeDetail.StandardHours.GetValueOrDefault(0) = 0 Then

                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursWorked.GetValueOrDefault(0))

                                Else

                                    If MissingTimeDetail.HoursWorked.GetValueOrDefault(0) = 0 Then

                                        StringBuilder.AppendLine(vbTab & "MISSING")

                                    Else

                                        StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursWorked.GetValueOrDefault(0))

                                    End If

                                End If

                                StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursDifference.GetValueOrDefault(0))
                                StringBuilder.AppendLine(vbCrLf)

                            End If

                        Else

                            If MissingTimeDetail.HoursDifference > 0 Then

                                StringBuilder.AppendLine(vbTab & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString)
                                StringBuilder.AppendLine(vbTab & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString)
                                StringBuilder.AppendLine(vbTab & MissingTimeDetail.StandardHours.GetValueOrDefault(0))

                                If MissingTimeDetail.StandardHours.GetValueOrDefault(0) = 0 Then

                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursWorked.GetValueOrDefault(0))

                                Else

                                    If MissingTimeDetail.HoursWorked.GetValueOrDefault(0) = 0 Then

                                        StringBuilder.AppendLine(vbTab & "MISSING")

                                    Else

                                        StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursWorked.GetValueOrDefault(0))

                                    End If

                                End If

                                StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursDifference.GetValueOrDefault(0))
                                StringBuilder.AppendLine(vbCrLf)

                            End If

                        End If

                    Next

                    Body = StringBuilder.ToString

                Else

                    For Each StartOfWeekDate In (From MissingTimeDetail In MissingTimeDetails.AsQueryable
                                                 Order By MissingTimeDetail.StartOfWeekDate
                                                 Select MissingTimeDetail.StartOfWeekDate.GetValueOrDefault("01/01/1900")
                                                 Distinct)

                        CountOfHoursWorked = (From MissingTimeDetail In MissingTimeDetails.AsQueryable
                                              Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                              Select MissingTimeDetail.HoursWorked).Sum

                        CountOfStandardHours = (From MissingTimeDetail In MissingTimeDetails.AsQueryable
                                                Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                                Select MissingTimeDetail.StandardHours).Sum

                        CountOfHoursDifference = (From MissingTimeDetail In MissingTimeDetails.AsQueryable
                                                  Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                                  Select MissingTimeDetail.HoursDifference).Sum

                        If MissingTimeOnly Then

                            If CountOfStandardHours > 0 AndAlso
                                    CountOfStandardHours = CountOfHoursDifference Then

                                StringBuilder.AppendLine("Week of: " & StartOfWeekDate.ToShortDateString)
                                StringBuilder.AppendLine(vbCrLf)
                                StringBuilder.AppendLine("Hours Required: " & CountOfStandardHours)
                                StringBuilder.AppendLine(vbCrLf)
                                StringBuilder.AppendLine("Hours Worked: " & CountOfHoursWorked)
                                StringBuilder.AppendLine(vbCrLf)
                                StringBuilder.AppendLine(vbCrLf)

                                StringBuilder.AppendLine("Date")
                                StringBuilder.AppendLine(vbTab)
                                StringBuilder.AppendLine("Day")
                                StringBuilder.AppendLine(vbTab)
                                StringBuilder.AppendLine("Standard Hours")
                                StringBuilder.AppendLine(vbTab)
                                StringBuilder.AppendLine("Hours Worked")
                                StringBuilder.AppendLine(vbTab)
                                StringBuilder.AppendLine("Variance")

                                For Each MissingTimeDetail In (From Entity In MissingTimeDetails.AsQueryable
                                                               Where Entity.StartOfWeekDate = StartOfWeekDate
                                                               Select Entity
                                                               Order By Entity.Date)

                                    StringBuilder.AppendLine(vbCrLf)
                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString)
                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString)
                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.StandardHours.GetValueOrDefault(0))

                                    If MissingTimeDetail.StandardHours.GetValueOrDefault(0) = 0 Then

                                        StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursWorked.GetValueOrDefault(0))

                                    Else

                                        If MissingTimeDetail.HoursWorked.GetValueOrDefault(0) = 0 Then

                                            StringBuilder.AppendLine(vbTab & "MISSING")

                                        Else

                                            StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursWorked.GetValueOrDefault(0))

                                        End If

                                    End If

                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursDifference.GetValueOrDefault(0))

                                Next

                            End If

                        Else

                            If CountOfHoursDifference > 0 Then

                                StringBuilder.AppendLine("Week of: " & StartOfWeekDate.ToShortDateString)
                                StringBuilder.AppendLine(vbCrLf)
                                StringBuilder.AppendLine("Hours Required: " & CountOfStandardHours)
                                StringBuilder.AppendLine(vbCrLf)
                                StringBuilder.AppendLine("Hours Worked: " & CountOfHoursWorked)
                                StringBuilder.AppendLine(vbCrLf)
                                StringBuilder.AppendLine(vbCrLf)

                                StringBuilder.AppendLine("Date")
                                StringBuilder.AppendLine(vbTab)
                                StringBuilder.AppendLine("Day")
                                StringBuilder.AppendLine(vbTab)
                                StringBuilder.AppendLine("Standard Hours")
                                StringBuilder.AppendLine(vbTab)
                                StringBuilder.AppendLine("Hours Worked")
                                StringBuilder.AppendLine(vbTab)
                                StringBuilder.AppendLine("Variance")

                                For Each MissingTimeDetail In (From Entity In MissingTimeDetails.AsQueryable
                                                               Where Entity.StartOfWeekDate = StartOfWeekDate
                                                               Select Entity
                                                               Order By Entity.Date)

                                    StringBuilder.AppendLine(vbCrLf)
                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString)
                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString)
                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.StandardHours.GetValueOrDefault(0))

                                    If MissingTimeDetail.StandardHours.GetValueOrDefault(0) = 0 Then

                                        StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursWorked.GetValueOrDefault(0))

                                    Else

                                        If MissingTimeDetail.HoursWorked.GetValueOrDefault(0) = 0 Then

                                            StringBuilder.AppendLine(vbTab & "MISSING")

                                        Else

                                            StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursWorked.GetValueOrDefault(0))

                                        End If

                                    End If

                                    StringBuilder.AppendLine(vbTab & MissingTimeDetail.HoursDifference.GetValueOrDefault(0))

                                Next

                            End If

                        End If

                    Next

                    StringBuilder.AppendLine(vbCrLf)

                    Body = StringBuilder.ToString

                End If

            End If

            CreateAlertBodyForMissingTimeNotification = Body

        End Function

#End Region

#Region "   EMail "
        Private Function CreateAlertEmailBodyForMissingTimeNotification(ByRef MissingTimeDetails As List(Of AdvantageFramework.Database.Entities.MissingTimeDetail),
                                                                        ByVal CustomMessage As String,
                                                                        ByVal EmployeeCode As String,
                                                                        ByVal EmployeeName As String,
                                                                        ByVal IsDaily As Boolean,
                                                                        ByVal MissingTimeOnly As Boolean,
                                                                        ByVal BaseURL As String) As String

            'objects
            Dim HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing

            Dim CountOfStandardHours As Decimal = 0
            Dim CountOfHoursWorked As Decimal = 0
            Dim CountOfHoursDifference As Decimal = 0
            Dim StartOfWeekDate As Date = Nothing
            Dim HighlightRow As Boolean = False

            If MissingTimeDetails.Count > 0 Then

                HTMLEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False)

                Dim CurrentRowDate As String = String.Empty
                Dim CurrentRowDayOfWeek As String = String.Empty
                Dim CurrentRowStandardHours As String = String.Empty
                Dim CurrentRowsHoursWorked As String = String.Empty
                Dim CurrentRowVariance As String = String.Empty

                If String.IsNullOrWhiteSpace(EmployeeName) = True Then

                    HTMLEmail.AddHeaderRow(String.Format("Missing Time Alert"))

                Else

                    HTMLEmail.AddHeaderRow(String.Format("Missing Time Alert for {0}", EmployeeName))

                End If

                If String.IsNullOrWhiteSpace(CustomMessage) = False Then

                    CustomMessage = CustomMessage.Replace("[img]", "<img src=""")
                    CustomMessage = CustomMessage.Replace("[/img]", """ />")
                    CustomMessage = CustomMessage.Replace(Environment.NewLine, "<br />")

                    HTMLEmail.AddHeaderRow(CustomMessage)

                End If

                If IsDaily Then

                    HTMLEmail.CustomTableRowStart({"Date", "Day", "Standard Hours", "Hours Worked", "Variance"})

                    For Each MissingTimeDetail In MissingTimeDetails.OrderBy(Function(Details) Details.Date)

                        CurrentRowDate = String.Empty
                        CurrentRowDayOfWeek = String.Empty
                        CurrentRowStandardHours = String.Empty
                        CurrentRowsHoursWorked = String.Empty
                        CurrentRowVariance = String.Empty
                        HighlightRow = False

                        If MissingTimeOnly Then

                            If MissingTimeDetail.StandardHours > 0 AndAlso MissingTimeDetail.StandardHours = MissingTimeDetail.HoursDifference Then

                                CurrentRowDate = MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString
                                CurrentRowDayOfWeek = MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString
                                CurrentRowStandardHours = FormatNumber(MissingTimeDetail.StandardHours.GetValueOrDefault(0), 2, TriState.True)

                                If MissingTimeDetail.StandardHours.GetValueOrDefault(0) = 0 Then

                                    CurrentRowsHoursWorked = FormatNumber(MissingTimeDetail.HoursWorked.GetValueOrDefault(0), 2, TriState.True)

                                Else

                                    If MissingTimeDetail.HoursWorked.GetValueOrDefault(0) = 0 Then

                                        CurrentRowsHoursWorked = "MISSING"

                                    Else

                                        CurrentRowsHoursWorked = FormatNumber(MissingTimeDetail.HoursWorked.GetValueOrDefault(0), 2, TriState.True)
                                        HighlightRow = True

                                    End If

                                End If

                                CurrentRowVariance = FormatNumber(MissingTimeDetail.HoursDifference.GetValueOrDefault(0), 2, TriState.True)
                                CurrentRowDate = HTMLEmail.TimeSheetLink(CType(CurrentRowDate, Date), "", False, BaseURL, EmployeeCode)
                                If HighlightRow = True Then HighlightRow = CType(CurrentRowVariance, Decimal) > 0

                                HTMLEmail.CustomTableRow({CurrentRowDate, CurrentRowDayOfWeek, CurrentRowStandardHours, CurrentRowsHoursWorked, CurrentRowVariance}, HighlightRow)

                            End If

                        Else

                            If MissingTimeDetail.HoursDifference > 0 Then

                                CurrentRowDate = MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString
                                CurrentRowDayOfWeek = MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString
                                CurrentRowStandardHours = FormatNumber(MissingTimeDetail.StandardHours.GetValueOrDefault(0), 2, TriState.True)

                                If MissingTimeDetail.StandardHours.GetValueOrDefault(0) = 0 Then

                                    CurrentRowsHoursWorked = FormatNumber(MissingTimeDetail.HoursWorked.GetValueOrDefault(0), 2, TriState.True)

                                Else

                                    If MissingTimeDetail.HoursWorked.GetValueOrDefault(0) = 0 Then

                                        CurrentRowsHoursWorked = "MISSING"

                                    Else

                                        CurrentRowsHoursWorked = FormatNumber(MissingTimeDetail.HoursWorked.GetValueOrDefault(0), 2, TriState.True)
                                        HighlightRow = True

                                    End If

                                End If

                                CurrentRowDate = HTMLEmail.TimeSheetLink(CType(CurrentRowDate, Date), "", False, BaseURL, EmployeeCode)
                                CurrentRowVariance = FormatNumber(MissingTimeDetail.HoursDifference.GetValueOrDefault(0), 2, TriState.True)
                                If HighlightRow = True Then HighlightRow = CType(CurrentRowVariance, Decimal) > 0

                                HTMLEmail.CustomTableRow({CurrentRowDate, CurrentRowDayOfWeek, CurrentRowStandardHours, CurrentRowsHoursWorked, CurrentRowVariance}, HighlightRow)

                            End If

                        End If

                    Next

                    HTMLEmail.CustomTableEnd()

                Else

                    HTMLEmail.CustomTableRowStart({"Week of", "Hours Required", "Hours Worked", "Date", "Day", "Standard Hours", "Hours Worked", "Variance"})

                    For Each StartOfWeekDate In (From MissingTimeDetail In MissingTimeDetails.AsQueryable
                                                 Order By MissingTimeDetail.StartOfWeekDate
                                                 Select MissingTimeDetail.StartOfWeekDate.GetValueOrDefault("01/01/1900")
                                                 Distinct)

                        CountOfHoursWorked = 0
                        CountOfStandardHours = 0
                        CountOfHoursDifference = 0

                        CountOfHoursWorked = (From MissingTimeDetail In MissingTimeDetails.AsQueryable
                                              Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                              Select MissingTimeDetail.HoursWorked).Sum

                        CountOfStandardHours = (From MissingTimeDetail In MissingTimeDetails.AsQueryable
                                                Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                                Select MissingTimeDetail.StandardHours).Sum

                        CountOfHoursDifference = (From MissingTimeDetail In MissingTimeDetails.AsQueryable
                                                  Where MissingTimeDetail.StartOfWeekDate = StartOfWeekDate
                                                  Select MissingTimeDetail.HoursDifference).Sum

                        If MissingTimeOnly Then

                            If CountOfStandardHours > 0 AndAlso CountOfStandardHours = CountOfHoursDifference Then

                                HTMLEmail.CustomTableRow({HTMLEmail.TimeSheetLink(StartOfWeekDate, "", True, BaseURL, EmployeeCode),
                                                         FormatNumber(CountOfStandardHours, 2, TriState.True),
                                                         FormatNumber(CountOfHoursWorked, 2, TriState.True),
                                                         "", "", "", "", ""}, CountOfStandardHours > CountOfHoursWorked)

                                For Each MissingTimeDetail In (From Entity In MissingTimeDetails.AsQueryable
                                                               Where Entity.StartOfWeekDate = StartOfWeekDate
                                                               Select Entity
                                                               Order By Entity.Date)

                                    CurrentRowDate = String.Empty
                                    CurrentRowDayOfWeek = String.Empty
                                    CurrentRowStandardHours = String.Empty
                                    CurrentRowsHoursWorked = String.Empty
                                    CurrentRowVariance = String.Empty
                                    HighlightRow = False

                                    CurrentRowDate = MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString
                                    CurrentRowDayOfWeek = MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString
                                    CurrentRowStandardHours = FormatNumber(MissingTimeDetail.StandardHours.GetValueOrDefault(0), 2, TriState.True)

                                    If MissingTimeDetail.StandardHours.GetValueOrDefault(0) = 0 Then

                                        CurrentRowsHoursWorked = FormatNumber(MissingTimeDetail.HoursWorked.GetValueOrDefault(0), 2, TriState.True)

                                    Else

                                        If MissingTimeDetail.HoursWorked.GetValueOrDefault(0) = 0 Then

                                            CurrentRowsHoursWorked = "MISSING"

                                        Else

                                            CurrentRowsHoursWorked = FormatNumber(MissingTimeDetail.HoursWorked.GetValueOrDefault(0), 2, TriState.True)
                                            HighlightRow = True

                                        End If

                                    End If

                                    CurrentRowVariance = FormatNumber(MissingTimeDetail.HoursDifference.GetValueOrDefault(0), 2, TriState.True)
                                    CurrentRowDate = HTMLEmail.TimeSheetLink(CType(CurrentRowDate, Date), "", False, BaseURL, EmployeeCode)
                                    If HighlightRow = True Then HighlightRow = CType(CurrentRowVariance, Decimal) > 0

                                    HTMLEmail.CustomTableRow({"", "", "", CurrentRowDate, CurrentRowDayOfWeek, CurrentRowStandardHours, CurrentRowsHoursWorked, CurrentRowVariance}, HighlightRow)

                                Next

                            End If

                        Else

                            If CountOfHoursDifference > 0 Then

                                HTMLEmail.CustomTableRow({HTMLEmail.TimeSheetLink(StartOfWeekDate, "", True, BaseURL, EmployeeCode),
                                                         FormatNumber(CountOfStandardHours, 2, TriState.True),
                                                         FormatNumber(CountOfHoursWorked, 2, TriState.True),
                                                         "", "", "", "", ""}, CountOfStandardHours > CountOfHoursWorked)

                                For Each MissingTimeDetail In (From Entity In MissingTimeDetails.AsQueryable
                                                               Where Entity.StartOfWeekDate = StartOfWeekDate
                                                               Select Entity
                                                               Order By Entity.Date)

                                    CurrentRowDate = String.Empty
                                    CurrentRowDayOfWeek = String.Empty
                                    CurrentRowStandardHours = String.Empty
                                    CurrentRowsHoursWorked = String.Empty
                                    CurrentRowVariance = String.Empty
                                    HighlightRow = False

                                    CurrentRowDate = MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").ToShortDateString
                                    CurrentRowDayOfWeek = MissingTimeDetail.Date.GetValueOrDefault("01/01/1900").DayOfWeek.ToString
                                    CurrentRowStandardHours = FormatNumber(MissingTimeDetail.StandardHours.GetValueOrDefault(0), 2, TriState.True)

                                    If MissingTimeDetail.StandardHours.GetValueOrDefault(0) = 0 Then

                                        CurrentRowsHoursWorked = FormatNumber(MissingTimeDetail.HoursWorked.GetValueOrDefault(0), 2, TriState.True)

                                    Else

                                        If MissingTimeDetail.HoursWorked.GetValueOrDefault(0) = 0 Then

                                            CurrentRowsHoursWorked = "MISSING"

                                        Else

                                            CurrentRowsHoursWorked = FormatNumber(MissingTimeDetail.HoursWorked.GetValueOrDefault(0), 2, TriState.True)
                                            HighlightRow = True

                                        End If

                                    End If

                                    CurrentRowVariance = FormatNumber(MissingTimeDetail.HoursDifference.GetValueOrDefault(0), 2, TriState.True)
                                    CurrentRowDate = HTMLEmail.TimeSheetLink(CType(CurrentRowDate, Date), "", False, BaseURL, EmployeeCode)
                                    If HighlightRow = True Then HighlightRow = CType(CurrentRowVariance, Decimal) > 0

                                    HTMLEmail.CustomTableRow({"", "", "", CurrentRowDate, CurrentRowDayOfWeek, CurrentRowStandardHours, CurrentRowsHoursWorked, CurrentRowVariance}, HighlightRow)

                                Next

                            End If

                        End If

                    Next

                    HTMLEmail.CustomTableEnd()

                End If

            End If

            HTMLEmail.Finish()
            CreateAlertEmailBodyForMissingTimeNotification = HTMLEmail.ToString

        End Function

#End Region

#End Region

#Region "  Document Manager "

#Region "  Alert "
        Public Sub SetAlertLevelByDocumentLevel(ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                                ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                                ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting)

            If Alert IsNot Nothing Then

                Select Case DocumentLevel
                    Case Database.Entities.DocumentLevel.AccountPayableInvoice
                        Alert.AlertLevel = "VN"
                    Case Database.Entities.DocumentLevel.AccountReceivableInvoice
                        Alert.AlertLevel = "AR"
                    Case Database.Entities.DocumentLevel.AdNumber
                        Alert.AlertLevel = "AN"
                    Case Database.Entities.DocumentLevel.Campaign
                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.CampaignID = DocumentLevelSetting.CampaignID
                        End If

                        Alert.AlertLevel = "CM"
                    Case Database.Entities.DocumentLevel.Client

                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.ClientCode = DocumentLevelSetting.ClientCode
                        End If

                        Alert.AlertLevel = "CL"
                    Case Database.Entities.DocumentLevel.Division
                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.ClientCode = DocumentLevelSetting.ClientCode
                            Alert.DivisionCode = DocumentLevelSetting.DivisionCode
                        End If

                        Alert.AlertLevel = "DI"
                    Case Database.Entities.DocumentLevel.Employee
                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.EmployeeCode = DocumentLevelSetting.EmployeeCode
                        End If

                        Alert.AlertLevel = "EM"
                    Case Database.Entities.DocumentLevel.ExpenseReceipts
                        Alert.AlertLevel = "EX"
                    Case Database.Entities.DocumentLevel.Job
                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.ClientCode = DocumentLevelSetting.ClientCode
                            Alert.DivisionCode = DocumentLevelSetting.DivisionCode
                            Alert.ProductCode = DocumentLevelSetting.ProductCode
                            Alert.JobNumber = DocumentLevelSetting.JobNumber
                        End If

                        Alert.AlertLevel = "JO"
                    Case Database.Entities.DocumentLevel.JobComponent
                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.ClientCode = DocumentLevelSetting.ClientCode
                            Alert.DivisionCode = DocumentLevelSetting.DivisionCode
                            Alert.ProductCode = DocumentLevelSetting.ProductCode
                            Alert.JobNumber = DocumentLevelSetting.JobNumber
                            Alert.JobComponentNumber = DocumentLevelSetting.JobComponentNumber
                        End If

                        Alert.AlertLevel = "JC"
                    Case Database.Entities.DocumentLevel.Office
                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.OfficeCode = DocumentLevelSetting.OfficeCode
                        End If

                        Alert.AlertLevel = "OF"
                    Case Database.Entities.DocumentLevel.Product
                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.ClientCode = DocumentLevelSetting.ClientCode
                            Alert.DivisionCode = DocumentLevelSetting.DivisionCode
                            Alert.ProductCode = DocumentLevelSetting.ProductCode
                        End If
                        Alert.AlertLevel = "PR"
                    Case Database.Entities.DocumentLevel.Vendor
                        If DocumentLevelSetting IsNot Nothing Then
                            Alert.VendorCode = DocumentLevelSetting.VendorCode
                        End If

                        Alert.AlertLevel = "VR"
                End Select

            End If
        End Sub
        Public Function CreateAndSendDocumentManagerAlert(ByVal Session As AdvantageFramework.Security.Session,
                                                          ByVal Document As AdvantageFramework.Database.Entities.Document,
                                                          ByVal DocumentLevel As AdvantageFramework.Database.Entities.DocumentLevel,
                                                          ByVal DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting,
                                                          ByVal Subject As String, ByVal AlertCategoryID As Integer, ByVal PriorityLevel As Short,
                                                          ByVal Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee)) As Boolean

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim AlertCreated As Boolean = False
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, "Alert")

                    Alert = New AdvantageFramework.Database.Entities.Alert

                    Alert.DbContext = DbContext

                    Alert.Subject = Subject
                    Alert.EmployeeCode = Session.User.EmployeeCode
                    Alert.Body = Document.Description & vbNewLine & vbNewLine & "Keywords: " & Document.Keywords
                    Alert.EmailBody = Document.Description & "<br/><br/>Keywords: " & Document.Keywords
                    Alert.AlertCategoryID = AlertCategoryID
                    Alert.PriorityLevel = PriorityLevel

                    If AlertType IsNot Nothing Then

                        Alert.AlertTypeID = AlertType.ID

                    End If

                    Alert.GeneratedDate = System.DateTime.Now
                    Alert.UserCode = DbContext.UserCode

                    SetAlertLevelByDocumentLevel(Alert, DocumentLevel, DocumentLevelSetting)

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                        AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, Alert.ID, DbContext.UserCode, System.DateTime.Now, False, Document.ID, AlertAttachment)

                        For Each Employee In Employees

                            If AdvantageFramework.AlertSystem.CheckEmployeeAlertNotification(Employee) Then

                                AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                                AlertRecipient.AlertID = Alert.ID
                                AlertRecipient.EmployeeCode = Employee.Code
                                AlertRecipient.EmployeeEmail = AdvantageFramework.Email.LoadEmployeeEmail(Employee, True, False)
                                AlertRecipient.DbContext = DbContext

                                AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                            End If

                        Next

                        AlertCreated = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert]", Nothing, Nothing, Nothing, Nothing, False, False, False)

                    End If

                End Using

            Catch ex As Exception
                AlertCreated = False
            Finally
                CreateAndSendDocumentManagerAlert = AlertCreated
            End Try

        End Function

#End Region

#End Region

#Region "  Contract "

#Region "  Alert "
        Public Function CreateAlertForContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                           ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                           ByVal EmployeeCode As String,
                                                           ByVal AlertCategoryEnum As AdvantageFramework.AlertSystem.ContractNotificationAlertCategory,
                                                           ByVal Contract As AdvantageFramework.Database.Entities.Contract,
                                                           ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertHeader As String = ""
            Dim AlertDetail As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertEmailHeader As String = ""
            Dim AlertEmailDetail As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim Priority As Integer = 3
            Dim AlertUser As String = ""

            If DbContext IsNot Nothing Then

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    EmployeeName = Employee.ToString()

                    AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ClientContract.ToString))

                    If AlertType IsNot Nothing Then

                        If AlertCategoryEnum = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal.ToString))

                        ElseIf AlertCategoryEnum = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingRequiredReport Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingRequiredReport.ToString))

                        ElseIf AlertCategoryEnum = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.RequiredReportCompleted Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.RequiredReportCompleted.ToString))

                        End If

                        If AlertCategory IsNot Nothing Then

                            AlertHeader = AdvantageFramework.AlertSystem.CreateAlertBodyHeaderForContractNotification(DbContext, EmployeeName, AlertCategoryEnum, Contract, ContractReport)
                            AlertEmailHeader = AdvantageFramework.AlertSystem.CreateAlertEmailBodyHeaderForContractNotification(DbContext, EmployeeName, AlertCategoryEnum, Contract, ContractReport)

                            AlertDetail = AdvantageFramework.AlertSystem.CreateAlertBodyDetailForContractNotification(DbContext, AlertCategoryEnum, Contract, ContractReport)
                            AlertEmailDetail = AdvantageFramework.AlertSystem.CreateAlertEmailBodyDetailForContractNotification(DbContext, AlertCategoryEnum, Contract, ContractReport)

                            AlertBody = AlertHeader + vbCrLf + AlertDetail
                            AlertEmailBody = AlertEmailHeader + vbCrLf + AlertEmailDetail

                            If AlertCategoryEnum = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal Then

                                AlertSubject = "Upcoming Contract Renewal for " & Contract.Product.Client.Name & " - " & Contract.Description
                                Priority = 3

                            ElseIf AlertCategoryEnum = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingRequiredReport Then

                                AlertSubject = "Upcoming Required Report for " & Contract.Product.Client.Name & " - " & ContractReport.Description
                                Priority = 3

                            ElseIf AlertCategoryEnum = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.RequiredReportCompleted Then

                                AlertSubject = "Required Report Completed for " & Contract.Product.Client.Name & " - " & ContractReport.Description
                                Priority = 3

                            End If

                            AlertUser = DbContext.UserCode

                            If AlertUser.Length = 0 Then

                                AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                            End If

                            Alert = New AdvantageFramework.Database.Entities.Alert

                            Alert.DbContext = DbContext
                            Alert.AlertTypeID = AlertType.ID
                            Alert.AlertCategoryID = AlertCategory.ID
                            Alert.Subject = AlertSubject
                            Alert.Body = AlertBody
                            Alert.GeneratedDate = Now
                            Alert.PriorityLevel = Priority
                            Alert.EmployeeCode = EmployeeCode
                            Alert.UserCode = AlertUser
                            Alert.AlertLevel = "CL"
                            Alert.EmailBody = AlertEmailBody
                            Alert.ClientCode = Contract.ClientCode
                            Alert.DivisionCode = Contract.DivisionCode
                            Alert.ProductCode = Contract.ProductCode

                            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                    If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                        EmployeeEmail = Employee.Email

                                    End If

                                    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                End If

                                If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                    Dim Body As String = Alert.EmailBody
                                    Try

                                        If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                            Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, False)

                                        End If

                                    Catch ex As Exception
                                    End Try

                                    AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", 2, SendingEmailStatus)

                                End If

                                AlertCreated = True

                            End If

                        Else

                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                            Console.WriteLine(AlertSubject)
                            Console.WriteLine(AlertBody)

                        End If

                    End If

                End If

            End If

            CreateAlertForContractNotification = AlertCreated

        End Function
        Private Function CreateAlertBodyHeaderForContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                      ByVal EmployeeName As String,
                                                                      ByVal ContractNotificationAlertCategory As AdvantageFramework.AlertSystem.ContractNotificationAlertCategory,
                                                                      ByVal Contract As AdvantageFramework.Database.Entities.Contract,
                                                                      ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport)

            'objects
            Dim AlertBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal Then

                        StringBuilder.AppendLine("Contract ends on " & Contract.EndDate.Value.ToShortDateString & " for:")
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Client: " & Contract.ClientCode & " - " & Contract.Product.Client.Name)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Division: " & Contract.DivisionCode & " - " & Contract.Product.Division.Name)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Product: " & Contract.ProductCode & " - " & Contract.Product.Name)

                    ElseIf ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingRequiredReport Then

                        StringBuilder.AppendLine("Report " & ContractReport.Description & " is scheduled to be started on " & ContractReport.NextStartDate.Value.ToShortDateString & " for:")
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Client: " & ContractReport.Contract.ClientCode & " - " & ContractReport.Contract.Product.Client.Name)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Division: " & ContractReport.Contract.DivisionCode & " - " & ContractReport.Contract.Product.Division.Name)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Product: " & ContractReport.Contract.ProductCode & " - " & ContractReport.Contract.Product.Name)

                    ElseIf ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.RequiredReportCompleted Then

                        StringBuilder.AppendLine("Report " & ContractReport.Description & " was completed on " & ContractReport.LastCompletedDate.Value.ToShortDateString)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Client: " & ContractReport.Contract.ClientCode & " - " & ContractReport.Contract.Product.Client.Name)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Division: " & ContractReport.Contract.DivisionCode & " - " & ContractReport.Contract.Product.Division.Name)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Product: " & ContractReport.Contract.ProductCode & " - " & ContractReport.Contract.Product.Name)

                    End If

                End If

                AlertBodyHeader = StringBuilder.ToString

            Catch ex As Exception
                AlertBodyHeader = ""
            Finally
                CreateAlertBodyHeaderForContractNotification = AlertBodyHeader
            End Try

        End Function
        Private Function CreateAlertBodyDetailForContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                      ByVal ContractNotificationAlertCategory As AdvantageFramework.AlertSystem.ContractNotificationAlertCategory,
                                                                      ByVal Contract As AdvantageFramework.Database.Entities.Contract,
                                                                      ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport)

            'objects
            Dim AlertBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal Then

                        StringBuilder.AppendLine("Contract Details:")
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine(Contract.Code & " - " & Contract.Description)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Start Date: " & Contract.StartDate.Value.ToShortDateString)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("End Date: " & Contract.EndDate.Value.ToShortDateString)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Total Contract Value: " & Format(Contract.FeeRetainer.GetValueOrDefault(0) + Contract.FeeIncentiveBonus.GetValueOrDefault(0) + Contract.FeeRoyalty.GetValueOrDefault(0) +
                                                 Contract.FeeProjectHourly.GetValueOrDefault(0) + Contract.MediaCommission.GetValueOrDefault(0) + Contract.ProductionCommission.GetValueOrDefault(0), "n2"))

                    Else

                        StringBuilder.AppendLine("Required Report Details:")
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Frequency: " & ContractReport.Cycle.Name)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Last Completed Date: " & ContractReport.LastCompletedDate.Value.ToShortDateString)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Next Start Date: " & ContractReport.NextStartDate.Value.ToShortDateString)

                    End If

                    AlertBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertBodyDetail = ""
            Finally
                CreateAlertBodyDetailForContractNotification = AlertBodyDetail
            End Try

        End Function

#End Region

#Region "  Email "
        Private Function CreateAlertEmailBodyHeaderForContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                           ByVal EmployeeName As String,
                                                                           ByVal ContractNotificationAlertCategory As AdvantageFramework.AlertSystem.ContractNotificationAlertCategory,
                                                                           ByVal Contract As AdvantageFramework.Database.Entities.Contract,
                                                                           ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport)

            'objects
            Dim AlertEmailBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderString As String = Nothing
            Dim ClientString As String = Nothing
            Dim DivisionString As String = Nothing
            Dim ProductString As String = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal Then

                        HeaderString = "Contract ends on " & Contract.EndDate.Value.ToShortDateString & " for:"

                    ElseIf ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingRequiredReport Then

                        HeaderString = "Report " & ContractReport.Description & " is scheduled to be started on " & ContractReport.NextStartDate.Value.ToShortDateString & " for:"

                    ElseIf ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.RequiredReportCompleted Then

                        HeaderString = "Report " & ContractReport.Description & " was completed on " & ContractReport.LastCompletedDate.Value.ToShortDateString

                    End If

                    StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr><td colspan=""2"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """>")
                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """>")
                    StringBuilder.AppendLine("<strong>" & HeaderString & "</strong></font></td></tr>")
                    StringBuilder.AppendLine("</table>")

                    ClientString = "Client: " & Contract.ClientCode & " - " & Contract.Product.Client.Name
                    DivisionString = "Division: " & Contract.DivisionCode & " - " & Contract.Product.Division.Name
                    ProductString = "Product: " & Contract.ProductCode & " - " & Contract.Product.Name

                    StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr>")
                    StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ClientString & "</font></td>")
                    StringBuilder.AppendLine("</tr>")
                    StringBuilder.AppendLine("<tr>")
                    StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & DivisionString & "</font></td>")
                    StringBuilder.AppendLine("</tr>")
                    StringBuilder.AppendLine("<tr>")
                    StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ProductString & "</font></td>")
                    StringBuilder.AppendLine("</tr>")
                    StringBuilder.Append("<hr size=""1"" color=""" & AdvantageFramework.Email.HeaderFontColor & """ />")
                    StringBuilder.AppendLine("</table>")

                    AlertEmailBodyHeader = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyHeader = ""
            Finally
                CreateAlertEmailBodyHeaderForContractNotification = AlertEmailBodyHeader
            End Try

        End Function
        Private Function CreateAlertEmailBodyDetailForContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                           ByVal ContractNotificationAlertCategory As AdvantageFramework.AlertSystem.ContractNotificationAlertCategory,
                                                                           ByVal Contract As AdvantageFramework.Database.Entities.Contract,
                                                                           ByVal ContractReport As AdvantageFramework.Database.Entities.ContractReport) As String
            'objects
            Dim AlertEmailBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderString As String = Nothing
            Dim ContractString As String = Nothing
            Dim ContractStartString As String = Nothing
            Dim ContractEndString As String = Nothing
            Dim ContractTotalString As String = Nothing
            Dim ReportFrequencyString As String = Nothing
            Dim ReportLastCompletedString As String = Nothing
            Dim ReportNextStartString As String = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal Then

                        HeaderString = "Contract Details:"

                        ContractString = Contract.Code & " - " & Contract.Description
                        ContractStartString = "Start Date: " & Contract.StartDate.Value.ToShortDateString
                        ContractEndString = "End Date: " & Contract.EndDate.Value.ToShortDateString
                        ContractTotalString = "Total Contract Value: " & Format(Contract.FeeRetainer.GetValueOrDefault(0) + Contract.FeeIncentiveBonus.GetValueOrDefault(0) + Contract.FeeRoyalty.GetValueOrDefault(0) +
                                                Contract.FeeProjectHourly.GetValueOrDefault(0) + Contract.MediaCommission.GetValueOrDefault(0) + Contract.ProductionCommission.GetValueOrDefault(0), "n2")

                    Else

                        HeaderString = "Required Report Details:"

                        ReportFrequencyString = "Frequency: " & ContractReport.Cycle.Name
                        ReportLastCompletedString = "Last Completed Date: " & ContractReport.LastCompletedDate.Value.ToShortDateString
                        ReportNextStartString = "Next Start Date: " & ContractReport.NextStartDate.Value.ToShortDateString

                    End If

                    StringBuilder.AppendLine("<br/><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr><td colspan=""2"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """>")
                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """>")
                    StringBuilder.AppendLine("<strong>" & HeaderString & "</strong></font></td></tr>")
                    StringBuilder.AppendLine("</table>")

                    If ContractNotificationAlertCategory = AdvantageFramework.AlertSystem.ContractNotificationAlertCategory.UpcomingContractRenewal Then

                        StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ContractString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ContractStartString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ContractEndString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ContractTotalString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.Append("<hr size=""1"" color=""" & AdvantageFramework.Email.HeaderFontColor & """ />")
                        StringBuilder.AppendLine("</table>")

                    Else

                        StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ReportFrequencyString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ReportLastCompletedString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ReportNextStartString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.Append("<hr size=""1"" color=""" & AdvantageFramework.Email.HeaderFontColor & """ />")
                        StringBuilder.AppendLine("</table>")

                    End If

                    AlertEmailBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyDetail = ""
            Finally
                CreateAlertEmailBodyDetailForContractNotification = AlertEmailBodyDetail
            End Try

        End Function

#End Region

#End Region

#Region "  Media Ocean Import "

#Region "  Alert "
        Public Function CreateAlertForMediaOceanValidationIssue(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                                                ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                ByVal EmployeeCode As String,
                                                                ByVal ImportValidationFailureType As AdvantageFramework.AlertSystem.ImportValidationFailureType,
                                                                ByVal ValidationIssue As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim AlertUser As String = ""

            Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    EmployeeName = Employee.ToString()

                    AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ImportValidation.ToString))

                    If AlertType IsNot Nothing Then

                        AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ImportValidation.MediaOceanValidationIssue.ToString))

                        If AlertCategory IsNot Nothing Then

                            AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyForMediaOceanValidationIssue(DbContext, EmployeeName, ValidationIssue)
                            AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyForMediaOceanValidationIssue(ValidationIssue)

                            AlertSubject = "Media Ocean Validation Issue - " & AdvantageFramework.StringUtilities.GetNameAsWords(ImportValidationFailureType.ToString)

                            AlertUser = DbContext.UserCode

                            If AlertUser.Length = 0 Then

                                AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                            End If

                            Alert = New AdvantageFramework.Database.Entities.Alert

                            Alert.DbContext = DbContext
                            Alert.AlertTypeID = AlertType.ID
                            Alert.AlertCategoryID = AlertCategory.ID
                            Alert.Subject = AlertSubject
                            Alert.Body = AlertBody
                            Alert.GeneratedDate = Now
                            Alert.PriorityLevel = 3
                            Alert.EmployeeCode = EmployeeCode
                            Alert.UserCode = AlertUser
                            Alert.EmailBody = AlertEmailBody

                            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                    If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                        EmployeeEmail = Employee.Email

                                    End If

                                    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                End If

                                If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                    Dim Body As String = Alert.EmailBody
                                    Try

                                        If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                            Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, True)

                                        End If

                                    Catch ex As Exception
                                    End Try

                                    AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", 2, SendingEmailStatus)

                                End If

                                AlertCreated = True

                            End If

                        Else

                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                            Console.WriteLine(AlertSubject)
                            Console.WriteLine(AlertBody)

                        End If

                    End If

                End If

            End Using

            CreateAlertForMediaOceanValidationIssue = AlertCreated

        End Function
        Private Function CreateAlertBodyForMediaOceanValidationIssue(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                     ByVal EmployeeName As String,
                                                                     ByVal ValidationIssue As String)

            'objects
            Dim AlertBody As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    StringBuilder.AppendLine("There was a problem with the validation of data coming through the Media Ocean Import:")
                    StringBuilder.AppendLine("")
                    StringBuilder.AppendLine(ValidationIssue)
                    StringBuilder.AppendLine("")

                End If

                AlertBody = StringBuilder.ToString

            Catch ex As Exception
                AlertBody = ""
            Finally
                CreateAlertBodyForMediaOceanValidationIssue = AlertBody
            End Try

        End Function

#End Region

#Region "  Email "
        Private Function CreateAlertEmailBodyForMediaOceanValidationIssue(ByVal ValidationIssue As String)

            'objects
            Dim AlertEmailBody As String = ""

            Try

                AlertEmailBody = "There was a problem with the validation of data coming through the Media Ocean Import:" & vbCrLf & vbCrLf & ValidationIssue

            Catch ex As Exception
                AlertEmailBody = ""
            Finally
                CreateAlertEmailBodyForMediaOceanValidationIssue = AlertEmailBody
            End Try

        End Function

#End Region

#End Region

#Region "  Import Templates "

#Region "  Alert "
        Public Function CreateAlertForImportTemplateResult(ByVal DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                                           ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                           ByVal EmployeeCode As String,
                                                           ByVal ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate,
                                                           ByVal ResultMessage As String,
                                                           ByRef EmailResultMessage As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim AlertUser As String = ""
            Dim ImportTemplateTypeName As Generic.KeyValuePair(Of Long, String) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    EmployeeName = Employee.ToString()

                    AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ImportValidation.ToString))

                    If AlertType IsNot Nothing Then

                        AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ImportValidation.ImportResults.ToString))

                        If AlertCategory IsNot Nothing Then

                            AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyForImportTemplateResult(ResultMessage)
                            AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyForImportTemplateResult(ResultMessage)

                            ImportTemplateTypeName = (From KeyValuePair In AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Importing.ImportTemplateTypes))
                                                      Where KeyValuePair.Key = CLng(ImportTemplate.Type)
                                                      Select KeyValuePair).Single


                            AlertSubject = "Import Results - " & ImportTemplate.Name & " - " & ImportTemplateTypeName.Value.ToString.Replace("_", "")

                            AlertUser = DbContext.UserCode

                            If AlertUser.Length = 0 Then

                                AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                            End If

                            Alert = New AdvantageFramework.Database.Entities.Alert

                            Alert.DbContext = DbContext
                            Alert.AlertTypeID = AlertType.ID
                            Alert.AlertCategoryID = AlertCategory.ID
                            Alert.Subject = AlertSubject
                            Alert.Body = AlertBody
                            Alert.GeneratedDate = Now
                            Alert.PriorityLevel = 3
                            Alert.EmployeeCode = EmployeeCode
                            Alert.UserCode = AlertUser
                            Alert.EmailBody = AlertEmailBody

                            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                    If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                        EmployeeEmail = Employee.Email

                                    End If

                                    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                End If

                                If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                    Dim Body As String = Alert.EmailBody
                                    Try

                                        If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                            Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, True)

                                        End If

                                    Catch ex As Exception
                                    End Try

                                    If AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", 2, SendingEmailStatus) Then

                                        EmailResultMessage = "Email sent to Employee --> " & Employee.Code & " - " & Employee.ToString()

                                    Else

                                        If SendingEmailStatus = Email.SendingEmailStatus.FailedToConnect Then

                                            EmailResultMessage = "Failed to connect to email server for Employee --> " & Employee.Code & " - " & Employee.ToString()

                                        ElseIf SendingEmailStatus = Email.SendingEmailStatus.FailedToSend Then

                                            EmailResultMessage = "Failed to send email to Employee --> " & Employee.Code & " - " & Employee.ToString()

                                        ElseIf SendingEmailStatus = Email.SendingEmailStatus.FailedToLoadSettings Then

                                            EmailResultMessage = "Failed to load settings --> " & Employee.Code & " - " & Employee.ToString()

                                        End If

                                    End If

                                End If

                                AlertCreated = True

                            End If

                        Else

                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                            Console.WriteLine(AlertSubject)
                            Console.WriteLine(AlertBody)

                        End If

                    End If

                End If

            End Using

            CreateAlertForImportTemplateResult = AlertCreated

        End Function
        Private Function CreateAlertBodyForImportTemplateResult(ByVal ResultMessage As String)

            'objects
            Dim AlertBody As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                StringBuilder.AppendLine("Import Result:")
                StringBuilder.AppendLine("")
                StringBuilder.AppendLine(ResultMessage)
                StringBuilder.AppendLine("")

                AlertBody = StringBuilder.ToString

            Catch ex As Exception
                AlertBody = ""
            Finally
                CreateAlertBodyForImportTemplateResult = AlertBody
            End Try

        End Function

#End Region

#Region "  Email "
        Private Function CreateAlertEmailBodyForImportTemplateResult(ByVal ResultMessage As String)

            'objects
            Dim AlertEmailBody As String = ""

            Try

                AlertEmailBody = "Import Result: " & ResultMessage

            Catch ex As Exception
                AlertEmailBody = ""
            Finally
                CreateAlertEmailBodyForImportTemplateResult = AlertEmailBody
            End Try

        End Function

#End Region

#End Region

#Region "  Vendor Contract "

#Region "  Alert "
        Public Function CreateAlertForVendorContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                 ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                                 ByVal EmployeeCode As String,
                                                                 ByVal AlertCategoryEnum As AdvantageFramework.AlertSystem.VendorContractNotificationAlertCategory,
                                                                 ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertHeader As String = ""
            Dim AlertDetail As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertEmailHeader As String = ""
            Dim AlertEmailDetail As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim Priority As Integer = 3
            Dim AlertUser As String = ""

            If DbContext IsNot Nothing Then

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)
                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorContract.VendorCode)

                If Employee IsNot Nothing AndAlso Vendor IsNot Nothing Then

                    EmployeeName = Employee.ToString()

                    AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.VendorContract.ToString))

                    If AlertType IsNot Nothing Then

                        If AlertCategoryEnum = VendorContractNotificationAlertCategory.UpcomingVendorContractRenewal Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.VendorContractNotificationAlertCategory.UpcomingVendorContractRenewal.ToString))

                        End If

                        If AlertCategory IsNot Nothing Then

                            AlertHeader = AdvantageFramework.AlertSystem.CreateAlertBodyHeaderForVendorContractNotification(DbContext, EmployeeName, AlertCategoryEnum, VendorContract, Vendor)
                            AlertEmailHeader = AdvantageFramework.AlertSystem.CreateAlertEmailBodyHeaderForVendorContractNotification(DbContext, EmployeeName, AlertCategoryEnum, VendorContract, Vendor)

                            AlertDetail = AdvantageFramework.AlertSystem.CreateAlertBodyDetailForVendorContractNotification(DbContext, AlertCategoryEnum, VendorContract)
                            AlertEmailDetail = AdvantageFramework.AlertSystem.CreateAlertEmailBodyDetailForVendorContractNotification(DbContext, AlertCategoryEnum, VendorContract)

                            AlertBody = AlertHeader + vbCrLf + AlertDetail
                            AlertEmailBody = AlertEmailHeader + vbCrLf + AlertEmailDetail

                            If AlertCategoryEnum = VendorContractNotificationAlertCategory.UpcomingVendorContractRenewal Then

                                AlertSubject = "Upcoming Vendor Contract Renewal for " & Vendor.Name & " - " & VendorContract.Description
                                Priority = 3

                            End If

                            AlertUser = DbContext.UserCode

                            If AlertUser.Length = 0 Then

                                AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                            End If

                            Alert = New AdvantageFramework.Database.Entities.Alert

                            Alert.DbContext = DbContext
                            Alert.AlertTypeID = AlertType.ID
                            Alert.AlertCategoryID = AlertCategory.ID
                            Alert.Subject = AlertSubject
                            Alert.Body = AlertBody
                            Alert.GeneratedDate = Now
                            Alert.PriorityLevel = Priority
                            Alert.EmployeeCode = EmployeeCode
                            Alert.UserCode = AlertUser
                            Alert.AlertLevel = "VN"
                            Alert.EmailBody = AlertEmailBody
                            Alert.VendorCode = VendorContract.VendorCode

                            If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                    If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                        EmployeeEmail = Employee.Email

                                    End If

                                    AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                End If

                                If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                    Dim Body As String = Alert.EmailBody
                                    Try

                                        If Alert IsNot Nothing AndAlso Alert.ID > 0 Then

                                            Body &= AdvantageFramework.Email.Classes.HtmlEmail.AppendListenerAlertIDToBody(Alert.ID, True)

                                        End If

                                    Catch ex As Exception
                                    End Try

                                    AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Body & "</body>", 2, SendingEmailStatus)

                                End If

                                AlertCreated = True

                            End If

                        Else

                            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                            Console.WriteLine(AlertSubject)
                            Console.WriteLine(AlertBody)

                        End If

                    End If

                End If

            End If

            CreateAlertForVendorContractNotification = AlertCreated

        End Function
        Private Function CreateAlertBodyHeaderForVendorContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                            ByVal EmployeeName As String,
                                                                            ByVal VendorContractNotificationAlertCategory As AdvantageFramework.AlertSystem.VendorContractNotificationAlertCategory,
                                                                            ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract,
                                                                            ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim AlertBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If VendorContractNotificationAlertCategory = VendorContractNotificationAlertCategory.UpcomingVendorContractRenewal Then

                        StringBuilder.AppendLine("Vendor Contract ends on " & VendorContract.EndDate.Value.ToShortDateString & " for:")
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Vendor: " & Vendor.ToString)

                    End If

                End If

                AlertBodyHeader = StringBuilder.ToString

            Catch ex As Exception
                AlertBodyHeader = ""
            Finally
                CreateAlertBodyHeaderForVendorContractNotification = AlertBodyHeader
            End Try

        End Function
        Private Function CreateAlertBodyDetailForVendorContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                            ByVal VendorContractNotificationAlertCategory As AdvantageFramework.AlertSystem.VendorContractNotificationAlertCategory,
                                                                            ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract)

            'objects
            Dim AlertBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If VendorContractNotificationAlertCategory = VendorContractNotificationAlertCategory.UpcomingVendorContractRenewal Then

                        StringBuilder.AppendLine("Vendor Contract Details:")
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine(VendorContract.Code & " - " & VendorContract.Description)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("Start Date: " & VendorContract.StartDate.Value.ToShortDateString)
                        StringBuilder.AppendLine("")
                        StringBuilder.AppendLine("End Date: " & VendorContract.EndDate.Value.ToShortDateString)

                    End If

                    AlertBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertBodyDetail = ""
            Finally
                CreateAlertBodyDetailForVendorContractNotification = AlertBodyDetail
            End Try

        End Function

#End Region

#Region "  Email "
        Private Function CreateAlertEmailBodyHeaderForVendorContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                                 ByVal EmployeeName As String,
                                                                                 ByVal VendorContractNotificationAlertCategory As AdvantageFramework.AlertSystem.VendorContractNotificationAlertCategory,
                                                                                 ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract,
                                                                                 ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            'objects
            Dim AlertEmailBodyHeader As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderString As String = Nothing
            Dim VendorString As String = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If VendorContractNotificationAlertCategory = VendorContractNotificationAlertCategory.UpcomingVendorContractRenewal Then

                        HeaderString = "Vendor Contract ends on " & VendorContract.EndDate.Value.ToShortDateString & " for:"

                    End If

                    StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr><td colspan=""2"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """>")
                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """>")
                    StringBuilder.AppendLine("<strong>" & HeaderString & "</strong></font></td></tr>")
                    StringBuilder.AppendLine("</table>")

                    VendorString = "Vendor: " & Vendor.ToString

                    StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr>")
                    StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & VendorString & "</font></td>")
                    StringBuilder.AppendLine("</tr>")
                    StringBuilder.Append("<hr size=""1"" color=""" & AdvantageFramework.Email.HeaderFontColor & """ />")
                    StringBuilder.AppendLine("</table>")

                    AlertEmailBodyHeader = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyHeader = ""
            Finally
                CreateAlertEmailBodyHeaderForVendorContractNotification = AlertEmailBodyHeader
            End Try

        End Function
        Private Function CreateAlertEmailBodyDetailForVendorContractNotification(ByRef DbContext As AdvantageFramework.Database.DbContext,
                                                                                 ByVal VendorContractNotificationAlertCategory As AdvantageFramework.AlertSystem.VendorContractNotificationAlertCategory,
                                                                                 ByVal VendorContract As AdvantageFramework.Database.Entities.VendorContract) As String
            'objects
            Dim AlertEmailBodyDetail As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim HeaderString As String = Nothing
            Dim ContractString As String = Nothing
            Dim ContractStartString As String = Nothing
            Dim ContractEndString As String = Nothing
            Dim ReportFrequencyString As String = Nothing
            Dim ReportLastCompletedString As String = Nothing
            Dim ReportNextStartString As String = Nothing

            Try

                If DbContext IsNot Nothing Then

                    StringBuilder = New System.Text.StringBuilder

                    If VendorContractNotificationAlertCategory = VendorContractNotificationAlertCategory.UpcomingVendorContractRenewal Then

                        HeaderString = "Vendor Contract Details:"

                    End If

                    ContractString = VendorContract.Code & " - " & VendorContract.Description
                    ContractStartString = "Start Date: " & VendorContract.StartDate.Value.ToShortDateString
                    ContractEndString = "End Date: " & VendorContract.EndDate.Value.ToShortDateString

                    StringBuilder.AppendLine("<br/><table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                    StringBuilder.AppendLine("<tr><td colspan=""2"" align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.HeaderBackgroundColor & """>")
                    StringBuilder.AppendLine("<font size=""" & AdvantageFramework.Email.HeaderFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.HeaderFontColor & """>")
                    StringBuilder.AppendLine("<strong>" & HeaderString & "</strong></font></td></tr>")
                    StringBuilder.AppendLine("</table>")

                    If VendorContractNotificationAlertCategory = VendorContractNotificationAlertCategory.UpcomingVendorContractRenewal Then

                        StringBuilder.AppendLine("<table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ContractString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ContractStartString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.AppendLine("<tr>")
                        StringBuilder.AppendLine("<td width=200 align=""left"" valign=""middle"" bgcolor=""" & AdvantageFramework.Email.RowBackgroundColor & """><font size=""" & AdvantageFramework.Email.RowFontSize & """ face=""" & AdvantageFramework.Email.Font & """ color=""" & AdvantageFramework.Email.RowFontColor & """>" & ContractEndString & "</font></td>")
                        StringBuilder.AppendLine("</tr>")
                        StringBuilder.Append("<hr size=""1"" color=""" & AdvantageFramework.Email.HeaderFontColor & """ />")
                        StringBuilder.AppendLine("</table>")

                    End If

                    AlertEmailBodyDetail = StringBuilder.ToString

                End If

            Catch ex As Exception
                AlertEmailBodyDetail = ""
            Finally
                CreateAlertEmailBodyDetailForVendorContractNotification = AlertEmailBodyDetail
            End Try

        End Function

#End Region

#End Region

#Region " Conceptshare External Reviews "

#End Region

#Region " Inbox "
        Public Function LoadAlertsAndAssignmentsManagerAsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                   ByRef Filter As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerFilter,
                                                                   ByRef ErrorMessage As String) As DataTable

            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            Try

                SqlConnection = DbContext.Database.Connection

                SqlCommand = New SqlClient.SqlCommand("advsp_alert_aam_original", SqlConnection)

                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@UserCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(DbContext.UserCode) = False,
                                                                                    DbContext.UserCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeCode",
                                                                                 IIf(String.IsNullOrWhiteSpace(Filter.EmployeeCode) = False,
                                                                                    Filter.EmployeeCode, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@SearchCriteria",
                                                                                 IIf(String.IsNullOrWhiteSpace(Filter.SearchCriteria) = False,
                                                                                    Filter.SearchCriteria, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@InboxType", Filter.InboxType))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ShowAssignmentType", Filter.ShowAssignmentType))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IsJobAlertsPage", Filter.IsJobAlertsPage))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobNumber",
                                                                                 IIf(Filter.JobNumber IsNot Nothing AndAlso Filter.JobNumber > 0,
                                                                                    Filter.JobNumber, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@JobComponentNumber",
                                                                                 IIf(Filter.JobComponentNumber IsNot Nothing AndAlso Filter.JobComponentNumber > 0,
                                                                                    Filter.JobComponentNumber, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@StartDate",
                                                                                 IIf(Filter.StartDate IsNot Nothing,
                                                                                    Filter.StartDate, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EndDate",
                                                                                 IIf(Filter.EndDate IsNot Nothing AndAlso CType(Filter.EndDate, Date).ToShortDateString <> Now.ToShortDateString,
                                                                                    Filter.EndDate, System.DBNull.Value)))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeCompletedAssignments", Filter.IncludeCompletedAssignments))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@GroupBy", Filter.GroupBy))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IsCount", Filter.IsCount))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@RecordCount", Filter.RecordCount))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeReviews", Filter.IncludeReviews))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeBoardLevel", Filter.IncludeBoardLevel))
                SqlCommand.Parameters.Add(New System.Data.SqlClient.SqlParameter("@IncludeBacklog", Filter.IncludeBacklog))

                SqlCommand.CommandType = CommandType.StoredProcedure

                SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

                Using SqlCommand

                    DataTable = New DataTable

                    SqlDataAdapter.Fill(DataTable)

                End Using

                If DataTable IsNot Nothing AndAlso DataTable.Rows IsNot Nothing Then

                    Filter.RecordCount = DataTable.Rows.Count

                Else

                    Filter.RecordCount = 0

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Filter.RecordCount = -1
            End Try

            Return DataTable

        End Function

        Public Function LoadAlertsAsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal ThisEmployeeCode As String,
                                              ByVal EmpCode As String,
                                              ByVal InboxType As String,
                                              ByVal FilterLevel As String,
                                              ByVal OfficeCode As String,
                                              ByVal ClCode As String,
                                              ByVal DivCode As String,
                                              ByVal PrdCode As String,
                                              ByVal CmpIdentifier As String,
                                              ByVal CmpCode As String,
                                              ByVal JobNumber As Integer,
                                              ByVal JobComponentNbr As Integer,
                                              ByVal AlertTypeId As String,
                                              ByVal AlertCategoryId As String,
                                              ByVal StartDate As String,
                                              ByVal EndDate As String,
                                              ByVal AlertLevel As String,
                                              ByVal VnCode As String,
                                              ByVal EstimateNumber As Integer,
                                              ByVal EstComponentNbr As Integer,
                                              ByVal TaskCode As String,
                                              ByVal TaskDescription As String,
                                              ByVal ATBNumber As Integer,
                                              ByVal ShowAssignmentType As String,
                                              ByVal AlrtNotifyHdrId As Integer,
                                              ByVal AlertNotifyName As String,
                                              ByVal IncludeCompletedAssignments As Boolean,
                                              ByVal IsJobAlertsPage As Boolean,
                                              ByVal AlertAssignmentSeqNbr As Integer,
                                              ByVal GroupBy As String,
                                              ByVal SearchCriteria As String,
                                              ByVal AccountExecutiveCode As String,
                                              ByVal ManagerCode As String,
                                              ByVal StateId As Integer,
                                              ByVal RecordsToReturn As Integer,
                                              ByVal IsCount As Boolean,
                                              ByRef RecordCount As Integer,
                                              ByVal IncludeReviews As Boolean,
                                              ByVal IncludeBoardLevel As Boolean,
                                              ByRef ErrorMessage As String) As DataTable

            Try

                'myreviews
                Dim MyObjDef As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Methods(DbContext.ConnectionString, DbContext.UserCode)
                Dim StaticRestrictionsDictionary As New Generic.Dictionary(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition, Boolean)
                Dim NeedsOr As Boolean = False
                Dim IsCc As String = "0"
                Dim SQL As String = ""
                Dim DateStart As DateTime? = Nothing
                Dim DateEnd As DateTime? = Nothing
                Dim IncludeBothAlertRcptTables As Boolean = False
                Dim ExcludeBothAlertRcptTables As Boolean = False
                Dim HasManagerFilterInput As Boolean = False
                Dim HasManagerDBRestriction As Boolean = False
                Dim ExcludeFieldsThatWillCauseDuplicates As Boolean = False
                Dim RecipientTableName As String = "ALERT_RCPT"
                Dim Offset As Decimal = 0 'cEmployee.GetTimeZoneOffset()
                Dim StringBuilder As System.Text.StringBuilder = Nothing
                Dim MarkReadAlertForNoDuplicates As Boolean = False
                Dim JobLogTableIsJoined As Boolean = False
                Dim JobComponentTableIsJoined As Boolean = False
                Dim HasEmployeeJoin As Boolean = False
                Dim TemplateIsSet As Boolean = False
                Dim SqlParameters As Generic.List(Of System.Data.SqlClient.SqlParameter) = Nothing
                Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim OfficeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ClientCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim DivisionCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ProductCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim CampaignCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AlertTypeIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AlertCategoryIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim StartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim EndDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AlertLevelSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim VendorCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim EstimateNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim EstimateComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim TaskFunctionCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim TaskFunctionDescriptionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AlertNotifyNameSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim IDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AlertNotifyHeaderIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim SearchCriteriaSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AlertStateIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim AccountExecutiveCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ManagerCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ATBNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim SortByStringBuilder As System.Text.StringBuilder = Nothing
                Dim IncludeCompletedAssignmentsSQL As String = ""
                Dim SelectText As String = ""
                Dim IncludesDismissed As Boolean = False
                Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
                Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
                Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
                Dim DataTable As System.Data.DataTable = Nothing
                Dim Alerts As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert) = Nothing
                Dim IncludeTasks As Boolean = False
                Dim IncludeReadAlertFunction As Boolean = False

                Dim AppVars As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
                Dim TaskStatus As String = String.Empty
                Dim TaskShow As String = String.Empty
                Dim TaskOnlyStartDue As String = String.Empty

                Dim TodayDate As Date = CType(Today.ToShortDateString, Date)

                Dim ClientUsingBoards As Boolean = HasBoards(DbContext)

                InboxType = InboxType.Trim().ToLower()
                ShowAssignmentType = ShowAssignmentType.Trim().ToLower()
                ErrorMessage = ""
                HasManagerFilterInput = ManagerCode.Trim() <> ""
                Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, ThisEmployeeCode)
                StringBuilder = New System.Text.StringBuilder

                If IsJobAlertsPage = False Then

                    If ShowAssignmentType <> "myalerts" Then

                        IncludeTasks = True

                        AppVars = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, DbContext.UserCode, "MyTasks").ToList

                        Try
                            TaskStatus = AppVars.Where(Function(av) av.Name = "ddType").First.Value
                        Catch ex As Exception
                            TaskStatus = String.Empty
                        End Try
                        Try
                            TaskShow = AppVars.Where(Function(av) av.Name = "StartToday").First.Value
                        Catch ex As Exception
                            TaskShow = String.Empty
                        End Try
                        Try
                            TaskOnlyStartDue = AppVars.Where(Function(av) av.Name = "TodayOnlyStartDue").First.Value
                        Catch ex As Exception
                            TaskOnlyStartDue = String.Empty
                        End Try

                    End If

                End If

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DbContext.ConnectionString, DbContext.UserCode)

                    If IsJobAlertsPage = False Then

                        Try

                            StaticRestrictionsDictionary = MyObjDef.LoadObjectStaticRestrictions(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.AlertInbox_AllAssignments)

                        Catch ex As Exception

                            StaticRestrictionsDictionary.Clear()

                        End Try

                    End If

                    If (InboxType = "inbox" AndAlso ShowAssignmentType = "unassigned") OrElse
                            (InboxType = "sent" AndAlso ShowAssignmentType = "unassigned") Then

                        ExcludeBothAlertRcptTables = True

                    End If

                    If IsJobAlertsPage = True OrElse InboxType = "sent" OrElse InboxType = "drafts" Then ExcludeFieldsThatWillCauseDuplicates = True

                    'ignore completed
                    If IsJobAlertsPage = False Then

                        IncludeCompletedAssignments = False

                    End If

                    If IsJobAlertsPage = True Then

                        EmpCode = ""

                    End If

                    If IsJobAlertsPage = False AndAlso InboxType = "dismissed" Then RecipientTableName = "ALERT_RCPT_DISMISSED"
                    If (IsJobAlertsPage = False And InboxType = "received") OrElse ShowAssignmentType <> "myalerts" Then IncludeBothAlertRcptTables = True
                    If InboxType = "inbox" OrElse InboxType = "drafts" Then IncludeBothAlertRcptTables = False
                    If IsJobAlertsPage = True Then

                        IncludeBothAlertRcptTables = False
                        ExcludeBothAlertRcptTables = True

                    End If

                    If InboxType = "drafts" Then ExcludeBothAlertRcptTables = True

                    If ShowAssignmentType = "myalertsandassignments" AndAlso (InboxType = "sent" OrElse InboxType = "received") Then

                        IncludeBothAlertRcptTables = False
                        ExcludeBothAlertRcptTables = True

                    End If

                    If ShowAssignmentType <> "myalerts" Then ' String.IsNullOrWhiteSpace(EmpCode) = False Then ' ShowAssignmentType = "myalertassignments" OrElse ShowAssignmentType = "myalertsandassignments" Then

                        IncludeTasks = True
                        IncludeBoardLevel = True

                    Else

                        IncludeBoardLevel = True

                    End If



                    With StringBuilder

                        .Append("SELECT DISTINCT  ")

                        .Append(ReturnFields("A", GroupBy, IsCount))

                        If IsCount = False Then

                            .Append(" CASE ")
                            .Append("       WHEN READ_ALERT = 1 THEN CAST('Read' AS VARCHAR)")
                            .Append("       ELSE CAST('Not Read' AS VARCHAR)")
                            .Append(" END AS READ_ALERT_TEXT")

                        Else

                            .Append(" '' AS READ_ALERT_TEXT")

                        End If

                        .Append(" FROM ( SELECT ")

                        'INNER MOST QUERY STARTS HERE

                        If RecordsToReturn > 0 Then .Append(String.Format(" TOP {0} ", RecordsToReturn))

                        .Append(" ALERT.ALERT_ID,")

                        If IsCount = False Then

                            .Append(" REPLACE(REPLACE(ALERT.SUBJECT,CHAR(13)+CHAR(10), ''),CHAR(10),'') AS [SUBJECT],")

                            If Offset = 0 Then

                                .Append(" ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED) AS GENERATED,")

                            Else

                                .Append(String.Format(" ISNULL(DATEADD(mi, (CONVERT(INT, {0}) * 60) + ({0} - CONVERT(INT, {0})), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)) AS GENERATED,", Offset))

                            End If

                            .Append(" CASE")
                            .Append("   WHEN ALERT.CP_ALERT = 1 AND ISNUMERIC(ALERT.ALERT_USER) = 1 THEN (SELECT CONT_FML FROM CDP_CONTACT_HDR WITH (NOLOCK) WHERE  CDP_CONTACT_ID = CAST(ALERT.ALERT_USER AS INT))")
                            .Append("   ELSE ALERT.LAST_UPDATED_FML")
                            .Append(" END AS [USER_NAME],")
                            .Append(" CASE WHEN ISNULL(ALERT.PRIORITY,0) = 0 THEN 3 ELSE ISNULL(ALERT.PRIORITY,3) END AS PRIORITY,")
                            .Append(" CASE")
                            .Append("   WHEN ALERT.PRIORITY = 1 THEN '1,Highest'")
                            .Append("   WHEN ALERT.PRIORITY = 2 THEN '2,High'")
                            .Append("   WHEN ALERT.PRIORITY = 3 THEN '3,Normal'")
                            .Append("   WHEN ALERT.PRIORITY = 4 THEN '4,Low'")
                            .Append("   WHEN ALERT.PRIORITY = 5 THEN '5,Lowest'")
                            .Append("   ELSE '3,Normal'")
                            .Append(" END AS CARD_GROUPING_PRIORITY_TEXT,")
                            .Append(" ALERT_TYPE.ALERT_TYPE_DESC AS TYPE,")
                            .Append(" ALERT_CATEGORY.ALERT_DESC AS CATEGORY,")
                            .Append(" ISNULL(ATTACHMENT_COUNT, 0) AS ATTACHMENTCOUNT,")

                            If IncludeTasks = True Then

                                .Append(" CASE WHEN ALERT.ALERT_CAT_ID = 71 THEN JTD.TASK_START_DATE ELSE ALERT.[START_DATE] END AS START_DATE,")
                                .Append(" CASE WHEN ALERT.ALERT_CAT_ID = 71 THEN JTD.JOB_REVISED_DATE ELSE ALERT.DUE_DATE END AS DUE_DATE,")

                            Else

                                .Append(" ALERT.START_DATE,")
                                .Append(" ALERT.DUE_DATE,")

                            End If
                            .Append(" ALERT.CL_CODE,")
                            .Append(" ALERT.DIV_CODE,")
                            .Append(" ALERT.PRD_CODE,")
                            .Append(" CLIENT.CL_NAME,")
                            .Append(" SV.[VERSION],")
                            .Append(" SB.BUILD,")
                            .Append(" ISNULL('v.' + SV.[VERSION], '') + ISNULL('.' + SB.BUILD, '') AS VERSION_BUILD,")

                            If GroupBy = "myalertsandassignments" Then

                                .Append(" CASE WHEN ISNULL(SD.SPRINT_HDR_ID, 0) = 0 AND COALESCE(ALERT_STATES.ALERT_STATE_NAME, ALS.ALERT_STATE_NAME, 'N/A') = 'Backlog' THEN NULL ELSE COALESCE(ALERT_STATES.ALERT_STATE_NAME, ALS.ALERT_STATE_NAME, 'N/A') END AS ALERT_STATE_NAME,")

                            Else

                                .Append(" CASE WHEN ISNULL(SD.SPRINT_HDR_ID, 0) = 0 AND ISNULL(ALERT_STATES.ALERT_STATE_NAME, ALS.ALERT_STATE_NAME) = 'Backlog' THEN NULL ELSE ISNULL(ALERT_STATES.ALERT_STATE_NAME, ALS.ALERT_STATE_NAME) END AS ALERT_STATE_NAME,")

                            End If

                        End If

                        If InboxType = "drafts" Then ExcludeBothAlertRcptTables = True


                        If ExcludeBothAlertRcptTables = False Then

                            If IsJobAlertsPage = True OrElse InboxType = "sent" OrElse ShowAssignmentType = "allalertassignments" OrElse ShowAssignmentType = "unassigned" Then

                                MarkReadAlertForNoDuplicates = True

                            End If
                            If MarkReadAlertForNoDuplicates = True Then

                                IncludeReadAlertFunction = True

                                If InboxType <> "inbox" Then

                                    .Append(" 1 AS READ_ALERT, ")

                                Else

                                    If IsCount = False Then

                                        .Append(" CASE ")
                                        If IncludeTasks = True Then
                                            If ShowAssignmentType = "allalertassignments" Then
                                                .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND (SELECT COUNT(1) FROM JOB_TRAFFIC_DET_EMPS JTE WITH (NOLOCK) WHERE ALERT.JOB_NUMBER = JTE.JOB_NUMBER And ALERT.JOB_COMPONENT_NBR = JTE.JOB_COMPONENT_NBR And ALERT.TASK_SEQ_NBR = JTE.SEQ_NBR) > 1 THEN 0 ")
                                            End If
                                            .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE = @EMP_CODE AND JTE.READ_ALERT = 1 THEN 1 ")
                                            If InboxType <> "dismissed" Then
                                                .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND ALERT_RCPT.EMP_CODE = @EMP_CODE AND (ALERT_RCPT.CURRENT_RCPT IS NULL OR ALERT_RCPT.CURRENT_RCPT = 0) AND ALERT_RCPT.READ_ALERT = 1 THEN 1")
                                            End If
                                            .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE = @EMP_CODE AND (JTE.READ_ALERT = 0 OR JTE.READ_ALERT IS NULL) THEN 0 ")
                                            .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE IS NOT NULL AND JTE.READ_ALERT = 1 THEN 1 ")
                                            .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE IS NOT NULL AND (JTE.READ_ALERT = 0 OR JTE.READ_ALERT IS NULL) THEN 0 ")
                                        End If
                                        '.Append(" WHEN (SELECT COUNT(1) FROM ALERT_RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND EMP_CODE = ALERT.ASSIGNED_EMP_CODE AND (READ_ALERT IS NULL OR READ_ALERT = 0)) > 0 THEN 0 ")
                                        .Append(" WHEN ALERT.IS_WORK_ITEM = 1 AND (SELECT COUNT(1) FROM ALERT_RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND CURRENT_NOTIFY = 1 AND (READ_ALERT IS NULL OR READ_ALERT = 0)) > 0 THEN 0 ")
                                        .Append(" ELSE 1 ")
                                        .Append(" END AS READ_ALERT, ")

                                    End If

                                End If

                                '.Append(String.Format(" CASE WHEN ALERT.ASSIGNED_EMP_CODE = '{0}' THEN 1 ELSE 0 END AS CURRENT_NOTIFY, ", ThisEmployeeCode))
                                .Append(String.Format(" 0 AS CURRENT_NOTIFY, "))

                            Else

                                If IsCount = False Then

                                    .Append(String.Format(" CASE"))

                                    If IncludeTasks = True Then

                                        .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE = @EMP_CODE AND JTE.READ_ALERT = 1 THEN 1")

                                        If InboxType <> "dismissed" Then

                                            .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND ALERT_RCPT.EMP_CODE = @EMP_CODE AND (ALERT_RCPT.CURRENT_RCPT IS NULL OR ALERT_RCPT.CURRENT_RCPT = 0) AND ALERT_RCPT.READ_ALERT = 1 THEN 1")

                                        End If

                                        .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE = @EMP_CODE AND (JTE.READ_ALERT = 0 OR JTE.READ_ALERT IS NULL) THEN 0 ")
                                        .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE IS NOT NULL AND JTE.READ_ALERT = 1 THEN 1 ")
                                        .Append(" WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE IS NOT NULL AND (JTE.READ_ALERT = 0 OR JTE.READ_ALERT IS NULL) THEN 0 ")

                                    End If

                                    '.Append(String.Format("     WHEN ALERT.IS_WORK_ITEM = 1 AND (NOT ALERT.ASSIGNED_EMP_CODE IS NULL) AND {0}.EMP_CODE = ALERT.ASSIGNED_EMP_CODE AND {0}.CURRENT_NOTIFY = 1 AND {0}.READ_ALERT = 1 THEN 1 ", RecipientTableName))
                                    .Append(String.Format("     WHEN ALERT.IS_WORK_ITEM = 1 AND {0}.EMP_CODE = '{1}' AND {0}.CURRENT_NOTIFY = 1 AND {0}.READ_ALERT = 1 THEN 1 ", RecipientTableName, ThisEmployeeCode))
                                    .Append(String.Format("     WHEN ALERT.IS_WORK_ITEM = 1 AND {0}.EMP_CODE <> '{1}' THEN CASE", RecipientTableName, ThisEmployeeCode))
                                    .Append(String.Format("																											WHEN (SELECT 1 FROM {0} WHERE ALERT_ID = ALERT.ALERT_ID AND {0}.EMP_CODE = '{1}' AND {0}.CURRENT_NOTIFY = 1 AND {0}.READ_ALERT = 1) = 1 THEN 1", RecipientTableName, ThisEmployeeCode))
                                    .Append(String.Format("																														ELSE 0"))
                                    .Append(String.Format("																									   END	"))
                                    .Append(String.Format("     ELSE {0}.READ_ALERT", RecipientTableName))
                                    .Append(String.Format(" END AS READ_ALERT,"))

                                End If

                                If ShowAssignmentType = "myalertsandassignments" Then

                                    .Append(String.Format(" CASE WHEN @EMP_CODE IS NULL THEN 0 WHEN NOT @EMP_CODE IS NULL AND ({0}.EMP_CODE = @EMP_CODE) THEN 1 ELSE 0 END AS CURRENT_NOTIFY, ", RecipientTableName))

                                Else

                                    .Append(String.Format(" CASE "))
                                    .Append(String.Format("	WHEN @EMP_CODE IS NULL THEN 0 "))

                                    If ExcludeBothAlertRcptTables = False Then

                                        .Append(String.Format("	WHEN NOT @EMP_CODE IS NULL AND (({0}.EMP_CODE = @EMP_CODE AND {0}.CURRENT_NOTIFY = 1)) THEN 1 ", RecipientTableName))

                                    Else

                                        '.Append(String.Format("	WHEN ALERT.ASSIGNED_EMP_CODE = @EMP_CODE THEN 1 "))

                                    End If
                                    If IncludeTasks = True Then

                                        .Append(" WHEN NOT @EMP_CODE IS NULL AND JTE.EMP_CODE = @EMP_CODE THEN 1")

                                    End If

                                    .Append(String.Format(" 	ELSE 0 "))
                                    .Append(String.Format(" END AS CURRENT_NOTIFY, "))

                                End If

                            End If

                            IsCc = String.Format(" ISNULL({0}.CURRENT_NOTIFY, 0) <> 1 ", RecipientTableName)

                            If IncludeTasks = True Then

                                If InboxType <> "inbox" Then

                                    .Append("0 AS IS_CC, ")

                                Else

                                    If ShowAssignmentType = "myalertsandassignments" Then

                                        .Append(String.Format(" CASE WHEN {0}.CURRENT_NOTIFY = 1 OR (NOT @EMP_CODE IS NULL AND JTE.EMP_CODE = @EMP_CODE AND JTD.JOB_COMPLETED_DATE IS NULL AND JT.COMPLETED_DATE IS NULL AND ({0}.CURRENT_RCPT IS NULL OR {0}.CURRENT_RCPT = 0)) THEN 0 ELSE 1 END AS IS_CC, ", RecipientTableName))

                                    ElseIf ShowAssignmentType = "allalertassignments" Then

                                        .Append(String.Format(" CASE WHEN {0}.CURRENT_NOTIFY = 1 OR (NOT @EMP_CODE IS NULL) OR (JTE.EMP_CODE IS NOT NULL) THEN 0 ELSE 1 END AS IS_CC,", RecipientTableName))

                                    Else

                                        .Append(String.Format(" CASE WHEN {0}.CURRENT_NOTIFY = 1 OR (NOT @EMP_CODE IS NULL AND JTE.EMP_CODE = @EMP_CODE) THEN 0 ELSE 1 END AS IS_CC,", RecipientTableName))

                                    End If

                                End If

                            Else

                                If InboxType <> "inbox" Then

                                    .Append("0 AS IS_CC, ")

                                Else

                                    If ShowAssignmentType = "myalertsandassignments" Then

                                        '.Append(String.Format(" CASE WHEN ALERT.ASSIGNED_EMP_CODE IS NULL THEN 1 WHEN {0}.CURRENT_NOTIFY = 1 THEN 0 ELSE 1 END AS IS_CC, ", RecipientTableName))
                                        .Append(String.Format(" CASE WHEN {0}.CURRENT_NOTIFY = 1 THEN 0 ELSE 1 END AS IS_CC, ", RecipientTableName))

                                    Else

                                        .Append(String.Format(" CASE WHEN {0}.CURRENT_NOTIFY = 1 THEN 0 ELSE 1 END AS IS_CC,", RecipientTableName))

                                    End If

                                End If

                            End If

                        Else

                            If IsCount = False Then

                                .Append(" 1 AS READ_ALERT,")

                            End If

                            .Append(" 0 AS CURRENT_NOTIFY,")
                            .Append(" 0 AS IS_CC,")

                            IsCc = "0 = 1"

                        End If

                        .Append("  CASE")
                        .Append("  	WHEN (ALERT.ALERT_STATE_ID IS NULL) THEN NULL")
                        .Append("  	ELSE")
                        .Append("  		CASE")
                        '.Append("  			WHEN NOT ALERT.ASSIGNED_EMP_CODE IS NULL THEN ALERT.ASSIGNED_EMP_CODE")
                        .Append("           WHEN ((SELECT COUNT(1) FROM ALERT_RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_RCPT.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT_RCPT.ALERT_STATE_ID) + (SELECT COUNT(1) FROM ALERT_RCPT_DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_RCPT_DISMISSED.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT_RCPT_DISMISSED.ALERT_STATE_ID)) > 1 THEN ''")
                        If ShowAssignmentType = "unassigned" Or InboxType = "drafts" Or InboxType = "sent" Or InboxType = "received" Then

                        ElseIf IsJobAlertsPage = True Then
                            .Append(String.Format("	          WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND NOT ALERT.ALERT_STATE_ID IS NULL THEN CASE WHEN (SELECT COUNT(1) FROM ALERT___RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT___RCPT.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT___RCPT.ALERT_STATE_ID) = 1 THEN (SELECT ALERT___RCPT.EMP_CODE FROM ALERT___RCPT WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT___RCPT.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT___RCPT.ALERT_STATE_ID)"))
                            .Append(String.Format("	          WHEN (SELECT COUNT(1) FROM ALERT_____RCPT___DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_____RCPT___DISMISSED.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT_____RCPT___DISMISSED.ALERT_STATE_ID) = 1 THEN (SELECT ALERT_____RCPT___DISMISSED.EMP_CODE FROM ALERT_____RCPT___DISMISSED INNER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = ALERT_____RCPT___DISMISSED.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_____RCPT___DISMISSED.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT_____RCPT___DISMISSED.ALERT_STATE_ID) ELSE 'Unassigned' END"))
                        ElseIf InboxType = "dismissed" Then
                            .Append("           WHEN (SELECT COUNT(1) FROM ALERT_RCPT_DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALERT_STATE_ID = ALERT_RCPT_DISMISSED.ALERT_STATE_ID) = 1 THEN '' ")
                        Else
                            .Append("           WHEN (SELECT COUNT(1) FROM ALERT_RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALERT_STATE_ID = ALERT_RCPT.ALERT_STATE_ID) = 1 THEN ALERT_RCPT.EMP_CODE ")
                        End If
                        .Append("  			ELSE ''")
                        .Append("  		END")
                        .Append("  END AS CURRENT_NOTIFY_EMP_CODE,")

                        .Append(String.Format(" CASE "))

                        If IsJobAlertsPage = True And ShowAssignmentType <> "myalerts" Then

                            .Append(String.Format("    WHEN (ALERT.ASSIGN_COMPLETED = 1 OR JTD.JOB_COMPLETED_DATE IS NOT NULL) THEN 'Completed' "))
                            .Append(String.Format("    WHEN (SELECT HAS_CHILDREN FROM dbo.advtf_traffic_schedule_GetHierarchyDates(@JOB_NUMBER,@JOB_COMPONENT_NBR) ATS WHERE JTD.SEQ_NBR = ATS.SEQ_NBR) = 1 THEN 'Parent' "))
                        Else
                            If ShowAssignmentType = "myalerts" Then
                                .Append(String.Format("    WHEN (ALERT.ASSIGN_COMPLETED = 1 AND ALERT.ALERT_CAT_ID <> 71) THEN 'Completed' "))
                            Else
                                .Append(String.Format("    WHEN (ALERT.ASSIGN_COMPLETED = 1 AND ALERT.ALERT_CAT_ID <> 71) OR ((JTD.JOB_COMPLETED_DATE IS NOT NULL OR JT.COMPLETED_DATE IS NOT NULL OR JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12) OR JTE.TEMP_COMP_DATE IS NOT NULL) AND ALERT.ALERT_CAT_ID = 71) THEN 'Completed' "))
                            End If


                        End If

                        If ShowAssignmentType = "unassigned" Then  'Change here to show Tasks in "unassigned" box!!!!

                            .Append(String.Format("   WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE IS NULL THEN 'Task'  WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND JTE.EMP_CODE IS NOT NULL THEN 'Task' "))

                        Else

                            .Append(String.Format("    WHEN (ALERT.ALERT_STATE_ID IS NULL) THEN  "))
                            .Append(String.Format("    CASE "))
                            .Append(String.Format("	   WHEN ((SELECT COUNT(1) FROM ALERT___RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL) + (SELECT COUNT(1) FROM ALERT_____RCPT___DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL)) > 1  THEN 'Multi' "))
                            If InboxType = "dismissed" Then
                                .Append(String.Format("	   WHEN ALERT.ALERT_STATE_ID IS NULL AND ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,''))"))
                                .Append(String.Format("	   WHEN ALERT.ALERT_STATE_ID Is NULL And (ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 0 Or ALERT_RCPT_DISMISSED.CURRENT_NOTIFY Is NULL) AND ALERT_CATEGORY.ALERT_CAT_ID <> 71 THEN  (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM ALERT_RCPT AR LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = AR.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND AR.CURRENT_NOTIFY = 1 AND AR.ALERT_STATE_ID IS NULL)"))
                            ElseIf IsJobAlertsPage = True Or InboxType = "drafts" Or InboxType = "sent" Or InboxType = "received" Then
                                .Append(String.Format("	   WHEN ALERT.ALERT_STATE_ID IS NULL AND ALERT_CATEGORY.ALERT_CAT_ID <> 71 THEN CASE WHEN (SELECT COUNT(1) FROM ALERT___RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALERT_STATE_ID IS NULL) = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM ALERT___RCPT INNER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = ALERT___RCPT.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALERT_STATE_ID IS NULL)"))
                                .Append(String.Format("	   WHEN (SELECT COUNT(1) FROM ALERT_____RCPT___DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALERT_STATE_ID IS NULL) = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM ALERT_____RCPT___DISMISSED INNER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = ALERT_____RCPT___DISMISSED.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALERT_STATE_ID IS NULL) END"))
                            Else
                                .Append(String.Format("	   WHEN ALERT.ALERT_STATE_ID IS NULL AND ALERT_RCPT.CURRENT_NOTIFY = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,''))"))
                                .Append(String.Format("	   WHEN ALERT.ALERT_STATE_ID Is NULL And (ALERT_RCPT.CURRENT_NOTIFY = 0 Or ALERT_RCPT.CURRENT_NOTIFY Is NULL) AND ALERT_CATEGORY.ALERT_CAT_ID <> 71 THEN  (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM ALERT_RCPT AR LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = AR.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND AR.CURRENT_NOTIFY = 1 AND AR.ALERT_STATE_ID IS NULL)"))
                            End If
                            .Append(String.Format("	   WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND ((SELECT COUNT(1) FROM JOB_TRAFFIC_DET_EMPS JTE WITH (NOLOCK) WHERE ALERT.JOB_NUMBER = JTE.JOB_NUMBER And ALERT.JOB_COMPONENT_NBR = JTE.JOB_COMPONENT_NBR And ALERT.TASK_SEQ_NBR = JTE.SEQ_NBR)) > 1  Then 'Multi' "))
                            If ShowAssignmentType <> "myalerts" And InboxType <> "drafts" Then
                                .Append(String.Format("    WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND ((SELECT COUNT(1) FROM JOB_TRAFFIC_DET_EMPS JTE WITH (NOLOCK) WHERE ALERT.JOB_NUMBER = JTE.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTE.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTE.SEQ_NBR)) = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM EMPLOYEE E WHERE E.EMP_CODE = JTE.EMP_CODE) "))
                            End If
                            If ShowAssignmentType = "myalerts" Then
                                .Append(String.Format("    WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 AND ((SELECT COUNT(1) FROM JOB_TRAFFIC_DET_EMPS JTE WITH (NOLOCK) WHERE ALERT.JOB_NUMBER = JTE.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTE.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTE.SEQ_NBR)) = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM JOB_TRAFFIC_DET_EMPS JTE INNER JOIN EMPLOYEE E ON JTE.EMP_CODE = E.EMP_CODE WHERE E.EMP_CODE = JTE.EMP_CODE AND ALERT.JOB_NUMBER = JTE.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTE.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTE.SEQ_NBR) "))
                            End If
                            .Append(String.Format("    ELSE NULL END "))



                        End If

                        .Append(String.Format("    ELSE CASE "))
                        '.Append(String.Format("           WHEN NOT ALERT.ASSIGNED_EMP_FML IS NULL THEN ALERT.ASSIGNED_EMP_FML "))
                        .Append(String.Format("	          WHEN ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALERT_STATE_ID IS NULL AND ((SELECT COUNT(1) FROM ALERT___RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL) + (SELECT COUNT(1) FROM ALERT_____RCPT___DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL)) > 1  THEN 'Multi' "))

                        .Append(String.Format("	          WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND NOT ALERT.ALERT_STATE_ID IS NULL AND ((SELECT COUNT(1) FROM ALERT___RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT___RCPT.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT___RCPT.ALERT_STATE_ID) + (SELECT COUNT(1) FROM ALERT_____RCPT___DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_____RCPT___DISMISSED.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT_____RCPT___DISMISSED.ALERT_STATE_ID)) > 1  THEN 'Multi' "))
                        If ShowAssignmentType = "unassigned" Then
                            .Append(String.Format("	          WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND NOT ALERT.ALERT_STATE_ID IS NULL THEN CASE WHEN (SELECT COUNT(1) FROM ALERT___RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT___RCPT.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT___RCPT.ALERT_STATE_ID) = 1 THEN 'Assigned'"))
                            .Append(String.Format("	          WHEN (SELECT COUNT(1) FROM ALERT_____RCPT___DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_____RCPT___DISMISSED.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT_____RCPT___DISMISSED.ALERT_STATE_ID) = 1 THEN 'Assigned' ELSE 'Unassigned' END"))
                        ElseIf IsJobAlertsPage = True Or InboxType = "drafts" Or InboxType = "sent" Or InboxType = "received" Then
                            .Append(String.Format("	          WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND NOT ALERT.ALERT_STATE_ID IS NULL THEN CASE WHEN (SELECT COUNT(1) FROM ALERT___RCPT WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT___RCPT.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT___RCPT.ALERT_STATE_ID) = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM ALERT___RCPT INNER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = ALERT___RCPT.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT___RCPT.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT___RCPT.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT___RCPT.ALERT_STATE_ID)"))
                            .Append(String.Format("	          WHEN (SELECT COUNT(1) FROM ALERT_____RCPT___DISMISSED WITH (NOLOCK) WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_____RCPT___DISMISSED.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT_____RCPT___DISMISSED.ALERT_STATE_ID) = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM ALERT_____RCPT___DISMISSED INNER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = ALERT_____RCPT___DISMISSED.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND ALERT_____RCPT___DISMISSED.CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID = ALERT_____RCPT___DISMISSED.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = ALERT_____RCPT___DISMISSED.ALERT_STATE_ID) ELSE 'Unassigned' END"))
                        ElseIf InboxType = "dismissed" Then
                            .Append(String.Format("	          WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND NOT ALERT.ALERT_STATE_ID IS NULL AND ALERT.ALERT_STATE_ID = ALERT_RCPT_DISMISSED.ALERT_STATE_ID THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,''))"))
                            .Append(String.Format("	          WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND NOT ALERT.ALERT_STATE_ID IS NULL AND (ALERT_RCPT_DISMISSED.CURRENT_NOTIFY = 0 OR ALERT_RCPT_DISMISSED.CURRENT_NOTIFY IS NULL) THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM ALERT_RCPT AR LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = AR.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND AR.CURRENT_NOTIFY = 1 AND AR.ALERT_STATE_ID IS NOT NULL)"))
                        Else
                            .Append(String.Format("	          WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND NOT ALERT.ALERT_STATE_ID IS NULL AND ALERT.ALERT_STATE_ID = ALERT_RCPT.ALERT_STATE_ID AND ALERT_RCPT.CURRENT_NOTIFY = 1 THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,''))"))
                            .Append(String.Format("	          WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND NOT ALERT.ALERT_STATE_ID IS NULL AND (ALERT_RCPT.CURRENT_NOTIFY = 0 OR ALERT_RCPT.CURRENT_NOTIFY IS NULL) THEN (SELECT coalesce((rtrim(EMP_FNAME) + ' '),'') + coalesce((EMP_MI + '. '),'') + coalesce(EMP_LNAME,'') FROM ALERT_RCPT AR LEFT OUTER JOIN EMPLOYEE E ON E.EMP_CODE = AR.EMP_CODE WHERE ALERT_ID = ALERT.ALERT_ID AND AR.CURRENT_NOTIFY = 1 AND AR.ALERT_STATE_ID IS NOT NULL)"))
                        End If
                        .Append(String.Format("           ELSE 'Unassigned' "))
                        .Append(String.Format("         END "))
                        .Append(String.Format(" END AS CURRENT_NOTIFY_EMP_FML,"))

                        If IsCount = False Then

                            .Append("  RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_NUMBER), 6 ) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_COMPONENT_NBR), 3) + ' - ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') + ' | ' + CLIENT.CL_NAME AS GRP_COMPONENT,")

                            Select Case GroupBy
                                Case "O"

                                    .Append(" OFFICE.OFFICE_NAME AS GRP_OFFICE,")

                                Case "C"

                                    .Append(" CLIENT.CL_NAME AS GRP_CLIENT,")

                                Case "CD"

                                    .Append(" DIVISION.DIV_NAME AS GRP_DIVISION,")

                                Case "CDP"

                                    .Append(" PRODUCT.PRD_DESCRIPTION AS GRP_PRODUCT,")

                                Case "CDPJ"

                                    .Append(" RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_LOG.JOB_NUMBER), 6) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') + ' | ' + CLIENT.CL_NAME AS GRP_JOB,")

                                Case "CM"

                                    .Append(" ISNULL(CAMPAIGN.CMP_NAME, '') AS GRP_CAMPAIGN,")

                                Case "PST"

                                    .Append(" CASE ")
                                    .Append(" WHEN JOB_TRAFFIC_DET.FNC_CODE IS NULL OR")
                                    .Append("   JOB_TRAFFIC_DET.FNC_CODE = '' THEN JOB_TRAFFIC_DET.TASK_DESCRIPTION")
                                    .Append(" ELSE JOB_TRAFFIC_DET.TASK_DESCRIPTION")
                                    .Append(" END AS GRP_TASK,")

                                Case "ES"

                                    .Append(" RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), ALERT.ESTIMATE_NUMBER), 6) + ' - ' + ISNULL(ESTIMATE_LOG.EST_LOG_DESC, '') AS GRP_ESTIMATE,")

                                Case "EST"

                                    .Append(" RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), ALERT.ESTIMATE_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 2) + CONVERT(VARCHAR(20), ALERT.EST_COMPONENT_NBR), 2) + ' - ' + ISNULL(ESTIMATE_COMPONENT.EST_COMP_DESC, '') AS GRP_ESTIMATE_COMPONENT,")

                                Case "DUE_DATE", "DUE_DATE_ASC"

                                    If IncludeTasks = True Then
                                        .Append(" CASE WHEN ALERT.ALERT_CAT_ID = 71 THEN CONVERT(CHAR(10), JTD.JOB_REVISED_DATE, 23) ELSE CONVERT(CHAR(10), ALERT.DUE_DATE, 23) END AS GRP_DUE_DATE,")
                                        .Append(" CASE WHEN ALERT.ALERT_CAT_ID = 71 THEN DATENAME(dw, JTD.JOB_REVISED_DATE) + ',' + SPACE(1) + DATENAME(m, JTD.JOB_REVISED_DATE) + SPACE(1) + CAST(DAY(JTD.JOB_REVISED_DATE) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(JTD.JOB_REVISED_DATE) AS CHAR(4)) ELSE DATENAME(dw, ALERT.DUE_DATE) + ',' + SPACE(1) + DATENAME(m, ALERT.DUE_DATE) + SPACE(1) + CAST(DAY(ALERT.DUE_DATE) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(ALERT.DUE_DATE) AS CHAR(4)) END AS GRP_DUE_DATE_DISPLAY,")
                                    Else
                                        .Append(" CONVERT(CHAR(10), ALERT.DUE_DATE, 23) AS GRP_DUE_DATE,")
                                        .Append(" DATENAME(dw, ALERT.DUE_DATE) + ',' + SPACE(1) + DATENAME(m, ALERT.DUE_DATE) + SPACE(1) + CAST(DAY(ALERT.DUE_DATE) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(ALERT.DUE_DATE) AS CHAR(4)) AS GRP_DUE_DATE_DISPLAY,")

                                    End If


                                Case "ALERT_NOTIFY_NAME"

                                    .Append(" ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID,")
                                    .Append(" ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME,")

                                Case "PRIORITY"

                                    .Append(" CASE ")
                                    .Append(" WHEN ALERT.PRIORITY = 1 THEN 'Highest'")
                                    .Append(" WHEN ALERT.PRIORITY = 2 THEN 'High'")
                                    .Append(" WHEN ALERT.PRIORITY = 3 THEN 'Normal'")
                                    .Append(" WHEN ALERT.PRIORITY = 4 THEN 'Low'")
                                    .Append(" WHEN ALERT.PRIORITY = 5 THEN 'Lowest'")
                                    .Append(" ELSE 'Normal'")
                                    .Append(" END AS GRP_PRIORITY,")

                                Case "AB"

                                    .Append(" RIGHT(REPLICATE('0', 6) + CONVERT(VARCHAR(20), ATB_REV.ATB_NUMBER), 6) + '/' + RIGHT(REPLICATE('0', 3) + CONVERT(VARCHAR(20), ATB_REV.REV_NBR), 3) + ' - ' + ISNULL(ATB_REV.ATB_DESCRIPTION, '') AS GRP_ATB,")

                                Case "LAST_UPD"

                                    .Append(" DATENAME(dw, ALERT.LAST_UPDATED) + ',' + SPACE(1) + DATENAME(m, ALERT.LAST_UPDATED) + SPACE(1) + CAST(DAY(ALERT.LAST_UPDATED) AS VARCHAR(2)) + ',' + SPACE(1) + CAST(YEAR(ALERT.LAST_UPDATED) AS CHAR(4)) AS GRP_LAST_UPD,")

                                Case "VER_BLD"

                                    .Append(" SV.VERSION + ', ' + SB.BUILD AS GRP_VER_BLD, ")

                            End Select

                            .Append(" COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) AS ID,")

                        End If

                        .Append(" CASE WHEN ((NOT ALERT.ALERT_STATE_ID IS NULL AND NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL) OR (NOT ALERT.IS_WORK_ITEM IS NULL AND ALERT.IS_WORK_ITEM = 1)) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS IS_ASSIGNMENT,")
                        .Append(" ISNULL(ALERT.IS_WORK_ITEM, 0) AS IS_WORK_ITEM,")

                        If IsCount = False Then

                            .Append(" ISNULL(ALERT.JOB_NUMBER, 0) AS JOB_NUMBER,")
                            .Append(" ISNULL(ALERT.JOB_COMPONENT_NBR, 0) AS JOB_COMPONENT_NBR,")
                            .Append(" ISNULL(ALERT.TASK_SEQ_NBR, 0) AS TASK_SEQ_NBR,")
                            .Append(" CASE ")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'OF' THEN 'Office'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'CL' THEN 'Client'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'DI' THEN 'Division'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'PR' THEN 'Product'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'CM' THEN 'Campaign'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'JO' THEN 'Job'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'JC' THEN 'Job Component'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'ES' THEN 'Estimate'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'EST' THEN 'Estimate'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'PS' THEN 'Schedule'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'PST' THEN 'Schedule Task'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'PO' THEN 'Purchase Order'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'AB' THEN 'Authorization to Buy'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'AP' THEN 'Accounts Payable'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'AD' THEN 'Agency Desktop'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'AN' THEN 'Ad Number'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'ED' THEN 'Employee Desktop'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'NA' THEN 'Approval'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'VN' THEN 'Vendor'")
                            .Append(" WHEN ALERT.ALERT_LEVEL = 'CT' THEN 'Contract'")
                            .Append(" ELSE ''")
                            .Append(" END AS ALERT_LEVEL_TEXT,")
                            .Append(" ALERT.TIME_DUE,")
                            .Append(" JOB_LOG.JOB_DESC,")
                            .Append(" JOB_COMPONENT.JOB_COMP_DESC,")

                        End If

                        .Append(" ALERT.IS_DRAFT,")

                        If IsCount = False Then

                            If ExcludeBothAlertRcptTables = False Then

                                If IncludeTasks = True Then

                                    .Append(String.Format(" CASE WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 THEN JTE.CARD_SEQ_NBR ELSE {0}.CARD_SEQ_NBR END AS CARD_SEQ_NBR,", RecipientTableName))

                                Else

                                    .Append(String.Format(" {0}.CARD_SEQ_NBR,", RecipientTableName))

                                End If

                            Else

                                .Append(" 0 AS CARD_SEQ_NBR,")

                            End If

                            If InboxType = "dismissed" Then

                                .Append(" 1 AS IS_DISMISSED,")

                            Else

                                .Append(" 0 AS IS_DISMISSED,")

                            End If

                            .Append(" ISNULL(ALERT.IS_CS_REVIEW, 0) AS IS_CS_REVIEW,")
                            .Append(" ISNULL(ALERT.CS_PROJECT_ID, 0) AS CS_PROJECT_ID,")
                            .Append(" ISNULL(ALERT.CS_REVIEW_ID, 0) AS CS_REVIEW_ID,")
                            .Append(" ISNULL(ALERT.CS_NUM_REVIEWER, 0) AS CS_NUM_REVIEWER,")
                            .Append(" ISNULL(ALERT.CS_NUM_CMPLT, 0) AS CS_NUM_CMPLT,")
                            .Append(" CAST(ALERT.CS_ASSET_IMG AS VARBINARY(MAX)) AS CS_ASSET_IMG,")
                            .Append(" ISNULL(ALERT.CS_NUM_REJECT, 0) AS CS_NUM_REJECT,")
                            .Append(" ISNULL(ALERT.CS_NUM_DEFER, 0) AS CS_NUM_DEFER,")
                            .Append(" ISNULL(ALERT.CS_NUM_APPR, 0) AS CS_NUM_APPR,")

                        End If

                        If ExcludeBothAlertRcptTables = False Then

                            .Append(String.Format(" {0}.CURRENT_RCPT,", RecipientTableName))

                        Else

                            .Append(" 0 AS CURRENT_RCPT,")

                        End If

                        If IsCount = False Then

                            .Append("ISNULL(SD.SPRINT_HDR_ID, 0) AS SPRINT_ID,")

                            If IncludeTasks = True Then

                                .Append("CASE WHEN ALERT_CATEGORY.ALERT_CAT_ID = 71 THEN ISNULL(JTD.TASK_STATUS,'P') ELSE NULL END AS TASK_STATUS,")
                                .Append("ISNULL(CAST(JTD.FNC_COMMENTS AS VARCHAR(MAX)),'') AS FNC_COMMENTS,")
                                .Append("JTE.TEMP_COMP_DATE,")

                            Else

                                .Append("NULL AS TASK_STATUS,")
                                .Append("ISNULL(CAST(JTD.FNC_COMMENTS AS VARCHAR(MAX)),'') AS FNC_COMMENTS,")
                                .Append("NULL AS TEMP_COMP_DATE,")

                            End If

                            .Append("ISNULL((SELECT COUNT(1) AS TOTAL_ITEMS FROM CHECKLIST_DTL CD WITH (NOLOCK) INNER JOIN CHECKLIST_HDR CH WITH (NOLOCK) ON CD.CHECKLIST_HDR_ID = CH.ID WHERE CH.ALERT_ID = ALERT.ALERT_ID GROUP BY ALERT_ID),0) AS CHECK_LIST_TOTAL,")
                            .Append("ISNULL((SELECT COUNT(1) AS TOTAL_ITEMS FROM CHECKLIST_DTL CD WITH (NOLOCK) INNER JOIN CHECKLIST_HDR CH WITH (NOLOCK) ON CD.CHECKLIST_HDR_ID = CH.ID WHERE CH.ALERT_ID = ALERT.ALERT_ID AND CD.IS_CHECKED = 1 GROUP BY ALERT_ID),0) AS CHECK_LIST_COMPLETE,")
                            .Append("JOB_COMPONENT.ESTIMATE_NUMBER, JOB_COMPONENT.EST_COMPONENT_NBR,")

                        End If

                        ''  INNER MOST QUERY SELECT ENDS
                        .Append(" NULL AS END_SELECT_CLAUSE")

                        .Append(" FROM  ALERT WITH (NOLOCK)")
                        .Append(" INNER JOIN ALERT_TYPE WITH (NOLOCK) ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID")
                        .Append(" INNER JOIN ALERT_CATEGORY WITH (NOLOCK) ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID")
                        .Append(" LEFT OUTER JOIN CLIENT WITH (NOLOCK) ON ALERT.CL_CODE = CLIENT.CL_CODE")
                        .Append(" LEFT OUTER JOIN SOFTWARE_VERSION SV WITH (NOLOCK) ON ALERT.VER = SV.VERSION_ID")
                        .Append(" LEFT OUTER JOIN SOFTWARE_BUILD SB WITH (NOLOCK) ON ALERT.BUILD = SB.BUILD_ID")
                        .Append(" LEFT OUTER JOIN SPRINT_DTL SD WITH (NOLOCK) ON SD.ALERT_ID = ALERT.ALERT_ID")

                        If IncludeTasks = True Then

                            .Append(" LEFT OUTER JOIN JOB_TRAFFIC_DET_EMPS JTE WITH (NOLOCK) ON ALERT.JOB_NUMBER = JTE.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTE.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTE.SEQ_NBR AND ALERT.ALERT_CAT_ID = 71")
                            .Append(" LEFT OUTER JOIN JOB_TRAFFIC_DET JTD WITH (NOLOCK) ON ALERT.JOB_NUMBER = JTD.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTD.SEQ_NBR")
                            .Append(" LEFT OUTER JOIN JOB_TRAFFIC JT WITH (NOLOCK) ON ALERT.JOB_NUMBER = JT.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR")

                        Else

                            .Append(" LEFT OUTER JOIN JOB_TRAFFIC_DET JTD WITH (NOLOCK) ON ALERT.JOB_NUMBER = JTD.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTD.SEQ_NBR")

                        End If

                        If ExcludeBothAlertRcptTables = False Then

                            If ShowAssignmentType <> "unassigned" Then

                                .Append(" LEFT OUTER JOIN EMPLOYEE WITH (NOLOCK)")
                                HasEmployeeJoin = True

                                .Append(String.Format(" LEFT OUTER JOIN {0} WITH (NOLOCK)", RecipientTableName))
                                .Append(String.Format(" ON  EMPLOYEE.EMP_CODE = {0}.EMP_CODE", RecipientTableName))
                                .Append(String.Format(" ON ALERT.ALERT_ID = {0}.ALERT_ID", RecipientTableName))

                            Else

                                If ShowAssignmentType = "unassigned" Then

                                    .Append(" LEFT OUTER JOIN ")

                                Else

                                    .Append(" INNER JOIN ")

                                End If

                                .Append(RecipientTableName)
                                .Append(String.Format(" ON ALERT.ALERT_ID = {0}.ALERT_ID", RecipientTableName))

                            End If

                        End If

                        If ShowAssignmentType = "allalertassignments" AndAlso InboxType <> "drafts" AndAlso HasEmployeeJoin = True Then

                            If AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, ThisEmployeeCode).Any Then

                                .Append(" INNER JOIN EMP_OFFICE WITH (NOLOCK) ON EMPLOYEE.OFFICE_CODE = EMP_OFFICE.OFFICE_CODE AND EMP_OFFICE.EMP_CODE = '" & ThisEmployeeCode & "'")

                            End If

                            If AdvantageFramework.Security.Database.Procedures.UserEmployeeAccess.LoadByUserCode(SecurityDbContext, DbContext.UserCode).Any Then

                                .Append(" INNER JOIN SEC_EMP WITH (NOLOCK) ON EMPLOYEE.EMP_CODE = SEC_EMP.EMP_CODE AND SEC_EMP.USER_ID = '" & DbContext.UserCode & "'")

                            End If

                        End If

                        If GroupBy <> "CDPJ" Then

                            .Append(" LEFT OUTER JOIN JOB_LOG WITH (NOLOCK)")
                            .Append(" ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER")
                            JobLogTableIsJoined = True

                        End If
                        If GroupBy <> "CDPJC" Then

                            .Append(" LEFT OUTER JOIN JOB_COMPONENT WITH (NOLOCK)")
                            .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                            .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")
                            JobComponentTableIsJoined = True

                        End If

                        Select Case GroupBy
                            Case "O"

                                .Append(" LEFT OUTER JOIN OFFICE WITH (NOLOCK)")
                                .Append(" ON ALERT.OFFICE_CODE = OFFICE.OFFICE_CODE")

                            Case "CD"

                                .Append(" LEFT OUTER JOIN DIVISION WITH (NOLOCK)")
                                .Append(" ON ALERT.CL_CODE = DIVISION.CL_CODE")
                                .Append(" AND ALERT.DIV_CODE = DIVISION.DIV_CODE")

                            Case "CDP"

                                .Append(" LEFT OUTER JOIN PRODUCT WITH (NOLOCK)")
                                .Append(" ON ALERT.CL_CODE = PRODUCT.CL_CODE")
                                .Append(" AND ALERT.DIV_CODE = PRODUCT.DIV_CODE")
                                .Append(" AND ALERT.PRD_CODE = PRODUCT.PRD_CODE")

                            Case "CDPJ"

                                If JobLogTableIsJoined = False Then

                                    .Append(" LEFT OUTER JOIN JOB_LOG WITH (NOLOCK)")
                                    .Append(" ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER")

                                    JobLogTableIsJoined = True

                                End If

                            Case "CDPJC"

                                If JobComponentTableIsJoined = False Then

                                    .Append(" LEFT OUTER JOIN JOB_COMPONENT WITH (NOLOCK)")
                                    .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                                    .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")

                                    JobComponentTableIsJoined = True

                                End If

                            Case "CM"

                                .Append(" INNER JOIN CAMPAIGN WITH (NOLOCK)")
                                .Append(" ON ALERT.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER")

                            Case "ES"

                                .Append(" INNER JOIN ESTIMATE_LOG WITH (NOLOCK)")
                                .Append(" ON ALERT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER")

                            Case "EST"

                                .Append(" INNER JOIN ESTIMATE_COMPONENT WITH (NOLOCK)")
                                .Append(" ON ALERT.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER")
                                .Append(" AND ALERT.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR")

                            Case "ALERT_NOTIFY_NAME"

                                .Append(" INNER JOIN ALERT_NOTIFY_HDR WITH (NOLOCK)")
                                .Append(" ON ALERT.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID")

                        End Select

                        .Append(" LEFT OUTER JOIN ALERT_STATES WITH (NOLOCK) ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID ")
                        .Append(" LEFT OUTER JOIN ALERT_STATES ALS WITH (NOLOCK) ON ALERT.BOARD_STATE_ID = ALS.ALERT_STATE_ID ")

                        If GroupBy = "AB" OrElse FilterLevel = "AB" Then

                            .Append(" INNER JOIN ATB_REV WITH (NOLOCK)")
                            .Append(" ON ALERT.ATB_REV_ID = ATB_REV.ATB_REV_ID")

                        End If

                        If GroupBy = "PST" OrElse FilterLevel = "PST" Then

                            .Append(" INNER JOIN JOB_TRAFFIC_DET WITH (NOLOCK)")
                            .Append(" ON ALERT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER")
                            .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR")
                            .Append(" AND ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR")

                        End If

                        If JobComponentTableIsJoined = False AndAlso AccountExecutiveCode.Trim() <> "" Then

                            .Append(" INNER JOIN JOB_COMPONENT WITH (NOLOCK)")
                            .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                            .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")

                        End If

                        If ManagerCode.Trim() <> "" Then

                            .Append(" INNER JOIN JOB_TRAFFIC WITH (NOLOCK)")
                            .Append(" ON ALERT.JOB_NUMBER = JOB_TRAFFIC.JOB_NUMBER")
                            .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC.JOB_COMPONENT_NBR")

                        End If

                        If ShowAssignmentType = "allalertassignments" AndAlso
                                MyObjDef.EmployeeHasDynamicRestriction(ThisEmployeeCode, AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.AlertInbox_AllAssignments) = True Then

                            .Append(" INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](")
                            .Append(CType(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.AlertInbox_AllAssignments, Integer))
                            .Append(",'")
                            .Append(ThisEmployeeCode)
                            .Append("') AS DR ON DR.CL_CODE = ALERT.CL_CODE ")
                            .Append("AND ((ALERT.DIV_CODE = DR.DIV_CODE) OR (ALERT.DIV_CODE IS NULL)) ")
                            .Append("AND ((ALERT.PRD_CODE = DR.PRD_CODE) OR (ALERT.PRD_CODE IS NULL)) ")

                        End If

                        If ShowAssignmentType = "allalertassignments" AndAlso StaticRestrictionsDictionary.Count > 0 AndAlso
                                MyObjDef.ObjectHasStaticRestriction(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.AlertInbox_AllAssignments) Then

                            For Each Restriction As Generic.KeyValuePair(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition, Boolean) In StaticRestrictionsDictionary

                                Select Case Restriction.Key

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.AlertGroup

                                        .Append(" INNER JOIN JOB_COMPONENT AS JCAG WITH (NOLOCK) ON ALERT.JOB_NUMBER = JCAG.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JCAG.JOB_COMPONENT_NBR ")
                                        .Append(" INNER JOIN EMAIL_GROUP AS EG WITH (NOLOCK) ON EG.EMAIL_GR_CODE = JCAG.EMAIL_GR_CODE ")
                                        .Append(" AND (EG.INACTIVE_FLAG = 0 OR EG.INACTIVE_FLAG IS NULL) ")

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.ScheduleAssignments

                                        .Append(" INNER JOIN JOB_TRAFFIC JTASN WITH (NOLOCK) ON ALERT.JOB_NUMBER = JTASN.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTASN.JOB_COMPONENT_NBR ")

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.ScheduleManager

                                        .Append(" INNER JOIN JOB_TRAFFIC JTMGR WITH (NOLOCK) ON ALERT.JOB_NUMBER = JTMGR.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTMGR.JOB_COMPONENT_NBR ")
                                        HasManagerDBRestriction = True

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.TaskAssignees

                                        .Append(" INNER JOIN JOB_TRAFFIC AS JTTA WITH (NOLOCK) ON ALERT.JOB_NUMBER = JTTA.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTTA.JOB_COMPONENT_NBR ")
                                        .Append(" INNER JOIN JOB_TRAFFIC_DET AS JTDEMPS WITH (NOLOCK) ON JTDEMPS.JOB_NUMBER = JTTA.JOB_NUMBER ")
                                        .Append(" AND JTDEMPS.JOB_COMPONENT_NBR = JTTA.JOB_COMPONENT_NBR ")
                                        .Append(" INNER JOIN JOB_TRAFFIC_DET_EMPS AS JTDEEMPS WITH (NOLOCK) ON JTDEEMPS.JOB_NUMBER = JTDEMPS.JOB_NUMBER ")
                                        .Append(" AND JTDEEMPS.JOB_COMPONENT_NBR = JTDEMPS.JOB_COMPONENT_NBR ")
                                        .Append(" AND JTDEEMPS.SEQ_NBR = JTDEMPS.SEQ_NBR ")

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.AccountExecutive

                                        .Append(" LEFT OUTER JOIN JOB_COMPONENT AS JCAE WITH (NOLOCK) ON ALERT.JOB_NUMBER = JCAE.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JCAE.JOB_COMPONENT_NBR ")

                                End Select

                            Next

                        End If

                        Dim HasBoardJoin As Boolean = False
                        If ClientUsingBoards = True Then

                            .Append(" LEFT OUTER JOIN [dbo].[advtf_alert_inactive_work_items]() IWI ON ALERT.ALERT_ID = IWI.ALERT_ID  ")
                            HasBoardJoin = True

                        End If
                        .Append(" WHERE 1 = 1 ")

                        If IsJobAlertsPage = False And HasBoardJoin = True Then

                            .Append(" AND (IWI.ALERT_ID IS NULL) ")

                        End If

                        If IncludeBoardLevel = False Then

                            .Append(" AND ALERT.ALERT_CAT_ID <> 71 ")

                        Else

                            If ShowAssignmentType = "myalerts" Then

                                .Append(" AND (1 = CASE WHEN ALERT.ALERT_CAT_ID <> 71 THEN 1 WHEN " & IsCc & " THEN 1 ELSE 0 END) ")

                            End If

                        End If

                        If IsJobAlertsPage = True Then

                            IncludeBothAlertRcptTables = IncludeCompletedAssignments = True

                        End If

                        If InboxType = "drafts" Then

                            .Append("AND ALERT.ALERT_USER = @USER_CODE")
                            .Append(" AND ALERT.IS_DRAFT = 1")

                        Else

                            .Append(" AND (ALERT.IS_DRAFT IS NULL OR ALERT.IS_DRAFT = 0)")

                            Select Case ShowAssignmentType

                                Case "myalertassignments"

                                    EmpCode = ThisEmployeeCode

                                    '.Append(" AND (NOT(ALERT.ALERT_STATE_ID IS NULL))")
                                    .Append(" AND ALERT.IS_WORK_ITEM = 1 ")

                                    If ExcludeBothAlertRcptTables = False Then

                                        .Append(" AND (")

                                        If InboxType <> "dismissed" Then

                                            '.Append(String.Format("("))
                                            '.Append(String.Format(" (ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND {0}.CURRENT_NOTIFY = 1)", RecipientTableName))
                                            '.Append(String.Format(" OR (NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ASSIGNED_EMP_CODE = @EMP_CODE)"))
                                            '.Append(String.Format(")"))

                                            '.Append(String.Format(" AND (({0}.EMP_CODE = @EMP_CODE) OR (JTE.EMP_CODE = @EMP_CODE))", RecipientTableName))
                                            .Append(String.Format("(ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND {0}.CURRENT_NOTIFY = 1)", RecipientTableName))
                                            '.Append(String.Format("OR (NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ({0}.EMP_CODE = @EMP_CODE))", RecipientTableName))
                                            .Append(String.Format("OR (ALERT.ALERT_CAT_ID = 71 AND JTE.EMP_CODE = @EMP_CODE)"))

                                            .Append(String.Format(" OR (ALERT.ALRT_NOTIFY_HDR_ID = {0}.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = {0}.ALERT_STATE_ID AND {0}.EMP_CODE = @EMP_CODE)", RecipientTableName))

                                        Else

                                            .Append(String.Format(" (({0}.EMP_CODE = @EMP_CODE) OR (JTE.EMP_CODE = @EMP_CODE))", RecipientTableName))

                                        End If

                                        .Append(")")

                                        .Append("AND 1 = CASE WHEN ALERT.ALERT_CAT_ID <> 71 THEN 1 WHEN ALERT.ALERT_CAT_ID = 71 AND JTD.JOB_COMPLETED_DATE IS NULL AND JT.COMPLETED_DATE IS NULL AND JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12) THEN 1 ELSE 0 END")

                                        If InboxType <> "dismissed" Then

                                            .Append(String.Format(" AND (({0}.EMP_CODE = @EMP_CODE) OR (JTE.EMP_CODE = @EMP_CODE))", RecipientTableName))

                                        End If

                                    End If
                                    .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                                Case "allalertassignments"

                                    .Append(" AND ALERT.IS_WORK_ITEM = 1 ")

                                    If EmpCode <> "" And ExcludeBothAlertRcptTables = False Then

                                        .Append(" AND (")

                                        If InboxType <> "sent" Then

                                            If InboxType <> "dismissed" Then

                                                .Append(String.Format("("))
                                                .Append(String.Format(" (ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND {0}.CURRENT_NOTIFY = 1)", RecipientTableName))
                                                .Append(String.Format(" OR (NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALRT_NOTIFY_HDR_ID = {0}.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = {0}.ALERT_STATE_ID AND ({0}.EMP_CODE = @EMP_CODE))", RecipientTableName))
                                                '.Append(String.Format(" OR (NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ASSIGNED_EMP_CODE = @EMP_CODE)"))
                                                '.Append(String.Format(" OR (ALERT.ASSIGNED_EMP_CODE IS NULL AND {0}.EMP_CODE = @EMP_CODE)", RecipientTableName))
                                                .Append(String.Format(")"))

                                                .Append(String.Format(" AND (({0}.EMP_CODE = @EMP_CODE) OR (JTE.EMP_CODE = @EMP_CODE))", RecipientTableName))


                                            Else

                                                .Append(String.Format(" (({0}.EMP_CODE = @EMP_CODE) OR (JTE.EMP_CODE = @EMP_CODE))", RecipientTableName))

                                            End If

                                        Else

                                            .Append(String.Format(" ({0}.CURRENT_NOTIFY = 1)", RecipientTableName))

                                        End If

                                        .Append(")")

                                    End If
                                    .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                                Case "unassigned"

                                    '.Append(" AND (NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL) AND (NOT ALERT.ALERT_STATE_ID IS NULL) AND (ALERT.ASSIGNED_EMP_CODE IS NULL)")
                                    .Append(" AND (ALERT.IS_WORK_ITEM = 1)")
                                    .Append(" AND (((SELECT COUNT(1) FROM ALERT_RCPT WHERE ALERT_ID = ALERT.ALERT_ID AND CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL) + (SELECT COUNT(1) FROM ALERT_RCPT_DISMISSED WHERE ALERT_ID = ALERT.ALERT_ID AND CURRENT_NOTIFY = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL)) = 0)")
                                    .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                                Case "myalerts"

                                    If IsJobAlertsPage = False And EmpCode <> "" And InboxType <> "sent" And ExcludeBothAlertRcptTables = False Then

                                        .Append(String.Format(" AND ({0}.EMP_CODE = @EMP_CODE)", RecipientTableName))

                                    End If

                                    If IncludeReviews = False Then .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                                Case "myalertsandassignments"

                                    If String.IsNullOrWhiteSpace(EmpCode) = False Then

                                        If IsJobAlertsPage = False AndAlso InboxType <> "sent" AndAlso ExcludeBothAlertRcptTables = False Then

                                            .Append(String.Format(" AND (({0}.EMP_CODE = @EMP_CODE AND ({0}.CURRENT_RCPT IS NULL OR {0}.CURRENT_RCPT = 0) AND (JTE.EMP_CODE IS NULL OR JTE.EMP_CODE <> @EMP_CODE)) OR (JTE.EMP_CODE = @EMP_CODE AND JTD.JOB_COMPLETED_DATE IS NULL AND JT.COMPLETED_DATE IS NULL AND JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (6, 12) AND ({0}.CURRENT_RCPT IS NULL OR {0}.CURRENT_RCPT = 0)))", RecipientTableName))

                                            If InboxType <> "dismissed" Then

                                                .Append(String.Format(" AND 1 = CASE"))
                                                .Append(String.Format("                      WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND {0}.EMP_CODE = @EMP_CODE AND {0}.ALRT_NOTIFY_HDR_ID IS NULL AND {0}.ALERT_STATE_ID IS NULL AND ((({0}.CURRENT_NOTIFY IS NULL OR {0}.CURRENT_NOTIFY = 0) AND ({0}.CURRENT_RCPT IS NULL OR {0}.CURRENT_RCPT = 0))) THEN 1 ", RecipientTableName))
                                                .Append(String.Format("                      WHEN NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND {0}.EMP_CODE <> @EMP_CODE AND ({0}.CURRENT_NOTIFY IS NULL OR {0}.CURRENT_NOTIFY = 0) AND ({0}.CURRENT_RCPT IS NULL OR {0}.CURRENT_RCPT = 0) THEN 1 ", RecipientTableName))
                                                .Append(String.Format("                      WHEN (ALERT.IS_WORK_ITEM IS NULL OR ALERT.IS_WORK_ITEM = 0) AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALERT_STATE_ID IS NULL AND {0}.EMP_CODE = @EMP_CODE AND ({0}.CURRENT_NOTIFY IS NULL OR {0}.CURRENT_NOTIFY = 0) AND ({0}.CURRENT_RCPT IS NULL OR {0}.CURRENT_RCPT = 0) THEN 1 ", RecipientTableName))
                                                .Append(String.Format("                      WHEN ALERT.IS_WORK_ITEM = 1 AND ALERT.ALRT_NOTIFY_HDR_ID IS NULL AND ALERT.ALERT_STATE_ID IS NULL AND (({0}.EMP_CODE = @EMP_CODE AND ({0}.CURRENT_RCPT IS NULL OR {0}.CURRENT_RCPT = 0)) OR (JTE.EMP_CODE = @EMP_CODE)) THEN 1 ", RecipientTableName))

                                                .Append(String.Format("                      WHEN (ALERT.ALRT_NOTIFY_HDR_ID = {0}.ALRT_NOTIFY_HDR_ID AND ALERT.ALERT_STATE_ID = {0}.ALERT_STATE_ID AND {0}.EMP_CODE = @EMP_CODE) THEN 1 ", RecipientTableName))


                                                .Append(String.Format("				ELSE 0"))
                                                .Append(String.Format("		    END "))

                                            End If

                                        End If


                                    End If

                                    EmpCode = ThisEmployeeCode
                                    If IncludeReviews = False Then .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                                Case "myreviews"

                                    If IsJobAlertsPage = False And EmpCode <> "" And InboxType <> "sent" And ExcludeBothAlertRcptTables = False Then

                                        .Append(String.Format(" AND ({0}.EMP_CODE = @EMP_CODE)", RecipientTableName))

                                    End If

                                    '(ALERT.ALERT_TYPE_ID = 15 AND ( ALERT.IS_CS_REVIEW = 1 )) INCLUDES "Reviews" for ConceptShare
                                    .Append(" AND ((ALERT.ALERT_TYPE_ID = 15 AND ( ALERT.IS_CS_REVIEW = 1 )) ")

                                    'Adding the additional OR (ALERT.ALERT_TYPE_ID = 6 AND ALERT.ALERT_CAT_ID = 79) will 
                                    'pickup the New Proofing Tool "Proofs"
                                    .Append(" OR (ALERT.ALERT_TYPE_ID = 6 And ALERT.ALERT_CAT_ID = 79)) ")

                                    EmpCode = ThisEmployeeCode


                            End Select

                        End If

                        If IsJobAlertsPage = False Then

                            'If ExcludeBothAlertRcptTables = False And GroupBy = "NEW_UNREAD" Then

                            '    .Append(String.Format(" AND ( ({0}.READ_ALERT IS NULL) OR ({0}.NEW_ALERT = 1) )", RecipientTableName))

                            'End If

                            Select Case InboxType
                                Case "sent"

                                    If EmpCode <> "" Then

                                        .Append(" AND (ALERT.EMP_CODE = @EMP_CODE)")

                                    End If

                                Case "action"

                                    .Append(" AND (ALERT.ALERT_CAT_ID = 33)")

                                Case "discussion"

                                    .Append(" AND (ALERT.ALERT_CAT_ID = 26)")

                                Case "event"

                                    .Append(" AND (ALERT.ALERT_CAT_ID = 24)")

                                Case "review"

                                    .Append(" AND (ALERT.ALERT_CAT_ID = 27)")

                                Case "issue"

                                    .Append(" AND (ALERT.ALERT_CAT_ID = 47)")

                            End Select

                        Else

                            If IncludeCompletedAssignments = False Then

                                IncludeBothAlertRcptTables = False

                            End If

                        End If

                        Select Case FilterLevel
                            Case "OF"

                                If OfficeCode.Trim() <> "" Then .Append(" AND (ALERT.OFFICE_CODE = @OFFICE_CODE)")

                            Case "CL"

                                If ClCode.Trim() <> "" Then .Append(" AND (ALERT.CL_CODE = @CL_CODE)")

                            Case "DI"

                                If ClCode.Trim() <> "" Then .Append(" AND (ALERT.CL_CODE = @CL_CODE)")
                                If DivCode.Trim() <> "" Then .Append(" AND (ALERT.DIV_CODE = @DIV_CODE)")

                            Case "PR"

                                If ClCode.Trim() <> "" Then .Append(" AND (ALERT.CL_CODE = @CL_CODE)")
                                If DivCode.Trim() <> "" Then .Append(" AND (ALERT.DIV_CODE = @DIV_CODE)")
                                If PrdCode.Trim() <> "" Then .Append(" AND (ALERT.PRD_CODE = @PRD_CODE)")

                            Case "CM"

                                If ClCode.Trim() <> "" Then .Append(" AND (ALERT.CL_CODE = @CL_CODE)")
                                If DivCode.Trim() <> "" Then .Append(" AND (ALERT.DIV_CODE = @DIV_CODE)")
                                If PrdCode.Trim() <> "" Then .Append(" AND (ALERT.PRD_CODE = @PRD_CODE)")
                                If CmpCode.Trim() <> "" Then .Append(" AND (ALERT.CMP_CODE = @CMP_CODE)")

                            Case "JO"

                                If JobNumber > 0 Then .Append(" AND (ALERT.JOB_NUMBER = @JOB_NUMBER)")

                            Case "JC"

                                If JobNumber > 0 AndAlso JobComponentNbr > 0 Then

                                    .Append(" AND (")
                                    .Append("   (ALERT.JOB_NUMBER = @JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)")
                                    .Append("   OR (ALERT.JOB_COMPONENT_NBR IS NULL AND ALERT.ALERT_LEVEL IN ('JO','J') AND ALERT.JOB_NUMBER = @JOB_NUMBER)")
                                    .Append(")")

                                End If

                            Case "VN"

                                If VnCode.Trim() <> "" Then .Append(" AND (ALERT.VN_CODE = @VN_CODE)")

                            Case "DO"

                                If AlertLevel.Trim() <> "" Then .Append(" AND (ALERT.ALERT_LEVEL = @ALERT_LEVEL)") ' should be either AD or ED

                            Case "ES"

                                If EstimateNumber > 0 Then .Append(" AND (ALERT.ESTIMATE_NUMBER = @ESTIMATE_NUMBER)")

                            Case "EST"

                                If EstimateNumber > 0 Then .Append(" AND (ALERT.ESTIMATE_NUMBER = @ESTIMATE_NUMBER)")
                                If EstComponentNbr > 0 Then .Append(" AND (ALERT.EST_COMPONENT_NBR = @EST_COMPONENT_NBR)")

                            Case "PST"

                                If JobNumber > 0 Then .Append(" AND (ALERT.JOB_NUMBER = @JOB_NUMBER)")
                                If JobComponentNbr > 0 Then .Append(" AND (ALERT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)")

                                If TaskCode.Trim() <> "" And TaskDescription.Trim() <> "" Then

                                    .Append(" AND (JOB_TRAFFIC_DET.FNC_CODE = @TASK_FNC_CODE)")

                                ElseIf TaskCode.Trim() = "" And TaskDescription.Trim() <> "" Then

                                    .Append(" AND (UPPER(JOB_TRAFFIC_DET.TASK_DESCRIPTION) LIKE '%' + UPPER(@TASK_FNC_DESC) + '%')")

                                ElseIf TaskCode.Trim() <> "" And TaskDescription.Trim() = "" Then

                                    .Append(" AND (JOB_TRAFFIC_DET.FNC_CODE = @TASK_FNC_CODE)")

                                End If

                            Case "ID"

                                If AlertAssignmentSeqNbr > 0 Then .Append(" AND (COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) = @ID)")

                            Case "ALRT_NOTIFY_HDR"

                                If AlrtNotifyHdrId > 0 Then .Append(" AND (ALERT.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID)")

                            Case "STATE"

                                If AlrtNotifyHdrId > 0 Then .Append(" AND (ALERT.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID)")
                                If StateId > 0 Then .Append(" AND (ALERT.ALERT_STATE_ID = @ALERT_STATE_ID)")

                            Case "AB"

                                If ATBNumber > 0 Then .Append(" AND (ATB_REV.ATB_NUMBER = @ATB_NUMBER)")

                        End Select

                        'Select Case GroupBy

                        '    Case "DUE_DATE", "DUE_DATE_ASC"

                        '        .Append(" AND (NOT (DUE_DATE IS NULL))")

                        'End Select

                        If AlertTypeId > 0 Then .Append(" AND (ALERT.ALERT_TYPE_ID = @ALERT_TYPE_ID)")
                        If AlertCategoryId > 0 Then .Append(" AND (ALERT.ALERT_CAT_ID = @ALERT_CAT_ID)")
                        If AccountExecutiveCode.Trim() <> "" Then .Append(" AND (JOB_COMPONENT.EMP_CODE = @AE_CODE)")

                        If ManagerCode.Trim() <> "" Then

                            Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                                .Append(String.Format(" AND (JOB_TRAFFIC.{0} = @MGR_CODE)", AdvantageFramework.ProjectSchedule.LoadProjectScheduleManageColumnForAlertFilter(DataContext)))

                            End Using

                        End If

                        DateStart = Today
                        DateEnd = Today

                        If InboxType <> "drafts" Then

                            Try

                                If StartDate.Trim() <> "" Then ' andalso cGlobals.wvIsDate(StartDate.Trim()) = True Then

                                    DateTime.TryParse(StartDate.Trim, DateStart)

                                Else

                                    DateStart = Nothing

                                End If

                            Catch ex As Exception
                                DateStart = Nothing
                            End Try

                            Try

                                If EndDate.Trim() <> "" Then ' AndAlso cGlobals.wvIsDate(EndDate.Trim()) = True Then

                                    DateTime.TryParse(CDate(EndDate.Trim()).ToShortDateString() & " 11:59 PM", DateEnd)

                                Else

                                    DateEnd = Nothing

                                End If

                            Catch ex As Exception
                                DateEnd = Nothing
                            End Try

                            If IsJobAlertsPage = False Then

                                If DateStart IsNot Nothing AndAlso DateEnd IsNot Nothing Then

                                    .Append(" AND (ALERT.LAST_UPDATED BETWEEN @START_DATE AND @END_DATE)")

                                ElseIf DateStart Is Nothing AndAlso DateEnd IsNot Nothing Then

                                    .Append(" AND (ALERT.LAST_UPDATED  <= @END_DATE)")

                                ElseIf DateStart IsNot Nothing AndAlso DateEnd Is Nothing Then

                                    .Append(" AND (ALERT.LAST_UPDATED >= @START_DATE)")

                                End If

                            End If

                        End If

                        'If IncludeTasks = True Then

                        '    If String.IsNullOrWhiteSpace(TaskStatus) = False Then

                        '        Select Case TaskStatus.Trim.ToUpper
                        '            Case "ACTIVE", "A"

                        '                .Append("AND ((TASK_STATUS IS NULL AND JTD.JOB_NUMBER IS NULL) OR (JTD.TASK_STATUS = 'A' OR JTD.TASK_STATUS = 'H' OR JTD.TASK_STATUS = 'L'))")

                        '            Case "PROJECTED", "P"

                        '                .Append(" AND (TASK_STATUS IS NULL AND JTD.JOB_NUMBER IS NULL) OR (JTD.TASK_STATUS = 'P')")

                        '            Case "H"

                        '                .Append(" AND (TASK_STATUS IS NULL AND JTD.JOB_NUMBER IS NULL) OR (JTD.TASK_STATUS = 'H')")

                        '            Case "L"

                        '                .Append(" AND (TASK_STATUS IS NULL AND JTD.JOB_NUMBER IS NULL) OR (JTD.TASK_STATUS = 'L')")

                        '        End Select


                        '    End If
                        '    If String.IsNullOrWhiteSpace(TaskShow) = False AndAlso TaskShow.ToLower = "true" Then

                        '        .Append(" AND (")
                        '        .Append(" (ALERT.ALERT_LEVEL = 'BRD' AND ((JTD.TASK_START_DATE IS NULL) OR (NOT JTD.TASK_START_DATE IS NULL AND JTD.TASK_START_DATE <= GETDATE()))     )")
                        '        .Append(" OR  (ALERT.ALERT_LEVEL <> 'BRD' AND ((ALERT.START_DATE IS NULL) OR (NOT ALERT.START_DATE IS NULL AND ALERT.DUE_DATE <= GETDATE()))   )")
                        '        .Append(" )")

                        '    End If
                        '    If String.IsNullOrWhiteSpace(TaskOnlyStartDue) = False AndAlso TaskOnlyStartDue.ToLower = "true" Then

                        '        .Append(" AND ((ALERT.ALERT_LEVEL = 'BRD' AND NOT JTD.TASK_START_DATE IS NULL AND NOT JTD.JOB_DUE_DATE IS NULL)")
                        '        .Append(" OR (ALERT.ALERT_LEVEL <> 'BRD' AND NOT ALERT.START_DATE IS NULL AND NOT ALERT.DUE_DATE IS NULL))")

                        '    End If

                        'End If

                        If ShowAssignmentType <> "myalertsandassignments" AndAlso ShowAssignmentType <> "myalerts" AndAlso GroupBy = "STATE" Then

                            '.Append(" AND (NOT COALESCE(ALERT.ALERT_STATE_ID, ALERT.BOARD_STATE_ID, NULL) IS NULL) ")

                        End If

                        If SearchCriteria.Trim() <> "" Then

                            .Append(" AND (")
                            .Append(" (UPPER(ALERT.[SUBJECT]) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")
                            .Append(" OR (UPPER(ALERT.ALERT_USER) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")
                            .Append(" OR (UPPER(CAST(ALERT.[BODY] AS VARCHAR)) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")

                            If IsNumeric(SearchCriteria) = True AndAlso SearchCriteria.Contains(".") = False Then

                                .Append(" OR (ALERT.JOB_NUMBER = CAST(@SEARCH_CRITERIA AS BIGINT))")
                                .Append(" OR (COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) = CAST(@SEARCH_CRITERIA AS BIGINT))")

                            End If

                            .Append(")")

                        End If

                        If ShowAssignmentType = "allalertassignments" AndAlso StaticRestrictionsDictionary.Count > 0 AndAlso
                                MyObjDef.ObjectHasStaticRestriction(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.AlertInbox_AllAssignments) Then

                            .Append(" AND ( ")

                            For Each Restriction As Generic.KeyValuePair(Of AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition, Boolean) In StaticRestrictionsDictionary

                                Select Case Restriction.Key

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.AlertGroup

                                        If NeedsOr = True Then .Append(" OR ")

                                        .Append(" (EG.EMP_CODE = '" & ThisEmployeeCode & "') ")

                                        NeedsOr = True

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.ScheduleAssignments

                                        If NeedsOr = True Then .Append(" OR ")

                                        .Append(" (")
                                        .Append(String.Format(" JTASN.ASSIGN_1 ='{0}'", ThisEmployeeCode))
                                        .Append(String.Format(" OR JTASN.ASSIGN_2 ='{0}'", ThisEmployeeCode))
                                        .Append(String.Format(" OR JTASN.ASSIGN_3 ='{0}'", ThisEmployeeCode))
                                        .Append(String.Format(" OR JTASN.ASSIGN_4 ='{0}'", ThisEmployeeCode))
                                        .Append(String.Format(" OR JTASN.ASSIGN_5 ='{0}'", ThisEmployeeCode))
                                        .Append(")")

                                        NeedsOr = True

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.ScheduleManager

                                        If NeedsOr = True Then .Append(" OR ")

                                        Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                                            .Append(String.Format(" (JTMGR.{0} = '{1}') ", AdvantageFramework.ProjectSchedule.LoadProjectScheduleManageColumnForAlertFilter(DataContext), ThisEmployeeCode))

                                        End Using

                                        NeedsOr = True

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.TaskAssignees

                                        If NeedsOr = True Then .Append(" OR ")

                                        .Append(String.Format(" (JTDEEMPS.EMP_CODE = '{0}') ", ThisEmployeeCode))

                                        NeedsOr = True

                                    Case AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.StaticDefinition.AccountExecutive

                                        If NeedsOr = True Then .Append(" OR ")

                                        .Append(String.Format(" ((JCAE.EMP_CODE = '{0}') OR (JCAE.EMP_CODE IS NULL)) ", ThisEmployeeCode))

                                        NeedsOr = True

                                End Select

                            Next

                            .Append(" ) ")

                        End If

                        If IsJobAlertsPage = False Then

                            If (InboxType.Trim().ToLower() = "dismissed" And ShowAssignmentType = "unassigned") Or
                       (InboxType.Trim().ToLower() = "received" And ShowAssignmentType = "unassigned") Then

                                .Append(" AND 0 = 1")

                            End If

                        End If

                        .Append(") AS A")

                        ''INNER MOST QUERY (ABOVE) ENDS

                        If ShowAssignmentType = "allalertassignments" Then

                            .Append(" WHERE 1 = 1")
                            .Append(" AND (A.IS_CC = 0) ")

                            If StaticRestrictionsDictionary.Count > 0 OrElse
                                MyObjDef.EmployeeHasDynamicRestriction(ThisEmployeeCode, AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.AlertInbox_AllAssignments) = True Then

                                .Append(" AND (NOT A.CURRENT_NOTIFY_EMP_CODE IS NULL) ")

                            End If

                        End If

                    End With

                    SqlParameters = New Generic.List(Of System.Data.SqlClient.SqlParameter)

                    EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

                    If Not String.IsNullOrWhiteSpace(EmpCode) Then

                        EmployeeCodeSqlParameter.Value = EmpCode.Trim()

                    Else

                        EmployeeCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    OfficeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 4)

                    If Not String.IsNullOrWhiteSpace(OfficeCode) Then

                        OfficeCodeSqlParameter.Value = OfficeCode.Trim()

                    Else

                        OfficeCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    ClientCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)

                    If Not String.IsNullOrWhiteSpace(ClCode) Then

                        ClientCodeSqlParameter.Value = ClCode.Trim()

                    Else

                        ClientCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    DivisionCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)

                    If Not String.IsNullOrWhiteSpace(DivCode) Then

                        DivisionCodeSqlParameter.Value = DivCode.Trim()

                    Else

                        DivisionCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    ProductCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)

                    If Not String.IsNullOrWhiteSpace(PrdCode) Then

                        ProductCodeSqlParameter.Value = PrdCode.Trim()

                    Else

                        ProductCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    CampaignCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@CMP_CODE", SqlDbType.VarChar, 6)

                    If Not String.IsNullOrWhiteSpace(CmpCode) Then

                        CampaignCodeSqlParameter.Value = CmpCode.Trim()

                    Else

                        CampaignCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)

                    If JobNumber > 0 Then

                        JobNumberSqlParameter.Value = JobNumber

                    Else

                        JobNumberSqlParameter.Value = System.DBNull.Value

                    End If

                    JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)

                    If JobComponentNbr > 0 Then

                        JobComponentNumberSqlParameter.Value = JobComponentNbr

                    Else

                        JobComponentNumberSqlParameter.Value = System.DBNull.Value

                    End If

                    AlertTypeIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_TYPE_ID", SqlDbType.Int)

                    If AlertTypeId > 0 Then

                        AlertTypeIDSqlParameter.Value = AlertTypeId

                    Else

                        AlertTypeIDSqlParameter.Value = System.DBNull.Value

                    End If

                    AlertCategoryIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_CAT_ID", SqlDbType.Int)

                    If AlertCategoryId > 0 Then

                        AlertCategoryIDSqlParameter.Value = AlertCategoryId

                    Else

                        AlertCategoryIDSqlParameter.Value = System.DBNull.Value

                    End If

                    StartDateSqlParameter = New System.Data.SqlClient.SqlParameter("@START_DATE", SqlDbType.SmallDateTime)

                    If DateStart IsNot Nothing Then

                        StartDateSqlParameter.Value = DateStart

                    Else

                        StartDateSqlParameter.Value = System.DBNull.Value

                    End If

                    EndDateSqlParameter = New System.Data.SqlClient.SqlParameter("@END_DATE", SqlDbType.SmallDateTime)

                    If DateEnd IsNot Nothing Then

                        EndDateSqlParameter.Value = DateEnd

                    Else

                        EndDateSqlParameter.Value = System.DBNull.Value

                    End If

                    AlertLevelSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_LEVEL", SqlDbType.VarChar, 50)

                    If Not String.IsNullOrWhiteSpace(AlertLevel) Then

                        AlertLevelSqlParameter.Value = AlertLevel.Trim()

                    Else

                        AlertLevelSqlParameter.Value = System.DBNull.Value

                    End If

                    VendorCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@VN_CODE", SqlDbType.VarChar, 6)

                    If Not String.IsNullOrWhiteSpace(VnCode) Then

                        VendorCodeSqlParameter.Value = VnCode.Trim()

                    Else

                        VendorCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    EstimateNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)

                    If EstimateNumber > 0 Then

                        EstimateNumberSqlParameter.Value = EstimateNumber

                    Else

                        EstimateNumberSqlParameter.Value = System.DBNull.Value

                    End If

                    EstimateComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)

                    If EstComponentNbr > 0 Then

                        EstimateComponentNumberSqlParameter.Value = EstComponentNbr

                    Else

                        EstimateComponentNumberSqlParameter.Value = System.DBNull.Value

                    End If

                    TaskFunctionCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@TASK_FNC_CODE", SqlDbType.VarChar, 10)

                    If Not String.IsNullOrWhiteSpace(TaskCode) Then

                        TaskFunctionCodeSqlParameter.Value = TaskCode.Trim()

                    Else

                        TaskFunctionCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    TaskFunctionDescriptionSqlParameter = New System.Data.SqlClient.SqlParameter("@TASK_FNC_DESC", SqlDbType.VarChar, 40)

                    If Not String.IsNullOrWhiteSpace(TaskDescription) Then

                        TaskFunctionDescriptionSqlParameter.Value = TaskDescription.Trim()

                    Else

                        TaskFunctionDescriptionSqlParameter.Value = System.DBNull.Value

                    End If


                    AlertNotifyNameSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_NOTIFY_NAME", SqlDbType.VarChar, 100)

                    If Not String.IsNullOrWhiteSpace(AlertNotifyName) Then

                        AlertNotifyNameSqlParameter.Value = AlertNotifyName.Trim()

                    Else

                        AlertNotifyNameSqlParameter.Value = System.DBNull.Value

                    End If

                    IDSqlParameter = New System.Data.SqlClient.SqlParameter("@ID", SqlDbType.Int)

                    If AlertAssignmentSeqNbr > 0 Then

                        IDSqlParameter.Value = AlertAssignmentSeqNbr

                    Else

                        IDSqlParameter.Value = System.DBNull.Value

                    End If

                    AlertNotifyHeaderIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)

                    If AlrtNotifyHdrId > 0 Then

                        AlertNotifyHeaderIDSqlParameter.Value = AlrtNotifyHdrId

                    Else

                        AlertNotifyHeaderIDSqlParameter.Value = System.DBNull.Value

                    End If

                    SearchCriteriaSqlParameter = New System.Data.SqlClient.SqlParameter("@SEARCH_CRITERIA", SqlDbType.VarChar, 1000)

                    If Not String.IsNullOrWhiteSpace(SearchCriteria) Then

                        SearchCriteriaSqlParameter.Value = SearchCriteria.Trim()

                    Else

                        SearchCriteriaSqlParameter.Value = System.DBNull.Value

                    End If

                    AlertStateIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_STATE_ID", SqlDbType.Int)

                    If StateId > 0 Then

                        AlertStateIDSqlParameter.Value = StateId

                    Else

                        AlertStateIDSqlParameter.Value = System.DBNull.Value

                    End If

                    AccountExecutiveCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@AE_CODE", SqlDbType.VarChar, 6)

                    If Not String.IsNullOrWhiteSpace(AccountExecutiveCode) Then

                        AccountExecutiveCodeSqlParameter.Value = AccountExecutiveCode.Trim()

                    Else

                        AccountExecutiveCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    ManagerCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@MGR_CODE", SqlDbType.VarChar, 6)

                    If Not String.IsNullOrWhiteSpace(ManagerCode) Then

                        ManagerCodeSqlParameter.Value = ManagerCode.Trim()

                    Else

                        ManagerCodeSqlParameter.Value = System.DBNull.Value

                    End If

                    ATBNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@ATB_NUMBER", SqlDbType.Int)

                    If ATBNumber > 0 Then

                        ATBNumberSqlParameter.Value = ATBNumber

                    Else

                        ATBNumberSqlParameter.Value = System.DBNull.Value

                    End If

                    UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                    UserCodeSqlParameter.Value = DbContext.UserCode

                    SqlParameters.Add(EmployeeCodeSqlParameter)
                    SqlParameters.Add(OfficeCodeSqlParameter)
                    SqlParameters.Add(ClientCodeSqlParameter)
                    SqlParameters.Add(DivisionCodeSqlParameter)
                    SqlParameters.Add(ProductCodeSqlParameter)
                    SqlParameters.Add(CampaignCodeSqlParameter)
                    SqlParameters.Add(JobNumberSqlParameter)
                    SqlParameters.Add(JobComponentNumberSqlParameter)
                    SqlParameters.Add(AlertTypeIDSqlParameter)
                    SqlParameters.Add(AlertCategoryIDSqlParameter)
                    SqlParameters.Add(StartDateSqlParameter)
                    SqlParameters.Add(EndDateSqlParameter)
                    SqlParameters.Add(AlertLevelSqlParameter)
                    SqlParameters.Add(VendorCodeSqlParameter)
                    SqlParameters.Add(EstimateNumberSqlParameter)
                    SqlParameters.Add(EstimateComponentNumberSqlParameter)
                    SqlParameters.Add(TaskFunctionCodeSqlParameter)
                    SqlParameters.Add(TaskFunctionDescriptionSqlParameter)
                    SqlParameters.Add(AlertNotifyNameSqlParameter)
                    SqlParameters.Add(IDSqlParameter)
                    SqlParameters.Add(AlertNotifyHeaderIDSqlParameter)
                    SqlParameters.Add(SearchCriteriaSqlParameter)
                    SqlParameters.Add(AlertStateIDSqlParameter)
                    SqlParameters.Add(AccountExecutiveCodeSqlParameter)
                    SqlParameters.Add(ManagerCodeSqlParameter)
                    SqlParameters.Add(ATBNumberSqlParameter)
                    SqlParameters.Add(UserCodeSqlParameter)

                    SQL = StringBuilder.ToString()

                    If ShowAssignmentType = "unassigned" Then

                        IncludeBothAlertRcptTables = False

                    End If

                    If InboxType = "dismissed" Then

                        SQL.Replace("ALERT_RCPT", "ALERT_RCPT_DISMISSED")
                        IncludesDismissed = True

                    Else

                        If IncludeBothAlertRcptTables = True And IsJobAlertsPage = False Then

                            If InboxType <> "inbox" Then

                                SQL &= " UNION " & SQL.Replace("ALERT_RCPT", "ALERT_RCPT_DISMISSED")

                            Else

                                SQL &= " UNION " & SQL.Replace("ALERT_RCPT", "ALERT_RCPT_DISMISSED").Replace("0 AS IS_DISMISSED", "1 AS IS_DISMISSED")

                            End If

                            IncludesDismissed = True

                        End If

                    End If

                    SQL = SQL.Replace("ALERT___RCPT", "ALERT_RCPT").Replace("ALERT_____RCPT___DISMISSED", "ALERT_RCPT_DISMISSED").Replace("_DISMISSED_DISMISSED", "_DISMISSED")

                    If IsCount = True Then

                        SelectText = "COUNT(1) AS REC_COUNT"

                    Else

                        SelectText = ReturnFields("B", GroupBy, IsCount)

                    End If

                    If IsJobAlertsPage = True Then

                        If ShowAssignmentType = "myalerts" Then

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE IS_ASSIGNMENT = 0", SelectText, SQL)

                        ElseIf ShowAssignmentType = "myalertassignments" Then

                            If IncludeCompletedAssignments = False Then

                                IncludeCompletedAssignmentsSQL = " AND (B.CURRENT_NOTIFY_EMP_FML <> 'Completed' OR B.CURRENT_NOTIFY_EMP_FML IS NULL) "

                            End If

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE CURRENT_NOTIFY_EMP_CODE = @EMP_CODE {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                        ElseIf ShowAssignmentType = "myalertsandassignments" Then

                            If IncludeCompletedAssignments = False Then

                                IncludeCompletedAssignmentsSQL = " WHERE ((B.CURRENT_NOTIFY_EMP_FML <> 'Completed' AND B.CURRENT_NOTIFY_EMP_FML <> 'Parent') OR B.CURRENT_NOTIFY_EMP_FML IS NULL) "

                            Else

                                IncludeCompletedAssignmentsSQL = " WHERE (B.CURRENT_NOTIFY_EMP_FML <> 'Parent' OR B.CURRENT_NOTIFY_EMP_FML IS NULL) "

                            End If

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                        ElseIf ShowAssignmentType = "allalertassignments" Then

                            If IncludeCompletedAssignments = False Then

                                IncludeCompletedAssignmentsSQL = " WHERE ((B.CURRENT_NOTIFY_EMP_FML <> 'Completed' AND B.CURRENT_NOTIFY_EMP_FML <> 'Parent')  OR CURRENT_NOTIFY_EMP_FML IS NULL) "

                            Else

                                IncludeCompletedAssignmentsSQL = " WHERE (B.CURRENT_NOTIFY_EMP_FML <> 'Parent' OR B.CURRENT_NOTIFY_EMP_FML IS NULL) "

                            End If

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                        ElseIf ShowAssignmentType = "unassigned" Then

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE B.CURRENT_NOTIFY_EMP_FML = 'Unassigned'", SelectText, SQL)

                        Else

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B", SelectText, SQL)

                        End If

                    Else

                        If ShowAssignmentType = "myalerts" Then

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE (((CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0) AND (CURRENT_RCPT IS NULL OR CURRENT_RCPT = 0) ) OR (CURRENT_NOTIFY = 1 AND CURRENT_NOTIFY_EMP_CODE = @EMP_CODE AND IS_CC = 1)) ", SelectText, SQL)

                        ElseIf ShowAssignmentType <> "myalertsandassignments" AndAlso ShowAssignmentType <> "myreviews" AndAlso ShowAssignmentType <> "unassigned" AndAlso InboxType = "inbox" Then

                            If ShowAssignmentType = "allalertassignments" Then

                                SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE IS_WORK_ITEM = 1 AND ((CURRENT_NOTIFY_EMP_FML <> 'Completed' AND CURRENT_NOTIFY_EMP_FML <> 'Unassigned') OR CURRENT_NOTIFY_EMP_FML IS NULL) ", SelectText, SQL)

                            Else

                                SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE (CURRENT_NOTIFY = 1) AND IS_CC = 0 AND (CURRENT_NOTIFY_EMP_FML <> 'Completed' OR CURRENT_NOTIFY_EMP_FML IS NULL) AND (CURRENT_RCPT IS NULL OR CURRENT_RCPT = 0) ", SelectText, SQL)

                            End If

                        ElseIf ShowAssignmentType = "unassigned" Then

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE (CURRENT_NOTIFY_EMP_FML <> 'Completed' AND  CURRENT_NOTIFY_EMP_FML <> 'Multi' AND  CURRENT_NOTIFY_EMP_FML <> 'Task' AND  CURRENT_NOTIFY_EMP_FML <> 'Assigned') OR CURRENT_NOTIFY_EMP_FML IS NULL OR B.CURRENT_NOTIFY_EMP_FML = 'Unassigned' ", SelectText, SQL)

                        ElseIf ShowAssignmentType = "myalertassignments" Then

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE CURRENT_NOTIFY = 1 ", SelectText, SQL)

                            'ElseIf ShowAssignmentType = "myalertsandassignments" Then

                            '    SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE (CURRENT_NOTIFY_EMP_FML <> 'Completed' OR CURRENT_NOTIFY_EMP_FML IS NULL) ", SelectText, SQL)

                        ElseIf ShowAssignmentType = "allalertassignments" AndAlso InboxType = "dismissed" Then

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B WHERE IS_WORK_ITEM = 1 AND CURRENT_NOTIFY_EMP_FML <> 'Unassigned' AND CURRENT_NOTIFY_EMP_FML = 'Completed'", SelectText, SQL)

                        Else

                            SQL = String.Format("SELECT DISTINCT {0} FROM ({1}) AS B ", SelectText, SQL)

                        End If

                    End If

                    If IsCount = False Then

                        Dim SbSort As New System.Text.StringBuilder

                        SbSort.Append(" ORDER BY ")
                        Select Case GroupBy
                            Case "O"

                                SbSort.Append("B.GRP_OFFICE,")

                            Case "C"

                                SbSort.Append("B.GRP_CLIENT, B.DIV_CODE, B.PRD_CODE,")

                            Case "CAT"

                                SbSort.Append("B.CATEGORY,")

                            Case "CD"

                                SbSort.Append("B.GRP_DIVISION, B.PRD_CODE,")

                            Case "CDP"

                                SbSort.Append("B.GRP_PRODUCT,")

                            Case "CDPJ"

                                SbSort.Append("B.GRP_JOB ASC,")

                            Case "CDPJC"

                                SbSort.Append("B.GRP_COMPONENT ASC,")

                            Case "CM"

                                SbSort.Append("B.GRP_CAMPAIGN,")

                            Case "PST"

                                SbSort.Append("B.GRP_TASK,")

                            Case "ES"

                                SbSort.Append("B.GRP_ESTIMATE,")

                            Case "EST"

                                SbSort.Append("B.GRP_ESTIMATE_COMPONENT,")

                            Case "DUE_DATE"

                                SbSort.Append("B.DUE_DATE DESC,")

                            Case "DUE_DATE_ASC"

                                SbSort.Append("B.DUE_DATE ASC,")

                            Case "ALERT_NOTIFY_NAME"

                                SbSort.Append("B.ALERT_NOTIFY_NAME,")

                            Case "PRIORITY"

                                SbSort.Append("B.PRIORITY,")

                            Case "STATE"

                                SbSort.Append("B.ALERT_STATE_NAME,")

                            Case "AB"

                                SbSort.Append("B.GRP_ATB,")

                            Case "LAST_UPD"

                                SbSort.Append("B.GENERATED DESC,")

                            Case "VER_BLD"

                                SbSort.Append("B.[VERSION] DESC, B.BUILD ASC,")

                            Case "NEW_UNREAD"

                                SbSort.Append("B.READ_ALERT,")

                        End Select

                        If GroupBy <> "LAST_UPD" Then

                            SbSort.Append(" B.CARD_SEQ_NBR, B.GENERATED DESC OPTION (RECOMPILE);")

                        Else

                            SbSort.Append(" B.CARD_SEQ_NBR OPTION (RECOMPILE);")

                        End If

                        SQL &= SbSort.ToString()

                    Else

                        SQL &= "  OPTION (RECOMPILE);"

                    End If

                    ' For testing to copy/paste query into enterprise mgr
                    SQL = SQL.Replace(vbTab, " ").Replace(vbCrLf, " ")

                    SqlConnection = DbContext.Database.Connection
                    SqlCommand = New SqlClient.SqlCommand(SQL, SqlConnection)
                    SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

                    Using SqlCommand

                        SqlCommand.CommandType = CommandType.Text
                        SqlCommand.Parameters.AddRange(SqlParameters.ToArray)

                        DataTable = New DataTable

                        SqlDataAdapter.Fill(DataTable)

                    End Using

                    If IsCount = False Then

                        'If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                        '    Alerts = DataTable.Rows.OfType(Of DataRow).ToList.Select(Function(dr) AdvantageFramework.DTO.Desktop.Alert.FromMainAlertQuery(dr, GroupBy)).ToList

                        'End If

                        'Return Alerts

                        Return DataTable

                    Else

                        Try

                            RecordCount = CType(DataTable.Rows(0)("REC_COUNT"), Integer)
                            ErrorMessage = ""
                            Return Nothing

                        Catch ex As Exception
                            RecordCount = -1
                            ErrorMessage = ex.Message.ToString
                            If ex.InnerException IsNot Nothing AndAlso String.IsNullOrWhiteSpace(ex.InnerException.Message) = False Then
                                ErrorMessage = ErrorMessage & Environment.NewLine & ex.InnerException.Message.ToString
                            End If
                            Return Nothing
                        End Try

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                If ex.InnerException IsNot Nothing AndAlso String.IsNullOrWhiteSpace(ex.InnerException.Message) = False Then
                    ErrorMessage = ErrorMessage & Environment.NewLine & ex.InnerException.Message.ToString
                End If
                Return Nothing
            End Try

        End Function
        Public Function LoadAlertsCPAsDatable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal CPID As Integer, ByVal InboxType As String, ByVal FilterLevel As String, ByVal OfficeCode As String, ByVal ClCode As String,
                           ByVal DivCode As String, ByVal PrdCode As String, ByVal CmpIdentifier As String, ByVal CmpCode As String, ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                           ByVal AlertTypeId As String, ByVal AlertCategoryId As String, ByVal StartDate As String, ByVal EndDate As String, ByVal AlertLevel As String,
                           ByVal VnCode As String, ByVal EstimateNumber As Integer, ByVal EstComponentNbr As Integer, ByVal TaskCode As String, ByVal TaskDescription As String,
                           ByVal ShowAssignmentType As String, ByVal AlrtNotifyHdrId As Integer, ByVal AlertNotifyName As String, ByVal IncludeCompletedAssignments As Boolean,
                           ByVal IsJobAlertsPage As Boolean, ByVal AlertAssignmentSeqNbr As Integer, ByVal GroupBy As String,
                           ByVal SearchCriteria As String, ByVal RecordsToReturn As Integer, ByVal IsCount As Boolean,
                           ByRef RecordCount As Integer, ByVal IncludeReviews As Boolean, ByRef ErrorMessage As String) As DataTable
            Dim SQL As String = ""


            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim IncludeTasks As Boolean = False

            Try

                InboxType = InboxType.Trim().ToLower()
                ShowAssignmentType = ShowAssignmentType.Trim().ToLower()

                ErrorMessage = ""

                Dim DateStart As DateTime = Today
                Dim DateEnd As DateTime = Today
                Dim IncludeBothAlertRcptTables As Boolean = False
                Dim ExcludeBothAlertRcptTables As Boolean = False

                If (InboxType = "inbox" And ShowAssignmentType = "unassigned") OrElse
               (InboxType = "sent" And ShowAssignmentType = "unassigned") Then

                    ExcludeBothAlertRcptTables = True

                End If


                Dim ExcludeFieldsThatWillCauseDuplicates As Boolean = False

                If IsJobAlertsPage = True Or InboxType = "sent" Then

                    ExcludeFieldsThatWillCauseDuplicates = True

                End If

                If IsJobAlertsPage = False Then 'ignore completed

                    IncludeCompletedAssignments = False

                End If

                'If IsJobAlertsPage = True Then
                '    EmpCode = ""
                'End If

                Dim RecipientTableName As String = "CP_ALERT_RCPT"

                If IsJobAlertsPage = False AndAlso InboxType = "dismissed" Then

                    RecipientTableName = "CP_ALERT_RCPT_DISMISSED"

                End If

                If (IsJobAlertsPage = False And InboxType = "received") OrElse ShowAssignmentType <> "myalerts" Then

                    IncludeBothAlertRcptTables = True

                End If

                If InboxType = "inbox" Then

                    IncludeBothAlertRcptTables = False

                End If

                If IsJobAlertsPage = True Then

                    IncludeBothAlertRcptTables = True

                End If

                If ShowAssignmentType <> "myalerts" Then

                    IncludeTasks = True

                End If

                Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, "")

                Dim sb As New System.Text.StringBuilder
                With sb

                    .Append("SELECT ")
                    .Append(" DISTINCT ")

                    If RecordsToReturn > 0 Then

                        .Append(String.Format(" TOP {0} ", RecordsToReturn))

                    End If

                    .Append(" ALERT.ALERT_ID,")
                    .Append(" ALERT.SUBJECT,")

                    If Offset = 0 Then

                        .Append(" ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED) AS GENERATED,")

                    Else

                        .Append(String.Format(" ISNULL(DATEADD(mi, (CONVERT(INT, {0}) * 60) + ({0} - CONVERT(INT, {0})), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)), ISNULL(ALERT.LAST_UPDATED, ALERT.GENERATED)) AS GENERATED,", Offset))

                    End If

                    .Append(" CASE ")
                    .Append(" WHEN ALERT.CP_ALERT = 1 AND ")
                    .Append("   ALERT.ALERT_USER_CP IS NOT NULL THEN (")
                    .Append(" SELECT CONT_FML")
                    .Append(" FROM   CDP_CONTACT_HDR WITH (NOLOCK)")
                    .Append(" WHERE  CDP_CONTACT_ID = ALERT_USER_CP")
                    .Append("   )")
                    .Append("   ELSE (SELECT [dbo].[wvfn_alert_get_last_user_name](ALERT.ALERT_ID))")
                    .Append(" END AS USER_NAME,")
                    .Append(" ISNULL(ALERT.PRIORITY,3) AS PRIORITY,")
                    .Append(" ALERT_TYPE.ALERT_TYPE_DESC AS TYPE,")
                    .Append(" ALERT_CATEGORY.ALERT_DESC AS CATEGORY,")
                    .Append(" (")
                    .Append("   SELECT COUNT(1) AS ATTACHMENTCOUNT")
                    .Append("   FROM   ALERT_ATTACHMENT WITH (NOLOCK)")
                    .Append("   WHERE  (ALERT_ID = ALERT.ALERT_ID)")
                    .Append(" ) AS ATTACHMENTCOUNT,")
                    .Append(" ALERT.START_DATE,")
                    .Append(" ALERT.DUE_DATE,")
                    .Append(" CLIENT.CL_NAME,")

                    .Append(" ( ")
                    .Append("   SELECT SOFTWARE_VERSION.VERSION ")
                    .Append("   FROM   SOFTWARE_VERSION WITH(NOLOCK) ")
                    .Append("   WHERE  SOFTWARE_VERSION.VERSION_ID = ALERT.VER ")
                    .Append(" ) AS [VERSION], ")
                    .Append(" ( ")
                    .Append("   SELECT SOFTWARE_BUILD.BUILD ")
                    .Append("   FROM   SOFTWARE_BUILD WITH(NOLOCK) ")
                    .Append("   WHERE  SOFTWARE_BUILD.VERSION_ID = ALERT.VER ")
                    .Append(" AND SOFTWARE_BUILD.BUILD_ID = ALERT.BUILD ")
                    .Append(" ) AS [BUILD], ")

                    If GroupBy = "myalertsandassignments" Then
                        .Append(" ISNULL(ALERT_STATES.ALERT_STATE_NAME,'N/A') AS ALERT_STATE_NAME,")
                    Else
                        .Append(" ALERT_STATES.ALERT_STATE_NAME AS ALERT_STATE_NAME,")
                    End If

                    If InboxType = "drafts" Then ExcludeBothAlertRcptTables = True

                    If ExcludeBothAlertRcptTables = False Then

                        Dim MarkReadAlertForNoDuplicates As Boolean = False

                        If IsJobAlertsPage = True Or InboxType = "sent" Or ShowAssignmentType = "allalertassignments" Then

                            MarkReadAlertForNoDuplicates = True

                        End If

                        If MarkReadAlertForNoDuplicates = True Or ExcludeBothAlertRcptTables = True Then

                            .Append("  1 AS READ_ALERT,")
                            .Append("  0 AS CURRENT_NOTIFY,")

                        Else

                            .Append(" " & RecipientTableName & ".READ_ALERT,")
                            .Append(" " & RecipientTableName & ".CURRENT_NOTIFY,")

                        End If

                        .Append(" ISNULL(CAST(" & RecipientTableName & ".IS_DELETED AS VARCHAR), '') AS IS_DELETED,")

                    Else

                        .Append(" 1 AS READ_ALERT,")
                        .Append("  0 AS CURRENT_NOTIFY,")

                    End If

                    'If ShowAssignmentType = "unassigned" Then
                    '    .Append(" 'Unassigned' AS CURRENT_NOTIFY_EMP_FML,")
                    'Else
                    '    .Append(" '' AS CURRENT_NOTIFY_EMP_FML,")
                    'End If

                    .Append(" (SELECT TOP 1 EMP_CODE FROM [dbo].[wvtf_GetAlertAssignedEmployee] (ALERT.ALERT_ID)) AS CURRENT_NOTIFY_EMP_CODE, ")
                    .Append(" (SELECT TOP 1 EMP_FML FROM [dbo].[wvtf_GetAlertAssignedEmployee] (ALERT.ALERT_ID)) AS CURRENT_NOTIFY_EMP_FML, ")

                    .Append(" RIGHT(")
                    .Append("   REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_NUMBER),")
                    .Append("   6")
                    .Append(" ) + '/' + RIGHT(")
                    .Append("   REPLICATE('0', 3) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_COMPONENT_NBR),")
                    .Append("   2")
                    .Append(" ) ")
                    .Append(" + ' - ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') AS GRP_COMPONENT,")

                    Select Case GroupBy
                        Case "O"
                            .Append(" OFFICE.OFFICE_CODE + ' - ' + OFFICE.OFFICE_NAME AS GRP_OFFICE,")
                        Case "C"
                            .Append(" ALERT.CL_CODE + ' - ' + CLIENT.CL_NAME AS GRP_CLIENT,")
                        Case "CD"
                            .Append(" ALERT.CL_CODE + ', ' + ALERT.DIV_CODE + ' - ' + DIVISION.DIV_NAME AS GRP_DIVISION,")
                        Case "CDP"
                            .Append(" ALERT.CL_CODE + ', ' + ALERT.DIV_CODE + ', ' + ALERT.PRD_CODE +")
                            .Append(" ' - ' + PRODUCT.PRD_DESCRIPTION AS GRP_PRODUCT,")
                        Case "CDPJ"
                            .Append(" RIGHT(")
                            .Append("   REPLICATE('0', 6) ")
                            .Append("   + CONVERT(VARCHAR(20), JOB_LOG.JOB_NUMBER),")
                            .Append("   6")
                            .Append(" ) + ' - ' + ISNULL(JOB_LOG.JOB_DESC, '') AS GRP_JOB,")
                        'Case "CDPJC"
                        '    .Append(" RIGHT(")
                        '    .Append("   REPLICATE('0', 6) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_NUMBER),")
                        '    .Append("   6")
                        '    .Append(" ) + '/' + RIGHT(")
                        '    .Append("   REPLICATE('0', 2) + CONVERT(VARCHAR(20), JOB_COMPONENT.JOB_COMPONENT_NBR),")
                        '    .Append("   2")
                        '    .Append(" ) ")
                        '    .Append(" + ' - ' + ISNULL(JOB_COMPONENT.JOB_COMP_DESC, '') AS GRP_COMPONENT,")
                        Case "CM"
                            .Append(" ISNULL(CAMPAIGN.CMP_CODE + ' - ', '') + ISNULL(CAMPAIGN.CMP_NAME, '') AS GRP_CAMPAIGN,")
                        Case "PST"
                            .Append(" CASE ")
                            .Append(" WHEN JOB_TRAFFIC_DET.FNC_CODE IS NULL OR")
                            .Append("   JOB_TRAFFIC_DET.FNC_CODE = '' THEN JOB_TRAFFIC_DET.TASK_DESCRIPTION")
                            .Append(" ELSE JOB_TRAFFIC_DET.FNC_CODE + '-' + JOB_TRAFFIC_DET.TASK_DESCRIPTION")
                            .Append(" END AS GRP_TASK,")
                        Case "ES"
                            .Append(" RIGHT(")
                            .Append("   REPLICATE('0', 6) + CONVERT(VARCHAR(20), ALERT.ESTIMATE_NUMBER),")
                            .Append("   6")
                            .Append(" ) + ' - ' + ISNULL(ESTIMATE_LOG.EST_LOG_DESC, '') AS GRP_ESTIMATE,")
                        Case "EST"
                            .Append(" RIGHT(")
                            .Append("   REPLICATE('0', 6) + CONVERT(VARCHAR(20), ALERT.ESTIMATE_NUMBER),")
                            .Append("   6")
                            .Append(" ) + '/' + RIGHT(")
                            .Append("   REPLICATE('0', 2) + CONVERT(VARCHAR(20), ALERT.EST_COMPONENT_NBR),")
                            .Append("   2")
                            .Append(" ) + ' - ' + ISNULL(ESTIMATE_COMPONENT.EST_COMP_DESC, '') AS GRP_ESTIMATE_COMPONENT,")
                        Case "DUE_DATE", "DUE_DATE_ASC"
                            .Append(" dbo.udf_format_date_time(ALERT.DUE_DATE, 'YYYY-MM-DD') AS GRP_DUE_DATE,")
                            .Append(" dbo.udf_format_date_time(ALERT.DUE_DATE, 'LONGDATE') AS GRP_DUE_DATE_DISPLAY,")
                        Case "ALERT_NOTIFY_NAME"
                            .Append(" ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID,")
                            .Append(" ALERT_NOTIFY_HDR.ALERT_NOTIFY_NAME,")
                        Case "PRIORITY"
                            .Append(" CASE ")
                            .Append(" WHEN ALERT.PRIORITY = 1 THEN 'Highest'")
                            .Append(" WHEN ALERT.PRIORITY = 2 THEN 'High'")
                            .Append(" WHEN ALERT.PRIORITY = 3 THEN 'Medium'")
                            .Append(" WHEN ALERT.PRIORITY = 4 THEN 'Low'")
                            .Append(" WHEN ALERT.PRIORITY = 5 THEN 'Lowest'")
                            .Append(" ELSE 'Medium'")
                            .Append(" END AS GRP_PRIORITY,")
                    End Select
                    .Append(" COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) AS ID,")
                    .Append(" CASE WHEN (NOT ALERT.ALERT_STATE_ID IS NULL AND NOT ALERT.ALRT_NOTIFY_HDR_ID IS NULL) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS IS_ASSIGNMENT,")
                    .Append(" ISNULL(ALERT.IS_WORK_ITEM, 0) AS IS_WORK_ITEM,")

                    .Append(" ISNULL(ALERT.JOB_NUMBER, 0) AS JOB_NUMBER,")
                    .Append(" ISNULL(ALERT.JOB_COMPONENT_NBR, 0) AS JOB_COMPONENT_NBR,")
                    .Append(" ALERT.TIME_DUE,")
                    .Append(" ALERT.IS_DRAFT,")

                    .Append(" JOB_LOG.JOB_DESC,")
                    .Append(" JOB_COMPONENT.JOB_COMP_DESC,")
                    .Append(" ISNULL(ALERT.TASK_SEQ_NBR, 0) AS TASK_SEQ_NBR,")

                    If InboxType = "dismissed" Then

                        .Append(" 1 AS IS_DISMISSED,")

                    Else

                        .Append(" 0 AS IS_DISMISSED,")

                    End If

                    .Append(" ISNULL(ALERT.IS_CS_REVIEW, 0) AS IS_CS_REVIEW,")
                    .Append(" ISNULL(ALERT.CS_PROJECT_ID, 0) AS CS_PROJECT_ID,")
                    .Append(" ISNULL(ALERT.CS_REVIEW_ID, 0) AS CS_REVIEW_ID,")
                    .Append(" ISNULL(ALERT.CS_NUM_REVIEWER, 0) AS CS_NUM_REVIEWER,")
                    .Append(" ISNULL(ALERT.CS_NUM_CMPLT, 0) AS CS_NUM_CMPLT,")
                    .Append(" CAST(ALERT.CS_ASSET_IMG AS VARBINARY(MAX)) AS CS_ASSET_IMG,")
                    .Append(" ISNULL(ALERT.CS_NUM_REJECT, 0) AS CS_NUM_REJECT,")
                    .Append(" ISNULL(ALERT.CS_NUM_DEFER, 0) AS CS_NUM_DEFER,")
                    .Append(" ISNULL(ALERT.CS_NUM_APPR, 0) AS CS_NUM_APPR,")

                    If ShowAssignmentType = "myalerts" Then
                        .Append(" 1 AS IS_CC, ")
                    End If
                    If ShowAssignmentType = "myalertassignments" Then
                        .Append(" 0 AS IS_CC, ")
                    End If

                    Dim JobLogTableIsJoined As Boolean = False
                    Dim JobComponentTableIsJoined As Boolean = False

                    .Append("ISNULL(SD.SPRINT_HDR_ID, 0) AS SPRINT_ID,")

                    .Append(" NULL AS END_SELECT_CLAUSE")

                    .Append(" FROM  ALERT WITH (NOLOCK)")
                    .Append(" INNER JOIN ALERT_TYPE WITH (NOLOCK)")
                    .Append(" ON ALERT.ALERT_TYPE_ID = ALERT_TYPE.ALERT_TYPE_ID")
                    .Append(" INNER JOIN ALERT_CATEGORY WITH (NOLOCK)")
                    .Append(" ON ALERT.ALERT_CAT_ID = ALERT_CATEGORY.ALERT_CAT_ID")
                    .Append(" LEFT OUTER JOIN CLIENT WITH (NOLOCK)")
                    .Append(" ON ALERT.CL_CODE = CLIENT.CL_CODE")
                    .Append(" LEFT OUTER JOIN SPRINT_DTL SD ON SD.ALERT_ID = ALERT.ALERT_ID")

                    If IncludeTasks = True Then

                        .Append(" LEFT OUTER JOIN JOB_TRAFFIC_DET_CNTS JTE WITH (NOLOCK) ON ALERT.JOB_NUMBER = JTE.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTE.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTE.SEQ_NBR AND ALERT.ALERT_CAT_ID = 71")
                        .Append(" LEFT OUTER JOIN JOB_TRAFFIC_DET JTD WITH (NOLOCK) ON ALERT.JOB_NUMBER = JTD.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JTD.JOB_COMPONENT_NBR AND ALERT.TASK_SEQ_NBR = JTD.SEQ_NBR")
                        .Append(" LEFT OUTER JOIN JOB_TRAFFIC JT WITH (NOLOCK) ON ALERT.JOB_NUMBER = JT.JOB_NUMBER AND ALERT.JOB_COMPONENT_NBR = JT.JOB_COMPONENT_NBR")

                    End If

                    If ExcludeBothAlertRcptTables = False Then
                        If ShowAssignmentType <> "unassigned" Then
                            .Append(" LEFT OUTER JOIN CP_USER WITH (NOLOCK)")
                            .Append(" LEFT OUTER JOIN " & RecipientTableName & " WITH (NOLOCK)")
                            .Append(" ON  CP_USER.CDP_CONTACT_ID = " & RecipientTableName & ".CDP_CONTACT_ID")
                            .Append(" ON ALERT.ALERT_ID = " & RecipientTableName & ".ALERT_ID")
                        Else
                            If ShowAssignmentType = "unassigned" Then
                                .Append(" LEFT OUTER JOIN ")
                            Else
                                .Append(" INNER JOIN ")
                            End If
                            .Append(RecipientTableName)
                            .Append(" ON ALERT.ALERT_ID = " & RecipientTableName & ".ALERT_ID")
                        End If
                    End If

                    If GroupBy <> "CDPJ" Then

                        .Append(" LEFT OUTER JOIN JOB_LOG WITH (NOLOCK)")
                        .Append(" ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER")
                        JobLogTableIsJoined = True

                    End If
                    If GroupBy <> "CDPJC" Then

                        .Append(" LEFT OUTER JOIN JOB_COMPONENT WITH (NOLOCK)")
                        .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                        .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")
                        JobComponentTableIsJoined = True

                    End If

                    Select Case GroupBy
                        Case "O"
                            .Append(" INNER JOIN OFFICE WITH (NOLOCK)")
                            .Append(" ON ALERT.OFFICE_CODE = OFFICE.OFFICE_CODE")
                        'Case "C"
                        '    .Append(" INNER JOIN CLIENT WITH (NOLOCK)")
                        '    .Append(" ON ALERT.CL_CODE = CLIENT.CL_CODE")
                        Case "CD"
                            .Append(" INNER JOIN DIVISION WITH (NOLOCK)")
                            .Append(" ON ALERT.CL_CODE = DIVISION.CL_CODE")
                            .Append(" AND ALERT.DIV_CODE = DIVISION.DIV_CODE")
                        Case "CDP"
                            .Append(" INNER JOIN PRODUCT WITH (NOLOCK)")
                            .Append(" ON ALERT.CL_CODE = PRODUCT.CL_CODE")
                            .Append(" AND ALERT.DIV_CODE = PRODUCT.DIV_CODE")
                            .Append(" AND ALERT.PRD_CODE = PRODUCT.PRD_CODE")
                        Case "CDPJ"

                            If JobLogTableIsJoined = False Then

                                .Append(" INNER JOIN JOB_LOG WITH (NOLOCK)")
                                .Append(" ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER")

                                JobLogTableIsJoined = True

                            End If

                        Case "CDPJC"

                            If JobComponentTableIsJoined = False Then

                                .Append(" INNER JOIN JOB_COMPONENT WITH (NOLOCK)")
                                .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                                .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")

                                JobComponentTableIsJoined = True

                            End If
                    'Case "CDPJ"
                    '    .Append(" INNER JOIN JOB_LOG WITH (NOLOCK)")
                    '    .Append(" ON ALERT.JOB_NUMBER = JOB_LOG.JOB_NUMBER")
                    'Case "CDPJC"
                    '    .Append(" INNER JOIN JOB_COMPONENT WITH (NOLOCK)")
                    '    .Append(" ON ALERT.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER")
                    '    .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR")
                        Case "CM"
                            .Append(" INNER JOIN CAMPAIGN WITH (NOLOCK)")
                            .Append(" ON ALERT.CMP_IDENTIFIER = CAMPAIGN.CMP_IDENTIFIER")
                        Case "ES"
                            .Append(" INNER JOIN ESTIMATE_LOG WITH (NOLOCK)")
                            .Append(" ON ALERT.ESTIMATE_NUMBER = ESTIMATE_LOG.ESTIMATE_NUMBER")
                        Case "EST"
                            .Append(" INNER JOIN ESTIMATE_COMPONENT WITH (NOLOCK)")
                            .Append(" ON ALERT.ESTIMATE_NUMBER = ESTIMATE_COMPONENT.ESTIMATE_NUMBER")
                            .Append(" AND ALERT.EST_COMPONENT_NBR = ESTIMATE_COMPONENT.EST_COMPONENT_NBR")
                        Case "ALERT_NOTIFY_NAME"
                            .Append(" INNER JOIN ALERT_NOTIFY_HDR WITH (NOLOCK)")
                            .Append(" ON ALERT.ALRT_NOTIFY_HDR_ID = ALERT_NOTIFY_HDR.ALRT_NOTIFY_HDR_ID")
                            'Case "STATE"
                            '    .Append(" INNER JOIN ALERT_STATES WITH (NOLOCK)")
                            '    .Append(" ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID")
                    End Select

                    If ShowAssignmentType <> "myalertsandassignments" And GroupBy = "STATE" Then
                        .Append(" INNER JOIN ALERT_STATES WITH (NOLOCK)")
                        .Append(" ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID")
                    Else
                        .Append(" LEFT OUTER JOIN ALERT_STATES WITH (NOLOCK)")
                        .Append(" ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID")
                    End If


                    'If GroupBy <> "STATE" Then
                    '    .Append(" LEFT OUTER JOIN ALERT_STATES WITH (NOLOCK)")
                    '    .Append(" ON ALERT.ALERT_STATE_ID = ALERT_STATES.ALERT_STATE_ID")
                    'End If

                    If GroupBy = "PST" Or FilterLevel = "PST" Then
                        .Append(" INNER JOIN JOB_TRAFFIC_DET WITH (NOLOCK)")
                        .Append(" ON ALERT.JOB_NUMBER = JOB_TRAFFIC_DET.JOB_NUMBER")
                        .Append(" AND ALERT.JOB_COMPONENT_NBR = JOB_TRAFFIC_DET.JOB_COMPONENT_NBR")
                        .Append(" AND ALERT.TASK_SEQ_NBR = JOB_TRAFFIC_DET.SEQ_NBR")

                    End If

                    .Append(" LEFT OUTER JOIN [dbo].[advtf_alert_inactive_work_items]() IWI ON ALERT.ALERT_ID = IWI.ALERT_ID  ")

                    .Append(" WHERE 1 = 1 ")


                    If IncludeCompletedAssignments = True Then
                        IncludeBothAlertRcptTables = True
                    End If

                    Select Case ShowAssignmentType
                        Case "myalertassignments"
                            'CPID = Me.mEmpCode
                            '.Append(" AND (NOT(ALERT.ALERT_STATE_ID IS NULL))")
                            If ExcludeBothAlertRcptTables = False Then
                                .Append(" AND (")
                                '.Append(" " & RecipientTableName & ".CDP_CONTACT_ID = @CPID")
                                '.Append(" AND (" & RecipientTableName & ".CURRENT_NOTIFY = 1)")
                                .Append(" (JTE.CDP_CONTACT_ID = @CPID AND ALERT.ALERT_CAT_ID = 71))")
                            End If
                        Case "allalertassignments"
                            .Append(" AND (NOT(ALERT.ALERT_STATE_ID IS NULL))")

                            If CPID <> 0 And ExcludeBothAlertRcptTables = False Then
                                .Append(" AND (")

                                If InboxType <> "sent" Then
                                    .Append(" " & RecipientTableName & ".CDP_CONTACT_ID = @CPID")
                                    '.Append(" AND (" & RecipientTableName & ".CURRENT_NOTIFY = 1 )")
                                Else
                                    '.Append(" (" & RecipientTableName & ".CURRENT_NOTIFY = 1 )")
                                End If

                                .Append(")")
                            End If

                        Case "unassigned"
                            .Append(" AND (NOT(ALERT.ALERT_STATE_ID IS NULL))")
                            If ExcludeBothAlertRcptTables = False Then
                                '.Append(" AND (( " & RecipientTableName & ".CURRENT_NOTIFY IS NULL))")
                            End If
                            If (InboxType = "inbox") Or (InboxType = "sent") Then
                                .Append(" AND ALERT.ALERT_ID NOT IN (SELECT DISTINCT ALERT_ID FROM ALERT_RCPT_DISMISSED WITH (NOLOCK))")
                                .Append(" AND ALERT.ALERT_ID NOT IN (SELECT DISTINCT ALERT_ID FROM ALERT_RCPT WITH (NOLOCK))")
                            End If

                        Case "myalerts"
                            '.Append(" AND (ALERT.ALERT_STATE_ID IS NULL)")
                            If IsJobAlertsPage = False And CPID <> 0 And InboxType <> "sent" And ExcludeBothAlertRcptTables = False Then
                                .Append(" AND (" & RecipientTableName & ".CDP_CONTACT_ID = @CPID)")
                            End If

                            If IncludeReviews = False Then .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                        Case "myalertsandassignments"

                            If IsJobAlertsPage = False And CPID <> 0 And InboxType <> "sent" And ExcludeBothAlertRcptTables = False Then
                                .Append(" AND (" & RecipientTableName & ".CDP_CONTACT_ID = @CPID)")
                            End If
                            'CPID = Me.mEmpCode

                            If IncludeReviews = False Then .Append(" AND (ALERT.IS_CS_REVIEW = 0 OR ALERT.IS_CS_REVIEW IS NULL)")

                        Case "myreviews"

                            If IsJobAlertsPage = False And CPID <> 0 And InboxType <> "sent" And ExcludeBothAlertRcptTables = False Then

                                .Append(" AND (" & RecipientTableName & ".CDP_CONTACT_ID = @CPID)")

                            End If

                            '(ALERT.ALERT_TYPE_ID = 15 AND ( ALERT.IS_CS_REVIEW = 1 )) INCLUDES "Reviews" for ConceptShare
                            .Append(" AND ((ALERT.ALERT_TYPE_ID = 15 AND ( ALERT.IS_CS_REVIEW = 1 )) ")

                            'Adding the additional OR (ALERT.ALERT_TYPE_ID = 6 AND ALERT.ALERT_CAT_ID = 79) will 
                            'pickup the New Proofing Tool "Proofs"
                            .Append(" OR (ALERT.ALERT_TYPE_ID = 6 And ALERT.ALERT_CAT_ID = 79)) ")


                    End Select

                    If IsJobAlertsPage = False Then
                        Select Case InboxType
                            Case "inbox", ""
                            'NOW CONTROLLED BY TABLE
                            '.Append(" And ((" & RecipientTableName & ".PROCESSED Is NULL))")
                            Case "sent"
                                If CPID <> 0 Then
                                    .Append(" And (CP_ALERT_RCPT.CDP_CONTACT_ID = @CPID)")
                                    .Append(" And (ALERT.ALERT_USER = CAST(@CPID AS VARCHAR(6)))")
                                End If
                            Case "dismissed"
                            'NOW CONTROLLED BY TABLE
                            '.Append(" And (Not(" & RecipientTableName & ".PROCESSED Is NULL))")
                            Case "received"

                            Case "action"
                                .Append(" And (ALERT.ALERT_CAT_ID = 33)")
                            Case "discussion"
                                .Append(" And (ALERT.ALERT_CAT_ID = 26)")
                            Case "event"
                                .Append(" And (ALERT.ALERT_CAT_ID = 24)")
                            Case "review"
                                .Append(" And (ALERT.ALERT_CAT_ID = 27)")
                            Case "issue"
                                .Append(" And (ALERT.ALERT_CAT_ID = 47)")
                        End Select
                    Else
                        If IncludeCompletedAssignments = False Then
                            IncludeBothAlertRcptTables = False
                        End If
                    End If

                    Select Case FilterLevel
                        Case "OF"
                            If OfficeCode.Trim() <> "" Then
                                .Append(" And (ALERT.OFFICE_CODE = @OFFICE_CODE)")
                            End If
                        Case "CL"
                            If ClCode.Trim() <> "" Then
                                .Append(" And (ALERT.CL_CODE = @CL_CODE)")
                            End If
                        Case "DI"
                            If ClCode.Trim() <> "" Then
                                .Append(" And (ALERT.CL_CODE = @CL_CODE)")
                            End If
                            If DivCode.Trim() <> "" Then
                                .Append(" And (ALERT.DIV_CODE = @DIV_CODE)")
                            End If
                        Case "PR"
                            If ClCode.Trim() <> "" Then
                                .Append(" And (ALERT.CL_CODE = @CL_CODE)")
                            End If
                            If DivCode.Trim() <> "" Then
                                .Append(" And (ALERT.DIV_CODE = @DIV_CODE)")
                            End If
                            If PrdCode.Trim() <> "" Then
                                .Append(" And (ALERT.PRD_CODE = @PRD_CODE)")
                            End If
                        Case "CM"
                            If ClCode.Trim() <> "" Then
                                .Append(" And (ALERT.CL_CODE = @CL_CODE)")
                            End If
                            If DivCode.Trim() <> "" Then
                                .Append(" And (ALERT.DIV_CODE = @DIV_CODE)")
                            End If
                            If PrdCode.Trim() <> "" Then
                                .Append(" And (ALERT.PRD_CODE = @PRD_CODE)")
                            End If
                            If CmpCode.Trim() <> "" Then
                                .Append(" And (ALERT.CMP_CODE = @CMP_CODE)")
                            End If
                        Case "JO"
                            If JobNumber > 0 Then
                                .Append(" And (ALERT.JOB_NUMBER = @JOB_NUMBER)")
                            End If
                        Case "JC"
                            .Append(" And (")
                            .Append("(ALERT.JOB_NUMBER = @JOB_NUMBER And ALERT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)")
                            .Append(" Or (ALERT.JOB_COMPONENT_NBR Is NULL And ALERT.ALERT_LEVEL = 'JO' AND ALERT.JOB_NUMBER = @JOB_NUMBER)")
                            .Append(")")
                        Case "VN"
                            If VnCode.Trim() <> "" Then
                                .Append(" AND (ALERT.VN_CODE = @VN_CODE)")
                            End If
                        Case "DO"
                            If AlertLevel.Trim() <> "" Then
                                .Append(" AND (ALERT.ALERT_LEVEL = @ALERT_LEVEL)") ' should be either AD or ED
                            End If
                        Case "ES"
                            If EstimateNumber > 0 Then
                                .Append(" AND (ALERT.ESTIMATE_NUMBER = @ESTIMATE_NUMBER)")
                            End If
                        Case "EST"
                            If EstimateNumber > 0 Then
                                .Append(" AND (ALERT.ESTIMATE_NUMBER = @ESTIMATE_NUMBER)")
                            End If
                            If EstComponentNbr > 0 Then
                                .Append(" AND (ALERT.EST_COMPONENT_NBR = @EST_COMPONENT_NBR)")
                            End If
                        Case "PST"
                            If JobNumber > 0 Then
                                .Append(" AND (ALERT.JOB_NUMBER = @JOB_NUMBER)")
                            End If
                            If JobComponentNbr > 0 Then
                                .Append(" AND (ALERT.JOB_COMPONENT_NBR = @JOB_COMPONENT_NBR)")
                            End If
                            'be sure to include the table join on this alert level and not just when grouping by this level
                            If TaskCode.Trim() <> "" And TaskDescription.Trim() <> "" Then
                                .Append(" AND (JOB_TRAFFIC_DET.FNC_CODE = @TASK_FNC_CODE)")
                            ElseIf TaskCode.Trim() = "" And TaskDescription.Trim() <> "" Then
                                .Append(" AND (UPPER(JOB_TRAFFIC_DET.TASK_DESCRIPTION) LIKE '%' + UPPER(@TASK_FNC_DESC) + '%')")
                            ElseIf TaskCode.Trim() <> "" And TaskDescription.Trim() = "" Then
                                .Append(" AND (JOB_TRAFFIC_DET.FNC_CODE = @TASK_FNC_CODE)")
                            ElseIf TaskCode.Trim() = "" And TaskDescription.Trim() = "" Then

                            End If
                        Case "ID"
                            If AlertAssignmentSeqNbr > 0 Then
                                .Append(" AND (COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) = @ID)")
                            End If
                        Case "ALRT_NOTIFY_HDR"
                            If AlrtNotifyHdrId > 0 Then
                                .Append(" AND (ALERT.ALRT_NOTIFY_HDR_ID = @ALRT_NOTIFY_HDR_ID)")
                            End If
                    End Select

                    Select Case GroupBy
                        Case "DUE_DATE", "DUE_DATE_ASC"
                            .Append(" AND (NOT (DUE_DATE IS NULL))")
                    End Select

                    If AlertTypeId > 0 Then
                        .Append(" AND (ALERT.ALERT_TYPE_ID = @ALERT_TYPE_ID)")
                    End If
                    If AlertCategoryId > 0 Then
                        .Append(" AND (ALERT.ALERT_CAT_ID = @ALERT_CAT_ID)")
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''
                    Try
                        If StartDate.Trim() <> "" Then
                            DateTime.TryParse(StartDate.Trim, DateStart)
                        Else
                            DateStart = Nothing
                        End If
                    Catch ex As Exception
                        DateStart = Nothing
                    End Try

                    Try
                        If EndDate.Trim() <> "" Then
                            DateTime.TryParse(CDate(EndDate.Trim()).ToShortDateString() & " 11:59 PM", DateEnd)
                        Else
                            DateEnd = Nothing
                        End If
                    Catch ex As Exception
                        DateEnd = Nothing
                    End Try

                    If IsJobAlertsPage = False Then
                        If Not DateStart = Nothing And Not DateEnd = Nothing Then
                            .Append(" AND (ALERT.GENERATED BETWEEN @START_DATE AND @END_DATE)")
                        ElseIf DateStart = Nothing And Not DateEnd = Nothing Then
                            .Append(" AND (ALERT.GENERATED  <= @END_DATE)")
                        ElseIf Not DateStart = Nothing And DateEnd = Nothing Then
                            .Append(" AND (ALERT.GENERATED >= @START_DATE)")
                        End If
                    End If

                    If SearchCriteria.Trim() <> "" Then
                        .Append(" AND (")
                        .Append(" (UPPER(ALERT.[SUBJECT]) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")
                        .Append(" OR (UPPER(ALERT.ALERT_USER) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")
                        .Append(" OR (UPPER(CAST(ALERT.[BODY] AS VARCHAR)) LIKE '%' + UPPER(@SEARCH_CRITERIA) + '%')")

                        If IsNumeric(SearchCriteria) = True Then
                            .Append(" OR (ALERT.JOB_NUMBER = CAST(@SEARCH_CRITERIA AS INTEGER))")
                            .Append(" OR (COALESCE(ALERT.ALERT_SEQ_NBR, ALERT.ALERT_ID) = CAST(@SEARCH_CRITERIA AS INTEGER))")
                        End If

                        .Append(")")
                    End If

                    If InboxType = "drafts" Then

                        .Append(" AND ALERT.IS_DRAFT = 1")

                    End If

                    If IsJobAlertsPage = False Then
                        If (InboxType.Trim().ToLower() = "dismissed" And ShowAssignmentType = "unassigned") Or
                       (InboxType.Trim().ToLower() = "received" And ShowAssignmentType = "unassigned") Then
                            .Append(" AND 0 = 1")
                        End If
                    End If

                End With

                Dim arP(21) As SqlParameter

                Dim pCPID As New SqlParameter("@CPID", SqlDbType.Int)
                If CPID <> 0 Then
                    pCPID.Value = CPID
                Else
                    pCPID.Value = System.DBNull.Value
                End If
                arP(0) = pCPID

                Dim pOFFICE_CODE As New SqlParameter("@OFFICE_CODE", SqlDbType.VarChar, 4)
                If OfficeCode.Trim() <> "" Then
                    pOFFICE_CODE.Value = OfficeCode.Trim()
                Else
                    pOFFICE_CODE.Value = System.DBNull.Value
                End If
                arP(1) = pOFFICE_CODE

                Dim pCL_CODE As New SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
                If ClCode.Trim() <> "" Then
                    pCL_CODE.Value = ClCode.Trim()
                Else
                    pCL_CODE.Value = System.DBNull.Value
                End If
                arP(2) = pCL_CODE

                Dim pDIV_CODE As New SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
                If DivCode.Trim() <> "" Then
                    pDIV_CODE.Value = DivCode.Trim()
                Else
                    pDIV_CODE.Value = System.DBNull.Value
                End If
                arP(3) = pDIV_CODE

                Dim pPRD_CODE As New SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
                If PrdCode.Trim() <> "" Then
                    pPRD_CODE.Value = PrdCode.Trim()
                Else
                    pPRD_CODE.Value = System.DBNull.Value
                End If
                arP(4) = pPRD_CODE

                Dim pCMP_CODE As New SqlParameter("@CMP_CODE", SqlDbType.VarChar, 6)
                If CmpCode.Trim() <> "" Then
                    pCMP_CODE.Value = CmpCode.Trim()
                Else
                    pCMP_CODE.Value = System.DBNull.Value
                End If
                arP(5) = pCMP_CODE

                Dim pJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                If JobNumber > 0 Then
                    pJOB_NUMBER.Value = JobNumber
                Else
                    pJOB_NUMBER.Value = System.DBNull.Value
                End If
                arP(6) = pJOB_NUMBER

                Dim pJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.Int)
                If JobComponentNbr > 0 Then
                    pJOB_COMPONENT_NBR.Value = JobComponentNbr
                Else
                    pJOB_COMPONENT_NBR.Value = System.DBNull.Value
                End If
                arP(7) = pJOB_COMPONENT_NBR

                Dim pALERT_TYPE_ID As New SqlParameter("@ALERT_TYPE_ID", SqlDbType.Int)
                If AlertTypeId > 0 Then
                    pALERT_TYPE_ID.Value = AlertTypeId
                Else
                    pALERT_TYPE_ID.Value = System.DBNull.Value
                End If
                arP(8) = pALERT_TYPE_ID

                Dim pALERT_CAT_ID As New SqlParameter("@ALERT_CAT_ID", SqlDbType.Int)
                If AlertCategoryId > 0 Then
                    pALERT_CAT_ID.Value = AlertCategoryId
                Else
                    pALERT_CAT_ID.Value = System.DBNull.Value
                End If
                arP(9) = pALERT_CAT_ID

                Dim pSTART_DATE As New SqlParameter("@START_DATE", SqlDbType.SmallDateTime)
                If Not DateStart = Nothing Then
                    pSTART_DATE.Value = DateStart
                Else
                    pSTART_DATE.Value = System.DBNull.Value
                End If
                arP(10) = pSTART_DATE

                Dim pEND_DATE As New SqlParameter("@END_DATE", SqlDbType.SmallDateTime)
                If Not DateEnd = Nothing Then
                    pEND_DATE.Value = DateEnd
                Else
                    pEND_DATE.Value = System.DBNull.Value
                End If
                arP(11) = pEND_DATE

                Dim pALERT_LEVEL As New SqlParameter("@ALERT_LEVEL", SqlDbType.VarChar, 50)
                If AlertLevel.Trim() <> "" Then
                    pALERT_LEVEL.Value = AlertLevel.Trim()
                Else
                    pALERT_LEVEL.Value = System.DBNull.Value
                End If
                arP(12) = pALERT_LEVEL

                Dim pVN_CODE As New SqlParameter("@VN_CODE", SqlDbType.VarChar, 6)
                If VnCode.Trim() <> "" Then
                    pVN_CODE.Value = VnCode.Trim()
                Else
                    pVN_CODE.Value = System.DBNull.Value
                End If
                arP(13) = pVN_CODE

                Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                If EstimateNumber > 0 Then
                    pESTIMATE_NUMBER.Value = EstimateNumber
                Else
                    pESTIMATE_NUMBER.Value = System.DBNull.Value
                End If
                arP(14) = pESTIMATE_NUMBER

                Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.Int)
                If EstComponentNbr > 0 Then
                    pEST_COMPONENT_NBR.Value = EstComponentNbr
                Else
                    pEST_COMPONENT_NBR.Value = System.DBNull.Value
                End If
                arP(15) = pEST_COMPONENT_NBR

                Dim pTASK_FNC_CODE As New SqlParameter("@TASK_FNC_CODE", SqlDbType.VarChar, 6)
                If TaskCode.Trim() <> "" Then
                    pTASK_FNC_CODE.Value = TaskCode.Trim()
                Else
                    pTASK_FNC_CODE.Value = System.DBNull.Value
                End If
                arP(16) = pTASK_FNC_CODE

                Dim pTASK_FNC_DESC As New SqlParameter("@TASK_FNC_DESC", SqlDbType.VarChar, 40)
                If TaskDescription.Trim() <> "" Then
                    pTASK_FNC_DESC.Value = TaskDescription.Trim()
                Else
                    pTASK_FNC_DESC.Value = System.DBNull.Value
                End If
                arP(17) = pTASK_FNC_DESC

                Dim pALERT_NOTIFY_NAME As New SqlParameter("@ALERT_NOTIFY_NAME", SqlDbType.VarChar, 100)
                If AlertNotifyName.Trim() <> "" Then
                    pALERT_NOTIFY_NAME.Value = AlertNotifyName.Trim()
                Else
                    pALERT_NOTIFY_NAME.Value = System.DBNull.Value
                End If
                arP(18) = pALERT_NOTIFY_NAME

                Dim pID As New SqlParameter("@ID", SqlDbType.Int)
                If AlertAssignmentSeqNbr > 0 Then
                    pID.Value = AlertAssignmentSeqNbr
                Else
                    pID.Value = System.DBNull.Value
                End If
                arP(19) = pID

                Dim pALRT_NOTIFY_HDR_ID As New SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)
                If AlrtNotifyHdrId > 0 Then
                    pALRT_NOTIFY_HDR_ID.Value = AlrtNotifyHdrId
                Else
                    pALRT_NOTIFY_HDR_ID.Value = System.DBNull.Value
                End If
                arP(20) = pALRT_NOTIFY_HDR_ID

                Dim pSEARCH_CRITERIA As New SqlParameter("@SEARCH_CRITERIA", SqlDbType.VarChar, 1000)
                If SearchCriteria.Trim() <> "" Then
                    pSEARCH_CRITERIA.Value = SearchCriteria.Trim()
                Else
                    pSEARCH_CRITERIA.Value = System.DBNull.Value
                End If
                arP(21) = pSEARCH_CRITERIA

                SQL = sb.ToString()

                If ShowAssignmentType = "unassigned" Then
                    IncludeBothAlertRcptTables = False
                End If

                If IncludeBothAlertRcptTables = True Then
                    SQL = SQL & " UNION " & SQL.Replace("CP_ALERT_RCPT", "CP_ALERT_RCPT_DISMISSED")
                    SQL = "SELECT A.* FROM ( " & SQL & ") AS A "
                Else
                    ' SQL = SQL & " ORDER BY GENERATED DESC;"
                End If

                'QUICK FIX FOR DISMISSED ALERTS WITH ASSIGNMENTS
                SQL = SQL.Replace("CP_ALERT_RCPT_DISMISSED_DISMISSED", "CP_ALERT_RCPT_DISMISSED")

                'Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, SQL, "DtAlerts", arP)

                Dim SelectText As String = ""

                If IsCount = True Then

                    SelectText = "COUNT(1) AS REC_COUNT"

                Else

                    SelectText = "B.*"

                End If

                If IsJobAlertsPage = True Then

                    Dim IncludeCompletedAssignmentsSQL As String = ""

                    If ShowAssignmentType = "myalerts" Then

                        SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE IS_ASSIGNMENT = 0", SelectText, SQL)

                    ElseIf ShowAssignmentType = "myalertassignments" Then

                        If IncludeCompletedAssignments = False Then

                            IncludeCompletedAssignmentsSQL = " AND (B.CURRENT_NOTIFY_EMP_FML <> 'Completed' OR B.CURRENT_NOTIFY_EMP_FML IS NULL) "

                        End If

                        SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE (CURRENT_NOTIFY_EMP_CODE = @EMP_CODE) {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                    ElseIf ShowAssignmentType = "myalertsandassignments" Then

                        If IncludeCompletedAssignments = False Then

                            IncludeCompletedAssignmentsSQL = " WHERE (B.CURRENT_NOTIFY_EMP_FML <> 'Completed' OR B.CURRENT_NOTIFY_EMP_FML IS NULL) "

                        End If

                        SQL = String.Format("SELECT {0} FROM ({1}) AS B {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                    ElseIf ShowAssignmentType = "allalertassignments" Then

                        If IncludeCompletedAssignments = False Then

                            IncludeCompletedAssignmentsSQL = " WHERE (B.CURRENT_NOTIFY_EMP_FML <> 'Completed') "

                        End If

                        SQL = String.Format("SELECT {0} FROM ({1}) AS B {2}", SelectText, SQL, IncludeCompletedAssignmentsSQL)

                    Else

                        SQL = String.Format("SELECT {0} FROM ({1} ) AS B", SelectText, SQL)

                    End If

                Else

                    If ShowAssignmentType = "myalerts" Then

                        SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE (CURRENT_NOTIFY IS NULL OR CURRENT_NOTIFY = 0) ", SelectText, SQL)

                    ElseIf ShowAssignmentType <> "myalertsandassignments" AndAlso ShowAssignmentType <> "myreviews" AndAlso InboxType = "inbox" Then

                        SQL = String.Format("SELECT {0} FROM ({1}) AS B WHERE (CURRENT_NOTIFY_EMP_FML <> 'Completed' OR CURRENT_NOTIFY_EMP_FML IS NULL)", SelectText, SQL)

                    Else

                        SQL = String.Format("SELECT {0} FROM ({1}) AS B", SelectText, SQL)

                    End If

                End If

                If IsCount = False Then

                    Dim SbSort As New System.Text.StringBuilder

                    SbSort.Append(" ORDER BY ")
                    Select Case GroupBy
                        Case "O"

                            SbSort.Append("B.GRP_OFFICE,")

                        Case "C"

                            SbSort.Append("B.GRP_CLIENT,")

                        Case "CAT"

                            SbSort.Append("B.CATEGORY,")

                        Case "CD"

                            SbSort.Append("B.GRP_DIVISION,")

                        Case "CDP"

                            SbSort.Append("B.GRP_PRODUCT,")

                        Case "CDPJ"

                            SbSort.Append("B.GRP_JOB,")

                        Case "CM"

                            SbSort.Append("B.GRP_CAMPAIGN,")

                        Case "PST"

                            SbSort.Append("B.GRP_TASK,")

                        Case "ES"

                            SbSort.Append("B.GRP_ESTIMATE,")

                        Case "EST"

                            SbSort.Append("B.GRP_ESTIMATE_COMPONENT,")

                        Case "DUE_DATE"

                            SbSort.Append("B.DUE_DATE DESC,")

                        Case "DUE_DATE_ASC"

                            SbSort.Append("B.DUE_DATE ASC,")

                        Case "ALERT_NOTIFY_NAME"

                            SbSort.Append("B.ALERT_NOTIFY_NAME,")

                        Case "PRIORITY"

                            SbSort.Append("B.PRIORITY,")

                        Case "STATE"

                            SbSort.Append("B.ALERT_STATE_NAME,")

                        Case "AB"

                            SbSort.Append("B.GRP_ATB,")

                        Case "LAST_UPD"

                            SbSort.Append("B.GENERATED DESC,")

                        Case "VER_BLD"

                            SbSort.Append("B.[VERSION] DESC, B.BUILD ASC,")

                        Case "NEW_UNREAD"

                            SbSort.Append("B.READ_ALERT,")

                    End Select

                    If GroupBy <> "LAST_UPD" Then

                        SbSort.Append(" B.GENERATED DESC OPTION (RECOMPILE);")

                    Else

                        'SbSort.Append(" B.CARD_SEQ_NBR OPTION (RECOMPILE);")

                    End If

                    SQL &= SbSort.ToString()

                Else

                    SQL &= "  OPTION (RECOMPILE);"

                End If


                ' For testing to copy/paste query into enterprise mgr
                SQL = SQL.Replace(vbTab, " ").Replace(vbCrLf, " ")

                SqlConnection = DbContext.Database.Connection
                SqlCommand = New SqlClient.SqlCommand(SQL, SqlConnection)
                SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

                Using SqlCommand

                    SqlCommand.CommandType = CommandType.Text
                    SqlCommand.Parameters.AddRange(arP.ToArray)

                    DataTable = New DataTable

                    SqlDataAdapter.Fill(DataTable)

                End Using

                If IsCount = False Then

                    'If DataTable IsNot Nothing AndAlso DataTable.Rows.Count > 0 Then

                    '    Alerts = DataTable.Rows.OfType(Of DataRow).ToList.Select(Function(dr) AdvantageFramework.DTO.Desktop.Alert.FromMainAlertQuery(dr, GroupBy)).ToList

                    'End If

                    'Return Alerts

                    Return DataTable

                Else

                    Try

                        RecordCount = CType(DataTable.Rows(0)("REC_COUNT"), Integer)
                        ErrorMessage = ""
                        Return Nothing

                    Catch ex As Exception
                        RecordCount = -1
                        ErrorMessage = ex.Message.ToString
                        If ex.InnerException IsNot Nothing AndAlso String.IsNullOrWhiteSpace(ex.InnerException.Message) = False Then
                            ErrorMessage = ErrorMessage & Environment.NewLine & ex.InnerException.Message.ToString
                        End If
                        Return Nothing
                    End Try

                End If

                'If IsCount = False Then

                '    Return SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, SQL, "DtAlerts", arP)

                'Else

                '    Try

                '        RecordCount = CType(SqlHelper.ExecuteDataTable(Me.mConnString, CommandType.Text, SQL, "DtAlerts", arP).Rows(0)("REC_COUNT"), Integer)

                '        ErrorMessage = ""
                '        Return Nothing

                '    Catch ex As Exception

                '        ErrorMessage = MiscFN.JavascriptSafe("COUNT ERROR: " & ex.Message.ToString())
                '        RecordCount = -1
                '        Return Nothing

                '    End Try

                'End If

            Catch ex As Exception
                'ErrorMessage = ex.Message.ToString() & "\n\n" & SQL
                'ErrorMessage = ErrorMessage.Replace("'", "\'").Replace("""", "\""").Replace("\", "\\")
                ErrorMessage = "Error retrieving alerts:\n" & ex.Message.ToString().Replace("'", "")
                Return Nothing
            End Try
        End Function
        Public Function LoadAlertRecipientsDataTable(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal ClientCode As String,
                                                     ByVal DivisionCode As String,
                                                     ByVal ProductCode As String,
                                                     ByVal JobNumber As Integer,
                                                     ByVal JobComponentNumber As Short,
                                                     ByVal CampaignIdentifier As Integer,
                                                     ByVal ClientPortalUserId As Integer,
                                                     ByVal AlertID As Integer,
                                                     ByVal UserCode As String,
                                                     ByVal OnlyConceptShareUsers As Boolean,
                                                     ByVal EmailGroupCode As String) As DataTable

            Dim AutoCompleteRecipientsDatatable As New DataTable
            Dim SqlConnection As System.Data.SqlClient.SqlConnection = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim SqlDataAdapter As System.Data.SqlClient.SqlDataAdapter = Nothing
            Dim SqlParameters As Generic.List(Of System.Data.SqlClient.SqlParameter) = Nothing

            Dim ClientCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DivisionCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProductCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CampaignIdentifierSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ClientPortalUserIdSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OnlyConceptShareUsersSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmailGroupCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            ClientCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            DivisionCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            ProductCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            CampaignIdentifierSqlParameter = New System.Data.SqlClient.SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int)
            ClientPortalUserIdSqlParameter = New System.Data.SqlClient.SqlParameter("@CLIENT_PORTAL_USER_ID", SqlDbType.Int)
            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.Int)
            OnlyConceptShareUsersSqlParameter = New System.Data.SqlClient.SqlParameter("@IS_REVIEWERS", SqlDbType.Bit)
            EmailGroupCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)

            ClientCodeSqlParameter.Value = ClientCode
            DivisionCodeSqlParameter.Value = DivisionCode
            ProductCodeSqlParameter.Value = ProductCode
            JobNumberSqlParameter.Value = JobNumber
            JobComponentNumberSqlParameter.Value = JobComponentNumber
            CampaignIdentifierSqlParameter.Value = CampaignIdentifier
            ClientPortalUserIdSqlParameter.Value = ClientPortalUserId
            AlertIDSqlParameter.Value = AlertID
            UserCodeSqlParameter.Value = DbContext.UserCode
            OnlyConceptShareUsersSqlParameter.Value = OnlyConceptShareUsers
            EmailGroupCodeSqlParameter.Value = EmailGroupCode

            SqlParameters.Add(ClientCodeSqlParameter)
            SqlParameters.Add(DivisionCodeSqlParameter)
            SqlParameters.Add(ProductCodeSqlParameter)
            SqlParameters.Add(JobNumberSqlParameter)
            SqlParameters.Add(JobComponentNumberSqlParameter)
            SqlParameters.Add(CampaignIdentifierSqlParameter)
            SqlParameters.Add(ClientPortalUserIdSqlParameter)
            SqlParameters.Add(AlertIDSqlParameter)
            SqlParameters.Add(UserCodeSqlParameter)
            SqlParameters.Add(OnlyConceptShareUsersSqlParameter)
            SqlParameters.Add(EmailGroupCodeSqlParameter)

            SqlConnection = DbContext.Database.Connection
            SqlCommand = New SqlClient.SqlCommand("usp_wv_AutoCompleteRecipientsLoad", SqlConnection)
            SqlDataAdapter = New SqlClient.SqlDataAdapter(SqlCommand)

            Using SqlCommand

                SqlCommand.CommandType = CommandType.StoredProcedure
                SqlCommand.Parameters.AddRange(SqlParameters.ToArray)

                SqlDataAdapter.Fill(AutoCompleteRecipientsDatatable)

            End Using

            Return AutoCompleteRecipientsDatatable

        End Function
        Public Function LoadAlertRecipients(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal ClientCode As String,
                                                     ByVal DivisionCode As String,
                                                     ByVal ProductCode As String,
                                                     ByVal JobNumber As Integer,
                                                     ByVal JobComponentNumber As Short,
                                                     ByVal CampaignIdentifier As Integer,
                                                     ByVal ClientPortalUserId As Integer,
                                                     ByVal AlertID As Integer,
                                                     ByVal UserCode As String,
                                                     ByVal OnlyConceptShareUsers As Boolean,
                                                     ByVal EmailGroupCode As String) As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipientLookUp)

            Dim Results As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipientLookUp) = Nothing
            Dim ClientCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DivisionCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ProductCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim CampaignIdentifierSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim ClientPortalUserIdSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim OnlyConceptShareUsersSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmailGroupCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            ClientCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@CL_CODE", SqlDbType.VarChar, 6)
            DivisionCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@DIV_CODE", SqlDbType.VarChar, 6)
            ProductCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@PRD_CODE", SqlDbType.VarChar, 6)
            JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
            JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
            CampaignIdentifierSqlParameter = New System.Data.SqlClient.SqlParameter("@CMP_IDENTIFIER", SqlDbType.Int)
            ClientPortalUserIdSqlParameter = New System.Data.SqlClient.SqlParameter("@CLIENT_PORTAL_USER_ID", SqlDbType.Int)
            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            OnlyConceptShareUsersSqlParameter = New System.Data.SqlClient.SqlParameter("@IS_REVIEWERS", SqlDbType.Bit)
            EmailGroupCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EMAIL_GR_CODE", SqlDbType.VarChar, 50)

            ClientCodeSqlParameter.Value = ClientCode
            DivisionCodeSqlParameter.Value = DivisionCode
            ProductCodeSqlParameter.Value = ProductCode
            JobNumberSqlParameter.Value = JobNumber
            JobComponentNumberSqlParameter.Value = JobComponentNumber
            CampaignIdentifierSqlParameter.Value = CampaignIdentifier
            ClientPortalUserIdSqlParameter.Value = ClientPortalUserId
            AlertIDSqlParameter.Value = AlertID
            UserCodeSqlParameter.Value = DbContext.UserCode
            OnlyConceptShareUsersSqlParameter.Value = OnlyConceptShareUsers
            EmailGroupCodeSqlParameter.Value = EmailGroupCode

            Try

                Results = DbContext.Database.SqlQuery(Of AdvantageFramework.DTO.Desktop.AlertRecipientLookUp)("EXEC [dbo].[usp_wv_AutoCompleteRecipientsLoad] @CL_CODE, @DIV_CODE, @PRD_CODE, @JOB_NUMBER, @JOB_COMPONENT_NBR, @CMP_IDENTIFIER, @CLIENT_PORTAL_USER_ID, @ALERT_ID, @USER_CODE, @IS_REVIEWERS, @EMAIL_GR_CODE;",
                                                                                                              ClientCodeSqlParameter,
                                                                                                              DivisionCodeSqlParameter,
                                                                                                              ProductCodeSqlParameter,
                                                                                                              JobNumberSqlParameter,
                                                                                                              JobComponentNumberSqlParameter,
                                                                                                              CampaignIdentifierSqlParameter,
                                                                                                              ClientPortalUserIdSqlParameter,
                                                                                                              AlertIDSqlParameter,
                                                                                                              UserCodeSqlParameter,
                                                                                                              OnlyConceptShareUsersSqlParameter,
                                                                                                              EmailGroupCodeSqlParameter).ToList

            Catch ex As Exception
                Results = Nothing
            End Try

            Return Results

        End Function
        Private Function ReturnFields(ByVal OuterTableName As String, ByVal GroupBy As String, ByVal IsCount As Boolean) As String

            Dim F As New System.Text.StringBuilder

            If IsCount = False Then

                F.AppendFormat("{0}.[ALERT_ID],", OuterTableName)
                F.AppendFormat("{0}.[SUBJECT],", OuterTableName)
                F.AppendFormat("{0}.[GENERATED],", OuterTableName)
                F.AppendFormat("{0}.[USER_NAME],", OuterTableName)
                F.AppendFormat("{0}.[PRIORITY],", OuterTableName)
                F.AppendFormat("{0}.[CARD_GROUPING_PRIORITY_TEXT],", OuterTableName)
                F.AppendFormat("{0}.[TYPE],", OuterTableName)
                F.AppendFormat("{0}.[CATEGORY],", OuterTableName)
                F.AppendFormat("{0}.[ATTACHMENTCOUNT],", OuterTableName)
                F.AppendFormat("{0}.[START_DATE],", OuterTableName)
                F.AppendFormat("{0}.[DUE_DATE],", OuterTableName)
                F.AppendFormat("{0}.[CL_CODE],", OuterTableName)
                F.AppendFormat("{0}.[DIV_CODE],", OuterTableName)
                F.AppendFormat("{0}.[PRD_CODE],", OuterTableName)
                F.AppendFormat("{0}.[CL_NAME],", OuterTableName)
                F.AppendFormat("{0}.[VERSION],", OuterTableName)
                F.AppendFormat("{0}.[BUILD],", OuterTableName)
                F.AppendFormat("{0}.[VERSION_BUILD],", OuterTableName)
                F.AppendFormat("{0}.[ALERT_STATE_NAME],", OuterTableName)
                F.AppendFormat("{0}.[READ_ALERT],", OuterTableName)
                F.AppendFormat("{0}.[CURRENT_NOTIFY],", OuterTableName)
                F.AppendFormat("{0}.[IS_CC],", OuterTableName)
                F.AppendFormat("{0}.[CURRENT_NOTIFY_EMP_CODE],", OuterTableName)
                F.AppendFormat("{0}.[CURRENT_NOTIFY_EMP_FML],", OuterTableName)
                F.AppendFormat("{0}.[GRP_COMPONENT],", OuterTableName)

                Select Case GroupBy
                    Case "O"

                        F.AppendFormat("{0}.[GRP_OFFICE],", OuterTableName)

                    Case "C"

                        F.AppendFormat("{0}.[GRP_CLIENT],", OuterTableName)

                    Case "CD"

                        F.AppendFormat("{0}.[GRP_DIVISION],", OuterTableName)

                    Case "CDP"

                        F.AppendFormat("{0}.[GRP_PRODUCT],", OuterTableName)

                    Case "CDPJ"

                        F.AppendFormat("{0}.[GRP_JOB],", OuterTableName)

                    Case "CM"

                        F.AppendFormat("{0}.[GRP_CAMPAIGN],", OuterTableName)

                    Case "PST"

                        F.AppendFormat("{0}.[GRP_TASK],", OuterTableName)

                    Case "ES"

                        F.AppendFormat("{0}.[GRP_ESTIMATE],", OuterTableName)

                    Case "EST"

                        F.AppendFormat("{0}.[GRP_ESTIMATE_COMPONENT],", OuterTableName)

                    Case "DUE_DATE", "DUE_DATE_ASC"

                        F.AppendFormat("{0}.[GRP_DUE_DATE],", OuterTableName)
                        F.AppendFormat("{0}.[GRP_DUE_DATE_DISPLAY],", OuterTableName)

                    Case "ALERT_NOTIFY_NAME"

                        F.AppendFormat("{0}.[ALRT_NOTIFY_HDR_ID],", OuterTableName)
                        F.AppendFormat("{0}.[ALERT_NOTIFY_NAME],", OuterTableName)

                    Case "PRIORITY"

                        F.AppendFormat("{0}.[GRP_PRIORITY],", OuterTableName)

                    Case "AB"

                        F.AppendFormat("{0}.[GRP_ATB],", OuterTableName)

                    Case "LAST_UPD"

                        F.AppendFormat("{0}.[GRP_LAST_UPD],", OuterTableName)

                    Case "VER_BLD"

                        F.AppendFormat("{0}.[GRP_VER_BLD],", OuterTableName)

                End Select

                F.AppendFormat("{0}.[ID],", OuterTableName)
                F.AppendFormat("{0}.[IS_ASSIGNMENT],", OuterTableName)
                F.AppendFormat("{0}.[IS_WORK_ITEM],", OuterTableName)
                F.AppendFormat("{0}.[JOB_NUMBER],", OuterTableName)
                F.AppendFormat("{0}.[JOB_COMPONENT_NBR],", OuterTableName)
                F.AppendFormat("{0}.[TASK_SEQ_NBR],", OuterTableName)
                F.AppendFormat("{0}.[ALERT_LEVEL_TEXT],", OuterTableName)
                F.AppendFormat("{0}.[TIME_DUE],", OuterTableName)
                F.AppendFormat("{0}.[JOB_DESC],", OuterTableName)
                F.AppendFormat("{0}.[JOB_COMP_DESC],", OuterTableName)
                F.AppendFormat("{0}.[IS_DRAFT],", OuterTableName)
                F.AppendFormat("{0}.[CARD_SEQ_NBR],", OuterTableName)
                F.AppendFormat("{0}.[IS_DISMISSED],", OuterTableName)
                F.AppendFormat("{0}.[IS_CS_REVIEW],", OuterTableName)
                F.AppendFormat("{0}.[CS_PROJECT_ID],", OuterTableName)
                F.AppendFormat("{0}.[CS_REVIEW_ID],", OuterTableName)
                F.AppendFormat("{0}.[CS_NUM_REVIEWER],", OuterTableName)
                F.AppendFormat("{0}.[CS_NUM_CMPLT],", OuterTableName)
                F.AppendFormat("{0}.[CS_ASSET_IMG],", OuterTableName)
                F.AppendFormat("{0}.[CS_NUM_REJECT],", OuterTableName)
                F.AppendFormat("{0}.[CS_NUM_DEFER],", OuterTableName)
                F.AppendFormat("{0}.[CS_NUM_APPR],", OuterTableName)
                F.AppendFormat("ISNULL({0}.[CURRENT_RCPT], 0) AS CURRENT_RCPT,", OuterTableName)
                F.AppendFormat("{0}.[SPRINT_ID],", OuterTableName)
                F.AppendFormat("{0}.[END_SELECT_CLAUSE],", OuterTableName)
                F.AppendFormat("{0}.[TASK_STATUS],", OuterTableName)
                F.AppendFormat("{0}.[FNC_COMMENTS],", OuterTableName)
                F.AppendFormat("{0}.[TEMP_COMP_DATE],", OuterTableName)
                F.AppendFormat("{0}.[CHECK_LIST_TOTAL],", OuterTableName)
                F.AppendFormat("{0}.[CHECK_LIST_COMPLETE],", OuterTableName)
                F.AppendFormat("{0}.[ESTIMATE_NUMBER],", OuterTableName)
                F.AppendFormat("{0}.[EST_COMPONENT_NBR],", OuterTableName)

                If OuterTableName = "B" Then

                    F.AppendFormat("{0}.[READ_ALERT_TEXT]", OuterTableName)

                End If

            Else

                F.AppendFormat("{0}.[ALERT_ID],", OuterTableName)
                F.AppendFormat("{0}.[IS_ASSIGNMENT],", OuterTableName)
                F.AppendFormat("{0}.[CURRENT_NOTIFY_EMP_FML],", OuterTableName)
                F.AppendFormat("{0}.[CURRENT_NOTIFY_EMP_CODE],", OuterTableName)
                F.AppendFormat("{0}.[CURRENT_NOTIFY],", OuterTableName)
                F.AppendFormat("{0}.[CURRENT_RCPT],", OuterTableName)
                F.AppendFormat("{0}.[IS_CC],", OuterTableName)
                F.AppendFormat("{0}.[IS_WORK_ITEM],", OuterTableName)

            End If

            Return F.ToString

        End Function
        Private Function HasBoards(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim i As Integer = 0

            Try

                i = DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(1) FROM BOARD WITH(NOLOCK);").SingleOrDefault

            Catch ex As Exception
                i = 0
            End Try

            Return i > 0

        End Function

#End Region

#Region "Alerts & Assignments Manager"
        Public Function LoadAlertsAndAssignmentsManager(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem)

            Dim List As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SearchCriteriaSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim InboxTypeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim ShowAssignmentTypeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IsJobAlertsPageSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim StartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim EndDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IncludeCompletedAssignmentsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim GroupBySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim RecordsToReturnSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IsCountSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim RecordCountSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IncludeReviewsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IncludeBoardLevelSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IncludeBacklogSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim ShowOnlyTempCompSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim EmployeeRoleSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim DepartmentSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                    UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 100)
                    EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EmployeeCode", SqlDbType.VarChar, 140)
                    SearchCriteriaSqlParameter = New System.Data.SqlClient.SqlParameter("@SearchCriteria", SqlDbType.VarChar, 1000)
                    InboxTypeSqlParameter = New System.Data.SqlClient.SqlParameter("@InboxType", SqlDbType.VarChar, 50)
                    ShowAssignmentTypeSqlParameter = New System.Data.SqlClient.SqlParameter("@ShowAssignmentType", SqlDbType.VarChar, 50)
                    IsJobAlertsPageSqlParameter = New System.Data.SqlClient.SqlParameter("@IsJobAlertsPage", SqlDbType.Bit)
                    JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
                    JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)
                    StartDateSqlParameter = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime)
                    EndDateSqlParameter = New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime)
                    IncludeCompletedAssignmentsSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeCompletedAssignments", SqlDbType.Bit)
                    GroupBySqlParameter = New System.Data.SqlClient.SqlParameter("@GroupBy", SqlDbType.VarChar, 6)
                    RecordsToReturnSqlParameter = New System.Data.SqlClient.SqlParameter("@RecordsToReturn", SqlDbType.VarChar, 6)
                    IsCountSqlParameter = New System.Data.SqlClient.SqlParameter("@IsCount", SqlDbType.Bit)
                    RecordCountSqlParameter = New System.Data.SqlClient.SqlParameter("@RecordCount", SqlDbType.Int)
                    IncludeReviewsSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeReviews", SqlDbType.Bit)
                    IncludeBoardLevelSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeBoardLevel", SqlDbType.Bit)
                    IncludeBacklogSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeBacklog", SqlDbType.Bit)
                    ShowOnlyTempCompSqlParameter = New System.Data.SqlClient.SqlParameter("@ShowOnlyTempComp", SqlDbType.Bit)
                    EmployeeRoleSqlParameter = New System.Data.SqlClient.SqlParameter("@EmployeeRole", SqlDbType.VarChar, 140)
                    DepartmentSqlParameter = New System.Data.SqlClient.SqlParameter("@Department", SqlDbType.VarChar, 100)

                    UserCodeSqlParameter.Value = DbContext.UserCode
                    EmployeeCodeSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.EmployeeCode) = False, Filter.EmployeeCode, System.DBNull.Value)
                    SearchCriteriaSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.SearchCriteria) = False, Filter.SearchCriteria, System.DBNull.Value)
                    InboxTypeSqlParameter.Value = Filter.InboxType
                    ShowAssignmentTypeSqlParameter.Value = Filter.ShowAssignmentType
                    IsJobAlertsPageSqlParameter.Value = Filter.IsJobAlertsPage
                    JobNumberSqlParameter.Value = If(Filter.JobNumber IsNot Nothing AndAlso Filter.JobNumber > 0, Filter.JobNumber, System.DBNull.Value)
                    JobComponentNumberSqlParameter.Value = If(Filter.JobComponentNumber IsNot Nothing AndAlso Filter.JobComponentNumber > 0, Filter.JobComponentNumber, System.DBNull.Value)
                    StartDateSqlParameter.Value = If(Filter.StartDate IsNot Nothing, Filter.StartDate, "1/1/1950")
                    EndDateSqlParameter.Value = If(Filter.EndDate IsNot Nothing, Filter.EndDate, Date.Now.ToShortDateString)
                    IncludeCompletedAssignmentsSqlParameter.Value = Filter.IncludeCompletedAssignments
                    GroupBySqlParameter.Value = Filter.GroupBy
                    RecordsToReturnSqlParameter.Value = Filter.RecordsToReturn
                    IsCountSqlParameter.Value = Filter.IsCount
                    RecordCountSqlParameter.Value = Filter.RecordCount
                    IncludeReviewsSqlParameter.Value = Filter.IncludeReviews
                    IncludeBoardLevelSqlParameter.Value = Filter.IncludeBoardLevel
                    IncludeBacklogSqlParameter.Value = Filter.IncludeBacklog
                    ShowOnlyTempCompSqlParameter.Value = If(Filter.IsJobAlertsPage = True, False, Filter.ShowOnlyTempCompletedTasks)
                    EmployeeRoleSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.EmployeeRole) = False, Filter.EmployeeRole, System.DBNull.Value)
                    DepartmentSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.Department) = False, Filter.Department, System.DBNull.Value)

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem)(
"EXEC [dbo].[advsp_alert_aam] @UserCode,@EmployeeCode,@SearchCriteria,@InboxType,@ShowAssignmentType,@IsJobAlertsPage,@JobNumber,@JobComponentNumber,@StartDate,@EndDate,
@IncludeCompletedAssignments,@GroupBy,@RecordsToReturn,@IsCount,@RecordCount,@IncludeReviews,@IncludeBoardLevel,@IncludeBacklog,@ShowOnlyTempComp,@EmployeeRole,@Department;",
UserCodeSqlParameter,
EmployeeCodeSqlParameter,
SearchCriteriaSqlParameter,
InboxTypeSqlParameter,
ShowAssignmentTypeSqlParameter,
IsJobAlertsPageSqlParameter,
JobNumberSqlParameter,
JobComponentNumberSqlParameter,
StartDateSqlParameter,
EndDateSqlParameter,
IncludeCompletedAssignmentsSqlParameter,
GroupBySqlParameter,
RecordsToReturnSqlParameter,
IsCountSqlParameter,
RecordCountSqlParameter,
IncludeReviewsSqlParameter,
IncludeBoardLevelSqlParameter,
IncludeBacklogSqlParameter,
ShowOnlyTempCompSqlParameter,
EmployeeRoleSqlParameter,
DepartmentSqlParameter
).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.AlertsAndAssignmentsManagerItem)

            Return List

        End Function
        Public Function LoadAlertsAndAssignmentsManagerCP(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                        ByVal Filter As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerFilter,
                                                        ByRef ErrorMessage As String) As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem)

            Dim List As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem) = Nothing

            Try

                If Filter IsNot Nothing Then

                    Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim SearchCriteriaSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim InboxTypeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim ShowAssignmentTypeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IsJobAlertsPageSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim StartDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim EndDateSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IncludeCompletedAssignmentsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim GroupBySqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim RecordsToReturnSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IsCountSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim RecordCountSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IncludeReviewsSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IncludeBoardLevelSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim IncludeBacklogSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim ShowOnlyTempCompSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim EmployeeRoleSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim DepartmentSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                    Dim ClientContactIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing


                    UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 100)
                    EmployeeCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@EmployeeCode", SqlDbType.VarChar, 140)
                    SearchCriteriaSqlParameter = New System.Data.SqlClient.SqlParameter("@SearchCriteria", SqlDbType.VarChar, 1000)
                    InboxTypeSqlParameter = New System.Data.SqlClient.SqlParameter("@InboxType", SqlDbType.VarChar, 50)
                    ShowAssignmentTypeSqlParameter = New System.Data.SqlClient.SqlParameter("@ShowAssignmentType", SqlDbType.VarChar, 50)
                    IsJobAlertsPageSqlParameter = New System.Data.SqlClient.SqlParameter("@IsJobAlertsPage", SqlDbType.Bit)
                    JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobNumber", SqlDbType.Int)
                    JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)
                    StartDateSqlParameter = New System.Data.SqlClient.SqlParameter("@StartDate", SqlDbType.SmallDateTime)
                    EndDateSqlParameter = New System.Data.SqlClient.SqlParameter("@EndDate", SqlDbType.SmallDateTime)
                    IncludeCompletedAssignmentsSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeCompletedAssignments", SqlDbType.Bit)
                    GroupBySqlParameter = New System.Data.SqlClient.SqlParameter("@GroupBy", SqlDbType.VarChar, 6)
                    RecordsToReturnSqlParameter = New System.Data.SqlClient.SqlParameter("@RecordsToReturn", SqlDbType.VarChar, 6)
                    IsCountSqlParameter = New System.Data.SqlClient.SqlParameter("@IsCount", SqlDbType.Bit)
                    RecordCountSqlParameter = New System.Data.SqlClient.SqlParameter("@RecordCount", SqlDbType.Int)
                    IncludeReviewsSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeReviews", SqlDbType.Bit)
                    IncludeBoardLevelSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeBoardLevel", SqlDbType.Bit)
                    IncludeBacklogSqlParameter = New System.Data.SqlClient.SqlParameter("@IncludeBacklog", SqlDbType.Bit)
                    ShowOnlyTempCompSqlParameter = New System.Data.SqlClient.SqlParameter("@ShowOnlyTempComp", SqlDbType.Bit)
                    EmployeeRoleSqlParameter = New System.Data.SqlClient.SqlParameter("@EmployeeRole", SqlDbType.VarChar, 140)
                    DepartmentSqlParameter = New System.Data.SqlClient.SqlParameter("@Department", SqlDbType.VarChar, 100)
                    ClientContactIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ClientContactID", SqlDbType.VarChar, 140)

                    UserCodeSqlParameter.Value = DbContext.UserCode
                    EmployeeCodeSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.EmployeeCode) = False, Filter.EmployeeCode, System.DBNull.Value)
                    SearchCriteriaSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.SearchCriteria) = False, Filter.SearchCriteria, System.DBNull.Value)
                    InboxTypeSqlParameter.Value = Filter.InboxType
                    ShowAssignmentTypeSqlParameter.Value = Filter.ShowAssignmentType
                    IsJobAlertsPageSqlParameter.Value = Filter.IsJobAlertsPage
                    JobNumberSqlParameter.Value = If(Filter.JobNumber IsNot Nothing AndAlso Filter.JobNumber > 0, Filter.JobNumber, System.DBNull.Value)
                    JobComponentNumberSqlParameter.Value = If(Filter.JobComponentNumber IsNot Nothing AndAlso Filter.JobComponentNumber > 0, Filter.JobComponentNumber, System.DBNull.Value)
                    StartDateSqlParameter.Value = If(Filter.StartDate IsNot Nothing, Filter.StartDate, "1/1/1950")
                    EndDateSqlParameter.Value = If(Filter.EndDate IsNot Nothing, Filter.EndDate, Date.Now.ToShortDateString)
                    IncludeCompletedAssignmentsSqlParameter.Value = Filter.IncludeCompletedAssignments
                    GroupBySqlParameter.Value = Filter.GroupBy
                    RecordsToReturnSqlParameter.Value = Filter.RecordsToReturn
                    IsCountSqlParameter.Value = Filter.IsCount
                    RecordCountSqlParameter.Value = Filter.RecordCount
                    IncludeReviewsSqlParameter.Value = Filter.IncludeReviews
                    IncludeBoardLevelSqlParameter.Value = Filter.IncludeBoardLevel
                    IncludeBacklogSqlParameter.Value = Filter.IncludeBacklog
                    ShowOnlyTempCompSqlParameter.Value = If(Filter.IsJobAlertsPage = True, False, Filter.ShowOnlyTempCompletedTasks)
                    EmployeeRoleSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.EmployeeRole) = False, Filter.EmployeeRole, System.DBNull.Value)
                    DepartmentSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.Department) = False, Filter.Department, System.DBNull.Value)
                    ClientContactIDSqlParameter.Value = If(String.IsNullOrWhiteSpace(Filter.ClientContactID) = False, Filter.ClientContactID, System.DBNull.Value)

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerItem)(
"EXEC [dbo].[advsp_alert_aam_cp] @UserCode,@EmployeeCode,@SearchCriteria,@InboxType,@ShowAssignmentType,@IsJobAlertsPage,@JobNumber,@JobComponentNumber,@StartDate,@EndDate,
@IncludeCompletedAssignments,@GroupBy,@RecordsToReturn,@IsCount,@RecordCount,@IncludeReviews,@IncludeBoardLevel,@IncludeBacklog,@ShowOnlyTempComp,@EmployeeRole,@Department,@ClientContactID;",
UserCodeSqlParameter,
EmployeeCodeSqlParameter,
SearchCriteriaSqlParameter,
InboxTypeSqlParameter,
ShowAssignmentTypeSqlParameter,
IsJobAlertsPageSqlParameter,
JobNumberSqlParameter,
JobComponentNumberSqlParameter,
StartDateSqlParameter,
EndDateSqlParameter,
IncludeCompletedAssignmentsSqlParameter,
GroupBySqlParameter,
RecordsToReturnSqlParameter,
IsCountSqlParameter,
RecordCountSqlParameter,
IncludeReviewsSqlParameter,
IncludeBoardLevelSqlParameter,
IncludeBacklogSqlParameter,
ShowOnlyTempCompSqlParameter,
EmployeeRoleSqlParameter,
DepartmentSqlParameter,
ClientContactIDSqlParameter
).ToList

                Else

                    ErrorMessage = "No input object."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                List = Nothing
            End Try

            If List Is Nothing Then List = New List(Of Classes.AlertsAndAssignmentsManagerItem)

            Return List

        End Function
        Public Function GetAlertsAndAssignmentsManagerUserColumnSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                      ByVal GridName As String, ByVal UserCode As String) _
                        As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerGridColumnSetting)

            Dim List As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerGridColumnSetting) = Nothing

            Try

                Dim GridNameSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                GridNameSqlParameter = New System.Data.SqlClient.SqlParameter("@GRID_NAME", SqlDbType.VarChar, 100)
                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

                GridNameSqlParameter.Value = GridName
                UserCodeSqlParameter.Value = UserCode

                List = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerGridColumnSetting)(
                                                    "EXEC [dbo].[usp_wv_AAMGetColumnSettings] @GRID_NAME, @USER_CODE;",
                                                    GridNameSqlParameter, UserCodeSqlParameter).ToList

            Catch ex As Exception

            End Try

            If List Is Nothing Then List = New List(Of Classes.AlertsAndAssignmentsManagerGridColumnSetting)

            Return List

        End Function
        Public Function GetDateDiffAndWeekendStatus(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                                      ByVal DateValue As String, ByVal UserCode As String) _
                                                    As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerDateItem

            Dim Result As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerDateItem = Nothing

            Try

                Dim DateValueSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                DateValueSqlParameter = New System.Data.SqlClient.SqlParameter("@DATE_VALUE", SqlDbType.VarChar, 10)

                DateValueSqlParameter.Value = DateTime.Parse(DateValue).ToString("MM/dd/yyyy")

                Result = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerDateItem)(
                                                    "EXEC [dbo].[usp_wv_AAMGetDateDiffAndWeekendStatus] @DATE_VALUE;",
                                                    DateValueSqlParameter).SingleOrDefault

            Catch ex As Exception

            End Try

            Return Result

        End Function
        Public Function GetUserViewSettings(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal UserCode As String, ByVal ApplicationName As String) _
                                                    As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting)

            Dim UserSettings As Generic.List(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting) = Nothing

            Try

                Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ApplicationNameSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

                UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                ApplicationNameSqlParameter = New System.Data.SqlClient.SqlParameter("@APPLICATION_NAME", SqlDbType.VarChar, 200)

                UserCodeSqlParameter.Value = UserCode
                ApplicationNameSqlParameter.Value = ApplicationName

                UserSettings = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerUserViewSetting)(
                                                    "EXEC [dbo].[usp_wv_AAMGetUserViewSettings] @USER_CODE, @APPLICATION_NAME;",
                                                    UserCodeSqlParameter, ApplicationNameSqlParameter).ToList

            Catch ex As Exception

            End Try

            Return UserSettings

        End Function

#End Region

#Region " Assignments "
        Public Function GetAssignmentTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertID As Integer,
                                              ByVal DocumentID As Integer,
                                              ByVal AllEmployees As Boolean,
                                              ByRef ErrorMessage As String) As AdvantageFramework.ViewModels.Desktop.AlertAssignmentViewModel

            Dim Template As Template = Nothing
            Dim AlertAssignmentModel As AdvantageFramework.ViewModels.Desktop.AlertAssignmentViewModel = New ViewModels.Desktop.AlertAssignmentViewModel

            Try

                Template = DbContext.Database.SqlQuery(Of Template)(String.Format("SELECT TOP 1 [AlertTemplateID] = ANH.ALRT_NOTIFY_HDR_ID, [AlertTemplateName] = ANH.ALERT_NOTIFY_NAME FROM ALERT A WITH(NOLOCK) INNER JOIN ALERT_NOTIFY_HDR ANH WITH(NOLOCK) ON A.ALRT_NOTIFY_HDR_ID = ANH.ALRT_NOTIFY_HDR_ID WHERE A.ALERT_ID = {0}", AlertID)).SingleOrDefault

            Catch ex As Exception
                Template = Nothing
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If Template IsNot Nothing Then

                AlertAssignmentModel.AlertTemplateID = Template.AlertTemplateID
                AlertAssignmentModel.AlertTemplateName = Template.AlertTemplateName

                Dim AlertTemplateQueryResultViewModelList As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertTemplateQueryResultViewModel) = Nothing

                Try

                    AlertTemplateQueryResultViewModelList = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Desktop.AlertTemplateQueryResultViewModel)(String.Format("EXEC [dbo].[advsp_alert_load_assignment_template] {0}, 0, {1}, {2};",
                                                                                                                                                                                  AlertID,
                                                                                                                                                                                  If(AllEmployees = True, 1, 0),
                                                                                                                                                                                  If(DocumentID > 0, DocumentID, "NULL"))).ToList()

                    If AlertTemplateQueryResultViewModelList IsNot Nothing Then

                        Dim States As Generic.List(Of State) = Nothing

                        States = DbContext.Database.SqlQuery(Of State)(String.Format("EXEC [dbo].[advsp_alert_load_assignment_template] {0}, 1, {1}, {2};",
                                                                                     AlertID,
                                                                                     If(AllEmployees = True, 1, 0),
                                                                                     If(DocumentID > 0, DocumentID, "NULL"))).ToList()

                        If States IsNot Nothing Then

                            Dim StateViewModel As AdvantageFramework.ViewModels.Desktop.AlertStateViewModel = Nothing
                            Dim StateEmployeeViewModel As AdvantageFramework.ViewModels.Desktop.AlertStateEmployeeViewModel = Nothing
                            Dim Employees As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertStateEmployeeViewModel) = Nothing
                            Dim EmployeeViewModel As AdvantageFramework.ViewModels.Desktop.AlertStateEmployeeViewModel = Nothing

                            For Each State As State In States

                                StateViewModel = Nothing
                                StateViewModel = New ViewModels.Desktop.AlertStateViewModel

                                StateViewModel.AlertStateID = State.AlertStateId
                                StateViewModel.AlertStateName = State.AlertStateName
                                StateViewModel.CanEdit = State.CanEditStateEmployees

                                Employees = Nothing
                                Employees = (From Entity In AlertTemplateQueryResultViewModelList
                                             Where Entity.AlertStateID = State.AlertStateId
                                             Select New AdvantageFramework.ViewModels.Desktop.AlertStateEmployeeViewModel With {.EmployeeCode = Entity.EmployeeCode,
                                                                                                                                .FullName = Entity.EmployeeFullName,
                                                                                                                                .AlertTemplateID = Entity.AlertTemplateID,
                                                                                                                                .AlertStateID = Entity.AlertStateID,
                                                                                                                                .IsDefault = Entity.IsDefaultEmployee,
                                                                                                                                .IsSelected = Entity.IsEmployeeSelected,
                                                                                                                                .CanDelete = Entity.CanDeleteEmployee,
                                                                                                                                .ProofingStatusID = Entity.ProofingStatusID,
                                                                                                                                .StatusDate = Entity.ProofingStatusDate}).ToList()

                                If Employees IsNot Nothing Then

                                    StateViewModel.Employees = Employees

                                End If

                                AlertAssignmentModel.States.Add(StateViewModel)

                            Next

                        End If

                    End If

                Catch ex As Exception
                    ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                End Try

            End If

            Return AlertAssignmentModel

        End Function
        Public Class Template
            Public Property AlertTemplateID As Integer? = 0
            Public Property AlertTemplateName As String
            Sub New()

            End Sub
        End Class
        Public Class State
            Public Property AlertStateId As Integer? = 0
            Public Property AlertStateName As String
            Public Property StateOrder As Short? = 0
            Public Property IsCurrentState As Boolean? = False
            Public Property CanEditStateEmployees As Boolean? = False
            Sub New()

            End Sub
        End Class
        Public Function SaveTemplateToAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal AlertID As Integer,
                                                 ByVal AlertTemplateID As Integer,
                                                 ByRef ErrorMessage As String) As Boolean

            Dim Saved As Boolean = True
            Dim SqlParameterAlertID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterAlertTemplateID As System.Data.SqlClient.SqlParameter = Nothing

            Try

                SqlParameterAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                SqlParameterAlertTemplateID = New System.Data.SqlClient.SqlParameter("@ALRT_NOTIFY_HDR_ID", SqlDbType.Int)

                SqlParameterAlertID.Value = AlertID
                SqlParameterAlertTemplateID.Value = AlertTemplateID

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_alert_save_template_to_assignment] @ALERT_ID, @ALRT_NOTIFY_HDR_ID;",
                                                     SqlParameterAlertID,
                                                     SqlParameterAlertTemplateID)

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Saved = False
            End Try

            Return Saved

        End Function

#End Region

#End Region

#Region " In Out Service"
        Public Function CreateAlertForInOutService(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                                                 EmployeeCode As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim AlertUser As String = ""

            Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString()

                        ' AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.Alert.ToString))

                        'If AlertType IsNot Nothing Then

                        'AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ImportValidation.ImportResults.ToString))

                        'If AlertCategory IsNot Nothing Then

                        AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyForInOutServiceError()
                        AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertBodyForInOutServiceError()

                        AlertSubject = "In Out Board Service"

                        AlertUser = DbContext.UserCode

                        If AlertUser.Length = 0 Then

                            AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                        End If

                        Alert = New AdvantageFramework.Database.Entities.Alert
                        Alert.DbContext = DbContext
                        Alert.AlertTypeID = 6
                        Alert.AlertCategoryID = 25
                        Alert.Subject = AlertSubject
                        Alert.Body = AlertBody
                        Alert.GeneratedDate = Now
                        Alert.PriorityLevel = 3
                        Alert.EmployeeCode = EmployeeCode
                        Alert.UserCode = AlertUser
                        Alert.EmailBody = AlertEmailBody

                        If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                            If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                    EmployeeEmail = Employee.Email

                                End If

                                AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                            End If

                            If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Alert.EmailBody & "</body>", 2, SendingEmailStatus)

                            End If

                            AlertCreated = True

                        End If

                    Else

                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                        Console.WriteLine(AlertSubject)
                        Console.WriteLine(AlertBody)

                    End If

                    ' End If

                    '  End If

                End Using

            End Using

            CreateAlertForInOutService = AlertCreated

        End Function
        Private Function CreateAlertBodyForInOutServiceError()

            'objects
            Dim AlertBody As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                StringBuilder.AppendLine("In Out board update failed.  Please contact Advantage Software Support.")
                StringBuilder.AppendLine("")

                AlertBody = StringBuilder.ToString

            Catch ex As Exception
                AlertBody = ""
            Finally
                CreateAlertBodyForInOutServiceError = AlertBody
            End Try

        End Function

#End Region

#Region "  Nielsen Service "

#Region "  Alert "

        Public Function CreateAlertForNonHostedNielsenDataImport(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                                                 EmployeeCode As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim AlertUser As String = ""

            Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString()

                        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ImportValidation.ToString))

                        If AlertType IsNot Nothing Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ImportValidation.ImportResults.ToString))

                            If AlertCategory IsNot Nothing Then

                                AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyForNonHostedNielsenDataImportError()
                                AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyForNonHostedNielsenDataImportError()

                                AlertSubject = "Nielsen Service" & Space(1) & System.Environment.MachineName

                                AlertUser = DbContext.UserCode

                                If AlertUser.Length = 0 Then

                                    AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                                End If

                                Alert = New AdvantageFramework.Database.Entities.Alert

                                Alert.DbContext = DbContext
                                Alert.AlertTypeID = AlertType.ID
                                Alert.AlertCategoryID = AlertCategory.ID
                                Alert.Subject = AlertSubject
                                Alert.Body = AlertBody
                                Alert.GeneratedDate = Now
                                Alert.PriorityLevel = 3
                                Alert.EmployeeCode = EmployeeCode
                                Alert.UserCode = AlertUser
                                Alert.EmailBody = AlertEmailBody

                                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                    If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                        If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                            EmployeeEmail = Employee.Email

                                        End If

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                    End If

                                    If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                        AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Alert.EmailBody & "</body>", 2, SendingEmailStatus)

                                    End If

                                    AlertCreated = True

                                End If

                            Else

                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                                Console.WriteLine(AlertSubject)
                                Console.WriteLine(AlertBody)

                            End If

                        End If

                    End If

                End Using

            End Using

            CreateAlertForNonHostedNielsenDataImport = AlertCreated

        End Function
        Private Function CreateAlertBodyForNonHostedNielsenDataImportError()

            'objects
            Dim AlertBody As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                StringBuilder.AppendLine("Nielsen data download failed.  Please contact Advantage Software Support.")
                StringBuilder.AppendLine("")

                AlertBody = StringBuilder.ToString

            Catch ex As Exception
                AlertBody = ""
            Finally
                CreateAlertBodyForNonHostedNielsenDataImportError = AlertBody
            End Try

        End Function
        Public Function CreateAlertForNewNielsenData(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                                     EmployeeCode As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim AlertUser As String = ""

            Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString()

                        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ImportValidation.ToString))

                        If AlertType IsNot Nothing Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ImportValidation.ImportResults.ToString))

                            If AlertCategory IsNot Nothing Then

                                AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyForNewNielsenData()
                                AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyForNewNielsenData()

                                AlertSubject = "New Nielsen Data"

                                AlertUser = DbContext.UserCode

                                If AlertUser.Length = 0 Then

                                    AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                                End If

                                Alert = New AdvantageFramework.Database.Entities.Alert

                                Alert.DbContext = DbContext
                                Alert.AlertTypeID = AlertType.ID
                                Alert.AlertCategoryID = AlertCategory.ID
                                Alert.Subject = AlertSubject
                                Alert.Body = AlertBody
                                Alert.GeneratedDate = Now
                                Alert.PriorityLevel = 3
                                Alert.EmployeeCode = EmployeeCode
                                Alert.UserCode = AlertUser
                                Alert.EmailBody = AlertEmailBody

                                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                    If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                        If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                            EmployeeEmail = Employee.Email

                                        End If

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                    End If

                                    If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                        AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Alert.EmailBody & "</body>", 2, SendingEmailStatus)

                                    End If

                                    AlertCreated = True

                                End If

                            Else

                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                                Console.WriteLine(AlertSubject)
                                Console.WriteLine(AlertBody)

                            End If

                        End If

                    End If

                End Using

            End Using

            CreateAlertForNewNielsenData = AlertCreated

        End Function
        Private Function CreateAlertBodyForNewNielsenData()

            'objects
            Dim AlertBody As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                StringBuilder.AppendLine("Nielsen data has been imported successfully.")
                StringBuilder.AppendLine("")

                AlertBody = StringBuilder.ToString

            Catch ex As Exception
                AlertBody = ""
            Finally
                CreateAlertBodyForNewNielsenData = AlertBody
            End Try

        End Function

#End Region

#Region "  Email "

        Private Function CreateAlertEmailBodyForNonHostedNielsenDataImportError()

            'objects
            Dim AlertEmailBody As String = ""

            Try

                AlertEmailBody = "Nielsen data download failed.  Please contact Advantage Software Support."

            Catch ex As Exception
                AlertEmailBody = ""
            Finally
                CreateAlertEmailBodyForNonHostedNielsenDataImportError = AlertEmailBody
            End Try

        End Function
        Private Function CreateAlertEmailBodyForNewNielsenData()

            'objects
            Dim AlertEmailBody As String = ""

            Try

                AlertEmailBody = "Nielsen data has been imported successfully."

            Catch ex As Exception
                AlertEmailBody = ""
            Finally
                CreateAlertEmailBodyForNewNielsenData = AlertEmailBody
            End Try

        End Function

#End Region

#End Region

#Region "  ComScore Service "

#Region "  Alert "
        Public Function CreateAlertForComscoreImport(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                                     EmployeeCode As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim AlertUser As String = ""

            Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString()

                        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ImportValidation.ToString))

                        If AlertType IsNot Nothing Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ImportValidation.ImportResults.ToString))

                            If AlertCategory IsNot Nothing Then

                                AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyForComscoreImportError()
                                AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyForComscoreImportError()

                                AlertSubject = "Comscore Service"

                                AlertUser = DbContext.UserCode

                                If AlertUser.Length = 0 Then

                                    AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                                End If

                                Alert = New AdvantageFramework.Database.Entities.Alert

                                Alert.DbContext = DbContext
                                Alert.AlertTypeID = AlertType.ID
                                Alert.AlertCategoryID = AlertCategory.ID
                                Alert.Subject = AlertSubject
                                Alert.Body = AlertBody
                                Alert.GeneratedDate = Now
                                Alert.PriorityLevel = 3
                                Alert.EmployeeCode = EmployeeCode
                                Alert.UserCode = AlertUser
                                Alert.EmailBody = AlertEmailBody

                                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                    If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                        If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                            EmployeeEmail = Employee.Email

                                        End If

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                    End If

                                    If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                        AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Alert.EmailBody & "</body>", 2, SendingEmailStatus)

                                    End If

                                    AlertCreated = True

                                End If

                            Else

                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                                Console.WriteLine(AlertSubject)
                                Console.WriteLine(AlertBody)

                            End If

                        End If

                    End If

                End Using

            End Using

            CreateAlertForComscoreImport = AlertCreated

        End Function
        Private Function CreateAlertBodyForComscoreImportError()

            'objects
            Dim AlertBody As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                StringBuilder.AppendLine("Comscore data download failed.  Please contact Advantage Software Support.")
                StringBuilder.AppendLine("")

                AlertBody = StringBuilder.ToString

            Catch ex As Exception
                AlertBody = ""
            Finally
                CreateAlertBodyForComscoreImportError = AlertBody
            End Try

        End Function

#End Region

#Region "  Email "
        Private Function CreateAlertEmailBodyForComscoreImportError()

            'objects
            Dim AlertEmailBody As String = ""

            Try

                AlertEmailBody = "Comscore data download failed.  Please contact Advantage Software Support."

            Catch ex As Exception
                AlertEmailBody = ""
            Finally
                CreateAlertEmailBodyForComscoreImportError = AlertEmailBody
            End Try

        End Function

#End Region

#End Region

#Region "  Nielsen Puerto Rico Service "

#Region "  Alert "

        Public Function CreateAlertForNonHostedNielsenPuertoRicoDataImport(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                                                           EmployeeCode As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim AlertUser As String = ""

            Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString()

                        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ImportValidation.ToString))

                        If AlertType IsNot Nothing Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ImportValidation.ImportResults.ToString))

                            If AlertCategory IsNot Nothing Then

                                AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyForNonHostedNielsenPuertoRicoDataImportError()
                                AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyForNonHostedNielsenPuertoRicoDataImportError()

                                AlertSubject = "Nielsen Puerto Rico Service" & Space(1) & System.Environment.MachineName

                                AlertUser = DbContext.UserCode

                                If AlertUser.Length = 0 Then

                                    AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                                End If

                                Alert = New AdvantageFramework.Database.Entities.Alert

                                Alert.DbContext = DbContext
                                Alert.AlertTypeID = AlertType.ID
                                Alert.AlertCategoryID = AlertCategory.ID
                                Alert.Subject = AlertSubject
                                Alert.Body = AlertBody
                                Alert.GeneratedDate = Now
                                Alert.PriorityLevel = 3
                                Alert.EmployeeCode = EmployeeCode
                                Alert.UserCode = AlertUser
                                Alert.EmailBody = AlertEmailBody

                                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                    If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                        If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                            EmployeeEmail = Employee.Email

                                        End If

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                    End If

                                    If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                        AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Alert.EmailBody & "</body>", 2, SendingEmailStatus)

                                    End If

                                    AlertCreated = True

                                End If

                            Else

                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                                Console.WriteLine(AlertSubject)
                                Console.WriteLine(AlertBody)

                            End If

                        End If

                    End If

                End Using

            End Using

            CreateAlertForNonHostedNielsenPuertoRicoDataImport = AlertCreated

        End Function
        Private Function CreateAlertBodyForNonHostedNielsenPuertoRicoDataImportError()

            'objects
            Dim AlertBody As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                StringBuilder.AppendLine("Nielsen Puerto Rico data download failed.  Please contact Advantage Software Support.")
                StringBuilder.AppendLine("")

                AlertBody = StringBuilder.ToString

            Catch ex As Exception
                AlertBody = ""
            Finally
                CreateAlertBodyForNonHostedNielsenPuertoRicoDataImportError = AlertBody
            End Try

        End Function
        Public Function CreateAlertForNewNielsenPuertoRicoData(DatabaseProfile As AdvantageFramework.Database.DatabaseProfile,
                                                               EmployeeCode As String) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AlertType As AdvantageFramework.Database.Entities.AlertType = Nothing
            Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory = Nothing
            Dim EmployeeEmail As String = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = AdvantageFramework.Email.SendingEmailStatus.FailedToLoadSettings
            Dim AlertBody As String = ""
            Dim AlertEmailBody As String = ""
            Dim AlertSubject As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeName As String = ""
            Dim AlertUser As String = ""

            Using DbContext As New AdvantageFramework.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeName = Employee.ToString()

                        AlertType = AdvantageFramework.Database.Procedures.AlertType.LoadByAlertTypeDescription(DbContext, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.AlertType.ImportValidation.ToString))

                        If AlertType IsNot Nothing Then

                            AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByAlertTypeIDAndAlertCategoryDescription(DbContext, AlertType.ID, AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.AlertSystem.ImportValidation.ImportResults.ToString))

                            If AlertCategory IsNot Nothing Then

                                AlertBody = AdvantageFramework.AlertSystem.CreateAlertBodyForNewNielsenPuertoRicoData()
                                AlertEmailBody = AdvantageFramework.AlertSystem.CreateAlertEmailBodyForNewNielsenPuertoRicoData()

                                AlertSubject = "New Nielsen Puerto Rico Data"

                                AlertUser = DbContext.UserCode

                                If AlertUser.Length = 0 Then

                                    AlertUser = My.User.Name.Substring(My.User.Name.LastIndexOf("\") + 1)

                                End If

                                Alert = New AdvantageFramework.Database.Entities.Alert

                                Alert.DbContext = DbContext
                                Alert.AlertTypeID = AlertType.ID
                                Alert.AlertCategoryID = AlertCategory.ID
                                Alert.Subject = AlertSubject
                                Alert.Body = AlertBody
                                Alert.GeneratedDate = Now
                                Alert.PriorityLevel = 3
                                Alert.EmployeeCode = EmployeeCode
                                Alert.UserCode = AlertUser
                                Alert.EmailBody = AlertEmailBody

                                If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                                    If CheckEmployeeAlertNotificationForAlert(Employee) Then

                                        If Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                                            EmployeeEmail = Employee.Email

                                        End If

                                        AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Alert.ID, Employee.Code, EmployeeEmail, Nothing, Nothing, Nothing, Nothing)

                                    End If

                                    If CheckEmployeeAlertNotificationForEmail(Employee) Then

                                        AdvantageFramework.Email.Send(DbContext, SecurityDbContext, Employee, Alert.Subject, "<body bgcolor=""#FFFFFF"">" & Alert.EmailBody & "</body>", 2, SendingEmailStatus)

                                    End If

                                    AlertCreated = True

                                End If

                            Else

                                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------")
                                Console.WriteLine(AlertSubject)
                                Console.WriteLine(AlertBody)

                            End If

                        End If

                    End If

                End Using

            End Using

            CreateAlertForNewNielsenPuertoRicoData = AlertCreated

        End Function
        Private Function CreateAlertBodyForNewNielsenPuertoRicoData()

            'objects
            Dim AlertBody As String = ""
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                StringBuilder.AppendLine("Nielsen Puerto Rico data has been imported successfully.")
                StringBuilder.AppendLine("")

                AlertBody = StringBuilder.ToString

            Catch ex As Exception
                AlertBody = ""
            Finally
                CreateAlertBodyForNewNielsenPuertoRicoData = AlertBody
            End Try

        End Function

#End Region

#Region "  Email "

        Private Function CreateAlertEmailBodyForNonHostedNielsenPuertoRicoDataImportError()

            'objects
            Dim AlertEmailBody As String = ""

            Try

                AlertEmailBody = "Nielsen Puerto Rico data download failed.  Please contact Advantage Software Support."

            Catch ex As Exception
                AlertEmailBody = ""
            Finally
                CreateAlertEmailBodyForNonHostedNielsenPuertoRicoDataImportError = AlertEmailBody
            End Try

        End Function
        Private Function CreateAlertEmailBodyForNewNielsenPuertoRicoData()

            'objects
            Dim AlertEmailBody As String = ""

            Try

                AlertEmailBody = "Nielsen Puerto Rico data has been imported successfully."

            Catch ex As Exception
                AlertEmailBody = ""
            Finally
                CreateAlertEmailBodyForNewNielsenPuertoRicoData = AlertEmailBody
            End Try

        End Function

#End Region

#End Region

    End Module

End Namespace
