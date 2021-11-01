Imports System
Imports System.Web
Imports Microsoft.AspNet.SignalR
Imports Microsoft.AspNet.SignalR.Hubs
Imports System.Collections.Generic
Imports System.Linq
Imports System.Threading.Tasks
Imports Newtonsoft
Imports Microsoft.Win32

Namespace SignalR.Classes

    <Authorize>
    Public Class BaseHub
        Inherits Microsoft.AspNet.SignalR.Hub

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Public Shared ServerGroups As New SignalR.Classes.ServerGroupings
        'Public Shared AllConnectedUsers As New Dictionary(Of String, SignalR.Classes.ConnectedUser)
        Public Shared ChatAdminConnString As String = String.Empty

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " System "

        Public Sub DisconnectCurrentUser()

            Try
                If Context IsNot Nothing Then

                    Dim UserCode As String = Context.User.Identity.Name
                    Dim ConnectionString As String = String.Empty
                    Dim ActiveUser As AdvantageFramework.Database.Entities.ChatActiveUser

                    ConnectionString = GetUserConnectionStringFromHubContext(Context)

                    If String.IsNullOrWhiteSpace(ConnectionString) = False AndAlso Context.QueryString("u") IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                            ActiveUser = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadByUserCode(DbContext, UserCode)

                            If ActiveUser IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ChatActiveUser.Delete(DbContext, ActiveUser)

                            End If

                        End Using

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Function LoadCurrentUser() As AdvantageFramework.Database.Entities.ChatActiveUser

            Try

                Dim ErrorMessage As String = String.Empty
                Dim ActiveUser As AdvantageFramework.Database.Entities.ChatActiveUser = Nothing
                Dim ChatActive As Boolean = False

                If Context IsNot Nothing Then


                    Try

                        If Context.QueryString("ca") IsNot Nothing AndAlso (Context.QueryString("ca") = "1" OrElse Context.QueryString("ca").ToLower = "true") Then

                            ChatActive = True

                        End If

                    Catch ex As Exception
                        ChatActive = False
                    End Try

                    If ChatActive = True Then

                        Dim ConnectionString As String = String.Empty
                        Dim UserCode As String = String.Empty
                        ConnectionString = GetUserConnectionStringFromHubContext(Context)

                        If String.IsNullOrWhiteSpace(ConnectionString) = False AndAlso Context.QueryString("u") IsNot Nothing Then

                            UserCode = Context.QueryString("u")

                            Using DbContext = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                                ActiveUser = AdvantageFramework.Database.Procedures.ChatActiveUser.LoadByUserCode(DbContext, UserCode)

                                If ActiveUser Is Nothing Then

                                    ActiveUser = New AdvantageFramework.Database.Entities.ChatActiveUser
                                    ActiveUser.ContextUserIdentityName = Context.User.Identity.Name
                                    ActiveUser.ConnectionId = Context.ConnectionId
                                    ActiveUser.UserCode = UserCode
                                    ActiveUser.ConnectionString = ConnectionString

                                    If Context.QueryString("e") IsNot Nothing Then ActiveUser.EmployeeCode = Context.QueryString("e")
                                    If Context.QueryString("n") IsNot Nothing Then ActiveUser.EmployeeFullName = Context.QueryString("n")
                                    If Context.QueryString("guid") IsNot Nothing Then ActiveUser.GUID = Context.QueryString("guid")

                                    Using oc = New AdvantageFramework.Database.DbContext(ConnectionString, UserCode)

                                        Try

                                            Dim ep As AdvantageFramework.Database.Entities.EmployeePicture

                                            ep = AdvantageFramework.Database.Procedures.EmployeePicture.LoadByEmployeeCode(oc, ActiveUser.EmployeeCode)

                                            If ep IsNot Nothing AndAlso ep.Image IsNot Nothing Then

                                                ActiveUser.EmployeePicture = ep.Image

                                            End If

                                        Catch ex As Exception
                                        End Try

                                    End Using

                                    AdvantageFramework.Database.Procedures.ChatActiveUser.Insert(DbContext, ActiveUser, ErrorMessage)

                                End If

                            End Using

                        End If

                    End If

                End If

                Return ActiveUser

            Catch ex As Exception
                Return Nothing
            End Try

        End Function

        Public Shared Function GetAdminConnectionString() As String

            Try

                If String.IsNullOrWhiteSpace(ChatAdminConnString) = True Then

                    'For chat db info to registry
                    Dim ChatDBConstant As String = "IS_CHAT_DB##"
                    Dim Is64Bit As Boolean = False

                    Dim AdvantageServersKey As RegistryKey
                    Dim ChatInfoFound As Boolean = False
                    Dim AdvantagePath As String = ""

                    If IntPtr.Size = 4 Then
                        '32bit
                        Is64Bit = False
                    Else
                        '64bit
                        Is64Bit = True
                    End If

                    If Is64Bit = False Then

                        AdvantagePath = "Software\Advantage\Servers"

                    Else

                        AdvantagePath = "Software\WOW6432Node\Advantage\Servers"

                    End If

                    AdvantageServersKey = My.Computer.Registry.LocalMachine.OpenSubKey(AdvantagePath)

                    If AdvantageServersKey IsNot Nothing Then

                        Dim Servers As String() = AdvantageServersKey.GetSubKeyNames()

                        If Servers IsNot Nothing AndAlso Servers.Length > 0 Then

                            For Each Server As String In Servers

                                If ChatInfoFound = True Then

                                    Exit For

                                Else

                                    Dim ServerRegKey As RegistryKey
                                    ServerRegKey = AdvantageServersKey.OpenSubKey(Server)

                                    Dim Databases As String() = ServerRegKey.GetSubKeyNames()

                                    If Databases IsNot Nothing AndAlso Databases.Length > 0 Then

                                        For Each Database As String In Databases

                                            If Database.Contains(ChatDBConstant) = True Then

                                                Dim ChatServerName As String = String.Empty
                                                Dim ChatDatabaseName As String = String.Empty
                                                Dim ChatUsername As String = String.Empty
                                                Dim ChatPassword As String = String.Empty

                                                'Get Values
                                                ChatServerName = Server.Replace("#", "\")
                                                ChatDatabaseName = Database.Replace(ChatDBConstant, "")
                                                ChatUsername = My.Computer.Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE\{0}\{1}\{2}", AdvantagePath, Server, Database), "Username", Nothing)
                                                ChatPassword = My.Computer.Registry.GetValue(String.Format("HKEY_LOCAL_MACHINE\{0}\{1}\{2}", AdvantagePath, Server, Database), "Password", Nothing)

                                                ChatPassword = AdvantageFramework.Security.Encryption.Decrypt(ChatPassword)

                                                ChatAdminConnString = AdvantageFramework.Database.CreateConnectionString(ChatServerName, ChatDatabaseName, False, ChatUsername, ChatPassword, "ChatTemp")

                                                If AdvantageFramework.Database.TestConnectionString(ChatAdminConnString) = True Then

                                                    AdvantageFramework.Security.AddWebvantageEventLog("Successfully connected to chat db!")
                                                    ChatInfoFound = True
                                                    Exit For

                                                Else

                                                    AdvantageFramework.Security.AddWebvantageEventLog(String.Format("Failed to connect to chat db using connection string:  {0}", ChatAdminConnString))
                                                    ChatAdminConnString = String.Empty

                                                End If

                                            End If

                                        Next

                                    End If

                                End If

                            Next

                        End If

                    End If

                End If

                Return ChatAdminConnString

            Catch ex As Exception

                Return String.Empty

            End Try

        End Function
        Public Shared Function GetUserConnectionStringFromHubContext(ByRef HubContext As HubCallerContext) As String

            If HubContext Is Nothing OrElse HubContext.QueryString("guid") Is Nothing Then

                Return String.Empty

            Else

                Return AdvantageFramework.Security.Encryption.ASCIIDecoding(HubContext.QueryString("guid"))

            End If

        End Function

#End Region

#Region " Overrides "

        Public Overrides Function OnConnected() As Threading.Tasks.Task

            LoadCurrentUser()
            Return MyBase.OnConnected()

        End Function
        Public Overrides Function OnDisconnected(stopCalled As Boolean) As Threading.Tasks.Task

            'DisconnectCurrentUser()
            Return MyBase.OnDisconnected(stopCalled)

        End Function
        Public Overrides Function OnReconnected() As Threading.Tasks.Task

            LoadCurrentUser()
            Return MyBase.OnReconnected()

        End Function

#End Region

#End Region

    End Class

End Namespace
