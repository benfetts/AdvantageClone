Namespace Invoices.GrandTotal

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

            If TypeOf XrSubreportJobTaxInformation.ReportSource Is TaxInformationSubReport Then

                TaxInformationSubReport = XrSubreportJobTaxInformation.ReportSource

                FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")
                JobNumber = Me.GetCurrentColumnValue("JobNumber")
                ComponentNumber = Me.GetCurrentColumnValue("ComponentNumber")
                StandardInvoiceDetails = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail)).Where(Function(Entity) Entity.FullInvoiceNumber = FullInvoiceNumber AndAlso Entity.JobNumber = JobNumber AndAlso Entity.ComponentNumber = ComponentNumber).ToList

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
                    'XrLabel3.Visible = False
                    'XrLabel1.Visible = True
                    'XrLabel4.Visible = False
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
        Private Sub GroupHeaderJobComponentComment_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderJobComponentComment.BeforePrint

            'If _InvoicePrintingSetting IsNot Nothing Then

            '    XrLabelJobComment.Visible = _InvoicePrintingSetting.IncludeJobComment.GetValueOrDefault(False)
            '    XrLabelBillingApprovalClientComment.Visible = _InvoicePrintingSetting.IncludeBillingApprovalClientComment.GetValueOrDefault(False)
            '    XrLabelJobComponentComment.Visible = _InvoicePrintingSetting.IncludeJobComponentComment.GetValueOrDefault(False)
            '    XrLabelEstimateComment.Visible = _InvoicePrintingSetting.IncludeEstimateComment.GetValueOrDefault(False)
            '    XrLabelEstimateComponentComment.Visible = _InvoicePrintingSetting.IncludeEstimateComponentComment.GetValueOrDefault(False)
            '    XrLabelEstimateQuoteComment.Visible = _InvoicePrintingSetting.IncludeEstimateQuoteComment.GetValueOrDefault(False)
            '    XrLabelEstimateRevisionComment.Visible = _InvoicePrintingSetting.IncludeEstimateRevisionComment.GetValueOrDefault(False)

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