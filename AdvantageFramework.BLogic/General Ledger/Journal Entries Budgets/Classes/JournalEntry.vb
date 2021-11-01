Namespace GeneralLedger.JournalEntriesBudgets.Classes

    Public Class JournalEntry

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Transaction
            PostPeriodCode
            GLSourceCode
            Description
        End Enum

#End Region

#Region " Variables "

        Private _GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property Transaction() As Integer
            Get
                Transaction = _GeneralLedger.Transaction
            End Get
        End Property

        Public ReadOnly Property PostPeriodCode As String
            Get
                PostPeriodCode = _GeneralLedger.PostPeriodCode
            End Get
        End Property

        Public ReadOnly Property GLSourceCode As String
            Get
                GLSourceCode = _GeneralLedger.GLSourceCode
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Description = _GeneralLedger.Description
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(GeneralLedger As AdvantageFramework.Database.Entities.GeneralLedger)

            _GeneralLedger = GeneralLedger

        End Sub

#End Region

    End Class

End Namespace