Namespace Database.Classes

    <Serializable()>
    Public Class VendorInvoice

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SequenceNumber
            InvoiceNumber
            InvoiceDate
            EntryDate
            InvoiceDescription
            InvoiceAmount
            ApprovalStatus
            IsPaymentOnHold
            Is1099Invoice
            VendorCode
            IsDeleted
        End Enum

#End Region

#Region " Variables "

        Private _ID As Integer = Nothing
        Private _SequenceNumber As Short = Nothing
        Private _InvoiceNumber As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _EntryDate As Nullable(Of Date) = Nothing
        Private _InvoiceDescription As String = Nothing
        Private _InvoiceAmount As Decimal = Nothing
        Private _IsPaymentOnHold As Boolean = Nothing
        Private _Is1099Invoice As Boolean = Nothing
        Private _VendorCode As String = Nothing
        Private _IsDeleted As Boolean = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As Integer
            Get
                ID = _ID
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property SequenceNumber() As Short
            Get
                SequenceNumber = _SequenceNumber
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property EntryDate() As Nullable(Of Date)
            Get
                If _EntryDate.GetValueOrDefault().ToShortDateString = "1/1/0001" Then
                    EntryDate = Nothing
                Else
                    EntryDate = _EntryDate.GetValueOrDefault().ToShortDateString
                End If
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property InvoiceDescription() As String
            Get
                InvoiceDescription = _InvoiceDescription
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property InvoiceAmount As Decimal
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property IsPaymentOnHold() As Boolean
            Get
                IsPaymentOnHold = _IsPaymentOnHold
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property Is1099Invoice() As Boolean
            Get
                Is1099Invoice = _Is1099Invoice
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property IsDeleted() As Boolean
            Get
                IsDeleted = _IsDeleted
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal AccountPayable As AdvantageFramework.Database.Entities.AccountPayable)

            _ID = AccountPayable.ID
            _SequenceNumber = AccountPayable.SequenceNumber
            _InvoiceNumber = AccountPayable.InvoiceNumber
            _InvoiceDate = AccountPayable.InvoiceDate
            _EntryDate = AccountPayable.CreatedDate.GetValueOrDefault(Nothing)
            _InvoiceDescription = AccountPayable.InvoiceDescription
            _InvoiceAmount = AccountPayable.InvoiceAmount + AccountPayable.ShippingAmount.GetValueOrDefault(0) + AccountPayable.SalesTaxAmount.GetValueOrDefault(0)
            _IsPaymentOnHold = CBool(AccountPayable.IsOnHold.GetValueOrDefault(0))
            _Is1099Invoice = CBool(AccountPayable.Is1099Invoice.GetValueOrDefault(0))
            _VendorCode = AccountPayable.VendorCode
            _IsDeleted = AccountPayable.Deleted.GetValueOrDefault(0)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace

