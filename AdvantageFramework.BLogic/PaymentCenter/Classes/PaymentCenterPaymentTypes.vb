Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterPaymentTypes

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Code
            Description
            BaseCheckNumber

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Code As String = Nothing
        Public Property Description As String = Nothing
        Public Property BaseCheckNumber As Integer?

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

