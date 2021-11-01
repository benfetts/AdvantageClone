'Imports System.Collections.Generic
'Imports System.Linq
'Imports System.Security.Cryptography
'Imports System.Text
'Imports Microsoft.AspNet.SignalR
'Imports Newtonsoft.Json

'Namespace SignalR.Classes

'    Public Class ChatRoom

'#Region " Constants "



'#End Region

'#Region " Enum "



'#End Region

'#Region " Variables "



'#End Region

'#Region " Properties "

'        <Newtonsoft.Json.JsonProperty("ID")>
'        Public Property ID As Integer = 0
'        <Newtonsoft.Json.JsonProperty("RoomID")>
'        Public Property RoomID As String = String.Empty
'        <Newtonsoft.Json.JsonProperty("Name")>
'        Public Property Name As String = String.Empty
'        <Newtonsoft.Json.JsonProperty("Description")>
'        Public Property Description As String = String.Empty
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property IsPrivate As Boolean = False
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property StartedByUserCode As String = String.Empty
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property CreateDate As DateTime

'        <Newtonsoft.Json.JsonIgnore>
'        Public Property JobNumber As Integer = 0
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property JobComponentNumber As Short = 0
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property AlertID As Integer = 0
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property OfficeCode As String = String.Empty
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property ClientCode As String = String.Empty
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property DivisionCode As String = String.Empty
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property ProductCode As String = String.Empty
'        <Newtonsoft.Json.JsonIgnore>
'        Public Property TaskSequenceNumber As Short = 0

'        Public Property Users As Dictionary(Of String, AdvantageFramework.Database.Entities.ChatActiveUser)
'        Public Property Messages As List(Of SignalR.Classes.ChatMessage)

'        Private Property _User As AdvantageFramework.Database.Entities.ChatActiveUser

'#End Region

'#Region " Methods "

'        Public Function AddMessage(ByVal User As AdvantageFramework.Database.Entities.ChatActiveUser, ByVal Message As SignalR.Classes.ChatMessage) As Boolean
'            Try

'                Messages.Add(Message)
'                Return True

'            Catch ex As Exception
'                Return False
'            End Try
'        End Function
'        Public Function Enter(ByVal User As AdvantageFramework.Database.Entities.ChatActiveUser) As Boolean

'            Dim Entered As Boolean = False

'            If Users.ContainsKey(User.GUID) = False Then

'                Try

'                    Users.Add(User.GUID, User)
'                    Dim cm As New ChatMessage(User)
'                    cm.Message = User.EmployeeFullName & " entered the room."
'                    cm.IsSystemMessage = True
'                    Messages.Add(cm)
'                    Entered = True

'                Catch ex As Exception
'                    Entered = False
'                End Try

'            Else

'                Entered = True

'            End If

'            Return Entered

'        End Function
'        Public Function Leave(ByVal User As AdvantageFramework.Database.Entities.ChatActiveUser, ByRef Message As ChatMessage) As String

'            Dim Left As Boolean = False

'            If Users.ContainsKey(User.GUID) = True Then


'                Try

'                    If Users.Remove(User.GUID) = True Then

'                        Dim cm As New ChatMessage(User)
'                        cm.Message = User.EmployeeFullName & " left the room."
'                        cm.IsSystemMessage = True

'                        Messages.Add(cm)
'                        Message = cm
'                        Left = True

'                    End If

'                Catch ex As Exception
'                    Left = False
'                End Try

'                Try

'                    If Left = True Then

'                        If Users.Count = 0 Then

'                            SignalR.Classes.ChatHub.DeleteRoomByRoomID(Me.RoomID, Nothing)

'                        End If

'                    End If

'                Catch ex As Exception

'                End Try

'            End If

'            Return Left

'        End Function
'        Public Function Save(ByVal sConnectionString As String, ByVal sUserCode As String, ByRef IsUpdate As Boolean, ByRef RoomID As Integer, ByRef FailedUserSave As Integer, ByRef FailedMessageSave As Integer) As Boolean

'            Dim Saved As Boolean = False

'            IsUpdate = True
'            RoomID = 0
'            FailedUserSave = 0
'            FailedMessageSave = 0

'            Using DbContext = New AdvantageFramework.Database.DbContext(sConnectionString, sUserCode)

'                Dim ChatRoom As AdvantageFramework.Database.Entities.ChatRoom
'                Dim ErrorMessage As String = ""

'                ChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, Me.RoomID)

'                If ChatRoom Is Nothing Then

'                    ChatRoom = New AdvantageFramework.Database.Entities.ChatRoom
'                    IsUpdate = False

'                Else

'                    RoomID = ChatRoom.ID

'                End If

'                ChatRoom.Name = Me.Name
'                If String.IsNullOrWhiteSpace(Me.Description) = False Then
'                    ChatRoom.Description = Me.Description
'                Else
'                    ChatRoom.Description = Nothing
'                End If
'                ChatRoom.IsPrivate = Me.IsPrivate

