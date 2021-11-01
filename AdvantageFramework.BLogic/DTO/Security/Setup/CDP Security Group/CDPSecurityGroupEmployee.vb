Namespace DTO.Security.Setup.CDPSecurityGroup

    Public Class CDPSecurityGroupEmployee
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            CDPSecurityGroupID
            EmployeeCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property CDPSecurityGroupID() As Integer
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EmployeeCode() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.CDPSecurityGroupID = 0
            Me.EmployeeCode = String.Empty

        End Sub
        Public Sub New(CDPSecurityGroupEmployee As AdvantageFramework.Database.Entities.CDPSecurityGroupEmployee)

            Me.ID = CDPSecurityGroupEmployee.ID
            Me.CDPSecurityGroupID = CDPSecurityGroupEmployee.CDPSecurityGroupID
            Me.EmployeeCode = CDPSecurityGroupEmployee.EmployeeCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.CDPSecurityGroupID.ToString & " - " & Me.EmployeeCode

        End Function

#End Region

    End Class

End Namespace
