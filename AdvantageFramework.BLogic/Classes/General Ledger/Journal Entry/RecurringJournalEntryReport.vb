Namespace Classes.GeneralLedger.JournalEntry

    Public Class RecurringJournalEntryReport

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ControlNumber
            Description
            ControlAmount
            CycleCode
            CycleDescription
            CreatedByUserCode
            LastPostPeriodCode
            LastPostingDate
            LastPostingUserCode
            TotalNumberOfPostings
            StartingPostPeriodCode
            NumberOfPostings
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

        Public Property ControlNumber As Integer
        Public Property Description As String
        Public Property ControlAmount As Nullable(Of Double)
        Public Property CycleCode As String
        Public Property CycleDescription As String
        Public Property CreatedByUserCode As String
        Public Property LastPostPeriodCode As String
        Public Property LastPostingDate As Nullable(Of Date)
        Public Property LastPostingUserCode As String
        Public Property TotalNumberOfPostings As Integer
        Public Property StartingPostPeriodCode As String
        Public Property NumberOfPostings As String
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

            ToString = Me.ControlNumber.ToString

        End Function

#End Region

    End Class

End Namespace