Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting
Imports AdvantageFramework
Imports System.Data.SqlClient
Imports AdvantageFramework.ViewModels.Employee
Imports System.Web.Configuration

Namespace Controllers

    Public Class CDP
        Public Property OfficeCode As String
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
    End Class

    Public Class ClientDDDTO
        Public Property Code As String
        Public Property DESCRIPTION As String
        Public Property Name As String
    End Class

    Public Class DivisionDDDTO
        Public Property Code As String
        Public Property DESCRIPTION As String
        Public Property CL_CODE As String
        Public Property Name As String
        Public Property ID As String
    End Class


    Public Class ProductsDDDTO
        Public Property Code As String
        Public Property DESCRIPTION As String
        Public Property Name As String
        Public Property ID As String
        Public Property OfficeCode As String
        Public Property ClientCode As String
        Public Property DivisionCode As String
    End Class

    Public Class SaleClassDDDTO
        Public Property Code As String
        Public Property Name As String
        Public Property description As String
    End Class

    Public Class CampaignDDDTO
        Public Property Code As String
        Public Property ID As Integer
        Public Property Name As String
        Public Property description As String
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
    End Class

    Public Class JobDDDTO
        Public Property Code As Integer
        Public Property Name As String
        Public Property description As String
        Public Property OfficeCode As String
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
    End Class

    <Serializable> Public Class JobCompDDDTO
        Public Property Code As String = String.Empty
        Public Property Name As String = String.Empty
        Public Property Description As String = String.Empty
        Public Property JobDescription As String = String.Empty
        Public Property JobComponentDescription As String = String.Empty
        Public Property DisplayDescription As String = String.Empty
        Public Property ID As String = String.Empty
        Public Property JobCode As Integer? = 0
        Public Property JobCompCode As Short? = 0
        Public Property OfficeCode As String = String.Empty
        Public Property ClientCode As String = String.Empty
        Public Property DivisionCode As String = String.Empty
        Public Property ProductCode As String = String.Empty
        Sub New()

        End Sub
    End Class

    Public Class EstimateDDDTO
        Public Property Code As Integer
        Public Property Name As String
        Public Property Description As String

        Public Property OfficeCode As String
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
    End Class

    Public Class EstimateComponentDDDTO
        Public Property Code As Short
        Public Property Name As String
        Public Property Description As String

        Public Property OfficeCode As String
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
        Public Property EstimateCode As Integer

    End Class

    Public Class EmployeeDDDTO
        Public Property Code As String
        Public Property Description As String
        Public Property FirstName As String
        Public Property MiddleInitial As String
        Public Property LastName As String
        Public Property Title As String
    End Class

    Public Class PONumberDDDTO
        Public Property code As Integer
        Public Property description As String
    End Class

    Public Class JobTypeDDDTO
        Public Property Code As String
        Public Property Name As String
    End Class

    Public Class FilterDTO
        Public Property Take As Integer
        Public Property Skip As Integer
        Public Property Page As Integer
        Public Property PageSize As Integer
        Public Property Sort As String
        Public Property filter As String
        Public Property ID As String
    End Class

    Public Class IDCodeName
        Public Property ID As Integer
        Public Property Code As String
        Public Property Name As String
    End Class


    Public Class UtilitiesController
        Inherits MVCControllerBase

#Region " Constants "

#End Region

        <HttpPost>
        Public Function UnityAction(ByVal ActionName As String, ByVal UnityMenuModel As Webvantage.ViewModels.UnityMenuModel) As JsonResult

            'objects
            Dim QueryString As AdvantageFramework.Web.QueryString
            Dim Success As Boolean = False
            Dim ErrorMessage As String = ""
            Dim SqlDataReader As System.Data.SqlClient.SqlDataReader = Nothing
            Dim oEstimating As cEstimating = Nothing
            Dim Alert As AdvantageFramework.Database.Entities.Alert = Nothing
            Dim EmployeeNonTask As AdvantageFramework.Database.Entities.EmployeeNonTask = Nothing
            Dim OpenWindow As Boolean = True
            Dim IsSilentOpen As Boolean = False
            Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))

            If UnityMenuModel.JobNumber > 0 AndAlso UnityMenuModel.JobComponentNumber > 0 Then

                QueryString = New AdvantageFramework.Web.QueryString

                QueryString.JobNumber = UnityMenuModel.JobNumber
                QueryString.JobComponentNumber = UnityMenuModel.JobComponentNumber

                Try

                    Select Case ActionName

                        Case "NewAlert"

                            QueryString.Page = "Alert_New.aspx"
                            QueryString.Add("caller", "jobtemplate")
                            QueryString.Add("f", "1")
                            QueryString.Add("jt", "1")

                            Success = True

                        Case "NewAssignment"

                            QueryString.Page = "Alert_New.aspx"
                            QueryString.Add("caller", "jobtemplate")
                            QueryString.Add("f", "1")
                            QueryString.Add("jt", "1")
                            QueryString.Add("assn", "1")

                            Success = True

                        Case "NewJob"

                            QueryString.Page = "JobTemplate_New.aspx"

                            Success = True

                        Case "JobJacket"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                            QueryString.Add("PageMode", "Edit")
                            QueryString.Add("NewComp", "0")

                            Success = True

                        Case "JobJacketAlerts"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Alerts

                            Success = True

                        Case "JobJacketDocuments"

                            System.Web.HttpContext.Current.Session("FromWindow") = "ProjectView"
                            System.Web.HttpContext.Current.Session("DocFilterLevel") = "JC"
                            System.Web.HttpContext.Current.Session("DocFilterValue") = UnityMenuModel.JobNumber.ToString() & "," & UnityMenuModel.JobComponentNumber.ToString()

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Documents
                            QueryString.Add("m", "D")

                            Success = True

                        Case "JobJacketCreativeBrief"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief

                            Success = True

                        Case "JobJacketSpecifications"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobSpecifications

                            Success = True

                        Case "JobJacketVersions"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                            Success = True

                        Case "JobJacketEstimates"

                            oEstimating = New cEstimating(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                            SqlDataReader = oEstimating.GetEstJob(UnityMenuModel.JobNumber, UnityMenuModel.JobComponentNumber)

                            If SqlDataReader.HasRows = True Then

                                SqlDataReader.Read()

                                If SqlDataReader("ESTIMATE_NUMBER") <> 0 Then

                                    QueryString.Add("JT", "0")
                                    QueryString.Add("newEst", "edit")
                                    QueryString.EstimateNumber = SqlDataReader("ESTIMATE_NUMBER")
                                    QueryString.EstimateComponentNumber = SqlDataReader("EST_COMPONENT_NBR")

                                Else

                                    QueryString.Add("JT", "0")
                                    QueryString.Add("newEst", "job")

                                End If

                            Else

                                QueryString.Add("JT", "0")
                                QueryString.Add("newEst", "job")

                            End If

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates

                            Success = True

                        Case "JobJacketSchedule"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule

                            Success = True

                        Case "JobJacketBoards"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.ProjectBoard

                            Success = True

                        Case "JobJacketQvA"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.FinancialStatus

                            Success = True

                        Case "JobJacketPurchaseOrders"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.PurchaseOrder

                            Success = True

                        Case "JobJacketEvents"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Events

                            Success = True

                        Case "JobJacketReviews"

                            QueryString.Page = "Content.aspx"
                            QueryString.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.DigitalAssetReviews

                            Success = True

                        Case "JobJacketSnapshot"

                            QueryString.Page = "TrafficSchedule_ProjectSummary.aspx"

                            Success = True

                        Case "AddTime"

                            QueryString.Page = "Employee/Timesheet/Entry"
                            QueryString.Add("Type", "New")
                            QueryString.Add("single", "1")
                            QueryString.EmployeeCode = Session("EmpCode")
                            QueryString.Add("new", "0")

                            If UnityMenuModel.AlertID > 0 Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                    Alert = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, UnityMenuModel.AlertID)

                                    If Alert IsNot Nothing AndAlso Alert.NonTaskID IsNot Nothing Then

                                        EmployeeNonTask = AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByEmployeeNonTaskID(DbContext, Alert.NonTaskID)

                                    End If

                                    If EmployeeNonTask IsNot Nothing Then

                                        QueryString.Add("caller", "Calendar_NewActivity")
                                        QueryString.FunctionCode = EmployeeNonTask.FunctionCode

                                    Else

                                        QueryString.Add("caller", "AlertView")

                                    End If

                                End Using

                            Else

                                QueryString.Add("caller", "AlertView")

                            End If

                            Success = True

                        Case "Stopwatch"

                            Success = AdvantageFramework.Timesheet.StopwatchStart(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode, Me.SecuritySession.User.EmployeeCode,
                                                                                  UnityMenuModel.JobNumber, UnityMenuModel.JobComponentNumber, UnityMenuModel.TaskSequenceNumber, UnityMenuModel.AlertID, ErrorMessage)

                            If Success = True Then

                                OpenWindow = True

                            End If

                        Case "Print"

                            QueryString.Page = UnityMenuModel.CurrentPrintPage
                            QueryString.Add("fromapp", "jobtemplate")
                            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                            If UnityMenuModel.EstimateNumber > 0 Then QueryString.EstimateNumber = UnityMenuModel.EstimateNumber
                            If UnityMenuModel.EstimateComponentNumber > 0 Then QueryString.EstimateComponentNumber = UnityMenuModel.EstimateComponentNumber
                            If UnityMenuModel.EstimatingQuoteDelimitedString <> "" Then QueryString.Add("sel_quotes", UnityMenuModel.EstimatingQuoteDelimitedString)

                            IsSilentOpen = True
                            Success = True

                        Case "SendAlert"

                            QueryString.Page = UnityMenuModel.CurrentPrintPage
                            QueryString.Add("fromapp", "jobtemplate")
                            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)
                            QueryString.Add("content", "1")

                            If UnityMenuModel.EstimateNumber > 0 Then QueryString.EstimateNumber = UnityMenuModel.EstimateNumber
                            If UnityMenuModel.EstimateComponentNumber > 0 Then QueryString.EstimateComponentNumber = UnityMenuModel.EstimateComponentNumber
                            If UnityMenuModel.EstimatingQuoteDelimitedString <> "" Then QueryString.Add("sel_quotes", UnityMenuModel.EstimatingQuoteDelimitedString)

                            IsSilentOpen = True
                            Success = True

                        Case "SendAssignment"

                            QueryString.Page = UnityMenuModel.CurrentPrintPage
                            QueryString.Add("fromapp", "jobtemplate")
                            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)
                            QueryString.Add("content", "1")

                            If UnityMenuModel.EstimateNumber > 0 Then QueryString.EstimateNumber = UnityMenuModel.EstimateNumber
                            If UnityMenuModel.EstimateComponentNumber > 0 Then QueryString.EstimateComponentNumber = UnityMenuModel.EstimateComponentNumber
                            If UnityMenuModel.EstimatingQuoteDelimitedString <> "" Then QueryString.Add("sel_quotes", UnityMenuModel.EstimatingQuoteDelimitedString)

                            IsSilentOpen = True
                            Success = True

                        Case "SendEmail"

                            QueryString.Page = UnityMenuModel.CurrentPrintPage '"JobTemplate_Print.aspx"
                            QueryString.Add("fromapp", "jobtemplate")
                            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)
                            QueryString.Add("content", "1")

                            If UnityMenuModel.EstimateNumber > 0 Then QueryString.EstimateNumber = UnityMenuModel.EstimateNumber
                            If UnityMenuModel.EstimateComponentNumber > 0 Then QueryString.EstimateComponentNumber = UnityMenuModel.EstimateComponentNumber
                            If UnityMenuModel.EstimatingQuoteDelimitedString <> "" Then QueryString.Add("sel_quotes", UnityMenuModel.EstimatingQuoteDelimitedString)

                            IsSilentOpen = True
                            Success = True

                        Case "PrintSendOptions"

                            QueryString.Page = UnityMenuModel.CurrentPrintPage
                            QueryString.Add("fromapp", "jobtemplate")
                            QueryString.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                            If UnityMenuModel.EstimateNumber > 0 Then QueryString.EstimateNumber = UnityMenuModel.EstimateNumber
                            If UnityMenuModel.EstimateComponentNumber > 0 Then QueryString.EstimateComponentNumber = UnityMenuModel.EstimateComponentNumber
                            If UnityMenuModel.EstimatingQuoteDelimitedString <> "" Then QueryString.Add("sel_quotes", UnityMenuModel.EstimatingQuoteDelimitedString)

                            Success = True

                        Case Else

                            ErrorMessage = "Action not found."
                            Success = False

                    End Select

                    If Success Then

                        If Me.SecuritySession.HasLimitedOfficeCodes AndAlso UnityMenuModel.JobNumber > 0 Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                                If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateJobOffice(DbContext, Me.SecuritySession.User.EmployeeCode, UnityMenuModel.JobNumber) = False Then

                                    Success = False

                                End If

                                If oValidation.ValidateJobCompIsViewable(Me.SecuritySession.UserCode, UnityMenuModel.JobNumber, UnityMenuModel.JobComponentNumber, "ts") = False Then

                                    Success = False

                                End If

                            End Using

                            If Success = False Then

                                ErrorMessage = "Access to this job/comp is denied."

                            End If

                        End If

                    End If

                Catch ex As Exception
                    Success = False
                    ErrorMessage = ex.Message
                End Try

            Else

                ErrorMessage = "Sorry, no associated Job Component."

            End If

            If Success Then

                Return Json(AdvantageFramework.Web.JsonResponseFactory.SuccessResponse(New With {.OpenWindow = OpenWindow, .IsSilentOpen = IsSilentOpen, .Url = QueryString.ToString(True)}))

            Else

                Return Json(AdvantageFramework.Web.JsonResponseFactory.ErrorResponse(ErrorMessage))

            End If

        End Function
        Public Function CommentPicture(<FromRoute> ByVal EmployeeCode As String) As ActionResult

            Try

                'objects
                Dim EmployeePic As AdvantageFramework.Database.Entities.EmployeePicture = Nothing
                Dim Picture As Byte() = Nothing
                Dim Image As System.Drawing.Image = Nothing
                Dim ImageConverter As System.Drawing.ImageConverter = Nothing
                Dim Bitmap As System.Drawing.Bitmap = Nothing
                Dim LoadBitmap As Boolean = False

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        EmployeePic = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If EmployeePic IsNot Nothing AndAlso
                            EmployeePic.Image IsNot Nothing AndAlso
                            EmployeePic.Image.Length > 0 Then

                            Picture = EmployeePic.Image
                            LoadBitmap = True

                        End If

                    Catch ex As Exception
                        LoadBitmap = False
                    End Try

                End Using

                If LoadBitmap = True Then

                    Try

                        ImageConverter = New Drawing.ImageConverter
                        Bitmap = DirectCast(ImageConverter.ConvertFrom(Picture), System.Drawing.Bitmap)
                        Image = Bitmap

                    Catch ex As Exception
                        Image = Nothing
                    End Try

                End If

                If Image Is Nothing Then

                    Return Nothing

                Else

                    Return ImageResult(Image, Drawing.Imaging.ImageFormat.Png)

                End If

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function EmployeePicture(<FromRoute> ByVal EmployeeCode As String) As ActionResult

            Try

                'objects
                Dim EmployeePic As AdvantageFramework.Database.Entities.EmployeePicture = Nothing
                Dim Picture As Byte() = Nothing
                Dim Image As System.Drawing.Image = Nothing
                Dim ImageConverter As System.Drawing.ImageConverter = Nothing
                Dim Bitmap As System.Drawing.Bitmap = Nothing
                Dim LoadBitmap As Boolean = False

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Try

                        EmployeePic = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If EmployeePic IsNot Nothing AndAlso
                       EmployeePic.Image IsNot Nothing AndAlso
                       EmployeePic.Image.Length > 0 Then

                            Picture = EmployeePic.Image
                            LoadBitmap = True

                        End If

                    Catch ex As Exception
                        LoadBitmap = False
                    End Try

                End Using

                If LoadBitmap = True Then

                    Try

                        ImageConverter = New Drawing.ImageConverter
                        Bitmap = DirectCast(ImageConverter.ConvertFrom(Picture), System.Drawing.Bitmap)
                        Image = Bitmap

                    Catch ex As Exception
                        Image = Nothing
                    End Try

                End If

                If Image Is Nothing Then

                    Image = System.Drawing.Image.FromFile(Server.MapPath("~/Images/Icons/Grey/256/user.png"))

                End If

                Return ImageResult(Image, Drawing.Imaging.ImageFormat.Png)

            Catch ex As Exception
                Return Nothing
            End Try

        End Function
        Public Function Thumbnail(<FromRoute> ByVal DocumentID As String) As ActionResult

            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim ThumbnailBytes As Byte() = Nothing
            Dim Image As System.Drawing.Image = Nothing
            Dim ImageConverter As System.Drawing.ImageConverter = Nothing
            Dim Bitmap As System.Drawing.Bitmap = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Document = AdvantageFramework.Database.Procedures.Document.LoadByDocumentID(DbContext, DocumentID)

                If Document IsNot Nothing Then

                    ThumbnailBytes = Document.Thumbnail

                End If

            End Using

            If ThumbnailBytes IsNot Nothing Then

                Try

                    ImageConverter = New Drawing.ImageConverter
                    Bitmap = DirectCast(ImageConverter.ConvertFrom(ThumbnailBytes), System.Drawing.Bitmap)
                    Image = Bitmap

                Catch ex As Exception
                    Image = Nothing
                End Try

            End If

            If Image Is Nothing Then

                If Document.FileName.ToLower.Contains(".doc") Then

                ElseIf Document.FileName.ToLower.Contains(".xls") Then

                ElseIf Document.FileName.ToLower.Contains(".pdf") Then

                Else

                    Image = System.Drawing.Image.FromFile(Server.MapPath("~/Images/Icons/Color/256/document_empty.png"))

                End If

            End If

            Return ImageResult(Image, Drawing.Imaging.ImageFormat.Png)

        End Function

