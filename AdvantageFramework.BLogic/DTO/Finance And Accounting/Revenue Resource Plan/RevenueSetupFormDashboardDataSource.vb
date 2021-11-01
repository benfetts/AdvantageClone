Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class RevenueSetupFormDashboardDataSource
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Client
            [Date]
            Revenue
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        Public Property Client() As String
        <Required>
        Public Property [Date]() As Date
        <Required>
        <System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString:="n2")>
        Public Property Revenue() As Decimal

#End Region

#Region " Methods "

        Public Sub New(RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate)

            Me.Client = If(RevenueResourcePlanRevenueDetailDate.RevenueResourcePlanRevenueDetail.Client IsNot Nothing, RevenueResourcePlanRevenueDetailDate.RevenueResourcePlanRevenueDetail.Client.Name, String.Empty)
            Me.[Date] = RevenueResourcePlanRevenueDetailDate.Date
            Me.Revenue = RevenueResourcePlanRevenueDetailDate.Revenue

        End Sub
        Public Sub New(RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate, Client As AdvantageFramework.Database.Entities.Client)

            Me.Client = If(Client IsNot Nothing, Client.Name, String.Empty)
            Me.[Date] = RevenueResourcePlanRevenueDetailDate.Date
            Me.Revenue = RevenueResourcePlanRevenueDetailDate.Revenue

        End Sub
        Public Sub New(RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate, ClientName As String)

            Me.Client = ClientName
            Me.[Date] = RevenueResourcePlanRevenueDetailDate.Date
            Me.Revenue = RevenueResourcePlanRevenueDetailDate.Revenue

            'Me.Revenue = CInt(Math.Ceiling(Rnd() * 3)) + 1

        End Sub
        Public Sub New()

            Me.Client = String.Empty
            Me.[Date] = New Date(Now.Year, Now.Month, 1)
            Me.Revenue = 0

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Client & " - " & Me.[Date].ToShortDateString

        End Function

#End Region

    End Class

End Namespace
