Namespace Services.CSIPreferredPartner.Classes

    Public Class CSIVendorFile

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PayToVendorName
            VendorID
            Type
            Address1
            Address2
            City
            State
            Zip
            Phone
            Fax
            Website
            SICCode
            Industry
            Notes
            Client
            Status
            AutoEnroll
            AnnualPayable
            EnrollmentDate
            ReasonRemoved
            EnrollmentMethod
            AccountOwner
            RemittanceContactName
            RemittancePhone
            ParentCompany
            ContactEmail
            RemittanceEmail
            TaxID
            Country
            APGLACode
            SpecialTerms
            CSIVendorID
            CreatedDate
            VendorName
            NumberOfTransactions
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <System.ComponentModel.DisplayName("VendorName")>
        Public Property PayToVendorName As String = ""
        Public Property VendorID As String = ""
        Public Property Type As String = ""
        Public Property Address1 As String = ""
        Public Property Address2 As String = ""
        Public Property City As String = ""
        Public Property State As String = ""
        Public Property Zip As String = ""
        Public Property Phone As String = ""
        Public Property Fax As String = ""
        Public Property Website As String = ""
        Public Property SICCode As String = ""
        Public Property Industry As String = ""
        Public Property Notes As String = ""
        Public Property Client As String = ""
        Public Property Status As String = ""
        Public Property AutoEnroll As String = ""
        Public Property AnnualPayable As String = ""
        Public Property EnrollmentDate As String = ""
        Public Property ReasonRemoved As String = ""
        Public Property EnrollmentMethod As String = ""
        Public Property AccountOwner As String = ""
        Public Property RemittanceContactName As String = ""
        Public Property RemittancePhone As String = ""
        Public Property ParentCompany As String = ""
        Public Property ContactEmail As String = ""
        Public Property RemittanceEmail As String = ""
        Public Property TaxID As String = ""
        Public Property Country As String = ""
        Public Property APGLACode As String = ""
        Public Property SpecialTerms As Integer = 0
        Public Property CSIVendorID As String = ""
        Public Property CreatedDate As String = ""
        Public Property VendorName As String = ""
        Public Property NumberOfTransactions As Integer = 0

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(Vendor As AdvantageFramework.Database.Entities.Vendor,
                       PayToVendor As AdvantageFramework.Database.Entities.Vendor,
                       VendorHistory As AdvantageFramework.Database.Entities.VendorHistory,
                       VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference)

            If PayToVendor Is Nothing Then

                If String.IsNullOrWhiteSpace(Vendor.PayToName) Then

                    Me.PayToVendorName = Vendor.Name

                Else

                    Me.PayToVendorName = Vendor.PayToName

                End If

            Else

                Me.PayToVendorName = PayToVendor.Name

            End If

            Me.VendorID = Vendor.Code
            Me.Type = Vendor.VendorCategory
            Me.Address1 = Vendor.StreetAddressLine1
            Me.Address2 = Vendor.StreetAddressLine2
            Me.City = Vendor.City
            Me.State = Vendor.State
            Me.Zip = Vendor.ZipCode
            Me.Phone = Vendor.PhoneNumber
            Me.Fax = Vendor.FaxPhoneNumber
            Me.Website = Vendor.Website
            Me.Notes = Vendor.Notes
            Me.Status = Vendor.VCCStatus.GetValueOrDefault(0)
            Me.ContactEmail = Vendor.EmailAddress
            Me.RemittanceEmail = Vendor.PaymentManagerEmailAddress
            Me.TaxID = Vendor.TaxID
            Me.Country = Vendor.Country
            Me.APGLACode = Vendor.DefaultAPAccount
            Me.SpecialTerms = If(Vendor.HasSpecialTerms.GetValueOrDefault(False) = True, 1, 0)

            If VendorCrossReference IsNot Nothing Then

                Me.CSIVendorID = VendorCrossReference.SourceVendorCode

            End If

            If VendorHistory IsNot Nothing Then

                Me.CreatedDate = VendorHistory.Date.ToShortDateString

            End If

            Me.VendorName = Vendor.Name

        End Sub
        Public Sub New(Vendor As AdvantageFramework.Database.Entities.Vendor, PayToVendor As AdvantageFramework.Database.Entities.Vendor,
                       VendorHistory As AdvantageFramework.Database.Entities.VendorHistory, VendorCrossReference As AdvantageFramework.Database.Entities.VendorCrossReference, AnnualPayable As Decimal, NumberOfTransactions As Integer)

            Me.New(Vendor, PayToVendor, VendorHistory, VendorCrossReference)

            Me.AnnualPayable = AnnualPayable
            Me.NumberOfTransactions = NumberOfTransactions

        End Sub

#End Region

    End Class

End Namespace

