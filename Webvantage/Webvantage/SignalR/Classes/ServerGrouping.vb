'Imports System.Collections.Generic
'Imports System.Linq

'Namespace SignalR.Classes

'    Public Class ServerGrouping

'#Region " Constants "



'#End Region

'#Region " Enum "



'#End Region

'#Region " Variables "

'        Public ChatRooms As New SignalR.Classes.ChatRooms
'        Public Users As New AdvantageFramework.Database.Entities.ChatActiveUser

'#End Region

'#Region " Properties "

'        Public Property Name As String = ""

'#End Region

'#Region " Methods "

'#Region " Rooms "


'#End Region
'#Region " Users "

'        'Public Function AddUser(ByRef User As SignalR.Classes.ConnectedUser) As Boolean

'        '    If Users.TryGetValue(User.ConnectionString, User) = False Then

'        '        Users.Add(User.ConnectionString, User)

'        '    End If
'        '    Return True

'        'End Function
'        Public Function FindUser(ByVal UserCode As String, ByRef User As AdvantageFramework.Database.Entities.ChatActiveUser) As Boolean

'            For Each cu As KeyValuePair(Of String, AdvantageFramework.Database.Entities.ChatActiveUser) In Users.Users

'                If cu.Value.UserCode = UserCode Then

'                    User = cu.Value
'                    Return True

'                End If

'            Next

'            Return False

'        End Function

'#End Region

'        'Public Function LoadRoom(ByVal RoomID As String, ByRef Room As SignalR.Classes.ChatRoom) As Boolean

'        '    Return True

'        'End Function
'        'Public Function LoadRooms() As Boolean

'        '    Return True

'        'End Function

'        Sub New(ByVal GroupingName As String)

'            Name = GroupingName

'        End Sub

'#End Region

'    End Class

'End Namespace
