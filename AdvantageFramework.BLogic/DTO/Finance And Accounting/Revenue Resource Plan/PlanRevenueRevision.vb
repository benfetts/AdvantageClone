Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanRevenueRevision
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanID
            RevenueResourcePlanRevenueID
            RevisionNumber
            Approved
            ApprovedByEmployeeCode
            ApprovedByEmployee
            ApprovedDate
            RevisionNotes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property RevenueResourcePlanID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property RevenueResourcePlanRevenueID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        Public Property RevisionNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Approved() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ApprovedByEmployeeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ApprovedByEmployee() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ApprovedDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanID = 0
            Me.RevenueResourcePlanRevenueID = 0
            Me.RevisionNumber = 1
            Me.Approved = False
            Me.ApprovedByEmployeeCode = Nothing
            Me.ApprovedByEmployee = String.Empty
            Me.ApprovedDate = Nothing
            Me.Notes = String.Empty

        End Sub
        Public Sub New(RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision)

            Me.ID = RevenueResourcePlanRevenueRevision.ID
            Me.RevenueResourcePlanID = RevenueResourcePlanRevenueRevision.RevenueResourcePlanRevenue.RevenueResourcePlanID
            Me.RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueRevision.RevenueResourcePlanRevenueID
            Me.RevisionNumber = RevenueResourcePlanRevenueRevision.RevisionNumber
            Me.Approved = RevenueResourcePlanRevenueRevision.Approved
            Me.ApprovedByEmployeeCode = RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode
            Me.ApprovedByEmployee = If(RevenueResourcePlanRevenueRevision.ApprovedByEmployee IsNot Nothing, RevenueResourcePlanRevenueRevision.ApprovedByEmployee.ToString, String.Empty)
            Me.ApprovedDate = RevenueResourcePlanRevenueRevision.ApprovedDate
            Me.Notes = RevenueResourcePlanRevenueRevision.Notes

        End Sub
        Public Sub SaveToEntity(ByRef RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision)

            RevenueResourcePlanRevenueRevision.Approved = Me.Approved
            RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode = Me.ApprovedByEmployeeCode
            RevenueResourcePlanRevenueRevision.ApprovedDate = Me.ApprovedDate
            RevenueResourcePlanRevenueRevision.Notes = Me.Notes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.RevenueResourcePlanID.ToString & " - " & Me.RevisionNumber.ToString

        End Function

#End Region

    End Class

End Namespace
