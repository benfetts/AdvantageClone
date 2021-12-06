Namespace Dashboard.Classes

    <Serializable()>
    Public Class FinancialDashboardMonthChartData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Month
            Revenue
            Expenses
            NetIncome

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Month As String
        Public Property Revenue As Decimal
        Public Property Expenses As Decimal
        Public Property NetIncome As Decimal

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

