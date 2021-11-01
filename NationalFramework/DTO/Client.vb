Namespace DTO

    Public Class Client
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Code
            Name
            IsInactive
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer

        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Code() As String

        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsInactive() As Boolean

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(Client As Database.Entities.Client)

            Me.ID = Client.ID
            Me.Code = Client.Code
            Me.Name = Client.Name
            Me.IsInactive = Client.IsInactive

        End Sub
        Public Sub SaveToEntity(ByRef Client As Database.Entities.Client)

            Client.ID = Me.ID
            Client.Code = Me.Code
            Client.Name = Me.Name
            Client.IsInactive = Me.IsInactive

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
