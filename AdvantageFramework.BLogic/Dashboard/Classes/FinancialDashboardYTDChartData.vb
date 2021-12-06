Namespace Dashboard.Classes

    <Serializable()>
    Public Class FinancialDashboardYTDChartData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Year
            Revenue
            Expenses
            Income
            Profit

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Year As String
        Public Property Revenue As Decimal
        Public Property Expenses As Decimal
        Public Property Income As Decimal
        Public Property Profit As Decimal

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

