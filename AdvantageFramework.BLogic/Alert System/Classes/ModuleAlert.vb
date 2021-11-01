Namespace AlertSystem.Classes

    <Serializable()> Public Class ModuleAlerts
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Alerts
            Title
            Level
            AlertsToDisplay
            IncludeCompletedAssignments
            IncludeTasksWithSchedule
            GroupBy

        End Enum

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Alerts As Generic.List(Of SimpleAlert)

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Title As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Level As AdvantageFramework.Database.Entities.AlertListLevel = AdvantageFramework.Database.Entities.AlertListLevel.NotSet

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AlertsToDisplay As AdvantageFramework.Database.Entities.AlertListShowAlertType = AdvantageFramework.Database.Entities.AlertListShowAlertType.AllAlertsAndAssignments

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeCompletedAssignments As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IncludeTasksWithSchedule As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GroupBy As AdvantageFramework.Database.Entities.AlertListGrouping = AdvantageFramework.Database.Entities.AlertListGrouping.None

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Private Property _ConnectionString As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Private Property _UserCode As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Private Property _EmployeeCode As String = ""

#End Region

#Region " Variables "

        Public JobNumber As Integer = 0
        Public JobComponentNumber As Integer = 0
        Public TaskSequenceNumber As Integer = 0
        Public CampaignID As Integer = 0

        Public EstimateNumber As Integer = 0
        Public EstimateComponentNumber As Integer = 0
        Public EstimateQuoteNumber As Integer = 0
        Public EstimateSelectedQuotes As String = ""
        Public EstimatePrintAll As Boolean = False

        Public MediaATBRevisionID As Integer = 0
        Public MediaATBNumber As Integer = 0
        Public MediaATBRevisionNumber As Integer = 0

        Public AccountsPayableID As Integer = 0
        Public AccountsPayableSequenceNumber As Integer = 0

        Public PurchaseOrderNumber As Integer = 0

#End Region

