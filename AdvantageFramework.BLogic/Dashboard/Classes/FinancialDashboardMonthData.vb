Namespace Dashboard.Classes

    <Serializable()>
    Public Class FinancialDashboardMonthData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Category
            Actual
            Budget
            VariancePercent
            MTD
            YOYPercent

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Category As String
        Public Property Actual As Decimal
        Public Property Budget As Decimal
        Public Property VariancePercent As Decimal
        Public Property MTD As Decimal
        Public Property YOYPercent As Decimal

#End Region

#Region " Methods "

        Sub New()

        End Sub

#End Region

    End Class

End Namespace

