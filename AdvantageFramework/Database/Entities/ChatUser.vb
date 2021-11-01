Namespace Database.Entities

    <Table("CHAT_USER")>
    Public Class ChatUser
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            ChatRoomID
            UserCode

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
        <Column("USER_CODE", TypeName:="varchar")>
        Public Property UserCode As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
