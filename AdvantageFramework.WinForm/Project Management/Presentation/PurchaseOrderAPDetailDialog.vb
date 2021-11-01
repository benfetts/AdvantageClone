Namespace ProjectManagement.Presentation

    Public Class PurchaseOrderAPDetailDialog

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

        Private Sub New(ByVal PONumber As Integer, ByVal LineNumber As Short)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            _PONumber = PONumber
            _LineNumber = LineNumber

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal PONumber As Integer, ByVal LineNumber As Short) As Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderAPDetailDialog As AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderAPDetailDialog = Nothing

            PurchaseOrderAPDetailDialog = New AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderAPDetailDialog(PONumber, LineNumber)

            ShowFormDialog = PurchaseOrderAPDetailDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderAPDetailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, _PONumber, _LineNumber)

                If PurchaseOrderDetail IsNot Nothing Then

                    Try

                        PurchaseOrderDetailAPInfos = DbContext.Database.SqlQuery(Of AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo)("EXEC [dbo].[advsp_po_load_ap_details] {0}, {1}", _PONumber, _LineNumber).ToList

                    Catch ex As Exception
                        PurchaseOrderDetailAPInfos = New Generic.List(Of AdvantageFramework.PurchaseOrders.Classes.PurchaseOrderDetailAPInfo)
                    End Try

                    DataGridViewForm_APDetails.DataSource = PurchaseOrderDetailAPInfos
                    DataGridViewForm_APDetails.CurrentView.BestFitColumns()

                    If PurchaseOrderDetail.JobNumber.HasValue AndAlso PurchaseOrderDetail.JobComponentNumber.HasValue Then

                        Try

                            PurchaseOrderDetails = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Load(DbContext).Include("PurchaseOrder")
                                                    Where (Entity.PurchaseOrder.IsVoid Is Nothing OrElse Entity.PurchaseOrder.IsVoid = 0) AndAlso
                                                          Entity.JobNumber = PurchaseOrderDetail.JobNumber AndAlso
                                                          Entity.JobComponentNumber = PurchaseOrderDetail.JobComponentNumber AndAlso
                                                          Entity.FunctionCode = PurchaseOrderDetail.FunctionCode AndAlso
                                                          Entity.PurchaseOrderNumber = _PONumber
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

                LabelForm_Amount.Text = POAmount.ToString("F2")
                LabelForm_Quantity.Text = POQuantity.ToString
                LabelForm_Rate.Text = PORate.ToString("F3")

                LabelForm_EstAmount.Text = EstimateAmount.ToString("F2")
                LabelForm_EstQuantity.Text = EstimateQuantity.ToString("F2")
                LabelForm_EstRate.Text = EstimateRate.ToString("F4")

                Try

                    ActualVariance = POAmount - PurchaseOrderDetailAPInfos.Select(Function(p) p.Amount).Sum

                Catch ex As Exception
                    ActualVariance = 0
                End Try

                LabelForm_ActVariance.Text = ActualVariance.ToString("F2")
                LabelForm_EstVariance.Text = Math.Abs(POAmount - EstimateAmount).ToString("F2")

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace