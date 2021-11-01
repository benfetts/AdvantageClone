Namespace Database.Classes

    <Serializable()>
    Public Class GeneralLedgerTransaction
        Inherits BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            SequenceNumber
            GLACode
            GLADescription
            DebitAmount
            CreditAmount
            Remark
        End Enum

#End Region

#Region " Variables "

        Private _GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

        Private _GLACodeDescription As String = Nothing
        Private _DebitAmount As Nullable(Of Double) = Nothing
        Private _CreditAmount As Nullable(Of Double) = Nothing

#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Seq")>
        Public ReadOnly Property SequenceNumber() As Short
            Get
                SequenceNumber = _GeneralLedgerDetail.SequenceNumber
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Account")>
        Public ReadOnly Property GLACode() As String
            Get
                GLACode = _GeneralLedgerDetail.GLACode
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Description")>
        Public Property GLACodeDescription() As String
            Get
                GLACodeDescription = _GLACodeDescription
            End Get
            Set(ByVal value As String)
                _GLACodeDescription = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2", CustomColumnCaption:="Debit")>
        Public Property DebitAmount() As Nullable(Of Double)
            Get
                DebitAmount = _DebitAmount
            End Get
            Set(ByVal value As Nullable(Of Double))
                _DebitAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="c2", CustomColumnCaption:="Credit")>
        Public Property CreditAmount() As Nullable(Of Double)
            Get
                CreditAmount = _CreditAmount
            End Get
            Set(ByVal value As Nullable(Of Double))
                _CreditAmount = value
            End Set
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Reference")>
        Public ReadOnly Property Remark() As String
            Get
                Remark = _GeneralLedgerDetail.Remark
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(ByVal GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail, ByVal GLADescription As String)

            _GeneralLedgerDetail = GeneralLedgerDetail
            _GLACodeDescription = GLADescription

            _DebitAmount = If(GeneralLedgerDetail.DebitAmount > 0, GeneralLedgerDetail.DebitAmount, Nothing)
            _CreditAmount = If(GeneralLedgerDetail.CreditAmount > 0, Nothing, GeneralLedgerDetail.CreditAmount)

        End Sub

#End Region

    End Class

End Namespace
