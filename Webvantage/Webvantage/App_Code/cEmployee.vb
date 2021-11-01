Imports System.Data.SqlClient
Imports System.Data

Public Enum AlertEmailFlag
    None = 0
    JustEmail = 1
    JustAlert = 2
    BothAlertEmail = 3
End Enum

<Serializable()> Public Class wvEmailGroup
    Dim mSelected As Boolean = False
    Dim mName As String
    Dim mEmployees As wvEmployees
    Dim mCheckBoxID As String
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal Value As String)
            mName = Value
        End Set
    End Property
    Public Property Selected() As Boolean
        Get
            Return mSelected
        End Get
        Set(ByVal Value As Boolean)
            mSelected = Value
        End Set
    End Property
    Public Property Employees() As wvEmployees
        Get
            Return mEmployees
        End Get
        Set(ByVal Value As wvEmployees)
            mEmployees = Value
        End Set
    End Property
    Public Property CheckBoxID() As String
        Get
            Return mCheckBoxID
        End Get
        Set(ByVal Value As String)
            mCheckBoxID = Value
        End Set
    End Property
End Class

<Serializable()> Public Class wvEmailGroups
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As wvEmailGroup
        Get
            Return CType(List(index), wvEmailGroup)
        End Get
        Set(ByVal Value As wvEmailGroup)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As wvEmailGroup) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As wvEmailGroup) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As wvEmailGroup)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As wvEmailGroup)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As wvEmailGroup) As Boolean
        Return List.Contains(value)
    End Function
End Class

<Serializable()> Public Class wvEmployee
    Dim mEmpCode As String
    Dim mEmployeeFullName As String
    Dim mEmail As String
    Dim mAlertEmail As AlertEmailFlag
    Dim mCheckBoxID As String
    Public Property EmpCode() As String
        Get
            Return mEmpCode
        End Get
        Set(ByVal Value As String)
            mEmpCode = Value
        End Set
    End Property
    Public Property EmployeeFullName() As String
        Get
            Return mEmployeeFullName
        End Get
        Set(ByVal Value As String)
            mEmployeeFullName = Value
        End Set
    End Property
    Public Property Email() As String
        Get
            Return mEmail
        End Get
        Set(ByVal Value As String)
            mEmail = Value
        End Set
    End Property
    Public Property AlertEmail() As AlertEmailFlag
        Get
            Return mAlertEmail
        End Get
        Set(ByVal Value As AlertEmailFlag)
            mAlertEmail = Value
        End Set
    End Property
    Public Property CheckBoxID() As String
        Get
            Return mCheckBoxID
        End Get
        Set(ByVal Value As String)
            mCheckBoxID = Value
        End Set
    End Property
End Class

<Serializable()> Public Class wvEmployees
    Inherits CollectionBase
    Default Public Property Item(ByVal index As Integer) As wvEmployee
        Get
            Return CType(List(index), wvEmployee)
        End Get
        Set(ByVal Value As wvEmployee)
            List(index) = Value
        End Set
    End Property
    Public Function Add(ByVal value As wvEmployee) As Integer
        Return List.Add(value)
    End Function
    Public Function IndexOf(ByVal value As wvEmployee) As Integer
        Return List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As wvEmployee)
        List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As wvEmployee)
        List.Remove(value)
    End Sub
    Public Function Contains(ByVal value As wvEmployee) As Boolean
        Return List.Contains(value)
    End Function
End Class

