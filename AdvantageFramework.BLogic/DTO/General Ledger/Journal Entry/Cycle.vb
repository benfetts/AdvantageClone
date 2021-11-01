Namespace DTO.GeneralLedger.JournalEntry

    Public Class Cycle
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
        <MaxLength(30)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Code = String.Empty
            Me.Name = String.Empty

        End Sub
        Public Sub New(Cycle As AdvantageFramework.Database.Entities.Cycle)

            Me.Code = Cycle.Code
            Me.Name = Cycle.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code.ToString & " - " & Me.Name.ToString

        End Function

#End Region

    End Class

End Namespace
