Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanStaffEmployee
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanID
            EmployeeCode
            EmployeeName
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

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property RevenueResourcePlanID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Code")>
        Public Property EmployeeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Name")>
        Public Property EmployeeName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Office() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property EmployeeTitleID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeTitle() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DepartmentTeamCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DepartmentTeam() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanID = 0
            Me.EmployeeCode = Nothing
            Me.EmployeeName = String.Empty
            Me.OfficeCode = Nothing
            Me.Office = String.Empty
            Me.EmployeeTitleID = Nothing
            Me.EmployeeTitle = String.Empty
            Me.DepartmentTeamCode = Nothing
            Me.DepartmentTeam = String.Empty

        End Sub
        Public Sub New(RevenueResourcePlanID As Integer, Employee As AdvantageFramework.Database.Views.Employee)

            Me.ID = 0
            Me.RevenueResourcePlanID = RevenueResourcePlanID
            Me.EmployeeCode = Employee.Code
            Me.EmployeeName = Employee.ToString
            Me.OfficeCode = Employee.OfficeCode
            Me.Office = If(Employee.Office IsNot Nothing, Employee.Office.Name, String.Empty)
            Me.EmployeeTitleID = Employee.EmployeeTitleID
            Me.EmployeeTitle = If(Employee.EmployeeTitle IsNot Nothing, Employee.EmployeeTitle.Description, String.Empty)
            Me.DepartmentTeamCode = Employee.DepartmentTeamCode
            Me.DepartmentTeam = If(Employee.DepartmentTeam IsNot Nothing, Employee.DepartmentTeam.Description, String.Empty)

        End Sub
        Public Sub New(RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff)

            Me.ID = RevenueResourcePlanStaff.ID
            Me.RevenueResourcePlanID = RevenueResourcePlanStaff.RevenueResourcePlanID
            Me.EmployeeCode = RevenueResourcePlanStaff.EmployeeCode
            Me.EmployeeName = If(RevenueResourcePlanStaff.Employee IsNot Nothing, RevenueResourcePlanStaff.Employee.ToString, String.Empty)
            Me.OfficeCode = RevenueResourcePlanStaff.OfficeCode
            Me.Office = If(RevenueResourcePlanStaff.Office IsNot Nothing, RevenueResourcePlanStaff.Office.Name, String.Empty)
            Me.EmployeeTitleID = RevenueResourcePlanStaff.EmployeeTitleID
            Me.EmployeeTitle = If(RevenueResourcePlanStaff.EmployeeTitle IsNot Nothing, RevenueResourcePlanStaff.EmployeeTitle.Description, String.Empty)
            Me.DepartmentTeamCode = RevenueResourcePlanStaff.DepartmentTeamCode
            Me.DepartmentTeam = If(RevenueResourcePlanStaff.DepartmentTeam IsNot Nothing, RevenueResourcePlanStaff.DepartmentTeam.Description, String.Empty)

        End Sub
        Public Sub SaveToEntity(ByRef RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff)

            RevenueResourcePlanStaff.EmployeeCode = Me.EmployeeCode
            RevenueResourcePlanStaff.OfficeCode = Me.OfficeCode
            RevenueResourcePlanStaff.EmployeeTitleID = Me.EmployeeTitleID
            RevenueResourcePlanStaff.DepartmentTeamCode = Me.DepartmentTeamCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.EmployeeCode.ToString

        End Function

#End Region

    End Class

End Namespace
