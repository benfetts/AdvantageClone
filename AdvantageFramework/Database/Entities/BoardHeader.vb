Namespace Database.Entities

    <Serializable()>
    <Table("BOARD_HDR")>
    Public Class BoardHeader
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            Name
            Description
            CreatedBy
            CreateDate
            LastModified
            IsSystem
            IsSequential
            ForceAllColumns
            SwimLaneID
            AlertTemplateID
            ExcludeTasks
            IsActive
            TrackChanges
            EmailOnChange

            BoardColumns

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Required>
        <MaxLength(50)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name As String

        <Column("DESCRIPTION", TypeName:="varchar(MAX)")>
        Public Property Description As String

        <MaxLength(6)>
        <Column("CREATED_BY", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedBy As String

        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate As DateTime?

        <Column("LAST_MODIFIED")>
        Public Property LastModified As DateTime?

        <Column("IS_SYSTEM")>
        Public Property IsSystem As Boolean?

        <Column("SEQUENTIAL")>
        Public Property IsSequential As Boolean?

        <Column("FORCE_ALL")>
        Public Property ForceAllColumns As Boolean?

        <Column("SWIM_LANE_ID")>
        Public Property SwimLaneID As Integer?

        <Column("ALRT_NOTIFY_HDR_ID")>
        Public Property AlertTemplateID As Integer?

        <Column("EXCLUDE_TASKS")>
        Public Property ExcludeTasks As Boolean?

        <Column("IS_ACTIVE")>
        Public Property IsActive As Boolean?

        <Column("TRACK_CHANGES")>
        Public Property TrackChanges As Boolean?

        <Column("EMAIL_ON_CHANGE")>
        Public Property EmailOnChange As Boolean?

        Public Overridable Property BoardColumns As ICollection(Of Database.Entities.BoardColumn)

#End Region

#Region " Methods "

        Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
