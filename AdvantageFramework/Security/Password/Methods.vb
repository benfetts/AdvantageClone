Namespace Security.Password

    <HideModuleName()>
    Public Module Methods

#Region " Constants "

        '
        Private Const KeyLength As Short = 5
        Private Const PasswordFormExpireMinutes As Long = 15

        Public Const IncorrectPasswordMessage As String = "Incorrect password - Access denied."
        Public Const IncorrectPasswordWithAttemptsMessage As String = "Incorrect password - Access denied.  Attempts:  {0}/{1}"
        Public Const IncorrectOldPasswordMessage As String = "Incorrect old password."
        Public Const NewPasswordMessage As String = "Security changes require you to create a new password.  "
        Public Const NoGroupMembershipMessage As String = "Access Denied – User is not established in Security"
        Public Const NoChangeForNewUserMessage As String = "Cannot change a password for a user with no password set. Please use the ""Forgot Password"" function."
        Public Const InactiveUserMessage As String = "Cannot change a password for a user that is marked inactive."
        Public Const LockoutWithAttemptsMessage As String = "You have been locked out.  Please wait {0} minutes before you try again or contact an administrator."
        Public Const LockoutWithAdminOnlyMessage As String = "You have been locked out.  Please contact an administrator."
        Public Const NoEmailAddressMessage As String = "No email address found.  Please contact an adminstrator to help set up a password."
        Public Const BadEmailAddressMessage As String = "Failed to send email.  Please contact your adminstrator to help set up a password or verify your correct email is in the system."

