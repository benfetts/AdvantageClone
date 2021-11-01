Namespace Database

    <Serializable()>
    Public Class DatabaseProfile

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            DatabaseServer
            DatabaseName
            DatabaseUserName
            DatabasePassword
            UseWindowsAuthentication
            CPDatabaseUserName
            CPDatabasePassword
            EnableServices
        End Enum

#End Region

#Region " Variables "

        Private _DatabaseServer As String = ""
        Private _DatabaseName As String = ""
        Private _DatabaseUserName As String = ""
        Private _DatabasePassword As String = ""
        Private _UseWindowsAuthentication As Boolean = False
        Private _CPDatabaseUserName As String = ""
        Private _CPDatabasePassword As String = ""
        Private _EnableServices As Boolean = True

#End Region

#Region " Properties "

        Public Property DatabaseServer() As String
            Get
                DatabaseServer = _DatabaseServer
            End Get
            Set(ByVal value As String)
                _DatabaseServer = value
            End Set
        End Property
        Public Property DatabaseName() As String
            Get
                DatabaseName = _DatabaseName
            End Get
            Set(ByVal value As String)
                _DatabaseName = value
            End Set
        End Property
        Public Property DatabaseUserName() As String
            Get
                DatabaseUserName = _DatabaseUserName
            End Get
            Set(ByVal value As String)
                _DatabaseUserName = value
            End Set
        End Property
        Public Property DatabasePassword() As String
            Get
                DatabasePassword = _DatabasePassword
            End Get
            Set(ByVal value As String)
                _DatabasePassword = value
            End Set
        End Property
        Public Property UseWindowsAuthentication As Boolean
            Get
                UseWindowsAuthentication = _UseWindowsAuthentication
            End Get
            Set(ByVal value As Boolean)
                _UseWindowsAuthentication = value
            End Set
        End Property
        Public Property CPDatabaseUserName() As String
            Get
                CPDatabaseUserName = _CPDatabaseUserName
            End Get
            Set(ByVal value As String)
                _CPDatabaseUserName = value
            End Set
        End Property
        Public Property CPDatabasePassword() As String
            Get
                CPDatabasePassword = _CPDatabasePassword
            End Get
            Set(ByVal value As String)
                _CPDatabasePassword = value
            End Set
        End Property
        Public Property EnableServices As Boolean
            Get
                EnableServices = _EnableServices
            End Get
            Set(ByVal value As Boolean)
                _EnableServices = value
            End Set
        End Property
        Public ReadOnly Property ConnectionString As String
            Get
                ConnectionString = AdvantageFramework.Database.CreateConnectionString(_DatabaseServer, _DatabaseName, _UseWindowsAuthentication, _DatabaseUserName, _DatabasePassword)
            End Get
        End Property
        Public ReadOnly Property CPConnectionString As String
            Get
                CPConnectionString = AdvantageFramework.Database.CreateConnectionString(_DatabaseServer, _DatabaseName, False, _CPDatabaseUserName, _CPDatabasePassword)
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.DatabaseServer & " " & Me.DatabaseName

        End Function
        Public Function CreateXML() As String

            CreateXML = AdvantageFramework.BaseClasses.CreateXML(Me)

        End Function
        Public Function ImportFromXML(ByVal XML As String) As AdvantageFramework.Database.DatabaseProfile

            ImportFromXML = AdvantageFramework.BaseClasses.ImportFromXML(XML, Me.GetType)

        End Function

#End Region

    End Class

End Namespace
