Namespace PurchaseOrders.Classes

    <Serializable()>
    Public Class PurchaseOrderDetailAPInfo
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            InvoiceNumber
            InvoiceDate
            InvoiceAmount
            FunctionCode
            FunctionDescription
            NonbillableFlag
            GeneralLedgerCode
            Quantity
            Rate
            Amount
        End Enum

#End Region

#Region " Variables "

        Private _InvoiceNumber As String = Nothing
        Private _InvoiceDate As Date = Nothing
        Private _InvoiceAmount As Decimal = Nothing
        Private _FunctionCode As String = Nothing
        Private _FunctionDescription As String = Nothing
        Private _NonbillableFlag As Nullable(Of Short) = Nothing
        Private _GeneralLedgerCode As String = Nothing
        Private _Quantity As Nullable(Of Decimal) = Nothing
        Private _Rate As Nullable(Of Decimal) = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceNumber() As String
            Get
                InvoiceNumber = _InvoiceNumber
            End Get
            Set(ByVal value As String)
                _InvoiceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceDate() As Date
            Get
                InvoiceDate = _InvoiceDate
            End Get
            Set(ByVal value As Date)
                _InvoiceDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property InvoiceAmount() As Decimal
            Get
                InvoiceAmount = _InvoiceAmount
            End Get
            Set(ByVal value As Decimal)
                _InvoiceAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionCode() As String
            Get
                FunctionCode = _FunctionCode
            End Get
            Set(ByVal value As String)
                _FunctionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property FunctionDescription() As String
            Get
                FunctionDescription = _FunctionDescription
            End Get
            Set(ByVal value As String)
                _FunctionDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Non Bill", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property NonbillableFlag() As Nullable(Of Short)
            Get
                NonbillableFlag = _NonbillableFlag
            End Get
            Set(ByVal value As Nullable(Of Short))
                _NonbillableFlag = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GeneralLedgerCode() As String
            Get
                GeneralLedgerCode = _GeneralLedgerCode
            End Get
            Set(ByVal value As String)
                _GeneralLedgerCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Quantity() As Nullable(Of Decimal)
            Get
                Quantity = _Quantity
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Quantity = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Rate() As Nullable(Of Decimal)
            Get
                Rate = _Rate
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Rate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace


