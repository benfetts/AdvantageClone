Namespace Database.Classes

    <Serializable()>
    Public Class ClientAccountsReceivableStatement
        Inherits BaseClasses.BaseClass


#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            DistributeViaEmail
            DistributeViaPrint
            UseAddress
            IncludeOnAccount
            ReportFormat
            LastEmailed
            LastPrinted
            ClientContactID
            ClientContactName
            ContactCode
            ContactTypeID
        End Enum

#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DistributeViaEmail As Short = Nothing
        Private _DistributeViaPrint As Short = Nothing
        Private _UseAddress As Nullable(Of Short) = Nothing
        Private _IncludeOnAccount As Short = Nothing
        Private _ReportFormat As Nullable(Of Short) = Nothing
        Private _LastEmailed As Nullable(Of Date) = Nothing
        Private _LastPrinted As Nullable(Of Date) = Nothing
        Private _ClientContactID As Integer = Nothing
        Private _ClientContactName As String = Nothing
        Private _ContactCode As String = Nothing
        Private _ContactTypeID As Nullable(Of Integer) = Nothing
        Private _ClientAccountsReceivableStatement As AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement = Nothing

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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="Contact Code", PropertyType:=BaseClasses.PropertyTypes.ClientContactID)>
        Public Property ClientContactID() As Integer
            Get
                ClientContactID = _ClientContactID
            End Get
            Set(ByVal value As Integer)
                _ClientContactID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Contact Name", DefaultColumnType:=BaseClasses.DefaultColumnTypes.ClientContactName)>
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ContactCode() As String
            Get
                ContactCode = _ContactCode
            End Get
            Set(value As String)
                _ContactCode = value
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
        Public Function GetEntity() As AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement

            Try

                If _ClientAccountsReceivableStatement IsNot Nothing Then

                    _ClientAccountsReceivableStatement.ClientCode = _ClientCode
                    _ClientAccountsReceivableStatement.DistributeViaEmail = _DistributeViaEmail
                    _ClientAccountsReceivableStatement.DistributeViaPrint = _DistributeViaPrint
                    _ClientAccountsReceivableStatement.UseAddress = _UseAddress
                    _ClientAccountsReceivableStatement.IncludeOnAccount = _IncludeOnAccount
                    _ClientAccountsReceivableStatement.ReportFormat = _ReportFormat
                    _ClientAccountsReceivableStatement.LastEmailed = _LastEmailed
                    _ClientAccountsReceivableStatement.LastPrinted = _LastPrinted
                    _ClientAccountsReceivableStatement.ClientContactID = _ClientContactID
                    _ClientAccountsReceivableStatement.ContactCode = _ContactCode

                End If

            Catch ex As Exception
                _ClientAccountsReceivableStatement = Nothing
            End Try

            GetEntity = _ClientAccountsReceivableStatement

        End Function
        Public Sub New(ByVal ClientAccountsReceivableStatement As AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement)

            _ClientCode = ClientAccountsReceivableStatement.ClientCode
            _DistributeViaEmail = ClientAccountsReceivableStatement.DistributeViaEmail
            _DistributeViaPrint = ClientAccountsReceivableStatement.DistributeViaPrint
            _UseAddress = ClientAccountsReceivableStatement.UseAddress
            _IncludeOnAccount = ClientAccountsReceivableStatement.IncludeOnAccount
            _ReportFormat = ClientAccountsReceivableStatement.ReportFormat
            _LastEmailed = ClientAccountsReceivableStatement.LastEmailed
            _LastPrinted = ClientAccountsReceivableStatement.LastPrinted
            _ClientContactID = ClientAccountsReceivableStatement.ClientContactID
            _ClientContactName = ClientAccountsReceivableStatement.ClientContact.FirstName & " " & ClientAccountsReceivableStatement.ClientContact.LastName
            _ContactCode = ClientAccountsReceivableStatement.ContactCode
            _ContactTypeID = ClientAccountsReceivableStatement.ClientContact.ContactTypeID

            _ClientAccountsReceivableStatement = ClientAccountsReceivableStatement

        End Sub
        Public Sub New()

            _ClientAccountsReceivableStatement = New AdvantageFramework.Database.Entities.ClientAccountsReceivableStatement

        End Sub
        Public Overrides Function ValidateCustomProperties(PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

            'objects
            Dim ErrorText As String = Nothing
            Dim PropertyValue As Object = Nothing

            If PropertyName = AdvantageFramework.Database.Classes.ClientAccountsReceivableStatement.Properties.ClientContactID.ToString Then

                If _ClientAccountsReceivableStatement.IsEntityBeingAdded() Then

                    PropertyValue = Value

                    If (From Entity In DirectCast(Me.DbContext, AdvantageFramework.Database.DbContext).ClientAccountsReceivableStatements
                        Where Entity.ClientContactID = DirectCast(PropertyValue, Integer) AndAlso
                              Entity.ClientCode.ToUpper = Me.ClientCode.ToUpper
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
