Imports System.Web.Mvc

Namespace Controllers.ProjectManagement

    Public Class EstimateController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "ProjectManagement/Estimate/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.ProjectManagement.EstimateController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As System.Web.Routing.RequestContext)

            MyBase.Initialize(requestContext)

            _Controller = New AdvantageFramework.Controller.ProjectManagement.EstimateController(Me.SecuritySession)

        End Sub

#Region " API "
        <HttpGet>
        Public Function Search(OfficeCode As String, ClientCode As String, DivisionCode As String, ProductCode As String, SalesClassCode As String, EstimateNumber As Integer,
            EstimateComponentNumber As Short, JobCode As Integer, ComponentCode As Short, CampaignID As Integer, ShowAll As Boolean) As System.Web.Mvc.JsonResult

            'objects
            Dim Estimates As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Estimate.EstimateSearchViewModel)


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Estimates = _Controller.GetEstimates(DbContext, Me.SecuritySession.UserCode, OfficeCode, ClientCode,
                                                     DivisionCode, ProductCode, SalesClassCode, EstimateNumber, EstimateComponentNumber,
                                                     JobCode, ComponentCode, CampaignID, ShowAll)

            End Using

            Return MaxJson(Estimates, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function CanAdd() As JsonResult

            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission
            Dim HasAccess As Boolean = False

            Dim _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))


            Using DbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext,
                                                                                                                     AdvantageFramework.Security.Application.Webvantage,
                                                                                                                     AdvantageFramework.Security.Modules.ProjectManagement_Estimating.ToString("F"),
                                                                                                                     _Session.User.ID)

                HasAccess = UserPermission.CanAdd

            End Using

            Return Json(HasAccess, JsonRequestBehavior.AllowGet)

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
                                     ByVal EstimateNumber As Integer?,
                                     ByVal EstimateComponentNumber As Integer?,
                                     ByVal ShowClosed As Boolean
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
                If EstimateNumber IsNot Nothing Then
                    .EstimateNumber = EstimateNumber
                End If
                If EstimateComponentNumber IsNot Nothing Then
                    .EstimateComponentNumber = EstimateComponentNumber
                End If
                .Add("closedarchived", ShowClosed)
                .Add("isbookmark", "1")
                .Build()
            End With

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_EstimateSearch
                .UserCode = Session("UserCode")
                .Name = "Estimate Search"
                .PageURL = "modules/project-management/estimate/estimate" & qs.ToString()

            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                'Me.ShowMessage(s)
            End If

        End Function

#End Region

#End Region

    End Class

End Namespace



'Join Estimate In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext) On Estimate.JobNumber Equals Job.Number

'.EstimateNumber = Estimate.EstimateNumber,
'.EstimateComponentNumber = Estimate.EstimateComponentNumber

