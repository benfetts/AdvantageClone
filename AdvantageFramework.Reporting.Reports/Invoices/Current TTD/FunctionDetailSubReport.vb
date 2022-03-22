Namespace Invoices.CurrentTTD

    Public Class FunctionDetailSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _DetailPrintedCount As Integer = 0
        Private _IsDraft As Boolean = False
        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _InvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail) = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property IsDraft As Boolean
            Set(value As Boolean)
                _IsDraft = value
            End Set
        End Property
        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice
            Set(value As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)
                _AccountReceivableInvoice = value
            End Set
        End Property
        Public WriteOnly Property InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)

                _InvoicePrintingSetting = value

                If _InvoicePrintingSetting IsNot Nothing Then

                    SetParameterValues()

                End If

            End Set
        End Property
        Public WriteOnly Property InvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail)
            Set(value As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CurrentTTDInvoiceDetail))
                _InvoiceDetails = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub SetParameterValues()

            ShowRate.Value = AdvantageFramework.InvoicePrinting.ShowRate(_InvoicePrintingSetting, FunctionType.Value)

        End Sub
        Private Sub XrLabelRate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelRate.BeforePrint

            'objects
            Dim CanShowFunctionRate As Boolean = True
            Dim FunctionType As String = ""

            Try

                FunctionType = Me.GetCurrentColumnValue("FunctionType")

            Catch ex As Exception
                FunctionType = ""
            End Try

            CanShowFunctionRate = AdvantageFramework.InvoicePrinting.ShowRate(_InvoicePrintingSetting, FunctionType)

            e.Cancel = Not CanShowFunctionRate

        End Sub
        Private Sub RemoveGroupHeaderGroupField(ByVal FieldName As String)

            'objects
            Dim GroupField As DevExpress.XtraReports.UI.GroupField = Nothing

            Try

                GroupField = GroupHeader.GroupFields(FieldName)

            Catch ex As Exception
                GroupField = Nothing
            End Try

            If GroupField IsNot Nothing Then

                Try

                    GroupHeader.GroupFields.Remove(GroupField)

                Catch ex As Exception
                    GroupField = Nothing
                End Try

            End If

        End Sub
        Private Sub AddGroupHeaderGroupField(FieldName As String)

            'objects
            Dim GroupField As DevExpress.XtraReports.UI.GroupField = Nothing

            Try

                GroupField = GroupHeader.GroupFields(FieldName)

            Catch ex As Exception
                GroupField = Nothing
            End Try

            If GroupField Is Nothing Then

                Try

                    GroupHeader.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField(FieldName, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))

                Catch ex As Exception
                    GroupField = Nothing
                End Try

            End If

        End Sub
        Private Sub FunctionDetailSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            GroupHeader.GroupFields.Clear()

            AddGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Item.ToString)
            AddGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.ItemDate.ToString)
            AddGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Rate.ToString)
            AddGroupHeaderGroupField("HoursAndQuantity")
            AddGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Comment.ToString)

            If _InvoicePrintingSetting IsNot Nothing Then

                If FunctionType.Value = "E" Then

                    If _InvoicePrintingSetting.ShowEmployeeTimeDescription = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Item.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowEmployeeTimeDate = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.ItemDate.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowEmployeeTimeRate = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Rate.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowEmployeeTimeFunctionComment = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Comment.ToString)

                    End If

                ElseIf FunctionType.Value = "I" Then

                    If _InvoicePrintingSetting.ShowIncomeOnlyDescription = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Item.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowIncomeOnlyDate = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.ItemDate.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowIncomeOnlyRate = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Rate.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowIncomeOnlyFunctionComment = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Comment.ToString)

                    End If

                ElseIf FunctionType.Value = "V" Then

                    If _InvoicePrintingSetting.ShowAPDescription = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Item.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowAPDate = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.ItemDate.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowAPRate = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Rate.ToString)

                    End If

                    If _InvoicePrintingSetting.ShowAccountsPayableFunctionComment = False Then

                        RemoveGroupHeaderGroupField(AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail.Properties.Comment.ToString)

                    End If

                End If

                'If _InvoicePrintingSetting.ShowEmployeeHours = False AndAlso _InvoicePrintingSetting.ShowQuantity = False Then

                RemoveGroupHeaderGroupField("HoursAndQuantity")

                'End If

            End If

        End Sub
        Private Sub FunctionDetailSubReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            Dim AllInvoiceFunctionDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail) = Nothing
            Dim InvoiceFunctionDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail) = Nothing
            Dim PrintFunctionType As Nullable(Of Short) = 1
            Dim ApplyExchangeRate As Nullable(Of Short) = 1
            Dim ExchangeRateAmount As Nullable(Of Decimal) = 1
            Dim TotalsShowTaxSeparately As Nullable(Of Boolean) = False
            Dim TotalsShowCommissionSeparately As Nullable(Of Boolean) = False
            Dim ShowZeroFunctionAmounts As Nullable(Of Boolean) = False
            Dim SequenceNumber As Short = 0

            If _InvoicePrintingSetting IsNot Nothing Then

                PrintFunctionType = _InvoicePrintingSetting.PrintFunctionType
                ApplyExchangeRate = _InvoicePrintingSetting.ApplyExchangeRate
                ExchangeRateAmount = _InvoicePrintingSetting.ExchangeRateAmount
                TotalsShowTaxSeparately = _InvoicePrintingSetting.TotalsShowTaxSeparately
                TotalsShowCommissionSeparately = _InvoicePrintingSetting.TotalsShowCommissionSeparately
                ShowZeroFunctionAmounts = _InvoicePrintingSetting.ShowZeroFunctionAmounts

            End If

            _DetailPrintedCount = 0

            AllInvoiceFunctionDetails = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                    If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

                        ApplyExchangeRate = 2
                        ExchangeRateAmount = _AccountReceivableInvoice.CurrencyRate.GetValueOrDefault(1)

                    End If

                End If

                For Each InvoiceDetail In _InvoiceDetails

                    Try

                        SequenceNumber = InvoiceDetail.InvoiceSequenceNumber

                    Catch ex As Exception
                        SequenceNumber = 0
                    End Try

                    If SequenceNumber <> 0 Then

                        SequenceNumber = 99

                    End If

                    InvoiceFunctionDetails = AdvantageFramework.InvoicePrinting.LoadFunctionDetails(DbContext, InvoiceDetail.ClientCode, InvoiceDetail.DivisionCode, InvoiceDetail.ProductCode,
                                                                                                    InvoiceDetail.InvoiceNumber, SequenceNumber, InvoiceDetail.InvoiceType, InvoiceDetail.JobNumber,
                                                                                                    InvoiceDetail.ComponentNumber, InvoiceDetail.OriginalFunctionCode, PrintFunctionType,
                                                                                                    ApplyExchangeRate, ExchangeRateAmount, TotalsShowTaxSeparately, TotalsShowCommissionSeparately,
                                                                                                    ShowZeroFunctionAmounts, _IsDraft, _AccountReceivableInvoice.Batch).ToList

                    InvoiceFunctionDetails.ForEach(Sub(IFD)

                                                       IFD.FunctionType = InvoiceDetail.FunctionType

                                                   End Sub)

                    AllInvoiceFunctionDetails.AddRange(InvoiceFunctionDetails)

                Next

            End Using

            Me.DataSource = AllInvoiceFunctionDetails

        End Sub
        Private Sub XrLabelTTDTotalAmount_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelTTDTotalAmount.BeforePrint

            XrLabelTTDTotalAmount.Text = FormatNumber(Me.TTDTotalAmount.Value, 2)

        End Sub
        Private Sub XrLabelTotalAmount_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles XrLabelTotalAmount.SummaryCalculated

            If String.IsNullOrWhiteSpace(e.Text) Then

                e.Text = "0.00"

            End If

        End Sub
        Private Sub XrLabelTotalHoursAndQuantity_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles XrLabelTotalHoursAndQuantity.SummaryCalculated

            If String.IsNullOrWhiteSpace(e.Text) Then

                e.Text = "0.00"

            End If

        End Sub
        Private Sub XrLabelItem_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelItem.BeforePrint

            e.Cancel = Not AdvantageFramework.InvoicePrinting.ShowDescription(_InvoicePrintingSetting, FunctionType.Value)

            'If e.Cancel = False Then

            '    _DetailPrintedCount += 1

            'End If

        End Sub
        Private Sub GroupHeader_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader.BeforePrint

            _DetailPrintedCount += 1

        End Sub
        Private Sub XrLabelItemDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelItemDate.BeforePrint

            e.Cancel = Not AdvantageFramework.InvoicePrinting.ShowDate(_InvoicePrintingSetting, FunctionType.Value)

        End Sub
        Private Sub GroupFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooter.BeforePrint

            If (Me.RowCount - 1 <> Me.CurrentRowIndex) OrElse (_DetailPrintedCount < 2) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub XrLabelComment_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelComment.BeforePrint

            'objects
            Dim InvoiceFunctionDetail As AdvantageFramework.InvoicePrinting.Classes.InvoiceFunctionDetail = Nothing

            If _InvoicePrintingSetting IsNot Nothing Then

                InvoiceFunctionDetail = Me.GetCurrentRow

                If InvoiceFunctionDetail IsNot Nothing Then

                    If InvoiceFunctionDetail.Type = "E" Then

                        If _InvoicePrintingSetting.ShowEmployeeTimeFunctionComment = True AndAlso String.IsNullOrWhiteSpace(InvoiceFunctionDetail.Comment) = False Then

                            XrLabelComment.Text = InvoiceFunctionDetail.Comment

                        Else

                            XrLabelComment.Text = ""

                        End If

                    ElseIf InvoiceFunctionDetail.Type = "IO" Then

                        If _InvoicePrintingSetting.ShowIncomeOnlyFunctionComment = True AndAlso String.IsNullOrWhiteSpace(InvoiceFunctionDetail.Comment) = False Then

                            XrLabelComment.Text = InvoiceFunctionDetail.Comment

                        Else

                            XrLabelComment.Text = ""

                        End If

                    ElseIf InvoiceFunctionDetail.Type = "AP" Then

                        If _InvoicePrintingSetting.ShowAccountsPayableFunctionComment = True AndAlso String.IsNullOrWhiteSpace(InvoiceFunctionDetail.Comment) = False Then

                            XrLabelComment.Text = InvoiceFunctionDetail.Comment

                        Else

                            XrLabelComment.Text = ""

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace
