'NOTE:
'Billing Rate in Timesheet requires Advantage DB version to be in a very specific range!
'Please ensure the web.config has the right versions using the VersionEncryptor

Imports Microsoft.Win32
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
<Serializable()> Public Structure cApplicationInfo
    <Serializable()> Public Structure cLicenseInfo
        Public PowerUsers As Long
        Public TimeEntry As Long
        Public AgencyName As String
    End Structure
    Public PowerUsers As Long
    Public TimeEntry As Long
    'Public Version As String '= "2.11.0"
    'Const strMinDBVersion As String = "v5.60"
    'Const strMaxDBVersion As String = "v5.70"
    Public DatabaseVersion As String
    Public LicenseInfo As cLicenseInfo
    Public SQLServerAppName As String
    Public ADvantageDatabaseVersion As String
    Public LastAdvantageUpdate As String
    Public LastWebvantageUpdate As String
End Structure

<Serializable()> Public Class AppSideMenu
#Region "Internal Variables"
    Inherits CollectionBase
    Private _MenuItem As String
#End Region
    Public Property MenuItem() As String
        Get
            Return _MenuItem
        End Get
        Set(ByVal Value As String)
            _MenuItem = Value
        End Set
    End Property
End Class

<Serializable()> Public Class cApplication
    Dim mConnString As String
    Dim oSQL As SqlHelper

    Private Function GetLicenseKey() As String

        ' Create parameter for stored procedure
        Dim parameterLicenseKey As New SqlParameter("@LicenseKey", SqlDbType.VarChar, 58)
        parameterLicenseKey.Direction = ParameterDirection.Output

        Try
            oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_App_Get_License_Key", parameterLicenseKey)
        Catch
            Err.Raise(9999, , Err.Description)
        End Try

        If IsDBNull(parameterLicenseKey.Value) = False Then
            Return CStr(parameterLicenseKey.Value)
        Else
            Return ""
        End If

    End Function

    Private Function Decrypt(ByVal strLK As String) As String
        Dim I As Integer
        Dim sChar As String
        Dim sReturn As String

        For I = 1 To Len(strLK)
            sChar = Mid$(strLK, I, 1)
            If sChar = "K" Then
                sChar = "0"
            ElseIf sChar = "T" Then
                sChar = "1"
            ElseIf sChar = "F" Then
                sChar = "2"
            ElseIf sChar = "M" Then
                sChar = "3"
            ElseIf sChar = "9" Then
                sChar = "4"
            ElseIf sChar = "Z" Then
                sChar = "5"
            ElseIf sChar = "@" Then
                sChar = "6"
            ElseIf sChar = "#" Then
                sChar = "7"
            ElseIf sChar = "p" Then
                sChar = "8"
            ElseIf sChar = "%" Then
                sChar = "9"
            ElseIf sChar = "Q" Then
                sChar = "a"
            ElseIf sChar = "6" Then
                sChar = "b"
            ElseIf sChar = "$" Then
                sChar = "c"
            ElseIf sChar = "O" Then
                sChar = "d"
            ElseIf sChar = "t" Then
                sChar = "e"
            ElseIf sChar = "W" Then
                sChar = "f"
            ElseIf sChar = "D" Then
                sChar = "g"
            ElseIf sChar = "0" Then
                sChar = "h"
            ElseIf sChar = "A" Then
                sChar = "i"
            ElseIf sChar = "r" Then
                sChar = "j"
            ElseIf sChar = "q" Then
                sChar = "k"
            ElseIf sChar = "V" Then
                sChar = "l"
            ElseIf sChar = "R" Then
                sChar = "m"
            ElseIf sChar = "(" Then
                sChar = "n"
            ElseIf sChar = Chr(34) Then
                sChar = "o"
            ElseIf sChar = "-" Then
                sChar = "p"
            ElseIf sChar = "z" Then
                sChar = "q"
            ElseIf sChar = "C" Then
                sChar = "r"
            ElseIf sChar = "3" Then
                sChar = "s"
            ElseIf sChar = "," Then
                sChar = "t"
            ElseIf sChar = "&" Then
                sChar = "u"
            ElseIf sChar = "u" Then
                sChar = "&"
            ElseIf sChar = "." Then
                sChar = "v"
            ElseIf sChar = "[" Then
                sChar = "w"
            ElseIf sChar = "j" Then
                sChar = "x"
            ElseIf sChar = "H" Then
                sChar = "y"
            ElseIf sChar = "=" Then
                sChar = "z"
            ElseIf sChar = "l" Then
                sChar = "A"
            ElseIf sChar = "h" Then
                sChar = "B"
            ElseIf sChar = "<" Then
                sChar = "C"
            ElseIf sChar = "_" Then
                sChar = "D"
            ElseIf sChar = "m" Then
                sChar = "E"
            ElseIf sChar = "b" Then
                sChar = "F"
            ElseIf sChar = ")" Then
                sChar = "G"
            ElseIf sChar = "o" Then
                sChar = "H"
            ElseIf sChar = "*" Then
                sChar = "I"
            ElseIf sChar = "d" Then
                sChar = "J"
            ElseIf sChar = "/" Then
                sChar = "K"
            ElseIf sChar = "B" Then
                sChar = "L"
            ElseIf sChar = "{" Then
                sChar = "M"
            ElseIf sChar = "4" Then
                sChar = "N"
            ElseIf sChar = "g" Then
                sChar = "O"
            ElseIf sChar = ">" Then
                sChar = "P"
            ElseIf sChar = "7" Then
                sChar = "Q"
            ElseIf sChar = "!" Then
                sChar = "R"
            ElseIf sChar = "+" Then
                sChar = "S"
            ElseIf sChar = "i" Then
                sChar = "T"
            ElseIf sChar = "]" Then
                sChar = "U"
            ElseIf sChar = "1" Then
                sChar = "V"
            ElseIf sChar = "I" Then
                sChar = "W"
            ElseIf sChar = "'" Then
                sChar = "X"
            ElseIf sChar = "a" Then
                sChar = "Y"
            ElseIf sChar = "5" Then
                sChar = "Z"
            ElseIf sChar = "c" Then
                sChar = "-"
            ElseIf sChar = "E" Then
                sChar = "."
            ElseIf sChar = "|" Then
                sChar = ","
            ElseIf sChar = "2" Then
                sChar = """"
            ElseIf sChar = "X" Then
                sChar = """"
            ElseIf sChar = "8" Then
                sChar = "!"
            ElseIf sChar = "k" Then
                sChar = "@"
            ElseIf sChar = "e" Then
                sChar = "#"
            ElseIf sChar = "s" Then
                sChar = "$"
            ElseIf sChar = "L" Then
                sChar = "%"
            ElseIf sChar = "N" Then
                sChar = " "
            ElseIf sChar = "S" Then
                sChar = "*"
            ElseIf sChar = "v" Then
                sChar = "("
            ElseIf sChar = "J" Then
                sChar = ")"
            ElseIf sChar = "Y" Then
                sChar = "_"
            ElseIf sChar = "f" Then
                sChar = "="
            ElseIf sChar = "}" Then
                sChar = "+"
            ElseIf sChar = "w" Then
                sChar = "<"
            ElseIf sChar = "U" Then
                sChar = ">"
            ElseIf sChar = "G" Then
                sChar = "/"
            ElseIf sChar = "x" Then
                sChar = "["
            ElseIf sChar = "n" Then
                sChar = "]"
            ElseIf sChar = "^" Then
                sChar = "}"
            ElseIf sChar = "P" Then
                sChar = "{"
            ElseIf sChar = "y" Then
                sChar = "|"
            End If
            sReturn = sReturn & sChar
        Next I

        Return sReturn
    End Function

    Public Function NTAuth_IgnoreCase() As Boolean
        If MiscFN.IsNTAuth() = True Then
            If CType(System.Configuration.ConfigurationManager.AppSettings("NTAuthIgnoreCase").ToString(), Boolean) = True Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Shared Function GetWebvantageVersion() As String
        Try
            Dim VersionKey As String = System.Configuration.ConfigurationManager.AppSettings("VCtrl")
            VersionKey = cSecurity.Decrypt("VersionEncryptor2007", VersionKey)
            Dim str() As String = VersionKey.Split("|")
            Return str(1).ToString
        Catch ex As Exception
            Return "Error getting Webvantage version!"
        End Try
    End Function

    Public Shared Function GetVersionText() As String
        If MiscFN.IsClientPortal() = False Then
            Return "Webvantage&nbsp;Aqua&nbsp;&nbsp;v" & cApplication.GetWebvantageVersion()
        Else
            Return "Webvantage&nbsp;Aqua&nbsp;::&nbsp;portal &nbsp;v" & cApplication.GetWebvantageVersion()
        End If
    End Function

    Public Shared Function GetCopyrightText() As String
        Return "The Advantage Software Company, Copyright&copy;, " & Now.Year().ToString() & "."
    End Function

    Public Shared Function WriteToWebvantageEventLog() As Boolean

        'objects
        Dim AllowWriteToWebvantageEventLog As Boolean = True

        Try

            If String.IsNullOrWhiteSpace(System.Configuration.ConfigurationManager.AppSettings.Get("WriteToWebvantageEventLog")) = False Then

                AllowWriteToWebvantageEventLog = CType(System.Configuration.ConfigurationManager.AppSettings("WriteToWebvantageEventLog").ToString(), Boolean)

            End If

        Catch ex As Exception
            AllowWriteToWebvantageEventLog = True
        End Try

        WriteToWebvantageEventLog = AllowWriteToWebvantageEventLog

    End Function
    'Remove proofing stuff from this when out of beta
    Public Shared Function IsConceptShareActive(ByRef SecuritySession As AdvantageFramework.Security.Session) As Boolean

        Dim IsActive As Boolean = False

        'Check code set by DashboardController.vb
        If HttpContext.Current.Session(AdvantageFramework.Proofing.ConceptShareSessionKey) IsNot Nothing Then

            IsActive = CType(HttpContext.Current.Session(AdvantageFramework.Proofing.ConceptShareSessionKey), Boolean)

        Else

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                IsActive = AdvantageFramework.Proofing.IsConceptShareActive(SecuritySession, DbContext, MiscFN.IsClientPortal)

            End Using

            HttpContext.Current.Session(AdvantageFramework.Proofing.ConceptShareSessionKey) = IsActive

        End If

        Return IsActive

    End Function
    Public Shared Function IsProofingToolActive(ByRef SecuritySession As AdvantageFramework.Security.Session) As Boolean

        Dim IsActive As Boolean = False

        'Check code set by DashboardController.vb
        If HttpContext.Current.Session(AdvantageFramework.Proofing.ProofingSessionKey) IsNot Nothing Then

            IsActive = CType(HttpContext.Current.Session(AdvantageFramework.Proofing.ProofingSessionKey), Boolean)

        Else

            Using DbContext = New AdvantageFramework.Database.DbContext(SecuritySession.ConnectionString, SecuritySession.UserCode)

                IsActive = AdvantageFramework.Proofing.IsProofingToolActive(SecuritySession, DbContext, MiscFN.IsClientPortal)

            End Using

            HttpContext.Current.Session(AdvantageFramework.Proofing.ProofingSessionKey) = IsActive

        End If

        Return IsActive

    End Function
    Public Function IsASPClient() As Boolean

        Dim IsValid As Boolean = False
        Dim SessionKey As String = "IsASPClient"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Dim i As Integer = 0

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                    i = DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT ISNULL(ASP_ACTIVE,0) FROM AGENCY WITH(NOLOCK);")).FirstOrDefault

                End Using

            Catch ex As Exception
                i = 0
            End Try

            IsValid = i = 1

            HttpContext.Current.Session(SessionKey) = IsValid

        Else

            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

        End If

        Return IsValid

    End Function
    Public Shared Function SetSignInCookie(ByRef ServerName As String, ByRef DatabaseName As String,
                                           ByRef UserName As String, ByRef Password As String,
                                           ByRef RememberSettings As Boolean, ByRef ErrorMessage As String) As Boolean

        Dim Version As String = GetWebvantageVersion()
        Dim CookieKey As String = "20PBTT077001_" & Version
        Dim ClientPortalCookieKey As String = "20LOLT157001_" & Version

        If MiscFN.IsClientPortal = True Then CookieKey = ClientPortalCookieKey

        Dim ChocolateChip As New System.Web.HttpCookie(CookieKey)
        Try
            If RememberSettings = False Then
                'Delete cookie
                Try

                    Dim currentUserCookie As HttpCookie = HttpContext.Current.Request.Cookies(CookieKey)
                    HttpContext.Current.Response.Cookies.Remove(CookieKey)
                    currentUserCookie.Expires = DateTime.Now.AddDays(-10)
                    currentUserCookie.Value = Nothing
                    HttpContext.Current.Response.SetCookie(currentUserCookie)

                Catch ex As Exception
                End Try

            Else
                With ChocolateChip
                    .Values("1") = AdvantageFramework.Security.Encryption.Encrypt(ServerName)
                    .Values("2") = AdvantageFramework.Security.Encryption.Encrypt(DatabaseName)
                    .Values("3") = AdvantageFramework.Security.Encryption.Encrypt(UserName)
                    .Values("4") = "" 'AdvantageFramework.Security.Encryption.Encrypt(Password)
                    .Values("5") = RememberSettings.ToString()

                    .Expires = DateTime.Now.AddDays(14)

                End With
                HttpContext.Current.Response.Cookies.Add(ChocolateChip)
            End If

            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try

    End Function

    Public Shared Function GetSignInCookie(ByRef ServerName As String, ByRef DatabaseName As String, ByRef UserName As String, ByRef Password As String,
                                ByRef RememberSettings As Boolean, ByRef ErrorMessage As String) As Boolean

        Dim Version As String = GetWebvantageVersion()
        Dim CookieKey As String = "20PBTT077001_" & Version
        Dim ClientPortalCookieKey As String = "20LOLT157001_" & Version

        If MiscFN.IsClientPortal = True Then CookieKey = ClientPortalCookieKey

        Try
            If HttpContext.Current.Request.Cookies(CookieKey) IsNot Nothing Then

                If Not HttpContext.Current.Request.Cookies(CookieKey)("1") Is Nothing Then

                    ServerName = AdvantageFramework.Security.Encryption.Decrypt(HttpContext.Current.Request.Cookies(CookieKey)("1").ToString())

                Else

                    ServerName = ""

                End If
                If Not HttpContext.Current.Request.Cookies(CookieKey)("2") Is Nothing Then

                    DatabaseName = AdvantageFramework.Security.Encryption.Decrypt(HttpContext.Current.Request.Cookies(CookieKey)("2").ToString())

                Else

                    DatabaseName = ""

                End If
                If Not HttpContext.Current.Request.Cookies(CookieKey)("3") Is Nothing Then

                    UserName = AdvantageFramework.Security.Encryption.Decrypt(HttpContext.Current.Request.Cookies(CookieKey)("3").ToString())

                Else

                    UserName = ""

                End If

                Password = ""

                If Not HttpContext.Current.Request.Cookies(CookieKey)("5") Is Nothing Then

                    RememberSettings = CType(HttpContext.Current.Request.Cookies(CookieKey)("5"), Boolean)

                Else

                    RememberSettings = False

                End If

            Else

                ServerName = ""
                DatabaseName = ""
                UserName = ""
                Password = ""
                RememberSettings = False
                ErrorMessage = ""

            End If

            ErrorMessage = ""
            Return True

        Catch ex As Exception
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function


    Public Function GetAlertList(ByVal EmpCode As String) As SqlDataReader
        Try
            Dim arP(1) As SqlParameter

            Dim pEMP_CODE As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            pEMP_CODE.Value = EmpCode
            arP(0) = pEMP_CODE

            Return oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_alert_GetList", arP)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Function AlertNotify() As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "AlertNotify"

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim i As Integer = 0
            i = oSQL.ExecuteScalar(mConnString, CommandType.Text, "Select ISNULL(ALERT_NOTIFY,0) FROM AGENCY With(NOLOCK);")
            If i = 1 Then
                IsValid = True
            Else
                IsValid = False
            End If

            'If IsValid = True And CType(System.Configuration.ConfigurationManager.AppSettings("AlertRefresh"), Integer) <= 0 Then
            '    IsValid = False
            'End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function PopupViewed(ByVal sAlertID As String, ByVal sEmpCode As String) As Boolean
        Dim i As Integer
        i = oSQL.ExecuteScalar(mConnString, CommandType.Text, "Select ISNULL(NEW_ALERT,0) FROM ALERT_RCPT Where ALERT_ID=" + sAlertID + " And EMP_CODE='" + sEmpCode + "'")
        If i = 1 Then
            Return True
        Else
            oSQL.ExecuteNonQuery(mConnString, CommandType.Text, "Update ALERT_RCPT set NEW_ALERT=1 where ALERT_ID=" + sAlertID + " and EMP_CODE='" + sEmpCode + "'")
            Return False
        End If
    End Function

    Public Function GetFileDate(ByVal FileName As String) As String
        Dim dir As DirectoryInfo = New DirectoryInfo(HttpContext.Current.Request.PhysicalApplicationPath & "bin")
        Dim files As FileInfo() = dir.GetFiles()
        Dim count As Integer = files.Length
        Dim i As Integer
        For i = 0 To count - 1
            If files(i).Name = FileName Then
                Return files(i).LastWriteTime.ToString
            End If
        Next
    End Function


