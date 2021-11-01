Namespace Classes.GeneralLedger.JournalEntry

    Public Class RecurringJournalEntryPostReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            CycleCode
            CycleDescription
            PostPeriodCode
            ControlNumber
            GLTransaction
            GLTransactionDescription
            TransactionDate
            ControlAmount
            Reversing
            SequenceNumber
            GLACode
            GLAccountDescription
            Amount
            Debit
            Credit
            ClientCode
            DivisionCode
            ProductCode
            Remark
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CycleCode() As String
        Public Property CycleDescription() As String
        Public Property PostPeriodCode() As String
        Public Property ControlNumber() As Integer
        Public Property GLTransaction As Integer
        Public Property GLTransactionDescription() As String
        Public Property TransactionDate() As Date
        Public Property ControlAmount() As Double
        Public Property Reversing As String
        Public Property SequenceNumber As Short
        Public Property GLACode As String
        Public Property GLAccountDescription As String
        Public Property Amount As Double
        Public Property Debit As Nullable(Of Double)
        Public Property Credit As Nullable(Of Double)
        Public Property ClientCode As String
        Public Property DivisionCode As String
        Public Property ProductCode As String
        Public Property Remark As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ControlNumber.ToString & " - " & Me.GLTransaction.ToString

        End Function

#End Region

    End Class

End Namespace