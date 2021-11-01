Imports System
Imports System.Web
Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.Hubs
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Newtonsoft

Namespace SignalR.Classes

    <Authorize>
    Public Class ChatHub
        Inherits SignalR.Classes.BaseHub

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum GroupAction

            OpenChatWindow
            UserEnteredRoom
            LoadMessages
            LoadUsersInRoom
            UserLeftRoom

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Rooms "

        Public Sub AddRoom(ByVal RoomName As String, ByVal IsPrivate As Boolean, ByVal Users As String)

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim NewRoom As New AdvantageFramework.Database.Entities.ChatRoom

            '        If String.IsNullOrWhiteSpace(RoomName) = True Then 'quick message room

            '            RoomName = String.Format("Quick message from {0}", User.EmployeeFullName)

            '            'If String.IsNullOrWhiteSpace(Users) = False Then

            '            '    Dim InvitedUsers As IEnumerable(Of MessagedUser) = Nothing
            '            '    Try

            '            '        InvitedUsers = Newtonsoft.Json.JsonConvert.DeserializeObject(Of IEnumerable(Of MessagedUser))(Users)

            '            '        If InvitedUsers IsNot Nothing Then

            '            '            Select Case InvitedUsers.Count
            '            '                Case 1

            '            '                    RoomName = User.UserCode & " & " & InvitedUsers.FirstOrDefault.UserCode

            '            '                Case > 1

            '            '                    RoomName = User.UserCode

            '            '                    For Each InvitedUser As MessagedUser In InvitedUsers

            '            '                        RoomName &= ", " & InvitedUser.UserCode

            '            '                    Next

            '            '                Case Else

            '            '                    RoomName = String.Format("Quick message from {0}", User.EmployeeFullName)

            '            '            End Select

            '            '        End If

            '            '    Catch ex As Exception
            '            '        InvitedUsers = Nothing
            '            '    End Try

            '            'End If

            '        End If

            '        NewRoom.Name = CheckRoomName(DbContext, RoomName)

            '        NewRoom.StartedByUserCode = User.UserCode
            '        NewRoom.IsPrivate = IsPrivate
            '        NewRoom.IsActive = True
            '        NewRoom.IsSaved = False

            '        If AdvantageFramework.Database.Procedures.ChatRoom.Insert(DbContext, NewRoom, Nothing) = True Then

            '            _EnterRoom(NewRoom.RoomID, Users, True)

            '        End If

            '    End Using

            'End If

        End Sub
        Public Function EnterRoom(ByVal RoomID As String, ByVal Users As String) As Boolean

            Return False
            'Return _EnterRoom(RoomID, Users, False)

        End Function
        Public Function _EnterRoom(ByVal RoomID As String, ByVal Users As String, ByVal IsNewRoom As Boolean) As Boolean

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()
            'Dim InvitedUsers As IEnumerable(Of MessagedUser) = Nothing
            'Dim UserIsInRoom As Boolean = False
            'Dim UserEnteredRoom As Boolean = False
            'Dim ErrorMessage As String = String.Empty

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim Room As AdvantageFramework.Database.Entities.ChatRoom
            '        Room = Nothing

            '        Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If Room IsNot Nothing Then

            '            Dim Message As New AdvantageFramework.Database.Entities.ChatMessage

            '            Message.ChatRoomID = Room.ID
            '            Message.Message = User.EmployeeFullName & " entered the room."
            '            Message.UserCode = User.UserCode
            '            Message.IsSystemMessage = True
            '            Message.MessageDate = DateTime.Now


            '            If AdvantageFramework.Database.Procedures.ChatUser.UserIsInRoom(DbContext, Room.ID, User.UserCode) = True Then

            '                UserIsInRoom = True

            '            Else

            '                'If Room.StartedByUserCode = User.UserCode OrElse Room.IsPrivate = False Then

            '                Dim NewUser As New AdvantageFramework.Database.Entities.ChatUser

            '                NewUser.ChatRoomID = Room.ID
            '                NewUser.UserCode = User.UserCode

            '                If AdvantageFramework.Database.Procedures.ChatUser.Insert(DbContext, NewUser, ErrorMessage) = True Then

            '                    AdvantageFramework.Database.Procedures.ChatMessage.Insert(DbContext, Message, Nothing)
            '                    UserEnteredRoom = True
            '                    UserIsInRoom = True

            '                End If

            '                'End If

            '            End If

            '            If UserIsInRoom = True Then

            '                Clients.User(User.ContextUserIdentityName).enteredRoom(Room.RoomID, Room.Name, User.UserCode, User.EmployeeFullName)

            '                Dim UsersInRoom As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)
            '                UsersInRoom = Nothing
            '                UsersInRoom = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadActiveByChatRoomID(DbContext, Room.ID).ToList()

            '                If UsersInRoom IsNot Nothing Then

            '                    For Each UserInRoom As AdvantageFramework.Database.Entities.ChatActiveUser In UsersInRoom

            '                        If UserInRoom.UserCode <> User.UserCode Then

            '                            ''Notify users that were already in the room
            '                            'Clients.User(UserInRoom.ContextUserIdentityName).enteredRoom(Room.RoomID, Room.Name, User.UserCode, User.EmployeeFullName)
            '                            Clients.User(UserInRoom.ContextUserIdentityName).showMessage(Room.RoomID, User.EmployeeFullName, Message.Message, FormatMessageDateForDisplay(Message), User.EmployeePicture, Message.IsSystemMessage.ToString.ToLower)

            '                        End If

            '                    Next

            '                End If


            '                'Invite users that weren't in room before
            '                Try

            '                    InvitedUsers = Newtonsoft.Json.JsonConvert.DeserializeObject(Of IEnumerable(Of MessagedUser))(Users)

            '                Catch ex As Exception
            '                    InvitedUsers = Nothing
            '                End Try

            '                If InvitedUsers IsNot Nothing Then

            '                    For Each InvitedUser As MessagedUser In InvitedUsers

            '                        If InvitedUser.UserCode <> User.UserCode Then

            '                            InviteToRoom(RoomID, InvitedUser.UserCode)

            '                        End If

            '                    Next

            '                End If

            '            End If

            '            Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            '            If IsNewRoom = True Then

            '                If Room.IsPrivate = True Then

            '                    If InvitedUsers IsNot Nothing Then

            '                        For Each InvitedUser As MessagedUser In InvitedUsers

            '                            RoomList = Nothing
            '                            RoomList = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, InvitedUser.UserCode)

            '                            If RoomList IsNot Nothing Then

            '                                Clients.User(InvitedUser.UserCode).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                            End If

            '                        Next

            '                    End If

            '                Else

            '                    Dim AllOnlineUsers As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)
            '                    AllOnlineUsers = Nothing

            '                    AllOnlineUsers = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadDoNotDisturb(DbContext).ToList

            '                    If AllOnlineUsers IsNot Nothing AndAlso AllOnlineUsers.Count > 0 Then

            '                        For Each OnlineUser As AdvantageFramework.Database.Entities.ChatActiveUser In AllOnlineUsers

            '                            RoomList = Nothing
            '                            RoomList = LoadRoomsList(OnlineUser)

            '                            If RoomList IsNot Nothing Then

            '                                Clients.User(OnlineUser.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                            End If

            '                        Next

            '                    End If

            '                End If

            '            Else

            '                RoomList = Nothing
            '                RoomList = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, User.UserCode)

            '                If RoomList Is Nothing Then

            '                    RoomList = New List(Of AdvantageFramework.Database.Entities.ChatRoom)

            '                End If
            '                If RoomList IsNot Nothing Then

            '                    Clients.User(User.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                End If

            '            End If

            '        End If

            '    End Using

            'End If

            'Return UserIsInRoom
            Return False

        End Function
        Public Function LeaveRoom(ByVal RoomID As String) As Boolean

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()
            'Dim ErrorMessage As String = String.Empty

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim Room As AdvantageFramework.Database.Entities.ChatRoom
            '        Room = Nothing

            '        Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If Room IsNot Nothing Then

            '            Dim RoomUser As AdvantageFramework.Database.Entities.ChatUser
            '            Dim MarkRoomInactive As Boolean = False
            '            Dim DeleteUnsavedRoom As Boolean = False

            '            RoomUser = Nothing

            '            RoomUser = AdvantageFramework.Database.Procedures.ChatUser.LoadByChatRoomIDAndUserCode(DbContext, Room.ID, User.UserCode)

            '            If RoomUser IsNot Nothing Then

            '                If AdvantageFramework.Database.Procedures.ChatUser.Delete(DbContext, RoomUser) = True Then

            '                    Dim Message As New AdvantageFramework.Database.Entities.ChatMessage

            '                    Message.ChatRoomID = Room.ID
            '                    Message.Message = User.EmployeeFullName & " left the room."
            '                    Message.IsSystemMessage = True
            '                    Message.UserCode = RoomUser.UserCode
            '                    Message.MessageDate = DateTime.Now

            '                    AdvantageFramework.Database.Procedures.ChatMessage.Insert(DbContext, Message, Nothing)

            '                    Dim UsersInRoom As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)
            '                    UsersInRoom = Nothing
            '                    UsersInRoom = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadActiveByChatRoomID(DbContext, Room.ID).ToList()

            '                    If UsersInRoom IsNot Nothing Then

            '                        If UsersInRoom.Count > 0 Then

            '                            For Each UserInRoom As AdvantageFramework.Database.Entities.ChatActiveUser In UsersInRoom

            '                                Clients.User(UserInRoom.ContextUserIdentityName).leftRoom(Room.RoomID, Message.Message, FormatMessageDateForDisplay(Message))

            '                            Next

            '                        Else

            '                            If Room.IsSaved = False Then

            '                                DeleteUnsavedRoom = True

            '                            Else

            '                                MarkRoomInactive = True

            '                            End If

            '                        End If

            '                    Else

            '                        If Room.IsSaved = False Then

            '                            DeleteUnsavedRoom = True

            '                        Else

            '                            MarkRoomInactive = True

            '                        End If

            '                    End If

            '                    If MarkRoomInactive = True Then

            '                        Room.IsActive = False

            '                        AdvantageFramework.Database.Procedures.ChatRoom.Update(DbContext, Room, Nothing)

            '                    ElseIf DeleteUnsavedRoom = True Then

            '                        AdvantageFramework.Database.Procedures.ChatRoom.Delete(DbContext, Room.ID)

            '                    End If

            '                    Dim NotifyCurrentUser As Boolean = True
            '                    Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            '                    If MarkRoomInactive = True OrElse DeleteUnsavedRoom = True Then

            '                        RoomList = Nothing

            '                        If Room.IsPrivate = True Then

            '                            If UsersInRoom IsNot Nothing AndAlso UsersInRoom.Count > 0 Then

            '                                For Each UserInRoom As AdvantageFramework.Database.Entities.ChatActiveUser In UsersInRoom

            '                                    RoomList = Nothing
            '                                    RoomList = LoadRoomsList(UserInRoom)

            '                                    If UserInRoom.UserCode = User.UserCode Then NotifyCurrentUser = False

            '                                    If RoomList IsNot Nothing Then

            '                                        Clients.User(UserInRoom.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                                    End If

            '                                Next

            '                            End If

            '                        Else

            '                            Dim AllOnlineUsers As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)
            '                            AllOnlineUsers = Nothing

            '                            AllOnlineUsers = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadDoNotDisturb(DbContext).ToList

            '                            If AllOnlineUsers IsNot Nothing AndAlso AllOnlineUsers.Count > 0 Then

            '                                For Each OnlineUser As AdvantageFramework.Database.Entities.ChatActiveUser In AllOnlineUsers

            '                                    RoomList = Nothing
            '                                    RoomList = LoadRoomsList(OnlineUser)

            '                                    If OnlineUser.UserCode = User.UserCode Then NotifyCurrentUser = False

            '                                    If RoomList IsNot Nothing Then

            '                                        Clients.User(OnlineUser.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                                    End If

            '                                Next

            '                            End If

            '                        End If


            '                    End If

            '                    If NotifyCurrentUser = True Then

            '                        RoomList = Nothing
            '                        RoomList = LoadRoomsList(User)

            '                        If RoomList IsNot Nothing Then

            '                            Clients.User(User.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                        End If

            '                    End If

            '                End If

            '            End If

            '        End If

            '    End Using

            'End If
            Return False

        End Function
        Public Function InviteToRoom(ByVal RoomID As String, ByVal UserCode As String) As Boolean

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()
            'Dim s As String = String.Empty

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim Room As AdvantageFramework.Database.Entities.ChatRoom
            '        Room = Nothing

            '        Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If Room IsNot Nothing Then

            '            Dim UserToBeInvited As AdvantageFramework.Database.Entities.ChatActiveUser

            '            UserToBeInvited = Nothing

            '            UserToBeInvited = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadByUserCode(DbContext, UserCode)

            '            If UserToBeInvited IsNot Nothing Then

            '                If AdvantageFramework.Database.Procedures.ChatUser.UserIsInRoom(DbContext, Room.ID, UserToBeInvited.UserCode) = True Then

            '                    'Clients.User(UserToBeInvited.ContextUserIdentityName).enteredRoom(Room.RoomID, Room.Name, UserToBeInvited.UserCode, UserToBeInvited.EmployeeFullName)

            '                Else

            '                    'Dim NewRoowUser As New AdvantageFramework.Database.Entities.ChatUser

            '                    'NewRoowUser.ChatRoomID = Room.ID
            '                    'NewRoowUser.UserCode = UserToBeInvited.UserCode

            '                    'If AdvantageFramework.Database.Procedures.ChatUser.Insert(DbContext, NewRoowUser, s) = True Then

            '                    Clients.User(UserToBeInvited.ContextUserIdentityName).inviteToRoom(Room.RoomID, Room.Name)

            '                    'End If

            '                End If

            '            End If

            '        End If

            '    End Using

            'End If
            Return False

        End Function

        Public Sub ListRooms()

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            '    RoomList = Nothing
            '    RoomList = LoadRoomsList(User)

            '    If RoomList IsNot Nothing Then

            '        Clients.User(User.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '    End If

            'End If

        End Sub
        Private Function LoadRoomsList(ByRef User As AdvantageFramework.Database.Entities.ChatActiveUser) As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        RoomList = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, User.UserCode)

            '    End Using

            'End If

            If RoomList Is Nothing Then

                RoomList = New List(Of AdvantageFramework.Database.Entities.ChatRoom)

            End If

            Return RoomList

        End Function

        Public Sub LoadMessages(ByVal RoomID As String, ByVal HideSystemMessages As Boolean)

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim Room As AdvantageFramework.Database.Entities.ChatRoom
            '        Room = Nothing

            '        Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If Room IsNot Nothing Then

            '            Dim MessagesInRoom As Generic.List(Of AdvantageFramework.Database.Classes.ChatMessage)
            '            MessagesInRoom = Nothing

            '            MessagesInRoom = AdvantageFramework.Database.Procedures.ChatMessage.LoadByChatRoomID(DbContext, Room.ID, HideSystemMessages).ToList

            '            If MessagesInRoom IsNot Nothing Then

            '                'Dim UsersInRoom As Generic.List(Of AdvantageFramework.Database.Entities.ChatUser)

            '                'UsersInRoom = Nothing
            '                'UsersInRoom = AdvantageFramework.Database.Procedures.ChatUser.LoadByChatRoomID(DbContext, Room.ID).ToList()

            '                'If UsersInRoom IsNot Nothing Then

            '                Dim Json As String = ""
            '                Json = Newtonsoft.Json.JsonConvert.SerializeObject(MessagesInRoom)
            '                Clients.User(User.ContextUserIdentityName).loadMessages(Room.RoomID, Json)
            '                '    For Each UserInRoom As AdvantageFramework.EF6CFDatabase.Entities.ChatUser In UsersInRoom

            '                '        Clients.User(UserInRoom.ContextUserIdentityName).loadMessages(Room.RoomID, Json)

            '                '    Next

            '                'End If

            '            End If

            '        End If

            '    End Using

            'End If

        End Sub

        Public Sub LoadUsersInRoom(ByVal RoomID As String)

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim Room As AdvantageFramework.Database.Entities.ChatRoom
            '        Room = Nothing

            '        Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If Room IsNot Nothing Then

            '            If AdvantageFramework.Database.Procedures.ChatUser.UserIsInRoom(DbContext, Room.ID, User.UserCode) = True Then

            '                ListUsersInRoom(Room)

            '            End If

            '        End If

            '    End Using

            'End If

        End Sub
        Private Sub ListUsersInRoom(ByRef Room As AdvantageFramework.Database.Entities.ChatRoom)

            'Dim Json As String = ""

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()
            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim UsersInRoom As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            '        UsersInRoom = Nothing

            '        UsersInRoom = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadActiveByChatRoomID(DbContext, Room.ID).ToList()

            '        If UsersInRoom IsNot Nothing Then

            '            Dim list = (From Entity In UsersInRoom
            '                        Order By Entity.EmployeeFullName
            '                        Select Entity.UserCode, Entity.EmployeeFullName).Distinct

            '            Json = Newtonsoft.Json.JsonConvert.SerializeObject(list)

            '            For Each UserInRoom As AdvantageFramework.Database.Entities.ChatActiveUser In UsersInRoom

            '                Clients.User(UserInRoom.ContextUserIdentityName).loadUsersInRoom(Room.RoomID, Json)

            '            Next

            '        End If

            '    End Using

            'End If

        End Sub

        Public Function IsRoomPrivate(ByVal RoomID As String) As Boolean

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim Room As AdvantageFramework.Database.Entities.ChatRoom
            '        Room = Nothing

            '        Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If Room IsNot Nothing Then

            '            Clients.User(User.ContextUserIdentityName).roomIsPrivate(Room.RoomID, Room.IsPrivate)

            '        End If

            '    End Using

            'End If
            Return False

        End Function
        Public Sub ChangeRoomPrivacy(ByVal RoomID As String, ByVal IsPrivate As Boolean)

            'Dim ErrorMessage As String = String.Empty
            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim Room As AdvantageFramework.Database.Entities.ChatRoom
            '        Room = Nothing

            '        Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If Room IsNot Nothing Then

            '            Dim RoomIsPrivate As Boolean = Room.IsPrivate

            '            Room.IsPrivate = IsPrivate

            '            If AdvantageFramework.Database.Procedures.ChatRoom.Update(DbContext, Room, ErrorMessage) = True Then

            '                Dim AllOnlineUsers As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)
            '                AllOnlineUsers = Nothing

            '                AllOnlineUsers = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadDoNotDisturb(DbContext).ToList

            '                Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            '                RoomList = Nothing

            '                If AllOnlineUsers IsNot Nothing AndAlso AllOnlineUsers.Count > 0 Then

            '                    For Each OnlineUser As AdvantageFramework.Database.Entities.ChatActiveUser In AllOnlineUsers

            '                        RoomList = Nothing
            '                        RoomList = LoadRoomsList(OnlineUser)

            '                        If RoomList IsNot Nothing Then

            '                            Clients.User(OnlineUser.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                            For Each ActiveRoom As AdvantageFramework.Database.Entities.ChatRoom In RoomList

            '                                If ActiveRoom.RoomID = Room.RoomID Then

            '                                    Clients.User(OnlineUser.ContextUserIdentityName).roomIsPrivate(Room.RoomID, Room.IsPrivate)

            '                                End If

            '                            Next

            '                        End If

            '                    Next

            '                End If

            '            End If

            '        End If

            '    End Using

            'End If

        End Sub
        Public Shared Function CheckRoomName(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal RoomName As String) As String

            'Try

            '    Dim NameCount As Integer = 0

            '    NameCount = AdvantageFramework.Database.Procedures.ChatRoom.LoadRoomNameCount(DbContext, RoomName)

            '    If NameCount > 0 Then

            '        RoomName = String.Format("{0} ({1})", RoomName, DateTime.Now.ToString("hh:mm:ss t"))

            '    End If

            'Catch ex As Exception
            'End Try

            'Return RoomName
            Return ""

        End Function

