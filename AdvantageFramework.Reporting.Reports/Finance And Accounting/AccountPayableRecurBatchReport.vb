Namespace FinanceAndAccounting

    Public Class AccountPayableRecurBatchReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _BatchTotal As Decimal = 0
        Private _ForUser As String = Nothing
        Private _ReportRange As String = Nothing
        Private _AgencyName As String = Nothing
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

        Private Sub AccountPayableBatchDetailReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

            If _DetailPageBreak Then

                Me.GroupFooterNonClient.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand

            Else

                Me.GroupFooterNonClient.PageBreak = DevExpress.XtraReports.UI.PageBreak.None

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
        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint

            If DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).Office = "" Then

                LabelDetail_OfficeLabel.Visible = False

            End If

        End Sub
        Private Sub DetailReportNonClient_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportNonClient.BeforePrint

            Dim AccountPayableID As Integer = Nothing
            Dim Transaction As Integer = Nothing
            Dim AccountPayableGLDistributionList As Generic.List(Of AdvantageFramework.Database.Entities.AccountPayableGLDistribution) = Nothing

            Try

                AccountPayableID = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).AccountPayableID
                Transaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).GLTransaction

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableGLDistributionList = (From Entity In AdvantageFramework.Database.Procedures.AccountPayableGLDistribution.LoadByAccountPayableIDAndTransaction(DbContext, AccountPayableID, Transaction).Include("GeneralLedgerAccount")
                                                        Select Entity
                                                        Order By Entity.LineNumber).ToList

                    BindingSourceNonClient.DataSource = AccountPayableGLDistributionList

                End Using

            Catch ex As Exception
                DetailReportNonClient.DataSource = Nothing
            End Try

            If DetailReportNonClient.DataSource Is Nothing OrElse AccountPayableGLDistributionList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelReportFooter_BatchTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelReportFooter_BatchTotal.BeforePrint

            LabelReportFooter_BatchTotal.Text = String.Format("{0:c2}", _BatchTotal)

        End Sub
        Private Sub LabelGroupFooterNonClient_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterNonClient_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelDetail_ForeignInvoiceLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_ForeignInvoiceLabel.BeforePrint

            If String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode) = False Then

                LabelDetail_ForeignInvoiceLabel.Text = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode & " Total:"

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_ForeignTotalInvoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_ForeignTotalInvoice.BeforePrint

            If String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode) = False Then

                LabelDetail_ForeignTotalInvoice.Text = String.Format("{0:c2}", DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).ForeignCurrencyTotal.GetValueOrDefault(0))

            Else

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
