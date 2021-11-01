Imports System.Data
Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions

<Serializable()> Public Structure cUser
    Public EmployeeName As String
    Public EmployeeCode As String
    Public TaskCalAccess As Boolean
    Public TimeEntryOnly As Boolean
    Public Admin As Boolean
End Structure

<Serializable()> Public Class cSecurity
    Private mConnString As String = ""
    Dim oSql As SqlHelper

    Public Shared Function DeleteCacheDependencyFile(ByVal Key As String, Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            If Key.Trim() <> "" Then
                Dim CacheDependencyDirectory As String = ""
                Dim CacheDependencyFile As String = ""
                Try

                    If System.Configuration.ConfigurationManager.AppSettings("CacheDependencyDirectory").ToString().Trim() = "" Then
                        CacheDependencyDirectory = "CacheDependency"
                    End If

                    CacheDependencyDirectory = AdvantageFramework.StringUtilities.AppendTrailingCharacter(CacheDependencyDirectory, "\")

                    If CacheDependencyDirectory.IndexOf(":\") = -1 And CacheDependencyDirectory.IndexOf("\\") = -1 Then 'not a full path or UNC path, stick it under WV

                        CacheDependencyDirectory = HttpContext.Current.Server.MapPath("~\") & CacheDependencyDirectory

                    End If

                    If CacheDependencyDirectory.Trim = "\" Then

                        CacheDependencyDirectory = ""

                    End If

                Catch ex As Exception
                    CacheDependencyDirectory = ""
                End Try
                If CacheDependencyDirectory <> "" Then
                    If Directory.Exists(CacheDependencyDirectory) = True Then
                        CacheDependencyFile = CacheDependencyDirectory & Key & ".txt"
                        Try
                            If File.Exists(CacheDependencyFile) Then
                                File.Delete(CacheDependencyFile)
                            End If
                        Catch ex As Exception
                            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
                            Return False
                        End Try
                    End If
                End If
            End If
            ErrorMessage = ""
            Return True
        Catch ex As Exception
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function

    'Please keep these 2functions as "direct to the database" as possible, we just need that one value from the db and this fn has to get called on every page, it needs to be as fast and simple as possible
    'thank you
    Public Overloads Function ValidSessionId(ByRef Message As AdvantageFramework.Security.ErrorMessages.SystemMessageType, ByRef DBSessionId As String, ByRef CurrSessionId As String) As Boolean
        If HttpContext.Current.Session("ConnString") Is Nothing Then
            Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoConnString
            Return False
        End If
        Try
            Dim SavedWebId As String = ""

            If HttpContext.Current.Session("UserGUID") IsNot Nothing Then 'Client Portal Mode

                Try
                    SavedWebId = SqlHelper.ExecuteScalar(HttpContext.Current.Session("ConnString"), CommandType.Text, "SELECT ISNULL(WEB_ID,'') FROM CP_USER WITH(NOLOCK) WHERE USER_GUID = " & _
                                                         HttpContext.Current.Session("UserGUID") & ";")
                Catch ex As Exception
                    SavedWebId = ""
                End Try

            Else 'Webvantage Mode

                'If HttpContext.Current.Session("SecUserId") Is Nothing Then
                '    Message = ValidateSessionMessage.NoSecUserId
                '    Return False
                'End If

                Try
                    If Not HttpContext.Current.Session("SecUserId") Is Nothing Then
                        SavedWebId = SqlHelper.ExecuteScalar(HttpContext.Current.Session("ConnString"), CommandType.Text, "SELECT ISNULL(WEB_ID,'') FROM SEC_USER WITH(NOLOCK) WHERE SEC_USER_ID = " & _
                                                                   HttpContext.Current.Session("SecUserId") & ";")
                    End If
                Catch ex As Exception
                    SavedWebId = ""
                End Try

            End If

            DBSessionId = SavedWebId.Trim()

            If CurrSessionId = "" Then
                Try
                    CurrSessionId = HttpContext.Current.Session("CurrentSessionId")
                Catch ex As Exception
                    CurrSessionId = ""
                End Try
            End If

            'If CurrSessionId = "" Then
            '    Try
            '        CurrSessionId = HttpContext.Current.Session.SessionID
            '    Catch ex As Exception
            '        CurrSessionId = ""
            '    End Try
            'End If

            If CurrSessionId = "" Or DBSessionId = "" Then
                Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage
                Return True
            Else
                If DBSessionId = CurrSessionId Then
                    Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage
                    Return True
                Else
                    Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.SessionIdMismatch
                    Return False
                End If
            End If

        Catch ex As Exception
            Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage
            Return True
        End Try
    End Function
    'Public Function ValidLicenseKey(ByRef Message As AdvantageFramework.Security.ErrorMessages.SystemMessageType, ByVal KeyId As Integer) As Boolean
    '    If HttpContext.Current.Session("ConnString") Is Nothing Then
    '        Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.NoConnString
    '        Return False
    '    End If
    '    Try
    '        Dim i As Integer = SqlHelper.ExecuteScalar(HttpContext.Current.Session("ConnString"), CommandType.Text, "IF EXISTS (SELECT 1 FROM AULU WITH(NOLOCK) WHERE AULU_ID = " & KeyId.ToString() & ") BEGIN SELECT 1 END ELSE SELECT 0;")
    '        If i = 1 Then
    '            Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage
    '            Return True
    '        Else
    '            Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.InvalidUserLicense
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Message = AdvantageFramework.Security.ErrorMessages.SystemMessageType.DefaultMessage
    '        Return True
    '    End Try
    'End Function

    Public Function HasClientRestrictions(ByVal UserID As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "HasClientRestrictions" & UserID

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim intReturn As Integer = 0
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID

            Try
                intReturn = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_get_client_restrictions", parameterUserID)
            Catch
                Err.Raise(Err.Number, "cSecurity:HasClientRestrictions", Err.Description)
            End Try

            If intReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function

    Public Function HasEmployeeRestrictions(ByVal UserID As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "HasEmployeeRestrictions" & UserID

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim intReturn As Integer = 0
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID

            Try
                intReturn = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_get_emp_restrictions", parameterUserID)
            Catch
                Err.Raise(Err.Number, "cSecurity:HasEmployeeRestrictions", Err.Description)
            End Try

            If intReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function

    Public Function GetEmpSecurity(ByVal UserID As String) As Integer
        Dim SessionKey As String = "GetEmpSecurity" & UserID
        Dim countReturn As Integer = 0

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID

            Try
                countReturn = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_emp_security", parameterUserID)
            Catch
                Err.Raise(Err.Number, "cSecurity:GetEmpSecurity", Err.Description)
            End Try

            HttpContext.Current.Session(SessionKey) = countReturn
        Else
            countReturn = CType(HttpContext.Current.Session(SessionKey), Integer)
        End If

        Return countReturn

    End Function

    Public Function CheckEmployees(ByVal UserID As String, ByVal empcode As String, Optional ByVal ShowAll As Boolean = False, Optional ByVal FromTS As Boolean = False) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "CheckEmployees" & UserID & empcode & ShowAll.ToString()

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim dr As SqlDataReader
            Dim d As New cDropDowns(Me.mConnString)
            dr = d.GetEmployees(UserID, False, False, FromTS)

            Do While dr.Read
                If dr.GetString(0) = empcode Then
                    IsValid = True
                End If
            Loop
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function

    Public Function CheckManagers(ByVal UserID As String, ByVal empcode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "CheckManagers" & UserID & empcode

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim dr As SqlDataReader

            Dim parameterUserID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
            parameterUserID.Value = UserID

            Try
                dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetManagers", parameterUserID)
            Catch
                Err.Raise(Err.Number, "Class:cDropDowns Routine:CheckManagers", Err.Description)
            End Try

            Do While dr.Read
                If dr.GetString(0) = empcode Then
                    IsValid = True
                End If
            Loop

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid
    End Function

    Public Function GetVendorContactSecurity(ByVal user As String) As String
        Dim SessionKey As String = "GetVendorContactSecurity" & user
        Dim vc As String = ""

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim arParams(1) As SqlParameter

                Dim paramUser As New SqlParameter("@UserID", SqlDbType.VarChar)
                paramUser.Value = user
                arParams(0) = paramUser

                vc = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_security_vendorcontact", arParams)

            Catch ex As Exception
                Err.Raise(Err.Number, "Error Getvendorcontact!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString())
            End Try

            HttpContext.Current.Session(SessionKey) = vc
        Else
            vc = HttpContext.Current.Session(SessionKey).ToString()
        End If

        Return vc
    End Function

#Region "Application Security"

    Public Function UserHasOfficeRestrictions(ByVal EmpCode As String, Optional ByRef AllowedOffices As String = "") As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "UserHasOfficeRestrictions" & EmpCode & AllowedOffices

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Try
                Dim dt As New DataTable
                dt = oSql.ExecuteDataTable(mConnString, CommandType.Text, "SELECT OFFICE_CODE FROM EMP_OFFICE WITH(NOLOCK) WHERE EMP_CODE = '" & EmpCode & "';", "DtAllowedOffices")
                If dt.Rows.Count > 0 Then
                    Dim sb As New System.Text.StringBuilder
                    For i As Integer = 0 To dt.Rows.Count - 1
                        With sb
                            .Append("'")
                            .Append(dt.Rows(i)("OFFICE_CODE").ToString())
                            .Append("',")
                        End With
                    Next
                    AllowedOffices = MiscFN.RemoveTrailingDelimiter(sb.ToString(), ",")
                    IsValid = True
                Else
                    AllowedOffices = "" 'allow all
                    IsValid = False
                End If
            Catch ex As Exception
                AllowedOffices = "" 'allow all
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

#End Region

#Region "Client Portal Security"
    Public Function getUsersCP(Optional ByVal client As String = "") As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterclientID As New SqlParameter("@ClientCode", SqlDbType.VarChar)
        parameterclientID.Value = client

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_CPUsers", parameterclientID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsers", Err.Description)
        End Try

        Return dr
    End Function
    Public Function getUsersCPData(ByVal UserCode As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterUserID.Value = UserCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_CPUsersData", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsers", Err.Description)
        End Try

        Return dr
    End Function
    Public Function getUsersCPDataCDP(ByVal UserCode As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterUserID.Value = UserCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_CPUsersDataCDP", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsers", Err.Description)
        End Try

        Return dr
    End Function
    Public Function getUsersCPDataCDPClient(ByVal UserCode As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterUserID.Value = UserCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_getCPUsersClient", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsers", Err.Description)
        End Try

        Return dr
    End Function
    Public Function getUsersCPDesktopObjects(ByVal UserCode As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterUserID.Value = UserCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_CPUsersDesktopObjects", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsersDesktopObjects", Err.Description)
        End Try

        Return dr
    End Function
    Public Function getUsersCPApplications(ByVal UserCode As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterUserID.Value = UserCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_CPUsersApplications", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsersDesktopObjects", Err.Description)
        End Try

        Return dr
    End Function
    Public Function getCPUsers(ByVal ClCode As String) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterClCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClCode.Value = ClCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_getCPUsers", parameterClCode)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsersDesktopObjects", Err.Description)
        End Try

        Return dr
    End Function
    Public Function getCPUsersData(ByVal CDPID As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterCDPCode As New SqlParameter("CDPID", SqlDbType.Int)
        parameterCDPCode.Value = CDPID

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_getCPUsersData", parameterCDPCode)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsersDesktopObjects", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetApplicationsCP(ByVal UserID As Integer) As SqlDataReader
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterUserID.Value = UserID

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetApplications", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetApplications", Err.Description)
        End Try

        Return dr
    End Function
    Public Function addNewUserCP(ByVal fname As String, _
                                 ByVal uname As String, _
                                 ByVal ucode As String, _
                                 ByVal password As String, _
                                 ByVal email As String, _
                                 ByVal empcode As String, _
                                 ByVal theme As String, _
                                 ByVal template As Integer, _
                                 ByVal admin As Boolean, _
                                 ByVal clcode As String, _
                                 ByVal alertgroup As String, _
                                 ByVal contactcode As String) As Boolean

        Dim cpuser As Boolean = True
        Dim arParams(19) As SqlParameter

        Dim parameterUserName As New SqlParameter("@UserName", SqlDbType.VarChar, 100)
        parameterUserName.Value = uname
        arParams(0) = parameterUserName

        Dim parameterLoweredUserName As New SqlParameter("@LoweredUsername", SqlDbType.VarChar, 100)
        parameterLoweredUserName.Value = uname.ToLower
        arParams(1) = parameterLoweredUserName

        Dim parameterFullName As New SqlParameter("@FullName", SqlDbType.VarChar, 100)
        parameterFullName.Value = fname
        arParams(2) = parameterFullName

        Dim parameterPassHash As New SqlParameter("@PassHash", SqlDbType.VarChar, 44)
        parameterPassHash.Value = password
        arParams(3) = parameterPassHash

        Dim parameterLastLogin As New SqlParameter("@LastLogin", SqlDbType.DateTime, 24)
        parameterLastLogin.Value = Now
        arParams(4) = parameterLastLogin

        Dim parameterApprovedbyEmpCode As New SqlParameter("@CreatedbyEmpCode", SqlDbType.VarChar, 6)
        parameterApprovedbyEmpCode.Value = empcode
        arParams(5) = parameterApprovedbyEmpCode

        Dim parameterApprovedTime As New SqlParameter("@CreatedTime", SqlDbType.DateTime, 24)
        parameterApprovedTime.Value = Now
        arParams(6) = parameterApprovedTime

        Dim parameterIsLocked As New SqlParameter("@IsLocked", SqlDbType.Bit, 1)
        parameterIsLocked.Value = 0
        arParams(7) = parameterIsLocked

        Dim parameterEmail As New SqlParameter("@Email", SqlDbType.VarChar, 100)
        parameterEmail.Value = email
        arParams(8) = parameterEmail

        Dim parameterLoginTryCount As New SqlParameter("@LoginTryCount", SqlDbType.SmallInt, 2)
        parameterLoginTryCount.Value = 0
        arParams(9) = parameterLoginTryCount

        Dim parameterUnlockTime As New SqlParameter("@UnlockTime", SqlDbType.DateTime, 24)
        parameterUnlockTime.Value = Nothing
        arParams(10) = parameterUnlockTime

        Dim parameterMustChangePassword As New SqlParameter("@MustChangePassword", SqlDbType.Bit, 1)
        parameterMustChangePassword.Value = 0
        arParams(11) = parameterMustChangePassword

        Dim parameterTheme As New SqlParameter("@Theme", SqlDbType.VarChar, 20)
        parameterTheme.Value = theme
        arParams(12) = parameterTheme

        Dim parameterUserCode As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterUserCode.Value = ucode
        arParams(13) = parameterUserCode

        Dim parameterTemplate As New SqlParameter("@Template", SqlDbType.Int, 2)
        parameterTemplate.Value = template
        arParams(14) = parameterTemplate

        Dim parameterAdmin As New SqlParameter("@Admin", SqlDbType.Bit, 1)
        parameterAdmin.Value = admin
        arParams(15) = parameterAdmin

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = clcode
        arParams(16) = parameterClientCode

        Dim parameterAlertGroup As New SqlParameter("@AlertGroup", SqlDbType.VarChar, 50)
        parameterAlertGroup.Value = alertgroup
        arParams(17) = parameterAlertGroup

        Dim parameterContactCode As New SqlParameter("@ContactCode", SqlDbType.VarChar, 6)
        parameterContactCode.Value = contactcode
        arParams(18) = parameterContactCode

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_user_new", arParams)
        Catch
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            cpuser = False
        End Try

        If cpuser = False Then
            Return False
        End If

        Return True
    End Function
    Public Function addNewUserCPcdp(ByVal ucode As String, _
                                 ByVal client As String, _
                                 ByVal division As String, _
                                 ByVal product As String) As Boolean

        Dim cpsecclient As Boolean = True
        Dim arParams2(4) As SqlParameter
        Dim dr As SqlDataReader
        Dim dr2 As SqlDataReader

        Dim parameterUserCode As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterUserCode.Value = ucode
        arParams2(0) = parameterUserCode

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = client
        arParams2(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        parameterDivisionCode.Value = division
        arParams2(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = product
        arParams2(3) = parameterProductCode

        'If division = "%" Or product = "%" Then
        'dr = getCDPByDivision(client, division, product)
        dr = Me.getCPUsersData(CInt(ucode))
        'End If

        If dr.HasRows Then
            Do While dr.Read
                dr2 = getCDPByDivision(dr.GetString(3), dr.GetString(4), dr.GetString(5))
                If dr2.HasRows Then
                    Do While dr2.Read
                        Dim dup As Boolean = CheckUserCDPDuplication(CInt(ucode), dr2.GetString(0), dr2.GetString(1), dr2.GetString(2))
                        If dup = False Then
                            parameterClientCode.Value = dr2.GetString(0)
                            arParams2(1) = parameterClientCode
                            parameterDivisionCode.Value = dr2.GetString(1)
                            arParams2(2) = parameterDivisionCode
                            parameterProductCode.Value = dr2.GetString(2)
                            arParams2(3) = parameterProductCode
                            Try
                                oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_userCDP_new", arParams2)
                            Catch
                                'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
                                cpsecclient = False
                            End Try
                        End If
                    Loop
                Else
                    Dim dup2 As Boolean = CheckUserCDPDuplication(CInt(ucode), dr.GetString(3), dr.GetString(4), dr.GetString(5))
                    If dup2 = False Then
                        parameterClientCode.Value = dr.GetString(3)
                        arParams2(1) = parameterClientCode
                        parameterDivisionCode.Value = dr.GetString(4)
                        arParams2(2) = parameterDivisionCode
                        parameterProductCode.Value = dr.GetString(5)
                        arParams2(3) = parameterProductCode
                        Try
                            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_userCDP_new", arParams2)
                        Catch ex As Exception
                            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
                            cpsecclient = False
                        End Try
                    End If
                End If

            Loop
        Else
            'Dim dup2 As Boolean = CheckUserCDPDuplication(ucode, client, division, product)
            'If dup2 = False Then
            '    Try
            '        oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_userCDP_new", arParams2)
            '    Catch
            '        'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            '        cpsecclient = False
            '    End Try
            'End If
        End If
        dr.Close()

        If cpsecclient = False Then
            Return False
        End If

        Return True
    End Function
    Public Function updateUserCP(ByVal fname As String, _
                                  ByVal uname As String, _
                                  ByVal ucode As String, _
                                  ByVal password As String, _
                                  ByVal email As String, _
                                  ByVal empcode As String, _
                                  ByVal theme As String, _
                                  ByVal template As Integer, _
                                  ByVal admin As Boolean, _
                                  ByVal clcode As String, _
                                  ByVal alertgroup As String, _
                                  ByVal contactcode As String) As Boolean

        Dim cpuser As Boolean = True
        Dim arParams(12) As SqlParameter


        Dim parameterUserName As New SqlParameter("@UserName", SqlDbType.VarChar, 100)
        parameterUserName.Value = uname
        arParams(0) = parameterUserName

        Dim parameterLoweredUserName As New SqlParameter("@LoweredUsername", SqlDbType.VarChar, 100)
        parameterLoweredUserName.Value = uname.ToLower
        arParams(1) = parameterLoweredUserName

        Dim parameterFullName As New SqlParameter("@FullName", SqlDbType.VarChar, 100)
        parameterFullName.Value = fname
        arParams(2) = parameterFullName

        Dim parameterPassHash As New SqlParameter("@PassHash", SqlDbType.VarChar, 44)
        parameterPassHash.Value = password
        arParams(3) = parameterPassHash

        'Dim parameterLastLogin As New SqlParameter("@LastLogin", SqlDbType.DateTime, 24)
        'parameterLastLogin.Value = Now
        'arParams(5) = parameterLastLogin

        'Dim parameterIsApproved As New SqlParameter("@IsApproved", SqlDbType.Bit, 1)
        'parameterIsApproved.Value = 1
        'arParams(6) = parameterIsApproved

        'Dim parameterApprovedbyEmpCode As New SqlParameter("@ApprovedbyEmpCode", SqlDbType.VarChar, 6)
        'parameterApprovedbyEmpCode.Value = empcode
        'arParams(7) = parameterApprovedbyEmpCode

        'Dim parameterApprovedTime As New SqlParameter("@ApprovedTime", SqlDbType.DateTime, 24)
        'parameterApprovedTime.Value = Now
        'arParams(8) = parameterApprovedTime

        'Dim parameterIsLocked As New SqlParameter("@IsLocked", SqlDbType.Bit, 1)
        'parameterIsLocked.Value = 0
        'arParams(9) = parameterIsLocked

        Dim parameterEmail As New SqlParameter("@Email", SqlDbType.VarChar, 100)
        parameterEmail.Value = email
        arParams(4) = parameterEmail

        'Dim parameterLoginTryCount As New SqlParameter("@LoginTryCount", SqlDbType.SmallInt, 2)
        'parameterLoginTryCount.Value = 0
        'arParams(11) = parameterLoginTryCount

        'Dim parameterUnlockTime As New SqlParameter("@UnlockTime", SqlDbType.DateTime, 24)
        'parameterUnlockTime.Value = Nothing
        'arParams(12) = parameterUnlockTime

        'Dim parameterMustChangePassword As New SqlParameter("@MustChangePassword", SqlDbType.Bit, 1)
        'parameterMustChangePassword.Value = 0
        'arParams(13) = parameterMustChangePassword

        Dim parameterTheme As New SqlParameter("@Theme", SqlDbType.VarChar, 20)
        parameterTheme.Value = theme
        arParams(5) = parameterTheme

        'Dim parameterSoundOn As New SqlParameter("@SoundOn", SqlDbType.Bit, 1)
        'parameterSoundOn.Value = 1
        'arParams(15) = parameterSoundOn

        Dim parameterCDPCode As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterCDPCode.Value = ucode
        arParams(6) = parameterCDPCode

        Dim parameterTemplate As New SqlParameter("@Template", SqlDbType.Int, 2)
        parameterTemplate.Value = template
        arParams(7) = parameterTemplate

        Dim parameterAdmin As New SqlParameter("@Admin", SqlDbType.Bit, 1)
        parameterAdmin.Value = admin
        arParams(8) = parameterAdmin

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = clcode
        arParams(9) = parameterClientCode

        Dim parameterAlertGroup As New SqlParameter("@AlertGroup", SqlDbType.VarChar, 50)
        parameterAlertGroup.Value = alertgroup
        arParams(10) = parameterAlertGroup

        Dim parameterContactCode As New SqlParameter("@ContactCode", SqlDbType.VarChar, 6)
        parameterContactCode.Value = contactcode
        arParams(11) = parameterContactCode

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_user_update", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserUpdate", Err.Description)
            cpuser = False
        End Try

        If cpuser = False Then
            Return False
        End If

        Return True
    End Function
    Public Function updateUserCPcdp(ByVal ucode As String, _
                                  ByVal client As String, _
                                  ByVal division As String, _
                                  ByVal product As String) As Boolean

        Dim cpsecclient As Boolean = True
        Dim arParams2(4) As SqlParameter

        Dim parameterUserCode As New SqlParameter("@UserCode", SqlDbType.VarChar, 6)
        parameterUserCode.Value = ucode
        arParams2(0) = parameterUserCode

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = client
        arParams2(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If division = "%" Then
            parameterDivisionCode.Value = DBNull.Value
        Else
            parameterDivisionCode.Value = division
        End If
        arParams2(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If product = "%" Then
            parameterProductCode.Value = DBNull.Value
        Else
            parameterProductCode.Value = product
        End If
        arParams2(3) = parameterProductCode

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_userCDP_update", arParams2)
        Catch
            Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserUpdate", Err.Description)
            cpsecclient = False
        End Try

        If cpsecclient = False Then
            Return False
        End If

        Return True
    End Function
    Public Function updateUserCPLock(ByVal ucode As String, ByVal locked As Boolean) As Boolean

        Dim cpuser As Boolean = True
        Dim arParams(4) As SqlParameter

        Dim parameterCDPCode As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterCDPCode.Value = ucode
        arParams(0) = parameterCDPCode

        Dim parameterIsLocked As New SqlParameter("@IsLocked", SqlDbType.Bit, 1)
        If locked = False Then
            parameterIsLocked.Value = 0
        Else
            parameterIsLocked.Value = 1
        End If
        arParams(1) = parameterIsLocked

        Dim parameterLoginTryCount As New SqlParameter("@LoginTryCount", SqlDbType.SmallInt, 2)
        parameterLoginTryCount.Value = 0
        arParams(2) = parameterLoginTryCount

        Dim parameterUnlockTime As New SqlParameter("@UnlockTime", SqlDbType.DateTime, 24)
        parameterUnlockTime.Value = Nothing
        arParams(3) = parameterUnlockTime

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_user_update_lock", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserUpdate", Err.Description)
            cpuser = False
        End Try

        If cpuser = False Then
            Return False
        End If

        Return True
    End Function
    Public Function deleteUserCP(ByVal usercode As String) As Boolean

        Dim cpuser As Boolean = True
        Dim parameterCDPCode As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterCDPCode.Value = usercode

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_user_delete", parameterCDPCode)
        Catch
            Err.Raise(Err.Number, "Class:cTaskCal Routine:UserDelete", Err.Description)
            cpuser = False
        End Try

        If cpuser = False Then
            Return False
        End If

        Return True
    End Function
    Public Function deleteUserCPcdp(ByVal usercode As String, ByVal client As String, ByVal division As String, ByVal product As String) As Boolean

        Dim arParams(4) As SqlParameter
        Dim cpsecclient As Boolean = True

        Dim parameterUserCode As New SqlParameter("@UserCode", SqlDbType.VarChar, 6)
        parameterUserCode.Value = usercode
        arParams(0) = parameterUserCode

        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
        parameterClientCode.Value = client
        arParams(1) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
        If division = "" Then
            parameterDivisionCode.Value = DBNull.Value
        Else
            parameterDivisionCode.Value = division
        End If
        arParams(2) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
        If product = "" Then
            parameterProductCode.Value = DBNull.Value
        Else
            parameterProductCode.Value = product
        End If
        arParams(3) = parameterProductCode

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_userCDP_delete", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cTaskCal Routine:UsersDelete", Err.Description)
            cpsecclient = False
        End Try

        If cpsecclient = False Then
            Return False
        End If

        Return True
    End Function
    Public Function settingsLogoCP(ByVal path As String) As Boolean

        Dim cppath As Boolean = True
        Dim arParams2(1) As SqlParameter
        Dim dr As SqlDataReader

        Dim parameterPath As New SqlParameter("@Path", SqlDbType.VarChar, 254)
        parameterPath.Value = path
        'arParams2(0) = parameterPath


        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_logoPath", parameterPath)
        Catch
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            cppath = False
        End Try

        If cppath = False Then
            Return False
        End If

        Return True
    End Function
    Public Function settingsCP(ByVal wvfolder As String, ByVal cpfolder As String) As Boolean

        Dim cpsettings As Boolean = True
        Dim arParams(2) As SqlParameter
        Dim dr As SqlDataReader

        Dim parameterWVFolder As New SqlParameter("@WVFolder", SqlDbType.VarChar, 100)
        parameterWVFolder.Value = wvfolder
        arParams(0) = parameterWVFolder

        Dim parameterCPFolder As New SqlParameter("@CPFolder", SqlDbType.VarChar, 100)
        parameterCPFolder.Value = cpfolder
        arParams(1) = parameterCPFolder


        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_cp_settings", arParams)
        Catch
            'Err.Raise(Err.Number, "Class:cTaskCal Routine:CPUserNew", Err.Description)
            cpsettings = False
        End Try

        If cpsettings = False Then
            Return False
        End If

        Return True
    End Function
    Public Function getlogoPathCP(ByVal ucode As String) As String

        Dim path As String
        'Dim arParams2(2) As SqlParameter
        Dim dr As SqlDataReader

        Dim parameterUserCode As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterUserCode.Value = ucode
        'arParams2(0) = parameterUserCode

        Try
            path = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_cp_getLogoPath", parameterUserCode)
        Catch
            Err.Raise(Err.Number, "cSecurity:GetEmpSecurity", Err.Description)
        End Try

        Return path
    End Function
    Public Function CheckUserCodeDuplication(ByVal usercode As Integer)
        Dim dr As SqlDataReader

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_GetUserCodes")
        Catch
            Err.Raise(Err.Number, "Class:cSecurity Routine:CheckUserCodes", Err.Description)
        End Try

        Do While dr.Read
            If dr.GetInt32(0) = usercode Then
                Return True
            End If
        Loop

        Return False
    End Function
    Public Function CheckUserNameDuplication(ByVal username As String)
        Dim dr As SqlDataReader

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_GetUserNames")
        Catch
            Err.Raise(Err.Number, "Class:cSecurity Routine:CheckUserNames", Err.Description)
        End Try

        Do While dr.Read
            If dr.GetString(0).Trim = username.Trim Then
                Return True
            End If
        Loop

        Return False
    End Function
    Public Function CheckUserCDPDuplication(ByVal UserCode As Integer, _
                                             ByVal client As String, _
                                             ByVal division As String, _
                                             ByVal product As String)
        Dim dr As SqlDataReader

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@CDPCode", SqlDbType.Int)
        parameterUserID.Value = UserCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_duplicationCDP", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCPUsers", Err.Description)
        End Try

        Do While dr.Read
            If dr.GetString(0) = client And dr.GetString(1) = division And dr.GetString(2) = product Then
                Return True
            End If
        Loop

        Return False
    End Function
    Public Function CheckUserName(ByVal userid As Integer, ByVal username As String)
        Dim dr As SqlDataReader

        Dim parameterUserID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterUserID.Value = userid

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_GetUserName", parameterUserID)
        Catch
            Err.Raise(Err.Number, "Class:cSecurity Routine:CheckUserName", Err.Description)
        End Try

        Do While dr.Read
            If dr.GetString(0).Trim = username.Trim Then
                Return True
            End If
        Loop

        Return False
    End Function
    Public Function getCDPByDivision(ByVal client As String, ByVal division As String, ByVal product As String)
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter
        '*** Create Parameters
        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClient.Value = client
        arParams(0) = parameterClient

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        If division = "" Then
            parameterDivision.Value = "%"
        Else
            parameterDivision.Value = division
        End If
        arParams(1) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        If product = "" Then
            parameterProduct.Value = "%"
        Else
            parameterProduct.Value = product
        End If
        arParams(2) = parameterProduct

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_dd_GetCDPs", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetCDPs", Err.Description)
        End Try

        Return dr
    End Function
    'Public Function getAgencyEmps(ByVal UserID As String, Optional ByVal ShowAll As Boolean = False) As SqlDataReader
    '    Dim dr As SqlDataReader

    '    '*** Create Parameters
    '    Dim arP(2) As SqlParameter
    '    Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
    '    parameterUserID.Value = UserID
    '    arP(0) = parameterUserID

    '    Dim parameterShowAll As New SqlParameter("@SHOW_ALL", SqlDbType.SmallInt)
    '    If ShowAll = True Then
    '        parameterShowAll.Value = 1
    '    ElseIf ShowAll = False Then
    '        parameterShowAll.Value = 0
    '    End If
    '    arP(1) = parameterShowAll

    '    Try
    '        dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEmpCodes", arP)
    '    Catch
    '        Err.Raise(Err.Number, "Class:cDropDowns Routine:CheckEmployees", Err.Description)
    '    End Try

    '    Return dr
    'End Function
    Public Function getAlertGroups(Optional ByVal strEmpCode As String = "") As SqlDataReader
        Dim dr As SqlDataReader

        Dim parameterProductCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterProductCode.Value = strEmpCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_dd_GetEmailGroups", parameterProductCode)
        Catch
            Err.Raise(Err.Number, "Class:cSecurity Routine:GetEmailGroups", Err.Description)
        End Try

        Return dr
    End Function
    Public Function getSettingsCP() As SqlDataReader
        Dim dr As SqlDataReader

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_cp_getSettings")
        Catch
            Err.Raise(Err.Number, "Class:cSecurity Routine:GetSettingsCP", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetAlertClientContact(ByVal CDPID As Integer) As String
        Dim ThisReturn As String
        Dim dr As SqlDataReader

        Dim parameterCDPID As New SqlParameter("@CDPID", SqlDbType.Int)
        parameterCDPID.Value = CDPID

        Try
            ThisReturn = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_Get_AlertClientContact", parameterCDPID)
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetCC", Err.Description)
        End Try
        'Do While dr.Read
        '    ThisReturn = dr.GetString(2)
        'Loop
        'dr.Close()
        Return ThisReturn
    End Function
    Public Function GetCPLicenseCount() As Integer
        Dim ThisReturn As Integer

        Try
            ThisReturn = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_checkCPUserLicenses")
        Catch
            Err.Raise(Err.Number, "Class:cAlerts Routine:GetCC", Err.Description)
        End Try
        'Do While dr.Read
        '    ThisReturn = dr.GetString(2)
        'Loop
        'dr.Close()
        Return ThisReturn
    End Function

    Public Function SaveBinaryImageCP(ByVal client As String, ByVal logo As Byte(), ByVal picture As Byte(), ByVal wp As String, ByVal sc As String, ByVal theme As String, ByVal background As String)
        Dim arParams(7) As SqlParameter

        Dim parameterID As New SqlParameter("@BINARY_IMAGE_CLIENT", SqlDbType.VarChar)
        parameterID.Value = client
        arParams(0) = parameterID

        Dim parameterValue As New SqlParameter("@BINARY_IMAGE_LOGO", SqlDbType.Image)
        parameterValue.Value = logo
        arParams(1) = parameterValue

        Dim parameterPicture As New SqlParameter("@BINARY_IMAGE_WP", SqlDbType.Image)
        parameterPicture.Value = picture
        arParams(2) = parameterPicture

        Dim parameterWP As New SqlParameter("@BINARY_IMAGE_WV_WP", SqlDbType.VarChar)
        If wp = "" Then
            parameterWP.Value = DBNull.Value
        Else
            parameterWP.Value = wp
        End If
        arParams(3) = parameterWP

        Dim parameterSC As New SqlParameter("@BINARY_IMAGE_WV_SC", SqlDbType.VarChar)
        If sc = "" Then
            parameterSC.Value = DBNull.Value
        Else
            parameterSC.Value = sc
        End If
        arParams(4) = parameterSC

        Dim parameterTheme As New SqlParameter("@BINARY_IMAGE_WV_THEME", SqlDbType.VarChar)
        If theme = "" Then
            parameterTheme.Value = DBNull.Value
        Else
            parameterTheme.Value = theme
        End If
        arParams(5) = parameterTheme

        Dim parameterBackGround As New SqlParameter("@BINARY_BACKGROUND", SqlDbType.VarChar)
        If background = "" Then
            parameterBackGround.Value = DBNull.Value
        Else
            parameterBackGround.Value = background
        End If
        arParams(6) = parameterBackGround

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_SaveCPImageSettings", arParams)
        Catch
            Return ""
        End Try

        Return ""

    End Function

    Public Function GetBinaryImageCP(ByVal ID As String)
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter

        Dim parameterID As New SqlParameter("@BINARY_IMAGE_CLIENT", SqlDbType.VarChar)
        parameterID.Value = ID
        arParams(0) = parameterID

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetCPImageSettings", arParams)
        Catch
            Return dr
        End Try

        Return dr

    End Function

    Public Function GetCPProfiles(ByVal ClCode As String) As SqlDataReader
        ' Create Instance of Connection and Command Object
        Dim arParams(1) As SqlParameter
        Dim dr As SqlDataReader

        Dim parameterCC As New SqlParameter("@ClCode", SqlDbType.VarChar, 6)
        parameterCC.Value = ClCode
        arParams(0) = parameterCC

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetCPProfileData", arParams)
        Catch
            Return dr
        End Try

        Return dr

    End Function
#End Region

    Public Shared Function Encrypt(ByVal strKey As String, ByVal strData As String) As String

        Dim strValue As String = ""

        If strKey <> "" Then
            ' convert key to 16 characters for simplicity
            Select Case Len(strKey)
                Case Is < 16
                    strKey = strKey & Left("longdivisionisexciting", 16 - Len(strKey))
                Case Is > 16
                    strKey = Left(strKey, 16)
            End Select

            ' create encryption keys
            Dim byteKey() As Byte = Encoding.UTF8.GetBytes(Left(strKey, 8))
            Dim byteVector() As Byte = Encoding.UTF8.GetBytes(Right(strKey, 8))

            ' convert data to byte array
            Dim byteData() As Byte = Encoding.UTF8.GetBytes(strData)

            ' encrypt 
            Dim objDES As New DESCryptoServiceProvider
            Dim objMemoryStream As New MemoryStream
            Dim objCryptoStream As New CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write)
            objCryptoStream.Write(byteData, 0, byteData.Length)
            objCryptoStream.FlushFinalBlock()

            ' convert to string and Base64 encode
            strValue = Convert.ToBase64String(objMemoryStream.ToArray())
        Else
            strValue = strData
        End If

        Return strValue

    End Function

    Public Shared Function Decrypt(ByVal strKey As String, ByVal strData As String) As String

        Dim strValue As String = ""

        If strKey <> "" Then
            ' convert key to 16 characters for simplicity
            Select Case Len(strKey)
                Case Is < 16
                    strKey = strKey & Left("longdivisionisexciting", 16 - Len(strKey))
                Case Is > 16
                    strKey = Left(strKey, 16)
            End Select

            ' create encryption keys
            Dim byteKey() As Byte = Encoding.UTF8.GetBytes(Left(strKey, 8))
            Dim byteVector() As Byte = Encoding.UTF8.GetBytes(Right(strKey, 8))

            ' convert data to byte array and Base64 decode
            Dim byteData(strData.Length) As Byte
            Try
                byteData = Convert.FromBase64String(strData)
            Catch ' invalid length
                strValue = strData
            End Try

            If strValue = "" Then
                Try
                    ' decrypt
                    Dim objDES As New DESCryptoServiceProvider
                    Dim objMemoryStream As New MemoryStream
                    Dim objCryptoStream As New CryptoStream(objMemoryStream, objDES.CreateDecryptor(byteKey, byteVector), CryptoStreamMode.Write)
                    objCryptoStream.Write(byteData, 0, byteData.Length)
                    objCryptoStream.FlushFinalBlock()

                    ' convert to string
                    Dim objEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
                    strValue = objEncoding.GetString(objMemoryStream.ToArray())
                Catch ' decryption error
                    strValue = ""
                End Try
            End If
        Else
            strValue = strData
        End If

        Return strValue

    End Function

    Public Shared Function FormatRemoveSQL(ByVal strSQL As String) As String

        Dim strCleanSQL As String = strSQL

        If strSQL <> Nothing Then

            Dim BadCommands As Array = Split(";,--,create,drop,select,insert,delete,update,union,sp_,xp_", ",")

            ' strip any dangerous SQL commands
            Dim intCommand As Integer
            For intCommand = 0 To BadCommands.Length - 1
                strCleanSQL = Regex.Replace(strCleanSQL, Convert.ToString(BadCommands.GetValue(intCommand)), " ", RegexOptions.IgnoreCase)
            Next

            ' convert any single quotes
            strCleanSQL = Replace(strCleanSQL, "'", "''")
        End If

        Return strCleanSQL

    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

End Class