#Region " Views "

#Region " -- Partials -- "

        Public Function UnityMenu(ByVal ViewModel As UnityMenuModel) As ActionResult

            'objects
            Dim BasePage As Webvantage.BasePageShared = Nothing
            Dim JobVersion As JobVersion = Nothing
            Dim QueryString As New AdvantageFramework.Web.QueryString()
            Dim JobJacketDocumentsVisible As Boolean = True
            Dim JobJacketEstimatesVisible As Boolean = True
            Dim JobJacketQvAVisible As Boolean = True
            Dim JobJacketPurchaseOrdersVisible As Boolean = True
            Dim JobJacketEventsVisible As Boolean = True
            Dim JobJacketCreativeBriefVisible As Boolean = True
            Dim JobJacketSpecificationsVisible As Boolean = True
            Dim JobJacketVersionsVisible As Boolean = True
            Dim JobJacketScheduleVisible As Boolean = True
            Dim JobJacketBoardsVisible As Boolean = True
            Dim JobJacketSnapshotVisible As Boolean = True
            Dim AddTimeVisible As Boolean = True
            Dim StopwatchVisible As Boolean = True
            Dim NewJobVisible As Boolean = True
            Dim JobJacketVisible As Boolean = True
            Dim JobJacketReviewsVisible As Boolean = True
            Dim NewAssignmentVisible As Boolean = True
            Dim NewAlertVisible As Boolean = True
            Dim SendAssignmentVisible As Boolean = True
            Dim SendAlertVisible As Boolean = True
            Dim JobJacketAlertsVisible As Boolean = True

            BasePage = New Webvantage.BasePageShared

            If ViewModel Is Nothing Then

                ViewModel = New Webvantage.ViewModels.UnityMenuModel

            End If

            If BasePage._Session Is Nothing Then

                If System.Web.HttpContext.Current.Session("Security_Session") Is Nothing Then

                    If System.Web.HttpContext.Current.Session("UserGUID") IsNot Nothing Then

                        BasePage._Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Client_Portal,
                                                                                    System.Web.HttpContext.Current.Session("ConnString"), System.Web.HttpContext.Current.Session("UserCode"),
                                                                                    CInt(System.Web.HttpContext.Current.Session("AdvantageUserLicenseInUseID")), System.Web.HttpContext.Current.Session("ConnString"))

                    Else

                        BasePage._Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage,
                                                                                    System.Web.HttpContext.Current.Session("ConnString"), System.Web.HttpContext.Current.Session("UserCode"),
                                                                                    CInt(System.Web.HttpContext.Current.Session("AdvantageUserLicenseInUseID")), System.Web.HttpContext.Current.Session("ConnString"))

                    End If

                    System.Web.HttpContext.Current.Session("Security_Session") = BasePage._Session

                Else

                    BasePage._Session = System.Web.HttpContext.Current.Session("Security_Session")

                End If

            End If

            If BasePage.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket) = False Or
                   BasePage.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket) = False Then

                NewJobVisible = False

            End If

            If BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, False) = False Then

                JobJacketVisible = False

            End If

            If BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts, False) = False Then

                JobJacketAlertsVisible = False
                NewAlertVisible = False
                NewAssignmentVisible = False

                SendAlertVisible = False
                SendAssignmentVisible = False

            End If

            JobJacketDocumentsVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_JobComponent, False) = 1)
            JobJacketCreativeBriefVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_CreativeBrief, False) = 1)
            JobJacketSpecificationsVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Specifications, False) = 1)
            JobJacketVersionsVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, False) = 1)
            JobJacketScheduleVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, False) = 1)
            JobJacketSnapshotVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DesktopObjects_ProjectViewpointSnapshot, False) = 1)

            JobJacketBoardsVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Boards, False) = 1)

            If BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Timesheet, False) = False Or MiscFN.IsClientPortal = True Then

                AddTimeVisible = False
                StopwatchVisible = False

            End If

            JobJacketReviewsVisible = cApplication.IsProofingToolActive(BasePage._Session)

            If MiscFN.IsClientPortal() Then

                JobJacketDocumentsVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Documents, False) = 1)
                JobJacketEstimatesVisible = False
                JobJacketQvAVisible = False
                JobJacketPurchaseOrdersVisible = False
                JobJacketEventsVisible = False

                NewAssignmentVisible = False
                SendAssignmentVisible = False

            Else

                'Don't know where this is set in ADV for CP users?? 
                If BasePage.UserHasAccessToAddNew(AdvantageFramework.Security.Modules.Desktop_Alerts) = False Then

                    NewAlertVisible = False
                    NewAssignmentVisible = False

                    SendAlertVisible = False
                    SendAssignmentVisible = False

                End If

                JobJacketDocumentsVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, False) = 1)
                JobJacketEstimatesVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating, False) = 1)
                JobJacketQvAVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DashboardQueries_QuotevsActualsDQ, False) = 1)
                JobJacketPurchaseOrdersVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders, False) = 1)
                JobJacketEventsVisible = (BasePage.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectEvents, False) = 1)

            End If

            If ViewModel.JobJacketDocuments.Visible Then

                ViewModel.JobJacketDocuments.Visible = JobJacketDocumentsVisible

            End If

            If ViewModel.JobJacketCreativeBrief.Visible Then

                ViewModel.JobJacketCreativeBrief.Visible = JobJacketCreativeBriefVisible

            End If

            If ViewModel.JobJacketSpecifications.Visible Then

                ViewModel.JobJacketSpecifications.Visible = JobJacketSpecificationsVisible

            End If

            If ViewModel.JobJacketVersions.Visible Then

                ViewModel.JobJacketVersions.Visible = JobJacketVersionsVisible

            End If

            If ViewModel.JobJacketSchedule.Visible Then

                ViewModel.JobJacketSchedule.Visible = JobJacketScheduleVisible

            End If

            If ViewModel.JobJacketSnapshot.Visible Then

                ViewModel.JobJacketSnapshot.Visible = JobJacketSnapshotVisible

            End If

            If ViewModel.AddTime.Visible Then

                ViewModel.AddTime.Visible = AddTimeVisible

            End If

            If ViewModel.Stopwatch.Visible Then

                ViewModel.Stopwatch.Visible = StopwatchVisible

            End If

            If ViewModel.NewJob.Visible Then

                ViewModel.NewJob.Visible = NewJobVisible

            End If

            If ViewModel.JobJacket.Visible Then

                ViewModel.JobJacket.Visible = JobJacketVisible

                If ViewModel.JobJacketVersions.Visible Then

                    JobVersion = New JobVersion(Me.SecuritySession.ConnectionString)

                    ViewModel.JobJacketVersions.Text = JobVersion.GetAgencyDesc()

                End If

            End If

            If ViewModel.JobJacketProofs.Visible Then

                ViewModel.JobJacketProofs.Visible = JobJacketReviewsVisible

            End If

            If ViewModel.NewAssignment.Visible Then

                ViewModel.NewAssignment.Visible = NewAssignmentVisible

            End If

            If ViewModel.SendAssignment.Visible Then

                ViewModel.SendAssignment.Visible = SendAssignmentVisible

            End If

            If ViewModel.SendAlert.Visible Then

                ViewModel.SendAlert.Visible = SendAlertVisible

            End If

            If ViewModel.JobJacketAlerts.Visible Then

                ViewModel.JobJacketAlerts.Visible = JobJacketAlertsVisible

            End If

            Return PartialView("~/Views/Shared/UnityMenu.vbhtml", ViewModel)

        End Function

