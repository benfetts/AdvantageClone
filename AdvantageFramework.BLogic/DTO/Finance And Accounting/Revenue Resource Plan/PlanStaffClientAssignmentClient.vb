Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanStaffClientAssignmentClient
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            ClientCode
            ClientName
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

#End Region

#Region " Methods "

        Public Sub New()

            Me.Selected = False
            Me.ClientCode = Nothing
            Me.ClientName = String.Empty

        End Sub
        Public Sub New(Client As AdvantageFramework.Database.Entities.Client)

            Me.ClientCode = Client.Code
            Me.ClientName = Client.Name

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ClientName

        End Function

#End Region

    End Class

End Namespace
