Namespace Database.Entities

    <Table("MEDIA_RFP_HEADER_STATUS")>
    Public Class MediaRFPHeaderStatus
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaRFPHeaderID
            MediaRFPStatusID
            CreatedDate
            CreatedByUserCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_RFP_HEADER_STATUS_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_RFP_HEADER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaRFPHeaderID() As Integer
        <Required>
        <Column("MEDIA_RFP_STATUS_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaRFPStatusID() As AdvantageFramework.Database.Entities.MediaRFPStatusID
        <Required>
        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <Required>
        <MaxLength(100)>
        <Column("USER_CREATED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String

        <ForeignKey("MediaRFPHeaderID")>
        Public Overridable Property MediaRFPHeader As Database.Entities.MediaRFPHeader

        <ForeignKey("MediaRFPStatusID")>
        Public Overridable Property MediaRFPStatus As Database.Entities.MediaRFPStatus

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
