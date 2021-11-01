Namespace AccountPayable.Classes

    <Serializable()>
    Public Class AccountPayableAvailableInternetOrders
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            VendorCode
            ClientCode
            DivisionCode
            ProductCode
            OrderNumber
            LineNumber
            InsertDate
            OrderDescription
            Placement
            LinkID
            ClientPO
            OfficeCode
            EndDate
            Type
        End Enum

#End Region

#Region " Variables "

        Private _VendorCode As String = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _OrderNumber As Integer = Nothing
        Private _LineNumber As Short = Nothing
        Private _InsertDate As Nullable(Of Date) = Nothing
        Private _OrderDescription As String = Nothing
        Private _LinkID As Nullable(Of Integer) = Nothing
        Private _ClientPO As String = Nothing
        Private _OfficeCode As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public ReadOnly Property ID() As String
            Get
                ID = Me.OrderNumber & "|" & Me.LineNumber
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Vendor")>
        Public Property VendorCode() As String
            Get
                VendorCode = _VendorCode
            End Get
            Set(ByVal value As String)
                _VendorCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client")>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(ByVal value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Division")>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(ByVal value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Product")>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(ByVal value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Order #")>
        Public Property OrderNumber() As Integer
            Get
                OrderNumber = _OrderNumber
            End Get
            Set(ByVal value As Integer)
                _OrderNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Line")>
        Public Property LineNumber() As Short
            Get
                LineNumber = _LineNumber
            End Get
            Set(ByVal value As Short)
                _LineNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Date")>
        Public Property InsertDate() As Nullable(Of Date)
            Get
                InsertDate = _InsertDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _InsertDate = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Description")>
        Public Property OrderDescription() As String
            Get
                OrderDescription = _OrderDescription
            End Get
            Set(ByVal value As String)
                _OrderDescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Placement() As String
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Link ID")>
        Public Property LinkID() As Nullable(Of Integer)
            Get
                LinkID = _LinkID
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _LinkID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Client PO")>
        Public Property ClientPO() As String
            Get
                ClientPO = _ClientPO
            End Get
            Set(ByVal value As String)
                _ClientPO = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
            Get
                OfficeCode = _OfficeCode
            End Get
            Set(value As String)
                _OfficeCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EndDate() As Nullable(Of Date)
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Type() As String

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
