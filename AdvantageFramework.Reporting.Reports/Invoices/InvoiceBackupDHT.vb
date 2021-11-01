Namespace Invoices

    Public Class InvoiceBackupDHT
        Implements AdvantageFramework.Reporting.Reports.ICustomReport

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
        Private _StandardInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.StandardInvoiceDetail) = Nothing
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
        Private _ApplyExchangeRate As Short = 1
        Private _ExchangeRateAmount As Decimal = 1.0

#End Region

#Region " Properties "

        Public ReadOnly Property BindingSourceControl As Windows.Forms.BindingSource Implements ICustomReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)
                _InvoicePrintingSetting = value
            End Set
        End Property
        Public WriteOnly Property AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice
            Set(value As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)
                _AccountReceivableInvoice = value
            End Set
        End Property
        Public WriteOnly Property InvoiceNumber As Integer
            Set(value As Integer)
                _InvoiceNumber = value
            End Set
        End Property
        Public WriteOnly Property SequenceNumber As Short
            Set(value As Short)
                _SequenceNumber = value
            End Set
        End Property
        Public WriteOnly Property UserCode As String
            Set(value As String)
                _UserCode = value
            End Set
        End Property
        Public WriteOnly Property InvoiceDate As Date
            Set(value As Date)
                _InvoiceDate = value
            End Set
        End Property
        Public WriteOnly Property IsDraft As Boolean
            Set(value As Boolean)
                _IsDraft = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub SetParameterValues()

            IncludeClientReference.Value = _InvoicePrintingSetting.IncludeClientReference.GetValueOrDefault(False)
            IncludeClientPO.Value = _InvoicePrintingSetting.IncludeClientPO.GetValueOrDefault(False)
            IncludeAccountExecutive.Value = _InvoicePrintingSetting.IncludeAccountExecutive.GetValueOrDefault(False)
            IncludeSalesClass.Value = _InvoicePrintingSetting.IncludeSalesClass.GetValueOrDefault(False)
            IncludeInvoiceDueDate.Value = _InvoicePrintingSetting.IncludeInvoiceDueDate.GetValueOrDefault(False)
            HideComponentNumberAndDescription.Value = _InvoicePrintingSetting.HideComponentNumberAndDescription.GetValueOrDefault(False)
            ShowCampaign.Value = _InvoicePrintingSetting.ShowCampaign
            ClientPOLocation.Value = _InvoicePrintingSetting.ClientPOLocation
            ClientRefLocation.Value = _InvoicePrintingSetting.ClientRefLocation
            SalesClassLocation.Value = _InvoicePrintingSetting.SalesClassLocation
            CampaignLocation.Value = _InvoicePrintingSetting.CampaignLocation

        End Sub
        Private Function GetCurrentRowObject() As AdvantageFramework.InvoicePrinting.Classes.InvoiceBackupDetail

            Try

                GetCurrentRowObject = Me.GetCurrentRow

            Catch ex As Exception
                GetCurrentRowObject = Nothing
            End Try

        End Function
        Private Sub Invoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            XrPageInfo.PageInfo = DevExpress.XtraPrinting.PageInfo.NumberOfTotal
            XrPageInfo.Format = "{0} of {1}"

            If _InvoicePrintingSetting IsNot Nothing Then

                If _InvoicePrintingSetting.UseLocationPrintOptions.GetValueOrDefault(False) Then

                    XrLabelLocationHeaderInfo.Text = _InvoicePrintingSetting.PageHeaderComment
                    XrLineHeaderLine.Visible = Not String.IsNullOrWhiteSpace(_InvoicePrintingSetting.PageHeaderComment)

                    XrLabelLocationFooterInfo.Text = _InvoicePrintingSetting.PageFooterComment

                End If

                If _InvoicePrintingSetting.BreakupByJobComponent = False Then

                    GroupFooterJobComponent.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                    GroupFooterJobComponent.HeightF = 36

                End If

            End If

        End Sub
        Private Sub Invoice_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim InvoiceBackupDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoiceBackupDetail) = Nothing

            If _InvoicePrintingSetting IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                        If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

                            _ApplyExchangeRate = 2
                            _ExchangeRateAmount = _AccountReceivableInvoice.CurrencyRate.GetValueOrDefault(1)

                            If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencySymbol) = False Then

                                XrLabelInvoiceTotalData.TextFormatString = _AccountReceivableInvoice.CurrencySymbol & "{0:n2}"

                            Else

                                XrLabelInvoiceTotalData.TextFormatString = "{0:n2}"

                            End If

                        Else

                            _ApplyExchangeRate = _InvoicePrintingSetting.ApplyExchangeRate.GetValueOrDefault(1)
                            _ExchangeRateAmount = _InvoicePrintingSetting.ExchangeRateAmount.GetValueOrDefault(1)

                            XrLabelInvoiceTotalData.TextFormatString = "{0:c2}"

                        End If

                    Else

                        _ApplyExchangeRate = _InvoicePrintingSetting.ApplyExchangeRate.GetValueOrDefault(1)
                        _ExchangeRateAmount = _InvoicePrintingSetting.ExchangeRateAmount.GetValueOrDefault(1)

                        XrLabelInvoiceTotalData.TextFormatString = "{0:c2}"

                    End If

                    _StandardInvoiceDetails = AdvantageFramework.InvoicePrinting.LoadStandardInvoiceDetails(DbContext, _UserCode, _InvoiceNumber, _SequenceNumber, _InvoicePrintingSetting.AddressBlockType, _InvoicePrintingSetting.PrintClientName, _InvoicePrintingSetting.PrintDivisionName,
                                                                                                            _InvoicePrintingSetting.PrintProductDescription, _InvoicePrintingSetting.PrintContactAfterAddress, _InvoicePrintingSetting.PrintFunctionType,
                                                                                                            _InvoicePrintingSetting.SortFunctionByType, _ApplyExchangeRate, _ExchangeRateAmount,
                                                                                                            _InvoicePrintingSetting.TotalsShowTaxSeparately, _InvoicePrintingSetting.TotalsShowCommissionSeparately,
                                                                                                            _InvoicePrintingSetting.UseInvoiceCategoryDescription, _InvoicePrintingSetting.InvoiceTitle, _InvoicePrintingSetting.InvoiceFooterCommentType,
                                                                                                            _InvoicePrintingSetting.InvoiceFooterComment, _InvoicePrintingSetting.GroupingOptionInsideDescription, _InvoicePrintingSetting.GroupingOptionOutsideDescription,
                                                                                                            _InvoicePrintingSetting.ShowCodes, _InvoicePrintingSetting.ContactType, _IsDraft, _AccountReceivableInvoice.Batch, _InvoicePrintingSetting.IncludeEstimateComment,
                                                                                                            _InvoicePrintingSetting.IncludeEstimateComponentComment, _InvoicePrintingSetting.IncludeEstimateQuoteComment,
                                                                                                            _InvoicePrintingSetting.IncludeEstimateRevisionComment, _InvoicePrintingSetting.IncludeEstimateFunctionComment).ToList

                    If _SequenceNumber > 0 AndAlso _IsDraft = False Then

                        InvoiceBackupDetails = AdvantageFramework.InvoicePrinting.LoadInvoiceBackupDetails(DbContext, _InvoiceNumber, 99, _InvoicePrintingSetting.AddressBlockType, _InvoicePrintingSetting.PrintClientName,
                                                                                                           _InvoicePrintingSetting.PrintDivisionName, _InvoicePrintingSetting.PrintProductDescription,
                                                                                                           _InvoicePrintingSetting.PrintContactAfterAddress, _InvoicePrintingSetting.PrintFunctionType,
                                                                                                           _InvoicePrintingSetting.SortFunctionByType, _ApplyExchangeRate, _ExchangeRateAmount,
                                                                                                           _InvoicePrintingSetting.UseInvoiceCategoryDescription, _InvoicePrintingSetting.InvoiceTitle, _InvoicePrintingSetting.ShowCodes,
                                                                                                           _InvoicePrintingSetting.ContactType, _InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False), _IsDraft, _AccountReceivableInvoice.Batch).ToList

                        If _StandardInvoiceDetails IsNot Nothing AndAlso _StandardInvoiceDetails.Count > 0 Then

                            For Each InvoiceBackupDetail In InvoiceBackupDetails

                                InvoiceBackupDetail.Address = _StandardInvoiceDetails(0).Address

                            Next

                        End If

                    Else

                        InvoiceBackupDetails = AdvantageFramework.InvoicePrinting.LoadInvoiceBackupDetails(DbContext, _InvoiceNumber, _SequenceNumber, _InvoicePrintingSetting.AddressBlockType, _InvoicePrintingSetting.PrintClientName,
                                                                                                           _InvoicePrintingSetting.PrintDivisionName, _InvoicePrintingSetting.PrintProductDescription,
                                                                                                           _InvoicePrintingSetting.PrintContactAfterAddress, _InvoicePrintingSetting.PrintFunctionType,
                                                                                                           _InvoicePrintingSetting.SortFunctionByType, _ApplyExchangeRate, _ExchangeRateAmount,
                                                                                                           _InvoicePrintingSetting.UseInvoiceCategoryDescription, _InvoicePrintingSetting.InvoiceTitle, _InvoicePrintingSetting.ShowCodes,
                                                                                                           _InvoicePrintingSetting.ContactType, _InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False), _IsDraft, _AccountReceivableInvoice.Batch).ToList

                    End If

                    If _InvoicePrintingSetting.ShowZeroFunctionAmounts.GetValueOrDefault(False) = False Then

                        For Each IBDGroup In (From Entity In InvoiceBackupDetails.ToList
                                              Group Entity By ClientCode = Entity.ClientCode,
                                                              FullInvoiceNumber = Entity.FullInvoiceNumber,
                                                              JobNumber = Entity.JobNumber,
                                                              ComponentNumber = Entity.ComponentNumber,
                                                              FunctionCode = Entity.FunctionCode Into FGroup = Group).ToList

                            If IBDGroup.FGroup.Sum(Function(Entity) Entity.TotalAmount.GetValueOrDefault(0)) = 0 Then

                                For Each IBD In IBDGroup.FGroup.ToList

                                    InvoiceBackupDetails.Remove(IBD)

                                Next

                            End If

                        Next

                    End If

                    If String.IsNullOrWhiteSpace(_InvoicePrintingSetting.LocationCode) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _InvoicePrintingSetting.LocationCode, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                    Me.DataSource = InvoiceBackupDetails

                End Using

            End If

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            If _InvoicePrintingSetting IsNot Nothing Then

                If _InvoicePrintingSetting.ShowPageHeaderLogo Then

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
        Private Sub XrLabelComment_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelComment.BeforePrint

            'objects
            Dim InvoiceBackupDetail As AdvantageFramework.InvoicePrinting.Classes.InvoiceBackupDetail = Nothing

            If _InvoicePrintingSetting IsNot Nothing Then

                InvoiceBackupDetail = Me.GetCurrentRowObject

                If InvoiceBackupDetail IsNot Nothing Then

                    If InvoiceBackupDetail.Type = "E" Then

                        If _InvoicePrintingSetting.BackupReportCommentOptionEmployeeTimeFunction.GetValueOrDefault(False) = True AndAlso String.IsNullOrWhiteSpace(InvoiceBackupDetail.Comment) = False Then

                            XrLabelComment.Text = InvoiceBackupDetail.Comment

                        Else

                            XrLabelComment.Text = ""

                        End If

                    ElseIf InvoiceBackupDetail.Type = "IO" Then

                        If _InvoicePrintingSetting.BackupReportCommentOptionIncomeOnlyFunction.GetValueOrDefault(False) = True AndAlso String.IsNullOrWhiteSpace(InvoiceBackupDetail.Comment) = False Then

                            XrLabelComment.Text = InvoiceBackupDetail.Comment

                        Else

                            XrLabelComment.Text = ""

                        End If

                    ElseIf InvoiceBackupDetail.Type = "AP" Then

                        If _InvoicePrintingSetting.BackupReportCommentOptionAccountsPayableFunction.GetValueOrDefault(False) = True AndAlso String.IsNullOrWhiteSpace(InvoiceBackupDetail.Comment) = False Then

                            XrLabelComment.Text = InvoiceBackupDetail.Comment

                        Else

                            XrLabelComment.Text = ""

                        End If

                    End If

                End If

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

        End Sub
        Private Sub XrSubreportTaxInformation_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrSubreportTaxInformation.BeforePrint

            'objects
            Dim TaxInformationSubReport As TaxInformationSubReport = Nothing
            Dim FullInvoiceNumber As String = ""
            Dim TaxAmount As Nullable(Of Decimal) = Nothing
            Dim TaxInformations As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.TaxInformation) = Nothing

            If TypeOf XrSubreportTaxInformation.ReportSource Is TaxInformationSubReport Then

                TaxInformationSubReport = XrSubreportTaxInformation.ReportSource

                FullInvoiceNumber = Me.GetCurrentColumnValue("FullInvoiceNumber")

                TaxInformations = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.TaxInformation)

                TaxAmount = Nothing
                TaxAmount = _StandardInvoiceDetails.Select(Function(Entity) Entity.CityTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.CityTaxLabel, TaxAmount))

                End If

                TaxAmount = Nothing
                TaxAmount = _StandardInvoiceDetails.Select(Function(Entity) Entity.CountyTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.CountyTaxLabel, TaxAmount))

                End If

                TaxAmount = Nothing
                TaxAmount = _StandardInvoiceDetails.Select(Function(Entity) Entity.StateTax).Sum

                If TaxAmount.HasValue AndAlso TaxAmount.Value <> 0 Then

                    TaxInformations.Add(New AdvantageFramework.InvoicePrinting.Classes.TaxInformation(FullInvoiceNumber, _InvoicePrintingSetting.StateTaxLabel, TaxAmount))

                End If

                TaxInformationSubReport.DataSource = TaxInformations

            End If

        End Sub
        Private Sub XrLabelInvoiceTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelInvoiceTotal.BeforePrint

            If _ApplyExchangeRate = 2 AndAlso _AccountReceivableInvoice IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

                    XrLabelInvoiceTotal.Text &= " (" & _AccountReceivableInvoice.CurrencyCode & ")"

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace