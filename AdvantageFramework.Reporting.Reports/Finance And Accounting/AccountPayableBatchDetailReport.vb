Namespace FinanceAndAccounting

    Public Class AccountPayableBatchDetailReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _InvoiceTotal As Decimal = 0
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

                Me.GroupFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand

            Else

                Me.GroupFooter.PageBreak = DevExpress.XtraReports.UI.PageBreak.None

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
        Private Sub DetailReportInternet_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportInternet.BeforePrint

            Dim AccountPayableID As Integer = Nothing
            Dim Transaction As Integer = Nothing
            Dim AccountPayableInternetDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail) = Nothing

            Try

                AccountPayableID = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).AccountPayableID
                Transaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).GLTransaction

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableInternetDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail)

                    AccountPayableInternetDistributionDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountPayableInternet.LoadByAccountPayableIDAndTransaction(DbContext, AccountPayableID, Transaction).ToList
                                                                          Select New AdvantageFramework.AccountPayable.Classes.AccountPayableInternetDistributionDetail(DbContext, Entity, False))

                    BindingSourceInternet.DataSource = AccountPayableInternetDistributionDetailList

                End Using

            Catch ex As Exception
                DetailReportInternet.DataSource = Nothing
            End Try

            If DetailReportInternet.DataSource Is Nothing OrElse AccountPayableInternetDistributionDetailList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportMagazine_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportMagazine.BeforePrint

            Dim AccountPayableID As Integer = Nothing
            Dim Transaction As Integer = Nothing
            Dim AccountPayableMagazineDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail) = Nothing

            Try

                AccountPayableID = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).AccountPayableID
                Transaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).GLTransaction

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableMagazineDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail)

                    AccountPayableMagazineDistributionDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountPayableMagazine.LoadByAccountPayableIDAndTransaction(DbContext, AccountPayableID, Transaction).ToList
                                                                          Select New AdvantageFramework.AccountPayable.Classes.AccountPayableMagazineDistributionDetail(DbContext, Entity, False))

                    BindingSourceMagazine.DataSource = AccountPayableMagazineDistributionDetailList

                End Using

            Catch ex As Exception
                DetailReportMagazine.DataSource = Nothing
            End Try

            If DetailReportMagazine.DataSource Is Nothing OrElse AccountPayableMagazineDistributionDetailList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportNewspaper_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportNewspaper.BeforePrint

            Dim AccountPayableID As Integer = Nothing
            Dim Transaction As Integer = Nothing
            Dim AccountPayableNewspaperDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail) = Nothing

            Try

                AccountPayableID = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).AccountPayableID
                Transaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).GLTransaction

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableNewspaperDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail)

                    AccountPayableNewspaperDistributionDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountPayableNewspaper.LoadByAccountPayableIDAndTransaction(DbContext, AccountPayableID, Transaction).ToList
                                                                           Select New AdvantageFramework.AccountPayable.Classes.AccountPayableNewspaperDistributionDetail(DbContext, Entity, False))

                    BindingSourceNewspaper.DataSource = AccountPayableNewspaperDistributionDetailList

                End Using

            Catch ex As Exception
                DetailReportNewspaper.DataSource = Nothing
            End Try

            If DetailReportNewspaper.DataSource Is Nothing OrElse AccountPayableNewspaperDistributionDetailList.Count = 0 Then

                e.Cancel = True

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
        Private Sub DetailReportOutOfHome_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportOutOfHome.BeforePrint

            Dim AccountPayableID As Integer = Nothing
            Dim Transaction As Integer = Nothing
            Dim AccountPayableOutOfHomeDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail) = Nothing

            Try

                AccountPayableID = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).AccountPayableID
                Transaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).GLTransaction

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableOutOfHomeDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail)

                    AccountPayableOutOfHomeDistributionDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountPayableOutOfHome.LoadByAccountPayableIDAndTransaction(DbContext, AccountPayableID, Transaction).ToList
                                                                           Select New AdvantageFramework.AccountPayable.Classes.AccountPayableOutOfHomeDistributionDetail(DbContext, Entity, False))

                    BindingSourceOutOfHome.DataSource = AccountPayableOutOfHomeDistributionDetailList

                End Using

            Catch ex As Exception
                DetailReportOutOfHome.DataSource = Nothing
            End Try

            If DetailReportOutOfHome.DataSource Is Nothing OrElse AccountPayableOutOfHomeDistributionDetailList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportProduction_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReportProduction.BeforePrint

            Dim AccountPayableID As Integer = Nothing
            Dim Transaction As Integer = Nothing
            Dim AccountPayableProductionDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail) = Nothing

            Try

                AccountPayableID = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).AccountPayableID
                Transaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).GLTransaction

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableProductionDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail)

                    AccountPayableProductionDistributionDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountPayableProduction.LoadByAccountPayableIDAndTransaction(DbContext, AccountPayableID, Transaction).ToList
                                                                            Select New AdvantageFramework.AccountPayable.Classes.AccountPayableProductionDistributionDetail(DbContext, Entity, _Session))

                    BindingSourceProduction.DataSource = AccountPayableProductionDistributionDetailList

                End Using

            Catch ex As Exception
                DetailReportProduction.DataSource = Nothing
            End Try

            If DetailReportProduction.DataSource Is Nothing OrElse AccountPayableProductionDistributionDetailList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportRadio_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportRadio.BeforePrint

            Dim AccountPayableID As Integer = Nothing
            Dim Transaction As Integer = Nothing
            Dim AccountPayableRadioDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail) = Nothing

            Try

                AccountPayableID = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).AccountPayableID
                Transaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).GLTransaction

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableRadioDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail)

                    AccountPayableRadioDistributionDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountPayableRadio.LoadByAccountPayableIDAndTransaction(DbContext, AccountPayableID, Transaction).ToList
                                                                       Select New AdvantageFramework.AccountPayable.Classes.AccountPayableRadioDistributionDetail(DbContext, Entity, False))

                    BindingSourceRadio.DataSource = AccountPayableRadioDistributionDetailList

                End Using

            Catch ex As Exception
                DetailReportRadio.DataSource = Nothing
            End Try

            If DetailReportRadio.DataSource Is Nothing OrElse AccountPayableRadioDistributionDetailList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DetailReportTV_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles DetailReportTV.BeforePrint

            Dim AccountPayableID As Integer = Nothing
            Dim Transaction As Integer = Nothing
            Dim AccountPayableTVDistributionDetailList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail) = Nothing

            Try

                AccountPayableID = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).AccountPayableID
                Transaction = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).GLTransaction

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountPayableTVDistributionDetailList = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail)

                    AccountPayableTVDistributionDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.AccountPayableTV.LoadByAccountPayableIDAndTransaction(DbContext, AccountPayableID, Transaction).ToList
                                                                    Select New AdvantageFramework.AccountPayable.Classes.AccountPayableTVDistributionDetail(DbContext, Entity, False))

                    BindingSourceTV.DataSource = AccountPayableTVDistributionDetailList

                End Using

            Catch ex As Exception
                DetailReportTV.DataSource = Nothing
            End Try

            If DetailReportTV.DataSource Is Nothing OrElse AccountPayableTVDistributionDetailList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelReportFooter_BatchTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelReportFooter_BatchTotal.BeforePrint

            LabelReportFooter_BatchTotal.Text = String.Format("{0:c2}", _BatchTotal)

        End Sub
        Private Sub LabelGroupFooter_InvoiceTotal_AfterPrint(sender As Object, e As System.EventArgs) Handles LabelGroupFooter_InvoiceTotal.AfterPrint

            _InvoiceTotal = 0

        End Sub
        Private Sub LabelGroupFooter_InvoiceTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooter_InvoiceTotal.BeforePrint

            LabelGroupFooter_InvoiceTotal.Text = String.Format("{0:c2}", _InvoiceTotal)

        End Sub
        Private Sub LabelGroupFooterInternet_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterInternet_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _InvoiceTotal += Convert.ToDecimal(e.Value)
                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelGroupFooterMagazine_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterMagazine_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _InvoiceTotal += Convert.ToDecimal(e.Value)
                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelGroupFooterNewspaper_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterNewspaper_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _InvoiceTotal += Convert.ToDecimal(e.Value)
                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelGroupFooterNonClient_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterNonClient_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _InvoiceTotal += Convert.ToDecimal(e.Value)
                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelGroupFooterProduction_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterProduction_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _InvoiceTotal += Convert.ToDecimal(e.Value)
                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelGroupFooterRadio_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterRadio_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _InvoiceTotal += Convert.ToDecimal(e.Value)
                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelGroupFooterTV_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterTV_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _InvoiceTotal += Convert.ToDecimal(e.Value)
                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelGroupFooterOutOfHome_DisbursedAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles LabelGroupFooterOutOfHome_DisbursedAmount.SummaryCalculated

            If e.Value IsNot Nothing Then

                _InvoiceTotal += Convert.ToDecimal(e.Value)
                _BatchTotal += Convert.ToDecimal(e.Value)

            End If

        End Sub
        Private Sub LabelGroupFooter_InvoiceForeignCurrencyTotalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.BeforePrint

            If String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode) = False Then

                LabelGroupFooter_InvoiceForeignCurrencyTotalLabel.Text = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode & " Total:"

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupFooter_InvoiceForeignCurrencyTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupFooter_InvoiceForeignCurrencyTotal.BeforePrint

            If String.IsNullOrWhiteSpace(DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).CurrencyCode) = False Then

                LabelGroupFooter_InvoiceForeignCurrencyTotal.Text = String.Format("{0:c2}", DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.AccountPayableBatchReport).ForeignCurrencyTotal.GetValueOrDefault(0))

            Else

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
