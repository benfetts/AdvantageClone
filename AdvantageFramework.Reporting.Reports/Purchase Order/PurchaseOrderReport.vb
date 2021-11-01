Imports System.Drawing.Printing

Namespace PurchaseOrder

    Public Class PurchaseOrderReport
        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _DefaultLocation As AdvantageFramework.Database.Entities.Location = Nothing
        Private _PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
        Private _FooterAboveSignature As Boolean = False
        Private _UsePrintedDate As Date = Nothing
        Private _UserDefinedReportID As Integer = 0
        Private _PrintCardInfo As Boolean = False
        Private _ChargeTo As String = Nothing
        Private _AgencyList As Generic.List(Of AdvantageFramework.Database.Entities.Agency) = Nothing
        Private _LocationLogo As AdvantageFramework.Database.Entities.LocationLogo = Nothing
        Private _Clientname As String = ""

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
        Public WriteOnly Property DefaultLocation As AdvantageFramework.Database.Entities.Location
            Set(value As AdvantageFramework.Database.Entities.Location)
                _DefaultLocation = value
            End Set
        End Property
        Public WriteOnly Property PrintDefaults As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault
            Set(value As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault)
                _PurchaseOrderPrintDefault = value
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
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.PurchaseOrder
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public WriteOnly Property ClientName As String
            Set(value As String)
                _Clientname = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function LoadCurrentPurchaseOrder() As AdvantageFramework.Database.Entities.PurchaseOrder

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Try

                PurchaseOrder = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.PurchaseOrder)

            Catch ex As Exception
                PurchaseOrder = Nothing
            Finally
                LoadCurrentPurchaseOrder = PurchaseOrder
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
        Private Function LoadFooterComments(ByRef FontSize As Short?) As String

            'objects
            Dim FooterComments As String = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                If PurchaseOrder IsNot Nothing Then

                    FooterComments = AdvantageFramework.PurchaseOrders.GetFooterText(_Session, PurchaseOrder, FontSize)

                End If

            Catch ex As Exception
                FooterComments = ""
            Finally
                LoadFooterComments = FooterComments
            End Try

        End Function
        Private Function FormatAddress(ByVal HeaderLines As String(), ByVal Address1 As String, ByVal Address2 As String, ByVal Address3 As String,
                                       ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal County As String, ByVal Country As String,
                                       ByVal Phone As String, ByVal PhoneExt As String, ByVal Fax As String, ByVal FaxExt As String) As String()

            'objects
            Dim AddressLines As Generic.List(Of String) = Nothing
            Dim CityStateZip As String = Nothing

            AddressLines = New Generic.List(Of String)

            If HeaderLines IsNot Nothing AndAlso HeaderLines.Any Then

                For Each HeaderLine In HeaderLines

                    AddressLines.Add(HeaderLine)

                Next

            End If

            If String.IsNullOrWhiteSpace(Address1) = False Then

                AddressLines.Add(Address1)

            End If

            If String.IsNullOrWhiteSpace(Address2) = False Then

                AddressLines.Add(Address2)

            End If

            If String.IsNullOrWhiteSpace(Address3) = False Then

                AddressLines.Add(Address3)

            End If

            If String.IsNullOrWhiteSpace(City) = False Then

                CityStateZip = City

            End If

            If String.IsNullOrWhiteSpace(State) = False Then

                CityStateZip &= If(String.IsNullOrEmpty(CityStateZip) = False, ", ", "") & State

            End If

            If String.IsNullOrWhiteSpace(Zip) = False Then

                CityStateZip &= If(String.IsNullOrEmpty(CityStateZip) = False, " ", "") & Zip

            End If

            If String.IsNullOrEmpty(CityStateZip) = False Then

                AddressLines.Add(CityStateZip)

            End If

            If String.IsNullOrEmpty(County) = False Then

                AddressLines.Add(County)

            End If

            If String.IsNullOrEmpty(Country) = False Then

                AddressLines.Add(Country)

            End If

            If String.IsNullOrEmpty(Phone) = False Then

                If String.IsNullOrEmpty(PhoneExt) = False Then

                    AddressLines.Add(String.Format("{0:(###) ###-####}", Phone) & " Ext: " & PhoneExt)

                Else

                    AddressLines.Add(String.Format("{0:(###) ###-####}", Phone))

                End If

            End If

            If String.IsNullOrEmpty(Fax) = False Then

                If String.IsNullOrEmpty(FaxExt) = False Then

                    AddressLines.Add(String.Format("{0:(###) ###-####}", Fax) & " Ext: " & FaxExt & " Fax")

                Else

                    AddressLines.Add(String.Format("{0:(###) ###-####}", Fax) & " Fax")

                End If

            End If

            If AddressLines IsNot Nothing AndAlso AddressLines.Count > 0 Then

                FormatAddress = AddressLines.ToArray

            Else

                FormatAddress = Nothing

            End If

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim FileName As String = Nothing
            Dim VCCCardPO As AdvantageFramework.Database.Entities.VCCCardPO = Nothing

            Try

                PurchaseOrder = DirectCast(Me.DataSource, IEnumerable(Of AdvantageFramework.Database.Entities.PurchaseOrder)).SingleOrDefault

            Catch ex As Exception
                PurchaseOrder = Nothing
            End Try

            If PurchaseOrder IsNot Nothing Then

                FileName = "PURCHASE_ORDER_" & AdvantageFramework.StringUtilities.PadWithCharacter(PurchaseOrder.Number.ToString, 8, "0", True, False)

            Else

                FileName = "PURCHASE_ORDER_REPORT"

            End If

            FileName = FileName & "_" & System.DateTime.Today.Year.ToString & System.DateTime.Today.Month.ToString & System.DateTime.Today.Day.ToString

            Me.ExportOptions.PrintPreview.DefaultFileName = FileName

            If _Session IsNot Nothing AndAlso PurchaseOrder IsNot Nothing Then

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _PrintCardInfo = DbContext.Database.SqlQuery(Of Boolean)("SELECT CAST(AGY_SETTINGS_VALUE as bit) FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'VCC_INCLUDE_CARDINFO'").FirstOrDefault

                    If _PrintCardInfo Then

                        _AgencyList = New Generic.List(Of AdvantageFramework.Database.Entities.Agency)

                        _AgencyList.Add(AdvantageFramework.Database.Procedures.Agency.Load(DbContext))

                        VCCCardPO = (From Entity In AdvantageFramework.Database.Procedures.VCCCardPO.Load(DbContext)
                                     Where Entity.PONumber = PurchaseOrder.Number
                                     Select Entity).SingleOrDefault

                        If VCCCardPO IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(VCCCardPO.CardNumber) Then

                            _ChargeTo = VCCCardPO.CardNumber + " - " + VCCCardPO.ExpirationDate.ToString("MM/dd/yyyy") + " - " + VCCCardPO.CVCCode

                        End If

                    End If

                    If _DefaultLocation IsNot Nothing Then

                        _LocationLogo = AdvantageFramework.Database.Procedures.LocationLogo.LoadByLocationAndLocationLogoTypeID(DbContext, _DefaultLocation.ID, AdvantageFramework.Database.Entities.LocationLogoTypes.HeaderPortrait)

                    Else

                        _LocationLogo = Nothing

                    End If

                End Using

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub Label_To_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_To.BeforePrint

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim HeaderLines As Generic.List(Of String) = Nothing
            Dim AddressString As String() = Nothing
            Dim VendorName As String = Nothing
            Dim PayToCode As String = Nothing
            Dim PayToName As String = Nothing
            Dim PayToAddress As String = Nothing
            Dim PayToAddress2 As String = Nothing
            Dim PayToAddress3 As String = Nothing
            Dim PayToCity As String = Nothing
            Dim PayToState As String = Nothing
            Dim PayToZip As String = Nothing
            Dim PayToCounty As String = Nothing
            Dim PayToCountry As String = Nothing
            Dim PayToPhone As String = Nothing
            Dim PayToPhoneExt As String = Nothing
            Dim PayToFax As String = Nothing
            Dim PayToFaxExt As String = Nothing

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AdvantageFramework.PurchaseOrders.LoadVendorPayToInformation(DbContext, PurchaseOrder.VendorCode, Name, PayToCode, PayToName, PayToAddress, PayToAddress2, PayToAddress3,
                                                                                 PayToCity, PayToCounty, PayToState, PayToZip, PayToCountry, PayToPhone, PayToPhoneExt, PayToFax, PayToFaxExt)

                    HeaderLines = New Generic.List(Of String)

                    If _PurchaseOrderPrintDefault IsNot Nothing Then

                        If _PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0) = 1 Then

                            HeaderLines.Add("vendor: " & PurchaseOrder.VendorCode)

                        End If

                    End If

                    HeaderLines.Add(Name)

                    AddressString = FormatAddress(HeaderLines.ToArray, PayToAddress, PayToAddress2, PayToAddress3, PayToCity, PayToState,
                                                  PayToZip, PayToCounty, PayToCountry, PayToPhone, PayToPhoneExt, PayToFax, PayToFaxExt)

                End Using

            Catch ex As Exception
                AddressString = Nothing
            Finally

                Label_To.Lines = AddressString

            End Try

        End Sub
        Private Sub Label_Originator_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Originator.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim EmployeeName As String = Nothing

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                    EmployeeName = Employee.FirstName & If(String.IsNullOrEmpty(Employee.MiddleInitial) = False, " " & Employee.MiddleInitial & ". ", " ") & Employee.LastName

                End Using

            Catch ex As Exception
                EmployeeName = Nothing
            Finally
                Label_Originator.Text = EmployeeName
            End Try

        End Sub
        Private Sub Label_PONumber_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_PONumber.BeforePrint

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim PONumber As String = Nothing

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                If PurchaseOrder IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PONumber = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDisplayNumber(DbContext, PurchaseOrder.Number)

                    End Using

                End If

                If IsNumeric(PONumber) Then

                    PONumber = AdvantageFramework.PurchaseOrders.FormatPurchaseOrderNumber(PONumber)

                End If

            Catch ex As Exception
                PONumber = Nothing
            Finally
                Label_PONumber.Text = PONumber
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
        Private Sub LabelFooter_LocationInfo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelFooter_LocationInfo.BeforePrint

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
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Fax), CBool(_DefaultLocation.PrintFaxFooter.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Email, CBool(_DefaultLocation.PrintEmailFooter.GetValueOrDefault(0)), LocationInfo)

                    LocationString = String.Join(" • ", LocationInfo)

                End If

            Catch ex As Exception
                LocationString = ""
            Finally
                LabelFooter_LocationInfo.Text = LocationString
            End Try

        End Sub
        Private Sub LabelHeader_Location_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_Location.BeforePrint

            'objects
            Dim LocationInfo As Generic.List(Of String) = Nothing
            Dim LocationString As String = Nothing
            Dim CityStateZipLine As String = Nothing

            Try

                If _DefaultLocation IsNot Nothing Then

                    If _DefaultLocation.PrintHeader.GetValueOrDefault(0) = 1 Then

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

                        BuildLocationString(_DefaultLocation.Name, CBool(_DefaultLocation.PrintNameHeader.GetValueOrDefault(0)), LocationInfo)
                        BuildLocationString(_DefaultLocation.Address, CBool(_DefaultLocation.PrintAddressHeader.GetValueOrDefault(0)), LocationInfo)
                        BuildLocationString(_DefaultLocation.Address2, CBool(_DefaultLocation.PrintAddress2Header.GetValueOrDefault(0)), LocationInfo)
                        BuildLocationString(CityStateZipLine, Not String.IsNullOrEmpty(CityStateZipLine), LocationInfo)
                        BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Phone), CBool(_DefaultLocation.PrintPhoneHeader.GetValueOrDefault(0)), LocationInfo)
                        BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Fax), CBool(_DefaultLocation.PrintFaxHeader.GetValueOrDefault(0)), LocationInfo)
                        BuildLocationString(_DefaultLocation.Email, CBool(_DefaultLocation.PrintEmailHeader.GetValueOrDefault(0)), LocationInfo)

                        LocationString = String.Join(" • ", LocationInfo)

                    End If

                End If

            Catch ex As Exception
                LocationString = ""
            Finally
                LabelHeader_Location.Text = LocationString
            End Try

        End Sub
        Private Sub SubReport_PurchaseOrderDetails_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubReport_PurchaseOrderDetails.BeforePrint

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DirectCast(SubReport_PurchaseOrderDetails.ReportSource, AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderDetailsSubReport).PurchaseOrderPrintDefault = _PurchaseOrderPrintDefault

                    SubReport_PurchaseOrderDetails.ReportSource.DataSource = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(DbContext, LoadCurrentPurchaseOrder().Number).ToList

                End Using

            Catch ex As Exception
                SubReport_PurchaseOrderDetails.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub Label_Attention_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Attention.BeforePrint

            'objects
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim ContactName As String = ""
            Dim Visible As Boolean = False
            Dim AddressLines As String() = Nothing

            Try

                If _PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0) = 1 Then

                    Visible = True

                    PurchaseOrder = LoadCurrentPurchaseOrder()

                    If PurchaseOrder IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(DbContext, PurchaseOrder.VendorCode, PurchaseOrder.VendorContactCode)

                            If VendorContact IsNot Nothing Then

                                ContactName = VendorContact.FirstName & " " & If(String.IsNullOrEmpty(VendorContact.MiddleInitial), "", VendorContact.MiddleInitial & ". ") & VendorContact.LastName

                                AddressLines = FormatAddress({ContactName}, VendorContact.Address1, VendorContact.Address2, Nothing, VendorContact.City, VendorContact.State, VendorContact.Zip,
                                                             VendorContact.County, VendorContact.Country, VendorContact.Phone, VendorContact.PhoneExt, VendorContact.Fax, VendorContact.FaxExt)

                            End If

                        End Using

                    End If

                End If

            Catch ex As Exception
                Visible = False
                AddressLines = Nothing
            Finally
                Label_Attention.Visible = Visible
                Label_Attention.Lines = AddressLines
            End Try

        End Sub
        Private Sub LabelHeader_Attention_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_Attention.BeforePrint

            'objects
            Dim Visible As Boolean = False
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                If PurchaseOrder IsNot Nothing Then

                    If CBool(_PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0)) = True Then

                        Visible = Not [String].IsNullOrWhiteSpace(PurchaseOrder.VendorContactCode)

                    Else

                        Visible = False

                    End If

                End If

            Catch ex As Exception
                Visible = False
            Finally
                LabelHeader_Attention.Visible = Visible
            End Try

        End Sub
        Private Sub Label_Description_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Description.BeforePrint

            'objects
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim Lines As String() = Nothing
            Dim Values As Generic.List(Of String) = Nothing
            Dim Visible As Boolean = False

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                If PurchaseOrder IsNot Nothing Then

                    Values = New Generic.List(Of String)

                    If String.IsNullOrWhiteSpace(PurchaseOrder.Description) = False Then

                        Values.Add("Description: " & PurchaseOrder.Description)

                    End If

                    If _PurchaseOrderPrintDefault IsNot Nothing Then

                        If _PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0) = 1 Then

                            If String.IsNullOrWhiteSpace(PurchaseOrder.MainInstruction) = False Then

                                Values.Add("Instructions: " & PurchaseOrder.MainInstruction)

                            End If

                        End If

                    End If

                    If Values IsNot Nothing Then

                        Lines = Values.ToArray

                    End If

                End If

                If Lines IsNot Nothing AndAlso Lines.Count > 0 Then

                    Visible = True

                End If

            Catch ex As Exception
                Lines = Nothing
            Finally
                Label_Description.Lines = Lines
                Label_Description.Visible = Visible
            End Try

        End Sub
        Private Sub LabelHeader_ShippingInstructions_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_ShippingInstructions.BeforePrint

            'objects
            Dim Visible As Boolean = False
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                If PurchaseOrder IsNot Nothing Then

                    If _PurchaseOrderPrintDefault IsNot Nothing Then

                        If _PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0) = 1 Then

                            If String.IsNullOrWhiteSpace(PurchaseOrder.DeliveryInstruction) = False Then

                                Visible = True

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                Visible = False
            Finally
                LabelHeader_ShippingInstructions.Visible = Visible
            End Try

        End Sub
        Private Sub Label_ShippingInstructions_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_ShippingInstructions.BeforePrint

            'objects
            Dim Visible As Boolean = False

            Try

                If _PurchaseOrderPrintDefault IsNot Nothing Then

                    If _PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0) = 1 Then

                        Visible = True

                    End If

                End If

            Catch ex As Exception
                Visible = False
            Finally
                Label_ShippingInstructions.Visible = Visible
            End Try

        End Sub
        Private Sub Label_FooterBelowSignature_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_FooterBelowSignature.BeforePrint

            'objects
            Dim Visible As Boolean = False
            Dim Text As String = ""
            Dim FontSize As Short? = Nothing

            Try

                If _FooterAboveSignature = False Then

                    If _PurchaseOrderPrintDefault IsNot Nothing Then

                        If _PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0) = 1 Then

                            Visible = True
                            Text = LoadFooterComments(FontSize)

                        End If

                    End If

                End If

            Catch ex As Exception
                Visible = False
            Finally

                Label_FooterBelowSignature.CanGrow = True
                Label_FooterBelowSignature.Multiline = True
                Label_FooterBelowSignature.Visible = Visible
                Label_FooterBelowSignature.Text = Text

                If FontSize.GetValueOrDefault(0) > 0 Then

                    Label_FooterBelowSignature.Font = New System.Drawing.Font(Label_FooterBelowSignature.Font.FontFamily, FontSize)

                End If

            End Try

        End Sub
        Private Sub Label_FooterAboveSignature_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_FooterAboveSignature.BeforePrint

            'objects
            Dim Visible As Boolean = False
            Dim Text As String = ""
            Dim FontSize As Short? = Nothing

            Try

                If _FooterAboveSignature = True Then

                    If _PurchaseOrderPrintDefault IsNot Nothing Then

                        If _PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0) = 1 Then

                            Visible = True
                            Text = LoadFooterComments(FontSize)

                        End If

                    End If

                End If

            Catch ex As Exception
                Visible = False
            Finally

                Label_FooterAboveSignature.CanGrow = True
                Label_FooterAboveSignature.Multiline = True
                Label_FooterAboveSignature.Visible = Visible
                Label_FooterAboveSignature.Text = Text

                If FontSize.GetValueOrDefault(0) > 0 Then

                    Label_FooterAboveSignature.Font = New System.Drawing.Font(Label_FooterAboveSignature.Font.FontFamily, FontSize)

                End If

            End Try

        End Sub
        Private Sub PictureBox_EmployeeSignature_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PictureBox_EmployeeSignature.BeforePrint

            'objects
            Dim Visible As Boolean = True
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            Try

                If _PurchaseOrderPrintDefault IsNot Nothing Then

                    If _PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0) = 1 Then

                        Visible = False

                    End If

                End If

                If Visible Then

                    PurchaseOrder = LoadCurrentPurchaseOrder()

                    If PurchaseOrder IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If CBool(_PurchaseOrderPrintDefault.UseUserSignature.GetValueOrDefault(0)) Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Session.User.EmployeeCode)

                            Else

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, PurchaseOrder.EmployeeCode)

                            End If

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
        Private Sub Label_IssueDate_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_IssueDate.BeforePrint

            'objects
            Dim IssueDate As Date = Nothing

            Try

                If _UsePrintedDate <> Nothing Then

                    IssueDate = _UsePrintedDate

                Else

                    IssueDate = LoadCurrentPurchaseOrder().Date

                End If

            Catch ex As Exception
                IssueDate = Nothing
            Finally
                Label_IssueDate.Text = IssueDate.ToShortDateString
            End Try

        End Sub
        Private Sub LabelRevised_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelRevised.BeforePrint

            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            PurchaseOrder = LoadCurrentPurchaseOrder()

            If PurchaseOrder IsNot Nothing AndAlso PurchaseOrder.Revision.GetValueOrDefault(0) > 0 Then

                LabelRevised.Text = "**Revision " & PurchaseOrder.Revision.Value.ToString.PadLeft(3, "0") & "**"

            End If

        End Sub
        Private Sub LabelFooter_DateToPrint_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelFooter_DateToPrint.BeforePrint

            'objects
            Dim IssueDate As Date = Nothing

            Try

                If _UsePrintedDate <> Nothing Then

                    IssueDate = _UsePrintedDate

                Else

                    IssueDate = LoadCurrentPurchaseOrder().Date

                End If

            Catch ex As Exception
                IssueDate = Nothing
            Finally
                LabelFooter_DateToPrint.Text = IssueDate.ToShortDateString
            End Try

        End Sub
        Private Sub GroupFooter_ChargeToSubReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooter_ChargeToSubReport.BeforePrint

            If _PrintCardInfo = False OrElse String.IsNullOrWhiteSpace(_ChargeTo) Then

                e.Cancel = True

            Else

                GroupFooter_ChargeToSubReport.ReportSource.DataSource = _AgencyList

                DirectCast(GroupFooter_ChargeToSubReport.ReportSource, AdvantageFramework.Reporting.Reports.MediaManager.ChargeToSubReport).ChargeTo = _ChargeTo

            End If

        End Sub

        Private Sub XrLabel1_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel1.BeforePrint
            If _PurchaseOrderPrintDefault IsNot Nothing Then

                If _PurchaseOrderPrintDefault.UseLocationName.GetValueOrDefault(0) = 1 Then

                    XrLabel1.Text = _DefaultLocation.Name & " Authorization:"

                End If

            End If

            If _PurchaseOrderPrintDefault IsNot Nothing Then

                If _PurchaseOrderPrintDefault.UseClientName.GetValueOrDefault(0) = 1 Then

                    XrLabel1.Text = "Agency Authorization as agent for " & _Clientname & ":"

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
