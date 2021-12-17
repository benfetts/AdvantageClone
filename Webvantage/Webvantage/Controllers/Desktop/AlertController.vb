Imports Kendo.Mvc.Extensions
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports System.Web.Routing
Imports System.Xml
Imports System.Threading
Imports System.IO
Imports System.Text
Imports MvcCodeRouting.Web.Mvc
Imports System.Data.SqlClient
Imports Microsoft.AspNet.SignalR

Namespace Controllers.Desktop

    <Serializable()>
    Public Class AlertController
        Inherits MVCControllerBase

#Region " Constants "

        Const AlertCategoriesSessionKey As String = "ACSSK"
        Const AlertStatesSessionKey As String = "ASSSK"
        Const AllActiveEmployeesSessionKey As String = "AAESSK"
        Const CheckRepositoryLimitRepositorySizeLimitSessionKey As String = "CRLSLSK"
        Const CheckRepositoryLimitRepositoryFileSizeLimitSessionKey As String = "CRLFSLSK"
        Const CheckRepositoryLimitRepositoryLimitTextSessionKey As String = "CRLLTSK"
        Const AgencyDefaultToRoutedSessionKey As String = "AGYDTRSK"
        Const AgencyAllowProofHQSessionKey As String = "AGYPHQSK"

#End Region

#Region " Enum "

        Public Enum PrintPages

            JobVersionPrint
            JobSpecPrint
            CampaignPrint
            CreativeBriefPrint
            EstimatingPrint
            JobTemplatePrint
            MediaATBPrint
            PurchaseOrderPrint

        End Enum
        Public Enum PrintFileTypes

            pdf = 1
            xls = 2
            txt = 4
            rtf = 5

        End Enum

#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Desktop.AlertController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Initialize "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)

        End Sub

#End Region

