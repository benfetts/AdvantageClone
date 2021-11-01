Namespace Security.Password

    <Serializable>
    Public Class TwoFactorAuthentication

#Region " Constants "

        Private _Keylength As Integer = 5
        Private _TimeOutMinutes As Integer = 15

#End Region

#Region " Enum "

        Public Enum [Type]

            None
            Email
            SecurityQuestion

        End Enum

#End Region

#Region " Variables "

        Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
        Private _SecurityDbContext As AdvantageFramework.Security.Database.DbContext = Nothing
        Private _UserCode As String = String.Empty
        Private _HasKeyInDB As Boolean = False
        Private _EmailAddress As String = String.Empty

#End Region

#Region " Properties "

        Public Property AuthorizationCode As String = String.Empty
        Public Property AuthorizationDateTime As DateTime? = Nothing

        'Public Property AuthKey As Key = Nothing
        Public Property IsValid As Boolean = False
        Public Property ErrorMessage As String = String.Empty
        Public Property Mode As AdvantageFramework.Security.Password.TwoFactorAuthentication.Type = AdvantageFramework.Security.Password.TwoFactorAuthentication.Type.None
        Private Property _ConnectionString As String = String.Empty
        Public ReadOnly Property EmailAddress As String
            Get

                Return _EmailAddress

            End Get
        End Property
        Public ReadOnly Property ObfuscatedEmailAddress As String
            Get

                Return AdvantageFramework.Security.Password.ObfuscateEmailAddress(_EmailAddress)

            End Get
        End Property
        Public Property HasValidUserCode As Boolean = False

#End Region