#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Lost Password "

        Public Function GetCurrentEncryptedPassword(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal UserCode As String,
                                                    ByVal EmployeeCode As String) As String

            Dim CurrentPassword As String = String.Empty
            Dim UserSqlParameter As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            Dim EmployeeSqlParameter As New System.Data.SqlClient.SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)

            UserSqlParameter.Value = UserCode
            EmployeeSqlParameter.Value = EmployeeCode

            Try

                CurrentPassword = DbContext.Database.SqlQuery(Of String)("SELECT TOP 1 PASSWORD FROM SEC_USER SU WITH(NOLOCK) " &
                                                                         "WHERE UPPER(SU.USER_CODE) = UPPER(@USER_CODE) ORDER BY SU.SEC_USER_ID DESC;",
                                                                         UserSqlParameter,
                                                                         EmployeeSqlParameter).SingleOrDefault

            Catch ex As Exception
                CurrentPassword = String.Empty
            End Try

            Return CurrentPassword

        End Function
        Public Function GetCurrentEncryptedPassword(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                    ByVal UserCode As String) As String

            Dim CurrentPassword As String = String.Empty
            Dim UserSqlParameter As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

            UserSqlParameter.Value = UserCode

            Try

                CurrentPassword = DbContext.Database.SqlQuery(Of String)("SELECT TOP 1 PASSWORD FROM SEC_USER SU WITH(NOLOCK) " &
                                                                         "WHERE UPPER(SU.USER_CODE) = UPPER(@USER_CODE) ORDER BY SU.SEC_USER_ID DESC;",
                                                                         UserSqlParameter).SingleOrDefault

            Catch ex As Exception
                CurrentPassword = String.Empty
            End Try

            Return CurrentPassword

        End Function
        Public Function SendPasswordChangeEmail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                ByVal ServerName As String,
                                                ByVal DatabaseName As String,
                                                ByVal UserCode As String,
                                                ByRef HasPassword As Boolean,
                                                ByRef ErrorMessage As String) As Boolean

            Dim Sent As Boolean = False
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Nothing
            Dim EmployeeCode As String = String.Empty
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeEmailAddress As String = String.Empty
            Dim Subject As String = String.Empty
            Dim Body As String = String.Empty
            Dim Sb As New Text.StringBuilder
            Dim HtmlEmail As New AdvantageFramework.Email.Classes.HtmlEmail(True, False)
            Dim URL As String = String.Empty
            Dim RandomKey As String = String.Empty
            Dim UserSqlParameter As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            Dim CurrentUser As AdvantageFramework.Security.Database.Entities.User = Nothing
            Dim CurrentUserCode As String = String.Empty
            Dim CurrentPassword As String = String.Empty

            If AdvantageFramework.Security.Password.UserHasEmail(DbContext, UserCode) = True Then

                If String.IsNullOrWhiteSpace(UserCode) = False Then

                    CurrentUser = AdvantageFramework.Security.Database.Procedures.User.LoadByUserCode(SecurityDbContext, UserCode)

                    If CurrentUser IsNot Nothing AndAlso String.IsNullOrWhiteSpace(CurrentUser.SID) Then

                        If CurrentUser.IsInactive = False Then

                            UserSqlParameter.Value = UserCode.ToUpper()

                            If String.IsNullOrWhiteSpace(CurrentUser.Password) = False Then

                                HasPassword = True

                            Else

                                HasPassword = False

                            End If
                            If HasPassword = False Then

                                Subject = "Advantage Software Create New Password"

                            Else

                                Subject = "Advantage Software Password Reset"

                            End If
                            Try

                                EmployeeCode = DbContext.Database.SqlQuery(Of String)("SELECT TOP 1 EMP_CODE FROM SEC_USER SU WITH(NOLOCK) WHERE UPPER(SU.USER_CODE) = UPPER(@USER_CODE) " &
                                                                                      "ORDER BY SU.SEC_USER_ID DESC;",
                                                                                      UserSqlParameter).SingleOrDefault

                            Catch ex As Exception
                                EmployeeCode = String.Empty
                            End Try
                            If String.IsNullOrWhiteSpace(EmployeeCode) = False Then

                                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                                If Employee IsNot Nothing Then

                                    If Employee.TerminationDate Is Nothing Then

                                        EmployeeEmailAddress = Employee.Email

                                        'If String.IsNullOrWhiteSpace(EmployeeEmailAddress) = True Then

                                        '    EmployeeEmailAddress = Employee.ReplyToEmail

                                        'End If
                                        If String.IsNullOrWhiteSpace(EmployeeEmailAddress) = False Then

                                            If AdvantageFramework.Email.HasValidSMTPSettings(DbContext, SecurityDbContext, EmployeeCode, True) Then

                                                If HasPassword = False Then

                                                    If String.IsNullOrWhiteSpace(Employee.FirstName) = False Then

                                                        HtmlEmail.AddCustomRow(String.Format("<span style=''>Hello {0},</span>", Employee.FirstName))

                                                    Else

                                                        HtmlEmail.AddCustomRow(String.Format("<span style=''>Hello,</span>"))

                                                    End If

                                                    HtmlEmail.AddBlankRow()

                                                    HtmlEmail.AddCustomRow(NewPasswordMessage)

                                                    HtmlEmail.AddBlankRow()

                                                    HtmlEmail.AddCustomRow("Please use the following key on the New Password page:")

                                                    URL = GeneratePasswordChangeURL(DbContext, ServerName, DatabaseName, UserCode, RandomKey)

                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow(String.Format("<span style='word-break: break-all; font-size:30px;'>{0}</span>", RandomKey))
                                                    HtmlEmail.AddBlankRow()

                                                    HtmlEmail.AddButtonLinkRow(URL, "Create Password", "Click here to create password")

                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("If the button above does not work, copy and paste the entire link below into your browser.")
                                                    HtmlEmail.AddCustomRow(String.Format("<div style='margin: 10px; padding: 20px; width: 450px; border: 1px solid gray !important; word-break: break-all;'><span style='word-break: break-all;'>{0}</span></div>", URL))
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("This link will expire in " & AdvantageFramework.Security.Password.PasswordFormExpireMinutes & " minutes.  If your link has expired, you can always request another.")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("If you’ve received multiple new password emails, please make sure you click on the link inside the most recent email.")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("This is an automated message. Please do not reply to this email. If you need additional help, please email <a href=""mailto:support@gotoadvantage.com"">support@gotoadvantage.com</a>.")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("<span style ='font-size:8.0px'>This message contains information that may be confidential, privileged or otherwise protected by law from disclosure. It is intended for the exclusive use of the addressee(s) and only the addressee or authorized agent of the addressee may review, copy, distribute or disclose to anyone the message or any information contained within. If you are not the addressee, please contact the sender by electronic reply and immediately delete all copies of the message. This message is not an offer capable of acceptance, does not create an obligation of any kind and no recipient may rely on this message.</span>")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddBlankRow()

                                                Else

                                                    If String.IsNullOrWhiteSpace(Employee.FirstName) = False Then

                                                        HtmlEmail.AddCustomRow(String.Format("<span style=''>Hello {0},</span>", Employee.FirstName))

                                                    Else

                                                        HtmlEmail.AddCustomRow(String.Format("<span style=''>Hello,</span>"))

                                                    End If

                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow(String.Format("We’ve received a request to reset the password for the Advantage account associated with {0}.  No changes have been made to your account yet.", EmployeeEmailAddress))

                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("Please use the following key on the Password Reset page:")

                                                    URL = GeneratePasswordChangeURL(DbContext, ServerName, DatabaseName, UserCode, RandomKey)

                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow(String.Format("<span style='word-break: break-all; font-size:30px;'>{0}</span>", RandomKey))
                                                    HtmlEmail.AddBlankRow()

                                                    HtmlEmail.AddButtonLinkRow(URL, "Change Password", "Click here change password")

                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("If the button above does not work, copy and paste the entire link below into your browser.")
                                                    HtmlEmail.AddCustomRow(String.Format("<div style='margin: 10px; padding: 20px; width: 450px; border: 1px solid gray !important; word-break: break-all;'><span style='word-break: break-all;'>{0}</span></div>", URL))
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("If you did not request a password reset, please disregard this email.")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("Please note that your password will not change unless you click the button or link above and create a new one.  This link will expire in " & AdvantageFramework.Security.Password.PasswordFormExpireMinutes & " minutes.  If your link has expired, you can always request another.")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("If you’ve received multiple reset emails, please make sure you click on the link inside the most recent email.")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("This is an automated message. Please do not reply to this email. If you need additional help, please email <a href=""mailto:support@gotoadvantage.com"">support@gotoadvantage.com</a>.")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddCustomRow("<span style ='font-size:8.0px'>This message contains information that may be confidential, privileged or otherwise protected by law from disclosure. It is intended for the exclusive use of the addressee(s) and only the addressee or authorized agent of the addressee may review, copy, distribute or disclose to anyone the message or any information contained within. If you are not the addressee, please contact the sender by electronic reply and immediately delete all copies of the message. This message is not an offer capable of acceptance, does not create an obligation of any kind and no recipient may rely on this message.</span>")
                                                    HtmlEmail.AddBlankRow()
                                                    HtmlEmail.AddBlankRow()

                                                End If

                                                HtmlEmail.AddAdvantageLogoImageRow()

                                                'HtmlEmail.AddCustomRow("If you did not request this password change, please contact blah blah blah")
                                                HtmlEmail.Finish()

                                                Body = HtmlEmail.ToString

                                                Sent = AdvantageFramework.Email.Send(DbContext,
                                                                                 SecurityDbContext,
                                                                                 EmployeeEmailAddress,
                                                                                 Subject,
                                                                                 Body,
                                                                                 3,
                                                                                 Nothing,
                                                                                 True,
                                                                                 SendingEmailStatus,
                                                                                 ErrorMessage)

                                                If Sent = False Then

                                                    Try

                                                        If String.IsNullOrWhiteSpace(ErrorMessage) = True AndAlso
                                                       String.IsNullOrWhiteSpace(SendingEmailStatus.ToString) = False Then

                                                            ErrorMessage = SendingEmailStatus.ToString

                                                        End If
                                                    Catch ex As Exception
                                                        ErrorMessage = "Email failed to send."
                                                    End Try

                                                    If String.IsNullOrWhiteSpace(ErrorMessage) = False AndAlso ErrorMessage.Contains("550 5.1.1") Then

                                                        ErrorMessage = AdvantageFramework.Security.Password.BadEmailAddressMessage

                                                    End If

                                                End If

                                            Else

                                                ErrorMessage = "No valid email settings available."
                                                Sent = False

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

            Else

                Sent = False
                ErrorMessage = AdvantageFramework.Security.Password.NoEmailAddressMessage

            End If

            Return Sent

        End Function
        Public Function GeneratePasswordChangeURL(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                                  ByVal ServerName As String,
                                                  ByVal DatabaseName As String,
                                                  ByVal UserCode As String,
                                                  ByRef UserKey As String) As String

            Dim URL As New Text.StringBuilder
            Dim QueryString As New Text.StringBuilder
            Dim WebvantageURL As String = String.Empty

            Try

                UserKey = AdvantageFramework.Security.RandomAlphaStringKey(KeyLength)

                WebvantageURL = LoadWebvantageURL(DbContext).Trim()

                If String.IsNullOrWhiteSpace(WebvantageURL) = False Then

                    URL.Append(WebvantageURL)
                    URL.Append("/Account/Password")
                    URL.Append("?dl=")

                    QueryString.Append("p=")
                    QueryString.Append(Now.Second * Now.Hour)
                    QueryString.Append(Now.Month.ToString)
                    QueryString.Append("thisIsFake")
                    QueryString.Append(Now.Year.ToString)

                    QueryString.Append("&a=")
                    QueryString.Append(UserCode)

                    QueryString.Append("&r=")
                    QueryString.Append(Now.Second.ToString)
                    QueryString.Append(Now.Month.ToString)
                    QueryString.Append(Now.Hour.ToString)

                    QueryString.Append("&k=")
                    QueryString.Append(Now.Month.ToString)
                    QueryString.Append("thisIsAlsoFake")
                    QueryString.Append(Now.Year.ToString)
                    QueryString.Append(Now.Minute.ToString)

                    QueryString.Append("&e=")
                    QueryString.Append(DatabaseName)

                    QueryString.Append("&rt=")
                    QueryString.Append(ServerName)

                    QueryString.Append("&ra=")
                    QueryString.Append(Now.Day.ToString)
                    QueryString.Append("faketyFakeFakeFake")
                    QueryString.Append(Now.Hour.ToString)

                    QueryString.Append("&n=")
                    QueryString.Append(Now.Second.ToString)
                    QueryString.Append("ThisIsABunchOfFakeInfo")
                    QueryString.Append(Now.Minute.ToString)
                    QueryString.Append(Now.Second.ToString)
                    QueryString.Append(Now.Hour.ToString)

                    QueryString.Append("&jks=")
                    QueryString.Append(DateTime.Now.ToString)
                    QueryString.Append("&loie=")
                    QueryString.Append(UserKey)

                    QueryString.Append("&parker=")
                    QueryString.Append(DbContext.UserCode)

                    QueryString.Append("&tran=")
                    QueryString.Append(DbContext.ConnectionString)
                    'QueryString.Append(Now.Minute.ToString)
                    'QueryString.Append(Now.Month.ToString)
                    'QueryString.Append(Now.Day.ToString)
                    'QueryString.Append(Now.Year.ToString)
                    'QueryString.Append(Now.Hour)
                    'QueryString.Append("ThisIsTheLastBitToEndIt")

                    URL.Append(AdvantageFramework.Security.Encryption.RijndaelSimpleEncrypt(QueryString.ToString) & "X")

                End If

            Catch ex As Exception
            End Try

            Return URL.ToString

        End Function
        Public Function PasswordObjectFromQueryString(NameValueCollection As System.Collections.Specialized.NameValueCollection,
                                                      ByRef ErrorMessage As String) As AdvantageFramework.Security.Classes.Password

            Dim P As New AdvantageFramework.Security.Classes.Password

            If NameValueCollection IsNot Nothing Then

                'Dim Values As System.Collections.Specialized.NameValueCollection = System.Web.HttpUtility.ParseQueryString(QueryString)

                If NameValueCollection IsNot Nothing AndAlso NameValueCollection.AllKeys.Count > 0 Then

                    For Each Key As String In NameValueCollection.AllKeys

                        Select Case Key
                            Case "rt"

                                P.ServerName = NameValueCollection.Item(Key)

                            Case "e"

                                P.DatabaseName = NameValueCollection.Item(Key)

                            Case "a"

                                P.UserCode = NameValueCollection.Item(Key)

                            Case "loie"

                                P.Key = NameValueCollection.Item(Key)

                            Case "jks"

                                Try

                                    P.SentDateTime = CType(NameValueCollection.Item(Key), DateTime)

                                Catch ex As Exception
                                    P.SentDateTime = Nothing
                                End Try

                            Case "tran"

                                Try

                                    P.ConnectionString = NameValueCollection.Item(Key)

                                Catch ex As Exception
                                    P.ConnectionString = String.Empty
                                End Try

                            Case "parker"

                                Try

                                    P.ConnectionUserName = NameValueCollection.Item(Key)

                                Catch ex As Exception
                                    P.ConnectionUserName = String.Empty
                                End Try

                        End Select

                    Next

                End If

            End If

            If String.IsNullOrWhiteSpace(P.ServerName) = False AndAlso
                    String.IsNullOrWhiteSpace(P.DatabaseName) = False AndAlso
                    String.IsNullOrWhiteSpace(P.UserCode) = False AndAlso
                    String.IsNullOrWhiteSpace(P.Key) = False AndAlso
                    (P.SentDateTime IsNot Nothing AndAlso IsDate(P.SentDateTime)) Then

                P.IsValid = True

            Else

                P.IsValid = False

            End If

            Return P

        End Function
        Public Function PasswordObjectFromQueryString(ByVal QueryString As String,
                                                      ByRef ErrorMessage As String) As AdvantageFramework.Security.Classes.Password

            Dim P As New AdvantageFramework.Security.Classes.Password

            If String.IsNullOrWhiteSpace(QueryString) = False Then

                Dim Values As System.Collections.Specialized.NameValueCollection = System.Web.HttpUtility.ParseQueryString(QueryString)

                If Values IsNot Nothing AndAlso Values.AllKeys.Count > 0 Then

                    For Each Value As String In Values.AllKeys

                        Select Case Value
                            Case "rt"

                                P.ServerName = Values(Value)

                            Case "e"

                                P.DatabaseName = Values(Value)

                            Case "a"

                                P.UserCode = Values(Value)

                            Case "loie"

                                P.Key = Values(Value)

                            Case "jks"

                                Try

                                    P.SentDateTime = CType(Values(Value), DateTime)

                                Catch ex As Exception
                                    P.SentDateTime = Nothing
                                End Try

                        End Select

                    Next

                End If

            End If

            If String.IsNullOrWhiteSpace(P.ServerName) = False AndAlso
                    String.IsNullOrWhiteSpace(P.DatabaseName) = False AndAlso
                    String.IsNullOrWhiteSpace(P.UserCode) = False AndAlso
                    String.IsNullOrWhiteSpace(P.Key) = False AndAlso
                    (P.SentDateTime IsNot Nothing AndAlso IsDate(P.SentDateTime)) Then

                P.IsValid = True

            Else

                P.IsValid = False

            End If

            Return P

        End Function
        Public Function ValidateUserKey(ByVal Key As String, ByVal Value As String,
                                        ByRef VerificationKey As String, ByRef ErrorMessage As String) As Boolean

            Dim IsValid As Boolean = False
            Dim Bytes() As Byte
            Dim s As String()
            Dim UserVal As String = String.Empty
            Dim P As AdvantageFramework.Security.Classes.Password = Nothing
            Dim MinutesAlive As Long = 0

            Try

                Bytes = System.Convert.FromBase64String(Key)
                Key = System.Text.ASCIIEncoding.ASCII.GetString(Bytes)

                If String.IsNullOrWhiteSpace(Key) = False Then

                    s = Key.Split("||")

                    Select Case s.Length
                        Case 3

                            UserVal = s(1)

                        Case 5

                            UserVal = s(2)

                    End Select
                    If String.IsNullOrWhiteSpace(UserVal) = False Then

                        Value = AdvantageFramework.Web.DecryptDeepLinkString(Value)

                        P = AdvantageFramework.Security.Password.PasswordObjectFromQueryString(Value, ErrorMessage)

                        If UserVal <> P.Key Then

                            ErrorMessage = "Wrong key."
                            IsValid = False

                        Else

                            IsValid = True

                        End If
                        If IsValid = True AndAlso AdvantageFramework.Security.Password.PasswordFormExpireMinutes > 0 Then

                            MinutesAlive = DateDiff(DateInterval.Minute, CType(P.SentDateTime, DateTime), CType(Now, DateTime))

                            If MinutesAlive <= AdvantageFramework.Security.Password.PasswordFormExpireMinutes Then

                                IsValid = True

                            Else

                                ErrorMessage = "This request has expired."
                                IsValid = False

                            End If

                        End If

                    Else

                        ErrorMessage = "No user input"
                        IsValid = False

                    End If

                End If

            Catch ex As Exception
                IsValid = False
            End Try
            If IsValid = True Then

                VerificationKey = AdvantageFramework.Security.RandomAlphaStringKey(KeyLength)

            End If

            Return IsValid

        End Function

