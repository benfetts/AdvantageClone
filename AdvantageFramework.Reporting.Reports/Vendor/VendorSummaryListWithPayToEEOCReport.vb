Namespace Vendor

    Public Class VendorSummaryListWithPayToEEOCReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PayToVendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AlternatePayToVendor As Boolean = False
        Private _PayToVendorTested As Boolean = False
        Private _AgencyName As String = ""
        Private _SortedBy As String = ""
        Private _Date As String = String.Empty

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
        Public WriteOnly Property SortedBy As String
            Set(value As String)
                _SortedBy = value
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

        Private Sub VendorSummaryListWithPayToEEOCReport_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_DateAndUserCode.Text = _Date & vbTab & _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub LabelHeader_SortedBy_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelHeader_SortedBy.BeforePrint

            LabelHeader_SortedBy.Text = _SortedBy

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
        Private Sub Label_PayToCityStateZip_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_PayToCityStateZip.BeforePrint

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
                Label_PayToCityStateZip.Text = PayToCityStateZip
            End Try

        End Sub
        Private Sub Label_GLAccount_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Label_GLAccount.BeforePrint

            'objects
            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim GeneralLedgerDescription As String = ""

            Try

                Vendor = LoadCurrentVendor()

                If Vendor IsNot Nothing AndAlso String.IsNullOrEmpty(Vendor.DefaultAPAccount) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, Vendor.DefaultAPAccount)

                    End Using

                End If

                If GeneralLedgerAccount IsNot Nothing Then

                    GeneralLedgerDescription = GeneralLedgerAccount.ToString

                End If

            Catch ex As Exception
                GeneralLedgerDescription = ""
            Finally
                Label_GLAccount.Text = GeneralLedgerDescription
            End Try

        End Sub

#End Region

#End Region
        
    End Class

End Namespace
