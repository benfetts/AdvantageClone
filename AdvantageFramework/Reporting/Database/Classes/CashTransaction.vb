Namespace Reporting.Database.Classes

    <Serializable>
    Public Class CashTransaction

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            BankCode
            BankDescription
            GLAccountCode
            GLAccountDescription
            PostPeriod
            GLXact
            Ref
            RefDescription
            CheckNumber
            CheckDate
            PayeePayor
            Amount
            VoidFlag
            VoidPeriod
            Cleared
            RecStmtDate
            ReconFlag
            DateOfEntry
            DepositDate
        End Enum

#End Region

#Region " Variables "

        Private _BankCode As String = Nothing
        Private _BankDescription As String = Nothing
        Private _GLAccountCode As String = Nothing
        Private _GLAccountDescription As String = Nothing
        Private _PostPeriod As String = Nothing
        Private _GLXact As Nullable(Of Integer) = Nothing
        Private _Ref As Nullable(Of Short)
        Private _RefDescription As String = Nothing
        Private _CheckNumber As String = Nothing
        Private _CheckDate As Nullable(Of Date) = Nothing
        Private _PayeePayor As String = Nothing
        Private _Amount As Nullable(Of Decimal) = Nothing
        Private _VoidFlag As String = Nothing
        Private _VoidPeriod As String = Nothing
        Private _Cleared As String = Nothing
        Private _RecStmtDate As Nullable(Of Date) = Nothing
        Private _ReconFlag As String = Nothing
        Private _DateOfEntry As Nullable(Of Date) = Nothing
        Private _DepositDate As Nullable(Of Date) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankCode() As String
            Get
                BankCode = _BankCode
            End Get
            Set(ByVal value As String)
                _BankCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BankDescription() As String
            Get
                BankDescription = _BankDescription
            End Get
            Set(ByVal value As String)
                _BankDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLAccountCode() As String
            Get
                GLAccountCode = _GLAccountCode
            End Get
            Set(ByVal value As String)
                _GLAccountCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GLAccountDescription() As String
            Get
                GLAccountDescription = _GLAccountDescription
            End Get
            Set(ByVal value As String)
                _GLAccountDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PostPeriod() As String
            Get
                PostPeriod = _PostPeriod
            End Get
            Set(ByVal value As String)
                _PostPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", CustomColumnCaption:="GLXACT")>
        Public Property GLXact() As Nullable(Of Integer)
            Get
                GLXact = _GLXact
            End Get
            Set(ByVal value As Nullable(Of Integer))
                _GLXact = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0")>
        Public Property Ref() As Nullable(Of Short)
            Get
                Ref = _Ref
            End Get
            Set(ByVal value As Nullable(Of Short))
                _Ref = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RefDescription() As String
            Get
                RefDescription = _RefDescription
            End Get
            Set(ByVal value As String)
                _RefDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckNumber() As String
            Get
                CheckNumber = _CheckNumber
            End Get
            Set(ByVal value As String)
                _CheckNumber = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CheckDate() As Nullable(Of Date)
            Get
                CheckDate = _CheckDate
            End Get
            Set(ByVal value As Nullable(Of Date))
                _CheckDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PayeePayor() As String
            Get
                PayeePayor = _PayeePayor
            End Get
            Set(ByVal value As String)
                _PayeePayor = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2")>
        Public Property Amount() As Nullable(Of Decimal)
            Get
                Amount = _Amount
            End Get
            Set(ByVal value As Nullable(Of Decimal))
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VoidFlag() As String
            Get
                VoidFlag = _VoidFlag
            End Get
            Set(value As String)
                _VoidFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property VoidPeriod() As String
            Get
                VoidPeriod = _VoidPeriod
            End Get
            Set(ByVal value As String)
                _VoidPeriod = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Cleared() As String
            Get
                Cleared = _Cleared
            End Get
            Set(value As String)
                _Cleared = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RecStmtDate() As Nullable(Of Date)
            Get
                RecStmtDate = _RecStmtDate
            End Get
            Set(value As Nullable(Of Date))
                _RecStmtDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ReconFlag() As String
            Get
                ReconFlag = _ReconFlag
            End Get
            Set(value As String)
                _ReconFlag = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DateOfEntry() As Nullable(Of Date)
            Get
                DateOfEntry = _DateOfEntry
            End Get
            Set(value As Nullable(Of Date))
                _DateOfEntry = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DepositDate() As Nullable(Of Date)
            Get
                DepositDate = _DepositDate
            End Get
            Set(value As Nullable(Of Date))
                _DepositDate = value
            End Set
        End Property
#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.BankDescription.ToString

        End Function

#End Region

    End Class

End Namespace
