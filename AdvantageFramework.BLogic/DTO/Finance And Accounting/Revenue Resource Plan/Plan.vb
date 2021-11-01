Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class Plan
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OwnerCode
            Owner
            OfficeCode
            Office
            StartDate
            EndDate
            Description
            Notes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OwnerCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Owner() As String
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Office() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDate() As Date
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Notes() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.OwnerCode = Nothing
            Me.Owner = String.Empty
            Me.OfficeCode = Nothing
            Me.Office = String.Empty
            Me.StartDate = New Date(Now.Year, Now.Month, 1)
            Me.EndDate = New Date(Now.Year + 1, If(Now.Month = 1, 12, Now.Month - 1), Date.DaysInMonth(Now.Year + 1, If(Now.Month = 1, 12, Now.Month - 1)))
            Me.Description = String.Empty
            Me.Notes = String.Empty
            Me.IsInactive = False

        End Sub
        Public Sub New(RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan)

            Me.ID = RevenueResourcePlan.ID
            Me.OwnerCode = RevenueResourcePlan.EmployeeCode
            Me.Owner = If(RevenueResourcePlan.Employee IsNot Nothing, RevenueResourcePlan.Employee.ToString, String.Empty)
            Me.OfficeCode = RevenueResourcePlan.OfficeCode
            Me.Office = If(RevenueResourcePlan.Office IsNot Nothing, RevenueResourcePlan.Office.Name, String.Empty)
            Me.StartDate = RevenueResourcePlan.StartDate
            Me.EndDate = RevenueResourcePlan.EndDate
            Me.Description = RevenueResourcePlan.Description
            Me.Notes = RevenueResourcePlan.Notes
            Me.IsInactive = RevenueResourcePlan.IsInactive

        End Sub
        Public Sub SaveToEntity(ByRef RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan)

            RevenueResourcePlan.EmployeeCode = Me.OwnerCode
            RevenueResourcePlan.OfficeCode = Me.OfficeCode
            RevenueResourcePlan.StartDate = Me.StartDate
            RevenueResourcePlan.EndDate = Me.EndDate
            RevenueResourcePlan.Description = Me.Description
            RevenueResourcePlan.Notes = If(String.IsNullOrWhiteSpace(Me.Notes), String.Empty, Me.Notes)
            RevenueResourcePlan.IsInactive = Me.IsInactive

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Description.ToString

        End Function

#End Region

    End Class

End Namespace
