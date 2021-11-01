Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Web.Mvc
Imports AdvantageFramework
Imports AdvantageFramework.ViewModels.ProjectManagement.Campaign

Namespace Controllers.ProjectManagement

    Public Class CampaignController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "ProjectManagement/Campaign/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        ' Private _Controller As Object = Nothing 'AdvantageFramework.Controller.ProjectManagement.JobJacketController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As System.Web.Routing.RequestContext)

            MyBase.Initialize(requestContext)

            ' _Controller = New Object ' New AdvantageFramework.Controller.ProjectManagement.JobJacketController(Me.SecuritySession)

        End Sub

#Region " API "

        <System.Web.Mvc.HttpGet>
        Public Function Search(OfficeCode As String, ClientCode As String, DivisionCode As String, ProductCode As String,
                               CampaignCode As String, ShowClosedCampaigns As Boolean,
                               ByVal Skip As Integer, ByVal Take As Integer,
                               Optional FromDate As Date? = Nothing, Optional ToDate As Date? = Nothing) As System.Web.Mvc.JsonResult

            Dim Campaigns As Generic.List(Of AdvantageFramework.ViewModels.ProjectManagement.Campaign.CampaignSearchDTO)
            Dim totalRows As Integer


            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@USER_ID", Me.SecuritySession.UserCode))
                arParams.Add(New SqlParameter("@OfficeCode", OfficeCode))
                arParams.Add(New SqlParameter("@ClientCode", ClientCode))
                arParams.Add(New SqlParameter("@DivisionCode", DivisionCode))
                arParams.Add(New SqlParameter("@ProductCode", ProductCode))
                arParams.Add(New SqlParameter("@CampaignCode", CampaignCode))
                arParams.Add(New SqlParameter("@ShowClosed", If(ShowClosedCampaigns = True, 1, 0)))

                Dim FromDateParameter As SqlParameter = New SqlParameter("@FromDate", SqlDbType.Date)
                FromDateParameter.IsNullable = True
                FromDateParameter.Value = If(FromDate Is Nothing, DBNull.Value, FromDate)
                arParams.Add(FromDateParameter)

                Dim ToDateParameter As SqlParameter = New SqlParameter("@ToDate", SqlDbType.Date)
                ToDateParameter.IsNullable = True
                ToDateParameter.Value = If(ToDate Is Nothing, DBNull.Value, ToDate)
                arParams.Add(ToDateParameter)
                arParams.Add(New SqlParameter("@Skip", Skip))
                arParams.Add(New SqlParameter("@Take", Take))
                Dim outParam As SqlParameter = New SqlParameter()
                outParam.SqlDbType = System.Data.SqlDbType.Int
                outParam.ParameterName = "@TotalRows"
                outParam.Value = 0
                outParam.Direction = System.Data.ParameterDirection.Output
                arParams.Add(outParam)

                Dim Command As String = "EXEC [dbo].[usp_wv_campaign_search_v2] @USER_ID, @OfficeCode, @ClientCode, @DivisionCode, @ProductCode, @CampaignCode, @ShowClosed, @FromDate, @ToDate, @Skip, @Take, @TotalRows out"


                Campaigns = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.Campaign.CampaignSearchDTO)(Command, arParams.ToArray).ToList

                If Not IsDBNull(outParam.Value) Then
                    totalRows = outParam.Value
                End If

            End Using


            Return MaxJson(New With {.total = totalRows, .data = Campaigns}, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function CanAdd() As JsonResult

            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission
            Dim HasAccess As Boolean = False

            Dim _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))


            Using DbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext,
                                                                                                                     AdvantageFramework.Security.Application.Webvantage,
                                                                                                                     AdvantageFramework.Security.Modules.ProjectManagement_Campaigns.ToString("F"),
                                                                                                                     _Session.User.ID)

                HasAccess = UserPermission.CanAdd

            End Using

            Return Json(HasAccess, JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function RequireDivisionProduct() As JsonResult
            Dim DivisionProduct As Boolean = False
            Dim Setting As Database.Entities.Setting

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString"), Session("UserCode"))
                Setting = Database.Procedures.Setting.LoadBySettingCode(DataContext, "CAMP_REQUIRE_DIV_PRD")

                If Setting IsNot Nothing Then
                    DivisionProduct = CType(Setting.Value, Boolean)
                End If
            End Using

            Return Json(DivisionProduct, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Public Function Create(ByVal OfficeCode As String, ByVal ClientCode As String, ByVal DivisionCode As String,
                               ByVal ProductCode As String, ByVal CampaignCode As String, ByVal CampaignDescription As String,
                               ByVal AlertGroupCode As String, ByVal CampaignType As Short) As JsonResult
            Dim Campaign As New AdvantageFramework.Database.Entities.Campaign
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                Campaign.DbContext = DbContext

                Campaign.OfficeCode = If(OfficeCode.Trim() = "", Nothing, OfficeCode.Trim())
                Campaign.ClientCode = If(ClientCode.Trim() = "", Nothing, ClientCode.Trim())
                Campaign.DivisionCode = If(DivisionCode.Trim() = "", Nothing, DivisionCode.Trim())
                Campaign.ProductCode = If(ProductCode.Trim() = "", Nothing, ProductCode.Trim())
                Campaign.Code = If(CampaignCode.Trim() = "", Nothing, CampaignCode.Trim())
                Campaign.Name = If(CampaignDescription.Trim() = "", Nothing, CampaignDescription.Trim())
                Campaign.AlertGroupCode = If(AlertGroupCode.Trim() = "", Nothing, AlertGroupCode.Trim())
                Campaign.CampaignType = CampaignType
                Campaign.IsClosed = 0

                ErrorText = Campaign.ValidateEntity(IsValid)

                If IsValid = True Then
                    Try

                        DbContext.Campaigns.Add(Campaign)

                        If DbContext.Campaigns.Count = 0 Then

                            Campaign.ID = 1

                        Else

                            Campaign.ID = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Campaign)
                                           Select Entity.ID).Max + 1

                        End If

                        DbContext.SaveChanges()

                    Catch ex As Exception
                        IsValid = False
                        ErrorText = ex.Message
                    End Try
                End If
            End Using

            Return Json(New With {.success = IsValid, .message = ErrorText, .campaignId = Campaign.ID}, "application/json", JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function GetDefaultCampaignID() As JsonResult
            Dim DefaultCode As String = ""
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString"), Session("UserCode"))

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CAMP_AUTO_GEN_CODE.ToString)

                End Using

                If (Setting IsNot Nothing AndAlso Setting.Value = 1) Then

                    Try

                        DefaultCode = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Campaign)
                                       Select Entity.ID).Max + 1
                    Catch ex As Exception
                        DefaultCode = ""
                    End Try

                    If DefaultCode = "" Then
                        DefaultCode = "1"
                    End If
                End If
            End Using

            Return Json(DefaultCode, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <System.Web.Mvc.HttpGet>
        Public Function GetCampaign(ByVal id As String) As JsonResult

            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim campaignDTO As CampaignDTO
            Dim campaignDetailDTOs As List(Of CampaignDetailDTO) = New List(Of CampaignDetailDTO)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, id)

                campaignDTO = New CampaignDTO With {
                        .ClientCode = Campaign.ClientCode,
                        .DivisionCode = Campaign.DivisionCode,
                        .ProductCode = Campaign.ProductCode,
                        .Code = Campaign.Code,
                        .StartDate = Campaign.StartDate,
                        .EndDate = Campaign.EndDate,
                        .Comment = If(Campaign.Comment = Nothing, "", Campaign.Comment),
                        .Name = Campaign.Name,
                        .IsDirectResponse = If(Campaign.IsDirectResponse = Nothing, 0, Campaign.IsDirectResponse),
                        .IsMagazine = If(Campaign.IsMagazine = Nothing, 0, Campaign.IsMagazine),
                        .IsNewspaper = If(Campaign.IsNewspaper = Nothing, 0, Campaign.IsNewspaper),
                        .IsOutOfHome = If(Campaign.IsOutOfHome = Nothing, 0, Campaign.IsOutOfHome),
                        .IsPrint = If(Campaign.IsPrint = Nothing, 0, Campaign.IsPrint),
                        .IsRadio = If(Campaign.IsRadio = Nothing, 0, Campaign.IsRadio),
                        .IsTelevision = If(Campaign.IsTelevision = Nothing, 0, Campaign.IsTelevision),
                        .IsOther = If(Campaign.IsOther = Nothing, 0, Campaign.IsOther),
                        .OtherDescription = Campaign.OtherDescription,
                        .ID = Campaign.ID,
                        .IsClosed = If(Campaign.IsClosed = Nothing, 0, Campaign.IsClosed),
                        .IsActive = If(Campaign.IsActive = Nothing, 0, Campaign.IsActive),
                        .BillingBudgetAmount = Campaign.BillingBudgetAmount,
                        .IncomeBudgetAmount = Campaign.IncomeBudgetAmount,
                        .CampaignType = Campaign.CampaignType,
                        .OfficeCode = Campaign.OfficeCode,
                        .AlertGroupCode = Campaign.AlertGroupCode,
                        .IsInternetAds = If(Campaign.IsInternetAds = Nothing, 0, Campaign.IsInternetAds),
                        .AdNumber = Campaign.AdNumber,
                        .MarketCode = Campaign.MarketCode,
                        .JobNumber = Campaign.JobNumber,
                        .JobComponentNumber = Campaign.JobComponentNumber,
                        .ClientWebsiteID = Campaign.ClientWebsiteID,
                        .AdServerID = Campaign.AdServerID,
                        .AdServerCampaignID = Campaign.AdServerCampaignID,
                        .AdServerCreatedBy = Campaign.AdServerCreatedBy
                    }

                For Each cd In Campaign.CampaignDetails

                    campaignDetailDTOs.Add(New CampaignDetailDTO() With {
                        .BillingBudgetAmount = cd.BillingBudgetAmount,
                        .CampaignDetailTypeCode = cd.CampaignDetailType,
                        .CampaignID = cd.CampaignID,
                        .DepartmentTeamCode = cd.DepartmentTeamCode,
                        .FunctionCode = cd.FunctionCode,
                        .ID = cd.ID,
                        .IncomeBudgetAmount = cd.IncomeBudgetAmount,
                        .PostPeriodCode = cd.PostPeriodCode,
                        .RevisedDate = cd.RevisedDate,
                        .SalesClassCode = cd.SalesClassCode,
                        .UserCode = cd.UserCode
                                           })
                Next
            End Using

            Return Json(campaignDTO, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <System.Web.Mvc.HttpPost>
        Public Function SaveCampaign(ByVal campaignDTO As CampaignDTO) As JsonResult
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, campaignDTO.ID)

                Campaign.AdNumber = campaignDTO.AdNumber
                Campaign.AdServerCampaignID = campaignDTO.AdServerCampaignID
                Campaign.AdServerCreatedBy = campaignDTO.AdServerCreatedBy
                Campaign.AdServerID = campaignDTO.AdServerID
                Campaign.AlertGroupCode = campaignDTO.AlertGroupCode
                Campaign.BillingBudgetAmount = campaignDTO.BillingBudgetAmount
                Campaign.CampaignType = campaignDTO.CampaignType
                Campaign.ClientCode = campaignDTO.ClientCode
                Campaign.ClientWebsiteID = campaignDTO.ClientWebsiteID
                Campaign.Code = campaignDTO.Code
                Campaign.Comment = campaignDTO.Comment
                Campaign.DivisionCode = campaignDTO.DivisionCode
                Campaign.EndDate = campaignDTO.EndDate
                Campaign.ID = campaignDTO.ID
                Campaign.IncomeBudgetAmount = campaignDTO.IncomeBudgetAmount
                Campaign.IsActive = campaignDTO.IsActive
                Campaign.IsClosed = campaignDTO.IsClosed
                Campaign.IsDirectResponse = campaignDTO.IsDirectResponse
                Campaign.IsInternetAds = campaignDTO.IsInternetAds
                Campaign.IsMagazine = campaignDTO.IsMagazine
                Campaign.IsNewspaper = campaignDTO.IsNewspaper
                Campaign.IsOther = campaignDTO.IsOther
                Campaign.IsOutOfHome = campaignDTO.IsOutOfHome
                Campaign.IsPrint = campaignDTO.IsPrint
                Campaign.IsRadio = campaignDTO.IsRadio
                Campaign.IsTelevision = campaignDTO.IsTelevision
                Campaign.JobComponentNumber = campaignDTO.JobComponentNumber
                Campaign.JobNumber = campaignDTO.JobNumber
                Campaign.MarketCode = campaignDTO.MarketCode
                Campaign.Name = campaignDTO.Name
                Campaign.OfficeCode = campaignDTO.OfficeCode
                Campaign.OtherDescription = campaignDTO.OtherDescription
                Campaign.ProductCode = campaignDTO.ProductCode
                Campaign.StartDate = campaignDTO.StartDate

                IsValid = AdvantageFramework.Database.Procedures.Campaign.Update(DbContext, Campaign, ErrorText)
            End Using

            Return Json(New With {.success = IsValid, .message = ErrorText, .campaignId = campaignDTO.ID}, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <System.Web.Mvc.HttpGet>
        Public Function DeleteCampaign(ByVal id As Integer) As JsonResult
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
            Dim Success As Boolean = True
            Dim ErrorText As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, id)

                If Not AdvantageFramework.Database.Procedures.Campaign.Delete(DbContext, Campaign) Then
                    Success = False
                    ErrorText = "The campaign is in use and cannot be deleted."
                End If
            End Using
            Return Json(New With {.success = Success, .message = ErrorText}, "application/json", JsonRequestBehavior.AllowGet)
        End Function


        <System.Web.Mvc.HttpGet>
        Public Function GetAllAttachedMedia(ByVal CmpID As Integer) As JsonResult
            Dim AttachedMedia As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@CmpID", CmpID))

                AttachedMedia = (From Item In DbContext.Database.SqlQuery(Of AdvantageFramework.AttachedMediaDTO)("exec usp_wv_get_attached_media_all @CmpID", arParams.ToArray)
                                 ).ToList


            End Using

            Return Json(AttachedMedia, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Public Function GetLandingPage(ByVal ClientCode As String) As JsonResult
            Dim LandingPages As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                LandingPages = (From Entity In AdvantageFramework.Database.Procedures.ClientWebsite.LoadByClientCode(DbContext, ClientCode)
                                Where Entity.IsInactive = False
                                Select New With {
                                    .Name = Entity.WebsiteAddress,
                                    .Code = Entity.ID,
                                    .Type = Entity.WebsiteType.Description,
                                    .Description = Entity.WebsiteName
                                    }).ToList
            End Using

            Return Json(LandingPages, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function GetCampaignDetails(ByVal ID As Integer) As JsonResult

            Dim Campaign As AdvantageFramework.Database.Entities.Campaign
            Dim CampaignDetails As Generic.List(Of AdvantageFramework.Database.Entities.CampaignDetail) = Nothing
            Dim BillingMediaBudgetAmount As Decimal = 0.00
            Dim BillingProductionBudgetAmount As Decimal = 0.00
            Dim BillingCombinedBudgetAmount As Decimal = 0.00
            Dim BillingTotalAllocatedAmount As Decimal = 0.00

            Dim IncomeMediaBudgetAmount As Decimal = 0.00
            Dim IncomeProductionBudgetAmount As Decimal = 0.00
            Dim IncomeCombinedBudgetAmount As Decimal = 0.00
            Dim IncomeTotalAllocatedAmount As Decimal = 0.00

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, ID)

            End Using

            If Campaign IsNot Nothing Then
                CampaignDetails = Campaign.CampaignDetails.OrderBy(Function(CampaignDetail) CampaignDetail.ID).ToList
            End If

            BillingMediaBudgetAmount = CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Media.ToString).Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0))
            BillingProductionBudgetAmount = CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Production.ToString).Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0))
            BillingCombinedBudgetAmount = CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType Is Nothing OrElse CampaignDetail.CampaignDetailType = "").Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0))
            BillingTotalAllocatedAmount = CampaignDetails.Sum(Function(CampaignDetail) CampaignDetail.BillingBudgetAmount.GetValueOrDefault(0))

            IncomeMediaBudgetAmount = CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Media.ToString).Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0))
            IncomeProductionBudgetAmount = CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType = AdvantageFramework.Database.Entities.CampaignDetailTypes.Production.ToString).Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0))
            IncomeCombinedBudgetAmount = CampaignDetails.Where(Function(CampaignDetail) CampaignDetail.CampaignDetailType Is Nothing OrElse CampaignDetail.CampaignDetailType = "").Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0))
            IncomeTotalAllocatedAmount = CampaignDetails.Sum(Function(CampaignDetail) CampaignDetail.IncomeBudgetAmount.GetValueOrDefault(0))

            Dim Results As New With {
                .CampaignIdentifier = Campaign.ID,
                .CampaignCode = Campaign.Code,
                .CampaignName = Campaign.Name,
                .Client = New With {
                        .Name = If(Campaign.Client IsNot Nothing, Campaign.Client.Name, ""),
                        .Code = If(Campaign.Client IsNot Nothing, Campaign.Client.Code, "")
                },
                .Division = New With {
                        .Name = If(Campaign.Division IsNot Nothing, Campaign.Division.Name, ""),
                        .Code = If(Campaign.Division IsNot Nothing, Campaign.Division.Code, "")
                },
                .Product = New With {
                        .Name = If(Campaign.Product IsNot Nothing, Campaign.Product.Name, ""),
                        .Code = If(Campaign.Product IsNot Nothing, Campaign.Product.Code, "")
                },
                .BillingBudgetAmount = Campaign.BillingBudgetAmount,
                .IncomeBudgetAmount = Campaign.IncomeBudgetAmount,
                .BillingMediaBudgetAmount = BillingMediaBudgetAmount,
                .BillingProductionBudgetAmount = BillingProductionBudgetAmount,
                .BillingCombinedBudgetAmount = BillingCombinedBudgetAmount,
                .BillingTotalAllocatedAmount = BillingTotalAllocatedAmount,
                .IncomeMediaBudgetAmount = IncomeMediaBudgetAmount,
                .IncomeProductionBudgetAmount = IncomeProductionBudgetAmount,
                .IncomeCombinedBudgetAmount = IncomeCombinedBudgetAmount,
                .IncomeTotalAllocatedAmount = IncomeTotalAllocatedAmount}

            Return Json(Results, "application/json", JsonRequestBehavior.AllowGet)

        End Function

        Public Function Export(ByVal ID As Integer) As JsonResult

        End Function

        <HttpPost>
        Public Function CreateBudget(ByVal ID As Integer, ByVal BeginPostPeriodCode As String, ByVal MaxPeriods As Integer) As JsonResult
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign
            Dim PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod) = Nothing
            Dim CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail = Nothing
            Dim BeginPostPeriod As AdvantageFramework.Database.Entities.PostPeriod = Nothing
            Dim BillingBudgetAmount As Decimal = 0
            Dim IncomeBudgetAmount As Decimal = 0
            Dim PostPeriodCount As Integer = 0
            Dim Success = True
            Dim Message = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                BeginPostPeriod = AdvantageFramework.Database.Procedures.PostPeriod.LoadByPostPeriodCode(DbContext, BeginPostPeriodCode)

                If BeginPostPeriod IsNot Nothing Then

                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, ID)

                    If Campaign IsNot Nothing Then


                        For Each CampDetail In Campaign.CampaignDetails.ToList

                            AdvantageFramework.Database.Procedures.CampaignDetail.Delete(DbContext, CampDetail)

                        Next


                        PostPeriods = AdvantageFramework.Database.Procedures.PostPeriod.LoadAllActiveNonYearEndPostPeriods(DbContext).Where(Function(PostPrd) PostPrd.StartDate >= BeginPostPeriod.StartDate).ToList

                        If Campaign.BillingBudgetAmount.GetValueOrDefault(0) > 0 Then

                            Try

                                BillingBudgetAmount = CDec(FormatNumber(Campaign.BillingBudgetAmount.GetValueOrDefault(0) / PostPeriods.Count, 2))

                            Catch ex As Exception
                                BillingBudgetAmount = 0
                            End Try

                        End If

                        If Campaign.IncomeBudgetAmount.GetValueOrDefault(0) > 0 Then

                            Try

                                IncomeBudgetAmount = CDec(FormatNumber(Campaign.IncomeBudgetAmount.GetValueOrDefault(0) / PostPeriods.Count, 2))

                            Catch ex As Exception
                                IncomeBudgetAmount = 0
                            End Try

                        End If

                        For Each PostPeriod In PostPeriods.ToList

                            If PostPeriodCount < MaxPeriods Then

                                CampaignDetail = New AdvantageFramework.Database.Entities.CampaignDetail

                                CampaignDetail.DbContext = DbContext

                                CampaignDetail.CampaignID = ID
                                CampaignDetail.PostPeriodCode = PostPeriod.Code
                                CampaignDetail.BillingBudgetAmount = BillingBudgetAmount
                                CampaignDetail.IncomeBudgetAmount = IncomeBudgetAmount

                                AdvantageFramework.Database.Procedures.CampaignDetail.Insert(DbContext, CampaignDetail)

                                PostPeriodCount += 1

                            End If

                        Next
                    Else
                        Success = False
                        Message = "The campaign you are trying to create a budget for does not exits anymore."
                    End If

                Else
                    Success = False
                    Message = "Please enter a valid post period code."
                End If

            End Using

            Return Json(New With {.Success = Success, .Message = Message}, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Public Function ReAllocateBudget(ByVal ID As Integer) As JsonResult
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign
            Dim BillingBudgetAmount As Decimal
            Dim IncomeBudgetAmount As Decimal

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, ID)

                If Campaign IsNot Nothing Then

                    If Campaign.BillingBudgetAmount > 0 Then

                        Try

                            BillingBudgetAmount = CDec(FormatNumber(Campaign.BillingBudgetAmount / Campaign.CampaignDetails.Count, 2))

                        Catch ex As Exception
                            BillingBudgetAmount = 0
                        End Try

                    End If

                    If Campaign.IncomeBudgetAmount > 0 Then

                        Try

                            IncomeBudgetAmount = CDec(FormatNumber(Campaign.IncomeBudgetAmount / Campaign.CampaignDetails.Count, 2))

                        Catch ex As Exception
                            IncomeBudgetAmount = 0
                        End Try

                    End If

                    For Each CampaignDetail In Campaign.CampaignDetails.ToList

                        CampaignDetail.BillingBudgetAmount = BillingBudgetAmount
                        CampaignDetail.IncomeBudgetAmount = IncomeBudgetAmount

                        AdvantageFramework.Database.Procedures.CampaignDetail.Update(DbContext, CampaignDetail)

                    Next

                End If

            End Using

            Return Json(New With {.Success = "Success"}, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function GetPeriod() As JsonResult
            Dim Period As CampaignDetailDTO

            Return Json(Period, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function GetPeriods(ByVal id As Integer) As JsonResult
            Dim Periods As IEnumerable

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@CampaignCode", id))

                Dim Command As String = "EXEC [dbo].[usp_wv_GetCampaignDetails] @CampaignCode"

                Periods = (From Item In DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.Campaign.CampaignDetailDTO)(Command, arParams.ToArray)
                           Select New With {
                                    .CampaignID = Item.CampaignID,
                                    .ID = Item.ID,
                                    .IncomeBudgetAmount = Item.IncomeBudgetAmount,
                                    .BillingBudgetAmount = Item.BillingBudgetAmount,
                                    .RevisedDate = Item.RevisedDate,
                                    .UserCode = Item.UserCode,
                                    .SalesClassCode = If(Not String.IsNullOrWhiteSpace(Item.SalesClassCode), Item.SalesClassCode, ""),
                                    .SalesClassName = If(Not String.IsNullOrWhiteSpace(Item.SalesClassCode), Item.SalesClassDesc & " (" & Item.SalesClassCode & ")", ""),
                                    .DepartmentTeamCode = Item.DepartmentTeamCode,
                                    .DepartmentTeamName = If(Not String.IsNullOrWhiteSpace(Item.DepartmentTeamCode), Item.DepartmentTeamDesc & " (" & Item.DepartmentTeamCode & ")", ""),
                                    .FunctionCode = Item.FunctionCode,
                                    .FunctionName = If(Not String.IsNullOrWhiteSpace(Item.FunctionCode), Item.FunctionDesc & " (" & Item.FunctionCode & ")", ""),
                                    .PostPeriodCode = Item.PostPeriodCode,
                                    .PostPeriodName = If(Not String.IsNullOrWhiteSpace(Item.PostPeriodCode), Item.PostPeriodCode & " - " & Item.PostPeriodDesc, ""),
                                    .CampaignDetailTypeCode = Item.CampaignDetailTypeCode,
                                    .CampaignDetailTypeName = If(Not String.IsNullOrWhiteSpace(Item.CampaignDetailTypeCode), Item.CampaignDetailTypeDesc, "")
                               }).ToList

            End Using


            Return Json(Periods, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function UpdatePeriod(ByVal Period As CampaignDetailDTO) As JsonResult

            Dim CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail = Nothing
            Dim Success As Boolean = True
            Dim Item As AdvantageFramework.ViewModels.ProjectManagement.Campaign.CampaignDetailDTO

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                CampaignDetail = AdvantageFramework.Database.Procedures.CampaignDetail.Load(DbContext, Period.CampaignID, Period.ID).FirstOrDefault

                CampaignDetail.BillingBudgetAmount = Period.BillingBudgetAmount
                CampaignDetail.CampaignDetailType = If(Not String.IsNullOrWhiteSpace(Period.CampaignDetailTypeCode), Period.CampaignDetailTypeCode, Nothing)
                CampaignDetail.CampaignID = Period.CampaignID
                CampaignDetail.DepartmentTeamCode = If(Not String.IsNullOrWhiteSpace(Period.DepartmentTeamCode), Period.DepartmentTeamCode, Nothing)
                CampaignDetail.FunctionCode = If(Not String.IsNullOrWhiteSpace(Period.FunctionCode), Period.FunctionCode, Nothing)
                CampaignDetail.IncomeBudgetAmount = Period.IncomeBudgetAmount
                CampaignDetail.PostPeriodCode = If(Not String.IsNullOrWhiteSpace(Period.PostPeriodCode), Period.PostPeriodCode, Nothing)
                CampaignDetail.RevisedDate = Period.RevisedDate
                CampaignDetail.SalesClassCode = If(Not String.IsNullOrWhiteSpace(Period.SalesClassCode), Period.SalesClassCode, Nothing)
                CampaignDetail.UserCode = Period.UserCode

                Success = AdvantageFramework.Database.Procedures.CampaignDetail.Update(DbContext, CampaignDetail)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@CampaignCode", Period.CampaignID))
                arParams.Add(New SqlParameter("@ID", Period.ID))

                Dim Command As String = "EXEC [dbo].[usp_wv_GetCampaignDetail] @CampaignCode, @ID"

                Item = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.Campaign.CampaignDetailDTO)(Command, arParams.ToArray).FirstOrDefault()

            End Using

            Dim rv As New With {
                                    .CampaignID = Item.CampaignID,
                                    .ID = Item.ID,
                                    .IncomeBudgetAmount = Item.IncomeBudgetAmount,
                                    .BillingBudgetAmount = Item.BillingBudgetAmount,
                                    .RevisedDate = Item.RevisedDate,
                                    .UserCode = Item.UserCode,
                                    .SalesClassCode = If(Not String.IsNullOrWhiteSpace(Item.SalesClassCode), Item.SalesClassCode, ""),
                                    .SalesClassName = If(Not String.IsNullOrWhiteSpace(Item.SalesClassCode), Item.SalesClassDesc & " (" & Item.SalesClassCode & ")", ""),
                                    .DepartmentTeamCode = Item.DepartmentTeamCode,
                                    .DepartmentTeamName = If(Not String.IsNullOrWhiteSpace(Item.DepartmentTeamCode), Item.DepartmentTeamDesc & " (" & Item.DepartmentTeamCode & ")", ""),
                                    .FunctionCode = Item.FunctionCode,
                                    .FunctionName = If(Not String.IsNullOrWhiteSpace(Item.FunctionCode), Item.FunctionDesc & " (" & Item.FunctionCode & ")", ""),
                                    .PostPeriodCode = Item.PostPeriodCode,
                                    .PostPeriodName = If(Not String.IsNullOrWhiteSpace(Item.PostPeriodCode), Item.PostPeriodCode & " - " & Item.PostPeriodDesc, ""),
                                    .CampaignDetailTypeCode = Item.CampaignDetailTypeCode,
                                    .CampaignDetailTypeName = If(Not String.IsNullOrWhiteSpace(Item.CampaignDetailTypeCode), Item.CampaignDetailTypeDesc, "")
                    }

            Return Json(rv, "application/json", JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function CreatePeriod(ByVal Period As CampaignDetailDTO) As JsonResult
            Dim CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail = Nothing
            Dim Success As Boolean = True
            Dim Item As AdvantageFramework.ViewModels.ProjectManagement.Campaign.CampaignDetailDTO

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                CampaignDetail = New Database.Entities.CampaignDetail() With {.BillingBudgetAmount = Period.BillingBudgetAmount,
                               .CampaignDetailType = If(Not String.IsNullOrWhiteSpace(Period.CampaignDetailTypeCode), Period.CampaignDetailTypeCode, Nothing),
                               .CampaignID = Period.CampaignID,
                               .DepartmentTeamCode = If(Not String.IsNullOrWhiteSpace(Period.DepartmentTeamCode), Period.DepartmentTeamCode, Nothing),
                               .FunctionCode = If(Not String.IsNullOrWhiteSpace(Period.FunctionCode), Period.FunctionCode, Nothing),
                               .IncomeBudgetAmount = Period.IncomeBudgetAmount,
                               .PostPeriodCode = If(Not String.IsNullOrWhiteSpace(Period.PostPeriodCode), Period.PostPeriodCode, Nothing),
                               .RevisedDate = Period.RevisedDate,
                               .SalesClassCode = If(Not String.IsNullOrWhiteSpace(Period.SalesClassCode), Period.SalesClassCode, Nothing),
                               .UserCode = Period.UserCode
                    }

                Success = AdvantageFramework.Database.Procedures.CampaignDetail.Insert(DbContext, CampaignDetail)

                Dim arParams As New List(Of SqlParameter)
                arParams.Add(New SqlParameter("@CampaignCode", Period.CampaignID))
                arParams.Add(New SqlParameter("@ID", CampaignDetail.ID))

                Dim Command As String = "EXEC [dbo].[usp_wv_GetCampaignDetail] @CampaignCode, @ID"

                Item = DbContext.Database.SqlQuery(Of AdvantageFramework.ViewModels.ProjectManagement.Campaign.CampaignDetailDTO)(Command, arParams.ToArray).FirstOrDefault()

            End Using

            Dim rv As New With {
                                    .CampaignID = Item.CampaignID,
                                    .ID = Item.ID,
                                    .IncomeBudgetAmount = Item.IncomeBudgetAmount,
                                    .BillingBudgetAmount = Item.BillingBudgetAmount,
                                    .RevisedDate = Item.RevisedDate,
                                    .UserCode = Item.UserCode,
                                    .SalesClassCode = If(Not String.IsNullOrWhiteSpace(Item.SalesClassCode), Item.SalesClassCode, ""),
                                    .SalesClassName = If(Not String.IsNullOrWhiteSpace(Item.SalesClassCode), Item.SalesClassDesc & " (" & Item.SalesClassCode & ")", ""),
                                    .DepartmentTeamCode = If(Not String.IsNullOrWhiteSpace(Item.DepartmentTeamCode), Item.DepartmentTeamCode, ""),
                                    .DepartmentTeamName = If(Not String.IsNullOrWhiteSpace(Item.DepartmentTeamCode), Item.DepartmentTeamDesc & " (" & Item.DepartmentTeamCode & ")", ""),
                                    .FunctionCode = If(Not String.IsNullOrWhiteSpace(Item.FunctionCode), Item.FunctionCode, ""),
                                    .FunctionName = If(Not String.IsNullOrWhiteSpace(Item.FunctionCode), Item.FunctionDesc & " (" & Item.FunctionCode & ")", ""),
                                    .PostPeriodCode = If(Not String.IsNullOrWhiteSpace(Item.PostPeriodCode), Item.PostPeriodCode, ""),
                                    .PostPeriodName = If(Not String.IsNullOrWhiteSpace(Item.PostPeriodCode), Item.PostPeriodCode & " - " & Item.PostPeriodDesc, ""),
                                    .CampaignDetailTypeCode = If(Not String.IsNullOrWhiteSpace(Item.CampaignDetailTypeCode), Item.CampaignDetailTypeCode, ""),
                                    .CampaignDetailTypeName = If(Not String.IsNullOrWhiteSpace(Item.CampaignDetailTypeCode), Item.CampaignDetailTypeDesc, "")
                    }

            Return Json(rv, "application/json", JsonRequestBehavior.AllowGet)

        End Function
        <HttpPost>
        Function SaveBudgetAmounts(ByVal CampaignID As Integer, ByVal BillingBudgetAmount As Decimal, ByVal IncomeBudgetAmount As Decimal) As JsonResult
            Dim Campaign As AdvantageFramework.Database.Entities.Campaign
            Dim Success As Boolean = True
            Dim Message As String = ""

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, CampaignID)

                If Campaign IsNot Nothing Then
                    Campaign.BillingBudgetAmount = BillingBudgetAmount
                    Campaign.IncomeBudgetAmount = IncomeBudgetAmount

                    Success = AdvantageFramework.Database.Procedures.Campaign.Update(DbContext, Campaign, Message)
                End If
            End Using

            Return Json(New With {.Success = Success}, "application/json", JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Function DestroyPeriod(ByVal CampaignID As Integer, ByVal ID As Short) As JsonResult
            Dim CampaignDetail As AdvantageFramework.Database.Entities.CampaignDetail = Nothing
            Dim Success As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                CampaignDetail = AdvantageFramework.Database.Procedures.CampaignDetail.Load(DbContext, CampaignID, ID).FirstOrDefault

                Success = AdvantageFramework.Database.Procedures.CampaignDetail.Delete(DbContext, CampaignDetail)

            End Using


            Return Json(New With {.Success = Success}, "application/json", JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function BookMarkPage(ByVal Office As String,
                                     ByVal Client As String,
                                     ByVal Division As String,
                                     ByVal Product As String,
                                     ByVal Campaign As String,
                                     ByVal ShowClosed As Boolean,
                                     ByVal FromDate As Date,
                                     ByVal ToDate As Date
                                     ) As JsonResult
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            With qs
                .OfficeCode = Office
                .ClientCode = Client
                .DivisionCode = Division
                .ProductCode = Product
                .CampaignCode = Campaign
                .Add("closedarchived", ShowClosed)
                .Add("FromDate", FromDate)
                .Add("ToDate", ToDate)
                .Add("isbookmark", "1")
                .Build()
            End With

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_Campaign
                .UserCode = Session("UserCode")
                .Name = "Campaign Search"
                .PageURL = "modules/project-management/campaigns/campaigns" & qs.ToString()

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

