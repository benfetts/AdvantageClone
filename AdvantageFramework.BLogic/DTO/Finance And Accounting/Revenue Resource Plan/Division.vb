Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class Division
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ClientCode
            ClientName
            DivisionCode
            DivisionName
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
        Public Property DivisionCode() As String
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property DivisionName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ClientCode = String.Empty
            Me.ClientName = String.Empty
            Me.DivisionCode = String.Empty
            Me.DivisionName = String.Empty

        End Sub
        Public Sub New(Division As AdvantageFramework.Database.Views.DivisionView)

            Me.ClientCode = Division.ClientCode
            Me.ClientName = Division.ClientName
            Me.DivisionCode = Division.DivisionCode
            Me.DivisionName = Division.DivisionName

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientCode.ToString & "-" & Me.DivisionCode.ToString

        End Function

#End Region

    End Class

End Namespace
