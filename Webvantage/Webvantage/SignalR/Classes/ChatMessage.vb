'Imports System.Collections.Generic
'Imports System.Linq

'Namespace SignalR.Classes

'    Public Class ChatMessage

'#Region " Constants "



'#End Region

'#Region " Enum "



'#End Region

'#Region " Variables "



'#End Region

'#Region " Properties "

'        Private Property _UserCode As String = ""
'        Private Property _ConnectionString As String = ""
'        Private Property _FullName As String = ""
'        Private Property _TimeStamp As DateTime
'        Private Property _EmployeePicture As Byte()

'        Public Property Message As String = ""

'        Public Property UserCode As String
'            Get
'                Return _UserCode
'            End Get
'            Set(value As String)
'                _UserCode = value
'            End Set
'        End Property
'        Public Property FullName As String
'            Get
'                Return _FullName
'            End Get
'            Set(value As String)
'                _FullName = value
'            End Set
'        End Property
'        Public Property TimeStamp As DateTime
'            Get
'                Return _TimeStamp
'            End Get
'            Set(value As DateTime)
'                _TimeStamp = value
'            End Set
'        End Property
'        Public Property EmployeePicture As Byte()
'            Get
'                Return _EmployeePicture
'            End Get
'            Set(value As Byte())
'                _EmployeePicture = value
'            End Set
'        End Property
'        Public Property IsSaved As Boolean = False
'        Public Property IsSystemMessage As Boolean = False
'        Public ReadOnly Property TimeStampToLongDateString As String
'            Get
'                Return String.Format("{0:f}", _TimeStamp)
'            End Get
'        End Property

'#End Region

'#Region " Methods "

'        Sub New(ByVal User As AdvantageFramework.Database.Entities.ChatActiveUser)

'            _UserCode = User.UserCode
'            _ConnectionString = User.ConnectionString
'            _FullName = User.EmployeeFullName
'            _EmployeePicture = User.EmployeePicture
'            _TimeStamp = DateTime.Now


'        End Sub
'        Sub New()

'        End Sub

'#End Region

'    End Class

'End Namespace