#Region " Shared for use outside class "

        Public Shared Sub RoomNameUpdated(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoom As AdvantageFramework.Database.Entities.ChatRoom)

            'If ChatRoom IsNot Nothing AndAlso ChatRoom.IsActive = True Then

            '    Dim ChatHubContext = GlobalHost.ConnectionManager.GetHubContext(Of ChatHub)()

            '    If ChatHubContext IsNot Nothing Then

            '        Dim AllActiveUsers As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            '        AllActiveUsers = Nothing

            '        If ChatRoom.IsPrivate = False Then

            '            AllActiveUsers = AdvantageFramework.Database.Procedures.ChatActiveUser.Load(DbContext).ToList

            '        Else

            '            AllActiveUsers = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadActiveByChatRoomID(DbContext, ChatRoom.ID).ToList

            '        End If

            '        If AllActiveUsers IsNot Nothing Then

            '            Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            '            For Each ActiveUser As AdvantageFramework.Database.Entities.ChatActiveUser In AllActiveUsers

            '                RoomList = Nothing
            '                RoomList = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, ActiveUser.UserCode)

            '                If RoomList IsNot Nothing Then

            '                    ChatHubContext.Clients.User(ActiveUser.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))
            '                    ChatHubContext.Clients.User(ActiveUser.ContextUserIdentityName).roomRenamed(ChatRoom.RoomID)

            '                End If

            '            Next

            '        End If

            '    End If

            'End If

        End Sub
        Public Shared Function CheckSavedRoomName(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal RoomName As String) As String

            'Try

            '    Dim NameCount As Integer = 0

            '    NameCount = AdvantageFramework.Database.Procedures.ChatRoom.LoadSavedRoomNameCount(DbContext, RoomName)

            '    If NameCount > 0 Then

            '        RoomName = String.Format("{0} ({1})", RoomName, DateTime.Now.ToString("hh:mm:ss t"))

            '    End If

            'Catch ex As Exception
            'End Try

            'Return RoomName
            Return ""

        End Function
        Public Shared Sub ContinueChatRoom(ByVal RoomID As String, ByVal Session As AdvantageFramework.Security.Session)

            'Dim ChatHubContext = GlobalHost.ConnectionManager.GetHubContext(Of ChatHub)()

            'If ChatHubContext IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '        Dim DbChatRoom As AdvantageFramework.Database.Entities.ChatRoom
            '        Dim s As String = String.Empty

            '        DbChatRoom = Nothing

            '        DbChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If DbChatRoom IsNot Nothing Then

            '            DbChatRoom.IsActive = True

            '            If AdvantageFramework.Database.Procedures.ChatRoom.Update(DbContext, DbChatRoom, s) = True Then

            '                Dim CallerIsInChat As Boolean = False
            '                Dim RoomUsers As Generic.List(Of String)

            '                RoomUsers = Nothing

            '                RoomUsers = AdvantageFramework.Database.Procedures.ChatUser.LoadActiveContextUserIdentityNameByChatRoomID(DbContext, DbChatRoom.ID)

            '                If RoomUsers IsNot Nothing Then

            '                    For Each RoomUser As String In RoomUsers

            '                        ChatHubContext.Clients.User(RoomUser).inviteToRoom(DbChatRoom.RoomID, DbChatRoom.Name)

            '                        If CallerIsInChat = False AndAlso RoomUser = Session.UserCode Then

            '                            CallerIsInChat = True

            '                        End If

            '                    Next

            '                End If

            '                If CallerIsInChat = False Then

            '                    ChatHubContext.Clients.User(Session.UserCode).inviteToRoom(DbChatRoom.RoomID, DbChatRoom.Name)

            '                End If

            '            End If


            '        End If

            '    End Using

            'End If

        End Sub
        Public Shared Function DeleteRoomByRoomID(ByVal DbChatRoom As AdvantageFramework.Database.Entities.ChatRoom, ByVal Session As AdvantageFramework.Security.Session, ByRef ErrorMessage As String) As Boolean

            'Dim ChatHubContext = GlobalHost.ConnectionManager.GetHubContext(Of ChatHub)()
            'Dim Deleted As Boolean = False

            'If ChatHubContext IsNot Nothing AndAlso DbChatRoom IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '        Dim RoomIsPrivate As Boolean = DbChatRoom.IsPrivate
            '        Dim RoomUsers As Generic.List(Of AdvantageFramework.Database.Entities.ChatUser)

            '        RoomUsers = Nothing

            '        Try

            '            RoomUsers = AdvantageFramework.Database.Procedures.ChatUser.LoadActiveByChatRoomID(DbContext, DbChatRoom.ID).ToList

            '        Catch ex As Exception
            '            RoomUsers = Nothing
            '        End Try

            '        Deleted = AdvantageFramework.Database.Procedures.ChatRoom.Delete(DbContext, DbChatRoom.ID)

            '        If Deleted = True Then

            '            Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)
            '            Dim ContextUserIdentityName As String = String.Empty

            '            If RoomUsers IsNot Nothing Then

            '                For Each RoomUser As AdvantageFramework.Database.Entities.ChatUser In RoomUsers

            '                    RoomList = Nothing

            '                    Try


            '                        RoomList = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, RoomUser.UserCode)

            '                        If RoomList IsNot Nothing Then

            '                            ContextUserIdentityName = String.Empty
            '                            ContextUserIdentityName = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT TOP 1 CONTEXT_USER_IDENTITY_NAME FROM CHAT_ACTIVE_USER WHERE USER_CODE = '{0}';", RoomUser.UserCode)).FirstOrDefault

            '                            If String.IsNullOrWhiteSpace(ContextUserIdentityName) = True Then

            '                                ChatHubContext.Clients.User(RoomUser.UserCode).roomDeleted(DbChatRoom.RoomID)

            '                                If RoomIsPrivate = True Then

            '                                    ChatHubContext.Clients.User(RoomUser.UserCode).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                                End If

            '                            Else

            '                                ChatHubContext.Clients.User(ContextUserIdentityName).roomDeleted(DbChatRoom.RoomID)

            '                                If RoomIsPrivate = True Then

            '                                    ChatHubContext.Clients.User(ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                                End If

            '                            End If

            '                        End If

            '                    Catch ex As Exception
            '                    End Try

            '                Next

            '            End If

            '            If RoomIsPrivate = False Then

            '                Try

            '                    Dim AllOnlineUsers As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)
            '                    AllOnlineUsers = Nothing

            '                    AllOnlineUsers = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadDoNotDisturb(DbContext).ToList

            '                    If AllOnlineUsers IsNot Nothing AndAlso AllOnlineUsers.Count > 0 Then

            '                        For Each OnlineUser As AdvantageFramework.Database.Entities.ChatActiveUser In AllOnlineUsers

            '                            RoomList = Nothing
            '                            RoomList = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, OnlineUser.UserCode)

            '                            If RoomList IsNot Nothing Then

            '                                ChatHubContext.Clients.User(OnlineUser.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                            End If

            '                        Next

            '                    End If

            '                Catch ex As Exception
            '                End Try

            '            End If

            '        End If

            '    End Using

            'End If

            'Return Deleted
            Return False

        End Function
        Public Shared Function FormatMessageDateForDisplay(ByVal Message As AdvantageFramework.Database.Entities.ChatMessage) As String

            'Dim Display As String = ""

            'Try

            '    If Message IsNot Nothing Then

            '        'If Message.MessageDate.ToShortDateString = Today.ToShortDateString Then

            '        Display = Message.MessageDate.ToString("f")

            '        'Else

            '        '    Display = Message.MessageDate.ToString("g")

            '        'End If

            '    End If

            'Catch ex As Exception

            '    Display = ""

            'End Try

            'Return Display
            Return ""

        End Function
        Public Shared Function SignOut(ByVal Session As AdvantageFramework.Security.Session, ByVal UserCodeToSignOut As String, ByVal UpdateWhoIsOnline As Boolean) As Boolean

            'Try

            '    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '        Dim ChatHubContext = GlobalHost.ConnectionManager.GetHubContext(Of ChatHub)()

            '        If ChatHubContext IsNot Nothing Then

            '            Dim ActiveUser As AdvantageFramework.Database.Entities.ChatActiveUser
            '            ActiveUser = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadByUserCode(DbContext, UserCodeToSignOut)

            '            If ActiveUser IsNot Nothing Then

            '                Dim FullName As String = ActiveUser.EmployeeFullName
            '                Dim EmployeePicture As Byte() = ActiveUser.EmployeePicture
            '                Dim UpdateRoomListForAllUsers As Boolean = False

            '                AdvantageFramework.Database.Procedures.ChatActiveUser.Delete(DbContext, ActiveUser)

            '                Dim ActiveRooms As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)
            '                ActiveRooms = Nothing

            '                ActiveRooms = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, UserCodeToSignOut)

            '                If ActiveRooms IsNot Nothing Then

            '                    Dim UsersInRoom As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)
            '                    Dim ChatMessage As New AdvantageFramework.Database.Entities.ChatMessage(ActiveUser)
            '                    Dim Json As String = ""
            '                    Dim MarkRoomInactive As Boolean = False
            '                    Dim DeleteUnsavedRoom As Boolean = False

            '                    ChatMessage.Message = ActiveUser.EmployeeFullName & " signed out."
            '                    ChatMessage.IsSystemMessage = True
            '                    ChatMessage.UserCode = ActiveUser.UserCode
            '                    ChatMessage.MessageDate = DateTime.Now

            '                    For Each ActiveRoom As AdvantageFramework.Database.Entities.ChatRoom In ActiveRooms

            '                        If AdvantageFramework.Database.Procedures.ChatUser.UserIsInRoom(DbContext, ActiveRoom.ID, Session.UserCode) = True Then

            '                            'Add message to room
            '                            ChatMessage.ChatRoomID = ActiveRoom.ID
            '                            AdvantageFramework.Database.Procedures.ChatMessage.Insert(DbContext, ChatMessage, Nothing)

            '                            'TODO: Update messages and list for all other users
            '                            UsersInRoom = Nothing
            '                            UsersInRoom = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadActiveByChatRoomID(DbContext, ActiveRoom.ID).ToList()

            '                            Json = String.Empty

            '                            If UsersInRoom IsNot Nothing Then

            '                                Dim list = From Entity In UsersInRoom
            '                                           Select Entity.UserCode, Entity.EmployeeFullName

            '                                Json = Newtonsoft.Json.JsonConvert.SerializeObject(list)

            '                                If UsersInRoom.Count > 0 Then

            '                                    For Each UserInRoom As AdvantageFramework.Database.Entities.ChatActiveUser In UsersInRoom

            '                                        ChatHubContext.Clients.User(UserInRoom.ContextUserIdentityName).loadUsersInRoom(ActiveRoom.RoomID, Json)
            '                                        ChatHubContext.Clients.User(UserInRoom.ContextUserIdentityName).showMessage(ActiveRoom.RoomID, FullName, ChatMessage.Message, FormatMessageDateForDisplay(ChatMessage), EmployeePicture, ChatMessage.IsSystemMessage.ToString.ToLower)

            '                                    Next

            '                                Else

            '                                    If ActiveRoom.IsSaved = False Then

            '                                        DeleteUnsavedRoom = True

            '                                    Else

            '                                        MarkRoomInactive = True

            '                                    End If

            '                                End If

            '                            Else

            '                                If ActiveRoom.IsSaved = False Then

            '                                    DeleteUnsavedRoom = True

            '                                Else

            '                                    MarkRoomInactive = True

            '                                End If

            '                            End If

            '                            If MarkRoomInactive = True Then

            '                                ActiveRoom.IsActive = False

            '                                AdvantageFramework.Database.Procedures.ChatRoom.Update(DbContext, ActiveRoom, Nothing)

            '                            ElseIf DeleteUnsavedRoom = True Then

            '                                AdvantageFramework.Database.Procedures.ChatRoom.Delete(DbContext, ActiveRoom.ID)

            '                            End If

            '                            If ActiveRoom.IsPrivate = False AndAlso UpdateRoomListForAllUsers = False Then

            '                                UpdateRoomListForAllUsers = True

            '                            End If
            '                            If UsersInRoom IsNot Nothing AndAlso UsersInRoom.Count > 0 Then

            '                                Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)
            '                                If UsersInRoom IsNot Nothing Then

            '                                    For Each RoomUser As AdvantageFramework.Database.Entities.ChatActiveUser In UsersInRoom

            '                                        RoomList = Nothing

            '                                        Try

            '                                            RoomList = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, RoomUser.UserCode)

            '                                            If RoomList IsNot Nothing Then

            '                                                If DeleteUnsavedRoom = True Then ChatHubContext.Clients.User(RoomUser.ContextUserIdentityName).roomDeleted(ActiveRoom.RoomID)

            '                                                If ActiveRoom.IsPrivate = True Then

            '                                                    ChatHubContext.Clients.User(RoomUser.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                                                End If

            '                                            End If

            '                                        Catch ex As Exception
            '                                        End Try

            '                                    Next

            '                                End If

            '                            End If

            '                        End If

            '                    Next

            '                End If

            '                If UpdateWhoIsOnline = True OrElse UpdateRoomListForAllUsers = True Then

            '                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

            '                        Dim Online As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)
            '                        Dim RoomList As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            '                        Online = Nothing
            '                        Online = AdvantageFramework.Database.Procedures.ChatActiveUser.Load(DbContext, ActiveUser.UserCode, ActiveUser.EmployeeCode, SecurityDbContext).ToList()

            '                        For Each UserOnline As AdvantageFramework.Database.Entities.ChatActiveUser In Online

            '                            RoomList = Nothing

            '                            If UpdateWhoIsOnline = True Then

            '                                ChatHubContext.Clients.User(UserOnline.ContextUserIdentityName).refreshWhoIsOnline()

            '                            End If
            '                            If UpdateRoomListForAllUsers = True Then

            '                                RoomList = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, UserOnline.UserCode)

            '                                If RoomList IsNot Nothing Then

            '                                    ChatHubContext.Clients.User(UserOnline.ContextUserIdentityName).listRooms(Newtonsoft.Json.JsonConvert.SerializeObject(RoomList))

            '                                End If

            '                            End If

            '                        Next

            '                    End Using

            '                End If

            '            End If

            '        End If

            '    End Using

            '    Return True

            'Catch ex As Exception

            '    Return False

            'End Try
            Return False

        End Function
        Public Shared Function SignOutByUserID(ByVal Session As AdvantageFramework.Security.Session, ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal UserID As Integer) As Boolean

            'Try

            '    If Session IsNot Nothing AndAlso SecurityDbContext IsNot Nothing Then

            '        Dim SecurityUser As AdvantageFramework.Security.Classes.User
            '        SecurityUser = Nothing

            '        SecurityUser = New AdvantageFramework.Security.Classes.User(AdvantageFramework.Security.Database.Procedures.User.LoadByUserID(SecurityDbContext, UserID))

            '        If SecurityUser IsNot Nothing Then

            '            SignalR.Classes.ChatHub.SignOut(Session, SecurityUser.UserCode, False)

            '        End If

            '    End If

            '    Return True

            'Catch ex As Exception

            '    Return False

            'End Try
            Return False

        End Function

