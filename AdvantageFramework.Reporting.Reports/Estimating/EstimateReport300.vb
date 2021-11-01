Namespace Estimating

    Public Class EstimateReport300
        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IEstimateReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _UserCode As String = ""
        Private _DefaultLocation As AdvantageFramework.Database.Entities.Location = Nothing
        Private _FooterAboveSignature As Boolean = False
        Private _UsePrintedDate As Date = Nothing
        Private _EstimateReportID As Integer = 0
        Private _UserDefinedReportID As Integer = 0
        Private _EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting = Nothing
        Private _EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting = Nothing
        Private _EstimateNumber As Integer = 0
        Private _EstimateComponentNumber As Integer = 0
        Private _EstimateQuoteNumber As Integer = 0
        Private _EstimateQuoteNumbers As String = ""
        Private _EstimateCompNumbers As String = ""
        Private _ClientCode As String = ""
        Private _DivisionCode As String = ""
        Private _ProductCode As String = ""
        Private _DefaultFooter As String = ""
        Private _DefaultFooterType As String = ""
        Private _ErrorString As String = ""
        Private _EstimatePrint As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail = Nothing
        Private _CultureCode As String = "en-US"
        Private _Combine As Integer = 0
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public WriteOnly Property UserCode As String
            Set(value As String)
                _UserCode = value
            End Set
        End Property
        Public WriteOnly Property ClientCode As String
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        Public WriteOnly Property DivisionCode As String
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        Public WriteOnly Property ProductCode As String
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        Public WriteOnly Property DefaultFooter As String
            Set(value As String)
                _DefaultFooter = value
            End Set
        End Property
        Public WriteOnly Property DefaultFooterType As String
            Set(value As String)
                _DefaultFooterType = value
            End Set
        End Property
        Public WriteOnly Property DefaultLocation As AdvantageFramework.Database.Entities.Location
            Set(value As AdvantageFramework.Database.Entities.Location)
                _DefaultLocation = value
            End Set
        End Property
        Public WriteOnly Property FooterAboveSignature As Boolean
            Set(value As Boolean)
                _FooterAboveSignature = value
            End Set
        End Property
        Public WriteOnly Property UsePrintedDate As Date
            Set(value As Date)
                _UsePrintedDate = value
            End Set
        End Property
        Public WriteOnly Property EstimatePrintingSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting
            Set(value As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintingSetting)
                _EstimatePrintingSetting = value
            End Set
        End Property
        Public WriteOnly Property EstimatePrintSetting As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting
            Set(value As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting)
                _EstimatePrintSetting = value
            End Set
        End Property
        Public WriteOnly Property EstimateNumber As Integer
            Set(value As Integer)
                _EstimateNumber = value
            End Set
        End Property
        Public WriteOnly Property EstimateComponentNumber As Integer
            Set(value As Integer)
                _EstimateComponentNumber = value
            End Set
        End Property
        Public WriteOnly Property EstimateQuoteNumber As Integer
            Set(value As Integer)
                _EstimateQuoteNumber = value
            End Set
        End Property
        Public WriteOnly Property EstimateQuoteNumbers As String
            Set(value As String)
                _EstimateQuoteNumbers = value
            End Set
        End Property
        Public WriteOnly Property EstimateCompNumbers As String
            Set(value As String)
                _EstimateCompNumbers = value
            End Set
        End Property
        Public ReadOnly Property EstimateReport As AdvantageFramework.Reporting.EstimateReportTypes Implements IEstimateReport.EstimateReport
            Get
                EstimateReport = AdvantageFramework.Reporting.EstimateReportTypes.OneQuotePerPage
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As Windows.Forms.BindingSource Implements IEstimateReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public Property EstimateReportID As Integer Implements IEstimateReport.EstimateReportID
            Get
                EstimateReportID = _EstimateReportID
            End Get
            Set(value As Integer)
                _EstimateReportID = value
            End Set
        End Property
        'Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
        '    Get
        '        AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.OneQuotePerPage
        '    End Get
        'End Property
        'Public ReadOnly Property BindingSourceControl As Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
        '    Get
        '        BindingSourceControl = BindingSource
        '    End Get
        'End Property
        'Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
        '    Get
        '        UserDefinedReportID = _UserDefinedReportID
        '    End Get
        '    Set(value As Integer)
        '        _UserDefinedReportID = value
        '    End Set
        'End Property
        Public WriteOnly Property CultureCode As String
            Set(value As String)
                _CultureCode = value
            End Set
        End Property
        Public WriteOnly Property Combine As Integer
            Set(value As Integer)
                _Combine = value
            End Set
        End Property
#End Region

