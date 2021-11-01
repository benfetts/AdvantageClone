Imports System.Data
Imports System
Imports System.Threading
Imports System.IO 'for writing the PDF
Imports System.Web.Services.Protocols ' for soap exception
Imports System.Web.Mail
Imports System.Web.UI.Page
Imports System.Text.RegularExpressions
Imports System.Data.SqlClient
Imports System.Collections
Imports MailBee.SmtpMail

<Serializable()> Public Class EmailCCCol
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As EmailCCDetail
        Get
            Return CType(List(index), EmailCCDetail)
        End Get
        Set(ByVal Value As EmailCCDetail)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As EmailCCDetail) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As EmailCCDetail) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As EmailCCDetail)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As EmailCCDetail)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As EmailCCDetail) As Boolean
        Return List.Contains(value)
    End Function

End Class

<Serializable()> Public Class SendEmailCol
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As SendEmailDetail
        Get
            Return CType(List(index), SendEmailDetail)
        End Get
        Set(ByVal Value As SendEmailDetail)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As SendEmailDetail) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As SendEmailDetail) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As SendEmailDetail)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As SendEmailDetail)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As SendEmailDetail) As Boolean
        Return List.Contains(value)
    End Function

End Class

<Serializable()> Public Class EmailCCDetail

    Dim m_ClientID As String
    Dim m_DivisionID As String
    Dim m_ProductID As String
    Dim m_Body As String

    Public Property ClientID() As String
        Get
            Return m_ClientID
        End Get
        Set(ByVal Value As String)
            m_ClientID = Value
        End Set
    End Property

    Public Property DivisionID() As String
        Get
            Return m_DivisionID
        End Get
        Set(ByVal Value As String)
            m_DivisionID = Value
        End Set
    End Property

    Public Property ProductID() As String
        Get
            Return m_ProductID
        End Get
        Set(ByVal Value As String)
            m_ProductID = Value
        End Set
    End Property

    Public Property Body() As String
        Get
            Return m_Body
        End Get
        Set(ByVal Value As String)
            m_Body = Value
        End Set
    End Property

End Class

<Serializable()> Public Class SendEmailDetail

    Dim m_ClientID As String
    Dim m_DivisionID As String
    Dim m_ProductID As String
    Dim m_ContactCode As String
    Dim m_FileName As String
    Dim m_ContactEmail As String
    Dim m_Subject As String
    Dim m_Body As String
    Dim m_Report As String
    Dim m_ID As String
    Dim m_PostPeriod As String
    Dim m_Location As String
    Dim m_AgedDate As Date
    Dim m_footer As String

    Public Property ClientID() As String
        Get
            Return m_ClientID
        End Get
        Set(ByVal Value As String)
            m_ClientID = Value
        End Set
    End Property

    Public Property DivisionID() As String
        Get
            Return m_DivisionID
        End Get
        Set(ByVal Value As String)
            m_DivisionID = Value
        End Set
    End Property

    Public Property ProductID() As String
        Get
            Return m_ProductID
        End Get
        Set(ByVal Value As String)
            m_ProductID = Value
        End Set
    End Property

    Public Property ContactCode() As String
        Get
            Return m_ContactCode
        End Get
        Set(ByVal Value As String)
            m_ContactCode = Value
        End Set
    End Property

    Public Property FileName() As String
        Get
            Return m_FileName
        End Get
        Set(ByVal Value As String)
            m_FileName = Value
        End Set
    End Property

    Public Property ContactEmail() As String
        Get
            Return m_ContactEmail
        End Get
        Set(ByVal Value As String)
            m_ContactEmail = Value
        End Set
    End Property

    Public Property Subject() As String
        Get
            Return m_Subject
        End Get
        Set(ByVal Value As String)
            m_Subject = Value
        End Set
    End Property

    Public Property Body() As String
        Get
            Return m_Body
        End Get
        Set(ByVal Value As String)
            m_Body = Value
        End Set
    End Property

    Public Property Report() As String
        Get
            Return m_Report
        End Get
        Set(ByVal Value As String)
            m_Report = Value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return m_ID
        End Get
        Set(ByVal Value As String)
            m_ID = Value
        End Set
    End Property

    Public Property PostPeriod() As String
        Get
            Return m_PostPeriod
        End Get
        Set(ByVal Value As String)
            m_PostPeriod = Value
        End Set
    End Property

    Public Property Location() As String
        Get
            Return m_Location
        End Get
        Set(ByVal Value As String)
            m_Location = Value
        End Set
    End Property

    Public Property AgedDate() As Date
        Get
            Return m_AgedDate
        End Get
        Set(ByVal Value As Date)
            m_AgedDate = Value
        End Set
    End Property

    Public Property footer() As String
        Get
            Return m_footer
        End Get
        Set(ByVal Value As String)
            m_footer = Value
        End Set
    End Property


End Class

