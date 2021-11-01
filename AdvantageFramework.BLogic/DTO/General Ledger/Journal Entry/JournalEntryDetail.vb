Namespace DTO.GeneralLedger.JournalEntry

    Public Class JournalEntryDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLTransaction
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
            RemarkIsTheSameAsHeaderDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GLTransaction() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="SEQ", IsReadOnlyColumn:=True)>
        Public Property SequenceNumber() As Nullable(Of Short)
        <Required(AllowEmptyStrings:=False)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property GLAccountDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Debit")>
        Public Property DebitAmount As Nullable(Of Decimal)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Credit")>
        Public Property CreditAmount As Nullable(Of Decimal)
        <MaxLength(150)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Reference")>
        Public Property Remark As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property CDPRequired As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ClientCode)>
        Public Property ClientCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.DivisionCode)>
        Public Property DivisionCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.ProductCode)>
        Public Property ProductCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property RemarkIsTheSameAsHeaderDescription As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.GLTransaction = 0
            Me.SequenceNumber = Nothing
            Me.GLACode = Nothing
            Me.GLAccountDescription = String.Empty
            Me.DebitAmount = Nothing
            Me.CreditAmount = Nothing
            Me.Remark = String.Empty
            Me.CDPRequired = False
            Me.ClientCode = Nothing
            Me.DivisionCode = Nothing
            Me.ProductCode = Nothing
            Me.RemarkIsTheSameAsHeaderDescription = False

        End Sub
        Public Sub New(GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail)

            Me.GLTransaction = GeneralLedgerDetail.GLTransaction
            Me.SequenceNumber = GeneralLedgerDetail.SequenceNumber
            Me.GLACode = GeneralLedgerDetail.GLACode
            Me.GLAccountDescription = GeneralLedgerDetail.GeneralLedgerAccount.Description

            If GeneralLedgerDetail.DebitAmount > 0 Then

                Me.DebitAmount = GeneralLedgerDetail.DebitAmount

            ElseIf GeneralLedgerDetail.DebitAmount < 0 Then

                Me.CreditAmount = GeneralLedgerDetail.DebitAmount

            Else

                Me.DebitAmount = 0
                Me.CreditAmount = Nothing

            End If

            Me.Remark = GeneralLedgerDetail.Remark
            Me.CDPRequired = If(GeneralLedgerDetail.GeneralLedgerAccount IsNot Nothing, CBool(GeneralLedgerDetail.GeneralLedgerAccount.CDPRequired.GetValueOrDefault(0)), False)
            Me.ClientCode = GeneralLedgerDetail.ClientCode
            Me.DivisionCode = GeneralLedgerDetail.DivisionCode
            Me.ProductCode = GeneralLedgerDetail.ProductCode
            Me.RemarkIsTheSameAsHeaderDescription = False

        End Sub
        Public Sub SaveToEntity(ByRef GeneralLedgerDetail As AdvantageFramework.Database.Entities.GeneralLedgerDetail)

            GeneralLedgerDetail.GLACode = Me.GLACode

            GeneralLedgerDetail.CreditAmount = If(Me.CreditAmount.HasValue, Me.CreditAmount.GetValueOrDefault(0), Me.DebitAmount.GetValueOrDefault(0))
            GeneralLedgerDetail.DebitAmount = If(Me.CreditAmount.HasValue, Me.CreditAmount.GetValueOrDefault(0), Me.DebitAmount.GetValueOrDefault(0))

            GeneralLedgerDetail.Remark = Me.Remark

            GeneralLedgerDetail.ClientCode = Me.ClientCode
            GeneralLedgerDetail.DivisionCode = Me.DivisionCode
            GeneralLedgerDetail.ProductCode = Me.ProductCode

        End Sub

#End Region

    End Class

End Namespace
