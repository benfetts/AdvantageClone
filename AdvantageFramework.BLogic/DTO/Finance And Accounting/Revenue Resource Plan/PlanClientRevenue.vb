Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanClientRevenue
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanID
            ClientCode
            Client
            OwnerCode
            Notes
            RevenueResourcePlanRevenueRevisionID
            RevisionNumber
            Approved
            ApprovedByCode
            ApprovedBy
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
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Client() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Owner")>
        Public Property OwnerCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Notes() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property RevenueResourcePlanRevenueRevisionID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        Public Property RevisionNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Approved() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ApprovedByCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ApprovedBy() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property ApprovedDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RevisionNotes() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanID = 0
            Me.ClientCode = Nothing
            Me.Client = String.Empty
            Me.OwnerCode = Nothing
            Me.Notes = String.Empty
            Me.RevenueResourcePlanRevenueRevisionID = 0
            Me.RevisionNumber = 1
            Me.Approved = False
            Me.ApprovedByCode = Nothing
            Me.ApprovedBy = String.Empty
            Me.ApprovedDate = Nothing
            Me.RevisionNotes = String.Empty

        End Sub
        Public Sub New(RevenueResourcePlanRevenue As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue)

            'objects
            Dim MaxRevision As Integer = 0
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing

            Me.ID = RevenueResourcePlanRevenue.ID
            Me.RevenueResourcePlanID = RevenueResourcePlanRevenue.RevenueResourcePlanID
            Me.ClientCode = RevenueResourcePlanRevenue.ClientCode
            Me.Client = If(RevenueResourcePlanRevenue.Client IsNot Nothing, RevenueResourcePlanRevenue.Client.Name, String.Empty)
            Me.OwnerCode = RevenueResourcePlanRevenue.EmployeeCode
            Me.Notes = RevenueResourcePlanRevenue.Notes

            If RevenueResourcePlanRevenue.RevenueResourcePlanRevenueRevisions IsNot Nothing AndAlso RevenueResourcePlanRevenue.RevenueResourcePlanRevenueRevisions.Count > 0 Then

                MaxRevision = RevenueResourcePlanRevenue.RevenueResourcePlanRevenueRevisions.Select(Function(Entity) Entity.RevisionNumber).Max

                Try

                    RevenueResourcePlanRevenueRevision = RevenueResourcePlanRevenue.RevenueResourcePlanRevenueRevisions.SingleOrDefault(Function(Entity) Entity.RevisionNumber = MaxRevision)

                Catch ex As Exception
                    RevenueResourcePlanRevenueRevision = Nothing
                End Try

            Else

                MaxRevision = 1
                RevenueResourcePlanRevenueRevision = Nothing

            End If

            Me.RevisionNumber = MaxRevision

            If RevenueResourcePlanRevenueRevision IsNot Nothing Then

                Me.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueRevision.ID
                Me.Approved = RevenueResourcePlanRevenueRevision.Approved
                Me.ApprovedByCode = RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode
                Me.ApprovedBy = If(RevenueResourcePlanRevenueRevision.ApprovedByEmployee IsNot Nothing, RevenueResourcePlanRevenueRevision.ApprovedByEmployee.ToString, String.Empty)
                Me.ApprovedDate = RevenueResourcePlanRevenueRevision.ApprovedDate
                Me.RevisionNotes = RevenueResourcePlanRevenueRevision.Notes

            Else

                Me.RevenueResourcePlanRevenueRevisionID = 0
                Me.Approved = False
                Me.ApprovedByCode = Nothing
                Me.ApprovedBy = String.Empty
                Me.ApprovedDate = Nothing
                Me.RevisionNotes = String.Empty

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.ClientCode.ToString

        End Function

#End Region

    End Class

End Namespace
