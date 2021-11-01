Imports System.Web.Mvc
Imports AdvantageFramework.Database.Entities
Imports System.Collections.Generic
Imports Webvantage.ViewModels
Imports System
Imports System.Linq
Imports System.Web
Imports Newtonsoft.Json
Imports Kendo.Mvc.Extensions

Namespace Controllers.FinanceAndAccounting

    Public Class JobForecastController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "FinanceAndAccounting/JobForecast/"

#End Region

#Region " Methods "

        Private Function IsJobForecastRevisionEditable(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobForecastRevisionID As Integer) As Boolean

            'objects
            Dim IsEditable As Boolean = False
            Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing

            Try

                JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, JobForecastRevisionID)

                If JobForecastRevision IsNot Nothing Then

                    If JobForecastRevision.IsApproved = False Then

                        With AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByJobForecastID(DbContext, JobForecastRevision.JobForecastID)

                            If .Count() > 1 Then

                                If .Max(Function(item) item.RevisionNumber) = JobForecastRevision.RevisionNumber Then

                                    IsEditable = True

                                End If

                            Else

                                IsEditable = True

                            End If

                        End With

                    End If

                End If

            Catch ex As Exception
                IsEditable = False
            Finally
                IsJobForecastRevisionEditable = IsEditable
            End Try

        End Function

