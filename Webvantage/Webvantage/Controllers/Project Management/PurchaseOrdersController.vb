Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Web.Mvc
Imports AdvantageFramework.ViewModels.ProjectManagement.PurchaseOrder

Namespace Controllers.ProjectManagement

    Public Class PurchaseOrdersController
        Inherits MVCControllerBase

#Region " Constants "

        Public Const BaseRoute As String = "ProjectManagement/PurchaseOrders/"

#End Region

#Region " Enum "



#End Region

#Region " Variables "

        ' Private _Controller As Object = Nothing 'AdvantageFramework.Controller.ProjectManagement.PurchaseOrdersController = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Protected Overrides Sub Initialize(requestContext As System.Web.Routing.RequestContext)

            MyBase.Initialize(requestContext)

            ' _Controller = New Object ' New AdvantageFramework.Controller.ProjectManagement.PurchaseOrdersController(Me.SecuritySession)

        End Sub

#Region " API "

        <System.Web.Mvc.HttpGet>
        Public Function Search(ByVal PONumber As String,
                                ByVal Description As String,
                                ByVal JobCode As Integer,
                                ByVal ComponentCode As Short,
                                ByVal ClientCode As String,
                                ByVal DivisionCode As String,
                                ByVal ProductCode As String,
                                ByVal VendorCode As String,
                                ByVal FromDate As Date?,
                                ByVal ToDate As Date?,
                                ByVal DueDate As Date?,
                                ByVal EmployeeCode As String,
                                ByVal ApproversCode As String,
                                ByVal Status As Short,
                                ByVal OmitClosed As Boolean,
                                ByVal OmitVoided As Boolean,
                                ByVal Printed As Boolean) As System.Web.Mvc.JsonResult

            Dim arParams As New List(Of SqlParameter)
            arParams.Add(New SqlParameter("@UserID", Me.SecuritySession.UserCode))
            arParams.Add(New SqlParameter("@PONumber", PONumber))
            arParams.Add(New SqlParameter("@Description", Description))
            arParams.Add(New SqlParameter("@JobCode", JobCode))
            arParams.Add(New SqlParameter("@ComponentCode", ComponentCode))
            arParams.Add(New SqlParameter("@ClientCode", ClientCode))
            arParams.Add(New SqlParameter("@DivisionCode", DivisionCode))
            arParams.Add(New SqlParameter("@ProductCode", ProductCode))
            arParams.Add(New SqlParameter("@VendorCode", VendorCode))
            Dim FromDateParameter As SqlParameter = New SqlParameter("@FromDate", SqlDbType.Date)
            FromDateParameter.IsNullable = True
            FromDateParameter.Value = If(FromDate Is Nothing, DBNull.Value, FromDate)
            arParams.Add(FromDateParameter)

            Dim ToDateParameter As SqlParameter = New SqlParameter("@ToDate", SqlDbType.Date)
            ToDateParameter.IsNullable = True
            ToDateParameter.Value = If(ToDate Is Nothing, DBNull.Value, ToDate)
            arParams.Add(ToDateParameter)

            Dim DueDateParameter As SqlParameter = New SqlParameter("@DueDate", SqlDbType.Date)
            DueDateParameter.IsNullable = True
            DueDateParameter.Value = If(DueDate Is Nothing, DBNull.Value, DueDate)
            arParams.Add(DueDateParameter)

            arParams.Add(New SqlParameter("@EmployeeCode", EmployeeCode))
            arParams.Add(New SqlParameter("@ApproverCode", ApproversCode))
            arParams.Add(New SqlParameter("@Status", Status))
            arParams.Add(New SqlParameter("@OmitVoided", If(OmitVoided, 1, 0)))
            arParams.Add(New SqlParameter("@OmitClosed", If(OmitClosed, 1, 0)))
            arParams.Add(New SqlParameter("@Printed", If(Printed, 1, 0)))

            'objects
            Dim PurchaseOrders As IEnumerable = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.SecuritySession.ConnectionString, Me.SecuritySession.UserCode)

                '"EXEC usp_wv_GetPurchaseOrders @UserID,@PONumber,@Description,@JobCode,@ComponentCode,@ClientCode,@DivisionCode,@ProductCode,@VendorCode,@FromDate,@ToDate,@DueDate,@EmployeeCode,@ApproverCode,3,@OmitVoided,@OmitClosed,@Printed", arParams.ToArray)
                PurchaseOrders = (From PO In DbContext.Database.SqlQuery(Of PurchaseOrderSearchDTO)("exec usp_wv_GetPurchaseOrders @UserID,@PONumber,@Description,@JobCode,@ComponentCode,@ClientCode,@DivisionCode,@ProductCode,@VendorCode,@FromDate,@ToDate,@DueDate,@EmployeeCode,@ApproverCode,@Status,@OmitVoided,@OmitClosed,@Printed", arParams.ToArray)
                                  Select PO).ToList

            End Using

            Return MaxJson(PurchaseOrders, System.Web.Mvc.JsonRequestBehavior.AllowGet)

        End Function

        <HttpGet>
        Public Function CanAdd() As JsonResult

            Dim UserPermission As AdvantageFramework.Security.Database.Views.UserPermission
            Dim HasAccess As Boolean = False

            Dim _Session = New AdvantageFramework.Security.Session(AdvantageFramework.Security.Application.Webvantage, Session("ConnString"), Session("UserCode"), CInt(Session("AdvantageUserLicenseInUseID")), Session("ConnString"))


            Using DbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))

                UserPermission = AdvantageFramework.Security.Database.Procedures.UserPermissionView.LoadByApplicationAndModuleAndUser(DbContext,
                                                                                                                     AdvantageFramework.Security.Application.Webvantage,
                                                                                                                     AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders.ToString("F"),
                                                                                                                     _Session.User.ID)

                HasAccess = UserPermission.CanAdd

            End Using

            Return Json(HasAccess, JsonRequestBehavior.AllowGet)

        End Function

        <HttpPost>
        Public Function BookMarkPage(ByVal PurchaseOrderNumber As Integer?,
                                     ByVal PODescription As String,
                                     ByVal Client As String,
                                     ByVal Division As String,
                                     ByVal Product As String,
                                     ByVal JobNumber As Integer?,
                                     ByVal ComponentNumber As Integer?,
                                     ByVal Vendor As String,
                                     ByVal FromDate As Date?,
                                     ByVal ToDate As Date?,
                                     ByVal DueDate As Date?,
                                     ByVal IssuedBy As String,
                                     ByVal Approver As String,
                                     ByVal POStatus As String
                                     ) As JsonResult
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
            Dim qs As New AdvantageFramework.Web.QueryString()

            With qs
                If PurchaseOrderNumber IsNot Nothing Then
                    .PurchaseOrderNumber = PurchaseOrderNumber
                End If
                .ClientCode = Client
                .DivisionCode = Division
                .ProductCode = Product
                .VendorCode = Vendor
                If JobNumber IsNot Nothing Then
                    .JobNumber = JobNumber
                End If
                If ComponentNumber IsNot Nothing Then
                    .JobComponentNumber = ComponentNumber
                End If
                .Add("podescription", PODescription)

                If FromDate IsNot Nothing Then
                    .Add("fromdate", FromDate.Value.ToShortDateString)
                End If
                If ToDate IsNot Nothing Then
                    .Add("todate", ToDate.Value.ToShortDateString)
                End If
                If DueDate IsNot Nothing Then
                    .Add("duedate", DueDate.Value.ToShortDateString)
                End If
                .Add("issued", IssuedBy)
                .Add("approver", Approver)
                .Add("postatus", POStatus)
                .Add("isbookmark", "1")
                .Build()
            End With

            With b

                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_PurchaseOrders
                .UserCode = Session("UserCode")
                .Name = "Purchase Order Search"
                .PageURL = "modules/project-management/purchase-orders/purchase-orders" & qs.ToString()

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

