Imports System.Web.Mvc
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports Webvantage.ViewModels.LookupObjects
Imports Kendo.Mvc.Extensions

Namespace Controllers.Utilities

    Public Class LookupController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "Utilities/Lookup/"

#End Region

#Region " Aurelia "

#Region " Enum "

        Public Enum LookupTypes

            Job = 1
            JobComponent = 2

        End Enum
        Public Enum LookupSources

            Standard = 0
            TimesheetOld = 1
            Timesheet = 2
            AccountSetup = 3
            PurchaseOrders = 4
            ExpenseReports = 5

        End Enum

#End Region
#Region " Views "

        <MvcCodeRouting.Web.Mvc.CustomRoute("~/Lookup_Job")>
        Public Function LookupJob() As ActionResult

            'objects
            Dim AureliaModel As Webvantage.ViewModels.AureliaModel = Nothing

            AureliaModel = New Webvantage.ViewModels.AureliaModel
            AureliaModel.App = "modules/utilities/lookup-job"

            If HttpContext IsNot Nothing Then

                Dim LookupType As Short = 0
                Dim LookupSource As Short = 0
                Dim IncludeClosed As Boolean = False
                Dim ClientCode As String = String.Empty
                Dim DivisionCode As String = String.Empty
                Dim ProductCode As String = String.Empty
                Dim JobNumber As Integer = 0

                If HttpContext.Request("LookupType") IsNot Nothing Then
                    Try
                        If Request.QueryString("LookupType") IsNot Nothing AndAlso IsNumeric(Request.QueryString("LookupType")) Then

                            LookupType = CType(Request.QueryString("LookupType"), Short)

                        End If
                    Catch ex As Exception
                        LookupType = 0
                    End Try
                    Try
                        If Request.QueryString("LookupSource") IsNot Nothing AndAlso IsNumeric(Request.QueryString("LookupSource")) Then

                            LookupSource = CType(Request.QueryString("LookupSource"), Short)

                        End If
                    Catch ex As Exception
                        LookupSource = 0
                    End Try
                    Try
                        If Request.QueryString("IncludeClosed") IsNot Nothing Then

                            If (IsNumeric(Request.QueryString("IncludeClosed")) = True AndAlso CType(Request.QueryString("IncludeClosed"), Short) = 1) OrElse
                                (IsNumeric(Request.QueryString("IncludeClosed")) = False AndAlso Request.QueryString("IncludeClosed").ToString.ToLower = "true") Then

                                IncludeClosed = True
                            End If

                        End If
                    Catch ex As Exception
                        IncludeClosed = False
                    End Try
                    Try
                        If Request.QueryString("c") IsNot Nothing Then
                            ClientCode = Request.QueryString("c")
                        End If
                    Catch ex As Exception
                        ClientCode = String.Empty
                    End Try
                    Try
                        If Request.QueryString("d") IsNot Nothing Then
                            DivisionCode = Request.QueryString("d")
                        End If
                    Catch ex As Exception
                        DivisionCode = String.Empty
                    End Try
                    Try
                        If Request.QueryString("p") IsNot Nothing Then
                            ProductCode = Request.QueryString("p")
                        End If
                    Catch ex As Exception
                        ProductCode = String.Empty
                    End Try
                    Try
                        If Request.QueryString("j") IsNot Nothing AndAlso IsNumeric(Request.QueryString("j")) Then
                            JobNumber = Request.QueryString("j")
                        End If
                    Catch ex As Exception
                        JobNumber = 0
                    End Try

                End If

                AureliaModel.Parameters.Add("LookupType", LookupType)
                AureliaModel.Parameters.Add("LookupSource", LookupSource)
                AureliaModel.Parameters.Add("IncludeClosed", IncludeClosed)
                AureliaModel.Parameters.Add("ClientCode", ClientCode)
                AureliaModel.Parameters.Add("DivisionCode", DivisionCode)
                AureliaModel.Parameters.Add("ProductCode", ProductCode)
                AureliaModel.Parameters.Add("JobNumber", JobNumber)

            End If

            Return Aurelia(AureliaModel)

        End Function

