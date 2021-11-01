Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq

Namespace SignalR.Classes

    '    Public Class ConnectedUser

    '#Region " Constants "



    '#End Region

    '#Region " Enum "



    '#End Region

    '#Region " Variables "



    '#End Region

    '#Region " Properties "

    '        <Newtonsoft.Json.JsonIgnore>
    '        Public Property ContextUserIdentityName As String = ""
    '        <Newtonsoft.Json.JsonIgnore>
    '        Public Property ConnectionId As String = ""
    '        <Newtonsoft.Json.JsonIgnore>
    '        Public Property GUID As String = ""

    '        Public Property UserCode As String = ""
    '        Public Property EmployeeCode As String = ""
    '        Public Property FullName As String = ""
    '        <Newtonsoft.Json.JsonIgnore>
    '        Public Property ConnectionString As String = ""
    '        Public Property EmployeePicture As Byte()
    '        <Newtonsoft.Json.JsonIgnore>
    '        Public Property IsTempSaved As Boolean = False
    '        <Newtonsoft.Json.JsonIgnore>
    '        Public Property AgencyName As String = ""
    '        <Newtonsoft.Json.JsonIgnore>
    '        Public Property DatabaseName As String = ""

    '        <Newtonsoft.Json.JsonIgnore>
    '        Public Property GroupingType As ServerGroupings.GroupByType = ServerGroupings.GroupUsersBy
    '        <Newtonsoft.Json.JsonIgnore>
    '        Public ReadOnly Property GroupingID As String
    '            Get

    '                Select Case GroupingType
    '                    Case ServerGroupings.GroupByType.Agency

    '                        Return AgencyName

    '                    Case ServerGroupings.GroupByType.Database

    '                        Return DatabaseName

    '                    Case ServerGroupings.GroupByType.AgencyAndDatabase

    '                        Return AgencyName & "_" & DatabaseName

    '                End Select

    '            End Get
    '        End Property

    '        Public Property DoNotDisturb As Boolean = False

    '#End Region

    '#Region " Methods "

    '        Public Sub Initialize()


    '        End Sub

    '        Sub New()

    '            'Me.Details = New UserEmployeeMapping

    '        End Sub

    '#End Region

    '    End Class

    Public Class MessagedUser

        Public Property UserCode As String = ""

    End Class

End Namespace
