Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class TrialBalanceReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            AccountCode
            AccountDescription
            AccountType
            BalanceCarryforward
            AccountBeginningBalance
            DebitCurrentMonth
            CreditCurrentMonth
            AccumulatedDebitAmount
            AccumulatedCreditAmount
            EndingDebitBalance
            EndingCreditBalance
            OfficeSegment
            BaseAccount
            DepartmentSegment
            OtherSegment
            MappedAccount
            TargetAccount
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _AccountCode As String = Nothing
        Private _AccountDescription As String = Nothing
        Private _AccountType As String = Nothing
        Private _BalanceCarryforward As Decimal = Nothing
        Private _AccountBeginningBalance As Decimal = Nothing
        Private _DebitCurrentMonth As Decimal = Nothing
        Private _CreditCurrentMonth As Decimal = Nothing
        Private _AccumulatedDebitAmount As Decimal = Nothing
        Private _AccumulatedCreditAmount As Decimal = Nothing
        Private _EndingDebitBalance As Decimal = Nothing
        Private _EndingCreditBalance As Decimal = Nothing
        Private _OfficeSegment As String = Nothing
        Private _BaseAccount As String = Nothing
        Private _DepartmentSegment As String = Nothing
        Private _OtherSegment As String = Nothing
        Private _MappedAccount As String = Nothing
        Private _TargetAccount As String = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Nullable(Of System.Guid)
            Get
                ID = _ID
            End Get
            Set
                _ID = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountCode() As String
            Get
                AccountCode = _AccountCode
            End Get
            Set
                _AccountCode = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property AccountDescription() As String
            Get
                AccountDescription = _AccountDescription
            End Get
            Set
                _AccountDescription = Value
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
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property BalanceCarryforward() As Decimal
            Get
                BalanceCarryforward = _BalanceCarryforward
            End Get
            Set
                _BalanceCarryforward = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AccountBeginningBalance() As Decimal
            Get
                AccountBeginningBalance = _AccountBeginningBalance
            End Get
            Set
                _AccountBeginningBalance = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DebitCurrentMonth() As Decimal
            Get
                DebitCurrentMonth = _DebitCurrentMonth
            End Get
            Set
                _DebitCurrentMonth = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CreditCurrentMonth() As Decimal
            Get
                CreditCurrentMonth = _CreditCurrentMonth
            End Get
            Set
                _CreditCurrentMonth = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AccumulatedDebitAmount() As Decimal
            Get
                AccumulatedDebitAmount = _AccumulatedDebitAmount
            End Get
            Set
                _AccumulatedDebitAmount = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AccumulatedCreditAmount() As Decimal
            Get
                AccumulatedCreditAmount = _AccumulatedCreditAmount
            End Get
            Set
                _AccumulatedCreditAmount = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EndingDebitBalance() As Decimal
            Get
                EndingDebitBalance = _EndingDebitBalance
            End Get
            Set
                _EndingDebitBalance = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property EndingCreditBalance() As Decimal
            Get
                EndingCreditBalance = _EndingCreditBalance
            End Get
            Set
                _EndingCreditBalance = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OfficeSegment() As String
            Get
                OfficeSegment = _OfficeSegment
            End Get
            Set
                _OfficeSegment = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property BaseAccount() As String
            Get
                BaseAccount = _BaseAccount
            End Get
            Set
                _BaseAccount = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DepartmentSegment() As String
            Get
                DepartmentSegment = _DepartmentSegment
            End Get
            Set
                _DepartmentSegment = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property OtherSegment() As String
            Get
                OtherSegment = _OtherSegment
            End Get
            Set
                _OtherSegment = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property MappedAccount() As String
            Get
                MappedAccount = _MappedAccount
            End Get
            Set
                _MappedAccount = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TargetAccount() As String
            Get
                TargetAccount = _TargetAccount
            End Get
            Set
                _TargetAccount = Value
            End Set
        End Property

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
