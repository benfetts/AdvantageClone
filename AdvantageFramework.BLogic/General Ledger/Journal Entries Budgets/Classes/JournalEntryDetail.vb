Namespace GeneralLedger.JournalEntriesBudgets.Classes

    Public Class JournalEntryDetail
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SequenceNumber
            GLACode
            GLAccountDescription
            DebitAmount
            CreditAmount
            Remark
            CDPRequired
            ClientCode
            DivisionCode
            ProductCode
        End Enum

#End Region

#Region " Variables "

        Private _GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
        Private _GLADescription As String = Nothing
        Private _DebitAmount As Nullable(Of Decimal) = Nothing
        Private _CreditAmount As Nullable(Of Decimal) = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Seq")>
        Public Property SequenceNumber() As Short
            Get
                SequenceNumber = _GeneralLedgerDetail.SequenceNumber
            End Get
            Set(value As Short)
                _GeneralLedgerDetail.SequenceNumber = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account", PropertyType:=BaseClasses.PropertyTypes.GeneralLedgerAccountCode)>
        Public Property GLACode As String
            Get
                GLACode = _GeneralLedgerDetail.GLACode
            End Get
            Set(value As String)
                _GeneralLedgerDetail.GLACode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.GeneralLedgerAccountDescription, IsReadOnlyColumn:=True)>
        Public Property GLAccountDescription As String
            Get
                GLAccountDescription = _GLADescription
            End Get
            Set(value As String)
                _GLADescription = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Debit")>
        Public Property DebitAmount As Nullable(Of Decimal)
            Get
                DebitAmount = _DebitAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _DebitAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Credit")>
        Public Property CreditAmount As Nullable(Of Decimal)
            Get
                CreditAmount = _CreditAmount
            End Get
            Set(value As Nullable(Of Decimal))
                _CreditAmount = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Reference")>
        Public Property Remark As String
            Get
                Remark = _GeneralLedgerDetail.Remark
            End Get
            Set(value As String)
                _GeneralLedgerDetail.Remark = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public ReadOnly Property CDPRequired As Boolean
            Get
                CDPRequired = If(_GeneralLedgerDetail.GeneralLedgerAccount IsNot Nothing, CBool(_GeneralLedgerDetail.GeneralLedgerAccount.CDPRequired.GetValueOrDefault(0)), False)
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode As String
            Get
                ClientCode = _GeneralLedgerDetail.ClientCode
            End Get
            Set(value As String)
                _GeneralLedgerDetail.ClientCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode As String
            Get
                DivisionCode = _GeneralLedgerDetail.DivisionCode
            End Get
            Set(value As String)
                _GeneralLedgerDetail.DivisionCode = value
            End Set
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode As String
            Get
                ProductCode = _GeneralLedgerDetail.ProductCode
            End Get
            Set(value As String)
                _GeneralLedgerDetail.ProductCode = value
            End Set
        End Property
#End Region

#Region " Methods "

        Public Sub New()

            _GeneralLedgerDetail = New AdvantageFramework.Database.Entities.GeneralLedgerDetail

        End Sub
        Public Sub New(GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail)

            _GeneralLedgerDetail = GeneralLedgerDetail

            If GeneralLedgerDetail.DebitAmount > 0 Then

                _DebitAmount = GeneralLedgerDetail.DebitAmount

            End If

            If GeneralLedgerDetail.CreditAmount < 0 Then

                _CreditAmount = GeneralLedgerDetail.CreditAmount

            End If

        End Sub

#End Region

    End Class

End Namespace