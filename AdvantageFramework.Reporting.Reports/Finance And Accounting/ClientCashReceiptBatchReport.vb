Imports System.Drawing.Printing

Namespace FinanceAndAccounting

    Public Class ClientCashReceiptBatchReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _ForUser As String = Nothing
        Private _ReportRange As String = Nothing
        Private _AgencyName As String = Nothing
        Private _GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount) = Nothing
        Private _GeneralLedgerDetailList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail) = Nothing
        Private _ClientCashReceiptDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetail) = Nothing
        Private _ClientCashReceiptOnAccountList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount) = Nothing
        Private _ClientCashReceiptTransactionSubreportList As Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptTransactionSubreport) = Nothing
        Private _ClientCashReceiptDetailPaymentList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment) = Nothing
        Private _DetailPageBreak As Boolean = False

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ForUser As String
            Set(value As String)
                _ForUser = value
            End Set
        End Property
        Public WriteOnly Property ReportRange As String
            Set(value As String)
                _ReportRange = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public WriteOnly Property DetailPageBreak As Boolean
            Set(value As Boolean)
                _DetailPageBreak = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ClientCashReceiptBatchReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            Dim GLTransactions As IEnumerable(Of Integer) = Nothing

            GLTransactions = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport)).Select(Function(Entity) Entity.GLTransaction).ToList

            _Date = System.DateTime.Now.ToString("F")

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _GeneralLedgerAccountList = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadCore(DbContext).ToList

                _GeneralLedgerDetailList = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerDetail.Load(DbContext)
                                            Where GLTransactions.Contains(Entity.GLTransaction)
                                            Select Entity).ToList

                _ClientCashReceiptDetailList = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceiptDetail.Load(DbContext).Include("AccountReceivable")
                                                Where GLTransactions.Contains(Entity.GLTransaction)
                                                Select Entity).ToList

                _ClientCashReceiptOnAccountList = (From Entity In AdvantageFramework.Database.Procedures.ClientCashReceiptOnAccount.Load(DbContext)
                                                   Where GLTransactions.Contains(Entity.GLTransaction)
                                                   Select Entity).ToList

            End Using

            If _DetailPageBreak Then

                Me.GroupFooterGLTransaction.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand

            Else

                Me.GroupFooterGLTransaction.PageBreak = DevExpress.XtraReports.UI.PageBreak.None

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_ReportCriteria.Text = "For User: " & _ForUser & Space(5) & _ReportRange
            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub Detail_AfterPrint(sender As Object, e As EventArgs) Handles Detail.AfterPrint

            _ClientCashReceiptTransactionSubreportList = New Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptTransactionSubreport)
            _ClientCashReceiptDetailPaymentList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment)

        End Sub
        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            _ClientCashReceiptTransactionSubreportList = Nothing
            _ClientCashReceiptDetailPaymentList = Nothing

        End Sub
        Private Sub DetailReportClientCashReceiptDetails_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles DetailReportClientCashReceiptDetails.DataSourceRowChanged

            'objects
            Dim BindingSource As Windows.Forms.BindingSource = Nothing
            Dim ClientCashReceiptID As Integer = Nothing
            Dim ClientCashReceiptSequenceNumber As Short = Nothing
            Dim ItemID As Short = Nothing

            BindingSource = DirectCast(sender, DevExpress.XtraReports.UI.DetailReportBand).DataSource

            _ClientCashReceiptTransactionSubreportList.Add(New AdvantageFramework.CashReceipts.Classes.ClientCashReceiptTransactionSubreport(
                                                                DirectCast(BindingSource.Item(e.CurrentRow), AdvantageFramework.Database.Entities.ClientCashReceiptDetail),
                                                                _GeneralLedgerAccountList, _GeneralLedgerDetailList))

            ClientCashReceiptID = DirectCast(BindingSource.Item(e.CurrentRow), AdvantageFramework.Database.Entities.ClientCashReceiptDetail).ClientCashReceiptID
            ClientCashReceiptSequenceNumber = DirectCast(BindingSource.Item(e.CurrentRow), AdvantageFramework.Database.Entities.ClientCashReceiptDetail).ClientCashReceiptSequenceNumber
            ItemID = DirectCast(BindingSource.Item(e.CurrentRow), AdvantageFramework.Database.Entities.ClientCashReceiptDetail).ItemID

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _ClientCashReceiptDetailPaymentList.AddRange(AdvantageFramework.Database.Procedures.ClientCashReceiptDetailPayment.LoadByClientCashReceiptDetailIDandSeqandItemID(DbContext, ClientCashReceiptID, ClientCashReceiptSequenceNumber, ItemID).ToList)

            End Using

        End Sub
        Private Sub Subreport_TransactionSubreport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Subreport_TransactionSubreport.BeforePrint

            Subreport_TransactionSubreport.ReportSource.DataSource = _ClientCashReceiptTransactionSubreportList.Where(Function(Entity) Entity.HasData = True).ToList

            If Subreport_TransactionSubreport.ReportSource.DataSource Is Nothing OrElse
                    DirectCast(Subreport_TransactionSubreport.ReportSource.DataSource, Generic.List(Of AdvantageFramework.CashReceipts.Classes.ClientCashReceiptTransactionSubreport)).Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Subreport_PartialPaymentDetailSubreport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Subreport_PartialPaymentDetailSubreport.BeforePrint

            Subreport_PartialPaymentDetailSubreport.ReportSource.DataSource = _ClientCashReceiptDetailPaymentList

            If Subreport_PartialPaymentDetailSubreport.ReportSource.DataSource Is Nothing OrElse
                    DirectCast(Subreport_PartialPaymentDetailSubreport.ReportSource.DataSource, Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetailPayment)).Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportClientCashReceiptDetails_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportClientCashReceiptDetails.BeforePrint

            Dim GLTransaction As Integer = 0
            Dim ClientCashReceiptDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptDetail) = Nothing

            Try

                GLTransaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport).GLTransaction

                ClientCashReceiptDetailList = _ClientCashReceiptDetailList.Where(Function(Entity) Entity.GLTransaction = GLTransaction).ToList

                BindingSourceClientCashReceiptDetails.DataSource = ClientCashReceiptDetailList

            Catch ex As Exception
                DetailReportClientCashReceiptDetails.DataSource = Nothing
            End Try

            If DetailReportClientCashReceiptDetails.DataSource Is Nothing OrElse ClientCashReceiptDetailList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportClientCashReceiptOnAccounts_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportClientCashReceiptOnAccounts.BeforePrint

            Dim GLTransaction As Integer = 0
            Dim ClientCashReceiptOnAccountList As Generic.List(Of AdvantageFramework.Database.Entities.ClientCashReceiptOnAccount) = Nothing

            Try

                GLTransaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport).GLTransaction

                ClientCashReceiptOnAccountList = _ClientCashReceiptOnAccountList.Where(Function(Entity) Entity.GLTransaction = GLTransaction).ToList

                BindingSourceClientCashReceiptOnAccount.DataSource = ClientCashReceiptOnAccountList

            Catch ex As Exception
                DetailReportClientCashReceiptOnAccounts.DataSource = Nothing
            End Try

            If DetailReportClientCashReceiptOnAccounts.DataSource Is Nothing OrElse ClientCashReceiptOnAccountList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooterClientCashReceiptDetail_OnAccountTotal_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.BeforePrint

            If _ClientCashReceiptOnAccountList.Where(Function(Entity) Entity.GLTransaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport).GLTransaction).FirstOrDefault IsNot Nothing Then

                LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.Text = FormatNumber(_ClientCashReceiptOnAccountList.Where(Function(Entity) Entity.GLTransaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport).GLTransaction).Sum(Function(Entity) Entity.Amount), 2)

            Else

                LabelGroupFooterClientCashReceiptDetail_OnAccountTotal.Text = Nothing

            End If

        End Sub
        Private Sub LabelReportFooter_SumChecks_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelReportFooter_SumChecks.BeforePrint

            Dim SumPayments As Decimal = 0
            Dim SumOnAccount As Decimal = 0

            Try

                SumPayments = LabelReportFooter_SumPayments.Summary.GetResult

            Catch ex As Exception
                SumPayments = 0
            End Try

            Try

                SumOnAccount = LabelReportFooter_SumOnAccount.Summary.GetResult

            Catch ex As Exception
                SumOnAccount = 0
            End Try

            LabelReportFooter_SumChecks.Text = FormatNumber(SumPayments + SumOnAccount, 2)

        End Sub
        Private Sub LabelDetail_PaymentTypeLabel_BeforePrint(sender As Object, e As PrintEventArgs) Handles LabelDetail_PaymentTypeLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.CashReceipts.Classes.ClientCashReceiptBatchReport.Properties.PaymentTypeDescription.ToString)) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