#Region " Methods "

        Sub Load()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)

                Dim EntityAlerts As Generic.List(Of AdvantageFramework.Database.Entities.Alert) = Nothing
                Dim Employees As Generic.List(Of AdvantageFramework.Security.Database.Views.Employee) = Nothing

                Select Case Me.Level

                    Case AdvantageFramework.Database.Entities.AlertListLevel.Campaign

                        Try

                            Dim cmp As AdvantageFramework.Database.Entities.Campaign = Nothing
                            cmp = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, Me.CampaignID)

                            If Not cmp Is Nothing Then

                                Me.Title = "Campaign: " & Me.CampaignID.ToString().PadLeft(6, "0") & " - " & cmp.Name
                                cmp = Nothing

                            End If

                        Catch ex As Exception

                            Me.Title = "Alert List"

                        End Try

                        EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                        Where Entity.CampaignID = Me.CampaignID).ToList()


                    Case AdvantageFramework.Database.Entities.AlertListLevel.EstimateComponent, AdvantageFramework.Database.Entities.AlertListLevel.Estimate, AdvantageFramework.Database.Entities.AlertListLevel.EstimateQuote

                        Try

                            Me.Title = "Estimate Component: " & Me.EstimateNumber.ToString().PadLeft(6, "0") & "/" & Me.EstimateComponentNumber.ToString().PadLeft(2, "0") & " - " &
                                        DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(EST_COMP_DESC, '') FROM ESTIMATE_COMPONENT WITH(NOLOCK) WHERE ESTIMATE_NUMBER = {0} AND EST_COMPONENT_NBR = {1}", Me.EstimateNumber, Me.EstimateComponentNumber)).SingleOrDefault().ToString()

                        Catch ex As Exception

                            Me.Title = "Alert List"

                        End Try

                        EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                        Where Entity.EstimateNumber = Me.EstimateNumber _
                                        And Entity.EstimateComponentNumber = Me.EstimateComponentNumber).ToList()

                    Case AdvantageFramework.Database.Entities.AlertListLevel.Job

                        Try

                            Dim jo As AdvantageFramework.Database.Entities.Job = Nothing
                            jo = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNumber)

                            If Not jo Is Nothing Then

                                Me.Title = "Job: " & Me.JobNumber.ToString().PadLeft(6, "0") & " - " & jo.Description
                                jo = Nothing

                            End If

                        Catch ex As Exception

                            Me.Title = "Alert List"

                        End Try

                        EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                        Where Entity.JobNumber = Me.JobNumber _
                                        And (Entity.AlertLevel = "JO" OrElse Entity.AlertLevel = "JJ")).ToList()

                    Case AdvantageFramework.Database.Entities.AlertListLevel.JobComponent

                        Try

                            Dim jc As AdvantageFramework.Database.Entities.JobComponent = Nothing
                            jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNumber)

                            If Not jc Is Nothing Then

                                Me.Title = "Job Component: " & Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & jc.Description
                                jc = Nothing

                            End If

                        Catch ex As Exception

                            Me.Title = "Alert List"

                        End Try

                        EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                        Where Entity.JobNumber = Me.JobNumber _
                                        And Entity.JobComponentNumber = Me.JobComponentNumber _
                                        And (Entity.AlertLevel = "JO" OrElse Entity.AlertLevel = "JJ" OrElse Entity.AlertLevel = "JC")).ToList()

                    Case AdvantageFramework.Database.Entities.AlertListLevel.MediaATB

                        Try

                            Dim matbr As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
                            matbr = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, Me.MediaATBNumber, Me.MediaATBRevisionNumber)

                            If Not matbr Is Nothing Then

                                Me.MediaATBRevisionID = matbr.RevisionID

                                Me.Title = "Authorization to Buy Media: " & Me.MediaATBNumber.ToString().PadLeft(6, "0") & "/" & Me.MediaATBRevisionNumber.ToString().PadLeft(2, "0") & " " & matbr.Description

                                matbr = Nothing

                            End If

                        Catch ex As Exception

                            Me.Title = "Alert List"

                        End Try

                        EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                        Where Entity.MediaATBRevisionID = Me.MediaATBRevisionID).ToList()

                    Case AdvantageFramework.Database.Entities.AlertListLevel.ProjectSchedule

                        Try

                            Dim jc As AdvantageFramework.Database.Entities.JobComponent = Nothing
                            jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNumber)

                            If Not jc Is Nothing Then

                                Me.Title = "Project Schedule: " & Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & jc.Description
                                jc = Nothing

                            End If

                        Catch ex As Exception

                            Me.Title = "Alert List"

                        End Try

                        If Me.IncludeTasksWithSchedule = True Then

                            EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                            Where Entity.JobNumber = Me.JobNumber _
                                            And Entity.JobComponentNumber = Me.JobComponentNumber _
                                            And Entity.AlertLevel = "PS" OrElse Entity.AlertLevel = "PST").ToList()

                        Else

                            EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                            Where Entity.JobNumber = Me.JobNumber _
                                            And Entity.JobComponentNumber = Me.JobComponentNumber _
                                            And Entity.AlertLevel = "PS").ToList()

                        End If

                    Case AdvantageFramework.Database.Entities.AlertListLevel.ProjectScheduleTask

                        Try

                            Dim pst As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
                            pst = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, Me.JobNumber, Me.JobComponentNumber, Me.TaskSequenceNumber)

                            If Not pst Is Nothing Then

                                Me.Title = "Task: " & Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNumber.ToString().PadLeft(2, "0") & "/" &
                                    Me.TaskSequenceNumber.ToString().PadLeft(2, "0") & " - " & pst.Description
                                pst = Nothing

                            End If

                        Catch ex As Exception

                            Me.Title = "Alert List"

                        End Try

                        EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                        Where Entity.JobNumber = Me.JobNumber _
                                        And Entity.JobComponentNumber = Me.JobComponentNumber _
                                        And Entity.TaskSequenceNumber = Me.TaskSequenceNumber _
                                        And Entity.AlertLevel = "PST").ToList()

                    Case AdvantageFramework.Database.Entities.AlertListLevel.PurchaseOrder

                        Try

                            Dim po As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
                            po = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, Me.PurchaseOrderNumber)

                            If Not po Is Nothing Then

                                Me.Title = "Purchase Order: " & Me.PurchaseOrderNumber.ToString().PadLeft(6, "0") & " - " & po.Description
                                po = Nothing

                            End If

                        Catch ex As Exception

                            Me.Title = "Alert List"

                        End Try

                        EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                        Where Entity.PONumber = Me.PurchaseOrderNumber).ToList()

                End Select

                If Me.JobNumber > 0 AndAlso Me.JobComponentNumber > 0 Then

                    Try

                        Dim jc As AdvantageFramework.Database.Entities.JobComponent = Nothing
                        jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNumber)

                        If Not jc Is Nothing Then

                            Me.Title = "Job Component: " & Me.JobNumber.ToString().PadLeft(6, "0") & "/" & Me.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & jc.Description
                            jc = Nothing

                        End If

                    Catch ex As Exception

                        Me.Title = "Alert List"

                    End Try
                    EntityAlerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments")
                                    Where (Entity.JobNumber = Me.JobNumber And Entity.JobComponentNumber Is Nothing) _
                                      Or (Entity.JobNumber = Me.JobNumber And Entity.JobComponentNumber = Me.JobComponentNumber)).ToList()

                End If

                If Not EntityAlerts Is Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me._ConnectionString, Me._UserCode)

                        Employees = AdvantageFramework.Security.Database.Procedures.EmployeeView.Load(SecurityDbContext).Include("Users").ToList()

                    End Using

                    Dim GroupingList As New Generic.List(Of SimpleLookup)

                    Select Case Me.GroupBy

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Category


                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Office

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = OFFICE_CODE, [Key2] = '', [Key3] = '', [IntKey1] = 0, [IntKey2] = 0, [IntKey3] = 0, [Text] = OFFICE_NAME FROM [dbo].[OFFICE] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Client

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = CL_CODE, [Key2] = '', [Key3] = '', [IntKey1] = 0, [IntKey2] = 0, [IntKey3] = 0, [Text] = CL_NAME FROM [dbo].[CLIENT] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Division

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = CL_CODE, [Key2] = DIV_CODE, [Key3] = '', [IntKey1] = 0, [IntKey2] = 0, [IntKey3] = 0, [Text] = DIV_NAME FROM [dbo].[DIVISION] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Product

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = CL_CODE, [Key2] = DIV_CODE, [Key3] = PRD_CODE, [IntKey1] = 0, [IntKey2] = 0, [IntKey3] = 0, [Text] = PRD_DESCRIPTION FROM [dbo].[PRODUCT] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Campaign

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = CMP_CODE, [Key2] = '', [Key3] = '', [IntKey1] = CMP_IDENTIFIER, [IntKey2] = 0, [IntKey3] = 0, [Text] = CMP_NAME FROM [dbo].[CAMPAIGN] WITH(NOLOCK);").ToList()

                            'Case AdvantageFramework.Database.Entities.AlertListGrouping.Estimate

                            '    GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = '', [Key2] = '', [Key3] = '', [IntKey1] = ESTIMATE_NUMBER, [IntKey2] = 0, [IntKey3] = 0, [Text] = EST_LOG_DESC FROM [dbo].[ESTIMATE_LOG] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.EstimateComponent, Database.Entities.AlertListGrouping.Estimate

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = '', [Key2] = '', [Key3] = '', [IntKey1] = ESTIMATE_NUMBER, [IntKey2] = EST_COMPONENT_NBR, [IntKey3] = 0, [Text] = EST_COMP_DESC FROM [dbo].[ESTIMATE_COMPONENT] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Job

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = '', [Key2] = '', [Key3] = '', [IntKey1] = JOB_NUMBER, [IntKey2] = 0, [IntKey3] = 0, [Text] = JOB_DESC FROM [dbo].[JOB_LOG] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.JobComponent

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = '', [Key2] = '', [Key3] = '', [IntKey1] = JOB_NUMBER, [IntKey2] = JOB_COMPONENT_NBR, [IntKey3] = 0, [Text] = JOB_COMP_DESC FROM [dbo].[JOB_COMPONENT] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Task

                            'GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = '', [Key2] = '', [Key3] = '', [IntKey1] = JOB_NUMBER, [IntKey2] = JOB_COMPONENT_NBR, [IntKey3] = SEQ_NBR, [Text] = TASK_DESCRIPTION FROM [dbo].[JOB_TRAFFIC_DET] WITH(NOLOCK);").ToList()
                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)(String.Format("SELECT [Key1] = '', [Key2] = '', [Key3] = '', [IntKey1] = JOB_NUMBER, [IntKey2] = JOB_COMPONENT_NBR, [IntKey3] = SEQ_NBR, [Text] = TASK_DESCRIPTION FROM [dbo].[JOB_TRAFFIC_DET] WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1};"), Me.JobNumber, Me.JobComponentNumber).ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Template

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = '', [Key2] = '', [Key3] = '', [IntKey1] = ALRT_NOTIFY_HDR_ID, [IntKey2] = 0, [IntKey3] = 0, [Text] = ALERT_NOTIFY_NAME FROM [dbo].[ALERT_NOTIFY_HDR] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.AuthorizationToBuy

                            GroupingList = DbContext.Database.SqlQuery(Of SimpleLookup)("SELECT [Key1] = '', [Key2] = '', [Key3] = '', [IntKey1] = ATB_REV_ID, [IntKey2] = ATB_NUMBER, [IntKey3] = REV_NBR, [Text] = ATB_DESCRIPTION FROM [dbo].[ATB_REV] WITH(NOLOCK);").ToList()

                        Case AdvantageFramework.Database.Entities.AlertListGrouping.State



                        Case AdvantageFramework.Database.Entities.AlertListGrouping.DueDate



                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Priority



                        Case AdvantageFramework.Database.Entities.AlertListGrouping.Level



                    End Select

                    Dim result As SimpleLookup
                    Dim AlertLevels As New Dictionary(Of String, String)
                    AlertLevels = AdvantageFramework.AlertSystem.LoadAlertLevels()

                    For Each Alert As AdvantageFramework.Database.Entities.Alert In EntityAlerts

                        result = Nothing

                        Dim NewSimpleAlert As New SimpleAlert()
                        NewSimpleAlert.ProcessAlert(Alert, Me._EmployeeCode)

                        If NewSimpleAlert.IsAssignment = True And NewSimpleAlert.IsCompleted = False And NewSimpleAlert.IsUnAssigned = False Then

                            NewSimpleAlert.CurrentlyAssignedTo = Employees.SingleOrDefault(Function(Entity) Entity.Code = NewSimpleAlert.CurrentlyAssignedTo).ToString()

                        End If

                        If NewSimpleAlert.LastUpdatedBy IsNot Nothing Then

                            Try

                                NewSimpleAlert.LastUpdatedBy = Employees.FirstOrDefault(Function(Entity) Entity.Users.Any(Function(User) User.UserCode.ToUpper = NewSimpleAlert.LastUpdatedBy.ToUpper) = True).ToString()

                            Catch ex As Exception

                            End Try
                            
                        End If
                        
                        NewSimpleAlert.AlertLevel = Alert.AlertLevel
                        NewSimpleAlert.Sort = 1

                        If Alert.AlertLevel IsNot Nothing AndAlso Alert.AlertLevel <> "" Then

                            AlertLevels.TryGetValue(Alert.AlertLevel, NewSimpleAlert.AlertLevelText)

                            'Select Case Me.Level
                            '    Case Database.Entities.AlertListLevel.AccountsPayable
                            '        If Alert.AlertLevel = "AP" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.Campaign
                            '        If Alert.AlertLevel = "CM" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.Estimate
                            '        If Alert.AlertLevel = "ES" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.EstimateComponent
                            '        If Alert.AlertLevel = "EST" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.EstimateQuote
                            '        If Alert.AlertLevel = "EST" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.Job
                            '        If Alert.AlertLevel = "JO" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.JobComponent
                            '        If Alert.AlertLevel = "JC" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.MediaATB
                            '        If Alert.AlertLevel = "AB" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.ProjectSchedule
                            '        If Alert.AlertLevel = "PS" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.ProjectScheduleTask
                            '        If Alert.AlertLevel = "PST" Then NewSimpleAlert.Sort = 0
                            '    Case Database.Entities.AlertListLevel.PurchaseOrder
                            '        If Alert.AlertLevel = "PO" Then NewSimpleAlert.Sort = 0
                            'End Select

                        End If

                        If Not GroupingList Is Nothing Then

                            Select Case Me.GroupBy
                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Category

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Office

                                    If Not Alert.OfficeCode Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.Key1 = Alert.OfficeCode)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Client

                                    If Not Alert.ClientCode Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.Key1 = Alert.ClientCode)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = Alert.ClientCode & " - " & result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Division

                                    If Not Alert.ClientCode Is Nothing AndAlso Not Alert.DivisionCode Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.Key1 = Alert.ClientCode AndAlso Entity.Key2 = Alert.DivisionCode)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = Alert.ClientCode & ", " & Alert.DivisionCode & " - " & result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Product

                                    If Not Alert.ClientCode Is Nothing AndAlso Not Alert.DivisionCode Is Nothing AndAlso Not Alert.ProductCode Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.Key1 = Alert.ClientCode AndAlso Entity.Key2 = Alert.DivisionCode AndAlso Entity.Key3 = Alert.ProductCode)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = Alert.ClientCode & ", " & Alert.DivisionCode & ", " & Alert.ProductCode & " - " & result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Campaign

                                    If Not Alert.CampaignID Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.IntKey1 = Alert.CampaignID)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = result.Key1 & " - " & result.Text

                                    End If

                                    'Case AdvantageFramework.Database.Entities.AlertListGrouping.Estimate

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.EstimateComponent, Database.Entities.AlertListGrouping.Estimate

                                    If Not Alert.EstimateNumber Is Nothing AndAlso Not Alert.EstimateComponentNumber Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.IntKey1 = Alert.EstimateNumber AndAlso Entity.IntKey2 = Alert.EstimateComponentNumber)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = result.IntKey1.ToString().PadLeft(6, "0") & "/" & result.IntKey2.ToString().PadLeft(2, "0") & " - " & result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Job

                                    If Not Alert.JobNumber Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.IntKey1 = Alert.JobNumber)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = result.IntKey1.ToString().PadLeft(6, "0") & " - " & result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.JobComponent

                                    If Not Alert.JobNumber Is Nothing AndAlso Not Alert.JobComponentNumber Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.IntKey1 = Alert.JobNumber AndAlso Entity.IntKey2 = Alert.JobComponentNumber)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = result.IntKey1.ToString().PadLeft(6, "0") & "/" & result.IntKey2.ToString().PadLeft(2, "0") & " - " & result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Task

                                    If Not Alert.JobNumber Is Nothing AndAlso Not Alert.JobComponentNumber Is Nothing AndAlso Not Alert.TaskSequenceNumber Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.IntKey1 = Alert.JobNumber AndAlso Entity.IntKey2 = Alert.JobComponentNumber AndAlso Entity.IntKey3 = Alert.TaskSequenceNumber)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Template

                                    If Not Alert.AlertAssignmentTemplateID Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.IntKey1 = Alert.AlertAssignmentTemplateID)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.State

                                    NewSimpleAlert.GroupingText = NewSimpleAlert.State

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.DueDate

                                    If Not Alert.DueDate Is Nothing Then NewSimpleAlert.GroupingText = CType(Alert.DueDate, Date).ToShortDateString()

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Priority

                                    NewSimpleAlert.GroupingText = NewSimpleAlert.PriorityString

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.AuthorizationToBuy

                                    If Not Alert.MediaATBRevisionID Is Nothing Then

                                        result = GroupingList.SingleOrDefault(Function(Entity) Entity.IntKey1 = Alert.MediaATBRevisionID)

                                    End If
                                    If Not result Is Nothing AndAlso Not result.Text Is Nothing Then

                                        NewSimpleAlert.GroupingText = result.Text

                                    End If

                                Case AdvantageFramework.Database.Entities.AlertListGrouping.Level

                                    NewSimpleAlert.GroupingText = NewSimpleAlert.AlertLevelText

                            End Select

                        End If

                        Alerts.Add(NewSimpleAlert)

                        NewSimpleAlert = Nothing

                    Next

                End If

                If Not Alerts Is Nothing Then

                    Select Case Me.AlertsToDisplay
                        Case AdvantageFramework.Database.Entities.AlertListShowAlertType.AllAlerts

                            Alerts = (From SimpleAlert In Alerts _
                                      Where SimpleAlert.IsAssignment = False _
                                      Order By SimpleAlert.LastUpdated).ToList()

                        Case AdvantageFramework.Database.Entities.AlertListShowAlertType.MyAssignments

                            Alerts = (From SimpleAlert In Alerts _
                                      Where SimpleAlert.IsAssignment = True _
                                      AndAlso SimpleAlert.IsMine = True _
                                      Order By SimpleAlert.LastUpdated).ToList()

                        Case AdvantageFramework.Database.Entities.AlertListShowAlertType.AllAssignments

                            Alerts = (From SimpleAlert In Alerts _
                                      Where SimpleAlert.IsAssignment = True _
                                      Order By SimpleAlert.LastUpdated).ToList()

                        Case AdvantageFramework.Database.Entities.AlertListShowAlertType.Unassigned

                            Alerts = (From SimpleAlert In Alerts _
                                      Where SimpleAlert.IsUnAssigned = True _
                                      Order By SimpleAlert.LastUpdated).ToList()

                    End Select

                    If IncludeCompletedAssignments = False Then

                        Alerts = (From SimpleAlert In Alerts _
                                  Where SimpleAlert.IsCompleted = False _
                                  Order By SimpleAlert.LastUpdated).ToList()

                    End If

                    ''Only show assignments when grouping by Template or State
                    'If Me.GroupBy = AdvantageFramework.Database.Entities.AlertListGrouping.Template Or Me.GroupBy = AdvantageFramework.Database.Entities.AlertListGrouping.State Then

                    '    Alerts = (From SimpleAlert In Alerts _
                    '              Where Not SimpleAlert.IsAssignment = True).ToList()

                    'End If

                End If

                EntityAlerts = Nothing
                Employees = Nothing

            End Using

        End Sub
        Sub New(ByVal ConnectionString As String, ByVal UserCode As String, ByVal EmployeeCode As String)

            Alerts = New Generic.List(Of SimpleAlert)
            Me._ConnectionString = ConnectionString
            Me._UserCode = UserCode
            Me._EmployeeCode = EmployeeCode

        End Sub