#End Region
#Region " Methods "

        <HttpPost>
        Public Function InitJobLookup(DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest,
                                      ByVal LookupType As Integer, ByVal LookupSource As Integer,
                                      ByVal IncludeClosed As Boolean?,
                                      ByVal SearchCriteriaText As String,
                                      ByVal ClientCode As String,
                                      ByVal DivisionCode As String,
                                      ByVal ProductCode As String,
                                      ByVal JobNumber As Integer?) As JsonResult

            Dim ErrorMessage As String = String.Empty
            Dim Results As IEnumerable(Of Webvantage.ViewModels.Lookup) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    Dim JobAsString As String = "NULL"

                    If String.IsNullOrWhiteSpace(ClientCode) = True Then

                        ClientCode = "NULL"

                    Else

                        ClientCode = String.Format("'{0}'", ClientCode)

                    End If
                    If String.IsNullOrWhiteSpace(DivisionCode) = True Then

                        DivisionCode = "NULL"

                    Else

                        DivisionCode = String.Format("'{0}'", DivisionCode)

                    End If
                    If String.IsNullOrWhiteSpace(ProductCode) = True Then

                        ProductCode = "NULL"

                    Else

                        ProductCode = String.Format("'{0}'", ProductCode)

                    End If
                    If JobNumber IsNot Nothing Then

                        JobAsString = JobNumber.ToString

                    End If
                    If IncludeClosed Is Nothing Then IncludeClosed = False
                    Select Case CType(LookupType, LookupTypes)
                        Case LookupTypes.Job

                            Select Case CType(LookupSource, LookupSources)

                                Case LookupSources.Timesheet, LookupSources.TimesheetOld

                                    Results = DbContext.Database.SqlQuery(Of Webvantage.ViewModels.Lookup)(String.Format("EXEC [dbo].[advsp_job_load_by_user] @CL_CODE = {2}, @DIV_CODE = {3}, @PRD_CODE = {4}, @JOB_NUMBER = {5}, @OPEN_COMP_ONLY = {0}, @ALLOWED_PROC_CONTROLS = 'timesheet', @USER_CODE = '{1}', @SKIP = 0, @TAKE = 0;",
                                                                                                           If(IncludeClosed = True, 0, 1), Me.SecuritySession.UserCode, ClientCode, DivisionCode, ProductCode, JobAsString)).ToList

                                Case Else

                                    Results = DbContext.Database.SqlQuery(Of Webvantage.ViewModels.Lookup)(String.Format("EXEC [dbo].[advsp_job_load_by_user] @CL_CODE = {2}, @DIV_CODE = {3}, @PRD_CODE = {4}, @JOB_NUMBER = {5}, @OPEN_COMP_ONLY = {0}, @ALLOWED_PROC_CONTROLS = '', @USER_CODE = '{1}', @SKIP = 0, @TAKE = 0;",
                                                                                                           If(IncludeClosed = True, 0, 1), Me.SecuritySession.UserCode, ClientCode, DivisionCode, ProductCode, JobAsString)).ToList

                            End Select

                        Case LookupTypes.JobComponent

                            Select Case CType(LookupSource, LookupSources)

                                Case LookupSources.Timesheet, LookupSources.TimesheetOld

                                    Results = DbContext.Database.SqlQuery(Of Webvantage.ViewModels.Lookup)(String.Format("EXEC [dbo].[advsp_job_component_load_by_user] @CL_CODE = {2}, @DIV_CODE = {3}, @PRD_CODE = {4}, @JOB_NUMBER = {5}, @OPEN_COMP_ONLY = {0}, @ALLOWED_PROC_CONTROLS = 'timesheet', @USER_CODE = '{1}', @SKIP = 0, @TAKE = 0;",
                                                                                                           If(IncludeClosed = True, 0, 1), Me.SecuritySession.UserCode, ClientCode, DivisionCode, ProductCode, JobAsString)).ToList

                                Case Else

                                    Results = DbContext.Database.SqlQuery(Of Webvantage.ViewModels.Lookup)(String.Format("EXEC [dbo].[advsp_job_component_load_by_user] @CL_CODE = {2}, @DIV_CODE = {3}, @PRD_CODE = {4}, @JOB_NUMBER = {5}, @OPEN_COMP_ONLY = {0}, @ALLOWED_PROC_CONTROLS = NULL, @USER_CODE = '{1}', @SKIP = 0, @TAKE = 0;",
                                                                                                           If(IncludeClosed = True, 0, 1), Me.SecuritySession.UserCode, ClientCode, DivisionCode, ProductCode, JobAsString)).ToList

                            End Select

                    End Select

                    If Not String.IsNullOrWhiteSpace(SearchCriteriaText) Then

                        SearchCriteriaText = SearchCriteriaText.Trim.ToUpper()

                        Results = (From Item In Results
                                   Where If(String.IsNullOrEmpty(Item.Description), "", Item.Description).ToUpper().Contains(SearchCriteriaText) OrElse
                                         If(String.IsNullOrEmpty(Item.ClientCode), "", Item.ClientCode).ToUpper().Contains(SearchCriteriaText) OrElse
                                         If(String.IsNullOrEmpty(Item.DivisionCode), "", Item.DivisionCode).ToUpper().Contains(SearchCriteriaText) OrElse
                                         If(String.IsNullOrEmpty(Item.ProductCode), "", Item.ProductCode).ToUpper().Contains(SearchCriteriaText) OrElse
                                         If(String.IsNullOrEmpty(Item.SalesClassDescription), "", Item.SalesClassDescription).ToUpper().Contains(SearchCriteriaText)
                                   Select Item).ToList

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message.ToString
                Results = Nothing
            End Try

            If Results Is Nothing Then Results = New Generic.List(Of Webvantage.ViewModels.Lookup)

            Return MaxJson(Results.ToDataSourceResult(DataSourceRequest), JsonRequestBehavior.AllowGet)

        End Function