#Region " -- Update Methods -- "

        <AcceptVerbs("POST")>
        Public Function UpdateJobComments(ByVal JobForecastJobID As Integer, ByVal Comments As String) As JsonResult

            'objects
            Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
            Dim ReturnObject As Object = Nothing

            Try

                If Me.SecuritySession IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        JobForecastJob = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByID(DbContext, JobForecastJobID)

                        If JobForecastJob IsNot Nothing Then

                            If IsJobForecastRevisionEditable(DbContext, JobForecastJob.JobForecastRevisionID) Then

                                JobForecastJob.Comment = Comments

                                If AdvantageFramework.JobForecast.UpdateJobForecastJob(DbContext, JobForecastJob) Then

                                    ReturnObject = New With {.Status = System.Net.HttpStatusCode.OK}

                                End If

                            Else

                                ReturnObject = New With {.Status = System.Net.HttpStatusCode.BadRequest,
                                                         .Message = "This revision is not editable."}

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

            If ReturnObject Is Nothing Then

                ReturnObject = False

            End If

            Return Json(ReturnObject)

        End Function
        <AcceptVerbs("POST")>
        Public Function UpdatePostPeriodAmount(ByVal JobForecastJobID As Integer, ByVal PostPeriodCode As String, ByVal Amount As Decimal?, ByVal BillingOrRevenue As Short?) As JsonResult

            'objects
            Dim JobForecastJobDetail As AdvantageFramework.Database.Entities.JobForecastJobDetail = Nothing
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing
            Dim ReturnObject As Object = Nothing
            Dim Budget As Decimal = Nothing
            Dim Variance As Decimal = Nothing
            Dim Actual As Decimal = Nothing
            Dim TotalBilling As Decimal = Nothing
            Dim TotalRevenue As Decimal = Nothing

            Try

                If Me.SecuritySession IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        JobForecastJob = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByID(DbContext, JobForecastJobID)

                        If JobForecastJob IsNot Nothing Then

                            If IsJobForecastRevisionEditable(DbContext, JobForecastJob.JobForecastRevisionID) Then

                                JobForecastJobDetail = (From Item In AdvantageFramework.Database.Procedures.JobForecastJobDetail.LoadByJobForecastJobID(DbContext, JobForecastJobID)
                                                        Where Item.PostPeriod = PostPeriodCode
                                                        Select Item).SingleOrDefault

                                If JobForecastJobDetail Is Nothing Then

                                    JobForecastJobDetail = New AdvantageFramework.Database.Entities.JobForecastJobDetail

                                    With JobForecastJobDetail

                                        .JobForecastID = JobForecastJob.JobForecastID
                                        .JobForecastRevisionID = JobForecastJob.JobForecastRevisionID
                                        .JobForecastJobID = JobForecastJob.ID
                                        .PostPeriod = PostPeriodCode

                                    End With

                                End If

                                If JobForecastJobDetail IsNot Nothing Then

                                    If BillingOrRevenue.GetValueOrDefault(0) = 0 Then

                                        JobForecastJobDetail.BillingAmount = Amount

                                    Else

                                        JobForecastJobDetail.RevenueAmount = Amount

                                    End If

                                    If AdvantageFramework.JobForecast.UpdateJobForecastJobDetail(DbContext, JobForecastJobDetail) Then

                                        AdvantageFramework.JobForecast.GetJobForecastJobTotalBudgetAndActual(DbContext, JobForecastJob.ID, Budget, Actual, Variance, TotalBilling, TotalRevenue)

                                        ReturnObject = New With {.Status = System.Net.HttpStatusCode.OK,
                                                                 .Budget = Budget,
                                                                 .Actual = Actual,
                                                                 .Variance = Variance,
                                                                 .TotalBilling = TotalBilling,
                                                                 .TotalRevenue = TotalRevenue}

                                    End If

                                End If

                            Else

                                ReturnObject = New With {.Status = System.Net.HttpStatusCode.BadRequest,
                                                         .Message = "This revision is not editable."}

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

            If ReturnObject Is Nothing Then

                ReturnObject = False

            End If

            Return Json(ReturnObject)

        End Function
        Public Sub UpdateJobColor(ByVal JobForecastJobID As Integer, ByVal Color As String)

            'objects
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing

            Try

                If Me.SecuritySession IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        JobForecastJob = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByID(DbContext, JobForecastJobID)

                        If JobForecastJob IsNot Nothing Then

                            If String.IsNullOrWhiteSpace(Color) = False Then

                                Try

                                    JobForecastJob.Color = System.Drawing.ColorTranslator.FromHtml(Color).ToArgb

                                Catch ex As Exception

                                End Try

                            Else

                                JobForecastJob.Color = Nothing

                            End If

                            AdvantageFramework.JobForecast.UpdateJobForecastJob(DbContext, JobForecastJob)

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub
        <AcceptVerbs("POST")>
        Public Function AddJobComponentsToForecast(ByVal RevisionID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            'objects
            Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
            Dim JobComponent As AdvantageFramework.Database.Entities.JobComponent = Nothing

            If RevisionID > 0 AndAlso JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, RevisionID)

                    If JobForecastRevision IsNot Nothing Then

                        JobComponent = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                        If JobComponent IsNot Nothing Then

                            Return Json(AdvantageFramework.JobForecast.InsertNewJobForecastJob(DbContext, JobForecastRevision, JobComponent))

                        End If

                    End If

                End Using

            End If

        End Function
        <AcceptVerbs("POST")>
        Public Function AddAllJobComponentsToForecast(ByVal RevisionID As Integer) As JsonResult



        End Function
        <AcceptVerbs("POST")>
        Public Function RemoveJobComponentsFromForecast(ByVal RevisionID As Integer, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As JsonResult

            'objects
            Dim JobForecastJob As AdvantageFramework.Database.Entities.JobForecastJob = Nothing

            If RevisionID > 0 AndAlso JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    JobForecastJob = (From Item In AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(DbContext, RevisionID)
                                      Where Item.JobNumber = JobNumber AndAlso
                                            Item.JobComponentNumber = JobComponentNumber
                                      Select Item).FirstOrDefault

                    If JobForecastJob IsNot Nothing Then

                        Return Json(AdvantageFramework.JobForecast.DeleteJobForecastJob(DbContext, JobForecastJob))

                    End If

                End Using

            End If

        End Function
        <AcceptVerbs("POST")>
        Public Function RemoveAllJobComponentsFromForecast(ByVal RevisionID As Integer) As JsonResult



        End Function
        <AcceptVerbs("POST")>
        Public Sub ActualizeJobForecast()



        End Sub

#End Region

#Region " -- Read Methods -- "

        Public Function JobForecast_Read(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As ActionResult

            'objects
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing
            Dim EmployeeCode As String, Year As String, Month As String

            Try

                If Me.SecuritySession IsNot Nothing Then

                    If Not String.IsNullOrWhiteSpace(Request("EmployeeCode")) Then

                        EmployeeCode = Request("EmployeeCode").Trim.ToString

                    End If

                    If Not String.IsNullOrWhiteSpace(Request("Year")) Then

                        Year = Request("Year").Trim.ToString

                    End If

                    If Not String.IsNullOrWhiteSpace(Request("Month")) Then

                        Month = Request("Month").Trim.ToString

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        DataSourceResult = AdvantageFramework.JobForecast.LoadCurrentJobForecasts(DbContext, EmployeeCode, Nothing, Nothing, Nothing, Me.SecuritySession.UserCode).AsQueryable().ToDataSourceResult(DataSourceRequest)

                    End Using

                End If

            Catch ex As Exception

            End Try

            Return Json(DataSourceResult)

        End Function
        Public Function Employees_Read() As JsonResult

            Dim Result As IEnumerable = Nothing

            Try

                If Me.SecuritySession IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Result = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList.
                                                                Select(Function(ActiveEmployee) New With {.Code = ActiveEmployee.Code,
                                                                                                          .Name = ActiveEmployee.ToString})

                    End Using

                End If

            Catch ex As Exception

            End Try

            Return Json(Result, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function PostPeriods_Read() As JsonResult

            Dim Result As IEnumerable = Nothing

            Try

                If Me.SecuritySession IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        Result = (From Entity In AdvantageFramework.Database.Procedures.PostPeriod.LoadAllYearEndPostPeriods(DbContext)
                                  Select New With {.[Year] = CInt(Entity.Year)}).ToList.OrderByDescending(Function(Entity) Entity.Year).ToList

                    End Using

                End If

            Catch ex As Exception

            End Try

            Return Json(Result, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function
        Public Function JobForecastDetails_Read(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As ActionResult

            'objects
            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing
            Dim EmployeeCode As String, Year As String, Month As String
            Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing

            Try

                If Me.SecuritySession IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, 1)

                        DataSourceResult = AdvantageFramework.JobForecast.BuildJobForecastJobDetailsDataTable(DbContext, JobForecastRevision).AsEnumerable().ToDataSourceResult(DataSourceRequest)

                    End Using

                End If

            Catch ex As Exception

            End Try

            Return Json(DataSourceResult)

        End Function
        Public Function JobForecast_SelectedJobComponents(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest) As ActionResult

            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing
            Dim RevisionID As Integer = Nothing
            Dim JobForecastJobs As IEnumerable(Of AdvantageFramework.Database.Entities.JobForecastJob) = Nothing
            Dim JobComponentViews As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            Try

                RevisionID = CInt(Request("RevisionID"))

                If RevisionID > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        JobForecastJobs = AdvantageFramework.Database.Procedures.JobForecastJob.LoadByJobForecastRevisionID(DbContext, RevisionID).ToList

                        JobComponentViews = (From Item In AdvantageFramework.Database.Procedures.JobComponentView.LoadAllOpen(DbContext).ToList
                                             Join JobForecastJob In JobForecastJobs On Item.JobNumber Equals JobForecastJob.JobNumber And Item.JobComponentNumber Equals JobForecastJob.JobComponentNumber
                                             Select Item).ToList

                        DataSourceResult = JobComponentViews.AsQueryable.ToDataSourceResult(DataSourceRequest)

                    End Using

                End If

            Catch ex As Exception

            End Try

            Return Json(DataSourceResult)

        End Function
        Public Function JobForecast_AvailableJobComponents(ByVal DataSourceRequest As Kendo.Mvc.UI.DataSourceRequest, ByVal Abc As String) As ActionResult

            Dim DataSourceResult As Kendo.Mvc.UI.DataSourceResult = Nothing
            Dim RevisionID As Integer = Nothing
            Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
            Dim JobComponentViews As IEnumerable(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing
            Dim ClientCode, DivisionCode, ProductCode As String

            Try

                RevisionID = CInt(Request("RevisionID"))
                ClientCode = Request("ClientCode")
                DivisionCode = Request("DivisionCode")
                ProductCode = Request("ProductCode")

                If RevisionID > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, RevisionID)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                            JobComponentViews = (From Item In AdvantageFramework.JobForecast.LoadAllJobComponents(DbContext, SecurityDbContext, Me.SecuritySession.User)
                                                 Group Join JfJob In JobForecastRevision.JobForecastJobs.ToList On JfJob.JobNumber Equals Item.JobNumber And JfJob.JobComponentNumber Equals Item.JobComponentNumber Into CompList = Group
                                                 From Comp In CompList.DefaultIfEmpty()
                                                 Where Comp Is Nothing
                                                 Select Item).ToList

                            DataSourceResult = JobComponentViews.AsQueryable.ToDataSourceResult(DataSourceRequest)

                        End Using

                    End Using

                End If

            Catch ex As Exception

            End Try

            Return Json(DataSourceResult)

        End Function
        Public Function GetForecastPostPeriods(ByVal JobForecastRevisionID As Integer) As JsonResult

            'objects
            Dim JobForecast As AdvantageFramework.Database.Entities.JobForecast = Nothing
            Dim PostPeriods As IEnumerable(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    JobForecast = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, JobForecastRevisionID).JobForecast

                    PostPeriods = AdvantageFramework.JobForecast.LoadPostPeriodsByJobForecast(DbContext, JobForecast)

                End Using

            Catch ex As Exception

            End Try

            Return Json((From Item In PostPeriods Select New With {.Code = Item.Code, .Description = Item.Description, .CodeAndDescription = Item.Code & " - " & Item.Description}).ToList, JsonRequestBehavior.AllowGet)

        End Function

#End Region

#Region " -- View Methods -- "

        Public Function Index() As ActionResult

            Return View()

        End Function
        Public Function Edit(ByVal id As Integer) As ActionResult

            'objects
            Dim JobForecastRevision As AdvantageFramework.Database.Entities.JobForecastRevision = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            If id > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                    JobForecastRevision = AdvantageFramework.Database.Procedures.JobForecastRevision.LoadByID(DbContext, id)

                    ViewBag.JobForecastRevision = JobForecastRevision

                    If JobForecastRevision IsNot Nothing Then

                        DataTable = AdvantageFramework.JobForecast.BuildJobForecastJobDetailsDataTable(DbContext, JobForecastRevision)

                        For Each DataColumn In DataTable.Columns.OfType(Of System.Data.DataColumn)()

                            If DataColumn.ColumnName.EndsWith("_Billing") Then

                                DataColumn.ColumnName.Replace("_Billing", "")
                                DataColumn.ColumnName = "Billing_" & DataColumn.ColumnName

                            ElseIf DataColumn.ColumnName.EndsWith("_Revenue") Then

                                DataColumn.ColumnName.Replace("_Revenue", "")
                                DataColumn.ColumnName = "Revenue_" & DataColumn.ColumnName

                            End If

                        Next

                    End If

                End Using

            End If

            Return View(DataTable)

        End Function
        Public Function SelectJobComponents(ByVal ID As Integer) As ActionResult

            Return View()

        End Function
        Public Function Actualize(ByVal ID As Integer, ByVal Components As String) As ActionResult

            'objects
            Dim ActualizeSettings As Webvantage.ViewModels.JobForecastModel.ActualizeSettings = Nothing
            Dim JobComponents As IEnumerable(Of Webvantage.ViewModels.JobForecastModel.JobComponent) = Nothing

            ActualizeSettings = New JobForecastModel.ActualizeSettings

            If Components.IndexOf("?opener=") > -1 Then

                TempData("opener") = Components.Split("?opener=").Last.Replace("opener=", "")
                Components = Components.Split("?opener=").First

            End If

            Try

                JobComponents = Newtonsoft.Json.JsonConvert.DeserializeObject(Of IEnumerable(Of ViewModels.JobForecastModel.JobComponent))(Components)

            Catch ex As Exception

            End Try

            TempData("JobComponents") = JobComponents
            TempData("JobForecastRevisionID") = ID

            Return View(ActualizeSettings)

        End Function
        <HttpPost>
        Public Function Actualize(ByVal ActualizeSettings As Webvantage.ViewModels.JobForecastModel.ActualizeSettings) As ActionResult

            Dim JobForecastRevisionID As Integer = 0

            If TempData("JobForecastRevisionID") IsNot Nothing Then

                JobForecastRevisionID = CInt(TempData("JobForecastRevisionID"))

            End If

            If TempData("JobComponents") IsNot Nothing Then

                Try

                    ActualizeSettings.Components = DirectCast(TempData("JobComponents"), IEnumerable(Of Webvantage.ViewModels.JobForecastModel.JobComponent))

                Catch ex As Exception

                End Try

            End If

            If JobForecastRevisionID > 0 Then

                If ModelState.IsValid Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                        For Each JobComponent In ActualizeSettings.Components

                            'AdvantageFramework.JobForecast.ActualizeJobComponent(DbContext, DbContext, JobForecastRevisionID, JobComponent.JobNumber, JobComponent.JobComponentNumber, ActualizeSettings.PostPeriodCode, ActualizeSettings.RollForwardBalances)

                        Next

                    End Using

                    ViewData("opener") = TempData("opener")
                    ViewData("Submitted") = True

                End If

            End If

            'if we got this far, something failed, redisplay form
            Return View(ActualizeSettings)

        End Function

#End Region

#End Region

    End Class

End Namespace