<Serializable()> Public Structure SMTP_Settings
    Private mSMTP_SERVER As String
    Private mSMTP_SENDER As String
    Private mEMAIL_USERNAME As String
    Private mEMAIL_PWD As String
    Private mSMTP_AUTH_METHOD As Int16
    Private mSMTP_PORT_NUMBER As Int16
    Private mEMAIL_REPLY_TO As String
    Private mSMTP_SECURE_TYPE As Int16
    Private mSMTP_USE_EMP_FROM As Int16
    Private mUSE_SMTP_FOR_PDF As Int16
    Private mMB_LICENSE_KEY As String
    Private mSMTP_USE_EMP_LOGIN As Int16


    Public Property SMTP_SERVER() As String
        Get
            Return mSMTP_SERVER
        End Get
        Set(ByVal Value As String)
            mSMTP_SERVER = Value
        End Set
    End Property
    Public Property SMTP_SENDER() As String
        Get
            Return mSMTP_SENDER
        End Get
        Set(ByVal Value As String)
            mSMTP_SENDER = Value
        End Set
    End Property
    Public Property EMAIL_USERNAME() As String
        Get
            Return mEMAIL_USERNAME
        End Get
        Set(ByVal Value As String)
            mEMAIL_USERNAME = Value
        End Set
    End Property
    Public Property EMAIL_PWD() As String
        Get
            Return mEMAIL_PWD
        End Get
        Set(ByVal Value As String)
            mEMAIL_PWD = Value
        End Set
    End Property
    Public Property SMTP_AUTH_METHOD() As Int16
        Get
            Return mSMTP_AUTH_METHOD
        End Get
        Set(ByVal Value As Int16)
            mSMTP_AUTH_METHOD = Value
        End Set
    End Property
    Public Property SMTP_PORT_NUMBER() As Int16
        Get
            Return mSMTP_PORT_NUMBER
        End Get
        Set(ByVal Value As Int16)
            mSMTP_PORT_NUMBER = Value
        End Set
    End Property
    Public Property EMAIL_REPLY_TO() As String
        Get
            Return mEMAIL_REPLY_TO
        End Get
        Set(ByVal Value As String)
            mEMAIL_REPLY_TO = Value
        End Set
    End Property
    Public Property SMTP_SECURE_TYPE() As Int16
        Get
            Return mSMTP_SECURE_TYPE
        End Get
        Set(ByVal Value As Int16)
            mSMTP_SECURE_TYPE = Value
        End Set
    End Property
    Public Property SMTP_USE_EMP_FROM() As Int16
        Get
            Return mSMTP_USE_EMP_FROM
        End Get
        Set(ByVal Value As Int16)
            mSMTP_USE_EMP_FROM = Value
        End Set
    End Property
    Public Property USE_SMTP_FOR_PDF() As Int16
        Get
            Return mUSE_SMTP_FOR_PDF
        End Get
        Set(ByVal Value As Int16)
            mUSE_SMTP_FOR_PDF = Value
        End Set
    End Property

    Public Property MB_LICENSE_KEY() As String
        Get
            Return mMB_LICENSE_KEY
        End Get
        Set(ByVal Value As String)
            mMB_LICENSE_KEY = Value
        End Set
    End Property

    Public Property SMTP_USE_EMP_LOGIN() As Int16
        Get
            Return mSMTP_USE_EMP_LOGIN
        End Get
        Set(ByVal Value As Int16)
            mSMTP_USE_EMP_LOGIN = Value
        End Set
    End Property

End Structure