#End Region

    End Class

    <Serializable()> Public Class SimpleAlert
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            IsAssignment
            IsCompleted
            IsMine
            IsUnAssigned
            CurrentlyAssignedTo
            Subject
            LastUpdated
            LastUpdatedBy
            AttachmentCount
            Type
            Category
            AlertID
            ID
            State
            Due
            Priority
            PrioritySort
            PriorityString
            PriorityAbbreviation
            GroupingText

        End Enum

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Private Property _Alert As AdvantageFramework.Database.Entities.Alert

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsAssignment As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsCompleted As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsMine As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsUnAssigned As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CurrentlyAssignedTo As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Subject As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LastUpdated As Nullable(Of Date) = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property LastUpdatedBy As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AttachmentCount As Integer = 0

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Type As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Category As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AlertID As Integer = 0

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ID As Integer = 0

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property State As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Due As Nullable(Of Date) = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Priority As Short = 3

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PrioritySort As Integer = 3 'Telerik grouping doesn't like "Priority" for some reason

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PriorityString As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property PriorityAbbreviation = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GroupingText As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AlertLevel As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AlertLevelText As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Sort As Integer = 0

#End Region

#Region " Variables "



#End Region

#Region " Methods "

        Public Sub ProcessAlert(ByRef Alert As AdvantageFramework.Database.Entities.Alert, Optional ByVal EmployeeCode As String = "")

            _Alert = Alert

            If Not _Alert Is Nothing Then

                AlertID = _Alert.ID

                IsAssignment = AdvantageFramework.AlertSystem.IsAlertAnAlertAssignment(_Alert)

                If Not _Alert.Subject Is Nothing Then Subject = _Alert.Subject

                Dim LatestComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

                LatestComment = _Alert.AlertComments.OrderByDescending(Function(Entity) Entity.GeneratedDate).FirstOrDefault()

                If LatestComment Is Nothing Then

                    LastUpdatedBy = _Alert.UserCode
                    LastUpdated = _Alert.GeneratedDate

                Else

                    LastUpdatedBy = LatestComment.UserCode
                    LastUpdated = LatestComment.GeneratedDate

                End If

                If Not _Alert.AlertAttachments Is Nothing Then AttachmentCount = _Alert.AlertAttachments.Count
                If Not _Alert.AlertType Is Nothing Then Type = _Alert.AlertType.Description
                If Not _Alert.AlertCategory Is Nothing Then Category = _Alert.AlertCategory.Description
                If Not _Alert.AlertState Is Nothing Then State = _Alert.AlertState.Name
                If Not _Alert.DueDate Is Nothing Then Due = _Alert.DueDate
                If Not _Alert.PriorityLevel Is Nothing Then Priority = _Alert.PriorityLevel.GetValueOrDefault(3)

                Select Case Priority
                    Case 5

                        PriorityString = "Lowest"
                        PriorityAbbreviation = "LL"
                        PrioritySort = 5

                    Case 4

                        PriorityString = "Low"
                        PriorityAbbreviation = "L"
                        PrioritySort = 4

                    Case 3

                        PriorityString = "Normal"
                        PriorityAbbreviation = "--"
                        PrioritySort = 3

                    Case 2

                        PriorityString = "High"
                        PriorityAbbreviation = "H"
                        PrioritySort = 2

                    Case 1

                        PriorityString = "Highest"
                        PriorityAbbreviation = "HH"
                        PrioritySort = 1

                End Select

                If Not _Alert.AlertSequenceNumber Is Nothing AndAlso _Alert.AlertSequenceNumber > 0 Then

                    ID = _Alert.AlertSequenceNumber

                Else

                    ID = AlertID

                End If

                If IsAssignment = True Then

                    Dim Assignee As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

                    Try

                        Assignee = (From Entity In _Alert.AlertRecipients _
                                    Where Entity.IsCurrentNotify = 1).First()


                    Catch ex As Exception

                        Assignee = Nothing

                    End Try

                    Dim DismissedAssignee As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing

                    If Assignee Is Nothing Then

                        Try

                            DismissedAssignee = (From Entity In _Alert.AlertRecipientDismisseds _
                                                 Where Entity.IsCurrentNotify = 1).First()

                        Catch ex As Exception

                            DismissedAssignee = Nothing

                        End Try

                    End If

                    If Assignee Is Nothing AndAlso DismissedAssignee Is Nothing Then

                        CurrentlyAssignedTo = "Unassigned"
                        IsUnAssigned = True

                    Else

                        Dim AssigneeLoaded As Boolean = False
                        If Not Assignee Is Nothing Then

                            CurrentlyAssignedTo = Assignee.EmployeeCode
                            IsMine = Assignee.EmployeeCode = EmployeeCode
                            AssigneeLoaded = True

                        End If
                        If AssigneeLoaded = False AndAlso Not DismissedAssignee Is Nothing Then

                            CurrentlyAssignedTo = "Completed" ' (" & DismissedAssignee.EmployeeCode & ")"
                            IsMine = DismissedAssignee.EmployeeCode = EmployeeCode
                            IsCompleted = True
                            AssigneeLoaded = True

                        End If

                        Assignee = Nothing
                        DismissedAssignee = Nothing

                    End If

                Else

                    'Might not need to check for "mine" for alerts in module alert list; so don't do it unless needed

                    ' '' ''Get "my" alert
                    '' ''Dim MyAlert As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
                    '' ''Try

                    '' ''    MyAlert = (From Entity In _Alert.AlertRecipients _
                    '' ''                Where Entity.EmployeeCode = EmployeeCode).First()


                    '' ''Catch ex As Exception

                    '' ''    MyAlert = Nothing

                    '' ''End Try

                    '' ''If Not MyAlert Is Nothing Then

                    '' ''    IsMine = True

                    '' ''Else

                    '' ''    'don't need this unless MyAlert is nothing, so don't declare it at top
                    '' ''    Dim MyDismissedAlert As AdvantageFramework.Database.Entities.AlertRecipientDismissed = Nothing

                    '' ''    Try

                    '' ''        MyDismissedAlert = (From Entity In _Alert.AlertRecipientDismisseds _
                    '' ''                             Where Entity.EmployeeCode = EmployeeCode).First()

                    '' ''    Catch ex As Exception

                    '' ''        MyDismissedAlert = Nothing

                    '' ''    End Try

                    '' ''    If Not MyDismissedAlert Is Nothing Then

                    '' ''        IsMine = True

                    '' ''    End If

                    '' ''End If

                End If

                _Alert = Nothing

            End If

        End Sub
        Public Sub New()

        End Sub

