Namespace DTO.Media.Traffic

    Public Class Vendor
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTrafficRevisionID
            StartDate
            EndDate
            VendorCode
            VendorName
            LastStatusDate
            Status
            AcceptedStatus
            AcceptedStatusDate
            AlertID
            IsCableSystem
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, CustomColumnCaption:="Instruction", PropertyType:=BaseClasses.Methods.PropertyTypes.MediaTrafficRevision)>
        Public Property MediaTrafficRevisionID() As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property StartDate() As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EndDate() As Nullable(Of Date)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.VendorCode)>
        Public Property VendorCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, DisplayFormat:="", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.VendorName)>
        Public Property VendorName() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property LastStatusDate As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Status As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property AcceptedStatus As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property AcceptedStatusDate As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property IsCableSystem() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficRevisionDescription As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTrafficID As Integer

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor)

            Me.ID = MediaTrafficVendor.ID
            Me.MediaTrafficRevisionID = MediaTrafficVendor.MediaTrafficRevisionID
            Me.StartDate = MediaTrafficVendor.MediaTrafficRevision.StartDate
            Me.EndDate = MediaTrafficVendor.MediaTrafficRevision.EndDate
            Me.VendorCode = MediaTrafficVendor.VendorCode
            Me.VendorName = MediaTrafficVendor.Vendor.Name
            Me.AlertID = MediaTrafficVendor.AlertID
            Me.IsCableSystem = MediaTrafficVendor.Vendor.IsCableSystem AndAlso MediaTrafficVendor.Vendor.NCCTVSyscodeID.HasValue
            Me.MediaTrafficRevisionDescription = MediaTrafficVendor.MediaTrafficRevision.Description
            Me.MediaTrafficID = MediaTrafficVendor.MediaTrafficRevision.MediaTrafficID

            SetStatus(MediaTrafficVendor.MediaTrafficVendorStatuses.ToList)

        End Sub
        Public Sub SaveToEntity(ByRef MediaTrafficVendor As AdvantageFramework.Database.Entities.MediaTrafficVendor)

            MediaTrafficVendor.MediaTrafficRevisionID = Me.MediaTrafficRevisionID
            MediaTrafficVendor.VendorCode = Me.VendorCode

        End Sub
        Private Sub SetStatus(MediaTrafficVendorStatuses As Generic.List(Of AdvantageFramework.Database.Entities.MediaTrafficVendorStatus))

            'objects
            Dim MediaTrafficVendorStatusLastCreated As AdvantageFramework.Database.Entities.MediaTrafficVendorStatus = Nothing

            If MediaTrafficVendorStatuses IsNot Nothing AndAlso MediaTrafficVendorStatuses.Count > 0 Then

                MediaTrafficVendorStatusLastCreated = MediaTrafficVendorStatuses.OrderByDescending(Function(S) S.CreatedDate).First

                Me.Status = MediaTrafficVendorStatusLastCreated.MediaTrafficStatus.StatusDescription
                Me.LastStatusDate = MediaTrafficVendorStatusLastCreated.CreatedDate

                If MediaTrafficVendorStatuses.Any(Function(S) S.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Accepted) Then

                    Me.AcceptedStatus = "Accepted"
                    Me.AcceptedStatusDate = MediaTrafficVendorStatuses.First(Function(S) S.MediaTrafficStatusID = Database.Entities.Methods.MediaTrafficStatusID.Accepted).CreatedDate

                End If

            Else

                Me.Status = "Pending"
                Me.LastStatusDate = Nothing

            End If

        End Sub

#End Region

    End Class

End Namespace
