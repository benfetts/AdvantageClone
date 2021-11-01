Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterBatchHeader

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            PaymentModule
            BatchId
            BatchName
            BatchOwner
            CreationDate
            LastUpdateDate
            PaymentDate
            BatchStatus
            BatchStatusDescription
            BankCode
            PayCutoffDate
            PostingPeriod
            MediaInternet
            MediaMagazine
            MediaNewspaper
            MediaOOH
            MediaRadio
            MediaTelevision
            NonClientItems
            ProductionItems
            AllInvoiceSelect
            PaidByClientSelect

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PaymentModule As String = String.Empty
        Public Property BatchId As Integer?
        Public Property BatchName As String = String.Empty
        Public Property BatchOwner As String = String.Empty
        Public Property CreationDate As Date?
        Public Property LastUpdateDate As Date?
        Public Property PaymentDate As Date?
        Public Property BatchStatus As String = String.Empty
        Public Property BatchStatusDescription As String = String.Empty
        Public Property BankCode As String = String.Empty
        Public Property PayCutoffDate As Date?
        Public Property PostingPeriod As String = String.Empty
        Public Property MediaInternet As Boolean = False
        Public Property MediaMagazine As Boolean = False
        Public Property MediaNewspaper As Boolean = False
        Public Property MediaOOH As Boolean = False
        Public Property MediaRadio As Boolean = False
        Public Property MediaTelevision As Boolean = False
        Public Property NonClientItems As Boolean = False
        Public Property ProductionItems As Boolean = False
        Public Property AllInvoicesSelect As Boolean = False
        Public Property PaidByClientSelect As Boolean = False

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

