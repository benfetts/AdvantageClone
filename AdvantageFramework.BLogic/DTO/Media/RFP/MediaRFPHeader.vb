Namespace DTO.Media.RFP

    Public Class MediaRFPHeader
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketDetailID
            VendorCode
            VendorName
            RequestDate
            DueDate
            TimeDue
            LastStatusDate
            Status
            Comments
            CommentToVendor
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property VendorName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Syscode As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property RequestDate As Date?
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsAutoFillProperty:=True)>
        Public Property DueDate As Date?
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsAutoFillProperty:=True)>
        Public Property TimeDue As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="g")>
        Public Property LastStatusDate As Nullable(Of Date)
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Status As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Comment to Vendor", DefaultColumnType:=BaseClasses.Methods.DefaultColumnTypes.Memo)>
        Public Property CommentToVendor As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Avail Comment")>
        Public Property Comments As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaTypeCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property NCCTVSyscodeID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property AlertID As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader)

            Me.ID = MediaRFPHeader.ID
            Me.MediaBroadcastWorksheetMarketID = MediaRFPHeader.MediaBroadcastWorksheetMarketID
            Me.VendorCode = MediaRFPHeader.VendorCode
            Me.VendorName = MediaRFPHeader.Vendor.Name
            Me.Syscode = MediaRFPHeader.Syscode
            Me.RequestDate = MediaRFPHeader.RequestDate
            Me.DueDate = MediaRFPHeader.DueDate
            Me.TimeDue = MediaRFPHeader.TimeDue
            Me.MediaTypeCode = MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode
            Me.NCCTVSyscodeID = MediaRFPHeader.Vendor.NCCTVSyscodeID
            Me.Comments = MediaRFPHeader.Comments
            Me.CommentToVendor = MediaRFPHeader.CommentToVendor
            Me.AlertID = MediaRFPHeader.AlertID

            SetStatus(MediaRFPHeader.MediaRFPHeaderStatuses.ToList)

        End Sub
        Private Sub SetStatus(MediaRFPHeaderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPHeaderStatus))

            'objects
            Dim MediaRFPHeaderStatusLastCreated As AdvantageFramework.Database.Entities.MediaRFPHeaderStatus = Nothing

            If MediaRFPHeaderStatuses IsNot Nothing AndAlso MediaRFPHeaderStatuses.Count > 0 Then

                MediaRFPHeaderStatusLastCreated = MediaRFPHeaderStatuses.OrderByDescending(Function(S) S.CreatedDate).First

                Me.Status = MediaRFPHeaderStatusLastCreated.MediaRFPStatus.StatusDescription
                Me.LastStatusDate = MediaRFPHeaderStatusLastCreated.CreatedDate

            Else

                Me.Status = "Pending"
                Me.LastStatusDate = Nothing

            End If

        End Sub
        Public Sub RefreshStatus(DbContext As AdvantageFramework.Database.DbContext)

            'objects
            Dim MediaRFPHeaderStatuses As Generic.List(Of AdvantageFramework.Database.Entities.MediaRFPHeaderStatus) = Nothing

            MediaRFPHeaderStatuses = AdvantageFramework.Database.Procedures.MediaRFPHeaderStatus.LoadByMediaRFPHeaderID(DbContext, Me.ID).ToList

            SetStatus(MediaRFPHeaderStatuses)

        End Sub

#End Region

    End Class

End Namespace
