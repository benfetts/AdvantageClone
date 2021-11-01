Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanResourceStaff
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            ID
            Name
            OfficeCode
            Office
            EmployeeTitleID
            EmployeeTitle
            DepartmentTeamCode
            DepartmentTeam
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Selected() As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Name() As String
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Office() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property EmployeeTitle() As String
        <MaxLength(4)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DepartmentTeamCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property DepartmentTeam() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Selected = False
            Me.ID = 0
            Me.Name = String.Empty
            Me.OfficeCode = Nothing
            Me.Office = String.Empty
            Me.EmployeeTitleID = Nothing
            Me.EmployeeTitle = String.Empty
            Me.DepartmentTeamCode = Nothing
            Me.DepartmentTeam = String.Empty

        End Sub
        Public Sub New(RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff)

            Me.Selected = False
            Me.ID = RevenueResourcePlanStaff.ID
            Me.Name = If(String.IsNullOrWhiteSpace(RevenueResourcePlanStaff.EmployeeCode), RevenueResourcePlanStaff.AltEmployeeName, If(RevenueResourcePlanStaff.Employee IsNot Nothing, RevenueResourcePlanStaff.Employee.ToString, String.Empty))
            Me.OfficeCode = RevenueResourcePlanStaff.OfficeCode
            Me.Office = If(RevenueResourcePlanStaff.Office IsNot Nothing, RevenueResourcePlanStaff.Office.Name, String.Empty)
            Me.EmployeeTitleID = RevenueResourcePlanStaff.EmployeeTitleID
            Me.EmployeeTitle = If(RevenueResourcePlanStaff.EmployeeTitle IsNot Nothing, RevenueResourcePlanStaff.EmployeeTitle.Description, String.Empty)
            Me.DepartmentTeamCode = RevenueResourcePlanStaff.DepartmentTeamCode
            Me.DepartmentTeam = If(RevenueResourcePlanStaff.DepartmentTeam IsNot Nothing, RevenueResourcePlanStaff.DepartmentTeam.Description, String.Empty)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Name.ToString

        End Function

#End Region

    End Class

End Namespace