#End Region

#End Region

        Public Sub DoNotDisturb(ByVal DoNotDisturbMe As Boolean)

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()
            'Dim ErrorMessage As String = String.Empty

            'If User IsNot Nothing Then

            '    User.DoNotDisturb = DoNotDisturbMe

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        AdvantageFramework.Database.Procedures.ChatActiveUser.Update(DbContext, User, ErrorMessage)

            '        Dim UserActiveRooms As Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            '        UserActiveRooms = Nothing

            '        UserActiveRooms = AdvantageFramework.Database.Procedures.ChatRoom.LoadActiveRooms(DbContext, User.UserCode)

            '        If UserActiveRooms IsNot Nothing Then

            '            Dim ActiveRoomUsers As Generic.List(Of AdvantageFramework.Database.Entities.ChatUser)
            '            Dim Message As New AdvantageFramework.Database.Entities.ChatMessage

            '            Message.IsSystemMessage = True
            '            Message.MessageDate = DateTime.Now
            '            Message.UserCode = User.UserCode

            '            If DoNotDisturbMe = True Then

            '                Message.Message = User.EmployeeFullName & " is offline."

            '            Else

            '                Message.Message = User.EmployeeFullName & " is online."

            '            End If

            '            For Each Room As AdvantageFramework.Database.Entities.ChatRoom In UserActiveRooms

            '                'Add message to room
            '                Message.ChatRoomID = Room.ID
            '                AdvantageFramework.Database.Procedures.ChatMessage.Insert(DbContext, Message, ErrorMessage)

            '                'Update active room users
            '                ActiveRoomUsers = Nothing
            '                ActiveRoomUsers = AdvantageFramework.Database.Procedures.ChatUser.LoadActiveByChatRoomID(DbContext, Room.ID).ToList()

            '                If ActiveRoomUsers IsNot Nothing Then

            '                    For Each RoomUser As AdvantageFramework.Database.Entities.ChatUser In ActiveRoomUsers

            '                        Clients.User(RoomUser.UserCode).showMessage(Room.RoomID, User.EmployeeFullName, Message.Message, FormatMessageDateForDisplay(Message), User.EmployeePicture, Message.IsSystemMessage.ToString.ToLower)

            '                    Next

            '                End If

            '                'Re-open closed windows?
            '                If DoNotDisturbMe = False Then

            '                    Clients.User(User.ContextUserIdentityName).openRoom(Room.RoomID, Room.Name)

            '                End If

            '            Next

            '        End If

            '    End Using

            'End If

        End Sub
        Public Sub SendMessageToRoom(ByVal RoomID As String, ByVal Message As String)

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()
            'Dim ErrorMessage As String = String.Empty

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim Room As AdvantageFramework.Database.Entities.ChatRoom
            '        Room = Nothing

            '        Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

            '        If Room IsNot Nothing Then

            '            Dim DbMessage As New AdvantageFramework.Database.Entities.ChatMessage

            '            DbMessage.ChatRoomID = Room.ID
            '            DbMessage.Message = Message
            '            DbMessage.UserCode = User.UserCode
            '            DbMessage.MessageDate = DateTime.Now
            '            DbMessage.IsSystemMessage = False

            '            If AdvantageFramework.Database.Procedures.ChatMessage.Insert(DbContext, DbMessage, ErrorMessage) = True Then

            '                Dim UsersInRoom As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            '                UsersInRoom = Nothing

            '                UsersInRoom = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadActiveByChatRoomID(DbContext, Room.ID).ToList()

            '                If UsersInRoom IsNot Nothing Then

            '                    Dim ContextUserIdentityNames As String()

            '                    ContextUserIdentityNames = (From Entity In UsersInRoom
            '                                                Select Entity.ContextUserIdentityName).Distinct.ToArray

            '                    For Each ContextUserIdentityName As String In ContextUserIdentityNames

            '                        If User.ContextUserIdentityName <> ContextUserIdentityName Then

            '                            Clients.User(ContextUserIdentityName).restoreRoom(Room.RoomID, Room.Name)

            '                        End If

            '                        Clients.User(ContextUserIdentityName).showMessage(Room.RoomID, User.EmployeeFullName, DbMessage.Message, FormatMessageDateForDisplay(DbMessage), User.EmployeePicture, DbMessage.IsSystemMessage.ToString.ToLower)

            '                    Next

            '                End If

            '            End If

            '        End If

            '    End Using

            'End If

        End Sub

        Public Sub ComeOnline()

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(User.ConnectionString, User.UserCode)

            '            Dim Online As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            '            Online = Nothing
            '            Online = AdvantageFramework.Database.Procedures.ChatActiveUser.Load(DbContext, User.UserCode, User.EmployeeCode, SecurityDbContext).ToList

            '            If Online IsNot Nothing Then

            '                Dim NotifiedCallingUser As Boolean = False
            '                Dim list = (From ActiveUser In Online
            '                            Order By ActiveUser.EmployeeFullName
            '                            Select ActiveUser.UserCode, ActiveUser.EmployeeFullName).Distinct
            '                Dim JsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(list)

            '                For Each ActiveUser As AdvantageFramework.Database.Entities.ChatActiveUser In Online

            '                    If ActiveUser.UserCode <> User.UserCode Then

            '                        Clients.User(ActiveUser.ContextUserIdentityName).refreshWhoIsOnline()

            '                    End If

            '                Next

            '            End If

            '        End Using

            '    End Using


            'End If

        End Sub
        Public Sub RefreshWhoIsOnline(ByVal DepartmentTeamCode As String)

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(User.ConnectionString, User.UserCode)

            '            Dim Online As Generic.List(Of AdvantageFramework.Database.Entities.ChatActiveUser)

            '            If String.IsNullOrWhiteSpace(DepartmentTeamCode) = True Then

            '                Online = AdvantageFramework.Database.Procedures.ChatActiveUser.Load(DbContext, User.UserCode, User.EmployeeCode, SecurityDbContext).ToList

            '            Else

            '                Online = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadByDepartmentTeamCode(DbContext, User.UserCode, User.EmployeeCode, DepartmentTeamCode, SecurityDbContext).ToList

            '            End If

            '            If Online IsNot Nothing Then

            '                Dim JsonString As String = Newtonsoft.Json.JsonConvert.SerializeObject(Online)
            '                Clients.User(User.ContextUserIdentityName).showWhoIsOnline(JsonString)

            '            End If

            '        End Using

            '    End Using

            'End If

        End Sub

        Public Sub LoadDepartmentTeam()

            'Dim User As AdvantageFramework.Database.Entities.ChatActiveUser = LoadCurrentUser()

            'If User IsNot Nothing Then

            '    Using DbContext = New AdvantageFramework.Database.DbContext(User.ConnectionString, User.UserCode)

            '        Dim DepartmentTeams As Generic.List(Of AdvantageFramework.Database.Entities.DepartmentTeam)

            '        DepartmentTeams = Nothing
            '        DepartmentTeams = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext).ToList

            '        If DepartmentTeams IsNot Nothing Then

            '            Dim list = (From DepartmentTeam In DepartmentTeams
            '                        Order By DepartmentTeam.Description
            '                        Select DepartmentTeam.Code, DepartmentTeam.Description).Distinct

            '            Clients.User(User.ContextUserIdentityName).loadDepartmentTeam(Newtonsoft.Json.JsonConvert.SerializeObject(list))

            '        End If

            '    End Using

            'End If

        End Sub

#End Region

    End Class

End Namespace