#End Region

#Region " Encryption "
        Private Function EncodeWebSafeGUID(ByVal TextGUID As String) As String

            Dim GUID As System.Guid = New System.Guid(TextGUID)

            Return EncodeWebSafeGUID(GUID)

        End Function
        Private Function EncodeWebSafeGUID(ByVal GUID As System.Guid) As String

            Dim EncodedString As String = Convert.ToBase64String(GUID.ToByteArray())

            EncodedString = EncodedString.Replace("/", "_")
            EncodedString = EncodedString.Replace("+", "-")

            Return EncodedString.Substring(0, 22)

        End Function
        Private Function DecodeWebSafeGUID(ByVal EncodedString As String) As System.Guid

            EncodedString = EncodedString.Replace("_", "/")
            EncodedString = EncodedString.Replace("-", "+")

            Dim BufferBytes As Byte() = Convert.FromBase64String(EncodedString & "==")

            Return New System.Guid(BufferBytes)

        End Function

#End Region

        Public Function ObfuscateEmailAddress(ByVal EmailAddress As String) As String

            Dim ar()
            Dim EmailUser As String = String.Empty
            Dim EmailDomain As String = String.Empty
            Dim EmailDisplay As String = String.Empty

            ar = EmailAddress.Split("@")

            If ar.Length = 2 Then

                EmailUser = ar(0)
                EmailDomain = ar(1)

                For i As Integer = 0 To EmailUser.Length - 1

                    If i > 0 AndAlso i < EmailUser.Length - 1 Then

                        EmailDisplay &= "*"

                    Else

                        EmailDisplay &= EmailUser(i)

                    End If

                Next

                EmailDisplay = EmailDisplay & "@" & EmailDomain

            End If

            Return EmailDisplay

        End Function
        Public Function UserHasPassword(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                        ByVal UserCode As String) As Boolean

            Dim HasPassword As Boolean = False
            Dim UserSqlParameter As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

            Try

                UserSqlParameter.Value = UserCode

                HasPassword = DbContext.Database.SqlQuery(Of Boolean)("SELECT CASE WHEN DATALENGTH(SU.PASSWORD) > 0 THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END " &
                                                                      " FROM SEC_USER SU WITH(NOLOCK) WHERE UPPER(SU.USER_CODE) = UPPER(@USER_CODE);", UserSqlParameter).SingleOrDefault

            Catch ex As Exception
                HasPassword = False
            End Try

            Return HasPassword

        End Function
        Public Function UserHasEmail(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                     ByVal UserCode As String) As Boolean

            Dim HasEmail As Boolean = False
            Dim UserSqlParameter As New System.Data.SqlClient.SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)

            Try

                UserSqlParameter.Value = UserCode

                HasEmail = DbContext.Database.SqlQuery(Of Boolean)("SELECT CASE WHEN E.EMP_EMAIL IS NULL OR DATALENGTH(E.EMP_EMAIL) = 0 THEN CAST(0 AS BIT) ELSE CAST(1 AS BIT) END FROM EMPLOYEE E WITH(NOLOCK) WHERE E.EMP_CODE = (SELECT TOP 1 SU.EMP_CODE FROM SEC_USER SU WITH(NOLOCK) WHERE UPPER(SU.USER_CODE) = UPPER(@USER_CODE) ORDER BY SU.SEC_USER_ID DESC);", UserSqlParameter).SingleOrDefault

            Catch ex As Exception
                HasEmail = False
            End Try

            Return HasEmail

        End Function
        Public Function LoadWebvantageURL(ByVal DbContext As AdvantageFramework.Database.DbContext) As String

            Dim URL As String = String.Empty

            Try

                URL = DbContext.Database.SqlQuery(Of String)("SELECT RTRIM(LTRIM(WEBVANTAGE_URL)) FROM AGENCY WITH(NOLOCK);").SingleOrDefault

                If String.IsNullOrWhiteSpace(URL) = False Then

                    If URL.EndsWith("/") = True Then URL = URL.Substring(0, URL.Length - 1)

                    If URL.ToLower.StartsWith("http://") = False AndAlso URL.ToLower.StartsWith("https://") = False Then

                        URL = "http://" & URL

                    End If

                End If

            Catch ex As Exception
                URL = String.Empty
            End Try

            Return URL.Trim()

        End Function
        Public Function LoadWebvantageURLFromSecurityContext(ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext) As String

            Dim URL As String = String.Empty

            Try

                URL = SecurityDbContext.Database.SqlQuery(Of String)("SELECT RTRIM(LTRIM(WEBVANTAGE_URL)) FROM AGENCY WITH(NOLOCK);").SingleOrDefault

                If String.IsNullOrWhiteSpace(URL) = False Then

                    If URL.EndsWith("/") = True Then URL = URL.Substring(0, URL.Length - 1)

                    If URL.ToLower.StartsWith("http://") = False AndAlso URL.ToLower.StartsWith("https://") = False Then

                        URL = "http://" & URL

                    End If

                End If

            Catch ex As Exception
                URL = String.Empty
            End Try

            Return URL.Trim()

        End Function
        Public Function InsertNewPasswordHistory(SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                                 User As AdvantageFramework.Security.Database.Entities.User) As Boolean

            Dim PasswordHistory As AdvantageFramework.Security.Database.Entities.PasswordHistory = Nothing

            PasswordHistory = New AdvantageFramework.Security.Database.Entities.PasswordHistory

            PasswordHistory.UserCode = User.UserCode
            PasswordHistory.StartDate = Today.Date
            PasswordHistory.Password = User.Password

            Return AdvantageFramework.Security.Database.Procedures.PasswordHistory.Insert(SecurityDbContext, PasswordHistory)

        End Function

#Region " Private "



#End Region

#End Region

    End Module

End Namespace