<Serializable()> Public Class cEmployee
    Private mConnString As String
    Dim oSql As SqlHelper

    Public Shared Function TimeZoneToday() As DateTime
        Try

            Dim Offset As Decimal = cEmployee.GetTimeZoneOffset()

            If Offset <> 0 Then

                Return DateAdd(DateInterval.Hour, Offset, CType(Now, DateTime))

            Else

                Return Now.Date

            End If

        Catch ex As Exception
            Return Now.Date
        End Try

    End Function
    Public Shared Function TimeZoneTodayTime() As DateTime
        Try

            Dim Offset As Decimal = cEmployee.GetTimeZoneOffset()

            If Offset <> 0 Then

                Return DateAdd(DateInterval.Hour, Offset, CType(Now, DateTime))

            Else

                Return Now

            End If

        Catch ex As Exception
            Return Now.Date
        End Try

    End Function
    Public Shared Function UserDate(ByRef [Date] As DateTime) As DateTime

        Try

            Dim Offset As Decimal = cEmployee.GetTimeZoneOffset()

            If Offset <> 0 Then

                Return DateAdd(DateInterval.Hour, Offset, [Date])

            Else

                Return [Date]

            End If

        Catch ex As Exception
            Return [Date]
        End Try

    End Function
    Public Shared Function DatabaseDate(ByRef [Date] As DateTime) As DateTime

        Try

            Dim Offset As Decimal = cEmployee.GetTimeZoneOffset()

            If Offset <> 0 Then

                Return DateAdd(DateInterval.Hour, Offset * -1, [Date])

            Else

                Return [Date]

            End If

        Catch ex As Exception
            Return [Date]
        End Try

    End Function
    Public Shared Sub ResetTimeZoneOffsetSession()

        If MiscFN.IsClientPortal = False Then

            ResetEmployeeTimeZoneOffsetSession()

        Else

            ResetClientPortalUserTimeZoneOffsetSession()

        End If

    End Sub
    Public Shared Sub ResetEmployeeTimeZoneOffsetSession()

        Try

            HttpContext.Current.Session("EmployeeTimeZoneOffset") = Nothing
            HttpContext.Current.Session("EmployeeTimeZoneOffsetUtcZero") = Nothing

        Catch ex As Exception
        End Try

    End Sub
    Public Shared Sub ResetClientPortalUserTimeZoneOffsetSession()

        Try

            HttpContext.Current.Session("ClientPortalUserTimeZoneOffset") = Nothing
            HttpContext.Current.Session("ClientPortalUserTimeZoneOffsetUtcZero") = Nothing

        Catch ex As Exception
        End Try

    End Sub

    Public Shared Function GetTimeZoneOffset(Optional ByVal ForceUTCZero As Boolean = False) As Decimal

        If MiscFN.IsClientPortal = False Then

            Return GetEmployeeTimeZoneOffset()

        Else

            Return GetClientPortalUserTimeZoneOffset()

        End If

    End Function
    Public Shared Function GetEmployeeTimeZoneOffset(Optional ByVal ForceUTCZero As Boolean = False) As Decimal

        Dim Offset As Decimal = CType(0.0, Decimal)

        Try

            Dim Key As String = "EmployeeTimeZoneOffset"

            If ForceUTCZero = True Then

                    Key &= "UtcZero"

                End If

                If HttpContext.Current.Session(Key) Is Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                        If ForceUTCZero = False Then

                            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployee(DbContext, HttpContext.Current.Session("EmpCode"))

                        Else

                            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForEmployeeForceUtcZero(DbContext, HttpContext.Current.Session("EmpCode"))

                        End If

                    End Using

                    HttpContext.Current.Session(Key) = Offset

                Else

                    Offset = HttpContext.Current.Session(Key)

                End If


        Catch ex As Exception
            Offset = CType(0.0, Decimal)
        End Try

        Return Offset

    End Function
    Public Shared Function GetClientPortalUserTimeZoneOffset(Optional ByVal ForceUTCZero As Boolean = False) As Decimal

        Dim Offset As Decimal = CType(0.0, Decimal)

        Try

            If HttpContext.Current.Session("UserID") IsNot Nothing AndAlso IsNumeric(HttpContext.Current.Session("UserID")) = True Then

                Dim Key As String = "ClientPortalUserTimeZoneOffset"

                If ForceUTCZero = True Then

                    Key &= "UtcZero"

                End If

                If HttpContext.Current.Session(Key) Is Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                        If ForceUTCZero = False Then

                            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForClientPortalUser(DbContext, HttpContext.Current.Session("UserID"))

                        Else

                            Offset = AdvantageFramework.Database.Procedures.Generic.LoadTimeZoneOffsetForClientPortalUserForceUtcZero(DbContext, HttpContext.Current.Session("UserID"))

                        End If

                    End Using

                    HttpContext.Current.Session(Key) = Offset

                Else

                    Offset = HttpContext.Current.Session(Key)

                End If

            End If

        Catch ex As Exception
            Offset = CType(0.0, Decimal)
        End Try

        Return Offset

    End Function

    Public Function GetEmail(ByVal EmpCode As String, Optional ByVal CheckEmailFlag As Boolean = False, Optional ByVal GetMailBeeFormatted As Boolean = False) As String
        Dim SessionKey As String = "GetEmail" & EmpCode & CheckEmailFlag.ToString() & GetMailBeeFormatted.ToString()
        Dim ThisReturn As String = ""

        If HttpContext.Current Is Nothing Then

            Dim arP(3) As SqlParameter

            Dim pEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            pEmpCode.Value = EmpCode
            arP(0) = pEmpCode

            Dim pCheckEmailFlag As New SqlParameter("@CheckEmailFlag", SqlDbType.TinyInt)
            pCheckEmailFlag.Value = MiscFN.BoolToInt(CheckEmailFlag)
            arP(1) = pCheckEmailFlag

            Dim pGetMailBeeFormatted As New SqlParameter("@GetMailBeeFormatted", SqlDbType.TinyInt)
            pGetMailBeeFormatted.Value = MiscFN.BoolToInt(GetMailBeeFormatted)
            arP(2) = pGetMailBeeFormatted

            Try
                ThisReturn = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_employee_getemail", arP).ToString()
            Catch
                ThisReturn = ""
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim arP(3) As SqlParameter

                Dim pEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                arP(0) = pEmpCode

                Dim pCheckEmailFlag As New SqlParameter("@CheckEmailFlag", SqlDbType.TinyInt)
                pCheckEmailFlag.Value = MiscFN.BoolToInt(CheckEmailFlag)
                arP(1) = pCheckEmailFlag

                Dim pGetMailBeeFormatted As New SqlParameter("@GetMailBeeFormatted", SqlDbType.TinyInt)
                pGetMailBeeFormatted.Value = MiscFN.BoolToInt(GetMailBeeFormatted)
                arP(2) = pGetMailBeeFormatted

                Try
                    ThisReturn = oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_employee_getemail", arP).ToString()
                Catch
                    ThisReturn = ""
                End Try
                HttpContext.Current.Session(SessionKey) = ThisReturn
            Else
                ThisReturn = HttpContext.Current.Session(SessionKey).ToString()
            End If

        End If

        Return ThisReturn

    End Function

    Public Function GetReplyTo(ByVal EmpCode As String) As String
        Dim SessionKey As String = "GetReplyTo" & EmpCode
        Dim ReturnString As String = ""
        If HttpContext.Current Is Nothing Then
            Try
                Dim ParamEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                ParamEmpCode.Value = EmpCode
                ReturnString = oSql.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_Employee_GetReplyTo", ParamEmpCode).ToString()
            Catch ex As Exception
                ReturnString = ""
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim ParamEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    ParamEmpCode.Value = EmpCode
                    ReturnString = oSql.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_Employee_GetReplyTo", ParamEmpCode).ToString()
                Catch ex As Exception
                    ReturnString = ""
                End Try

                HttpContext.Current.Session(SessionKey) = ReturnString
            Else
                ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            End If

        End If

        Return ReturnString

    End Function

    Public Function GetFromAddress(ByVal EmpCode As String) As String
        Dim SessionKey As String = "GetFromAddress" & EmpCode
        Dim ReturnString As String = ""
        If HttpContext.Current Is Nothing Then
            Try
                Dim ParamEmailAddress As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                ParamEmailAddress.Value = EmpCode
                ReturnString = oSql.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_Employee_GetFromAddress", ParamEmailAddress).ToString()
            Catch ex As Exception
                ReturnString = ""
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim ParamEmailAddress As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                    ParamEmailAddress.Value = EmpCode
                    ReturnString = oSql.ExecuteScalar(Me.mConnString, CommandType.StoredProcedure, "usp_wv_Employee_GetFromAddress", ParamEmailAddress).ToString()
                Catch ex As Exception
                    ReturnString = ""
                End Try

                HttpContext.Current.Session(SessionKey) = ReturnString
            Else
                ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            End If

        End If

        Return ReturnString

    End Function

    Public Function GetMailBeeTitle(ByVal Empcode As String) As String
        Dim SessionKey As String = "GetMailBeeTitle" & Empcode
        Dim ReturnString As String = ""
        If HttpContext.Current Is Nothing Then
            Try
                Dim StrSQL As String = "SELECT ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') +  ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + EMPLOYEE.EMP_EMAIL + '>' FROM EMPLOYEE WITH(NOLOCK) WHERE EMPLOYEE.EMP_CODE = '" & Empcode & "'"
                ReturnString = oSql.ExecuteScalar(mConnString, CommandType.Text, StrSQL).ToString()
            Catch ex As Exception
                ReturnString = ""
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim StrSQL As String = "SELECT ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') +  ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + EMPLOYEE.EMP_EMAIL + '>' FROM EMPLOYEE WITH(NOLOCK) WHERE EMPLOYEE.EMP_CODE = '" & Empcode & "'"
                    ReturnString = oSql.ExecuteScalar(mConnString, CommandType.Text, StrSQL).ToString()
                Catch ex As Exception
                    ReturnString = ""
                End Try
                HttpContext.Current.Session(SessionKey) = ReturnString
            Else
                ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            End If

        End If

        Return ReturnString

    End Function

    Public Function GetMailBeeTitleFromEmailAddress(ByVal EmailAddress As String) As String
        Dim SessionKey As String = "GetMailBeeTitleFromEmailAddress" & EmailAddress
        Dim ReturnString As String = ""
        If HttpContext.Current Is Nothing Then
            Try
                Dim StrSQL As String = "SELECT ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') +  ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + EMPLOYEE.EMP_EMAIL + '>' FROM EMPLOYEE WITH(NOLOCK) WHERE UPPER(EMPLOYEE.EMP_EMAIL) = UPPER('" & EmailAddress & "')"
                ReturnString = oSql.ExecuteScalar(mConnString, CommandType.Text, StrSQL).ToString()
            Catch ex As Exception
                ReturnString = ""
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim StrSQL As String = "SELECT ISNULL(EMPLOYEE.EMP_FNAME+' ', '') + ISNULL(EMPLOYEE.EMP_MI+'. ', '') +  ISNULL(EMPLOYEE.EMP_LNAME, '') + ' <' + EMPLOYEE.EMP_EMAIL + '>' FROM EMPLOYEE WITH(NOLOCK) WHERE UPPER(EMPLOYEE.EMP_EMAIL) = UPPER('" & EmailAddress & "')"
                    ReturnString = oSql.ExecuteScalar(mConnString, CommandType.Text, StrSQL).ToString()
                Catch ex As Exception
                    ReturnString = ""
                End Try
                HttpContext.Current.Session(SessionKey) = ReturnString
            Else
                ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            End If

        End If

        Return ReturnString

    End Function

    Public Function GetName(ByVal EmpCode As String) As String
        Dim SessionKey As String = "GetName" & EmpCode
        Dim ReturnString As String = ""
        If HttpContext.Current Is Nothing Then
            ' Create Instance of Connection and Command Object
            Dim arParams(3) As SqlParameter
            Dim myReturn As Integer

            Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
            pUserCode.Value = HttpContext.Current.Session("UserCode")
            arParams(0) = pUserCode

            Dim parameterEC As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEC.Value = EmpCode
            arParams(1) = parameterEC

            Dim parameterEN As New SqlParameter("@EmpName", SqlDbType.VarChar, 100)
            parameterEN.Direction = ParameterDirection.Output
            arParams(2) = parameterEN

            Try
                oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_emp_getname", arParams)
                ReturnString = parameterEN.Value.ToString()
            Catch
                ReturnString = ""
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                ' Create Instance of Connection and Command Object
                Dim arParams(3) As SqlParameter
                Dim myReturn As Integer

                Dim pUserCode As New SqlParameter("@USER_CODE", SqlDbType.VarChar, 100)
                pUserCode.Value = HttpContext.Current.Session("UserCode")
                arParams(0) = pUserCode

                Dim parameterEC As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                parameterEC.Value = EmpCode
                arParams(1) = parameterEC

                Dim parameterEN As New SqlParameter("@EmpName", SqlDbType.VarChar, 100)
                parameterEN.Direction = ParameterDirection.Output
                arParams(2) = parameterEN

                Try
                    oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_emp_getname", arParams)
                    ReturnString = parameterEN.Value.ToString()
                Catch
                    ReturnString = ""
                End Try

                HttpContext.Current.Session(SessionKey) = ReturnString
            Else
                ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            End If

        End If

        Return ReturnString

    End Function

    Public Function GetDept(ByVal EmpCode As String) As String
        Dim SessionKey As String = "GetDept" & EmpCode
        Dim ReturnString As String = ""
        If HttpContext.Current Is Nothing Then
            ' Create Instance of Connection and Command Object
            Dim arParams(2) As SqlParameter
            Dim myReturn As Integer

            Dim parameterEC As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            parameterEC.Value = EmpCode
            arParams(0) = parameterEC

            Dim parameterED As New SqlParameter("@EmpDept", SqlDbType.VarChar, 4)
            parameterED.Direction = ParameterDirection.Output
            arParams(1) = parameterED

            Try
                oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_emp_getdept", arParams)
                ReturnString = parameterED.Value
            Catch
                ReturnString = ""
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                ' Create Instance of Connection and Command Object
                Dim arParams(2) As SqlParameter
                Dim myReturn As Integer

                Dim parameterEC As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                parameterEC.Value = EmpCode
                arParams(0) = parameterEC

                Dim parameterED As New SqlParameter("@EmpDept", SqlDbType.VarChar, 4)
                parameterED.Direction = ParameterDirection.Output
                arParams(1) = parameterED

                Try
                    oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_emp_getdept", arParams)
                    ReturnString = parameterED.Value
                Catch
                    ReturnString = ""
                End Try

                HttpContext.Current.Session(SessionKey) = ReturnString
            Else
                ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            End If

        End If

        Return ReturnString

    End Function

    ''' ------Get the Flag which tells whether the employee wants an alert or email------
    ''' <summary>
    ''' Get the Flag which tells whether the employee wants an alert or email or both
    ''' 0 = No notification at all
    ''' 1 = Receives just email
    ''' 2 = Receives just alert
    ''' 3 = Receives both alert and email
    ''' </summary>
    ''' <param name="Empcode"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[smoreno]	2/1/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetAlertEmailFlag(ByVal Empcode As String) As Integer
        Dim SessionKey As String = "GetAlertEmailFlag" & Empcode
        Dim ReturnInteger As Integer = 0
        If HttpContext.Current Is Nothing Then
            Try
                Dim parameterUserName As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                parameterUserName.Value = Empcode
                ReturnInteger = CInt(oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_employee_get_alert_email_flag", parameterUserName))
            Catch
                ReturnInteger = 0
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Try
                    Dim parameterUserName As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                    parameterUserName.Value = Empcode
                    ReturnInteger = CInt(oSql.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_employee_get_alert_email_flag", parameterUserName))
                Catch
                    ReturnInteger = 0
                End Try

                HttpContext.Current.Session(SessionKey) = ReturnInteger
            Else
                ReturnInteger = CType(HttpContext.Current.Session(SessionKey).ToString(), Integer)
            End If

        End If

        Return ReturnInteger

    End Function

    Public Function getEmpSigPath(ByVal empCode As String) As String
        Dim SessionKey As String = "getEmpSigPath" & empCode
        Dim ReturnString As String = ""
        If HttpContext.Current Is Nothing Then
            Dim StrSQL As String = "SELECT SIGNATURE_PATH FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '" & empCode & "';"
            Try
                ReturnString = oSql.ExecuteScalar(mConnString, CommandType.Text, StrSQL)
            Catch
                ReturnString = ""
            End Try

        Else
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim StrSQL As String = "SELECT SIGNATURE_PATH FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = '" & empCode & "';"
                Try
                    ReturnString = oSql.ExecuteScalar(mConnString, CommandType.Text, StrSQL)
                Catch
                    ReturnString = ""
                End Try
                HttpContext.Current.Session(SessionKey) = ReturnString
            Else
                ReturnString = HttpContext.Current.Session(SessionKey).ToString()
            End If

        End If

        Return ReturnString

    End Function

    Public Function GetEmployeeProfileDataTable(ByVal EmpCode As String) As DataTable
        ' Create Instance of Connection and Command Object
        Dim arParams(2) As SqlParameter
        Dim dt As New DataTable

        Dim parameterEC As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEC.Value = EmpCode
        arParams(0) = parameterEC

        Dim pUserCode As New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
        pUserCode.Value = HttpContext.Current.Session("UserCode")
        arParams(1) = pUserCode

        Try
            dt = oSql.ExecuteDataTable(mConnString, CommandType.StoredProcedure, "usp_wv_GetEmpProfileData", "DtData", arParams)
        Catch
            Return dt
        End Try

        Return dt

    End Function
    Public Function GetEmployeeProfile(ByVal EmpCode As String) As SqlDataReader
        ' Create Instance of Connection and Command Object
        Dim arParams(2) As SqlParameter
        Dim dr As SqlDataReader

        Dim parameterEC As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEC.Value = EmpCode
        arParams(0) = parameterEC

        Dim pUserCode As New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
        pUserCode.Value = HttpContext.Current.Session("UserCode")
        arParams(1) = pUserCode

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_GetEmpProfileData", arParams)
        Catch
            Return dr
        End Try

        Return dr

    End Function
    Public Function SaveEmployeeProfile(ByVal EmpCode As String, ByVal picture As Byte(), ByVal nickname As String, ByVal wallpaper As Byte())
        ' Create Instance of Connection and Command Object
        Dim arParams(4) As SqlParameter

        Dim parameterEC As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEC.Value = EmpCode
        arParams(0) = parameterEC

        Dim parameterPicture As New SqlParameter("@Picture", SqlDbType.Image)
        parameterPicture.Value = picture
        arParams(1) = parameterPicture

        Dim parameterNickname As New SqlParameter("@Nickname", SqlDbType.VarChar)
        parameterNickname.Value = nickname
        arParams(2) = parameterNickname

        Dim parameterWallpaper As New SqlParameter("@Wallpaper", SqlDbType.Image)
        parameterWallpaper.Value = wallpaper
        arParams(3) = parameterWallpaper

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_SaveEmpProfileData", arParams)
        Catch
            Return ""
        End Try

        Return ""

    End Function
    Public Function UpdateEmployeeProfile(ByVal ID As Integer, ByVal picture As Byte(), ByVal nickname As String, ByVal wallpaper As Byte())
        ' Create Instance of Connection and Command Object
        Dim arParams(4) As SqlParameter

        Dim parameterID As New SqlParameter("@ID", SqlDbType.Int)
        parameterID.Value = ID
        arParams(0) = parameterID

        Dim parameterPicture As New SqlParameter("@Picture", SqlDbType.Image)
        parameterPicture.Value = picture
        arParams(1) = parameterPicture

        Dim parameterNickname As New SqlParameter("@Nickname", SqlDbType.VarChar)
        parameterNickname.Value = nickname
        arParams(2) = parameterNickname

        Dim parameterWallpaper As New SqlParameter("@Wallpaper", SqlDbType.Image)
        parameterWallpaper.Value = wallpaper
        arParams(3) = parameterWallpaper

        Try
            oSql.ExecuteNonQuery(mConnString, CommandType.StoredProcedure, "usp_wv_UpdateEmpProfileData", arParams)
        Catch
            Return ""
        End Try

        Return ""

    End Function
    Public Function GetEmailGroups(ByVal DefaultGroup As String, Optional ByVal ShowAutoGroup As Boolean = False, Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNbr As Integer = 0) As wvEmailGroups
        Dim dr As SqlDataReader
        Dim TheseGroups As New wvEmailGroups
        Dim ThisGroup As wvEmailGroup
        Dim TheseEmployees As New wvEmployees
        Dim ThisEmployee As wvEmployee
        Dim strGroup As String = ""
        Dim strLastGroup As String = ""
        Dim FirstPass As Boolean = True


        Dim arParams(4) As SqlParameter

        Dim paramGroup As New SqlParameter("@DefaultGroup", SqlDbType.VarChar, 50)
        paramGroup.Value = DefaultGroup
        arParams(0) = paramGroup

        Dim parameterJOB_NUMBER As New SqlParameter("@JOB_NUMBER", SqlDbType.Int)
        parameterJOB_NUMBER.Value = JobNumber
        arParams(1) = parameterJOB_NUMBER

        Dim parameterJOB_COMPONENT_NBR As New SqlParameter("@JOB_COMPONENT_NBR", SqlDbType.SmallInt)
        parameterJOB_COMPONENT_NBR.Value = JobComponentNbr
        arParams(2) = parameterJOB_COMPONENT_NBR

        Dim parameterAUTO_GROUP As New SqlParameter("@AUTO_GROUP", SqlDbType.SmallInt)
        If ShowAutoGroup = True Then
            parameterAUTO_GROUP.Value = 1
        Else
            parameterAUTO_GROUP.Value = 0
        End If
        arParams(3) = parameterAUTO_GROUP



        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_email_get_groups", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cEmployee Routine:GetEmailGroups", Err.Description)
        End Try

        If dr.HasRows = True Then
            Do While dr.Read()
                strGroup = dr("GroupCode")
                If strGroup <> strLastGroup Then
                    strLastGroup = strGroup
                    If FirstPass = False Then
                        ThisGroup.Employees = TheseEmployees
                        TheseGroups.Add(ThisGroup)
                    End If
                    TheseEmployees = New wvEmployees
                    ThisGroup = New wvEmailGroup
                    ThisGroup.Name = strGroup
                    ThisGroup.CheckBoxID = "chk_" & strGroup
                    If strGroup = DefaultGroup Then
                        ThisGroup.Selected = True
                    End If
                    FirstPass = False
                End If
                ThisEmployee = New wvEmployee
                Try
                    ThisEmployee.EmpCode = DBStr(dr, ("Empcode"))
                Catch ex As Exception
                    ThisEmployee.EmpCode = ""
                End Try
                Try
                    ThisEmployee.EmployeeFullName = DBStr(dr, ("EmpName"))
                Catch ex As Exception
                    ThisEmployee.EmployeeFullName = ""
                End Try
                Try
                    ThisEmployee.AlertEmail = dr("AlertEmail")
                Catch ex As Exception
                    ThisEmployee.AlertEmail = 0
                End Try
                Try
                    ThisEmployee.Email = DBStr(dr, ("Email"))
                Catch ex As Exception
                    ThisEmployee.Email = ""
                End Try
                Try
                    ThisEmployee.CheckBoxID = "chk_" & strGroup & ThisEmployee.EmpCode
                Catch ex As Exception
                    ThisEmployee.CheckBoxID = ""
                End Try
                TheseEmployees.Add(ThisEmployee)
            Loop
            ThisGroup.Employees = TheseEmployees
            TheseGroups.Add(ThisGroup)
        End If

        Return TheseGroups

    End Function
    Public Function GetEmailRecipientsInternal(ByVal includeall As Boolean, ByVal empcode As String, ByVal name As String, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0, Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNbr As Integer = 0) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter
        Dim paramIncludeAll As New SqlParameter("@IncludeAll", SqlDbType.Int)
        If includeall = False Then
            paramIncludeAll.Value = 0
        Else
            paramIncludeAll.Value = 1
        End If
        arParams(0) = paramIncludeAll

        Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = empcode
        arParams(1) = parameterEmpCode

        Dim parameterName As New SqlParameter("@Name", SqlDbType.VarChar, 100)
        parameterName.Value = name
        arParams(2) = parameterName

        Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
        If CP = True Then
            parameterCP.Value = 1
        Else
            parameterCP.Value = 0
        End If
        arParams(3) = parameterCP

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(4) = parameterCPID

        Dim parameterJOB_NUMBER As New SqlParameter("@JobNumber", SqlDbType.Int)
        parameterJOB_NUMBER.Value = JobNumber
        arParams(5) = parameterJOB_NUMBER

        Dim parameterJOB_COMPONENT_NBR As New SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)
        parameterJOB_COMPONENT_NBR.Value = JobComponentNbr
        arParams(6) = parameterJOB_COMPONENT_NBR

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_email_getInternalRecipients", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cEmployee Routine:GetEmailRecipientsInternal", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetEmailRecipientsClient(ByVal includeall As Boolean, ByVal client As String, ByVal name As String, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0, Optional ByVal JobNumber As Integer = 0, Optional ByVal JobComponentNbr As Integer = 0) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(7) As SqlParameter
        Dim paramIncludeAll As New SqlParameter("@IncludeAll", SqlDbType.Int)
        If includeall = False Then
            paramIncludeAll.Value = 0
        Else
            paramIncludeAll.Value = 1
        End If
        arParams(0) = paramIncludeAll

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClient.Value = client
        arParams(1) = parameterClient

        Dim parameterName As New SqlParameter("@Name", SqlDbType.VarChar, 100)
        parameterName.Value = name
        arParams(2) = parameterName

        Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
        If CP = True Then
            parameterCP.Value = 1
        Else
            parameterCP.Value = 0
        End If
        arParams(3) = parameterCP

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(4) = parameterCPID

        Dim parameterJOB_NUMBER As New SqlParameter("@JobNumber", SqlDbType.Int)
        parameterJOB_NUMBER.Value = JobNumber
        arParams(5) = parameterJOB_NUMBER

        Dim parameterJOB_COMPONENT_NBR As New SqlParameter("@JobComponentNumber", SqlDbType.SmallInt)
        parameterJOB_COMPONENT_NBR.Value = JobComponentNbr
        arParams(6) = parameterJOB_COMPONENT_NBR

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_email_getClientRecipients", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cEmployee Routine:GetEmailRecipientsClient", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetEmailRecipientsProduct(ByVal includeall As Boolean, ByVal client As String, ByVal division As String, ByVal product As String, ByVal name As String, ByVal namediv As String, ByVal nameprd As String, Optional ByVal CP As Boolean = False, Optional ByVal CPID As Integer = 0) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(9) As SqlParameter
        Dim paramIncludeAll As New SqlParameter("@IncludeAll", SqlDbType.Int)
        If includeall = False Then
            paramIncludeAll.Value = 0
        Else
            paramIncludeAll.Value = 1
        End If
        arParams(0) = paramIncludeAll

        Dim parameterClient As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        parameterClient.Value = client
        arParams(1) = parameterClient

        Dim parameterDivision As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        parameterDivision.Value = division
        arParams(2) = parameterDivision

        Dim parameterProduct As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        parameterProduct.Value = product
        arParams(3) = parameterProduct

        Dim parameterName As New SqlParameter("@Name", SqlDbType.VarChar, 100)
        parameterName.Value = name
        arParams(4) = parameterName

        Dim parameterNameDiv As New SqlParameter("@NameDiv", SqlDbType.VarChar, 100)
        parameterNameDiv.Value = namediv
        arParams(5) = parameterNameDiv

        Dim parameterNamePrd As New SqlParameter("@NamePrd", SqlDbType.VarChar, 100)
        parameterNamePrd.Value = nameprd
        arParams(6) = parameterNamePrd

        Dim parameterCP As New SqlParameter("@CP", SqlDbType.Int)
        If CP = True Then
            parameterCP.Value = 1
        Else
            parameterCP.Value = 0
        End If
        arParams(7) = parameterCP

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(8) = parameterCPID

        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_email_getProductRecipients", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cEmployee Routine:GetEmailRecipientsProduct", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetEmailVendorContacts(ByVal includeall As Boolean, ByVal vendor As String, ByVal name As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter
        Dim paramIncludeAll As New SqlParameter("@IncludeAll", SqlDbType.Int)
        If includeall = False Then
            paramIncludeAll.Value = 0
        Else
            paramIncludeAll.Value = 1
        End If
        arParams(0) = paramIncludeAll

        Dim parameterVendor As New SqlParameter("@Vendor", SqlDbType.VarChar, 6)
        parameterVendor.Value = vendor
        arParams(1) = parameterVendor

        Dim parameterName As New SqlParameter("@Name", SqlDbType.VarChar, 100)
        parameterName.Value = name
        arParams(2) = parameterName


        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_email_getVendorContacts", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cEmployee Routine:GetEmailVendorContacts", Err.Description)
        End Try

        Return dr

    End Function
    Public Function GetEmailVendorReps(ByVal includeall As Boolean, ByVal vendor As String, ByVal name As String) As SqlDataReader
        Dim dr As SqlDataReader
        Dim arParams(3) As SqlParameter
        Dim paramIncludeAll As New SqlParameter("@IncludeAll", SqlDbType.Int)
        If includeall = False Then
            paramIncludeAll.Value = 0
        Else
            paramIncludeAll.Value = 1
        End If
        arParams(0) = paramIncludeAll

        Dim parameterVendor As New SqlParameter("@Vendor", SqlDbType.VarChar, 6)
        parameterVendor.Value = vendor
        arParams(1) = parameterVendor

        Dim parameterName As New SqlParameter("@Name", SqlDbType.VarChar, 100)
        parameterName.Value = name
        arParams(2) = parameterName


        Try
            dr = oSql.ExecuteReader(mConnString, CommandType.StoredProcedure, "usp_wv_email_getVendorReps", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cEmployee Routine:GetEmailVendorContacts", Err.Description)
        End Try

        Return dr

    End Function
    Public Function getEmpSignatureImage(ByVal empCode As String) As System.Drawing.Image
        Dim StrSQL As String = ""
        Dim dr As SqlDataReader
        Dim oSql As SqlHelper

        StrSQL = "SELECT EMP_SIG FROM EMPLOYEE WHERE EMP_CODE = '" & empCode & "'"
        dr = oSql.ExecuteReader(mConnString, CommandType.Text, StrSQL)
        dr.Read()

        Dim memstrm As New System.IO.MemoryStream(CType(dr("EMP_SIG"), Byte()))
        Dim SigImage As System.Drawing.Image = System.Drawing.Image.FromStream(memstrm)

        dr.Close()
        Return SigImage

    End Function
    Private Function DBStr(ByRef dr As SqlDataReader, ByVal Name As String) As String
        If IsDBNull(dr(Name)) = True Then
            Return ""
        Else
            Return CStr(dr(Name))
        End If
    End Function
    Private Function FPart(ByVal pString As String)
        If pString.IndexOf(" ") > 0 Then
            Return pString.Substring(0, pString.IndexOf(" "))
        Else
            Return pString
        End If
    End Function

    Public Function EmployeePicture_SaveNickname(ByVal EmpCode As String, ByVal Nickname As String, Optional ByRef ErrorMessage As String = "") As Boolean

        Try

            If EmpCode = "" Then

                ErrorMessage = "No employee code"
                Return False

            End If

            Using MyConn As New SqlConnection(Me.mConnString)

                Dim MyCommand As New SqlCommand()
                With MyCommand
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "usp_wv_SaveEmployeeNickname"
                    .Connection = MyConn
                End With

                Dim pEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                pEmpCode.Value = EmpCode
                MyCommand.Parameters.Add(pEmpCode)

                Dim pNickname As New SqlParameter("@NICKNAME", SqlDbType.VarChar, 10)
                If Nickname = "" Then
                    pNickname.Value = System.DBNull.Value
                Else
                    pNickname.Value = Nickname
                End If
                MyCommand.Parameters.Add(pNickname)

                MyConn.Open()

                MyCommand.ExecuteNonQuery()

            End Using

            ErrorMessage = ""
            Return True

        Catch ex As Exception

            ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            Return False

        End Try

    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub

End Class
