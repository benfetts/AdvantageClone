Imports System.IO
'Imports ICSharpCode.SharpZipLib.Zip
'Imports ICSharpCode.SharpZipLib.Core
Imports Ionic.Zip
Imports Webvantage.cGlobals
Imports Webvantage.MiscFN
Imports System.Data
Imports System.Data.SqlClient
Imports Webvantage.SqlHelper
Imports System.Web
Imports System

<System.Serializable()> Public Class MobileDocumentRepository

#Region " Variables "

    Private _path As String
    Private _userDomain As String
    Private _userName As String
    Private _userPassword As String
    Private _connString As String
    Private _OriginalWindowsIdentity As System.Security.Principal.WindowsIdentity
    Private oSQL As AdvantageMobile.DataService.SqlHelper


#End Region

#Region " Properties "

    Public Property ConnectionString() As String
        Get
            Return _connString
        End Get
        Set(ByVal value As String)
            _connString = value
        End Set
    End Property
    Public Property Path() As String
        Get
            Return _path
        End Get
        Set(ByVal value As String)
            _path = value
        End Set
    End Property
    Public Property UserDomain() As String
        Get
            Return _userDomain
        End Get
        Set(ByVal value As String)
            _userDomain = value
        End Set
    End Property
    Public Property UserName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property
    Public Property UserPassword() As String
        Get
            Return _userPassword
        End Get
        Set(ByVal value As String)
            _userPassword = value
        End Set
    End Property
    Public Property OriginalWindowsIdentity() As System.Security.Principal.WindowsIdentity
        Get
            Return _OriginalWindowsIdentity
        End Get
        Set(ByVal value As System.Security.Principal.WindowsIdentity)
            _OriginalWindowsIdentity = value
        End Set
    End Property

#End Region

    Public Sub New(Optional ByVal connectionString As String = "", Optional ByVal InitRepositoryLimits As Boolean = False)
        If connectionString.Trim() <> "" Then
            Me.ConnectionString = connectionString
        Else
            Me.ConnectionString = HttpContext.Current.Session("ConnString")
        End If

        Try
            Me.IsRepositoryLimitFeatureEnabled = Me.RepositoryLimitFeatureIsEnabled
        Catch ex As Exception
            Me.IsRepositoryLimitFeatureEnabled = False
        End Try

        If InitRepositoryLimits = True Or Me.IsRepositoryLimitFeatureEnabled = True Then
            Try
                Me.FileSizeMax = Me.GetFileSizeLimit(ByteDisplay.Bytes)
                Me.RepositoryMax = Me.GetRepositoryLimit(ByteDisplay.Bytes)
                Me.RepositoryUsed = Me.GetRepositoryUsage(ByteDisplay.Bytes)
                Me.RepositoryLeft = Me.RepositoryMax - Me.RepositoryUsed
                If Me.RepositoryMax > 0 And Me.FileSizeMax > 0 Then
                    If (Me.RepositoryUsed >= Me.RepositoryMax) Then ' Or (Me.FileSizeMax > Me.RepositoryLeft) Then
                        Me.IsOverRepositoryLimitSet = True
                    Else
                        Me.IsOverRepositoryLimitSet = False
                    End If
                Else
                    Me.IsOverRepositoryLimitSet = False
                End If
            Catch ex As Exception
                Me.IsRepositoryLimitFeatureEnabled = False
                Me.FileSizeMax = -1
                Me.RepositoryMax = -1
                Me.RepositoryUsed = -1
                Me.IsOverRepositoryLimitSet = False
            End Try
        Else
            Me.IsRepositoryLimitFeatureEnabled = False
            Me.FileSizeMax = -1
            Me.RepositoryMax = -1
            Me.RepositoryUsed = -1
            Me.IsOverRepositoryLimitSet = False
        End If
    End Sub

