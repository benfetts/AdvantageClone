Namespace DTO.Media.Traffic

    Public Class Revision
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevisionNumber
            Description
            StartDate
            EndDate
            Status
            Modified
            MediaTrafficID
            GeneratedToOneOrMoreVendors
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="ID")>
        Public Property MediaTrafficID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Rev Nbr")>
        Public Property RevisionNumber As Integer
        <MaxLength(80)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property StartDate As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property EndDate As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Status As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property GeneratedToOneOrMoreVendors As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Max Rev#")>
        Public Property MaxRevisionNumber As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property CreativeGroupCount As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public ReadOnly Property SubItemGridLookupDescription As String
            Get
                SubItemGridLookupDescription = "ID: " & Me.MediaTrafficID.ToString & " Rev: " & Me.RevisionNumber.ToString & " - " & Me.Description
            End Get
        End Property
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BroadcastWorksheetStartDate As Date
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property BroadcastWorksheetEndDate As Date

#End Region

#Region " Methods "

        Public Sub New()

            Me.Status = String.Empty
            Me.GeneratedToOneOrMoreVendors = False

        End Sub
        Public Sub New(MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision, DbContext As AdvantageFramework.Database.DbContext,
                       BroadcastWorksheetStartDate As Date, BroadcastWorksheetEndDate As Date)

            Me.ID = MediaTrafficRevision.ID
            Me.RevisionNumber = MediaTrafficRevision.RevisionNumber
            Me.Description = MediaTrafficRevision.Description
            Me.StartDate = MediaTrafficRevision.StartDate
            Me.EndDate = MediaTrafficRevision.EndDate
            Me.MediaTrafficID = MediaTrafficRevision.MediaTrafficID
            Me.GeneratedToOneOrMoreVendors = False
            Me.BroadcastWorksheetStartDate = BroadcastWorksheetStartDate
            Me.BroadcastWorksheetEndDate = BroadcastWorksheetEndDate

            For Each MediaTrafficVendor In MediaTrafficRevision.MediaTrafficVendors

                If MediaTrafficVendor.MediaTrafficVendorStatuses.Any(Function(S) S.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Accepted) = True Then

                    Me.Status = "Accepted by one or more vendor(s)"

                ElseIf MediaTrafficVendor.MediaTrafficVendorStatuses.Any(Function(S) S.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Received) = True Then

                    Me.Status = "Received by one or more vendor(s)"

                End If

                If MediaTrafficVendor.MediaTrafficVendorStatuses.Any(Function(S) S.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Generated) = True Then

                    Me.GeneratedToOneOrMoreVendors = True

                    If String.IsNullOrWhiteSpace(Me.Status) Then

                        Me.Status = "Generated to one or more vendor(s)"

                    End If

                End If

            Next

            Me.MaxRevisionNumber = AdvantageFramework.Database.Procedures.MediaTrafficRevision.LoadByMediaTrafficID(DbContext, Me.MediaTrafficID).Max(Function(MTR) MTR.RevisionNumber)
            Me.CreativeGroupCount = MediaTrafficRevision.MediaTrafficCreativeGroups.Count

        End Sub
        Public Sub SaveToEntity(ByRef MediaTrafficRevision As AdvantageFramework.Database.Entities.MediaTrafficRevision)

            MediaTrafficRevision.Description = Me.Description
            MediaTrafficRevision.StartDate = Me.StartDate
            MediaTrafficRevision.EndDate = Me.EndDate

        End Sub

#End Region

    End Class

End Namespace
