Namespace Invoices.StandardMediaInvoice

	Public Class Invoice
		Implements AdvantageFramework.Reporting.Reports.ICustomInvoice

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
		Private _InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
		Private _MediaInvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoicePrintingSetting = Nothing
		Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
		Private _InvoiceNumber As Integer = Nothing
		Private _SequenceNumber As Short = Nothing
		Private _MediaType As String = Nothing
		Private _UserCode As String = Nothing
		Private _InvoiceDate As Date = Nothing
		Private _IsDraft As Boolean = False
		Private _PageCount As Integer = -1
        Private _GroupedByOrderMonth As Boolean = False
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property InvoiceType As InvoicePrinting.InvoiceTypes Implements ICustomInvoice.InvoiceType
			Get
				InvoiceType = InvoicePrinting.InvoiceTypes.Media
			End Get
		End Property
		Public ReadOnly Property BindingSourceControl As Windows.Forms.BindingSource Implements ICustomInvoice.BindingSourceControl
			Get
				BindingSourceControl = BindingSource
			End Get
		End Property
		Public Property CustomInvoiceID As Integer Implements ICustomInvoice.CustomInvoiceID
		Public Property InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
			Get
				InvoicePrintingMediaSetting = _InvoicePrintingMediaSetting
			End Get
			Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
				_InvoicePrintingMediaSetting = value
			End Set
		End Property
		Public Property AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
			Get
				AgencyInvoicePrintingMediaSetting = _AgencyInvoicePrintingMediaSetting
			End Get
			Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
				_AgencyInvoicePrintingMediaSetting = value
			End Set
		End Property
		Public Property OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
			Get
				OneTimeInvoicePrintingMediaSetting = _OneTimeInvoicePrintingMediaSetting
			End Get
			Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
				_OneTimeInvoicePrintingMediaSetting = value
			End Set
		End Property
		Public Property AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice
			Get
				AccountReceivableInvoice = _AccountReceivableInvoice
			End Get
			Set(value As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)
				_AccountReceivableInvoice = value
			End Set
		End Property
		Public Property Session As AdvantageFramework.Security.Session
			Get
				Session = _Session
			End Get
			Set(value As AdvantageFramework.Security.Session)
				_Session = value
			End Set
		End Property
		Public Property InvoiceNumber As Integer
			Get
				InvoiceNumber = _InvoiceNumber
			End Get
			Set(value As Integer)
				_InvoiceNumber = value
			End Set
		End Property
		Public Property SequenceNumber As Short
			Get
				SequenceNumber = _SequenceNumber
			End Get
			Set(value As Short)
				_SequenceNumber = value
			End Set
		End Property
		Public Property MediaType As String
			Get
				MediaType = _MediaType
			End Get
			Set(value As String)
				_MediaType = value
			End Set
		End Property
		Public Property UserCode As String
			Get
				UserCode = _UserCode
			End Get
			Set(value As String)
				_UserCode = value
			End Set
		End Property
		Public Property InvoiceDate As Date
			Get
				InvoiceDate = _InvoiceDate
			End Get
			Set(value As Date)
				_InvoiceDate = value
			End Set
		End Property
		Public Property IsDraft As Boolean
			Get
				IsDraft = _IsDraft
			End Get
			Set(value As Boolean)
				_IsDraft = value
			End Set
		End Property

#End Region