<Serializable()> Public Class cWebServices
    Private mConnString As String
    Private mUserID As String
    Private Property mEmpCode As String = ""

    Public oSMTPSettings As SMTP_Settings
    Public err_msg As String = ""

    Private Sub setErrMsg(Optional ByVal msg As String = "")
        If msg = "" Then
            err_msg = "The e-mail could not be sent.\nYour system administrator may need to check the e-mail settings in Advantage and the e-mail server configuration"
        Else
            err_msg = msg
        End If
    End Sub

    Public Function getErrMsg()
        Return err_msg
    End Function
    Public Function SendEmail(ByVal strFileName As String, ByVal strTo As String, ByVal strSubject As String, _
                          ByVal strBody As String, Optional ByVal strCCList As String = "", Optional ByVal strCCListDelimiter As String = ",", Optional ByVal IsHTML As Boolean = False, _
                          Optional ByVal ThePriority As Short = 3) As Boolean

        Try

            Dim edso As New EmailWithDocumentsSessionObject()
            edso.ConnectionString = mConnString
            edso.UserCode = mUserID
            edso.EmployeeCode = mEmpCode
            edso.SessionID = HttpContext.Current.Session.SessionID.ToString()
            edso.PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
            edso.strTo = strTo
            edso.strCCList = strCCList
            edso.strSubject = strSubject
            edso.strBody = strBody.Trim()
            edso.Priority = ThePriority

            edso.strFileName = strFileName

            edso.Send()

        Catch ex As Exception

        End Try

        Return True

    End Function
    Public Function SendEmailNewNoDocs(ByVal strFileName As String, ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, Optional ByVal strFileNameJS As String = "", _
                                       Optional ByVal strCCList As String = "", Optional ByVal strBCCList As String = "", Optional ByVal strCCListDelimiter As String = ",", _
                                       Optional ByVal strBCCListDelimiter As String = ",", Optional ByVal strFileNameJV As String = "", Optional ByVal strFileNameEST As String = "", _
                                       Optional ByVal combine As Integer = 0, Optional ByVal strFileNameCB As String = "") As Boolean

        Try

            Dim edso As New EmailWithDocumentsSessionObject()
            edso.ConnectionString = mConnString
            edso.UserCode = mUserID
            edso.EmployeeCode = mEmpCode
            edso.SessionID = HttpContext.Current.Session.SessionID.ToString()
            edso.PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
            edso.strTo = strTo
            edso.strCCList = strCCList
            edso.strBCCList = strBCCList
            edso.strSubject = strSubject
            edso.strBody = strBody.Trim()
            edso.Priority = 3

            edso.strFileName = strFileName.Trim()
            edso.strFileNameJS = strFileNameJS.Trim()
            edso.strFileNameJV = strFileNameJV.Trim()
            edso.strFileNameEST = strFileNameEST.Trim()
            edso.strFileNameCB = strFileNameCB.Trim()

            edso.combine = combine
            edso.Send()

        Catch ex As Exception

        End Try

        Return True

    End Function
    Public Function GetSMPTSettingsByUser(Optional ByVal IsClientPortal As Boolean = False) As Boolean
        'Dim SessionKey As String = "GetSMPTSettingsByUser" & mUserID

        'If HttpContext.Current.Session(SessionKey) Is Nothing Then

        Dim dr As SqlClient.SqlDataReader
        Dim arParams(0) As SqlParameter
        Dim oSQL As SqlHelper

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = mUserID
        arParams(0) = parameterUserID

        Try
            If IsClientPortal = True Then
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_smtp_by_cpuser", arParams)
            Else
                dr = oSQL.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_get_smtp_by_user", arParams)
            End If
        Catch
            Err.Raise(Err.Number, "Class:cWebServices Routine:GetSMPTSettingsByUser", Err.Description)
            setErrMsg(Err.Description)
            Return False
        End Try

        Try
            If dr.HasRows Then
                dr.Read()
                Try
                    If Not IsDBNull(dr.GetString(0)) Then
                        oSMTPSettings.SMTP_SERVER = dr.GetString(0)
                        'HttpContext.Current.Session(SessionKey & "SMTP_SERVER") = dr.GetString(0)
                    Else
                        'HttpContext.Current.Session(SessionKey & "SMTP_SERVER") = ""
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "SMTP_SERVER") = ""
                End Try
                Try
                    If Not IsDBNull(dr.GetString(1)) Then
                        oSMTPSettings.SMTP_SENDER = dr.GetString(1)
                        'HttpContext.Current.Session(SessionKey & "SMTP_SENDER") = dr.GetString(1)
                    Else
                        'HttpContext.Current.Session(SessionKey & "SMTP_SENDER") = ""
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "SMTP_SENDER") = ""
                End Try
                Try
                    If Not IsDBNull(dr.GetString(2)) Then
                        oSMTPSettings.EMAIL_USERNAME = dr.GetString(2)
                        'HttpContext.Current.Session(SessionKey & "EMAIL_USERNAME") = dr.GetString(2)
                    Else
                        'HttpContext.Current.Session(SessionKey & "EMAIL_USERNAME") = ""
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "EMAIL_USERNAME") = ""
                End Try
                Try
                    If Not IsDBNull(dr.GetString(3)) Then
                        oSMTPSettings.EMAIL_PWD = dr.GetString(3)
                        'HttpContext.Current.Session(SessionKey & "EMAIL_PWD") = dr.GetString(3)
                    Else
                        'HttpContext.Current.Session(SessionKey & "EMAIL_PWD") = ""
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "EMAIL_PWD") = ""
                End Try
                Try
                    If Not IsDBNull(dr.GetInt16(4)) Then
                        oSMTPSettings.SMTP_AUTH_METHOD = dr.GetInt16(4)
                        'HttpContext.Current.Session(SessionKey & "SMTP_AUTH_METHOD") = dr.GetInt16(4)
                    Else
                        'HttpContext.Current.Session(SessionKey & "SMTP_AUTH_METHOD") = 0
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "SMTP_AUTH_METHOD") = 0
                End Try
                Try
                    If Not IsDBNull(dr.GetInt16(5)) Then
                        oSMTPSettings.SMTP_PORT_NUMBER = dr.GetInt16(5)
                        'HttpContext.Current.Session(SessionKey & "SMTP_PORT_NUMBER") = dr.GetInt16(5)
                    Else
                        'HttpContext.Current.Session(SessionKey & "SMTP_PORT_NUMBER") = 0
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "SMTP_PORT_NUMBER") = 0
                End Try
                Try
                    If Not IsDBNull(dr.GetString(6)) Then
                        oSMTPSettings.EMAIL_REPLY_TO = dr.GetString(6)
                        'HttpContext.Current.Session(SessionKey & "EMAIL_REPLY_TO") = dr.GetString(6)
                    Else
                        'HttpContext.Current.Session(SessionKey & "EMAIL_REPLY_TO") = ""
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "EMAIL_REPLY_TO") = ""
                End Try
                Try
                    If Not IsDBNull(dr.GetInt16(7)) Then
                        oSMTPSettings.SMTP_SECURE_TYPE = dr.GetInt16(7)
                        'HttpContext.Current.Session(SessionKey & "SMTP_SECURE_TYPE") = dr.GetInt16(7)
                    Else
                        'HttpContext.Current.Session(SessionKey & "SMTP_SECURE_TYPE") = 0
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "SMTP_SECURE_TYPE") = 0
                End Try
                Try
                    If Not IsDBNull(dr.GetInt16(8)) Then
                        oSMTPSettings.SMTP_USE_EMP_FROM = dr.GetInt16(8)
                        'HttpContext.Current.Session(SessionKey & "SMTP_USE_EMP_FROM") = dr.GetInt16(8)
                    Else
                        'HttpContext.Current.Session(SessionKey & "SMTP_USE_EMP_FROM") = 0
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "SMTP_USE_EMP_FROM") = 0
                End Try
                Try
                    If Not IsDBNull(dr.GetInt16(9)) Then
                        oSMTPSettings.USE_SMTP_FOR_PDF = dr.GetInt16(9)
                        'HttpContext.Current.Session(SessionKey & "USE_SMTP_FOR_PDF") = dr.GetInt16(9)
                    Else
                        'HttpContext.Current.Session(SessionKey & "USE_SMTP_FOR_PDF") = 0
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "USE_SMTP_FOR_PDF") = 0
                End Try
                Try
                    oSMTPSettings.MB_LICENSE_KEY = AdvantageFramework.Email.MailBeeDotNetKey
                    'HttpContext.Current.Session(SessionKey & "MB_LICENSE_KEY") = AdvantageFramework.Email.MailBeeDotNetKey
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "MB_LICENSE_KEY") = "MN700-CF0778C1075F07C1078BF870175F-B389"
                End Try
                Try
                    If Not IsDBNull(dr.GetInt16(11)) Then
                        oSMTPSettings.SMTP_USE_EMP_LOGIN = dr.GetInt16(11)
                        'HttpContext.Current.Session(SessionKey & "SMTP_USE_EMP_LOGIN") = dr.GetInt16(11)
                    Else
                        'HttpContext.Current.Session(SessionKey & "SMTP_USE_EMP_LOGIN") = 0
                    End If
                Catch ex As Exception
                    'HttpContext.Current.Session(SessionKey & "SMTP_USE_EMP_LOGIN") = 0
                End Try
                'HttpContext.Current.Session(SessionKey) = True
                Return True
            Else
                setErrMsg("No settings found")
                'HttpContext.Current.Session(SessionKey) = Nothing
                Return False
            End If
        Catch ex As Exception
            setErrMsg(ex.Message)
            'HttpContext.Current.Session(SessionKey) = Nothing
            Return False
        End Try
        'Else
        '    With oSMTPSettings
        '        Try
        '            .SMTP_SERVER = HttpContext.Current.Session(SessionKey & "SMTP_SERVER")
        '        Catch ex As Exception
        '            .SMTP_SERVER = ""
        '        End Try
        '        Try
        '            .SMTP_SENDER = HttpContext.Current.Session(SessionKey & "SMTP_SENDER")
        '        Catch ex As Exception
        '            .SMTP_SENDER = ""
        '        End Try
        '        Try
        '            .EMAIL_USERNAME = HttpContext.Current.Session(SessionKey & "EMAIL_USERNAME")
        '        Catch ex As Exception
        '            .EMAIL_USERNAME = ""
        '        End Try
        '        Try
        '            .EMAIL_PWD = HttpContext.Current.Session(SessionKey & "EMAIL_PWD")
        '        Catch ex As Exception
        '            .EMAIL_PWD = ""
        '        End Try
        '        Try
        '            .SMTP_AUTH_METHOD = HttpContext.Current.Session(SessionKey & "SMTP_AUTH_METHOD")
        '        Catch ex As Exception
        '            .SMTP_AUTH_METHOD = 0
        '        End Try
        '        Try
        '            .SMTP_PORT_NUMBER = HttpContext.Current.Session(SessionKey & "SMTP_PORT_NUMBER")
        '        Catch ex As Exception
        '            .SMTP_PORT_NUMBER = 0
        '        End Try
        '        Try
        '            .EMAIL_REPLY_TO = HttpContext.Current.Session(SessionKey & "EMAIL_REPLY_TO")
        '        Catch ex As Exception
        '            .EMAIL_REPLY_TO = ""
        '        End Try
        '        Try
        '            .SMTP_SECURE_TYPE = HttpContext.Current.Session(SessionKey & "SMTP_SECURE_TYPE")
        '        Catch ex As Exception
        '            .SMTP_SECURE_TYPE = 0
        '        End Try
        '        Try
        '            .SMTP_USE_EMP_FROM = HttpContext.Current.Session(SessionKey & "SMTP_USE_EMP_FROM")
        '        Catch ex As Exception
        '            .SMTP_USE_EMP_FROM = 0
        '        End Try
        '        Try
        '            .USE_SMTP_FOR_PDF = HttpContext.Current.Session(SessionKey & "USE_SMTP_FOR_PDF")
        '        Catch ex As Exception
        '            .USE_SMTP_FOR_PDF = 0
        '        End Try
        '        Try
        '            .MB_LICENSE_KEY = HttpContext.Current.Session(SessionKey & "MB_LICENSE_KEY")
        '        Catch ex As Exception
        '            .MB_LICENSE_KEY = ""
        '        End Try
        '        Try
        '            .SMTP_USE_EMP_LOGIN = HttpContext.Current.Session(SessionKey & "SMTP_USE_EMP_LOGIN")
        '        Catch ex As Exception
        '            .SMTP_USE_EMP_LOGIN = 0
        '        End Try
        '        HttpContext.Current.Session(SessionKey) = True
        '        Return True
        '    End With
        'End If
    End Function
    Public Sub New(ByVal ConnectionString As String, ByVal UserID As String, ByVal EmpCode As String)

        mConnString = ConnectionString
        mUserID = UserID
        Me.mEmpCode = EmpCode

    End Sub

