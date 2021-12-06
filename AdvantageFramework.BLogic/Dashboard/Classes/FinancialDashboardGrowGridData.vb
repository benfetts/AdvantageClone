Namespace Dashboard.Classes

    <Serializable()>
    Public Class FinancialDashboardGrowGridData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Client
            YOY
            Growth

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Client As String
        Public Property YOY As Decimal
        Public Property Growth As Decimal

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

