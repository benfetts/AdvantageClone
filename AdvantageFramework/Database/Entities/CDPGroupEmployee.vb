Namespace Database.Entities

    <Table("CDP_GROUP_EMPLOYEE")>
    Public Class CDPSecurityGroupEmployee
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            CDPSecurityGroupID
            EmployeeCode
            Employee
            CDPSecurityGroup
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("CDP_GROUP_EMPLOYEE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("CDP_GROUP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CDPSecurityGroupID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EmployeeCode() As String

        Public Overridable Property CDPSecurityGroup As Database.Entities.CDPSecurityGroup
        Public Overridable Property Employee As Database.Views.Employee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.CDPSecurityGroupID.ToString & " - " & Me.EmployeeCode

        End Function

#End Region

    End Class

End Namespace
