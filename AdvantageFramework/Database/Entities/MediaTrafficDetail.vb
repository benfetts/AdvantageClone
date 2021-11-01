Namespace Database.Entities

    <Table("MEDIA_TRAFFIC_DETAIL")>
    Public Class MediaTrafficDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTrafficCreativeGroupID
            DayPartID
            Length
            StartTime
            EndTime
            AdNumber
            CreativeTitle
            Location
            IsBookend
            BookendName
            BookendSequenceNumber
            Position
            Rotation
            Comment
            MediaTrafficRevision
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_TRAFFIC_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_TRAFFIC_CREATIVE_GROUP_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTrafficCreativeGroupID() As Integer
        <Column("DAY_PART_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property DayPartID() As Nullable(Of Integer)
        <Required>
        <Column("LENGTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Length() As Short
        <MaxLength(10)>
        <Column("START_TIME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property StartTime() As String
        <MaxLength(10)>
        <Column("END_TIME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EndTime() As String
        <MaxLength(30)>
        <Column("AD_NBR", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property AdNumber() As String
        <MaxLength(100)>
        <Column("CREATIVE_TITLE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property CreativeTitle() As String
        <MaxLength(100)>
        <Column("LOCATION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Location() As String
        <Required>
        <Column("BOOKEND")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsBookend() As Boolean
        <MaxLength(30)>
        <Column("BOOKEND_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BookendName() As String
        <Required>
        <Column("BOOKEND_SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BookendSequenceNumber() As Short
        <Column("POSITION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Position() As Nullable(Of Short)
        <Required>
        <Column("ROTATION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Rotation As Short
        <MaxLength(2000)>
        <Column("COMMENT", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Comment() As String

        <ForeignKey("MediaTrafficCreativeGroupID")>
        Public Overridable Property MediaTrafficCreativeGroup As Database.Entities.MediaTrafficCreativeGroup

        <ForeignKey("AdNumber")>
        Public Overridable Property Ad As Database.Entities.Ad

        Public Overridable Property MediaTrafficDetailDocuments As ICollection(Of Database.Entities.MediaTrafficDetailDocument)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
