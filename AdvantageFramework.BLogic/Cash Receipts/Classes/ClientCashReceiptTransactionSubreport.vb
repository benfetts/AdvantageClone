Namespace CashReceipts.Classes

    <Serializable()>
    Public Class ClientCashReceiptTransactionSubreport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DueFrom
            DueTo
            DueFromDebit
            DueFromCredit
            DueToDebit
            DueToCredit
            DueFromAdjustment
            DueToAdjustment
            DueFromDebitAdjustment
            DueFromCreditAdjustment
            DueToDebitAdjustment
            DueToCreditAdjustment
        End Enum

#End Region

#Region " Variables "

        Private _DueFrom As String = Nothing
        Private _DueTo As String = Nothing
        Private _DueFromAdjustment As String = Nothing
        Private _DueToAdjustment As String = Nothing
        Private _DueFromDebit As Nullable(Of Double) = Nothing
        Private _DueFromCredit As Nullable(Of Double) = Nothing
        Private _DueToDebit As Nullable(Of Double) = Nothing
        Private _DueToCredit As Nullable(Of Double) = Nothing
        Private _DueFromDebitAdjustment As Nullable(Of Double) = Nothing
        Private _DueFromCreditAdjustment As Nullable(Of Double) = Nothing
        Private _DueToDebitAdjustment As Nullable(Of Double) = Nothing
        Private _DueToCreditAdjustment As Nullable(Of Double) = Nothing
        Private _GeneralLedgerDetailDueFrom As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
        Private _GeneralLedgerDetailDueTo As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
        Private _GeneralLedgerDetailDueFromAdjustment As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing
        Private _GeneralLedgerDetailDueToAdjustment As AdvantageFramework.Database.Entities.GeneralLedgerDetail = Nothing

#End Region

