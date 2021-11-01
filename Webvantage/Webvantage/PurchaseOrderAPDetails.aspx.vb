Public Class PurchaseOrderAPDetails
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _PONumber As Integer = Nothing
    Private _LineNumber As Short = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadDetails()

        'objects
        Dim PurchaseOrderDetails As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrderDetail) = Nothing
        Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
        Dim PurchaseOrderEstimates As Generic.List(Of AdvantageFramework.Database.Classes.PurchaseOrderEstimate) = Nothing
        Dim PurchaseOrderDetailAPInfos As Generic.List(Of AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo) = Nothing
        Dim POQuantity As Integer = Nothing
        Dim POAmount As Decimal = Nothing
        Dim PORate As Decimal = Nothing
        Dim EstimateQuantity As Decimal = Nothing
        Dim EstimateAmount As Decimal = Nothing
        Dim EstimateRate As Decimal = Nothing
        Dim ActualVariance As Decimal = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, _PONumber, _LineNumber)

            If PurchaseOrderDetail IsNot Nothing Then

                Try

                    PurchaseOrderDetailAPInfos = DbContext.Database.SqlQuery(Of AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo)("EXEC [dbo].[advsp_po_load_ap_details] {0}, {1}", _PONumber, _LineNumber).ToList

                Catch ex As Exception
                    PurchaseOrderDetailAPInfos = New Generic.List(Of AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo)
                End Try


                If PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue Then

                    Try

                        PurchaseOrderDetails = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Load(DbContext).Include("PurchaseOrder")
                                                Where (Entity.PurchaseOrder.IsVoid Is Nothing OrElse Entity.PurchaseOrder.IsVoid = 0) AndAlso
                                                      Entity.JobNumber = PurchaseOrderDetail.JobNumber AndAlso
                                                      Entity.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber AndAlso
                                                      Entity.FunctionCode = PurchaseOrderDetail.FunctionCode
                                                Select Entity).ToList

                    Catch ex As Exception
                        PurchaseOrderDetails = Nothing
                    End Try

                    If PurchaseOrderDetails IsNot Nothing AndAlso PurchaseOrderDetails.Count > 0 Then

                        Try

                            POQuantity = (From Entity In PurchaseOrderDetails
                                          Select Entity.Quantity).Sum

                        Catch ex As Exception
                            POQuantity = 0
                        End Try

                        Try

                            POAmount = (From Entity In PurchaseOrderDetails
                                        Select Entity.ExtendedAmount).Sum

                        Catch ex As Exception
                            POAmount = Nothing
                        End Try

                        Try

                            PORate = POAmount / POQuantity

                        Catch ex As Exception
                            PORate = 0
                        End Try

                    End If

                    Try

                        PurchaseOrderEstimates = AdvantageFramework.Database.Procedures.PurchaseOrderEstimateComplex.Load(DbContext, 1, PurchaseOrderDetail.JobNumber, PurchaseOrderDetail.JobComponentNumber, PurchaseOrderDetail.FunctionCode).ToList

                    Catch ex As Exception
                        PurchaseOrderEstimates = Nothing
                    End Try

                    If PurchaseOrderEstimates IsNot Nothing AndAlso PurchaseOrderEstimates.Count > 0 Then

                        Try

                            EstimateQuantity = (From Entity In PurchaseOrderEstimates
                                                Select Entity.EstimateRevisionQuantity).Sum

                        Catch ex As Exception
                            EstimateQuantity = Nothing
                        End Try

                        Try

                            EstimateAmount = (From Entity In PurchaseOrderEstimates
                                              Select Entity.EstimateRevisionExtendedAmount).Sum

                        Catch ex As Exception
                            EstimateAmount = Nothing
                        End Try

                        Try

                            EstimateRate = EstimateAmount / EstimateQuantity

                        Catch ex As Exception
                            EstimateRate = Nothing
                        End Try

                    End If

                End If

            End If

            Label_POAmount.Text = POAmount.ToString("F2")
            Label_POQuantity.Text = POQuantity.ToString
            Label_PORate.Text = PORate.ToString("F3")

            Label_EstimateAmount.Text = EstimateAmount.ToString("F2")
            Label_EstimateQuantity.Text = EstimateQuantity.ToString("F2")
            Label_EstimateRate.Text = EstimateRate.ToString("F4")

            Try

                ActualVariance = POAmount - PurchaseOrderDetailAPInfos.Select(Function(p) p.Amount).Sum

            Catch ex As Exception
                ActualVariance = 0
            End Try

            Label_ActualVariance.Text = ActualVariance.ToString("F2")
            Label_EstimateVariance.Text = (POAmount - EstimateAmount).ToString("F2")

        End Using

    End Sub

#Region "  Form Event Handlers "

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        Try

            _PONumber = AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("po_number"))

        Catch ex As Exception
            _PONumber = 0
        End Try

        Try

            _LineNumber = Request.QueryString("line_number")

        Catch ex As Exception
            _LineNumber = 0
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Purchase Order AP Details"

        If Not Me.IsPostBack Then

            LoadDetails()

        End If

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadGrid_APDetails_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGrid_APDetails.ItemDataBound

        'objects
        Dim NonBillCheckBox As System.Web.UI.WebControls.CheckBox = Nothing
        Dim PurchaseOrderDetailAPInfo As AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo = Nothing

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Try

                PurchaseOrderDetailAPInfo = DirectCast(DirectCast(e.Item, Telerik.Web.UI.GridDataItem).DataItem, AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo)

            Catch ex As Exception
                PurchaseOrderDetailAPInfo = Nothing
            End Try

            If PurchaseOrderDetailAPInfo IsNot Nothing Then

                NonBillCheckBox = DirectCast(e.Item.FindControl("CheckBox_NonbillableFlag"), System.Web.UI.WebControls.CheckBox)

                NonBillCheckBox.Checked = CBool(PurchaseOrderDetailAPInfo.NonbillableFlag.GetValueOrDefault(0))

            End If

        End If

    End Sub
    Private Sub RadGrid_APDetails_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid_APDetails.NeedDataSource

        'objects
        Dim PurchaseOrderDetailAPInfos As Generic.List(Of AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                PurchaseOrderDetailAPInfos = DbContext.Database.SqlQuery(Of AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo)("EXEC [dbo].[advsp_po_load_ap_details] {0}, {1}", _PONumber, _LineNumber).ToList

            Catch ex As Exception
                PurchaseOrderDetailAPInfos = New Generic.List(Of AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo)
            End Try

            RadGrid_APDetails.DataSource = PurchaseOrderDetailAPInfos

        End Using

    End Sub

#End Region

#End Region


End Class
