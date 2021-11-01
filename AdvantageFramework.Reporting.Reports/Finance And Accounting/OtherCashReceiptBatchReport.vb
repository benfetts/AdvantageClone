Namespace FinanceAndAccounting

    Public Class OtherCashReceiptBatchReport

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
        Private _OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.Database.Entities.OtherCashReceiptDetail) = Nothing
        Private _DetailPageBreak As Boolean = False
        Private _GrandCheckTotal As Decimal = 0

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

        Private Sub OtherCashReceiptBatchReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'objects
            Dim GLTransactions As IEnumerable(Of Integer) = Nothing

            GLTransactions = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.CashReceipts.Classes.OtherCashReceiptBatchReport)).Select(Function(Entity) Entity.GLTransaction).ToList

            _Date = System.DateTime.Now.ToString("F")

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _OtherCashReceiptDetailList = (From Entity In AdvantageFramework.Database.Procedures.OtherCashReceiptDetail.Load(DbContext)
                                               Where GLTransactions.Contains(Entity.GLTransaction)
                                               Select Entity).ToList

            End Using

            If _DetailPageBreak Then

                Me.GroupFooterGLTransactionSeparatorLine.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand

            Else

                Me.GroupFooterGLTransactionSeparatorLine.PageBreak = DevExpress.XtraReports.UI.PageBreak.None

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
        Private Sub DetailReportOtherCashReceiptDetails_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportOtherCashReceiptDetails.BeforePrint

            'objects
            Dim GLTransaction As Integer = 0
            Dim OtherCashReceiptDetailList As Generic.List(Of AdvantageFramework.Database.Entities.OtherCashReceiptDetail) = Nothing

            Try

                GLTransaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.CashReceipts.Classes.OtherCashReceiptBatchReport).GLTransaction

                OtherCashReceiptDetailList = _OtherCashReceiptDetailList.Where(Function(Entity) Entity.GLTransaction = GLTransaction).ToList

                BindingSourceOtherCashReceiptDetails.DataSource = OtherCashReceiptDetailList

            Catch ex As Exception
                DetailReportOtherCashReceiptDetails.DataSource = Nothing
            End Try

            If DetailReportOtherCashReceiptDetails.DataSource Is Nothing OrElse OtherCashReceiptDetailList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelReportFooter_BatchTotal_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelReportFooter_BatchTotal.BeforePrint

            LabelReportFooter_BatchTotal.Text = FormatNumber(_GrandCheckTotal, 2)

        End Sub
        Private Sub LabelDetail_PaymentTypeLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_PaymentTypeLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.CashReceipts.Classes.OtherCashReceiptBatchReport.Properties.PaymentTypeDescription.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooter_CheckTotal_AfterPrint(sender As Object, e As EventArgs) Handles LabelGroupFooter_CheckTotal.AfterPrint

            _GrandCheckTotal += CDec(LabelGroupFooter_CheckTotal.Summary.GetResult)

        End Sub

#End Region

#End Region

    End Class

End Namespace
