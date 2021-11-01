Namespace DTO.GeneralLedger.JournalEntry

    Public Class RecurringJournalEntryDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ControlNumber
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
        Public Property ControlNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="SEQ", IsReadOnlyColumn:=True)>
        Public Property SequenceNumber() As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", CustomColumnCaption:="GL Account")>
        Public Property GLACode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property GLAccountDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Debit")>
        Public Property DebitAmount As Nullable(Of Double)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="n2", CustomColumnCaption:="Credit")>
        Public Property CreditAmount As Nullable(Of Double)
        <MaxLength(45)>
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

            Me.ControlNumber = 0
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
        Public Sub New(GeneralLedgerRecurringEntryDetail As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail)

            Me.ControlNumber = GeneralLedgerRecurringEntryDetail.ControlNumber
            Me.SequenceNumber = GeneralLedgerRecurringEntryDetail.SequenceNumber
            Me.GLACode = GeneralLedgerRecurringEntryDetail.GLACode
            Me.GLAccountDescription = GeneralLedgerRecurringEntryDetail.GeneralLedgerAccount.Description

            If GeneralLedgerRecurringEntryDetail.Amount > 0 Then

                Me.DebitAmount = GeneralLedgerRecurringEntryDetail.Amount

            Else

                Me.DebitAmount = Nothing

            End If

            If GeneralLedgerRecurringEntryDetail.Amount < 0 Then

                Me.CreditAmount = GeneralLedgerRecurringEntryDetail.Amount

            Else

                Me.CreditAmount = Nothing

            End If

            Me.Remark = GeneralLedgerRecurringEntryDetail.Remarks
            Me.CDPRequired = If(GeneralLedgerRecurringEntryDetail.GeneralLedgerAccount IsNot Nothing, CBool(GeneralLedgerRecurringEntryDetail.GeneralLedgerAccount.CDPRequired.GetValueOrDefault(0)), False)
            Me.ClientCode = GeneralLedgerRecurringEntryDetail.ClientCode
            Me.DivisionCode = GeneralLedgerRecurringEntryDetail.DivisionCode
            Me.ProductCode = GeneralLedgerRecurringEntryDetail.ProductCode
            Me.RemarkIsTheSameAsHeaderDescription = False

        End Sub
        Public Sub SaveToEntity(ByRef GeneralLedgerRecurringEntryDetail As AdvantageFramework.Database.Entities.GeneralLedgerRecurringEntryDetail)

            GeneralLedgerRecurringEntryDetail.GLACode = Me.GLACode

            GeneralLedgerRecurringEntryDetail.Amount = If(Me.CreditAmount.HasValue, Me.CreditAmount.GetValueOrDefault(0), Me.DebitAmount.GetValueOrDefault(0))

            GeneralLedgerRecurringEntryDetail.Remarks = Me.Remark

            GeneralLedgerRecurringEntryDetail.ClientCode = Me.ClientCode
            GeneralLedgerRecurringEntryDetail.DivisionCode = Me.DivisionCode
            GeneralLedgerRecurringEntryDetail.ProductCode = Me.ProductCode

        End Sub

#End Region

    End Class

End Namespace