#Region " Methods "

        'Public Function ShowAuthInput() As Boolean

        '    Dim Show As Boolean = False

        '    Try

        '        If Me.TwoFactorMode <> Type.None Then

        '            Show = True

        '        End If

        '    Catch ex As Exception
        '        Show = False
        '    End Try

        '    Return Show

        'End Function
        Public Function Validate(ByVal UserEnteredAuthKey As String) As Boolean

            If Me.GetKey() = True Then

                Me.IsValid = False

                Dim MinutesAlive As Long = 0

                If UserEnteredAuthKey = Me.AuthorizationCode Then

                    Me.IsValid = True

                Else

                    Me.IsValid = False
                    Me.ErrorMessage = "Incorrect authorization key."

                End If

                If Me.IsValid = True Then

                    MinutesAlive = DateDiff(DateInterval.Minute, CType(Me.AuthorizationDateTime, DateTime), CType(Now, DateTime))

                    If MinutesAlive <= _TimeOutMinutes Then

                        Me.IsValid = True
                        ErrorMessage = String.Empty

                    Else

                        ErrorMessage = "This authorization key has expired.<br />Please click the Resend link to get a new code."
                        Me.IsValid = False

                    End If

                    'Me.Clear()

                End If

            End If

            Return Me.IsValid

        End Function
        Public Function SendTwoFactorAuthenticationEmail() As Boolean

            Dim Sent As Boolean = False
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim EmployeeCode As String = String.Empty
            Dim Employee As Employee = Nothing
            Dim Subject As String = "Advantage Software Authentication Code"
            Dim Body As String = String.Empty
            Dim Sb As New Text.StringBuilder
            Dim HtmlEmail As New AdvantageFramework.Email.Classes.HtmlEmail(True, False)
            Dim URL As String = String.Empty
            Dim UserSqlParameter As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            Dim CurrentUser As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim CurrentUserCode As String = String.Empty
            Dim CurrentPassword As String = String.Empty

            Me._DbContext.Database.Connection.Open()
            Me._SecurityDbContext.Database.Connection.Open()

            If String.IsNullOrWhiteSpace(Me._UserCode) = False Then

                CurrentUser = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(Me._SecurityDbContext, Me._UserCode)

                If CurrentUser IsNot Nothing Then

                    If CurrentUser.IsInactive = False Then

                        UserSqlParameter.Value = Me._UserCode

                        Try

                            EmployeeCode = Me._DbContext.Database.SqlQuery(Of String)("SELECT TOP 1 EMP_CODE FROM SEC_USER SU WITH(NOLOCK) WHERE UPPER(SU.USER_CODE) = UPPER(@USER_CODE) " &
                                                                                      "ORDER BY SU.SEC_USER_ID DESC;",
                                                                                      UserSqlParameter).SingleOrDefault

                        Catch ex As Exception
                            EmployeeCode = String.Empty
                        End Try
                        If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                            Employee = (From Entity In _DbContext.Employees
                                        Where Entity.Code = EmployeeCode
                                        Select New Employee With {.Code = Entity.Code,
                                                                  .FirstName = Entity.FirstName,
                                                                  .MiddleInitial = Entity.MiddleInitial,
                                                                  .LastName = Entity.LastName,
                                                                  .Email = Entity.Email,
                                                                  .TerminationDate = Entity.TerminationDate}).SingleOrDefault

                            If Employee IsNot Nothing Then

                                If AdvantageFramework.Email.HasValidSMTPSettings(_DbContext, _SecurityDbContext, EmployeeCode, True) Then

                                    If Employee.TerminationDate Is Nothing Then

                                        Me._EmailAddress = Employee.Email

                                        If String.IsNullOrWhiteSpace(Me._EmailAddress) = False Then

                                            Me.SetKey()

                                            If String.IsNullOrWhiteSpace(Employee.FirstName) = False Then

                                                HtmlEmail.AddCustomRow(String.Format("<span style=''>Hello {0},</span>", Employee.FirstName))

                                            Else

                                                HtmlEmail.AddCustomRow(String.Format("<span style=''>Hello,</span>"))

                                            End If

                                            HtmlEmail.AddBlankRow()

                                            HtmlEmail.AddCustomRow("Please use the following Advantage authentication code to sign in:")

                                            HtmlEmail.AddBlankRow()
                                            'HtmlEmail.AddCustomRow(String.Format("<span style='word-break: break-all; font-size:30px;'>{0}</span>", Me.AuthKey.AuthKey))
                                            HtmlEmail.AddCustomRow(String.Format("<span style='word-break: break-all; font-size:30px;'>{0}</span>", Me.AuthorizationCode))
                                            HtmlEmail.AddBlankRow()
                                            HtmlEmail.AddCustomRow(String.Format("This code will expire in {0} minutes.  If your code has expired, you can always request another.", Me._TimeOutMinutes))
                                            HtmlEmail.AddBlankRow()
                                            HtmlEmail.AddCustomRow("If you’ve received multiple reset emails, please make sure you use the code inside the most recent email.")
                                            HtmlEmail.AddBlankRow()
                                            HtmlEmail.AddCustomRow("This is an automated message. Please do not reply to this email. If you need additional help, please email <a href=""mailto:support@gotoadvantage.com"">support@gotoadvantage.com</a>.")
                                            HtmlEmail.AddBlankRow()
                                            HtmlEmail.AddCustomRow("<span style ='font-size:8.0px'>This message contains information that may be confidential, privileged or otherwise protected by law from disclosure. It is intended for the exclusive use of the addressee(s) and only the addressee or authorized agent of the addressee may review, copy, distribute or disclose to anyone the message or any information contained within. If you are not the addressee, please contact the sender by electronic reply and immediately delete all copies of the message. This message is not an offer capable of acceptance, does not create an obligation of any kind and no recipient may rely on this message.</span>")
                                            HtmlEmail.AddBlankRow()
                                            HtmlEmail.AddBlankRow()

                                            HtmlEmail.AddAdvantageLogoImageRow()

                                            HtmlEmail.Finish()

                                            Body = HtmlEmail.ToString

                                            Sent = AdvantageFramework.Email.Send(Me._DbContext,
                                                                             Me._SecurityDbContext,
                                                                             Me._EmailAddress,
                                                                             Subject,
                                                                             Body,
                                                                             3,
                                                                             Nothing,
                                                                             True,
                                                                             SendingEmailStatus,
                                                                             ErrorMessage)

                                            If Sent = False Then

                                                Try

                                                    If String.IsNullOrWhiteSpace(SendingEmailStatus.ToString) = False Then

                                                        ErrorMessage = SendingEmailStatus.ToString

                                                    End If
                                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                                        ErrorMessage &= Environment.NewLine & ErrorMessage

                                                    End If

                                                Catch ex As Exception
                                                    ErrorMessage = "Email failed to send."
                                                End Try

                                            End If

                                        Else

                                            ErrorMessage = AdvantageFramework.Security.Password.NoEmailAddressMessage
                                            Sent = False

                                        End If

                                    Else

                                        ErrorMessage = "Employee terminated."
                                        Sent = False

                                    End If

                                Else

                                    ErrorMessage = "No valid email settings available."
                                    Sent = False

                                End If

                            Else

                                ErrorMessage = "No employee associated with this User ID."
                                Sent = False

                            End If

                        Else

                            ErrorMessage = "No employee associated with this User ID."
                            Sent = False

                        End If

                    Else

                        ErrorMessage = "Inactive user code."
                        Sent = False

                    End If

                Else

                    ErrorMessage = "Invalid user code."
                    Sent = False

                End If

            Else

                ErrorMessage = "User code required."
                Sent = False

            End If

            Return Sent

        End Function

