Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class ResourceSetupFormDashboardDataSource
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Employee
            [Date]
            Hours
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        Public Property Employee() As String
        <Required>
        Public Property [Date]() As Date
        <Required>
        <System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="n1")>
        Public Property Hours() As Decimal

#End Region

#Region " Methods "

        Public Sub New(RevenueResourcePlanResourceDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate)

            If RevenueResourcePlanResourceDetailDate.RevenueResourcePlanResourceDetail IsNot Nothing Then

                If RevenueResourcePlanResourceDetailDate.RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(RevenueResourcePlanResourceDetailDate.RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.EmployeeCode) Then

                        Me.Employee = RevenueResourcePlanResourceDetailDate.RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.AltEmployeeName

                    Else

                        Me.Employee = RevenueResourcePlanResourceDetailDate.RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.Employee.ToString

                    End If

                End If

            End If

            Me.[Date] = RevenueResourcePlanResourceDetailDate.Date
            Me.Hours = RevenueResourcePlanResourceDetailDate.Hours

        End Sub
        Public Sub New(RevenueResourcePlanResourceDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate, EmployeeName As String)

            Me.Employee = EmployeeName
            Me.[Date] = RevenueResourcePlanResourceDetailDate.Date
            Me.Hours = RevenueResourcePlanResourceDetailDate.Hours

            'Me.Revenue = CInt(Math.Ceiling(Rnd() * 3)) + 1

        End Sub
        Public Sub New()

            Me.Employee = String.Empty
            Me.[Date] = New Date(Now.Year, Now.Month, 1)
            Me.Hours = 0

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Employee & " - " & Me.[Date].ToShortDateString

        End Function

#End Region

    End Class

End Namespace