#End Region

    End Class
    <Serializable()> Public Class SimpleComment
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Comment
            GeneratedDate
            GeneratedBy

        End Enum

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Comment As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GeneratedDate As Nullable(Of Date) = Nothing

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property GeneratedBy As String = ""

#End Region

#Region " Variables "



#End Region

#Region " Page "



#End Region

#Region " Controls "



#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class
    <Serializable()> Public Class SimpleRecipient
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            EmployeeCode
            EmployeeName
            IsAssignee
            IsActive

        End Enum

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeCode As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeName As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsAssignee As Boolean = False

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsActive As Boolean = False

#End Region

#Region " Variables "



#End Region

#Region " Page "



#End Region

#Region " Controls "



#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class
    Public Class SimpleLookup
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Key1
            Key2
            Key3
            IntKey1
            IntKey2
            IntKey3

        End Enum

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Key1 As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Key2 As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Key3 As String = ""

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IntKey1 As Nullable(Of Integer) = 0

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IntKey2 As Nullable(Of Integer) = 0

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IntKey3 As Nullable(Of Integer) = 0

        <System.Runtime.Serialization.DataMemberAttribute(), AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Text As String = ""

#End Region

#Region " Variables "



#End Region

#Region " Methods "



#End Region


    End Class

End Namespace