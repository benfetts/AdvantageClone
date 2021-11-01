Namespace Database.Entities

    <Table("CHAT_ROOM")>
    Public Class ChatRoom
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            RoomID
            Name
            Description
            StartedByUserCode
            CreateDate
            IsPrivate
            AlertID
            OfficeCode
            ClientCode
            DivisionCode
            ProductCode
            JobNumber
            JobComponentNumber
            TaskSequenceNumber

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
        <Column("ROOM_ID", TypeName:="varchar")>
        Public Property RoomID As String
        <Required>
        <Column("ROOM_NAME", TypeName:="varchar")>
        Public Property Name As String
        <Column("ROOM_DESC", TypeName:="varchar(MAX)")>
        Public Property Description As String
        <Column("IS_PRIVATE")>
        Public Property IsPrivate As Boolean
        <Required>
        <Column("STARTED_BY_USER_CODE", TypeName:="varchar")>
        Public Property StartedByUserCode As String
        <Required>
        <Column("CREATE_DATE")>
        Public Property CreateDate As DateTime
        <Column("ALERT_ID")>
        Public Property AlertID As Integer
        <Column("OFFICE_CODE", TypeName:="varchar")>
        Public Property OfficeCode As String
        <Column("CL_CODE", TypeName:="varchar")>
        Public Property ClientCode As String
        <Column("DIV_CODE", TypeName:="varchar")>
        Public Property DivisionCode As String
        <Column("PRD_CODE", TypeName:="varchar")>
        Public Property ProductCode As String
        <Column("JOB_NUMBER")>
        Public Property JobNumber As Nullable(Of Integer)
        <Column("JOB_COMPONENT_NBR")>
        Public Property JobComponentNumber As Nullable(Of Short)
        <Column("TASK_SEQ_NBR")>
        Public Property TaskSequenceNumber As Nullable(Of Short)
        <Column("IS_SAVED")>
        Public Property IsSaved As Nullable(Of Boolean) = False
        <Column("IS_ACTIVE")>
        Public Property IsActive As Nullable(Of Boolean) = False

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
