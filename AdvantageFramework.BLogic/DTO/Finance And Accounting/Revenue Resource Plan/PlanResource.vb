Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanResource
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanID
            ClientCode
            EmployeeCode
            Notes
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
        Public Property RevenueResourcePlanID() As Integer
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ClientCode() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanID = 0
            Me.ClientCode = Nothing
            Me.EmployeeCode = Nothing
            Me.Notes = String.Empty

        End Sub
        Public Sub New(RevenueResourcePlanResource As AdvantageFramework.Database.Entities.RevenueResourcePlanResource)

            Me.ID = RevenueResourcePlanResource.ID
            Me.RevenueResourcePlanID = RevenueResourcePlanResource.RevenueResourcePlanID
            Me.ClientCode = RevenueResourcePlanResource.ClientCode
            Me.EmployeeCode = RevenueResourcePlanResource.EmployeeCode
            Me.Notes = RevenueResourcePlanResource.Notes

        End Sub
        Public Sub SaveToEntity(ByRef RevenueResourcePlanResource As AdvantageFramework.Database.Entities.RevenueResourcePlanResource)

            RevenueResourcePlanResource.ClientCode = Me.ClientCode
            RevenueResourcePlanResource.EmployeeCode = Me.EmployeeCode
            RevenueResourcePlanResource.Notes = Me.Notes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
