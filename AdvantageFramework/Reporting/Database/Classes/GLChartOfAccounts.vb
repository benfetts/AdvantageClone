Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class GLChartOfAccounts

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLAccount
            Description
            Base
            Dept
            Office
            Other
            AccountGroupCode
            AccountGroupDesc
            AccountType
            BalanceType
            PayrollIndicator
            POIndicator
            CDPRequired
            DateEntered
            ModifiedDate
            CreateUser
            ModifiedbyUser
            InactiveFlag
        End Enum

#End Region

#Region " Variables "

        Private _GLAccount As String = Nothing
        Private _Description As String = Nothing
        Private _Base As String = Nothing
        Private _Dept As String = Nothing
        Private _Office As String = Nothing
        Private _Other As String = Nothing
        Private _AccountGroupCode As String = Nothing
        Private _AccountGroupDesc As String = Nothing
        Private _AccountType As String = Nothing
        Private _BalanceType As String = Nothing
        Private _PayrollIndicator As String = Nothing
        Private _POIndicator As String = Nothing
        Private _CDPRequired As String = Nothing
        Private _ModifiedDate As Nullable(Of Date) = Nothing
        Private _DateEntered As Nullable(Of Date) = Nothing
        Private _CreateUser As String = Nothing
        Private _ModifiedByUser As String = Nothing
        Private _InactiveFlag As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLAccount() As String
            Get
                GLAccount = _GLAccount
            End Get
            Set
                _GLAccount = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Description() As String
            Get
                Description = _Description
            End Get
            Set
                _Description = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Base() As String
            Get
                Base = _Base
            End Get
            Set
                _Base = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Dept() As String
            Get
                Dept = _Dept
            End Get
            Set
                _Dept = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Office() As String
            Get
                Office = _Office
            End Get
            Set
                _Office = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Other() As String
            Get
                Other = _Other
            End Get
            Set
                _Other = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountGroupCode() As String
            Get
                AccountGroupCode = _AccountGroupCode
            End Get
            Set
                _AccountGroupCode = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountGroupDesc() As String
            Get
                AccountGroupDesc = _AccountGroupDesc
            End Get
            Set
                _AccountGroupDesc = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountType() As String
            Get
                AccountType = _AccountType
            End Get
            Set
                _AccountType = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BalanceType() As String
            Get
                BalanceType = _BalanceType
            End Get
            Set
                _BalanceType = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PayrollIndicator() As String
            Get
                PayrollIndicator = _PayrollIndicator
            End Get
            Set
                _PayrollIndicator = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property POIndicator() As String
            Get
                POIndicator = _POIndicator
            End Get
            Set
                _POIndicator = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CDPRequired() As String
            Get
                CDPRequired = _CDPRequired
            End Get
            Set
                _CDPRequired = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DateEntered() As Nullable(Of Date)
            Get
                DateEntered = _DateEntered
            End Get
            Set
                _DateEntered = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ModifiedDate() As Nullable(Of Date)
            Get
                ModifiedDate = _ModifiedDate
            End Get
            Set
                _ModifiedDate = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CreateUser() As String
            Get
                CreateUser = _CreateUser
            End Get
            Set
                _CreateUser = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ModifiedByUser() As String
            Get
                ModifiedByUser = _ModifiedByUser
            End Get
            Set
                _ModifiedByUser = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property InactiveFlag() As String
            Get
                InactiveFlag = _InactiveFlag
            End Get
            Set
                _InactiveFlag = Value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.GLAccount.ToString

        End Function

#End Region

    End Class

End Namespace
