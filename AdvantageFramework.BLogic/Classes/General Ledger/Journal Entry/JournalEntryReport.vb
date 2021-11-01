Namespace Classes.GeneralLedger.JournalEntry

    Public Class JournalEntryReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            GLTransaction
            GLTransactionDescription
            PostPeriodCode
            PostPeriodDescription
            TransactionDate
            CreatedByUserCode
            ControlAmount
            GLSourceCode
            GLSourceDescription
            PostedToSummary
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
            Reversed
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property GLTransaction As Integer
        Public Property GLTransactionDescription As String
        Public Property PostPeriodCode As String
        Public Property PostPeriodDescription As String
        Public Property TransactionDate As Date
        Public Property CreatedByUserCode As String
        Public Property ControlAmount As Nullable(Of Double)
        Public Property GLSourceCode As String
        Public Property GLSourceDescription As String
        Public Property PostedToSummary As Nullable(Of Date)
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
        Public Property Reversed As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.GLTransaction.ToString

        End Function

#End Region

    End Class

End Namespace
