Namespace Controller.Media

    Public Class MediaManagerGeneratePurchaseOrderController
        Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#Region " Public "

        Public Sub New(Session As AdvantageFramework.Security.Session)

            MyBase.New(Session)

        End Sub
        Public Function Load(ByRef MediaManagerPODetails As Generic.List(Of AdvantageFramework.DTO.Media.MediaManager.MediaManagerPODetail)) As AdvantageFramework.ViewModels.Media.MediaManagerGeneratePurchaseOrderViewModel

            'objects
            Dim MediaManagerGeneratePurchaseOrderViewModel As AdvantageFramework.ViewModels.Media.MediaManagerGeneratePurchaseOrderViewModel = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeLimit As Decimal? = Nothing
            Dim VendorCodes() As String = Nothing
            Dim Vendors As Generic.List(Of AdvantageFramework.Database.Entities.Vendor) = Nothing
            Dim VCCCardPOs As Generic.List(Of AdvantageFramework.Database.Entities.VCCCardPO) = Nothing
            Dim POTotal As Decimal = 0

            MediaManagerGeneratePurchaseOrderViewModel = New AdvantageFramework.ViewModels.Media.MediaManagerGeneratePurchaseOrderViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                MediaManagerGeneratePurchaseOrderViewModel.IsASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)
                MediaManagerGeneratePurchaseOrderViewModel.AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                For Each MediaManagerPODetail In MediaManagerPODetails

                    If Not IsNumeric(MediaManagerPODetail.DisplayPONumber) Then

                        MediaManagerPODetail.DisplayPONumber = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT dbo.advfn_purchase_order_display_number({0})", MediaManagerPODetail.PONumber)).SingleOrDefault

                    End If

                    If Not IsNumeric(MediaManagerPODetail.DisplayPONumber) Then

                        PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, MediaManagerPODetail.PONumber)

                        If PurchaseOrder IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(PurchaseOrder.PurchaseOrderApprovalRuleCode) AndAlso PurchaseOrder.ApprovalFlag.GetValueOrDefault(0) <> 1 Then

                            Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                            If Employee IsNot Nothing AndAlso Employee.PurchaseOrderLimit.HasValue Then

                                Try

                                    POTotal = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, MediaManagerPODetail.PONumber)
                                               Select Entity.ExtendedAmount).Sum

                                Catch ex As Exception
                                    POTotal = 0
                                End Try

                                If Employee.PurchaseOrderLimit < POTotal Then

                                    MediaManagerPODetail.NeedsApproval = True

                                    AdvantageFramework.PurchaseOrders.SubmitForApproval(Me.Session, PurchaseOrder, AlertSystem.PriorityLevels.Normal, Nothing)

                                End If

                            End If

                        End If

                    End If

                Next

                VendorCodes = MediaManagerPODetails.Select(Function(Entity) Entity.VendorCode).Distinct.ToArray

                Vendors = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Vendor).Where(Function(Entity) VendorCodes.Contains(Entity.Code) = True).ToList
                VCCCardPOs = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.VCCCardPO).ToList

                MediaManagerGeneratePurchaseOrderViewModel.MediaManagerGeneratePurchaseOrders = (From MediaManagerPODetail In MediaManagerPODetails
                                                                                                 From Vendor In Vendors.Where(Function(Entity) Entity.Code = MediaManagerPODetail.VendorCode).DefaultIfEmpty
                                                                                                 From VCCCardPO In VCCCardPOs.Where(Function(Entity) Entity.PONumber = MediaManagerPODetail.PONumber).DefaultIfEmpty
                                                                                                 Select New With {.MediaManagerPODetail = MediaManagerPODetail, .Vendor = Vendor, .VCCCardPO = VCCCardPO}).
                                            Select(Function(OrderGroup) New AdvantageFramework.DTO.Media.MediaManager.MediaManagerGeneratePurchaseOrder(DbContext, OrderGroup.MediaManagerPODetail, OrderGroup.Vendor, OrderGroup.VCCCardPO)).ToList

            End Using

            Load = MediaManagerGeneratePurchaseOrderViewModel

        End Function

#End Region

#End Region

    End Class

End Namespace
