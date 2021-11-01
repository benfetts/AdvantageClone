Namespace Invoices.NetCommissionTaxCurrent

    Public Class ComboInvoiceSubReport
        Implements IComboInvoice

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Private _InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
        Private _IsDraft As Boolean = False
        Private _MediaType As String = ""
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

            ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
            ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)
            IncludeClientReference.Value = _InvoicePrintingSetting.IncludeClientReference.GetValueOrDefault(False)
            IncludeClientPO.Value = _InvoicePrintingSetting.IncludeClientPO.GetValueOrDefault(False)
            IncludeAccountExecutive.Value = _InvoicePrintingSetting.IncludeAccountExecutive.GetValueOrDefault(False)
            IncludeSalesClass.Value = _InvoicePrintingSetting.IncludeSalesClass.GetValueOrDefault(False)
            IncludeInvoiceDueDate.Value = (_IsDraft = False AndAlso _InvoicePrintingSetting.IncludeInvoiceDueDate.GetValueOrDefault(False) = True)
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
            ShowCampaign.Value = _InvoicePrintingSetting.ShowCampaign
            ShowCampaignComment.Value = _InvoicePrintingSetting.ShowCampaignComment
            ClientPOLocation.Value = _InvoicePrintingSetting.ClientPOLocation
            ClientRefLocation.Value = _InvoicePrintingSetting.ClientRefLocation
            SalesClassLocation.Value = _InvoicePrintingSetting.SalesClassLocation
            CampaignLocation.Value = _InvoicePrintingSetting.CampaignLocation
            HeaderGroupBy.Value = _InvoicePrintingSetting.HeaderGroupBy
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
                    XrTableRowBillingApprovalClientComment.Visible = False
                    XrTableRowBillingJobComment.Visible = False
                    XrTableRowJobComment.Visible = True
                    XrTableRowJobComponentComment.Visible = False
                    XrTableRowJobCampaignComment.Visible = False
                    GroupFooterJobComponent.Visible = True
                    XrTableRowJobComponent.Visible = False

                ElseIf _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Invoice Then

                    GroupHeaderJobComponent.GroupFields.Clear()
                    GroupHeaderJobComponentComment.Visible = False
                    GroupFooterJobComponent.Visible = False
                    XrTableRowJobComponent.Visible = False
                    XrTableRowJob.Visible = False

                End If

            End If

        End Sub
        Private Sub Invoice_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing

            If _InvoicePrintingSetting IsNot Nothing AndAlso _AccountReceivableInvoice IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

					StandardInvoiceDetails = AdvantageFramework.InvoicePrinting.LoadStandardInvoiceDetails(DbContext, _Session.UserCode, _AccountReceivableInvoice.InvoiceNumber, _AccountReceivableInvoice.InvoiceSequenceNumber, _InvoicePrintingSetting.AddressBlockType, _InvoicePrintingSetting.PrintClientName, _InvoicePrintingSetting.PrintDivisionName,
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

					Me.DataSource = StandardInvoiceDetails

                End Using

            End If

        End Sub
        Private Sub GroupHeaderFunction_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderFunction.BeforePrint

            'objects
            Dim GroupByFunctionSubReport As GroupByFunctionSubReport = Nothing
            Dim GroupByFunctionTypeFunctionSubReport As GroupByFunctionTypeFunctionSubReport = Nothing
            Dim GroupByFunctionHeadingFunctionSubReport As GroupByFunctionHeadingFunctionSubReport = Nothing
            Dim GroupByFunctionTypeSubReport As GroupByFunctionTypeSubReport = Nothing
            Dim GroupByFunctionHeadingSubReport As GroupByFunctionHeadingSubReport = Nothing
            Dim GroupByInsideOutsideFunctionSubReport As GroupByInsideOutsideFunctionSubReport = Nothing
            Dim GroupByInsideOutsideSubReport As GroupByInsideOutsideSubReport = Nothing
            Dim StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing
            Dim FullInvoiceNumber As String = Nothing
            Dim JobNumber As Nullable(Of Integer) = Nothing
            Dim ComponentNumber As Nullable(Of Short) = Nothing

            If _InvoicePrintingSetting IsNot Nothing Then

                Try

                    FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")

                Catch ex As Exception
                    FullInvoiceNumber = ""
                End Try

                Try

                    JobNumber = Me.GetCurrentColumnValue("JobNumber")

                Catch ex As Exception
                    JobNumber = Nothing
                End Try

                Try

                    ComponentNumber = Me.GetCurrentColumnValue("ComponentNumber")

                Catch ex As Exception
                    ComponentNumber = Nothing
                End Try

                Try

                    If _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.None Then

                        StandardInvoiceDetails = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                                 Entity.JobNumber = JobNumber AndAlso
                                                                                                                                                                                 Entity.ComponentNumber = ComponentNumber).ToList

                    ElseIf _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Job Then

                        StandardInvoiceDetails = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso
                                                                                                                                                                                 Entity.JobNumber = JobNumber).ToList

                    ElseIf _InvoicePrintingSetting.SummaryLevel = AdvantageFramework.InvoicePrinting.SummaryLevels.Invoice Then

                        StandardInvoiceDetails = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber).ToList

                    End If

                Catch ex As Exception
                    StandardInvoiceDetails = Nothing
                End Try

                If StandardInvoiceDetails IsNot Nothing Then

                    If StandardInvoiceDetails.Count > 0 Then

                        If _InvoicePrintingSetting.GroupingOptionType.GetValueOrDefault(1) = 1 Then

                            GroupByFunctionSubReport = New GroupByFunctionSubReport
                            GroupByFunctionSubReport.DataSource = StandardInvoiceDetails

                            GroupByFunctionSubReport.ShowFunctionDetail.Value = _InvoicePrintingSetting.ShowFunctionDetail.GetValueOrDefault(False)
                            GroupByFunctionSubReport.HideFunctionTotals.Value = _InvoicePrintingSetting.HideFunctionTotals.GetValueOrDefault(False)
                            GroupByFunctionSubReport.ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
                            GroupByFunctionSubReport.ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)

                            GroupByFunctionSubReport.Session = _Session
                            GroupByFunctionSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                            GroupByFunctionSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                            GroupByFunctionSubReport.IsDraft = _IsDraft
                            GroupByFunctionSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                            XrSubreportData.ReportSource = GroupByFunctionSubReport

                        ElseIf _InvoicePrintingSetting.GroupingOptionType.GetValueOrDefault(1) = 7 Then

                            GroupByFunctionTypeFunctionSubReport = New GroupByFunctionTypeFunctionSubReport
                            GroupByFunctionTypeFunctionSubReport.DataSource = StandardInvoiceDetails

                            GroupByFunctionTypeFunctionSubReport.ShowFunctionDetail.Value = _InvoicePrintingSetting.ShowFunctionDetail.GetValueOrDefault(False)
                            GroupByFunctionTypeFunctionSubReport.HideFunctionTotals.Value = _InvoicePrintingSetting.HideFunctionTotals.GetValueOrDefault(False)
                            GroupByFunctionTypeFunctionSubReport.ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
                            GroupByFunctionTypeFunctionSubReport.ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)

                            GroupByFunctionTypeFunctionSubReport.Session = _Session
                            GroupByFunctionTypeFunctionSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                            GroupByFunctionTypeFunctionSubReport.IsDraft = _IsDraft
                            GroupByFunctionTypeFunctionSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                            XrSubreportData.ReportSource = GroupByFunctionTypeFunctionSubReport

                        ElseIf _InvoicePrintingSetting.GroupingOptionType.GetValueOrDefault(1) = 2 Then

                            GroupByFunctionHeadingFunctionSubReport = New GroupByFunctionHeadingFunctionSubReport
                            GroupByFunctionHeadingFunctionSubReport.DataSource = StandardInvoiceDetails

                            GroupByFunctionHeadingFunctionSubReport.ShowFunctionDetail.Value = _InvoicePrintingSetting.ShowFunctionDetail.GetValueOrDefault(False)
                            GroupByFunctionHeadingFunctionSubReport.HideFunctionTotals.Value = _InvoicePrintingSetting.HideFunctionTotals.GetValueOrDefault(False)
                            GroupByFunctionHeadingFunctionSubReport.ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
                            GroupByFunctionHeadingFunctionSubReport.ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)

                            GroupByFunctionHeadingFunctionSubReport.Session = _Session
                            GroupByFunctionHeadingFunctionSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                            GroupByFunctionHeadingFunctionSubReport.IsDraft = _IsDraft
                            GroupByFunctionHeadingFunctionSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                            XrSubreportData.ReportSource = GroupByFunctionHeadingFunctionSubReport

                        ElseIf _InvoicePrintingSetting.GroupingOptionType.GetValueOrDefault(1) = 8 Then

                            GroupByFunctionTypeSubReport = New GroupByFunctionTypeSubReport
                            GroupByFunctionTypeSubReport.DataSource = StandardInvoiceDetails

                            GroupByFunctionTypeSubReport.ShowFunctionDetail.Value = _InvoicePrintingSetting.ShowFunctionDetail.GetValueOrDefault(False)
                            GroupByFunctionTypeSubReport.HideFunctionTotals.Value = _InvoicePrintingSetting.HideFunctionTotals.GetValueOrDefault(False)
                            GroupByFunctionTypeSubReport.ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
                            GroupByFunctionTypeSubReport.ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)

                            GroupByFunctionTypeSubReport.Session = _Session
                            GroupByFunctionTypeSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                            GroupByFunctionTypeSubReport.IsDraft = _IsDraft
                            GroupByFunctionTypeSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                            XrSubreportData.ReportSource = GroupByFunctionTypeSubReport

                        ElseIf _InvoicePrintingSetting.GroupingOptionType.GetValueOrDefault(1) = 5 Then

                            GroupByFunctionHeadingSubReport = New GroupByFunctionHeadingSubReport
                            GroupByFunctionHeadingSubReport.DataSource = StandardInvoiceDetails

                            GroupByFunctionHeadingSubReport.ShowFunctionDetail.Value = _InvoicePrintingSetting.ShowFunctionDetail.GetValueOrDefault(False)
                            GroupByFunctionHeadingSubReport.HideFunctionTotals.Value = _InvoicePrintingSetting.HideFunctionTotals.GetValueOrDefault(False)
                            GroupByFunctionHeadingSubReport.ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
                            GroupByFunctionHeadingSubReport.ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)

                            GroupByFunctionHeadingSubReport.Session = _Session
                            GroupByFunctionHeadingSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                            GroupByFunctionHeadingSubReport.IsDraft = _IsDraft
                            GroupByFunctionHeadingSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                            XrSubreportData.ReportSource = GroupByFunctionHeadingSubReport

                        ElseIf _InvoicePrintingSetting.GroupingOptionType.GetValueOrDefault(1) = 6 Then

                            GroupByInsideOutsideSubReport = New GroupByInsideOutsideSubReport
                            GroupByInsideOutsideSubReport.DataSource = StandardInvoiceDetails

                            GroupByInsideOutsideSubReport.ShowFunctionDetail.Value = _InvoicePrintingSetting.ShowFunctionDetail.GetValueOrDefault(False)
                            GroupByInsideOutsideSubReport.HideFunctionTotals.Value = _InvoicePrintingSetting.HideFunctionTotals.GetValueOrDefault(False)
                            GroupByInsideOutsideSubReport.ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
                            GroupByInsideOutsideSubReport.ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)

                            GroupByInsideOutsideSubReport.Session = _Session
                            GroupByInsideOutsideSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                            GroupByInsideOutsideSubReport.IsDraft = _IsDraft
                            GroupByInsideOutsideSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                            XrSubreportData.ReportSource = GroupByInsideOutsideSubReport

                        ElseIf _InvoicePrintingSetting.GroupingOptionType.GetValueOrDefault(1) = 3 Then

                            GroupByInsideOutsideFunctionSubReport = New GroupByInsideOutsideFunctionSubReport
                            GroupByInsideOutsideFunctionSubReport.DataSource = StandardInvoiceDetails

                            GroupByInsideOutsideFunctionSubReport.ShowFunctionDetail.Value = _InvoicePrintingSetting.ShowFunctionDetail.GetValueOrDefault(False)
                            GroupByInsideOutsideFunctionSubReport.HideFunctionTotals.Value = _InvoicePrintingSetting.HideFunctionTotals.GetValueOrDefault(False)
                            GroupByInsideOutsideFunctionSubReport.ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
                            GroupByInsideOutsideFunctionSubReport.ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)

                            GroupByInsideOutsideFunctionSubReport.Session = _Session
                            GroupByInsideOutsideFunctionSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                            GroupByInsideOutsideFunctionSubReport.IsDraft = _IsDraft
                            GroupByInsideOutsideFunctionSubReport.InvoicePrintingSetting = _InvoicePrintingSetting

                            XrSubreportData.ReportSource = GroupByInsideOutsideFunctionSubReport

                        End If

                    End If

                End If

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
        Private Sub GroupHeaderJobComponentComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderJobComponentComment.BeforePrint

            'If _InvoicePrintingSetting IsNot Nothing Then

            '    XrLabelJobComment.Visible = _InvoicePrintingSetting.IncludeJobComment.GetValueOrDefault(False)
            '    XrLabelBillingApprovalClientComment.Visible = _InvoicePrintingSetting.IncludeBillingApprovalClientComment.GetValueOrDefault(False)
            '    XrLabelJobComponentComment.Visible = _InvoicePrintingSetting.IncludeJobComponentComment.GetValueOrDefault(False)
            '    XrLabelNetComment.Visible = _InvoicePrintingSetting.IncludeEstimateComment.GetValueOrDefault(False)
            '    XrLabelNetComponentComment.Visible = _InvoicePrintingSetting.IncludeEstimateComponentComment.GetValueOrDefault(False)
            '    XrLabelNetQuoteComment.Visible = _InvoicePrintingSetting.IncludeEstimateQuoteComment.GetValueOrDefault(False)
            '    XrLabelNetRevisionComment.Visible = _InvoicePrintingSetting.IncludeEstimateRevisionComment.GetValueOrDefault(False)

            'End If

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

#End Region

    End Class

End Namespace