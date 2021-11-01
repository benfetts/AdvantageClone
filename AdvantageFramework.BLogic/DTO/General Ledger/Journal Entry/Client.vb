Namespace DTO.GeneralLedger.JournalEntry

    Public Class Client
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Code() As String
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Name = String.Empty

        End Sub
        Public Sub New(Client As AdvantageFramework.Database.Entities.Client)

            Me.Code = Client.Code
            Me.Name = Client.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString & " - " & Me.Name.ToString

        End Function

#End Region

    End Class

End Namespace
