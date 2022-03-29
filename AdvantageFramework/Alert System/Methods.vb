Imports HtmlAgilityPack

Namespace AlertSystem

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        Private Const AssignmentLink As String = "{0} here to view this assignment."
        Private Const AlertLink As String = "{0} here to view this alert."
        Private Const ReviewLink As String = "{0} here to view this review."
        Private Const AppVarApplication As String = "CSHARE"

#End Region

#Region " Enum "

        Public Enum AlertType
            Production
            EmployeeTimeForecast
            ProjectSchedule
            MissingTime
            ExpenseApproval
            ClientContract
            ImportValidation
            VendorContract
        End Enum

        Public Enum EmployeeTimeForecastAlertCategory
            HoursChangedForSupervisedEmployee
            HoursOverbookedForEmployee
        End Enum

        Public Enum TaskNotificationAlertCategory
            PastDueTask
            UpcomingTask
            TaskMarkedTempComplete
        End Enum

        Public Enum QvANotificationAlertCategory
            QuoteVsActualAlert
        End Enum

        Public Enum MissingTimeAlertCategory
            MissingTimeAlert
            MissingTimeReportSupervisor
        End Enum

        Public Enum ContractNotificationAlertCategory
            UpcomingContractRenewal
            UpcomingRequiredReport
            RequiredReportCompleted
        End Enum

        Public Enum VendorContractNotificationAlertCategory
            UpcomingVendorContractRenewal
        End Enum

        Public Enum ImportValidation
            MediaOceanValidationIssue
            ImportResults
        End Enum

        Public Enum ImportValidationFailureType
            CannotConnectToFTP
            AccountsReceivablePostPeriodClosedOrNotSetup
            GeneralLedgerPostPeriodClosedOrNotSetup
            ClientMappingNotSetup
            GeneralLedgerMappingNotSetup
            MissingSalesClassCode
        End Enum

        Public Enum PriorityLevels As Short
            Highest = 1
            High = 2
            Normal = 3
            Low = 4
            Lowest = 5
        End Enum

        Public Enum Levels
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("OF", "Office")>
            Office
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CL", "Client")>
            Client
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("DI", "Division")>
            Division
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PR", "Product")>
            Product
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CM", "Campaign")>
            Campaign
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("JO", "Job")>
            Job
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("JC", "Job/Component")>
            JobComponent
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ES", "Estimate")>
            Estimate
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("EST", "Estimate Component")>
            EstimateComponent
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PS", "Project Schedule")>
            ProjectSchedule
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PST", "Task")>
            Task
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("PO", "Purchase Order")>
            PurchaseOrder
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AP", "AP Invoice")>
            AccountPayable
        End Enum

        Public Enum EmployeeStatus

            NotMyAnything = 0
            MyAlert = 1
            MyAssignment = 2
            MyAlertDismissed = 3
            MyAssignmentCompleted = 4
            NotMyAssigment = 5
            NotMyAssignmentCompleted = 6
            NotMyAlert = 7
            NotMyAlertcompleted = 8

        End Enum

        Public Enum AlertInbox_ShowFilter

            MyAlertsAndAssignments
            MyAlerts
            MyAssignments
            AllAssignments
            Unassigned

        End Enum

        Public Enum AlertInbox_FolderFilter

            Inbox
            'Sent
            Dismissed
            AllReceived
            Drafts

        End Enum

        Public Enum ActionIconState

            Dismiss
            Undismiss
            Complete
            ReOpen
            Hide
            DeleteDraft

        End Enum

        Public Enum AppVars

            Routed

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property WebvantageWithClientPortalAssignmentLinkVerbiage As String
            Get
                Return String.Format(AssignmentLink, "Webvantage users click")
            End Get
        End Property
        Public ReadOnly Property WebvantageAssignmentLinkVerbiage As String
            Get
                Return String.Format(AssignmentLink, "Click")
            End Get
        End Property
        Public ReadOnly Property ClientPortalAssignmentLinkVerbiage As String
            Get
                Return String.Format(AssignmentLink, "Client Portal users click")
            End Get
        End Property

        Public ReadOnly Property WebvantageWithClientPortalAlertLinkVerbiage As String
            Get
                Return String.Format(AlertLink, "Webvantage users click")
            End Get
        End Property
        Public ReadOnly Property WebvantageAlertLinkVerbiage As String
            Get
                Return String.Format(AlertLink, "Click")
            End Get
        End Property
        Public ReadOnly Property ClientPortalAlertLinkVerbiage As String
            Get
                Return String.Format(AlertLink, "Client Portal users click")
            End Get
        End Property

        Public ReadOnly Property WebvantageWithClientPortalReviewLinkVerbiage As String
            Get
                Return String.Format(ReviewLink, "Webvantage users click")
            End Get
        End Property
        Public ReadOnly Property WebvantageReviewLinkVerbiage As String
            Get
                Return String.Format(ReviewLink, "Click")
            End Get
        End Property
        Public ReadOnly Property ClientPortalReviewLinkVerbiage As String
            Get
                Return String.Format(ReviewLink, "Client Portal users click")
            End Get
        End Property


#End Region

#Region " Methods "

#Region "  General "

#Region " Settings "

        Public Function GetUserReviewRoutedSetting(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim AppVarList As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim RoutedChecked As Boolean = GetAgencyReviewRoutedSetting(DbContext)

            Try

                AppVarList = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, DbContext.UserCode, AppVarApplication).ToList

                If AppVarList IsNot Nothing Then

                    AppVar = (From Entity In AppVarList
                              Where Entity.Name = AppVars.Routed.ToString
                              Select Entity).SingleOrDefault

                End If
                If AppVar Is Nothing Then

                    AppVar = New Database.Entities.AppVars
                    AppVar.Name = AppVars.Routed.ToString
                    AppVar.Application = AppVarApplication
                    AppVar.UserCode = DbContext.UserCode
                    AppVar.Value = RoutedChecked
                    AppVar.Type = "Boolean"
                    AppVar.Group = 0

                    AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                Else

                    RoutedChecked = AppVar.Value = True.ToString

                End If

            Catch ex As Exception
                RoutedChecked = False
            End Try

            Return RoutedChecked

        End Function
        Public Function SetUserReviewRoutedSetting(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                         ByVal Checked As Boolean) As Boolean

            Dim AppVarList As Generic.List(Of AdvantageFramework.Database.Entities.AppVars) = Nothing
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim IsSet As Boolean = True

            Try

                AppVarList = AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, DbContext.UserCode, AppVarApplication).ToList

                If AppVarList IsNot Nothing Then

                    AppVar = (From Entity In AppVarList
                              Where Entity.Name = AppVars.Routed.ToString
                              Select Entity).SingleOrDefault

                End If
                If AppVar Is Nothing Then

                    AppVar = New Database.Entities.AppVars
                    AppVar.Name = AppVars.Routed.ToString
                    AppVar.Application = AppVarApplication
                    AppVar.UserCode = DbContext.UserCode
                    AppVar.Type = "Boolean"
                    AppVar.Group = 0
                    AppVar.Value = True.ToString

                    IsSet = AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                Else

                    AppVar.Name = AppVars.Routed.ToString
                    AppVar.Application = AppVarApplication
                    AppVar.UserCode = DbContext.UserCode
                    AppVar.Type = "Boolean"
                    AppVar.Group = 0
                    AppVar.Value = Checked.ToString

                    IsSet = AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                End If

            Catch ex As Exception
                IsSet = False
            End Try

            Return IsSet

        End Function
        Private Function GetAgencyReviewRoutedSetting(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            Dim YesItIs As Boolean = False

            Try

                YesItIs = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT ISNULL(CAST(A.AGY_SETTINGS_VALUE AS BIT), 1) FROM AGY_SETTINGS A WITH(NOLOCK) " &
                                                                                " WHERE A.AGY_SETTINGS_CODE = 'ALRT_ASSGN_CS_RT_DFL';")).SingleOrDefault

            Catch ex As Exception
                YesItIs = True
            End Try

            Return YesItIs

        End Function

