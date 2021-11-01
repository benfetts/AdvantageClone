Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanResourceRevision
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanID
            RevenueResourcePlanResourceID
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
        Public Property RevenueResourcePlanResourceID() As Integer
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
            Me.RevenueResourcePlanResourceID = 0
            Me.RevisionNumber = 1
            Me.Approved = False
            Me.ApprovedByEmployeeCode = Nothing
            Me.ApprovedByEmployee = String.Empty
            Me.ApprovedDate = Nothing
            Me.Notes = String.Empty

        End Sub
        Public Sub New(RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision)

            Me.ID = RevenueResourcePlanResourceRevision.ID
            Me.RevenueResourcePlanID = RevenueResourcePlanResourceRevision.RevenueResourcePlanResource.RevenueResourcePlanID
            Me.RevenueResourcePlanResourceID = RevenueResourcePlanResourceRevision.RevenueResourcePlanResourceID
            Me.RevisionNumber = RevenueResourcePlanResourceRevision.RevisionNumber
            Me.Approved = RevenueResourcePlanResourceRevision.Approved
            Me.ApprovedByEmployeeCode = RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode
            Me.ApprovedByEmployee = If(RevenueResourcePlanResourceRevision.ApprovedByEmployee IsNot Nothing, RevenueResourcePlanResourceRevision.ApprovedByEmployee.ToString, String.Empty)
            Me.ApprovedDate = RevenueResourcePlanResourceRevision.ApprovedDate
            Me.Notes = RevenueResourcePlanResourceRevision.Notes

        End Sub
        Public Sub SaveToEntity(ByRef RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision)

            RevenueResourcePlanResourceRevision.Approved = Me.Approved
            RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode = Me.ApprovedByEmployeeCode
            RevenueResourcePlanResourceRevision.ApprovedDate = Me.ApprovedDate
            RevenueResourcePlanResourceRevision.Notes = Me.Notes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.RevenueResourcePlanID.ToString & " - " & Me.RevisionNumber.ToString

        End Function

#End Region

    End Class

End Namespace
