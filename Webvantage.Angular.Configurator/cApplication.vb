Option Explicit On 
Imports System.Xml
Imports System.Text
Imports Microsoft.Win32
Imports System.IO
Imports System.Security.AccessControl

Namespace nsWebsites
    Public Class Website
        Dim m_WebSiteName As String
        Dim m_PhysicalPath As String
        Dim m_WebSitePath As String



        Public Sub New()

        End Sub
        Public Property Name() As String
            Get
                Return m_WebSiteName
            End Get
            Set(ByVal Value As String)
                m_WebSiteName = Value
            End Set
        End Property

        Public Property PhysicalPath() As String
            Get
                Return m_PhysicalPath
            End Get
            Set(ByVal Value As String)
                m_PhysicalPath = Value
            End Set
        End Property
        Public Property WebSitePath() As String
            Get
                Return m_WebSitePath
            End Get
            Set(ByVal Value As String)
                m_WebSitePath = Value
            End Set
        End Property

    End Class

    Public Class WebSites
        Inherits CollectionBase
        Default Public Property Item(ByVal index As Integer) As Website
            Get
                Return CType(List(index), Website)
            End Get
            Set(ByVal Value As Website)
                List(index) = Value
            End Set
        End Property
        Public Function Add(ByVal value As Website) As Integer
            Return List.Add(value)
        End Function
        Public Function IndexOf(ByVal value As Website) As Integer
            Return List.IndexOf(value)
        End Function
        Public Sub Insert(ByVal index As Integer, ByVal value As Website)
            List.Insert(index, value)
        End Sub
        Public Sub Remove(ByVal value As Website)
            List.Remove(value)
        End Sub
        Public Function Contains(ByVal value As Website) As Boolean
            Return List.Contains(value)
        End Function
    End Class