#Region " Currently not in use"

    'Public Function GetAdminConnString(ByVal DatabaseServerName As String, ByVal DatabaseName As String) As String
    '    Dim strSQLAdminUserName As String
    '    Dim strSQLAdminPassword As String

    '    Dim objRK As RegistryKey
    '    Dim ThisServer As String
    '    objRK = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers")
    '    Dim rkDatabaseNames As RegistryKey
    '    Dim rkDatabase As RegistryKey
    '    Try
    '        'loop through subkeys under server node
    '        'if subkey name is same as me.txtdatabase.text, then keep parent subkey name as servername
    '        'get username/password for sqladmin key
    '        Dim StrArServerNames() As String
    '        Dim StrArDatabaseNames() As String
    '        Dim StrServerName As String = String.Empty
    '        Dim StrDatabaseName As String = String.Empty

    '        StrArServerNames = objRK.GetSubKeyNames
    '        For i As Integer = 0 To StrArServerNames.Length - 1 'string array has all server names
    '            StrServerName = StrArServerNames(i).ToString() '.Replace("#", "\")
    '            rkDatabaseNames = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers").OpenSubKey(StrServerName)
    '            StrArDatabaseNames = rkDatabaseNames.GetSubKeyNames
    '            For j As Integer = 0 To StrArDatabaseNames.Length - 1 'string array has all databases under this server
    '                StrDatabaseName = StrArDatabaseNames(j).ToString
    '                If StrDatabaseName = DatabaseName Then 'this is the key we're looking for
    '                    DatabaseServerName = StrArServerNames(i).ToString.Replace("#", "\")
    '                    rkDatabase = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Advantage").OpenSubKey("Servers").OpenSubKey(StrServerName).OpenSubKey(StrDatabaseName)
    '                    If strSQLAdminUserName = String.Empty Or strSQLAdminUserName = "" Then
    '                        strSQLAdminUserName = rkDatabase.GetValue("Username", "")
    '                    End If
    '                    If strSQLAdminPassword = String.Empty Or strSQLAdminPassword = "" Then
    '                        strSQLAdminPassword = rkDatabase.GetValue("Password", "")
    '                    End If
    '                End If
    '            Next
    '        Next

    '        Dim strAdminConnString As String = String.Empty
    '        If strSQLAdminUserName = "" Or strSQLAdminPassword = "" Then
    '            strAdminConnString = ""
    '        Else
    '            strAdminConnString = "Persist Security Info=False;Data Source=" & DatabaseServerName
    '            strAdminConnString &= ";Initial Catalog=" & DatabaseName
    '            strAdminConnString &= ";User ID=" & strSQLAdminUserName & ";Password=" & strSQLAdminPassword
    '            strAdminConnString &= ";Pooling=False;Application Name=Webvantage;Connect Timeout=120;Connection Lifetime=60;Connection Reset=True;Max Pool Size=1;"
    '        End If

    '        Return strAdminConnString

    '    Catch ex As Exception
    '        Return ""
    '    End Try

    'End Function

    Public Sub ClearSleepingConnections()
        oSQL.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_KillSleepingConnections")
    End Sub

    'called from global.asax if sysadmin info is in web.config
    Public Overloads Sub ClearLicenses()

    End Sub
    'called from login for administrator and sysadmin info is not in web.config
    Public Overloads Sub ClearLicenses(ByVal AdminConnString As String)

    End Sub


#End Region

    Public Sub New(Optional ByVal ConnectionString As String = "")
        If ConnectionString.Trim() = "" Then
            mConnString = HttpContext.Current.Session("ConnString").ToString()
        Else
            mConnString = ConnectionString
        End If
    End Sub

End Class
