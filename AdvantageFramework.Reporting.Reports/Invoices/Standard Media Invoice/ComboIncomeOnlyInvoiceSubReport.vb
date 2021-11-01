Namespace Invoices.StandardMediaInvoice

    Public Class ComboIncomeOnlyInvoiceSubReport
        Implements IComboInvoice

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum ValueType
            Text
            [Date]
            [Integer]
            [Decimal]
            [OrderLineNumber]
        End Enum

        Private Enum TotalType
            Order
            Market
            Invoice
        End Enum

#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Private _InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
        Private _IsDraft As Boolean = False
        Private _MediaInvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoicePrintingSetting = Nothing
        Private _MediaType As String = ""
        Private _GroupedByOrderMonth As Boolean = False
		Private _ApplyExchangeRate As Short = 1
		Private _ExchangeRateAmount As Decimal = 1.0

#End Region

#Region " Properties "

		Public WriteOnly Property Session As AdvantageFramework.Security.Session Implements IComboInvoice.Session
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting Implements IComboInvoice.InvoicePrintingSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)
                _InvoicePrintingSetting = value
            End Set
        End Property
        Public WriteOnly Property InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting Implements IComboInvoice.InvoicePrintingMediaSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
                _InvoicePrintingMediaSetting = value
            End Set
        End Property
        Public WriteOnly Property AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting Implements IComboInvoice.AgencyInvoicePrintingMediaSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
                _AgencyInvoicePrintingMediaSetting = value
            End Set
        End Property
        Public WriteOnly Property OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting Implements IComboInvoice.OneTimeInvoicePrintingMediaSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
                _OneTimeInvoicePrintingMediaSetting = value
            End Set
        End Property
        Public WriteOnly Property AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice Implements IComboInvoice.AccountReceivableInvoice
            Set(value As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)
                _AccountReceivableInvoice = value
            End Set
        End Property
        Public WriteOnly Property IsDraft As Boolean Implements IComboInvoice.IsDraft
            Set(value As Boolean)
                _IsDraft = value
            End Set
        End Property
        Public WriteOnly Property MediaType As String Implements IComboInvoice.MediaType
            Set(value As String)
                _MediaType = value
            End Set
        End Property
		Public WriteOnly Property ApplyExchangeRate As Short Implements IComboInvoice.ApplyExchangeRate
			Set(value As Short)
				_ApplyExchangeRate = value
			End Set
		End Property
		Public WriteOnly Property ExchangeRateAmount As Decimal Implements IComboInvoice.ExchangeRateAmount
			Set(value As Decimal)
				_ExchangeRateAmount = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub SetParameterValues() Implements IComboInvoice.SetParameterValues

			'objects
			Dim IsMultiCurrencyEnabled As Boolean = False

			If _InvoicePrintingMediaSetting IsNot Nothing AndAlso _AgencyInvoicePrintingMediaSetting IsNot Nothing AndAlso
					_OneTimeInvoicePrintingMediaSetting IsNot Nothing AndAlso _AccountReceivableInvoice IsNot Nothing Then

				Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

					IsMultiCurrencyEnabled = AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext)

				End Using

				_MediaInvoicePrintingSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoicePrintingSetting(_InvoicePrintingMediaSetting, _AgencyInvoicePrintingMediaSetting, _OneTimeInvoicePrintingMediaSetting, _MediaType,
																														  IsMultiCurrencyEnabled, _ApplyExchangeRate, _ExchangeRateAmount, _AccountReceivableInvoice.CurrencyCode)

			End If

		End Sub
        Private Sub Invoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            If _MediaInvoicePrintingSetting IsNot Nothing Then

                If _MediaInvoicePrintingSetting.ShowLineDetail = 1 Then

                    If _MediaInvoicePrintingSetting.OrderMonthsColumn > 0 Then

                        If _MediaInvoicePrintingSetting.ProgramColumn = 0 AndAlso _MediaInvoicePrintingSetting.SpotLengthColumn = 0 AndAlso _MediaInvoicePrintingSetting.TagColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.StartEndTimesColumn = 0 AndAlso _MediaInvoicePrintingSetting.NumberOfSpotsColumn = 0 AndAlso _MediaInvoicePrintingSetting.RemarksColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.HeadlineColumn = 0 AndAlso _MediaInvoicePrintingSetting.StartDatesColumn = 0 AndAlso _MediaInvoicePrintingSetting.EndDatesColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.CreativeSizeColumn = 0 AndAlso _MediaInvoicePrintingSetting.InsertDatesColumn = 0 AndAlso _MediaInvoicePrintingSetting.CopyAreaColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.MaterialColumn = 0 AndAlso _MediaInvoicePrintingSetting.AdNumberColumn = 0 AndAlso _MediaInvoicePrintingSetting.LocationColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.OutdoorTypeColumn = 0 AndAlso _MediaInvoicePrintingSetting.SizeColumn = 0 AndAlso _MediaInvoicePrintingSetting.EditorialIssueColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.SectionColumn = 0 AndAlso _MediaInvoicePrintingSetting.QuantityColumn = 0 AndAlso _MediaInvoicePrintingSetting.AdSizeColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.URLColumn = 0 AndAlso _MediaInvoicePrintingSetting.InternetTypeColumn = 0 AndAlso _MediaInvoicePrintingSetting.JobComponentNumberColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.JobDescriptionColumn = 0 AndAlso _MediaInvoicePrintingSetting.ComponentDescriptionColumn = 0 AndAlso _MediaInvoicePrintingSetting.OrderDetailCommentColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.OrderHouseDetailCommentColumn = 0 AndAlso _MediaInvoicePrintingSetting.ExtraChargesColumn = 0 Then

                            GroupHeaderOrderTotals.Visible = True
                            GroupHeaderOrderNumberLine.Visible = False
                            GroupFooterOrderNumberLine.Visible = False

                            GroupHeaderOrderTotals.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderStartDate.ToString, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))
                            GroupHeaderOrderTotals.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderMonths.ToString, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))
                            _GroupedByOrderMonth = True

                        End If

                    End If

                    If _GroupedByOrderMonth = False Then

                        If _MediaInvoicePrintingSetting.SortLinesBy = AdvantageFramework.InvoicePrinting.MediaSortLinesBy.LineNumber Then

                            GroupHeaderOrderNumberLine.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderLineNumber.ToString, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))

                        ElseIf _MediaInvoicePrintingSetting.SortLinesBy = AdvantageFramework.InvoicePrinting.MediaSortLinesBy.LineDate Then

                            GroupHeaderOrderNumberLine.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderStartDate.ToString, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))
                            GroupHeaderOrderNumberLine.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderLineNumber.ToString, DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))

                        End If

                    End If

                Else

                    GroupHeaderOrderTotals.Visible = True
                    GroupHeaderOrderNumberLine.Visible = False
                    GroupFooterOrderNumberLine.Visible = False

                End If

            End If

        End Sub
        Private Sub Invoice_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim MediaInvoiceDetailFormatteds As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted) = Nothing
            Dim IncomeOnlyRecords As Generic.List(Of AdvantageFramework.Database.Entities.IncomeOnly) = Nothing
            Dim IncomeOnlyAmount As Decimal = 0

            If _MediaInvoicePrintingSetting IsNot Nothing AndAlso _AccountReceivableInvoice IsNot Nothing Then

                If _MediaInvoicePrintingSetting.ShowLineDetail = 1 Then

                    If _MediaInvoicePrintingSetting.OrderMonthsColumn > 0 Then

                        If _MediaInvoicePrintingSetting.ProgramColumn = 0 AndAlso _MediaInvoicePrintingSetting.SpotLengthColumn = 0 AndAlso _MediaInvoicePrintingSetting.TagColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.StartEndTimesColumn = 0 AndAlso _MediaInvoicePrintingSetting.NumberOfSpotsColumn = 0 AndAlso _MediaInvoicePrintingSetting.RemarksColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.HeadlineColumn = 0 AndAlso _MediaInvoicePrintingSetting.StartDatesColumn = 0 AndAlso _MediaInvoicePrintingSetting.EndDatesColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.CreativeSizeColumn = 0 AndAlso _MediaInvoicePrintingSetting.InsertDatesColumn = 0 AndAlso _MediaInvoicePrintingSetting.CopyAreaColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.MaterialColumn = 0 AndAlso _MediaInvoicePrintingSetting.AdNumberColumn = 0 AndAlso _MediaInvoicePrintingSetting.LocationColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.OutdoorTypeColumn = 0 AndAlso _MediaInvoicePrintingSetting.SizeColumn = 0 AndAlso _MediaInvoicePrintingSetting.EditorialIssueColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.SectionColumn = 0 AndAlso _MediaInvoicePrintingSetting.QuantityColumn = 0 AndAlso _MediaInvoicePrintingSetting.AdSizeColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.URLColumn = 0 AndAlso _MediaInvoicePrintingSetting.InternetTypeColumn = 0 AndAlso _MediaInvoicePrintingSetting.JobComponentNumberColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.JobDescriptionColumn = 0 AndAlso _MediaInvoicePrintingSetting.ComponentDescriptionColumn = 0 AndAlso _MediaInvoicePrintingSetting.OrderDetailCommentColumn = 0 AndAlso
                                _MediaInvoicePrintingSetting.OrderHouseDetailCommentColumn = 0 AndAlso _MediaInvoicePrintingSetting.ExtraChargesColumn = 0 Then

                            If _MediaInvoicePrintingSetting.OrderMonthsColumn = 3 Then

                                _MediaInvoicePrintingSetting.TotalColumnVisible3 = True

                            ElseIf _MediaInvoicePrintingSetting.OrderMonthsColumn = 4 Then

                                _MediaInvoicePrintingSetting.TotalColumnVisible4 = True

                            ElseIf _MediaInvoicePrintingSetting.OrderMonthsColumn = 5 Then

                                _MediaInvoicePrintingSetting.TotalColumnVisible5 = True

                            ElseIf _MediaInvoicePrintingSetting.OrderMonthsColumn = 6 Then

                                _MediaInvoicePrintingSetting.TotalColumnVisible6 = True

                            ElseIf _MediaInvoicePrintingSetting.OrderMonthsColumn = 7 Then

                                _MediaInvoicePrintingSetting.TotalColumnVisible7 = True

                            End If

                        End If

                    End If

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

					MediaInvoiceDetailFormatteds = AdvantageFramework.InvoicePrinting.LoadMediaInvoiceDetails(DbContext, _Session.UserCode, _AccountReceivableInvoice.InvoiceNumber, _AccountReceivableInvoice.InvoiceSequenceNumber, _MediaType, _MediaInvoicePrintingSetting.AddressBlockType, _MediaInvoicePrintingSetting.PrintClientName,
																					 _MediaInvoicePrintingSetting.PrintDivisionName, _MediaInvoicePrintingSetting.PrintProductDescription, _MediaInvoicePrintingSetting.PrintContactAfterAddress,
																					 _MediaInvoicePrintingSetting.ApplyExchangeRate, _MediaInvoicePrintingSetting.ExchangeRateAmount,
																					 _MediaInvoicePrintingSetting.ShowTaxSeparately, _MediaInvoicePrintingSetting.ShowCommissionSeparately,
																					 _MediaInvoicePrintingSetting.ShowRebateSeparately, _MediaInvoicePrintingSetting.UseInvoiceCategoryDescription,
																					 If(String.IsNullOrWhiteSpace(_MediaInvoicePrintingSetting.InvoiceTitle) = False, _MediaInvoicePrintingSetting.InvoiceTitle, ""),
																					 _MediaInvoicePrintingSetting.InvoiceFooterCommentType,
																					 If(String.IsNullOrWhiteSpace(_MediaInvoicePrintingSetting.InvoiceFooterComment) = False, _MediaInvoicePrintingSetting.InvoiceFooterComment, ""), _MediaInvoicePrintingSetting.ShowCodes,
																					 _MediaInvoicePrintingSetting.ContactType, _IsDraft, _AccountReceivableInvoice.Batch).Select(Function(Entity) New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted(Entity, _MediaInvoicePrintingSetting, _MediaType, _IsDraft)).ToList

					If MediaInvoiceDetailFormatteds IsNot Nothing AndAlso _MediaInvoicePrintingSetting.ShowZeroFunctionAmounts = False Then

                        Try

                            MediaInvoiceDetailFormatteds = MediaInvoiceDetailFormatteds.Where(Function(Entity) Entity.NetAmount.GetValueOrDefault(0) <> 0).ToList

                        Catch ex As Exception

                        End Try

                    End If

                    For Each MediaInvoiceDetailFormatted In MediaInvoiceDetailFormatteds.ToList

                        If _IsDraft Then

                            IncomeOnlyRecords = AdvantageFramework.Database.Procedures.IncomeOnly.Load(DbContext).Where(Function(Entity) Entity.ARInvoiceNumber Is Nothing AndAlso Entity.ARInvoiceSequence Is Nothing AndAlso
                                                                                                                                             Entity.ARType Is Nothing AndAlso
                                                                                                                                             Entity.JobNumber = MediaInvoiceDetailFormatted.JobNumber AndAlso Entity.JobComponentNumber = MediaInvoiceDetailFormatted.ComponentNumber AndAlso
                                                                                                                                             Entity.OrderNumber = MediaInvoiceDetailFormatted.OrderNumber AndAlso Entity.LineNumber = MediaInvoiceDetailFormatted.OrderLineNumber).ToList

                        Else

                            IncomeOnlyRecords = AdvantageFramework.Database.Procedures.IncomeOnly.Load(DbContext).Where(Function(Entity) Entity.ARInvoiceNumber = MediaInvoiceDetailFormatted.InvoiceNumber AndAlso Entity.ARInvoiceSequence = MediaInvoiceDetailFormatted.InvoiceSequenceNumber AndAlso
                                                                                                                                             Entity.ARType = MediaInvoiceDetailFormatted.InvoiceType AndAlso
                                                                                                                                             Entity.JobNumber = MediaInvoiceDetailFormatted.JobNumber AndAlso Entity.JobComponentNumber = MediaInvoiceDetailFormatted.ComponentNumber AndAlso
                                                                                                                                             Entity.OrderNumber = MediaInvoiceDetailFormatted.OrderNumber AndAlso Entity.LineNumber = MediaInvoiceDetailFormatted.OrderLineNumber).ToList

                        End If

                        If IncomeOnlyRecords IsNot Nothing AndAlso IncomeOnlyRecords.Count > 0 Then

                            IncomeOnlyAmount = IncomeOnlyRecords.Sum(Function(Entity) Entity.LineTotal.GetValueOrDefault(0))

                            If IncomeOnlyAmount <> 0 Then

                                If _MediaInvoicePrintingSetting.ShowCommissionSeparately = False Then

                                    If _MediaInvoicePrintingSetting.CommissionAmountColumn = 3 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue3) Then

                                            MediaInvoiceDetailFormatted.ColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue3) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue3) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue3) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.CommissionAmountColumn = 4 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue4) Then

                                            MediaInvoiceDetailFormatted.ColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue4) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue4) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue4) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.CommissionAmountColumn = 5 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue5) Then

                                            MediaInvoiceDetailFormatted.ColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue5) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue5) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue5) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.CommissionAmountColumn = 6 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue6) Then

                                            MediaInvoiceDetailFormatted.ColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue6) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue6) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue6) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.CommissionAmountColumn = 7 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue7) Then

                                            MediaInvoiceDetailFormatted.ColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue7) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue7) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue7) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    End If

                                    If _MediaInvoicePrintingSetting.BillAmountColumn = 3 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue3) Then

                                            MediaInvoiceDetailFormatted.ColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue3) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue3) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue3) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.BillAmountColumn = 4 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue4) Then

                                            MediaInvoiceDetailFormatted.ColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue4) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue4) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue4) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.BillAmountColumn = 5 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue5) Then

                                            MediaInvoiceDetailFormatted.ColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue5) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue5) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue5) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.BillAmountColumn = 6 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue6) Then

                                            MediaInvoiceDetailFormatted.ColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue6) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue6) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue6) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.BillAmountColumn = 7 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.ColumnValue7) Then

                                            MediaInvoiceDetailFormatted.ColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.ColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GrandTotalColumnValue7) Then

                                            MediaInvoiceDetailFormatted.GrandTotalColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GrandTotalColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.GroupTotalColumnValue7) Then

                                            MediaInvoiceDetailFormatted.GroupTotalColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.GroupTotalColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                        If IsNumeric(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue7) Then

                                            MediaInvoiceDetailFormatted.InvoiceTotalColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.InvoiceTotalColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    End If

                                Else

                                    If _MediaInvoicePrintingSetting.BillAmountColumn = 3 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.CommissionColumnValue3) Then

                                            MediaInvoiceDetailFormatted.CommissionColumnValue3 = FormatNumber(CDec(MediaInvoiceDetailFormatted.CommissionColumnValue3) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.BillAmountColumn = 4 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.CommissionColumnValue4) Then

                                            MediaInvoiceDetailFormatted.CommissionColumnValue4 = FormatNumber(CDec(MediaInvoiceDetailFormatted.CommissionColumnValue4) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.BillAmountColumn = 5 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.CommissionColumnValue5) Then

                                            MediaInvoiceDetailFormatted.CommissionColumnValue5 = FormatNumber(CDec(MediaInvoiceDetailFormatted.CommissionColumnValue5) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.BillAmountColumn = 6 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.CommissionColumnValue6) Then

                                            MediaInvoiceDetailFormatted.CommissionColumnValue6 = FormatNumber(CDec(MediaInvoiceDetailFormatted.CommissionColumnValue6) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    ElseIf _MediaInvoicePrintingSetting.BillAmountColumn = 7 Then

                                        If IsNumeric(MediaInvoiceDetailFormatted.CommissionColumnValue7) Then

                                            MediaInvoiceDetailFormatted.CommissionColumnValue7 = FormatNumber(CDec(MediaInvoiceDetailFormatted.CommissionColumnValue7) + IncomeOnlyAmount, 2, TriState.UseDefault, TriState.UseDefault, TriState.True)

                                        End If

                                    End If

                                End If

                                'MediaInvoiceDetailFormatted.CommissionAmount += IncomeOnlyAmount
                                'MediaInvoiceDetailFormatted.BillAmount += IncomeOnlyAmount
                                MediaInvoiceDetailFormatted.TotalAmount += IncomeOnlyAmount

                            End If

                        End If

                    Next

                    Me.DataSource = MediaInvoiceDetailFormatteds

                End Using

            End If

        End Sub
        Private Sub GroupHeaderInvoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderInvoice.BeforePrint

            'If _MediaType = "M" OrElse _MediaType = "N" OrElse _MediaType = "I" OrElse _MediaType = "O" Then

            '    XrLabelHeaderColumn3.Visible = False
            '    XrLabelColumn3.Visible = False
            '    XrLineOrderTotalColumn3.Visible = False
            '    XrLabelOrderTotalColumn3.Visible = False
            '    XrLineOrderGroupByTotalColumn3.Visible = False
            '    XrLabelOrderGroupByTotalColumn3.Visible = False

            '    XrLabelHeaderColumn2.WidthF = XrLabelHeaderColumn2.WidthF + XrLabelHeaderColumn3.WidthF
            '    XrLabelColumn2.WidthF = XrLabelColumn2.WidthF + XrLabelColumn3.WidthF

            'End If

        End Sub
        Private Sub GroupFooterOrderSub_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderSub.BeforePrint

            If _MediaInvoicePrintingSetting IsNot Nothing Then

                If _MediaInvoicePrintingSetting.ShowOrderSubtotals AndAlso _MediaInvoicePrintingSetting.ShowLineDetail = 1 Then

                    If _GroupedByOrderMonth Then

                        If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.OrderNumber = Me.GetCurrentColumnValue("OrderNumber")).Select(Function(Entity) Entity.OrderMonths).Distinct.Count <= 1 Then

                            e.Cancel = True

                        End If

                    Else

                        If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.OrderNumber = Me.GetCurrentColumnValue("OrderNumber")).Select(Function(Entity) Entity.OrderLineNumber).Distinct.Count <= 1 Then

                            e.Cancel = True

                        End If

                    End If

                Else

                    e.Cancel = True

                End If

            Else

                If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.OrderNumber = Me.GetCurrentColumnValue("OrderNumber")).Select(Function(Entity) Entity.OrderLineNumber).Distinct.Count <= 1 Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub XrSubreportBillingHistory_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportBillingHistory.BeforePrint

            Dim MediaInvoiceDetailFormatted As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted = Nothing
            Dim BillingHistorySubReport As BillingHistorySubReport = Nothing

            If TypeOf XrSubreportBillingHistory.ReportSource Is BillingHistorySubReport Then

                BillingHistorySubReport = XrSubreportBillingHistory.ReportSource

                BillingHistorySubReport.Session = _Session
                BillingHistorySubReport.IsDraft = _IsDraft

                If TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted Then

                    MediaInvoiceDetailFormatted = Me.GetCurrentRow

                    BillingHistorySubReport.InvoiceNumber.Value = MediaInvoiceDetailFormatted.InvoiceNumber
                    BillingHistorySubReport.OrderNumber.Value = MediaInvoiceDetailFormatted.OrderNumber

                End If

            End If

        End Sub
        Private Sub GroupFooterHeaderGroupBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterOrderGroupBy.BeforePrint

            If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.OrderGroupBy = Me.GetCurrentColumnValue("OrderGroupBy")).Select(Function(Entity) Entity.OrderNumber).Distinct.Count <= 1 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterInvoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterInvoice.BeforePrint

            If _MediaInvoicePrintingSetting IsNot Nothing Then

                If _MediaInvoicePrintingSetting.BillAmountColumn < 7 AndAlso _MediaInvoicePrintingSetting.BillAmountColumn > 2 Then

					XrLabelTotal.LeftF = CSng(_MediaInvoicePrintingSetting.BillAmountColumn - 2 & "50")
					XrLabelGrandTotal.LeftF = CSng(_MediaInvoicePrintingSetting.BillAmountColumn - 1 & "50")

				End If

            End If

        End Sub
        Private Sub XrLabelOrderGroupTotalColumn_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles XrLabelOrderGroupTotal3.SummaryCalculated, XrLabelOrderGroupTotal4.SummaryCalculated,
                                                                                                                                                 XrLabelOrderGroupTotal5.SummaryCalculated, XrLabelOrderGroupTotal6.SummaryCalculated,
                                                                                                                                                 XrLabelOrderGroupTotal7.SummaryCalculated

            'objects
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim FullInvoiceNumber As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim OrderMonths As String = Nothing
            Dim OrderGroupByDateValue As Nullable(Of Date) = Nothing
            Dim OrderGroupBy As String = Nothing

            If _MediaInvoicePrintingSetting IsNot Nothing AndAlso TypeOf sender Is DevExpress.XtraReports.UI.XRLabel Then

                If _MediaInvoicePrintingSetting.ShowLineDetail = 0 Then

                    FullInvoiceNumber = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.FullInvoiceNumber.ToString)
                    OrderNumber = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderNumber.ToString)
                    OrderGroupByDateValue = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderGroupByDateValue.ToString)
                    OrderGroupBy = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderGroupBy.ToString)

                    If _MediaInvoicePrintingSetting.OrderMonthsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            StartDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                              Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                              Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                              Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                              Entity.OrderStartDate.HasValue).Min(Function(Entity) Entity.OrderStartDate.Value)

                        Catch ex As Exception
                            StartDate = Date.MinValue
                        End Try

                        Try

                            EndDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                            Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                            Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                            Entity.OrderEndDate.HasValue).Max(Function(Entity) Entity.OrderEndDate.Value)

                        Catch ex As Exception
                            EndDate = Date.MinValue
                        End Try

                        If StartDate <> Date.MinValue AndAlso EndDate <> Date.MinValue Then

                            StartDate = New Date(StartDate.Year, StartDate.Month, 1)
                            EndDate = New Date(EndDate.Year, EndDate.Month, 1)

                            If StartDate <> EndDate Then

                                OrderMonths = StartDate.ToString("MMM yy") & "-" & EndDate.ToString("MMM yy")

                            Else

                                OrderMonths = StartDate.ToString("MMM yy")

                            End If

                        ElseIf StartDate <> Date.MinValue Then

                            StartDate = New Date(StartDate.Year, StartDate.Month, 1)

                            OrderMonths = StartDate.ToString("MMM yy")

                        End If

                        e.Text = OrderMonths

                    ElseIf _MediaInvoicePrintingSetting.StartDatesColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            StartDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                              Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                              Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                              Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                              Entity.OrderStartDate.HasValue).Min(Function(Entity) Entity.OrderStartDate.Value)

                        Catch ex As Exception
                            StartDate = Date.MinValue
                        End Try

                        If StartDate <> Date.MinValue Then

                            e.Text = FormatDateTime(StartDate, DateFormat.ShortDate)

                        End If

                    ElseIf _MediaInvoicePrintingSetting.EndDatesColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            EndDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                            Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                            Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                            Entity.OrderEndDate.HasValue).Max(Function(Entity) Entity.OrderEndDate.Value)

                        Catch ex As Exception
                            EndDate = Date.MinValue
                        End Try

                        If EndDate <> Date.MinValue Then

                            e.Text = FormatDateTime(EndDate, DateFormat.ShortDate)

                        End If

                    End If

                ElseIf _MediaInvoicePrintingSetting.ShowLineDetail = 1 AndAlso _GroupedByOrderMonth Then

                    If _MediaInvoicePrintingSetting.OrderMonthsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        e.Text = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderMonths.ToString)

                    End If

                End If

            End If

        End Sub
        Private Sub XrLabelOrderGroupTotalColumn_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelOrderGroupTotal3.BeforePrint, XrLabelOrderGroupTotal4.BeforePrint,
                                                                                                                                    XrLabelOrderGroupTotal5.BeforePrint, XrLabelOrderGroupTotal6.BeforePrint,
                                                                                                                                    XrLabelOrderGroupTotal7.BeforePrint

            If _MediaInvoicePrintingSetting IsNot Nothing AndAlso TypeOf sender Is DevExpress.XtraReports.UI.XRLabel Then

                If _MediaInvoicePrintingSetting.QuantityColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.SpotLengthColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.NumberOfSpotsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                    CType(sender, DevExpress.XtraReports.UI.XRLabel).Summary.FormatString = "{0:n0}"

                End If

            End If

        End Sub
        Private Sub XrLabelOrderTotalColumnColumn_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles XrLabelOrderTotalColumn3.SummaryCalculated, XrLabelOrderTotalColumn4.SummaryCalculated,
                                                                                                                                                  XrLabelOrderTotalColumn5.SummaryCalculated, XrLabelOrderTotalColumn6.SummaryCalculated,
                                                                                                                                                  XrLabelOrderTotalColumn7.SummaryCalculated

            'objects
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim FullInvoiceNumber As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim OrderMonths As String = Nothing
            Dim OrderGroupByDateValue As Nullable(Of Date) = Nothing
            Dim OrderGroupBy As String = Nothing

            If _MediaInvoicePrintingSetting IsNot Nothing AndAlso TypeOf sender Is DevExpress.XtraReports.UI.XRLabel Then

                If _MediaInvoicePrintingSetting.ShowLineDetail = 0 Then

                    FullInvoiceNumber = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.FullInvoiceNumber.ToString)
                    OrderNumber = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderNumber.ToString)
                    OrderGroupByDateValue = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderGroupByDateValue.ToString)
                    OrderGroupBy = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderGroupBy.ToString)

                    If _MediaInvoicePrintingSetting.OrderMonthsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            StartDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                              Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                              Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                              Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                              Entity.OrderStartDate.HasValue).Min(Function(Entity) Entity.OrderStartDate.Value)

                        Catch ex As Exception
                            StartDate = Date.MinValue
                        End Try

                        Try

                            EndDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                            Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                            Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                            Entity.OrderEndDate.HasValue).Max(Function(Entity) Entity.OrderEndDate.Value)

                        Catch ex As Exception
                            EndDate = Date.MinValue
                        End Try

                        If StartDate <> Date.MinValue AndAlso EndDate <> Date.MinValue Then

                            StartDate = New Date(StartDate.Year, StartDate.Month, 1)
                            EndDate = New Date(EndDate.Year, EndDate.Month, 1)

                            If StartDate <> EndDate Then

                                OrderMonths = StartDate.ToString("MMM yy") & "-" & EndDate.ToString("MMM yy")

                            Else

                                OrderMonths = StartDate.ToString("MMM yy")

                            End If

                        ElseIf StartDate <> Date.MinValue Then

                            StartDate = New Date(StartDate.Year, StartDate.Month, 1)

                            OrderMonths = StartDate.ToString("MMM yy")

                        End If

                        e.Text = OrderMonths

                    ElseIf _MediaInvoicePrintingSetting.StartDatesColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            StartDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                              Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                              Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                              Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                              Entity.OrderStartDate.HasValue).Min(Function(Entity) Entity.OrderStartDate.Value)

                        Catch ex As Exception
                            StartDate = Date.MinValue
                        End Try

                        If StartDate <> Date.MinValue Then

                            e.Text = FormatDateTime(StartDate, DateFormat.ShortDate)

                        End If

                    ElseIf _MediaInvoicePrintingSetting.EndDatesColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            EndDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                            Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                            Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                            Entity.OrderEndDate.HasValue).Max(Function(Entity) Entity.OrderEndDate.Value)

                        Catch ex As Exception
                            EndDate = Date.MinValue
                        End Try

                        If EndDate <> Date.MinValue Then

                            e.Text = FormatDateTime(EndDate, DateFormat.ShortDate)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub XrLabelOrderTotalColumn_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelOrderTotalColumn3.BeforePrint, XrLabelOrderTotalColumn4.BeforePrint,
                                                                                                                               XrLabelOrderTotalColumn5.BeforePrint, XrLabelOrderTotalColumn6.BeforePrint,
                                                                                                                               XrLabelOrderTotalColumn7.BeforePrint

            If _MediaInvoicePrintingSetting IsNot Nothing AndAlso TypeOf sender Is DevExpress.XtraReports.UI.XRLabel Then

                If _MediaInvoicePrintingSetting.QuantityColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.SpotLengthColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.NumberOfSpotsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                    CType(sender, DevExpress.XtraReports.UI.XRLabel).Summary.FormatString = "{0:n0}"

                ElseIf _MediaInvoicePrintingSetting.ShowLineDetail = 1 AndAlso _GroupedByOrderMonth Then

                    If _MediaInvoicePrintingSetting.OrderMonthsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub XrLineOrderTotalColumn_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLineOrderTotalColumn3.BeforePrint, XrLineOrderTotalColumn4.BeforePrint,
                                                                                                                       XrLineOrderTotalColumn5.BeforePrint, XrLineOrderTotalColumn6.BeforePrint,
                                                                                                                       XrLineOrderTotalColumn7.BeforePrint

            If _MediaInvoicePrintingSetting.ShowLineDetail = 1 AndAlso _GroupedByOrderMonth Then

                If _MediaInvoicePrintingSetting.OrderMonthsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLine).Name)) Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub XrLabelOrderGroupByTotalColumnColumn_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles XrLabelOrderGroupByTotalColumn3.SummaryCalculated, XrLabelOrderGroupByTotalColumn4.SummaryCalculated,
                                                                                                                                                         XrLabelOrderGroupByTotalColumn5.SummaryCalculated, XrLabelOrderGroupByTotalColumn6.SummaryCalculated,
                                                                                                                                                         XrLabelOrderGroupByTotalColumn7.SummaryCalculated

            'objects
            Dim StartDate As Date = Date.MinValue
            Dim EndDate As Date = Date.MinValue
            Dim FullInvoiceNumber As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim OrderMonths As String = Nothing
            Dim OrderGroupByDateValue As Nullable(Of Date) = Nothing
            Dim OrderGroupBy As String = Nothing

            If _MediaInvoicePrintingSetting IsNot Nothing AndAlso TypeOf sender Is DevExpress.XtraReports.UI.XRLabel Then

                If _MediaInvoicePrintingSetting.ShowLineDetail = 0 Then

                    FullInvoiceNumber = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.FullInvoiceNumber.ToString)
                    OrderNumber = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderNumber.ToString)
                    OrderGroupByDateValue = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderGroupByDateValue.ToString)
                    OrderGroupBy = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.OrderGroupBy.ToString)

                    If _MediaInvoicePrintingSetting.OrderMonthsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            StartDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                              Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                              Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                              Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                              Entity.OrderStartDate.HasValue).Min(Function(Entity) Entity.OrderStartDate.Value)

                        Catch ex As Exception
                            StartDate = Date.MinValue
                        End Try

                        Try

                            EndDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                            Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                            Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                            Entity.OrderEndDate.HasValue).Max(Function(Entity) Entity.OrderEndDate.Value)

                        Catch ex As Exception
                            EndDate = Date.MinValue
                        End Try

                        If StartDate <> Date.MinValue AndAlso EndDate <> Date.MinValue Then

                            StartDate = New Date(StartDate.Year, StartDate.Month, 1)
                            EndDate = New Date(EndDate.Year, EndDate.Month, 1)

                            If StartDate <> EndDate Then

                                OrderMonths = StartDate.ToString("MMM yy") & "-" & EndDate.ToString("MMM yy")

                            Else

                                OrderMonths = StartDate.ToString("MMM yy")

                            End If

                        ElseIf StartDate <> Date.MinValue Then

                            StartDate = New Date(StartDate.Year, StartDate.Month, 1)

                            OrderMonths = StartDate.ToString("MMM yy")

                        End If

                        e.Text = OrderMonths

                    ElseIf _MediaInvoicePrintingSetting.StartDatesColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            StartDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                              Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                              Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                              Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                              Entity.OrderStartDate.HasValue).Min(Function(Entity) Entity.OrderStartDate.Value)

                        Catch ex As Exception
                            StartDate = Date.MinValue
                        End Try

                        If StartDate <> Date.MinValue Then

                            e.Text = FormatDateTime(StartDate, DateFormat.ShortDate)

                        End If

                    ElseIf _MediaInvoicePrintingSetting.EndDatesColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        Try

                            EndDate = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                            Entity.OrderNumber = OrderNumber AndAlso
                                                                                                                                                                            Entity.OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) = OrderGroupByDateValue.GetValueOrDefault(Date.MinValue) AndAlso
                                                                                                                                                                            Entity.OrderGroupBy = OrderGroupBy AndAlso
                                                                                                                                                                            Entity.OrderEndDate.HasValue).Max(Function(Entity) Entity.OrderEndDate.Value)

                        Catch ex As Exception
                            EndDate = Date.MinValue
                        End Try

                        If EndDate <> Date.MinValue Then

                            e.Text = FormatDateTime(EndDate, DateFormat.ShortDate)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub XrLabelOrderGroupByTotalColumn_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelOrderGroupByTotalColumn3.BeforePrint, XrLabelOrderGroupByTotalColumn4.BeforePrint,
                                                                                                                                      XrLabelOrderGroupByTotalColumn5.BeforePrint, XrLabelOrderGroupByTotalColumn6.BeforePrint,
                                                                                                                                      XrLabelOrderGroupByTotalColumn7.BeforePrint

            If _MediaInvoicePrintingSetting IsNot Nothing AndAlso TypeOf sender Is DevExpress.XtraReports.UI.XRLabel Then

                If _MediaInvoicePrintingSetting.QuantityColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.SpotLengthColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.NumberOfSpotsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                    CType(sender, DevExpress.XtraReports.UI.XRLabel).Summary.FormatString = "{0:n0}"

                ElseIf _MediaInvoicePrintingSetting.ShowLineDetail = 1 AndAlso _GroupedByOrderMonth Then

                    If _MediaInvoicePrintingSetting.OrderMonthsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub XrLineOrderGroupByTotalColumn_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLineOrderGroupByTotalColumn3.BeforePrint, XrLineOrderGroupByTotalColumn4.BeforePrint,
                                                                                                                              XrLineOrderGroupByTotalColumn5.BeforePrint, XrLineOrderGroupByTotalColumn6.BeforePrint,
                                                                                                                              XrLineOrderGroupByTotalColumn7.BeforePrint

            If _MediaInvoicePrintingSetting IsNot Nothing AndAlso _MediaInvoicePrintingSetting.ShowLineDetail = 1 AndAlso _GroupedByOrderMonth Then

                If _MediaInvoicePrintingSetting.OrderMonthsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLine).Name)) Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub XrSubreportTaxInformation_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportTaxInformation.BeforePrint

            'objects
            Dim TaxInformationSubReport As TaxInformationSubReport = Nothing
            Dim FullInvoiceNumber As String = ""
            Dim TaxAmount3 As Nullable(Of Decimal) = Nothing
            Dim TaxAmount4 As Nullable(Of Decimal) = Nothing
            Dim TaxAmount5 As Nullable(Of Decimal) = Nothing
            Dim TaxAmount6 As Nullable(Of Decimal) = Nothing
            Dim TaxAmount7 As Nullable(Of Decimal) = Nothing
            Dim TaxInformations As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaTaxInformation) = Nothing
            Dim MediaInvoiceDetailFormatteds As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted) = Nothing

            If _MediaInvoicePrintingSetting.ShowTaxSeparately Then

                If TypeOf XrSubreportTaxInformation.ReportSource Is TaxInformationSubReport Then

                    TaxInformationSubReport = XrSubreportTaxInformation.ReportSource

                    FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")
                    MediaInvoiceDetailFormatteds = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber).ToList

                    TaxInformations = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaTaxInformation)

                    TaxAmount3 = Nothing
                    TaxAmount4 = Nothing
                    TaxAmount5 = Nothing
                    TaxAmount6 = Nothing
                    TaxAmount7 = Nothing

                    TaxAmount3 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CityTaxColumnValue3.GetValueOrDefault(0)).Sum
                    TaxAmount4 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CityTaxColumnValue4.GetValueOrDefault(0)).Sum
                    TaxAmount5 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CityTaxColumnValue5.GetValueOrDefault(0)).Sum
                    TaxAmount6 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CityTaxColumnValue6.GetValueOrDefault(0)).Sum
                    TaxAmount7 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CityTaxColumnValue7.GetValueOrDefault(0)).Sum

                    If (TaxAmount3 + TaxAmount4 + TaxAmount5 + TaxAmount6 + TaxAmount7) > 0 Then

                        TaxAmount3 = If(TaxAmount3 = 0, Nothing, TaxAmount3)
                        TaxAmount4 = If(TaxAmount4 = 0, Nothing, TaxAmount4)
                        TaxAmount5 = If(TaxAmount5 = 0, Nothing, TaxAmount5)
                        TaxAmount6 = If(TaxAmount6 = 0, Nothing, TaxAmount6)
                        TaxAmount7 = If(TaxAmount7 = 0, Nothing, TaxAmount7)

                        TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.MediaTaxInformation(FullInvoiceNumber, _MediaInvoicePrintingSetting.CityTaxLabel, TaxAmount3, TaxAmount4, TaxAmount5, TaxAmount6, TaxAmount7))

                    End If

                    TaxAmount3 = Nothing
                    TaxAmount4 = Nothing
                    TaxAmount5 = Nothing
                    TaxAmount6 = Nothing
                    TaxAmount7 = Nothing

                    TaxAmount3 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CountyTaxColumnValue3.GetValueOrDefault(0)).Sum
                    TaxAmount4 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CountyTaxColumnValue4.GetValueOrDefault(0)).Sum
                    TaxAmount5 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CountyTaxColumnValue5.GetValueOrDefault(0)).Sum
                    TaxAmount6 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CountyTaxColumnValue6.GetValueOrDefault(0)).Sum
                    TaxAmount7 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.CountyTaxColumnValue7.GetValueOrDefault(0)).Sum

                    If (TaxAmount3 + TaxAmount4 + TaxAmount5 + TaxAmount6 + TaxAmount7) > 0 Then

                        TaxAmount3 = If(TaxAmount3 = 0, Nothing, TaxAmount3)
                        TaxAmount4 = If(TaxAmount4 = 0, Nothing, TaxAmount4)
                        TaxAmount5 = If(TaxAmount5 = 0, Nothing, TaxAmount5)
                        TaxAmount6 = If(TaxAmount6 = 0, Nothing, TaxAmount6)
                        TaxAmount7 = If(TaxAmount7 = 0, Nothing, TaxAmount7)

                        TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.MediaTaxInformation(FullInvoiceNumber, _MediaInvoicePrintingSetting.CountyTaxLabel, TaxAmount3, TaxAmount4, TaxAmount5, TaxAmount6, TaxAmount7))

                    End If

                    TaxAmount3 = Nothing
                    TaxAmount4 = Nothing
                    TaxAmount5 = Nothing
                    TaxAmount6 = Nothing
                    TaxAmount7 = Nothing

                    TaxAmount3 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.StateTaxColumnValue3.GetValueOrDefault(0)).Sum
                    TaxAmount4 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.StateTaxColumnValue4.GetValueOrDefault(0)).Sum
                    TaxAmount5 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.StateTaxColumnValue5.GetValueOrDefault(0)).Sum
                    TaxAmount6 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.StateTaxColumnValue6.GetValueOrDefault(0)).Sum
                    TaxAmount7 = MediaInvoiceDetailFormatteds.Select(Function(Entity) Entity.StateTaxColumnValue7.GetValueOrDefault(0)).Sum

                    If (TaxAmount3 + TaxAmount4 + TaxAmount5 + TaxAmount6 + TaxAmount7) > 0 Then

                        TaxAmount3 = If(TaxAmount3 = 0, Nothing, TaxAmount3)
                        TaxAmount4 = If(TaxAmount4 = 0, Nothing, TaxAmount4)
                        TaxAmount5 = If(TaxAmount5 = 0, Nothing, TaxAmount5)
                        TaxAmount6 = If(TaxAmount6 = 0, Nothing, TaxAmount6)
                        TaxAmount7 = If(TaxAmount7 = 0, Nothing, TaxAmount7)

                        TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.MediaTaxInformation(FullInvoiceNumber, _MediaInvoicePrintingSetting.StateTaxLabel, TaxAmount3, TaxAmount4, TaxAmount5, TaxAmount6, TaxAmount7))

                    End If

                    If TaxInformations.Count > 0 Then

                        TaxInformationSubReport.DataSource = TaxInformations

                    Else

                        e.Cancel = True

                    End If

                End If

            Else

                e.Cancel = True

            End If

        End Sub
		Private Sub XrLabelJobVersionData_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelJobVersionData.BeforePrint

			'objects
			Dim JobVersions As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.JobVersion) = Nothing
			Dim JobVersionData As String = ""

			Try

				Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

					JobVersions = DbContext.Database.SqlQuery(Of AdvantageFramework.InvoicePrinting.Classes.JobVersion)(String.Format("EXEC dbo.advsp_invoice_printing_load_job_version_template {0}, {1}", Me.GetCurrentColumnValue("JobNumber"), Me.GetCurrentColumnValue("ComponentNumber"))).ToList

				End Using

			Catch ex As Exception
				JobVersions = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.JobVersion)
			End Try

			For Each JobVersion In JobVersions

				If String.IsNullOrWhiteSpace(JobVersionData) Then

					JobVersionData = JobVersion.Label & " " & JobVersion.Value

				Else

					JobVersionData &= System.Environment.NewLine & JobVersion.Label & " " & JobVersion.Value

				End If

			Next

			CType(sender, DevExpress.XtraReports.UI.XRLabel).Text = JobVersionData

		End Sub
		Private Sub XrLabelCampaignComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelCampaignComment.BeforePrint

			If _MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByCampaign Then

				XrLabelCampaignComment.Text = Nothing

			End If

		End Sub
		Private Sub XrLabelCampaignCommentGroupBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelCampaignCommentGroupBy.BeforePrint

			If _MediaInvoicePrintingSetting.HeaderGroupBy <> AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByCampaign Then

				XrLabelCampaignCommentGroupBy.Text = Nothing

			End If

		End Sub

#End Region

	End Class

End Namespace