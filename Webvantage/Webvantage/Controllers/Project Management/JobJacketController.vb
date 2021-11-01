Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Web.Mvc
Imports Webvantage.ViewModels
Imports Kendo.Mvc.Extensions
Imports MvcCodeRouting.Web.Mvc
Imports Webvantage.Controllers
Imports System.Web.Routing
Imports Ionic.Zip
Imports ActiveReportsAssembly
Imports System.Data.SqlClient

Namespace Controllers.ProjectManagement

    Public Class JobJacketController
        Inherits MVCControllerBase

#Region " Variables "

        Private _Controller As Object = Nothing 'AdvantageFramework.Controller.ProjectManagement.JobJacketController = Nothing

#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New Object ' New AdvantageFramework.Controller.ProjectManagement.JobJacketController(Me.SecuritySession)

        End Sub


#Region " Views "

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/ProjectManagement_JobJacket")>
        Public Function Index() As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel

            AureliaModel.App = "modules/project-management/job-jacket/job-jacket"

            Return Aurelia(AureliaModel)

        End Function

#End Region

#Region " API "
        <HttpGet>
        Public Function Search(ByVal OfficeCode As String, ByVal ClientCode As String,
                               ByVal DivisionCode As String, ByVal ProductCode As String,
                               ByVal SalesClassCode As String, ByVal JobNumber As Integer,
                               ByVal ComponentNumber As Integer, CampaignID As Integer,
                               ByVal AccountExecutiveCode As String, ByVal JobTypeCode As String,
                               ByVal ShowClosed As Boolean, ByVal Year As Integer?,
                               Optional ByVal Skip As Integer = 0, Optional ByVal Take As Integer = 0) As JsonResult


            Dim JobJackets As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.JobJacket.JobJacketSearchDTO)
            Dim totalRows As Integer
            Dim budgetSum As Decimal

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim arParams As New List(Of SqlParameter)
                    arParams.Add(New SqlParameter("@USER_ID", Me.SecuritySession.UserCode))
                    arParams.Add(New SqlParameter("@OfficeCode", OfficeCode))
                    arParams.Add(New SqlParameter("@ClientCode", ClientCode))
                    arParams.Add(New SqlParameter("@DivisionCode", DivisionCode))
                    arParams.Add(New SqlParameter("@ProductCode", ProductCode))
                    arParams.Add(New SqlParameter("@SalesClassCode", SalesClassCode))
                    arParams.Add(New SqlParameter("@JobNumber", JobNumber))
                    arParams.Add(New SqlParameter("@ComponentNumber", ComponentNumber))
                    arParams.Add(New SqlParameter("@AccountExecutiveCode", AccountExecutiveCode))
                    arParams.Add(New SqlParameter("@CampaignID", CampaignID))
                    arParams.Add(New SqlParameter("@JobTypeCode", JobTypeCode))
                    arParams.Add(New SqlParameter("@ShowClosed", ShowClosed))
                    If Year Is Nothing Then
                        Dim Param As SqlParameter = New SqlParameter("@Year", SqlDbType.Int)
                        Param.Value = DBNull.Value
                        arParams.Add(Param)
                    Else
                        arParams.Add(New SqlParameter("@Year", Year))
                    End If
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
                    Dim outBudget As SqlParameter = New SqlParameter()
                    outBudget.SqlDbType = System.Data.SqlDbType.Decimal
                    outBudget.ParameterName = "@BudgetSum"
                    outBudget.Value = 0
                    outBudget.Precision = 18
                    outBudget.Scale = 2
                    outBudget.Direction = System.Data.ParameterDirection.Output
                    arParams.Add(outBudget)

                    Dim Command As String = "EXEC [dbo].[usp_wv_Job_Jacket_Search] @USER_ID, @OfficeCode, @ClientCode, @DivisionCode, @ProductCode, @SalesClassCode, @JobNumber, @ComponentNumber, @AccountExecutiveCode, @CampaignID, @JobTypeCode,@ShowClosed,@Year, @Skip, @Take, @CPID, @TotalRows out, @BudgetSum out;"

                    JobJackets = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.JobJacket.JobJacketSearchDTO)(Command, arParams.ToArray).ToList

                    If Not IsDBNull(outParam.Value) Then
                        totalRows = outParam.Value
                    End If

                    If Not IsDBNull(outBudget.Value) Then
                        budgetSum = outBudget.Value
                    End If
                End Using

            Catch ex As Exception

            End Try

            Dim BudgetSumClass = New With {.sum = budgetSum}

            Return MaxJson(New With {.total = totalRows, .Data = JobJackets, .aggregates = New With {.Budget = BudgetSumClass}}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function LookupClients(ByVal OfficeCodes As String(), ByVal IncludeInactive As Boolean) As JsonResult

            'objects
            Dim Clients As IEnumerable = Nothing

            Clients = _Controller.LookupClients(OfficeCodes, IncludeInactive)

            Return MaxJson(Clients)

        End Function

        <HttpPost>
        Public Function LookupDivisions(ByVal ClientCodes As String(), ByVal IncludeInactive As Boolean) As JsonResult

            'objects
            Dim Divisions As IEnumerable = Nothing

            Divisions = _Controller.LookupDivisions(ClientCodes, IncludeInactive)

            Return MaxJson(Divisions)

        End Function

        Public Function GetJobs() As JsonResult

            'objects
            Dim Jobs As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Jobs = (From Item In AdvantageFramework.Database.Procedures.JobView.LoadAllOpen(DbContext)
                        Select New With {.ClientCode = Item.ClientCode,
                                        .ClientName = Item.ClientName,
                                        .DivisionCode = Item.DivisionCode,
                                        .DivisionName = Item.DivisionName,
                                        .ProductCode = Item.ProductCode,
                                        .ProductDescription = Item.ProductDescription,
                                        .JobNumber = Item.JobNumber,
                                        .JobDescription = Item.JobDescription,
                                        .OfficeCode = Item.OfficeCode,
                                        .OfficeName = Item.OfficeName,
                                        .SalesClass = "Sales Class",
                                        .JobType = "Job Type",
                                        .IsOpen = Item.IsOpen}).ToList

            End Using

            Return Json(Jobs, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetOffices() As JsonResult

            'objects
            Dim Offices As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Offices = (From Item In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext)
                           Select New With {.Code = Item.Code,
                                            .Name = Item.Name}).ToList

            End Using

            Return Json(Offices, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetClients() As JsonResult

            'objects
            Dim Clients As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Clients = (From Item In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                           Select New With {.Code = Item.Code,
                                            .Name = Item.Name}).ToList

            End Using

            Return Json(Clients, JsonRequestBehavior.AllowGet)

        End Function

        Public Function GetDivisions() As JsonResult

            'objects
            Dim Divisions As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Divisions = (From Item In AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext)
                             Select New With {.Code = Item.Code,
                                              .Name = Item.Name,
                                              .ClientCode = Item.ClientCode}).ToList

            End Using

            Return Json(Divisions, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetProducts() As JsonResult

            'objects
            Dim Products As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Products = (From Item In AdvantageFramework.Database.Procedures.Product.LoadAllActive(DbContext)
                            Select New With {.Code = Item.Code,
                                             .Name = Item.Name,
                                             .ClientCode = Item.ClientCode,
                                             .DivisionCode = Item.DivisionCode}).ToList

            End Using

            Return Json(Products, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetSalesClasses() As JsonResult

            'objects
            Dim SalesClasses As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                SalesClasses = (From Item In AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                                Select New With {.Code = Item.Code,
                                                 .Description = Item.Description}).ToList

            End Using

            Return Json(SalesClasses, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetCampaigns() As JsonResult

            'objects
            Dim Campaigns As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Campaigns = (From Item In AdvantageFramework.Database.Procedures.Campaign.LoadAllActiveCampaigns(DbContext)
                             Select New With {.ClientCode = Item.ClientCode,
                                              .DivisionCode = Item.DivisionCode,
                                              .ProductCode = Item.ProductCode,
                                              .Code = Item.Code,
                                              .Name = Item.Name,
                                              .ID = Item.ID}).ToList

            End Using

            Return Json(Campaigns, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetComponents() As JsonResult

            'objects
            Dim Components As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Components = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadAllOpen(DbContext).OrderByDescending(Function(Entity) Entity.JobNumber)
                              Join Job In AdvantageFramework.Database.Procedures.Job.Load(DbContext).Include("SalesClass") On Item.JobNumber Equals Job.Number
                              Join Comp In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext) On Item.JobNumber Equals Comp.JobNumber And Item.JobComponentNumber Equals Comp.Number
                              Join JobType In AdvantageFramework.Database.Procedures.JobType.Load(DbContext) On Comp.JobTypeCode Equals JobType.Code
                              Select New With {.ID = Item.ID,
                                              .JobComponentNumber = Item.JobComponentNumber,
                                              .JobComponentDescription = Item.JobComponentDescription,
                                              .ClientCode = Item.ClientCode,
                                              .ClientName = Item.ClientName,
                                              .DivisionCode = Item.DivisionCode,
                                              .DivisionName = Item.DivisionName,
                                              .ProductCode = Item.ProductCode,
                                              .ProductDescription = Item.ProductDescription,
                                              .JobNumber = Item.JobNumber,
                                              .JobDescription = Item.JobDescription,
                                              .OfficeCode = Item.OfficeCode,
                                              .OfficeName = Item.OfficeName,
                                              .IsOpen = Item.IsOpen,
                                              .SalesClass = If(Job.SalesClass Is Nothing, String.Empty, Job.SalesClass.Description),
                                              .JobType = If(JobType IsNot Nothing, String.Empty, JobType.Description),
                                              .JobProcessControl = Item.JobProcessControl}).ToList

            End Using

            Return Json(Components, JsonRequestBehavior.AllowGet)

        End Function
        Public Function GetAccountExecutives() As JsonResult

            'objects
            Dim AccountExecutives As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                AccountExecutives = (From Item In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                                     Select New With {.Code = Item.Code,
                                                      .FirstName = Item.FirstName,
                                                      .MiddleInitial = Item.MiddleInitial,
                                                      .LastName = Item.MiddleInitial}).ToList

            End Using

            Return Json(AccountExecutives, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function PrintJobs(ByVal JobComponents As String()) As FileResult

            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim JobComp As String()
            Dim memStream As System.IO.MemoryStream

            If JobComponents Is Nothing Then

            ElseIf JobComponents.Length = 1 Then
                JobComp = JobComponents(0).Split("/")

                If IsNumeric(JobComp(0)) = True Then
                    JobNumber = CType(JobComp(0), Integer)
                End If

                If IsNumeric(JobComp(1)) = True Then
                    JobComponentNbr = CType(JobComp(1), Integer)
                End If

                memStream = Me.PrintJob(JobNumber, JobComponentNbr)

                Dim fr As FileResult = New FileStreamResult(memStream, "application/pdf")

                Dim sb1 As New System.Text.StringBuilder 'build filename
                sb1.Append("JobOrder_")
                sb1.Append(JobNumber)
                sb1.Append("_")
                sb1.Append(JobComponentNbr)
                sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))
                sb1.Append(".pdf")

                Dim filename As String = sb1.ToString()

                fr.FileDownloadName = filename

                Return fr

            ElseIf JobComponents.Length > 1 Then
                Dim zip As New ZipFile

                For Each comp As String In JobComponents
                    JobComp = comp.Split("/")

                    If IsNumeric(JobComp(0)) = True Then
                        JobNumber = CType(JobComp(0), Integer)
                    End If

                    If IsNumeric(JobComp(1)) = True Then
                        JobComponentNbr = CType(JobComp(1), Integer)
                    End If

                    memStream = Me.PrintJob(JobNumber, JobComponentNbr)

                    Dim sb1 As New System.Text.StringBuilder 'build filename
                    sb1.Append("JobOrder_")
                    sb1.Append(JobNumber)
                    sb1.Append("_")
                    sb1.Append(JobComponentNbr)
                    sb1.Append(AdvantageFramework.StringUtilities.GUID_Date(True, True, True))
                    sb1.Append(".pdf")

                    Dim filename As String = sb1.ToString()

                    zip.AddEntry(filename, memStream)
                Next

                memStream = New IO.MemoryStream
                zip.Save(memStream)
                memStream.Seek(0, IO.SeekOrigin.Begin)
                Dim fr As FileResult = New FileStreamResult(memStream, "application/zip")

                fr.FileDownloadName = "Webvantage_Job_Templates__" & Today.Year.ToString() & Today.Month.ToString() & Today.Day.ToString() & ".zip"

                Return fr
            End If


        End Function

        <HttpPost>
        Public Function BookMarkPage(ByVal Office As String,
                                     ByVal Client As String,
                                     ByVal Division As String,
                                     ByVal Product As String,
                                     ByVal SalesClass As String,
                                     ByVal Campaign As Integer?,
                                     ByVal JobNumber As Integer?,
                                     ByVal ComponentNumber As Integer?,
                                     ByVal AccountExecutive As String,
                                     ByVal ShowClosed As Boolean,
                                     ByVal JobType As String
                                     ) As JsonResult
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            With qs
                .OfficeCode = Office
                .ClientCode = Client
                .DivisionCode = Division
                .ProductCode = Product
                .SalesClassCode = SalesClass
                .CampaignIdentifier = Campaign
                If JobNumber IsNot Nothing Then
                    .JobNumber = JobNumber
                End If
                If ComponentNumber IsNot Nothing Then
                    .JobComponentNumber = ComponentNumber
                End If
                .AccountExecutiveCode = AccountExecutive
                .Add("jt", JobType)
                .Add("closedarchived", ShowClosed)
                .Add("isbookmark", "1")
                .Build()
            End With

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_JobJacket
                .UserCode = Session("UserCode")
                .Name = "Job Jacket Search"
                .PageURL = "modules/project-management/job-jacket/job-jacket-search" & qs.ToString()

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                'Me.ShowMessage(s)
            End If

        End Function

        <HttpPost>
        Public Function UpdateAE(ByVal AccountExecutive As String, ByVal IsDefault As Boolean, ByVal Components() As String) As JsonResult
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim Updated As Boolean = False
            Dim Inserted As Boolean = False
            Dim AE As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim AcctExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim ProductAccountExecutivesList As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
            Dim DefaultAE As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

            Try
                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                    For Each jobcomp In Components

                        Dim job() As String = jobcomp.Split("/")

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, job(0), job(1))

                        If JobComponent IsNot Nothing Then

                            AE = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductAndEmployeeCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode, AccountExecutive)

                            If AE Is Nothing Then

                                If IsDefault = True Then

                                    ProductAccountExecutivesList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode).ToList
                                    For Each AccountExecutiveClass In ProductAccountExecutivesList
                                        If AccountExecutiveClass.IsDefaultAccountExecutive = 1 Then
                                            DefaultAE = AccountExecutiveClass
                                        End If
                                    Next

                                    If DefaultAE IsNot Nothing Then
                                        DefaultAE.IsDefaultAccountExecutive = 0
                                        AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, DefaultAE)
                                    End If

                                    AcctExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                                    AcctExecutive.DbContext = DbContext

                                    AcctExecutive.ClientCode = JobComponent.Job.ClientCode
                                    AcctExecutive.DivisionCode = JobComponent.Job.DivisionCode
                                    AcctExecutive.ProductCode = JobComponent.Job.ProductCode
                                    AcctExecutive.EmployeeCode = AccountExecutive
                                    AcctExecutive.IsDefaultAccountExecutive = 1
                                    AcctExecutive.ManagementLevelID = 1

                                    Inserted = AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AcctExecutive)

                                Else

                                    AcctExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                                    AcctExecutive.DbContext = DbContext

                                    AcctExecutive.ClientCode = JobComponent.Job.ClientCode
                                    AcctExecutive.DivisionCode = JobComponent.Job.DivisionCode
                                    AcctExecutive.ProductCode = JobComponent.Job.ProductCode
                                    AcctExecutive.EmployeeCode = AccountExecutive
                                    AcctExecutive.IsDefaultAccountExecutive = 0
                                    AcctExecutive.ManagementLevelID = 1

                                    Inserted = AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AcctExecutive)

                                End If

                                If Inserted = True Then
                                    JobComponent.AccountExecutiveEmployeeCode = AcctExecutive.EmployeeCode
                                    AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)
                                End If

                            Else

                                If IsDefault = True And AE.IsDefaultAccountExecutive = 0 Then

                                    ProductAccountExecutivesList = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode).ToList
                                    For Each AccountExecutiveClass In ProductAccountExecutivesList
                                        If AccountExecutiveClass.IsDefaultAccountExecutive = 1 Then
                                            DefaultAE = AccountExecutiveClass
                                        End If
                                    Next

                                    If DefaultAE IsNot Nothing Then
                                        DefaultAE.IsDefaultAccountExecutive = 0
                                        AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, DefaultAE)
                                    End If


                                    AE.IsDefaultAccountExecutive = 1
                                    Updated = AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, AE)
                                End If

                                JobComponent.AccountExecutiveEmployeeCode = AE.EmployeeCode
                                AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)

                            End If
                        End If
                    Next
                End Using

                Updated = True

            Catch ex As Exception
                Updated = False
            End Try
        End Function

        <HttpPost>
        Public Function UpdateAlertGroup(ByVal AlertGroup As String, ByVal IsDefault As Boolean, ByVal Components() As String) As JsonResult

            'objects
            Dim Parameters As System.Data.SqlClient.SqlParameter() = Nothing
            Dim Updated As Boolean = False
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing
            Dim AlertGroupClass As AdvantageFramework.Database.Entities.AlertGroup = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Try
                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                    For Each ComponentBatch In Components

                        Dim job() As String = ComponentBatch.Split("/")

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, job(0), job(1))

                        If JobComponent IsNot Nothing Then
                            JobComponent.AlertGroupCode = AlertGroup
                            AdvantageFramework.Database.Procedures.JobComponent.Update(DbContext, JobComponent)
                        End If

                        If IsDefault = True Then
                            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, JobComponent.Job.ClientCode, JobComponent.Job.DivisionCode, JobComponent.Job.ProductCode)

                            Product.ProductionAlertGroup = AlertGroup
                            AdvantageFramework.Database.Procedures.Product.Update(DbContext, Product)

                        End If


                    Next

                End Using

                Updated = True

            Catch ex As Exception
                Updated = False
            End Try


        End Function

        <HttpGet>
        Public Function CanAdd() As JsonResult

            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission
            Dim HasAccess As Boolean = False

            Dim _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))


            Using DbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext,
                                                                                                                     AdvantageFramework.Security.Application.Webvantage,
                                                                                                                     AdvantageFramework.Security.Modules.ProjectManagement_JobJacket.ToString("F"),
                                                                                                                     _Session.User.ID)

                HasAccess = UserPermission.CanAdd

            End Using

            Return Json(HasAccess, JsonRequestBehavior.AllowGet)

        End Function



