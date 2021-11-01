Namespace PurchaseOrder

    Public Class PurchaseOrderStandardFormatReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _DefaultLocation As AdvantageFramework.Database.Entities.Location = Nothing
        Private _PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing

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

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub Label_To_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_To.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim VendorAddress As Generic.List(Of String) = Nothing
            Dim CityStateString As String = ""

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                Using ObjectContext = New AdvantageFramework.Database.ObjectContext(_Session.ConnectionString, _Session.UserCode)

                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(ObjectContext, PurchaseOrder.VendorCode)

                    VendorAddress = New Generic.List(Of String)

                    VendorAddress.Add(Vendor.Name)

                    If String.IsNullOrEmpty(Vendor.StreetAddressLine1) = False Then

                        VendorAddress.Add(Vendor.StreetAddressLine1)

                    End If

                    If String.IsNullOrEmpty(Vendor.StreetAddressLine2) = False Then

                        VendorAddress.Add(Vendor.StreetAddressLine2)

                    End If

                    If String.IsNullOrEmpty(Vendor.StreetAddressLine3) = False Then

                        VendorAddress.Add(Vendor.StreetAddressLine3)

                    End If

                    If String.IsNullOrEmpty(Vendor.City) = False Then

                        CityStateString = Vendor.City

                    End If

                    If String.IsNullOrEmpty(Vendor.State) = False Then

                        CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, ", ", "") & Vendor.State

                    End If

                    If String.IsNullOrEmpty(Vendor.ZipCode) = False Then

                        CityStateString &= If(String.IsNullOrEmpty(CityStateString) = False, " ", "") & Vendor.ZipCode

                    End If

                    If String.IsNullOrEmpty(CityStateString) = False Then

                        VendorAddress.Add(CityStateString)

                    End If

                    If String.IsNullOrEmpty(Vendor.County) = False Then

                        VendorAddress.Add(Vendor.County)

                    End If

                    If String.IsNullOrEmpty(Vendor.Country) = False Then

                        VendorAddress.Add(Vendor.Country)

                    End If

                    If String.IsNullOrEmpty(Vendor.PhoneNumber) = False Then

                        If String.IsNullOrEmpty(Vendor.PhoneNumberExtension) = False Then

                            VendorAddress.Add(String.Format("{0:(###) ###-####}", Vendor.PhoneNumber) & " Ext: " & Vendor.PhoneNumberExtension)

                        Else

                            VendorAddress.Add(String.Format("{0:(###) ###-####}", Vendor.PhoneNumber))

                        End If

                    End If

                    If String.IsNullOrEmpty(Vendor.FaxPhoneNumber) = False Then

                        If String.IsNullOrEmpty(Vendor.FaxPhoneNumberExtension) = False Then

                            VendorAddress.Add(String.Format("{0:(###) ###-####}", Vendor.FaxPhoneNumber) & " Ext: " & Vendor.FaxPhoneNumberExtension & " Fax")

                        Else

                            VendorAddress.Add(String.Format("{0:(###) ###-####}", Vendor.FaxPhoneNumber) & " Fax")

                        End If

                    End If

                End Using

            Catch ex As Exception
                VendorAddress = Nothing
            Finally

                If VendorAddress IsNot Nothing Then

                    Label_To.Lines = VendorAddress.ToArray

                Else

                    Label_To.Text = ""

                End If

            End Try

        End Sub
        Private Sub Label_Originator_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Originator.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing
            Dim EmployeeName As String = Nothing

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                Using ObjectContext = New AdvantageFramework.Database.ObjectContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(ObjectContext, PurchaseOrder.EmployeeCode)

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

                PONumber = AdvantageFramework.PurchaseOrders.FormatPurchaseOrderNumber(PurchaseOrder.Number)

            Catch ex As Exception
                PONumber = Nothing
            Finally
                Label_PONumber.Text = PONumber
            End Try


        End Sub
        Private Sub LabelHeader_Location_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_Location.BeforePrint

            'objects
            Dim LocationInfo As Generic.List(Of String) = Nothing
            Dim LocationString As String = Nothing
            Dim CityStateZipLine As String = Nothing

            Try

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

                    BuildLocationString(_DefaultLocation.Address, CBool(_DefaultLocation.PrintAddressHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Address2, CBool(_DefaultLocation.PrintAddress2Header.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(CityStateZipLine, Not String.IsNullOrEmpty(CityStateZipLine), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Phone), CBool(_DefaultLocation.PrintPhoneHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Fax), CBool(_DefaultLocation.PrintFaxHeader.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Email, CBool(_DefaultLocation.PrintEmailHeader.GetValueOrDefault(0)), LocationInfo)

                    LocationString = String.Join(" • ", LocationInfo)

                End If

            Catch ex As Exception
                LocationString = ""
            Finally
                LabelHeader_Location.Text = LocationString
            End Try

        End Sub
        Private Sub PictureBoxHeader_Logo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PictureBoxHeader_Logo.BeforePrint

            'objects
            Dim Image As Object = Nothing
            Dim LogoVisible As Boolean = False

            Try

                If _DefaultLocation IsNot Nothing Then

                    If _DefaultLocation.LogoLocation <> "N" Then

                        LogoVisible = True
                        Image = System.Drawing.Image.FromFile(_DefaultLocation.LogoPath)

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
        Private Sub LabelPageHeader_Agency_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_Agency.BeforePrint

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
                LabelPageHeader_Agency.Visible = AgencyNameVisible
            End Try
            
        End Sub
        Private Sub LabelFooter_LocationInfo_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelFooter_LocationInfo.BeforePrint

            'objects
            Dim LocationInfo As Generic.List(Of String) = Nothing
            Dim LocationString As String = Nothing
            Dim CityStateZipLine As String = Nothing
            Dim PrintFooter As Boolean = False

            Try

                If _DefaultLocation.PrintFooter.GetValueOrDefault(0) = 1 Then

                    PrintFooter = True

                    If CBool(_DefaultLocation.PrintCityFooter.GetValueOrDefault(0)) Then

                        CityStateZipLine = _DefaultLocation.City

                    End If

                    If CBool(_DefaultLocation.PrintStateFooter.GetValueOrDefault(0)) Then

                        CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, ", ", "") & _DefaultLocation.State

                    End If

                    If CBool(_DefaultLocation.PrintZipFooter.GetValueOrDefault(0)) Then

                        CityStateZipLine = CityStateZipLine & If(String.IsNullOrEmpty(CityStateZipLine) = False, " ", "") & _DefaultLocation.Zip

                    End If

                    BuildLocationString(_DefaultLocation.Address, CBool(_DefaultLocation.PrintAddressFooter.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Address2, CBool(_DefaultLocation.PrintAddress2Footer.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(CityStateZipLine, Not String.IsNullOrEmpty(CityStateZipLine), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Phone), CBool(_DefaultLocation.PrintPhoneFooter.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(String.Format("{0:(###) ###-####}", _DefaultLocation.Fax), CBool(_DefaultLocation.PrintFaxFooter.GetValueOrDefault(0)), LocationInfo)
                    BuildLocationString(_DefaultLocation.Email, CBool(_DefaultLocation.PrintEmailFooter.GetValueOrDefault(0)), LocationInfo)

                    LocationString = String.Join(" \u2022 ", LocationInfo)

                End If

            Catch ex As Exception
                PrintFooter = False
                LocationString = ""
            Finally
                LabelFooter_LocationInfo.Visible = PrintFooter
                LabelFooter_LocationInfo.Text = LocationString
            End Try

        End Sub
        Private Sub SubReport_PurchaseOrderDetails_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles SubReport_PurchaseOrderDetails.BeforePrint

            Try

                Using ObjectContext = New AdvantageFramework.Database.ObjectContext(_Session.ConnectionString, _Session.UserCode)

                    DirectCast(SubReport_PurchaseOrderDetails.ReportSource, AdvantageFramework.Reporting.Reports.PurchaseOrder.PurchaseOrderDetailsSubReport).PurchaseOrderPrintDefault = _PurchaseOrderPrintDefault

                    SubReport_PurchaseOrderDetails.ReportSource.DataSource = AdvantageFramework.PurchaseOrders.LoadPurchaseOrderDetails(ObjectContext, LoadCurrentPurchaseOrder().Number).ToList

                End Using

            Catch ex As Exception
                SubReport_PurchaseOrderDetails.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub Label_Attention_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_Attention.BeforePrint

            'objects
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim LabelText As String = ""
            Dim Visible As Boolean = False

            Try

                If _PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0) = 1 Then

                    Visible = True

                    Using ObjectContext = New AdvantageFramework.Database.ObjectContext(_Session.ConnectionString, _Session.UserCode)

                        VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(ObjectContext, "", "")

                        If VendorContact IsNot Nothing Then

                            LabelText = VendorContact.FirstName & " " & If(String.IsNullOrEmpty(VendorContact.MiddleInitial), "", VendorContact.MiddleInitial & ". ") & VendorContact.LastName

                        End If

                    End Using

                End If

            Catch ex As Exception
                Visible = False
                LabelText = False
            Finally
                Label_Attention.Visible = Visible
                Label_Attention.Text = LabelText
            End Try

        End Sub
        Private Sub LabelHeader_Attention_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_Attention.BeforePrint

            'objects
            Dim Visible As Boolean = False

            Try

                If _PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0) = 1 Then

                    Visible = True

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

            Try

                PurchaseOrder = LoadCurrentPurchaseOrder()

                If PurchaseOrder IsNot Nothing Then

                    Values = New Generic.List(Of String)

                    Values.Add("Description: " & PurchaseOrder.Description)

                    If _PurchaseOrderPrintDefault IsNot Nothing Then

                        If _PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0) = 1 Then

                            Values.Add("Instructions: " & PurchaseOrder.MainInstruction)

                        End If

                    End If

                    If Values IsNot Nothing Then

                        Lines = Values.ToArray

                    End If

                End If

            Catch ex As Exception
                Lines = Nothing
            Finally
                Label_Description.Lines = Lines
            End Try

        End Sub
        Private Sub LabelHeader_ShippingInstructions_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelHeader_ShippingInstructions.BeforePrint

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
        Private Sub Label_FooterComments_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_FooterComments.BeforePrint

            'objects
            Dim Visible As Boolean = False

            Try

                If _PurchaseOrderPrintDefault IsNot Nothing Then

                    If _PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0) = 1 Then

                        Visible = True

                    End If

                End If

            Catch ex As Exception
                Visible = False
            Finally
                Label_FooterComments.CanGrow = True
                Label_FooterComments.Multiline = True
                Label_FooterComments.Visible = Visible
            End Try

        End Sub

#End Region

#End Region
        
    End Class

End Namespace
