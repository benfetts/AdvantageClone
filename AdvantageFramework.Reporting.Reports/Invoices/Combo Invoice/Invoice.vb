Namespace Invoices.ComboInvoice

    Public Class Invoice
        Implements AdvantageFramework.Reporting.Reports.ICustomInvoice

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
        Private _InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
        Private _AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
        Private _AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
        Private _InvoiceNumber As Integer = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _UserCode As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _IsDraft As Boolean = False
        Private _PageCount As Integer = -1
        Private _ApplyExchangeRate As Short = 1
        Private _ExchangeRateAmount As Decimal = 1.0
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property InvoiceType As InvoicePrinting.InvoiceTypes Implements ICustomInvoice.InvoiceType
            Get
                InvoiceType = InvoicePrinting.InvoiceTypes.Production
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As Windows.Forms.BindingSource Implements ICustomInvoice.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public Property CustomInvoiceID As Integer Implements ICustomInvoice.CustomInvoiceID
        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting)
                _InvoicePrintingComboSetting = value
            End Set
        End Property
        Public WriteOnly Property InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting)
                _InvoicePrintingSetting = value
            End Set
        End Property
        Public WriteOnly Property AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
                _AgencyInvoicePrintingMediaSetting = value
            End Set
        End Property
        Public WriteOnly Property OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
                _OneTimeInvoicePrintingMediaSetting = value
            End Set
        End Property
        Public WriteOnly Property InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting
            Set(value As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting)
                _InvoicePrintingMediaSetting = value
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
        Public WriteOnly Property ApplyExchangeRate As Short
            Set(value As Short)
                _ApplyExchangeRate = value
            End Set
        End Property
        Public WriteOnly Property ExchangeRateAmount As Decimal
            Set(value As Decimal)
                _ExchangeRateAmount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub SetParameterValues()

            'IncludeClientPO.Value = _InvoicePrintingSetting.IncludeClientPO.GetValueOrDefault(False)
            'IncludeSalesClass.Value = _InvoicePrintingSetting.IncludeSalesClass.GetValueOrDefault(False)
            'IncludeInvoiceDueDate.Value = (_IsDraft = False AndAlso _InvoicePrintingSetting.IncludeInvoiceDueDate.GetValueOrDefault(False) = True)

            IncludeClientPO.Value = False
            IncludeSalesClass.Value = False

            If _InvoicePrintingComboSetting IsNot Nothing Then

                IncludeInvoiceDueDate.Value = _InvoicePrintingComboSetting.IncludeInvoiceDueDate

                If _InvoicePrintingSetting IsNot Nothing Then

                    _InvoicePrintingSetting.ApplyExchangeRate = _InvoicePrintingComboSetting.ApplyExchangeRate
                    _InvoicePrintingSetting.ExchangeRateAmount = _InvoicePrintingComboSetting.ExchangeRateAmount

                End If

                If _InvoicePrintingMediaSetting IsNot Nothing Then

                    _InvoicePrintingMediaSetting.ApplyExchangeRate = _InvoicePrintingComboSetting.ApplyExchangeRate
                    _InvoicePrintingMediaSetting.ExchangeRateAmount = _InvoicePrintingComboSetting.ExchangeRateAmount

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If String.IsNullOrWhiteSpace(_InvoicePrintingComboSetting.LocationCode) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _InvoicePrintingComboSetting.LocationCode, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                End Using

            End If

        End Sub
        Private Function GetCurrentRowObject() As AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail

            'objects
            Dim ComboInvoiceDetail As AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail = Nothing

            Try

                ComboInvoiceDetail = Me.GetCurrentRow()

            Catch ex As Exception
                ComboInvoiceDetail = Nothing
            End Try

            GetCurrentRowObject = ComboInvoiceDetail

        End Function
        Private Sub XrSubreportInvoiceBodies_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrSubreportInvoiceBodies.BeforePrint

            'objects
            Dim ComboInvoiceSubReport As IComboInvoice = Nothing
            Dim MediaType As String = Nothing

            MediaType = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail.Properties.MediaType.ToString)

            If MediaType = "P" Then

                If _InvoicePrintingSetting IsNot Nothing Then

                    If _InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.Production Then

                        ComboInvoiceSubReport = New AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.ComboInvoiceSubReport

                    ElseIf _InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionCurrentTTD Then

                        ComboInvoiceSubReport = New AdvantageFramework.Reporting.Reports.Invoices.CurrentTTD.ComboInvoiceSubReport

                    ElseIf _InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionEstimatePriorCurrentTTD Then

                        ComboInvoiceSubReport = New AdvantageFramework.Reporting.Reports.Invoices.EstimatePriorCurrentTTD.ComboInvoiceSubReport

                    ElseIf _InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionNetCommissionTaxCurrent Then

                        ComboInvoiceSubReport = New AdvantageFramework.Reporting.Reports.Invoices.NetCommissionTaxCurrent.ComboInvoiceSubReport

                    ElseIf _InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionGrandTotal Then

                        ComboInvoiceSubReport = New AdvantageFramework.Reporting.Reports.Invoices.GrandTotal.ComboInvoiceSubReport

                    ElseIf _InvoicePrintingSetting.ReportFormatType.GetValueOrDefault(1) = AdvantageFramework.InvoicePrinting.InvoiceTypes.ProductionEstimateCurrentTTD Then

                        ComboInvoiceSubReport = New AdvantageFramework.Reporting.Reports.Invoices.EstimateCurrentTTD.ComboInvoiceSubReport

                    End If

                Else

                    ComboInvoiceSubReport = New AdvantageFramework.Reporting.Reports.Invoices.StandardInvoice.ComboInvoiceSubReport

                End If

            Else

                ComboInvoiceSubReport = New AdvantageFramework.Reporting.Reports.Invoices.StandardMediaInvoice.ComboInvoiceSubReport

            End If

            If ComboInvoiceSubReport IsNot Nothing Then

                ComboInvoiceSubReport.Session = _Session
                ComboInvoiceSubReport.InvoicePrintingSetting = _InvoicePrintingSetting
                ComboInvoiceSubReport.InvoicePrintingMediaSetting = _InvoicePrintingMediaSetting
                ComboInvoiceSubReport.AgencyInvoicePrintingMediaSetting = _AgencyInvoicePrintingMediaSetting
                ComboInvoiceSubReport.OneTimeInvoicePrintingMediaSetting = _OneTimeInvoicePrintingMediaSetting
                ComboInvoiceSubReport.AccountReceivableInvoice = _AccountReceivableInvoice
                ComboInvoiceSubReport.IsDraft = _IsDraft
                ComboInvoiceSubReport.MediaType = MediaType
                ComboInvoiceSubReport.ApplyExchangeRate = _ApplyExchangeRate
                ComboInvoiceSubReport.ExchangeRateAmount = _ExchangeRateAmount

                ComboInvoiceSubReport.SetParameterValues()

                XrSubreportInvoiceBodies.ReportSource = ComboInvoiceSubReport

            End If

        End Sub
        Private Sub Invoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            XrPageInfo.PageInfo = DevExpress.XtraPrinting.PageInfo.NumberOfTotal
            XrPageInfo.Format = "{0} of {1}"

            If _InvoicePrintingComboSetting IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_InvoicePrintingComboSetting.LocationCode) = False Then

                    XrLabelLocationHeaderInfo.Text = _InvoicePrintingComboSetting.PageHeaderComment
                    XrLineHeaderLine.Visible = Not String.IsNullOrWhiteSpace(_InvoicePrintingComboSetting.PageHeaderComment)

                    XrLabelLocationFooterInfo.Text = _InvoicePrintingComboSetting.PageFooterComment

                End If

            End If

        End Sub
        Private Sub Invoice_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim ComboInvoiceDetails As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail) = Nothing
            Dim MediaTypes As Generic.Dictionary(Of Long, String) = Nothing

            If _InvoicePrintingComboSetting IsNot Nothing AndAlso Me.DataSource Is Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                        If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

                            _ApplyExchangeRate = 2
                            _ExchangeRateAmount = _AccountReceivableInvoice.CurrencyRate.GetValueOrDefault(1)

                            If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencySymbol) = False Then

                                XrLabelGrandTotal.TextFormatString = _AccountReceivableInvoice.CurrencySymbol & "{0:n2}"

                            Else

                                XrLabelGrandTotal.TextFormatString = "{0:n2}"

                            End If

                        Else

                            _ApplyExchangeRate = _InvoicePrintingComboSetting.ApplyExchangeRate.GetValueOrDefault(1)
                            _ExchangeRateAmount = _InvoicePrintingComboSetting.ExchangeRateAmount.GetValueOrDefault(1)

                            XrLabelGrandTotal.TextFormatString = "{0:c2}"

                        End If

                    Else

                        _ApplyExchangeRate = _InvoicePrintingComboSetting.ApplyExchangeRate.GetValueOrDefault(1)
                        _ExchangeRateAmount = _InvoicePrintingComboSetting.ExchangeRateAmount.GetValueOrDefault(1)

                        XrLabelGrandTotal.TextFormatString = "{0:c2}"

                    End If

                    ComboInvoiceDetails = AdvantageFramework.InvoicePrinting.LoadComboInvoiceDetails(DbContext, _UserCode, _InvoiceNumber, _SequenceNumber,
                                                                                                     _InvoicePrintingComboSetting.AddressBlockType, _InvoicePrintingComboSetting.PrintClientName,
                                                                                                     _InvoicePrintingComboSetting.PrintDivisionName, _InvoicePrintingComboSetting.PrintProductDescription,
                                                                                                     _InvoicePrintingComboSetting.PrintContactAfterAddress,
                                                                                                     _ApplyExchangeRate, _ExchangeRateAmount,
                                                                                                     _InvoicePrintingComboSetting.UseInvoiceCategoryDescription,
                                                                                                     _InvoicePrintingComboSetting.InvoiceTitle, _InvoicePrintingComboSetting.InvoiceFooterCommentType,
                                                                                                     _InvoicePrintingComboSetting.InvoiceFooterComment, _InvoicePrintingComboSetting.ShowCodes,
                                                                                                     _InvoicePrintingComboSetting.ContactType, _IsDraft, _AccountReceivableInvoice.Batch).ToList

                    For Each ComboInvoiceDetail In ComboInvoiceDetails

                        ComboInvoiceDetail.SortOrder = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.InvoicePrinting.MediaTypeSortOrder), ComboInvoiceDetail.MediaType)

                    Next

                    If _LocationLogo Is Nothing AndAlso String.IsNullOrWhiteSpace(_InvoicePrintingComboSetting.LocationCode) = False Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _InvoicePrintingComboSetting.LocationCode, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                    Me.DataSource = ComboInvoiceDetails

                End Using

            End If

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            If _InvoicePrintingComboSetting IsNot Nothing Then

                If _InvoicePrintingComboSetting.ShowPageHeaderLogo Then

                    If String.IsNullOrWhiteSpace(_InvoicePrintingComboSetting.PageHeaderLogoPath) = False Then

                        If My.Computer.FileSystem.FileExists(_InvoicePrintingComboSetting.PageHeaderLogoPath) Then

                            XrPictureBoxHeaderLogo.ImageUrl = _InvoicePrintingComboSetting.PageHeaderLogoPath

                        End If

                    ElseIf _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                        Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                            XrPictureBoxHeaderLogo.ImageSource = New DevExpress.XtraPrinting.Drawing.ImageSource(System.Drawing.Image.FromStream(MemoryStream))

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub XrLabelExchangeRateNote_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelExchangeRateNote.BeforePrint

            If _ApplyExchangeRate = 2 AndAlso _AccountReceivableInvoice IsNot Nothing Then

                If CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail)).All(Function(Entity) Entity.MediaType = "P") Then

                    If _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.HideExchangeRateMessage = False Then

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

                ElseIf CType(Me.DataSource, Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail)).All(Function(Entity) Entity.MediaType <> "P") Then

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso _InvoicePrintingMediaSetting.HideExchangeRateMessage = False Then

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

                Else

                    If _InvoicePrintingSetting IsNot Nothing AndAlso _InvoicePrintingSetting.HideExchangeRateMessage = False AndAlso
                            _InvoicePrintingMediaSetting IsNot Nothing AndAlso _InvoicePrintingMediaSetting.HideExchangeRateMessage = False Then

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
        Private Sub XrTableRowClientReference_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowClientReference.BeforePrint

            'objects
            Dim MediaType As String = Nothing
            Dim Cancel As Boolean = True

            MediaType = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail.Properties.MediaType.ToString)

            Select Case MediaType

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.P.ToString

                    If _InvoicePrintingSetting IsNot Nothing Then

                        Cancel = Not (_InvoicePrintingSetting.IncludeClientReference.GetValueOrDefault(False) AndAlso _InvoicePrintingSetting.ClientRefLocation = AdvantageFramework.InvoicePrinting.ClientReferenceLocations.Header)

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.I.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.M.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.N.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.O.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.R.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.T.ToString

                    Cancel = True

            End Select

            e.Cancel = Cancel

        End Sub
        Private Sub XrTableRowClientPO_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowClientPO.BeforePrint

            'objects
            Dim MediaType As String = Nothing
            Dim Cancel As Boolean = True

            MediaType = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail.Properties.MediaType.ToString)

            Select Case MediaType

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.P.ToString

                    If _InvoicePrintingSetting IsNot Nothing AndAlso
                            _InvoicePrintingSetting.IncludeClientPO.GetValueOrDefault(False) AndAlso
                            _InvoicePrintingSetting.ClientPOLocation = AdvantageFramework.InvoicePrinting.ClientPOLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.I.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.InternetShowClientPO.GetValueOrDefault(False) AndAlso
                            _InvoicePrintingMediaSetting.InternetClientPOLocation = AdvantageFramework.InvoicePrinting.ClientPOLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.M.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.MagazineShowClientPO.GetValueOrDefault(False) AndAlso
                            _InvoicePrintingMediaSetting.MagazineClientPOLocation = AdvantageFramework.InvoicePrinting.ClientPOLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.N.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.NewspaperShowClientPO.GetValueOrDefault(False) AndAlso
                            _InvoicePrintingMediaSetting.NewspaperClientPOLocation = AdvantageFramework.InvoicePrinting.ClientPOLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.O.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.OutdoorShowClientPO.GetValueOrDefault(False) AndAlso
                            _InvoicePrintingMediaSetting.OutdoorClientPOLocation = AdvantageFramework.InvoicePrinting.ClientPOLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.R.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.RadioShowClientPO.GetValueOrDefault(False) AndAlso
                            _InvoicePrintingMediaSetting.RadioClientPOLocation = AdvantageFramework.InvoicePrinting.ClientPOLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.T.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.TVShowClientPO.GetValueOrDefault(False) AndAlso
                            _InvoicePrintingMediaSetting.TVClientPOLocation = AdvantageFramework.InvoicePrinting.ClientPOLocations.Header Then

                        Cancel = False

                    End If

            End Select

            e.Cancel = Cancel

        End Sub
        Private Sub XrTableRowAccountExecutive_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowAccountExecutive.BeforePrint

            'objects
            Dim MediaType As String = Nothing
            Dim Cancel As Boolean = True

            MediaType = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail.Properties.MediaType.ToString)

            Select Case MediaType

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.P.ToString

                    If _InvoicePrintingSetting IsNot Nothing Then

                        Cancel = Not _InvoicePrintingSetting.IncludeAccountExecutive.GetValueOrDefault(False)

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.I.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.M.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.N.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.O.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.R.ToString

                    Cancel = True

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.T.ToString

                    Cancel = True

            End Select

            e.Cancel = Cancel

        End Sub
        Private Sub XrTableRowSalesClass_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowSalesClass.BeforePrint

            'objects
            Dim MediaType As String = Nothing
            Dim Cancel As Boolean = True

            MediaType = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail.Properties.MediaType.ToString)

            Select Case MediaType

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.P.ToString

                    If _InvoicePrintingSetting IsNot Nothing AndAlso
                            _InvoicePrintingSetting.IncludeSalesClass.GetValueOrDefault(False) AndAlso
                            _InvoicePrintingSetting.SalesClassLocation = AdvantageFramework.InvoicePrinting.SalesClassLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.I.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.InternetShowSalesClass AndAlso
                            _InvoicePrintingMediaSetting.InternetSalesClassLocation = AdvantageFramework.InvoicePrinting.SalesClassLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.M.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.MagazineShowSalesClass AndAlso
                            _InvoicePrintingMediaSetting.MagazineSalesClassLocation = AdvantageFramework.InvoicePrinting.SalesClassLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.N.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.NewspaperShowSalesClass AndAlso
                            _InvoicePrintingMediaSetting.NewspaperSalesClassLocation = AdvantageFramework.InvoicePrinting.SalesClassLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.O.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.OutdoorShowSalesClass AndAlso
                            _InvoicePrintingMediaSetting.OutdoorSalesClassLocation = AdvantageFramework.InvoicePrinting.SalesClassLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.R.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.RadioShowSalesClass AndAlso
                            _InvoicePrintingMediaSetting.RadioSalesClassLocation = AdvantageFramework.InvoicePrinting.SalesClassLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.T.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.TVShowSalesClass AndAlso
                            _InvoicePrintingMediaSetting.TVSalesClassLocation = AdvantageFramework.InvoicePrinting.SalesClassLocations.Header Then

                        Cancel = False

                    End If

            End Select

            e.Cancel = Cancel

        End Sub
        Private Sub XrTableRowCampaign_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowCampaign.BeforePrint

            'objects
            Dim MediaType As String = Nothing
            Dim Cancel As Boolean = True

            MediaType = Me.GetCurrentColumnValue(AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail.Properties.MediaType.ToString)

            Select Case MediaType

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.P.ToString

                    If _InvoicePrintingSetting IsNot Nothing AndAlso
                            _InvoicePrintingSetting.ShowCampaign AndAlso
                            _InvoicePrintingSetting.CampaignLocation = AdvantageFramework.InvoicePrinting.CampaignLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.I.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.InternetShowCampaign AndAlso
                            _InvoicePrintingMediaSetting.InternetCampaignLocation = AdvantageFramework.InvoicePrinting.CampaignLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.M.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.MagazineShowCampaign AndAlso
                            _InvoicePrintingMediaSetting.MagazineCampaignLocation = AdvantageFramework.InvoicePrinting.CampaignLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.N.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.NewspaperShowCampaign AndAlso
                            _InvoicePrintingMediaSetting.NewspaperCampaignLocation = AdvantageFramework.InvoicePrinting.CampaignLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.O.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.OutdoorShowCampaign AndAlso
                            _InvoicePrintingMediaSetting.OutdoorCampaignLocation = AdvantageFramework.InvoicePrinting.CampaignLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.R.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.RadioShowCampaign AndAlso
                            _InvoicePrintingMediaSetting.RadioCampaignLocation = AdvantageFramework.InvoicePrinting.CampaignLocations.Header Then

                        Cancel = False

                    End If

                Case AdvantageFramework.InvoicePrinting.MediaTypeSortOrder.T.ToString

                    If _InvoicePrintingMediaSetting IsNot Nothing AndAlso
                            _InvoicePrintingMediaSetting.TVShowCampaign AndAlso
                            _InvoicePrintingMediaSetting.TVCampaignLocation = AdvantageFramework.InvoicePrinting.CampaignLocations.Header Then

                        Cancel = False

                    End If

            End Select

            e.Cancel = Cancel

        End Sub
        Private Sub XrLabelTotal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrLabelTotal.BeforePrint

            If _ApplyExchangeRate = 2 AndAlso _AccountReceivableInvoice IsNot Nothing Then

                If String.IsNullOrWhiteSpace(_AccountReceivableInvoice.CurrencyCode) = False Then

                    XrLabelTotal.Text &= " (" & _AccountReceivableInvoice.CurrencyCode & ")"

                End If

            End If

        End Sub
        Private Sub XrTableCellClientPO_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableCellClientPO.BeforePrint

            'objects
            Dim ComboInvoiceDetail As AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail = Nothing

            ComboInvoiceDetail = TryCast(Me.DataSource, IEnumerable(Of AdvantageFramework.InvoicePrinting.Classes.ComboInvoiceDetail)).FirstOrDefault

            If ComboInvoiceDetail IsNot Nothing Then

                XrTableCellClientPO.Text = ComboInvoiceDetail.ClientPO

            End If

        End Sub

#End Region

    End Class

End Namespace
