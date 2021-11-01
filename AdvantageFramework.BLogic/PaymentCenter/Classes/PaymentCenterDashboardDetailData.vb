Namespace PaymentCenter.Classes

    <Serializable()>
    Public Class PaymentCenterDashboardDetailData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Category
            SubCategory
            Count
            Amount
            CategoryColor

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Category As String
        Public Property SubCategory As String
        Public Property Count As Integer
        Public Property Amount As Decimal
        Public Property CategoryColor As String

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

