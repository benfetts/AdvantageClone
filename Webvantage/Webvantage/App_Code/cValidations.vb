Imports System.Data
Imports System.Data.SqlClient
<Serializable()> Public Class cValidations
    Dim mConnString As String
    Dim oSQL As SqlHelper

    Public Function ValidateDateTextBox(ByRef tb As System.Web.UI.WebControls.TextBox, ByVal IsRequired As Boolean) As Boolean
        Dim strDate As String = tb.Text.Trim
        If IsRequired = True And strDate = "" Then
            Return False
        End If
        If strDate <> "" Then
            If cGlobals.wvIsDate(strDate) = True Then
                tb.Text = cGlobals.wvCDate(strDate).ToShortDateString
                Return True
            Else
                tb.Text = ""
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Public Function ValidateTrafficStatus(ByVal StatusCode As String, Optional ByVal IsUpdateAllowInactive As Boolean = False) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateTrafficStatus" & StatusCode & IsUpdateAllowInactive.ToString()
        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim ireturn As Integer = 0
            Dim arparams(2) As SqlParameter

            Dim pStatusCode As New SqlParameter("@TRF_CODE", SqlDbType.VarChar, 10)
            pStatusCode.Value = StatusCode
            arparams(0) = pStatusCode

            Dim pIsUpdate As New SqlParameter("@IS_UPDATE", SqlDbType.Bit)
            pIsUpdate.Value = IsUpdateAllowInactive
            arparams(1) = pIsUpdate

            Try
                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_TrafficCode", arparams))
            Catch
                Err.Raise(Err.Number, "Class:cValidations Routine:ValidateTrafficStatusCode", Err.Description)
            End Try

            If ireturn > 0 Then
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

    Public Function ValidateCDPContact(ByVal CDPContactID As Integer, ByVal UserCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateCDPContact" & CDPContactID.ToString() & UserCode

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter
            Dim paramCDPContactID As New SqlParameter("@CDPContactID", SqlDbType.Int)
            paramCDPContactID.Value = CDPContactID
            arParams(0) = paramCDPContactID
            Dim paramUserCode As New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(1) = paramUserCode

            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_CDPContact", arParams))
            Catch
                Err.Raise(Err.Number, "Class:cValidations Routine:ValidateCDPContact", Err.Description)
            End Try

            If iReturn > 0 Then
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

    Public Function ValidateCDPContactEst(ByVal CDPContactID As Integer, ByVal UserCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateCDPContactEst" & CDPContactID.ToString() & UserCode

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter
            Dim paramCDPContactID As New SqlParameter("@CDPContactID", SqlDbType.Int)
            paramCDPContactID.Value = CDPContactID
            arParams(0) = paramCDPContactID
            Dim paramUserCode As New SqlParameter("@UserCode", SqlDbType.VarChar, 100)
            paramUserCode.Value = UserCode
            arParams(1) = paramUserCode

            Dim iReturn As Integer = 0
            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_CDPContact_Est", arParams))
            Catch
                Err.Raise(Err.Number, "Class:cValidations Routine:ValidateCDPContact", Err.Description)
            End Try

            If iReturn > 0 Then
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

    Public Function ValidateOffice(ByVal OFFICE_CODE As String, Optional ByVal IncludeAll As Boolean = False, Optional ByVal ClientCode As String = "",
                                   Optional ByVal DivisionCode As String = "", Optional ByVal ProductCode As String = "") As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateOffice" & AdvantageFramework.Security.Encryption.ASCIIEncoding(OFFICE_CODE & IncludeAll.ToString()) & HttpContext.Current.Session("UserCode")

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(2) As SqlParameter

                Dim parameterOfficeCode As New SqlParameter("@OfficeCode", SqlDbType.VarChar, 6)
                parameterOfficeCode.Value = OFFICE_CODE
                arParams(0) = parameterOfficeCode

                Dim parameterUSER_ID As New SqlParameter("@USER_ID", SqlDbType.VarChar, 100)
                parameterUSER_ID.Value = HttpContext.Current.Session("UserCode")
                arParams(1) = parameterUSER_ID

                If IncludeAll = False Then
                    myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_office", arParams)
                Else
                    myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_office_all", arParams)
                End If

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If
        Return IsValid

    End Function

    Public Function ValidateCDP(ByVal CL As String, ByVal DIV As String, ByVal PRD As String, Optional ByVal IncludeAll As Boolean = False) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateCDP" & CL & DIV & PRD & IncludeAll.ToString()

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(3) As SqlParameter

                Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
                parameterClientCode.Value = CL
                arParams(0) = parameterClientCode

                Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
                parameterDivisionCode.Value = DIV
                arParams(1) = parameterDivisionCode

                Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
                parameterProductCode.Value = PRD
                arParams(2) = parameterProductCode

                If IncludeAll = False Then
                    If CL <> "" And DIV <> "" And PRD <> "" Then
                        myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_cdp", arParams)
                    ElseIf CL <> "" And DIV <> "" And PRD = "" Then
                        myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_cd", arParams)
                    ElseIf CL <> "" And DIV = "" And PRD = "" Then
                        myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_client", arParams)
                    End If
                Else
                    If CL <> "" And DIV <> "" And PRD <> "" Then
                        myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_cdp_all", arParams)
                    ElseIf CL <> "" And DIV <> "" And PRD = "" Then
                        myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_cd_all", arParams)
                    ElseIf CL <> "" And DIV = "" And PRD = "" Then
                        myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_client_all", arParams)
                    End If
                End If

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If

            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If
        Return IsValid

    End Function

    Public Function ValidateDivision(ByVal CL As String, ByVal DIV As String, ByVal PRD As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateDivision" & CL & DIV & PRD

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(3) As SqlParameter

                Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
                parameterClientCode.Value = CL
                arParams(0) = parameterClientCode

                Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
                parameterDivisionCode.Value = DIV
                arParams(1) = parameterDivisionCode

                Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
                parameterProductCode.Value = PRD
                arParams(2) = parameterProductCode

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_division", arParams)

                If myReturnMessage = "Valid" Then
                    Return True
                Else
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateProduct(ByVal CL As String, ByVal DIV As String, ByVal PRD As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateProduct" & CL & DIV & PRD

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(3) As SqlParameter

                Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
                parameterClientCode.Value = CL
                arParams(0) = parameterClientCode

                Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
                parameterDivisionCode.Value = DIV
                arParams(1) = parameterDivisionCode

                Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
                parameterProductCode.Value = PRD
                arParams(2) = parameterProductCode

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_product", arParams)

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateVendor(ByVal Vendor As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateVendor" & Vendor
        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(1) As SqlParameter

                Dim parameterVendor As New SqlParameter("@Vendor", SqlDbType.VarChar, 6)
                parameterVendor.Value = Vendor
                arParams(0) = parameterVendor

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_vendor", arParams)

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateAPInvoice(ByVal APInvoice As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateAPInvoice" & APInvoice

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(1) As SqlParameter

                Dim parameterAPInvoice As New SqlParameter("@APInvoice", SqlDbType.VarChar)
                parameterAPInvoice.Value = APInvoice
                arParams(0) = parameterAPInvoice

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_apinvoice", arParams)

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try
            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateVendorAPInvoice(ByVal APInvoice As String, ByVal Vendor As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateVendorAPInvoice" & APInvoice & Vendor

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(2) As SqlParameter

                Dim parameterAPInvoice As New SqlParameter("@APInvoice", SqlDbType.VarChar)
                parameterAPInvoice.Value = APInvoice
                arParams(0) = parameterAPInvoice

                Dim parameterVendor As New SqlParameter("@Vendor", SqlDbType.VarChar)
                parameterVendor.Value = Vendor
                arParams(1) = parameterVendor

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_vendorapinvoice", arParams)

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateEmpCode(ByVal EmpCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateEmpCode" & EmpCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As Integer = 0

                Dim arParams(1) As SqlParameter

                Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                parameterEmpCode.Value = EmpCode
                arParams(0) = parameterEmpCode

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_emp_code", arParams)

                If myReturnMessage = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateEmpCodetd(ByVal EmpCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateEmpCodetd" & EmpCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As Integer = 0

                Dim arParams(1) As SqlParameter

                Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                parameterEmpCode.Value = EmpCode
                arParams(0) = parameterEmpCode

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_emp_code_td", arParams)

                If myReturnMessage = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If
        Return IsValid

    End Function
    Public Function ValidateEmpCodesExist(ByVal EmpCodeString As String, ByRef ErrorMessage As String) As Boolean
        Try

            ErrorMessage = ""
            EmpCodeString = EmpCodeString.Trim()

            If EmpCodeString = "" Then

                ErrorMessage = ""
                Return True

            Else

                EmpCodeString = MiscFN.CleanStringForSplit(EmpCodeString, ",")

                Dim InvalidList As String = ""

                Dim SQL As New System.Text.StringBuilder
                With SQL

                    If EmpCodeString.Contains(",") = False And EmpCodeString.Length = 1 Then

                        .Append("IF NOT EXISTS (SELECT EMP_CODE FROM EMPLOYEE WITH(NOLOCK) WHERE EMP_CODE = @EMP_LIST) ")
                        .Append("BEGIN ")
                        .Append("   SELECT @EMP_LIST AS vstr; ")
                        .Append("END ")
                        .Append("ELSE ")
                        .Append("BEGIN ")
                        .Append("   SELECT EMP_CODE AS vstr FROM EMPLOYEE WHERE EMP_CODE IS NULL; ")
                        .Append("END ")

                    Else

                        .Append("SELECT vstr ")
                        .Append("FROM charlist_to_table (@EMP_LIST,',') ")
                        .Append("LEFT OUTER JOIN EMPLOYEE ON vstr = EMPLOYEE.EMP_CODE ")
                        .Append("WHERE EMPLOYEE.EMP_CODE IS NULL;")

                    End If

                End With

                Using MyConn As New SqlConnection(Me.mConnString)

                    Dim MyCommand As New SqlCommand()
                    With MyCommand

                        .CommandType = CommandType.Text
                        .CommandText = SQL.ToString()
                        .Connection = MyConn

                    End With

                    Dim pEmpCode As New SqlParameter("@EMP_LIST", SqlDbType.VarChar)
                    pEmpCode.Value = EmpCodeString

                    MyCommand.Parameters.Add(pEmpCode)

                    MyConn.Open()

                    Dim Reader As SqlDataReader
                    Reader = MyCommand.ExecuteReader()

                    If Reader.HasRows = True Then

                        Dim i As Integer = 0

                        Do While Reader.Read()

                            If Reader.IsDBNull(Reader.GetOrdinal("vstr")) = False Then

                                InvalidList &= Reader.GetValue(Reader.GetOrdinal("vstr")) & ","
                                i += 1

                            End If

                        Loop

                        InvalidList = MiscFN.CleanStringForSplit(InvalidList, ",")

                        Select Case i

                            Case 1

                                ErrorMessage = "The following employee code does not exist:  " & InvalidList.Replace(",", ", ") & ". \nPlease enter a valid recipient."
                                Return False

                            Case Is > 1

                                ErrorMessage = "The following employee codes do not exist:  " & InvalidList.Replace(",", ", ") & ". \nPlease enter valid recipients."
                                Return False

                            Case Else

                                ErrorMessage = ""
                                Return True

                        End Select

                    Else

                        ErrorMessage = ""
                        Return True

                    End If

                End Using

            End If

        Catch ex As Exception

            'ErrorMessage = AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString())
            'Return False
            ErrorMessage = ""
            Return True

        End Try
    End Function

    Public Overloads Function ValidateCDPIsViewable(ByVal ClCode As String, ByVal DivCode As String, ByVal PrdCode As String,
                                                    ByVal JobNumber As Integer, ByVal JobComponentNbr As Integer,
                                                    ByRef Message As String) As Boolean

        ClCode = ClCode.Trim()
        DivCode = DivCode.Trim()
        PrdCode = PrdCode.Trim()

        If ClCode <> "" Then

            If Me.ValidateCDPIsViewable("CL", HttpContext.Current.Session("UserCode"), ClCode, "", "") = False Then

                Message = "Access to this client is denied"
                Return False

            End If

        End If

        If ClCode <> "" AndAlso DivCode <> "" Then

            If Me.ValidateCDPIsViewable("DI", HttpContext.Current.Session("UserCode"), ClCode, DivCode, "") = False Then

                Message = "Access to this division is denied"
                Return False

            End If

        End If

        If ClCode <> "" AndAlso DivCode <> "" AndAlso PrdCode <> "" Then

            If Me.ValidateCDPIsViewable("PR", HttpContext.Current.Session("UserCode"), ClCode, DivCode, PrdCode) = False Then

                Message = "Access to this product is denied"
                Return False

            End If

        End If

        If JobNumber > 0 Then

            If Me.ValidateJobIsViewable(HttpContext.Current.Session("UserCode"), JobNumber) = False Then

                Message = "Access to this job is denied"
                Return False

            End If

        End If

        If JobComponentNbr > 0 Then

            If Me.ValidateJobCompIsViewable(HttpContext.Current.Session("UserCode"), JobNumber, JobComponentNbr) = False Then

                Message = "Access to this job/comp is denied"
                Return False

            End If

        End If

        Message = ""
        Return True

    End Function

    Public Overloads Function ValidateCDPIsViewable(ByVal TheLevel As String, ByVal strUserID As String, ByVal strClientCode As String,
                                          ByVal strDivisionCode As String, ByVal strProductCode As String, Optional ByVal fromapp As String = "") As Boolean
        Dim IsValid As Boolean = False

        Dim SessionKey As String = "ValidateCDPIsViewable" & strUserID & AdvantageFramework.Security.Encryption.ASCIIEncoding(strClientCode & strDivisionCode & strProductCode)

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim ireturn As Integer = 0
            Try
                Dim arparams(6) As SqlParameter

                Dim paramLevel As New SqlParameter("@Level", SqlDbType.VarChar, 2)
                paramLevel.Value = TheLevel
                arparams(0) = paramLevel

                Dim paramClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
                paramClientCode.Value = strClientCode
                arparams(1) = paramClientCode

                Dim paramDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
                paramDivisionCode.Value = strDivisionCode
                arparams(2) = paramDivisionCode

                Dim paramProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
                paramProductCode.Value = strProductCode
                arparams(3) = paramProductCode

                Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
                parameterUserID.Value = strUserID
                arparams(4) = parameterUserID

                Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 100)
                parameterFromApp.Value = fromapp
                arparams(5) = parameterFromApp

                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_CDP_IsViewable", arparams))
            Catch
                ireturn = 0
            End Try

            If ireturn > 0 Then
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

    Public Function ValidateCDPJCIsViewable(ByVal strClientCode As String, ByVal strDivisionCode As String, ByVal strProductCode As String,
                                            ByVal JobNum As Integer, ByVal JobCompNum As Integer) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateCDPJCIsViewable" & AdvantageFramework.Security.Encryption.ASCIIEncoding(strClientCode & strDivisionCode & strProductCode &
                                    JobNum.ToString().PadLeft(6, "0") & JobCompNum.ToString().PadLeft(6, "0"))

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim ireturn As Integer = 0
            Dim arparams(5) As SqlParameter

            Dim paramClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            paramClientCode.Value = strClientCode
            arparams(0) = paramClientCode

            Dim paramDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            paramDivisionCode.Value = strDivisionCode
            arparams(1) = paramDivisionCode

            Dim paramProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            paramProductCode.Value = strProductCode
            arparams(2) = paramProductCode

            Dim paramJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
            paramJobNum.Value = JobNum
            arparams(3) = paramJobNum

            Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.Int)
            parameterJobCompNum.Value = JobCompNum
            arparams(4) = parameterJobCompNum

            Try
                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_CDPJC_IsViewable", arparams))
            Catch
                ireturn = 0
            End Try

            If ireturn > 0 Then
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

    Public Function ValidateJobIsViewable(ByVal strUserID As String, ByVal strJobNum As String) As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Or IsNumeric(strJobNum) = False Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateJobIsViewable" & strUserID & strJobNum.ToString().PadLeft(6, "0")

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(3) As SqlParameter

                Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
                parameterUserID.Value = strUserID
                arparams(0) = parameterUserID

                Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                parameterJobNum.Value = strJobNum
                arparams(1) = parameterJobNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobIsViewable", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If

            Return IsValid

        End If
    End Function

    Public Function ValidateJobIsViewableCDP(ByVal strUserID As String, ByVal strJobNum As String) As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Or IsNumeric(strJobNum) = False Then
            Return False
            Exit Function
        Else

            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateJobIsViewableCDP" & strUserID & strJobNum.PadLeft(6, "0")

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(3) As SqlParameter

                Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
                parameterUserID.Value = strUserID
                arparams(0) = parameterUserID

                Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                parameterJobNum.Value = strJobNum
                arparams(1) = parameterJobNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobIsViewable_CDP", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If

            Return IsValid

        End If
    End Function

    Public Function ValidateJobCompIsEditable(ByVal strJobNum As String, ByVal strJobCompNum As String, Optional ByVal OnlyClosedProcessControls As Boolean = False) As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Or IsNumeric(strJobNum) = False Or strJobCompNum = "" Or strJobCompNum = String.Empty Or IsNumeric(strJobCompNum) = False Then

            Return False
            Exit Function

        Else

            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateJobCompIsEditable" & strJobNum.PadLeft(6, "0") & strJobNum.PadLeft(6, "0") & OnlyClosedProcessControls.ToString()

            'If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Dim ireturn As Integer = 0
            Dim arparams(3) As SqlParameter


            Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
            parameterJobNum.Value = strJobNum
            arparams(0) = parameterJobNum

            Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.Int)
            parameterJobCompNum.Value = strJobCompNum
            arparams(1) = parameterJobCompNum

            Dim parameterOnlyClosedProcessControls As New SqlParameter("@OnlyClosedProcessControls", SqlDbType.SmallInt)
            If OnlyClosedProcessControls = True Then
                parameterOnlyClosedProcessControls.Value = 1
            Else
                parameterOnlyClosedProcessControls.Value = 0
            End If
            arparams(2) = parameterOnlyClosedProcessControls

            Try
                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobCompIsEditable", arparams))
            Catch
                ireturn = 0
            End Try

            If ireturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            '    HttpContext.Current.Session(SessionKey) = IsValid
            'Else

            '    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)

            'End If

            Return IsValid

        End If

    End Function

    Public Function ValidateJobCompIsViewable(ByVal strUserID As String, ByVal strJobNum As String, ByVal strJobCompNum As String, Optional ByVal fromapp As String = "") As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Or IsNumeric(strJobNum) = False Then
            Return False
        Else
            Dim IsViewable As Boolean = False
            Dim SessionKey As String = "ValidateJobCompIsViewable" & strUserID & strJobNum.Trim().PadLeft(6, "0") & strJobCompNum.Trim().PadLeft(6, "0")
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(4) As SqlParameter

                Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
                parameterUserID.Value = strUserID
                arparams(0) = parameterUserID

                Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                parameterJobNum.Value = strJobNum
                arparams(1) = parameterJobNum

                Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.Int)
                parameterJobCompNum.Value = strJobCompNum
                arparams(2) = parameterJobCompNum

                Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 100)
                parameterFromApp.Value = fromapp
                arparams(3) = parameterFromApp

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobCompIsViewable", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsViewable = True
                Else
                    IsViewable = False
                End If
                HttpContext.Current.Session(SessionKey) = IsViewable
            Else
                IsViewable = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If
            Return IsViewable
        End If

    End Function

    Public Function ValidateJobIsOpen(ByVal strJobNum As String, ByVal strJobCompNum As String) As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Or IsNumeric(strJobNum) = False Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateJobIsOpen" & strJobNum.Trim().PadLeft(6, "0") & strJobCompNum.Trim().PadLeft(6, "0")
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(2) As SqlParameter

                Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                parameterJobNum.Value = strJobNum
                arparams(0) = parameterJobNum

                Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.Int)
                parameterJobCompNum.Value = strJobCompNum
                arparams(1) = parameterJobCompNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_job_JobIsOpen", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    Return True
                Else
                    Return False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If
            Return IsValid

        End If

    End Function

    Public Function ValidatePONumber(ByVal strPONum As String) As Boolean
        If strPONum = "" Or strPONum = String.Empty Or IsNumeric(strPONum) = False Then
            Return False
            Exit Function
        Else
            Dim ireturn As Integer = 0
            Dim arparams(1) As SqlParameter

            Dim parameterPONum As New SqlParameter("@PONum", SqlDbType.Int)
            parameterPONum.Value = strPONum
            arparams(0) = parameterPONum

            Try
                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_PONum", arparams))
            Catch
                Err.Raise(Err.Number, "Class:cValidations Routine:ValidatePONumber", Err.Description)
            End Try

            If ireturn > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function ValidateJobNumber(ByVal strJobNum As String) As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Or IsNumeric(strJobNum) = False Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateJobNumber" & strJobNum.Trim().PadLeft(6, "0")
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(1) As SqlParameter

                Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                parameterJobNum.Value = strJobNum
                arparams(0) = parameterJobNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobNum", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If
            Return IsValid

        End If
    End Function

    Public Function ValidateJobCompNumber(ByVal strJobNum As String, ByVal strJobCompNum As String) As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Or strJobCompNum = "" Or strJobCompNum = String.Empty Or IsNumeric(strJobNum) = False Or IsNumeric(strJobCompNum) = False Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateJobCompNumber" & strJobNum.Trim().PadLeft(6, "0") & strJobCompNum.Trim().PadLeft(6, "0")
            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(2) As SqlParameter

                Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                parameterJobNum.Value = strJobNum
                arparams(0) = parameterJobNum

                Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.SmallInt)
                parameterJobCompNum.Value = strJobCompNum
                arparams(1) = parameterJobCompNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobCompNum", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If

            Return IsValid

        End If
    End Function

    Public Function ValidateJobPO(ByVal strJobNum As String) As Boolean
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim rowcount As Integer = 0

        SQL_STRING = " SELECT count(*) "
        SQL_STRING += " FROM JOB_LOG "
        SQL_STRING += " INNER JOIN JOB_COMPONENT ON JOB_LOG.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER "
        'SQL_STRING += " WHERE (JOB_COMPONENT.JOB_PROCESS_CONTRL NOT IN (2,5,6,7,10,11,12)) "
        SQL_STRING += " WHERE JOB_LOG.JOB_NUMBER = " & strJobNum

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobPO", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            rowcount = dr.GetInt32(0)
        End If

        dr.Close()
        If rowcount > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Function ValidateJobCompPO(ByVal strJobNum As String, ByVal strJobCompNum As String) As Boolean
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim rowcount As Integer = 0

        SQL_STRING = " SELECT count(*) "
        SQL_STRING += " FROM JOB_COMPONENT "
        'SQL_STRING += " WHERE JOB_PROCESS_CONTRL NOT IN (2,5,6,7,10,11,12) "
        SQL_STRING += " WHERE JOB_NUMBER = " & strJobNum
        SQL_STRING += " AND JOB_COMPONENT_NBR = " & strJobCompNum

        Try
            dr = oSQL.ExecuteReader(mConnString, CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobCompPO", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            rowcount = dr.GetInt32(0)
        End If

        dr.Close()
        If rowcount > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overloads Function ValidateTaxCode(ByRef ojobcomp As JobComponent) As Boolean
        Try
            If ojobcomp.TAX_FLAG = 1 Then
                Return ValidateTaxCode(ojobcomp.TAX_CODE)
            Else
                Return True
            End If
        Catch ex As Exception
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateTaxCode", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateTaxCode(ByVal strTaxCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateTaxCode" & strTaxCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim ireturn As Integer = 0
            Dim arparams(1) As SqlParameter

            Dim parameterTaxCode As New SqlParameter("@TaxCode", SqlDbType.VarChar, 4)

            parameterTaxCode.Value = strTaxCode
            arparams(0) = parameterTaxCode

            Try
                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_taxcode", arparams))
            Catch
                ireturn = 0
            End Try

            If ireturn > 0 Then
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

    'Public Function getOneCDP(ByVal ClientCodeFromListBox As String) As String
    '    Dim paramClientCode As New System.Data.SqlClient.SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
    '    paramClientCode.Value = ClientCodeFromListBox.Split("-")(0).ToString
    '    Return CType(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_JJ_IsSingleCDP", paramClientCode), String)

    'End Function

    Public Function ValidateNewJob(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal SCCode As String, ByVal AE As String, ByVal OfficeCode As String, ByRef ReturnMessage As String) As Boolean
        'usp_wv_validate_newjob
        Dim arParams(4) As SqlParameter

        Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
        If ClientCode.Trim.Length = 0 Then
            Err.Raise(9999, "cValidations:ValidateNewJob", "Client Code is Required")
        End If
        parameterClientCode.Value = ClientCode
        arParams(0) = parameterClientCode

        Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
        If DivisionCode.Trim.Length = 0 Then
            Err.Raise(9999, "cValidations:ValidateNewJob", "Division Code is Required")
        End If
        parameterDivisionCode.Value = DivisionCode
        arParams(1) = parameterDivisionCode

        Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
        If ProductCode.Trim.Length = 0 Then
            Err.Raise(9999, "cValidations:ValidateNewJob", "Product Code is Required")
        End If
        parameterProductCode.Value = ProductCode
        arParams(2) = parameterProductCode

        Dim parameterSalesClass As New SqlParameter("@SalesClass", SqlDbType.VarChar, 6)
        If SCCode.Trim.Length = 0 Then
            Err.Raise(9999, "cValidations:ValidateNewJob", "Sales Class Code is Required")
        End If
        parameterSalesClass.Value = SCCode
        arParams(3) = parameterSalesClass

        Try
            ReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_newjob", arParams)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateNewJob", Err.Description)
        End Try

        If ReturnMessage = "sucessful" Then

            If ValidateAccountExecutive(ClientCode, DivisionCode, ProductCode, AE) = False Then
                ReturnMessage = "Invalid Account Executive"
                Return False
            End If
            If ValidateSalesClassCode(SCCode) = False Then
                ReturnMessage = "Invalid Sales Code"
                Return False
            End If
            If OfficeCode.Trim().Length > 0 Then
                If ValidateOffice(OfficeCode) = False Then
                    ReturnMessage = "Invalid Office Code"
                    Return False
                End If
                Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))
                    If AdvantageFramework.Database.Procedures.EmployeeOffice.ValidateCDPOffice(DbContext, HttpContext.Current.Session("EmpCode"), ClientCode, DivisionCode, ProductCode) = False Then
                        ReturnMessage = "Invalid Office Code"
                        Return False
                    End If
                End Using

            End If

            Return True
        Else
            Return False
        End If

    End Function

    Public Overloads Function ValidateSalesClassCode(ByRef ojob As Job) As Boolean
        Try
            Return ValidateSalesClassCode(ojob.SC_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateCampaign", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateSalesClassCode(ByVal strSalesClass As String, Optional ByVal IncludeAll As Boolean = False) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateSalesClassCode" & strSalesClass & IncludeAll.ToString()

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim ireturn As Integer = 0
            Dim arparams(1) As SqlParameter

            Dim parameterSalesClassCode As New SqlParameter("@SalesClassCode", SqlDbType.VarChar, 6)

            parameterSalesClassCode.Value = strSalesClass
            arparams(0) = parameterSalesClassCode

            Try
                If IncludeAll = False Then
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_sales_class_code", arparams))
                Else
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_sales_class_code_all", arparams))
                End If
            Catch
                ireturn = 0
            End Try

            If ireturn > 0 Then
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

    Public Overloads Function ValidateCampaign(ByRef oJob As Job) As Boolean

        If oJob.CL_CODE.Trim.Length = 0 Then
            Err.Raise(9999, "cValidations:ValidateCampaign", "Client Code is Required")
        End If

        If oJob.DIV_CODE.Trim.Length = 0 Then
            Err.Raise(9999, "cValidations:ValidateCampaign", "Division Code is Required")
        End If

        If oJob.PRD_CODE.Trim.Length = 0 Then
            Err.Raise(9999, "cValidations:ValidateCampaign", "Product Code is Required")
        End If

        If oJob.CMP_CODE.Trim.Length = 0 Then
            Err.Raise(9999, "cValidations:ValidateCampaign", "Campaign Code is Required")
        End If

        Try
            Return ValidateCampaign(oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE, oJob.CMP_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateCampaign", Err.Description)
        End Try

    End Function
    Public Overloads Function ValidateCampaign(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal CampaignCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateCampaign" & ClientCode & DivisionCode & ProductCode & CampaignCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer
            Dim arParams(4) As SqlParameter

            Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If ClientCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateCampaign", "Client Code is Required")
            End If
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            If DivisionCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateCampaign", "Division Code is Required")
            End If
            parameterDivisionCode.Value = DivisionCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            If ProductCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateCampaign", "Product Code is Required")
            End If
            parameterProductCode.Value = ProductCode
            arParams(2) = parameterProductCode

            Dim parameterCampaignCode As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
            If CampaignCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateCampaign", "Campaign Code is Required")
            End If
            parameterCampaignCode.Value = CampaignCode
            arParams(3) = parameterCampaignCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_campaign", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateCampaignEstimate(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal CampaignCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateCampaignEstimate" & ClientCode & DivisionCode & ProductCode & CampaignCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer
            Dim arParams(4) As SqlParameter

            Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If ClientCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateCampaign", "Client Code is Required")
            End If
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            If DivisionCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateCampaign", "Division Code is Required")
            End If
            parameterDivisionCode.Value = DivisionCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            If ProductCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateCampaign", "Product Code is Required")
            End If
            parameterProductCode.Value = ProductCode
            arParams(2) = parameterProductCode

            Dim parameterCampaignCode As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
            If CampaignCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateCampaign", "Campaign Code is Required")
            End If
            parameterCampaignCode.Value = CampaignCode
            arParams(3) = parameterCampaignCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_campaign_estimate", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    'Public Function ValidateCampaignAlert(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal CampaignCode As String) As Boolean
    '    Try
    '        Dim iReturn As Integer
    '        Dim arParams(4) As SqlParameter

    '        Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
    '        parameterClientCode.Value = ClientCode
    '        arParams(0) = parameterClientCode

    '        Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
    '        parameterDivisionCode.Value = DivisionCode
    '        arParams(1) = parameterDivisionCode

    '        Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
    '        parameterProductCode.Value = ProductCode
    '        arParams(2) = parameterProductCode

    '        Dim parameterCampaignCode As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
    '        parameterCampaignCode.Value = CampaignCode
    '        arParams(3) = parameterCampaignCode

    '        iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_campaign", arParams))

    '        If iReturn > 0 Then
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    Public Function ValidateCampaignIsViewable(ByVal UserID As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal CampaignCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateCampaignIsViewable" & UserID & AdvantageFramework.Security.Encryption.ASCIIEncoding(ClientCode & DivisionCode & ProductCode & CampaignCode)
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim iReturn As Integer
                Dim arParams(5) As SqlParameter

                Dim parameterUserCode As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
                parameterUserCode.Value = UserID
                arParams(0) = parameterUserCode

                Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
                parameterClientCode.Value = ClientCode
                arParams(1) = parameterClientCode

                Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
                parameterDivisionCode.Value = DivisionCode
                arParams(2) = parameterDivisionCode

                Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
                parameterProductCode.Value = ProductCode
                arParams(3) = parameterProductCode

                Dim parameterCampaignCode As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
                parameterCampaignCode.Value = CampaignCode
                arParams(4) = parameterCampaignCode

                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_campaign_isViewable", arParams))

                If iReturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateCampaignFilter(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal CampaignCode As String) As Boolean
        Dim IsValid As Boolean = False
        'Dim SessionKey As String = "ValidateCampaignFilter" & AdvantageFramework.Security.Encryption.ASCIIEncoding(ClientCode & DivisionCode & ProductCode & CampaignCode)

        'If HttpContext.Current.Session(SessionKey) Is Nothing Then
        Try
            Dim iReturn As Integer
            Dim arParams(4) As SqlParameter

            Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            parameterDivisionCode.Value = DivisionCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            parameterProductCode.Value = ProductCode
            arParams(2) = parameterProductCode

            Dim parameterCampaignCode As New SqlParameter("@CampaignCode", SqlDbType.VarChar, 6)
            parameterCampaignCode.Value = CampaignCode
            arParams(3) = parameterCampaignCode

            iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_campaign_filter", arParams))

            If iReturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If
        Catch ex As Exception
            IsValid = False
        End Try

        '    HttpContext.Current.Session(SessionKey) = IsValid
        'Else
        '    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        'End If
        Return IsValid
    End Function

    Public Overloads Function ValidateCoopBilling(ByRef oJob As Job) As Boolean
        Try
            Return ValidateCoopBilling(oJob.BILL_COOP_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateCoopBilling", Err.Description)
        End Try

    End Function
    Public Overloads Function ValidateCoopBilling(ByVal BillingCoopCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateCoopBilling" & BillingCoopCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer

            Dim Tparameter As New SqlParameter("@CoopBillingCode", SqlDbType.VarChar, 6)
            If BillingCoopCode.Trim.Length = 0 Then
                Err.Raise(9999, "Jobs:ValidateCoopBilling", "Billing Coop Code is Required")
            End If
            Tparameter.Value = BillingCoopCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_coop_billing", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobComponentAccountNumber(ByRef oJobComponent As JobComponent) As Boolean
        Try
            Return ValidateJobComponentAccountNumber(oJobComponent.ACCT_NBR)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobCodeAccountNumber(oJobComponent)", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobComponentAccountNumber(ByVal AccountNumber As String) As Boolean
        Dim IsValid As Boolean = True
        Dim SessionKey As String = "ValidateJobComponentAccountNumber" & AccountNumber

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then

            Dim arParams(1) As SqlParameter
            Dim iSQLRetVal As Integer = 0
            If AccountNumber <> String.Empty Then
                Dim prmAccountNumber As New SqlParameter("@AccountNumber", SqlDbType.VarChar, 30)
                prmAccountNumber.Value = AccountNumber
                arParams(0) = prmAccountNumber

                Try
                    iSQLRetVal = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_jc_account_number", arParams))
                Catch
                    iSQLRetVal = 0
                End Try

                If iSQLRetVal = 0 Then
                    IsValid = False
                End If

            End If

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Overloads Function ValidateSalesClassFormat(ByRef oJob As Job) As Boolean
        Try
            Return ValidateSalesClassFormat(oJob.SC_CODE, oJob.FORMAT_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateSalesClassFormat", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateSalesClassFormat(ByVal SalesClassCode As String, ByVal SalesClassFormatCode As String) As Boolean
        If SalesClassFormatCode = String.Empty Or SalesClassFormatCode = "" Or SalesClassFormatCode.Length < 1 Then
            Return True
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateSalesClassFormat" & SalesClassCode & SalesClassFormatCode

            SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim arParams(2) As SqlParameter
                Dim iReturn As Integer

                Dim Tparameter1 As New SqlParameter("@SalesClassCode", SqlDbType.VarChar, 6)
                If SalesClassCode.Trim.Length = 0 Then
                    Err.Raise(9999, "Jobs:ValidateSalesClassFormat", "Sales Class Code is Required")
                End If
                Tparameter1.Value = SalesClassCode
                arParams(0) = Tparameter1

                Dim Tparameter2 As New SqlParameter("@SalesClassFormatCode", SqlDbType.VarChar, 8)
                If SalesClassFormatCode.Trim.Length = 0 Then
                    Err.Raise(9999, "Jobs:ValidateSalesClassFormat", "Sales Class Format Code is Required")
                End If
                Tparameter2.Value = SalesClassFormatCode
                arParams(1) = Tparameter2

                Try
                    iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_sales_class_format", arParams))
                Catch
                    iReturn = 0
                End Try

                If iReturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If
            Return IsValid
        End If
    End Function

    Public Overloads Function ValidateComplexity(ByRef oJob As Job) As Boolean
        Try
            Return ValidateComplexity(oJob.COMPLEX_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateComplexity", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateComplexity(ByVal ComplexityCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateComplexity" & ComplexityCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ComplexityCode", SqlDbType.VarChar, 8)
            If ComplexityCode.Trim.Length = 0 Then
                Err.Raise(9999, "Class:cValidations Routine:ValidateComplexity", "Complexity Code is Required")
            End If
            Tparameter.Value = ComplexityCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_complexity", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidatePromotion(ByRef oJob As Job) As Boolean
        Try
            Return ValidatePromotion(oJob.PROMO_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidatePromotion", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidatePromotion(ByVal Promotioncode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidatePromotion" & Promotioncode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer

            Dim Tparameter As New SqlParameter("@PromotionCode", SqlDbType.VarChar, 8)
            Tparameter.Value = Promotioncode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_promotion", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobType(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateJobType(ojobcomp.JT_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobType", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobType(ByVal JobTypeCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobType" & JobTypeCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@JobTypeCode", SqlDbType.VarChar, 10)
            Tparameter.Value = JobTypeCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_job_type", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateDeptTeam(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateDeptTeam(ojobcomp.DP_TM_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateDeptTeam", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateDeptTeam(ByVal DeptTeamCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateDeptTeam" & DeptTeamCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@DeptTeamCode", SqlDbType.VarChar, 4)
            Tparameter.Value = DeptTeamCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_dept_team", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateAdNumber(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateAdNumber(ojobcomp.AD_NBR)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateAdNumber", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateAdNumber(ByVal AdNumber As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateAdNumber" & AdNumber

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@ADNumber", SqlDbType.VarChar, 30)
            Tparameter.Value = AdNumber

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_ad_number", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Function ValidateExpenseInv(ByVal inv As String, Optional ByVal empcode As String = "") As Boolean
        If inv = "" Then Return False

        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateExpenseInv" & inv & empcode
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Dim arParams(2) As SqlParameter

            Dim Tparameter As New SqlParameter("@INV_NBR", SqlDbType.Int)
            Tparameter.Value = CInt(inv)
            arParams(0) = Tparameter

            Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
            parameterEmpCode.Value = empcode
            arParams(1) = parameterEmpCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_expense", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateAccountExecutive(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateAccountExecutive(ojobcomp.ParentJob.CL_CODE, ojobcomp.ParentJob.DIV_CODE, ojobcomp.ParentJob.PRD_CODE, ojobcomp.EMP_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateAccountExecutive", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateAccountExecutive(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal AccountExec As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateAccountExecutive" & ClientCode & DivisionCode & ProductCode & AccountExec

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Dim arParams(4) As SqlParameter

            Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
            If ClientCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateAccountExecutive", "Client Code is Required")
            End If
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
            If DivisionCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateAccountExecutive", "Division Code is Required")
            End If
            parameterDivisionCode.Value = DivisionCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
            If ProductCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateAccountExecutive", "Product Code is Required")
            End If
            parameterProductCode.Value = ProductCode
            arParams(2) = parameterProductCode

            Dim parameterAE As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            If AccountExec.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateAccountExecutive", "Product Contact Code is Required")
            End If
            parameterAE.Value = AccountExec
            arParams(3) = parameterAE

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_account_executive", arParams))
            Catch
                Err.Raise(Err.Number, "Class:cValidations Routine:ValidateAccountExecutive", Err.Description)
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateMarket(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateMarket(ojobcomp.MARKET_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateMarket", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateMarket(ByVal MarketCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateMarket" & MarketCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@MarketCode", SqlDbType.VarChar, 10)
            Tparameter.Value = MarketCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_market", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateProdContact(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateProdContact(ojobcomp.ParentJob.CL_CODE, ojobcomp.ParentJob.DIV_CODE, ojobcomp.ParentJob.PRD_CODE, ojobcomp.PRD_CONT_CODE)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateProdContact", Err.Description)
        End Try

    End Function
    Public Overloads Function ValidateProdContact(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal ContactCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateProdContact" & ClientCode & DivisionCode & ProductCode & ContactCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0
            Dim arParams(4) As SqlParameter

            Dim parameterClientCode As New SqlParameter("@ClientCode", SqlDbType.VarChar, 6)
            If ClientCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProdContact", "Client Code is Required")
            End If
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@DivisionCode", SqlDbType.VarChar, 6)
            If DivisionCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProdContact", "Division Code is Required")
            End If
            parameterDivisionCode.Value = DivisionCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@ProductCode", SqlDbType.VarChar, 6)
            If ProductCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProdContact", "Product Code is Required")
            End If
            parameterProductCode.Value = ProductCode
            arParams(2) = parameterProductCode

            Dim parameterProductCategory As New SqlParameter("@ProductContact", SqlDbType.VarChar, 10)
            If ContactCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProdContact", "Product Contact Code is Required")
            End If
            parameterProductCategory.Value = ContactCode
            arParams(3) = parameterProductCategory

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_product_contact", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobCompUDF1(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateJobCompUDF1(ojobcomp.UDF1.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobCompUDF1", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobCompUDF1(ByRef UDF1 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobCompUDF1" & UDF1

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF1

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf1_jc", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobCompUDF2(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateJobCompUDF2(ojobcomp.UDF2.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobCompUDF2", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobCompUDF2(ByRef UDF2 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobCompUDF2" & UDF2

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF2

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf2_jc", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobCompUDF3(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateJobCompUDF3(ojobcomp.UDF3.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobCompUDF3", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobCompUDF3(ByRef UDF3 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobCompUDF3" & UDF3

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF3

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf3_jc", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobCompUDF4(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateJobCompUDF4(ojobcomp.UDF4.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobCompUDF4", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobCompUDF4(ByRef UDF4 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobCompUDF4" & UDF4

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF4

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf4_jc", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobCompUDF5(ByRef ojobcomp As JobComponent) As Boolean
        Try
            Return ValidateJobCompUDF5(ojobcomp.UDF5.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobCompUDF5", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobCompUDF5(ByRef UDF5 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobCompUDF5" & UDF5

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF5

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf5_jc", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobUDF1(ByRef ojob As Job) As Boolean
        Try
            Return ValidateJobUDF1(ojob.UDF1.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobUDF1", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobUDF1(ByRef UDF1 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobUDF1" & UDF1


        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF1

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf1", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobUDF2(ByRef ojob As Job) As Boolean
        Try
            Return ValidateJobUDF2(ojob.UDF2.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobUDF2", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobUDF2(ByRef UDF2 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobUDF2" & UDF2

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF2

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf2", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobUDF3(ByRef ojob As Job) As Boolean
        Try
            Return ValidateJobUDF3(ojob.UDF3.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobUDF3", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobUDF3(ByRef UDF3 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobUDF3" & UDF3

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF3

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf3", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobUDF4(ByRef ojob As Job) As Boolean
        Try
            Return ValidateJobUDF4(ojob.UDF4.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobUDF4", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobUDF4(ByRef UDF4 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobUDF4" & UDF4

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF4

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf4", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateJobUDF5(ByRef ojob As Job) As Boolean
        Try
            Return ValidateJobUDF5(ojob.UDF5.Code)
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobUDF5", Err.Description)
        End Try
    End Function
    Public Overloads Function ValidateJobUDF5(ByRef UDF5 As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateJobUDF5" & UDF5

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@UDV_CODE", SqlDbType.VarChar, 10)
            Tparameter.Value = UDF5

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_udf5", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Function ValidateProductCategory(ByVal ProductCategoryCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateProductCategory" & ProductCategoryCode & ClientCode & DivisionCode & ProductCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive
        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer
            Dim arParams(4) As SqlParameter

            Dim parameterClientCode As New SqlParameter("@Client", SqlDbType.VarChar, 6)
            If ClientCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProductCategory", "Client Code is Required")
            End If
            parameterClientCode.Value = ClientCode
            arParams(0) = parameterClientCode

            Dim parameterDivisionCode As New SqlParameter("@Division", SqlDbType.VarChar, 6)
            If DivisionCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProductCategory", "Division Code is Required")
            End If
            parameterDivisionCode.Value = DivisionCode
            arParams(1) = parameterDivisionCode

            Dim parameterProductCode As New SqlParameter("@Product", SqlDbType.VarChar, 6)
            If ProductCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProductCategory", "Product Code is Required")
            End If
            parameterProductCode.Value = ProductCode
            arParams(2) = parameterProductCode

            Dim parameterProductCategoryCode As New SqlParameter("@ProductCategory", SqlDbType.VarChar, 10)
            If ProductCategoryCode.Trim.Length = 0 Then
                Err.Raise(9999, "cValidations:ValidateProductCategory", "Product Category Code is Required")
            End If
            parameterProductCategoryCode.Value = ProductCategoryCode
            arParams(3) = parameterProductCategoryCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_product_category", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    'Public Function ValidateFunctionCategory(ByVal Empcode As String, ByVal FuncDept As String, ByVal FuncType As String) As Boolean
    '    Dim arParams(2) As SqlParameter
    '    Dim iReturn As Integer

    '    Dim Tparameter1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
    '    If Empcode = "" Then
    '        'Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Employee Code is Required")
    '        Return False
    '        Exit Function
    '    End If
    '    Tparameter1.Value = Empcode
    '    arParams(0) = Tparameter1

    '    Dim Tparameter2 As New SqlParameter("@FuncCat", SqlDbType.VarChar, 10)
    '    If FuncDept = "" Then
    '        'Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Function/Department is Required")
    '        Return False
    '        Exit Function
    '    End If
    '    Tparameter2.Value = FuncDept
    '    arParams(1) = Tparameter2

    '    Dim Tparameter3 As New SqlParameter("@FuncType", SqlDbType.VarChar, 1)
    '    If FuncType = "" Then
    '        'Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Function Type is Required")
    '        Return False
    '        Exit Function
    '    End If
    '    Tparameter3.Value = FuncType
    '    arParams(2) = Tparameter3

    '    Try
    '        iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncat", arParams))
    '    Catch
    '        Err.Raise(Err.Number, "Class:cValidations Routine:ValidateFunctionCategory", Err.Description)
    '    End Try

    '    If iReturn > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Public Function ValidateFunctionTSAddNew(ByVal EmpCode As String, ByVal FuncCode As String) As Boolean

        Dim IsValid As Boolean = False
        Dim arParams(2) As SqlParameter
        Dim Tparameter1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
        Dim Tparameter2 As New SqlParameter("@FuncCode", SqlDbType.VarChar)

        Tparameter1.Value = EmpCode
        arParams(0) = Tparameter1

        Tparameter2.Value = FuncCode
        arParams(1) = Tparameter2

        Try
            IsValid = CBool(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncat_ts_addnew", arParams))
        Catch
            IsValid = False
        End Try

        Return IsValid

    End Function
    Public Function ValidateFunctionDeptTeamIsInActive(ByVal FunctionCode As String) As Boolean

        Try

            Return CType(oSQL.ExecuteScalar(mConnString, CommandType.Text, String.Format("SELECT COUNT(1) FROM FUNCTIONS WITH(NOLOCK) INNER JOIN DEPT_TEAM WITH(NOLOCK) ON FUNCTIONS.DP_TM_CODE = DEPT_TEAM.DP_TM_CODE WHERE FUNCTIONS.FNC_CODE = '{0}' AND DEPT_TEAM.INACTIVE_FLAG = 1;", FunctionCode)), Integer) = 1

        Catch ex As Exception

            Return False

        End Try

    End Function

    'Public Function ValidateFunctionCategoryTS(ByVal Empcode As String, ByVal FuncDept As String, ByVal FuncType As String) As Boolean
    '    Dim arParams(2) As SqlParameter
    '    Dim iReturn As Integer

    '    Dim Tparameter1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
    '    If Empcode = "" Then
    '        Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Employee Code is Required")
    '    End If
    '    Tparameter1.Value = Empcode
    '    arParams(0) = Tparameter1

    '    Dim Tparameter2 As New SqlParameter("@FuncCat", SqlDbType.VarChar, 10)
    '    If FuncDept = "" Then
    '        Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Function/Department is Required")
    '    End If
    '    Tparameter2.Value = FuncDept
    '    arParams(1) = Tparameter2

    '    Dim Tparameter3 As New SqlParameter("@FuncType", SqlDbType.VarChar, 1)
    '    If FuncType = "" Then
    '        Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Function Type is Required")
    '    End If
    '    Tparameter3.Value = FuncType
    '    arParams(2) = Tparameter3

    '    Try
    '        iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncat_ts", arParams))
    '    Catch
    '        Err.Raise(Err.Number, "Class:cValidations Routine:ValidateFunctionCategory", Err.Description)
    '    End Try

    '    If iReturn > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Public Function ValidateFunctionCategoryAll(ByVal Empcode As String, ByVal FuncDept As String, ByVal FuncType As String, Optional ByVal boolIsCategory As Boolean = False) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateFunctionCategoryAll" & Empcode & FuncDept & FuncType & boolIsCategory.ToString()

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(2) As SqlParameter
            Dim iReturn As Integer

            Dim Tparameter1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
            If Empcode = "" Then
                Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Employee Code is Required")
            End If
            Tparameter1.Value = Empcode
            arParams(0) = Tparameter1

            Dim Tparameter2 As New SqlParameter("@FuncCat", SqlDbType.VarChar, 10)
            If FuncDept = "" Then
                Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Function/Department is Required")
            End If
            Tparameter2.Value = FuncDept
            arParams(1) = Tparameter2

            Dim Tparameter3 As New SqlParameter("@FuncType", SqlDbType.VarChar, 1)
            If FuncType = "" Then
                Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Function Type is Required")
            End If
            Tparameter3.Value = FuncType
            arParams(2) = Tparameter3

            Try
                If boolIsCategory = False Then
                    iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncat_all", arParams))
                Else
                    iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_category", arParams(1)))
                End If
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateBlackplate(ByVal strCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateBlackplate" & strCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim ireturn As Integer = 0
            Dim arparams(1) As SqlParameter

            Dim parameterCode As New SqlParameter("@Code", SqlDbType.VarChar, 6)

            'If strTaxCode.Trim.Length = 0 Then
            '    Err.Raise(9999, "cValidations:ValidateTaxCode", "Valid Tax Code is Required")
            'End If
            parameterCode.Value = strCode
            arparams(0) = parameterCode

            Try
                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_blackplate", arparams))
            Catch
                ireturn = 0
            End Try

            If ireturn > 0 Then
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

    Public Function ValidateStatus(ByVal Status As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateStatus" & Status

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(1) As SqlParameter

                Dim parameterStatus As New SqlParameter("@Status", SqlDbType.VarChar)
                parameterStatus.Value = Status
                arParams(0) = parameterStatus

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_status", arParams)

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If

            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If
        Return IsValid
    End Function

    Public Function ValidateRegion(ByVal Region As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateRegion" & Region

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(1) As SqlParameter

                Dim parameterRegion As New SqlParameter("@Region", SqlDbType.VarChar)
                parameterRegion.Value = Region
                arParams(0) = parameterRegion

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_region", arParams)

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If
        Return IsValid
    End Function

    Public Function ValidateTaskCode(ByVal TaskCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateTaskCode" & TaskCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@TaskCode", SqlDbType.VarChar)
            Tparameter.Value = TaskCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_task_code", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Function ValidateRoleCode(ByVal RoleCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateRoleCode" & RoleCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim iReturn As Integer = 0

            Dim Tparameter As New SqlParameter("@RoleCode", SqlDbType.VarChar)
            Tparameter.Value = RoleCode

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_role", Tparameter))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Function ValidateAdSize(ByVal AdSize As String, ByVal MediaType As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateAdSize" & AdSize & MediaType

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive


        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As String = String.Empty

                Dim arParams(2) As SqlParameter

                Dim parameterAdSize As New SqlParameter("@AdSize", SqlDbType.VarChar)
                parameterAdSize.Value = AdSize
                arParams(0) = parameterAdSize

                Dim parameterMediaType As New SqlParameter("@MediaType", SqlDbType.VarChar)
                parameterMediaType.Value = MediaType
                arParams(1) = parameterMediaType

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_adsize", arParams)

                If myReturnMessage = "Valid" Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateGlaCode(ByVal GlaCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateGlaCode" & GlaCode


        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As Integer = 0

                Dim arParams(1) As SqlParameter

                Dim parameterGlaCode As New SqlParameter("@GlaCode", SqlDbType.VarChar)
                parameterGlaCode.Value = GlaCode
                arParams(0) = parameterGlaCode

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_gla_code", arParams)

                If myReturnMessage = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateEstimateNumber(ByVal strEstNum As String) As Boolean
        If strEstNum = "" Or strEstNum = String.Empty Or IsNumeric(strEstNum) = False Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateEstimateNumber" & strEstNum

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(1) As SqlParameter

                Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
                parameterEstNum.Value = strEstNum
                arparams(0) = parameterEstNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_EstNum", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If

            Return IsValid

        End If
    End Function

    Public Function ValidateEstimateCompNumber(ByVal strEstNum As String, ByVal strEstCompNum As String) As Boolean
        If strEstNum = "" Or strEstNum = String.Empty Or strEstCompNum = "" Or strEstCompNum = String.Empty Or IsNumeric(strEstNum) = False Or IsNumeric(strEstCompNum) = False Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateEstimateCompNumber" & strEstNum.PadLeft(6, "0") & strEstCompNum.PadLeft(6, "0")

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(2) As SqlParameter

                Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
                parameterEstNum.Value = strEstNum
                arparams(0) = parameterEstNum

                Dim parameterEstCompNum As New SqlParameter("@EstCompNum", SqlDbType.SmallInt)
                parameterEstCompNum.Value = strEstCompNum
                arparams(1) = parameterEstCompNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_EstimateCompNum", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If

            Return IsValid

        End If
    End Function

    Public Function ValidateEstimateQuote(ByVal strEstNum As String, ByVal strEstCompNum As String, ByVal strQuoteNum As String) As Boolean
        If strEstNum = "" Or strEstNum = String.Empty Or strEstCompNum = "" Or strEstCompNum = String.Empty Or strQuoteNum = "" Or strQuoteNum = String.Empty Or IsNumeric(strEstNum) = False Or IsNumeric(strEstCompNum) = False Or IsNumeric(strQuoteNum) = False Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateEstimateQuote" & strEstNum.PadLeft(6, "0") & strEstCompNum.PadLeft(6, "0") & strQuoteNum.PadLeft(6, "0")

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(3) As SqlParameter

                Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
                parameterEstNum.Value = strEstNum
                arparams(0) = parameterEstNum

                Dim parameterEstCompNum As New SqlParameter("@EstCompNum", SqlDbType.SmallInt)
                parameterEstCompNum.Value = strEstCompNum
                arparams(1) = parameterEstCompNum

                Dim parameterQuoteNum As New SqlParameter("@QuoteNum", SqlDbType.SmallInt)
                parameterQuoteNum.Value = strQuoteNum
                arparams(2) = parameterQuoteNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_EstimateQuote", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If

            Return IsValid

        End If
    End Function

    Public Function ValidateJobEstimateNumber(ByVal strJobNum As String, ByVal strJobCompNum As String, ByVal strEstNum As String, ByVal strEstCompNum As String) As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Or strJobCompNum = "" Or strJobCompNum = String.Empty Or IsNumeric(strJobNum) = False Or IsNumeric(strJobCompNum) = False Then
            Return False
            Exit Function
        ElseIf strEstNum = "" Or strEstNum = String.Empty Or strEstCompNum = "" Or strEstCompNum = String.Empty Or IsNumeric(strEstNum) = False Or IsNumeric(strEstCompNum) = False Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            Dim SessionKey As String = "ValidateJobEstimateNumber" & strEstNum.PadLeft(6, "0") & strEstCompNum.PadLeft(6, "0") & strJobNum.PadLeft(6, "0") & strJobCompNum.PadLeft(6, "0")

            If HttpContext.Current.Session(SessionKey) Is Nothing Then
                Dim ireturn As Integer = 0
                Dim arparams(4) As SqlParameter

                Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
                parameterJobNum.Value = strJobNum
                arparams(0) = parameterJobNum

                Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.SmallInt)
                parameterJobCompNum.Value = strJobCompNum
                arparams(1) = parameterJobCompNum

                Dim parameterEstNum As New SqlParameter("@EstNum", SqlDbType.Int)
                parameterEstNum.Value = strEstNum
                arparams(2) = parameterEstNum

                Dim parameterEstCompNum As New SqlParameter("@EstCompNum", SqlDbType.SmallInt)
                parameterEstCompNum.Value = strEstCompNum
                arparams(3) = parameterEstCompNum

                Try
                    ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobEstimateNum", arparams))
                Catch
                    ireturn = 0
                End Try

                If ireturn > 0 Then
                    IsValid = True
                Else
                    IsValid = False
                End If

                HttpContext.Current.Session(SessionKey) = IsValid
            Else
                IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            End If

            Return IsValid

        End If
    End Function
    'Public Overloads Function ValidateFunctionCode(ByVal Empcode As String, ByVal FuncCode As String) As Boolean
    '    Dim arParams(2) As SqlParameter
    '    Dim iReturn As Integer

    '    Dim Tparameter1 As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
    '    If Empcode = "" Then
    '        'Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Employee Code is Required")
    '        Return False
    '        Exit Function
    '    End If
    '    Tparameter1.Value = Empcode
    '    arParams(0) = Tparameter1

    '    Dim Tparameter2 As New SqlParameter("@FuncCode", SqlDbType.VarChar, 10)
    '    If FuncCode = "" Then
    '        'Err.Raise(9999, "cValidation:ValidateFunctionCategory", "Function/Department is Required")
    '        Return False
    '        Exit Function
    '    End If
    '    Tparameter2.Value = FuncCode
    '    arParams(1) = Tparameter2

    '    Try
    '        iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncode", arParams))
    '    Catch
    '        Err.Raise(Err.Number, "Class:cValidations Routine:ValidateFunctionCode", Err.Description)
    '    End Try

    '    If iReturn > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Public Overloads Function ValidateFunctionCode(ByVal FuncCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateFunctionCode" & FuncCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive


        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(1) As SqlParameter
            Dim iReturn As Integer

            Dim Tparameter2 As New SqlParameter("@FuncCode", SqlDbType.VarChar, 10)
            If FuncCode = "" Then
                Return False
            End If
            Tparameter2.Value = FuncCode
            arParams(0) = Tparameter2

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncode_all", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Function ValidateFunctionCodeEst(ByVal FuncCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateFunctionCodeEst" & FuncCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive


        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(1) As SqlParameter
            Dim iReturn As Integer

            Dim Tparameter2 As New SqlParameter("@FuncCode", SqlDbType.VarChar, 10)
            If FuncCode = "" Then
                Return False
            End If
            Tparameter2.Value = FuncCode
            arParams(0) = Tparameter2

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncode_est", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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
    Public Function ValidateFunctionCodeEst(ByVal FuncCode As String, ByVal JobNumber As Integer, ByVal ClientCode As String) As Boolean

        Dim IsValid As Boolean = False

        Using DbContext = New AdvantageFramework.Database.DbContext(mConnString, HttpContext.Current.Session("UserCode"))

            Try

                IsValid = DbContext.Database.SqlQuery(Of Integer)(String.Format("EXEC [dbo].[usp_wv_validate_functioncode_est] '{0}';", FuncCode)).FirstOrDefault() > 0

            Catch ex As Exception
                IsValid = False
            End Try

            If IsValid = True Then

                Dim Fnc As AdvantageFramework.Database.Entities.Function = Nothing

                Fnc = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FuncCode)

                If Fnc IsNot Nothing AndAlso Fnc.Type = "E" Then

                    If JobNumber > 0 OrElse String.IsNullOrEmpty(ClientCode) = False Then

                        Dim RestrictedFunctionCode As String = String.Empty
                        Dim LimitFunctionsByBillingRate As Boolean = False

                        If String.IsNullOrWhiteSpace(ClientCode) = False AndAlso JobNumber > 0 Then

                            Try

                                ClientCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CL_CODE FROM JOB_LOG WHERE JOB_NUMBER = {0};", JobNumber)).SingleOrDefault

                            Catch ex As Exception
                                ClientCode = String.Empty
                            End Try

                        End If

                        If String.IsNullOrWhiteSpace(ClientCode) = False Then

                            Try

                                LimitFunctionsByBillingRate = DbContext.Database.SqlQuery(Of Boolean)(String.Format("SELECT CAST(ISNULL(LIMIT_TIME_FUNCTIONS_TO_BILLING_HIERARCHY, 0) AS BIT) FROM CLIENT WHERE CL_CODE = '{0}';", ClientCode)).SingleOrDefault

                            Catch ex As Exception
                                LimitFunctionsByBillingRate = False
                            End Try

                        End If
                        If LimitFunctionsByBillingRate = True Then

                            Try

                                RestrictedFunctionCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT FNC_CODE FROM BILLING_RATE WHERE CL_CODE = '{0}' AND FNC_CODE = '{1}';", ClientCode, FuncCode)).FirstOrDefault

                            Catch ex As Exception
                                RestrictedFunctionCode = String.Empty
                            End Try

                            If FuncCode = RestrictedFunctionCode Then

                                IsValid = True

                            Else

                                IsValid = False

                            End If

                        End If

                    End If

                End If

            End If

        End Using

        Return IsValid

    End Function

    Public Function ValidateFunctionCodeEvt(ByVal FuncCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateFunctionCodeEvt" & FuncCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive


        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(1) As SqlParameter
            Dim iReturn As Integer

            Dim Tparameter2 As New SqlParameter("@FuncCode", SqlDbType.VarChar, 10)
            If FuncCode = "" Then
                Return False
            End If
            Tparameter2.Value = FuncCode
            arParams(0) = Tparameter2

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncode_evt", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Overloads Function ValidateFunctionCodeVendor(ByVal FuncCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidateFunctionCode" & FuncCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive


        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim arParams(1) As SqlParameter
            Dim iReturn As Integer

            Dim Tparameter2 As New SqlParameter("@FuncCode", SqlDbType.VarChar, 10)
            If FuncCode = "" Then
                Return False
            End If
            Tparameter2.Value = FuncCode
            arParams(0) = Tparameter2

            Try
                iReturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_functioncode_vendor", arParams))
            Catch
                iReturn = 0
            End Try

            If iReturn > 0 Then
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

    Public Function ValidatePOApprover(ByVal EmpCode As String) As Boolean
        Dim IsValid As Boolean = False
        Dim SessionKey As String = "ValidatePOApprover" & EmpCode

        SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive


        If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Try
                Dim myReturnMessage As Integer = 0

                Dim arParams(1) As SqlParameter

                Dim parameterEmpCode As New SqlParameter("@EmpCode", SqlDbType.VarChar, 6)
                parameterEmpCode.Value = EmpCode
                arParams(0) = parameterEmpCode

                myReturnMessage = oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_poapprover", arParams)

                If myReturnMessage = 1 Then
                    IsValid = True
                Else
                    IsValid = False
                End If
            Catch ex As Exception
                IsValid = False
            End Try

            HttpContext.Current.Session(SessionKey) = IsValid
        Else
            IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        End If

        Return IsValid

    End Function

    Public Function ValidateJobNumberUserDefined(ByVal strJobNum As String, ByVal userfield As String) As Boolean
        If strJobNum = "" Or strJobNum = String.Empty Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            'Dim SessionKey As String = "ValidateTrafficStatus" & strJobNum.PadLeft(6, "0") & userfield

            'SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

            'If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim ireturn As Integer = 0
            Dim arparams(2) As SqlParameter

            Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.VarChar)
            parameterJobNum.Value = strJobNum
            arparams(0) = parameterJobNum

            Dim parameterUserField As New SqlParameter("@UserField", SqlDbType.VarChar)
            parameterUserField.Value = userfield
            arparams(1) = parameterUserField

            Try
                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobNumUserDefined", arparams))
            Catch
                ireturn = 0
            End Try

            If ireturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            '    HttpContext.Current.Session(SessionKey) = IsValid
            'Else
            '    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            'End If
            Return IsValid
        End If
    End Function
    Public Function ValidateJobCompNumberUserDefined(ByVal strJobCompNum As String, ByVal userfield As String) As Boolean
        If strJobCompNum = "" Or strJobCompNum = String.Empty Then
            Return False
            Exit Function
        Else
            Dim IsValid As Boolean = False
            'Dim SessionKey As String = "ValidateJobCompNumberUserDefined" & strJobCompNum.PadLeft(6, "0") & userfield

            'SessionKey = AdvantageFramework.Security.Encryption.ASCIIEncoding(SessionKey) 'Make sure session key is case sensitive

            'If HttpContext.Current.Session(SessionKey) Is Nothing Then
            Dim ireturn As Integer = 0
            Dim arparams(2) As SqlParameter

            Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.VarChar)
            parameterJobCompNum.Value = strJobCompNum
            arparams(0) = parameterJobCompNum

            Dim parameterUserField As New SqlParameter("@UserField", SqlDbType.VarChar)
            parameterUserField.Value = userfield
            arparams(1) = parameterUserField

            Try
                ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobCompNumUserDefined", arparams))
            Catch
                ireturn = 0
            End Try

            If ireturn > 0 Then
                IsValid = True
            Else
                IsValid = False
            End If

            '    HttpContext.Current.Session(SessionKey) = IsValid
            'Else
            '    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
            'End If
            Return IsValid
        End If
    End Function

    Public Function ValidateJobSpecsVersion(ByVal JobNum As Integer, ByVal JobComp As Integer, ByVal version As Integer, ByVal revision As Integer) As Boolean
        Dim IsValid As Boolean = False
        'Dim SessionKey As String = "ValidateJobSpecsVersion" & JobNum.ToString().PadLeft(6, "0") & JobComp.ToString().PadLeft(6, "0") & version.ToString().PadLeft(6, "0") & revision.ToString().PadLeft(6, "0")

        'If HttpContext.Current.Session(SessionKey) Is Nothing Then
        Dim ireturn As Integer = 0
        Dim arparams(4) As SqlParameter

        Dim parameterJobNum As New SqlParameter("@JobNum", SqlDbType.Int)
        parameterJobNum.Value = JobNum
        arparams(0) = parameterJobNum

        Dim parameterJobCompNum As New SqlParameter("@JobCompNum", SqlDbType.Int)
        parameterJobCompNum.Value = JobComp
        arparams(1) = parameterJobCompNum

        Dim parameterVERSION As New SqlParameter("@VERSION", SqlDbType.Int)
        parameterVERSION.Value = version
        arparams(2) = parameterVERSION

        Dim parameterREVISION As New SqlParameter("@REVISION", SqlDbType.Int)
        parameterREVISION.Value = revision
        arparams(3) = parameterREVISION

        Try
            ireturn = CInt(oSQL.ExecuteScalar(mConnString, CommandType.StoredProcedure, "usp_wv_validate_JobSpecVersion", arparams))
        Catch
            Err.Raise(Err.Number, "Class:cValidations Routine:ValidateJobSpecVersion", Err.Description)
        End Try

        If ireturn > 0 Then
            IsValid = True
        Else
            IsValid = False
        End If

        '    HttpContext.Current.Session(SessionKey) = IsValid
        'Else
        '    IsValid = CType(HttpContext.Current.Session(SessionKey), Boolean)
        'End If

        Return IsValid

    End Function

    Public Sub New(ByVal ConnectionString As String)
        mConnString = ConnectionString
    End Sub
End Class