#Region " Properties "

        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueFrom() As String
            Get
                DueFrom = _DueFrom
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueTo() As String
            Get
                DueTo = _DueTo
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueFromDebit() As Nullable(Of Double)
            Get
                DueFromDebit = _DueFromDebit
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueFromCredit() As Nullable(Of Double)
            Get
                DueFromCredit = _DueFromCredit
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueToDebit() As Nullable(Of Double)
            Get
                DueToDebit = _DueToDebit
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueToCredit() As Nullable(Of Double)
            Get
                DueToCredit = _DueToCredit
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueFromAdjustment() As String
            Get
                DueFromAdjustment = _DueFromAdjustment
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueToAdjustment() As String
            Get
                DueToAdjustment = _DueToAdjustment
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueFromDebitAdjustment() As Nullable(Of Double)
            Get
                DueFromDebitAdjustment = _DueFromDebitAdjustment
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueFromCreditAdjustment() As Nullable(Of Double)
            Get
                DueFromCreditAdjustment = _DueFromCreditAdjustment
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueToDebitAdjustment() As Nullable(Of Double)
            Get
                DueToDebitAdjustment = _DueToDebitAdjustment
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property DueToCreditAdjustment() As Nullable(Of Double)
            Get
                DueToCreditAdjustment = _DueToCreditAdjustment
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property HasData() As Boolean
            Get
                If _DueFrom IsNot Nothing OrElse _DueTo IsNot Nothing OrElse _DueFromAdjustment IsNot Nothing OrElse _DueToAdjustment IsNot Nothing Then
                    HasData = True
                Else
                    HasData = False
                End If
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GeneralLedgerDetailDueFrom As AdvantageFramework.Database.Entities.GeneralLedgerDetail
            Get
                GeneralLedgerDetailDueFrom = _GeneralLedgerDetailDueFrom
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GeneralLedgerDetailDueTo As AdvantageFramework.Database.Entities.GeneralLedgerDetail
            Get
                GeneralLedgerDetailDueTo = _GeneralLedgerDetailDueTo
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GeneralLedgerDetailDueFromAdjustment As AdvantageFramework.Database.Entities.GeneralLedgerDetail
            Get
                GeneralLedgerDetailDueFromAdjustment = _GeneralLedgerDetailDueFromAdjustment
            End Get
        End Property
        <System.Runtime.Serialization.DataMemberAttribute(),
        AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public ReadOnly Property GeneralLedgerDetailDueToAdjustment As AdvantageFramework.Database.Entities.GeneralLedgerDetail
            Get
                GeneralLedgerDetailDueToAdjustment = _GeneralLedgerDetailDueToAdjustment
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ClientCashReceiptDetail As AdvantageFramework.Database.Entities.ClientCashReceiptDetail, _
                       ByVal GeneralLedgerAccountList As Generic.List(Of AdvantageFramework.Database.Core.GeneralLedgerAccount), _
                       ByVal GeneralLedgerDetailList As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerDetail))

            Dim Amount As Double = 0

            If ClientCashReceiptDetail.GLACodeDueFrom IsNot Nothing AndAlso ClientCashReceiptDetail.GLSequenceNumberDueFrom IsNot Nothing Then

                _DueFrom = GeneralLedgerAccountList.Where(Function(E) E.Code = ClientCashReceiptDetail.GLACodeDueFrom).SingleOrDefault.ToString

                _GeneralLedgerDetailDueFrom = GeneralLedgerDetailList.Where(Function(E) E.GLTransaction = ClientCashReceiptDetail.GLTransaction AndAlso _
                                                                                        E.SequenceNumber = ClientCashReceiptDetail.GLSequenceNumberDueFrom).SingleOrDefault

                If _GeneralLedgerDetailDueFrom IsNot Nothing Then

                    Amount = _GeneralLedgerDetailDueFrom.CreditAmount

                End If

                If Amount > 0 Then

                    _DueFromDebit = Amount

                Else

                    _DueFromCredit = Math.Abs(Amount)

                End If

            End If

            If ClientCashReceiptDetail.GLACodeDueTo IsNot Nothing AndAlso ClientCashReceiptDetail.GLSequenceNumberDueTo IsNot Nothing Then

                _DueTo = GeneralLedgerAccountList.Where(Function(E) E.Code = ClientCashReceiptDetail.GLACodeDueTo).SingleOrDefault.ToString

                _GeneralLedgerDetailDueTo = GeneralLedgerDetailList.Where(Function(E) E.GLTransaction = ClientCashReceiptDetail.GLTransaction AndAlso _
                                                                                      E.SequenceNumber = ClientCashReceiptDetail.GLSequenceNumberDueTo).SingleOrDefault

                If _GeneralLedgerDetailDueTo IsNot Nothing Then

                    Amount = _GeneralLedgerDetailDueTo.CreditAmount

                End If

                If Amount > 0 Then

                    _DueToDebit = Amount

                Else

                    _DueToCredit = Math.Abs(Amount)

                End If

            End If

            If ClientCashReceiptDetail.GLACodeDueFromAdjustment IsNot Nothing AndAlso ClientCashReceiptDetail.GLSequenceNumberDueFromAdjustment IsNot Nothing Then

                _DueFromAdjustment = GeneralLedgerAccountList.Where(Function(E) E.Code = ClientCashReceiptDetail.GLACodeDueFromAdjustment).SingleOrDefault.ToString

                _GeneralLedgerDetailDueFromAdjustment = GeneralLedgerDetailList.Where(Function(E) E.GLTransaction = ClientCashReceiptDetail.GLTransaction AndAlso _
                                                                                                  E.SequenceNumber = ClientCashReceiptDetail.GLSequenceNumberDueFromAdjustment).SingleOrDefault

                If _GeneralLedgerDetailDueFromAdjustment IsNot Nothing Then

                    Amount = _GeneralLedgerDetailDueFromAdjustment.CreditAmount

                End If

                If Amount > 0 Then

                    _DueFromDebitAdjustment = Amount

                Else

                    _DueFromCreditAdjustment = Math.Abs(Amount)

                End If

            End If

            If ClientCashReceiptDetail.GLACodeDueToAdjustment IsNot Nothing AndAlso ClientCashReceiptDetail.GLSequenceNumberDueToAdjustment IsNot Nothing Then

                _DueToAdjustment = GeneralLedgerAccountList.Where(Function(E) E.Code = ClientCashReceiptDetail.GLACodeDueToAdjustment).SingleOrDefault.ToString

                _GeneralLedgerDetailDueToAdjustment = GeneralLedgerDetailList.Where(Function(E) E.GLTransaction = ClientCashReceiptDetail.GLTransaction AndAlso _
                                                                                                E.SequenceNumber = ClientCashReceiptDetail.GLSequenceNumberDueToAdjustment).SingleOrDefault

                If _GeneralLedgerDetailDueToAdjustment IsNot Nothing Then

                    Amount = _GeneralLedgerDetailDueToAdjustment.CreditAmount

                End If

                If Amount > 0 Then

                    _DueToDebitAdjustment = Amount

                Else

                    _DueToCreditAdjustment = Math.Abs(Amount)

                End If

            End If

        End Sub

#End Region

    End Class

End Namespace

