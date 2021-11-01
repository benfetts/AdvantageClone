Namespace AccountPayable.Classes

    <Serializable()>
    Public Class IRS1099AllVendorsSummaryReport
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorPayToCode
            VendorName
            VendorTaxID
            TotalAmountPaid
            Is1099
            IsActive
            APAccount
            BankCode
            Vendor1099Category
            VendorCode
        End Enum

#End Region

#Region " Variables "

        Private _VendorPayToCode As String = Nothing
        Private _VendorName As String = Nothing
        Private _VendorTaxID As String = Nothing
        Private _TotalAmountPaid As Decimal = Nothing
        Private _Is1099 As Boolean = Nothing
        Private _IsActive As Boolean = Nothing
        Private _APAccount As String = Nothing
        Private _BankCode As String = Nothing
        Private _Vendor1099Category As Integer = Nothing
        Private _VendorCode As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorPayToCode() As String
            Get
                VendorPayToCode = _VendorPayToCode
            End Get
            Set(ByVal value As String)
                _VendorPayToCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName() As String
            Get
                VendorName = _VendorName
            End Get
            Set(ByVal value As String)
                _VendorName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorTaxID() As String
            Get
                VendorTaxID = _VendorTaxID
            End Get
            Set(ByVal value As String)
                _VendorTaxID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property TotalAmountPaid() As Decimal
            Get
                TotalAmountPaid = _TotalAmountPaid
            End Get
            Set(ByVal value As Decimal)
                _TotalAmountPaid = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Is1099() As Boolean
            Get
                Is1099 = _Is1099
            End Get
            Set(ByVal value As Boolean)
                _Is1099 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsActive() As Boolean
            Get
                IsActive = _IsActive
            End Get
            Set(ByVal value As Boolean)
                _IsActive = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property APAccount() As String
            Get
                APAccount = _APAccount
            End Get
            Set(ByVal value As String)
                _APAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property BankCode() As String
            Get
                BankCode = _BankCode
            End Get
            Set(ByVal value As String)
                _BankCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Vendor1099Category() As Integer
            Get
                Vendor1099Category = _Vendor1099Category
            End Get
            Set(ByVal value As Integer)
                _Vendor1099Category = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace