Namespace InvoicePrinting.Classes

    <Serializable()>
    Public Class AutoEmailContact

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            ClientContactID
            ClientContactCode
            ClientContactName
            Type
            ContactTypeID
            Email
            Print
            EmailAddress
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _ClientContactID As Integer = Nothing
        Private _ClientContactCode As String = Nothing
        Private _ClientContactName As String = Nothing
        Private _Type As String = Nothing
        Private _ContactTypeID As Nullable(Of Integer) = Nothing
        Private _Email As Boolean = Nothing
        Private _Print As Boolean = Nothing
        Private _EmailAddress As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ClientContactID() As Integer
            Get
                ClientContactID = _ClientContactID
            End Get
            Set(ByVal value As Integer)
                _ClientContactID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Contact Code")>
        Public Property ClientContactCode() As String
            Get
                ClientContactCode = _ClientContactCode
            End Get
            Set(value As String)
                _ClientContactCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Contact Name")>
        Public Property ClientContactName() As String
            Get
                ClientContactName = _ClientContactName
            End Get
            Set(ByVal value As String)
                _ClientContactName = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property Type() As String
            Get
                Type = _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ContactTypeID, CustomColumnCaption:="Contact Type")>
        Public Property ContactTypeID() As Nullable(Of Integer)
            Get
                ContactTypeID = _ContactTypeID
            End Get
            Set(value As Nullable(Of Integer))
                _ContactTypeID = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Email() As Boolean
            Get
                Email = _Email
            End Get
            Set(value As Boolean)
                _Email = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Print() As Boolean
            Get
                Print = _Print
            End Get
            Set(value As Boolean)
                _Print = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.Email)>
        Public Property EmailAddress() As String
            Get
                EmailAddress = _EmailAddress
            End Get
            Set(value As String)
                _EmailAddress = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function
        Public Sub New(ClientAccountsReceivableStatement As AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement,
                       AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            _ClientCode = ClientAccountsReceivableStatement.ClientCode
            _ClientName = AccountReceivableInvoice.ClientName
            _DivisionCode = Nothing
            _DivisionName = Nothing
            _ProductCode = Nothing
            _ProductName = Nothing
            _ClientContactID = ClientAccountsReceivableStatement.ClientContactID
            _ClientContactCode = ClientAccountsReceivableStatement.ContactCode
            _ClientContactName = ClientAccountsReceivableStatement.ClientContact.FirstName & " " & ClientAccountsReceivableStatement.ClientContact.LastName
            _Type = If(AccountReceivableInvoice.RecordType = "P", "Production", "Media")
            _ContactTypeID = ClientAccountsReceivableStatement.ClientContact.ContactTypeID
            _Email = CBool(ClientAccountsReceivableStatement.DistributeViaEmail)
            _Print = CBool(ClientAccountsReceivableStatement.DistributeViaPrint)
            _EmailAddress = ClientAccountsReceivableStatement.ClientContact.EmailAddress

        End Sub
        Public Sub New(ProductAccountsReceivableStatement As AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement,
                       AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            _ClientCode = ProductAccountsReceivableStatement.ClientCode
            _ClientName = AccountReceivableInvoice.ClientName
            _DivisionCode = ProductAccountsReceivableStatement.DivisionCode
            _DivisionName = AccountReceivableInvoice.DivisionName
            _ProductCode = ProductAccountsReceivableStatement.ProductCode
            _ProductName = AccountReceivableInvoice.ProductName
            _ClientContactID = ProductAccountsReceivableStatement.ClientContactID
            _ClientContactCode = ProductAccountsReceivableStatement.ClientContactCode
            _ClientContactName = ProductAccountsReceivableStatement.ClientContact.FirstName & " " & ProductAccountsReceivableStatement.ClientContact.LastName
            _Type = If(AccountReceivableInvoice.RecordType = "P", "Production", "Media")
            _ContactTypeID = ProductAccountsReceivableStatement.ClientContact.ContactTypeID
            _Email = CBool(ProductAccountsReceivableStatement.DistributeViaEmail)
            _Print = CBool(ProductAccountsReceivableStatement.DistributeViaPrint)
            _EmailAddress = ProductAccountsReceivableStatement.ClientContact.EmailAddress

        End Sub

#End Region

    End Class

End Namespace