#Region " Private "

        Private Sub LoadCurrentType()

            Dim s As String = String.Empty
            Dim SQL As String = String.Format("SELECT RTRIM(LTRIM(LOWER(ISNULL(CAST(A.AGY_SETTINGS_VALUE AS VARCHAR), '')))) " &
                                              " FROM AGY_SETTINGS A WITH(NOLOCK) WHERE A.AGY_SETTINGS_CODE = 'PWD_TWO_FCTR'")

            If Me._DbContext IsNot Nothing Then

                Try

                    s = Me._DbContext.Database.SqlQuery(Of String)(SQL).SingleOrDefault()

                Catch ex As Exception
                    s = String.Empty
                End Try

            ElseIf String.IsNullOrWhiteSpace(Me._ConnectionString) = False Then

                Try

                    Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                        Dim MyCMD As New System.Data.SqlClient.SqlCommand()

                        MyCMD.CommandType = CommandType.Text
                        MyCMD.CommandText = SQL
                        MyCMD.Connection = MyConn

                        MyConn.Open()
                        s = MyCMD.ExecuteScalar().ToString()

                        If MyConn.State = ConnectionState.Open Then

                            MyConn.Close()

                        End If

                    End Using

                Catch ex As Exception
                    s = String.Empty
                End Try

            End If
            If String.IsNullOrWhiteSpace(s) = False Then

                Select Case s.ToLower()
                    Case "email"

                        Me.Mode = Type.Email

                    Case "securityquestion"

                        Me.Mode = Type.SecurityQuestion

                    Case Else

                        Me.Mode = Type.None

                End Select

            End If

        End Sub
        Private Sub SetKey()

            Dim ObjectString As String = String.Empty

            ''  Newtonsoft not deserializing!!!
            'Me.AuthKey.AuthKey = AdvantageFramework.Security.RandomAlphaStringKey(Me._Keylength)
            'Me.AuthKey.AuthDateTime = DateTime.Now
            'ObjectString = Newtonsoft.Json.JsonConvert.SerializeObject(Me.AuthKey)
            'ObjectString = AdvantageFramework.Security.Encryption.Encrypt(ObjectString)

            Me.AuthorizationCode = AdvantageFramework.Security.RandomAlphaStringKey(Me._Keylength)
            Me.AuthorizationDateTime = DateTime.Now

            ObjectString = String.Format("{0}|{1}", AuthorizationCode, AuthorizationDateTime.ToString())
            ObjectString = AdvantageFramework.Security.Encryption.Encrypt(ObjectString)

            Try

                Me._DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE SEC_USER WITH(ROWLOCK) SET AUTH_KEY = '{0}' WHERE USER_CODE = '{1}';", ObjectString, Me._UserCode))

            Catch ex As Exception
                Me.ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

        End Sub
        Private Function GetKey() As Boolean

            Dim Got As Boolean = True

            Try

                Dim ObjectString As String = String.Empty

                Try

                    ObjectString = Me._DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(S.AUTH_KEY, '') FROM SEC_USER S WITH(NOLOCK) WHERE S.USER_CODE = '{0}';", Me._UserCode)).SingleOrDefault

                Catch ex As Exception
                    Me.ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                    ObjectString = String.Empty
                    Got = False
                End Try

                If String.IsNullOrWhiteSpace(ObjectString) = False Then

                    ObjectString = AdvantageFramework.Security.Encryption.Decrypt(ObjectString)

                    Try

                        Dim ar As String()

                        ar = ObjectString.Split("|")

                        Me.AuthorizationCode = ar(0)
                        Me.AuthorizationDateTime = CType(ar(1), DateTime)

                    Catch ex As Exception
                    End Try

                    'Try

                    '    Me.AuthKey = Newtonsoft.Json.JsonConvert.DeserializeObject(ObjectString) ' CType(Newtonsoft.Json.JsonConvert.DeserializeObject(ObjectString), Key)

                    'Catch ex As Exception
                    '    Me.ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                    '    Me.AuthKey = Nothing
                    '    Got = False
                    'End Try

                End If

            Catch ex As Exception
                Me.ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                'Me.AuthKey = Nothing
                Got = False
            End Try

            'If Me.AuthKey IsNot Nothing Then

            '    If String.IsNullOrWhiteSpace(Me.AuthKey.AuthKey) = False Then

            '        Got = True

            '    End If

            'Else

            '    'Me.Clear()
            '    Got = False

            'End If

            Return Got

        End Function
        Public Sub Clear()

            Try

                Me._DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE SEC_USER WITH(ROWLOCK) SET AUTH_KEY = NULL WHERE USER_CODE = '{0}';", Me._UserCode))

            Catch ex As Exception
                Me.ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
            End Try

        End Sub
        Private Sub CheckForValidUserCode()

            Dim s As String = String.Empty
            Dim SQL As String = String.Format("SELECT USER_CODE FROM dbo.SEC_USER WHERE USER_CODE = '{0}'", _UserCode)

            If Me._DbContext IsNot Nothing Then

                Try

                    s = Me._DbContext.Database.SqlQuery(Of String)(SQL).SingleOrDefault()

                Catch ex As Exception
                    s = String.Empty
                End Try

            ElseIf String.IsNullOrWhiteSpace(Me._ConnectionString) = False Then

                Try

                    Using MyConn As New System.Data.SqlClient.SqlConnection(Me._ConnectionString)

                        Dim MyCMD As New System.Data.SqlClient.SqlCommand()

                        MyCMD.CommandType = CommandType.Text
                        MyCMD.CommandText = SQL
                        MyCMD.Connection = MyConn

                        MyConn.Open()
                        s = MyCMD.ExecuteScalar().ToString()

                        If MyConn.State = ConnectionState.Open Then

                            MyConn.Close()

                        End If

                    End Using

                Catch ex As Exception
                    s = String.Empty
                End Try

            End If
            If String.IsNullOrWhiteSpace(s) = False Then

                Me.HasValidUserCode = True

            Else

                Me.HasValidUserCode = False

            End If

        End Sub

