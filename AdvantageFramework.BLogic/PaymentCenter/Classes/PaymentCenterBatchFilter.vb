Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterBatchFilter

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            BatchOwner
            StartDate
            EndDate
            Status

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BatchOwner As String = String.Empty
        Public Property StartDate As Date?
        Public Property EndDate As Date?
        Public Property Status As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

