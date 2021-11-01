Namespace DTO

    Public Class Client
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientName() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.IsInactive = False

        End Sub
        Public Sub New(Client As AdvantageFramework.Database.Entities.Client)

            Me.ClientCode = Client.Code
            Me.ClientName = Client.Name
            Me.IsInactive = (Client.IsActive = 0)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString & " - " & Me.ClientName.ToString

        End Function

#End Region

    End Class

End Namespace