#Region " Repository Limit "

    'For setting sizes, a NULL or minus 1 indicates no limits
    '1 kilobyte = 1024 bytes
    '1 megabytes = 1 048 576 bytes
    '1 gigabytes = 1 073 741 824 bytes
    Public KB As Long = 1024
    Public MB As Long = 1048576
    Public GB As Long = 1073741824

    Public Enum ByteDisplay

        Auto = 0
        Bytes = 1
        Kilobytes = 2
        Megabytes = 3
        Gigabytes = 4

    End Enum

    Private _isRepositoryLimitFeatureEnabled As Boolean = False
    Private _isOverRepositoryLimitSet As Boolean = False
    Private _fileSizeMax As Long = -1
    Private _repositoryMax As Long = -1
    Private _repositoryUsed As Long = -1
    Private _repositoryLeft As Long = -1
    Public Property IsOverRepositoryLimitSet() As Boolean
        Get
            Return _isOverRepositoryLimitSet
        End Get
        Set(ByVal value As Boolean)
            _isOverRepositoryLimitSet = value
        End Set
    End Property
    Public Property IsRepositoryLimitFeatureEnabled() As Boolean
        Get
            Return _isRepositoryLimitFeatureEnabled
        End Get
        Set(ByVal value As Boolean)
            _isRepositoryLimitFeatureEnabled = value
        End Set
    End Property
    Public Property FileSizeMax() As Long
        Get
            Return _fileSizeMax
        End Get
        Set(ByVal value As Long)
            _fileSizeMax = value
        End Set
    End Property
    Public Property RepositoryMax() As Long
        Get
            Return _repositoryMax
        End Get
        Set(ByVal value As Long)
            _repositoryMax = value
        End Set
    End Property
    Public Property RepositoryUsed() As Long
        Get
            Return _repositoryUsed
        End Get
        Set(ByVal value As Long)
            _repositoryUsed = value
        End Set
    End Property
    Public Property RepositoryLeft() As Long
        Get
            Return _repositoryLeft
        End Get
        Set(ByVal value As Long)
            _repositoryLeft = value
        End Set
    End Property
    Public Function GetRepositorySize() As Long
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Dim SessionKey As String = "RepositorySize"
            Dim RepositorySize As Long = -1
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    RepositorySize = CType(oSQL.ExecuteScalar(Me.ConnectionString, CommandType.Text, "SELECT ISNULL(SUM(CAST(FILE_SIZE AS BIGINT)),0) FROM DOCUMENTS WITH(NOLOCK) WHERE NOT FILE_SIZE IS NULL;"), Long)
                Catch ex As Exception
                    RepositorySize = -1
                End Try
                HttpContext.Current.Session(SessionKey) = RepositorySize
            Else
                RepositorySize = CType(HttpContext.Current.Session(SessionKey), Long)
            End If
            Return RepositorySize
        Else
            Return 0
        End If
    End Function
    'Get actual usage
    Public Function GetRepositoryUsage(ByVal DisplayIn As ByteDisplay, Optional ByRef Abbreviation As String = "") As Long
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Try
                Dim l As Long = Me.GetRepositorySize()
                Select Case DisplayIn
                    Case ByteDisplay.Auto
                        Dim j As Long = l
                        Abbreviation = "Bytes"
                        If l >= KB Then
                            j = l / KB
                            Abbreviation = "KB"
                        End If
                        If l >= MB Then
                            j = l / MB
                            Abbreviation = "MB"
                        End If
                        If l >= GB Then
                            j = l / GB
                            Abbreviation = "GB"
                        End If
                        l = j
                    Case ByteDisplay.Bytes
                        l = l
                        Abbreviation = "Bytes"
                    Case ByteDisplay.Kilobytes
                        l = l / KB
                        Abbreviation = "KB"
                    Case ByteDisplay.Megabytes
                        l = l / MB
                        Abbreviation = "MB"
                    Case ByteDisplay.Gigabytes
                        l = l / GB
                        Abbreviation = "GB"
                End Select
                l = CType(Math.Round(CType(l, Double), 2), Long)
                Return l
            Catch ex As Exception
                Return -2 'error
            End Try
        Else
            Return -1
        End If
    End Function

    Private Function GetRepositoryLimit(Optional ByVal DisplayAs As ByteDisplay = ByteDisplay.Gigabytes) As Long
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Dim SessionKey As String = "RepositoryLimit"
            Dim RepositoryLimit As Long = -1
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim arP(1) As SqlParameter
                    Dim p0 As New SqlParameter("@TYPE", SqlDbType.SmallInt)
                    p0.Value = 0
                    arP(0) = p0
                    Dim divisor As Long
                    Select Case DisplayAs
                        Case ByteDisplay.Bytes, ByteDisplay.Auto
                            'in db as bytes
                            divisor = 1
                        Case ByteDisplay.Kilobytes
                            divisor = KB
                        Case ByteDisplay.Megabytes
                            divisor = MB
                        Case ByteDisplay.Gigabytes
                            divisor = GB
                    End Select
                    RepositoryLimit = CType(oSQL.ExecuteScalar(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_Limit_Get", arP), Long) / divisor
                Catch ex As Exception
                    RepositoryLimit = -1
                End Try
                HttpContext.Current.Session(SessionKey) = RepositoryLimit
            Else
                RepositoryLimit = CType(HttpContext.Current.Session(SessionKey), Long)
            End If
            Return RepositoryLimit
        Else
            Return 0
        End If
    End Function
    Public Function SaveRepositoryLimit(ByVal TheLimit As Long) As String
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Try
                Dim SessionKey As String = "RepositoryLimit"
                TheLimit = TheLimit * GB
                Dim arP(2) As SqlParameter
                Dim p0 As New SqlParameter("@TYPE", SqlDbType.SmallInt)
                p0.Value = 0
                arP(0) = p0
                Dim p1 As New SqlParameter("@LIMIT", SqlDbType.VarChar, 8000)
                p1.Value = TheLimit.ToString()
                arP(1) = p1
                oSQL.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_Limit_Set", arP)
                HttpContext.Current.Session(SessionKey) = Nothing
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        Else
            Return ""
        End If
    End Function
    Public Function SaveFileSizeLimit(ByVal TheLimit As Long) As String
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Try
                TheLimit = TheLimit * MB
                Dim arP(2) As SqlParameter
                Dim p0 As New SqlParameter("@TYPE", SqlDbType.SmallInt)
                p0.Value = 1
                arP(0) = p0
                Dim p1 As New SqlParameter("@LIMIT", SqlDbType.VarChar, 8000)
                p1.Value = TheLimit.ToString()
                arP(1) = p1
                oSQL.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_Limit_Set", arP)
                Dim SessionKey As String = "FileSizeLimit"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitAuto"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitBytes"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitKilobytes"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitMegabytes"
                HttpContext.Current.Session(SessionKey) = Nothing
                SessionKey = "FileSizeLimitGigabytes"
                HttpContext.Current.Session(SessionKey) = Nothing
                Return ""
            Catch ex As Exception
                Return ex.Message.ToString()
            End Try
        Else
            Return ""
        End If
    End Function
    Public Function GetFileSizeLimit(Optional ByVal DisplayAs As ByteDisplay = ByteDisplay.Megabytes) As Long
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 1 Then
            Dim FileSizeLimit As Long = -1
            Dim SessionKey As String = "FileSizeLimit" & DisplayAs.ToString()
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim arP(1) As SqlParameter
                    Dim p0 As New SqlParameter("@TYPE", SqlDbType.SmallInt)
                    p0.Value = 1
                    arP(0) = p0
                    Dim divisor As Long
                    Select Case DisplayAs
                        Case ByteDisplay.Bytes, ByteDisplay.Auto
                            'in db as bytes
                            divisor = 1
                        Case ByteDisplay.Kilobytes
                            divisor = KB
                        Case ByteDisplay.Megabytes
                            divisor = MB
                        Case ByteDisplay.Gigabytes
                            divisor = GB
                    End Select
                    FileSizeLimit = CType(oSQL.ExecuteScalar(Me.ConnectionString, CommandType.StoredProcedure, "usp_wv_DocumentManager_Limit_Get", arP), Long) / divisor
                Catch ex As Exception
                    FileSizeLimit = -1
                End Try
                HttpContext.Current.Session(SessionKey) = FileSizeLimit
            Else
                FileSizeLimit = CType(HttpContext.Current.Session(SessionKey), Long)
            End If
            Return FileSizeLimit
        Else
            Return 0
        End If
    End Function
    Public Function FileSizeLimitText() As String
        If Me.IsOverRepositoryLimitSet = True Then
            Return "*The repository is full.  Files will not be uploaded!  Please contact an administrator."
        End If
        Dim l As Long = Me.FileSizeMax
        If l > 0 And l > Me.RepositoryLeft And Me.RepositoryLeft > 0 Then
            Return "*The file size limit exceeds the space left in the repository.  Files will not be uploaded!  Please contact an administrator."
        End If
        If l < 0 Then
            Return ""
        ElseIf l = 0 Then
            Return "*Upload file size is set to 0 MB.  Files will not be uploaded!  Please contact an administrator."
        ElseIf l > 0 Then
            Dim d As Long = Me.FileSizeMax / Me.MB
            Return "*Files larger than " & d.ToString() & "MB will automatically be excluded."
        End If
    End Function
    Public Structure FileCompare
        Public FileByteLength As Long
        Public FileSizeLimit As Long
        Public NormalizedFileSize As Long
        Public Difference As Long
        Public ReturnMessageHTML As String
        Public ReturnMessageJS As String
        Public IsOverRepositoryLimit As Boolean
        Public FileLimitExceedRemainingRepositorySpace As Boolean
    End Structure
    Public Function IsOverFileSizeLimit(ByRef fc As FileCompare,
    Optional ByVal DisplayAs As ByteDisplay = ByteDisplay.Megabytes) As Boolean
        If Me.IsRepositoryLimitFeatureEnabled = False Then
            With fc
                .FileSizeLimit = -1
                .NormalizedFileSize = -1
                .Difference = -1
                .ReturnMessageHTML = ""
                .ReturnMessageJS = ""
                .IsOverRepositoryLimit = False
                .FileLimitExceedRemainingRepositorySpace = False
            End With
            Return False
        End If
        'Comparison is done in bytes but give user option to return some data
        Dim limit As Long = Me.FileSizeMax
        Dim divisor As Long = 1
        Dim abrev As String = ""
        Select Case DisplayAs
            Case ByteDisplay.Bytes, ByteDisplay.Auto
                'in db as bytes
                divisor = 1
                abrev = "Bytes"
            Case ByteDisplay.Kilobytes
                divisor = KB
                abrev = "KB"
            Case ByteDisplay.Megabytes
                divisor = MB
                abrev = "MB"
            Case ByteDisplay.Gigabytes
                divisor = GB
                abrev = "GB"
        End Select
        'set the struct
        With fc
            If Me.FileSizeMax >= Me.RepositoryLeft Then
                .FileLimitExceedRemainingRepositorySpace = True
            Else
                .FileLimitExceedRemainingRepositorySpace = False
            End If
            .FileSizeLimit = limit / divisor
            .NormalizedFileSize = .FileByteLength / divisor
            .Difference = (.FileByteLength - limit) / divisor
            .IsOverRepositoryLimit = Me.IsOverRepositoryLimitSet
            If .IsOverRepositoryLimit = True Then
                .ReturnMessageHTML = "Repository limit has been reached."
                .ReturnMessageJS = "Repository limit has been reached."
            ElseIf limit > 0 And limit > Me.RepositoryLeft And .IsOverRepositoryLimit = False Then
                .ReturnMessageHTML = "The file size limit exceeds the space left in the repository."
                .ReturnMessageJS = "The file size limit exceeds the space left in the repository."
                .FileLimitExceedRemainingRepositorySpace = True
            ElseIf .FileByteLength > Me.FileSizeMax Then
                .ReturnMessageHTML = "File is too large.  Uploads are limited to " & .FileSizeLimit.ToString() & abrev & "."
                .ReturnMessageJS = "File is too large.  Uploads are limited to " & .FileSizeLimit.ToString() & abrev & "."
            End If
        End With
        'boolean return here
        If limit < 0 Or fc.FileByteLength = 0 Then 'no limits
            Return False
            Exit Function
        End If
        If fc.FileByteLength > limit Or fc.IsOverRepositoryLimit = True Or fc.FileLimitExceedRemainingRepositorySpace = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function RepositoryLimitFeatureIsEnabled() As Boolean
        If CType(System.Configuration.ConfigurationManager.AppSettings("EnableDocRepSize"), Integer) = 0 Then
            Return False
            Exit Function
        End If
        If Me.GetRepositoryLimit(ByteDisplay.Bytes) < 0 Then
            Return False
        Else
            Return True
        End If
    End Function
#End Region


End Class
