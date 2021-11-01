Namespace DTO.GeneralLedger.JournalEntry

    Public Class Division
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
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
        Public Property ClientCode() As String
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientName() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Code() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Name() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.Code = String.Empty
            Me.Name = String.Empty

        End Sub
        Public Sub New(Division As AdvantageFramework.Database.Views.DivisionView)

            Me.ClientCode = Division.ClientCode
            Me.ClientName = Division.ClientName
            Me.Code = Division.DivisionCode
            Me.Name = Division.DivisionName

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString & "-" & Me.Code.ToString

        End Function

#End Region

    End Class

End Namespace
