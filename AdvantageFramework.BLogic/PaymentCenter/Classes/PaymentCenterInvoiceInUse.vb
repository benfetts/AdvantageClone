Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterInvoiceInUse

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            BatchId
            BatchName
            InvoiceNumber
            UserId
            UserName
            CreationDate
            LastUpdateDate

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BatchId As Integer? = 0
        Public Property BatchName As String = String.Empty
        Public Property InvoiceNumber As String = String.Empty
        Public Property UserId As String = String.Empty
        Public Property UserName As String = String.Empty
        Public Property CreationDate As Date?
        Public Property LastUpdateDate As Date?


#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

