Namespace DTO.Security.Setup.CDPSecurityGroup

    Public Class Employee
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            CDPSecurityGroupID
            DepartmentTeamCode
            DepartmentTeam
            OfficeCode
            OfficeName
            EmployeeCode
            EmployeeName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CDPSecurityGroupID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property OfficeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Office")>
        Public Property Office() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property DepartmentTeamCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Department/Team")>
        Public Property DepartmentTeam() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Employee")>
        Public Property EmployeeName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Terminated")>
        Public Property Terminated() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.CDPSecurityGroupID = 0
            Me.OfficeCode = String.Empty
            Me.Office = String.Empty
            Me.DepartmentTeamCode = String.Empty
            Me.DepartmentTeam = String.Empty
            Me.EmployeeCode = String.Empty
            Me.EmployeeName = String.Empty
            Me.Terminated = False

        End Sub
        Public Sub New(CDPSecurityGroupEmployee As AdvantageFramework.Database.Entities.CDPSecurityGroupEmployee)

            Me.ID = CDPSecurityGroupEmployee.ID
            Me.CDPSecurityGroupID = CDPSecurityGroupEmployee.CDPSecurityGroupID
            Me.OfficeCode = If(CDPSecurityGroupEmployee.Employee IsNot Nothing, CDPSecurityGroupEmployee.Employee.OfficeCode, String.Empty)
            Me.Office = If(CDPSecurityGroupEmployee.Employee IsNot Nothing, If(CDPSecurityGroupEmployee.Employee.Office IsNot Nothing, CDPSecurityGroupEmployee.Employee.Office.Name, String.Empty), String.Empty)
            Me.DepartmentTeamCode = If(CDPSecurityGroupEmployee.Employee IsNot Nothing, CDPSecurityGroupEmployee.Employee.DepartmentTeamCode, String.Empty)
            Me.DepartmentTeam = If(CDPSecurityGroupEmployee.Employee IsNot Nothing, If(CDPSecurityGroupEmployee.Employee.DepartmentTeam IsNot Nothing, CDPSecurityGroupEmployee.Employee.DepartmentTeam.Description, String.Empty), String.Empty)
            Me.EmployeeCode = CDPSecurityGroupEmployee.EmployeeCode
            Me.EmployeeName = If(CDPSecurityGroupEmployee.Employee IsNot Nothing, CDPSecurityGroupEmployee.Employee.ToString, String.Empty)
            Me.Terminated = If(CDPSecurityGroupEmployee.Employee IsNot Nothing, CDPSecurityGroupEmployee.Employee.TerminationDate.HasValue, False)

        End Sub
        Public Sub New(Employee As AdvantageFramework.Database.Views.Employee)

            Me.ID = 0
            Me.CDPSecurityGroupID = 0
            Me.OfficeCode = If(Employee IsNot Nothing, Employee.OfficeCode, String.Empty)
            Me.Office = If(Employee IsNot Nothing, If(Employee.Office IsNot Nothing, Employee.Office.Name, String.Empty), String.Empty)
            Me.DepartmentTeamCode = If(Employee IsNot Nothing, Employee.DepartmentTeamCode, String.Empty)
            Me.DepartmentTeam = If(Employee IsNot Nothing, If(Employee.DepartmentTeam IsNot Nothing, Employee.DepartmentTeam.Description, String.Empty), String.Empty)
            Me.EmployeeCode = Employee.Code
            Me.EmployeeName = Employee.ToString
            Me.Terminated = If(Employee IsNot Nothing, Employee.TerminationDate.HasValue, False)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.EmployeeCode.ToString

        End Function

#End Region

    End Class

End Namespace