End Namespace
Public Class cApplication
    Private mConnString As String
    Dim oSql As SqlHelper
    Public Shared strWebsitePhysicalPath As String

    Public Function CopyDirectory(ByVal source As String, ByVal destination As String)

        Dim currentDirectory As DirectoryInfo = New DirectoryInfo(source)
        Dim file As FileInfo

        For Each file In currentDirectory.GetFiles()
            file.CopyTo(Path.Combine(destination, file.Name))
        Next

        Dim di As DirectoryInfo

        For Each di In currentDirectory.GetDirectories()

            Dim subDirectory As String = Path.Combine(destination, di.Name)
            Directory.CreateDirectory(subDirectory)

            CopyDirectory(di.FullName, subDirectory)

        Next
    End Function
    Public Sub AddDirectorySecurity(ByVal FileName As String, ByVal Account As String, ByVal Rights As FileSystemRights, ByVal ControlType As AccessControlType)
        Try

            Dim dInfo As New DirectoryInfo(FileName)
            Dim dSecurity As DirectorySecurity = dInfo.GetAccessControl()

            dSecurity.AddAccessRule(New FileSystemAccessRule(Account, Rights, ControlType))
            dInfo.SetAccessControl(dSecurity)

        Catch ex As Exception

            MsgBox("AddDirectorySecurity" & Environment.NewLine & ex.Message.ToString())

        End Try

    End Sub

    Public Function dbTestConnection() As String
        Dim strName As String, strSubName As String
        Dim webvantageversion As String
        'Dim xmlpath As String = Application.StartupPath & "\Webvantage.config"
        Try
            'Dim docVersion As XmlDocument = New XmlDocument
            'docVersion.Load(xmlpath)
            'webvantageversion = docVersion.InnerText

            strName = oSql.ExecuteScalar(mConnString, CommandType.Text, "SELECT VERSION_ID FROM ADVAN_UPDATE")

            strSubName = strName.Substring(1)

            If strSubName >= webvantageversion Then
                Return strName
            Else
                Return Nothing
            End If

        Catch
            Return -1
        End Try

    End Function

    Public Function ExecuteScalar(ByVal commandType As CommandType,
                                  ByVal commandText As String) As Object
        ' Pass through the call providing null for the set of SqlParameters
        Return oSql.ExecuteScalar(mConnString, commandType, commandText)
    End Function ' ExecuteScalar

    Public Sub ExecuteSqlScriptsWithOsql(ByVal dbName As String, _
    ByVal isWinAuth As Boolean, ByVal login As String, ByVal pwd As String, _
    ByVal scriptFiles As String)
        Dim osqlParams As String = ""
        ' the OSQL utility requires different parameters if using the Win or SQL 
        ' server security
        If (isWinAuth) Then
            osqlParams = String.Format("-E -d {0} -i ", dbName)
        Else
            osqlParams = String.Format("-U {0} -P {1} -d {2} -i ", login, pwd, _
                dbName)
        End If
        ' execute each script file in the scripts array
        Dim proc As New Process
        proc.StartInfo.FileName = "osql.exe"
        proc.StartInfo.CreateNoWindow = True
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        proc.StartInfo.Arguments = osqlParams & """" & scriptFiles & """"
        proc.Start()
        ' wait until the scrip execution ends

        proc.WaitForExit()

    End Sub

    Public Function set_WebVirtDir(ByVal strWebName As String, ByVal strPath As String, ByVal strIISPATH As String)
        Dim MsgBoxTitle As String
        MsgBoxTitle = "Installing " & g_AppTitle '& " " & g_Version
        Dim objVirtDir, sName
        On Error Resume Next
        Dim objIIS
        objIIS = GetObject(strIISPATH)
        If Err.Number <> 0 Then
            MsgBox("Unable to open IIS W3SVC Root object - " & _
                "please ensure that IIS is running" & vbCrLf & _
                "     - Error Details: " & Err.Description & " [Number:" & _
                Hex(Err.Number) & "]", vbCritical, MsgBoxTitle)
            Exit Function
        End If
        objVirtDir = objIIS.GetObject("IISWebVirtualDir", strWebName)
        If Err.Number <> 0 Then
            Err.Clear()
            objVirtDir = objIIS.Create("IISWebVirtualDir", strWebName)
        End If
        If Err.Number <> 0 Then
            MsgBox("Unable to create IIS Virtual Web - " & _
                "please ensure that IIS is running" & vbCrLf & _
                "     - Error Details: " & Err.Description & " [Number:" & _
                Hex(Err.Number) & "]", vbCritical, MsgBoxTitle)
            Exit Function
        End If
        objVirtDir.AccessScript = True
        objVirtDir.Path = strPath
        ' Work around for bug in IIS 4
        objVirtDir.KeyType = "IISWebVirtualDir"
        objVirtDir.AppCreate(True)
        objVirtDir.SetInfo()
        If Err.Number <> 0 Then
            MsgBox("Unable to save IIS Virtual Web settings - " & _
                "please ensure that IIS is running" & vbCrLf & _
                "     - Error Details: " & Err.Description & " [Number:" & _
                Hex(Err.Number) & "]", vbCritical, MsgBoxTitle)
            Exit Function
        End If
        objVirtDir = Nothing
        objIIS = Nothing
    End Function
    Public Sub CreateVirtualDir(ByVal IISWebSite As String, ByVal AppName As String, ByVal strPath As String, ByVal sSessionTimeout As Integer, ByVal DefaultPage As String)
        Dim PathCreated As Boolean
        Try
            Dim IISAdmin As New System.DirectoryServices.DirectoryEntry(IISWebSite) '"IIS://" & WebSite & "/W3SVC/1/Root"
            'make sure folder exists
            If Not System.IO.Directory.Exists(strPath) Then

                System.IO.Directory.CreateDirectory(strPath)
                PathCreated = True

            End If
            'If the virtual directory already exists then delete it
            For Each VD As System.DirectoryServices.DirectoryEntry In IISAdmin.Children

                If VD.Name = AppName Then

                    IISAdmin.Invoke("Delete", New String() {VD.SchemaClassName, AppName})
                    IISAdmin.CommitChanges()
                    Application.DoEvents()
                    Threading.Thread.Sleep(1000) 'Give windows time to handle events

                    Exit For

                End If

            Next VD

            'Create and setup new virtual directory
            Dim VDir As System.DirectoryServices.DirectoryEntry = IISAdmin.Children.Add(AppName, "IIsWebVirtualDir")

            VDir.Properties("Path").Item(0) = strPath
            VDir.Properties("AppFriendlyName").Item(0) = AppName
            VDir.Properties("EnableDirBrowsing").Item(0) = False
            VDir.Properties("AccessRead").Item(0) = True
            VDir.Properties("AccessExecute").Item(0) = True
            VDir.Properties("AccessWrite").Item(0) = False
            VDir.Properties("AccessScript").Item(0) = True
            VDir.Properties("AuthNTLM").Item(0) = True
            VDir.Properties("EnableDefaultDoc").Item(0) = True
            VDir.Properties("DefaultDoc").Item(0) = DefaultPage 'System.Configuration.ConfigurationManager.AppSettings("IISDocuments").ToString '"default.htm,default.aspx,default.asp"
            VDir.Properties("AspEnableParentPaths").Item(0) = True
            VDir.Properties("AppPackageName").Item(0) = AppName
            VDir.Properties("AspSessionTimeout").Item(0) = sSessionTimeout

            VDir.CommitChanges()
            'the following are acceptable params
            'INPROC = 0
            'OUTPROC = 1
            'POOLED = 2
            VDir.Invoke("AppCreate", 1)

        Catch Ex As Exception

            'Throw Ex
            MsgBox(Ex.Message.ToString(), MsgBoxStyle.OkOnly)

        Finally

            If PathCreated Then

                System.IO.Directory.Delete(strPath)

            End If

        End Try

    End Sub
    Public Function GetIISPath() As String
        'get the IIS install path
        Dim IISregKey As RegistryKey
        Dim IISregSubKey1 As RegistryKey
        Dim IISregSubKey2 As RegistryKey
        Dim IISregSubKey3 As RegistryKey

        Try
            IISregKey = Registry.LocalMachine

            IISregSubKey1 = IISregKey.CreateSubKey("SOFTWARE")
            IISregSubKey2 = IISregSubKey1.CreateSubKey("Microsoft")
            IISregSubKey3 = IISregSubKey2.CreateSubKey("InetStp")
            GetIISPath = (IISregSubKey3.GetValue("PathWWWRoot")) 'IIS root path directory
        Catch ex As Exception
            MsgBox("Error:  IIS is not loaded on this server.")
        End Try

    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

End Class
