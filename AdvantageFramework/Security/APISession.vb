Namespace Security

    Public Class APISession

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ServerName As String = String.Empty
        Private _DatabaseName As String = String.Empty
        Private _UseWindowsAuthentication As Boolean = False
        Private _UserName As String = String.Empty
        Private _Password As String = String.Empty
        Private _UserCode As String = String.Empty
        Private _EmployeeCode As String = String.Empty
        Private _ConnectionString As String = String.Empty

#End Region

#Region " Properties "

        Public ReadOnly Property ServerName As String
            Get
                ServerName = _ServerName
            End Get
        End Property
        Public ReadOnly Property DatabaseName As String
            Get
                DatabaseName = _DatabaseName
            End Get
        End Property
        Public ReadOnly Property UseWindowsAuthentication As Boolean
            Get
                UseWindowsAuthentication = _UseWindowsAuthentication
            End Get
        End Property
        Public ReadOnly Property UserName As String
            Get
                UserName = _UserName
            End Get
        End Property
        Public ReadOnly Property Password As String
            Get
                Password = _Password
            End Get
        End Property
        Public ReadOnly Property UserCode As String
            Get
                UserCode = _UserCode
            End Get
        End Property
        Public ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Public ReadOnly Property ConnectionString As String
            Get
                ConnectionString = _ConnectionString
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New(ByVal ServerName As String, ByVal DatabaseName As String, ByVal UseWindowsAuthentication As Boolean,
                       ByVal UserName As String, ByVal Password As String, ByVal UserCode As String,
                       ByVal EmployeeCode As String, ByVal ConnectionString As String)

            _ServerName = ServerName
            _DatabaseName = DatabaseName
            _UseWindowsAuthentication = UseWindowsAuthentication
            _UserName = UserName
            _Password = Password
            _UserCode = UserCode
            _EmployeeCode = EmployeeCode
            _ConnectionString = ConnectionString

        End Sub

#End Region

    End Class

End Namespace