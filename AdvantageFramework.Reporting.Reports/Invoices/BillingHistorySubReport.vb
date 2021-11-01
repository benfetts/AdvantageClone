Namespace Invoices

    Public Class BillingHistorySubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _IsDraft As Boolean = False

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property IsDraft As Boolean
            Set(value As Boolean)
                _IsDraft = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Sub BillingHistorySubReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            If Me.OrderNumber.Value > 0 Then

                XrLabelBillingHistoryHeader.Text = "Billing History for Order " & Format(OrderNumber.Value, "00000#") & ":"

            End If

        End Sub
        Private Sub BillingHistorySubReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim AllInvoiceBillingHistorys As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBillingHistory) = Nothing
            Dim InvoiceBillingHistorys As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBillingHistory) = Nothing
            Dim JobNumbers As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If Me.JobNumber.Value > 0 Then

                    AllInvoiceBillingHistorys = AdvantageFramework.InvoicePrinting.LoadStandardInvoiceBillingHistory(DbContext, Me.InvoiceNumber.Value, Me.JobNumber.Value, Me.ComponentNumber.Value, _IsDraft).ToList

                ElseIf String.IsNullOrWhiteSpace(Me.JobNumbers.Value) = False AndAlso Me.JobNumbers.Value <> "0" Then

                    JobNumbers = Split(Me.JobNumbers.Value, ",").ToList

                    AllInvoiceBillingHistorys = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBillingHistory)

                    For Each JobNum In JobNumbers

                        If String.IsNullOrWhiteSpace(JobNum) = False AndAlso IsNumeric(JobNum) Then

                            InvoiceBillingHistorys = AdvantageFramework.InvoicePrinting.LoadStandardInvoiceBillingHistory(DbContext, Me.InvoiceNumber.Value, JobNum, Me.ComponentNumber.Value, _IsDraft).ToList

                            AllInvoiceBillingHistorys.AddRange(InvoiceBillingHistorys)

                        End If

                    Next

                ElseIf Me.OrderNumber.Value > 0 Then

                    AllInvoiceBillingHistorys = AdvantageFramework.InvoicePrinting.LoadMediaInvoiceBillingHistory(DbContext, Me.InvoiceNumber.Value, Me.OrderNumber.Value, _IsDraft).ToList

                End If

                Me.DataSource = AllInvoiceBillingHistorys

                If AllInvoiceBillingHistorys IsNot Nothing AndAlso AllInvoiceBillingHistorys.Count = 0 Then

                    ReportHeader.Visible = False
                    ReportFooter.Visible = False
                    Detail.Visible = False

                Else

                    ReportHeader.Visible = True
                    ReportFooter.Visible = True
                    Detail.Visible = True

                End If

            End Using

        End Sub

#End Region

    End Class

End Namespace
