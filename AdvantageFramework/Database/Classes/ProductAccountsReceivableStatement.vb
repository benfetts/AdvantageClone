Namespace Database.Classes

    <Serializable()>
    Public Class ProductAccountsReceivableStatement
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            DivisionCode
            ProductCode
            DistributeViaEmail
            DistributeViaPrint
            UseAddress
            IncludeOnAccount
            ReportFormat
            LastEmailed
            LastPrinted
            ClientContactID
            ClientContactName
            ClientContactCode
            ClientContact
            ContactTypeID
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _DistributeViaEmail As Short = Nothing
        Private _DistributeViaPrint As Short = Nothing
        Private _UseAddress As Nullable(Of Short) = Nothing
        Private _IncludeOnAccount As Short = Nothing
        Private _ReportFormat As Nullable(Of Short) = Nothing
        Private _LastEmailed As Nullable(Of Date) = Nothing
        Private _LastPrinted As Nullable(Of Date) = Nothing
        Private _ClientContactID As Integer = Nothing
        Private _ClientContactName As String = Nothing
        Private _ClientContactCode As String = Nothing
        Private _ContactTypeID As Nullable(Of Integer) = Nothing
        Private _ProductAccountsReceivableStatement As AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Client", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Division", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Product", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Contact Code", PropertyType:=BaseClasses.PropertyTypes.ClientContactID)>
        Public Property ClientContactID() As Integer
            Get
                ClientContactID = _ClientContactID
            End Get
            Set(ByVal value As Integer)
                _ClientContactID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Contact Name", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientContactName)>
        Public Property ClientContactName() As String
            Get
                ClientContactName = _ClientContactName
            End Get
            Set(ByVal value As String)
                _ClientContactName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ContactTypeID, IsReadOnlyColumn:=True, CustomColumnCaption:="Contact Type")>
        Public Property ContactTypeID() As Nullable(Of Integer)
            Get
                ContactTypeID = _ContactTypeID
            End Get
            Set(value As Nullable(Of Integer))
                _ContactTypeID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Email", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property DistributeViaEmail() As Short
            Get
                DistributeViaEmail = _DistributeViaEmail
            End Get
            Set(value As Short)
                _DistributeViaEmail = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Print", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property DistributeViaPrint() As Short
            Get
                DistributeViaPrint = _DistributeViaPrint
            End Get
            Set(value As Short)
                _DistributeViaPrint = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property UseAddress() As Nullable(Of Short)
            Get
                UseAddress = _UseAddress
            End Get
            Set(value As Nullable(Of Short))
                _UseAddress = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ReportFormat() As Nullable(Of Short)
            Get
                ReportFormat = _ReportFormat
            End Get
            Set(value As Nullable(Of Short))
                _ReportFormat = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property LastEmailed() As Nullable(Of Date)
            Get
                LastEmailed = _LastEmailed
            End Get
            Set(value As Nullable(Of Date))
                _LastEmailed = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property LastPrinted() As Nullable(Of Date)
            Get
                LastPrinted = _LastPrinted
            End Get
            Set(value As Nullable(Of Date))
                _LastPrinted = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ClientContactCode() As String
            Get
                ClientContactCode = _ClientContactCode
            End Get
            Set(value As String)
                _ClientContactCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.DefaultColumnTypes.StandardCheckBox)>
        Public Property IncludeOnAccount() As Short
            Get
                IncludeOnAccount = _IncludeOnAccount
            End Get
            Set(value As Short)
                _IncludeOnAccount = value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ClientCode

        End Function
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement

            Try

                If _ProductAccountsReceivableStatement IsNot Nothing Then

                    _ProductAccountsReceivableStatement.ClientCode = _ClientCode
                    _ProductAccountsReceivableStatement.DivisionCode = _DivisionCode
                    _ProductAccountsReceivableStatement.ProductCode = _ProductCode
                    _ProductAccountsReceivableStatement.DistributeViaEmail = _DistributeViaEmail
                    _ProductAccountsReceivableStatement.DistributeViaPrint = _DistributeViaPrint
                    _ProductAccountsReceivableStatement.UseAddress = _UseAddress
                    _ProductAccountsReceivableStatement.IncludeOnAccount = _IncludeOnAccount
                    _ProductAccountsReceivableStatement.ReportFormat = _ReportFormat
                    _ProductAccountsReceivableStatement.LastEmailed = _LastEmailed
                    _ProductAccountsReceivableStatement.LastPrinted = _LastPrinted
                    _ProductAccountsReceivableStatement.ClientContactID = _ClientContactID
                    _ProductAccountsReceivableStatement.ClientContactCode = _ClientContactCode

                End If

            Catch ex As Exception
                _ProductAccountsReceivableStatement = Nothing
            End Try

            GetEntity = _ProductAccountsReceivableStatement

        End Function
        Public Sub New(ByVal ProductAccountsReceivableStatement As AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement)

            _ClientCode = ProductAccountsReceivableStatement.ClientCode
            _DivisionCode = ProductAccountsReceivableStatement.DivisionCode
            _ProductCode = ProductAccountsReceivableStatement.ProductCode
            _DistributeViaEmail = ProductAccountsReceivableStatement.DistributeViaEmail
            _DistributeViaPrint = ProductAccountsReceivableStatement.DistributeViaPrint
            _UseAddress = ProductAccountsReceivableStatement.UseAddress
            _IncludeOnAccount = ProductAccountsReceivableStatement.IncludeOnAccount
            _ReportFormat = ProductAccountsReceivableStatement.ReportFormat
            _LastEmailed = ProductAccountsReceivableStatement.LastEmailed
            _LastPrinted = ProductAccountsReceivableStatement.LastPrinted
            _ClientContactID = ProductAccountsReceivableStatement.ClientContactID
            _ClientContactName = ProductAccountsReceivableStatement.ClientContact.FirstName & " " & ProductAccountsReceivableStatement.ClientContact.LastName
            _ClientContactCode = ProductAccountsReceivableStatement.ClientContactCode
            _ContactTypeID = ProductAccountsReceivableStatement.ClientContact.ContactTypeID

            _ProductAccountsReceivableStatement = ProductAccountsReceivableStatement

        End Sub
        Public Sub New()

            _ProductAccountsReceivableStatement = New AdvantageFramework.Database.Entities.ProductAccountsReceivableStatement

        End Sub
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = Nothing
            Dim PropertyValue As Object = Nothing

            If PropertyName = AdvantageFramework.Database.Classes.ProductAccountsReceivableStatement.Properties.ClientContactID.ToString Then

                If _ProductAccountsReceivableStatement.IsEntityBeingAdded() Then

                    PropertyValue = Value

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ProductAccountsReceivableStatements
                        Where Entity.ClientContactID = DirectCast(PropertyValue, Integer) AndAlso
                              Entity.ClientCode.ToUpper = Me.ClientCode.ToUpper AndAlso
                              Entity.DivisionCode.ToUpper = Me.DivisionCode.ToUpper AndAlso
                              Entity.ProductCode.ToUpper = Me.ProductCode.ToUpper
                        Select Entity).Any Then

                        IsValid = False

                        ErrorText = "Duplicate entry."

                    End If

                End If

            End If

            ValidateCustomProperties = ErrorText

        End Function

#End Region

    End Class

End Namespace
