'Imports System.Collections.Generic
'Imports System.Linq

'Namespace SignalR.Classes

'    Public Class ServerGroupings

'#Region " Constants "


'#End Region

'#Region " Enum "

'        Public Enum GroupByType

'            Agency = 1
'            Database = 2
'            AgencyAndDatabase = 3

'        End Enum

'#End Region

'#Region " Variables "

'        Public Groupings As Dictionary(Of String, SignalR.Classes.ServerGrouping)

'#End Region

'#Region " Properties "

'        Public Shared Property GroupUsersBy As GroupByType = GroupByType.Database

'#End Region

'#Region " Methods "

'        Public Function Find(ByVal GroupingName As String, ByRef Grouping As SignalR.Classes.ServerGrouping) As Boolean

'            If Groupings.TryGetValue(GroupingName, Grouping) = True Then

'                Return True

'            Else

'                Grouping = Nothing
'                Return False

'            End If
'        End Function
'        Public Function Add(ByRef Grouping As SignalR.Classes.ServerGrouping) As Boolean

'            Try

'                Groupings.Add(Grouping.Name, Grouping)

'            Catch ex As Exception
'                Return False
'            End Try

'        End Function

'        Sub New()

'            Groupings = New Dictionary(Of String, SignalR.Classes.ServerGrouping)

'        End Sub

'#End Region

'    End Class

'End Namespace