#End Region

#End Region

#Region " Methods "

        <AcceptVerbs("POST")>
        Function Search(SearchCriteriaText As String) As ActionResult
            Try

                Dim LookupDisplayObject As ViewModels.LookupDisplayObject = Nothing
                Dim LookupSearchCriteria As ViewModels.LookupSearchCriteria = Nothing
                Dim LookupRepository As Repositories.LookupRepository = Nothing

                Try

                    If SecuritySession IsNot Nothing Then

                        LookupSearchCriteria = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ViewModels.LookupSearchCriteria)(SearchCriteriaText)
                        LookupRepository = New Repositories.LookupRepository(SecuritySession)
                        LookupDisplayObject = LookupRepository.SearchLookup(LookupSearchCriteria)

                    End If

                Catch ex As Exception
                    LookupDisplayObject = New ViewModels.LookupDisplayObject()
                    LogError(ex)
                End Try

                Dim SearchResult As JsonResult = Json(LookupDisplayObject)
                SearchResult.MaxJsonLength = Integer.MaxValue
                Search = SearchResult

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        <AcceptVerbs("POST")>
        Function Validate(LookUps As String) As ActionResult
            Try

                Dim ValidationRequest As ViewModels.StandardValidationRequest = Nothing
                Dim ValidationResult As ViewModels.StandardValidationResult = Nothing
                Dim LookupRepository As Repositories.LookupRepository = Nothing

                Try
                    If SecuritySession IsNot Nothing Then

                        ValidationRequest = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ViewModels.StandardValidationRequest)(LookUps)
                        LookupRepository = New Repositories.LookupRepository(SecuritySession)
                        ValidationResult = LookupRepository.ValidateLookUp(ValidationRequest)

                    End If

                Catch ex As Exception

                    ValidationResult = New ViewModels.StandardValidationResult
                    ValidationResult.IsValid = False
                    ValidationResult.ValidationMessage = ex.Message.ToString()

                    If ex.InnerException IsNot Nothing Then

                        ValidationResult.ValidationMessage &= ex.InnerException.Message.ToString()

                    End If

                End Try

                Dim Result As JsonResult = Json(ValidationResult)
                Result.MaxJsonLength = Integer.MaxValue
                Validate = Result

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        <AcceptVerbs("POST")>
        Function JobOrComponentClosed(SearchCriteriaText As String) As ActionResult
            Try
                Dim LookupRepository As Repositories.LookupRepository = Nothing
                Dim ItemsClosed As Boolean = False
                Dim JSON As String = ""

                Dim searchCriteria As ViewModels.LookupSearchCriteria = New ViewModels.LookupSearchCriteria()
                If (SearchCriteriaText.Length > 0) Then
                    searchCriteria = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ViewModels.LookupSearchCriteria)(SearchCriteriaText)
                End If

                Try
                    If SecuritySession IsNot Nothing Then
                        LookupRepository = New Repositories.LookupRepository(SecuritySession)
                        ItemsClosed = LookupRepository.JobOrComponentClosed(searchCriteria.JobComponent)
                    End If
                Catch ex As Exception
                    ItemsClosed = False
                    LogError(ex)
                End Try

                JSON = String.Format("{{ ""Closed"" : ""{0}"" }}", ItemsClosed.ToString().ToLower())
                Response.Clear()
                Response.ContentType = "application/json; charset=utf-8"
                Response.Write(JSON)

            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        <AcceptVerbs("Post")>
        Function TimesheetFunctionCategories(SearchCriteriaText As String) As ActionResult
            Try
                Dim Results As List(Of FunctionCategorySearchResult) = Nothing
                Dim SearchCriteria As FunctionCategory = Nothing

                Dim EmployeeRepo As Interfaces.IEmployeeRepository = Nothing

                SearchCriteria = New FunctionCategory()
                Results = New List(Of FunctionCategorySearchResult)

                If (SearchCriteriaText.Length > 0) Then
                    SearchCriteria = Newtonsoft.Json.JsonConvert.DeserializeObject(Of FunctionCategory)(SearchCriteriaText)
                    SearchCriteria.SearchText = SearchCriteria.SearchText.Trim()
                End If

                Try
                    If SecuritySession IsNot Nothing Then
                        EmployeeRepo = New Repositories.EmployeeRepository(SecuritySession)
                        Results = EmployeeRepo.SearchFunctionCategories(SearchCriteria)
                    End If
                Catch ex As Exception
                    Results = New List(Of FunctionCategorySearchResult)
                    LogError(ex)
                End Try

                TimesheetFunctionCategories = Json(Results)

            Catch ex As Exception
                Return Nothing
            End Try
        End Function

#End Region

    End Class

End Namespace
