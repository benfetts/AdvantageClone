Namespace Database.Classes

    <Serializable()>
    Public Class GeneralLedgerDetailReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            TransactionID
            TransSeq
            AccountCode
            AccountDescription
            Amount
            AbsoluteAmount
            DebitOrCredit
            Remark
            PostPeriodCode
            PostingPeriodEndingDate
            EntryDate
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
            TargetAccount
            UserID
            ProductUserDefinedField1
            ProductUserDefinedField2
            ProductUserDefinedField3
            ProductUserDefinedField4
        End Enum

#End Region

#Region " Variables "

        Private _TransactionID As Integer = Nothing
        Private _TransSeq As Short = Nothing
        Private _AccountCode As String = Nothing
        Private _AccountDescription As String = Nothing
        Private _Amount As Double = Nothing
        Private _AbsoluteAmount As Double? = Nothing
        Private _DebitOrCredit As String = Nothing
        Private _Remark As String = Nothing
        Private _PostPeriodCode As String = Nothing
        Private _PostingPeriodEndingDate As Date? = Nothing
        Private _EntryDate As Date = Nothing
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
        Private _TargetAccount As String = Nothing
        Private _UserID As String = Nothing
        Private _ProductUserDefinedField1 As String = Nothing
        Private _ProductUserDefinedField2 As String = Nothing
        Private _ProductUserDefinedField3 As String = Nothing
        Private _ProductUserDefinedField4 As String = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", IsReadOnlyColumn:=True)>
        Public Property TransactionID() As Integer
            Get
                TransactionID = _TransactionID
            End Get
            Set(value As Integer)
                _TransactionID = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="f0", IsReadOnlyColumn:=True)>
        Public Property TransSeq() As Short
            Get
                TransSeq = _TransSeq
            End Get
            Set(value As Short)
                _TransSeq = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(30)>
        Public Property AccountCode() As String
            Get
                AccountCode = _AccountCode
            End Get
            Set(value As String)
                _AccountCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(75)>
        Public Property AccountDescription() As String
            Get
                AccountDescription = _AccountDescription
            End Get
            Set(value As String)
                _AccountDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n", IsReadOnlyColumn:=True)>
        Public Property Amount() As Double
            Get
                Amount = _Amount
            End Get
            Set(value As Double)
                _Amount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n", IsReadOnlyColumn:=True)>
        Public Property AbsoluteAmount() As Nullable(Of Double)
            Get
                AbsoluteAmount = _AbsoluteAmount
            End Get
            Set(value As Nullable(Of Double))
                _AbsoluteAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, IsReadOnlyColumn:=True)>
        Public Property DebitOrCredit As String
            Get
                DebitOrCredit = _DebitOrCredit
            End Get
            Set(value As String)
                _DebitOrCredit = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(150)>
        Public Property Remark() As String
            Get
                Remark = _Remark
            End Get
            Set(value As String)
                _Remark = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(6)>
        Public Property PostPeriodCode() As String
            Get
                PostPeriodCode = _PostPeriodCode
            End Get
            Set(value As String)
                _PostPeriodCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property PostingPeriodEndingDate() As Nullable(Of Date)
            Get
                PostingPeriodEndingDate = _PostingPeriodEndingDate
            End Get
            Set(value As Nullable(Of Date))
                _PostingPeriodEndingDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d", IsReadOnlyColumn:=True)>
        Public Property EntryDate() As Date
            Get
                EntryDate = _EntryDate
            End Get
            Set(value As Date)
                _EntryDate = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="d", IsReadOnlyColumn:=True)>
        Public Property PostedToSummary As Nullable(Of Date)
            Get
                PostedToSummary = _PostedToSummary
            End Get
            Set(value As Nullable(Of Date))
                _PostedToSummary = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(6)>
        Public Property ClientCode() As String
            Get
                ClientCode = _ClientCode
            End Get
            Set(value As String)
                _ClientCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(40)>
        Public Property ClientName() As String
            Get
                ClientName = _ClientName
            End Get
            Set(value As String)
                _ClientName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(6)>
        Public Property DivisionCode() As String
            Get
                DivisionCode = _DivisionCode
            End Get
            Set(value As String)
                _DivisionCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(40)>
        Public Property DivisionName() As String
            Get
                DivisionName = _DivisionName
            End Get
            Set(value As String)
                _DivisionName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(6)>
        Public Property ProductCode() As String
            Get
                ProductCode = _ProductCode
            End Get
            Set(value As String)
                _ProductCode = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(40)>
        Public Property ProductName() As String
            Get
                ProductName = _ProductName
            End Get
            Set(value As String)
                _ProductName = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(2)>
        Public Property Source() As String
            Get
                Source = _Source
            End Get
            Set(value As String)
                _Source = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(20)>
        Public Property OfficeSegment() As String
            Get
                OfficeSegment = _OfficeSegment
            End Get
            Set(value As String)
                _OfficeSegment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(20)>
        Public Property BaseAccount() As String
            Get
                BaseAccount = _BaseAccount
            End Get
            Set(value As String)
                _BaseAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(5)>
        Public Property DepartmentSegment() As String
            Get
                DepartmentSegment = _DepartmentSegment
            End Get
            Set(value As String)
                _DepartmentSegment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(20)>
        Public Property OtherSegment() As String
            Get
                OtherSegment = _OtherSegment
            End Get
            Set(value As String)
                _OtherSegment = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True),
        System.ComponentModel.DataAnnotations.MaxLength(100)>
        Public Property MappedAccount() As String
            Get
                MappedAccount = _MappedAccount
            End Get
            Set(value As String)
                _MappedAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property TargetAccount() As String
            Get
                TargetAccount = _TargetAccount
            End Get
            Set(value As String)
                _TargetAccount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property UserID() As String
            Get
                UserID = _UserID
            End Get
            Set(value As String)
                _UserID = value
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

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.TransactionID.ToString

        End Function

#End Region

    End Class

End Namespace
