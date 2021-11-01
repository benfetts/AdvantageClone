Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanStaffClientAssignmentDivision
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
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
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Selected() As Boolean
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property ClientName() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property DivisionName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Selected = False
            Me.ClientCode = Nothing
            Me.ClientName = String.Empty
            Me.DivisionCode = Nothing
            Me.DivisionName = String.Empty

        End Sub
        Public Sub New(Division As AdvantageFramework.Database.Views.DivisionView)

            Me.Selected = False
            Me.ClientCode = Division.ClientCode
            Me.ClientName = Division.ClientName
            Me.DivisionCode = Division.DivisionCode
            Me.DivisionName = Division.DivisionName

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientName & " - " & Me.DivisionName

        End Function

#End Region

    End Class

End Namespace
