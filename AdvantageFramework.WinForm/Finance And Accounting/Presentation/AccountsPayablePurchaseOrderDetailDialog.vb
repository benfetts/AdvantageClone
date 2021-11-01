Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayablePurchaseOrderDetailDialog

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
        Private Sub LoadPurchaseOrderDetail()

            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim TotalPOAmount As Decimal = 0
            Dim AccountPayablePurchaseOrderDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayablePurchaseOrderDetail) = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PONumber)

                If PurchaseOrder IsNot Nothing Then

                    CheckBoxForm_WorkComplete.Checked = CBool(PurchaseOrder.IsWorkComplete.GetValueOrDefault(0))

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                    If Employee IsNot Nothing Then

                        LabelForm_IssuedBy.Text = Employee.ToString

                    End If

                    LabelForm_IssuedDate.Text = PurchaseOrder.Date
                    LabelForm_Revision.Text = PurchaseOrder.Revision

                    Try

                        TotalPOAmount = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumber(DbContext, _PONumber).Sum(Function(POD) POD.ExtendedAmount)

                    Catch ex As Exception
                        TotalPOAmount = 0
                    End Try

                    NumericInputForm_TotalPOAmount.SetFormat("n2")
                    NumericInputForm_TotalPOAmount.EditValue = TotalPOAmount

                End If

                PurchaseOrderDetail = AdvantageFramework.Database.Procedures.PurchaseOrderDetail.LoadByPONumberAndLineNumber(DbContext, _PONumber, _LineNumber)

                AccountPayablePurchaseOrderDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayablePurchaseOrderDetail)

                AccountPayablePurchaseOrderDetailList.Add(New AdvantageFramework.AccountPayable.Classes.AccountPayablePurchaseOrderDetail(DbContext, PurchaseOrderDetail))

                DataGridViewForm_PurchaseOrderDetails.DataSource = AccountPayablePurchaseOrderDetailList

                DataGridViewForm_PurchaseOrderDetails.CurrentView.BestFitColumns()

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal PONumber As Integer, POLineNumber As Short) As System.Windows.Forms.DialogResult

            'objects
            Dim AccountsPayablePurchaseOrderDetailDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayablePurchaseOrderDetailDialog = Nothing

            AccountsPayablePurchaseOrderDetailDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayablePurchaseOrderDetailDialog(PONumber, POLineNumber)

            ShowFormDialog = AccountsPayablePurchaseOrderDetailDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayablePurchaseOrderDetailDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            LoadPurchaseOrderDetail()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace