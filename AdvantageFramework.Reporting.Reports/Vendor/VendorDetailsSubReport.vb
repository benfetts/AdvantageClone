Namespace Vendor

    Public Class VendorDetailsSubReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PayToVendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AlternatePayToVendor As Boolean = False
        Private _PayToVendorTested As Boolean = False

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

#End Region

#Region " Methods "

        Private Function LoadCurrentVendor() As AdvantageFramework.Database.Entities.Vendor

            Try

                LoadCurrentVendor = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Entities.Vendor)

            Catch ex As Exception
                LoadCurrentVendor = Nothing
            End Try

        End Function
        Private Sub LoadPayToVendor()

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            If _PayToVendorTested = False Then

                Try

                    Vendor = LoadCurrentVendor()

                    If Vendor.Code <> Vendor.PayToCode Then

                        _AlternatePayToVendor = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            _PayToVendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, Vendor.PayToCode)

                        End Using

                    End If

                Catch ex As Exception
                    _AlternatePayToVendor = False
                    _PayToVendor = Nothing
                End Try

                _PayToVendorTested = True

            End If

        End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub Label_CityStateZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_CityStateZip.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim CityStateZip As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    CityStateZip = Vendor.City & ", " & Vendor.State & "  " & Vendor.ZipCode

                End If

            Catch ex As Exception
                CityStateZip = ""
            Finally
                Label_CityStateZip.Text = CityStateZip
            End Try

        End Sub
        Private Sub Label_Status_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Status.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Status As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Status = If(Vendor.ActiveFlag.GetValueOrDefault(0) = 0, "Inactive", "Active")

                End If

            Catch ex As Exception
                Status = ""
            Finally
                Label_Status.Text = Status
            End Try

        End Sub
        Private Sub Label_VendorCategory_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_VendorCategory.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Category As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Category = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorCategory)).ToList
                                Where EnumObject.Code.ToUpper = Vendor.VendorCategory.ToUpper
                                Select EnumObject.Description).SingleOrDefault

                End If

            Catch ex As Exception
                Category = ""
            Finally
                Label_VendorCategory.Text = Category
            End Try

        End Sub
        Private Sub Label_AllowedVendorCategories_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_AllowedVendorCategories.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim AllowedCategories As Generic.List(Of String) = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    AllowedCategories = New Generic.List(Of String)

                    If Vendor.InternetCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Internet.ToString))

                    End If

                    If Vendor.MagazineCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Magazine.ToString))

                    End If

                    If Vendor.NewspaperCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Newspaper.ToString))

                    End If

                    If Vendor.OutOfHomeCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.OutOfHome.ToString))

                    End If

                    If Vendor.RadioCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Radio.ToString))

                    End If

                    If Vendor.TVCategory.GetValueOrDefault(0) = 1 Then

                        AllowedCategories.Add(AdvantageFramework.StringUtilities.GetNameAsWords(AdvantageFramework.Database.Entities.VendorCategory.Television.ToString))

                    End If

                End If

            Catch ex As Exception
                AllowedCategories = Nothing
            Finally

                If AllowedCategories IsNot Nothing Then

                    Label_AllowedVendorCategories.Lines = AllowedCategories.ToArray

                Else

                    Label_AllowedVendorCategories.Text = ""

                End If

            End Try

        End Sub
        Private Sub Label_PayToCode_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCode.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            LoadPayToVendor()

            Vendor = LoadCurrentVendor()

            Label_PayToCode.Text = Vendor.PayToCode

        End Sub
        Private Sub Label_PayToName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToName.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PayToName As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToName = _PayToVendor.Name

                Else

                    Vendor = LoadCurrentVendor()

                    PayToName = Vendor.PayToName

                End If

            Catch ex As Exception
                PayToName = ""
            Finally
                Label_PayToName.Text = PayToName
            End Try

        End Sub
        Private Sub Label_PayToAddress1_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToAddress1.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PayToAddress1 As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToAddress1 = _PayToVendor.StreetAddressLine1

                Else

                    Vendor = LoadCurrentVendor()

                    PayToAddress1 = Vendor.PayToAddressLine1

                End If

            Catch ex As Exception
                PayToAddress1 = ""
            Finally
                Label_PayToAddress1.Text = PayToAddress1
            End Try

        End Sub
        Private Sub Label_PayToAddress2_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToAddress2.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PayToAddressLine2 As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToAddressLine2 = _PayToVendor.StreetAddressLine2

                Else

                    Vendor = LoadCurrentVendor()

                    PayToAddressLine2 = Vendor.PayToAddressLine2

                End If

            Catch ex As Exception
                PayToAddressLine2 = ""
            Finally
                Label_PayToAddress2.Text = PayToAddressLine2
            End Try

        End Sub
        Private Sub Label_PayToAddress3_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToAddress3.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PayToStreetAddressLine3 As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToStreetAddressLine3 = _PayToVendor.StreetAddressLine3

                Else

                    Vendor = LoadCurrentVendor()

                    PayToStreetAddressLine3 = Vendor.PayToStreetAddressLine3

                End If

            Catch ex As Exception
                PayToStreetAddressLine3 = ""
            Finally
                Label_PayToAddress3.Text = PayToStreetAddressLine3
            End Try

        End Sub
        Private Sub Label_PayToCounty_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCounty.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PayToCounty As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToCounty = _PayToVendor.County

                Else

                    Vendor = LoadCurrentVendor()

                    PayToCounty = Vendor.PayToCounty

                End If

            Catch ex As Exception
                PayToCounty = ""
            Finally
                Label_PayToCounty.Text = PayToCounty
            End Try

        End Sub
        Private Sub Label_PayToCountry_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCountry.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PayToCountry As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToCountry = _PayToVendor.Country

                Else

                    Vendor = LoadCurrentVendor()

                    PayToCountry = Vendor.PayToCountry

                End If

            Catch ex As Exception
                PayToCountry = ""
            Finally
                Label_PayToCountry.Text = PayToCountry
            End Try

        End Sub
        Private Sub Label_PayToCityStateAndZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCityStateAndZip.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PayToCityStateZip As String = ""

            Try

                LoadPayToVendor()

                If _AlternatePayToVendor Then

                    PayToCityStateZip = _PayToVendor.City & ", " & _PayToVendor.State & "  " & _PayToVendor.ZipCode

                Else

                    Vendor = LoadCurrentVendor()

                    PayToCityStateZip = Vendor.PayToCity & ", " & Vendor.PayToState & "  " & Vendor.PayToZipCode

                End If

            Catch ex As Exception
                PayToCityStateZip = ""
            Finally
                Label_PayToCityStateAndZip.Text = PayToCityStateZip
            End Try

        End Sub
        Private Sub Label_DefaultOffice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_DefaultOffice.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim OfficeName As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.OfficeCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Vendor.OfficeCode)

                        If Office IsNot Nothing Then

                            OfficeName = Office.Name

                        Else

                            OfficeName = "Not Assigned"

                        End If

                    End Using

                End If

            Catch ex As Exception
                OfficeName = "Not Assigned"
            Finally
                Label_DefaultOffice.Text = OfficeName
            End Try

        End Sub
        Private Sub Label_DefaultFunction_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_DefaultFunction.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim FunctionName As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.FunctionCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, Vendor.FunctionCode)

                        If [Function] IsNot Nothing Then

                            FunctionName = [Function].Code & " - " & [Function].Description

                        End If

                    End Using

                End If

            Catch ex As Exception
                FunctionName = ""
            Finally
                Label_DefaultFunction.Text = FunctionName
            End Try

        End Sub
        Private Sub Label_Terms_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_Terms.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorTerm As AdvantageFramework.Database.Entities.VendorTerm = Nothing
            Dim VendorTermName As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.VendorTermCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        VendorTerm = AdvantageFramework.Database.Procedures.VendorTerm.LoadByVendorTermCode(DbContext, Vendor.VendorTermCode)

                        If VendorTerm IsNot Nothing Then

                            VendorTermName = VendorTerm.Code & vbTab & VendorTerm.Description

                        End If

                    End Using

                End If

            Catch ex As Exception
                VendorTermName = ""
            Finally
                Label_Terms.Text = VendorTermName
            End Try

        End Sub
        Private Sub Label_SortOptions_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_SortOptions.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorSortKeys As Generic.List(Of AdvantageFramework.Database.Entities.VendorSortKey) = Nothing
            Dim SortOptions As Generic.List(Of String) = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    SortOptions = New Generic.List(Of String)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        VendorSortKeys = AdvantageFramework.Database.Procedures.VendorSortKey.LoadByVendorCode(DbContext, Vendor.Code).ToList

                        For Each VendorSortKey In VendorSortKeys

                            SortOptions.Add(VendorSortKey.SortKey)

                        Next

                    End Using

                End If

            Catch ex As Exception
                SortOptions = Nothing
            Finally

                If SortOptions IsNot Nothing Then

                    Label_SortOptions.Lines = SortOptions.ToArray

                Else

                    Label_SortOptions.Text = ""

                End If

            End Try

        End Sub
        Private Sub Label_EEOCStatus_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_EEOCStatus.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim EEOCStatuses As Generic.List(Of AdvantageFramework.Database.Entities.EEOCStatus) = Nothing
            Dim EEOCStatus As AdvantageFramework.Database.Entities.EEOCStatus = Nothing
            Dim VendorEEOCStatusList As Generic.List(Of String) = Nothing


            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        EEOCStatuses = AdvantageFramework.Database.Procedures.EEOCStatus.LoadByVendorCode(DataContext, Vendor.Code).ToList

                        VendorEEOCStatusList = New Generic.List(Of String)

                        For Each EEOCStatus In EEOCStatuses

                            Try

                                VendorEEOCStatusList.Add((From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.VendorEEOCStatus)).ToList
                                                          Where Entity.Code = EEOCStatus.EEOCCode
                                                          Select Entity.Description).SingleOrDefault & " (" & EEOCStatus.EEOCCode & ")")

                            Catch ex As Exception

                            End Try

                        Next

                    End Using

                End If

            Catch ex As Exception
                VendorEEOCStatusList = Nothing
            Finally

                If VendorEEOCStatusList IsNot Nothing Then

                    Label_EEOCStatus.Lines = VendorEEOCStatusList.ToArray

                Else

                    Label_EEOCStatus.Text = ""

                End If

            End Try

        End Sub
        Private Sub Checkbox_OneCheckPerInvoice_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Checkbox_OneCheckPerInvoice.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.OneCheckPerInvoice.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                Checkbox_OneCheckPerInvoice.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_EmployeeVendor_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_EmployeeVendor.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.EmployeeVendor.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_EmployeeVendor.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_ACH_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_ACH.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.IsACH.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_ACH.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_HasSpecialTerms_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_HasSpecialTerms.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Vendor.HasSpecialTerms.GetValueOrDefault(False)

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_HasSpecialTerms.Checked = Checked
            End Try

        End Sub
        Private Sub Label_ACHType_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_ACHType.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim ACHType As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    If Convert.ToBoolean(Vendor.IsACH.GetValueOrDefault(0)) Then

                        ACHType = Vendor.ACHType

                    End If

                End If

            Catch ex As Exception
                ACHType = ""
            Finally
                Label_ACHType.Text = ACHType
            End Try

        End Sub
        Private Sub Label_1099Category_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_1099Category.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Category As String = ""
            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Category = AdvantageFramework.EnumUtilities.GetNameAsWords(GetType(AdvantageFramework.Database.Entities.Vendor1099Category), Vendor.Vendor1099Category.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Category = ""
            Finally
                Label_1099Category.Text = Category
            End Try

        End Sub
        Private Sub CheckBox_1099Vendor_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_1099Vendor.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.Vendor1099Flag.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_1099Vendor.Checked = Checked
            End Try

        End Sub
        Private Sub CheckBox_1099Use1099Address_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles CheckBox_1099Use1099Address.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Convert.ToBoolean(Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0))

                End If

            Catch ex As Exception
                Checked = False
            Finally
                CheckBox_1099Use1099Address.Checked = Checked
            End Try

        End Sub
        Private Sub Label_1099CityStateZip_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_1099CityStateZip.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim PayToCityStateZip As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    PayToCityStateZip = Vendor.Vendor1099City & ", " & Vendor.Vendor1099State & "  " & Vendor.Vendor1099ZipCode

                End If

            Catch ex As Exception
                PayToCityStateZip = ""
            Finally
                Label_1099CityStateZip.Text = PayToCityStateZip
            End Try

        End Sub
        Private Sub Label_DefaultAP_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_DefaultAP.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccountName As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.DefaultAPAccount IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Vendor.DefaultAPAccount)

                        If GeneralLedgerAccount IsNot Nothing Then

                            GeneralLedgerAccountName = GeneralLedgerAccount.ToString

                        Else

                            GeneralLedgerAccountName = ""

                        End If

                    End Using

                End If

            Catch ex As Exception
                GeneralLedgerAccountName = ""
            Finally
                Label_DefaultAP.Text = GeneralLedgerAccountName
            End Try

        End Sub
        Private Sub Label_DefaultExpenseAccount_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_DefaultExpenseAccount.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerAccountName As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.DefaultExpenseAccount IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Vendor.DefaultExpenseAccount)

                        If GeneralLedgerAccount IsNot Nothing Then

                            GeneralLedgerAccountName = GeneralLedgerAccount.ToString

                        Else

                            GeneralLedgerAccountName = ""

                        End If

                    End Using

                End If

            Catch ex As Exception
                GeneralLedgerAccountName = ""
            Finally
                Label_DefaultExpenseAccount.Text = GeneralLedgerAccountName
            End Try

        End Sub
        Private Sub Label_DefaultBank_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_DefaultBank.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Bank As AdvantageFramework.Database.Entities.Bank = Nothing
            Dim BankName As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.BankCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Bank = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, Vendor.BankCode)

                        If Bank IsNot Nothing Then

                            BankName = Bank.ToString

                        Else

                            BankName = ""

                        End If

                    End Using

                End If

            Catch ex As Exception
                BankName = ""
            Finally
                Label_DefaultBank.Text = BankName
            End Try

        End Sub
        Private Sub Label_VCCStatus_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Label_VCCStatus.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VCCStatus As String = Nothing

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso Vendor.VCCStatus.HasValue Then

                    VCCStatus = AdvantageFramework.StringUtilities.GetNameAsWords([Enum].GetName(GetType(AdvantageFramework.Database.Entities.VCCStatuses), Vendor.VCCStatus))

                Else

                    VCCStatus = "[Open]"

                End If

            Catch ex As Exception
                VCCStatus = "[Open]"
            Finally
                Label_VCCStatus.Text = VCCStatus
            End Try

        End Sub
        Private Sub XrCheckBoxSendVCCWithMediaOrder_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles XrCheckBoxSendVCCWithMediaOrder.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim Checked As Boolean = False

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing Then

                    Checked = Vendor.SendVCCWithMediaOrder

                End If

            Catch ex As Exception
                Checked = False
            Finally
                XrCheckBoxSendVCCWithMediaOrder.Checked = Checked
            End Try

        End Sub

#End Region

#End Region

    End Class

End Namespace