End Class

'Public Function SendEmailWAttachments(ByVal AlertID As Integer, ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, _
'                                              Optional ByVal strCCList As String = "", Optional ByVal strCCListDelimiter As String = ",", _
'                                              Optional ByVal IsHTML As Boolean = False, Optional ByVal ThePriority As Integer = 3, _
'                                              Optional ByVal IsNTAuth As Boolean = False) As Boolean
'    Try
'        Dim strFrom As String = String.Empty
'        Dim sendbool As Boolean = False
'        Dim boolMisc As Boolean = False
'        Dim errDesc As String = ""

'        Dim impersonationContext As System.Security.Principal.WindowsImpersonationContext
'        Dim currentWindowsIdentity As System.Security.Principal.WindowsIdentity

'        If IsNTAuth = True Then
'            currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
'            impersonationContext = currentWindowsIdentity.Impersonate()
'        End If

'        boolMisc = GetSMPTSettingsByUser(MiscFN.IsClientPortal)
'        If boolMisc = False Then Return False

'        'If send to email invalid, try to use default
'        If strTo.Trim().IndexOf("<") = -1 Then
'            If AdvantageFramework.Email.IsValidEmailAddress(strTo) = False Then
'                setErrMsg("Invalid Send To email address")
'                Return False
'                Exit Function
'            End If
'        End If