#Region " Methods "

		Public Sub SetParameterValues()

			'objects
			Dim IsMultiCurrencyEnabled As Boolean = False
			Dim ApplyExchangeRate As Short = 1
			Dim ExchangeRateAmount As Decimal = 1.0

			If _InvoicePrintingMediaSetting IsNot Nothing AndAlso _AgencyInvoicePrintingMediaSetting IsNot Nothing AndAlso
					_OneTimeInvoicePrintingMediaSetting IsNot Nothing AndAlso _AccountReceivableInvoice IsNot Nothing Then

				Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

					If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

						IsMultiCurrencyEnabled = True

						If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

							ApplyExchangeRate = 2
							ExchangeRateAmount = _AccountReceivableInvoice.CurrencyRate.GetValueOrDefault(1)

                            If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencySymbol) = False Then

                                XrLabelGrandTotal.TextFormatString = _AccountReceivableInvoice.CurrencySymbol & "{0:n2}"

                            Else

                                XrLabelGrandTotal.TextFormatString = "{0:n2}"

                            End If

                        Else

							ApplyExchangeRate = _InvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(1)
							ExchangeRateAmount = _InvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(1)

                            XrLabelGrandTotal.TextFormatString = "{0:c2}"

                        End If

					Else

						ApplyExchangeRate = _InvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(1)
						ExchangeRateAmount = _InvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(1)

                        XrLabelGrandTotal.TextFormatString = "{0:c2}"

                    End If

				End Using

				_MediaInvoicePrintingSetting = New AdvantageFramework.InvoicePrinting.Classes.MediaInvoicePrintingSetting(_InvoicePrintingMediaSetting, _AgencyInvoicePrintingMediaSetting, _OneTimeInvoicePrintingMediaSetting, _MediaType,
																														  IsMultiCurrencyEnabled, ApplyExchangeRate, ExchangeRateAmount, _AccountReceivableInvoice.CurrencyCode)

			End If

		End Sub
		Private Sub Invoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            XrPageInfo.PageInfo = DevExpress.XtraPrinting.PageInfo.NumberOfTotal
            XrPageInfo.Format = "{0} of {1}"

            If _MediaInvoicePrintingSetting IsNot Nothing Then

				If _MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory Then

					XrLabelOrderGroupByInOrderTotals.Visible = True

					GroupHeaderOrder.GroupFields.Clear()
					GroupHeaderOrder.Visible = False
					GroupFooterOrder.Visible = False

					GroupHeaderOrderSub.GroupFields.Clear()
					GroupHeaderOrderSub.Visible = False
					GroupFooterOrderSub.Visible = False

					GroupHeaderOrderNumberLine.GroupFields.Clear()
					GroupHeaderOrderNumberLine.Visible = False
					GroupFooterOrderNumberLine.Visible = False

					GroupHeaderOrderTotals.Visible = True

				Else

					If _MediaInvoicePrintingSetting.ShowLineDetail = 1 Then

						If _MediaInvoicePrintingSetting.OrderMonthsColumn > 0 Then

                            If _MediaInvoicePrintingSetting.LineNumberColumn = 0 AndAlso _MediaInvoicePrintingSetting.ProgramColumn = 0 AndAlso _MediaInvoicePrintingSetting.SpotLengthColumn = 0 AndAlso _MediaInvoicePrintingSetting.TagColumn = 0 AndAlso
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

			End If

        End Sub
		Private Sub Invoice_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

			'objects
			Dim MediaInvoiceDetailFormatteds As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted) = Nothing

			If _MediaInvoicePrintingSetting IsNot Nothing Then

				If _MediaInvoicePrintingSetting.ShowLineDetail = 1 Then

					If _MediaInvoicePrintingSetting.OrderMonthsColumn > 0 Then

                        If _MediaInvoicePrintingSetting.LineNumberColumn = 0 AndAlso _MediaInvoicePrintingSetting.ProgramColumn = 0 AndAlso _MediaInvoicePrintingSetting.SpotLengthColumn = 0 AndAlso _MediaInvoicePrintingSetting.TagColumn = 0 AndAlso
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

                    MediaInvoiceDetailFormatteds = AdvantageFramework.InvoicePrinting.LoadMediaInvoiceDetails(DbContext, _UserCode, _InvoiceNumber, _SequenceNumber, _MediaType, _MediaInvoicePrintingSetting.AddressBlockType, _MediaInvoicePrintingSetting.PrintClientName,
                                                                                     _MediaInvoicePrintingSetting.PrintDivisionName, _MediaInvoicePrintingSetting.PrintProductDescription, _MediaInvoicePrintingSetting.PrintContactAfterAddress,
                                                                                     _MediaInvoicePrintingSetting.ApplyExchangeRate, _MediaInvoicePrintingSetting.ExchangeRateAmount,
                                                                                     _MediaInvoicePrintingSetting.ShowTaxSeparately, _MediaInvoicePrintingSetting.ShowCommissionSeparately,
                                                                                     _MediaInvoicePrintingSetting.ShowRebateSeparately, _MediaInvoicePrintingSetting.UseInvoiceCategoryDescription,
                                                                                     If(String.IsNullOrEmpty(_MediaInvoicePrintingSetting.InvoiceTitle) = False, _MediaInvoicePrintingSetting.InvoiceTitle, ""),
                                                                                     _MediaInvoicePrintingSetting.InvoiceFooterCommentType,
                                                                                     If(String.IsNullOrWhiteSpace(_MediaInvoicePrintingSetting.InvoiceFooterComment) = False, _MediaInvoicePrintingSetting.InvoiceFooterComment, ""), _MediaInvoicePrintingSetting.ShowCodes,
                                                                                     _MediaInvoicePrintingSetting.ContactType, _IsDraft, _AccountReceivableInvoice.Batch).Select(Function(Entity) New AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted(Entity, _MediaInvoicePrintingSetting, _MediaType, _IsDraft)).ToList

                    If MediaInvoiceDetailFormatteds IsNot Nothing AndAlso _MediaInvoicePrintingSetting.ShowZeroFunctionAmounts = False Then

						Try

                            MediaInvoiceDetailFormatteds = MediaInvoiceDetailFormatteds.Where(Function(Entity) Entity.TotalAmount.GetValueOrDefault(0) <> 0).ToList

                        Catch ex As Exception

						End Try

					End If

                    If String.IsNullOrWhiteSpace(_MediaInvoicePrintingSetting.LocationCode) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _MediaInvoicePrintingSetting.LocationCode, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

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

			If _MediaInvoicePrintingSetting IsNot Nothing AndAlso _MediaInvoicePrintingSetting.HeaderGroupBy = AdvantageFramework.InvoicePrinting.MediaOrderGroupBy.GroupByVendorInvoiceCategory Then

				e.Cancel = True

			Else

                'If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).Where(Function(Entity) Entity.OrderGroupBy = Me.GetCurrentColumnValue("OrderGroupBy")).Select(Function(Entity) Entity.OrderNumber).Distinct.Count <= 1 Then

                '	e.Cancel = True

                'End If

            End If

		End Sub
		Private Sub GroupFooterInvoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterInvoice.BeforePrint

			If _MediaInvoicePrintingSetting IsNot Nothing Then

				If _MediaInvoicePrintingSetting.BillAmountColumn < 7 AndAlso _MediaInvoicePrintingSetting.BillAmountColumn > 2 Then

					XrPanelInvoiceTotal.LeftF = CSng(_MediaInvoicePrintingSetting.BillAmountColumn - 2 & "20.17")

				End If

			End If

		End Sub
		Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

			If _MediaInvoicePrintingSetting IsNot Nothing Then

                If _MediaInvoicePrintingSetting.UseLocationPrintOptions AndAlso _MediaInvoicePrintingSetting.ShowPageHeaderLogo Then

                    If String.IsNullOrWhiteSpace(_MediaInvoicePrintingSetting.PageHeaderLogoPath) = False Then

                        If My.Computer.FileSystem.FileExists(_MediaInvoicePrintingSetting.PageHeaderLogoPath) Then

                            XrPictureBoxHeaderLogo.ImageUrl = _MediaInvoicePrintingSetting.PageHeaderLogoPath

                        End If

                    ElseIf _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                        Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                            XrPictureBoxHeaderLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                        End Using

                    End If

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

                If _MediaInvoicePrintingSetting.QuantityColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.SpotLengthColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.NumberOfSpotsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                    If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then

                        e.Text = FormatNumber(e.Value, 0)

                    End If

                End If

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

                    ElseIf _MediaType = "O" AndAlso _MediaInvoicePrintingSetting.InsertDatesColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

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

                    ElseIf _MediaType = "O" AndAlso _MediaInvoicePrintingSetting.OutdoorEndDateColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

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

                    'CType(sender, DevExpress.XtraReports.UI.XRLabel).Summary.FormatString = "{0:n0}"

                End If

			End If

		End Sub
        Private Sub XrLabelOrderTotalColumn_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles XrLabelOrderTotalColumn3.SummaryCalculated, XrLabelOrderTotalColumn4.SummaryCalculated,
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

                If _MediaInvoicePrintingSetting.QuantityColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.SpotLengthColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.NumberOfSpotsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                    If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then

                        e.Text = FormatNumber(e.Value, 0)

                    End If

                End If

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

                    'CType(sender, DevExpress.XtraReports.UI.XRLabel).Summary.FormatString = "{0:n0}"

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
        Private Sub XrLabelOrderGroupByTotalColumn_SummaryCalculated(sender As Object, e As DevExpress.XtraReports.UI.TextFormatEventArgs) Handles XrLabelOrderGroupByTotalColumn3.SummaryCalculated, XrLabelOrderGroupByTotalColumn4.SummaryCalculated,
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

                If _MediaInvoicePrintingSetting.QuantityColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.SpotLengthColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) OrElse
                        _MediaInvoicePrintingSetting.NumberOfSpotsColumn = CInt(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(CType(sender, DevExpress.XtraReports.UI.XRLabel).Name)) Then

                    If e.Value IsNot Nothing AndAlso IsNumeric(e.Value) Then

                        e.Text = FormatNumber(e.Value, 0)

                    End If

                End If

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

                    'CType(sender, DevExpress.XtraReports.UI.XRLabel).Summary.FormatString = "{0:n0}"

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
		Private Sub XrLabelInvoiceDateData_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelInvoiceDateData.BeforePrint

			XrLabelInvoiceDateData.Text = _InvoiceDate.ToShortDateString

		End Sub
		Private Sub XrLabelInvoiceNumberData_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelInvoiceNumberData.BeforePrint

			'objects
			Dim FullInvoiceNumber As String = ""
			Dim InvoiceNumber As Integer = Nothing
			Dim SequenceNumber As Short = Nothing

			FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")
			InvoiceNumber = Me.GetCurrentColumnValue("InvoiceNumber")
			SequenceNumber = Me.GetCurrentColumnValue("InvoiceSequenceNumber")

            If SequenceNumber > 0 AndAlso SequenceNumber < 99 Then

                XrLabelInvoiceNumberData.Text = FullInvoiceNumber

            Else

                XrLabelInvoiceNumberData.Text = Format(InvoiceNumber, "00000#")

			End If

			If _IsDraft Then

				XrLabelInvoiceNumberData.Text &= "DRAFT "

			End If

		End Sub
		Private Sub XrLabelStandardComment_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelStandardComment.BeforePrint

			'objects
			Dim InvoiceFooterCommentFontSize As Nullable(Of Short) = Nothing

			InvoiceFooterCommentFontSize = CShort(Me.GetCurrentColumnValue("InvoiceFooterCommentFontSize"))

			If InvoiceFooterCommentFontSize.HasValue AndAlso InvoiceFooterCommentFontSize.Value > 0 Then

				XrLabelStandardComment.Font = New Drawing.Font(XrLabelStandardComment.Font.Name, CSng(InvoiceFooterCommentFontSize.Value))

			End If

		End Sub
		Private Sub XrLabelBillComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelBillComment.BeforePrint

			If _MediaInvoicePrintingSetting IsNot Nothing Then

				If _MediaInvoicePrintingSetting.IncludeBillingComment Then

					If Me.PrintingSystem.Document.PageCount <> _PageCount Then

						_PageCount = PrintingSystem.Document.PageCount

					End If

					If _PageCount > 0 Then

						XrLabelBillComment.Visible = False
						e.Cancel = True

					End If

				Else

					XrLabelBillComment.Visible = False
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

					If (TaxAmount3 + TaxAmount4 + TaxAmount5 + TaxAmount6 + TaxAmount7) <> 0 Then

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

					If (TaxAmount3 + TaxAmount4 + TaxAmount5 + TaxAmount6 + TaxAmount7) <> 0 Then

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

					If (TaxAmount3 + TaxAmount4 + TaxAmount5 + TaxAmount6 + TaxAmount7) <> 0 Then

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
		Private Sub XrLabelInvoiceTitle_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelInvoiceTitle.BeforePrint

			If _MediaInvoicePrintingSetting IsNot Nothing Then

				If _MediaInvoicePrintingSetting.ShowSalesClass AndAlso _MediaInvoicePrintingSetting.SalesClassLocation = AdvantageFramework.InvoicePrinting.MediaSalesClassLocations.Header Then

					XrLabelInvoiceTitle.Text = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.SalesClass.ToString).ToString.ToUpper & " INVOICE"

				Else

					XrLabelInvoiceTitle.Text = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.InvoiceCategory.ToString)

				End If

			Else

				XrLabelInvoiceTitle.Text = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted.Properties.InvoiceCategory.ToString)

			End If

		End Sub
		Private Sub XrLabelTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelTotal.BeforePrint

			If _MediaInvoicePrintingSetting IsNot Nothing AndAlso _MediaInvoicePrintingSetting.ApplyExchangeRate = 2 AndAlso _AccountReceivableInvoice IsNot Nothing Then

				If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

					XrLabelTotal.Text &= " (" & _AccountReceivableInvoice.CurrencyCode & ")"

				End If

			End If

		End Sub
		Private Sub XrTableCellClientPO_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableCellClientPO.BeforePrint

			'objects
			Dim MediaInvoiceDetailFormatted As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted = Nothing

			MediaInvoiceDetailFormatted = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceDetailFormatted)).FirstOrDefault

			If MediaInvoiceDetailFormatted IsNot Nothing Then

				XrTableCellClientPO.Text = MediaInvoiceDetailFormatted.ClientPO

			End If

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