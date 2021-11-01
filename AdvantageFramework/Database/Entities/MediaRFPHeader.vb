Namespace Database.Entities

    <Table("MEDIA_RFP_HEADER")>
    Public Class MediaRFPHeader
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaBroadcastWorksheetMarketID
            RequestDate
            DueDate
            VendorCode
            Syscode
            Comments
            CommentToVendor
            AlertID
            MediaBroadcastWorksheetMarket
            Vendor
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_RFP_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_BROADCAST_WORKSHEET_MARKET_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Column("REQUEST_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property RequestDate() As Nullable(Of Date)
        <Column("DUE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DueDate() As Nullable(Of Date)
        <Required>
        <MaxLength(6)>
        <Column("VN_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property VendorCode() As String
        <Column("SYSCODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property Syscode() As Nullable(Of Integer)
        <Column("COMMENTS", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comments() As String
        <Column("COMMENT_TO_VENDOR", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CommentToVendor() As String
        <Column("ALERT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AlertID() As Nullable(Of Integer)
        <Column("TIME_DUE", TypeName:="varchar")>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property TimeDue() As String

        <ForeignKey("MediaBroadcastWorksheetMarketID")>
        Public Overridable Property MediaBroadcastWorksheetMarket As Database.Entities.MediaBroadcastWorksheetMarket
        <ForeignKey("VendorCode")>
        Public Overridable Property Vendor As Database.Entities.Vendor
        <ForeignKey("AlertID")>
        Public Overridable Property Alert As Database.Entities.Alert
        Public Overridable Property MediaRFPAvailLines As ICollection(Of Database.Entities.MediaRFPAvailLine)
        Public Overridable Property MediaRFPHeaderStatuses As ICollection(Of Database.Entities.MediaRFPHeaderStatus)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
