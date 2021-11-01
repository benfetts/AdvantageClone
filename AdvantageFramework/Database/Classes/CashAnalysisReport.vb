Namespace Database.Classes

    <Serializable()>
    Public Class CashAnalysisReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            ClientCode
            ClientDescription
            ClientBilledFee
            ClientBilledCost
            ClientBilledTotal
            ClientCashFee
            ClientCashCost
            ClientCashTotal
            OpenARClientFee
            OpenARClientCost
            OpenARTotal
            ClientVendorInvoice
            NonBillableVendorInvoice
            VendorInvoiceTotal
            ClientVendorInvoicePaid
            NonBillableVendorInvoicePaid
            VendorInvoicePaidTotal
            ClientVendorInvoiceUnpaid
            NonBillableVendorUnpaid
            VendorInvoiceUnpaidTotal
            ClientVendorPaidUncleared
            NonBillableVendorUncleared
            VendorPaidUnclearedTotal
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientDescription As String = Nothing
        Private _ClientBilledFee As Nullable(Of Decimal) = Nothing
        Private _ClientBilledCost As Nullable(Of Decimal) = Nothing
        Private _ClientBilledTotal As Nullable(Of Decimal) = Nothing
        Private _ClientCashFee As Nullable(Of Decimal) = Nothing
        Private _ClientCashCost As Nullable(Of Decimal) = Nothing
        Private _ClientCashTotal As Nullable(Of Decimal) = Nothing
        Private _OpenARClientFee As Nullable(Of Decimal) = Nothing
        Private _OpenARClientCost As Nullable(Of Decimal) = Nothing
        Private _OpenARTotal As Nullable(Of Decimal) = Nothing
        Private _ClientVendorInvoice As Nullable(Of Decimal) = Nothing
        Private _NonBillableVendorInvoice As Nullable(Of Decimal) = Nothing
        Private _VendorInvoiceTotal As Nullable(Of Decimal) = Nothing
        Private _ClientVendorInvoicePaid As Nullable(Of Decimal) = Nothing
        Private _NonBillableVendorInvoicePaid As Nullable(Of Decimal) = Nothing
        Private _VendorInvoicePaidTotal As Nullable(Of Decimal) = Nothing
        Private _ClientVendorInvoiceUnpaid As Nullable(Of Decimal) = Nothing
        Private _NonBillableVendorUnpaid As Nullable(Of Decimal) = Nothing
        Private _VendorInvoiceUnpaidTotal As Nullable(Of Decimal) = Nothing
        Private _ClientVendorPaidUncleared As Nullable(Of Decimal) = Nothing
        Private _NonBillableVendorUncleared As Nullable(Of Decimal) = Nothing
        Private _VendorPaidUnclearedTotal As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ClientDescription() As String
            Get
                ClientDescription = _ClientDescription
            End Get
            Set(ByVal value As String)
                _ClientDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientBilledFee() As Nullable(Of Decimal)
            Get
                ClientBilledFee = _ClientBilledFee
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientBilledFee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientBilledCost() As Nullable(Of Decimal)
            Get
                ClientBilledCost = _ClientBilledCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientBilledCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientBilledTotal() As Nullable(Of Decimal)
            Get
                ClientBilledTotal = _ClientBilledTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientBilledTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientCashFee() As Nullable(Of Decimal)
            Get
                ClientCashFee = _ClientCashFee
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientCashFee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientCashCost() As Nullable(Of Decimal)
            Get
                ClientCashCost = _ClientCashCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientCashCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientCashTotal() As Nullable(Of Decimal)
            Get
                ClientCashTotal = _ClientCashTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientCashTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OpenARClientFee() As Nullable(Of Decimal)
            Get
                OpenARClientFee = _OpenARClientFee
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenARClientFee = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OpenARClientCost() As Nullable(Of Decimal)
            Get
                OpenARClientCost = _OpenARClientCost
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenARClientCost = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property OpenARTotal() As Nullable(Of Decimal)
            Get
                OpenARTotal = _OpenARTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _OpenARTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientVendorInvoice() As Nullable(Of Decimal)
            Get
                ClientVendorInvoice = _ClientVendorInvoice
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientVendorInvoice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NonBillableVendorInvoice() As Nullable(Of Decimal)
            Get
                NonBillableVendorInvoice = _NonBillableVendorInvoice
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableVendorInvoice = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorInvoiceTotal() As Nullable(Of Decimal)
            Get
                VendorInvoiceTotal = _VendorInvoiceTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VendorInvoiceTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientVendorInvoicePaid() As Nullable(Of Decimal)
            Get
                ClientVendorInvoicePaid = _ClientVendorInvoicePaid
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientVendorInvoicePaid = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NonBillableVendorInvoicePaid() As Nullable(Of Decimal)
            Get
                NonBillableVendorInvoicePaid = _NonBillableVendorInvoicePaid
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableVendorInvoicePaid = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorInvoicePaidTotal() As Nullable(Of Decimal)
            Get
                VendorInvoicePaidTotal = _VendorInvoicePaidTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VendorInvoicePaidTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientVendorInvoiceUnpaid() As Nullable(Of Decimal)
            Get
                ClientVendorInvoiceUnpaid = _ClientVendorInvoiceUnpaid
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientVendorInvoiceUnpaid = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NonBillableVendorUnpaid() As Nullable(Of Decimal)
            Get
                NonBillableVendorUnpaid = _NonBillableVendorUnpaid
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableVendorUnpaid = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorInvoiceUnpaidTotal() As Nullable(Of Decimal)
            Get
                VendorInvoiceUnpaidTotal = _VendorInvoiceUnpaidTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VendorInvoiceUnpaidTotal = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property ClientVendorPaidUncleared() As Nullable(Of Decimal)
            Get
                ClientVendorPaidUncleared = _ClientVendorPaidUncleared
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _ClientVendorPaidUncleared = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property NonBillableVendorUncleared() As Nullable(Of Decimal)
            Get
                NonBillableVendorUncleared = _NonBillableVendorUncleared
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _NonBillableVendorUncleared = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property VendorPaidUnclearedTotal() As Nullable(Of Decimal)
            Get
                VendorPaidUnclearedTotal = _VendorPaidUnclearedTotal
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _VendorPaidUnclearedTotal = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
