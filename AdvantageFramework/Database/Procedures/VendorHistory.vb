Namespace Database.Procedures.VendorHistory

    <HideModuleName()> _
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Action
            [NEW]
            DELETED
            FROM
            [TO]
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByVendorCode(ByVal DbContext As Database.DbContext, ByVal VendorCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorHistory)

            LoadByVendorCode = From VendorHistory In DbContext.GetQuery(Of Database.Entities.VendorHistory)
                               Where VendorHistory.Code = VendorCode
                               Select VendorHistory

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorHistory)

            Load = From VendorHistory In DbContext.GetQuery(Of Database.Entities.VendorHistory)
                   Select VendorHistory

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorHistory As AdvantageFramework.Database.Entities.VendorHistory) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.VendorHistorys.Add(VendorHistory)

                ErrorText = VendorHistory.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function CreateFromVendorUpdate(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal OriginalVendor As AdvantageFramework.Database.Entities.Vendor,
                                               ByVal NewVendor As AdvantageFramework.Database.Entities.Vendor) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""
            Dim FromVendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing
            Dim ToVendorHistory As AdvantageFramework.Database.Entities.VendorHistory = Nothing

            Try

                If OriginalVendor IsNot Nothing AndAlso NewVendor IsNot Nothing Then

                    FromVendorHistory = New AdvantageFramework.Database.Entities.VendorHistory
                    ToVendorHistory = New AdvantageFramework.Database.Entities.VendorHistory

                    LoadVendorHistory(FromVendorHistory, OriginalVendor)
                    LoadVendorHistory(ToVendorHistory, NewVendor)

                    'FromVendorHistory.ID = Nothing
                    'FromVendorHistory.MergeNewCode = 
                    FromVendorHistory.Action = "FROM"
                    FromVendorHistory.DateTime = System.DateTime.Now
                    FromVendorHistory.[Date] = FromVendorHistory.DateTime
                    FromVendorHistory.User = DbContext.UserCode
                    FromVendorHistory.DbContext = DbContext

                    'ToVendorHistory.ID = Nothing
                    'ToVendorHistory.MergeNewCode = 
                    ToVendorHistory.Action = "TO"
                    ToVendorHistory.DateTime = FromVendorHistory.DateTime
                    ToVendorHistory.[Date] = FromVendorHistory.DateTime
                    ToVendorHistory.User = DbContext.UserCode
                    ToVendorHistory.DbContext = DbContext

                    If Insert(DbContext, FromVendorHistory) AndAlso Insert(DbContext, ToVendorHistory) Then

                        Created = True

                    End If

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateFromVendorUpdate = Created
            End Try

        End Function
        Public Function CreateFromVendorAdd(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim IsValid As Boolean = True
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory
            Dim ErrorText As String = ""

            Try

                VendorHistory = New AdvantageFramework.Database.Entities.VendorHistory

                LoadVendorHistory(VendorHistory, Vendor)

                'VendorHistory.ID = Nothing
                'VendorHistory.MergeNewCode = 
                VendorHistory.Action = "NEW"
                VendorHistory.DateTime = System.DateTime.Now
                VendorHistory.[Date] = VendorHistory.DateTime
                VendorHistory.User = DbContext.UserCode
                VendorHistory.DbContext = DbContext

                If Insert(DbContext, VendorHistory) Then

                    Created = True

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateFromVendorAdd = Created
            End Try

        End Function
        Public Function CreateFromVendorDelete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor) As Boolean

            'objects
            Dim Created As Boolean = False
            Dim IsValid As Boolean = True
            Dim VendorHistory As AdvantageFramework.Database.Entities.VendorHistory
            Dim ErrorText As String = ""

            Try

                VendorHistory = New AdvantageFramework.Database.Entities.VendorHistory

                LoadVendorHistory(VendorHistory, Vendor)

                'VendorHistory.ID = Nothing
                'VendorHistory.MergeNewCode = 
                VendorHistory.Action = "DELETED"
                VendorHistory.DateTime = System.DateTime.Now
                VendorHistory.[Date] = VendorHistory.DateTime
                VendorHistory.User = DbContext.UserCode
                VendorHistory.DbContext = DbContext

                If Insert(DbContext, VendorHistory) Then

                    Created = True

                End If

            Catch ex As Exception
                Created = False
            Finally
                CreateFromVendorDelete = Created
            End Try

        End Function
        Private Sub LoadVendorHistory(ByRef VendorHistory As AdvantageFramework.Database.Entities.VendorHistory, ByVal Vendor As AdvantageFramework.Database.Entities.Vendor)

            If VendorHistory IsNot Nothing AndAlso Vendor IsNot Nothing Then

                VendorHistory.VendorCategory = Vendor.VendorCategory
                VendorHistory.ActiveFlag = Vendor.ActiveFlag
                VendorHistory.Code = Vendor.Code
                VendorHistory.Name = Vendor.Name
                VendorHistory.Address1 = Vendor.StreetAddressLine1
                VendorHistory.Address2 = Vendor.StreetAddressLine2
                VendorHistory.Address3 = Vendor.StreetAddressLine3
                VendorHistory.City = Vendor.City
                VendorHistory.County = Vendor.County
                VendorHistory.State = Vendor.State
                VendorHistory.Country = Vendor.Country
                VendorHistory.Zip = Vendor.ZipCode
                VendorHistory.Phone = Vendor.PhoneNumber
                VendorHistory.PhoneExt = Vendor.FaxPhoneNumberExtension
                VendorHistory.Fax = Vendor.FaxPhoneNumber
                VendorHistory.FaxExt = Vendor.FaxPhoneNumberExtension
                VendorHistory.Email = Vendor.EmailAddress
                VendorHistory.PayToCode = Vendor.PayToCode
                VendorHistory.PayToName = Vendor.PayToName
                VendorHistory.PayToAddress1 = Vendor.PayToAddressLine1
                VendorHistory.PayToAddress2 = Vendor.PayToAddressLine2
                VendorHistory.PayToAddress3 = Vendor.PayToStreetAddressLine3
                VendorHistory.PayToCity = Vendor.PayToCity
                VendorHistory.PayToCounty = Vendor.PayToCounty
                VendorHistory.PayToState = Vendor.PayToState
                VendorHistory.PayToCountry = Vendor.PayToCountry
                VendorHistory.PayToZip = Vendor.PayToZipCode
                VendorHistory.PayToPhone = Vendor.PayToPhoneNumber
                VendorHistory.PayToPhoneExt = Vendor.PayToPhoneNumberExtension
                VendorHistory.PayToFax = Vendor.PayToFaxPhoneNumber
                VendorHistory.PayToFaxExt = Vendor.PayToFaxPhoneNumberExtension
                VendorHistory.PayToEmail = Vendor.PayToEmail
                VendorHistory.Vendor1099Address1 = Vendor.Vendor1099StreetAddressLine1
                VendorHistory.Vendor1099Address2 = Vendor.Vendor1099StreetAddressLine2
                VendorHistory.Vendor1099Address3 = Vendor.Vendor1099StreetAddressLine3
                VendorHistory.Vendor1099City = Vendor.Vendor1099City
                VendorHistory.Vendor1099County = Vendor.Vendor1099County
                VendorHistory.Vendor1099State = Vendor.Vendor1099State
                VendorHistory.Vendor1099Country = Vendor.Vendor1099Country
                VendorHistory.Vendor1099Zip = Vendor.Vendor1099ZipCode
                VendorHistory.Vendor1099Flag = Vendor.Vendor1099Flag
                VendorHistory.Vendor1099UseAddress = Vendor.Vendor1099Flag
                VendorHistory.Vendor1099Category = Vendor.Vendor1099Category
                VendorHistory.DefaultTermCode = Vendor.VendorTermCode
                VendorHistory.TaxID = Vendor.TaxID
                VendorHistory.SortName = Vendor.SortName
                VendorHistory.DefaultAPAccount = Vendor.DefaultAPAccount
                VendorHistory.DefaultExpenseAccount = Vendor.DefaultExpenseAccount
                VendorHistory.AccountNumber = Vendor.AccountNumber
                VendorHistory.OfficeCode = Vendor.OfficeCode
                VendorHistory.DefaultFunctionCode = Vendor.FunctionCode
                VendorHistory.EmployeeVendor = Vendor.EmployeeVendor
                VendorHistory.DefaultVendorContact = Vendor.DefaultVendorContactCode
                VendorHistory.OneCheckPerInvoice = Vendor.OneCheckPerInvoice
                VendorHistory.WebSite = Vendor.Website
                VendorHistory.CurrencyCode = Vendor.CurrencyCode
                VendorHistory.PaymentManagerEmail = Vendor.PaymentManagerEmailAddress

            End If

        End Sub

#End Region

    End Module

End Namespace
