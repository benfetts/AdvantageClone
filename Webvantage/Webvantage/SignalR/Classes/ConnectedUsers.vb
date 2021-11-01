'Imports System.Collections.Generic
'Imports System.Linq

'Namespace SignalR.Classes

'    Public Class ConnectedUsers

'#Region " Constants "



'#End Region

'#Region " Enum "



'#End Region

'#Region " Variables "

'        Public Users As Dictionary(Of String, SignalR.Classes.ConnectedUser)

'#End Region

'#Region " Properties "



'#End Region

'#Region " Methods "

'        Public Function Add(ByRef User As SignalR.Classes.ConnectedUser) As Boolean

'            If Find(User) = False Then

'                Users.Add(User.ConnectionString, User)

'            End If

'            Return True

'        End Function
'        Public Function Find(ByRef User As SignalR.Classes.ConnectedUser) As Boolean

'            Return Users.ContainsKey(User.ConnectionString)

'        End Function
'        Sub New()

'            Users = New Dictionary(Of String, ConnectedUser)

'        End Sub

'#End Region
'    End Class

'End Namespace