#End Region

        Function PrintJob(ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer) As System.IO.MemoryStream
            Dim strReportName As String
            Dim CurrentCultureCode As String = LoGlo.UserCultureGet()
            Dim imgPath As String = Request.PhysicalApplicationPath & "Images\logo_print.gif"
            Dim rpt
            Dim ds As DataSet
            Dim ds2 As DataSet
            Dim ds3 As DataSet
            Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))
            Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
            Dim rush As Short
            Dim oJob As Job = New Job(Session("ConnString"))
            Dim oReports As New cReports(Session("ConnString"))
            Dim memStream As New System.IO.MemoryStream()
            Dim pdf As New DataDynamics.ActiveReports.Export.Pdf.PdfExport
            Dim ci As New System.Globalization.CultureInfo(ReportFunctions.UserCultureGet())
            Dim Settings As AdvantageFramework.ViewModels.ProjectManagement.JobJacket.JobOrderFormSettingsDTO
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

            Settings = LoadPrintSettings()

            oJob.GetJob(JobNumber, JobComponentNbr)
            rush = oJob.JOB_RUSH_CHARGES
            If rush <> 1 Then rush = 0

            strReportName = MyJobTemplate.GetTemplateDesc(MyJobTemplate.GetTemplateCode(JobNumber, JobComponentNbr))

            rpt = New ActiveReportsAssembly.arptJobTemplate
            rpt.CultureCode = CurrentCultureCode
            rpt.JobNum = JobNumber
            rpt.JobCompNum = JobComponentNbr
            rpt.printJobOrderForm = If(Settings IsNot Nothing, Not Settings.JOB_ORDER_FORM = 0, 1)
            rpt.omitEmptyFields = If(Settings IsNot Nothing, Not Settings.OMIT_EMPTY_FLDS = 0, 0)
            rpt.includeTA = If(Settings IsNot Nothing, Not Settings.TRAFFIC_GENERAL_ASSIGN = 0, 0)
            rpt.sectionTitleTA = If(Settings IsNot Nothing, Settings.KEY_ASSIGN_TITLE, "")
            rpt.includeTS = If(Settings IsNot Nothing, Not Settings.TRAFFIC_SCHED = 0, 0)
            rpt.scheduleCommentTS = If(Settings IsNot Nothing, Not Settings.SCHED_COMMENTS = 0, 0)
            rpt.sectionTitleTS = If(Settings IsNot Nothing, Settings.TRAFFIC_SCHED_TITLE, "")
            rpt.dueDatesOnlyTS = If(Settings IsNot Nothing, Not Settings.DUE_DATE = 0, 0)
            rpt.milestonesOnlyTS = If(Settings IsNot Nothing, Not Settings.MILESTONE = 0, 0)
            rpt.milestoneTitle = If(Settings IsNot Nothing, Settings.SCHED_MILESTONE_TITLE, "")
            rpt.employeeAssignmentsTS = If(Settings IsNot Nothing, Not Settings.EMPL_ASSIGN = 0, 0)
            rpt.ReportTitle = strReportName
            rpt.imgPath = imgPath
            rpt.LogoPath = oReports.GetLocationLogoPathByID(If(Settings IsNot Nothing, Settings.LOCATION_ID, ""))
            rpt.LogoPlacement = If(Settings IsNot Nothing, Settings.REPORT_TITLE_PLACEMENT, 0)
            rpt.LogoID = If(Settings IsNot Nothing, Settings.LOCATION_ID, "None")
            rpt.Reporter = Session("UserCode")
            rpt.dtTraffic = oReports.GetJobTrafficAssignments(JobNumber, JobComponentNbr)
            ds3 = oTrafficSchedule.GetScheduleAssignmentLabels
            rpt.dtTrafficLabels = ds3.Tables(0)
            rpt.dtSchedule = oReports.GetJobTrafficSchedule(JobNumber, JobComponentNbr, "ama")
            rpt.dtAgency = oReports.GetAgencyInfoJobTemplate(If(Settings IsNot Nothing, Settings.LOCATION_ID, "None"))
            ds2 = MyJobTemplate.GetJobTemplateComments(JobNumber, JobComponentNbr)
            rpt.dtComments = ds2.Tables(0)
            ds = MyJobTemplate.GetJobTemplateDetails(JobNumber, JobComponentNbr)
            rpt.MyDT = ds.Tables(0)
            rpt.dtData = ds.Tables(2)
            rpt.rushJob = rush

            If Settings IsNot Nothing AndAlso Settings.LOCATION_ID <> "" Then
                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())
                    rpt._LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, Settings.LOCATION_ID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)
                End Using
            End If

            rpt.Culture = ci
            rpt.Run(False)

            pdf.Export(rpt.Document, memStream)

            memStream.Seek(0, IO.SeekOrigin.Begin)

            Return memStream

        End Function

        Private Function LoadPrintSettings() As AdvantageFramework.ViewModels.ProjectManagement.JobJacket.JobOrderFormSettingsDTO

            Dim Settings As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.JobJacket.JobOrderFormSettingsDTO)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Dim arParams(1) As SqlParameter
                Dim paramUserID As New SqlParameter("@UserID", SqlDbType.VarChar)
                paramUserID.Value = Session("UserCode")
                arParams(0) = paramUserID

                Settings = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.JobJacket.JobOrderFormSettingsDTO)("usp_wv_GetJobOrderFormSettings @UserID", paramUserID).ToList

            End Using

            Return Settings.FirstOrDefault

        End Function

#End Region

    End Class

End Namespace

