Imports System.Web
Imports System.Web.UI
Imports System.IO

Namespace Web.CookieMessages

    <Serializable()> _
    Public Class CookieMessage
        Implements IEquatable(Of CookieMessage)

        Const MessageBaseURL = "UI_Message.aspx"

#Region " Properties "

        Public Property MessageType As CookieMessages.Methods.Message
            Get
                Return _MessageType
            End Get
            Set(value As CookieMessages.Methods.Message)
                _MessageType = value
            End Set
        End Property

        Public Property RemindAgain As Boolean
            Get
                Return _RemindAgain
            End Get
            Set(value As Boolean)
                _RemindAgain = value
            End Set
        End Property

        Public Property LastReminded As Date
            Get
                Return _LastReminded
            End Get
            Set(value As Date)
                _LastReminded = value
            End Set
        End Property
        Public ReadOnly Property URL As String
            Get
                Return MessageBaseURL & "?msgid=" & CType(_MessageType, Integer).ToString()

            End Get
        End Property
        Private _MessageType As CookieMessages.Methods.Message
        Private _RemindAgain As Boolean = True
        Private _LastReminded As Date

#End Region

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj Is Nothing Then
                Return False
            End If
            Dim objAsCookieMessage As CookieMessage = TryCast(obj, CookieMessage)
            If objAsCookieMessage Is Nothing Then
                Return False
            Else
                Return Equals(objAsCookieMessage)
            End If
        End Function

        Public Overrides Function GetHashCode() As Integer
            Return CType(MessageType, Integer)
        End Function

        Public Overloads Function Equals(other As CookieMessage) As Boolean _
            Implements IEquatable(Of CookieMessage).Equals
            If other Is Nothing Then
                Return False
            End If
            Return (Me.MessageType.Equals(other.MessageType))
        End Function

    End Class

    <Serializable()> _
    Public Class Methods

#Region " Constants "

        Const CookieName = "WebvantageMessages"

#End Region

#Region " Enum "

        Public Enum Message

            NewApplications = 0
            SetColors = 1
            MobileApps = 2

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        'Public ReadOnly Property Messages As Generic.List(Of CookieMessage)
        '    Get
        '        Return _Messages
        '    End Get
        'End Property
        Public Property MessagesToShow As Generic.List(Of CookieMessage)

        Private Property _Messages As Generic.List(Of CookieMessage)
        Private Property _ConnectionString As String = ""
        Private Property _UserCode As String = ""
        Private Property _UserCookieName As String = ""

#End Region

#Region " Methods "

        Public Sub Save()

            SaveDatabase()
            SaveCookie()

        End Sub
        Public Sub Load()

            If HttpContext.Current.Session(_UserCookieName) Is Nothing Then

                LoadFromCookie()
                HttpContext.Current.Session(_UserCookieName) = _UserCookieName

            End If

        End Sub

        Public Sub Update(ByVal Message As CookieMessage)

            If _Messages.Contains(Message) Then _Messages.Remove(Message)
            _Messages.Add(Message)
            Save()

        End Sub

        Private Sub LoadFromCookie()

            If Not HttpContext.Current.Request.Cookies(_UserCookieName) Is Nothing Then

                Dim formatter As New LosFormatter()
                _Messages = DirectCast(formatter.Deserialize(HttpContext.Current.Request.Cookies(_UserCookieName).Value.ToString()), Generic.List(Of CookieMessage))

            Else

                LoadFromDatabase()

            End If

            If _Messages IsNot Nothing AndAlso _Messages.Count > 0 Then

                For Each msg In _Messages

                    If msg.RemindAgain = True AndAlso (msg.LastReminded = #12:00:00 AM# OrElse DateDiff(DateInterval.Day, msg.LastReminded, Today.Date) >= 1) Then

                        MessagesToShow.Add(msg)

                    End If

                Next

            End If

        End Sub
        Private Sub LoadFromDatabase()

            Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                Dim s As String = ""
                s = DbContext.Database.SqlQuery(Of String)("SELECT VARIABLE_VALUE FROM APP_VARS WITH(NOLOCK) WHERE USERID = {0} AND APPLICATION = 'COOKIE_MESSAGES';", _UserCode).SingleOrDefault()

                If s IsNot Nothing Then

                    Dim formatter As New LosFormatter()
                    _Messages = DirectCast(formatter.Deserialize(s), Generic.List(Of CookieMessage))

                End If

            End Using

            SaveCookie()

        End Sub

        Private Sub SaveCookie()

            Dim formatter As New LosFormatter()
            Dim c As New System.Web.HttpCookie(_UserCookieName)

            Using writer As New StringWriter()

                formatter.Serialize(writer, _Messages)
                c.Value = writer.ToString()
                c.Expires = DateTime.Now.AddDays(1)

            End Using

            HttpContext.Current.Response.Cookies.Add(c)

        End Sub
        Private Sub SaveDatabase()

            Using DbContext = New AdvantageFramework.Database.DbContext(_ConnectionString, _UserCode)

                Dim Application As String = "COOKIE_MESSAGES"
                Dim VariableName As String = "VALUE"
                Dim VariableType As String = "String"
                Dim VariableValue As String = ""

                Dim formatter As New LosFormatter()

                Using writer As New StringWriter()

                    formatter.Serialize(writer, _Messages)
                    VariableValue = writer.ToString()

                End Using

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM APP_VARS WITH(ROWLOCK) WHERE USERID = '{0}' AND APPLICATION = 'COOKIE_MESSAGES';" &
                                                                   "INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES ('{0}','{1}','{2}','{3}','{4}');",
                                                                   _UserCode, Application, VariableName, VariableType, VariableValue))

            End Using

        End Sub

        Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            _ConnectionString = ConnectionString
            _UserCode = UserCode
            _UserCookieName = CookieName & "_" & UserCode
            _Messages = New Generic.List(Of CookieMessage)

            Dim SetColorCookieMessage As New CookieMessage
            SetColorCookieMessage.MessageType = Message.SetColors
            _Messages.Add(SetColorCookieMessage)

            'Dim NewAppsCookieMessage As New CookieMessage
            'NewAppsCookieMessage.MessageType = Message.NewApplications
            '_Messages.Add(NewAppsCookieMessage)

            MessagesToShow = New Generic.List(Of CookieMessage)

        End Sub

#End Region

    End Class

End Namespace