'                If String.IsNullOrWhiteSpace(Me.ClientCode) = False Then
'                    ChatRoom.ClientCode = Me.ClientCode
'                Else
'                    ChatRoom.ClientCode = Nothing
'                End If
'                If String.IsNullOrWhiteSpace(Me.DivisionCode) = False Then
'                    ChatRoom.DivisionCode = Me.DivisionCode
'                Else
'                    ChatRoom.DivisionCode = Nothing
'                End If
'                If String.IsNullOrWhiteSpace(Me.ProductCode) = False Then
'                    ChatRoom.ProductCode = Me.ProductCode
'                Else
'                    ChatRoom.ProductCode = Nothing
'                End If
'                If Me.JobNumber > 0 Then
'                    ChatRoom.JobNumber = Me.JobNumber
'                Else
'                    ChatRoom.JobNumber = Nothing
'                End If
'                If Me.JobComponentNumber > 0 Then
'                    ChatRoom.JobComponentNumber = Me.JobComponentNumber
'                Else
'                    ChatRoom.JobComponentNumber = Nothing
'                End If
'                If Me.TaskSequenceNumber > 0 Then
'                    ChatRoom.TaskSequenceNumber = Me.TaskSequenceNumber
'                Else
'                    ChatRoom.TaskSequenceNumber = Nothing
'                End If
'                If Me.AlertID > 0 Then
'                    ChatRoom.AlertID = Me.AlertID
'                Else
'                    ChatRoom.AlertID = Nothing
'                End If

'                If IsUpdate = False Then

'                    ChatRoom.RoomID = Me.RoomID
'                    ChatRoom.StartedByUserCode = Me.StartedByUserCode
'                    ChatRoom.CreateDate = Me.CreateDate

'                    Saved = AdvantageFramework.Database.Procedures.ChatRoom.Insert(DbContext, ChatRoom, ErrorMessage)
'                    RoomID = ChatRoom.ID

'                Else

'                    Saved = AdvantageFramework.Database.Procedures.ChatRoom.Update(DbContext, ChatRoom, ErrorMessage)

'                End If

'                If Saved = True Then

'                    Dim ChatUser As AdvantageFramework.Database.Entities.ChatUser
'                    Dim SavedUsers As Generic.List(Of AdvantageFramework.Database.Entities.ChatUser)

'                    SavedUsers = Nothing

'                    If IsUpdate = True Then

'                        SavedUsers = AdvantageFramework.Database.Procedures.ChatUser.LoadByChatRoomID(DbContext, ChatRoom.ID).ToList()

'                        Dim NewUsers = (From User In Users
'                                        Where Not (From SavedUser In SavedUsers
'                                                   Select SavedUser.UserCode).Contains(User.Value.UserCode))

'                        For Each User In NewUsers

'                            ChatUser = New AdvantageFramework.Database.Entities.ChatUser

'                            ChatUser.ChatRoomID = ChatRoom.ID
'                            ChatUser.UserCode = User.Value.UserCode

'                            If AdvantageFramework.Database.Procedures.ChatUser.Insert(DbContext, ChatUser, ErrorMessage) = False Then

'                                FailedUserSave += 1

'                            End If

'                        Next

'                    Else

'                        For Each User In Me.Users

'                            ChatUser = New AdvantageFramework.Database.Entities.ChatUser
'                            ChatUser.ChatRoomID = ChatRoom.ID
'                            ChatUser.UserCode = User.Value.UserCode

'                            If AdvantageFramework.Database.Procedures.ChatUser.Insert(DbContext, ChatUser, ErrorMessage) = False Then

'                                FailedUserSave += 1

'                            End If

'                        Next

'                    End If

'                    Dim ChatMessage As AdvantageFramework.Database.Entities.ChatMessage
'                    For Each Message In Me.Messages

'                        If Message.IsSaved = False Then

'                            ChatMessage = New AdvantageFramework.Database.Entities.ChatMessage

'                            ChatMessage.ChatRoomID = ChatRoom.ID
'                            ChatMessage.UserCode = Message.UserCode
'                            ChatMessage.Message = Message.Message
'                            ChatMessage.MessageDate = Message.TimeStamp
'                            ChatMessage.IsSystemMessage = Message.IsSystemMessage

'                            If AdvantageFramework.Database.Procedures.ChatMessage.Insert(DbContext, ChatMessage, ErrorMessage) = True Then

'                                Message.IsSaved = True

'                            Else

'                                FailedMessageSave += 1

'                            End If


'                        End If

'                    Next

'                End If

'            End Using

'            Return Saved

'        End Function
'        Public Function UserIsInRoom(ByVal User As AdvantageFramework.Database.Entities.ChatActiveUser) As Boolean

'            Try

'                Return Users.ContainsKey(User.GUID)

'            Catch ex As Exception
'                Return False
'            End Try

'        End Function

'        Sub New(ByVal User As AdvantageFramework.Database.Entities.ChatActiveUser)

'            _User = User
'            RoomID = Guid.NewGuid().ToString().GetHashCode().ToString("x")

'            CreateDate = DateTime.Now

'            Users = New Dictionary(Of String, AdvantageFramework.Database.Entities.ChatActiveUser)
'            Messages = New List(Of SignalR.Classes.ChatMessage)

'            If String.IsNullOrWhiteSpace(Name) = True Then

'                Name = User.EmployeeFullName & "'s Room"

'            End If

'        End Sub
'        Sub New()

'            Users = New Dictionary(Of String, AdvantageFramework.Database.Entities.ChatActiveUser)
'            Messages = New List(Of SignalR.Classes.ChatMessage)

'        End Sub

'#End Region

'    End Class

'End Namespace