'        Dim SMTPUsername As String = oSMTPSettings.EMAIL_USERNAME
'        Dim SMTPPassword As String = oSMTPSettings.EMAIL_PWD

'        strFrom = oSMTPSettings.SMTP_SENDER

'        MailBee.Global.SafeMode = True
'        Dim mbSMTP As New MailBee.SmtpMail.Smtp
'        mbSMTP.LicenseKey = oSMTPSettings.MB_LICENSE_KEY

'        Dim mbServerInfo As New MailBee.SmtpMail.SmtpServer
'        With mbServerInfo
'            .AuthMethods = oSMTPSettings.SMTP_AUTH_METHOD
'            .Name = oSMTPSettings.SMTP_SERVER
'            .AccountName = SMTPUsername
'            .Password = SMTPPassword
'            If oSMTPSettings.SMTP_PORT_NUMBER > 0 Then
'                .Port = oSMTPSettings.SMTP_PORT_NUMBER
'            End If
'            Select Case oSMTPSettings.SMTP_SECURE_TYPE
'                Case 2
'                    .SslMode = MailBee.Security.SslStartupMode.UseStartTls
'            End Select
'            '.SmtpOptions = ExtendedSmtpOptions.ClassicSmtpMode _
'            '               And ExtendedSmtpOptions.NoChunking _
'            '               And ExtendedSmtpOptions.NoDsn _
'            '               And ExtendedSmtpOptions.NoSize
'        End With

'        'assume email server disabled
'        If mbServerInfo.Name.Trim() = "" Then
'            Me.err_msg = ""
'            Return True
'        End If

'        mbServerInfo.HelloDomain = mbServerInfo.Name
'        mbSMTP.DirectSendDefaults.HelloDomain = mbServerInfo.Name

'        mbSMTP.SmtpServers.Add(mbServerInfo)

'        sendbool = mbSMTP.Connect()
'        If sendbool = False Then
'            Me.err_msg = mbSMTP.GetErrorDescription
'            Return False
'        End If

'        Dim emp As New cEmployee(Me.mConnString)
'        Dim ClientContact As AdvantageFramework.Security.Database.Entities.ClientContact
'        If MiscFN.IsClientPortal = True Then
'            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.mConnString, Me.mUserID)
'                ClientContact = AdvantageFramework.Security.Database.Procedures.ClientContact.LoadByClientContactID(SecurityDbContext, Me.mUserID)
'                If ClientContact.EmailAddress <> "" Then
'                    strFrom = ClientContact.EmailAddress
'                    mbSMTP.Message.From.AsString = ClientContact.FullNameFML & " <" & ClientContact.EmailAddress & ">"
'                End If
'            End Using
'        Else
'            strFrom = emp.GetEmail(Me.mEmpCode)
'            mbSMTP.Message.From.AsString = emp.GetFromAddress(Me.mEmpCode)
'        End If

'        mbSMTP.Message.ReplyTo.AsString = oSMTPSettings.EMAIL_REPLY_TO
'        mbSMTP.Message.To.AsString = strTo
'        mbSMTP.Message.Subject = strSubject

'        Dim a As New cAlerts()
'        a.SetPriority(mbSMTP, ThePriority)

'        If IsHTML = True Then
'            mbSMTP.Message.BodyHtmlText = strBody
'        Else
'            mbSMTP.Message.BodyPlainText = strBody
'        End If

'        Try
'            Dim AlertAttachments As New vAlertAttachmentList(mConnString)
'            AlertAttachments.Where.AlertID.Value = AlertID
'            AlertAttachments.Where.EMAILSENT.Value = False
'            AlertAttachments.Query.Load()
'            Do Until AlertAttachments.EOF

'                If IsNTAuth = True Then
'                    currentWindowsIdentity = CType(HttpContext.Current.User.Identity, System.Security.Principal.WindowsIdentity)
'                    impersonationContext = currentWindowsIdentity.Impersonate()
'                End If

'                Dim DocumentRepository As New DocumentRepository(mConnString)

'                Dim ByteStream As Byte()
'                ByteStream = DocumentRepository.GetDocument(AlertAttachments.DOCUMENT_ID)
'                Try
'                    mbSMTP.Message.Attachments.Add(ByteStream, AlertAttachments.RealFileName, Nothing, AlertAttachments.MimeType, Nothing, _
'                                                   MailBee.Mime.NewAttachmentOptions.None, MailBee.Mime.MailTransferEncoding.Base64)
'                    If Not ByteStream Is Nothing Then
'                        ByteStream = Nothing
'                    End If
'                Catch ex As Exception
'                End Try
'                AlertAttachments.MoveNext()
'            Loop

'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            If strCCList <> "" Then
'                strCCList = MiscFN.CleanStringForSplit(strCCList, strCCListDelimiter, False, True, True, True)
'                mbSMTP.Message.Cc.AsString = strCCList.Replace(",", ", ")
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            If mbSMTP.Message.To.AsString = "" And mbSMTP.Message.Cc.AsString = "" And mbSMTP.Bcc.AsString = "" Then
'            Else

'                Dim alert As New Alert(Me.mConnString)
'                If alert.MessageIsOverSized(mbSMTP, , Me.err_msg) = True Then

'                End If

'                sendbool = mbSMTP.Send()

'            End If
'            If sendbool = False Then
'                Me.err_msg = mbSMTP.GetErrorDescription
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            mbSMTP.Disconnect()
'            mbSMTP = Nothing
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'    Catch ex As Exception
'        setErrMsg(ex.Message)
'        Return False
'    End Try

'    Return True

'End Function
'Public Function SendEmail(ByVal strFileName As String, ByVal strTo As String, ByVal strSubject As String, _
'                          ByVal strBody As String, Optional ByVal strCCList As String = "", Optional ByVal strCCListDelimiter As String = ",", Optional ByVal IsHTML As Boolean = False, _
'                          Optional ByVal ThePriority As Short = 3) As Boolean
'    Try
'        Dim boolMisc As Boolean = False

'        boolMisc = GetSMPTSettingsByUser()
'        If boolMisc = False Then Return False

'        Dim SMTPUsername As String = oSMTPSettings.EMAIL_USERNAME
'        Dim SMTPPassword As String = oSMTPSettings.EMAIL_PWD

'        MailBee.Global.SafeMode = True
'        Dim mbSMTP As New MailBee.SmtpMail.Smtp
'        mbSMTP.LicenseKey = oSMTPSettings.MB_LICENSE_KEY

'        MailBee.Global.SafeMode = True
'        Dim mbServerInfo As New MailBee.SmtpMail.SmtpServer
'        With mbServerInfo
'            .AuthMethods = oSMTPSettings.SMTP_AUTH_METHOD
'            .Name = oSMTPSettings.SMTP_SERVER
'            .AccountName = [SMTPUsername]
'            .Password = [SMTPPassword]
'            If oSMTPSettings.SMTP_PORT_NUMBER > 0 Then
'                .Port = oSMTPSettings.SMTP_PORT_NUMBER
'            End If
'            Select Case oSMTPSettings.SMTP_SECURE_TYPE
'                Case 2
'                    .SslMode = MailBee.Security.SslStartupMode.UseStartTls
'            End Select
'            '.SmtpOptions = ExtendedSmtpOptions.ClassicSmtpMode _
'            '               And ExtendedSmtpOptions.NoChunking _
'            '               And ExtendedSmtpOptions.NoDsn _
'            '               And ExtendedSmtpOptions.NoSize
'        End With

'        'assume email server disabled
'        If mbServerInfo.Name.Trim() = "" Then
'            Me.err_msg = ""
'            Return True
'        End If

'        mbServerInfo.HelloDomain = mbServerInfo.Name
'        mbSMTP.DirectSendDefaults.HelloDomain = mbServerInfo.Name

'        mbSMTP.SmtpServers.Add(mbServerInfo)

'        boolMisc = mbSMTP.Connect()

'        If boolMisc = False Then
'            Me.err_msg = mbSMTP.GetErrorDescription
'            Return False
'        End If

'        Dim emp As New cEmployee(Me.mConnString)
'        mbSMTP.Message.From.AsString = emp.GetFromAddress(Me.mEmpCode)
'        mbSMTP.Message.To.AsString = strTo
'        mbSMTP.Message.ReplyTo.AsString = oSMTPSettings.EMAIL_REPLY_TO

'        Dim boolHasAttachment As Boolean = False

'        mbSMTP.Message.Subject = strSubject

'        If IsHTML = True Then
'            strBody = strBody.Replace(vbCrLf, "<br />")
'            strBody = strBody.Replace(vbCr, "<br />")
'            strBody = strBody.Replace(vbLf, "<br />")
'            strBody = strBody.Replace(Environment.NewLine, "<br />")
'            mbSMTP.Message.BodyHtmlText = strBody
'        Else
'            mbSMTP.Message.BodyPlainText = strBody
'        End If

'        Dim a As New cAlerts()
'        a.SetPriority(mbSMTP, ThePriority)

'        Try
'            If strFileName <> "" And strFileName.Length > 0 And strFileName <> String.Empty Then
'                boolHasAttachment = True
'                mbSMTP.AddAttachment(strFileName)
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            If strCCList <> "" Then
'                strCCList = MiscFN.RemoveTrailingDelimiter(strCCList, strCCListDelimiter)
'                mbSMTP.Message.Cc.AsString = strCCList
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            If mbSMTP.Message.To.AsString = "" And mbSMTP.Message.Cc.AsString = "" And mbSMTP.Bcc.AsString = "" Then
'            Else
'                Dim alert As New Alert(Me.mConnString)
'                If alert.MessageIsOverSized(mbSMTP, , Me.err_msg) = True Then

'                End If
'                boolMisc = mbSMTP.Send()
'            End If
'            If boolMisc = False Then
'                Me.err_msg = mbSMTP.GetErrorDescription
'                Return False
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            mbSMTP.Disconnect()
'            mbSMTP = Nothing
'            If boolHasAttachment = True Then
'                File.Delete(strFileName)
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'    Catch ex As Exception
'        setErrMsg(ex.Message)
'        Return False
'    End Try

'    Return True

'End Function
'Public Function SendEmailNewNoDocs(ByVal strFileName As String, ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String, Optional ByVal strFileNameJS As String = "", Optional ByVal strCCList As String = "", Optional ByVal strBCCList As String = "", Optional ByVal strCCListDelimiter As String = ",", Optional ByVal strBCCListDelimiter As String = ",", Optional ByVal strFileNameJV As String = "", Optional ByVal strFileNameEST As String = "", Optional ByVal combine As Integer = 0, Optional ByVal strFileNameCB As String = "") As Boolean
'    Try
'        If strTo.Trim() = "" Then
'            'no email addresses to send to...
'            'just return a true so as to not trigger an error alert
'            Return True
'        End If
'        Dim strFrom As String = String.Empty
'        Dim x As Integer
'        Dim arrayTo As Boolean = True
'        Dim arrayCc As Boolean = True
'        Dim arrayBcc As Boolean = True
'        Dim toArray() As String
'        Dim ccArray() As String
'        Dim bccArray() As String
'        Dim boolMisc As Boolean = False

'        boolMisc = GetSMPTSettingsByUser()
'        If boolMisc = False Then
'            setErrMsg("Error collecting SMTP database data.")
'            Return False
'            Exit Function
'        End If

'        If strTo.EndsWith(",") Then
'            strTo = strTo.Substring(0, strTo.Length - 1)
'        End If
'        If strCCList.EndsWith(",") Then
'            strCCList = strCCList.Substring(0, strCCList.Length - 1)
'        End If
'        If strBCCList.EndsWith(",") Then
'            strBCCList = strBCCList.Substring(0, strBCCList.Length - 1)
'        End If
'        If strTo <> "" And strTo.Contains(",") = True Then
'            toArray = strTo.Split(",")
'        ElseIf strTo <> "" Then
'            If AdvantageFramework.Email.IsValidEmailAddress(strTo) = False Then
'                setErrMsg("Invalid Send To email address")
'                Return False
'                Exit Function
'            End If
'            arrayTo = False
'        Else
'            arrayTo = False
'        End If
'        If strCCList <> "" And strCCList.Contains(",") Then
'            ccArray = strCCList.Split(",")
'        ElseIf strCCList <> "" Then
'            If AdvantageFramework.Email.IsValidEmailAddress(strCCList) = False Then
'                setErrMsg("Invalid CC email address")
'                Return False
'                Exit Function
'            End If
'            arrayCc = False
'        Else
'            arrayCc = False
'        End If
'        If strBCCList <> "" And strBCCList.Contains(",") Then
'            bccArray = strBCCList.Split(",")
'        ElseIf strBCCList <> "" Then
'            If AdvantageFramework.Email.IsValidEmailAddress(strBCCList) = False Then
'                setErrMsg("Invalid BCC email address")
'                Return False
'                Exit Function
'            End If
'            arrayBcc = False
'        Else
'            arrayBcc = False
'        End If

'        If arrayTo = True Then
'            If toArray.Length > 0 Then
'                For x = 0 To toArray.Length - 1
'                    If AdvantageFramework.Email.IsValidEmailAddress(toArray(x)) = False Then
'                        setErrMsg("Invalid email address")
'                        Return False
'                        Exit Function
'                    End If
'                Next
'            End If
'        End If


'        If arrayCc = True Then
'            If ccArray.Length > 0 Then
'                For x = 0 To ccArray.Length - 1
'                    If AdvantageFramework.Email.IsValidEmailAddress(ccArray(x)) = False Then
'                        setErrMsg("Invalid CC address")
'                        Return False
'                        Exit Function
'                    End If
'                Next
'            End If
'        End If

'        If arrayBcc = True Then
'            If bccArray.Length > 0 Then
'                For x = 0 To bccArray.Length - 1
'                    If AdvantageFramework.Email.IsValidEmailAddress(bccArray(x)) = False Then
'                        setErrMsg("Invalid BCC address")
'                        Return False
'                        Exit Function
'                    End If
'                Next
'            End If
'        End If


'        Dim SMTPUsername As String = oSMTPSettings.EMAIL_USERNAME
'        Dim SMTPPassword As String = oSMTPSettings.EMAIL_PWD

'        strFrom = oSMTPSettings.SMTP_SENDER

'        MailBee.Global.SafeMode = True
'        Dim mbSMTP As New MailBee.SmtpMail.Smtp
'        mbSMTP.LicenseKey = oSMTPSettings.MB_LICENSE_KEY

'        Dim mbServerInfo As New MailBee.SmtpMail.SmtpServer
'        With mbServerInfo
'            .AuthMethods = oSMTPSettings.SMTP_AUTH_METHOD
'            .Name = oSMTPSettings.SMTP_SERVER
'            .AccountName = SMTPUsername
'            .Password = SMTPPassword
'            If oSMTPSettings.SMTP_PORT_NUMBER > 0 Then
'                .Port = oSMTPSettings.SMTP_PORT_NUMBER
'            End If
'            Select Case oSMTPSettings.SMTP_SECURE_TYPE
'                Case 2
'                    .SslMode = MailBee.Security.SslStartupMode.UseStartTls
'            End Select
'            '.SmtpOptions = ExtendedSmtpOptions.ClassicSmtpMode _
'            '               And ExtendedSmtpOptions.NoChunking _
'            '               And ExtendedSmtpOptions.NoDsn _
'            '               And ExtendedSmtpOptions.NoSize
'        End With

'        'assume email server disabled
'        If mbServerInfo.Name.Trim() = "" Then
'            Me.err_msg = ""
'            Return True
'        End If

'        mbServerInfo.HelloDomain = mbServerInfo.Name
'        mbSMTP.DirectSendDefaults.HelloDomain = mbServerInfo.Name

'        mbSMTP.SmtpServers.Add(mbServerInfo)

'        boolMisc = mbSMTP.Connect()
'        If boolMisc = False Then
'            Me.err_msg = mbSMTP.GetErrorDescription
'            Return False
'        End If


'        Dim boolHasAttachment As Boolean = False

'        Dim emp As New cEmployee(Me.mConnString)
'        mbSMTP.Message.From.AsString = emp.GetFromAddress(Me.mEmpCode)
'        mbSMTP.Message.To.AsString = strTo
'        mbSMTP.Message.Subject = strSubject
'        mbSMTP.Message.ReplyTo.AsString = oSMTPSettings.EMAIL_REPLY_TO


'        Try
'            If strFileName <> "" And strFileName.Length > 0 And strFileName <> String.Empty Then
'                boolHasAttachment = True
'                mbSMTP.AddAttachment(strFileName)
'            End If
'            If strFileNameJS <> "" And strFileNameJS.Length > 0 And strFileNameJS <> String.Empty Then
'                boolHasAttachment = True
'                mbSMTP.AddAttachment(strFileNameJS)
'            End If
'            If strFileNameJV <> "" And strFileNameJV.Length > 0 And strFileNameJV <> String.Empty Then
'                boolHasAttachment = True
'                mbSMTP.AddAttachment(strFileNameJV)
'            End If
'            If strFileNameEST <> "" And strFileNameEST.Length > 0 And strFileNameEST <> String.Empty Then
'                boolHasAttachment = True
'                If combine = 1 Then
'                    mbSMTP.AddAttachment(strFileNameEST)
'                Else
'                    Dim files() As String = strFileNameEST.Split(",")
'                    For p As Integer = 0 To files.Length - 1
'                        mbSMTP.AddAttachment(files(p))
'                    Next
'                End If
'            End If
'            If strFileNameCB <> "" And strFileNameCB.Length > 0 And strFileNameCB <> String.Empty Then
'                boolHasAttachment = True
'                mbSMTP.AddAttachment(strFileNameCB)
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Dim DocumentRepository As New DocumentRepository(Me.mConnString)
'        Dim oAgency As New cAgency(Me.mConnString)
'        Dim Document As New Document(Me.mConnString)
'        Dim BoolHasLinksHeader As Boolean = False
'        Dim HTMLNewLine As String = "<br />"
'        Dim sb As New System.Text.StringBuilder
'        Dim k As Integer

'        mbSMTP.Message.BodyHtmlText = strBody & sb.ToString

'        Try
'            If strCCList <> "" Then
'                strCCList = MiscFN.RemoveTrailingDelimiter(strCCList, strCCListDelimiter)
'                mbSMTP.Message.Cc.AsString = strCCList
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            If strBCCList <> "" Then
'                strBCCList = MiscFN.RemoveTrailingDelimiter(strBCCList, strBCCListDelimiter)
'                mbSMTP.Message.Bcc.AsString = strBCCList
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            If mbSMTP.Message.To.AsString = "" And mbSMTP.Message.Cc.AsString = "" And mbSMTP.Bcc.AsString = "" Then
'            Else
'                Dim alert As New Alert(Me.mConnString)
'                If alert.MessageIsOverSized(mbSMTP, , Me.err_msg) = True Then

'                End If
'                boolMisc = mbSMTP.Send()
'            End If
'            If boolMisc = False Then
'                Me.err_msg = mbSMTP.GetErrorDescription
'                Return False
'            End If
'        Catch ex As Exception
'            setErrMsg(ex.Message)
'            Return False
'        End Try

'        Try
'            mbSMTP.Disconnect()
'            mbSMTP = Nothing
'            Return True
'        Catch ex As Exception
'        End Try

'    Catch ex As Exception
'        setErrMsg(ex.Message)
'        Return False
'    End Try

'    Return True

'End Function