#End Region

#End Region

#Region " Methods "

#Region "api"
        <HttpGet>
        Public Function SearchOffices(Optional ByVal SprintID As Integer = 0) As JsonResult

            'objects
            Dim Offices As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                'arParams.Add(New SqlParameter("@SprintID", SprintID))

                Offices = (From Item In DbContext.Database.SqlQuery(Of ClientDDDTO)("EXEC [dbo].[usp_wv_dd_GetOfficesEmp] @UserID", arParams.ToArray)
                           Select New With {
                               .Code = Item.Code,
                               .Name = Item.Name + " (" + Item.Code + ")"
                               }).ToList

            End Using

            Return MaxJson(Offices, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function SearchClients(Optional OfficeCode As String = Nothing, Optional ByVal SprintID As Integer = 0, Optional ByVal Text As String = "", Optional ByVal skip As Integer = 0, Optional ByVal take As Integer = 0, Optional ByVal filter As FilterDTO = Nothing, Optional ByVal page As Integer = 0, Optional ByVal pageSize As Integer = 0) As JsonResult

            Dim Clients As IEnumerable = Nothing
            Dim totalRows As Integer = 0

            Dim arParams As New List(Of SqlParameter)

            Dim foo As String = Request.Url.PathAndQuery

            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@FromApp", "util"))
            arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
            arParams.Add(New SqlParameter("@SprintID", SprintID))
            arParams.Add(New SqlParameter("@Text", Text))
            arParams.Add(New SqlParameter("@Skip", skip))
            arParams.Add(New SqlParameter("@Take", take))
            Dim outParam As SqlParameter = New SqlParameter()
            outParam.SqlDbType = System.Data.SqlDbType.Int
            outParam.ParameterName = "@TotalRows"
            outParam.Value = 0
            outParam.Direction = System.Data.ParameterDirection.Output
            arParams.Add(outParam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Clients = (From Item In DbContext.Database.SqlQuery(Of ClientDDDTO)("EXEC [dbo].[usp_wv_dd_GetClients_Paging] @UserID, @FromApp, @OfficeCode, @SprintID,@Text, @Skip, @Take, @TotalRows out", arParams.ToArray)
                           Select New With {
                                 .Code = Item.Code, .Name = Item.Name + " (" + Item.Code + ")"}).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If
            End Using

            Return MaxJson(New With {.Clients = Clients, .Total = totalRows}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchClients2(ByVal OfficeCode As String,
                                       ByVal SprintID As Integer,
                                       ByVal skip As Integer,
                                       ByVal take As Integer,
                                       ByVal page As Integer,
                                       ByVal pageSize As Integer) As JsonResult

            Dim Clients As IEnumerable = Nothing
            Dim totalRows As Integer = 0

            Dim arParams As New List(Of SqlParameter)

            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@FromApp", "util"))
            arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
            arParams.Add(New SqlParameter("@SprintID", SprintID))
            arParams.Add(New SqlParameter("@Text", ""))
            arParams.Add(New SqlParameter("@Skip", skip))
            arParams.Add(New SqlParameter("@Take", take))
            Dim outParam As SqlParameter = New SqlParameter()
            outParam.SqlDbType = System.Data.SqlDbType.Int
            outParam.ParameterName = "@TotalRows"
            outParam.Value = 0
            outParam.Direction = System.Data.ParameterDirection.Output
            arParams.Add(outParam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Clients = (From Item In DbContext.Database.SqlQuery(Of ClientDDDTO)("EXEC [dbo].[usp_wv_dd_GetClients_Paging] @UserID, @FromApp, @OfficeCode, @SprintID,@Text, @Skip, @Take, @TotalRows out", arParams.ToArray)
                           Select New With {
                                 .Code = Item.Code, .Name = Item.Name + " (" + Item.Code + ")"}).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If
            End Using

            Return MaxJson(New With {.Clients = Clients, .Total = totalRows}, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function SearchClientIndex(Optional OfficeCode As String = Nothing, Optional ByVal SprintID As Integer = 0, Optional ByVal Text As String = "", Optional ByVal ClientCode As String = "") As JsonResult

            Dim arParams As New List(Of SqlParameter)
            Dim index As Integer = -1

            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
            arParams.Add(New SqlParameter("@ClientCode", ClientCode))
            arParams.Add(New SqlParameter("@SprintID", SprintID))
            arParams.Add(New SqlParameter("@Text", Text))
            Dim outParam As SqlParameter = New SqlParameter()
            outParam.SqlDbType = System.Data.SqlDbType.Int
            outParam.ParameterName = "@Index"
            outParam.Value = 0
            outParam.Direction = System.Data.ParameterDirection.Output
            arParams.Add(outParam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetClients_Index] @UserID, @OfficeCode, @ClientCode, @SprintID, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function


        <HttpGet>
        Public Function SearchDivisions(Optional OfficeCode As String = Nothing, Optional ClientCode As String = Nothing, Optional ByVal SprintID As Integer = 0, Optional ByVal Text As String = "", Optional ByVal Skip As Integer = 0, Optional ByVal Take As Integer = 0) As JsonResult

            Dim Divisions As IEnumerable
            Dim totalRows As Integer = 0

            Dim arParams As New List(Of SqlParameter)
            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, DBNull.Value)))
            arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
            arParams.Add(New SqlParameter("@SprintID", SprintID))
            arParams.Add(New SqlParameter("@Text", Text))
            arParams.Add(New SqlParameter("@Skip", Skip))
            arParams.Add(New SqlParameter("@Take", Take))
            If Me.SecuritySession.ClientPortalUser IsNot Nothing Then
                arParams.Add(New SqlParameter("@CPID", Me.SecuritySession.ClientPortalUser.ClientContactID))
            Else
                arParams.Add(New SqlParameter("@CPID", 0))
            End If
            Dim outParam As SqlParameter = New SqlParameter()
            outParam.SqlDbType = System.Data.SqlDbType.Int
            outParam.ParameterName = "@TotalRows"
            outParam.Value = 0
            outParam.Direction = System.Data.ParameterDirection.Output
            arParams.Add(outParam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Divisions = (From Item In DbContext.Database.SqlQuery(Of DivisionDDDTO)("EXEC [dbo].[usp_wv_dd_GetDivisions_Paging] @UserID, @OfficeCode, @ClientCode, @SprintID, @Text, @Skip, @Take, @CPID, @TotalRows out", arParams.ToArray)
                             Select New With {
                                 .Code = Item.Code,
                                 .ID = Item.ID,
                                 .ClientCode = Item.CL_CODE,
                                 .Name = Item.Name + If(Item.Code = Item.CL_CODE,
                                    " (" + Item.CL_CODE + ")", " (" + Item.CL_CODE + "/" + Item.Code + ")")}).ToList


                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

            End Using

            Return MaxJson(New With {.Divisions = Divisions, .Total = totalRows}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchDivisionIndex(Optional OfficeCode As String = Nothing, Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = "", Optional ByVal SprintID As Integer = 0, Optional ByVal Text As String = "") As JsonResult

            Dim arParams As New List(Of SqlParameter)
            Dim index As Integer = -1

            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
            arParams.Add(New SqlParameter("@ClientCode", ClientCode))
            arParams.Add(New SqlParameter("@DivisionCode", DivisionCode))
            arParams.Add(New SqlParameter("@SprintID", SprintID))
            arParams.Add(New SqlParameter("@Text", Text))
            Dim outParam As SqlParameter = New SqlParameter()
            outParam.SqlDbType = System.Data.SqlDbType.Int
            outParam.ParameterName = "@Index"
            outParam.Value = 0
            outParam.Direction = System.Data.ParameterDirection.Output
            arParams.Add(outParam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetDivisions_Index] @UserID, @OfficeCode, @ClientCode, @DivisionCode, @SprintID, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchProducts(ByVal OfficeCode As String, ClientCode As String, DivisionCode As String, Optional ByVal SprintID As Integer = 0, Optional ByVal Text As String = "", Optional ByVal Skip As Integer = 0, Optional ByVal Take As Integer = 0) As JsonResult

            'objects
            Dim Products As IEnumerable = Nothing
            Dim totalRows As Integer = 0
            Dim arParams As New List(Of SqlParameter)
            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, DBNull.Value)))
            arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, DBNull.Value)))
            arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, DBNull.Value)))
            arParams.Add(New SqlParameter("@SprintID", SprintID))
            arParams.Add(New SqlParameter("@Text", Text))
            arParams.Add(New SqlParameter("@Skip", Skip))
            arParams.Add(New SqlParameter("@Take", Take))
            If Me.SecuritySession.ClientPortalUser IsNot Nothing Then
                arParams.Add(New SqlParameter("@CPID", Me.SecuritySession.ClientPortalUser.ClientContactID))
            Else
                arParams.Add(New SqlParameter("@CPID", 0))
            End If
            Dim outParam As SqlParameter = New SqlParameter()
            outParam.SqlDbType = System.Data.SqlDbType.Int
            outParam.ParameterName = "@TotalRows"
            outParam.Value = 0
            outParam.Direction = System.Data.ParameterDirection.Output
            arParams.Add(outParam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Products = (From Item In DbContext.Database.SqlQuery(Of ProductsDDDTO)("EXEC [dbo].[usp_wv_dd_GetProducts_Paging] @UserID,@OfficeCode, @ClientCode, @DivisionCode, @SprintID, @Text, @Skip, @Take, @CPID, @TotalRows out", arParams.ToArray)
                            Select New With {.Code = Item.Code,
                                .OfficeCode = Item.OfficeCode,
                                .ClientCode = Item.ClientCode,
                                .DivisionCode = Item.DivisionCode,
                                .ID = Item.ID,
                                .Name = Item.Name + " (" + Item.ClientCode + If(Item.ClientCode = Item.DivisionCode, "", "/" + Item.DivisionCode) + If(Item.DivisionCode = Item.Code, "", "/" + Item.Code) + ")"}).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

            End Using

            Return MaxJson(New With {.Products = Products, .Total = totalRows}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchProductIndex(Optional OfficeCode As String = Nothing, Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = "", Optional ByVal ProductID As String = "", Optional ByVal SprintID As Integer = 0, Optional ByVal Text As String = "") As JsonResult

            'Optional OfficeCode As String = Nothing,
            'arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))

            Dim arParams As New List(Of SqlParameter)
            Dim index As Integer = -1

            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@ClientCode", ClientCode))
            arParams.Add(New SqlParameter("@DivisionCode", DivisionCode))
            arParams.Add(New SqlParameter("@ProductID", ProductID))
            arParams.Add(New SqlParameter("@SprintID", SprintID))
            arParams.Add(New SqlParameter("@Text", Text))
            Dim outParam As SqlParameter = New SqlParameter()
            outParam.SqlDbType = System.Data.SqlDbType.Int
            outParam.ParameterName = "@Index"
            outParam.Value = 0
            outParam.Direction = System.Data.ParameterDirection.Output
            arParams.Add(outParam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetProducts_Index] @UserID, @ClientCode, @DivisionCode, @ProductID, @SprintID, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchSalesClass() As JsonResult
            'objects
            Dim SalesClasses As IEnumerable = Nothing

            Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
            parameterFromApp.Value = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                SalesClasses = (From Item In DbContext.Database.SqlQuery(Of SaleClassDDDTO)("EXEC [dbo].[usp_wv_dd_salesclass] @FromApp", parameterFromApp)
                                Select New With {
                                    .Code = Item.Code,
                                    .Name = Item.Name + " (" + Item.Code + ")"
                                        }).ToList

            End Using

            Return MaxJson(SalesClasses, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchSalesClassAll() As JsonResult
            'objects
            Dim SalesClasses As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                SalesClasses = (From Item In DbContext.Database.SqlQuery(Of SaleClassDDDTO)("EXEC [dbo].[usp_wv_dd_salesclass_all]")
                                Select New With {
                                    .Code = Item.Code,
                                    .Name = Item.Name + " (" + Item.Code + ")"
                                        }).ToList

            End Using

            Return MaxJson(SalesClasses, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchCDPForJob(ByVal JobNumber As Integer)
            Dim CDPs As List(Of CDP) = Nothing
            Dim arParams As New List(Of SqlParameter)
            arParams.Add(New SqlParameter("@JobNumber", JobNumber))

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                CDPs = DbContext.Database.SqlQuery(Of CDP)("EXEC [dbo].[usp_wv_dd_GetCDPforJob] @JobNumber", New SqlParameter("@JobNumber", JobNumber)).ToList

            End Using

            Return MaxJson(CDPs.FirstOrDefault, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function SearchJob(ByVal OfficeCode As String,
                                  ByVal ClientCode As String,
                                  ByVal DivisionCode As String,
                                  ByVal ProductCode As String,
                                  ByVal AccountExecutive As String,
                                  Optional ByVal Text As String = "",
                                  Optional ByVal CampaignID As Integer = 0,
                                  Optional ByVal SalesClass As String = "",
                                  Optional ByVal JobType As String = "",
                                  Optional ByVal ShowClosedJobs As Boolean = False,
                                  Optional ByVal SprintID As Integer = 0,
                                  Optional ByVal Skip As Integer = 0,
                                  Optional ByVal Take As Integer = 0) As JsonResult

            Dim totalRows As Integer = 0
            Dim CompareClientCode As Boolean = Not String.IsNullOrWhiteSpace(ClientCode)
            Dim CompareDivisionCode As Boolean = Not String.IsNullOrWhiteSpace(DivisionCode)
            Dim CompareProductCode As Boolean = Not String.IsNullOrWhiteSpace(ProductCode)
            Dim CompareOfficeCode As Boolean = Not String.IsNullOrWhiteSpace(OfficeCode)
            'objects
            Dim Jobs As IEnumerable = Nothing
            Dim Jobst As Generic.List(Of JobDDDTO) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@AccountExecutive", AccountExecutive))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", SalesClass))
                arParams.Add(New SqlParameter("@JobType", JobType))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@SprintID", SprintID))
                arParams.Add(New SqlParameter("@Text", Text))
                arParams.Add(New SqlParameter("@Skip", Skip))
                arParams.Add(New SqlParameter("@Take", Take))
                If Me.SecuritySession.ClientPortalUser IsNot Nothing Then
                    arParams.Add(New SqlParameter("@CPID", Me.SecuritySession.ClientPortalUser.ClientContactID))
                Else
                    arParams.Add(New SqlParameter("@CPID", 0))
                End If
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@TotalRows"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                Jobst = (From Item In DbContext.Database.SqlQuery(Of JobDDDTO)("usp_wv_dd_JobJacket_Paging @UserID,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@SprintID,@Text,@Skip,@Take,@CPID,@TotalRows OUT", arParams.ToArray)).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

                Jobs = Jobst.Select(Function(Item) New With {
                            .Code = Item.Code,
                            .OfficeCode = Item.OfficeCode,
                            .ClientCode = Item.ClientCode,
                            .DivisionCode = Item.DivisionCode,
                            .ProductCode = Item.ProductCode,
                            .Description = Item.Name,
                            .Name = AdvantageFramework.StringUtilities.PadWithCharacter(Item.Code, 6, "0", True, True) _
                                & " - " & Item.Name _
                                & If(CompareClientCode Or CompareDivisionCode Or CompareProductCode,
                                "",
                                " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode, "", "/" & Item.ProductCode) & ")")})

            End Using

            Return MaxJson(New With {.Jobs = Jobs, .Total = totalRows}, JsonRequestBehavior.AllowGet)

        End Function

        Public Function SearchJobIndex(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False,
                                        Optional ByVal SprintID As Integer = 0) As JsonResult

            Dim index As Integer = -1

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", If(JobCode IsNot Nothing, JobCode, "")))
                arParams.Add(New SqlParameter("@AccountExecutive", If(AccountExecutive IsNot Nothing, AccountExecutive, "")))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", If(SalesClass IsNot Nothing, SalesClass, "")))
                arParams.Add(New SqlParameter("@JobType", If(JobType IsNot Nothing, JobType, "")))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@SprintID", SprintID))
                arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@Index"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetAllJobs_Index] @UserID, @OfficeCode, @ClientCode, @DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@SprintID, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchJobPS(ByVal OfficeCode As String,
                                  ByVal ClientCode As String,
                                  ByVal DivisionCode As String,
                                  ByVal ProductCode As String,
                                  ByVal AccountExecutive As String,
                                  Optional ByVal CampaignID As Integer = 0,
                                  Optional ByVal SalesClass As String = "",
                                  Optional ByVal JobType As String = "",
                                  Optional ByVal ShowClosedJobs As Boolean = False,
                                  Optional ByVal Text As String = "",
                                  Optional ByVal Skip As Integer = 0,
                                  Optional ByVal Take As Integer = 0) As JsonResult

            Dim totalRows As Integer = 0
            Dim CompareClientCode As Boolean = Not String.IsNullOrWhiteSpace(ClientCode)
            Dim CompareDivisionCode As Boolean = Not String.IsNullOrWhiteSpace(DivisionCode)
            Dim CompareProductCode As Boolean = Not String.IsNullOrWhiteSpace(ProductCode)
            Dim CompareOfficeCode As Boolean = Not String.IsNullOrWhiteSpace(OfficeCode)
            'objects
            Dim Jobs As IEnumerable = Nothing
            Dim Jobst As Generic.List(Of JobDDDTO) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@AccountExecutive", AccountExecutive))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", SalesClass))
                arParams.Add(New SqlParameter("@JobType", JobType))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@Text", Text))
                arParams.Add(New SqlParameter("@Skip", Skip))
                arParams.Add(New SqlParameter("@Take", Take))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@TotalRows"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                Jobst = (From Item In DbContext.Database.SqlQuery(Of JobDDDTO)("usp_wv_dd_JobJacket_PS_Paging @UserID,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@Text,@Skip,@Take,@TotalRows OUT", arParams.ToArray)).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

                Jobs = Jobst.Select(Function(Item) New With {
                                .Code = Item.Code,
                                .OfficeCode = Item.OfficeCode,
                                .ClientCode = Item.ClientCode,
                                .DivisionCode = Item.DivisionCode,
                                .ProductCode = Item.ProductCode,
                                .Name = AdvantageFramework.StringUtilities.PadWithCharacter(Item.Code, 6, "0", True, True) _
                                    & " - " & Item.Name _
                                    & If(CompareClientCode Or CompareDivisionCode Or CompareProductCode,
                                    "",
                                    " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode, "", "/" & Item.ProductCode) & ")")})
            End Using

            Return MaxJson(New With {.Jobs = Jobs, .Total = totalRows}, JsonRequestBehavior.AllowGet)
        End Function


        <HttpGet>
        Public Function SearchJobIndexPS(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False) As JsonResult

            Dim index As Integer = -1

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", If(JobCode IsNot Nothing, JobCode, "")))
                arParams.Add(New SqlParameter("@AccountExecutive", If(AccountExecutive IsNot Nothing, AccountExecutive, "")))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", If(SalesClass IsNot Nothing, SalesClass, "")))
                arParams.Add(New SqlParameter("@JobType", If(JobType IsNot Nothing, JobType, "")))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@Index"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetAllJobs_PS_Index] @UserID, @OfficeCode, @ClientCode, @DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function


        <HttpGet>
        Public Function SearchCampaignDetailTypes()
            Dim CampaignDetailTypes As IEnumerable = Nothing

            CampaignDetailTypes = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.CampaignDetailTypes))
                                   Select New With {.Name = EnumObject.Description,
                                          .Code = EnumObject.Code}).ToList

            Return MaxJson(CampaignDetailTypes, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function SearchDepartmentTeam()
            Dim DepartmentTeam As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                DepartmentTeam = (From Item In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext)
                                  Select New With {
                                      .Code = Item.Code,
                                      .Name = Item.Description & " (" & Item.Code & ")"}).ToList

            End Using

            Return MaxJson(DepartmentTeam, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function SearchJobEstimate(ByVal OfficeCode As String,
                                  ByVal ClientCode As String,
                                  ByVal DivisionCode As String,
                                  ByVal ProductCode As String,
                                  ByVal AccountExecutive As String,
                                  Optional ByVal CampaignID As Integer = 0,
                                  Optional ByVal SalesClass As String = "",
                                  Optional ByVal JobType As String = "",
                                  Optional ByVal ShowClosedJobs As Boolean = False,
                                  Optional ByVal Text As String = "",
                                  Optional ByVal Skip As Integer = 0,
                                  Optional ByVal Take As Integer = 0) As JsonResult

            Dim totalRows As Integer = 0
            Dim CompareClientCode As Boolean = Not String.IsNullOrWhiteSpace(ClientCode)
            Dim CompareDivisionCode As Boolean = Not String.IsNullOrWhiteSpace(DivisionCode)
            Dim CompareProductCode As Boolean = Not String.IsNullOrWhiteSpace(ProductCode)
            Dim CompareOfficeCode As Boolean = Not String.IsNullOrWhiteSpace(OfficeCode)
            'objects
            Dim Jobs As IEnumerable
            Dim Jobst As Generic.List(Of JobDDDTO) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@AccountExecutive", AccountExecutive))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", SalesClass))
                arParams.Add(New SqlParameter("@JobType", JobType))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@Text", Text))
                arParams.Add(New SqlParameter("@Skip", Skip))
                arParams.Add(New SqlParameter("@Take", Take))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@TotalRows"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                Jobst = (From Item In DbContext.Database.SqlQuery(Of JobDDDTO)("usp_wv_dd_JobJacket_Estimates_Paging  @UserID,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@Text,@Skip,@Take,@TotalRows OUT", arParams.ToArray)).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

                Jobs = Jobst.Select(Function(Item) New With {
                            .Code = Item.Code,
                            .Name = AdvantageFramework.StringUtilities.PadWithCharacter(Item.Code, 6, "0", True, True) _
                                & " - " & Item.Name _
                                & If(CompareClientCode Or CompareDivisionCode Or CompareProductCode,
                                "",
                                " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode, "", "/" & Item.ProductCode) & ")")})
            End Using

            Return MaxJson(New With {.Jobs = Jobs, .Total = totalRows}, JsonRequestBehavior.AllowGet)

        End Function

        Public Function SearchJobIndexEstimate(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False) As JsonResult

            Dim index As Integer = -1

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", If(JobCode IsNot Nothing, JobCode, "")))
                arParams.Add(New SqlParameter("@AccountExecutive", If(AccountExecutive IsNot Nothing, AccountExecutive, "")))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", If(SalesClass IsNot Nothing, SalesClass, "")))
                arParams.Add(New SqlParameter("@JobType", If(JobType IsNot Nothing, JobType, "")))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@Index"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetAllJobs_Estimates_Index] @UserID, @OfficeCode, @ClientCode, @DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchJobNumber() As JsonResult

            'objects
            Dim Jobs As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Jobs = (From Item In DbContext.JobViews
                        Where Item.IsOpen = 1
                        Select Item).ToList.Select(Function(Entity) New With {.Code = Entity.JobNumber, .Name = Entity.JobNumber.ToString})

            End Using

            Return MaxJson(Jobs, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchComponent(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False,
                                        Optional ByVal SprintID As Integer = 0,
                                        Optional ByVal Skip As Integer = 0,
                                        Optional ByVal Take As Integer = 0) As JsonResult

            'objects
            Dim JobComponents As IEnumerable = Nothing
            Dim JobComponentViews As Generic.List(Of JobCompDDDTO) = Nothing

            Dim FilterJobNumber As Boolean = Not String.IsNullOrWhiteSpace(JobCode)
            Dim CompareClientCode As Boolean = Not String.IsNullOrWhiteSpace(ClientCode)
            Dim CompareDivisionCode As Boolean = Not String.IsNullOrWhiteSpace(DivisionCode)
            Dim CompareProductCode As Boolean = Not String.IsNullOrWhiteSpace(ProductCode)
            Dim totalRows As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", If(JobCode IsNot Nothing, JobCode, "")))
                arParams.Add(New SqlParameter("@AccountExecutive", If(AccountExecutive IsNot Nothing, AccountExecutive, "")))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", If(SalesClass IsNot Nothing, SalesClass, "")))
                arParams.Add(New SqlParameter("@JobType", If(JobType IsNot Nothing, JobType, "")))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@SprintID", SprintID))
                arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
                arParams.Add(New SqlParameter("@Skip", Skip))
                arParams.Add(New SqlParameter("@Take", Take))
                If Me.SecuritySession.ClientPortalUser IsNot Nothing Then
                    arParams.Add(New SqlParameter("@CPID", Me.SecuritySession.ClientPortalUser.ClientContactID))
                Else
                    arParams.Add(New SqlParameter("@CPID", 0))
                End If
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@TotalRows"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                JobComponentViews = (From Item In DbContext.Database.SqlQuery(Of JobCompDDDTO)("usp_wv_dd_GetAllJobComps_Paging @UserID, @OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@SprintID,@Text,@Skip,@Take,@CPID, @TotalRows out", arParams.ToArray)).ToList
                'open jobs. Please use client filters first.

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

                JobComponents = (From Item In JobComponentViews
                                 Select New With {.Code = Item.JobCompCode,
                                                .ID = Item.ID,
                                                .OfficeCode = Item.OfficeCode,
                                                .ClientCode = Item.ClientCode,
                                                .DivisionCode = Item.DivisionCode,
                                                .ProductCode = Item.ProductCode,
                                                .JobCode = Item.JobCode,
                                                .Description = Item.Name,
                                                .Name = If(FilterJobNumber, "", AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCode, 6, "0", True, True) & "/") &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCompCode, 3, "0", True, True) & " - " &
                                                        Item.Name & If(CompareClientCode Or CompareDivisionCode Or CompareProductCode,
                                                        "",
                                                        " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode, "", "/" & Item.ProductCode) & ")")}).ToList
            End Using

            Return MaxJson(New With {.JobComponents = JobComponents, .Total = totalRows}, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function SearchComponentIndex(Optional ByVal OfficeCode As String = "",
                                        Optional ByVal ClientCode As String = "",
                                        Optional ByVal DivisionCode As String = "",
                                        Optional ByVal ProductCode As String = "",
                                        Optional ByVal JobCode As String = "",
                                        Optional ByVal CompenentID As Integer = 0,
                                        Optional ByVal AccountExecutive As String = "",
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False,
                                        Optional ByVal SprintID As Integer = 0) As JsonResult

            Dim index As Integer = -1

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", If(JobCode IsNot Nothing, JobCode, "")))
                arParams.Add(New SqlParameter("@CompenentID", CompenentID))
                arParams.Add(New SqlParameter("@AccountExecutive", If(AccountExecutive IsNot Nothing, AccountExecutive, "")))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", If(SalesClass IsNot Nothing, SalesClass, "")))
                arParams.Add(New SqlParameter("@JobType", If(JobType IsNot Nothing, JobType, "")))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@SprintID", SprintID))
                arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@Index"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetAllJobComps_Index] @UserID, @OfficeCode, @ClientCode, @DivisionCode,@ProductCode,@JobCode,@CompenentID,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@SprintID, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function


        <HttpGet>
        Public Function SearchComponentFromTimesheet(ByVal OfficeCode As String,
                                                     ByVal ClientCode As String,
                                                     ByVal DivisionCode As String,
                                                     ByVal ProductCode As String,
                                                     ByVal JobCode As String,
                                                     ByVal AccountExecutive As String,
                                                     Optional ByVal Text As String = "",
                                                     Optional ByVal CampaignID As String = "",
                                                     Optional ByVal SalesClass As String = "",
                                                     Optional ByVal JobType As String = "",
                                                     Optional ByVal ShowClosedJobs As Boolean = False,
                                                     Optional ByVal SprintID As String = "",
                                                     Optional ByVal Skip As String = "",
                                                     Optional ByVal Take As String = "") As JsonResult

            'objects
            Dim JobComponents As IEnumerable = Nothing
            Dim JobComponentViews As Generic.List(Of JobCompDDDTO) = Nothing
            Dim FilterJobNumber As Boolean = Not String.IsNullOrWhiteSpace(JobCode)
            Dim CompareClientCode As Boolean = Not String.IsNullOrWhiteSpace(ClientCode)
            Dim CompareDivisionCode As Boolean = Not String.IsNullOrWhiteSpace(DivisionCode)
            Dim CompareProductCode As Boolean = Not String.IsNullOrWhiteSpace(ProductCode)
            Dim totalRows As Integer = 0
            Dim JobNumber As Integer = 0
            Dim arParams As New List(Of SqlParameter)

            Dim IntCampaignID As Integer = 0
            Dim IntSprintID As Integer = 0
            Dim IntSkip As Integer = 0
            Dim IntTake As Integer = 0

            Try

                If String.IsNullOrWhiteSpace(CampaignID) = False AndAlso IsNumeric(CampaignID) = True Then

                    IntCampaignID = CType(CampaignID, Integer)

                End If

            Catch ex As Exception
            End Try
            Try

                If String.IsNullOrWhiteSpace(SprintID) = False AndAlso IsNumeric(SprintID) = True Then

                    IntSprintID = CType(SprintID, Integer)

                End If

            Catch ex As Exception
            End Try
            Try

                If String.IsNullOrWhiteSpace(Skip) = False AndAlso IsNumeric(Skip) = True Then

                    IntSkip = CType(Skip, Integer)

                End If

            Catch ex As Exception
            End Try
            Try

                If String.IsNullOrWhiteSpace(Take) = False AndAlso IsNumeric(Take) = True Then

                    IntTake = CType(Take, Integer)

                End If

            Catch ex As Exception
            End Try

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Try
                    If String.IsNullOrWhiteSpace(JobCode) = False AndAlso
                        IsNumeric(JobCode) = True Then

                        JobNumber = CType(JobCode, Integer)

                    End If
                Catch ex As Exception
                    JobNumber = 0
                End Try
                Try

                    Text = RebuildJobComponentSearchText(Text, "/")

                Catch ex As Exception
                End Try
                Try

                    Text = RebuildJobComponentSearchText(Text, "-")

                Catch ex As Exception
                End Try
                Try

                    Text = RebuildJobComponentSearchText(Text, ",")

                Catch ex As Exception
                End Try
                Try

                    Text = RebuildJobComponentSearchText(Text, "\")

                Catch ex As Exception
                End Try
                Try

                    Text = RebuildJobComponentSearchText(Text, "|")

                Catch ex As Exception
                End Try

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(String.IsNullOrWhiteSpace(OfficeCode) = False, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(String.IsNullOrWhiteSpace(ClientCode) = False, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(String.IsNullOrWhiteSpace(DivisionCode) = False, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(String.IsNullOrWhiteSpace(ProductCode) = False, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", JobNumber))
                arParams.Add(New SqlParameter("@AccountExecutive", If(String.IsNullOrWhiteSpace(AccountExecutive) = False, AccountExecutive, "")))
                arParams.Add(New SqlParameter("@CampaignID", IntCampaignID))
                arParams.Add(New SqlParameter("@SalesClass", If(String.IsNullOrWhiteSpace(SalesClass) = False, SalesClass, "")))
                arParams.Add(New SqlParameter("@JobType", If(String.IsNullOrWhiteSpace(JobType) = False, JobType, "")))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@SprintID", IntSprintID))
                arParams.Add(New SqlParameter("@Text", If(String.IsNullOrWhiteSpace(Text) = False, Text, "")))
                arParams.Add(New SqlParameter("@Skip", IntSkip))
                arParams.Add(New SqlParameter("@Take", IntTake))

                If Me.SecuritySession.ClientPortalUser IsNot Nothing Then

                    Try

                        arParams.Add(New SqlParameter("@CPID", Me.SecuritySession.ClientPortalUser.ClientContactID))

                    Catch ex As Exception
                        arParams.Add(New SqlParameter("@CPID", 0))
                    End Try

                Else

                    arParams.Add(New SqlParameter("@CPID", 0))

                End If

                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@TotalRows"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output

                arParams.Add(outParam)

                JobComponentViews = (From Item In DbContext.Database.SqlQuery(Of JobCompDDDTO)("EXEC [dbo].[advsp_lookup_ts_job_component_paging] @UserID, @OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@SprintID,@Text,@Skip,@Take,@CPID, @TotalRows out", arParams.ToArray)).ToList
                'open jobs. Please use client filters first.

                Try

                    If IsDBNull(outParam.Value) = False AndAlso IsNumeric(outParam.Value) = True Then

                        totalRows = outParam.Value

                    End If

                Catch ex As Exception
                End Try

                JobComponents = (From Item In JobComponentViews
                                 Select New With {.Code = Item.JobCompCode,
                                                .ID = Item.ID,
                                                .OfficeCode = Item.OfficeCode,
                                                .ClientCode = Item.ClientCode,
                                                .DivisionCode = Item.DivisionCode,
                                                .ProductCode = Item.ProductCode,
                                                .JobCode = Item.JobCode,
                                                .Description = Item.Name,
                                                .Name = If(FilterJobNumber, "", AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCode, 6, "0", True, True) & "/") &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCompCode, 3, "0", True, True) & " - " &
                                                        IIf(Item.JobDescription = Item.JobComponentDescription, Item.JobComponentDescription, Item.JobDescription & " - " & Item.JobComponentDescription) & If(CompareClientCode Or CompareDivisionCode Or CompareProductCode,
                                                        "",
                                                        " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode, "", "/" & Item.ProductCode) & ")")}).ToList
            End Using

            Return MaxJson(New With {.JobComponents = JobComponents, .Total = totalRows}, JsonRequestBehavior.AllowGet)
        End Function
        Private Function RebuildJobComponentSearchText(ByVal SearchValue As String, ByVal SplitCharacter As String) As String

            Dim ar() As String
            Dim ReturnValue As String = SearchValue

            Try

                If SearchValue.Contains(SplitCharacter) = True Then

                    ar = SearchValue.Split(SplitCharacter)

                    If ar.Length = 2 Then

                        If IsNumeric(ar(0).Trim()) = True AndAlso IsNumeric(ar(1).Trim()) = True Then

                            ReturnValue = ar(0).Trim().ToString().PadLeft(6, "0") & "/" & ar(1).Trim().ToString().PadLeft(3, "0")

                        End If

                    End If

                End If

            Catch ex As Exception
                ReturnValue = SearchValue
            End Try

            Return ReturnValue

        End Function
        <HttpGet>
        Public Function SearchComponentIndexFromTimesheet(Optional ByVal OfficeCode As String = "",
                                                          Optional ByVal ClientCode As String = "",
                                                          Optional ByVal DivisionCode As String = "",
                                                          Optional ByVal ProductCode As String = "",
                                                          Optional ByVal JobCode As String = "",
                                                          Optional ByVal CompenentID As Integer = 0,
                                                          Optional ByVal AccountExecutive As String = "",
                                                          Optional ByVal Text As String = "",
                                                          Optional ByVal CampaignID As Integer = 0,
                                                          Optional ByVal SalesClass As String = "",
                                                          Optional ByVal JobType As String = "",
                                                          Optional ByVal ShowClosedJobs As Boolean = False,
                                                          Optional ByVal SprintID As Integer = 0) As JsonResult

            Dim index As Integer = -1

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim arParams As New List(Of SqlParameter)
                    Dim outParam As SqlParameter = New SqlParameter()

                    arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                    arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                    arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                    arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                    arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                    arParams.Add(New SqlParameter("@JobCode", If(JobCode IsNot Nothing, JobCode, "")))
                    arParams.Add(New SqlParameter("@CompenentID", CompenentID))
                    arParams.Add(New SqlParameter("@AccountExecutive", If(AccountExecutive IsNot Nothing, AccountExecutive, "")))
                    arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                    arParams.Add(New SqlParameter("@SalesClass", If(SalesClass IsNot Nothing, SalesClass, "")))
                    arParams.Add(New SqlParameter("@JobType", If(JobType IsNot Nothing, JobType, "")))
                    arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                    arParams.Add(New SqlParameter("@SprintID", SprintID))
                    arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))

                    outParam.SqlDbType = System.Data.SqlDbType.Int
                    outParam.ParameterName = "@Index"
                    outParam.Value = 0
                    outParam.Direction = System.Data.ParameterDirection.Output

                    arParams.Add(outParam)

                    DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_lookup_ts_job_component_index] @UserID, @OfficeCode, @ClientCode, @DivisionCode,@ProductCode,@JobCode,@CompenentID,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@SprintID, @Text, @Index out", arParams.ToArray)

                    If Not IsDBNull(outParam.Value) Then

                        index = outParam.Value

                    End If

                End Using

            Catch ex As Exception
            End Try

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function SearchComponentPS(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False,
                                        Optional ByVal SprintID As Integer = 0,
                                        Optional ByVal Skip As Integer = 0,
                                        Optional ByVal Take As Integer = 0) As JsonResult

            'objects
            Dim JobComponents As IEnumerable = Nothing
            Dim JobComponentViews As Generic.List(Of JobCompDDDTO) = Nothing
            Dim totalRows As Integer = 0

            Dim FilterJobNumber As Boolean = Not String.IsNullOrWhiteSpace(JobCode)
            Dim CompareClientCode As Boolean = Not String.IsNullOrWhiteSpace(ClientCode)
            Dim CompareDivisionCode As Boolean = Not String.IsNullOrWhiteSpace(DivisionCode)
            Dim CompareProductCode As Boolean = Not String.IsNullOrWhiteSpace(ProductCode)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", JobCode))
                arParams.Add(New SqlParameter("@AccountExecutive", AccountExecutive))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", SalesClass))
                arParams.Add(New SqlParameter("@JobType", JobType))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
                arParams.Add(New SqlParameter("@Skip", Skip))
                arParams.Add(New SqlParameter("@Take", Take))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@TotalRows"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                JobComponentViews = (From Item In DbContext.Database.SqlQuery(Of JobCompDDDTO)("usp_wv_dd_GetAllJobComps_PS_Paging @UserID,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@Text,@Skip,@Take, @TotalRows out", arParams.ToArray)).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

                JobComponents = (From Item In JobComponentViews
                                 Select New With {.Code = Item.JobCompCode,
                                                .ID = Item.ID,
                                                .OfficeCode = Item.OfficeCode,
                                                .ClientCode = Item.ClientCode,
                                                .DivisionCode = Item.DivisionCode,
                                                .ProductCode = Item.ProductCode,
                                                .JobCode = Item.JobCode,
                                                .Description = Item.Name,
                                                .Name = If(FilterJobNumber, "", AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCode, 6, "0", True, True) & "/") &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCompCode, 3, "0", True, True) & " - " &
                                                        Item.Name & If(CompareClientCode Or CompareDivisionCode Or CompareProductCode,
                                                        "",
                                                        " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode, "", "/" & Item.ProductCode) & ")")}).ToList

            End Using

            Return MaxJson(New With {.JobComponents = JobComponents, .Total = totalRows}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchComponentIndexPS(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal CompenentID As Integer,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False) As JsonResult

            Dim index As Integer = -1

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", If(JobCode IsNot Nothing, JobCode, "")))
                arParams.Add(New SqlParameter("@CompenentID", CompenentID))
                arParams.Add(New SqlParameter("@AccountExecutive", If(AccountExecutive IsNot Nothing, AccountExecutive, "")))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", If(SalesClass IsNot Nothing, SalesClass, "")))
                arParams.Add(New SqlParameter("@JobType", If(JobType IsNot Nothing, JobType, "")))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@Index"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetAllJobComps_PS_Index] @UserID, @OfficeCode, @ClientCode, @DivisionCode,@ProductCode,@JobCode,@CompenentID,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function


        <HttpGet>
        Public Function SearchJobCompEstimate(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False,
                                        Optional ByVal SprintID As Integer = 0,
                                        Optional ByVal Skip As Integer = 0,
                                        Optional ByVal Take As Integer = 0) As JsonResult

            'objects
            Dim JobComponents As IEnumerable = Nothing
            Dim FilterJobNumber As Boolean = False
            Dim JobComponentViews As Generic.List(Of JobCompDDDTO) = Nothing

            Dim totalRows As Integer = 0

            FilterJobNumber = Not String.IsNullOrWhiteSpace(JobCode)
            Dim CompareClientCode As Boolean = Not String.IsNullOrWhiteSpace(ClientCode)
            Dim CompareDivisionCode As Boolean = Not String.IsNullOrWhiteSpace(DivisionCode)
            Dim CompareProductCode As Boolean = Not String.IsNullOrWhiteSpace(ProductCode)

            Dim arParams As New List(Of SqlParameter)

            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
            arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
            arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
            arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
            arParams.Add(New SqlParameter("@JobCode", JobCode))
            arParams.Add(New SqlParameter("@AccountExecutive", AccountExecutive))
            arParams.Add(New SqlParameter("@CampaignID", CampaignID))
            arParams.Add(New SqlParameter("@SalesClass", SalesClass))
            arParams.Add(New SqlParameter("@JobType", JobType))
            arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
            arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
            arParams.Add(New SqlParameter("@Skip", Skip))
            arParams.Add(New SqlParameter("@Take", Take))
            Dim outParam As SqlParameter = New SqlParameter()
            outParam.SqlDbType = System.Data.SqlDbType.Int
            outParam.ParameterName = "@TotalRows"
            outParam.Value = 0
            outParam.Direction = System.Data.ParameterDirection.Output
            arParams.Add(outParam)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobComponentViews = (From Item In DbContext.Database.SqlQuery(Of JobCompDDDTO)("usp_wv_dd_GetAllJobComps_Estimates_Paging  @UserID,@OfficeCode,@ClientCode,@DivisionCode,@ProductCode,@JobCode,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed,@Text,@Skip,@Take, @TotalRows out", arParams.ToArray)).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

                JobComponents = (From Item In JobComponentViews
                                 Select New With {.Code = Item.JobCompCode,
                                                .ID = Item.ID,
                                                .OfficeCode = Item.OfficeCode,
                                                .ClientCode = Item.ClientCode,
                                                .DivisionCode = Item.DivisionCode,
                                                .ProductCode = Item.ProductCode,
                                                .JobCode = Item.JobCode,
                                                .Description = Item.Name,
                                                .Name = If(FilterJobNumber, "", AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCode, 6, "0", True, True) & "/") &
                                                        AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCompCode, 3, "0", True, True) & " - " &
                                                        Item.Name & If(CompareClientCode Or CompareDivisionCode Or CompareProductCode,
                                                        "",
                                                        " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode, "", "/" & Item.ProductCode) & ")")}).ToList

            End Using

            Return MaxJson(New With {.JobComponents = JobComponents, .Total = totalRows}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchComponentIndexEstimate(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal CompenentID As Integer,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal Text As String = "",
                                        Optional ByVal CampaignID As Integer = 0,
                                        Optional ByVal SalesClass As String = "",
                                        Optional ByVal JobType As String = "",
                                        Optional ByVal ShowClosedJobs As Boolean = False) As JsonResult

            Dim index As Integer = -1

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", If(OfficeCode IsNot Nothing, OfficeCode, "")))
                arParams.Add(New SqlParameter("@ClientCode", If(ClientCode IsNot Nothing, ClientCode, "")))
                arParams.Add(New SqlParameter("@DivisionCode", If(DivisionCode IsNot Nothing, DivisionCode, "")))
                arParams.Add(New SqlParameter("@ProductCode", If(ProductCode IsNot Nothing, ProductCode, "")))
                arParams.Add(New SqlParameter("@JobCode", If(JobCode IsNot Nothing, JobCode, "")))
                arParams.Add(New SqlParameter("@CompenentID", CompenentID))
                arParams.Add(New SqlParameter("@AccountExecutive", If(AccountExecutive IsNot Nothing, AccountExecutive, "")))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", If(SalesClass IsNot Nothing, SalesClass, "")))
                arParams.Add(New SqlParameter("@JobType", If(JobType IsNot Nothing, JobType, "")))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedJobs = True, 1, 0)))
                arParams.Add(New SqlParameter("@Text", If(Text IsNot Nothing, Text, "")))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@Index"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                DbContext.Database.ExecuteSqlCommand("EXEC [dbo].[usp_wv_dd_GetAllJobComps_Estimate_Index] @UserID, @OfficeCode, @ClientCode, @DivisionCode,@ProductCode,@JobCode,@CompenentID,@AccountExecutive,@CampaignID,@SalesClass,@JobType,@ShowClosed, @Text, @Index out", arParams.ToArray)

                If Not IsDBNull(outParam.Value) Then
                    index = outParam.Value
                End If

            End Using

            Return MaxJson(index, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchComponent_v2(ByVal OfficeCode As String,
                                        ByVal ClientCode As String,
                                        ByVal DivisionCode As String,
                                        ByVal ProductCode As String,
                                        ByVal JobCode As String,
                                        ByVal AccountExecutive As String,
                                        Optional ByVal ShowClosedJobs As Boolean = False) As JsonResult

            'objects
            Dim JobComponents As IEnumerable = Nothing
            Dim FilterJobNumber As Boolean = False
            Dim JobComponentViews As Generic.List(Of JobCompDDDTO) = Nothing

            FilterJobNumber = Not String.IsNullOrWhiteSpace(JobCode)
            Dim CompareClientCode As Boolean = Not String.IsNullOrWhiteSpace(ClientCode)
            Dim CompareDivisionCode As Boolean = Not String.IsNullOrWhiteSpace(DivisionCode)
            Dim CompareProductCode As Boolean = Not String.IsNullOrWhiteSpace(ProductCode)

            Dim arParams As New List(Of SqlParameter)
            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@ShowClosedJobs", If(ShowClosedJobs, 1, 0)))

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                JobComponents = (From Item In DbContext.Database.SqlQuery(Of JobCompDDDTO)("usp_wv_dd_GetAllJobCompsJJ_V2 @UserID, @ShowClosedJobs", arParams.ToArray)
                                 Where Item.JobCode = If(FilterJobNumber, JobCode, Item.JobCode) AndAlso
                                        Item.ClientCode = If(CompareClientCode, ClientCode, Item.ClientCode) AndAlso
                                        Item.DivisionCode = If(CompareDivisionCode, DivisionCode, Item.DivisionCode) AndAlso
                                        Item.ProductCode = If(CompareProductCode, ProductCode, Item.ProductCode) AndAlso
                                        Item.OfficeCode = If(String.IsNullOrWhiteSpace(OfficeCode), Item.OfficeCode, OfficeCode)
                                 Order By Item.JobCode Descending, Item.JobCompCode
                                 Select New With {.Code = Item,
                                                      .Name = If(FilterJobNumber, "", AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCode, 6, "0", True, True) & "/") &
                                                              AdvantageFramework.StringUtilities.PadWithCharacter(Item.JobCompCode, 3, "0", True, True) & " - " &
                                                              Item.Name & If(CompareClientCode Or CompareDivisionCode Or CompareProductCode,
                                "",
                                " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode, "", "/" & Item.ProductCode) & ")")}).ToList
            End Using

            Return MaxJson(JobComponents, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchAccountExecutive(ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As JsonResult

            Dim AccountExecutives As IEnumerable = Nothing
            Dim dr As SqlDataReader
            Dim arParams(4) As SqlParameter

            Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
            parameterDivisionCode.Value = DivisionCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
            parameterProductCode.Value = ProductCode
            arParams(2) = parameterProductCode

            Dim parameterUserID As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            parameterUserID.Value = Me.SecuritySession.UserCode
            arParams(3) = parameterUserID

            Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
            parameterOfficeCode.Value = OfficeCode
            arParams(4) = parameterOfficeCode

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                AccountExecutives = (From Item In DbContext.Database.SqlQuery(Of SaleClassDDDTO)("EXEC [dbo].[usp_wv_dd_account_executive] @Client, @Division, @Product, @USER_CODE, @OfficeCode", arParams)
                                     Select New With {
                                        .Code = Item.Code,
                                        .Name = Item.Name + " (" + Item.Code + ")"
                                        }).ToList
            End Using

            Return MaxJson(AccountExecutives, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function SearchJobType(ByVal SalesClassCode As String, Optional ByVal Text As String = "", Optional ByVal Skip As Integer = 0, Optional ByVal Take As Integer = 0) As JsonResult

            'objects
            Dim JobTypes As IEnumerable = Nothing
            Dim totalRows As Integer

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@SalesClassCode", SalesClassCode))
                arParams.Add(New SqlParameter("@Text", Text))
                arParams.Add(New SqlParameter("@Skip", Skip))
                arParams.Add(New SqlParameter("@Take", Take))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@TotalRows"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                JobTypes = (From Item In DbContext.Database.SqlQuery(Of JobTypeDDDTO)("EXEC [dbo].[usp_wv_dd_JobType_Paging] @SalesClassCode, @Text, @Skip, @Take, @TotalRows OUTPUT", arParams.ToArray) Select New With {
                                        .Code = Item.Code,
                                        .Name = Item.Name + " (" + Item.Code + ")"
                                        }).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If


            End Using

            Return MaxJson(New With {.JobTypes = JobTypes, .Total = totalRows}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchStatus() As JsonResult

            'objects
            Dim Statuses As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Statuses = (From Item In DbContext.Status
                            Where Item.IsInactive Is Nothing OrElse Item.IsInactive = 0
                            Order By Item.Description
                            Select New With {.Code = Item.Code, .Name = Item.Description}).ToList

            End Using

            Return MaxJson(Statuses, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchCampaign(OfficeCode As String,
                                       ClientCode As String,
                                       DivisionCode As String,
                                       ProductCode As String,
                                       Optional ByVal InclClosed As Boolean = False) As JsonResult

            Dim Campaigns As IEnumerable = Nothing
            Dim arParams(5) As SqlParameter

            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = Me.SecuritySession.UserCode
            arParams(0) = parameterUserID

            Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 4)
            parameterOfficeCode.Value = OfficeCode
            arParams(1) = parameterOfficeCode

            Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClientCode.Value = ClientCode
            arParams(2) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivisionCode.Value = DivisionCode
            arParams(3) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProductCode.Value = ProductCode
            arParams(4) = parameterProductCode

            Dim parameterInclClosed As New SqlParameter("@InclClosed", SqlDbType.Int)
            parameterInclClosed.Value = InclClosed
            arParams(5) = parameterInclClosed

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Campaigns = (From Item In DbContext.Database.SqlQuery(Of CampaignDDDTO)("EXEC [dbo].[usp_wv_campaign_search_popup_v2] @UserID, @OfficeCode, @ClientCode, @DivisionCode, @ProductCode, @InclClosed", arParams)
                             Select New With {
                                    .Code = Item.Code,
                                    .ID = Item.ID,
                                    .Name = Item.Code & " - " + Item.Name & " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode Or Item.DivisionCode = Nothing, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode Or Item.ProductCode = Nothing, "", "/" & Item.ProductCode) & ")"
                                        }).ToList
            End Using

            Return MaxJson(Campaigns, JsonRequestBehavior.AllowGet)

        End Function

        <System.Web.Mvc.HttpGet>
        Public Function SearchEmployee(Optional ShowTerminatedEmployees As Boolean = False, Optional Role As String = Nothing, Optional TaskCode As String = Nothing) As JsonResult

            Dim Employees As IEnumerable = Nothing

            Dim arParams As New List(Of SqlParameter)

            If (String.IsNullOrWhiteSpace(Role) AndAlso String.IsNullOrWhiteSpace(TaskCode)) Then

                arParams.Add(New SqlParameter("@USER_CODE", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@SHOW_ALL", If(ShowTerminatedEmployees, 1, 0)))
                arParams.Add(New SqlParameter("@OVERRIDE_SEC_EMP", 0))
                arParams.Add(New SqlParameter("@FROM_TS", 0))

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Employees = (From Item In DbContext.Database.SqlQuery(Of EmployeeDDDTO)("exec usp_wv_dd_GetEmpCodes @USER_CODE, @SHOW_ALL, @OVERRIDE_SEC_EMP, @FROM_TS", arParams.ToArray)
                                 Select New With {
                                     .Code = Item.Code,
                                     .Name = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName + " (" + Item.Code + ")",
                                     .NameOnly = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName,
                                     .Title = Item.Title
                                         }
                                     ).ToList

                End Using
            Else
                arParams.Add(New SqlParameter("@USER_CODE", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@Role", If(Role IsNot Nothing, Role, DBNull.Value)))
                arParams.Add(New SqlParameter("@TaskCode", If(TaskCode IsNot Nothing, TaskCode, DBNull.Value)))

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                    Employees = (From Item In DbContext.Database.SqlQuery(Of EmployeeDDDTO)("exec usp_wv_dd_GetEmpCodesByRole @USER_CODE, @Role,@TaskCode", arParams.ToArray)
                                 Select New With {
                                     .Code = Item.Code,
                                     .Name = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName + " (" + Item.Code + ")",
                                     .NameOnly = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName,
                                     .Title = Item.Title
                                         }
                                     ).ToList
                End Using
            End If

            Return MaxJson(Employees, JsonRequestBehavior.AllowGet)

        End Function

        <System.Web.Mvc.HttpGet>
        Public Function SearchPOApprovers() As JsonResult

            Dim Employees As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                Employees = (From Item In DbContext.Database.SqlQuery(Of EmployeeDDDTO)("exec proc_WV_PO_Approvers_LoadAll")
                             Select New With {
                                 .Code = Item.Code,
                                 .Name = Item.FirstName + " " + If(String.IsNullOrWhiteSpace(Item.MiddleInitial), "", Item.MiddleInitial + ". ") + Item.LastName + " (" + Item.Code + ")"
                                     }
                                 ).ToList

            End Using

            Return MaxJson(Employees, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchPONumber(ByVal OmitVoided As Boolean, ByVal OmitClosed As Boolean) As JsonResult
            Dim PONumber As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@USER_CODE", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OmitVoided", If(OmitVoided, "true", "false")))
                arParams.Add(New SqlParameter("@OmitClosed", If(OmitClosed, "true", "false")))

                PONumber = (From Item In DbContext.Database.SqlQuery(Of PONumberDDDTO)("exec usp_wv_dd_po @OmitVoided, @OmitClosed, @USER_CODE", arParams.ToArray)
                            Select New With {
                                 .Code = Item.code,
                                 .Name = Item.description
                                     }
                                 ).ToList


                'PONumber = (From PO In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.PurchaseOrder)
                '            Where PO.IsVoid = If(OmitVoided, 0S, PO.IsVoid) And
                '                PO.IsComplete = If(OmitClosed, 0S, PO.IsComplete)
                '            Order By PO.Number
                '            Select New With {
                '                    .Code = PO.Number.ToString,
                '                    .Name = PO.Number.ToString + " - " + PO.Description
                '                }).ToList
            End Using

            Return MaxJson(PONumber, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchVendor() As JsonResult
            Dim Vendors As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Vendors = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext)
                           Select New With {
                                   .Code = Vendor.Code,
                                   .Name = Vendor.Name + " (" + Vendor.Code + ")"
                                   }).ToList

            End Using

            Return MaxJson(Vendors, JsonRequestBehavior.AllowGet)

        End Function

        <System.Web.Mvc.HttpGet>
        Public Function SearchEstimateNumber(OfficeCode As String,
                                       ClientCode As String,
                                       DivisionCode As String,
                                       ProductCode As String,
                                       Optional ByVal CampaignID As Integer = 0,
                                       Optional ByVal SalesClass As String = "",
                                       Optional ByVal JobCode As Integer = 0,
                                       Optional ByVal ComponentCode As Short = 0) As JsonResult
            Dim Estmates As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@ClientCode", ClientCode))
                arParams.Add(New SqlParameter("@DivisionCode", DivisionCode))
                arParams.Add(New SqlParameter("@ProductCode", ProductCode))
                arParams.Add(New SqlParameter("@JobCode", JobCode))
                arParams.Add(New SqlParameter("@ComponentCode", ComponentCode))
                arParams.Add(New SqlParameter("@OfficeCode", OfficeCode))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", SalesClass))

                Estmates = (From Item In DbContext.Database.SqlQuery(Of EstimateDDDTO)("EXEC [dbo].[usp_wv_dd_GetEstimates]  @ClientCode, @DivisionCode, @ProductCode, @UserID, @JobCode, @ComponentCode, @OfficeCode, @CampaignID, @SalesClass", arParams.ToArray) Select New With {
                                   .Code = Item.Code,
                                   .Name = Item.Code.ToString.PadLeft(6, "0") + " - " + Item.Name & " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode Or Item.DivisionCode = Nothing, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode Or Item.ProductCode = Nothing, "", "/" & Item.ProductCode) & ")"
                                   }).ToList

            End Using

            Return MaxJson(Estmates, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchEstimateCompNumber(OfficeCode As String,
                                       ClientCode As String,
                                       DivisionCode As String,
                                       ProductCode As String,
                                       Optional ByVal CampaignID As Integer = 0,
                                       Optional ByVal SalesClass As String = "",
                                       Optional ByVal JobCode As Integer = 0,
                                       Optional ByVal ComponentCode As Short = 0,
                                       Optional ByVal EstimateCode As Integer = 0) As JsonResult
            Dim Estmates As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)

                arParams.Add(New SqlParameter("@ClientCode", ClientCode))
                arParams.Add(New SqlParameter("@DivisionCode", DivisionCode))
                arParams.Add(New SqlParameter("@ProductCode", ProductCode))
                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@EstimateCode", EstimateCode))
                arParams.Add(New SqlParameter("@JobCode", JobCode))
                arParams.Add(New SqlParameter("@ComponentCode", ComponentCode))
                arParams.Add(New SqlParameter("@OfficeCode", OfficeCode))
                arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                arParams.Add(New SqlParameter("@SalesClass", SalesClass))

                Estmates = (From Item In DbContext.Database.SqlQuery(Of EstimateComponentDDDTO)("EXEC [dbo].[usp_wv_dd_GetEstimateComp_v2] @ClientCode, @DivisionCode, @ProductCode, @UserID, @EstimateCode, @JobCode, @ComponentCode, @OfficeCode, @CampaignID, @SalesClass", arParams.ToArray) Select New With {
                                   .Code = Item,
                                   .Name = If(EstimateCode > 0, "", Item.EstimateCode.ToString.PadLeft(6, "0") & "/") + Item.Code.ToString.PadLeft(3, "0") & " - " + Item.Name & " (" & Item.ClientCode & If(Item.ClientCode = Item.DivisionCode Or Item.DivisionCode = Nothing, "", "/" & Item.DivisionCode) & If(Item.DivisionCode = Item.ProductCode Or Item.ProductCode = Nothing, "", "/" & Item.ProductCode) & ")"
                                   }).ToList

            End Using

            Return MaxJson(Estmates, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchVenderFunctions() As JsonResult
            Dim Estmates As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))

                Estmates = (From Item In DbContext.Database.SqlQuery(Of ClientDDDTO)("EXEC [dbo].[usp_wv_dd_GetFunctions_Vendor] @UserID", arParams.ToArray) Select New With {
                                   .Code = Item.Code,
                                   .Name = Item.Name + " (" + Item.Code + ")"
                                   }).ToList

            End Using

            Return MaxJson(Estmates, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchFunctions() As JsonResult
            Dim Estmates As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))

                ' @UserID", arParams.ToArray

                Estmates = (From Item In DbContext.Database.SqlQuery(Of ClientDDDTO)("EXEC [dbo].[usp_wv_dd_GetFunctions_All_CD]") Select New With {
                                   .Code = Item.Code,
                                   .Name = Item.Name + " (" + Item.Code + ")"
                                   }).ToList

            End Using

            Return MaxJson(Estmates, JsonRequestBehavior.AllowGet)

        End Function
        <HttpGet>
        Public Function SearchEstimateFunctions() As JsonResult
            Dim Estimates As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)


                ' @UserID", arParams.ToArray

                Estimates = (From Item In DbContext.Database.SqlQuery(Of JobTypeDDDTO)("select FNC_CODE Code, FNC_DESCRIPTION Name from FUNCTIONS where FNC_TYPE='E' AND FNC_INACTIVE != 1") Select New With {
                                   .Code = Item.Code,
                                   .Name = Item.Name
                                   }).ToList

            End Using

            Return MaxJson(Estimates, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetBookmarks(ByVal Search As String) As JsonResult
            Dim Bookmarks As IEnumerable
            Dim s As String

            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            Bookmarks = BmMethods.GetBookmarks(Session("UserCode"), s, Search)

            Return MaxJson(Bookmarks, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function CheckOpenByDefaultCount() As JsonResult
            Dim Count As Integer = 0
            Dim s As String

            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            Count = BmMethods.GetOpenByDefaultCount(Session("UserCode"))

            Return MaxJson(Count, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function DeleteBookmark(ByVal BookMarkID As Integer) As JsonResult

            'objects
            Dim Deleted As Boolean = False
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            Deleted = BmMethods.DeleteBookmark(BookMarkID)

            Return Json(Deleted, JsonRequestBehavior.DenyGet)

        End Function

        <HttpPost>
        Public Function UpdateBookmarkOpenByDefaultmark(ByVal BookMarkID As Integer, ByVal OpenByDefault As Boolean) As JsonResult

            'objects
            Dim Updated As Boolean = False
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            Updated = BmMethods.UpdateBookmarkOpenByDefault(BookMarkID, OpenByDefault)

            Return Json(Updated, JsonRequestBehavior.DenyGet)

        End Function


        <HttpGet>
        Public Function SearchAlertGroups() As JsonResult
            Dim AlertGroupCategory As IEnumerable

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                AlertGroupCategory = (From Item In DbContext.GetQuery(Of Database.Entities.AlertGroup)
                                      Where Item.IsInactive = 0
                                      Order By Item.Code
                                      Select New With {
                                   .Code = Item.Code,
                                   .Name = Item.Code
                                   }).Distinct().ToList
            End Using

            Return MaxJson(AlertGroupCategory, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function SearchProjectManager() As JsonResult

            Dim Employees As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Employees = (From Employee In DbContext.Database.SqlQuery(Of ManagerViewModel)("usp_wv_dd_GetManagers @USER_ID", New SqlParameter("@USER_ID", Session("UserCode")))
                             Select New With {.Code = Employee.code, .Name = Employee.EMP_FNAME + If(String.IsNullOrWhiteSpace(Employee.EMP_MI), "", " " + Employee.EMP_MI + ".") + " " + Employee.EMP_LNAME + " (" + Employee.code + ")"}
                                 ).ToList

            End Using

            Return MaxJson(Employees, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchTimeZones() As JsonResult

            Dim TimeZones As IEnumerable

            'TimeZones = AdvantageFramework.Database.Procedures.TimeZone.LoadSystemTimeZones

            'If TimeZones IsNot Nothing Then

            '    Me.RadComboBoxEmployeeTimeZone.Items.Clear()
            '    Me.RadComboBoxEmployeeTimeZone.DataSource = TimeZones
            '    Me.RadComboBoxEmployeeTimeZone.DataTextField = "StandardName"
            '    Me.RadComboBoxEmployeeTimeZone.DataValueField = "Id"
            '    Me.RadComboBoxEmployeeTimeZone.DataBind()
            '    Me.RadComboBoxEmployeeTimeZone.Items.Insert(0, New RadComboBoxItem("[Don't Change]", ""))

            'End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                TimeZones = (From Timezone In AdvantageFramework.Database.Procedures.TimeZone.LoadSystemTimeZones
                             Select New With {
                                   .Code = Timezone.Id,
                                   .Name = Timezone.StandardName
                                   }).ToList

            End Using

            Return MaxJson(TimeZones, JsonRequestBehavior.AllowGet)



        End Function

        Public Function Savetimezone(ByVal TimeZoneID As Integer)
            Dim Success As Boolean = False
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.SecuritySession.User.EmployeeCode)

                    If Employee IsNot Nothing Then

                        Employee.TimeZoneID = TimeZoneID

                        Success = AdvantageFramework.Database.Procedures.EmployeeView.Update(DbContext, DataContext, Employee)

                    End If

                    Dim EmployeePicture As AdvantageFramework.Database.Entities.EmployeePicture = Nothing


                End Using
            End Using

        End Function

        <HttpGet>
        Public Function GetDateFormat() As JsonResult
            Return MaxJson(New With {.DateFormat = LoGlo.GetDateFormat(), .DateInputFormat = LoGlo.GetDateInputFormat()}, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetLoggedInUser() As JsonResult
            Dim employee As Database.Views.Employee = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Me.SecuritySession.User.EmployeeCode)
            End Using

            Return MaxJson(New With {.Code = employee.Code, .Name = employee.FirstName & " " & employee.MiddleInitial & ". " & employee.LastName}, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetSessionTimeout() As JsonResult
            Dim TimeoutMilliseconds As Double
            Dim sss As SessionStateSection = WebConfigurationManager.GetSection("system.web/sessionState")

            If sss IsNot Nothing Then

                TimeoutMilliseconds = sss.Timeout.TotalMilliseconds

            End If

            Return MaxJson(New With {.TimeoutMilliseconds = TimeoutMilliseconds}, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function CheckJobTaskCount(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As JsonResult
            Dim Count As Integer = 0
            Dim s As String

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Count = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber).Count()

            End Using

            Return MaxJson(Count, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function EncryptPONumber(ByVal PONUmber As String) As JsonResult

            Dim strEncryption As String = AdvantageFramework.Security.Encryption.EncryptPO(PONUmber)

            Return MaxJson(strEncryption, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function SearchAdNumber(ByVal ClientCode As String) As JsonResult
            Dim AdNumbers As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                AdNumbers = (From Ad In AdvantageFramework.Database.Procedures.Ad.LoadAllActiveByClientCodeAndNotExpired(DbContext, ClientCode)
                             Select New With {.Code = Ad.Number,
                                 .Name = Ad.Number & " - " & Ad.Description}).ToList
            End Using

            Return MaxJson(AdNumbers, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function SearchMarket() As JsonResult
            Dim Markets As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Markets = (From Market In AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext)
                           Select New With {.Code = Market.Code,
                               .Name = Market.Code & " - " & Market.Description}).ToList
            End Using

            Return MaxJson(Markets, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function SearchClientWebsite(ByVal ClientCode As String) As JsonResult
            Dim ClientWebsite As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)
                ClientWebsite = (From Entity In AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, ClientCode)
                                 Where Entity.IsInactive = False
                                 Select New With {.Code = Entity.ID,
                                                  .Description = Entity.WebsiteAddress,
                                                  .WebsiteType = Entity.WebsiteType.Description,
                                                  .WebsiteName = Entity.WebsiteName
                                                         }).ToList

            End Using

            Return MaxJson(ClientWebsite, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function SearchPostPeriod()
            Dim PostPeriods As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                PostPeriods = (From Period In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveNonYearEndPostPeriods(DbContext).OrderByDescending(Function(Entity) Entity.Code)
                               Select New With {
                                   .Code = Period.Code,
                                   .Name = Period.Code & " - " & Period.Description
                                   }).ToList
            End Using

            Return MaxJson(PostPeriods, JsonRequestBehavior.AllowGet)
        End Function

        Class Task
            Public Property Code As String
            Public Property DESCRIPTION As String
            Public Property TRF_DESCRIPTION As String
            Public Property TRF_ORDER As Short?
            Public Property EST_FNC_CODE As String
            Public Property FNC_DESCRIPTION As String
        End Class

        <HttpGet>
        Function SearchTasks(Optional ByVal JobNumber As Integer = 0, Optional ByVal JobCompnentNumber As Short = 0) As JsonResult
            Dim Tasks As IEnumerable = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@JobNumber", JobNumber))
                arParams.Add(New SqlParameter("@JobCompnentNumber", JobCompnentNumber))

                Tasks = (From Task In DbContext.Database.SqlQuery(Of Task)("usp_wv_dd_GetTasks @JobNumber, @JobCompnentNumber", arParams.ToArray)
                         Select New With {Task.Code,
                             .Name = Task.TRF_DESCRIPTION,
                             .Order = Task.TRF_ORDER,
                             Task.EST_FNC_CODE,
                             Task.FNC_DESCRIPTION}
                                 ).ToList

            End Using

            Return MaxJson(Tasks, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function SearchContacts(ByVal ClientCode As String, ByVal DivCode As String, ByVal ProdCode As String) As JsonResult
            Dim Tasks As IEnumerable = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@ClientCode", ClientCode))
                arParams.Add(New SqlParameter("@DivCode", DivCode))
                arParams.Add(New SqlParameter("@ProdCode", ProdCode))

                Tasks = (From Task In DbContext.Database.SqlQuery(Of IDCodeName)("select CDP_CONTACT_HDR.CDP_CONTACT_ID ID, CONT_CODE Code, CONT_FML Name from CDP_CONTACT_HDR 
	                                left join CDP_CONTACT_DTL on CDP_CONTACT_HDR.CDP_CONTACT_ID = CDP_CONTACT_DTL.CDP_CONTACT_ID
	                                where CL_CODE = @ClientCode and (DIV_CODE = @DivCode or DIV_CODE is null) and (PRD_CODE=@ProdCode or PRD_CODE is null)", arParams.ToArray)
                         Select New With {.Code = Task.Code, .Name = Task.Name, .ID = Task.ID}
                                 ).ToList

            End Using

            Return MaxJson(Tasks, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function GetJobInfoForSchedule(ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            Dim jobInfo As JobInfo = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim Offset As Decimal = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, Me.SecuritySession.User.EmployeeCode)
                Dim arParams As New List(Of SqlParameter)

                Dim JobNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim JobComponentNumberSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim ForScheduleSqlParameter As System.Data.SqlClient.SqlParameter = Nothing
                Dim OffsetSqlParameter As System.Data.SqlClient.SqlParameter = Nothing


                JobNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_NUMBER", SqlDbType.Int)
                JobComponentNumberSqlParameter = New System.Data.SqlClient.SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
                ForScheduleSqlParameter = New System.Data.SqlClient.SqlParameter("@FOR_SCHEDULE", SqlDbType.Bit)
                OffsetSqlParameter = New System.Data.SqlClient.SqlParameter("@OFFSET", SqlDbType.Decimal)

                JobNumberSqlParameter.Value = JobNumber
                JobComponentNumberSqlParameter.Value = JobComponentNumber
                ForScheduleSqlParameter.Value = 1

                If Offset < 0 Then 'Not sure about this...

                    OffsetSqlParameter.Value = -Offset

                Else

                    OffsetSqlParameter.Value = Offset

                End If

                Try

                    jobInfo = DbContext.Database.SqlQuery(Of JobInfo)("EXEC [dbo].[advsp_utilities_get_job_info] @JOB_NUMBER, @JOB_COMPONENT_NBR, @FOR_SCHEDULE, @OFFSET;",
                                                                    JobNumberSqlParameter,
                                                                    JobComponentNumberSqlParameter,
                                                                    ForScheduleSqlParameter,
                                                                    OffsetSqlParameter).FirstOrDefault()
                Catch ex As Exception
                    Diagnostics.Debug.Write(ex)
                End Try

            End Using

            Return MaxJson(jobInfo, JsonRequestBehavior.AllowGet)

        End Function
        Function GetJobInfo(ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As JsonResult

            Return GetJobInfoForSchedule(JobNumber, JobComponentNumber)

        End Function

#End Region

#End Region

    End Class

    Class JobInfo
        Public Property JobNumber As Integer '
        Public Property ComponentNumber As Short '
        Public Property ComponentDescription As String '
        Public Property Client As String '
        Public Property ClientCode As String '
        Public Property Division As String '
        Public Property DivisionCode As String '
        Public Property Product As String '
        Public Property ProductCode As String '
        Public Property JobTypeCode As String '
        Public Property JobTypeDescription As String '
        Public Property PercentComplete As Decimal?
        Public Property Status As String
        Public Property StatusCode As String
        Public Property DueDate As Date?
        Public Property StartDate As Date?
        Public Property CompletedDate As Date?
        Public Property TrafficComments As String
        Public Property Template As Boolean
        Public Property CalculateByPredecessor As Integer
        Public Property TotalTasks As Integer
        Public Property OpenTasks As Integer
        Public Property ProjectedHours As Decimal
        Public Property ActualEMPTaskHours As Decimal
        Public Property ByStartDate As Short
        Public Property PostedHours As Decimal
    End Class

End Namespace
