Namespace Database.Entities

    <Table("BOARD")>
    Public Class Board
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            Name
            Description
            BoardOwnerEmployeeCode
            BoardHeaderID
            OfficeCode
            CreateUser
            CreateDate
            CompletedDate
            IsActive
            TrackChanges
            EmailOnChange
            IncludeAllJobs

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
        <MaxLength(100)>
        <Column("NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name As String

        <Column("DESCRIPTION", TypeName:="varchar(MAX)")>
        Public Property Description As String

        <MaxLength(6)>
        <Column("BOARD_OWNER_EMP_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property BoardOwnerEmployeeCode As String

        <Column("BOARD_HDR_ID")>
        Public Property BoardHeaderID As Integer?

        <MaxLength(4)>
        <Column("OFFICE_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OfficeCode As String

        <MaxLength(100)>
        <Column("CREATE_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedByUserCode As String

        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedDate As DateTime?

        <Column("COMPLETED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompletedDate As DateTime?

        <Column("IS_ACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property IsActive As Boolean?

        <Column("TRACK_CHANGES")>
        Public Property TrackChanges As Boolean?

        <Column("EMAIL_ON_CHANGE")>
        Public Property EmailOnChange As Boolean?

        <Column("INCL_ALL_JOBS")>
        Public Property IncludeAllJobs As Boolean?

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
