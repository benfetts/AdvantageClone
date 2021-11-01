Namespace Invoices.GrandTotal

    Public Class Invoice
        Implements AdvantageFramework.Reporting.Reports.ICustomInvoice

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
        Private _InvoiceNumber As Integer = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _UserCode As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _IsDraft As Boolean = False
        Private _PageCount As Integer = -1
		Private _ApplyExchangeRate As Short = 1
        Private _ExchangeRateAmount As Decimal = 1.0
        Private _HideExchangeRateMessage As Boolean = False
        Private _CDPDaysToPay As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.CDPDaysToPay) = Nothing
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property InvoiceType As InvoicePrinting.InvoiceTypes Implements ICustomInvoice.InvoiceType
            Get
                InvoiceType = InvoicePrinting.InvoiceTypes.ProductionGrandTotal
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As Windows.Forms.BindingSource Implements ICustomInvoice.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public Property CustomInvoiceID As Integer Implements ICustomInvoice.CustomInvoiceID
		Public Property Session As AdvantageFramework.Security.Session
			Get
				Session = _Session
			End Get
			Set(value As AdvantageFramework.Security.Session)
				_Session = value
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
		Public Property InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
			Get
				InvoicePrintingSetting = _InvoicePrintingSetting
			End Get
			Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)
				_InvoicePrintingSetting = value
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

            ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
            ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)
            IncludeClientReference.Value = _InvoicePrintingSetting.IncludeClientReference.GetValueOrDefault(False)
            IncludeClientPO.Value = _InvoicePrintingSetting.IncludeClientPO.GetValueOrDefault(False)
            IncludeAccountExecutive.Value = _InvoicePrintingSetting.IncludeAccountExecutive.GetValueOrDefault(False)
            IncludeSalesClass.Value = _InvoicePrintingSetting.IncludeSalesClass.GetValueOrDefault(False)
            IncludeInvoiceDueDate.Value = _InvoicePrintingSetting.IncludeInvoiceDueDate.GetValueOrDefault(False)
            HideComponentNumberAndDescription.Value = _InvoicePrintingSetting.HideComponentNumberAndDescription.GetValueOrDefault(False)
            ShowBillingHistory.Value = _InvoicePrintingSetting.TotalsShowBillingHistory.GetValueOrDefault(False)
            ShowTaxSeparately.Value = _InvoicePrintingSetting.TotalsShowTaxSeparately.GetValueOrDefault(False)
            ShowCommissionSeparately.Value = _InvoicePrintingSetting.TotalsShowCommissionSeparately.GetValueOrDefault(False)
            IndicateTaxableFunctions.Value = _InvoicePrintingSetting.IndicateTaxableFunctions.GetValueOrDefault(False)
            HideJobInfo.Value = _InvoicePrintingSetting.HideJobInfo
			BillingApprovalClientComment.Value = _InvoicePrintingSetting.IncludeBillingApprovalClientComment.GetValueOrDefault(False)
			JobComment.Value = _InvoicePrintingSetting.IncludeJobComment.GetValueOrDefault(False)
            JobComponentComment.Value = _InvoicePrintingSetting.IncludeJobComponentComment.GetValueOrDefault(False)
            EstimateComment.Value = _InvoicePrintingSetting.IncludeEstimateComment.GetValueOrDefault(False)
            EstimateComponentComment.Value = _InvoicePrintingSetting.IncludeEstimateComponentComment.GetValueOrDefault(False)
            EstimateQuoteComment.Value = _InvoicePrintingSetting.IncludeEstimateQuoteComment.GetValueOrDefault(False)
            EstimateRevisionComment.Value = _InvoicePrintingSetting.IncludeEstimateRevisionComment.GetValueOrDefault(False)
            TaxTotalLocation.Value = _InvoicePrintingSetting.TaxTotalLocation
            ShowCampaign.Value = _InvoicePrintingSetting.ShowCampaign
            ShowCampaignComment.Value = _InvoicePrintingSetting.ShowCampaignComment
            ClientPOLocation.Value = _InvoicePrintingSetting.ClientPOLocation
            ClientRefLocation.Value = _InvoicePrintingSetting.ClientRefLocation
            SalesClassLocation.Value = _InvoicePrintingSetting.SalesClassLocation
            HeaderGroupBy.Value = _InvoicePrintingSetting.HeaderGroupBy
            CampaignLocation.Value = _InvoicePrintingSetting.CampaignLocation
            InvoiceComment.Value = _InvoicePrintingSetting.IncludeBillingComment.GetValueOrDefault(False)

        End Sub
        Private Sub XrSubreportBillingHistory_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportBillingHistory.BeforePrint

            Dim StandardInvoiceDetail As AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail = Nothing
            Dim BillingHistorySubReport As BillingHistorySubReport = Nothing

            If TypeOf XrSubreportBillingHistory.ReportSource Is BillingHistorySubReport AndAlso TypeOf Me.GetCurrentRow Is AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail Then

                BillingHistorySubReport = XrSubreportBillingHistory.ReportSource
                StandardInvoiceDetail = Me.GetCurrentRow

                BillingHistorySubReport.Session = _Session
                BillingHistorySubReport.InvoiceNumber.Value = StandardInvoiceDetail.InvoiceNumber
                BillingHistorySubReport.JobNumber.Value = StandardInvoiceDetail.JobNumber
                BillingHistorySubReport.IsDraft = _IsDraft

                If HideComponentNumberAndDescription.Value = False Then

                    BillingHistorySubReport.ComponentNumber.Value = StandardInvoiceDetail.ComponentNumber

                End If

            End If

        End Sub
        Private Sub XrSubreportInvoiceTaxInformation_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportInvoiceTaxInformation.BeforePrint

            'objects
            Dim TaxInformationSubReport As TaxInformationSubReport = Nothing
            Dim FullInvoiceNumber As String = ""
            Dim TaxAmount As Nullable(Of Decimal) = Nothing
            Dim TaxInformations As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.TaxInformation) = Nothing
            Dim StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing

            If TypeOf XrSubreportInvoiceTaxInformation.ReportSource Is TaxInformationSubReport Then

                TaxInformationSubReport = XrSubreportInvoiceTaxInformation.ReportSource

                FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")
                StandardInvoiceDetails = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber).ToList

                TaxInformations = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.TaxInformation)

                TaxAmount = Nothing
                TaxAmount = StandardInvoiceDetails.Select(Function(Entity) Entity.CityTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.CityTaxLabel, TaxAmount))

                End If

                TaxAmount = Nothing
                TaxAmount = StandardInvoiceDetails.Select(Function(Entity) Entity.CountyTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.CountyTaxLabel, TaxAmount))

                End If

                TaxAmount = Nothing
                TaxAmount = StandardInvoiceDetails.Select(Function(Entity) Entity.StateTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.StateTaxLabel, TaxAmount))

                End If

                TaxInformationSubReport.DataSource = TaxInformations

            End If

        End Sub
        Private Sub XrSubreportJobTaxInformation_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportJobTaxInformation.BeforePrint

            'objects
            Dim TaxInformationSubReport As TaxInformationSubReport = Nothing
            Dim FullInvoiceNumber As String = ""
            Dim JobNumber As Nullable(Of Integer) = Nothing
            Dim ComponentNumber As Nullable(Of Short) = Nothing
            Dim TaxAmount As Nullable(Of Decimal) = Nothing
            Dim TaxInformations As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.TaxInformation) = Nothing
            Dim StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing
            Dim SalesClassCode As String = String.Empty
            Dim CampaignCode As String = String.Empty

            If TypeOf XrSubreportJobTaxInformation.ReportSource Is TaxInformationSubReport Then

                TaxInformationSubReport = XrSubreportJobTaxInformation.ReportSource

                FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")
                JobNumber = Me.GetCurrentColumnValue("JobNumber")
                ComponentNumber = Me.GetCurrentColumnValue("ComponentNumber")

                Try

                    CampaignCode = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail.Properties.CampaignCode.ToString)

                Catch ex As Exception
                    CampaignCode = String.Empty
                End Try

                Try

                    SalesClassCode = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail.Properties.SalesClassCode.ToString)

                Catch ex As Exception
                    SalesClassCode = String.Empty
                End Try

                If _InvoicePrintingSetting IsNot Nothing AndAlso
                        _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Invoice Then

                    StandardInvoiceDetails = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber).ToList

                Else

                    StandardInvoiceDetails = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso Entity.JobNumber = JobNumber AndAlso Entity.ComponentNumber = ComponentNumber).ToList

                End If

                If HeaderGroupBy.Value = 1 Then

                    Try

                        StandardInvoiceDetails = StandardInvoiceDetails.Where(Function(Entity) Entity.CampaignCode = CampaignCode).ToList

                    Catch ex As Exception

                    End Try

                ElseIf HeaderGroupBy.Value = 2 Then

                    Try

                        StandardInvoiceDetails = StandardInvoiceDetails.Where(Function(Entity) Entity.SalesClassCode = SalesClassCode).ToList

                    Catch ex As Exception

                    End Try

                ElseIf HeaderGroupBy.Value = 3 Then

                    Try

                        StandardInvoiceDetails = StandardInvoiceDetails.Where(Function(Entity) Entity.CampaignCode = CampaignCode AndAlso Entity.SalesClassCode = SalesClassCode).ToList

                    Catch ex As Exception

                    End Try

                ElseIf HeaderGroupBy.Value = 4 Then

                    Try

                        StandardInvoiceDetails = StandardInvoiceDetails.Where(Function(Entity) Entity.SalesClassCode = SalesClassCode AndAlso Entity.CampaignCode = CampaignCode).ToList

                    Catch ex As Exception

                    End Try

                End If

                TaxInformations = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.TaxInformation)

                TaxAmount = Nothing
                TaxAmount = StandardInvoiceDetails.Select(Function(Entity) Entity.CityTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.CityTaxLabel, TaxAmount))

                End If

                TaxAmount = Nothing
                TaxAmount = StandardInvoiceDetails.Select(Function(Entity) Entity.CountyTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.CountyTaxLabel, TaxAmount))

                End If

                TaxAmount = Nothing
                TaxAmount = StandardInvoiceDetails.Select(Function(Entity) Entity.StateTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.StateTaxLabel, TaxAmount))

                End If

                TaxInformationSubReport.DataSource = TaxInformations

            End If

        End Sub
        Private Sub Invoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'If XrRichText1.DataBindings IsNot Nothing AndAlso XrRichText1.DataBindings.Count > 0 Then

            'XrRichText1.DataBindings(0).FormatString = "<div style=""font-family:Arial; font-size:9pt;"">{0}</div>"

            'End If

            'If XrRichText2.DataBindings IsNot Nothing AndAlso XrRichText2.DataBindings.Count > 0 Then

            '    XrRichText2.DataBindings(0).FormatString = "<div style=""font-family:Arial; font-size:9pt;"">{0}</div>"

            'End If

            'If XrRichText3.DataBindings IsNot Nothing AndAlso XrRichText3.DataBindings.Count > 0 Then

            '    XrRichText3.DataBindings(0).FormatString = "<div style=""font-family:Arial; font-size:9pt;"">{0}</div>"

            'End If

            'If XrRichText4.DataBindings IsNot Nothing AndAlso XrRichText4.DataBindings.Count > 0 Then

            '    XrRichText4.DataBindings(0).FormatString = "<div style=""font-family:Arial; font-size:9pt;"">{0}</div>"

            'End If

            XrPageInfo.PageInfo = DevExpress.XtraPrinting.PageInfo.NumberOfTotal
            XrPageInfo.Format = "{0} of {1}"

            If _InvoicePrintingSetting IsNot Nothing Then

                If _InvoicePrintingSetting.UseLocationPrintOptions.GetValueOrDefault(False) Then

                    XrLabelLocationHeaderInfo.Text = _InvoicePrintingSetting.PageHeaderComment
                    XrLineHeaderLine.Visible = Not String.IsNullOrWhiteSpace(_InvoicePrintingSetting.PageHeaderComment)

                    XrLabelLocationFooterInfo.Text = _InvoicePrintingSetting.PageFooterComment

                End If

            End If

            If HeaderGroupBy.Value = 1 Then

                GroupHeaderHeaderGroupBy.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))

            ElseIf HeaderGroupBy.Value = 2 Then

                GroupHeaderHeaderGroupBy.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))

            ElseIf HeaderGroupBy.Value = 3 Then

                GroupHeaderHeaderGroupBy.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))
                GroupHeaderHeaderGroupBy.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))

            ElseIf HeaderGroupBy.Value = 4 Then

                GroupHeaderHeaderGroupBy.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("SalesClassCode", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))
                GroupHeaderHeaderGroupBy.GroupFields.Add(New DevExpress.XtraReports.UI.GroupField("CampaignID", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending))

            End If

            If _InvoicePrintingSetting IsNot Nothing Then

                If _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.None Then

                    GroupHeaderJobComponent.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending), New DevExpress.XtraReports.UI.GroupField("ComponentNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})

                ElseIf _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Job Then

                    GroupHeaderJobComponent.GroupFields.AddRange(New DevExpress.XtraReports.UI.GroupField() {New DevExpress.XtraReports.UI.GroupField("JobNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)})
                    GroupHeaderJobComponentComment.Visible = True
					'XrLabelDescriptionData.Visible = False
					'XrLabel2.Visible = False
					'XrLabel1.Visible = True
					'XrLabel3.Visible = False
					GroupFooterJobComponent.Visible = True
                    XrTableRowJobComponent.Visible = False

                ElseIf _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Invoice Then

                    GroupHeaderJobComponent.GroupFields.Clear()
                    GroupHeaderJobComponentComment.Visible = False
					GroupFooterJobComponent.Visible = True
					XrTableRowJobComponent.Visible = False
                    XrTableRowJob.Visible = False

                End If

            End If

        End Sub
        Private Sub Invoice_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim CDPDaysToPay As AdvantageFramework.InvoicePrinting.Classes.CDPDaysToPay = Nothing

            If _InvoicePrintingSetting IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DbContext.Database.Connection.Open()

                    If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

						If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

							_ApplyExchangeRate = 2
							_ExchangeRateAmount = _AccountReceivableInvoice.CurrencyRate.GetValueOrDefault(1)

                            If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencySymbol) = False Then

                                XrTableCellTotalAmount.TextFormatString = _AccountReceivableInvoice.CurrencySymbol & "{0:n2}"
                                XrTableCellDiscountTotalAmount.TextFormatString = _AccountReceivableInvoice.CurrencySymbol & "{0:n2}"
                                XrTableCellDiscountInvoiceTotalAmount.TextFormatString = _AccountReceivableInvoice.CurrencySymbol & "{0:n2}"

                            Else

                                XrTableCellTotalAmount.TextFormatString = "{0:n2}"
                                XrTableCellDiscountTotalAmount.TextFormatString = "{0:n2}"
                                XrTableCellDiscountInvoiceTotalAmount.TextFormatString = "{0:n2}"

                            End If

                        Else

							_ApplyExchangeRate = _InvoicePrintingSetting.ApplyExchangeRate.GetValueOrDefault(1)
							_ExchangeRateAmount = _InvoicePrintingSetting.ExchangeRateAmount.GetValueOrDefault(1)

                            XrTableCellTotalAmount.TextFormatString = "{0:c2}"
                            XrTableCellDiscountTotalAmount.TextFormatString = "{0:c2}"
                            XrTableCellDiscountInvoiceTotalAmount.TextFormatString = "{0:c2}"

                        End If

					Else

						_ApplyExchangeRate = _InvoicePrintingSetting.ApplyExchangeRate.GetValueOrDefault(1)
						_ExchangeRateAmount = _InvoicePrintingSetting.ExchangeRateAmount.GetValueOrDefault(1)

                        XrTableCellTotalAmount.TextFormatString = "{0:c2}"
                        XrTableCellDiscountTotalAmount.TextFormatString = "{0:c2}"
                        XrTableCellDiscountInvoiceTotalAmount.TextFormatString = "{0:c2}"

                    End If

                    _HideExchangeRateMessage = _InvoicePrintingSetting.HideExchangeRateMessage

                    StandardInvoiceDetails = AdvantageFramework.InvoicePrinting.LoadStandardInvoiceDetails(DbContext, _UserCode, _InvoiceNumber, _SequenceNumber, _InvoicePrintingSetting.AddressBlockType, _InvoicePrintingSetting.PrintClientName, _InvoicePrintingSetting.PrintDivisionName,
																										   _InvoicePrintingSetting.PrintProductDescription, _InvoicePrintingSetting.PrintContactAfterAddress, _InvoicePrintingSetting.PrintFunctionType,
																										   _InvoicePrintingSetting.SortFunctionByType, _ApplyExchangeRate, _ExchangeRateAmount,
																										   _InvoicePrintingSetting.TotalsShowTaxSeparately, _InvoicePrintingSetting.TotalsShowCommissionSeparately,
																										   _InvoicePrintingSetting.UseInvoiceCategoryDescription, _InvoicePrintingSetting.InvoiceTitle, _InvoicePrintingSetting.InvoiceFooterCommentType,
																										   _InvoicePrintingSetting.InvoiceFooterComment, _InvoicePrintingSetting.GroupingOptionInsideDescription, _InvoicePrintingSetting.GroupingOptionOutsideDescription,
																										   _InvoicePrintingSetting.ShowCodes, _InvoicePrintingSetting.ContactType, _IsDraft, _AccountReceivableInvoice.Batch, _InvoicePrintingSetting.IncludeEstimateComment,
																										   _InvoicePrintingSetting.IncludeEstimateComponentComment, _InvoicePrintingSetting.IncludeEstimateQuoteComment,
																										   _InvoicePrintingSetting.IncludeEstimateRevisionComment, _InvoicePrintingSetting.IncludeEstimateFunctionComment).ToList

                    If StandardInvoiceDetails IsNot Nothing AndAlso _InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False) = False Then

                        Try

                            StandardInvoiceDetails = StandardInvoiceDetails.Where(Function(Entity) Entity.TotalAmount.GetValueOrDefault(0) <> 0).ToList

                        Catch ex As Exception

                        End Try

                    End If

                    _CDPDaysToPay = DbContext.Products.Include("Client").Where(Function(Entity) Entity.ClientCode = _InvoicePrintingSetting.ClientCode).
                                                                         Select(Function(Entity) New With {.ClientCode = Entity.ClientCode,
                                                                                                           .DivisionCode = Entity.DivisionCode,
                                                                                                           .ProductCode = Entity.Code,
                                                                                                           .ClientDaysToPay = Entity.Client.ProductionDaysToPay,
                                                                                                           .ProductDaysToPay = Entity.ProductionDaysToPay}).ToList.
                                                                         Select(Function(Entity) New AdvantageFramework.InvoicePrinting.Classes.CDPDaysToPay With {.ClientCode = Entity.ClientCode,
                                                                                                                                                                   .DivisionCode = Entity.DivisionCode,
                                                                                                                                                                   .ProductCode = Entity.ProductCode,
                                                                                                                                                                   .ClientDaysToPay = Entity.ClientDaysToPay.GetValueOrDefault(0),
                                                                                                                                                                   .ProductDaysToPay = Entity.ProductDaysToPay}).ToList

                    For Each CDPDaysToPay In _CDPDaysToPay.ToList

                        If StandardInvoiceDetails.Any(Function(Entity) Entity.ClientCode = CDPDaysToPay.ClientCode AndAlso
                                                                       Entity.DivisionCode = CDPDaysToPay.DivisionCode AndAlso
                                                                       Entity.ProductCode = CDPDaysToPay.ProductCode) = False Then

                            _CDPDaysToPay.Remove(CDPDaysToPay)

                        End If

                    Next

                    _CDPDaysToPay = _CDPDaysToPay.OrderBy(Function(Entity) Entity.ClientCode).ThenBy(Function(Entity) Entity.DivisionCode).ThenBy(Function(Entity) Entity.ProductCode).ToList

                    If String.IsNullOrWhiteSpace(_InvoicePrintingSetting.LocationCode) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _InvoicePrintingSetting.LocationCode, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                    Me.DataSource = StandardInvoiceDetails

                End Using

            End If

        End Sub
        Private Sub GroupFooterJobComponentComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterJobComponentComment.BeforePrint

            If _InvoicePrintingSetting Is Nothing Then

                e.Cancel = True

            ElseIf _InvoicePrintingSetting.TotalsShowCommissionSeparately = False Then

                e.Cancel = True

            Else

                If _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.None Then

                    If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber") AndAlso
                                                                                                                                                       Entity.JobNumber = Me.GetCurrentColumnValue("JobNumber") AndAlso
                                                                                                                                                       Entity.ComponentNumber = Me.GetCurrentColumnValue("ComponentNumber")).Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0)) = 0 Then

                        e.Cancel = True

                    End If

                ElseIf _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Job Then

                    If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber") AndAlso
                                                                                                                                                       Entity.JobNumber = Me.GetCurrentColumnValue("JobNumber")).Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0)) = 0 Then

                        e.Cancel = True

                    End If

                ElseIf _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Invoice Then

                    If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")).Sum(Function(Entity) Entity.CommissionAmount.GetValueOrDefault(0)) = 0 Then

                        e.Cancel = True

                    End If

                End If

            End If

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            If _InvoicePrintingSetting IsNot Nothing Then

                If _InvoicePrintingSetting.UseLocationPrintOptions.GetValueOrDefault(False) AndAlso _InvoicePrintingSetting.ShowPageHeaderLogo Then

                    If String.IsNullOrWhiteSpace(_InvoicePrintingSetting.PageHeaderLogoPath) = False Then

                        If My.Computer.FileSystem.FileExists(_InvoicePrintingSetting.PageHeaderLogoPath) Then

                            XrPictureBoxHeaderLogo.ImageUrl = _InvoicePrintingSetting.PageHeaderLogoPath

                        End If

                    ElseIf _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                        Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                            XrPictureBoxHeaderLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub GroupHeaderInvoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderInvoice.BeforePrint

            If _InvoicePrintingSetting IsNot Nothing Then

                XrLabelBillingComment.Visible = _InvoicePrintingSetting.IncludeBillingComment.GetValueOrDefault(False)

            End If

        End Sub
        Private Sub XrLabelExchangeRateNote_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelExchangeRateNote.BeforePrint

            If _ApplyExchangeRate = 2 AndAlso _AccountReceivableInvoice IsNot Nothing AndAlso _HideExchangeRateMessage = False Then

                XrLabelExchangeRateNote.Visible = True

                If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

                    XrLabelExchangeRateNote.Text = "Exchange rate of " & FormatNumber(_ExchangeRateAmount, 4) & " has been applied."

                Else

                    XrLabelExchangeRateNote.Text = "Note: This invoice has been converted using the exchange rate of " & FormatNumber(_ExchangeRateAmount, 4)

                End If

            Else

                XrLabelExchangeRateNote.Text = ""
				XrLabelExchangeRateNote.Visible = False

			End If

		End Sub
        Private Sub XrLabelInvoiceDateData_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelInvoiceDateData.BeforePrint

            XrLabelInvoiceDateData.Text = _InvoiceDate.ToShortDateString

        End Sub
        Private Sub XrLabelInvoiceNumberData_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelInvoiceNumberData.BeforePrint

            'objects
            Dim FullInvoiceNumber As String = ""
            Dim InvoiceNumber As Nullable(Of Integer) = Nothing
            Dim SequenceNumber As Nullable(Of Short) = Nothing

            FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")
            InvoiceNumber = Me.GetCurrentColumnValue("InvoiceNumber")
            SequenceNumber = Me.GetCurrentColumnValue("InvoiceSequenceNumber")

            If SequenceNumber.HasValue AndAlso SequenceNumber.Value > 0 AndAlso SequenceNumber.Value < 99 Then

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
        Private Sub XrLabelBillingComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelBillingComment.BeforePrint

            If _InvoicePrintingSetting IsNot Nothing Then

                If _InvoicePrintingSetting.IncludeBillingComment.GetValueOrDefault(False) Then

                    If Me.PrintingSystem.Document.PageCount <> _PageCount Then

                        _PageCount = PrintingSystem.Document.PageCount

                    End If

                    If _PageCount > 0 Then

                        XrLabelBillingComment.Visible = False
                        e.Cancel = True

                    End If

                Else

                    XrLabelBillingComment.Visible = False
                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub XrRichText1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrRichText1.BeforePrint

            'objects
            Dim Comment As String = ""

            If TypeOf sender Is DevExpress.XtraReports.UI.XRRichText AndAlso _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.None Then

                Comment = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber") AndAlso
                                                                                                                                                          Entity.JobNumber = Me.GetCurrentColumnValue("JobNumber") AndAlso
                                                                                                                                                          Entity.ComponentNumber = Me.GetCurrentColumnValue("ComponentNumber")).Max(Function(Entity) Entity.EstimateComment)

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Html = String.Format("<div style=""font-family:Arial; font-size:9pt;"">{0}</div>", Comment)

            End If

        End Sub
        Private Sub XrRichText2_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrRichText2.BeforePrint

            'objects
            Dim Comment As String = ""

            If TypeOf sender Is DevExpress.XtraReports.UI.XRRichText AndAlso _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.None Then

                Comment = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber") AndAlso
                                                                                                                                                          Entity.JobNumber = Me.GetCurrentColumnValue("JobNumber") AndAlso
                                                                                                                                                          Entity.ComponentNumber = Me.GetCurrentColumnValue("ComponentNumber")).Max(Function(Entity) Entity.EstimateComponentComment)

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Html = String.Format("<div style=""font-family:Arial; font-size:9pt;"">{0}</div>", Comment)

            End If

        End Sub
        Private Sub XrRichText3_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrRichText3.BeforePrint

            'objects
            Dim Comment As String = ""

            If TypeOf sender Is DevExpress.XtraReports.UI.XRRichText AndAlso _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.None Then

                Comment = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber") AndAlso
                                                                                                                                                          Entity.JobNumber = Me.GetCurrentColumnValue("JobNumber") AndAlso
                                                                                                                                                          Entity.ComponentNumber = Me.GetCurrentColumnValue("ComponentNumber")).Max(Function(Entity) Entity.EstimateQuoteComment)

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Html = String.Format("<div style=""font-family:Arial; font-size:9pt;"">{0}</div>", Comment)

            End If

        End Sub
        Private Sub XrRichText4_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrRichText4.BeforePrint

            'objects
            Dim Comment As String = ""

            If TypeOf sender Is DevExpress.XtraReports.UI.XRRichText AndAlso _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.None Then

                Comment = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber") AndAlso
                                                                                                                                                          Entity.JobNumber = Me.GetCurrentColumnValue("JobNumber") AndAlso
                                                                                                                                                          Entity.ComponentNumber = Me.GetCurrentColumnValue("ComponentNumber")).Max(Function(Entity) Entity.EstimateRevisionComment)

                CType(sender, DevExpress.XtraReports.UI.XRRichText).Html = String.Format("<div style=""font-family:Arial; font-size:9pt;"">{0}</div>", Comment)

            End If

        End Sub
        Private Sub XrLabelTotalForJob_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelTotalForJob.BeforePrint

            If _InvoicePrintingSetting IsNot Nothing Then

                If _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.None Then

                    If _InvoicePrintingSetting.HideComponentNumberAndDescription.GetValueOrDefault(False) Then

                        XrLabelTotalForJob.Text = "Total for Job:"

                    Else

                        XrLabelTotalForJob.Text = "Total for Job/Component:"

                    End If

                ElseIf _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Job Then

                    XrLabelTotalForJob.Text = "Total for Job:"

                End If

            End If

        End Sub
        Private Sub XrTableCellClientPO_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableCellClientPO.BeforePrint

            'objects
            Dim StandardInvoiceDetail As AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail = Nothing

            StandardInvoiceDetail = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).OrderBy(Function(Entity) Entity.JobNumber).ThenBy(Function(Entity) Entity.ComponentNumber).FirstOrDefault

            If StandardInvoiceDetail IsNot Nothing Then

                XrTableCellClientPO.Text = StandardInvoiceDetail.ClientPO

            End If

        End Sub
        Private Sub XrTableCellTotalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableCellTotalLabel.BeforePrint

            If _ApplyExchangeRate = 2 AndAlso _AccountReceivableInvoice IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

                    XrTableCellTotalLabel.Text &= " (" & _AccountReceivableInvoice.CurrencyCode & ")"

                End If

            End If

        End Sub
        Private Sub XrTableCellAmountDue_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableCellAmountDue.BeforePrint

            If _ApplyExchangeRate = 2 AndAlso _AccountReceivableInvoice IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

                    XrTableCellAmountDue.Text &= " (" & _AccountReceivableInvoice.CurrencyCode & ")"

                End If

            End If

        End Sub
        Private Sub XrTableCellPaidBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableCellPaidBy.BeforePrint

            'objects
            Dim DueDate As Date = Date.MinValue
            Dim CDPDaysToPay As AdvantageFramework.InvoicePrinting.Classes.CDPDaysToPay = Nothing

            If _AccountReceivableInvoice IsNot Nothing AndAlso _InvoicePrintingSetting IsNot Nothing Then

                If _AccountReceivableInvoice.DueDate.HasValue Then

                    DueDate = _AccountReceivableInvoice.DueDate.Value

                ElseIf _CDPDaysToPay IsNot Nothing AndAlso _CDPDaysToPay.Count > 0 Then

                    CDPDaysToPay = _CDPDaysToPay.FirstOrDefault(Function(Entity) Entity.ClientCode = _AccountReceivableInvoice.ClientCode)

                    If CDPDaysToPay IsNot Nothing AndAlso CDPDaysToPay.ProductDaysToPay > 0 Then

                        DueDate = _AccountReceivableInvoice.InvoiceDate.Value.AddDays(CDPDaysToPay.ProductDaysToPay)

                    ElseIf CDPDaysToPay IsNot Nothing AndAlso CDPDaysToPay.ClientDaysToPay > 0 Then

                        DueDate = _AccountReceivableInvoice.InvoiceDate.Value.AddDays(CDPDaysToPay.ClientDaysToPay)

                    Else

                        DueDate = _AccountReceivableInvoice.InvoiceDate.Value

                    End If

                ElseIf _InvoicePrintingSetting.ClientDaysToPay > 0 Then

                    DueDate = _AccountReceivableInvoice.InvoiceDate.Value.AddDays(_InvoicePrintingSetting.ClientDaysToPay)

                Else

                    DueDate = _AccountReceivableInvoice.InvoiceDate.Value

                End If

                XrTableCellPaidBy.Text = String.Format(XrTableCellPaidBy.Text, DueDate.ToShortDateString)

            End If

        End Sub
        Private Sub XrTableCellPaidByBlank_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrTableCellPaidByBlank.BeforePrint

            'objects
            Dim DueDate As Date = Date.MinValue
            Dim CDPDaysToPay As AdvantageFramework.InvoicePrinting.Classes.CDPDaysToPay = Nothing

            If _AccountReceivableInvoice IsNot Nothing AndAlso _InvoicePrintingSetting IsNot Nothing Then

                If _AccountReceivableInvoice.DueDate.HasValue Then

                    DueDate = _AccountReceivableInvoice.DueDate.Value

                ElseIf _CDPDaysToPay IsNot Nothing AndAlso _CDPDaysToPay.Count > 0 Then

                    CDPDaysToPay = _CDPDaysToPay.FirstOrDefault(Function(Entity) Entity.ClientCode = _AccountReceivableInvoice.ClientCode)

                    If CDPDaysToPay IsNot Nothing AndAlso CDPDaysToPay.ProductDaysToPay > 0 Then

                        DueDate = _AccountReceivableInvoice.InvoiceDate.Value.AddDays(CDPDaysToPay.ProductDaysToPay)

                    ElseIf CDPDaysToPay IsNot Nothing AndAlso CDPDaysToPay.ClientDaysToPay > 0 Then

                        DueDate = _AccountReceivableInvoice.InvoiceDate.Value.AddDays(CDPDaysToPay.ClientDaysToPay)

                    Else

                        DueDate = _AccountReceivableInvoice.InvoiceDate.Value

                    End If

                ElseIf _InvoicePrintingSetting.ClientDaysToPay > 0 Then

                    DueDate = _AccountReceivableInvoice.InvoiceDate.Value.AddDays(_InvoicePrintingSetting.ClientDaysToPay)

                Else

                    DueDate = _AccountReceivableInvoice.InvoiceDate.Value

                End If

                XrTableCellPaidByBlank.Text = String.Format(XrTableCellPaidByBlank.Text, DueDate.ToShortDateString)

            End If

        End Sub
        Private Sub GroupFooterInvoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterInvoice.BeforePrint

            If TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Any(Function(Entity) Entity.DiscountAmount.GetValueOrDefault(0) <> Entity.TotalAmount.GetValueOrDefault(0)) Then

                XrTableRowStandardTotals.Visible = False
                XrTableRowAmountDue.Visible = True
                XrTableRowDates.Visible = True
                XrTableRowTotals.Visible = True

            End If

        End Sub
        Private Sub XrTableCellDiscountTotalAmount_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles XrTableCellDiscountTotalAmount.PrintOnPage

            If _AccountReceivableInvoice IsNot Nothing AndAlso _AccountReceivableInvoice.InvoiceAmount < 0 Then

                XrTableCellDiscountTotalAmount.Text = FormatCurrency(_AccountReceivableInvoice.InvoiceAmount, 2)

            End If

        End Sub

#End Region

    End Class

End Namespace