#End Region

        Sub New(ByVal ConnectionString As String, ByVal UserCode As String)

            Me._UserCode = UserCode

            'Me.AuthKey = New Key
            'Me.AuthKey.UserCode = Me._UserCode

            Me._ConnectionString = ConnectionString

            Me._DbContext = New AdvantageFramework.Database.DbContext(Me._ConnectionString, Me._UserCode)
            Me._SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me._ConnectionString, Me._UserCode)

            Me.LoadCurrentType()
            Me.CheckForValidUserCode()

        End Sub
        Sub New(ByVal DbContext As AdvantageFramework.Database.DbContext,
                ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                ByVal UserCode As String)

            Me._DbContext = DbContext
            Me._SecurityDbContext = SecurityDbContext
            Me._UserCode = UserCode

            'Me.AuthKey = New Key
            'Me.AuthKey.UserCode = Me._UserCode

            Me.LoadCurrentType()
            Me.CheckForValidUserCode()

        End Sub

#End Region

#Region " Classes "

        <Serializable>
        Public Class Key

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property AuthKey As String = String.Empty
            Public Property AuthDateTime As DateTime? = Nothing
            Public Property ServerName As String = String.Empty
            Public Property DatabaseName As String = String.Empty
            Public Property UserCode As String = String.Empty
            Public Property UserPassword As String = String.Empty

#End Region

#Region " Methods "

            Sub New()

            End Sub

#End Region

        End Class

        <Serializable>
        Public Class Employee

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

            Public Property Code() As String
            Public Property FirstName() As String
            Public Property MiddleInitial() As String
            Public Property LastName() As String
            Public Property Email() As String
            Public Property TerminationDate() As Nullable(Of Date)

#End Region

#Region " Methods "

            Sub New()



            End Sub

#End Region

        End Class

#End Region

    End Class

End Namespace
