Namespace Database.Classes

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

        Public Enum CombinedFederalStateFilingCode As Short
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AL", "Alabama")>
            AL = 1
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AZ", "Arizona")>
            AZ = 4
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("AR", "Arkansas")>
            AR = 5
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CA", "California")>
            CA = 6
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CO", "Colorado")>
            CO = 7
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("CT", "Connecticut")>
            CT = 8
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("DE", "Delaware")>
            DE = 10
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("DC", "District of Columbia")>
            DC = 11
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("GA", "Georgia")>
            GA = 13
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("HI", "Hawaii")>
            HI = 15
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ID", "Idaho")>
            ID = 16
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IN", "Indiana")>
            [IN] = 18
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("IA", "Iowa")>
            IA = 19
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("KS", "Kansas")>
            KS = 20
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("LA", "Louisiana")>
            LA = 22
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ME", "Maine")>
            [ME] = 23
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MD", "Maryland")>
            MD = 24
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MA", "Massachusetts")>
            MA = 25
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MN", "Minnesota")>
            MN = 27
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MS", "Mississippi")>
            MS = 28
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MO", "Missouri")>
            MO = 29
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("MT", "Montana")>
            MT = 30
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NE", "Nebraska")>
            NE = 31
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NJ", "New Jersey")>
            NJ = 34
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NM", "New Mexico")>
            NM = 35
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("NC", "North Carolina")>
            NC = 37
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("ND", "North Dakota")>
            ND = 38
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("OH", "Ohio")>
            OH = 39
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("SC", "South Carolina")>
            SC = 45
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("UT", "Utah")>
            UT = 49
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("VA", "Viginia")>
            VA = 51
            <AdvantageFramework.EnumUtilities.Attributes.EnumObject("WI", "Wisconsin")>
            WI = 55
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
        Public Property Vendor As AdvantageFramework.Database.Entities.Vendor
            Get
                Vendor = _Vendor
            End Get
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
                PayToName = _Vendor.PayToName
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public ReadOnly Property PayToAddress As String
            Get
                If _Vendor.UseAlternativeAddressFor1099.GetValueOrDefault(0) = 1 Then
                    PayToAddress = _Vendor.Vendor1099StreetAddressLine1
                Else
                    PayToAddress = _Vendor.PayToAddressLine1
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
                    PayToCity = _Vendor.PayToCity
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
                    PayToState = _Vendor.PayToState
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
                    PayToZipCode = _Vendor.PayToZipCode
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
                Select Case Vendor.Vendor1099Category.GetValueOrDefault(0)

                    Case 0

                        IncomeType = "Non Employee Compensation"

                    Case 1

                        IncomeType = "Other Income"

                    Case 2

                        IncomeType = "Rent"

                    Case 3

                        IncomeType = "Royalties"

                    Case 4

                        IncomeType = "Gross Proceeds to Attorney"

                    Case Else

                        IncomeType = "Non Employee Compensation"

                End Select
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
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
        Public Sub New(ByVal ObjectContext As AdvantageFramework.Database.ObjectContext, ByVal VendorPayToCode As String, TotalAmountPaid As Decimal)

            _Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(ObjectContext, VendorPayToCode)

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

                Case AdvantageFramework.Database.Classes.IRS1099Processing.Properties.FederalTaxID.ToString

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

