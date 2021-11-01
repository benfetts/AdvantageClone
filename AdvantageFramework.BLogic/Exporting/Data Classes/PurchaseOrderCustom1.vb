Namespace Exporting.DataClasses

    <Serializable()>
    Public Class PurchaseOrderCustom1
        Implements AdvantageFramework.Exporting.Interfaces.IExportData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            PONumber
            [Date]
            VendorID
            Name
            LineNumber
            VendorItem
            QuantityOrdered
            UnitCost
            VendorDescription
            SiteID
            ExtendedCost
            Company
            PurchasesAccount
            RequiredDate
            CurrentPromisedDate
            PromisedShipDate
            RequestedBy
            ShippingMethod
        End Enum

#End Region

#Region " Variables "

        Private _PONumber As Integer = Nothing
        Private _Date As Nullable(Of Date) = Nothing
        Private _VendorID As String = Nothing
        Private _Name As String = Nothing
        Private _LineNumber As Integer = Nothing
        Private _VendorItem As String = Nothing
        Private _QuantityOrdered As Nullable(Of Integer) = Nothing
        Private _UnitCost As Nullable(Of Decimal) = Nothing
        Private _VendorDescription As String = Nothing
        Private _SiteID As String = Nothing
        Private _ExtendedCost As Nullable(Of Decimal) = Nothing
        Private _Company As String = Nothing
        Private _PurchasesAccount As String = Nothing
        Private _RequiredDate As Nullable(Of Date) = Nothing
        Private _CurrentPromisedDate As Nullable(Of Date) = Nothing
        Private _PromisedShipDate As Nullable(Of Date) = Nothing
        Private _RequestedBy As String = Nothing
        Private _ShippingMethod As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PONumber() As Integer
            Get
                PONumber = _PONumber
            End Get
            Set(value As Integer)
                _PONumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property [Date]() As Nullable(Of Date)
            Get
                [Date] = _Date
            End Get
            Set(value As Nullable(Of Date))
                _Date = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorID() As String
            Get
                VendorID = _VendorID
            End Get
            Set(value As String)
                _VendorID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Name() As String
            Get
                Name = _Name
            End Get
            Set(value As String)
                _Name = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property LineNumber() As Integer
            Get
                LineNumber = _LineNumber
            End Get
            Set(value As Integer)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorItem() As String
            Get
                VendorItem = _VendorItem
            End Get
            Set(value As String)
                _VendorItem = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", IsReadOnlyColumn:=True)>
        Public Property QuantityOrdered() As Nullable(Of Integer)
            Get
                QuantityOrdered = _QuantityOrdered
            End Get
            Set(value As Nullable(Of Integer))
                _QuantityOrdered = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n3", IsReadOnlyColumn:=True)>
        Public Property UnitCost As Nullable(Of Decimal)
            Get
                UnitCost = _UnitCost
            End Get
            Set(value As Nullable(Of Decimal))
                _UnitCost = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property VendorDescription() As String
            Get
                VendorDescription = _VendorDescription
            End Get
            Set(value As String)
                _VendorDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property SiteID() As String
            Get
                SiteID = _SiteID
            End Get
            Set(value As String)
                _SiteID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", IsReadOnlyColumn:=True)>
        Public Property ExtendedCost() As Nullable(Of Decimal)
            Get
                ExtendedCost = _ExtendedCost
            End Get
            Set(value As Nullable(Of Decimal))
                _ExtendedCost = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Company() As String
            Get
                Company = _Company
            End Get
            Set(value As String)
                _Company = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PurchasesAccount() As String
            Get
                PurchasesAccount = _PurchasesAccount
            End Get
            Set(value As String)
                _PurchasesAccount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property RequiredDate() As Nullable(Of Date)
            Get
                RequiredDate = _RequiredDate
            End Get
            Set(value As Nullable(Of Date))
                _RequiredDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CurrentPromisedDate() As Nullable(Of Date)
            Get
                CurrentPromisedDate = _CurrentPromisedDate
            End Get
            Set(value As Nullable(Of Date))
                _CurrentPromisedDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PromisedShipDate() As Nullable(Of Date)
            Get
                PromisedShipDate = _PromisedShipDate
            End Get
            Set(value As Nullable(Of Date))
                _PromisedShipDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property RequestedBy() As String
            Get
                RequestedBy = _RequestedBy
            End Get
            Set(value As String)
                _RequestedBy = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ShippingMethod() As String
            Get
                ShippingMethod = _ShippingMethod
            End Get
            Set(value As String)
                _ShippingMethod = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
