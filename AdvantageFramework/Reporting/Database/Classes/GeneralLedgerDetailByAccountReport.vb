Namespace Reporting.Database.Classes

    <Serializable()>
    Public Class GeneralLedgerDetailByAccountReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            TransactionID
            AccountCode
            AccountDescription
            AccountType
            TransactionDate
            AccountBeginningBalance
            DebitAmount
            CreditAmount
            Remark
            PostPeriodCode
            PostPeriodDescription
            PostPeriodStartDate
            PostPeriodEndDate
            GLMonth
            GLYear
            PostedToSummary
            ClientCode
            ClientName
            DivisionCode
            DivisionName
            ProductCode
            ProductName
            Source
            OfficeSegment
            BaseAccount
            DepartmentSegment
            OtherSegment
            MappedAccount
            Reversing
            UserCode
            ProductUserDefinedField1
            ProductUserDefinedField2
            ProductUserDefinedField3
            ProductUserDefinedField4
            CDP
        End Enum

#End Region

#Region " Variables "

        Private _ID As Nullable(Of System.Guid) = Nothing
        Private _TransactionID As Nullable(Of Integer) = Nothing
        Private _AccountCode As String = Nothing
        Private _AccountDescription As String = Nothing
        Private _AccountType As String = Nothing
        Private _TransactionDate As Nullable(Of Date) = Nothing
        Private _AccountBeginningBalance As Double = Nothing
        Private _DebitAmount As Double = Nothing
        Private _CreditAmount As Double = Nothing
        Private _Remark As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _PostPeriodDescription As String = Nothing
        Private _PostPeriodStartDate As Nullable(Of Date) = Nothing
        Private _PostPeriodEndDate As Nullable(Of Date) = Nothing
        Private _GLMonth As Nullable(Of Short) = Nothing
        Private _GLYear As String = Nothing
        Private _PostedToSummary As Nullable(Of Date) = Nothing
        Private _ClientCode As String = Nothing
        Private _ClientName As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _DivisionName As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ProductName As String = Nothing
        Private _Source As String = Nothing
        Private _OfficeSegment As String = Nothing
        Private _BaseAccount As String = Nothing
        Private _DepartmentSegment As String = Nothing
        Private _OtherSegment As String = Nothing
        Private _MappedAccount As String = Nothing
        Private _Reversing As String = Nothing
        Private _UserCode As String = Nothing
        Private _ProductUserDefinedField1 As String = Nothing
        Private _ProductUserDefinedField2 As String = Nothing
        Private _ProductUserDefinedField3 As String = Nothing
        Private _ProductUserDefinedField4 As String = Nothing

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
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="f0")>
        Public Property TransactionID() As Nullable(Of Integer)
            Get
                TransactionID = _TransactionID
            End Get
            Set
                _TransactionID = Value
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
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property TransactionDate() As Nullable(Of Date)
            Get
                TransactionDate = _TransactionDate
            End Get
            Set
                _TransactionDate = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property AccountBeginningBalance() As Double
            Get
                AccountBeginningBalance = _AccountBeginningBalance
            End Get
            Set
                _AccountBeginningBalance = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property DebitAmount() As Double
            Get
                DebitAmount = _DebitAmount
            End Get
            Set
                _DebitAmount = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2")>
        Public Property CreditAmount() As Double
            Get
                CreditAmount = _CreditAmount
            End Get
            Set
                _CreditAmount = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Remark() As String
            Get
                Remark = _Remark
            End Get
            Set
                _Remark = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set
                _PostPeriodCode = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodDescription() As String
            Get
                PostPeriodDescription = _PostPeriodDescription
            End Get
            Set
                _PostPeriodDescription = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodStartDate() As Nullable(Of Date)
            Get
                PostPeriodStartDate = _PostPeriodStartDate
            End Get
            Set
                _PostPeriodStartDate = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property PostPeriodEndDate() As Nullable(Of Date)
            Get
                PostPeriodEndDate = _PostPeriodEndDate
            End Get
            Set
                _PostPeriodEndDate = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLMonth() As Nullable(Of Short)
            Get
                GLMonth = _GLMonth
            End Get
            Set
                _GLMonth = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property GLYear() As String
            Get
                GLYear = _GLYear
            End Get
            Set
                _GLYear = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="F")>
        Public Property PostedToSummary() As Nullable(Of Date)
            Get
                PostedToSummary = _PostedToSummary
            End Get
            Set
                _PostedToSummary = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set
                _ClientCode = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set
                _ClientName = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set
                _DivisionCode = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set
                _DivisionName = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set
                _ProductCode = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set
                _ProductName = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set
                _Source = Value
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
        Public Property Reversing() As String
            Get
                Reversing = _Reversing
            End Get
            Set
                _Reversing = Value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property UserCode() As String
            Get
                UserCode = _UserCode
            End Get
            Set
                _UserCode = Value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductUserDefinedField1() As String
            Get
                ProductUserDefinedField1 = _ProductUserDefinedField1
            End Get
            Set(value As String)
                _ProductUserDefinedField1 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductUserDefinedField2() As String
            Get
                ProductUserDefinedField2 = _ProductUserDefinedField2
            End Get
            Set(value As String)
                _ProductUserDefinedField2 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductUserDefinedField3() As String
            Get
                ProductUserDefinedField3 = _ProductUserDefinedField3
            End Get
            Set(value As String)
                _ProductUserDefinedField3 = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ProductUserDefinedField4() As String
            Get
                ProductUserDefinedField4 = _ProductUserDefinedField4
            End Get
            Set(value As String)
                _ProductUserDefinedField4 = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute()>
        Public Property CDP() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