#End Region

        Public Function IsMultiRouteTemplate(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal AlertAssignmentTemplateID As Integer,
                                             ByRef Message As String) As Boolean

            Dim YesItIs As Boolean = False

            Try

                YesItIs = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CASE WHEN [TYPE] = 1 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END FROM ALERT_NOTIFY_HDR WITH(NOLOCK) WHERE ALRT_NOTIFY_HDR_ID = {0};", AlertAssignmentTemplateID)).SingleOrDefault
                Message = String.Empty

            Catch ex As Exception
                Message = ex.Message.ToString
                YesItIs = False
            End Try

            Return YesItIs

        End Function
        Public Function CheckClientContactAlertNotificationForAlert(ByRef ClientContact As AdvantageFramework.Database.Entities.ClientContact) As Boolean

            'objects
            Dim SendClientContactAlert As Boolean = False

            If ClientContact IsNot Nothing Then

                If (ClientContact.IsInactive Is Nothing OrElse ClientContact.IsInactive = 0) AndAlso
                   (ClientContact.GetAlerts IsNot Nothing AndAlso ClientContact.GetAlerts = 1) Then

                    SendClientContactAlert = True

                End If

            End If

            CheckClientContactAlertNotificationForAlert = SendClientContactAlert

        End Function
        Public Function CheckClientContactAlertNotificationForEmail(ByRef ClientContact As AdvantageFramework.Database.Entities.ClientContact) As Boolean

            'objects
            Dim SendClientContactEmail As Boolean = False

            If ClientContact IsNot Nothing Then

                If (ClientContact.IsInactive Is Nothing OrElse ClientContact.IsInactive = 0) AndAlso
                   (ClientContact.GetEmails IsNot Nothing AndAlso ClientContact.GetEmails = 1) Then

                    SendClientContactEmail = True

                End If

            End If

            CheckClientContactAlertNotificationForEmail = SendClientContactEmail

        End Function
        Public Function CheckClientContactAlertNotification(ByRef ClientContact As AdvantageFramework.Database.Entities.ClientContact) As Boolean

            'objects
            Dim SendClientContactEmailOrAlert As Boolean = False

            If ClientContact IsNot Nothing Then

                SendClientContactEmailOrAlert = CheckClientContactAlertNotificationForAlert(ClientContact) OrElse CheckClientContactAlertNotificationForEmail(ClientContact)

            End If

            CheckClientContactAlertNotification = SendClientContactEmailOrAlert

        End Function
        Public Function CheckEmployeeAlertNotificationForAlert(ByRef Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            'objects
            Dim SendEmployeeAlert As Boolean = False

            If Employee IsNot Nothing Then

                If Employee.AlertNotificationType.GetValueOrDefault(0) = 2 OrElse
                        Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                    SendEmployeeAlert = True

                End If

            End If

            CheckEmployeeAlertNotificationForAlert = SendEmployeeAlert

        End Function
        Public Function CheckEmployeeAlertNotificationForEmail(ByRef Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            'objects
            Dim SendEmployeeEmail As Boolean = False

            If Employee IsNot Nothing Then

                If Employee.AlertNotificationType.GetValueOrDefault(0) = 1 OrElse
                        Employee.AlertNotificationType.GetValueOrDefault(0) = 3 Then

                    SendEmployeeEmail = True

                End If

            End If

            CheckEmployeeAlertNotificationForEmail = SendEmployeeEmail

        End Function
        Public Function CheckEmployeeAlertNotification(ByRef Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            'objects
            Dim SendEmployeeEmailOrAlert As Boolean = False

            If Employee IsNot Nothing Then

                SendEmployeeEmailOrAlert = CheckEmployeeAlertNotificationForAlert(Employee) OrElse CheckEmployeeAlertNotificationForEmail(Employee)

            End If

            CheckEmployeeAlertNotification = SendEmployeeEmailOrAlert

        End Function
        Public Function CreateAlertRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal Employee As AdvantageFramework.Database.Views.Employee,
                                             ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                             ByVal CheckAlertNotification As Boolean) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing

            Try

                If CheckAlertNotification = False OrElse CheckEmployeeAlertNotification(Employee) = True Then

                    AlertRecipient = New Database.Entities.AlertRecipient

                    AlertRecipient.AlertID = Alert.ID
                    AlertRecipient.EmployeeCode = Employee.Code
                    AlertRecipient.EmployeeEmail = AdvantageFramework.Email.LoadEmployeeEmail(Employee, True, False)

                    Created = AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient)

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateAlertRecipient = Created
            End Try

        End Function
        Public Function BuildAndSendAlertEmail(ByVal ConnectionString As String,
                                               ByVal UserCode As String,
                                               ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                               ByVal Subject As String,
                                               Optional ByVal EmployeeCodesToSendEmailTo As String = "",
                                               Optional ByVal ClientPortalEmailAddressessToSendTo As String = "",
                                               Optional ByVal AppName As String = "",
                                               Optional ByVal SupervisorApprovalComment As String = "",
                                               Optional ByVal ExcludeAttachments As Boolean = False,
                                               Optional ByVal InsertEmailBodyAsAlertDescription As Boolean = False, '10
                                               Optional ByVal IsClientPortal As Boolean = False,
                                               Optional ByVal IncludeOriginator As Boolean = False,
                                               Optional ByVal WebvantageURL As String = "",
                                               Optional ByVal ClientPortalURL As String = "",
                                               Optional ByRef ErrorMessage As String = "",
                                               Optional ByVal ResetAssignedToEmployeeCodeReadFlag As Boolean = True,
                                               Optional ByVal IncludeAlertVendorReps As Boolean = True,
                                               Optional ByVal EmployeeSession As String = "",
                                               Optional ByVal DocumentID As Integer? = 0,
                                               Optional ByVal ProofingURL As String = "") As Boolean '20

            Dim Completed As Boolean = False

            Try

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(ConnectionString, UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                        Completed = BuildAndSendAlertEmail(SecurityDbContext,
                                                           DbContext,
                                                           Alert,
                                                           Subject,
                                                           EmployeeCodesToSendEmailTo,
                                                           ClientPortalEmailAddressessToSendTo,
                                                           AppName,
                                                           SupervisorApprovalComment,
                                                           ExcludeAttachments,
                                                           InsertEmailBodyAsAlertDescription, '10
                                                           IsClientPortal,
                                                           IncludeOriginator,
                                                           WebvantageURL,
                                                           ClientPortalURL,
                                                           ErrorMessage,
                                                           ResetAssignedToEmployeeCodeReadFlag,
                                                           IncludeAlertVendorReps,
                                                           EmployeeSession,
                                                           EmployeeSession,
                                                           DocumentID,
                                                           ProofingURL) '21

                    End Using

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Completed = False
            Finally
                BuildAndSendAlertEmail = Completed
            End Try

        End Function
        Public Function BuildAndSendAlertEmail(ByVal Session As AdvantageFramework.Security.Session,
                                               ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                               ByVal Subject As String,
                                               Optional ByVal EmployeeCodesToSendEmailTo As String = "",
                                               Optional ByVal ClientPortalEmailAddressessToSendTo As String = "",
                                               Optional ByVal AppName As String = "",
                                               Optional ByVal SupervisorApprovalComment As String = "",
                                               Optional ByVal ExcludeAttachments As Boolean = False,
                                               Optional ByVal InsertEmailBodyAsAlertDescription As Boolean = False,
                                               Optional ByVal IsClientPortal As Boolean = False, '10
                                               Optional ByVal IncludeOriginator As Boolean = False,
                                               Optional ByVal WebvantageURL As String = "",
                                               Optional ByVal ClientPortalURL As String = "",
                                               Optional ByRef ErrorMessage As String = "",
                                               Optional ByVal ResetAssignedToEmployeeCodeReadFlag As Boolean = True,
                                               Optional ByVal IncludeAlertVendorReps As Boolean = True,
                                               Optional ByVal DocumentID As Integer? = 0,
                                               Optional ByVal ProofingURL As String = "") As Boolean '18

            Dim Completed As Boolean = False

            Try

                Using SecurityDbContext As New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Completed = BuildAndSendAlertEmail(SecurityDbContext,
                                                           DbContext,
                                                           Alert,
                                                           Subject,
                                                           EmployeeCodesToSendEmailTo,
                                                           ClientPortalEmailAddressessToSendTo,
                                                           AppName,
                                                           SupervisorApprovalComment,
                                                           ExcludeAttachments,
                                                           InsertEmailBodyAsAlertDescription,  '10
                                                           IsClientPortal,
                                                           IncludeOriginator,
                                                           WebvantageURL,
                                                           ClientPortalURL,
                                                           ErrorMessage,
                                                           ResetAssignedToEmployeeCodeReadFlag,
                                                           IncludeAlertVendorReps,
                                                           "",
                                                           Session.User.EmployeeCode,
                                                           DocumentID,
                                                           ProofingURL) '21

                    End Using

                End Using

            Catch ex As Exception
                Completed = False
            Finally
                BuildAndSendAlertEmail = Completed
            End Try

        End Function
        Public Function BuildAndSendAlertEmail(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                               ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                               ByVal Subject As String,
                                               Optional ByVal EmployeeCodesToSendEmailTo As String = "",
                                               Optional ByVal ClientPortalEmailAddressessToSendTo As String = "",
                                               Optional ByVal AppName As String = "",
                                               Optional ByVal SupervisorApprovalComment As String = "",
                                               Optional ByVal ExcludeAttachments As Boolean = False,
                                               Optional ByVal InsertEmailBodyAsAlertDescription As Boolean = False, '10
                                               Optional ByVal IsClientPortal As Boolean = False,
                                               Optional ByVal IncludeOriginator As Boolean = False,
                                               Optional ByVal WebvantageURL As String = "",
                                               Optional ByVal ClientPortalURL As String = "",
                                               Optional ByRef ErrorMessage As String = "",
                                               Optional ByVal ResetAssignedToEmployeeCodeReadFlag As Boolean = True,
                                               Optional ByVal IncludeAlertVendorReps As Boolean = True,
                                               Optional ByVal EmployeeSession As String = "",
                                               Optional ByVal FromEmployeeCode As String = "",
                                               Optional ByVal DocumentID As Integer? = 0,
                                               Optional ByVal ProofingURL As String = "") As Boolean '21

            Dim Completed As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing
            'Dim AlertEmailRecipients As Generic.List(Of AdvantageFramework.Database.Classes.AlertEmailRecipient) = Nothing
            Dim IsAlertAssignment As Boolean = False
            Dim IsWorkItem As Boolean = False
            Dim OriginatorEmployeeCode As String = Nothing
            Dim CurrentAssigneeEmployeeCode As String = Nothing
            Dim AlertAttachmentViews As Generic.List(Of AdvantageFramework.Database.Views.AlertAttachmentView) = Nothing
            'Dim AlertComments As Generic.List(Of AdvantageFramework.Database.Classes.AlertComment) = Nothing
            'Dim Comment As String = Nothing
            Dim AlertDetails As AdvantageFramework.Email.Classes.Alert = Nothing
            Dim EmployeeEmailList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim HasLinksHeader As Boolean = False
            Dim AttachmentFiles As Generic.List(Of String) = Nothing
            Dim SaveToLocation As String = ""
            Dim FileName As String = ""
            Dim FinalEmailBody As String = ""
            Dim ThumbnailFilename As String = ""
            'Dim EmployeeCodesToEmail As Generic.List(Of String) = Nothing
            Dim EmailToString As String = ""
            Dim EmailCcString As String = ""

            Dim empsTo As New Generic.List(Of String)
            Dim empsCC As New Generic.List(Of String)

            Dim mentions As String()

            Dim ExceptionMessage As String = ""
            Dim ClickLinkText As String = ""
            Dim IsSingleReviewEmailToClientPortalUser As Boolean = False
            Dim IsSingleReviewEmailToInternalReviewer As Boolean = False

            Dim CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
            Dim ImpersonationContext As System.Security.Principal.WindowsImpersonationContext = Nothing
            Dim VendorRepCodes As IEnumerable(Of String) = Nothing

            Dim EmployeeViewLink As String = String.Empty
            Dim ContactViewLink As String = String.Empty
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim VendorRepEmailBody As String = Nothing
            Dim NewLink As String = Nothing
            Dim VendorRepEmailToString As String = Nothing

            Dim BaseAlertRecipients As Generic.List(Of AdvantageFramework.Database.Classes.AlertEmailRecipient) = Nothing
            Dim ClientPortalAlertEmailRecipients As Generic.List(Of AdvantageFramework.Database.Classes.AlertEmailRecipient) = Nothing
            Dim MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor = Nothing

            Dim IsProof As Boolean = False

            Try

                If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                    Try

                        CurrentWindowsIdentity = CType(System.Web.HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)

                    Catch ex As Exception
                        CurrentWindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()
                    End Try

                    ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                End If

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                IsAlertAssignment = IsAlertAnAlertAssignment(Alert)
                IsWorkItem = Alert.IsWorkItem.GetValueOrDefault(False)

                If IsWorkItem = True OrElse IsAlertAssignment = True Then

                    IncludeOriginator = True

                End If
                If Alert.AlertLevel = "BRD" OrElse Alert.AlertCategoryID = 71 Then

                    IncludeOriginator = False

                End If
                If Alert.AlertCategoryID = 79 OrElse
                    Alert.AlertTypeID = 15 OrElse
                    (Alert.IsConceptShareReview IsNot Nothing AndAlso Alert.IsConceptShareReview = True) Then

                    IsProof = True

                End If

                BaseAlertRecipients = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.AlertEmailRecipient)(String.Format("EXEC [dbo].[usp_Get_Alert_EmailRecipients] {0};", Alert.ID)).ToList

                If BaseAlertRecipients IsNot Nothing Then

                    If IsWorkItem = True Then

                        empsTo = (From Entity In BaseAlertRecipients
                                  Where Entity.IsAssignee = True And Entity.SendEmail = True And Entity.IsClientPortal = False
                                  Select Entity.EmployeeCode).ToList

                        For Each emp In empsTo

                            If emp.Count > 0 Then

                                MarkAssigneeUnread(DbContext, Alert, emp)

                            End If

                        Next

                        empsCC = (From Entity In BaseAlertRecipients
                                  Where Entity.IsCC = True And Entity.IsClientPortal = False
                                  Select Entity.EmployeeCode).ToList



                        For Each emp In empsCC

                            If emp.Count > 0 Then

                                MarkCCsUnread(DbContext, Alert.ID, emp)

                            End If

                        Next

                    Else

                        UpdateAlertRecipients(DbContext, Alert.ID, BaseAlertRecipients, ErrorMessage, EmployeeSession)

                        empsTo = (From Entity In BaseAlertRecipients
                                  Where Entity.SendEmail = True And Entity.IsClientPortal = False
                                  Select Entity.EmployeeCode).ToList

                    End If

                End If

                mentions = GetAlertMentions(DbContext, Alert.ID, SecurityDbContext.UserCode)
                RemoveAlertMentions(DbContext, Alert.ID, SecurityDbContext.UserCode)

                If mentions IsNot Nothing And mentions.Length > 0 Then

                    For Each item As String In mentions

                        If empsCC.Contains(item) = False Then

                            empsCC.Add(item)
                            MarkCCsUnread(DbContext, Alert.ID, item)

                        End If

                    Next

                End If

                ClientPortalAlertEmailRecipients = (From Entity In BaseAlertRecipients
                                                    Where Entity.IsClientPortal
                                                    Select Entity).ToList

                If IsAlertAssignment OrElse IsWorkItem Then

                    If IncludeOriginator = True AndAlso
                        empsCC.Contains(Alert.EmployeeCode) = False AndAlso
                        empsTo.Contains(Alert.EmployeeCode) = False Then

                        empsCC.Add(Alert.EmployeeCode)

                    End If

                    ClientPortalEmailAddressessToSendTo = ""

                    Subject = Subject.Replace("[Alert", "[Assignment")
                    Subject = Subject.Replace("Alert]", "Assignment]")

                End If

                If (empsTo Is Nothing OrElse empsTo.Count = 0) AndAlso (empsCC Is Nothing OrElse empsCC.Count = 0) AndAlso
                        String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = True AndAlso
                        String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = True AndAlso
                        Not (Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.OrderGenerated AndAlso IncludeAlertVendorReps) AndAlso
                        Not (Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.RFPGenerated AndAlso IncludeAlertVendorReps) AndAlso
                        Not (Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.MediaTrafficGenerated AndAlso IncludeAlertVendorReps) Then 'no one to send to

                    ErrorMessage = ""
                    Completed = True

                Else

                    HTMLEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False)

                    'Build email body
                    Try

                        ' Set link back into WV in email
                        Dim HyperLinkRowSet As Boolean = False
                        Dim IncludeContactLink As Boolean = False
                        Dim EmailBody As String = Alert.EmailBody

                        Try

                            If ClientPortalAlertEmailRecipients IsNot Nothing AndAlso ClientPortalAlertEmailRecipients.Count > 0 Then

                                If Agency.ClientPortalURL IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Agency.ClientPortalURL) = False AndAlso IsSingleReviewEmailToInternalReviewer = False Then

                                    IncludeContactLink = True

                                End If
                                If IsSingleReviewEmailToClientPortalUser = False AndAlso ((empsTo IsNot Nothing AndAlso empsTo.Count > 0) OrElse
                                    String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = False) Then

                                    If IsAlertAssignment = True OrElse IsWorkItem = True Then

                                        ClickLinkText = WebvantageWithClientPortalAssignmentLinkVerbiage
                                        EmployeeViewLink = HTMLEmail.AssignmentLink(DbContext, Alert.ID, 0, ClickLinkText, Web.Methods.DeepLinkType.External)
                                        If IncludeContactLink = True Then

                                            ContactViewLink = HTMLEmail.AssignmentLink(DbContext, Alert.ID, 0, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal)

                                        End If

                                    Else

                                        ClickLinkText = WebvantageWithClientPortalAlertLinkVerbiage
                                        EmployeeViewLink = HTMLEmail.AlertLink(DbContext, Alert.ID, ClickLinkText, Web.Methods.DeepLinkType.External)
                                        If IncludeContactLink = True Then ContactViewLink = HTMLEmail.AlertLink(DbContext, Alert.ID, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal)

                                    End If

                                    HTMLEmail.AddCustomRow(EmployeeViewLink)

                                End If
                                If IsAlertAssignment = True OrElse IsWorkItem = True Then

                                    ClickLinkText = ClientPortalAssignmentLinkVerbiage
                                    EmployeeViewLink = HTMLEmail.AssignmentLink(DbContext, Alert.ID, 0, ClickLinkText, Web.Methods.DeepLinkType.External)
                                    If IncludeContactLink = True Then ContactViewLink = HTMLEmail.AssignmentLink(DbContext, Alert.ID, 0, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal)

                                Else

                                    ClickLinkText = ClientPortalAlertLinkVerbiage
                                    'EmployeeViewLink = HTMLEmail.AlertLink(DbContext, Alert.ID, ClickLinkText, Web.Methods.DeepLinkType.External)
                                    If IncludeContactLink = True Then ContactViewLink = HTMLEmail.AlertLink(DbContext, Alert.ID, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal)

                                End If
                                If IncludeContactLink = True AndAlso String.IsNullOrWhiteSpace(ContactViewLink) = False Then

                                    HTMLEmail.AddCustomRow(ContactViewLink)

                                End If

                            Else

                                If (empsTo Is Nothing OrElse empsTo.Count = 0) AndAlso String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = True Then

                                    If ClientPortalAlertEmailRecipients Is Nothing AndAlso String.IsNullOrWhiteSpace(ClientPortalEmailAddressessToSendTo) = False Then

                                        If Agency.ClientPortalURL IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Agency.ClientPortalURL) = False AndAlso IsSingleReviewEmailToInternalReviewer = False Then

                                            IncludeContactLink = True

                                        End If

                                    End If

                                End If
                                If IsAlertAssignment = True OrElse IsWorkItem = True Then

                                    ClickLinkText = WebvantageAssignmentLinkVerbiage
                                    EmployeeViewLink = HTMLEmail.AssignmentLink(DbContext, Alert.ID, 0, ClickLinkText, Web.Methods.DeepLinkType.External)
                                    If IncludeContactLink = True Then ContactViewLink = HTMLEmail.AssignmentLink(DbContext, Alert.ID, 0, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal)

                                Else

                                    ClickLinkText = WebvantageAlertLinkVerbiage
                                    EmployeeViewLink = HTMLEmail.AlertLink(DbContext, Alert.ID, ClickLinkText, Web.Methods.DeepLinkType.External, Alert.AlertCategoryID)
                                    If IncludeContactLink = True Then ContactViewLink = HTMLEmail.AlertLink(DbContext, Alert.ID, ClickLinkText, Web.Methods.DeepLinkType.ClientPortalExternal)

                                End If
                                If IncludeContactLink = True AndAlso String.IsNullOrWhiteSpace(ContactViewLink) = False Then

                                    HTMLEmail.AddCustomRow(ContactViewLink)

                                End If
                                If HyperLinkRowSet = False Then

                                    HTMLEmail.AddCustomRow(EmployeeViewLink)

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                        ' Subject and description
                        Try

                            HTMLEmail.AddHeaderRow(Subject)
                            HTMLEmail.AddKeyValueRow("Subject", If(String.IsNullOrEmpty(Alert.Subject), "", Alert.Subject))

                            UrlToHtmlLink(EmailBody, Agency.WebvantageURL, Agency.ClientPortalURL)
                            ' Thumbnail?
                            Try

                                If IsProof = True Then

                                    If DocumentID IsNot Nothing AndAlso DocumentID > 0 Then

                                        HTMLEmail.AddDocumentThumbnailRow(DbContext, CInt(DocumentID), ThumbnailFilename)

                                    Else

                                        HTMLEmail.AddLatestVersionsThumbnails(DbContext, Alert.ID)

                                    End If

                                End If

                            Catch ex As Exception
                            End Try

                                If IsProof = True Then

                                    If DocumentID IsNot Nothing AndAlso DocumentID > 0 Then

                                        HTMLEmail.AddDocumentThumbnailRow(DbContext, CInt(DocumentID), ThumbnailFilename)

                                    Else

                                        HTMLEmail.AddLatestVersionsThumbnails(DbContext, Alert.ID)

                                    End If

                                End If

                            Catch ex As Exception
                            End Try

                            If String.IsNullOrWhiteSpace(EmailBody) = False Then HTMLEmail.AddKeyValueRow("Description", EmailBody)

                            HTMLEmail.AddBlankRow()

                        Catch ex As Exception
                        End Try

                        ' Thumbnail?
                        Try

                            If IsProof = True Then

                                If DocumentID IsNot Nothing AndAlso DocumentID > 0 Then

                                    HTMLEmail.AddDocumentThumbnailRow(DbContext, DocumentID, ThumbnailFilename)

                                Else

                                    HTMLEmail.AddLatestVersionsThumbnails(DbContext, Alert.ID)

                                End If

                            End If

                        Catch ex As Exception
                        End Try

                        ' Comments
                        Try

                            If IsProof = True AndAlso DocumentID IsNot Nothing AndAlso DocumentID > 0 Then

                                CommentsHistory(DbContext, False, Alert.ID, DocumentID, ThumbnailFilename, Agency, HTMLEmail)

                            Else

                                CommentsHistory(DbContext, False, Alert.ID, Agency, HTMLEmail)

                            End If

                            HTMLEmail.AddBlankRow()

                        Catch ex As Exception
                        End Try

                        ' Details
                        Try


                            If AppName = "SupervisorApproval" AndAlso String.IsNullOrWhiteSpace(SupervisorApprovalComment) = False Then

                                HTMLEmail.AddKeyValueRow("Comments", SupervisorApprovalComment)
                                HTMLEmail.AddBlankRow()

                            End If

                        Catch ex As Exception
                        End Try

                        ' General Info
                        AlertDetails = AdvantageFramework.Database.Procedures.AlertView.LoadByAlertID(DbContext, Alert.ID)

                        Try

                            If IsClientPortal = False Then

                                HTMLEmail.AddCustomRow(GeneralInformation(DbContext, AlertDetails, False, 0))

                            Else

                                If IsNumeric(Alert.UserCode) = True Then

                                    HTMLEmail.AddCustomRow(GeneralInformation(DbContext, AlertDetails, True, CType(Alert.UserCode, Integer)))

                                End If

                            End If

                            HTMLEmail.AddBlankRow()

                        Catch ex As Exception
                        End Try
                        ' Details Section
                        Try

                            If AppName <> "SupervisorApproval" AndAlso AppName <> "Timesheet" AndAlso AppName <> "Expense" AndAlso AppName <> "APVendorMediaInvoiceApproval" Then

                                LoadAlertDetailsInTable(DbContext, AlertDetails, HTMLEmail, IsClientPortal)

                            End If

                            AttachmentFiles = New Generic.List(Of String)

                            If Convert.ToBoolean(Agency.IncludeAttachmentsWithAlerts.GetValueOrDefault(0)) = 0 AndAlso ExcludeAttachments = False Then 'The property should be renamed to "ExcludeFromEmail" or "IncludeAttachmentsWithAlertsOnly"

                                AlertAttachmentViews = (From Entity In AdvantageFramework.Database.Procedures.AlertAttachmentView.LoadByAlertID(DbContext, Alert.ID)
                                                        Where Entity.EmailSent = Nothing OrElse Entity.EmailSent = False
                                                        Select Entity).ToList()

                                If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                                    ImpersonationContext.Undo()

                                End If

                                HTMLEmail.AddKeyValueRowNoCell("Attachments", AlertAttachmentViews.Count.ToString())

                                For Each AlertAttachmentView In AlertAttachmentViews

                                    If AlertAttachmentView.MimeType = "URL" Then

                                        If HasLinksHeader = False Then

                                            HTMLEmail.AddHeaderRow("Attached Links")
                                            HasLinksHeader = True

                                        End If

                                        HTMLEmail.AddHyperlinkRow(AlertAttachmentView.RepositoryFilename, AlertAttachmentView.RealFileName)

                                    Else

                                        Dim Downloaded As Boolean = False

                                        If Agency.IsASP.GetValueOrDefault(0) = 1 Then

                                            SaveToLocation = AdvantageFramework.FileSystem.LoadHostedClientDownloadLocation(Agency)
                                            Downloaded = AdvantageFramework.FileSystem.Download(Agency, AlertAttachmentView, SaveToLocation, FileName)

                                            If Downloaded = False Then

                                                SaveToLocation = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")
                                                Downloaded = AdvantageFramework.FileSystem.Download(Agency, AlertAttachmentView, SaveToLocation, FileName)

                                            End If

                                        ElseIf Agency.FileSystemDirectory = "" Then

                                            SaveToLocation = My.Application.Info.DirectoryPath & "\"
                                            Downloaded = AdvantageFramework.FileSystem.Download(Agency, AlertAttachmentView, SaveToLocation, FileName)

                                        Else

                                            SaveToLocation = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")
                                            Downloaded = AdvantageFramework.FileSystem.Download(Agency, AlertAttachmentView, SaveToLocation, FileName)

                                        End If

                                        If Downloaded Then

                                            AttachmentFiles.Add(FileName)

                                            If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                                                ImpersonationContext = CurrentWindowsIdentity.Impersonate

                                            End If

                                            UpdateAlertAttachment(DbContext, AlertAttachmentView.AlertID, AlertAttachmentView.AttachmentID)

                                            If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                                                ImpersonationContext.Undo()

                                            End If

                                        End If

                                    End If

                                Next

                            End If

                        Catch ex As Exception
                        End Try
                        'Finalize the body
                        'Don't modify body after this!!
                        Try

                            If String.IsNullOrWhiteSpace(EmployeeViewLink) = False Then

                                HTMLEmail.AddCustomRow(EmployeeViewLink)

                            End If
                            If IncludeContactLink = True AndAlso String.IsNullOrWhiteSpace(ContactViewLink) = False Then

                                HTMLEmail.AddCustomRow(ContactViewLink)

                            End If

                            HTMLEmail.Finish()
                            FinalEmailBody = HTMLEmail.ToString(Alert.ID)

                            If InsertEmailBodyAsAlertDescription = True AndAlso IsAlertAssignment = False Then

                                AdvantageFramework.Database.Procedures.Alert.Update(DbContext, Alert)

                            End If

                        Catch ex As Exception
                        End Try

                    Catch ex As Exception
                    End Try
                    'Subject
                    Dim JobAdded As Boolean = False
                    Try

                        If String.IsNullOrWhiteSpace(Subject) = True Then

                            If String.IsNullOrEmpty(Alert.Subject) = False Then

                                Subject = Alert.Subject

                            End If

                        Else

                            If Alert.JobNumber IsNot Nothing Then

                                If String.IsNullOrEmpty(Alert.JobNumber) = False Then

                                    If Alert.Subject.Contains(Alert.JobNumber.ToString.PadLeft(6, "0")) = False Then

                                        Dim j As AdvantageFramework.Database.Entities.Job = Nothing
                                        j = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Alert.JobNumber)

                                        If j IsNot Nothing Then

                                            Subject = Subject & " " & Alert.JobNumber.ToString.PadLeft(6, "0") & " - " & Alert.JobComponentNumber.ToString.PadLeft(3, "0") & " " & j.Description
                                            JobAdded = True

                                        End If

                                    End If

                                End If

                            End If
                            If String.IsNullOrEmpty(Alert.Subject) = False AndAlso Subject.Contains(Alert.Subject) = False Then

                                If JobAdded = True Then

                                    Subject = Subject & " | " & Alert.Subject

                                Else

                                    Subject = Subject & " " & Alert.Subject

                                End If

                            End If

                        End If


                        If AppName = "SupervisorApproval" OrElse AppName = "Expense" Then

                            If Subject.StartsWith("[New Alert]") = False OrElse Subject.StartsWith("[New Assignment]") = False Then

                                Subject = "[New Alert] " & Subject

                            End If

                        End If

                    Catch ex As Exception
                    End Try

                    'Set To and CC and Send email
                    Try

                        If IsAlertAssignment = False Then

                            If String.IsNullOrWhiteSpace(EmployeeCodesToSendEmailTo) = False Then

                                Try

                                    For Each EmployeeCode In EmployeeCodesToSendEmailTo.Split(",")

                                        If empsTo.Contains(EmployeeCode) = False AndAlso empsCC.Contains(EmployeeCode) = False Then

                                            empsTo.Add(EmployeeCode)

                                        End If

                                    Next

                                Catch ex As Exception
                                End Try

                            End If

                        End If

                        Dim EmpEmailString As String = ""
                        Dim CurrentEmployee As AdvantageFramework.Database.Views.Employee

                        If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                            ImpersonationContext = CurrentWindowsIdentity.Impersonate

                        End If

                        For Each EmployeeCode In empsTo.Distinct

                            CurrentEmployee = Nothing
                            EmpEmailString = String.Empty

                            CurrentEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                            If CurrentEmployee IsNot Nothing Then

                                If (CurrentEmployee.AlertNotificationType IsNot Nothing AndAlso CurrentEmployee.AlertNotificationType = 3) AndAlso
                                    (CurrentEmployee.Email IsNot Nothing AndAlso String.IsNullOrEmpty(CurrentEmployee.Email) = False) AndAlso
                                    AdvantageFramework.StringUtilities.IsValidEmailAddress(CurrentEmployee.Email) = True Then

                                    EmpEmailString = AdvantageFramework.EmployeeUtilities.LoadEmailWithEmployeeName(CurrentEmployee)

                                End If

                                If String.IsNullOrWhiteSpace(EmpEmailString) = False Then

                                    Try

                                        EmailToString &= EmpEmailString & ";"

                                    Catch ex As Exception
                                    End Try

                                End If

                            End If

                        Next
                        For Each EmployeeCode In empsCC.Distinct

                            CurrentEmployee = Nothing
                            EmpEmailString = String.Empty

                            CurrentEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                            If CurrentEmployee IsNot Nothing Then

                                If (CurrentEmployee.AlertNotificationType IsNot Nothing AndAlso CurrentEmployee.AlertNotificationType = 3) AndAlso
                                    (CurrentEmployee.Email IsNot Nothing AndAlso String.IsNullOrEmpty(CurrentEmployee.Email) = False) AndAlso
                                    AdvantageFramework.StringUtilities.IsValidEmailAddress(CurrentEmployee.Email) = True Then

                                    EmpEmailString = AdvantageFramework.EmployeeUtilities.LoadEmailWithEmployeeName(CurrentEmployee)

                                End If

                                If String.IsNullOrWhiteSpace(EmpEmailString) = False Then

                                    Try

                                        EmailCcString &= EmpEmailString & ";"

                                    Catch ex As Exception
                                    End Try

                                End If

                            End If

                        Next
                        If ClientPortalAlertEmailRecipients IsNot Nothing Then

                            For Each ClientPortalAlertEmailRecipient In ClientPortalAlertEmailRecipients

                                Try
                                    If IsAlertAssignment = False Then

                                        EmailToString &= ClientPortalAlertEmailRecipient.MailBeeTitle & ";"

                                    Else

                                        EmailCcString &= ClientPortalAlertEmailRecipient.MailBeeTitle & ";"

                                    End If

                                Catch ex As Exception
                                End Try

                            Next

                        End If

                        If Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.RFPGenerated AndAlso IncludeAlertVendorReps Then

                            VendorRepCodes = (From Entity In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, Alert.ID)
                                              Where Entity.VendorRepresentativeCode IsNot Nothing AndAlso
                                                    Entity.VendorRepresentativeCode <> ""
                                              Select Entity.VendorRepresentativeCode).Distinct.ToArray

                            If VendorRepCodes IsNot Nothing AndAlso VendorRepCodes.Count > 0 Then

                                MediaRFPHeader = (From Entity In AdvantageFramework.Database.Procedures.MediaRFPHeader.Load(DbContext)
                                                  Where Entity.AlertID = Alert.ID
                                                  Select Entity).FirstOrDefault

                                If MediaRFPHeader IsNot Nothing Then

                                    Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                                        For Each VendorRep In (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Alert.VendorCode)
                                                               Where VendorRepCodes.Contains(Entity.Code) AndAlso
                                                                     Entity.EmailAddress IsNot Nothing AndAlso
                                                                     Entity.EmailAddress <> ""
                                                               Select Entity).ToList

                                            NewLink = "<a href=""" & AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/") & "MediaManager/RequestForProposalForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & DbContext.Database.Connection.Database & "&MediaRFPHeaderID=" & MediaRFPHeader.ID & "&Email=" & VendorRep.EmailAddress) & "%7C"" > Click Here</a> to View the RFP"

                                            VendorRepEmailBody = ReplaceLinks(FinalEmailBody, NewLink)

                                            VendorRepEmailToString = VendorRep.ToString & " <" & VendorRep.EmailAddress & ">" & ";"

                                            AdvantageFramework.Email.Send(DbContext, SecurityDbContext, VendorRepEmailToString, Subject,
                                                                          VendorRepEmailBody, Alert.PriorityLevel, AttachmentFiles.ToArray, SendingEmailStatus, ExceptionMessage, "")

                                        Next

                                    End Using

                                End If

                            End If

                        ElseIf Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.OrderGenerated AndAlso IncludeAlertVendorReps Then

                            VendorRepCodes = (From Entity In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, Alert.ID)
                                              Where Entity.VendorRepresentativeCode IsNot Nothing AndAlso
                                                    Entity.VendorRepresentativeCode <> ""
                                              Select Entity.VendorRepresentativeCode).Distinct.ToArray

                            If VendorRepCodes IsNot Nothing AndAlso VendorRepCodes.Count > 0 Then

                                Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                                    For Each VendorRep In (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Alert.VendorCode)
                                                           Where VendorRepCodes.Contains(Entity.Code) AndAlso
                                                                 Entity.EmailAddress IsNot Nothing AndAlso
                                                                 Entity.EmailAddress <> ""
                                                           Select Entity).ToList

                                        NewLink = "<a href=""" & AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/") & "Media/MakegoodDelivery/MakegoodOutstandingForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & DbContext.Database.Connection.Database & "&VendorCode=" & Alert.VendorCode & "&VendorRepCode=" & VendorRep.Code) & "%7C"" > Click Here</a> to review open orders and take various actions."

                                        VendorRepEmailBody = ReplaceLinks(FinalEmailBody, NewLink)

                                        VendorRepEmailToString = VendorRep.ToString & " <" & VendorRep.EmailAddress & ">" & ";"

                                        AdvantageFramework.Email.Send(DbContext, SecurityDbContext, VendorRepEmailToString, Subject,
                                                                          VendorRepEmailBody, Alert.PriorityLevel, AttachmentFiles.ToArray, SendingEmailStatus, ExceptionMessage, "")

                                    Next

                                End Using

                            End If

                        ElseIf Alert.AlertCategoryID = AdvantageFramework.Database.Entities.AlertCategories.MediaTrafficGenerated AndAlso IncludeAlertVendorReps Then

                            MediaTrafficVendor = (From Entity In AdvantageFramework.Database.Procedures.MediaTrafficVendor.Load(DbContext)
                                                  Where Entity.AlertID = Alert.ID
                                                  Select Entity).FirstOrDefault

                            If MediaTrafficVendor IsNot Nothing Then

                                VendorRepCodes = (From Entity In AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, Alert.ID)
                                                  Where Entity.VendorRepresentativeCode IsNot Nothing AndAlso
                                                    Entity.VendorRepresentativeCode <> ""
                                                  Select Entity.VendorRepresentativeCode).Distinct.ToArray

                                If VendorRepCodes IsNot Nothing AndAlso VendorRepCodes.Count > 0 Then

                                    Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                                        For Each VendorRep In (From Entity In AdvantageFramework.Database.Procedures.VendorRepresentative.LoadActiveByVendorCode(DataContext, Alert.VendorCode)
                                                               Where VendorRepCodes.Contains(Entity.Code) AndAlso
                                                                 Entity.EmailAddress IsNot Nothing AndAlso
                                                                 Entity.EmailAddress <> ""
                                                               Select Entity).ToList

                                            NewLink = "<a href=""" & AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.WebvantageURL, "/") & "Media/MediaTraffic/TrafficInstructionForm?%7C" & AdvantageFramework.Security.Encryption.Encrypt("Database=" & DbContext.Database.Connection.Database & "&MediaTrafficID=" & MediaTrafficVendor.MediaTrafficRevision.MediaTrafficID & "&VendorCode=" & MediaTrafficVendor.VendorCode & "&RevisionNumber=" & MediaTrafficVendor.MediaTrafficRevision.RevisionNumber & "&Email=" & VendorRep.EmailAddress) & "%7C"" > Click Here</a> to View the Traffic Instruction"

                                            VendorRepEmailBody = ReplaceLinks(FinalEmailBody, NewLink)

                                            VendorRepEmailToString = VendorRep.ToString & " <" & VendorRep.EmailAddress & ">" & ";"

                                            AdvantageFramework.Email.Send(DbContext, SecurityDbContext, VendorRepEmailToString, Subject,
                                                                          VendorRepEmailBody, Alert.PriorityLevel, AttachmentFiles.ToArray, SendingEmailStatus, ExceptionMessage, "")

                                        Next

                                    End Using

                                End If

                            End If

                        End If

                        EmailToString = AdvantageFramework.StringUtilities.CleanStringForSplit(EmailToString, ";", False)
                        EmailCcString = AdvantageFramework.StringUtilities.CleanStringForSplit(EmailCcString, ";", False)
                        EmailToString = AdvantageFramework.StringUtilities.CleanStringForSplit(EmailToString, ",", False)
                        EmailCcString = AdvantageFramework.StringUtilities.CleanStringForSplit(EmailCcString, ",", False)

                        If String.IsNullOrWhiteSpace(EmailToString) = True AndAlso String.IsNullOrWhiteSpace(EmailCcString) = True Then

                            Completed = True

                        Else

                            'Just in case
                            Subject = Subject.Replace("[New Alert] [New Alert]", "[New Alert]")
                            Subject = Subject.Replace("[New Assignment] [New Assignment]", "[New Alert]")

                            Completed = AdvantageFramework.Email.Send(DbContext, SecurityDbContext, EmailToString, Subject,
                                                                      FinalEmailBody, Alert.PriorityLevel, AttachmentFiles.ToArray,
                                                                      SendingEmailStatus, ExceptionMessage, EmailCcString, String.Empty, FromEmployeeCode)

                        End If

                        If AdvantageFramework.Security.Impersonate.CheckNTAuthentication = True Then

                            ImpersonationContext.Undo()

                        End If

                        ErrorMessage = AdvantageFramework.Email.LoadEmailErrorMessage(SendingEmailStatus)

                        If SendingEmailStatus <> Email.SendingEmailStatus.EmailSent AndAlso ExceptionMessage <> "" Then

                            ErrorMessage &= Environment.NewLine & ExceptionMessage

                        End If

                    Catch ex As Exception
                    End Try

                    'Clean up attachments
                    Try

                        If AttachmentFiles IsNot Nothing Then

                            For Each AttachmentFile In AttachmentFiles

                                If AdvantageFramework.FileSystem.Delete(Agency, AttachmentFile) = False Then

                                    If System.IO.File.Exists(AttachmentFile) Then

                                        System.IO.File.Delete(AttachmentFile)

                                    End If

                                End If

                            Next

                        End If

                    Catch ex As Exception
                    End Try

                End If

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Completed = False
            Finally
                BuildAndSendAlertEmail = Completed
            End Try

        End Function
        Private Sub LoadAlertDetailsInTable(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal AlertDetails As AdvantageFramework.Email.Classes.Alert,
                                            ByRef HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail,
                                            ByVal IsClientPortal As Boolean)

            If HTMLEmail IsNot Nothing AndAlso AlertDetails IsNot Nothing Then

                If IsClientPortal = False Then

                    LoadAlertDetailsInTableInternal(DbContext, AlertDetails, HTMLEmail)

                Else

                    LoadAlertDetailsInTableClientPortal(AlertDetails, HTMLEmail)

                End If

            End If

        End Sub
        Private Sub LoadAlertDetailsInTableClientPortal(ByVal AlertDetails As AdvantageFramework.Email.Classes.Alert,
                                                        ByVal HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail)

            Dim TaskDescription As String = ""


            HtmlEmail.AddHeaderRow("Alert Details")

            Try

                If String.IsNullOrEmpty(AlertDetails.OfficeName) = False Then

                    HtmlEmail.AddKeyValueRow("Office", AlertDetails.OfficeName)

                End If

            Catch ex As Exception
            End Try
            Try

                If String.IsNullOrEmpty(AlertDetails.ClientName) = False Then

                    HtmlEmail.AddKeyValueRow("Client", AlertDetails.ClientName)

                End If

            Catch ex As Exception
            End Try
            Try

                If String.IsNullOrEmpty(AlertDetails.DivisionName) = False Then

                    HtmlEmail.AddKeyValueRow("Division", AlertDetails.DivisionName)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertDetails.ProductName) = False Then

                    HtmlEmail.AddKeyValueRow("Product", AlertDetails.ProductName)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertDetails.CampaignName) = False Then

                    HtmlEmail.AddKeyValueRow("Campaign", AlertDetails.CampaignName)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertDetails.JobDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Job", AlertDetails.JobNumber.ToString().PadLeft(6, "0") & " - " & AlertDetails.JobDescription)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertDetails.JobComponentDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Component", AlertDetails.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & AlertDetails.JobComponentDescription)

                End If

            Catch ex As Exception

            End Try

            HtmlEmail.AddBlankRow()

        End Sub
        Private Sub LoadAlertDetailsInTableInternal(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal AlertView As AdvantageFramework.Email.Classes.Alert,
                                                    ByRef HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail)

            Dim JobComponentTask As AdvantageFramework.Database.Entities.JobComponentTask = Nothing
            Dim TaskDescription As String = ""

            HtmlEmail.AddHeaderRow("Alert Details")

            Try

                If String.IsNullOrEmpty(AlertView.OfficeName) = False Then

                    HtmlEmail.AddKeyValueRow("Office", AlertView.OfficeName)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertView.ClientName) = False Then

                    HtmlEmail.AddKeyValueRow("Client", AlertView.ClientName)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertView.DivisionName) = False Then

                    HtmlEmail.AddKeyValueRow("Division", AlertView.DivisionName)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertView.ProductName) = False Then

                    HtmlEmail.AddKeyValueRow("Product", AlertView.ProductName)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertView.CampaignName) = False Then

                    HtmlEmail.AddKeyValueRow("Campaign", AlertView.CampaignName)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertView.JobDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Job", AlertView.JobNumber.ToString().PadLeft(6, "0") & " - " & AlertView.JobDescription)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertView.JobComponentDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Component", AlertView.JobComponentNumber.ToString().PadLeft(2, "0") & " - " & AlertView.JobComponentDescription)

                End If

            Catch ex As Exception

            End Try

            Try

                If String.IsNullOrEmpty(AlertView.TaskFunctionDescription) = False Then

                    TaskDescription = AlertView.TaskFunctionDescription

                End If
                If String.IsNullOrEmpty(TaskDescription) = False Then

                    HtmlEmail.AddKeyValueRow("Task", TaskDescription)

                End If

            Catch ex As Exception
            End Try

            If AlertView.AlertLevel = "PST" Then

                Try

                    JobComponentTask = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, AlertView.JobNumber, AlertView.JobComponentNumber, AlertView.TaskSequenceNumber)

                Catch ex As Exception
                End Try

                If JobComponentTask IsNot Nothing Then

                    If JobComponentTask.StartDate.HasValue Then

                        HtmlEmail.AddKeyValueRow("Start Date", JobComponentTask.StartDate.Value.ToShortDateString)

                    End If

                    If JobComponentTask.DueDate.HasValue Then

                        HtmlEmail.AddKeyValueRow("Due Date", JobComponentTask.DueDate.Value.ToShortDateString)

                    End If

                End If

            End If

            HtmlEmail.AddBlankRow()

        End Sub
        Public Function AddAlertRecipients(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal EmployeeCodesAndContactCodes As String) As Boolean

            Dim Completed As Boolean = False
            Dim Codes() As String

            Codes = AdvantageFramework.StringUtilities.CleanStringForSplit(EmployeeCodesAndContactCodes, ",").Split(",")

            If Codes.Length > 0 Then

                For Each Code As String In Codes

                    If Code.Contains("(CC)") = False Then

                        AddAlertRecipient(DbContext, AlertID, Code)

                    Else

                        If IsNumeric(Code) = True Then AddAlertClientContactRecipient(DbContext, AlertID, CType(Code, Integer))

                    End If

                Next

                Completed = True

            Else

                Completed = True

            End If

            Return Completed

        End Function
        Public Function AddAlertRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal EmployeeCode As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Employee IsNot Nothing Then

                    Added = AddAlertRecipient(DbContext, AlertID, Employee)

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddAlertRecipient = Added
            End Try

        End Function
        Public Function AddAlertRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal Employee As AdvantageFramework.Database.Views.Employee) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim EmailAddress As String = ""
            Dim AddRecipient As Boolean = True

            Try

                If CheckEmployeeAlertNotificationForEmail(Employee) Then

                    EmailAddress = LoadEmployeeEmailAddress(Employee)

                ElseIf CheckEmployeeAlertNotificationForAlert(Employee) Then

                    EmailAddress = ""

                Else

                    AddRecipient = False

                End If

                If AddRecipient Then

                    AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                    AlertRecipient.AlertID = AlertID
                    AlertRecipient.EmployeeCode = Employee.Code
                    AlertRecipient.EmployeeEmail = EmailAddress
                    AlertRecipient.DbContext = DbContext

                    If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient) Then

                        Added = True

                    End If

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddAlertRecipient = Added
            End Try

        End Function
        Public Function AddAlertComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal AlertID As Integer,
                                        ByVal CommentID As Integer?,
                                        ByVal Comment As String,
                                        ByVal ClientContactID As Integer?,
                                        ByVal DocumentList As String,
                                        ByVal DocumentID As Integer?) As Boolean

            'objects
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim Added As Boolean = False
            Dim LastAlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

            AlertComment = New Database.Entities.AlertComment

            AlertComment.AlertID = AlertID
            AlertComment.Comment = Comment
            AlertComment.UserCode = DbContext.UserCode
            AlertComment.GeneratedDate = Now
            AlertComment.HasEmailBeenSent = False
            AlertComment.ClientContactID = ClientContactID
            AlertComment.ParentID = CommentID
            AlertComment.DocumentID = DocumentID

            If AdvantageFramework.Database.Procedures.AlertComment.Insert(DbContext, AlertComment) Then

                Added = True

                AdvantageFramework.AlertSystem.UndismissCCsByAlertID(DbContext, AlertID)

                If Not String.IsNullOrWhiteSpace(DocumentList) Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ALERT_COMMENT] SET DOCUMENT_LIST = '{0}' WHERE COMMENT_ID = {1} AND ALERT_ID = {2}", DocumentList, AlertComment.ID, AlertComment.AlertID))

                End If

            End If

            Return Added

        End Function
        Public Function UpdateAlertComment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal CommentID As Integer,
                                           ByVal Comment As String,
                                           ByVal ClientContactID As Integer?,
                                           ByVal DocumentList As String,
                                           ByVal DocumentID As Integer?) As Boolean

            'objects
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing
            Dim Updated As Boolean = False
            Dim AlertID As Integer = 0

            AlertComment = AdvantageFramework.Database.Procedures.AlertComment.LoadByCommentID(DbContext, CommentID)

            If AlertComment IsNot Nothing Then

                AlertID = AlertComment.AlertID
                AlertComment.Comment = Comment
                AlertComment.GeneratedDate = Now
                AlertComment.HasEmailBeenSent = False
                AlertComment.ClientContactID = ClientContactID
                AlertComment.ParentID = CommentID
                AlertComment.DocumentID = DocumentID

                If AdvantageFramework.Database.Procedures.AlertComment.Update(DbContext, AlertComment) = True Then

                    Updated = True

                    AdvantageFramework.AlertSystem.UndismissCCsByAlertID(DbContext, AlertID)

                    If Not String.IsNullOrWhiteSpace(DocumentList) Then

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ALERT_COMMENT] SET DOCUMENT_LIST = '{0}' WHERE COMMENT_ID = {1} AND ALERT_ID = {2}", DocumentList, AlertComment.ID, AlertComment.AlertID))

                    End If

                End If

            End If

            Return Updated

        End Function
        Public Function AddAlertClientContactRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal ContactID As Integer) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim AlertRecipient As AdvantageFramework.Database.Entities.AlertRecipient = Nothing
            Dim EmailAddress As String = ""
            Dim AddRecipient As Boolean = True

            Try

                ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, ContactID)

                If ClientContact IsNot Nothing Then

                    If CheckClientContactAlertNotificationForEmail(ClientContact) Then

                        EmailAddress = LoadClientContactEmailAddress(ClientContact)

                    ElseIf CheckClientContactAlertNotificationForAlert(ClientContact) Then

                        EmailAddress = ""

                    Else

                        AddRecipient = False

                    End If

                    If AddRecipient Then

                        AlertRecipient = New AdvantageFramework.Database.Entities.AlertRecipient

                        AlertRecipient.AlertID = AlertID
                        'AlertRecipient.cl = EmployeeCode
                        AlertRecipient.EmployeeEmail = EmailAddress
                        AlertRecipient.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, AlertRecipient) Then

                            Added = True

                        End If

                    End If

                End If


            Catch ex As Exception
                Added = False
            Finally
                AddAlertClientContactRecipient = Added
            End Try

        End Function
        Private Function LoadClientContactEmailAddress(ByVal ClientContact As AdvantageFramework.Database.Entities.ClientContact, Optional ByVal CheckEmailFlag As Boolean = False, Optional ByVal GetMailBeeFormatted As Boolean = False) As String

            'objects
            Dim EmailAddress As String = ""
            Dim LoadEmail As Boolean = True

            Try

                If CheckEmailFlag Then

                    LoadEmail = CheckClientContactAlertNotificationForEmail(ClientContact)

                End If

                If LoadEmail Then

                    If GetMailBeeFormatted Then

                        EmailAddress = ClientContact.ToString() & " <" & ClientContact.EmailAddress & ">"

                    Else

                        EmailAddress = ClientContact.EmailAddress

                    End If

                End If

            Catch ex As Exception
                EmailAddress = ""
            Finally
                LoadClientContactEmailAddress = EmailAddress
            End Try

        End Function

        Public Function SetAssignmentUnassigned(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                                ByVal UserCode As String) As Boolean

            Dim Success As Boolean = False

            Try

                Success = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[usp_wv_ALERT_NOTIFY_SAVE] '{0}', {1}, '{2}', {3}, {4}, {5}, '{6}', {7}, {8}, {9}",
                                                                                    If(Alert.IsCPAlert, Alert.ClientContactID, UserCode),
                                                                                    Alert.ID,
                                                                                    "",
                                                                                    0,
                                                                                    Alert.AlertStateID,
                                                                                    Alert.AlertAssignmentTemplateID,
                                                                                    "",
                                                                                    1,
                                                                                    1,
                                                                                    0)).FirstOrDefault()

            Catch ex As Exception
                Success = False
            End Try

            Return Success

        End Function
        Public Function CompleteAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                           ByVal EmployeeCode As String,
                                           ByVal UserCode As String,
                                           ByVal ProofingStatusID As Integer?,
                                           ByVal DocumentID As Integer?) As AdvantageFramework.AlertSystem.CompleteAssignmentResult

            Dim Result As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing
            Dim Completed As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Dim SqlParameterAlertId As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterUserCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterProofingStatusID As System.Data.SqlClient.SqlParameter = Nothing
                Dim SqlParameterDocumentID As System.Data.SqlClient.SqlParameter = Nothing
                'Dim EmployeeDismissingIsAssignee As Boolean = False
                'Dim CurrentAssigneeEmployeeCode As String = String.Empty
                'Dim TempCompleteTaskAgencySettingValue As Short = 0
                'Dim FullCompleteTaskAgencySettingValue As Short = 0
                'Dim ShowTaskTempCompletePrompt As Boolean = False '????
                'Dim ShowTaskFullyCompletePrompt As Boolean = False '????

                SqlParameterAlertId = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                SqlParameterUserCode = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                SqlParameterProofingStatusID = New System.Data.SqlClient.SqlParameter("@PROOFING_STATUS_ID", SqlDbType.Int)
                SqlParameterDocumentID = New System.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int)

                SqlParameterAlertId.Value = Alert.ID
                SqlParameterUserCode.Value = UserCode
                SqlParameterEmployeeCode.Value = EmployeeCode

                If ProofingStatusID IsNot Nothing AndAlso ProofingStatusID > 0 Then

                    SqlParameterProofingStatusID.Value = ProofingStatusID

                Else

                    SqlParameterProofingStatusID.Value = System.DBNull.Value

                End If
                If DocumentID IsNot Nothing AndAlso DocumentID > 0 Then

                    SqlParameterDocumentID.Value = DocumentID

                Else

                    SqlParameterDocumentID.Value = System.DBNull.Value

                End If

                Try

                    Result = DbContext.Database.SqlQuery(Of AdvantageFramework.AlertSystem.CompleteAssignmentResult)("EXEC [dbo].[advsp_alert_complete_assignment] @ALERT_ID, @USER_CODE, @EMP_CODE, @PROOFING_STATUS_ID;",
                                                                                                                      SqlParameterAlertId,
                                                                                                                      SqlParameterUserCode,
                                                                                                                      SqlParameterEmployeeCode,
                                                                                                                      SqlParameterProofingStatusID,
                                                                                                                      SqlParameterDocumentID).SingleOrDefault

                Catch ex As Exception
                    ErrorMessage = ex.Message.ToString()
                    Completed = False
                End Try

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                Completed = False
            End Try

            If Result Is Nothing Then

                Result = New AdvantageFramework.AlertSystem.CompleteAssignmentResult
                Result.Success = Completed
                Result.Message = ErrorMessage

            End If

            Return Result

        End Function
        Public Function UnCompleteAssignment(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                             ByVal EmployeeCode As String,
                                             ByVal UserCode As String) As AdvantageFramework.AlertSystem.CompleteAssignmentResult

            Return CompleteAssignment(DbContext, Alert, EmployeeCode, UserCode, Nothing, Nothing)

        End Function
        Public Function UndismissCCsByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertID As Integer) As Boolean

            Dim DismissedCCEmpCodes As Generic.List(Of String) = Nothing
            Dim Undismissed As Boolean = True

            Try

                DismissedCCEmpCodes = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT DISTINCT ARD.EMP_CODE FROM ALERT_RCPT_DISMISSED ARD WITH(NOLOCK) WHERE (ARD.CURRENT_NOTIFY IS NULL OR ARD.CURRENT_NOTIFY = 0) AND ARD.ALERT_ID = {0};", AlertID)).ToList

                If DismissedCCEmpCodes IsNot Nothing Then

                    For Each EmployeeCode As String In DismissedCCEmpCodes

                        AdvantageFramework.AlertSystem.UnDismissAlertByAlertIDAndEmployeeCode(DbContext, AlertID, EmployeeCode, DbContext.UserCode)

                    Next

                End If

            Catch ex As Exception
                Undismissed = False
            End Try

            Return Undismissed

        End Function
        Public Function UnDismissAlert(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByRef Alert As AdvantageFramework.Database.Entities.Alert,
                                       ByVal EmployeeCode As String,
                                       ByVal UserCode As String) As Boolean

            Dim Success As Boolean = False

            Try

                Success = UnDismissAlertByAlertIDAndEmployeeCode(DbContext, Alert.ID, EmployeeCode, UserCode)

            Catch ex As Exception
                Success = False
            End Try

            Return Success

        End Function
        Public Function UnDismissAlertByAlertIDAndEmployeeCode(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                               ByRef AlertID As Integer,
                                                               ByVal EmployeeCode As String,
                                                               ByVal UserCode As String) As Boolean

            Dim Success As Boolean = False

            Try

                Success = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[usp_wv_ALERT_UNDISMISS] {0}, '{1}', '{2}', 0, 0, 0;",
                                                                                    AlertID,
                                                                                    UserCode,
                                                                                    EmployeeCode)).FirstOrDefault()

            Catch ex As Exception
                Success = False
            End Try

            Return Success

        End Function

        Public Sub LoadWebvantageAndClientPortalURLs(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByRef WebvantageURL As String, ByRef ClientPortalURL As String)

            Try

                Dim Agency As AdvantageFramework.Database.Entities.Agency

                Agency = Nothing
                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                If Agency IsNot Nothing Then

                    WebvantageURL = Agency.WebvantageURL

                End If

            Catch ex As Exception
                WebvantageURL = String.Empty
            End Try
            Try

                ClientPortalURL = DbContext.Database.SqlQuery(Of String)("SELECT TOP 1 ISNULL(CP_APPLICATION_FOLDER, '') FROM CP_SETTINGS WITH(NOLOCK);").FirstOrDefault

            Catch ex As Exception
                ClientPortalURL = String.Empty
            End Try


        End Sub

        Public Function GetAlertMentions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal AlertId As Integer, ByVal UserCode As String) As String()

            Dim Mentions As String() = Nothing
            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim EmpCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            EmpCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)

            AlertIDSqlParameter.Value = AlertId
            EmpCodeSqlParameter.Value = UserCode

            Try

                Mentions = DbContext.Database.SqlQuery(Of String)("EXEC [dbo].[usp_wv_ALERT_GET_MENTIONS] @ALERT_ID, @USER_CODE;",
                                                         AlertIDSqlParameter,
                                                         EmpCodeSqlParameter
                                                         ).ToArray

            Catch ex As Exception

            End Try

            Return Mentions

        End Function

        Public Sub RemoveAlertMentions(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                     ByVal AlertId As Integer, ByVal UserCode As String)

            Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim DescriptionMentionSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            AlertIDSqlParameter = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            DescriptionMentionSqlParameter = New System.Data.SqlClient.SqlParameter("@DESCRIPTION_MENTION", SqlDbType.Int)
            UserCodeSqlParameter = New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 6)

            AlertIDSqlParameter.Value = AlertId
            DescriptionMentionSqlParameter.Value = 0
            UserCodeSqlParameter.Value = UserCode

            Try

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_ALERT_REMOVE_MENTION] @ALERT_ID, @DESCRIPTION_MENTION, @USER_CODE;",
                                                         AlertIDSqlParameter,
                                                         DescriptionMentionSqlParameter,
                                                         UserCodeSqlParameter)

            Catch ex As Exception

            End Try

        End Sub

        Public Function LoadEmployeeEmailAddress(ByVal Employee As AdvantageFramework.Database.Views.Employee, Optional ByVal CheckEmailFlag As Boolean = False, Optional ByVal GetMailBeeFormatted As Boolean = False) As String

            'objects
            Dim EmailAddress As String = ""
            Dim LoadEmail As Boolean = True

            Try

                If CheckEmailFlag Then

                    LoadEmail = CheckEmployeeAlertNotificationForEmail(Employee)

                End If

                If LoadEmail Then

                    If GetMailBeeFormatted Then

                        EmailAddress = Employee.ToString() & " <" & Employee.Email & ">"

                    Else

                        EmailAddress = Employee.Email

                    End If

                End If

            Catch ex As Exception
                EmailAddress = ""
            Finally
                LoadEmployeeEmailAddress = EmailAddress
            End Try

        End Function
        Private Function LoadEmployeeFromAddress(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal EmployeeCode As String) As String

            'objects
            Dim FromAddress As String = ""
            Dim FullAddress As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing

            Try

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                If Agency.UseEmployeeLogin = 1 AndAlso String.IsNullOrEmpty(Employee.Email) = False Then

                    FromAddress = Employee.Email

                Else

                    FromAddress = Agency.SMTPUserName

                End If

                FullAddress = Employee.ToString & " <" & FromAddress & "> "

            Catch ex As Exception
                FullAddress = Agency.SMTPUserName
            Finally
                LoadEmployeeFromAddress = FullAddress
            End Try

        End Function
        Private Function CheckAlertOriginator(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Alert As AdvantageFramework.Database.Entities.Alert) As String

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeCode As String = ""

            Try

                Employee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                            Where Entity.Code = Alert.EmployeeCode AndAlso
                                  (Employee.AlertNotificationType = 1 OrElse Employee.AlertNotificationType = 3) AndAlso
                                  (Employee.TerminationDate Is Nothing OrElse Employee.TerminationDate > System.DateTime.Today)
                            Select Entity).SingleOrDefault

                EmployeeCode = Employee.Code

            Catch ex As Exception
                EmployeeCode = Nothing
            Finally
                CheckAlertOriginator = EmployeeCode
            End Try

        End Function
        Public Function UpdateAssignmentRecipient(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal AlertID As Integer, ByVal AssignedEmployeeCode As String) As Boolean

            'objects
            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ALERT_RCPT WITH(ROWLOCK) SET PROCESSED = NULL, NEW_ALERT = NULL, READ_ALERT = NULL WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND CURRENT_NOTIFY = 1",
                                                                   AlertID, AssignedEmployeeCode))

            Catch ex As Exception
                Updated = False
            Finally
                UpdateAssignmentRecipient = Updated
            End Try

        End Function
        Public Function MarkCCsUnread(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal AlertID As Integer, ByVal AssignedEmployeeCode As String) As Boolean

            'objects
            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ALERT_RCPT] WITH(ROWLOCK) SET READ_ALERT = NULL WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND (CURRENT_RCPT = 0 OR CURRENT_RCPT IS NULL)",
                                                                   AlertID, AssignedEmployeeCode))

            Catch ex As Exception
                Updated = False
            Finally
            End Try

            Return Updated

        End Function
        Public Function MarkAssigneeUnread(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                           ByVal AssignedEmployeeCode As String) As Boolean

            Dim Updated As Boolean = True

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[ALERT_RCPT] WITH(ROWLOCK) SET READ_ALERT = NULL WHERE ALERT_ID = {0} AND EMP_CODE = '{1}' AND CURRENT_NOTIFY = 1;",
                                                                   Alert.ID, AssignedEmployeeCode))

                If Alert.AlertCategoryID = 71 OrElse Alert.AlertLevel = "BRD" OrElse Alert.AlertLevel = "PST" Then

                    DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[JOB_TRAFFIC_DET_EMPS] WITH(ROWLOCK) SET READ_ALERT = NULL WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1} AND SEQ_NBR = {2} AND EMP_CODE = '{3}';",
                                                                       Alert.JobNumber, Alert.JobComponentNumber, Alert.TaskSequenceNumber, AssignedEmployeeCode))

                End If

            Catch ex As Exception
                Updated = False
            Finally
            End Try

            Return Updated

        End Function
        Public Function UpdateAlertRecipients(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertID As Integer, ByVal AlertRecipients As Generic.List(Of AdvantageFramework.Database.Classes.AlertEmailRecipient),
                                              ByRef ErrorMessage As String, Optional ByVal EmployeeSession As String = "") As Boolean

            Dim Success As Boolean = True
            Dim EmployeeCodes As String = String.Empty

            If AlertRecipients IsNot Nothing Then

                EmployeeCodes = String.Join(",", (From Entity In AlertRecipients
                                                  Select "'" & Entity.EmployeeCode & "'").ToArray)

                Success = UpdateAlertRecipients(DbContext, AlertID, EmployeeCodes, "", True, EmployeeSession, ErrorMessage)

            End If

            Return Success

        End Function
        Public Function UpdateAlertRecipients(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal AlertId As Integer, ByVal EmpCodeListChecked As String, ByVal EmpCodeListUnChecked As String,
                                              ByVal MarkAsNew As Boolean, ByVal LeaveEmployeeCodeReadFlag As String, ByRef ErrorMessage As String) As Boolean

            Dim Success As Boolean = True

            Try

                Dim arP(5) As System.Data.SqlClient.SqlParameter

                Dim pAlertId As New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
                pAlertId.Value = AlertId
                arP(0) = pAlertId

                Dim pEmpCodeListChecked As New System.Data.SqlClient.SqlParameter("@EMP_LIST_CHECKED", SqlDbType.VarChar)
                pEmpCodeListChecked.Value = EmpCodeListChecked
                arP(1) = pEmpCodeListChecked

                Dim pEmpCodeListUnChecked As New System.Data.SqlClient.SqlParameter("@EMP_LIST_UNCHECKED", SqlDbType.VarChar)
                pEmpCodeListUnChecked.Value = EmpCodeListUnChecked
                arP(2) = pEmpCodeListUnChecked

                Dim pMarkAsNew As New System.Data.SqlClient.SqlParameter("@SET_AS_NEW", SqlDbType.Bit)
                pMarkAsNew.Value = MarkAsNew
                arP(3) = pMarkAsNew

                Dim pLeaveEmployeeCode As New System.Data.SqlClient.SqlParameter("@LEAVE_READ_EMP_CODE", SqlDbType.VarChar)
                pLeaveEmployeeCode.Value = LeaveEmployeeCodeReadFlag
                arP(4) = pLeaveEmployeeCode

                DbContext.Database.ExecuteSqlCommand(String.Format("[dbo].[usp_wv_ALERT_UPDATE_RECIPIENTS] @ALERT_ID, @EMP_LIST_CHECKED, @EMP_LIST_UNCHECKED, @SET_AS_NEW, @LEAVE_READ_EMP_CODE"),
                                                     pAlertId, pEmpCodeListChecked, pEmpCodeListUnChecked, pMarkAsNew, pLeaveEmployeeCode)

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Success

        End Function
        Public Function GeneralInformation(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByVal AlertView As AdvantageFramework.Email.Classes.Alert,
                                           ByVal IsClientPortal As Boolean,
                                           ByVal ClientPortalUserID As Integer) As String

            'objects
            Dim GeneralInfo As String = ""
            Dim AlternateAlertID As Integer = Nothing
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing

            Try

                Try

                    AlternateAlertID = AlertView.AlertSequenceNumber

                Catch ex As Exception
                    AlternateAlertID = 0
                End Try

                If AlternateAlertID = 0 Then

                    AlternateAlertID = AlertView.ID

                End If

                HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False)

                HtmlEmail.AddHeaderRow("General Information")
                HtmlEmail.AddKeyValueRow("ID", AlternateAlertID.ToString)

                If IsClientPortal = True Then

                    HtmlEmail.AddKeyValueRow("", "Client Portal Alert")

                End If

                HtmlEmail.AddKeyValueRow("Generated", String.Format("{0:G}", LocalDate(DbContext, AlertView.GeneratedDate)))

                If IsClientPortal = True Then

                    Try

                        HtmlEmail.AddKeyValueRow("By", AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, ClientPortalUserID).ToString)

                    Catch ex As Exception
                    End Try

                Else

                    Try

                        DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 ISNULL(E.EMP_FNAME + ' ', '') + ISNULL(E.EMP_MI + '. ','') + ISNULL(E.EMP_LNAME,'') FROM SEC_USER SU INNER JOIN EMPLOYEE E ON SU.EMP_CODE = E.EMP_CODE WHERE USER_CODE = '{0}';",
                                                                             AlertView.UserCode)).SingleOrDefault

                    Catch ex As Exception
                        HtmlEmail.AddKeyValueRow("By", AlertView.UserCode)
                    End Try

                End If

                Try

                    If AlertView.AlertCategoryID <> Nothing Then

                        HtmlEmail.AddKeyValueRow("Type", AdvantageFramework.Database.Procedures.AlertCategory.LoadByID(DbContext, AlertView.AlertCategoryID).Description)

                    End If

                Catch ex As Exception
                End Try
                Try

                    If AlertView.PriorityLevel IsNot Nothing Then

                        HtmlEmail.AddKeyValueRow("Priority", [Enum].GetName(GetType(AdvantageFramework.AlertSystem.PriorityLevels), AlertView.PriorityLevel))

                    End If

                Catch ex As Exception
                End Try
                Try

                    Dim BoardNameBoardStatename As BoardInfo = Nothing
                    Dim SQL As String = String.Format("SELECT TOP 1 B.[NAME] AS BoardName, ALS.ALERT_STATE_NAME AS BoardStateName " &
                                                      "FROM  SPRINT_DTL SD INNER JOIN SPRINT_HDR SH ON SD.SPRINT_HDR_ID = SH.ID INNER JOIN ALERT A ON SD.ALERT_ID = A.ALERT_ID INNER JOIN BOARD B ON B.ID = SH.BOARD_ID INNER JOIN ALERT_STATES ALS ON ALS.ALERT_STATE_ID = A.BOARD_STATE_ID " &
                                                      "WHERE SD.ALERT_ID = {0} ORDER BY SH.IS_ACTIVE DESC, SH.IS_COMPLETE ASC;", AlertView.ID)

                    BoardNameBoardStatename = DbContext.Database.SqlQuery(Of BoardInfo)(SQL).SingleOrDefault

                    If BoardNameBoardStatename IsNot Nothing Then

                        If String.IsNullOrWhiteSpace(BoardNameBoardStatename.BoardName) = False Then

                            HtmlEmail.AddKeyValueRow("Board", BoardNameBoardStatename.BoardName)

                        End If
                        If String.IsNullOrWhiteSpace(BoardNameBoardStatename.BoardStateName) = False Then

                            HtmlEmail.AddKeyValueRow("Board State", BoardNameBoardStatename.BoardStateName)

                        End If

                    End If

                Catch ex As Exception
                End Try
                Try

                    If AlertView.StartDate.HasValue Then

                        HtmlEmail.AddKeyValueRow("Start Date", String.Format("{0:d}", AlertView.StartDate))

                    End If

                Catch ex As Exception
                End Try
                Try

                    If AlertView.DueDate.HasValue Then

                        HtmlEmail.AddKeyValueRow("Due Date", String.Format("{0:d}", AlertView.DueDate))

                    End If

                Catch ex As Exception
                End Try

                Try

                    If String.IsNullOrEmpty(AlertView.TimeDue) = False Then

                        HtmlEmail.AddKeyValueRow("Time Due", AlertView.TimeDue)

                    End If

                Catch ex As Exception
                End Try

                Try

                    If String.IsNullOrEmpty(AlertView.VersionName) = False Then

                        HtmlEmail.AddKeyValueRow("Version", AlertView.VersionName)

                    End If

                Catch ex As Exception
                End Try

                Try

                    If String.IsNullOrEmpty(AlertView.BuildName) = False Then

                        HtmlEmail.AddKeyValueRow("Build", AlertView.BuildName)

                    End If

                Catch ex As Exception
                End Try

                HtmlEmail.Finish()

                GeneralInfo = HtmlEmail.ToString

            Catch ex As Exception
                GeneralInfo = ""
            Finally
                GeneralInformation = GeneralInfo
            End Try

        End Function
        <Serializable()>
        Public Class BoardInfo
            Public Property BoardName As String
            Public Property BoardStateName As String
            Sub New()

            End Sub
        End Class
        Public Sub SetPriority(ByRef EmailMessage As MailBee.SmtpMail.Smtp, ByVal PriorityLevel As AdvantageFramework.AlertSystem.PriorityLevels)

            Dim MailBeePriorityLevel As MailBee.Mime.MailPriority = MailBee.Mime.MailPriority.Normal

            MailBeePriorityLevel = CType(CType(PriorityLevel, Integer), MailBee.Mime.MailPriority)

            AdvantageFramework.Email.SetPriority(EmailMessage, MailBeePriorityLevel)

        End Sub
        Private Sub UpdateAlertAttachment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal AlertAttachmentID As Integer)

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.ALERT_ATTACHMENT WITH(ROWLOCK) SET EMAILSENT = 1 WHERE ATTACHMENT_ID = {0} AND ALERT_ID = {1}", AlertAttachmentID, AlertID))

            Catch ex As Exception

            End Try

        End Sub
        Public Function IsAlertAnAlertAssignment(ByVal Alert As AdvantageFramework.Database.Entities.Alert) As Boolean

            'objects
            Dim IsAnAlertAssignment As Boolean = False

            If Alert IsNot Nothing Then

                If (Alert.AlertStateID IsNot Nothing AndAlso Alert.AlertAssignmentTemplateID IsNot Nothing AndAlso
                    Alert.AlertStateID > 0 AndAlso Alert.AlertAssignmentTemplateID > 0) Then

                    IsAnAlertAssignment = True

                End If

            End If

            IsAlertAnAlertAssignment = IsAnAlertAssignment

        End Function
        Public Function CreateAndSendAlertAssignment(ByVal Session As AdvantageFramework.Security.Session, ByVal AlertTypeID As Integer, ByVal AlertCategoryID As Integer,
                                                     ByVal AlertLevel As String, ByVal AlertAssignmentTemplateID As Integer, ByVal AlertStateID As Integer, ByVal PriorityLevel As PriorityLevels,
                                                     ByVal Subject As String, ByVal Body As String, ByVal EmailBody As String, ByVal EmployeeCode As String,
                                                     ByVal UserCode As String, ByVal AssignedToEmployeeCode As String, ByVal ExcludeAttachments As Boolean,
                                                     ByRef ErrorMessage As String, ByRef EmailSent As Boolean,
                                                     Optional ByVal DueDate As Nullable(Of Date) = Nothing, Optional ByVal TimeDue As String = Nothing, Optional ByVal DocumentIDs() As Integer = Nothing, Optional ByVal OfficeCode As String = Nothing,
                                                     Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing,
                                                     Optional ByVal CampaignCode As String = Nothing, Optional ByVal JobNumber As Integer = Nothing, Optional ByVal JobComponentNumber As Short = Nothing,
                                                     Optional ByVal EstimateNumber As Integer = Nothing, Optional ByVal EstimateComponentNumber As Short = Nothing, Optional ByVal EstimateQuoteNumber As Short = Nothing,
                                                     Optional ByVal EstimateRevisionNumber As Short = Nothing, Optional ByVal VendorCode As String = Nothing, Optional ByVal PONumber As Integer = Nothing,
                                                     Optional ByVal PORevisionNumber As Short = Nothing, Optional ByVal AccountPayableID As Integer = Nothing, Optional ByVal AccountPayableSequenceNumber As Short = Nothing,
                                                     Optional ByVal CampaignID As Integer = Nothing, Optional ByVal ClientContactID As Integer = Nothing, Optional ByVal IsCPAlert As Boolean = False) As Boolean

            'objects
            Dim AlertCreated As Boolean = False
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim IsUnassigned As Boolean = False
            Dim AlertAttachment As AdvantageFramework.Database.Entities.AlertAttachment = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    Alert = New AdvantageFramework.Database.Entities.Alert

                    Alert.DbContext = DbContext

                    Alert.AlertTypeID = AlertTypeID
                    Alert.AlertCategoryID = AlertCategoryID
                    Alert.AlertLevel = AlertLevel
                    Alert.AlertAssignmentTemplateID = AlertAssignmentTemplateID
                    Alert.AlertStateID = AlertStateID
                    Alert.PriorityLevel = PriorityLevel
                    Alert.DueDate = DueDate
                    Alert.TimeDue = TimeDue
                    Alert.Subject = Subject
                    Alert.Body = Body
                    Alert.EmailBody = EmailBody
                    Alert.GeneratedDate = System.DateTime.Now

                    If IsAlertAnAlertAssignment(Alert) = True Then

                        Alert.IsWorkItem = True

                    End If

                    If IsCPAlert Then

                        Alert.EmployeeCode = ""
                        Alert.UserCode = ClientContactID
                        Alert.IsCPAlert = 1
                        Alert.ClientContactID = ClientContactID

                    Else

                        Alert.EmployeeCode = EmployeeCode
                        Alert.UserCode = UserCode
                        Alert.IsCPAlert = Nothing
                        Alert.ClientContactID = Nothing

                    End If

                    Alert.OfficeCode = OfficeCode
                    Alert.ClientCode = ClientCode
                    Alert.DivisionCode = DivisionCode
                    Alert.ProductCode = ProductCode
                    Alert.CampaignCode = CampaignCode
                    Alert.JobNumber = JobNumber
                    Alert.JobComponentNumber = JobComponentNumber
                    Alert.EstimateNumber = EstimateNumber
                    Alert.EstimateComponentNumber = EstimateComponentNumber
                    Alert.EstimateQuoteNumber = EstimateQuoteNumber
                    Alert.EstimateRevisionNumber = EstimateRevisionNumber
                    Alert.VendorCode = VendorCode
                    Alert.PONumber = PONumber
                    Alert.PORevisionNumber = PORevisionNumber
                    Alert.AccountPayableID = AccountPayableID
                    Alert.AccountPayableSequenceNumber = AccountPayableSequenceNumber
                    Alert.CampaignID = CampaignID

                    If AdvantageFramework.Database.Procedures.Alert.Insert(DbContext, Alert) Then

                        Try

                            If (AssignedToEmployeeCode.Trim().ToLower().IndexOf("unassigned") > -1 OrElse AssignedToEmployeeCode.Trim().ToLower().IndexOf("un-assigned") > -1) Then

                                IsUnassigned = True

                            End If

                        Catch ex As Exception
                            IsUnassigned = False
                        End Try

                        Try

                            AlertCreated = DbContext.Database.SqlQuery(Of Boolean)(String.Format("EXEC [dbo].[usp_wv_ALERT_NOTIFY_SAVE] '{0}', {1}, '{2}', {3}, {4}, {5}, '{6}', {7}, {8}, {9}", If(IsCPAlert, ClientContactID, UserCode), Alert.ID, AssignedToEmployeeCode, 0, AlertStateID, AlertAssignmentTemplateID, "", If(IsUnassigned, 1, 0), 1, 1)).FirstOrDefault()

                        Catch ex As Exception
                            AlertCreated = False
                        End Try

                        If AlertCreated Then

                            If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Length > 0 Then

                                For Each DocumentID In DocumentIDs

                                    AlertAttachment = New AdvantageFramework.Database.Entities.AlertAttachment

                                    AlertAttachment.DbContext = DbContext
                                    AlertAttachment.AlertID = Alert.ID
                                    AlertAttachment.GeneratedDate = System.DateTime.Now
                                    AlertAttachment.DocumentID = DocumentID
                                    AlertAttachment.HasEmailBeenSent = False

                                    If IsCPAlert Then

                                        AlertAttachment.UserCode = ""
                                        AlertAttachment.ClientContactID = ClientContactID

                                    Else

                                        AlertAttachment.UserCode = UserCode
                                        AlertAttachment.ClientContactID = Nothing

                                    End If

                                    AdvantageFramework.Database.Procedures.AlertAttachment.Insert(DbContext, AlertAttachment)

                                Next

                            End If

                        End If

                    End If

                End Using

                If AlertCreated Then

                    EmailSent = AdvantageFramework.AlertSystem.BuildAndSendAlertEmail(Session, Alert, "[New Alert]", Nothing, Nothing, Nothing, Nothing, ExcludeAttachments, False, IsCPAlert, True, "", "", ErrorMessage)

                End If

            Catch ex As Exception
                AlertCreated = False
            Finally
                CreateAndSendAlertAssignment = AlertCreated
            End Try

        End Function
        Public Function LoadSourceApps(ByVal ConnectionString As String, ByVal Application As AdvantageFramework.Security.Application, ByVal ShowAll As Boolean, Optional ByRef ErrorMessage As String = "") As System.Data.SqlClient.SqlDataReader

            Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
            Dim SqlCommand As System.Data.SqlClient.SqlCommand = Nothing
            Dim StringBuilder As System.Text.StringBuilder = Nothing

            Try

                StringBuilder = New System.Text.StringBuilder

                With StringBuilder

                    .Append("SELECT ID, SOURCE_APP_CODE, SOURCE_APP_DESC FROM ALERT_DFLT_SBJ_SRC WITH(NOLOCK) WHERE 1 =1 ")

                    If ShowAll = False Then

                        .Append("AND USER_VISIBLE = 1 ")

                    End If

                    Select Case Application

                        Case Security.Application.Webvantage

                        Case Security.Application.Client_Portal

                            .Append("AND CP_VISIBLE = 1 ")

                    End Select

                    .Append(";")

                End With

                Using SqlConnection As New System.Data.SqlClient.SqlConnection(ConnectionString)

                    SqlCommand = New System.Data.SqlClient.SqlCommand

                    With SqlCommand

                        .CommandType = CommandType.Text
                        .CommandText = StringBuilder.ToString()
                        .Connection = SqlConnection

                    End With

                    SqlConnection.Open()

                    SqlDataReader = SqlCommand.ExecuteReader()

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString()
                SqlDataReader = Nothing
            End Try

            LoadSourceApps = SqlDataReader

        End Function

        Public Function LocalDate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal [Date] As Date) As Date

            Dim NewDate As Date = [Date]

            Try

                Dim DatabaseGMT As Decimal = 0.0
                Dim AgencyGMT As Decimal = 0.0

                LoadGMT(DbContext, AgencyGMT, DatabaseGMT)

                If DatabaseGMT <> AgencyGMT Then

                    NewDate = LocalDate(DatabaseGMT, AgencyGMT, [Date])

                End If

            Catch ex As Exception

                NewDate = [Date]

            Finally

                LocalDate = NewDate

            End Try

        End Function
        Public Function LocalDate(ByVal DatabaseGMTHours As Decimal, ByVal AgencyGMTHours As Decimal, ByVal [Date] As DateTime) As DateTime

            Dim NewDate As DateTime = [Date]

            Try

                If DatabaseGMTHours <> AgencyGMTHours Then

                    NewDate = GetOffsetDateTime(AgencyGMTHours - DatabaseGMTHours, [Date])

                End If

            Catch ex As Exception
                NewDate = [Date]
            Finally
                LocalDate = NewDate
            End Try

        End Function
        Public Function GetOffsetDateTime(ByVal OffSet As Decimal, ByVal [Date] As DateTime) As DateTime

            Return DateAdd(DateInterval.Minute, (CType(OffSet, Integer) * 60) + (OffSet - CType(OffSet, Integer)), [Date])

        End Function
        Public Sub LoadGMT(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef AgencyGMT As Double, ByRef DatabaseGMT As Double)

            AgencyGMT = 0.0
            DatabaseGMT = 0.0

            Using DataContext As New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                DatabaseGMT = AdvantageFramework.Database.Procedures.Generic.LoadSQLHoursOffset(DataContext)
                AgencyGMT = AdvantageFramework.Database.Procedures.Generic.LoadAgencyHoursOffset(DataContext)

            End Using

        End Sub

        Public Sub ExternalLinkToInternalLink(ByRef BodyHTML As String, ByRef Agency As AdvantageFramework.Database.Entities.Agency)

            ExternalLinkToInternalLink(BodyHTML, Agency.WebvantageURL, Agency.ClientPortalURL)

        End Sub
        Public Sub ExternalLinkToInternalLink(ByRef BodyHTML As String, ByVal WebvantageURL As String, ByVal ClientPortalURL As String)

            If String.IsNullOrWhiteSpace(WebvantageURL) = False AndAlso WebvantageURL.EndsWith("/") = True Then WebvantageURL = WebvantageURL.Substring(0, WebvantageURL.Length - 1)
            If String.IsNullOrWhiteSpace(ClientPortalURL) = False AndAlso ClientPortalURL.EndsWith("/") = True Then ClientPortalURL = ClientPortalURL.Substring(0, ClientPortalURL.Length - 1)

            'Dim Page As String = String.Empty
            'Dim HtmlSnippet As New HtmlAgilityPack.HtmlDocument
            'Dim HrefAttribute As HtmlAgilityPack.HtmlAttribute

            'WebvantageURL = WebvantageURL
            'ClientPortalURL = ClientPortalURL

            'If WebvantageURL.EndsWith("/") = True Then WebvantageURL = WebvantageURL.Substring(0, WebvantageURL.Length - 1)
            'If ClientPortalURL.EndsWith("/") = True Then ClientPortalURL = ClientPortalURL.Substring(0, ClientPortalURL.Length - 1)

            'BodyHTML = BodyHTML.Replace(Environment.NewLine, "")
            'BodyHTML = BodyHTML.Replace("""", "'")

            'HtmlSnippet.LoadHtml(BodyHTML)

            'Dim Nodes As HtmlNodeCollection = Nothing

            'Try

            '    Nodes = HtmlSnippet.DocumentNode.SelectNodes("//a[@href]")

            'Catch ex As Exception
            '    Nodes = Nothing
            'End Try

            'If Nodes IsNot Nothing Then

            '    For Each Link As HtmlAgilityPack.HtmlNode In Nodes

            '        HrefAttribute = Nothing
            '        HrefAttribute = Link.Attributes("href")

            '        If HrefAttribute IsNot Nothing Then

            '            If HrefAttribute.Value.Contains(WebvantageURL) = True Then

            '                Page = HrefAttribute.Value.Replace(WebvantageURL, "")

            '            ElseIf HrefAttribute.Value.Contains(ClientPortalURL) = True Then

            '                Page = HrefAttribute.Value.Replace(ClientPortalURL, "")

            '            End If

            '            If Page.StartsWith("/") = True Then Page = Page.Substring(1, Page.Length - 1)

            '            If Page.ToLower.Contains(".aspx") = True Then

            '                BodyHTML = BodyHTML.Replace(HrefAttribute.Value, String.Format("javascript:OpenRadWindow('','{0}');", Page))

            '            End If

            '        End If

            '    Next

            'End If

            FixAlertLinksForCurrentDomain(BodyHTML, WebvantageURL, ClientPortalURL)

            BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.WebvantageAlertLinkVerbiage, "")
            BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.WebvantageAssignmentLinkVerbiage, "")
            BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.WebvantageWithClientPortalAlertLinkVerbiage, "")
            BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.WebvantageWithClientPortalAssignmentLinkVerbiage, "")
            BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.ClientPortalAlertLinkVerbiage, "")
            BodyHTML = BodyHTML.Replace(AdvantageFramework.AlertSystem.ClientPortalAssignmentLinkVerbiage, "")

        End Sub
        Public Sub FixAlertLinksForCurrentDomain(ByRef BodyText As String, ByVal WebvantageURL As String, ByVal ClientPortalURL As String)

            'objects
            Dim FixedBodyText As String = ""
            Dim Uri As System.Uri = Nothing
            Dim Pattern As String = "href=[\'""]?([^\'"" >]+)?[\'""]"
            Dim Href As String = Nothing
            Dim MatchCollection As System.Text.RegularExpressions.MatchCollection = Nothing
            Dim OnClick As String = ""
            Dim CurrentPattern As String = ""
            Dim PageURL As String = ""
            Dim QueryString As String = ""

            Try

                FixedBodyText = BodyText

                If Not String.IsNullOrWhiteSpace(FixedBodyText) Then

                    MatchCollection = System.Text.RegularExpressions.Regex.Matches(FixedBodyText, Pattern, Text.RegularExpressions.RegexOptions.IgnoreCase)

                    If MatchCollection IsNot Nothing Then

                        For Each Match In MatchCollection.OfType(Of System.Text.RegularExpressions.Match).Where(Function(m) m.Success = True)

                            Try

                                Href = Match.Groups(1).Value

                            Catch ex As Exception
                                Href = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(Href) = False Then

                                If Href.Contains(WebvantageURL) OrElse Href.Contains(ClientPortalURL) Then

                                    If Href.ToLower.StartsWith("http://") = False AndAlso Href.ToLower.StartsWith("https://") = False Then

                                        Href = "http://" & Href

                                    End If

                                    Try

                                        Uri = New Uri(Href)

                                        PageURL = Uri.Segments.Last
                                        QueryString = Uri.Query

                                        If Not String.IsNullOrWhiteSpace(Uri.Query) Then

                                            If Uri.Query.StartsWith("?dl=") Then

                                                Dim TargetURL As String = ""

                                                TargetURL = Uri.Query.Substring(4)
                                                TargetURL = AdvantageFramework.Web.DecryptDeepLinkString(TargetURL)

                                                If Not String.IsNullOrWhiteSpace(TargetURL) Then

                                                    PageURL = TargetURL
                                                    QueryString = ""

                                                End If

                                            End If

                                        End If

                                        If PageURL = "Timesheet" Then

                                            PageURL = "Employee/Timesheet"

                                        End If

                                        OnClick = "OpenRadWindow('', '" & PageURL & QueryString & "', 0, 0); return false;"

                                        CurrentPattern = "href=[\'""](?:\b" & System.Text.RegularExpressions.Regex.Escape(Href) & "\b)[\'""]"

                                        FixedBodyText = System.Text.RegularExpressions.Regex.Replace(FixedBodyText, CurrentPattern, "href=""#"" onclick=""" & OnClick & """")

                                    Catch ex As Exception
                                    End Try

                                End If

                            End If

                        Next

                    End If

                End If

            Catch ex As Exception
                FixedBodyText = BodyText
            End Try

            BodyText = FixedBodyText

        End Sub
        Public Sub CommentsHistory(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   ByVal IsProof As Boolean,
                                   ByVal AlertID As Integer,
                                   ByVal DocumentID As Integer,
                                   ByVal DocumentFilename As String,
                                   ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                   ByRef HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail)

            _CommentsHistory(DbContext, IsProof, AlertID, DocumentID, DocumentFilename, Agency, HTMLEmail)

        End Sub
        Public Sub CommentsHistory(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                   ByVal IsProof As Boolean,
                                   ByVal AlertID As Integer,
                                   ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                   ByRef HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail)

            _CommentsHistory(DbContext, IsProof, AlertID, Nothing, "", Agency, HTMLEmail)

        End Sub
        Private Sub _CommentsHistory(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal IsProof As Boolean,
                                     ByVal AlertID As Integer,
                                     ByVal DocumentID As Integer?,
                                     ByVal DocumentFilename As String,
                                     ByVal Agency As AdvantageFramework.Database.Entities.Agency,
                                     ByRef HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail)

            'objects
            Dim AllComments As Generic.List(Of AdvantageFramework.Email.Classes.AlertComment) = Nothing
            Dim AlertComments As Generic.List(Of AdvantageFramework.Email.Classes.AlertComment) = Nothing
            Dim Offset As Decimal = 0.0

            Dim SqlParameterAlertID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterDocumentID As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterEmployeeCode As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterOffset As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterHideSystemComments As System.Data.SqlClient.SqlParameter = Nothing

            SqlParameterAlertID = New System.Data.SqlClient.SqlParameter("@ALERT_ID", SqlDbType.Int)
            SqlParameterDocumentID = New System.Data.SqlClient.SqlParameter("@DOCUMENT_ID", SqlDbType.Int)
            SqlParameterEmployeeCode = New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            SqlParameterOffset = New System.Data.SqlClient.SqlParameter("@OFFSET", SqlDbType.Decimal)
            SqlParameterHideSystemComments = New System.Data.SqlClient.SqlParameter("@HIDE_SYSTEM_COMMENTS", SqlDbType.Bit)



            Try

                Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, String.Empty)

                SqlParameterAlertID.Value = AlertID
                SqlParameterEmployeeCode.Value = ""
                SqlParameterOffset.Value = Offset
                SqlParameterHideSystemComments.Value = False

                If DocumentID IsNot Nothing AndAlso DocumentID > 0 Then

                    SqlParameterDocumentID.Value = DocumentID

                Else

                    SqlParameterDocumentID.Value = System.DBNull.Value

                End If

                AllComments = DbContext.Database.SqlQuery(Of AdvantageFramework.Email.Classes.AlertComment)("EXEC [dbo].[advsp_alert_load_comments] @ALERT_ID, @DOCUMENT_ID, @EMP_CODE, @OFFSET, @HIDE_SYSTEM_COMMENTS;",
                                                                                                            SqlParameterAlertID,
                                                                                                            SqlParameterDocumentID,
                                                                                                            SqlParameterEmployeeCode,
                                                                                                            SqlParameterOffset,
                                                                                                            SqlParameterHideSystemComments).ToList

                If AllComments IsNot Nothing AndAlso AllComments.Count > 0 Then

                    If String.IsNullOrWhiteSpace(DocumentFilename) = True Then

                        HTMLEmail.AddHeaderRow("Comments")

                    Else

                        HTMLEmail.AddHeaderRow("Comments for:  " & DocumentFilename)

                    End If

                    AlertComments = (From Entity In AllComments
                                     Where Entity.ParentID = 0).OrderByDescending(Function(x) x.GeneratedDate).OrderByDescending(Function(x) x.CommentID).ToList()

                    If AlertComments IsNot Nothing Then

                        For Each Comment As AdvantageFramework.Email.Classes.AlertComment In AlertComments

                            GetReplies(Comment, AllComments, HTMLEmail, Agency)

                        Next

                    End If

                End If

            Catch ex As Exception
            End Try

        End Sub

        Private Function GetReplies(ByRef Parent As AdvantageFramework.Email.Classes.AlertComment,
                                    ByVal AllComments As Generic.List(Of AdvantageFramework.Email.Classes.AlertComment),
                                    ByRef HTMLEmail As AdvantageFramework.Email.Classes.HtmlEmail,
                                    ByVal Agency As AdvantageFramework.Database.Entities.Agency) As Boolean

            Dim HasChildren As Boolean = False
            Dim CommentID As Integer = Parent.CommentID
            Dim Children As Generic.List(Of AdvantageFramework.Email.Classes.AlertComment) = Nothing
            Dim CommentString As String = String.Empty

            'CommentString &= "<br />"

            UrlToHtmlLink(CommentString, Agency.WebvantageURL, Agency.ClientPortalURL)

            CommentString &= HTMLEmail.AddComment(Agency.WebvantageURL, Agency.ClientPortalURL,
                                                  Parent.EmployeeFullName, Parent.UserCode,
                                                  Parent.GeneratedDate, Parent.CustodyEndDate,
                                                  Parent.Comment)

            HTMLEmail.AddCustomRowLeftPad(CommentString, Parent.ReplyLevel)

            Try

                Children = (From Entity In AllComments
                            Where Entity.ParentID = CommentID).OrderBy(Function(x) x.GeneratedDate).ThenBy(Function(x) x.CommentID).ToList

                If Children IsNot Nothing AndAlso Children.Count > 0 Then

                    HasChildren = True

                    If Parent.Replies Is Nothing Then

                        Parent.Replies = New List(Of AdvantageFramework.Email.Classes.AlertComment)

                    End If
                    For Each Child As AdvantageFramework.Email.Classes.AlertComment In Children

                        Parent.Replies.Add(Child)

                        GetReplies(Child, AllComments, HTMLEmail, Agency)

                    Next

                End If

            Catch ex As Exception
                HasChildren = False
            End Try

            Return HasChildren

        End Function

        Private Function ReplaceLinks(HTMLEmail As String, ReplacementLink As String)

            Dim NewHTMLEmail As String = Nothing

            NewHTMLEmail = System.Text.RegularExpressions.Regex.Replace(HTMLEmail, "<a href=""(.*?)"".*?>(.*?)</a>", ReplacementLink)

            ReplaceLinks = NewHTMLEmail

        End Function

#Region " Permalink "

        Public Function UrlToHtmlLink(ByRef TextString As String, ByVal WebvantageURL As String, ByVal ClientPortalURL As String) As Boolean

            If String.IsNullOrWhiteSpace(TextString) = True OrElse
                    TextString.Contains("<img") = True OrElse
                    TextString.Contains("data:image") = True OrElse
                    TextString.Contains("Click here to navigate") = True Then

                Return False

            Else

                Dim HasWebvantageLink As Boolean = False
                Dim FixedBodyText As String = String.Empty
                Dim URL As String = String.Empty
                Dim MatchCollection As System.Text.RegularExpressions.MatchCollection = Nothing
                Dim HrefLink As String = String.Empty
                Dim Counter As Integer = 0

                Try

                    FixedBodyText = TextString


                    MatchCollection = GetUrlMatchCollection(FixedBodyText, WebvantageURL, ClientPortalURL)

                    If MatchCollection IsNot Nothing Then

                        Dim ProcessedURLs As New Generic.List(Of String)

                        For Each Match In MatchCollection.OfType(Of System.Text.RegularExpressions.Match).Where(Function(m) m.Success = True)

                            HrefLink = String.Empty

                            Try

                                URL = Match.Value

                            Catch ex As Exception
                                URL = String.Empty
                            End Try

                            If String.IsNullOrWhiteSpace(URL) = False AndAlso ProcessedURLs.Contains(URL) = False Then

                                HrefLink = String.Format("<a style=""overflow-wrap: break-word;word-break:break-all;-ms-word-break: break-all;word-wrap: break-word;"" href=""{0}"">{0}</a>", URL)
                                ProcessedURLs.Add(URL)
                                HasWebvantageLink = True
                                FixedBodyText = FixedBodyText.Replace(URL, HrefLink)

                            End If

                        Next

                        TextString = FixedBodyText

                    End If

                Catch ex As Exception
                End Try

                Return HasWebvantageLink

            End If

        End Function
        Public Function GetUrlMatchCollection(ByRef TextString As String, ByVal WebvantageURL As String, ByVal ClientPortalURL As String) As Text.RegularExpressions.MatchCollection

            Dim Matches As Text.RegularExpressions.MatchCollection = Nothing

            If TextHasInternalLinks(TextString, WebvantageURL, ClientPortalURL) = True Then

                Dim Pattern As String = "\b([\d\w\.\/\+\-\?\:]*)((ht|f)tp(s|)\:\/\/|[\d\d\d|\d\d]\.[\d\d\d|\d\d]\.|www\.|\.tv|\.ac|\.com|\.edu|\.gov|\.int|\.mil|\.net|\.org|\.biz|\.info|\.name|\.pro|\.museum|\.co|\.ca)([\d\w\.\/\%\+\-\=\&amp;\?\:\\\&quot;\'\,\|\~\;]*)\b([=,@,+,!,%,&,*,-])*"
                Dim AllMatches As System.Text.RegularExpressions.MatchCollection = Nothing

                Try

                    Matches = System.Text.RegularExpressions.Regex.Matches(TextString, Pattern, Text.RegularExpressions.RegexOptions.IgnoreCase)

                Catch ex As Exception
                    Matches = Nothing
                End Try

            End If

            Return Matches

        End Function
        Public Function TextHasInternalLinks(ByVal TextString As String, ByVal WebvantageURL As String, ByVal ClientPortalURL As String) As Boolean

            If TextString.Contains(WebvantageURL) OrElse TextString.Contains(ClientPortalURL) OrElse TextString.ToLower.Contains("newapp?dl=") Then

                Return True

            Else

                Return False

            End If

        End Function

        'Public Function Encrypt(ByVal DeepLinkString As String) As String

        '    Return AdvantageFramework.Security.Encryption.Encrypt(DeepLinkString)

        'End Function
        'Public Function Decrypt(ByVal DeepLink As String) As String

        '    Return AdvantageFramework.Security.Encryption.Decrypt(DeepLink)

        'End Function

#End Region

#End Region

#End Region

    End Module

    <Serializable()>
    Public Class AlertNotification

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID As Integer?
        Public Property LastUpdated As DateTime?
        Public Property Generated As DateTime?
        Public Property Priority As Short?
        Public Property ShortSubject As String = String.Empty
        Public Property Subject As String = String.Empty
        Public Property IsAssignment As Boolean?
        Public Property JobNumber As Integer?
        Public Property JobComponentNumber As Short?
        Public Property SequenceNumber As Short?
        Public Property IsConceptShareReview As Boolean?
        Public Property ConceptShareProjectID As Integer?
        Public Property ConceptShareReviewID As Integer?
        Public Property AssignedEmployeeCode As String = String.Empty
        Public Property CurrentNotify As Boolean?
        Public Property IsWorkItem As Boolean?
        Public Property SprintID As Integer?
        Public Property LastUpdatedFullName As String = String.Empty
        Public Property LastUpdatedEmployeeCode As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class
    <Serializable()>
    Public Class CompleteAssignmentResult

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            AlertID
            IsCompleting
            IsRouted
            IsTask
            IsAutoRoute
            InitialAlertTemplateID
            InitialAlertStateID
            FinalAlertTemplateID
            FinalAlertStateID
            AutoRouteChangedState
            CurrentAssigneesString
            CurrentAssigneesArray
            CurrentAssigneesList
            Success
            Message
            AssignmentFullyCompleted

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property AlertID As Integer? = 0
        Public Property IsCompleting As Boolean? = False
        Public Property IsRouted As Boolean? = False
        Public Property IsTask As Boolean? = False
        Public Property IsAutoRoute As Boolean? = False
        Public Property InitialAlertTemplateID As Integer? = 0
        Public Property InitialAlertStateID As Integer? = 0
        Public Property FinalAlertTemplateID As Integer? = 0
        Public Property FinalAlertStateID As Integer? = 0
        Public Property AutoRouteChangedState As Boolean? = False
        Public Property CurrentAssigneesString As String = String.Empty
        Public ReadOnly Property CurrentAssigneesArray As String()
            Get
                If String.IsNullOrWhiteSpace(CurrentAssigneesString) = False Then
                    Return CurrentAssigneesString.Split(",")
                Else
                    Return Nothing
                End If
            End Get
        End Property
        Public ReadOnly Property CurrentAssigneesList As Generic.List(Of String)
            Get
                If String.IsNullOrWhiteSpace(CurrentAssigneesString) = False Then
                    Return CurrentAssigneesString.Split(",").ToList
                Else
                    Return Nothing
                End If
            End Get
        End Property
        Public Property Success As Boolean? = True
        Public Property Message As String = String.Empty
        Public Property AssignmentFullyCompleted As Boolean? = False
        Public Property IsProof As Boolean? = False

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace
