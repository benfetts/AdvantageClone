Namespace FinanceAndAccounting

    Public Class ClientInvoiceReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _ClientCode As String = Nothing
        Private _DateFrom As Date = Nothing
        Private _DateTo As Date = Nothing
        Private _AgencyName As String = Nothing
        Private _ClientCodeName As String = Nothing

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
        Public WriteOnly Property ClientCode As String
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public WriteOnly Property DateFrom As Date
            Set(value As Date)
                _DateFrom = value
            End Set
        End Property
        Public WriteOnly Property DateTo As Date
            Set(value As Date)
                _DateTo = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub ClientInvoiceReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            _Date = System.DateTime.Now.ToString("F")

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

            End Using

            If Client IsNot Nothing Then

                _ClientCodeName = Client.ToString

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Client.Text = _ClientCodeName
            LabelPageHeader_DateFrom.Text = _DateFrom
            LabelPageHeader_DateTo.Text = _DateTo
            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub DetailReportPayments_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportPayments.BeforePrint

            'objects
            Dim InvoiceNumber As Integer = Nothing
            Dim InvoiceSequenceNumber As Short = Nothing
            Dim ClientInvoicePaymentList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoicePayment) = Nothing

            Try

                InvoiceNumber = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountReceivable.Classes.ClientInvoice).InvoiceNumber
                InvoiceSequenceNumber = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountReceivable.Classes.ClientInvoice).SequenceNumber

                Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientInvoicePaymentList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoicePayment)(String.Format("exec advsp_ar_invoice_select_payments {0},{1}", InvoiceNumber, InvoiceSequenceNumber)).ToList

                    BindingSourcePayments.DataSource = ClientInvoicePaymentList

                End Using

            Catch ex As Exception
                BindingSourcePayments.DataSource = Nothing
            End Try

            If DetailReportPayments.DataSource Is Nothing OrElse ClientInvoicePaymentList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportPayments_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles DetailReportPayments.DataSourceRowChanged

            'objects
            Dim ClientCashReceiptID As Integer = 0
            Dim ClientInvoicePaymentCheckDetailList As Generic.List(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoicePaymentCheckDetail) = Nothing

            ClientCashReceiptID = DirectCast(DetailReportPayments.GetCurrentRow, AdvantageFramework.AccountReceivable.Classes.ClientInvoicePayment).ClientCashReceiptID

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ClientInvoicePaymentCheckDetailList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountReceivable.Classes.ClientInvoicePaymentCheckDetail)(String.Format("exec advsp_ar_invoice_select_check_detail {0}", ClientCashReceiptID)).ToList

            End Using

            SubreportDetail_CheckDetail.ReportSource.DataSource = ClientInvoicePaymentCheckDetailList

        End Sub

#End Region

#End Region

    End Class

End Namespace