#Region " Methods "

        Public Sub SetParameterValues()

            'ShowQuantity.Value = _InvoicePrintingSetting.ShowQuantity.GetValueOrDefault(False)
            'ShowEmployeeHours.Value = _InvoicePrintingSetting.ShowEmployeeHours.GetValueOrDefault(False)
            'IncludeClientReference.Value = _InvoicePrintingSetting.IncludeClientReference.GetValueOrDefault(False)
            'IncludeClientPO.Value = _InvoicePrintingSetting.IncludeClientPO.GetValueOrDefault(False)
            'IncludeAccountExecutive.Value = _InvoicePrintingSetting.IncludeAccountExecutive.GetValueOrDefault(False)
            'IncludeSalesClass.Value = _InvoicePrintingSetting.IncludeSalesClass.GetValueOrDefault(False)
            'IncludeInvoiceDueDate.Value = _InvoicePrintingSetting.IncludeInvoiceDueDate.GetValueOrDefault(False)
            'HideComponentNumberAndDescription.Value = _InvoicePrintingSetting.HideComponentNumberAndDescription.GetValueOrDefault(False)
            'ShowBillingHistory.Value = _InvoicePrintingSetting.TotalsShowBillingHistory.GetValueOrDefault(False)
            'ShowTaxSeparately.Value = _InvoicePrintingSetting.TotalsShowTaxSeparately.GetValueOrDefault(False)
            'ShowCommissionSeparately.Value = _InvoicePrintingSetting.TotalsShowCommissionSeparately.GetValueOrDefault(False)
            'IndicateTaxableFunctions.Value = _InvoicePrintingSetting.IndicateTaxableFunctions.GetValueOrDefault(False)

        End Sub
        Private Function LoadCurrentEstimatePrint() As AdvantageFramework.Database.Classes.EstimatePrintDetail

            'objects
            Dim EstimatePrint As AdvantageFramework.Database.Classes.EstimatePrintDetail = Nothing

            Try

                EstimatePrint = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Classes.EstimatePrintDetail)

            Catch ex As Exception
                EstimatePrint = Nothing
            Finally
                LoadCurrentEstimatePrint = EstimatePrint
            End Try

        End Function
        Private Sub BuildLocationString(ByVal FieldValue As String, ByVal PrintField As Boolean, ByVal List As Generic.List(Of String))

            Try

                If PrintField Then

                    If String.IsNullOrEmpty(FieldValue) = False Then

                        List.Add(FieldValue)

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Function LoadFooterComments(ByRef FontSize As Short) As String

            'objects
            Dim FooterComments As String = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim StandardComment As AdvantageFramework.Database.Entities.StandardComment = Nothing

            Try

                'PurchaseOrder = LoadCurrentPurchaseOrder()

                If PurchaseOrder IsNot Nothing Then

                    If String.IsNullOrEmpty(PurchaseOrder.Footer) = False Then

                        FooterComments = PurchaseOrder.Footer

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            StandardComment = AdvantageFramework.Database.Procedures.StandardComment.LoadByVendorCodeAndApplicationCode(DbContext, PurchaseOrder.VendorCode, AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Database.Entities.StandardCommentApplications.PurchaseOrder).Code)

                            If StandardComment IsNot Nothing Then

                                FooterComments = StandardComment.Comment
                                FontSize = StandardComment.FontSize

                            Else

                                FooterComments = AdvantageFramework.Database.Procedures.Agency.Load(DbContext).POFooterComments

                            End If

                        End Using

                    End If

                End If

            Catch ex As Exception
                FooterComments = ""
            Finally
                LoadFooterComments = FooterComments
            End Try

        End Function
        Public Sub SetCulture(ByVal [Report] As AdvantageFramework.Reporting.Reports.Estimating.EstimateReport300, Optional ByVal CultureCode As String = "en-US")
            Try
                Dim ci As New System.Globalization.CultureInfo(CultureCode)
                Threading.Thread.CurrentThread.CurrentCulture = ci
            Catch ex As Exception
            End Try
        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub EstimateReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'objects
            'Dim EstimatePrint As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail = Nothing
            Dim FileName As String = Nothing

            Try

                _EstimatePrint = DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail)).FirstOrDefault

            Catch ex As Exception
                _EstimatePrint = Nothing
            End Try

            If _EstimatePrint IsNot Nothing Then

                FileName = "ESTIMATING_" & AdvantageFramework.StringUtilities.PadWithCharacter(_EstimatePrint.EstimateNumber.ToString, 6, "0", True, False)

            Else

                FileName = "ESTIMATING_REPORT"

            End If

            FileName = FileName & "_" & System.DateTime.Today.Year.ToString & System.DateTime.Today.Month.ToString & System.DateTime.Today.Day.ToString

            Me.ExportOptions.PrintPreview.DefaultFileName = FileName

            If _EstimatePrintingSetting IsNot Nothing Then
                If _EstimatePrintingSetting.GroupingOptionGroupOption = "2" Then
                    Me.GroupHeader5.Visible = True
                ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "1" Then
                    Me.GroupHeader5.Visible = False
                    Me.GroupFooter5.Visible = False
                ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "3" Then
                    Me.GroupHeader5.Visible = True
                ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "4" Then
                    Me.GroupHeader5.Visible = False
                    Me.Detail.Visible = False
                    Me.Label_FunctionHeadingDescription.Visible = True
                ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "5" Then
                    Me.GroupHeader5.Visible = True
                ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "6" Then
                    Me.GroupHeader5.Visible = True
                Else
                    Me.GroupHeader5.Visible = False
                    Me.GroupFooter5.Visible = False
                End If
            ElseIf _EstimatePrintSetting IsNot Nothing Then
                If _EstimatePrintSetting.GroupingOptionGroupOption = "2" Then
                    Me.GroupHeader5.Visible = True
                ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "1" Then
                    Me.GroupHeader5.Visible = False
                    Me.GroupFooter5.Visible = False
                ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "3" Then
                    Me.GroupHeader5.Visible = True
                ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "4" Then
                    Me.GroupHeader5.Visible = False
                    Me.Detail.Visible = False
                    Me.Label_FunctionHeadingDescription.Visible = True
                ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "5" Then
                    Me.GroupHeader5.Visible = True
                ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "6" Then
                    Me.GroupHeader5.Visible = True
                Else
                    Me.GroupHeader5.Visible = False
                    Me.GroupFooter5.Visible = False
                End If
            End If

            If _EstimatePrintingSetting IsNot Nothing Then
                If _EstimatePrintingSetting.Signature = 0 Then
                    Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                    Me.GroupFooter9.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                    Me.GroupFooter1.Visible = False
                End If
                If _EstimatePrintingSetting.Signature = 2 Then
                    Me.GroupFooter8.Visible = True
                    Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                    Me.GroupFooter8.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                    Me.XrLabel44.Text = ""
                    Me.XrLabel46.Text = ""
                    Me.XrLabel48.Text = ""
                    Me.XrLabel49.Text = ""
                    Me.XrLabel50.Text = ""
                    Me.XrLabel51.Text = ""
                    Me.XrLine14.Visible = False
                    Me.XrLine15.Visible = False
                    Me.XrLine16.Visible = False
                    Me.XrLine17.Visible = False
                    Me.XrLine18.Visible = False
                    Me.XrLine19.Visible = False
                End If
                If _EstimatePrintingSetting.Signature = 3 Then
                    Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                    Me.XrLabel1.Text = _AgencyName & " Authorization:"
                End If
                If _EstimatePrintingSetting.Signature = 4 Then
                    Me.GroupFooter8.Visible = True
                    Me.GroupFooter8.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If
                If _EstimatePrintingSetting.Signature = 5 Then
                    Me.GroupFooter7.Visible = True
                    Me.GroupFooter7.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If
                If _EstimatePrintingSetting.Signature = 7 Then
                    Me.GroupFooter1.Visible = False
                    Me.GroupFooter6.Visible = True
                    Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                    Me.GroupFooter6.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If
                If _EstimatePrintingSetting.Signature = 8 Then
                    Me.GroupFooter1.Visible = False
                    Me.GroupFooter11.Visible = True
                    Me.GroupFooter11.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If


                If _EstimatePrintingSetting.GroupingOptionFunctionOption = "3" Then
                    Me.Detail.Visible = False
                    Me.GroupHeader4.Visible = False
                End If
                If _EstimatePrintingSetting.GroupingOptionFunctionOption = "4" Then
                    Me.XrLabelRate.Visible = True
                    Me.Label_Rate.Visible = True
                End If
                If _EstimatePrintingSetting.IncludeQuantityHours = True Then
                    Me.XrLabelQuantityHours.Visible = True
                End If
                If _EstimatePrintingSetting.SubtotalsOnly = True Then
                    Me.Label_ExtendedAmount.Visible = False
                End If
                'If _EstimatePrintingSetting.PrintAdNumber = False Then
                '    Me.XrTableRowAdNumber.Visible = False
                'End If
            ElseIf _EstimatePrintSetting IsNot Nothing Then
                If _EstimatePrintSetting.Signature = 0 Then
                    Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.None
                    Me.GroupFooter9.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                    Me.GroupFooter1.Visible = False
                End If
                If _EstimatePrintSetting.Signature = 1 Then
                    Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If
                If _EstimatePrintSetting.Signature = 2 Then
                    Me.GroupFooter8.Visible = True
                    Me.GroupFooter8.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                    Me.XrLabel44.Text = ""
                    Me.XrLabel46.Text = ""
                    Me.XrLabel48.Text = ""
                    Me.XrLabel49.Text = ""
                    Me.XrLabel50.Text = ""
                    Me.XrLabel51.Text = ""
                    Me.XrLine14.Visible = False
                    Me.XrLine15.Visible = False
                    Me.XrLine16.Visible = False
                    Me.XrLine17.Visible = False
                    Me.XrLine18.Visible = False
                    Me.XrLine19.Visible = False
                End If
                If _EstimatePrintSetting.Signature = 3 Then
                    Me.GroupFooter1.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                    Me.XrLabel1.Text = _AgencyName & " Authorization:"
                End If
                If _EstimatePrintSetting.Signature = 4 Then
                    Me.GroupFooter8.Visible = True
                    Me.GroupFooter8.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If
                If _EstimatePrintSetting.Signature = 5 Then
                    Me.GroupFooter7.Visible = True
                    Me.GroupFooter7.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If
                If _EstimatePrintSetting.Signature = 7 Then
                    Me.GroupFooter1.Visible = False
                    Me.GroupFooter6.Visible = True
                    Me.GroupFooter6.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If
                If _EstimatePrintSetting.Signature = 8 Then
                    Me.GroupFooter1.Visible = False
                    Me.GroupFooter11.Visible = True
                    Me.GroupFooter11.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If

                If _EstimatePrintSetting.GroupingOptionFunctionOption = "3" Then
                    Me.Detail.Visible = False
                    Me.GroupHeader4.Visible = False
                End If
                If _EstimatePrintSetting.GroupingOptionFunctionOption = "4" Then
                    Me.XrLabelRate.Visible = True
                    Me.Label_Rate.Visible = True
                End If
                If _EstimatePrintSetting.IncludeQuantityHours = True Then
                    Me.XrLabelQuantityHours.Visible = True
                End If
                If _EstimatePrintSetting.SubtotalsOnly = True Then
                    Me.Label_ExtendedAmount.Visible = False
                End If
                'If _EstimatePrintSetting.PrintAdNumber = False Then
                '    Me.XrTableRowAdNumber.Visible = False
                'End If
            End If

        End Sub
        Private Sub EstimateReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded
            Try
                SetCulture(Me, _CultureCode)
                'objects
                Dim EstimatePrintDetails As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimatePrintDetail) = Nothing

                If _EstimatePrintingSetting IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        EstimatePrintDetails = AdvantageFramework.Estimate.Printing.LoadEstimatePrintDetails(DbContext, _EstimateNumber, _EstimateComponentNumber, _UserCode, _EstimateQuoteNumber, _EstimatePrintingSetting.GroupingOptionGroupOption, _EstimateQuoteNumbers, _Combine, _EstimateCompNumbers).ToList

                        Me.DataSource = EstimatePrintDetails

                        If _DefaultLocation IsNot Nothing Then

                            _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _DefaultLocation.ID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                        Else

                            _LocationLogo = Nothing

                        End If

                    End Using

                ElseIf _EstimatePrintSetting IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        EstimatePrintDetails = AdvantageFramework.Estimate.Printing.LoadEstimatePrintDetails(DbContext, _EstimateNumber, _EstimateComponentNumber, _UserCode, _EstimateQuoteNumber, _EstimatePrintSetting.GroupingOptionGroupOption, _EstimateQuoteNumbers, _Combine, _EstimateCompNumbers).ToList

                        Me.DataSource = EstimatePrintDetails

                        If _DefaultLocation IsNot Nothing Then

                            _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _DefaultLocation.ID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                        Else

                            _LocationLogo = Nothing

                        End If

                    End Using

                End If
            Catch ex As Exception
                _ErrorString = ex.ToString
            End Try
        End Sub


