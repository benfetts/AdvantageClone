Namespace Database.Entities

    <Table("CHAT_MESSAGE")>
    Public Class ChatMessage
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            ChatRoomID
            UserCode
            Message
            MessageDate
            IsSystemMessage

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
        <Column("CHAT_ROOM_ID")>
        Public Property ChatRoomID As Integer
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        Public Property UserCode As String
        <Required>
        <Column("MESSAGE", TypeName:="varchar(MAX)")>
        Public Property Message As String
        <Required>
        <Column("MESSAGE_DATE")>
        Public Property MessageDate As DateTime
        <Required>
        <Column("IS_SYSTEM_MESSAGE")>
        Public Property IsSystemMessage As Boolean
        <NotMapped>
        Public ReadOnly Property TimeStampToLongDateString As String
            Get
                Return MessageDate.ToString("f")
            End Get
        End Property

#End Region

#Region " Methods "

        Sub New(ByVal User As AdvantageFramework.Database.Entities.ChatActiveUser)

            UserCode = User.UserCode
            MessageDate = DateTime.Now
            '_ConnectionString = User.ConnectionString
            '_FullName = User.EmployeeFullName
            '_EmployeePicture = User.EmployeePicture

        End Sub
        Sub New()

            MessageDate = DateTime.Now

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
