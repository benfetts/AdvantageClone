Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class SetupFormDashboardDataSource
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Office
            Owner
            StartDate
            EndDate
            Description
            Revenue
            Hours
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        Public Property Office() As String
        <Required>
        Public Property Owner() As String
        <Required>
        Public Property StartDate() As Date
        <Required>
        Public Property EndDate() As Date
        <Required>
        Public Property Description() As String
        <Required>
        <System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="n2")>
        Public Property Revenue() As Decimal
        <Required>
        <System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="n1")>
        Public Property Hours() As Decimal

#End Region

#Region " Methods "

        Public Sub New(RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan)

            Me.Office = If(RevenueResourcePlan.Office IsNot Nothing, RevenueResourcePlan.Office.Name, String.Empty)
            Me.Owner = If(RevenueResourcePlan.Employee IsNot Nothing, RevenueResourcePlan.Employee.ToString, String.Empty)
            Me.StartDate = RevenueResourcePlan.StartDate
            Me.EndDate = RevenueResourcePlan.EndDate
            Me.Description = RevenueResourcePlan.Description

            If RevenueResourcePlan.RevenueResourcePlanResources IsNot Nothing Then

                Me.Hours = 0

            Else

                Me.Hours = 0

            End If

            If RevenueResourcePlan.RevenueResourcePlanRevenues IsNot Nothing Then

                Me.Revenue = 0

            Else

                Me.Revenue = 0

            End If

        End Sub
        Public Sub New()

            Me.Office = String.Empty
            Me.Owner = String.Empty
            Me.StartDate = New Date(Now.Year, Now.Month, 1)
            Me.EndDate = New Date(Now.Year, Now.Month, 1)
            Me.Description = String.Empty
            Me.Revenue = 0
            Me.Hours = 0

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Description & " - " & Me.Owner & " - " & Me.Office

        End Function

#End Region

    End Class

End Namespace