#End Region

#Region "  Control Event Handlers "

        Private Sub PageHeader_BeforePrint1(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint
            Dim LocationInfo As Generic.List(Of String) = Nothing
            Dim LocationString As String = Nothing
            Dim CityStateZipLine As String = Nothing

            Try
                If _DefaultLocation IsNot Nothing Then
                    If IsDBNull(_DefaultLocation.PrintNameHeader) = False Then
                        If _DefaultLocation.PrintNameHeader = 1 Then
                            Me.LabelHeader_LocationName.Text = _DefaultLocation.Name
                        End If
                    End If
                    'Agency Information
                    LocationInfo = New Generic.List(Of String)

                    If CBool(_DefaultLocation.PrintCityHeader.GetValueOrDefault(0)) Then

                        CityStateZipLine = _DefaultLocation.City

                    End If
                    If CBool(_DefaultLocation.PrintStateHeader.GetValueOrDefault(0)) Then

                        CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, ", ", "") & _DefaultLocation.State

                    End If

                    If CBool(_DefaultLocation.PrintZipHeader.GetValueOrDefault(0)) Then

                        CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, " ", "") & _DefaultLocation.Zip

                    End If

                    BuildLocationString(_DefaultLocation.Address, CBool(_DefaultLocation.PrintAddressHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Address2, CBool(_DefaultLocation.PrintAddress2Header.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(CityStateZipLine, Not String.IsNullOrEmpty(CityStateZipLine), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Phone), CBool(_DefaultLocation.PrintPhoneHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Fax) & " Fax", CBool(_DefaultLocation.PrintFaxHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Email, CBool(_DefaultLocation.PrintEmailHeader.GetValueOrDefault(0)), LocationInfo)

                    LocationString = String.Join(" • ", LocationInfo)

                    'Me.txtDates.Text = printedDate.ToShortDateString

                    If IsDBNull(_DefaultLocation.PrintHeader) = False Then
                        If _DefaultLocation.PrintHeader = 0 Then
                            LocationString = ""
                        End If
                    End If

                End If

                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.ReportTitle <> "" Then
                        Me.LabelPageHeader_Title.Text = _EstimatePrintingSetting.ReportTitle
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.ReportTitle <> "" Then
                        Me.LabelPageHeader_Title.Text = _EstimatePrintSetting.ReportTitle
                    End If
                End If

            Catch ex As Exception
                LocationString = ""
            Finally
                LabelHeader_Location.Text = LocationString
            End Try
        End Sub
        Private Sub Label_To_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_To.BeforePrint

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Contact As AdvantageFramework.Database.Entities.ClientContact = Nothing

            Dim CDP As AdvantageFramework.Database.Entities.Product = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim CDPAddress As Generic.List(Of String) = Nothing
            Dim CityStateString As String = ""

            Try

                'PurchaseOrder = LoadCurrentPurchaseOrder()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _EstimatePrintingSetting IsNot Nothing Then

                        CDPAddress = New Generic.List(Of String)

                        If _EstimatePrintingSetting.CDPAddressOption = "Client" Then

                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintingSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintingSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintingSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.ProductionAttentionLine) = False Then
                                CDPAddress.Add(CDP.Client.ProductionAttentionLine)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.BillingAddress) = False Then
                                CDPAddress.Add(CDP.Client.BillingAddress)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.BillingAddress2) = False Then
                                CDPAddress.Add(CDP.Client.BillingAddress2)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.City) = False Then
                                CityStateString = CDP.Client.City
                            End If
                            If String.IsNullOrEmpty(CDP.Client.State) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & CDP.Client.State
                            End If
                            If String.IsNullOrEmpty(CDP.Client.Zip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & CDP.Client.Zip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.Country) = False Then
                                CDPAddress.Add(CDP.Client.Country)
                            End If

                        ElseIf _EstimatePrintingSetting.CDPAddressOption = "Division" Then

                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintingSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintingSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintingSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.AttentionLine) = False Then
                                CDPAddress.Add(CDP.Division.AttentionLine)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.BillingAddress) = False Then
                                CDPAddress.Add(CDP.Division.BillingAddress)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.BillingAddress2) = False Then
                                CDPAddress.Add(CDP.Division.BillingAddress2)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.City) = False Then
                                CityStateString = CDP.Division.City
                            End If
                            If String.IsNullOrEmpty(CDP.Division.State) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & CDP.Division.State
                            End If
                            If String.IsNullOrEmpty(CDP.Division.Zip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & CDP.Division.Zip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.Country) = False Then
                                CDPAddress.Add(CDP.Division.Country)
                            End If

                        ElseIf _EstimatePrintingSetting.CDPAddressOption = "Product" Then

                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintingSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintingSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintingSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(CDP.AttentionTo) = False Then
                                CDPAddress.Add(CDP.AttentionTo)
                            End If
                            If String.IsNullOrEmpty(CDP.BillingAddress) = False Then
                                CDPAddress.Add(CDP.BillingAddress)
                            End If
                            If String.IsNullOrEmpty(CDP.BillingAddress2) = False Then
                                CDPAddress.Add(CDP.BillingAddress2)
                            End If
                            If String.IsNullOrEmpty(CDP.BillingCity) = False Then
                                CityStateString = CDP.BillingCity
                            End If
                            If String.IsNullOrEmpty(CDP.BillingState) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & CDP.BillingState
                            End If
                            If String.IsNullOrEmpty(CDP.BillingZip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & CDP.BillingZip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                            If String.IsNullOrEmpty(CDP.BillingCountry) = False Then
                                CDPAddress.Add(CDP.BillingCountry)
                            End If

                        ElseIf _EstimatePrintingSetting.CDPAddressOption = "Contact" Then

                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintingSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintingSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintingSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactName) = False Then
                                CDPAddress.Add(_EstimatePrint.EstimateContactName)
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactAddress1) = False Then
                                CDPAddress.Add(_EstimatePrint.EstimateContactAddress1)
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactAddress2) = False Then
                                CDPAddress.Add(_EstimatePrint.EstimateContactAddress2)
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactCity) = False Then
                                CityStateString = _EstimatePrint.EstimateContactCity
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactState) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & _EstimatePrint.EstimateContactState
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactZip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & _EstimatePrint.EstimateContactZip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                        Else
                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintingSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintingSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintingSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.ProductionAttentionLine) = False Then
                                CDPAddress.Add(CDP.Client.ProductionAttentionLine)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.BillingAddress) = False Then
                                CDPAddress.Add(CDP.Client.BillingAddress)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.BillingAddress2) = False Then
                                CDPAddress.Add(CDP.Client.BillingAddress2)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.City) = False Then
                                CityStateString = CDP.Client.City
                            End If
                            If String.IsNullOrEmpty(CDP.Client.State) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & CDP.Client.State
                            End If
                            If String.IsNullOrEmpty(CDP.Client.Zip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & CDP.Client.Zip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.Country) = False Then
                                CDPAddress.Add(CDP.Client.Country)
                            End If


                        End If

                    ElseIf _EstimatePrintSetting IsNot Nothing Then
                        CDPAddress = New Generic.List(Of String)

                        If _EstimatePrintSetting.CDPAddressOption = "Client" Then

                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.ProductionAttentionLine) = False Then
                                CDPAddress.Add(CDP.Client.ProductionAttentionLine)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.BillingAddress) = False Then
                                CDPAddress.Add(CDP.Client.BillingAddress)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.BillingAddress2) = False Then
                                CDPAddress.Add(CDP.Client.BillingAddress2)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.City) = False Then
                                CityStateString = CDP.Client.City
                            End If
                            If String.IsNullOrEmpty(CDP.Client.State) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & CDP.Client.State
                            End If
                            If String.IsNullOrEmpty(CDP.Client.Zip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & CDP.Client.Zip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.Country) = False Then
                                CDPAddress.Add(CDP.Client.Country)
                            End If

                        ElseIf _EstimatePrintSetting.CDPAddressOption = "Division" Then

                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.AttentionLine) = False Then
                                CDPAddress.Add(CDP.Division.AttentionLine)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.BillingAddress) = False Then
                                CDPAddress.Add(CDP.Division.BillingAddress)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.BillingAddress2) = False Then
                                CDPAddress.Add(CDP.Division.BillingAddress2)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.City) = False Then
                                CityStateString = CDP.Division.City
                            End If
                            If String.IsNullOrEmpty(CDP.Division.State) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & CDP.Division.State
                            End If
                            If String.IsNullOrEmpty(CDP.Division.Zip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & CDP.Division.Zip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                            If String.IsNullOrEmpty(CDP.Division.Country) = False Then
                                CDPAddress.Add(CDP.Division.Country)
                            End If

                        ElseIf _EstimatePrintSetting.CDPAddressOption = "Product" Then

                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(CDP.AttentionTo) = False Then
                                CDPAddress.Add(CDP.AttentionTo)
                            End If
                            If String.IsNullOrEmpty(CDP.BillingAddress) = False Then
                                CDPAddress.Add(CDP.BillingAddress)
                            End If
                            If String.IsNullOrEmpty(CDP.BillingAddress2) = False Then
                                CDPAddress.Add(CDP.BillingAddress2)
                            End If
                            If String.IsNullOrEmpty(CDP.BillingCity) = False Then
                                CityStateString = CDP.BillingCity
                            End If
                            If String.IsNullOrEmpty(CDP.BillingState) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & CDP.BillingState
                            End If
                            If String.IsNullOrEmpty(CDP.BillingZip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & CDP.BillingZip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                            If String.IsNullOrEmpty(CDP.BillingCountry) = False Then
                                CDPAddress.Add(CDP.BillingCountry)
                            End If

                        ElseIf _EstimatePrintSetting.CDPAddressOption = "Contact" Then

                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactName) = False Then
                                CDPAddress.Add(_EstimatePrint.EstimateContactName)
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactAddress1) = False Then
                                CDPAddress.Add(_EstimatePrint.EstimateContactAddress1)
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactAddress2) = False Then
                                CDPAddress.Add(_EstimatePrint.EstimateContactAddress2)
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactCity) = False Then
                                CityStateString = _EstimatePrint.EstimateContactCity
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactState) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & _EstimatePrint.EstimateContactState
                            End If
                            If String.IsNullOrEmpty(_EstimatePrint.EstimateContactZip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & _EstimatePrint.EstimateContactZip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                        Else
                            CDP = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                            If _EstimatePrintSetting.PrintClientName = True Then
                                CDPAddress.Add(CDP.Client.Name)
                            End If
                            If _EstimatePrintSetting.PrintDivisionName = True Then
                                CDPAddress.Add(CDP.Division.Name)
                            End If
                            If _EstimatePrintSetting.PrintProductDescription = True Then
                                CDPAddress.Add(CDP.Name)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.ProductionAttentionLine) = False Then
                                CDPAddress.Add(CDP.Client.ProductionAttentionLine)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.BillingAddress) = False Then
                                CDPAddress.Add(CDP.Client.BillingAddress)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.BillingAddress2) = False Then
                                CDPAddress.Add(CDP.Client.BillingAddress2)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.City) = False Then
                                CityStateString = CDP.Client.City
                            End If
                            If String.IsNullOrEmpty(CDP.Client.State) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & CDP.Client.State
                            End If
                            If String.IsNullOrEmpty(CDP.Client.Zip) = False Then
                                CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & CDP.Client.Zip
                            End If
                            If String.IsNullOrEmpty(CityStateString) = False Then
                                CDPAddress.Add(CityStateString)
                            End If
                            If String.IsNullOrEmpty(CDP.Client.Country) = False Then
                                CDPAddress.Add(CDP.Client.Country)
                            End If


                        End If
                    End If

                End Using

            Catch ex As Exception
                CDPAddress = Nothing
            Finally

                If CDPAddress IsNot Nothing Then

                    Label_To.Lines = CDPAddress.ToArray

                Else

                    Label_To.Text = ""

                End If

            End Try

        End Sub
        Private Sub Label_EstNumber_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_EstNumber.BeforePrint
            'objects
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.SummaryLevel = 1 Then
                        Me.Label_EstNumber.Text = _EstimateNumber & " - " & Me.XrLabelQuoteNumber.Text
                    Else
                        Me.Label_EstNumber.Text = _EstimateNumber & " - " & _EstimateComponentNumber & " - " & Me.XrLabelQuoteNumber.Text
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.CombineComponents = True Then
                        Me.Label_EstNumber.Text = _EstimateNumber & " - " & Me.XrLabelQuoteNumber.Text
                    Else
                        Me.Label_EstNumber.Text = _EstimateNumber & " - " & _EstimateComponentNumber & " - " & Me.XrLabelQuoteNumber.Text
                    End If
                End If
            Catch ex As Exception

            End Try

        End Sub
        Private Sub PictureBoxHeader_Logo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PictureBoxHeader_Logo.BeforePrint

            'objects
            Dim Image As Object = Nothing
            Dim LogoVisible As Boolean = False

            Try

                If _DefaultLocation IsNot Nothing Then

                    If _DefaultLocation.LogoLocation <> "N" Then

                        If String.IsNullOrWhiteSpace(_DefaultLocation.LogoPath) = False Then

                            If My.Computer.FileSystem.FileExists(_DefaultLocation.LogoPath) Then

                                LogoVisible = True
                                Image = System.Drawing.Image.FromFile(_DefaultLocation.LogoPath)

                            End If

                        ElseIf _LocationLogo IsNot Nothing AndAlso _LocationLogo.Image IsNot Nothing Then

                            Using MemoryStream = New System.IO.MemoryStream(_LocationLogo.Image)

                                LogoVisible = True
                                Image = System.Drawing.Image.FromStream(MemoryStream)

                            End Using

                        End If

                    End If

                End If

            Catch ex As Exception
                LogoVisible = False
                Image = Nothing
            Finally
                PictureBoxHeader_Logo.Visible = LogoVisible
                PictureBoxHeader_Logo.Image = Image
            End Try

        End Sub
        Private Sub LabelPageHeader_Agency_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs)

            'objects
            Dim AgencyNameVisible As Boolean = False

            Try

                If _DefaultLocation IsNot Nothing Then

                    If CBool(_DefaultLocation.PrintHeader.GetValueOrDefault(0)) Then

                        If CBool(_DefaultLocation.PrintNameHeader.GetValueOrDefault(0)) Then

                            AgencyNameVisible = True

                        End If

                    End If

                End If

            Catch ex As Exception
                AgencyNameVisible = False
            Finally
                'LabelPageHeader_Agency.Visible = AgencyNameVisible
            End Try

        End Sub
        Private Sub LabelFooter_LocationInfo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Terms.BeforePrint

            'objects
            Dim LocationInfo As Generic.List(Of String) = Nothing
            Dim LocationString As String = Nothing
            Dim CityStateZipLine As String = Nothing

            Try

                If _DefaultLocation.PrintFooter.GetValueOrDefault(0) = 1 Then

                    LocationInfo = New Generic.List(Of String)

                    If CBool(_DefaultLocation.PrintCityFooter.GetValueOrDefault(0)) Then

                        CityStateZipLine = _DefaultLocation.City

                    End If

                    If CBool(_DefaultLocation.PrintStateFooter.GetValueOrDefault(0)) Then

                        CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, ", ", "") & _DefaultLocation.State

                    End If

                    If CBool(_DefaultLocation.PrintZipFooter.GetValueOrDefault(0)) Then

                        CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, " ", "") & _DefaultLocation.Zip

                    End If

                    BuildLocationString(_DefaultLocation.Name, CBool(_DefaultLocation.PrintNameFooter.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Address, CBool(_DefaultLocation.PrintAddressFooter.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Address2, CBool(_DefaultLocation.PrintAddress2Footer.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(CityStateZipLine, Not String.IsNullOrEmpty(CityStateZipLine), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Phone), CBool(_DefaultLocation.PrintPhoneFooter.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Fax) & " Fax", CBool(_DefaultLocation.PrintFaxFooter.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Email, CBool(_DefaultLocation.PrintEmailFooter.GetValueOrDefault(0)), LocationInfo)

                    LocationString = String.Join(" • ", LocationInfo)

                End If

            Catch ex As Exception
                LocationString = ""
            Finally
                Label_Terms.Text = LocationString
            End Try

        End Sub
        Private Sub PictureBox_EmployeeSignature_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PictureBox_EmployeeSignature.BeforePrint

            'objects
            Dim Visible As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            Try

                If Visible Then

                    If _EstimatePrintingSetting IsNot Nothing Then
                        If _EstimatePrintingSetting.UseEmployeeSignature = False Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _Session.UserCode)
                                End Using

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmployeeCode)

                                If Employee IsNot Nothing Then

                                    If Employee.SignatureImage IsNot Nothing Then

                                        Try

                                            MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                            PictureBox_EmployeeSignature.Image = System.Drawing.Image.FromStream(MemoryStream)

                                        Catch ex As Exception

                                        End Try

                                    Else

                                        PictureBox_EmployeeSignature.Image = Nothing

                                    End If

                                End If

                            End Using

                        End If

                        If _EstimatePrintingSetting.ExcludeSignatures = True Then
                            PictureBox_EmployeeSignature.Image = Nothing
                        End If

                    ElseIf _EstimatePrintSetting IsNot Nothing Then
                        If _EstimatePrintSetting.UseEmployeeSignature = False Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _Session.UserCode)
                                End Using

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmployeeCode)

                                If Employee IsNot Nothing Then

                                    If Employee.SignatureImage IsNot Nothing Then

                                        Try

                                            MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                            PictureBox_EmployeeSignature.Image = System.Drawing.Image.FromStream(MemoryStream)

                                        Catch ex As Exception

                                        End Try

                                    Else

                                        PictureBox_EmployeeSignature.Image = Nothing

                                    End If

                                End If

                            End Using

                        End If

                        If _EstimatePrintSetting.ExcludeSignatures = True Then
                            PictureBox_EmployeeSignature.Image = Nothing
                        End If

                    End If

                Else

                    PictureBox_EmployeeSignature.Image = Nothing

                End If

            Catch ex As Exception
                PictureBox_EmployeeSignature.Image = Nothing
                Visible = False
            Finally
                PictureBox_EmployeeSignature.Visible = Visible
            End Try

        End Sub
        Private Sub XrPictureBox_Signature_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrPictureBox_Signature.BeforePrint
            'objects
            Dim Visible As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim User As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            Try

                If Visible Then

                    If _EstimatePrintingSetting IsNot Nothing Then
                        If _EstimatePrintingSetting.UseEmployeeSignature = False Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _Session.UserCode)
                                End Using

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmployeeCode)

                                If Employee IsNot Nothing Then

                                    If Employee.SignatureImage IsNot Nothing Then

                                        Try

                                            MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                            XrPictureBox_Signature.Image = System.Drawing.Image.FromStream(MemoryStream)

                                        Catch ex As Exception

                                        End Try

                                    Else

                                        XrPictureBox_Signature.Image = Nothing

                                    End If

                                End If

                            End Using

                        End If

                        If _EstimatePrintingSetting.ExcludeSignatures = True Then
                            XrPictureBox_Signature.Image = Nothing
                        End If

                    ElseIf _EstimatePrintSetting IsNot Nothing Then
                        If _EstimatePrintSetting.UseEmployeeSignature = False Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                                    User = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, _Session.UserCode)
                                End Using

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, User.EmployeeCode)

                                If Employee IsNot Nothing Then

                                    If Employee.SignatureImage IsNot Nothing Then

                                        Try

                                            MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                                            XrPictureBox_Signature.Image = System.Drawing.Image.FromStream(MemoryStream)

                                        Catch ex As Exception

                                        End Try

                                    Else

                                        XrPictureBox_Signature.Image = Nothing

                                    End If

                                End If

                            End Using

                        End If

                        If _EstimatePrintSetting.ExcludeSignatures = True Then
                            XrPictureBox_Signature.Image = Nothing
                        End If

                    End If

                Else

                    XrPictureBox_Signature.Image = Nothing

                End If

            Catch ex As Exception
                XrPictureBox_Signature.Image = Nothing
                Visible = False
            Finally
                XrPictureBox_Signature.Visible = Visible
            End Try

        End Sub
        Private Sub Label_EstimateDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_EstimateDate.BeforePrint

            'objects
            Dim IssueDate As Date = Nothing

            Try
                If _UsePrintedDate <> Nothing Then

                    IssueDate = _UsePrintedDate

                Else

                    IssueDate = Now.Date

                End If


            Catch ex As Exception
                IssueDate = Nothing
            Finally
                Label_EstimateDate.Text = IssueDate.ToShortDateString
            End Try

        End Sub

        Private Sub Label_AuthorizationDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_AuthorizationDate.BeforePrint
            Try
                Me.Label_AuthorizationDate.Text = Me.Label_EstimateDate.Text
            Catch ex As Exception

            End Try
        End Sub
        Private Sub XrLabel42_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabel42.BeforePrint
            Try
                Me.XrLabel42.Text = Me.Label_EstimateDate.Text
            Catch ex As Exception

            End Try
        End Sub
        Private Sub GroupHeader_Main_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader_Main.BeforePrint

            'objects
            Dim LocationInfo As Generic.List(Of String) = Nothing
            Dim LocationString As String = Nothing
            Dim CityStateZipLine As String = Nothing

            Try

                If _DefaultLocation IsNot Nothing Then

                    If _DefaultLocation.PrintHeader.GetValueOrDefault(0) = 1 Then

                        If _DefaultLocation.PrintNameHeader.GetValueOrDefault(0) = 1 Then

                            LabelHeader_LocationName.Text = _DefaultLocation.Name

                        End If

                    End If

                    LocationInfo = New Generic.List(Of String)

                    If CBool(_DefaultLocation.PrintCityHeader.GetValueOrDefault(0)) Then

                        CityStateZipLine = _DefaultLocation.City

                    End If

                End If

                If CBool(_DefaultLocation.PrintStateHeader.GetValueOrDefault(0)) Then

                    CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, ", ", "") & _DefaultLocation.State

                End If

                If CBool(_DefaultLocation.PrintZipHeader.GetValueOrDefault(0)) Then

                    CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, " ", "") & _DefaultLocation.Zip

                End If

                BuildLocationString(_DefaultLocation.Address, CBool(_DefaultLocation.PrintAddressHeader.GetValueOrDefault(0)), LocationInfo)
                BuildLocationString(_DefaultLocation.Address2, CBool(_DefaultLocation.PrintAddress2Header.GetValueOrDefault(0)), LocationInfo)
                BuildLocationString(CityStateZipLine, Not String.IsNullOrEmpty(CityStateZipLine), LocationInfo)
                BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Phone), CBool(_DefaultLocation.PrintPhoneHeader.GetValueOrDefault(0)), LocationInfo)
                BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Fax), CBool(_DefaultLocation.PrintFaxHeader.GetValueOrDefault(0)), LocationInfo)
                BuildLocationString(_DefaultLocation.Email, CBool(_DefaultLocation.PrintEmailHeader.GetValueOrDefault(0)), LocationInfo)

                LocationString = String.Join(" • ", LocationInfo)

            Catch ex As Exception
                LocationString = ""
            Finally
                'LabelHeader_Location.Text = LocationString
            End Try

        End Sub
        Private Sub GroupHeader5_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader5.BeforePrint

        End Sub
        Private Sub GroupHeader1_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader1.BeforePrint
            Try

            Catch ex As Exception

            End Try
        End Sub

        Private Sub GroupHeader2_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader2.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.HideJobDescription = True Then
                        Me.XrLabel12.Text = ""
                        Me.Label_JobNumber.Visible = False
                        Me.Label_JobDescription.Visible = False
                    End If
                End If
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.HideComponentDescription = True Then
                        Me.XrLabel13.Text = ""
                        Me.Label_ComponentNumber.Visible = False
                        Me.Label_JobComponentDescription.Visible = False
                        Me.Label_ComponentDescription.Visible = False
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.HideComponentDescription = True Then
                        Me.XrLabel13.Text = ""
                        Me.Label_ComponentNumber.Visible = False
                        Me.Label_JobComponentDescription.Visible = False
                        Me.Label_ComponentDescription.Visible = False
                    End If
                End If
                If _EstimatePrint.EstimateCampaignID IsNot Nothing Then
                    If _EstimatePrint.EstimateCampaignID > 0 Then
                        Me.Label_JobNumber.Visible = False
                        Me.Label_JobDescription.Visible = False
                        Me.Label_JobComponentDescription.Visible = False
                        Me.Label_ComponentNumber.Visible = False
                        Me.XrLabel12.Visible = False
                        Me.XrLabel13.Visible = False
                    Else
                        Me.XrLabelCampaign.Visible = False
                        Me.XrLabelEstimateCampaignName.Visible = False
                    End If
                Else
                    Me.XrLabelCampaign.Visible = False
                    Me.XrLabelEstimateCampaignName.Visible = False
                    If _EstimatePrint.JobNumber Is Nothing Then
                        Me.Label_JobNumber.Visible = False
                        Me.Label_JobDescription.Visible = False
                        Me.Label_JobComponentDescription.Visible = False
                        Me.Label_ComponentNumber.Visible = False
                        Me.XrLabel12.Visible = False
                        Me.XrLabel13.Visible = False
                    End If
                End If
                If _Combine = 1 Then
                    Me.XrLabel7.Text = ""
                    Me.Label_EstimateComponent.Text = ""
                    Me.Label_ComponentDescription.Text = ""
                    Me.XrLabel13.Text = ""
                    Me.Label_ComponentNumber.Text = ""
                    Me.Label_JobComponentDescription.Text = ""
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub GroupFooter2_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooter2.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.GroupingOptionFunctionOption = "3" Then
                        Me.XrLine20.Visible = False
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.GroupingOptionFunctionOption = "3" Then
                        Me.XrLine20.Visible = False
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Detail_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Detail.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeRate = True Then
                        Me.Label_Rate.Visible = True
                    End If
                    If _EstimatePrintingSetting.IncludeQuantityHours = True Then
                        Me.Label_QuantityHours.Visible = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeRate = True Then
                        Me.Label_Rate.Visible = True
                    End If
                    If _EstimatePrintSetting.IncludeQuantityHours = True Then
                        Me.Label_QuantityHours.Visible = True
                    End If
                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub Label_Rate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Rate.BeforePrint
            Try
                If Me.Label_Rate.Text.EndsWith("0") Then
                    Me.Label_Rate.Text = Me.Label_Rate.Text.Substring(0, Me.Label_Rate.Text.Length - 1)
                End If
                If Me.Label_Rate.Text.EndsWith("0") Then
                    Me.Label_Rate.Text = Me.Label_Rate.Text.Substring(0, Me.Label_Rate.Text.Length - 1)
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrRichTextDetailComments_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrRichTextDetailComments.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeEstimateFunctionComment = True Then
                        Me.XrRichTextDetailComments.Visible = True
                    Else
                        Me.XrRichTextDetailComments.Html = ""
                        Me.XrRichTextDetailComments.Text = ""
                        Me.XrRichTextDetailComments.DataBindings.Clear()
                        'Me.XrRichTextDetailComments.Visible = False
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeEstimateFunctionComment = True Then
                        Me.XrRichTextDetailComments.Visible = True
                    Else
                        Me.XrRichTextDetailComments.Html = ""
                        Me.XrRichTextDetailComments.Text = ""
                        Me.XrRichTextDetailComments.DataBindings.Clear()
                        'Me.XrRichTextDetailComments.Visible = False
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrRichTextSuppliedByNotes_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrRichTextSuppliedByNotes.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeSuppliedByNotes = True Then
                        Me.XrRichTextSuppliedByNotes.Visible = True
                    Else
                        Me.XrRichTextSuppliedByNotes.Html = ""
                        Me.XrRichTextSuppliedByNotes.Text = ""
                        Me.XrRichTextSuppliedByNotes.DataBindings.Clear()
                        'Me.XrRichTextSuppliedByNotes.Visible = False
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeSuppliedByNotes = True Then
                        Me.XrRichTextSuppliedByNotes.Visible = True
                    Else
                        Me.XrRichTextSuppliedByNotes.Html = ""
                        Me.XrRichTextSuppliedByNotes.Text = ""
                        Me.XrRichTextSuppliedByNotes.DataBindings.Clear()
                        'Me.XrRichTextSuppliedByNotes.Visible = False
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub GroupHeader4_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader4.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeRate = True Then
                        Me.XrLabelRate.Visible = True
                    End If
                    If _EstimatePrintingSetting.IncludeQuantityHours = 1 Then
                        Me.XrLabelQuantityHours.Visible = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeRate = True Then
                        Me.XrLabelRate.Visible = True
                    End If
                    If _EstimatePrintSetting.IncludeQuantityHours = 1 Then
                        Me.XrLabelQuantityHours.Visible = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub GroupHeader3_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeader3.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeEstimateComment = True Then
                        Me.XrRichTextEstimateComment.Visible = True
                    Else
                        Me.XrRichTextEstimateComment.Html = ""
                        Me.XrRichTextEstimateComment.Text = ""
                        Me.XrRichTextEstimateComment.DataBindings.Clear()
                        'Me.XrRichTextEstimateComment.Visible = False
                    End If
                    If _EstimatePrintingSetting.IncludeEstimateComponentComment = True Then
                        Me.XrRichTextEstimateComponentComment.Visible = True
                    Else
                        Me.XrRichTextEstimateComponentComment.Html = ""
                        Me.XrRichTextEstimateComponentComment.Text = ""
                        Me.XrRichTextEstimateComponentComment.DataBindings.Clear()
                        'Me.XrRichTextEstimateComponentComment.Visible = False
                    End If
                    If _EstimatePrintingSetting.IncludeEstimateQuoteComment = True Then
                        Me.XrRichTextQuoteComment.Visible = True
                    Else
                        Me.XrRichTextQuoteComment.Html = ""
                        Me.XrRichTextQuoteComment.Text = ""
                        Me.XrRichTextQuoteComment.DataBindings.Clear()
                        'Me.XrRichTextQuoteComment.Visible = False
                    End If
                    If _EstimatePrintingSetting.IncludeEstimateRevisionComment = True Then
                        Me.XrRichTextRevisionComment.Visible = True
                    Else
                        Me.XrRichTextRevisionComment.Html = ""
                        Me.XrRichTextRevisionComment.Text = ""
                        Me.XrRichTextRevisionComment.DataBindings.Clear()
                        'Me.XrRichTextRevisionComment.Visible = False
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeEstimateComment = True Then
                        Me.XrRichTextEstimateComment.Visible = True
                    Else
                        Me.XrRichTextEstimateComment.Html = ""
                        Me.XrRichTextEstimateComment.Text = ""
                        Me.XrRichTextEstimateComment.DataBindings.Clear()
                        'Me.XrRichTextEstimateComment.Visible = False
                    End If
                    If _EstimatePrintSetting.IncludeEstimateComponentComment = True Then
                        Me.XrRichTextEstimateComponentComment.Visible = True
                    Else
                        Me.XrRichTextEstimateComponentComment.Html = ""
                        Me.XrRichTextEstimateComponentComment.Text = ""
                        Me.XrRichTextEstimateComponentComment.DataBindings.Clear()
                        'Me.XrRichTextEstimateComponentComment.Visible = False
                    End If
                    If _EstimatePrintSetting.IncludeEstimateQuoteComment = True Then
                        Me.XrRichTextQuoteComment.Visible = True
                    Else
                        Me.XrRichTextQuoteComment.Html = ""
                        Me.XrRichTextQuoteComment.Text = ""
                        Me.XrRichTextQuoteComment.DataBindings.Clear()
                        'Me.XrRichTextQuoteComment.Visible = False
                    End If
                    If _EstimatePrintSetting.IncludeEstimateRevisionComment = True Then
                        Me.XrRichTextRevisionComment.Visible = True
                    Else
                        Me.XrRichTextRevisionComment.Html = ""
                        Me.XrRichTextRevisionComment.Text = ""
                        Me.XrRichTextRevisionComment.DataBindings.Clear()
                        'Me.XrRichTextRevisionComment.Visible = False
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrRichTextDefaultFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrRichTextDefaultFooter.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.DefaultFooterComment = True Then
                        If _DefaultFooterType = "Standard Comment" Then
                            XrRichTextDefaultFooter.Text = _DefaultFooter
                        ElseIf _DefaultFooterType = "Agency Defined" Then
                            XrRichTextDefaultFooter.Text = _DefaultFooter
                        Else
                            XrRichTextDefaultFooter.Html = _DefaultFooter
                        End If
                    Else
                        XrRichTextDefaultFooter.Html = ""
                        XrRichTextDefaultFooter.Text = ""
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.DefaultFooterComment = True Then
                        If _DefaultFooterType = "Standard Comment" Then
                            XrRichTextDefaultFooter.Text = _DefaultFooter
                        ElseIf _DefaultFooterType = "Agency Defined" Then
                            XrRichTextDefaultFooter.Text = _DefaultFooter
                        Else
                            XrRichTextDefaultFooter.Html = _DefaultFooter
                        End If
                    Else
                        XrRichTextDefaultFooter.Html = ""
                        XrRichTextDefaultFooter.Text = ""
                    End If
                End If



            Catch ex As Exception

            End Try
        End Sub

        Private Sub Label_EstimateNumber_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_EstimateNumber.BeforePrint
            Try
                Me.Label_EstimateNumber.Text = Me.Label_EstimateNumber.Text.PadLeft(6, "0")
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Label_EstimateComponent_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_EstimateComponent.BeforePrint
            Try
                If _Combine = 0 Then
                    Me.Label_EstimateComponent.Text = Me.Label_EstimateComponent.Text.PadLeft(2, "0")
                Else
                    Me.Label_EstimateComponent.Text = ""
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Label_QuoteNumber_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_QuoteNumber.BeforePrint
            Try
                Me.Label_QuoteNumber.Text = Me.Label_QuoteNumber.Text.PadLeft(2, "0")
            Catch ex As Exception

            End Try
        End Sub

        'Private Sub Label_Revision_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs)
        '    Try
        '        Me.Label_Revision.Text = Me.Label_Revision.Text.PadLeft(2, "0")
        '    Catch ex As Exception

        '    End Try
        'End Sub

        Private Sub Label_JobNumber_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_JobNumber.BeforePrint
            Try
                Me.Label_JobNumber.Text = Me.Label_JobNumber.Text.PadLeft(6, "0")
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Label_ComponentNumber_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ComponentNumber.BeforePrint
            Try
                If _Combine = 0 Then
                    Me.Label_ComponentNumber.Text = Me.Label_ComponentNumber.Text.PadLeft(2, "0")
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableRow_SubTotal_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableRow_SubTotal.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.TotalsShowContingencySeparately = False And _EstimatePrintingSetting.TotalsShowCommissionSeparately = False And _EstimatePrintingSetting.TotalsShowTaxSeparately = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.TotalsShowContingencySeparately = False And _EstimatePrintSetting.TotalsShowCommissionSeparately = False And _EstimatePrintSetting.TotalsShowTaxSeparately = False Then
                        e.Cancel = True
                    End If
                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableRow_Contingency_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableRow_Contingency.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.TotalsShowContingencySeparately = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.TotalsShowContingencySeparately = False Then
                        e.Cancel = True
                    End If
                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableRow_Commission_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableRow_Commission.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.TotalsShowCommissionSeparately = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.TotalsShowCommissionSeparately = False Then
                        e.Cancel = True
                    End If
                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableRow_Tax_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableRow_Tax.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.TotalsShowTaxSeparately = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.TotalsShowTaxSeparately = False Then
                        e.Cancel = True
                    End If
                End If

            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableRow_FunctionType_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableRow_FunctionType.BeforePrint
            Try
                If Me.TableCell_FunctionType.Text = "E" Then
                    Me.TableCell_FunctionType.Text = "Employee Time Charges"
                End If
                If Me.TableCell_FunctionType.Text = "V" Then
                    Me.TableCell_FunctionType.Text = "Vendor Charges"
                End If
                If Me.TableCell_FunctionType.Text = "I" Then
                    Me.TableCell_FunctionType.Text = "Miscellaneous Charges"
                End If
                If Me.TableCell_FunctionType.Text = "C" Then
                    Me.TableCell_FunctionType.Text = "Client Out of Pocket"
                End If

                Me.TableCell_FunctionTypeAmount.Visible = False

                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.GroupingOptionGroupOption = "1" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "3" Or _EstimatePrintingSetting.GroupingOptionGroupOption = "4" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "5" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "6" Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.GroupingOptionGroupOption = "1" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "3" Or _EstimatePrintSetting.GroupingOptionGroupOption = "4" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "5" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "6" Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableRow_FunctionHeading_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableRow_FunctionHeading.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.GroupingOptionGroupOption = "2" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "1" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "5" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "6" Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.GroupingOptionGroupOption = "2" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "1" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "5" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "6" Then
                        e.Cancel = True
                    End If
                End If

                Me.TableCell_FunctionHeadingAmount.Visible = False
            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableRow_InOut_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableRow_InOut.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.GroupingOptionGroupOption = "2" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "1" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "3" Or _EstimatePrintingSetting.GroupingOptionGroupOption = "4" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "6" Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.GroupingOptionGroupOption = "2" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "1" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "3" Or _EstimatePrintSetting.GroupingOptionGroupOption = "4" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "6" Then
                        e.Cancel = True
                    End If
                End If

                Me.TableCell_InOutAmount.Visible = False
            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableRow_Phase_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableRow_Phase.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.GroupingOptionGroupOption = "2" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "1" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "3" Or _EstimatePrintingSetting.GroupingOptionGroupOption = "4" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "5" Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.GroupingOptionGroupOption = "2" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "1" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "3" Or _EstimatePrintSetting.GroupingOptionGroupOption = "4" Then
                        e.Cancel = True
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "5" Then
                        e.Cancel = True
                    End If
                End If

                Me.TableCell_PhaseAmount.Visible = False
            Catch ex As Exception

            End Try
        End Sub

        'Private Sub Label_JobDueDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs)
        '    Try
        '        If Me.Label_JobDueDate.Text <> "" Then
        '            Me.Label_JobDueDate.Text = CDate(Me.Label_JobDueDate.Text).ToShortDateString
        '        End If
        '    Catch ex As Exception

        '    End Try
        'End Sub

        Private Sub XrTableRowClientReference_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowClientReference.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeClientReference = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeClientReference = False Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrTableRowSalesClass_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowSalesClass.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeSalesClass = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeSalesClass = False Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrTableRowAccountExecutive_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowAccountExecutive.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeAccountExecutive = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeAccountExecutive = False Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrTableRowCPM_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowCPM.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeCPM = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeCPM = False Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrTableRowCPU_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowCPU.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeCPU = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeCPU = False Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrTableRowEstimateQuantity_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowEstimateQuantity.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeJobQuantity = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeJobQuantity = False Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrTableRowAdNumber_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowAdNumber.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.PrintAdNumber = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.PrintAdNumber = False Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrTableRowJobDueDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowJobDueDate.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.IncludeJobDueDate = False Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.IncludeJobDueDate = False Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrTableRowRevision_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrTableRowRevision.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.HideRevision = True Then
                        e.Cancel = True
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.HideRevision = True Then
                        e.Cancel = True
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub XrLabelGroupingTotalLabel_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrLabelGroupingTotalLabel.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If _EstimatePrintingSetting.GroupingOptionGroupOption = "2" Then
                        If Me.XrLabelFT.Text = "E" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Employee Time Charges:"
                        End If
                        If Me.XrLabelFT.Text = "V" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Vendor Charges:"
                        End If
                        If Me.XrLabelFT.Text = "I" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Miscellaneous Charges:"
                        End If
                        If Me.XrLabelFT.Text = "C" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Client Out of Pocket:"
                        End If
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "3" Then
                        Me.XrLabelGroupingTotalLabel.Text = "Total " & Me.XrLabelFH.Text & ":"
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "4" Then
                        Me.XrLabelGroupingTotalLabel.Text = ""
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "5" Then
                        If Me.XrLabelIO.Text = "I" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total " & _EstimatePrintingSetting.GroupingOptionInsideDescription & ":"
                        End If
                        If Me.XrLabelIO.Text = "O" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total " & _EstimatePrintingSetting.GroupingOptionOutsideDescription & ":"
                        End If
                        If Me.XrLabelIO.Text = "C" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Client Out of Pocket:"
                        End If
                    ElseIf _EstimatePrintingSetting.GroupingOptionGroupOption = "6" Then
                        Me.XrLabelGroupingTotalLabel.Text = "Total " & Me.XrLabelPhase.Text & ":"
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If _EstimatePrintSetting.GroupingOptionGroupOption = "2" Then
                        If Me.XrLabelFT.Text = "E" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Employee Time Charges:"
                        End If
                        If Me.XrLabelFT.Text = "V" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Vendor Charges:"
                        End If
                        If Me.XrLabelFT.Text = "I" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Miscellaneous Charges:"
                        End If
                        If Me.XrLabelFT.Text = "C" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Client Out of Pocket:"
                        End If
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "3" Then
                        Me.XrLabelGroupingTotalLabel.Text = "Total " & Me.XrLabelFH.Text & ":"
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "4" Then
                        Me.XrLabelGroupingTotalLabel.Text = ""
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "5" Then
                        If Me.XrLabelIO.Text = "I" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total " & _EstimatePrintSetting.GroupingOptionInsideDescription & ":"
                        End If
                        If Me.XrLabelIO.Text = "O" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total " & _EstimatePrintSetting.GroupingOptionOutsideDescription & ":"
                        End If
                        If Me.XrLabelIO.Text = "C" Then
                            Me.XrLabelGroupingTotalLabel.Text = "Total Client Out of Pocket:"
                        End If
                    ElseIf _EstimatePrintSetting.GroupingOptionGroupOption = "6" Then
                        Me.XrLabelGroupingTotalLabel.Text = "Total " & Me.XrLabelPhase.Text & ":"
                    End If
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub Label_FunctionHeadingDescription_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_FunctionHeadingDescription.BeforePrint
            Try

            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableCell7_InOut_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles TableCell7_InOut.BeforePrint
            Try
                If _EstimatePrintingSetting IsNot Nothing Then
                    If Me.TableCell7_InOut.Text = "I" Then
                        Me.TableCell7_InOut.Text = _EstimatePrintingSetting.GroupingOptionInsideDescription
                    End If
                    If Me.TableCell7_InOut.Text = "O" Then
                        Me.TableCell7_InOut.Text = _EstimatePrintingSetting.GroupingOptionOutsideDescription
                    End If
                ElseIf _EstimatePrintSetting IsNot Nothing Then
                    If Me.TableCell7_InOut.Text = "I" Then
                        Me.TableCell7_InOut.Text = _EstimatePrintSetting.GroupingOptionInsideDescription
                    End If
                    If Me.TableCell7_InOut.Text = "O" Then
                        Me.TableCell7_InOut.Text = _EstimatePrintSetting.GroupingOptionOutsideDescription
                    End If
                End If

                If Me.TableCell7_InOut.Text = "C" Then
                    Me.TableCell7_InOut.Text = "Client Out of Pocket"
                End If
            Catch ex As Exception

            End Try
        End Sub

        Private Sub TableCell_SubTotal_PrintOnPage(sender As Object, e As DevExpress.XtraReports.UI.PrintOnPageEventArgs) Handles TableCell_SubTotal.PrintOnPage
            Try
                If Me.TableCell_SubTotal.Text = "None" Then
                    Me.TableCell_SubTotal.Text = ""
                End If
            Catch ex As Exception

            End Try
        End Sub

        Friend WithEvents TopMarginBand1 As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents DetailBand1 As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents BottomMarginBand1 As DevExpress.XtraReports.UI.BottomMarginBand
        Friend WithEvents TopMarginBand2 As DevExpress.XtraReports.UI.TopMarginBand
        Friend WithEvents DetailBand2 As DevExpress.XtraReports.UI.DetailBand
        Friend WithEvents BottomMarginBand2 As DevExpress.XtraReports.UI.BottomMarginBand

#End Region

#End Region




    End Class

End Namespace
