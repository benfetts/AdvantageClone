Namespace Database.Classes

    <Serializable()>
    Public Class ChatMessage

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
            TimeStampToLongDateString
            EmployeePicture
            FullName
        End Enum

#End Region

#Region " Variables "

        Private _TimeStampToLongDateString As String

#End Region

#Region " Properties "

        Public Property ID As Integer
        Public Property ChatRoomID As Integer
        Public Property UserCode As String = Nothing
        Public Property Message As String = Nothing
        Public Property MessageDate As DateTime
        Public Property IsSystemMessage As Boolean = False
        Public Property TimeStampToLongDateString As String
            Get
                Return MessageDate.ToString("f")
            End Get
            Set(value As String)
                _TimeStampToLongDateString = value
            End Set
        End Property
        Public Property EmployeePicture As Byte() = Nothing
        Public Property FullName As String = Nothing

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace