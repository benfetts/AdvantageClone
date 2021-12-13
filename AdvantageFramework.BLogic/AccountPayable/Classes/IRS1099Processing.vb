Namespace AccountPayable.Classes

    <Serializable()>
    Public Class IRS1099Processing
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            Vendor1099Category
            PayToName
            PayToAddress
            PayToCity
            PayToState
            PayToZipCode
            FederalTaxID
            IncomeType
            TotalAmountPaid
        End Enum

#End Region

#Region " Variables "

        Private _Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Private _TotalAmountPaid As Decimal = 0

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False), _
        System.ComponentModel.Browsable(False), _
        Xml.Serialization.XmlIgnore()>
        Public WriteOnly Property Vendor As AdvantageFramework.Database.Entities.Vendor
            Set(value As AdvantageFramework.Database.Entities.Vendor)
                _Vendor = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property VendorCode As String
            Get
                VendorCode = _Vendor.Code
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property Vendor1099Category As Short
            Get
                Vendor1099Category = _Vendor.Vendor1099Category.GetValueOrDefault(0)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property PayToName As String
            Get
                If _Vendor.UseAlternativeNameFor1099 Then
                    PayToName = _Vendor.Vendor1099Name
                Else
                    If String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine1) AndAlso String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine2) Then
                        PayToName = _Vendor.Name
                    Else
                        PayToName = _Vendor.PayToName
                    End If
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property PayToAddress As String
            Get
                If _Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0) = 1 Then
                    PayToAddress = _Vendor.Vendor1099StreetAddressLine1
                Else
                    If String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine1) AndAlso String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine2) Then
                        PayToAddress = _Vendor.StreetAddressLine1
                    Else
                        PayToAddress = _Vendor.PayToAddressLine1
                    End If
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property PayToAddress2 As String
            Get
                If _Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0) = 1 Then
                    PayToAddress2 = _Vendor.Vendor1099StreetAddressLine2
                Else
                    If String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine1) AndAlso String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine2) Then
                        PayToAddress2 = _Vendor.StreetAddressLine2
                    Else
                        PayToAddress2 = _Vendor.PayToAddressLine2
                    End If
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property PayToAddress3 As String
            Get
                If _Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0) = 1 Then
                    PayToAddress3 = _Vendor.Vendor1099StreetAddressLine3
                Else
                    If String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine1) AndAlso String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine2) Then
                        PayToAddress3 = _Vendor.StreetAddressLine3
                    Else
                        PayToAddress3 = _Vendor.PayToStreetAddressLine3
                    End If
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property PayToCity As String
            Get
                If _Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0) = 1 Then
                    PayToCity = _Vendor.Vendor1099City
                Else
                    If String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine1) AndAlso String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine2) Then
                        PayToCity = _Vendor.City
                    Else
                        PayToCity = _Vendor.PayToCity
                    End If
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property PayToState As String
            Get
                If _Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0) = 1 Then
                    PayToState = _Vendor.Vendor1099State
                Else
                    If String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine1) AndAlso String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine2) Then
                        PayToState = _Vendor.State
                    Else
                        PayToState = _Vendor.PayToState
                    End If
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property PayToZipCode As String
            Get
                If _Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0) = 1 Then
                    PayToZipCode = _Vendor.Vendor1099ZipCode
                Else
                    If String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine1) AndAlso String.IsNullOrWhiteSpace(_Vendor.PayToAddressLine2) Then
                        PayToZipCode = _Vendor.ZipCode
                    Else
                        PayToZipCode = _Vendor.PayToZipCode
                    End If
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property FederalTaxID As String
            Get
                FederalTaxID = _Vendor.TaxID
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property IncomeType As String
            Get
                Select Case Me.Vendor1099Category

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.NonEmployeeCompensation

                        IncomeType = "Non Employee Compensation"

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.OtherIncome

                        IncomeType = "Other Income"

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.Rent

                        IncomeType = "Rent"

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.Royalties

                        IncomeType = "Royalties"

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.GrossProceedsToAttorney

                        IncomeType = "Gross Proceeds to Attorney"

                    Case AdvantageFramework.Database.Entities.Vendor1099Category.MedicalAndHealthCare

                        IncomeType = "Medical and Health Care"

                    Case Else

                        IncomeType = "Non Employee Compensation"

                End Select
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n2")>
        Public ReadOnly Property TotalAmountPaid As Decimal
            Get
                TotalAmountPaid = _TotalAmountPaid
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            _Vendor = New AdvantageFramework.Database.Entities.Vendor

        End Sub
        Public Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal VendorPayToCode As String, TotalAmountPaid As Decimal)

            _Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorPayToCode)

            _TotalAmountPaid = TotalAmountPaid

        End Sub
        Public Overrides Function ToString() As String

            ToString = _Vendor.Code

        End Function
        Public Overrides Function ValidateCustomProperties(ByVal PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = ""
            Dim PropertyValue As Object = Nothing

            Select Case PropertyName

                Case AdvantageFramework.AccountPayable.Classes.IRS1099Processing.Properties.FederalTaxID.ToString

                    PropertyValue = Value

                    If AdvantageFramework.StringUtilities.RemoveAllNonNumeric(PropertyValue).Length <> 9 Then

                        IsValid = False

                        ErrorText = "Federal Tax ID must be nine digits in length."

                    End If

            End Select

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace

