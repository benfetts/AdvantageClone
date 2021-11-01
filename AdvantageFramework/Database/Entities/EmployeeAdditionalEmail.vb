Namespace Database.Entities

    <Table("EMPLOYEE_ADDL_EMAIL")>
    Public Class EmployeeAdditionalEmail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            EmployeeCode
            Email
            Employee
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("EMPLOYEE_ADDL_EMAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(6)>
        <Column("EMP_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property EmployeeCode() As String
        <Required>
        <MaxLength(50)>
        <Column("EMP_EMAIL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=AdvantageFramework.BaseClasses.PropertyTypes.Email)>
        Public Property Email() As String

        Public Overridable Property Employee As Database.Views.Employee

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.EmployeeCode

        End Function

#End Region

    End Class

End Namespace
