Namespace AccountPayable.Classes

    <Serializable()>
    Public Class IRS1099VendorBankCheckAmountTotal
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BankCode
            VendorPayToCode
            CheckAmountTotal
            Vendor1099Category
        End Enum

#End Region

#Region " Variables "

        Private _BankCode As String = Nothing
        Private _VendorPayToCode As String = Nothing
        Private _CheckAmountTotal As Decimal = Nothing
        Private _Vendor1099Category As Integer = Nothing

#End Region

#Region " Properties "

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
        Public Property VendorPayToCode() As String
            Get
                VendorPayToCode = _VendorPayToCode
            End Get
            Set(ByVal value As String)
                _VendorPayToCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property CheckAmountTotal() As Decimal
            Get
                CheckAmountTotal = _CheckAmountTotal
            End Get
            Set(ByVal value As Decimal)
                _CheckAmountTotal = value
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

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace