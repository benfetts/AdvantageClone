Namespace DTO.Security.Setup.CDPSecurityGroup

    Public Class CDPSecurityGroup
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.Name = String.Empty

        End Sub
        Public Sub New(CDPSecurityGroup As AdvantageFramework.Database.Entities.CDPSecurityGroup)

            Me.ID = CDPSecurityGroup.ID
            Me.Name = CDPSecurityGroup.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.Name

        End Function

#End Region

    End Class

End Namespace