#Region " Aurelia Views "

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Desktop_CommentView")>
        Public Function CommentView(ByVal AlertID As Integer) As ActionResult

            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/desktop/alert-view/comment-view"
            AureliaModel.Parameters.Add("AlertID", AlertID)

            Return Aurelia(AureliaModel)

        End Function
        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Desktop_Reassign")>
        Public Function Reassign(ByVal AlertID As Integer) As ActionResult

            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/desktop/alert-view/reassign"
            AureliaModel.Parameters.Add("AlertID", AlertID)

            Return Aurelia(AureliaModel)

        End Function
        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Desktop_AlertView")>
        Public Function AlertView(AlertID As Integer, SprintID As Integer) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/desktop/alert-view/alert-view"
            AureliaModel.Parameters.Add("AlertID", AlertID)
            AureliaModel.Parameters.Add("SprintID", SprintID)

            If HttpContext.Request("FromBoard") IsNot Nothing Then
                Try

                    If HttpContext.Request.QueryString("FromBoard") IsNot Nothing AndAlso HttpContext.Request.QueryString("FromBoard").ToString = "1" Then

                        AureliaModel.Parameters.Add("FromBoard", "true")

                    End If

                Catch ex As Exception
                End Try
            End If
            If HttpContext.Request("OpenedFrom") IsNot Nothing Then
                Try

                    If HttpContext.Request.QueryString("OpenedFrom") IsNot Nothing AndAlso IsNumeric(Request.QueryString("OpenedFrom")) Then

                        AureliaModel.Parameters.Add("OpenedFrom", CInt(Request.QueryString("OpenedFrom")))

                    End If

                Catch ex As Exception
                End Try
            End If

            Return Aurelia(AureliaModel)

        End Function
        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Desktop_NewAssignment")>
        Public Function NewAssignment() As ActionResult

            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing
            Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

            Dim BoardStateID As Integer? = Nothing
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Integer? = Nothing
            Dim ClientCode As String = String.Empty
            Dim ContentPage As String = ""
            Dim Caller As String = String.Empty

            If IsNumeric(CurrentQueryString.BoardID) Then BoardStateID = CType(CurrentQueryString.BoardID, Integer)
            If IsNumeric(CurrentQueryString.JobNumber) Then JobNumber = CType(CurrentQueryString.JobNumber, Integer)
            If IsNumeric(CurrentQueryString.JobComponentNumber) Then JobComponentNumber = CType(CurrentQueryString.JobComponentNumber, Integer)
            If String.IsNullOrWhiteSpace(CurrentQueryString.ClientCode) Then ClientCode = CurrentQueryString.ClientCode
            If String.IsNullOrWhiteSpace(CurrentQueryString.GetValue("content")) = False Then ContentPage = CurrentQueryString.GetValue("content")
            If String.IsNullOrWhiteSpace(CurrentQueryString.GetValue("caller")) = False Then Caller = CurrentQueryString.GetValue("caller")

            ''''Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

            ''''    Board = (From Sprint In AdvantageFramework.Database.Procedures.SprintHeader.Load(DbContext)
            ''''             Join Brd In AdvantageFramework.Database.Procedures.Board.Load(DbContext) On Sprint.BoardID Equals Brd.ID
            ''''             Where Sprint.ID = SprintID
            ''''             Select Brd).SingleOrDefault()

            ''''End Using

            AureliaModel = New Webvantage.ViewModels.AureliaModel
            AureliaModel.App = "modules/desktop/alert-view/add-work-item"

            ''''AureliaModel.Parameters.Add("SprintID", SprintID)

            If Board IsNot Nothing Then

                AureliaModel.Parameters.Add("BoardID", Board.ID)
                AureliaModel.Parameters.Add("BoardHeaderID", Board.BoardHeaderID)

            End If

            If BoardStateID.HasValue Then AureliaModel.Parameters.Add("BoardStateID", BoardStateID)
            If JobNumber.HasValue Then AureliaModel.Parameters.Add("JobNumber", JobNumber)
            If JobComponentNumber.HasValue Then AureliaModel.Parameters.Add("JobComponentNumber", JobComponentNumber)
            If ClientCode.HasValue Then AureliaModel.Parameters.Add("ClientCode", ClientCode)
            If ContentPage.HasValue Then AureliaModel.Parameters.Add("ContentPage", ContentPage)
            If Caller.HasValue Then AureliaModel.Parameters.Add("caller", Caller)

            Return Aurelia(AureliaModel)

        End Function
        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Desktop_AddWorkItem")>
        Public Function AddWorkItem(ByVal SprintID As Integer) As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing
            Dim BoardStateID As Integer? = Nothing
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Integer? = Nothing
            Dim ClientCode As String = String.Empty
            Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

            If HttpContext.Request("BoardStateID") IsNot Nothing Then

                Try

                    If HttpContext.Request.QueryString("BoardStateID") IsNot Nothing AndAlso IsNumeric(Request.QueryString("BoardStateID")) Then BoardStateID = CInt(Request.QueryString("BoardStateID"))

                Catch ex As Exception
                End Try

            End If
            If HttpContext.Request("JobNumber") IsNot Nothing Then

                Try

                    If HttpContext.Request.QueryString("JobNumber") IsNot Nothing AndAlso IsNumeric(Request.QueryString("JobNumber")) Then JobNumber = CInt(Request.QueryString("JobNumber"))

                Catch ex As Exception
                End Try

            End If
            If HttpContext.Request("JobComponentNumber") IsNot Nothing Then

                Try

                    If HttpContext.Request.QueryString("JobComponentNumber") IsNot Nothing AndAlso IsNumeric(Request.QueryString("JobComponentNumber")) Then JobComponentNumber = CInt(Request.QueryString("JobComponentNumber"))

                Catch ex As Exception
                End Try

            End If
            If HttpContext.Request("ClientCode") IsNot Nothing Then

                Try

                    If HttpContext.Request.QueryString("ClientCode") IsNot Nothing Then ClientCode = HttpContext.Request.QueryString("ClientCode")

                Catch ex As Exception
                End Try

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Board = (From Sprint In AdvantageFramework.Database.Procedures.SprintHeader.Load(DbContext)
                         Join Brd In AdvantageFramework.Database.Procedures.Board.Load(DbContext) On Sprint.BoardID Equals Brd.ID
                         Where Sprint.ID = SprintID
                         Select Brd).SingleOrDefault()

            End Using

            AureliaModel = New Webvantage.ViewModels.AureliaModel
            AureliaModel.App = "modules/desktop/alert-view/add-work-item"

            AureliaModel.Parameters.Add("SprintID", SprintID)

            If Board IsNot Nothing Then

                AureliaModel.Parameters.Add("BoardID", Board.ID)
                AureliaModel.Parameters.Add("BoardHeaderID", Board.BoardHeaderID)

            End If
            If BoardStateID.HasValue Then

                AureliaModel.Parameters.Add("BoardStateID", BoardStateID)

            End If
            If JobNumber.HasValue Then

                AureliaModel.Parameters.Add("JobNumber", JobNumber)

            End If
            If JobComponentNumber.HasValue Then

                AureliaModel.Parameters.Add("JobComponentNumber", JobComponentNumber)

            End If
            If ClientCode.HasValue Then

                AureliaModel.Parameters.Add("ClientCode", ClientCode)

            End If

            Return Aurelia(AureliaModel)

        End Function
        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Desktop_AlertView_CopyTransfer")>
        Public Function CopyTransferAlert(ByVal Type As Integer,
                                          ByVal AlertID As Integer,
                                          ByVal SprintID As Integer,
                                          ByVal Subject As String,
                                          ByVal IsProof As Boolean?,
                                          ByVal IsRouted As Boolean?) As ActionResult

            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/desktop/alert-view/copy-transfer"

            If IsProof Is Nothing Then IsProof = False
            If IsRouted Is Nothing Then IsRouted = False

            'If HttpContext.Request("AlertID") IsNot Nothing Then

            '    Try

            '        If HttpContext.Request.QueryString("AlertID") IsNot Nothing Then AlertID = CInt(Request.QueryString("AlertID"))

            '    Catch ex As Exception
            '    End Try

            'End If
            'If HttpContext.Request("SprintID") IsNot Nothing Then

            '    Try

            '        If HttpContext.Request.QueryString("SprintID") IsNot Nothing Then SprintID = CInt(Request.QueryString("SprintID"))

            '    Catch ex As Exception
            '    End Try

            'End If

            AureliaModel.Parameters.Add("Type", Type)
            AureliaModel.Parameters.Add("AlertID", AlertID)
            AureliaModel.Parameters.Add("SprintID", SprintID)
            AureliaModel.Parameters.Add("Subject", Subject)
            AureliaModel.Parameters.Add("IsProof", IsProof)
            AureliaModel.Parameters.Add("IsRouted", IsRouted)

            Return Aurelia(AureliaModel)

        End Function

#End Region
#Region " Razor Views "
        'NS: commented out, moved to InboxController

        'Public Function Inbox(ByVal AAFilter As AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerFilter) As ActionResult

        '    Dim Employee As cEmployee = Nothing

        '    Employee = New cEmployee(Me.SecuritySession.ConnectionString)

        '    ViewBag.EmployeeName = Employee.GetName(Me.SecuritySession.User.EmployeeCode)
        '    ViewBag.DefaultEmpCode = Me.SecuritySession.User.EmployeeCode
        '    ViewBag.EmployeeCode = Me.SecuritySession.User.EmployeeCode

        '    Dim Settings As UserThemeSettings


        '    ViewBag.BackgroundColor = GetUserBackgroundColor(Me.SecuritySession.UserName)

        '    Return View()

        'End Function
        'Public Function _InboxGrid() As ActionResult

        '    Dim Filter As New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManagerFilter

        '    If String.IsNullOrWhiteSpace(Me.CurrentQueryString.UserCode) = False Then

        '        Filter.UserCode = Me.CurrentQueryString.UserCode

        '    Else

        '        Filter.UserCode = Me.SecuritySession.UserCode

        '    End If

        '    Filter.EmployeeCode = Me.CurrentQueryString.EmpCode
        '    Filter.SearchCriteria = Me.CurrentQueryString.SearchText
        '    Filter.InboxType = Me.CurrentQueryString.AamInboxType
        '    Filter.ShowAssignmentType = Me.CurrentQueryString.AamShowAssignmentType
        '    Filter.IsJobAlertsPage = Me.CurrentQueryString.AamIsJobAlertsPage
        '    Filter.JobNumber = Me.CurrentQueryString.JobNumber
        '    Filter.JobComponentNumber = Me.CurrentQueryString.JobComponentNbr
        '    Filter.StartDate = Me.CurrentQueryString.StartDate
        '    Filter.EndDate = Me.CurrentQueryString.EndDate
        '    Filter.IncludeCompletedAssignments = Me.CurrentQueryString.AamIncludeCompletedAssignments
        '    Filter.GroupBy = Me.CurrentQueryString.AamGroupBy
        '    Filter.RecordsToReturn = Me.CurrentQueryString.AamRecordsToReturn
        '    Filter.IsCount = Me.CurrentQueryString.AamIsCount
        '    'Filter.RecordCount
        '    Filter.IncludeReviews = Me.CurrentQueryString.AamIncludeReviews
        '    Filter.IncludeBoardLevel = Me.CurrentQueryString.AamIncludeBoardLevel
        '    Filter.IncludeBacklog = Me.CurrentQueryString.AamIncludeBacklog

        '    Return PartialView()

        '    Dim AAManager As New AdvantageFramework.AlertSystem.Classes.AlertsAndAssignmentsManager
        '    Dim ErrorMessage As String = ""

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
        '        AAManager.Items = AdvantageFramework.AlertSystem.LoadAlertsAndAssignmentsManager(DbContext, Filter, ErrorMessage)
        '    End Using

        '    Return View(AAManager)

        'End Function
        'Public Function _InboxFilter() As ActionResult

        '    Return PartialView()

        'End Function

#End Region

#Region " API "

#Region " Get "

        <HttpPost>
        Public Function TryGetFeedbackSummary(ByVal AlertID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ByteFile As Byte() = Nothing
            Dim FileName As String = String.Empty
            Dim FullPathToDocument As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim Key As String = String.Empty

            Success = OutputProofingFeedbackSummary(AlertID, FileName, ErrorMessage)

            If Success = True Then

                Key = AdvantageFramework.Security.Encryption.Encrypt(FileName)

            End If

            Return MaxJson(New With {.Success = Success,
                                     .Key = Key,
                                     .ErrorMessage = ErrorMessage})

        End Function
        <HttpGet>
        Public Function GetFeedbackSummary(ByVal Key As String) As FileResult

            Dim Success As Boolean = False
            Dim ByteFile As Byte() = Nothing
            Dim Path As String = HttpContext.Request.PhysicalApplicationPath.Trim() & "TEMP\"
            Dim FileName As String = String.Empty
            Dim FullPathToDocument As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing

            If String.IsNullOrWhiteSpace(Key) = False Then

                Try

                    FileName = AdvantageFramework.Security.Encryption.Decrypt(Key)

                Catch ex As Exception
                    ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                End Try

                If String.IsNullOrWhiteSpace(FileName) = False Then

                    FullPathToDocument = Path & FileName

                    ByteFile = System.IO.File.ReadAllBytes(FullPathToDocument)

                    FileContentResult = Me.File(ByteFile, "application/pdf")
                    FileContentResult.FileDownloadName = FileName

                End If

            End If

            Return FileContentResult

        End Function

        <HttpGet>
        Public Function CheckForStateChange(ByVal AlertID As Integer, ByVal AlertStateID As Integer) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim StateChanged As Boolean = False
            Dim DbAlertStateID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                DbAlertStateID = Me._Controller.GetCurrentAlertStateID(DbContext, AlertID)

                If AlertStateID <> DbAlertStateID Then

                    StateChanged = True

                End If
                If StateChanged = True Then

                    'Notify?

                End If

            End Using

            Return MaxJson(New With {.StateChanged = StateChanged,
                                     .DbAlertStateID = DbAlertStateID,
                                     .ErrorMessage = ErrorMessage}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetLatestDocumentID(ByVal AlertID As Integer) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim DocumentID As Integer = 0


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                _Controller.GetLatestDocumentID(DbContext, AlertID, ErrorMessage)

            End Using

            Return MaxJson(New With {.DocumentID = DocumentID,
                                     .ErrorMessage = ErrorMessage}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAssignmentTemplate(ByVal AlertTemplateID As Integer) As JsonResult

            Dim AlertAssignmentModel As New AdvantageFramework.ViewModels.Desktop.AlertAssignmentViewModel
            Dim AlertStateModel As AdvantageFramework.ViewModels.Desktop.AlertStateViewModel = Nothing
            Dim AlertStateEmployeeModel As AdvantageFramework.ViewModels.Desktop.AlertStateEmployeeViewModel = Nothing
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim AlertAssignmentTemplate As AdvantageFramework.Database.Entities.AlertAssignmentTemplate = Nothing
                    Dim AlertStates As Generic.List(Of AdvantageFramework.Database.Entities.AlertState) = Nothing
                    Dim AlertStateEmployees As Generic.List(Of AdvantageFramework.Database.Entities.AlertAssignmentTemplateEmployee) = Nothing

                    AlertAssignmentTemplate = AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadByAlertAssignmentTemplateID(DbContext, AlertTemplateID)

                    If AlertAssignmentTemplate IsNot Nothing Then

                        AlertAssignmentModel.AlertTemplateID = AlertAssignmentTemplate.ID
                        AlertAssignmentModel.AlertTemplateName = AlertAssignmentTemplate.Name

                        AlertStates = AdvantageFramework.Database.Procedures.AlertState.LoadByAlertAssignmentTemplateID(DbContext, AlertTemplateID).ToList()

                        If AlertStates IsNot Nothing Then

                            For Each AlertState In AlertStates

                                AlertStateModel = Nothing
                                AlertStateModel = New AdvantageFramework.ViewModels.Desktop.AlertStateViewModel

                                AlertStateModel.AlertStateID = AlertState.ID
                                AlertStateModel.AlertStateName = AlertState.Name

                                AlertStateModel.Employees = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.Desktop.AlertStateEmployeeViewModel)(String.Format("EXEC [dbo].[advsp_proofing_template_states_employees_get] {0}, {1}, 1;", AlertTemplateID, AlertState.ID)).ToList()

                                AlertAssignmentModel.States.Add(AlertStateModel)

                            Next

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return MaxJson(New With {.Template = AlertAssignmentModel,
                                     .ErrorMessage = ErrorMessage}, JsonRequestBehavior.AllowGet)

        End Function
        '<HttpGet>
        'Public Function CanCompleteProof(ByVal AlertID As Integer) As JsonResult

        '    Dim EmployeeCanComplete As Boolean = False
        '    Dim ErrorMessage As String = String.Empty
        '    Dim Result As AdvantageFramework.Proofing.ProofingCanCompleteResult = Nothing

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

        '        Result = AdvantageFramework.Proofing.CanComplete(DbContext,
        '                                                         Me.SecuritySession.UserCode,
        '                                                         "",
        '                                                         AlertID,
        '                                                         ErrorMessage)

        '        If Result IsNot Nothing Then

        '            If String.IsNullOrWhiteSpace(Result.CompleteMessage) = False Then

        '                ErrorMessage = Result.CompleteMessage

        '            End If

        '        End If

        '    End Using

        '    Return Json(New With {.CanComplete = Result.CanComplete,
        '                          .Result = Result,
        '                          .ErrorMessage = ErrorMessage}, JsonRequestBehavior.AllowGet)

        'End Function
        <HttpGet>
        Public Function GetDefaultEmailGroup(ByVal JobNumber As Integer,
                                             ByVal JobComponentNumber As Short) As String

            Dim EmailGroupName As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                EmailGroupName = AdvantageFramework.AlertSystem.GetJobDefaultEmailGroup(DbContext, JobNumber, JobComponentNumber)

            End Using

            'Return Json(EmailGroupName, JsonRequestBehavior.AllowGet)
            Return EmailGroupName

        End Function
        <HttpGet>
        Public Function GetEmailGroupsTreeviewSimple(ByVal EmailGroupCode As String,
                                                     ByVal JobNumber As Integer?,
                                                     ByVal JobComponentNumber As Short?,
                                                     ByVal AutoGroup As Boolean?) As JsonResult

            Dim EmailGroups As Generic.List(Of AdvantageFramework.AlertSystem.Classes.EmailGroupTreeViewDataSimple) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                EmailGroups = AdvantageFramework.AlertSystem.GetEmailGroupsTreeviewDataSimple(DbContext, EmailGroupCode, JobNumber, JobComponentNumber, AutoGroup)

            End Using

            Return MaxJson(EmailGroups, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetEmailGroupsTreeview(ByVal EmailGroupCode As String,
                                               ByVal JobNumber As Integer?,
                                               ByVal JobComponentNumber As Short?,
                                               ByVal AutoGroup As Boolean?) As JsonResult

            Dim EmailGroups As Generic.List(Of AdvantageFramework.AlertSystem.Classes.EmailGroupTreeViewData) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                EmailGroups = AdvantageFramework.AlertSystem.GetEmailGroupsTreeviewData(DbContext, EmailGroupCode, JobNumber, JobComponentNumber, AutoGroup)

            End Using

            Return MaxJson(EmailGroups, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetEmailGroups(ByVal EmailGroupCode As String,
                                       ByVal JobNumber As Integer?,
                                       ByVal JobComponentNumber As Short?,
                                       ByVal AutoGroup As Boolean?) As JsonResult

            Dim EmailGroups As Generic.List(Of AdvantageFramework.AlertSystem.Classes.EmailGroup) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                EmailGroups = AdvantageFramework.AlertSystem.GetEmailGroups(DbContext, EmailGroupCode, JobNumber, JobComponentNumber, AutoGroup)

            End Using

            Return MaxJson(EmailGroups, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertGroupMembers(ByVal AlertGroup As String) As JsonResult
            Dim List As List(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Dim SQL As String = String.Format("SELECT EMAIL_GROUP.EMP_CODE AS Code, EMP_LNAME + ', ' + EMP_FNAME AS Name " &
                                                  "FROM EMAIL_GROUP INNER JOIN EMPLOYEE ON EMPLOYEE.EMP_CODE = EMAIL_GROUP.EMP_CODE " &
                                                  "WHERE (INACTIVE_FLAG Is NULL Or INACTIVE_FLAG = 0) And EMAIL_GR_CODE = '{0}'",
                                                  AlertGroup)

                List = DbContext.Database.SqlQuery(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList)(SQL).ToList

            End Using
            Return MaxJson(List, JsonRequestBehavior.AllowGet)
        End Function
        <HttpGet>
        Public Function GetReviewThumbnailString(ByVal AlertID As Integer) As JsonResult

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim ImageString As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing AndAlso Alert.ConceptShareAssetImage IsNot Nothing Then

                    ImageString = AdvantageFramework.ConceptShare.ByteArrayImageToImageURL(Alert.ConceptShareAssetImage)

                End If

            End Using

            Return MaxJson(ImageString, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetReviewThumbnail(ByVal AlertID As Integer) As ImageResult

            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Picture As Byte() = Nothing
            Dim Image As System.Drawing.Image = Nothing
            Dim ImageConverter As System.Drawing.ImageConverter = Nothing
            Dim Bitmap As System.Drawing.Bitmap = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing AndAlso Alert.ConceptShareAssetImage IsNot Nothing Then

                    Picture = Alert.ConceptShareAssetImage

                End If

            End Using
            If Picture IsNot Nothing Then

                Try

                    ImageConverter = New Drawing.ImageConverter
                    Bitmap = DirectCast(ImageConverter.ConvertFrom(Alert.ConceptShareAssetImage), System.Drawing.Bitmap)
                    Image = Bitmap

                Catch ex As Exception
                    Image = Nothing
                End Try

            End If
            If Image Is Nothing Then

                Image = System.Drawing.Image.FromFile(Server.MapPath("~/Images/Icons/Grey/256/document_empty.png"))

            End If

            Return ImageResult(Image, Drawing.Imaging.ImageFormat.Png)

        End Function
        <HttpGet>
        Public Function GetProofingURL(ByVal AlertID As Integer, ByVal DocumentID As Integer?) As JsonResult

            Dim URL As String = String.Empty
            Dim ErrorMessage As String = String.Empty

            URL = AdvantageFramework.Web.GetProofingURL(Me.SecuritySession, AlertID, DocumentID, 0, ErrorMessage)

            Dim Results As New With {
                .url = URL,
                .errorMessage = ErrorMessage
                }

            Return MaxJson(Results, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetConceptShareProofingURL(ByVal AlertID As Integer) As JsonResult

            Dim URL As String = String.Empty

            If Me.SecuritySession IsNot Nothing Then

                Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                ConceptShareConnection = Nothing
                ConceptShareConnection = ConceptShareSession.CreateConceptShareConnection

                If ConceptShareConnection IsNot Nothing Then

                    Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                        If Alert IsNot Nothing AndAlso
                            Alert.ConceptShareProjectID IsNot Nothing AndAlso Alert.ConceptShareReviewID IsNot Nothing Then

                            URL = AdvantageFramework.ConceptShare.GetReviewProofingURL(ConceptShareConnection, Alert.ConceptShareProjectID, Alert.ConceptShareReviewID)

                        End If

                    End Using

                End If

            End If

            Return Json(URL, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetSprintInfo(ByVal SprintID As Integer) As JsonResult
            Dim BoardStateID As Integer? = Nothing
            Dim JobNumber As Integer? = Nothing
            Dim JobComponentNumber As Integer? = Nothing
            Dim ClientCode As String = String.Empty
            Dim Board As AdvantageFramework.Database.Entities.Board = Nothing

            If HttpContext.Request("BoardStateID") IsNot Nothing Then

                Try

                    If HttpContext.Request.QueryString("BoardStateID") IsNot Nothing AndAlso IsNumeric(Request.QueryString("BoardStateID")) Then BoardStateID = CInt(Request.QueryString("BoardStateID"))

                Catch ex As Exception
                End Try

            End If
            If HttpContext.Request("JobNumber") IsNot Nothing Then

                Try

                    If HttpContext.Request.QueryString("JobNumber") IsNot Nothing AndAlso IsNumeric(Request.QueryString("JobNumber")) Then JobNumber = CInt(Request.QueryString("JobNumber"))

                Catch ex As Exception
                End Try

            End If
            If HttpContext.Request("JobComponentNumber") IsNot Nothing Then

                Try

                    If HttpContext.Request.QueryString("JobComponentNumber") IsNot Nothing AndAlso IsNumeric(Request.QueryString("JobComponentNumber")) Then JobComponentNumber = CInt(Request.QueryString("JobComponentNumber"))

                Catch ex As Exception
                End Try

            End If
            If HttpContext.Request("ClientCode") IsNot Nothing Then

                Try

                    If HttpContext.Request.QueryString("ClientCode") IsNot Nothing Then ClientCode = HttpContext.Request.QueryString("ClientCode")

                Catch ex As Exception
                End Try

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Board = (From Sprint In AdvantageFramework.Database.Procedures.SprintHeader.Load(DbContext)
                         Join Brd In AdvantageFramework.Database.Procedures.Board.Load(DbContext) On Sprint.BoardID Equals Brd.ID
                         Where Sprint.ID = SprintID
                         Select Brd).SingleOrDefault()

            End Using


            Dim Results As New With {
                .SprintID = SprintID,
                .BoardID = If(Board IsNot Nothing, Board.ID, Nothing),
                .BoardHeaderID = If(Board IsNot Nothing, Board.BoardHeaderID, Nothing),
                .BoardStateID = BoardStateID,
                .JobNumber = JobNumber,
                .JobComponentNumber = JobComponentNumber,
                .ClientCode = ClientCode
                }

            Return MaxJson(Results, JsonRequestBehavior.AllowGet)
        End Function
        <HttpGet>
        Public Function GetAlertView(AlertID As Integer, ByVal SprintID As Integer) As JsonResult

            Dim AlertView As AdvantageFramework.ViewModels.Desktop.AlertView = Nothing
            Dim DeepLink As AdvantageFramework.Web.DeepLink = Nothing
            Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

            If MiscFN.IsClientPortal = True Then

                AlertView = _Controller.LoadAlertView(AlertID, SecuritySession.ClientPortalUser.ClientContactID, SprintID:=SprintID, IsClientPortal:=MiscFN.IsClientPortal)

            Else

                AlertView = _Controller.LoadAlertView(AlertID, SprintID:=SprintID, IsClientPortal:=MiscFN.IsClientPortal)

            End If

            If AlertView Is Nothing Then

                AlertView = New AdvantageFramework.ViewModels.Desktop.AlertView

            Else

                'AlertView.Alert.Body = ""
                'AlertView.Alert.EmailBody = ""
                Webvantage.Recents.AddToRecentAssignments(AlertView.Alert)

            End If

            Try

                LoadAlertSecurity(AlertView, AlertView.Alert.IsWorkItem, AlertView.Alert.TaskSequenceNumber.GetValueOrDefault(-1) >= 0)

            Catch ex As Exception
            End Try

            Try

                QueryString = Me.CurrentQueryString
                QueryString.Page = "Desktop_AlertView"

                If QueryString IsNot Nothing And AlertView IsNot Nothing AndAlso AlertView.Alert IsNot Nothing Then

                    DeepLink = New AdvantageFramework.Web.DeepLink(Me.SecuritySession)
                    If DeepLink IsNot Nothing Then DeepLink.BuildFromQueryString(QueryString, AlertView.Alert.WvPermaLink, AlertView.Alert.CpPermaLink)

                End If

            Catch ex As Exception
            End Try

            Return MaxJson(AlertView, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertHours(ByVal AlertID As Integer) As JsonResult

            Return MaxJson(_Controller.LoadAlertHours(AlertID), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsMyAssignment(ByVal AlertID As Integer) As JsonResult

            Return MaxJson(_Controller.IsMyAssignment(AlertID, Me.SecuritySession.User.EmployeeCode), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertRecipients(ByVal AlertID As Integer) As JsonResult

            'objects
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing

            AlertRecipients = _Controller.LoadAlertRecipients(AlertID)

            Return MaxJson(AlertRecipients, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertCategories(ByVal IncludeTask As Boolean) As JsonResult

            Dim AlertCategories As Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertCategoryViewModel)

            If HttpContext.Session(AlertCategoriesSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim SecurityModule As AdvantageFramework.Security.Modules = AdvantageFramework.Security.Methods.Modules.ProjectManagement_ProjectSchedule

                    Dim access As Boolean = AdvantageFramework.Security.DoesUserHaveAccessToModule(Me.SecuritySession, SecurityModule)
                    Dim CanUpdate As Boolean = AdvantageFramework.Security.CanUserUpdateInModule(Me.SecuritySession, SecurityModule)

                    If access = False Or CanUpdate = False Or IncludeTask = False Then

                        AlertCategories = (From Item In DbContext.AlertCategories
                                           Where Item.AlertTypeID = 6 AndAlso {28, 29, 30, 31}.Contains(Item.ID) = False AndAlso Item.Description <> "Task" AndAlso Item.IsInactive = False
                                           Let SortOrder = If(Item.ID >= 70 AndAlso Item.ID <> 79, 1, 2)
                                           Order By SortOrder, Item.Description
                                           Select New AdvantageFramework.ViewModels.Desktop.AlertCategoryViewModel With {.ID = Item.ID, .AlertTypeID = Item.AlertTypeID, .Description = Item.Description}).ToList

                    Else

                        AlertCategories = (From Item In DbContext.AlertCategories
                                           Where Item.AlertTypeID = 6 AndAlso {28, 29, 30, 31}.Contains(Item.ID) = False AndAlso Item.IsInactive = False
                                           Let SortOrder = If(Item.ID >= 70 AndAlso Item.ID <> 79, 1, 2)
                                           Order By SortOrder, Item.Description
                                           Select New AdvantageFramework.ViewModels.Desktop.AlertCategoryViewModel With {.ID = Item.ID, .AlertTypeID = Item.AlertTypeID, .Description = Item.Description}).ToList

                    End If

                End Using

            Else

                AlertCategories = CType(HttpContext.Session(AlertCategoriesSessionKey), Generic.List(Of AdvantageFramework.ViewModels.Desktop.AlertCategoryViewModel))

            End If

            If AlertCategories Is Nothing Then AlertCategories = New List(Of AdvantageFramework.ViewModels.Desktop.AlertCategoryViewModel)

            Return MaxJson(AlertCategories, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertAttachments(ByVal AlertID As Integer) As JsonResult

            Return MaxJson(_Controller.LoadAlertAttachments(Me.SecuritySession, AlertID, 0, MiscFN.IsClientPortal), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTaskDescription(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal TaskSequenceNumber As Short) As JsonResult

            Return MaxJson(_Controller.LoadTaskDescription(JobNumber, JobComponentNumber, TaskSequenceNumber), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertBody(ByVal AlertID As Integer) As JsonResult

            Return MaxJson(_Controller.LoadAlertBody(AlertID), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetExternalReviewersList(ByVal AlertID As Integer, ByVal ShowAllType As Integer) As JsonResult

            Dim ExternalReviewers As Generic.List(Of AdvantageFramework.ViewModels.Desktop.ExternalReviewerViewModel) = Nothing
            Dim ErrorMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                ExternalReviewers = AdvantageFramework.Proofing.GetExternalReviewersList(DbContext, AlertID, String.Empty, ShowAllType, ErrorMessage)

            End Using

            Return MaxJson(ExternalReviewers, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetCurrentProofersList(ByVal AlertID As Integer) As JsonResult

            Dim Proofers As Generic.List(Of AdvantageFramework.Proofing.Classes.CurrentProofers) = Nothing
            Dim ErrorMessage As String = String.Empty
            Dim Loaded As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Try

                    Proofers = AdvantageFramework.Proofing.GetCurrentProofersList(DbContext, AlertID, ErrorMessage)

                Catch ex As Exception
                    Loaded = False
                End Try

                If Proofers Is Nothing OrElse String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    Loaded = False

                End If

            End Using

            Return MaxJson(New With {.Loaded = Loaded,
                                     .Proofers = Proofers
                                    }, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertTemplateStates(ByVal AlertTemplateID As Integer) As JsonResult

            'objects
            Dim AlertTemplateStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateState) = Nothing

            AlertTemplateStates = _Controller.LoadAlertTemplateStates(AlertTemplateID)

            Return MaxJson(AlertTemplateStates, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertChecklists(ByVal AlertID As Integer) As JsonResult

            'objects
            Dim Checklists As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) = Nothing

            Checklists = _Controller.GetCheckLists(AlertID)

            Return MaxJson(Checklists, JsonRequestBehavior.AllowGet)

        End Function
        ''<HttpGet>
        ''Public Function GetAlertTemplateStateEmployeesCount(ByVal AlertTemplateID As Integer, ByVal AlertStateID As Integer) As Integer
        ''    'Count defaults
        ''    'objects
        ''    Dim AlertTemplateStateEmployees As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee) = Nothing
        ''    Dim Count As Integer = 0

        ''    Try

        ''        AlertTemplateStateEmployees = _Controller.LoadAlertTemplateStateEmployees(AlertTemplateID, AlertStateID, False, "", False)

        ''    Catch ex As Exception
        ''        AlertTemplateStateEmployees = Nothing
        ''    End Try

        ''    If AlertTemplateStateEmployees Is Nothing Then

        ''        AlertTemplateStateEmployees = New List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee)

        ''    End If

        ''    Count = AlertTemplateStateEmployees.Count

        ''    Return Count

        ''End Function
        <HttpGet>
        Public Function GetAssignmentsGridDataSource(ByVal AlertID As Integer?,
                                                     ByVal DocumentID As Integer?,
                                                     ByVal AllEmployees As Boolean?) As JsonResult

            'objects
            Dim AlertAssignmentModel As AdvantageFramework.ViewModels.Desktop.AlertAssignmentViewModel = New AdvantageFramework.ViewModels.Desktop.AlertAssignmentViewModel
            Dim ErrorMessage As String = String.Empty

            Try

                If AlertID IsNot Nothing AndAlso AlertID > 0 Then

                    If AllEmployees Is Nothing Then AllEmployees = False
                    If DocumentID Is Nothing Then DocumentID = 0

                    AlertAssignmentModel = _Controller.GetAssignmentTemplate(AlertID, DocumentID, AllEmployees, ErrorMessage)

                End If

            Catch ex As Exception
                AlertAssignmentModel = Nothing
            End Try

            If AlertAssignmentModel Is Nothing Then AlertAssignmentModel = New AdvantageFramework.ViewModels.Desktop.AlertAssignmentViewModel

            Return MaxJson(AlertAssignmentModel.States, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetAlertTemplateStateEmployees(ByVal AlertID As Integer?,
                                                       ByVal AlertTemplateID As Integer?,
                                                       ByVal AlertStateID As Integer?,
                                                       ByVal ShowAll As Boolean?,
                                                       ByVal IncludeEmployeeCode As String) As JsonResult

            'objects
            Dim AlertTemplateStateEmployees As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee) = Nothing

            Try

                If AlertID Is Nothing Then AlertID = 0
                If AlertTemplateID Is Nothing Then AlertTemplateID = 0
                If AlertStateID Is Nothing Then AlertStateID = 0
                If ShowAll Is Nothing Then ShowAll = False

                AlertTemplateStateEmployees = _Controller.LoadAlertTemplateStateEmployees(AlertID, AlertTemplateID, AlertStateID, ShowAll.GetValueOrDefault(False), IncludeEmployeeCode, False)

            Catch ex As Exception
                AlertTemplateStateEmployees = Nothing
            End Try

            If AlertTemplateStateEmployees Is Nothing Then AlertTemplateStateEmployees = New List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee)

            Return MaxJson(AlertTemplateStateEmployees, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function DoesAlertHaveBoard(ByVal AlertID As Integer) As JsonResult

            Return MaxJson(_Controller.DoesAlertHaveBoard(AlertID), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function DoesJobHaveSchedule(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Return MaxJson(_Controller.DoesJobHaveSchedule(JobNumber, JobComponentNumber), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNotificationCount() As JsonResult

            Return Json(_Controller.LoadNotificationCount(), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNotifications() As JsonResult

            Return Json(_Controller.LoadNotifications(), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetLimitedNotifications() As JsonResult

            Return Json(_Controller.LoadNotifications().Take(5).ToList, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function AlertNotificationMarkAllAsRead() As JsonResult

            Dim Success As Boolean = False

            Try

                Success = _Controller.AlertNotificationMarkAllAsRead(CurrentEmployeeCode)

            Catch ex As Exception
                Success = False
            End Try

            Return Json(Success, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function AlertNotificationDismissAllAlerts() As JsonResult

            Return Json(_Controller.AlertNotificationDismissAllAlerts(CurrentEmployeeCode), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertComments(ByVal AlertID As Integer,
                                         ByVal DocumentID As Integer?,
                                         ByVal HideSystemComments As Boolean?) As JsonResult

            'objects
            Dim AlertComments As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertComment) = Nothing
            Dim CommentDocuments As Generic.List(Of AdvantageFramework.AlertSystem.Classes.CommentDocument) = Nothing
            Dim CommentDocument As AdvantageFramework.AlertSystem.Classes.CommentDocument = Nothing

            AlertComments = _Controller.LoadAlertComments(AlertID, DocumentID, HideSystemComments, MiscFN.IsClientPortal)

            For Each AlertComment In AlertComments

                Try

                    If Not String.IsNullOrWhiteSpace(AlertComment.DocumentList) Then

                        CommentDocument = New AdvantageFramework.AlertSystem.Classes.CommentDocument
                        CommentDocuments = CommentDocument.StringToObject(AlertComment.DocumentList)

                        If CommentDocuments IsNot Nothing AndAlso CommentDocuments.Count > 0 Then

                            For Each CmtDoc In CommentDocuments

                                If AlertComment.Documents Is Nothing Then

                                    AlertComment.Documents = New List(Of AdvantageFramework.DTO.Desktop.AlertComment.CommentDocument)

                                End If

                                AlertComment.Documents.Add(New AdvantageFramework.DTO.Desktop.AlertComment.CommentDocument With {.ID = CmtDoc.DocumentId,
                                                                                                                                 .Name = CmtDoc.Filename,
                                                                                                                                 .Title = CmtDoc.Title,
                                                                                                                                 .Link = CmtDoc.Filename,
                                                                                                                                 .MimeType = CmtDoc.MimeType})

                            Next

                        End If

                        AlertComment.DocumentList = String.Empty

                    End If

                Catch ex As Exception
                End Try

            Next

            Return MaxJson(AlertComments, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetScheduleTasks(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim List As IEnumerable

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                List = (From Entity In _Controller.GetScheduleTasks(DbContext, JobNumber, JobComponentNumber)
                        Select New With {.Description = Entity.TaskDescription,
                                         .TaskSequenceNumber = Entity.SequenceNumber,
                                         .JobComponentNumber = Entity.JobComponentNumber,
                                         .JobNumber = Entity.JobNumber,
                                         .Completed = Entity.JobCompletedDate}).ToList


            End Using

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertSettings() As JsonResult

            Return MaxJson(_Controller.LoadAlertSettings(), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetDefaultSubjectType() As JsonResult

            Return Json(_Controller.GetDefaultSubjectType(), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetSoftwareVersionsByJobComponent(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal VersionID As String) As JsonResult

            'objects
            Dim SoftwareVersions As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.SoftwareVersion) = Nothing

            If String.IsNullOrWhiteSpace(VersionID) = True OrElse IsNumeric(VersionID) = False Then

                VersionID = 0

            End If

            SoftwareVersions = _Controller.LoadSoftwareVersionsByJobComponent(JobNumber, JobComponentNumber, CType(VersionID, Integer))

            Return MaxJson(SoftwareVersions, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetSoftwareBuildsByVersion(ByVal VersionID As Integer) As JsonResult

            'objects
            Dim SoftwareBuilds As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.SoftwareBuild) = Nothing

            If VersionID > 0 Then SoftwareBuilds = _Controller.LoadSoftwareBuildsByVersion(VersionID)

            Return MaxJson(SoftwareBuilds, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertStates() As JsonResult

            'objects
            Dim AlertStates As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertState) = Nothing

            If HttpContext.Session(AlertStatesSessionKey) Is Nothing Then

                AlertStates = _Controller.LoadAlertStates()

                If AlertStates IsNot Nothing Then

                    HttpContext.Session(AlertStatesSessionKey) = AlertStates

                End If

            Else

                AlertStates = CType(HttpContext.Session(AlertStatesSessionKey), Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertState))

            End If

            If AlertStates Is Nothing Then AlertStates = New List(Of AdvantageFramework.DTO.Desktop.Alert.AlertState)
            Return MaxJson(AlertStates, JsonRequestBehavior.AllowGet)

        End Function
        ''<HttpGet>
        ''Public Function GetAlertTemplateStateEmployeesByAlertID(ByVal AssignedEmployeeCode As String,
        ''                                                        ByVal AssignedEmployeeName As String,
        ''                                                        ByVal AlertTemplateID As Integer?,
        ''                                                        ByVal AlertStateID As Integer?,
        ''                                                        ByVal AlertID As Integer?,
        ''                                                        ByVal ShowAll As Boolean?,
        ''                                                        ByVal IncludeEmployeeCode As String) As JsonResult

        ''    'objects
        ''    Dim AlertTemplateStateEmployees As Generic.List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee) = Nothing

        ''    If AlertTemplateID IsNot Nothing AndAlso AlertStateID IsNot Nothing Then

        ''        AlertTemplateStateEmployees = _Controller.LoadAlertTemplateStateEmployees(AlertID, AlertTemplateID, AlertStateID, ShowAll.GetValueOrDefault(False), IncludeEmployeeCode, False)

        ''        Try

        ''            If String.IsNullOrWhiteSpace(AssignedEmployeeCode) = False AndAlso AssignedEmployeeCode.ToLower.Contains("unassigned") = False Then

        ''                Dim ListHasAssignedEmployee As Boolean = False

        ''                ListHasAssignedEmployee = (From Entity In AlertTemplateStateEmployees
        ''                                           Where Entity.Code = AssignedEmployeeCode
        ''                                           Select Entity).Count > 0

        ''                If ListHasAssignedEmployee = False Then

        ''                    Dim CurrentEmployee As New AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee

        ''                    CurrentEmployee.Code = AssignedEmployeeCode
        ''                    CurrentEmployee.Name = AssignedEmployeeName
        ''                    CurrentEmployee.IsDefault = False

        ''                    If AlertTemplateStateEmployees Is Nothing Then AlertTemplateStateEmployees = New List(Of AdvantageFramework.DTO.Desktop.Alert.AlertTemplateStateEmployee)

        ''                    AlertTemplateStateEmployees.Add(CurrentEmployee)

        ''                End If

        ''            End If

        ''        Catch ex As Exception
        ''        End Try

        ''    End If

        ''    Return MaxJson(AlertTemplateStateEmployees, JsonRequestBehavior.AllowGet)

        ''End Function
        <HttpGet>
        Public Function GetEmployees() As JsonResult

            'objects
            Dim Employees As Generic.List(Of AdvantageFramework.ViewModels.Desktop.ActiveEmployeeViewModel)
            If HttpContext.Session(AllActiveEmployeesSessionKey) Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Employees = (From Item In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                 Select Item.Code, Item.FirstName, Item.MiddleInitial, Item.LastName).ToList _
                             .Select(Function(emp) New AdvantageFramework.ViewModels.Desktop.ActiveEmployeeViewModel With {.Code = emp.Code, .Name = emp.FirstName & If(String.IsNullOrWhiteSpace(emp.MiddleInitial), " ", " " & emp.MiddleInitial & ". ") & emp.LastName}).ToList

                End Using

                If Employees IsNot Nothing Then

                    HttpContext.Session(AllActiveEmployeesSessionKey) = Employees

                End If

            Else

                Employees = CType(HttpContext.Session(AllActiveEmployeesSessionKey), Generic.List(Of AdvantageFramework.ViewModels.Desktop.ActiveEmployeeViewModel))

            End If

            If Employees Is Nothing Then Employees = New List(Of AdvantageFramework.ViewModels.Desktop.ActiveEmployeeViewModel)

            Return MaxJson(Employees, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetAlertRecipientsLookup() As JsonResult

            Dim List As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipientLookUp)

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                Dim UserCode As String = SecuritySession.UserCode
                Dim ClientCode As String = Me.CurrentQueryString.ClientCode
                Dim DivisionCode As String = Me.CurrentQueryString.DivisionCode
                Dim ProductCode As String = Me.CurrentQueryString.ProductCode
                Dim JobNumber As Integer = Me.CurrentQueryString.JobNumber
                Dim JobComponentNumber As Short = Me.CurrentQueryString.JobComponentNumber
                Dim AlertID As Integer = Me.CurrentQueryString.AlertID

                Dim CampaignIdentifier As Integer = 0
                Dim ClientPortalUserId As Integer = 0
                Dim OnlyConceptShareUsers As Boolean = False
                Dim EmailGroupCode As String = String.Empty

                List = AdvantageFramework.AlertSystem.LoadAlertRecipients(DbContext, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponentNumber, CampaignIdentifier,
                                                                          ClientPortalUserId, AlertID, UserCode, OnlyConceptShareUsers, EmailGroupCode)

            End Using

            If List Is Nothing Then List = New List(Of AdvantageFramework.DTO.Desktop.AlertRecipientLookUp)

            For Each Recipient As AdvantageFramework.DTO.Desktop.AlertRecipientLookUp In List

                If Recipient.IsClientContact = True Then

                    Recipient.Code = "CC|" & Recipient.Code

                End If

            Next

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetSprintSetup(ByVal SprintID As Integer) As JsonResult

            Dim ExcludeTasks As Boolean
            Dim SprintHeader As AdvantageFramework.Database.Entities.SprintHeader = Nothing
            Dim RepositorySizeLimit As Long = 0
            Dim RepositoryFileSizeLimit As Long = 0
            Dim RepositoryLimitText As String = ""
            Dim LimitRepository As Boolean = False
            Dim AllowUpload As Boolean = True
            Dim DefaultAssignment As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                ExcludeTasks = (From Sprint In AdvantageFramework.Database.Procedures.SprintHeader.Load(DbContext)
                                Join Board In AdvantageFramework.Database.Procedures.Board.Load(DbContext) On Sprint.BoardID Equals Board.ID
                                Join BoardHeader In AdvantageFramework.Database.Procedures.BoardHeader.Load(DbContext) On Board.BoardHeaderID Equals BoardHeader.ID
                                Where Sprint.ID = SprintID
                                Select [ET] = BoardHeader.ExcludeTasks).SingleOrDefault().GetValueOrDefault(False)

                AllowUpload = Me.AllowRepositoryUpload(DbContext, RepositorySizeLimit, RepositoryFileSizeLimit, RepositoryLimitText, LimitRepository)

                'Get from session if since it is agency setting and not user setting
                DefaultAssignment = GetAgencyDefaultToRoutedOnNewAssignmentSetting()

            End Using

            Return MaxJson(New With {.RepositoryLimitText = RepositoryLimitText, .AllowUpload = AllowUpload, .ExcludeTasks = ExcludeTasks, .DefaultAssignment = DefaultAssignment}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNewAssignmentInfoFromJob(ByVal JobNumber As Integer) As JsonResult

            Dim Alert As New AdvantageFramework.DTO.Desktop.Alert
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            Alert.JobNumber = JobNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Job = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Job).Include("Client").Include("Division").Include("Product").Include("Office")
                       Where Entity.Number = JobNumber
                       Select Entity).SingleOrDefault

                If Job IsNot Nothing Then

                    Alert.JobDescription = Job.Description

                    If Job.Office IsNot Nothing Then

                        Alert.OfficeCode = Job.Office.Code
                        Alert.OfficeName = Job.Office.Name

                    End If
                    If Job.Client IsNot Nothing Then

                        Alert.ClientCode = Job.Client.Code
                        Alert.ClientName = Job.Client.Name

                    End If
                    If Job.Division IsNot Nothing Then

                        Alert.DivisionCode = Job.Division.Code
                        Alert.DivisionName = Job.Division.Name

                    End If
                    If Job.Product IsNot Nothing Then

                        Alert.ProductCode = Job.Product.Code
                        Alert.ProductName = Job.Product.Name

                    End If

                End If

            End Using

            Return MaxJson(Alert, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNewAssignmentInfoFromJobComponent(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim Alert As New AdvantageFramework.DTO.Desktop.Alert
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            Alert.JobNumber = JobNumber
            Alert.JobComponentNumber = JobComponentNumber

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                'JobComponent = From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.JobComponent).Include("Job").Include("Client").Include("Division").Include("Product").Include("Office")
                '               Where Entity.ID = JobComponentNumber And Entity.JobNumber = JobNumber
                '               Select Entity

                'JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                Job = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Job).Include("Client").Include("Division").Include("Product").Include("Office").Include("JobComponents")
                       Where Entity.Number = JobNumber
                       Select Entity).SingleOrDefault

                If Job IsNot Nothing Then

                    JobComponent = (From Entity In Job.JobComponents
                                    Where Entity.Number = JobComponentNumber
                                    Select Entity).SingleOrDefault
                End If

                If JobComponent IsNot Nothing Then

                    Alert.JobComponentDescription = JobComponent.Description

                    If Job IsNot Nothing Then

                        Alert.JobDescription = Job.Description

                        If Job.Office IsNot Nothing Then

                            Alert.OfficeCode = Job.Office.Code
                            Alert.OfficeName = Job.Office.Name

                        End If
                        If Job.Client IsNot Nothing Then

                            Alert.ClientCode = Job.Client.Code
                            Alert.ClientName = Job.Client.Name

                        End If
                        If Job.Division IsNot Nothing Then

                            Alert.DivisionCode = Job.Division.Code
                            Alert.DivisionName = Job.Division.Name

                        End If
                        If Job.Product IsNot Nothing Then

                            Alert.ProductCode = Job.Product.Code
                            Alert.ProductName = Job.Product.Name

                        End If

                    End If

                End If

            End Using

            Return MaxJson(Alert, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetEmailGroupByAlertID(ByVal AlertID As Integer) As JsonResult

            Dim List As Generic.List(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList)(String.Format("EXEC [dbo].[advsp_alert_get_cc_groups] {0}, 0;", AlertID)).ToList

                Catch ex As Exception
                    List = Nothing
                End Try

            End Using

            If List Is Nothing Then List = New List(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList)

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNewAssignmentJobList(ByVal SprintID As Integer, ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As JsonResult

            Dim Jobs As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            If String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(ProductCode) = False Then

                Jobs = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                          AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Job)
                        Where Entity.ClientCode = ClientCode And Entity.DivisionCode = DivisionCode And Entity.ProductCode = ProductCode).ToList

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(ProductCode) = True Then

                Jobs = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                          AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Job)
                        Where Entity.ClientCode = ClientCode And Entity.DivisionCode = DivisionCode).ToList

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = True AndAlso String.IsNullOrWhiteSpace(ProductCode) = True Then

                Jobs = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                          AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Job)
                        Where Entity.ClientCode = ClientCode).ToList

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = True AndAlso String.IsNullOrWhiteSpace(ProductCode) = False Then

                Jobs = New List(Of AdvantageFramework.DTO.JobComponent)

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = True AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(ProductCode) = False Then

                Jobs = New List(Of AdvantageFramework.DTO.JobComponent)

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = True AndAlso String.IsNullOrWhiteSpace(DivisionCode) = True AndAlso String.IsNullOrWhiteSpace(ProductCode) = True Then

                If String.IsNullOrWhiteSpace(OfficeCode) = False Then

                    Jobs = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                              AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Job)
                            Where Entity.OfficeCode = OfficeCode).ToList

                Else

                    Jobs = AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                              AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Job)

                End If

            Else

                If String.IsNullOrWhiteSpace(OfficeCode) = False Then

                    Jobs = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                              AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Job)
                            Where Entity.OfficeCode = OfficeCode).ToList

                Else

                    Jobs = New List(Of AdvantageFramework.DTO.JobComponent)

                End If

            End If

            Return MaxJson(Jobs, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNewAssignmentOfficeList(ByVal SprintID As Integer) As JsonResult

            Dim Offices As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            If SprintID > 0 Then

                Offices = AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                             AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Office)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Office) = Nothing

                        ResultQuery = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.SecuritySession)

                        Offices = (From Item In ResultQuery
                                   Select Item.Code,
                                         Item.Name).Select(Function(Cl) New AdvantageFramework.DTO.JobComponent With {.OfficeCode = Cl.Code,
                                                                                                                      .OfficeName = Cl.Name}).ToList

                    End Using

                End Using

            End If

            Return MaxJson(Offices, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNewAssignmentClientList(ByVal SprintID As Integer?, ByVal OfficeCode As String) As JsonResult

            Dim Clients As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            Try

                If SprintID IsNot Nothing AndAlso SprintID > 0 Then

                    If String.IsNullOrWhiteSpace(OfficeCode) = True Then

                        Clients = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                                 AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Client)
                                   Order By Entity.ClientName
                                   Select Entity).ToList

                    Else

                        Clients = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                                 AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Client)
                                   Where Entity.OfficeCode = OfficeCode
                                   Order By Entity.ClientName
                                   Select Entity).ToList

                    End If

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            If String.IsNullOrWhiteSpace(OfficeCode) = True Then

                                Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Client) = Nothing

                                ResultQuery = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.SecuritySession, DbContext, SecurityDbContext)
                                ResultQuery = ResultQuery.Where(Function(Cl) Cl.IsActive = 1)

                                Clients = (From Item In ResultQuery
                                           Order By Item.Name
                                           Select Item.Code,
                                             Item.Name).Select(Function(Cl) New AdvantageFramework.DTO.JobComponent With {.ClientCode = Cl.Code,
                                                                                                                          .ClientName = Cl.Name}).ToList

                            Else

                                Dim scbo As Generic.List(Of SimpleClientByOffice) = Nothing

                                scbo = DbContext.Database.SqlQuery(Of SimpleClientByOffice)(String.Format("EXEC [dbo].[usp_wv_dd_Filter_Clients_All] '{0}', '{1}';", Me.SecuritySession.UserCode, OfficeCode)).ToList
                                scbo = scbo.Where(Function(Cl) Cl.IsActive = 1).ToList


                                If scbo IsNot Nothing Then

                                    Clients = (From Item In scbo
                                               Order By Item.ClientName
                                               Select Item.ClientCode,
                                               Item.ClientName).Select(Function(Cl) New AdvantageFramework.DTO.JobComponent With {.ClientCode = Cl.ClientCode,
                                                                                                                                  .ClientName = Cl.ClientName}).ToList
                                End If

                            End If

                        End Using

                    End Using

                End If

            Catch ex As Exception
                If Clients Is Nothing Then Clients = New List(Of AdvantageFramework.DTO.JobComponent)
            End Try

            Return MaxJson(Clients, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNewAssignmentDivisionList(ByVal SprintID As Integer, ByVal OfficeCode As String, ByVal ClientCode As String) As JsonResult

            Dim Divisions As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            If SprintID > 0 Then

                If String.IsNullOrWhiteSpace(ClientCode) = True Then

                    Divisions = New List(Of AdvantageFramework.DTO.JobComponent)

                Else

                    Divisions = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                               AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Division)
                                 Order By Entity.DivisionName
                                 Where Entity.ClientCode = ClientCode).ToList

                End If
                If String.IsNullOrWhiteSpace(OfficeCode) = False Then

                    Divisions = Divisions.Where(Function(Entity) Entity.OfficeCode = OfficeCode).ToList

                End If

            Else

                If String.IsNullOrWhiteSpace(ClientCode) = True Then

                    Divisions = New List(Of AdvantageFramework.DTO.JobComponent)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Division) = Nothing

                            ResultQuery = AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(Me.SecuritySession, DbContext, SecurityDbContext)
                            ResultQuery = ResultQuery.Where(Function(Cl) Cl.IsActive = 1 And Cl.ClientCode = ClientCode)

                            Divisions = (From Item In ResultQuery
                                         Order By Item.Name
                                         Select Item.Code,
                                            Item.Name).Select(Function(Cl) New AdvantageFramework.DTO.JobComponent With {.ClientCode = ClientCode,
                                                                                                                         .DivisionCode = Cl.Code,
                                                                                                                         .DivisionName = Cl.Name}).ToList

                        End Using

                    End Using

                End If

            End If

            Return MaxJson(Divisions, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNewAssignmentProductList(ByVal SprintID As Integer, ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String) As JsonResult

            Dim Products As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            If SprintID > 0 Then

                If String.IsNullOrWhiteSpace(ClientCode) = True AndAlso String.IsNullOrWhiteSpace(DivisionCode) = True Then

                    Products = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                             AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Product)
                                Order By Entity.ProductName
                                Select Entity).ToList

                ElseIf String.IsNullOrWhiteSpace(ClientCode) = True AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False Then

                    Products = New List(Of AdvantageFramework.DTO.JobComponent)

                ElseIf String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = True Then

                    Products = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                             AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Product)
                                Order By Entity.ProductName
                                Where Entity.ClientCode = ClientCode And Entity.DivisionCode = DivisionCode
                                Select Entity).ToList

                ElseIf String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False Then

                    Products = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                             AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Product)
                                Order By Entity.ProductName
                                Where Entity.ClientCode = ClientCode And Entity.DivisionCode = DivisionCode
                                Select Entity).ToList

                End If
                If String.IsNullOrWhiteSpace(OfficeCode) = False Then

                    Products = (From Entity In Products.Where(Function(Entity) Entity.OfficeCode = OfficeCode)
                                Order By Entity.ProductName
                                Select Entity).ToList

                End If

            Else

                If String.IsNullOrWhiteSpace(ClientCode) = True OrElse String.IsNullOrWhiteSpace(DivisionCode) = True Then

                    Products = New List(Of AdvantageFramework.DTO.JobComponent)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            Dim ResultQuery As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.Product) = Nothing

                            ResultQuery = AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Me.SecuritySession, DbContext, SecurityDbContext)
                            ResultQuery = ResultQuery.Where(Function(Cl) Cl.IsActive = 1 And Cl.ClientCode = ClientCode And Cl.DivisionCode = DivisionCode)

                            Products = (From Item In ResultQuery
                                        Order By Item.Name
                                        Select Item.Code,
                                           Item.Name).Select(Function(Cl) New AdvantageFramework.DTO.JobComponent With {.ClientCode = ClientCode,
                                                                                                                        .DivisionCode = DivisionCode,
                                                                                                                        .ProductCode = Cl.Code,
                                                                                                                        .ProductName = Cl.Name}).ToList

                        End Using

                    End Using

                End If

            End If

            Return MaxJson(Products, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetNewAssignmentComponentList(ByVal SprintID As Integer, ByVal JobNumber As Integer?) As JsonResult

            Dim Components As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            If JobNumber Is Nothing OrElse JobNumber = 0 Then

                Components = New List(Of AdvantageFramework.DTO.JobComponent)
                'Components = AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                '                                                                             AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Component)

            Else

                Components = (From Entity In AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0,
                                                                                                                AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Component)
                              Order By Entity.JobNumber, Entity.JobComponentNumber
                              Where Entity.JobNumber = JobNumber
                              Select Entity).ToList

            End If

            Return MaxJson(Components, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function DownloadAttachment(ByVal Key As String) As FileResult

            'objects
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim ByteFile As Byte() = Nothing
            Dim FileExists As Boolean = False
            Dim DocumentID As Integer = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    DocumentID = CInt(AdvantageFramework.Security.Encryption.Decrypt(Key))

                    If DocumentID > 0 Then

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)
                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                        If Agency IsNot Nothing AndAlso Document IsNot Nothing Then

                            If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists) Then

                                FileContentResult = Me.File(ByteFile, Document.MIMEType)
                                FileContentResult.FileDownloadName = Document.FileName

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
            End Try

            Return FileContentResult

        End Function
        <HttpGet>
        Public Function GetAlertTemplates(ByVal IsProof As Boolean?) As JsonResult

            'objects
            Dim AlertTemplates As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                If IsProof Is Nothing OrElse IsProof = False Then

                    AlertTemplates = (From Item In AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext)
                                      Where Item.TemplateType Is Nothing OrElse Item.TemplateType <> 2
                                      Select New With {.ID = Item.ID, .Name = Item.Name, .IsAutoRoute = Item.AutoNextState}).ToList

                Else

                    AlertTemplates = (From Item In AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext)
                                      Where Item.TemplateType IsNot Nothing AndAlso Item.TemplateType = 2
                                      Select New With {.ID = Item.ID, .Name = Item.Name, .IsAutoRoute = True}).ToList

                End If

            End Using

            Return MaxJson(AlertTemplates, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetTaskFunctions() As JsonResult

            'objects
            Dim Tasks As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Tasks = (From item In AdvantageFramework.Database.Procedures.Task.LoadAllActive(DbContext)
                         Order By item.Description Ascending
                         Select New With {.Code = item.Code,
                                          .Description = item.Description,
                                          .CodeAndDescription = item.Description & " (" & item.Code & ")"}).ToList

            End Using

            Return MaxJson(Tasks, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsAlertAssignmentTemplateMultiRoute(ByVal AlertTemplateID As Integer) As JsonResult

            'objects
            Dim AlertAssignmentTemplateIsMultiRoute As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                AlertAssignmentTemplateIsMultiRoute = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CASE WHEN [TYPE] = 1 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END FROM ALERT_NOTIFY_HDR WHERE ALRT_NOTIFY_HDR_ID = {0};", AlertTemplateID)).SingleOrDefault

            End Using

            Return MaxJson(AlertAssignmentTemplateIsMultiRoute, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetDefaultWorkflowTemplate(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            'objects
            Dim DefaultWorkflowTemplate As Integer = 0
            Dim DefaultWorkflowName As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                DefaultWorkflowTemplate = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALRT_NOTIFY_HDR_ID,0) FROM JOB_COMPONENT WITH(NOLOCK) WHERE JOB_NUMBER = {0} AND JOB_COMPONENT_NBR = {1}", JobNumber, JobComponentNumber)).SingleOrDefault
                DefaultWorkflowName = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(ALERT_NOTIFY_NAME,'') FROM ALERT_NOTIFY_HDR WHERE ALRT_NOTIFY_HDR_ID = {0} ", DefaultWorkflowTemplate)).SingleOrDefault

            End Using

            Return MaxJson(New With {.DefaultWorkflowTemplate = DefaultWorkflowTemplate, .DefaultWorkflowName = DefaultWorkflowName}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function isClientPortal() As JsonResult

            Return Json(IsClientPortalActive(), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsProofingActive() As JsonResult

            Return Json(IsProofingToolActive(Me.SecuritySession), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsConceptShareActive() As JsonResult

            Return Json(IsConceptShareToolActive(Me.SecuritySession), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function AllowProofHQ() As JsonResult

            Dim ProofHQ As Boolean = False

            Try

                ProofHQ = GetAgencyAllowProofHQSetting()

            Catch ex As Exception
                ProofHQ = False
            End Try

            Return Json(ProofHQ, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function InitCopyTransfer(ByVal AlertID As Integer, ByVal SprintID As Integer?) As JsonResult

            Dim JobComponents As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            JobComponents = _Controller.LoadCopyAndTransferJobs(AlertID, SprintID)

            If JobComponents Is Nothing Then JobComponents = New List(Of AdvantageFramework.DTO.JobComponent)

            Return MaxJson(New With {.JobComponents = JobComponents}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function JobIsNoTaskBoard(ByVal JobNumber As Integer,
                                         ByVal JobComponentNumber As Short) As JsonResult

            Dim NoTaskBoard As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                NoTaskBoard = _Controller.JobIsNoTaskBoard(DbContext, JobNumber, JobComponentNumber)

            End Using

            Return Json(New With {.NoTaskBoard = NoTaskBoard}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function IsNoTaskBoard(ByVal AlertID As Integer) As JsonResult

            Dim NoTaskBoard As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                NoTaskBoard = _Controller.IsNoTaskBoard(DbContext, AlertID)

            End Using

            Return Json(New With {.NoTaskBoard = NoTaskBoard}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function CheckForBoard(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Return MaxJson(_Controller.CheckForBoard(JobNumber, JobComponentNumber), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function BoardIDChanged(ByVal BoardID As Integer, ByVal SprintID As Short) As JsonResult

            Return MaxJson(_Controller.BoardIDChanged(BoardID, SprintID), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetBoardsByJob(ByVal JobNumber As Integer) As JsonResult

            Dim List As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)


            End Using

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetBoardStates(ByVal BoardHeaderID As Integer) As JsonResult

            'objects
            Dim BoardStates As IEnumerable = Nothing

            BoardStates = _Controller.LoadBoardStates(BoardHeaderID)

            Return MaxJson(BoardStates, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetBoardSprints(ByVal BoardID As Integer) As JsonResult

            Return MaxJson(_Controller.GetBoardSprints(BoardID), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetBoardSprintStates(ByVal SprintID As Integer) As JsonResult

            Return MaxJson(_Controller.GetBoardSprintStates(SprintID), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function CanAddTimeToJob(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim Message As String = String.Empty
            Dim Can As Boolean = False

            Can = _Controller.CanAddTimeToJob(JobNumber, JobComponentNumber, Message)

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Can, Message, Nothing), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function DownloadFeedbackSummary(ByVal Key As String) As FileResult

            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim FileContentResult As System.Web.Mvc.FileContentResult = Nothing
            Dim ByteFile As Byte() = Nothing
            Dim FileExists As Boolean = False
            Dim FullPath As String = String.Empty

            Try

                If String.IsNullOrWhiteSpace(Key) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Try

                            FullPath = AdvantageFramework.Security.Encryption.Decrypt(Key)

                        Catch ex As Exception
                            FullPath = String.Empty
                        End Try

                        If String.IsNullOrWhiteSpace(FullPath) = False Then

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                            If Agency IsNot Nothing Then

                                Dim FileStream As System.IO.FileStream = Nothing
                                Dim BinaryReader As System.IO.BinaryReader = Nothing

                                FileStream = New System.IO.FileStream(FullPath, IO.FileMode.OpenOrCreate)
                                BinaryReader = New System.IO.BinaryReader(FileStream)
                                ByteFile = BinaryReader.ReadBytes(New System.IO.FileInfo(FullPath).Length)

                                If ByteFile IsNot Nothing Then

                                    FileContentResult = Me.File(ByteFile, "application/pdf")
                                    FileContentResult.FileDownloadName = FullPath.Substring(FullPath.LastIndexOf("\") + 1, FullPath.Length - FullPath.LastIndexOf("\") - 1)

                                End If
                                'If AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists) Then

                                '    FileContentResult = Me.File(ByteFile, Document.MIMEType)

                                '    FileContentResult.FileDownloadName = Document.FILENAME

                                'End If

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
            End Try

            Return FileContentResult

        End Function
        <HttpGet>
        Public Function FeedbackSummaryLoad(ByVal ProjectID As Integer, ByVal ReviewID As Integer) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim Key As String = String.Empty

            Try

                If ProjectID > 0 And ReviewID > 0 Then

                    Dim ConceptShareProjectID As Integer = 0
                    Dim ConceptShareReviewID As Integer = 0

                    Try

                        If IsNumeric(ProjectID) Then

                            ConceptShareProjectID = ProjectID

                        End If

                    Catch ex As Exception
                        ConceptShareProjectID = 0
                    End Try
                    Try

                        If IsNumeric(ReviewID) Then

                            ConceptShareReviewID = ReviewID

                        End If

                    Catch ex As Exception
                        ConceptShareReviewID = 0
                    End Try
                    If ConceptShareProjectID > 0 AndAlso ConceptShareReviewID > 0 Then

                        Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                        Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection

                        ConceptShareConnection = Nothing
                        ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                        If ConceptShareConnection IsNot Nothing Then

                            Dim Identifier As String = String.Empty
                            Dim Filename As String = String.Empty
                            Dim PdfBytes As Byte()

                            PdfBytes = AdvantageFramework.ConceptShare.GenerateReviewFeedbackSummary(ConceptShareConnection, ConceptShareProjectID, ConceptShareReviewID)

                            If PdfBytes IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                    Dim Alert As AdvantageFramework.Database.Entities.Alert

                                    Alert = Nothing
                                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByConceptShareReviewID(DbContext, ConceptShareReviewID)

                                    If Alert IsNot Nothing Then

                                        Identifier = Alert.Subject

                                    End If

                                    Filename = String.Format("Feedback_Summary_{0}_{1}.pdf", MiscFN.JavascriptSafe(Identifier.Replace(" ", "_")), AdvantageFramework.StringUtilities.GUID_Date())

                                    Filename = AdvantageFramework.StringUtilities.RemoveIllegalFilenameIllegalCharacters(Filename)

                                    Success = DownloadFeedbackSummaryBytesToTemp(DbContext, PdfBytes, Filename, Key)

                                End Using

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return MaxJson(New With {.Success = Success, .Key = Key, .Message = ErrorMessage}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function GetJobVersionDefaults() As JsonResult
            Dim Defaults As Generic.List(Of AdvantageFramework.DTO.Maintenance.General.Settings.Setting) = Me._Controller.GetJobVersionDefaults()
            Dim ID As Integer = 0

            For Each setting In Defaults

                If setting.Code = "JR_ASSIGN_TMPLT" Then
                    'we need the freaking discription so lets find it.
                    If Integer.TryParse(setting.Value, ID) Then
                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            setting.DisplayDescription = (From Item In AdvantageFramework.Database.Procedures.AlertAssignmentTemplate.LoadAllActive(DbContext)
                                                          Where Item.ID = ID
                                                          Select New With {.ID = Item.ID, .Name = Item.Name}).FirstOrDefault().Name

                        End Using
                    End If

                End If

            Next

            Return MaxJson(Defaults, Mvc.JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function CanCompleteProof(ByVal AlertID As Integer) As JsonResult

            Dim Result As AdvantageFramework.Proofing.Classes.ProofingCanCompleteResult = Nothing
            Dim ErrorMessage As String = String.Empty
            Dim CanComplete As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Result = AdvantageFramework.Proofing.CanComplete(DbContext, Me.SecuritySession.UserCode,
                                                                 Me.SecuritySession.User.EmployeeCode,
                                                                 AlertID, ErrorMessage)


            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(CanComplete,
                                                                            ErrorMessage,
                                                                            Result), JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function CanDeleteDocument(ByVal AlertID As Integer, ByVal DocumentID As Integer) As JsonResult

            Dim CanDelete As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim Result As AdvantageFramework.Proofing.Classes.ProofingCanDeleteDocumentResult = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    Result = AdvantageFramework.Proofing.CanDeleteDocument(DbContext, AlertID, DocumentID)

                Catch ex As Exception
                    Result = New AdvantageFramework.Proofing.Classes.ProofingCanDeleteDocumentResult
                    Result.CanDelete = False
                    Result.Message = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                End Try

                CanDelete = Result.CanDelete
                ErrorMessage = Result.Message

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(CanDelete,
                                                                            ErrorMessage,
                                                                            Result), JsonRequestBehavior.AllowGet)

        End Function

#End Region
#Region " Post "

        <AcceptVerbs("GET", "POST"),
        System.Web.Mvc.AllowAnonymous()>
        Public Function RefreshProofingAssignment(ByVal dl As String) As JsonResult

            Dim ReturnMessage As String = ""

            If String.IsNullOrWhiteSpace(dl) = False Then

                Dim Success As Boolean = True
                Dim ErrorMessage As String = ""
                Dim qs As New AdvantageFramework.Web.QueryString

                qs = qs.FromString("placeholder?dl=" & dl)

                Try

                    If String.IsNullOrWhiteSpace(qs.ConnectionString) = False AndAlso
                    String.IsNullOrWhiteSpace(qs.UserCode) = False AndAlso
                    qs.AlertID > 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(qs.ConnectionString, qs.UserCode)

                            Webvantage.SignalR.Classes.NotificationHub.RefreshAlertProof(DbContext, qs.AlertID, qs.UserCode, True)
                            ReturnMessage = "Refreshed AlertID: " & qs.AlertID

                        End Using

                    Else

                        ReturnMessage = "Missing needed parameters!"

                    End If

                Catch ex As Exception
                    ReturnMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                End Try

            Else

                ReturnMessage = "Missing all parameters for refresh!"

            End If

            Return Json(ReturnMessage, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function EmailExternalReviewers(ByVal AlertID As Integer,
                                               ByVal ProofingExternalReviewerID As Integer?) As JsonResult

            Dim ErrorMessages As New Generic.List(Of String)
            Dim Success As Boolean = False

            If ProofingExternalReviewerID = 0 Then ProofingExternalReviewerID = Nothing

            Success = Me._Controller.EmailExternalReviewers(AlertID, ProofingExternalReviewerID, False, ErrorMessages)

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            Nothing,
                                                                            New With {.Success = Success,
                                                                                      .Message = ErrorMessages}))

        End Function

        <HttpPost>
        Public Function AddExternalReviewerToAssignment(ByVal AlertID As Integer,
                                                        ByVal ProofingExternalReviewerID As Integer) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim Success As Boolean = True

            Success = Me._Controller.AddExternalReviewerToAssignment(AlertID, ProofingExternalReviewerID, ErrorMessage)

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            ErrorMessage,
                                                                            New With {.Success = Success,
                                                                                      .Message = ErrorMessage}))

        End Function
        <HttpGet>
        Public Function CanRemoveExternalReviewerFromAssignment(ByVal AlertID As Integer,
                                                                ByVal ProofingExternalReviewerID As Integer) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim CanRemove As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                CanRemove = Me._Controller.CanRemoveExternalReviewerFromAssignment(DbContext, AlertID, ProofingExternalReviewerID, ErrorMessage)

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(CanRemove,
                                                                            ErrorMessage,
                                                                            New With {.Success = CanRemove,
                                                                                      .Message = ErrorMessage}), JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function RemoveExternalReviewerFromAssignment(ByVal AlertID As Integer,
                                                             ByVal ProofingExternalReviewerID As Integer) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim Success As Boolean = True

            Success = Me._Controller.RemoveExternalReviewerFromAssignment(AlertID, ProofingExternalReviewerID, ErrorMessage)

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success,
                                                                            ErrorMessage,
                                                                            New With {.Success = Success,
                                                                                      .Message = ErrorMessage}))

        End Function
        <HttpPost>
        Public Function SaveExternalReviewer(ByVal AlertID As Integer,
                                             ByVal Name As String,
                                             ByVal Email As String) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim Success As Boolean = True
            Dim ProofingExternalReviewer As AdvantageFramework.Database.Entities.ProofingExternalReviewer = Nothing
            Try

                ProofingExternalReviewer = Me._Controller.SaveExternalReviewer(AlertID, Name, Email, ErrorMessage)

                If ProofingExternalReviewer IsNot Nothing Then

                    If Me._Controller.AddExternalReviewerToAssignment(AlertID, ProofingExternalReviewer.ID, ErrorMessage) = False Then

                        Success = False
                        ErrorMessage = "Could not add external reviewer to assignment.  " & ErrorMessage

                    End If

                Else

                    Success = False
                    ErrorMessage = "Could not add external reviewer to database.  " & ErrorMessage

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, New With {.Success = Success, .Message = ErrorMessage}))

        End Function
        <HttpPost>
        Public Function UploadURL(ByVal AlertID As Integer,
                                  ByVal Title As String,
                                  ByVal URL As String,
                                  ByVal UploadDocumentManager As Boolean) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim Success As Boolean = True

            Try

                Success = Me._Controller.UploadURL(AlertID, Title, URL, UploadDocumentManager, ErrorMessage)

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, New With {.Success = Success, .Message = ErrorMessage}))

        End Function
        <HttpPost>
        Public Function TempUploadURL(ByVal AlertID As Integer,
                                      ByVal Title As String,
                                      ByVal UploadDocumentManager As Boolean,
                                      ByVal URL As String) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim Success As Boolean = True

            Try

                Success = Me._Controller.UploadURL(AlertID, Title, URL, UploadDocumentManager, ErrorMessage)

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, New With {.Success = Success, .Message = ErrorMessage}))

        End Function
        <HttpPost>
        Public Function SaveAssignmentWithDateWorkaround(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                                         ByVal StartDate As String, ByVal DueDate As String, ByVal CompletedDate As String,
                                                         ByVal Notify As Boolean) As JsonResult

            ApplyDateWorkaround(Alert, StartDate, DueDate, CompletedDate)

            Return SaveAssignment(Alert, Notify)

        End Function
        <HttpPost>
        Public Function SaveAssignment(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal Notify As Boolean) As JsonResult

            'objects
            Dim Saved As Boolean = False
            Dim AlertView As AdvantageFramework.ViewModels.Desktop.AlertView
            Dim UpdateSprint As Boolean = False
            Dim SprintID As Integer = 0

            Saved = _Controller.SaveAssignment(Alert)

            'NotifyAlertRecipients(Alert.ID, Notify, True, False, UpdateSprint, Alert.SprintID, False)

            If Saved Then

                Try

                    If Alert.SprintID IsNot Nothing Then

                        SprintID = Alert.SprintID

                    End If

                Catch ex As Exception
                    SprintID = 0
                End Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, Alert.ID, SprintID, Me.SecuritySession.UserCode, "", False)

                End Using

                Return GetAlertView(Alert.ID, If(Alert.SprintID IsNot Nothing, Alert.SprintID, 0))

            Else

                Return Nothing

            End If

        End Function
        <HttpPost>
        Public Function SendAssignmentWithDateWorkaround(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                                         ByVal StartDate As String, ByVal DueDate As String, ByVal CompletedDate As String,
                                                         ByVal AddUpdatedComment As Boolean) As JsonResult

            ApplyDateWorkaround(Alert, StartDate, DueDate, CompletedDate)

            Return SendAssignment(Alert, AddUpdatedComment)

        End Function
        <HttpPost>
        Public Function SendAssignment(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                       ByVal AddUpdatedComment As Boolean) As JsonResult

            'objects
            Dim Sent As Boolean = Nothing
            Dim Message As String = Nothing
            Dim UpdateSprint As Boolean = False
            Dim StateChanged As Boolean = False
            Dim AssigneesChanged As Boolean = False
            Dim SendEmail As Boolean = AddUpdatedComment

            Try

                If _Controller.SaveAssignment(Alert) Then

                    If _Controller.SendAssignment(Alert, StateChanged, AssigneesChanged, AddUpdatedComment, Message) Then

                        Sent = True

                        If StateChanged = True AndAlso Alert.AlertCategoryID = 79 Then

                            SendEmail = True

                        End If

                        NotifyAlertRecipients(Alert.ID, SendEmail, True, False, True, Alert.SprintID, False, 0)

                        Try

                            Alert = _Controller.LoadAlertView(Alert.ID).Alert

                        Catch ex As Exception
                        End Try

                    End If

                End If

            Catch ex As Exception
                Message = ex.Message
            End Try

            Return MaxJson(New With {.Sent = Sent,
                                     .Message = Message,
                                     .Alert = Alert,
                                     .StateChanged = StateChanged,
                                     .AssigneesChanged = AssigneesChanged})

        End Function
        <HttpPost>
        Public Function ZeroOutEmployeeHours(ByVal AlertID As Integer,
                                             ByVal EmployeeCode As String) As JsonResult

            Dim Updated As Boolean = False

            If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Updated = _Controller.UpdateRecipientHours(DbContext, AlertID, 0, EmployeeCode)

                End Using

            End If

            Return Json(New With {.Updated = Updated})

        End Function
        <HttpPost>
        Public Function UpdateRecipientHours(ByVal AlertID As Integer,
                                             ByVal HoursAllowed As Decimal,
                                             ByVal JobHours As Decimal?) As JsonResult

            Dim Updated As Boolean = False
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Updated = _Controller.UpdateRecipientHours(DbContext, AlertID, HoursAllowed, "")

                If JobHours IsNot Nothing Then

                    Dim SQL As String = String.Format("UPDATE JOB_TRAFFIC_DET SET JOB_HRS = {0} FROM
	                                                        JOB_TRAFFIC_DET jtd
	                                                        JOIN ALERT A ON A.JOB_NUMBER = jtd.JOB_NUMBER 
	                                                        AND A.JOB_COMPONENT_NBR = jtd.JOB_COMPONENT_NBR 
	                                                        AND A.TASK_SEQ_NBR = jtd.SEQ_NBR 
	                                                        AND A.ALERT_ID = {1};", JobHours, AlertID)
                    DbContext.Database.ExecuteSqlCommand(SQL)

                End If

            End Using

            Return Json(New With {.Updated = Updated})

        End Function
        <HttpPost>
        Public Function SetShowHideSystemComments(ByVal Hide As Boolean) As JsonResult

            'objects
            Dim Success As Boolean = False

            Success = _Controller.SetShowHideSystemComments(Hide)

            Return MaxJson(New With {.Success = Success})

        End Function
        <HttpPost>
        Public Function AddMention(ByVal AlertID As Integer, ByVal Mentions As String(), ByVal DescriptionMention As Integer)

            _Controller.AddAlertMentions(AlertID, Mentions, DescriptionMention)

        End Function
        <HttpPost>
        Public Function AddAlertComment(ByVal AlertID As Integer, ByVal CommentID As Integer?,
                                        ByVal Comment As String, ByVal Files As String(),
                                        ByVal UploadToRepository As Boolean, ByVal UploadToProofHQ As Boolean,
                                        ByVal LinksString As String, ByVal Mentions As String(),
                                        ByVal DocumentID As Integer?) As JsonResult

            'objects
            Dim Added As Boolean = False
            Dim TempDirectory As String = Nothing
            Dim TempFiles As Generic.List(Of String) = Nothing
            Dim CommentDocuments As Generic.List(Of AdvantageFramework.AlertSystem.Classes.CommentDocument) = Nothing
            Dim CommentDocument As AdvantageFramework.AlertSystem.Classes.CommentDocument = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As String = Nothing
            Dim LinksList As Generic.List(Of Link) = Nothing
            Dim ErrorMessages As New Generic.List(Of String)
            Dim ErrorMessage As String = String.Empty

            Try

                If (Mentions IsNot Nothing AndAlso Mentions.Length > 0) Then

                    AddMention(AlertID, Mentions, 0)

                End If

            Catch ex As Exception
            End Try
            If Files IsNot Nothing AndAlso Files.Count > 0 Then

                TempFiles = GetTempUploadAttachments(Files, ErrorMessage)

                If TempFiles IsNot Nothing Then

                    Documents = New List(Of AdvantageFramework.Database.Entities.Document)

                    If _Controller.SaveAttachments(AlertID, TempFiles, UploadToRepository, UploadToProofHQ, ErrorMessage, Documents) Then

                        If Documents IsNot Nothing AndAlso Documents.Count > 0 Then

                            CommentDocuments = (From item In Documents
                                                Select New AdvantageFramework.AlertSystem.Classes.CommentDocument With {.Filename = item.FileName,
                                                                                 .DocumentId = item.ID,
                                                                                 .MimeType = item.MIMEType}).ToList

                        End If

                    End If

                End If

            End If
            Try

                If String.IsNullOrWhiteSpace(LinksString) = False Then

                    LinksList = JsonConvert.DeserializeObject(Of Generic.List(Of Link))(LinksString)

                End If
                If LinksList IsNot Nothing AndAlso LinksList.Count > 0 Then

                    Dim CommentDoc As AdvantageFramework.AlertSystem.Classes.CommentDocument = Nothing

                    If CommentDocuments Is Nothing Then

                        CommentDocuments = New List(Of AdvantageFramework.AlertSystem.Classes.CommentDocument)

                    End If

                    For Each Link As AlertController.Link In LinksList

                        ErrorMessage = String.Empty
                        CommentDoc = Nothing

                        If Link.Link.ToLower().StartsWith("http://") = False AndAlso Link.Link.ToLower().StartsWith("https://") = False Then

                            Link.Link = "http://" & Link.Link

                        End If

                        If Me._Controller.UploadURL(AlertID, Link.Title, Link.Link, Link.UploadDocumentManager, ErrorMessage) = True Then

                            CommentDoc = New AdvantageFramework.AlertSystem.Classes.CommentDocument

                            CommentDoc.DocumentId = -1
                            CommentDoc.Title = Link.Title
                            CommentDoc.Filename = Link.Link
                            CommentDoc.MimeType = "URL"

                            CommentDocuments.Add(CommentDoc)

                        Else

                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                ErrorMessages.Add(ErrorMessage)

                            End If

                        End If

                    Next

                End If

            Catch ex As Exception
                ErrorMessages.Add(AdvantageFramework.StringUtilities.FullErrorToString(ex))
            End Try

            CommentDocument = New AdvantageFramework.AlertSystem.Classes.CommentDocument

            DocumentList = CommentDocument.ObjectToString(CommentDocuments)

            Added = _Controller.AddAlertComment(AlertID, CommentID, Comment, Nothing, DocumentList, DocumentID)

            If Added Then

                DeleteTempUploadAttachments()

                NotifyAlertRecipients(AlertID, True, True, False, False, Nothing, True, DocumentID)

            End If

            Return MaxJson(Added)

        End Function
        <HttpPost>
        Public Function UpdateAlertCommentSimple(ByVal CommentID As Integer,
                                                 ByVal Comment As String,
                                                 ByVal Mentions As String()) As JsonResult

            Dim Updated As Boolean = False
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                AlertComment = AdvantageFramework.Database.Procedures.AlertComment.LoadByCommentID(DbContext, CommentID)

                If AlertComment IsNot Nothing Then

                    Try

                        If (Mentions IsNot Nothing AndAlso Mentions.Length > 0) Then

                            AddMention(AlertComment.AlertID, Mentions, 0)

                        End If

                    Catch ex As Exception
                    End Try

                    AlertComment.Comment = Comment

                    Updated = AdvantageFramework.Database.Procedures.AlertComment.Update(DbContext, AlertComment)

                    If Updated = True Then

                        'NotifyAlertRecipients(AlertComment.AlertID, True, True, False, False, Nothing, True, AlertComment.DocumentID)

                    End If

                End If

            End Using

            Return Json(Updated)

        End Function
        <HttpPost>
        Public Function UpdateAlertComment(ByVal CommentID As Integer,
                                           ByVal Comment As String,
                                           ByVal Files As String(),
                                           ByVal UploadToRepository As Boolean,
                                           ByVal UploadToProofHQ As Boolean,
                                           ByVal LinksString As String,
                                           ByVal Mentions As String(),
                                           ByVal DocumentID As Integer?,
                                           ByVal IsExternalLink As Boolean?) As JsonResult

            'objects
            Dim Updated As Boolean = False
            Dim TempDirectory As String = Nothing
            Dim TempFiles As Generic.List(Of String) = Nothing
            Dim CommentDocuments As Generic.List(Of AdvantageFramework.AlertSystem.Classes.CommentDocument) = Nothing
            Dim CommentDocument As AdvantageFramework.AlertSystem.Classes.CommentDocument = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim DocumentList As String = Nothing
            Dim LinksList As Generic.List(Of Link) = Nothing
            Dim ErrorMessages As New Generic.List(Of String)
            Dim ErrorMessage As String = String.Empty
            Dim AlertComment As AdvantageFramework.Database.Entities.AlertComment = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                AlertComment = AdvantageFramework.Database.Procedures.AlertComment.LoadByCommentID(DbContext, CommentID)

                If AlertComment IsNot Nothing Then

                    Try

                        If (Mentions IsNot Nothing AndAlso Mentions.Length > 0) Then

                            AddMention(AlertComment.AlertID, Mentions, 0)

                        End If

                    Catch ex As Exception
                    End Try
                    If Files IsNot Nothing AndAlso Files.Count > 0 Then

                        TempFiles = GetTempUploadAttachments(Files, ErrorMessage)

                        If TempFiles IsNot Nothing Then

                            Documents = New List(Of AdvantageFramework.Database.Entities.Document)

                            If _Controller.SaveAttachments(AlertComment.AlertID, TempFiles, UploadToRepository, UploadToProofHQ, ErrorMessage, Documents) Then

                                If Documents IsNot Nothing AndAlso Documents.Count > 0 Then

                                    CommentDocuments = (From item In Documents
                                                        Select New AdvantageFramework.AlertSystem.Classes.CommentDocument With {.Filename = item.FileName,
                                                                                     .DocumentId = item.ID,
                                                                                     .MimeType = item.MIMEType}).ToList

                                End If

                            End If

                        End If

                    End If
                    Try

                        If String.IsNullOrWhiteSpace(LinksString) = False Then

                            LinksList = JsonConvert.DeserializeObject(Of Generic.List(Of Link))(LinksString)

                        End If
                        If LinksList IsNot Nothing AndAlso LinksList.Count > 0 Then

                            Dim CommentDoc As AdvantageFramework.AlertSystem.Classes.CommentDocument = Nothing

                            If CommentDocuments Is Nothing Then

                                CommentDocuments = New List(Of AdvantageFramework.AlertSystem.Classes.CommentDocument)

                            End If

                            For Each Link As AlertController.Link In LinksList

                                ErrorMessage = String.Empty
                                CommentDoc = Nothing

                                If Me._Controller.UploadURL(AlertComment.AlertID, Link.Title, Link.Link, Link.UploadDocumentManager, ErrorMessage) = True Then

                                    CommentDoc = New AdvantageFramework.AlertSystem.Classes.CommentDocument

                                    CommentDoc.DocumentId = -1
                                    CommentDoc.Title = Link.Title
                                    CommentDoc.Filename = Link.Link
                                    CommentDoc.MimeType = "URL"

                                    CommentDocuments.Add(CommentDoc)

                                Else

                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                        ErrorMessages.Add(ErrorMessage)

                                    End If

                                End If

                            Next

                        End If

                    Catch ex As Exception
                        ErrorMessages.Add(AdvantageFramework.StringUtilities.FullErrorToString(ex))
                    End Try

                    CommentDocument = New AdvantageFramework.AlertSystem.Classes.CommentDocument

                    DocumentList = CommentDocument.ObjectToString(CommentDocuments)

                    Updated = _Controller.UpdateAlertComment(DbContext, CommentID, Comment, Nothing, DocumentList, DocumentID)

                    If Updated = True Then

                        DeleteTempUploadAttachments()

                        'NotifyAlertRecipients(AlertComment.AlertID, True, True, False, False, Nothing, True, DocumentID)

                    End If

                End If

            End Using

            Return Json(Updated)

        End Function
        <Serializable> Public Class Link
            Public Property Title As String = String.Empty
            Public Property Link As String = String.Empty
            Public Property UploadDocumentManager As Boolean = False
            Sub New()

            End Sub
        End Class
        <HttpPost>
        Public Function CreateAssignmentWithDateWorkaround(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                                           ByVal StartDate As String, ByVal DueDate As String,
                                                           ByVal Notify As Boolean, ByVal UploadToRepository As Boolean,
                                                           ByVal UploadToProofHQ As Boolean, ByVal Report As String,
                                                           ByVal LinksString As String) As JsonResult


            If String.IsNullOrWhiteSpace(StartDate) = False AndAlso IsDate(StartDate) = True Then

                Alert.StartDate = CType(CType(StartDate, Date).ToShortDateString, Date)

            End If
            If String.IsNullOrWhiteSpace(DueDate) = False AndAlso IsDate(DueDate) = True Then

                Alert.DueDate = CType(CType(DueDate, Date).ToShortDateString, Date)

            End If

            Return CreateAssignment(Alert, Notify, UploadToRepository, UploadToProofHQ, Report, LinksString)

        End Function
        <HttpPost>
        Public Function CreateAssignment(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                         ByVal Notify As Boolean, ByVal UploadToRepository As Boolean,
                                         ByVal UploadToProofHQ As Boolean, ByVal Report As String,
                                         ByVal LinksString As String) As JsonResult

            'objects
            Dim Created As Boolean = False
            Dim UploadedFile As Object = Nothing
            Dim ErrorMessage As String = String.Empty
            Dim TempFiles As Generic.List(Of String) = Nothing
            Dim LinksList As Generic.List(Of Link) = Nothing
            Dim ErrorMessages As New Generic.List(Of String)
            Dim RefreshMe As Boolean = False
            Dim SendEmail As Boolean = Notify

            Try

                TempFiles = GetTempUploadAttachments(Alert.UploadedFiles, ErrorMessage)

            Catch ex As Exception
                TempFiles = Nothing
            End Try

            'For old "Print/Send" where it would automatically generate and attach docs
            Try

                If String.IsNullOrWhiteSpace(Alert.CallingPage) = False Then

                    If TempFiles Is Nothing Then TempFiles = New List(Of String)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Dim GeneratedReportFullPathAndFilename As String = String.Empty

                        Select Case Alert.CallingPage.ToLower
                            Case PrintPages.JobVersionPrint.ToString.ToLower

                                Try

                                    Dim TemplateName As String = String.Empty
                                    Dim ReportVersion As String = String.Empty

                                    If HttpContext.Session("JVTemplateName") IsNot Nothing Then TemplateName = HttpContext.Session("JVTemplateName").ToString
                                    If HttpContext.Session("JVReportVersion") IsNot Nothing Then ReportVersion = HttpContext.Session("JVReportVersion").ToString
                                    'Alert.JobNumber, Alert.JobComponentNumber,
                                    GeneratedReportFullPathAndFilename = OutputReportFileJobVersion(DbContext, 1, TemplateName, ReportVersion, 1, ErrorMessage)

                                Catch ex As Exception
                                    GeneratedReportFullPathAndFilename = String.Empty
                                End Try
                                If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                    TempFiles.Add(GeneratedReportFullPathAndFilename)

                                End If

                            Case PrintPages.PurchaseOrderPrint.ToString.ToLower

                                Try

                                    Dim PurchaseOrderRefID As Integer = 0
                                    Dim PurchaseOrderPrintOptions As String = String.Empty
                                    Dim PurchaseOrderPrintReport As String = String.Empty

                                    If HttpContext.Session("POPrint") IsNot Nothing Then PurchaseOrderRefID = HttpContext.Session("POPrint").ToString
                                    If HttpContext.Session("POPrintOptions") IsNot Nothing Then PurchaseOrderPrintOptions = HttpContext.Session("POPrintOptions").ToString
                                    If HttpContext.Session("POPrintReport") IsNot Nothing Then PurchaseOrderPrintReport = HttpContext.Session("POPrintReport").ToString

                                    GeneratedReportFullPathAndFilename = Me.OutputReportFilePO(DbContext, PurchaseOrderRefID, PurchaseOrderPrintOptions, PurchaseOrderPrintReport, ErrorMessage)

                                Catch ex As Exception
                                    GeneratedReportFullPathAndFilename = String.Empty
                                End Try
                                If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                    TempFiles.Add(GeneratedReportFullPathAndFilename)

                                End If

                            Case PrintPages.JobTemplatePrint.ToString.ToLower

                                Try

                                    If Alert.JobNumber IsNot Nothing AndAlso Alert.JobNumber > 0 AndAlso
                                        Alert.JobComponentNumber IsNot Nothing AndAlso Alert.JobComponentNumber > 0 Then

                                        Dim _Report As String = Report 'Session("JobPrintReport")
                                        Dim Jobs As String = String.Empty 'Session("JobPrintMultiSwitch")
                                        Dim PrintJobOrder As Boolean = False 'Session("JobPrintJobOrder")
                                        Dim PrintJobSpecs As Boolean = False 'Session("JobPrintJobSpecs")
                                        Dim PrintJobVersions As Boolean = False 'Session("JobPrintJobVersions")
                                        Dim PrintCreativeBrief As Boolean = False 'Session("JobPrintCreativeBrief")
                                        Dim OmitEmptyFieldsJobSpecs As Boolean = False 'Session("OmitEmptyFieldsJS")
                                        Dim OmitEmptyFieldsJobVersions As Boolean = False 'Session("OmitEmptyFieldsJV")

                                        Dim JobVersionReportTitle As String = String.Empty 'Session("JVReportTitle")
                                        Dim CreativeBriefReportTitle As String = String.Empty 'Session("CBReportTitle")
                                        Dim CreativeBriefLogoLocation As String = String.Empty 'Session("CBLogoLocation")
                                        Dim CreativeBriefLogoLocationID As String = String.Empty 'Session("CBLogoLocationID")
                                        Dim CreativeBriefLogoPlacement As Integer = 1 'Session("CBLogoPlacement")

                                        If HttpContext.Session("JobPrintReport") IsNot Nothing Then _Report = HttpContext.Session("JobPrintReport")
                                        If HttpContext.Session("JobPrintMultiSwitch") IsNot Nothing Then Jobs = HttpContext.Session("JobPrintMultiSwitch")
                                        If HttpContext.Session("JobPrintJobOrder") IsNot Nothing Then PrintJobOrder = HttpContext.Session("JobPrintJobOrder")
                                        If HttpContext.Session("JobPrintJobSpecs") IsNot Nothing Then PrintJobSpecs = HttpContext.Session("JobPrintJobSpecs")
                                        If HttpContext.Session("JobPrintJobVersions") IsNot Nothing Then PrintJobVersions = HttpContext.Session("JobPrintJobVersions")
                                        If HttpContext.Session("JobPrintCreativeBrief") IsNot Nothing Then PrintCreativeBrief = HttpContext.Session("JobPrintCreativeBrief")
                                        If HttpContext.Session("OmitEmptyFieldsJS") IsNot Nothing Then OmitEmptyFieldsJobSpecs = HttpContext.Session("OmitEmptyFieldsJS")
                                        If HttpContext.Session("OmitEmptyFieldsJV") IsNot Nothing Then OmitEmptyFieldsJobVersions = HttpContext.Session("OmitEmptyFieldsJV")
                                        If HttpContext.Session("JVReportTitle") IsNot Nothing Then JobVersionReportTitle = HttpContext.Session("JVReportTitle")
                                        If HttpContext.Session("CBReportTitle") IsNot Nothing Then CreativeBriefReportTitle = HttpContext.Session("CBReportTitle")
                                        If HttpContext.Session("CBLogoLocation") IsNot Nothing Then CreativeBriefLogoLocation = HttpContext.Session("CBLogoLocation")
                                        If HttpContext.Session("CBLogoLocationID") IsNot Nothing Then CreativeBriefLogoLocationID = HttpContext.Session("CBLogoLocationID")
                                        If HttpContext.Session("CBLogoPlacement") IsNot Nothing Then CreativeBriefLogoPlacement = HttpContext.Session("CBLogoPlacement")

                                        HttpContext.Session("printjs") = If(PrintJobSpecs = True, 1, 0)
                                        HttpContext.Session("printjv") = If(PrintJobVersions = True, 1, 0)
                                        HttpContext.Session("printcb") = If(PrintCreativeBrief = True, 1, 0)
                                        HttpContext.Session("printjof") = If(PrintJobOrder = True, 1, 0)

                                        If PrintJobOrder = True Then
                                            Try

                                                GeneratedReportFullPathAndFilename = Me.OutputReportFileJT(DbContext, Alert.JobNumber, Alert.JobComponentNumber, 1, _Report, ErrorMessage)

                                            Catch ex As Exception
                                                GeneratedReportFullPathAndFilename = String.Empty
                                            End Try
                                            If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                                TempFiles.Add(GeneratedReportFullPathAndFilename)

                                            End If
                                        End If
                                        If PrintJobSpecs = True Then
                                            Try

                                                GeneratedReportFullPathAndFilename = Me.OutputReportFileJSAllVers(Alert.JobNumber, Alert.JobComponentNumber, 1, ErrorMessage)

                                            Catch ex As Exception
                                                GeneratedReportFullPathAndFilename = String.Empty
                                            End Try
                                            If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                                TempFiles.Add(GeneratedReportFullPathAndFilename)

                                            End If
                                        End If
                                        If PrintJobVersions = True Then
                                            Try

                                                GeneratedReportFullPathAndFilename = Me.OutputReportFileJVAllVers(Alert.JobNumber, Alert.JobComponentNumber, JobVersionReportTitle, 1, ErrorMessage)

                                            Catch ex As Exception
                                                GeneratedReportFullPathAndFilename = String.Empty
                                            End Try
                                            If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                                TempFiles.Add(GeneratedReportFullPathAndFilename)

                                            End If
                                        End If
                                        If PrintCreativeBrief = True Then
                                            Try

                                                GeneratedReportFullPathAndFilename = Me.OutputReportFileCB(DbContext, Alert.JobNumber, Alert.JobComponentNumber, 1, ErrorMessage)

                                            Catch ex As Exception
                                                GeneratedReportFullPathAndFilename = String.Empty
                                            End Try
                                            If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                                TempFiles.Add(GeneratedReportFullPathAndFilename)

                                            End If
                                        End If


                                    End If

                                Catch ex As Exception
                                End Try

                            Case PrintPages.EstimatingPrint.ToString.ToLower

                                Try

                                    Dim EstimatingPrintJobNumber As Integer = 0
                                    Dim EstimatingPrintJobComponentNumber As Short = 0
                                    Dim EstimatingPrintEstimatingNumber As Integer = 0
                                    Dim EstimatingPrintEstimatingComponentNumber As Short = 0
                                    Dim EstimatingPrintType As Integer = 0
                                    Dim EstimatingPrintReport As String = String.Empty
                                    Dim EstimatingPrintOption As String = String.Empty
                                    Dim EstimatingPrintQuotes As String = String.Empty
                                    Dim EstimatingPrintComps As String = String.Empty
                                    Dim EstimatingPrintCombine As Boolean = False
                                    Dim EstimatingPrintFormatType As String
                                    Dim EstimatingPrintedDate As String
                                    Dim EstimatingPrintUseSignature As String

                                    If HttpContext.Session("EstimatingPrintJobNumber") IsNot Nothing Then EstimatingPrintJobNumber = HttpContext.Session("EstimatingPrintJobNumber")
                                    If HttpContext.Session("EstimatingPrintJobComponentNumber") IsNot Nothing Then EstimatingPrintJobComponentNumber = HttpContext.Session("EstimatingPrintJobComponentNumber")
                                    If HttpContext.Session("EstimatingPrintEstimatingNumber") IsNot Nothing Then EstimatingPrintEstimatingNumber = HttpContext.Session("EstimatingPrintEstimatingNumber")
                                    If HttpContext.Session("EstimatingPrintEstimatingComponentNumber") IsNot Nothing Then EstimatingPrintEstimatingComponentNumber = HttpContext.Session("EstimatingPrintEstimatingComponentNumber")
                                    If HttpContext.Session("EstimatingPrintType") IsNot Nothing Then EstimatingPrintType = HttpContext.Session("EstimatingPrintType")
                                    If HttpContext.Session("EstimatingPrintReport") IsNot Nothing Then EstimatingPrintReport = HttpContext.Session("EstimatingPrintReport")
                                    If HttpContext.Session("EstimatingPrintOption") IsNot Nothing Then EstimatingPrintOption = HttpContext.Session("EstimatingPrintOption")
                                    If HttpContext.Session("EstimatingPrintQuotes") IsNot Nothing Then EstimatingPrintQuotes = HttpContext.Session("EstimatingPrintQuotes")
                                    If HttpContext.Session("EstimatingPrintComp") IsNot Nothing Then EstimatingPrintComps = HttpContext.Session("EstimatingPrintComp")
                                    If HttpContext.Session("EstimatingPrintFormatType") IsNot Nothing Then EstimatingPrintFormatType = HttpContext.Session("EstimatingPrintFormatType")
                                    If HttpContext.Session("EstimatingPrintedDate") IsNot Nothing Then EstimatingPrintedDate = HttpContext.Session("EstimatingPrintedDate")
                                    If HttpContext.Session("EstimatingPrintUseSignature") IsNot Nothing Then EstimatingPrintUseSignature = HttpContext.Session("EstimatingPrintUseSignature")

                                    Try

                                        If HttpContext.Session("EstimatingPrintCombine") IsNot Nothing AndAlso HttpContext.Session("EstimatingPrintCombine") = 1 Then

                                            EstimatingPrintCombine = True

                                        End If

                                    Catch ex As Exception
                                        EstimatingPrintCombine = False
                                    End Try
                                    If EstimatingPrintCombine = True Then

                                        Try

                                            GeneratedReportFullPathAndFilename = Me.OutputReportFileEST(DbContext,
                                                                                                        EstimatingPrintEstimatingNumber,
                                                                                                        EstimatingPrintEstimatingComponentNumber,
                                                                                                        EstimatingPrintType,
                                                                                                        EstimatingPrintFormatType,
                                                                                                        EstimatingPrintCombine,
                                                                                                        EstimatingPrintReport,
                                                                                                        EstimatingPrintOption,
                                                                                                        ErrorMessage,
                                                                                                        EstimatingPrintUseSignature,
                                                                                                        EstimatingPrintJobComponentNumber,
                                                                                                        EstimatingPrintComps,
                                                                                                        EstimatingPrintQuotes)

                                        Catch ex As Exception
                                            GeneratedReportFullPathAndFilename = String.Empty
                                        End Try
                                        If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                            TempFiles.Add(GeneratedReportFullPathAndFilename)

                                        End If

                                    Else

                                        Dim comp As Integer = 0
                                        Dim qte As Integer = 0
                                        Dim qtes As String = String.Empty
                                        Dim qtedesc As String = String.Empty
                                        Dim comps() As String = EstimatingPrintComps.Split(",")
                                        Dim quotesEst() As String = EstimatingPrintQuotes.Split(",")
                                        Dim quotesDesc() As String = HttpContext.Session("EstimatingQteDescs").ToString.Split(",")
                                        Dim FileName As String = String.Empty

                                        For i As Integer = 0 To comps.Length - 1

                                            FileName = String.Empty

                                            Try

                                                If comps(i) <> "" Then

                                                    If comp > 0 And comp <> comps(i) Then

                                                        If IsNumeric(comps(i)) = True Then

                                                            HttpContext.Session("EstimatingQteDescs" & comp) = qtedesc

                                                            Try

                                                                FileName = Me.OutputReportFileEST(DbContext,
                                                                                                  EstimatingPrintEstimatingNumber,
                                                                                                  comps(i),
                                                                                                  EstimatingPrintType,
                                                                                                  EstimatingPrintFormatType,
                                                                                                  EstimatingPrintCombine,
                                                                                                  EstimatingPrintReport,
                                                                                                  EstimatingPrintOption,
                                                                                                  ErrorMessage,
                                                                                                  EstimatingPrintUseSignature,
                                                                                                  comps(i),
                                                                                                  EstimatingPrintComps,
                                                                                                  EstimatingPrintQuotes)

                                                            Catch ex As Exception
                                                                FileName = String.Empty
                                                            End Try
                                                            If String.IsNullOrWhiteSpace(FileName) = False Then

                                                                TempFiles.Add(FileName)

                                                            End If

                                                            qtes = ""

                                                        End If

                                                    End If

                                                    comp = comps(i)
                                                    qte = quotesEst(i)
                                                    qtes &= qte & ","
                                                    qtedesc &= quotesDesc(i) & ","

                                                End If

                                            Catch ex As Exception
                                            End Try

                                        Next

                                        FileName = String.Empty
                                        HttpContext.Session("EstimatingQteDescs" & comp) = qtedesc

                                        Try

                                            FileName = Me.OutputReportFileEST(DbContext, EstimatingPrintEstimatingNumber, EstimatingPrintEstimatingComponentNumber, EstimatingPrintType,
                                                                              EstimatingPrintFormatType, EstimatingPrintCombine, EstimatingPrintReport, EstimatingPrintOption,
                                                                              ErrorMessage, True, EstimatingPrintEstimatingComponentNumber,
                                                                              EstimatingPrintComps, EstimatingPrintQuotes)

                                        Catch ex As Exception
                                            FileName = String.Empty
                                        End Try
                                        If String.IsNullOrWhiteSpace(FileName) = False Then

                                            TempFiles.Add(FileName)

                                        End If

                                        GeneratedReportFullPathAndFilename = MiscFN.RemoveTrailingDelimiter(GeneratedReportFullPathAndFilename, ",")

                                    End If

                                Catch ex As Exception
                                End Try

                            Case PrintPages.CreativeBriefPrint.ToString.ToLower

                                Try

                                    GeneratedReportFullPathAndFilename = OutputReportFileCB(DbContext, Alert.JobNumber, Alert.JobComponentNumber, 1, ErrorMessage)

                                Catch ex As Exception
                                    GeneratedReportFullPathAndFilename = String.Empty
                                End Try
                                If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                    TempFiles.Add(GeneratedReportFullPathAndFilename)

                                End If

                            Case PrintPages.MediaATBPrint.ToString.ToLower

                            Case PrintPages.JobSpecPrint.ToString.ToLower

                                Try

                                    GeneratedReportFullPathAndFilename = OutputReportFileJS(1, ErrorMessage)

                                Catch ex As Exception
                                    GeneratedReportFullPathAndFilename = String.Empty
                                End Try
                                If String.IsNullOrWhiteSpace(GeneratedReportFullPathAndFilename) = False Then

                                    TempFiles.Add(GeneratedReportFullPathAndFilename)

                                End If

                        End Select

                    End Using

                End If

            Catch ex As Exception
            End Try

            If TempFiles IsNot Nothing AndAlso TempFiles.Count > 0 Then

                Alert.UploadedFiles = TempFiles.ToArray

            Else

                Alert.UploadedFiles = Nothing

            End If

            If _Controller.CreateAssignment(Alert, SendEmail, UploadToRepository, UploadToProofHQ, ErrorMessage) Then

                DeleteTempUploadAttachments()

                Try

                    If String.IsNullOrWhiteSpace(LinksString) = False Then

                        LinksList = JsonConvert.DeserializeObject(Of Generic.List(Of Link))(LinksString)

                    End If
                    If LinksList IsNot Nothing AndAlso LinksList.Count > 0 Then

                        'Dim CommentDoc As Webvantage.CommentDocument = Nothing

                        'If CommentDocuments Is Nothing Then

                        '    CommentDocuments = New List(Of CommentDocument)

                        'End If

                        For Each Link As AlertController.Link In LinksList

                            ErrorMessage = String.Empty

                            If Link.Link.ToLower().StartsWith("http://") = False AndAlso Link.Link.ToLower().StartsWith("https://") = False Then

                                Link.Link = "http://" & Link.Link

                            End If

                            If Me._Controller.UploadURL(Alert.ID, Link.Title, Link.Link, Link.UploadDocumentManager, ErrorMessage) = True Then

                                'CommentDoc = New Webvantage.CommentDocument

                                'CommentDoc.DocumentId = -1
                                'CommentDoc.Title = Link.Title
                                'CommentDoc.Filename = Link.Link
                                'CommentDoc.MimeType = "URL"

                                'CommentDocuments.Add(CommentDoc)

                            Else

                                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                    ErrorMessages.Add(ErrorMessage)

                                End If

                            End If

                        Next

                    End If

                Catch ex As Exception
                    ErrorMessages.Add(AdvantageFramework.StringUtilities.FullErrorToString(ex))
                End Try

                Created = True

                NotifyAlertRecipients(Alert.ID, SendEmail, True, True, True, Nothing, False, 0)

                Try

                    Webvantage.SignalR.Classes.NotificationHub.RefreshMyAssignmentsBecauseIamTheAssignee(Me.SecuritySession.ConnectionString, Me.SecuritySession.User.EmployeeCode,
                                                                                                         Me.SecuritySession.UserCode, Alert.ID)


                Catch ex As Exception
                End Try

                Try

                    If Alert IsNot Nothing AndAlso Alert.Assignees IsNot Nothing AndAlso Alert.Assignees.Contains(Me.SecuritySession.User.EmployeeCode) Then

                        RefreshMe = True

                    End If

                Catch ex As Exception
                End Try

            End If

            Return MaxJson(New With {.Success = Created,
                                     .Message = ErrorMessage.Replace(vbNewLine, "<br/>"),
                                     .AlertID = Alert.ID,
                                     .Title = Alert.Subject,
                                     .RefreshMe = RefreshMe})

        End Function
        <HttpPost>
        Public Function CalculateScheduleDates(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty
            Dim ReturnObject As Object = Nothing

            If Alert IsNot Nothing AndAlso
                Alert.JobNumber IsNot Nothing AndAlso Alert.JobNumber > 0 AndAlso
                Alert.JobComponentNumber IsNot Nothing AndAlso Alert.JobComponentNumber > 0 AndAlso
                Alert.TaskSequenceNumber IsNot Nothing AndAlso Alert.TaskSequenceNumber > -1 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim JobTraffic As AdvantageFramework.Database.Entities.JobTraffic = Nothing

                    JobTraffic = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext,
                                                                                                                        Alert.JobNumber,
                                                                                                                        Alert.JobComponentNumber)
                    If JobTraffic IsNot Nothing Then

                        Dim Schedule As Webvantage.cSchedule = Nothing
                        Dim Result As String = Nothing

                        Schedule = New Webvantage.cSchedule(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        If JobTraffic.ScheduleCalculation.GetValueOrDefault(0) = 0 Then

                            Result = Schedule.CalculateDueDates(Alert.JobNumber, Alert.JobComponentNumber, 0)

                        Else

                            Result = Schedule.CalculateDueDatesPred(Alert.JobNumber, Alert.JobComponentNumber, 1)

                        End If
                        Select Case Result

                            Case -1

                                ErrorMessage = "Could not get start date."

                            Case -2

                                ErrorMessage = "Schedule is not feasible for calculation."

                        End Select
                        If Result <> -1 AndAlso Result <> -2 Then

                            Success = True

                        End If
                        If Success = True Then

                            If AdvantageFramework.Database.Procedures.JobTrafficPredecessors.LoadByJobNumberAndJobComponentNumberPredecessors(DbContext, Alert.JobNumber, Alert.JobComponentNumber).Any Then

                                Result = Schedule.CalculateJobPreds(Alert.JobNumber, Alert.JobComponentNumber, 0, Me.SecuritySession.User.EmployeeCode)

                            End If

                            Schedule.UpdateTaskAlertsDueDate(Alert.JobNumber, Alert.JobComponentNumber)

                        End If

                    End If

                End Using

            End If

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, ReturnObject))

        End Function
        <HttpPost>
        Public Function UploadAttachmentToProofHQ(ByVal AttachmentID As Integer) As JsonResult

            'objects
            Dim Uploaded As Boolean = False

            Uploaded = _Controller.UploadAttachmentToProofHQ(AttachmentID)

            Return MaxJson(Uploaded)

        End Function
        <HttpPost>
        Public Function GetCCRecipientsAvailable(ByVal ClientCode As String,
                                                 ByVal JobNumber As Integer?, ByVal JobComponentNumber As Short?, ByVal TaskSequenceNumber As Short?,
                                                 ByVal Type As Integer) As JsonResult

            Dim List As Generic.List(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList) = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    Dim SQL As String = String.Format("EXEC [dbo].[advsp_alert_get_cc_groups] {0}, NULL, {1}, {2}, {3}, {4};",
                                                        Type,
                                                        If(String.IsNullOrWhiteSpace(ClientCode) = False, String.Format("'{0}'", ClientCode), "NULL"),
                                                        If(JobNumber IsNot Nothing AndAlso JobNumber > 0, JobNumber, "NULL"),
                                                        If(JobComponentNumber IsNot Nothing AndAlso JobComponentNumber > 0, JobComponentNumber, "NULL"),
                                                        If(TaskSequenceNumber IsNot Nothing AndAlso TaskSequenceNumber >= 0, TaskSequenceNumber, "NULL"))

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList)(SQL).ToList

                Catch ex As Exception
                    List = Nothing
                End Try

            End Using

            Return MaxJson(List, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function AddCCRecipientsFrom(ByVal AlertID As Integer, ByVal Type As Integer) As JsonResult

            'objects
            Dim Added As Boolean = False
            Dim HasAdd As Boolean = False
            Dim List As Generic.List(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try

                    List = DbContext.Database.SqlQuery(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList)(String.Format("EXEC [dbo].[advsp_alert_get_cc_groups] {0}, {1}, NULL, NULL, NULL, NULL;", Type, AlertID)).ToList

                Catch ex As Exception
                    List = Nothing
                End Try
                If List IsNot Nothing Then

                    Try

                        For Each Item As AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList In List

                            If Item.Code.StartsWith("CC|") = False Then

                                Added = _Controller.AddRecipient(AlertID, Item.Code)

                            Else

                                Added = _Controller.AddClientContactRecipient(AlertID, CType(Item.Code.Replace("CC|", ""), Integer))

                            End If
                            If Added = True Then

                                HasAdd = True

                            End If

                        Next

                    Catch ex As Exception

                    End Try

                End If

            End Using

            If HasAdd = True Then

                Me.PushAlertRecipientsChange(AlertID, "")

            End If

            Return MaxJson(HasAdd)

        End Function
        <HttpPost>
        Public Function AddRecipients(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert,
                                      ByVal EmployeeCodes As Generic.List(Of AdvantageFramework.Controller.Desktop.AlertController.SimpleSelectList)) As JsonResult

            'objects
            Dim Added As Boolean = False

            'If EmployeeCode.StartsWith("CC|") = False Then

            '    Added = _Controller.AddRecipient(Alert.ID, EmployeeCode)

            'Else

            '    Added = _Controller.AddClientContactRecipient(Alert.ID, CType(EmployeeCode.Replace("CC|", ""), Integer))

            'End If

            'Me.PushAlertRecipientsChange(Alert.ID, "")

            Return MaxJson(Added)

        End Function
        <HttpPost>
        Public Function AddRecipient(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim Added As Boolean = False

            If EmployeeCode.StartsWith("CC|") = False Then

                Added = _Controller.AddRecipient(Alert.ID, EmployeeCode)

            Else

                Added = _Controller.AddClientContactRecipient(Alert.ID, CType(EmployeeCode.Replace("CC|", ""), Integer))

            End If

            Me.PushAlertRecipientsChange(Alert.ID, "")

            Return MaxJson(Added)

        End Function
        <HttpPost>
        Public Function DeleteRecipient(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim Deleted As Boolean = False

            If EmployeeCode.StartsWith("CC|") = False Then

                Deleted = _Controller.DeleteRecipient(Alert.ID, EmployeeCode)

            Else

                Deleted = _Controller.DeleteClientContact(Alert.ID, CType(EmployeeCode.Replace("CC|", ""), Integer))

            End If

            Me.PushAlertRecipientsChange(Alert.ID, EmployeeCode)

            Return MaxJson(Deleted)

        End Function
        <HttpPost>
        Public Function StateHasAssignee(ByVal AlertID As Integer,
                                         ByVal AlertTemplateID As Integer,
                                         ByVal AlertStateID As Integer,
                                         ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim HasAssignee As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                HasAssignee = AdvantageFramework.AlertSystem.HasAssignee(DbContext, AlertID, AlertTemplateID, AlertStateID, EmployeeCode)

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(HasAssignee, ErrorMessage, New With {.HasAssignee = HasAssignee,
                                                                                                                 .Message = ErrorMessage}))

        End Function



        <HttpPost>
        Public Function AddAssigneeToTemplate(ByVal AlertID As Integer,
                                              ByVal AlertTemplateID As Integer,
                                              ByVal AlertStateID As Integer,
                                              ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim Added As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Added = AdvantageFramework.AlertSystem.AddAssigneeToTemplate(DbContext, Me.SecuritySession.UserCode,
                                                                             AlertID, AlertTemplateID, AlertStateID, EmployeeCode, 0, ErrorMessage)

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Added, ErrorMessage, New With {.Success = Added, .Message = ErrorMessage}))

        End Function
        <HttpPost>
        Public Function DeleteAssigneeFromTemplate(ByVal AlertID As Integer,
                                                   ByVal AlertTemplateID As Integer,
                                                   ByVal AlertStateID As Integer,
                                                   ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Deleted = AdvantageFramework.AlertSystem.DeleteAssigneeFromTemplate(DbContext,
                                                                                    Me.SecuritySession.UserCode,
                                                                                    AlertID, AlertTemplateID, AlertStateID,
                                                                                    EmployeeCode, 0, ErrorMessage)

            End Using

            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Deleted, ErrorMessage, New With {.Success = Deleted, .Message = ErrorMessage}))

        End Function
        <HttpPost>
        Public Function AddAssignee(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim Added As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Added = AdvantageFramework.AlertSystem.AddAssignee(DbContext, Me.SecuritySession, Alert.ID, EmployeeCode)

            End Using

            If Added = True Then

                Me.PushAlertRecipientsChange(Alert.ID, "")

            End If

            Return MaxJson(Added)

        End Function
        <HttpPost>
        Public Function DeleteAssignee(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal EmployeeCode As String) As JsonResult

            'objects
            Dim Deleted As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Deleted = AdvantageFramework.AlertSystem.DeleteAssignee(DbContext, Alert.ID, EmployeeCode)

            End Using

            Me.PushAlertRecipientsChange(Alert.ID, EmployeeCode)

            Return MaxJson(Deleted)

        End Function
        <HttpGet>
        Public Function GetSprintJobComponents(ByVal SprintID As Integer) As JsonResult

            'objects
            Dim JobComponents As Generic.List(Of AdvantageFramework.DTO.JobComponent) = Nothing

            JobComponents = AdvantageFramework.ProjectManagement.Agile.LoadSprintJobComponents(Me.SecuritySession, SprintID, 0, AdvantageFramework.ProjectManagement.Agile.Methods.JobComponentLookupObjectLevel.Component)

            Return MaxJson(JobComponents, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function InitNewAssignment(ByVal CallingPage As String) As JsonResult

            Dim AllowUpload As Boolean = True
            Dim DefaultAssignment As Boolean = False
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = 0
            Dim DefaultSubject As String = String.Empty
            Dim RepositorySizeLimit As Long = 0
            Dim RepositoryFileSizeLimit As Long = 0
            Dim RepositoryLimitText As String = ""
            Dim LimitRepository As Boolean = False
            Dim AllowProofHQ As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                AllowUpload = Me.AllowRepositoryUpload(DbContext, RepositorySizeLimit, RepositoryFileSizeLimit, RepositoryLimitText, LimitRepository)

                CurrentQueryString.SprintHeaderID = 0
                CurrentQueryString.BoardStateID = 0
                CurrentQueryString.JobNumber = 0
                CurrentQueryString.JobComponentNumber = 0
                CurrentQueryString.BoardID = 0
                CurrentQueryString.BoardHeaderID = 0
                CurrentQueryString.ClientCode = 0

                'Get from session if since it is agency setting and not user setting
                DefaultAssignment = GetAgencyDefaultToRoutedOnNewAssignmentSetting()
                AllowProofHQ = GetAgencyAllowProofHQSetting()

            End Using

            Return MaxJson(New With {.DefaultSubject = DefaultSubject,
                                     .RepositoryLimitText = RepositoryLimitText,
                                     .AllowUpload = AllowUpload,
                                     .DefaultAssignment = DefaultAssignment,
                                     .AllowProofHQ = AllowProofHQ}, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function TryDownloadAttachment(ByVal AlertID As Integer, ByVal DocumentID As Integer)

            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim AttachmentEntity As AdvantageFramework.Database.Entities.AlertAttachment = Nothing
            Dim ByteFile As Byte() = Nothing
            Dim FileExists As Boolean = False
            Dim Key As String = String.Empty
            Dim ErrorMessage As String = String.Empty
            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    AttachmentEntity = AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertIDAndDocumentID(DbContext, AlertID, DocumentID)

                    If AttachmentEntity IsNot Nothing Then

                        Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                        If Document IsNot Nothing Then

                            Dim arParams As New List(Of SqlParameter)

                            arParams.Add(New SqlParameter("@ALERT_ID", AlertID))
                            arParams.Add(New SqlParameter("@DOCUMENT_ID", DocumentID))
                            arParams.Add(New SqlParameter("@FILENAME", Document.FileName))

                            ErrorMessage = DbContext.Database.SqlQuery(Of String)("EXEC [dbo].[advsp_alert_validate_attachment_download] @ALERT_ID, @DOCUMENT_ID, @FILENAME;",
                                                                              arParams.ToArray).SingleOrDefault

                            If String.IsNullOrWhiteSpace(ErrorMessage) = True Then

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                If Agency IsNot Nothing Then

                                    AdvantageFramework.FileSystem.Download(Agency, Document, ByteFile, FileExists)

                                    If FileExists Then

                                        Key = AdvantageFramework.Security.Encryption.Encrypt(DocumentID.ToString)

                                    Else

                                        ErrorMessage = "Cannot retrieve document from repository."
                                        FileExists = False

                                    End If


                                Else

                                    ErrorMessage = "Cannot get Agency info."
                                    FileExists = False

                                End If

                            Else

                                FileExists = False

                            End If

                        Else

                            ErrorMessage = "Cannot get Document info."
                            FileExists = False

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                FileExists = False
            End Try

            Return MaxJson(New With {.Exists = FileExists, .Key = Key, .ErrorMessage = ErrorMessage})

        End Function
        <AcceptVerbs("POST")>
        Public Function StartStopwatch(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                If Alert IsNot Nothing AndAlso Alert.JobNumber IsNot Nothing AndAlso Alert.JobNumber > 0 AndAlso Alert.JobComponentNumber IsNot Nothing AndAlso Alert.JobComponentNumber > 0 Then


                    Success = AdvantageFramework.EmployeeTimesheet.StopwatchStart(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.SecuritySession.User.EmployeeCode,
                                                                                  Alert.JobNumber, Alert.JobComponentNumber,
                                                                                  If(Alert.TaskSequenceNumber IsNot Nothing, Alert.TaskSequenceNumber, -1),
                                                                                  Alert.ID, ErrorMessage)

                End If

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            'Return MaxJson(New With {.Success = Success, .Message = ErrorMessage})
            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, New With {.Success = Success, .Message = ErrorMessage}))

        End Function
        <AcceptVerbs("POST")>
        Public Function HasStopwatch(ByVal EmployeeCode As String) As JsonResult

            Dim StopwatchIsRunning As Boolean = False
            Dim EmployeeTimeID As Integer = 0
            Dim EmployeeTimeDetailID As Integer = 0
            Dim StopwatchStartDate As Date
            Dim Comment As String = String.Empty
            Dim Description As String = String.Empty
            Dim TimeType As String = String.Empty
            Dim StopwatchServerTime As Date
            Dim IsOverTwentyFourHours As Boolean = False
            Dim RunningTime As New TimeSpan
            Dim DateString As String = String.Empty
            Dim IsCommentRequired As Boolean = False
            Dim TimesheetSettings As New AdvantageFramework.Timesheet.TimesheetSettings(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
            Dim HasComments As Boolean = False

            If String.IsNullOrWhiteSpace(EmployeeCode) = True Then

                EmployeeCode = Me.CurrentEmployeeCode

            End If

            If AdvantageFramework.Timesheet.HasStopWatch(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, EmployeeCode,
                                                         EmployeeTimeID, EmployeeTimeDetailID, StopwatchStartDate, Comment, Description, TimeType, StopwatchServerTime) = True Then

                StopwatchIsRunning = True
                RunningTime = Me.TimeZoneToday.Subtract(StopwatchStartDate)
                IsOverTwentyFourHours = RunningTime.TotalHours > 24
                DateString = StopwatchStartDate.ToString("MMMM dd, yyyy H:mm:ss")

                If TimesheetSettings.CommentsRequired = True AndAlso Comment = "" AndAlso TimeType = "D" AndAlso TimesheetSettings.TimeEntryCommentRequired(EmployeeTimeID, EmployeeTimeDetailID) = True Then

                    IsCommentRequired = True

                End If
                If String.IsNullOrWhiteSpace(Comment) = False Then

                    HasComments = True

                End If

            End If

            Return MaxJson(New With {.StopwatchIsRunning = StopwatchIsRunning,
                                     .DateString = DateString,
                                     .ServerTime = StopwatchServerTime,
                                     .Description = Description,
                                     .CommentsRequired = IsCommentRequired,
                                     .HasComments = HasComments,
                                     .EmployeeCode = Me.CurrentEmployeeCode})

        End Function
        <AcceptVerbs("POST")>
        Public Function StopStopwatch(ByVal EmployeeCode As String) As JsonResult

            Dim StopWatch As Boolean = False
            Dim EtId As Integer = 0
            Dim EtDtlId As Integer = 0
            Dim StopwatchStartDate As Date = Nothing
            Dim Comment As String = ""
            Dim Description As String = ""
            Dim StopwatchServerTime As Date
            Dim TimeType As String = ""
            Dim stopped As Boolean = False
            Dim ErrorMessage As String = String.Empty

            If AdvantageFramework.Timesheet.HasStopWatch(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.CurrentEmployeeCode, EtId, EtDtlId, StopwatchStartDate, Comment, Description, TimeType, StopwatchServerTime) = True Then

                StopWatch = True

                If EtId > 0 And EtDtlId > 0 Then

                    Dim ts As New AdvantageFramework.Timesheet.TimesheetSettings(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Dim Hours As Decimal = 0.0
                    Dim s As String = ""

                    If ts.CommentsRequired = True And Comment = "" And TimeType = "D" And ts.TimeEntryCommentRequired(EtId, EtDtlId) = True Then

                        ErrorMessage = "Comment is required."
                        stopped = False

                    Else

                        stopped = AdvantageFramework.Timesheet.StopwatchStop(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.CurrentEmployeeCode,
                                                                             EtId, EtDtlId, Hours, Comment, s)

                    End If

                End If

            End If

            'Return MaxJson(New With {.Success = stopped, .Message = ErrorMessage})
            Return Json(AdvantageFramework.Web.JsonResponseFactory.Response(stopped, ErrorMessage, New With {.Success = stopped, .Message = ErrorMessage}))

        End Function
        <HttpPost>
        Public Function BookmarkAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            'objects
            Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
            Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
            Dim Saved As Boolean = False
            Dim Message As String = ""

            BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
            Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

            Bookmark.BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_Alerts
            Bookmark.UserCode = Me.SecuritySession.UserCode

            If Alert.IsWorkItem = False Then

                Bookmark.Name = String.Format("{0}: {1} {2}", "Alert", Alert.ID, Alert.Subject)

            Else

                If Alert.AlertSequenceNumber IsNot Nothing AndAlso Alert.JobNumber IsNot Nothing AndAlso Alert.JobComponentNumber IsNot Nothing Then

                    Bookmark.Name = String.Format("{0}: {1}/{2}/{3} - {4}", "Assignment", Alert.JobNumber.ToString.PadLeft(6, "0"), Alert.JobComponentNumber.ToString.PadLeft(2, "0"), Alert.AlertSequenceNumber, Alert.Subject)

                Else

                    Bookmark.Name = String.Format("{0}: {1} {2}", "Assignment", Alert.ID, Alert.Subject)

                End If

            End If

            Bookmark.PageURL = "Desktop_AlertView" & Me.HttpContext.Request.UrlReferrer.Query
            Bookmark.Description = Alert.Subject

            Saved = BookmarkMethods.SaveBookmark(Bookmark, Message)

            Return MaxJson(New With {.Success = Saved, .Message = Message})

        End Function
        <HttpPost>
        Public Function Reassign(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            Dim Reassigned As Boolean = False
            Dim Message As String = Nothing
            Dim UpdateSprint As Boolean = False
            Dim StateChanged As Boolean = False
            Dim AssigneesChanged As Boolean = False

            If _Controller.SendAssignment(Alert, StateChanged, AssigneesChanged, True, Message) Then

                Reassigned = True
                NotifyAlertRecipients(Alert.ID, True, True, False, True, Alert.SprintID, False, 0)

            End If

            Return MaxJson(New With {.Reassigned = Reassigned,
                                     .Message = Message,
                                     .StateChanged = StateChanged,
                                     .AssigneesChanged = AssigneesChanged})

        End Function
        <HttpPost>
        Public Function ReopenAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            'objects
            Dim Reopened As Boolean = False

            Reopened = _Controller.ReopenAlert(Alert)

            If Reopened = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    PushSprintRefreshAndNotifyByAlertID(DbContext, Alert.ID, Alert.SprintID)

                End Using

            End If

            Return MaxJson(New With {.Success = Reopened})

        End Function
        <HttpPost>
        Public Function CompleteAlertByAlertID(ByVal AlertID As Integer) As JsonResult

            Dim Completed As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        Completed = _Controller.CompleteAlert(Alert).Success

                    End If
                    If Completed = True Then

                        PushSprintRefreshAndNotifyByAlertID(DbContext, Alert.ID, Nothing)

                    End If

                End Using

            Catch ex As Exception
                Completed = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return MaxJson(New With {.Success = Completed})

        End Function
        <HttpPost>
        Public Function UnTempComplete(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            'objects
            Dim UnTempCompleted As Boolean = False

            UnTempCompleted = _Controller.UnTempComplete(Alert)

            If UnTempCompleted = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Webvantage.SignalR.Classes.NotificationHub.RefreshTaskAssignment(DbContext, Alert.ID, If(Alert.SprintID IsNot Nothing, Alert.SprintID, 0), Me.SecuritySession.UserCode)

                End Using

            End If

            Return MaxJson(New With {.Success = UnTempCompleted})

        End Function
        <HttpPost>
        Public Function TempComplete(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            'objects
            Dim TempCompleted As Boolean = False
            Dim ShowFullyCompletePrompt As Boolean = False

            TempCompleted = _Controller.TempComplete(Alert, ShowFullyCompletePrompt)

            If TempCompleted = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Webvantage.SignalR.Classes.NotificationHub.RefreshTaskAssignment(DbContext, Alert.ID, If(Alert.SprintID IsNot Nothing, Alert.SprintID, 0), Me.SecuritySession.UserCode)

                End Using

            End If

            Return MaxJson(New With {.Success = TempCompleted, .ShowFullyCompletePrompt = ShowFullyCompletePrompt})

        End Function

        <HttpPost>
        Public Function CompleteProof(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing
            'Dim UserCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim AlertIDSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
            'Dim EmployeeCodeSqlParameter As System.Data.SqlClient.SqlParameter = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                CompleteResult = _Controller.CompleteProof(DbContext, Alert.ID, Me.SecuritySession.User.EmployeeCode)

                NotifyAlertRecipients(Alert.ID, True, True, False, True, Alert.SprintID, False, 0)
                PushSprintRefreshAndNotifyByAlertID(DbContext, Alert.ID, Alert.SprintID)

                Return MaxJson(New With {.Success = CompleteResult.Success,
                                         .StateChanged = True,
                                         .AssigneesChanged = True,
                                         .Result = CompleteResult})
            End Using

        End Function
        <HttpPost>
        Public Function CompleteAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            Dim CompleteResult As AdvantageFramework.AlertSystem.CompleteAssignmentResult = Nothing
            Dim StateChanged As Boolean = False
            Dim AssigneesChanged As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                CompleteResult = _Controller.CompleteAlert(DbContext, Alert, StateChanged, AssigneesChanged)

                If CompleteResult IsNot Nothing AndAlso CompleteResult.Success = True Then

                    NotifyAlertRecipients(Alert.ID, CompleteResult.AutoRouteChangedState, True, False, True, Alert.SprintID, False, 0)
                    PushSprintRefreshAndNotifyByAlertID(DbContext, Alert.ID, Alert.SprintID)

                End If

            End Using

            Return MaxJson(New With {.Success = CompleteResult.Success,
                                     .StateChanged = StateChanged,
                                     .AssigneesChanged = AssigneesChanged,
                                     .Result = CompleteResult})

        End Function
        <HttpPost>
        Public Function SyncReview(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            Dim Dismissed As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim AlertEntity As AdvantageFramework.Database.Entities.Alert = Nothing

                AlertEntity = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Alert.ID)

                If AlertEntity IsNot Nothing Then

                    If AlertEntity.ConceptShareReviewID IsNot Nothing AndAlso AlertEntity.ConceptShareReviewID > 0 Then

                        If AlertEntity.AlertAssignmentTemplateID IsNot Nothing AndAlso AlertEntity.AlertAssignmentTemplateID > 0 Then

                            Dim ConceptShareSession As New ConceptShareSession(Me.SecuritySession)
                            Dim ConceptShareConnection As AdvantageFramework.ConceptShare.Classes.ConceptShareConnection
                            Dim ReviewSummary As AdvantageFramework.ConceptShare.Classes.ReviewSummary = Nothing
                            Dim ConceptShareProjectID As Integer = 0
                            Dim ConceptShareReviewID As Integer = 0
                            Dim NewCommentsCount As Integer = 0
                            Dim NewRepliesCount As Integer = 0
                            Dim CommentsSynced As Boolean = False

                            ConceptShareConnection = Nothing

                            ConceptShareConnection = ConceptShareSession.CreateAdminConceptShareConnection

                            If ConceptShareConnection IsNot Nothing Then

                                'CommentsSynced = AdvantageFramework.ConceptShare.SyncReviewToAlert(ConceptShareConnection,
                                '                                                                   ConceptShareProjectID,
                                '                                                                   ConceptShareReviewID,
                                '                                                                   Alert.ID,
                                '                                                                   NewCommentsCount,
                                '                                                                   NewRepliesCount,
                                '                                                                   Me.SecuritySession, DbContext)
                                ReviewSummary = AdvantageFramework.ConceptShare.LoadReviewSummary(ConceptShareConnection, AlertEntity.ConceptShareReviewID)

                                If ReviewSummary IsNot Nothing Then

                                    Dim ThreadableSync As New AdvantageFramework.ConceptShare.ThreadableSync(Me.SecuritySession)

                                    ThreadableSync.ConceptShareConnection = ConceptShareConnection
                                    ThreadableSync.ReviewID = AlertEntity.ConceptShareReviewID
                                    If AlertEntity.ConceptShareProjectID IsNot Nothing Then

                                        ThreadableSync.ProjectID = AlertEntity.ConceptShareProjectID

                                    End If

                                    ThreadableSync.SyncFromCard(AlertEntity, ReviewSummary)

                                End If

                            End If

                        Else

                            'old path???
                            Dismissed = _Controller.DismissAlert(Alert)

                        End If

                    End If

                End If
                If Dismissed = True Then

                    RefreshAfterAlertAction(DbContext, Alert.ID, Alert.SprintID)

                End If

            End Using

            Return MaxJson(New With {.Success = Dismissed})

        End Function
        <HttpPost>
        Public Function DismissAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            'objects
            Dim Dismissed As Boolean = False

            If MiscFN.IsClientPortal = True Then

                Dismissed = _Controller.DismissAlertCP(Alert)

            Else

                Dismissed = _Controller.DismissAlert(Alert)

            End If
            If Dismissed = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    RefreshAfterAlertAction(DbContext, Alert.ID, Alert.SprintID)
                    'SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                End Using

            End If

            Return MaxJson(New With {.Success = Dismissed})

        End Function
        <HttpPost>
        Public Function DismissAlertAAManager(ByVal AlertID As Integer, ByVal SprintID As Integer) As JsonResult

            'objects
            Dim Dismissed As Boolean = False

            If MiscFN.IsClientPortal = True Then

                'Dismissed = _Controller.DismissAlertCP(Alert)

            Else

                Dismissed = _Controller.DismissAlertAAManager(AlertID)

            End If
            If Dismissed = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    RefreshAfterAlertAction(DbContext, AlertID, SprintID)
                    'SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                End Using

            End If

            Return MaxJson(New With {.Success = Dismissed})

        End Function
        <HttpPost>
        Public Function DismissAlertComplete(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            'objects
            Dim Dismissed As Boolean = False

            Dismissed = _Controller.DismissAlertComplete(Alert)

            If Dismissed = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    RefreshAfterAlertAction(DbContext, Alert.ID, Alert.SprintID)
                    'SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                End Using

            End If

            Return MaxJson(New With {.Success = Dismissed})

        End Function
        <HttpPost>
        Public Function DismissAlertCompleteAAManager(ByVal AlertID As Integer, ByVal SprintID As Integer) As JsonResult

            'objects
            Dim Dismissed As Boolean = False

            Dismissed = _Controller.DismissAlertCompleteAAManager(AlertID)

            If Dismissed = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    RefreshAfterAlertAction(DbContext, AlertID, SprintID)
                    'SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                End Using

            End If

            Return MaxJson(New With {.Success = Dismissed})

        End Function

        <HttpPost>
        Public Function UnDismissAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            'objects
            Dim UnDismissed As Boolean = False

            UnDismissed = _Controller.UnDismissAlert(Alert)

            If UnDismissed = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    RefreshAfterAlertAction(DbContext, Alert.ID, Alert.SprintID)
                    'SignalR.Classes.NotificationHub.RefreshAlertsForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)

                End Using

            End If

            Return MaxJson(New With {.Success = UnDismissed})

        End Function
        <HttpPost>
        Public Function DeleteAttachment(ByVal AlertID As Integer, ByVal DocumentID As Integer, ByVal IsTaskDocument As Boolean) As JsonResult

            Dim Deleted As Boolean = False

            Deleted = _Controller.DeleteAttachment(AlertID, DocumentID, IsTaskDocument)

            If Deleted = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    PushSprintRefreshAndNotifyByAlertID(DbContext, AlertID, Nothing)

                End Using

            End If

            Return MaxJson(New With {.Success = Deleted})

        End Function
        <HttpPost>
        Public Function SaveNewWorkItem(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            If Alert IsNot Nothing Then



            End If

        End Function
        <HttpPost>
        Public Function TempUploadAttachment(ByVal File As HttpPostedFileBase) As JsonResult

            'objects
            Dim FileName As String = Nothing
            Dim Path As String = Nothing
            Dim FullDirectory As String = Nothing
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = ""
            Dim Key As String = String.Empty

            Try

                If File IsNot Nothing Then

                    If File.ContentLength > 0 Then

                        If FileTypeIsValid(File) = True Then

                            Dim AlertController = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)
                            Dim DelayMilliseconds As Integer = AlertController.GetUploadDelay()

                            Try

                                If DelayMilliseconds > 0 Then

                                    System.Threading.Thread.Sleep(CType(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay"), Integer))

                                End If

                            Catch ex As Exception
                            End Try

                            If HttpContext.Session("TempUploadAttachment") Is Nothing Then

                                HttpContext.Session("TempUploadAttachment") = Guid.NewGuid.ToString

                            End If

                            Key = HttpContext.Session("TempUploadAttachment")

                            FullDirectory = Me.PathToTempFolder() & Key

                            If Not System.IO.Directory.Exists(FullDirectory) Then

                                System.IO.Directory.CreateDirectory(FullDirectory)

                            End If

                            If System.IO.Directory.Exists(FullDirectory) Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                    AdvantageFramework.FileSystem.CheckFileForRepositoryConstraints(DbContext, File.ContentLength,
                                                                                                    IsValid, ErrorMessage)

                                    If IsValid = True Then

                                        Try

                                            File.SaveAs(FullDirectory & "\" & File.FileName)
                                            IsValid = True

                                        Catch ex As Exception
                                            IsValid = False
                                            ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                                        End Try

                                    Else

                                        'CheckFileForRepositoryConstraints should have set the ErrorMessage 

                                    End If

                                End Using

                            End If

                        Else

                            IsValid = False
                            ErrorMessage = "Invalid file type."

                        End If

                    Else

                        IsValid = False
                        ErrorMessage = "No file content."

                    End If

                Else

                    IsValid = False
                    ErrorMessage = "No file."

                End If

            Catch ex As Exception
                IsValid = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try
            Try

                If IsValid = False AndAlso String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    ErrorMessage = Key & "__ERR:" & ErrorMessage
                    AdvantageFramework.Security.AddWebvantageEventLog("TEMP_UPLOAD_ATTACHMENT__" & ErrorMessage)
                    Webvantage.SignalR.Classes.NotificationHub.MessageUser(Me.SecuritySession.UserCode, ErrorMessage)

                End If

            Catch ex As Exception
            End Try
            If IsValid = True Then

                If System.IO.File.Exists(FullDirectory & "\" & File.FileName) = False Then

                    IsValid = False
                    ErrorMessage = Key & "__ERR: File could not be validated."
                    AdvantageFramework.Security.AddWebvantageEventLog("TEMP_UPLOAD_ATTACHMENT__" & ErrorMessage)
                    Webvantage.SignalR.Classes.NotificationHub.MessageUser(Me.SecuritySession.UserCode, ErrorMessage)

                End If

            End If

            'Return MaxJson(New With {.Success = IsValid, .Message = ErrorMessage})
            If IsValid Then

                Return MaxJson(Key)

            Else

                Response.StatusCode = CInt(Net.HttpStatusCode.InternalServerError)
                Return MaxJson(ErrorMessage)

            End If

        End Function
        <HttpPost>
        Public Function UploadAttachment(ByVal File As HttpPostedFileBase, ByVal AlertID As Integer, ByVal UploadToRepository As Boolean, ByVal UploadToProofHQ As Boolean) As JsonResult

            'objects
            Dim FileName As String = Nothing
            Dim FullDirectory As String = Nothing
            Dim Saved As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorMessage As String = String.Empty
            Dim Key As String = String.Empty

            Try

                If File IsNot Nothing Then

                    If File.ContentLength > 0 Then

                        If FileTypeIsValid(File) = True Then

                            Dim AlertController = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)
                            Dim DelayMilliseconds As Integer = AlertController.GetUploadDelay()

                            Try

                                If DelayMilliseconds > 0 Then

                                    System.Threading.Thread.Sleep(CType(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay"), Integer))

                                End If

                            Catch ex As Exception
                            End Try

                            Key = Guid.NewGuid.ToString
                            FullDirectory = Me.PathToTempFolder() & Key

                            If Not System.IO.Directory.Exists(FullDirectory) Then

                                System.IO.Directory.CreateDirectory(FullDirectory)

                            End If

                            If System.IO.Directory.Exists(FullDirectory) Then

                                FileName = FullDirectory & "\" & File.FileName

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                    AdvantageFramework.FileSystem.CheckFileForRepositoryConstraints(DbContext, File.ContentLength, IsValid, ErrorMessage)

                                    If IsValid Then

                                        File.SaveAs(FullDirectory & "\" & File.FileName)

                                        If System.IO.File.Exists(FileName) Then

                                            Saved = _Controller.SaveAttachment(AlertID, FileName, UploadToRepository, UploadToProofHQ, ErrorMessage)

                                        End If
                                        If Saved = True Then

                                            PushSprintRefreshAndNotifyByAlertID(DbContext, AlertID, Nothing)

                                        End If

                                    End If

                                End Using

                            End If

                        Else

                            ErrorMessage = "Invalid file type."

                        End If

                    Else

                        ErrorMessage = "No file content."

                    End If

                Else

                    ErrorMessage = "No file."

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try
            Try

                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    AdvantageFramework.Security.AddWebvantageEventLog("UPLOAD_ATTACHMENT__" &
                                                                      Me.SecuritySession.UserCode &
                                                                      "__ERR:" &
                                                                      ErrorMessage)

                End If

            Catch ex As Exception
            End Try
            If Saved Then

                Return MaxJson(Saved)

            Else

                Response.StatusCode = CInt(Net.HttpStatusCode.InternalServerError)
                Return MaxJson(ErrorMessage)

            End If

        End Function
        <HttpPost>
        Public Function DeleteTempUploadAttachment(ByVal Filename As String) As JsonResult

            'objects
            Dim FullDirectory As String = Nothing
            Dim Key As String = String.Empty
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                Dim AlertController = New AdvantageFramework.Controller.Desktop.AlertController(Me.SecuritySession)
                Dim DelayMilliseconds As Integer = AlertController.GetUploadDelay()
                Try

                    If DelayMilliseconds > 0 Then

                        System.Threading.Thread.Sleep(CType(System.Web.Configuration.WebConfigurationManager.AppSettings.Get("UploadDelay"), Integer))

                    End If

                Catch ex As Exception
                End Try

                If Not String.IsNullOrWhiteSpace(Filename) Then

                    If HttpContext.Session("TempUploadAttachment") IsNot Nothing Then

                        Key = HttpContext.Session("TempUploadAttachment")

                        If String.IsNullOrWhiteSpace(Key) = False Then

                            FullDirectory = Me.PathToTempFolder() & Key

                            If System.IO.Directory.Exists(FullDirectory) Then

                                If System.IO.File.Exists(FullDirectory & "\" & Filename) Then

                                    System.IO.File.Delete(FullDirectory & "\" & Filename)

                                    If System.IO.Directory.GetFiles(FullDirectory).Count = 0 Then

                                        System.IO.Directory.Delete(FullDirectory, True)

                                    End If

                                    Deleted = True

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try
            Try
                If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                    ErrorMessage = Me.SecuritySession.UserCode & "__KEY_" & Key & "__ERR:" & ErrorMessage
                    AdvantageFramework.Security.AddWebvantageEventLog("DELETE_TEMP_UPLOAD_ATTACHMENT__" & ErrorMessage)

                End If
            Catch ex As Exception
            End Try

            Return MaxJson(Deleted)

        End Function
        <HttpPost>
        Public Function SignAttachment(ByVal Attachment As AdvantageFramework.DTO.Desktop.AlertAttachment) As JsonResult

            'objects
            Dim Signed As Boolean = False

            Signed = SignDocument(Attachment.AlertID, Attachment.DocumentID)

            Return MaxJson(New With {.Success = Signed})

        End Function
        <HttpPost>
        Public Function SetAutoClose(ByVal AutoClose As Boolean) As JsonResult

            'objects
            Dim Success As Boolean = False

            Success = _Controller.SetAutoClose(AutoClose)

            Return MaxJson(New With {.Success = Success})

        End Function
        <HttpPost>
        Public Function SetShowChecklistsOnCards(ByVal ShowChecklistsOnCards As Boolean) As JsonResult

            'objects
            Dim Success As Boolean = False

            Success = _Controller.SetShowChecklistsOnCards(ShowChecklistsOnCards)

            Return MaxJson(New With {.Success = Success})

        End Function

        <HttpPost>
        Public Function SetUploadDocumentManager(ByVal Upload As Boolean) As JsonResult

            'objects
            Dim Success As Boolean = False

            Success = _Controller.SetUploadDocumentManager(Upload)

            Return MaxJson(New With {.Success = Success})

        End Function
        <HttpPost>
        Public Function SetDetailsExpanded(ByVal Expanded As Boolean) As JsonResult

            'objects
            Dim Success As Boolean = False

            Success = _Controller.SetDetailsExpanded(Expanded)

            Return MaxJson(New With {.Success = Success})

        End Function
        <HttpPost>
        Public Function GetLinkableDocuments(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert) As JsonResult

            'objects
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing
            Dim LinkableDocuments As Generic.List(Of AdvantageFramework.DTO.Desktop.Document) = Nothing
            Dim DocumentIDs As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Select Case Alert.AlertLevel

                    Case "JC", "BRD"

                        If Alert.JobNumber.GetValueOrDefault(0) > 0 AndAlso Alert.JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            DocumentIDs = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_JOB_COMPONENT_DOCUMENTS WHERE SORT = 0 AND JOB_NUMBER = {0} AND JOB_COMPONENT_NUMBER = {1} UNION ALL SELECT DOCUMENT_ID FROM dbo.WV_CURRENT_JOB_DOCUMENTS WHERE SORT = 0 AND JOB_NUMBER = {0}", Alert.JobNumber, Alert.JobComponentNumber)).Distinct.ToArray

                            Documents = (From Item In AdvantageFramework.Database.Procedures.Document.LoadCurrentJobComponentDocuments(DbContext, Alert.JobNumber, Alert.JobComponentNumber).ToList
                                         Join DocId In DocumentIDs On Item.ID Equals DocId
                                         Select Item).ToList

                        End If

                    Case Else


                End Select

                If Alert.ID > 0 AndAlso Documents IsNot Nothing AndAlso Documents.Count > 0 Then

                    DocumentIDs = (From Item In AdvantageFramework.Database.Procedures.AlertAttachment.LoadByAlertID(DbContext, Alert.ID)
                                   Select Item.DocumentID).ToArray

                    If DocumentIDs IsNot Nothing AndAlso DocumentIDs.Count > 0 Then

                        Documents = Documents.Where(Function(d) DocumentIDs.Contains(d.ID) = False).ToList

                    End If

                End If

            End Using

            If Documents IsNot Nothing Then

                LinkableDocuments = (From Document In Documents
                                     Select AdvantageFramework.DTO.Desktop.Document.FromEntity(Document)).ToList

                _Controller.LoadAttachmentDisplayData(LinkableDocuments)

            End If

            Return MaxJson(LinkableDocuments, JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Public Function LinkExistingDocuments(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal Documents As Integer()) As JsonResult

            'objects
            Dim Linked As Boolean = False

            Linked = _Controller.LinkExistingDocuments(Alert.ID, Documents)

            Return MaxJson(Linked)

        End Function
        <HttpPost>
        Public Function SaveWidgetLayout(ByVal WidgetLayout As String()) As JsonResult

            'objects
            Dim Saved As Boolean = False

            Saved = _Controller.SetWidgetLayout(WidgetLayout)

            Return MaxJson(Saved)

        End Function
        <HttpPost>
        Public Function ChangeBoardState(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal NewStateID As Integer) As JsonResult

            'objects
            Dim Changed As Boolean = False

            Changed = _Controller.ChangeBoardState(Alert, NewStateID)

            Return MaxJson(Changed)

        End Function
        <HttpPost>
        Public Function TransferAlert(ByVal AlertID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                      ByVal BoardID As Integer, ByVal SprintID As Integer, ByVal StateID As Integer) As JsonResult

            Dim Transferrred As Boolean = False
            Dim Message As String = String.Empty

            Try

                Transferrred = _Controller.TransferAlert(AlertID, JobNumber, JobComponentNumber, BoardID, SprintID, StateID)

            Catch ex As Exception
                Transferrred = False
                Message = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If Transferrred = True Then

                Message = String.Empty

            End If

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Transferrred, Message, Nothing))

        End Function
        <HttpPost>
        Public Function CopyAlert(ByVal Alert As AdvantageFramework.DTO.Desktop.Alert, ByVal CopyComments As Boolean, ByVal CopyAttachments As Boolean) As JsonResult

            Dim NewAlertID As Integer = 0
            Dim Message As String = String.Empty
            Dim Copied As Boolean = False
            Dim Subject As String = String.Empty

            Try

                NewAlertID = _Controller.CopyAlert(Me.SecuritySession, Alert, CopyComments, CopyAttachments)

            Catch ex As Exception
                NewAlertID = 0
                Message = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            If NewAlertID > 0 Then

                Copied = True
                Message = String.Empty
                NotifyAlertRecipients(NewAlertID, True, True, True, True, Nothing, False, 0)

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Subject = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [SUBJECT] FROM ALERT WITH(NOLOCK) WHERE ALERT_ID = {0};", NewAlertID)).SingleOrDefault()
                        Subject = AdvantageFramework.StringUtilities.JavascriptSafe(Subject)

                    End Using

                Catch ex As Exception
                End Try

            End If

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Copied, Message, New With {.NewAlertID = NewAlertID,
                                                                                                          .Subject = Subject}))

        End Function
        <AcceptVerbs("POST")>
        Public Function ExtendSession() As JsonResult

            Dim Success As Boolean = False
            Dim ErrorMessage As String = String.Empty

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Success = True

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Success, ErrorMessage, Nothing))

        End Function

        'NS: commented out, moved to InboxContoller
        '<HttpPost>
        'Public Function SaveColumnSetting(ByVal GridName As String, ByVal Column As String, ShowHide As Boolean) As JsonResult

        '    Dim save As Boolean = True
        '    Dim colName As String = ""

        '    Try
        '        If Column = "SoftwareBuild" Then
        '            colName = "GridBoundColumnBUILD"
        '        End If
        '        If Column = "SoftwareVersion" Then
        '            colName = "GridBoundColumnVER"
        '        End If
        '        If Column = "ClientName" Then
        '            colName = "CL_NAME"
        '        End If
        '        If Column = "Category" Then
        '            colName = "CATEGORY"
        '        End If
        '        If Column = "StartDate" Then
        '            colName = "START_DATE"
        '        End If
        '        If Column = "DueDate" Then
        '            colName = "DUE_DATE"
        '        End If
        '        If Column = "TimeDue" Then
        '            colName = "GridBoundColumnTimeDue"
        '        End If
        '        If Column = "Priority" Then
        '            colName = "Priority"
        '        End If
        '        If Column = "AssignedTo" Then
        '            colName = "CurrentNotifyEmpFMLColumn"
        '        End If
        '        If Column = "State" Then
        '            colName = "ALERT_STATE_NAME"
        '        End If
        '        If Column = "Division" Then
        '            colName = "GridBoundColumnDivision"
        '        End If
        '        If Column = "Product" Then
        '            colName = "GridBoundColumnProduct"
        '        End If
        '        If Column = "Type" Then
        '                colName = "GridBoundColumnType"
        '            End If
        '        If Column = "Level" Then
        '            colName = "GridBoundColumnLevel"
        '        End If
        '        If Column = "AE" Then
        '            colName = "GridBoundColumnAE"
        '        End If
        '        If Column = "PM" Then
        '            colName = "GridBoundColumnPM"
        '        End If
        '        If Column = "Office" Then
        '            colName = "GridBoundColumnOffice"
        '        End If
        '        If Column = "Campaign" Then
        '            colName = "GridBoundColumnCampaign"
        '        End If
        '        If Column = "Template" Then
        '            colName = "GridBoundColumnTemplate"
        '        End If


        '        AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(Session("ConnString"), HttpContext.Session("UserCode"), GridName, colName, ShowHide)
        '    Catch ex As Exception
        '        save = False
        '    End Try


        '    Return MaxJson(New With {.Success = save})

        'End Function

#Region " Checklist "

        <HttpPost>
        Public Function CreateChecklist(ByVal AlertID As Integer, ByVal Checklist As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) As JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _Controller.CreateChecklist(AlertID, Checklist, MiscFN.IsClientPortal)

            If Created = True Then

                Me.PushChecklistRefresh(AlertID)

            End If

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Created, "", Checklist))

        End Function
        <HttpPost>
        Public Function UpdateChecklistTitle(ByVal ChecklistID As Integer, ByVal Title As String) As JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.UpdateChecklistTitle(ChecklistID, Title)

            If Updated = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim AlertID As Integer = 0

                    Try

                        AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_ID, 0) FROM CHECKLIST_HDR WITH(NOLOCK) WHERE ID = {0};",
                                                                                        ChecklistID)).SingleOrDefault

                    Catch ex As Exception
                        AlertID = 0
                    End Try

                    If AlertID > 0 Then

                        Me.PushChecklistRefresh(AlertID)

                    End If

                End Using

            End If

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, "", Nothing))

        End Function
        <HttpPost>
        Public Function CreateChecklistItem(ByVal Checklist As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader, ByVal ChecklistItem As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail) As JsonResult

            'objects
            Dim Created As Boolean = False

            Created = _Controller.CreateChecklistItem(Checklist, ChecklistItem, MiscFN.IsClientPortal)

            If Created = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim AlertID As Integer = 0

                    Try

                        AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_ID, 0) FROM CHECKLIST_HDR WITH(NOLOCK) WHERE ID = {0};",
                                                                                        Checklist.ID)).SingleOrDefault

                    Catch ex As Exception
                        AlertID = 0
                    End Try

                    If AlertID > 0 Then

                        Me.PushChecklistRefresh(AlertID)

                    End If

                End Using

            End If
            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Created, "", ChecklistItem))

        End Function
        <HttpPost>
        Public Function DeleteChecklistItem(ByVal ChecklistItem As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail) As JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.DeleteChecklistItem(ChecklistItem)

            If Deleted = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim AlertID As Integer = 0

                    Try

                        AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_ID, 0) FROM CHECKLIST_HDR WITH(NOLOCK) WHERE ID = {0};",
                                                                                        ChecklistItem.ChecklistHeaderID)).SingleOrDefault

                    Catch ex As Exception
                        AlertID = 0
                    End Try

                    If AlertID > 0 Then

                        Me.PushChecklistRefresh(AlertID)

                    End If

                End Using

            End If

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Deleted, "", ChecklistItem))

        End Function
        <HttpPost>
        Public Function DeleteChecklist(ByVal ChecklistHeader As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) As JsonResult

            'objects
            Dim Deleted As Boolean = False

            Deleted = _Controller.DeleteChecklist(ChecklistHeader)

            If Deleted = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim AlertID As Integer = 0

                    Try

                        AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_ID, 0) FROM CHECKLIST_HDR WITH(NOLOCK) WHERE ID = {0};",
                                                                                        ChecklistHeader.ID)).SingleOrDefault

                    Catch ex As Exception
                        AlertID = 0
                    End Try

                    If AlertID > 0 Then

                        Me.PushChecklistRefresh(AlertID)

                    End If

                End Using

            End If

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Deleted, "", ChecklistHeader))

        End Function
        <HttpPost>
        Public Function UpdateChecklistItem(ByVal ChecklistItem As AdvantageFramework.DTO.Desktop.Alert.ChecklistDetail) As JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.UpdateChecklistItem(ChecklistItem, MiscFN.IsClientPortal)

            If Updated = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim AlertID As Integer = 0

                    Try

                        AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_ID, 0) FROM CHECKLIST_HDR WITH(NOLOCK) WHERE ID = {0};",
                                                                                        ChecklistItem.ChecklistHeaderID)).SingleOrDefault

                    Catch ex As Exception
                        AlertID = 0
                    End Try

                    If AlertID > 0 Then

                        Me.PushChecklistRefresh(AlertID)

                    End If

                End Using

            End If

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, "", ChecklistItem))

        End Function
        <HttpPost>
        Public Function UpdateChecklist(ByVal Checklist As AdvantageFramework.DTO.Desktop.Alert.ChecklistHeader) As JsonResult

            'objects
            Dim Updated As Boolean = False

            Updated = _Controller.UpdateChecklist(Checklist)

            If Updated = True Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim AlertID As Integer = 0

                    Try

                        AlertID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ALERT_ID, 0) FROM CHECKLIST_HDR WITH(NOLOCK) WHERE ID = {0};",
                                                                                        Checklist.ID)).SingleOrDefault

                    Catch ex As Exception
                        AlertID = 0
                    End Try

                    If AlertID > 0 Then

                        Me.PushChecklistRefresh(AlertID)

                    End If

                End Using

            End If

            Return MaxJson(AdvantageFramework.Web.JsonResponseFactory.Response(Updated, "", Checklist))

        End Function

#End Region

#End Region

#End Region

#Region " Private "

#Region " Reports / Attachments "

        Private Function PathToTempFolder() As String

            Return HttpContext.Request.PhysicalApplicationPath & "TEMP\"

        End Function
        Private Function LoadDefaultSubject(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                              ByVal CallingPage As String, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As String

            Dim HasData As Boolean = False
            Dim SubjectStringBuilder As New System.Text.StringBuilder
            Dim DefaultSubject As String = String.Empty
            Dim jc As New Job(Session("ConnString"))

            Select Case CallingPage
                Case PrintPages.JobVersionPrint.ToString

                    HasData = True

                    jc.GetJob(JobNumber, JobComponentNumber)

                    SubjectStringBuilder.Append("[")
                    SubjectStringBuilder.Append(Session("JVTemplateName").ToString.Replace("\", "").Replace("/", ""))
                    SubjectStringBuilder.Append(" - " & HttpContext.Session("JVReportVersion"))
                    SubjectStringBuilder.Append("] ")
                    SubjectStringBuilder.Append(jc.ClientDesc & " -")
                    SubjectStringBuilder.Append(" Job/Comp ")

                    If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then

                        SubjectStringBuilder.Append(Session("JVReportJobNum").ToString.PadLeft(6, "0") & "-" & HttpContext.Session("JVReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")

                    Else

                        SubjectStringBuilder.Append(Session("JVReportJobNum").ToString.PadLeft(6, "0") & "-" & HttpContext.Session("JVReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)

                    End If

            End Select
            'If HttpContext.Session("pagetype") = "po" Or Me.PageType() = "po" Then
            '    HasData = True
            '    Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            '    POHeader.Select_POHeader(Int32.Parse(Me.PO_RefId), "")
            '    sb1.Append("[Purchase Order] ")
            '    sb1.Append(Me.PO_RefId)
            '    sb1.Append(" for ")
            '    sb1.Append(POHeader.Vendor_Name.Trim())
            'End If
            'If HttpContext.Session("pagetype") = "jt" Or Me.PageType() = "jt" Then
            '    HasData = True
            '    sb1.Append("[Job Order]")
            '    If HttpContext.Request.QueryString("fromapp") IsNot Nothing AndAlso HttpContext.Request.QueryString("fromapp") = "jobsearchmul" Then
            '        sb1.Append(" for multiple Job/Components")
            '    Else
            '        sb1.Append(" for Job/Comp ")
            '        jc.GetJob(Me.JobNumber, Me.JobComponentNbr)
            '        If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then
            '            sb1.Append(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")
            '        Else
            '            sb1.Append(Me.JobNumber.ToString.PadLeft(6, "0") & "-" & Me.JobComponentNbr.ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)
            '        End If
            '    End If
            'End If
            'If HttpContext.Session("pagetype") = "js" Or Me.PageType() = "js" Then
            '    HasData = True
            '    jc.GetJob(Me.JobNumber, Me.JobComponentNbr)
            '    sb1.Append("[Job Specs]")
            '    sb1.Append(" for Job/Comp ")
            '    If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then
            '        sb1.Append(Session("JSReportJobNum").ToString.PadLeft(6, "0") & "-" & HttpContext.Session("JSReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")
            '    Else
            '        sb1.Append(Session("JSReportJobNum").ToString.PadLeft(6, "0") & "-" & HttpContext.Session("JSReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)
            '    End If

            'End If
            ''If CallingPage = "JobVersionPrint" Then

            ''    HasData = True

            ''    jc.GetJob(JobNumber, JobComponentNumber)

            ''    SubjectStringBuilder.Append("[")
            ''    SubjectStringBuilder.Append(Session("JVTemplateName").ToString.Replace("\", "").Replace("/", ""))
            ''    SubjectStringBuilder.Append(" - " & HttpContext.Session("JVReportVersion"))
            ''    SubjectStringBuilder.Append("] ")
            ''    SubjectStringBuilder.Append(jc.ClientDesc & " -")
            ''    SubjectStringBuilder.Append(" Job/Comp ")

            ''    If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then

            ''        SubjectStringBuilder.Append(Session("JVReportJobNum").ToString.PadLeft(6, "0") & "-" & HttpContext.Session("JVReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")

            ''    Else

            ''        SubjectStringBuilder.Append(Session("JVReportJobNum").ToString.PadLeft(6, "0") & "-" & HttpContext.Session("JVReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)

            ''    End If

            ''End If
            'If HttpContext.Session("pagetype") = "cb" Or Me.PageType() = "cb" Then
            '    HasData = True
            '    jc.GetJob(Me.JobNumber, Me.JobComponentNbr)
            '    sb1.Append("[Creative Brief]")
            '    sb1.Append(" for Job/Comp ")
            '    If jc.JobComponent.JOB_COMP_DESC.Length > 254 Then
            '        sb1.Append(Session("CBReportJobNum").ToString.PadLeft(6, "0") & "-" & HttpContext.Session("CBReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC.Substring(0, 254) & "...")
            '    Else
            '        sb1.Append(Session("CBReportJobNum").ToString.PadLeft(6, "0") & "-" & HttpContext.Session("CBReportJobCompNum").ToString.PadLeft(3, "0") & " - " & jc.JobComponent.JOB_COMP_DESC)
            '    End If
            'End If
            'If HttpContext.Session("pagetype") = "rfq" Or Me.PageType() = "rfq" Then
            '    HasData = True
            '    Dim oEstimating As New cEstimating(Session("ConnString"), HttpContext.Session("UserCode"))
            '    Dim dt As DataTable
            '    sb1.Append("[Request For Quote]")
            'End If

            ''sb1.Append("] ")

            'If (Session("pagetype") = "po" Or Me.PageType() = "po") Then
            '    sb1.Append(" Please see attachment.")
            'End If

            Dim str As String = SubjectStringBuilder.ToString()

            If str.Trim() <> "" And HasData = True Then

                DefaultSubject = SubjectStringBuilder.ToString()

            End If

            SubjectStringBuilder = Nothing

            Return DefaultSubject

        End Function
        Private Function OutputProofingFeedbackSummary(ByVal AlertID As Integer,
                                                       ByRef FileName As String,
                                                       ByRef ErrorMessage As String) As Boolean
            Dim Success As Boolean = True
            Dim Path As String = HttpContext.Request.PhysicalApplicationPath.Trim() & "TEMP\"
            Dim FullPathToDocument As String = String.Empty
            Dim FeedbackSummaryXtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                    If Alert IsNot Nothing Then

                        FileName = AdvantageFramework.StringUtilities.FileSystemFilenameAndPathSafe(Alert.Subject)

                        FeedbackSummaryXtraReport = AdvantageFramework.Reporting.Reports.CreateProofingFeedbackSummary(Me.SecuritySession,
                                                    AlertID,
                                                    0,
                                                    Me.IsClientPortalActive(),
                                                    0,
                                                    String.Empty)

                        If FeedbackSummaryXtraReport IsNot Nothing Then

                            FileName = String.Format("Feedback_Summary_{0}_{1}.pdf",
                                                     FileName,
                                                     AdvantageFramework.StringUtilities.GUID_Date())

                            AdvantageFramework.StringUtilities.FullErrorToString(Nothing)

                            Try

                                FullPathToDocument = Path & FileName
                                FeedbackSummaryXtraReport.ExportToPdf(FullPathToDocument)

                            Catch ex As Exception
                                Success = False
                                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                            End Try

                        End If

                    End If

                End Using

            Catch ex As Exception
                Success = False
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

            Return Success

        End Function
        'ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
        'aka Forms
        Private Function OutputReportFileJobVersion(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal FileType As Integer, ByVal TemplateName As String, ByVal ReportVersion As String,
                                                    ByVal OutputFormat As Integer,
                                                    ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try

                Dim StringBuilderFileName As New System.Text.StringBuilder 'build filename
                Dim StringBuilderTimeStamp As New System.Text.StringBuilder 'unique timestamp for filename..
                Dim StringBuilderReportName As New System.Text.StringBuilder
                Dim LegacyJobVersion As JobVersion = New JobVersion(DbContext.ConnectionString)
                Dim Description As String = String.Empty
                Dim ImagePath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"
                Dim ReportViewer As New popReportViewer

                Description = LegacyJobVersion.GetAgencyDesc()

                StringBuilderTimeStamp.Append(Now.Year.ToString)
                StringBuilderTimeStamp.Append(Now.Month.ToString)
                StringBuilderTimeStamp.Append(Now.Day.ToString)

                StringBuilderFileName.Append(Request.PhysicalApplicationPath.Trim())
                StringBuilderFileName.Append("TEMP\")

                StringBuilderFileName.Append(TemplateName.Replace("\", "").Replace("/", "") & "_")
                StringBuilderFileName.Append(ReportVersion)
                StringBuilderFileName.Append("_")
                'StringBuilderFileName.Append(JobNumber)
                'StringBuilderFileName.Append("_")
                'StringBuilderFileName.Append(JobComponentNumber)
                StringBuilderFileName.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                StringBuilderReportName.Append("jobver")

                If String.IsNullOrWhiteSpace(OutputFormat) = True Then

                    FileType = 1

                Else

                    FileType = OutputFormat

                End If

                ReportViewer.renderDoc(StringBuilderFileName.ToString(), StringBuilderReportName.ToString(), "", "", "", "", "", FileType, ImagePath)

                OutputFileName = StringBuilderFileName.ToString()

                If OutputFileName.EndsWith(".pdf") = False AndAlso FileType = 1 Then

                    OutputFileName &= ".pdf"

                ElseIf OutputFileName.EndsWith(".xls") = False AndAlso FileType = 2 Then

                    OutputFileName &= ".xls"

                ElseIf OutputFileName.EndsWith(".txt") = False AndAlso FileType = 4 Then

                    OutputFileName &= ".txt"

                ElseIf OutputFileName.EndsWith(".rtf") = False AndAlso FileType = 5 Then

                    OutputFileName &= ".rtf"

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFilePS(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                            ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim StrFilePrefix As String = Me.PathToTempFolder()
                Dim StrFileName As String = ""
                Dim r As cReports = New cReports(Session("ConnString"))
                Dim StrFileType As String = ".pdf"
                StrFileName = "Project_Schedule_" & JobNumber.ToString() & "_" & JobComponentNumber.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType

                Dim rpt As New popReportViewer
                Try
                    Dim ThisOptions As String = JobNumber.ToString() & "|" & JobComponentNumber.ToString() & "|" & HttpContext.Request.QueryString("hours") & "|" &
                        HttpContext.Request.QueryString("ms") & "|" & HttpContext.Request.QueryString("due") & "|" & HttpContext.Request.QueryString("sort") & "|" & HttpContext.Request.QueryString("completed")
                    If HttpContext.Request.QueryString("rpt") = "duedate" Then
                        rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJobDueDate", "", "", "", "", "", 1, "", ThisOptions)
                    Else
                        rpt.renderDoc(StrFilePrefix & StrFileName, "TrafficDetailByJob", "", "", "", "", "", 1, "", ThisOptions)
                    End If
                Catch ex As Exception
                    ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                    OutputFileName = ""
                End Try

                OutputFileName = StrFilePrefix & StrFileName

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFileJT(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal FileType As Integer, ByVal Report As String,
                                            ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim sb1 As New System.Text.StringBuilder 'build filename
                Dim sbReportName As New System.Text.StringBuilder

                sb1.Append(Request.PhysicalApplicationPath.Trim())
                sb1.Append("TEMP\")

                sb1.Append("JobOrder_")
                If JobNumber > 0 Then sb1.Append(JobNumber)
                If JobComponentNumber > 0 Then

                    sb1.Append("_")
                    sb1.Append(JobComponentNumber)

                End If
                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                sbReportName.Append(Report)

                Dim rpt As New popReportViewer

                Dim imgPath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"
                rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", FileType, imgPath)
                Dim str As String = sb1.ToString()
                If str.IndexOf(".pdf") = -1 Then
                    str &= ".pdf"
                End If
                OutputFileName = str
            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFileJS(ByVal FileType As Integer,
                                            ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim sb1 As New System.Text.StringBuilder 'build filename
                Dim sbTime As New System.Text.StringBuilder 'unique timestamp for filename..
                Dim sbReportName As New System.Text.StringBuilder

                sbTime.Append(Now.Year.ToString)
                sbTime.Append(Now.Month.ToString)
                sbTime.Append(Now.Day.ToString)

                sb1.Append(Request.PhysicalApplicationPath.Trim())
                sb1.Append("TEMP\")


                sb1.Append("Specification_")
                sb1.Append(Session("JSReportJobNum"))
                sb1.Append("_")
                sb1.Append(Session("JSReportJobCompNum"))
                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                sbReportName.Append("jobspec")

                Dim rpt As New popReportViewer

                Dim imgPath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"
                rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", FileType, imgPath)
                Dim str As String = sb1.ToString()
                If str.IndexOf(".pdf") = -1 Then
                    str &= ".pdf"
                End If
                OutputFileName = str
            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFileJSAllVers(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short,
                                                   ByVal FileType As Integer, ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim sb1 As New System.Text.StringBuilder 'build filename
                Dim sbReportName As New System.Text.StringBuilder

                sb1.Append(Request.PhysicalApplicationPath.Trim())
                sb1.Append("TEMP\")

                sb1.Append("Specification_")
                sb1.Append(JobNumber)
                sb1.Append("_")
                sb1.Append(JobComponentNumber)
                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))


                sbReportName.Append("jobspecs")

                Dim rpt As New popReportViewer
                Dim imgPath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"
                rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", FileType, imgPath)
                Dim str As String = sb1.ToString()
                If str.IndexOf(".pdf") = -1 Then
                    str &= ".pdf"
                End If
                OutputFileName = str
            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFileJVAllVers(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal ReportTitle As String,
                                                   ByVal FileType As Integer, ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim sb1 As New System.Text.StringBuilder 'build filename
                Dim sbReportName As New System.Text.StringBuilder

                sb1.Append(Request.PhysicalApplicationPath.Trim())
                sb1.Append("TEMP\")

                sb1.Append(Session("JVReportTitle").ToString.Replace("\", "").Replace("/", "") & "_")
                sb1.Append(JobNumber)
                sb1.Append("_")
                sb1.Append(JobComponentNumber)
                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                sbReportName.Append("jobversions")

                Dim rpt As New popReportViewer

                Dim imgPath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"
                rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", FileType, imgPath)
                Dim str As String = sb1.ToString()
                If str.IndexOf(".pdf") = -1 Then
                    str &= ".pdf"
                End If
                OutputFileName = str
            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFileCB(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal FileType As Integer,
                                            ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim sb1 As New System.Text.StringBuilder 'build filename
                Dim sbReportName As New System.Text.StringBuilder

                If JobNumber > 0 Then
                    HttpContext.Session("CBReportJobNum") = JobNumber.ToString.PadLeft(6, "0")
                    HttpContext.Session("JobOrderFormJobNum") = JobNumber.ToString.PadLeft(6, "0")
                End If
                If JobComponentNumber > 0 Then
                    HttpContext.Session("CBReportJobCompNum") = JobComponentNumber.ToString.PadLeft(3, "0")
                    HttpContext.Session("JobOrderFormJobCompNum") = JobComponentNumber.ToString.PadLeft(3, "0")
                End If
                sb1.Append(Request.PhysicalApplicationPath.Trim())
                sb1.Append("TEMP\")

                sb1.Append("CreativeBrief_")
                If HttpContext.Session("pagetype") = "cb" Then
                    sb1.Append(Session("CBReportJobNum"))
                    sb1.Append("_")
                    sb1.Append(Session("CBReportJobCompNum"))
                Else
                    sb1.Append(Session("JobOrderFormJobNum"))
                    sb1.Append("_")
                    sb1.Append(Session("JobOrderFormJobCompNum"))
                End If

                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                sbReportName.Append("CreativeBrief")

                Dim rpt As New popReportViewer

                Dim imgPath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"
                rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", FileType, imgPath)
                Dim str As String = sb1.ToString()
                If str.IndexOf(".pdf") = -1 Then
                    str &= ".pdf"
                End If
                OutputFileName = str
            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFileATB(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal ATBNumber As Integer, ByVal ATBRevisionNumber As Integer,
                                             ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty


            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim DataSource As Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevision) = Nothing
            Dim MediaATBRevision As AdvantageFramework.Database.Entities.MediaATBRevision = Nothing
            Dim FileName As String = Nothing
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim FilePrefix As String = ""
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            Try

                FilePrefix = HttpContext.Request.PhysicalApplicationPath.Trim() & "TEMP\"

                If ATBNumber > 0 AndAlso ATBRevisionNumber > -1 Then

                    MediaATBRevision = AdvantageFramework.Database.Procedures.MediaATBRevision.LoadByATBNumberAndRevisionNumber(DbContext, ATBNumber, ATBRevisionNumber)

                    If MediaATBRevision IsNot Nothing Then

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.MediaATBRevision)

                        DataSource.Add(MediaATBRevision)

                        ParameterDictionary("DataSource") = DataSource

                        Try

                            AppVar = (From Entity In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, DbContext.UserCode, "ATBPrint")
                                      Where Entity.Name = "DefaultReportType"
                                      Select Entity).SingleOrDefault

                        Catch ex As Exception
                            AppVar = Nothing
                        End Try

                        ReportType = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMedia

                        If AppVar IsNot Nothing Then

                            If AppVar.Value = "Report" Then

                                ReportType = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMedia

                            ElseIf AppVar.Value = "Form" Then

                                ReportType = AdvantageFramework.Reporting.ReportTypes.AuthorizationToBuyDigitalMediaForm

                            End If

                        End If

                        XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(Me.SecuritySession, ReportType, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        If XtraReport IsNot Nothing Then

                            MemoryStream = New System.IO.MemoryStream

                            FileName = FilePrefix

                            FileName &= "ATB_" & AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.ATBNumber.ToString, 6, "0", True) & "_" &
                                AdvantageFramework.StringUtilities.PadWithCharacter(MediaATBRevision.RevisionNumber.ToString, 3, "0", True) & "_" & cEmployee.TimeZoneToday.ToString("yyyyMd") & ".PDF"

                            XtraReport.CreateDocument()

                            XtraReport.ExportToPdf(MemoryStream)

                            Using FileStream = New System.IO.FileStream(FileName, FileMode.Create, FileAccess.ReadWrite)

                                MemoryStream.WriteTo(FileStream)

                            End Using

                        End If

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            OutputFileName = FileName

            Return OutputFileName

        End Function
        Private Function OutputReportFileCMP(ByVal FileType As Integer,
                                             ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim ThisCmpIdentifier As Integer = 0
                Try
                    If Not HttpContext.Request.QueryString("CmpCode") Is Nothing Then
                        ThisCmpIdentifier = CType(Request.QueryString("CmpCode"), Integer)
                    End If
                Catch ex As Exception
                    ThisCmpIdentifier = 0
                End Try
                If ThisCmpIdentifier = 0 Then
                    Try
                        If Not HttpContext.Request.QueryString("cmp") Is Nothing Then
                            ThisCmpIdentifier = CType(Request.QueryString("cmp"), Integer)
                        End If
                    Catch ex As Exception
                        ThisCmpIdentifier = 0
                    End Try
                End If
                If ThisCmpIdentifier > 0 Then
                    Dim sb1 As New System.Text.StringBuilder 'build filename
                    Dim sbReportName As New System.Text.StringBuilder
                    Dim cCMP As New cCampaign(Session("ConnString"), ThisCmpIdentifier)

                    sb1.Append(Request.PhysicalApplicationPath.Trim())
                    sb1.Append("TEMP\")

                    sb1.Append("Campaign_")
                    sb1.Append(cCMP.CMP_CODE)
                    sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                    sbReportName.Append("Campaign")

                    Dim rpt As New popReportViewer

                    Try
                        Dim imgPath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"
                        rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), ThisCmpIdentifier, "", "", "", "", FileType, imgPath)
                        Dim str As String = sb1.ToString()
                        If str.IndexOf(".pdf") = -1 Then
                            str &= ".pdf"
                        End If
                        OutputFileName = str
                    Catch ex As Exception
                        ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                        OutputFileName = ""
                    End Try
                End If
            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFileEST(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                             ByVal EstimateNumber As Integer, ByVal EstimateComponentNumber As Short, ByVal FileType As Integer,
                                             ByVal FormatType As String, ByVal Combine As Boolean, ByVal ReportType As String, ByVal Options As String,
                                             ByRef ErrorMessage As String, ByVal UseSignature As Boolean, ByVal comp As Integer,
                                             ByVal comps As String, ByVal quotes As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try

                Dim sb1 As New System.Text.StringBuilder 'build filename
                Dim sbReportName As New System.Text.StringBuilder
                Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
                Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing
                Dim EstimateFormat As AdvantageFramework.Estimate.Printing.ReportFormats = AdvantageFramework.Estimate.Printing.ReportFormats.OneQuotePerPage
                Dim EstimatePrintingSettings As AdvantageFramework.Database.Entities.EstimatePrintingSetting = Nothing
                Dim EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
                Dim EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting = Nothing
                Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
                Dim DefaultFileName As String
                Dim Files As Generic.List(Of String) = Nothing
                Dim CurrentCultureCode As String = LoGlo.UserCultureGet()

                Dim estType As String = ""

                If FormatType <> "" Then
                    'For Each EstimateQuote In EstimateQuotes

                    estType = FormatType

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)(String.Format("EXEC [dbo].[advsp_estimate_printing_quotes] {0}, {1}",
                                                                                                                                                  EstimateNumber, EstimateComponentNumber)).ToList
                        EstimateQuote = EstimateQuotes(0)
                        EstimatePrintingSetting = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWebvantage(DbContext, DataContext, estType, EstimateQuote.ClientCode, EstimateQuote.CDP,
                                                                                                                              Me.SecuritySession.UserCode).FirstOrDefault()
                    End Using

                    If Combine = True Then

                        Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.SecuritySession, EstimateQuote, EstimatePrintingSetting, Nothing, comps,
                                                                                     quotes, HttpContext.Session("EstimatingQteDescs"), 2, Nothing, CurrentCultureCode)
                    Else

                        Report = AdvantageFramework.Reporting.Reports.CreateEstimate(Me.SecuritySession, EstimateQuote, EstimatePrintingSetting, Nothing, comps,
                                                                                     quotes, HttpContext.Session("EstimatingQteDescs" & EstimateComponentNumber), 0, Nothing, CurrentCultureCode)
                    End If

                    If Report IsNot Nothing Then

                        DefaultFileName = "Estimate_" & Format(EstimateQuote.EstimateNumber, "000000#") & "_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) ' & "_" & Format(EstimateQuote.QuoteNumber, "00#")

                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                        Report.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = HttpContext.Request.PhysicalApplicationPath.Trim() & "TEMP\"
                        Report.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        Report.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        If FileType = 1 Then

                            Report.ExportToPdf(Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf")

                        ElseIf FileType = 5 Then

                            Report.ExportToRtf(Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".rtf")

                        Else

                            Report.ExportToPdf(Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf")

                        End If

                    End If
                    If FileType = 1 Then

                        Return HttpContext.Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf"

                    ElseIf FileType = 5 Then

                        Return HttpContext.Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".rtf"

                    Else

                        Return HttpContext.Request.PhysicalApplicationPath.Trim() & "TEMP\" & DefaultFileName & ".pdf"

                    End If

                Else

                    sb1.Append(Request.PhysicalApplicationPath.Trim())
                    sb1.Append("TEMP\")

                    sb1.Append("Estimate_")
                    sb1.Append(EstimateNumber)
                    If comp <> 0 Then
                        sb1.Append("_")
                        sb1.Append(comp)
                    End If
                    sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                    sbReportName.Append(ReportType)

                    HttpContext.Session("EstimatingAddressOption") = Options

                    If ReportType.Contains("SS1") = True Or ReportType.Contains("008") = True Or
                        ReportType.Contains("009") = True Or ReportType.Contains("QUR") = True Or ReportType.Contains("Mars") = True Then

                        HttpContext.Session("EstimatingCombine") = "0"

                    Else

                        If Combine = True Then

                            HttpContext.Session("EstimatingCombine") = 1

                        Else

                            HttpContext.Session("EstimatingCombine") = 0

                        End If

                    End If

                    HttpContext.Session("EstimatingEstNum") = EstimateNumber

                    If comp = 0 Then

                        HttpContext.Session("EstimatingEstComp") = EstimateComponentNumber

                    Else

                        HttpContext.Session("EstimatingEstComp") = comp

                    End If
                    If quotes = "" Then

                        HttpContext.Session("EstimatingQuotes") = quotes

                    Else

                        HttpContext.Session("EstimatingQuotes") = quotes

                    End If

                    HttpContext.Session("EstimatingComps") = comp
                    HttpContext.Session("EstimatingUseEmpSig") = UseSignature

                    Dim rpt As New popReportViewer
                    Dim imgPath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"

                    rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", FileType, imgPath)

                    Dim str As String = sb1.ToString()
                    If str.IndexOf(".pdf") = -1 Then

                        str &= ".pdf"

                    End If

                    OutputFileName = str

                End If

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFileRFQ(ByVal FileType As Integer,
                                             ByRef ErrorMessage As String,
                                             Optional ByVal comp As Integer = 0, Optional ByVal quotes As String = "") As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim sb1 As New System.Text.StringBuilder 'build filename
                Dim sbReportName As New System.Text.StringBuilder

                sb1.Append(Request.PhysicalApplicationPath.Trim())
                sb1.Append("TEMP\")

                sb1.Append("RFQ_")
                sb1.Append(Request.QueryString("EstNum"))
                If comp <> 0 Then
                    sb1.Append("_")
                    sb1.Append(comp)
                End If
                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))

                sbReportName.Append(Request.QueryString("Report"))

                HttpContext.Session("VendorReqEstNum") = HttpContext.Request.QueryString("EstNum")
                HttpContext.Session("VendorReqEstComp") = HttpContext.Request.QueryString("EstCompNum")
                HttpContext.Session("VendorReqVenQte") = HttpContext.Request.QueryString("VendorQteNbr")
                HttpContext.Session("VendorReqVenCode") = HttpContext.Request.QueryString("VendorCode")

                Dim rpt As New popReportViewer

                Dim imgPath As String = HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif"
                rpt.renderDoc(sb1.ToString(), sbReportName.ToString(), "", "", "", "", "", FileType, imgPath)
                Dim str As String = sb1.ToString()
                If str.IndexOf(".pdf") = -1 Then
                    str &= ".pdf"
                End If
                OutputFileName = str
            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFilePO(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                            ByVal PO_RefId As Integer, ByVal PrintOptions As String, ByVal Report As String,
                                            ByRef ErrorMessage As String) As String


            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim FileName As String = "PURCHASE_ORDER_" & AdvantageFramework.StringUtilities.PadWithCharacter(Int32.Parse(PO_RefId).ToString, 8, "0", True, False) & ".pdf"
            Dim Path As String = HttpContext.Request.PhysicalApplicationPath.Trim() & "TEMP\" & FileName
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing
            Dim FooterAboveSignature As Boolean = True
            Dim UsePrintedDate As Date? = Nothing
            Dim IsActiveReport As Boolean = False
            Dim ReportFormat As String = Nothing
            Dim PrintOptionsForActiveReports As String = Nothing
            Dim DataSource As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrder) = Nothing
            Dim popReportViewer As Webvantage.popReportViewer = Nothing
            Dim Saved As Boolean = False

            Try

                PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, DbContext.UserCode)

                If PurchaseOrderPrintDefault IsNot Nothing Then

                    ReportFormat = PurchaseOrderPrintDefault.ReportFormat

                    If Not String.IsNullOrWhiteSpace(PurchaseOrderPrintDefault.LocationID) Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(DbContext.ConnectionString, DbContext.UserCode)

                            Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, PurchaseOrderPrintDefault.LocationID)

                        End Using

                    End If

                End If

                If Not [String].IsNullOrWhiteSpace(Report) Then

                    ReportFormat = Report

                End If

                If String.IsNullOrWhiteSpace(ReportFormat) Then

                    ReportFormat = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.StandardFormat).Code

                End If

                If Not AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.PurchaseOrderReports)).Select(Function(EnumObject) EnumObject.Code).ToArray.Contains(ReportFormat) Then

                    IsActiveReport = True

                End If

                If IsActiveReport Then

                    If PurchaseOrderPrintDefault IsNot Nothing Then

                        PrintOptionsForActiveReports = String.Join(";", {PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0),
                                                                         PurchaseOrderPrintDefault.UseUserSignature.GetValueOrDefault(0)}.ToArray)

                    End If

                    If Location IsNot Nothing Then

                        HttpContext.Session("LocationOverride") = Location
                        HttpContext.Session("POPrintLocationID") = Location.ID
                        HttpContext.Session("POPrintLocationPath") = Location.LogoPath
                        HttpContext.Session("POPrintLocationName") = Location.Name

                    Else

                        HttpContext.Session("LocationOverride") = Nothing
                        HttpContext.Session("POPrintLocationID") = "None"
                        HttpContext.Session("POPrintLocationPath") = ""
                        HttpContext.Session("POPrintLocationName") = ""

                    End If

                    popReportViewer = New popReportViewer

                    Saved = popReportViewer.renderDoc(Path & FileName, ReportFormat, PO_RefId, "", "", "", "", 1, HttpContext.Request.PhysicalApplicationPath & "Images\logo_print.gif", PrintOptionsForActiveReports)

                Else

                    ParameterDictionary = New Generic.Dictionary(Of String, Object)
                    DataSource = (From Item In AdvantageFramework.Database.Procedures.PurchaseOrder.Load(DbContext)
                                  Where Item.Number = PO_RefId
                                  Select Item).ToList

                    ParameterDictionary("DataSource") = DataSource

                    If PurchaseOrderPrintDefault IsNot Nothing Then

                        ParameterDictionary("PrintDefaults") = PurchaseOrderPrintDefault

                    End If

                    ParameterDictionary("DefaultLocation") = Location

                    If ReportFormat = AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.FooterAboveSignature).Code Then

                        ParameterDictionary("FooterAboveSignature") = True

                    End If

                    If CBool(PurchaseOrderPrintDefault.DateToPrint.GetValueOrDefault(0)) Then

                        ParameterDictionary("UsePrintedDate") = System.DateTime.Now

                    End If

                    XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(Me.SecuritySession, AdvantageFramework.Reporting.ReportTypes.PurchaseOrderReport,
                                                                                   ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    If XtraReport IsNot Nothing Then

                        Try

                            XtraReport.ExportToPdf(Path)

                            Saved = True

                        Catch ex As Exception

                        End Try

                    End If

                End If

                If Saved Then

                    Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
                    PO.UpdatePOPrint(1, PO_RefId, 1)

                End If

                OutputFileName = Path

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function
        Private Function OutputReportFilePSExcel(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByVal ClCode As String, ByVal DivCode As String, ByVal ProdCode As String,
                                                 ByVal JobNumber As Integer, ByVal JobComponentNumber As Short, ByVal EmpCode As String,
                                                 ByVal ManagerCode As String, ByVal TaskCode As String, ByVal AccountExecCode As String,
                                                 ByVal RoleCode As String, ByVal CutOffDate As Date, ByVal IncludeCompletedTasks As Boolean, IncludeOnlyPendingTasks As Boolean,
                                                 ByVal ExcludeProjectedTasks As Boolean, ByVal IncludeCompletedSchedules As Boolean, ByVal CampaignCode As String,
                                                 ByVal TaskPhaseFilter As String, ByVal MilestonesOnly As Boolean, ByVal TrafficStatusCode As String, ByVal ExcludeTaskComment As Boolean,
                                                 ByRef ErrorMessage As String) As String

            Dim OutputFileName As String = String.Empty
            ErrorMessage = String.Empty

            Try
                Dim StrFilePrefix As String = Me.PathToTempFolder()
                Dim StrFileName As String = ""
                Dim r As cReports = New cReports(Session("ConnString"))
                Dim StrFileType As String = ".xls"
                StrFileName = "Project_Schedule_" & JobNumber.ToString() & "_" & JobComponentNumber.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, True, True) & StrFileType

                Dim fs As FileStream = System.IO.File.OpenWrite(StrFilePrefix & StrFileName)
                Dim ms As MemoryStream
                Dim gl As New Ganttline()
                Dim tsCal As New TrafficSchedule_Calendar_Render()
                Dim ppe As New PertPageExcel()
                Dim enc As New UTF8Encoding
                Dim arrBytData() As Byte
                Dim Workbook As Aspose.Cells.Workbook = Nothing

                If HttpContext.Request.QueryString("form") = "calx" Then
                    Workbook = tsCal.RenderProjectCalendarReportWorkbook(JobNumber, JobComponentNumber, HttpContext.Request.QueryString("ms"), HttpContext.Request.QueryString("completed"))
                    'arrBytData = System.Text.Encoding.ASCII.GetBytes(tsCal.RenderProjectCalendarReport2Excel(Me.JobNumber, Me.JobComponentNbr, HttpContext.Request.QueryString("ms")))
                    'ms = New MemoryStream(arrBytData)
                ElseIf HttpContext.Request.QueryString("form") = "mulx" Then
                    arrBytData = System.Text.Encoding.ASCII.GetBytes(ppe.RendorMultiJobPSExcel(ClCode, DivCode, ProdCode, JobNumber, JobComponentNumber,
                                                                                               EmpCode, ManagerCode, TaskCode, AccountExecCode, RoleCode, CutOffDate,
                                                                                               IncludeCompletedTasks, IncludeOnlyPendingTasks, ExcludeProjectedTasks,
                                                                                               IncludeCompletedSchedules, CampaignCode, TaskPhaseFilter, MilestonesOnly, TrafficStatusCode))
                    ms = New MemoryStream(arrBytData)
                ElseIf HttpContext.Request.QueryString("form") = "day" Then
                    Workbook = gl.RenderProjectTimelineReportWorkbook(Me.SecuritySession.ConnectionString, JobNumber, JobComponentNumber, MilestonesOnly, ExcludeTaskComment, True, HttpContext.Request.QueryString("completed"))
                    'arrBytData = System.Text.Encoding.ASCII.GetBytes(gl.RenderProjectTimelineReportExcelByDay(Me.JobNumber, Me.JobComponentNbr, HttpContext.Request.QueryString("ms"), Me.SecuritySession.ConnectionString, Me.ExcludeTaskComment))
                    'ms = New MemoryStream(arrBytData)
                Else
                    Workbook = gl.RenderProjectTimelineReportWorkbook(Me.SecuritySession.ConnectionString, JobNumber, JobComponentNumber, MilestonesOnly, ExcludeTaskComment, False, HttpContext.Request.QueryString("completed"))
                    'arrBytData = System.Text.Encoding.ASCII.GetBytes(gl.RenderProjectTimelineReportExcel(Me.JobNumber, Me.JobComponentNbr, HttpContext.Request.QueryString("ms"), Me.SecuritySession.ConnectionString, Me.ExcludeTaskComment))
                    'ms = New MemoryStream(arrBytData)
                End If

                If Workbook IsNot Nothing Then

                    ms = New MemoryStream()
                    Workbook.FileName = StrFileName
                    Workbook.Save(ms, (New Aspose.Cells.XlsSaveOptions(Aspose.Cells.SaveFormat.Excel97To2003)))

                End If

                ms.WriteTo(fs)
                ms.Flush()
                ms.Close()
                fs.Close()

                OutputFileName = StrFilePrefix & StrFileName

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                OutputFileName = ""
            End Try

            Return OutputFileName

        End Function

#End Region
        'NS: commmented out, moved to InboxControlller
        'Private Function GetUserBackgroundColor(UserCode As String) As String

        '    'Objects
        '    Dim BackgroundColor As String = Nothing

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

        '        Try

        '            BackgroundColor = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 VARIABLE_VALUE FROM APP_VARS WHERE USERID = '{0}' AND APPLICATION = 'MY_SETTINGS' AND VARIABLE_NAME = 'SMPL_BG_COLOR';", UserCode)).SingleOrDefault

        '        Catch ex As Exception

        '            BackgroundColor = String.Empty

        '        End Try

        '    End Using

        '    Return BackgroundColor

        'End Function

        Private Function FileTypeIsValid(ByVal File As HttpPostedFileBase) As Boolean

            Dim IsValid As Boolean = True
            Dim BlackList As Generic.List(Of String)

            BlackList = AdvantageFramework.DocumentManager.BlackListedFileTypes

            If BlackList.Contains(Path.GetExtension(File.FileName)) = True Then

                IsValid = False

            End If

            Return IsValid

        End Function

        Private Sub LoadAlertSecurity(ByRef AlertView As AdvantageFramework.ViewModels.Desktop.AlertView, ByVal IsWorkItem As Boolean, ByVal IsTask As Boolean)

            Try

                Dim AlertSecurity As AdvantageFramework.ViewModels.Desktop.AlertSecurityViewModel = Nothing
                Dim UseScheduleSecurity As Boolean = False
                Dim KeyName As String = "AlSec"

                If IsWorkItem = True AndAlso IsTask = True Then

                    UseScheduleSecurity = True
                    KeyName = "PrjSec"

                End If

                If HttpContext.Session(KeyName) IsNot Nothing Then

                    AlertSecurity = CType(HttpContext.Session(KeyName), AdvantageFramework.ViewModels.Desktop.AlertSecurityViewModel)

                Else

                    Dim SecurityModule As AdvantageFramework.Security.Modules = AdvantageFramework.Security.Methods.Modules.Desktop_Alerts

                    AlertSecurity = New AdvantageFramework.ViewModels.Desktop.AlertSecurityViewModel

                    If UseScheduleSecurity = True Then

                        SecurityModule = AdvantageFramework.Security.Methods.Modules.ProjectManagement_ProjectSchedule

                    End If

                    AlertSecurity.CanAdd = AdvantageFramework.Security.CanUserAddInModule(Me.SecuritySession, SecurityModule)
                    If UseScheduleSecurity = False Then

                        AlertSecurity.CanUpdate = AdvantageFramework.Security.CanUserUpdateInModule(Me.SecuritySession, SecurityModule)

                    Else

                        AlertSecurity.CanUpdate = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowTaskEdit)

                    End If
                    AlertSecurity.CanPrint = AdvantageFramework.Security.CanUserPrintInModule(Me.SecuritySession, SecurityModule)
                    AlertSecurity.CanCustom1 = AdvantageFramework.Security.CanUserCustom1InModule(Me.SecuritySession, SecurityModule)
                    AlertSecurity.CanCustom2 = AdvantageFramework.Security.CanUserCustom2InModule(Me.SecuritySession, SecurityModule)

                    HttpContext.Session(KeyName) = AlertSecurity

                End If

                If AlertSecurity IsNot Nothing Then

                    AlertView.CanAdd = AlertSecurity.CanAdd
                    AlertView.CanUpdate = AlertSecurity.CanUpdate
                    AlertView.CanPrint = AlertSecurity.CanPrint
                    AlertView.CanCustom1 = AlertSecurity.CanCustom1
                    AlertView.CanCustom1 = AlertSecurity.CanCustom1

                End If

            Catch ex As Exception
            End Try

        End Sub
        Private Function DownloadFeedbackSummaryBytesToTemp(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                            ByVal ByteFile() As Byte,
                                                            ByRef FileName As String,
                                                            ByRef Key As String) As Boolean

            'objects
            Dim Downloaded As Boolean = Nothing
            Dim FileStream As System.IO.FileStream = Nothing
            Dim FileSystemFile As String = Nothing
            Dim File As String = Nothing
            Dim BinaryReader As System.IO.BinaryReader = Nothing
            Dim FileWriter As System.IO.FileStream = Nothing
            Dim Counter As Integer = 0
            Dim FileExtension As String = "pdf"
            Dim TempDirectory As String = Me.PathToTempFolder()

            Try

                If ByteFile IsNot Nothing AndAlso ByteFile.Length > 0 Then

                    FileName = TempDirectory & FileName

                    Try

                        FileWriter = New System.IO.FileStream(FileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Write)
                        FileWriter.Write(ByteFile, 0, ByteFile.Length)

                        Downloaded = True

                        Key = AdvantageFramework.Security.Encryption.Encrypt(FileName)

                    Catch ex As Exception
                        Downloaded = False
                    End Try
                    If FileWriter IsNot Nothing Then

                        FileWriter.Close()

                    End If

                End If

            Catch ex As Exception
                Downloaded = False
            Finally
                DownloadFeedbackSummaryBytesToTemp = Downloaded
            End Try

            Return DownloadFeedbackSummaryBytesToTemp

        End Function
        Private Sub ApplyDateWorkaround(ByRef Alert As AdvantageFramework.DTO.Desktop.Alert,
                                        ByVal StartDate As String,
                                        ByVal DueDate As String,
                                        ByVal CompletedDate As String)

            If String.IsNullOrWhiteSpace(StartDate) = False AndAlso IsDate(StartDate) = True Then

                Alert.StartDate = CType(CType(StartDate, Date).ToShortDateString, Date)

            End If
            If String.IsNullOrWhiteSpace(DueDate) = False AndAlso IsDate(DueDate) = True Then

                Alert.DueDate = CType(CType(DueDate, Date).ToShortDateString, Date)

            End If
            If String.IsNullOrWhiteSpace(CompletedDate) = False AndAlso IsDate(CompletedDate) = True Then

                Alert.CompletedDate = CType(CType(CompletedDate, Date).ToShortDateString, Date)

            End If

        End Sub
        Private Sub RefreshAfterAlertAction(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal SprintID As Integer?)
            Try

                Try

                    If SprintID Is Nothing OrElse SprintID = 0 Then

                        SprintID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT SD.SPRINT_HDR_ID FROM SPRINT_DTL SD WHERE SD.ALERT_ID = {0};", AlertID)).SingleOrDefault

                    End If

                Catch ex As Exception
                    SprintID = 0
                End Try

                Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, SprintID, Me.SecuritySession.UserCode, "", False)
                Webvantage.SignalR.Classes.NotificationHub.NotifyRecipients(DbContext, AlertID)

            Catch ex As Exception
            End Try
        End Sub
        Private Function GetAgencyAllowProofHQSetting() As Boolean

            Dim AllowProofHQ As Boolean = False

            Try

                If Session(AgencyAllowProofHQSessionKey) Is Nothing Then

                    Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        If Agency IsNot Nothing AndAlso Agency.AllowProofHQ IsNot Nothing Then

                            AllowProofHQ = Agency.AllowProofHQ

                        End If

                    End Using

                    Session(AgencyAllowProofHQSessionKey) = AllowProofHQ

                Else

                    AllowProofHQ = Session(AgencyAllowProofHQSessionKey)

                End If

            Catch ex As Exception
                AllowProofHQ = False
            End Try

            Return AllowProofHQ

        End Function
        Private Sub PushAlertRecipientsChange(ByVal AlertID As Integer, ByVal RemovedRecipientEmployeeCode As String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim RemovedUserCode As String = String.Empty

                Try

                    If String.IsNullOrWhiteSpace(RemovedRecipientEmployeeCode) = False Then

                        RemovedUserCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 USER_CODE FROM SEC_USER WHERE EMP_CODE = '{0}' AND NOT WEB_ID IS NULL ORDER BY SEC_USER_ID DESC;", RemovedRecipientEmployeeCode)).SingleOrDefault

                    End If

                Catch ex As Exception
                    RemovedUserCode = String.Empty
                End Try

                Webvantage.SignalR.Classes.NotificationHub.RefreshAlertAssigneesAndCCs(DbContext, AlertID, Me.SecuritySession.UserCode, RemovedUserCode, False)

            End Using

        End Sub
        Private Function GetAgencyDefaultToRoutedOnNewAssignmentSetting() As Boolean

            Dim DefaultToRouted As Boolean = False

            If Session(AgencyDefaultToRoutedSessionKey) Is Nothing Then

                Dim setting As AdvantageFramework.Database.Entities.Setting = Nothing
                Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, "ASSIGN_TYPE_DEFAULT")

                    If setting IsNot Nothing Then

                        DefaultToRouted = setting.Value

                    End If

                End Using

                'Session(AgencyDefaultToRoutedSessionKey) = DefaultToRouted

            Else

                DefaultToRouted = Session(AgencyDefaultToRoutedSessionKey)

            End If

            Return DefaultToRouted

        End Function
        Private Sub LoadDocumentRepositoryLimits(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                 ByRef RepositorySizeLimit As Long,
                                                 ByRef RespositoryFileSizeLimit As Long,
                                                 ByRef LimitText As String)

            If Session(CheckRepositoryLimitRepositoryFileSizeLimitSessionKey) Is Nothing Then

                AdvantageFramework.FileSystem.GetDocumentRepositoryMaxFileSizeLimit(DbContext, RespositoryFileSizeLimit, LimitText)
                RepositorySizeLimit = AdvantageFramework.FileSystem.GetDocumentRepositoryLimit(DbContext)

                Session(CheckRepositoryLimitRepositorySizeLimitSessionKey) = RepositorySizeLimit
                Session(CheckRepositoryLimitRepositoryFileSizeLimitSessionKey) = RespositoryFileSizeLimit
                Session(CheckRepositoryLimitRepositoryLimitTextSessionKey) = LimitText

            Else

                RepositorySizeLimit = Session(CheckRepositoryLimitRepositorySizeLimitSessionKey)
                RespositoryFileSizeLimit = Session(CheckRepositoryLimitRepositoryFileSizeLimitSessionKey)
                LimitText = Session(CheckRepositoryLimitRepositoryLimitTextSessionKey)

            End If

        End Sub
        Private Function CheckRepositoryLimit(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim ValidRepositoryLimit As Boolean = True
            Dim DocumentRepositoryLimit As Long = -1
            Dim DocumentRepositoryFileSizeLimit As Long = -1
            Dim DocumentRepositorySize As Long = 0
            Dim LimitText As String = String.Empty

            Try

                Me.LoadDocumentRepositoryLimits(DbContext, DocumentRepositoryLimit, DocumentRepositoryFileSizeLimit, LimitText)

                If DocumentRepositoryLimit > 0 Then

                    DocumentRepositorySize = AdvantageFramework.FileSystem.GetDocumentRepositorySize(DbContext)

                    If (DocumentRepositoryLimit - DocumentRepositorySize) < 1 Then

                        ErrorMessage = "There is no more space left in the repository. File(s) will not be uploaded! Please contact an administrator."
                        ValidRepositoryLimit = False

                    End If

                End If

            Catch ex As Exception
            End Try

            CheckRepositoryLimit = ValidRepositoryLimit

        End Function
        Private Function AllowRepositoryUpload(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByRef RepositorySizeLimit As Long,
                                               ByRef RepositoryFileSizeLimit As Long,
                                               ByRef RepositoryLimitText As String,
                                               ByRef LimitRepository As Boolean) As Boolean

            Dim AllowUpload As Boolean = True

            Try

                Me.LoadDocumentRepositoryLimits(DbContext, RepositorySizeLimit, RepositoryFileSizeLimit, RepositoryLimitText)

                If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 0 Then

                    LimitRepository = False

                ElseIf RepositoryFileSizeLimit < 0 Then

                    LimitRepository = False

                Else

                    LimitRepository = True

                End If
                If LimitRepository = True Then

                    If Not Me.CheckRepositoryLimit(DbContext, RepositoryLimitText) Then

                        AllowUpload = False

                    End If

                End If

            Catch ex As Exception
                AllowUpload = True
            End Try
            If AllowRepositoryUpload = True Then

                RepositorySizeLimit = -1
                RepositoryFileSizeLimit = -1
                RepositoryLimitText = String.Empty

            End If

            Return AllowUpload

        End Function
        Private Sub DeleteTempUploadAttachments()

            Dim Key As String = String.Empty

            If HttpContext.Session("TempUploadAttachment") IsNot Nothing Then

                Key = HttpContext.Session("TempUploadAttachment")

                Try

                    Dim Directory As New IO.DirectoryInfo(Me.PathToTempFolder() & Key)
                    Dim AllFiles As IO.FileInfo() = Directory.GetFiles()

                    If AllFiles IsNot Nothing Then

                        For Each SingleFile As IO.FileInfo In AllFiles

                            Try

                                System.IO.File.Delete(Me.PathToTempFolder() & Key & "\" & SingleFile.Name)

                            Catch ex As Exception
                            End Try

                        Next

                    End If

                Catch ex As Exception
                End Try
                Try

                    System.IO.Directory.Delete(Me.PathToTempFolder() & Key, True)

                Catch ex As Exception
                End Try

                HttpContext.Session("TempUploadAttachment") = Nothing

            End If

        End Sub

        <Serializable> Public Class MyFileInfo
            Public Property Filename As String = String.Empty
            Public Property FileDate As Date? = Nothing
            Sub New()

            End Sub
        End Class

        Private Function GetTempUploadAttachments(ByVal Files As IEnumerable(Of String),
                                                  ByRef ErrorMessage As String) As Generic.List(Of String)

            'objects
            Dim Key As String = String.Empty
            Dim FullFiles As Generic.List(Of String) = Nothing
            Dim FileInfos As New Generic.List(Of MyFileInfo)

            If HttpContext.Session("TempUploadAttachment") IsNot Nothing Then

                Try

                    Key = HttpContext.Session("TempUploadAttachment")

                    Dim Directory As New IO.DirectoryInfo(Me.PathToTempFolder() & Key)
                    Dim AllFiles As IO.FileInfo() = Directory.GetFiles()

                    'Use what is in the folder (as long as files in folder are deleted and folder is deleted and the temp upload works...this should be more consistent...
                    If AllFiles IsNot Nothing Then

                        FullFiles = New Generic.List(Of String)

                        For Each SingleFile As IO.FileInfo In AllFiles

                            'FullFiles.Add(Me.PathToTempFolder() & Key & "\" & SingleFile.Name)

                            Dim MyFileInfo As New MyFileInfo

                            MyFileInfo.Filename = Me.PathToTempFolder() & Key & "\" & SingleFile.Name
                            MyFileInfo.FileDate = System.IO.File.GetCreationTime(MyFileInfo.Filename)

                            FileInfos.Add(MyFileInfo)

                            MyFileInfo = Nothing

                        Next

                    End If

                    FullFiles = (From Entity In FileInfos
                                 Order By Entity.FileDate
                                 Select Entity.Filename).ToList()

                    '' This relies on the client side list of files
                    'If Not String.IsNullOrWhiteSpace(TempDirectory) AndAlso Files IsNot Nothing AndAlso Files.Count > 0 Then

                    '    FullFiles = New Generic.List(Of String)

                    '    For Each FileName In Files

                    '        FullFiles.Add(Me.PathToTempFolder() & TempDirectory & "\" & FileName)

                    '    Next

                    'End If

                Catch ex As Exception
                    ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                End Try

            End If

            Return FullFiles

        End Function
        Private Function SignDocument(ByVal AlertID As Integer, ByVal DocumentID As Integer) As Boolean

            'objects
            Dim DocumentSigned As Boolean = False
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim Folder As String = ""
            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim PKCS7 As Aspose.Pdf.InteractiveFeatures.Forms.PKCS7 = Nothing
            Dim Signature As Aspose.Pdf.InteractiveFeatures.Forms.Signature = Nothing
            Dim License As Aspose.Pdf.License = Nothing
            Dim HasBlankSignature As Boolean = False
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim DocMDPSignature As Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature = Nothing
            Dim SignatureFileMemoryStream As System.IO.MemoryStream = Nothing
            Dim AlertComment As AlertComment = Nothing
            Dim CurrentWindowsIdentity As System.Security.Principal.WindowsIdentity
            Dim ImpersonationContext As System.Security.Principal.WindowsImpersonationContext

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                    If Document IsNot Nothing Then

                        If Document.FileName.ToUpper.Contains(".PDF") Then

                            If MiscFN.IsNTAuth() = True Then

                                CurrentWindowsIdentity = CType(System.Web.HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                                ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                            End If

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.SecuritySession.User.EmployeeCode)

                            If MiscFN.IsNTAuth() = True Then

                                ImpersonationContext.Undo()

                            End If

                            Folder = AdvantageFramework.StringUtilities.AppendTrailingCharacter(Agency.FileSystemDirectory, "\")

                            If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                                AliasAccount.BeginImpersonation(Agency.FileSystemUserName, Agency.FileSystemDomain, AdvantageFramework.Security.Encryption.Decrypt(Agency.FileSystemPassword))

                            End If

                            If Employee IsNot Nothing Then

                                If Employee.AdobeSignatureFile IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.AdobeSignatureFilePassword) = False Then

                                    DocumentSigned = TryToSignDocumentWithEmployeeInfo(DbContext, Employee, Document, Folder)

                                End If

                            End If

                            If DocumentSigned = False Then

                                License = New Aspose.Pdf.License

                                License.SetLicense("Aspose.Total.lic")
                                License.Embedded = True

                                Using PDFDocument = New Aspose.Pdf.Document(Folder & Document.FileSystemFileName)

                                    Using PdfFileSignature = New Aspose.Pdf.Facades.PdfFileSignature(PDFDocument)

                                        PKCS7 = New Aspose.Pdf.InteractiveFeatures.Forms.PKCS7(AdvantageFramework.StringUtilities.AppendTrailingCharacter(Request.PhysicalApplicationPath, "\") & "AdvantagePDFSign.pfx", "APDFSAPDFS")
                                        PKCS7.Reason = "Advantage Digital Sign"

                                        DocMDPSignature = New Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature(PKCS7, Aspose.Pdf.InteractiveFeatures.Forms.DocMDPAccessPermissions.FillingInForms)

                                        If Employee IsNot Nothing Then

                                            If Employee.SignatureImage IsNot Nothing Then

                                                MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                                PdfFileSignature.SignatureAppearanceStream = MemoryStream

                                            End If

                                            PKCS7.ContactInfo = Employee.ToString

                                        End If

                                        For Each SignatureName In PdfFileSignature.GetBlankSignNames.OfType(Of String).ToList

                                            PdfFileSignature.Sign(SignatureName, PKCS7)
                                            HasBlankSignature = True

                                        Next

                                        If HasBlankSignature = False Then

                                            PdfFileSignature.Sign(1, "Advantage Digital Sign", Employee.ToString, "", True, New System.Drawing.Rectangle(100, 100, 200, 100), PKCS7)

                                        End If

                                        PdfFileSignature.Save(Folder & Document.FileSystemFileName)

                                        Document.FileSize = AdvantageFramework.FileSystem.GetFileSize(Folder & Document.FileSystemFileName)

                                        DocumentSigned = AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                    End Using

                                End Using

                                Try

                                    If MemoryStream IsNot Nothing Then

                                        MemoryStream.Close()
                                        MemoryStream.Dispose()
                                        MemoryStream = Nothing

                                    End If

                                Catch ex As Exception

                                End Try

                                If PKCS7 IsNot Nothing Then

                                    PKCS7 = Nothing

                                End If

                                If License IsNot Nothing Then

                                    License = Nothing

                                End If

                            End If

                            If Agency.FileSystemUserName IsNot Nothing AndAlso Agency.FileSystemUserName <> "" Then

                                AliasAccount.EndImpersonation()

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception

                DocumentSigned = False

                If ex IsNot Nothing Then

                    AdvantageFramework.Security.AddWebvantageEventLog(ex.Message, Diagnostics.EventLogEntryType.Error)

                    If ex.InnerException IsNot Nothing Then

                        AdvantageFramework.Security.AddWebvantageEventLog(ex.InnerException.Message, Diagnostics.EventLogEntryType.Error)

                    End If

                End If

            End Try

            If DocumentSigned Then

                If MiscFN.IsNTAuth() = True Then

                    CurrentWindowsIdentity = CType(System.Web.HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
                    ImpersonationContext = CurrentWindowsIdentity.Impersonate()

                End If

                AlertComment = New AlertComment(Me.SecuritySession.ConnectionString)

                If MiscFN.IsClientPortal = True Then

                    'AlertComment.AddNewComment(AlertID, "", "Digitally Signed - " & Document.FileName, Me._ClientPortalID)

                Else

                    AlertComment.AddNewComment(AlertID, Me.SecuritySession.UserCode, "Digitally Signed - " & Document.FileName)

                End If

            End If

            SignDocument = DocumentSigned

        End Function
        Private Function TryToSignDocumentWithEmployeeInfo(DbContext As AdvantageFramework.Database.DbContext, Employee As AdvantageFramework.Database.Views.Employee, Document As AdvantageFramework.Database.Entities.Document, Folder As String) As Boolean

            'objects
            Dim DocumentSigned As Boolean = False
            Dim PKCS7 As Aspose.Pdf.InteractiveFeatures.Forms.PKCS7 = Nothing
            Dim Signature As Aspose.Pdf.InteractiveFeatures.Forms.Signature = Nothing
            Dim License As Aspose.Pdf.License = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing
            Dim DocMDPSignature As Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature = Nothing
            Dim SignatureFileMemoryStream As System.IO.MemoryStream = Nothing
            Dim HasBlankSignature As Boolean = False

            Try

                If Employee IsNot Nothing Then

                    If Employee.AdobeSignatureFile IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Employee.AdobeSignatureFilePassword) = False Then

                        License = New Aspose.Pdf.License

                        License.SetLicense("Aspose.Total.lic")
                        License.Embedded = True

                        Using PDFDocument = New Aspose.Pdf.Document(Folder & Document.FileSystemFileName)

                            Using PdfFileSignature = New Aspose.Pdf.Facades.PdfFileSignature(PDFDocument)

                                Try

                                    SignatureFileMemoryStream = New System.IO.MemoryStream(Employee.AdobeSignatureFile)

                                    PKCS7 = New Aspose.Pdf.InteractiveFeatures.Forms.PKCS7(SignatureFileMemoryStream, Employee.AdobeSignatureFilePassword)
                                    PKCS7.Reason = "Advantage Digital Sign"

                                Catch ex As Exception

                                End Try

                                If PKCS7 IsNot Nothing Then

                                    DocMDPSignature = New Aspose.Pdf.InteractiveFeatures.Forms.DocMDPSignature(PKCS7, Aspose.Pdf.InteractiveFeatures.Forms.DocMDPAccessPermissions.FillingInForms)

                                    If Employee.SignatureImage IsNot Nothing Then

                                        MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                        PdfFileSignature.SignatureAppearanceStream = MemoryStream

                                    End If

                                    PKCS7.ContactInfo = Employee.ToString

                                    For Each SignatureName In PdfFileSignature.GetBlankSignNames.OfType(Of String).ToList

                                        PdfFileSignature.Sign(SignatureName, PKCS7)
                                        HasBlankSignature = True

                                    Next

                                    If HasBlankSignature = False Then

                                        PdfFileSignature.Sign(1, "Advantage Digital Sign", Employee.ToString, "", True, New System.Drawing.Rectangle(100, 100, 200, 100), PKCS7)

                                    End If

                                    PdfFileSignature.Save(Folder & Document.FileSystemFileName)

                                    Document.FileSize = AdvantageFramework.FileSystem.GetFileSize(Folder & Document.FileSystemFileName)

                                    DocumentSigned = AdvantageFramework.Database.Procedures.Document.Update(DbContext, Document)

                                End If

                            End Using

                        End Using

                    End If

                End If

            Catch ex As Exception
                DocumentSigned = False
            End Try

            Try

                If MemoryStream IsNot Nothing Then

                    MemoryStream.Close()
                    MemoryStream.Dispose()
                    MemoryStream = Nothing

                End If

            Catch ex As Exception

            End Try

            If PKCS7 IsNot Nothing Then

                PKCS7 = Nothing

            End If

            If License IsNot Nothing Then

                License = Nothing

            End If

            TryToSignDocumentWithEmployeeInfo = DocumentSigned

        End Function
        Private Function NotifyAlertRecipients(ByVal AlertID As Integer,
                                               ByVal SendEmail As Boolean,
                                               ByVal IncludeOriginator As Boolean,
                                               ByVal IsNew As Boolean,
                                               ByVal UpdateSprint As Boolean,
                                               ByVal SprintID As Integer?,
                                               ByVal OnlyCommentAdded As Boolean,
                                               ByVal DocumentID As Integer?) As Boolean

            'objects
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim Sent As Boolean = False
            Dim Errors As Generic.List(Of String)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, AlertID)

                If Alert IsNot Nothing Then

                    If SendEmail = True Then

                        If DocumentID Is Nothing Then DocumentID = 0
                        Sent = SendEmailToRecipients(DbContext, Alert, IncludeOriginator, IsNew, DocumentID)

                    Else

                        'Recipients are marked "not read" in SendEmailToRecipients
                        'So if that isn't run, need to mark unread
                        Try

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE ALERT_RCPT WITH(ROWLOCK) SET READ_ALERT = NULL WHERE ALERT_ID = {0}", AlertID))

                        Catch ex As Exception
                        End Try

                    End If
                    If OnlyCommentAdded = False Then

                        If SprintID Is Nothing Then

                            SprintID = 0

                        End If

                        Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, SprintID, Me.SecuritySession.UserCode, "", False)

                    Else

                        Webvantage.SignalR.Classes.NotificationHub.RefreshAlertComments(DbContext, AlertID, Me.SecuritySession.UserCode, False)

                    End If
                    If UpdateSprint = True Then

                        PushSprintRefreshAndNotifyByAlertID(DbContext, AlertID, SprintID)

                    End If

                End If

            End Using

            NotifyAlertRecipients = Sent

        End Function
        Private Function SendEmailToRecipients(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                               ByVal Alert As AdvantageFramework.Database.Entities.Alert,
                                               ByVal IncludeOriginator As Boolean,
                                               ByVal IsNew As Boolean,
                                               ByVal DocumentID As Integer) As Boolean

            'objects
            Dim EmployeeCodes As Generic.List(Of String) = Nothing
            Dim AlertRecipients As Generic.List(Of AdvantageFramework.DTO.Desktop.AlertRecipient) = Nothing
            Dim EmailSessionObject As Webvantage.EmailSessionObject = Nothing
            Dim Subject As String = Nothing
            Dim SubjectList As Generic.List(Of String) = New Generic.List(Of String)
            Dim ResetAssignedToEmployeeCodeReadFlag As Boolean = True
            Dim Notified As Boolean = True

            Try

                EmployeeCodes = New List(Of String)

                AlertRecipients = (From Entity In _Controller.LoadAlertRecipients(Alert.ID)
                                   Where Entity.IsCurrentRecipient = True).ToList

                If AlertRecipients IsNot Nothing AndAlso AlertRecipients.Count > 0 Then

                    EmployeeCodes.AddRange(AlertRecipients.Select(Function(r) r.EmployeeCode).ToList)

                End If

                ResetAssignedToEmployeeCodeReadFlag = True


                'If EmployeeCodes.Count > 0 Then

                EmailSessionObject = New Webvantage.EmailSessionObject(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.SecuritySession,
                                                                           HttpContext.Session("WebvantageURL"), HttpContext.Session("ClientPortalURL"))

                If IsNew Then

                    SubjectList.Add("New")

                End If
                If Alert.IsWorkItem.GetValueOrDefault(False) = True Then

                    SubjectList.Add("Assignment")

                Else

                    SubjectList.Add("Alert")

                End If
                If Not IsNew Then

                    SubjectList.Add("Updated")

                End If


                Subject = "[" & String.Join(" ", SubjectList) & "]"

                If EmployeeCodes Is Nothing Then EmployeeCodes = New List(Of String)

                With EmailSessionObject

                    .AlertId = Alert.ID
                    .Subject = Subject
                    .EmployeeCodesToSendEmailTo = String.Join(", ", EmployeeCodes)
                    .ClientPortalEmailAddressessToSendTo = ""
                    .IsClientPortal = False
                    .IncludeOriginator = True
                    .SessionID = HttpContext.Session.SessionID.ToString()
                    .PhysicalApplicationPath = HttpContext.Request.PhysicalApplicationPath
                    .ResetAssignedToEmployeeCodeReadFlag = ResetAssignedToEmployeeCodeReadFlag
                    .DocumentID = DocumentID
                    If Alert.AlertCategoryID = 79 AndAlso DocumentID > 0 Then

                        .ProofingURL = AdvantageFramework.Proofing.GetProofingURL(Me.SecuritySession, Alert.ID, DocumentID, Nothing, .ErrorMessage)

                    End If

                    .Send()

                End With

                'End If

            Catch ex As Exception
                Notified = False
            End Try

            Return Notified

        End Function
        Private Sub PushSprintRefreshAndNotifyByAlertID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal SprintID As Integer?)
            Try

                Try

                    If SprintID Is Nothing OrElse SprintID = 0 Then

                        SprintID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 SD.SPRINT_HDR_ID FROM SPRINT_DTL SD WITH(NOLOCK) INNER JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID  WHERE SD.ALERT_ID = {0} AND SH.IS_ACTIVE = 1;", AlertID)).SingleOrDefault

                    End If

                Catch ex As Exception
                    SprintID = 0
                End Try

                If SprintID IsNot Nothing AndAlso SprintID > 0 Then

                    Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, SprintID, Me.SecuritySession.UserCode, "", True)

                Else

                    Webvantage.SignalR.Classes.NotificationHub.NotifyRecipientsAll(DbContext, AlertID)

                End If

                ''Handled in RefreshNewAlertView
                'If SprintID > 0 Then

                '    Webvantage.SignalR.Classes.NotificationHub.RefreshSprint(DbContext, SprintID, True)

                'End If

            Catch ex As Exception
            End Try
        End Sub
        Private Sub PushAlertRefresh(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer, ByVal IncludeUser As Boolean)
            Try

                Dim SprintID As Integer = 0

                Try

                    SprintID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 SD.SPRINT_HDR_ID FROM SPRINT_DTL SD WITH(NOLOCK) INNER JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID  WHERE SD.ALERT_ID = {0} AND SH.IS_ACTIVE = 1;", AlertID)).SingleOrDefault

                Catch ex As Exception
                    SprintID = 0
                End Try

                Webvantage.SignalR.Classes.NotificationHub.RefreshNewAlertView(DbContext, AlertID, SprintID, Me.SecuritySession.UserCode, "", IncludeUser)

            Catch ex As Exception
            End Try
        End Sub
        Private Sub PushAlertRefresh(ByVal AlertID As Integer, ByVal IncludeUser As Boolean)
            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Me.PushAlertRefresh(DbContext, AlertID, IncludeUser)

                End Using

            Catch ex As Exception
            End Try
        End Sub
        Private Sub PushChecklistRefresh(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AlertID As Integer)
            Try

                'Dim SprintID As Integer = 0

                'Try

                '    SprintID = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT TOP 1 SD.SPRINT_HDR_ID FROM SPRINT_DTL SD WITH(NOLOCK) INNER JOIN SPRINT_HDR SH WITH(NOLOCK) ON SD.SPRINT_HDR_ID = SH.ID  WHERE SD.ALERT_ID = {0} AND SH.IS_ACTIVE = 1;", AlertID)).SingleOrDefault

                'Catch ex As Exception
                '    SprintID = 0
                'End Try

                Webvantage.SignalR.Classes.NotificationHub.RefreshAlertChecklists(DbContext, AlertID, Me.SecuritySession.UserCode, False)

            Catch ex As Exception
            End Try
        End Sub
        Private Sub PushChecklistRefresh(ByVal AlertID As Integer)
            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Webvantage.SignalR.Classes.NotificationHub.RefreshAlertChecklists(DbContext, AlertID, Me.SecuritySession.UserCode, False)

                End Using

            Catch ex As Exception
            End Try
        End Sub

#End Region

#Region " Classes "

        <Serializable>
        Public Class SimpleClientByOffice

            Public Property ClientCode As String
            Public Property ClientName As String
            Public Property IsActive As Short

            Sub New()

            End Sub
        End Class

#End Region

    End Class

End Namespace

