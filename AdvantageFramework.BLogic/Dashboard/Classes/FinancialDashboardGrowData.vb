Namespace Dashboard.Classes

    <Serializable()>
    Public Class FinancialDashboardGrowData

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            Items

        End Enum
        Public Enum Type

            All

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Filter As AdvantageFramework.Dashboard.Classes.EmployeeUtilizationFilter = Nothing
        Public Property Items As Generic.List(Of AdvantageFramework.Dashboard.Classes.FinancialDashboardGrowGridData) = Nothing
        Public Property ErrorMesage As String = String.Empty

#End Region

#Region " Methods "

        Sub New()

            Me.Filter = New EmployeeUtilizationFilter
            Me.Items = New List(Of FinancialDashboardGrowGridData)

        End Sub

#End Region

    End Class

End Namespace

