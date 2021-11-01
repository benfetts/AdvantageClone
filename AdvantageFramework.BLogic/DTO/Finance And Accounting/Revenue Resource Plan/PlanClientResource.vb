Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanClientResource
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
            RevenueResourcePlanResourceRevisionID
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
        Public Property RevenueResourcePlanResourceRevisionID() As Integer
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
            Me.RevenueResourcePlanResourceRevisionID = 0
            Me.RevisionNumber = 1
            Me.Approved = False
            Me.ApprovedByCode = Nothing
            Me.ApprovedBy = String.Empty
            Me.ApprovedDate = Nothing
            Me.RevisionNotes = String.Empty

        End Sub
        Public Sub New(RevenueResourcePlanResource As AdvantageFramework.Database.Entities.RevenueResourcePlanResource)

            'objects
            Dim MaxRevision As Integer = 0
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing

            Me.ID = RevenueResourcePlanResource.ID
            Me.RevenueResourcePlanID = RevenueResourcePlanResource.RevenueResourcePlanID
            Me.ClientCode = RevenueResourcePlanResource.ClientCode
            Me.Client = If(RevenueResourcePlanResource.Client IsNot Nothing, RevenueResourcePlanResource.Client.Name, String.Empty)
            Me.OwnerCode = RevenueResourcePlanResource.EmployeeCode
            Me.Notes = RevenueResourcePlanResource.Notes

            If RevenueResourcePlanResource.RevenueResourcePlanResourceRevisions IsNot Nothing AndAlso RevenueResourcePlanResource.RevenueResourcePlanResourceRevisions.Count > 0 Then

                MaxRevision = RevenueResourcePlanResource.RevenueResourcePlanResourceRevisions.Select(Function(Entity) Entity.RevisionNumber).Max

                Try

                    RevenueResourcePlanResourceRevision = RevenueResourcePlanResource.RevenueResourcePlanResourceRevisions.SingleOrDefault(Function(Entity) Entity.RevisionNumber = MaxRevision)

                Catch ex As Exception
                    RevenueResourcePlanResourceRevision = Nothing
                End Try

            Else

                MaxRevision = 1
                RevenueResourcePlanResourceRevision = Nothing

            End If

            Me.RevisionNumber = MaxRevision

            If RevenueResourcePlanResourceRevision IsNot Nothing Then

                Me.RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevision.ID
                Me.Approved = RevenueResourcePlanResourceRevision.Approved
                Me.ApprovedByCode = RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode
                Me.ApprovedBy = If(RevenueResourcePlanResourceRevision.ApprovedByEmployee IsNot Nothing, RevenueResourcePlanResourceRevision.ApprovedByEmployee.ToString, String.Empty)
                Me.ApprovedDate = RevenueResourcePlanResourceRevision.ApprovedDate
                Me.RevisionNotes = RevenueResourcePlanResourceRevision.Notes

            Else

                Me.RevenueResourcePlanResourceRevisionID = 0
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
