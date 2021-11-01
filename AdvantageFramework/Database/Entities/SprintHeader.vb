Namespace Database.Entities

    <Table("SPRINT_HDR")>
    Public Class SprintHeader
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            Description
            Comment
            BoardID
            SequenceNumber
            StartDate
            StartWeekNumber
            NumberOfWeeks
            IsActive
            IsComplete
            CreateUser
            CreateDate
            CompletedDate
            TrackChanges
            EmailOnChange
            ItemCount

            SprintDetails

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
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description As String

        <Column("COMMENT", TypeName:="varchar")>
        Public Property Comments As String

        <Required>
        <Column("BOARD_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property BoardID As Integer?

        <Column("SEQ_NBR")>
        Public Property SequenceNumber As Short?

        <Column("START_DATE")>
        Public Property StartDate As DateTime?

        <Column("START_WEEK_NUM")>
        Public Property StartWeekNumber As Integer?

        <Column("NUM_WEEKS")>
        Public Property NumberOfWeeks As Integer?

        <MaxLength(100)>
        <Column("CREATE_USER", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CreatedByUserCode As String

        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate As DateTime?

        <Column("IS_ACTIVE")>
        Public Property IsActive As Boolean?

        <Column("IS_COMPLETE")>
        Public Property IsComplete As Boolean?

        <Column("COMPLETED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CompletedDate As DateTime?

        <Column("TRACK_CHANGES")>
        Public Property TrackChanges As Boolean?

        <Column("EMAIL_ON_CHANGE")>
        Public Property EmailOnChange As Boolean?

        Public Overridable Property SprintDetails As ICollection(Of Database.Entities.SprintDetail)

#End Region

#Region " Methods "

        Public Overrides Function ValidateEntity(ByRef IsValid As Boolean) As String

            ValidateEntity = MyBase.ValidateEntity(IsValid)

        End Function


        Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
