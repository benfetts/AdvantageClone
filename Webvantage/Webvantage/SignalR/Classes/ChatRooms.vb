'Imports System.Collections.Generic
'Imports System.Linq

'Namespace SignalR.Classes

'    Public Class ChatRooms

'#Region " Constants "



'#End Region

'#Region " Enum "



'#End Region

'#Region " Variables "



'#End Region

'#Region " Properties "

'        Private _Rooms As Dictionary(Of String, AdvantageFramework.Database.Entities.ChatRoom)

'#End Region

'#Region " Methods "

'        Public Function Count() As Integer

'            Return _Rooms.Count

'        End Function
'        Public Function Find(ByVal RoomID As String, ByRef Room As AdvantageFramework.Database.Entities.ChatRoom) As Boolean

'            If _Rooms.TryGetValue(RoomID, Room) = True Then

'                Return True

'            Else

'                Room = Nothing
'                Return False

'            End If

'        End Function
'        Public Function List() As List(Of AdvantageFramework.Database.Entities.ChatRoom)

'            Return _Rooms.Values.ToList()

'        End Function
'        Public Function AddRoom(ByRef Room As AdvantageFramework.Database.Entities.ChatRoom) As Boolean

'            Try

'                Dim RoomName As String = Room.Name
'                Dim RoomCount As Integer = Me.List().Where(Function(Entity) Entity.Name = RoomName).Count()

'                If RoomCount > 0 Then

'                    RoomCount += 1
'                    Room.Name = Room.Name & String.Format(" ({0})", RoomCount.ToString())

'                End If

'            Catch ex As Exception
'            End Try
'            Try

'                _Rooms.Add(Room.RoomID, Room)
'                Return True

'            Catch ex As Exception
'                Return False
'            End Try

'        End Function
'        Public Function RemoveRoom(ByVal Room As AdvantageFramework.Database.Entities.ChatRoom) As Boolean

'            Return _Rooms.Remove(Room.RoomID)

'        End Function
'        Public Sub SaveRoom()

'        End Sub

'        Sub New()

'            _Rooms = New Dictionary(Of String, AdvantageFramework.Database.Entities.ChatRoom)

'        End Sub

'#End Region

'    End Class

'End Namespace
